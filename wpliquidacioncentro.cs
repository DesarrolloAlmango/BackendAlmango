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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpliquidacioncentro : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpliquidacioncentro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpliquidacioncentro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavTodoslosprofesionales = new GXCheckbox();
         cmbavActionswallet = new GXCombobox();
         cmbavOperacionesperiodocod = new GXCombobox();
         chkavIncluirbalance = new GXCheckbox();
         cmbWalletBalancesTipoMov = new GXCombobox();
         cmbWalletBalancesConcepto = new GXCombobox();
         cmbWalletBalancesEstadoOPE = new GXCombobox();
         cmbSolicitudServicioOrigenPago = new GXCombobox();
         cmbavActions = new GXCombobox();
         cmbavWalletbalancestipomov = new GXCombobox();
         cmbavWalletbalancesconcepto = new GXCombobox();
         cmbavWalletbalancesestadoope = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwallet") == 0 )
            {
               gxnrGridwallet_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridwallet") == 0 )
            {
               gxgrGridwallet_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwalletbalances") == 0 )
            {
               gxnrGridwalletbalances_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridwalletbalances") == 0 )
            {
               gxgrGridwalletbalances_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridprevia") == 0 )
            {
               gxnrGridprevia_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridprevia") == 0 )
            {
               gxgrGridprevia_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridhistorial") == 0 )
            {
               gxnrGridhistorial_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridhistorial") == 0 )
            {
               gxgrGridhistorial_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridwallet_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
         AV33GridWalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "GridWalletId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwallet_newrow( ) ;
         /* End function gxnrGridwallet_newrow_invoke */
      }

      protected void gxgrGridwallet_refresh_invoke( )
      {
         subGridwallet_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwallet_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridwalletbalances_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwalletbalances_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridprevia_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridprevia_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridhistorial_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridhistorial_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15BuscarCuenta = GetPar( "BuscarCuenta");
         AV44TodosLosProfesionales = StringUtil.StrToBool( GetPar( "TodosLosProfesionales"));
         AV18FechaDesde = context.localUtil.ParseDateParm( GetPar( "FechaDesde"));
         AV19FechaHasta = context.localUtil.ParseDateParm( GetPar( "FechaHasta"));
         AV56WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         AV48TotalSolicitudes = NumberUtil.Val( GetPar( "TotalSolicitudes"), ".");
         AV43ProfesionalesId = GetPar( "ProfesionalesId");
         A120ProfesionalesId = GetPar( "ProfesionalesId");
         A184SolicitudesFechaInstalacion = context.localUtil.ParseDateParm( GetPar( "SolicitudesFechaInstalacion"));
         A688SolicitudesLiqProf = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesLiqProf"), "."), 18, MidpointRounding.ToEven));
         n688SolicitudesLiqProf = false;
         A130EstadosSolTipo = GetPar( "EstadosSolTipo");
         A131EstadosSolId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosSolId"), "."), 18, MidpointRounding.ToEven));
         A141EstadoSGTipo = GetPar( "EstadoSGTipo");
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoSGId"), "."), 18, MidpointRounding.ToEven));
         A529SolicitudServicioComPro = NumberUtil.Val( GetPar( "SolicitudServicioComPro"), ".");
         A867SolicitudesCostoXZComProf = NumberUtil.Val( GetPar( "SolicitudesCostoXZComProf"), ".");
         cmbSolicitudServicioOrigenPago.FromJSonString( GetNextPar( ));
         A438SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
         n438SolicitudServicioOrigenPago = false;
         A211SolicitudServicioPFinal = NumberUtil.Val( GetPar( "SolicitudServicioPFinal"), ".");
         AV37IncluirBalance = StringUtil.StrToBool( GetPar( "IncluirBalance"));
         cmbWalletBalancesTipoMov.FromJSonString( GetNextPar( ));
         A643WalletBalancesTipoMov = GetPar( "WalletBalancesTipoMov");
         A644WalletBalancesImporte = NumberUtil.Val( GetPar( "WalletBalancesImporte"), ".");
         AV33GridWalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "GridWalletId"), "."), 18, MidpointRounding.ToEven));
         AV9ProfesionalesNombre = GetPar( "ProfesionalesNombre");
         AV85UserId = (long)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
         AV5OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridwallet_refresh_invoke */
      }

      protected void gxnrGridwalletbalances_newrow_invoke( )
      {
         nRC_GXsfl_100 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_100"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_100_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_100_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_100_idx = GetPar( "sGXsfl_100_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwalletbalances_newrow( ) ;
         /* End function gxnrGridwalletbalances_newrow_invoke */
      }

      protected void gxgrGridwalletbalances_refresh_invoke( )
      {
         subGridwallet_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwallet_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridwalletbalances_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwalletbalances_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridprevia_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridprevia_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridhistorial_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridhistorial_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15BuscarCuenta = GetPar( "BuscarCuenta");
         AV44TodosLosProfesionales = StringUtil.StrToBool( GetPar( "TodosLosProfesionales"));
         AV18FechaDesde = context.localUtil.ParseDateParm( GetPar( "FechaDesde"));
         AV19FechaHasta = context.localUtil.ParseDateParm( GetPar( "FechaHasta"));
         AV56WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         A715WalletNombre = GetPar( "WalletNombre");
         A648WalletSaldo = NumberUtil.Val( GetPar( "WalletSaldo"), ".");
         AV43ProfesionalesId = GetPar( "ProfesionalesId");
         A120ProfesionalesId = GetPar( "ProfesionalesId");
         A184SolicitudesFechaInstalacion = context.localUtil.ParseDateParm( GetPar( "SolicitudesFechaInstalacion"));
         A688SolicitudesLiqProf = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesLiqProf"), "."), 18, MidpointRounding.ToEven));
         n688SolicitudesLiqProf = false;
         A130EstadosSolTipo = GetPar( "EstadosSolTipo");
         A131EstadosSolId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosSolId"), "."), 18, MidpointRounding.ToEven));
         A141EstadoSGTipo = GetPar( "EstadoSGTipo");
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoSGId"), "."), 18, MidpointRounding.ToEven));
         A529SolicitudServicioComPro = NumberUtil.Val( GetPar( "SolicitudServicioComPro"), ".");
         A867SolicitudesCostoXZComProf = NumberUtil.Val( GetPar( "SolicitudesCostoXZComProf"), ".");
         cmbSolicitudServicioOrigenPago.FromJSonString( GetNextPar( ));
         A438SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
         n438SolicitudServicioOrigenPago = false;
         A211SolicitudServicioPFinal = NumberUtil.Val( GetPar( "SolicitudServicioPFinal"), ".");
         AV48TotalSolicitudes = NumberUtil.Val( GetPar( "TotalSolicitudes"), ".");
         AV37IncluirBalance = StringUtil.StrToBool( GetPar( "IncluirBalance"));
         AV9ProfesionalesNombre = GetPar( "ProfesionalesNombre");
         AV85UserId = (long)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
         AV5OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridwalletbalances_refresh_invoke */
      }

      protected void gxnrGridprevia_newrow_invoke( )
      {
         nRC_GXsfl_118 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_118"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_118_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_118_idx = GetPar( "sGXsfl_118_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridprevia_newrow( ) ;
         /* End function gxnrGridprevia_newrow_invoke */
      }

      protected void gxgrGridprevia_refresh_invoke( )
      {
         subGridwallet_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwallet_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridwalletbalances_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwalletbalances_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridprevia_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridprevia_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridhistorial_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridhistorial_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15BuscarCuenta = GetPar( "BuscarCuenta");
         AV44TodosLosProfesionales = StringUtil.StrToBool( GetPar( "TodosLosProfesionales"));
         AV18FechaDesde = context.localUtil.ParseDateParm( GetPar( "FechaDesde"));
         AV19FechaHasta = context.localUtil.ParseDateParm( GetPar( "FechaHasta"));
         AV56WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         A637WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         A639WalletCodRefencia = GetPar( "WalletCodRefencia");
         A715WalletNombre = GetPar( "WalletNombre");
         A648WalletSaldo = NumberUtil.Val( GetPar( "WalletSaldo"), ".");
         AV48TotalSolicitudes = NumberUtil.Val( GetPar( "TotalSolicitudes"), ".");
         AV43ProfesionalesId = GetPar( "ProfesionalesId");
         AV37IncluirBalance = StringUtil.StrToBool( GetPar( "IncluirBalance"));
         cmbWalletBalancesTipoMov.FromJSonString( GetNextPar( ));
         A643WalletBalancesTipoMov = GetPar( "WalletBalancesTipoMov");
         A644WalletBalancesImporte = NumberUtil.Val( GetPar( "WalletBalancesImporte"), ".");
         AV9ProfesionalesNombre = GetPar( "ProfesionalesNombre");
         AV85UserId = (long)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
         AV5OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridprevia_refresh_invoke */
      }

      protected void gxnrGridhistorial_newrow_invoke( )
      {
         nRC_GXsfl_140 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_140"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_140_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_140_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_140_idx = GetPar( "sGXsfl_140_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridhistorial_newrow( ) ;
         /* End function gxnrGridhistorial_newrow_invoke */
      }

      protected void gxgrGridhistorial_refresh_invoke( )
      {
         subGridwallet_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwallet_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridwalletbalances_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridwalletbalances_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridprevia_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridprevia_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridhistorial_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridhistorial_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15BuscarCuenta = GetPar( "BuscarCuenta");
         AV44TodosLosProfesionales = StringUtil.StrToBool( GetPar( "TodosLosProfesionales"));
         AV18FechaDesde = context.localUtil.ParseDateParm( GetPar( "FechaDesde"));
         AV19FechaHasta = context.localUtil.ParseDateParm( GetPar( "FechaHasta"));
         AV56WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         A639WalletCodRefencia = GetPar( "WalletCodRefencia");
         A715WalletNombre = GetPar( "WalletNombre");
         A648WalletSaldo = NumberUtil.Val( GetPar( "WalletSaldo"), ".");
         AV48TotalSolicitudes = NumberUtil.Val( GetPar( "TotalSolicitudes"), ".");
         AV43ProfesionalesId = GetPar( "ProfesionalesId");
         A120ProfesionalesId = GetPar( "ProfesionalesId");
         A184SolicitudesFechaInstalacion = context.localUtil.ParseDateParm( GetPar( "SolicitudesFechaInstalacion"));
         A688SolicitudesLiqProf = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesLiqProf"), "."), 18, MidpointRounding.ToEven));
         n688SolicitudesLiqProf = false;
         A130EstadosSolTipo = GetPar( "EstadosSolTipo");
         A131EstadosSolId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosSolId"), "."), 18, MidpointRounding.ToEven));
         A141EstadoSGTipo = GetPar( "EstadoSGTipo");
         A142EstadoSGId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoSGId"), "."), 18, MidpointRounding.ToEven));
         A529SolicitudServicioComPro = NumberUtil.Val( GetPar( "SolicitudServicioComPro"), ".");
         A867SolicitudesCostoXZComProf = NumberUtil.Val( GetPar( "SolicitudesCostoXZComProf"), ".");
         cmbSolicitudServicioOrigenPago.FromJSonString( GetNextPar( ));
         A438SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
         n438SolicitudServicioOrigenPago = false;
         A211SolicitudServicioPFinal = NumberUtil.Val( GetPar( "SolicitudServicioPFinal"), ".");
         AV37IncluirBalance = StringUtil.StrToBool( GetPar( "IncluirBalance"));
         AV9ProfesionalesNombre = GetPar( "ProfesionalesNombre");
         AV85UserId = (long)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
         AV5OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridhistorial_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor H00L92 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H00L92_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H00L92_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(H00L92_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(H00L92_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00L92_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0])-(H00L92_A180SolicitudItemsComision[0]*H00L92_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H00L92_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00L92_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0])+(H00L92_A180SolicitudItemsComision[0]*H00L92_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H00L92_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00L92_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0])-((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0])*(H00L92_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H00L92_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00L92_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0])+((H00L92_A176SolicitudesItemsPrecioFinal[0]*H00L92_A177SolicitudesItemsCantidad[0])*(H00L92_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            AssignAttri("", false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      public override short ExecuteStartEvent( )
      {
         PAL92( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTL92( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true, false);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpliquidacioncentro.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESNOMBRE", StringUtil.RTrim( AV9ProfesionalesNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ProfesionalesNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85UserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85UserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vBUSCARCUENTA", StringUtil.RTrim( AV15BuscarCuenta));
         GxWebStd.gx_hidden_field( context, "GXH_vTODOSLOSPROFESIONALES", StringUtil.BoolToStr( AV44TodosLosProfesionales));
         GxWebStd.gx_hidden_field( context, "GXH_vTODOSLOSPROFESIONALES", StringUtil.BoolToStr( AV44TodosLosProfesionales));
         GxWebStd.gx_hidden_field( context, "GXH_vFECHADESDE", context.localUtil.Format(AV18FechaDesde, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vFECHAHASTA", context.localUtil.Format(AV19FechaHasta, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTODOSLOSPROFESIONALES", StringUtil.BoolToStr( AV44TodosLosProfesionales));
         GxWebStd.gx_hidden_field( context, "GXH_vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_100", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_100), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_118", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_118), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_140", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_140), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDWALLETPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35GridWalletPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDWALLETAPPLIEDFILTERS", AV27GridWalletAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vGRIDHISTORIALPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23GridHistorialPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDHISTORIALAPPLIEDFILTERS", AV21GridHistorialAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV43ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESLIQPROF", StringUtil.LTrim( StringUtil.NToC( (decimal)(A688SolicitudesLiqProf), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSSOLTIPO", StringUtil.RTrim( A130EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGTIPO", StringUtil.RTrim( A141EstadoSGTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A142EstadoSGId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCELIQUIDACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1012WalletBalanceLiquidacion), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "OPERACIONESREF", StringUtil.RTrim( A555OperacionesRef));
         GxWebStd.gx_hidden_field( context, "OPERACIONESPERIODOCOD", A1028OperacionesPeriodoCod);
         GxWebStd.gx_hidden_field( context, "OPERACIONESESTADO", StringUtil.RTrim( A577OperacionesEstado));
         GxWebStd.gx_hidden_field( context, "OPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESNOMBRE", StringUtil.RTrim( AV9ProfesionalesNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ProfesionalesNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85UserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85UserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETTIPOENTIDAD", StringUtil.RTrim( A638WalletTipoEntidad));
         GxWebStd.gx_hidden_field( context, "OPERACIONESTIPO", StringUtil.RTrim( A649OperacionesTipo));
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Class", StringUtil.RTrim( Gridwalletpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridwalletpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridwalletpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridwalletpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridwalletpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridwalletpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridwalletpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridwalletpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridwalletpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridwalletpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridwalletpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridwalletpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Previous", StringUtil.RTrim( Gridwalletpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Next", StringUtil.RTrim( Gridwalletpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Caption", StringUtil.RTrim( Gridwalletpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridwalletpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridwalletpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Width", StringUtil.RTrim( Dvpanel_panelbuscadorcuentas_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Autowidth", StringUtil.BoolToStr( Dvpanel_panelbuscadorcuentas_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Autoheight", StringUtil.BoolToStr( Dvpanel_panelbuscadorcuentas_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Cls", StringUtil.RTrim( Dvpanel_panelbuscadorcuentas_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Title", StringUtil.RTrim( Dvpanel_panelbuscadorcuentas_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Collapsible", StringUtil.BoolToStr( Dvpanel_panelbuscadorcuentas_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Collapsed", StringUtil.BoolToStr( Dvpanel_panelbuscadorcuentas_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panelbuscadorcuentas_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Iconposition", StringUtil.RTrim( Dvpanel_panelbuscadorcuentas_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELBUSCADORCUENTAS_Autoscroll", StringUtil.BoolToStr( Dvpanel_panelbuscadorcuentas_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Class", StringUtil.RTrim( Gridhistorialpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridhistorialpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridhistorialpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridhistorialpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridhistorialpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridhistorialpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridhistorialpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridhistorialpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridhistorialpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridhistorialpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridhistorialpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridhistorialpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Previous", StringUtil.RTrim( Gridhistorialpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Next", StringUtil.RTrim( Gridhistorialpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Caption", StringUtil.RTrim( Gridhistorialpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridhistorialpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridhistorialpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABSLIQUIDACION_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabsliquidacion_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABSLIQUIDACION_Class", StringUtil.RTrim( Gxuitabspanel_tabsliquidacion_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABSLIQUIDACION_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabsliquidacion_Historymanagement));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Title", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridhistorial_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Gridhistorial_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridprevia_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_EMPOWERER_Infinitescrolling", StringUtil.RTrim( Gridprevia_empowerer_Infinitescrolling));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridwalletbalances_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridwallet_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridhistorialpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridhistorialpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridwalletpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridwalletpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Result", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Result));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridhistorialpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridhistorialpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridwalletpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridwalletpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnbtnliquidar_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Result", StringUtil.RTrim( Dvelop_confirmpanel_actioncrearwallets_Result));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+2+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEL92( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTL92( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wpliquidacioncentro.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPLiquidacionCentro" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Centro de Liquidacion", "") ;
      }

      protected void WBL90( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panelbuscadorcuentas.SetProperty("Width", Dvpanel_panelbuscadorcuentas_Width);
            ucDvpanel_panelbuscadorcuentas.SetProperty("AutoWidth", Dvpanel_panelbuscadorcuentas_Autowidth);
            ucDvpanel_panelbuscadorcuentas.SetProperty("AutoHeight", Dvpanel_panelbuscadorcuentas_Autoheight);
            ucDvpanel_panelbuscadorcuentas.SetProperty("Cls", Dvpanel_panelbuscadorcuentas_Cls);
            ucDvpanel_panelbuscadorcuentas.SetProperty("Title", Dvpanel_panelbuscadorcuentas_Title);
            ucDvpanel_panelbuscadorcuentas.SetProperty("Collapsible", Dvpanel_panelbuscadorcuentas_Collapsible);
            ucDvpanel_panelbuscadorcuentas.SetProperty("Collapsed", Dvpanel_panelbuscadorcuentas_Collapsed);
            ucDvpanel_panelbuscadorcuentas.SetProperty("ShowCollapseIcon", Dvpanel_panelbuscadorcuentas_Showcollapseicon);
            ucDvpanel_panelbuscadorcuentas.SetProperty("IconPosition", Dvpanel_panelbuscadorcuentas_Iconposition);
            ucDvpanel_panelbuscadorcuentas.SetProperty("AutoScroll", Dvpanel_panelbuscadorcuentas_Autoscroll);
            ucDvpanel_panelbuscadorcuentas.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panelbuscadorcuentas_Internalname, "DVPANEL_PANELBUSCADORCUENTASContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANELBUSCADORCUENTASContainer"+"PanelBuscadorCuentas"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanelbuscadorcuentas_Internalname, 1, 0, "px", 0, "px", "GridWithPaginationBar WorkWithSelection WorkWith", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnactioncrearwallets_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "Crear Cuentas Pendientes", ""), bttBtnactioncrearwallets_Jsonclick, 7, context.GetMessage( "Crear Cuentas Pendientes", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11l91_client"+"'", TempTags, "", 2, "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTodoslosprofesionales_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_35_idx + "',0)\"";
            ClassString = "aligncenter";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTodoslosprofesionales_Internalname, StringUtil.BoolToStr( AV44TodosLosProfesionales), "", "", 1, chkavTodoslosprofesionales.Enabled, "true", context.GetMessage( "Seleccionar todas las cuentas", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(24, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,24);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBuscarcuenta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBuscarcuenta_Internalname, context.GetMessage( "Buscar Cuenta", ""), "col-sm-3 ActionAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBuscarcuenta_Internalname, StringUtil.RTrim( AV15BuscarCuenta), StringUtil.RTrim( context.localUtil.Format( AV15BuscarCuenta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Selección de Cuenta / Profesional", ""), edtavBuscarcuenta_Jsonclick, 0, "ActionAttribute", "", "", "", "", 1, edtavBuscarcuenta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridwallettablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridwalletContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridwalletContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwallet", GridwalletContainer, subGridwallet_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridwalletContainerData", GridwalletContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridwalletContainerData"+"V", GridwalletContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridwalletContainerData"+"V"+"\" value='"+GridwalletContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridwalletpaginationbar.SetProperty("Class", Gridwalletpaginationbar_Class);
            ucGridwalletpaginationbar.SetProperty("ShowFirst", Gridwalletpaginationbar_Showfirst);
            ucGridwalletpaginationbar.SetProperty("ShowPrevious", Gridwalletpaginationbar_Showprevious);
            ucGridwalletpaginationbar.SetProperty("ShowNext", Gridwalletpaginationbar_Shownext);
            ucGridwalletpaginationbar.SetProperty("ShowLast", Gridwalletpaginationbar_Showlast);
            ucGridwalletpaginationbar.SetProperty("PagesToShow", Gridwalletpaginationbar_Pagestoshow);
            ucGridwalletpaginationbar.SetProperty("PagingButtonsPosition", Gridwalletpaginationbar_Pagingbuttonsposition);
            ucGridwalletpaginationbar.SetProperty("PagingCaptionPosition", Gridwalletpaginationbar_Pagingcaptionposition);
            ucGridwalletpaginationbar.SetProperty("EmptyGridClass", Gridwalletpaginationbar_Emptygridclass);
            ucGridwalletpaginationbar.SetProperty("RowsPerPageSelector", Gridwalletpaginationbar_Rowsperpageselector);
            ucGridwalletpaginationbar.SetProperty("RowsPerPageOptions", Gridwalletpaginationbar_Rowsperpageoptions);
            ucGridwalletpaginationbar.SetProperty("Previous", Gridwalletpaginationbar_Previous);
            ucGridwalletpaginationbar.SetProperty("Next", Gridwalletpaginationbar_Next);
            ucGridwalletpaginationbar.SetProperty("Caption", Gridwalletpaginationbar_Caption);
            ucGridwalletpaginationbar.SetProperty("EmptyGridCaption", Gridwalletpaginationbar_Emptygridcaption);
            ucGridwalletpaginationbar.SetProperty("RowsPerPageCaption", Gridwalletpaginationbar_Rowsperpagecaption);
            ucGridwalletpaginationbar.SetProperty("CurrentPage", AV32GridWalletCurrentPage);
            ucGridwalletpaginationbar.SetProperty("PageCount", AV35GridWalletPageCount);
            ucGridwalletpaginationbar.SetProperty("AppliedFilters", AV27GridWalletAppliedFilters);
            ucGridwalletpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridwalletpaginationbar_Internalname, "GRIDWALLETPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefiltros_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOperacionesperiodocod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperacionesperiodocod_Internalname, context.GetMessage( "Cod. Período Liquidación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_35_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacionesperiodocod, cmbavOperacionesperiodocod_Internalname, StringUtil.RTrim( AV59OperacionesPeriodoCod), 1, cmbavOperacionesperiodocod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavOperacionesperiodocod.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_WPLiquidacionCentro.htm");
            cmbavOperacionesperiodocod.CurrentValue = StringUtil.RTrim( AV59OperacionesPeriodoCod);
            AssignProp("", false, cmbavOperacionesperiodocod_Internalname, "Values", (string)(cmbavOperacionesperiodocod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechadesde_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechadesde_Internalname, context.GetMessage( "Fecha Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_35_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechadesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechadesde_Internalname, context.localUtil.Format(AV18FechaDesde, "99/99/99"), context.localUtil.Format( AV18FechaDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechadesde_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechadesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_bitmap( context, edtavFechadesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechadesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WPLiquidacionCentro.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechahasta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechahasta_Internalname, context.GetMessage( "Fecha hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_35_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechahasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechahasta_Internalname, context.localUtil.Format(AV19FechaHasta, "99/99/99"), context.localUtil.Format( AV19FechaHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechahasta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechahasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_bitmap( context, edtavFechahasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechahasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WPLiquidacionCentro.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, divTablecontent_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabsliquidacion.SetProperty("PageCount", Gxuitabspanel_tabsliquidacion_Pagecount);
            ucGxuitabspanel_tabsliquidacion.SetProperty("Class", Gxuitabspanel_tabsliquidacion_Class);
            ucGxuitabspanel_tabsliquidacion.SetProperty("HistoryManagement", Gxuitabspanel_tabsliquidacion_Historymanagement);
            ucGxuitabspanel_tabsliquidacion.Render(context, "tab", Gxuitabspanel_tabsliquidacion_Internalname, "GXUITABSPANEL_TABSLIQUIDACIONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSLIQUIDACIONContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabwallet_title_Internalname, context.GetMessage( "Cuenta", ""), "", "", lblTabwallet_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabWallet") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSLIQUIDACIONContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablewalletcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_79_L92( true) ;
         }
         else
         {
            wb_table1_79_L92( false) ;
         }
         return  ;
      }

      protected void wb_table1_79_L92e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridwalletbalancesContainer.SetWrapped(nGXWrapped);
            StartGridControl100( ) ;
         }
         if ( wbEnd == 100 )
         {
            wbEnd = 0;
            nRC_GXsfl_100 = (int)(nGXsfl_100_idx-1);
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridwalletbalancesContainer.AddObjectProperty("GRIDWALLETBALANCES_nEOF", GRIDWALLETBALANCES_nEOF);
               GridwalletbalancesContainer.AddObjectProperty("GRIDWALLETBALANCES_nFirstRecordOnPage", GRIDWALLETBALANCES_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridwalletbalancesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwalletbalances", GridwalletbalancesContainer, subGridwalletbalances_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridwalletbalancesContainerData", GridwalletbalancesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridwalletbalancesContainerData"+"V", GridwalletbalancesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridwalletbalancesContainerData"+"V"+"\" value='"+GridwalletbalancesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSLIQUIDACIONContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabsolicitudes_title_Internalname, context.GetMessage( "Solicitudes a Liquidar", ""), "", "", lblTabsolicitudes_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabSolicitudes") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSLIQUIDACIONContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesolicitudes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridpreviaContainer.SetWrapped(nGXWrapped);
            StartGridControl118( ) ;
         }
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            nRC_GXsfl_118 = (int)(nGXsfl_118_idx-1);
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridpreviaContainer.AddObjectProperty("GRIDPREVIA_nEOF", GRIDPREVIA_nEOF);
               GridpreviaContainer.AddObjectProperty("GRIDPREVIA_nFirstRecordOnPage", GRIDPREVIA_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridpreviaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridprevia", GridpreviaContainer, subGridprevia_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpreviaContainerData", GridpreviaContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpreviaContainerData"+"V", GridpreviaContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpreviaContainerData"+"V"+"\" value='"+GridpreviaContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSLIQUIDACIONContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabhistorial_title_Internalname, context.GetMessage( "Historial de liquidaciones", ""), "", "", lblTabhistorial_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabHistorial") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSLIQUIDACIONContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablehistorial_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridhistorialtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridhistorialContainer.SetWrapped(nGXWrapped);
            StartGridControl140( ) ;
         }
         if ( wbEnd == 140 )
         {
            wbEnd = 0;
            nRC_GXsfl_140 = (int)(nGXsfl_140_idx-1);
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridhistorialContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridhistorial", GridhistorialContainer, subGridhistorial_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridhistorialContainerData", GridhistorialContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridhistorialContainerData"+"V", GridhistorialContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridhistorialContainerData"+"V"+"\" value='"+GridhistorialContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridhistorialpaginationbar.SetProperty("Class", Gridhistorialpaginationbar_Class);
            ucGridhistorialpaginationbar.SetProperty("ShowFirst", Gridhistorialpaginationbar_Showfirst);
            ucGridhistorialpaginationbar.SetProperty("ShowPrevious", Gridhistorialpaginationbar_Showprevious);
            ucGridhistorialpaginationbar.SetProperty("ShowNext", Gridhistorialpaginationbar_Shownext);
            ucGridhistorialpaginationbar.SetProperty("ShowLast", Gridhistorialpaginationbar_Showlast);
            ucGridhistorialpaginationbar.SetProperty("PagesToShow", Gridhistorialpaginationbar_Pagestoshow);
            ucGridhistorialpaginationbar.SetProperty("PagingButtonsPosition", Gridhistorialpaginationbar_Pagingbuttonsposition);
            ucGridhistorialpaginationbar.SetProperty("PagingCaptionPosition", Gridhistorialpaginationbar_Pagingcaptionposition);
            ucGridhistorialpaginationbar.SetProperty("EmptyGridClass", Gridhistorialpaginationbar_Emptygridclass);
            ucGridhistorialpaginationbar.SetProperty("RowsPerPageSelector", Gridhistorialpaginationbar_Rowsperpageselector);
            ucGridhistorialpaginationbar.SetProperty("RowsPerPageOptions", Gridhistorialpaginationbar_Rowsperpageoptions);
            ucGridhistorialpaginationbar.SetProperty("Previous", Gridhistorialpaginationbar_Previous);
            ucGridhistorialpaginationbar.SetProperty("Next", Gridhistorialpaginationbar_Next);
            ucGridhistorialpaginationbar.SetProperty("Caption", Gridhistorialpaginationbar_Caption);
            ucGridhistorialpaginationbar.SetProperty("EmptyGridCaption", Gridhistorialpaginationbar_Emptygridcaption);
            ucGridhistorialpaginationbar.SetProperty("RowsPerPageCaption", Gridhistorialpaginationbar_Rowsperpagecaption);
            ucGridhistorialpaginationbar.SetProperty("CurrentPage", AV22GridHistorialCurrentPage);
            ucGridhistorialpaginationbar.SetProperty("PageCount", AV23GridHistorialPageCount);
            ucGridhistorialpaginationbar.SetProperty("AppliedFilters", AV21GridHistorialAppliedFilters);
            ucGridhistorialpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridhistorialpaginationbar_Internalname, "GRIDHISTORIALPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_155_L92( true) ;
         }
         else
         {
            wb_table2_155_L92( false) ;
         }
         return  ;
      }

      protected void wb_table2_155_L92e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table3_199_L92( true) ;
         }
         else
         {
            wb_table3_199_L92( false) ;
         }
         return  ;
      }

      protected void wb_table3_199_L92e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridwalletcurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridWalletCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32GridWalletCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,208);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridwalletcurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridwalletcurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridhistorialcurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22GridHistorialCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22GridHistorialCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridhistorialcurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridhistorialcurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            wb_table4_210_L92( true) ;
         }
         else
         {
            wb_table4_210_L92( false) ;
         }
         return  ;
      }

      protected void wb_table4_210_L92e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table5_215_L92( true) ;
         }
         else
         {
            wb_table5_215_L92( false) ;
         }
         return  ;
      }

      protected void wb_table5_215_L92e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridhistorial_empowerer.SetProperty("FixedColumns", Gridhistorial_empowerer_Fixedcolumns);
            ucGridhistorial_empowerer.Render(context, "wwp.gridempowerer", Gridhistorial_empowerer_Internalname, "GRIDHISTORIAL_EMPOWERERContainer");
            /* User Defined Control */
            ucGridprevia_empowerer.SetProperty("InfiniteScrolling", Gridprevia_empowerer_Infinitescrolling);
            ucGridprevia_empowerer.Render(context, "wwp.gridempowerer", Gridprevia_empowerer_Internalname, "GRIDPREVIA_EMPOWERERContainer");
            /* User Defined Control */
            ucGridwalletbalances_empowerer.Render(context, "wwp.gridempowerer", Gridwalletbalances_empowerer_Internalname, "GRIDWALLETBALANCES_EMPOWERERContainer");
            /* User Defined Control */
            ucGridwallet_empowerer.Render(context, "wwp.gridempowerer", Gridwallet_empowerer_Internalname, "GRIDWALLET_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridwalletContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridwalletContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwallet", GridwalletContainer, subGridwallet_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridwalletContainerData", GridwalletContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridwalletContainerData"+"V", GridwalletContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridwalletContainerData"+"V"+"\" value='"+GridwalletContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 100 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridwalletbalancesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridwalletbalancesContainer.AddObjectProperty("GRIDWALLETBALANCES_nEOF", GRIDWALLETBALANCES_nEOF);
                  GridwalletbalancesContainer.AddObjectProperty("GRIDWALLETBALANCES_nFirstRecordOnPage", GRIDWALLETBALANCES_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridwalletbalancesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwalletbalances", GridwalletbalancesContainer, subGridwalletbalances_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridwalletbalancesContainerData", GridwalletbalancesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridwalletbalancesContainerData"+"V", GridwalletbalancesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridwalletbalancesContainerData"+"V"+"\" value='"+GridwalletbalancesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridpreviaContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridpreviaContainer.AddObjectProperty("GRIDPREVIA_nEOF", GRIDPREVIA_nEOF);
                  GridpreviaContainer.AddObjectProperty("GRIDPREVIA_nFirstRecordOnPage", GRIDPREVIA_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridpreviaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridprevia", GridpreviaContainer, subGridprevia_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpreviaContainerData", GridpreviaContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpreviaContainerData"+"V", GridpreviaContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpreviaContainerData"+"V"+"\" value='"+GridpreviaContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 140 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridhistorialContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridhistorialContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridhistorial", GridhistorialContainer, subGridhistorial_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridhistorialContainerData", GridhistorialContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridhistorialContainerData"+"V", GridhistorialContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridhistorialContainerData"+"V"+"\" value='"+GridhistorialContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTL92( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Centro de Liquidacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPL90( ) ;
      }

      protected void WSL92( )
      {
         STARTL92( ) ;
         EVTL92( ) ;
      }

      protected void EVTL92( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDWALLETPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridwalletpaginationbar.Changepage */
                              E12L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDWALLETPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridwalletpaginationbar.Changerowsperpage */
                              E13L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDHISTORIALPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridhistorialpaginationbar.Changepage */
                              E14L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDHISTORIALPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridhistorialpaginationbar.Changerowsperpage */
                              E15L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btnbtnliquidar.Close */
                              E16L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_actioncrearwallets.Close */
                              E17L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNLIQUIDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnLiquidar' */
                              E18L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNCANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnCancelar' */
                              E19L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTODOSLOSPROFESIONALES.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VOPERACIONESPERIODOCOD.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21L92 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDWALLETBALANCESPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDWALLETBALANCESPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridwalletbalances_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridwalletbalances_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridwalletbalances_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridwalletbalances_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPREVIAPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPREVIAPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridprevia_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridprevia_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridprevia_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridprevia_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "GRIDWALLET.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VACTIONSWALLET.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "GRIDWALLET.ONLINEACTIVATE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VACTIONSWALLET.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              cmbavActionswallet.Name = cmbavActionswallet_Internalname;
                              cmbavActionswallet.CurrentValue = cgiGet( cmbavActionswallet_Internalname);
                              AV13ActionsWallet = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActionswallet_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActionswallet_Internalname, StringUtil.LTrimStr( (decimal)(AV13ActionsWallet), 4, 0));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavGridwalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridwalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDWALLETID");
                                 GX_FocusControl = edtavGridwalletid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV33GridWalletId = 0;
                                 AssignAttri("", false, edtavGridwalletid_Internalname, StringUtil.LTrimStr( (decimal)(AV33GridWalletId), 18, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV33GridWalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridwalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavGridwalletid_Internalname, StringUtil.LTrimStr( (decimal)(AV33GridWalletId), 18, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
                              }
                              A639WalletCodRefencia = cgiGet( edtWalletCodRefencia_Internalname);
                              A715WalletNombre = cgiGet( edtWalletNombre_Internalname);
                              A647WalletTotalCredito = context.localUtil.CToN( cgiGet( edtWalletTotalCredito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A646WalletTotalDebito = context.localUtil.CToN( cgiGet( edtWalletTotalDebito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A648WalletSaldo = context.localUtil.CToN( cgiGet( edtWalletSaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavSaldoacreedor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSaldoacreedor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSALDOACREEDOR");
                                 GX_FocusControl = edtavSaldoacreedor_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV86SaldoAcreedor = 0;
                                 AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
                              }
                              else
                              {
                                 AV86SaldoAcreedor = context.localUtil.CToN( cgiGet( edtavSaldoacreedor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                                 AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavSaldodeudor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSaldodeudor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSALDODEUDOR");
                                 GX_FocusControl = edtavSaldodeudor_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV87SaldoDeudor = 0;
                                 AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
                              }
                              else
                              {
                                 AV87SaldoDeudor = context.localUtil.CToN( cgiGet( edtavSaldodeudor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                                 AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
                              }
                              A1007WalletSolicitudesPendientes = context.localUtil.CToN( cgiGet( edtWalletSolicitudesPendientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              AV34GridWalletNombre = cgiGet( edtavGridwalletnombre_Internalname);
                              AssignAttri("", false, edtavGridwalletnombre_Internalname, AV34GridWalletNombre);
                              GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETNOMBRE"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, StringUtil.RTrim( context.localUtil.Format( AV34GridWalletNombre, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E22L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E23L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWALLET.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridwallet.Load */
                                    E24L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONSWALLET.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E25L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWALLET.ONLINEACTIVATE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridwallet.Onlineactivate */
                                    E26L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Buscarcuenta Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBUSCARCUENTA"), AV15BuscarCuenta) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todoslosprofesionales Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vTODOSLOSPROFESIONALES")) != AV44TodosLosProfesionales )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todoslosprofesionales Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vTODOSLOSPROFESIONALES")) != AV44TodosLosProfesionales )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fechadesde Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHADESDE"), 0) != AV18FechaDesde )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fechahasta Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHAHASTA"), 0) != AV19FechaHasta )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todoslosprofesionales Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vTODOSLOSPROFESIONALES")) != AV44TodosLosProfesionales )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Walletid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vWALLETID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV56WalletId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "GRIDWALLETBALANCES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "GRIDWALLETBALANCES.REFRESH") == 0 ) )
                           {
                              nGXsfl_100_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
                              SubsflControlProps_1006( ) ;
                              AV37IncluirBalance = StringUtil.StrToBool( cgiGet( chkavIncluirbalance_Internalname));
                              AssignAttri("", false, chkavIncluirbalance_Internalname, AV37IncluirBalance);
                              A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A640WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A641WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtWalletBalancesFechaAlta_Internalname), 0);
                              A644WalletBalancesImporte = context.localUtil.CToN( cgiGet( edtWalletBalancesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbWalletBalancesTipoMov.Name = cmbWalletBalancesTipoMov_Internalname;
                              cmbWalletBalancesTipoMov.CurrentValue = cgiGet( cmbWalletBalancesTipoMov_Internalname);
                              A643WalletBalancesTipoMov = cgiGet( cmbWalletBalancesTipoMov_Internalname);
                              cmbWalletBalancesConcepto.Name = cmbWalletBalancesConcepto_Internalname;
                              cmbWalletBalancesConcepto.CurrentValue = cgiGet( cmbWalletBalancesConcepto_Internalname);
                              A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWalletBalancesConcepto_Internalname), "."), 18, MidpointRounding.ToEven));
                              n1010WalletBalancesConcepto = false;
                              A1009WalletBalancesObs = cgiGet( edtWalletBalancesObs_Internalname);
                              n1009WalletBalancesObs = false;
                              cmbWalletBalancesEstadoOPE.Name = cmbWalletBalancesEstadoOPE_Internalname;
                              cmbWalletBalancesEstadoOPE.CurrentValue = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
                              A645WalletBalancesEstadoOPE = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
                              A1011WalletBalancesUrl = cgiGet( edtWalletBalancesUrl_Internalname);
                              n1011WalletBalancesUrl = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDWALLETBALANCES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridwalletbalances.Load */
                                    E27L96 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWALLETBALANCES.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridwalletbalances.Refresh */
                                    E28L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "GRIDPREVIA.LOAD") == 0 )
                           {
                              nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
                              SubsflControlProps_1185( ) ;
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A184SolicitudesFechaInstalacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSolicitudesFechaInstalacion_Internalname), 0));
                              A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbSolicitudServicioOrigenPago.Name = cmbSolicitudServicioOrigenPago_Internalname;
                              cmbSolicitudServicioOrigenPago.CurrentValue = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
                              A438SolicitudServicioOrigenPago = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
                              n438SolicitudServicioOrigenPago = false;
                              A530SolicitudServicioComALM = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n530SolicitudServicioComALM = false;
                              A529SolicitudServicioComPro = context.localUtil.CToN( cgiGet( edtSolicitudServicioComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A865SolicitudesCostoXZComAlm = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n865SolicitudesCostoXZComAlm = false;
                              A867SolicitudesCostoXZComProf = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDPREVIA.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridprevia.Load */
                                    E29L95 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDHISTORIAL.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_140_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
                              SubsflControlProps_1404( ) ;
                              cmbavActions.Name = cmbavActions_Internalname;
                              cmbavActions.CurrentValue = cgiGet( cmbavActions_Internalname);
                              AV12Actions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActions_Internalname, StringUtil.LTrimStr( (decimal)(AV12Actions), 4, 0));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWalletbalancesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWalletbalancesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWALLETBALANCESID");
                                 GX_FocusControl = edtavWalletbalancesid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV51WalletBalancesId = 0;
                                 AssignAttri("", false, edtavWalletbalancesid_Internalname, StringUtil.LTrimStr( (decimal)(AV51WalletBalancesId), 18, 0));
                              }
                              else
                              {
                                 AV51WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWalletbalancesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavWalletbalancesid_Internalname, StringUtil.LTrimStr( (decimal)(AV51WalletBalancesId), 18, 0));
                              }
                              if ( context.localUtil.VCDateTime( cgiGet( edtavWalletbalancesfechaalta_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Wallet Balances Fecha Alta", "")}), 1, "vWALLETBALANCESFECHAALTA");
                                 GX_FocusControl = edtavWalletbalancesfechaalta_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV50WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
                                 AssignAttri("", false, edtavWalletbalancesfechaalta_Internalname, context.localUtil.TToC( AV50WalletBalancesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                              }
                              else
                              {
                                 AV50WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtavWalletbalancesfechaalta_Internalname), 0);
                                 AssignAttri("", false, edtavWalletbalancesfechaalta_Internalname, context.localUtil.TToC( AV50WalletBalancesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWalletbalancesimporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavWalletbalancesimporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWALLETBALANCESIMPORTE");
                                 GX_FocusControl = edtavWalletbalancesimporte_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV52WalletBalancesImporte = 0;
                                 AssignAttri("", false, edtavWalletbalancesimporte_Internalname, StringUtil.LTrimStr( AV52WalletBalancesImporte, 18, 2));
                              }
                              else
                              {
                                 AV52WalletBalancesImporte = context.localUtil.CToN( cgiGet( edtavWalletbalancesimporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                                 AssignAttri("", false, edtavWalletbalancesimporte_Internalname, StringUtil.LTrimStr( AV52WalletBalancesImporte, 18, 2));
                              }
                              cmbavWalletbalancestipomov.Name = cmbavWalletbalancestipomov_Internalname;
                              cmbavWalletbalancestipomov.CurrentValue = cgiGet( cmbavWalletbalancestipomov_Internalname);
                              AV54WalletBalancesTipoMov = cgiGet( cmbavWalletbalancestipomov_Internalname);
                              AssignAttri("", false, cmbavWalletbalancestipomov_Internalname, AV54WalletBalancesTipoMov);
                              cmbavWalletbalancesconcepto.Name = cmbavWalletbalancesconcepto_Internalname;
                              cmbavWalletbalancesconcepto.CurrentValue = cgiGet( cmbavWalletbalancesconcepto_Internalname);
                              AV49WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWalletbalancesconcepto_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavWalletbalancesconcepto_Internalname, StringUtil.LTrimStr( (decimal)(AV49WalletBalancesConcepto), 4, 0));
                              AV53WalletBalancesObs = cgiGet( edtavWalletbalancesobs_Internalname);
                              AssignAttri("", false, edtavWalletbalancesobs_Internalname, AV53WalletBalancesObs);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWalletbalancesopeid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWalletbalancesopeid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWALLETBALANCESOPEID");
                                 GX_FocusControl = edtavWalletbalancesopeid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV10WalletBalancesOpeId = 0;
                                 AssignAttri("", false, edtavWalletbalancesopeid_Internalname, StringUtil.LTrimStr( (decimal)(AV10WalletBalancesOpeId), 18, 0));
                              }
                              else
                              {
                                 AV10WalletBalancesOpeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWalletbalancesopeid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavWalletbalancesopeid_Internalname, StringUtil.LTrimStr( (decimal)(AV10WalletBalancesOpeId), 18, 0));
                              }
                              cmbavWalletbalancesestadoope.Name = cmbavWalletbalancesestadoope_Internalname;
                              cmbavWalletbalancesestadoope.CurrentValue = cgiGet( cmbavWalletbalancesestadoope_Internalname);
                              AV80WalletBalancesEstadoOPE = cgiGet( cmbavWalletbalancesestadoope_Internalname);
                              AssignAttri("", false, cmbavWalletbalancesestadoope_Internalname, AV80WalletBalancesEstadoOPE);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDHISTORIAL.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridhistorial.Load */
                                    E30L94 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E31L92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEL92( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PAL92( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = chkavTodoslosprofesionales_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridwallet_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGridwallet_Islastpage==1)&&(nGXsfl_35_idx+1>subGridwallet_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridwalletContainer)) ;
         /* End function gxnrGridwallet_newrow */
      }

      protected void gxnrGridhistorial_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1404( ) ;
         while ( nGXsfl_140_idx <= nRC_GXsfl_140 )
         {
            sendrow_1404( ) ;
            nGXsfl_140_idx = ((subGridhistorial_Islastpage==1)&&(nGXsfl_140_idx+1>subGridhistorial_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1404( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridhistorialContainer)) ;
         /* End function gxnrGridhistorial_newrow */
      }

      protected void gxnrGridprevia_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1185( ) ;
         while ( nGXsfl_118_idx <= nRC_GXsfl_118 )
         {
            sendrow_1185( ) ;
            nGXsfl_118_idx = ((subGridprevia_Islastpage==1)&&(nGXsfl_118_idx+1>subGridprevia_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1185( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridpreviaContainer)) ;
         /* End function gxnrGridprevia_newrow */
      }

      protected void gxnrGridwalletbalances_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1006( ) ;
         while ( nGXsfl_100_idx <= nRC_GXsfl_100 )
         {
            sendrow_1006( ) ;
            nGXsfl_100_idx = ((subGridwalletbalances_Islastpage==1)&&(nGXsfl_100_idx+1>subGridwalletbalances_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_idx+1);
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1006( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridwalletbalancesContainer)) ;
         /* End function gxnrGridwalletbalances_newrow */
      }

      protected void gxgrGridwallet_refresh( int subGridwallet_Rows ,
                                             int subGridwalletbalances_Rows ,
                                             int subGridprevia_Rows ,
                                             int subGridhistorial_Rows ,
                                             string AV15BuscarCuenta ,
                                             bool AV44TodosLosProfesionales ,
                                             DateTime AV18FechaDesde ,
                                             DateTime AV19FechaHasta ,
                                             long AV56WalletId ,
                                             decimal AV48TotalSolicitudes ,
                                             string AV43ProfesionalesId ,
                                             string A120ProfesionalesId ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             long A688SolicitudesLiqProf ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId ,
                                             string A141EstadoSGTipo ,
                                             int A142EstadoSGId ,
                                             decimal A529SolicitudServicioComPro ,
                                             decimal A867SolicitudesCostoXZComProf ,
                                             string A438SolicitudServicioOrigenPago ,
                                             decimal A211SolicitudServicioPFinal ,
                                             bool AV37IncluirBalance ,
                                             string A643WalletBalancesTipoMov ,
                                             decimal A644WalletBalancesImporte ,
                                             long AV33GridWalletId ,
                                             string AV9ProfesionalesNombre ,
                                             long AV85UserId ,
                                             long AV5OperacionesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDWALLET_nCurrentRecord = 0;
         RFL92( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridwallet_refresh */
      }

      protected void gxgrGridwalletbalances_refresh( int subGridwallet_Rows ,
                                                     int subGridwalletbalances_Rows ,
                                                     int subGridprevia_Rows ,
                                                     int subGridhistorial_Rows ,
                                                     string AV15BuscarCuenta ,
                                                     bool AV44TodosLosProfesionales ,
                                                     DateTime AV18FechaDesde ,
                                                     DateTime AV19FechaHasta ,
                                                     long AV56WalletId ,
                                                     string A715WalletNombre ,
                                                     decimal A648WalletSaldo ,
                                                     string AV43ProfesionalesId ,
                                                     string A120ProfesionalesId ,
                                                     DateTime A184SolicitudesFechaInstalacion ,
                                                     long A688SolicitudesLiqProf ,
                                                     string A130EstadosSolTipo ,
                                                     int A131EstadosSolId ,
                                                     string A141EstadoSGTipo ,
                                                     int A142EstadoSGId ,
                                                     decimal A529SolicitudServicioComPro ,
                                                     decimal A867SolicitudesCostoXZComProf ,
                                                     string A438SolicitudServicioOrigenPago ,
                                                     decimal A211SolicitudServicioPFinal ,
                                                     decimal AV48TotalSolicitudes ,
                                                     bool AV37IncluirBalance ,
                                                     string AV9ProfesionalesNombre ,
                                                     long AV85UserId ,
                                                     long AV5OperacionesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDWALLETBALANCES_nCurrentRecord = 0;
         RFL96( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridwalletbalances_refresh */
      }

      protected void gxgrGridprevia_refresh( int subGridwallet_Rows ,
                                             int subGridwalletbalances_Rows ,
                                             int subGridprevia_Rows ,
                                             int subGridhistorial_Rows ,
                                             string AV15BuscarCuenta ,
                                             bool AV44TodosLosProfesionales ,
                                             DateTime AV18FechaDesde ,
                                             DateTime AV19FechaHasta ,
                                             long AV56WalletId ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             decimal AV48TotalSolicitudes ,
                                             string AV43ProfesionalesId ,
                                             bool AV37IncluirBalance ,
                                             string A643WalletBalancesTipoMov ,
                                             decimal A644WalletBalancesImporte ,
                                             string AV9ProfesionalesNombre ,
                                             long AV85UserId ,
                                             long AV5OperacionesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPREVIA_nCurrentRecord = 0;
         RFL95( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridprevia_refresh */
      }

      protected void gxgrGridhistorial_refresh( int subGridwallet_Rows ,
                                                int subGridwalletbalances_Rows ,
                                                int subGridprevia_Rows ,
                                                int subGridhistorial_Rows ,
                                                string AV15BuscarCuenta ,
                                                bool AV44TodosLosProfesionales ,
                                                DateTime AV18FechaDesde ,
                                                DateTime AV19FechaHasta ,
                                                long AV56WalletId ,
                                                string A639WalletCodRefencia ,
                                                string A715WalletNombre ,
                                                decimal A648WalletSaldo ,
                                                decimal AV48TotalSolicitudes ,
                                                string AV43ProfesionalesId ,
                                                string A120ProfesionalesId ,
                                                DateTime A184SolicitudesFechaInstalacion ,
                                                long A688SolicitudesLiqProf ,
                                                string A130EstadosSolTipo ,
                                                int A131EstadosSolId ,
                                                string A141EstadoSGTipo ,
                                                int A142EstadoSGId ,
                                                decimal A529SolicitudServicioComPro ,
                                                decimal A867SolicitudesCostoXZComProf ,
                                                string A438SolicitudServicioOrigenPago ,
                                                decimal A211SolicitudServicioPFinal ,
                                                bool AV37IncluirBalance ,
                                                string AV9ProfesionalesNombre ,
                                                long AV85UserId ,
                                                long AV5OperacionesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDHISTORIAL_nCurrentRecord = 0;
         RFL94( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridhistorial_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "WALLETNOMBRE", StringUtil.RTrim( A715WalletNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETSALDO", GetSecureSignedToken( "", context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "WALLETSALDO", StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGRIDWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridWalletId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34GridWalletNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "vGRIDWALLETNOMBRE", StringUtil.RTrim( AV34GridWalletNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESTIPOMOV", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A643WalletBalancesTipoMov, "")), context));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESTIPOMOV", StringUtil.RTrim( A643WalletBalancesTipoMov));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESIMPORTE", GetSecureSignedToken( "", context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESIMPORTE", StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDSERVICIOCOMPRO", GetSecureSignedToken( "", context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "SOLICITUDSERVICIOCOMPRO", StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESCOSTOXZCOMPROF", GetSecureSignedToken( "", context.localUtil.Format( A867SolicitudesCostoXZComProf, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOSTOXZCOMPROF", StringUtil.LTrim( StringUtil.NToC( A867SolicitudesCostoXZComProf, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "SOLICITUDSERVICIOPFINAL", StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 18, 2, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV44TodosLosProfesionales = StringUtil.StrToBool( StringUtil.BoolToStr( AV44TodosLosProfesionales));
         AssignAttri("", false, "AV44TodosLosProfesionales", AV44TodosLosProfesionales);
         if ( cmbavOperacionesperiodocod.ItemCount > 0 )
         {
            AV59OperacionesPeriodoCod = cmbavOperacionesperiodocod.getValidValue(AV59OperacionesPeriodoCod);
            AssignAttri("", false, "AV59OperacionesPeriodoCod", AV59OperacionesPeriodoCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacionesperiodocod.CurrentValue = StringUtil.RTrim( AV59OperacionesPeriodoCod);
            AssignProp("", false, cmbavOperacionesperiodocod_Internalname, "Values", cmbavOperacionesperiodocod.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         GRIDPREVIA_nFirstRecordOnPage = 0;
         GRIDPREVIA_nCurrentRecord = 0;
         GXCCtl = "GRIDPREVIA_nFirstRecordOnPage_" + sGXsfl_118_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RFL92( ) ;
         RFL96( ) ;
         RFL95( ) ;
         RFL94( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavGridwalletid_Enabled = 0;
         edtavSaldoacreedor_Enabled = 0;
         edtavSaldodeudor_Enabled = 0;
         edtavGridwalletnombre_Enabled = 0;
         edtavWalletcodrefencia_Enabled = 0;
         AssignProp("", false, edtavWalletcodrefencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletcodrefencia_Enabled), 5, 0), true);
         edtavWalletid_Enabled = 0;
         AssignProp("", false, edtavWalletid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletid_Enabled), 5, 0), true);
         edtavWalletnombre_Enabled = 0;
         AssignProp("", false, edtavWalletnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletnombre_Enabled), 5, 0), true);
         edtavWalletsaldo_Enabled = 0;
         AssignProp("", false, edtavWalletsaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletsaldo_Enabled), 5, 0), true);
         edtavWalletbalancesid_Enabled = 0;
         edtavWalletbalancesfechaalta_Enabled = 0;
         edtavWalletbalancesimporte_Enabled = 0;
         cmbavWalletbalancestipomov.Enabled = 0;
         cmbavWalletbalancesconcepto.Enabled = 0;
         edtavWalletbalancesobs_Enabled = 0;
         edtavWalletbalancesopeid_Enabled = 0;
         cmbavWalletbalancesestadoope.Enabled = 0;
         edtavTotalsolicitudes_Enabled = 0;
         AssignProp("", false, edtavTotalsolicitudes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalsolicitudes_Enabled), 5, 0), true);
         edtavTotalnetoapagar_Enabled = 0;
         AssignProp("", false, edtavTotalnetoapagar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalnetoapagar_Enabled), 5, 0), true);
         edtavTotalajusteswallet_Enabled = 0;
         AssignProp("", false, edtavTotalajusteswallet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalajusteswallet_Enabled), 5, 0), true);
         edtavCantidadregistros_Enabled = 0;
         AssignProp("", false, edtavCantidadregistros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidadregistros_Enabled), 5, 0), true);
         edtavCantidadajustes_Enabled = 0;
         AssignProp("", false, edtavCantidadajustes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidadajustes_Enabled), 5, 0), true);
      }

      protected int subGridwalletclient_rec_count_fnc( )
      {
         GRIDWALLET_nRecordCount = 0;
         /* Using cursor H00L93 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A638WalletTipoEntidad = H00L93_A638WalletTipoEntidad[0];
            A637WalletId = H00L93_A637WalletId[0];
            A639WalletCodRefencia = H00L93_A639WalletCodRefencia[0];
            GXt_char1 = A715WalletNombre;
            new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char1) ;
            A715WalletNombre = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15BuscarCuenta)) || ( StringUtil.Like( StringUtil.Lower( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Lower( StringUtil.Trim( AV15BuscarCuenta)) + "%" , 256 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Lower( StringUtil.Trim( AV15BuscarCuenta)) + "%" , 256 , "%"),  ' ' ) ) )
            {
               GXt_decimal2 = A1007WalletSolicitudesPendientes;
               new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
               A1007WalletSolicitudesPendientes = GXt_decimal2;
               GXt_decimal2 = A646WalletTotalDebito;
               new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
               A646WalletTotalDebito = GXt_decimal2;
               GXt_decimal2 = A647WalletTotalCredito;
               new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
               A647WalletTotalCredito = GXt_decimal2;
               A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
               GRIDWALLET_nRecordCount = (long)(GRIDWALLET_nRecordCount+1);
            }
            pr_default.readNext(1);
         }
         GRIDWALLET_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nEOF), 1, 0, ".", "")));
         pr_default.close(1);
         return (int)(GRIDWALLET_nRecordCount) ;
      }

      protected void RFL92( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridwalletContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E23L92 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridwalletContainer.AddObjectProperty("GridName", "Gridwallet");
         GridwalletContainer.AddObjectProperty("CmpContext", "");
         GridwalletContainer.AddObjectProperty("InMasterPage", "false");
         GridwalletContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridwalletContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridwalletContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridwalletContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Backcolorstyle), 1, 0, ".", "")));
         GridwalletContainer.PageSize = subGridwallet_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            /* Using cursor H00L94 */
            pr_default.execute(2);
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            GRIDWALLET_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRIDWALLET_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGridwallet_Rows == 0 ) || ( GRIDWALLET_nCurrentRecord < GRIDWALLET_nFirstRecordOnPage + subGridwallet_fnc_Recordsperpage( ) ) ) ) )
            {
               A638WalletTipoEntidad = H00L94_A638WalletTipoEntidad[0];
               A637WalletId = H00L94_A637WalletId[0];
               A639WalletCodRefencia = H00L94_A639WalletCodRefencia[0];
               GXt_char1 = A715WalletNombre;
               new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char1) ;
               A715WalletNombre = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15BuscarCuenta)) || ( StringUtil.Like( StringUtil.Lower( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Lower( StringUtil.Trim( AV15BuscarCuenta)) + "%" , 256 , "%"),  ' ' ) || StringUtil.Like( StringUtil.Lower( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Lower( StringUtil.Trim( AV15BuscarCuenta)) + "%" , 256 , "%"),  ' ' ) ) )
               {
                  GXt_decimal2 = A1007WalletSolicitudesPendientes;
                  new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
                  A1007WalletSolicitudesPendientes = GXt_decimal2;
                  GXt_decimal2 = A646WalletTotalDebito;
                  new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
                  A646WalletTotalDebito = GXt_decimal2;
                  GXt_decimal2 = A647WalletTotalCredito;
                  new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
                  A647WalletTotalCredito = GXt_decimal2;
                  A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
                  /* Execute user event: Gridwallet.Load */
                  E24L92 ();
               }
               pr_default.readNext(2);
            }
            GRIDWALLET_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDWALLET_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 35;
            WBL90( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesL92( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETNOMBRE"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETSALDO"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESNOMBRE", StringUtil.RTrim( AV9ProfesionalesNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ProfesionalesNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85UserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85UserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETNOMBRE"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, StringUtil.RTrim( context.localUtil.Format( AV34GridWalletNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected void RFL94( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridhistorialContainer.ClearRows();
         }
         wbStart = 140;
         /* Execute user event: Refresh */
         E23L92 ();
         nGXsfl_140_idx = 1;
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1404( ) ;
         bGXsfl_140_Refreshing = true;
         GridhistorialContainer.AddObjectProperty("GridName", "Gridhistorial");
         GridhistorialContainer.AddObjectProperty("CmpContext", "");
         GridhistorialContainer.AddObjectProperty("InMasterPage", "false");
         GridhistorialContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridhistorialContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridhistorialContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridhistorialContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Backcolorstyle), 1, 0, ".", "")));
         GridhistorialContainer.PageSize = subGridhistorial_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1404( ) ;
            GXPagingFrom4 = (int)(((subGridhistorial_Rows==0) ? 0 : GRIDHISTORIAL_nFirstRecordOnPage));
            GXPagingTo4 = ((subGridhistorial_Rows==0) ? 10000 : subGridhistorial_fnc_Recordsperpage( )+1);
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV43ProfesionalesId ,
                                                 AV44TodosLosProfesionales ,
                                                 A637WalletId ,
                                                 AV56WalletId ,
                                                 A645WalletBalancesEstadoOPE ,
                                                 A1010WalletBalancesConcepto } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H00L95 */
            pr_default.execute(3, new Object[] {AV56WalletId, GXPagingFrom4, GXPagingTo4, GXPagingTo4});
            nGXsfl_140_idx = 1;
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1404( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ( subGridhistorial_Rows == 0 ) || ( GRIDHISTORIAL_nCurrentRecord < subGridhistorial_fnc_Recordsperpage( ) ) ) ) )
            {
               A1010WalletBalancesConcepto = H00L95_A1010WalletBalancesConcepto[0];
               n1010WalletBalancesConcepto = H00L95_n1010WalletBalancesConcepto[0];
               A645WalletBalancesEstadoOPE = H00L95_A645WalletBalancesEstadoOPE[0];
               A637WalletId = H00L95_A637WalletId[0];
               A641WalletBalancesFechaAlta = H00L95_A641WalletBalancesFechaAlta[0];
               A644WalletBalancesImporte = H00L95_A644WalletBalancesImporte[0];
               A643WalletBalancesTipoMov = H00L95_A643WalletBalancesTipoMov[0];
               A1009WalletBalancesObs = H00L95_A1009WalletBalancesObs[0];
               n1009WalletBalancesObs = H00L95_n1009WalletBalancesObs[0];
               A1012WalletBalanceLiquidacion = H00L95_A1012WalletBalanceLiquidacion[0];
               n1012WalletBalanceLiquidacion = H00L95_n1012WalletBalanceLiquidacion[0];
               A640WalletBalancesId = H00L95_A640WalletBalancesId[0];
               /* Execute user event: Gridhistorial.Load */
               E30L94 ();
               pr_default.readNext(3);
            }
            GRIDHISTORIAL_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 140;
            WBL90( ) ;
         }
         bGXsfl_140_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesL94( )
      {
      }

      protected int subGridpreviaclient_rec_count_fnc( )
      {
         GRIDPREVIA_nRecordCount = 0;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A131EstadosSolId ,
                                              AV18FechaDesde ,
                                              AV19FechaHasta ,
                                              AV43ProfesionalesId ,
                                              AV44TodosLosProfesionales ,
                                              A184SolicitudesFechaInstalacion ,
                                              A120ProfesionalesId ,
                                              A688SolicitudesLiqProf ,
                                              A130EstadosSolTipo ,
                                              A141EstadoSGTipo ,
                                              A142EstadoSGId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor H00L96 */
         pr_default.execute(4, new Object[] {AV18FechaDesde, AV19FechaHasta, AV43ProfesionalesId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A142EstadoSGId = H00L96_A142EstadoSGId[0];
            A141EstadoSGTipo = H00L96_A141EstadoSGTipo[0];
            A130EstadosSolTipo = H00L96_A130EstadosSolTipo[0];
            A688SolicitudesLiqProf = H00L96_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = H00L96_n688SolicitudesLiqProf[0];
            A438SolicitudServicioOrigenPago = H00L96_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = H00L96_n438SolicitudServicioOrigenPago[0];
            A133ProveedorID = H00L96_A133ProveedorID[0];
            A131EstadosSolId = H00L96_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = H00L96_A184SolicitudesFechaInstalacion[0];
            A120ProfesionalesId = H00L96_A120ProfesionalesId[0];
            A127SolicitudesID = H00L96_A127SolicitudesID[0];
            A527SolicitudServicioComProv = H00L96_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = H00L96_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = H00L96_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = H00L96_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = H00L96_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = H00L96_n865SolicitudesCostoXZComAlm[0];
            A796SolicitudesComisionMetodoPago = H00L96_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = H00L96_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = H00L96_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = H00L96_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = H00L96_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = H00L96_A864SolicitudesCostoXZona[0];
            A130EstadosSolTipo = H00L96_A130EstadosSolTipo[0];
            A688SolicitudesLiqProf = H00L96_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = H00L96_n688SolicitudesLiqProf[0];
            A438SolicitudServicioOrigenPago = H00L96_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = H00L96_n438SolicitudServicioOrigenPago[0];
            A133ProveedorID = H00L96_A133ProveedorID[0];
            A131EstadosSolId = H00L96_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = H00L96_A184SolicitudesFechaInstalacion[0];
            A527SolicitudServicioComProv = H00L96_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = H00L96_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = H00L96_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = H00L96_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = H00L96_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = H00L96_n865SolicitudesCostoXZComAlm[0];
            A796SolicitudesComisionMetodoPago = H00L96_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = H00L96_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = H00L96_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = H00L96_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = H00L96_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = H00L96_A864SolicitudesCostoXZona[0];
            if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  GetSolicitudesTotal( A127SolicitudesID) ;
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                        {
                           A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                        }
                        else
                        {
                           if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                           {
                              A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                           }
                           else
                           {
                              A211SolicitudServicioPFinal = 0;
                           }
                        }
                     }
                  }
                  if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                  }
                  else
                  {
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                        else
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                     }
                  }
                  if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
                  {
                     A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
                  }
                  else
                  {
                     A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
                  }
                  GRIDPREVIA_nRecordCount = (long)(GRIDPREVIA_nRecordCount+1);
               }
            }
            pr_default.readNext(4);
         }
         GRIDPREVIA_nEOF = (short)(((pr_default.getStatus(4) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nEOF), 1, 0, ".", "")));
         pr_default.close(4);
         return (int)(GRIDPREVIA_nRecordCount) ;
      }

      protected void RFL95( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridpreviaContainer.ClearRows();
         }
         wbStart = 118;
         /* Execute user event: Refresh */
         E23L92 ();
         nGXsfl_118_idx = (int)(1+GRIDPREVIA_nFirstRecordOnPage);
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1185( ) ;
         bGXsfl_118_Refreshing = true;
         GridpreviaContainer.AddObjectProperty("GridName", "Gridprevia");
         GridpreviaContainer.AddObjectProperty("CmpContext", "");
         GridpreviaContainer.AddObjectProperty("InMasterPage", "false");
         GridpreviaContainer.AddObjectProperty("Class", "WorkWith");
         GridpreviaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridpreviaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridpreviaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Backcolorstyle), 1, 0, ".", "")));
         GridpreviaContainer.PageSize = subGridprevia_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1185( ) ;
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 A131EstadosSolId ,
                                                 AV18FechaDesde ,
                                                 AV19FechaHasta ,
                                                 AV43ProfesionalesId ,
                                                 AV44TodosLosProfesionales ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 A120ProfesionalesId ,
                                                 A688SolicitudesLiqProf ,
                                                 A130EstadosSolTipo ,
                                                 A141EstadoSGTipo ,
                                                 A142EstadoSGId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00L97 */
            pr_default.execute(5, new Object[] {AV18FechaDesde, AV19FechaHasta, AV43ProfesionalesId});
            nGXsfl_118_idx = (int)(1+GRIDPREVIA_nFirstRecordOnPage);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1185( ) ;
            GRIDPREVIA_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(5) != 101) ) && ( ( ( subGridprevia_Rows == 0 ) || ( GRIDPREVIA_nCurrentRecord < GRIDPREVIA_nFirstRecordOnPage + subGridprevia_fnc_Recordsperpage( ) ) ) ) )
            {
               A142EstadoSGId = H00L97_A142EstadoSGId[0];
               A141EstadoSGTipo = H00L97_A141EstadoSGTipo[0];
               A130EstadosSolTipo = H00L97_A130EstadosSolTipo[0];
               A688SolicitudesLiqProf = H00L97_A688SolicitudesLiqProf[0];
               n688SolicitudesLiqProf = H00L97_n688SolicitudesLiqProf[0];
               A438SolicitudServicioOrigenPago = H00L97_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = H00L97_n438SolicitudServicioOrigenPago[0];
               A133ProveedorID = H00L97_A133ProveedorID[0];
               A131EstadosSolId = H00L97_A131EstadosSolId[0];
               A184SolicitudesFechaInstalacion = H00L97_A184SolicitudesFechaInstalacion[0];
               A120ProfesionalesId = H00L97_A120ProfesionalesId[0];
               A127SolicitudesID = H00L97_A127SolicitudesID[0];
               A527SolicitudServicioComProv = H00L97_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = H00L97_n527SolicitudServicioComProv[0];
               A530SolicitudServicioComALM = H00L97_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = H00L97_n530SolicitudServicioComALM[0];
               A865SolicitudesCostoXZComAlm = H00L97_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = H00L97_n865SolicitudesCostoXZComAlm[0];
               A796SolicitudesComisionMetodoPago = H00L97_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H00L97_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H00L97_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H00L97_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H00L97_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = H00L97_A864SolicitudesCostoXZona[0];
               A130EstadosSolTipo = H00L97_A130EstadosSolTipo[0];
               A688SolicitudesLiqProf = H00L97_A688SolicitudesLiqProf[0];
               n688SolicitudesLiqProf = H00L97_n688SolicitudesLiqProf[0];
               A438SolicitudServicioOrigenPago = H00L97_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = H00L97_n438SolicitudServicioOrigenPago[0];
               A133ProveedorID = H00L97_A133ProveedorID[0];
               A131EstadosSolId = H00L97_A131EstadosSolId[0];
               A184SolicitudesFechaInstalacion = H00L97_A184SolicitudesFechaInstalacion[0];
               A527SolicitudServicioComProv = H00L97_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = H00L97_n527SolicitudServicioComProv[0];
               A530SolicitudServicioComALM = H00L97_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = H00L97_n530SolicitudServicioComALM[0];
               A865SolicitudesCostoXZComAlm = H00L97_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = H00L97_n865SolicitudesCostoXZComAlm[0];
               A796SolicitudesComisionMetodoPago = H00L97_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H00L97_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H00L97_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H00L97_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H00L97_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = H00L97_A864SolicitudesCostoXZona[0];
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
                  if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     GetSolicitudesTotal( A127SolicitudesID) ;
                     if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                        {
                           A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                        }
                        else
                        {
                           if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                           {
                              A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                           }
                           else
                           {
                              if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                              {
                                 A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                              }
                              else
                              {
                                 A211SolicitudServicioPFinal = 0;
                              }
                           }
                        }
                     }
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                        }
                        else
                        {
                           if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                           {
                              A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                           }
                           else
                           {
                              A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                           }
                        }
                     }
                     if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
                     {
                        A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
                     }
                     else
                     {
                        A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
                     }
                     /* Execute user event: Gridprevia.Load */
                     E29L95 ();
                  }
               }
               pr_default.readNext(5);
            }
            GRIDPREVIA_nEOF = (short)(((pr_default.getStatus(5) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nEOF), 1, 0, ".", "")));
            pr_default.close(5);
            wbEnd = 118;
            WBL90( ) ;
         }
         bGXsfl_118_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesL95( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDSERVICIOCOMPRO"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESCOSTOXZCOMPROF"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, context.localUtil.Format( A867SolicitudesCostoXZComProf, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDSERVICIOPFINAL"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
      }

      protected int subGridwalletbalancesclient_rec_count_fnc( )
      {
         GRIDWALLETBALANCES_nRecordCount = 0;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV43ProfesionalesId ,
                                              AV44TodosLosProfesionales ,
                                              A639WalletCodRefencia ,
                                              A645WalletBalancesEstadoOPE } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H00L98 */
         pr_default.execute(6, new Object[] {AV43ProfesionalesId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A639WalletCodRefencia = H00L98_A639WalletCodRefencia[0];
            A1011WalletBalancesUrl = H00L98_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = H00L98_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = H00L98_A645WalletBalancesEstadoOPE[0];
            A1009WalletBalancesObs = H00L98_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = H00L98_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = H00L98_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = H00L98_n1010WalletBalancesConcepto[0];
            A643WalletBalancesTipoMov = H00L98_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = H00L98_A644WalletBalancesImporte[0];
            A641WalletBalancesFechaAlta = H00L98_A641WalletBalancesFechaAlta[0];
            A640WalletBalancesId = H00L98_A640WalletBalancesId[0];
            A637WalletId = H00L98_A637WalletId[0];
            A639WalletCodRefencia = H00L98_A639WalletCodRefencia[0];
            if ( StringUtil.StrCmp(A645WalletBalancesEstadoOPE, context.GetMessage( "PND", "")) == 0 )
            {
               GRIDWALLETBALANCES_nRecordCount = (long)(GRIDWALLETBALANCES_nRecordCount+1);
            }
            pr_default.readNext(6);
         }
         GRIDWALLETBALANCES_nEOF = (short)(((pr_default.getStatus(6) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nEOF), 1, 0, ".", "")));
         pr_default.close(6);
         return (int)(GRIDWALLETBALANCES_nRecordCount) ;
      }

      protected void RFL96( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridwalletbalancesContainer.ClearRows();
         }
         wbStart = 100;
         /* Execute user event: Refresh */
         E23L92 ();
         /* Execute user event: Gridwalletbalances.Refresh */
         E28L92 ();
         nGXsfl_100_idx = 1;
         sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
         SubsflControlProps_1006( ) ;
         bGXsfl_100_Refreshing = true;
         GridwalletbalancesContainer.AddObjectProperty("GridName", "Gridwalletbalances");
         GridwalletbalancesContainer.AddObjectProperty("CmpContext", "");
         GridwalletbalancesContainer.AddObjectProperty("InMasterPage", "false");
         GridwalletbalancesContainer.AddObjectProperty("Class", "WorkWith");
         GridwalletbalancesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridwalletbalancesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridwalletbalancesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Backcolorstyle), 1, 0, ".", "")));
         GridwalletbalancesContainer.PageSize = subGridwalletbalances_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1006( ) ;
            pr_default.dynParam(7, new Object[]{ new Object[]{
                                                 AV43ProfesionalesId ,
                                                 AV44TodosLosProfesionales ,
                                                 A639WalletCodRefencia ,
                                                 A645WalletBalancesEstadoOPE } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H00L99 */
            pr_default.execute(7, new Object[] {AV43ProfesionalesId});
            nGXsfl_100_idx = 1;
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1006( ) ;
            GRIDWALLETBALANCES_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(7) != 101) ) && ( ( ( subGridwalletbalances_Rows == 0 ) || ( GRIDWALLETBALANCES_nCurrentRecord < GRIDWALLETBALANCES_nFirstRecordOnPage + subGridwalletbalances_fnc_Recordsperpage( ) ) ) ) )
            {
               A639WalletCodRefencia = H00L99_A639WalletCodRefencia[0];
               A1011WalletBalancesUrl = H00L99_A1011WalletBalancesUrl[0];
               n1011WalletBalancesUrl = H00L99_n1011WalletBalancesUrl[0];
               A645WalletBalancesEstadoOPE = H00L99_A645WalletBalancesEstadoOPE[0];
               A1009WalletBalancesObs = H00L99_A1009WalletBalancesObs[0];
               n1009WalletBalancesObs = H00L99_n1009WalletBalancesObs[0];
               A1010WalletBalancesConcepto = H00L99_A1010WalletBalancesConcepto[0];
               n1010WalletBalancesConcepto = H00L99_n1010WalletBalancesConcepto[0];
               A643WalletBalancesTipoMov = H00L99_A643WalletBalancesTipoMov[0];
               A644WalletBalancesImporte = H00L99_A644WalletBalancesImporte[0];
               A641WalletBalancesFechaAlta = H00L99_A641WalletBalancesFechaAlta[0];
               A640WalletBalancesId = H00L99_A640WalletBalancesId[0];
               A637WalletId = H00L99_A637WalletId[0];
               A639WalletCodRefencia = H00L99_A639WalletCodRefencia[0];
               if ( StringUtil.StrCmp(A645WalletBalancesEstadoOPE, context.GetMessage( "PND", "")) == 0 )
               {
                  /* Execute user event: Gridwalletbalances.Load */
                  E27L96 ();
               }
               pr_default.readNext(7);
            }
            GRIDWALLETBALANCES_nEOF = (short)(((pr_default.getStatus(7) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nEOF), 1, 0, ".", "")));
            pr_default.close(7);
            wbEnd = 100;
            WBL90( ) ;
         }
         bGXsfl_100_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesL96( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETID"+"_"+sGXsfl_100_idx, GetSecureSignedToken( sGXsfl_100_idx, context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESTIPOMOV"+"_"+sGXsfl_100_idx, GetSecureSignedToken( sGXsfl_100_idx, StringUtil.RTrim( context.localUtil.Format( A643WalletBalancesTipoMov, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESIMPORTE"+"_"+sGXsfl_100_idx, GetSecureSignedToken( sGXsfl_100_idx, context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESID"+"_"+sGXsfl_100_idx, GetSecureSignedToken( sGXsfl_100_idx, context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected int subGridwallet_fnc_Pagecount( )
      {
         GRIDWALLET_nRecordCount = subGridwallet_fnc_Recordcount( );
         if ( ((long)((GRIDWALLET_nRecordCount) % (subGridwallet_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWALLET_nRecordCount/ (decimal)(subGridwallet_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWALLET_nRecordCount/ (decimal)(subGridwallet_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridwallet_fnc_Recordcount( )
      {
         return (int)(subGridwalletclient_rec_count_fnc()) ;
      }

      protected int subGridwallet_fnc_Recordsperpage( )
      {
         if ( subGridwallet_Rows > 0 )
         {
            return subGridwallet_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridwallet_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWALLET_nFirstRecordOnPage/ (decimal)(subGridwallet_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridwallet_firstpage( )
      {
         GRIDWALLET_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridwallet_nextpage( )
      {
         if ( GRIDWALLET_nEOF == 0 )
         {
            GRIDWALLET_nFirstRecordOnPage = (long)(GRIDWALLET_nFirstRecordOnPage+subGridwallet_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nFirstRecordOnPage), 15, 0, ".", "")));
         GridwalletContainer.AddObjectProperty("GRIDWALLET_nFirstRecordOnPage", GRIDWALLET_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDWALLET_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridwallet_previouspage( )
      {
         if ( GRIDWALLET_nFirstRecordOnPage >= subGridwallet_fnc_Recordsperpage( ) )
         {
            GRIDWALLET_nFirstRecordOnPage = (long)(GRIDWALLET_nFirstRecordOnPage-subGridwallet_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridwallet_lastpage( )
      {
         GRIDWALLET_nRecordCount = subGridwallet_fnc_Recordcount( );
         if ( GRIDWALLET_nRecordCount > subGridwallet_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDWALLET_nRecordCount) % (subGridwallet_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDWALLET_nFirstRecordOnPage = (long)(GRIDWALLET_nRecordCount-subGridwallet_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDWALLET_nFirstRecordOnPage = (long)(GRIDWALLET_nRecordCount-((long)((GRIDWALLET_nRecordCount) % (subGridwallet_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDWALLET_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridwallet_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDWALLET_nFirstRecordOnPage = (long)(subGridwallet_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDWALLET_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridhistorial_fnc_Pagecount( )
      {
         GRIDHISTORIAL_nRecordCount = subGridhistorial_fnc_Recordcount( );
         if ( ((long)((GRIDHISTORIAL_nRecordCount) % (subGridhistorial_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDHISTORIAL_nRecordCount/ (decimal)(subGridhistorial_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDHISTORIAL_nRecordCount/ (decimal)(subGridhistorial_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridhistorial_fnc_Recordcount( )
      {
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV43ProfesionalesId ,
                                              AV44TodosLosProfesionales ,
                                              A637WalletId ,
                                              AV56WalletId ,
                                              A645WalletBalancesEstadoOPE ,
                                              A1010WalletBalancesConcepto } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H00L910 */
         pr_default.execute(8, new Object[] {AV56WalletId});
         GRIDHISTORIAL_nRecordCount = H00L910_AGRIDHISTORIAL_nRecordCount[0];
         pr_default.close(8);
         return (int)(GRIDHISTORIAL_nRecordCount) ;
      }

      protected int subGridhistorial_fnc_Recordsperpage( )
      {
         if ( subGridhistorial_Rows > 0 )
         {
            return subGridhistorial_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridhistorial_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDHISTORIAL_nFirstRecordOnPage/ (decimal)(subGridhistorial_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridhistorial_firstpage( )
      {
         GRIDHISTORIAL_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridhistorial_nextpage( )
      {
         GRIDHISTORIAL_nRecordCount = subGridhistorial_fnc_Recordcount( );
         if ( ( GRIDHISTORIAL_nRecordCount >= subGridhistorial_fnc_Recordsperpage( ) ) && ( GRIDHISTORIAL_nEOF == 0 ) )
         {
            GRIDHISTORIAL_nFirstRecordOnPage = (long)(GRIDHISTORIAL_nFirstRecordOnPage+subGridhistorial_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nFirstRecordOnPage), 15, 0, ".", "")));
         GridhistorialContainer.AddObjectProperty("GRIDHISTORIAL_nFirstRecordOnPage", GRIDHISTORIAL_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDHISTORIAL_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridhistorial_previouspage( )
      {
         if ( GRIDHISTORIAL_nFirstRecordOnPage >= subGridhistorial_fnc_Recordsperpage( ) )
         {
            GRIDHISTORIAL_nFirstRecordOnPage = (long)(GRIDHISTORIAL_nFirstRecordOnPage-subGridhistorial_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridhistorial_lastpage( )
      {
         GRIDHISTORIAL_nRecordCount = subGridhistorial_fnc_Recordcount( );
         if ( GRIDHISTORIAL_nRecordCount > subGridhistorial_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDHISTORIAL_nRecordCount) % (subGridhistorial_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDHISTORIAL_nFirstRecordOnPage = (long)(GRIDHISTORIAL_nRecordCount-subGridhistorial_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDHISTORIAL_nFirstRecordOnPage = (long)(GRIDHISTORIAL_nRecordCount-((long)((GRIDHISTORIAL_nRecordCount) % (subGridhistorial_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDHISTORIAL_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridhistorial_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDHISTORIAL_nFirstRecordOnPage = (long)(subGridhistorial_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDHISTORIAL_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHISTORIAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridprevia_fnc_Pagecount( )
      {
         GRIDPREVIA_nRecordCount = subGridprevia_fnc_Recordcount( );
         if ( ((long)((GRIDPREVIA_nRecordCount) % (subGridprevia_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPREVIA_nRecordCount/ (decimal)(subGridprevia_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPREVIA_nRecordCount/ (decimal)(subGridprevia_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridprevia_fnc_Recordcount( )
      {
         return (int)(subGridpreviaclient_rec_count_fnc()) ;
      }

      protected int subGridprevia_fnc_Recordsperpage( )
      {
         if ( subGridprevia_Rows > 0 )
         {
            return subGridprevia_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridprevia_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPREVIA_nFirstRecordOnPage/ (decimal)(subGridprevia_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridprevia_firstpage( )
      {
         GRIDPREVIA_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridprevia_nextpage( )
      {
         if ( GRIDPREVIA_nEOF == 0 )
         {
            GRIDPREVIA_nFirstRecordOnPage = (long)(GRIDPREVIA_nFirstRecordOnPage+subGridprevia_fnc_Recordsperpage( ));
         }
         if ( GRIDPREVIA_nEOF == 1 )
         {
            GRIDPREVIA_nFirstRecordOnPage = GRIDPREVIA_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         GridpreviaContainer.AddObjectProperty("GRIDPREVIA_nFirstRecordOnPage", GRIDPREVIA_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDPREVIA_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridprevia_previouspage( )
      {
         if ( GRIDPREVIA_nFirstRecordOnPage >= subGridprevia_fnc_Recordsperpage( ) )
         {
            GRIDPREVIA_nFirstRecordOnPage = (long)(GRIDPREVIA_nFirstRecordOnPage-subGridprevia_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridprevia_lastpage( )
      {
         GRIDPREVIA_nRecordCount = subGridprevia_fnc_Recordcount( );
         if ( GRIDPREVIA_nRecordCount > subGridprevia_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDPREVIA_nRecordCount) % (subGridprevia_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDPREVIA_nFirstRecordOnPage = (long)(GRIDPREVIA_nRecordCount-subGridprevia_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDPREVIA_nFirstRecordOnPage = (long)(GRIDPREVIA_nRecordCount-((long)((GRIDPREVIA_nRecordCount) % (subGridprevia_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDPREVIA_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridprevia_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDPREVIA_nFirstRecordOnPage = (long)(subGridprevia_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDPREVIA_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridwalletbalances_fnc_Pagecount( )
      {
         GRIDWALLETBALANCES_nRecordCount = subGridwalletbalances_fnc_Recordcount( );
         if ( ((long)((GRIDWALLETBALANCES_nRecordCount) % (subGridwalletbalances_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWALLETBALANCES_nRecordCount/ (decimal)(subGridwalletbalances_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWALLETBALANCES_nRecordCount/ (decimal)(subGridwalletbalances_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridwalletbalances_fnc_Recordcount( )
      {
         return (int)(subGridwalletbalancesclient_rec_count_fnc()) ;
      }

      protected int subGridwalletbalances_fnc_Recordsperpage( )
      {
         if ( subGridwalletbalances_Rows > 0 )
         {
            return subGridwalletbalances_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridwalletbalances_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDWALLETBALANCES_nFirstRecordOnPage/ (decimal)(subGridwalletbalances_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridwalletbalances_firstpage( )
      {
         GRIDWALLETBALANCES_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridwalletbalances_nextpage( )
      {
         if ( GRIDWALLETBALANCES_nEOF == 0 )
         {
            GRIDWALLETBALANCES_nFirstRecordOnPage = (long)(GRIDWALLETBALANCES_nFirstRecordOnPage+subGridwalletbalances_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nFirstRecordOnPage), 15, 0, ".", "")));
         GridwalletbalancesContainer.AddObjectProperty("GRIDWALLETBALANCES_nFirstRecordOnPage", GRIDWALLETBALANCES_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDWALLETBALANCES_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridwalletbalances_previouspage( )
      {
         if ( GRIDWALLETBALANCES_nFirstRecordOnPage >= subGridwalletbalances_fnc_Recordsperpage( ) )
         {
            GRIDWALLETBALANCES_nFirstRecordOnPage = (long)(GRIDWALLETBALANCES_nFirstRecordOnPage-subGridwalletbalances_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridwalletbalances_lastpage( )
      {
         GRIDWALLETBALANCES_nRecordCount = subGridwalletbalances_fnc_Recordcount( );
         if ( GRIDWALLETBALANCES_nRecordCount > subGridwalletbalances_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDWALLETBALANCES_nRecordCount) % (subGridwalletbalances_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDWALLETBALANCES_nFirstRecordOnPage = (long)(GRIDWALLETBALANCES_nRecordCount-subGridwalletbalances_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDWALLETBALANCES_nFirstRecordOnPage = (long)(GRIDWALLETBALANCES_nRecordCount-((long)((GRIDWALLETBALANCES_nRecordCount) % (subGridwalletbalances_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDWALLETBALANCES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridwalletbalances_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDWALLETBALANCES_nFirstRecordOnPage = (long)(subGridwalletbalances_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDWALLETBALANCES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavGridwalletid_Enabled = 0;
         edtavSaldoacreedor_Enabled = 0;
         edtavSaldodeudor_Enabled = 0;
         edtavGridwalletnombre_Enabled = 0;
         edtavWalletcodrefencia_Enabled = 0;
         AssignProp("", false, edtavWalletcodrefencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletcodrefencia_Enabled), 5, 0), true);
         edtavWalletid_Enabled = 0;
         AssignProp("", false, edtavWalletid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletid_Enabled), 5, 0), true);
         edtavWalletnombre_Enabled = 0;
         AssignProp("", false, edtavWalletnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletnombre_Enabled), 5, 0), true);
         edtavWalletsaldo_Enabled = 0;
         AssignProp("", false, edtavWalletsaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletsaldo_Enabled), 5, 0), true);
         edtavWalletbalancesid_Enabled = 0;
         edtavWalletbalancesfechaalta_Enabled = 0;
         edtavWalletbalancesimporte_Enabled = 0;
         cmbavWalletbalancestipomov.Enabled = 0;
         cmbavWalletbalancesconcepto.Enabled = 0;
         edtavWalletbalancesobs_Enabled = 0;
         edtavWalletbalancesopeid_Enabled = 0;
         cmbavWalletbalancesestadoope.Enabled = 0;
         edtavTotalsolicitudes_Enabled = 0;
         AssignProp("", false, edtavTotalsolicitudes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalsolicitudes_Enabled), 5, 0), true);
         edtavTotalnetoapagar_Enabled = 0;
         AssignProp("", false, edtavTotalnetoapagar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalnetoapagar_Enabled), 5, 0), true);
         edtavTotalajusteswallet_Enabled = 0;
         AssignProp("", false, edtavTotalajusteswallet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalajusteswallet_Enabled), 5, 0), true);
         edtavCantidadregistros_Enabled = 0;
         AssignProp("", false, edtavCantidadregistros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidadregistros_Enabled), 5, 0), true);
         edtavCantidadajustes_Enabled = 0;
         AssignProp("", false, edtavCantidadajustes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidadajustes_Enabled), 5, 0), true);
         edtWalletCodRefencia_Enabled = 0;
         edtWalletNombre_Enabled = 0;
         edtWalletTotalCredito_Enabled = 0;
         edtWalletTotalDebito_Enabled = 0;
         edtWalletSaldo_Enabled = 0;
         edtWalletSolicitudesPendientes_Enabled = 0;
         edtWalletId_Enabled = 0;
         edtWalletBalancesId_Enabled = 0;
         edtWalletBalancesFechaAlta_Enabled = 0;
         edtWalletBalancesImporte_Enabled = 0;
         cmbWalletBalancesTipoMov.Enabled = 0;
         cmbWalletBalancesConcepto.Enabled = 0;
         edtWalletBalancesObs_Enabled = 0;
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         edtWalletBalancesUrl_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         edtSolicitudServicioComALM_Enabled = 0;
         edtSolicitudServicioComPro_Enabled = 0;
         edtSolicitudesCostoXZComAlm_Enabled = 0;
         edtSolicitudesCostoXZComProf_Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPL90( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22L92 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_100 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_100"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_118 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_118"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_140 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_140"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV35GridWalletPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDWALLETPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV35GridWalletPageCount", StringUtil.LTrimStr( (decimal)(AV35GridWalletPageCount), 10, 0));
            AV27GridWalletAppliedFilters = cgiGet( "vGRIDWALLETAPPLIEDFILTERS");
            AV23GridHistorialPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDHISTORIALPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23GridHistorialPageCount", StringUtil.LTrimStr( (decimal)(AV23GridHistorialPageCount), 10, 0));
            AV21GridHistorialAppliedFilters = cgiGet( "vGRIDHISTORIALAPPLIEDFILTERS");
            GRIDWALLET_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLET_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDWALLETBALANCES_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLETBALANCES_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDPREVIA_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPREVIA_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDHISTORIAL_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDHISTORIAL_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDWALLET_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLET_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDWALLETBALANCES_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLETBALANCES_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDPREVIA_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPREVIA_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDHISTORIAL_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDHISTORIAL_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridwallet_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLET_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDWALLET_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Rows), 6, 0, ".", "")));
            subGridwalletbalances_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLETBALANCES_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Rows), 6, 0, ".", "")));
            subGridprevia_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPREVIA_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDPREVIA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Rows), 6, 0, ".", "")));
            subGridhistorial_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDHISTORIAL_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Rows), 6, 0, ".", "")));
            Gridwalletpaginationbar_Class = cgiGet( "GRIDWALLETPAGINATIONBAR_Class");
            Gridwalletpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDWALLETPAGINATIONBAR_Showfirst"));
            Gridwalletpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDWALLETPAGINATIONBAR_Showprevious"));
            Gridwalletpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDWALLETPAGINATIONBAR_Shownext"));
            Gridwalletpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDWALLETPAGINATIONBAR_Showlast"));
            Gridwalletpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLETPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridwalletpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDWALLETPAGINATIONBAR_Pagingbuttonsposition");
            Gridwalletpaginationbar_Pagingcaptionposition = cgiGet( "GRIDWALLETPAGINATIONBAR_Pagingcaptionposition");
            Gridwalletpaginationbar_Emptygridclass = cgiGet( "GRIDWALLETPAGINATIONBAR_Emptygridclass");
            Gridwalletpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDWALLETPAGINATIONBAR_Rowsperpageselector"));
            Gridwalletpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLETPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridwalletpaginationbar_Rowsperpageoptions = cgiGet( "GRIDWALLETPAGINATIONBAR_Rowsperpageoptions");
            Gridwalletpaginationbar_Previous = cgiGet( "GRIDWALLETPAGINATIONBAR_Previous");
            Gridwalletpaginationbar_Next = cgiGet( "GRIDWALLETPAGINATIONBAR_Next");
            Gridwalletpaginationbar_Caption = cgiGet( "GRIDWALLETPAGINATIONBAR_Caption");
            Gridwalletpaginationbar_Emptygridcaption = cgiGet( "GRIDWALLETPAGINATIONBAR_Emptygridcaption");
            Gridwalletpaginationbar_Rowsperpagecaption = cgiGet( "GRIDWALLETPAGINATIONBAR_Rowsperpagecaption");
            Dvpanel_panelbuscadorcuentas_Width = cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Width");
            Dvpanel_panelbuscadorcuentas_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Autowidth"));
            Dvpanel_panelbuscadorcuentas_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Autoheight"));
            Dvpanel_panelbuscadorcuentas_Cls = cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Cls");
            Dvpanel_panelbuscadorcuentas_Title = cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Title");
            Dvpanel_panelbuscadorcuentas_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Collapsible"));
            Dvpanel_panelbuscadorcuentas_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Collapsed"));
            Dvpanel_panelbuscadorcuentas_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Showcollapseicon"));
            Dvpanel_panelbuscadorcuentas_Iconposition = cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Iconposition");
            Dvpanel_panelbuscadorcuentas_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELBUSCADORCUENTAS_Autoscroll"));
            Gridhistorialpaginationbar_Class = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Class");
            Gridhistorialpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Showfirst"));
            Gridhistorialpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Showprevious"));
            Gridhistorialpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Shownext"));
            Gridhistorialpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Showlast"));
            Gridhistorialpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridhistorialpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Pagingbuttonsposition");
            Gridhistorialpaginationbar_Pagingcaptionposition = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Pagingcaptionposition");
            Gridhistorialpaginationbar_Emptygridclass = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Emptygridclass");
            Gridhistorialpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselector"));
            Gridhistorialpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridhistorialpaginationbar_Rowsperpageoptions = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Rowsperpageoptions");
            Gridhistorialpaginationbar_Previous = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Previous");
            Gridhistorialpaginationbar_Next = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Next");
            Gridhistorialpaginationbar_Caption = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Caption");
            Gridhistorialpaginationbar_Emptygridcaption = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Emptygridcaption");
            Gridhistorialpaginationbar_Rowsperpagecaption = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Rowsperpagecaption");
            Gxuitabspanel_tabsliquidacion_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABSLIQUIDACION_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabsliquidacion_Class = cgiGet( "GXUITABSPANEL_TABSLIQUIDACION_Class");
            Gxuitabspanel_tabsliquidacion_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABSLIQUIDACION_Historymanagement"));
            Dvelop_confirmpanel_btnbtnliquidar_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Title");
            Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Confirmationtext");
            Dvelop_confirmpanel_btnbtnliquidar_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnbtnliquidar_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Nobuttoncaption");
            Dvelop_confirmpanel_btnbtnliquidar_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnbtnliquidar_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Yesbuttonposition");
            Dvelop_confirmpanel_btnbtnliquidar_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Confirmtype");
            Dvelop_confirmpanel_actioncrearwallets_Title = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Title");
            Dvelop_confirmpanel_actioncrearwallets_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Confirmationtext");
            Dvelop_confirmpanel_actioncrearwallets_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Yesbuttoncaption");
            Dvelop_confirmpanel_actioncrearwallets_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Nobuttoncaption");
            Dvelop_confirmpanel_actioncrearwallets_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Cancelbuttoncaption");
            Dvelop_confirmpanel_actioncrearwallets_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Yesbuttonposition");
            Dvelop_confirmpanel_actioncrearwallets_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Confirmtype");
            Gridhistorial_empowerer_Gridinternalname = cgiGet( "GRIDHISTORIAL_EMPOWERER_Gridinternalname");
            Gridhistorial_empowerer_Fixedcolumns = cgiGet( "GRIDHISTORIAL_EMPOWERER_Fixedcolumns");
            Gridprevia_empowerer_Gridinternalname = cgiGet( "GRIDPREVIA_EMPOWERER_Gridinternalname");
            Gridprevia_empowerer_Infinitescrolling = cgiGet( "GRIDPREVIA_EMPOWERER_Infinitescrolling");
            Gridwalletbalances_empowerer_Gridinternalname = cgiGet( "GRIDWALLETBALANCES_EMPOWERER_Gridinternalname");
            Gridwallet_empowerer_Gridinternalname = cgiGet( "GRIDWALLET_EMPOWERER_Gridinternalname");
            Gridhistorialpaginationbar_Selectedpage = cgiGet( "GRIDHISTORIALPAGINATIONBAR_Selectedpage");
            Gridhistorialpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDHISTORIALPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridwalletpaginationbar_Selectedpage = cgiGet( "GRIDWALLETPAGINATIONBAR_Selectedpage");
            Gridwalletpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDWALLETPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_btnbtnliquidar_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR_Result");
            Dvelop_confirmpanel_actioncrearwallets_Result = cgiGet( "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS_Result");
            /* Read variables values. */
            AV44TodosLosProfesionales = StringUtil.StrToBool( cgiGet( chkavTodoslosprofesionales_Internalname));
            AssignAttri("", false, "AV44TodosLosProfesionales", AV44TodosLosProfesionales);
            AV15BuscarCuenta = cgiGet( edtavBuscarcuenta_Internalname);
            AssignAttri("", false, "AV15BuscarCuenta", AV15BuscarCuenta);
            cmbavOperacionesperiodocod.Name = cmbavOperacionesperiodocod_Internalname;
            cmbavOperacionesperiodocod.CurrentValue = cgiGet( cmbavOperacionesperiodocod_Internalname);
            AV59OperacionesPeriodoCod = cgiGet( cmbavOperacionesperiodocod_Internalname);
            AssignAttri("", false, "AV59OperacionesPeriodoCod", AV59OperacionesPeriodoCod);
            if ( context.localUtil.VCDate( cgiGet( edtavFechadesde_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Desde", "")}), 1, "vFECHADESDE");
               GX_FocusControl = edtavFechadesde_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18FechaDesde = DateTime.MinValue;
               AssignAttri("", false, "AV18FechaDesde", context.localUtil.Format(AV18FechaDesde, "99/99/99"));
            }
            else
            {
               AV18FechaDesde = context.localUtil.CToD( cgiGet( edtavFechadesde_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV18FechaDesde", context.localUtil.Format(AV18FechaDesde, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechahasta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Hasta", "")}), 1, "vFECHAHASTA");
               GX_FocusControl = edtavFechahasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19FechaHasta = DateTime.MinValue;
               AssignAttri("", false, "AV19FechaHasta", context.localUtil.Format(AV19FechaHasta, "99/99/99"));
            }
            else
            {
               AV19FechaHasta = context.localUtil.CToD( cgiGet( edtavFechahasta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV19FechaHasta", context.localUtil.Format(AV19FechaHasta, "99/99/99"));
            }
            AV55WalletCodRefencia = cgiGet( edtavWalletcodrefencia_Internalname);
            AssignAttri("", false, "AV55WalletCodRefencia", AV55WalletCodRefencia);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWALLETID");
               GX_FocusControl = edtavWalletid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV56WalletId = 0;
               AssignAttri("", false, "AV56WalletId", StringUtil.LTrimStr( (decimal)(AV56WalletId), 18, 0));
            }
            else
            {
               AV56WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56WalletId", StringUtil.LTrimStr( (decimal)(AV56WalletId), 18, 0));
            }
            AV57WalletNombre = cgiGet( edtavWalletnombre_Internalname);
            AssignAttri("", false, "AV57WalletNombre", AV57WalletNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWalletsaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavWalletsaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWALLETSALDO");
               GX_FocusControl = edtavWalletsaldo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV58WalletSaldo = 0;
               AssignAttri("", false, "AV58WalletSaldo", StringUtil.LTrimStr( AV58WalletSaldo, 18, 2));
            }
            else
            {
               AV58WalletSaldo = context.localUtil.CToN( cgiGet( edtavWalletsaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV58WalletSaldo", StringUtil.LTrimStr( AV58WalletSaldo, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalsolicitudes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalsolicitudes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALSOLICITUDES");
               GX_FocusControl = edtavTotalsolicitudes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV48TotalSolicitudes = 0;
               AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
            }
            else
            {
               AV48TotalSolicitudes = context.localUtil.CToN( cgiGet( edtavTotalsolicitudes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalnetoapagar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalnetoapagar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALNETOAPAGAR");
               GX_FocusControl = edtavTotalnetoapagar_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47TotalNetoAPagar = 0;
               AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
            }
            else
            {
               AV47TotalNetoAPagar = context.localUtil.CToN( cgiGet( edtavTotalnetoapagar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalajusteswallet_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalajusteswallet_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALAJUSTESWALLET");
               GX_FocusControl = edtavTotalajusteswallet_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45TotalAjustesWallet = 0;
               AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
            }
            else
            {
               AV45TotalAjustesWallet = context.localUtil.CToN( cgiGet( edtavTotalajusteswallet_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCantidadregistros_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCantidadregistros_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCANTIDADREGISTROS");
               GX_FocusControl = edtavCantidadregistros_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17CantidadRegistros = 0;
               AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
            }
            else
            {
               AV17CantidadRegistros = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCantidadregistros_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCantidadajustes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCantidadajustes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCANTIDADAJUSTES");
               GX_FocusControl = edtavCantidadajustes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16CantidadAjustes = 0;
               AssignAttri("", false, "AV16CantidadAjustes", StringUtil.LTrimStr( (decimal)(AV16CantidadAjustes), 4, 0));
            }
            else
            {
               AV16CantidadAjustes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCantidadajustes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV16CantidadAjustes", StringUtil.LTrimStr( (decimal)(AV16CantidadAjustes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridwalletcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridwalletcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDWALLETCURRENTPAGE");
               GX_FocusControl = edtavGridwalletcurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32GridWalletCurrentPage = 0;
               AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
            }
            else
            {
               AV32GridWalletCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridwalletcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridhistorialcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridhistorialcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDHISTORIALCURRENTPAGE");
               GX_FocusControl = edtavGridhistorialcurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22GridHistorialCurrentPage = 0;
               AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
            }
            else
            {
               AV22GridHistorialCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridhistorialcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            nGXsfl_35_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGridwallet_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            if ( nGXsfl_35_idx > 0 )
            {
               cmbavActionswallet.Name = cmbavActionswallet_Internalname;
               cmbavActionswallet.CurrentValue = cgiGet( cmbavActionswallet_Internalname);
               AV13ActionsWallet = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActionswallet_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActionswallet_Internalname, StringUtil.LTrimStr( (decimal)(AV13ActionsWallet), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavGridwalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridwalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDWALLETID");
                  GX_FocusControl = edtavGridwalletid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  AV33GridWalletId = 0;
                  AssignAttri("", false, edtavGridwalletid_Internalname, StringUtil.LTrimStr( (decimal)(AV33GridWalletId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
               }
               else
               {
                  AV33GridWalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridwalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, edtavGridwalletid_Internalname, StringUtil.LTrimStr( (decimal)(AV33GridWalletId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
               }
               A639WalletCodRefencia = cgiGet( edtWalletCodRefencia_Internalname);
               A715WalletNombre = cgiGet( edtWalletNombre_Internalname);
               A647WalletTotalCredito = context.localUtil.CToN( cgiGet( edtWalletTotalCredito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A646WalletTotalDebito = context.localUtil.CToN( cgiGet( edtWalletTotalDebito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A648WalletSaldo = context.localUtil.CToN( cgiGet( edtWalletSaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavSaldoacreedor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSaldoacreedor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSALDOACREEDOR");
                  GX_FocusControl = edtavSaldoacreedor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  AV86SaldoAcreedor = 0;
                  AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
               }
               else
               {
                  AV86SaldoAcreedor = context.localUtil.CToN( cgiGet( edtavSaldoacreedor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtavSaldodeudor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSaldodeudor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSALDODEUDOR");
                  GX_FocusControl = edtavSaldodeudor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  AV87SaldoDeudor = 0;
                  AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
               }
               else
               {
                  AV87SaldoDeudor = context.localUtil.CToN( cgiGet( edtavSaldodeudor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
               }
               A1007WalletSolicitudesPendientes = context.localUtil.CToN( cgiGet( edtWalletSolicitudesPendientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AV34GridWalletNombre = cgiGet( edtavGridwalletnombre_Internalname);
               AssignAttri("", false, edtavGridwalletnombre_Internalname, AV34GridWalletNombre);
               GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETNOMBRE"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, StringUtil.RTrim( context.localUtil.Format( AV34GridWalletNombre, "")), context));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBUSCARCUENTA"), AV15BuscarCuenta) != 0 )
            {
               GRIDWALLET_nFirstRecordOnPage = 0;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToBool( cgiGet( "GXH_vTODOSLOSPROFESIONALES")) != AV44TodosLosProfesionales )
            {
               GRIDWALLETBALANCES_nFirstRecordOnPage = 0;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToBool( cgiGet( "GXH_vTODOSLOSPROFESIONALES")) != AV44TodosLosProfesionales )
            {
               GRIDPREVIA_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHADESDE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV18FechaDesde ) )
            {
               GRIDPREVIA_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHAHASTA"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV19FechaHasta ) )
            {
               GRIDPREVIA_nFirstRecordOnPage = 0;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToBool( cgiGet( "GXH_vTODOSLOSPROFESIONALES")) != AV44TodosLosProfesionales )
            {
               GRIDHISTORIAL_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vWALLETID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV56WalletId )) )
            {
               GRIDHISTORIAL_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E22L92 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22L92( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext3 = AV84Context;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext3) ;
         AV84Context = GXt_SdtWWPContext3;
         AV85UserId = AV84Context.gxTpr_Userid;
         AssignAttri("", false, "AV85UserId", StringUtil.LTrimStr( (decimal)(AV85UserId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV85UserId), "ZZZZZZZZZ9"), context));
         Gridhistorial_empowerer_Gridinternalname = subGridhistorial_Internalname;
         ucGridhistorial_empowerer.SendProperty(context, "", false, Gridhistorial_empowerer_Internalname, "GridInternalName", Gridhistorial_empowerer_Gridinternalname);
         subGridhistorial_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Rows), 6, 0, ".", "")));
         AV22GridHistorialCurrentPage = 1;
         AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
         edtavGridhistorialcurrentpage_Visible = 0;
         AssignProp("", false, edtavGridhistorialcurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridhistorialcurrentpage_Visible), 5, 0), true);
         AV23GridHistorialPageCount = -1;
         AssignAttri("", false, "AV23GridHistorialPageCount", StringUtil.LTrimStr( (decimal)(AV23GridHistorialPageCount), 10, 0));
         Gridprevia_empowerer_Gridinternalname = subGridprevia_Internalname;
         ucGridprevia_empowerer.SendProperty(context, "", false, Gridprevia_empowerer_Internalname, "GridInternalName", Gridprevia_empowerer_Gridinternalname);
         subGridprevia_Rows = 20;
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Rows), 6, 0, ".", "")));
         Gridwalletbalances_empowerer_Gridinternalname = subGridwalletbalances_Internalname;
         ucGridwalletbalances_empowerer.SendProperty(context, "", false, Gridwalletbalances_empowerer_Internalname, "GridInternalName", Gridwalletbalances_empowerer_Gridinternalname);
         subGridwalletbalances_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Rows), 6, 0, ".", "")));
         Gridwallet_empowerer_Gridinternalname = subGridwallet_Internalname;
         ucGridwallet_empowerer.SendProperty(context, "", false, Gridwallet_empowerer_Internalname, "GridInternalName", Gridwallet_empowerer_Gridinternalname);
         subGridwallet_Rows = 8;
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Rows), 6, 0, ".", "")));
         AV32GridWalletCurrentPage = 1;
         AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
         edtavGridwalletcurrentpage_Visible = 0;
         AssignProp("", false, edtavGridwalletcurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridwalletcurrentpage_Visible), 5, 0), true);
         AV35GridWalletPageCount = -1;
         AssignAttri("", false, "AV35GridWalletPageCount", StringUtil.LTrimStr( (decimal)(AV35GridWalletPageCount), 10, 0));
         Gridhistorialpaginationbar_Rowsperpageselectedvalue = subGridhistorial_Rows;
         ucGridhistorialpaginationbar.SendProperty(context, "", false, Gridhistorialpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridhistorialpaginationbar_Rowsperpageselectedvalue), 9, 0));
         Gridwalletpaginationbar_Rowsperpageselectedvalue = subGridwallet_Rows;
         ucGridwalletpaginationbar.SendProperty(context, "", false, Gridwalletpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridwalletpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV56WalletId = 0;
         AssignAttri("", false, "AV56WalletId", StringUtil.LTrimStr( (decimal)(AV56WalletId), 18, 0));
         AV33GridWalletId = 0;
         AssignAttri("", false, edtavGridwalletid_Internalname, StringUtil.LTrimStr( (decimal)(AV33GridWalletId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         /* Execute user subroutine: 'CARGARCOMBOSEMANAS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E23L92( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV45TotalAjustesWallet = 0;
         AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
         if ( ! (0==AV56WalletId) && ! AV44TodosLosProfesionales )
         {
            AV88GXLvl41 = 0;
            /* Using cursor H00L911 */
            pr_default.execute(9, new Object[] {AV56WalletId});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A637WalletId = H00L911_A637WalletId[0];
               A639WalletCodRefencia = H00L911_A639WalletCodRefencia[0];
               A638WalletTipoEntidad = H00L911_A638WalletTipoEntidad[0];
               GXt_char1 = A715WalletNombre;
               new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char1) ;
               A715WalletNombre = GXt_char1;
               GXt_decimal2 = A646WalletTotalDebito;
               new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
               A646WalletTotalDebito = GXt_decimal2;
               GXt_decimal2 = A647WalletTotalCredito;
               new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
               A647WalletTotalCredito = GXt_decimal2;
               A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
               AV88GXLvl41 = 1;
               AV55WalletCodRefencia = A639WalletCodRefencia;
               AssignAttri("", false, "AV55WalletCodRefencia", AV55WalletCodRefencia);
               AV57WalletNombre = A715WalletNombre;
               AssignAttri("", false, "AV57WalletNombre", AV57WalletNombre);
               AV58WalletSaldo = A648WalletSaldo;
               AssignAttri("", false, "AV58WalletSaldo", StringUtil.LTrimStr( AV58WalletSaldo, 18, 2));
               AV43ProfesionalesId = A639WalletCodRefencia;
               AssignAttri("", false, "AV43ProfesionalesId", AV43ProfesionalesId);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(9);
            if ( AV88GXLvl41 == 0 )
            {
               AV55WalletCodRefencia = "";
               AssignAttri("", false, "AV55WalletCodRefencia", AV55WalletCodRefencia);
               AV57WalletNombre = "";
               AssignAttri("", false, "AV57WalletNombre", AV57WalletNombre);
               AV58WalletSaldo = 0;
               AssignAttri("", false, "AV58WalletSaldo", StringUtil.LTrimStr( AV58WalletSaldo, 18, 2));
               AV43ProfesionalesId = "";
               AssignAttri("", false, "AV43ProfesionalesId", AV43ProfesionalesId);
            }
            divTablecontent_Visible = 1;
            AssignProp("", false, divTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontent_Visible), 5, 0), true);
            /* Execute user subroutine: 'CALCULARSOLICITUDES' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'RECALCULARTOTALESWALLET' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV47TotalNetoAPagar = (decimal)(AV48TotalSolicitudes+AV45TotalAjustesWallet);
            AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
         }
         else
         {
            AV55WalletCodRefencia = "";
            AssignAttri("", false, "AV55WalletCodRefencia", AV55WalletCodRefencia);
            AV57WalletNombre = "";
            AssignAttri("", false, "AV57WalletNombre", AV57WalletNombre);
            AV58WalletSaldo = 0;
            AssignAttri("", false, "AV58WalletSaldo", StringUtil.LTrimStr( AV58WalletSaldo, 18, 2));
            AV43ProfesionalesId = "";
            AssignAttri("", false, "AV43ProfesionalesId", AV43ProfesionalesId);
            divTablecontent_Visible = 0;
            AssignProp("", false, divTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontent_Visible), 5, 0), true);
            AV17CantidadRegistros = 0;
            AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
            AV48TotalSolicitudes = 0;
            AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
            AV45TotalAjustesWallet = 0;
            AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
            AV47TotalNetoAPagar = 0;
            AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
         }
         AV35GridWalletPageCount = subGridwallet_fnc_Pagecount( );
         AssignAttri("", false, "AV35GridWalletPageCount", StringUtil.LTrimStr( (decimal)(AV35GridWalletPageCount), 10, 0));
         AV23GridHistorialPageCount = subGridhistorial_fnc_Pagecount( );
         AssignAttri("", false, "AV23GridHistorialPageCount", StringUtil.LTrimStr( (decimal)(AV23GridHistorialPageCount), 10, 0));
         edtavSaldodeudor_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavSaldodeudor_Internalname, "Columnheaderclass", edtavSaldodeudor_Columnheaderclass, !bGXsfl_35_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E24L92( )
      {
         if ( ( subGridwallet_Islastpage == 1 ) || ( subGridwallet_Rows == 0 ) || ( ( GRIDWALLET_nCurrentRecord >= GRIDWALLET_nFirstRecordOnPage ) && ( GRIDWALLET_nCurrentRecord < GRIDWALLET_nFirstRecordOnPage + subGridwallet_fnc_Recordsperpage( ) ) ) )
         {
            /* Gridwallet_Load Routine */
            returnInSub = false;
            AV33GridWalletId = A637WalletId;
            AssignAttri("", false, edtavGridwalletid_Internalname, StringUtil.LTrimStr( (decimal)(AV33GridWalletId), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
            AV34GridWalletNombre = A715WalletNombre;
            AssignAttri("", false, edtavGridwalletnombre_Internalname, AV34GridWalletNombre);
            GxWebStd.gx_hidden_field( context, "gxhash_vGRIDWALLETNOMBRE"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, StringUtil.RTrim( context.localUtil.Format( AV34GridWalletNombre, "")), context));
            if ( ( A648WalletSaldo > Convert.ToDecimal( 0 )) )
            {
               AV86SaldoAcreedor = A648WalletSaldo;
               AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
               AV87SaldoDeudor = 0;
               AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
            }
            else
            {
               if ( ( A648WalletSaldo < Convert.ToDecimal( 0 )) )
               {
                  AV86SaldoAcreedor = 0;
                  AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
                  AV87SaldoDeudor = (decimal)(A648WalletSaldo*-1);
                  AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
               }
               else
               {
                  AV86SaldoAcreedor = 0;
                  AssignAttri("", false, edtavSaldoacreedor_Internalname, StringUtil.LTrimStr( AV86SaldoAcreedor, 18, 2));
                  AV87SaldoDeudor = 0;
                  AssignAttri("", false, edtavSaldodeudor_Internalname, StringUtil.LTrimStr( AV87SaldoDeudor, 18, 2));
               }
            }
            cmbavActionswallet.removeAllItems();
            cmbavActionswallet.addItem("0", ";fa fa-bars", 0);
            cmbavActionswallet.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Acreditar", ""), "fas fa-circle-plus", "", "", "", "", "", "", ""), 0);
            cmbavActionswallet.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Debitar", ""), "fas fa-circle-minus", "", "", "", "", "", "", ""), 0);
            edtavSaldodeudor_Columnclass = ((AV87SaldoDeudor!=Convert.ToDecimal(0)) ? "WWColumn WWColumnDanger WWColumnDangerSingleCell" : "WWColumn");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 35;
            }
            sendrow_352( ) ;
         }
         GRIDWALLET_nEOF = (short)(((subGridwallet_Rows==0)||(GRIDWALLET_nCurrentRecord<GRIDWALLET_nFirstRecordOnPage+subGridwallet_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLET_nEOF), 1, 0, ".", "")));
         GRIDWALLET_nCurrentRecord = (long)(GRIDWALLET_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            context.DoAjaxLoad(35, GridwalletRow);
         }
         /*  Sending Event outputs  */
         cmbavActionswallet.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13ActionsWallet), 4, 0));
      }

      protected void E14L92( )
      {
         /* Gridhistorialpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridhistorialpaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV22GridHistorialCurrentPage = (long)(AV22GridHistorialCurrentPage-1);
            AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
            subgridhistorial_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridhistorialpaginationbar_Selectedpage, "Next") == 0 )
         {
            AV22GridHistorialCurrentPage = (long)(AV22GridHistorialCurrentPage+1);
            AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
            subgridhistorial_nextpage( ) ;
         }
         else
         {
            AV42PageToGo = (int)(Math.Round(NumberUtil.Val( Gridhistorialpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV22GridHistorialCurrentPage = AV42PageToGo;
            AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
            subgridhistorial_gotopage( AV42PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E15L92( )
      {
         /* Gridhistorialpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridhistorial_Rows = Gridhistorialpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDHISTORIAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Rows), 6, 0, ".", "")));
         AV22GridHistorialCurrentPage = 1;
         AssignAttri("", false, "AV22GridHistorialCurrentPage", StringUtil.LTrimStr( (decimal)(AV22GridHistorialCurrentPage), 10, 0));
         subgridhistorial_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E12L92( )
      {
         /* Gridwalletpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridwalletpaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV32GridWalletCurrentPage = (long)(AV32GridWalletCurrentPage-1);
            AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
            subgridwallet_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridwalletpaginationbar_Selectedpage, "Next") == 0 )
         {
            AV32GridWalletCurrentPage = (long)(AV32GridWalletCurrentPage+1);
            AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
            subgridwallet_nextpage( ) ;
         }
         else
         {
            AV42PageToGo = (int)(Math.Round(NumberUtil.Val( Gridwalletpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV32GridWalletCurrentPage = AV42PageToGo;
            AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
            subgridwallet_gotopage( AV42PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E13L92( )
      {
         /* Gridwalletpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridwallet_Rows = Gridwalletpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDWALLET_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Rows), 6, 0, ".", "")));
         AV32GridWalletCurrentPage = 1;
         AssignAttri("", false, "AV32GridWalletCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridWalletCurrentPage), 10, 0));
         subgridwallet_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E18L92( )
      {
         /* 'DoBtnLiquidar' Routine */
         returnInSub = false;
         if ( AV44TodosLosProfesionales )
         {
            Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext = context.GetMessage( "¿Está seguro de procesar la liquidación masiva para todos los profesionales activos en el período ", "")+StringUtil.Trim( AV59OperacionesPeriodoCod)+"?";
            ucDvelop_confirmpanel_btnbtnliquidar.SendProperty(context, "", false, Dvelop_confirmpanel_btnbtnliquidar_Internalname, "ConfirmationText", Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext);
         }
         else
         {
            Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext = context.GetMessage( "¿Desea generar la liquidación para el profesional seleccionado?", "");
            ucDvelop_confirmpanel_btnbtnliquidar.SendProperty(context, "", false, Dvelop_confirmpanel_btnbtnliquidar_Internalname, "ConfirmationText", Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext);
            AV81OperacionPreviaId = 0;
            /* Using cursor H00L912 */
            pr_default.execute(10, new Object[] {AV59OperacionesPeriodoCod, AV43ProfesionalesId});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A577OperacionesEstado = H00L912_A577OperacionesEstado[0];
               n577OperacionesEstado = H00L912_n577OperacionesEstado[0];
               A1028OperacionesPeriodoCod = H00L912_A1028OperacionesPeriodoCod[0];
               n1028OperacionesPeriodoCod = H00L912_n1028OperacionesPeriodoCod[0];
               A649OperacionesTipo = H00L912_A649OperacionesTipo[0];
               n649OperacionesTipo = H00L912_n649OperacionesTipo[0];
               A555OperacionesRef = H00L912_A555OperacionesRef[0];
               n555OperacionesRef = H00L912_n555OperacionesRef[0];
               A554OperacionesId = H00L912_A554OperacionesId[0];
               if ( StringUtil.StrCmp(A649OperacionesTipo, context.GetMessage( "LSF", "")) == 0 )
               {
                  AV81OperacionPreviaId = A554OperacionesId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(10);
            }
            pr_default.close(10);
            if ( AV81OperacionPreviaId > 0 )
            {
               Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext = context.GetMessage( "Ya existe liquidación en este período para el profesional. De continuar se sobreescribirá la liquidación actual.", "");
               ucDvelop_confirmpanel_btnbtnliquidar.SendProperty(context, "", false, Dvelop_confirmpanel_btnbtnliquidar_Internalname, "ConfirmationText", Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext);
            }
         }
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDARContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E16L92( )
      {
         /* Dvelop_confirmpanel_btnbtnliquidar_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnbtnliquidar_Result, "Yes") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59OperacionesPeriodoCod)) || ( (DateTime.MinValue==AV18FechaDesde) || (DateTime.MinValue==AV19FechaHasta) ) )
            {
               GX_msglist.addItem(context.GetMessage( "Debe seleccionar un período de liquidación.", ""));
            }
            else
            {
               if ( ! AV44TodosLosProfesionales )
               {
                  AV14BalancesSeleccionados.Clear();
                  /* Start For Each Line in Gridwalletbalances */
                  nRC_GXsfl_100 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_100"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  nGXsfl_100_fel_idx = 0;
                  while ( nGXsfl_100_fel_idx < nRC_GXsfl_100 )
                  {
                     nGXsfl_100_fel_idx = ((subGridwalletbalances_Islastpage==1)&&(nGXsfl_100_fel_idx+1>subGridwalletbalances_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_fel_idx+1);
                     sGXsfl_100_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_fel_idx), 4, 0), 4, "0");
                     SubsflControlProps_fel_1006( ) ;
                     AV37IncluirBalance = StringUtil.StrToBool( cgiGet( chkavIncluirbalance_Internalname));
                     A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                     A640WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                     A641WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtWalletBalancesFechaAlta_Internalname), 0);
                     A644WalletBalancesImporte = context.localUtil.CToN( cgiGet( edtWalletBalancesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                     cmbWalletBalancesTipoMov.Name = cmbWalletBalancesTipoMov_Internalname;
                     cmbWalletBalancesTipoMov.CurrentValue = cgiGet( cmbWalletBalancesTipoMov_Internalname);
                     A643WalletBalancesTipoMov = cgiGet( cmbWalletBalancesTipoMov_Internalname);
                     cmbWalletBalancesConcepto.Name = cmbWalletBalancesConcepto_Internalname;
                     cmbWalletBalancesConcepto.CurrentValue = cgiGet( cmbWalletBalancesConcepto_Internalname);
                     A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWalletBalancesConcepto_Internalname), "."), 18, MidpointRounding.ToEven));
                     n1010WalletBalancesConcepto = false;
                     A1009WalletBalancesObs = cgiGet( edtWalletBalancesObs_Internalname);
                     n1009WalletBalancesObs = false;
                     cmbWalletBalancesEstadoOPE.Name = cmbWalletBalancesEstadoOPE_Internalname;
                     cmbWalletBalancesEstadoOPE.CurrentValue = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
                     A645WalletBalancesEstadoOPE = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
                     A1011WalletBalancesUrl = cgiGet( edtWalletBalancesUrl_Internalname);
                     n1011WalletBalancesUrl = false;
                     if ( AV37IncluirBalance )
                     {
                        AV14BalancesSeleccionados.Add(A640WalletBalancesId, 0);
                     }
                     /* End For Each Line */
                  }
                  if ( nGXsfl_100_fel_idx == 0 )
                  {
                     nGXsfl_100_idx = 1;
                     sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
                     SubsflControlProps_1006( ) ;
                  }
                  nGXsfl_100_fel_idx = 1;
                  AV8OperacionesTipo = "LSF";
                  AV7OperacionesRef = StringUtil.Trim( AV43ProfesionalesId);
                  AV6OperacionesNombreRef = AV9ProfesionalesNombre;
                  new liquidacionsolicitudes(context ).execute(  AV8OperacionesTipo,  AV7OperacionesRef,  AV6OperacionesNombreRef,  AV18FechaDesde,  AV19FechaHasta,  AV14BalancesSeleccionados,  AV59OperacionesPeriodoCod, out  Gx_msg, out  AV40IsOk) ;
                  if ( AV40IsOk )
                  {
                     GX_msglist.addItem(context.GetMessage( "Liquidación individual generada con éxito", ""));
                     AV17CantidadRegistros = 0;
                     AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
                     AV48TotalSolicitudes = 0;
                     AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
                     AV45TotalAjustesWallet = 0;
                     AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
                     AV16CantidadAjustes = 0;
                     AssignAttri("", false, "AV16CantidadAjustes", StringUtil.LTrimStr( (decimal)(AV16CantidadAjustes), 4, 0));
                     AV47TotalNetoAPagar = 0;
                     AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
                     context.DoAjaxRefresh();
                  }
                  else
                  {
                     GX_msglist.addItem(Gx_msg);
                     GX_msglist.addItem(context.GetMessage( "Ocurrió un error al procesar la liquidación", ""));
                  }
               }
               else
               {
                  AV8OperacionesTipo = "LSF";
                  new liquidacionsolicitudestotal(context ).execute(  AV8OperacionesTipo,  AV18FechaDesde,  AV19FechaHasta,  AV59OperacionesPeriodoCod,  AV85UserId, out  Gx_msg, out  AV40IsOk) ;
                  if ( AV40IsOk )
                  {
                     GX_msglist.addItem(Gx_msg);
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "Error en la corrida masiva: ", "")+Gx_msg);
                  }
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E19L92( )
      {
         /* 'DoBtnCancelar' Routine */
         returnInSub = false;
         CallWebObject(formatLink("walletww.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E31L92( )
      {
         /* Actions_Click Routine */
         returnInSub = false;
         if ( AV12Actions == 1 )
         {
            /* Execute user subroutine: 'DO BTNVERRESUMEN' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV12Actions == 2 )
         {
            /* Execute user subroutine: 'DO BTNPDF' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV12Actions == 3 )
         {
            /* Execute user subroutine: 'DO BTNVERDETALLE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV12Actions == 4 )
         {
            /* Execute user subroutine: 'DO BTNANULAR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV12Actions = 0;
         AssignAttri("", false, cmbavActions_Internalname, StringUtil.LTrimStr( (decimal)(AV12Actions), 4, 0));
         /*  Sending Event outputs  */
         cmbavActions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Actions), 4, 0));
         AssignProp("", false, cmbavActions_Internalname, "Values", cmbavActions.ToJavascriptSource(), true);
      }

      protected void E17L92( )
      {
         /* Dvelop_confirmpanel_actioncrearwallets_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_actioncrearwallets_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION ACTIONCREARWALLETS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E25L92( )
      {
         /* Actionswallet_Click Routine */
         returnInSub = false;
         if ( AV13ActionsWallet == 1 )
         {
            /* Execute user subroutine: 'DO ACTIONACREDITAR' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV13ActionsWallet == 2 )
         {
            /* Execute user subroutine: 'DO ACTIONDEBITAR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV13ActionsWallet = 0;
         AssignAttri("", false, cmbavActionswallet_Internalname, StringUtil.LTrimStr( (decimal)(AV13ActionsWallet), 4, 0));
         /*  Sending Event outputs  */
         cmbavActionswallet.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13ActionsWallet), 4, 0));
         AssignProp("", false, cmbavActionswallet_Internalname, "Values", cmbavActionswallet.ToJavascriptSource(), true);
      }

      protected void S142( )
      {
         /* 'DO BTNVERRESUMEN' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'DO BTNPDF' Routine */
         returnInSub = false;
         if ( AV10WalletBalancesOpeId > 0 )
         {
            /* Window Datatype Object Property */
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "areciboliquidacion.aspx"+UrlEncode(StringUtil.LTrimStr(AV10WalletBalancesOpeId,18,0));
            AV11Window.Url = formatLink("areciboliquidacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV11Window.SetReturnParms(new Object[] {});
            context.NewWindow(AV11Window);
         }
      }

      protected void S162( )
      {
         /* 'DO BTNVERDETALLE' Routine */
         returnInSub = false;
         new reciboliquidacionexcel(context ).execute(  AV10WalletBalancesOpeId, out  AV20Filename) ;
         CallWebObject(formatLink(AV20Filename) );
         context.wjLocDisableFrm = 0;
      }

      protected void S172( )
      {
         /* 'DO BTNANULAR' Routine */
         returnInSub = false;
         if ( ! (0==AV10WalletBalancesOpeId) )
         {
            new anularliquidacion(context ).execute(  AV10WalletBalancesOpeId, out  AV78Ok, out  AV79Mensaje) ;
            GX_msglist.addItem(AV79Mensaje);
            if ( AV78Ok )
            {
               AV10WalletBalancesOpeId = 0;
               AssignAttri("", false, edtavWalletbalancesopeid_Internalname, StringUtil.LTrimStr( (decimal)(AV10WalletBalancesOpeId), 18, 0));
               context.DoAjaxRefresh();
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "No hay una operación seleccionada para anular.", ""));
         }
      }

      protected void S182( )
      {
         /* 'DO ACTION ACTIONCREARWALLETS' Routine */
         returnInSub = false;
         new altawalletpendientes(context ).execute( out  Gx_msg) ;
         context.StatusMessage( Gx_msg );
         gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
      }

      protected void S192( )
      {
         /* 'DO ACTIONACREDITAR' Routine */
         returnInSub = false;
         AV56WalletId = AV33GridWalletId;
         AssignAttri("", false, "AV56WalletId", StringUtil.LTrimStr( (decimal)(AV56WalletId), 18, 0));
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("NCR")) + "," + UrlEncode(StringUtil.LTrimStr(AV33GridWalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV34GridWalletNombre)) + "," + UrlEncode(StringUtil.LTrimStr(AV5OperacionesId,18,0));
         context.PopUp(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S202( )
      {
         /* 'DO ACTIONDEBITAR' Routine */
         returnInSub = false;
         AV56WalletId = AV33GridWalletId;
         AssignAttri("", false, "AV56WalletId", StringUtil.LTrimStr( (decimal)(AV56WalletId), 18, 0));
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("NDE")) + "," + UrlEncode(StringUtil.LTrimStr(AV33GridWalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV34GridWalletNombre)) + "," + UrlEncode(StringUtil.LTrimStr(AV5OperacionesId,18,0));
         context.PopUp(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E28L92( )
      {
         /* Gridwalletbalances_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RECALCULARTOTALESWALLET' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E26L92( )
      {
         /* Gridwallet_Onlineactivate Routine */
         returnInSub = false;
         AV56WalletId = AV33GridWalletId;
         AssignAttri("", false, "AV56WalletId", StringUtil.LTrimStr( (decimal)(AV56WalletId), 18, 0));
         AV17CantidadRegistros = 0;
         AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
         AV48TotalSolicitudes = 0;
         AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
         GRIDPREVIA_nFirstRecordOnPage = 0;
         GRIDPREVIA_nCurrentRecord = 0;
         GXCCtl = "GRIDPREVIA_nFirstRecordOnPage_" + sGXsfl_118_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
         gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         gxgrGridwalletbalances_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A715WalletNombre, A648WalletSaldo, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV48TotalSolicitudes, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
         /* Execute user subroutine: 'RECALCULARTOTALESWALLET' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E20L92( )
      {
         /* Todoslosprofesionales_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV44TodosLosProfesionales )
         {
            AV43ProfesionalesId = "";
            AssignAttri("", false, "AV43ProfesionalesId", AV43ProfesionalesId);
            AV15BuscarCuenta = "";
            AssignAttri("", false, "AV15BuscarCuenta", AV15BuscarCuenta);
         }
         /*  Sending Event outputs  */
      }

      protected void E21L92( )
      {
         /* Operacionesperiodocod_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59OperacionesPeriodoCod)) )
         {
            AV74PosW = (short)(StringUtil.StringSearch( AV59OperacionesPeriodoCod, "-W", 1));
            if ( AV74PosW > 0 )
            {
               AV75AnioSeleccionado = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV59OperacionesPeriodoCod, 1, AV74PosW-1), "."), 18, MidpointRounding.ToEven));
               AV76SemSeleccionada = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV59OperacionesPeriodoCod, AV74PosW+2, 2), "."), 18, MidpointRounding.ToEven));
               AV66PrimerJueves = context.localUtil.YMDToD( AV75AnioSeleccionado, 1, 4);
               AV67DowPJ = DateTimeUtil.Dow( AV66PrimerJueves);
               if ( AV67DowPJ == 1 )
               {
                  AV66PrimerJueves = DateTimeUtil.DAdd(AV66PrimerJueves,-((int)(3)));
               }
               else
               {
                  AV66PrimerJueves = DateTimeUtil.DAdd(AV66PrimerJueves,-((int)((AV67DowPJ-5))));
               }
               AV77DiasASumar = (short)((AV76SemSeleccionada-1)*7);
               AV65JuevesSemana = DateTimeUtil.DAdd(AV66PrimerJueves,+((int)(AV77DiasASumar)));
               AV63LunesSemana = DateTimeUtil.DAdd(AV65JuevesSemana,-((int)(3)));
               AV64DomingoSemana = DateTimeUtil.DAdd(AV63LunesSemana,+((int)(6)));
               AV18FechaDesde = AV63LunesSemana;
               AssignAttri("", false, "AV18FechaDesde", context.localUtil.Format(AV18FechaDesde, "99/99/99"));
               AV19FechaHasta = AV64DomingoSemana;
               AssignAttri("", false, "AV19FechaHasta", context.localUtil.Format(AV19FechaHasta, "99/99/99"));
               AV73FechaDesdeSugerida = AV63LunesSemana;
               AV72FechaHastaSugerida = AV64DomingoSemana;
               GRIDPREVIA_nFirstRecordOnPage = 0;
               GRIDPREVIA_nCurrentRecord = 0;
               GXCCtl = "GRIDPREVIA_nFirstRecordOnPage_" + sGXsfl_118_idx;
               GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nFirstRecordOnPage), 15, 0, ".", "")));
               gxgrGridprevia_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A637WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
               gxgrGridwallet_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, A643WalletBalancesTipoMov, A644WalletBalancesImporte, AV33GridWalletId, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
               gxgrGridhistorial_refresh( subGridwallet_Rows, subGridwalletbalances_Rows, subGridprevia_Rows, subGridhistorial_Rows, AV15BuscarCuenta, AV44TodosLosProfesionales, AV18FechaDesde, AV19FechaHasta, AV56WalletId, A639WalletCodRefencia, A715WalletNombre, A648WalletSaldo, AV48TotalSolicitudes, AV43ProfesionalesId, A120ProfesionalesId, A184SolicitudesFechaInstalacion, A688SolicitudesLiqProf, A130EstadosSolTipo, A131EstadosSolId, A141EstadoSGTipo, A142EstadoSGId, A529SolicitudServicioComPro, A867SolicitudesCostoXZComProf, A438SolicitudServicioOrigenPago, A211SolicitudServicioPFinal, AV37IncluirBalance, AV9ProfesionalesNombre, AV85UserId, AV5OperacionesId) ;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'CARGARCOMBOSEMANAS' Routine */
         returnInSub = false;
         AV60PeriodoFechaPivot = DateTimeUtil.ServerDate( context, pr_default);
         AV61i = 1;
         while ( AV61i <= 4 )
         {
            AV62Dow = DateTimeUtil.Dow( AV60PeriodoFechaPivot);
            if ( AV62Dow == 1 )
            {
               AV63LunesSemana = DateTimeUtil.DAdd(AV60PeriodoFechaPivot,-((int)(6)));
            }
            else
            {
               AV63LunesSemana = DateTimeUtil.DAdd(AV60PeriodoFechaPivot,-((int)((AV62Dow-2))));
            }
            AV64DomingoSemana = DateTimeUtil.DAdd(AV63LunesSemana,+((int)(6)));
            AV65JuevesSemana = DateTimeUtil.DAdd(AV63LunesSemana,+((int)(3)));
            AV70AnioISO = (short)(DateTimeUtil.Year( AV65JuevesSemana));
            AV66PrimerJueves = context.localUtil.YMDToD( AV70AnioISO, 1, 4);
            AV67DowPJ = DateTimeUtil.Dow( AV66PrimerJueves);
            if ( AV67DowPJ == 1 )
            {
               AV66PrimerJueves = DateTimeUtil.DAdd(AV66PrimerJueves,-((int)(3)));
            }
            else
            {
               AV66PrimerJueves = DateTimeUtil.DAdd(AV66PrimerJueves,-((int)((AV67DowPJ-5))));
            }
            AV69NroSemanaISO = (short)(NumberUtil.Int( (long)(Math.Round((DateTimeUtil.DDiff(AV65JuevesSemana,AV66PrimerJueves))/ (decimal)(7), 18, MidpointRounding.ToEven)))+1);
            AV71CodSemana = StringUtil.Trim( StringUtil.Str( (decimal)(AV70AnioISO), 4, 0)) + "-W" + StringUtil.Trim( StringUtil.Str( (decimal)(AV69NroSemanaISO), 4, 0));
            AV68DescSemana = "Semana " + StringUtil.Trim( StringUtil.Str( (decimal)(AV69NroSemanaISO), 4, 0)) + " (" + context.localUtil.DToC( AV63LunesSemana, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/") + " al " + context.localUtil.DToC( AV64DomingoSemana, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/") + ")";
            cmbavOperacionesperiodocod.addItem(AV71CodSemana, AV68DescSemana, 0);
            if ( AV61i == 1 )
            {
               AV59OperacionesPeriodoCod = AV71CodSemana;
               AssignAttri("", false, "AV59OperacionesPeriodoCod", AV59OperacionesPeriodoCod);
               AV18FechaDesde = AV63LunesSemana;
               AssignAttri("", false, "AV18FechaDesde", context.localUtil.Format(AV18FechaDesde, "99/99/99"));
               AV19FechaHasta = AV64DomingoSemana;
               AssignAttri("", false, "AV19FechaHasta", context.localUtil.Format(AV19FechaHasta, "99/99/99"));
               AV73FechaDesdeSugerida = AV63LunesSemana;
               AV72FechaHastaSugerida = AV64DomingoSemana;
            }
            AV60PeriodoFechaPivot = DateTimeUtil.DAdd(AV63LunesSemana,-((int)(1)));
            AV61i = (short)(AV61i+1);
         }
      }

      protected void S132( )
      {
         /* 'RECALCULARTOTALESWALLET' Routine */
         returnInSub = false;
         AV45TotalAjustesWallet = 0;
         AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
         AV16CantidadAjustes = 0;
         AssignAttri("", false, "AV16CantidadAjustes", StringUtil.LTrimStr( (decimal)(AV16CantidadAjustes), 4, 0));
         AV47TotalNetoAPagar = AV48TotalSolicitudes;
         AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
         /* Start For Each Line in Gridwalletbalances */
         nRC_GXsfl_100 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_100"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_100_fel_idx = 0;
         while ( nGXsfl_100_fel_idx < nRC_GXsfl_100 )
         {
            nGXsfl_100_fel_idx = ((subGridwalletbalances_Islastpage==1)&&(nGXsfl_100_fel_idx+1>subGridwalletbalances_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_fel_idx+1);
            sGXsfl_100_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1006( ) ;
            AV37IncluirBalance = StringUtil.StrToBool( cgiGet( chkavIncluirbalance_Internalname));
            A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A640WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A641WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtWalletBalancesFechaAlta_Internalname), 0);
            A644WalletBalancesImporte = context.localUtil.CToN( cgiGet( edtWalletBalancesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            cmbWalletBalancesTipoMov.Name = cmbWalletBalancesTipoMov_Internalname;
            cmbWalletBalancesTipoMov.CurrentValue = cgiGet( cmbWalletBalancesTipoMov_Internalname);
            A643WalletBalancesTipoMov = cgiGet( cmbWalletBalancesTipoMov_Internalname);
            cmbWalletBalancesConcepto.Name = cmbWalletBalancesConcepto_Internalname;
            cmbWalletBalancesConcepto.CurrentValue = cgiGet( cmbWalletBalancesConcepto_Internalname);
            A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWalletBalancesConcepto_Internalname), "."), 18, MidpointRounding.ToEven));
            n1010WalletBalancesConcepto = false;
            A1009WalletBalancesObs = cgiGet( edtWalletBalancesObs_Internalname);
            n1009WalletBalancesObs = false;
            cmbWalletBalancesEstadoOPE.Name = cmbWalletBalancesEstadoOPE_Internalname;
            cmbWalletBalancesEstadoOPE.CurrentValue = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
            A645WalletBalancesEstadoOPE = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
            A1011WalletBalancesUrl = cgiGet( edtWalletBalancesUrl_Internalname);
            n1011WalletBalancesUrl = false;
            if ( AV37IncluirBalance )
            {
               AV16CantidadAjustes = (short)(AV16CantidadAjustes+1);
               AssignAttri("", false, "AV16CantidadAjustes", StringUtil.LTrimStr( (decimal)(AV16CantidadAjustes), 4, 0));
               if ( StringUtil.StrCmp(A643WalletBalancesTipoMov, "CRE") == 0 )
               {
                  AV45TotalAjustesWallet = (decimal)(AV45TotalAjustesWallet+A644WalletBalancesImporte);
                  AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
                  AV47TotalNetoAPagar = (decimal)(AV47TotalNetoAPagar+A644WalletBalancesImporte);
                  AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
               }
               else
               {
                  AV45TotalAjustesWallet = (decimal)(AV45TotalAjustesWallet-A644WalletBalancesImporte);
                  AssignAttri("", false, "AV45TotalAjustesWallet", StringUtil.LTrimStr( AV45TotalAjustesWallet, 18, 2));
                  AV47TotalNetoAPagar = (decimal)(AV47TotalNetoAPagar-A644WalletBalancesImporte);
                  AssignAttri("", false, "AV47TotalNetoAPagar", StringUtil.LTrimStr( AV47TotalNetoAPagar, 18, 2));
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_100_fel_idx == 0 )
         {
            nGXsfl_100_idx = 1;
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1006( ) ;
         }
         nGXsfl_100_fel_idx = 1;
      }

      protected void S122( )
      {
         /* 'CALCULARSOLICITUDES' Routine */
         returnInSub = false;
         AV17CantidadRegistros = 0;
         AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
         AV48TotalSolicitudes = 0;
         AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) || ( AV44TodosLosProfesionales ) )
         {
            pr_default.dynParam(11, new Object[]{ new Object[]{
                                                 A131EstadosSolId ,
                                                 AV44TodosLosProfesionales ,
                                                 AV18FechaDesde ,
                                                 AV19FechaHasta ,
                                                 A120ProfesionalesId ,
                                                 AV43ProfesionalesId ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 A688SolicitudesLiqProf ,
                                                 A130EstadosSolTipo ,
                                                 A141EstadoSGTipo ,
                                                 A142EstadoSGId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00L913 */
            pr_default.execute(11, new Object[] {AV43ProfesionalesId, AV18FechaDesde, AV19FechaHasta});
            while ( (pr_default.getStatus(11) != 101) )
            {
               A127SolicitudesID = H00L913_A127SolicitudesID[0];
               A142EstadoSGId = H00L913_A142EstadoSGId[0];
               A141EstadoSGTipo = H00L913_A141EstadoSGTipo[0];
               A131EstadosSolId = H00L913_A131EstadosSolId[0];
               A130EstadosSolTipo = H00L913_A130EstadosSolTipo[0];
               A688SolicitudesLiqProf = H00L913_A688SolicitudesLiqProf[0];
               n688SolicitudesLiqProf = H00L913_n688SolicitudesLiqProf[0];
               A184SolicitudesFechaInstalacion = H00L913_A184SolicitudesFechaInstalacion[0];
               A120ProfesionalesId = H00L913_A120ProfesionalesId[0];
               A438SolicitudServicioOrigenPago = H00L913_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = H00L913_n438SolicitudServicioOrigenPago[0];
               A796SolicitudesComisionMetodoPago = H00L913_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H00L913_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H00L913_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H00L913_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H00L913_n897SolicitudesDescuento[0];
               A527SolicitudServicioComProv = H00L913_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = H00L913_n527SolicitudServicioComProv[0];
               A530SolicitudServicioComALM = H00L913_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = H00L913_n530SolicitudServicioComALM[0];
               A865SolicitudesCostoXZComAlm = H00L913_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = H00L913_n865SolicitudesCostoXZComAlm[0];
               A864SolicitudesCostoXZona = H00L913_A864SolicitudesCostoXZona[0];
               A131EstadosSolId = H00L913_A131EstadosSolId[0];
               A130EstadosSolTipo = H00L913_A130EstadosSolTipo[0];
               A688SolicitudesLiqProf = H00L913_A688SolicitudesLiqProf[0];
               n688SolicitudesLiqProf = H00L913_n688SolicitudesLiqProf[0];
               A184SolicitudesFechaInstalacion = H00L913_A184SolicitudesFechaInstalacion[0];
               A438SolicitudServicioOrigenPago = H00L913_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = H00L913_n438SolicitudServicioOrigenPago[0];
               A796SolicitudesComisionMetodoPago = H00L913_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H00L913_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H00L913_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H00L913_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H00L913_n897SolicitudesDescuento[0];
               A527SolicitudServicioComProv = H00L913_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = H00L913_n527SolicitudServicioComProv[0];
               A530SolicitudServicioComALM = H00L913_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = H00L913_n530SolicitudServicioComALM[0];
               A865SolicitudesCostoXZComAlm = H00L913_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = H00L913_n865SolicitudesCostoXZComAlm[0];
               A864SolicitudesCostoXZona = H00L913_A864SolicitudesCostoXZona[0];
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
                  if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     GetSolicitudesTotal( A127SolicitudesID) ;
                     if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                        {
                           A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                        }
                        else
                        {
                           if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                           {
                              A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                           }
                           else
                           {
                              if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                              {
                                 A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                              }
                              else
                              {
                                 A211SolicitudServicioPFinal = 0;
                              }
                           }
                        }
                     }
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                        }
                        else
                        {
                           if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                           {
                              A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                           }
                           else
                           {
                              A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                           }
                        }
                     }
                     if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
                     {
                        A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
                     }
                     else
                     {
                        A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
                     }
                     AV17CantidadRegistros = (short)(AV17CantidadRegistros+1);
                     AssignAttri("", false, "AV17CantidadRegistros", StringUtil.LTrimStr( (decimal)(AV17CantidadRegistros), 4, 0));
                     AV41NetoFila = (decimal)(A529SolicitudServicioComPro+A867SolicitudesCostoXZComProf);
                     if ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
                     {
                        AV41NetoFila = (decimal)(AV41NetoFila-A211SolicitudServicioPFinal);
                     }
                     AV48TotalSolicitudes = (decimal)(AV48TotalSolicitudes+AV41NetoFila);
                     AssignAttri("", false, "AV48TotalSolicitudes", StringUtil.LTrimStr( AV48TotalSolicitudes, 18, 2));
                  }
               }
               pr_default.readNext(11);
            }
            pr_default.close(11);
         }
      }

      private void E30L94( )
      {
         /* Gridhistorial_Load Routine */
         returnInSub = false;
         AV51WalletBalancesId = A640WalletBalancesId;
         AssignAttri("", false, edtavWalletbalancesid_Internalname, StringUtil.LTrimStr( (decimal)(AV51WalletBalancesId), 18, 0));
         AV50WalletBalancesFechaAlta = A641WalletBalancesFechaAlta;
         AssignAttri("", false, edtavWalletbalancesfechaalta_Internalname, context.localUtil.TToC( AV50WalletBalancesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV52WalletBalancesImporte = A644WalletBalancesImporte;
         AssignAttri("", false, edtavWalletbalancesimporte_Internalname, StringUtil.LTrimStr( AV52WalletBalancesImporte, 18, 2));
         AV54WalletBalancesTipoMov = A643WalletBalancesTipoMov;
         AssignAttri("", false, cmbavWalletbalancestipomov_Internalname, AV54WalletBalancesTipoMov);
         AV49WalletBalancesConcepto = A1010WalletBalancesConcepto;
         AssignAttri("", false, cmbavWalletbalancesconcepto_Internalname, StringUtil.LTrimStr( (decimal)(AV49WalletBalancesConcepto), 4, 0));
         AV53WalletBalancesObs = A1009WalletBalancesObs;
         AssignAttri("", false, edtavWalletbalancesobs_Internalname, AV53WalletBalancesObs);
         AV10WalletBalancesOpeId = A1012WalletBalanceLiquidacion;
         AssignAttri("", false, edtavWalletbalancesopeid_Internalname, StringUtil.LTrimStr( (decimal)(AV10WalletBalancesOpeId), 18, 0));
         cmbavActions.removeAllItems();
         cmbavActions.addItem("0", ";fa fa-bars", 0);
         cmbavActions.addItem("1", context.GetMessage( "Ver Resumen", ""), 0);
         cmbavActions.addItem("2", context.GetMessage( "PDF", ""), 0);
         cmbavActions.addItem("3", context.GetMessage( "Excel", ""), 0);
         cmbavActions.addItem("4", context.GetMessage( "Anular", ""), 0);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 140;
         }
         sendrow_1404( ) ;
         GRIDHISTORIAL_nCurrentRecord = (long)(GRIDHISTORIAL_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_140_Refreshing )
         {
            context.DoAjaxLoad(140, GridhistorialRow);
         }
         /*  Sending Event outputs  */
         cmbavWalletbalancestipomov.CurrentValue = StringUtil.RTrim( AV54WalletBalancesTipoMov);
         cmbavWalletbalancesconcepto.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WalletBalancesConcepto), 4, 0));
         cmbavActions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Actions), 4, 0));
      }

      private void E29L95( )
      {
         if ( ( subGridprevia_Islastpage == 1 ) || ( subGridprevia_Rows == 0 ) || ( ( GRIDPREVIA_nCurrentRecord >= GRIDPREVIA_nFirstRecordOnPage ) && ( GRIDPREVIA_nCurrentRecord < GRIDPREVIA_nFirstRecordOnPage + subGridprevia_fnc_Recordsperpage( ) ) ) )
         {
            /* Gridprevia_Load Routine */
            returnInSub = false;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 118;
            }
            sendrow_1185( ) ;
         }
         GRIDPREVIA_nEOF = (short)(((subGridprevia_Rows==0)||(GRIDPREVIA_nCurrentRecord<GRIDPREVIA_nFirstRecordOnPage+subGridprevia_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDPREVIA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPREVIA_nEOF), 1, 0, ".", "")));
         GRIDPREVIA_nCurrentRecord = (long)(GRIDPREVIA_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_118_Refreshing )
         {
            context.DoAjaxLoad(118, GridpreviaRow);
         }
      }

      private void E27L96( )
      {
         if ( ( subGridwalletbalances_Islastpage == 1 ) || ( subGridwalletbalances_Rows == 0 ) || ( ( GRIDWALLETBALANCES_nCurrentRecord >= GRIDWALLETBALANCES_nFirstRecordOnPage ) && ( GRIDWALLETBALANCES_nCurrentRecord < GRIDWALLETBALANCES_nFirstRecordOnPage + subGridwalletbalances_fnc_Recordsperpage( ) ) ) )
         {
            /* Gridwalletbalances_Load Routine */
            returnInSub = false;
            edtWalletBalancesUrl_Linktarget = "_blank";
            edtWalletBalancesUrl_Link = A1011WalletBalancesUrl;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 100;
            }
            sendrow_1006( ) ;
         }
         GRIDWALLETBALANCES_nEOF = (short)(((subGridwalletbalances_Rows==0)||(GRIDWALLETBALANCES_nCurrentRecord<GRIDWALLETBALANCES_nFirstRecordOnPage+subGridwalletbalances_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDWALLETBALANCES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDWALLETBALANCES_nEOF), 1, 0, ".", "")));
         GRIDWALLETBALANCES_nCurrentRecord = (long)(GRIDWALLETBALANCES_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_100_Refreshing )
         {
            context.DoAjaxLoad(100, GridwalletbalancesRow);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table5_215_L92( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_actioncrearwallets_Internalname, tblTabledvelop_confirmpanel_actioncrearwallets_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("Title", Dvelop_confirmpanel_actioncrearwallets_Title);
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("ConfirmationText", Dvelop_confirmpanel_actioncrearwallets_Confirmationtext);
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("YesButtonCaption", Dvelop_confirmpanel_actioncrearwallets_Yesbuttoncaption);
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("NoButtonCaption", Dvelop_confirmpanel_actioncrearwallets_Nobuttoncaption);
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_actioncrearwallets_Cancelbuttoncaption);
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("YesButtonPosition", Dvelop_confirmpanel_actioncrearwallets_Yesbuttonposition);
            ucDvelop_confirmpanel_actioncrearwallets.SetProperty("ConfirmType", Dvelop_confirmpanel_actioncrearwallets_Confirmtype);
            ucDvelop_confirmpanel_actioncrearwallets.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_actioncrearwallets_Internalname, "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_ACTIONCREARWALLETSContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_215_L92e( true) ;
         }
         else
         {
            wb_table5_215_L92e( false) ;
         }
      }

      protected void wb_table4_210_L92( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnbtnliquidar_Internalname, tblTabledvelop_confirmpanel_btnbtnliquidar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("Title", Dvelop_confirmpanel_btnbtnliquidar_Title);
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext);
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnbtnliquidar_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnbtnliquidar_Nobuttoncaption);
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnbtnliquidar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnbtnliquidar_Yesbuttonposition);
            ucDvelop_confirmpanel_btnbtnliquidar.SetProperty("ConfirmType", Dvelop_confirmpanel_btnbtnliquidar_Confirmtype);
            ucDvelop_confirmpanel_btnbtnliquidar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnbtnliquidar_Internalname, "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNBTNLIQUIDARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_210_L92e( true) ;
         }
         else
         {
            wb_table4_210_L92e( false) ;
         }
      }

      protected void wb_table3_199_L92( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableactions_Internalname, tblTableactions_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnliquidar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "Confirmar liquidacion", ""), bttBtnbtnliquidar_Jsonclick, 5, context.GetMessage( "Confirmar liquidacion", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNLIQUIDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPLiquidacionCentro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtncancelar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "Cancelar", ""), bttBtnbtncancelar_Jsonclick, 5, context.GetMessage( "Cancelar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNCANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPLiquidacionCentro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_199_L92e( true) ;
         }
         else
         {
            wb_table3_199_L92e( false) ;
         }
      }

      protected void wb_table2_155_L92( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletotales_Internalname, tblTabletotales_Internalname, "", "CellPadding", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletotalsolicitudes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktotalsolicitudes_Internalname, context.GetMessage( "Importe solicitudes", ""), "", "", lblTextblocktotalsolicitudes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalsolicitudes_Internalname, context.GetMessage( "Total Solicitudes", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalsolicitudes_Internalname, StringUtil.LTrim( StringUtil.NToC( AV48TotalSolicitudes, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavTotalsolicitudes_Enabled!=0) ? context.localUtil.Format( AV48TotalSolicitudes, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV48TotalSolicitudes, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalsolicitudes_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTotalsolicitudes_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletotalnetoapagar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktotalnetoapagar_Internalname, context.GetMessage( "Importe total", ""), "", "", lblTextblocktotalnetoapagar_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalnetoapagar_Internalname, context.GetMessage( "Total Neto APagar", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalnetoapagar_Internalname, StringUtil.LTrim( StringUtil.NToC( AV47TotalNetoAPagar, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavTotalnetoapagar_Enabled!=0) ? context.localUtil.Format( AV47TotalNetoAPagar, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV47TotalNetoAPagar, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalnetoapagar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTotalnetoapagar_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletotalajusteswallet_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktotalajusteswallet_Internalname, context.GetMessage( "Ajustes", ""), "", "", lblTextblocktotalajusteswallet_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalajusteswallet_Internalname, context.GetMessage( "Total Ajustes Wallet", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalajusteswallet_Internalname, StringUtil.LTrim( StringUtil.NToC( AV45TotalAjustesWallet, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavTotalajusteswallet_Enabled!=0) ? context.localUtil.Format( AV45TotalAjustesWallet, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV45TotalAjustesWallet, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,180);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalajusteswallet_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTotalajusteswallet_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecantidadregistros_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcantidadregistros_Internalname, context.GetMessage( "Nro de solicitudes", ""), "", "", lblTextblockcantidadregistros_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCantidadregistros_Internalname, context.GetMessage( "Cantidad Registros", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCantidadregistros_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17CantidadRegistros), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCantidadregistros_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17CantidadRegistros), "ZZZ9") : context.localUtil.Format( (decimal)(AV17CantidadRegistros), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,188);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCantidadregistros_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCantidadregistros_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecantidadajustes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcantidadajustes_Internalname, context.GetMessage( "Nro Ajustes", ""), "", "", lblTextblockcantidadajustes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCantidadajustes_Internalname, context.GetMessage( "Cantidad Ajustes", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCantidadajustes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CantidadAjustes), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCantidadajustes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16CantidadAjustes), "ZZZ9") : context.localUtil.Format( (decimal)(AV16CantidadAjustes), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCantidadajustes_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCantidadajustes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_155_L92e( true) ;
         }
         else
         {
            wb_table2_155_L92e( false) ;
         }
      }

      protected void wb_table1_79_L92( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablewalletheader_Internalname, tblTablewalletheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavWalletcodrefencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletcodrefencia_Internalname, context.GetMessage( "Profesional", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletcodrefencia_Internalname, StringUtil.RTrim( AV55WalletCodRefencia), StringUtil.RTrim( context.localUtil.Format( AV55WalletCodRefencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletcodrefencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWalletcodrefencia_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavWalletid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletid_Internalname, context.GetMessage( "Nro Cuenta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWalletid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV56WalletId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV56WalletId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWalletid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavWalletnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletnombre_Internalname, context.GetMessage( "Nombre Cuenta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletnombre_Internalname, StringUtil.RTrim( AV57WalletNombre), StringUtil.RTrim( context.localUtil.Format( AV57WalletNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletnombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWalletnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavWalletsaldo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletsaldo_Internalname, context.GetMessage( "Saldo", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletsaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( AV58WalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavWalletsaldo_Enabled!=0) ? context.localUtil.Format( AV58WalletSaldo, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV58WalletSaldo, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletsaldo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWalletsaldo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPLiquidacionCentro.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_79_L92e( true) ;
         }
         else
         {
            wb_table1_79_L92e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PAL92( ) ;
         WSL92( ) ;
         WEL92( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20261052025191", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true, false);
            context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 74760), false, true, false);
            context.AddJavascriptSource("wpliquidacioncentro.js", "?20261052025191", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         cmbavActionswallet_Internalname = "vACTIONSWALLET_"+sGXsfl_35_idx;
         edtavGridwalletid_Internalname = "vGRIDWALLETID_"+sGXsfl_35_idx;
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA_"+sGXsfl_35_idx;
         edtWalletNombre_Internalname = "WALLETNOMBRE_"+sGXsfl_35_idx;
         edtWalletTotalCredito_Internalname = "WALLETTOTALCREDITO_"+sGXsfl_35_idx;
         edtWalletTotalDebito_Internalname = "WALLETTOTALDEBITO_"+sGXsfl_35_idx;
         edtWalletSaldo_Internalname = "WALLETSALDO_"+sGXsfl_35_idx;
         edtavSaldoacreedor_Internalname = "vSALDOACREEDOR_"+sGXsfl_35_idx;
         edtavSaldodeudor_Internalname = "vSALDODEUDOR_"+sGXsfl_35_idx;
         edtWalletSolicitudesPendientes_Internalname = "WALLETSOLICITUDESPENDIENTES_"+sGXsfl_35_idx;
         edtavGridwalletnombre_Internalname = "vGRIDWALLETNOMBRE_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         cmbavActionswallet_Internalname = "vACTIONSWALLET_"+sGXsfl_35_fel_idx;
         edtavGridwalletid_Internalname = "vGRIDWALLETID_"+sGXsfl_35_fel_idx;
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA_"+sGXsfl_35_fel_idx;
         edtWalletNombre_Internalname = "WALLETNOMBRE_"+sGXsfl_35_fel_idx;
         edtWalletTotalCredito_Internalname = "WALLETTOTALCREDITO_"+sGXsfl_35_fel_idx;
         edtWalletTotalDebito_Internalname = "WALLETTOTALDEBITO_"+sGXsfl_35_fel_idx;
         edtWalletSaldo_Internalname = "WALLETSALDO_"+sGXsfl_35_fel_idx;
         edtavSaldoacreedor_Internalname = "vSALDOACREEDOR_"+sGXsfl_35_fel_idx;
         edtavSaldodeudor_Internalname = "vSALDODEUDOR_"+sGXsfl_35_fel_idx;
         edtWalletSolicitudesPendientes_Internalname = "WALLETSOLICITUDESPENDIENTES_"+sGXsfl_35_fel_idx;
         edtavGridwalletnombre_Internalname = "vGRIDWALLETNOMBRE_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WBL90( ) ;
         if ( ( subGridwallet_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGridwallet_fnc_Recordsperpage( ) * 1 ) )
         {
            GridwalletRow = GXWebRow.GetNew(context,GridwalletContainer);
            if ( subGridwallet_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridwallet_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridwallet_Class, "") != 0 )
               {
                  subGridwallet_Linesclass = subGridwallet_Class+"Odd";
               }
            }
            else if ( subGridwallet_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridwallet_Backstyle = 0;
               subGridwallet_Backcolor = subGridwallet_Allbackcolor;
               if ( StringUtil.StrCmp(subGridwallet_Class, "") != 0 )
               {
                  subGridwallet_Linesclass = subGridwallet_Class+"Uniform";
               }
            }
            else if ( subGridwallet_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridwallet_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridwallet_Class, "") != 0 )
               {
                  subGridwallet_Linesclass = subGridwallet_Class+"Odd";
               }
               subGridwallet_Backcolor = (int)(0x0);
            }
            else if ( subGridwallet_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridwallet_Backstyle = 1;
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
               {
                  subGridwallet_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridwallet_Class, "") != 0 )
                  {
                     subGridwallet_Linesclass = subGridwallet_Class+"Even";
                  }
               }
               else
               {
                  subGridwallet_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridwallet_Class, "") != 0 )
                  {
                     subGridwallet_Linesclass = subGridwallet_Class+"Odd";
                  }
               }
            }
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_35_idx + "',35)\"";
            if ( ( cmbavActionswallet.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONSWALLET_" + sGXsfl_35_idx;
               cmbavActionswallet.Name = GXCCtl;
               cmbavActionswallet.WebTags = "";
               if ( cmbavActionswallet.ItemCount > 0 )
               {
                  AV13ActionsWallet = (short)(Math.Round(NumberUtil.Val( cmbavActionswallet.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13ActionsWallet), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActionswallet_Internalname, StringUtil.LTrimStr( (decimal)(AV13ActionsWallet), 4, 0));
               }
            }
            /* ComboBox */
            GridwalletRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActionswallet,(string)cmbavActionswallet_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV13ActionsWallet), 4, 0)),(short)1,(string)cmbavActionswallet_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONSWALLET.CLICK."+sGXsfl_35_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"",(bool)true,(short)0});
            cmbavActionswallet.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13ActionsWallet), 4, 0));
            AssignProp("", false, cmbavActionswallet_Internalname, "Values", (string)(cmbavActionswallet.ToJavascriptSource()), !bGXsfl_35_Refreshing);
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridwalletid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavGridwalletid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV33GridWalletId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGridwalletid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavGridwalletid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletCodRefencia_Internalname,StringUtil.RTrim( A639WalletCodRefencia),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletCodRefencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletNombre_Internalname,StringUtil.RTrim( A715WalletNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletTotalCredito_Internalname,StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A647WalletTotalCredito, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletTotalCredito_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletTotalDebito_Internalname,StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A646WalletTotalDebito, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletTotalDebito_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletSaldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletSaldo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSaldoacreedor_Internalname,StringUtil.LTrim( StringUtil.NToC( AV86SaldoAcreedor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSaldoacreedor_Enabled!=0) ? context.localUtil.Format( AV86SaldoAcreedor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV86SaldoAcreedor, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSaldoacreedor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSaldoacreedor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSaldodeudor_Internalname,StringUtil.LTrim( StringUtil.NToC( AV87SaldoDeudor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSaldodeudor_Enabled!=0) ? context.localUtil.Format( AV87SaldoDeudor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV87SaldoDeudor, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSaldodeudor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSaldodeudor_Columnclass,(string)edtavSaldodeudor_Columnheaderclass,(short)-1,(int)edtavSaldodeudor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletSolicitudesPendientes_Internalname,StringUtil.LTrim( StringUtil.NToC( A1007WalletSolicitudesPendientes, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A1007WalletSolicitudesPendientes, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletSolicitudesPendientes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridwalletnombre_Internalname,StringUtil.RTrim( AV34GridWalletNombre),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGridwalletnombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGridwalletnombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesL92( ) ;
            GridwalletContainer.AddRow(GridwalletRow);
            nGXsfl_35_idx = ((subGridwallet_Islastpage==1)&&(nGXsfl_35_idx+1>subGridwallet_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void SubsflControlProps_1006( )
      {
         chkavIncluirbalance_Internalname = "vINCLUIRBALANCE_"+sGXsfl_100_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_100_idx;
         edtWalletBalancesId_Internalname = "WALLETBALANCESID_"+sGXsfl_100_idx;
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA_"+sGXsfl_100_idx;
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE_"+sGXsfl_100_idx;
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV_"+sGXsfl_100_idx;
         cmbWalletBalancesConcepto_Internalname = "WALLETBALANCESCONCEPTO_"+sGXsfl_100_idx;
         edtWalletBalancesObs_Internalname = "WALLETBALANCESOBS_"+sGXsfl_100_idx;
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE_"+sGXsfl_100_idx;
         edtWalletBalancesUrl_Internalname = "WALLETBALANCESURL_"+sGXsfl_100_idx;
      }

      protected void SubsflControlProps_fel_1006( )
      {
         chkavIncluirbalance_Internalname = "vINCLUIRBALANCE_"+sGXsfl_100_fel_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_100_fel_idx;
         edtWalletBalancesId_Internalname = "WALLETBALANCESID_"+sGXsfl_100_fel_idx;
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA_"+sGXsfl_100_fel_idx;
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE_"+sGXsfl_100_fel_idx;
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV_"+sGXsfl_100_fel_idx;
         cmbWalletBalancesConcepto_Internalname = "WALLETBALANCESCONCEPTO_"+sGXsfl_100_fel_idx;
         edtWalletBalancesObs_Internalname = "WALLETBALANCESOBS_"+sGXsfl_100_fel_idx;
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE_"+sGXsfl_100_fel_idx;
         edtWalletBalancesUrl_Internalname = "WALLETBALANCESURL_"+sGXsfl_100_fel_idx;
      }

      protected void sendrow_1006( )
      {
         sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
         SubsflControlProps_1006( ) ;
         WBL90( ) ;
         if ( ( subGridwalletbalances_Rows * 1 == 0 ) || ( nGXsfl_100_idx <= subGridwalletbalances_fnc_Recordsperpage( ) * 1 ) )
         {
            GridwalletbalancesRow = GXWebRow.GetNew(context,GridwalletbalancesContainer);
            if ( subGridwalletbalances_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridwalletbalances_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridwalletbalances_Class, "") != 0 )
               {
                  subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Odd";
               }
            }
            else if ( subGridwalletbalances_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridwalletbalances_Backstyle = 0;
               subGridwalletbalances_Backcolor = subGridwalletbalances_Allbackcolor;
               if ( StringUtil.StrCmp(subGridwalletbalances_Class, "") != 0 )
               {
                  subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Uniform";
               }
            }
            else if ( subGridwalletbalances_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridwalletbalances_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridwalletbalances_Class, "") != 0 )
               {
                  subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Odd";
               }
               subGridwalletbalances_Backcolor = (int)(0x0);
            }
            else if ( subGridwalletbalances_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridwalletbalances_Backstyle = 1;
               if ( ((int)((nGXsfl_100_idx) % (2))) == 0 )
               {
                  subGridwalletbalances_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridwalletbalances_Class, "") != 0 )
                  {
                     subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Even";
                  }
               }
               else
               {
                  subGridwalletbalances_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridwalletbalances_Class, "") != 0 )
                  {
                     subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Odd";
                  }
               }
            }
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_100_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_100_idx + "',100)\"";
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vINCLUIRBALANCE_" + sGXsfl_100_idx;
            chkavIncluirbalance.Name = GXCCtl;
            chkavIncluirbalance.WebTags = "";
            chkavIncluirbalance.Caption = "";
            AssignProp("", false, chkavIncluirbalance_Internalname, "TitleCaption", chkavIncluirbalance.Caption, !bGXsfl_100_Refreshing);
            chkavIncluirbalance.CheckedValue = "false";
            AV37IncluirBalance = StringUtil.StrToBool( StringUtil.BoolToStr( AV37IncluirBalance));
            AssignAttri("", false, chkavIncluirbalance_Internalname, AV37IncluirBalance);
            GridwalletbalancesRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIncluirbalance_Internalname,StringUtil.BoolToStr( AV37IncluirBalance),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(101, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,101);\""});
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletbalancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletbalancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletbalancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesFechaAlta_Internalname,context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A641WalletBalancesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletbalancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesImporte_Internalname,StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesImporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWalletBalancesTipoMov.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETBALANCESTIPOMOV_" + sGXsfl_100_idx;
               cmbWalletBalancesTipoMov.Name = GXCCtl;
               cmbWalletBalancesTipoMov.WebTags = "";
               cmbWalletBalancesTipoMov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
               cmbWalletBalancesTipoMov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
               if ( cmbWalletBalancesTipoMov.ItemCount > 0 )
               {
                  A643WalletBalancesTipoMov = cmbWalletBalancesTipoMov.getValidValue(A643WalletBalancesTipoMov);
               }
            }
            /* ComboBox */
            GridwalletbalancesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesTipoMov,(string)cmbWalletBalancesTipoMov_Internalname,StringUtil.RTrim( A643WalletBalancesTipoMov),(short)1,(string)cmbWalletBalancesTipoMov_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletBalancesTipoMov.CurrentValue = StringUtil.RTrim( A643WalletBalancesTipoMov);
            AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Values", (string)(cmbWalletBalancesTipoMov.ToJavascriptSource()), !bGXsfl_100_Refreshing);
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWalletBalancesConcepto.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETBALANCESCONCEPTO_" + sGXsfl_100_idx;
               cmbWalletBalancesConcepto.Name = GXCCtl;
               cmbWalletBalancesConcepto.WebTags = "";
               cmbWalletBalancesConcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
               cmbWalletBalancesConcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
               cmbWalletBalancesConcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
               cmbWalletBalancesConcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
               cmbWalletBalancesConcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
               cmbWalletBalancesConcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
               if ( cmbWalletBalancesConcepto.ItemCount > 0 )
               {
                  A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbWalletBalancesConcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  n1010WalletBalancesConcepto = false;
               }
            }
            /* ComboBox */
            GridwalletbalancesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesConcepto,(string)cmbWalletBalancesConcepto_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0)),(short)1,(string)cmbWalletBalancesConcepto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletBalancesConcepto.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0));
            AssignProp("", false, cmbWalletBalancesConcepto_Internalname, "Values", (string)(cmbWalletBalancesConcepto.ToJavascriptSource()), !bGXsfl_100_Refreshing);
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletbalancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesObs_Internalname,(string)A1009WalletBalancesObs,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesObs_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWalletBalancesEstadoOPE.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETBALANCESESTADOOPE_" + sGXsfl_100_idx;
               cmbWalletBalancesEstadoOPE.Name = GXCCtl;
               cmbWalletBalancesEstadoOPE.WebTags = "";
               cmbWalletBalancesEstadoOPE.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbWalletBalancesEstadoOPE.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbWalletBalancesEstadoOPE.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbWalletBalancesEstadoOPE.ItemCount > 0 )
               {
                  A645WalletBalancesEstadoOPE = cmbWalletBalancesEstadoOPE.getValidValue(A645WalletBalancesEstadoOPE);
               }
            }
            /* ComboBox */
            GridwalletbalancesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesEstadoOPE,(string)cmbWalletBalancesEstadoOPE_Internalname,StringUtil.RTrim( A645WalletBalancesEstadoOPE),(short)1,(string)cmbWalletBalancesEstadoOPE_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletBalancesEstadoOPE.CurrentValue = StringUtil.RTrim( A645WalletBalancesEstadoOPE);
            AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Values", (string)(cmbWalletBalancesEstadoOPE.ToJavascriptSource()), !bGXsfl_100_Refreshing);
            /* Subfile cell */
            if ( GridwalletbalancesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridwalletbalancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesUrl_Internalname,(string)A1011WalletBalancesUrl,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWalletBalancesUrl_Link,(string)edtWalletBalancesUrl_Linktarget,(string)"",(string)"",(string)edtWalletBalancesUrl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)100,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesL96( ) ;
            GridwalletbalancesContainer.AddRow(GridwalletbalancesRow);
            nGXsfl_100_idx = ((subGridwalletbalances_Islastpage==1)&&(nGXsfl_100_idx+1>subGridwalletbalances_fnc_Recordsperpage( )) ? 1 : nGXsfl_100_idx+1);
            sGXsfl_100_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_100_idx), 4, 0), 4, "0");
            SubsflControlProps_1006( ) ;
         }
         /* End function sendrow_1006 */
      }

      protected void SubsflControlProps_1185( )
      {
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_118_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_118_idx;
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION_"+sGXsfl_118_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_118_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_118_idx;
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO_"+sGXsfl_118_idx;
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM_"+sGXsfl_118_idx;
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO_"+sGXsfl_118_idx;
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM_"+sGXsfl_118_idx;
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF_"+sGXsfl_118_idx;
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL_"+sGXsfl_118_idx;
      }

      protected void SubsflControlProps_fel_1185( )
      {
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_118_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_118_fel_idx;
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION_"+sGXsfl_118_fel_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_118_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_118_fel_idx;
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO_"+sGXsfl_118_fel_idx;
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM_"+sGXsfl_118_fel_idx;
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO_"+sGXsfl_118_fel_idx;
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM_"+sGXsfl_118_fel_idx;
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF_"+sGXsfl_118_fel_idx;
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL_"+sGXsfl_118_fel_idx;
      }

      protected void sendrow_1185( )
      {
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1185( ) ;
         WBL90( ) ;
         if ( ( subGridprevia_Rows * 1 == 0 ) || ( nGXsfl_118_idx - GRIDPREVIA_nFirstRecordOnPage <= subGridprevia_fnc_Recordsperpage( ) * 1 ) )
         {
            GridpreviaRow = GXWebRow.GetNew(context,GridpreviaContainer);
            if ( subGridprevia_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridprevia_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridprevia_Class, "") != 0 )
               {
                  subGridprevia_Linesclass = subGridprevia_Class+"Odd";
               }
            }
            else if ( subGridprevia_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridprevia_Backstyle = 0;
               subGridprevia_Backcolor = subGridprevia_Allbackcolor;
               if ( StringUtil.StrCmp(subGridprevia_Class, "") != 0 )
               {
                  subGridprevia_Linesclass = subGridprevia_Class+"Uniform";
               }
            }
            else if ( subGridprevia_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridprevia_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridprevia_Class, "") != 0 )
               {
                  subGridprevia_Linesclass = subGridprevia_Class+"Odd";
               }
               subGridprevia_Backcolor = (int)(0x0);
            }
            else if ( subGridprevia_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridprevia_Backstyle = 1;
               if ( ((int)((nGXsfl_118_idx) % (2))) == 0 )
               {
                  subGridprevia_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridprevia_Class, "") != 0 )
                  {
                     subGridprevia_Linesclass = subGridprevia_Class+"Even";
                  }
               }
               else
               {
                  subGridprevia_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridprevia_Class, "") != 0 )
                  {
                     subGridprevia_Linesclass = subGridprevia_Class+"Odd";
                  }
               }
            }
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_118_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)false,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesFechaInstalacion_Internalname,context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"),context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesFechaInstalacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "SOLICITUDSERVICIOORIGENPAGO_" + sGXsfl_118_idx;
            cmbSolicitudServicioOrigenPago.Name = GXCCtl;
            cmbSolicitudServicioOrigenPago.WebTags = "";
            cmbSolicitudServicioOrigenPago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
            cmbSolicitudServicioOrigenPago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
            cmbSolicitudServicioOrigenPago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
            if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
            {
               A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
               n438SolicitudServicioOrigenPago = false;
            }
            /* ComboBox */
            GridpreviaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudServicioOrigenPago,(string)cmbSolicitudServicioOrigenPago_Internalname,StringUtil.RTrim( A438SolicitudServicioOrigenPago),(short)1,(string)cmbSolicitudServicioOrigenPago_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)false,(short)0});
            cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
            AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Values", (string)(cmbSolicitudServicioOrigenPago.ToJavascriptSource()), !bGXsfl_118_Refreshing);
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComALM_Internalname,StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComALM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComPro_Internalname,StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComPro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZComAlm_Internalname,StringUtil.LTrim( StringUtil.NToC( A865SolicitudesCostoXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A865SolicitudesCostoXZComAlm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZComAlm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZComProf_Internalname,StringUtil.LTrim( StringUtil.NToC( A867SolicitudesCostoXZComProf, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A867SolicitudesCostoXZComProf, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZComProf_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpreviaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpreviaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioPFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioPFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)false,(string)"Precio",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesL95( ) ;
            GridpreviaContainer.AddRow(GridpreviaRow);
            nGXsfl_118_idx = ((subGridprevia_Islastpage==1)&&(nGXsfl_118_idx+1>subGridprevia_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1185( ) ;
         }
         /* End function sendrow_1185 */
      }

      protected void SubsflControlProps_1404( )
      {
         cmbavActions_Internalname = "vACTIONS_"+sGXsfl_140_idx;
         edtavWalletbalancesid_Internalname = "vWALLETBALANCESID_"+sGXsfl_140_idx;
         edtavWalletbalancesfechaalta_Internalname = "vWALLETBALANCESFECHAALTA_"+sGXsfl_140_idx;
         edtavWalletbalancesimporte_Internalname = "vWALLETBALANCESIMPORTE_"+sGXsfl_140_idx;
         cmbavWalletbalancestipomov_Internalname = "vWALLETBALANCESTIPOMOV_"+sGXsfl_140_idx;
         cmbavWalletbalancesconcepto_Internalname = "vWALLETBALANCESCONCEPTO_"+sGXsfl_140_idx;
         edtavWalletbalancesobs_Internalname = "vWALLETBALANCESOBS_"+sGXsfl_140_idx;
         edtavWalletbalancesopeid_Internalname = "vWALLETBALANCESOPEID_"+sGXsfl_140_idx;
         cmbavWalletbalancesestadoope_Internalname = "vWALLETBALANCESESTADOOPE_"+sGXsfl_140_idx;
      }

      protected void SubsflControlProps_fel_1404( )
      {
         cmbavActions_Internalname = "vACTIONS_"+sGXsfl_140_fel_idx;
         edtavWalletbalancesid_Internalname = "vWALLETBALANCESID_"+sGXsfl_140_fel_idx;
         edtavWalletbalancesfechaalta_Internalname = "vWALLETBALANCESFECHAALTA_"+sGXsfl_140_fel_idx;
         edtavWalletbalancesimporte_Internalname = "vWALLETBALANCESIMPORTE_"+sGXsfl_140_fel_idx;
         cmbavWalletbalancestipomov_Internalname = "vWALLETBALANCESTIPOMOV_"+sGXsfl_140_fel_idx;
         cmbavWalletbalancesconcepto_Internalname = "vWALLETBALANCESCONCEPTO_"+sGXsfl_140_fel_idx;
         edtavWalletbalancesobs_Internalname = "vWALLETBALANCESOBS_"+sGXsfl_140_fel_idx;
         edtavWalletbalancesopeid_Internalname = "vWALLETBALANCESOPEID_"+sGXsfl_140_fel_idx;
         cmbavWalletbalancesestadoope_Internalname = "vWALLETBALANCESESTADOOPE_"+sGXsfl_140_fel_idx;
      }

      protected void sendrow_1404( )
      {
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1404( ) ;
         WBL90( ) ;
         if ( ( subGridhistorial_Rows * 1 == 0 ) || ( nGXsfl_140_idx <= subGridhistorial_fnc_Recordsperpage( ) * 1 ) )
         {
            GridhistorialRow = GXWebRow.GetNew(context,GridhistorialContainer);
            if ( subGridhistorial_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridhistorial_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridhistorial_Class, "") != 0 )
               {
                  subGridhistorial_Linesclass = subGridhistorial_Class+"Odd";
               }
            }
            else if ( subGridhistorial_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridhistorial_Backstyle = 0;
               subGridhistorial_Backcolor = subGridhistorial_Allbackcolor;
               if ( StringUtil.StrCmp(subGridhistorial_Class, "") != 0 )
               {
                  subGridhistorial_Linesclass = subGridhistorial_Class+"Uniform";
               }
            }
            else if ( subGridhistorial_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridhistorial_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridhistorial_Class, "") != 0 )
               {
                  subGridhistorial_Linesclass = subGridhistorial_Class+"Odd";
               }
               subGridhistorial_Backcolor = (int)(0x0);
            }
            else if ( subGridhistorial_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridhistorial_Backstyle = 1;
               if ( ((int)((nGXsfl_140_idx) % (2))) == 0 )
               {
                  subGridhistorial_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridhistorial_Class, "") != 0 )
                  {
                     subGridhistorial_Linesclass = subGridhistorial_Class+"Even";
                  }
               }
               else
               {
                  subGridhistorial_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridhistorial_Class, "") != 0 )
                  {
                     subGridhistorial_Linesclass = subGridhistorial_Class+"Odd";
                  }
               }
            }
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_140_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_140_idx + "',140)\"";
            if ( ( cmbavActions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONS_" + sGXsfl_140_idx;
               cmbavActions.Name = GXCCtl;
               cmbavActions.WebTags = "";
               if ( cmbavActions.ItemCount > 0 )
               {
                  AV12Actions = (short)(Math.Round(NumberUtil.Val( cmbavActions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Actions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActions_Internalname, StringUtil.LTrimStr( (decimal)(AV12Actions), 4, 0));
               }
            }
            /* ComboBox */
            GridhistorialRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActions,(string)cmbavActions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV12Actions), 4, 0)),(short)1,(string)cmbavActions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONS.CLICK."+sGXsfl_140_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"",(string)"",(bool)true,(short)0});
            cmbavActions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Actions), 4, 0));
            AssignProp("", false, cmbavActions_Internalname, "Values", (string)(cmbavActions.ToJavascriptSource()), !bGXsfl_140_Refreshing);
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            GridhistorialRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWalletbalancesid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWalletbalancesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV51WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV51WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,142);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWalletbalancesid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWalletbalancesid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            GridhistorialRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWalletbalancesfechaalta_Internalname,context.localUtil.TToC( AV50WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( AV50WalletBalancesFechaAlta, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,143);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWalletbalancesfechaalta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWalletbalancesfechaalta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            GridhistorialRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWalletbalancesimporte_Internalname,StringUtil.LTrim( StringUtil.NToC( AV52WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWalletbalancesimporte_Enabled!=0) ? context.localUtil.Format( AV52WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV52WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,144);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWalletbalancesimporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWalletbalancesimporte_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_140_idx + "',140)\"";
            if ( ( cmbavWalletbalancestipomov.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vWALLETBALANCESTIPOMOV_" + sGXsfl_140_idx;
               cmbavWalletbalancestipomov.Name = GXCCtl;
               cmbavWalletbalancestipomov.WebTags = "";
               cmbavWalletbalancestipomov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
               cmbavWalletbalancestipomov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
               if ( cmbavWalletbalancestipomov.ItemCount > 0 )
               {
                  AV54WalletBalancesTipoMov = cmbavWalletbalancestipomov.getValidValue(AV54WalletBalancesTipoMov);
                  AssignAttri("", false, cmbavWalletbalancestipomov_Internalname, AV54WalletBalancesTipoMov);
               }
            }
            /* ComboBox */
            GridhistorialRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavWalletbalancestipomov,(string)cmbavWalletbalancestipomov_Internalname,StringUtil.RTrim( AV54WalletBalancesTipoMov),(short)1,(string)cmbavWalletbalancestipomov_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavWalletbalancestipomov.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"",(string)"",(bool)true,(short)0});
            cmbavWalletbalancestipomov.CurrentValue = StringUtil.RTrim( AV54WalletBalancesTipoMov);
            AssignProp("", false, cmbavWalletbalancestipomov_Internalname, "Values", (string)(cmbavWalletbalancestipomov.ToJavascriptSource()), !bGXsfl_140_Refreshing);
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_140_idx + "',140)\"";
            if ( ( cmbavWalletbalancesconcepto.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vWALLETBALANCESCONCEPTO_" + sGXsfl_140_idx;
               cmbavWalletbalancesconcepto.Name = GXCCtl;
               cmbavWalletbalancesconcepto.WebTags = "";
               cmbavWalletbalancesconcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
               cmbavWalletbalancesconcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
               cmbavWalletbalancesconcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
               cmbavWalletbalancesconcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
               cmbavWalletbalancesconcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
               cmbavWalletbalancesconcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
               if ( cmbavWalletbalancesconcepto.ItemCount > 0 )
               {
                  AV49WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbavWalletbalancesconcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavWalletbalancesconcepto_Internalname, StringUtil.LTrimStr( (decimal)(AV49WalletBalancesConcepto), 4, 0));
               }
            }
            /* ComboBox */
            GridhistorialRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavWalletbalancesconcepto,(string)cmbavWalletbalancesconcepto_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV49WalletBalancesConcepto), 4, 0)),(short)1,(string)cmbavWalletbalancesconcepto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbavWalletbalancesconcepto.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"",(string)"",(bool)true,(short)0});
            cmbavWalletbalancesconcepto.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49WalletBalancesConcepto), 4, 0));
            AssignProp("", false, cmbavWalletbalancesconcepto_Internalname, "Values", (string)(cmbavWalletbalancesconcepto.ToJavascriptSource()), !bGXsfl_140_Refreshing);
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            GridhistorialRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWalletbalancesobs_Internalname,(string)AV53WalletBalancesObs,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWalletbalancesobs_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWalletbalancesobs_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridhistorialRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWalletbalancesopeid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10WalletBalancesOpeId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWalletbalancesopeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10WalletBalancesOpeId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10WalletBalancesOpeId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWalletbalancesopeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWalletbalancesopeid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridhistorialContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavWalletbalancesestadoope.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vWALLETBALANCESESTADOOPE_" + sGXsfl_140_idx;
               cmbavWalletbalancesestadoope.Name = GXCCtl;
               cmbavWalletbalancesestadoope.WebTags = "";
               cmbavWalletbalancesestadoope.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbavWalletbalancesestadoope.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbavWalletbalancesestadoope.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbavWalletbalancesestadoope.ItemCount > 0 )
               {
                  AV80WalletBalancesEstadoOPE = cmbavWalletbalancesestadoope.getValidValue(AV80WalletBalancesEstadoOPE);
                  AssignAttri("", false, cmbavWalletbalancesestadoope_Internalname, AV80WalletBalancesEstadoOPE);
               }
            }
            /* ComboBox */
            GridhistorialRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavWalletbalancesestadoope,(string)cmbavWalletbalancesestadoope_Internalname,StringUtil.RTrim( AV80WalletBalancesEstadoOPE),(short)1,(string)cmbavWalletbalancesestadoope_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavWalletbalancesestadoope.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavWalletbalancesestadoope.CurrentValue = StringUtil.RTrim( AV80WalletBalancesEstadoOPE);
            AssignProp("", false, cmbavWalletbalancesestadoope_Internalname, "Values", (string)(cmbavWalletbalancesestadoope.ToJavascriptSource()), !bGXsfl_140_Refreshing);
            send_integrity_lvl_hashesL94( ) ;
            GridhistorialContainer.AddRow(GridhistorialRow);
            nGXsfl_140_idx = ((subGridhistorial_Islastpage==1)&&(nGXsfl_140_idx+1>subGridhistorial_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1404( ) ;
         }
         /* End function sendrow_1404 */
      }

      protected void init_web_controls( )
      {
         chkavTodoslosprofesionales.Name = "vTODOSLOSPROFESIONALES";
         chkavTodoslosprofesionales.WebTags = "";
         chkavTodoslosprofesionales.Caption = "";
         AssignProp("", false, chkavTodoslosprofesionales_Internalname, "TitleCaption", chkavTodoslosprofesionales.Caption, true);
         chkavTodoslosprofesionales.CheckedValue = "false";
         AV44TodosLosProfesionales = StringUtil.StrToBool( StringUtil.BoolToStr( AV44TodosLosProfesionales));
         AssignAttri("", false, "AV44TodosLosProfesionales", AV44TodosLosProfesionales);
         GXCCtl = "vACTIONSWALLET_" + sGXsfl_35_idx;
         cmbavActionswallet.Name = GXCCtl;
         cmbavActionswallet.WebTags = "";
         if ( cmbavActionswallet.ItemCount > 0 )
         {
            AV13ActionsWallet = (short)(Math.Round(NumberUtil.Val( cmbavActionswallet.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13ActionsWallet), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActionswallet_Internalname, StringUtil.LTrimStr( (decimal)(AV13ActionsWallet), 4, 0));
         }
         cmbavOperacionesperiodocod.Name = "vOPERACIONESPERIODOCOD";
         cmbavOperacionesperiodocod.WebTags = "";
         if ( cmbavOperacionesperiodocod.ItemCount > 0 )
         {
            AV59OperacionesPeriodoCod = cmbavOperacionesperiodocod.getValidValue(AV59OperacionesPeriodoCod);
            AssignAttri("", false, "AV59OperacionesPeriodoCod", AV59OperacionesPeriodoCod);
         }
         GXCCtl = "vINCLUIRBALANCE_" + sGXsfl_100_idx;
         chkavIncluirbalance.Name = GXCCtl;
         chkavIncluirbalance.WebTags = "";
         chkavIncluirbalance.Caption = "";
         AssignProp("", false, chkavIncluirbalance_Internalname, "TitleCaption", chkavIncluirbalance.Caption, !bGXsfl_100_Refreshing);
         chkavIncluirbalance.CheckedValue = "false";
         AV37IncluirBalance = StringUtil.StrToBool( StringUtil.BoolToStr( AV37IncluirBalance));
         AssignAttri("", false, chkavIncluirbalance_Internalname, AV37IncluirBalance);
         GXCCtl = "WALLETBALANCESTIPOMOV_" + sGXsfl_100_idx;
         cmbWalletBalancesTipoMov.Name = GXCCtl;
         cmbWalletBalancesTipoMov.WebTags = "";
         cmbWalletBalancesTipoMov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
         cmbWalletBalancesTipoMov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
         if ( cmbWalletBalancesTipoMov.ItemCount > 0 )
         {
            A643WalletBalancesTipoMov = cmbWalletBalancesTipoMov.getValidValue(A643WalletBalancesTipoMov);
         }
         GXCCtl = "WALLETBALANCESCONCEPTO_" + sGXsfl_100_idx;
         cmbWalletBalancesConcepto.Name = GXCCtl;
         cmbWalletBalancesConcepto.WebTags = "";
         cmbWalletBalancesConcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
         cmbWalletBalancesConcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
         cmbWalletBalancesConcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
         cmbWalletBalancesConcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
         cmbWalletBalancesConcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
         cmbWalletBalancesConcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
         if ( cmbWalletBalancesConcepto.ItemCount > 0 )
         {
            A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbWalletBalancesConcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n1010WalletBalancesConcepto = false;
         }
         GXCCtl = "WALLETBALANCESESTADOOPE_" + sGXsfl_100_idx;
         cmbWalletBalancesEstadoOPE.Name = GXCCtl;
         cmbWalletBalancesEstadoOPE.WebTags = "";
         cmbWalletBalancesEstadoOPE.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbWalletBalancesEstadoOPE.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbWalletBalancesEstadoOPE.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbWalletBalancesEstadoOPE.ItemCount > 0 )
         {
            A645WalletBalancesEstadoOPE = cmbWalletBalancesEstadoOPE.getValidValue(A645WalletBalancesEstadoOPE);
         }
         GXCCtl = "SOLICITUDSERVICIOORIGENPAGO_" + sGXsfl_118_idx;
         cmbSolicitudServicioOrigenPago.Name = GXCCtl;
         cmbSolicitudServicioOrigenPago.WebTags = "";
         cmbSolicitudServicioOrigenPago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
         {
            A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
            n438SolicitudServicioOrigenPago = false;
         }
         GXCCtl = "vACTIONS_" + sGXsfl_140_idx;
         cmbavActions.Name = GXCCtl;
         cmbavActions.WebTags = "";
         if ( cmbavActions.ItemCount > 0 )
         {
            AV12Actions = (short)(Math.Round(NumberUtil.Val( cmbavActions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Actions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActions_Internalname, StringUtil.LTrimStr( (decimal)(AV12Actions), 4, 0));
         }
         GXCCtl = "vWALLETBALANCESTIPOMOV_" + sGXsfl_140_idx;
         cmbavWalletbalancestipomov.Name = GXCCtl;
         cmbavWalletbalancestipomov.WebTags = "";
         cmbavWalletbalancestipomov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
         cmbavWalletbalancestipomov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
         if ( cmbavWalletbalancestipomov.ItemCount > 0 )
         {
            AV54WalletBalancesTipoMov = cmbavWalletbalancestipomov.getValidValue(AV54WalletBalancesTipoMov);
            AssignAttri("", false, cmbavWalletbalancestipomov_Internalname, AV54WalletBalancesTipoMov);
         }
         GXCCtl = "vWALLETBALANCESCONCEPTO_" + sGXsfl_140_idx;
         cmbavWalletbalancesconcepto.Name = GXCCtl;
         cmbavWalletbalancesconcepto.WebTags = "";
         cmbavWalletbalancesconcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
         cmbavWalletbalancesconcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
         cmbavWalletbalancesconcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
         cmbavWalletbalancesconcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
         cmbavWalletbalancesconcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
         cmbavWalletbalancesconcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
         if ( cmbavWalletbalancesconcepto.ItemCount > 0 )
         {
            AV49WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbavWalletbalancesconcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavWalletbalancesconcepto_Internalname, StringUtil.LTrimStr( (decimal)(AV49WalletBalancesConcepto), 4, 0));
         }
         GXCCtl = "vWALLETBALANCESESTADOOPE_" + sGXsfl_140_idx;
         cmbavWalletbalancesestadoope.Name = GXCCtl;
         cmbavWalletbalancesestadoope.WebTags = "";
         cmbavWalletbalancesestadoope.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbavWalletbalancesestadoope.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbavWalletbalancesestadoope.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbavWalletbalancesestadoope.ItemCount > 0 )
         {
            AV80WalletBalancesEstadoOPE = cmbavWalletbalancesestadoope.getValidValue(AV80WalletBalancesEstadoOPE);
            AssignAttri("", false, cmbavWalletbalancesestadoope_Internalname, AV80WalletBalancesEstadoOPE);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridwalletContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridwalletContainer"+"DivS\" data-gxgridid=\"35\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridwallet_Internalname, subGridwallet_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridwallet_Backcolorstyle == 0 )
            {
               subGridwallet_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridwallet_Class) > 0 )
               {
                  subGridwallet_Linesclass = subGridwallet_Class+"Title";
               }
            }
            else
            {
               subGridwallet_Titlebackstyle = 1;
               if ( subGridwallet_Backcolorstyle == 1 )
               {
                  subGridwallet_Titlebackcolor = subGridwallet_Allbackcolor;
                  if ( StringUtil.Len( subGridwallet_Class) > 0 )
                  {
                     subGridwallet_Linesclass = subGridwallet_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridwallet_Class) > 0 )
                  {
                     subGridwallet_Linesclass = subGridwallet_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nro Cuenta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Profesional", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total Credito", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total Debito", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Saldo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Saldo Acreedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Saldo Deudor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Saldo Corriente", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridwalletContainer.AddObjectProperty("GridName", "Gridwallet");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridwalletContainer = new GXWebGrid( context);
            }
            else
            {
               GridwalletContainer.Clear();
            }
            GridwalletContainer.SetWrapped(nGXWrapped);
            GridwalletContainer.AddObjectProperty("GridName", "Gridwallet");
            GridwalletContainer.AddObjectProperty("Header", subGridwallet_Header);
            GridwalletContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridwalletContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Backcolorstyle), 1, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("CmpContext", "");
            GridwalletContainer.AddObjectProperty("InMasterPage", "false");
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ActionsWallet), 4, 0, ".", ""))));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridWalletId), 18, 0, ".", ""))));
            GridwalletColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridwalletid_Enabled), 5, 0, ".", "")));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A639WalletCodRefencia)));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A715WalletNombre)));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, ".", ""))));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, ".", ""))));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, ".", ""))));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV86SaldoAcreedor, 18, 2, ".", ""))));
            GridwalletColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSaldoacreedor_Enabled), 5, 0, ".", "")));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV87SaldoDeudor, 18, 2, ".", ""))));
            GridwalletColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSaldodeudor_Columnclass));
            GridwalletColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSaldodeudor_Columnheaderclass));
            GridwalletColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSaldodeudor_Enabled), 5, 0, ".", "")));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1007WalletSolicitudesPendientes, 18, 2, ".", ""))));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34GridWalletNombre)));
            GridwalletColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridwalletnombre_Enabled), 5, 0, ".", "")));
            GridwalletContainer.AddColumnProperties(GridwalletColumn);
            GridwalletContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Selectedindex), 4, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Allowselection), 1, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Selectioncolor), 9, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Allowhovering), 1, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Hoveringcolor), 9, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Allowcollapsing), 1, 0, ".", "")));
            GridwalletContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwallet_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl100( )
      {
         if ( GridwalletbalancesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridwalletbalancesContainer"+"DivS\" data-gxgridid=\"100\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridwalletbalances_Internalname, subGridwalletbalances_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridwalletbalances_Backcolorstyle == 0 )
            {
               subGridwalletbalances_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridwalletbalances_Class) > 0 )
               {
                  subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Title";
               }
            }
            else
            {
               subGridwalletbalances_Titlebackstyle = 1;
               if ( subGridwalletbalances_Backcolorstyle == 1 )
               {
                  subGridwalletbalances_Titlebackcolor = subGridwalletbalances_Allbackcolor;
                  if ( StringUtil.Len( subGridwalletbalances_Class) > 0 )
                  {
                     subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridwalletbalances_Class) > 0 )
                  {
                     subGridwalletbalances_Linesclass = subGridwalletbalances_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Incluir", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Wallet Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Operación Nro.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Importe", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Concepto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Observacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "URL", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridwalletbalancesContainer.AddObjectProperty("GridName", "Gridwalletbalances");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridwalletbalancesContainer = new GXWebGrid( context);
            }
            else
            {
               GridwalletbalancesContainer.Clear();
            }
            GridwalletbalancesContainer.SetWrapped(nGXWrapped);
            GridwalletbalancesContainer.AddObjectProperty("GridName", "Gridwalletbalances");
            GridwalletbalancesContainer.AddObjectProperty("Header", subGridwalletbalances_Header);
            GridwalletbalancesContainer.AddObjectProperty("Class", "WorkWith");
            GridwalletbalancesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Backcolorstyle), 1, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("CmpContext", "");
            GridwalletbalancesContainer.AddObjectProperty("InMasterPage", "false");
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV37IncluirBalance)));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", ""))));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, ".", ""))));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, ".", ""))));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A643WalletBalancesTipoMov)));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010WalletBalancesConcepto), 4, 0, ".", ""))));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1009WalletBalancesObs));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A645WalletBalancesEstadoOPE)));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridwalletbalancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1011WalletBalancesUrl));
            GridwalletbalancesColumn.AddObjectProperty("Link", StringUtil.RTrim( edtWalletBalancesUrl_Link));
            GridwalletbalancesColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtWalletBalancesUrl_Linktarget));
            GridwalletbalancesContainer.AddColumnProperties(GridwalletbalancesColumn);
            GridwalletbalancesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Selectedindex), 4, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Allowselection), 1, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Selectioncolor), 9, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Allowhovering), 1, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Hoveringcolor), 9, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Allowcollapsing), 1, 0, ".", "")));
            GridwalletbalancesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwalletbalances_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl118( )
      {
         if ( GridpreviaContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridpreviaContainer"+"DivS\" data-gxgridid=\"118\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridprevia_Internalname, subGridprevia_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridprevia_Backcolorstyle == 0 )
            {
               subGridprevia_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridprevia_Class) > 0 )
               {
                  subGridprevia_Linesclass = subGridprevia_Class+"Title";
               }
            }
            else
            {
               subGridprevia_Titlebackstyle = 1;
               if ( subGridprevia_Backcolorstyle == 1 )
               {
                  subGridprevia_Titlebackcolor = subGridprevia_Allbackcolor;
                  if ( StringUtil.Len( subGridprevia_Class) > 0 )
                  {
                     subGridprevia_Linesclass = subGridprevia_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridprevia_Class) > 0 )
                  {
                     subGridprevia_Linesclass = subGridprevia_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de instalación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen del Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión Almango", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión Profesional", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Com. Amg-Zona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Com. Prof-Zona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridpreviaContainer.AddObjectProperty("GridName", "Gridprevia");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridpreviaContainer = new GXWebGrid( context);
            }
            else
            {
               GridpreviaContainer.Clear();
            }
            GridpreviaContainer.SetWrapped(nGXWrapped);
            GridpreviaContainer.AddObjectProperty("GridName", "Gridprevia");
            GridpreviaContainer.AddObjectProperty("Header", subGridprevia_Header);
            GridpreviaContainer.AddObjectProperty("Class", "WorkWith");
            GridpreviaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Backcolorstyle), 1, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("CmpContext", "");
            GridpreviaContainer.AddObjectProperty("InMasterPage", "false");
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99")));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A438SolicitudServicioOrigenPago)));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A865SolicitudesCostoXZComAlm, 18, 2, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A867SolicitudesCostoXZComProf, 18, 2, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpreviaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, ".", ""))));
            GridpreviaContainer.AddColumnProperties(GridpreviaColumn);
            GridpreviaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Selectedindex), 4, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Allowselection), 1, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Selectioncolor), 9, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Allowhovering), 1, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Hoveringcolor), 9, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Allowcollapsing), 1, 0, ".", "")));
            GridpreviaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprevia_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl140( )
      {
         if ( GridhistorialContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridhistorialContainer"+"DivS\" data-gxgridid=\"140\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridhistorial_Internalname, subGridhistorial_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridhistorial_Backcolorstyle == 0 )
            {
               subGridhistorial_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridhistorial_Class) > 0 )
               {
                  subGridhistorial_Linesclass = subGridhistorial_Class+"Title";
               }
            }
            else
            {
               subGridhistorial_Titlebackstyle = 1;
               if ( subGridhistorial_Backcolorstyle == 1 )
               {
                  subGridhistorial_Titlebackcolor = subGridhistorial_Allbackcolor;
                  if ( StringUtil.Len( subGridhistorial_Class) > 0 )
                  {
                     subGridhistorial_Linesclass = subGridhistorial_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridhistorial_Class) > 0 )
                  {
                     subGridhistorial_Linesclass = subGridhistorial_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Importe", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Movimiento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Concepto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Observacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Wallet Balance Liquidacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridhistorialContainer.AddObjectProperty("GridName", "Gridhistorial");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridhistorialContainer = new GXWebGrid( context);
            }
            else
            {
               GridhistorialContainer.Clear();
            }
            GridhistorialContainer.SetWrapped(nGXWrapped);
            GridhistorialContainer.AddObjectProperty("GridName", "Gridhistorial");
            GridhistorialContainer.AddObjectProperty("Header", subGridhistorial_Header);
            GridhistorialContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridhistorialContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Backcolorstyle), 1, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("CmpContext", "");
            GridhistorialContainer.AddObjectProperty("InMasterPage", "false");
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Actions), 4, 0, ".", ""))));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51WalletBalancesId), 18, 0, ".", ""))));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWalletbalancesid_Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( AV50WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWalletbalancesfechaalta_Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV52WalletBalancesImporte, 18, 2, ".", ""))));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWalletbalancesimporte_Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV54WalletBalancesTipoMov)));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavWalletbalancestipomov.Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49WalletBalancesConcepto), 4, 0, ".", ""))));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavWalletbalancesconcepto.Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV53WalletBalancesObs));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWalletbalancesobs_Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10WalletBalancesOpeId), 18, 0, ".", ""))));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWalletbalancesopeid_Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhistorialColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV80WalletBalancesEstadoOPE)));
            GridhistorialColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavWalletbalancesestadoope.Enabled), 5, 0, ".", "")));
            GridhistorialContainer.AddColumnProperties(GridhistorialColumn);
            GridhistorialContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Selectedindex), 4, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Allowselection), 1, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Selectioncolor), 9, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Allowhovering), 1, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Hoveringcolor), 9, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Allowcollapsing), 1, 0, ".", "")));
            GridhistorialContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhistorial_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnactioncrearwallets_Internalname = "BTNACTIONCREARWALLETS";
         chkavTodoslosprofesionales_Internalname = "vTODOSLOSPROFESIONALES";
         edtavBuscarcuenta_Internalname = "vBUSCARCUENTA";
         cmbavActionswallet_Internalname = "vACTIONSWALLET";
         edtavGridwalletid_Internalname = "vGRIDWALLETID";
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA";
         edtWalletNombre_Internalname = "WALLETNOMBRE";
         edtWalletTotalCredito_Internalname = "WALLETTOTALCREDITO";
         edtWalletTotalDebito_Internalname = "WALLETTOTALDEBITO";
         edtWalletSaldo_Internalname = "WALLETSALDO";
         edtavSaldoacreedor_Internalname = "vSALDOACREEDOR";
         edtavSaldodeudor_Internalname = "vSALDODEUDOR";
         edtWalletSolicitudesPendientes_Internalname = "WALLETSOLICITUDESPENDIENTES";
         edtavGridwalletnombre_Internalname = "vGRIDWALLETNOMBRE";
         Gridwalletpaginationbar_Internalname = "GRIDWALLETPAGINATIONBAR";
         divGridwallettablewithpaginationbar_Internalname = "GRIDWALLETTABLEWITHPAGINATIONBAR";
         divPanelbuscadorcuentas_Internalname = "PANELBUSCADORCUENTAS";
         Dvpanel_panelbuscadorcuentas_Internalname = "DVPANEL_PANELBUSCADORCUENTAS";
         cmbavOperacionesperiodocod_Internalname = "vOPERACIONESPERIODOCOD";
         edtavFechadesde_Internalname = "vFECHADESDE";
         edtavFechahasta_Internalname = "vFECHAHASTA";
         divTablefiltros_Internalname = "TABLEFILTROS";
         lblTabwallet_title_Internalname = "TABWALLET_TITLE";
         edtavWalletcodrefencia_Internalname = "vWALLETCODREFENCIA";
         edtavWalletid_Internalname = "vWALLETID";
         edtavWalletnombre_Internalname = "vWALLETNOMBRE";
         edtavWalletsaldo_Internalname = "vWALLETSALDO";
         tblTablewalletheader_Internalname = "TABLEWALLETHEADER";
         chkavIncluirbalance_Internalname = "vINCLUIRBALANCE";
         edtWalletId_Internalname = "WALLETID";
         edtWalletBalancesId_Internalname = "WALLETBALANCESID";
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA";
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE";
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV";
         cmbWalletBalancesConcepto_Internalname = "WALLETBALANCESCONCEPTO";
         edtWalletBalancesObs_Internalname = "WALLETBALANCESOBS";
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE";
         edtWalletBalancesUrl_Internalname = "WALLETBALANCESURL";
         divTablewalletcontainer_Internalname = "TABLEWALLETCONTAINER";
         lblTabsolicitudes_title_Internalname = "TABSOLICITUDES_TITLE";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         edtProveedorID_Internalname = "PROVEEDORID";
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO";
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM";
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO";
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM";
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF";
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL";
         divTablesolicitudes_Internalname = "TABLESOLICITUDES";
         lblTabhistorial_title_Internalname = "TABHISTORIAL_TITLE";
         cmbavActions_Internalname = "vACTIONS";
         edtavWalletbalancesid_Internalname = "vWALLETBALANCESID";
         edtavWalletbalancesfechaalta_Internalname = "vWALLETBALANCESFECHAALTA";
         edtavWalletbalancesimporte_Internalname = "vWALLETBALANCESIMPORTE";
         cmbavWalletbalancestipomov_Internalname = "vWALLETBALANCESTIPOMOV";
         cmbavWalletbalancesconcepto_Internalname = "vWALLETBALANCESCONCEPTO";
         edtavWalletbalancesobs_Internalname = "vWALLETBALANCESOBS";
         edtavWalletbalancesopeid_Internalname = "vWALLETBALANCESOPEID";
         cmbavWalletbalancesestadoope_Internalname = "vWALLETBALANCESESTADOOPE";
         Gridhistorialpaginationbar_Internalname = "GRIDHISTORIALPAGINATIONBAR";
         divGridhistorialtablewithpaginationbar_Internalname = "GRIDHISTORIALTABLEWITHPAGINATIONBAR";
         divTablehistorial_Internalname = "TABLEHISTORIAL";
         Gxuitabspanel_tabsliquidacion_Internalname = "GXUITABSPANEL_TABSLIQUIDACION";
         lblTextblocktotalsolicitudes_Internalname = "TEXTBLOCKTOTALSOLICITUDES";
         edtavTotalsolicitudes_Internalname = "vTOTALSOLICITUDES";
         divUnnamedtabletotalsolicitudes_Internalname = "UNNAMEDTABLETOTALSOLICITUDES";
         lblTextblocktotalnetoapagar_Internalname = "TEXTBLOCKTOTALNETOAPAGAR";
         edtavTotalnetoapagar_Internalname = "vTOTALNETOAPAGAR";
         divUnnamedtabletotalnetoapagar_Internalname = "UNNAMEDTABLETOTALNETOAPAGAR";
         lblTextblocktotalajusteswallet_Internalname = "TEXTBLOCKTOTALAJUSTESWALLET";
         edtavTotalajusteswallet_Internalname = "vTOTALAJUSTESWALLET";
         divUnnamedtabletotalajusteswallet_Internalname = "UNNAMEDTABLETOTALAJUSTESWALLET";
         lblTextblockcantidadregistros_Internalname = "TEXTBLOCKCANTIDADREGISTROS";
         edtavCantidadregistros_Internalname = "vCANTIDADREGISTROS";
         divUnnamedtablecantidadregistros_Internalname = "UNNAMEDTABLECANTIDADREGISTROS";
         lblTextblockcantidadajustes_Internalname = "TEXTBLOCKCANTIDADAJUSTES";
         edtavCantidadajustes_Internalname = "vCANTIDADAJUSTES";
         divUnnamedtablecantidadajustes_Internalname = "UNNAMEDTABLECANTIDADAJUSTES";
         tblTabletotales_Internalname = "TABLETOTALES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnbtnliquidar_Internalname = "BTNBTNLIQUIDAR";
         bttBtnbtncancelar_Internalname = "BTNBTNCANCELAR";
         tblTableactions_Internalname = "TABLEACTIONS";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGridwalletcurrentpage_Internalname = "vGRIDWALLETCURRENTPAGE";
         edtavGridhistorialcurrentpage_Internalname = "vGRIDHISTORIALCURRENTPAGE";
         Dvelop_confirmpanel_btnbtnliquidar_Internalname = "DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR";
         tblTabledvelop_confirmpanel_btnbtnliquidar_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR";
         Dvelop_confirmpanel_actioncrearwallets_Internalname = "DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS";
         tblTabledvelop_confirmpanel_actioncrearwallets_Internalname = "TABLEDVELOP_CONFIRMPANEL_ACTIONCREARWALLETS";
         Gridhistorial_empowerer_Internalname = "GRIDHISTORIAL_EMPOWERER";
         Gridprevia_empowerer_Internalname = "GRIDPREVIA_EMPOWERER";
         Gridwalletbalances_empowerer_Internalname = "GRIDWALLETBALANCES_EMPOWERER";
         Gridwallet_empowerer_Internalname = "GRIDWALLET_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridwallet_Internalname = "GRIDWALLET";
         subGridwalletbalances_Internalname = "GRIDWALLETBALANCES";
         subGridprevia_Internalname = "GRIDPREVIA";
         subGridhistorial_Internalname = "GRIDHISTORIAL";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridhistorial_Allowcollapsing = 0;
         subGridhistorial_Allowselection = 0;
         subGridhistorial_Header = "";
         subGridprevia_Allowcollapsing = 0;
         subGridprevia_Allowselection = 0;
         subGridprevia_Header = "";
         subGridwalletbalances_Allowcollapsing = 0;
         subGridwalletbalances_Allowselection = 0;
         subGridwalletbalances_Header = "";
         subGridwallet_Allowcollapsing = 0;
         subGridwallet_Allowhovering = -1;
         subGridwallet_Allowselection = 1;
         subGridwallet_Header = "";
         chkavTodoslosprofesionales.Caption = "";
         cmbavWalletbalancesestadoope_Jsonclick = "";
         cmbavWalletbalancesestadoope.Enabled = 1;
         edtavWalletbalancesopeid_Jsonclick = "";
         edtavWalletbalancesopeid_Enabled = 1;
         edtavWalletbalancesobs_Jsonclick = "";
         edtavWalletbalancesobs_Enabled = 1;
         cmbavWalletbalancesconcepto_Jsonclick = "";
         cmbavWalletbalancesconcepto.Enabled = 1;
         cmbavWalletbalancestipomov_Jsonclick = "";
         cmbavWalletbalancestipomov.Enabled = 1;
         edtavWalletbalancesimporte_Jsonclick = "";
         edtavWalletbalancesimporte_Enabled = 1;
         edtavWalletbalancesfechaalta_Jsonclick = "";
         edtavWalletbalancesfechaalta_Enabled = 1;
         edtavWalletbalancesid_Jsonclick = "";
         edtavWalletbalancesid_Enabled = 1;
         cmbavActions_Jsonclick = "";
         subGridhistorial_Class = "GridWithPaginationBar WorkWith";
         subGridhistorial_Backcolorstyle = 0;
         edtSolicitudServicioPFinal_Jsonclick = "";
         edtSolicitudesCostoXZComProf_Jsonclick = "";
         edtSolicitudesCostoXZComAlm_Jsonclick = "";
         edtSolicitudServicioComPro_Jsonclick = "";
         edtSolicitudServicioComALM_Jsonclick = "";
         cmbSolicitudServicioOrigenPago_Jsonclick = "";
         edtProveedorID_Jsonclick = "";
         edtEstadosSolId_Jsonclick = "";
         edtSolicitudesFechaInstalacion_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         edtSolicitudesID_Jsonclick = "";
         subGridprevia_Class = "WorkWith";
         subGridprevia_Backcolorstyle = 0;
         edtWalletBalancesUrl_Jsonclick = "";
         edtWalletBalancesUrl_Linktarget = "";
         edtWalletBalancesUrl_Link = "";
         cmbWalletBalancesEstadoOPE_Jsonclick = "";
         edtWalletBalancesObs_Jsonclick = "";
         cmbWalletBalancesConcepto_Jsonclick = "";
         cmbWalletBalancesTipoMov_Jsonclick = "";
         edtWalletBalancesImporte_Jsonclick = "";
         edtWalletBalancesFechaAlta_Jsonclick = "";
         edtWalletBalancesId_Jsonclick = "";
         edtWalletId_Jsonclick = "";
         chkavIncluirbalance.Caption = "";
         subGridwalletbalances_Class = "WorkWith";
         subGridwalletbalances_Backcolorstyle = 0;
         edtavGridwalletnombre_Jsonclick = "";
         edtavGridwalletnombre_Enabled = 1;
         edtWalletSolicitudesPendientes_Jsonclick = "";
         edtavSaldodeudor_Jsonclick = "";
         edtavSaldodeudor_Columnclass = "WWColumn";
         edtavSaldodeudor_Enabled = 1;
         edtavSaldoacreedor_Jsonclick = "";
         edtavSaldoacreedor_Enabled = 1;
         edtWalletSaldo_Jsonclick = "";
         edtWalletTotalDebito_Jsonclick = "";
         edtWalletTotalCredito_Jsonclick = "";
         edtWalletNombre_Jsonclick = "";
         edtWalletCodRefencia_Jsonclick = "";
         edtavGridwalletid_Jsonclick = "";
         edtavGridwalletid_Enabled = 1;
         cmbavActionswallet_Jsonclick = "";
         subGridwallet_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGridwallet_Backcolorstyle = 0;
         edtavWalletsaldo_Jsonclick = "";
         edtavWalletsaldo_Enabled = 1;
         edtavWalletnombre_Jsonclick = "";
         edtavWalletnombre_Enabled = 1;
         edtavWalletid_Jsonclick = "";
         edtavWalletid_Enabled = 1;
         edtavWalletcodrefencia_Jsonclick = "";
         edtavWalletcodrefencia_Enabled = 1;
         edtavCantidadajustes_Jsonclick = "";
         edtavCantidadajustes_Enabled = 1;
         edtavCantidadregistros_Jsonclick = "";
         edtavCantidadregistros_Enabled = 1;
         edtavTotalajusteswallet_Jsonclick = "";
         edtavTotalajusteswallet_Enabled = 1;
         edtavTotalnetoapagar_Jsonclick = "";
         edtavTotalnetoapagar_Enabled = 1;
         edtavTotalsolicitudes_Jsonclick = "";
         edtavTotalsolicitudes_Enabled = 1;
         edtavSaldodeudor_Columnheaderclass = "";
         edtSolicitudServicioPFinal_Enabled = 0;
         edtSolicitudesCostoXZComProf_Enabled = 0;
         edtSolicitudesCostoXZComAlm_Enabled = 0;
         edtSolicitudServicioComPro_Enabled = 0;
         edtSolicitudServicioComALM_Enabled = 0;
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtWalletBalancesUrl_Enabled = 0;
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         edtWalletBalancesObs_Enabled = 0;
         cmbWalletBalancesConcepto.Enabled = 0;
         cmbWalletBalancesTipoMov.Enabled = 0;
         edtWalletBalancesImporte_Enabled = 0;
         edtWalletBalancesFechaAlta_Enabled = 0;
         edtWalletBalancesId_Enabled = 0;
         edtWalletId_Enabled = 0;
         edtWalletSolicitudesPendientes_Enabled = 0;
         edtWalletSaldo_Enabled = 0;
         edtWalletTotalDebito_Enabled = 0;
         edtWalletTotalCredito_Enabled = 0;
         edtWalletNombre_Enabled = 0;
         edtWalletCodRefencia_Enabled = 0;
         edtavGridhistorialcurrentpage_Jsonclick = "";
         edtavGridhistorialcurrentpage_Visible = 1;
         edtavGridwalletcurrentpage_Jsonclick = "";
         edtavGridwalletcurrentpage_Visible = 1;
         divTablecontent_Visible = 1;
         edtavFechahasta_Jsonclick = "";
         edtavFechahasta_Enabled = 1;
         edtavFechadesde_Jsonclick = "";
         edtavFechadesde_Enabled = 1;
         cmbavOperacionesperiodocod_Jsonclick = "";
         cmbavOperacionesperiodocod.Enabled = 1;
         edtavBuscarcuenta_Jsonclick = "";
         edtavBuscarcuenta_Enabled = 1;
         chkavTodoslosprofesionales.Enabled = 1;
         Gridprevia_empowerer_Infinitescrolling = "Grid";
         Gridhistorial_empowerer_Fixedcolumns = "L;;;;;;;;";
         Dvelop_confirmpanel_actioncrearwallets_Confirmtype = "1";
         Dvelop_confirmpanel_actioncrearwallets_Yesbuttonposition = "left";
         Dvelop_confirmpanel_actioncrearwallets_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_actioncrearwallets_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_actioncrearwallets_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_actioncrearwallets_Confirmationtext = "¿Desea crear las Cuentas faltantes para los profesionales activos?";
         Dvelop_confirmpanel_actioncrearwallets_Title = context.GetMessage( "Cuentas Pendientes", "");
         Dvelop_confirmpanel_btnbtnliquidar_Confirmtype = "1";
         Dvelop_confirmpanel_btnbtnliquidar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnbtnliquidar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnbtnliquidar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnbtnliquidar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext = "¿Está seguro de que desea confirmar la liquidación de las solicitudes seleccionadas?";
         Dvelop_confirmpanel_btnbtnliquidar_Title = context.GetMessage( "Confirmación", "");
         Gxuitabspanel_tabsliquidacion_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabsliquidacion_Class = "Tab";
         Gxuitabspanel_tabsliquidacion_Pagecount = 3;
         Gridhistorialpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridhistorialpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridhistorialpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridhistorialpaginationbar_Next = "WWP_PagingNextCaption";
         Gridhistorialpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridhistorialpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridhistorialpaginationbar_Rowsperpageselectedvalue = 10;
         Gridhistorialpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridhistorialpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridhistorialpaginationbar_Pagingcaptionposition = "Left";
         Gridhistorialpaginationbar_Pagingbuttonsposition = "Right";
         Gridhistorialpaginationbar_Pagestoshow = 5;
         Gridhistorialpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridhistorialpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridhistorialpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridhistorialpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridhistorialpaginationbar_Class = "PaginationBar";
         Dvpanel_panelbuscadorcuentas_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panelbuscadorcuentas_Iconposition = "Right";
         Dvpanel_panelbuscadorcuentas_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panelbuscadorcuentas_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panelbuscadorcuentas_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panelbuscadorcuentas_Title = context.GetMessage( "Centro de Cuentas y Saldos", "");
         Dvpanel_panelbuscadorcuentas_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_panelbuscadorcuentas_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panelbuscadorcuentas_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panelbuscadorcuentas_Width = "100%";
         Gridwalletpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridwalletpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridwalletpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridwalletpaginationbar_Next = "WWP_PagingNextCaption";
         Gridwalletpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridwalletpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridwalletpaginationbar_Rowsperpageselectedvalue = 10;
         Gridwalletpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridwalletpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridwalletpaginationbar_Pagingcaptionposition = "Left";
         Gridwalletpaginationbar_Pagingbuttonsposition = "Right";
         Gridwalletpaginationbar_Pagestoshow = 5;
         Gridwalletpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridwalletpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridwalletpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridwalletpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridwalletpaginationbar_Class = "PaginationBar";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Centro de Liquidacion", "");
         subGridhistorial_Rows = 0;
         subGridprevia_Rows = 50;
         subGridwalletbalances_Rows = 0;
         subGridwallet_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDHISTORIAL.LOAD","{handler:'E30L94',iparms:[{av:'A640WalletBalancesId',fld:'WALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A641WalletBalancesFechaAlta',fld:'WALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbWalletBalancesTipoMov'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',pic:'',hsh:true,type:'char'},{av:'cmbWalletBalancesConcepto'},{av:'A1010WalletBalancesConcepto',fld:'WALLETBALANCESCONCEPTO',pic:'ZZZ9',type:'int'},{av:'A1009WalletBalancesObs',fld:'WALLETBALANCESOBS',pic:'',type:'svchar'},{av:'A1012WalletBalanceLiquidacion',fld:'WALLETBALANCELIQUIDACION',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRIDHISTORIAL.LOAD",",oparms:[{av:'AV51WalletBalancesId',fld:'vWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV50WalletBalancesFechaAlta',fld:'vWALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV52WalletBalancesImporte',fld:'vWALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavWalletbalancestipomov'},{av:'AV54WalletBalancesTipoMov',fld:'vWALLETBALANCESTIPOMOV',pic:'',type:'char'},{av:'cmbavWalletbalancesconcepto'},{av:'AV49WalletBalancesConcepto',fld:'vWALLETBALANCESCONCEPTO',pic:'ZZZ9',type:'int'},{av:'AV53WalletBalancesObs',fld:'vWALLETBALANCESOBS',pic:'',type:'svchar'},{av:'AV10WalletBalancesOpeId',fld:'vWALLETBALANCESOPEID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavActions'},{av:'AV12Actions',fld:'vACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPREVIA.LOAD","{handler:'E29L95',iparms:[]");
         setEventMetadata("GRIDPREVIA.LOAD",",oparms:[]}");
         setEventMetadata("GRIDWALLETBALANCES.LOAD","{handler:'E27L96',iparms:[{av:'A1011WalletBalancesUrl',fld:'WALLETBALANCESURL',pic:'',type:'svchar'}]");
         setEventMetadata("GRIDWALLETBALANCES.LOAD",",oparms:[{av:'edtWalletBalancesUrl_Linktarget',ctrl:'WALLETBALANCESURL',prop:'Linktarget'},{av:'edtWalletBalancesUrl_Link',ctrl:'WALLETBALANCESURL',prop:'Link'}]}");
         setEventMetadata("GRIDWALLET.LOAD","{handler:'E24L92',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("GRIDWALLET.LOAD",",oparms:[{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV34GridWalletNombre',fld:'vGRIDWALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV86SaldoAcreedor',fld:'vSALDOACREEDOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV87SaldoDeudor',fld:'vSALDODEUDOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavActionswallet'},{av:'AV13ActionsWallet',fld:'vACTIONSWALLET',pic:'ZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnclass',ctrl:'vSALDODEUDOR',prop:'Columnclass'}]}");
         setEventMetadata("GRIDHISTORIALPAGINATIONBAR.CHANGEPAGE","{handler:'E14L92',iparms:[{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'Gridhistorialpaginationbar_Selectedpage',ctrl:'GRIDHISTORIALPAGINATIONBAR',prop:'SelectedPage'},{av:'AV22GridHistorialCurrentPage',fld:'vGRIDHISTORIALCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRIDHISTORIALPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV22GridHistorialCurrentPage',fld:'vGRIDHISTORIALCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDHISTORIALPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E15L92',iparms:[{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',pic:'',type:'boolean'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridhistorialpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDHISTORIALPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDHISTORIALPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV22GridHistorialCurrentPage',fld:'vGRIDHISTORIALCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETPAGINATIONBAR.CHANGEPAGE","{handler:'E12L92',iparms:[{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridwalletpaginationbar_Selectedpage',ctrl:'GRIDWALLETPAGINATIONBAR',prop:'SelectedPage'},{av:'AV32GridWalletCurrentPage',fld:'vGRIDWALLETCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("GRIDWALLETPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV32GridWalletCurrentPage',fld:'vGRIDWALLETCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13L92',iparms:[{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',pic:'',type:'boolean'},{av:'cmbWalletBalancesTipoMov'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridwalletpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDWALLETPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDWALLETPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'AV32GridWalletCurrentPage',fld:'vGRIDWALLETCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOBTNLIQUIDAR'","{handler:'E18L92',iparms:[{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'cmbavOperacionesperiodocod'},{av:'AV59OperacionesPeriodoCod',fld:'vOPERACIONESPERIODOCOD',pic:'',type:'svchar'},{av:'A555OperacionesRef',fld:'OPERACIONESREF',pic:'',type:'char'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A649OperacionesTipo',fld:'OPERACIONESTIPO',pic:'',type:'char'},{av:'A1028OperacionesPeriodoCod',fld:'OPERACIONESPERIODOCOD',pic:'',type:'svchar'},{av:'A577OperacionesEstado',fld:'OPERACIONESESTADO',pic:'',type:'char'},{av:'A554OperacionesId',fld:'OPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOBTNLIQUIDAR'",",oparms:[{av:'Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext',ctrl:'DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR',prop:'ConfirmationText'}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR.CLOSE","{handler:'E16L92',iparms:[{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Dvelop_confirmpanel_btnbtnliquidar_Result',ctrl:'DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR',prop:'Result'},{av:'cmbavOperacionesperiodocod'},{av:'AV59OperacionesPeriodoCod',fld:'vOPERACIONESPERIODOCOD',pic:'',type:'svchar'},{av:'A640WalletBalancesId',fld:'WALLETBALANCESID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNBTNLIQUIDAR.CLOSE",",oparms:[{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'}]}");
         setEventMetadata("'DOBTNCANCELAR'","{handler:'E19L92',iparms:[]");
         setEventMetadata("'DOBTNCANCELAR'",",oparms:[]}");
         setEventMetadata("VACTIONS.CLICK","{handler:'E31L92',iparms:[{av:'cmbavActions'},{av:'AV12Actions',fld:'vACTIONS',pic:'ZZZ9',type:'int'},{av:'AV10WalletBalancesOpeId',fld:'vWALLETBALANCESOPEID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("VACTIONS.CLICK",",oparms:[{av:'cmbavActions'},{av:'AV12Actions',fld:'vACTIONS',pic:'ZZZ9',type:'int'},{av:'AV10WalletBalancesOpeId',fld:'vWALLETBALANCESOPEID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOACTIONCREARWALLETS'","{handler:'E11L91',iparms:[]");
         setEventMetadata("'DOACTIONCREARWALLETS'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS.CLOSE","{handler:'E17L92',iparms:[{av:'Dvelop_confirmpanel_actioncrearwallets_Result',ctrl:'DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS',prop:'Result'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_ACTIONCREARWALLETS.CLOSE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VACTIONSWALLET.CLICK","{handler:'E25L92',iparms:[{av:'cmbavActionswallet'},{av:'AV13ActionsWallet',fld:'vACTIONSWALLET',pic:'ZZZ9',type:'int'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV34GridWalletNombre',fld:'vGRIDWALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("VACTIONSWALLET.CLICK",",oparms:[{av:'cmbavActionswallet'},{av:'AV13ActionsWallet',fld:'vACTIONSWALLET',pic:'ZZZ9',type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETBALANCES.REFRESH","{handler:'E28L92',iparms:[{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("GRIDWALLETBALANCES.REFRESH",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]}");
         setEventMetadata("GRIDWALLET.ONLINEACTIVATE","{handler:'E26L92',iparms:[{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'}]");
         setEventMetadata("GRIDWALLET.ONLINEACTIVATE",",oparms:[{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'}]}");
         setEventMetadata("VTODOSLOSPROFESIONALES.CONTROLVALUECHANGED","{handler:'E20L92',iparms:[{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'}]");
         setEventMetadata("VTODOSLOSPROFESIONALES.CONTROLVALUECHANGED",",oparms:[{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'}]}");
         setEventMetadata("VOPERACIONESPERIODOCOD.CONTROLVALUECHANGED","{handler:'E21L92',iparms:[{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'cmbavOperacionesperiodocod'},{av:'AV59OperacionesPeriodoCod',fld:'vOPERACIONESPERIODOCOD',pic:'',type:'svchar'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'}]");
         setEventMetadata("VOPERACIONESPERIODOCOD.CONTROLVALUECHANGED",",oparms:[{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPREVIA_FIRSTPAGE","{handler:'subgridprevia_firstpage',iparms:[{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDPREVIA_FIRSTPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPREVIA_PREVPAGE","{handler:'subgridprevia_previouspage',iparms:[{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDPREVIA_PREVPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPREVIA_NEXTPAGE","{handler:'subgridprevia_nextpage',iparms:[{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDPREVIA_NEXTPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPREVIA_LASTPAGE","{handler:'subgridprevia_lastpage',iparms:[{av:'GRIDPREVIA_nFirstRecordOnPage',type:'int'},{av:'GRIDPREVIA_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDPREVIA_LASTPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETBALANCES_FIRSTPAGE","{handler:'subgridwalletbalances_firstpage',iparms:[{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDWALLETBALANCES_FIRSTPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETBALANCES_PREVPAGE","{handler:'subgridwalletbalances_previouspage',iparms:[{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDWALLETBALANCES_PREVPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETBALANCES_NEXTPAGE","{handler:'subgridwalletbalances_nextpage',iparms:[{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDWALLETBALANCES_NEXTPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRIDWALLETBALANCES_LASTPAGE","{handler:'subgridwalletbalances_lastpage',iparms:[{av:'GRIDWALLETBALANCES_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLETBALANCES_nEOF',type:'int'},{av:'subGridwallet_Rows',ctrl:'GRIDWALLET',prop:'Rows'},{av:'subGridwalletbalances_Rows',ctrl:'GRIDWALLETBALANCES',prop:'Rows'},{av:'subGridprevia_Rows',ctrl:'GRIDPREVIA',prop:'Rows'},{av:'subGridhistorial_Rows',ctrl:'GRIDHISTORIAL',prop:'Rows'},{av:'AV15BuscarCuenta',fld:'vBUSCARCUENTA',pic:'',type:'char'},{av:'AV9ProfesionalesNombre',fld:'vPROFESIONALESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV85UserId',fld:'vUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV56WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',grid:100,pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'nRC_GXsfl_100',ctrl:'GRIDWALLETBALANCES',prop:'GridRC',grid:100,type:'int'},{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'GRIDWALLET_nFirstRecordOnPage',type:'int'},{av:'GRIDWALLET_nEOF',type:'int'},{av:'AV44TodosLosProfesionales',fld:'vTODOSLOSPROFESIONALES',pic:'',type:'boolean'},{av:'AV18FechaDesde',fld:'vFECHADESDE',pic:'',type:'date'},{av:'AV19FechaHasta',fld:'vFECHAHASTA',pic:'',type:'date'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A688SolicitudesLiqProf',fld:'SOLICITUDESLIQPROF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A141EstadoSGTipo',fld:'ESTADOSGTIPO',pic:'',type:'char'},{av:'A142EstadoSGId',fld:'ESTADOSGID',pic:'ZZZZ9',type:'int'},{av:'A529SolicitudServicioComPro',fld:'SOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'A867SolicitudesCostoXZComProf',fld:'SOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'cmbSolicitudServicioOrigenPago'},{av:'A438SolicitudServicioOrigenPago',fld:'SOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'A211SolicitudServicioPFinal',fld:'SOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'},{av:'AV37IncluirBalance',fld:'vINCLUIRBALANCE',grid:100,pic:'',type:'boolean'},{av:'A643WalletBalancesTipoMov',fld:'WALLETBALANCESTIPOMOV',grid:100,pic:'',hsh:true,type:'char'},{av:'A644WalletBalancesImporte',fld:'WALLETBALANCESIMPORTE',grid:100,pic:'ZZZZZZZZZZZZZZ9.99',hsh:true,type:'decimal'},{av:'AV33GridWalletId',fld:'vGRIDWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDHISTORIAL_nFirstRecordOnPage',type:'int'},{av:'GRIDHISTORIAL_nEOF',type:'int'}]");
         setEventMetadata("GRIDWALLETBALANCES_LASTPAGE",",oparms:[{av:'AV45TotalAjustesWallet',fld:'vTOTALAJUSTESWALLET',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV17CantidadRegistros',fld:'vCANTIDADREGISTROS',pic:'ZZZ9',type:'int'},{av:'AV48TotalSolicitudes',fld:'vTOTALSOLICITUDES',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV55WalletCodRefencia',fld:'vWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV57WalletNombre',fld:'vWALLETNOMBRE',pic:'',type:'char'},{av:'AV58WalletSaldo',fld:'vWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'AV47TotalNetoAPagar',fld:'vTOTALNETOAPAGAR',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35GridWalletPageCount',fld:'vGRIDWALLETPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV23GridHistorialPageCount',fld:'vGRIDHISTORIALPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavSaldodeudor_Columnheaderclass',ctrl:'vSALDODEUDOR',prop:'Columnheaderclass'},{av:'AV16CantidadAjustes',fld:'vCANTIDADAJUSTES',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALIDV_FECHADESDE","{handler:'Validv_Fechadesde',iparms:[]");
         setEventMetadata("VALIDV_FECHADESDE",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAHASTA","{handler:'Validv_Fechahasta',iparms:[]");
         setEventMetadata("VALIDV_FECHAHASTA",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETID","{handler:'Validv_Walletid',iparms:[]");
         setEventMetadata("VALIDV_WALLETID",",oparms:[]}");
         setEventMetadata("VALID_WALLETCODREFENCIA","{handler:'Valid_Walletcodrefencia',iparms:[]");
         setEventMetadata("VALID_WALLETCODREFENCIA",",oparms:[]}");
         setEventMetadata("VALID_WALLETNOMBRE","{handler:'Valid_Walletnombre',iparms:[]");
         setEventMetadata("VALID_WALLETNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_WALLETTOTALCREDITO","{handler:'Valid_Wallettotalcredito',iparms:[]");
         setEventMetadata("VALID_WALLETTOTALCREDITO",",oparms:[]}");
         setEventMetadata("VALID_WALLETTOTALDEBITO","{handler:'Valid_Wallettotaldebito',iparms:[]");
         setEventMetadata("VALID_WALLETTOTALDEBITO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gridwalletnombre',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_WALLETID","{handler:'Valid_Walletid',iparms:[]");
         setEventMetadata("VALID_WALLETID",",oparms:[]}");
         setEventMetadata("VALID_WALLETBALANCESESTADOOPE","{handler:'Valid_Walletbalancesestadoope',iparms:[]");
         setEventMetadata("VALID_WALLETBALANCESESTADOOPE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Walletbalancesurl',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM","{handler:'Valid_Solicitudserviciocomalm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALM","{handler:'Valid_Solicitudescostoxzcomalm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL","{handler:'Valid_Solicitudserviciopfinal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETBALANCESFECHAALTA","{handler:'Validv_Walletbalancesfechaalta',iparms:[]");
         setEventMetadata("VALIDV_WALLETBALANCESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETBALANCESTIPOMOV","{handler:'Validv_Walletbalancestipomov',iparms:[]");
         setEventMetadata("VALIDV_WALLETBALANCESTIPOMOV",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETBALANCESCONCEPTO","{handler:'Validv_Walletbalancesconcepto',iparms:[]");
         setEventMetadata("VALIDV_WALLETBALANCESCONCEPTO",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETBALANCESESTADOOPE","{handler:'Validv_Walletbalancesestadoope',iparms:[]");
         setEventMetadata("VALIDV_WALLETBALANCESESTADOOPE",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         Gridhistorialpaginationbar_Selectedpage = "";
         Gridwalletpaginationbar_Selectedpage = "";
         Dvelop_confirmpanel_btnbtnliquidar_Result = "";
         Dvelop_confirmpanel_actioncrearwallets_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15BuscarCuenta = "";
         AV18FechaDesde = DateTime.MinValue;
         AV19FechaHasta = DateTime.MinValue;
         AV43ProfesionalesId = "";
         A120ProfesionalesId = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A130EstadosSolTipo = "";
         A141EstadoSGTipo = "";
         A438SolicitudServicioOrigenPago = "";
         AV37IncluirBalance = false;
         A643WalletBalancesTipoMov = "";
         AV9ProfesionalesNombre = "";
         A715WalletNombre = "";
         A639WalletCodRefencia = "";
         H00L92_A127SolicitudesID = new long[1] ;
         H00L92_A134SolicitudesItemsID = new short[1] ;
         H00L92_A180SolicitudItemsComision = new decimal[1] ;
         H00L92_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00L92_A178SolicitudItemsSR = new string[] {""} ;
         H00L92_A177SolicitudesItemsCantidad = new short[1] ;
         H00L92_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00L92_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27GridWalletAppliedFilters = "";
         AV21GridHistorialAppliedFilters = "";
         A555OperacionesRef = "";
         A1028OperacionesPeriodoCod = "";
         A577OperacionesEstado = "";
         A638WalletTipoEntidad = "";
         A649OperacionesTipo = "";
         Gridhistorial_empowerer_Gridinternalname = "";
         Gridprevia_empowerer_Gridinternalname = "";
         Gridwalletbalances_empowerer_Gridinternalname = "";
         Gridwallet_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panelbuscadorcuentas = new GXUserControl();
         TempTags = "";
         bttBtnactioncrearwallets_Jsonclick = "";
         GridwalletContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridwalletpaginationbar = new GXUserControl();
         AV59OperacionesPeriodoCod = "";
         ucGxuitabspanel_tabsliquidacion = new GXUserControl();
         lblTabwallet_title_Jsonclick = "";
         GridwalletbalancesContainer = new GXWebGrid( context);
         lblTabsolicitudes_title_Jsonclick = "";
         GridpreviaContainer = new GXWebGrid( context);
         lblTabhistorial_title_Jsonclick = "";
         GridhistorialContainer = new GXWebGrid( context);
         ucGridhistorialpaginationbar = new GXUserControl();
         ucGridhistorial_empowerer = new GXUserControl();
         ucGridprevia_empowerer = new GXUserControl();
         ucGridwalletbalances_empowerer = new GXUserControl();
         ucGridwallet_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV34GridWalletNombre = "";
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A1009WalletBalancesObs = "";
         A645WalletBalancesEstadoOPE = "";
         A1011WalletBalancesUrl = "";
         AV50WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         AV54WalletBalancesTipoMov = "";
         AV53WalletBalancesObs = "";
         AV80WalletBalancesEstadoOPE = "";
         GXCCtl = "";
         H00L93_A638WalletTipoEntidad = new string[] {""} ;
         H00L93_A637WalletId = new long[1] ;
         H00L93_A639WalletCodRefencia = new string[] {""} ;
         H00L94_A638WalletTipoEntidad = new string[] {""} ;
         H00L94_A637WalletId = new long[1] ;
         H00L94_A639WalletCodRefencia = new string[] {""} ;
         H00L95_A1010WalletBalancesConcepto = new short[1] ;
         H00L95_n1010WalletBalancesConcepto = new bool[] {false} ;
         H00L95_A645WalletBalancesEstadoOPE = new string[] {""} ;
         H00L95_A637WalletId = new long[1] ;
         H00L95_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00L95_A644WalletBalancesImporte = new decimal[1] ;
         H00L95_A643WalletBalancesTipoMov = new string[] {""} ;
         H00L95_A1009WalletBalancesObs = new string[] {""} ;
         H00L95_n1009WalletBalancesObs = new bool[] {false} ;
         H00L95_A1012WalletBalanceLiquidacion = new long[1] ;
         H00L95_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         H00L95_A640WalletBalancesId = new long[1] ;
         H00L96_A140RelacionesId = new long[1] ;
         H00L96_A142EstadoSGId = new int[1] ;
         H00L96_A141EstadoSGTipo = new string[] {""} ;
         H00L96_A130EstadosSolTipo = new string[] {""} ;
         H00L96_A688SolicitudesLiqProf = new long[1] ;
         H00L96_n688SolicitudesLiqProf = new bool[] {false} ;
         H00L96_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00L96_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00L96_A133ProveedorID = new long[1] ;
         H00L96_A131EstadosSolId = new int[1] ;
         H00L96_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00L96_A120ProfesionalesId = new string[] {""} ;
         H00L96_A127SolicitudesID = new long[1] ;
         H00L96_A527SolicitudServicioComProv = new decimal[1] ;
         H00L96_n527SolicitudServicioComProv = new bool[] {false} ;
         H00L96_A530SolicitudServicioComALM = new decimal[1] ;
         H00L96_n530SolicitudServicioComALM = new bool[] {false} ;
         H00L96_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         H00L96_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         H00L96_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00L96_A212SolicitudesCotizacion = new decimal[1] ;
         H00L96_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00L96_A897SolicitudesDescuento = new decimal[1] ;
         H00L96_n897SolicitudesDescuento = new bool[] {false} ;
         H00L96_A864SolicitudesCostoXZona = new decimal[1] ;
         H00L97_A140RelacionesId = new long[1] ;
         H00L97_A142EstadoSGId = new int[1] ;
         H00L97_A141EstadoSGTipo = new string[] {""} ;
         H00L97_A130EstadosSolTipo = new string[] {""} ;
         H00L97_A688SolicitudesLiqProf = new long[1] ;
         H00L97_n688SolicitudesLiqProf = new bool[] {false} ;
         H00L97_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00L97_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00L97_A133ProveedorID = new long[1] ;
         H00L97_A131EstadosSolId = new int[1] ;
         H00L97_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00L97_A120ProfesionalesId = new string[] {""} ;
         H00L97_A127SolicitudesID = new long[1] ;
         H00L97_A527SolicitudServicioComProv = new decimal[1] ;
         H00L97_n527SolicitudServicioComProv = new bool[] {false} ;
         H00L97_A530SolicitudServicioComALM = new decimal[1] ;
         H00L97_n530SolicitudServicioComALM = new bool[] {false} ;
         H00L97_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         H00L97_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         H00L97_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00L97_A212SolicitudesCotizacion = new decimal[1] ;
         H00L97_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00L97_A897SolicitudesDescuento = new decimal[1] ;
         H00L97_n897SolicitudesDescuento = new bool[] {false} ;
         H00L97_A864SolicitudesCostoXZona = new decimal[1] ;
         H00L98_A639WalletCodRefencia = new string[] {""} ;
         H00L98_A1011WalletBalancesUrl = new string[] {""} ;
         H00L98_n1011WalletBalancesUrl = new bool[] {false} ;
         H00L98_A645WalletBalancesEstadoOPE = new string[] {""} ;
         H00L98_A1009WalletBalancesObs = new string[] {""} ;
         H00L98_n1009WalletBalancesObs = new bool[] {false} ;
         H00L98_A1010WalletBalancesConcepto = new short[1] ;
         H00L98_n1010WalletBalancesConcepto = new bool[] {false} ;
         H00L98_A643WalletBalancesTipoMov = new string[] {""} ;
         H00L98_A644WalletBalancesImporte = new decimal[1] ;
         H00L98_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00L98_A640WalletBalancesId = new long[1] ;
         H00L98_A637WalletId = new long[1] ;
         H00L99_A639WalletCodRefencia = new string[] {""} ;
         H00L99_A1011WalletBalancesUrl = new string[] {""} ;
         H00L99_n1011WalletBalancesUrl = new bool[] {false} ;
         H00L99_A645WalletBalancesEstadoOPE = new string[] {""} ;
         H00L99_A1009WalletBalancesObs = new string[] {""} ;
         H00L99_n1009WalletBalancesObs = new bool[] {false} ;
         H00L99_A1010WalletBalancesConcepto = new short[1] ;
         H00L99_n1010WalletBalancesConcepto = new bool[] {false} ;
         H00L99_A643WalletBalancesTipoMov = new string[] {""} ;
         H00L99_A644WalletBalancesImporte = new decimal[1] ;
         H00L99_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00L99_A640WalletBalancesId = new long[1] ;
         H00L99_A637WalletId = new long[1] ;
         H00L910_AGRIDHISTORIAL_nRecordCount = new long[1] ;
         AV55WalletCodRefencia = "";
         AV57WalletNombre = "";
         AV84Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext3 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00L911_A637WalletId = new long[1] ;
         H00L911_A639WalletCodRefencia = new string[] {""} ;
         H00L911_A638WalletTipoEntidad = new string[] {""} ;
         GXt_char1 = "";
         GridwalletRow = new GXWebRow();
         ucDvelop_confirmpanel_btnbtnliquidar = new GXUserControl();
         H00L912_A577OperacionesEstado = new string[] {""} ;
         H00L912_n577OperacionesEstado = new bool[] {false} ;
         H00L912_A1028OperacionesPeriodoCod = new string[] {""} ;
         H00L912_n1028OperacionesPeriodoCod = new bool[] {false} ;
         H00L912_A649OperacionesTipo = new string[] {""} ;
         H00L912_n649OperacionesTipo = new bool[] {false} ;
         H00L912_A555OperacionesRef = new string[] {""} ;
         H00L912_n555OperacionesRef = new bool[] {false} ;
         H00L912_A554OperacionesId = new long[1] ;
         AV14BalancesSeleccionados = new GxSimpleCollection<long>();
         AV8OperacionesTipo = "";
         AV7OperacionesRef = "";
         AV6OperacionesNombreRef = "";
         Gx_msg = "";
         AV11Window = new GXWindow();
         GXEncryptionTmp = "";
         AV20Filename = "";
         AV79Mensaje = "";
         AV66PrimerJueves = DateTime.MinValue;
         AV65JuevesSemana = DateTime.MinValue;
         AV63LunesSemana = DateTime.MinValue;
         AV64DomingoSemana = DateTime.MinValue;
         AV73FechaDesdeSugerida = DateTime.MinValue;
         AV72FechaHastaSugerida = DateTime.MinValue;
         AV60PeriodoFechaPivot = DateTime.MinValue;
         AV71CodSemana = "";
         AV68DescSemana = "";
         H00L913_A140RelacionesId = new long[1] ;
         H00L913_A127SolicitudesID = new long[1] ;
         H00L913_A142EstadoSGId = new int[1] ;
         H00L913_A141EstadoSGTipo = new string[] {""} ;
         H00L913_A131EstadosSolId = new int[1] ;
         H00L913_A130EstadosSolTipo = new string[] {""} ;
         H00L913_A688SolicitudesLiqProf = new long[1] ;
         H00L913_n688SolicitudesLiqProf = new bool[] {false} ;
         H00L913_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00L913_A120ProfesionalesId = new string[] {""} ;
         H00L913_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00L913_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00L913_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00L913_A212SolicitudesCotizacion = new decimal[1] ;
         H00L913_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00L913_A897SolicitudesDescuento = new decimal[1] ;
         H00L913_n897SolicitudesDescuento = new bool[] {false} ;
         H00L913_A527SolicitudServicioComProv = new decimal[1] ;
         H00L913_n527SolicitudServicioComProv = new bool[] {false} ;
         H00L913_A530SolicitudServicioComALM = new decimal[1] ;
         H00L913_n530SolicitudServicioComALM = new bool[] {false} ;
         H00L913_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         H00L913_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         H00L913_A864SolicitudesCostoXZona = new decimal[1] ;
         GridhistorialRow = new GXWebRow();
         GridpreviaRow = new GXWebRow();
         GridwalletbalancesRow = new GXWebRow();
         ucDvelop_confirmpanel_actioncrearwallets = new GXUserControl();
         bttBtnbtnliquidar_Jsonclick = "";
         bttBtnbtncancelar_Jsonclick = "";
         lblTextblocktotalsolicitudes_Jsonclick = "";
         lblTextblocktotalnetoapagar_Jsonclick = "";
         lblTextblocktotalajusteswallet_Jsonclick = "";
         lblTextblockcantidadregistros_Jsonclick = "";
         lblTextblockcantidadajustes_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridwallet_Linesclass = "";
         ROClassString = "";
         subGridwalletbalances_Linesclass = "";
         subGridprevia_Linesclass = "";
         subGridhistorial_Linesclass = "";
         GridwalletColumn = new GXWebColumn();
         GridwalletbalancesColumn = new GXWebColumn();
         GridpreviaColumn = new GXWebColumn();
         GridhistorialColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpliquidacioncentro__default(),
            new Object[][] {
                new Object[] {
               H00L92_A127SolicitudesID, H00L92_A134SolicitudesItemsID, H00L92_A180SolicitudItemsComision, H00L92_A179SolicitudItemsComisionTipo, H00L92_A178SolicitudItemsSR, H00L92_A177SolicitudesItemsCantidad, H00L92_A176SolicitudesItemsPrecioFinal, H00L92_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               H00L93_A638WalletTipoEntidad, H00L93_A637WalletId, H00L93_A639WalletCodRefencia
               }
               , new Object[] {
               H00L94_A638WalletTipoEntidad, H00L94_A637WalletId, H00L94_A639WalletCodRefencia
               }
               , new Object[] {
               H00L95_A1010WalletBalancesConcepto, H00L95_n1010WalletBalancesConcepto, H00L95_A645WalletBalancesEstadoOPE, H00L95_A637WalletId, H00L95_A641WalletBalancesFechaAlta, H00L95_A644WalletBalancesImporte, H00L95_A643WalletBalancesTipoMov, H00L95_A1009WalletBalancesObs, H00L95_n1009WalletBalancesObs, H00L95_A1012WalletBalanceLiquidacion,
               H00L95_n1012WalletBalanceLiquidacion, H00L95_A640WalletBalancesId
               }
               , new Object[] {
               H00L96_A140RelacionesId, H00L96_A142EstadoSGId, H00L96_A141EstadoSGTipo, H00L96_A130EstadosSolTipo, H00L96_A688SolicitudesLiqProf, H00L96_n688SolicitudesLiqProf, H00L96_A438SolicitudServicioOrigenPago, H00L96_n438SolicitudServicioOrigenPago, H00L96_A133ProveedorID, H00L96_A131EstadosSolId,
               H00L96_A184SolicitudesFechaInstalacion, H00L96_A120ProfesionalesId, H00L96_A127SolicitudesID, H00L96_A527SolicitudServicioComProv, H00L96_n527SolicitudServicioComProv, H00L96_A530SolicitudServicioComALM, H00L96_n530SolicitudServicioComALM, H00L96_A865SolicitudesCostoXZComAlm, H00L96_n865SolicitudesCostoXZComAlm, H00L96_A796SolicitudesComisionMetodoPago,
               H00L96_A212SolicitudesCotizacion, H00L96_A1016SolicitudesDescuentoCupon, H00L96_A897SolicitudesDescuento, H00L96_n897SolicitudesDescuento, H00L96_A864SolicitudesCostoXZona
               }
               , new Object[] {
               H00L97_A140RelacionesId, H00L97_A142EstadoSGId, H00L97_A141EstadoSGTipo, H00L97_A130EstadosSolTipo, H00L97_A688SolicitudesLiqProf, H00L97_n688SolicitudesLiqProf, H00L97_A438SolicitudServicioOrigenPago, H00L97_n438SolicitudServicioOrigenPago, H00L97_A133ProveedorID, H00L97_A131EstadosSolId,
               H00L97_A184SolicitudesFechaInstalacion, H00L97_A120ProfesionalesId, H00L97_A127SolicitudesID, H00L97_A527SolicitudServicioComProv, H00L97_n527SolicitudServicioComProv, H00L97_A530SolicitudServicioComALM, H00L97_n530SolicitudServicioComALM, H00L97_A865SolicitudesCostoXZComAlm, H00L97_n865SolicitudesCostoXZComAlm, H00L97_A796SolicitudesComisionMetodoPago,
               H00L97_A212SolicitudesCotizacion, H00L97_A1016SolicitudesDescuentoCupon, H00L97_A897SolicitudesDescuento, H00L97_n897SolicitudesDescuento, H00L97_A864SolicitudesCostoXZona
               }
               , new Object[] {
               H00L98_A639WalletCodRefencia, H00L98_A1011WalletBalancesUrl, H00L98_n1011WalletBalancesUrl, H00L98_A645WalletBalancesEstadoOPE, H00L98_A1009WalletBalancesObs, H00L98_n1009WalletBalancesObs, H00L98_A1010WalletBalancesConcepto, H00L98_n1010WalletBalancesConcepto, H00L98_A643WalletBalancesTipoMov, H00L98_A644WalletBalancesImporte,
               H00L98_A641WalletBalancesFechaAlta, H00L98_A640WalletBalancesId, H00L98_A637WalletId
               }
               , new Object[] {
               H00L99_A639WalletCodRefencia, H00L99_A1011WalletBalancesUrl, H00L99_n1011WalletBalancesUrl, H00L99_A645WalletBalancesEstadoOPE, H00L99_A1009WalletBalancesObs, H00L99_n1009WalletBalancesObs, H00L99_A1010WalletBalancesConcepto, H00L99_n1010WalletBalancesConcepto, H00L99_A643WalletBalancesTipoMov, H00L99_A644WalletBalancesImporte,
               H00L99_A641WalletBalancesFechaAlta, H00L99_A640WalletBalancesId, H00L99_A637WalletId
               }
               , new Object[] {
               H00L910_AGRIDHISTORIAL_nRecordCount
               }
               , new Object[] {
               H00L911_A637WalletId, H00L911_A639WalletCodRefencia, H00L911_A638WalletTipoEntidad
               }
               , new Object[] {
               H00L912_A577OperacionesEstado, H00L912_n577OperacionesEstado, H00L912_A1028OperacionesPeriodoCod, H00L912_n1028OperacionesPeriodoCod, H00L912_A649OperacionesTipo, H00L912_n649OperacionesTipo, H00L912_A555OperacionesRef, H00L912_n555OperacionesRef, H00L912_A554OperacionesId
               }
               , new Object[] {
               H00L913_A140RelacionesId, H00L913_A127SolicitudesID, H00L913_A142EstadoSGId, H00L913_A141EstadoSGTipo, H00L913_A131EstadosSolId, H00L913_A130EstadosSolTipo, H00L913_A688SolicitudesLiqProf, H00L913_n688SolicitudesLiqProf, H00L913_A184SolicitudesFechaInstalacion, H00L913_A120ProfesionalesId,
               H00L913_A438SolicitudServicioOrigenPago, H00L913_n438SolicitudServicioOrigenPago, H00L913_A796SolicitudesComisionMetodoPago, H00L913_A212SolicitudesCotizacion, H00L913_A1016SolicitudesDescuentoCupon, H00L913_A897SolicitudesDescuento, H00L913_n897SolicitudesDescuento, H00L913_A527SolicitudServicioComProv, H00L913_n527SolicitudServicioComProv, H00L913_A530SolicitudServicioComALM,
               H00L913_n530SolicitudServicioComALM, H00L913_A865SolicitudesCostoXZComAlm, H00L913_n865SolicitudesCostoXZComAlm, H00L913_A864SolicitudesCostoXZona
               }
            }
         );
         /* GeneXus formulas. */
         edtavGridwalletid_Enabled = 0;
         edtavSaldoacreedor_Enabled = 0;
         edtavSaldodeudor_Enabled = 0;
         edtavGridwalletnombre_Enabled = 0;
         edtavWalletcodrefencia_Enabled = 0;
         edtavWalletid_Enabled = 0;
         edtavWalletnombre_Enabled = 0;
         edtavWalletsaldo_Enabled = 0;
         edtavWalletbalancesid_Enabled = 0;
         edtavWalletbalancesfechaalta_Enabled = 0;
         edtavWalletbalancesimporte_Enabled = 0;
         cmbavWalletbalancestipomov.Enabled = 0;
         cmbavWalletbalancesconcepto.Enabled = 0;
         edtavWalletbalancesobs_Enabled = 0;
         edtavWalletbalancesopeid_Enabled = 0;
         cmbavWalletbalancesestadoope.Enabled = 0;
         edtavTotalsolicitudes_Enabled = 0;
         edtavTotalnetoapagar_Enabled = 0;
         edtavTotalajusteswallet_Enabled = 0;
         edtavCantidadregistros_Enabled = 0;
         edtavCantidadajustes_Enabled = 0;
      }

      private short GRIDWALLET_nEOF ;
      private short GRIDWALLETBALANCES_nEOF ;
      private short GRIDPREVIA_nEOF ;
      private short GRIDHISTORIAL_nEOF ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short AV13ActionsWallet ;
      private short A1010WalletBalancesConcepto ;
      private short AV12Actions ;
      private short AV49WalletBalancesConcepto ;
      private short nDonePA ;
      private short subGridwallet_Backcolorstyle ;
      private short subGridhistorial_Backcolorstyle ;
      private short subGridprevia_Backcolorstyle ;
      private short subGridwalletbalances_Backcolorstyle ;
      private short AV17CantidadRegistros ;
      private short AV16CantidadAjustes ;
      private short AV88GXLvl41 ;
      private short AV74PosW ;
      private short AV75AnioSeleccionado ;
      private short AV76SemSeleccionada ;
      private short AV67DowPJ ;
      private short AV77DiasASumar ;
      private short AV61i ;
      private short AV62Dow ;
      private short AV70AnioISO ;
      private short AV69NroSemanaISO ;
      private short subGridwallet_Backstyle ;
      private short subGridwalletbalances_Backstyle ;
      private short subGridprevia_Backstyle ;
      private short subGridhistorial_Backstyle ;
      private short subGridwallet_Titlebackstyle ;
      private short subGridwallet_Allowselection ;
      private short subGridwallet_Allowhovering ;
      private short subGridwallet_Allowcollapsing ;
      private short subGridwallet_Collapsed ;
      private short subGridwalletbalances_Titlebackstyle ;
      private short subGridwalletbalances_Allowselection ;
      private short subGridwalletbalances_Allowhovering ;
      private short subGridwalletbalances_Allowcollapsing ;
      private short subGridwalletbalances_Collapsed ;
      private short subGridprevia_Titlebackstyle ;
      private short subGridprevia_Allowselection ;
      private short subGridprevia_Allowhovering ;
      private short subGridprevia_Allowcollapsing ;
      private short subGridprevia_Collapsed ;
      private short subGridhistorial_Titlebackstyle ;
      private short subGridhistorial_Allowselection ;
      private short subGridhistorial_Allowhovering ;
      private short subGridhistorial_Allowcollapsing ;
      private short subGridhistorial_Collapsed ;
      private int Gridhistorialpaginationbar_Rowsperpageselectedvalue ;
      private int Gridwalletpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_35 ;
      private int nRC_GXsfl_100 ;
      private int nRC_GXsfl_118 ;
      private int nRC_GXsfl_140 ;
      private int subGridwallet_Rows ;
      private int subGridwalletbalances_Rows ;
      private int subGridprevia_Rows ;
      private int subGridhistorial_Rows ;
      private int nGXsfl_35_idx=1 ;
      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private int nGXsfl_100_idx=1 ;
      private int nGXsfl_118_idx=1 ;
      private int nGXsfl_140_idx=1 ;
      private int Gridwalletpaginationbar_Pagestoshow ;
      private int Gridhistorialpaginationbar_Pagestoshow ;
      private int Gxuitabspanel_tabsliquidacion_Pagecount ;
      private int edtavBuscarcuenta_Enabled ;
      private int edtavFechadesde_Enabled ;
      private int edtavFechahasta_Enabled ;
      private int divTablecontent_Visible ;
      private int edtavGridwalletcurrentpage_Visible ;
      private int edtavGridhistorialcurrentpage_Visible ;
      private int subGridwallet_Islastpage ;
      private int subGridhistorial_Islastpage ;
      private int subGridprevia_Islastpage ;
      private int subGridwalletbalances_Islastpage ;
      private int edtavGridwalletid_Enabled ;
      private int edtavSaldoacreedor_Enabled ;
      private int edtavSaldodeudor_Enabled ;
      private int edtavGridwalletnombre_Enabled ;
      private int edtavWalletcodrefencia_Enabled ;
      private int edtavWalletid_Enabled ;
      private int edtavWalletnombre_Enabled ;
      private int edtavWalletsaldo_Enabled ;
      private int edtavWalletbalancesid_Enabled ;
      private int edtavWalletbalancesfechaalta_Enabled ;
      private int edtavWalletbalancesimporte_Enabled ;
      private int edtavWalletbalancesobs_Enabled ;
      private int edtavWalletbalancesopeid_Enabled ;
      private int edtavTotalsolicitudes_Enabled ;
      private int edtavTotalnetoapagar_Enabled ;
      private int edtavTotalajusteswallet_Enabled ;
      private int edtavCantidadregistros_Enabled ;
      private int edtavCantidadajustes_Enabled ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private int edtWalletCodRefencia_Enabled ;
      private int edtWalletNombre_Enabled ;
      private int edtWalletTotalCredito_Enabled ;
      private int edtWalletTotalDebito_Enabled ;
      private int edtWalletSaldo_Enabled ;
      private int edtWalletSolicitudesPendientes_Enabled ;
      private int edtWalletId_Enabled ;
      private int edtWalletBalancesId_Enabled ;
      private int edtWalletBalancesFechaAlta_Enabled ;
      private int edtWalletBalancesImporte_Enabled ;
      private int edtWalletBalancesObs_Enabled ;
      private int edtWalletBalancesUrl_Enabled ;
      private int edtSolicitudesID_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtSolicitudesFechaInstalacion_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtSolicitudServicioComALM_Enabled ;
      private int edtSolicitudServicioComPro_Enabled ;
      private int edtSolicitudesCostoXZComAlm_Enabled ;
      private int edtSolicitudesCostoXZComProf_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int AV42PageToGo ;
      private int nGXsfl_100_fel_idx=1 ;
      private int idxLst ;
      private int subGridwallet_Backcolor ;
      private int subGridwallet_Allbackcolor ;
      private int subGridwalletbalances_Backcolor ;
      private int subGridwalletbalances_Allbackcolor ;
      private int subGridprevia_Backcolor ;
      private int subGridprevia_Allbackcolor ;
      private int subGridhistorial_Backcolor ;
      private int subGridhistorial_Allbackcolor ;
      private int subGridwallet_Titlebackcolor ;
      private int subGridwallet_Selectedindex ;
      private int subGridwallet_Selectioncolor ;
      private int subGridwallet_Hoveringcolor ;
      private int subGridwalletbalances_Titlebackcolor ;
      private int subGridwalletbalances_Selectedindex ;
      private int subGridwalletbalances_Selectioncolor ;
      private int subGridwalletbalances_Hoveringcolor ;
      private int subGridprevia_Titlebackcolor ;
      private int subGridprevia_Selectedindex ;
      private int subGridprevia_Selectioncolor ;
      private int subGridprevia_Hoveringcolor ;
      private int subGridhistorial_Titlebackcolor ;
      private int subGridhistorial_Selectedindex ;
      private int subGridhistorial_Selectioncolor ;
      private int subGridhistorial_Hoveringcolor ;
      private long GRIDWALLET_nFirstRecordOnPage ;
      private long GRIDWALLETBALANCES_nFirstRecordOnPage ;
      private long GRIDPREVIA_nFirstRecordOnPage ;
      private long GRIDHISTORIAL_nFirstRecordOnPage ;
      private long AV33GridWalletId ;
      private long AV56WalletId ;
      private long A688SolicitudesLiqProf ;
      private long AV85UserId ;
      private long AV5OperacionesId ;
      private long A637WalletId ;
      private long A127SolicitudesID ;
      private long AV35GridWalletPageCount ;
      private long AV23GridHistorialPageCount ;
      private long A1012WalletBalanceLiquidacion ;
      private long A554OperacionesId ;
      private long AV32GridWalletCurrentPage ;
      private long AV22GridHistorialCurrentPage ;
      private long A640WalletBalancesId ;
      private long A133ProveedorID ;
      private long AV51WalletBalancesId ;
      private long AV10WalletBalancesOpeId ;
      private long GRIDWALLET_nCurrentRecord ;
      private long GRIDWALLETBALANCES_nCurrentRecord ;
      private long GRIDPREVIA_nCurrentRecord ;
      private long GRIDHISTORIAL_nCurrentRecord ;
      private long GRIDWALLET_nRecordCount ;
      private long GRIDPREVIA_nRecordCount ;
      private long GRIDWALLETBALANCES_nRecordCount ;
      private long GRIDHISTORIAL_nRecordCount ;
      private long AV81OperacionPreviaId ;
      private decimal AV48TotalSolicitudes ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A644WalletBalancesImporte ;
      private decimal A648WalletSaldo ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal A647WalletTotalCredito ;
      private decimal A646WalletTotalDebito ;
      private decimal AV86SaldoAcreedor ;
      private decimal AV87SaldoDeudor ;
      private decimal A1007WalletSolicitudesPendientes ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal AV52WalletBalancesImporte ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal AV58WalletSaldo ;
      private decimal AV47TotalNetoAPagar ;
      private decimal AV45TotalAjustesWallet ;
      private decimal GXt_decimal2 ;
      private decimal AV41NetoFila ;
      private string Gridhistorialpaginationbar_Selectedpage ;
      private string Gridwalletpaginationbar_Selectedpage ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Result ;
      private string Dvelop_confirmpanel_actioncrearwallets_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string AV15BuscarCuenta ;
      private string AV43ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string A130EstadosSolTipo ;
      private string A141EstadoSGTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A643WalletBalancesTipoMov ;
      private string AV9ProfesionalesNombre ;
      private string sGXsfl_100_idx="0001" ;
      private string A715WalletNombre ;
      private string sGXsfl_118_idx="0001" ;
      private string A639WalletCodRefencia ;
      private string sGXsfl_140_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A555OperacionesRef ;
      private string A577OperacionesEstado ;
      private string A638WalletTipoEntidad ;
      private string A649OperacionesTipo ;
      private string Gridwalletpaginationbar_Class ;
      private string Gridwalletpaginationbar_Pagingbuttonsposition ;
      private string Gridwalletpaginationbar_Pagingcaptionposition ;
      private string Gridwalletpaginationbar_Emptygridclass ;
      private string Gridwalletpaginationbar_Rowsperpageoptions ;
      private string Gridwalletpaginationbar_Previous ;
      private string Gridwalletpaginationbar_Next ;
      private string Gridwalletpaginationbar_Caption ;
      private string Gridwalletpaginationbar_Emptygridcaption ;
      private string Gridwalletpaginationbar_Rowsperpagecaption ;
      private string Dvpanel_panelbuscadorcuentas_Width ;
      private string Dvpanel_panelbuscadorcuentas_Cls ;
      private string Dvpanel_panelbuscadorcuentas_Title ;
      private string Dvpanel_panelbuscadorcuentas_Iconposition ;
      private string Gridhistorialpaginationbar_Class ;
      private string Gridhistorialpaginationbar_Pagingbuttonsposition ;
      private string Gridhistorialpaginationbar_Pagingcaptionposition ;
      private string Gridhistorialpaginationbar_Emptygridclass ;
      private string Gridhistorialpaginationbar_Rowsperpageoptions ;
      private string Gridhistorialpaginationbar_Previous ;
      private string Gridhistorialpaginationbar_Next ;
      private string Gridhistorialpaginationbar_Caption ;
      private string Gridhistorialpaginationbar_Emptygridcaption ;
      private string Gridhistorialpaginationbar_Rowsperpagecaption ;
      private string Gxuitabspanel_tabsliquidacion_Class ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Title ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Confirmationtext ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Confirmtype ;
      private string Dvelop_confirmpanel_actioncrearwallets_Title ;
      private string Dvelop_confirmpanel_actioncrearwallets_Confirmationtext ;
      private string Dvelop_confirmpanel_actioncrearwallets_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_actioncrearwallets_Nobuttoncaption ;
      private string Dvelop_confirmpanel_actioncrearwallets_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_actioncrearwallets_Yesbuttonposition ;
      private string Dvelop_confirmpanel_actioncrearwallets_Confirmtype ;
      private string Gridhistorial_empowerer_Gridinternalname ;
      private string Gridhistorial_empowerer_Fixedcolumns ;
      private string Gridprevia_empowerer_Gridinternalname ;
      private string Gridprevia_empowerer_Infinitescrolling ;
      private string Gridwalletbalances_empowerer_Gridinternalname ;
      private string Gridwallet_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_panelbuscadorcuentas_Internalname ;
      private string divPanelbuscadorcuentas_Internalname ;
      private string TempTags ;
      private string bttBtnactioncrearwallets_Internalname ;
      private string bttBtnactioncrearwallets_Jsonclick ;
      private string chkavTodoslosprofesionales_Internalname ;
      private string edtavBuscarcuenta_Internalname ;
      private string edtavBuscarcuenta_Jsonclick ;
      private string divGridwallettablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridwallet_Internalname ;
      private string Gridwalletpaginationbar_Internalname ;
      private string divTablefiltros_Internalname ;
      private string cmbavOperacionesperiodocod_Internalname ;
      private string cmbavOperacionesperiodocod_Jsonclick ;
      private string edtavFechadesde_Internalname ;
      private string edtavFechadesde_Jsonclick ;
      private string edtavFechahasta_Internalname ;
      private string edtavFechahasta_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabsliquidacion_Internalname ;
      private string lblTabwallet_title_Internalname ;
      private string lblTabwallet_title_Jsonclick ;
      private string divTablewalletcontainer_Internalname ;
      private string subGridwalletbalances_Internalname ;
      private string lblTabsolicitudes_title_Internalname ;
      private string lblTabsolicitudes_title_Jsonclick ;
      private string divTablesolicitudes_Internalname ;
      private string subGridprevia_Internalname ;
      private string lblTabhistorial_title_Internalname ;
      private string lblTabhistorial_title_Jsonclick ;
      private string divTablehistorial_Internalname ;
      private string divGridhistorialtablewithpaginationbar_Internalname ;
      private string subGridhistorial_Internalname ;
      private string Gridhistorialpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGridwalletcurrentpage_Internalname ;
      private string edtavGridwalletcurrentpage_Jsonclick ;
      private string edtavGridhistorialcurrentpage_Internalname ;
      private string edtavGridhistorialcurrentpage_Jsonclick ;
      private string Gridhistorial_empowerer_Internalname ;
      private string Gridprevia_empowerer_Internalname ;
      private string Gridwalletbalances_empowerer_Internalname ;
      private string Gridwallet_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavActionswallet_Internalname ;
      private string edtavGridwalletid_Internalname ;
      private string edtWalletCodRefencia_Internalname ;
      private string edtWalletNombre_Internalname ;
      private string edtWalletTotalCredito_Internalname ;
      private string edtWalletTotalDebito_Internalname ;
      private string edtWalletSaldo_Internalname ;
      private string edtavSaldoacreedor_Internalname ;
      private string edtavSaldodeudor_Internalname ;
      private string edtWalletSolicitudesPendientes_Internalname ;
      private string AV34GridWalletNombre ;
      private string edtavGridwalletnombre_Internalname ;
      private string chkavIncluirbalance_Internalname ;
      private string edtWalletId_Internalname ;
      private string edtWalletBalancesId_Internalname ;
      private string edtWalletBalancesFechaAlta_Internalname ;
      private string edtWalletBalancesImporte_Internalname ;
      private string cmbWalletBalancesTipoMov_Internalname ;
      private string cmbWalletBalancesConcepto_Internalname ;
      private string edtWalletBalancesObs_Internalname ;
      private string cmbWalletBalancesEstadoOPE_Internalname ;
      private string A645WalletBalancesEstadoOPE ;
      private string edtWalletBalancesUrl_Internalname ;
      private string edtSolicitudesID_Internalname ;
      private string edtProfesionalesId_Internalname ;
      private string edtSolicitudesFechaInstalacion_Internalname ;
      private string edtEstadosSolId_Internalname ;
      private string edtProveedorID_Internalname ;
      private string cmbSolicitudServicioOrigenPago_Internalname ;
      private string edtSolicitudServicioComALM_Internalname ;
      private string edtSolicitudServicioComPro_Internalname ;
      private string edtSolicitudesCostoXZComAlm_Internalname ;
      private string edtSolicitudesCostoXZComProf_Internalname ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string cmbavActions_Internalname ;
      private string edtavWalletbalancesid_Internalname ;
      private string edtavWalletbalancesfechaalta_Internalname ;
      private string edtavWalletbalancesimporte_Internalname ;
      private string cmbavWalletbalancestipomov_Internalname ;
      private string AV54WalletBalancesTipoMov ;
      private string cmbavWalletbalancesconcepto_Internalname ;
      private string edtavWalletbalancesobs_Internalname ;
      private string edtavWalletbalancesopeid_Internalname ;
      private string cmbavWalletbalancesestadoope_Internalname ;
      private string AV80WalletBalancesEstadoOPE ;
      private string GXCCtl ;
      private string edtavWalletcodrefencia_Internalname ;
      private string edtavWalletid_Internalname ;
      private string edtavWalletnombre_Internalname ;
      private string edtavWalletsaldo_Internalname ;
      private string edtavTotalsolicitudes_Internalname ;
      private string edtavTotalnetoapagar_Internalname ;
      private string edtavTotalajusteswallet_Internalname ;
      private string edtavCantidadregistros_Internalname ;
      private string edtavCantidadajustes_Internalname ;
      private string AV55WalletCodRefencia ;
      private string AV57WalletNombre ;
      private string GXt_char1 ;
      private string edtavSaldodeudor_Columnheaderclass ;
      private string edtavSaldodeudor_Columnclass ;
      private string Dvelop_confirmpanel_btnbtnliquidar_Internalname ;
      private string sGXsfl_100_fel_idx="0001" ;
      private string AV8OperacionesTipo ;
      private string AV7OperacionesRef ;
      private string AV6OperacionesNombreRef ;
      private string Gx_msg ;
      private string GXEncryptionTmp ;
      private string edtWalletBalancesUrl_Linktarget ;
      private string edtWalletBalancesUrl_Link ;
      private string tblTabledvelop_confirmpanel_actioncrearwallets_Internalname ;
      private string Dvelop_confirmpanel_actioncrearwallets_Internalname ;
      private string tblTabledvelop_confirmpanel_btnbtnliquidar_Internalname ;
      private string tblTableactions_Internalname ;
      private string bttBtnbtnliquidar_Internalname ;
      private string bttBtnbtnliquidar_Jsonclick ;
      private string bttBtnbtncancelar_Internalname ;
      private string bttBtnbtncancelar_Jsonclick ;
      private string tblTabletotales_Internalname ;
      private string divUnnamedtabletotalsolicitudes_Internalname ;
      private string lblTextblocktotalsolicitudes_Internalname ;
      private string lblTextblocktotalsolicitudes_Jsonclick ;
      private string edtavTotalsolicitudes_Jsonclick ;
      private string divUnnamedtabletotalnetoapagar_Internalname ;
      private string lblTextblocktotalnetoapagar_Internalname ;
      private string lblTextblocktotalnetoapagar_Jsonclick ;
      private string edtavTotalnetoapagar_Jsonclick ;
      private string divUnnamedtabletotalajusteswallet_Internalname ;
      private string lblTextblocktotalajusteswallet_Internalname ;
      private string lblTextblocktotalajusteswallet_Jsonclick ;
      private string edtavTotalajusteswallet_Jsonclick ;
      private string divUnnamedtablecantidadregistros_Internalname ;
      private string lblTextblockcantidadregistros_Internalname ;
      private string lblTextblockcantidadregistros_Jsonclick ;
      private string edtavCantidadregistros_Jsonclick ;
      private string divUnnamedtablecantidadajustes_Internalname ;
      private string lblTextblockcantidadajustes_Internalname ;
      private string lblTextblockcantidadajustes_Jsonclick ;
      private string edtavCantidadajustes_Jsonclick ;
      private string tblTablewalletheader_Internalname ;
      private string edtavWalletcodrefencia_Jsonclick ;
      private string edtavWalletid_Jsonclick ;
      private string edtavWalletnombre_Jsonclick ;
      private string edtavWalletsaldo_Jsonclick ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGridwallet_Class ;
      private string subGridwallet_Linesclass ;
      private string cmbavActionswallet_Jsonclick ;
      private string ROClassString ;
      private string edtavGridwalletid_Jsonclick ;
      private string edtWalletCodRefencia_Jsonclick ;
      private string edtWalletNombre_Jsonclick ;
      private string edtWalletTotalCredito_Jsonclick ;
      private string edtWalletTotalDebito_Jsonclick ;
      private string edtWalletSaldo_Jsonclick ;
      private string edtavSaldoacreedor_Jsonclick ;
      private string edtavSaldodeudor_Jsonclick ;
      private string edtWalletSolicitudesPendientes_Jsonclick ;
      private string edtavGridwalletnombre_Jsonclick ;
      private string subGridwalletbalances_Class ;
      private string subGridwalletbalances_Linesclass ;
      private string edtWalletId_Jsonclick ;
      private string edtWalletBalancesId_Jsonclick ;
      private string edtWalletBalancesFechaAlta_Jsonclick ;
      private string edtWalletBalancesImporte_Jsonclick ;
      private string cmbWalletBalancesTipoMov_Jsonclick ;
      private string cmbWalletBalancesConcepto_Jsonclick ;
      private string edtWalletBalancesObs_Jsonclick ;
      private string cmbWalletBalancesEstadoOPE_Jsonclick ;
      private string edtWalletBalancesUrl_Jsonclick ;
      private string sGXsfl_118_fel_idx="0001" ;
      private string subGridprevia_Class ;
      private string subGridprevia_Linesclass ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtSolicitudesFechaInstalacion_Jsonclick ;
      private string edtEstadosSolId_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string cmbSolicitudServicioOrigenPago_Jsonclick ;
      private string edtSolicitudServicioComALM_Jsonclick ;
      private string edtSolicitudServicioComPro_Jsonclick ;
      private string edtSolicitudesCostoXZComAlm_Jsonclick ;
      private string edtSolicitudesCostoXZComProf_Jsonclick ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string sGXsfl_140_fel_idx="0001" ;
      private string subGridhistorial_Class ;
      private string subGridhistorial_Linesclass ;
      private string cmbavActions_Jsonclick ;
      private string edtavWalletbalancesid_Jsonclick ;
      private string edtavWalletbalancesfechaalta_Jsonclick ;
      private string edtavWalletbalancesimporte_Jsonclick ;
      private string cmbavWalletbalancestipomov_Jsonclick ;
      private string cmbavWalletbalancesconcepto_Jsonclick ;
      private string edtavWalletbalancesobs_Jsonclick ;
      private string edtavWalletbalancesopeid_Jsonclick ;
      private string cmbavWalletbalancesestadoope_Jsonclick ;
      private string subGridwallet_Header ;
      private string subGridwalletbalances_Header ;
      private string subGridprevia_Header ;
      private string subGridhistorial_Header ;
      private DateTime A641WalletBalancesFechaAlta ;
      private DateTime AV50WalletBalancesFechaAlta ;
      private DateTime AV18FechaDesde ;
      private DateTime AV19FechaHasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV66PrimerJueves ;
      private DateTime AV65JuevesSemana ;
      private DateTime AV63LunesSemana ;
      private DateTime AV64DomingoSemana ;
      private DateTime AV73FechaDesdeSugerida ;
      private DateTime AV72FechaHastaSugerida ;
      private DateTime AV60PeriodoFechaPivot ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV44TodosLosProfesionales ;
      private bool n688SolicitudesLiqProf ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool AV37IncluirBalance ;
      private bool Gridwalletpaginationbar_Showfirst ;
      private bool Gridwalletpaginationbar_Showprevious ;
      private bool Gridwalletpaginationbar_Shownext ;
      private bool Gridwalletpaginationbar_Showlast ;
      private bool Gridwalletpaginationbar_Rowsperpageselector ;
      private bool Dvpanel_panelbuscadorcuentas_Autowidth ;
      private bool Dvpanel_panelbuscadorcuentas_Autoheight ;
      private bool Dvpanel_panelbuscadorcuentas_Collapsible ;
      private bool Dvpanel_panelbuscadorcuentas_Collapsed ;
      private bool Dvpanel_panelbuscadorcuentas_Showcollapseicon ;
      private bool Dvpanel_panelbuscadorcuentas_Autoscroll ;
      private bool Gridhistorialpaginationbar_Showfirst ;
      private bool Gridhistorialpaginationbar_Showprevious ;
      private bool Gridhistorialpaginationbar_Shownext ;
      private bool Gridhistorialpaginationbar_Showlast ;
      private bool Gridhistorialpaginationbar_Rowsperpageselector ;
      private bool Gxuitabspanel_tabsliquidacion_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n1010WalletBalancesConcepto ;
      private bool n1009WalletBalancesObs ;
      private bool n1011WalletBalancesUrl ;
      private bool n530SolicitudServicioComALM ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_140_Refreshing=false ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n527SolicitudServicioComProv ;
      private bool n897SolicitudesDescuento ;
      private bool bGXsfl_118_Refreshing=false ;
      private bool bGXsfl_100_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool n577OperacionesEstado ;
      private bool n1028OperacionesPeriodoCod ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool AV40IsOk ;
      private bool AV78Ok ;
      private string AV27GridWalletAppliedFilters ;
      private string AV21GridHistorialAppliedFilters ;
      private string A1028OperacionesPeriodoCod ;
      private string AV59OperacionesPeriodoCod ;
      private string A1009WalletBalancesObs ;
      private string A1011WalletBalancesUrl ;
      private string AV53WalletBalancesObs ;
      private string AV20Filename ;
      private string AV79Mensaje ;
      private string AV71CodSemana ;
      private string AV68DescSemana ;
      private GXWebGrid GridwalletContainer ;
      private GXWebGrid GridwalletbalancesContainer ;
      private GXWebGrid GridpreviaContainer ;
      private GXWebGrid GridhistorialContainer ;
      private GXWebRow GridwalletRow ;
      private GXWebRow GridhistorialRow ;
      private GXWebRow GridpreviaRow ;
      private GXWebRow GridwalletbalancesRow ;
      private GXWebColumn GridwalletColumn ;
      private GXWebColumn GridwalletbalancesColumn ;
      private GXWebColumn GridpreviaColumn ;
      private GXWebColumn GridhistorialColumn ;
      private GXUserControl ucDvpanel_panelbuscadorcuentas ;
      private GXUserControl ucGridwalletpaginationbar ;
      private GXUserControl ucGxuitabspanel_tabsliquidacion ;
      private GXUserControl ucGridhistorialpaginationbar ;
      private GXUserControl ucGridhistorial_empowerer ;
      private GXUserControl ucGridprevia_empowerer ;
      private GXUserControl ucGridwalletbalances_empowerer ;
      private GXUserControl ucGridwallet_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_btnbtnliquidar ;
      private GXUserControl ucDvelop_confirmpanel_actioncrearwallets ;
      private GXWebForm Form ;
      private GXWindow AV11Window ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavTodoslosprofesionales ;
      private GXCombobox cmbavActionswallet ;
      private GXCombobox cmbavOperacionesperiodocod ;
      private GXCheckbox chkavIncluirbalance ;
      private GXCombobox cmbWalletBalancesTipoMov ;
      private GXCombobox cmbWalletBalancesConcepto ;
      private GXCombobox cmbWalletBalancesEstadoOPE ;
      private GXCombobox cmbSolicitudServicioOrigenPago ;
      private GXCombobox cmbavActions ;
      private GXCombobox cmbavWalletbalancestipomov ;
      private GXCombobox cmbavWalletbalancesconcepto ;
      private GXCombobox cmbavWalletbalancesestadoope ;
      private IDataStoreProvider pr_default ;
      private long[] H00L92_A127SolicitudesID ;
      private short[] H00L92_A134SolicitudesItemsID ;
      private decimal[] H00L92_A180SolicitudItemsComision ;
      private string[] H00L92_A179SolicitudItemsComisionTipo ;
      private string[] H00L92_A178SolicitudItemsSR ;
      private short[] H00L92_A177SolicitudesItemsCantidad ;
      private decimal[] H00L92_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00L92_n176SolicitudesItemsPrecioFinal ;
      private string[] H00L93_A638WalletTipoEntidad ;
      private long[] H00L93_A637WalletId ;
      private string[] H00L93_A639WalletCodRefencia ;
      private string[] H00L94_A638WalletTipoEntidad ;
      private long[] H00L94_A637WalletId ;
      private string[] H00L94_A639WalletCodRefencia ;
      private short[] H00L95_A1010WalletBalancesConcepto ;
      private bool[] H00L95_n1010WalletBalancesConcepto ;
      private string[] H00L95_A645WalletBalancesEstadoOPE ;
      private long[] H00L95_A637WalletId ;
      private DateTime[] H00L95_A641WalletBalancesFechaAlta ;
      private decimal[] H00L95_A644WalletBalancesImporte ;
      private string[] H00L95_A643WalletBalancesTipoMov ;
      private string[] H00L95_A1009WalletBalancesObs ;
      private bool[] H00L95_n1009WalletBalancesObs ;
      private long[] H00L95_A1012WalletBalanceLiquidacion ;
      private bool[] H00L95_n1012WalletBalanceLiquidacion ;
      private long[] H00L95_A640WalletBalancesId ;
      private long[] H00L96_A140RelacionesId ;
      private int[] H00L96_A142EstadoSGId ;
      private string[] H00L96_A141EstadoSGTipo ;
      private string[] H00L96_A130EstadosSolTipo ;
      private long[] H00L96_A688SolicitudesLiqProf ;
      private bool[] H00L96_n688SolicitudesLiqProf ;
      private string[] H00L96_A438SolicitudServicioOrigenPago ;
      private bool[] H00L96_n438SolicitudServicioOrigenPago ;
      private long[] H00L96_A133ProveedorID ;
      private int[] H00L96_A131EstadosSolId ;
      private DateTime[] H00L96_A184SolicitudesFechaInstalacion ;
      private string[] H00L96_A120ProfesionalesId ;
      private long[] H00L96_A127SolicitudesID ;
      private decimal[] H00L96_A527SolicitudServicioComProv ;
      private bool[] H00L96_n527SolicitudServicioComProv ;
      private decimal[] H00L96_A530SolicitudServicioComALM ;
      private bool[] H00L96_n530SolicitudServicioComALM ;
      private decimal[] H00L96_A865SolicitudesCostoXZComAlm ;
      private bool[] H00L96_n865SolicitudesCostoXZComAlm ;
      private decimal[] H00L96_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00L96_A212SolicitudesCotizacion ;
      private decimal[] H00L96_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00L96_A897SolicitudesDescuento ;
      private bool[] H00L96_n897SolicitudesDescuento ;
      private decimal[] H00L96_A864SolicitudesCostoXZona ;
      private long[] H00L97_A140RelacionesId ;
      private int[] H00L97_A142EstadoSGId ;
      private string[] H00L97_A141EstadoSGTipo ;
      private string[] H00L97_A130EstadosSolTipo ;
      private long[] H00L97_A688SolicitudesLiqProf ;
      private bool[] H00L97_n688SolicitudesLiqProf ;
      private string[] H00L97_A438SolicitudServicioOrigenPago ;
      private bool[] H00L97_n438SolicitudServicioOrigenPago ;
      private long[] H00L97_A133ProveedorID ;
      private int[] H00L97_A131EstadosSolId ;
      private DateTime[] H00L97_A184SolicitudesFechaInstalacion ;
      private string[] H00L97_A120ProfesionalesId ;
      private long[] H00L97_A127SolicitudesID ;
      private decimal[] H00L97_A527SolicitudServicioComProv ;
      private bool[] H00L97_n527SolicitudServicioComProv ;
      private decimal[] H00L97_A530SolicitudServicioComALM ;
      private bool[] H00L97_n530SolicitudServicioComALM ;
      private decimal[] H00L97_A865SolicitudesCostoXZComAlm ;
      private bool[] H00L97_n865SolicitudesCostoXZComAlm ;
      private decimal[] H00L97_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00L97_A212SolicitudesCotizacion ;
      private decimal[] H00L97_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00L97_A897SolicitudesDescuento ;
      private bool[] H00L97_n897SolicitudesDescuento ;
      private decimal[] H00L97_A864SolicitudesCostoXZona ;
      private string[] H00L98_A639WalletCodRefencia ;
      private string[] H00L98_A1011WalletBalancesUrl ;
      private bool[] H00L98_n1011WalletBalancesUrl ;
      private string[] H00L98_A645WalletBalancesEstadoOPE ;
      private string[] H00L98_A1009WalletBalancesObs ;
      private bool[] H00L98_n1009WalletBalancesObs ;
      private short[] H00L98_A1010WalletBalancesConcepto ;
      private bool[] H00L98_n1010WalletBalancesConcepto ;
      private string[] H00L98_A643WalletBalancesTipoMov ;
      private decimal[] H00L98_A644WalletBalancesImporte ;
      private DateTime[] H00L98_A641WalletBalancesFechaAlta ;
      private long[] H00L98_A640WalletBalancesId ;
      private long[] H00L98_A637WalletId ;
      private string[] H00L99_A639WalletCodRefencia ;
      private string[] H00L99_A1011WalletBalancesUrl ;
      private bool[] H00L99_n1011WalletBalancesUrl ;
      private string[] H00L99_A645WalletBalancesEstadoOPE ;
      private string[] H00L99_A1009WalletBalancesObs ;
      private bool[] H00L99_n1009WalletBalancesObs ;
      private short[] H00L99_A1010WalletBalancesConcepto ;
      private bool[] H00L99_n1010WalletBalancesConcepto ;
      private string[] H00L99_A643WalletBalancesTipoMov ;
      private decimal[] H00L99_A644WalletBalancesImporte ;
      private DateTime[] H00L99_A641WalletBalancesFechaAlta ;
      private long[] H00L99_A640WalletBalancesId ;
      private long[] H00L99_A637WalletId ;
      private long[] H00L910_AGRIDHISTORIAL_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV84Context ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext3 ;
      private long[] H00L911_A637WalletId ;
      private string[] H00L911_A639WalletCodRefencia ;
      private string[] H00L911_A638WalletTipoEntidad ;
      private string[] H00L912_A577OperacionesEstado ;
      private bool[] H00L912_n577OperacionesEstado ;
      private string[] H00L912_A1028OperacionesPeriodoCod ;
      private bool[] H00L912_n1028OperacionesPeriodoCod ;
      private string[] H00L912_A649OperacionesTipo ;
      private bool[] H00L912_n649OperacionesTipo ;
      private string[] H00L912_A555OperacionesRef ;
      private bool[] H00L912_n555OperacionesRef ;
      private long[] H00L912_A554OperacionesId ;
      private GxSimpleCollection<long> AV14BalancesSeleccionados ;
      private long[] H00L913_A140RelacionesId ;
      private long[] H00L913_A127SolicitudesID ;
      private int[] H00L913_A142EstadoSGId ;
      private string[] H00L913_A141EstadoSGTipo ;
      private int[] H00L913_A131EstadosSolId ;
      private string[] H00L913_A130EstadosSolTipo ;
      private long[] H00L913_A688SolicitudesLiqProf ;
      private bool[] H00L913_n688SolicitudesLiqProf ;
      private DateTime[] H00L913_A184SolicitudesFechaInstalacion ;
      private string[] H00L913_A120ProfesionalesId ;
      private string[] H00L913_A438SolicitudServicioOrigenPago ;
      private bool[] H00L913_n438SolicitudServicioOrigenPago ;
      private decimal[] H00L913_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00L913_A212SolicitudesCotizacion ;
      private decimal[] H00L913_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00L913_A897SolicitudesDescuento ;
      private bool[] H00L913_n897SolicitudesDescuento ;
      private decimal[] H00L913_A527SolicitudServicioComProv ;
      private bool[] H00L913_n527SolicitudServicioComProv ;
      private decimal[] H00L913_A530SolicitudServicioComALM ;
      private bool[] H00L913_n530SolicitudServicioComALM ;
      private decimal[] H00L913_A865SolicitudesCostoXZComAlm ;
      private bool[] H00L913_n865SolicitudesCostoXZComAlm ;
      private decimal[] H00L913_A864SolicitudesCostoXZona ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpliquidacioncentro__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00L95( IGxContext context ,
                                             string AV43ProfesionalesId ,
                                             bool AV44TodosLosProfesionales ,
                                             long A637WalletId ,
                                             long AV56WalletId ,
                                             string A645WalletBalancesEstadoOPE ,
                                             short A1010WalletBalancesConcepto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [WalletBalancesConcepto], [WalletBalancesEstadoOPE], [WalletId], [WalletBalancesFechaAlta], [WalletBalancesImporte], [WalletBalancesTipoMov], [WalletBalancesObs], [WalletBalanceLiquidacion], [WalletBalancesId]";
         sFromString = " FROM [WalletBalances]";
         sOrderString = "";
         AddWhere(sWhereString, "([WalletBalancesEstadoOPE] <> 'ANU')");
         AddWhere(sWhereString, "([WalletBalancesConcepto] = 5)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) && ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "([WalletId] = @AV56WalletId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         sOrderString += " ORDER BY [WalletBalancesId] DESC";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom4" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo4" + " > 0 THEN " + "@GXPagingTo4" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00L96( IGxContext context ,
                                             int A131EstadosSolId ,
                                             DateTime AV18FechaDesde ,
                                             DateTime AV19FechaHasta ,
                                             string AV43ProfesionalesId ,
                                             bool AV44TodosLosProfesionales ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             string A120ProfesionalesId ,
                                             long A688SolicitudesLiqProf ,
                                             string A130EstadosSolTipo ,
                                             string A141EstadoSGTipo ,
                                             int A142EstadoSGId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[3];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[RelacionesId], T1.[EstadoSGId], T1.[EstadoSGTipo], T2.[EstadosSolTipo], T2.[SolicitudesLiqProf], T2.[SolicitudServicioOrigenPago], T2.[ProveedorID], T2.[EstadosSolId], T2.[SolicitudesFechaInstalacion], T1.[ProfesionalesId], T1.[SolicitudesID], T2.[SolicitudServicioComProv], T2.[SolicitudServicioComALM], T2.[SolicitudesCostoXZComAlm], T2.[SolicitudesComisionMetodoPago], T2.[SolicitudesCotizacion], T2.[SolicitudesDescuentoCupon], T2.[SolicitudesDescuento], T2.[SolicitudesCostoXZona] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID])";
         AddWhere(sWhereString, "(T2.[SolicitudesLiqProf] IS NULL or (T2.[SolicitudesLiqProf] = convert(int, 0)))");
         AddWhere(sWhereString, "(T2.[EstadosSolId] IN (2,5,6,7))");
         AddWhere(sWhereString, "(T1.[EstadoSGId] = 1)");
         if ( ! (DateTime.MinValue==AV18FechaDesde) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] >= @AV18FechaDesde)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV19FechaHasta) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] <= @AV19FechaHasta)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) && ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV43ProfesionalesId)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesID], T1.[RelacionesId]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00L97( IGxContext context ,
                                             int A131EstadosSolId ,
                                             DateTime AV18FechaDesde ,
                                             DateTime AV19FechaHasta ,
                                             string AV43ProfesionalesId ,
                                             bool AV44TodosLosProfesionales ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             string A120ProfesionalesId ,
                                             long A688SolicitudesLiqProf ,
                                             string A130EstadosSolTipo ,
                                             string A141EstadoSGTipo ,
                                             int A142EstadoSGId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[3];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[RelacionesId], T1.[EstadoSGId], T1.[EstadoSGTipo], T2.[EstadosSolTipo], T2.[SolicitudesLiqProf], T2.[SolicitudServicioOrigenPago], T2.[ProveedorID], T2.[EstadosSolId], T2.[SolicitudesFechaInstalacion], T1.[ProfesionalesId], T1.[SolicitudesID], T2.[SolicitudServicioComProv], T2.[SolicitudServicioComALM], T2.[SolicitudesCostoXZComAlm], T2.[SolicitudesComisionMetodoPago], T2.[SolicitudesCotizacion], T2.[SolicitudesDescuentoCupon], T2.[SolicitudesDescuento], T2.[SolicitudesCostoXZona] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID])";
         AddWhere(sWhereString, "(T2.[SolicitudesLiqProf] IS NULL or (T2.[SolicitudesLiqProf] = convert(int, 0)))");
         AddWhere(sWhereString, "(T2.[EstadosSolId] IN (2,5,6,7))");
         AddWhere(sWhereString, "(T1.[EstadoSGId] = 1)");
         if ( ! (DateTime.MinValue==AV18FechaDesde) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] >= @AV18FechaDesde)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV19FechaHasta) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] <= @AV19FechaHasta)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) && ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV43ProfesionalesId)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesID], T1.[RelacionesId]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00L98( IGxContext context ,
                                             string AV43ProfesionalesId ,
                                             bool AV44TodosLosProfesionales ,
                                             string A639WalletCodRefencia ,
                                             string A645WalletBalancesEstadoOPE )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[1];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T2.[WalletCodRefencia], T1.[WalletBalancesUrl], T1.[WalletBalancesEstadoOPE], T1.[WalletBalancesObs], T1.[WalletBalancesConcepto], T1.[WalletBalancesTipoMov], T1.[WalletBalancesImporte], T1.[WalletBalancesFechaAlta], T1.[WalletBalancesId], T1.[WalletId] FROM ([WalletBalances] T1 INNER JOIN [Wallet] T2 ON T2.[WalletId] = T1.[WalletId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) && ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "(T2.[WalletCodRefencia] = @AV43ProfesionalesId)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[WalletBalancesId] DESC";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H00L99( IGxContext context ,
                                             string AV43ProfesionalesId ,
                                             bool AV44TodosLosProfesionales ,
                                             string A639WalletCodRefencia ,
                                             string A645WalletBalancesEstadoOPE )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[1];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T2.[WalletCodRefencia], T1.[WalletBalancesUrl], T1.[WalletBalancesEstadoOPE], T1.[WalletBalancesObs], T1.[WalletBalancesConcepto], T1.[WalletBalancesTipoMov], T1.[WalletBalancesImporte], T1.[WalletBalancesFechaAlta], T1.[WalletBalancesId], T1.[WalletId] FROM ([WalletBalances] T1 INNER JOIN [Wallet] T2 ON T2.[WalletId] = T1.[WalletId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) && ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "(T2.[WalletCodRefencia] = @AV43ProfesionalesId)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[WalletBalancesId] DESC";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H00L910( IGxContext context ,
                                              string AV43ProfesionalesId ,
                                              bool AV44TodosLosProfesionales ,
                                              long A637WalletId ,
                                              long AV56WalletId ,
                                              string A645WalletBalancesEstadoOPE ,
                                              short A1010WalletBalancesConcepto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[1];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [WalletBalances]";
         AddWhere(sWhereString, "([WalletBalancesEstadoOPE] <> 'ANU')");
         AddWhere(sWhereString, "([WalletBalancesConcepto] = 5)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ProfesionalesId)) && ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "([WalletId] = @AV56WalletId)");
         }
         else
         {
            GXv_int14[0] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      protected Object[] conditional_H00L913( IGxContext context ,
                                              int A131EstadosSolId ,
                                              bool AV44TodosLosProfesionales ,
                                              DateTime AV18FechaDesde ,
                                              DateTime AV19FechaHasta ,
                                              string A120ProfesionalesId ,
                                              string AV43ProfesionalesId ,
                                              DateTime A184SolicitudesFechaInstalacion ,
                                              long A688SolicitudesLiqProf ,
                                              string A130EstadosSolTipo ,
                                              string A141EstadoSGTipo ,
                                              int A142EstadoSGId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int16 = new short[3];
         Object[] GXv_Object17 = new Object[2];
         scmdbuf = "SELECT T1.[RelacionesId], T1.[SolicitudesID], T1.[EstadoSGId], T1.[EstadoSGTipo], T2.[EstadosSolId], T2.[EstadosSolTipo], T2.[SolicitudesLiqProf], T2.[SolicitudesFechaInstalacion], T1.[ProfesionalesId], T2.[SolicitudServicioOrigenPago], T2.[SolicitudesComisionMetodoPago], T2.[SolicitudesCotizacion], T2.[SolicitudesDescuentoCupon], T2.[SolicitudesDescuento], T2.[SolicitudServicioComProv], T2.[SolicitudServicioComALM], T2.[SolicitudesCostoXZComAlm], T2.[SolicitudesCostoXZona] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID])";
         AddWhere(sWhereString, "(T2.[SolicitudesLiqProf] IS NULL or (T2.[SolicitudesLiqProf] = convert(int, 0)) or T2.[SolicitudesLiqProf] = 0)");
         AddWhere(sWhereString, "(T2.[EstadosSolId] IN (2,5,6,7))");
         AddWhere(sWhereString, "(T1.[EstadoSGId] = 1)");
         if ( ! AV44TodosLosProfesionales )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV43ProfesionalesId)");
         }
         else
         {
            GXv_int16[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV18FechaDesde) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] >= @AV18FechaDesde)");
         }
         else
         {
            GXv_int16[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV19FechaHasta) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] <= @AV19FechaHasta)");
         }
         else
         {
            GXv_int16[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesID], T1.[RelacionesId]";
         GXv_Object17[0] = scmdbuf;
         GXv_Object17[1] = GXv_int16;
         return GXv_Object17 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H00L95(context, (string)dynConstraints[0] , (bool)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] );
               case 4 :
                     return conditional_H00L96(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] );
               case 5 :
                     return conditional_H00L97(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] );
               case 6 :
                     return conditional_H00L98(context, (string)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 7 :
                     return conditional_H00L99(context, (string)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 8 :
                     return conditional_H00L910(context, (string)dynConstraints[0] , (bool)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] );
               case 11 :
                     return conditional_H00L913(context, (int)dynConstraints[0] , (bool)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] );
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
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00L92;
          prmH00L92 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH00L93;
          prmH00L93 = new Object[] {
          };
          Object[] prmH00L94;
          prmH00L94 = new Object[] {
          };
          Object[] prmH00L911;
          prmH00L911 = new Object[] {
          new ParDef("@AV56WalletId",GXType.Decimal,18,0)
          };
          Object[] prmH00L912;
          prmH00L912 = new Object[] {
          new ParDef("@AV59OperacionesPeriodoCod",GXType.NVarChar,10,0) ,
          new ParDef("@AV43ProfesionalesId",GXType.NChar,20,0)
          };
          Object[] prmH00L95;
          prmH00L95 = new Object[] {
          new ParDef("@AV56WalletId",GXType.Decimal,18,0) ,
          new ParDef("@GXPagingFrom4",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo4",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo4",GXType.Int32,9,0)
          };
          Object[] prmH00L96;
          prmH00L96 = new Object[] {
          new ParDef("@AV18FechaDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FechaHasta",GXType.Date,8,0) ,
          new ParDef("@AV43ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmH00L97;
          prmH00L97 = new Object[] {
          new ParDef("@AV18FechaDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FechaHasta",GXType.Date,8,0) ,
          new ParDef("@AV43ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmH00L98;
          prmH00L98 = new Object[] {
          new ParDef("@AV43ProfesionalesId",GXType.NChar,20,0)
          };
          Object[] prmH00L99;
          prmH00L99 = new Object[] {
          new ParDef("@AV43ProfesionalesId",GXType.NChar,20,0)
          };
          Object[] prmH00L910;
          prmH00L910 = new Object[] {
          new ParDef("@AV56WalletId",GXType.Decimal,18,0)
          };
          Object[] prmH00L913;
          prmH00L913 = new Object[] {
          new ParDef("@AV43ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV18FechaDesde",GXType.Date,8,0) ,
          new ParDef("@AV19FechaHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00L92", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L92,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00L93", "SELECT [WalletTipoEntidad], [WalletId], [WalletCodRefencia] FROM [Wallet] WHERE [WalletTipoEntidad] = 'PRO' ORDER BY [WalletCodRefencia] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L93,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00L94", "SELECT [WalletTipoEntidad], [WalletId], [WalletCodRefencia] FROM [Wallet] WHERE [WalletTipoEntidad] = 'PRO' ORDER BY [WalletCodRefencia] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L94,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00L95", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L95,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00L96", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L96,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00L97", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L97,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00L98", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L98,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00L99", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L99,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00L910", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L910,1, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00L911", "SELECT [WalletId], [WalletCodRefencia], [WalletTipoEntidad] FROM [Wallet] WHERE [WalletId] = @AV56WalletId ORDER BY [WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L911,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00L912", "SELECT [OperacionesEstado], [OperacionesPeriodoCod], [OperacionesTipo], [OperacionesRef], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesEstado] <> 'ANU') AND ([OperacionesPeriodoCod] = @AV59OperacionesPeriodoCod) AND ([OperacionesRef] = @AV43ProfesionalesId) ORDER BY [OperacionesRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L912,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00L913", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00L913,51, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 25);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 25);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((long[]) buf[9])[0] = rslt.getLong(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 1);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((long[]) buf[12])[0] = rslt.getLong(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
                ((bool[]) buf[23])[0] = rslt.wasNull(18);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(19);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 1);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((long[]) buf[12])[0] = rslt.getLong(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
                ((bool[]) buf[23])[0] = rslt.wasNull(18);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(19);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 3);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((long[]) buf[12])[0] = rslt.getLong(10);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 3);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((long[]) buf[12])[0] = rslt.getLong(10);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 25);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(18);
                return;
       }
    }

 }

}

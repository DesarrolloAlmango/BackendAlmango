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
   public class mudanzaww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public mudanzaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mudanzaww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbMudanzaHoraServicio = new GXCombobox();
         cmbMudanzaRgoHoraservicio = new GXCombobox();
         cmbMudanzaPisoDptoOrigen = new GXCombobox();
         cmbMudanzaVehiculoSugerido = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_111 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_111"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_111_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_111_idx = GetPar( "sGXsfl_111_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20MudanzaAsesor1 = GetPar( "MudanzaAsesor1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24MudanzaAsesor2 = GetPar( "MudanzaAsesor2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28MudanzaAsesor3 = GetPar( "MudanzaAsesor3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV135Pgmname = GetPar( "Pgmname");
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV41TFMudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMudanzaId"), "."), 18, MidpointRounding.ToEven));
         AV42TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMudanzaId_To"), "."), 18, MidpointRounding.ToEven));
         AV43TFMudanzaAsesor = GetPar( "TFMudanzaAsesor");
         AV44TFMudanzaAsesor_Sel = GetPar( "TFMudanzaAsesor_Sel");
         AV45TFMudanzaFechaAlta = context.localUtil.ParseDateParm( GetPar( "TFMudanzaFechaAlta"));
         AV46TFMudanzaFechaAlta_To = context.localUtil.ParseDateParm( GetPar( "TFMudanzaFechaAlta_To"));
         AV50TFMudanzaFechaServicio = context.localUtil.ParseDateParm( GetPar( "TFMudanzaFechaServicio"));
         AV51TFMudanzaFechaServicio_To = context.localUtil.ParseDateParm( GetPar( "TFMudanzaFechaServicio_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV117TFMudanzaHoraServicio_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV119TFMudanzaRgoHoraservicio_Sels);
         AV60TFMudanzaDireccionOrigen = GetPar( "TFMudanzaDireccionOrigen");
         AV61TFMudanzaDireccionOrigen_Sel = GetPar( "TFMudanzaDireccionOrigen_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV121TFMudanzaPisoDptoOrigen_Sels);
         AV62TFMudanzaDireccionDestino = GetPar( "TFMudanzaDireccionDestino");
         AV63TFMudanzaDireccionDestino_Sel = GetPar( "TFMudanzaDireccionDestino_Sel");
         AV122TFMudanzaPisoDptoDestino = GetPar( "TFMudanzaPisoDptoDestino");
         AV123TFMudanzaPisoDptoDestino_Sel = GetPar( "TFMudanzaPisoDptoDestino_Sel");
         AV64TFMudanzaDistancia = NumberUtil.Val( GetPar( "TFMudanzaDistancia"), ".");
         AV65TFMudanzaDistancia_To = NumberUtil.Val( GetPar( "TFMudanzaDistancia_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV109TFMudanzaVehiculoSugerido_Sels);
         AV130TFMudanzaPrecioBasexHora = NumberUtil.Val( GetPar( "TFMudanzaPrecioBasexHora"), ".");
         AV131TFMudanzaPrecioBasexHora_To = NumberUtil.Val( GetPar( "TFMudanzaPrecioBasexHora_To"), ".");
         AV68TFMudanzaPeajeCantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "TFMudanzaPeajeCantidad"), "."), 18, MidpointRounding.ToEven));
         AV69TFMudanzaPeajeCantidad_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFMudanzaPeajeCantidad_To"), "."), 18, MidpointRounding.ToEven));
         AV70TFMudanzaPeajevalor = NumberUtil.Val( GetPar( "TFMudanzaPeajevalor"), ".");
         AV71TFMudanzaPeajevalor_To = NumberUtil.Val( GetPar( "TFMudanzaPeajevalor_To"), ".");
         AV72TFTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFTipoInmuebleOrigenId"), "."), 18, MidpointRounding.ToEven));
         AV73TFTipoInmuebleOrigenId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFTipoInmuebleOrigenId_To"), "."), 18, MidpointRounding.ToEven));
         AV124TFTipoInmuebleOrigenNombre = GetPar( "TFTipoInmuebleOrigenNombre");
         AV125TFTipoInmuebleOrigenNombre_Sel = GetPar( "TFTipoInmuebleOrigenNombre_Sel");
         AV76TFTipoInmuebleOrigenValor = NumberUtil.Val( GetPar( "TFTipoInmuebleOrigenValor"), ".");
         AV77TFTipoInmuebleOrigenValor_To = NumberUtil.Val( GetPar( "TFTipoInmuebleOrigenValor_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV103IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV104IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV132ProveedorId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorId"), "."), 18, MidpointRounding.ToEven));
         AV134SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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

      public override short ExecuteStartEvent( )
      {
         PAE52( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTE52( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mudanzaww.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV135Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV135Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV132ProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV132ProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV134SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV134SecUserId), "ZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMUDANZAASESOR1", AV20MudanzaAsesor1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMUDANZAASESOR2", AV24MudanzaAsesor2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vMUDANZAASESOR3", AV28MudanzaAsesor3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_111", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_111), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV98GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV100GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV105AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV105AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV96DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV96DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_MUDANZAFECHAALTAAUXDATETO", context.localUtil.DToC( AV48DDO_MudanzaFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_MUDANZAFECHASERVICIOAUXDATETO", context.localUtil.DToC( AV53DDO_MudanzaFechaServicioAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV135Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV135Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFMudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFMudanzaId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAASESOR", AV43TFMudanzaAsesor);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAASESOR_SEL", AV44TFMudanzaAsesor_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAFECHAALTA", context.localUtil.DToC( AV45TFMudanzaFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAFECHAALTA_TO", context.localUtil.DToC( AV46TFMudanzaFechaAlta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAFECHASERVICIO", context.localUtil.DToC( AV50TFMudanzaFechaServicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAFECHASERVICIO_TO", context.localUtil.DToC( AV51TFMudanzaFechaServicio_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMUDANZAHORASERVICIO_SELS", AV117TFMudanzaHoraServicio_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMUDANZAHORASERVICIO_SELS", AV117TFMudanzaHoraServicio_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMUDANZARGOHORASERVICIO_SELS", AV119TFMudanzaRgoHoraservicio_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMUDANZARGOHORASERVICIO_SELS", AV119TFMudanzaRgoHoraservicio_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFMUDANZADIRECCIONORIGEN", AV60TFMudanzaDireccionOrigen);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZADIRECCIONORIGEN_SEL", AV61TFMudanzaDireccionOrigen_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMUDANZAPISODPTOORIGEN_SELS", AV121TFMudanzaPisoDptoOrigen_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMUDANZAPISODPTOORIGEN_SELS", AV121TFMudanzaPisoDptoOrigen_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFMUDANZADIRECCIONDESTINO", AV62TFMudanzaDireccionDestino);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZADIRECCIONDESTINO_SEL", AV63TFMudanzaDireccionDestino_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPISODPTODESTINO", StringUtil.RTrim( AV122TFMudanzaPisoDptoDestino));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPISODPTODESTINO_SEL", StringUtil.RTrim( AV123TFMudanzaPisoDptoDestino_Sel));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZADISTANCIA", StringUtil.LTrim( StringUtil.NToC( AV64TFMudanzaDistancia, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZADISTANCIA_TO", StringUtil.LTrim( StringUtil.NToC( AV65TFMudanzaDistancia_To, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMUDANZAVEHICULOSUGERIDO_SELS", AV109TFMudanzaVehiculoSugerido_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMUDANZAVEHICULOSUGERIDO_SELS", AV109TFMudanzaVehiculoSugerido_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPRECIOBASEXHORA", StringUtil.LTrim( StringUtil.NToC( AV130TFMudanzaPrecioBasexHora, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPRECIOBASEXHORA_TO", StringUtil.LTrim( StringUtil.NToC( AV131TFMudanzaPrecioBasexHora_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPEAJECANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68TFMudanzaPeajeCantidad), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPEAJECANTIDAD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69TFMudanzaPeajeCantidad_To), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPEAJEVALOR", StringUtil.LTrim( StringUtil.NToC( AV70TFMudanzaPeajevalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPEAJEVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV71TFMudanzaPeajevalor_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPOINMUEBLEORIGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72TFTipoInmuebleOrigenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPOINMUEBLEORIGENID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73TFTipoInmuebleOrigenId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPOINMUEBLEORIGENNOMBRE", AV124TFTipoInmuebleOrigenNombre);
         GxWebStd.gx_hidden_field( context, "vTFTIPOINMUEBLEORIGENNOMBRE_SEL", AV125TFTipoInmuebleOrigenNombre_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTIPOINMUEBLEORIGENVALOR", StringUtil.LTrim( StringUtil.NToC( AV76TFTipoInmuebleOrigenValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPOINMUEBLEORIGENVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV77TFTipoInmuebleOrigenValor_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAHORASERVICIO_SELSJSON", AV116TFMudanzaHoraServicio_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZARGOHORASERVICIO_SELSJSON", AV118TFMudanzaRgoHoraservicio_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAPISODPTOORIGEN_SELSJSON", AV120TFMudanzaPisoDptoOrigen_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFMUDANZAVEHICULOSUGERIDO_SELSJSON", AV108TFMudanzaVehiculoSugerido_SelsJson);
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV132ProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV132ProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV134SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV134SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vDDO_MUDANZAFECHAALTAAUXDATE", context.localUtil.DToC( AV47DDO_MudanzaFechaAltaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_MUDANZAFECHASERVICIOAUXDATE", context.localUtil.DToC( AV52DDO_MudanzaFechaServicioAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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
            WEE52( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTE52( ) ;
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
         return formatLink("mudanzaww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "MudanzaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Mudanza", "") ;
      }

      protected void WBE50( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_E52( true) ;
         }
         else
         {
            wb_table1_25_E52( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_E52e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_MudanzaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_E52( true) ;
         }
         else
         {
            wb_table2_49_E52( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_E52e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_MudanzaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_71_E52( true) ;
         }
         else
         {
            wb_table3_71_E52( false) ;
         }
         return  ;
      }

      protected void wb_table3_71_E52e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_MudanzaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_93_E52( true) ;
         }
         else
         {
            wb_table4_93_E52( false) ;
         }
         return  ;
      }

      protected void wb_table4_93_E52e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl111( ) ;
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            nRC_GXsfl_111 = (int)(nGXsfl_111_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV98GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV99GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV100GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV105AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_MudanzaWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV96DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV96DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0145"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0145"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_111_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0145"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_mudanzafechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_mudanzafechaaltaauxdatetext_Internalname, AV49DDO_MudanzaFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV49DDO_MudanzaFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_mudanzafechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MudanzaWW.htm");
            /* User Defined Control */
            ucTfmudanzafechaalta_rangepicker.SetProperty("Start Date", AV47DDO_MudanzaFechaAltaAuxDate);
            ucTfmudanzafechaalta_rangepicker.SetProperty("End Date", AV48DDO_MudanzaFechaAltaAuxDateTo);
            ucTfmudanzafechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfmudanzafechaalta_rangepicker_Internalname, "TFMUDANZAFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_mudanzafechaservicioauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_mudanzafechaservicioauxdatetext_Internalname, AV54DDO_MudanzaFechaServicioAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV54DDO_MudanzaFechaServicioAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_mudanzafechaservicioauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MudanzaWW.htm");
            /* User Defined Control */
            ucTfmudanzafechaservicio_rangepicker.SetProperty("Start Date", AV52DDO_MudanzaFechaServicioAuxDate);
            ucTfmudanzafechaservicio_rangepicker.SetProperty("End Date", AV53DDO_MudanzaFechaServicioAuxDateTo);
            ucTfmudanzafechaservicio_rangepicker.Render(context, "wwp.daterangepicker", Tfmudanzafechaservicio_rangepicker_Internalname, "TFMUDANZAFECHASERVICIO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTE52( )
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
         Form.Meta.addItem("description", context.GetMessage( " Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPE50( ) ;
      }

      protected void WSE52( )
      {
         STARTE52( ) ;
         EVTE52( ) ;
      }

      protected void EVTE52( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E11E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E21E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26E52 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
                              SubsflControlProps_1112( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV101GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV101GridActions), 4, 0));
                              A735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A736MudanzaAsesor = cgiGet( edtMudanzaAsesor_Internalname);
                              A737MudanzaFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtMudanzaFechaAlta_Internalname), 0));
                              A738MudanzaFechaServicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtMudanzaFechaServicio_Internalname), 0));
                              cmbMudanzaHoraServicio.Name = cmbMudanzaHoraServicio_Internalname;
                              cmbMudanzaHoraServicio.CurrentValue = cgiGet( cmbMudanzaHoraServicio_Internalname);
                              A739MudanzaHoraServicio = cgiGet( cmbMudanzaHoraServicio_Internalname);
                              n739MudanzaHoraServicio = false;
                              cmbMudanzaRgoHoraservicio.Name = cmbMudanzaRgoHoraservicio_Internalname;
                              cmbMudanzaRgoHoraservicio.CurrentValue = cgiGet( cmbMudanzaRgoHoraservicio_Internalname);
                              A776MudanzaRgoHoraservicio = cgiGet( cmbMudanzaRgoHoraservicio_Internalname);
                              n776MudanzaRgoHoraservicio = false;
                              A740MudanzaDireccionOrigen = cgiGet( edtMudanzaDireccionOrigen_Internalname);
                              cmbMudanzaPisoDptoOrigen.Name = cmbMudanzaPisoDptoOrigen_Internalname;
                              cmbMudanzaPisoDptoOrigen.CurrentValue = cgiGet( cmbMudanzaPisoDptoOrigen_Internalname);
                              A777MudanzaPisoDptoOrigen = cgiGet( cmbMudanzaPisoDptoOrigen_Internalname);
                              A741MudanzaDireccionDestino = cgiGet( edtMudanzaDireccionDestino_Internalname);
                              A778MudanzaPisoDptoDestino = cgiGet( edtMudanzaPisoDptoDestino_Internalname);
                              A762MudanzaDistancia = context.localUtil.CToN( cgiGet( edtMudanzaDistancia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbMudanzaVehiculoSugerido.Name = cmbMudanzaVehiculoSugerido_Internalname;
                              cmbMudanzaVehiculoSugerido.CurrentValue = cgiGet( cmbMudanzaVehiculoSugerido_Internalname);
                              A742MudanzaVehiculoSugerido = cgiGet( cmbMudanzaVehiculoSugerido_Internalname);
                              A780MudanzaPrecioBasexHora = context.localUtil.CToN( cgiGet( edtMudanzaPrecioBasexHora_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A761MudanzaPeajeCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaPeajeCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A760MudanzaPeajevalor = context.localUtil.CToN( cgiGet( edtMudanzaPeajevalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A743TipoInmuebleOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoInmuebleOrigenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A755TipoInmuebleOrigenNombre = cgiGet( edtTipoInmuebleOrigenNombre_Internalname);
                              A756TipoInmuebleOrigenValor = context.localUtil.CToN( cgiGet( edtTipoInmuebleOrigenValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E27E52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28E52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29E52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30E52 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Mudanzaasesor1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUDANZAASESOR1"), AV20MudanzaAsesor1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Mudanzaasesor2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUDANZAASESOR2"), AV24MudanzaAsesor2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Mudanzaasesor3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMUDANZAASESOR3"), AV28MudanzaAsesor3) != 0 )
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
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 145 )
                        {
                           OldWwpaux_wc = cgiGet( "W0145");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0145", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEE52( )
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

      protected void PAE52( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1112( ) ;
         while ( nGXsfl_111_idx <= nRC_GXsfl_111 )
         {
            sendrow_1112( ) ;
            nGXsfl_111_idx = ((subGrid_Islastpage==1)&&(nGXsfl_111_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20MudanzaAsesor1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24MudanzaAsesor2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28MudanzaAsesor3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV135Pgmname ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       long AV41TFMudanzaId ,
                                       long AV42TFMudanzaId_To ,
                                       string AV43TFMudanzaAsesor ,
                                       string AV44TFMudanzaAsesor_Sel ,
                                       DateTime AV45TFMudanzaFechaAlta ,
                                       DateTime AV46TFMudanzaFechaAlta_To ,
                                       DateTime AV50TFMudanzaFechaServicio ,
                                       DateTime AV51TFMudanzaFechaServicio_To ,
                                       GxSimpleCollection<string> AV117TFMudanzaHoraServicio_Sels ,
                                       GxSimpleCollection<string> AV119TFMudanzaRgoHoraservicio_Sels ,
                                       string AV60TFMudanzaDireccionOrigen ,
                                       string AV61TFMudanzaDireccionOrigen_Sel ,
                                       GxSimpleCollection<string> AV121TFMudanzaPisoDptoOrigen_Sels ,
                                       string AV62TFMudanzaDireccionDestino ,
                                       string AV63TFMudanzaDireccionDestino_Sel ,
                                       string AV122TFMudanzaPisoDptoDestino ,
                                       string AV123TFMudanzaPisoDptoDestino_Sel ,
                                       decimal AV64TFMudanzaDistancia ,
                                       decimal AV65TFMudanzaDistancia_To ,
                                       GxSimpleCollection<string> AV109TFMudanzaVehiculoSugerido_Sels ,
                                       decimal AV130TFMudanzaPrecioBasexHora ,
                                       decimal AV131TFMudanzaPrecioBasexHora_To ,
                                       short AV68TFMudanzaPeajeCantidad ,
                                       short AV69TFMudanzaPeajeCantidad_To ,
                                       decimal AV70TFMudanzaPeajevalor ,
                                       decimal AV71TFMudanzaPeajevalor_To ,
                                       short AV72TFTipoInmuebleOrigenId ,
                                       short AV73TFTipoInmuebleOrigenId_To ,
                                       string AV124TFTipoInmuebleOrigenNombre ,
                                       string AV125TFTipoInmuebleOrigenNombre_Sel ,
                                       decimal AV76TFTipoInmuebleOrigenValor ,
                                       decimal AV77TFTipoInmuebleOrigenValor_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving ,
                                       bool AV103IsAuthorized_Update ,
                                       bool AV104IsAuthorized_Delete ,
                                       long AV132ProveedorId ,
                                       long AV134SecUserId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFE52( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", "")));
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFE52( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV135Pgmname = "MudanzaWW";
      }

      protected void RFE52( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 111;
         /* Execute user event: Refresh */
         E28E52 ();
         nGXsfl_111_idx = 1;
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         bGXsfl_111_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1112( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A739MudanzaHoraServicio ,
                                                 AV156Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                                 A776MudanzaRgoHoraservicio ,
                                                 AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                                 A777MudanzaPisoDptoOrigen ,
                                                 AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                                 A742MudanzaVehiculoSugerido ,
                                                 AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                                 AV136Mudanzawwds_1_filterfulltext ,
                                                 AV137Mudanzawwds_2_dynamicfiltersselector1 ,
                                                 AV138Mudanzawwds_3_dynamicfiltersoperator1 ,
                                                 AV139Mudanzawwds_4_mudanzaasesor1 ,
                                                 AV140Mudanzawwds_5_dynamicfiltersenabled2 ,
                                                 AV141Mudanzawwds_6_dynamicfiltersselector2 ,
                                                 AV142Mudanzawwds_7_dynamicfiltersoperator2 ,
                                                 AV143Mudanzawwds_8_mudanzaasesor2 ,
                                                 AV144Mudanzawwds_9_dynamicfiltersenabled3 ,
                                                 AV145Mudanzawwds_10_dynamicfiltersselector3 ,
                                                 AV146Mudanzawwds_11_dynamicfiltersoperator3 ,
                                                 AV147Mudanzawwds_12_mudanzaasesor3 ,
                                                 AV148Mudanzawwds_13_tfmudanzaid ,
                                                 AV149Mudanzawwds_14_tfmudanzaid_to ,
                                                 AV151Mudanzawwds_16_tfmudanzaasesor_sel ,
                                                 AV150Mudanzawwds_15_tfmudanzaasesor ,
                                                 AV152Mudanzawwds_17_tfmudanzafechaalta ,
                                                 AV153Mudanzawwds_18_tfmudanzafechaalta_to ,
                                                 AV154Mudanzawwds_19_tfmudanzafechaservicio ,
                                                 AV155Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                                 AV156Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                                 AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                                 AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                                 AV158Mudanzawwds_23_tfmudanzadireccionorigen ,
                                                 AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                                 AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                                 AV161Mudanzawwds_26_tfmudanzadirecciondestino ,
                                                 AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                                 AV163Mudanzawwds_28_tfmudanzapisodptodestino ,
                                                 AV165Mudanzawwds_30_tfmudanzadistancia ,
                                                 AV166Mudanzawwds_31_tfmudanzadistancia_to ,
                                                 AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                                 AV168Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                                 AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                                 AV170Mudanzawwds_35_tfmudanzapeajecantidad ,
                                                 AV171Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                                 AV172Mudanzawwds_37_tfmudanzapeajevalor ,
                                                 AV173Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                                 AV174Mudanzawwds_39_tftipoinmuebleorigenid ,
                                                 AV175Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                                 AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                                 AV176Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                                 AV178Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                                 AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                                 A735MudanzaId ,
                                                 A736MudanzaAsesor ,
                                                 A740MudanzaDireccionOrigen ,
                                                 A741MudanzaDireccionDestino ,
                                                 A778MudanzaPisoDptoDestino ,
                                                 A762MudanzaDistancia ,
                                                 A780MudanzaPrecioBasexHora ,
                                                 A761MudanzaPeajeCantidad ,
                                                 A760MudanzaPeajevalor ,
                                                 A743TipoInmuebleOrigenId ,
                                                 A755TipoInmuebleOrigenNombre ,
                                                 A756TipoInmuebleOrigenValor ,
                                                 A737MudanzaFechaAlta ,
                                                 A738MudanzaFechaServicio ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
            lV139Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1), "%", "");
            lV139Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1), "%", "");
            lV143Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2), "%", "");
            lV143Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2), "%", "");
            lV147Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3), "%", "");
            lV147Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3), "%", "");
            lV150Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV150Mudanzawwds_15_tfmudanzaasesor), "%", "");
            lV158Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV158Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
            lV161Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV161Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
            lV163Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV163Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
            lV176Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV176Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
            /* Using cursor H00E52 */
            pr_default.execute(0, new Object[] {lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV139Mudanzawwds_4_mudanzaasesor1, lV139Mudanzawwds_4_mudanzaasesor1, lV143Mudanzawwds_8_mudanzaasesor2, lV143Mudanzawwds_8_mudanzaasesor2, lV147Mudanzawwds_12_mudanzaasesor3, lV147Mudanzawwds_12_mudanzaasesor3, AV148Mudanzawwds_13_tfmudanzaid, AV149Mudanzawwds_14_tfmudanzaid_to, lV150Mudanzawwds_15_tfmudanzaasesor, AV151Mudanzawwds_16_tfmudanzaasesor_sel, AV152Mudanzawwds_17_tfmudanzafechaalta, AV153Mudanzawwds_18_tfmudanzafechaalta_to, AV154Mudanzawwds_19_tfmudanzafechaservicio, AV155Mudanzawwds_20_tfmudanzafechaservicio_to, lV158Mudanzawwds_23_tfmudanzadireccionorigen, AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV161Mudanzawwds_26_tfmudanzadirecciondestino, AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV163Mudanzawwds_28_tfmudanzapisodptodestino, AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV165Mudanzawwds_30_tfmudanzadistancia, AV166Mudanzawwds_31_tfmudanzadistancia_to, AV168Mudanzawwds_33_tfmudanzapreciobasexhora, AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV170Mudanzawwds_35_tfmudanzapeajecantidad, AV171Mudanzawwds_36_tfmudanzapeajecantidad_to, AV172Mudanzawwds_37_tfmudanzapeajevalor, AV173Mudanzawwds_38_tfmudanzapeajevalor_to, AV174Mudanzawwds_39_tftipoinmuebleorigenid, AV175Mudanzawwds_40_tftipoinmuebleorigenid_to, lV176Mudanzawwds_41_tftipoinmuebleorigennombre, AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV178Mudanzawwds_43_tftipoinmuebleorigenvalor, AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_111_idx = 1;
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A756TipoInmuebleOrigenValor = H00E52_A756TipoInmuebleOrigenValor[0];
               A755TipoInmuebleOrigenNombre = H00E52_A755TipoInmuebleOrigenNombre[0];
               A743TipoInmuebleOrigenId = H00E52_A743TipoInmuebleOrigenId[0];
               A760MudanzaPeajevalor = H00E52_A760MudanzaPeajevalor[0];
               A761MudanzaPeajeCantidad = H00E52_A761MudanzaPeajeCantidad[0];
               A780MudanzaPrecioBasexHora = H00E52_A780MudanzaPrecioBasexHora[0];
               A742MudanzaVehiculoSugerido = H00E52_A742MudanzaVehiculoSugerido[0];
               A762MudanzaDistancia = H00E52_A762MudanzaDistancia[0];
               A778MudanzaPisoDptoDestino = H00E52_A778MudanzaPisoDptoDestino[0];
               A741MudanzaDireccionDestino = H00E52_A741MudanzaDireccionDestino[0];
               A777MudanzaPisoDptoOrigen = H00E52_A777MudanzaPisoDptoOrigen[0];
               A740MudanzaDireccionOrigen = H00E52_A740MudanzaDireccionOrigen[0];
               A776MudanzaRgoHoraservicio = H00E52_A776MudanzaRgoHoraservicio[0];
               n776MudanzaRgoHoraservicio = H00E52_n776MudanzaRgoHoraservicio[0];
               A739MudanzaHoraServicio = H00E52_A739MudanzaHoraServicio[0];
               n739MudanzaHoraServicio = H00E52_n739MudanzaHoraServicio[0];
               A738MudanzaFechaServicio = H00E52_A738MudanzaFechaServicio[0];
               A737MudanzaFechaAlta = H00E52_A737MudanzaFechaAlta[0];
               A736MudanzaAsesor = H00E52_A736MudanzaAsesor[0];
               A735MudanzaId = H00E52_A735MudanzaId[0];
               A756TipoInmuebleOrigenValor = H00E52_A756TipoInmuebleOrigenValor[0];
               A755TipoInmuebleOrigenNombre = H00E52_A755TipoInmuebleOrigenNombre[0];
               /* Execute user event: Grid.Load */
               E29E52 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 111;
            WBE50( ) ;
         }
         bGXsfl_111_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesE52( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV135Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV135Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAID"+"_"+sGXsfl_111_idx, GetSecureSignedToken( sGXsfl_111_idx, context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV132ProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV132ProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV134SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV134SecUserId), "ZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV156Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV136Mudanzawwds_1_filterfulltext ,
                                              AV137Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV138Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV139Mudanzawwds_4_mudanzaasesor1 ,
                                              AV140Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV141Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV142Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV143Mudanzawwds_8_mudanzaasesor2 ,
                                              AV144Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV145Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV146Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV147Mudanzawwds_12_mudanzaasesor3 ,
                                              AV148Mudanzawwds_13_tfmudanzaid ,
                                              AV149Mudanzawwds_14_tfmudanzaid_to ,
                                              AV151Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV150Mudanzawwds_15_tfmudanzaasesor ,
                                              AV152Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV153Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV154Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV155Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV156Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV158Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV161Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV163Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV165Mudanzawwds_30_tfmudanzadistancia ,
                                              AV166Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV168Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV170Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV171Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV172Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV173Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV174Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV175Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV176Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV178Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV136Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext), "%", "");
         lV139Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV139Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV143Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV143Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV147Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV147Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV150Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV150Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV158Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV158Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV161Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV161Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV163Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV163Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV176Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV176Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor H00E53 */
         pr_default.execute(1, new Object[] {lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV136Mudanzawwds_1_filterfulltext, lV139Mudanzawwds_4_mudanzaasesor1, lV139Mudanzawwds_4_mudanzaasesor1, lV143Mudanzawwds_8_mudanzaasesor2, lV143Mudanzawwds_8_mudanzaasesor2, lV147Mudanzawwds_12_mudanzaasesor3, lV147Mudanzawwds_12_mudanzaasesor3, AV148Mudanzawwds_13_tfmudanzaid, AV149Mudanzawwds_14_tfmudanzaid_to, lV150Mudanzawwds_15_tfmudanzaasesor, AV151Mudanzawwds_16_tfmudanzaasesor_sel, AV152Mudanzawwds_17_tfmudanzafechaalta, AV153Mudanzawwds_18_tfmudanzafechaalta_to, AV154Mudanzawwds_19_tfmudanzafechaservicio, AV155Mudanzawwds_20_tfmudanzafechaservicio_to, lV158Mudanzawwds_23_tfmudanzadireccionorigen, AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV161Mudanzawwds_26_tfmudanzadirecciondestino, AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV163Mudanzawwds_28_tfmudanzapisodptodestino, AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV165Mudanzawwds_30_tfmudanzadistancia, AV166Mudanzawwds_31_tfmudanzadistancia_to, AV168Mudanzawwds_33_tfmudanzapreciobasexhora, AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV170Mudanzawwds_35_tfmudanzapeajecantidad, AV171Mudanzawwds_36_tfmudanzapeajecantidad_to, AV172Mudanzawwds_37_tfmudanzapeajevalor, AV173Mudanzawwds_38_tfmudanzapeajevalor_to, AV174Mudanzawwds_39_tftipoinmuebleorigenid, AV175Mudanzawwds_40_tftipoinmuebleorigenid_to, lV176Mudanzawwds_41_tftipoinmuebleorigennombre, AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV178Mudanzawwds_43_tftipoinmuebleorigenvalor, AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         GRID_nRecordCount = H00E53_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV135Pgmname = "MudanzaWW";
         edtMudanzaId_Enabled = 0;
         edtMudanzaAsesor_Enabled = 0;
         edtMudanzaFechaAlta_Enabled = 0;
         edtMudanzaFechaServicio_Enabled = 0;
         cmbMudanzaHoraServicio.Enabled = 0;
         cmbMudanzaRgoHoraservicio.Enabled = 0;
         edtMudanzaDireccionOrigen_Enabled = 0;
         cmbMudanzaPisoDptoOrigen.Enabled = 0;
         edtMudanzaDireccionDestino_Enabled = 0;
         edtMudanzaPisoDptoDestino_Enabled = 0;
         edtMudanzaDistancia_Enabled = 0;
         cmbMudanzaVehiculoSugerido.Enabled = 0;
         edtMudanzaPrecioBasexHora_Enabled = 0;
         edtMudanzaPeajeCantidad_Enabled = 0;
         edtMudanzaPeajevalor_Enabled = 0;
         edtTipoInmuebleOrigenId_Enabled = 0;
         edtTipoInmuebleOrigenNombre_Enabled = 0;
         edtTipoInmuebleOrigenValor_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPE50( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27E52 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV105AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV96DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_111 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_111"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV98GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV99GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV100GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV47DDO_MudanzaFechaAltaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_MUDANZAFECHAALTAAUXDATE"), 0);
            AV48DDO_MudanzaFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_MUDANZAFECHAALTAAUXDATETO"), 0);
            AV52DDO_MudanzaFechaServicioAuxDate = context.localUtil.CToD( cgiGet( "vDDO_MUDANZAFECHASERVICIOAUXDATE"), 0);
            AV53DDO_MudanzaFechaServicioAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_MUDANZAFECHASERVICIOAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV20MudanzaAsesor1 = cgiGet( edtavMudanzaasesor1_Internalname);
            AssignAttri("", false, "AV20MudanzaAsesor1", AV20MudanzaAsesor1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24MudanzaAsesor2 = cgiGet( edtavMudanzaasesor2_Internalname);
            AssignAttri("", false, "AV24MudanzaAsesor2", AV24MudanzaAsesor2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28MudanzaAsesor3 = cgiGet( edtavMudanzaasesor3_Internalname);
            AssignAttri("", false, "AV28MudanzaAsesor3", AV28MudanzaAsesor3);
            AV49DDO_MudanzaFechaAltaAuxDateText = cgiGet( edtavDdo_mudanzafechaaltaauxdatetext_Internalname);
            AssignAttri("", false, "AV49DDO_MudanzaFechaAltaAuxDateText", AV49DDO_MudanzaFechaAltaAuxDateText);
            AV54DDO_MudanzaFechaServicioAuxDateText = cgiGet( edtavDdo_mudanzafechaservicioauxdatetext_Internalname);
            AssignAttri("", false, "AV54DDO_MudanzaFechaServicioAuxDateText", AV54DDO_MudanzaFechaServicioAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUDANZAASESOR1"), AV20MudanzaAsesor1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUDANZAASESOR2"), AV24MudanzaAsesor2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMUDANZAASESOR3"), AV28MudanzaAsesor3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E27E52 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27E52( )
      {
         /* Start Routine */
         returnInSub = false;
         CallWebObject(formatLink("mudanza.aspx", new object[] {UrlEncode(StringUtil.RTrim(context.GetMessage( "INS", ""))),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","MudanzaId","ProveedorId","SecUserId"}) );
         context.wjLocDisableFrm = 1;
         this.executeUsercontrolMethod("", false, "TFMUDANZAFECHASERVICIO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_mudanzafechaservicioauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFMUDANZAFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_mudanzafechaaltaauxdatetext_Internalname});
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV18DynamicFiltersSelector1 = "MUDANZAASESOR";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "MUDANZAASESOR";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "MUDANZAASESOR";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV105AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV106AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV106AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV106AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV106AGExportDataItem.gxTpr_Eventkey = "Export";
         AV106AGExportDataItem.gxTpr_Isdivider = false;
         AV105AGExportData.Add(AV106AGExportDataItem, 0);
         AV106AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV106AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV106AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV106AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV106AGExportDataItem.gxTpr_Isdivider = false;
         AV105AGExportData.Add(AV106AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Mudanza", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV96DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV96DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E28E52( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV37Session.Get("MudanzaWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("MudanzaWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtMudanzaId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaId_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaAsesor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaAsesor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaAsesor_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaFechaAlta_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaFechaServicio_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaFechaServicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaFechaServicio_Visible), 5, 0), !bGXsfl_111_Refreshing);
         cmbMudanzaHoraServicio.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMudanzaHoraServicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMudanzaHoraServicio.Visible), 5, 0), !bGXsfl_111_Refreshing);
         cmbMudanzaRgoHoraservicio.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMudanzaRgoHoraservicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMudanzaRgoHoraservicio.Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaDireccionOrigen_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaDireccionOrigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionOrigen_Visible), 5, 0), !bGXsfl_111_Refreshing);
         cmbMudanzaPisoDptoOrigen.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMudanzaPisoDptoOrigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMudanzaPisoDptoOrigen.Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaDireccionDestino_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaDireccionDestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionDestino_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaPisoDptoDestino_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaPisoDptoDestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaPisoDptoDestino_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaDistancia_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaDistancia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDistancia_Visible), 5, 0), !bGXsfl_111_Refreshing);
         cmbMudanzaVehiculoSugerido.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMudanzaVehiculoSugerido_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMudanzaVehiculoSugerido.Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaPrecioBasexHora_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaPrecioBasexHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaPrecioBasexHora_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaPeajeCantidad_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(14)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaPeajeCantidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaPeajeCantidad_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtMudanzaPeajevalor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(15)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMudanzaPeajevalor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaPeajevalor_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtTipoInmuebleOrigenId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(16)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTipoInmuebleOrigenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoInmuebleOrigenId_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtTipoInmuebleOrigenNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(17)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTipoInmuebleOrigenNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoInmuebleOrigenNombre_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtTipoInmuebleOrigenValor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(18)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTipoInmuebleOrigenValor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoInmuebleOrigenValor_Visible), 5, 0), !bGXsfl_111_Refreshing);
         AV98GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV98GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV98GridCurrentPage), 10, 0));
         AV99GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV99GridPageCount", StringUtil.LTrimStr( (decimal)(AV99GridPageCount), 10, 0));
         GXt_char2 = AV100GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV135Pgmname, out  GXt_char2) ;
         AV100GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV100GridAppliedFilters", AV100GridAppliedFilters);
         AV136Mudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV137Mudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV138Mudanzawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV139Mudanzawwds_4_mudanzaasesor1 = AV20MudanzaAsesor1;
         AV140Mudanzawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV141Mudanzawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV142Mudanzawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV143Mudanzawwds_8_mudanzaasesor2 = AV24MudanzaAsesor2;
         AV144Mudanzawwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV145Mudanzawwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV146Mudanzawwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV147Mudanzawwds_12_mudanzaasesor3 = AV28MudanzaAsesor3;
         AV148Mudanzawwds_13_tfmudanzaid = AV41TFMudanzaId;
         AV149Mudanzawwds_14_tfmudanzaid_to = AV42TFMudanzaId_To;
         AV150Mudanzawwds_15_tfmudanzaasesor = AV43TFMudanzaAsesor;
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = AV44TFMudanzaAsesor_Sel;
         AV152Mudanzawwds_17_tfmudanzafechaalta = AV45TFMudanzaFechaAlta;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = AV46TFMudanzaFechaAlta_To;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = AV50TFMudanzaFechaServicio;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = AV51TFMudanzaFechaServicio_To;
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = AV117TFMudanzaHoraServicio_Sels;
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV119TFMudanzaRgoHoraservicio_Sels;
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = AV60TFMudanzaDireccionOrigen;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV61TFMudanzaDireccionOrigen_Sel;
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV121TFMudanzaPisoDptoOrigen_Sels;
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = AV62TFMudanzaDireccionDestino;
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV63TFMudanzaDireccionDestino_Sel;
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = AV122TFMudanzaPisoDptoDestino;
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV123TFMudanzaPisoDptoDestino_Sel;
         AV165Mudanzawwds_30_tfmudanzadistancia = AV64TFMudanzaDistancia;
         AV166Mudanzawwds_31_tfmudanzadistancia_to = AV65TFMudanzaDistancia_To;
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV109TFMudanzaVehiculoSugerido_Sels;
         AV168Mudanzawwds_33_tfmudanzapreciobasexhora = AV130TFMudanzaPrecioBasexHora;
         AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV131TFMudanzaPrecioBasexHora_To;
         AV170Mudanzawwds_35_tfmudanzapeajecantidad = AV68TFMudanzaPeajeCantidad;
         AV171Mudanzawwds_36_tfmudanzapeajecantidad_to = AV69TFMudanzaPeajeCantidad_To;
         AV172Mudanzawwds_37_tfmudanzapeajevalor = AV70TFMudanzaPeajevalor;
         AV173Mudanzawwds_38_tfmudanzapeajevalor_to = AV71TFMudanzaPeajevalor_To;
         AV174Mudanzawwds_39_tftipoinmuebleorigenid = AV72TFTipoInmuebleOrigenId;
         AV175Mudanzawwds_40_tftipoinmuebleorigenid_to = AV73TFTipoInmuebleOrigenId_To;
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = AV124TFTipoInmuebleOrigenNombre;
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV125TFTipoInmuebleOrigenNombre_Sel;
         AV178Mudanzawwds_43_tftipoinmuebleorigenvalor = AV76TFTipoInmuebleOrigenValor;
         AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV77TFTipoInmuebleOrigenValor_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12E52( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV97PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV97PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13E52( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16E52( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaId") == 0 )
            {
               AV41TFMudanzaId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFMudanzaId", StringUtil.LTrimStr( (decimal)(AV41TFMudanzaId), 18, 0));
               AV42TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFMudanzaId_To", StringUtil.LTrimStr( (decimal)(AV42TFMudanzaId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaAsesor") == 0 )
            {
               AV43TFMudanzaAsesor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFMudanzaAsesor", AV43TFMudanzaAsesor);
               AV44TFMudanzaAsesor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFMudanzaAsesor_Sel", AV44TFMudanzaAsesor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaFechaAlta") == 0 )
            {
               AV45TFMudanzaFechaAlta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV45TFMudanzaFechaAlta", context.localUtil.Format(AV45TFMudanzaFechaAlta, "99/99/99"));
               AV46TFMudanzaFechaAlta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV46TFMudanzaFechaAlta_To", context.localUtil.Format(AV46TFMudanzaFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaFechaServicio") == 0 )
            {
               AV50TFMudanzaFechaServicio = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV50TFMudanzaFechaServicio", context.localUtil.Format(AV50TFMudanzaFechaServicio, "99/99/99"));
               AV51TFMudanzaFechaServicio_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV51TFMudanzaFechaServicio_To", context.localUtil.Format(AV51TFMudanzaFechaServicio_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaHoraServicio") == 0 )
            {
               AV116TFMudanzaHoraServicio_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV116TFMudanzaHoraServicio_SelsJson", AV116TFMudanzaHoraServicio_SelsJson);
               AV117TFMudanzaHoraServicio_Sels.FromJSonString(AV116TFMudanzaHoraServicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaRgoHoraservicio") == 0 )
            {
               AV118TFMudanzaRgoHoraservicio_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV118TFMudanzaRgoHoraservicio_SelsJson", AV118TFMudanzaRgoHoraservicio_SelsJson);
               AV119TFMudanzaRgoHoraservicio_Sels.FromJSonString(AV118TFMudanzaRgoHoraservicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaDireccionOrigen") == 0 )
            {
               AV60TFMudanzaDireccionOrigen = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV60TFMudanzaDireccionOrigen", AV60TFMudanzaDireccionOrigen);
               AV61TFMudanzaDireccionOrigen_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV61TFMudanzaDireccionOrigen_Sel", AV61TFMudanzaDireccionOrigen_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaPisoDptoOrigen") == 0 )
            {
               AV120TFMudanzaPisoDptoOrigen_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV120TFMudanzaPisoDptoOrigen_SelsJson", AV120TFMudanzaPisoDptoOrigen_SelsJson);
               AV121TFMudanzaPisoDptoOrigen_Sels.FromJSonString(AV120TFMudanzaPisoDptoOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaDireccionDestino") == 0 )
            {
               AV62TFMudanzaDireccionDestino = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFMudanzaDireccionDestino", AV62TFMudanzaDireccionDestino);
               AV63TFMudanzaDireccionDestino_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFMudanzaDireccionDestino_Sel", AV63TFMudanzaDireccionDestino_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaPisoDptoDestino") == 0 )
            {
               AV122TFMudanzaPisoDptoDestino = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV122TFMudanzaPisoDptoDestino", AV122TFMudanzaPisoDptoDestino);
               AV123TFMudanzaPisoDptoDestino_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV123TFMudanzaPisoDptoDestino_Sel", AV123TFMudanzaPisoDptoDestino_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaDistancia") == 0 )
            {
               AV64TFMudanzaDistancia = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV64TFMudanzaDistancia", StringUtil.LTrimStr( AV64TFMudanzaDistancia, 10, 2));
               AV65TFMudanzaDistancia_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV65TFMudanzaDistancia_To", StringUtil.LTrimStr( AV65TFMudanzaDistancia_To, 10, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaVehiculoSugerido") == 0 )
            {
               AV108TFMudanzaVehiculoSugerido_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV108TFMudanzaVehiculoSugerido_SelsJson", AV108TFMudanzaVehiculoSugerido_SelsJson);
               AV109TFMudanzaVehiculoSugerido_Sels.FromJSonString(AV108TFMudanzaVehiculoSugerido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaPrecioBasexHora") == 0 )
            {
               AV130TFMudanzaPrecioBasexHora = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV130TFMudanzaPrecioBasexHora", StringUtil.LTrimStr( AV130TFMudanzaPrecioBasexHora, 18, 2));
               AV131TFMudanzaPrecioBasexHora_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV131TFMudanzaPrecioBasexHora_To", StringUtil.LTrimStr( AV131TFMudanzaPrecioBasexHora_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaPeajeCantidad") == 0 )
            {
               AV68TFMudanzaPeajeCantidad = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV68TFMudanzaPeajeCantidad", StringUtil.Str( (decimal)(AV68TFMudanzaPeajeCantidad), 1, 0));
               AV69TFMudanzaPeajeCantidad_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV69TFMudanzaPeajeCantidad_To", StringUtil.Str( (decimal)(AV69TFMudanzaPeajeCantidad_To), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MudanzaPeajevalor") == 0 )
            {
               AV70TFMudanzaPeajevalor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV70TFMudanzaPeajevalor", StringUtil.LTrimStr( AV70TFMudanzaPeajevalor, 18, 2));
               AV71TFMudanzaPeajevalor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV71TFMudanzaPeajevalor_To", StringUtil.LTrimStr( AV71TFMudanzaPeajevalor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoInmuebleOrigenId") == 0 )
            {
               AV72TFTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV72TFTipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(AV72TFTipoInmuebleOrigenId), 4, 0));
               AV73TFTipoInmuebleOrigenId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV73TFTipoInmuebleOrigenId_To", StringUtil.LTrimStr( (decimal)(AV73TFTipoInmuebleOrigenId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoInmuebleOrigenNombre") == 0 )
            {
               AV124TFTipoInmuebleOrigenNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV124TFTipoInmuebleOrigenNombre", AV124TFTipoInmuebleOrigenNombre);
               AV125TFTipoInmuebleOrigenNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV125TFTipoInmuebleOrigenNombre_Sel", AV125TFTipoInmuebleOrigenNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoInmuebleOrigenValor") == 0 )
            {
               AV76TFTipoInmuebleOrigenValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV76TFTipoInmuebleOrigenValor", StringUtil.LTrimStr( AV76TFTipoInmuebleOrigenValor, 18, 2));
               AV77TFTipoInmuebleOrigenValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV77TFTipoInmuebleOrigenValor_To", StringUtil.LTrimStr( AV77TFTipoInmuebleOrigenValor_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV109TFMudanzaVehiculoSugerido_Sels", AV109TFMudanzaVehiculoSugerido_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121TFMudanzaPisoDptoOrigen_Sels", AV121TFMudanzaPisoDptoOrigen_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV119TFMudanzaRgoHoraservicio_Sels", AV119TFMudanzaRgoHoraservicio_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV117TFMudanzaHoraServicio_Sels", AV117TFMudanzaHoraServicio_Sels);
      }

      private void E29E52( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         if ( AV103IsAuthorized_Update )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV104IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mudanzaview.aspx"+UrlEncode(StringUtil.LTrimStr(A735MudanzaId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         edtMudanzaAsesor_Link = formatLink("mudanzaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 111;
         }
         sendrow_1112( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_111_Refreshing )
         {
            context.DoAjaxLoad(111, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV101GridActions), 4, 0));
      }

      protected void E17E52( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "MudanzaWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22E52( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E18E52( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E23E52( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E24E52( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E19E52( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E25E52( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E20E52( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20MudanzaAsesor1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24MudanzaAsesor2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28MudanzaAsesor3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV135Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFMudanzaId, AV42TFMudanzaId_To, AV43TFMudanzaAsesor, AV44TFMudanzaAsesor_Sel, AV45TFMudanzaFechaAlta, AV46TFMudanzaFechaAlta_To, AV50TFMudanzaFechaServicio, AV51TFMudanzaFechaServicio_To, AV117TFMudanzaHoraServicio_Sels, AV119TFMudanzaRgoHoraservicio_Sels, AV60TFMudanzaDireccionOrigen, AV61TFMudanzaDireccionOrigen_Sel, AV121TFMudanzaPisoDptoOrigen_Sels, AV62TFMudanzaDireccionDestino, AV63TFMudanzaDireccionDestino_Sel, AV122TFMudanzaPisoDptoDestino, AV123TFMudanzaPisoDptoDestino_Sel, AV64TFMudanzaDistancia, AV65TFMudanzaDistancia_To, AV109TFMudanzaVehiculoSugerido_Sels, AV130TFMudanzaPrecioBasexHora, AV131TFMudanzaPrecioBasexHora_To, AV68TFMudanzaPeajeCantidad, AV69TFMudanzaPeajeCantidad_To, AV70TFMudanzaPeajevalor, AV71TFMudanzaPeajevalor_To, AV72TFTipoInmuebleOrigenId, AV73TFTipoInmuebleOrigenId_To, AV124TFTipoInmuebleOrigenNombre, AV125TFTipoInmuebleOrigenNombre_Sel, AV76TFTipoInmuebleOrigenValor, AV77TFTipoInmuebleOrigenValor_To, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV132ProveedorId, AV134SecUserId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E26E52( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E11E52( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("MudanzaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV135Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("MudanzaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "MudanzaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV39ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV135Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV117TFMudanzaHoraServicio_Sels", AV117TFMudanzaHoraServicio_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV119TFMudanzaRgoHoraservicio_Sels", AV119TFMudanzaRgoHoraservicio_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121TFMudanzaPisoDptoOrigen_Sels", AV121TFMudanzaPisoDptoOrigen_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV109TFMudanzaVehiculoSugerido_Sels", AV109TFMudanzaVehiculoSugerido_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E30E52( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV101GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV101GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV101GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV101GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV101GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV101GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21E52( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("mudanza.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(AV132ProveedorId,18,0)),UrlEncode(StringUtil.LTrimStr(AV134SecUserId,10,0))}, new string[] {"Mode","MudanzaId","ProveedorId","SecUserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E14E52( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV109TFMudanzaVehiculoSugerido_Sels", AV109TFMudanzaVehiculoSugerido_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121TFMudanzaPisoDptoOrigen_Sels", AV121TFMudanzaPisoDptoOrigen_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV119TFMudanzaRgoHoraservicio_Sels", AV119TFMudanzaRgoHoraservicio_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV117TFMudanzaHoraServicio_Sels", AV117TFMudanzaHoraServicio_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E15E52( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0145",(string)"",(string)"Mudanza",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0145"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaAsesor",  "",  "Asesor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaFechaServicio",  "",  "Fecha Servicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaHoraServicio",  "",  "Hora Servicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaRgoHoraservicio",  "",  "Rgo Horaservicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaDireccionOrigen",  "",  "Direccion Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaPisoDptoOrigen",  "",  "Dpto Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaDireccionDestino",  "",  "Direccion Destino",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaPisoDptoDestino",  "",  "Dpto Destino",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaDistancia",  "",  "Distancia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaVehiculoSugerido",  "",  "Vehiculo Sugerido",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaPrecioBasexHora",  "",  "Basex Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaPeajeCantidad",  "",  "Peaje Cantidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "MudanzaPeajevalor",  "",  "Peajevalor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "TipoInmuebleOrigenId",  "",  "Origen Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "TipoInmuebleOrigenNombre",  "",  "Origen Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "TipoInmuebleOrigenValor",  "",  "Origen Valor",  true,  "") ;
         GXt_char2 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MudanzaWWColumnsSelector", out  GXt_char2) ;
         AV34UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV103IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Update", out  GXt_boolean3) ;
         AV103IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV103IsAuthorized_Update", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GXt_boolean3 = AV104IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Delete", out  GXt_boolean3) ;
         AV104IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV104IsAuthorized_Delete", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GXt_boolean3 = AV107TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Insert", out  GXt_boolean3) ;
         AV107TempBoolean = GXt_boolean3;
         if ( ! ( AV107TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV107TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean3) ;
         AV107TempBoolean = GXt_boolean3;
         if ( ! ( AV107TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Mudanza",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavMudanzaasesor1_Visible = 0;
         AssignProp("", false, edtavMudanzaasesor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanzaasesor1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUDANZAASESOR") == 0 )
         {
            edtavMudanzaasesor1_Visible = 1;
            AssignProp("", false, edtavMudanzaasesor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanzaasesor1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavMudanzaasesor2_Visible = 0;
         AssignProp("", false, edtavMudanzaasesor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanzaasesor2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUDANZAASESOR") == 0 )
         {
            edtavMudanzaasesor2_Visible = 1;
            AssignProp("", false, edtavMudanzaasesor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanzaasesor2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavMudanzaasesor3_Visible = 0;
         AssignProp("", false, edtavMudanzaasesor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanzaasesor3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUDANZAASESOR") == 0 )
         {
            edtavMudanzaasesor3_Visible = 1;
            AssignProp("", false, edtavMudanzaasesor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanzaasesor3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "MUDANZAASESOR";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24MudanzaAsesor2 = "";
         AssignAttri("", false, "AV24MudanzaAsesor2", AV24MudanzaAsesor2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "MUDANZAASESOR";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28MudanzaAsesor3 = "";
         AssignAttri("", false, "AV28MudanzaAsesor3", AV28MudanzaAsesor3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "MudanzaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV41TFMudanzaId = 0;
         AssignAttri("", false, "AV41TFMudanzaId", StringUtil.LTrimStr( (decimal)(AV41TFMudanzaId), 18, 0));
         AV42TFMudanzaId_To = 0;
         AssignAttri("", false, "AV42TFMudanzaId_To", StringUtil.LTrimStr( (decimal)(AV42TFMudanzaId_To), 18, 0));
         AV43TFMudanzaAsesor = "";
         AssignAttri("", false, "AV43TFMudanzaAsesor", AV43TFMudanzaAsesor);
         AV44TFMudanzaAsesor_Sel = "";
         AssignAttri("", false, "AV44TFMudanzaAsesor_Sel", AV44TFMudanzaAsesor_Sel);
         AV45TFMudanzaFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "AV45TFMudanzaFechaAlta", context.localUtil.Format(AV45TFMudanzaFechaAlta, "99/99/99"));
         AV46TFMudanzaFechaAlta_To = DateTime.MinValue;
         AssignAttri("", false, "AV46TFMudanzaFechaAlta_To", context.localUtil.Format(AV46TFMudanzaFechaAlta_To, "99/99/99"));
         AV50TFMudanzaFechaServicio = DateTime.MinValue;
         AssignAttri("", false, "AV50TFMudanzaFechaServicio", context.localUtil.Format(AV50TFMudanzaFechaServicio, "99/99/99"));
         AV51TFMudanzaFechaServicio_To = DateTime.MinValue;
         AssignAttri("", false, "AV51TFMudanzaFechaServicio_To", context.localUtil.Format(AV51TFMudanzaFechaServicio_To, "99/99/99"));
         AV117TFMudanzaHoraServicio_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV119TFMudanzaRgoHoraservicio_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV60TFMudanzaDireccionOrigen = "";
         AssignAttri("", false, "AV60TFMudanzaDireccionOrigen", AV60TFMudanzaDireccionOrigen);
         AV61TFMudanzaDireccionOrigen_Sel = "";
         AssignAttri("", false, "AV61TFMudanzaDireccionOrigen_Sel", AV61TFMudanzaDireccionOrigen_Sel);
         AV121TFMudanzaPisoDptoOrigen_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV62TFMudanzaDireccionDestino = "";
         AssignAttri("", false, "AV62TFMudanzaDireccionDestino", AV62TFMudanzaDireccionDestino);
         AV63TFMudanzaDireccionDestino_Sel = "";
         AssignAttri("", false, "AV63TFMudanzaDireccionDestino_Sel", AV63TFMudanzaDireccionDestino_Sel);
         AV122TFMudanzaPisoDptoDestino = "";
         AssignAttri("", false, "AV122TFMudanzaPisoDptoDestino", AV122TFMudanzaPisoDptoDestino);
         AV123TFMudanzaPisoDptoDestino_Sel = "";
         AssignAttri("", false, "AV123TFMudanzaPisoDptoDestino_Sel", AV123TFMudanzaPisoDptoDestino_Sel);
         AV64TFMudanzaDistancia = 0;
         AssignAttri("", false, "AV64TFMudanzaDistancia", StringUtil.LTrimStr( AV64TFMudanzaDistancia, 10, 2));
         AV65TFMudanzaDistancia_To = 0;
         AssignAttri("", false, "AV65TFMudanzaDistancia_To", StringUtil.LTrimStr( AV65TFMudanzaDistancia_To, 10, 2));
         AV109TFMudanzaVehiculoSugerido_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV130TFMudanzaPrecioBasexHora = 0;
         AssignAttri("", false, "AV130TFMudanzaPrecioBasexHora", StringUtil.LTrimStr( AV130TFMudanzaPrecioBasexHora, 18, 2));
         AV131TFMudanzaPrecioBasexHora_To = 0;
         AssignAttri("", false, "AV131TFMudanzaPrecioBasexHora_To", StringUtil.LTrimStr( AV131TFMudanzaPrecioBasexHora_To, 18, 2));
         AV68TFMudanzaPeajeCantidad = 0;
         AssignAttri("", false, "AV68TFMudanzaPeajeCantidad", StringUtil.Str( (decimal)(AV68TFMudanzaPeajeCantidad), 1, 0));
         AV69TFMudanzaPeajeCantidad_To = 0;
         AssignAttri("", false, "AV69TFMudanzaPeajeCantidad_To", StringUtil.Str( (decimal)(AV69TFMudanzaPeajeCantidad_To), 1, 0));
         AV70TFMudanzaPeajevalor = 0;
         AssignAttri("", false, "AV70TFMudanzaPeajevalor", StringUtil.LTrimStr( AV70TFMudanzaPeajevalor, 18, 2));
         AV71TFMudanzaPeajevalor_To = 0;
         AssignAttri("", false, "AV71TFMudanzaPeajevalor_To", StringUtil.LTrimStr( AV71TFMudanzaPeajevalor_To, 18, 2));
         AV72TFTipoInmuebleOrigenId = 0;
         AssignAttri("", false, "AV72TFTipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(AV72TFTipoInmuebleOrigenId), 4, 0));
         AV73TFTipoInmuebleOrigenId_To = 0;
         AssignAttri("", false, "AV73TFTipoInmuebleOrigenId_To", StringUtil.LTrimStr( (decimal)(AV73TFTipoInmuebleOrigenId_To), 4, 0));
         AV124TFTipoInmuebleOrigenNombre = "";
         AssignAttri("", false, "AV124TFTipoInmuebleOrigenNombre", AV124TFTipoInmuebleOrigenNombre);
         AV125TFTipoInmuebleOrigenNombre_Sel = "";
         AssignAttri("", false, "AV125TFTipoInmuebleOrigenNombre_Sel", AV125TFTipoInmuebleOrigenNombre_Sel);
         AV76TFTipoInmuebleOrigenValor = 0;
         AssignAttri("", false, "AV76TFTipoInmuebleOrigenValor", StringUtil.LTrimStr( AV76TFTipoInmuebleOrigenValor, 18, 2));
         AV77TFTipoInmuebleOrigenValor_To = 0;
         AssignAttri("", false, "AV77TFTipoInmuebleOrigenValor_To", StringUtil.LTrimStr( AV77TFTipoInmuebleOrigenValor_To, 18, 2));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "MUDANZAASESOR";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20MudanzaAsesor1 = "";
         AssignAttri("", false, "AV20MudanzaAsesor1", AV20MudanzaAsesor1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S262( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mudanzaview.aspx"+UrlEncode(StringUtil.LTrimStr(A735MudanzaId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("mudanzaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("mudanza.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A735MudanzaId,18,0)),UrlEncode(StringUtil.LTrimStr(AV132ProveedorId,18,0)),UrlEncode(StringUtil.LTrimStr(AV134SecUserId,10,0))}, new string[] {"Mode","MudanzaId","ProveedorId","SecUserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         CallWebObject(formatLink("mudanza.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A735MudanzaId,18,0)),UrlEncode(StringUtil.LTrimStr(AV132ProveedorId,18,0)),UrlEncode(StringUtil.LTrimStr(AV134SecUserId,10,0))}, new string[] {"Mode","MudanzaId","ProveedorId","SecUserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV135Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV135Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV135Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV180GXV1 = 1;
         while ( AV180GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV180GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV41TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFMudanzaId", StringUtil.LTrimStr( (decimal)(AV41TFMudanzaId), 18, 0));
               AV42TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFMudanzaId_To", StringUtil.LTrimStr( (decimal)(AV42TFMudanzaId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR") == 0 )
            {
               AV43TFMudanzaAsesor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFMudanzaAsesor", AV43TFMudanzaAsesor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR_SEL") == 0 )
            {
               AV44TFMudanzaAsesor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFMudanzaAsesor_Sel", AV44TFMudanzaAsesor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHAALTA") == 0 )
            {
               AV45TFMudanzaFechaAlta = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV45TFMudanzaFechaAlta", context.localUtil.Format(AV45TFMudanzaFechaAlta, "99/99/99"));
               AV46TFMudanzaFechaAlta_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV46TFMudanzaFechaAlta_To", context.localUtil.Format(AV46TFMudanzaFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHASERVICIO") == 0 )
            {
               AV50TFMudanzaFechaServicio = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV50TFMudanzaFechaServicio", context.localUtil.Format(AV50TFMudanzaFechaServicio, "99/99/99"));
               AV51TFMudanzaFechaServicio_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV51TFMudanzaFechaServicio_To", context.localUtil.Format(AV51TFMudanzaFechaServicio_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAHORASERVICIO_SEL") == 0 )
            {
               AV116TFMudanzaHoraServicio_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV116TFMudanzaHoraServicio_SelsJson", AV116TFMudanzaHoraServicio_SelsJson);
               AV117TFMudanzaHoraServicio_Sels.FromJSonString(AV116TFMudanzaHoraServicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZARGOHORASERVICIO_SEL") == 0 )
            {
               AV118TFMudanzaRgoHoraservicio_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV118TFMudanzaRgoHoraservicio_SelsJson", AV118TFMudanzaRgoHoraservicio_SelsJson);
               AV119TFMudanzaRgoHoraservicio_Sels.FromJSonString(AV118TFMudanzaRgoHoraservicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN") == 0 )
            {
               AV60TFMudanzaDireccionOrigen = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFMudanzaDireccionOrigen", AV60TFMudanzaDireccionOrigen);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN_SEL") == 0 )
            {
               AV61TFMudanzaDireccionOrigen_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFMudanzaDireccionOrigen_Sel", AV61TFMudanzaDireccionOrigen_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTOORIGEN_SEL") == 0 )
            {
               AV120TFMudanzaPisoDptoOrigen_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV120TFMudanzaPisoDptoOrigen_SelsJson", AV120TFMudanzaPisoDptoOrigen_SelsJson);
               AV121TFMudanzaPisoDptoOrigen_Sels.FromJSonString(AV120TFMudanzaPisoDptoOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO") == 0 )
            {
               AV62TFMudanzaDireccionDestino = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFMudanzaDireccionDestino", AV62TFMudanzaDireccionDestino);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO_SEL") == 0 )
            {
               AV63TFMudanzaDireccionDestino_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFMudanzaDireccionDestino_Sel", AV63TFMudanzaDireccionDestino_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO") == 0 )
            {
               AV122TFMudanzaPisoDptoDestino = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV122TFMudanzaPisoDptoDestino", AV122TFMudanzaPisoDptoDestino);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO_SEL") == 0 )
            {
               AV123TFMudanzaPisoDptoDestino_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV123TFMudanzaPisoDptoDestino_Sel", AV123TFMudanzaPisoDptoDestino_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZADISTANCIA") == 0 )
            {
               AV64TFMudanzaDistancia = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV64TFMudanzaDistancia", StringUtil.LTrimStr( AV64TFMudanzaDistancia, 10, 2));
               AV65TFMudanzaDistancia_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV65TFMudanzaDistancia_To", StringUtil.LTrimStr( AV65TFMudanzaDistancia_To, 10, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAVEHICULOSUGERIDO_SEL") == 0 )
            {
               AV108TFMudanzaVehiculoSugerido_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV108TFMudanzaVehiculoSugerido_SelsJson", AV108TFMudanzaVehiculoSugerido_SelsJson);
               AV109TFMudanzaVehiculoSugerido_Sels.FromJSonString(AV108TFMudanzaVehiculoSugerido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAPRECIOBASEXHORA") == 0 )
            {
               AV130TFMudanzaPrecioBasexHora = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV130TFMudanzaPrecioBasexHora", StringUtil.LTrimStr( AV130TFMudanzaPrecioBasexHora, 18, 2));
               AV131TFMudanzaPrecioBasexHora_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV131TFMudanzaPrecioBasexHora_To", StringUtil.LTrimStr( AV131TFMudanzaPrecioBasexHora_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJECANTIDAD") == 0 )
            {
               AV68TFMudanzaPeajeCantidad = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV68TFMudanzaPeajeCantidad", StringUtil.Str( (decimal)(AV68TFMudanzaPeajeCantidad), 1, 0));
               AV69TFMudanzaPeajeCantidad_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV69TFMudanzaPeajeCantidad_To", StringUtil.Str( (decimal)(AV69TFMudanzaPeajeCantidad_To), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJEVALOR") == 0 )
            {
               AV70TFMudanzaPeajevalor = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV70TFMudanzaPeajevalor", StringUtil.LTrimStr( AV70TFMudanzaPeajevalor, 18, 2));
               AV71TFMudanzaPeajevalor_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV71TFMudanzaPeajevalor_To", StringUtil.LTrimStr( AV71TFMudanzaPeajevalor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENID") == 0 )
            {
               AV72TFTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV72TFTipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(AV72TFTipoInmuebleOrigenId), 4, 0));
               AV73TFTipoInmuebleOrigenId_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV73TFTipoInmuebleOrigenId_To", StringUtil.LTrimStr( (decimal)(AV73TFTipoInmuebleOrigenId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE") == 0 )
            {
               AV124TFTipoInmuebleOrigenNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV124TFTipoInmuebleOrigenNombre", AV124TFTipoInmuebleOrigenNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE_SEL") == 0 )
            {
               AV125TFTipoInmuebleOrigenNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV125TFTipoInmuebleOrigenNombre_Sel", AV125TFTipoInmuebleOrigenNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENVALOR") == 0 )
            {
               AV76TFTipoInmuebleOrigenValor = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV76TFTipoInmuebleOrigenValor", StringUtil.LTrimStr( AV76TFTipoInmuebleOrigenValor, 18, 2));
               AV77TFTipoInmuebleOrigenValor_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV77TFTipoInmuebleOrigenValor_To", StringUtil.LTrimStr( AV77TFTipoInmuebleOrigenValor_To, 18, 2));
            }
            AV180GXV1 = (int)(AV180GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMudanzaAsesor_Sel)),  AV44TFMudanzaAsesor_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV117TFMudanzaHoraServicio_Sels.Count==0),  AV116TFMudanzaHoraServicio_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV119TFMudanzaRgoHoraservicio_Sels.Count==0),  AV118TFMudanzaRgoHoraservicio_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFMudanzaDireccionOrigen_Sel)),  AV61TFMudanzaDireccionOrigen_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV121TFMudanzaPisoDptoOrigen_Sels.Count==0),  AV120TFMudanzaPisoDptoOrigen_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFMudanzaDireccionDestino_Sel)),  AV63TFMudanzaDireccionDestino_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV123TFMudanzaPisoDptoDestino_Sel)),  AV123TFMudanzaPisoDptoDestino_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV109TFMudanzaVehiculoSugerido_Sels.Count==0),  AV108TFMudanzaVehiculoSugerido_SelsJson, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV125TFTipoInmuebleOrigenNombre_Sel)),  AV125TFTipoInmuebleOrigenNombre_Sel, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|||"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"||"+GXt_char11+"|||||"+GXt_char12+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMudanzaAsesor)),  AV43TFMudanzaAsesor, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFMudanzaDireccionOrigen)),  AV60TFMudanzaDireccionOrigen, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFMudanzaDireccionDestino)),  AV62TFMudanzaDireccionDestino, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV122TFMudanzaPisoDptoDestino)),  AV122TFMudanzaPisoDptoDestino, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV124TFTipoInmuebleOrigenNombre)),  AV124TFTipoInmuebleOrigenNombre, out  GXt_char8) ;
         Ddo_grid_Filteredtext_set = ((0==AV41TFMudanzaId) ? "" : StringUtil.Str( (decimal)(AV41TFMudanzaId), 18, 0))+"|"+GXt_char12+"|"+((DateTime.MinValue==AV45TFMudanzaFechaAlta) ? "" : context.localUtil.DToC( AV45TFMudanzaFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV50TFMudanzaFechaServicio) ? "" : context.localUtil.DToC( AV50TFMudanzaFechaServicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+GXt_char11+"||"+GXt_char10+"|"+GXt_char9+"|"+((Convert.ToDecimal(0)==AV64TFMudanzaDistancia) ? "" : StringUtil.Str( AV64TFMudanzaDistancia, 10, 2))+"||"+((Convert.ToDecimal(0)==AV130TFMudanzaPrecioBasexHora) ? "" : StringUtil.Str( AV130TFMudanzaPrecioBasexHora, 18, 2))+"|"+((0==AV68TFMudanzaPeajeCantidad) ? "" : StringUtil.Str( (decimal)(AV68TFMudanzaPeajeCantidad), 1, 0))+"|"+((Convert.ToDecimal(0)==AV70TFMudanzaPeajevalor) ? "" : StringUtil.Str( AV70TFMudanzaPeajevalor, 18, 2))+"|"+((0==AV72TFTipoInmuebleOrigenId) ? "" : StringUtil.Str( (decimal)(AV72TFTipoInmuebleOrigenId), 4, 0))+"|"+GXt_char8+"|"+((Convert.ToDecimal(0)==AV76TFTipoInmuebleOrigenValor) ? "" : StringUtil.Str( AV76TFTipoInmuebleOrigenValor, 18, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV42TFMudanzaId_To) ? "" : StringUtil.Str( (decimal)(AV42TFMudanzaId_To), 18, 0))+"||"+((DateTime.MinValue==AV46TFMudanzaFechaAlta_To) ? "" : context.localUtil.DToC( AV46TFMudanzaFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV51TFMudanzaFechaServicio_To) ? "" : context.localUtil.DToC( AV51TFMudanzaFechaServicio_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||||||"+((Convert.ToDecimal(0)==AV65TFMudanzaDistancia_To) ? "" : StringUtil.Str( AV65TFMudanzaDistancia_To, 10, 2))+"||"+((Convert.ToDecimal(0)==AV131TFMudanzaPrecioBasexHora_To) ? "" : StringUtil.Str( AV131TFMudanzaPrecioBasexHora_To, 18, 2))+"|"+((0==AV69TFMudanzaPeajeCantidad_To) ? "" : StringUtil.Str( (decimal)(AV69TFMudanzaPeajeCantidad_To), 1, 0))+"|"+((Convert.ToDecimal(0)==AV71TFMudanzaPeajevalor_To) ? "" : StringUtil.Str( AV71TFMudanzaPeajevalor_To, 18, 2))+"|"+((0==AV73TFTipoInmuebleOrigenId_To) ? "" : StringUtil.Str( (decimal)(AV73TFTipoInmuebleOrigenId_To), 4, 0))+"||"+((Convert.ToDecimal(0)==AV77TFTipoInmuebleOrigenValor_To) ? "" : StringUtil.Str( AV77TFTipoInmuebleOrigenValor_To, 18, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S232( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUDANZAASESOR") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20MudanzaAsesor1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20MudanzaAsesor1", AV20MudanzaAsesor1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUDANZAASESOR") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24MudanzaAsesor2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24MudanzaAsesor2", AV24MudanzaAsesor2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUDANZAASESOR") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28MudanzaAsesor3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28MudanzaAsesor3", AV28MudanzaAsesor3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV135Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAID",  context.GetMessage( "Id", ""),  !((0==AV41TFMudanzaId)&&(0==AV42TFMudanzaId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFMudanzaId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFMudanzaId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMUDANZAASESOR",  context.GetMessage( "Asesor", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMudanzaAsesor)),  0,  AV43TFMudanzaAsesor,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMudanzaAsesor_Sel)),  AV44TFMudanzaAsesor_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAFECHAALTA",  context.GetMessage( "Fecha Alta", ""),  !((DateTime.MinValue==AV45TFMudanzaFechaAlta)&&(DateTime.MinValue==AV46TFMudanzaFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV45TFMudanzaFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV46TFMudanzaFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAFECHASERVICIO",  context.GetMessage( "Fecha Servicio", ""),  !((DateTime.MinValue==AV50TFMudanzaFechaServicio)&&(DateTime.MinValue==AV51TFMudanzaFechaServicio_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV50TFMudanzaFechaServicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV51TFMudanzaFechaServicio_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAHORASERVICIO_SEL",  context.GetMessage( "Hora Servicio", ""),  !(AV117TFMudanzaHoraServicio_Sels.Count==0),  0,  AV117TFMudanzaHoraServicio_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZARGOHORASERVICIO_SEL",  context.GetMessage( "Rgo Horaservicio", ""),  !(AV119TFMudanzaRgoHoraservicio_Sels.Count==0),  0,  AV119TFMudanzaRgoHoraservicio_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMUDANZADIRECCIONORIGEN",  context.GetMessage( "Direccion Origen", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFMudanzaDireccionOrigen)),  0,  AV60TFMudanzaDireccionOrigen,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFMudanzaDireccionOrigen_Sel)),  AV61TFMudanzaDireccionOrigen_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAPISODPTOORIGEN_SEL",  context.GetMessage( "Dpto Origen", ""),  !(AV121TFMudanzaPisoDptoOrigen_Sels.Count==0),  0,  AV121TFMudanzaPisoDptoOrigen_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMUDANZADIRECCIONDESTINO",  context.GetMessage( "Direccion Destino", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFMudanzaDireccionDestino)),  0,  AV62TFMudanzaDireccionDestino,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFMudanzaDireccionDestino_Sel)),  AV63TFMudanzaDireccionDestino_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMUDANZAPISODPTODESTINO",  context.GetMessage( "Dpto Destino", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV122TFMudanzaPisoDptoDestino)),  0,  AV122TFMudanzaPisoDptoDestino,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV123TFMudanzaPisoDptoDestino_Sel)),  AV123TFMudanzaPisoDptoDestino_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZADISTANCIA",  context.GetMessage( "Distancia", ""),  !((Convert.ToDecimal(0)==AV64TFMudanzaDistancia)&&(Convert.ToDecimal(0)==AV65TFMudanzaDistancia_To)),  0,  StringUtil.Trim( StringUtil.Str( AV64TFMudanzaDistancia, 10, 2)),  StringUtil.Trim( StringUtil.Str( AV65TFMudanzaDistancia_To, 10, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAVEHICULOSUGERIDO_SEL",  context.GetMessage( "Vehiculo Sugerido", ""),  !(AV109TFMudanzaVehiculoSugerido_Sels.Count==0),  0,  AV109TFMudanzaVehiculoSugerido_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAPRECIOBASEXHORA",  context.GetMessage( "Basex Hora", ""),  !((Convert.ToDecimal(0)==AV130TFMudanzaPrecioBasexHora)&&(Convert.ToDecimal(0)==AV131TFMudanzaPrecioBasexHora_To)),  0,  StringUtil.Trim( StringUtil.Str( AV130TFMudanzaPrecioBasexHora, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV131TFMudanzaPrecioBasexHora_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAPEAJECANTIDAD",  context.GetMessage( "Peaje Cantidad", ""),  !((0==AV68TFMudanzaPeajeCantidad)&&(0==AV69TFMudanzaPeajeCantidad_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV68TFMudanzaPeajeCantidad), 1, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV69TFMudanzaPeajeCantidad_To), 1, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMUDANZAPEAJEVALOR",  context.GetMessage( "Peajevalor", ""),  !((Convert.ToDecimal(0)==AV70TFMudanzaPeajevalor)&&(Convert.ToDecimal(0)==AV71TFMudanzaPeajevalor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV70TFMudanzaPeajevalor, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV71TFMudanzaPeajevalor_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTIPOINMUEBLEORIGENID",  context.GetMessage( "Origen Id", ""),  !((0==AV72TFTipoInmuebleOrigenId)&&(0==AV73TFTipoInmuebleOrigenId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV72TFTipoInmuebleOrigenId), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV73TFTipoInmuebleOrigenId_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTIPOINMUEBLEORIGENNOMBRE",  context.GetMessage( "Origen Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV124TFTipoInmuebleOrigenNombre)),  0,  AV124TFTipoInmuebleOrigenNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV125TFTipoInmuebleOrigenNombre_Sel)),  AV125TFTipoInmuebleOrigenNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTIPOINMUEBLEORIGENVALOR",  context.GetMessage( "Origen Valor", ""),  !((Convert.ToDecimal(0)==AV76TFTipoInmuebleOrigenValor)&&(Convert.ToDecimal(0)==AV77TFTipoInmuebleOrigenValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV76TFTipoInmuebleOrigenValor, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV77TFTipoInmuebleOrigenValor_To, 18, 2))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV135Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MUDANZAASESOR") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MudanzaAsesor1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Asesor", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV20MudanzaAsesor1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MUDANZAASESOR") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24MudanzaAsesor2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Asesor", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV24MudanzaAsesor2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MUDANZAASESOR") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MudanzaAsesor3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Asesor", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV28MudanzaAsesor3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV135Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Mudanza";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S292( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new mudanzawwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
         }
      }

      protected void S302( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("mudanzawwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_93_E52( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, context.GetMessage( "Dynamic Filters Operator3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_MudanzaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_mudanzaasesor3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanzaasesor3_Internalname, context.GetMessage( "Mudanza Asesor3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanzaasesor3_Internalname, AV28MudanzaAsesor3, StringUtil.RTrim( context.localUtil.Format( AV28MudanzaAsesor3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanzaasesor3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanzaasesor3_Visible, edtavMudanzaasesor3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_93_E52e( true) ;
         }
         else
         {
            wb_table4_93_E52e( false) ;
         }
      }

      protected void wb_table3_71_E52( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, context.GetMessage( "Dynamic Filters Operator2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_MudanzaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_mudanzaasesor2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanzaasesor2_Internalname, context.GetMessage( "Mudanza Asesor2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanzaasesor2_Internalname, AV24MudanzaAsesor2, StringUtil.RTrim( context.localUtil.Format( AV24MudanzaAsesor2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanzaasesor2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanzaasesor2_Visible, edtavMudanzaasesor2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_71_E52e( true) ;
         }
         else
         {
            wb_table3_71_E52e( false) ;
         }
      }

      protected void wb_table2_49_E52( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, context.GetMessage( "Dynamic Filters Operator1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_MudanzaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_mudanzaasesor1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanzaasesor1_Internalname, context.GetMessage( "Mudanza Asesor1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanzaasesor1_Internalname, AV20MudanzaAsesor1, StringUtil.RTrim( context.localUtil.Format( AV20MudanzaAsesor1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanzaasesor1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanzaasesor1_Visible, edtavMudanzaasesor1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_E52e( true) ;
         }
         else
         {
            wb_table2_49_E52e( false) ;
         }
      }

      protected void wb_table1_25_E52( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_E52( true) ;
         }
         else
         {
            wb_table5_30_E52( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_E52e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_E52e( true) ;
         }
         else
         {
            wb_table1_25_E52e( false) ;
         }
      }

      protected void wb_table5_30_E52( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_MudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_E52e( true) ;
         }
         else
         {
            wb_table5_30_E52e( false) ;
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
         PAE52( ) ;
         WSE52( ) ;
         WEE52( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026862257240", true, true, false);
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
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true, false);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("mudanzaww.js", "?2026862257241", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1112( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_111_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_111_idx;
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR_"+sGXsfl_111_idx;
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA_"+sGXsfl_111_idx;
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO_"+sGXsfl_111_idx;
         cmbMudanzaHoraServicio_Internalname = "MUDANZAHORASERVICIO_"+sGXsfl_111_idx;
         cmbMudanzaRgoHoraservicio_Internalname = "MUDANZARGOHORASERVICIO_"+sGXsfl_111_idx;
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN_"+sGXsfl_111_idx;
         cmbMudanzaPisoDptoOrigen_Internalname = "MUDANZAPISODPTOORIGEN_"+sGXsfl_111_idx;
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO_"+sGXsfl_111_idx;
         edtMudanzaPisoDptoDestino_Internalname = "MUDANZAPISODPTODESTINO_"+sGXsfl_111_idx;
         edtMudanzaDistancia_Internalname = "MUDANZADISTANCIA_"+sGXsfl_111_idx;
         cmbMudanzaVehiculoSugerido_Internalname = "MUDANZAVEHICULOSUGERIDO_"+sGXsfl_111_idx;
         edtMudanzaPrecioBasexHora_Internalname = "MUDANZAPRECIOBASEXHORA_"+sGXsfl_111_idx;
         edtMudanzaPeajeCantidad_Internalname = "MUDANZAPEAJECANTIDAD_"+sGXsfl_111_idx;
         edtMudanzaPeajevalor_Internalname = "MUDANZAPEAJEVALOR_"+sGXsfl_111_idx;
         edtTipoInmuebleOrigenId_Internalname = "TIPOINMUEBLEORIGENID_"+sGXsfl_111_idx;
         edtTipoInmuebleOrigenNombre_Internalname = "TIPOINMUEBLEORIGENNOMBRE_"+sGXsfl_111_idx;
         edtTipoInmuebleOrigenValor_Internalname = "TIPOINMUEBLEORIGENVALOR_"+sGXsfl_111_idx;
      }

      protected void SubsflControlProps_fel_1112( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_111_fel_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_111_fel_idx;
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR_"+sGXsfl_111_fel_idx;
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA_"+sGXsfl_111_fel_idx;
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO_"+sGXsfl_111_fel_idx;
         cmbMudanzaHoraServicio_Internalname = "MUDANZAHORASERVICIO_"+sGXsfl_111_fel_idx;
         cmbMudanzaRgoHoraservicio_Internalname = "MUDANZARGOHORASERVICIO_"+sGXsfl_111_fel_idx;
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN_"+sGXsfl_111_fel_idx;
         cmbMudanzaPisoDptoOrigen_Internalname = "MUDANZAPISODPTOORIGEN_"+sGXsfl_111_fel_idx;
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO_"+sGXsfl_111_fel_idx;
         edtMudanzaPisoDptoDestino_Internalname = "MUDANZAPISODPTODESTINO_"+sGXsfl_111_fel_idx;
         edtMudanzaDistancia_Internalname = "MUDANZADISTANCIA_"+sGXsfl_111_fel_idx;
         cmbMudanzaVehiculoSugerido_Internalname = "MUDANZAVEHICULOSUGERIDO_"+sGXsfl_111_fel_idx;
         edtMudanzaPrecioBasexHora_Internalname = "MUDANZAPRECIOBASEXHORA_"+sGXsfl_111_fel_idx;
         edtMudanzaPeajeCantidad_Internalname = "MUDANZAPEAJECANTIDAD_"+sGXsfl_111_fel_idx;
         edtMudanzaPeajevalor_Internalname = "MUDANZAPEAJEVALOR_"+sGXsfl_111_fel_idx;
         edtTipoInmuebleOrigenId_Internalname = "TIPOINMUEBLEORIGENID_"+sGXsfl_111_fel_idx;
         edtTipoInmuebleOrigenNombre_Internalname = "TIPOINMUEBLEORIGENNOMBRE_"+sGXsfl_111_fel_idx;
         edtTipoInmuebleOrigenValor_Internalname = "TIPOINMUEBLEORIGENVALOR_"+sGXsfl_111_fel_idx;
      }

      protected void sendrow_1112( )
      {
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         WBE50( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_111_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_111_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_111_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_111_idx + "',111)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_111_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV101GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV101GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV101GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV101GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_111_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV101GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMudanzaAsesor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaAsesor_Internalname,(string)A736MudanzaAsesor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMudanzaAsesor_Link,(string)"",(string)"",(string)"",(string)edtMudanzaAsesor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaAsesor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaFechaAlta_Internalname,context.localUtil.Format(A737MudanzaFechaAlta, "99/99/99"),context.localUtil.Format( A737MudanzaFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaFechaServicio_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaFechaServicio_Internalname,context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"),context.localUtil.Format( A738MudanzaFechaServicio, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaFechaServicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaFechaServicio_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMudanzaHoraServicio.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMudanzaHoraServicio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZAHORASERVICIO_" + sGXsfl_111_idx;
               cmbMudanzaHoraServicio.Name = GXCCtl;
               cmbMudanzaHoraServicio.WebTags = "";
               cmbMudanzaHoraServicio.addItem("08", "08:00", 0);
               cmbMudanzaHoraServicio.addItem("09", "09:00", 0);
               cmbMudanzaHoraServicio.addItem("10", "10:00", 0);
               cmbMudanzaHoraServicio.addItem("11", "11:00", 0);
               cmbMudanzaHoraServicio.addItem("12", "12:00", 0);
               cmbMudanzaHoraServicio.addItem("13", "13:00", 0);
               cmbMudanzaHoraServicio.addItem("14", "14:00", 0);
               cmbMudanzaHoraServicio.addItem("15", "15:00", 0);
               cmbMudanzaHoraServicio.addItem("16", "16:00", 0);
               cmbMudanzaHoraServicio.addItem("17", "17:00", 0);
               cmbMudanzaHoraServicio.addItem("18", "18:00", 0);
               cmbMudanzaHoraServicio.addItem("19", "19:00", 0);
               if ( cmbMudanzaHoraServicio.ItemCount > 0 )
               {
                  A739MudanzaHoraServicio = cmbMudanzaHoraServicio.getValidValue(A739MudanzaHoraServicio);
                  n739MudanzaHoraServicio = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaHoraServicio,(string)cmbMudanzaHoraServicio_Internalname,StringUtil.RTrim( A739MudanzaHoraServicio),(short)1,(string)cmbMudanzaHoraServicio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbMudanzaHoraServicio.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaHoraServicio.CurrentValue = StringUtil.RTrim( A739MudanzaHoraServicio);
            AssignProp("", false, cmbMudanzaHoraServicio_Internalname, "Values", (string)(cmbMudanzaHoraServicio.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMudanzaRgoHoraservicio.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMudanzaRgoHoraservicio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZARGOHORASERVICIO_" + sGXsfl_111_idx;
               cmbMudanzaRgoHoraservicio.Name = GXCCtl;
               cmbMudanzaRgoHoraservicio.WebTags = "";
               cmbMudanzaRgoHoraservicio.addItem("08-12", "08:00 - 12:00", 0);
               cmbMudanzaRgoHoraservicio.addItem("12-16", "12:00 - 16:00", 0);
               cmbMudanzaRgoHoraservicio.addItem("16-20", "16:00 - 20:00", 0);
               if ( cmbMudanzaRgoHoraservicio.ItemCount > 0 )
               {
                  A776MudanzaRgoHoraservicio = cmbMudanzaRgoHoraservicio.getValidValue(A776MudanzaRgoHoraservicio);
                  n776MudanzaRgoHoraservicio = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaRgoHoraservicio,(string)cmbMudanzaRgoHoraservicio_Internalname,StringUtil.RTrim( A776MudanzaRgoHoraservicio),(short)1,(string)cmbMudanzaRgoHoraservicio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbMudanzaRgoHoraservicio.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaRgoHoraservicio.CurrentValue = StringUtil.RTrim( A776MudanzaRgoHoraservicio);
            AssignProp("", false, cmbMudanzaRgoHoraservicio_Internalname, "Values", (string)(cmbMudanzaRgoHoraservicio.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMudanzaDireccionOrigen_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaDireccionOrigen_Internalname,(string)A740MudanzaDireccionOrigen,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaDireccionOrigen_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaDireccionOrigen_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMudanzaPisoDptoOrigen.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMudanzaPisoDptoOrigen.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZAPISODPTOORIGEN_" + sGXsfl_111_idx;
               cmbMudanzaPisoDptoOrigen.Name = GXCCtl;
               cmbMudanzaPisoDptoOrigen.WebTags = "";
               if ( cmbMudanzaPisoDptoOrigen.ItemCount > 0 )
               {
                  A777MudanzaPisoDptoOrigen = cmbMudanzaPisoDptoOrigen.getValidValue(A777MudanzaPisoDptoOrigen);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaPisoDptoOrigen,(string)cmbMudanzaPisoDptoOrigen_Internalname,StringUtil.RTrim( A777MudanzaPisoDptoOrigen),(short)1,(string)cmbMudanzaPisoDptoOrigen_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbMudanzaPisoDptoOrigen.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaPisoDptoOrigen.CurrentValue = StringUtil.RTrim( A777MudanzaPisoDptoOrigen);
            AssignProp("", false, cmbMudanzaPisoDptoOrigen_Internalname, "Values", (string)(cmbMudanzaPisoDptoOrigen.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMudanzaDireccionDestino_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaDireccionDestino_Internalname,(string)A741MudanzaDireccionDestino,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaDireccionDestino_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaDireccionDestino_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMudanzaPisoDptoDestino_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPisoDptoDestino_Internalname,StringUtil.RTrim( A778MudanzaPisoDptoDestino),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPisoDptoDestino_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtMudanzaPisoDptoDestino_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaDistancia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaDistancia_Internalname,StringUtil.LTrim( StringUtil.NToC( A762MudanzaDistancia, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A762MudanzaDistancia, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaDistancia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaDistancia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMudanzaVehiculoSugerido.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMudanzaVehiculoSugerido.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MUDANZAVEHICULOSUGERIDO_" + sGXsfl_111_idx;
               cmbMudanzaVehiculoSugerido.Name = GXCCtl;
               cmbMudanzaVehiculoSugerido.WebTags = "";
               if ( cmbMudanzaVehiculoSugerido.ItemCount > 0 )
               {
                  A742MudanzaVehiculoSugerido = cmbMudanzaVehiculoSugerido.getValidValue(A742MudanzaVehiculoSugerido);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMudanzaVehiculoSugerido,(string)cmbMudanzaVehiculoSugerido_Internalname,StringUtil.RTrim( A742MudanzaVehiculoSugerido),(short)1,(string)cmbMudanzaVehiculoSugerido_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbMudanzaVehiculoSugerido.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMudanzaVehiculoSugerido.CurrentValue = StringUtil.RTrim( A742MudanzaVehiculoSugerido);
            AssignProp("", false, cmbMudanzaVehiculoSugerido_Internalname, "Values", (string)(cmbMudanzaVehiculoSugerido.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaPrecioBasexHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPrecioBasexHora_Internalname,StringUtil.LTrim( StringUtil.NToC( A780MudanzaPrecioBasexHora, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A780MudanzaPrecioBasexHora, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPrecioBasexHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtMudanzaPrecioBasexHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaPeajeCantidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPeajeCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A761MudanzaPeajeCantidad), 1, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A761MudanzaPeajeCantidad), "9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPeajeCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaPeajeCantidad_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMudanzaPeajevalor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaPeajevalor_Internalname,StringUtil.LTrim( StringUtil.NToC( A760MudanzaPeajevalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A760MudanzaPeajevalor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaPeajevalor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMudanzaPeajevalor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtTipoInmuebleOrigenId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoInmuebleOrigenId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A743TipoInmuebleOrigenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A743TipoInmuebleOrigenId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoInmuebleOrigenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTipoInmuebleOrigenId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtTipoInmuebleOrigenNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoInmuebleOrigenNombre_Internalname,(string)A755TipoInmuebleOrigenNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoInmuebleOrigenNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTipoInmuebleOrigenNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"ParametroNombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtTipoInmuebleOrigenValor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoInmuebleOrigenValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A756TipoInmuebleOrigenValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A756TipoInmuebleOrigenValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoInmuebleOrigenValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTipoInmuebleOrigenValor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesE52( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_111_idx = ((subGrid_Islastpage==1)&&(nGXsfl_111_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         /* End function sendrow_1112 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("MUDANZAASESOR", context.GetMessage( "Asesor", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("MUDANZAASESOR", context.GetMessage( "Asesor", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("MUDANZAASESOR", context.GetMessage( "Asesor", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_111_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV101GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV101GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV101GridActions), 4, 0));
         }
         GXCCtl = "MUDANZAHORASERVICIO_" + sGXsfl_111_idx;
         cmbMudanzaHoraServicio.Name = GXCCtl;
         cmbMudanzaHoraServicio.WebTags = "";
         cmbMudanzaHoraServicio.addItem("08", "08:00", 0);
         cmbMudanzaHoraServicio.addItem("09", "09:00", 0);
         cmbMudanzaHoraServicio.addItem("10", "10:00", 0);
         cmbMudanzaHoraServicio.addItem("11", "11:00", 0);
         cmbMudanzaHoraServicio.addItem("12", "12:00", 0);
         cmbMudanzaHoraServicio.addItem("13", "13:00", 0);
         cmbMudanzaHoraServicio.addItem("14", "14:00", 0);
         cmbMudanzaHoraServicio.addItem("15", "15:00", 0);
         cmbMudanzaHoraServicio.addItem("16", "16:00", 0);
         cmbMudanzaHoraServicio.addItem("17", "17:00", 0);
         cmbMudanzaHoraServicio.addItem("18", "18:00", 0);
         cmbMudanzaHoraServicio.addItem("19", "19:00", 0);
         if ( cmbMudanzaHoraServicio.ItemCount > 0 )
         {
            A739MudanzaHoraServicio = cmbMudanzaHoraServicio.getValidValue(A739MudanzaHoraServicio);
            n739MudanzaHoraServicio = false;
         }
         GXCCtl = "MUDANZARGOHORASERVICIO_" + sGXsfl_111_idx;
         cmbMudanzaRgoHoraservicio.Name = GXCCtl;
         cmbMudanzaRgoHoraservicio.WebTags = "";
         cmbMudanzaRgoHoraservicio.addItem("08-12", "08:00 - 12:00", 0);
         cmbMudanzaRgoHoraservicio.addItem("12-16", "12:00 - 16:00", 0);
         cmbMudanzaRgoHoraservicio.addItem("16-20", "16:00 - 20:00", 0);
         if ( cmbMudanzaRgoHoraservicio.ItemCount > 0 )
         {
            A776MudanzaRgoHoraservicio = cmbMudanzaRgoHoraservicio.getValidValue(A776MudanzaRgoHoraservicio);
            n776MudanzaRgoHoraservicio = false;
         }
         GXCCtl = "MUDANZAPISODPTOORIGEN_" + sGXsfl_111_idx;
         cmbMudanzaPisoDptoOrigen.Name = GXCCtl;
         cmbMudanzaPisoDptoOrigen.WebTags = "";
         if ( cmbMudanzaPisoDptoOrigen.ItemCount > 0 )
         {
            A777MudanzaPisoDptoOrigen = cmbMudanzaPisoDptoOrigen.getValidValue(A777MudanzaPisoDptoOrigen);
         }
         GXCCtl = "MUDANZAVEHICULOSUGERIDO_" + sGXsfl_111_idx;
         cmbMudanzaVehiculoSugerido.Name = GXCCtl;
         cmbMudanzaVehiculoSugerido.WebTags = "";
         if ( cmbMudanzaVehiculoSugerido.ItemCount > 0 )
         {
            A742MudanzaVehiculoSugerido = cmbMudanzaVehiculoSugerido.getValidValue(A742MudanzaVehiculoSugerido);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl111( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"111\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaAsesor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Asesor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaFechaServicio_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Servicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMudanzaHoraServicio.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora Servicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMudanzaRgoHoraservicio.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rgo Horaservicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaDireccionOrigen_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Direccion Origen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMudanzaPisoDptoOrigen.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dpto Origen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaDireccionDestino_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Direccion Destino", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaPisoDptoDestino_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dpto Destino", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaDistancia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Distancia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMudanzaVehiculoSugerido.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Vehiculo Sugerido", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaPrecioBasexHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Basex Hora", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaPeajeCantidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Peaje Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMudanzaPeajevalor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Peajevalor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTipoInmuebleOrigenId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTipoInmuebleOrigenNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTipoInmuebleOrigenValor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Valor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV101GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A736MudanzaAsesor));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMudanzaAsesor_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaAsesor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A737MudanzaFechaAlta, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaFechaServicio_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A739MudanzaHoraServicio)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMudanzaHoraServicio.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A776MudanzaRgoHoraservicio)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMudanzaRgoHoraservicio.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A740MudanzaDireccionOrigen));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaDireccionOrigen_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A777MudanzaPisoDptoOrigen)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMudanzaPisoDptoOrigen.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A741MudanzaDireccionDestino));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaDireccionDestino_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A778MudanzaPisoDptoDestino)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaPisoDptoDestino_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A762MudanzaDistancia, 10, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaDistancia_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A742MudanzaVehiculoSugerido));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMudanzaVehiculoSugerido.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A780MudanzaPrecioBasexHora, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaPrecioBasexHora_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A761MudanzaPeajeCantidad), 1, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaPeajeCantidad_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A760MudanzaPeajevalor, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMudanzaPeajevalor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A743TipoInmuebleOrigenId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoInmuebleOrigenId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A755TipoInmuebleOrigenNombre));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoInmuebleOrigenNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A756TipoInmuebleOrigenValor, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoInmuebleOrigenValor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavMudanzaasesor1_Internalname = "vMUDANZAASESOR1";
         cellFilter_mudanzaasesor1_cell_Internalname = "FILTER_MUDANZAASESOR1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavMudanzaasesor2_Internalname = "vMUDANZAASESOR2";
         cellFilter_mudanzaasesor2_cell_Internalname = "FILTER_MUDANZAASESOR2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavMudanzaasesor3_Internalname = "vMUDANZAASESOR3";
         cellFilter_mudanzaasesor3_cell_Internalname = "FILTER_MUDANZAASESOR3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtMudanzaId_Internalname = "MUDANZAID";
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR";
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA";
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO";
         cmbMudanzaHoraServicio_Internalname = "MUDANZAHORASERVICIO";
         cmbMudanzaRgoHoraservicio_Internalname = "MUDANZARGOHORASERVICIO";
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN";
         cmbMudanzaPisoDptoOrigen_Internalname = "MUDANZAPISODPTOORIGEN";
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO";
         edtMudanzaPisoDptoDestino_Internalname = "MUDANZAPISODPTODESTINO";
         edtMudanzaDistancia_Internalname = "MUDANZADISTANCIA";
         cmbMudanzaVehiculoSugerido_Internalname = "MUDANZAVEHICULOSUGERIDO";
         edtMudanzaPrecioBasexHora_Internalname = "MUDANZAPRECIOBASEXHORA";
         edtMudanzaPeajeCantidad_Internalname = "MUDANZAPEAJECANTIDAD";
         edtMudanzaPeajevalor_Internalname = "MUDANZAPEAJEVALOR";
         edtTipoInmuebleOrigenId_Internalname = "TIPOINMUEBLEORIGENID";
         edtTipoInmuebleOrigenNombre_Internalname = "TIPOINMUEBLEORIGENNOMBRE";
         edtTipoInmuebleOrigenValor_Internalname = "TIPOINMUEBLEORIGENVALOR";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_mudanzafechaaltaauxdatetext_Internalname = "vDDO_MUDANZAFECHAALTAAUXDATETEXT";
         Tfmudanzafechaalta_rangepicker_Internalname = "TFMUDANZAFECHAALTA_RANGEPICKER";
         divDdo_mudanzafechaaltaauxdates_Internalname = "DDO_MUDANZAFECHAALTAAUXDATES";
         edtavDdo_mudanzafechaservicioauxdatetext_Internalname = "vDDO_MUDANZAFECHASERVICIOAUXDATETEXT";
         Tfmudanzafechaservicio_rangepicker_Internalname = "TFMUDANZAFECHASERVICIO_RANGEPICKER";
         divDdo_mudanzafechaservicioauxdates_Internalname = "DDO_MUDANZAFECHASERVICIOAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtTipoInmuebleOrigenValor_Jsonclick = "";
         edtTipoInmuebleOrigenNombre_Jsonclick = "";
         edtTipoInmuebleOrigenId_Jsonclick = "";
         edtMudanzaPeajevalor_Jsonclick = "";
         edtMudanzaPeajeCantidad_Jsonclick = "";
         edtMudanzaPrecioBasexHora_Jsonclick = "";
         cmbMudanzaVehiculoSugerido_Jsonclick = "";
         edtMudanzaDistancia_Jsonclick = "";
         edtMudanzaPisoDptoDestino_Jsonclick = "";
         edtMudanzaDireccionDestino_Jsonclick = "";
         cmbMudanzaPisoDptoOrigen_Jsonclick = "";
         edtMudanzaDireccionOrigen_Jsonclick = "";
         cmbMudanzaRgoHoraservicio_Jsonclick = "";
         cmbMudanzaHoraServicio_Jsonclick = "";
         edtMudanzaFechaServicio_Jsonclick = "";
         edtMudanzaFechaAlta_Jsonclick = "";
         edtMudanzaAsesor_Jsonclick = "";
         edtMudanzaAsesor_Link = "";
         edtMudanzaId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavMudanzaasesor1_Jsonclick = "";
         edtavMudanzaasesor1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavMudanzaasesor2_Jsonclick = "";
         edtavMudanzaasesor2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavMudanzaasesor3_Jsonclick = "";
         edtavMudanzaasesor3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavMudanzaasesor3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavMudanzaasesor2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavMudanzaasesor1_Visible = 1;
         edtTipoInmuebleOrigenValor_Visible = -1;
         edtTipoInmuebleOrigenNombre_Visible = -1;
         edtTipoInmuebleOrigenId_Visible = -1;
         edtMudanzaPeajevalor_Visible = -1;
         edtMudanzaPeajeCantidad_Visible = -1;
         edtMudanzaPrecioBasexHora_Visible = -1;
         cmbMudanzaVehiculoSugerido.Visible = -1;
         edtMudanzaDistancia_Visible = -1;
         edtMudanzaPisoDptoDestino_Visible = -1;
         edtMudanzaDireccionDestino_Visible = -1;
         cmbMudanzaPisoDptoOrigen.Visible = -1;
         edtMudanzaDireccionOrigen_Visible = -1;
         cmbMudanzaRgoHoraservicio.Visible = -1;
         cmbMudanzaHoraServicio.Visible = -1;
         edtMudanzaFechaServicio_Visible = -1;
         edtMudanzaFechaAlta_Visible = -1;
         edtMudanzaAsesor_Visible = -1;
         edtMudanzaId_Visible = -1;
         edtTipoInmuebleOrigenValor_Enabled = 0;
         edtTipoInmuebleOrigenNombre_Enabled = 0;
         edtTipoInmuebleOrigenId_Enabled = 0;
         edtMudanzaPeajevalor_Enabled = 0;
         edtMudanzaPeajeCantidad_Enabled = 0;
         edtMudanzaPrecioBasexHora_Enabled = 0;
         cmbMudanzaVehiculoSugerido.Enabled = 0;
         edtMudanzaDistancia_Enabled = 0;
         edtMudanzaPisoDptoDestino_Enabled = 0;
         edtMudanzaDireccionDestino_Enabled = 0;
         cmbMudanzaPisoDptoOrigen.Enabled = 0;
         edtMudanzaDireccionOrigen_Enabled = 0;
         cmbMudanzaRgoHoraservicio.Enabled = 0;
         cmbMudanzaHoraServicio.Enabled = 0;
         edtMudanzaFechaServicio_Enabled = 0;
         edtMudanzaFechaAlta_Enabled = 0;
         edtMudanzaAsesor_Enabled = 0;
         edtMudanzaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_mudanzafechaservicioauxdatetext_Jsonclick = "";
         edtavDdo_mudanzafechaaltaauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "18.0||||||||||10.2||8.2|1.0|8.2|4.0||8.2";
         Ddo_grid_Datalistproc = "MudanzaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||08:08\\\\:00,09:09\\\\:00,10:10\\\\:00,11:11\\\\:00,12:12\\\\:00,13:13\\\\:00,14:14\\\\:00,15:15\\\\:00,16:16\\\\:00,17:17\\\\:00,18:18\\\\:00,19:19\\\\:00|08-12:08\\\\:00 - 12\\\\:00,12-16:12\\\\:00 - 16\\\\:00,16-20:16\\\\:00 - 20\\\\:00||||||||||||";
         Ddo_grid_Allowmultipleselection = "||||T|T||T||||T||||||";
         Ddo_grid_Datalisttype = "|Dynamic|||FixedValues|FixedValues|Dynamic|FixedValues|Dynamic|Dynamic||FixedValues|||||Dynamic|";
         Ddo_grid_Includedatalist = "|T|||T|T|T|T|T|T||T|||||T|";
         Ddo_grid_Filterisrange = "T||P|P|||||||T||T|T|T|T||T";
         Ddo_grid_Filtertype = "Numeric|Character|Date|Date|||Character||Character|Character|Numeric||Numeric|Numeric|Numeric|Numeric|Character|Numeric";
         Ddo_grid_Includefilter = "T|T|T|T|||T||T|T|T||T|T|T|T|T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18";
         Ddo_grid_Columnids = "1:MudanzaId|2:MudanzaAsesor|3:MudanzaFechaAlta|4:MudanzaFechaServicio|5:MudanzaHoraServicio|6:MudanzaRgoHoraservicio|7:MudanzaDireccionOrigen|8:MudanzaPisoDptoOrigen|9:MudanzaDireccionDestino|10:MudanzaPisoDptoDestino|11:MudanzaDistancia|12:MudanzaVehiculoSugerido|13:MudanzaPrecioBasexHora|14:MudanzaPeajeCantidad|15:MudanzaPeajevalor|16:TipoInmuebleOrigenId|17:TipoInmuebleOrigenNombre|18:TipoInmuebleOrigenValor";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Mudanza", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV108TFMudanzaVehiculoSugerido_SelsJson',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELSJSON',pic:'',type:'vchar'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV120TFMudanzaPisoDptoOrigen_SelsJson',fld:'vTFMUDANZAPISODPTOORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV118TFMudanzaRgoHoraservicio_SelsJson',fld:'vTFMUDANZARGOHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV116TFMudanzaHoraServicio_SelsJson',fld:'vTFMUDANZAHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E29E52',iparms:[{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV101GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtMudanzaAsesor_Link',ctrl:'MUDANZAASESOR',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E22E52',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMudanzaasesor2_Visible',ctrl:'vMUDANZAASESOR2',prop:'Visible'},{av:'edtavMudanzaasesor3_Visible',ctrl:'vMUDANZAASESOR3',prop:'Visible'},{av:'edtavMudanzaasesor1_Visible',ctrl:'vMUDANZAASESOR1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E23E52',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavMudanzaasesor1_Visible',ctrl:'vMUDANZAASESOR1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E24E52',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMudanzaasesor2_Visible',ctrl:'vMUDANZAASESOR2',prop:'Visible'},{av:'edtavMudanzaasesor3_Visible',ctrl:'vMUDANZAASESOR3',prop:'Visible'},{av:'edtavMudanzaasesor1_Visible',ctrl:'vMUDANZAASESOR1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E25E52',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavMudanzaasesor2_Visible',ctrl:'vMUDANZAASESOR2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMudanzaasesor2_Visible',ctrl:'vMUDANZAASESOR2',prop:'Visible'},{av:'edtavMudanzaasesor3_Visible',ctrl:'vMUDANZAASESOR3',prop:'Visible'},{av:'edtavMudanzaasesor1_Visible',ctrl:'vMUDANZAASESOR1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E26E52',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavMudanzaasesor3_Visible',ctrl:'vMUDANZAASESOR3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11E52',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV116TFMudanzaHoraServicio_SelsJson',fld:'vTFMUDANZAHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV118TFMudanzaRgoHoraservicio_SelsJson',fld:'vTFMUDANZARGOHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV120TFMudanzaPisoDptoOrigen_SelsJson',fld:'vTFMUDANZAPISODPTOORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV108TFMudanzaVehiculoSugerido_SelsJson',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV108TFMudanzaVehiculoSugerido_SelsJson',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELSJSON',pic:'',type:'vchar'},{av:'AV120TFMudanzaPisoDptoOrigen_SelsJson',fld:'vTFMUDANZAPISODPTOORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV118TFMudanzaRgoHoraservicio_SelsJson',fld:'vTFMUDANZARGOHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV116TFMudanzaHoraServicio_SelsJson',fld:'vTFMUDANZAHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'edtavMudanzaasesor1_Visible',ctrl:'vMUDANZAASESOR1',prop:'Visible'},{av:'edtavMudanzaasesor2_Visible',ctrl:'vMUDANZAASESOR2',prop:'Visible'},{av:'edtavMudanzaasesor3_Visible',ctrl:'vMUDANZAASESOR3',prop:'Visible'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E30E52',iparms:[{av:'cmbavGridactions'},{av:'AV101GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV101GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E21E52',iparms:[{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14E52',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV116TFMudanzaHoraServicio_SelsJson',fld:'vTFMUDANZAHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV118TFMudanzaRgoHoraservicio_SelsJson',fld:'vTFMUDANZARGOHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV120TFMudanzaPisoDptoOrigen_SelsJson',fld:'vTFMUDANZAPISODPTOORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV108TFMudanzaVehiculoSugerido_SelsJson',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELSJSON',pic:'',type:'vchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20MudanzaAsesor1',fld:'vMUDANZAASESOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24MudanzaAsesor2',fld:'vMUDANZAASESOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28MudanzaAsesor3',fld:'vMUDANZAASESOR3',pic:'',type:'svchar'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV135Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFMudanzaId',fld:'vTFMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMudanzaId_To',fld:'vTFMUDANZAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFMudanzaAsesor',fld:'vTFMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV44TFMudanzaAsesor_Sel',fld:'vTFMUDANZAASESOR_SEL',pic:'',type:'svchar'},{av:'AV45TFMudanzaFechaAlta',fld:'vTFMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV46TFMudanzaFechaAlta_To',fld:'vTFMUDANZAFECHAALTA_TO',pic:'',type:'date'},{av:'AV50TFMudanzaFechaServicio',fld:'vTFMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'AV51TFMudanzaFechaServicio_To',fld:'vTFMUDANZAFECHASERVICIO_TO',pic:'',type:'date'},{av:'AV117TFMudanzaHoraServicio_Sels',fld:'vTFMUDANZAHORASERVICIO_SELS',pic:''},{av:'AV119TFMudanzaRgoHoraservicio_Sels',fld:'vTFMUDANZARGOHORASERVICIO_SELS',pic:''},{av:'AV60TFMudanzaDireccionOrigen',fld:'vTFMUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'AV61TFMudanzaDireccionOrigen_Sel',fld:'vTFMUDANZADIRECCIONORIGEN_SEL',pic:'',type:'svchar'},{av:'AV121TFMudanzaPisoDptoOrigen_Sels',fld:'vTFMUDANZAPISODPTOORIGEN_SELS',pic:''},{av:'AV62TFMudanzaDireccionDestino',fld:'vTFMUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'AV63TFMudanzaDireccionDestino_Sel',fld:'vTFMUDANZADIRECCIONDESTINO_SEL',pic:'',type:'svchar'},{av:'AV122TFMudanzaPisoDptoDestino',fld:'vTFMUDANZAPISODPTODESTINO',pic:'',type:'char'},{av:'AV123TFMudanzaPisoDptoDestino_Sel',fld:'vTFMUDANZAPISODPTODESTINO_SEL',pic:'',type:'char'},{av:'AV64TFMudanzaDistancia',fld:'vTFMUDANZADISTANCIA',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV65TFMudanzaDistancia_To',fld:'vTFMUDANZADISTANCIA_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV109TFMudanzaVehiculoSugerido_Sels',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELS',pic:''},{av:'AV130TFMudanzaPrecioBasexHora',fld:'vTFMUDANZAPRECIOBASEXHORA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV131TFMudanzaPrecioBasexHora_To',fld:'vTFMUDANZAPRECIOBASEXHORA_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68TFMudanzaPeajeCantidad',fld:'vTFMUDANZAPEAJECANTIDAD',pic:'9',type:'int'},{av:'AV69TFMudanzaPeajeCantidad_To',fld:'vTFMUDANZAPEAJECANTIDAD_TO',pic:'9',type:'int'},{av:'AV70TFMudanzaPeajevalor',fld:'vTFMUDANZAPEAJEVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV71TFMudanzaPeajevalor_To',fld:'vTFMUDANZAPEAJEVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV72TFTipoInmuebleOrigenId',fld:'vTFTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV73TFTipoInmuebleOrigenId_To',fld:'vTFTIPOINMUEBLEORIGENID_TO',pic:'ZZZ9',type:'int'},{av:'AV124TFTipoInmuebleOrigenNombre',fld:'vTFTIPOINMUEBLEORIGENNOMBRE',pic:'',type:'svchar'},{av:'AV125TFTipoInmuebleOrigenNombre_Sel',fld:'vTFTIPOINMUEBLEORIGENNOMBRE_SEL',pic:'',type:'svchar'},{av:'AV76TFTipoInmuebleOrigenValor',fld:'vTFTIPOINMUEBLEORIGENVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV77TFTipoInmuebleOrigenValor_To',fld:'vTFTIPOINMUEBLEORIGENVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV132ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV134SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV108TFMudanzaVehiculoSugerido_SelsJson',fld:'vTFMUDANZAVEHICULOSUGERIDO_SELSJSON',pic:'',type:'vchar'},{av:'AV120TFMudanzaPisoDptoOrigen_SelsJson',fld:'vTFMUDANZAPISODPTOORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV118TFMudanzaRgoHoraservicio_SelsJson',fld:'vTFMUDANZARGOHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'AV116TFMudanzaHoraServicio_SelsJson',fld:'vTFMUDANZAHORASERVICIO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMudanzaasesor1_Visible',ctrl:'vMUDANZAASESOR1',prop:'Visible'},{av:'edtavMudanzaasesor2_Visible',ctrl:'vMUDANZAASESOR2',prop:'Visible'},{av:'edtavMudanzaasesor3_Visible',ctrl:'vMUDANZAASESOR3',prop:'Visible'},{av:'edtMudanzaId_Visible',ctrl:'MUDANZAID',prop:'Visible'},{av:'edtMudanzaAsesor_Visible',ctrl:'MUDANZAASESOR',prop:'Visible'},{av:'edtMudanzaFechaAlta_Visible',ctrl:'MUDANZAFECHAALTA',prop:'Visible'},{av:'edtMudanzaFechaServicio_Visible',ctrl:'MUDANZAFECHASERVICIO',prop:'Visible'},{av:'cmbMudanzaHoraServicio'},{av:'cmbMudanzaRgoHoraservicio'},{av:'edtMudanzaDireccionOrigen_Visible',ctrl:'MUDANZADIRECCIONORIGEN',prop:'Visible'},{av:'cmbMudanzaPisoDptoOrigen'},{av:'edtMudanzaDireccionDestino_Visible',ctrl:'MUDANZADIRECCIONDESTINO',prop:'Visible'},{av:'edtMudanzaPisoDptoDestino_Visible',ctrl:'MUDANZAPISODPTODESTINO',prop:'Visible'},{av:'edtMudanzaDistancia_Visible',ctrl:'MUDANZADISTANCIA',prop:'Visible'},{av:'cmbMudanzaVehiculoSugerido'},{av:'edtMudanzaPrecioBasexHora_Visible',ctrl:'MUDANZAPRECIOBASEXHORA',prop:'Visible'},{av:'edtMudanzaPeajeCantidad_Visible',ctrl:'MUDANZAPEAJECANTIDAD',prop:'Visible'},{av:'edtMudanzaPeajevalor_Visible',ctrl:'MUDANZAPEAJEVALOR',prop:'Visible'},{av:'edtTipoInmuebleOrigenId_Visible',ctrl:'TIPOINMUEBLEORIGENID',prop:'Visible'},{av:'edtTipoInmuebleOrigenNombre_Visible',ctrl:'TIPOINMUEBLEORIGENNOMBRE',prop:'Visible'},{av:'edtTipoInmuebleOrigenValor_Visible',ctrl:'TIPOINMUEBLEORIGENVALOR',prop:'Visible'},{av:'AV98GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV99GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV100GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15E52',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_TIPOINMUEBLEORIGENID","{handler:'Valid_Tipoinmuebleorigenid',iparms:[]");
         setEventMetadata("VALID_TIPOINMUEBLEORIGENID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tipoinmuebleorigenvalor',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20MudanzaAsesor1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24MudanzaAsesor2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28MudanzaAsesor3 = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV135Pgmname = "";
         AV43TFMudanzaAsesor = "";
         AV44TFMudanzaAsesor_Sel = "";
         AV45TFMudanzaFechaAlta = DateTime.MinValue;
         AV46TFMudanzaFechaAlta_To = DateTime.MinValue;
         AV50TFMudanzaFechaServicio = DateTime.MinValue;
         AV51TFMudanzaFechaServicio_To = DateTime.MinValue;
         AV117TFMudanzaHoraServicio_Sels = new GxSimpleCollection<string>();
         AV119TFMudanzaRgoHoraservicio_Sels = new GxSimpleCollection<string>();
         AV60TFMudanzaDireccionOrigen = "";
         AV61TFMudanzaDireccionOrigen_Sel = "";
         AV121TFMudanzaPisoDptoOrigen_Sels = new GxSimpleCollection<string>();
         AV62TFMudanzaDireccionDestino = "";
         AV63TFMudanzaDireccionDestino_Sel = "";
         AV122TFMudanzaPisoDptoDestino = "";
         AV123TFMudanzaPisoDptoDestino_Sel = "";
         AV109TFMudanzaVehiculoSugerido_Sels = new GxSimpleCollection<string>();
         AV124TFTipoInmuebleOrigenNombre = "";
         AV125TFTipoInmuebleOrigenNombre_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV100GridAppliedFilters = "";
         AV105AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV96DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV48DDO_MudanzaFechaAltaAuxDateTo = DateTime.MinValue;
         AV53DDO_MudanzaFechaServicioAuxDateTo = DateTime.MinValue;
         AV116TFMudanzaHoraServicio_SelsJson = "";
         AV118TFMudanzaRgoHoraservicio_SelsJson = "";
         AV120TFMudanzaPisoDptoOrigen_SelsJson = "";
         AV108TFMudanzaVehiculoSugerido_SelsJson = "";
         AV47DDO_MudanzaFechaAltaAuxDate = DateTime.MinValue;
         AV52DDO_MudanzaFechaServicioAuxDate = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV49DDO_MudanzaFechaAltaAuxDateText = "";
         ucTfmudanzafechaalta_rangepicker = new GXUserControl();
         AV54DDO_MudanzaFechaServicioAuxDateText = "";
         ucTfmudanzafechaservicio_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A736MudanzaAsesor = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         A739MudanzaHoraServicio = "";
         A776MudanzaRgoHoraservicio = "";
         A740MudanzaDireccionOrigen = "";
         A777MudanzaPisoDptoOrigen = "";
         A741MudanzaDireccionDestino = "";
         A778MudanzaPisoDptoDestino = "";
         A742MudanzaVehiculoSugerido = "";
         A755TipoInmuebleOrigenNombre = "";
         AV156Mudanzawwds_21_tfmudanzahoraservicio_sels = new GxSimpleCollection<string>();
         AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels = new GxSimpleCollection<string>();
         AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels = new GxSimpleCollection<string>();
         AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels = new GxSimpleCollection<string>();
         lV136Mudanzawwds_1_filterfulltext = "";
         lV139Mudanzawwds_4_mudanzaasesor1 = "";
         lV143Mudanzawwds_8_mudanzaasesor2 = "";
         lV147Mudanzawwds_12_mudanzaasesor3 = "";
         lV150Mudanzawwds_15_tfmudanzaasesor = "";
         lV158Mudanzawwds_23_tfmudanzadireccionorigen = "";
         lV161Mudanzawwds_26_tfmudanzadirecciondestino = "";
         lV163Mudanzawwds_28_tfmudanzapisodptodestino = "";
         lV176Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         AV136Mudanzawwds_1_filterfulltext = "";
         AV137Mudanzawwds_2_dynamicfiltersselector1 = "";
         AV139Mudanzawwds_4_mudanzaasesor1 = "";
         AV141Mudanzawwds_6_dynamicfiltersselector2 = "";
         AV143Mudanzawwds_8_mudanzaasesor2 = "";
         AV145Mudanzawwds_10_dynamicfiltersselector3 = "";
         AV147Mudanzawwds_12_mudanzaasesor3 = "";
         AV151Mudanzawwds_16_tfmudanzaasesor_sel = "";
         AV150Mudanzawwds_15_tfmudanzaasesor = "";
         AV152Mudanzawwds_17_tfmudanzafechaalta = DateTime.MinValue;
         AV153Mudanzawwds_18_tfmudanzafechaalta_to = DateTime.MinValue;
         AV154Mudanzawwds_19_tfmudanzafechaservicio = DateTime.MinValue;
         AV155Mudanzawwds_20_tfmudanzafechaservicio_to = DateTime.MinValue;
         AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel = "";
         AV158Mudanzawwds_23_tfmudanzadireccionorigen = "";
         AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel = "";
         AV161Mudanzawwds_26_tfmudanzadirecciondestino = "";
         AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel = "";
         AV163Mudanzawwds_28_tfmudanzapisodptodestino = "";
         AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel = "";
         AV176Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         H00E52_A756TipoInmuebleOrigenValor = new decimal[1] ;
         H00E52_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         H00E52_A743TipoInmuebleOrigenId = new short[1] ;
         H00E52_A760MudanzaPeajevalor = new decimal[1] ;
         H00E52_A761MudanzaPeajeCantidad = new short[1] ;
         H00E52_A780MudanzaPrecioBasexHora = new decimal[1] ;
         H00E52_A742MudanzaVehiculoSugerido = new string[] {""} ;
         H00E52_A762MudanzaDistancia = new decimal[1] ;
         H00E52_A778MudanzaPisoDptoDestino = new string[] {""} ;
         H00E52_A741MudanzaDireccionDestino = new string[] {""} ;
         H00E52_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         H00E52_A740MudanzaDireccionOrigen = new string[] {""} ;
         H00E52_A776MudanzaRgoHoraservicio = new string[] {""} ;
         H00E52_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         H00E52_A739MudanzaHoraServicio = new string[] {""} ;
         H00E52_n739MudanzaHoraServicio = new bool[] {false} ;
         H00E52_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         H00E52_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00E52_A736MudanzaAsesor = new string[] {""} ;
         H00E52_A735MudanzaId = new long[1] ;
         H00E53_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV106AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char6 = "";
         GXt_char7 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanzaww__default(),
            new Object[][] {
                new Object[] {
               H00E52_A756TipoInmuebleOrigenValor, H00E52_A755TipoInmuebleOrigenNombre, H00E52_A743TipoInmuebleOrigenId, H00E52_A760MudanzaPeajevalor, H00E52_A761MudanzaPeajeCantidad, H00E52_A780MudanzaPrecioBasexHora, H00E52_A742MudanzaVehiculoSugerido, H00E52_A762MudanzaDistancia, H00E52_A778MudanzaPisoDptoDestino, H00E52_A741MudanzaDireccionDestino,
               H00E52_A777MudanzaPisoDptoOrigen, H00E52_A740MudanzaDireccionOrigen, H00E52_A776MudanzaRgoHoraservicio, H00E52_n776MudanzaRgoHoraservicio, H00E52_A739MudanzaHoraServicio, H00E52_n739MudanzaHoraServicio, H00E52_A738MudanzaFechaServicio, H00E52_A737MudanzaFechaAlta, H00E52_A736MudanzaAsesor, H00E52_A735MudanzaId
               }
               , new Object[] {
               H00E53_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV135Pgmname = "MudanzaWW";
         /* GeneXus formulas. */
         AV135Pgmname = "MudanzaWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV68TFMudanzaPeajeCantidad ;
      private short AV69TFMudanzaPeajeCantidad_To ;
      private short AV72TFTipoInmuebleOrigenId ;
      private short AV73TFTipoInmuebleOrigenId_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV101GridActions ;
      private short A761MudanzaPeajeCantidad ;
      private short A743TipoInmuebleOrigenId ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV138Mudanzawwds_3_dynamicfiltersoperator1 ;
      private short AV142Mudanzawwds_7_dynamicfiltersoperator2 ;
      private short AV146Mudanzawwds_11_dynamicfiltersoperator3 ;
      private short AV170Mudanzawwds_35_tfmudanzapeajecantidad ;
      private short AV171Mudanzawwds_36_tfmudanzapeajecantidad_to ;
      private short AV174Mudanzawwds_39_tftipoinmuebleorigenid ;
      private short AV175Mudanzawwds_40_tftipoinmuebleorigenid_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_111 ;
      private int nGXsfl_111_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV156Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ;
      private int AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ;
      private int AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ;
      private int AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ;
      private int edtMudanzaId_Enabled ;
      private int edtMudanzaAsesor_Enabled ;
      private int edtMudanzaFechaAlta_Enabled ;
      private int edtMudanzaFechaServicio_Enabled ;
      private int edtMudanzaDireccionOrigen_Enabled ;
      private int edtMudanzaDireccionDestino_Enabled ;
      private int edtMudanzaPisoDptoDestino_Enabled ;
      private int edtMudanzaDistancia_Enabled ;
      private int edtMudanzaPrecioBasexHora_Enabled ;
      private int edtMudanzaPeajeCantidad_Enabled ;
      private int edtMudanzaPeajevalor_Enabled ;
      private int edtTipoInmuebleOrigenId_Enabled ;
      private int edtTipoInmuebleOrigenNombre_Enabled ;
      private int edtTipoInmuebleOrigenValor_Enabled ;
      private int edtMudanzaId_Visible ;
      private int edtMudanzaAsesor_Visible ;
      private int edtMudanzaFechaAlta_Visible ;
      private int edtMudanzaFechaServicio_Visible ;
      private int edtMudanzaDireccionOrigen_Visible ;
      private int edtMudanzaDireccionDestino_Visible ;
      private int edtMudanzaPisoDptoDestino_Visible ;
      private int edtMudanzaDistancia_Visible ;
      private int edtMudanzaPrecioBasexHora_Visible ;
      private int edtMudanzaPeajeCantidad_Visible ;
      private int edtMudanzaPeajevalor_Visible ;
      private int edtTipoInmuebleOrigenId_Visible ;
      private int edtTipoInmuebleOrigenNombre_Visible ;
      private int edtTipoInmuebleOrigenValor_Visible ;
      private int AV97PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavMudanzaasesor1_Visible ;
      private int edtavMudanzaasesor2_Visible ;
      private int edtavMudanzaasesor3_Visible ;
      private int AV180GXV1 ;
      private int edtavMudanzaasesor3_Enabled ;
      private int edtavMudanzaasesor2_Enabled ;
      private int edtavMudanzaasesor1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41TFMudanzaId ;
      private long AV42TFMudanzaId_To ;
      private long AV132ProveedorId ;
      private long AV134SecUserId ;
      private long AV98GridCurrentPage ;
      private long AV99GridPageCount ;
      private long A735MudanzaId ;
      private long GRID_nCurrentRecord ;
      private long AV148Mudanzawwds_13_tfmudanzaid ;
      private long AV149Mudanzawwds_14_tfmudanzaid_to ;
      private long GRID_nRecordCount ;
      private decimal AV64TFMudanzaDistancia ;
      private decimal AV65TFMudanzaDistancia_To ;
      private decimal AV130TFMudanzaPrecioBasexHora ;
      private decimal AV131TFMudanzaPrecioBasexHora_To ;
      private decimal AV70TFMudanzaPeajevalor ;
      private decimal AV71TFMudanzaPeajevalor_To ;
      private decimal AV76TFTipoInmuebleOrigenValor ;
      private decimal AV77TFTipoInmuebleOrigenValor_To ;
      private decimal A762MudanzaDistancia ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal A760MudanzaPeajevalor ;
      private decimal A756TipoInmuebleOrigenValor ;
      private decimal AV165Mudanzawwds_30_tfmudanzadistancia ;
      private decimal AV166Mudanzawwds_31_tfmudanzadistancia_to ;
      private decimal AV168Mudanzawwds_33_tfmudanzapreciobasexhora ;
      private decimal AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to ;
      private decimal AV172Mudanzawwds_37_tfmudanzapeajevalor ;
      private decimal AV173Mudanzawwds_38_tfmudanzapeajevalor_to ;
      private decimal AV178Mudanzawwds_43_tftipoinmuebleorigenvalor ;
      private decimal AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_111_idx="0001" ;
      private string AV135Pgmname ;
      private string AV122TFMudanzaPisoDptoDestino ;
      private string AV123TFMudanzaPisoDptoDestino_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_mudanzafechaaltaauxdates_Internalname ;
      private string edtavDdo_mudanzafechaaltaauxdatetext_Internalname ;
      private string edtavDdo_mudanzafechaaltaauxdatetext_Jsonclick ;
      private string Tfmudanzafechaalta_rangepicker_Internalname ;
      private string divDdo_mudanzafechaservicioauxdates_Internalname ;
      private string edtavDdo_mudanzafechaservicioauxdatetext_Internalname ;
      private string edtavDdo_mudanzafechaservicioauxdatetext_Jsonclick ;
      private string Tfmudanzafechaservicio_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtMudanzaId_Internalname ;
      private string edtMudanzaAsesor_Internalname ;
      private string edtMudanzaFechaAlta_Internalname ;
      private string edtMudanzaFechaServicio_Internalname ;
      private string cmbMudanzaHoraServicio_Internalname ;
      private string A739MudanzaHoraServicio ;
      private string cmbMudanzaRgoHoraservicio_Internalname ;
      private string A776MudanzaRgoHoraservicio ;
      private string edtMudanzaDireccionOrigen_Internalname ;
      private string cmbMudanzaPisoDptoOrigen_Internalname ;
      private string A777MudanzaPisoDptoOrigen ;
      private string edtMudanzaDireccionDestino_Internalname ;
      private string A778MudanzaPisoDptoDestino ;
      private string edtMudanzaPisoDptoDestino_Internalname ;
      private string edtMudanzaDistancia_Internalname ;
      private string cmbMudanzaVehiculoSugerido_Internalname ;
      private string edtMudanzaPrecioBasexHora_Internalname ;
      private string edtMudanzaPeajeCantidad_Internalname ;
      private string edtMudanzaPeajevalor_Internalname ;
      private string edtTipoInmuebleOrigenId_Internalname ;
      private string edtTipoInmuebleOrigenNombre_Internalname ;
      private string edtTipoInmuebleOrigenValor_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string lV163Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel ;
      private string AV163Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string edtavMudanzaasesor1_Internalname ;
      private string edtavMudanzaasesor2_Internalname ;
      private string edtavMudanzaasesor3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string edtMudanzaAsesor_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char6 ;
      private string GXt_char7 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_mudanzaasesor3_cell_Internalname ;
      private string edtavMudanzaasesor3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_mudanzaasesor2_cell_Internalname ;
      private string edtavMudanzaasesor2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_mudanzaasesor1_cell_Internalname ;
      private string edtavMudanzaasesor1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_111_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtMudanzaId_Jsonclick ;
      private string edtMudanzaAsesor_Jsonclick ;
      private string edtMudanzaFechaAlta_Jsonclick ;
      private string edtMudanzaFechaServicio_Jsonclick ;
      private string cmbMudanzaHoraServicio_Jsonclick ;
      private string cmbMudanzaRgoHoraservicio_Jsonclick ;
      private string edtMudanzaDireccionOrigen_Jsonclick ;
      private string cmbMudanzaPisoDptoOrigen_Jsonclick ;
      private string edtMudanzaDireccionDestino_Jsonclick ;
      private string edtMudanzaPisoDptoDestino_Jsonclick ;
      private string edtMudanzaDistancia_Jsonclick ;
      private string cmbMudanzaVehiculoSugerido_Jsonclick ;
      private string edtMudanzaPrecioBasexHora_Jsonclick ;
      private string edtMudanzaPeajeCantidad_Jsonclick ;
      private string edtMudanzaPeajevalor_Jsonclick ;
      private string edtTipoInmuebleOrigenId_Jsonclick ;
      private string edtTipoInmuebleOrigenNombre_Jsonclick ;
      private string edtTipoInmuebleOrigenValor_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV45TFMudanzaFechaAlta ;
      private DateTime AV46TFMudanzaFechaAlta_To ;
      private DateTime AV50TFMudanzaFechaServicio ;
      private DateTime AV51TFMudanzaFechaServicio_To ;
      private DateTime AV48DDO_MudanzaFechaAltaAuxDateTo ;
      private DateTime AV53DDO_MudanzaFechaServicioAuxDateTo ;
      private DateTime AV47DDO_MudanzaFechaAltaAuxDate ;
      private DateTime AV52DDO_MudanzaFechaServicioAuxDate ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime A738MudanzaFechaServicio ;
      private DateTime AV152Mudanzawwds_17_tfmudanzafechaalta ;
      private DateTime AV153Mudanzawwds_18_tfmudanzafechaalta_to ;
      private DateTime AV154Mudanzawwds_19_tfmudanzafechaservicio ;
      private DateTime AV155Mudanzawwds_20_tfmudanzafechaservicio_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
      private bool AV103IsAuthorized_Update ;
      private bool AV104IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_111_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n739MudanzaHoraServicio ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV140Mudanzawwds_5_dynamicfiltersenabled2 ;
      private bool AV144Mudanzawwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV107TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV116TFMudanzaHoraServicio_SelsJson ;
      private string AV118TFMudanzaRgoHoraservicio_SelsJson ;
      private string AV120TFMudanzaPisoDptoOrigen_SelsJson ;
      private string AV108TFMudanzaVehiculoSugerido_SelsJson ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20MudanzaAsesor1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24MudanzaAsesor2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28MudanzaAsesor3 ;
      private string AV43TFMudanzaAsesor ;
      private string AV44TFMudanzaAsesor_Sel ;
      private string AV60TFMudanzaDireccionOrigen ;
      private string AV61TFMudanzaDireccionOrigen_Sel ;
      private string AV62TFMudanzaDireccionDestino ;
      private string AV63TFMudanzaDireccionDestino_Sel ;
      private string AV124TFTipoInmuebleOrigenNombre ;
      private string AV125TFTipoInmuebleOrigenNombre_Sel ;
      private string AV100GridAppliedFilters ;
      private string AV49DDO_MudanzaFechaAltaAuxDateText ;
      private string AV54DDO_MudanzaFechaServicioAuxDateText ;
      private string A736MudanzaAsesor ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A742MudanzaVehiculoSugerido ;
      private string A755TipoInmuebleOrigenNombre ;
      private string lV136Mudanzawwds_1_filterfulltext ;
      private string lV139Mudanzawwds_4_mudanzaasesor1 ;
      private string lV143Mudanzawwds_8_mudanzaasesor2 ;
      private string lV147Mudanzawwds_12_mudanzaasesor3 ;
      private string lV150Mudanzawwds_15_tfmudanzaasesor ;
      private string lV158Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string lV161Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string lV176Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string AV136Mudanzawwds_1_filterfulltext ;
      private string AV137Mudanzawwds_2_dynamicfiltersselector1 ;
      private string AV139Mudanzawwds_4_mudanzaasesor1 ;
      private string AV141Mudanzawwds_6_dynamicfiltersselector2 ;
      private string AV143Mudanzawwds_8_mudanzaasesor2 ;
      private string AV145Mudanzawwds_10_dynamicfiltersselector3 ;
      private string AV147Mudanzawwds_12_mudanzaasesor3 ;
      private string AV151Mudanzawwds_16_tfmudanzaasesor_sel ;
      private string AV150Mudanzawwds_15_tfmudanzaasesor ;
      private string AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel ;
      private string AV158Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel ;
      private string AV161Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel ;
      private string AV176Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfmudanzafechaalta_rangepicker ;
      private GXUserControl ucTfmudanzafechaservicio_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbMudanzaHoraServicio ;
      private GXCombobox cmbMudanzaRgoHoraservicio ;
      private GXCombobox cmbMudanzaPisoDptoOrigen ;
      private GXCombobox cmbMudanzaVehiculoSugerido ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GxSimpleCollection<string> AV117TFMudanzaHoraServicio_Sels ;
      private GxSimpleCollection<string> AV119TFMudanzaRgoHoraservicio_Sels ;
      private GxSimpleCollection<string> AV121TFMudanzaPisoDptoOrigen_Sels ;
      private GxSimpleCollection<string> AV109TFMudanzaVehiculoSugerido_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV105AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV96DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV156Mudanzawwds_21_tfmudanzahoraservicio_sels ;
      private GxSimpleCollection<string> AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels ;
      private GxSimpleCollection<string> AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels ;
      private GxSimpleCollection<string> AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00E52_A756TipoInmuebleOrigenValor ;
      private string[] H00E52_A755TipoInmuebleOrigenNombre ;
      private short[] H00E52_A743TipoInmuebleOrigenId ;
      private decimal[] H00E52_A760MudanzaPeajevalor ;
      private short[] H00E52_A761MudanzaPeajeCantidad ;
      private decimal[] H00E52_A780MudanzaPrecioBasexHora ;
      private string[] H00E52_A742MudanzaVehiculoSugerido ;
      private decimal[] H00E52_A762MudanzaDistancia ;
      private string[] H00E52_A778MudanzaPisoDptoDestino ;
      private string[] H00E52_A741MudanzaDireccionDestino ;
      private string[] H00E52_A777MudanzaPisoDptoOrigen ;
      private string[] H00E52_A740MudanzaDireccionOrigen ;
      private string[] H00E52_A776MudanzaRgoHoraservicio ;
      private bool[] H00E52_n776MudanzaRgoHoraservicio ;
      private string[] H00E52_A739MudanzaHoraServicio ;
      private bool[] H00E52_n739MudanzaHoraServicio ;
      private DateTime[] H00E52_A738MudanzaFechaServicio ;
      private DateTime[] H00E52_A737MudanzaFechaAlta ;
      private string[] H00E52_A736MudanzaAsesor ;
      private long[] H00E52_A735MudanzaId ;
      private long[] H00E53_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV106AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class mudanzaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00E52( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV156Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV136Mudanzawwds_1_filterfulltext ,
                                             string AV137Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV138Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV139Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV140Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV141Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV142Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV143Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV144Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV145Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV146Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV147Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV148Mudanzawwds_13_tfmudanzaid ,
                                             long AV149Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV151Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV150Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV152Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV153Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV154Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV155Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV156Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV158Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV161Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV163Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV165Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV166Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV168Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV170Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV171Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV172Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV173Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV174Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV175Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV176Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV178Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[66];
         Object[] GXv_Object14 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId]";
         sFromString = " FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
            GXv_int13[9] = 1;
            GXv_int13[10] = 1;
            GXv_int13[11] = 1;
            GXv_int13[12] = 1;
            GXv_int13[13] = 1;
            GXv_int13[14] = 1;
            GXv_int13[15] = 1;
            GXv_int13[16] = 1;
            GXv_int13[17] = 1;
            GXv_int13[18] = 1;
            GXv_int13[19] = 1;
            GXv_int13[20] = 1;
            GXv_int13[21] = 1;
            GXv_int13[22] = 1;
            GXv_int13[23] = 1;
            GXv_int13[24] = 1;
            GXv_int13[25] = 1;
            GXv_int13[26] = 1;
            GXv_int13[27] = 1;
            GXv_int13[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV137Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV138Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV139Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV137Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV138Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV139Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int13[30] = 1;
         }
         if ( AV140Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV141Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV142Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV143Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int13[31] = 1;
         }
         if ( AV140Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV141Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV142Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV143Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int13[32] = 1;
         }
         if ( AV144Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV145Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV146Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV147Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int13[33] = 1;
         }
         if ( AV144Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV145Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV146Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV147Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int13[34] = 1;
         }
         if ( ! (0==AV148Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV148Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int13[35] = 1;
         }
         if ( ! (0==AV149Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV149Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int13[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV151Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV150Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int13[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV151Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV151Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int13[38] = 1;
         }
         if ( StringUtil.StrCmp(AV151Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV152Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV152Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int13[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV153Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV153Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int13[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV154Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV154Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int13[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV155Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV155Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int13[42] = 1;
         }
         if ( AV156Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV156Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV158Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int13[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int13[44] = 1;
         }
         if ( StringUtil.StrCmp(AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV161Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int13[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int13[46] = 1;
         }
         if ( StringUtil.StrCmp(AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV163Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int13[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int13[48] = 1;
         }
         if ( StringUtil.StrCmp(AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV165Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV165Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int13[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV166Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV166Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int13[50] = 1;
         }
         if ( AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV168Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV168Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int13[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int13[52] = 1;
         }
         if ( ! (0==AV170Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV170Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int13[53] = 1;
         }
         if ( ! (0==AV171Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV171Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int13[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV172Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV172Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int13[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV173Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV173Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int13[56] = 1;
         }
         if ( ! (0==AV174Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV174Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int13[57] = 1;
         }
         if ( ! (0==AV175Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV175Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int13[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV176Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int13[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int13[60] = 1;
         }
         if ( StringUtil.StrCmp(AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV178Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV178Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int13[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int13[62] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaAsesor]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaAsesor] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaServicio]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaFechaServicio] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaHoraServicio]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaHoraServicio] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaRgoHoraservicio]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaRgoHoraservicio] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionOrigen]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionOrigen] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoOrigen]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoOrigen] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionDestino]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaDireccionDestino] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoDestino]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPisoDptoDestino] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaDistancia]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaDistancia] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaVehiculoSugerido]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaVehiculoSugerido] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPrecioBasexHora]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPrecioBasexHora] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajeCantidad]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajeCantidad] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajevalor]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MudanzaPeajevalor] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipoInmuebleOrigenId]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipoInmuebleOrigenId] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaNombre]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaValor]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ParametroMudanzaValor] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[MudanzaId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H00E53( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV156Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV136Mudanzawwds_1_filterfulltext ,
                                             string AV137Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV138Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV139Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV140Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV141Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV142Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV143Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV144Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV145Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV146Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV147Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV148Mudanzawwds_13_tfmudanzaid ,
                                             long AV149Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV151Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV150Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV152Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV153Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV154Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV155Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV156Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV158Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV161Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV163Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV165Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV166Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV168Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV170Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV171Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV172Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV173Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV174Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV175Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV176Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV178Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[63];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV136Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV136Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV136Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV136Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int15[0] = 1;
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
            GXv_int15[6] = 1;
            GXv_int15[7] = 1;
            GXv_int15[8] = 1;
            GXv_int15[9] = 1;
            GXv_int15[10] = 1;
            GXv_int15[11] = 1;
            GXv_int15[12] = 1;
            GXv_int15[13] = 1;
            GXv_int15[14] = 1;
            GXv_int15[15] = 1;
            GXv_int15[16] = 1;
            GXv_int15[17] = 1;
            GXv_int15[18] = 1;
            GXv_int15[19] = 1;
            GXv_int15[20] = 1;
            GXv_int15[21] = 1;
            GXv_int15[22] = 1;
            GXv_int15[23] = 1;
            GXv_int15[24] = 1;
            GXv_int15[25] = 1;
            GXv_int15[26] = 1;
            GXv_int15[27] = 1;
            GXv_int15[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV137Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV138Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV139Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int15[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV137Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV138Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV139Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int15[30] = 1;
         }
         if ( AV140Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV141Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV142Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV143Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int15[31] = 1;
         }
         if ( AV140Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV141Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV142Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV143Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int15[32] = 1;
         }
         if ( AV144Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV145Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV146Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV147Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int15[33] = 1;
         }
         if ( AV144Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV145Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV146Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV147Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int15[34] = 1;
         }
         if ( ! (0==AV148Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV148Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int15[35] = 1;
         }
         if ( ! (0==AV149Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV149Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int15[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV151Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV150Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int15[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV151Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV151Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int15[38] = 1;
         }
         if ( StringUtil.StrCmp(AV151Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV152Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV152Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int15[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV153Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV153Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int15[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV154Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV154Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int15[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV155Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV155Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int15[42] = 1;
         }
         if ( AV156Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV156Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV157Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV158Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int15[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int15[44] = 1;
         }
         if ( StringUtil.StrCmp(AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV160Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV161Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int15[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int15[46] = 1;
         }
         if ( StringUtil.StrCmp(AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV163Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int15[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int15[48] = 1;
         }
         if ( StringUtil.StrCmp(AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV165Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV165Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int15[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV166Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV166Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int15[50] = 1;
         }
         if ( AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV167Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV168Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV168Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int15[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int15[52] = 1;
         }
         if ( ! (0==AV170Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV170Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int15[53] = 1;
         }
         if ( ! (0==AV171Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV171Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int15[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV172Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV172Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int15[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV173Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV173Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int15[56] = 1;
         }
         if ( ! (0==AV174Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV174Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int15[57] = 1;
         }
         if ( ! (0==AV175Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV175Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int15[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV176Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int15[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int15[60] = 1;
         }
         if ( StringUtil.StrCmp(AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV178Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV178Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int15[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int15[62] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00E52(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
               case 1 :
                     return conditional_H00E53(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00E52;
          prmH00E52 = new Object[] {
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV139Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV139Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV143Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV143Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV147Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV147Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV148Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV149Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV150Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV151Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV152Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV153Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV154Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV155Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV158Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV161Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV163Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV165Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV166Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV168Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV170Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV171Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV172Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV173Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV174Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV175Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV176Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV178Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00E53;
          prmH00E53 = new Object[] {
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV136Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV139Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV139Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV143Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV143Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV147Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV147Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV148Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV149Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV150Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV151Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV152Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV153Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV154Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV155Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV158Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV159Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV161Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV162Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV163Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV164Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV165Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV166Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV168Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV169Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV170Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV171Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV172Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV173Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV174Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV175Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV176Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV177Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV178Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV179Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00E52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E52,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00E53", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E53,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 30);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 5);
                ((bool[]) buf[13])[0] = rslt.wasNull(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 2);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((string[]) buf[18])[0] = rslt.getVarchar(17);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

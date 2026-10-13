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
   public class postulacionesww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public postulacionesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulacionesww( IGxContext context )
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
         chkPostulacionesReqSuministros = new GXCheckbox();
         cmbPostulacionesEstado = new GXCombobox();
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
         nRC_GXsfl_129 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_129"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_129_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_129_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_129_idx = GetPar( "sGXsfl_129_idx");
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
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV108PostulacionesProveedorNombre1 = GetPar( "PostulacionesProveedorNombre1");
         AV20PostulacionesProveedorId1 = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesProveedorId1"), "."), 18, MidpointRounding.ToEven));
         AV21ServiciosNombre1 = GetPar( "ServiciosNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV109PostulacionesProveedorNombre2 = GetPar( "PostulacionesProveedorNombre2");
         AV25PostulacionesProveedorId2 = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesProveedorId2"), "."), 18, MidpointRounding.ToEven));
         AV26ServiciosNombre2 = GetPar( "ServiciosNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV110PostulacionesProveedorNombre3 = GetPar( "PostulacionesProveedorNombre3");
         AV30PostulacionesProveedorId3 = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesProveedorId3"), "."), 18, MidpointRounding.ToEven));
         AV31ServiciosNombre3 = GetPar( "ServiciosNombre3");
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV123Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV44TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesId"), "."), 18, MidpointRounding.ToEven));
         AV45TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesId_To"), "."), 18, MidpointRounding.ToEven));
         AV46TFServiciosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFServiciosId"), "."), 18, MidpointRounding.ToEven));
         AV47TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFServiciosId_To"), "."), 18, MidpointRounding.ToEven));
         AV48TFServiciosNombre = GetPar( "TFServiciosNombre");
         AV49TFServiciosNombre_Sel = GetPar( "TFServiciosNombre_Sel");
         AV50TFPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesProveedorId"), "."), 18, MidpointRounding.ToEven));
         AV51TFPostulacionesProveedorId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesProveedorId_To"), "."), 18, MidpointRounding.ToEven));
         AV103TFPostulacionesProveedorNombre = GetPar( "TFPostulacionesProveedorNombre");
         AV104TFPostulacionesProveedorNombre_Sel = GetPar( "TFPostulacionesProveedorNombre_Sel");
         AV52TFPostulacionesPrecio = NumberUtil.Val( GetPar( "TFPostulacionesPrecio"), ".");
         AV53TFPostulacionesPrecio_To = NumberUtil.Val( GetPar( "TFPostulacionesPrecio_To"), ".");
         AV105TFPostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesMultimediaSerial"), "."), 18, MidpointRounding.ToEven));
         AV106TFPostulacionesMultimediaSerial_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesMultimediaSerial_To"), "."), 18, MidpointRounding.ToEven));
         AV111TFPostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesSolicitudesId"), "."), 18, MidpointRounding.ToEven));
         AV112TFPostulacionesSolicitudesId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesSolicitudesId_To"), "."), 18, MidpointRounding.ToEven));
         AV54TFPostulacionesDescripcion = GetPar( "TFPostulacionesDescripcion");
         AV55TFPostulacionesDescripcion_Sel = GetPar( "TFPostulacionesDescripcion_Sel");
         AV56TFPostulacionesReqSuministros_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesReqSuministros_Sel"), "."), 18, MidpointRounding.ToEven));
         AV57TFPostulacionesSuministrosDescripcion = GetPar( "TFPostulacionesSuministrosDescripcion");
         AV58TFPostulacionesSuministrosDescripcion_Sel = GetPar( "TFPostulacionesSuministrosDescripcion_Sel");
         AV59TFPostulacionesFechaTrabajo = context.localUtil.ParseDateParm( GetPar( "TFPostulacionesFechaTrabajo"));
         AV60TFPostulacionesFechaTrabajo_To = context.localUtil.ParseDateParm( GetPar( "TFPostulacionesFechaTrabajo_To"));
         AV64TFPostulacionesFechaCierre = context.localUtil.ParseDateParm( GetPar( "TFPostulacionesFechaCierre"));
         AV65TFPostulacionesFechaCierre_To = context.localUtil.ParseDateParm( GetPar( "TFPostulacionesFechaCierre_To"));
         AV69TFPostulacionesHoraCierre = GetPar( "TFPostulacionesHoraCierre");
         AV70TFPostulacionesHoraCierre_Sel = GetPar( "TFPostulacionesHoraCierre_Sel");
         AV71TFPostulacionesTipoFecha = GetPar( "TFPostulacionesTipoFecha");
         AV122TFPostulacionesTipoFecha_Sel = GetPar( "TFPostulacionesTipoFecha_Sel");
         AV73TFPostulacionesRgoHoraservicio = GetPar( "TFPostulacionesRgoHoraservicio");
         AV74TFPostulacionesRgoHoraservicio_Sel = GetPar( "TFPostulacionesRgoHoraservicio_Sel");
         AV75TFPostulacionesApellidoNombre = GetPar( "TFPostulacionesApellidoNombre");
         AV76TFPostulacionesApellidoNombre_Sel = GetPar( "TFPostulacionesApellidoNombre_Sel");
         AV77TFPostulacionesMail = GetPar( "TFPostulacionesMail");
         AV78TFPostulacionesMail_Sel = GetPar( "TFPostulacionesMail_Sel");
         AV79TFPostulacionesTelefono = GetPar( "TFPostulacionesTelefono");
         AV80TFPostulacionesTelefono_Sel = GetPar( "TFPostulacionesTelefono_Sel");
         AV81TFPostulacionesFechaAlta = context.localUtil.ParseDTimeParm( GetPar( "TFPostulacionesFechaAlta"));
         AV82TFPostulacionesFechaAlta_To = context.localUtil.ParseDTimeParm( GetPar( "TFPostulacionesFechaAlta_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV87TFPostulacionesEstado_Sels);
         AV88TFPostulacionesSecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesSecUserId"), "."), 18, MidpointRounding.ToEven));
         AV89TFPostulacionesSecUserId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionesSecUserId_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV97IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV98IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV99IsAuthorized_ServiciosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ServiciosNombre"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
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
         PAKI2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTKI2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("postulacionesww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV123Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV123Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV97IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV97IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV98IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV98IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SERVICIOSNOMBRE", AV99IsAuthorized_ServiciosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SERVICIOSNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_ServiciosNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPOSTULACIONESPROVEEDORNOMBRE1", StringUtil.RTrim( AV108PostulacionesProveedorNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vPOSTULACIONESPROVEEDORID1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20PostulacionesProveedorId1), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSERVICIOSNOMBRE1", StringUtil.RTrim( AV21ServiciosNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPOSTULACIONESPROVEEDORNOMBRE2", StringUtil.RTrim( AV109PostulacionesProveedorNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vPOSTULACIONESPROVEEDORID2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25PostulacionesProveedorId2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSERVICIOSNOMBRE2", StringUtil.RTrim( AV26ServiciosNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPOSTULACIONESPROVEEDORNOMBRE3", StringUtil.RTrim( AV110PostulacionesProveedorNombre3));
         GxWebStd.gx_hidden_field( context, "GXH_vPOSTULACIONESPROVEEDORID3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30PostulacionesProveedorId3), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSERVICIOSNOMBRE3", StringUtil.RTrim( AV31ServiciosNombre3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_129", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV92GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV93GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV94GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV100AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV100AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV90DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV90DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_POSTULACIONESFECHATRABAJOAUXDATETO", context.localUtil.DToC( AV62DDO_PostulacionesFechaTrabajoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_POSTULACIONESFECHACIERREAUXDATETO", context.localUtil.DToC( AV67DDO_PostulacionesFechaCierreAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_POSTULACIONESFECHAALTAAUXDATETO", context.localUtil.DToC( AV84DDO_PostulacionesFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV123Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV123Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFPostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFPostulacionesId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSERVICIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSERVICIOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFServiciosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSERVICIOSNOMBRE", StringUtil.RTrim( AV48TFServiciosNombre));
         GxWebStd.gx_hidden_field( context, "vTFSERVICIOSNOMBRE_SEL", StringUtil.RTrim( AV49TFServiciosNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFPostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESPROVEEDORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFPostulacionesProveedorId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESPROVEEDORNOMBRE", StringUtil.RTrim( AV103TFPostulacionesProveedorNombre));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESPROVEEDORNOMBRE_SEL", StringUtil.RTrim( AV104TFPostulacionesProveedorNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESPRECIO", StringUtil.LTrim( StringUtil.NToC( AV52TFPostulacionesPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESPRECIO_TO", StringUtil.LTrim( StringUtil.NToC( AV53TFPostulacionesPrecio_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESMULTIMEDIASERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV105TFPostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESMULTIMEDIASERIAL_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV106TFPostulacionesMultimediaSerial_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV111TFPostulacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESSOLICITUDESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV112TFPostulacionesSolicitudesId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESDESCRIPCION", StringUtil.RTrim( AV54TFPostulacionesDescripcion));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESDESCRIPCION_SEL", StringUtil.RTrim( AV55TFPostulacionesDescripcion_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESREQSUMINISTROS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56TFPostulacionesReqSuministros_Sel), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESSUMINISTROSDESCRIPCION", StringUtil.RTrim( AV57TFPostulacionesSuministrosDescripcion));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL", StringUtil.RTrim( AV58TFPostulacionesSuministrosDescripcion_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESFECHATRABAJO", context.localUtil.DToC( AV59TFPostulacionesFechaTrabajo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESFECHATRABAJO_TO", context.localUtil.DToC( AV60TFPostulacionesFechaTrabajo_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESFECHACIERRE", context.localUtil.DToC( AV64TFPostulacionesFechaCierre, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESFECHACIERRE_TO", context.localUtil.DToC( AV65TFPostulacionesFechaCierre_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESHORACIERRE", AV69TFPostulacionesHoraCierre);
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESHORACIERRE_SEL", AV70TFPostulacionesHoraCierre_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESTIPOFECHA", AV71TFPostulacionesTipoFecha);
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESTIPOFECHA_SEL", AV122TFPostulacionesTipoFecha_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESRGOHORASERVICIO", StringUtil.RTrim( AV73TFPostulacionesRgoHoraservicio));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESRGOHORASERVICIO_SEL", StringUtil.RTrim( AV74TFPostulacionesRgoHoraservicio_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESAPELLIDONOMBRE", StringUtil.RTrim( AV75TFPostulacionesApellidoNombre));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESAPELLIDONOMBRE_SEL", StringUtil.RTrim( AV76TFPostulacionesApellidoNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESMAIL", AV77TFPostulacionesMail);
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESMAIL_SEL", AV78TFPostulacionesMail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESTELEFONO", StringUtil.RTrim( AV79TFPostulacionesTelefono));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESTELEFONO_SEL", StringUtil.RTrim( AV80TFPostulacionesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESFECHAALTA", context.localUtil.TToC( AV81TFPostulacionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESFECHAALTA_TO", context.localUtil.TToC( AV82TFPostulacionesFechaAlta_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPOSTULACIONESESTADO_SELS", AV87TFPostulacionesEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPOSTULACIONESESTADO_SELS", AV87TFPostulacionesEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV88TFPostulacionesSecUserId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESSECUSERID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89TFPostulacionesSecUserId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV33DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV32DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV97IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV97IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV98IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV98IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SERVICIOSNOMBRE", AV99IsAuthorized_ServiciosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SERVICIOSNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_ServiciosNombre, context));
         GxWebStd.gx_hidden_field( context, "vTFPOSTULACIONESESTADO_SELSJSON", AV86TFPostulacionesEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vDDO_POSTULACIONESFECHATRABAJOAUXDATE", context.localUtil.DToC( AV61DDO_PostulacionesFechaTrabajoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_POSTULACIONESFECHACIERREAUXDATE", context.localUtil.DToC( AV66DDO_PostulacionesFechaCierreAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_POSTULACIONESFECHAALTAAUXDATE", context.localUtil.DToC( AV83DDO_PostulacionesFechaAltaAuxDate, 0, "/"));
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
            WEKI2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTKI2( ) ;
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
         return formatLink("postulacionesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PostulacionesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Postulaciones", "") ;
      }

      protected void WBKI0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_KI2( true) ;
         }
         else
         {
            wb_table1_25_KI2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_KI2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_PostulacionesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_KI2( true) ;
         }
         else
         {
            wb_table2_49_KI2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_KI2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_PostulacionesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_77_KI2( true) ;
         }
         else
         {
            wb_table3_77_KI2( false) ;
         }
         return  ;
      }

      protected void wb_table3_77_KI2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_PostulacionesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_105_KI2( true) ;
         }
         else
         {
            wb_table4_105_KI2( false) ;
         }
         return  ;
      }

      protected void wb_table4_105_KI2e( bool wbgen )
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
            StartGridControl129( ) ;
         }
         if ( wbEnd == 129 )
         {
            wbEnd = 0;
            nRC_GXsfl_129 = (int)(nGXsfl_129_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV92GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV93GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV94GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV100AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_PostulacionesWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV90DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV90DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0167"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0167"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_129_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0167"+"");
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
            GxWebStd.gx_div_start( context, divDdo_postulacionesfechatrabajoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_postulacionesfechatrabajoauxdatetext_Internalname, AV63DDO_PostulacionesFechaTrabajoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV63DDO_PostulacionesFechaTrabajoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_postulacionesfechatrabajoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            /* User Defined Control */
            ucTfpostulacionesfechatrabajo_rangepicker.SetProperty("Start Date", AV61DDO_PostulacionesFechaTrabajoAuxDate);
            ucTfpostulacionesfechatrabajo_rangepicker.SetProperty("End Date", AV62DDO_PostulacionesFechaTrabajoAuxDateTo);
            ucTfpostulacionesfechatrabajo_rangepicker.Render(context, "wwp.daterangepicker", Tfpostulacionesfechatrabajo_rangepicker_Internalname, "TFPOSTULACIONESFECHATRABAJO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_postulacionesfechacierreauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_postulacionesfechacierreauxdatetext_Internalname, AV68DDO_PostulacionesFechaCierreAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV68DDO_PostulacionesFechaCierreAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_postulacionesfechacierreauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            /* User Defined Control */
            ucTfpostulacionesfechacierre_rangepicker.SetProperty("Start Date", AV66DDO_PostulacionesFechaCierreAuxDate);
            ucTfpostulacionesfechacierre_rangepicker.SetProperty("End Date", AV67DDO_PostulacionesFechaCierreAuxDateTo);
            ucTfpostulacionesfechacierre_rangepicker.Render(context, "wwp.daterangepicker", Tfpostulacionesfechacierre_rangepicker_Internalname, "TFPOSTULACIONESFECHACIERRE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_postulacionesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_postulacionesfechaaltaauxdatetext_Internalname, AV85DDO_PostulacionesFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV85DDO_PostulacionesFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_postulacionesfechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            /* User Defined Control */
            ucTfpostulacionesfechaalta_rangepicker.SetProperty("Start Date", AV83DDO_PostulacionesFechaAltaAuxDate);
            ucTfpostulacionesfechaalta_rangepicker.SetProperty("End Date", AV84DDO_PostulacionesFechaAltaAuxDateTo);
            ucTfpostulacionesfechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfpostulacionesfechaalta_rangepicker_Internalname, "TFPOSTULACIONESFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 129 )
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

      protected void STARTKI2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Postulaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPKI0( ) ;
      }

      protected void WSKI2( )
      {
         STARTKI2( ) ;
         EVTKI2( ) ;
      }

      protected void EVTKI2( )
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
                              E11KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E21KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25KI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26KI2 ();
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
                              nGXsfl_129_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
                              SubsflControlProps_1292( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV95GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV95GridActions), 4, 0));
                              A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n422PostulacionesId = false;
                              A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n942ServiciosId = false;
                              A943ServiciosNombre = cgiGet( edtServiciosNombre_Internalname);
                              A945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A969PostulacionesProveedorNombre = cgiGet( edtPostulacionesProveedorNombre_Internalname);
                              A946PostulacionesPrecio = context.localUtil.CToN( cgiGet( edtPostulacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A961PostulacionesMultimediaSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesMultimediaSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A970PostulacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n970PostulacionesSolicitudesId = false;
                              A936PostulacionesDescripcion = cgiGet( edtPostulacionesDescripcion_Internalname);
                              A937PostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( chkPostulacionesReqSuministros_Internalname));
                              A938PostulacionesSuministrosDescri = cgiGet( edtPostulacionesSuministrosDescri_Internalname);
                              A947PostulacionesFechaTrabajo = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionesFechaTrabajo_Internalname), 0));
                              A939PostulacionesFechaCierre = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionesFechaCierre_Internalname), 0));
                              A940PostulacionesHoraCierre = cgiGet( edtPostulacionesHoraCierre_Internalname);
                              A941PostulacionesTipoFecha = cgiGet( edtPostulacionesTipoFecha_Internalname);
                              A949PostulacionesRgoHoraservicio = cgiGet( edtPostulacionesRgoHoraservicio_Internalname);
                              A950PostulacionesApellidoNombre = cgiGet( edtPostulacionesApellidoNombre_Internalname);
                              A951PostulacionesMail = cgiGet( edtPostulacionesMail_Internalname);
                              A952PostulacionesTelefono = cgiGet( edtPostulacionesTelefono_Internalname);
                              A425PostulacionesFechaAlta = context.localUtil.CToT( cgiGet( edtPostulacionesFechaAlta_Internalname), 0);
                              cmbPostulacionesEstado.Name = cmbPostulacionesEstado_Internalname;
                              cmbPostulacionesEstado.CurrentValue = cgiGet( cmbPostulacionesEstado_Internalname);
                              A424PostulacionesEstado = cgiGet( cmbPostulacionesEstado_Internalname);
                              A948PostulacionesSecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E27KI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28KI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29KI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30KI2 ();
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
                                       /* Set Refresh If Postulacionesproveedornombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPOSTULACIONESPROVEEDORNOMBRE1"), AV108PostulacionesProveedorNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Postulacionesproveedorid1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPOSTULACIONESPROVEEDORID1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20PostulacionesProveedorId1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Serviciosnombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSERVICIOSNOMBRE1"), AV21ServiciosNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Postulacionesproveedornombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPOSTULACIONESPROVEEDORNOMBRE2"), AV109PostulacionesProveedorNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Postulacionesproveedorid2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPOSTULACIONESPROVEEDORID2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25PostulacionesProveedorId2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Serviciosnombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSERVICIOSNOMBRE2"), AV26ServiciosNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Postulacionesproveedornombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPOSTULACIONESPROVEEDORNOMBRE3"), AV110PostulacionesProveedorNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Postulacionesproveedorid3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPOSTULACIONESPROVEEDORID3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30PostulacionesProveedorId3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Serviciosnombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSERVICIOSNOMBRE3"), AV31ServiciosNombre3) != 0 )
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
                        if ( nCmpId == 167 )
                        {
                           OldWwpaux_wc = cgiGet( "W0167");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0167", "", sEvt);
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

      protected void WEKI2( )
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

      protected void PAKI2( )
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
         SubsflControlProps_1292( ) ;
         while ( nGXsfl_129_idx <= nRC_GXsfl_129 )
         {
            sendrow_1292( ) ;
            nGXsfl_129_idx = ((subGrid_Islastpage==1)&&(nGXsfl_129_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV108PostulacionesProveedorNombre1 ,
                                       long AV20PostulacionesProveedorId1 ,
                                       string AV21ServiciosNombre1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV109PostulacionesProveedorNombre2 ,
                                       long AV25PostulacionesProveedorId2 ,
                                       string AV26ServiciosNombre2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       string AV110PostulacionesProveedorNombre3 ,
                                       long AV30PostulacionesProveedorId3 ,
                                       string AV31ServiciosNombre3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV123Pgmname ,
                                       string AV17FilterFullText ,
                                       long AV44TFPostulacionesId ,
                                       long AV45TFPostulacionesId_To ,
                                       long AV46TFServiciosId ,
                                       long AV47TFServiciosId_To ,
                                       string AV48TFServiciosNombre ,
                                       string AV49TFServiciosNombre_Sel ,
                                       long AV50TFPostulacionesProveedorId ,
                                       long AV51TFPostulacionesProveedorId_To ,
                                       string AV103TFPostulacionesProveedorNombre ,
                                       string AV104TFPostulacionesProveedorNombre_Sel ,
                                       decimal AV52TFPostulacionesPrecio ,
                                       decimal AV53TFPostulacionesPrecio_To ,
                                       short AV105TFPostulacionesMultimediaSerial ,
                                       short AV106TFPostulacionesMultimediaSerial_To ,
                                       long AV111TFPostulacionesSolicitudesId ,
                                       long AV112TFPostulacionesSolicitudesId_To ,
                                       string AV54TFPostulacionesDescripcion ,
                                       string AV55TFPostulacionesDescripcion_Sel ,
                                       short AV56TFPostulacionesReqSuministros_Sel ,
                                       string AV57TFPostulacionesSuministrosDescripcion ,
                                       string AV58TFPostulacionesSuministrosDescripcion_Sel ,
                                       DateTime AV59TFPostulacionesFechaTrabajo ,
                                       DateTime AV60TFPostulacionesFechaTrabajo_To ,
                                       DateTime AV64TFPostulacionesFechaCierre ,
                                       DateTime AV65TFPostulacionesFechaCierre_To ,
                                       string AV69TFPostulacionesHoraCierre ,
                                       string AV70TFPostulacionesHoraCierre_Sel ,
                                       string AV71TFPostulacionesTipoFecha ,
                                       string AV122TFPostulacionesTipoFecha_Sel ,
                                       string AV73TFPostulacionesRgoHoraservicio ,
                                       string AV74TFPostulacionesRgoHoraservicio_Sel ,
                                       string AV75TFPostulacionesApellidoNombre ,
                                       string AV76TFPostulacionesApellidoNombre_Sel ,
                                       string AV77TFPostulacionesMail ,
                                       string AV78TFPostulacionesMail_Sel ,
                                       string AV79TFPostulacionesTelefono ,
                                       string AV80TFPostulacionesTelefono_Sel ,
                                       DateTime AV81TFPostulacionesFechaAlta ,
                                       DateTime AV82TFPostulacionesFechaAlta_To ,
                                       GxSimpleCollection<string> AV87TFPostulacionesEstado_Sels ,
                                       long AV88TFPostulacionesSecUserId ,
                                       long AV89TFPostulacionesSecUserId_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV97IsAuthorized_Update ,
                                       bool AV98IsAuthorized_Delete ,
                                       bool AV99IsAuthorized_ServiciosNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFKI2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", "")));
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
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFKI2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV123Pgmname = "PostulacionesWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV181Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV125Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV126Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV127Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV128Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV129Postulacioneswwds_6_serviciosnombre1 ,
                                              AV130Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV131Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV132Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV133Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV134Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV135Postulacioneswwds_12_serviciosnombre2 ,
                                              AV136Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV137Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV138Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV139Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV140Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV141Postulacioneswwds_18_serviciosnombre3 ,
                                              AV142Postulacioneswwds_19_tfpostulacionesid ,
                                              AV143Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV144Postulacioneswwds_21_tfserviciosid ,
                                              AV145Postulacioneswwds_22_tfserviciosid_to ,
                                              AV147Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV146Postulacioneswwds_23_tfserviciosnombre ,
                                              AV148Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV150Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV152Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV153Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV158Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV165Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV167Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV169Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV173Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV176Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV175Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV178Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV177Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV179Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV181Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV182Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV183Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV124Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV156Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV127Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV127Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV129Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV129Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV133Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV133Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV135Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV135Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV139Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV139Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV141Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV141Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV146Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV146Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV150Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV150Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV158Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV158Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV167Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV167Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV169Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV169Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV173Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV173Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV175Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV175Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV177Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV177Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor H00KI3 */
         pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId, AV156Postulacioneswwds_33_tfpostulacionessolicitudesid, AV156Postulacioneswwds_33_tfpostulacionessolicitudesid, AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV127Postulacioneswwds_4_postulacionesproveedornombre1, lV127Postulacioneswwds_4_postulacionesproveedornombre1, AV128Postulacioneswwds_5_postulacionesproveedorid1, AV128Postulacioneswwds_5_postulacionesproveedorid1, AV128Postulacioneswwds_5_postulacionesproveedorid1, lV129Postulacioneswwds_6_serviciosnombre1, lV129Postulacioneswwds_6_serviciosnombre1, lV133Postulacioneswwds_10_postulacionesproveedornombre2, lV133Postulacioneswwds_10_postulacionesproveedornombre2, AV134Postulacioneswwds_11_postulacionesproveedorid2, AV134Postulacioneswwds_11_postulacionesproveedorid2, AV134Postulacioneswwds_11_postulacionesproveedorid2, lV135Postulacioneswwds_12_serviciosnombre2, lV135Postulacioneswwds_12_serviciosnombre2, lV139Postulacioneswwds_16_postulacionesproveedornombre3, lV139Postulacioneswwds_16_postulacionesproveedornombre3, AV140Postulacioneswwds_17_postulacionesproveedorid3, AV140Postulacioneswwds_17_postulacionesproveedorid3, AV140Postulacioneswwds_17_postulacionesproveedorid3, lV141Postulacioneswwds_18_serviciosnombre3, lV141Postulacioneswwds_18_serviciosnombre3, AV142Postulacioneswwds_19_tfpostulacionesid, AV143Postulacioneswwds_20_tfpostulacionesid_to, AV144Postulacioneswwds_21_tfserviciosid, AV145Postulacioneswwds_22_tfserviciosid_to, lV146Postulacioneswwds_23_tfserviciosnombre, AV147Postulacioneswwds_24_tfserviciosnombre_sel, AV148Postulacioneswwds_25_tfpostulacionesproveedorid, AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV150Postulacioneswwds_27_tfpostulacionesproveedornombre, AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV152Postulacioneswwds_29_tfpostulacionesprecio, AV153Postulacioneswwds_30_tfpostulacionesprecio_to, AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV158Postulacioneswwds_35_tfpostulacionesdescripcion, AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV165Postulacioneswwds_42_tfpostulacionesfechacierre, AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV167Postulacioneswwds_44_tfpostulacioneshoracierre, AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV169Postulacioneswwds_46_tfpostulacionestipofecha, AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV173Postulacioneswwds_50_tfpostulacionesapellidonombre, AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV175Postulacioneswwds_52_tfpostulacionesmail, AV176Postulacioneswwds_53_tfpostulacionesmail_sel, lV177Postulacioneswwds_54_tfpostulacionestelefono, AV178Postulacioneswwds_55_tfpostulacionestelefono_sel, AV179Postulacioneswwds_56_tfpostulacionesfechaalta, AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV182Postulacioneswwds_59_tfpostulacionessecuserid, AV183Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A948PostulacionesSecUserId = H00KI3_A948PostulacionesSecUserId[0];
            A424PostulacionesEstado = H00KI3_A424PostulacionesEstado[0];
            A425PostulacionesFechaAlta = H00KI3_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = H00KI3_A952PostulacionesTelefono[0];
            A951PostulacionesMail = H00KI3_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = H00KI3_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = H00KI3_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = H00KI3_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = H00KI3_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = H00KI3_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = H00KI3_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = H00KI3_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = H00KI3_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = H00KI3_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = H00KI3_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = H00KI3_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = H00KI3_A969PostulacionesProveedorNombre[0];
            A945PostulacionesProveedorId = H00KI3_A945PostulacionesProveedorId[0];
            A943ServiciosNombre = H00KI3_A943ServiciosNombre[0];
            A942ServiciosId = H00KI3_A942ServiciosId[0];
            n942ServiciosId = H00KI3_n942ServiciosId[0];
            A422PostulacionesId = H00KI3_A422PostulacionesId[0];
            n422PostulacionesId = H00KI3_n422PostulacionesId[0];
            A970PostulacionesSolicitudesId = H00KI3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = H00KI3_n970PostulacionesSolicitudesId[0];
            A969PostulacionesProveedorNombre = H00KI3_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = H00KI3_A943ServiciosNombre[0];
            A970PostulacionesSolicitudesId = H00KI3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = H00KI3_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFKI2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 129;
         /* Execute user event: Refresh */
         E28KI2 ();
         nGXsfl_129_idx = 1;
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         bGXsfl_129_Refreshing = true;
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
            SubsflControlProps_1292( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A424PostulacionesEstado ,
                                                 AV181Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                                 AV125Postulacioneswwds_2_dynamicfiltersselector1 ,
                                                 AV126Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                                 AV127Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                                 AV128Postulacioneswwds_5_postulacionesproveedorid1 ,
                                                 AV129Postulacioneswwds_6_serviciosnombre1 ,
                                                 AV130Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                                 AV131Postulacioneswwds_8_dynamicfiltersselector2 ,
                                                 AV132Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                                 AV133Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                                 AV134Postulacioneswwds_11_postulacionesproveedorid2 ,
                                                 AV135Postulacioneswwds_12_serviciosnombre2 ,
                                                 AV136Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                                 AV137Postulacioneswwds_14_dynamicfiltersselector3 ,
                                                 AV138Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                                 AV139Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                                 AV140Postulacioneswwds_17_postulacionesproveedorid3 ,
                                                 AV141Postulacioneswwds_18_serviciosnombre3 ,
                                                 AV142Postulacioneswwds_19_tfpostulacionesid ,
                                                 AV143Postulacioneswwds_20_tfpostulacionesid_to ,
                                                 AV144Postulacioneswwds_21_tfserviciosid ,
                                                 AV145Postulacioneswwds_22_tfserviciosid_to ,
                                                 AV147Postulacioneswwds_24_tfserviciosnombre_sel ,
                                                 AV146Postulacioneswwds_23_tfserviciosnombre ,
                                                 AV148Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                                 AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                                 AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                                 AV150Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                                 AV152Postulacioneswwds_29_tfpostulacionesprecio ,
                                                 AV153Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                                 AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                                 AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                                 AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                                 AV158Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                                 AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                                 AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                                 AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                                 AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                                 AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                                 AV165Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                                 AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                                 AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                                 AV167Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                                 AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                                 AV169Postulacioneswwds_46_tfpostulacionestipofecha ,
                                                 AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                                 AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                                 AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                                 AV173Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                                 AV176Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                                 AV175Postulacioneswwds_52_tfpostulacionesmail ,
                                                 AV178Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                                 AV177Postulacioneswwds_54_tfpostulacionestelefono ,
                                                 AV179Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                                 AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                                 AV181Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                                 AV182Postulacioneswwds_59_tfpostulacionessecuserid ,
                                                 AV183Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                                 A969PostulacionesProveedorNombre ,
                                                 A945PostulacionesProveedorId ,
                                                 A943ServiciosNombre ,
                                                 A422PostulacionesId ,
                                                 A942ServiciosId ,
                                                 A946PostulacionesPrecio ,
                                                 A961PostulacionesMultimediaSerial ,
                                                 A936PostulacionesDescripcion ,
                                                 A937PostulacionesReqSuministros ,
                                                 A938PostulacionesSuministrosDescri ,
                                                 A947PostulacionesFechaTrabajo ,
                                                 A939PostulacionesFechaCierre ,
                                                 A940PostulacionesHoraCierre ,
                                                 A941PostulacionesTipoFecha ,
                                                 A949PostulacionesRgoHoraservicio ,
                                                 A950PostulacionesApellidoNombre ,
                                                 A951PostulacionesMail ,
                                                 A952PostulacionesTelefono ,
                                                 A425PostulacionesFechaAlta ,
                                                 A948PostulacionesSecUserId ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV124Postulacioneswwds_1_filterfulltext ,
                                                 A970PostulacionesSolicitudesId ,
                                                 AV156Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                                 AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV127Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
            lV127Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
            lV129Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1), 80, "%");
            lV129Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1), 80, "%");
            lV133Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
            lV133Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
            lV135Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2), 80, "%");
            lV135Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2), 80, "%");
            lV139Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
            lV139Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
            lV141Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3), 80, "%");
            lV141Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3), 80, "%");
            lV146Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV146Postulacioneswwds_23_tfserviciosnombre), 80, "%");
            lV150Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV150Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
            lV158Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV158Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
            lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
            lV167Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV167Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
            lV169Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV169Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
            lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
            lV173Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV173Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
            lV175Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV175Postulacioneswwds_52_tfpostulacionesmail), "%", "");
            lV177Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV177Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
            /* Using cursor H00KI5 */
            pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId, AV156Postulacioneswwds_33_tfpostulacionessolicitudesid, AV156Postulacioneswwds_33_tfpostulacionessolicitudesid, AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV127Postulacioneswwds_4_postulacionesproveedornombre1, lV127Postulacioneswwds_4_postulacionesproveedornombre1, AV128Postulacioneswwds_5_postulacionesproveedorid1, AV128Postulacioneswwds_5_postulacionesproveedorid1, AV128Postulacioneswwds_5_postulacionesproveedorid1, lV129Postulacioneswwds_6_serviciosnombre1, lV129Postulacioneswwds_6_serviciosnombre1, lV133Postulacioneswwds_10_postulacionesproveedornombre2, lV133Postulacioneswwds_10_postulacionesproveedornombre2, AV134Postulacioneswwds_11_postulacionesproveedorid2, AV134Postulacioneswwds_11_postulacionesproveedorid2, AV134Postulacioneswwds_11_postulacionesproveedorid2, lV135Postulacioneswwds_12_serviciosnombre2, lV135Postulacioneswwds_12_serviciosnombre2, lV139Postulacioneswwds_16_postulacionesproveedornombre3, lV139Postulacioneswwds_16_postulacionesproveedornombre3, AV140Postulacioneswwds_17_postulacionesproveedorid3, AV140Postulacioneswwds_17_postulacionesproveedorid3, AV140Postulacioneswwds_17_postulacionesproveedorid3, lV141Postulacioneswwds_18_serviciosnombre3, lV141Postulacioneswwds_18_serviciosnombre3, AV142Postulacioneswwds_19_tfpostulacionesid, AV143Postulacioneswwds_20_tfpostulacionesid_to, AV144Postulacioneswwds_21_tfserviciosid, AV145Postulacioneswwds_22_tfserviciosid_to, lV146Postulacioneswwds_23_tfserviciosnombre, AV147Postulacioneswwds_24_tfserviciosnombre_sel, AV148Postulacioneswwds_25_tfpostulacionesproveedorid, AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV150Postulacioneswwds_27_tfpostulacionesproveedornombre, AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV152Postulacioneswwds_29_tfpostulacionesprecio, AV153Postulacioneswwds_30_tfpostulacionesprecio_to, AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV158Postulacioneswwds_35_tfpostulacionesdescripcion, AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV165Postulacioneswwds_42_tfpostulacionesfechacierre, AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV167Postulacioneswwds_44_tfpostulacioneshoracierre, AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV169Postulacioneswwds_46_tfpostulacionestipofecha, AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV173Postulacioneswwds_50_tfpostulacionesapellidonombre, AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV175Postulacioneswwds_52_tfpostulacionesmail, AV176Postulacioneswwds_53_tfpostulacionesmail_sel, lV177Postulacioneswwds_54_tfpostulacionestelefono, AV178Postulacioneswwds_55_tfpostulacionestelefono_sel, AV179Postulacioneswwds_56_tfpostulacionesfechaalta, AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV182Postulacioneswwds_59_tfpostulacionessecuserid, AV183Postulacioneswwds_60_tfpostulacionessecuserid_to});
            nGXsfl_129_idx = 1;
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A948PostulacionesSecUserId = H00KI5_A948PostulacionesSecUserId[0];
               A424PostulacionesEstado = H00KI5_A424PostulacionesEstado[0];
               A425PostulacionesFechaAlta = H00KI5_A425PostulacionesFechaAlta[0];
               A952PostulacionesTelefono = H00KI5_A952PostulacionesTelefono[0];
               A951PostulacionesMail = H00KI5_A951PostulacionesMail[0];
               A950PostulacionesApellidoNombre = H00KI5_A950PostulacionesApellidoNombre[0];
               A949PostulacionesRgoHoraservicio = H00KI5_A949PostulacionesRgoHoraservicio[0];
               A941PostulacionesTipoFecha = H00KI5_A941PostulacionesTipoFecha[0];
               A940PostulacionesHoraCierre = H00KI5_A940PostulacionesHoraCierre[0];
               A939PostulacionesFechaCierre = H00KI5_A939PostulacionesFechaCierre[0];
               A947PostulacionesFechaTrabajo = H00KI5_A947PostulacionesFechaTrabajo[0];
               A938PostulacionesSuministrosDescri = H00KI5_A938PostulacionesSuministrosDescri[0];
               A937PostulacionesReqSuministros = H00KI5_A937PostulacionesReqSuministros[0];
               A936PostulacionesDescripcion = H00KI5_A936PostulacionesDescripcion[0];
               A961PostulacionesMultimediaSerial = H00KI5_A961PostulacionesMultimediaSerial[0];
               A946PostulacionesPrecio = H00KI5_A946PostulacionesPrecio[0];
               A969PostulacionesProveedorNombre = H00KI5_A969PostulacionesProveedorNombre[0];
               A945PostulacionesProveedorId = H00KI5_A945PostulacionesProveedorId[0];
               A943ServiciosNombre = H00KI5_A943ServiciosNombre[0];
               A942ServiciosId = H00KI5_A942ServiciosId[0];
               n942ServiciosId = H00KI5_n942ServiciosId[0];
               A422PostulacionesId = H00KI5_A422PostulacionesId[0];
               n422PostulacionesId = H00KI5_n422PostulacionesId[0];
               A970PostulacionesSolicitudesId = H00KI5_A970PostulacionesSolicitudesId[0];
               n970PostulacionesSolicitudesId = H00KI5_n970PostulacionesSolicitudesId[0];
               A969PostulacionesProveedorNombre = H00KI5_A969PostulacionesProveedorNombre[0];
               A943ServiciosNombre = H00KI5_A943ServiciosNombre[0];
               A970PostulacionesSolicitudesId = H00KI5_A970PostulacionesSolicitudesId[0];
               n970PostulacionesSolicitudesId = H00KI5_n970PostulacionesSolicitudesId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV124Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV124Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E29KI2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 129;
            WBKI0( ) ;
         }
         bGXsfl_129_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesKI2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV123Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV123Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV97IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV97IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV98IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV98IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SERVICIOSNOMBRE", AV99IsAuthorized_ServiciosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SERVICIOSNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_ServiciosNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESID"+"_"+sGXsfl_129_idx, GetSecureSignedToken( sGXsfl_129_idx, context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV123Pgmname = "PostulacionesWW";
         /* Using cursor H00KI7 */
         pr_default.execute(2, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A970PostulacionesSolicitudesId = H00KI7_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = H00KI7_n970PostulacionesSolicitudesId[0];
         }
         else
         {
            A970PostulacionesSolicitudesId = 0;
            n970PostulacionesSolicitudesId = false;
         }
         pr_default.close(2);
         edtPostulacionesId_Enabled = 0;
         edtServiciosId_Enabled = 0;
         edtServiciosNombre_Enabled = 0;
         edtPostulacionesProveedorId_Enabled = 0;
         edtPostulacionesProveedorNombre_Enabled = 0;
         edtPostulacionesPrecio_Enabled = 0;
         edtPostulacionesMultimediaSerial_Enabled = 0;
         edtPostulacionesSolicitudesId_Enabled = 0;
         edtPostulacionesDescripcion_Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         edtPostulacionesSuministrosDescri_Enabled = 0;
         edtPostulacionesFechaTrabajo_Enabled = 0;
         edtPostulacionesFechaCierre_Enabled = 0;
         edtPostulacionesHoraCierre_Enabled = 0;
         edtPostulacionesTipoFecha_Enabled = 0;
         edtPostulacionesRgoHoraservicio_Enabled = 0;
         edtPostulacionesApellidoNombre_Enabled = 0;
         edtPostulacionesMail_Enabled = 0;
         edtPostulacionesTelefono_Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         cmbPostulacionesEstado.Enabled = 0;
         edtPostulacionesSecUserId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPKI0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27KI2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV100AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV90DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV92GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV93GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV94GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV61DDO_PostulacionesFechaTrabajoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_POSTULACIONESFECHATRABAJOAUXDATE"), 0);
            AV62DDO_PostulacionesFechaTrabajoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_POSTULACIONESFECHATRABAJOAUXDATETO"), 0);
            AV66DDO_PostulacionesFechaCierreAuxDate = context.localUtil.CToD( cgiGet( "vDDO_POSTULACIONESFECHACIERREAUXDATE"), 0);
            AV67DDO_PostulacionesFechaCierreAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_POSTULACIONESFECHACIERREAUXDATETO"), 0);
            AV83DDO_PostulacionesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_POSTULACIONESFECHAALTAAUXDATE"), 0);
            AssignAttri("", false, "AV83DDO_PostulacionesFechaAltaAuxDate", context.localUtil.Format(AV83DDO_PostulacionesFechaAltaAuxDate, "99/99/99"));
            AV84DDO_PostulacionesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_POSTULACIONESFECHAALTAAUXDATETO"), 0);
            AssignAttri("", false, "AV84DDO_PostulacionesFechaAltaAuxDateTo", context.localUtil.Format(AV84DDO_PostulacionesFechaAltaAuxDateTo, "99/99/99"));
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
            AV108PostulacionesProveedorNombre1 = cgiGet( edtavPostulacionesproveedornombre1_Internalname);
            AssignAttri("", false, "AV108PostulacionesProveedorNombre1", AV108PostulacionesProveedorNombre1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPOSTULACIONESPROVEEDORID1");
               GX_FocusControl = edtavPostulacionesproveedorid1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20PostulacionesProveedorId1 = 0;
               AssignAttri("", false, "AV20PostulacionesProveedorId1", StringUtil.LTrimStr( (decimal)(AV20PostulacionesProveedorId1), 18, 0));
            }
            else
            {
               AV20PostulacionesProveedorId1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20PostulacionesProveedorId1", StringUtil.LTrimStr( (decimal)(AV20PostulacionesProveedorId1), 18, 0));
            }
            AV21ServiciosNombre1 = cgiGet( edtavServiciosnombre1_Internalname);
            AssignAttri("", false, "AV21ServiciosNombre1", AV21ServiciosNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AV109PostulacionesProveedorNombre2 = cgiGet( edtavPostulacionesproveedornombre2_Internalname);
            AssignAttri("", false, "AV109PostulacionesProveedorNombre2", AV109PostulacionesProveedorNombre2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPOSTULACIONESPROVEEDORID2");
               GX_FocusControl = edtavPostulacionesproveedorid2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25PostulacionesProveedorId2 = 0;
               AssignAttri("", false, "AV25PostulacionesProveedorId2", StringUtil.LTrimStr( (decimal)(AV25PostulacionesProveedorId2), 18, 0));
            }
            else
            {
               AV25PostulacionesProveedorId2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25PostulacionesProveedorId2", StringUtil.LTrimStr( (decimal)(AV25PostulacionesProveedorId2), 18, 0));
            }
            AV26ServiciosNombre2 = cgiGet( edtavServiciosnombre2_Internalname);
            AssignAttri("", false, "AV26ServiciosNombre2", AV26ServiciosNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AV110PostulacionesProveedorNombre3 = cgiGet( edtavPostulacionesproveedornombre3_Internalname);
            AssignAttri("", false, "AV110PostulacionesProveedorNombre3", AV110PostulacionesProveedorNombre3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPOSTULACIONESPROVEEDORID3");
               GX_FocusControl = edtavPostulacionesproveedorid3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30PostulacionesProveedorId3 = 0;
               AssignAttri("", false, "AV30PostulacionesProveedorId3", StringUtil.LTrimStr( (decimal)(AV30PostulacionesProveedorId3), 18, 0));
            }
            else
            {
               AV30PostulacionesProveedorId3 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavPostulacionesproveedorid3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30PostulacionesProveedorId3", StringUtil.LTrimStr( (decimal)(AV30PostulacionesProveedorId3), 18, 0));
            }
            AV31ServiciosNombre3 = cgiGet( edtavServiciosnombre3_Internalname);
            AssignAttri("", false, "AV31ServiciosNombre3", AV31ServiciosNombre3);
            AV63DDO_PostulacionesFechaTrabajoAuxDateText = cgiGet( edtavDdo_postulacionesfechatrabajoauxdatetext_Internalname);
            AssignAttri("", false, "AV63DDO_PostulacionesFechaTrabajoAuxDateText", AV63DDO_PostulacionesFechaTrabajoAuxDateText);
            AV68DDO_PostulacionesFechaCierreAuxDateText = cgiGet( edtavDdo_postulacionesfechacierreauxdatetext_Internalname);
            AssignAttri("", false, "AV68DDO_PostulacionesFechaCierreAuxDateText", AV68DDO_PostulacionesFechaCierreAuxDateText);
            AV85DDO_PostulacionesFechaAltaAuxDateText = cgiGet( edtavDdo_postulacionesfechaaltaauxdatetext_Internalname);
            AssignAttri("", false, "AV85DDO_PostulacionesFechaAltaAuxDateText", AV85DDO_PostulacionesFechaAltaAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPOSTULACIONESPROVEEDORNOMBRE1"), AV108PostulacionesProveedorNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPOSTULACIONESPROVEEDORID1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20PostulacionesProveedorId1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSERVICIOSNOMBRE1"), AV21ServiciosNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPOSTULACIONESPROVEEDORNOMBRE2"), AV109PostulacionesProveedorNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPOSTULACIONESPROVEEDORID2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25PostulacionesProveedorId2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSERVICIOSNOMBRE2"), AV26ServiciosNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPOSTULACIONESPROVEEDORNOMBRE3"), AV110PostulacionesProveedorNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPOSTULACIONESPROVEEDORID3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30PostulacionesProveedorId3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSERVICIOSNOMBRE3"), AV31ServiciosNombre3) != 0 )
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
         E27KI2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27KI2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFPOSTULACIONESFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_postulacionesfechaaltaauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFPOSTULACIONESFECHACIERRE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_postulacionesfechacierreauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFPOSTULACIONESFECHATRABAJO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_postulacionesfechatrabajoauxdatetext_Internalname});
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
         AV18DynamicFiltersSelector1 = "POSTULACIONESPROVEEDORNOMBRE";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "POSTULACIONESPROVEEDORNOMBRE";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "POSTULACIONESPROVEEDORNOMBRE";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
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
         AV100AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV101AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV101AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV101AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV101AGExportDataItem.gxTpr_Eventkey = "Export";
         AV101AGExportDataItem.gxTpr_Isdivider = false;
         AV100AGExportData.Add(AV101AGExportDataItem, 0);
         AV101AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV101AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV101AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV101AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV101AGExportDataItem.gxTpr_Isdivider = false;
         AV100AGExportData.Add(AV101AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV99IsAuthorized_ServiciosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWServicios", out  GXt_boolean1) ;
         AV99IsAuthorized_ServiciosNombre = GXt_boolean1;
         AssignAttri("", false, "AV99IsAuthorized_ServiciosNombre", AV99IsAuthorized_ServiciosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SERVICIOSNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_ServiciosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Postulaciones", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV90DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV90DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E28KI2( )
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
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("PostulacionesWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("PostulacionesWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
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
         edtPostulacionesId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtServiciosId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtServiciosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtServiciosId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtServiciosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtServiciosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtServiciosNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesProveedorId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesProveedorId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesProveedorNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesProveedorNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesPrecio_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesPrecio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesPrecio_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesMultimediaSerial_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesMultimediaSerial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesSolicitudesId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesSolicitudesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesSolicitudesId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesDescripcion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesDescripcion_Visible), 5, 0), !bGXsfl_129_Refreshing);
         chkPostulacionesReqSuministros.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkPostulacionesReqSuministros.Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesSuministrosDescri_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesSuministrosDescri_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesSuministrosDescri_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesFechaTrabajo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesFechaTrabajo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaTrabajo_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesFechaCierre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesFechaCierre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaCierre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesHoraCierre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(14)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesHoraCierre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesHoraCierre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesTipoFecha_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(15)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesTipoFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesTipoFecha_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesRgoHoraservicio_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(16)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesRgoHoraservicio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesRgoHoraservicio_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesApellidoNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(17)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesApellidoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesApellidoNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesMail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(18)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesMail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesMail_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesTelefono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(19)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesTelefono_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(20)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaAlta_Visible), 5, 0), !bGXsfl_129_Refreshing);
         cmbPostulacionesEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(21)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbPostulacionesEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbPostulacionesEstado.Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtPostulacionesSecUserId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(22)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPostulacionesSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesSecUserId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         AV92GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV92GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV92GridCurrentPage), 10, 0));
         AV93GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV93GridPageCount", StringUtil.LTrimStr( (decimal)(AV93GridPageCount), 10, 0));
         GXt_char3 = AV94GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV123Pgmname, out  GXt_char3) ;
         AV94GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV94GridAppliedFilters", AV94GridAppliedFilters);
         AV124Postulacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV126Postulacioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = AV108PostulacionesProveedorNombre1;
         AV128Postulacioneswwds_5_postulacionesproveedorid1 = AV20PostulacionesProveedorId1;
         AV129Postulacioneswwds_6_serviciosnombre1 = AV21ServiciosNombre1;
         AV130Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV132Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = AV109PostulacionesProveedorNombre2;
         AV134Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV135Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV136Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV138Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = AV110PostulacionesProveedorNombre3;
         AV140Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV141Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV142Postulacioneswwds_19_tfpostulacionesid = AV44TFPostulacionesId;
         AV143Postulacioneswwds_20_tfpostulacionesid_to = AV45TFPostulacionesId_To;
         AV144Postulacioneswwds_21_tfserviciosid = AV46TFServiciosId;
         AV145Postulacioneswwds_22_tfserviciosid_to = AV47TFServiciosId_To;
         AV146Postulacioneswwds_23_tfserviciosnombre = AV48TFServiciosNombre;
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = AV49TFServiciosNombre_Sel;
         AV148Postulacioneswwds_25_tfpostulacionesproveedorid = AV50TFPostulacionesProveedorId;
         AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV51TFPostulacionesProveedorId_To;
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = AV103TFPostulacionesProveedorNombre;
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV104TFPostulacionesProveedorNombre_Sel;
         AV152Postulacioneswwds_29_tfpostulacionesprecio = AV52TFPostulacionesPrecio;
         AV153Postulacioneswwds_30_tfpostulacionesprecio_to = AV53TFPostulacionesPrecio_To;
         AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV105TFPostulacionesMultimediaSerial;
         AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV106TFPostulacionesMultimediaSerial_To;
         AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = AV111TFPostulacionesSolicitudesId;
         AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV112TFPostulacionesSolicitudesId_To;
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = AV54TFPostulacionesDescripcion;
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV55TFPostulacionesDescripcion_Sel;
         AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV56TFPostulacionesReqSuministros_Sel;
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV57TFPostulacionesSuministrosDescripcion;
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV58TFPostulacionesSuministrosDescripcion_Sel;
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV59TFPostulacionesFechaTrabajo;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV60TFPostulacionesFechaTrabajo_To;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = AV64TFPostulacionesFechaCierre;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV65TFPostulacionesFechaCierre_To;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV122TFPostulacionesTipoFecha_Sel;
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV175Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV177Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = AV87TFPostulacionesEstado_Sels;
         AV182Postulacioneswwds_59_tfpostulacionessecuserid = AV88TFPostulacionesSecUserId;
         AV183Postulacioneswwds_60_tfpostulacionessecuserid_to = AV89TFPostulacionesSecUserId_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12KI2( )
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
            AV91PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV91PageToGo) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13KI2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16KI2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesId") == 0 )
            {
               AV44TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFPostulacionesId", StringUtil.LTrimStr( (decimal)(AV44TFPostulacionesId), 18, 0));
               AV45TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFPostulacionesId_To", StringUtil.LTrimStr( (decimal)(AV45TFPostulacionesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ServiciosId") == 0 )
            {
               AV46TFServiciosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFServiciosId", StringUtil.LTrimStr( (decimal)(AV46TFServiciosId), 18, 0));
               AV47TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFServiciosId_To", StringUtil.LTrimStr( (decimal)(AV47TFServiciosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ServiciosNombre") == 0 )
            {
               AV48TFServiciosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFServiciosNombre", AV48TFServiciosNombre);
               AV49TFServiciosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFServiciosNombre_Sel", AV49TFServiciosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesProveedorId") == 0 )
            {
               AV50TFPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFPostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV50TFPostulacionesProveedorId), 18, 0));
               AV51TFPostulacionesProveedorId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFPostulacionesProveedorId_To", StringUtil.LTrimStr( (decimal)(AV51TFPostulacionesProveedorId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesProveedorNombre") == 0 )
            {
               AV103TFPostulacionesProveedorNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV103TFPostulacionesProveedorNombre", AV103TFPostulacionesProveedorNombre);
               AV104TFPostulacionesProveedorNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV104TFPostulacionesProveedorNombre_Sel", AV104TFPostulacionesProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesPrecio") == 0 )
            {
               AV52TFPostulacionesPrecio = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV52TFPostulacionesPrecio", StringUtil.LTrimStr( AV52TFPostulacionesPrecio, 18, 2));
               AV53TFPostulacionesPrecio_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV53TFPostulacionesPrecio_To", StringUtil.LTrimStr( AV53TFPostulacionesPrecio_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesMultimediaSerial") == 0 )
            {
               AV105TFPostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV105TFPostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(AV105TFPostulacionesMultimediaSerial), 4, 0));
               AV106TFPostulacionesMultimediaSerial_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV106TFPostulacionesMultimediaSerial_To", StringUtil.LTrimStr( (decimal)(AV106TFPostulacionesMultimediaSerial_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesSolicitudesId") == 0 )
            {
               AV111TFPostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV111TFPostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV111TFPostulacionesSolicitudesId), 18, 0));
               AV112TFPostulacionesSolicitudesId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV112TFPostulacionesSolicitudesId_To", StringUtil.LTrimStr( (decimal)(AV112TFPostulacionesSolicitudesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesDescripcion") == 0 )
            {
               AV54TFPostulacionesDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFPostulacionesDescripcion", AV54TFPostulacionesDescripcion);
               AV55TFPostulacionesDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFPostulacionesDescripcion_Sel", AV55TFPostulacionesDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesReqSuministros") == 0 )
            {
               AV56TFPostulacionesReqSuministros_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFPostulacionesReqSuministros_Sel", StringUtil.Str( (decimal)(AV56TFPostulacionesReqSuministros_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesSuministrosDescripcion") == 0 )
            {
               AV57TFPostulacionesSuministrosDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV57TFPostulacionesSuministrosDescripcion", AV57TFPostulacionesSuministrosDescripcion);
               AV58TFPostulacionesSuministrosDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV58TFPostulacionesSuministrosDescripcion_Sel", AV58TFPostulacionesSuministrosDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesFechaTrabajo") == 0 )
            {
               AV59TFPostulacionesFechaTrabajo = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV59TFPostulacionesFechaTrabajo", context.localUtil.Format(AV59TFPostulacionesFechaTrabajo, "99/99/99"));
               AV60TFPostulacionesFechaTrabajo_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV60TFPostulacionesFechaTrabajo_To", context.localUtil.Format(AV60TFPostulacionesFechaTrabajo_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesFechaCierre") == 0 )
            {
               AV64TFPostulacionesFechaCierre = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFPostulacionesFechaCierre", context.localUtil.Format(AV64TFPostulacionesFechaCierre, "99/99/99"));
               AV65TFPostulacionesFechaCierre_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV65TFPostulacionesFechaCierre_To", context.localUtil.Format(AV65TFPostulacionesFechaCierre_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesHoraCierre") == 0 )
            {
               AV69TFPostulacionesHoraCierre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV69TFPostulacionesHoraCierre", AV69TFPostulacionesHoraCierre);
               AV70TFPostulacionesHoraCierre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV70TFPostulacionesHoraCierre_Sel", AV70TFPostulacionesHoraCierre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesTipoFecha") == 0 )
            {
               AV71TFPostulacionesTipoFecha = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV71TFPostulacionesTipoFecha", AV71TFPostulacionesTipoFecha);
               AV122TFPostulacionesTipoFecha_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV122TFPostulacionesTipoFecha_Sel", AV122TFPostulacionesTipoFecha_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesRgoHoraservicio") == 0 )
            {
               AV73TFPostulacionesRgoHoraservicio = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV73TFPostulacionesRgoHoraservicio", AV73TFPostulacionesRgoHoraservicio);
               AV74TFPostulacionesRgoHoraservicio_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV74TFPostulacionesRgoHoraservicio_Sel", AV74TFPostulacionesRgoHoraservicio_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesApellidoNombre") == 0 )
            {
               AV75TFPostulacionesApellidoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV75TFPostulacionesApellidoNombre", AV75TFPostulacionesApellidoNombre);
               AV76TFPostulacionesApellidoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV76TFPostulacionesApellidoNombre_Sel", AV76TFPostulacionesApellidoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesMail") == 0 )
            {
               AV77TFPostulacionesMail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV77TFPostulacionesMail", AV77TFPostulacionesMail);
               AV78TFPostulacionesMail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV78TFPostulacionesMail_Sel", AV78TFPostulacionesMail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesTelefono") == 0 )
            {
               AV79TFPostulacionesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV79TFPostulacionesTelefono", AV79TFPostulacionesTelefono);
               AV80TFPostulacionesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV80TFPostulacionesTelefono_Sel", AV80TFPostulacionesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesFechaAlta") == 0 )
            {
               AV81TFPostulacionesFechaAlta = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV81TFPostulacionesFechaAlta", context.localUtil.TToC( AV81TFPostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV82TFPostulacionesFechaAlta_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV82TFPostulacionesFechaAlta_To", context.localUtil.TToC( AV82TFPostulacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV82TFPostulacionesFechaAlta_To) )
               {
                  AV82TFPostulacionesFechaAlta_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV82TFPostulacionesFechaAlta_To)), (short)(DateTimeUtil.Month( AV82TFPostulacionesFechaAlta_To)), (short)(DateTimeUtil.Day( AV82TFPostulacionesFechaAlta_To)), 23, 59, 59);
                  AssignAttri("", false, "AV82TFPostulacionesFechaAlta_To", context.localUtil.TToC( AV82TFPostulacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesEstado") == 0 )
            {
               AV86TFPostulacionesEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV86TFPostulacionesEstado_SelsJson", AV86TFPostulacionesEstado_SelsJson);
               AV87TFPostulacionesEstado_Sels.FromJSonString(AV86TFPostulacionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionesSecUserId") == 0 )
            {
               AV88TFPostulacionesSecUserId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV88TFPostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(AV88TFPostulacionesSecUserId), 18, 0));
               AV89TFPostulacionesSecUserId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV89TFPostulacionesSecUserId_To", StringUtil.LTrimStr( (decimal)(AV89TFPostulacionesSecUserId_To), 18, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87TFPostulacionesEstado_Sels", AV87TFPostulacionesEstado_Sels);
      }

      private void E29KI2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV97IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV98IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( AV99IsAuthorized_ServiciosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "serviciosview.aspx"+UrlEncode(StringUtil.LTrimStr(A942ServiciosId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtServiciosNombre_Link = formatLink("serviciosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "postulacionesview.aspx"+UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtPostulacionesProveedorNombre_Link = formatLink("postulacionesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 129;
            }
            sendrow_1292( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_129_Refreshing )
         {
            context.DoAjaxLoad(129, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV95GridActions), 4, 0));
      }

      protected void E17KI2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "PostulacionesWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22KI2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E18KI2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E23KI2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E24KI2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E19KI2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E25KI2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E20KI2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV108PostulacionesProveedorNombre1, AV20PostulacionesProveedorId1, AV21ServiciosNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV109PostulacionesProveedorNombre2, AV25PostulacionesProveedorId2, AV26ServiciosNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV110PostulacionesProveedorNombre3, AV30PostulacionesProveedorId3, AV31ServiciosNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV123Pgmname, AV17FilterFullText, AV44TFPostulacionesId, AV45TFPostulacionesId_To, AV46TFServiciosId, AV47TFServiciosId_To, AV48TFServiciosNombre, AV49TFServiciosNombre_Sel, AV50TFPostulacionesProveedorId, AV51TFPostulacionesProveedorId_To, AV103TFPostulacionesProveedorNombre, AV104TFPostulacionesProveedorNombre_Sel, AV52TFPostulacionesPrecio, AV53TFPostulacionesPrecio_To, AV105TFPostulacionesMultimediaSerial, AV106TFPostulacionesMultimediaSerial_To, AV111TFPostulacionesSolicitudesId, AV112TFPostulacionesSolicitudesId_To, AV54TFPostulacionesDescripcion, AV55TFPostulacionesDescripcion_Sel, AV56TFPostulacionesReqSuministros_Sel, AV57TFPostulacionesSuministrosDescripcion, AV58TFPostulacionesSuministrosDescripcion_Sel, AV59TFPostulacionesFechaTrabajo, AV60TFPostulacionesFechaTrabajo_To, AV64TFPostulacionesFechaCierre, AV65TFPostulacionesFechaCierre_To, AV69TFPostulacionesHoraCierre, AV70TFPostulacionesHoraCierre_Sel, AV71TFPostulacionesTipoFecha, AV122TFPostulacionesTipoFecha_Sel, AV73TFPostulacionesRgoHoraservicio, AV74TFPostulacionesRgoHoraservicio_Sel, AV75TFPostulacionesApellidoNombre, AV76TFPostulacionesApellidoNombre_Sel, AV77TFPostulacionesMail, AV78TFPostulacionesMail_Sel, AV79TFPostulacionesTelefono, AV80TFPostulacionesTelefono_Sel, AV81TFPostulacionesFechaAlta, AV82TFPostulacionesFechaAlta_To, AV87TFPostulacionesEstado_Sels, AV88TFPostulacionesSecUserId, AV89TFPostulacionesSecUserId_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV97IsAuthorized_Update, AV98IsAuthorized_Delete, AV99IsAuthorized_ServiciosNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E26KI2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E11KI2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("PostulacionesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV123Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("PostulacionesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "PostulacionesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV42ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV123Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87TFPostulacionesEstado_Sels", AV87TFPostulacionesEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E30KI2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV95GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV95GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV95GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV95GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV95GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV95GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21KI2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14KI2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87TFPostulacionesEstado_Sels", AV87TFPostulacionesEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E15KI2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0167",(string)"",(string)"Postulaciones",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0167"+"");
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
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ServiciosId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ServiciosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesProveedorId",  "",  "Proveedor Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesProveedorNombre",  "",  "Proveedor Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesPrecio",  "",  "Precio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesMultimediaSerial",  "",  "Multimedia Serial",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesSolicitudesId",  "",  "Solicitudes Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesDescripcion",  "",  "Descripcion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesReqSuministros",  "",  "Req Suministros",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesSuministrosDescripcion",  "",  "Suministros Descripcion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesFechaTrabajo",  "",  "Fecha Trabajo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesFechaCierre",  "",  "Fecha Cierre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesHoraCierre",  "",  "Hora Cierre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesTipoFecha",  "",  "Tipo Fecha",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesRgoHoraservicio",  "",  "Rgo Horaservicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesApellidoNombre",  "",  "Apellido Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesMail",  "",  "Mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesTelefono",  "",  "Telefono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesFechaAlta",  "",  "Fecha",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "PostulacionesSecUserId",  "",  "User Id",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "PostulacionesWWColumnsSelector", out  GXt_char3) ;
         AV37UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV97IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Update", out  GXt_boolean1) ;
         AV97IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV97IsAuthorized_Update", AV97IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV97IsAuthorized_Update, context));
         GXt_boolean1 = AV98IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Delete", out  GXt_boolean1) ;
         AV98IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV98IsAuthorized_Delete", AV98IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV98IsAuthorized_Delete, context));
         GXt_boolean1 = AV102TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Insert", out  GXt_boolean1) ;
         AV102TempBoolean = GXt_boolean1;
         if ( ! ( AV102TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV102TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV102TempBoolean = GXt_boolean1;
         if ( ! ( AV102TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Postulaciones",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavPostulacionesproveedornombre1_Visible = 0;
         AssignProp("", false, edtavPostulacionesproveedornombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedornombre1_Visible), 5, 0), true);
         edtavPostulacionesproveedorid1_Visible = 0;
         AssignProp("", false, edtavPostulacionesproveedorid1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedorid1_Visible), 5, 0), true);
         edtavServiciosnombre1_Visible = 0;
         AssignProp("", false, edtavServiciosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServiciosnombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
         {
            edtavPostulacionesproveedornombre1_Visible = 1;
            AssignProp("", false, edtavPostulacionesproveedornombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedornombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 )
         {
            edtavPostulacionesproveedorid1_Visible = 1;
            AssignProp("", false, edtavPostulacionesproveedorid1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedorid1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
         {
            edtavServiciosnombre1_Visible = 1;
            AssignProp("", false, edtavServiciosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServiciosnombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavPostulacionesproveedornombre2_Visible = 0;
         AssignProp("", false, edtavPostulacionesproveedornombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedornombre2_Visible), 5, 0), true);
         edtavPostulacionesproveedorid2_Visible = 0;
         AssignProp("", false, edtavPostulacionesproveedorid2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedorid2_Visible), 5, 0), true);
         edtavServiciosnombre2_Visible = 0;
         AssignProp("", false, edtavServiciosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServiciosnombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
         {
            edtavPostulacionesproveedornombre2_Visible = 1;
            AssignProp("", false, edtavPostulacionesproveedornombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedornombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 )
         {
            edtavPostulacionesproveedorid2_Visible = 1;
            AssignProp("", false, edtavPostulacionesproveedorid2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedorid2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
         {
            edtavServiciosnombre2_Visible = 1;
            AssignProp("", false, edtavServiciosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServiciosnombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavPostulacionesproveedornombre3_Visible = 0;
         AssignProp("", false, edtavPostulacionesproveedornombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedornombre3_Visible), 5, 0), true);
         edtavPostulacionesproveedorid3_Visible = 0;
         AssignProp("", false, edtavPostulacionesproveedorid3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedorid3_Visible), 5, 0), true);
         edtavServiciosnombre3_Visible = 0;
         AssignProp("", false, edtavServiciosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServiciosnombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
         {
            edtavPostulacionesproveedornombre3_Visible = 1;
            AssignProp("", false, edtavPostulacionesproveedornombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedornombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 )
         {
            edtavPostulacionesproveedorid3_Visible = 1;
            AssignProp("", false, edtavPostulacionesproveedorid3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPostulacionesproveedorid3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
         {
            edtavServiciosnombre3_Visible = 1;
            AssignProp("", false, edtavServiciosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServiciosnombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "POSTULACIONESPROVEEDORNOMBRE";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV109PostulacionesProveedorNombre2 = "";
         AssignAttri("", false, "AV109PostulacionesProveedorNombre2", AV109PostulacionesProveedorNombre2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "POSTULACIONESPROVEEDORNOMBRE";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV110PostulacionesProveedorNombre3 = "";
         AssignAttri("", false, "AV110PostulacionesProveedorNombre3", AV110PostulacionesProveedorNombre3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "PostulacionesWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFPostulacionesId = 0;
         AssignAttri("", false, "AV44TFPostulacionesId", StringUtil.LTrimStr( (decimal)(AV44TFPostulacionesId), 18, 0));
         AV45TFPostulacionesId_To = 0;
         AssignAttri("", false, "AV45TFPostulacionesId_To", StringUtil.LTrimStr( (decimal)(AV45TFPostulacionesId_To), 18, 0));
         AV46TFServiciosId = 0;
         AssignAttri("", false, "AV46TFServiciosId", StringUtil.LTrimStr( (decimal)(AV46TFServiciosId), 18, 0));
         AV47TFServiciosId_To = 0;
         AssignAttri("", false, "AV47TFServiciosId_To", StringUtil.LTrimStr( (decimal)(AV47TFServiciosId_To), 18, 0));
         AV48TFServiciosNombre = "";
         AssignAttri("", false, "AV48TFServiciosNombre", AV48TFServiciosNombre);
         AV49TFServiciosNombre_Sel = "";
         AssignAttri("", false, "AV49TFServiciosNombre_Sel", AV49TFServiciosNombre_Sel);
         AV50TFPostulacionesProveedorId = 0;
         AssignAttri("", false, "AV50TFPostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV50TFPostulacionesProveedorId), 18, 0));
         AV51TFPostulacionesProveedorId_To = 0;
         AssignAttri("", false, "AV51TFPostulacionesProveedorId_To", StringUtil.LTrimStr( (decimal)(AV51TFPostulacionesProveedorId_To), 18, 0));
         AV103TFPostulacionesProveedorNombre = "";
         AssignAttri("", false, "AV103TFPostulacionesProveedorNombre", AV103TFPostulacionesProveedorNombre);
         AV104TFPostulacionesProveedorNombre_Sel = "";
         AssignAttri("", false, "AV104TFPostulacionesProveedorNombre_Sel", AV104TFPostulacionesProveedorNombre_Sel);
         AV52TFPostulacionesPrecio = 0;
         AssignAttri("", false, "AV52TFPostulacionesPrecio", StringUtil.LTrimStr( AV52TFPostulacionesPrecio, 18, 2));
         AV53TFPostulacionesPrecio_To = 0;
         AssignAttri("", false, "AV53TFPostulacionesPrecio_To", StringUtil.LTrimStr( AV53TFPostulacionesPrecio_To, 18, 2));
         AV105TFPostulacionesMultimediaSerial = 0;
         AssignAttri("", false, "AV105TFPostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(AV105TFPostulacionesMultimediaSerial), 4, 0));
         AV106TFPostulacionesMultimediaSerial_To = 0;
         AssignAttri("", false, "AV106TFPostulacionesMultimediaSerial_To", StringUtil.LTrimStr( (decimal)(AV106TFPostulacionesMultimediaSerial_To), 4, 0));
         AV111TFPostulacionesSolicitudesId = 0;
         AssignAttri("", false, "AV111TFPostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV111TFPostulacionesSolicitudesId), 18, 0));
         AV112TFPostulacionesSolicitudesId_To = 0;
         AssignAttri("", false, "AV112TFPostulacionesSolicitudesId_To", StringUtil.LTrimStr( (decimal)(AV112TFPostulacionesSolicitudesId_To), 18, 0));
         AV54TFPostulacionesDescripcion = "";
         AssignAttri("", false, "AV54TFPostulacionesDescripcion", AV54TFPostulacionesDescripcion);
         AV55TFPostulacionesDescripcion_Sel = "";
         AssignAttri("", false, "AV55TFPostulacionesDescripcion_Sel", AV55TFPostulacionesDescripcion_Sel);
         AV56TFPostulacionesReqSuministros_Sel = 0;
         AssignAttri("", false, "AV56TFPostulacionesReqSuministros_Sel", StringUtil.Str( (decimal)(AV56TFPostulacionesReqSuministros_Sel), 1, 0));
         AV57TFPostulacionesSuministrosDescripcion = "";
         AssignAttri("", false, "AV57TFPostulacionesSuministrosDescripcion", AV57TFPostulacionesSuministrosDescripcion);
         AV58TFPostulacionesSuministrosDescripcion_Sel = "";
         AssignAttri("", false, "AV58TFPostulacionesSuministrosDescripcion_Sel", AV58TFPostulacionesSuministrosDescripcion_Sel);
         AV59TFPostulacionesFechaTrabajo = DateTime.MinValue;
         AssignAttri("", false, "AV59TFPostulacionesFechaTrabajo", context.localUtil.Format(AV59TFPostulacionesFechaTrabajo, "99/99/99"));
         AV60TFPostulacionesFechaTrabajo_To = DateTime.MinValue;
         AssignAttri("", false, "AV60TFPostulacionesFechaTrabajo_To", context.localUtil.Format(AV60TFPostulacionesFechaTrabajo_To, "99/99/99"));
         AV64TFPostulacionesFechaCierre = DateTime.MinValue;
         AssignAttri("", false, "AV64TFPostulacionesFechaCierre", context.localUtil.Format(AV64TFPostulacionesFechaCierre, "99/99/99"));
         AV65TFPostulacionesFechaCierre_To = DateTime.MinValue;
         AssignAttri("", false, "AV65TFPostulacionesFechaCierre_To", context.localUtil.Format(AV65TFPostulacionesFechaCierre_To, "99/99/99"));
         AV69TFPostulacionesHoraCierre = "";
         AssignAttri("", false, "AV69TFPostulacionesHoraCierre", AV69TFPostulacionesHoraCierre);
         AV70TFPostulacionesHoraCierre_Sel = "";
         AssignAttri("", false, "AV70TFPostulacionesHoraCierre_Sel", AV70TFPostulacionesHoraCierre_Sel);
         AV71TFPostulacionesTipoFecha = "";
         AssignAttri("", false, "AV71TFPostulacionesTipoFecha", AV71TFPostulacionesTipoFecha);
         AV122TFPostulacionesTipoFecha_Sel = "";
         AssignAttri("", false, "AV122TFPostulacionesTipoFecha_Sel", AV122TFPostulacionesTipoFecha_Sel);
         AV73TFPostulacionesRgoHoraservicio = "";
         AssignAttri("", false, "AV73TFPostulacionesRgoHoraservicio", AV73TFPostulacionesRgoHoraservicio);
         AV74TFPostulacionesRgoHoraservicio_Sel = "";
         AssignAttri("", false, "AV74TFPostulacionesRgoHoraservicio_Sel", AV74TFPostulacionesRgoHoraservicio_Sel);
         AV75TFPostulacionesApellidoNombre = "";
         AssignAttri("", false, "AV75TFPostulacionesApellidoNombre", AV75TFPostulacionesApellidoNombre);
         AV76TFPostulacionesApellidoNombre_Sel = "";
         AssignAttri("", false, "AV76TFPostulacionesApellidoNombre_Sel", AV76TFPostulacionesApellidoNombre_Sel);
         AV77TFPostulacionesMail = "";
         AssignAttri("", false, "AV77TFPostulacionesMail", AV77TFPostulacionesMail);
         AV78TFPostulacionesMail_Sel = "";
         AssignAttri("", false, "AV78TFPostulacionesMail_Sel", AV78TFPostulacionesMail_Sel);
         AV79TFPostulacionesTelefono = "";
         AssignAttri("", false, "AV79TFPostulacionesTelefono", AV79TFPostulacionesTelefono);
         AV80TFPostulacionesTelefono_Sel = "";
         AssignAttri("", false, "AV80TFPostulacionesTelefono_Sel", AV80TFPostulacionesTelefono_Sel);
         AV81TFPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV81TFPostulacionesFechaAlta", context.localUtil.TToC( AV81TFPostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV82TFPostulacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV82TFPostulacionesFechaAlta_To", context.localUtil.TToC( AV82TFPostulacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV87TFPostulacionesEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV88TFPostulacionesSecUserId = 0;
         AssignAttri("", false, "AV88TFPostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(AV88TFPostulacionesSecUserId), 18, 0));
         AV89TFPostulacionesSecUserId_To = 0;
         AssignAttri("", false, "AV89TFPostulacionesSecUserId_To", StringUtil.LTrimStr( (decimal)(AV89TFPostulacionesSecUserId_To), 18, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "POSTULACIONESPROVEEDORNOMBRE";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV108PostulacionesProveedorNombre1 = "";
         AssignAttri("", false, "AV108PostulacionesProveedorNombre1", AV108PostulacionesProveedorNombre1);
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
         GXEncryptionTmp = "postulacionesview.aspx"+UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("postulacionesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0));
         CallWebObject(formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0));
         CallWebObject(formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV123Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV123Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV123Pgmname+"GridState"), null, "", "");
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
         AV184GXV1 = 1;
         while ( AV184GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV184GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV44TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFPostulacionesId", StringUtil.LTrimStr( (decimal)(AV44TFPostulacionesId), 18, 0));
               AV45TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFPostulacionesId_To", StringUtil.LTrimStr( (decimal)(AV45TFPostulacionesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSERVICIOSID") == 0 )
            {
               AV46TFServiciosId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFServiciosId", StringUtil.LTrimStr( (decimal)(AV46TFServiciosId), 18, 0));
               AV47TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFServiciosId_To", StringUtil.LTrimStr( (decimal)(AV47TFServiciosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE") == 0 )
            {
               AV48TFServiciosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFServiciosNombre", AV48TFServiciosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE_SEL") == 0 )
            {
               AV49TFServiciosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFServiciosNombre_Sel", AV49TFServiciosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORID") == 0 )
            {
               AV50TFPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFPostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(AV50TFPostulacionesProveedorId), 18, 0));
               AV51TFPostulacionesProveedorId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFPostulacionesProveedorId_To", StringUtil.LTrimStr( (decimal)(AV51TFPostulacionesProveedorId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV103TFPostulacionesProveedorNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV103TFPostulacionesProveedorNombre", AV103TFPostulacionesProveedorNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV104TFPostulacionesProveedorNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV104TFPostulacionesProveedorNombre_Sel", AV104TFPostulacionesProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPRECIO") == 0 )
            {
               AV52TFPostulacionesPrecio = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV52TFPostulacionesPrecio", StringUtil.LTrimStr( AV52TFPostulacionesPrecio, 18, 2));
               AV53TFPostulacionesPrecio_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV53TFPostulacionesPrecio_To", StringUtil.LTrimStr( AV53TFPostulacionesPrecio_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMULTIMEDIASERIAL") == 0 )
            {
               AV105TFPostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV105TFPostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(AV105TFPostulacionesMultimediaSerial), 4, 0));
               AV106TFPostulacionesMultimediaSerial_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV106TFPostulacionesMultimediaSerial_To", StringUtil.LTrimStr( (decimal)(AV106TFPostulacionesMultimediaSerial_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSOLICITUDESID") == 0 )
            {
               AV111TFPostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV111TFPostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV111TFPostulacionesSolicitudesId), 18, 0));
               AV112TFPostulacionesSolicitudesId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV112TFPostulacionesSolicitudesId_To", StringUtil.LTrimStr( (decimal)(AV112TFPostulacionesSolicitudesId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION") == 0 )
            {
               AV54TFPostulacionesDescripcion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFPostulacionesDescripcion", AV54TFPostulacionesDescripcion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION_SEL") == 0 )
            {
               AV55TFPostulacionesDescripcion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFPostulacionesDescripcion_Sel", AV55TFPostulacionesDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESREQSUMINISTROS_SEL") == 0 )
            {
               AV56TFPostulacionesReqSuministros_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFPostulacionesReqSuministros_Sel", StringUtil.Str( (decimal)(AV56TFPostulacionesReqSuministros_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION") == 0 )
            {
               AV57TFPostulacionesSuministrosDescripcion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFPostulacionesSuministrosDescripcion", AV57TFPostulacionesSuministrosDescripcion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL") == 0 )
            {
               AV58TFPostulacionesSuministrosDescripcion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFPostulacionesSuministrosDescripcion_Sel", AV58TFPostulacionesSuministrosDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHATRABAJO") == 0 )
            {
               AV59TFPostulacionesFechaTrabajo = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV59TFPostulacionesFechaTrabajo", context.localUtil.Format(AV59TFPostulacionesFechaTrabajo, "99/99/99"));
               AV60TFPostulacionesFechaTrabajo_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV60TFPostulacionesFechaTrabajo_To", context.localUtil.Format(AV60TFPostulacionesFechaTrabajo_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHACIERRE") == 0 )
            {
               AV64TFPostulacionesFechaCierre = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFPostulacionesFechaCierre", context.localUtil.Format(AV64TFPostulacionesFechaCierre, "99/99/99"));
               AV65TFPostulacionesFechaCierre_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV65TFPostulacionesFechaCierre_To", context.localUtil.Format(AV65TFPostulacionesFechaCierre_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE") == 0 )
            {
               AV69TFPostulacionesHoraCierre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFPostulacionesHoraCierre", AV69TFPostulacionesHoraCierre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE_SEL") == 0 )
            {
               AV70TFPostulacionesHoraCierre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFPostulacionesHoraCierre_Sel", AV70TFPostulacionesHoraCierre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA") == 0 )
            {
               AV71TFPostulacionesTipoFecha = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFPostulacionesTipoFecha", AV71TFPostulacionesTipoFecha);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA_SEL") == 0 )
            {
               AV122TFPostulacionesTipoFecha_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV122TFPostulacionesTipoFecha_Sel", AV122TFPostulacionesTipoFecha_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO") == 0 )
            {
               AV73TFPostulacionesRgoHoraservicio = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFPostulacionesRgoHoraservicio", AV73TFPostulacionesRgoHoraservicio);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO_SEL") == 0 )
            {
               AV74TFPostulacionesRgoHoraservicio_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFPostulacionesRgoHoraservicio_Sel", AV74TFPostulacionesRgoHoraservicio_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE") == 0 )
            {
               AV75TFPostulacionesApellidoNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFPostulacionesApellidoNombre", AV75TFPostulacionesApellidoNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE_SEL") == 0 )
            {
               AV76TFPostulacionesApellidoNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFPostulacionesApellidoNombre_Sel", AV76TFPostulacionesApellidoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL") == 0 )
            {
               AV77TFPostulacionesMail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFPostulacionesMail", AV77TFPostulacionesMail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL_SEL") == 0 )
            {
               AV78TFPostulacionesMail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFPostulacionesMail_Sel", AV78TFPostulacionesMail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO") == 0 )
            {
               AV79TFPostulacionesTelefono = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFPostulacionesTelefono", AV79TFPostulacionesTelefono);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO_SEL") == 0 )
            {
               AV80TFPostulacionesTelefono_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFPostulacionesTelefono_Sel", AV80TFPostulacionesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHAALTA") == 0 )
            {
               AV81TFPostulacionesFechaAlta = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV81TFPostulacionesFechaAlta", context.localUtil.TToC( AV81TFPostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV82TFPostulacionesFechaAlta_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV82TFPostulacionesFechaAlta_To", context.localUtil.TToC( AV82TFPostulacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV83DDO_PostulacionesFechaAltaAuxDate = DateTimeUtil.ResetTime(AV81TFPostulacionesFechaAlta);
               AssignAttri("", false, "AV83DDO_PostulacionesFechaAltaAuxDate", context.localUtil.Format(AV83DDO_PostulacionesFechaAltaAuxDate, "99/99/99"));
               AV84DDO_PostulacionesFechaAltaAuxDateTo = DateTimeUtil.ResetTime(AV82TFPostulacionesFechaAlta_To);
               AssignAttri("", false, "AV84DDO_PostulacionesFechaAltaAuxDateTo", context.localUtil.Format(AV84DDO_PostulacionesFechaAltaAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESESTADO_SEL") == 0 )
            {
               AV86TFPostulacionesEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV86TFPostulacionesEstado_SelsJson", AV86TFPostulacionesEstado_SelsJson);
               AV87TFPostulacionesEstado_Sels.FromJSonString(AV86TFPostulacionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSECUSERID") == 0 )
            {
               AV88TFPostulacionesSecUserId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV88TFPostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(AV88TFPostulacionesSecUserId), 18, 0));
               AV89TFPostulacionesSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV89TFPostulacionesSecUserId_To", StringUtil.LTrimStr( (decimal)(AV89TFPostulacionesSecUserId_To), 18, 0));
            }
            AV184GXV1 = (int)(AV184GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFServiciosNombre_Sel)),  AV49TFServiciosNombre_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV104TFPostulacionesProveedorNombre_Sel)),  AV104TFPostulacionesProveedorNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPostulacionesDescripcion_Sel)),  AV55TFPostulacionesDescripcion_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFPostulacionesSuministrosDescripcion_Sel)),  AV58TFPostulacionesSuministrosDescripcion_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV70TFPostulacionesHoraCierre_Sel)),  AV70TFPostulacionesHoraCierre_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV122TFPostulacionesTipoFecha_Sel)),  AV122TFPostulacionesTipoFecha_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPostulacionesRgoHoraservicio_Sel)),  AV74TFPostulacionesRgoHoraservicio_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFPostulacionesApellidoNombre_Sel)),  AV76TFPostulacionesApellidoNombre_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFPostulacionesMail_Sel)),  AV78TFPostulacionesMail_Sel, out  GXt_char12) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFPostulacionesTelefono_Sel)),  AV80TFPostulacionesTelefono_Sel, out  GXt_char13) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV87TFPostulacionesEstado_Sels.Count==0),  AV86TFPostulacionesEstado_SelsJson, out  GXt_char14) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char3+"||"+GXt_char5+"||||"+GXt_char6+"|"+((0==AV56TFPostulacionesReqSuministros_Sel) ? "" : StringUtil.Str( (decimal)(AV56TFPostulacionesReqSuministros_Sel), 1, 0))+"|"+GXt_char7+"|||"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12+"|"+GXt_char13+"||"+GXt_char14+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFServiciosNombre)),  AV48TFServiciosNombre, out  GXt_char14) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV103TFPostulacionesProveedorNombre)),  AV103TFPostulacionesProveedorNombre, out  GXt_char13) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFPostulacionesDescripcion)),  AV54TFPostulacionesDescripcion, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFPostulacionesSuministrosDescripcion)),  AV57TFPostulacionesSuministrosDescripcion, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFPostulacionesHoraCierre)),  AV69TFPostulacionesHoraCierre, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFPostulacionesTipoFecha)),  AV71TFPostulacionesTipoFecha, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFPostulacionesRgoHoraservicio)),  AV73TFPostulacionesRgoHoraservicio, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPostulacionesApellidoNombre)),  AV75TFPostulacionesApellidoNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFPostulacionesMail)),  AV77TFPostulacionesMail, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFPostulacionesTelefono)),  AV79TFPostulacionesTelefono, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = ((0==AV44TFPostulacionesId) ? "" : StringUtil.Str( (decimal)(AV44TFPostulacionesId), 18, 0))+"|"+((0==AV46TFServiciosId) ? "" : StringUtil.Str( (decimal)(AV46TFServiciosId), 18, 0))+"|"+GXt_char14+"|"+((0==AV50TFPostulacionesProveedorId) ? "" : StringUtil.Str( (decimal)(AV50TFPostulacionesProveedorId), 18, 0))+"|"+GXt_char13+"|"+((Convert.ToDecimal(0)==AV52TFPostulacionesPrecio) ? "" : StringUtil.Str( AV52TFPostulacionesPrecio, 18, 2))+"|"+((0==AV105TFPostulacionesMultimediaSerial) ? "" : StringUtil.Str( (decimal)(AV105TFPostulacionesMultimediaSerial), 4, 0))+"|"+((0==AV111TFPostulacionesSolicitudesId) ? "" : StringUtil.Str( (decimal)(AV111TFPostulacionesSolicitudesId), 18, 0))+"|"+GXt_char12+"||"+GXt_char11+"|"+((DateTime.MinValue==AV59TFPostulacionesFechaTrabajo) ? "" : context.localUtil.DToC( AV59TFPostulacionesFechaTrabajo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV64TFPostulacionesFechaCierre) ? "" : context.localUtil.DToC( AV64TFPostulacionesFechaCierre, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+((DateTime.MinValue==AV81TFPostulacionesFechaAlta) ? "" : context.localUtil.DToC( AV83DDO_PostulacionesFechaAltaAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||"+((0==AV88TFPostulacionesSecUserId) ? "" : StringUtil.Str( (decimal)(AV88TFPostulacionesSecUserId), 18, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV45TFPostulacionesId_To) ? "" : StringUtil.Str( (decimal)(AV45TFPostulacionesId_To), 18, 0))+"|"+((0==AV47TFServiciosId_To) ? "" : StringUtil.Str( (decimal)(AV47TFServiciosId_To), 18, 0))+"||"+((0==AV51TFPostulacionesProveedorId_To) ? "" : StringUtil.Str( (decimal)(AV51TFPostulacionesProveedorId_To), 18, 0))+"||"+((Convert.ToDecimal(0)==AV53TFPostulacionesPrecio_To) ? "" : StringUtil.Str( AV53TFPostulacionesPrecio_To, 18, 2))+"|"+((0==AV106TFPostulacionesMultimediaSerial_To) ? "" : StringUtil.Str( (decimal)(AV106TFPostulacionesMultimediaSerial_To), 4, 0))+"|"+((0==AV112TFPostulacionesSolicitudesId_To) ? "" : StringUtil.Str( (decimal)(AV112TFPostulacionesSolicitudesId_To), 18, 0))+"||||"+((DateTime.MinValue==AV60TFPostulacionesFechaTrabajo_To) ? "" : context.localUtil.DToC( AV60TFPostulacionesFechaTrabajo_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV65TFPostulacionesFechaCierre_To) ? "" : context.localUtil.DToC( AV65TFPostulacionesFechaCierre_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||||||"+((DateTime.MinValue==AV82TFPostulacionesFechaAlta_To) ? "" : context.localUtil.DToC( AV84DDO_PostulacionesFechaAltaAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||"+((0==AV89TFPostulacionesSecUserId_To) ? "" : StringUtil.Str( (decimal)(AV89TFPostulacionesSecUserId_To), 18, 0));
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV108PostulacionesProveedorNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV108PostulacionesProveedorNombre1", AV108PostulacionesProveedorNombre1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20PostulacionesProveedorId1 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20PostulacionesProveedorId1", StringUtil.LTrimStr( (decimal)(AV20PostulacionesProveedorId1), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21ServiciosNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ServiciosNombre1", AV21ServiciosNombre1);
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
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV109PostulacionesProveedorNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV109PostulacionesProveedorNombre2", AV109PostulacionesProveedorNombre2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25PostulacionesProveedorId2 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25PostulacionesProveedorId2", StringUtil.LTrimStr( (decimal)(AV25PostulacionesProveedorId2), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26ServiciosNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26ServiciosNombre2", AV26ServiciosNombre2);
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
                  AV27DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV110PostulacionesProveedorNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV110PostulacionesProveedorNombre3", AV110PostulacionesProveedorNombre3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30PostulacionesProveedorId3 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV30PostulacionesProveedorId3", StringUtil.LTrimStr( (decimal)(AV30PostulacionesProveedorId3), 18, 0));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31ServiciosNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31ServiciosNombre3", AV31ServiciosNombre3);
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
         if ( AV32DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV123Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESID",  context.GetMessage( "Id", ""),  !((0==AV44TFPostulacionesId)&&(0==AV45TFPostulacionesId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFPostulacionesId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFPostulacionesId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSERVICIOSID",  context.GetMessage( "Id", ""),  !((0==AV46TFServiciosId)&&(0==AV47TFServiciosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFServiciosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFServiciosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSERVICIOSNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFServiciosNombre)),  0,  AV48TFServiciosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFServiciosNombre_Sel)),  AV49TFServiciosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESPROVEEDORID",  context.GetMessage( "Proveedor Id", ""),  !((0==AV50TFPostulacionesProveedorId)&&(0==AV51TFPostulacionesProveedorId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFPostulacionesProveedorId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFPostulacionesProveedorId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESPROVEEDORNOMBRE",  context.GetMessage( "Proveedor Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV103TFPostulacionesProveedorNombre)),  0,  AV103TFPostulacionesProveedorNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV104TFPostulacionesProveedorNombre_Sel)),  AV104TFPostulacionesProveedorNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESPRECIO",  context.GetMessage( "Precio", ""),  !((Convert.ToDecimal(0)==AV52TFPostulacionesPrecio)&&(Convert.ToDecimal(0)==AV53TFPostulacionesPrecio_To)),  0,  StringUtil.Trim( StringUtil.Str( AV52TFPostulacionesPrecio, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV53TFPostulacionesPrecio_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESMULTIMEDIASERIAL",  context.GetMessage( "Multimedia Serial", ""),  !((0==AV105TFPostulacionesMultimediaSerial)&&(0==AV106TFPostulacionesMultimediaSerial_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV105TFPostulacionesMultimediaSerial), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV106TFPostulacionesMultimediaSerial_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESSOLICITUDESID",  context.GetMessage( "Solicitudes Id", ""),  !((0==AV111TFPostulacionesSolicitudesId)&&(0==AV112TFPostulacionesSolicitudesId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV111TFPostulacionesSolicitudesId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV112TFPostulacionesSolicitudesId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESDESCRIPCION",  context.GetMessage( "Descripcion", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFPostulacionesDescripcion)),  0,  AV54TFPostulacionesDescripcion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPostulacionesDescripcion_Sel)),  AV55TFPostulacionesDescripcion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESREQSUMINISTROS_SEL",  context.GetMessage( "Req Suministros", ""),  !(0==AV56TFPostulacionesReqSuministros_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV56TFPostulacionesReqSuministros_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESSUMINISTROSDESCRIPCION",  context.GetMessage( "Suministros Descripcion", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFPostulacionesSuministrosDescripcion)),  0,  AV57TFPostulacionesSuministrosDescripcion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFPostulacionesSuministrosDescripcion_Sel)),  AV58TFPostulacionesSuministrosDescripcion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESFECHATRABAJO",  context.GetMessage( "Fecha Trabajo", ""),  !((DateTime.MinValue==AV59TFPostulacionesFechaTrabajo)&&(DateTime.MinValue==AV60TFPostulacionesFechaTrabajo_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV59TFPostulacionesFechaTrabajo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV60TFPostulacionesFechaTrabajo_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESFECHACIERRE",  context.GetMessage( "Fecha Cierre", ""),  !((DateTime.MinValue==AV64TFPostulacionesFechaCierre)&&(DateTime.MinValue==AV65TFPostulacionesFechaCierre_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV64TFPostulacionesFechaCierre, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV65TFPostulacionesFechaCierre_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESHORACIERRE",  context.GetMessage( "Hora Cierre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFPostulacionesHoraCierre)),  0,  AV69TFPostulacionesHoraCierre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV70TFPostulacionesHoraCierre_Sel)),  AV70TFPostulacionesHoraCierre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESTIPOFECHA",  context.GetMessage( "Tipo Fecha", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFPostulacionesTipoFecha)),  0,  AV71TFPostulacionesTipoFecha,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV122TFPostulacionesTipoFecha_Sel)),  AV122TFPostulacionesTipoFecha_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESRGOHORASERVICIO",  context.GetMessage( "Rgo Horaservicio", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFPostulacionesRgoHoraservicio)),  0,  AV73TFPostulacionesRgoHoraservicio,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPostulacionesRgoHoraservicio_Sel)),  AV74TFPostulacionesRgoHoraservicio_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESAPELLIDONOMBRE",  context.GetMessage( "Apellido Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPostulacionesApellidoNombre)),  0,  AV75TFPostulacionesApellidoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFPostulacionesApellidoNombre_Sel)),  AV76TFPostulacionesApellidoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESMAIL",  context.GetMessage( "Mail", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFPostulacionesMail)),  0,  AV77TFPostulacionesMail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFPostulacionesMail_Sel)),  AV78TFPostulacionesMail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESTELEFONO",  context.GetMessage( "Telefono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFPostulacionesTelefono)),  0,  AV79TFPostulacionesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFPostulacionesTelefono_Sel)),  AV80TFPostulacionesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESFECHAALTA",  context.GetMessage( "Fecha", ""),  !((DateTime.MinValue==AV81TFPostulacionesFechaAlta)&&(DateTime.MinValue==AV82TFPostulacionesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV81TFPostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV82TFPostulacionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV87TFPostulacionesEstado_Sels.Count==0),  0,  AV87TFPostulacionesEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPOSTULACIONESSECUSERID",  context.GetMessage( "User Id", ""),  !((0==AV88TFPostulacionesSecUserId)&&(0==AV89TFPostulacionesSecUserId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV88TFPostulacionesSecUserId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV89TFPostulacionesSecUserId_To), 18, 0))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV123Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV108PostulacionesProveedorNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV108PostulacionesProveedorNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 ) && ! (0==AV20PostulacionesProveedorId1) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Id", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV20PostulacionesProveedorId1), 18, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ServiciosNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Servicios Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV21ServiciosNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV109PostulacionesProveedorNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV109PostulacionesProveedorNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 ) && ! (0==AV25PostulacionesProveedorId2) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Id", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV25PostulacionesProveedorId2), 18, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ServiciosNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Servicios Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV26ServiciosNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV110PostulacionesProveedorNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV110PostulacionesProveedorNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 ) && ! (0==AV30PostulacionesProveedorId3) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Id", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV30PostulacionesProveedorId3), 18, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ServiciosNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Servicios Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV31ServiciosNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV123Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Postulaciones";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         new postulacioneswwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
         if ( StringUtil.StrCmp(AV34ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV34ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV35ErrorMessage);
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
         Innewwindow1_Target = formatLink("postulacioneswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_105_KI2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_PostulacionesWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_postulacionesproveedornombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostulacionesproveedornombre3_Internalname, context.GetMessage( "Postulaciones Proveedor Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostulacionesproveedornombre3_Internalname, StringUtil.RTrim( AV110PostulacionesProveedorNombre3), StringUtil.RTrim( context.localUtil.Format( AV110PostulacionesProveedorNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostulacionesproveedornombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPostulacionesproveedornombre3_Visible, edtavPostulacionesproveedornombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_postulacionesproveedorid3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostulacionesproveedorid3_Internalname, context.GetMessage( "Postulaciones Proveedor Id3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostulacionesproveedorid3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30PostulacionesProveedorId3), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPostulacionesproveedorid3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30PostulacionesProveedorId3), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30PostulacionesProveedorId3), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostulacionesproveedorid3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPostulacionesproveedorid3_Visible, edtavPostulacionesproveedorid3_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_serviciosnombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServiciosnombre3_Internalname, context.GetMessage( "Servicios Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServiciosnombre3_Internalname, StringUtil.RTrim( AV31ServiciosNombre3), StringUtil.RTrim( context.localUtil.Format( AV31ServiciosNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServiciosnombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavServiciosnombre3_Visible, edtavServiciosnombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_PostulacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_105_KI2e( true) ;
         }
         else
         {
            wb_table4_105_KI2e( false) ;
         }
      }

      protected void wb_table3_77_KI2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 0, "HLP_PostulacionesWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_postulacionesproveedornombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostulacionesproveedornombre2_Internalname, context.GetMessage( "Postulaciones Proveedor Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostulacionesproveedornombre2_Internalname, StringUtil.RTrim( AV109PostulacionesProveedorNombre2), StringUtil.RTrim( context.localUtil.Format( AV109PostulacionesProveedorNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostulacionesproveedornombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPostulacionesproveedornombre2_Visible, edtavPostulacionesproveedornombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_postulacionesproveedorid2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostulacionesproveedorid2_Internalname, context.GetMessage( "Postulaciones Proveedor Id2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostulacionesproveedorid2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25PostulacionesProveedorId2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPostulacionesproveedorid2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25PostulacionesProveedorId2), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV25PostulacionesProveedorId2), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostulacionesproveedorid2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPostulacionesproveedorid2_Visible, edtavPostulacionesproveedorid2_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_serviciosnombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServiciosnombre2_Internalname, context.GetMessage( "Servicios Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServiciosnombre2_Internalname, StringUtil.RTrim( AV26ServiciosNombre2), StringUtil.RTrim( context.localUtil.Format( AV26ServiciosNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServiciosnombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavServiciosnombre2_Visible, edtavServiciosnombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_PostulacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_PostulacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_77_KI2e( true) ;
         }
         else
         {
            wb_table3_77_KI2e( false) ;
         }
      }

      protected void wb_table2_49_KI2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_PostulacionesWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_postulacionesproveedornombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostulacionesproveedornombre1_Internalname, context.GetMessage( "Postulaciones Proveedor Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostulacionesproveedornombre1_Internalname, StringUtil.RTrim( AV108PostulacionesProveedorNombre1), StringUtil.RTrim( context.localUtil.Format( AV108PostulacionesProveedorNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostulacionesproveedornombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPostulacionesproveedornombre1_Visible, edtavPostulacionesproveedornombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_postulacionesproveedorid1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostulacionesproveedorid1_Internalname, context.GetMessage( "Postulaciones Proveedor Id1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostulacionesproveedorid1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20PostulacionesProveedorId1), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPostulacionesproveedorid1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20PostulacionesProveedorId1), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20PostulacionesProveedorId1), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostulacionesproveedorid1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPostulacionesproveedorid1_Visible, edtavPostulacionesproveedorid1_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_serviciosnombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServiciosnombre1_Internalname, context.GetMessage( "Servicios Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServiciosnombre1_Internalname, StringUtil.RTrim( AV21ServiciosNombre1), StringUtil.RTrim( context.localUtil.Format( AV21ServiciosNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServiciosnombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavServiciosnombre1_Visible, edtavServiciosnombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_PostulacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_PostulacionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_KI2e( true) ;
         }
         else
         {
            wb_table2_49_KI2e( false) ;
         }
      }

      protected void wb_table1_25_KI2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV41ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_KI2( true) ;
         }
         else
         {
            wb_table5_30_KI2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_KI2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_KI2e( true) ;
         }
         else
         {
            wb_table1_25_KI2e( false) ;
         }
      }

      protected void wb_table5_30_KI2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PostulacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_KI2e( true) ;
         }
         else
         {
            wb_table5_30_KI2e( false) ;
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
         PAKI2( ) ;
         WSKI2( ) ;
         WEKI2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932019457", true, true, false);
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
         context.AddJavascriptSource("postulacionesww.js", "?2026932019458", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_129_idx;
         edtServiciosId_Internalname = "SERVICIOSID_"+sGXsfl_129_idx;
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE_"+sGXsfl_129_idx;
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID_"+sGXsfl_129_idx;
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE_"+sGXsfl_129_idx;
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO_"+sGXsfl_129_idx;
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL_"+sGXsfl_129_idx;
         edtPostulacionesSolicitudesId_Internalname = "POSTULACIONESSOLICITUDESID_"+sGXsfl_129_idx;
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION_"+sGXsfl_129_idx;
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS_"+sGXsfl_129_idx;
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI_"+sGXsfl_129_idx;
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO_"+sGXsfl_129_idx;
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE_"+sGXsfl_129_idx;
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE_"+sGXsfl_129_idx;
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA_"+sGXsfl_129_idx;
         edtPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO_"+sGXsfl_129_idx;
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE_"+sGXsfl_129_idx;
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL_"+sGXsfl_129_idx;
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO_"+sGXsfl_129_idx;
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA_"+sGXsfl_129_idx;
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO_"+sGXsfl_129_idx;
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_fel_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_129_fel_idx;
         edtServiciosId_Internalname = "SERVICIOSID_"+sGXsfl_129_fel_idx;
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE_"+sGXsfl_129_fel_idx;
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID_"+sGXsfl_129_fel_idx;
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE_"+sGXsfl_129_fel_idx;
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO_"+sGXsfl_129_fel_idx;
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL_"+sGXsfl_129_fel_idx;
         edtPostulacionesSolicitudesId_Internalname = "POSTULACIONESSOLICITUDESID_"+sGXsfl_129_fel_idx;
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION_"+sGXsfl_129_fel_idx;
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS_"+sGXsfl_129_fel_idx;
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI_"+sGXsfl_129_fel_idx;
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO_"+sGXsfl_129_fel_idx;
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE_"+sGXsfl_129_fel_idx;
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE_"+sGXsfl_129_fel_idx;
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA_"+sGXsfl_129_fel_idx;
         edtPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO_"+sGXsfl_129_fel_idx;
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE_"+sGXsfl_129_fel_idx;
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL_"+sGXsfl_129_fel_idx;
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO_"+sGXsfl_129_fel_idx;
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA_"+sGXsfl_129_fel_idx;
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO_"+sGXsfl_129_fel_idx;
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID_"+sGXsfl_129_fel_idx;
      }

      protected void sendrow_1292( )
      {
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         WBKI0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_129_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_129_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_129_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_129_idx + "',129)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV95GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV95GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV95GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV95GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_129_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV95GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtServiciosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServiciosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtServiciosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtServiciosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtServiciosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServiciosNombre_Internalname,StringUtil.RTrim( A943ServiciosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtServiciosNombre_Link,(string)"",(string)"",(string)"",(string)edtServiciosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtServiciosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesProveedorId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesProveedorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesProveedorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPostulacionesProveedorId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesProveedorNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesProveedorNombre_Internalname,StringUtil.RTrim( A969PostulacionesProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtPostulacionesProveedorNombre_Link,(string)"",(string)"",(string)"",(string)edtPostulacionesProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesProveedorNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesPrecio_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A946PostulacionesPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesPrecio_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesMultimediaSerial_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesMultimediaSerial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A961PostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A961PostulacionesMultimediaSerial), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesMultimediaSerial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPostulacionesMultimediaSerial_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesSolicitudesId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesSolicitudesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A970PostulacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A970PostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesSolicitudesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtPostulacionesSolicitudesId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesDescripcion_Internalname,StringUtil.RTrim( A936PostulacionesDescripcion),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkPostulacionesReqSuministros.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "POSTULACIONESREQSUMINISTROS_" + sGXsfl_129_idx;
            chkPostulacionesReqSuministros.Name = GXCCtl;
            chkPostulacionesReqSuministros.WebTags = "";
            chkPostulacionesReqSuministros.Caption = "";
            AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, !bGXsfl_129_Refreshing);
            chkPostulacionesReqSuministros.CheckedValue = "false";
            A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPostulacionesReqSuministros_Internalname,StringUtil.BoolToStr( A937PostulacionesReqSuministros),(string)"",(string)"",chkPostulacionesReqSuministros.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesSuministrosDescri_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesSuministrosDescri_Internalname,StringUtil.RTrim( A938PostulacionesSuministrosDescri),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesSuministrosDescri_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesSuministrosDescri_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesFechaTrabajo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaTrabajo_Internalname,context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"),context.localUtil.Format( A947PostulacionesFechaTrabajo, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaTrabajo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesFechaTrabajo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesFechaCierre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaCierre_Internalname,context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"),context.localUtil.Format( A939PostulacionesFechaCierre, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaCierre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesFechaCierre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesHoraCierre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesHoraCierre_Internalname,(string)A940PostulacionesHoraCierre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesHoraCierre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesHoraCierre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesTipoFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesTipoFecha_Internalname,(string)A941PostulacionesTipoFecha,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesTipoFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesTipoFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesRgoHoraservicio_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesRgoHoraservicio_Internalname,StringUtil.RTrim( A949PostulacionesRgoHoraservicio),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesRgoHoraservicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesRgoHoraservicio_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesApellidoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesApellidoNombre_Internalname,StringUtil.RTrim( A950PostulacionesApellidoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesApellidoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesApellidoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesMail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesMail_Internalname,(string)A951PostulacionesMail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A951PostulacionesMail,(string)"",(string)"",(string)"",(string)edtPostulacionesMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesMail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPostulacionesTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A952PostulacionesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesTelefono_Internalname,StringUtil.RTrim( A952PostulacionesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtPostulacionesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesTelefono_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaAlta_Internalname,context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A425PostulacionesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbPostulacionesEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbPostulacionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONESESTADO_" + sGXsfl_129_idx;
               cmbPostulacionesEstado.Name = GXCCtl;
               cmbPostulacionesEstado.WebTags = "";
               cmbPostulacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbPostulacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbPostulacionesEstado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
               if ( cmbPostulacionesEstado.ItemCount > 0 )
               {
                  A424PostulacionesEstado = cmbPostulacionesEstado.getValidValue(A424PostulacionesEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionesEstado,(string)cmbPostulacionesEstado_Internalname,StringUtil.RTrim( A424PostulacionesEstado),(short)1,(string)cmbPostulacionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbPostulacionesEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionesEstado.CurrentValue = StringUtil.RTrim( A424PostulacionesEstado);
            AssignProp("", false, cmbPostulacionesEstado_Internalname, "Values", (string)(cmbPostulacionesEstado.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPostulacionesSecUserId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A948PostulacionesSecUserId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A948PostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPostulacionesSecUserId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesKI2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_129_idx = ((subGrid_Islastpage==1)&&(nGXsfl_129_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
         }
         /* End function sendrow_1292 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("POSTULACIONESPROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
         cmbavDynamicfiltersselector1.addItem("POSTULACIONESPROVEEDORID", context.GetMessage( "Proveedor Id", ""), 0);
         cmbavDynamicfiltersselector1.addItem("SERVICIOSNOMBRE", context.GetMessage( "Servicios Nombre", ""), 0);
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
         cmbavDynamicfiltersselector2.addItem("POSTULACIONESPROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
         cmbavDynamicfiltersselector2.addItem("POSTULACIONESPROVEEDORID", context.GetMessage( "Proveedor Id", ""), 0);
         cmbavDynamicfiltersselector2.addItem("SERVICIOSNOMBRE", context.GetMessage( "Servicios Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("POSTULACIONESPROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
         cmbavDynamicfiltersselector3.addItem("POSTULACIONESPROVEEDORID", context.GetMessage( "Proveedor Id", ""), 0);
         cmbavDynamicfiltersselector3.addItem("SERVICIOSNOMBRE", context.GetMessage( "Servicios Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV95GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV95GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV95GridActions), 4, 0));
         }
         GXCCtl = "POSTULACIONESREQSUMINISTROS_" + sGXsfl_129_idx;
         chkPostulacionesReqSuministros.Name = GXCCtl;
         chkPostulacionesReqSuministros.WebTags = "";
         chkPostulacionesReqSuministros.Caption = "";
         AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, !bGXsfl_129_Refreshing);
         chkPostulacionesReqSuministros.CheckedValue = "false";
         A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
         GXCCtl = "POSTULACIONESESTADO_" + sGXsfl_129_idx;
         cmbPostulacionesEstado.Name = GXCCtl;
         cmbPostulacionesEstado.WebTags = "";
         cmbPostulacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPostulacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPostulacionesEstado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
         if ( cmbPostulacionesEstado.ItemCount > 0 )
         {
            A424PostulacionesEstado = cmbPostulacionesEstado.getValidValue(A424PostulacionesEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl129( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"129\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtServiciosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtServiciosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesProveedorId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesProveedorNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesPrecio_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesMultimediaSerial_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Multimedia Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesSolicitudesId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Descripcion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkPostulacionesReqSuministros.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Req Suministros", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesSuministrosDescri_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Suministros Descripcion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesFechaTrabajo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Trabajo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesFechaCierre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Cierre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesHoraCierre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora Cierre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesTipoFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Fecha", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesRgoHoraservicio_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rgo Horaservicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesApellidoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Apellido Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesMail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mail", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Telefono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbPostulacionesEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPostulacionesSecUserId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "User Id", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV95GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtServiciosId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A943ServiciosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtServiciosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtServiciosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesProveedorId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A969PostulacionesProveedorNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtPostulacionesProveedorNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesProveedorNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A946PostulacionesPrecio, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesPrecio_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A961PostulacionesMultimediaSerial), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesMultimediaSerial_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A970PostulacionesSolicitudesId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesSolicitudesId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A936PostulacionesDescripcion)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A937PostulacionesReqSuministros)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkPostulacionesReqSuministros.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A938PostulacionesSuministrosDescri)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesSuministrosDescri_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesFechaTrabajo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesFechaCierre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A940PostulacionesHoraCierre));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesHoraCierre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A941PostulacionesTipoFecha));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesTipoFecha_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A949PostulacionesRgoHoraservicio)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesRgoHoraservicio_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A950PostulacionesApellidoNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesApellidoNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A951PostulacionesMail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesMail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A952PostulacionesTelefono)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesTelefono_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A424PostulacionesEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPostulacionesEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A948PostulacionesSecUserId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPostulacionesSecUserId_Visible), 5, 0, ".", "")));
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
         edtavPostulacionesproveedornombre1_Internalname = "vPOSTULACIONESPROVEEDORNOMBRE1";
         cellFilter_postulacionesproveedornombre1_cell_Internalname = "FILTER_POSTULACIONESPROVEEDORNOMBRE1_CELL";
         edtavPostulacionesproveedorid1_Internalname = "vPOSTULACIONESPROVEEDORID1";
         cellFilter_postulacionesproveedorid1_cell_Internalname = "FILTER_POSTULACIONESPROVEEDORID1_CELL";
         edtavServiciosnombre1_Internalname = "vSERVICIOSNOMBRE1";
         cellFilter_serviciosnombre1_cell_Internalname = "FILTER_SERVICIOSNOMBRE1_CELL";
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
         edtavPostulacionesproveedornombre2_Internalname = "vPOSTULACIONESPROVEEDORNOMBRE2";
         cellFilter_postulacionesproveedornombre2_cell_Internalname = "FILTER_POSTULACIONESPROVEEDORNOMBRE2_CELL";
         edtavPostulacionesproveedorid2_Internalname = "vPOSTULACIONESPROVEEDORID2";
         cellFilter_postulacionesproveedorid2_cell_Internalname = "FILTER_POSTULACIONESPROVEEDORID2_CELL";
         edtavServiciosnombre2_Internalname = "vSERVICIOSNOMBRE2";
         cellFilter_serviciosnombre2_cell_Internalname = "FILTER_SERVICIOSNOMBRE2_CELL";
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
         edtavPostulacionesproveedornombre3_Internalname = "vPOSTULACIONESPROVEEDORNOMBRE3";
         cellFilter_postulacionesproveedornombre3_cell_Internalname = "FILTER_POSTULACIONESPROVEEDORNOMBRE3_CELL";
         edtavPostulacionesproveedorid3_Internalname = "vPOSTULACIONESPROVEEDORID3";
         cellFilter_postulacionesproveedorid3_cell_Internalname = "FILTER_POSTULACIONESPROVEEDORID3_CELL";
         edtavServiciosnombre3_Internalname = "vSERVICIOSNOMBRE3";
         cellFilter_serviciosnombre3_cell_Internalname = "FILTER_SERVICIOSNOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtPostulacionesId_Internalname = "POSTULACIONESID";
         edtServiciosId_Internalname = "SERVICIOSID";
         edtServiciosNombre_Internalname = "SERVICIOSNOMBRE";
         edtPostulacionesProveedorId_Internalname = "POSTULACIONESPROVEEDORID";
         edtPostulacionesProveedorNombre_Internalname = "POSTULACIONESPROVEEDORNOMBRE";
         edtPostulacionesPrecio_Internalname = "POSTULACIONESPRECIO";
         edtPostulacionesMultimediaSerial_Internalname = "POSTULACIONESMULTIMEDIASERIAL";
         edtPostulacionesSolicitudesId_Internalname = "POSTULACIONESSOLICITUDESID";
         edtPostulacionesDescripcion_Internalname = "POSTULACIONESDESCRIPCION";
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS";
         edtPostulacionesSuministrosDescri_Internalname = "POSTULACIONESSUMINISTROSDESCRI";
         edtPostulacionesFechaTrabajo_Internalname = "POSTULACIONESFECHATRABAJO";
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE";
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE";
         edtPostulacionesTipoFecha_Internalname = "POSTULACIONESTIPOFECHA";
         edtPostulacionesRgoHoraservicio_Internalname = "POSTULACIONESRGOHORASERVICIO";
         edtPostulacionesApellidoNombre_Internalname = "POSTULACIONESAPELLIDONOMBRE";
         edtPostulacionesMail_Internalname = "POSTULACIONESMAIL";
         edtPostulacionesTelefono_Internalname = "POSTULACIONESTELEFONO";
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA";
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO";
         edtPostulacionesSecUserId_Internalname = "POSTULACIONESSECUSERID";
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
         edtavDdo_postulacionesfechatrabajoauxdatetext_Internalname = "vDDO_POSTULACIONESFECHATRABAJOAUXDATETEXT";
         Tfpostulacionesfechatrabajo_rangepicker_Internalname = "TFPOSTULACIONESFECHATRABAJO_RANGEPICKER";
         divDdo_postulacionesfechatrabajoauxdates_Internalname = "DDO_POSTULACIONESFECHATRABAJOAUXDATES";
         edtavDdo_postulacionesfechacierreauxdatetext_Internalname = "vDDO_POSTULACIONESFECHACIERREAUXDATETEXT";
         Tfpostulacionesfechacierre_rangepicker_Internalname = "TFPOSTULACIONESFECHACIERRE_RANGEPICKER";
         divDdo_postulacionesfechacierreauxdates_Internalname = "DDO_POSTULACIONESFECHACIERREAUXDATES";
         edtavDdo_postulacionesfechaaltaauxdatetext_Internalname = "vDDO_POSTULACIONESFECHAALTAAUXDATETEXT";
         Tfpostulacionesfechaalta_rangepicker_Internalname = "TFPOSTULACIONESFECHAALTA_RANGEPICKER";
         divDdo_postulacionesfechaaltaauxdates_Internalname = "DDO_POSTULACIONESFECHAALTAAUXDATES";
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
         edtPostulacionesSecUserId_Jsonclick = "";
         cmbPostulacionesEstado_Jsonclick = "";
         edtPostulacionesFechaAlta_Jsonclick = "";
         edtPostulacionesTelefono_Jsonclick = "";
         edtPostulacionesMail_Jsonclick = "";
         edtPostulacionesApellidoNombre_Jsonclick = "";
         edtPostulacionesRgoHoraservicio_Jsonclick = "";
         edtPostulacionesTipoFecha_Jsonclick = "";
         edtPostulacionesHoraCierre_Jsonclick = "";
         edtPostulacionesFechaCierre_Jsonclick = "";
         edtPostulacionesFechaTrabajo_Jsonclick = "";
         edtPostulacionesSuministrosDescri_Jsonclick = "";
         chkPostulacionesReqSuministros.Caption = "";
         edtPostulacionesDescripcion_Jsonclick = "";
         edtPostulacionesSolicitudesId_Jsonclick = "";
         edtPostulacionesMultimediaSerial_Jsonclick = "";
         edtPostulacionesPrecio_Jsonclick = "";
         edtPostulacionesProveedorNombre_Jsonclick = "";
         edtPostulacionesProveedorNombre_Link = "";
         edtPostulacionesProveedorId_Jsonclick = "";
         edtServiciosNombre_Jsonclick = "";
         edtServiciosNombre_Link = "";
         edtServiciosId_Jsonclick = "";
         edtPostulacionesId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavServiciosnombre1_Jsonclick = "";
         edtavServiciosnombre1_Enabled = 1;
         edtavPostulacionesproveedorid1_Jsonclick = "";
         edtavPostulacionesproveedorid1_Enabled = 1;
         edtavPostulacionesproveedornombre1_Jsonclick = "";
         edtavPostulacionesproveedornombre1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavServiciosnombre2_Jsonclick = "";
         edtavServiciosnombre2_Enabled = 1;
         edtavPostulacionesproveedorid2_Jsonclick = "";
         edtavPostulacionesproveedorid2_Enabled = 1;
         edtavPostulacionesproveedornombre2_Jsonclick = "";
         edtavPostulacionesproveedornombre2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavServiciosnombre3_Jsonclick = "";
         edtavServiciosnombre3_Enabled = 1;
         edtavPostulacionesproveedorid3_Jsonclick = "";
         edtavPostulacionesproveedorid3_Enabled = 1;
         edtavPostulacionesproveedornombre3_Jsonclick = "";
         edtavPostulacionesproveedornombre3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavServiciosnombre3_Visible = 1;
         edtavPostulacionesproveedorid3_Visible = 1;
         edtavPostulacionesproveedornombre3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavServiciosnombre2_Visible = 1;
         edtavPostulacionesproveedorid2_Visible = 1;
         edtavPostulacionesproveedornombre2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavServiciosnombre1_Visible = 1;
         edtavPostulacionesproveedorid1_Visible = 1;
         edtavPostulacionesproveedornombre1_Visible = 1;
         edtPostulacionesSecUserId_Visible = -1;
         cmbPostulacionesEstado.Visible = -1;
         edtPostulacionesFechaAlta_Visible = -1;
         edtPostulacionesTelefono_Visible = -1;
         edtPostulacionesMail_Visible = -1;
         edtPostulacionesApellidoNombre_Visible = -1;
         edtPostulacionesRgoHoraservicio_Visible = -1;
         edtPostulacionesTipoFecha_Visible = -1;
         edtPostulacionesHoraCierre_Visible = -1;
         edtPostulacionesFechaCierre_Visible = -1;
         edtPostulacionesFechaTrabajo_Visible = -1;
         edtPostulacionesSuministrosDescri_Visible = -1;
         chkPostulacionesReqSuministros.Visible = -1;
         edtPostulacionesDescripcion_Visible = -1;
         edtPostulacionesSolicitudesId_Visible = -1;
         edtPostulacionesMultimediaSerial_Visible = -1;
         edtPostulacionesPrecio_Visible = -1;
         edtPostulacionesProveedorNombre_Visible = -1;
         edtPostulacionesProveedorId_Visible = -1;
         edtServiciosNombre_Visible = -1;
         edtServiciosId_Visible = -1;
         edtPostulacionesId_Visible = -1;
         edtPostulacionesSecUserId_Enabled = 0;
         cmbPostulacionesEstado.Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         edtPostulacionesTelefono_Enabled = 0;
         edtPostulacionesMail_Enabled = 0;
         edtPostulacionesApellidoNombre_Enabled = 0;
         edtPostulacionesRgoHoraservicio_Enabled = 0;
         edtPostulacionesTipoFecha_Enabled = 0;
         edtPostulacionesHoraCierre_Enabled = 0;
         edtPostulacionesFechaCierre_Enabled = 0;
         edtPostulacionesFechaTrabajo_Enabled = 0;
         edtPostulacionesSuministrosDescri_Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         edtPostulacionesDescripcion_Enabled = 0;
         edtPostulacionesSolicitudesId_Enabled = 0;
         edtPostulacionesMultimediaSerial_Enabled = 0;
         edtPostulacionesPrecio_Enabled = 0;
         edtPostulacionesProveedorNombre_Enabled = 0;
         edtPostulacionesProveedorId_Enabled = 0;
         edtServiciosNombre_Enabled = 0;
         edtServiciosId_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_postulacionesfechaaltaauxdatetext_Jsonclick = "";
         edtavDdo_postulacionesfechacierreauxdatetext_Jsonclick = "";
         edtavDdo_postulacionesfechatrabajoauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;;;;;;;";
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
         Ddo_grid_Format = "18.0|18.0||18.0||-18.2|4.0|18.0||||||||||||||18.0";
         Ddo_grid_Datalistproc = "PostulacionesWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||||||1:WWP_TSChecked,2:WWP_TSUnChecked|||||||||||HAB:Habilitado,DES:Deshabilitado,GAN:Ganador|";
         Ddo_grid_Allowmultipleselection = "||||||||||||||||||||T|";
         Ddo_grid_Datalisttype = "||Dynamic||Dynamic||||Dynamic|FixedValues|Dynamic|||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||FixedValues|";
         Ddo_grid_Includedatalist = "||T||T||||T|T|T|||T|T|T|T|T|T||T|";
         Ddo_grid_Filterisrange = "T|T||T||T|T|T||||P|P|||||||P||T";
         Ddo_grid_Filtertype = "Numeric|Numeric|Character|Numeric|Character|Numeric|Numeric|Numeric|Character||Character|Date|Date|Character|Character|Character|Character|Character|Character|Date||Numeric";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T|T|T||T|T|T|T|T|T|T|T|T|T||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T||T|T|T|T|T|T|T|T|T|T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "3|4|5|2|1|6|7||8|9|10|11|12|13|14|15|16|17|18|19|20|21";
         Ddo_grid_Columnids = "1:PostulacionesId|2:ServiciosId|3:ServiciosNombre|4:PostulacionesProveedorId|5:PostulacionesProveedorNombre|6:PostulacionesPrecio|7:PostulacionesMultimediaSerial|8:PostulacionesSolicitudesId|9:PostulacionesDescripcion|10:PostulacionesReqSuministros|11:PostulacionesSuministrosDescripcion|12:PostulacionesFechaTrabajo|13:PostulacionesFechaCierre|14:PostulacionesHoraCierre|15:PostulacionesTipoFecha|16:PostulacionesRgoHoraservicio|17:PostulacionesApellidoNombre|18:PostulacionesMail|19:PostulacionesTelefono|20:PostulacionesFechaAlta|21:PostulacionesEstado|22:PostulacionesSecUserId";
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
         Form.Caption = context.GetMessage( " Postulaciones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV86TFPostulacionesEstado_SelsJson',fld:'vTFPOSTULACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E29KI2',iparms:[{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A942ServiciosId',fld:'SERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV95GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtServiciosNombre_Link',ctrl:'SERVICIOSNOMBRE',prop:'Link'},{av:'edtPostulacionesProveedorNombre_Link',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E22KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'edtavPostulacionesproveedornombre2_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedorid2_Visible',ctrl:'vPOSTULACIONESPROVEEDORID2',prop:'Visible'},{av:'edtavServiciosnombre2_Visible',ctrl:'vSERVICIOSNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedornombre3_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedorid3_Visible',ctrl:'vPOSTULACIONESPROVEEDORID3',prop:'Visible'},{av:'edtavServiciosnombre3_Visible',ctrl:'vSERVICIOSNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedornombre1_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedorid1_Visible',ctrl:'vPOSTULACIONESPROVEEDORID1',prop:'Visible'},{av:'edtavServiciosnombre1_Visible',ctrl:'vSERVICIOSNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E23KI2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'edtavPostulacionesproveedornombre1_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedorid1_Visible',ctrl:'vPOSTULACIONESPROVEEDORID1',prop:'Visible'},{av:'edtavServiciosnombre1_Visible',ctrl:'vSERVICIOSNOMBRE1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E24KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'edtavPostulacionesproveedornombre2_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedorid2_Visible',ctrl:'vPOSTULACIONESPROVEEDORID2',prop:'Visible'},{av:'edtavServiciosnombre2_Visible',ctrl:'vSERVICIOSNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedornombre3_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedorid3_Visible',ctrl:'vPOSTULACIONESPROVEEDORID3',prop:'Visible'},{av:'edtavServiciosnombre3_Visible',ctrl:'vSERVICIOSNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedornombre1_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedorid1_Visible',ctrl:'vPOSTULACIONESPROVEEDORID1',prop:'Visible'},{av:'edtavServiciosnombre1_Visible',ctrl:'vSERVICIOSNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E25KI2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'edtavPostulacionesproveedornombre2_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedorid2_Visible',ctrl:'vPOSTULACIONESPROVEEDORID2',prop:'Visible'},{av:'edtavServiciosnombre2_Visible',ctrl:'vSERVICIOSNOMBRE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'edtavPostulacionesproveedornombre2_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedorid2_Visible',ctrl:'vPOSTULACIONESPROVEEDORID2',prop:'Visible'},{av:'edtavServiciosnombre2_Visible',ctrl:'vSERVICIOSNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedornombre3_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedorid3_Visible',ctrl:'vPOSTULACIONESPROVEEDORID3',prop:'Visible'},{av:'edtavServiciosnombre3_Visible',ctrl:'vSERVICIOSNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedornombre1_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedorid1_Visible',ctrl:'vPOSTULACIONESPROVEEDORID1',prop:'Visible'},{av:'edtavServiciosnombre1_Visible',ctrl:'vSERVICIOSNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E26KI2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtavPostulacionesproveedornombre3_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedorid3_Visible',ctrl:'vPOSTULACIONESPROVEEDORID3',prop:'Visible'},{av:'edtavServiciosnombre3_Visible',ctrl:'vSERVICIOSNOMBRE3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11KI2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV86TFPostulacionesEstado_SelsJson',fld:'vTFPOSTULACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV83DDO_PostulacionesFechaAltaAuxDate',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV84DDO_PostulacionesFechaAltaAuxDateTo',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATETO',pic:'',type:'date'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV86TFPostulacionesEstado_SelsJson',fld:'vTFPOSTULACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV83DDO_PostulacionesFechaAltaAuxDate',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV84DDO_PostulacionesFechaAltaAuxDateTo',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATETO',pic:'',type:'date'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'edtavPostulacionesproveedornombre1_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedorid1_Visible',ctrl:'vPOSTULACIONESPROVEEDORID1',prop:'Visible'},{av:'edtavServiciosnombre1_Visible',ctrl:'vSERVICIOSNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedornombre2_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedorid2_Visible',ctrl:'vPOSTULACIONESPROVEEDORID2',prop:'Visible'},{av:'edtavServiciosnombre2_Visible',ctrl:'vSERVICIOSNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedornombre3_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedorid3_Visible',ctrl:'vPOSTULACIONESPROVEEDORID3',prop:'Visible'},{av:'edtavServiciosnombre3_Visible',ctrl:'vSERVICIOSNOMBRE3',prop:'Visible'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E30KI2',iparms:[{av:'cmbavGridactions'},{av:'AV95GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV95GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E21KI2',iparms:[{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14KI2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV86TFPostulacionesEstado_SelsJson',fld:'vTFPOSTULACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV83DDO_PostulacionesFechaAltaAuxDate',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV84DDO_PostulacionesFechaAltaAuxDateTo',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATETO',pic:'',type:'date'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV108PostulacionesProveedorNombre1',fld:'vPOSTULACIONESPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV20PostulacionesProveedorId1',fld:'vPOSTULACIONESPROVEEDORID1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ServiciosNombre1',fld:'vSERVICIOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV109PostulacionesProveedorNombre2',fld:'vPOSTULACIONESPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV25PostulacionesProveedorId2',fld:'vPOSTULACIONESPROVEEDORID2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ServiciosNombre2',fld:'vSERVICIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV110PostulacionesProveedorNombre3',fld:'vPOSTULACIONESPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV30PostulacionesProveedorId3',fld:'vPOSTULACIONESPROVEEDORID3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ServiciosNombre3',fld:'vSERVICIOSNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV123Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFPostulacionesId',fld:'vTFPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFPostulacionesId_To',fld:'vTFPOSTULACIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFServiciosId',fld:'vTFSERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFServiciosId_To',fld:'vTFSERVICIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFServiciosNombre',fld:'vTFSERVICIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFServiciosNombre_Sel',fld:'vTFSERVICIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPostulacionesProveedorId',fld:'vTFPOSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFPostulacionesProveedorId_To',fld:'vTFPOSTULACIONESPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV103TFPostulacionesProveedorNombre',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV104TFPostulacionesProveedorNombre_Sel',fld:'vTFPOSTULACIONESPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFPostulacionesPrecio',fld:'vTFPOSTULACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV53TFPostulacionesPrecio_To',fld:'vTFPOSTULACIONESPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV105TFPostulacionesMultimediaSerial',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL',pic:'ZZZ9',type:'int'},{av:'AV106TFPostulacionesMultimediaSerial_To',fld:'vTFPOSTULACIONESMULTIMEDIASERIAL_TO',pic:'ZZZ9',type:'int'},{av:'AV111TFPostulacionesSolicitudesId',fld:'vTFPOSTULACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV112TFPostulacionesSolicitudesId_To',fld:'vTFPOSTULACIONESSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFPostulacionesDescripcion',fld:'vTFPOSTULACIONESDESCRIPCION',pic:'',type:'char'},{av:'AV55TFPostulacionesDescripcion_Sel',fld:'vTFPOSTULACIONESDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV56TFPostulacionesReqSuministros_Sel',fld:'vTFPOSTULACIONESREQSUMINISTROS_SEL',pic:'9',type:'int'},{av:'AV57TFPostulacionesSuministrosDescripcion',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION',pic:'',type:'char'},{av:'AV58TFPostulacionesSuministrosDescripcion_Sel',fld:'vTFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV59TFPostulacionesFechaTrabajo',fld:'vTFPOSTULACIONESFECHATRABAJO',pic:'',type:'date'},{av:'AV60TFPostulacionesFechaTrabajo_To',fld:'vTFPOSTULACIONESFECHATRABAJO_TO',pic:'',type:'date'},{av:'AV64TFPostulacionesFechaCierre',fld:'vTFPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV65TFPostulacionesFechaCierre_To',fld:'vTFPOSTULACIONESFECHACIERRE_TO',pic:'',type:'date'},{av:'AV69TFPostulacionesHoraCierre',fld:'vTFPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV70TFPostulacionesHoraCierre_Sel',fld:'vTFPOSTULACIONESHORACIERRE_SEL',pic:'',type:'svchar'},{av:'AV71TFPostulacionesTipoFecha',fld:'vTFPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV122TFPostulacionesTipoFecha_Sel',fld:'vTFPOSTULACIONESTIPOFECHA_SEL',pic:'',type:'svchar'},{av:'AV73TFPostulacionesRgoHoraservicio',fld:'vTFPOSTULACIONESRGOHORASERVICIO',pic:'',type:'char'},{av:'AV74TFPostulacionesRgoHoraservicio_Sel',fld:'vTFPOSTULACIONESRGOHORASERVICIO_SEL',pic:'',type:'char'},{av:'AV75TFPostulacionesApellidoNombre',fld:'vTFPOSTULACIONESAPELLIDONOMBRE',pic:'',type:'char'},{av:'AV76TFPostulacionesApellidoNombre_Sel',fld:'vTFPOSTULACIONESAPELLIDONOMBRE_SEL',pic:'',type:'char'},{av:'AV77TFPostulacionesMail',fld:'vTFPOSTULACIONESMAIL',pic:'',type:'svchar'},{av:'AV78TFPostulacionesMail_Sel',fld:'vTFPOSTULACIONESMAIL_SEL',pic:'',type:'svchar'},{av:'AV79TFPostulacionesTelefono',fld:'vTFPOSTULACIONESTELEFONO',pic:'',type:'char'},{av:'AV80TFPostulacionesTelefono_Sel',fld:'vTFPOSTULACIONESTELEFONO_SEL',pic:'',type:'char'},{av:'AV81TFPostulacionesFechaAlta',fld:'vTFPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV82TFPostulacionesFechaAlta_To',fld:'vTFPOSTULACIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV87TFPostulacionesEstado_Sels',fld:'vTFPOSTULACIONESESTADO_SELS',pic:''},{av:'AV88TFPostulacionesSecUserId',fld:'vTFPOSTULACIONESSECUSERID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV89TFPostulacionesSecUserId_To',fld:'vTFPOSTULACIONESSECUSERID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV97IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV98IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ServiciosNombre',fld:'vISAUTHORIZED_SERVICIOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV86TFPostulacionesEstado_SelsJson',fld:'vTFPOSTULACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV83DDO_PostulacionesFechaAltaAuxDate',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV84DDO_PostulacionesFechaAltaAuxDateTo',fld:'vDDO_POSTULACIONESFECHAALTAAUXDATETO',pic:'',type:'date'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavPostulacionesproveedornombre1_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedorid1_Visible',ctrl:'vPOSTULACIONESPROVEEDORID1',prop:'Visible'},{av:'edtavServiciosnombre1_Visible',ctrl:'vSERVICIOSNOMBRE1',prop:'Visible'},{av:'edtavPostulacionesproveedornombre2_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedorid2_Visible',ctrl:'vPOSTULACIONESPROVEEDORID2',prop:'Visible'},{av:'edtavServiciosnombre2_Visible',ctrl:'vSERVICIOSNOMBRE2',prop:'Visible'},{av:'edtavPostulacionesproveedornombre3_Visible',ctrl:'vPOSTULACIONESPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavPostulacionesproveedorid3_Visible',ctrl:'vPOSTULACIONESPROVEEDORID3',prop:'Visible'},{av:'edtavServiciosnombre3_Visible',ctrl:'vSERVICIOSNOMBRE3',prop:'Visible'},{av:'edtPostulacionesId_Visible',ctrl:'POSTULACIONESID',prop:'Visible'},{av:'edtServiciosId_Visible',ctrl:'SERVICIOSID',prop:'Visible'},{av:'edtServiciosNombre_Visible',ctrl:'SERVICIOSNOMBRE',prop:'Visible'},{av:'edtPostulacionesProveedorId_Visible',ctrl:'POSTULACIONESPROVEEDORID',prop:'Visible'},{av:'edtPostulacionesProveedorNombre_Visible',ctrl:'POSTULACIONESPROVEEDORNOMBRE',prop:'Visible'},{av:'edtPostulacionesPrecio_Visible',ctrl:'POSTULACIONESPRECIO',prop:'Visible'},{av:'edtPostulacionesMultimediaSerial_Visible',ctrl:'POSTULACIONESMULTIMEDIASERIAL',prop:'Visible'},{av:'edtPostulacionesSolicitudesId_Visible',ctrl:'POSTULACIONESSOLICITUDESID',prop:'Visible'},{av:'edtPostulacionesDescripcion_Visible',ctrl:'POSTULACIONESDESCRIPCION',prop:'Visible'},{av:'chkPostulacionesReqSuministros.Visible',ctrl:'POSTULACIONESREQSUMINISTROS',prop:'Visible'},{av:'edtPostulacionesSuministrosDescri_Visible',ctrl:'POSTULACIONESSUMINISTROSDESCRI',prop:'Visible'},{av:'edtPostulacionesFechaTrabajo_Visible',ctrl:'POSTULACIONESFECHATRABAJO',prop:'Visible'},{av:'edtPostulacionesFechaCierre_Visible',ctrl:'POSTULACIONESFECHACIERRE',prop:'Visible'},{av:'edtPostulacionesHoraCierre_Visible',ctrl:'POSTULACIONESHORACIERRE',prop:'Visible'},{av:'edtPostulacionesTipoFecha_Visible',ctrl:'POSTULACIONESTIPOFECHA',prop:'Visible'},{av:'edtPostulacionesRgoHoraservicio_Visible',ctrl:'POSTULACIONESRGOHORASERVICIO',prop:'Visible'},{av:'edtPostulacionesApellidoNombre_Visible',ctrl:'POSTULACIONESAPELLIDONOMBRE',prop:'Visible'},{av:'edtPostulacionesMail_Visible',ctrl:'POSTULACIONESMAIL',prop:'Visible'},{av:'edtPostulacionesTelefono_Visible',ctrl:'POSTULACIONESTELEFONO',prop:'Visible'},{av:'edtPostulacionesFechaAlta_Visible',ctrl:'POSTULACIONESFECHAALTA',prop:'Visible'},{av:'cmbPostulacionesEstado'},{av:'edtPostulacionesSecUserId_Visible',ctrl:'POSTULACIONESSECUSERID',prop:'Visible'},{av:'AV92GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV94GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15KI2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_POSTULACIONESID","{handler:'Valid_Postulacionesid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESID",",oparms:[]}");
         setEventMetadata("VALID_SERVICIOSID","{handler:'Valid_Serviciosid',iparms:[]");
         setEventMetadata("VALID_SERVICIOSID",",oparms:[]}");
         setEventMetadata("VALID_SERVICIOSNOMBRE","{handler:'Valid_Serviciosnombre',iparms:[]");
         setEventMetadata("VALID_SERVICIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID","{handler:'Valid_Postulacionesproveedorid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORNOMBRE","{handler:'Valid_Postulacionesproveedornombre',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPRECIO","{handler:'Valid_Postulacionesprecio',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPRECIO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESMULTIMEDIASERIAL","{handler:'Valid_Postulacionesmultimediaserial',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESMULTIMEDIASERIAL",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESSOLICITUDESID","{handler:'Valid_Postulacionessolicitudesid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESSOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESDESCRIPCION","{handler:'Valid_Postulacionesdescripcion',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESDESCRIPCION",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESSUMINISTROSDESCRI","{handler:'Valid_Postulacionessuministrosdescri',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESSUMINISTROSDESCRI",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESHORACIERRE","{handler:'Valid_Postulacioneshoracierre',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESHORACIERRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESTIPOFECHA","{handler:'Valid_Postulacionestipofecha',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESTIPOFECHA",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESRGOHORASERVICIO","{handler:'Valid_Postulacionesrgohoraservicio',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESRGOHORASERVICIO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESAPELLIDONOMBRE","{handler:'Valid_Postulacionesapellidonombre',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESAPELLIDONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESMAIL","{handler:'Valid_Postulacionesmail',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESMAIL",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESTELEFONO","{handler:'Valid_Postulacionestelefono',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESESTADO","{handler:'Valid_Postulacionesestado',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESESTADO",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESSECUSERID","{handler:'Valid_Postulacionessecuserid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESSECUSERID",",oparms:[]}");
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
         AV18DynamicFiltersSelector1 = "";
         AV108PostulacionesProveedorNombre1 = "";
         AV21ServiciosNombre1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV109PostulacionesProveedorNombre2 = "";
         AV26ServiciosNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV110PostulacionesProveedorNombre3 = "";
         AV31ServiciosNombre3 = "";
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV123Pgmname = "";
         AV17FilterFullText = "";
         AV48TFServiciosNombre = "";
         AV49TFServiciosNombre_Sel = "";
         AV103TFPostulacionesProveedorNombre = "";
         AV104TFPostulacionesProveedorNombre_Sel = "";
         AV54TFPostulacionesDescripcion = "";
         AV55TFPostulacionesDescripcion_Sel = "";
         AV57TFPostulacionesSuministrosDescripcion = "";
         AV58TFPostulacionesSuministrosDescripcion_Sel = "";
         AV59TFPostulacionesFechaTrabajo = DateTime.MinValue;
         AV60TFPostulacionesFechaTrabajo_To = DateTime.MinValue;
         AV64TFPostulacionesFechaCierre = DateTime.MinValue;
         AV65TFPostulacionesFechaCierre_To = DateTime.MinValue;
         AV69TFPostulacionesHoraCierre = "";
         AV70TFPostulacionesHoraCierre_Sel = "";
         AV71TFPostulacionesTipoFecha = "";
         AV122TFPostulacionesTipoFecha_Sel = "";
         AV73TFPostulacionesRgoHoraservicio = "";
         AV74TFPostulacionesRgoHoraservicio_Sel = "";
         AV75TFPostulacionesApellidoNombre = "";
         AV76TFPostulacionesApellidoNombre_Sel = "";
         AV77TFPostulacionesMail = "";
         AV78TFPostulacionesMail_Sel = "";
         AV79TFPostulacionesTelefono = "";
         AV80TFPostulacionesTelefono_Sel = "";
         AV81TFPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV82TFPostulacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV87TFPostulacionesEstado_Sels = new GxSimpleCollection<string>();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV94GridAppliedFilters = "";
         AV100AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV90DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV62DDO_PostulacionesFechaTrabajoAuxDateTo = DateTime.MinValue;
         AV67DDO_PostulacionesFechaCierreAuxDateTo = DateTime.MinValue;
         AV84DDO_PostulacionesFechaAltaAuxDateTo = DateTime.MinValue;
         AV86TFPostulacionesEstado_SelsJson = "";
         AV61DDO_PostulacionesFechaTrabajoAuxDate = DateTime.MinValue;
         AV66DDO_PostulacionesFechaCierreAuxDate = DateTime.MinValue;
         AV83DDO_PostulacionesFechaAltaAuxDate = DateTime.MinValue;
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
         AV63DDO_PostulacionesFechaTrabajoAuxDateText = "";
         ucTfpostulacionesfechatrabajo_rangepicker = new GXUserControl();
         AV68DDO_PostulacionesFechaCierreAuxDateText = "";
         ucTfpostulacionesfechacierre_rangepicker = new GXUserControl();
         AV85DDO_PostulacionesFechaAltaAuxDateText = "";
         ucTfpostulacionesfechaalta_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A943ServiciosNombre = "";
         A969PostulacionesProveedorNombre = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A424PostulacionesEstado = "";
         AV124Postulacioneswwds_1_filterfulltext = "";
         AV125Postulacioneswwds_2_dynamicfiltersselector1 = "";
         AV127Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         AV129Postulacioneswwds_6_serviciosnombre1 = "";
         AV131Postulacioneswwds_8_dynamicfiltersselector2 = "";
         AV133Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         AV135Postulacioneswwds_12_serviciosnombre2 = "";
         AV137Postulacioneswwds_14_dynamicfiltersselector3 = "";
         AV139Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         AV141Postulacioneswwds_18_serviciosnombre3 = "";
         AV146Postulacioneswwds_23_tfserviciosnombre = "";
         AV147Postulacioneswwds_24_tfserviciosnombre_sel = "";
         AV150Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = "";
         AV158Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel = "";
         AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = "";
         AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo = DateTime.MinValue;
         AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = DateTime.MinValue;
         AV165Postulacioneswwds_42_tfpostulacionesfechacierre = DateTime.MinValue;
         AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to = DateTime.MinValue;
         AV167Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel = "";
         AV169Postulacioneswwds_46_tfpostulacionestipofecha = "";
         AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel = "";
         AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = "";
         AV173Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = "";
         AV175Postulacioneswwds_52_tfpostulacionesmail = "";
         AV176Postulacioneswwds_53_tfpostulacionesmail_sel = "";
         AV177Postulacioneswwds_54_tfpostulacionestelefono = "";
         AV178Postulacioneswwds_55_tfpostulacionestelefono_sel = "";
         AV179Postulacioneswwds_56_tfpostulacionesfechaalta = (DateTime)(DateTime.MinValue);
         AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV181Postulacioneswwds_58_tfpostulacionesestado_sels = new GxSimpleCollection<string>();
         lV124Postulacioneswwds_1_filterfulltext = "";
         lV127Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         lV129Postulacioneswwds_6_serviciosnombre1 = "";
         lV133Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         lV135Postulacioneswwds_12_serviciosnombre2 = "";
         lV139Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         lV141Postulacioneswwds_18_serviciosnombre3 = "";
         lV146Postulacioneswwds_23_tfserviciosnombre = "";
         lV150Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         lV158Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         lV167Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         lV169Postulacioneswwds_46_tfpostulacionestipofecha = "";
         lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         lV173Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         lV175Postulacioneswwds_52_tfpostulacionesmail = "";
         lV177Postulacioneswwds_54_tfpostulacionestelefono = "";
         H00KI3_A948PostulacionesSecUserId = new long[1] ;
         H00KI3_A424PostulacionesEstado = new string[] {""} ;
         H00KI3_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KI3_A952PostulacionesTelefono = new string[] {""} ;
         H00KI3_A951PostulacionesMail = new string[] {""} ;
         H00KI3_A950PostulacionesApellidoNombre = new string[] {""} ;
         H00KI3_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         H00KI3_A941PostulacionesTipoFecha = new string[] {""} ;
         H00KI3_A940PostulacionesHoraCierre = new string[] {""} ;
         H00KI3_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         H00KI3_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         H00KI3_A938PostulacionesSuministrosDescri = new string[] {""} ;
         H00KI3_A937PostulacionesReqSuministros = new bool[] {false} ;
         H00KI3_A936PostulacionesDescripcion = new string[] {""} ;
         H00KI3_A961PostulacionesMultimediaSerial = new short[1] ;
         H00KI3_A946PostulacionesPrecio = new decimal[1] ;
         H00KI3_A969PostulacionesProveedorNombre = new string[] {""} ;
         H00KI3_A945PostulacionesProveedorId = new long[1] ;
         H00KI3_A943ServiciosNombre = new string[] {""} ;
         H00KI3_A942ServiciosId = new long[1] ;
         H00KI3_n942ServiciosId = new bool[] {false} ;
         H00KI3_A422PostulacionesId = new long[1] ;
         H00KI3_n422PostulacionesId = new bool[] {false} ;
         H00KI3_A970PostulacionesSolicitudesId = new long[1] ;
         H00KI3_n970PostulacionesSolicitudesId = new bool[] {false} ;
         H00KI5_A948PostulacionesSecUserId = new long[1] ;
         H00KI5_A424PostulacionesEstado = new string[] {""} ;
         H00KI5_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KI5_A952PostulacionesTelefono = new string[] {""} ;
         H00KI5_A951PostulacionesMail = new string[] {""} ;
         H00KI5_A950PostulacionesApellidoNombre = new string[] {""} ;
         H00KI5_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         H00KI5_A941PostulacionesTipoFecha = new string[] {""} ;
         H00KI5_A940PostulacionesHoraCierre = new string[] {""} ;
         H00KI5_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         H00KI5_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         H00KI5_A938PostulacionesSuministrosDescri = new string[] {""} ;
         H00KI5_A937PostulacionesReqSuministros = new bool[] {false} ;
         H00KI5_A936PostulacionesDescripcion = new string[] {""} ;
         H00KI5_A961PostulacionesMultimediaSerial = new short[1] ;
         H00KI5_A946PostulacionesPrecio = new decimal[1] ;
         H00KI5_A969PostulacionesProveedorNombre = new string[] {""} ;
         H00KI5_A945PostulacionesProveedorId = new long[1] ;
         H00KI5_A943ServiciosNombre = new string[] {""} ;
         H00KI5_A942ServiciosId = new long[1] ;
         H00KI5_n942ServiciosId = new bool[] {false} ;
         H00KI5_A422PostulacionesId = new long[1] ;
         H00KI5_n422PostulacionesId = new bool[] {false} ;
         H00KI5_A970PostulacionesSolicitudesId = new long[1] ;
         H00KI5_n970PostulacionesSolicitudesId = new bool[] {false} ;
         H00KI7_A970PostulacionesSolicitudesId = new long[1] ;
         H00KI7_n970PostulacionesSolicitudesId = new bool[] {false} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV101AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char14 = "";
         GXt_char13 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
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
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacionesww__default(),
            new Object[][] {
                new Object[] {
               H00KI3_A948PostulacionesSecUserId, H00KI3_A424PostulacionesEstado, H00KI3_A425PostulacionesFechaAlta, H00KI3_A952PostulacionesTelefono, H00KI3_A951PostulacionesMail, H00KI3_A950PostulacionesApellidoNombre, H00KI3_A949PostulacionesRgoHoraservicio, H00KI3_A941PostulacionesTipoFecha, H00KI3_A940PostulacionesHoraCierre, H00KI3_A939PostulacionesFechaCierre,
               H00KI3_A947PostulacionesFechaTrabajo, H00KI3_A938PostulacionesSuministrosDescri, H00KI3_A937PostulacionesReqSuministros, H00KI3_A936PostulacionesDescripcion, H00KI3_A961PostulacionesMultimediaSerial, H00KI3_A946PostulacionesPrecio, H00KI3_A969PostulacionesProveedorNombre, H00KI3_A945PostulacionesProveedorId, H00KI3_A943ServiciosNombre, H00KI3_A942ServiciosId,
               H00KI3_n942ServiciosId, H00KI3_A422PostulacionesId, H00KI3_A970PostulacionesSolicitudesId, H00KI3_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               H00KI5_A948PostulacionesSecUserId, H00KI5_A424PostulacionesEstado, H00KI5_A425PostulacionesFechaAlta, H00KI5_A952PostulacionesTelefono, H00KI5_A951PostulacionesMail, H00KI5_A950PostulacionesApellidoNombre, H00KI5_A949PostulacionesRgoHoraservicio, H00KI5_A941PostulacionesTipoFecha, H00KI5_A940PostulacionesHoraCierre, H00KI5_A939PostulacionesFechaCierre,
               H00KI5_A947PostulacionesFechaTrabajo, H00KI5_A938PostulacionesSuministrosDescri, H00KI5_A937PostulacionesReqSuministros, H00KI5_A936PostulacionesDescripcion, H00KI5_A961PostulacionesMultimediaSerial, H00KI5_A946PostulacionesPrecio, H00KI5_A969PostulacionesProveedorNombre, H00KI5_A945PostulacionesProveedorId, H00KI5_A943ServiciosNombre, H00KI5_A942ServiciosId,
               H00KI5_n942ServiciosId, H00KI5_A422PostulacionesId, H00KI5_A970PostulacionesSolicitudesId, H00KI5_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               H00KI7_A970PostulacionesSolicitudesId, H00KI7_n970PostulacionesSolicitudesId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV123Pgmname = "PostulacionesWW";
         /* GeneXus formulas. */
         AV123Pgmname = "PostulacionesWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short AV105TFPostulacionesMultimediaSerial ;
      private short AV106TFPostulacionesMultimediaSerial_To ;
      private short AV56TFPostulacionesReqSuministros_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV95GridActions ;
      private short A961PostulacionesMultimediaSerial ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV126Postulacioneswwds_3_dynamicfiltersoperator1 ;
      private short AV132Postulacioneswwds_9_dynamicfiltersoperator2 ;
      private short AV138Postulacioneswwds_15_dynamicfiltersoperator3 ;
      private short AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial ;
      private short AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ;
      private short AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_129 ;
      private int nGXsfl_129_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int AV181Postulacioneswwds_58_tfpostulacionesestado_sels_Count ;
      private int edtPostulacionesId_Enabled ;
      private int edtServiciosId_Enabled ;
      private int edtServiciosNombre_Enabled ;
      private int edtPostulacionesProveedorId_Enabled ;
      private int edtPostulacionesProveedorNombre_Enabled ;
      private int edtPostulacionesPrecio_Enabled ;
      private int edtPostulacionesMultimediaSerial_Enabled ;
      private int edtPostulacionesSolicitudesId_Enabled ;
      private int edtPostulacionesDescripcion_Enabled ;
      private int edtPostulacionesSuministrosDescri_Enabled ;
      private int edtPostulacionesFechaTrabajo_Enabled ;
      private int edtPostulacionesFechaCierre_Enabled ;
      private int edtPostulacionesHoraCierre_Enabled ;
      private int edtPostulacionesTipoFecha_Enabled ;
      private int edtPostulacionesRgoHoraservicio_Enabled ;
      private int edtPostulacionesApellidoNombre_Enabled ;
      private int edtPostulacionesMail_Enabled ;
      private int edtPostulacionesTelefono_Enabled ;
      private int edtPostulacionesFechaAlta_Enabled ;
      private int edtPostulacionesSecUserId_Enabled ;
      private int edtPostulacionesId_Visible ;
      private int edtServiciosId_Visible ;
      private int edtServiciosNombre_Visible ;
      private int edtPostulacionesProveedorId_Visible ;
      private int edtPostulacionesProveedorNombre_Visible ;
      private int edtPostulacionesPrecio_Visible ;
      private int edtPostulacionesMultimediaSerial_Visible ;
      private int edtPostulacionesSolicitudesId_Visible ;
      private int edtPostulacionesDescripcion_Visible ;
      private int edtPostulacionesSuministrosDescri_Visible ;
      private int edtPostulacionesFechaTrabajo_Visible ;
      private int edtPostulacionesFechaCierre_Visible ;
      private int edtPostulacionesHoraCierre_Visible ;
      private int edtPostulacionesTipoFecha_Visible ;
      private int edtPostulacionesRgoHoraservicio_Visible ;
      private int edtPostulacionesApellidoNombre_Visible ;
      private int edtPostulacionesMail_Visible ;
      private int edtPostulacionesTelefono_Visible ;
      private int edtPostulacionesFechaAlta_Visible ;
      private int edtPostulacionesSecUserId_Visible ;
      private int AV91PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPostulacionesproveedornombre1_Visible ;
      private int edtavPostulacionesproveedorid1_Visible ;
      private int edtavServiciosnombre1_Visible ;
      private int edtavPostulacionesproveedornombre2_Visible ;
      private int edtavPostulacionesproveedorid2_Visible ;
      private int edtavServiciosnombre2_Visible ;
      private int edtavPostulacionesproveedornombre3_Visible ;
      private int edtavPostulacionesproveedorid3_Visible ;
      private int edtavServiciosnombre3_Visible ;
      private int AV184GXV1 ;
      private int edtavPostulacionesproveedornombre3_Enabled ;
      private int edtavPostulacionesproveedorid3_Enabled ;
      private int edtavServiciosnombre3_Enabled ;
      private int edtavPostulacionesproveedornombre2_Enabled ;
      private int edtavPostulacionesproveedorid2_Enabled ;
      private int edtavServiciosnombre2_Enabled ;
      private int edtavPostulacionesproveedornombre1_Enabled ;
      private int edtavPostulacionesproveedorid1_Enabled ;
      private int edtavServiciosnombre1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV20PostulacionesProveedorId1 ;
      private long AV25PostulacionesProveedorId2 ;
      private long AV30PostulacionesProveedorId3 ;
      private long AV44TFPostulacionesId ;
      private long AV45TFPostulacionesId_To ;
      private long AV46TFServiciosId ;
      private long AV47TFServiciosId_To ;
      private long AV50TFPostulacionesProveedorId ;
      private long AV51TFPostulacionesProveedorId_To ;
      private long AV111TFPostulacionesSolicitudesId ;
      private long AV112TFPostulacionesSolicitudesId_To ;
      private long AV88TFPostulacionesSecUserId ;
      private long AV89TFPostulacionesSecUserId_To ;
      private long AV92GridCurrentPage ;
      private long AV93GridPageCount ;
      private long A422PostulacionesId ;
      private long A942ServiciosId ;
      private long A945PostulacionesProveedorId ;
      private long A970PostulacionesSolicitudesId ;
      private long A948PostulacionesSecUserId ;
      private long GRID_nCurrentRecord ;
      private long AV128Postulacioneswwds_5_postulacionesproveedorid1 ;
      private long AV134Postulacioneswwds_11_postulacionesproveedorid2 ;
      private long AV140Postulacioneswwds_17_postulacionesproveedorid3 ;
      private long AV142Postulacioneswwds_19_tfpostulacionesid ;
      private long AV143Postulacioneswwds_20_tfpostulacionesid_to ;
      private long AV144Postulacioneswwds_21_tfserviciosid ;
      private long AV145Postulacioneswwds_22_tfserviciosid_to ;
      private long AV148Postulacioneswwds_25_tfpostulacionesproveedorid ;
      private long AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to ;
      private long AV156Postulacioneswwds_33_tfpostulacionessolicitudesid ;
      private long AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to ;
      private long AV182Postulacioneswwds_59_tfpostulacionessecuserid ;
      private long AV183Postulacioneswwds_60_tfpostulacionessecuserid_to ;
      private long GRID_nRecordCount ;
      private decimal AV52TFPostulacionesPrecio ;
      private decimal AV53TFPostulacionesPrecio_To ;
      private decimal A946PostulacionesPrecio ;
      private decimal AV152Postulacioneswwds_29_tfpostulacionesprecio ;
      private decimal AV153Postulacioneswwds_30_tfpostulacionesprecio_to ;
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
      private string sGXsfl_129_idx="0001" ;
      private string AV108PostulacionesProveedorNombre1 ;
      private string AV21ServiciosNombre1 ;
      private string AV109PostulacionesProveedorNombre2 ;
      private string AV26ServiciosNombre2 ;
      private string AV110PostulacionesProveedorNombre3 ;
      private string AV31ServiciosNombre3 ;
      private string AV123Pgmname ;
      private string AV48TFServiciosNombre ;
      private string AV49TFServiciosNombre_Sel ;
      private string AV103TFPostulacionesProveedorNombre ;
      private string AV104TFPostulacionesProveedorNombre_Sel ;
      private string AV54TFPostulacionesDescripcion ;
      private string AV55TFPostulacionesDescripcion_Sel ;
      private string AV57TFPostulacionesSuministrosDescripcion ;
      private string AV58TFPostulacionesSuministrosDescripcion_Sel ;
      private string AV73TFPostulacionesRgoHoraservicio ;
      private string AV74TFPostulacionesRgoHoraservicio_Sel ;
      private string AV75TFPostulacionesApellidoNombre ;
      private string AV76TFPostulacionesApellidoNombre_Sel ;
      private string AV79TFPostulacionesTelefono ;
      private string AV80TFPostulacionesTelefono_Sel ;
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
      private string divDdo_postulacionesfechatrabajoauxdates_Internalname ;
      private string edtavDdo_postulacionesfechatrabajoauxdatetext_Internalname ;
      private string edtavDdo_postulacionesfechatrabajoauxdatetext_Jsonclick ;
      private string Tfpostulacionesfechatrabajo_rangepicker_Internalname ;
      private string divDdo_postulacionesfechacierreauxdates_Internalname ;
      private string edtavDdo_postulacionesfechacierreauxdatetext_Internalname ;
      private string edtavDdo_postulacionesfechacierreauxdatetext_Jsonclick ;
      private string Tfpostulacionesfechacierre_rangepicker_Internalname ;
      private string divDdo_postulacionesfechaaltaauxdates_Internalname ;
      private string edtavDdo_postulacionesfechaaltaauxdatetext_Internalname ;
      private string edtavDdo_postulacionesfechaaltaauxdatetext_Jsonclick ;
      private string Tfpostulacionesfechaalta_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtPostulacionesId_Internalname ;
      private string edtServiciosId_Internalname ;
      private string A943ServiciosNombre ;
      private string edtServiciosNombre_Internalname ;
      private string edtPostulacionesProveedorId_Internalname ;
      private string A969PostulacionesProveedorNombre ;
      private string edtPostulacionesProveedorNombre_Internalname ;
      private string edtPostulacionesPrecio_Internalname ;
      private string edtPostulacionesMultimediaSerial_Internalname ;
      private string edtPostulacionesSolicitudesId_Internalname ;
      private string A936PostulacionesDescripcion ;
      private string edtPostulacionesDescripcion_Internalname ;
      private string chkPostulacionesReqSuministros_Internalname ;
      private string A938PostulacionesSuministrosDescri ;
      private string edtPostulacionesSuministrosDescri_Internalname ;
      private string edtPostulacionesFechaTrabajo_Internalname ;
      private string edtPostulacionesFechaCierre_Internalname ;
      private string edtPostulacionesHoraCierre_Internalname ;
      private string edtPostulacionesTipoFecha_Internalname ;
      private string A949PostulacionesRgoHoraservicio ;
      private string edtPostulacionesRgoHoraservicio_Internalname ;
      private string A950PostulacionesApellidoNombre ;
      private string edtPostulacionesApellidoNombre_Internalname ;
      private string edtPostulacionesMail_Internalname ;
      private string A952PostulacionesTelefono ;
      private string edtPostulacionesTelefono_Internalname ;
      private string edtPostulacionesFechaAlta_Internalname ;
      private string cmbPostulacionesEstado_Internalname ;
      private string A424PostulacionesEstado ;
      private string edtPostulacionesSecUserId_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string AV127Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string AV129Postulacioneswwds_6_serviciosnombre1 ;
      private string AV133Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string AV135Postulacioneswwds_12_serviciosnombre2 ;
      private string AV139Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string AV141Postulacioneswwds_18_serviciosnombre3 ;
      private string AV146Postulacioneswwds_23_tfserviciosnombre ;
      private string AV147Postulacioneswwds_24_tfserviciosnombre_sel ;
      private string AV150Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ;
      private string AV158Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel ;
      private string AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ;
      private string AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ;
      private string AV173Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ;
      private string AV177Postulacioneswwds_54_tfpostulacionestelefono ;
      private string AV178Postulacioneswwds_55_tfpostulacionestelefono_sel ;
      private string lV127Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string lV129Postulacioneswwds_6_serviciosnombre1 ;
      private string lV133Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string lV135Postulacioneswwds_12_serviciosnombre2 ;
      private string lV139Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string lV141Postulacioneswwds_18_serviciosnombre3 ;
      private string lV146Postulacioneswwds_23_tfserviciosnombre ;
      private string lV150Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string lV158Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string lV173Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string lV177Postulacioneswwds_54_tfpostulacionestelefono ;
      private string edtavPostulacionesproveedornombre1_Internalname ;
      private string edtavPostulacionesproveedorid1_Internalname ;
      private string edtavServiciosnombre1_Internalname ;
      private string edtavPostulacionesproveedornombre2_Internalname ;
      private string edtavPostulacionesproveedorid2_Internalname ;
      private string edtavServiciosnombre2_Internalname ;
      private string edtavPostulacionesproveedornombre3_Internalname ;
      private string edtavPostulacionesproveedorid3_Internalname ;
      private string edtavServiciosnombre3_Internalname ;
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
      private string edtServiciosNombre_Link ;
      private string GXEncryptionTmp ;
      private string edtPostulacionesProveedorNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char14 ;
      private string GXt_char13 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_postulacionesproveedornombre3_cell_Internalname ;
      private string edtavPostulacionesproveedornombre3_Jsonclick ;
      private string cellFilter_postulacionesproveedorid3_cell_Internalname ;
      private string edtavPostulacionesproveedorid3_Jsonclick ;
      private string cellFilter_serviciosnombre3_cell_Internalname ;
      private string edtavServiciosnombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_postulacionesproveedornombre2_cell_Internalname ;
      private string edtavPostulacionesproveedornombre2_Jsonclick ;
      private string cellFilter_postulacionesproveedorid2_cell_Internalname ;
      private string edtavPostulacionesproveedorid2_Jsonclick ;
      private string cellFilter_serviciosnombre2_cell_Internalname ;
      private string edtavServiciosnombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_postulacionesproveedornombre1_cell_Internalname ;
      private string edtavPostulacionesproveedornombre1_Jsonclick ;
      private string cellFilter_postulacionesproveedorid1_cell_Internalname ;
      private string edtavPostulacionesproveedorid1_Jsonclick ;
      private string cellFilter_serviciosnombre1_cell_Internalname ;
      private string edtavServiciosnombre1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_129_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtPostulacionesId_Jsonclick ;
      private string edtServiciosId_Jsonclick ;
      private string edtServiciosNombre_Jsonclick ;
      private string edtPostulacionesProveedorId_Jsonclick ;
      private string edtPostulacionesProveedorNombre_Jsonclick ;
      private string edtPostulacionesPrecio_Jsonclick ;
      private string edtPostulacionesMultimediaSerial_Jsonclick ;
      private string edtPostulacionesSolicitudesId_Jsonclick ;
      private string edtPostulacionesDescripcion_Jsonclick ;
      private string edtPostulacionesSuministrosDescri_Jsonclick ;
      private string edtPostulacionesFechaTrabajo_Jsonclick ;
      private string edtPostulacionesFechaCierre_Jsonclick ;
      private string edtPostulacionesHoraCierre_Jsonclick ;
      private string edtPostulacionesTipoFecha_Jsonclick ;
      private string edtPostulacionesRgoHoraservicio_Jsonclick ;
      private string edtPostulacionesApellidoNombre_Jsonclick ;
      private string edtPostulacionesMail_Jsonclick ;
      private string gxphoneLink ;
      private string edtPostulacionesTelefono_Jsonclick ;
      private string edtPostulacionesFechaAlta_Jsonclick ;
      private string cmbPostulacionesEstado_Jsonclick ;
      private string edtPostulacionesSecUserId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV81TFPostulacionesFechaAlta ;
      private DateTime AV82TFPostulacionesFechaAlta_To ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime AV179Postulacioneswwds_56_tfpostulacionesfechaalta ;
      private DateTime AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to ;
      private DateTime AV59TFPostulacionesFechaTrabajo ;
      private DateTime AV60TFPostulacionesFechaTrabajo_To ;
      private DateTime AV64TFPostulacionesFechaCierre ;
      private DateTime AV65TFPostulacionesFechaCierre_To ;
      private DateTime AV62DDO_PostulacionesFechaTrabajoAuxDateTo ;
      private DateTime AV67DDO_PostulacionesFechaCierreAuxDateTo ;
      private DateTime AV84DDO_PostulacionesFechaAltaAuxDateTo ;
      private DateTime AV61DDO_PostulacionesFechaTrabajoAuxDate ;
      private DateTime AV66DDO_PostulacionesFechaCierreAuxDate ;
      private DateTime AV83DDO_PostulacionesFechaAltaAuxDate ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A939PostulacionesFechaCierre ;
      private DateTime AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo ;
      private DateTime AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ;
      private DateTime AV165Postulacioneswwds_42_tfpostulacionesfechacierre ;
      private DateTime AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV97IsAuthorized_Update ;
      private bool AV98IsAuthorized_Delete ;
      private bool AV99IsAuthorized_ServiciosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_129_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n422PostulacionesId ;
      private bool n942ServiciosId ;
      private bool n970PostulacionesSolicitudesId ;
      private bool A937PostulacionesReqSuministros ;
      private bool AV130Postulacioneswwds_7_dynamicfiltersenabled2 ;
      private bool AV136Postulacioneswwds_13_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV102TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV86TFPostulacionesEstado_SelsJson ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV17FilterFullText ;
      private string AV69TFPostulacionesHoraCierre ;
      private string AV70TFPostulacionesHoraCierre_Sel ;
      private string AV71TFPostulacionesTipoFecha ;
      private string AV122TFPostulacionesTipoFecha_Sel ;
      private string AV77TFPostulacionesMail ;
      private string AV78TFPostulacionesMail_Sel ;
      private string AV94GridAppliedFilters ;
      private string AV63DDO_PostulacionesFechaTrabajoAuxDateText ;
      private string AV68DDO_PostulacionesFechaCierreAuxDateText ;
      private string AV85DDO_PostulacionesFechaAltaAuxDateText ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A951PostulacionesMail ;
      private string AV124Postulacioneswwds_1_filterfulltext ;
      private string AV125Postulacioneswwds_2_dynamicfiltersselector1 ;
      private string AV131Postulacioneswwds_8_dynamicfiltersselector2 ;
      private string AV137Postulacioneswwds_14_dynamicfiltersselector3 ;
      private string AV167Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel ;
      private string AV169Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel ;
      private string AV175Postulacioneswwds_52_tfpostulacionesmail ;
      private string AV176Postulacioneswwds_53_tfpostulacionesmail_sel ;
      private string lV124Postulacioneswwds_1_filterfulltext ;
      private string lV167Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string lV169Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string lV175Postulacioneswwds_52_tfpostulacionesmail ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private IGxSession AV40Session ;
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
      private GXUserControl ucTfpostulacionesfechatrabajo_rangepicker ;
      private GXUserControl ucTfpostulacionesfechacierre_rangepicker ;
      private GXUserControl ucTfpostulacionesfechaalta_rangepicker ;
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
      private GXCheckbox chkPostulacionesReqSuministros ;
      private GXCombobox cmbPostulacionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GxSimpleCollection<string> AV87TFPostulacionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV100AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV90DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV181Postulacioneswwds_58_tfpostulacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] H00KI3_A948PostulacionesSecUserId ;
      private string[] H00KI3_A424PostulacionesEstado ;
      private DateTime[] H00KI3_A425PostulacionesFechaAlta ;
      private string[] H00KI3_A952PostulacionesTelefono ;
      private string[] H00KI3_A951PostulacionesMail ;
      private string[] H00KI3_A950PostulacionesApellidoNombre ;
      private string[] H00KI3_A949PostulacionesRgoHoraservicio ;
      private string[] H00KI3_A941PostulacionesTipoFecha ;
      private string[] H00KI3_A940PostulacionesHoraCierre ;
      private DateTime[] H00KI3_A939PostulacionesFechaCierre ;
      private DateTime[] H00KI3_A947PostulacionesFechaTrabajo ;
      private string[] H00KI3_A938PostulacionesSuministrosDescri ;
      private bool[] H00KI3_A937PostulacionesReqSuministros ;
      private string[] H00KI3_A936PostulacionesDescripcion ;
      private short[] H00KI3_A961PostulacionesMultimediaSerial ;
      private decimal[] H00KI3_A946PostulacionesPrecio ;
      private string[] H00KI3_A969PostulacionesProveedorNombre ;
      private long[] H00KI3_A945PostulacionesProveedorId ;
      private string[] H00KI3_A943ServiciosNombre ;
      private long[] H00KI3_A942ServiciosId ;
      private bool[] H00KI3_n942ServiciosId ;
      private long[] H00KI3_A422PostulacionesId ;
      private bool[] H00KI3_n422PostulacionesId ;
      private long[] H00KI3_A970PostulacionesSolicitudesId ;
      private bool[] H00KI3_n970PostulacionesSolicitudesId ;
      private long[] H00KI5_A948PostulacionesSecUserId ;
      private string[] H00KI5_A424PostulacionesEstado ;
      private DateTime[] H00KI5_A425PostulacionesFechaAlta ;
      private string[] H00KI5_A952PostulacionesTelefono ;
      private string[] H00KI5_A951PostulacionesMail ;
      private string[] H00KI5_A950PostulacionesApellidoNombre ;
      private string[] H00KI5_A949PostulacionesRgoHoraservicio ;
      private string[] H00KI5_A941PostulacionesTipoFecha ;
      private string[] H00KI5_A940PostulacionesHoraCierre ;
      private DateTime[] H00KI5_A939PostulacionesFechaCierre ;
      private DateTime[] H00KI5_A947PostulacionesFechaTrabajo ;
      private string[] H00KI5_A938PostulacionesSuministrosDescri ;
      private bool[] H00KI5_A937PostulacionesReqSuministros ;
      private string[] H00KI5_A936PostulacionesDescripcion ;
      private short[] H00KI5_A961PostulacionesMultimediaSerial ;
      private decimal[] H00KI5_A946PostulacionesPrecio ;
      private string[] H00KI5_A969PostulacionesProveedorNombre ;
      private long[] H00KI5_A945PostulacionesProveedorId ;
      private string[] H00KI5_A943ServiciosNombre ;
      private long[] H00KI5_A942ServiciosId ;
      private bool[] H00KI5_n942ServiciosId ;
      private long[] H00KI5_A422PostulacionesId ;
      private bool[] H00KI5_n422PostulacionesId ;
      private long[] H00KI5_A970PostulacionesSolicitudesId ;
      private bool[] H00KI5_n970PostulacionesSolicitudesId ;
      private long[] H00KI7_A970PostulacionesSolicitudesId ;
      private bool[] H00KI7_n970PostulacionesSolicitudesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV101AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class postulacionesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00KI3( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV181Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV125Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV126Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV127Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV128Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV129Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV130Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV131Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV132Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV133Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV134Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV135Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV136Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV137Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV138Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV139Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV140Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV141Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV142Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV143Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV144Postulacioneswwds_21_tfserviciosid ,
                                             long AV145Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV147Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV146Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV148Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV150Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV152Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV153Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV158Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV165Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV167Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV169Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV173Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV176Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV175Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV178Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV177Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV179Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV181Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV182Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV183Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV124Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV156Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[64];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSecUserId], T1.[PostulacionesEstado], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T2.[ProveedorNombre] AS PostulacionesProveedorNombre, T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T3.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[PostulacionesProveedorId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T1.[ServiciosId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV156Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV127Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int15[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV127Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int15[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV128Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV128Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int15[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV128Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV128Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV128Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV128Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV129Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV129Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV133Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV133Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV134Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV134Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV134Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV134Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV134Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV134Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV135Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV135Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV139Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV139Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV140Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV140Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV140Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV140Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV140Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV140Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV141Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int15[24] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV141Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int15[25] = 1;
         }
         if ( ! (0==AV142Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV142Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int15[26] = 1;
         }
         if ( ! (0==AV143Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV143Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int15[27] = 1;
         }
         if ( ! (0==AV144Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV144Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int15[28] = 1;
         }
         if ( ! (0==AV145Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV145Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int15[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV146Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int15[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV147Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ServiciosNombre] = @AV147Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int15[31] = 1;
         }
         if ( StringUtil.StrCmp(AV147Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ServiciosNombre] IS NULL or (T3.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV148Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV148Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int15[32] = 1;
         }
         if ( ! (0==AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int15[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV150Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int15[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int15[35] = 1;
         }
         if ( StringUtil.StrCmp(AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV152Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV152Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int15[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV153Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int15[37] = 1;
         }
         if ( ! (0==AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int15[38] = 1;
         }
         if ( ! (0==AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int15[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV158Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int15[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int15[41] = 1;
         }
         if ( StringUtil.StrCmp(AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int15[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int15[43] = 1;
         }
         if ( StringUtil.StrCmp(AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int15[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int15[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV165Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV165Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int15[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int15[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV167Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int15[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int15[49] = 1;
         }
         if ( StringUtil.StrCmp(AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV169Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int15[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int15[51] = 1;
         }
         if ( StringUtil.StrCmp(AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int15[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int15[53] = 1;
         }
         if ( StringUtil.StrCmp(AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV173Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int15[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int15[55] = 1;
         }
         if ( StringUtil.StrCmp(AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV176Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV175Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int15[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV176Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV176Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int15[57] = 1;
         }
         if ( StringUtil.StrCmp(AV176Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV178Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV177Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int15[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV178Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV178Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int15[59] = 1;
         }
         if ( StringUtil.StrCmp(AV178Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV179Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV179Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int15[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int15[61] = 1;
         }
         if ( AV181Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV181Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV182Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV182Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int15[62] = 1;
         }
         if ( ! (0==AV183Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV183Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int15[63] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado]";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId]";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId] DESC";
         }
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      protected Object[] conditional_H00KI5( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV181Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV125Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV126Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV127Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV128Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV129Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV130Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV131Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV132Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV133Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV134Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV135Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV136Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV137Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV138Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV139Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV140Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV141Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV142Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV143Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV144Postulacioneswwds_21_tfserviciosid ,
                                             long AV145Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV147Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV146Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV148Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV150Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV152Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV153Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV158Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV165Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV167Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV169Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV173Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV176Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV175Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV178Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV177Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV179Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV181Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV182Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV183Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV124Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV156Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int17 = new short[64];
         Object[] GXv_Object18 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSecUserId], T1.[PostulacionesEstado], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T2.[ProveedorNombre] AS PostulacionesProveedorNombre, T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T3.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[PostulacionesProveedorId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T1.[ServiciosId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV156Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV156Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV127Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int17[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV127Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int17[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV128Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV128Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int17[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV128Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV128Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int17[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV128Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV128Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int17[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV129Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int17[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV125Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV126Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV129Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int17[11] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV133Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int17[12] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV133Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int17[13] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV134Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV134Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int17[14] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV134Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV134Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int17[15] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV134Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV134Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int17[16] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV135Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int17[17] = 1;
         }
         if ( AV130Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV132Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV135Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int17[18] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV139Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int17[19] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV139Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int17[20] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV140Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV140Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int17[21] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV140Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV140Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int17[22] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV140Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV140Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int17[23] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV141Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int17[24] = 1;
         }
         if ( AV136Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV138Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV141Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int17[25] = 1;
         }
         if ( ! (0==AV142Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV142Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int17[26] = 1;
         }
         if ( ! (0==AV143Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV143Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int17[27] = 1;
         }
         if ( ! (0==AV144Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV144Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int17[28] = 1;
         }
         if ( ! (0==AV145Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV145Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int17[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV146Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int17[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV147Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ServiciosNombre] = @AV147Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int17[31] = 1;
         }
         if ( StringUtil.StrCmp(AV147Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ServiciosNombre] IS NULL or (T3.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV148Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV148Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int17[32] = 1;
         }
         if ( ! (0==AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int17[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV150Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int17[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int17[35] = 1;
         }
         if ( StringUtil.StrCmp(AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV152Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV152Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int17[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV153Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int17[37] = 1;
         }
         if ( ! (0==AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int17[38] = 1;
         }
         if ( ! (0==AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int17[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV158Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int17[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int17[41] = 1;
         }
         if ( StringUtil.StrCmp(AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV160Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int17[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int17[43] = 1;
         }
         if ( StringUtil.StrCmp(AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int17[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int17[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV165Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV165Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int17[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int17[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV167Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int17[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int17[49] = 1;
         }
         if ( StringUtil.StrCmp(AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV169Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int17[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int17[51] = 1;
         }
         if ( StringUtil.StrCmp(AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int17[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int17[53] = 1;
         }
         if ( StringUtil.StrCmp(AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV173Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int17[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int17[55] = 1;
         }
         if ( StringUtil.StrCmp(AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV176Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV175Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int17[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV176Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV176Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int17[57] = 1;
         }
         if ( StringUtil.StrCmp(AV176Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV178Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV177Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int17[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV178Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV178Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int17[59] = 1;
         }
         if ( StringUtil.StrCmp(AV178Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV179Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV179Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int17[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int17[61] = 1;
         }
         if ( AV181Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV181Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV182Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV182Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int17[62] = 1;
         }
         if ( ! (0==AV183Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV183Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int17[63] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ServiciosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado]";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId]";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId] DESC";
         }
         GXv_Object18[0] = scmdbuf;
         GXv_Object18[1] = GXv_int17;
         return GXv_Object18 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00KI3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (short)dynConstraints[79] , (bool)dynConstraints[80] , (string)dynConstraints[81] , (long)dynConstraints[82] , (long)dynConstraints[83] , (long)dynConstraints[84] );
               case 1 :
                     return conditional_H00KI5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (short)dynConstraints[79] , (bool)dynConstraints[80] , (string)dynConstraints[81] , (long)dynConstraints[82] , (long)dynConstraints[83] , (long)dynConstraints[84] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00KI7;
          prmH00KI7 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmH00KI3;
          prmH00KI3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV156Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV156Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV127Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV127Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV128Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV128Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV128Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV129Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV129Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV133Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV133Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV134Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV134Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV134Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV135Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV135Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV139Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV139Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV140Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV140Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV140Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV141Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV141Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV142Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV143Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV144Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV145Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV146Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV147Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV148Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV150Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV152Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV153Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV158Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV165Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV167Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV169Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV173Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV175Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV176Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV177Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV178Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV179Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV182Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV183Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmH00KI5;
          prmH00KI5 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV156Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV156Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV157Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV127Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV127Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV128Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV128Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV128Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV129Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV129Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV133Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV133Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV134Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV134Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV134Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV135Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV135Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV139Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV139Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV140Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV140Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV140Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV141Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV141Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV142Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV143Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV144Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV145Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV146Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV147Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV148Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV149Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV150Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV151Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV152Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV153Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV154Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV155Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV158Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV159Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV161Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV162Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV163Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV164Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV165Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV166Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV167Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV168Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV169Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV170Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV171Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV172Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV173Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV174Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV175Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV176Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV177Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV178Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV179Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV180Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV182Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV183Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00KI3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KI3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00KI5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KI5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00KI7", "SELECT COALESCE( T1.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KI7,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 250);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 2000);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 80);
                ((long[]) buf[19])[0] = rslt.getLong(20);
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((long[]) buf[21])[0] = rslt.getLong(21);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 250);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 2000);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 80);
                ((long[]) buf[19])[0] = rslt.getLong(20);
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((long[]) buf[21])[0] = rslt.getLong(21);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}

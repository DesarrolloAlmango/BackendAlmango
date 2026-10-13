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
namespace GeneXus.Programs.dashboard {
   public class dashboard1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public dashboard1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dashboard1( IGxContext context )
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
         radavFiltro = new GXRadio();
         cmbavLocalidadorigen = new GXCombobox();
         cmbavLocalidaddestino = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
            {
               gxnrFreestylegrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
            {
               gxgrFreestylegrid1_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdtconsumoproductivos") == 0 )
            {
               gxnrGridsdtconsumoproductivos_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdtconsumoproductivos") == 0 )
            {
               gxgrGridsdtconsumoproductivos_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid2") == 0 )
            {
               gxnrFreestylegrid2_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid2") == 0 )
            {
               gxgrFreestylegrid2_refresh_invoke( ) ;
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
         edtTablaAuxId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxId_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxDepartamentoNombre_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxDepartamentoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoNombre_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxCapacidadProd_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxCapacidadProd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxCapacidadProd_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxDepartamentoId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxDepartamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoId_Visible), 5, 0), !bGXsfl_107_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridsdtconsumoproductivos_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdtconsumoproductivos_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV13RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
         edtTablaAuxId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxId_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxDepartamentoNombre_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxDepartamentoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoNombre_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxCapacidadProd_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxCapacidadProd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxCapacidadProd_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxDepartamentoId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtTablaAuxDepartamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoId_Visible), 5, 0), !bGXsfl_107_Refreshing);
         AV26Filtro = GetPar( "Filtro");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
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
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridsdtconsumoproductivos_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdtconsumoproductivos_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV13RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47SDTConsumoProductivo);
         AV26Filtro = GetPar( "Filtro");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrGridsdtconsumoproductivos_newrow_invoke( )
      {
         nRC_GXsfl_161 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_161"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_161_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_161_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_161_idx = GetPar( "sGXsfl_161_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdtconsumoproductivos_newrow( ) ;
         /* End function gxnrGridsdtconsumoproductivos_newrow_invoke */
      }

      protected void gxgrGridsdtconsumoproductivos_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridsdtconsumoproductivos_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdtconsumoproductivos_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV13RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
         AV26Filtro = GetPar( "Filtro");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdtconsumoproductivos_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdtconsumoproductivos_refresh_invoke */
      }

      protected void gxnrFreestylegrid2_newrow_invoke( )
      {
         nRC_GXsfl_154 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_154"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_154_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_154_idx = GetPar( "sGXsfl_154_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid2_newrow( ) ;
         /* End function gxnrFreestylegrid2_newrow_invoke */
      }

      protected void gxgrFreestylegrid2_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridsdtconsumoproductivos_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdtconsumoproductivos_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV13RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
         AV26Filtro = GetPar( "Filtro");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid2_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid2_refresh_invoke */
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
         PAGR2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTGR2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Calendar/index.global.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Calendar/WWPCalendarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("dashboard.dashboard1.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtconsumoproductivo", AV47SDTConsumoProductivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtconsumoproductivo", AV47SDTConsumoProductivo);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_140", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_140), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_154", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_154), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV20DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV20DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vZONASID_DATA", AV15ZonasId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vZONASID_DATA", AV15ZonasId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDEPARTAMENTOID_DATA", AV17DepartamentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDEPARTAMENTOID_DATA", AV17DepartamentoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRUBROSID_DATA", AV18RubrosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRUBROSID_DATA", AV18RubrosId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMEDIDASID_DATA", AV19MedidasId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMEDIDASID_DATA", AV19MedidasId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCALIDADORIGEN_DATA", AV28LocalidadOrigen_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCALIDADORIGEN_DATA", AV28LocalidadOrigen_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCALIDADDESTINO_DATA", AV30LocalidadDestino_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCALIDADDESTINO_DATA", AV30LocalidadDestino_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRID1CURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Grid1CurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39Grid1PageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRID1APPLIEDFILTERS", AV40Grid1AppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEVENTS", AV23Events);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEVENTS", AV23Events);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCONSUMOPRODUCTIVO", AV47SDTConsumoProductivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCONSUMOPRODUCTIVO", AV47SDTConsumoProductivo);
         }
         GxWebStd.gx_hidden_field( context, "vORIGEN", AV31Origen);
         GxWebStd.gx_hidden_field( context, "vDESTINO", AV32Destino);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "subFreestylegrid2_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONASID_Cls", StringUtil.RTrim( Combo_zonasid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONASID_Selectedvalue_set", StringUtil.RTrim( Combo_zonasid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONASID_Visible", StringUtil.BoolToStr( Combo_zonasid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONASID_Emptyitemtext", StringUtil.RTrim( Combo_zonasid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_DEPARTAMENTOID_Cls", StringUtil.RTrim( Combo_departamentoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DEPARTAMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_departamentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DEPARTAMENTOID_Emptyitemtext", StringUtil.RTrim( Combo_departamentoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Cls", StringUtil.RTrim( Combo_rubrosid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Selectedvalue_set", StringUtil.RTrim( Combo_rubrosid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Emptyitemtext", StringUtil.RTrim( Combo_rubrosid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Cls", StringUtil.RTrim( Combo_medidasid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Selectedvalue_set", StringUtil.RTrim( Combo_medidasid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Selectedtext_set", StringUtil.RTrim( Combo_medidasid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Datalistproc", StringUtil.RTrim( Combo_medidasid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_medidasid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Emptyitemtext", StringUtil.RTrim( Combo_medidasid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADORIGEN_Cls", StringUtil.RTrim( Combo_localidadorigen_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADORIGEN_Selectedvalue_set", StringUtil.RTrim( Combo_localidadorigen_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADORIGEN_Emptyitemtext", StringUtil.RTrim( Combo_localidadorigen_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADDESTINO_Cls", StringUtil.RTrim( Combo_localidaddestino_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADDESTINO_Selectedvalue_set", StringUtil.RTrim( Combo_localidaddestino_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADDESTINO_Emptyitemtext", StringUtil.RTrim( Combo_localidaddestino_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Width", StringUtil.RTrim( Dvpanel_unnamedtable5_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Cls", StringUtil.RTrim( Dvpanel_unnamedtable5_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Title", StringUtil.RTrim( Dvpanel_unnamedtable5_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable5_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE5_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Width", StringUtil.RTrim( Dvpanel_unnamedtable6_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Cls", StringUtil.RTrim( Dvpanel_unnamedtable6_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Title", StringUtil.RTrim( Dvpanel_unnamedtable6_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable6_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Class", StringUtil.RTrim( Grid1paginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Grid1paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Grid1paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Grid1paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Grid1paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Grid1paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Grid1paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Grid1paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Grid1paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Grid1paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Previous", StringUtil.RTrim( Grid1paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Next", StringUtil.RTrim( Grid1paginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Caption", StringUtil.RTrim( Grid1paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Grid1paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Grid1paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Selectable", StringUtil.BoolToStr( Utchartstackedbar_Selectable));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Viewstyle", StringUtil.RTrim( Utchartstackedbar_Viewstyle));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Defaulteventstyle", StringUtil.RTrim( Utchartstackedbar_Defaulteventstyle));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Enableweekends", StringUtil.BoolToStr( Utchartstackedbar_Enableweekends));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Enabledayheaders", StringUtil.BoolToStr( Utchartstackedbar_Enabledayheaders));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Enableeventshoursperday", StringUtil.BoolToStr( Utchartstackedbar_Enableeventshoursperday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Navlinks", StringUtil.BoolToStr( Utchartstackedbar_Navlinks));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Includeupdateinpopup", StringUtil.BoolToStr( Utchartstackedbar_Includeupdateinpopup));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Includedeleteinpopup", StringUtil.BoolToStr( Utchartstackedbar_Includedeleteinpopup));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Nowindicator", StringUtil.BoolToStr( Utchartstackedbar_Nowindicator));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Daymaxevents", StringUtil.LTrim( StringUtil.NToC( (decimal)(Utchartstackedbar_Daymaxevents), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Shownoncurrentdates", StringUtil.BoolToStr( Utchartstackedbar_Shownoncurrentdates));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Titleposition", StringUtil.RTrim( Utchartstackedbar_Titleposition));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Monthbuttonposition", StringUtil.RTrim( Utchartstackedbar_Monthbuttonposition));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Weekbuttonposition", StringUtil.RTrim( Utchartstackedbar_Weekbuttonposition));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Daybuttonposition", StringUtil.RTrim( Utchartstackedbar_Daybuttonposition));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Listbuttonposition", StringUtil.RTrim( Utchartstackedbar_Listbuttonposition));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Sunday", StringUtil.BoolToStr( Utchartstackedbar_Sunday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Monday", StringUtil.BoolToStr( Utchartstackedbar_Monday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Tuesday", StringUtil.BoolToStr( Utchartstackedbar_Tuesday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Wednesday", StringUtil.BoolToStr( Utchartstackedbar_Wednesday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Thursday", StringUtil.BoolToStr( Utchartstackedbar_Thursday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Friday", StringUtil.BoolToStr( Utchartstackedbar_Friday));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Saturday", StringUtil.BoolToStr( Utchartstackedbar_Saturday));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardlefticon2_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardlefticon2_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardlefticon2_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardlefticon2_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardlefticon2_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardlefticon2_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardlefticon2_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardlefticon2_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardlefticon2_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON2_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardlefticon2_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardlefticon1_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardlefticon1_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID1_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid1_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID1_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid1_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid1_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsdtconsumoproductivos_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Class", StringUtil.RTrim( subFreestylegrid1_Class));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADDESTINO_Selectedvalue_get", StringUtil.RTrim( Combo_localidaddestino_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADDESTINO_Selectedtext_get", StringUtil.RTrim( Combo_localidaddestino_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADORIGEN_Selectedvalue_get", StringUtil.RTrim( Combo_localidadorigen_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LOCALIDADORIGEN_Selectedtext_get", StringUtil.RTrim( Combo_localidadorigen_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Selectedvalue_get", StringUtil.RTrim( Combo_medidasid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Selectedvalue_get", StringUtil.RTrim( Combo_rubrosid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_DEPARTAMENTOID_Selectedvalue_get", StringUtil.RTrim( Combo_departamentoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONASID_Selectedvalue_get", StringUtil.RTrim( Combo_zonasid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "TABLAAUXID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABLAAUXDEPARTAMENTONOMBRE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxDepartamentoNombre_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABLAAUXCAPACIDADPROD_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxCapacidadProd_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABLAAUXDEPARTAMENTOID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxDepartamentoId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDIDASID_Selectedvalue_get", StringUtil.RTrim( Combo_medidasid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Selectedvalue_get", StringUtil.RTrim( Combo_rubrosid_Selectedvalue_get));
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
            WEGR2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTGR2( ) ;
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
         return formatLink("dashboard.dashboard1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Dashboard.Dashboard1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Panel de Control", "") ;
      }

      protected void WBGR0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable5.SetProperty("Width", Dvpanel_unnamedtable5_Width);
            ucDvpanel_unnamedtable5.SetProperty("AutoWidth", Dvpanel_unnamedtable5_Autowidth);
            ucDvpanel_unnamedtable5.SetProperty("AutoHeight", Dvpanel_unnamedtable5_Autoheight);
            ucDvpanel_unnamedtable5.SetProperty("Cls", Dvpanel_unnamedtable5_Cls);
            ucDvpanel_unnamedtable5.SetProperty("Title", Dvpanel_unnamedtable5_Title);
            ucDvpanel_unnamedtable5.SetProperty("Collapsible", Dvpanel_unnamedtable5_Collapsible);
            ucDvpanel_unnamedtable5.SetProperty("Collapsed", Dvpanel_unnamedtable5_Collapsed);
            ucDvpanel_unnamedtable5.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable5_Showcollapseicon);
            ucDvpanel_unnamedtable5.SetProperty("IconPosition", Dvpanel_unnamedtable5_Iconposition);
            ucDvpanel_unnamedtable5.SetProperty("AutoScroll", Dvpanel_unnamedtable5_Autoscroll);
            ucDvpanel_unnamedtable5.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable5_Internalname, "DVPANEL_UNNAMEDTABLE5Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE5Container"+"UnnamedTable5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "PanelFilled", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Filtro", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavFiltro, radavFiltro_Internalname, StringUtil.RTrim( AV26Filtro), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavFiltro_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableservicios_Internalname, divTableservicios_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_zonasid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_zonasid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedzonasid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_zonasid_Internalname, context.GetMessage( "Zona", ""), "", "", lblTextblockcombo_zonasid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_zonasid.SetProperty("Caption", Combo_zonasid_Caption);
            ucCombo_zonasid.SetProperty("Cls", Combo_zonasid_Cls);
            ucCombo_zonasid.SetProperty("EmptyItemText", Combo_zonasid_Emptyitemtext);
            ucCombo_zonasid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_zonasid.SetProperty("DropDownOptionsData", AV15ZonasId_Data);
            ucCombo_zonasid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_zonasid_Internalname, "COMBO_ZONASIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop10 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddepartamentoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_departamentoid_Internalname, context.GetMessage( "Departamento", ""), "", "", lblTextblockcombo_departamentoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_departamentoid.SetProperty("Caption", Combo_departamentoid_Caption);
            ucCombo_departamentoid.SetProperty("Cls", Combo_departamentoid_Cls);
            ucCombo_departamentoid.SetProperty("EmptyItemText", Combo_departamentoid_Emptyitemtext);
            ucCombo_departamentoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_departamentoid.SetProperty("DropDownOptionsData", AV17DepartamentoId_Data);
            ucCombo_departamentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_departamentoid_Internalname, "COMBO_DEPARTAMENTOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop10 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedrubrosid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_rubrosid_Internalname, context.GetMessage( "Rubro", ""), "", "", lblTextblockcombo_rubrosid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_rubrosid.SetProperty("Caption", Combo_rubrosid_Caption);
            ucCombo_rubrosid.SetProperty("Cls", Combo_rubrosid_Cls);
            ucCombo_rubrosid.SetProperty("EmptyItemText", Combo_rubrosid_Emptyitemtext);
            ucCombo_rubrosid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_rubrosid.SetProperty("DropDownOptionsData", AV18RubrosId_Data);
            ucCombo_rubrosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_rubrosid_Internalname, "COMBO_RUBROSIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop10 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmedidasid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_medidasid_Internalname, context.GetMessage( "Subrubro", ""), "", "", lblTextblockcombo_medidasid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_medidasid.SetProperty("Caption", Combo_medidasid_Caption);
            ucCombo_medidasid.SetProperty("Cls", Combo_medidasid_Cls);
            ucCombo_medidasid.SetProperty("DataListProc", Combo_medidasid_Datalistproc);
            ucCombo_medidasid.SetProperty("EmptyItemText", Combo_medidasid_Emptyitemtext);
            ucCombo_medidasid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_medidasid.SetProperty("DropDownOptionsData", AV19MedidasId_Data);
            ucCombo_medidasid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_medidasid_Internalname, "COMBO_MEDIDASIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaplicar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnaplicar_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOAPLICAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, " ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemudanzas_Internalname, divTablemudanzas_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop10 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocalidadorigen_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_localidadorigen_Internalname, context.GetMessage( "Localidad origen", ""), "", "", lblTextblockcombo_localidadorigen_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_localidadorigen.SetProperty("Caption", Combo_localidadorigen_Caption);
            ucCombo_localidadorigen.SetProperty("Cls", Combo_localidadorigen_Cls);
            ucCombo_localidadorigen.SetProperty("EmptyItemText", Combo_localidadorigen_Emptyitemtext);
            ucCombo_localidadorigen.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_localidadorigen.SetProperty("DropDownOptionsData", AV28LocalidadOrigen_Data);
            ucCombo_localidadorigen.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_localidadorigen_Internalname, "COMBO_LOCALIDADORIGENContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop10 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocalidaddestino_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_localidaddestino_Internalname, context.GetMessage( "Localidad destino", ""), "", "", lblTextblockcombo_localidaddestino_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_localidaddestino.SetProperty("Caption", Combo_localidaddestino_Caption);
            ucCombo_localidaddestino.SetProperty("Cls", Combo_localidaddestino_Cls);
            ucCombo_localidaddestino.SetProperty("EmptyItemText", Combo_localidaddestino_Emptyitemtext);
            ucCombo_localidaddestino.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_localidaddestino.SetProperty("DropDownOptionsData", AV30LocalidadDestino_Data);
            ucCombo_localidaddestino.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_localidaddestino_Internalname, "COMBO_LOCALIDADDESTINOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, " ", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaplicar2_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnaplicar2_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOAPLICAR2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, " ", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, " ", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable6.SetProperty("Width", Dvpanel_unnamedtable6_Width);
            ucDvpanel_unnamedtable6.SetProperty("AutoWidth", Dvpanel_unnamedtable6_Autowidth);
            ucDvpanel_unnamedtable6.SetProperty("AutoHeight", Dvpanel_unnamedtable6_Autoheight);
            ucDvpanel_unnamedtable6.SetProperty("Cls", Dvpanel_unnamedtable6_Cls);
            ucDvpanel_unnamedtable6.SetProperty("Title", Dvpanel_unnamedtable6_Title);
            ucDvpanel_unnamedtable6.SetProperty("Collapsible", Dvpanel_unnamedtable6_Collapsible);
            ucDvpanel_unnamedtable6.SetProperty("Collapsed", Dvpanel_unnamedtable6_Collapsed);
            ucDvpanel_unnamedtable6.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable6_Showcollapseicon);
            ucDvpanel_unnamedtable6.SetProperty("IconPosition", Dvpanel_unnamedtable6_Iconposition);
            ucDvpanel_unnamedtable6.SetProperty("AutoScroll", Dvpanel_unnamedtable6_Autoscroll);
            ucDvpanel_unnamedtable6.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable6_Internalname, "DVPANEL_UNNAMEDTABLE6Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE6Container"+"UnnamedTable6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl107( ) ;
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            nRC_GXsfl_107 = (int)(nGXsfl_107_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, " ", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid1tablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl140( ) ;
         }
         if ( wbEnd == 140 )
         {
            wbEnd = 0;
            nRC_GXsfl_140 = (int)(nGXsfl_140_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV60GXV1 = nGXsfl_140_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid1paginationbar.SetProperty("Class", Grid1paginationbar_Class);
            ucGrid1paginationbar.SetProperty("ShowFirst", Grid1paginationbar_Showfirst);
            ucGrid1paginationbar.SetProperty("ShowPrevious", Grid1paginationbar_Showprevious);
            ucGrid1paginationbar.SetProperty("ShowNext", Grid1paginationbar_Shownext);
            ucGrid1paginationbar.SetProperty("ShowLast", Grid1paginationbar_Showlast);
            ucGrid1paginationbar.SetProperty("PagesToShow", Grid1paginationbar_Pagestoshow);
            ucGrid1paginationbar.SetProperty("PagingButtonsPosition", Grid1paginationbar_Pagingbuttonsposition);
            ucGrid1paginationbar.SetProperty("PagingCaptionPosition", Grid1paginationbar_Pagingcaptionposition);
            ucGrid1paginationbar.SetProperty("EmptyGridClass", Grid1paginationbar_Emptygridclass);
            ucGrid1paginationbar.SetProperty("RowsPerPageSelector", Grid1paginationbar_Rowsperpageselector);
            ucGrid1paginationbar.SetProperty("RowsPerPageOptions", Grid1paginationbar_Rowsperpageoptions);
            ucGrid1paginationbar.SetProperty("Previous", Grid1paginationbar_Previous);
            ucGrid1paginationbar.SetProperty("Next", Grid1paginationbar_Next);
            ucGrid1paginationbar.SetProperty("Caption", Grid1paginationbar_Caption);
            ucGrid1paginationbar.SetProperty("EmptyGridCaption", Grid1paginationbar_Emptygridcaption);
            ucGrid1paginationbar.SetProperty("RowsPerPageCaption", Grid1paginationbar_Rowsperpagecaption);
            ucGrid1paginationbar.SetProperty("CurrentPage", AV38Grid1CurrentPage);
            ucGrid1paginationbar.SetProperty("PageCount", AV39Grid1PageCount);
            ucGrid1paginationbar.SetProperty("AppliedFilters", AV40Grid1AppliedFilters);
            ucGrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Grid1paginationbar_Internalname, "GRID1PAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", context.GetMessage( "pRUEBA", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "pRUEBA", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid2Container.SetIsFreestyle(true);
            Freestylegrid2Container.SetWrapped(nGXWrapped);
            StartGridControl154( ) ;
         }
         if ( wbEnd == 154 )
         {
            wbEnd = 0;
            nRC_GXsfl_154 = (int)(nGXsfl_154_idx-1);
            if ( Freestylegrid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV68GXV9 = nGXsfl_154_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Freestylegrid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid2", Freestylegrid2Container, subFreestylegrid2_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid2ContainerData", Freestylegrid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid2ContainerData"+"V", Freestylegrid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid2ContainerData"+"V"+"\" value='"+Freestylegrid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 col-lg-8 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", divTablechart1_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartstackedbar.SetProperty("Events", AV23Events);
            ucUtchartstackedbar.SetProperty("Selectable", Utchartstackedbar_Selectable);
            ucUtchartstackedbar.SetProperty("ViewStyle", Utchartstackedbar_Viewstyle);
            ucUtchartstackedbar.SetProperty("DefaultEventStyle", Utchartstackedbar_Defaulteventstyle);
            ucUtchartstackedbar.SetProperty("EnableWeekends", Utchartstackedbar_Enableweekends);
            ucUtchartstackedbar.SetProperty("EnableDayHeaders", Utchartstackedbar_Enabledayheaders);
            ucUtchartstackedbar.SetProperty("EnableEventsHoursPerDay", Utchartstackedbar_Enableeventshoursperday);
            ucUtchartstackedbar.SetProperty("NavLinks", Utchartstackedbar_Navlinks);
            ucUtchartstackedbar.SetProperty("IncludeUpdateInPopup", Utchartstackedbar_Includeupdateinpopup);
            ucUtchartstackedbar.SetProperty("IncludeDeleteInPopup", Utchartstackedbar_Includedeleteinpopup);
            ucUtchartstackedbar.SetProperty("NowIndicator", Utchartstackedbar_Nowindicator);
            ucUtchartstackedbar.SetProperty("DayMaxEvents", Utchartstackedbar_Daymaxevents);
            ucUtchartstackedbar.SetProperty("ShowNonCurrentDates", Utchartstackedbar_Shownoncurrentdates);
            ucUtchartstackedbar.SetProperty("TitlePosition", Utchartstackedbar_Titleposition);
            ucUtchartstackedbar.SetProperty("MonthButtonPosition", Utchartstackedbar_Monthbuttonposition);
            ucUtchartstackedbar.SetProperty("WeekButtonPosition", Utchartstackedbar_Weekbuttonposition);
            ucUtchartstackedbar.SetProperty("DayButtonPosition", Utchartstackedbar_Daybuttonposition);
            ucUtchartstackedbar.SetProperty("ListButtonPosition", Utchartstackedbar_Listbuttonposition);
            ucUtchartstackedbar.SetProperty("Sunday", Utchartstackedbar_Sunday);
            ucUtchartstackedbar.SetProperty("Monday", Utchartstackedbar_Monday);
            ucUtchartstackedbar.SetProperty("Tuesday", Utchartstackedbar_Tuesday);
            ucUtchartstackedbar.SetProperty("Wednesday", Utchartstackedbar_Wednesday);
            ucUtchartstackedbar.SetProperty("Thursday", Utchartstackedbar_Thursday);
            ucUtchartstackedbar.SetProperty("Friday", Utchartstackedbar_Friday);
            ucUtchartstackedbar.SetProperty("Saturday", Utchartstackedbar_Saturday);
            ucUtchartstackedbar.Render(context, "dvelop.wwpcalendar", Utchartstackedbar_Internalname, "UTCHARTSTACKEDBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "ALERTAS", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Dashboard/Dashboard1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardlefticon2_maintable.SetProperty("Width", Dvpanel_cardlefticon2_maintable_Width);
            ucDvpanel_cardlefticon2_maintable.SetProperty("AutoWidth", Dvpanel_cardlefticon2_maintable_Autowidth);
            ucDvpanel_cardlefticon2_maintable.SetProperty("AutoHeight", Dvpanel_cardlefticon2_maintable_Autoheight);
            ucDvpanel_cardlefticon2_maintable.SetProperty("Cls", Dvpanel_cardlefticon2_maintable_Cls);
            ucDvpanel_cardlefticon2_maintable.SetProperty("Title", Dvpanel_cardlefticon2_maintable_Title);
            ucDvpanel_cardlefticon2_maintable.SetProperty("Collapsible", Dvpanel_cardlefticon2_maintable_Collapsible);
            ucDvpanel_cardlefticon2_maintable.SetProperty("Collapsed", Dvpanel_cardlefticon2_maintable_Collapsed);
            ucDvpanel_cardlefticon2_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardlefticon2_maintable_Showcollapseicon);
            ucDvpanel_cardlefticon2_maintable.SetProperty("IconPosition", Dvpanel_cardlefticon2_maintable_Iconposition);
            ucDvpanel_cardlefticon2_maintable.SetProperty("AutoScroll", Dvpanel_cardlefticon2_maintable_Autoscroll);
            ucDvpanel_cardlefticon2_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardlefticon2_maintable_Internalname, "DVPANEL_CARDLEFTICON2_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDLEFTICON2_MAINTABLEContainer"+"CardLeftIcon2_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardlefticon2_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon2_icon_Internalname, context.GetMessage( "<i class='ProgressCardIconWarning fas fa-circle-exclamation' style='font-size: 50px'></i>", ""), "", "", lblCardlefticon2_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardlefticon2_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon2_description_Internalname, context.GetMessage( "Días límite", ""), "", "", lblCardlefticon2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardlefticon2_value_Internalname, context.GetMessage( "Card Left Icon2_Value", ""), "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardlefticon2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33CardLeftIcon2_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCardlefticon2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33CardLeftIcon2_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV33CardLeftIcon2_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardlefticon2_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardlefticon2_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoCardCell", "start", "top", "", "", "div");
            wb_table1_197_GR2( true) ;
         }
         else
         {
            wb_table1_197_GR2( false) ;
         }
         return  ;
      }

      protected void wb_table1_197_GR2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardlefticon1_maintable.SetProperty("Width", Dvpanel_cardlefticon1_maintable_Width);
            ucDvpanel_cardlefticon1_maintable.SetProperty("AutoWidth", Dvpanel_cardlefticon1_maintable_Autowidth);
            ucDvpanel_cardlefticon1_maintable.SetProperty("AutoHeight", Dvpanel_cardlefticon1_maintable_Autoheight);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Cls", Dvpanel_cardlefticon1_maintable_Cls);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Title", Dvpanel_cardlefticon1_maintable_Title);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Collapsible", Dvpanel_cardlefticon1_maintable_Collapsible);
            ucDvpanel_cardlefticon1_maintable.SetProperty("Collapsed", Dvpanel_cardlefticon1_maintable_Collapsed);
            ucDvpanel_cardlefticon1_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardlefticon1_maintable_Showcollapseicon);
            ucDvpanel_cardlefticon1_maintable.SetProperty("IconPosition", Dvpanel_cardlefticon1_maintable_Iconposition);
            ucDvpanel_cardlefticon1_maintable.SetProperty("AutoScroll", Dvpanel_cardlefticon1_maintable_Autoscroll);
            ucDvpanel_cardlefticon1_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardlefticon1_maintable_Internalname, "DVPANEL_CARDLEFTICON1_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDLEFTICON1_MAINTABLEContainer"+"CardLeftIcon1_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardlefticon1_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_icon_Internalname, context.GetMessage( "<i class='ProgressCardIconDanger fas fa-triangle-exclamation' style='font-size: 50px'></i>", ""), "", "", lblCardlefticon1_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardlefticon1_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_description_Internalname, context.GetMessage( "Días Saturados", ""), "", "", lblCardlefticon1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardlefticon1_value_Internalname, context.GetMessage( "Card Left Icon1_Value", ""), "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardlefticon1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34CardLeftIcon1_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCardlefticon1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV34CardLeftIcon1_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV34CardLeftIcon1_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardlefticon1_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardlefticon1_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Dashboard/Dashboard1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoCardCell", "start", "top", "", "", "div");
            wb_table2_219_GR2( true) ;
         }
         else
         {
            wb_table2_219_GR2( false) ;
         }
         return  ;
      }

      protected void wb_table2_219_GR2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 228,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavZonasid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ZonasId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11ZonasId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,228);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Seleccione su Zona", ""), edtavZonasid_Jsonclick, 0, "Attribute", "", "", "", "", edtavZonasid_Visible, 1, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Dashboard/Dashboard1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,229);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDepartamentoid_Visible, 1, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Dashboard/Dashboard1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13RubrosId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,230);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubrosid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Dashboard/Dashboard1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMedidasid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14MedidasId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14MedidasId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,231);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMedidasid_Jsonclick, 0, "Attribute", "", "", "", "", edtavMedidasid_Visible, 1, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Dashboard/Dashboard1.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 232,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLocalidadorigen, cmbavLocalidadorigen_Internalname, StringUtil.RTrim( AV27LocalidadOrigen), 1, cmbavLocalidadorigen_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavLocalidadorigen.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,232);\"", "", true, 0, "HLP_Dashboard/Dashboard1.htm");
            cmbavLocalidadorigen.CurrentValue = StringUtil.RTrim( AV27LocalidadOrigen);
            AssignProp("", false, cmbavLocalidadorigen_Internalname, "Values", (string)(cmbavLocalidadorigen.ToJavascriptSource()), true);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 233,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLocalidaddestino, cmbavLocalidaddestino_Internalname, StringUtil.RTrim( AV29LocalidadDestino), 1, cmbavLocalidaddestino_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavLocalidaddestino.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,233);\"", "", true, 0, "HLP_Dashboard/Dashboard1.htm");
            cmbavLocalidaddestino.CurrentValue = StringUtil.RTrim( AV29LocalidadDestino);
            AssignProp("", false, cmbavLocalidaddestino_Internalname, "Values", (string)(cmbavLocalidaddestino.ToJavascriptSource()), true);
            /* User Defined Control */
            ucGrid1_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid1_titlescategories_Internalname, "GRID1_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid1_empowerer.SetProperty("HasCategories", Grid1_empowerer_Hascategories);
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            /* User Defined Control */
            ucGridsdtconsumoproductivos_empowerer.Render(context, "wwp.gridempowerer", Gridsdtconsumoproductivos_empowerer_Internalname, "GRIDSDTCONSUMOPRODUCTIVOS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 140 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV60GXV1 = nGXsfl_140_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 154 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV68GXV9 = nGXsfl_154_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Freestylegrid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid2", Freestylegrid2Container, subFreestylegrid2_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid2ContainerData", Freestylegrid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid2ContainerData"+"V", Freestylegrid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid2ContainerData"+"V"+"\" value='"+Freestylegrid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 161 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsdtconsumoproductivosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV65GXV6 = nGXsfl_161_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsdtconsumoproductivosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtconsumoproductivos", GridsdtconsumoproductivosContainer, subGridsdtconsumoproductivos_Internalname);
                  if ( ! isAjaxCallMode( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtconsumoproductivosContainerData", GridsdtconsumoproductivosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtconsumoproductivosContainerData"+"V", GridsdtconsumoproductivosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtconsumoproductivosContainerData"+"V"+"\" value='"+GridsdtconsumoproductivosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTGR2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Panel de Control", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPGR0( ) ;
      }

      protected void WSGR2( )
      {
         STARTGR2( ) ;
         EVTGR2( ) ;
      }

      protected void EVTGR2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RUBROSID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_rubrosid.Onoptionclicked */
                              E11GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_MEDIDASID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_medidasid.Onoptionclicked */
                              E12GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changepage */
                              E13GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changerowsperpage */
                              E14GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                              E15GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                              E16GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E17GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOAPLICAR2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAplicar2' */
                              E18GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOAPLICAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAplicar' */
                              E19GR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTRO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20GR2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_107_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              AV50DepartamentoNombre = cgiGet( edtavDepartamentonombre_Internalname);
                              AssignAttri("", false, edtavDepartamentonombre_Internalname, AV50DepartamentoNombre);
                              AV51Capacidad = context.localUtil.CToN( cgiGet( edtavCapacidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              AssignAttri("", false, edtavCapacidad_Internalname, StringUtil.LTrimStr( AV51Capacidad, 18, 2));
                              A830TablaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTablaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A832TablaAuxDepartamentoNombre = cgiGet( edtTablaAuxDepartamentoNombre_Internalname);
                              A833TablaAuxCapacidadProd = context.localUtil.CToN( cgiGet( edtTablaAuxCapacidadProd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A831TablaAuxDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTablaAuxDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_107_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_107_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_107_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E21GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E22GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid1.Load */
                                    E23GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 56), "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 30), "GRIDSDTCONSUMOPRODUCTIVOS.LOAD") == 0 ) )
                           {
                              nGXsfl_154_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
                              SubsflControlProps_1544( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_Rows_" + sGXsfl_154_idx;
                              subGridsdtconsumoproductivos_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_Rows_" + sGXsfl_154_idx;
                              GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Rows), 6, 0, ".", "")));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
                              GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nEOF_" + sGXsfl_154_idx;
                              GRIDSDTCONSUMOPRODUCTIVOS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "nRC_GXsfl_161_" + sGXsfl_154_idx;
                              nRC_GXsfl_161 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid2.Load */
                                    E24GR4 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changepage */
                                    E15GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsdtconsumoproductivospaginationbar.Changerowsperpage */
                                    E16GR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 30), "GRIDSDTCONSUMOPRODUCTIVOS.LOAD") == 0 )
                                 {
                                    nGXsfl_161_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                                    sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
                                    SubsflControlProps_1615( ) ;
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                                    GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_161_idx;
                                    Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                                    ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                                    AV65GXV6 = (int)(nGXsfl_161_idx+GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage);
                                    if ( ( AV47SDTConsumoProductivo.Count >= AV65GXV6 ) && ( AV65GXV6 > 0 ) )
                                    {
                                       AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6));
                                    }
                                    GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_161_idx;
                                    AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                    GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_161_idx;
                                    AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                    GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_161_idx;
                                    AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "GRIDSDTCONSUMOPRODUCTIVOS.LOAD") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          /* Execute user event: Gridsdtconsumoproductivos.Load */
                                          E25GR5 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 )
                           {
                              nGXsfl_140_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
                              SubsflControlProps_1403( ) ;
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Class", Gridsdtconsumoproductivospaginationbar_Class);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowFirst", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowPrevious", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowNext", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingButtonsPosition", Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "PagingCaptionPosition", Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridClass", Gridsdtconsumoproductivospaginationbar_Emptygridclass);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelector", StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageOptions", Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Previous", Gridsdtconsumoproductivospaginationbar_Previous);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Next", Gridsdtconsumoproductivospaginationbar_Next);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "Caption", Gridsdtconsumoproductivospaginationbar_Caption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "EmptyGridCaption", Gridsdtconsumoproductivospaginationbar_Emptygridcaption);
                              GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_140_idx;
                              Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
                              ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageCaption", Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption);
                              AV60GXV1 = (int)(nGXsfl_140_idx+GRID1_nFirstRecordOnPage);
                              if ( ( AV47SDTConsumoProductivo.Count >= AV60GXV1 ) && ( AV60GXV1 > 0 ) )
                              {
                                 AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1));
                                 AV48Aceptados = cgiGet( edtavAceptados_Internalname);
                                 AssignAttri("", false, edtavAceptados_Internalname, AV48Aceptados);
                              }
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_140_idx;
                              AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_140_idx;
                              AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_140_idx;
                              AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E26GR3 ();
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

      protected void WEGR2( )
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

      protected void PAGR2( )
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
               GX_FocusControl = radavFiltro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1072( ) ;
         while ( nGXsfl_107_idx <= nRC_GXsfl_107 )
         {
            sendrow_1072( ) ;
            nGXsfl_107_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_107_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1403( ) ;
         while ( nGXsfl_140_idx <= nRC_GXsfl_140 )
         {
            sendrow_1403( ) ;
            nGXsfl_140_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_140_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1403( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxnrFreestylegrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1544( ) ;
         while ( nGXsfl_154_idx <= nRC_GXsfl_154 )
         {
            sendrow_1544( ) ;
            nGXsfl_154_idx = ((subFreestylegrid2_Islastpage==1)&&(nGXsfl_154_idx+1>subFreestylegrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_154_idx+1);
            sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
            SubsflControlProps_1544( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid2Container)) ;
         /* End function gxnrFreestylegrid2_newrow */
      }

      protected void gxnrGridsdtconsumoproductivos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1615( ) ;
         while ( nGXsfl_161_idx <= nRC_GXsfl_161 )
         {
            sendrow_1615( ) ;
            nGXsfl_161_idx = ((subGridsdtconsumoproductivos_Islastpage==1)&&(nGXsfl_161_idx+1>subGridsdtconsumoproductivos_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_idx+1);
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
            SubsflControlProps_1615( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsdtconsumoproductivosContainer)) ;
         /* End function gxnrGridsdtconsumoproductivos_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( int subGrid1_Rows ,
                                                 int subGridsdtconsumoproductivos_Rows ,
                                                 long AV12DepartamentoId ,
                                                 short AV13RubrosId ,
                                                 string AV26Filtro )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RFGR2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFreestylegrid1_refresh */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int subGridsdtconsumoproductivos_Rows ,
                                        long AV12DepartamentoId ,
                                        short AV13RubrosId ,
                                        GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> AV47SDTConsumoProductivo ,
                                        string AV26Filtro )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFGR3( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGridsdtconsumoproductivos_refresh( int subGrid1_Rows ,
                                                            int subGridsdtconsumoproductivos_Rows ,
                                                            long AV12DepartamentoId ,
                                                            short AV13RubrosId ,
                                                            string AV26Filtro )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord = 0;
         RFGR5( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdtconsumoproductivos_refresh */
      }

      protected void gxgrFreestylegrid2_refresh( int subGrid1_Rows ,
                                                 int subGridsdtconsumoproductivos_Rows ,
                                                 long AV12DepartamentoId ,
                                                 short AV13RubrosId ,
                                                 string AV26Filtro )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID2_nCurrentRecord = 0;
         RFGR4( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFreestylegrid2_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         AssignAttri("", false, "AV26Filtro", AV26Filtro);
         if ( cmbavLocalidadorigen.ItemCount > 0 )
         {
            AV27LocalidadOrigen = cmbavLocalidadorigen.getValidValue(AV27LocalidadOrigen);
            AssignAttri("", false, "AV27LocalidadOrigen", AV27LocalidadOrigen);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLocalidadorigen.CurrentValue = StringUtil.RTrim( AV27LocalidadOrigen);
            AssignProp("", false, cmbavLocalidadorigen_Internalname, "Values", cmbavLocalidadorigen.ToJavascriptSource(), true);
         }
         if ( cmbavLocalidaddestino.ItemCount > 0 )
         {
            AV29LocalidadDestino = cmbavLocalidaddestino.getValidValue(AV29LocalidadDestino);
            AssignAttri("", false, "AV29LocalidadDestino", AV29LocalidadDestino);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLocalidaddestino.CurrentValue = StringUtil.RTrim( AV29LocalidadDestino);
            AssignProp("", false, cmbavLocalidaddestino_Internalname, "Values", cmbavLocalidaddestino.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFGR2( ) ;
         RFGR3( ) ;
         RFGR4( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavDepartamentonombre_Enabled = 0;
         edtavCapacidad_Enabled = 0;
         edtavSdtconsumoproductivo__dia_Enabled = 0;
         edtavSdtconsumoproductivo__horasdisponibles_Enabled = 0;
         edtavSdtconsumoproductivo__horassolicitadas_Enabled = 0;
         edtavSdtconsumoproductivo__horastomadas_Enabled = 0;
         edtavAceptados_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajesolicitado_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajetomadas_Enabled = 0;
         edtavCardlefticon2_value_Enabled = 0;
         AssignProp("", false, edtavCardlefticon2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardlefticon2_value_Enabled), 5, 0), true);
         edtavCardlefticon1_value_Enabled = 0;
         AssignProp("", false, edtavCardlefticon1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardlefticon1_value_Enabled), 5, 0), true);
      }

      protected void RFGR2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E22GR2 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", "");
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1072( ) ;
            /* Using cursor H00GR2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A831TablaAuxDepartamentoId = H00GR2_A831TablaAuxDepartamentoId[0];
               A833TablaAuxCapacidadProd = H00GR2_A833TablaAuxCapacidadProd[0];
               A832TablaAuxDepartamentoNombre = H00GR2_A832TablaAuxDepartamentoNombre[0];
               A830TablaAuxId = H00GR2_A830TablaAuxId[0];
               /* Execute user event: Freestylegrid1.Load */
               E23GR2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 107;
            WBGR0( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGR2( )
      {
      }

      protected void RFGR3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 140;
         /* Execute user event: Refresh */
         E22GR2 ();
         nGXsfl_140_idx = 1;
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1403( ) ;
         bGXsfl_140_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1403( ) ;
            /* Execute user event: Grid1.Load */
            E26GR3 ();
            if ( ( subGrid1_Islastpage == 0 ) && ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_140_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               /* Execute user event: Grid1.Load */
               E26GR3 ();
            }
            wbEnd = 140;
            WBGR0( ) ;
         }
         bGXsfl_140_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGR3( )
      {
      }

      protected void RFGR4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid2Container.ClearRows();
         }
         wbStart = 154;
         /* Execute user event: Refresh */
         E22GR2 ();
         nGXsfl_154_idx = 1;
         sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
         SubsflControlProps_1544( ) ;
         bGXsfl_154_Refreshing = true;
         Freestylegrid2Container.AddObjectProperty("GridName", "Freestylegrid2");
         Freestylegrid2Container.AddObjectProperty("CmpContext", "");
         Freestylegrid2Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid2Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid2Container.PageSize = subFreestylegrid2_fnc_Recordsperpage( );
         if ( subFreestylegrid1_Islastpage != 0 )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(subFreestylegrid1_fnc_Recordcount( )-subFreestylegrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("FREESTYLEGRID1_nFirstRecordOnPage", FREESTYLEGRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1544( ) ;
            /* Execute user event: Freestylegrid2.Load */
            E24GR4 ();
            wbEnd = 154;
            WBGR0( ) ;
         }
         bGXsfl_154_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGR4( )
      {
      }

      protected void RFGR5( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsdtconsumoproductivosContainer.ClearRows();
         }
         wbStart = 161;
         /* Execute user event: Refresh */
         E22GR2 ();
         nGXsfl_161_idx = 1;
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
         SubsflControlProps_1615( ) ;
         bGXsfl_161_Refreshing = true;
         GridsdtconsumoproductivosContainer.AddObjectProperty("GridName", "Gridsdtconsumoproductivos");
         GridsdtconsumoproductivosContainer.AddObjectProperty("CmpContext", "");
         GridsdtconsumoproductivosContainer.AddObjectProperty("InMasterPage", "false");
         GridsdtconsumoproductivosContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridsdtconsumoproductivosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsdtconsumoproductivosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsdtconsumoproductivosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Backcolorstyle), 1, 0, ".", "")));
         GridsdtconsumoproductivosContainer.PageSize = subGridsdtconsumoproductivos_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1615( ) ;
            /* Execute user event: Gridsdtconsumoproductivos.Load */
            E25GR5 ();
            if ( ( subGridsdtconsumoproductivos_Islastpage == 0 ) && ( GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord > 0 ) && ( GRIDSDTCONSUMOPRODUCTIVOS_nGridOutOfScope == 0 ) && ( nGXsfl_161_idx == 1 ) )
            {
               GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord = 0;
               GRIDSDTCONSUMOPRODUCTIVOS_nGridOutOfScope = 1;
               subgridsdtconsumoproductivos_firstpage( ) ;
               /* Execute user event: Gridsdtconsumoproductivos.Load */
               E25GR5 ();
            }
            wbEnd = 161;
            WBGR0( ) ;
         }
         bGXsfl_161_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGR5( )
      {
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return AV47SDTConsumoProductivo.Count ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subFreestylegrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridsdtconsumoproductivos_fnc_Pagecount( )
      {
         GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount = subGridsdtconsumoproductivos_fnc_Recordcount( );
         if ( ((long)((GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount) % (subGridsdtconsumoproductivos_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount/ (decimal)(subGridsdtconsumoproductivos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount/ (decimal)(subGridsdtconsumoproductivos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdtconsumoproductivos_fnc_Recordcount( )
      {
         return AV47SDTConsumoProductivo.Count ;
      }

      protected int subGridsdtconsumoproductivos_fnc_Recordsperpage( )
      {
         if ( subGridsdtconsumoproductivos_Rows > 0 )
         {
            return subGridsdtconsumoproductivos_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdtconsumoproductivos_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage/ (decimal)(subGridsdtconsumoproductivos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdtconsumoproductivos_firstpage( )
      {
         GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = 0;
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtconsumoproductivos_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtconsumoproductivos_nextpage( )
      {
         GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount = subGridsdtconsumoproductivos_fnc_Recordcount( );
         if ( ( GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount >= subGridsdtconsumoproductivos_fnc_Recordsperpage( ) ) && ( GRIDSDTCONSUMOPRODUCTIVOS_nEOF == 0 ) )
         {
            GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage+subGridsdtconsumoproductivos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsdtconsumoproductivosContainer.AddObjectProperty("GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage", GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtconsumoproductivos_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDTCONSUMOPRODUCTIVOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdtconsumoproductivos_previouspage( )
      {
         if ( GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage >= subGridsdtconsumoproductivos_fnc_Recordsperpage( ) )
         {
            GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage-subGridsdtconsumoproductivos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtconsumoproductivos_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtconsumoproductivos_lastpage( )
      {
         GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount = subGridsdtconsumoproductivos_fnc_Recordcount( );
         if ( GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount > subGridsdtconsumoproductivos_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount) % (subGridsdtconsumoproductivos_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount-subGridsdtconsumoproductivos_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount-((long)((GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount) % (subGridsdtconsumoproductivos_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = 0;
         }
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtconsumoproductivos_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdtconsumoproductivos_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(subGridsdtconsumoproductivos_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = 0;
         }
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtconsumoproductivos_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV26Filtro) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavDepartamentonombre_Enabled = 0;
         edtavCapacidad_Enabled = 0;
         edtavSdtconsumoproductivo__dia_Enabled = 0;
         edtavSdtconsumoproductivo__horasdisponibles_Enabled = 0;
         edtavSdtconsumoproductivo__horassolicitadas_Enabled = 0;
         edtavSdtconsumoproductivo__horastomadas_Enabled = 0;
         edtavAceptados_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajesolicitado_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajetomadas_Enabled = 0;
         edtavCardlefticon2_value_Enabled = 0;
         AssignProp("", false, edtavCardlefticon2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardlefticon2_value_Enabled), 5, 0), true);
         edtavCardlefticon1_value_Enabled = 0;
         AssignProp("", false, edtavCardlefticon1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardlefticon1_value_Enabled), 5, 0), true);
         edtTablaAuxId_Enabled = 0;
         edtTablaAuxDepartamentoNombre_Enabled = 0;
         edtTablaAuxCapacidadProd_Enabled = 0;
         edtTablaAuxDepartamentoId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPGR0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E21GR2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtconsumoproductivo"), AV47SDTConsumoProductivo);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV20DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vZONASID_DATA"), AV15ZonasId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDEPARTAMENTOID_DATA"), AV17DepartamentoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRUBROSID_DATA"), AV18RubrosId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vMEDIDASID_DATA"), AV19MedidasId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCALIDADORIGEN_DATA"), AV28LocalidadOrigen_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCALIDADDESTINO_DATA"), AV30LocalidadDestino_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vEVENTS"), AV23Events);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTCONSUMOPRODUCTIVO"), AV47SDTConsumoProductivo);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_107"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_140 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_140"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_154 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_154"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38Grid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRID1CURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39Grid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRID1PAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40Grid1AppliedFilters = cgiGet( "vGRID1APPLIEDFILTERS");
            AV31Origen = cgiGet( "vORIGEN");
            AV32Destino = cgiGet( "vDESTINO");
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDTCONSUMOPRODUCTIVOS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSDTCONSUMOPRODUCTIVOS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFreestylegrid2_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subFreestylegrid2_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Combo_zonasid_Cls = cgiGet( "COMBO_ZONASID_Cls");
            Combo_zonasid_Selectedvalue_set = cgiGet( "COMBO_ZONASID_Selectedvalue_set");
            Combo_zonasid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ZONASID_Visible"));
            Combo_zonasid_Emptyitemtext = cgiGet( "COMBO_ZONASID_Emptyitemtext");
            Combo_departamentoid_Cls = cgiGet( "COMBO_DEPARTAMENTOID_Cls");
            Combo_departamentoid_Selectedvalue_set = cgiGet( "COMBO_DEPARTAMENTOID_Selectedvalue_set");
            Combo_departamentoid_Emptyitemtext = cgiGet( "COMBO_DEPARTAMENTOID_Emptyitemtext");
            Combo_rubrosid_Cls = cgiGet( "COMBO_RUBROSID_Cls");
            Combo_rubrosid_Selectedvalue_set = cgiGet( "COMBO_RUBROSID_Selectedvalue_set");
            Combo_rubrosid_Emptyitemtext = cgiGet( "COMBO_RUBROSID_Emptyitemtext");
            Combo_medidasid_Cls = cgiGet( "COMBO_MEDIDASID_Cls");
            Combo_medidasid_Selectedvalue_set = cgiGet( "COMBO_MEDIDASID_Selectedvalue_set");
            Combo_medidasid_Selectedtext_set = cgiGet( "COMBO_MEDIDASID_Selectedtext_set");
            Combo_medidasid_Datalistproc = cgiGet( "COMBO_MEDIDASID_Datalistproc");
            Combo_medidasid_Datalistprocparametersprefix = cgiGet( "COMBO_MEDIDASID_Datalistprocparametersprefix");
            Combo_medidasid_Emptyitemtext = cgiGet( "COMBO_MEDIDASID_Emptyitemtext");
            Combo_localidadorigen_Cls = cgiGet( "COMBO_LOCALIDADORIGEN_Cls");
            Combo_localidadorigen_Selectedvalue_set = cgiGet( "COMBO_LOCALIDADORIGEN_Selectedvalue_set");
            Combo_localidadorigen_Emptyitemtext = cgiGet( "COMBO_LOCALIDADORIGEN_Emptyitemtext");
            Combo_localidaddestino_Cls = cgiGet( "COMBO_LOCALIDADDESTINO_Cls");
            Combo_localidaddestino_Selectedvalue_set = cgiGet( "COMBO_LOCALIDADDESTINO_Selectedvalue_set");
            Combo_localidaddestino_Emptyitemtext = cgiGet( "COMBO_LOCALIDADDESTINO_Emptyitemtext");
            Dvpanel_unnamedtable5_Width = cgiGet( "DVPANEL_UNNAMEDTABLE5_Width");
            Dvpanel_unnamedtable5_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE5_Autowidth"));
            Dvpanel_unnamedtable5_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE5_Autoheight"));
            Dvpanel_unnamedtable5_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE5_Cls");
            Dvpanel_unnamedtable5_Title = cgiGet( "DVPANEL_UNNAMEDTABLE5_Title");
            Dvpanel_unnamedtable5_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE5_Collapsible"));
            Dvpanel_unnamedtable5_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE5_Collapsed"));
            Dvpanel_unnamedtable5_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE5_Showcollapseicon"));
            Dvpanel_unnamedtable5_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE5_Iconposition");
            Dvpanel_unnamedtable5_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE5_Autoscroll"));
            Dvpanel_unnamedtable6_Width = cgiGet( "DVPANEL_UNNAMEDTABLE6_Width");
            Dvpanel_unnamedtable6_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Autowidth"));
            Dvpanel_unnamedtable6_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Autoheight"));
            Dvpanel_unnamedtable6_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE6_Cls");
            Dvpanel_unnamedtable6_Title = cgiGet( "DVPANEL_UNNAMEDTABLE6_Title");
            Dvpanel_unnamedtable6_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Collapsible"));
            Dvpanel_unnamedtable6_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Collapsed"));
            Dvpanel_unnamedtable6_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Showcollapseicon"));
            Dvpanel_unnamedtable6_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE6_Iconposition");
            Dvpanel_unnamedtable6_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Autoscroll"));
            Grid1paginationbar_Class = cgiGet( "GRID1PAGINATIONBAR_Class");
            Grid1paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showfirst"));
            Grid1paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showprevious"));
            Grid1paginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Shownext"));
            Grid1paginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showlast"));
            Grid1paginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Pagingbuttonsposition = cgiGet( "GRID1PAGINATIONBAR_Pagingbuttonsposition");
            Grid1paginationbar_Pagingcaptionposition = cgiGet( "GRID1PAGINATIONBAR_Pagingcaptionposition");
            Grid1paginationbar_Emptygridclass = cgiGet( "GRID1PAGINATIONBAR_Emptygridclass");
            Grid1paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselector"));
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Rowsperpageoptions = cgiGet( "GRID1PAGINATIONBAR_Rowsperpageoptions");
            Grid1paginationbar_Previous = cgiGet( "GRID1PAGINATIONBAR_Previous");
            Grid1paginationbar_Next = cgiGet( "GRID1PAGINATIONBAR_Next");
            Grid1paginationbar_Caption = cgiGet( "GRID1PAGINATIONBAR_Caption");
            Grid1paginationbar_Emptygridcaption = cgiGet( "GRID1PAGINATIONBAR_Emptygridcaption");
            Grid1paginationbar_Rowsperpagecaption = cgiGet( "GRID1PAGINATIONBAR_Rowsperpagecaption");
            Utchartstackedbar_Selectable = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Selectable"));
            Utchartstackedbar_Viewstyle = cgiGet( "UTCHARTSTACKEDBAR_Viewstyle");
            Utchartstackedbar_Defaulteventstyle = cgiGet( "UTCHARTSTACKEDBAR_Defaulteventstyle");
            Utchartstackedbar_Enableweekends = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Enableweekends"));
            Utchartstackedbar_Enabledayheaders = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Enabledayheaders"));
            Utchartstackedbar_Enableeventshoursperday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Enableeventshoursperday"));
            Utchartstackedbar_Navlinks = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Navlinks"));
            Utchartstackedbar_Includeupdateinpopup = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Includeupdateinpopup"));
            Utchartstackedbar_Includedeleteinpopup = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Includedeleteinpopup"));
            Utchartstackedbar_Nowindicator = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Nowindicator"));
            Utchartstackedbar_Daymaxevents = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UTCHARTSTACKEDBAR_Daymaxevents"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Utchartstackedbar_Shownoncurrentdates = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Shownoncurrentdates"));
            Utchartstackedbar_Titleposition = cgiGet( "UTCHARTSTACKEDBAR_Titleposition");
            Utchartstackedbar_Monthbuttonposition = cgiGet( "UTCHARTSTACKEDBAR_Monthbuttonposition");
            Utchartstackedbar_Weekbuttonposition = cgiGet( "UTCHARTSTACKEDBAR_Weekbuttonposition");
            Utchartstackedbar_Daybuttonposition = cgiGet( "UTCHARTSTACKEDBAR_Daybuttonposition");
            Utchartstackedbar_Listbuttonposition = cgiGet( "UTCHARTSTACKEDBAR_Listbuttonposition");
            Utchartstackedbar_Sunday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Sunday"));
            Utchartstackedbar_Monday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Monday"));
            Utchartstackedbar_Tuesday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Tuesday"));
            Utchartstackedbar_Wednesday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Wednesday"));
            Utchartstackedbar_Thursday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Thursday"));
            Utchartstackedbar_Friday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Friday"));
            Utchartstackedbar_Saturday = StringUtil.StrToBool( cgiGet( "UTCHARTSTACKEDBAR_Saturday"));
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Dvpanel_cardlefticon2_maintable_Width = cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Width");
            Dvpanel_cardlefticon2_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Autowidth"));
            Dvpanel_cardlefticon2_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Autoheight"));
            Dvpanel_cardlefticon2_maintable_Cls = cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Cls");
            Dvpanel_cardlefticon2_maintable_Title = cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Title");
            Dvpanel_cardlefticon2_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Collapsible"));
            Dvpanel_cardlefticon2_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Collapsed"));
            Dvpanel_cardlefticon2_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardlefticon2_maintable_Iconposition = cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Iconposition");
            Dvpanel_cardlefticon2_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON2_MAINTABLE_Autoscroll"));
            Dvpanel_cardlefticon1_maintable_Width = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Width");
            Dvpanel_cardlefticon1_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Autowidth"));
            Dvpanel_cardlefticon1_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoheight"));
            Dvpanel_cardlefticon1_maintable_Cls = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Cls");
            Dvpanel_cardlefticon1_maintable_Title = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Title");
            Dvpanel_cardlefticon1_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsible"));
            Dvpanel_cardlefticon1_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Collapsed"));
            Dvpanel_cardlefticon1_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardlefticon1_maintable_Iconposition = cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Iconposition");
            Dvpanel_cardlefticon1_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDLEFTICON1_MAINTABLE_Autoscroll"));
            Grid1_titlescategories_Gridinternalname = cgiGet( "GRID1_TITLESCATEGORIES_Gridinternalname");
            Grid1_titlescategories_Gridtitlescategories = cgiGet( "GRID1_TITLESCATEGORIES_Gridtitlescategories");
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Grid1_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRID1_EMPOWERER_Hascategories"));
            Gridsdtconsumoproductivos_empowerer_Gridinternalname = cgiGet( "GRIDSDTCONSUMOPRODUCTIVOS_EMPOWERER_Gridinternalname");
            subFreestylegrid1_Class = cgiGet( "FREESTYLEGRID1_Class");
            Grid1paginationbar_Selectedpage = cgiGet( "GRID1PAGINATIONBAR_Selectedpage");
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsdtconsumoproductivospaginationbar_Selectedpage = cgiGet( "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Selectedpage");
            Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Combo_medidasid_Selectedvalue_get = cgiGet( "COMBO_MEDIDASID_Selectedvalue_get");
            Combo_rubrosid_Selectedvalue_get = cgiGet( "COMBO_RUBROSID_Selectedvalue_get");
            nRC_GXsfl_140 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_140"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_140_fel_idx = 0;
            while ( nGXsfl_140_fel_idx < nRC_GXsfl_140 )
            {
               nGXsfl_140_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_140_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_fel_idx+1);
               sGXsfl_140_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1403( ) ;
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_140_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
               AV60GXV1 = (int)(nGXsfl_140_fel_idx+GRID1_nFirstRecordOnPage);
               if ( ( AV47SDTConsumoProductivo.Count >= AV60GXV1 ) && ( AV60GXV1 > 0 ) )
               {
                  AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1));
                  AV48Aceptados = cgiGet( edtavAceptados_Internalname);
               }
               GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_140_fel_idx;
               AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_140_fel_idx;
               AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_140_fel_idx;
               AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
            }
            if ( nGXsfl_140_fel_idx == 0 )
            {
               nGXsfl_140_idx = 1;
               sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
               SubsflControlProps_1403( ) ;
            }
            nGXsfl_140_fel_idx = 1;
            GXCCtl = "nRC_GXsfl_161_" + sGXsfl_154_idx;
            nRC_GXsfl_161 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_161_fel_idx = 0;
            while ( nGXsfl_161_fel_idx < nRC_GXsfl_161 )
            {
               nGXsfl_161_fel_idx = ((subGridsdtconsumoproductivos_Islastpage==1)&&(nGXsfl_161_fel_idx+1>subGridsdtconsumoproductivos_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_fel_idx+1);
               sGXsfl_161_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_fel_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
               SubsflControlProps_fel_1615( ) ;
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Class = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Emptygridclass = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Previous = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Next = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Caption = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Emptygridcaption = cgiGet( GXCCtl);
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_161_fel_idx;
               Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = cgiGet( GXCCtl);
               AV65GXV6 = (int)(nGXsfl_161_fel_idx+GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage);
               if ( ( AV47SDTConsumoProductivo.Count >= AV65GXV6 ) && ( AV65GXV6 > 0 ) )
               {
                  AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6));
               }
               GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_161_fel_idx;
               AV56GridSDTConsumoProductivosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_161_fel_idx;
               AV57GridSDTConsumoProductivosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_161_fel_idx;
               AV58GridSDTConsumoProductivosAppliedFilters = cgiGet( GXCCtl);
            }
            if ( nGXsfl_161_fel_idx == 0 )
            {
               nGXsfl_161_idx = 1;
               sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
               SubsflControlProps_1615( ) ;
            }
            nGXsfl_161_fel_idx = 1;
            /* Read variables values. */
            AV26Filtro = cgiGet( radavFiltro_Internalname);
            AssignAttri("", false, "AV26Filtro", AV26Filtro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardlefticon2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardlefticon2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDLEFTICON2_VALUE");
               GX_FocusControl = edtavCardlefticon2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33CardLeftIcon2_Value = 0;
               AssignAttri("", false, "AV33CardLeftIcon2_Value", StringUtil.LTrimStr( (decimal)(AV33CardLeftIcon2_Value), 8, 0));
            }
            else
            {
               AV33CardLeftIcon2_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardlefticon2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33CardLeftIcon2_Value", StringUtil.LTrimStr( (decimal)(AV33CardLeftIcon2_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardlefticon1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardlefticon1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDLEFTICON1_VALUE");
               GX_FocusControl = edtavCardlefticon1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34CardLeftIcon1_Value = 0;
               AssignAttri("", false, "AV34CardLeftIcon1_Value", StringUtil.LTrimStr( (decimal)(AV34CardLeftIcon1_Value), 8, 0));
            }
            else
            {
               AV34CardLeftIcon1_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardlefticon1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV34CardLeftIcon1_Value", StringUtil.LTrimStr( (decimal)(AV34CardLeftIcon1_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavZonasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavZonasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vZONASID");
               GX_FocusControl = edtavZonasid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ZonasId = 0;
               AssignAttri("", false, "AV11ZonasId", StringUtil.LTrimStr( (decimal)(AV11ZonasId), 18, 0));
            }
            else
            {
               AV11ZonasId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavZonasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11ZonasId", StringUtil.LTrimStr( (decimal)(AV11ZonasId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDEPARTAMENTOID");
               GX_FocusControl = edtavDepartamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12DepartamentoId = 0;
               AssignAttri("", false, "AV12DepartamentoId", StringUtil.LTrimStr( (decimal)(AV12DepartamentoId), 18, 0));
            }
            else
            {
               AV12DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavDepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12DepartamentoId", StringUtil.LTrimStr( (decimal)(AV12DepartamentoId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRUBROSID");
               GX_FocusControl = edtavRubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13RubrosId = 0;
               AssignAttri("", false, "AV13RubrosId", StringUtil.LTrimStr( (decimal)(AV13RubrosId), 4, 0));
            }
            else
            {
               AV13RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavRubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13RubrosId", StringUtil.LTrimStr( (decimal)(AV13RubrosId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMedidasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMedidasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMEDIDASID");
               GX_FocusControl = edtavMedidasid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14MedidasId = 0;
               AssignAttri("", false, "AV14MedidasId", StringUtil.LTrimStr( (decimal)(AV14MedidasId), 18, 0));
            }
            else
            {
               AV14MedidasId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavMedidasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14MedidasId", StringUtil.LTrimStr( (decimal)(AV14MedidasId), 18, 0));
            }
            cmbavLocalidadorigen.Name = cmbavLocalidadorigen_Internalname;
            cmbavLocalidadorigen.CurrentValue = cgiGet( cmbavLocalidadorigen_Internalname);
            AV27LocalidadOrigen = cgiGet( cmbavLocalidadorigen_Internalname);
            AssignAttri("", false, "AV27LocalidadOrigen", AV27LocalidadOrigen);
            cmbavLocalidaddestino.Name = cmbavLocalidaddestino_Internalname;
            cmbavLocalidaddestino.CurrentValue = cgiGet( cmbavLocalidaddestino_Internalname);
            AV29LocalidadDestino = cgiGet( cmbavLocalidaddestino_Internalname);
            AssignAttri("", false, "AV29LocalidadDestino", AV29LocalidadDestino);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E21GR2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21GR2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = AV23Events;
         new wwp_calendar_getevent(context ).execute(  AV26Filtro,  AV11ZonasId,  AV12DepartamentoId,  AV13RubrosId,  AV14MedidasId,  StringUtil.Trim( AV31Origen),  StringUtil.Trim( AV32Destino), out  GXt_objcol_SdtWWP_Calendar_Events_Item1) ;
         AV23Events = GXt_objcol_SdtWWP_Calendar_Events_Item1;
         Utchartstackedbar_Enabledayheaders = true;
         ucUtchartstackedbar.SendProperty(context, "", false, Utchartstackedbar_Internalname, "EnableDayHeaders", StringUtil.BoolToStr( Utchartstackedbar_Enabledayheaders));
         Utchartstackedbar_Enableweekends = true;
         ucUtchartstackedbar.SendProperty(context, "", false, Utchartstackedbar_Internalname, "EnableWeekends", StringUtil.BoolToStr( Utchartstackedbar_Enableweekends));
         divTableservicios_Visible = 0;
         AssignProp("", false, divTableservicios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableservicios_Visible), 5, 0), true);
         divTablemudanzas_Visible = 0;
         AssignProp("", false, divTablemudanzas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemudanzas_Visible), 5, 0), true);
         GXt_int2 = AV42Limite;
         new oparametros(context ).execute(  context.GetMessage( "DiasLimite", ""), out  AV44ParametrosVarchar, out  GXt_int2, out  AV45ParametrosEstado) ;
         AV42Limite = Convert.ToInt16(GXt_int2);
         GXt_int3 = AV43Saturado;
         new oparametros(context ).execute(  context.GetMessage( "DiaSaturado", ""), out  AV44ParametrosVarchar, out  GXt_int3, out  AV45ParametrosEstado) ;
         AV43Saturado = Convert.ToInt16(GXt_int3);
         divTablechart1_Height = 447;
         AssignProp("", false, divTablechart1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart1_Height), 9, 0), true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV20DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV20DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         cmbavLocalidaddestino.Visible = 0;
         AssignProp("", false, cmbavLocalidaddestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLocalidaddestino.Visible), 5, 0), true);
         cmbavLocalidadorigen.Visible = 0;
         AssignProp("", false, cmbavLocalidadorigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLocalidadorigen.Visible), 5, 0), true);
         edtavMedidasid_Visible = 0;
         AssignProp("", false, edtavMedidasid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMedidasid_Visible), 5, 0), true);
         edtavRubrosid_Visible = 0;
         AssignProp("", false, edtavRubrosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosid_Visible), 5, 0), true);
         edtavDepartamentoid_Visible = 0;
         AssignProp("", false, edtavDepartamentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDepartamentoid_Visible), 5, 0), true);
         edtavZonasid_Visible = 0;
         AssignProp("", false, edtavZonasid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavZonasid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOZONASID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBODEPARTAMENTOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBORUBROSID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOMEDIDASID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOLOCALIDADORIGEN' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOLOCALIDADDESTINO' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         Grid1_titlescategories_Gridinternalname = subGrid1_Internalname;
         ucGrid1_titlescategories.SendProperty(context, "", false, Grid1_titlescategories_Internalname, "GridInternalName", Grid1_titlescategories_Gridinternalname);
         Grid1_titlescategories_Gridtitlescategories = StringUtil.Format( "%1;%1;%1;%1;", context.GetMessage( "Servicios", ""), "", "", "", "", "", "", "", "");
         ucGrid1_titlescategories.SendProperty(context, "", false, Grid1_titlescategories_Internalname, "GridTitlesCategories", Grid1_titlescategories_Gridtitlescategories);
         Gridsdtconsumoproductivos_empowerer_Gridinternalname = subGridsdtconsumoproductivos_Internalname;
         ucGridsdtconsumoproductivos_empowerer.SendProperty(context, "", false, Gridsdtconsumoproductivos_empowerer_Internalname, "GridInternalName", Gridsdtconsumoproductivos_empowerer_Gridinternalname);
         subGridsdtconsumoproductivos_Rows = 50;
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_Rows_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Rows), 6, 0, ".", "")));
         edtTablaAuxId_Visible = 0;
         AssignProp("", false, edtTablaAuxId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxId_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxDepartamentoNombre_Visible = 0;
         AssignProp("", false, edtTablaAuxDepartamentoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoNombre_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxCapacidadProd_Visible = 0;
         AssignProp("", false, edtTablaAuxCapacidadProd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxCapacidadProd_Visible), 5, 0), !bGXsfl_107_Refreshing);
         edtTablaAuxDepartamentoId_Visible = 0;
         AssignProp("", false, edtTablaAuxDepartamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTablaAuxDepartamentoId_Visible), 5, 0), !bGXsfl_107_Refreshing);
         Grid1paginationbar_Rowsperpageselectedvalue = subGrid1_Rows;
         ucGrid1paginationbar.SendProperty(context, "", false, Grid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0));
         Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = subGridsdtconsumoproductivos_Rows;
         ucGridsdtconsumoproductivospaginationbar.SendProperty(context, "", false, Gridsdtconsumoproductivospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_decimal5 = AV46CapacidadProductiva;
         new ocapacidadproductivaalmango(context ).execute(  AV12DepartamentoId,  AV13RubrosId, out  GXt_decimal5) ;
         AV46CapacidadProductiva = GXt_decimal5;
         GX_msglist.addItem(context.localUtil.Format( AV46CapacidadProductiva, "ZZZZZZ9.99"));
      }

      protected void E22GR2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GX_msglist.addItem(context.GetMessage( "&DepartamentoId: ", "")+StringUtil.Str( (decimal)(AV12DepartamentoId), 18, 0));
         GX_msglist.addItem(context.GetMessage( "&RubrosId: ", "")+StringUtil.Str( (decimal)(AV13RubrosId), 4, 0));
         GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6 = AV47SDTConsumoProductivo;
         new oconsumoproductivo(context ).execute(  AV12DepartamentoId,  AV13RubrosId, out  GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6) ;
         AV47SDTConsumoProductivo = GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6;
         gx_BV140 = true;
         GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6 = AV52SDTConsumoProd;
         new oconsumoproductivo(context ).execute(  0,  0, out  GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6) ;
         AV52SDTConsumoProd = GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6;
         AV38Grid1CurrentPage = subGrid1_fnc_Currentpage( );
         AssignAttri("", false, "AV38Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV38Grid1CurrentPage), 10, 0));
         AV39Grid1PageCount = subGrid1_fnc_Pagecount( );
         AssignAttri("", false, "AV39Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV39Grid1PageCount), 10, 0));
         edtavSdtconsumoproductivo__dia_Columnheaderclass = "WWColumn ColumnWeightBold ColumnAlignCenter";
         AssignProp("", false, edtavSdtconsumoproductivo__dia_Internalname, "Columnheaderclass", edtavSdtconsumoproductivo__dia_Columnheaderclass, !bGXsfl_140_Refreshing);
         edtavSdtconsumoproductivo__horasdisponibles_Columnheaderclass = "WWColumn ColumnAlignCenter";
         AssignProp("", false, edtavSdtconsumoproductivo__horasdisponibles_Internalname, "Columnheaderclass", edtavSdtconsumoproductivo__horasdisponibles_Columnheaderclass, !bGXsfl_140_Refreshing);
         edtavSdtconsumoproductivo__horassolicitadas_Columnheaderclass = "WWColumn ColumnAlignCenter";
         AssignProp("", false, edtavSdtconsumoproductivo__horassolicitadas_Internalname, "Columnheaderclass", edtavSdtconsumoproductivo__horassolicitadas_Columnheaderclass, !bGXsfl_140_Refreshing);
         edtavAceptados_Columnheaderclass = "WWColumn ColumnAlignLeft";
         AssignProp("", false, edtavAceptados_Internalname, "Columnheaderclass", edtavAceptados_Columnheaderclass, !bGXsfl_140_Refreshing);
         AV56GridSDTConsumoProductivosCurrentPage = subGridsdtconsumoproductivos_fnc_Currentpage( );
         AssignAttri("", false, "AV56GridSDTConsumoProductivosCurrentPage", StringUtil.LTrimStr( (decimal)(AV56GridSDTConsumoProductivosCurrentPage), 10, 0));
         AV57GridSDTConsumoProductivosPageCount = subGridsdtconsumoproductivos_fnc_Pagecount( );
         AssignAttri("", false, "AV57GridSDTConsumoProductivosPageCount", StringUtil.LTrimStr( (decimal)(AV57GridSDTConsumoProductivosPageCount), 10, 0));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47SDTConsumoProductivo", AV47SDTConsumoProductivo);
      }

      private void E23GR2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         edtavDepartamentonombre_Fontbold = 1;
         AV50DepartamentoNombre = A832TablaAuxDepartamentoNombre;
         AssignAttri("", false, edtavDepartamentonombre_Internalname, AV50DepartamentoNombre);
         AV51Capacidad = A833TablaAuxCapacidadProd;
         AssignAttri("", false, edtavCapacidad_Internalname, StringUtil.LTrimStr( AV51Capacidad, 18, 2));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 107;
         }
         sendrow_1072( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_107_Refreshing )
         {
            context.DoAjaxLoad(107, Freestylegrid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E13GR2( )
      {
         /* Grid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV37PageToGo = subGrid1_fnc_Currentpage( );
            AV37PageToGo = (int)(AV37PageToGo+1);
            subgrid1_gotopage( AV37PageToGo) ;
         }
         else
         {
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Grid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid1_gotopage( AV37PageToGo) ;
         }
         /*  Sending Event outputs  */
         if ( gx_BV140 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47SDTConsumoProductivo", AV47SDTConsumoProductivo);
            nGXsfl_140_bak_idx = nGXsfl_140_idx;
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
            nGXsfl_140_idx = nGXsfl_140_bak_idx;
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1403( ) ;
         }
      }

      protected void E14GR2( )
      {
         /* Grid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid1_Rows = Grid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         subgrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15GR2( )
      {
         /* Gridsdtconsumoproductivospaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsdtconsumoproductivospaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgridsdtconsumoproductivos_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsdtconsumoproductivospaginationbar_Selectedpage, "Next") == 0 )
         {
            AV37PageToGo = subGridsdtconsumoproductivos_fnc_Currentpage( );
            AV37PageToGo = (int)(AV37PageToGo+1);
            subgridsdtconsumoproductivos_gotopage( AV37PageToGo) ;
         }
         else
         {
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Gridsdtconsumoproductivospaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgridsdtconsumoproductivos_gotopage( AV37PageToGo) ;
         }
         /*  Sending Event outputs  */
         if ( gx_BV140 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47SDTConsumoProductivo", AV47SDTConsumoProductivo);
            nGXsfl_140_bak_idx = nGXsfl_140_idx;
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
            nGXsfl_140_idx = nGXsfl_140_bak_idx;
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1403( ) ;
         }
      }

      protected void E16GR2( )
      {
         /* Gridsdtconsumoproductivospaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsdtconsumoproductivos_Rows = Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue;
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_Rows_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Rows), 6, 0, ".", "")));
         subgridsdtconsumoproductivos_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E17GR2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         GXt_char7 = AV49LongVarChar;
         new obtenercapacidadproductiva(context ).execute( out  GXt_char7) ;
         AV49LongVarChar = GXt_char7;
         GX_msglist.addItem(AV49LongVarChar);
      }

      protected void E18GR2( )
      {
         /* 'DoAplicar2' Routine */
         returnInSub = false;
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = AV23Events;
         new wwp_calendar_getevent(context ).execute(  AV26Filtro,  AV11ZonasId,  AV12DepartamentoId,  AV13RubrosId,  AV14MedidasId,  StringUtil.Trim( AV31Origen),  StringUtil.Trim( AV32Destino), out  GXt_objcol_SdtWWP_Calendar_Events_Item1) ;
         AV23Events = GXt_objcol_SdtWWP_Calendar_Events_Item1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23Events", AV23Events);
      }

      protected void E19GR2( )
      {
         AV60GXV1 = (int)(nGXsfl_140_idx+GRID1_nFirstRecordOnPage);
         if ( ( AV60GXV1 > 0 ) && ( AV47SDTConsumoProductivo.Count >= AV60GXV1 ) )
         {
            AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1));
         }
         AV65GXV6 = (int)(nGXsfl_161_idx+GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage);
         if ( ( AV65GXV6 > 0 ) && ( AV47SDTConsumoProductivo.Count >= AV65GXV6 ) )
         {
            AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6));
         }
         /* 'DoAplicar' Routine */
         returnInSub = false;
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = AV23Events;
         new wwp_calendar_getevent(context ).execute(  AV26Filtro,  AV11ZonasId,  AV12DepartamentoId,  AV13RubrosId,  AV14MedidasId,  StringUtil.Trim( AV31Origen),  StringUtil.Trim( AV32Destino), out  GXt_objcol_SdtWWP_Calendar_Events_Item1) ;
         AV23Events = GXt_objcol_SdtWWP_Calendar_Events_Item1;
         AV47SDTConsumoProductivo.Clear();
         gx_BV140 = true;
         GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6 = AV47SDTConsumoProductivo;
         new oconsumoproductivo(context ).execute(  AV12DepartamentoId,  AV13RubrosId, out  GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6) ;
         AV47SDTConsumoProductivo = GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6;
         gx_BV140 = true;
         GXt_decimal5 = AV46CapacidadProductiva;
         new ocapacidadproductivaalmango(context ).execute(  AV12DepartamentoId,  AV13RubrosId, out  GXt_decimal5) ;
         AV46CapacidadProductiva = GXt_decimal5;
         GX_msglist.addItem(context.localUtil.Format( AV46CapacidadProductiva, "ZZZZZZ9.99"));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23Events", AV23Events);
         if ( gx_BV140 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47SDTConsumoProductivo", AV47SDTConsumoProductivo);
            nGXsfl_140_bak_idx = nGXsfl_140_idx;
            gxgrGrid1_refresh( subGrid1_Rows, subGridsdtconsumoproductivos_Rows, AV12DepartamentoId, AV13RubrosId, AV47SDTConsumoProductivo, AV26Filtro) ;
            nGXsfl_140_idx = nGXsfl_140_bak_idx;
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1403( ) ;
         }
      }

      protected void E12GR2( )
      {
         /* Combo_medidasid_Onoptionclicked Routine */
         returnInSub = false;
         AV14MedidasId = (long)(Math.Round(NumberUtil.Val( Combo_medidasid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV14MedidasId", StringUtil.LTrimStr( (decimal)(AV14MedidasId), 18, 0));
         /*  Sending Event outputs  */
      }

      protected void E11GR2( )
      {
         /* Combo_rubrosid_Onoptionclicked Routine */
         returnInSub = false;
         AV21Cond_RubrosId = AV13RubrosId;
         AssignAttri("", false, "AV21Cond_RubrosId", StringUtil.LTrimStr( (decimal)(AV21Cond_RubrosId), 4, 0));
         AV13RubrosId = (short)(Math.Round(NumberUtil.Val( Combo_rubrosid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV13RubrosId", StringUtil.LTrimStr( (decimal)(AV13RubrosId), 4, 0));
         if ( AV21Cond_RubrosId != AV13RubrosId )
         {
            AV14MedidasId = 0;
            AssignAttri("", false, "AV14MedidasId", StringUtil.LTrimStr( (decimal)(AV14MedidasId), 18, 0));
            Combo_medidasid_Selectedvalue_set = "";
            ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedValue_set", Combo_medidasid_Selectedvalue_set);
            Combo_medidasid_Selectedtext_set = "";
            ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedText_set", Combo_medidasid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( 1 == 0 ) ) )
         {
            Combo_zonasid_Visible = false;
            ucCombo_zonasid.SendProperty(context, "", false, Combo_zonasid_Internalname, "Visible", StringUtil.BoolToStr( Combo_zonasid_Visible));
            divCombo_zonasid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_zonasid_cell_Internalname, "Class", divCombo_zonasid_cell_Class, true);
         }
         else
         {
            Combo_zonasid_Visible = true;
            ucCombo_zonasid.SendProperty(context, "", false, Combo_zonasid_Internalname, "Visible", StringUtil.BoolToStr( Combo_zonasid_Visible));
            divCombo_zonasid_cell_Class = "col-xs-12 CellPaddingTop10 ExtendedComboCell";
            AssignProp("", false, divCombo_zonasid_cell_Internalname, "Class", divCombo_zonasid_cell_Class, true);
         }
      }

      protected void S162( )
      {
         /* 'LOADCOMBOLOCALIDADDESTINO' Routine */
         returnInSub = false;
         /* Using cursor H00GR3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A789MudanzaLocalidadDestino = H00GR3_A789MudanzaLocalidadDestino[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = A789MudanzaLocalidadDestino;
            AV16Combo_DataItem.gxTpr_Title = A789MudanzaLocalidadDestino;
            AV30LocalidadDestino_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_localidaddestino_Selectedvalue_set = AV29LocalidadDestino;
         ucCombo_localidaddestino.SendProperty(context, "", false, Combo_localidaddestino_Internalname, "SelectedValue_set", Combo_localidaddestino_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOLOCALIDADORIGEN' Routine */
         returnInSub = false;
         /* Using cursor H00GR4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A788MudanzaLocalidadOrigen = H00GR4_A788MudanzaLocalidadOrigen[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = A788MudanzaLocalidadOrigen;
            AV16Combo_DataItem.gxTpr_Title = A788MudanzaLocalidadOrigen;
            AV28LocalidadOrigen_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_localidadorigen_Selectedvalue_set = AV27LocalidadOrigen;
         ucCombo_localidadorigen.SendProperty(context, "", false, Combo_localidadorigen_Internalname, "SelectedValue_set", Combo_localidadorigen_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOMEDIDASID' Routine */
         returnInSub = false;
         Combo_medidasid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"MedidasId\", \"Cond_RubrosId\": \"#%1#\"", edtavRubrosid_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "DataListProcParametersPrefix", Combo_medidasid_Datalistprocparametersprefix);
         AV21Cond_RubrosId = AV13RubrosId;
         AssignAttri("", false, "AV21Cond_RubrosId", StringUtil.LTrimStr( (decimal)(AV21Cond_RubrosId), 4, 0));
         AV71GXLvl383 = 0;
         /* Using cursor H00GR5 */
         pr_default.execute(3, new Object[] {AV21Cond_RubrosId, AV14MedidasId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A121RubrosId = H00GR5_A121RubrosId[0];
            A137MedidasID = H00GR5_A137MedidasID[0];
            A138MedidasNombre = H00GR5_A138MedidasNombre[0];
            AV71GXLvl383 = 1;
            Combo_medidasid_Selectedtext_set = A138MedidasNombre;
            ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedText_set", Combo_medidasid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( AV71GXLvl383 == 0 )
         {
            Combo_medidasid_Selectedtext_set = "";
            ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedText_set", Combo_medidasid_Selectedtext_set);
         }
         Combo_medidasid_Selectedvalue_set = ((0==AV14MedidasId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV14MedidasId), 18, 0)));
         ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedValue_set", Combo_medidasid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBORUBROSID' Routine */
         returnInSub = false;
         /* Using cursor H00GR6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A121RubrosId = H00GR6_A121RubrosId[0];
            A122RubrosNombre = H00GR6_A122RubrosNombre[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
            AV16Combo_DataItem.gxTpr_Title = A122RubrosNombre;
            AV18RubrosId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_rubrosid_Selectedvalue_set = ((0==AV13RubrosId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV13RubrosId), 4, 0)));
         ucCombo_rubrosid.SendProperty(context, "", false, Combo_rubrosid_Internalname, "SelectedValue_set", Combo_rubrosid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBODEPARTAMENTOID' Routine */
         returnInSub = false;
         /* Using cursor H00GR7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A112DepartamentoId = H00GR7_A112DepartamentoId[0];
            A113DepartamentoDepartamento = H00GR7_A113DepartamentoDepartamento[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AV16Combo_DataItem.gxTpr_Title = A113DepartamentoDepartamento;
            AV17DepartamentoId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_departamentoid_Selectedvalue_set = ((0==AV12DepartamentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV12DepartamentoId), 18, 0)));
         ucCombo_departamentoid.SendProperty(context, "", false, Combo_departamentoid_Internalname, "SelectedValue_set", Combo_departamentoid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOZONASID' Routine */
         returnInSub = false;
         /* Using cursor H00GR8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A110ZonasID = H00GR8_A110ZonasID[0];
            A111ZonasNombre = H00GR8_A111ZonasNombre[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
            AV16Combo_DataItem.gxTpr_Title = A111ZonasNombre;
            AV15ZonasId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         Combo_zonasid_Selectedvalue_set = ((0==AV11ZonasId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV11ZonasId), 18, 0)));
         ucCombo_zonasid.SendProperty(context, "", false, Combo_zonasid_Internalname, "SelectedValue_set", Combo_zonasid_Selectedvalue_set);
      }

      protected void E20GR2( )
      {
         /* Filtro_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Filtro, context.GetMessage( "Servicios", "")) == 0 )
         {
            divTableservicios_Visible = 1;
            AssignProp("", false, divTableservicios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableservicios_Visible), 5, 0), true);
            divTablemudanzas_Visible = 0;
            AssignProp("", false, divTablemudanzas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemudanzas_Visible), 5, 0), true);
            AV27LocalidadOrigen = "";
            AssignAttri("", false, "AV27LocalidadOrigen", AV27LocalidadOrigen);
            Combo_localidadorigen_Selectedvalue_set = "";
            ucCombo_localidadorigen.SendProperty(context, "", false, Combo_localidadorigen_Internalname, "SelectedValue_set", Combo_localidadorigen_Selectedvalue_set);
            AV31Origen = "";
            AssignAttri("", false, "AV31Origen", AV31Origen);
            AV29LocalidadDestino = "";
            AssignAttri("", false, "AV29LocalidadDestino", AV29LocalidadDestino);
            Combo_localidaddestino_Selectedvalue_set = "";
            ucCombo_localidaddestino.SendProperty(context, "", false, Combo_localidaddestino_Internalname, "SelectedValue_set", Combo_localidaddestino_Selectedvalue_set);
            AV32Destino = "";
            AssignAttri("", false, "AV32Destino", AV32Destino);
         }
         else if ( StringUtil.StrCmp(AV26Filtro, context.GetMessage( "Mudanzas", "")) == 0 )
         {
            divTableservicios_Visible = 0;
            AssignProp("", false, divTableservicios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableservicios_Visible), 5, 0), true);
            divTablemudanzas_Visible = 1;
            AssignProp("", false, divTablemudanzas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemudanzas_Visible), 5, 0), true);
            AV11ZonasId = 0;
            AssignAttri("", false, "AV11ZonasId", StringUtil.LTrimStr( (decimal)(AV11ZonasId), 18, 0));
            Combo_zonasid_Selectedvalue_set = "";
            ucCombo_zonasid.SendProperty(context, "", false, Combo_zonasid_Internalname, "SelectedValue_set", Combo_zonasid_Selectedvalue_set);
            AV12DepartamentoId = 0;
            AssignAttri("", false, "AV12DepartamentoId", StringUtil.LTrimStr( (decimal)(AV12DepartamentoId), 18, 0));
            Combo_departamentoid_Selectedvalue_set = "";
            ucCombo_departamentoid.SendProperty(context, "", false, Combo_departamentoid_Internalname, "SelectedValue_set", Combo_departamentoid_Selectedvalue_set);
            AV13RubrosId = 0;
            AssignAttri("", false, "AV13RubrosId", StringUtil.LTrimStr( (decimal)(AV13RubrosId), 4, 0));
            Combo_rubrosid_Selectedvalue_set = "";
            ucCombo_rubrosid.SendProperty(context, "", false, Combo_rubrosid_Internalname, "SelectedValue_set", Combo_rubrosid_Selectedvalue_set);
            AV14MedidasId = 0;
            AssignAttri("", false, "AV14MedidasId", StringUtil.LTrimStr( (decimal)(AV14MedidasId), 18, 0));
            Combo_medidasid_Selectedvalue_set = "";
            ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedValue_set", Combo_medidasid_Selectedvalue_set);
         }
         else
         {
            divTableservicios_Visible = 0;
            AssignProp("", false, divTableservicios_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableservicios_Visible), 5, 0), true);
            divTablemudanzas_Visible = 0;
            AssignProp("", false, divTablemudanzas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemudanzas_Visible), 5, 0), true);
            AV11ZonasId = 0;
            AssignAttri("", false, "AV11ZonasId", StringUtil.LTrimStr( (decimal)(AV11ZonasId), 18, 0));
            Combo_zonasid_Selectedvalue_set = "";
            ucCombo_zonasid.SendProperty(context, "", false, Combo_zonasid_Internalname, "SelectedValue_set", Combo_zonasid_Selectedvalue_set);
            AV12DepartamentoId = 0;
            AssignAttri("", false, "AV12DepartamentoId", StringUtil.LTrimStr( (decimal)(AV12DepartamentoId), 18, 0));
            Combo_departamentoid_Selectedvalue_set = "";
            ucCombo_departamentoid.SendProperty(context, "", false, Combo_departamentoid_Internalname, "SelectedValue_set", Combo_departamentoid_Selectedvalue_set);
            AV13RubrosId = 0;
            AssignAttri("", false, "AV13RubrosId", StringUtil.LTrimStr( (decimal)(AV13RubrosId), 4, 0));
            Combo_rubrosid_Selectedvalue_set = "";
            ucCombo_rubrosid.SendProperty(context, "", false, Combo_rubrosid_Internalname, "SelectedValue_set", Combo_rubrosid_Selectedvalue_set);
            AV14MedidasId = 0;
            AssignAttri("", false, "AV14MedidasId", StringUtil.LTrimStr( (decimal)(AV14MedidasId), 18, 0));
            Combo_medidasid_Selectedvalue_set = "";
            ucCombo_medidasid.SendProperty(context, "", false, Combo_medidasid_Internalname, "SelectedValue_set", Combo_medidasid_Selectedvalue_set);
            AV27LocalidadOrigen = "";
            AssignAttri("", false, "AV27LocalidadOrigen", AV27LocalidadOrigen);
            Combo_localidadorigen_Selectedvalue_set = "";
            ucCombo_localidadorigen.SendProperty(context, "", false, Combo_localidadorigen_Internalname, "SelectedValue_set", Combo_localidadorigen_Selectedvalue_set);
            AV31Origen = "";
            AssignAttri("", false, "AV31Origen", AV31Origen);
            AV29LocalidadDestino = "";
            AssignAttri("", false, "AV29LocalidadDestino", AV29LocalidadDestino);
            Combo_localidaddestino_Selectedvalue_set = "";
            ucCombo_localidaddestino.SendProperty(context, "", false, Combo_localidaddestino_Internalname, "SelectedValue_set", Combo_localidaddestino_Selectedvalue_set);
            AV32Destino = "";
            AssignAttri("", false, "AV32Destino", AV32Destino);
         }
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = AV23Events;
         new wwp_calendar_getevent(context ).execute(  AV26Filtro,  AV11ZonasId,  AV12DepartamentoId,  AV13RubrosId,  AV14MedidasId,  StringUtil.Trim( AV31Origen),  StringUtil.Trim( AV32Destino), out  GXt_objcol_SdtWWP_Calendar_Events_Item1) ;
         AV23Events = GXt_objcol_SdtWWP_Calendar_Events_Item1;
         /*  Sending Event outputs  */
         cmbavLocalidadorigen.CurrentValue = StringUtil.RTrim( AV27LocalidadOrigen);
         AssignProp("", false, cmbavLocalidadorigen_Internalname, "Values", cmbavLocalidadorigen.ToJavascriptSource(), true);
         cmbavLocalidaddestino.CurrentValue = StringUtil.RTrim( AV29LocalidadDestino);
         AssignProp("", false, cmbavLocalidaddestino_Internalname, "Values", cmbavLocalidaddestino.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23Events", AV23Events);
      }

      private void E26GR3( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV47SDTConsumoProductivo.Count )
         {
            AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1));
            GX_msglist.addItem(context.GetMessage( "Prueba", ""));
            AV48Aceptados = StringUtil.Str( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)(AV47SDTConsumoProductivo.CurrentItem)).gxTpr_Horastomadas, 10, 2) + " / " + StringUtil.Str( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)(AV47SDTConsumoProductivo.CurrentItem)).gxTpr_Porcentajetomadas, 6, 2) + "%";
            AssignAttri("", false, edtavAceptados_Internalname, AV48Aceptados);
            if ( ( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)(AV47SDTConsumoProductivo.CurrentItem)).gxTpr_Porcentajesolicitado >= Convert.ToDecimal( 70 )) && ( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)(AV47SDTConsumoProductivo.CurrentItem)).gxTpr_Porcentajesolicitado < Convert.ToDecimal( 85 )) )
            {
               edtavSdtconsumoproductivo__dia_Columnclass = "WWColumn WWColumnWarning ColumnWeightBold ColumnAlignCenter WWColumnWarningFirstColumn";
               edtavSdtconsumoproductivo__horasdisponibles_Columnclass = "WWColumn WWColumnWarning ColumnAlignCenter";
               edtavSdtconsumoproductivo__horassolicitadas_Columnclass = "WWColumn WWColumnWarning ColumnAlignCenter";
               edtavAceptados_Columnclass = "WWColumn WWColumnWarning ColumnAlignLeft";
            }
            else if ( ( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)(AV47SDTConsumoProductivo.CurrentItem)).gxTpr_Porcentajesolicitado >= Convert.ToDecimal( 85 )) )
            {
               edtavSdtconsumoproductivo__dia_Columnclass = "WWColumn WWColumnDanger ColumnWeightBold ColumnAlignCenter WWColumnDangerFirstColumn";
               edtavSdtconsumoproductivo__horasdisponibles_Columnclass = "WWColumn WWColumnDanger ColumnAlignCenter";
               edtavSdtconsumoproductivo__horassolicitadas_Columnclass = "WWColumn WWColumnDanger ColumnAlignCenter";
               edtavAceptados_Columnclass = "WWColumn WWColumnDanger ColumnAlignLeft";
            }
            else
            {
               edtavSdtconsumoproductivo__dia_Columnclass = "WWColumn ColumnWeightBold ColumnAlignCenter";
               edtavSdtconsumoproductivo__horasdisponibles_Columnclass = "WWColumn ColumnAlignCenter";
               edtavSdtconsumoproductivo__horassolicitadas_Columnclass = "WWColumn ColumnAlignCenter";
               edtavAceptados_Columnclass = "WWColumn ColumnAlignLeft";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 140;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1403( ) ;
            }
            GRID1_nEOF = (short)(((subGrid1_Rows==0)||(GRID1_nCurrentRecord<GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_140_Refreshing )
            {
               context.DoAjaxLoad(140, Grid1Row);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      private void E24GR4( )
      {
         /* Freestylegrid2_Load Routine */
         returnInSub = false;
         AV68GXV9 = 1;
         while ( AV68GXV9 <= AV52SDTConsumoProd.Count )
         {
            AV52SDTConsumoProd.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV52SDTConsumoProd.Item(AV68GXV9));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 154;
            }
            sendrow_1544( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_154_Refreshing )
            {
               context.DoAjaxLoad(154, Freestylegrid2Row);
            }
            AV68GXV9 = (int)(AV68GXV9+1);
         }
      }

      private void E25GR5( )
      {
         /* Gridsdtconsumoproductivos_Load Routine */
         returnInSub = false;
         AV65GXV6 = 1;
         while ( AV65GXV6 <= AV47SDTConsumoProductivo.Count )
         {
            AV47SDTConsumoProductivo.CurrentItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 161;
            }
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
               GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            else
            {
               GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = 0;
            }
            if ( ( subGridsdtconsumoproductivos_Islastpage == 1 ) || ( subGridsdtconsumoproductivos_Rows == 0 ) || ( ( GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord >= GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage ) && ( GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord < GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage + subGridsdtconsumoproductivos_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1615( ) ;
            }
            GRIDSDTCONSUMOPRODUCTIVOS_nEOF = (short)(((subGridsdtconsumoproductivos_Rows==0)||(GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord<GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage+subGridsdtconsumoproductivos_fnc_Recordsperpage( )) ? 1 : 0));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nEOF_" + sGXsfl_154_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nEOF), 1, 0, ".", "")));
            GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord = (long)(GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_161_Refreshing )
            {
               context.DoAjaxLoad(161, GridsdtconsumoproductivosRow);
            }
            AV65GXV6 = (int)(AV65GXV6+1);
         }
      }

      protected void wb_table2_219_GR2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardlefticon1_moreinfo_Internalname, tblCardlefticon1_moreinfo_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_moreinfoicon_Internalname, context.GetMessage( "<i class='CardMaterialMoreInfoIcon far fa-calendar-days' style='font-size: 16px'></i>", ""), "", "", lblCardlefticon1_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Dashboard/Dashboard1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon1_moreinfocaption_Internalname, context.GetMessage( "Ver detalle", ""), "", "", lblCardlefticon1_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+"e27gr1_client"+"'", "", "TextBlockMoreInfoCard", 7, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_219_GR2e( true) ;
         }
         else
         {
            wb_table2_219_GR2e( false) ;
         }
      }

      protected void wb_table1_197_GR2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardlefticon2_moreinfo_Internalname, tblCardlefticon2_moreinfo_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon2_moreinfoicon_Internalname, context.GetMessage( "<i class='CardMaterialMoreInfoIcon far fa-calendar-days' style='font-size: 16px'></i>", ""), "", "", lblCardlefticon2_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Dashboard/Dashboard1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardlefticon2_moreinfocaption_Internalname, context.GetMessage( "Ver detalle", ""), "", "", lblCardlefticon2_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+"e28gr1_client"+"'", "", "TextBlockMoreInfoCard", 7, "", 1, 1, 0, 0, "HLP_Dashboard/Dashboard1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_197_GR2e( true) ;
         }
         else
         {
            wb_table1_197_GR2e( false) ;
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
         PAGR2( ) ;
         WSGR2( ) ;
         WEGR2( ) ;
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
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Calendar/FullCalendar.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932018178", true, true, false);
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
         context.AddJavascriptSource("dashboard/dashboard1.js", "?2026932018179", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Calendar/index.global.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Calendar/WWPCalendarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1072( )
      {
         edtavDepartamentonombre_Internalname = "vDEPARTAMENTONOMBRE_"+sGXsfl_107_idx;
         edtavCapacidad_Internalname = "vCAPACIDAD_"+sGXsfl_107_idx;
         edtTablaAuxId_Internalname = "TABLAAUXID_"+sGXsfl_107_idx;
         edtTablaAuxDepartamentoNombre_Internalname = "TABLAAUXDEPARTAMENTONOMBRE_"+sGXsfl_107_idx;
         edtTablaAuxCapacidadProd_Internalname = "TABLAAUXCAPACIDADPROD_"+sGXsfl_107_idx;
         edtTablaAuxDepartamentoId_Internalname = "TABLAAUXDEPARTAMENTOID_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtavDepartamentonombre_Internalname = "vDEPARTAMENTONOMBRE_"+sGXsfl_107_fel_idx;
         edtavCapacidad_Internalname = "vCAPACIDAD_"+sGXsfl_107_fel_idx;
         edtTablaAuxId_Internalname = "TABLAAUXID_"+sGXsfl_107_fel_idx;
         edtTablaAuxDepartamentoNombre_Internalname = "TABLAAUXDEPARTAMENTONOMBRE_"+sGXsfl_107_fel_idx;
         edtTablaAuxCapacidadProd_Internalname = "TABLAAUXCAPACIDADPROD_"+sGXsfl_107_fel_idx;
         edtTablaAuxDepartamentoId_Internalname = "TABLAAUXDEPARTAMENTOID_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WBGR0( ) ;
         Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
         if ( subFreestylegrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
            subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_107_idx) % (2))) == 0 )
            {
               subFreestylegrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
               }
            }
            else
            {
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_107_idx+"\">") ;
         }
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblFreestylegrid1layouttable_Internalname+"_"+sGXsfl_107_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDepartamentonombre_Internalname,context.GetMessage( "Departamento Nombre", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_107_idx + "',107)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDepartamentonombre_Internalname,StringUtil.RTrim( AV50DepartamentoNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDepartamentonombre_Jsonclick,(short)0,(string)"Attribute",(string)((edtavDepartamentonombre_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"),(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDepartamentonombre_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCapacidad_Internalname,context.GetMessage( "Capacidad", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_107_idx + "',107)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCapacidad_Internalname,StringUtil.LTrim( StringUtil.NToC( AV51Capacidad, 22, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavCapacidad_Enabled!=0) ? context.localUtil.Format( AV51Capacidad, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV51Capacidad, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCapacidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCapacidad_Enabled,(short)0,(string)"text",(string)"",(short)22,(string)"chr",(short)1,(string)"row",(short)22,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Total",(string)"end",(bool)false,(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"Invisible"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegrid1_Internalname+"_"+sGXsfl_107_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxId_Internalname,context.GetMessage( "Tabla Aux Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Single line edit */
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A830TablaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A830TablaAuxId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTablaAuxId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTablaAuxId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxDepartamentoNombre_Internalname,context.GetMessage( "Tabla Aux Departamento Nombre", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Single line edit */
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxDepartamentoNombre_Internalname,StringUtil.RTrim( A832TablaAuxDepartamentoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTablaAuxDepartamentoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTablaAuxDepartamentoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxCapacidadProd_Internalname,context.GetMessage( "Tabla Aux Capacidad Prod", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Single line edit */
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxCapacidadProd_Internalname,StringUtil.LTrim( StringUtil.NToC( A833TablaAuxCapacidadProd, 22, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A833TablaAuxCapacidadProd, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTablaAuxCapacidadProd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTablaAuxCapacidadProd_Visible,(short)0,(short)0,(string)"text",(string)"",(short)22,(string)"chr",(short)1,(string)"row",(short)22,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Total",(string)"end",(bool)false,(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxDepartamentoId_Internalname,context.GetMessage( "Tabla Aux Departamento Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         /* Single line edit */
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTablaAuxDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A831TablaAuxDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A831TablaAuxDepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTablaAuxDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtTablaAuxDepartamentoId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylegrid1Row.AddRenderProperties(Freestylegrid1Column);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashesGR2( ) ;
         GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridSDTConsumoProductivosCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridSDTConsumoProductivosPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV58GridSDTConsumoProductivosAppliedFilters);
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Class));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0, ".", "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridclass));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Previous));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Next));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Caption));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridcaption));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_107_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption));
         /* End of Columns property logic. */
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_107_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_107_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         /* End function sendrow_1072 */
      }

      protected void SubsflControlProps_1403( )
      {
         edtavSdtconsumoproductivo__dia_Internalname = "SDTCONSUMOPRODUCTIVO__DIA_"+sGXsfl_140_idx;
         edtavSdtconsumoproductivo__horasdisponibles_Internalname = "SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES_"+sGXsfl_140_idx;
         edtavSdtconsumoproductivo__horassolicitadas_Internalname = "SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS_"+sGXsfl_140_idx;
         edtavSdtconsumoproductivo__horastomadas_Internalname = "SDTCONSUMOPRODUCTIVO__HORASTOMADAS_"+sGXsfl_140_idx;
         edtavAceptados_Internalname = "vACEPTADOS_"+sGXsfl_140_idx;
      }

      protected void SubsflControlProps_fel_1403( )
      {
         edtavSdtconsumoproductivo__dia_Internalname = "SDTCONSUMOPRODUCTIVO__DIA_"+sGXsfl_140_fel_idx;
         edtavSdtconsumoproductivo__horasdisponibles_Internalname = "SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES_"+sGXsfl_140_fel_idx;
         edtavSdtconsumoproductivo__horassolicitadas_Internalname = "SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS_"+sGXsfl_140_fel_idx;
         edtavSdtconsumoproductivo__horastomadas_Internalname = "SDTCONSUMOPRODUCTIVO__HORASTOMADAS_"+sGXsfl_140_fel_idx;
         edtavAceptados_Internalname = "vACEPTADOS_"+sGXsfl_140_fel_idx;
      }

      protected void sendrow_1403( )
      {
         sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
         SubsflControlProps_1403( ) ;
         WBGR0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_140_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_140_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_140_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtconsumoproductivo__dia_Internalname,context.localUtil.Format(((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Dia, "99/99/99"),context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Dia, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,141);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtconsumoproductivo__dia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtconsumoproductivo__dia_Columnclass,(string)edtavSdtconsumoproductivo__dia_Columnheaderclass,(short)-1,(int)edtavSdtconsumoproductivo__dia_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtconsumoproductivo__horasdisponibles_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horasdisponibles, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtconsumoproductivo__horasdisponibles_Enabled!=0) ? context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horasdisponibles, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horasdisponibles, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,142);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtconsumoproductivo__horasdisponibles_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtconsumoproductivo__horasdisponibles_Columnclass,(string)edtavSdtconsumoproductivo__horasdisponibles_Columnheaderclass,(short)-1,(int)edtavSdtconsumoproductivo__horasdisponibles_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtconsumoproductivo__horassolicitadas_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horassolicitadas, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtconsumoproductivo__horassolicitadas_Enabled!=0) ? context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horassolicitadas, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horassolicitadas, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,143);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtconsumoproductivo__horassolicitadas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtconsumoproductivo__horassolicitadas_Columnclass,(string)edtavSdtconsumoproductivo__horassolicitadas_Columnheaderclass,(short)-1,(int)edtavSdtconsumoproductivo__horassolicitadas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtconsumoproductivo__horastomadas_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horastomadas, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtconsumoproductivo__horastomadas_Enabled!=0) ? context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horastomadas, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV60GXV1)).gxTpr_Horastomadas, "ZZZZZZ9.99"))),""+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtconsumoproductivo__horastomadas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnAlignCenter",(string)"",(short)0,(int)edtavSdtconsumoproductivo__horastomadas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_140_idx + "',140)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAceptados_Internalname,(string)AV48Aceptados,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAceptados_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavAceptados_Columnclass,(string)edtavAceptados_Columnheaderclass,(short)-1,(int)edtavAceptados_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)140,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesGR3( ) ;
            GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridSDTConsumoProductivosCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
            GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridSDTConsumoProductivosPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
            GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, AV58GridSDTConsumoProductivosAppliedFilters);
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Class));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0, ".", "")));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridclass));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Previous));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Next));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Caption));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridcaption));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_140_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption));
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_140_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_140_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_140_idx+1);
            sGXsfl_140_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_140_idx), 4, 0), 4, "0");
            SubsflControlProps_1403( ) ;
         }
         /* End function sendrow_1403 */
      }

      protected void SubsflControlProps_1615( )
      {
         edtavSdtconsumoproductivo__porcentajesolicitado_Internalname = "SDTCONSUMOPRODUCTIVO__PORCENTAJESOLICITADO_"+sGXsfl_161_idx;
         edtavSdtconsumoproductivo__porcentajetomadas_Internalname = "SDTCONSUMOPRODUCTIVO__PORCENTAJETOMADAS_"+sGXsfl_161_idx;
      }

      protected void SubsflControlProps_fel_1615( )
      {
         edtavSdtconsumoproductivo__porcentajesolicitado_Internalname = "SDTCONSUMOPRODUCTIVO__PORCENTAJESOLICITADO_"+sGXsfl_161_fel_idx;
         edtavSdtconsumoproductivo__porcentajetomadas_Internalname = "SDTCONSUMOPRODUCTIVO__PORCENTAJETOMADAS_"+sGXsfl_161_fel_idx;
      }

      protected void sendrow_1615( )
      {
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
         SubsflControlProps_1615( ) ;
         WBGR0( ) ;
         if ( ( subGridsdtconsumoproductivos_Rows * 1 == 0 ) || ( nGXsfl_161_idx <= subGridsdtconsumoproductivos_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsdtconsumoproductivosRow = GXWebRow.GetNew(context,GridsdtconsumoproductivosContainer);
            if ( subGridsdtconsumoproductivos_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdtconsumoproductivos_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdtconsumoproductivos_Class, "") != 0 )
               {
                  subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Odd";
               }
            }
            else if ( subGridsdtconsumoproductivos_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdtconsumoproductivos_Backstyle = 0;
               subGridsdtconsumoproductivos_Backcolor = subGridsdtconsumoproductivos_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdtconsumoproductivos_Class, "") != 0 )
               {
                  subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Uniform";
               }
            }
            else if ( subGridsdtconsumoproductivos_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdtconsumoproductivos_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdtconsumoproductivos_Class, "") != 0 )
               {
                  subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Odd";
               }
               subGridsdtconsumoproductivos_Backcolor = (int)(0x0);
            }
            else if ( subGridsdtconsumoproductivos_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdtconsumoproductivos_Backstyle = 1;
               if ( ((int)((nGXsfl_161_idx) % (2))) == 0 )
               {
                  subGridsdtconsumoproductivos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtconsumoproductivos_Class, "") != 0 )
                  {
                     subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Even";
                  }
               }
               else
               {
                  subGridsdtconsumoproductivos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtconsumoproductivos_Class, "") != 0 )
                  {
                     subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Odd";
                  }
               }
            }
            if ( GridsdtconsumoproductivosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_161_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsdtconsumoproductivosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'" + sGXsfl_161_idx + "',161)\"";
            ROClassString = "Attribute";
            GridsdtconsumoproductivosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtconsumoproductivo__porcentajesolicitado_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6)).gxTpr_Porcentajesolicitado, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtconsumoproductivo__porcentajesolicitado_Enabled!=0) ? context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6)).gxTpr_Porcentajesolicitado, "ZZ9.99") : context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6)).gxTpr_Porcentajesolicitado, "ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,162);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtconsumoproductivo__porcentajesolicitado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtconsumoproductivo__porcentajesolicitado_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtconsumoproductivosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'" + sGXsfl_161_idx + "',161)\"";
            ROClassString = "Attribute";
            GridsdtconsumoproductivosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtconsumoproductivo__porcentajetomadas_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6)).gxTpr_Porcentajetomadas, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtconsumoproductivo__porcentajetomadas_Enabled!=0) ? context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6)).gxTpr_Porcentajetomadas, "ZZ9.99") : context.localUtil.Format( ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV47SDTConsumoProductivo.Item(AV65GXV6)).gxTpr_Porcentajetomadas, "ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,163);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtconsumoproductivo__porcentajetomadas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtconsumoproductivo__porcentajetomadas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesGR5( ) ;
            GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridSDTConsumoProductivosCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
            GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridSDTConsumoProductivosPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
            GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, AV58GridSDTConsumoProductivosAppliedFilters);
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Class));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0, ".", "")));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridclass));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Previous));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Next));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Caption));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridcaption));
            GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_161_idx;
            GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption));
            GridsdtconsumoproductivosContainer.AddRow(GridsdtconsumoproductivosRow);
            nGXsfl_161_idx = ((subGridsdtconsumoproductivos_Islastpage==1)&&(nGXsfl_161_idx+1>subGridsdtconsumoproductivos_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_idx+1);
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0") + sGXsfl_154_idx;
            SubsflControlProps_1615( ) ;
         }
         /* End function sendrow_1615 */
      }

      protected void SubsflControlProps_1544( )
      {
         Gridsdtconsumoproductivospaginationbar_Internalname = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_"+sGXsfl_154_idx;
         subGridsdtconsumoproductivos_Internalname = "GRIDSDTCONSUMOPRODUCTIVOS_"+sGXsfl_154_idx;
      }

      protected void SubsflControlProps_fel_1544( )
      {
         Gridsdtconsumoproductivospaginationbar_Internalname = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_"+sGXsfl_154_fel_idx;
         subGridsdtconsumoproductivos_Internalname = "GRIDSDTCONSUMOPRODUCTIVOS_"+sGXsfl_154_fel_idx;
      }

      protected void sendrow_1544( )
      {
         sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
         SubsflControlProps_1544( ) ;
         WBGR0( ) ;
         Freestylegrid2Row = GXWebRow.GetNew(context,Freestylegrid2Container);
         if ( subFreestylegrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegrid2_Class, "") != 0 )
            {
               subFreestylegrid2_Linesclass = subFreestylegrid2_Class+"Odd";
            }
         }
         else if ( subFreestylegrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegrid2_Backstyle = 0;
            subFreestylegrid2_Backcolor = subFreestylegrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegrid2_Class, "") != 0 )
            {
               subFreestylegrid2_Linesclass = subFreestylegrid2_Class+"Uniform";
            }
         }
         else if ( subFreestylegrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegrid2_Class, "") != 0 )
            {
               subFreestylegrid2_Linesclass = subFreestylegrid2_Class+"Odd";
            }
            subFreestylegrid2_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_154_idx) % (2))) == 0 )
            {
               subFreestylegrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegrid2_Class, "") != 0 )
               {
                  subFreestylegrid2_Linesclass = subFreestylegrid2_Class+"Even";
               }
            }
            else
            {
               subFreestylegrid2_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegrid2_Class, "") != 0 )
               {
                  subFreestylegrid2_Linesclass = subFreestylegrid2_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylegrid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_154_idx+"\">") ;
         }
         /* Table start */
         Freestylegrid2Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblFreestylegrid2layouttable_Internalname+"_"+sGXsfl_154_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid2Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid2Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"HasGridEmpowerer"});
         /* Div Control */
         Freestylegrid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridsdtconsumoproductivostablewithpaginationbar_Internalname+"_"+sGXsfl_154_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Freestylegrid2Row.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"GridsdtconsumoproductivosContainer"});
         if ( isAjaxCallMode( ) )
         {
            GridsdtconsumoproductivosContainer = new GXWebGrid( context);
         }
         else
         {
            GridsdtconsumoproductivosContainer.Clear();
         }
         GridsdtconsumoproductivosContainer.SetWrapped(nGXWrapped);
         StartGridControl161( ) ;
         RFGR5( ) ;
         nRC_GXsfl_161 = (int)(nGXsfl_161_idx-1);
         GXCCtl = "nRC_GXsfl_161_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_161), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( GridsdtconsumoproductivosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "</table>") ;
         }
         else
         {
            if ( ! isAjaxCallMode( ) )
            {
               GxWebStd.gx_hidden_field( context, "GridsdtconsumoproductivosContainerData"+"_"+sGXsfl_154_idx, GridsdtconsumoproductivosContainer.ToJavascriptSource());
            }
            if ( isAjaxCallMode( ) )
            {
               Freestylegrid2Row.AddGrid("Gridsdtconsumoproductivos", GridsdtconsumoproductivosContainer);
            }
            if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
            {
               GxWebStd.gx_hidden_field( context, "GridsdtconsumoproductivosContainerData"+"V_"+sGXsfl_154_idx, GridsdtconsumoproductivosContainer.GridValuesHidden());
            }
            else
            {
               context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtconsumoproductivosContainerData"+"V_"+sGXsfl_154_idx+"\" value='"+GridsdtconsumoproductivosContainer.GridValuesHidden()+"'/>") ;
            }
         }
         Freestylegrid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* User Defined Control */
         Freestylegrid2Row.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)"GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBARContainer"+"_"+sGXsfl_154_idx,(short)-1});
         Freestylegrid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid2Container.GetWrapped() == 1 )
         {
            Freestylegrid2Container.CloseTag("cell");
         }
         if ( Freestylegrid2Container.GetWrapped() == 1 )
         {
            Freestylegrid2Container.CloseTag("row");
         }
         if ( Freestylegrid2Container.GetWrapped() == 1 )
         {
            Freestylegrid2Container.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashesGR4( ) ;
         GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridSDTConsumoProductivosCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridSDTConsumoProductivosPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vGRIDSDTCONSUMOPRODUCTIVOSAPPLIEDFILTERS_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV58GridSDTConsumoProductivosAppliedFilters);
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_nEOF_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTCONSUMOPRODUCTIVOS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOS_Rows_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Rows), 6, 0, ".", "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Class_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Class));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showfirst_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showfirst));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showprevious_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showprevious));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Shownext_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Shownext));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Showlast_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Showlast));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagestoshow_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Pagestoshow), 9, 0, ".", "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingbuttonsposition_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Pagingcaptionposition_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridclass_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridclass));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselector_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Gridsdtconsumoproductivospaginationbar_Rowsperpageselector));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageselectedvalue_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpageoptions_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Previous_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Previous));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Next_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Next));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Caption_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Caption));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Emptygridcaption_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Emptygridcaption));
         GXCCtl = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR_Rowsperpagecaption_" + sGXsfl_154_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption));
         GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage = 0;
         GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord = 0;
         /* End of Columns property logic. */
         Freestylegrid2Container.AddRow(Freestylegrid2Row);
         nGXsfl_154_idx = ((subFreestylegrid2_Islastpage==1)&&(nGXsfl_154_idx+1>subFreestylegrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_154_idx+1);
         sGXsfl_154_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_154_idx), 4, 0), 4, "0");
         SubsflControlProps_1544( ) ;
         /* End function sendrow_1544 */
      }

      protected void init_web_controls( )
      {
         radavFiltro.Name = "vFILTRO";
         radavFiltro.WebTags = "";
         radavFiltro.addItem("", context.GetMessage( "Todos", ""), 0);
         radavFiltro.addItem("Servicios", context.GetMessage( "Servicios", ""), 0);
         radavFiltro.addItem("Mudanzas", context.GetMessage( "Mudanzas", ""), 0);
         cmbavLocalidadorigen.Name = "vLOCALIDADORIGEN";
         cmbavLocalidadorigen.WebTags = "";
         if ( cmbavLocalidadorigen.ItemCount > 0 )
         {
            AV27LocalidadOrigen = cmbavLocalidadorigen.getValidValue(AV27LocalidadOrigen);
            AssignAttri("", false, "AV27LocalidadOrigen", AV27LocalidadOrigen);
         }
         cmbavLocalidaddestino.Name = "vLOCALIDADDESTINO";
         cmbavLocalidaddestino.WebTags = "";
         if ( cmbavLocalidaddestino.ItemCount > 0 )
         {
            AV29LocalidadDestino = cmbavLocalidaddestino.getValidValue(AV29LocalidadDestino);
            AssignAttri("", false, "AV29LocalidadDestino", AV29LocalidadDestino);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"107\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Freestylegrid1Container = new GXWebGrid( context);
            }
            else
            {
               Freestylegrid1Container.Clear();
            }
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", "");
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV50DepartamentoNombre)));
            Freestylegrid1Column.AddObjectProperty("Fontbold", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDepartamentonombre_Fontbold), 1, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDepartamentonombre_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV51Capacidad, 22, 2, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCapacidad_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A830TablaAuxId), 18, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxId_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A832TablaAuxDepartamentoNombre)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxDepartamentoNombre_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A833TablaAuxCapacidadProd, 22, 2, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxCapacidadProd_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A831TablaAuxDepartamentoId), 18, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTablaAuxDepartamentoId_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl140( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"140\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Día", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Capacidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitados (min)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aceptados (min)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aceptados (min)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtconsumoproductivo__dia_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtconsumoproductivo__dia_Columnheaderclass));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtconsumoproductivo__dia_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtconsumoproductivo__horasdisponibles_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtconsumoproductivo__horasdisponibles_Columnheaderclass));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtconsumoproductivo__horasdisponibles_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtconsumoproductivo__horassolicitadas_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtconsumoproductivo__horassolicitadas_Columnheaderclass));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtconsumoproductivo__horassolicitadas_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtconsumoproductivo__horastomadas_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV48Aceptados));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavAceptados_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavAceptados_Columnheaderclass));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAceptados_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl154( )
      {
         if ( Freestylegrid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Freestylegrid2Container"+"DivS\" data-gxgridid=\"154\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid2_Internalname, subFreestylegrid2_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid2Container.AddObjectProperty("GridName", "Freestylegrid2");
         }
         else
         {
            Freestylegrid2Container.AddObjectProperty("GridName", "Freestylegrid2");
            Freestylegrid2Container.AddObjectProperty("Header", subFreestylegrid2_Header);
            Freestylegrid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid2Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("CmpContext", "");
            Freestylegrid2Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid2Container.AddColumnProperties(Freestylegrid2Column);
            Freestylegrid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Selectedindex), 4, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Allowselection), 1, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Allowhovering), 1, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl161( )
      {
         if ( GridsdtconsumoproductivosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridsdtconsumoproductivosContainer"+"DivS\" data-gxgridid=\"161\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdtconsumoproductivos_Internalname, subGridsdtconsumoproductivos_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdtconsumoproductivos_Backcolorstyle == 0 )
            {
               subGridsdtconsumoproductivos_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdtconsumoproductivos_Class) > 0 )
               {
                  subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Title";
               }
            }
            else
            {
               subGridsdtconsumoproductivos_Titlebackstyle = 1;
               if ( subGridsdtconsumoproductivos_Backcolorstyle == 1 )
               {
                  subGridsdtconsumoproductivos_Titlebackcolor = subGridsdtconsumoproductivos_Allbackcolor;
                  if ( StringUtil.Len( subGridsdtconsumoproductivos_Class) > 0 )
                  {
                     subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdtconsumoproductivos_Class) > 0 )
                  {
                     subGridsdtconsumoproductivos_Linesclass = subGridsdtconsumoproductivos_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Porcentaje Solicitado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Porcentaje Tomadas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsdtconsumoproductivosContainer.AddObjectProperty("GridName", "Gridsdtconsumoproductivos");
         }
         else
         {
            GridsdtconsumoproductivosContainer.AddObjectProperty("GridName", "Gridsdtconsumoproductivos");
            GridsdtconsumoproductivosContainer.AddObjectProperty("Header", subGridsdtconsumoproductivos_Header);
            GridsdtconsumoproductivosContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridsdtconsumoproductivosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Backcolorstyle), 1, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("CmpContext", "");
            GridsdtconsumoproductivosContainer.AddObjectProperty("InMasterPage", "false");
            GridsdtconsumoproductivosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsdtconsumoproductivosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtconsumoproductivo__porcentajesolicitado_Enabled), 5, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddColumnProperties(GridsdtconsumoproductivosColumn);
            GridsdtconsumoproductivosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsdtconsumoproductivosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtconsumoproductivo__porcentajetomadas_Enabled), 5, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddColumnProperties(GridsdtconsumoproductivosColumn);
            GridsdtconsumoproductivosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Selectedindex), 4, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Allowselection), 1, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Selectioncolor), 9, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Allowhovering), 1, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Hoveringcolor), 9, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Allowcollapsing), 1, 0, ".", "")));
            GridsdtconsumoproductivosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtconsumoproductivos_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         radavFiltro_Internalname = "vFILTRO";
         lblTextblockcombo_zonasid_Internalname = "TEXTBLOCKCOMBO_ZONASID";
         Combo_zonasid_Internalname = "COMBO_ZONASID";
         divTablesplittedzonasid_Internalname = "TABLESPLITTEDZONASID";
         divCombo_zonasid_cell_Internalname = "COMBO_ZONASID_CELL";
         lblTextblockcombo_departamentoid_Internalname = "TEXTBLOCKCOMBO_DEPARTAMENTOID";
         Combo_departamentoid_Internalname = "COMBO_DEPARTAMENTOID";
         divTablesplitteddepartamentoid_Internalname = "TABLESPLITTEDDEPARTAMENTOID";
         lblTextblockcombo_rubrosid_Internalname = "TEXTBLOCKCOMBO_RUBROSID";
         Combo_rubrosid_Internalname = "COMBO_RUBROSID";
         divTablesplittedrubrosid_Internalname = "TABLESPLITTEDRUBROSID";
         lblTextblockcombo_medidasid_Internalname = "TEXTBLOCKCOMBO_MEDIDASID";
         Combo_medidasid_Internalname = "COMBO_MEDIDASID";
         divTablesplittedmedidasid_Internalname = "TABLESPLITTEDMEDIDASID";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         bttBtnaplicar_Internalname = "BTNAPLICAR";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         divTableservicios_Internalname = "TABLESERVICIOS";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblockcombo_localidadorigen_Internalname = "TEXTBLOCKCOMBO_LOCALIDADORIGEN";
         Combo_localidadorigen_Internalname = "COMBO_LOCALIDADORIGEN";
         divTablesplittedlocalidadorigen_Internalname = "TABLESPLITTEDLOCALIDADORIGEN";
         lblTextblockcombo_localidaddestino_Internalname = "TEXTBLOCKCOMBO_LOCALIDADDESTINO";
         Combo_localidaddestino_Internalname = "COMBO_LOCALIDADDESTINO";
         divTablesplittedlocalidaddestino_Internalname = "TABLESPLITTEDLOCALIDADDESTINO";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         bttBtnaplicar2_Internalname = "BTNAPLICAR2";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         divTablemudanzas_Internalname = "TABLEMUDANZAS";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         Dvpanel_unnamedtable5_Internalname = "DVPANEL_UNNAMEDTABLE5";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtavDepartamentonombre_Internalname = "vDEPARTAMENTONOMBRE";
         edtavCapacidad_Internalname = "vCAPACIDAD";
         edtTablaAuxId_Internalname = "TABLAAUXID";
         edtTablaAuxDepartamentoNombre_Internalname = "TABLAAUXDEPARTAMENTONOMBRE";
         edtTablaAuxCapacidadProd_Internalname = "TABLAAUXCAPACIDADPROD";
         edtTablaAuxDepartamentoId_Internalname = "TABLAAUXDEPARTAMENTOID";
         tblUnnamedtablecontentfsfreestylegrid1_Internalname = "UNNAMEDTABLECONTENTFSFREESTYLEGRID1";
         tblFreestylegrid1layouttable_Internalname = "FREESTYLEGRID1LAYOUTTABLE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         Dvpanel_unnamedtable6_Internalname = "DVPANEL_UNNAMEDTABLE6";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtavSdtconsumoproductivo__dia_Internalname = "SDTCONSUMOPRODUCTIVO__DIA";
         edtavSdtconsumoproductivo__horasdisponibles_Internalname = "SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES";
         edtavSdtconsumoproductivo__horassolicitadas_Internalname = "SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS";
         edtavSdtconsumoproductivo__horastomadas_Internalname = "SDTCONSUMOPRODUCTIVO__HORASTOMADAS";
         edtavAceptados_Internalname = "vACEPTADOS";
         Grid1paginationbar_Internalname = "GRID1PAGINATIONBAR";
         divGrid1tablewithpaginationbar_Internalname = "GRID1TABLEWITHPAGINATIONBAR";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         edtavSdtconsumoproductivo__porcentajesolicitado_Internalname = "SDTCONSUMOPRODUCTIVO__PORCENTAJESOLICITADO";
         edtavSdtconsumoproductivo__porcentajetomadas_Internalname = "SDTCONSUMOPRODUCTIVO__PORCENTAJETOMADAS";
         Gridsdtconsumoproductivospaginationbar_Internalname = "GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR";
         divGridsdtconsumoproductivostablewithpaginationbar_Internalname = "GRIDSDTCONSUMOPRODUCTIVOSTABLEWITHPAGINATIONBAR";
         tblFreestylegrid2layouttable_Internalname = "FREESTYLEGRID2LAYOUTTABLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Utchartstackedbar_Internalname = "UTCHARTSTACKEDBAR";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         lblCardlefticon2_icon_Internalname = "CARDLEFTICON2_ICON";
         lblCardlefticon2_description_Internalname = "CARDLEFTICON2_DESCRIPTION";
         edtavCardlefticon2_value_Internalname = "vCARDLEFTICON2_VALUE";
         divCardlefticon2_tableinfo_Internalname = "CARDLEFTICON2_TABLEINFO";
         lblCardlefticon2_moreinfoicon_Internalname = "CARDLEFTICON2_MOREINFOICON";
         lblCardlefticon2_moreinfocaption_Internalname = "CARDLEFTICON2_MOREINFOCAPTION";
         tblCardlefticon2_moreinfo_Internalname = "CARDLEFTICON2_MOREINFO";
         divCardlefticon2_maintable_Internalname = "CARDLEFTICON2_MAINTABLE";
         Dvpanel_cardlefticon2_maintable_Internalname = "DVPANEL_CARDLEFTICON2_MAINTABLE";
         lblCardlefticon1_icon_Internalname = "CARDLEFTICON1_ICON";
         lblCardlefticon1_description_Internalname = "CARDLEFTICON1_DESCRIPTION";
         edtavCardlefticon1_value_Internalname = "vCARDLEFTICON1_VALUE";
         divCardlefticon1_tableinfo_Internalname = "CARDLEFTICON1_TABLEINFO";
         lblCardlefticon1_moreinfoicon_Internalname = "CARDLEFTICON1_MOREINFOICON";
         lblCardlefticon1_moreinfocaption_Internalname = "CARDLEFTICON1_MOREINFOCAPTION";
         tblCardlefticon1_moreinfo_Internalname = "CARDLEFTICON1_MOREINFO";
         divCardlefticon1_maintable_Internalname = "CARDLEFTICON1_MAINTABLE";
         Dvpanel_cardlefticon1_maintable_Internalname = "DVPANEL_CARDLEFTICON1_MAINTABLE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTablemain_Internalname = "TABLEMAIN";
         edtavZonasid_Internalname = "vZONASID";
         edtavDepartamentoid_Internalname = "vDEPARTAMENTOID";
         edtavRubrosid_Internalname = "vRUBROSID";
         edtavMedidasid_Internalname = "vMEDIDASID";
         cmbavLocalidadorigen_Internalname = "vLOCALIDADORIGEN";
         cmbavLocalidaddestino_Internalname = "vLOCALIDADDESTINO";
         Grid1_titlescategories_Internalname = "GRID1_TITLESCATEGORIES";
         Grid1_empowerer_Internalname = "GRID1_EMPOWERER";
         Gridsdtconsumoproductivos_empowerer_Internalname = "GRIDSDTCONSUMOPRODUCTIVOS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreestylegrid1_Internalname = "FREESTYLEGRID1";
         subGrid1_Internalname = "GRID1";
         subGridsdtconsumoproductivos_Internalname = "GRIDSDTCONSUMOPRODUCTIVOS";
         subFreestylegrid2_Internalname = "FREESTYLEGRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsdtconsumoproductivos_Allowcollapsing = 0;
         subGridsdtconsumoproductivos_Allowselection = 0;
         subGridsdtconsumoproductivos_Header = "";
         subFreestylegrid2_Allowcollapsing = 0;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         subFreestylegrid1_Allowcollapsing = 0;
         subFreestylegrid2_Class = "FreeStyleGrid";
         edtavSdtconsumoproductivo__porcentajetomadas_Jsonclick = "";
         edtavSdtconsumoproductivo__porcentajetomadas_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajesolicitado_Jsonclick = "";
         edtavSdtconsumoproductivo__porcentajesolicitado_Enabled = 0;
         subGridsdtconsumoproductivos_Class = "GridWithPaginationBar WorkWith";
         subGridsdtconsumoproductivos_Backcolorstyle = 0;
         edtavAceptados_Jsonclick = "";
         edtavAceptados_Columnclass = "WWColumn ColumnAlignLeft";
         edtavAceptados_Enabled = 0;
         edtavSdtconsumoproductivo__horastomadas_Jsonclick = "";
         edtavSdtconsumoproductivo__horastomadas_Enabled = 0;
         edtavSdtconsumoproductivo__horassolicitadas_Jsonclick = "";
         edtavSdtconsumoproductivo__horassolicitadas_Columnheaderclass = "";
         edtavSdtconsumoproductivo__horassolicitadas_Columnclass = "WWColumn ColumnAlignCenter";
         edtavSdtconsumoproductivo__horassolicitadas_Enabled = 0;
         edtavSdtconsumoproductivo__horasdisponibles_Jsonclick = "";
         edtavSdtconsumoproductivo__horasdisponibles_Columnheaderclass = "";
         edtavSdtconsumoproductivo__horasdisponibles_Columnclass = "WWColumn ColumnAlignCenter";
         edtavSdtconsumoproductivo__horasdisponibles_Enabled = 0;
         edtavSdtconsumoproductivo__dia_Jsonclick = "";
         edtavSdtconsumoproductivo__dia_Columnheaderclass = "";
         edtavSdtconsumoproductivo__dia_Columnclass = "WWColumn ColumnWeightBold ColumnAlignCenter";
         edtavSdtconsumoproductivo__dia_Enabled = 0;
         subGrid1_Class = "GridWithPaginationBar WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtTablaAuxDepartamentoId_Jsonclick = "";
         edtTablaAuxCapacidadProd_Jsonclick = "";
         edtTablaAuxDepartamentoNombre_Jsonclick = "";
         edtTablaAuxId_Jsonclick = "";
         edtavCapacidad_Jsonclick = "";
         edtavCapacidad_Enabled = 0;
         edtavDepartamentonombre_Jsonclick = "";
         edtavDepartamentonombre_Fontbold = 0;
         edtavDepartamentonombre_Enabled = 0;
         edtavAceptados_Columnheaderclass = "";
         edtTablaAuxDepartamentoId_Enabled = 0;
         edtTablaAuxCapacidadProd_Enabled = 0;
         edtTablaAuxDepartamentoNombre_Enabled = 0;
         edtTablaAuxId_Enabled = 0;
         subFreestylegrid2_Backcolorstyle = 0;
         subFreestylegrid1_Backcolorstyle = 0;
         edtavSdtconsumoproductivo__porcentajetomadas_Enabled = -1;
         edtavSdtconsumoproductivo__porcentajesolicitado_Enabled = -1;
         edtavSdtconsumoproductivo__horastomadas_Enabled = -1;
         edtavSdtconsumoproductivo__horassolicitadas_Enabled = -1;
         edtavSdtconsumoproductivo__horasdisponibles_Enabled = -1;
         edtavSdtconsumoproductivo__dia_Enabled = -1;
         Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsdtconsumoproductivospaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridsdtconsumoproductivospaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridsdtconsumoproductivospaginationbar_Next = "WWP_PagingNextCaption";
         Gridsdtconsumoproductivospaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsdtconsumoproductivospaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsdtconsumoproductivospaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition = "Left";
         Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition = "Right";
         Gridsdtconsumoproductivospaginationbar_Pagestoshow = 5;
         Gridsdtconsumoproductivospaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsdtconsumoproductivospaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsdtconsumoproductivospaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsdtconsumoproductivospaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsdtconsumoproductivospaginationbar_Class = "PaginationBar";
         cmbavLocalidaddestino_Jsonclick = "";
         cmbavLocalidaddestino.Visible = 1;
         cmbavLocalidadorigen_Jsonclick = "";
         cmbavLocalidadorigen.Visible = 1;
         edtavMedidasid_Jsonclick = "";
         edtavMedidasid_Visible = 1;
         edtavRubrosid_Jsonclick = "";
         edtavRubrosid_Visible = 1;
         edtavDepartamentoid_Jsonclick = "";
         edtavDepartamentoid_Visible = 1;
         edtavZonasid_Jsonclick = "";
         edtavZonasid_Visible = 1;
         edtavCardlefticon1_value_Jsonclick = "";
         edtavCardlefticon1_value_Enabled = 1;
         edtavCardlefticon2_value_Jsonclick = "";
         edtavCardlefticon2_value_Enabled = 1;
         divTablechart1_Height = 0;
         Combo_localidaddestino_Caption = "";
         Combo_localidadorigen_Caption = "";
         divTablemudanzas_Visible = 1;
         Combo_medidasid_Caption = "";
         Combo_rubrosid_Caption = "";
         Combo_departamentoid_Caption = "";
         Combo_zonasid_Caption = "";
         divCombo_zonasid_cell_Class = "col-xs-12";
         divTableservicios_Visible = 1;
         radavFiltro_Jsonclick = "";
         Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue = 10;
         subFreestylegrid1_Class = "FreeStyleGrid";
         Grid1_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid1_titlescategories_Gridtitlescategories = "";
         Dvpanel_cardlefticon1_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Iconposition = "Right";
         Dvpanel_cardlefticon1_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardlefticon1_maintable_Title = "";
         Dvpanel_cardlefticon1_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardlefticon1_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardlefticon1_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon1_maintable_Width = "100%";
         Dvpanel_cardlefticon2_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon2_maintable_Iconposition = "Right";
         Dvpanel_cardlefticon2_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon2_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon2_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardlefticon2_maintable_Title = "";
         Dvpanel_cardlefticon2_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardlefticon2_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardlefticon2_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardlefticon2_maintable_Width = "100%";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Title = context.GetMessage( "Calendario", "");
         Dvpanel_tablechart1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Utchartstackedbar_Saturday = Convert.ToBoolean( 0);
         Utchartstackedbar_Friday = Convert.ToBoolean( 0);
         Utchartstackedbar_Thursday = Convert.ToBoolean( 0);
         Utchartstackedbar_Wednesday = Convert.ToBoolean( 0);
         Utchartstackedbar_Tuesday = Convert.ToBoolean( 0);
         Utchartstackedbar_Monday = Convert.ToBoolean( 0);
         Utchartstackedbar_Sunday = Convert.ToBoolean( 0);
         Utchartstackedbar_Listbuttonposition = "None";
         Utchartstackedbar_Daybuttonposition = "None";
         Utchartstackedbar_Weekbuttonposition = "None";
         Utchartstackedbar_Monthbuttonposition = "None";
         Utchartstackedbar_Titleposition = "HeaderCenter";
         Utchartstackedbar_Shownoncurrentdates = Convert.ToBoolean( 0);
         Utchartstackedbar_Daymaxevents = 2;
         Utchartstackedbar_Nowindicator = Convert.ToBoolean( -1);
         Utchartstackedbar_Includedeleteinpopup = Convert.ToBoolean( 0);
         Utchartstackedbar_Includeupdateinpopup = Convert.ToBoolean( 0);
         Utchartstackedbar_Navlinks = Convert.ToBoolean( -1);
         Utchartstackedbar_Enableeventshoursperday = Convert.ToBoolean( 0);
         Utchartstackedbar_Enabledayheaders = Convert.ToBoolean( -1);
         Utchartstackedbar_Enableweekends = Convert.ToBoolean( -1);
         Utchartstackedbar_Defaulteventstyle = "Grayscale";
         Utchartstackedbar_Viewstyle = "Standard";
         Utchartstackedbar_Selectable = Convert.ToBoolean( 0);
         Grid1paginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Grid1paginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Grid1paginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Grid1paginationbar_Next = "WWP_PagingNextCaption";
         Grid1paginationbar_Previous = "WWP_PagingPreviousCaption";
         Grid1paginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Grid1paginationbar_Rowsperpageselectedvalue = 10;
         Grid1paginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Grid1paginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Grid1paginationbar_Pagingcaptionposition = "Left";
         Grid1paginationbar_Pagingbuttonsposition = "Right";
         Grid1paginationbar_Pagestoshow = 5;
         Grid1paginationbar_Showlast = Convert.ToBoolean( 0);
         Grid1paginationbar_Shownext = Convert.ToBoolean( -1);
         Grid1paginationbar_Showprevious = Convert.ToBoolean( -1);
         Grid1paginationbar_Showfirst = Convert.ToBoolean( 0);
         Grid1paginationbar_Class = "PaginationBar";
         Dvpanel_unnamedtable6_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Iconposition = "Right";
         Dvpanel_unnamedtable6_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable6_Title = context.GetMessage( "Capacidad productiva diaria (min)", "");
         Dvpanel_unnamedtable6_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_unnamedtable6_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable6_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Width = "100%";
         Dvpanel_unnamedtable5_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Iconposition = "Right";
         Dvpanel_unnamedtable5_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Title = context.GetMessage( "Parámetros", "");
         Dvpanel_unnamedtable5_Cls = "panel PanelFilled";
         Dvpanel_unnamedtable5_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Width = "100%";
         Combo_localidaddestino_Emptyitemtext = "Todas";
         Combo_localidaddestino_Cls = "ExtendedCombo DVBootstrapResponsivePanel";
         Combo_localidadorigen_Emptyitemtext = "Todas";
         Combo_localidadorigen_Cls = "ExtendedCombo DVBootstrapResponsivePanel";
         Combo_medidasid_Emptyitemtext = "Todos";
         Combo_medidasid_Datalistprocparametersprefix = "";
         Combo_medidasid_Datalistproc = "Dashboard.Dashboard1LoadDVCombo";
         Combo_medidasid_Cls = "ExtendedCombo DynamicFilters";
         Combo_rubrosid_Emptyitemtext = "Todos";
         Combo_rubrosid_Cls = "ExtendedCombo DynamicFilters";
         Combo_departamentoid_Emptyitemtext = "Todos";
         Combo_departamentoid_Cls = "ExtendedCombo DynamicFilters";
         Combo_zonasid_Emptyitemtext = "Todos";
         Combo_zonasid_Visible = Convert.ToBoolean( -1);
         Combo_zonasid_Cls = "ExtendedCombo DVBootstrapResponsivePanel";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Panel de Control", "");
         edtTablaAuxDepartamentoId_Visible = 1;
         edtTablaAuxCapacidadProd_Visible = 1;
         edtTablaAuxDepartamentoNombre_Visible = 1;
         edtTablaAuxId_Visible = 1;
         subGridsdtconsumoproductivos_Rows = 0;
         subGrid1_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'edtTablaAuxId_Visible',ctrl:'TABLAAUXID',prop:'Visible'},{av:'edtTablaAuxDepartamentoNombre_Visible',ctrl:'TABLAAUXDEPARTAMENTONOMBRE',prop:'Visible'},{av:'edtTablaAuxCapacidadProd_Visible',ctrl:'TABLAAUXCAPACIDADPROD',prop:'Visible'},{av:'edtTablaAuxDepartamentoId_Visible',ctrl:'TABLAAUXDEPARTAMENTOID',prop:'Visible'},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'FREESTYLEGRID2_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID2_nEOF',type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nEOF',type:'int'},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'AV38Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39Grid1PageCount',fld:'vGRID1PAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{ctrl:'SDTCONSUMOPRODUCTIVO__DIA',prop:'Columnheaderclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES',prop:'Columnheaderclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS',prop:'Columnheaderclass'},{av:'edtavAceptados_Columnheaderclass',ctrl:'vACEPTADOS',prop:'Columnheaderclass'},{av:'AV56GridSDTConsumoProductivosCurrentPage',fld:'vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridSDTConsumoProductivosPageCount',fld:'vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E26GR3',iparms:[{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV48Aceptados',fld:'vACEPTADOS',pic:'',type:'svchar'},{ctrl:'SDTCONSUMOPRODUCTIVO__DIA',prop:'Columnclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES',prop:'Columnclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS',prop:'Columnclass'},{av:'edtavAceptados_Columnclass',ctrl:'vACEPTADOS',prop:'Columnclass'}]}");
         setEventMetadata("FREESTYLEGRID2.LOAD","{handler:'E24GR4',iparms:[]");
         setEventMetadata("FREESTYLEGRID2.LOAD",",oparms:[]}");
         setEventMetadata("GRIDSDTCONSUMOPRODUCTIVOS.LOAD","{handler:'E25GR5',iparms:[]");
         setEventMetadata("GRIDSDTCONSUMOPRODUCTIVOS.LOAD",",oparms:[]}");
         setEventMetadata("FREESTYLEGRID1.LOAD","{handler:'E23GR2',iparms:[{av:'A832TablaAuxDepartamentoNombre',fld:'TABLAAUXDEPARTAMENTONOMBRE',pic:'',type:'char'},{av:'A833TablaAuxCapacidadProd',fld:'TABLAAUXCAPACIDADPROD',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("FREESTYLEGRID1.LOAD",",oparms:[{av:'edtavDepartamentonombre_Fontbold',ctrl:'vDEPARTAMENTONOMBRE',prop:'Fontbold'},{av:'AV50DepartamentoNombre',fld:'vDEPARTAMENTONOMBRE',pic:'',type:'char'},{av:'AV51Capacidad',fld:'vCAPACIDAD',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE","{handler:'E13GR2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'Grid1paginationbar_Selectedpage',ctrl:'GRID1PAGINATIONBAR',prop:'SelectedPage'},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'edtTablaAuxId_Visible',ctrl:'TABLAAUXID',prop:'Visible'},{av:'edtTablaAuxDepartamentoNombre_Visible',ctrl:'TABLAAUXDEPARTAMENTONOMBRE',prop:'Visible'},{av:'edtTablaAuxCapacidadProd_Visible',ctrl:'TABLAAUXCAPACIDADPROD',prop:'Visible'},{av:'edtTablaAuxDepartamentoId_Visible',ctrl:'TABLAAUXDEPARTAMENTOID',prop:'Visible'},{av:'FREESTYLEGRID2_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID2_nEOF',type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nEOF',type:'int'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'AV38Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39Grid1PageCount',fld:'vGRID1PAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{ctrl:'SDTCONSUMOPRODUCTIVO__DIA',prop:'Columnheaderclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES',prop:'Columnheaderclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS',prop:'Columnheaderclass'},{av:'edtavAceptados_Columnheaderclass',ctrl:'vACEPTADOS',prop:'Columnheaderclass'},{av:'AV56GridSDTConsumoProductivosCurrentPage',fld:'vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridSDTConsumoProductivosPageCount',fld:'vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E14GR2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'Grid1paginationbar_Rowsperpageselectedvalue',ctrl:'GRID1PAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'}]}");
         setEventMetadata("GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE","{handler:'E15GR2',iparms:[{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nEOF',type:'int'},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'Gridsdtconsumoproductivospaginationbar_Selectedpage',ctrl:'GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR',prop:'SelectedPage'},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'edtTablaAuxId_Visible',ctrl:'TABLAAUXID',prop:'Visible'},{av:'edtTablaAuxDepartamentoNombre_Visible',ctrl:'TABLAAUXDEPARTAMENTONOMBRE',prop:'Visible'},{av:'edtTablaAuxCapacidadProd_Visible',ctrl:'TABLAAUXCAPACIDADPROD',prop:'Visible'},{av:'edtTablaAuxDepartamentoId_Visible',ctrl:'TABLAAUXDEPARTAMENTOID',prop:'Visible'},{av:'GRID1_nEOF',type:'int'},{av:'FREESTYLEGRID2_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID2_nEOF',type:'int'}]");
         setEventMetadata("GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'AV38Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39Grid1PageCount',fld:'vGRID1PAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{ctrl:'SDTCONSUMOPRODUCTIVO__DIA',prop:'Columnheaderclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASDISPONIBLES',prop:'Columnheaderclass'},{ctrl:'SDTCONSUMOPRODUCTIVO__HORASSOLICITADAS',prop:'Columnheaderclass'},{av:'edtavAceptados_Columnheaderclass',ctrl:'vACEPTADOS',prop:'Columnheaderclass'},{av:'AV56GridSDTConsumoProductivosCurrentPage',fld:'vGRIDSDTCONSUMOPRODUCTIVOSCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridSDTConsumoProductivosPageCount',fld:'vGRIDSDTCONSUMOPRODUCTIVOSPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E16GR2',iparms:[{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nEOF',type:'int'},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDSDTCONSUMOPRODUCTIVOSPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'}]}");
         setEventMetadata("'DOUSERACTION1'","{handler:'E17GR2',iparms:[]");
         setEventMetadata("'DOUSERACTION1'",",oparms:[]}");
         setEventMetadata("'DOAPLICAR2'","{handler:'E18GR2',iparms:[{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'AV11ZonasId',fld:'vZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV14MedidasId',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31Origen',fld:'vORIGEN',pic:'',type:'svchar'},{av:'AV32Destino',fld:'vDESTINO',pic:'',type:'svchar'}]");
         setEventMetadata("'DOAPLICAR2'",",oparms:[{av:'AV23Events',fld:'vEVENTS',pic:''}]}");
         setEventMetadata("'DOAPLICAR'","{handler:'E19GR2',iparms:[{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'AV11ZonasId',fld:'vZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV14MedidasId',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31Origen',fld:'vORIGEN',pic:'',type:'svchar'},{av:'AV32Destino',fld:'vDESTINO',pic:'',type:'svchar'},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'edtTablaAuxId_Visible',ctrl:'TABLAAUXID',prop:'Visible'},{av:'edtTablaAuxDepartamentoNombre_Visible',ctrl:'TABLAAUXDEPARTAMENTONOMBRE',prop:'Visible'},{av:'edtTablaAuxCapacidadProd_Visible',ctrl:'TABLAAUXCAPACIDADPROD',prop:'Visible'},{av:'edtTablaAuxDepartamentoId_Visible',ctrl:'TABLAAUXDEPARTAMENTOID',prop:'Visible'},{av:'GRID1_nEOF',type:'int'},{av:'FREESTYLEGRID2_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID2_nEOF',type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'subGridsdtconsumoproductivos_Rows',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'Rows'}]");
         setEventMetadata("'DOAPLICAR'",",oparms:[{av:'AV23Events',fld:'vEVENTS',pic:''},{av:'AV47SDTConsumoProductivo',fld:'vSDTCONSUMOPRODUCTIVO',grid:140,pic:''},{av:'nGXsfl_140_idx',ctrl:'GRID',prop:'GridCurrRow',grid:140},{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_140',ctrl:'GRID1',prop:'GridRC',grid:140,type:'int'},{av:'GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_161',ctrl:'GRIDSDTCONSUMOPRODUCTIVOS',prop:'GridRC',grid:161,type:'int'}]}");
         setEventMetadata("COMBO_MEDIDASID.ONOPTIONCLICKED","{handler:'E12GR2',iparms:[{av:'Combo_medidasid_Selectedvalue_get',ctrl:'COMBO_MEDIDASID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_MEDIDASID.ONOPTIONCLICKED",",oparms:[{av:'AV14MedidasId',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("COMBO_RUBROSID.ONOPTIONCLICKED","{handler:'E11GR2',iparms:[{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'Combo_rubrosid_Selectedvalue_get',ctrl:'COMBO_RUBROSID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_RUBROSID.ONOPTIONCLICKED",",oparms:[{av:'AV21Cond_RubrosId',fld:'vCOND_RUBROSID',pic:'ZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV14MedidasId',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Combo_medidasid_Selectedvalue_set',ctrl:'COMBO_MEDIDASID',prop:'SelectedValue_set'},{av:'Combo_medidasid_Selectedtext_set',ctrl:'COMBO_MEDIDASID',prop:'SelectedText_set'}]}");
         setEventMetadata("VFILTRO.CONTROLVALUECHANGED","{handler:'E20GR2',iparms:[{av:'radavFiltro'},{av:'AV26Filtro',fld:'vFILTRO',pic:'',type:'svchar'},{av:'AV11ZonasId',fld:'vZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV14MedidasId',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31Origen',fld:'vORIGEN',pic:'',type:'svchar'},{av:'AV32Destino',fld:'vDESTINO',pic:'',type:'svchar'}]");
         setEventMetadata("VFILTRO.CONTROLVALUECHANGED",",oparms:[{av:'cmbavLocalidadorigen'},{av:'AV27LocalidadOrigen',fld:'vLOCALIDADORIGEN',pic:'',type:'svchar'},{av:'Combo_localidadorigen_Selectedvalue_set',ctrl:'COMBO_LOCALIDADORIGEN',prop:'SelectedValue_set'},{av:'AV31Origen',fld:'vORIGEN',pic:'',type:'svchar'},{av:'cmbavLocalidaddestino'},{av:'AV29LocalidadDestino',fld:'vLOCALIDADDESTINO',pic:'',type:'svchar'},{av:'Combo_localidaddestino_Selectedvalue_set',ctrl:'COMBO_LOCALIDADDESTINO',prop:'SelectedValue_set'},{av:'AV32Destino',fld:'vDESTINO',pic:'',type:'svchar'},{av:'AV11ZonasId',fld:'vZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Combo_zonasid_Selectedvalue_set',ctrl:'COMBO_ZONASID',prop:'SelectedValue_set'},{av:'AV12DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Combo_departamentoid_Selectedvalue_set',ctrl:'COMBO_DEPARTAMENTOID',prop:'SelectedValue_set'},{av:'AV13RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'Combo_rubrosid_Selectedvalue_set',ctrl:'COMBO_RUBROSID',prop:'SelectedValue_set'},{av:'AV14MedidasId',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Combo_medidasid_Selectedvalue_set',ctrl:'COMBO_MEDIDASID',prop:'SelectedValue_set'},{av:'divTableservicios_Visible',ctrl:'TABLESERVICIOS',prop:'Visible'},{av:'divTablemudanzas_Visible',ctrl:'TABLEMUDANZAS',prop:'Visible'},{av:'AV23Events',fld:'vEVENTS',pic:''}]}");
         setEventMetadata("CARDLEFTICON2_MOREINFOCAPTION.CLICK","{handler:'E28GR1',iparms:[]");
         setEventMetadata("CARDLEFTICON2_MOREINFOCAPTION.CLICK",",oparms:[]}");
         setEventMetadata("CARDLEFTICON1_MOREINFOCAPTION.CLICK","{handler:'E27GR1',iparms:[]");
         setEventMetadata("CARDLEFTICON1_MOREINFOCAPTION.CLICK",",oparms:[]}");
         setEventMetadata("VALIDV_MEDIDASID","{handler:'Validv_Medidasid',iparms:[]");
         setEventMetadata("VALIDV_MEDIDASID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tablaauxdepartamentoid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Aceptados',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv8',iparms:[]");
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
         Grid1paginationbar_Selectedpage = "";
         Gridsdtconsumoproductivospaginationbar_Selectedpage = "";
         Combo_localidaddestino_Selectedvalue_get = "";
         Combo_localidaddestino_Selectedtext_get = "";
         Combo_localidadorigen_Selectedvalue_get = "";
         Combo_localidadorigen_Selectedtext_get = "";
         Combo_medidasid_Selectedvalue_get = "";
         Combo_rubrosid_Selectedvalue_get = "";
         Combo_departamentoid_Selectedvalue_get = "";
         Combo_zonasid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV26Filtro = "";
         AV47SDTConsumoProductivo = new GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>( context, "SDTConsumoProductivoItem", "AlmangoX");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15ZonasId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17DepartamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18RubrosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19MedidasId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28LocalidadOrigen_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV30LocalidadDestino_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV40Grid1AppliedFilters = "";
         AV23Events = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "AlmangoX");
         AV31Origen = "";
         AV32Destino = "";
         Combo_zonasid_Selectedvalue_set = "";
         Combo_departamentoid_Selectedvalue_set = "";
         Combo_rubrosid_Selectedvalue_set = "";
         Combo_medidasid_Selectedvalue_set = "";
         Combo_medidasid_Selectedtext_set = "";
         Combo_localidadorigen_Selectedvalue_set = "";
         Combo_localidaddestino_Selectedvalue_set = "";
         Grid1_titlescategories_Gridinternalname = "";
         Grid1_empowerer_Gridinternalname = "";
         Gridsdtconsumoproductivos_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_unnamedtable5 = new GXUserControl();
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblTextblockcombo_zonasid_Jsonclick = "";
         ucCombo_zonasid = new GXUserControl();
         lblTextblockcombo_departamentoid_Jsonclick = "";
         ucCombo_departamentoid = new GXUserControl();
         lblTextblockcombo_rubrosid_Jsonclick = "";
         ucCombo_rubrosid = new GXUserControl();
         lblTextblockcombo_medidasid_Jsonclick = "";
         ucCombo_medidasid = new GXUserControl();
         lblTextblock1_Jsonclick = "";
         bttBtnaplicar_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblockcombo_localidadorigen_Jsonclick = "";
         ucCombo_localidadorigen = new GXUserControl();
         lblTextblockcombo_localidaddestino_Jsonclick = "";
         ucCombo_localidaddestino = new GXUserControl();
         lblTextblock4_Jsonclick = "";
         bttBtnaplicar2_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         ucDvpanel_unnamedtable6 = new GXUserControl();
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         lblTextblock8_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         ucGrid1paginationbar = new GXUserControl();
         bttBtnuseraction1_Jsonclick = "";
         Freestylegrid2Container = new GXWebGrid( context);
         ucDvpanel_tablechart1 = new GXUserControl();
         ucUtchartstackedbar = new GXUserControl();
         ucDvpanel_cardlefticon2_maintable = new GXUserControl();
         lblCardlefticon2_icon_Jsonclick = "";
         lblCardlefticon2_description_Jsonclick = "";
         ucDvpanel_cardlefticon1_maintable = new GXUserControl();
         lblCardlefticon1_icon_Jsonclick = "";
         lblCardlefticon1_description_Jsonclick = "";
         AV27LocalidadOrigen = "";
         AV29LocalidadDestino = "";
         ucGrid1_titlescategories = new GXUserControl();
         ucGrid1_empowerer = new GXUserControl();
         ucGridsdtconsumoproductivos_empowerer = new GXUserControl();
         GridsdtconsumoproductivosContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         ucGridsdtconsumoproductivospaginationbar = new GXUserControl();
         AV50DepartamentoNombre = "";
         A832TablaAuxDepartamentoNombre = "";
         AV58GridSDTConsumoProductivosAppliedFilters = "";
         AV48Aceptados = "";
         H00GR2_A831TablaAuxDepartamentoId = new long[1] ;
         H00GR2_A833TablaAuxCapacidadProd = new decimal[1] ;
         H00GR2_A832TablaAuxDepartamentoNombre = new string[] {""} ;
         H00GR2_A830TablaAuxId = new long[1] ;
         AV44ParametrosVarchar = "";
         AV45ParametrosEstado = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV52SDTConsumoProd = new GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>( context, "SDTConsumoProductivoItem", "AlmangoX");
         Freestylegrid1Row = new GXWebRow();
         AV49LongVarChar = "";
         GXt_char7 = "";
         GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6 = new GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>( context, "SDTConsumoProductivoItem", "AlmangoX");
         H00GR3_A735MudanzaId = new long[1] ;
         H00GR3_A789MudanzaLocalidadDestino = new string[] {""} ;
         A789MudanzaLocalidadDestino = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00GR4_A735MudanzaId = new long[1] ;
         H00GR4_A788MudanzaLocalidadOrigen = new string[] {""} ;
         A788MudanzaLocalidadOrigen = "";
         H00GR5_A121RubrosId = new short[1] ;
         H00GR5_A137MedidasID = new long[1] ;
         H00GR5_A138MedidasNombre = new string[] {""} ;
         A138MedidasNombre = "";
         H00GR6_A121RubrosId = new short[1] ;
         H00GR6_A122RubrosNombre = new string[] {""} ;
         A122RubrosNombre = "";
         H00GR7_A112DepartamentoId = new long[1] ;
         H00GR7_A113DepartamentoDepartamento = new string[] {""} ;
         A113DepartamentoDepartamento = "";
         H00GR8_A112DepartamentoId = new long[1] ;
         H00GR8_A114DepartamentoMunicipioId = new long[1] ;
         H00GR8_A110ZonasID = new long[1] ;
         H00GR8_A111ZonasNombre = new string[] {""} ;
         A111ZonasNombre = "";
         GXt_objcol_SdtWWP_Calendar_Events_Item1 = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "AlmangoX");
         Grid1Row = new GXWebRow();
         Freestylegrid2Row = new GXWebRow();
         GridsdtconsumoproductivosRow = new GXWebRow();
         lblCardlefticon1_moreinfoicon_Jsonclick = "";
         lblCardlefticon1_moreinfocaption_Jsonclick = "";
         lblCardlefticon2_moreinfoicon_Jsonclick = "";
         lblCardlefticon2_moreinfocaption_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreestylegrid1_Linesclass = "";
         Freestylegrid1Column = new GXWebColumn();
         ROClassString = "";
         subGrid1_Linesclass = "";
         subGridsdtconsumoproductivos_Linesclass = "";
         subFreestylegrid2_Linesclass = "";
         subFreestylegrid1_Header = "";
         Grid1Column = new GXWebColumn();
         subFreestylegrid2_Header = "";
         Freestylegrid2Column = new GXWebColumn();
         GridsdtconsumoproductivosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dashboard.dashboard1__default(),
            new Object[][] {
                new Object[] {
               H00GR2_A831TablaAuxDepartamentoId, H00GR2_A833TablaAuxCapacidadProd, H00GR2_A832TablaAuxDepartamentoNombre, H00GR2_A830TablaAuxId
               }
               , new Object[] {
               H00GR3_A735MudanzaId, H00GR3_A789MudanzaLocalidadDestino
               }
               , new Object[] {
               H00GR4_A735MudanzaId, H00GR4_A788MudanzaLocalidadOrigen
               }
               , new Object[] {
               H00GR5_A121RubrosId, H00GR5_A137MedidasID, H00GR5_A138MedidasNombre
               }
               , new Object[] {
               H00GR6_A121RubrosId, H00GR6_A122RubrosNombre
               }
               , new Object[] {
               H00GR7_A112DepartamentoId, H00GR7_A113DepartamentoDepartamento
               }
               , new Object[] {
               H00GR8_A112DepartamentoId, H00GR8_A114DepartamentoMunicipioId, H00GR8_A110ZonasID, H00GR8_A111ZonasNombre
               }
            }
         );
         /* GeneXus formulas. */
         edtavDepartamentonombre_Enabled = 0;
         edtavCapacidad_Enabled = 0;
         edtavSdtconsumoproductivo__dia_Enabled = 0;
         edtavSdtconsumoproductivo__horasdisponibles_Enabled = 0;
         edtavSdtconsumoproductivo__horassolicitadas_Enabled = 0;
         edtavSdtconsumoproductivo__horastomadas_Enabled = 0;
         edtavAceptados_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajesolicitado_Enabled = 0;
         edtavSdtconsumoproductivo__porcentajetomadas_Enabled = 0;
         edtavCardlefticon2_value_Enabled = 0;
         edtavCardlefticon1_value_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short GRIDSDTCONSUMOPRODUCTIVOS_nEOF ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13RubrosId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short subFreestylegrid2_Backcolorstyle ;
      private short subGridsdtconsumoproductivos_Backcolorstyle ;
      private short AV42Limite ;
      private short AV43Saturado ;
      private short FREESTYLEGRID1_nEOF ;
      private short FREESTYLEGRID2_nEOF ;
      private short edtavDepartamentonombre_Fontbold ;
      private short AV21Cond_RubrosId ;
      private short AV71GXLvl383 ;
      private short A121RubrosId ;
      private short nGXWrapped ;
      private short subFreestylegrid1_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subGridsdtconsumoproductivos_Backstyle ;
      private short subFreestylegrid2_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subFreestylegrid2_Allowselection ;
      private short subFreestylegrid2_Allowhovering ;
      private short subFreestylegrid2_Allowcollapsing ;
      private short subFreestylegrid2_Collapsed ;
      private short subGridsdtconsumoproductivos_Titlebackstyle ;
      private short subGridsdtconsumoproductivos_Allowselection ;
      private short subGridsdtconsumoproductivos_Allowhovering ;
      private short subGridsdtconsumoproductivos_Allowcollapsing ;
      private short subGridsdtconsumoproductivos_Collapsed ;
      private int edtTablaAuxId_Visible ;
      private int edtTablaAuxDepartamentoNombre_Visible ;
      private int edtTablaAuxCapacidadProd_Visible ;
      private int edtTablaAuxDepartamentoId_Visible ;
      private int Grid1paginationbar_Rowsperpageselectedvalue ;
      private int Gridsdtconsumoproductivospaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_107 ;
      private int nRC_GXsfl_140 ;
      private int nRC_GXsfl_154 ;
      private int subFreestylegrid2_Recordcount ;
      private int nRC_GXsfl_161 ;
      private int nGXsfl_161_idx=1 ;
      private int subGrid1_Rows ;
      private int subGridsdtconsumoproductivos_Rows ;
      private int nGXsfl_107_idx=1 ;
      private int nGXsfl_140_idx=1 ;
      private int nGXsfl_154_idx=1 ;
      private int Grid1paginationbar_Pagestoshow ;
      private int Utchartstackedbar_Daymaxevents ;
      private int divTableservicios_Visible ;
      private int divTablemudanzas_Visible ;
      private int AV60GXV1 ;
      private int AV68GXV9 ;
      private int divTablechart1_Height ;
      private int AV33CardLeftIcon2_Value ;
      private int edtavCardlefticon2_value_Enabled ;
      private int AV34CardLeftIcon1_Value ;
      private int edtavCardlefticon1_value_Enabled ;
      private int edtavZonasid_Visible ;
      private int edtavDepartamentoid_Visible ;
      private int edtavRubrosid_Visible ;
      private int edtavMedidasid_Visible ;
      private int AV65GXV6 ;
      private int Gridsdtconsumoproductivospaginationbar_Pagestoshow ;
      private int subFreestylegrid1_Islastpage ;
      private int subGrid1_Islastpage ;
      private int subFreestylegrid2_Islastpage ;
      private int subGridsdtconsumoproductivos_Islastpage ;
      private int edtavDepartamentonombre_Enabled ;
      private int edtavCapacidad_Enabled ;
      private int edtavSdtconsumoproductivo__dia_Enabled ;
      private int edtavSdtconsumoproductivo__horasdisponibles_Enabled ;
      private int edtavSdtconsumoproductivo__horassolicitadas_Enabled ;
      private int edtavSdtconsumoproductivo__horastomadas_Enabled ;
      private int edtavAceptados_Enabled ;
      private int edtavSdtconsumoproductivo__porcentajesolicitado_Enabled ;
      private int edtavSdtconsumoproductivo__porcentajetomadas_Enabled ;
      private int GRID1_nGridOutOfScope ;
      private int GRIDSDTCONSUMOPRODUCTIVOS_nGridOutOfScope ;
      private int edtTablaAuxId_Enabled ;
      private int edtTablaAuxDepartamentoNombre_Enabled ;
      private int edtTablaAuxCapacidadProd_Enabled ;
      private int edtTablaAuxDepartamentoId_Enabled ;
      private int nGXsfl_140_fel_idx=1 ;
      private int nGXsfl_161_fel_idx=1 ;
      private int GXt_int2 ;
      private int GXt_int3 ;
      private int AV37PageToGo ;
      private int nGXsfl_140_bak_idx=1 ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGridsdtconsumoproductivos_Backcolor ;
      private int subGridsdtconsumoproductivos_Allbackcolor ;
      private int subFreestylegrid2_Backcolor ;
      private int subFreestylegrid2_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subFreestylegrid2_Selectedindex ;
      private int subFreestylegrid2_Selectioncolor ;
      private int subFreestylegrid2_Hoveringcolor ;
      private int subGridsdtconsumoproductivos_Titlebackcolor ;
      private int subGridsdtconsumoproductivos_Selectedindex ;
      private int subGridsdtconsumoproductivos_Selectioncolor ;
      private int subGridsdtconsumoproductivos_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRIDSDTCONSUMOPRODUCTIVOS_nFirstRecordOnPage ;
      private long AV12DepartamentoId ;
      private long AV38Grid1CurrentPage ;
      private long AV39Grid1PageCount ;
      private long AV11ZonasId ;
      private long AV14MedidasId ;
      private long A830TablaAuxId ;
      private long A831TablaAuxDepartamentoId ;
      private long AV56GridSDTConsumoProductivosCurrentPage ;
      private long AV57GridSDTConsumoProductivosPageCount ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long GRIDSDTCONSUMOPRODUCTIVOS_nCurrentRecord ;
      private long FREESTYLEGRID2_nCurrentRecord ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private long GRID1_nRecordCount ;
      private long GRIDSDTCONSUMOPRODUCTIVOS_nRecordCount ;
      private long FREESTYLEGRID2_nFirstRecordOnPage ;
      private long A137MedidasID ;
      private long A112DepartamentoId ;
      private long A110ZonasID ;
      private decimal AV51Capacidad ;
      private decimal A833TablaAuxCapacidadProd ;
      private decimal AV46CapacidadProductiva ;
      private decimal GXt_decimal5 ;
      private string Grid1paginationbar_Selectedpage ;
      private string Gridsdtconsumoproductivospaginationbar_Selectedpage ;
      private string Combo_localidaddestino_Selectedvalue_get ;
      private string Combo_localidaddestino_Selectedtext_get ;
      private string Combo_localidadorigen_Selectedvalue_get ;
      private string Combo_localidadorigen_Selectedtext_get ;
      private string Combo_medidasid_Selectedvalue_get ;
      private string Combo_rubrosid_Selectedvalue_get ;
      private string Combo_departamentoid_Selectedvalue_get ;
      private string Combo_zonasid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_107_idx="0001" ;
      private string edtTablaAuxId_Internalname ;
      private string edtTablaAuxDepartamentoNombre_Internalname ;
      private string edtTablaAuxCapacidadProd_Internalname ;
      private string edtTablaAuxDepartamentoId_Internalname ;
      private string sGXsfl_140_idx="0001" ;
      private string sGXsfl_161_idx="0001" ;
      private string sGXsfl_154_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_zonasid_Cls ;
      private string Combo_zonasid_Selectedvalue_set ;
      private string Combo_zonasid_Emptyitemtext ;
      private string Combo_departamentoid_Cls ;
      private string Combo_departamentoid_Selectedvalue_set ;
      private string Combo_departamentoid_Emptyitemtext ;
      private string Combo_rubrosid_Cls ;
      private string Combo_rubrosid_Selectedvalue_set ;
      private string Combo_rubrosid_Emptyitemtext ;
      private string Combo_medidasid_Cls ;
      private string Combo_medidasid_Selectedvalue_set ;
      private string Combo_medidasid_Selectedtext_set ;
      private string Combo_medidasid_Datalistproc ;
      private string Combo_medidasid_Datalistprocparametersprefix ;
      private string Combo_medidasid_Emptyitemtext ;
      private string Combo_localidadorigen_Cls ;
      private string Combo_localidadorigen_Selectedvalue_set ;
      private string Combo_localidadorigen_Emptyitemtext ;
      private string Combo_localidaddestino_Cls ;
      private string Combo_localidaddestino_Selectedvalue_set ;
      private string Combo_localidaddestino_Emptyitemtext ;
      private string Dvpanel_unnamedtable5_Width ;
      private string Dvpanel_unnamedtable5_Cls ;
      private string Dvpanel_unnamedtable5_Title ;
      private string Dvpanel_unnamedtable5_Iconposition ;
      private string Dvpanel_unnamedtable6_Width ;
      private string Dvpanel_unnamedtable6_Cls ;
      private string Dvpanel_unnamedtable6_Title ;
      private string Dvpanel_unnamedtable6_Iconposition ;
      private string Grid1paginationbar_Class ;
      private string Grid1paginationbar_Pagingbuttonsposition ;
      private string Grid1paginationbar_Pagingcaptionposition ;
      private string Grid1paginationbar_Emptygridclass ;
      private string Grid1paginationbar_Rowsperpageoptions ;
      private string Grid1paginationbar_Previous ;
      private string Grid1paginationbar_Next ;
      private string Grid1paginationbar_Caption ;
      private string Grid1paginationbar_Emptygridcaption ;
      private string Grid1paginationbar_Rowsperpagecaption ;
      private string Utchartstackedbar_Viewstyle ;
      private string Utchartstackedbar_Defaulteventstyle ;
      private string Utchartstackedbar_Titleposition ;
      private string Utchartstackedbar_Monthbuttonposition ;
      private string Utchartstackedbar_Weekbuttonposition ;
      private string Utchartstackedbar_Daybuttonposition ;
      private string Utchartstackedbar_Listbuttonposition ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Dvpanel_cardlefticon2_maintable_Width ;
      private string Dvpanel_cardlefticon2_maintable_Cls ;
      private string Dvpanel_cardlefticon2_maintable_Title ;
      private string Dvpanel_cardlefticon2_maintable_Iconposition ;
      private string Dvpanel_cardlefticon1_maintable_Width ;
      private string Dvpanel_cardlefticon1_maintable_Cls ;
      private string Dvpanel_cardlefticon1_maintable_Title ;
      private string Dvpanel_cardlefticon1_maintable_Iconposition ;
      private string Grid1_titlescategories_Gridinternalname ;
      private string Grid1_titlescategories_Gridtitlescategories ;
      private string Grid1_empowerer_Gridinternalname ;
      private string Gridsdtconsumoproductivos_empowerer_Gridinternalname ;
      private string subFreestylegrid1_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string Dvpanel_unnamedtable5_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavFiltro_Internalname ;
      private string radavFiltro_Jsonclick ;
      private string divTableservicios_Internalname ;
      private string divCombo_zonasid_cell_Internalname ;
      private string divCombo_zonasid_cell_Class ;
      private string divTablesplittedzonasid_Internalname ;
      private string lblTextblockcombo_zonasid_Internalname ;
      private string lblTextblockcombo_zonasid_Jsonclick ;
      private string Combo_zonasid_Caption ;
      private string Combo_zonasid_Internalname ;
      private string divTablesplitteddepartamentoid_Internalname ;
      private string lblTextblockcombo_departamentoid_Internalname ;
      private string lblTextblockcombo_departamentoid_Jsonclick ;
      private string Combo_departamentoid_Caption ;
      private string Combo_departamentoid_Internalname ;
      private string divTablesplittedrubrosid_Internalname ;
      private string lblTextblockcombo_rubrosid_Internalname ;
      private string lblTextblockcombo_rubrosid_Jsonclick ;
      private string Combo_rubrosid_Caption ;
      private string Combo_rubrosid_Internalname ;
      private string divTablesplittedmedidasid_Internalname ;
      private string lblTextblockcombo_medidasid_Internalname ;
      private string lblTextblockcombo_medidasid_Jsonclick ;
      private string Combo_medidasid_Caption ;
      private string Combo_medidasid_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string bttBtnaplicar_Internalname ;
      private string bttBtnaplicar_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string divTablemudanzas_Internalname ;
      private string divTablesplittedlocalidadorigen_Internalname ;
      private string lblTextblockcombo_localidadorigen_Internalname ;
      private string lblTextblockcombo_localidadorigen_Jsonclick ;
      private string Combo_localidadorigen_Caption ;
      private string Combo_localidadorigen_Internalname ;
      private string divTablesplittedlocalidaddestino_Internalname ;
      private string lblTextblockcombo_localidaddestino_Internalname ;
      private string lblTextblockcombo_localidaddestino_Jsonclick ;
      private string Combo_localidaddestino_Caption ;
      private string Combo_localidaddestino_Internalname ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string bttBtnaplicar2_Internalname ;
      private string bttBtnaplicar2_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string Dvpanel_unnamedtable6_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string divGrid1tablewithpaginationbar_Internalname ;
      private string subGrid1_Internalname ;
      private string Grid1paginationbar_Internalname ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string subFreestylegrid2_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string Utchartstackedbar_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string Dvpanel_cardlefticon2_maintable_Internalname ;
      private string divCardlefticon2_maintable_Internalname ;
      private string lblCardlefticon2_icon_Internalname ;
      private string lblCardlefticon2_icon_Jsonclick ;
      private string divCardlefticon2_tableinfo_Internalname ;
      private string lblCardlefticon2_description_Internalname ;
      private string lblCardlefticon2_description_Jsonclick ;
      private string edtavCardlefticon2_value_Internalname ;
      private string edtavCardlefticon2_value_Jsonclick ;
      private string Dvpanel_cardlefticon1_maintable_Internalname ;
      private string divCardlefticon1_maintable_Internalname ;
      private string lblCardlefticon1_icon_Internalname ;
      private string lblCardlefticon1_icon_Jsonclick ;
      private string divCardlefticon1_tableinfo_Internalname ;
      private string lblCardlefticon1_description_Internalname ;
      private string lblCardlefticon1_description_Jsonclick ;
      private string edtavCardlefticon1_value_Internalname ;
      private string edtavCardlefticon1_value_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavZonasid_Internalname ;
      private string edtavZonasid_Jsonclick ;
      private string edtavDepartamentoid_Internalname ;
      private string edtavDepartamentoid_Jsonclick ;
      private string edtavRubrosid_Internalname ;
      private string edtavRubrosid_Jsonclick ;
      private string edtavMedidasid_Internalname ;
      private string edtavMedidasid_Jsonclick ;
      private string cmbavLocalidadorigen_Internalname ;
      private string cmbavLocalidadorigen_Jsonclick ;
      private string cmbavLocalidaddestino_Internalname ;
      private string cmbavLocalidaddestino_Jsonclick ;
      private string Grid1_titlescategories_Internalname ;
      private string Grid1_empowerer_Internalname ;
      private string Gridsdtconsumoproductivos_empowerer_Internalname ;
      private string subGridsdtconsumoproductivos_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string Gridsdtconsumoproductivospaginationbar_Class ;
      private string Gridsdtconsumoproductivospaginationbar_Internalname ;
      private string Gridsdtconsumoproductivospaginationbar_Pagingbuttonsposition ;
      private string Gridsdtconsumoproductivospaginationbar_Pagingcaptionposition ;
      private string Gridsdtconsumoproductivospaginationbar_Emptygridclass ;
      private string Gridsdtconsumoproductivospaginationbar_Rowsperpageoptions ;
      private string Gridsdtconsumoproductivospaginationbar_Previous ;
      private string Gridsdtconsumoproductivospaginationbar_Next ;
      private string Gridsdtconsumoproductivospaginationbar_Caption ;
      private string Gridsdtconsumoproductivospaginationbar_Emptygridcaption ;
      private string Gridsdtconsumoproductivospaginationbar_Rowsperpagecaption ;
      private string AV50DepartamentoNombre ;
      private string edtavDepartamentonombre_Internalname ;
      private string edtavCapacidad_Internalname ;
      private string A832TablaAuxDepartamentoNombre ;
      private string edtavAceptados_Internalname ;
      private string sGXsfl_140_fel_idx="0001" ;
      private string sGXsfl_161_fel_idx="0001" ;
      private string AV45ParametrosEstado ;
      private string edtavSdtconsumoproductivo__dia_Columnheaderclass ;
      private string edtavSdtconsumoproductivo__dia_Internalname ;
      private string edtavSdtconsumoproductivo__horasdisponibles_Columnheaderclass ;
      private string edtavSdtconsumoproductivo__horasdisponibles_Internalname ;
      private string edtavSdtconsumoproductivo__horassolicitadas_Columnheaderclass ;
      private string edtavSdtconsumoproductivo__horassolicitadas_Internalname ;
      private string edtavAceptados_Columnheaderclass ;
      private string GXt_char7 ;
      private string A138MedidasNombre ;
      private string A122RubrosNombre ;
      private string A113DepartamentoDepartamento ;
      private string A111ZonasNombre ;
      private string edtavSdtconsumoproductivo__dia_Columnclass ;
      private string edtavSdtconsumoproductivo__horasdisponibles_Columnclass ;
      private string edtavSdtconsumoproductivo__horassolicitadas_Columnclass ;
      private string edtavAceptados_Columnclass ;
      private string tblCardlefticon1_moreinfo_Internalname ;
      private string lblCardlefticon1_moreinfoicon_Internalname ;
      private string lblCardlefticon1_moreinfoicon_Jsonclick ;
      private string lblCardlefticon1_moreinfocaption_Internalname ;
      private string lblCardlefticon1_moreinfocaption_Jsonclick ;
      private string tblCardlefticon2_moreinfo_Internalname ;
      private string lblCardlefticon2_moreinfoicon_Internalname ;
      private string lblCardlefticon2_moreinfoicon_Jsonclick ;
      private string lblCardlefticon2_moreinfocaption_Internalname ;
      private string lblCardlefticon2_moreinfocaption_Jsonclick ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subFreestylegrid1_Linesclass ;
      private string tblFreestylegrid1layouttable_Internalname ;
      private string ROClassString ;
      private string edtavDepartamentonombre_Jsonclick ;
      private string edtavCapacidad_Jsonclick ;
      private string tblUnnamedtablecontentfsfreestylegrid1_Internalname ;
      private string edtTablaAuxId_Jsonclick ;
      private string edtTablaAuxDepartamentoNombre_Jsonclick ;
      private string edtTablaAuxCapacidadProd_Jsonclick ;
      private string edtTablaAuxDepartamentoId_Jsonclick ;
      private string edtavSdtconsumoproductivo__horastomadas_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavSdtconsumoproductivo__dia_Jsonclick ;
      private string edtavSdtconsumoproductivo__horasdisponibles_Jsonclick ;
      private string edtavSdtconsumoproductivo__horassolicitadas_Jsonclick ;
      private string edtavSdtconsumoproductivo__horastomadas_Jsonclick ;
      private string edtavAceptados_Jsonclick ;
      private string edtavSdtconsumoproductivo__porcentajesolicitado_Internalname ;
      private string edtavSdtconsumoproductivo__porcentajetomadas_Internalname ;
      private string subGridsdtconsumoproductivos_Class ;
      private string subGridsdtconsumoproductivos_Linesclass ;
      private string edtavSdtconsumoproductivo__porcentajesolicitado_Jsonclick ;
      private string edtavSdtconsumoproductivo__porcentajetomadas_Jsonclick ;
      private string sGXsfl_154_fel_idx="0001" ;
      private string subFreestylegrid2_Class ;
      private string subFreestylegrid2_Linesclass ;
      private string tblFreestylegrid2layouttable_Internalname ;
      private string divGridsdtconsumoproductivostablewithpaginationbar_Internalname ;
      private string subFreestylegrid1_Header ;
      private string subGrid1_Header ;
      private string subFreestylegrid2_Header ;
      private string subGridsdtconsumoproductivos_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool Combo_zonasid_Visible ;
      private bool Dvpanel_unnamedtable5_Autowidth ;
      private bool Dvpanel_unnamedtable5_Autoheight ;
      private bool Dvpanel_unnamedtable5_Collapsible ;
      private bool Dvpanel_unnamedtable5_Collapsed ;
      private bool Dvpanel_unnamedtable5_Showcollapseicon ;
      private bool Dvpanel_unnamedtable5_Autoscroll ;
      private bool Dvpanel_unnamedtable6_Autowidth ;
      private bool Dvpanel_unnamedtable6_Autoheight ;
      private bool Dvpanel_unnamedtable6_Collapsible ;
      private bool Dvpanel_unnamedtable6_Collapsed ;
      private bool Dvpanel_unnamedtable6_Showcollapseicon ;
      private bool Dvpanel_unnamedtable6_Autoscroll ;
      private bool Grid1paginationbar_Showfirst ;
      private bool Grid1paginationbar_Showprevious ;
      private bool Grid1paginationbar_Shownext ;
      private bool Grid1paginationbar_Showlast ;
      private bool Grid1paginationbar_Rowsperpageselector ;
      private bool Utchartstackedbar_Selectable ;
      private bool Utchartstackedbar_Enableweekends ;
      private bool Utchartstackedbar_Enabledayheaders ;
      private bool Utchartstackedbar_Enableeventshoursperday ;
      private bool Utchartstackedbar_Navlinks ;
      private bool Utchartstackedbar_Includeupdateinpopup ;
      private bool Utchartstackedbar_Includedeleteinpopup ;
      private bool Utchartstackedbar_Nowindicator ;
      private bool Utchartstackedbar_Shownoncurrentdates ;
      private bool Utchartstackedbar_Sunday ;
      private bool Utchartstackedbar_Monday ;
      private bool Utchartstackedbar_Tuesday ;
      private bool Utchartstackedbar_Wednesday ;
      private bool Utchartstackedbar_Thursday ;
      private bool Utchartstackedbar_Friday ;
      private bool Utchartstackedbar_Saturday ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_cardlefticon2_maintable_Autowidth ;
      private bool Dvpanel_cardlefticon2_maintable_Autoheight ;
      private bool Dvpanel_cardlefticon2_maintable_Collapsible ;
      private bool Dvpanel_cardlefticon2_maintable_Collapsed ;
      private bool Dvpanel_cardlefticon2_maintable_Showcollapseicon ;
      private bool Dvpanel_cardlefticon2_maintable_Autoscroll ;
      private bool Dvpanel_cardlefticon1_maintable_Autowidth ;
      private bool Dvpanel_cardlefticon1_maintable_Autoheight ;
      private bool Dvpanel_cardlefticon1_maintable_Collapsible ;
      private bool Dvpanel_cardlefticon1_maintable_Collapsed ;
      private bool Dvpanel_cardlefticon1_maintable_Showcollapseicon ;
      private bool Dvpanel_cardlefticon1_maintable_Autoscroll ;
      private bool Grid1_empowerer_Hascategories ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool Gridsdtconsumoproductivospaginationbar_Showfirst ;
      private bool Gridsdtconsumoproductivospaginationbar_Showprevious ;
      private bool Gridsdtconsumoproductivospaginationbar_Shownext ;
      private bool Gridsdtconsumoproductivospaginationbar_Showlast ;
      private bool Gridsdtconsumoproductivospaginationbar_Rowsperpageselector ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_140_Refreshing=false ;
      private bool bGXsfl_154_Refreshing=false ;
      private bool bGXsfl_161_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV140 ;
      private string AV49LongVarChar ;
      private string AV26Filtro ;
      private string AV40Grid1AppliedFilters ;
      private string AV31Origen ;
      private string AV32Destino ;
      private string AV27LocalidadOrigen ;
      private string AV29LocalidadDestino ;
      private string AV58GridSDTConsumoProductivosAppliedFilters ;
      private string AV48Aceptados ;
      private string AV44ParametrosVarchar ;
      private string A789MudanzaLocalidadDestino ;
      private string A788MudanzaLocalidadOrigen ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid Freestylegrid2Container ;
      private GXWebGrid GridsdtconsumoproductivosContainer ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebRow Grid1Row ;
      private GXWebRow Freestylegrid2Row ;
      private GXWebRow GridsdtconsumoproductivosRow ;
      private GXWebColumn Freestylegrid1Column ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn Freestylegrid2Column ;
      private GXWebColumn GridsdtconsumoproductivosColumn ;
      private GXUserControl ucDvpanel_unnamedtable5 ;
      private GXUserControl ucCombo_zonasid ;
      private GXUserControl ucCombo_departamentoid ;
      private GXUserControl ucCombo_rubrosid ;
      private GXUserControl ucCombo_medidasid ;
      private GXUserControl ucCombo_localidadorigen ;
      private GXUserControl ucCombo_localidaddestino ;
      private GXUserControl ucDvpanel_unnamedtable6 ;
      private GXUserControl ucGrid1paginationbar ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartstackedbar ;
      private GXUserControl ucDvpanel_cardlefticon2_maintable ;
      private GXUserControl ucDvpanel_cardlefticon1_maintable ;
      private GXUserControl ucGrid1_titlescategories ;
      private GXUserControl ucGrid1_empowerer ;
      private GXUserControl ucGridsdtconsumoproductivos_empowerer ;
      private GXUserControl ucGridsdtconsumoproductivospaginationbar ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXRadio radavFiltro ;
      private GXCombobox cmbavLocalidadorigen ;
      private GXCombobox cmbavLocalidaddestino ;
      private GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> AV47SDTConsumoProductivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV20DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15ZonasId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17DepartamentoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18RubrosId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19MedidasId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV28LocalidadOrigen_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30LocalidadDestino_Data ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> AV23Events ;
      private IDataStoreProvider pr_default ;
      private long[] H00GR2_A831TablaAuxDepartamentoId ;
      private decimal[] H00GR2_A833TablaAuxCapacidadProd ;
      private string[] H00GR2_A832TablaAuxDepartamentoNombre ;
      private long[] H00GR2_A830TablaAuxId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> AV52SDTConsumoProd ;
      private GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> GXt_objcol_SdtSDTConsumoProductivo_SDTConsumoProductivoItem6 ;
      private long[] H00GR3_A735MudanzaId ;
      private string[] H00GR3_A789MudanzaLocalidadDestino ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private long[] H00GR4_A735MudanzaId ;
      private string[] H00GR4_A788MudanzaLocalidadOrigen ;
      private short[] H00GR5_A121RubrosId ;
      private long[] H00GR5_A137MedidasID ;
      private string[] H00GR5_A138MedidasNombre ;
      private short[] H00GR6_A121RubrosId ;
      private string[] H00GR6_A122RubrosNombre ;
      private long[] H00GR7_A112DepartamentoId ;
      private string[] H00GR7_A113DepartamentoDepartamento ;
      private long[] H00GR8_A112DepartamentoId ;
      private long[] H00GR8_A114DepartamentoMunicipioId ;
      private long[] H00GR8_A110ZonasID ;
      private string[] H00GR8_A111ZonasNombre ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> GXt_objcol_SdtWWP_Calendar_Events_Item1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class dashboard1__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00GR2;
          prmH00GR2 = new Object[] {
          };
          Object[] prmH00GR3;
          prmH00GR3 = new Object[] {
          };
          Object[] prmH00GR4;
          prmH00GR4 = new Object[] {
          };
          Object[] prmH00GR5;
          prmH00GR5 = new Object[] {
          new ParDef("@AV21Cond_RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV14MedidasId",GXType.Decimal,18,0)
          };
          Object[] prmH00GR6;
          prmH00GR6 = new Object[] {
          };
          Object[] prmH00GR7;
          prmH00GR7 = new Object[] {
          };
          Object[] prmH00GR8;
          prmH00GR8 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00GR2", "SELECT [TablaAuxDepartamentoId], [TablaAuxCapacidadProd], [TablaAuxDepartamentoNombre], [TablaAuxId] FROM [TablaAux] ORDER BY [TablaAuxId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00GR3", "SELECT [MudanzaId], [MudanzaLocalidadDestino] FROM [Mudanza] ORDER BY [MudanzaLocalidadDestino] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00GR4", "SELECT [MudanzaId], [MudanzaLocalidadOrigen] FROM [Mudanza] ORDER BY [MudanzaLocalidadOrigen] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00GR5", "SELECT TOP 1 [RubrosId], [MedidasID], [MedidasNombre] FROM [RubrosMedidas] WHERE [RubrosId] = @AV21Cond_RubrosId and [MedidasID] = @AV14MedidasId ORDER BY [RubrosId], [MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00GR6", "SELECT [RubrosId], [RubrosNombre] FROM [Rubros] ORDER BY [RubrosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00GR7", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00GR8", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [ZonasNombre] FROM [Zonas] ORDER BY [ZonasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GR8,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
       }
    }

 }

}

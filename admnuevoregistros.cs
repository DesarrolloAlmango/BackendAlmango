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
   public class admnuevoregistros : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public admnuevoregistros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public admnuevoregistros( IGxContext context )
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
         cmbSecUserEstado = new GXCombobox();
         cmbusuariosTipo = new GXCombobox();
         cmbusuariosEstado = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsecuser") == 0 )
            {
               gxnrGridsecuser_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsecuser") == 0 )
            {
               gxgrGridsecuser_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridusuarios") == 0 )
            {
               gxnrGridusuarios_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridusuarios") == 0 )
            {
               gxgrGridusuarios_refresh_invoke( ) ;
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

      protected void gxnrGridsecuser_newrow_invoke( )
      {
         nRC_GXsfl_20 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_20"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_20_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_20_idx = GetPar( "sGXsfl_20_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsecuser_newrow( ) ;
         /* End function gxnrGridsecuser_newrow_invoke */
      }

      protected void gxgrGridsecuser_refresh_invoke( )
      {
         subGridsecuser_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsecuser_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridusuarios_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridusuarios_Rows"), "."), 18, MidpointRounding.ToEven));
         AV8IsAuthorized_SecUserName = StringUtil.StrToBool( GetPar( "IsAuthorized_SecUserName"));
         AV15IsAuthorized_usuariosId = StringUtil.StrToBool( GetPar( "IsAuthorized_usuariosId"));
         AV28SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
         AV23usuariosId = GetPar( "usuariosId");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsecuser_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV8IsAuthorized_SecUserName, AV15IsAuthorized_usuariosId, AV28SecUserId, AV23usuariosId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsecuser_refresh_invoke */
      }

      protected void gxnrGridusuarios_newrow_invoke( )
      {
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridusuarios_newrow( ) ;
         /* End function gxnrGridusuarios_newrow_invoke */
      }

      protected void gxgrGridusuarios_refresh_invoke( )
      {
         subGridsecuser_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsecuser_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridusuarios_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridusuarios_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15IsAuthorized_usuariosId = StringUtil.StrToBool( GetPar( "IsAuthorized_usuariosId"));
         AV8IsAuthorized_SecUserName = StringUtil.StrToBool( GetPar( "IsAuthorized_SecUserName"));
         AV28SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
         AV23usuariosId = GetPar( "usuariosId");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridusuarios_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV15IsAuthorized_usuariosId, AV8IsAuthorized_SecUserName, AV28SecUserId, AV23usuariosId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridusuarios_refresh_invoke */
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
         PACW2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTCW2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("admnuevoregistros.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USUARIOSID", AV15IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV15IsAuthorized_usuariosId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SECUSERNAME", AV8IsAuthorized_SecUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SECUSERNAME", GetSecureSignedToken( "", AV8IsAuthorized_SecUserName, context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.RTrim( AV23usuariosId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23usuariosId, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSECUSERPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12GridSecUserPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSECUSERAPPLIEDFILTERS", AV13GridSecUserAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vGRIDUSUARIOSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridUsuariosPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDUSUARIOSAPPLIEDFILTERS", AV19GridUsuariosAppliedFilters);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USUARIOSID", AV15IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV15IsAuthorized_usuariosId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SECUSERNAME", AV8IsAuthorized_SecUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SECUSERNAME", GetSecureSignedToken( "", AV8IsAuthorized_SecUserName, context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.RTrim( AV23usuariosId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23usuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Class", StringUtil.RTrim( Gridsecuserpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridsecuserpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridsecuserpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridsecuserpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridsecuserpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsecuserpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridsecuserpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridsecuserpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridsecuserpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridsecuserpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsecuserpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridsecuserpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Previous", StringUtil.RTrim( Gridsecuserpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Next", StringUtil.RTrim( Gridsecuserpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Caption", StringUtil.RTrim( Gridsecuserpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridsecuserpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridsecuserpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Width", StringUtil.RTrim( Dvpanel_tablecontent1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecontent1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecontent1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Cls", StringUtil.RTrim( Dvpanel_tablecontent1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Title", StringUtil.RTrim( Dvpanel_tablecontent1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecontent1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecontent1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecontent1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Iconposition", StringUtil.RTrim( Dvpanel_tablecontent1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecontent1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Class", StringUtil.RTrim( Gridusuariospaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridusuariospaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridusuariospaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridusuariospaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridusuariospaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridusuariospaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridusuariospaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridusuariospaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridusuariospaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridusuariospaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridusuariospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridusuariospaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridusuariospaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Next", StringUtil.RTrim( Gridusuariospaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridusuariospaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridusuariospaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridusuariospaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Width", StringUtil.RTrim( Dvpanel_tablecontent2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecontent2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecontent2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Cls", StringUtil.RTrim( Dvpanel_tablecontent2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Title", StringUtil.RTrim( Dvpanel_tablecontent2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecontent2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecontent2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecontent2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Iconposition", StringUtil.RTrim( Dvpanel_tablecontent2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT2_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecontent2_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Title", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Title", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridusuarios_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsecuser_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridusuariospaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridusuariospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsecuserpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsecuserpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Result", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Result", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Result));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridusuariospaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridusuariospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsecuserpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSECUSERPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsecuserpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Result", StringUtil.RTrim( Dvelop_confirmpanel_activarprofesional_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Result", StringUtil.RTrim( Dvelop_confirmpanel_activarempresa_Result));
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
            WECW2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTCW2( ) ;
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
         return formatLink("admnuevoregistros.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ADMNuevoRegistros" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Administrar Nuevos Registros", "") ;
      }

      protected void WBCW0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecontent1.SetProperty("Width", Dvpanel_tablecontent1_Width);
            ucDvpanel_tablecontent1.SetProperty("AutoWidth", Dvpanel_tablecontent1_Autowidth);
            ucDvpanel_tablecontent1.SetProperty("AutoHeight", Dvpanel_tablecontent1_Autoheight);
            ucDvpanel_tablecontent1.SetProperty("Cls", Dvpanel_tablecontent1_Cls);
            ucDvpanel_tablecontent1.SetProperty("Title", Dvpanel_tablecontent1_Title);
            ucDvpanel_tablecontent1.SetProperty("Collapsible", Dvpanel_tablecontent1_Collapsible);
            ucDvpanel_tablecontent1.SetProperty("Collapsed", Dvpanel_tablecontent1_Collapsed);
            ucDvpanel_tablecontent1.SetProperty("ShowCollapseIcon", Dvpanel_tablecontent1_Showcollapseicon);
            ucDvpanel_tablecontent1.SetProperty("IconPosition", Dvpanel_tablecontent1_Iconposition);
            ucDvpanel_tablecontent1.SetProperty("AutoScroll", Dvpanel_tablecontent1_Autoscroll);
            ucDvpanel_tablecontent1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecontent1_Internalname, "DVPANEL_TABLECONTENT1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECONTENT1Container"+"TableContent1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsecusertablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsecuserContainer.SetWrapped(nGXWrapped);
            StartGridControl20( ) ;
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsecuserContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsecuser", GridsecuserContainer, subGridsecuser_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsecuserContainerData", GridsecuserContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsecuserContainerData"+"V", GridsecuserContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsecuserContainerData"+"V"+"\" value='"+GridsecuserContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridsecuserpaginationbar.SetProperty("Class", Gridsecuserpaginationbar_Class);
            ucGridsecuserpaginationbar.SetProperty("ShowFirst", Gridsecuserpaginationbar_Showfirst);
            ucGridsecuserpaginationbar.SetProperty("ShowPrevious", Gridsecuserpaginationbar_Showprevious);
            ucGridsecuserpaginationbar.SetProperty("ShowNext", Gridsecuserpaginationbar_Shownext);
            ucGridsecuserpaginationbar.SetProperty("ShowLast", Gridsecuserpaginationbar_Showlast);
            ucGridsecuserpaginationbar.SetProperty("PagesToShow", Gridsecuserpaginationbar_Pagestoshow);
            ucGridsecuserpaginationbar.SetProperty("PagingButtonsPosition", Gridsecuserpaginationbar_Pagingbuttonsposition);
            ucGridsecuserpaginationbar.SetProperty("PagingCaptionPosition", Gridsecuserpaginationbar_Pagingcaptionposition);
            ucGridsecuserpaginationbar.SetProperty("EmptyGridClass", Gridsecuserpaginationbar_Emptygridclass);
            ucGridsecuserpaginationbar.SetProperty("RowsPerPageSelector", Gridsecuserpaginationbar_Rowsperpageselector);
            ucGridsecuserpaginationbar.SetProperty("RowsPerPageOptions", Gridsecuserpaginationbar_Rowsperpageoptions);
            ucGridsecuserpaginationbar.SetProperty("Previous", Gridsecuserpaginationbar_Previous);
            ucGridsecuserpaginationbar.SetProperty("Next", Gridsecuserpaginationbar_Next);
            ucGridsecuserpaginationbar.SetProperty("Caption", Gridsecuserpaginationbar_Caption);
            ucGridsecuserpaginationbar.SetProperty("EmptyGridCaption", Gridsecuserpaginationbar_Emptygridcaption);
            ucGridsecuserpaginationbar.SetProperty("RowsPerPageCaption", Gridsecuserpaginationbar_Rowsperpagecaption);
            ucGridsecuserpaginationbar.SetProperty("CurrentPage", AV11GridSecUserCurrentPage);
            ucGridsecuserpaginationbar.SetProperty("PageCount", AV12GridSecUserPageCount);
            ucGridsecuserpaginationbar.SetProperty("AppliedFilters", AV13GridSecUserAppliedFilters);
            ucGridsecuserpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridsecuserpaginationbar_Internalname, "GRIDSECUSERPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-1", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADMNuevoRegistros.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecontent2.SetProperty("Width", Dvpanel_tablecontent2_Width);
            ucDvpanel_tablecontent2.SetProperty("AutoWidth", Dvpanel_tablecontent2_Autowidth);
            ucDvpanel_tablecontent2.SetProperty("AutoHeight", Dvpanel_tablecontent2_Autoheight);
            ucDvpanel_tablecontent2.SetProperty("Cls", Dvpanel_tablecontent2_Cls);
            ucDvpanel_tablecontent2.SetProperty("Title", Dvpanel_tablecontent2_Title);
            ucDvpanel_tablecontent2.SetProperty("Collapsible", Dvpanel_tablecontent2_Collapsible);
            ucDvpanel_tablecontent2.SetProperty("Collapsed", Dvpanel_tablecontent2_Collapsed);
            ucDvpanel_tablecontent2.SetProperty("ShowCollapseIcon", Dvpanel_tablecontent2_Showcollapseicon);
            ucDvpanel_tablecontent2.SetProperty("IconPosition", Dvpanel_tablecontent2_Iconposition);
            ucDvpanel_tablecontent2.SetProperty("AutoScroll", Dvpanel_tablecontent2_Autoscroll);
            ucDvpanel_tablecontent2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecontent2_Internalname, "DVPANEL_TABLECONTENT2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECONTENT2Container"+"TableContent2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridusuariostablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridusuariosContainer.SetWrapped(nGXWrapped);
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridusuariosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridusuarios", GridusuariosContainer, subGridusuarios_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridusuariosContainerData", GridusuariosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridusuariosContainerData"+"V", GridusuariosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridusuariosContainerData"+"V"+"\" value='"+GridusuariosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridusuariospaginationbar.SetProperty("Class", Gridusuariospaginationbar_Class);
            ucGridusuariospaginationbar.SetProperty("ShowFirst", Gridusuariospaginationbar_Showfirst);
            ucGridusuariospaginationbar.SetProperty("ShowPrevious", Gridusuariospaginationbar_Showprevious);
            ucGridusuariospaginationbar.SetProperty("ShowNext", Gridusuariospaginationbar_Shownext);
            ucGridusuariospaginationbar.SetProperty("ShowLast", Gridusuariospaginationbar_Showlast);
            ucGridusuariospaginationbar.SetProperty("PagesToShow", Gridusuariospaginationbar_Pagestoshow);
            ucGridusuariospaginationbar.SetProperty("PagingButtonsPosition", Gridusuariospaginationbar_Pagingbuttonsposition);
            ucGridusuariospaginationbar.SetProperty("PagingCaptionPosition", Gridusuariospaginationbar_Pagingcaptionposition);
            ucGridusuariospaginationbar.SetProperty("EmptyGridClass", Gridusuariospaginationbar_Emptygridclass);
            ucGridusuariospaginationbar.SetProperty("RowsPerPageSelector", Gridusuariospaginationbar_Rowsperpageselector);
            ucGridusuariospaginationbar.SetProperty("RowsPerPageOptions", Gridusuariospaginationbar_Rowsperpageoptions);
            ucGridusuariospaginationbar.SetProperty("Previous", Gridusuariospaginationbar_Previous);
            ucGridusuariospaginationbar.SetProperty("Next", Gridusuariospaginationbar_Next);
            ucGridusuariospaginationbar.SetProperty("Caption", Gridusuariospaginationbar_Caption);
            ucGridusuariospaginationbar.SetProperty("EmptyGridCaption", Gridusuariospaginationbar_Emptygridcaption);
            ucGridusuariospaginationbar.SetProperty("RowsPerPageCaption", Gridusuariospaginationbar_Rowsperpagecaption);
            ucGridusuariospaginationbar.SetProperty("CurrentPage", AV17GridUsuariosCurrentPage);
            ucGridusuariospaginationbar.SetProperty("PageCount", AV18GridUsuariosPageCount);
            ucGridusuariospaginationbar.SetProperty("AppliedFilters", AV19GridUsuariosAppliedFilters);
            ucGridusuariospaginationbar.Render(context, "dvelop.dvpaginationbar", Gridusuariospaginationbar_Internalname, "GRIDUSUARIOSPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridsecusercurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11GridSecUserCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11GridSecUserCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridsecusercurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridsecusercurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ADMNuevoRegistros.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridusuarioscurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridUsuariosCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17GridUsuariosCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridusuarioscurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridusuarioscurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ADMNuevoRegistros.htm");
            wb_table1_56_CW2( true) ;
         }
         else
         {
            wb_table1_56_CW2( false) ;
         }
         return  ;
      }

      protected void wb_table1_56_CW2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_61_CW2( true) ;
         }
         else
         {
            wb_table2_61_CW2( false) ;
         }
         return  ;
      }

      protected void wb_table2_61_CW2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridusuarios_empowerer.Render(context, "wwp.gridempowerer", Gridusuarios_empowerer_Internalname, "GRIDUSUARIOS_EMPOWERERContainer");
            /* User Defined Control */
            ucGridsecuser_empowerer.Render(context, "wwp.gridempowerer", Gridsecuser_empowerer_Internalname, "GRIDSECUSER_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsecuserContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsecuserContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsecuser", GridsecuserContainer, subGridsecuser_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsecuserContainerData", GridsecuserContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsecuserContainerData"+"V", GridsecuserContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsecuserContainerData"+"V"+"\" value='"+GridsecuserContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridusuariosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridusuariosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridusuarios", GridusuariosContainer, subGridusuarios_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridusuariosContainerData", GridusuariosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridusuariosContainerData"+"V", GridusuariosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridusuariosContainerData"+"V"+"\" value='"+GridusuariosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTCW2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Administrar Nuevos Registros", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPCW0( ) ;
      }

      protected void WSCW2( )
      {
         STARTCW2( ) ;
         EVTCW2( ) ;
      }

      protected void EVTCW2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSECUSERPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridsecuserpaginationbar.Changepage */
                              E11CW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSECUSERPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridsecuserpaginationbar.Changerowsperpage */
                              E12CW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDUSUARIOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridusuariospaginationbar.Changepage */
                              E13CW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDUSUARIOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridusuariospaginationbar.Changerowsperpage */
                              E14CW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_activarprofesional.Close */
                              E15CW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_activarempresa.Close */
                              E16CW2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDSECUSER.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOVER'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOVER'") == 0 ) )
                           {
                              nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              AV22Ver = cgiGet( edtavVer_Internalname);
                              AssignProp("", false, edtavVer_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV22Ver)) ? AV31Ver_GXI : context.convertURL( context.PathToRelativeUrl( AV22Ver))), !bGXsfl_20_Refreshing);
                              AssignProp("", false, edtavVer_Internalname, "SrcSet", context.GetImageSrcSet( AV22Ver), true);
                              A18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A26SecUserName = cgiGet( edtSecUserName_Internalname);
                              cmbSecUserEstado.Name = cmbSecUserEstado_Internalname;
                              cmbSecUserEstado.CurrentValue = cgiGet( cmbSecUserEstado_Internalname);
                              A550SecUserEstado = cgiGet( cmbSecUserEstado_Internalname);
                              n550SecUserEstado = false;
                              A587SecUserFullName = cgiGet( edtSecUserFullName_Internalname);
                              AV26ActivarEmpresa = cgiGet( edtavActivarempresa_Internalname);
                              AssignProp("", false, edtavActivarempresa_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV26ActivarEmpresa)) ? AV32Activarempresa_GXI : context.convertURL( context.PathToRelativeUrl( AV26ActivarEmpresa))), !bGXsfl_20_Refreshing);
                              AssignProp("", false, edtavActivarempresa_Internalname, "SrcSet", context.GetImageSrcSet( AV26ActivarEmpresa), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17CW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18CW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSECUSER.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridsecuser.Load */
                                    E19CW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOVER'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoVer' */
                                    E20CW2 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "GRIDUSUARIOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'DOVER2'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'DOVER2'") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_413( ) ;
                              AV20Ver2 = cgiGet( edtavVer2_Internalname);
                              AssignProp("", false, edtavVer2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV20Ver2)) ? AV29Ver2_GXI : context.convertURL( context.PathToRelativeUrl( AV20Ver2))), !bGXsfl_41_Refreshing);
                              AssignProp("", false, edtavVer2_Internalname, "SrcSet", context.GetImageSrcSet( AV20Ver2), true);
                              A145usuariosId = cgiGet( edtusuariosId_Internalname);
                              A240usuariosNumeroIdentidad = cgiGet( edtusuariosNumeroIdentidad_Internalname);
                              cmbusuariosTipo.Name = cmbusuariosTipo_Internalname;
                              cmbusuariosTipo.CurrentValue = cgiGet( cmbusuariosTipo_Internalname);
                              A225usuariosTipo = cgiGet( cmbusuariosTipo_Internalname);
                              cmbusuariosEstado.Name = cmbusuariosEstado_Internalname;
                              cmbusuariosEstado.CurrentValue = cgiGet( cmbusuariosEstado_Internalname);
                              A226usuariosEstado = cgiGet( cmbusuariosEstado_Internalname);
                              AV25ActivarProfesional = cgiGet( edtavActivarprofesional_Internalname);
                              AssignProp("", false, edtavActivarprofesional_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25ActivarProfesional)) ? AV30Activarprofesional_GXI : context.convertURL( context.PathToRelativeUrl( AV25ActivarProfesional))), !bGXsfl_41_Refreshing);
                              AssignProp("", false, edtavActivarprofesional_Internalname, "SrcSet", context.GetImageSrcSet( AV25ActivarProfesional), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDUSUARIOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridusuarios.Load */
                                    E21CW3 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOVER2'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoVer2' */
                                    E22CW2 ();
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

      protected void WECW2( )
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

      protected void PACW2( )
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
               GX_FocusControl = edtavGridsecusercurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsecuser_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subGridsecuser_Islastpage==1)&&(nGXsfl_20_idx+1>subGridsecuser_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsecuserContainer)) ;
         /* End function gxnrGridsecuser_newrow */
      }

      protected void gxnrGridusuarios_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_413( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_413( ) ;
            nGXsfl_41_idx = ((subGridusuarios_Islastpage==1)&&(nGXsfl_41_idx+1>subGridusuarios_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_413( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridusuariosContainer)) ;
         /* End function gxnrGridusuarios_newrow */
      }

      protected void gxgrGridsecuser_refresh( int subGridsecuser_Rows ,
                                              int subGridusuarios_Rows ,
                                              bool AV8IsAuthorized_SecUserName ,
                                              bool AV15IsAuthorized_usuariosId ,
                                              long AV28SecUserId ,
                                              string AV23usuariosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSECUSER_nCurrentRecord = 0;
         RFCW2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsecuser_refresh */
      }

      protected void gxgrGridusuarios_refresh( int subGridsecuser_Rows ,
                                               int subGridusuarios_Rows ,
                                               bool AV15IsAuthorized_usuariosId ,
                                               bool AV8IsAuthorized_SecUserName ,
                                               long AV28SecUserId ,
                                               string AV23usuariosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDUSUARIOS_nCurrentRecord = 0;
         RFCW3( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridusuarios_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSNUMEROIDENTIDAD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A240usuariosNumeroIdentidad, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSNUMEROIDENTIDAD", StringUtil.RTrim( A240usuariosNumeroIdentidad));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.RTrim( A145usuariosId));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFCW2( ) ;
         RFCW3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFCW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsecuserContainer.ClearRows();
         }
         wbStart = 20;
         /* Execute user event: Refresh */
         E18CW2 ();
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         GridsecuserContainer.AddObjectProperty("GridName", "Gridsecuser");
         GridsecuserContainer.AddObjectProperty("CmpContext", "");
         GridsecuserContainer.AddObjectProperty("InMasterPage", "false");
         GridsecuserContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridsecuserContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsecuserContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsecuserContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Backcolorstyle), 1, 0, ".", "")));
         GridsecuserContainer.PageSize = subGridsecuser_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            GXPagingFrom2 = (int)(((subGridsecuser_Rows==0) ? 0 : GRIDSECUSER_nFirstRecordOnPage));
            GXPagingTo2 = ((subGridsecuser_Rows==0) ? 10000 : subGridsecuser_fnc_Recordsperpage( )+1);
            /* Using cursor H00CW2 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2});
            nGXsfl_20_idx = 1;
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGridsecuser_Rows == 0 ) || ( GRIDSECUSER_nCurrentRecord < subGridsecuser_fnc_Recordsperpage( ) ) ) ) )
            {
               A587SecUserFullName = H00CW2_A587SecUserFullName[0];
               A550SecUserEstado = H00CW2_A550SecUserEstado[0];
               n550SecUserEstado = H00CW2_n550SecUserEstado[0];
               A26SecUserName = H00CW2_A26SecUserName[0];
               A18SecUserId = H00CW2_A18SecUserId[0];
               /* Execute user event: Gridsecuser.Load */
               E19CW2 ();
               pr_default.readNext(0);
            }
            GRIDSECUSER_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 20;
            WBCW0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesCW2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USUARIOSID", AV15IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV15IsAuthorized_usuariosId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SECUSERNAME", AV8IsAuthorized_SecUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SECUSERNAME", GetSecureSignedToken( "", AV8IsAuthorized_SecUserName, context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.RTrim( AV23usuariosId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23usuariosId, "")), context));
      }

      protected int subGridusuariosclient_rec_count_fnc( )
      {
         GRIDUSUARIOS_nRecordCount = 0;
         /* Using cursor H00CW3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A226usuariosEstado = H00CW3_A226usuariosEstado[0];
            A225usuariosTipo = H00CW3_A225usuariosTipo[0];
            A240usuariosNumeroIdentidad = H00CW3_A240usuariosNumeroIdentidad[0];
            A145usuariosId = H00CW3_A145usuariosId[0];
            if ( ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "P", "")) == 0 ) || ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "R", "")) == 0 ) )
            {
               GRIDUSUARIOS_nRecordCount = (long)(GRIDUSUARIOS_nRecordCount+1);
            }
            pr_default.readNext(1);
         }
         GRIDUSUARIOS_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nEOF), 1, 0, ".", "")));
         pr_default.close(1);
         return (int)(GRIDUSUARIOS_nRecordCount) ;
      }

      protected void RFCW3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridusuariosContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E18CW2 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_413( ) ;
         bGXsfl_41_Refreshing = true;
         GridusuariosContainer.AddObjectProperty("GridName", "Gridusuarios");
         GridusuariosContainer.AddObjectProperty("CmpContext", "");
         GridusuariosContainer.AddObjectProperty("InMasterPage", "false");
         GridusuariosContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridusuariosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridusuariosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridusuariosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Backcolorstyle), 1, 0, ".", "")));
         GridusuariosContainer.PageSize = subGridusuarios_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_413( ) ;
            /* Using cursor H00CW4 */
            pr_default.execute(2);
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_413( ) ;
            GRIDUSUARIOS_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGridusuarios_Rows == 0 ) || ( GRIDUSUARIOS_nCurrentRecord < GRIDUSUARIOS_nFirstRecordOnPage + subGridusuarios_fnc_Recordsperpage( ) ) ) ) )
            {
               A226usuariosEstado = H00CW4_A226usuariosEstado[0];
               A225usuariosTipo = H00CW4_A225usuariosTipo[0];
               A240usuariosNumeroIdentidad = H00CW4_A240usuariosNumeroIdentidad[0];
               A145usuariosId = H00CW4_A145usuariosId[0];
               if ( ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "P", "")) == 0 ) || ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "R", "")) == 0 ) )
               {
                  /* Execute user event: Gridusuarios.Load */
                  E21CW3 ();
               }
               pr_default.readNext(2);
            }
            GRIDUSUARIOS_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 41;
            WBCW0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesCW3( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSNUMEROIDENTIDAD"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, StringUtil.RTrim( context.localUtil.Format( A240usuariosNumeroIdentidad, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), context));
      }

      protected int subGridsecuser_fnc_Pagecount( )
      {
         GRIDSECUSER_nRecordCount = subGridsecuser_fnc_Recordcount( );
         if ( ((long)((GRIDSECUSER_nRecordCount) % (subGridsecuser_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSECUSER_nRecordCount/ (decimal)(subGridsecuser_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSECUSER_nRecordCount/ (decimal)(subGridsecuser_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsecuser_fnc_Recordcount( )
      {
         /* Using cursor H00CW5 */
         pr_default.execute(3);
         GRIDSECUSER_nRecordCount = H00CW5_AGRIDSECUSER_nRecordCount[0];
         pr_default.close(3);
         return (int)(GRIDSECUSER_nRecordCount) ;
      }

      protected int subGridsecuser_fnc_Recordsperpage( )
      {
         if ( subGridsecuser_Rows > 0 )
         {
            return subGridsecuser_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsecuser_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSECUSER_nFirstRecordOnPage/ (decimal)(subGridsecuser_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsecuser_firstpage( )
      {
         GRIDSECUSER_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsecuser_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV8IsAuthorized_SecUserName, AV15IsAuthorized_usuariosId, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsecuser_nextpage( )
      {
         GRIDSECUSER_nRecordCount = subGridsecuser_fnc_Recordcount( );
         if ( ( GRIDSECUSER_nRecordCount >= subGridsecuser_fnc_Recordsperpage( ) ) && ( GRIDSECUSER_nEOF == 0 ) )
         {
            GRIDSECUSER_nFirstRecordOnPage = (long)(GRIDSECUSER_nFirstRecordOnPage+subGridsecuser_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsecuserContainer.AddObjectProperty("GRIDSECUSER_nFirstRecordOnPage", GRIDSECUSER_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsecuser_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV8IsAuthorized_SecUserName, AV15IsAuthorized_usuariosId, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSECUSER_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsecuser_previouspage( )
      {
         if ( GRIDSECUSER_nFirstRecordOnPage >= subGridsecuser_fnc_Recordsperpage( ) )
         {
            GRIDSECUSER_nFirstRecordOnPage = (long)(GRIDSECUSER_nFirstRecordOnPage-subGridsecuser_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsecuser_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV8IsAuthorized_SecUserName, AV15IsAuthorized_usuariosId, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsecuser_lastpage( )
      {
         GRIDSECUSER_nRecordCount = subGridsecuser_fnc_Recordcount( );
         if ( GRIDSECUSER_nRecordCount > subGridsecuser_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDSECUSER_nRecordCount) % (subGridsecuser_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSECUSER_nFirstRecordOnPage = (long)(GRIDSECUSER_nRecordCount-subGridsecuser_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSECUSER_nFirstRecordOnPage = (long)(GRIDSECUSER_nRecordCount-((long)((GRIDSECUSER_nRecordCount) % (subGridsecuser_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSECUSER_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsecuser_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV8IsAuthorized_SecUserName, AV15IsAuthorized_usuariosId, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsecuser_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSECUSER_nFirstRecordOnPage = (long)(subGridsecuser_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSECUSER_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSECUSER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsecuser_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV8IsAuthorized_SecUserName, AV15IsAuthorized_usuariosId, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridusuarios_fnc_Pagecount( )
      {
         GRIDUSUARIOS_nRecordCount = subGridusuarios_fnc_Recordcount( );
         if ( ((long)((GRIDUSUARIOS_nRecordCount) % (subGridusuarios_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDUSUARIOS_nRecordCount/ (decimal)(subGridusuarios_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDUSUARIOS_nRecordCount/ (decimal)(subGridusuarios_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridusuarios_fnc_Recordcount( )
      {
         return (int)(subGridusuariosclient_rec_count_fnc()) ;
      }

      protected int subGridusuarios_fnc_Recordsperpage( )
      {
         if ( subGridusuarios_Rows > 0 )
         {
            return subGridusuarios_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridusuarios_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDUSUARIOS_nFirstRecordOnPage/ (decimal)(subGridusuarios_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridusuarios_firstpage( )
      {
         GRIDUSUARIOS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuarios_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV15IsAuthorized_usuariosId, AV8IsAuthorized_SecUserName, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridusuarios_nextpage( )
      {
         if ( GRIDUSUARIOS_nEOF == 0 )
         {
            GRIDUSUARIOS_nFirstRecordOnPage = (long)(GRIDUSUARIOS_nFirstRecordOnPage+subGridusuarios_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridusuariosContainer.AddObjectProperty("GRIDUSUARIOS_nFirstRecordOnPage", GRIDUSUARIOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuarios_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV15IsAuthorized_usuariosId, AV8IsAuthorized_SecUserName, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDUSUARIOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridusuarios_previouspage( )
      {
         if ( GRIDUSUARIOS_nFirstRecordOnPage >= subGridusuarios_fnc_Recordsperpage( ) )
         {
            GRIDUSUARIOS_nFirstRecordOnPage = (long)(GRIDUSUARIOS_nFirstRecordOnPage-subGridusuarios_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuarios_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV15IsAuthorized_usuariosId, AV8IsAuthorized_SecUserName, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridusuarios_lastpage( )
      {
         GRIDUSUARIOS_nRecordCount = subGridusuarios_fnc_Recordcount( );
         if ( GRIDUSUARIOS_nRecordCount > subGridusuarios_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDUSUARIOS_nRecordCount) % (subGridusuarios_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDUSUARIOS_nFirstRecordOnPage = (long)(GRIDUSUARIOS_nRecordCount-subGridusuarios_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDUSUARIOS_nFirstRecordOnPage = (long)(GRIDUSUARIOS_nRecordCount-((long)((GRIDUSUARIOS_nRecordCount) % (subGridusuarios_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDUSUARIOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuarios_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV15IsAuthorized_usuariosId, AV8IsAuthorized_SecUserName, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridusuarios_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDUSUARIOS_nFirstRecordOnPage = (long)(subGridusuarios_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDUSUARIOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusuarios_refresh( subGridsecuser_Rows, subGridusuarios_Rows, AV15IsAuthorized_usuariosId, AV8IsAuthorized_SecUserName, AV28SecUserId, AV23usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSecUserId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         cmbSecUserEstado.Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtusuariosId_Enabled = 0;
         edtusuariosNumeroIdentidad_Enabled = 0;
         cmbusuariosTipo.Enabled = 0;
         cmbusuariosEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPCW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17CW2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV12GridSecUserPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDSECUSERPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12GridSecUserPageCount", StringUtil.LTrimStr( (decimal)(AV12GridSecUserPageCount), 10, 0));
            AV13GridSecUserAppliedFilters = cgiGet( "vGRIDSECUSERAPPLIEDFILTERS");
            AV18GridUsuariosPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDUSUARIOSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18GridUsuariosPageCount", StringUtil.LTrimStr( (decimal)(AV18GridUsuariosPageCount), 10, 0));
            AV19GridUsuariosAppliedFilters = cgiGet( "vGRIDUSUARIOSAPPLIEDFILTERS");
            GRIDSECUSER_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSECUSER_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDUSUARIOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSUARIOS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSECUSER_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSECUSER_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDUSUARIOS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSUARIOS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsecuser_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSECUSER_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDSECUSER_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Rows), 6, 0, ".", "")));
            subGridusuarios_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSUARIOS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Rows), 6, 0, ".", "")));
            Gridsecuserpaginationbar_Class = cgiGet( "GRIDSECUSERPAGINATIONBAR_Class");
            Gridsecuserpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDSECUSERPAGINATIONBAR_Showfirst"));
            Gridsecuserpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDSECUSERPAGINATIONBAR_Showprevious"));
            Gridsecuserpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDSECUSERPAGINATIONBAR_Shownext"));
            Gridsecuserpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDSECUSERPAGINATIONBAR_Showlast"));
            Gridsecuserpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSECUSERPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsecuserpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDSECUSERPAGINATIONBAR_Pagingbuttonsposition");
            Gridsecuserpaginationbar_Pagingcaptionposition = cgiGet( "GRIDSECUSERPAGINATIONBAR_Pagingcaptionposition");
            Gridsecuserpaginationbar_Emptygridclass = cgiGet( "GRIDSECUSERPAGINATIONBAR_Emptygridclass");
            Gridsecuserpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDSECUSERPAGINATIONBAR_Rowsperpageselector"));
            Gridsecuserpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSECUSERPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsecuserpaginationbar_Rowsperpageoptions = cgiGet( "GRIDSECUSERPAGINATIONBAR_Rowsperpageoptions");
            Gridsecuserpaginationbar_Previous = cgiGet( "GRIDSECUSERPAGINATIONBAR_Previous");
            Gridsecuserpaginationbar_Next = cgiGet( "GRIDSECUSERPAGINATIONBAR_Next");
            Gridsecuserpaginationbar_Caption = cgiGet( "GRIDSECUSERPAGINATIONBAR_Caption");
            Gridsecuserpaginationbar_Emptygridcaption = cgiGet( "GRIDSECUSERPAGINATIONBAR_Emptygridcaption");
            Gridsecuserpaginationbar_Rowsperpagecaption = cgiGet( "GRIDSECUSERPAGINATIONBAR_Rowsperpagecaption");
            Dvpanel_tablecontent1_Width = cgiGet( "DVPANEL_TABLECONTENT1_Width");
            Dvpanel_tablecontent1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT1_Autowidth"));
            Dvpanel_tablecontent1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT1_Autoheight"));
            Dvpanel_tablecontent1_Cls = cgiGet( "DVPANEL_TABLECONTENT1_Cls");
            Dvpanel_tablecontent1_Title = cgiGet( "DVPANEL_TABLECONTENT1_Title");
            Dvpanel_tablecontent1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT1_Collapsible"));
            Dvpanel_tablecontent1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT1_Collapsed"));
            Dvpanel_tablecontent1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT1_Showcollapseicon"));
            Dvpanel_tablecontent1_Iconposition = cgiGet( "DVPANEL_TABLECONTENT1_Iconposition");
            Dvpanel_tablecontent1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT1_Autoscroll"));
            Gridusuariospaginationbar_Class = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Class");
            Gridusuariospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Showfirst"));
            Gridusuariospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Showprevious"));
            Gridusuariospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Shownext"));
            Gridusuariospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Showlast"));
            Gridusuariospaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridusuariospaginationbar_Pagingbuttonsposition = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Pagingbuttonsposition");
            Gridusuariospaginationbar_Pagingcaptionposition = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Pagingcaptionposition");
            Gridusuariospaginationbar_Emptygridclass = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Emptygridclass");
            Gridusuariospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselector"));
            Gridusuariospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridusuariospaginationbar_Rowsperpageoptions = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageoptions");
            Gridusuariospaginationbar_Previous = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Previous");
            Gridusuariospaginationbar_Next = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Next");
            Gridusuariospaginationbar_Caption = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Caption");
            Gridusuariospaginationbar_Emptygridcaption = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Emptygridcaption");
            Gridusuariospaginationbar_Rowsperpagecaption = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Rowsperpagecaption");
            Dvpanel_tablecontent2_Width = cgiGet( "DVPANEL_TABLECONTENT2_Width");
            Dvpanel_tablecontent2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT2_Autowidth"));
            Dvpanel_tablecontent2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT2_Autoheight"));
            Dvpanel_tablecontent2_Cls = cgiGet( "DVPANEL_TABLECONTENT2_Cls");
            Dvpanel_tablecontent2_Title = cgiGet( "DVPANEL_TABLECONTENT2_Title");
            Dvpanel_tablecontent2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT2_Collapsible"));
            Dvpanel_tablecontent2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT2_Collapsed"));
            Dvpanel_tablecontent2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT2_Showcollapseicon"));
            Dvpanel_tablecontent2_Iconposition = cgiGet( "DVPANEL_TABLECONTENT2_Iconposition");
            Dvpanel_tablecontent2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT2_Autoscroll"));
            Dvelop_confirmpanel_activarprofesional_Title = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Title");
            Dvelop_confirmpanel_activarprofesional_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Confirmationtext");
            Dvelop_confirmpanel_activarprofesional_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Yesbuttoncaption");
            Dvelop_confirmpanel_activarprofesional_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Nobuttoncaption");
            Dvelop_confirmpanel_activarprofesional_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Cancelbuttoncaption");
            Dvelop_confirmpanel_activarprofesional_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Yesbuttonposition");
            Dvelop_confirmpanel_activarprofesional_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Confirmtype");
            Dvelop_confirmpanel_activarempresa_Title = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Title");
            Dvelop_confirmpanel_activarempresa_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Confirmationtext");
            Dvelop_confirmpanel_activarempresa_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Yesbuttoncaption");
            Dvelop_confirmpanel_activarempresa_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Nobuttoncaption");
            Dvelop_confirmpanel_activarempresa_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Cancelbuttoncaption");
            Dvelop_confirmpanel_activarempresa_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Yesbuttonposition");
            Dvelop_confirmpanel_activarempresa_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Confirmtype");
            Gridusuarios_empowerer_Gridinternalname = cgiGet( "GRIDUSUARIOS_EMPOWERER_Gridinternalname");
            Gridsecuser_empowerer_Gridinternalname = cgiGet( "GRIDSECUSER_EMPOWERER_Gridinternalname");
            Gridusuariospaginationbar_Selectedpage = cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Selectedpage");
            Gridusuariospaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSUARIOSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridsecuserpaginationbar_Selectedpage = cgiGet( "GRIDSECUSERPAGINATIONBAR_Selectedpage");
            Gridsecuserpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDSECUSERPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_activarprofesional_Result = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL_Result");
            Dvelop_confirmpanel_activarempresa_Result = cgiGet( "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA_Result");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridsecusercurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridsecusercurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDSECUSERCURRENTPAGE");
               GX_FocusControl = edtavGridsecusercurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11GridSecUserCurrentPage = 0;
               AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
            }
            else
            {
               AV11GridSecUserCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridsecusercurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridusuarioscurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridusuarioscurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDUSUARIOSCURRENTPAGE");
               GX_FocusControl = edtavGridusuarioscurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17GridUsuariosCurrentPage = 0;
               AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
            }
            else
            {
               AV17GridUsuariosCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridusuarioscurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
            }
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
         E17CW2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17CW2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gridusuarios_empowerer_Gridinternalname = subGridusuarios_Internalname;
         ucGridusuarios_empowerer.SendProperty(context, "", false, Gridusuarios_empowerer_Internalname, "GridInternalName", Gridusuarios_empowerer_Gridinternalname);
         subGridusuarios_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Rows), 6, 0, ".", "")));
         AV17GridUsuariosCurrentPage = 1;
         AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
         edtavGridusuarioscurrentpage_Visible = 0;
         AssignProp("", false, edtavGridusuarioscurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridusuarioscurrentpage_Visible), 5, 0), true);
         AV18GridUsuariosPageCount = -1;
         AssignAttri("", false, "AV18GridUsuariosPageCount", StringUtil.LTrimStr( (decimal)(AV18GridUsuariosPageCount), 10, 0));
         GXt_boolean1 = AV15IsAuthorized_usuariosId;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios", out  GXt_boolean1) ;
         AV15IsAuthorized_usuariosId = GXt_boolean1;
         AssignAttri("", false, "AV15IsAuthorized_usuariosId", AV15IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV15IsAuthorized_usuariosId, context));
         Gridsecuser_empowerer_Gridinternalname = subGridsecuser_Internalname;
         ucGridsecuser_empowerer.SendProperty(context, "", false, Gridsecuser_empowerer_Internalname, "GridInternalName", Gridsecuser_empowerer_Gridinternalname);
         subGridsecuser_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Rows), 6, 0, ".", "")));
         AV11GridSecUserCurrentPage = 1;
         AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
         edtavGridsecusercurrentpage_Visible = 0;
         AssignProp("", false, edtavGridsecusercurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridsecusercurrentpage_Visible), 5, 0), true);
         AV12GridSecUserPageCount = -1;
         AssignAttri("", false, "AV12GridSecUserPageCount", StringUtil.LTrimStr( (decimal)(AV12GridSecUserPageCount), 10, 0));
         GXt_boolean1 = AV8IsAuthorized_SecUserName;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser", out  GXt_boolean1) ;
         AV8IsAuthorized_SecUserName = GXt_boolean1;
         AssignAttri("", false, "AV8IsAuthorized_SecUserName", AV8IsAuthorized_SecUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SECUSERNAME", GetSecureSignedToken( "", AV8IsAuthorized_SecUserName, context));
         Gridusuariospaginationbar_Rowsperpageselectedvalue = subGridusuarios_Rows;
         ucGridusuariospaginationbar.SendProperty(context, "", false, Gridusuariospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridusuariospaginationbar_Rowsperpageselectedvalue), 9, 0));
         Gridsecuserpaginationbar_Rowsperpageselectedvalue = subGridsecuser_Rows;
         ucGridsecuserpaginationbar.SendProperty(context, "", false, Gridsecuserpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsecuserpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18CW2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E19CW2( )
      {
         /* Gridsecuser_Load Routine */
         returnInSub = false;
         edtavVer_gximage = "searchPrompt";
         AV22Ver = context.GetImagePath( "cb6d7d5d-679d-409a-a895-2ff22f253a5e", "", context.GetTheme( ));
         AssignAttri("", false, edtavVer_Internalname, AV22Ver);
         AV31Ver_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cb6d7d5d-679d-409a-a895-2ff22f253a5e", "", context.GetTheme( )), context);
         edtavVer_Tooltiptext = "";
         edtavActivarempresa_gximage = "icon_key";
         AV26ActivarEmpresa = context.GetImagePath( "7ca49d59-ac16-4d16-b4fe-bc93fcf1138e", "", context.GetTheme( ));
         AssignAttri("", false, edtavActivarempresa_Internalname, AV26ActivarEmpresa);
         AV32Activarempresa_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7ca49d59-ac16-4d16-b4fe-bc93fcf1138e", "", context.GetTheme( )), context);
         edtavActivarempresa_Tooltiptext = "";
         if ( AV8IsAuthorized_SecUserName )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.secuserview.aspx"+UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSecUserName_Link = formatLink("wwpbaseobjects.secuserview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 20;
         }
         sendrow_202( ) ;
         GRIDSECUSER_nCurrentRecord = (long)(GRIDSECUSER_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
         {
            context.DoAjaxLoad(20, GridsecuserRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E13CW2( )
      {
         /* Gridusuariospaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridusuariospaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV17GridUsuariosCurrentPage = (long)(AV17GridUsuariosCurrentPage-1);
            AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
            subgridusuarios_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridusuariospaginationbar_Selectedpage, "Next") == 0 )
         {
            AV17GridUsuariosCurrentPage = (long)(AV17GridUsuariosCurrentPage+1);
            AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
            subgridusuarios_nextpage( ) ;
         }
         else
         {
            AV10PageToGo = (int)(Math.Round(NumberUtil.Val( Gridusuariospaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV17GridUsuariosCurrentPage = AV10PageToGo;
            AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
            subgridusuarios_gotopage( AV10PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E14CW2( )
      {
         /* Gridusuariospaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridusuarios_Rows = Gridusuariospaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Rows), 6, 0, ".", "")));
         AV17GridUsuariosCurrentPage = 1;
         AssignAttri("", false, "AV17GridUsuariosCurrentPage", StringUtil.LTrimStr( (decimal)(AV17GridUsuariosCurrentPage), 10, 0));
         subgridusuarios_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E11CW2( )
      {
         /* Gridsecuserpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsecuserpaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV11GridSecUserCurrentPage = (long)(AV11GridSecUserCurrentPage-1);
            AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
            subgridsecuser_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsecuserpaginationbar_Selectedpage, "Next") == 0 )
         {
            AV11GridSecUserCurrentPage = (long)(AV11GridSecUserCurrentPage+1);
            AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
            subgridsecuser_nextpage( ) ;
         }
         else
         {
            AV10PageToGo = (int)(Math.Round(NumberUtil.Val( Gridsecuserpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV11GridSecUserCurrentPage = AV10PageToGo;
            AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
            subgridsecuser_gotopage( AV10PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E12CW2( )
      {
         /* Gridsecuserpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsecuser_Rows = Gridsecuserpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDSECUSER_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Rows), 6, 0, ".", "")));
         AV11GridSecUserCurrentPage = 1;
         AssignAttri("", false, "AV11GridSecUserCurrentPage", StringUtil.LTrimStr( (decimal)(AV11GridSecUserCurrentPage), 10, 0));
         subgridsecuser_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E22CW2( )
      {
         /* 'DoVer2' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A240usuariosNumeroIdentidad));
         context.PopUp(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E15CW2( )
      {
         /* Dvelop_confirmpanel_activarprofesional_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_activarprofesional_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTIVARPROFESIONAL' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void E20CW2( )
      {
         /* 'DoVer' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secuser.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0));
         context.PopUp(formatLink("wwpbaseobjects.secuser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E16CW2( )
      {
         /* Dvelop_confirmpanel_activarempresa_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_activarempresa_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTIVAREMPRESA' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV21IsAuthorized_Ver2;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV21IsAuthorized_Ver2 = GXt_boolean1;
         if ( ! ( AV21IsAuthorized_Ver2 ) )
         {
            edtavVer2_Visible = 0;
            AssignProp("", false, edtavVer2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVer2_Visible), 5, 0), !bGXsfl_41_Refreshing);
         }
         GXt_boolean1 = AV24IsAuthorized_Ver;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWUser", out  GXt_boolean1) ;
         AV24IsAuthorized_Ver = GXt_boolean1;
         if ( ! ( AV24IsAuthorized_Ver ) )
         {
            edtavVer_Visible = 0;
            AssignProp("", false, edtavVer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVer_Visible), 5, 0), !bGXsfl_20_Refreshing);
         }
      }

      protected void S122( )
      {
         /* 'DO ACTIVARPROFESIONAL' Routine */
         returnInSub = false;
         new activarcuenta(context ).execute(  context.GetMessage( "S", ""),  A145usuariosId,  AV28SecUserId) ;
      }

      protected void S132( )
      {
         /* 'DO ACTIVAREMPRESA' Routine */
         returnInSub = false;
         new activarcuenta(context ).execute(  context.GetMessage( "P", ""),  AV23usuariosId,  A18SecUserId) ;
      }

      private void E21CW3( )
      {
         if ( ( subGridusuarios_Islastpage == 1 ) || ( subGridusuarios_Rows == 0 ) || ( ( GRIDUSUARIOS_nCurrentRecord >= GRIDUSUARIOS_nFirstRecordOnPage ) && ( GRIDUSUARIOS_nCurrentRecord < GRIDUSUARIOS_nFirstRecordOnPage + subGridusuarios_fnc_Recordsperpage( ) ) ) )
         {
            /* Gridusuarios_Load Routine */
            returnInSub = false;
            edtavVer2_gximage = "Select";
            AV20Ver2 = context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", context.GetTheme( ));
            AssignAttri("", false, edtavVer2_Internalname, AV20Ver2);
            AV29Ver2_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1ca03f75-9947-4d2c-90a4-e8ab9c5cedea", "", context.GetTheme( )), context);
            edtavVer2_Tooltiptext = "";
            edtavActivarprofesional_gximage = "icon_key";
            AV25ActivarProfesional = context.GetImagePath( "7ca49d59-ac16-4d16-b4fe-bc93fcf1138e", "", context.GetTheme( ));
            AssignAttri("", false, edtavActivarprofesional_Internalname, AV25ActivarProfesional);
            AV30Activarprofesional_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7ca49d59-ac16-4d16-b4fe-bc93fcf1138e", "", context.GetTheme( )), context);
            edtavActivarprofesional_Tooltiptext = "";
            if ( AV15IsAuthorized_usuariosId )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "usuariosview.aspx"+UrlEncode(StringUtil.RTrim(A145usuariosId)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtusuariosId_Link = formatLink("usuariosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 41;
            }
            sendrow_413( ) ;
         }
         GRIDUSUARIOS_nEOF = (short)(((subGridusuarios_Rows==0)||(GRIDUSUARIOS_nCurrentRecord<GRIDUSUARIOS_nFirstRecordOnPage+subGridusuarios_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRIDUSUARIOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSUARIOS_nEOF), 1, 0, ".", "")));
         GRIDUSUARIOS_nCurrentRecord = (long)(GRIDUSUARIOS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
         {
            context.DoAjaxLoad(41, GridusuariosRow);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table2_61_CW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_activarempresa_Internalname, tblTabledvelop_confirmpanel_activarempresa_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_activarempresa.SetProperty("Title", Dvelop_confirmpanel_activarempresa_Title);
            ucDvelop_confirmpanel_activarempresa.SetProperty("ConfirmationText", Dvelop_confirmpanel_activarempresa_Confirmationtext);
            ucDvelop_confirmpanel_activarempresa.SetProperty("YesButtonCaption", Dvelop_confirmpanel_activarempresa_Yesbuttoncaption);
            ucDvelop_confirmpanel_activarempresa.SetProperty("NoButtonCaption", Dvelop_confirmpanel_activarempresa_Nobuttoncaption);
            ucDvelop_confirmpanel_activarempresa.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_activarempresa_Cancelbuttoncaption);
            ucDvelop_confirmpanel_activarempresa.SetProperty("YesButtonPosition", Dvelop_confirmpanel_activarempresa_Yesbuttonposition);
            ucDvelop_confirmpanel_activarempresa.SetProperty("ConfirmType", Dvelop_confirmpanel_activarempresa_Confirmtype);
            ucDvelop_confirmpanel_activarempresa.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_activarempresa_Internalname, "DVELOP_CONFIRMPANEL_ACTIVAREMPRESAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_ACTIVAREMPRESAContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_61_CW2e( true) ;
         }
         else
         {
            wb_table2_61_CW2e( false) ;
         }
      }

      protected void wb_table1_56_CW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_activarprofesional_Internalname, tblTabledvelop_confirmpanel_activarprofesional_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_activarprofesional.SetProperty("Title", Dvelop_confirmpanel_activarprofesional_Title);
            ucDvelop_confirmpanel_activarprofesional.SetProperty("ConfirmationText", Dvelop_confirmpanel_activarprofesional_Confirmationtext);
            ucDvelop_confirmpanel_activarprofesional.SetProperty("YesButtonCaption", Dvelop_confirmpanel_activarprofesional_Yesbuttoncaption);
            ucDvelop_confirmpanel_activarprofesional.SetProperty("NoButtonCaption", Dvelop_confirmpanel_activarprofesional_Nobuttoncaption);
            ucDvelop_confirmpanel_activarprofesional.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_activarprofesional_Cancelbuttoncaption);
            ucDvelop_confirmpanel_activarprofesional.SetProperty("YesButtonPosition", Dvelop_confirmpanel_activarprofesional_Yesbuttonposition);
            ucDvelop_confirmpanel_activarprofesional.SetProperty("ConfirmType", Dvelop_confirmpanel_activarprofesional_Confirmtype);
            ucDvelop_confirmpanel_activarprofesional.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_activarprofesional_Internalname, "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_ACTIVARPROFESIONALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_56_CW2e( true) ;
         }
         else
         {
            wb_table1_56_CW2e( false) ;
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
         PACW2( ) ;
         WSCW2( ) ;
         WECW2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932017148", true, true, false);
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
            context.AddJavascriptSource("admnuevoregistros.js", "?2026932017148", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtavVer_Internalname = "vVER_"+sGXsfl_20_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_20_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_20_idx;
         cmbSecUserEstado_Internalname = "SECUSERESTADO_"+sGXsfl_20_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_20_idx;
         edtavActivarempresa_Internalname = "vACTIVAREMPRESA_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtavVer_Internalname = "vVER_"+sGXsfl_20_fel_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_20_fel_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_20_fel_idx;
         cmbSecUserEstado_Internalname = "SECUSERESTADO_"+sGXsfl_20_fel_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_20_fel_idx;
         edtavActivarempresa_Internalname = "vACTIVAREMPRESA_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         WBCW0( ) ;
         if ( ( subGridsecuser_Rows * 1 == 0 ) || ( nGXsfl_20_idx <= subGridsecuser_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsecuserRow = GXWebRow.GetNew(context,GridsecuserContainer);
            if ( subGridsecuser_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsecuser_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsecuser_Class, "") != 0 )
               {
                  subGridsecuser_Linesclass = subGridsecuser_Class+"Odd";
               }
            }
            else if ( subGridsecuser_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsecuser_Backstyle = 0;
               subGridsecuser_Backcolor = subGridsecuser_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsecuser_Class, "") != 0 )
               {
                  subGridsecuser_Linesclass = subGridsecuser_Class+"Uniform";
               }
            }
            else if ( subGridsecuser_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsecuser_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsecuser_Class, "") != 0 )
               {
                  subGridsecuser_Linesclass = subGridsecuser_Class+"Odd";
               }
               subGridsecuser_Backcolor = (int)(0x0);
            }
            else if ( subGridsecuser_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsecuser_Backstyle = 1;
               if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
               {
                  subGridsecuser_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsecuser_Class, "") != 0 )
                  {
                     subGridsecuser_Linesclass = subGridsecuser_Class+"Even";
                  }
               }
               else
               {
                  subGridsecuser_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsecuser_Class, "") != 0 )
                  {
                     subGridsecuser_Linesclass = subGridsecuser_Class+"Odd";
                  }
               }
            }
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_20_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVer_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',20)\"";
            ClassString = "ActionBaseColorAttribute" + " " + ((StringUtil.StrCmp(edtavVer_gximage, "")==0) ? "" : "GX_Image_"+edtavVer_gximage+"_Class");
            StyleString = "";
            AV22Ver_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV22Ver))&&String.IsNullOrEmpty(StringUtil.RTrim( AV31Ver_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV22Ver)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV22Ver)) ? AV31Ver_GXI : context.PathToRelativeUrl( AV22Ver));
            GridsecuserRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavVer_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavVer_Visible,(short)1,(string)"",(string)edtavVer_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavVer_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOVER\\'."+sGXsfl_20_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV22Ver_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsecuserRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsecuserRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A26SecUserName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbSecUserEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECUSERESTADO_" + sGXsfl_20_idx;
               cmbSecUserEstado.Name = GXCCtl;
               cmbSecUserEstado.WebTags = "";
               cmbSecUserEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbSecUserEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbSecUserEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbSecUserEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbSecUserEstado.ItemCount > 0 )
               {
                  A550SecUserEstado = cmbSecUserEstado.getValidValue(A550SecUserEstado);
                  n550SecUserEstado = false;
               }
            }
            /* ComboBox */
            GridsecuserRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecUserEstado,(string)cmbSecUserEstado_Internalname,StringUtil.RTrim( A550SecUserEstado),(short)1,(string)cmbSecUserEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecUserEstado.CurrentValue = StringUtil.RTrim( A550SecUserEstado);
            AssignProp("", false, cmbSecUserEstado_Internalname, "Values", (string)(cmbSecUserEstado.ToJavascriptSource()), !bGXsfl_20_Refreshing);
            /* Subfile cell */
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsecuserRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserFullName_Internalname,(string)A587SecUserFullName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserFullName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsecuserContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',20)\"";
            ClassString = "ActionBaseColorAttribute" + " " + ((StringUtil.StrCmp(edtavActivarempresa_gximage, "")==0) ? "" : "GX_Image_"+edtavActivarempresa_gximage+"_Class");
            StyleString = "";
            AV26ActivarEmpresa_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV26ActivarEmpresa))&&String.IsNullOrEmpty(StringUtil.RTrim( AV32Activarempresa_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV26ActivarEmpresa)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26ActivarEmpresa)) ? AV32Activarempresa_GXI : context.PathToRelativeUrl( AV26ActivarEmpresa));
            GridsecuserRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavActivarempresa_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavActivarempresa_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavActivarempresa_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e23cw2_client"+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV26ActivarEmpresa_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashesCW2( ) ;
            GridsecuserContainer.AddRow(GridsecuserRow);
            nGXsfl_20_idx = ((subGridsecuser_Islastpage==1)&&(nGXsfl_20_idx+1>subGridsecuser_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         /* End function sendrow_202 */
      }

      protected void SubsflControlProps_413( )
      {
         edtavVer2_Internalname = "vVER2_"+sGXsfl_41_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_41_idx;
         edtusuariosNumeroIdentidad_Internalname = "USUARIOSNUMEROIDENTIDAD_"+sGXsfl_41_idx;
         cmbusuariosTipo_Internalname = "USUARIOSTIPO_"+sGXsfl_41_idx;
         cmbusuariosEstado_Internalname = "USUARIOSESTADO_"+sGXsfl_41_idx;
         edtavActivarprofesional_Internalname = "vACTIVARPROFESIONAL_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_413( )
      {
         edtavVer2_Internalname = "vVER2_"+sGXsfl_41_fel_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_41_fel_idx;
         edtusuariosNumeroIdentidad_Internalname = "USUARIOSNUMEROIDENTIDAD_"+sGXsfl_41_fel_idx;
         cmbusuariosTipo_Internalname = "USUARIOSTIPO_"+sGXsfl_41_fel_idx;
         cmbusuariosEstado_Internalname = "USUARIOSESTADO_"+sGXsfl_41_fel_idx;
         edtavActivarprofesional_Internalname = "vACTIVARPROFESIONAL_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_413( )
      {
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_413( ) ;
         WBCW0( ) ;
         if ( ( subGridusuarios_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGridusuarios_fnc_Recordsperpage( ) * 1 ) )
         {
            GridusuariosRow = GXWebRow.GetNew(context,GridusuariosContainer);
            if ( subGridusuarios_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridusuarios_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridusuarios_Class, "") != 0 )
               {
                  subGridusuarios_Linesclass = subGridusuarios_Class+"Odd";
               }
            }
            else if ( subGridusuarios_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridusuarios_Backstyle = 0;
               subGridusuarios_Backcolor = subGridusuarios_Allbackcolor;
               if ( StringUtil.StrCmp(subGridusuarios_Class, "") != 0 )
               {
                  subGridusuarios_Linesclass = subGridusuarios_Class+"Uniform";
               }
            }
            else if ( subGridusuarios_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridusuarios_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridusuarios_Class, "") != 0 )
               {
                  subGridusuarios_Linesclass = subGridusuarios_Class+"Odd";
               }
               subGridusuarios_Backcolor = (int)(0x0);
            }
            else if ( subGridusuarios_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridusuarios_Backstyle = 1;
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
               {
                  subGridusuarios_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridusuarios_Class, "") != 0 )
                  {
                     subGridusuarios_Linesclass = subGridusuarios_Class+"Even";
                  }
               }
               else
               {
                  subGridusuarios_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridusuarios_Class, "") != 0 )
                  {
                     subGridusuarios_Linesclass = subGridusuarios_Class+"Odd";
                  }
               }
            }
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavVer2_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',41)\"";
            ClassString = "ActionBaseColorAttribute" + " " + ((StringUtil.StrCmp(edtavVer2_gximage, "")==0) ? "" : "GX_Image_"+edtavVer2_gximage+"_Class");
            StyleString = "";
            AV20Ver2_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20Ver2))&&String.IsNullOrEmpty(StringUtil.RTrim( AV29Ver2_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20Ver2)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20Ver2)) ? AV29Ver2_GXI : context.PathToRelativeUrl( AV20Ver2));
            GridusuariosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavVer2_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavVer2_Visible,(short)1,(string)"",(string)edtavVer2_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavVer2_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOVER2\\'."+sGXsfl_41_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV20Ver2_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusuariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosId_Internalname,StringUtil.RTrim( A145usuariosId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtusuariosId_Link,(string)"",(string)"",(string)"",(string)edtusuariosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusuariosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNumeroIdentidad_Internalname,StringUtil.RTrim( A240usuariosNumeroIdentidad),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNumeroIdentidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbusuariosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSTIPO_" + sGXsfl_41_idx;
               cmbusuariosTipo.Name = GXCCtl;
               cmbusuariosTipo.WebTags = "";
               cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
               cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
               cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
               cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
               cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
               cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
               cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
               if ( cmbusuariosTipo.ItemCount > 0 )
               {
                  A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
               }
            }
            /* ComboBox */
            GridusuariosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosTipo,(string)cmbusuariosTipo_Internalname,StringUtil.RTrim( A225usuariosTipo),(short)1,(string)cmbusuariosTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
            AssignProp("", false, cmbusuariosTipo_Internalname, "Values", (string)(cmbusuariosTipo.ToJavascriptSource()), !bGXsfl_41_Refreshing);
            /* Subfile cell */
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbusuariosEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSESTADO_" + sGXsfl_41_idx;
               cmbusuariosEstado.Name = GXCCtl;
               cmbusuariosEstado.WebTags = "";
               cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbusuariosEstado.ItemCount > 0 )
               {
                  A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
               }
            }
            /* ComboBox */
            GridusuariosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosEstado,(string)cmbusuariosEstado_Internalname,StringUtil.RTrim( A226usuariosEstado),(short)1,(string)cmbusuariosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
            AssignProp("", false, cmbusuariosEstado_Internalname, "Values", (string)(cmbusuariosEstado.ToJavascriptSource()), !bGXsfl_41_Refreshing);
            /* Subfile cell */
            if ( GridusuariosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',41)\"";
            ClassString = "ActionBaseColorAttribute" + " " + ((StringUtil.StrCmp(edtavActivarprofesional_gximage, "")==0) ? "" : "GX_Image_"+edtavActivarprofesional_gximage+"_Class");
            StyleString = "";
            AV25ActivarProfesional_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25ActivarProfesional))&&String.IsNullOrEmpty(StringUtil.RTrim( AV30Activarprofesional_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25ActivarProfesional)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25ActivarProfesional)) ? AV30Activarprofesional_GXI : context.PathToRelativeUrl( AV25ActivarProfesional));
            GridusuariosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavActivarprofesional_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavActivarprofesional_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavActivarprofesional_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e24cw3_client"+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV25ActivarProfesional_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashesCW3( ) ;
            GridusuariosContainer.AddRow(GridusuariosRow);
            nGXsfl_41_idx = ((subGridusuarios_Islastpage==1)&&(nGXsfl_41_idx+1>subGridusuarios_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_413( ) ;
         }
         /* End function sendrow_413 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SECUSERESTADO_" + sGXsfl_20_idx;
         cmbSecUserEstado.Name = GXCCtl;
         cmbSecUserEstado.WebTags = "";
         cmbSecUserEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbSecUserEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbSecUserEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbSecUserEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbSecUserEstado.ItemCount > 0 )
         {
            A550SecUserEstado = cmbSecUserEstado.getValidValue(A550SecUserEstado);
            n550SecUserEstado = false;
         }
         GXCCtl = "USUARIOSTIPO_" + sGXsfl_41_idx;
         cmbusuariosTipo.Name = GXCCtl;
         cmbusuariosTipo.WebTags = "";
         cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
         cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
         cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
         cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
         cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
         cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
         cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
            A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
         }
         GXCCtl = "USUARIOSESTADO_" + sGXsfl_41_idx;
         cmbusuariosEstado.Name = GXCCtl;
         cmbusuariosEstado.WebTags = "";
         cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl20( )
      {
         if ( GridsecuserContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridsecuserContainer"+"DivS\" data-gxgridid=\"20\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsecuser_Internalname, subGridsecuser_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsecuser_Backcolorstyle == 0 )
            {
               subGridsecuser_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsecuser_Class) > 0 )
               {
                  subGridsecuser_Linesclass = subGridsecuser_Class+"Title";
               }
            }
            else
            {
               subGridsecuser_Titlebackstyle = 1;
               if ( subGridsecuser_Backcolorstyle == 1 )
               {
                  subGridsecuser_Titlebackcolor = subGridsecuser_Allbackcolor;
                  if ( StringUtil.Len( subGridsecuser_Class) > 0 )
                  {
                     subGridsecuser_Linesclass = subGridsecuser_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsecuser_Class) > 0 )
                  {
                     subGridsecuser_Linesclass = subGridsecuser_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+" "+((StringUtil.StrCmp(edtavVer_gximage, "")==0) ? "" : "GX_Image_"+edtavVer_gximage+"_Class")+"\" "+" style=\""+((edtavVer_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario Nro.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "NickName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre Completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+" "+((StringUtil.StrCmp(edtavActivarempresa_gximage, "")==0) ? "" : "GX_Image_"+edtavActivarempresa_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsecuserContainer.AddObjectProperty("GridName", "Gridsecuser");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridsecuserContainer = new GXWebGrid( context);
            }
            else
            {
               GridsecuserContainer.Clear();
            }
            GridsecuserContainer.SetWrapped(nGXWrapped);
            GridsecuserContainer.AddObjectProperty("GridName", "Gridsecuser");
            GridsecuserContainer.AddObjectProperty("Header", subGridsecuser_Header);
            GridsecuserContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridsecuserContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Backcolorstyle), 1, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("CmpContext", "");
            GridsecuserContainer.AddObjectProperty("InMasterPage", "false");
            GridsecuserColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsecuserColumn.AddObjectProperty("Value", context.convertURL( AV22Ver));
            GridsecuserColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavVer_Tooltiptext));
            GridsecuserColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVer_Visible), 5, 0, ".", "")));
            GridsecuserContainer.AddColumnProperties(GridsecuserColumn);
            GridsecuserColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsecuserColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, ".", ""))));
            GridsecuserContainer.AddColumnProperties(GridsecuserColumn);
            GridsecuserColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsecuserColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A26SecUserName));
            GridsecuserColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserName_Link));
            GridsecuserContainer.AddColumnProperties(GridsecuserColumn);
            GridsecuserColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsecuserColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A550SecUserEstado)));
            GridsecuserContainer.AddColumnProperties(GridsecuserColumn);
            GridsecuserColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsecuserColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A587SecUserFullName));
            GridsecuserContainer.AddColumnProperties(GridsecuserColumn);
            GridsecuserColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsecuserColumn.AddObjectProperty("Value", context.convertURL( AV26ActivarEmpresa));
            GridsecuserColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActivarempresa_Tooltiptext));
            GridsecuserContainer.AddColumnProperties(GridsecuserColumn);
            GridsecuserContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Selectedindex), 4, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Allowselection), 1, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Selectioncolor), 9, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Allowhovering), 1, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Hoveringcolor), 9, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Allowcollapsing), 1, 0, ".", "")));
            GridsecuserContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsecuser_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl41( )
      {
         if ( GridusuariosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridusuariosContainer"+"DivS\" data-gxgridid=\"41\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridusuarios_Internalname, subGridusuarios_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridusuarios_Backcolorstyle == 0 )
            {
               subGridusuarios_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridusuarios_Class) > 0 )
               {
                  subGridusuarios_Linesclass = subGridusuarios_Class+"Title";
               }
            }
            else
            {
               subGridusuarios_Titlebackstyle = 1;
               if ( subGridusuarios_Backcolorstyle == 1 )
               {
                  subGridusuarios_Titlebackcolor = subGridusuarios_Allbackcolor;
                  if ( StringUtil.Len( subGridusuarios_Class) > 0 )
                  {
                     subGridusuarios_Linesclass = subGridusuarios_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridusuarios_Class) > 0 )
                  {
                     subGridusuarios_Linesclass = subGridusuarios_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+" "+((StringUtil.StrCmp(edtavVer2_gximage, "")==0) ? "" : "GX_Image_"+edtavVer2_gximage+"_Class")+"\" "+" style=\""+((edtavVer2_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "NickName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Documento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "usuarios Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+" "+((StringUtil.StrCmp(edtavActivarprofesional_gximage, "")==0) ? "" : "GX_Image_"+edtavActivarprofesional_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridusuariosContainer.AddObjectProperty("GridName", "Gridusuarios");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridusuariosContainer = new GXWebGrid( context);
            }
            else
            {
               GridusuariosContainer.Clear();
            }
            GridusuariosContainer.SetWrapped(nGXWrapped);
            GridusuariosContainer.AddObjectProperty("GridName", "Gridusuarios");
            GridusuariosContainer.AddObjectProperty("Header", subGridusuarios_Header);
            GridusuariosContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridusuariosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Backcolorstyle), 1, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("CmpContext", "");
            GridusuariosContainer.AddObjectProperty("InMasterPage", "false");
            GridusuariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusuariosColumn.AddObjectProperty("Value", context.convertURL( AV20Ver2));
            GridusuariosColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavVer2_Tooltiptext));
            GridusuariosColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVer2_Visible), 5, 0, ".", "")));
            GridusuariosContainer.AddColumnProperties(GridusuariosColumn);
            GridusuariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusuariosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A145usuariosId)));
            GridusuariosColumn.AddObjectProperty("Link", StringUtil.RTrim( edtusuariosId_Link));
            GridusuariosContainer.AddColumnProperties(GridusuariosColumn);
            GridusuariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusuariosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A240usuariosNumeroIdentidad)));
            GridusuariosContainer.AddColumnProperties(GridusuariosColumn);
            GridusuariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusuariosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A225usuariosTipo)));
            GridusuariosContainer.AddColumnProperties(GridusuariosColumn);
            GridusuariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusuariosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A226usuariosEstado)));
            GridusuariosContainer.AddColumnProperties(GridusuariosColumn);
            GridusuariosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusuariosColumn.AddObjectProperty("Value", context.convertURL( AV25ActivarProfesional));
            GridusuariosColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavActivarprofesional_Tooltiptext));
            GridusuariosContainer.AddColumnProperties(GridusuariosColumn);
            GridusuariosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Selectedindex), 4, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Allowselection), 1, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Selectioncolor), 9, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Allowhovering), 1, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Hoveringcolor), 9, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Allowcollapsing), 1, 0, ".", "")));
            GridusuariosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusuarios_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavVer_Internalname = "vVER";
         edtSecUserId_Internalname = "SECUSERID";
         edtSecUserName_Internalname = "SECUSERNAME";
         cmbSecUserEstado_Internalname = "SECUSERESTADO";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtavActivarempresa_Internalname = "vACTIVAREMPRESA";
         Gridsecuserpaginationbar_Internalname = "GRIDSECUSERPAGINATIONBAR";
         divGridsecusertablewithpaginationbar_Internalname = "GRIDSECUSERTABLEWITHPAGINATIONBAR";
         divTablecontent1_Internalname = "TABLECONTENT1";
         Dvpanel_tablecontent1_Internalname = "DVPANEL_TABLECONTENT1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavVer2_Internalname = "vVER2";
         edtusuariosId_Internalname = "USUARIOSID";
         edtusuariosNumeroIdentidad_Internalname = "USUARIOSNUMEROIDENTIDAD";
         cmbusuariosTipo_Internalname = "USUARIOSTIPO";
         cmbusuariosEstado_Internalname = "USUARIOSESTADO";
         edtavActivarprofesional_Internalname = "vACTIVARPROFESIONAL";
         Gridusuariospaginationbar_Internalname = "GRIDUSUARIOSPAGINATIONBAR";
         divGridusuariostablewithpaginationbar_Internalname = "GRIDUSUARIOSTABLEWITHPAGINATIONBAR";
         divTablecontent2_Internalname = "TABLECONTENT2";
         Dvpanel_tablecontent2_Internalname = "DVPANEL_TABLECONTENT2";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGridsecusercurrentpage_Internalname = "vGRIDSECUSERCURRENTPAGE";
         edtavGridusuarioscurrentpage_Internalname = "vGRIDUSUARIOSCURRENTPAGE";
         Dvelop_confirmpanel_activarprofesional_Internalname = "DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL";
         tblTabledvelop_confirmpanel_activarprofesional_Internalname = "TABLEDVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL";
         Dvelop_confirmpanel_activarempresa_Internalname = "DVELOP_CONFIRMPANEL_ACTIVAREMPRESA";
         tblTabledvelop_confirmpanel_activarempresa_Internalname = "TABLEDVELOP_CONFIRMPANEL_ACTIVAREMPRESA";
         Gridusuarios_empowerer_Internalname = "GRIDUSUARIOS_EMPOWERER";
         Gridsecuser_empowerer_Internalname = "GRIDSECUSER_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridsecuser_Internalname = "GRIDSECUSER";
         subGridusuarios_Internalname = "GRIDUSUARIOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridusuarios_Allowcollapsing = 0;
         subGridusuarios_Allowselection = 0;
         subGridusuarios_Header = "";
         subGridsecuser_Allowcollapsing = 0;
         subGridsecuser_Allowselection = 0;
         subGridsecuser_Header = "";
         edtavActivarprofesional_Jsonclick = "";
         edtavActivarprofesional_gximage = "";
         edtavActivarprofesional_Tooltiptext = "";
         cmbusuariosEstado_Jsonclick = "";
         cmbusuariosTipo_Jsonclick = "";
         edtusuariosNumeroIdentidad_Jsonclick = "";
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Link = "";
         edtavVer2_Jsonclick = "";
         edtavVer2_gximage = "";
         edtavVer2_Tooltiptext = "";
         subGridusuarios_Class = "GridWithPaginationBar WorkWith";
         subGridusuarios_Backcolorstyle = 0;
         edtavActivarempresa_Jsonclick = "";
         edtavActivarempresa_gximage = "";
         edtavActivarempresa_Tooltiptext = "";
         edtSecUserFullName_Jsonclick = "";
         cmbSecUserEstado_Jsonclick = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Link = "";
         edtSecUserId_Jsonclick = "";
         edtavVer_Jsonclick = "";
         edtavVer_gximage = "";
         edtavVer_Tooltiptext = "";
         subGridsecuser_Class = "GridWithPaginationBar WorkWith";
         subGridsecuser_Backcolorstyle = 0;
         edtavVer_Visible = -1;
         edtavVer2_Visible = -1;
         cmbusuariosEstado.Enabled = 0;
         cmbusuariosTipo.Enabled = 0;
         edtusuariosNumeroIdentidad_Enabled = 0;
         edtusuariosId_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         cmbSecUserEstado.Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtavGridusuarioscurrentpage_Jsonclick = "";
         edtavGridusuarioscurrentpage_Visible = 1;
         edtavGridsecusercurrentpage_Jsonclick = "";
         edtavGridsecusercurrentpage_Visible = 1;
         Dvelop_confirmpanel_activarempresa_Confirmtype = "1";
         Dvelop_confirmpanel_activarempresa_Yesbuttonposition = "left";
         Dvelop_confirmpanel_activarempresa_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_activarempresa_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_activarempresa_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_activarempresa_Confirmationtext = "¿Desea concederle permisos de acceso al sistema?";
         Dvelop_confirmpanel_activarempresa_Title = context.GetMessage( "Atención", "");
         Dvelop_confirmpanel_activarprofesional_Confirmtype = "1";
         Dvelop_confirmpanel_activarprofesional_Yesbuttonposition = "left";
         Dvelop_confirmpanel_activarprofesional_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_activarprofesional_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_activarprofesional_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_activarprofesional_Confirmationtext = "¿Desea concederle permisos de acceso al sistema?";
         Dvelop_confirmpanel_activarprofesional_Title = context.GetMessage( "Atención", "");
         Dvpanel_tablecontent2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecontent2_Iconposition = "Right";
         Dvpanel_tablecontent2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecontent2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecontent2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecontent2_Title = context.GetMessage( "Registro de Profesionales", "");
         Dvpanel_tablecontent2_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tablecontent2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecontent2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecontent2_Width = "100%";
         Gridusuariospaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridusuariospaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridusuariospaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridusuariospaginationbar_Next = "WWP_PagingNextCaption";
         Gridusuariospaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridusuariospaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridusuariospaginationbar_Rowsperpageselectedvalue = 10;
         Gridusuariospaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridusuariospaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridusuariospaginationbar_Pagingcaptionposition = "Left";
         Gridusuariospaginationbar_Pagingbuttonsposition = "Right";
         Gridusuariospaginationbar_Pagestoshow = 5;
         Gridusuariospaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridusuariospaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridusuariospaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridusuariospaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridusuariospaginationbar_Class = "PaginationBar";
         Dvpanel_tablecontent1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecontent1_Iconposition = "Right";
         Dvpanel_tablecontent1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecontent1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecontent1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecontent1_Title = context.GetMessage( "Comercios y Usuarios Administrativos", "");
         Dvpanel_tablecontent1_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tablecontent1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecontent1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecontent1_Width = "100%";
         Gridsecuserpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsecuserpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridsecuserpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridsecuserpaginationbar_Next = "WWP_PagingNextCaption";
         Gridsecuserpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsecuserpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsecuserpaginationbar_Rowsperpageselectedvalue = 10;
         Gridsecuserpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsecuserpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsecuserpaginationbar_Pagingcaptionposition = "Left";
         Gridsecuserpaginationbar_Pagingbuttonsposition = "Right";
         Gridsecuserpaginationbar_Pagestoshow = 5;
         Gridsecuserpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsecuserpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsecuserpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsecuserpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsecuserpaginationbar_Class = "PaginationBar";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Administrar Nuevos Registros", "");
         subGridusuarios_Rows = 0;
         subGridsecuser_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDSECUSER_nFirstRecordOnPage',type:'int'},{av:'GRIDSECUSER_nEOF',type:'int'},{av:'GRIDUSUARIOS_nFirstRecordOnPage',type:'int'},{av:'GRIDUSUARIOS_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavVer2_Visible',ctrl:'vVER2',prop:'Visible'},{av:'edtavVer_Visible',ctrl:'vVER',prop:'Visible'}]}");
         setEventMetadata("GRIDUSUARIOS.LOAD","{handler:'E21CW3',iparms:[{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRIDUSUARIOS.LOAD",",oparms:[{av:'AV20Ver2',fld:'vVER2',pic:'',type:'bits'},{av:'edtavVer2_Tooltiptext',ctrl:'vVER2',prop:'Tooltiptext'},{av:'AV25ActivarProfesional',fld:'vACTIVARPROFESIONAL',pic:'',type:'bits'},{av:'edtavActivarprofesional_Tooltiptext',ctrl:'vACTIVARPROFESIONAL',prop:'Tooltiptext'},{av:'edtusuariosId_Link',ctrl:'USUARIOSID',prop:'Link'}]}");
         setEventMetadata("GRIDSECUSER.LOAD","{handler:'E19CW2',iparms:[{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRIDSECUSER.LOAD",",oparms:[{av:'AV22Ver',fld:'vVER',pic:'',type:'bits'},{av:'edtavVer_Tooltiptext',ctrl:'vVER',prop:'Tooltiptext'},{av:'AV26ActivarEmpresa',fld:'vACTIVAREMPRESA',pic:'',type:'bits'},{av:'edtavActivarempresa_Tooltiptext',ctrl:'vACTIVAREMPRESA',prop:'Tooltiptext'},{av:'edtSecUserName_Link',ctrl:'SECUSERNAME',prop:'Link'}]}");
         setEventMetadata("GRIDUSUARIOSPAGINATIONBAR.CHANGEPAGE","{handler:'E13CW2',iparms:[{av:'GRIDSECUSER_nFirstRecordOnPage',type:'int'},{av:'GRIDSECUSER_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'GRIDUSUARIOS_nFirstRecordOnPage',type:'int'},{av:'GRIDUSUARIOS_nEOF',type:'int'},{av:'Gridusuariospaginationbar_Selectedpage',ctrl:'GRIDUSUARIOSPAGINATIONBAR',prop:'SelectedPage'},{av:'AV17GridUsuariosCurrentPage',fld:'vGRIDUSUARIOSCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRIDUSUARIOSPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV17GridUsuariosCurrentPage',fld:'vGRIDUSUARIOSCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavVer2_Visible',ctrl:'vVER2',prop:'Visible'},{av:'edtavVer_Visible',ctrl:'vVER',prop:'Visible'}]}");
         setEventMetadata("GRIDUSUARIOSPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E14CW2',iparms:[{av:'GRIDUSUARIOS_nFirstRecordOnPage',type:'int'},{av:'GRIDUSUARIOS_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'Gridusuariospaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDUSUARIOSPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDUSUARIOSPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV17GridUsuariosCurrentPage',fld:'vGRIDUSUARIOSCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRIDSECUSERPAGINATIONBAR.CHANGEPAGE","{handler:'E11CW2',iparms:[{av:'GRIDSECUSER_nFirstRecordOnPage',type:'int'},{av:'GRIDSECUSER_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'Gridsecuserpaginationbar_Selectedpage',ctrl:'GRIDSECUSERPAGINATIONBAR',prop:'SelectedPage'},{av:'AV11GridSecUserCurrentPage',fld:'vGRIDSECUSERCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'GRIDUSUARIOS_nFirstRecordOnPage',type:'int'},{av:'GRIDUSUARIOS_nEOF',type:'int'}]");
         setEventMetadata("GRIDSECUSERPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV11GridSecUserCurrentPage',fld:'vGRIDSECUSERCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtavVer2_Visible',ctrl:'vVER2',prop:'Visible'},{av:'edtavVer_Visible',ctrl:'vVER',prop:'Visible'}]}");
         setEventMetadata("GRIDSECUSERPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12CW2',iparms:[{av:'GRIDSECUSER_nFirstRecordOnPage',type:'int'},{av:'GRIDSECUSER_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'Gridsecuserpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDSECUSERPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDSECUSERPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'AV11GridSecUserCurrentPage',fld:'vGRIDSECUSERCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOVER2'","{handler:'E22CW2',iparms:[{av:'GRIDSECUSER_nFirstRecordOnPage',type:'int'},{av:'GRIDSECUSER_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'A240usuariosNumeroIdentidad',fld:'USUARIOSNUMEROIDENTIDAD',pic:'',hsh:true,type:'char'},{av:'GRIDUSUARIOS_nFirstRecordOnPage',type:'int'},{av:'GRIDUSUARIOS_nEOF',type:'int'}]");
         setEventMetadata("'DOVER2'",",oparms:[{av:'edtavVer2_Visible',ctrl:'vVER2',prop:'Visible'},{av:'edtavVer_Visible',ctrl:'vVER',prop:'Visible'}]}");
         setEventMetadata("'DOACTIVARPROFESIONAL'","{handler:'E24CW3',iparms:[]");
         setEventMetadata("'DOACTIVARPROFESIONAL'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL.CLOSE","{handler:'E15CW2',iparms:[{av:'Dvelop_confirmpanel_activarprofesional_Result',ctrl:'DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL',prop:'Result'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',hsh:true,type:'char'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_ACTIVARPROFESIONAL.CLOSE",",oparms:[]}");
         setEventMetadata("'DOVER'","{handler:'E20CW2',iparms:[{av:'GRIDSECUSER_nFirstRecordOnPage',type:'int'},{av:'GRIDSECUSER_nEOF',type:'int'},{av:'subGridsecuser_Rows',ctrl:'GRIDSECUSER',prop:'Rows'},{av:'subGridusuarios_Rows',ctrl:'GRIDUSUARIOS',prop:'Rows'},{av:'AV8IsAuthorized_SecUserName',fld:'vISAUTHORIZED_SECUSERNAME',pic:'',hsh:true,type:'boolean'},{av:'AV15IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'AV28SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDUSUARIOS_nFirstRecordOnPage',type:'int'},{av:'GRIDUSUARIOS_nEOF',type:'int'}]");
         setEventMetadata("'DOVER'",",oparms:[{av:'edtavVer2_Visible',ctrl:'vVER2',prop:'Visible'},{av:'edtavVer_Visible',ctrl:'vVER',prop:'Visible'}]}");
         setEventMetadata("'DOACTIVAREMPRESA'","{handler:'E23CW2',iparms:[]");
         setEventMetadata("'DOACTIVAREMPRESA'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_ACTIVAREMPRESA.CLOSE","{handler:'E16CW2',iparms:[{av:'Dvelop_confirmpanel_activarempresa_Result',ctrl:'DVELOP_CONFIRMPANEL_ACTIVAREMPRESA',prop:'Result'},{av:'AV23usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_ACTIVAREMPRESA.CLOSE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Activarempresa',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSTIPO","{handler:'Valid_Usuariostipo',iparms:[]");
         setEventMetadata("VALID_USUARIOSTIPO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Activarprofesional',iparms:[]");
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
         Gridusuariospaginationbar_Selectedpage = "";
         Gridsecuserpaginationbar_Selectedpage = "";
         Dvelop_confirmpanel_activarprofesional_Result = "";
         Dvelop_confirmpanel_activarempresa_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV23usuariosId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV13GridSecUserAppliedFilters = "";
         AV19GridUsuariosAppliedFilters = "";
         Gridusuarios_empowerer_Gridinternalname = "";
         Gridsecuser_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tablecontent1 = new GXUserControl();
         GridsecuserContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridsecuserpaginationbar = new GXUserControl();
         lblTextblock1_Jsonclick = "";
         ucDvpanel_tablecontent2 = new GXUserControl();
         GridusuariosContainer = new GXWebGrid( context);
         ucGridusuariospaginationbar = new GXUserControl();
         TempTags = "";
         ucGridusuarios_empowerer = new GXUserControl();
         ucGridsecuser_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV22Ver = "";
         AV31Ver_GXI = "";
         A26SecUserName = "";
         A550SecUserEstado = "";
         A587SecUserFullName = "";
         AV26ActivarEmpresa = "";
         AV32Activarempresa_GXI = "";
         AV20Ver2 = "";
         AV29Ver2_GXI = "";
         A145usuariosId = "";
         A240usuariosNumeroIdentidad = "";
         A225usuariosTipo = "";
         A226usuariosEstado = "";
         AV25ActivarProfesional = "";
         AV30Activarprofesional_GXI = "";
         H00CW2_A587SecUserFullName = new string[] {""} ;
         H00CW2_A550SecUserEstado = new string[] {""} ;
         H00CW2_n550SecUserEstado = new bool[] {false} ;
         H00CW2_A26SecUserName = new string[] {""} ;
         H00CW2_A18SecUserId = new long[1] ;
         H00CW3_A226usuariosEstado = new string[] {""} ;
         H00CW3_A225usuariosTipo = new string[] {""} ;
         H00CW3_A240usuariosNumeroIdentidad = new string[] {""} ;
         H00CW3_A145usuariosId = new string[] {""} ;
         H00CW4_A226usuariosEstado = new string[] {""} ;
         H00CW4_A225usuariosTipo = new string[] {""} ;
         H00CW4_A240usuariosNumeroIdentidad = new string[] {""} ;
         H00CW4_A145usuariosId = new string[] {""} ;
         H00CW5_AGRIDSECUSER_nRecordCount = new long[1] ;
         GXEncryptionTmp = "";
         GridsecuserRow = new GXWebRow();
         GridusuariosRow = new GXWebRow();
         ucDvelop_confirmpanel_activarempresa = new GXUserControl();
         ucDvelop_confirmpanel_activarprofesional = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridsecuser_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         subGridusuarios_Linesclass = "";
         GridsecuserColumn = new GXWebColumn();
         GridusuariosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.admnuevoregistros__default(),
            new Object[][] {
                new Object[] {
               H00CW2_A587SecUserFullName, H00CW2_A550SecUserEstado, H00CW2_n550SecUserEstado, H00CW2_A26SecUserName, H00CW2_A18SecUserId
               }
               , new Object[] {
               H00CW3_A226usuariosEstado, H00CW3_A225usuariosTipo, H00CW3_A240usuariosNumeroIdentidad, H00CW3_A145usuariosId
               }
               , new Object[] {
               H00CW4_A226usuariosEstado, H00CW4_A225usuariosTipo, H00CW4_A240usuariosNumeroIdentidad, H00CW4_A145usuariosId
               }
               , new Object[] {
               H00CW5_AGRIDSECUSER_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRIDSECUSER_nEOF ;
      private short GRIDUSUARIOS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGridsecuser_Backcolorstyle ;
      private short subGridusuarios_Backcolorstyle ;
      private short subGridsecuser_Backstyle ;
      private short subGridusuarios_Backstyle ;
      private short subGridsecuser_Titlebackstyle ;
      private short subGridsecuser_Allowselection ;
      private short subGridsecuser_Allowhovering ;
      private short subGridsecuser_Allowcollapsing ;
      private short subGridsecuser_Collapsed ;
      private short subGridusuarios_Titlebackstyle ;
      private short subGridusuarios_Allowselection ;
      private short subGridusuarios_Allowhovering ;
      private short subGridusuarios_Allowcollapsing ;
      private short subGridusuarios_Collapsed ;
      private int Gridusuariospaginationbar_Rowsperpageselectedvalue ;
      private int Gridsecuserpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_20 ;
      private int nRC_GXsfl_41 ;
      private int subGridsecuser_Rows ;
      private int subGridusuarios_Rows ;
      private int nGXsfl_20_idx=1 ;
      private int nGXsfl_41_idx=1 ;
      private int Gridsecuserpaginationbar_Pagestoshow ;
      private int Gridusuariospaginationbar_Pagestoshow ;
      private int edtavGridsecusercurrentpage_Visible ;
      private int edtavGridusuarioscurrentpage_Visible ;
      private int subGridsecuser_Islastpage ;
      private int subGridusuarios_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtusuariosId_Enabled ;
      private int edtusuariosNumeroIdentidad_Enabled ;
      private int AV10PageToGo ;
      private int edtavVer2_Visible ;
      private int edtavVer_Visible ;
      private int idxLst ;
      private int subGridsecuser_Backcolor ;
      private int subGridsecuser_Allbackcolor ;
      private int subGridusuarios_Backcolor ;
      private int subGridusuarios_Allbackcolor ;
      private int subGridsecuser_Titlebackcolor ;
      private int subGridsecuser_Selectedindex ;
      private int subGridsecuser_Selectioncolor ;
      private int subGridsecuser_Hoveringcolor ;
      private int subGridusuarios_Titlebackcolor ;
      private int subGridusuarios_Selectedindex ;
      private int subGridusuarios_Selectioncolor ;
      private int subGridusuarios_Hoveringcolor ;
      private long GRIDSECUSER_nFirstRecordOnPage ;
      private long GRIDUSUARIOS_nFirstRecordOnPage ;
      private long AV28SecUserId ;
      private long AV12GridSecUserPageCount ;
      private long AV18GridUsuariosPageCount ;
      private long AV11GridSecUserCurrentPage ;
      private long AV17GridUsuariosCurrentPage ;
      private long A18SecUserId ;
      private long GRIDSECUSER_nCurrentRecord ;
      private long GRIDUSUARIOS_nCurrentRecord ;
      private long GRIDUSUARIOS_nRecordCount ;
      private long GRIDSECUSER_nRecordCount ;
      private string Gridusuariospaginationbar_Selectedpage ;
      private string Gridsecuserpaginationbar_Selectedpage ;
      private string Dvelop_confirmpanel_activarprofesional_Result ;
      private string Dvelop_confirmpanel_activarempresa_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_20_idx="0001" ;
      private string AV23usuariosId ;
      private string sGXsfl_41_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gridsecuserpaginationbar_Class ;
      private string Gridsecuserpaginationbar_Pagingbuttonsposition ;
      private string Gridsecuserpaginationbar_Pagingcaptionposition ;
      private string Gridsecuserpaginationbar_Emptygridclass ;
      private string Gridsecuserpaginationbar_Rowsperpageoptions ;
      private string Gridsecuserpaginationbar_Previous ;
      private string Gridsecuserpaginationbar_Next ;
      private string Gridsecuserpaginationbar_Caption ;
      private string Gridsecuserpaginationbar_Emptygridcaption ;
      private string Gridsecuserpaginationbar_Rowsperpagecaption ;
      private string Dvpanel_tablecontent1_Width ;
      private string Dvpanel_tablecontent1_Cls ;
      private string Dvpanel_tablecontent1_Title ;
      private string Dvpanel_tablecontent1_Iconposition ;
      private string Gridusuariospaginationbar_Class ;
      private string Gridusuariospaginationbar_Pagingbuttonsposition ;
      private string Gridusuariospaginationbar_Pagingcaptionposition ;
      private string Gridusuariospaginationbar_Emptygridclass ;
      private string Gridusuariospaginationbar_Rowsperpageoptions ;
      private string Gridusuariospaginationbar_Previous ;
      private string Gridusuariospaginationbar_Next ;
      private string Gridusuariospaginationbar_Caption ;
      private string Gridusuariospaginationbar_Emptygridcaption ;
      private string Gridusuariospaginationbar_Rowsperpagecaption ;
      private string Dvpanel_tablecontent2_Width ;
      private string Dvpanel_tablecontent2_Cls ;
      private string Dvpanel_tablecontent2_Title ;
      private string Dvpanel_tablecontent2_Iconposition ;
      private string Dvelop_confirmpanel_activarprofesional_Title ;
      private string Dvelop_confirmpanel_activarprofesional_Confirmationtext ;
      private string Dvelop_confirmpanel_activarprofesional_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_activarprofesional_Nobuttoncaption ;
      private string Dvelop_confirmpanel_activarprofesional_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_activarprofesional_Yesbuttonposition ;
      private string Dvelop_confirmpanel_activarprofesional_Confirmtype ;
      private string Dvelop_confirmpanel_activarempresa_Title ;
      private string Dvelop_confirmpanel_activarempresa_Confirmationtext ;
      private string Dvelop_confirmpanel_activarempresa_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_activarempresa_Nobuttoncaption ;
      private string Dvelop_confirmpanel_activarempresa_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_activarempresa_Yesbuttonposition ;
      private string Dvelop_confirmpanel_activarempresa_Confirmtype ;
      private string Gridusuarios_empowerer_Gridinternalname ;
      private string Gridsecuser_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_tablecontent1_Internalname ;
      private string divTablecontent1_Internalname ;
      private string divGridsecusertablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridsecuser_Internalname ;
      private string Gridsecuserpaginationbar_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string Dvpanel_tablecontent2_Internalname ;
      private string divTablecontent2_Internalname ;
      private string divGridusuariostablewithpaginationbar_Internalname ;
      private string subGridusuarios_Internalname ;
      private string Gridusuariospaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavGridsecusercurrentpage_Internalname ;
      private string edtavGridsecusercurrentpage_Jsonclick ;
      private string edtavGridusuarioscurrentpage_Internalname ;
      private string edtavGridusuarioscurrentpage_Jsonclick ;
      private string Gridusuarios_empowerer_Internalname ;
      private string Gridsecuser_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavVer_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string cmbSecUserEstado_Internalname ;
      private string A550SecUserEstado ;
      private string edtSecUserFullName_Internalname ;
      private string edtavActivarempresa_Internalname ;
      private string edtavVer2_Internalname ;
      private string A145usuariosId ;
      private string edtusuariosId_Internalname ;
      private string A240usuariosNumeroIdentidad ;
      private string edtusuariosNumeroIdentidad_Internalname ;
      private string cmbusuariosTipo_Internalname ;
      private string A225usuariosTipo ;
      private string cmbusuariosEstado_Internalname ;
      private string A226usuariosEstado ;
      private string edtavActivarprofesional_Internalname ;
      private string edtavVer_gximage ;
      private string edtavVer_Tooltiptext ;
      private string edtavActivarempresa_gximage ;
      private string edtavActivarempresa_Tooltiptext ;
      private string edtSecUserName_Link ;
      private string GXEncryptionTmp ;
      private string edtavVer2_gximage ;
      private string edtavVer2_Tooltiptext ;
      private string edtavActivarprofesional_gximage ;
      private string edtavActivarprofesional_Tooltiptext ;
      private string edtusuariosId_Link ;
      private string tblTabledvelop_confirmpanel_activarempresa_Internalname ;
      private string Dvelop_confirmpanel_activarempresa_Internalname ;
      private string tblTabledvelop_confirmpanel_activarprofesional_Internalname ;
      private string Dvelop_confirmpanel_activarprofesional_Internalname ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string subGridsecuser_Class ;
      private string subGridsecuser_Linesclass ;
      private string sImgUrl ;
      private string edtavVer_Jsonclick ;
      private string ROClassString ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string GXCCtl ;
      private string cmbSecUserEstado_Jsonclick ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtavActivarempresa_Jsonclick ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGridusuarios_Class ;
      private string subGridusuarios_Linesclass ;
      private string edtavVer2_Jsonclick ;
      private string edtusuariosId_Jsonclick ;
      private string edtusuariosNumeroIdentidad_Jsonclick ;
      private string cmbusuariosTipo_Jsonclick ;
      private string cmbusuariosEstado_Jsonclick ;
      private string edtavActivarprofesional_Jsonclick ;
      private string subGridsecuser_Header ;
      private string subGridusuarios_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8IsAuthorized_SecUserName ;
      private bool AV15IsAuthorized_usuariosId ;
      private bool Gridsecuserpaginationbar_Showfirst ;
      private bool Gridsecuserpaginationbar_Showprevious ;
      private bool Gridsecuserpaginationbar_Shownext ;
      private bool Gridsecuserpaginationbar_Showlast ;
      private bool Gridsecuserpaginationbar_Rowsperpageselector ;
      private bool Dvpanel_tablecontent1_Autowidth ;
      private bool Dvpanel_tablecontent1_Autoheight ;
      private bool Dvpanel_tablecontent1_Collapsible ;
      private bool Dvpanel_tablecontent1_Collapsed ;
      private bool Dvpanel_tablecontent1_Showcollapseicon ;
      private bool Dvpanel_tablecontent1_Autoscroll ;
      private bool Gridusuariospaginationbar_Showfirst ;
      private bool Gridusuariospaginationbar_Showprevious ;
      private bool Gridusuariospaginationbar_Shownext ;
      private bool Gridusuariospaginationbar_Showlast ;
      private bool Gridusuariospaginationbar_Rowsperpageselector ;
      private bool Dvpanel_tablecontent2_Autowidth ;
      private bool Dvpanel_tablecontent2_Autoheight ;
      private bool Dvpanel_tablecontent2_Collapsible ;
      private bool Dvpanel_tablecontent2_Collapsed ;
      private bool Dvpanel_tablecontent2_Showcollapseicon ;
      private bool Dvpanel_tablecontent2_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool n550SecUserEstado ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV21IsAuthorized_Ver2 ;
      private bool AV24IsAuthorized_Ver ;
      private bool GXt_boolean1 ;
      private bool AV22Ver_IsBlob ;
      private bool AV26ActivarEmpresa_IsBlob ;
      private bool AV20Ver2_IsBlob ;
      private bool AV25ActivarProfesional_IsBlob ;
      private string AV13GridSecUserAppliedFilters ;
      private string AV19GridUsuariosAppliedFilters ;
      private string AV31Ver_GXI ;
      private string A26SecUserName ;
      private string A587SecUserFullName ;
      private string AV32Activarempresa_GXI ;
      private string AV29Ver2_GXI ;
      private string AV30Activarprofesional_GXI ;
      private string AV22Ver ;
      private string AV26ActivarEmpresa ;
      private string AV20Ver2 ;
      private string AV25ActivarProfesional ;
      private GXWebGrid GridsecuserContainer ;
      private GXWebGrid GridusuariosContainer ;
      private GXWebRow GridsecuserRow ;
      private GXWebRow GridusuariosRow ;
      private GXWebColumn GridsecuserColumn ;
      private GXWebColumn GridusuariosColumn ;
      private GXUserControl ucDvpanel_tablecontent1 ;
      private GXUserControl ucGridsecuserpaginationbar ;
      private GXUserControl ucDvpanel_tablecontent2 ;
      private GXUserControl ucGridusuariospaginationbar ;
      private GXUserControl ucGridusuarios_empowerer ;
      private GXUserControl ucGridsecuser_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_activarempresa ;
      private GXUserControl ucDvelop_confirmpanel_activarprofesional ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSecUserEstado ;
      private GXCombobox cmbusuariosTipo ;
      private GXCombobox cmbusuariosEstado ;
      private IDataStoreProvider pr_default ;
      private string[] H00CW2_A587SecUserFullName ;
      private string[] H00CW2_A550SecUserEstado ;
      private bool[] H00CW2_n550SecUserEstado ;
      private string[] H00CW2_A26SecUserName ;
      private long[] H00CW2_A18SecUserId ;
      private string[] H00CW3_A226usuariosEstado ;
      private string[] H00CW3_A225usuariosTipo ;
      private string[] H00CW3_A240usuariosNumeroIdentidad ;
      private string[] H00CW3_A145usuariosId ;
      private string[] H00CW4_A226usuariosEstado ;
      private string[] H00CW4_A225usuariosTipo ;
      private string[] H00CW4_A240usuariosNumeroIdentidad ;
      private string[] H00CW4_A145usuariosId ;
      private long[] H00CW5_AGRIDSECUSER_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class admnuevoregistros__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00CW2;
          prmH00CW2 = new Object[] {
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00CW3;
          prmH00CW3 = new Object[] {
          };
          Object[] prmH00CW4;
          prmH00CW4 = new Object[] {
          };
          Object[] prmH00CW5;
          prmH00CW5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00CW2", "SELECT [SecUserFullName], [SecUserEstado], [SecUserName], [SecUserId] FROM [SecUser] WHERE [SecUserEstado] = 'PEN' ORDER BY [SecUserId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CW2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00CW3", "SELECT [usuariosEstado], [usuariosTipo], [usuariosNumeroIdentidad], [usuariosId] FROM [usuarios] WHERE [usuariosEstado] = 'PEN' ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CW3,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00CW4", "SELECT [usuariosEstado], [usuariosTipo], [usuariosNumeroIdentidad], [usuariosId] FROM [usuarios] WHERE [usuariosEstado] = 'PEN' ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CW4,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00CW5", "SELECT COUNT(*) FROM [SecUser] WHERE [SecUserEstado] = 'PEN' ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CW5,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

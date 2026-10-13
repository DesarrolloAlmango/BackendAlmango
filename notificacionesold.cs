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
   public class notificacionesold : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public notificacionesold( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public notificacionesold( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavUsuariosnotificaciontipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridnoti") == 0 )
               {
                  gxnrGridnoti_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridnoti") == 0 )
               {
                  gxgrGridnoti_refresh_invoke( ) ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGridnoti_newrow_invoke( )
      {
         nRC_GXsfl_18 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_18"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_18_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_18_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_18_idx = GetPar( "sGXsfl_18_idx");
         sPrefix = GetPar( "sPrefix");
         cmbavUsuariosnotificaciontipo.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsuariosnotificaciontipo.Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavUsuariosnotificacioncodigo_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificacioncodigo_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavNusuariosid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavNusuariosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNusuariosid_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavUsuariosnotificaciondescripcion_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUsuariosnotificaciondescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificaciondescripcion_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridnoti_newrow( ) ;
         /* End function gxnrGridnoti_newrow_invoke */
      }

      protected void gxgrGridnoti_refresh_invoke( )
      {
         subGridnoti_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridnoti_Rows"), "."), 18, MidpointRounding.ToEven));
         cmbavUsuariosnotificaciontipo.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsuariosnotificaciontipo.Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavUsuariosnotificacioncodigo_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificacioncodigo_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavNusuariosid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavNusuariosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNusuariosid_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavUsuariosnotificaciondescripcion_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUsuariosnotificaciondescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificaciondescripcion_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV17Notificaciones);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridnoti_refresh( subGridnoti_Rows, AV17Notificaciones, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridnoti_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PAB82( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavEliminar_Enabled = 0;
               AssignProp(sPrefix, false, edtavEliminar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEliminar_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               edtavNusuariosid_Enabled = 0;
               AssignProp(sPrefix, false, edtavNusuariosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNusuariosid_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               edtavUsuariosnotificacioncodigo_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificacioncodigo_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               cmbavUsuariosnotificaciontipo.Enabled = 0;
               AssignProp(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuariosnotificaciontipo.Enabled), 5, 0), !bGXsfl_18_Refreshing);
               edtavUsuariosnotificaciondescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuariosnotificaciondescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificaciondescripcion_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               edtavNusuariosnotificacionfecha_Enabled = 0;
               AssignProp(sPrefix, false, edtavNusuariosnotificacionfecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNusuariosnotificacionfecha_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               edtavParametros_Enabled = 0;
               AssignProp(sPrefix, false, edtavParametros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParametros_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               WSB82( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Incidencias", "")) ;
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
         }
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notificacionesold.aspx") +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               GxWebStd.gx_hidden_field( context, "_GxRefreshTimeout", "{\"Type\":\"always\",\"Time\":\"2700\"}");
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICACIONES", AV17Notificaciones);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICACIONES", AV17Notificaciones);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOTIFICACIONES", GetSecureSignedToken( sPrefix, AV17Notificaciones, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDNOTIPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14GridNotiPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDNOTIAPPLIEDFILTERS", AV15GridNotiAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICACIONES", AV17Notificaciones);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICACIONES", AV17Notificaciones);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOTIFICACIONES", GetSecureSignedToken( sPrefix, AV17Notificaciones, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGridnoti_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Class", StringUtil.RTrim( Gridnotipaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridnotipaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridnotipaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridnotipaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridnotipaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridnotipaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridnotipaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridnotipaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridnotipaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridnotipaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridnotipaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridnotipaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Previous", StringUtil.RTrim( Gridnotipaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Next", StringUtil.RTrim( Gridnotipaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Caption", StringUtil.RTrim( Gridnotipaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridnotipaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridnotipaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridnoti_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridnotipaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridnotipaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSNOTIFICACIONTIPO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsuariosnotificaciontipo.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSNOTIFICACIONCODIGO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosnotificacioncodigo_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNUSUARIOSID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNusuariosid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSNOTIFICACIONDESCRIPCION_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosnotificaciondescripcion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridnotipaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridnotipaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormB82( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "NotificacionesOld" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Incidencias", "") ;
      }

      protected void WBB80( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "notificacionesold.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridnotitablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridnotiContainer.SetWrapped(nGXWrapped);
            StartGridControl18( ) ;
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            nRC_GXsfl_18 = (int)(nGXsfl_18_idx-1);
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridnotiContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridnoti", GridnotiContainer, subGridnoti_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridnotiContainerData", GridnotiContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridnotiContainerData"+"V", GridnotiContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridnotiContainerData"+"V"+"\" value='"+GridnotiContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridnotipaginationbar.SetProperty("Class", Gridnotipaginationbar_Class);
            ucGridnotipaginationbar.SetProperty("ShowFirst", Gridnotipaginationbar_Showfirst);
            ucGridnotipaginationbar.SetProperty("ShowPrevious", Gridnotipaginationbar_Showprevious);
            ucGridnotipaginationbar.SetProperty("ShowNext", Gridnotipaginationbar_Shownext);
            ucGridnotipaginationbar.SetProperty("ShowLast", Gridnotipaginationbar_Showlast);
            ucGridnotipaginationbar.SetProperty("PagesToShow", Gridnotipaginationbar_Pagestoshow);
            ucGridnotipaginationbar.SetProperty("PagingButtonsPosition", Gridnotipaginationbar_Pagingbuttonsposition);
            ucGridnotipaginationbar.SetProperty("PagingCaptionPosition", Gridnotipaginationbar_Pagingcaptionposition);
            ucGridnotipaginationbar.SetProperty("EmptyGridClass", Gridnotipaginationbar_Emptygridclass);
            ucGridnotipaginationbar.SetProperty("RowsPerPageSelector", Gridnotipaginationbar_Rowsperpageselector);
            ucGridnotipaginationbar.SetProperty("RowsPerPageOptions", Gridnotipaginationbar_Rowsperpageoptions);
            ucGridnotipaginationbar.SetProperty("Previous", Gridnotipaginationbar_Previous);
            ucGridnotipaginationbar.SetProperty("Next", Gridnotipaginationbar_Next);
            ucGridnotipaginationbar.SetProperty("Caption", Gridnotipaginationbar_Caption);
            ucGridnotipaginationbar.SetProperty("EmptyGridCaption", Gridnotipaginationbar_Emptygridcaption);
            ucGridnotipaginationbar.SetProperty("RowsPerPageCaption", Gridnotipaginationbar_Rowsperpagecaption);
            ucGridnotipaginationbar.SetProperty("CurrentPage", AV13GridNotiCurrentPage);
            ucGridnotipaginationbar.SetProperty("PageCount", AV14GridNotiPageCount);
            ucGridnotipaginationbar.SetProperty("AppliedFilters", AV15GridNotiAppliedFilters);
            ucGridnotipaginationbar.Render(context, "dvelop.dvpaginationbar", Gridnotipaginationbar_Internalname, sPrefix+"GRIDNOTIPAGINATIONBARContainer");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridnoticurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13GridNotiCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13GridNotiCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridnoticurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridnoticurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacionesOld.htm");
            /* User Defined Control */
            ucGridnoti_empowerer.Render(context, "wwp.gridempowerer", Gridnoti_empowerer_Internalname, sPrefix+"GRIDNOTI_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridnotiContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridnotiContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridnoti", GridnotiContainer, subGridnoti_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridnotiContainerData", GridnotiContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridnotiContainerData"+"V", GridnotiContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridnotiContainerData"+"V"+"\" value='"+GridnotiContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTB82( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Incidencias", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUPB80( ) ;
            }
         }
      }

      protected void WSB82( )
      {
         STARTB82( ) ;
         EVTB82( ) ;
      }

      protected void EVTB82( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB80( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDNOTIPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB80( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridnotipaginationbar.Changepage */
                                    E11B82 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDNOTIPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB80( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridnotipaginationbar.Changerowsperpage */
                                    E12B82 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB80( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavEliminar_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRIDNOTI.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VELIMINAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VELIMINAR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPB80( ) ;
                              }
                              nGXsfl_18_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              AV16Eliminar = cgiGet( edtavEliminar_Internalname);
                              AssignAttri(sPrefix, false, edtavEliminar_Internalname, AV16Eliminar);
                              AV7NusuariosId = cgiGet( edtavNusuariosid_Internalname);
                              AssignAttri(sPrefix, false, edtavNusuariosid_Internalname, AV7NusuariosId);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNUSUARIOSID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV7NusuariosId, "")), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuariosnotificacioncodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuariosnotificacioncodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSUARIOSNOTIFICACIONCODIGO");
                                 GX_FocusControl = edtavUsuariosnotificacioncodigo_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV8usuariosNotificacionCodigo = 0;
                                 AssignAttri(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, StringUtil.LTrimStr( (decimal)(AV8usuariosNotificacionCodigo), 10, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONCODIGO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV8usuariosNotificacionCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuariosnotificacioncodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, StringUtil.LTrimStr( (decimal)(AV8usuariosNotificacionCodigo), 10, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONCODIGO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
                              }
                              cmbavUsuariosnotificaciontipo.Name = cmbavUsuariosnotificaciontipo_Internalname;
                              cmbavUsuariosnotificaciontipo.CurrentValue = cgiGet( cmbavUsuariosnotificaciontipo_Internalname);
                              AV9usuariosNotificacionTipo = cgiGet( cmbavUsuariosnotificaciontipo_Internalname);
                              AssignAttri(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, AV9usuariosNotificacionTipo);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONTIPO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV9usuariosNotificacionTipo, "")), context));
                              AV10usuariosNotificacionDescripcion = cgiGet( edtavUsuariosnotificaciondescripcion_Internalname);
                              AssignAttri(sPrefix, false, edtavUsuariosnotificaciondescripcion_Internalname, AV10usuariosNotificacionDescripcion);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavNusuariosnotificacionfecha_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Nusuarios Notificacion Fecha", "")}), 1, "vNUSUARIOSNOTIFICACIONFECHA");
                                 GX_FocusControl = edtavNusuariosnotificacionfecha_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV19NusuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
                                 AssignAttri(sPrefix, false, edtavNusuariosnotificacionfecha_Internalname, context.localUtil.Format(AV19NusuariosNotificacionFecha, "99/99/99"));
                              }
                              else
                              {
                                 AV19NusuariosNotificacionFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtavNusuariosnotificacionfecha_Internalname), 0));
                                 AssignAttri(sPrefix, false, edtavNusuariosnotificacionfecha_Internalname, context.localUtil.Format(AV19NusuariosNotificacionFecha, "99/99/99"));
                              }
                              AV23Parametros = cgiGet( edtavParametros_Internalname);
                              AssignAttri(sPrefix, false, edtavParametros_Internalname, AV23Parametros);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEliminar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E13B82 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEliminar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E14B82 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDNOTI.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEliminar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridnoti.Load */
                                          E15B82 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VELIMINAR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEliminar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E16B82 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUPB80( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEliminar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WEB82( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormB82( ) ;
            }
         }
      }

      protected void PAB82( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavGridnoticurrentpage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridnoti_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_182( ) ;
         while ( nGXsfl_18_idx <= nRC_GXsfl_18 )
         {
            sendrow_182( ) ;
            nGXsfl_18_idx = ((subGridnoti_Islastpage==1)&&(nGXsfl_18_idx+1>subGridnoti_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridnotiContainer)) ;
         /* End function gxnrGridnoti_newrow */
      }

      protected void gxgrGridnoti_refresh( int subGridnoti_Rows ,
                                           GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> AV17Notificaciones ,
                                           string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDNOTI_nCurrentRecord = 0;
         RFB82( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridnoti_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNUSUARIOSID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV7NusuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNUSUARIOSID", StringUtil.RTrim( AV7NusuariosId));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV9usuariosNotificacionTipo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSNOTIFICACIONTIPO", StringUtil.RTrim( AV9usuariosNotificacionTipo));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONCODIGO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSNOTIFICACIONCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8usuariosNotificacionCodigo), 10, 0, ".", "")));
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
         RFB82( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavEliminar_Enabled = 0;
         edtavNusuariosid_Enabled = 0;
         edtavUsuariosnotificacioncodigo_Enabled = 0;
         cmbavUsuariosnotificaciontipo.Enabled = 0;
         edtavUsuariosnotificaciondescripcion_Enabled = 0;
         edtavNusuariosnotificacionfecha_Enabled = 0;
         edtavParametros_Enabled = 0;
      }

      protected void RFB82( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridnotiContainer.ClearRows();
         }
         wbStart = 18;
         /* Execute user event: Refresh */
         E14B82 ();
         nGXsfl_18_idx = 1;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         bGXsfl_18_Refreshing = true;
         GridnotiContainer.AddObjectProperty("GridName", "Gridnoti");
         GridnotiContainer.AddObjectProperty("CmpContext", sPrefix);
         GridnotiContainer.AddObjectProperty("InMasterPage", "false");
         GridnotiContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridnotiContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridnotiContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridnotiContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Backcolorstyle), 1, 0, ".", "")));
         GridnotiContainer.PageSize = subGridnoti_fnc_Recordsperpage( );
         if ( subGridnoti_Islastpage != 0 )
         {
            GRIDNOTI_nFirstRecordOnPage = (long)(subGridnoti_fnc_Recordcount( )-subGridnoti_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nFirstRecordOnPage), 15, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("GRIDNOTI_nFirstRecordOnPage", GRIDNOTI_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_182( ) ;
            /* Execute user event: Gridnoti.Load */
            E15B82 ();
            if ( ( subGridnoti_Islastpage == 0 ) && ( GRIDNOTI_nCurrentRecord > 0 ) && ( GRIDNOTI_nGridOutOfScope == 0 ) && ( nGXsfl_18_idx == 1 ) )
            {
               GRIDNOTI_nCurrentRecord = 0;
               GRIDNOTI_nGridOutOfScope = 1;
               subgridnoti_firstpage( ) ;
               /* Execute user event: Gridnoti.Load */
               E15B82 ();
            }
            wbEnd = 18;
            WBB80( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesB82( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICACIONES", AV17Notificaciones);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICACIONES", AV17Notificaciones);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOTIFICACIONES", GetSecureSignedToken( sPrefix, AV17Notificaciones, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNUSUARIOSID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV7NusuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONTIPO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV9usuariosNotificacionTipo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONCODIGO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
      }

      protected int subGridnoti_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridnoti_fnc_Recordcount( )
      {
         return (int)(((subGridnoti_Recordcount==0) ? GRIDNOTI_nFirstRecordOnPage+1 : subGridnoti_Recordcount)) ;
      }

      protected int subGridnoti_fnc_Recordsperpage( )
      {
         if ( subGridnoti_Rows > 0 )
         {
            return subGridnoti_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridnoti_fnc_Currentpage( )
      {
         return (int)(((subGridnoti_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGridnoti_fnc_Recordcount( )/ (decimal)(subGridnoti_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGridnoti_fnc_Recordcount( )) % (subGridnoti_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRIDNOTI_nFirstRecordOnPage/ (decimal)(subGridnoti_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgridnoti_firstpage( )
      {
         GRIDNOTI_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnoti_refresh( subGridnoti_Rows, AV17Notificaciones, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridnoti_nextpage( )
      {
         if ( GRIDNOTI_nEOF == 0 )
         {
            GRIDNOTI_nFirstRecordOnPage = (long)(GRIDNOTI_nFirstRecordOnPage+subGridnoti_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nFirstRecordOnPage), 15, 0, ".", "")));
         GridnotiContainer.AddObjectProperty("GRIDNOTI_nFirstRecordOnPage", GRIDNOTI_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnoti_refresh( subGridnoti_Rows, AV17Notificaciones, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDNOTI_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridnoti_previouspage( )
      {
         if ( GRIDNOTI_nFirstRecordOnPage >= subGridnoti_fnc_Recordsperpage( ) )
         {
            GRIDNOTI_nFirstRecordOnPage = (long)(GRIDNOTI_nFirstRecordOnPage-subGridnoti_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnoti_refresh( subGridnoti_Rows, AV17Notificaciones, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridnoti_lastpage( )
      {
         subGridnoti_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnoti_refresh( subGridnoti_Rows, AV17Notificaciones, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridnoti_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDNOTI_nFirstRecordOnPage = (long)(subGridnoti_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDNOTI_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnoti_refresh( subGridnoti_Rows, AV17Notificaciones, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavEliminar_Enabled = 0;
         edtavNusuariosid_Enabled = 0;
         edtavUsuariosnotificacioncodigo_Enabled = 0;
         cmbavUsuariosnotificaciontipo.Enabled = 0;
         edtavUsuariosnotificaciondescripcion_Enabled = 0;
         edtavNusuariosnotificacionfecha_Enabled = 0;
         edtavParametros_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB80( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13B82 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_18"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV14GridNotiPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDNOTIPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14GridNotiPageCount", StringUtil.LTrimStr( (decimal)(AV14GridNotiPageCount), 10, 0));
            AV15GridNotiAppliedFilters = cgiGet( sPrefix+"vGRIDNOTIAPPLIEDFILTERS");
            GRIDNOTI_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDNOTI_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDNOTI_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDNOTI_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridnoti_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGridnoti_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridnoti_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDNOTI_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Rows), 6, 0, ".", "")));
            Gridnotipaginationbar_Class = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Class");
            Gridnotipaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Showfirst"));
            Gridnotipaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Showprevious"));
            Gridnotipaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Shownext"));
            Gridnotipaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Showlast"));
            Gridnotipaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridnotipaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Pagingbuttonsposition");
            Gridnotipaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Pagingcaptionposition");
            Gridnotipaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Emptygridclass");
            Gridnotipaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselector"));
            Gridnotipaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridnotipaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageoptions");
            Gridnotipaginationbar_Previous = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Previous");
            Gridnotipaginationbar_Next = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Next");
            Gridnotipaginationbar_Caption = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Caption");
            Gridnotipaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Emptygridcaption");
            Gridnotipaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpagecaption");
            Gridnoti_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDNOTI_EMPOWERER_Gridinternalname");
            Gridnotipaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Selectedpage");
            Gridnotipaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDNOTIPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridnoticurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridnoticurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDNOTICURRENTPAGE");
               GX_FocusControl = edtavGridnoticurrentpage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13GridNotiCurrentPage = 0;
               AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
            }
            else
            {
               AV13GridNotiCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridnoticurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
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
         E13B82 ();
         if (returnInSub) return;
      }

      protected void E13B82( )
      {
         /* Start Routine */
         returnInSub = false;
         Gridnoti_empowerer_Gridinternalname = subGridnoti_Internalname;
         ucGridnoti_empowerer.SendProperty(context, sPrefix, false, Gridnoti_empowerer_Internalname, "GridInternalName", Gridnoti_empowerer_Gridinternalname);
         subGridnoti_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Rows), 6, 0, ".", "")));
         AV13GridNotiCurrentPage = 1;
         AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
         edtavGridnoticurrentpage_Visible = 0;
         AssignProp(sPrefix, false, edtavGridnoticurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridnoticurrentpage_Visible), 5, 0), true);
         AV14GridNotiPageCount = -1;
         AssignAttri(sPrefix, false, "AV14GridNotiPageCount", StringUtil.LTrimStr( (decimal)(AV14GridNotiPageCount), 10, 0));
         Gridnotipaginationbar_Rowsperpageselectedvalue = subGridnoti_Rows;
         ucGridnotipaginationbar.SendProperty(context, sPrefix, false, Gridnotipaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridnotipaginationbar_Rowsperpageselectedvalue), 9, 0));
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV25WWPContext) ;
         /* Execute user subroutine: 'OBTENER NOTIFICACIONES' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E14B82( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E15B82( )
      {
         /* Gridnoti_Load Routine */
         returnInSub = false;
         AV17Notificaciones.Sort(context.GetMessage( "[NusuariosNotificacionFecha]", ""));
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV17Notificaciones.Count )
         {
            AV18item = ((SdtNotificacionesSDT_NotificacionesSDTItem)AV17Notificaciones.Item(AV28GXV1));
            if ( ! (0==AV18item.gxTpr_Nusuariosnotificacioncodigo) )
            {
               AV7NusuariosId = AV18item.gxTpr_Nusuariosid;
               AssignAttri(sPrefix, false, edtavNusuariosid_Internalname, AV7NusuariosId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNUSUARIOSID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV7NusuariosId, "")), context));
               AV9usuariosNotificacionTipo = AV18item.gxTpr_Nusuariosnotificaciontipo;
               AssignAttri(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, AV9usuariosNotificacionTipo);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONTIPO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV9usuariosNotificacionTipo, "")), context));
               AV8usuariosNotificacionCodigo = AV18item.gxTpr_Nusuariosnotificacioncodigo;
               AssignAttri(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, StringUtil.LTrimStr( (decimal)(AV8usuariosNotificacionCodigo), 10, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONCODIGO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
               AV22usuariosNotificacionNotificado = AV18item.gxTpr_Nusuariosnotificacionnotificado;
               AV19NusuariosNotificacionFecha = DateTimeUtil.ResetTime(AV18item.gxTpr_Nusuariosnotificacionfecha);
               AssignAttri(sPrefix, false, edtavNusuariosnotificacionfecha_Internalname, context.localUtil.Format(AV19NusuariosNotificacionFecha, "99/99/99"));
               AV27NusuariosNotificacionCodigo = AV18item.gxTpr_Nusuariosnotificacioncodigo;
               AV10usuariosNotificacionDescripcion = AV18item.gxTpr_Nusuariosnotificaciondescripcion;
               AssignAttri(sPrefix, false, edtavUsuariosnotificaciondescripcion_Internalname, AV10usuariosNotificacionDescripcion);
               AV21usuariosNotificacionParametros = AV18item.gxTpr_Nusuariosnotificacionparametros;
               AV20usuariosNotificacionObjeto = AV18item.gxTpr_Nusuariosnotificacionobjeto;
               AV23Parametros = StringUtil.Trim( AV21usuariosNotificacionParametros);
               AssignAttri(sPrefix, false, edtavParametros_Internalname, AV23Parametros);
               edtavUsuariosnotificaciondescripcion_Linktarget = context.GetMessage( "_blank", "");
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "centerobject.aspx"+UrlEncode(StringUtil.RTrim(AV20usuariosNotificacionObjeto)) + "," + UrlEncode(StringUtil.RTrim(AV23Parametros));
               edtavUsuariosnotificaciondescripcion_Link = formatLink("centerobject.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               AV16Eliminar = "<i class=\"AttributeColorDanger fas fa-trash-can\"></i>";
               AssignAttri(sPrefix, false, edtavEliminar_Internalname, AV16Eliminar);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 18;
               }
               if ( ( subGridnoti_Islastpage == 1 ) || ( subGridnoti_Rows == 0 ) || ( ( GRIDNOTI_nCurrentRecord >= GRIDNOTI_nFirstRecordOnPage ) && ( GRIDNOTI_nCurrentRecord < GRIDNOTI_nFirstRecordOnPage + subGridnoti_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_182( ) ;
               }
               GRIDNOTI_nEOF = (short)(((subGridnoti_Rows==0)||(GRIDNOTI_nCurrentRecord<GRIDNOTI_nFirstRecordOnPage+subGridnoti_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTI_nEOF), 1, 0, ".", "")));
               GRIDNOTI_nCurrentRecord = (long)(GRIDNOTI_nCurrentRecord+1);
               subGridnoti_Recordcount = (int)(GRIDNOTI_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_18_Refreshing )
               {
                  context.DoAjaxLoad(18, GridnotiRow);
               }
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17Notificaciones", AV17Notificaciones);
         cmbavUsuariosnotificaciontipo.CurrentValue = StringUtil.RTrim( AV9usuariosNotificacionTipo);
      }

      protected void E11B82( )
      {
         /* Gridnotipaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridnotipaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV13GridNotiCurrentPage = (long)(AV13GridNotiCurrentPage-1);
            AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
            subgridnoti_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridnotipaginationbar_Selectedpage, "Next") == 0 )
         {
            AV13GridNotiCurrentPage = (long)(AV13GridNotiCurrentPage+1);
            AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
            subgridnoti_nextpage( ) ;
         }
         else
         {
            AV12PageToGo = (int)(Math.Round(NumberUtil.Val( Gridnotipaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV13GridNotiCurrentPage = AV12PageToGo;
            AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
            subgridnoti_gotopage( AV12PageToGo) ;
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E12B82( )
      {
         /* Gridnotipaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridnoti_Rows = Gridnotipaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDNOTI_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Rows), 6, 0, ".", "")));
         AV13GridNotiCurrentPage = 1;
         AssignAttri(sPrefix, false, "AV13GridNotiCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridNotiCurrentPage), 10, 0));
         subgridnoti_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16B82( )
      {
         /* Eliminar_Click Routine */
         returnInSub = false;
         new eliminarnotificacion(context ).execute(  AV7NusuariosId,  AV9usuariosNotificacionTipo,  AV8usuariosNotificacionCodigo) ;
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S112( )
      {
         /* 'OBTENER NOTIFICACIONES' Routine */
         returnInSub = false;
         cmbavUsuariosnotificaciontipo.Visible = 0;
         AssignProp(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsuariosnotificaciontipo.Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavUsuariosnotificacioncodigo_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuariosnotificacioncodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificacioncodigo_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavNusuariosid_Visible = 0;
         AssignProp(sPrefix, false, edtavNusuariosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNusuariosid_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavUsuariosnotificaciondescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuariosnotificaciondescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuariosnotificaciondescripcion_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         AV17Notificaciones.Clear();
         GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem1 = AV17Notificaciones;
         new onotificaciones(context ).execute(  AV25WWPContext.gxTpr_Usuariosid,  context.GetMessage( "N", ""),  context.GetMessage( "N", ""),  false, out  GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem1) ;
         AV17Notificaciones = GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem1;
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
         PAB82( ) ;
         WSB82( ) ;
         WEB82( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAB82( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "notificacionesold", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAB82( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PAB82( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSB82( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WSB82( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WEB82( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730212161", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("notificacionesold.js", "?2026730212161", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         edtavEliminar_Internalname = sPrefix+"vELIMINAR_"+sGXsfl_18_idx;
         edtavNusuariosid_Internalname = sPrefix+"vNUSUARIOSID_"+sGXsfl_18_idx;
         edtavUsuariosnotificacioncodigo_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONCODIGO_"+sGXsfl_18_idx;
         cmbavUsuariosnotificaciontipo_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONTIPO_"+sGXsfl_18_idx;
         edtavUsuariosnotificaciondescripcion_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONDESCRIPCION_"+sGXsfl_18_idx;
         edtavNusuariosnotificacionfecha_Internalname = sPrefix+"vNUSUARIOSNOTIFICACIONFECHA_"+sGXsfl_18_idx;
         edtavParametros_Internalname = sPrefix+"vPARAMETROS_"+sGXsfl_18_idx;
      }

      protected void SubsflControlProps_fel_182( )
      {
         edtavEliminar_Internalname = sPrefix+"vELIMINAR_"+sGXsfl_18_fel_idx;
         edtavNusuariosid_Internalname = sPrefix+"vNUSUARIOSID_"+sGXsfl_18_fel_idx;
         edtavUsuariosnotificacioncodigo_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONCODIGO_"+sGXsfl_18_fel_idx;
         cmbavUsuariosnotificaciontipo_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONTIPO_"+sGXsfl_18_fel_idx;
         edtavUsuariosnotificaciondescripcion_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONDESCRIPCION_"+sGXsfl_18_fel_idx;
         edtavNusuariosnotificacionfecha_Internalname = sPrefix+"vNUSUARIOSNOTIFICACIONFECHA_"+sGXsfl_18_fel_idx;
         edtavParametros_Internalname = sPrefix+"vPARAMETROS_"+sGXsfl_18_fel_idx;
      }

      protected void sendrow_182( )
      {
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         WBB80( ) ;
         if ( ( subGridnoti_Rows * 1 == 0 ) || ( nGXsfl_18_idx <= subGridnoti_fnc_Recordsperpage( ) * 1 ) )
         {
            GridnotiRow = GXWebRow.GetNew(context,GridnotiContainer);
            if ( subGridnoti_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridnoti_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridnoti_Class, "") != 0 )
               {
                  subGridnoti_Linesclass = subGridnoti_Class+"Odd";
               }
            }
            else if ( subGridnoti_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridnoti_Backstyle = 0;
               subGridnoti_Backcolor = subGridnoti_Allbackcolor;
               if ( StringUtil.StrCmp(subGridnoti_Class, "") != 0 )
               {
                  subGridnoti_Linesclass = subGridnoti_Class+"Uniform";
               }
            }
            else if ( subGridnoti_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridnoti_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridnoti_Class, "") != 0 )
               {
                  subGridnoti_Linesclass = subGridnoti_Class+"Odd";
               }
               subGridnoti_Backcolor = (int)(0x0);
            }
            else if ( subGridnoti_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridnoti_Backstyle = 1;
               if ( ((int)((nGXsfl_18_idx) % (2))) == 0 )
               {
                  subGridnoti_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridnoti_Class, "") != 0 )
                  {
                     subGridnoti_Linesclass = subGridnoti_Class+"Even";
                  }
               }
               else
               {
                  subGridnoti_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridnoti_Class, "") != 0 )
                  {
                     subGridnoti_Linesclass = subGridnoti_Class+"Odd";
                  }
               }
            }
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_18_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridnotiRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEliminar_Internalname,StringUtil.RTrim( AV16Eliminar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVELIMINAR.CLICK."+sGXsfl_18_idx+"'",(string)"",(string)"",context.GetMessage( "Borrar Notificación", ""),(string)"",(string)edtavEliminar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavEliminar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavNusuariosid_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridnotiRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNusuariosid_Internalname,StringUtil.RTrim( AV7NusuariosId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNusuariosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavNusuariosid_Visible,(int)edtavNusuariosid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavUsuariosnotificacioncodigo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridnotiRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsuariosnotificacioncodigo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavUsuariosnotificacioncodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8usuariosNotificacionCodigo), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,21);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsuariosnotificacioncodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavUsuariosnotificacioncodigo_Visible,(int)edtavUsuariosnotificacioncodigo_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbavUsuariosnotificaciontipo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            if ( ( cmbavUsuariosnotificaciontipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vUSUARIOSNOTIFICACIONTIPO_" + sGXsfl_18_idx;
               cmbavUsuariosnotificaciontipo.Name = GXCCtl;
               cmbavUsuariosnotificaciontipo.WebTags = "";
               cmbavUsuariosnotificaciontipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
               cmbavUsuariosnotificaciontipo.addItem("T", context.GetMessage( "Tags", ""), 0);
               cmbavUsuariosnotificaciontipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
               cmbavUsuariosnotificaciontipo.addItem("C", context.GetMessage( "Correo", ""), 0);
               cmbavUsuariosnotificaciontipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
               cmbavUsuariosnotificaciontipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
               if ( cmbavUsuariosnotificaciontipo.ItemCount > 0 )
               {
                  AV9usuariosNotificacionTipo = cmbavUsuariosnotificaciontipo.getValidValue(AV9usuariosNotificacionTipo);
                  AssignAttri(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, AV9usuariosNotificacionTipo);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOSNOTIFICACIONTIPO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV9usuariosNotificacionTipo, "")), context));
               }
            }
            /* ComboBox */
            GridnotiRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavUsuariosnotificaciontipo,(string)cmbavUsuariosnotificaciontipo_Internalname,StringUtil.RTrim( AV9usuariosNotificacionTipo),(short)1,(string)cmbavUsuariosnotificaciontipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbavUsuariosnotificaciontipo.Visible,cmbavUsuariosnotificaciontipo.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"",(string)"",(bool)true,(short)0});
            cmbavUsuariosnotificaciontipo.CurrentValue = StringUtil.RTrim( AV9usuariosNotificacionTipo);
            AssignProp(sPrefix, false, cmbavUsuariosnotificaciontipo_Internalname, "Values", (string)(cmbavUsuariosnotificaciontipo.ToJavascriptSource()), !bGXsfl_18_Refreshing);
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridnotiRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsuariosnotificaciondescripcion_Internalname,StringUtil.RTrim( AV10usuariosNotificacionDescripcion),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUsuariosnotificaciondescripcion_Link,(string)edtavUsuariosnotificaciondescripcion_Linktarget,(string)"",(string)"",(string)edtavUsuariosnotificaciondescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavUsuariosnotificaciondescripcion_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridnotiRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNusuariosnotificacionfecha_Internalname,context.localUtil.Format(AV19NusuariosNotificacionFecha, "99/99/99"),context.localUtil.Format( AV19NusuariosNotificacionFecha, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,24);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNusuariosnotificacionfecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNusuariosnotificacionfecha_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridnotiContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridnotiRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavParametros_Internalname,StringUtil.RTrim( AV23Parametros),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavParametros_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(short)-1,(int)edtavParametros_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesB82( ) ;
            GridnotiContainer.AddRow(GridnotiRow);
            nGXsfl_18_idx = ((subGridnoti_Islastpage==1)&&(nGXsfl_18_idx+1>subGridnoti_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         /* End function sendrow_182 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vUSUARIOSNOTIFICACIONTIPO_" + sGXsfl_18_idx;
         cmbavUsuariosnotificaciontipo.Name = GXCCtl;
         cmbavUsuariosnotificaciontipo.WebTags = "";
         cmbavUsuariosnotificaciontipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
         cmbavUsuariosnotificaciontipo.addItem("T", context.GetMessage( "Tags", ""), 0);
         cmbavUsuariosnotificaciontipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
         cmbavUsuariosnotificaciontipo.addItem("C", context.GetMessage( "Correo", ""), 0);
         cmbavUsuariosnotificaciontipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
         cmbavUsuariosnotificaciontipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
         if ( cmbavUsuariosnotificaciontipo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl18( )
      {
         if ( GridnotiContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridnotiContainer"+"DivS\" data-gxgridid=\"18\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridnoti_Internalname, subGridnoti_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridnoti_Backcolorstyle == 0 )
            {
               subGridnoti_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridnoti_Class) > 0 )
               {
                  subGridnoti_Linesclass = subGridnoti_Class+"Title";
               }
            }
            else
            {
               subGridnoti_Titlebackstyle = 1;
               if ( subGridnoti_Backcolorstyle == 1 )
               {
                  subGridnoti_Titlebackcolor = subGridnoti_Allbackcolor;
                  if ( StringUtil.Len( subGridnoti_Class) > 0 )
                  {
                     subGridnoti_Linesclass = subGridnoti_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridnoti_Class) > 0 )
                  {
                     subGridnoti_Linesclass = subGridnoti_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavNusuariosid_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUsuariosnotificacioncodigo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbavUsuariosnotificaciontipo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridnotiContainer.AddObjectProperty("GridName", "Gridnoti");
         }
         else
         {
            GridnotiContainer.AddObjectProperty("GridName", "Gridnoti");
            GridnotiContainer.AddObjectProperty("Header", subGridnoti_Header);
            GridnotiContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridnotiContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Backcolorstyle), 1, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("CmpContext", sPrefix);
            GridnotiContainer.AddObjectProperty("InMasterPage", "false");
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV16Eliminar)));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEliminar_Enabled), 5, 0, ".", "")));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV7NusuariosId)));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNusuariosid_Enabled), 5, 0, ".", "")));
            GridnotiColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNusuariosid_Visible), 5, 0, ".", "")));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8usuariosNotificacionCodigo), 10, 0, ".", ""))));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosnotificacioncodigo_Enabled), 5, 0, ".", "")));
            GridnotiColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosnotificacioncodigo_Visible), 5, 0, ".", "")));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV9usuariosNotificacionTipo)));
            GridnotiColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsuariosnotificaciontipo.Visible), 5, 0, ".", "")));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsuariosnotificaciontipo.Enabled), 5, 0, ".", "")));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV10usuariosNotificacionDescripcion)));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuariosnotificaciondescripcion_Enabled), 5, 0, ".", "")));
            GridnotiColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUsuariosnotificaciondescripcion_Link));
            GridnotiColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtavUsuariosnotificaciondescripcion_Linktarget));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(AV19NusuariosNotificacionFecha, "99/99/99")));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNusuariosnotificacionfecha_Enabled), 5, 0, ".", "")));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotiColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV23Parametros)));
            GridnotiColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavParametros_Enabled), 5, 0, ".", "")));
            GridnotiContainer.AddColumnProperties(GridnotiColumn);
            GridnotiContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Selectedindex), 4, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Allowselection), 1, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Selectioncolor), 9, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Allowhovering), 1, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Hoveringcolor), 9, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Allowcollapsing), 1, 0, ".", "")));
            GridnotiContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnoti_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavEliminar_Internalname = sPrefix+"vELIMINAR";
         edtavNusuariosid_Internalname = sPrefix+"vNUSUARIOSID";
         edtavUsuariosnotificacioncodigo_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONCODIGO";
         cmbavUsuariosnotificaciontipo_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONTIPO";
         edtavUsuariosnotificaciondescripcion_Internalname = sPrefix+"vUSUARIOSNOTIFICACIONDESCRIPCION";
         edtavNusuariosnotificacionfecha_Internalname = sPrefix+"vNUSUARIOSNOTIFICACIONFECHA";
         edtavParametros_Internalname = sPrefix+"vPARAMETROS";
         Gridnotipaginationbar_Internalname = sPrefix+"GRIDNOTIPAGINATIONBAR";
         divGridnotitablewithpaginationbar_Internalname = sPrefix+"GRIDNOTITABLEWITHPAGINATIONBAR";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavGridnoticurrentpage_Internalname = sPrefix+"vGRIDNOTICURRENTPAGE";
         Gridnoti_empowerer_Internalname = sPrefix+"GRIDNOTI_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridnoti_Internalname = sPrefix+"GRIDNOTI";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGridnoti_Allowcollapsing = 0;
         subGridnoti_Allowselection = 0;
         subGridnoti_Header = "";
         edtavParametros_Jsonclick = "";
         edtavParametros_Enabled = 1;
         edtavNusuariosnotificacionfecha_Jsonclick = "";
         edtavNusuariosnotificacionfecha_Enabled = 1;
         edtavUsuariosnotificaciondescripcion_Jsonclick = "";
         edtavUsuariosnotificaciondescripcion_Linktarget = "";
         edtavUsuariosnotificaciondescripcion_Link = "";
         cmbavUsuariosnotificaciontipo_Jsonclick = "";
         cmbavUsuariosnotificaciontipo.Enabled = 1;
         edtavUsuariosnotificacioncodigo_Jsonclick = "";
         edtavUsuariosnotificacioncodigo_Enabled = 1;
         edtavNusuariosid_Jsonclick = "";
         edtavNusuariosid_Enabled = 1;
         edtavEliminar_Jsonclick = "";
         edtavEliminar_Enabled = 1;
         subGridnoti_Class = "GridWithPaginationBar WorkWith";
         subGridnoti_Backcolorstyle = 0;
         edtavGridnoticurrentpage_Jsonclick = "";
         edtavGridnoticurrentpage_Visible = 1;
         Gridnotipaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridnotipaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridnotipaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridnotipaginationbar_Next = "WWP_PagingNextCaption";
         Gridnotipaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridnotipaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridnotipaginationbar_Rowsperpageselectedvalue = 10;
         Gridnotipaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridnotipaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridnotipaginationbar_Pagingcaptionposition = "Left";
         Gridnotipaginationbar_Pagingbuttonsposition = "Right";
         Gridnotipaginationbar_Pagestoshow = 5;
         Gridnotipaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridnotipaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridnotipaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridnotipaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridnotipaginationbar_Class = "PaginationBar";
         edtavUsuariosnotificaciondescripcion_Enabled = 1;
         edtavNusuariosid_Visible = -1;
         edtavUsuariosnotificacioncodigo_Visible = -1;
         cmbavUsuariosnotificaciontipo.Visible = -1;
         subGridnoti_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDNOTI_nFirstRecordOnPage',type:'int'},{av:'GRIDNOTI_nEOF',type:'int'},{av:'subGridnoti_Rows',ctrl:'GRIDNOTI',prop:'Rows'},{av:'cmbavUsuariosnotificaciontipo'},{av:'edtavUsuariosnotificacioncodigo_Visible',ctrl:'vUSUARIOSNOTIFICACIONCODIGO',prop:'Visible'},{av:'edtavNusuariosid_Visible',ctrl:'vNUSUARIOSID',prop:'Visible'},{av:'edtavUsuariosnotificaciondescripcion_Enabled',ctrl:'vUSUARIOSNOTIFICACIONDESCRIPCION',prop:'Enabled'},{av:'sPrefix',type:'char'},{av:'AV17Notificaciones',fld:'vNOTIFICACIONES',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDNOTI.LOAD","{handler:'E15B82',iparms:[{av:'AV17Notificaciones',fld:'vNOTIFICACIONES',pic:'',hsh:true}]");
         setEventMetadata("GRIDNOTI.LOAD",",oparms:[{av:'AV17Notificaciones',fld:'vNOTIFICACIONES',pic:'',hsh:true},{av:'AV7NusuariosId',fld:'vNUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'cmbavUsuariosnotificaciontipo'},{av:'AV9usuariosNotificacionTipo',fld:'vUSUARIOSNOTIFICACIONTIPO',pic:'',hsh:true,type:'char'},{av:'AV8usuariosNotificacionCodigo',fld:'vUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV19NusuariosNotificacionFecha',fld:'vNUSUARIOSNOTIFICACIONFECHA',pic:'',type:'date'},{av:'AV10usuariosNotificacionDescripcion',fld:'vUSUARIOSNOTIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV23Parametros',fld:'vPARAMETROS',pic:'',type:'char'},{av:'edtavUsuariosnotificaciondescripcion_Linktarget',ctrl:'vUSUARIOSNOTIFICACIONDESCRIPCION',prop:'Linktarget'},{av:'edtavUsuariosnotificaciondescripcion_Link',ctrl:'vUSUARIOSNOTIFICACIONDESCRIPCION',prop:'Link'},{av:'AV16Eliminar',fld:'vELIMINAR',pic:'',type:'char'}]}");
         setEventMetadata("GRIDNOTIPAGINATIONBAR.CHANGEPAGE","{handler:'E11B82',iparms:[{av:'GRIDNOTI_nFirstRecordOnPage',type:'int'},{av:'GRIDNOTI_nEOF',type:'int'},{av:'subGridnoti_Rows',ctrl:'GRIDNOTI',prop:'Rows'},{av:'cmbavUsuariosnotificaciontipo'},{av:'edtavUsuariosnotificacioncodigo_Visible',ctrl:'vUSUARIOSNOTIFICACIONCODIGO',prop:'Visible'},{av:'edtavNusuariosid_Visible',ctrl:'vNUSUARIOSID',prop:'Visible'},{av:'edtavUsuariosnotificaciondescripcion_Enabled',ctrl:'vUSUARIOSNOTIFICACIONDESCRIPCION',prop:'Enabled'},{av:'AV17Notificaciones',fld:'vNOTIFICACIONES',pic:'',hsh:true},{av:'sPrefix',type:'char'},{av:'Gridnotipaginationbar_Selectedpage',ctrl:'GRIDNOTIPAGINATIONBAR',prop:'SelectedPage'},{av:'AV13GridNotiCurrentPage',fld:'vGRIDNOTICURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRIDNOTIPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV13GridNotiCurrentPage',fld:'vGRIDNOTICURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRIDNOTIPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12B82',iparms:[{av:'GRIDNOTI_nFirstRecordOnPage',type:'int'},{av:'GRIDNOTI_nEOF',type:'int'},{av:'subGridnoti_Rows',ctrl:'GRIDNOTI',prop:'Rows'},{av:'cmbavUsuariosnotificaciontipo'},{av:'edtavUsuariosnotificacioncodigo_Visible',ctrl:'vUSUARIOSNOTIFICACIONCODIGO',prop:'Visible'},{av:'edtavNusuariosid_Visible',ctrl:'vNUSUARIOSID',prop:'Visible'},{av:'edtavUsuariosnotificaciondescripcion_Enabled',ctrl:'vUSUARIOSNOTIFICACIONDESCRIPCION',prop:'Enabled'},{av:'AV17Notificaciones',fld:'vNOTIFICACIONES',pic:'',hsh:true},{av:'sPrefix',type:'char'},{av:'Gridnotipaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDNOTIPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDNOTIPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridnoti_Rows',ctrl:'GRIDNOTI',prop:'Rows'},{av:'AV13GridNotiCurrentPage',fld:'vGRIDNOTICURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VELIMINAR.CLICK","{handler:'E16B82',iparms:[{av:'GRIDNOTI_nFirstRecordOnPage',type:'int'},{av:'GRIDNOTI_nEOF',type:'int'},{av:'subGridnoti_Rows',ctrl:'GRIDNOTI',prop:'Rows'},{av:'cmbavUsuariosnotificaciontipo'},{av:'edtavUsuariosnotificacioncodigo_Visible',ctrl:'vUSUARIOSNOTIFICACIONCODIGO',prop:'Visible'},{av:'edtavNusuariosid_Visible',ctrl:'vNUSUARIOSID',prop:'Visible'},{av:'edtavUsuariosnotificaciondescripcion_Enabled',ctrl:'vUSUARIOSNOTIFICACIONDESCRIPCION',prop:'Enabled'},{av:'AV17Notificaciones',fld:'vNOTIFICACIONES',pic:'',hsh:true},{av:'sPrefix',type:'char'},{av:'AV7NusuariosId',fld:'vNUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'AV9usuariosNotificacionTipo',fld:'vUSUARIOSNOTIFICACIONTIPO',pic:'',hsh:true,type:'char'},{av:'AV8usuariosNotificacionCodigo',fld:'vUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VELIMINAR.CLICK",",oparms:[]}");
         setEventMetadata("VALIDV_NUSUARIOSNOTIFICACIONFECHA","{handler:'Validv_Nusuariosnotificacionfecha',iparms:[]");
         setEventMetadata("VALIDV_NUSUARIOSNOTIFICACIONFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Parametros',iparms:[]");
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
         Gridnotipaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17Notificaciones = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV15GridNotiAppliedFilters = "";
         Gridnoti_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridnotiContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridnotipaginationbar = new GXUserControl();
         TempTags = "";
         ucGridnoti_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16Eliminar = "";
         AV7NusuariosId = "";
         AV9usuariosNotificacionTipo = "";
         AV10usuariosNotificacionDescripcion = "";
         AV19NusuariosNotificacionFecha = DateTime.MinValue;
         AV23Parametros = "";
         AV25WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18item = new SdtNotificacionesSDT_NotificacionesSDTItem(context);
         AV22usuariosNotificacionNotificado = "";
         AV21usuariosNotificacionParametros = "";
         AV20usuariosNotificacionObjeto = "";
         GXEncryptionTmp = "";
         GridnotiRow = new GXWebRow();
         GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem1 = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridnoti_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridnotiColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavEliminar_Enabled = 0;
         edtavNusuariosid_Enabled = 0;
         edtavUsuariosnotificacioncodigo_Enabled = 0;
         cmbavUsuariosnotificaciontipo.Enabled = 0;
         edtavUsuariosnotificaciondescripcion_Enabled = 0;
         edtavNusuariosnotificacionfecha_Enabled = 0;
         edtavParametros_Enabled = 0;
      }

      private short GRIDNOTI_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGridnoti_Backcolorstyle ;
      private short subGridnoti_Backstyle ;
      private short subGridnoti_Titlebackstyle ;
      private short subGridnoti_Allowselection ;
      private short subGridnoti_Allowhovering ;
      private short subGridnoti_Allowcollapsing ;
      private short subGridnoti_Collapsed ;
      private int edtavUsuariosnotificacioncodigo_Visible ;
      private int edtavNusuariosid_Visible ;
      private int edtavUsuariosnotificaciondescripcion_Enabled ;
      private int Gridnotipaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_18 ;
      private int subGridnoti_Recordcount ;
      private int subGridnoti_Rows ;
      private int nGXsfl_18_idx=1 ;
      private int edtavEliminar_Enabled ;
      private int edtavNusuariosid_Enabled ;
      private int edtavUsuariosnotificacioncodigo_Enabled ;
      private int edtavNusuariosnotificacionfecha_Enabled ;
      private int edtavParametros_Enabled ;
      private int Gridnotipaginationbar_Pagestoshow ;
      private int edtavGridnoticurrentpage_Visible ;
      private int subGridnoti_Islastpage ;
      private int GRIDNOTI_nGridOutOfScope ;
      private int AV28GXV1 ;
      private int AV12PageToGo ;
      private int idxLst ;
      private int subGridnoti_Backcolor ;
      private int subGridnoti_Allbackcolor ;
      private int subGridnoti_Titlebackcolor ;
      private int subGridnoti_Selectedindex ;
      private int subGridnoti_Selectioncolor ;
      private int subGridnoti_Hoveringcolor ;
      private long GRIDNOTI_nFirstRecordOnPage ;
      private long AV14GridNotiPageCount ;
      private long AV13GridNotiCurrentPage ;
      private long AV8usuariosNotificacionCodigo ;
      private long GRIDNOTI_nCurrentRecord ;
      private long AV27NusuariosNotificacionCodigo ;
      private string Gridnotipaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_18_idx="0001" ;
      private string cmbavUsuariosnotificaciontipo_Internalname ;
      private string edtavUsuariosnotificacioncodigo_Internalname ;
      private string edtavNusuariosid_Internalname ;
      private string edtavUsuariosnotificaciondescripcion_Internalname ;
      private string edtavEliminar_Internalname ;
      private string edtavNusuariosnotificacionfecha_Internalname ;
      private string edtavParametros_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gridnotipaginationbar_Class ;
      private string Gridnotipaginationbar_Pagingbuttonsposition ;
      private string Gridnotipaginationbar_Pagingcaptionposition ;
      private string Gridnotipaginationbar_Emptygridclass ;
      private string Gridnotipaginationbar_Rowsperpageoptions ;
      private string Gridnotipaginationbar_Previous ;
      private string Gridnotipaginationbar_Next ;
      private string Gridnotipaginationbar_Caption ;
      private string Gridnotipaginationbar_Emptygridcaption ;
      private string Gridnotipaginationbar_Rowsperpagecaption ;
      private string Gridnoti_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divGridnotitablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridnoti_Internalname ;
      private string Gridnotipaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavGridnoticurrentpage_Internalname ;
      private string edtavGridnoticurrentpage_Jsonclick ;
      private string Gridnoti_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV16Eliminar ;
      private string AV7NusuariosId ;
      private string AV9usuariosNotificacionTipo ;
      private string AV10usuariosNotificacionDescripcion ;
      private string AV23Parametros ;
      private string AV22usuariosNotificacionNotificado ;
      private string AV21usuariosNotificacionParametros ;
      private string AV20usuariosNotificacionObjeto ;
      private string edtavUsuariosnotificaciondescripcion_Linktarget ;
      private string edtavUsuariosnotificaciondescripcion_Link ;
      private string GXEncryptionTmp ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string subGridnoti_Class ;
      private string subGridnoti_Linesclass ;
      private string ROClassString ;
      private string edtavEliminar_Jsonclick ;
      private string edtavNusuariosid_Jsonclick ;
      private string edtavUsuariosnotificacioncodigo_Jsonclick ;
      private string GXCCtl ;
      private string cmbavUsuariosnotificaciontipo_Jsonclick ;
      private string edtavUsuariosnotificaciondescripcion_Jsonclick ;
      private string edtavNusuariosnotificacionfecha_Jsonclick ;
      private string edtavParametros_Jsonclick ;
      private string subGridnoti_Header ;
      private DateTime AV19NusuariosNotificacionFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool Gridnotipaginationbar_Showfirst ;
      private bool Gridnotipaginationbar_Showprevious ;
      private bool Gridnotipaginationbar_Shownext ;
      private bool Gridnotipaginationbar_Showlast ;
      private bool Gridnotipaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15GridNotiAppliedFilters ;
      private GXWebGrid GridnotiContainer ;
      private GXWebRow GridnotiRow ;
      private GXWebColumn GridnotiColumn ;
      private GXUserControl ucGridnotipaginationbar ;
      private GXUserControl ucGridnoti_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsuariosnotificaciontipo ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> AV17Notificaciones ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV25WWPContext ;
      private SdtNotificacionesSDT_NotificacionesSDTItem AV18item ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}

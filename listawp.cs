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
   public class listawp : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public listawp( )
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

      public listawp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_ProveedorID )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         ExecutePrivate();
         aP0_ProveedorID=this.AV10ProveedorID;
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
         dynavListaid = new GXCombobox();
         cmbavEstado = new GXCombobox();
         cmbListaTipo = new GXCombobox();
         cmbAgrupacionEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProveedorID");
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
                  AV10ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV10ProveedorID", StringUtil.LTrimStr( (decimal)(AV10ProveedorID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV10ProveedorID});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLISTAID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvLISTAIDBU2( ) ;
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
                  gxfirstwebparm = GetFirstPar( "ProveedorID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProveedorID");
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_26 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_26"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_26_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_26_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_26_idx = GetPar( "sGXsfl_26_idx");
         sPrefix = GetPar( "sPrefix");
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
         dynavListaid.FromJSonString( GetNextPar( ));
         AV9ListaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaId"), "."), 18, MidpointRounding.ToEven));
         cmbavEstado.FromJSonString( GetNextPar( ));
         AV8Estado = GetPar( "Estado");
         AV10ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV14IsAuthorized_ProfesionalesPrimerNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ProfesionalesPrimerNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV9ListaId, AV8Estado, AV10ProveedorID, AV14IsAuthorized_ProfesionalesPrimerNombre, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            PABU2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavEditar_Enabled = 0;
               AssignProp(sPrefix, false, edtavEditar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEditar_Enabled), 5, 0), !bGXsfl_26_Refreshing);
               GXVvLISTAID_htmlBU2( ) ;
               WSBU2( ) ;
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
            context.SendWebValue( context.GetMessage( "Lista WP", "")) ;
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
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "listawp.aspx"+UrlEncode(StringUtil.LTrimStr(AV10ProveedorID,18,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listawp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV14IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_ProfesionalesPrimerNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vESTADO", StringUtil.RTrim( AV8Estado));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Grid1PageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID1APPLIEDFILTERS", AV19Grid1AppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV10ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV14IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_ProfesionalesPrimerNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROFESIONALESID", StringUtil.RTrim( AV20ProfesionalesId));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Class", StringUtil.RTrim( Grid1paginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Grid1paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Grid1paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Grid1paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Grid1paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Grid1paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Grid1paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Grid1paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Grid1paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Grid1paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Previous", StringUtil.RTrim( Grid1paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Next", StringUtil.RTrim( Grid1paginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Caption", StringUtil.RTrim( Grid1paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Grid1paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Grid1paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormBU2( )
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
         return "ListaWP" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista WP", "") ;
      }

      protected void WBBU0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "listawp.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavListaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavListaid_Internalname, context.GetMessage( "Lista", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'" + sPrefix + "',false,'" + sGXsfl_26_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavListaid, dynavListaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9ListaId), 18, 0)), 1, dynavListaid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavListaid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_ListaWP.htm");
            dynavListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ListaId), 18, 0));
            AssignProp(sPrefix, false, dynavListaid_Internalname, "Values", (string)(dynavListaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagregar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(26), 2, 0)+","+"null"+");", context.GetMessage( "Agregar a la Lista", ""), bttBtnagregar_Jsonclick, 5, context.GetMessage( "Agregar a la Lista", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOAGREGAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_26_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEstado, cmbavEstado_Internalname, StringUtil.RTrim( AV8Estado), 1, cmbavEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_ListaWP.htm");
            cmbavEstado.CurrentValue = StringUtil.RTrim( AV8Estado);
            AssignProp(sPrefix, false, cmbavEstado_Internalname, "Values", (string)(cmbavEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl26( ) ;
         }
         if ( wbEnd == 26 )
         {
            wbEnd = 0;
            nRC_GXsfl_26 = (int)(nGXsfl_26_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
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
            ucGrid1paginationbar.SetProperty("CurrentPage", AV17Grid1CurrentPage);
            ucGrid1paginationbar.SetProperty("PageCount", AV18Grid1PageCount);
            ucGrid1paginationbar.SetProperty("AppliedFilters", AV19Grid1AppliedFilters);
            ucGrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Grid1paginationbar_Internalname, sPrefix+"GRID1PAGINATIONBARContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_26_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Grid1CurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Grid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ListaWP.htm");
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, sPrefix+"GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 26 )
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
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBU2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Lista WP", ""), 0) ;
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
               STRUPBU0( ) ;
            }
         }
      }

      protected void WSBU2( )
      {
         STARTBU2( ) ;
         EVTBU2( ) ;
      }

      protected void EVTBU2( )
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
                                 STRUPBU0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1paginationbar.Changepage */
                                    E11BU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1paginationbar.Changerowsperpage */
                                    E12BU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOAGREGAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAgregar' */
                                    E13BU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavEditar_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEDITAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEDITAR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBU0( ) ;
                              }
                              nGXsfl_26_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
                              SubsflControlProps_262( ) ;
                              A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbListaTipo.Name = cmbListaTipo_Internalname;
                              cmbListaTipo.CurrentValue = cgiGet( cmbListaTipo_Internalname);
                              A591ListaTipo = cgiGet( cmbListaTipo_Internalname);
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A589AgrupacionMotivo = cgiGet( edtAgrupacionMotivo_Internalname);
                              cmbAgrupacionEstado.Name = cmbAgrupacionEstado_Internalname;
                              cmbAgrupacionEstado.CurrentValue = cgiGet( cmbAgrupacionEstado_Internalname);
                              A588AgrupacionEstado = cgiGet( cmbAgrupacionEstado_Internalname);
                              AV7Editar = cgiGet( edtavEditar_Internalname);
                              AssignAttri(sPrefix, false, edtavEditar_Internalname, AV7Editar);
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
                                          GX_FocusControl = edtavEditar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E14BU2 ();
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
                                          GX_FocusControl = edtavEditar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E15BU2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEditar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid1.Load */
                                          E16BU2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEDITAR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEditar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17BU2 ();
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
                                             /* Set Refresh If Listaid Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vLISTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9ListaId )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Estado Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vESTADO"), AV8Estado) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUPBU0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavEditar_Internalname;
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

      protected void WEBU2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBU2( ) ;
            }
         }
      }

      protected void PABU2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listawp.aspx")), "listawp.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listawp.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusDescription = 403.ToString();
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "ProveedorID");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
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
               GX_FocusControl = dynavListaid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLISTAIDBU2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLISTAID_dataBU2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLISTAID_htmlBU2( )
      {
         long gxdynajaxvalue;
         GXDLVvLISTAID_dataBU2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavListaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavListaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavListaid.ItemCount > 0 )
         {
            AV9ListaId = (long)(Math.Round(NumberUtil.Val( dynavListaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9ListaId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9ListaId", StringUtil.LTrimStr( (decimal)(AV9ListaId), 18, 0));
         }
      }

      protected void GXDLVvLISTAID_dataBU2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00BU2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00BU2_A590Listaid[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00BU2_A592ListaNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_262( ) ;
         while ( nGXsfl_26_idx <= nRC_GXsfl_26 )
         {
            sendrow_262( ) ;
            nGXsfl_26_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV9ListaId ,
                                        string AV8Estado ,
                                        long AV10ProveedorID ,
                                        bool AV14IsAuthorized_ProfesionalesPrimerNombre ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFBU2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLISTAID_htmlBU2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavListaid.ItemCount > 0 )
         {
            AV9ListaId = (long)(Math.Round(NumberUtil.Val( dynavListaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9ListaId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9ListaId", StringUtil.LTrimStr( (decimal)(AV9ListaId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ListaId), 18, 0));
            AssignProp(sPrefix, false, dynavListaid_Internalname, "Values", dynavListaid.ToJavascriptSource(), true);
         }
         if ( cmbavEstado.ItemCount > 0 )
         {
            AV8Estado = cmbavEstado.getValidValue(AV8Estado);
            AssignAttri(sPrefix, false, "AV8Estado", AV8Estado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEstado.CurrentValue = StringUtil.RTrim( AV8Estado);
            AssignProp(sPrefix, false, cmbavEstado_Internalname, "Values", cmbavEstado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBU2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavEditar_Enabled = 0;
      }

      protected void RFBU2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E15BU2 ();
         nGXsfl_26_idx = 1;
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         bGXsfl_26_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_262( ) ;
            GXPagingFrom2 = (int)(((subGrid1_Rows==0) ? 0 : GRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid1_Rows==0) ? 10000 : subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV8Estado ,
                                                 A588AgrupacionEstado ,
                                                 A591ListaTipo ,
                                                 AV9ListaId ,
                                                 AV10ProveedorID ,
                                                 A590Listaid ,
                                                 A133ProveedorID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H00BU3 */
            pr_default.execute(1, new Object[] {AV9ListaId, AV10ProveedorID, AV8Estado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_26_idx = 1;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A588AgrupacionEstado = H00BU3_A588AgrupacionEstado[0];
               A589AgrupacionMotivo = H00BU3_A589AgrupacionMotivo[0];
               A192ProfesionalesApellidoSegundo = H00BU3_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00BU3_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00BU3_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00BU3_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H00BU3_A120ProfesionalesId[0];
               A133ProveedorID = H00BU3_A133ProveedorID[0];
               A591ListaTipo = H00BU3_A591ListaTipo[0];
               A590Listaid = H00BU3_A590Listaid[0];
               A192ProfesionalesApellidoSegundo = H00BU3_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00BU3_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00BU3_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00BU3_A166ProfesionalesPrimerNombre[0];
               A591ListaTipo = H00BU3_A591ListaTipo[0];
               /* Execute user event: Grid1.Load */
               E16BU2 ();
               pr_default.readNext(1);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 26;
            WBBU0( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBU2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV14IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_ProfesionalesPrimerNombre, context));
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
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV8Estado ,
                                              A588AgrupacionEstado ,
                                              A591ListaTipo ,
                                              AV9ListaId ,
                                              AV10ProveedorID ,
                                              A590Listaid ,
                                              A133ProveedorID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00BU4 */
         pr_default.execute(2, new Object[] {AV9ListaId, AV10ProveedorID, AV8Estado});
         GRID1_nRecordCount = H00BU4_AGRID1_nRecordCount[0];
         pr_default.close(2);
         return (int)(GRID1_nRecordCount) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV9ListaId, AV8Estado, AV10ProveedorID, AV14IsAuthorized_ProfesionalesPrimerNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV9ListaId, AV8Estado, AV10ProveedorID, AV14IsAuthorized_ProfesionalesPrimerNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV9ListaId, AV8Estado, AV10ProveedorID, AV14IsAuthorized_ProfesionalesPrimerNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV9ListaId, AV8Estado, AV10ProveedorID, AV14IsAuthorized_ProfesionalesPrimerNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV9ListaId, AV8Estado, AV10ProveedorID, AV14IsAuthorized_ProfesionalesPrimerNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavEditar_Enabled = 0;
         GXVvLISTAID_htmlBU2( ) ;
         edtListaid_Enabled = 0;
         cmbListaTipo.Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtAgrupacionMotivo_Enabled = 0;
         cmbAgrupacionEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBU0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14BU2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_26"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV18Grid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRID1PAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV18Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV18Grid1PageCount), 10, 0));
            AV19Grid1AppliedFilters = cgiGet( sPrefix+"vGRID1APPLIEDFILTERS");
            wcpOAV10ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Grid1paginationbar_Class = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Class");
            Grid1paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Showfirst"));
            Grid1paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Showprevious"));
            Grid1paginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Shownext"));
            Grid1paginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Showlast"));
            Grid1paginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Pagingbuttonsposition");
            Grid1paginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Pagingcaptionposition");
            Grid1paginationbar_Emptygridclass = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Emptygridclass");
            Grid1paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselector"));
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Rowsperpageoptions");
            Grid1paginationbar_Previous = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Previous");
            Grid1paginationbar_Next = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Next");
            Grid1paginationbar_Caption = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Caption");
            Grid1paginationbar_Emptygridcaption = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Emptygridcaption");
            Grid1paginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Rowsperpagecaption");
            Grid1_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID1_EMPOWERER_Gridinternalname");
            Grid1paginationbar_Selectedpage = cgiGet( sPrefix+"GRID1PAGINATIONBAR_Selectedpage");
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            dynavListaid.Name = dynavListaid_Internalname;
            dynavListaid.CurrentValue = cgiGet( dynavListaid_Internalname);
            AV9ListaId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavListaid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9ListaId", StringUtil.LTrimStr( (decimal)(AV9ListaId), 18, 0));
            cmbavEstado.Name = cmbavEstado_Internalname;
            cmbavEstado.CurrentValue = cgiGet( cmbavEstado_Internalname);
            AV8Estado = cgiGet( cmbavEstado_Internalname);
            AssignAttri(sPrefix, false, "AV8Estado", AV8Estado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRID1CURRENTPAGE");
               GX_FocusControl = edtavGrid1currentpage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17Grid1CurrentPage = 0;
               AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
            }
            else
            {
               AV17Grid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vLISTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9ListaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vESTADO"), AV8Estado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E14BU2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14BU2( )
      {
         /* Start Routine */
         returnInSub = false;
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, sPrefix, false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV17Grid1CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
         edtavGrid1currentpage_Visible = 0;
         AssignProp(sPrefix, false, edtavGrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGrid1currentpage_Visible), 5, 0), true);
         AV18Grid1PageCount = -1;
         AssignAttri(sPrefix, false, "AV18Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV18Grid1PageCount), 10, 0));
         GXt_boolean1 = AV14IsAuthorized_ProfesionalesPrimerNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV14IsAuthorized_ProfesionalesPrimerNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV14IsAuthorized_ProfesionalesPrimerNombre", AV14IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_ProfesionalesPrimerNombre, context));
         Grid1paginationbar_Rowsperpageselectedvalue = subGrid1_Rows;
         ucGrid1paginationbar.SendProperty(context, sPrefix, false, Grid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E15BU2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         edtProfesionalesPrimerNombre_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtProfesionalesPrimerNombre_Internalname, "Columnheaderclass", edtProfesionalesPrimerNombre_Columnheaderclass, !bGXsfl_26_Refreshing);
         edtProfesionalesSegundoNombre_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtProfesionalesSegundoNombre_Internalname, "Columnheaderclass", edtProfesionalesSegundoNombre_Columnheaderclass, !bGXsfl_26_Refreshing);
         edtProfesionalesApellidoPrimero_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtProfesionalesApellidoPrimero_Internalname, "Columnheaderclass", edtProfesionalesApellidoPrimero_Columnheaderclass, !bGXsfl_26_Refreshing);
         edtProfesionalesApellidoSegundo_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtProfesionalesApellidoSegundo_Internalname, "Columnheaderclass", edtProfesionalesApellidoSegundo_Columnheaderclass, !bGXsfl_26_Refreshing);
         edtAgrupacionMotivo_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, edtAgrupacionMotivo_Internalname, "Columnheaderclass", edtAgrupacionMotivo_Columnheaderclass, !bGXsfl_26_Refreshing);
         cmbAgrupacionEstado_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbAgrupacionEstado_Internalname, "Columnheaderclass", cmbAgrupacionEstado_Columnheaderclass, !bGXsfl_26_Refreshing);
         edtavEditar_Columnheaderclass = "WWIconActionColumn";
         AssignProp(sPrefix, false, edtavEditar_Internalname, "Columnheaderclass", edtavEditar_Columnheaderclass, !bGXsfl_26_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E16BU2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV7Editar = "<i class=\"fas fa-pen-to-square\"></i>";
         AssignAttri(sPrefix, false, edtavEditar_Internalname, AV7Editar);
         if ( AV14IsAuthorized_ProfesionalesPrimerNombre )
         {
            edtProfesionalesPrimerNombre_Link = formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) ;
         }
         if ( StringUtil.StrCmp(A588AgrupacionEstado, "PEN") == 0 )
         {
            edtProfesionalesPrimerNombre_Columnclass = "WWColumn WWColumnWarning WWColumnWarningFirstColumn";
            edtProfesionalesSegundoNombre_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesApellidoPrimero_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesApellidoSegundo_Columnclass = "WWColumn WWColumnWarning";
            edtAgrupacionMotivo_Columnclass = "WWColumn WWColumnWarning";
            cmbAgrupacionEstado_Columnclass = "WWColumn WWColumnWarning";
            edtavEditar_Columnclass = "WWIconActionColumn WWColumnWarning";
         }
         else if ( StringUtil.StrCmp(A588AgrupacionEstado, "VIN") == 0 )
         {
            edtProfesionalesPrimerNombre_Columnclass = "WWColumn WWColumnDanger WWColumnDangerFirstColumn";
            edtProfesionalesSegundoNombre_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesApellidoPrimero_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesApellidoSegundo_Columnclass = "WWColumn WWColumnDanger";
            edtAgrupacionMotivo_Columnclass = "WWColumn WWColumnDanger";
            cmbAgrupacionEstado_Columnclass = "WWColumn WWColumnDanger";
            edtavEditar_Columnclass = "WWIconActionColumn WWColumnDanger";
         }
         else
         {
            edtProfesionalesPrimerNombre_Columnclass = "WWColumn";
            edtProfesionalesSegundoNombre_Columnclass = "WWColumn";
            edtProfesionalesApellidoPrimero_Columnclass = "WWColumn";
            edtProfesionalesApellidoSegundo_Columnclass = "WWColumn";
            edtAgrupacionMotivo_Columnclass = "WWColumn";
            cmbAgrupacionEstado_Columnclass = "WWColumn";
            edtavEditar_Columnclass = "WWIconActionColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 26;
         }
         sendrow_262( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_26_Refreshing )
         {
            context.DoAjaxLoad(26, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E11BU2( )
      {
         /* Grid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV17Grid1CurrentPage = (long)(AV17Grid1CurrentPage-1);
            AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
            subgrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV17Grid1CurrentPage = (long)(AV17Grid1CurrentPage+1);
            AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
            subgrid1_nextpage( ) ;
         }
         else
         {
            AV16PageToGo = (int)(Math.Round(NumberUtil.Val( Grid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV17Grid1CurrentPage = AV16PageToGo;
            AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
            subgrid1_gotopage( AV16PageToGo) ;
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E12BU2( )
      {
         /* Grid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid1_Rows = Grid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV17Grid1CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV17Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV17Grid1CurrentPage), 10, 0));
         subgrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13BU2( )
      {
         /* 'DoAgregar' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "promptprofesionaleslista.aspx"+UrlEncode(StringUtil.LTrimStr(AV9ListaId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV20ProfesionalesId));
         context.PopUp(formatLink("promptprofesionaleslista.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV9ListaId","AV10ProveedorID","AV20ProfesionalesId"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         dynavListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ListaId), 18, 0));
         AssignProp(sPrefix, false, dynavListaid_Internalname, "Values", dynavListaid.ToJavascriptSource(), true);
      }

      protected void E17BU2( )
      {
         /* Editar_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "listaagrupacionwp.aspx"+UrlEncode(StringUtil.LTrimStr(A590Listaid,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(A588AgrupacionEstado));
         context.PopUp(formatLink("listaagrupacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"A590Listaid","A133ProveedorID","A120ProfesionalesId","A588AgrupacionEstado"});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         cmbAgrupacionEstado.CurrentValue = StringUtil.RTrim( A588AgrupacionEstado);
         AssignProp(sPrefix, false, cmbAgrupacionEstado_Internalname, "Values", cmbAgrupacionEstado.ToJavascriptSource(), true);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10ProveedorID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV10ProveedorID", StringUtil.LTrimStr( (decimal)(AV10ProveedorID), 18, 0));
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
         PABU2( ) ;
         WSBU2( ) ;
         WEBU2( ) ;
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
         sCtrlAV10ProveedorID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABU2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "listawp", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABU2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV10ProveedorID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV10ProveedorID", StringUtil.LTrimStr( (decimal)(AV10ProveedorID), 18, 0));
         }
         wcpOAV10ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV10ProveedorID != wcpOAV10ProveedorID ) ) )
         {
            setjustcreated();
         }
         wcpOAV10ProveedorID = AV10ProveedorID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV10ProveedorID = cgiGet( sPrefix+"AV10ProveedorID_CTRL");
         if ( StringUtil.Len( sCtrlAV10ProveedorID) > 0 )
         {
            AV10ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV10ProveedorID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV10ProveedorID", StringUtil.LTrimStr( (decimal)(AV10ProveedorID), 18, 0));
         }
         else
         {
            AV10ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV10ProveedorID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
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
         PABU2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBU2( ) ;
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
         WSBU2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10ProveedorID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10ProveedorID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10ProveedorID_CTRL", StringUtil.RTrim( sCtrlAV10ProveedorID));
         }
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
         WEBU2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319515359", true, true, false);
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
            context.AddJavascriptSource("listawp.js", "?20269319515359", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_262( )
      {
         edtListaid_Internalname = sPrefix+"LISTAID_"+sGXsfl_26_idx;
         cmbListaTipo_Internalname = sPrefix+"LISTATIPO_"+sGXsfl_26_idx;
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID_"+sGXsfl_26_idx;
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_26_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_26_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_26_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_26_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_26_idx;
         edtAgrupacionMotivo_Internalname = sPrefix+"AGRUPACIONMOTIVO_"+sGXsfl_26_idx;
         cmbAgrupacionEstado_Internalname = sPrefix+"AGRUPACIONESTADO_"+sGXsfl_26_idx;
         edtavEditar_Internalname = sPrefix+"vEDITAR_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         edtListaid_Internalname = sPrefix+"LISTAID_"+sGXsfl_26_fel_idx;
         cmbListaTipo_Internalname = sPrefix+"LISTATIPO_"+sGXsfl_26_fel_idx;
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID_"+sGXsfl_26_fel_idx;
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_26_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_26_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_26_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_26_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_26_fel_idx;
         edtAgrupacionMotivo_Internalname = sPrefix+"AGRUPACIONMOTIVO_"+sGXsfl_26_fel_idx;
         cmbAgrupacionEstado_Internalname = sPrefix+"AGRUPACIONESTADO_"+sGXsfl_26_fel_idx;
         edtavEditar_Internalname = sPrefix+"vEDITAR_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WBBU0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_26_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_26_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_26_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "LISTATIPO_" + sGXsfl_26_idx;
            cmbListaTipo.Name = GXCCtl;
            cmbListaTipo.WebTags = "";
            cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
            cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
            cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
            cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
            if ( cmbListaTipo.ItemCount > 0 )
            {
               A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbListaTipo,(string)cmbListaTipo_Internalname,StringUtil.RTrim( A591ListaTipo),(short)1,(string)cmbListaTipo_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp(sPrefix, false, cmbListaTipo_Internalname, "Values", (string)(cmbListaTipo.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtProfesionalesPrimerNombre_Link,(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesPrimerNombre_Columnclass,(string)edtProfesionalesPrimerNombre_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesSegundoNombre_Columnclass,(string)edtProfesionalesSegundoNombre_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesApellidoPrimero_Columnclass,(string)edtProfesionalesApellidoPrimero_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesApellidoSegundo_Columnclass,(string)edtProfesionalesApellidoSegundo_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgrupacionMotivo_Internalname,(string)A589AgrupacionMotivo,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgrupacionMotivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtAgrupacionMotivo_Columnclass,(string)edtAgrupacionMotivo_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAgrupacionEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_26_idx;
               cmbAgrupacionEstado.Name = GXCCtl;
               cmbAgrupacionEstado.WebTags = "";
               cmbAgrupacionEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
               cmbAgrupacionEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
               cmbAgrupacionEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
               if ( cmbAgrupacionEstado.ItemCount > 0 )
               {
                  A588AgrupacionEstado = cmbAgrupacionEstado.getValidValue(A588AgrupacionEstado);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAgrupacionEstado,(string)cmbAgrupacionEstado_Internalname,StringUtil.RTrim( A588AgrupacionEstado),(short)1,(string)cmbAgrupacionEstado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbAgrupacionEstado_Columnclass,(string)cmbAgrupacionEstado_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbAgrupacionEstado.CurrentValue = StringUtil.RTrim( A588AgrupacionEstado);
            AssignProp(sPrefix, false, cmbAgrupacionEstado_Internalname, "Values", (string)(cmbAgrupacionEstado.ToJavascriptSource()), !bGXsfl_26_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_26_idx + "',26)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEditar_Internalname,StringUtil.RTrim( AV7Editar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVEDITAR.CLICK."+sGXsfl_26_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEditar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavEditar_Columnclass,(string)edtavEditar_Columnheaderclass,(short)-1,(int)edtavEditar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesBU2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_26_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         dynavListaid.Name = "vLISTAID";
         dynavListaid.WebTags = "";
         cmbavEstado.Name = "vESTADO";
         cmbavEstado.WebTags = "";
         cmbavEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
         cmbavEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
         cmbavEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
         if ( cmbavEstado.ItemCount > 0 )
         {
         }
         GXCCtl = "LISTATIPO_" + sGXsfl_26_idx;
         cmbListaTipo.Name = GXCCtl;
         cmbListaTipo.WebTags = "";
         cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
         cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
         cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
         cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
         if ( cmbListaTipo.ItemCount > 0 )
         {
         }
         GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_26_idx;
         cmbAgrupacionEstado.Name = GXCCtl;
         cmbAgrupacionEstado.WebTags = "";
         cmbAgrupacionEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
         cmbAgrupacionEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
         cmbAgrupacionEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
         if ( cmbAgrupacionEstado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl26( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"DivS\" data-gxgridid=\"26\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Listaid", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Lista Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código del Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", sPrefix);
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A591ListaTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesPrimerNombre_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesPrimerNombre_Columnheaderclass));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtProfesionalesPrimerNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesSegundoNombre_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesSegundoNombre_Columnheaderclass));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesApellidoPrimero_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesApellidoPrimero_Columnheaderclass));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesApellidoSegundo_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesApellidoSegundo_Columnheaderclass));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A589AgrupacionMotivo));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtAgrupacionMotivo_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtAgrupacionMotivo_Columnheaderclass));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A588AgrupacionEstado)));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbAgrupacionEstado_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbAgrupacionEstado_Columnheaderclass));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV7Editar)));
            Grid1Column.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavEditar_Columnclass));
            Grid1Column.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavEditar_Columnheaderclass));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEditar_Enabled), 5, 0, ".", "")));
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

      protected void init_default_properties( )
      {
         dynavListaid_Internalname = sPrefix+"vLISTAID";
         bttBtnagregar_Internalname = sPrefix+"BTNAGREGAR";
         cmbavEstado_Internalname = sPrefix+"vESTADO";
         edtListaid_Internalname = sPrefix+"LISTAID";
         cmbListaTipo_Internalname = sPrefix+"LISTATIPO";
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID";
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO";
         edtAgrupacionMotivo_Internalname = sPrefix+"AGRUPACIONMOTIVO";
         cmbAgrupacionEstado_Internalname = sPrefix+"AGRUPACIONESTADO";
         edtavEditar_Internalname = sPrefix+"vEDITAR";
         Grid1paginationbar_Internalname = sPrefix+"GRID1PAGINATIONBAR";
         divGrid1tablewithpaginationbar_Internalname = sPrefix+"GRID1TABLEWITHPAGINATIONBAR";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         edtavGrid1currentpage_Internalname = sPrefix+"vGRID1CURRENTPAGE";
         Grid1_empowerer_Internalname = sPrefix+"GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid1_Internalname = sPrefix+"GRID1";
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
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavEditar_Jsonclick = "";
         edtavEditar_Columnclass = "WWIconActionColumn";
         edtavEditar_Enabled = 1;
         cmbAgrupacionEstado_Jsonclick = "";
         cmbAgrupacionEstado_Columnclass = "WWColumn";
         edtAgrupacionMotivo_Jsonclick = "";
         edtAgrupacionMotivo_Columnclass = "WWColumn";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Columnclass = "WWColumn";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Columnclass = "WWColumn";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Columnclass = "WWColumn";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Columnclass = "WWColumn";
         edtProfesionalesPrimerNombre_Link = "";
         edtProfesionalesId_Jsonclick = "";
         edtProveedorID_Jsonclick = "";
         cmbListaTipo_Jsonclick = "";
         edtListaid_Jsonclick = "";
         subGrid1_Class = "GridWithPaginationBar WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavEditar_Columnheaderclass = "";
         cmbAgrupacionEstado_Columnheaderclass = "";
         edtAgrupacionMotivo_Columnheaderclass = "";
         edtProfesionalesApellidoSegundo_Columnheaderclass = "";
         edtProfesionalesApellidoPrimero_Columnheaderclass = "";
         edtProfesionalesSegundoNombre_Columnheaderclass = "";
         edtProfesionalesPrimerNombre_Columnheaderclass = "";
         cmbAgrupacionEstado.Enabled = 0;
         edtAgrupacionMotivo_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         cmbListaTipo.Enabled = 0;
         edtListaid_Enabled = 0;
         edtavGrid1currentpage_Jsonclick = "";
         edtavGrid1currentpage_Visible = 1;
         cmbavEstado_Jsonclick = "";
         cmbavEstado.Enabled = 1;
         dynavListaid_Jsonclick = "";
         dynavListaid.Enabled = 1;
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
         subGrid1_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavEstado'},{av:'AV8Estado',fld:'vESTADO',pic:'',type:'char'},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'sPrefix',type:'char'},{av:'dynavListaid'},{av:'AV9ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtAgrupacionMotivo_Columnheaderclass',ctrl:'AGRUPACIONMOTIVO',prop:'Columnheaderclass'},{av:'cmbAgrupacionEstado'},{av:'edtavEditar_Columnheaderclass',ctrl:'vEDITAR',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID1.LOAD","{handler:'E16BU2',iparms:[{av:'AV14IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'cmbAgrupacionEstado'},{av:'A588AgrupacionEstado',fld:'AGRUPACIONESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV7Editar',fld:'vEDITAR',pic:'',type:'char'},{av:'edtProfesionalesPrimerNombre_Link',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Link'},{av:'edtProfesionalesPrimerNombre_Columnclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnclass'},{av:'edtProfesionalesSegundoNombre_Columnclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnclass'},{av:'edtProfesionalesApellidoPrimero_Columnclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnclass'},{av:'edtProfesionalesApellidoSegundo_Columnclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnclass'},{av:'edtAgrupacionMotivo_Columnclass',ctrl:'AGRUPACIONMOTIVO',prop:'Columnclass'},{av:'cmbAgrupacionEstado'},{av:'edtavEditar_Columnclass',ctrl:'vEDITAR',prop:'Columnclass'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE","{handler:'E11BU2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavListaid'},{av:'AV9ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavEstado'},{av:'AV8Estado',fld:'vESTADO',pic:'',type:'char'},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Grid1paginationbar_Selectedpage',ctrl:'GRID1PAGINATIONBAR',prop:'SelectedPage'},{av:'AV17Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV17Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtAgrupacionMotivo_Columnheaderclass',ctrl:'AGRUPACIONMOTIVO',prop:'Columnheaderclass'},{av:'cmbAgrupacionEstado'},{av:'edtavEditar_Columnheaderclass',ctrl:'vEDITAR',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12BU2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavListaid'},{av:'AV9ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavEstado'},{av:'AV8Estado',fld:'vESTADO',pic:'',type:'char'},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Grid1paginationbar_Rowsperpageselectedvalue',ctrl:'GRID1PAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV17Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOAGREGAR'","{handler:'E13BU2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavListaid'},{av:'AV9ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavEstado'},{av:'AV8Estado',fld:'vESTADO',pic:'',type:'char'},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'AV20ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("'DOAGREGAR'",",oparms:[{av:'AV20ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynavListaid'},{av:'AV9ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtAgrupacionMotivo_Columnheaderclass',ctrl:'AGRUPACIONMOTIVO',prop:'Columnheaderclass'},{av:'cmbAgrupacionEstado'},{av:'edtavEditar_Columnheaderclass',ctrl:'vEDITAR',prop:'Columnheaderclass'}]}");
         setEventMetadata("VEDITAR.CLICK","{handler:'E17BU2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'dynavListaid'},{av:'AV9ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavEstado'},{av:'AV8Estado',fld:'vESTADO',pic:'',type:'char'},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'cmbAgrupacionEstado'},{av:'A588AgrupacionEstado',fld:'AGRUPACIONESTADO',pic:'',type:'char'}]");
         setEventMetadata("VEDITAR.CLICK",",oparms:[{av:'cmbAgrupacionEstado'},{av:'A588AgrupacionEstado',fld:'AGRUPACIONESTADO',pic:'',type:'char'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtAgrupacionMotivo_Columnheaderclass',ctrl:'AGRUPACIONMOTIVO',prop:'Columnheaderclass'},{av:'edtavEditar_Columnheaderclass',ctrl:'vEDITAR',prop:'Columnheaderclass'}]}");
         setEventMetadata("VALIDV_LISTAID","{handler:'Validv_Listaid',iparms:[]");
         setEventMetadata("VALIDV_LISTAID",",oparms:[]}");
         setEventMetadata("VALIDV_ESTADO","{handler:'Validv_Estado',iparms:[]");
         setEventMetadata("VALIDV_ESTADO",",oparms:[]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[]");
         setEventMetadata("VALID_LISTAID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Editar',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV8Estado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV19Grid1AppliedFilters = "";
         AV20ProfesionalesId = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagregar_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucGrid1paginationbar = new GXUserControl();
         ucGrid1_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A591ListaTipo = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A589AgrupacionMotivo = "";
         A588AgrupacionEstado = "";
         AV7Editar = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00BU2_A590Listaid = new long[1] ;
         H00BU2_A592ListaNombre = new string[] {""} ;
         H00BU2_A593ListaEstado = new string[] {""} ;
         H00BU2_n593ListaEstado = new bool[] {false} ;
         H00BU2_A591ListaTipo = new string[] {""} ;
         H00BU3_A588AgrupacionEstado = new string[] {""} ;
         H00BU3_A589AgrupacionMotivo = new string[] {""} ;
         H00BU3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00BU3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00BU3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00BU3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00BU3_A120ProfesionalesId = new string[] {""} ;
         H00BU3_A133ProveedorID = new long[1] ;
         H00BU3_A591ListaTipo = new string[] {""} ;
         H00BU3_A590Listaid = new long[1] ;
         H00BU4_AGRID1_nRecordCount = new long[1] ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV10ProveedorID = "";
         subGrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listawp__default(),
            new Object[][] {
                new Object[] {
               H00BU2_A590Listaid, H00BU2_A592ListaNombre, H00BU2_A593ListaEstado, H00BU2_n593ListaEstado, H00BU2_A591ListaTipo
               }
               , new Object[] {
               H00BU3_A588AgrupacionEstado, H00BU3_A589AgrupacionMotivo, H00BU3_A192ProfesionalesApellidoSegundo, H00BU3_A167ProfesionalesApellidoPrimero, H00BU3_A191ProfesionalesSegundoNombre, H00BU3_A166ProfesionalesPrimerNombre, H00BU3_A120ProfesionalesId, H00BU3_A133ProveedorID, H00BU3_A591ListaTipo, H00BU3_A590Listaid
               }
               , new Object[] {
               H00BU4_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         edtavEditar_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int Grid1paginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_26 ;
      private int subGrid1_Rows ;
      private int nGXsfl_26_idx=1 ;
      private int edtavEditar_Enabled ;
      private int Grid1paginationbar_Pagestoshow ;
      private int edtavGrid1currentpage_Visible ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtListaid_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtAgrupacionMotivo_Enabled ;
      private int AV16PageToGo ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV10ProveedorID ;
      private long wcpOAV10ProveedorID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV9ListaId ;
      private long AV18Grid1PageCount ;
      private long AV17Grid1CurrentPage ;
      private long A590Listaid ;
      private long A133ProveedorID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string Grid1paginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_26_idx="0001" ;
      private string AV8Estado ;
      private string edtavEditar_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV20ProfesionalesId ;
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
      private string Grid1_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string dynavListaid_Internalname ;
      private string TempTags ;
      private string dynavListaid_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagregar_Internalname ;
      private string bttBtnagregar_Jsonclick ;
      private string cmbavEstado_Internalname ;
      private string cmbavEstado_Jsonclick ;
      private string divGrid1tablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string Grid1paginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGrid1currentpage_Internalname ;
      private string edtavGrid1currentpage_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtListaid_Internalname ;
      private string cmbListaTipo_Internalname ;
      private string A591ListaTipo ;
      private string edtProveedorID_Internalname ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A191ProfesionalesSegundoNombre ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A192ProfesionalesApellidoSegundo ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string edtAgrupacionMotivo_Internalname ;
      private string cmbAgrupacionEstado_Internalname ;
      private string A588AgrupacionEstado ;
      private string AV7Editar ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string edtProfesionalesPrimerNombre_Columnheaderclass ;
      private string edtProfesionalesSegundoNombre_Columnheaderclass ;
      private string edtProfesionalesApellidoPrimero_Columnheaderclass ;
      private string edtProfesionalesApellidoSegundo_Columnheaderclass ;
      private string edtAgrupacionMotivo_Columnheaderclass ;
      private string cmbAgrupacionEstado_Columnheaderclass ;
      private string edtavEditar_Columnheaderclass ;
      private string edtProfesionalesPrimerNombre_Link ;
      private string edtProfesionalesPrimerNombre_Columnclass ;
      private string edtProfesionalesSegundoNombre_Columnclass ;
      private string edtProfesionalesApellidoPrimero_Columnclass ;
      private string edtProfesionalesApellidoSegundo_Columnclass ;
      private string edtAgrupacionMotivo_Columnclass ;
      private string cmbAgrupacionEstado_Columnclass ;
      private string edtavEditar_Columnclass ;
      private string sCtrlAV10ProveedorID ;
      private string sGXsfl_26_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtListaid_Jsonclick ;
      private string GXCCtl ;
      private string cmbListaTipo_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string edtAgrupacionMotivo_Jsonclick ;
      private string cmbAgrupacionEstado_Jsonclick ;
      private string edtavEditar_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14IsAuthorized_ProfesionalesPrimerNombre ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool Grid1paginationbar_Showfirst ;
      private bool Grid1paginationbar_Showprevious ;
      private bool Grid1paginationbar_Shownext ;
      private bool Grid1paginationbar_Showlast ;
      private bool Grid1paginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private string AV19Grid1AppliedFilters ;
      private string A589AgrupacionMotivo ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucGrid1paginationbar ;
      private GXUserControl ucGrid1_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_ProveedorID ;
      private GXCombobox dynavListaid ;
      private GXCombobox cmbavEstado ;
      private GXCombobox cmbListaTipo ;
      private GXCombobox cmbAgrupacionEstado ;
      private IDataStoreProvider pr_default ;
      private long[] H00BU2_A590Listaid ;
      private string[] H00BU2_A592ListaNombre ;
      private string[] H00BU2_A593ListaEstado ;
      private bool[] H00BU2_n593ListaEstado ;
      private string[] H00BU2_A591ListaTipo ;
      private string[] H00BU3_A588AgrupacionEstado ;
      private string[] H00BU3_A589AgrupacionMotivo ;
      private string[] H00BU3_A192ProfesionalesApellidoSegundo ;
      private string[] H00BU3_A167ProfesionalesApellidoPrimero ;
      private string[] H00BU3_A191ProfesionalesSegundoNombre ;
      private string[] H00BU3_A166ProfesionalesPrimerNombre ;
      private string[] H00BU3_A120ProfesionalesId ;
      private long[] H00BU3_A133ProveedorID ;
      private string[] H00BU3_A591ListaTipo ;
      private long[] H00BU3_A590Listaid ;
      private long[] H00BU4_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class listawp__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BU3( IGxContext context ,
                                             string AV8Estado ,
                                             string A588AgrupacionEstado ,
                                             string A591ListaTipo ,
                                             long AV9ListaId ,
                                             long AV10ProveedorID ,
                                             long A590Listaid ,
                                             long A133ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[AgrupacionEstado], T1.[AgrupacionMotivo], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProveedorID], T3.[ListaTipo], T1.[Listaid]";
         sFromString = " FROM (([ListaAgrupacion] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [Lista] T3 ON T3.[Listaid] = T1.[Listaid])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[Listaid] = @AV9ListaId and T1.[ProveedorID] = @AV10ProveedorID)");
         AddWhere(sWhereString, "(T3.[ListaTipo] = 'PROV')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Estado)) )
         {
            AddWhere(sWhereString, "(T1.[AgrupacionEstado] = @AV8Estado)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         sOrderString += " ORDER BY T1.[Listaid], T1.[ProveedorID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00BU4( IGxContext context ,
                                             string AV8Estado ,
                                             string A588AgrupacionEstado ,
                                             string A591ListaTipo ,
                                             long AV9ListaId ,
                                             long AV10ProveedorID ,
                                             long A590Listaid ,
                                             long A133ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([ListaAgrupacion] T1 INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid])";
         AddWhere(sWhereString, "(T1.[Listaid] = @AV9ListaId and T1.[ProveedorID] = @AV10ProveedorID)");
         AddWhere(sWhereString, "(T2.[ListaTipo] = 'PROV')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Estado)) )
         {
            AddWhere(sWhereString, "(T1.[AgrupacionEstado] = @AV8Estado)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00BU3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] );
               case 2 :
                     return conditional_H00BU4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] );
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
          Object[] prmH00BU2;
          prmH00BU2 = new Object[] {
          };
          Object[] prmH00BU3;
          prmH00BU3 = new Object[] {
          new ParDef("@AV9ListaId",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8Estado",GXType.NChar,3,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00BU4;
          prmH00BU4 = new Object[] {
          new ParDef("@AV9ListaId",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8Estado",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BU2", "SELECT [Listaid], [ListaNombre], [ListaEstado], [ListaTipo] FROM [Lista] WHERE [ListaTipo] = 'PROV' ORDER BY [ListaNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BU2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BU3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BU4,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 4);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

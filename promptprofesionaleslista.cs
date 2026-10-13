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
   public class promptprofesionaleslista : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public promptprofesionaleslista( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promptprofesionaleslista( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_ListaId ,
                           ref long aP1_ProveedorID ,
                           ref string aP2_ProfesionalesId )
      {
         this.AV5ListaId = aP0_ListaId;
         this.AV6ProveedorID = aP1_ProveedorID;
         this.AV8ProfesionalesId = aP2_ProfesionalesId;
         ExecutePrivate();
         aP0_ListaId=this.AV5ListaId;
         aP1_ProveedorID=this.AV6ProveedorID;
         aP2_ProfesionalesId=this.AV8ProfesionalesId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ListaId");
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
               gxfirstwebparm = GetFirstPar( "ListaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ListaId");
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
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
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10Nombre = GetPar( "Nombre");
         AV15IsAuthorized_ProfesionalesPrimerNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ProfesionalesPrimerNombre"));
         AV6ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV5ListaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV10Nombre, AV15IsAuthorized_ProfesionalesPrimerNombre, AV6ProveedorID, AV5ListaId) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PABT2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBT2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "promptprofesionaleslista.aspx"+UrlEncode(StringUtil.LTrimStr(AV5ListaId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV8ProfesionalesId));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("promptprofesionaleslista.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV15IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV15IsAuthorized_ProfesionalesPrimerNombre, context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vNOMBRE", StringUtil.RTrim( AV10Nombre));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Grid1PageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRID1APPLIEDFILTERS", AV20Grid1AppliedFilters);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV15IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV15IsAuthorized_ProfesionalesPrimerNombre, context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV8ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEBT2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBT2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "promptprofesionaleslista.aspx"+UrlEncode(StringUtil.LTrimStr(AV5ListaId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV8ProfesionalesId));
         return formatLink("promptprofesionaleslista.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "promptProfesionalesLista" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesionales Para Lista Negras", "") ;
      }

      protected void WBBT0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNombre_Internalname, context.GetMessage( "Buscar", ""), "col-sm-3 SearchFiltersCellLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNombre_Internalname, StringUtil.RTrim( AV10Nombre), StringUtil.RTrim( context.localUtil.Format( AV10Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNombre_Jsonclick, 0, "SearchFiltersCell", "", "", "", "", 1, edtavNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_promptProfesionalesLista.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid1tablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl20( ) ;
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGrid1paginationbar.SetProperty("CurrentPage", AV18Grid1CurrentPage);
            ucGrid1paginationbar.SetProperty("PageCount", AV19Grid1PageCount);
            ucGrid1paginationbar.SetProperty("AppliedFilters", AV20Grid1AppliedFilters);
            ucGrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Grid1paginationbar_Internalname, "GRID1PAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Incluir a la Lista Negra", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_promptProfesionalesLista.htm");
            wb_table1_31_BT2( true) ;
         }
         else
         {
            wb_table1_31_BT2( false) ;
         }
         return  ;
      }

      protected void wb_table1_31_BT2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucToastr1.Render(context, "toastr", Toastr1_Internalname, "TOASTR1Container");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Grid1CurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18Grid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_promptProfesionalesLista.htm");
            wb_table2_49_BT2( true) ;
         }
         else
         {
            wb_table2_49_BT2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_BT2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
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
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
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
         wbLoad = true;
      }

      protected void STARTBT2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Profesionales Para Lista Negras", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBT0( ) ;
      }

      protected void WSBT2( )
      {
         STARTBT2( ) ;
         EVTBT2( ) ;
      }

      protected void EVTBT2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changepage */
                              E11BT2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changerowsperpage */
                              E12BT2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btnconfirmar.Close */
                              E13BT2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCancelar' */
                              E14BT2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15BT2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16BT2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E17BT2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Nombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMBRE"), AV10Nombre) != 0 )
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEBT2( )
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

      protected void PABT2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "promptprofesionaleslista.aspx")), "promptprofesionaleslista.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "promptprofesionaleslista.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "ListaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5ListaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5ListaId", StringUtil.LTrimStr( (decimal)(AV5ListaId), 18, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV6ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV6ProveedorID", StringUtil.LTrimStr( (decimal)(AV6ProveedorID), 18, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
                        AV8ProfesionalesId = GetPar( "ProfesionalesId");
                        AssignAttri("", false, "AV8ProfesionalesId", AV8ProfesionalesId);
                     }
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
               GX_FocusControl = edtavNombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        string AV10Nombre ,
                                        bool AV15IsAuthorized_ProfesionalesPrimerNombre ,
                                        long AV6ProveedorID ,
                                        long AV5ListaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFBT2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
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
         RFBT2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected int subGrid1client_rec_count_fnc( )
      {
         GRID1_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10Nombre ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A191ProfesionalesSegundoNombre ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
         lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
         lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
         lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
         /* Using cursor H00BT2 */
         pr_default.execute(0, new Object[] {lV10Nombre, lV10Nombre, lV10Nombre, lV10Nombre});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = H00BT2_A108EstadosGenericosId[0];
            A107EstadosTipo = H00BT2_A107EstadosTipo[0];
            A192ProfesionalesApellidoSegundo = H00BT2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = H00BT2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = H00BT2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = H00BT2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = H00BT2_A120ProfesionalesId[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               GRID1_nRecordCount = (long)(GRID1_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID1_nRecordCount) ;
      }

      protected void RFBT2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 20;
         /* Execute user event: Refresh */
         E16BT2 ();
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV10Nombre ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A107EstadosTipo ,
                                                 A108EstadosGenericosId } ,
                                                 new int[]{
                                                 TypeConstants.INT
                                                 }
            });
            lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
            lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
            lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
            lV10Nombre = StringUtil.PadR( StringUtil.RTrim( AV10Nombre), 80, "%");
            /* Using cursor H00BT3 */
            pr_default.execute(1, new Object[] {lV10Nombre, lV10Nombre, lV10Nombre, lV10Nombre});
            nGXsfl_20_idx = 1;
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
            GRID1_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A108EstadosGenericosId = H00BT3_A108EstadosGenericosId[0];
               A107EstadosTipo = H00BT3_A107EstadosTipo[0];
               A192ProfesionalesApellidoSegundo = H00BT3_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00BT3_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00BT3_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00BT3_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H00BT3_A120ProfesionalesId[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  /* Execute user event: Grid1.Load */
                  E17BT2 ();
               }
               pr_default.readNext(1);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 20;
            WBBT0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBT2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV15IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV15IsAuthorized_ProfesionalesPrimerNombre, context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
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
         return (int)(subGrid1client_rec_count_fnc()) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV10Nombre, AV15IsAuthorized_ProfesionalesPrimerNombre, AV6ProveedorID, AV5ListaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         if ( GRID1_nEOF == 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV10Nombre, AV15IsAuthorized_ProfesionalesPrimerNombre, AV6ProveedorID, AV5ListaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV10Nombre, AV15IsAuthorized_ProfesionalesPrimerNombre, AV6ProveedorID, AV5ListaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV10Nombre, AV15IsAuthorized_ProfesionalesPrimerNombre, AV6ProveedorID, AV5ListaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV10Nombre, AV15IsAuthorized_ProfesionalesPrimerNombre, AV6ProveedorID, AV5ListaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBT0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15BT2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV19Grid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRID1PAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV19Grid1PageCount), 10, 0));
            AV20Grid1AppliedFilters = cgiGet( "vGRID1APPLIEDFILTERS");
            AV8ProfesionalesId = cgiGet( "vPROFESIONALESID");
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
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
            Dvelop_confirmpanel_btnconfirmar_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Title");
            Dvelop_confirmpanel_btnconfirmar_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmationtext");
            Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Nobuttoncaption");
            Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttonposition");
            Dvelop_confirmpanel_btnconfirmar_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmtype");
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Grid1paginationbar_Selectedpage = cgiGet( "GRID1PAGINATIONBAR_Selectedpage");
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV10Nombre = cgiGet( edtavNombre_Internalname);
            AssignAttri("", false, "AV10Nombre", AV10Nombre);
            AV12Motivo = cgiGet( edtavMotivo_Internalname);
            AssignAttri("", false, "AV12Motivo", AV12Motivo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRID1CURRENTPAGE");
               GX_FocusControl = edtavGrid1currentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18Grid1CurrentPage = 0;
               AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
            }
            else
            {
               AV18Grid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            nGXsfl_20_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid1_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
            if ( nGXsfl_20_idx > 0 )
            {
               A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
               A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
               A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
               A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
               A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNOMBRE"), AV10Nombre) != 0 )
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
         E15BT2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15BT2( )
      {
         /* Start Routine */
         returnInSub = false;
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV18Grid1CurrentPage = 1;
         AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
         edtavGrid1currentpage_Visible = 0;
         AssignProp("", false, edtavGrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGrid1currentpage_Visible), 5, 0), true);
         AV19Grid1PageCount = -1;
         AssignAttri("", false, "AV19Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV19Grid1PageCount), 10, 0));
         GXt_boolean1 = AV15IsAuthorized_ProfesionalesPrimerNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV15IsAuthorized_ProfesionalesPrimerNombre = GXt_boolean1;
         AssignAttri("", false, "AV15IsAuthorized_ProfesionalesPrimerNombre", AV15IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV15IsAuthorized_ProfesionalesPrimerNombre, context));
         Grid1paginationbar_Rowsperpageselectedvalue = subGrid1_Rows;
         ucGrid1paginationbar.SendProperty(context, "", false, Grid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16BT2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E17BT2( )
      {
         if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid1_Load Routine */
            returnInSub = false;
            if ( AV15IsAuthorized_ProfesionalesPrimerNombre )
            {
               edtProfesionalesPrimerNombre_Link = formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) ;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 20;
            }
            sendrow_202( ) ;
         }
         GRID1_nEOF = (short)(((subGrid1_Rows==0)||(GRID1_nCurrentRecord<GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
         {
            context.DoAjaxLoad(20, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E11BT2( )
      {
         /* Grid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV18Grid1CurrentPage = (long)(AV18Grid1CurrentPage-1);
            AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
            subgrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV18Grid1CurrentPage = (long)(AV18Grid1CurrentPage+1);
            AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
            subgrid1_nextpage( ) ;
         }
         else
         {
            AV17PageToGo = (int)(Math.Round(NumberUtil.Val( Grid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV18Grid1CurrentPage = AV17PageToGo;
            AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
            subgrid1_gotopage( AV17PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E12BT2( )
      {
         /* Grid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid1_Rows = Grid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV18Grid1CurrentPage = 1;
         AssignAttri("", false, "AV18Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV18Grid1CurrentPage), 10, 0));
         subgrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14BT2( )
      {
         /* 'DoCancelar' Routine */
         returnInSub = false;
         AV8ProfesionalesId = "";
         AssignAttri("", false, "AV8ProfesionalesId", AV8ProfesionalesId);
         context.setWebReturnParms(new Object[] {(long)AV5ListaId,(long)AV6ProveedorID,(string)AV8ProfesionalesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV5ListaId","AV6ProveedorID","AV8ProfesionalesId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E13BT2( )
      {
         /* Dvelop_confirmpanel_btnconfirmar_Close Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) )
         {
            AV11Proveedor = false;
            new aingresaralista(context ).execute(  AV5ListaId,  AV6ProveedorID,  AV8ProfesionalesId,  AV11Proveedor,  AV12Motivo, out  AV7IsOk) ;
            context.setWebReturnParms(new Object[] {(long)AV5ListaId,(long)AV6ProveedorID,(string)AV8ProfesionalesId});
            context.setWebReturnParmsMetadata(new Object[] {"AV5ListaId","AV6ProveedorID","AV8ProfesionalesId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV9Titulo = context.GetMessage( "Error: ", "");
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Debe seleccionar un profesional.", ""),(string)AV9Titulo});
         }
      }

      protected void wb_table2_49_BT2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnconfirmar_Internalname, tblTabledvelop_confirmpanel_btnconfirmar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("Title", Dvelop_confirmpanel_btnconfirmar_Title);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnconfirmar_Confirmationtext);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("ConfirmType", Dvelop_confirmpanel_btnconfirmar_Confirmtype);
            ucDvelop_confirmpanel_btnconfirmar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnconfirmar_Internalname, "DVELOP_CONFIRMPANEL_BTNCONFIRMARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNCONFIRMARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_BT2e( true) ;
         }
         else
         {
            wb_table2_49_BT2e( false) ;
         }
      }

      protected void wb_table1_31_BT2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavMotivo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMotivo_Internalname, context.GetMessage( "Motivo", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMotivo_Internalname, AV12Motivo, StringUtil.RTrim( context.localUtil.Format( AV12Motivo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Ingrese un Motivo", ""), edtavMotivo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMotivo_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_promptProfesionalesLista.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", context.GetMessage( "Cancelar", ""), bttBtncancelar_Jsonclick, 5, context.GetMessage( "Cancelar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_promptProfesionalesLista.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", context.GetMessage( "Confirmar", ""), bttBtnconfirmar_Jsonclick, 7, context.GetMessage( "Confirmar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18bt1_client"+"'", TempTags, "", 2, "HLP_promptProfesionalesLista.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_31_BT2e( true) ;
         }
         else
         {
            wb_table1_31_BT2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5ListaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV5ListaId", StringUtil.LTrimStr( (decimal)(AV5ListaId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV6ProveedorID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV6ProveedorID", StringUtil.LTrimStr( (decimal)(AV6ProveedorID), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV8ProfesionalesId = (string)getParm(obj,2);
         AssignAttri("", false, "AV8ProfesionalesId", AV8ProfesionalesId);
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
         PABT2( ) ;
         WSBT2( ) ;
         WEBT2( ) ;
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
         AddStyleSheetFile("Toastr/toastr.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021222589", true, true, false);
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
            context.AddJavascriptSource("promptprofesionaleslista.js", "?202673021222590", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
            context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_20_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_20_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_20_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_20_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_20_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_20_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_20_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_20_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         WBBT0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_20_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_20_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProfesionalesPrimerNombre_Link,(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesBT2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_20_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl20( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"20\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.SendWebValue( context.GetMessage( " Apellido ", "")) ;
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
            Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtProfesionalesPrimerNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
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
         edtavNombre_Internalname = "vNOMBRE";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         Grid1paginationbar_Internalname = "GRID1PAGINATIONBAR";
         divGrid1tablewithpaginationbar_Internalname = "GRID1TABLEWITHPAGINATIONBAR";
         edtavMotivo_Internalname = "vMOTIVO";
         bttBtncancelar_Internalname = "BTNCANCELAR";
         bttBtnconfirmar_Internalname = "BTNCONFIRMAR";
         tblUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTable1_Internalname = "TABLE1";
         Toastr1_Internalname = "TOASTR1";
         divMaintable_Internalname = "MAINTABLE";
         edtavGrid1currentpage_Internalname = "vGRID1CURRENTPAGE";
         Dvelop_confirmpanel_btnconfirmar_Internalname = "DVELOP_CONFIRMPANEL_BTNCONFIRMAR";
         tblTabledvelop_confirmpanel_btnconfirmar_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNCONFIRMAR";
         Grid1_empowerer_Internalname = "GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowhovering = -1;
         subGrid1_Allowselection = 1;
         subGrid1_Header = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Link = "";
         edtProfesionalesId_Jsonclick = "";
         subGrid1_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavMotivo_Jsonclick = "";
         edtavMotivo_Enabled = 1;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtavGrid1currentpage_Jsonclick = "";
         edtavGrid1currentpage_Visible = 1;
         edtavNombre_Jsonclick = "";
         edtavNombre_Enabled = 1;
         Dvelop_confirmpanel_btnconfirmar_Confirmtype = "1";
         Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnconfirmar_Confirmationtext = "Confirme para Incluir a la Lista";
         Dvelop_confirmpanel_btnconfirmar_Title = context.GetMessage( "ATENCIÓN", "");
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Profesionales Para Lista Negras", "");
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10Nombre',fld:'vNOMBRE',pic:'',type:'char'},{av:'AV15IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E17BT2',iparms:[{av:'AV15IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'edtProfesionalesPrimerNombre_Link',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Link'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE","{handler:'E11BT2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10Nombre',fld:'vNOMBRE',pic:'',type:'char'},{av:'AV15IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Grid1paginationbar_Selectedpage',ctrl:'GRID1PAGINATIONBAR',prop:'SelectedPage'},{av:'AV18Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV18Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12BT2',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV10Nombre',fld:'vNOMBRE',pic:'',type:'char'},{av:'AV15IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Grid1paginationbar_Rowsperpageselectedvalue',ctrl:'GRID1PAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV18Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOCANCELAR'","{handler:'E14BT2',iparms:[{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOCANCELAR'",",oparms:[{av:'AV8ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'}]}");
         setEventMetadata("'DOCONFIRMAR'","{handler:'E18BT1',iparms:[]");
         setEventMetadata("'DOCONFIRMAR'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNCONFIRMAR.CLOSE","{handler:'E13BT2',iparms:[{av:'AV8ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'AV5ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12Motivo',fld:'vMOTIVO',pic:'',type:'svchar'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNCONFIRMAR.CLOSE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Profesionalesapellidosegundo',iparms:[]");
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
         wcpOAV8ProfesionalesId = "";
         Grid1paginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10Nombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV20Grid1AppliedFilters = "";
         A107EstadosTipo = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucGrid1paginationbar = new GXUserControl();
         ucToastr1 = new GXUserControl();
         ucGrid1_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         GXDecQS = "";
         lV10Nombre = "";
         H00BT2_A108EstadosGenericosId = new int[1] ;
         H00BT2_A107EstadosTipo = new string[] {""} ;
         H00BT2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00BT2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00BT2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00BT2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00BT2_A120ProfesionalesId = new string[] {""} ;
         H00BT3_A108EstadosGenericosId = new int[1] ;
         H00BT3_A107EstadosTipo = new string[] {""} ;
         H00BT3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00BT3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00BT3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00BT3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00BT3_A120ProfesionalesId = new string[] {""} ;
         AV12Motivo = "";
         Grid1Row = new GXWebRow();
         AV9Titulo = "";
         ucDvelop_confirmpanel_btnconfirmar = new GXUserControl();
         ClassString = "";
         StyleString = "";
         bttBtncancelar_Jsonclick = "";
         bttBtnconfirmar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promptprofesionaleslista__default(),
            new Object[][] {
                new Object[] {
               H00BT2_A108EstadosGenericosId, H00BT2_A107EstadosTipo, H00BT2_A192ProfesionalesApellidoSegundo, H00BT2_A167ProfesionalesApellidoPrimero, H00BT2_A191ProfesionalesSegundoNombre, H00BT2_A166ProfesionalesPrimerNombre, H00BT2_A120ProfesionalesId
               }
               , new Object[] {
               H00BT3_A108EstadosGenericosId, H00BT3_A107EstadosTipo, H00BT3_A192ProfesionalesApellidoSegundo, H00BT3_A167ProfesionalesApellidoPrimero, H00BT3_A191ProfesionalesSegundoNombre, H00BT3_A166ProfesionalesPrimerNombre, H00BT3_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int Grid1paginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_20 ;
      private int subGrid1_Rows ;
      private int nGXsfl_20_idx=1 ;
      private int A108EstadosGenericosId ;
      private int Grid1paginationbar_Pagestoshow ;
      private int edtavNombre_Enabled ;
      private int edtavGrid1currentpage_Visible ;
      private int subGrid1_Islastpage ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int AV17PageToGo ;
      private int edtavMotivo_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV5ListaId ;
      private long AV6ProveedorID ;
      private long wcpOAV5ListaId ;
      private long wcpOAV6ProveedorID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV19Grid1PageCount ;
      private long AV18Grid1CurrentPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV8ProfesionalesId ;
      private string wcpOAV8ProfesionalesId ;
      private string Grid1paginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_20_idx="0001" ;
      private string AV10Nombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A107EstadosTipo ;
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
      private string Dvelop_confirmpanel_btnconfirmar_Title ;
      private string Dvelop_confirmpanel_btnconfirmar_Confirmationtext ;
      private string Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnconfirmar_Confirmtype ;
      private string Grid1_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string edtavNombre_Internalname ;
      private string TempTags ;
      private string edtavNombre_Jsonclick ;
      private string divGrid1tablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string Grid1paginationbar_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string Toastr1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGrid1currentpage_Internalname ;
      private string edtavGrid1currentpage_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
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
      private string GXDecQS ;
      private string lV10Nombre ;
      private string edtavMotivo_Internalname ;
      private string edtProfesionalesPrimerNombre_Link ;
      private string tblTabledvelop_confirmpanel_btnconfirmar_Internalname ;
      private string Dvelop_confirmpanel_btnconfirmar_Internalname ;
      private string tblUnnamedtable1_Internalname ;
      private string edtavMotivo_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancelar_Internalname ;
      private string bttBtncancelar_Jsonclick ;
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15IsAuthorized_ProfesionalesPrimerNombre ;
      private bool Grid1paginationbar_Showfirst ;
      private bool Grid1paginationbar_Showprevious ;
      private bool Grid1paginationbar_Shownext ;
      private bool Grid1paginationbar_Showlast ;
      private bool Grid1paginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private bool AV11Proveedor ;
      private bool AV7IsOk ;
      private string AV20Grid1AppliedFilters ;
      private string AV12Motivo ;
      private string AV9Titulo ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucGrid1paginationbar ;
      private GXUserControl ucToastr1 ;
      private GXUserControl ucGrid1_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_btnconfirmar ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_ListaId ;
      private long aP1_ProveedorID ;
      private string aP2_ProfesionalesId ;
      private IDataStoreProvider pr_default ;
      private int[] H00BT2_A108EstadosGenericosId ;
      private string[] H00BT2_A107EstadosTipo ;
      private string[] H00BT2_A192ProfesionalesApellidoSegundo ;
      private string[] H00BT2_A167ProfesionalesApellidoPrimero ;
      private string[] H00BT2_A191ProfesionalesSegundoNombre ;
      private string[] H00BT2_A166ProfesionalesPrimerNombre ;
      private string[] H00BT2_A120ProfesionalesId ;
      private int[] H00BT3_A108EstadosGenericosId ;
      private string[] H00BT3_A107EstadosTipo ;
      private string[] H00BT3_A192ProfesionalesApellidoSegundo ;
      private string[] H00BT3_A167ProfesionalesApellidoPrimero ;
      private string[] H00BT3_A191ProfesionalesSegundoNombre ;
      private string[] H00BT3_A166ProfesionalesPrimerNombre ;
      private string[] H00BT3_A120ProfesionalesId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class promptprofesionaleslista__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BT2( IGxContext context ,
                                             string AV10Nombre ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Nombre)) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] like RTRIM(LTRIM(@lV10Nombre)) or [ProfesionalesApellidoPrimero] like RTRIM(LTRIM(@lV10Nombre)) or [ProfesionalesSegundoNombre] like RTRIM(LTRIM(@lV10Nombre)) or [ProfesionalesApellidoSegundo] like RTRIM(LTRIM(@lV10Nombre)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesId]";
         scmdbuf += " OPTION (FAST 11)";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00BT3( IGxContext context ,
                                             string AV10Nombre ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Nombre)) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] like RTRIM(LTRIM(@lV10Nombre)) or [ProfesionalesApellidoPrimero] like RTRIM(LTRIM(@lV10Nombre)) or [ProfesionalesSegundoNombre] like RTRIM(LTRIM(@lV10Nombre)) or [ProfesionalesApellidoSegundo] like RTRIM(LTRIM(@lV10Nombre)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesId]";
         scmdbuf += " OPTION (FAST 11)";
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
               case 0 :
                     return conditional_H00BT2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] );
               case 1 :
                     return conditional_H00BT3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] );
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
          Object[] prmH00BT2;
          prmH00BT2 = new Object[] {
          new ParDef("@lV10Nombre",GXType.NChar,80,0) ,
          new ParDef("@lV10Nombre",GXType.NChar,80,0) ,
          new ParDef("@lV10Nombre",GXType.NChar,80,0) ,
          new ParDef("@lV10Nombre",GXType.NChar,80,0)
          };
          Object[] prmH00BT3;
          prmH00BT3 = new Object[] {
          new ParDef("@lV10Nombre",GXType.NChar,80,0) ,
          new ParDef("@lV10Nombre",GXType.NChar,80,0) ,
          new ParDef("@lV10Nombre",GXType.NChar,80,0) ,
          new ParDef("@lV10Nombre",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BT2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BT3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BT3,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
       }
    }

 }

}

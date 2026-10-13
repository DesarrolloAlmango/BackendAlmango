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
   public class incidenciaslista : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public incidenciaslista( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public incidenciaslista( IGxContext context )
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
         cmbIncidenciaOrigen = new GXCombobox();
         cmbMotivoTipo = new GXCombobox();
         cmbIncidenciaEstado = new GXCombobox();
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
         nRC_GXsfl_24 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_24"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_24_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_24_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_24_idx = GetPar( "sGXsfl_24_idx");
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
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows) ;
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
            ValidateSpaRequest();
            PAB92( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavAtender_Enabled = 0;
               AssignProp("", false, edtavAtender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAtender_Enabled), 5, 0), !bGXsfl_24_Refreshing);
               WSB92( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WEB92( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( context.GetMessage( "Lista de Incidencias", "")) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("incidenciaslista.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_24), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Grid1PageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRID1APPLIEDFILTERS", AV14Grid1AppliedFilters);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormB92( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "IncidenciasLista" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista de Incidencias", "") ;
      }

      protected void WBB90( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Lista General de Incidencias", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigTitle", 0, "", 1, 1, 0, 0, "HLP_IncidenciasLista.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-10 col-sm-6 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid1tablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl24( ) ;
         }
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            nRC_GXsfl_24 = (int)(nGXsfl_24_idx-1);
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
            ucGrid1paginationbar.SetProperty("CurrentPage", AV12Grid1CurrentPage);
            ucGrid1paginationbar.SetProperty("PageCount", AV13Grid1PageCount);
            ucGrid1paginationbar.SetProperty("AppliedFilters", AV14Grid1AppliedFilters);
            ucGrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Grid1paginationbar_Internalname, "GRID1PAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Grid1CurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12Grid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_IncidenciasLista.htm");
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 24 )
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

      protected void STARTB92( )
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
         Form.Meta.addItem("description", context.GetMessage( "Lista de Incidencias", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPB90( ) ;
      }

      protected void WSB92( )
      {
         STARTB92( ) ;
         EVTB92( ) ;
      }

      protected void EVTB92( )
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
                           E11B92 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Grid1paginationbar.Changerowsperpage */
                           E12B92 ();
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
                           nGXsfl_24_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
                           SubsflControlProps_242( ) ;
                           AV5Atender = cgiGet( edtavAtender_Internalname);
                           AssignAttri("", false, edtavAtender_Internalname, AV5Atender);
                           A603IncidenciaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtIncidenciaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           cmbIncidenciaOrigen.Name = cmbIncidenciaOrigen_Internalname;
                           cmbIncidenciaOrigen.CurrentValue = cgiGet( cmbIncidenciaOrigen_Internalname);
                           A611IncidenciaOrigen = cgiGet( cmbIncidenciaOrigen_Internalname);
                           A606IncidenciaCodRef = cgiGet( edtIncidenciaCodRef_Internalname);
                           A604MotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           cmbMotivoTipo.Name = cmbMotivoTipo_Internalname;
                           cmbMotivoTipo.CurrentValue = cgiGet( cmbMotivoTipo_Internalname);
                           A618MotivoTipo = cgiGet( cmbMotivoTipo_Internalname);
                           n618MotivoTipo = false;
                           A616MotivoNombre = cgiGet( edtMotivoNombre_Internalname);
                           A609IncidenciaFechaActualizacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtIncidenciaFechaActualizacion_Internalname), 0));
                           A615IncidenciaUsrAlta = cgiGet( edtIncidenciaUsrAlta_Internalname);
                           A610IncidenciaFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtIncidenciaFechaAlta_Internalname), 0));
                           cmbIncidenciaEstado.Name = cmbIncidenciaEstado_Internalname;
                           cmbIncidenciaEstado.CurrentValue = cgiGet( cmbIncidenciaEstado_Internalname);
                           A608IncidenciaEstado = cgiGet( cmbIncidenciaEstado_Internalname);
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E13B92 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E14B92 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Grid1.Load */
                                 E15B92 ();
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
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WEB92( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormB92( ) ;
            }
         }
      }

      protected void PAB92( )
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
               GX_FocusControl = edtavGrid1currentpage_Internalname;
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
         SubsflControlProps_242( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            sendrow_242( ) ;
            nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFB92( ) ;
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
         RFB92( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavAtender_Enabled = 0;
      }

      protected void RFB92( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 24;
         /* Execute user event: Refresh */
         E14B92 ();
         nGXsfl_24_idx = 1;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         bGXsfl_24_Refreshing = true;
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
            SubsflControlProps_242( ) ;
            GXPagingFrom2 = (int)(((subGrid1_Rows==0) ? 0 : GRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid1_Rows==0) ? 10000 : subGrid1_fnc_Recordsperpage( )+1);
            /* Using cursor H00B92 */
            pr_default.execute(0, new Object[] {AV6IncidenciaFechaAlta, GXPagingFrom2, GXPagingTo2});
            nGXsfl_24_idx = 1;
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A608IncidenciaEstado = H00B92_A608IncidenciaEstado[0];
               A610IncidenciaFechaAlta = H00B92_A610IncidenciaFechaAlta[0];
               A615IncidenciaUsrAlta = H00B92_A615IncidenciaUsrAlta[0];
               A609IncidenciaFechaActualizacion = H00B92_A609IncidenciaFechaActualizacion[0];
               A616MotivoNombre = H00B92_A616MotivoNombre[0];
               A618MotivoTipo = H00B92_A618MotivoTipo[0];
               n618MotivoTipo = H00B92_n618MotivoTipo[0];
               A604MotivoId = H00B92_A604MotivoId[0];
               A606IncidenciaCodRef = H00B92_A606IncidenciaCodRef[0];
               A611IncidenciaOrigen = H00B92_A611IncidenciaOrigen[0];
               A603IncidenciaId = H00B92_A603IncidenciaId[0];
               A616MotivoNombre = H00B92_A616MotivoNombre[0];
               A618MotivoTipo = H00B92_A618MotivoTipo[0];
               n618MotivoTipo = H00B92_n618MotivoTipo[0];
               /* Execute user event: Grid1.Load */
               E15B92 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 24;
            WBB90( ) ;
         }
         bGXsfl_24_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesB92( )
      {
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
         /* Using cursor H00B93 */
         pr_default.execute(1, new Object[] {AV6IncidenciaFechaAlta});
         GRID1_nRecordCount = H00B93_AGRID1_nRecordCount[0];
         pr_default.close(1);
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
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows) ;
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
            gxgrGrid1_refresh( subGrid1_Rows) ;
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
            gxgrGrid1_refresh( subGrid1_Rows) ;
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
            gxgrGrid1_refresh( subGrid1_Rows) ;
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
            gxgrGrid1_refresh( subGrid1_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavAtender_Enabled = 0;
         edtIncidenciaId_Enabled = 0;
         cmbIncidenciaOrigen.Enabled = 0;
         edtIncidenciaCodRef_Enabled = 0;
         edtMotivoId_Enabled = 0;
         cmbMotivoTipo.Enabled = 0;
         edtMotivoNombre_Enabled = 0;
         edtIncidenciaFechaActualizacion_Enabled = 0;
         edtIncidenciaUsrAlta_Enabled = 0;
         edtIncidenciaFechaAlta_Enabled = 0;
         cmbIncidenciaEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB90( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13B92 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_24 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_24"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV13Grid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRID1PAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV13Grid1PageCount), 10, 0));
            AV14Grid1AppliedFilters = cgiGet( "vGRID1APPLIEDFILTERS");
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
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Grid1paginationbar_Selectedpage = cgiGet( "GRID1PAGINATIONBAR_Selectedpage");
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRID1CURRENTPAGE");
               GX_FocusControl = edtavGrid1currentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12Grid1CurrentPage = 0;
               AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
            }
            else
            {
               AV12Grid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
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
         E13B92 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13B92( )
      {
         /* Start Routine */
         returnInSub = false;
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV12Grid1CurrentPage = 1;
         AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
         edtavGrid1currentpage_Visible = 0;
         AssignProp("", false, edtavGrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGrid1currentpage_Visible), 5, 0), true);
         AV13Grid1PageCount = -1;
         AssignAttri("", false, "AV13Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV13Grid1PageCount), 10, 0));
         GXt_boolean1 = AV9IsAuthorized_IncidenciaOrigen;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia", out  GXt_boolean1) ;
         AV9IsAuthorized_IncidenciaOrigen = GXt_boolean1;
         Grid1paginationbar_Rowsperpageselectedvalue = subGrid1_Rows;
         ucGrid1paginationbar.SendProperty(context, "", false, Grid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E14B92( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E15B92( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV5Atender = "<i class=\"AttributeColorSuccess fas fa-handshake-angle\"></i>";
         AssignAttri("", false, edtavAtender_Internalname, AV5Atender);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 24;
         }
         sendrow_242( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_24_Refreshing )
         {
            context.DoAjaxLoad(24, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E11B92( )
      {
         /* Grid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV12Grid1CurrentPage = (long)(AV12Grid1CurrentPage-1);
            AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
            subgrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV12Grid1CurrentPage = (long)(AV12Grid1CurrentPage+1);
            AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
            subgrid1_nextpage( ) ;
         }
         else
         {
            AV11PageToGo = (int)(Math.Round(NumberUtil.Val( Grid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV12Grid1CurrentPage = AV11PageToGo;
            AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
            subgrid1_gotopage( AV11PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E12B92( )
      {
         /* Grid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid1_Rows = Grid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV12Grid1CurrentPage = 1;
         AssignAttri("", false, "AV12Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV12Grid1CurrentPage), 10, 0));
         subgrid1_firstpage( ) ;
         /*  Sending Event outputs  */
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
         PAB92( ) ;
         WSB92( ) ;
         WEB92( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021221329", true, true, false);
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
            context.AddJavascriptSource("incidenciaslista.js", "?202673021221330", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
            context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_242( )
      {
         edtavAtender_Internalname = "vATENDER_"+sGXsfl_24_idx;
         edtIncidenciaId_Internalname = "INCIDENCIAID_"+sGXsfl_24_idx;
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN_"+sGXsfl_24_idx;
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF_"+sGXsfl_24_idx;
         edtMotivoId_Internalname = "MOTIVOID_"+sGXsfl_24_idx;
         cmbMotivoTipo_Internalname = "MOTIVOTIPO_"+sGXsfl_24_idx;
         edtMotivoNombre_Internalname = "MOTIVONOMBRE_"+sGXsfl_24_idx;
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION_"+sGXsfl_24_idx;
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA_"+sGXsfl_24_idx;
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA_"+sGXsfl_24_idx;
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_242( )
      {
         edtavAtender_Internalname = "vATENDER_"+sGXsfl_24_fel_idx;
         edtIncidenciaId_Internalname = "INCIDENCIAID_"+sGXsfl_24_fel_idx;
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN_"+sGXsfl_24_fel_idx;
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF_"+sGXsfl_24_fel_idx;
         edtMotivoId_Internalname = "MOTIVOID_"+sGXsfl_24_fel_idx;
         cmbMotivoTipo_Internalname = "MOTIVOTIPO_"+sGXsfl_24_fel_idx;
         edtMotivoNombre_Internalname = "MOTIVONOMBRE_"+sGXsfl_24_fel_idx;
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION_"+sGXsfl_24_fel_idx;
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA_"+sGXsfl_24_fel_idx;
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA_"+sGXsfl_24_fel_idx;
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO_"+sGXsfl_24_fel_idx;
      }

      protected void sendrow_242( )
      {
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         WBB90( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_24_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_24_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_24_idx + "',24)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAtender_Internalname,StringUtil.RTrim( AV5Atender),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"",(string)"'"+""+"'"+",false,"+"'"+"e16b92_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAtender_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAtender_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)24,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A603IncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbIncidenciaOrigen.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INCIDENCIAORIGEN_" + sGXsfl_24_idx;
               cmbIncidenciaOrigen.Name = GXCCtl;
               cmbIncidenciaOrigen.WebTags = "";
               cmbIncidenciaOrigen.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
               cmbIncidenciaOrigen.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
               cmbIncidenciaOrigen.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
               if ( cmbIncidenciaOrigen.ItemCount > 0 )
               {
                  A611IncidenciaOrigen = cmbIncidenciaOrigen.getValidValue(A611IncidenciaOrigen);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbIncidenciaOrigen,(string)cmbIncidenciaOrigen_Internalname,StringUtil.RTrim( A611IncidenciaOrigen),(short)1,(string)cmbIncidenciaOrigen_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbIncidenciaOrigen.CurrentValue = StringUtil.RTrim( A611IncidenciaOrigen);
            AssignProp("", false, cmbIncidenciaOrigen_Internalname, "Values", (string)(cmbIncidenciaOrigen.ToJavascriptSource()), !bGXsfl_24_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaCodRef_Internalname,(string)A606IncidenciaCodRef,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaCodRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A604MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A604MotivoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "MOTIVOTIPO_" + sGXsfl_24_idx;
            cmbMotivoTipo.Name = GXCCtl;
            cmbMotivoTipo.WebTags = "";
            cmbMotivoTipo.addItem("INC", context.GetMessage( "Incidencias", ""), 0);
            if ( cmbMotivoTipo.ItemCount > 0 )
            {
               A618MotivoTipo = cmbMotivoTipo.getValidValue(A618MotivoTipo);
               n618MotivoTipo = false;
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMotivoTipo,(string)cmbMotivoTipo_Internalname,StringUtil.RTrim( A618MotivoTipo),(short)1,(string)cmbMotivoTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMotivoTipo.CurrentValue = StringUtil.RTrim( A618MotivoTipo);
            AssignProp("", false, cmbMotivoTipo_Internalname, "Values", (string)(cmbMotivoTipo.ToJavascriptSource()), !bGXsfl_24_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoNombre_Internalname,StringUtil.RTrim( A616MotivoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaFechaActualizacion_Internalname,context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"),context.localUtil.Format( A609IncidenciaFechaActualizacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaFechaActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaUsrAlta_Internalname,StringUtil.RTrim( A615IncidenciaUsrAlta),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaFechaAlta_Internalname,context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"),context.localUtil.Format( A610IncidenciaFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbIncidenciaEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INCIDENCIAESTADO_" + sGXsfl_24_idx;
               cmbIncidenciaEstado.Name = GXCCtl;
               cmbIncidenciaEstado.WebTags = "";
               cmbIncidenciaEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbIncidenciaEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbIncidenciaEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbIncidenciaEstado.ItemCount > 0 )
               {
                  A608IncidenciaEstado = cmbIncidenciaEstado.getValidValue(A608IncidenciaEstado);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbIncidenciaEstado,(string)cmbIncidenciaEstado_Internalname,StringUtil.RTrim( A608IncidenciaEstado),(short)1,(string)cmbIncidenciaEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbIncidenciaEstado.CurrentValue = StringUtil.RTrim( A608IncidenciaEstado);
            AssignProp("", false, cmbIncidenciaEstado_Internalname, "Values", (string)(cmbIncidenciaEstado.ToJavascriptSource()), !bGXsfl_24_Refreshing);
            send_integrity_lvl_hashesB92( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         /* End function sendrow_242 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "INCIDENCIAORIGEN_" + sGXsfl_24_idx;
         cmbIncidenciaOrigen.Name = GXCCtl;
         cmbIncidenciaOrigen.WebTags = "";
         cmbIncidenciaOrigen.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
         cmbIncidenciaOrigen.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
         cmbIncidenciaOrigen.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
         if ( cmbIncidenciaOrigen.ItemCount > 0 )
         {
            A611IncidenciaOrigen = cmbIncidenciaOrigen.getValidValue(A611IncidenciaOrigen);
         }
         GXCCtl = "MOTIVOTIPO_" + sGXsfl_24_idx;
         cmbMotivoTipo.Name = GXCCtl;
         cmbMotivoTipo.WebTags = "";
         cmbMotivoTipo.addItem("INC", context.GetMessage( "Incidencias", ""), 0);
         if ( cmbMotivoTipo.ItemCount > 0 )
         {
            A618MotivoTipo = cmbMotivoTipo.getValidValue(A618MotivoTipo);
            n618MotivoTipo = false;
         }
         GXCCtl = "INCIDENCIAESTADO_" + sGXsfl_24_idx;
         cmbIncidenciaEstado.Name = GXCCtl;
         cmbIncidenciaEstado.WebTags = "";
         cmbIncidenciaEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbIncidenciaEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbIncidenciaEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbIncidenciaEstado.ItemCount > 0 )
         {
            A608IncidenciaEstado = cmbIncidenciaEstado.getValidValue(A608IncidenciaEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl24( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"24\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Incidencia Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Actualización", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
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
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV5Atender)));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAtender_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A603IncidenciaId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A611IncidenciaOrigen)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A606IncidenciaCodRef));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A604MotivoId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A618MotivoTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A616MotivoNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A615IncidenciaUsrAlta)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A608IncidenciaEstado)));
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
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTable2_Internalname = "TABLE2";
         edtavAtender_Internalname = "vATENDER";
         edtIncidenciaId_Internalname = "INCIDENCIAID";
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN";
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF";
         edtMotivoId_Internalname = "MOTIVOID";
         cmbMotivoTipo_Internalname = "MOTIVOTIPO";
         edtMotivoNombre_Internalname = "MOTIVONOMBRE";
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION";
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA";
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA";
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO";
         Grid1paginationbar_Internalname = "GRID1PAGINATIONBAR";
         divGrid1tablewithpaginationbar_Internalname = "GRID1TABLEWITHPAGINATIONBAR";
         divTable3_Internalname = "TABLE3";
         divTable1_Internalname = "TABLE1";
         Toastr1_Internalname = "TOASTR1";
         divMaintable_Internalname = "MAINTABLE";
         edtavGrid1currentpage_Internalname = "vGRID1CURRENTPAGE";
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
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         cmbIncidenciaEstado_Jsonclick = "";
         edtIncidenciaFechaAlta_Jsonclick = "";
         edtIncidenciaUsrAlta_Jsonclick = "";
         edtIncidenciaFechaActualizacion_Jsonclick = "";
         edtMotivoNombre_Jsonclick = "";
         cmbMotivoTipo_Jsonclick = "";
         edtMotivoId_Jsonclick = "";
         edtIncidenciaCodRef_Jsonclick = "";
         cmbIncidenciaOrigen_Jsonclick = "";
         edtIncidenciaId_Jsonclick = "";
         edtavAtender_Jsonclick = "";
         edtavAtender_Enabled = 1;
         subGrid1_Class = "GridWithPaginationBar WorkWith";
         subGrid1_Backcolorstyle = 0;
         cmbIncidenciaEstado.Enabled = 0;
         edtIncidenciaFechaAlta_Enabled = 0;
         edtIncidenciaUsrAlta_Enabled = 0;
         edtIncidenciaFechaActualizacion_Enabled = 0;
         edtMotivoNombre_Enabled = 0;
         cmbMotivoTipo.Enabled = 0;
         edtMotivoId_Enabled = 0;
         edtIncidenciaCodRef_Enabled = 0;
         cmbIncidenciaOrigen.Enabled = 0;
         edtIncidenciaId_Enabled = 0;
         edtavGrid1currentpage_Jsonclick = "";
         edtavGrid1currentpage_Visible = 1;
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
         subGrid1_Rows = 25;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E15B92',iparms:[]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV5Atender',fld:'vATENDER',pic:'',type:'char'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE","{handler:'E11B92',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'Grid1paginationbar_Selectedpage',ctrl:'GRID1PAGINATIONBAR',prop:'SelectedPage'},{av:'AV12Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV12Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12B92',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'Grid1paginationbar_Rowsperpageselectedvalue',ctrl:'GRID1PAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV12Grid1CurrentPage',fld:'vGRID1CURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VATENDER.CLICK","{handler:'E16B92',iparms:[]");
         setEventMetadata("VATENDER.CLICK",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOID","{handler:'Valid_Motivoid',iparms:[]");
         setEventMetadata("VALID_MOTIVOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Incidenciaestado',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV14Grid1AppliedFilters = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucGrid1paginationbar = new GXUserControl();
         ucToastr1 = new GXUserControl();
         TempTags = "";
         ucGrid1_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5Atender = "";
         A611IncidenciaOrigen = "";
         A606IncidenciaCodRef = "";
         A618MotivoTipo = "";
         A616MotivoNombre = "";
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         A615IncidenciaUsrAlta = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A608IncidenciaEstado = "";
         AV6IncidenciaFechaAlta = DateTime.MinValue;
         H00B92_A608IncidenciaEstado = new string[] {""} ;
         H00B92_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00B92_A615IncidenciaUsrAlta = new string[] {""} ;
         H00B92_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00B92_A616MotivoNombre = new string[] {""} ;
         H00B92_A618MotivoTipo = new string[] {""} ;
         H00B92_n618MotivoTipo = new bool[] {false} ;
         H00B92_A604MotivoId = new long[1] ;
         H00B92_A606IncidenciaCodRef = new string[] {""} ;
         H00B92_A611IncidenciaOrigen = new string[] {""} ;
         H00B92_A603IncidenciaId = new long[1] ;
         H00B93_AGRID1_nRecordCount = new long[1] ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidenciaslista__default(),
            new Object[][] {
                new Object[] {
               H00B92_A608IncidenciaEstado, H00B92_A610IncidenciaFechaAlta, H00B92_A615IncidenciaUsrAlta, H00B92_A609IncidenciaFechaActualizacion, H00B92_A616MotivoNombre, H00B92_A618MotivoTipo, H00B92_n618MotivoTipo, H00B92_A604MotivoId, H00B92_A606IncidenciaCodRef, H00B92_A611IncidenciaOrigen,
               H00B92_A603IncidenciaId
               }
               , new Object[] {
               H00B93_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         edtavAtender_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
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
      private int nRC_GXsfl_24 ;
      private int subGrid1_Rows ;
      private int nGXsfl_24_idx=1 ;
      private int edtavAtender_Enabled ;
      private int Grid1paginationbar_Pagestoshow ;
      private int edtavGrid1currentpage_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtIncidenciaId_Enabled ;
      private int edtIncidenciaCodRef_Enabled ;
      private int edtMotivoId_Enabled ;
      private int edtMotivoNombre_Enabled ;
      private int edtIncidenciaFechaActualizacion_Enabled ;
      private int edtIncidenciaUsrAlta_Enabled ;
      private int edtIncidenciaFechaAlta_Enabled ;
      private int AV11PageToGo ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV13Grid1PageCount ;
      private long AV12Grid1CurrentPage ;
      private long A603IncidenciaId ;
      private long A604MotivoId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string Grid1paginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_24_idx="0001" ;
      private string edtavAtender_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable1_Internalname ;
      private string divTable2_Internalname ;
      private string divGrid1tablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string Grid1paginationbar_Internalname ;
      private string divTable3_Internalname ;
      private string Toastr1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavGrid1currentpage_Internalname ;
      private string edtavGrid1currentpage_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV5Atender ;
      private string edtIncidenciaId_Internalname ;
      private string cmbIncidenciaOrigen_Internalname ;
      private string A611IncidenciaOrigen ;
      private string edtIncidenciaCodRef_Internalname ;
      private string edtMotivoId_Internalname ;
      private string cmbMotivoTipo_Internalname ;
      private string A618MotivoTipo ;
      private string A616MotivoNombre ;
      private string edtMotivoNombre_Internalname ;
      private string edtIncidenciaFechaActualizacion_Internalname ;
      private string A615IncidenciaUsrAlta ;
      private string edtIncidenciaUsrAlta_Internalname ;
      private string edtIncidenciaFechaAlta_Internalname ;
      private string cmbIncidenciaEstado_Internalname ;
      private string A608IncidenciaEstado ;
      private string sGXsfl_24_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavAtender_Jsonclick ;
      private string edtIncidenciaId_Jsonclick ;
      private string GXCCtl ;
      private string cmbIncidenciaOrigen_Jsonclick ;
      private string edtIncidenciaCodRef_Jsonclick ;
      private string edtMotivoId_Jsonclick ;
      private string cmbMotivoTipo_Jsonclick ;
      private string edtMotivoNombre_Jsonclick ;
      private string edtIncidenciaFechaActualizacion_Jsonclick ;
      private string edtIncidenciaUsrAlta_Jsonclick ;
      private string edtIncidenciaFechaAlta_Jsonclick ;
      private string cmbIncidenciaEstado_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime AV6IncidenciaFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool Grid1paginationbar_Showfirst ;
      private bool Grid1paginationbar_Showprevious ;
      private bool Grid1paginationbar_Shownext ;
      private bool Grid1paginationbar_Showlast ;
      private bool Grid1paginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n618MotivoTipo ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9IsAuthorized_IncidenciaOrigen ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private string AV14Grid1AppliedFilters ;
      private string A606IncidenciaCodRef ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucGrid1paginationbar ;
      private GXUserControl ucToastr1 ;
      private GXUserControl ucGrid1_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbIncidenciaOrigen ;
      private GXCombobox cmbMotivoTipo ;
      private GXCombobox cmbIncidenciaEstado ;
      private IDataStoreProvider pr_default ;
      private string[] H00B92_A608IncidenciaEstado ;
      private DateTime[] H00B92_A610IncidenciaFechaAlta ;
      private string[] H00B92_A615IncidenciaUsrAlta ;
      private DateTime[] H00B92_A609IncidenciaFechaActualizacion ;
      private string[] H00B92_A616MotivoNombre ;
      private string[] H00B92_A618MotivoTipo ;
      private bool[] H00B92_n618MotivoTipo ;
      private long[] H00B92_A604MotivoId ;
      private string[] H00B92_A606IncidenciaCodRef ;
      private string[] H00B92_A611IncidenciaOrigen ;
      private long[] H00B92_A603IncidenciaId ;
      private long[] H00B93_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class incidenciaslista__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00B92;
          prmH00B92 = new Object[] {
          new ParDef("@AV6IncidenciaFechaAlta",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00B93;
          prmH00B93 = new Object[] {
          new ParDef("@AV6IncidenciaFechaAlta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00B92", "SELECT T1.[IncidenciaEstado], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T1.[IncidenciaFechaActualizacion], T2.[MotivoNombre], T2.[MotivoTipo], T1.[MotivoId], T1.[IncidenciaCodRef], T1.[IncidenciaOrigen], T1.[IncidenciaId] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId]) WHERE T1.[IncidenciaFechaAlta] >= @AV6IncidenciaFechaAlta ORDER BY T1.[IncidenciaId] DESC  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B92,26, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00B93", "SELECT COUNT(*) FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId]) WHERE T1.[IncidenciaFechaAlta] >= @AV6IncidenciaFechaAlta ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B93,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

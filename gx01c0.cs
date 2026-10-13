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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx01c0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01c0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01c0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pMailId )
      {
         this.AV12pMailId = 0 ;
         ExecutePrivate();
         aP0_pMailId=this.AV12pMailId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCmailestado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pMailId");
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
               gxfirstwebparm = GetFirstPar( "pMailId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pMailId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV12pMailId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pMailId", StringUtil.LTrimStr( (decimal)(AV12pMailId), 18, 0));
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
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cMailId = (long)(Math.Round(NumberUtil.Val( GetPar( "cMailId"), "."), 18, MidpointRounding.ToEven));
         AV7cMailCuentaNombre = GetPar( "cMailCuentaNombre");
         AV8cMailDireccion = GetPar( "cMailDireccion");
         AV9cMailPawword = GetPar( "cMailPawword");
         AV10cMailPuertoSMTP = (long)(Math.Round(NumberUtil.Val( GetPar( "cMailPuertoSMTP"), "."), 18, MidpointRounding.ToEven));
         cmbavCmailestado.FromJSonString( GetNextPar( ));
         AV11cMailEstado = GetPar( "cMailEstado");
         AV14cMailSender = GetPar( "cMailSender");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cMailId, AV7cMailCuentaNombre, AV8cMailDireccion, AV9cMailPawword, AV10cMailPuertoSMTP, AV11cMailEstado, AV14cMailSender) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
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
         PA9O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9O2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01c0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pMailId,18,0))}, new string[] {"pMailId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILCUENTANOMBRE", StringUtil.RTrim( AV7cMailCuentaNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDIRECCION", AV8cMailDireccion);
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILPAWWORD", StringUtil.RTrim( AV9cMailPawword));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILPUERTOSMTP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cMailPuertoSMTP), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILESTADO", StringUtil.RTrim( AV11cMailEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILSENDER", AV14cMailSender);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pMailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divMailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILCUENTANOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divMailcuentanombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILDIRECCIONFILTERCONTAINER_Class", StringUtil.RTrim( divMaildireccionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILPAWWORDFILTERCONTAINER_Class", StringUtil.RTrim( divMailpawwordfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILPUERTOSMTPFILTERCONTAINER_Class", StringUtil.RTrim( divMailpuertosmtpfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divMailestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILSENDERFILTERCONTAINER_Class", StringUtil.RTrim( divMailsenderfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE9O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9O2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx01c0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pMailId,18,0))}, new string[] {"pMailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01C0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Mail", "") ;
      }

      protected void WB9O0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMailidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLblmailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmailid_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCmailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cMailId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cMailId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmailid_Visible, edtavCmailid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01C0.htm");
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
            GxWebStd.gx_div_start( context, divMailcuentanombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailcuentanombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailcuentanombrefilter_Internalname, context.GetMessage( "Nombre de la Cuenta", ""), "", "", lblLblmailcuentanombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmailcuentanombre_Internalname, context.GetMessage( "Nombre de la Cuenta", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmailcuentanombre_Internalname, StringUtil.RTrim( AV7cMailCuentaNombre), StringUtil.RTrim( context.localUtil.Format( AV7cMailCuentaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmailcuentanombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmailcuentanombre_Visible, edtavCmailcuentanombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01C0.htm");
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
            GxWebStd.gx_div_start( context, divMaildireccionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildireccionfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildireccionfilter_Internalname, context.GetMessage( "Mail Direccion", ""), "", "", lblLblmaildireccionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmaildireccion_Internalname, context.GetMessage( "Mail Direccion", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmaildireccion_Internalname, AV8cMailDireccion, StringUtil.RTrim( context.localUtil.Format( AV8cMailDireccion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmaildireccion_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmaildireccion_Visible, edtavCmaildireccion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01C0.htm");
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
            GxWebStd.gx_div_start( context, divMailpawwordfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailpawwordfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailpawwordfilter_Internalname, context.GetMessage( "Mail Pawword", ""), "", "", lblLblmailpawwordfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmailpawword_Internalname, context.GetMessage( "Mail Pawword", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmailpawword_Internalname, StringUtil.RTrim( AV9cMailPawword), StringUtil.RTrim( context.localUtil.Format( AV9cMailPawword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmailpawword_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmailpawword_Visible, edtavCmailpawword_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_Gx01C0.htm");
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
            GxWebStd.gx_div_start( context, divMailpuertosmtpfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailpuertosmtpfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailpuertosmtpfilter_Internalname, context.GetMessage( "Port SMTP", ""), "", "", lblLblmailpuertosmtpfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmailpuertosmtp_Internalname, context.GetMessage( "Port SMTP", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmailpuertosmtp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cMailPuertoSMTP), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCmailpuertosmtp_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cMailPuertoSMTP), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10cMailPuertoSMTP), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmailpuertosmtp_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmailpuertosmtp_Visible, edtavCmailpuertosmtp_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01C0.htm");
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
            GxWebStd.gx_div_start( context, divMailestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailestadofilter_Internalname, context.GetMessage( "Mail Estado", ""), "", "", lblLblmailestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmailestado_Internalname, context.GetMessage( "Mail Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmailestado, cmbavCmailestado_Internalname, StringUtil.RTrim( AV11cMailEstado), 1, cmbavCmailestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCmailestado.Visible, cmbavCmailestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_Gx01C0.htm");
            cmbavCmailestado.CurrentValue = StringUtil.RTrim( AV11cMailEstado);
            AssignProp("", false, cmbavCmailestado_Internalname, "Values", (string)(cmbavCmailestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divMailsenderfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailsenderfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailsenderfilter_Internalname, context.GetMessage( "Mail de Envio", ""), "", "", lblLblmailsenderfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e179o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmailsender_Internalname, context.GetMessage( "Mail de Envio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmailsender_Internalname, AV14cMailSender, StringUtil.RTrim( context.localUtil.Format( AV14cMailSender, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmailsender_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmailsender_Visible, edtavCmailsender_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e189o1_client"+"'", TempTags, "", 2, "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01C0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
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
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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

      protected void START9O2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Mail", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9O0( ) ;
      }

      protected void WS9O2( )
      {
         START9O2( ) ;
         EVT9O2( ) ;
      }

      protected void EVT9O2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A241MailCuentaNombre = cgiGet( edtMailCuentaNombre_Internalname);
                              A255MailPawword = cgiGet( edtMailPawword_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E199O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E209O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmailid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMailId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmailcuentanombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILCUENTANOMBRE"), AV7cMailCuentaNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmaildireccion Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDIRECCION"), AV8cMailDireccion) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmailpawword Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILPAWWORD"), AV9cMailPawword) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmailpuertosmtp Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILPUERTOSMTP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cMailPuertoSMTP )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmailestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILESTADO"), AV11cMailEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmailsender Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILSENDER"), AV14cMailSender) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E219O2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE9O2( )
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

      protected void PA9O2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cMailId ,
                                        string AV7cMailCuentaNombre ,
                                        string AV8cMailDireccion ,
                                        string AV9cMailPawword ,
                                        long AV10cMailPuertoSMTP ,
                                        string AV11cMailEstado ,
                                        string AV14cMailSender )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, ".", "")));
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
         if ( cmbavCmailestado.ItemCount > 0 )
         {
            AV11cMailEstado = cmbavCmailestado.getValidValue(AV11cMailEstado);
            AssignAttri("", false, "AV11cMailEstado", AV11cMailEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmailestado.CurrentValue = StringUtil.RTrim( AV11cMailEstado);
            AssignProp("", false, cmbavCmailestado_Internalname, "Values", cmbavCmailestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cMailCuentaNombre ,
                                                 AV8cMailDireccion ,
                                                 AV9cMailPawword ,
                                                 AV10cMailPuertoSMTP ,
                                                 AV11cMailEstado ,
                                                 AV14cMailSender ,
                                                 A241MailCuentaNombre ,
                                                 A242MailDireccion ,
                                                 A255MailPawword ,
                                                 A248MailPuertoSMTP ,
                                                 A243MailEstado ,
                                                 A714MailSender ,
                                                 AV6cMailId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV7cMailCuentaNombre = StringUtil.PadR( StringUtil.RTrim( AV7cMailCuentaNombre), 80, "%");
            lV8cMailDireccion = StringUtil.Concat( StringUtil.RTrim( AV8cMailDireccion), "%", "");
            lV9cMailPawword = StringUtil.PadR( StringUtil.RTrim( AV9cMailPawword), 20, "%");
            lV11cMailEstado = StringUtil.PadR( StringUtil.RTrim( AV11cMailEstado), 3, "%");
            lV14cMailSender = StringUtil.Concat( StringUtil.RTrim( AV14cMailSender), "%", "");
            /* Using cursor H009O2 */
            pr_default.execute(0, new Object[] {AV6cMailId, lV7cMailCuentaNombre, lV8cMailDireccion, lV9cMailPawword, AV10cMailPuertoSMTP, lV11cMailEstado, lV14cMailSender, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A714MailSender = H009O2_A714MailSender[0];
               n714MailSender = H009O2_n714MailSender[0];
               A243MailEstado = H009O2_A243MailEstado[0];
               A248MailPuertoSMTP = H009O2_A248MailPuertoSMTP[0];
               A242MailDireccion = H009O2_A242MailDireccion[0];
               A255MailPawword = H009O2_A255MailPawword[0];
               A241MailCuentaNombre = H009O2_A241MailCuentaNombre[0];
               A149MailId = H009O2_A149MailId[0];
               /* Execute user event: Load */
               E209O2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB9O0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9O2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAILID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cMailCuentaNombre ,
                                              AV8cMailDireccion ,
                                              AV9cMailPawword ,
                                              AV10cMailPuertoSMTP ,
                                              AV11cMailEstado ,
                                              AV14cMailSender ,
                                              A241MailCuentaNombre ,
                                              A242MailDireccion ,
                                              A255MailPawword ,
                                              A248MailPuertoSMTP ,
                                              A243MailEstado ,
                                              A714MailSender ,
                                              AV6cMailId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV7cMailCuentaNombre = StringUtil.PadR( StringUtil.RTrim( AV7cMailCuentaNombre), 80, "%");
         lV8cMailDireccion = StringUtil.Concat( StringUtil.RTrim( AV8cMailDireccion), "%", "");
         lV9cMailPawword = StringUtil.PadR( StringUtil.RTrim( AV9cMailPawword), 20, "%");
         lV11cMailEstado = StringUtil.PadR( StringUtil.RTrim( AV11cMailEstado), 3, "%");
         lV14cMailSender = StringUtil.Concat( StringUtil.RTrim( AV14cMailSender), "%", "");
         /* Using cursor H009O3 */
         pr_default.execute(1, new Object[] {AV6cMailId, lV7cMailCuentaNombre, lV8cMailDireccion, lV9cMailPawword, AV10cMailPuertoSMTP, lV11cMailEstado, lV14cMailSender});
         GRID1_nRecordCount = H009O3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailId, AV7cMailCuentaNombre, AV8cMailDireccion, AV9cMailPawword, AV10cMailPuertoSMTP, AV11cMailEstado, AV14cMailSender) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailId, AV7cMailCuentaNombre, AV8cMailDireccion, AV9cMailPawword, AV10cMailPuertoSMTP, AV11cMailEstado, AV14cMailSender) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailId, AV7cMailCuentaNombre, AV8cMailDireccion, AV9cMailPawword, AV10cMailPuertoSMTP, AV11cMailEstado, AV14cMailSender) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailId, AV7cMailCuentaNombre, AV8cMailDireccion, AV9cMailPawword, AV10cMailPuertoSMTP, AV11cMailEstado, AV14cMailSender) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailId, AV7cMailCuentaNombre, AV8cMailDireccion, AV9cMailPawword, AV10cMailPuertoSMTP, AV11cMailEstado, AV14cMailSender) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtMailId_Enabled = 0;
         edtMailCuentaNombre_Enabled = 0;
         edtMailPawword_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E199O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMAILID");
               GX_FocusControl = edtavCmailid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cMailId = 0;
               AssignAttri("", false, "AV6cMailId", StringUtil.LTrimStr( (decimal)(AV6cMailId), 18, 0));
            }
            else
            {
               AV6cMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cMailId", StringUtil.LTrimStr( (decimal)(AV6cMailId), 18, 0));
            }
            AV7cMailCuentaNombre = cgiGet( edtavCmailcuentanombre_Internalname);
            AssignAttri("", false, "AV7cMailCuentaNombre", AV7cMailCuentaNombre);
            AV8cMailDireccion = cgiGet( edtavCmaildireccion_Internalname);
            AssignAttri("", false, "AV8cMailDireccion", AV8cMailDireccion);
            AV9cMailPawword = cgiGet( edtavCmailpawword_Internalname);
            AssignAttri("", false, "AV9cMailPawword", AV9cMailPawword);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmailpuertosmtp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmailpuertosmtp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMAILPUERTOSMTP");
               GX_FocusControl = edtavCmailpuertosmtp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cMailPuertoSMTP = 0;
               AssignAttri("", false, "AV10cMailPuertoSMTP", StringUtil.LTrimStr( (decimal)(AV10cMailPuertoSMTP), 10, 0));
            }
            else
            {
               AV10cMailPuertoSMTP = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmailpuertosmtp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cMailPuertoSMTP", StringUtil.LTrimStr( (decimal)(AV10cMailPuertoSMTP), 10, 0));
            }
            cmbavCmailestado.Name = cmbavCmailestado_Internalname;
            cmbavCmailestado.CurrentValue = cgiGet( cmbavCmailestado_Internalname);
            AV11cMailEstado = cgiGet( cmbavCmailestado_Internalname);
            AssignAttri("", false, "AV11cMailEstado", AV11cMailEstado);
            AV14cMailSender = cgiGet( edtavCmailsender_Internalname);
            AssignAttri("", false, "AV14cMailSender", AV14cMailSender);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILCUENTANOMBRE"), AV7cMailCuentaNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDIRECCION"), AV8cMailDireccion) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILPAWWORD"), AV9cMailPawword) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILPUERTOSMTP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cMailPuertoSMTP )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILESTADO"), AV11cMailEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILSENDER"), AV14cMailSender) != 0 )
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
         E199O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E199O2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Mail", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E209O2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E219O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E219O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pMailId = A149MailId;
         AssignAttri("", false, "AV12pMailId", StringUtil.LTrimStr( (decimal)(AV12pMailId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pMailId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pMailId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pMailId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pMailId", StringUtil.LTrimStr( (decimal)(AV12pMailId), 18, 0));
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
         PA9O2( ) ;
         WS9O2( ) ;
         WE9O2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126267", true, true, false);
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
         context.AddJavascriptSource("gx01c0.js", "?20267302126268", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtMailId_Internalname = "MAILID_"+sGXsfl_84_idx;
         edtMailCuentaNombre_Internalname = "MAILCUENTANOMBRE_"+sGXsfl_84_idx;
         edtMailPawword_Internalname = "MAILPAWWORD_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtMailId_Internalname = "MAILID_"+sGXsfl_84_fel_idx;
         edtMailCuentaNombre_Internalname = "MAILCUENTANOMBRE_"+sGXsfl_84_fel_idx;
         edtMailPawword_Internalname = "MAILPAWWORD_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB9O0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailCuentaNombre_Internalname,StringUtil.RTrim( A241MailCuentaNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailCuentaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailPawword_Internalname,StringUtil.RTrim( A255MailPawword),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailPawword_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)-1,(short)0,(short)84,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes9O2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCmailestado.Name = "vCMAILESTADO";
         cmbavCmailestado.WebTags = "";
         cmbavCmailestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCmailestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbavCmailestado.ItemCount > 0 )
         {
            AV11cMailEstado = cmbavCmailestado.getValidValue(AV11cMailEstado);
            AssignAttri("", false, "AV11cMailEstado", AV11cMailEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Cuenta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pawword", "")) ;
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
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A241MailCuentaNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A255MailPawword)));
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
         lblLblmailidfilter_Internalname = "LBLMAILIDFILTER";
         edtavCmailid_Internalname = "vCMAILID";
         divMailidfiltercontainer_Internalname = "MAILIDFILTERCONTAINER";
         lblLblmailcuentanombrefilter_Internalname = "LBLMAILCUENTANOMBREFILTER";
         edtavCmailcuentanombre_Internalname = "vCMAILCUENTANOMBRE";
         divMailcuentanombrefiltercontainer_Internalname = "MAILCUENTANOMBREFILTERCONTAINER";
         lblLblmaildireccionfilter_Internalname = "LBLMAILDIRECCIONFILTER";
         edtavCmaildireccion_Internalname = "vCMAILDIRECCION";
         divMaildireccionfiltercontainer_Internalname = "MAILDIRECCIONFILTERCONTAINER";
         lblLblmailpawwordfilter_Internalname = "LBLMAILPAWWORDFILTER";
         edtavCmailpawword_Internalname = "vCMAILPAWWORD";
         divMailpawwordfiltercontainer_Internalname = "MAILPAWWORDFILTERCONTAINER";
         lblLblmailpuertosmtpfilter_Internalname = "LBLMAILPUERTOSMTPFILTER";
         edtavCmailpuertosmtp_Internalname = "vCMAILPUERTOSMTP";
         divMailpuertosmtpfiltercontainer_Internalname = "MAILPUERTOSMTPFILTERCONTAINER";
         lblLblmailestadofilter_Internalname = "LBLMAILESTADOFILTER";
         cmbavCmailestado_Internalname = "vCMAILESTADO";
         divMailestadofiltercontainer_Internalname = "MAILESTADOFILTERCONTAINER";
         lblLblmailsenderfilter_Internalname = "LBLMAILSENDERFILTER";
         edtavCmailsender_Internalname = "vCMAILSENDER";
         divMailsenderfiltercontainer_Internalname = "MAILSENDERFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtMailId_Internalname = "MAILID";
         edtMailCuentaNombre_Internalname = "MAILCUENTANOMBRE";
         edtMailPawword_Internalname = "MAILPAWWORD";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
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
         edtMailPawword_Jsonclick = "";
         edtMailCuentaNombre_Jsonclick = "";
         edtMailId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtMailPawword_Enabled = 0;
         edtMailCuentaNombre_Enabled = 0;
         edtMailId_Enabled = 0;
         edtavCmailsender_Jsonclick = "";
         edtavCmailsender_Enabled = 1;
         edtavCmailsender_Visible = 1;
         cmbavCmailestado_Jsonclick = "";
         cmbavCmailestado.Visible = 1;
         cmbavCmailestado.Enabled = 1;
         edtavCmailpuertosmtp_Jsonclick = "";
         edtavCmailpuertosmtp_Enabled = 1;
         edtavCmailpuertosmtp_Visible = 1;
         edtavCmailpawword_Jsonclick = "";
         edtavCmailpawword_Enabled = 1;
         edtavCmailpawword_Visible = 1;
         edtavCmaildireccion_Jsonclick = "";
         edtavCmaildireccion_Enabled = 1;
         edtavCmaildireccion_Visible = 1;
         edtavCmailcuentanombre_Jsonclick = "";
         edtavCmailcuentanombre_Enabled = 1;
         edtavCmailcuentanombre_Visible = 1;
         edtavCmailid_Jsonclick = "";
         edtavCmailid_Enabled = 1;
         edtavCmailid_Visible = 1;
         divMailsenderfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMailestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMailpuertosmtpfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMailpawwordfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMaildireccionfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMailcuentanombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMailidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Mail", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMailCuentaNombre',fld:'vCMAILCUENTANOMBRE',pic:'',type:'char'},{av:'AV8cMailDireccion',fld:'vCMAILDIRECCION',pic:'',type:'svchar'},{av:'AV9cMailPawword',fld:'vCMAILPAWWORD',pic:'',type:'char'},{av:'AV10cMailPuertoSMTP',fld:'vCMAILPUERTOSMTP',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCmailestado'},{av:'AV11cMailEstado',fld:'vCMAILESTADO',pic:'',type:'char'},{av:'AV14cMailSender',fld:'vCMAILSENDER',pic:'',type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E189O1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLMAILIDFILTER.CLICK","{handler:'E119O1',iparms:[{av:'divMailidfiltercontainer_Class',ctrl:'MAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILIDFILTER.CLICK",",oparms:[{av:'divMailidfiltercontainer_Class',ctrl:'MAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCmailid_Visible',ctrl:'vCMAILID',prop:'Visible'}]}");
         setEventMetadata("LBLMAILCUENTANOMBREFILTER.CLICK","{handler:'E129O1',iparms:[{av:'divMailcuentanombrefiltercontainer_Class',ctrl:'MAILCUENTANOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILCUENTANOMBREFILTER.CLICK",",oparms:[{av:'divMailcuentanombrefiltercontainer_Class',ctrl:'MAILCUENTANOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCmailcuentanombre_Visible',ctrl:'vCMAILCUENTANOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLMAILDIRECCIONFILTER.CLICK","{handler:'E139O1',iparms:[{av:'divMaildireccionfiltercontainer_Class',ctrl:'MAILDIRECCIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDIRECCIONFILTER.CLICK",",oparms:[{av:'divMaildireccionfiltercontainer_Class',ctrl:'MAILDIRECCIONFILTERCONTAINER',prop:'Class'},{av:'edtavCmaildireccion_Visible',ctrl:'vCMAILDIRECCION',prop:'Visible'}]}");
         setEventMetadata("LBLMAILPAWWORDFILTER.CLICK","{handler:'E149O1',iparms:[{av:'divMailpawwordfiltercontainer_Class',ctrl:'MAILPAWWORDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILPAWWORDFILTER.CLICK",",oparms:[{av:'divMailpawwordfiltercontainer_Class',ctrl:'MAILPAWWORDFILTERCONTAINER',prop:'Class'},{av:'edtavCmailpawword_Visible',ctrl:'vCMAILPAWWORD',prop:'Visible'}]}");
         setEventMetadata("LBLMAILPUERTOSMTPFILTER.CLICK","{handler:'E159O1',iparms:[{av:'divMailpuertosmtpfiltercontainer_Class',ctrl:'MAILPUERTOSMTPFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILPUERTOSMTPFILTER.CLICK",",oparms:[{av:'divMailpuertosmtpfiltercontainer_Class',ctrl:'MAILPUERTOSMTPFILTERCONTAINER',prop:'Class'},{av:'edtavCmailpuertosmtp_Visible',ctrl:'vCMAILPUERTOSMTP',prop:'Visible'}]}");
         setEventMetadata("LBLMAILESTADOFILTER.CLICK","{handler:'E169O1',iparms:[{av:'divMailestadofiltercontainer_Class',ctrl:'MAILESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILESTADOFILTER.CLICK",",oparms:[{av:'divMailestadofiltercontainer_Class',ctrl:'MAILESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCmailestado'}]}");
         setEventMetadata("LBLMAILSENDERFILTER.CLICK","{handler:'E179O1',iparms:[{av:'divMailsenderfiltercontainer_Class',ctrl:'MAILSENDERFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILSENDERFILTER.CLICK",",oparms:[{av:'divMailsenderfiltercontainer_Class',ctrl:'MAILSENDERFILTERCONTAINER',prop:'Class'},{av:'edtavCmailsender_Visible',ctrl:'vCMAILSENDER',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E219O2',iparms:[{av:'A149MailId',fld:'MAILID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pMailId',fld:'vPMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMailCuentaNombre',fld:'vCMAILCUENTANOMBRE',pic:'',type:'char'},{av:'AV8cMailDireccion',fld:'vCMAILDIRECCION',pic:'',type:'svchar'},{av:'AV9cMailPawword',fld:'vCMAILPAWWORD',pic:'',type:'char'},{av:'AV10cMailPuertoSMTP',fld:'vCMAILPUERTOSMTP',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCmailestado'},{av:'AV11cMailEstado',fld:'vCMAILESTADO',pic:'',type:'char'},{av:'AV14cMailSender',fld:'vCMAILSENDER',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMailCuentaNombre',fld:'vCMAILCUENTANOMBRE',pic:'',type:'char'},{av:'AV8cMailDireccion',fld:'vCMAILDIRECCION',pic:'',type:'svchar'},{av:'AV9cMailPawword',fld:'vCMAILPAWWORD',pic:'',type:'char'},{av:'AV10cMailPuertoSMTP',fld:'vCMAILPUERTOSMTP',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCmailestado'},{av:'AV11cMailEstado',fld:'vCMAILESTADO',pic:'',type:'char'},{av:'AV14cMailSender',fld:'vCMAILSENDER',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMailCuentaNombre',fld:'vCMAILCUENTANOMBRE',pic:'',type:'char'},{av:'AV8cMailDireccion',fld:'vCMAILDIRECCION',pic:'',type:'svchar'},{av:'AV9cMailPawword',fld:'vCMAILPAWWORD',pic:'',type:'char'},{av:'AV10cMailPuertoSMTP',fld:'vCMAILPUERTOSMTP',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCmailestado'},{av:'AV11cMailEstado',fld:'vCMAILESTADO',pic:'',type:'char'},{av:'AV14cMailSender',fld:'vCMAILSENDER',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMailCuentaNombre',fld:'vCMAILCUENTANOMBRE',pic:'',type:'char'},{av:'AV8cMailDireccion',fld:'vCMAILDIRECCION',pic:'',type:'svchar'},{av:'AV9cMailPawword',fld:'vCMAILPAWWORD',pic:'',type:'char'},{av:'AV10cMailPuertoSMTP',fld:'vCMAILPUERTOSMTP',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCmailestado'},{av:'AV11cMailEstado',fld:'vCMAILESTADO',pic:'',type:'char'},{av:'AV14cMailSender',fld:'vCMAILSENDER',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CMAILSENDER","{handler:'Validv_Cmailsender',iparms:[]");
         setEventMetadata("VALIDV_CMAILSENDER",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Mailpawword',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cMailCuentaNombre = "";
         AV8cMailDireccion = "";
         AV9cMailPawword = "";
         AV11cMailEstado = "";
         AV14cMailSender = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmailidfilter_Jsonclick = "";
         TempTags = "";
         lblLblmailcuentanombrefilter_Jsonclick = "";
         lblLblmaildireccionfilter_Jsonclick = "";
         lblLblmailpawwordfilter_Jsonclick = "";
         lblLblmailpuertosmtpfilter_Jsonclick = "";
         lblLblmailestadofilter_Jsonclick = "";
         lblLblmailsenderfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         A241MailCuentaNombre = "";
         A255MailPawword = "";
         lV7cMailCuentaNombre = "";
         lV8cMailDireccion = "";
         lV9cMailPawword = "";
         lV11cMailEstado = "";
         lV14cMailSender = "";
         A242MailDireccion = "";
         A243MailEstado = "";
         A714MailSender = "";
         H009O2_A714MailSender = new string[] {""} ;
         H009O2_n714MailSender = new bool[] {false} ;
         H009O2_A243MailEstado = new string[] {""} ;
         H009O2_A248MailPuertoSMTP = new long[1] ;
         H009O2_A242MailDireccion = new string[] {""} ;
         H009O2_A255MailPawword = new string[] {""} ;
         H009O2_A241MailCuentaNombre = new string[] {""} ;
         H009O2_A149MailId = new long[1] ;
         H009O3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01c0__default(),
            new Object[][] {
                new Object[] {
               H009O2_A714MailSender, H009O2_n714MailSender, H009O2_A243MailEstado, H009O2_A248MailPuertoSMTP, H009O2_A242MailDireccion, H009O2_A255MailPawword, H009O2_A241MailCuentaNombre, H009O2_A149MailId
               }
               , new Object[] {
               H009O3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCmailid_Enabled ;
      private int edtavCmailid_Visible ;
      private int edtavCmailcuentanombre_Visible ;
      private int edtavCmailcuentanombre_Enabled ;
      private int edtavCmaildireccion_Visible ;
      private int edtavCmaildireccion_Enabled ;
      private int edtavCmailpawword_Visible ;
      private int edtavCmailpawword_Enabled ;
      private int edtavCmailpuertosmtp_Enabled ;
      private int edtavCmailpuertosmtp_Visible ;
      private int edtavCmailsender_Visible ;
      private int edtavCmailsender_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtMailId_Enabled ;
      private int edtMailCuentaNombre_Enabled ;
      private int edtMailPawword_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pMailId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cMailId ;
      private long AV10cMailPuertoSMTP ;
      private long A149MailId ;
      private long GRID1_nCurrentRecord ;
      private long A248MailPuertoSMTP ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divMailidfiltercontainer_Class ;
      private string divMailcuentanombrefiltercontainer_Class ;
      private string divMaildireccionfiltercontainer_Class ;
      private string divMailpawwordfiltercontainer_Class ;
      private string divMailpuertosmtpfiltercontainer_Class ;
      private string divMailestadofiltercontainer_Class ;
      private string divMailsenderfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cMailCuentaNombre ;
      private string AV9cMailPawword ;
      private string AV11cMailEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divMailidfiltercontainer_Internalname ;
      private string lblLblmailidfilter_Internalname ;
      private string lblLblmailidfilter_Jsonclick ;
      private string edtavCmailid_Internalname ;
      private string TempTags ;
      private string edtavCmailid_Jsonclick ;
      private string divMailcuentanombrefiltercontainer_Internalname ;
      private string lblLblmailcuentanombrefilter_Internalname ;
      private string lblLblmailcuentanombrefilter_Jsonclick ;
      private string edtavCmailcuentanombre_Internalname ;
      private string edtavCmailcuentanombre_Jsonclick ;
      private string divMaildireccionfiltercontainer_Internalname ;
      private string lblLblmaildireccionfilter_Internalname ;
      private string lblLblmaildireccionfilter_Jsonclick ;
      private string edtavCmaildireccion_Internalname ;
      private string edtavCmaildireccion_Jsonclick ;
      private string divMailpawwordfiltercontainer_Internalname ;
      private string lblLblmailpawwordfilter_Internalname ;
      private string lblLblmailpawwordfilter_Jsonclick ;
      private string edtavCmailpawword_Internalname ;
      private string edtavCmailpawword_Jsonclick ;
      private string divMailpuertosmtpfiltercontainer_Internalname ;
      private string lblLblmailpuertosmtpfilter_Internalname ;
      private string lblLblmailpuertosmtpfilter_Jsonclick ;
      private string edtavCmailpuertosmtp_Internalname ;
      private string edtavCmailpuertosmtp_Jsonclick ;
      private string divMailestadofiltercontainer_Internalname ;
      private string lblLblmailestadofilter_Internalname ;
      private string lblLblmailestadofilter_Jsonclick ;
      private string cmbavCmailestado_Internalname ;
      private string cmbavCmailestado_Jsonclick ;
      private string divMailsenderfiltercontainer_Internalname ;
      private string lblLblmailsenderfilter_Internalname ;
      private string lblLblmailsenderfilter_Jsonclick ;
      private string edtavCmailsender_Internalname ;
      private string edtavCmailsender_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtMailId_Internalname ;
      private string A241MailCuentaNombre ;
      private string edtMailCuentaNombre_Internalname ;
      private string A255MailPawword ;
      private string edtMailPawword_Internalname ;
      private string lV7cMailCuentaNombre ;
      private string lV9cMailPawword ;
      private string lV11cMailEstado ;
      private string A243MailEstado ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtMailId_Jsonclick ;
      private string edtMailCuentaNombre_Jsonclick ;
      private string edtMailPawword_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n714MailSender ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV8cMailDireccion ;
      private string AV14cMailSender ;
      private string AV15Linkselection_GXI ;
      private string lV8cMailDireccion ;
      private string lV14cMailSender ;
      private string A242MailDireccion ;
      private string A714MailSender ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCmailestado ;
      private IDataStoreProvider pr_default ;
      private string[] H009O2_A714MailSender ;
      private bool[] H009O2_n714MailSender ;
      private string[] H009O2_A243MailEstado ;
      private long[] H009O2_A248MailPuertoSMTP ;
      private string[] H009O2_A242MailDireccion ;
      private string[] H009O2_A255MailPawword ;
      private string[] H009O2_A241MailCuentaNombre ;
      private long[] H009O2_A149MailId ;
      private long[] H009O3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pMailId ;
   }

   public class gx01c0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009O2( IGxContext context ,
                                             string AV7cMailCuentaNombre ,
                                             string AV8cMailDireccion ,
                                             string AV9cMailPawword ,
                                             long AV10cMailPuertoSMTP ,
                                             string AV11cMailEstado ,
                                             string AV14cMailSender ,
                                             string A241MailCuentaNombre ,
                                             string A242MailDireccion ,
                                             string A255MailPawword ,
                                             long A248MailPuertoSMTP ,
                                             string A243MailEstado ,
                                             string A714MailSender ,
                                             long AV6cMailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MailSender], [MailEstado], [MailPuertoSMTP], [MailDireccion], [MailPawword], [MailCuentaNombre], [MailId]";
         sFromString = " FROM [Mail]";
         sOrderString = "";
         AddWhere(sWhereString, "([MailId] >= @AV6cMailId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMailCuentaNombre)) )
         {
            AddWhere(sWhereString, "([MailCuentaNombre] like @lV7cMailCuentaNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cMailDireccion)) )
         {
            AddWhere(sWhereString, "([MailDireccion] like @lV8cMailDireccion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMailPawword)) )
         {
            AddWhere(sWhereString, "([MailPawword] like @lV9cMailPawword)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cMailPuertoSMTP) )
         {
            AddWhere(sWhereString, "([MailPuertoSMTP] >= @AV10cMailPuertoSMTP)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cMailEstado)) )
         {
            AddWhere(sWhereString, "([MailEstado] like @lV11cMailEstado)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cMailSender)) )
         {
            AddWhere(sWhereString, "([MailSender] like @lV14cMailSender)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [MailId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009O3( IGxContext context ,
                                             string AV7cMailCuentaNombre ,
                                             string AV8cMailDireccion ,
                                             string AV9cMailPawword ,
                                             long AV10cMailPuertoSMTP ,
                                             string AV11cMailEstado ,
                                             string AV14cMailSender ,
                                             string A241MailCuentaNombre ,
                                             string A242MailDireccion ,
                                             string A255MailPawword ,
                                             long A248MailPuertoSMTP ,
                                             string A243MailEstado ,
                                             string A714MailSender ,
                                             long AV6cMailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Mail]";
         AddWhere(sWhereString, "([MailId] >= @AV6cMailId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMailCuentaNombre)) )
         {
            AddWhere(sWhereString, "([MailCuentaNombre] like @lV7cMailCuentaNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cMailDireccion)) )
         {
            AddWhere(sWhereString, "([MailDireccion] like @lV8cMailDireccion)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMailPawword)) )
         {
            AddWhere(sWhereString, "([MailPawword] like @lV9cMailPawword)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cMailPuertoSMTP) )
         {
            AddWhere(sWhereString, "([MailPuertoSMTP] >= @AV10cMailPuertoSMTP)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cMailEstado)) )
         {
            AddWhere(sWhereString, "([MailEstado] like @lV11cMailEstado)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cMailSender)) )
         {
            AddWhere(sWhereString, "([MailSender] like @lV14cMailSender)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H009O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H009O3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH009O2;
          prmH009O2 = new Object[] {
          new ParDef("@AV6cMailId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMailCuentaNombre",GXType.NChar,80,0) ,
          new ParDef("@lV8cMailDireccion",GXType.NVarChar,100,0) ,
          new ParDef("@lV9cMailPawword",GXType.NChar,20,0) ,
          new ParDef("@AV10cMailPuertoSMTP",GXType.Decimal,10,0) ,
          new ParDef("@lV11cMailEstado",GXType.NChar,3,0) ,
          new ParDef("@lV14cMailSender",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009O3;
          prmH009O3 = new Object[] {
          new ParDef("@AV6cMailId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMailCuentaNombre",GXType.NChar,80,0) ,
          new ParDef("@lV8cMailDireccion",GXType.NVarChar,100,0) ,
          new ParDef("@lV9cMailPawword",GXType.NChar,20,0) ,
          new ParDef("@AV10cMailPuertoSMTP",GXType.Decimal,10,0) ,
          new ParDef("@lV11cMailEstado",GXType.NChar,3,0) ,
          new ParDef("@lV14cMailSender",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009O2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009O3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class gx00h0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00h0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00h0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pWWPMailId )
      {
         this.AV13pWWPMailId = 0 ;
         ExecutePrivate();
         aP0_pWWPMailId=this.AV13pWWPMailId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCwwpmailstatus = new GXCombobox();
         cmbWWPMailStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWWPMailId");
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
               gxfirstwebparm = GetFirstPar( "pWWPMailId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWWPMailId");
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
               AV13pWWPMailId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pWWPMailId", StringUtil.LTrimStr( (decimal)(AV13pWWPMailId), 10, 0));
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
         AV6cWWPMailId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPMailId"), "."), 18, MidpointRounding.ToEven));
         AV7cWWPMailSubject = GetPar( "cWWPMailSubject");
         cmbavCwwpmailstatus.FromJSonString( GetNextPar( ));
         AV8cWWPMailStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "cWWPMailStatus"), "."), 18, MidpointRounding.ToEven));
         AV9cWWPMailCreated = context.localUtil.ParseDTimeParm( GetPar( "cWWPMailCreated"));
         AV10cWWPMailScheduled = context.localUtil.ParseDTimeParm( GetPar( "cWWPMailScheduled"));
         AV11cWWPMailProcessed = context.localUtil.ParseDTimeParm( GetPar( "cWWPMailProcessed"));
         AV12cWWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPNotificationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPMailId, AV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId) ;
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
         PA8W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8W2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.gx00h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pWWPMailId,10,0))}, new string[] {"pWWPMailId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPMAILSUBJECT", AV7cWWPMailSubject);
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPMAILSTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cWWPMailStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPMAILCREATED", context.localUtil.TToC( AV9cWWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPMAILSCHEDULED", context.localUtil.TToC( AV10cWWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPMAILPROCESSED", context.localUtil.TToC( AV11cWWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cWWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPWWPMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pWWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WWPMAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpmailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPMAILSUBJECTFILTERCONTAINER_Class", StringUtil.RTrim( divWwpmailsubjectfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPMAILSTATUSFILTERCONTAINER_Class", StringUtil.RTrim( divWwpmailstatusfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpnotificationidfiltercontainer_Class));
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
            WE8W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8W2( ) ;
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
         return formatLink("wwpbaseobjects.mail.gx00h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pWWPMailId,10,0))}, new string[] {"pWWPMailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.Gx00H0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List WWP_Mail", "") ;
      }

      protected void WB8W0( )
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
            GxWebStd.gx_div_start( context, divWwpmailidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpmailidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpmailidfilter_Internalname, context.GetMessage( "Mail Id", ""), "", "", lblLblwwpmailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e118w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpmailid_Internalname, context.GetMessage( "Mail Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpmailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwwpmailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cWWPMailId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cWWPMailId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpmailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpmailid_Visible, edtavCwwpmailid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divWwpmailsubjectfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpmailsubjectfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpmailsubjectfilter_Internalname, context.GetMessage( "Mail Subject", ""), "", "", lblLblwwpmailsubjectfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e128w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpmailsubject_Internalname, context.GetMessage( "Mail Subject", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpmailsubject_Internalname, AV7cWWPMailSubject, StringUtil.RTrim( context.localUtil.Format( AV7cWWPMailSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpmailsubject_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpmailsubject_Visible, edtavCwwpmailsubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divWwpmailstatusfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpmailstatusfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpmailstatusfilter_Internalname, context.GetMessage( "Mail Status", ""), "", "", lblLblwwpmailstatusfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e138w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCwwpmailstatus_Internalname, context.GetMessage( "Mail Status", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCwwpmailstatus, cmbavCwwpmailstatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8cWWPMailStatus), 4, 0)), 1, cmbavCwwpmailstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCwwpmailstatus.Visible, cmbavCwwpmailstatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            cmbavCwwpmailstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8cWWPMailStatus), 4, 0));
            AssignProp("", false, cmbavCwwpmailstatus_Internalname, "Values", (string)(cmbavCwwpmailstatus.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divWwpmailcreatedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpmailcreatedfilter_Internalname, context.GetMessage( "Mail Created", ""), "", "", lblLblwwpmailcreatedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpmailcreated_Internalname, context.GetMessage( "Mail Created", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpmailcreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpmailcreated_Internalname, context.localUtil.TToC( AV9cWWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV9cWWPMailCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpmailcreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpmailcreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divWwpmailscheduledfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpmailscheduledfilter_Internalname, context.GetMessage( "Mail Scheduled", ""), "", "", lblLblwwpmailscheduledfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpmailscheduled_Internalname, context.GetMessage( "Mail Scheduled", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpmailscheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpmailscheduled_Internalname, context.localUtil.TToC( AV10cWWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV10cWWPMailScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpmailscheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpmailscheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divWwpmailprocessedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpmailprocessedfilter_Internalname, context.GetMessage( "Mail Processed", ""), "", "", lblLblwwpmailprocessedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpmailprocessed_Internalname, context.GetMessage( "Mail Processed", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpmailprocessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpmailprocessed_Internalname, context.localUtil.TToC( AV11cWWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV11cWWPMailProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpmailprocessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpmailprocessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divWwpnotificationidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpnotificationidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationidfilter_Internalname, context.GetMessage( "Notification Id", ""), "", "", lblLblwwpnotificationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e148w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpnotificationid_Internalname, context.GetMessage( "Notification Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cWWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwwpnotificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cWWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV12cWWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationid_Visible, edtavCwwpnotificationid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e158w1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/Gx00H0.htm");
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

      protected void START8W2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List WWP_Mail", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8W0( ) ;
      }

      protected void WS8W2( )
      {
         START8W2( ) ;
         EVT8W2( ) ;
      }

      protected void EVT8W2( )
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
                              A89WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A78WWPMailSubject = cgiGet( edtWWPMailSubject_Internalname);
                              cmbWWPMailStatus.Name = cmbWWPMailStatus_Internalname;
                              cmbWWPMailStatus.CurrentValue = cgiGet( cmbWWPMailStatus_Internalname);
                              A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPMailStatus_Internalname), "."), 18, MidpointRounding.ToEven));
                              A100WWPMailCreated = context.localUtil.CToT( cgiGet( edtWWPMailCreated_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E168W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E178W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwwpmailid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWWPMailId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpmailsubject Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPMAILSUBJECT"), AV7cWWPMailSubject) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpmailstatus Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPMAILSTATUS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cWWPMailStatus )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpmailcreated Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPMAILCREATED"), 0) != AV9cWWPMailCreated )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpmailscheduled Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPMAILSCHEDULED"), 0) != AV10cWWPMailScheduled )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpmailprocessed Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPMAILPROCESSED"), 0) != AV11cWWPMailProcessed )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cWWPNotificationId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E188W2 ();
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

      protected void WE8W2( )
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

      protected void PA8W2( )
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
                                        long AV6cWWPMailId ,
                                        string AV7cWWPMailSubject ,
                                        short AV8cWWPMailStatus ,
                                        DateTime AV9cWWPMailCreated ,
                                        DateTime AV10cWWPMailScheduled ,
                                        DateTime AV11cWWPMailProcessed ,
                                        long AV12cWWPNotificationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF8W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPMAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A89WWPMailId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPMailId), 10, 0, ".", "")));
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
         if ( cmbavCwwpmailstatus.ItemCount > 0 )
         {
            AV8cWWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbavCwwpmailstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8cWWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8cWWPMailStatus", StringUtil.LTrimStr( (decimal)(AV8cWWPMailStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCwwpmailstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8cWWPMailStatus), 4, 0));
            AssignProp("", false, cmbavCwwpmailstatus_Internalname, "Values", cmbavCwwpmailstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8W2( )
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
                                                 AV7cWWPMailSubject ,
                                                 AV8cWWPMailStatus ,
                                                 AV9cWWPMailCreated ,
                                                 AV10cWWPMailScheduled ,
                                                 AV11cWWPMailProcessed ,
                                                 AV12cWWPNotificationId ,
                                                 A78WWPMailSubject ,
                                                 A90WWPMailStatus ,
                                                 A100WWPMailCreated ,
                                                 A101WWPMailScheduled ,
                                                 A95WWPMailProcessed ,
                                                 A31WWPNotificationId ,
                                                 AV6cWWPMailId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV7cWWPMailSubject = StringUtil.Concat( StringUtil.RTrim( AV7cWWPMailSubject), "%", "");
            /* Using cursor H008W2 */
            pr_default.execute(0, new Object[] {AV6cWWPMailId, lV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A31WWPNotificationId = H008W2_A31WWPNotificationId[0];
               n31WWPNotificationId = H008W2_n31WWPNotificationId[0];
               A95WWPMailProcessed = H008W2_A95WWPMailProcessed[0];
               n95WWPMailProcessed = H008W2_n95WWPMailProcessed[0];
               A101WWPMailScheduled = H008W2_A101WWPMailScheduled[0];
               A100WWPMailCreated = H008W2_A100WWPMailCreated[0];
               A90WWPMailStatus = H008W2_A90WWPMailStatus[0];
               A78WWPMailSubject = H008W2_A78WWPMailSubject[0];
               A89WWPMailId = H008W2_A89WWPMailId[0];
               /* Execute user event: Load */
               E178W2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB8W0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8W2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPMAILID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A89WWPMailId), "ZZZZZZZZZ9"), context));
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
                                              AV7cWWPMailSubject ,
                                              AV8cWWPMailStatus ,
                                              AV9cWWPMailCreated ,
                                              AV10cWWPMailScheduled ,
                                              AV11cWWPMailProcessed ,
                                              AV12cWWPNotificationId ,
                                              A78WWPMailSubject ,
                                              A90WWPMailStatus ,
                                              A100WWPMailCreated ,
                                              A101WWPMailScheduled ,
                                              A95WWPMailProcessed ,
                                              A31WWPNotificationId ,
                                              AV6cWWPMailId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV7cWWPMailSubject = StringUtil.Concat( StringUtil.RTrim( AV7cWWPMailSubject), "%", "");
         /* Using cursor H008W3 */
         pr_default.execute(1, new Object[] {AV6cWWPMailId, lV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId});
         GRID1_nRecordCount = H008W3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPMailId, AV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPMailId, AV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPMailId, AV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPMailId, AV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPMailId, AV7cWWPMailSubject, AV8cWWPMailStatus, AV9cWWPMailCreated, AV10cWWPMailScheduled, AV11cWWPMailProcessed, AV12cWWPNotificationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWWPMailId_Enabled = 0;
         edtWWPMailSubject_Enabled = 0;
         cmbWWPMailStatus.Enabled = 0;
         edtWWPMailCreated_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E168W2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPMAILID");
               GX_FocusControl = edtavCwwpmailid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cWWPMailId = 0;
               AssignAttri("", false, "AV6cWWPMailId", StringUtil.LTrimStr( (decimal)(AV6cWWPMailId), 10, 0));
            }
            else
            {
               AV6cWWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cWWPMailId", StringUtil.LTrimStr( (decimal)(AV6cWWPMailId), 10, 0));
            }
            AV7cWWPMailSubject = cgiGet( edtavCwwpmailsubject_Internalname);
            AssignAttri("", false, "AV7cWWPMailSubject", AV7cWWPMailSubject);
            cmbavCwwpmailstatus.Name = cmbavCwwpmailstatus_Internalname;
            cmbavCwwpmailstatus.CurrentValue = cgiGet( cmbavCwwpmailstatus_Internalname);
            AV8cWWPMailStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavCwwpmailstatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8cWWPMailStatus", StringUtil.LTrimStr( (decimal)(AV8cWWPMailStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpmailcreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Mail Created", "")}), 1, "vCWWPMAILCREATED");
               GX_FocusControl = edtavCwwpmailcreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cWWPMailCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9cWWPMailCreated", context.localUtil.TToC( AV9cWWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV9cWWPMailCreated = context.localUtil.CToT( cgiGet( edtavCwwpmailcreated_Internalname));
               AssignAttri("", false, "AV9cWWPMailCreated", context.localUtil.TToC( AV9cWWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpmailscheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Mail Scheduled", "")}), 1, "vCWWPMAILSCHEDULED");
               GX_FocusControl = edtavCwwpmailscheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cWWPMailScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10cWWPMailScheduled", context.localUtil.TToC( AV10cWWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV10cWWPMailScheduled = context.localUtil.CToT( cgiGet( edtavCwwpmailscheduled_Internalname));
               AssignAttri("", false, "AV10cWWPMailScheduled", context.localUtil.TToC( AV10cWWPMailScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpmailprocessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Mail Processed", "")}), 1, "vCWWPMAILPROCESSED");
               GX_FocusControl = edtavCwwpmailprocessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cWWPMailProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV11cWWPMailProcessed", context.localUtil.TToC( AV11cWWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV11cWWPMailProcessed = context.localUtil.CToT( cgiGet( edtavCwwpmailprocessed_Internalname));
               AssignAttri("", false, "AV11cWWPMailProcessed", context.localUtil.TToC( AV11cWWPMailProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPNOTIFICATIONID");
               GX_FocusControl = edtavCwwpnotificationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cWWPNotificationId = 0;
               AssignAttri("", false, "AV12cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV12cWWPNotificationId), 10, 0));
            }
            else
            {
               AV12cWWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV12cWWPNotificationId), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWWPMailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWWPMAILSUBJECT"), AV7cWWPMailSubject) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPMAILSTATUS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cWWPMailStatus )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPMAILCREATED")) != AV9cWWPMailCreated )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPMAILSCHEDULED")) != AV10cWWPMailScheduled )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPMAILPROCESSED")) != AV11cWWPMailProcessed )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cWWPNotificationId )) )
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
         E168W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E168W2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "WWP_Mail", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E178W2( )
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
         E188W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E188W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pWWPMailId = A89WWPMailId;
         AssignAttri("", false, "AV13pWWPMailId", StringUtil.LTrimStr( (decimal)(AV13pWWPMailId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pWWPMailId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pWWPMailId"});
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
         AV13pWWPMailId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pWWPMailId", StringUtil.LTrimStr( (decimal)(AV13pWWPMailId), 10, 0));
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
         PA8W2( ) ;
         WS8W2( ) ;
         WE8W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021254881", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/gx00h0.js", "?202673021254881", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtWWPMailId_Internalname = "WWPMAILID_"+sGXsfl_84_idx;
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT_"+sGXsfl_84_idx;
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS_"+sGXsfl_84_idx;
         edtWWPMailCreated_Internalname = "WWPMAILCREATED_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtWWPMailId_Internalname = "WWPMAILID_"+sGXsfl_84_fel_idx;
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT_"+sGXsfl_84_fel_idx;
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS_"+sGXsfl_84_fel_idx;
         edtWWPMailCreated_Internalname = "WWPMAILCREATED_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB8W0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A89WWPMailId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtWWPMailSubject_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPMailId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtWWPMailSubject_Internalname, "Link", edtWWPMailSubject_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailSubject_Internalname,(string)A78WWPMailSubject,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPMailSubject_Link,(string)"",(string)"",(string)"",(string)edtWWPMailSubject_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWWPMailStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WWPMAILSTATUS_" + sGXsfl_84_idx;
               cmbWWPMailStatus.Name = GXCCtl;
               cmbWWPMailStatus.WebTags = "";
               cmbWWPMailStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
               cmbWWPMailStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
               cmbWWPMailStatus.addItem("3", context.GetMessage( "Error", ""), 0);
               if ( cmbWWPMailStatus.ItemCount > 0 )
               {
                  A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPMailStatus,(string)cmbWWPMailStatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0)),(short)1,(string)cmbWWPMailStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0));
            AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", (string)(cmbWWPMailStatus.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailCreated_Internalname,context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A100WWPMailCreated, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailCreated_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_DateTimeMillis",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes8W2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCwwpmailstatus.Name = "vCWWPMAILSTATUS";
         cmbavCwwpmailstatus.WebTags = "";
         cmbavCwwpmailstatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbavCwwpmailstatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbavCwwpmailstatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbavCwwpmailstatus.ItemCount > 0 )
         {
            AV8cWWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbavCwwpmailstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8cWWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8cWWPMailStatus", StringUtil.LTrimStr( (decimal)(AV8cWWPMailStatus), 4, 0));
         }
         GXCCtl = "WWPMAILSTATUS_" + sGXsfl_84_idx;
         cmbWWPMailStatus.Name = GXCCtl;
         cmbWWPMailStatus.WebTags = "";
         cmbWWPMailStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPMailStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPMailStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A90WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A90WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
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
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Subject", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Created", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPMailId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A78WWPMailSubject));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtWWPMailSubject_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A90WWPMailStatus), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A100WWPMailCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
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
         lblLblwwpmailidfilter_Internalname = "LBLWWPMAILIDFILTER";
         edtavCwwpmailid_Internalname = "vCWWPMAILID";
         divWwpmailidfiltercontainer_Internalname = "WWPMAILIDFILTERCONTAINER";
         lblLblwwpmailsubjectfilter_Internalname = "LBLWWPMAILSUBJECTFILTER";
         edtavCwwpmailsubject_Internalname = "vCWWPMAILSUBJECT";
         divWwpmailsubjectfiltercontainer_Internalname = "WWPMAILSUBJECTFILTERCONTAINER";
         lblLblwwpmailstatusfilter_Internalname = "LBLWWPMAILSTATUSFILTER";
         cmbavCwwpmailstatus_Internalname = "vCWWPMAILSTATUS";
         divWwpmailstatusfiltercontainer_Internalname = "WWPMAILSTATUSFILTERCONTAINER";
         lblLblwwpmailcreatedfilter_Internalname = "LBLWWPMAILCREATEDFILTER";
         edtavCwwpmailcreated_Internalname = "vCWWPMAILCREATED";
         divWwpmailcreatedfiltercontainer_Internalname = "WWPMAILCREATEDFILTERCONTAINER";
         lblLblwwpmailscheduledfilter_Internalname = "LBLWWPMAILSCHEDULEDFILTER";
         edtavCwwpmailscheduled_Internalname = "vCWWPMAILSCHEDULED";
         divWwpmailscheduledfiltercontainer_Internalname = "WWPMAILSCHEDULEDFILTERCONTAINER";
         lblLblwwpmailprocessedfilter_Internalname = "LBLWWPMAILPROCESSEDFILTER";
         edtavCwwpmailprocessed_Internalname = "vCWWPMAILPROCESSED";
         divWwpmailprocessedfiltercontainer_Internalname = "WWPMAILPROCESSEDFILTERCONTAINER";
         lblLblwwpnotificationidfilter_Internalname = "LBLWWPNOTIFICATIONIDFILTER";
         edtavCwwpnotificationid_Internalname = "vCWWPNOTIFICATIONID";
         divWwpnotificationidfiltercontainer_Internalname = "WWPNOTIFICATIONIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWWPMailId_Internalname = "WWPMAILID";
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT";
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS";
         edtWWPMailCreated_Internalname = "WWPMAILCREATED";
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
         edtWWPMailCreated_Jsonclick = "";
         cmbWWPMailStatus_Jsonclick = "";
         edtWWPMailSubject_Jsonclick = "";
         edtWWPMailSubject_Link = "";
         edtWWPMailId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtWWPMailCreated_Enabled = 0;
         cmbWWPMailStatus.Enabled = 0;
         edtWWPMailSubject_Enabled = 0;
         edtWWPMailId_Enabled = 0;
         edtavCwwpnotificationid_Jsonclick = "";
         edtavCwwpnotificationid_Enabled = 1;
         edtavCwwpnotificationid_Visible = 1;
         edtavCwwpmailprocessed_Jsonclick = "";
         edtavCwwpmailprocessed_Enabled = 1;
         edtavCwwpmailscheduled_Jsonclick = "";
         edtavCwwpmailscheduled_Enabled = 1;
         edtavCwwpmailcreated_Jsonclick = "";
         edtavCwwpmailcreated_Enabled = 1;
         cmbavCwwpmailstatus_Jsonclick = "";
         cmbavCwwpmailstatus.Visible = 1;
         cmbavCwwpmailstatus.Enabled = 1;
         edtavCwwpmailsubject_Jsonclick = "";
         edtavCwwpmailsubject_Enabled = 1;
         edtavCwwpmailsubject_Visible = 1;
         edtavCwwpmailid_Jsonclick = "";
         edtavCwwpmailid_Enabled = 1;
         edtavCwwpmailid_Visible = 1;
         divWwpnotificationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpmailstatusfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpmailsubjectfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpmailidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List WWP_Mail", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPMailId',fld:'vCWWPMAILID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPMailSubject',fld:'vCWWPMAILSUBJECT',pic:'',type:'svchar'},{av:'cmbavCwwpmailstatus'},{av:'AV8cWWPMailStatus',fld:'vCWWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'AV9cWWPMailCreated',fld:'vCWWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPMailScheduled',fld:'vCWWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPMailProcessed',fld:'vCWWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV12cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E158W1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWWPMAILIDFILTER.CLICK","{handler:'E118W1',iparms:[{av:'divWwpmailidfiltercontainer_Class',ctrl:'WWPMAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPMAILIDFILTER.CLICK",",oparms:[{av:'divWwpmailidfiltercontainer_Class',ctrl:'WWPMAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpmailid_Visible',ctrl:'vCWWPMAILID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPMAILSUBJECTFILTER.CLICK","{handler:'E128W1',iparms:[{av:'divWwpmailsubjectfiltercontainer_Class',ctrl:'WWPMAILSUBJECTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPMAILSUBJECTFILTER.CLICK",",oparms:[{av:'divWwpmailsubjectfiltercontainer_Class',ctrl:'WWPMAILSUBJECTFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpmailsubject_Visible',ctrl:'vCWWPMAILSUBJECT',prop:'Visible'}]}");
         setEventMetadata("LBLWWPMAILSTATUSFILTER.CLICK","{handler:'E138W1',iparms:[{av:'divWwpmailstatusfiltercontainer_Class',ctrl:'WWPMAILSTATUSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPMAILSTATUSFILTER.CLICK",",oparms:[{av:'divWwpmailstatusfiltercontainer_Class',ctrl:'WWPMAILSTATUSFILTERCONTAINER',prop:'Class'},{av:'cmbavCwwpmailstatus'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK","{handler:'E148W1',iparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK",",oparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationid_Visible',ctrl:'vCWWPNOTIFICATIONID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E188W2',iparms:[{av:'A89WWPMailId',fld:'WWPMAILID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pWWPMailId',fld:'vPWWPMAILID',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPMailId',fld:'vCWWPMAILID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPMailSubject',fld:'vCWWPMAILSUBJECT',pic:'',type:'svchar'},{av:'cmbavCwwpmailstatus'},{av:'AV8cWWPMailStatus',fld:'vCWWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'AV9cWWPMailCreated',fld:'vCWWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPMailScheduled',fld:'vCWWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPMailProcessed',fld:'vCWWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV12cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPMailId',fld:'vCWWPMAILID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPMailSubject',fld:'vCWWPMAILSUBJECT',pic:'',type:'svchar'},{av:'cmbavCwwpmailstatus'},{av:'AV8cWWPMailStatus',fld:'vCWWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'AV9cWWPMailCreated',fld:'vCWWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPMailScheduled',fld:'vCWWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPMailProcessed',fld:'vCWWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV12cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPMailId',fld:'vCWWPMAILID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPMailSubject',fld:'vCWWPMAILSUBJECT',pic:'',type:'svchar'},{av:'cmbavCwwpmailstatus'},{av:'AV8cWWPMailStatus',fld:'vCWWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'AV9cWWPMailCreated',fld:'vCWWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPMailScheduled',fld:'vCWWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPMailProcessed',fld:'vCWWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV12cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPMailId',fld:'vCWWPMAILID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7cWWPMailSubject',fld:'vCWWPMAILSUBJECT',pic:'',type:'svchar'},{av:'cmbavCwwpmailstatus'},{av:'AV8cWWPMailStatus',fld:'vCWWPMAILSTATUS',pic:'ZZZ9',type:'int'},{av:'AV9cWWPMailCreated',fld:'vCWWPMAILCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPMailScheduled',fld:'vCWWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPMailProcessed',fld:'vCWWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV12cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPMAILSTATUS","{handler:'Validv_Cwwpmailstatus',iparms:[]");
         setEventMetadata("VALIDV_CWWPMAILSTATUS",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPMAILCREATED","{handler:'Validv_Cwwpmailcreated',iparms:[]");
         setEventMetadata("VALIDV_CWWPMAILCREATED",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPMAILSCHEDULED","{handler:'Validv_Cwwpmailscheduled',iparms:[]");
         setEventMetadata("VALIDV_CWWPMAILSCHEDULED",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPMAILPROCESSED","{handler:'Validv_Cwwpmailprocessed',iparms:[]");
         setEventMetadata("VALIDV_CWWPMAILPROCESSED",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpmailcreated',iparms:[]");
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
         AV7cWWPMailSubject = "";
         AV9cWWPMailCreated = (DateTime)(DateTime.MinValue);
         AV10cWWPMailScheduled = (DateTime)(DateTime.MinValue);
         AV11cWWPMailProcessed = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwwpmailidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwwpmailsubjectfilter_Jsonclick = "";
         lblLblwwpmailstatusfilter_Jsonclick = "";
         lblLblwwpmailcreatedfilter_Jsonclick = "";
         lblLblwwpmailscheduledfilter_Jsonclick = "";
         lblLblwwpmailprocessedfilter_Jsonclick = "";
         lblLblwwpnotificationidfilter_Jsonclick = "";
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
         A78WWPMailSubject = "";
         A100WWPMailCreated = (DateTime)(DateTime.MinValue);
         lV7cWWPMailSubject = "";
         A101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         H008W2_A31WWPNotificationId = new long[1] ;
         H008W2_n31WWPNotificationId = new bool[] {false} ;
         H008W2_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         H008W2_n95WWPMailProcessed = new bool[] {false} ;
         H008W2_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         H008W2_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         H008W2_A90WWPMailStatus = new short[1] ;
         H008W2_A78WWPMailSubject = new string[] {""} ;
         H008W2_A89WWPMailId = new long[1] ;
         H008W3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.gx00h0__default(),
            new Object[][] {
                new Object[] {
               H008W2_A31WWPNotificationId, H008W2_n31WWPNotificationId, H008W2_A95WWPMailProcessed, H008W2_n95WWPMailProcessed, H008W2_A101WWPMailScheduled, H008W2_A100WWPMailCreated, H008W2_A90WWPMailStatus, H008W2_A78WWPMailSubject, H008W2_A89WWPMailId
               }
               , new Object[] {
               H008W3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV8cWWPMailStatus ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A90WWPMailStatus ;
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
      private int edtavCwwpmailid_Enabled ;
      private int edtavCwwpmailid_Visible ;
      private int edtavCwwpmailsubject_Visible ;
      private int edtavCwwpmailsubject_Enabled ;
      private int edtavCwwpmailcreated_Enabled ;
      private int edtavCwwpmailscheduled_Enabled ;
      private int edtavCwwpmailprocessed_Enabled ;
      private int edtavCwwpnotificationid_Enabled ;
      private int edtavCwwpnotificationid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPMailId_Enabled ;
      private int edtWWPMailSubject_Enabled ;
      private int edtWWPMailCreated_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pWWPMailId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cWWPMailId ;
      private long AV12cWWPNotificationId ;
      private long A89WWPMailId ;
      private long GRID1_nCurrentRecord ;
      private long A31WWPNotificationId ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWwpmailidfiltercontainer_Class ;
      private string divWwpmailsubjectfiltercontainer_Class ;
      private string divWwpmailstatusfiltercontainer_Class ;
      private string divWwpnotificationidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWwpmailidfiltercontainer_Internalname ;
      private string lblLblwwpmailidfilter_Internalname ;
      private string lblLblwwpmailidfilter_Jsonclick ;
      private string edtavCwwpmailid_Internalname ;
      private string TempTags ;
      private string edtavCwwpmailid_Jsonclick ;
      private string divWwpmailsubjectfiltercontainer_Internalname ;
      private string lblLblwwpmailsubjectfilter_Internalname ;
      private string lblLblwwpmailsubjectfilter_Jsonclick ;
      private string edtavCwwpmailsubject_Internalname ;
      private string edtavCwwpmailsubject_Jsonclick ;
      private string divWwpmailstatusfiltercontainer_Internalname ;
      private string lblLblwwpmailstatusfilter_Internalname ;
      private string lblLblwwpmailstatusfilter_Jsonclick ;
      private string cmbavCwwpmailstatus_Internalname ;
      private string cmbavCwwpmailstatus_Jsonclick ;
      private string divWwpmailcreatedfiltercontainer_Internalname ;
      private string lblLblwwpmailcreatedfilter_Internalname ;
      private string lblLblwwpmailcreatedfilter_Jsonclick ;
      private string edtavCwwpmailcreated_Internalname ;
      private string edtavCwwpmailcreated_Jsonclick ;
      private string divWwpmailscheduledfiltercontainer_Internalname ;
      private string lblLblwwpmailscheduledfilter_Internalname ;
      private string lblLblwwpmailscheduledfilter_Jsonclick ;
      private string edtavCwwpmailscheduled_Internalname ;
      private string edtavCwwpmailscheduled_Jsonclick ;
      private string divWwpmailprocessedfiltercontainer_Internalname ;
      private string lblLblwwpmailprocessedfilter_Internalname ;
      private string lblLblwwpmailprocessedfilter_Jsonclick ;
      private string edtavCwwpmailprocessed_Internalname ;
      private string edtavCwwpmailprocessed_Jsonclick ;
      private string divWwpnotificationidfiltercontainer_Internalname ;
      private string lblLblwwpnotificationidfilter_Internalname ;
      private string lblLblwwpnotificationidfilter_Jsonclick ;
      private string edtavCwwpnotificationid_Internalname ;
      private string edtavCwwpnotificationid_Jsonclick ;
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
      private string edtWWPMailId_Internalname ;
      private string edtWWPMailSubject_Internalname ;
      private string cmbWWPMailStatus_Internalname ;
      private string edtWWPMailCreated_Internalname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWWPMailId_Jsonclick ;
      private string edtWWPMailSubject_Link ;
      private string edtWWPMailSubject_Jsonclick ;
      private string GXCCtl ;
      private string cmbWWPMailStatus_Jsonclick ;
      private string edtWWPMailCreated_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV9cWWPMailCreated ;
      private DateTime AV10cWWPMailScheduled ;
      private DateTime AV11cWWPMailProcessed ;
      private DateTime A100WWPMailCreated ;
      private DateTime A101WWPMailScheduled ;
      private DateTime A95WWPMailProcessed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n31WWPNotificationId ;
      private bool n95WWPMailProcessed ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cWWPMailSubject ;
      private string AV15Linkselection_GXI ;
      private string A78WWPMailSubject ;
      private string lV7cWWPMailSubject ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCwwpmailstatus ;
      private GXCombobox cmbWWPMailStatus ;
      private IDataStoreProvider pr_default ;
      private long[] H008W2_A31WWPNotificationId ;
      private bool[] H008W2_n31WWPNotificationId ;
      private DateTime[] H008W2_A95WWPMailProcessed ;
      private bool[] H008W2_n95WWPMailProcessed ;
      private DateTime[] H008W2_A101WWPMailScheduled ;
      private DateTime[] H008W2_A100WWPMailCreated ;
      private short[] H008W2_A90WWPMailStatus ;
      private string[] H008W2_A78WWPMailSubject ;
      private long[] H008W2_A89WWPMailId ;
      private long[] H008W3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pWWPMailId ;
   }

   public class gx00h0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008W2( IGxContext context ,
                                             string AV7cWWPMailSubject ,
                                             short AV8cWWPMailStatus ,
                                             DateTime AV9cWWPMailCreated ,
                                             DateTime AV10cWWPMailScheduled ,
                                             DateTime AV11cWWPMailProcessed ,
                                             long AV12cWWPNotificationId ,
                                             string A78WWPMailSubject ,
                                             short A90WWPMailStatus ,
                                             DateTime A100WWPMailCreated ,
                                             DateTime A101WWPMailScheduled ,
                                             DateTime A95WWPMailProcessed ,
                                             long A31WWPNotificationId ,
                                             long AV6cWWPMailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [WWPNotificationId], [WWPMailProcessed], [WWPMailScheduled], [WWPMailCreated], [WWPMailStatus], [WWPMailSubject], [WWPMailId]";
         sFromString = " FROM [WWP_Mail]";
         sOrderString = "";
         AddWhere(sWhereString, "([WWPMailId] >= @AV6cWWPMailId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cWWPMailSubject)) )
         {
            AddWhere(sWhereString, "([WWPMailSubject] like @lV7cWWPMailSubject)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cWWPMailStatus) )
         {
            AddWhere(sWhereString, "([WWPMailStatus] >= @AV8cWWPMailStatus)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cWWPMailCreated) )
         {
            AddWhere(sWhereString, "([WWPMailCreated] >= @AV9cWWPMailCreated)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cWWPMailScheduled) )
         {
            AddWhere(sWhereString, "([WWPMailScheduled] >= @AV10cWWPMailScheduled)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cWWPMailProcessed) )
         {
            AddWhere(sWhereString, "([WWPMailProcessed] >= @AV11cWWPMailProcessed)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cWWPNotificationId) )
         {
            AddWhere(sWhereString, "([WWPNotificationId] >= @AV12cWWPNotificationId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [WWPMailId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H008W3( IGxContext context ,
                                             string AV7cWWPMailSubject ,
                                             short AV8cWWPMailStatus ,
                                             DateTime AV9cWWPMailCreated ,
                                             DateTime AV10cWWPMailScheduled ,
                                             DateTime AV11cWWPMailProcessed ,
                                             long AV12cWWPNotificationId ,
                                             string A78WWPMailSubject ,
                                             short A90WWPMailStatus ,
                                             DateTime A100WWPMailCreated ,
                                             DateTime A101WWPMailScheduled ,
                                             DateTime A95WWPMailProcessed ,
                                             long A31WWPNotificationId ,
                                             long AV6cWWPMailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [WWP_Mail]";
         AddWhere(sWhereString, "([WWPMailId] >= @AV6cWWPMailId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cWWPMailSubject)) )
         {
            AddWhere(sWhereString, "([WWPMailSubject] like @lV7cWWPMailSubject)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cWWPMailStatus) )
         {
            AddWhere(sWhereString, "([WWPMailStatus] >= @AV8cWWPMailStatus)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cWWPMailCreated) )
         {
            AddWhere(sWhereString, "([WWPMailCreated] >= @AV9cWWPMailCreated)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cWWPMailScheduled) )
         {
            AddWhere(sWhereString, "([WWPMailScheduled] >= @AV10cWWPMailScheduled)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cWWPMailProcessed) )
         {
            AddWhere(sWhereString, "([WWPMailProcessed] >= @AV11cWWPMailProcessed)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cWWPNotificationId) )
         {
            AddWhere(sWhereString, "([WWPNotificationId] >= @AV12cWWPNotificationId)");
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
                     return conditional_H008W2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H008W3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH008W2;
          prmH008W2 = new Object[] {
          new ParDef("@AV6cWWPMailId",GXType.Decimal,10,0) ,
          new ParDef("@lV7cWWPMailSubject",GXType.NVarChar,80,0) ,
          new ParDef("@AV8cWWPMailStatus",GXType.Int16,4,0) ,
          new ParDef("@AV9cWWPMailCreated",GXType.DateTime2,10,12) ,
          new ParDef("@AV10cWWPMailScheduled",GXType.DateTime2,10,12) ,
          new ParDef("@AV11cWWPMailProcessed",GXType.DateTime2,10,12) ,
          new ParDef("@AV12cWWPNotificationId",GXType.Decimal,10,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008W3;
          prmH008W3 = new Object[] {
          new ParDef("@AV6cWWPMailId",GXType.Decimal,10,0) ,
          new ParDef("@lV7cWWPMailSubject",GXType.NVarChar,80,0) ,
          new ParDef("@AV8cWWPMailStatus",GXType.Int16,4,0) ,
          new ParDef("@AV9cWWPMailCreated",GXType.DateTime2,10,12) ,
          new ParDef("@AV10cWWPMailScheduled",GXType.DateTime2,10,12) ,
          new ParDef("@AV11cWWPMailProcessed",GXType.DateTime2,10,12) ,
          new ParDef("@AV12cWWPNotificationId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008W2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H008W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008W3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2, true);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4, true);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

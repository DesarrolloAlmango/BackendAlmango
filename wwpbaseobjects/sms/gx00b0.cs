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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class gx00b0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00b0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00b0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pWWPSMSId )
      {
         this.AV12pWWPSMSId = 0 ;
         ExecutePrivate();
         aP0_pWWPSMSId=this.AV12pWWPSMSId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCwwpsmsstatus = new GXCombobox();
         cmbWWPSMSStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWWPSMSId");
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
               gxfirstwebparm = GetFirstPar( "pWWPSMSId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWWPSMSId");
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
               AV12pWWPSMSId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pWWPSMSId", StringUtil.LTrimStr( (decimal)(AV12pWWPSMSId), 10, 0));
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
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV6cWWPSMSId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPSMSId"), "."), 18, MidpointRounding.ToEven));
         cmbavCwwpsmsstatus.FromJSonString( GetNextPar( ));
         AV7cWWPSMSStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "cWWPSMSStatus"), "."), 18, MidpointRounding.ToEven));
         AV8cWWPSMSCreated = context.localUtil.ParseDTimeParm( GetPar( "cWWPSMSCreated"));
         AV9cWWPSMSScheduled = context.localUtil.ParseDTimeParm( GetPar( "cWWPSMSScheduled"));
         AV10cWWPSMSProcessed = context.localUtil.ParseDTimeParm( GetPar( "cWWPSMSProcessed"));
         AV11cWWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWWPNotificationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId) ;
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
         PA8R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8R2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.sms.gx00b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pWWPSMSId,10,0))}, new string[] {"pWWPSMSId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSMSSTATUS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cWWPSMSStatus), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSMSCREATED", context.localUtil.TToC( AV8cWWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSMSSCHEDULED", context.localUtil.TToC( AV9cWWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPSMSPROCESSED", context.localUtil.TToC( AV10cWWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cWWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPWWPSMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pWWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WWPSMSIDFILTERCONTAINER_Class", StringUtil.RTrim( divWwpsmsidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WWPSMSSTATUSFILTERCONTAINER_Class", StringUtil.RTrim( divWwpsmsstatusfiltercontainer_Class));
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
            WE8R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8R2( ) ;
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
         return formatLink("wwpbaseobjects.sms.gx00b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pWWPSMSId,10,0))}, new string[] {"pWWPSMSId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SMS.Gx00B0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List WWP_SMS", "") ;
      }

      protected void WB8R0( )
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
            GxWebStd.gx_div_start( context, divWwpsmsidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpsmsidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsmsidfilter_Internalname, context.GetMessage( "SMS Id", ""), "", "", lblLblwwpsmsidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e118r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpsmsid_Internalname, context.GetMessage( "SMS Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpsmsid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwwpsmsid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cWWPSMSId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cWWPSMSId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpsmsid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpsmsid_Visible, edtavCwwpsmsid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divWwpsmsstatusfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWwpsmsstatusfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsmsstatusfilter_Internalname, context.GetMessage( "SMS Status", ""), "", "", lblLblwwpsmsstatusfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e128r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCwwpsmsstatus_Internalname, context.GetMessage( "SMS Status", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCwwpsmsstatus, cmbavCwwpsmsstatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7cWWPSMSStatus), 4, 0)), 1, cmbavCwwpsmsstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCwwpsmsstatus.Visible, cmbavCwwpsmsstatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            cmbavCwwpsmsstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7cWWPSMSStatus), 4, 0));
            AssignProp("", false, cmbavCwwpsmsstatus_Internalname, "Values", (string)(cmbavCwwpsmsstatus.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divWwpsmscreatedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsmscreatedfilter_Internalname, context.GetMessage( "SMS Created", ""), "", "", lblLblwwpsmscreatedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpsmscreated_Internalname, context.GetMessage( "SMS Created", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpsmscreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpsmscreated_Internalname, context.localUtil.TToC( AV8cWWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV8cWWPSMSCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpsmscreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpsmscreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divWwpsmsscheduledfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsmsscheduledfilter_Internalname, context.GetMessage( "SMS Scheduled", ""), "", "", lblLblwwpsmsscheduledfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpsmsscheduled_Internalname, context.GetMessage( "SMS Scheduled", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpsmsscheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpsmsscheduled_Internalname, context.localUtil.TToC( AV9cWWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV9cWWPSMSScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpsmsscheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpsmsscheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divWwpsmsprocessedfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwwpsmsprocessedfilter_Internalname, context.GetMessage( "SMS Processed", ""), "", "", lblLblwwpsmsprocessedfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwwpsmsprocessed_Internalname, context.GetMessage( "SMS Processed", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwwpsmsprocessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwwpsmsprocessed_Internalname, context.localUtil.TToC( AV10cWWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV10cWWPSMSProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpsmsprocessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwwpsmsprocessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblwwpnotificationidfilter_Internalname, context.GetMessage( "Notification Id", ""), "", "", lblLblwwpnotificationidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e138r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwwpnotificationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cWWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwwpnotificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cWWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cWWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwwpnotificationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwwpnotificationid_Visible, edtavCwwpnotificationid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e148r1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/Gx00B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START8R2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List WWP_SMS", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8R0( ) ;
      }

      protected void WS8R2( )
      {
         START8R2( ) ;
         EVT8R2( ) ;
      }

      protected void EVT8R2( )
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
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A42WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbWWPSMSStatus.Name = cmbWWPSMSStatus_Internalname;
                              cmbWWPSMSStatus.CurrentValue = cgiGet( cmbWWPSMSStatus_Internalname);
                              A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPSMSStatus_Internalname), "."), 18, MidpointRounding.ToEven));
                              A49WWPSMSCreated = context.localUtil.CToT( cgiGet( edtWWPSMSCreated_Internalname), 0);
                              A50WWPSMSScheduled = context.localUtil.CToT( cgiGet( edtWWPSMSScheduled_Internalname), 0);
                              A44WWPSMSProcessed = context.localUtil.CToT( cgiGet( edtWWPSMSProcessed_Internalname), 0);
                              n44WWPSMSProcessed = false;
                              A31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n31WWPNotificationId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E158R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E168R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwwpsmsid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPSMSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWWPSMSId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpsmsstatus Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPSMSSTATUS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cWWPSMSStatus )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpsmscreated Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPSMSCREATED"), 0) != AV8cWWPSMSCreated )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpsmsscheduled Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPSMSSCHEDULED"), 0) != AV9cWWPSMSScheduled )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpsmsprocessed Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPSMSPROCESSED"), 0) != AV10cWWPSMSProcessed )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwwpnotificationid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cWWPNotificationId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E178R2 ();
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

      protected void WE8R2( )
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

      protected void PA8R2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cWWPSMSId ,
                                        short AV7cWWPSMSStatus ,
                                        DateTime AV8cWWPSMSCreated ,
                                        DateTime AV9cWWPSMSScheduled ,
                                        DateTime AV10cWWPSMSProcessed ,
                                        long AV11cWWPNotificationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF8R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPSMSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A42WWPSMSId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPSMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A42WWPSMSId), 10, 0, ".", "")));
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
         if ( cmbavCwwpsmsstatus.ItemCount > 0 )
         {
            AV7cWWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbavCwwpsmsstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7cWWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7cWWPSMSStatus", StringUtil.LTrimStr( (decimal)(AV7cWWPSMSStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCwwpsmsstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7cWWPSMSStatus), 4, 0));
            AssignProp("", false, cmbavCwwpsmsstatus_Internalname, "Values", cmbavCwwpsmsstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cWWPSMSStatus ,
                                                 AV8cWWPSMSCreated ,
                                                 AV9cWWPSMSScheduled ,
                                                 AV10cWWPSMSProcessed ,
                                                 AV11cWWPNotificationId ,
                                                 A43WWPSMSStatus ,
                                                 A49WWPSMSCreated ,
                                                 A50WWPSMSScheduled ,
                                                 A44WWPSMSProcessed ,
                                                 A31WWPNotificationId ,
                                                 AV6cWWPSMSId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H008R2 */
            pr_default.execute(0, new Object[] {AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A31WWPNotificationId = H008R2_A31WWPNotificationId[0];
               n31WWPNotificationId = H008R2_n31WWPNotificationId[0];
               A44WWPSMSProcessed = H008R2_A44WWPSMSProcessed[0];
               n44WWPSMSProcessed = H008R2_n44WWPSMSProcessed[0];
               A50WWPSMSScheduled = H008R2_A50WWPSMSScheduled[0];
               A49WWPSMSCreated = H008R2_A49WWPSMSCreated[0];
               A43WWPSMSStatus = H008R2_A43WWPSMSStatus[0];
               A42WWPSMSId = H008R2_A42WWPSMSId[0];
               /* Execute user event: Load */
               E168R2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB8R0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8R2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPSMSID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A42WWPSMSId), "ZZZZZZZZZ9"), context));
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
                                              AV7cWWPSMSStatus ,
                                              AV8cWWPSMSCreated ,
                                              AV9cWWPSMSScheduled ,
                                              AV10cWWPSMSProcessed ,
                                              AV11cWWPNotificationId ,
                                              A43WWPSMSStatus ,
                                              A49WWPSMSCreated ,
                                              A50WWPSMSScheduled ,
                                              A44WWPSMSProcessed ,
                                              A31WWPNotificationId ,
                                              AV6cWWPSMSId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         /* Using cursor H008R3 */
         pr_default.execute(1, new Object[] {AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId});
         GRID1_nRecordCount = H008R3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWWPSMSId, AV7cWWPSMSStatus, AV8cWWPSMSCreated, AV9cWWPSMSScheduled, AV10cWWPSMSProcessed, AV11cWWPNotificationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWWPSMSId_Enabled = 0;
         cmbWWPSMSStatus.Enabled = 0;
         edtWWPSMSCreated_Enabled = 0;
         edtWWPSMSScheduled_Enabled = 0;
         edtWWPSMSProcessed_Enabled = 0;
         edtWWPNotificationId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E158R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpsmsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpsmsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPSMSID");
               GX_FocusControl = edtavCwwpsmsid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cWWPSMSId = 0;
               AssignAttri("", false, "AV6cWWPSMSId", StringUtil.LTrimStr( (decimal)(AV6cWWPSMSId), 10, 0));
            }
            else
            {
               AV6cWWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpsmsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cWWPSMSId", StringUtil.LTrimStr( (decimal)(AV6cWWPSMSId), 10, 0));
            }
            cmbavCwwpsmsstatus.Name = cmbavCwwpsmsstatus_Internalname;
            cmbavCwwpsmsstatus.CurrentValue = cgiGet( cmbavCwwpsmsstatus_Internalname);
            AV7cWWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavCwwpsmsstatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7cWWPSMSStatus", StringUtil.LTrimStr( (decimal)(AV7cWWPSMSStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpsmscreated_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Created", "")}), 1, "vCWWPSMSCREATED");
               GX_FocusControl = edtavCwwpsmscreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cWWPSMSCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8cWWPSMSCreated", context.localUtil.TToC( AV8cWWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV8cWWPSMSCreated = context.localUtil.CToT( cgiGet( edtavCwwpsmscreated_Internalname));
               AssignAttri("", false, "AV8cWWPSMSCreated", context.localUtil.TToC( AV8cWWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpsmsscheduled_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Scheduled", "")}), 1, "vCWWPSMSSCHEDULED");
               GX_FocusControl = edtavCwwpsmsscheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cWWPSMSScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9cWWPSMSScheduled", context.localUtil.TToC( AV9cWWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV9cWWPSMSScheduled = context.localUtil.CToT( cgiGet( edtavCwwpsmsscheduled_Internalname));
               AssignAttri("", false, "AV9cWWPSMSScheduled", context.localUtil.TToC( AV9cWWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwwpsmsprocessed_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "SMS Processed", "")}), 1, "vCWWPSMSPROCESSED");
               GX_FocusControl = edtavCwwpsmsprocessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cWWPSMSProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10cWWPSMSProcessed", context.localUtil.TToC( AV10cWWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV10cWWPSMSProcessed = context.localUtil.CToT( cgiGet( edtavCwwpsmsprocessed_Internalname));
               AssignAttri("", false, "AV10cWWPSMSProcessed", context.localUtil.TToC( AV10cWWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWWPNOTIFICATIONID");
               GX_FocusControl = edtavCwwpnotificationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cWWPNotificationId = 0;
               AssignAttri("", false, "AV11cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV11cWWPNotificationId), 10, 0));
            }
            else
            {
               AV11cWWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwwpnotificationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cWWPNotificationId", StringUtil.LTrimStr( (decimal)(AV11cWWPNotificationId), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPSMSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWWPSMSId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPSMSSTATUS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cWWPSMSStatus )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPSMSCREATED")) != AV8cWWPSMSCreated )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPSMSSCHEDULED")) != AV9cWWPSMSScheduled )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWWPSMSPROCESSED")) != AV10cWWPSMSProcessed )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWWPNOTIFICATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cWWPNotificationId )) )
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
         E158R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E158R2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "WWP_SMS", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E168R2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            context.DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E178R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E178R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pWWPSMSId = A42WWPSMSId;
         AssignAttri("", false, "AV12pWWPSMSId", StringUtil.LTrimStr( (decimal)(AV12pWWPSMSId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pWWPSMSId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pWWPSMSId"});
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
         AV12pWWPSMSId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pWWPSMSId", StringUtil.LTrimStr( (decimal)(AV12pWWPSMSId), 10, 0));
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
         PA8R2( ) ;
         WS8R2( ) ;
         WE8R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021254583", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/sms/gx00b0.js", "?202673021254583", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtWWPSMSId_Internalname = "WWPSMSID_"+sGXsfl_74_idx;
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS_"+sGXsfl_74_idx;
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED_"+sGXsfl_74_idx;
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED_"+sGXsfl_74_idx;
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED_"+sGXsfl_74_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtWWPSMSId_Internalname = "WWPSMSID_"+sGXsfl_74_fel_idx;
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS_"+sGXsfl_74_fel_idx;
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED_"+sGXsfl_74_fel_idx;
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED_"+sGXsfl_74_fel_idx;
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED_"+sGXsfl_74_fel_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB8R0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42WWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPSMSId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A42WWPSMSId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A42WWPSMSId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPSMSId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWWPSMSStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WWPSMSSTATUS_" + sGXsfl_74_idx;
               cmbWWPSMSStatus.Name = GXCCtl;
               cmbWWPSMSStatus.WebTags = "";
               cmbWWPSMSStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
               cmbWWPSMSStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
               cmbWWPSMSStatus.addItem("3", context.GetMessage( "Error", ""), 0);
               if ( cmbWWPSMSStatus.ItemCount > 0 )
               {
                  A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPSMSStatus,(string)cmbWWPSMSStatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0)),(short)1,(string)cmbWWPSMSStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0));
            AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", (string)(cmbWWPSMSStatus.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPSMSCreated_Internalname,context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A49WWPSMSCreated, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPSMSCreated_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_DateTimeMillis",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPSMSScheduled_Internalname,context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A50WWPSMSScheduled, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPSMSScheduled_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_DateTimeMillis",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPSMSProcessed_Internalname,context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A44WWPSMSProcessed, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPSMSProcessed_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_DateTimeMillis",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes8R2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCwwpsmsstatus.Name = "vCWWPSMSSTATUS";
         cmbavCwwpsmsstatus.WebTags = "";
         cmbavCwwpsmsstatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbavCwwpsmsstatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbavCwwpsmsstatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbavCwwpsmsstatus.ItemCount > 0 )
         {
            AV7cWWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbavCwwpsmsstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7cWWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7cWWPSMSStatus", StringUtil.LTrimStr( (decimal)(AV7cWWPSMSStatus), 4, 0));
         }
         GXCCtl = "WWPSMSSTATUS_" + sGXsfl_74_idx;
         cmbWWPSMSStatus.Name = GXCCtl;
         cmbWWPSMSStatus.WebTags = "";
         cmbWWPSMSStatus.addItem("1", context.GetMessage( "Pending", ""), 0);
         cmbWWPSMSStatus.addItem("2", context.GetMessage( "Sent", ""), 0);
         cmbWWPSMSStatus.addItem("3", context.GetMessage( "Error", ""), 0);
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A43WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Created", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Scheduled", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Processed", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42WWPSMSId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A43WWPSMSStatus), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A49WWPSMSCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A50WWPSMSScheduled, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A44WWPSMSProcessed, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, ".", ""))));
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
         lblLblwwpsmsidfilter_Internalname = "LBLWWPSMSIDFILTER";
         edtavCwwpsmsid_Internalname = "vCWWPSMSID";
         divWwpsmsidfiltercontainer_Internalname = "WWPSMSIDFILTERCONTAINER";
         lblLblwwpsmsstatusfilter_Internalname = "LBLWWPSMSSTATUSFILTER";
         cmbavCwwpsmsstatus_Internalname = "vCWWPSMSSTATUS";
         divWwpsmsstatusfiltercontainer_Internalname = "WWPSMSSTATUSFILTERCONTAINER";
         lblLblwwpsmscreatedfilter_Internalname = "LBLWWPSMSCREATEDFILTER";
         edtavCwwpsmscreated_Internalname = "vCWWPSMSCREATED";
         divWwpsmscreatedfiltercontainer_Internalname = "WWPSMSCREATEDFILTERCONTAINER";
         lblLblwwpsmsscheduledfilter_Internalname = "LBLWWPSMSSCHEDULEDFILTER";
         edtavCwwpsmsscheduled_Internalname = "vCWWPSMSSCHEDULED";
         divWwpsmsscheduledfiltercontainer_Internalname = "WWPSMSSCHEDULEDFILTERCONTAINER";
         lblLblwwpsmsprocessedfilter_Internalname = "LBLWWPSMSPROCESSEDFILTER";
         edtavCwwpsmsprocessed_Internalname = "vCWWPSMSPROCESSED";
         divWwpsmsprocessedfiltercontainer_Internalname = "WWPSMSPROCESSEDFILTERCONTAINER";
         lblLblwwpnotificationidfilter_Internalname = "LBLWWPNOTIFICATIONIDFILTER";
         edtavCwwpnotificationid_Internalname = "vCWWPNOTIFICATIONID";
         divWwpnotificationidfiltercontainer_Internalname = "WWPNOTIFICATIONIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWWPSMSId_Internalname = "WWPSMSID";
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS";
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED";
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED";
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
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
         edtWWPNotificationId_Jsonclick = "";
         edtWWPSMSProcessed_Jsonclick = "";
         edtWWPSMSScheduled_Jsonclick = "";
         edtWWPSMSCreated_Jsonclick = "";
         cmbWWPSMSStatus_Jsonclick = "";
         edtWWPSMSId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtWWPNotificationId_Enabled = 0;
         edtWWPSMSProcessed_Enabled = 0;
         edtWWPSMSScheduled_Enabled = 0;
         edtWWPSMSCreated_Enabled = 0;
         cmbWWPSMSStatus.Enabled = 0;
         edtWWPSMSId_Enabled = 0;
         edtavCwwpnotificationid_Jsonclick = "";
         edtavCwwpnotificationid_Enabled = 1;
         edtavCwwpnotificationid_Visible = 1;
         edtavCwwpsmsprocessed_Jsonclick = "";
         edtavCwwpsmsprocessed_Enabled = 1;
         edtavCwwpsmsscheduled_Jsonclick = "";
         edtavCwwpsmsscheduled_Enabled = 1;
         edtavCwwpsmscreated_Jsonclick = "";
         edtavCwwpsmscreated_Enabled = 1;
         cmbavCwwpsmsstatus_Jsonclick = "";
         cmbavCwwpsmsstatus.Visible = 1;
         cmbavCwwpsmsstatus.Enabled = 1;
         edtavCwwpsmsid_Jsonclick = "";
         edtavCwwpsmsid_Enabled = 1;
         edtavCwwpsmsid_Visible = 1;
         divWwpnotificationidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpsmsstatusfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWwpsmsidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List WWP_SMS", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSMSId',fld:'vCWWPSMSID',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwwpsmsstatus'},{av:'AV7cWWPSMSStatus',fld:'vCWWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'AV8cWWPSMSCreated',fld:'vCWWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV9cWWPSMSScheduled',fld:'vCWWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPSMSProcessed',fld:'vCWWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E148R1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWWPSMSIDFILTER.CLICK","{handler:'E118R1',iparms:[{av:'divWwpsmsidfiltercontainer_Class',ctrl:'WWPSMSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPSMSIDFILTER.CLICK",",oparms:[{av:'divWwpsmsidfiltercontainer_Class',ctrl:'WWPSMSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpsmsid_Visible',ctrl:'vCWWPSMSID',prop:'Visible'}]}");
         setEventMetadata("LBLWWPSMSSTATUSFILTER.CLICK","{handler:'E128R1',iparms:[{av:'divWwpsmsstatusfiltercontainer_Class',ctrl:'WWPSMSSTATUSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPSMSSTATUSFILTER.CLICK",",oparms:[{av:'divWwpsmsstatusfiltercontainer_Class',ctrl:'WWPSMSSTATUSFILTERCONTAINER',prop:'Class'},{av:'cmbavCwwpsmsstatus'}]}");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK","{handler:'E138R1',iparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWWPNOTIFICATIONIDFILTER.CLICK",",oparms:[{av:'divWwpnotificationidfiltercontainer_Class',ctrl:'WWPNOTIFICATIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwwpnotificationid_Visible',ctrl:'vCWWPNOTIFICATIONID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E178R2',iparms:[{av:'A42WWPSMSId',fld:'WWPSMSID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pWWPSMSId',fld:'vPWWPSMSID',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSMSId',fld:'vCWWPSMSID',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwwpsmsstatus'},{av:'AV7cWWPSMSStatus',fld:'vCWWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'AV8cWWPSMSCreated',fld:'vCWWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV9cWWPSMSScheduled',fld:'vCWWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPSMSProcessed',fld:'vCWWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSMSId',fld:'vCWWPSMSID',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwwpsmsstatus'},{av:'AV7cWWPSMSStatus',fld:'vCWWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'AV8cWWPSMSCreated',fld:'vCWWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV9cWWPSMSScheduled',fld:'vCWWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPSMSProcessed',fld:'vCWWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSMSId',fld:'vCWWPSMSID',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwwpsmsstatus'},{av:'AV7cWWPSMSStatus',fld:'vCWWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'AV8cWWPSMSCreated',fld:'vCWWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV9cWWPSMSScheduled',fld:'vCWWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPSMSProcessed',fld:'vCWWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWWPSMSId',fld:'vCWWPSMSID',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwwpsmsstatus'},{av:'AV7cWWPSMSStatus',fld:'vCWWPSMSSTATUS',pic:'ZZZ9',type:'int'},{av:'AV8cWWPSMSCreated',fld:'vCWWPSMSCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV9cWWPSMSScheduled',fld:'vCWWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV10cWWPSMSProcessed',fld:'vCWWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'AV11cWWPNotificationId',fld:'vCWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPSMSSTATUS","{handler:'Validv_Cwwpsmsstatus',iparms:[]");
         setEventMetadata("VALIDV_CWWPSMSSTATUS",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPSMSCREATED","{handler:'Validv_Cwwpsmscreated',iparms:[]");
         setEventMetadata("VALIDV_CWWPSMSCREATED",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPSMSSCHEDULED","{handler:'Validv_Cwwpsmsscheduled',iparms:[]");
         setEventMetadata("VALIDV_CWWPSMSSCHEDULED",",oparms:[]}");
         setEventMetadata("VALIDV_CWWPSMSPROCESSED","{handler:'Validv_Cwwpsmsprocessed',iparms:[]");
         setEventMetadata("VALIDV_CWWPSMSPROCESSED",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpnotificationid',iparms:[]");
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
         AV8cWWPSMSCreated = (DateTime)(DateTime.MinValue);
         AV9cWWPSMSScheduled = (DateTime)(DateTime.MinValue);
         AV10cWWPSMSProcessed = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwwpsmsidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwwpsmsstatusfilter_Jsonclick = "";
         lblLblwwpsmscreatedfilter_Jsonclick = "";
         lblLblwwpsmsscheduledfilter_Jsonclick = "";
         lblLblwwpsmsprocessedfilter_Jsonclick = "";
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
         AV14Linkselection_GXI = "";
         A49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         H008R2_A31WWPNotificationId = new long[1] ;
         H008R2_n31WWPNotificationId = new bool[] {false} ;
         H008R2_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         H008R2_n44WWPSMSProcessed = new bool[] {false} ;
         H008R2_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         H008R2_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         H008R2_A43WWPSMSStatus = new short[1] ;
         H008R2_A42WWPSMSId = new long[1] ;
         H008R3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.gx00b0__default(),
            new Object[][] {
                new Object[] {
               H008R2_A31WWPNotificationId, H008R2_n31WWPNotificationId, H008R2_A44WWPSMSProcessed, H008R2_n44WWPSMSProcessed, H008R2_A50WWPSMSScheduled, H008R2_A49WWPSMSCreated, H008R2_A43WWPSMSStatus, H008R2_A42WWPSMSId
               }
               , new Object[] {
               H008R3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cWWPSMSStatus ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A43WWPSMSStatus ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCwwpsmsid_Enabled ;
      private int edtavCwwpsmsid_Visible ;
      private int edtavCwwpsmscreated_Enabled ;
      private int edtavCwwpsmsscheduled_Enabled ;
      private int edtavCwwpsmsprocessed_Enabled ;
      private int edtavCwwpnotificationid_Enabled ;
      private int edtavCwwpnotificationid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPSMSId_Enabled ;
      private int edtWWPSMSCreated_Enabled ;
      private int edtWWPSMSScheduled_Enabled ;
      private int edtWWPSMSProcessed_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pWWPSMSId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cWWPSMSId ;
      private long AV11cWWPNotificationId ;
      private long A42WWPSMSId ;
      private long A31WWPNotificationId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWwpsmsidfiltercontainer_Class ;
      private string divWwpsmsstatusfiltercontainer_Class ;
      private string divWwpnotificationidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWwpsmsidfiltercontainer_Internalname ;
      private string lblLblwwpsmsidfilter_Internalname ;
      private string lblLblwwpsmsidfilter_Jsonclick ;
      private string edtavCwwpsmsid_Internalname ;
      private string TempTags ;
      private string edtavCwwpsmsid_Jsonclick ;
      private string divWwpsmsstatusfiltercontainer_Internalname ;
      private string lblLblwwpsmsstatusfilter_Internalname ;
      private string lblLblwwpsmsstatusfilter_Jsonclick ;
      private string cmbavCwwpsmsstatus_Internalname ;
      private string cmbavCwwpsmsstatus_Jsonclick ;
      private string divWwpsmscreatedfiltercontainer_Internalname ;
      private string lblLblwwpsmscreatedfilter_Internalname ;
      private string lblLblwwpsmscreatedfilter_Jsonclick ;
      private string edtavCwwpsmscreated_Internalname ;
      private string edtavCwwpsmscreated_Jsonclick ;
      private string divWwpsmsscheduledfiltercontainer_Internalname ;
      private string lblLblwwpsmsscheduledfilter_Internalname ;
      private string lblLblwwpsmsscheduledfilter_Jsonclick ;
      private string edtavCwwpsmsscheduled_Internalname ;
      private string edtavCwwpsmsscheduled_Jsonclick ;
      private string divWwpsmsprocessedfiltercontainer_Internalname ;
      private string lblLblwwpsmsprocessedfilter_Internalname ;
      private string lblLblwwpsmsprocessedfilter_Jsonclick ;
      private string edtavCwwpsmsprocessed_Internalname ;
      private string edtavCwwpsmsprocessed_Jsonclick ;
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
      private string edtWWPSMSId_Internalname ;
      private string cmbWWPSMSStatus_Internalname ;
      private string edtWWPSMSCreated_Internalname ;
      private string edtWWPSMSScheduled_Internalname ;
      private string edtWWPSMSProcessed_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWWPSMSId_Jsonclick ;
      private string GXCCtl ;
      private string cmbWWPSMSStatus_Jsonclick ;
      private string edtWWPSMSCreated_Jsonclick ;
      private string edtWWPSMSScheduled_Jsonclick ;
      private string edtWWPSMSProcessed_Jsonclick ;
      private string edtWWPNotificationId_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8cWWPSMSCreated ;
      private DateTime AV9cWWPSMSScheduled ;
      private DateTime AV10cWWPSMSProcessed ;
      private DateTime A49WWPSMSCreated ;
      private DateTime A50WWPSMSScheduled ;
      private DateTime A44WWPSMSProcessed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n44WWPSMSProcessed ;
      private bool n31WWPNotificationId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCwwpsmsstatus ;
      private GXCombobox cmbWWPSMSStatus ;
      private IDataStoreProvider pr_default ;
      private long[] H008R2_A31WWPNotificationId ;
      private bool[] H008R2_n31WWPNotificationId ;
      private DateTime[] H008R2_A44WWPSMSProcessed ;
      private bool[] H008R2_n44WWPSMSProcessed ;
      private DateTime[] H008R2_A50WWPSMSScheduled ;
      private DateTime[] H008R2_A49WWPSMSCreated ;
      private short[] H008R2_A43WWPSMSStatus ;
      private long[] H008R2_A42WWPSMSId ;
      private long[] H008R3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pWWPSMSId ;
   }

   public class gx00b0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008R2( IGxContext context ,
                                             short AV7cWWPSMSStatus ,
                                             DateTime AV8cWWPSMSCreated ,
                                             DateTime AV9cWWPSMSScheduled ,
                                             DateTime AV10cWWPSMSProcessed ,
                                             long AV11cWWPNotificationId ,
                                             short A43WWPSMSStatus ,
                                             DateTime A49WWPSMSCreated ,
                                             DateTime A50WWPSMSScheduled ,
                                             DateTime A44WWPSMSProcessed ,
                                             long A31WWPNotificationId ,
                                             long AV6cWWPSMSId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [WWPNotificationId], [WWPSMSProcessed], [WWPSMSScheduled], [WWPSMSCreated], [WWPSMSStatus], [WWPSMSId]";
         sFromString = " FROM [WWP_SMS]";
         sOrderString = "";
         AddWhere(sWhereString, "([WWPSMSId] >= @AV6cWWPSMSId)");
         if ( ! (0==AV7cWWPSMSStatus) )
         {
            AddWhere(sWhereString, "([WWPSMSStatus] >= @AV7cWWPSMSStatus)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cWWPSMSCreated) )
         {
            AddWhere(sWhereString, "([WWPSMSCreated] >= @AV8cWWPSMSCreated)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cWWPSMSScheduled) )
         {
            AddWhere(sWhereString, "([WWPSMSScheduled] >= @AV9cWWPSMSScheduled)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cWWPSMSProcessed) )
         {
            AddWhere(sWhereString, "([WWPSMSProcessed] >= @AV10cWWPSMSProcessed)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cWWPNotificationId) )
         {
            AddWhere(sWhereString, "([WWPNotificationId] >= @AV11cWWPNotificationId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [WWPSMSId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H008R3( IGxContext context ,
                                             short AV7cWWPSMSStatus ,
                                             DateTime AV8cWWPSMSCreated ,
                                             DateTime AV9cWWPSMSScheduled ,
                                             DateTime AV10cWWPSMSProcessed ,
                                             long AV11cWWPNotificationId ,
                                             short A43WWPSMSStatus ,
                                             DateTime A49WWPSMSCreated ,
                                             DateTime A50WWPSMSScheduled ,
                                             DateTime A44WWPSMSProcessed ,
                                             long A31WWPNotificationId ,
                                             long AV6cWWPSMSId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [WWP_SMS]";
         AddWhere(sWhereString, "([WWPSMSId] >= @AV6cWWPSMSId)");
         if ( ! (0==AV7cWWPSMSStatus) )
         {
            AddWhere(sWhereString, "([WWPSMSStatus] >= @AV7cWWPSMSStatus)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cWWPSMSCreated) )
         {
            AddWhere(sWhereString, "([WWPSMSCreated] >= @AV8cWWPSMSCreated)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cWWPSMSScheduled) )
         {
            AddWhere(sWhereString, "([WWPSMSScheduled] >= @AV9cWWPSMSScheduled)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cWWPSMSProcessed) )
         {
            AddWhere(sWhereString, "([WWPSMSProcessed] >= @AV10cWWPSMSProcessed)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cWWPNotificationId) )
         {
            AddWhere(sWhereString, "([WWPNotificationId] >= @AV11cWWPNotificationId)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H008R2(context, (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] );
               case 1 :
                     return conditional_H008R3(context, (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] );
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
          Object[] prmH008R2;
          prmH008R2 = new Object[] {
          new ParDef("@AV6cWWPSMSId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cWWPSMSStatus",GXType.Int16,4,0) ,
          new ParDef("@AV8cWWPSMSCreated",GXType.DateTime2,10,12) ,
          new ParDef("@AV9cWWPSMSScheduled",GXType.DateTime2,10,12) ,
          new ParDef("@AV10cWWPSMSProcessed",GXType.DateTime2,10,12) ,
          new ParDef("@AV11cWWPNotificationId",GXType.Decimal,10,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008R3;
          prmH008R3 = new Object[] {
          new ParDef("@AV6cWWPSMSId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cWWPSMSStatus",GXType.Int16,4,0) ,
          new ParDef("@AV8cWWPSMSCreated",GXType.DateTime2,10,12) ,
          new ParDef("@AV9cWWPSMSScheduled",GXType.DateTime2,10,12) ,
          new ParDef("@AV10cWWPSMSProcessed",GXType.DateTime2,10,12) ,
          new ParDef("@AV11cWWPNotificationId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008R2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H008R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008R3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

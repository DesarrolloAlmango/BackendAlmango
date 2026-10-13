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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_discussionswc( )
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

      public wwp_discussionswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           string aP1_WWPDiscussionMessageEntityRecordId ,
                           string aP2_WWPSubscriptionEntityRecordDescription ,
                           string aP3_WWPNotificationLink )
      {
         this.AV8WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPDiscussionMessageEntityRecordId = aP1_WWPDiscussionMessageEntityRecordId;
         this.AV10WWPSubscriptionEntityRecordDescription = aP2_WWPSubscriptionEntityRecordDescription;
         this.AV11WWPNotificationLink = aP3_WWPNotificationLink;
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
         chkavIsdiscussionanswerswcloaded = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPEntityName");
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
                  AV8WWPEntityName = GetPar( "WWPEntityName");
                  AssignAttri(sPrefix, false, "AV8WWPEntityName", AV8WWPEntityName);
                  AV9WWPDiscussionMessageEntityRecordId = GetPar( "WWPDiscussionMessageEntityRecordId");
                  AssignAttri(sPrefix, false, "AV9WWPDiscussionMessageEntityRecordId", AV9WWPDiscussionMessageEntityRecordId);
                  AV10WWPSubscriptionEntityRecordDescription = GetPar( "WWPSubscriptionEntityRecordDescription");
                  AssignAttri(sPrefix, false, "AV10WWPSubscriptionEntityRecordDescription", AV10WWPSubscriptionEntityRecordDescription);
                  AV11WWPNotificationLink = GetPar( "WWPNotificationLink");
                  AssignAttri(sPrefix, false, "AV11WWPNotificationLink", AV11WWPNotificationLink);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV8WWPEntityName,(string)AV9WWPDiscussionMessageEntityRecordId,(string)AV10WWPSubscriptionEntityRecordDescription,(string)AV11WWPNotificationLink});
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
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_16 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_16"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_16_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_16_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_16_idx = GetPar( "sGXsfl_16_idx");
         sPrefix = GetPar( "sPrefix");
         chkavIsdiscussionanswerswcloaded.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavIsdiscussionanswerswcloaded_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsdiscussionanswerswcloaded.Visible), 5, 0), !bGXsfl_16_Refreshing);
         edtWWPDiscussionMessageId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtWWPDiscussionMessageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0), !bGXsfl_16_Refreshing);
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
         AV9WWPDiscussionMessageEntityRecordId = GetPar( "WWPDiscussionMessageEntityRecordId");
         AV21Pgmname = GetPar( "Pgmname");
         chkavIsdiscussionanswerswcloaded.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavIsdiscussionanswerswcloaded_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsdiscussionanswerswcloaded.Visible), 5, 0), !bGXsfl_16_Refreshing);
         edtWWPDiscussionMessageId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtWWPDiscussionMessageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0), !bGXsfl_16_Refreshing);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV9WWPDiscussionMessageEntityRecordId, AV21Pgmname, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV21Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
               WS0N2( ) ;
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
            context.SendWebValue( context.GetMessage( "Discussions of a record", "")) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.discussions.wwp_discussionswc.aspx"+UrlEncode(StringUtil.RTrim(AV8WWPEntityName)) + "," + UrlEncode(StringUtil.RTrim(AV9WWPDiscussionMessageEntityRecordId)) + "," + UrlEncode(StringUtil.RTrim(AV10WWPSubscriptionEntityRecordDescription)) + "," + UrlEncode(StringUtil.RTrim(AV11WWPNotificationLink));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_16", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_16), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPEntityName", wcpOAV8WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9WWPDiscussionMessageEntityRecordId", wcpOAV9WWPDiscussionMessageEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10WWPSubscriptionEntityRecordDescription", wcpOAV10WWPSubscriptionEntityRecordDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11WWPNotificationLink", wcpOAV11WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYNAME", AV8WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDISCUSSIONMESSAGEENTITYRECORDID", AV9WWPDiscussionMessageEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION", AV10WWPSubscriptionEntityRecordDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONLINK", AV11WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCMENTIONS_Datalistproc", StringUtil.RTrim( Ucmentions_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vISDISCUSSIONANSWERSWCLOADED_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsdiscussionanswerswcloaded.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPDISCUSSIONMESSAGEID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0N2( )
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
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            if ( ! ( WebComp_Wcdiscussionsonethreadwc == null ) )
            {
               WebComp_Wcdiscussionsonethreadwc.componentjscripts();
            }
            if ( ! ( WebComp_Discussionsonethreadcollapsedwc == null ) )
            {
               WebComp_Discussionsonethreadcollapsedwc.componentjscripts();
            }
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
         return "WWPBaseObjects.Discussions.WWP_DiscussionsWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Discussions of a record", "") ;
      }

      protected void WB0N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.discussions.wwp_discussionswc.aspx");
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainDiscussions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDiscussionstitle_Internalname, context.GetMessage( "Discussions", ""), "", "", lblDiscussionstitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleWWP", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-end;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNewthread_Internalname, context.GetMessage( "WWP_StartNewThread", ""), "", "", lblNewthread_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "StartNewThreadTB", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 DiscussionsGridCell", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl16( ) ;
         }
         if ( wbEnd == 16 )
         {
            wbEnd = 0;
            nRC_GXsfl_16 = (int)(nGXsfl_16_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNewthreadcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 DiscussionNewMessageCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenewthread_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMessage_Internalname, context.GetMessage( "Message", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_16_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMessage_Internalname, AV17Message, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtavMessage_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", context.GetMessage( "Type a message to create a new thread...", ""), -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-end;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnter_Internalname, context.GetMessage( "<i class=\"fas fa-paper-plane DiscussionsSendIcon\"></i>", ""), "", "", lblEnter_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", "", "TextBlock", 5, context.GetMessage( "GX_BtnEnter", ""), 1, 1, 0, 1, "HLP_WWPBaseObjects/Discussions/WWP_DiscussionsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmentions.SetProperty("DataListProc", Ucmentions_Datalistproc);
            ucUcmentions.Render(context, "wwp.suggest", Ucmentions_Internalname, sPrefix+"UCMENTIONSContainer");
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
            GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageEntityReco_Internalname, A545WWPDiscussionMessageEntityReco, StringUtil.RTrim( context.localUtil.Format( A545WWPDiscussionMessageEntityReco, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageEntityReco_Jsonclick, 0, "Attribute", "", "", "", "", edtWWPDiscussionMessageEntityReco_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Discussions/WWP_DiscussionsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 16 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0N2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Discussions of a record", ""), 0) ;
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
               STRUP0N0( ) ;
            }
         }
      }

      protected void WS0N2( )
      {
         START0N2( ) ;
         EVT0N2( ) ;
      }

      protected void EVT0N2( )
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
                                 STRUP0N0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
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
                                          /* Execute user event: Enter */
                                          E110N2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavMessage_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              nGXsfl_16_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_16_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_16_idx), 4, 0), 4, "0");
                              SubsflControlProps_162( ) ;
                              AV19UserExtendedPhoto = cgiGet( edtavUserextendedphoto_Internalname);
                              AssignProp(sPrefix, false, edtavUserextendedphoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19UserExtendedPhoto)) ? AV22Userextendedphoto_GXI : context.convertURL( context.PathToRelativeUrl( AV19UserExtendedPhoto))), !bGXsfl_16_Refreshing);
                              AssignProp(sPrefix, false, edtavUserextendedphoto_Internalname, "SrcSet", context.GetImageSrcSet( AV19UserExtendedPhoto), true);
                              A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
                              A543WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname), 0);
                              A544WWPDiscussionMessageMessage = cgiGet( edtWWPDiscussionMessageMessage_Internalname);
                              AV18IsDiscussionAnswersWCLoaded = StringUtil.StrToBool( cgiGet( chkavIsdiscussionanswerswcloaded_Internalname));
                              AssignAttri(sPrefix, false, chkavIsdiscussionanswerswcloaded_Internalname, AV18IsDiscussionAnswersWCLoaded);
                              A540WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E120N2 ();
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
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E130N2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E140N2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP0N0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 45 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0045" + sEvtType;
                           OldWcdiscussionsonethreadwc = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcdiscussionsonethreadwc) == 0 ) || ( StringUtil.StrCmp(OldWcdiscussionsonethreadwc, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcdiscussionsonethreadwc, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcdiscussionsonethreadwc";
                              WebComp_GX_Process_Component = OldWcdiscussionsonethreadwc;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0045", sEvtType, sEvt);
                           }
                           nGXsfl_16_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcdiscussionsonethreadwc";
                           WebComp_GX_Process_Component = OldWcdiscussionsonethreadwc;
                        }
                        else if ( nCmpId == 48 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0048" + sEvtType;
                           OldDiscussionsonethreadcollapsedwc = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldDiscussionsonethreadcollapsedwc) == 0 ) || ( StringUtil.StrCmp(OldDiscussionsonethreadcollapsedwc, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldDiscussionsonethreadcollapsedwc, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldDiscussionsonethreadcollapsedwc";
                              WebComp_GX_Process_Component = OldDiscussionsonethreadcollapsedwc;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0048", sEvtType, sEvt);
                           }
                           nGXsfl_16_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Discussionsonethreadcollapsedwc";
                           WebComp_GX_Process_Component = OldDiscussionsonethreadcollapsedwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0N2( ) ;
            }
         }
      }

      protected void PA0N2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.discussions.wwp_discussionswc.aspx")), "wwpbaseobjects.discussions.wwp_discussionswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.discussions.wwp_discussionswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPEntityName");
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
               GX_FocusControl = edtavMessage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_162( ) ;
         while ( nGXsfl_16_idx <= nRC_GXsfl_16 )
         {
            sendrow_162( ) ;
            nGXsfl_16_idx = ((subGrid_Islastpage==1)&&(nGXsfl_16_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_16_idx+1);
            sGXsfl_16_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_16_idx), 4, 0), 4, "0");
            SubsflControlProps_162( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV9WWPDiscussionMessageEntityRecordId ,
                                       string AV21Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0N2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
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
         RF0N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
      }

      protected void RF0N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 16;
         /* Execute user event: Refresh */
         E130N2 ();
         nGXsfl_16_idx = 1;
         sGXsfl_16_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_16_idx), 4, 0), 4, "0");
         SubsflControlProps_162( ) ;
         bGXsfl_16_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               WebComp_Wcdiscussionsonethreadwc.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Discussionsonethreadcollapsedwc_Component) != 0 )
               {
                  WebComp_Discussionsonethreadcollapsedwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_162( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H000N2 */
            pr_default.execute(0, new Object[] {AV9WWPDiscussionMessageEntityRecordId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_16_idx = 1;
            sGXsfl_16_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_16_idx), 4, 0), 4, "0");
            SubsflControlProps_162( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1WWPUserExtendedId = H000N2_A1WWPUserExtendedId[0];
               A545WWPDiscussionMessageEntityReco = H000N2_A545WWPDiscussionMessageEntityReco[0];
               AssignAttri(sPrefix, false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
               A540WWPDiscussionMessageId = H000N2_A540WWPDiscussionMessageId[0];
               A544WWPDiscussionMessageMessage = H000N2_A544WWPDiscussionMessageMessage[0];
               A543WWPDiscussionMessageDate = H000N2_A543WWPDiscussionMessageDate[0];
               A2WWPUserExtendedFullName = H000N2_A2WWPUserExtendedFullName[0];
               A2WWPUserExtendedFullName = H000N2_A2WWPUserExtendedFullName[0];
               /* Execute user event: Grid.Load */
               E140N2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 16;
            WB0N0( ) ;
         }
         bGXsfl_16_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0N2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
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
         /* Using cursor H000N3 */
         pr_default.execute(1, new Object[] {AV9WWPDiscussionMessageEntityRecordId});
         GRID_nRecordCount = H000N3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV9WWPDiscussionMessageEntityRecordId, AV21Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV9WWPDiscussionMessageEntityRecordId, AV21Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV9WWPDiscussionMessageEntityRecordId, AV21Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV9WWPDiscussionMessageEntityRecordId, AV21Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV9WWPDiscussionMessageEntityRecordId, AV21Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPDiscussionMessageDate_Enabled = 0;
         edtWWPDiscussionMessageMessage_Enabled = 0;
         edtWWPDiscussionMessageId_Enabled = 0;
         edtWWPDiscussionMessageEntityReco_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPDiscussionMessageEntityReco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageEntityReco_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_16 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_16"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV8WWPEntityName = cgiGet( sPrefix+"wcpOAV8WWPEntityName");
            wcpOAV9WWPDiscussionMessageEntityRecordId = cgiGet( sPrefix+"wcpOAV9WWPDiscussionMessageEntityRecordId");
            wcpOAV10WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"wcpOAV10WWPSubscriptionEntityRecordDescription");
            wcpOAV11WWPNotificationLink = cgiGet( sPrefix+"wcpOAV11WWPNotificationLink");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ucmentions_Datalistproc = cgiGet( sPrefix+"UCMENTIONS_Datalistproc");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV17Message = cgiGet( edtavMessage_Internalname);
            AssignAttri(sPrefix, false, "AV17Message", AV17Message);
            A545WWPDiscussionMessageEntityReco = cgiGet( edtWWPDiscussionMessageEntityReco_Internalname);
            AssignAttri(sPrefix, false, "A545WWPDiscussionMessageEntityReco", A545WWPDiscussionMessageEntityReco);
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
         E120N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120N2( )
      {
         /* Start Routine */
         returnInSub = false;
         chkavIsdiscussionanswerswcloaded.Visible = 0;
         AssignProp(sPrefix, false, chkavIsdiscussionanswerswcloaded_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsdiscussionanswerswcloaded.Visible), 5, 0), !bGXsfl_16_Refreshing);
         edtWWPDiscussionMessageId_Visible = 0;
         AssignProp(sPrefix, false, edtWWPDiscussionMessageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0), !bGXsfl_16_Refreshing);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         edtWWPDiscussionMessageEntityReco_Visible = 0;
         AssignProp(sPrefix, false, edtWWPDiscussionMessageEntityReco_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageEntityReco_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E140N2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Discussionsonethreadcollapsedwc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Discussionsonethreadcollapsedwc_Component), StringUtil.Lower( "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadCollapsedWC")) != 0 )
         {
            WebComp_Discussionsonethreadcollapsedwc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc", new Object[] {context} );
            WebComp_Discussionsonethreadcollapsedwc.ComponentInit();
            WebComp_Discussionsonethreadcollapsedwc.Name = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadCollapsedWC";
            WebComp_Discussionsonethreadcollapsedwc_Component = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadCollapsedWC";
         }
         if ( StringUtil.Len( WebComp_Discussionsonethreadcollapsedwc_Component) != 0 )
         {
            WebComp_Discussionsonethreadcollapsedwc.setjustcreated();
            WebComp_Discussionsonethreadcollapsedwc.componentprepare(new Object[] {(string)sPrefix+"W0048",(string)sGXsfl_16_idx,(long)A540WWPDiscussionMessageId});
            WebComp_Discussionsonethreadcollapsedwc.componentbind(new Object[] {(string)""});
         }
         if ( ! bGXsfl_16_Refreshing )
         {
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Discussionsonethreadcollapsedwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0048"+sGXsfl_16_idx);
               WebComp_Discussionsonethreadcollapsedwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 16;
         }
         sendrow_162( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_16_Refreshing )
         {
            context.DoAjaxLoad(16, GridRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E110N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110N2( )
      {
         /* Enter Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV21Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV21Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV20Session.Get(AV21Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV20Session.Get(AV21Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV21Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13TrnContext.gxTpr_Callerobject = AV21Pgmname;
         AV13TrnContext.gxTpr_Callerondelete = true;
         AV13TrnContext.gxTpr_Callerurl = AV12HTTPRequest.ScriptName+"?"+AV12HTTPRequest.QueryString;
         AV13TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Discussions.WWP_DiscussionMessage";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV14TrnContextAtt.gxTpr_Attributename = "WWPDiscussionMessageEntityRecordId";
         AV14TrnContextAtt.gxTpr_Attributevalue = AV9WWPDiscussionMessageEntityRecordId;
         AV13TrnContext.gxTpr_Attributes.Add(AV14TrnContextAtt, 0);
         AV20Session.Set("TrnContext", AV13TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8WWPEntityName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV8WWPEntityName", AV8WWPEntityName);
         AV9WWPDiscussionMessageEntityRecordId = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV9WWPDiscussionMessageEntityRecordId", AV9WWPDiscussionMessageEntityRecordId);
         AV10WWPSubscriptionEntityRecordDescription = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV10WWPSubscriptionEntityRecordDescription", AV10WWPSubscriptionEntityRecordDescription);
         AV11WWPNotificationLink = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV11WWPNotificationLink", AV11WWPNotificationLink);
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
         PA0N2( ) ;
         WS0N2( ) ;
         WE0N2( ) ;
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
         sCtrlAV8WWPEntityName = (string)((string)getParm(obj,0));
         sCtrlAV9WWPDiscussionMessageEntityRecordId = (string)((string)getParm(obj,1));
         sCtrlAV10WWPSubscriptionEntityRecordDescription = (string)((string)getParm(obj,2));
         sCtrlAV11WWPNotificationLink = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\discussions\\wwp_discussionswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8WWPEntityName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV8WWPEntityName", AV8WWPEntityName);
            AV9WWPDiscussionMessageEntityRecordId = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV9WWPDiscussionMessageEntityRecordId", AV9WWPDiscussionMessageEntityRecordId);
            AV10WWPSubscriptionEntityRecordDescription = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV10WWPSubscriptionEntityRecordDescription", AV10WWPSubscriptionEntityRecordDescription);
            AV11WWPNotificationLink = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV11WWPNotificationLink", AV11WWPNotificationLink);
         }
         wcpOAV8WWPEntityName = cgiGet( sPrefix+"wcpOAV8WWPEntityName");
         wcpOAV9WWPDiscussionMessageEntityRecordId = cgiGet( sPrefix+"wcpOAV9WWPDiscussionMessageEntityRecordId");
         wcpOAV10WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"wcpOAV10WWPSubscriptionEntityRecordDescription");
         wcpOAV11WWPNotificationLink = cgiGet( sPrefix+"wcpOAV11WWPNotificationLink");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV8WWPEntityName, wcpOAV8WWPEntityName) != 0 ) || ( StringUtil.StrCmp(AV9WWPDiscussionMessageEntityRecordId, wcpOAV9WWPDiscussionMessageEntityRecordId) != 0 ) || ( StringUtil.StrCmp(AV10WWPSubscriptionEntityRecordDescription, wcpOAV10WWPSubscriptionEntityRecordDescription) != 0 ) || ( StringUtil.StrCmp(AV11WWPNotificationLink, wcpOAV11WWPNotificationLink) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV8WWPEntityName = AV8WWPEntityName;
         wcpOAV9WWPDiscussionMessageEntityRecordId = AV9WWPDiscussionMessageEntityRecordId;
         wcpOAV10WWPSubscriptionEntityRecordDescription = AV10WWPSubscriptionEntityRecordDescription;
         wcpOAV11WWPNotificationLink = AV11WWPNotificationLink;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8WWPEntityName = cgiGet( sPrefix+"AV8WWPEntityName_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPEntityName) > 0 )
         {
            AV8WWPEntityName = cgiGet( sCtrlAV8WWPEntityName);
            AssignAttri(sPrefix, false, "AV8WWPEntityName", AV8WWPEntityName);
         }
         else
         {
            AV8WWPEntityName = cgiGet( sPrefix+"AV8WWPEntityName_PARM");
         }
         sCtrlAV9WWPDiscussionMessageEntityRecordId = cgiGet( sPrefix+"AV9WWPDiscussionMessageEntityRecordId_CTRL");
         if ( StringUtil.Len( sCtrlAV9WWPDiscussionMessageEntityRecordId) > 0 )
         {
            AV9WWPDiscussionMessageEntityRecordId = cgiGet( sCtrlAV9WWPDiscussionMessageEntityRecordId);
            AssignAttri(sPrefix, false, "AV9WWPDiscussionMessageEntityRecordId", AV9WWPDiscussionMessageEntityRecordId);
         }
         else
         {
            AV9WWPDiscussionMessageEntityRecordId = cgiGet( sPrefix+"AV9WWPDiscussionMessageEntityRecordId_PARM");
         }
         sCtrlAV10WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"AV10WWPSubscriptionEntityRecordDescription_CTRL");
         if ( StringUtil.Len( sCtrlAV10WWPSubscriptionEntityRecordDescription) > 0 )
         {
            AV10WWPSubscriptionEntityRecordDescription = cgiGet( sCtrlAV10WWPSubscriptionEntityRecordDescription);
            AssignAttri(sPrefix, false, "AV10WWPSubscriptionEntityRecordDescription", AV10WWPSubscriptionEntityRecordDescription);
         }
         else
         {
            AV10WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"AV10WWPSubscriptionEntityRecordDescription_PARM");
         }
         sCtrlAV11WWPNotificationLink = cgiGet( sPrefix+"AV11WWPNotificationLink_CTRL");
         if ( StringUtil.Len( sCtrlAV11WWPNotificationLink) > 0 )
         {
            AV11WWPNotificationLink = cgiGet( sCtrlAV11WWPNotificationLink);
            AssignAttri(sPrefix, false, "AV11WWPNotificationLink", AV11WWPNotificationLink);
         }
         else
         {
            AV11WWPNotificationLink = cgiGet( sPrefix+"AV11WWPNotificationLink_PARM");
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
         PA0N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0N2( ) ;
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
         WS0N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPEntityName_PARM", AV8WWPEntityName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPEntityName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPEntityName_CTRL", StringUtil.RTrim( sCtrlAV8WWPEntityName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPDiscussionMessageEntityRecordId_PARM", AV9WWPDiscussionMessageEntityRecordId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9WWPDiscussionMessageEntityRecordId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9WWPDiscussionMessageEntityRecordId_CTRL", StringUtil.RTrim( sCtrlAV9WWPDiscussionMessageEntityRecordId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPSubscriptionEntityRecordDescription_PARM", AV10WWPSubscriptionEntityRecordDescription);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10WWPSubscriptionEntityRecordDescription)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10WWPSubscriptionEntityRecordDescription_CTRL", StringUtil.RTrim( sCtrlAV10WWPSubscriptionEntityRecordDescription));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPNotificationLink_PARM", AV11WWPNotificationLink);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11WWPNotificationLink)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPNotificationLink_CTRL", StringUtil.RTrim( sCtrlAV11WWPNotificationLink));
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
         WE0N2( ) ;
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wcdiscussionsonethreadwc == null ) )
         {
            WebComp_Wcdiscussionsonethreadwc.componentjscripts();
         }
         if ( ! ( WebComp_Discussionsonethreadcollapsedwc == null ) )
         {
            WebComp_Discussionsonethreadcollapsedwc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcdiscussionsonethreadwc == null ) )
         {
            WebComp_Wcdiscussionsonethreadwc.componentthemes();
         }
         if ( ! ( WebComp_Discussionsonethreadcollapsedwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Discussionsonethreadcollapsedwc_Component) != 0 )
            {
               WebComp_Discussionsonethreadcollapsedwc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302122558", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionswc.js", "?20267302122558", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_162( )
      {
         edtavUserextendedphoto_Internalname = sPrefix+"vUSEREXTENDEDPHOTO_"+sGXsfl_16_idx;
         edtWWPUserExtendedFullName_Internalname = sPrefix+"WWPUSEREXTENDEDFULLNAME_"+sGXsfl_16_idx;
         edtWWPDiscussionMessageDate_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEDATE_"+sGXsfl_16_idx;
         edtWWPDiscussionMessageMessage_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEMESSAGE_"+sGXsfl_16_idx;
         chkavIsdiscussionanswerswcloaded_Internalname = sPrefix+"vISDISCUSSIONANSWERSWCLOADED_"+sGXsfl_16_idx;
         edtWWPDiscussionMessageId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEID_"+sGXsfl_16_idx;
      }

      protected void SubsflControlProps_fel_162( )
      {
         edtavUserextendedphoto_Internalname = sPrefix+"vUSEREXTENDEDPHOTO_"+sGXsfl_16_fel_idx;
         edtWWPUserExtendedFullName_Internalname = sPrefix+"WWPUSEREXTENDEDFULLNAME_"+sGXsfl_16_fel_idx;
         edtWWPDiscussionMessageDate_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEDATE_"+sGXsfl_16_fel_idx;
         edtWWPDiscussionMessageMessage_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEMESSAGE_"+sGXsfl_16_fel_idx;
         chkavIsdiscussionanswerswcloaded_Internalname = sPrefix+"vISDISCUSSIONANSWERSWCLOADED_"+sGXsfl_16_fel_idx;
         edtWWPDiscussionMessageId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEID_"+sGXsfl_16_fel_idx;
      }

      protected void sendrow_162( )
      {
         sGXsfl_16_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_16_idx), 4, 0), 4, "0");
         SubsflControlProps_162( ) ;
         WB0N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_16_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_16_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_16_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDiscussioncardcell_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginBottom15",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDiscussioncard_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"DiscussionCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecard_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellPaddingTop5",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",context.GetMessage( "User Extended Photo", ""),(string)"gx-form-item AttributeDiscussionImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Static Bitmap Variable */
            ClassString = "AttributeDiscussionImage" + " " + ((StringUtil.StrCmp(edtavUserextendedphoto_gximage, "")==0) ? "" : "GX_Image_"+edtavUserextendedphoto_gximage+"_Class");
            StyleString = "";
            AV19UserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV19UserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( AV22Userextendedphoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV19UserExtendedPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19UserExtendedPhoto)) ? AV22Userextendedphoto_GXI : context.PathToRelativeUrl( AV19UserExtendedPhoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUserextendedphoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV19UserExtendedPhoto_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTabletitle_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablemergedwwpuserextendedfullname_Internalname+"_"+sGXsfl_16_idx,(short)1,(string)"TableMerged",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"MergeDataCell"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedFullName_Internalname,context.GetMessage( "User Full Name", ""),(string)"gx-form-item AttributeDiscussionUserNameLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "AttributeDiscussionUserName";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedFullName_Internalname,(string)A2WWPUserExtendedFullName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPUserExtendedFullName_Jsonclick,(short)0,(string)"AttributeDiscussionUserName",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)16,(short)0,(short)-1,(short)-1,(bool)true,(string)"WWPBaseObjects\\WWP_Description",(string)"start",(bool)true,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageDate_Internalname,context.GetMessage( "Message Date", ""),(string)"gx-form-item AttributeDiscussionDateLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "AttributeDiscussionDate";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageDate_Internalname,context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A543WWPDiscussionMessageDate, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPDiscussionMessageDate_Jsonclick,(short)0,(string)"AttributeDiscussionDate",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)16,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageMessage_Internalname,context.GetMessage( "Message", ""),(string)"col-sm-3 AttributeDiscussionDescriptionLabel",(short)0,(bool)true,(string)""});
            /* Multiple line edit */
            ClassString = "AttributeDiscussionDescription";
            StyleString = "";
            ClassString = "AttributeDiscussionDescription";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageMessage_Internalname,(string)A544WWPDiscussionMessageMessage,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divWcdiscussionsonethreadcell_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, sPrefix+"W0045"+sGXsfl_16_idx, StringUtil.RTrim( WebComp_Wcdiscussionsonethreadwc_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
            context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0045"+sGXsfl_16_idx+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( bGXsfl_16_Refreshing )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0045"+sGXsfl_16_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     WebComp_Wcdiscussionsonethreadwc.componentstart();
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcdiscussionsonethreadwc), StringUtil.Lower( WebComp_Wcdiscussionsonethreadwc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0045"+sGXsfl_16_idx);
               }
               WebComp_Wcdiscussionsonethreadwc.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcdiscussionsonethreadwc), StringUtil.Lower( WebComp_Wcdiscussionsonethreadwc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
            WebComp_Wcdiscussionsonethreadwc_Component = "";
            WebComp_Wcdiscussionsonethreadwc.componentjscripts();
            GridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcdiscussionsonethreadwc"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divDiscussionsonethreadcollapsedwccell_Internalname+"_"+sGXsfl_16_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            sendrow_16230( ) ;
         }
      }

      protected void sendrow_16230( )
      {
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0048"+sGXsfl_16_idx, StringUtil.RTrim( WebComp_Discussionsonethreadcollapsedwc_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0048"+sGXsfl_16_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_16_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Discussionsonethreadcollapsedwc_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0048"+sGXsfl_16_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Discussionsonethreadcollapsedwc_Component) != 0 )
                     {
                        WebComp_Discussionsonethreadcollapsedwc.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldDiscussionsonethreadcollapsedwc), StringUtil.Lower( WebComp_Discussionsonethreadcollapsedwc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0048"+sGXsfl_16_idx);
               }
               WebComp_Discussionsonethreadcollapsedwc.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldDiscussionsonethreadcollapsedwc), StringUtil.Lower( WebComp_Discussionsonethreadcollapsedwc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Discussionsonethreadcollapsedwc_Component = "";
         WebComp_Discussionsonethreadcollapsedwc.componentjscripts();
         GridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Discussionsonethreadcollapsedwc"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_16_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavIsdiscussionanswerswcloaded_Internalname,context.GetMessage( "Is Discussion Answers WCLoaded", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vISDISCUSSIONANSWERSWCLOADED_" + sGXsfl_16_idx;
         chkavIsdiscussionanswerswcloaded.Name = GXCCtl;
         chkavIsdiscussionanswerswcloaded.WebTags = "";
         chkavIsdiscussionanswerswcloaded.Caption = context.GetMessage( "Is Discussion Answers WCLoaded", "");
         AssignProp(sPrefix, false, chkavIsdiscussionanswerswcloaded_Internalname, "TitleCaption", chkavIsdiscussionanswerswcloaded.Caption, !bGXsfl_16_Refreshing);
         chkavIsdiscussionanswerswcloaded.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsdiscussionanswerswcloaded_Internalname,StringUtil.BoolToStr( AV18IsDiscussionAnswersWCLoaded),(string)"",context.GetMessage( "Is Discussion Answers WCLoaded", ""),chkavIsdiscussionanswerswcloaded.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageId_Internalname,context.GetMessage( "Message Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A540WWPDiscussionMessageId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A540WWPDiscussionMessageId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPDiscussionMessageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPDiscussionMessageId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)16,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("row");
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("table");
         }
         /* End of table */
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0N2( ) ;
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_16_idx = ((subGrid_Islastpage==1)&&(nGXsfl_16_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_16_idx+1);
         sGXsfl_16_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_16_idx), 4, 0), 4, "0");
         SubsflControlProps_162( ) ;
         /* End function sendrow_162 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vISDISCUSSIONANSWERSWCLOADED_" + sGXsfl_16_idx;
         chkavIsdiscussionanswerswcloaded.Name = GXCCtl;
         chkavIsdiscussionanswerswcloaded.WebTags = "";
         chkavIsdiscussionanswerswcloaded.Caption = context.GetMessage( "Is Discussion Answers WCLoaded", "");
         AssignProp(sPrefix, false, chkavIsdiscussionanswerswcloaded_Internalname, "TitleCaption", chkavIsdiscussionanswerswcloaded.Caption, !bGXsfl_16_Refreshing);
         chkavIsdiscussionanswerswcloaded.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl16( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"16\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV19UserExtendedPhoto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2WWPUserExtendedFullName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A543WWPDiscussionMessageDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A544WWPDiscussionMessageMessage));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV18IsDiscussionAnswersWCLoaded)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsdiscussionanswerswcloaded.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A540WWPDiscussionMessageId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
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
         lblDiscussionstitle_Internalname = sPrefix+"DISCUSSIONSTITLE";
         lblNewthread_Internalname = sPrefix+"NEWTHREAD";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtavUserextendedphoto_Internalname = sPrefix+"vUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = sPrefix+"WWPUSEREXTENDEDFULLNAME";
         edtWWPDiscussionMessageDate_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEDATE";
         tblTablemergedwwpuserextendedfullname_Internalname = sPrefix+"TABLEMERGEDWWPUSEREXTENDEDFULLNAME";
         edtWWPDiscussionMessageMessage_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEMESSAGE";
         divTabletitle_Internalname = sPrefix+"TABLETITLE";
         divTablecard_Internalname = sPrefix+"TABLECARD";
         divWcdiscussionsonethreadcell_Internalname = sPrefix+"WCDISCUSSIONSONETHREADCELL";
         divDiscussionsonethreadcollapsedwccell_Internalname = sPrefix+"DISCUSSIONSONETHREADCOLLAPSEDWCCELL";
         divDiscussioncard_Internalname = sPrefix+"DISCUSSIONCARD";
         divDiscussioncardcell_Internalname = sPrefix+"DISCUSSIONCARDCELL";
         chkavIsdiscussionanswerswcloaded_Internalname = sPrefix+"vISDISCUSSIONANSWERSWCLOADED";
         edtWWPDiscussionMessageId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEID";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = sPrefix+"UNNAMEDTABLEFSGRID";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtavMessage_Internalname = sPrefix+"vMESSAGE";
         lblEnter_Internalname = sPrefix+"ENTER";
         divTablenewthread_Internalname = sPrefix+"TABLENEWTHREAD";
         divNewthreadcell_Internalname = sPrefix+"NEWTHREADCELL";
         Ucmentions_Internalname = sPrefix+"UCMENTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtWWPDiscussionMessageEntityReco_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEENTITYRECO";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         edtWWPDiscussionMessageId_Jsonclick = "";
         chkavIsdiscussionanswerswcloaded.Caption = context.GetMessage( "Is Discussion Answers WCLoaded", "");
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtavUserextendedphoto_gximage = "";
         subGrid_Class = "FreeStyleGrid";
         edtWWPDiscussionMessageEntityReco_Enabled = 0;
         edtWWPDiscussionMessageId_Enabled = 0;
         edtWWPDiscussionMessageMessage_Enabled = 0;
         edtWWPDiscussionMessageDate_Enabled = 0;
         edtWWPUserExtendedFullName_Enabled = 0;
         subGrid_Backcolorstyle = 0;
         edtWWPDiscussionMessageEntityReco_Jsonclick = "";
         edtWWPDiscussionMessageEntityReco_Visible = 1;
         edtavMessage_Enabled = 1;
         Ucmentions_Datalistproc = "WWPBaseObjects.Discussions.WWP_GetUsersForDiscussionMentions";
         edtWWPDiscussionMessageId_Visible = 1;
         chkavIsdiscussionanswerswcloaded.Visible = 1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV9WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:'',type:'svchar'},{av:'chkavIsdiscussionanswerswcloaded.Visible',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E140N2',iparms:[{av:'A540WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWC'}]}");
         setEventMetadata("ENTER","{handler:'E110N2',iparms:[]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV9WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:'',type:'svchar'},{av:'chkavIsdiscussionanswerswcloaded.Visible',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix',type:'char'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV9WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:'',type:'svchar'},{av:'chkavIsdiscussionanswerswcloaded.Visible',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix',type:'char'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV9WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:'',type:'svchar'},{av:'chkavIsdiscussionanswerswcloaded.Visible',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix',type:'char'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV9WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:'',type:'svchar'},{av:'chkavIsdiscussionanswerswcloaded.Visible',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix',type:'char'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpdiscussionmessageid',iparms:[]");
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
         wcpOAV8WWPEntityName = "";
         wcpOAV9WWPDiscussionMessageEntityRecordId = "";
         wcpOAV10WWPSubscriptionEntityRecordDescription = "";
         wcpOAV11WWPNotificationLink = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV21Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         lblDiscussionstitle_Jsonclick = "";
         lblNewthread_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV17Message = "";
         lblEnter_Jsonclick = "";
         ucUcmentions = new GXUserControl();
         A545WWPDiscussionMessageEntityReco = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19UserExtendedPhoto = "";
         AV22Userextendedphoto_GXI = "";
         A2WWPUserExtendedFullName = "";
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A544WWPDiscussionMessageMessage = "";
         OldWcdiscussionsonethreadwc = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         OldDiscussionsonethreadcollapsedwc = "";
         GXDecQS = "";
         WebComp_Discussionsonethreadcollapsedwc_Component = "";
         H000N2_A1WWPUserExtendedId = new string[] {""} ;
         H000N2_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         H000N2_A540WWPDiscussionMessageId = new long[1] ;
         H000N2_A544WWPDiscussionMessageMessage = new string[] {""} ;
         H000N2_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         H000N2_A2WWPUserExtendedFullName = new string[] {""} ;
         A1WWPUserExtendedId = "";
         H000N3_AGRID_nRecordCount = new long[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV20Session = context.GetSession();
         AV15GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12HTTPRequest = new GxHttpRequest( context);
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8WWPEntityName = "";
         sCtrlAV9WWPDiscussionMessageEntityRecordId = "";
         sCtrlAV10WWPSubscriptionEntityRecordDescription = "";
         sCtrlAV11WWPNotificationLink = "";
         subGrid_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         WebComp_Wcdiscussionsonethreadwc_Component = "";
         GXCCtl = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionswc__default(),
            new Object[][] {
                new Object[] {
               H000N2_A1WWPUserExtendedId, H000N2_A545WWPDiscussionMessageEntityReco, H000N2_A540WWPDiscussionMessageId, H000N2_A544WWPDiscussionMessageMessage, H000N2_A543WWPDiscussionMessageDate, H000N2_A2WWPUserExtendedFullName
               }
               , new Object[] {
               H000N3_AGRID_nRecordCount
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcdiscussionsonethreadwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Discussionsonethreadcollapsedwc = new GeneXus.Http.GXNullWebComponent();
         AV21Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
         /* GeneXus formulas. */
         AV21Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtWWPDiscussionMessageId_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_16 ;
      private int nGXsfl_16_idx=1 ;
      private int edtavMessage_Enabled ;
      private int edtWWPDiscussionMessageEntityReco_Visible ;
      private int nGXsfl_16_webc_idx=0 ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMessageMessage_Enabled ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int edtWWPDiscussionMessageEntityReco_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A540WWPDiscussionMessageId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_16_idx="0001" ;
      private string chkavIsdiscussionanswerswcloaded_Internalname ;
      private string edtWWPDiscussionMessageId_Internalname ;
      private string AV21Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ucmentions_Datalistproc ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblDiscussionstitle_Internalname ;
      private string lblDiscussionstitle_Jsonclick ;
      private string lblNewthread_Internalname ;
      private string lblNewthread_Jsonclick ;
      private string divGridcell_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divNewthreadcell_Internalname ;
      private string divTablenewthread_Internalname ;
      private string edtavMessage_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string lblEnter_Internalname ;
      private string lblEnter_Jsonclick ;
      private string Ucmentions_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtWWPDiscussionMessageEntityReco_Internalname ;
      private string edtWWPDiscussionMessageEntityReco_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavUserextendedphoto_Internalname ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageMessage_Internalname ;
      private string OldWcdiscussionsonethreadwc ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string OldDiscussionsonethreadcollapsedwc ;
      private string GXDecQS ;
      private string WebComp_Discussionsonethreadcollapsedwc_Component ;
      private string A1WWPUserExtendedId ;
      private string sCtrlAV8WWPEntityName ;
      private string sCtrlAV9WWPDiscussionMessageEntityRecordId ;
      private string sCtrlAV10WWPSubscriptionEntityRecordDescription ;
      private string sCtrlAV11WWPNotificationLink ;
      private string sGXsfl_16_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divDiscussioncardcell_Internalname ;
      private string divDiscussioncard_Internalname ;
      private string divTablecard_Internalname ;
      private string edtavUserextendedphoto_gximage ;
      private string sImgUrl ;
      private string divTabletitle_Internalname ;
      private string tblTablemergedwwpuserextendedfullname_Internalname ;
      private string ROClassString ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private string divWcdiscussionsonethreadcell_Internalname ;
      private string WebComp_Wcdiscussionsonethreadwc_Component ;
      private string divDiscussionsonethreadcollapsedwccell_Internalname ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string GXCCtl ;
      private string edtWWPDiscussionMessageId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A543WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_16_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV18IsDiscussionAnswersWCLoaded ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Discussionsonethreadcollapsedwc ;
      private bool AV19UserExtendedPhoto_IsBlob ;
      private string AV8WWPEntityName ;
      private string AV9WWPDiscussionMessageEntityRecordId ;
      private string AV10WWPSubscriptionEntityRecordDescription ;
      private string AV11WWPNotificationLink ;
      private string wcpOAV8WWPEntityName ;
      private string wcpOAV9WWPDiscussionMessageEntityRecordId ;
      private string wcpOAV10WWPSubscriptionEntityRecordDescription ;
      private string wcpOAV11WWPNotificationLink ;
      private string AV17Message ;
      private string A545WWPDiscussionMessageEntityReco ;
      private string AV22Userextendedphoto_GXI ;
      private string A2WWPUserExtendedFullName ;
      private string A544WWPDiscussionMessageMessage ;
      private string AV19UserExtendedPhoto ;
      private IGxSession AV20Session ;
      private GXWebComponent WebComp_Wcdiscussionsonethreadwc ;
      private GXWebComponent WebComp_Discussionsonethreadcollapsedwc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucUcmentions ;
      private GXWebForm Form ;
      private GxHttpRequest AV12HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIsdiscussionanswerswcloaded ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private string[] H000N2_A1WWPUserExtendedId ;
      private string[] H000N2_A545WWPDiscussionMessageEntityReco ;
      private long[] H000N2_A540WWPDiscussionMessageId ;
      private string[] H000N2_A544WWPDiscussionMessageMessage ;
      private DateTime[] H000N2_A543WWPDiscussionMessageDate ;
      private string[] H000N2_A2WWPUserExtendedFullName ;
      private long[] H000N3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV15GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_discussionswc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000N2;
          prmH000N2 = new Object[] {
          new ParDef("@AV9WWPDiscussionMessageEntityRecordId",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000N3;
          prmH000N3 = new Object[] {
          new ParDef("@AV9WWPDiscussionMessageEntityRecordId",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000N2", "SELECT T1.[WWPUserExtendedId], T1.[WWPDiscussionMessageEntityReco], T1.[WWPDiscussionMessageId], T1.[WWPDiscussionMessageMessage], T1.[WWPDiscussionMessageDate], T2.[WWPUserExtendedFullName] FROM ([WWP_DiscussionMessage] T1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = T1.[WWPUserExtendedId]) WHERE T1.[WWPDiscussionMessageEntityReco] = @AV9WWPDiscussionMessageEntityRecordId ORDER BY T1.[WWPDiscussionMessageId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000N3", "SELECT COUNT(*) FROM ([WWP_DiscussionMessage] T1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = T1.[WWPUserExtendedId]) WHERE T1.[WWPDiscussionMessageEntityReco] = @AV9WWPDiscussionMessageEntityRecordId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000N3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

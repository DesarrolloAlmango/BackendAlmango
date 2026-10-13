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
   public class adicional1wc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public adicional1wc( )
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

      public adicional1wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId )
      {
         this.AV23MudanzaId = aP0_MudanzaId;
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
         cmbavSdtcarga__cantidad = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "MudanzaId");
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
                  AV23MudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "MudanzaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV23MudanzaId", StringUtil.LTrimStr( (decimal)(AV23MudanzaId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV23MudanzaId});
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
                  gxfirstwebparm = GetFirstPar( "MudanzaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MudanzaId");
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
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
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
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
            PAGQ2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdtcarga__nombre_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtcarga__nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtcarga__nombre_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               WSGQ2( ) ;
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
            context.SendWebValue( context.GetMessage( "Adicional", "")) ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "adicional1wc.aspx"+UrlEncode(StringUtil.LTrimStr(AV23MudanzaId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("adicional1wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdtcarga", AV13SDTCarga);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdtcarga", AV13SDTCarga);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV23MudanzaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV23MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTCARGA", AV13SDTCarga);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTCARGA", AV13SDTCarga);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCANTIDADPEONES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26CantidadPeones), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseFormGQ2( )
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
         return "Adicional1WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Adicional", "") ;
      }

      protected void WBGQ0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "adicional1wc.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "top-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV27GXV1 = nGXsfl_9_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
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
                  AV27GXV1 = nGXsfl_9_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTGQ2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Adicional", ""), 0) ;
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
               STRUPGQ0( ) ;
            }
         }
      }

      protected void WSGQ2( )
      {
         STARTGQ2( ) ;
         EVTGQ2( ) ;
      }

      protected void EVTGQ2( )
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
                                 STRUPGQ0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGQ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdtcarga__nombre_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'DOSUBTRACT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOADD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "SDTCARGA__CANTIDAD.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'DOSUBTRACT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "SDTCARGA__CANTIDAD.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOADD'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGQ0( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV27GXV1 = nGXsfl_9_idx;
                              if ( ( AV13SDTCarga.Count >= AV27GXV1 ) && ( AV27GXV1 > 0 ) )
                              {
                                 AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1));
                              }
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
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E11GQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Freestylegrid1.Load */
                                          E12GQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOSUBTRACT'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoSubtract' */
                                          E13GQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOADD'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoAdd' */
                                          E14GQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SDTCARGA__CANTIDAD.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Sdtcarga__cantidad.Click */
                                          E15GQ2 ();
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
                                       STRUPGQ0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
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

      protected void WEGQ2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormGQ2( ) ;
            }
         }
      }

      protected void PAGQ2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "adicional1wc.aspx")), "adicional1wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "adicional1wc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MudanzaId");
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
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_9_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RFGQ2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFreestylegrid1_refresh */
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
         RFGQ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdtcarga__nombre_Enabled = 0;
      }

      protected void RFGQ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 9;
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_92( ) ;
            /* Execute user event: Freestylegrid1.Load */
            E12GQ2 ();
            wbEnd = 9;
            WBGQ0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGQ2( )
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

      protected void before_start_formulas( )
      {
         edtavSdtcarga__nombre_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPGQ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11GQ2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdtcarga"), AV13SDTCarga);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDTCARGA"), AV13SDTCarga);
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV23MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV23MudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_9_fel_idx = 0;
            while ( nGXsfl_9_fel_idx < nRC_GXsfl_9 )
            {
               nGXsfl_9_fel_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_9_fel_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_fel_idx+1);
               sGXsfl_9_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_92( ) ;
               AV27GXV1 = nGXsfl_9_fel_idx;
               if ( ( AV13SDTCarga.Count >= AV27GXV1 ) && ( AV27GXV1 > 0 ) )
               {
                  AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1));
               }
            }
            if ( nGXsfl_9_fel_idx == 0 )
            {
               nGXsfl_9_idx = 1;
               sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
               SubsflControlProps_92( ) ;
            }
            nGXsfl_9_fel_idx = 1;
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11GQ2 ();
         if (returnInSub) return;
      }

      protected void E11GQ2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV24Mudanza.Load(AV23MudanzaId);
         if ( AV24Mudanza.Success() )
         {
            AV13SDTCarga.Clear();
            gx_BV9 = true;
            /* Using cursor H00GQ2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A731ParametroMudanzaTipo = H00GQ2_A731ParametroMudanzaTipo[0];
               A730ParametroMudanzaId = H00GQ2_A730ParametroMudanzaId[0];
               A732ParametroMudanzaNombre = H00GQ2_A732ParametroMudanzaNombre[0];
               A733ParametroMudanzaValor = H00GQ2_A733ParametroMudanzaValor[0];
               AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
               AV16SDTCargaItem.gxTpr_Id = A730ParametroMudanzaId;
               AV16SDTCargaItem.gxTpr_Nombre = A732ParametroMudanzaNombre;
               AV32GXV5 = 1;
               while ( AV32GXV5 <= AV24Mudanza.gxTpr_Adicional.Count )
               {
                  AV25MudanzaAdicionalItem = ((SdtMudanza_Adicional)AV24Mudanza.gxTpr_Adicional.Item(AV32GXV5));
                  if ( AV25MudanzaAdicionalItem.gxTpr_Itemadicionalid == A730ParametroMudanzaId )
                  {
                     AV16SDTCargaItem.gxTpr_Cantidad = AV25MudanzaAdicionalItem.gxTpr_Itemadicionalcantidad;
                     if (true) break;
                  }
                  AV32GXV5 = (int)(AV32GXV5+1);
               }
               AV16SDTCargaItem.gxTpr_Valor = A733ParametroMudanzaValor;
               AV16SDTCargaItem.gxTpr_Unidad = "$";
               AV13SDTCarga.Add(AV16SDTCargaItem, 0);
               gx_BV9 = true;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV22WebSession.Set(context.GetMessage( "SDTCargaJson", ""), AV21SDTCargaJson);
         }
         else
         {
            AV13SDTCarga.Clear();
            gx_BV9 = true;
            /* Using cursor H00GQ3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A731ParametroMudanzaTipo = H00GQ3_A731ParametroMudanzaTipo[0];
               A730ParametroMudanzaId = H00GQ3_A730ParametroMudanzaId[0];
               A732ParametroMudanzaNombre = H00GQ3_A732ParametroMudanzaNombre[0];
               A733ParametroMudanzaValor = H00GQ3_A733ParametroMudanzaValor[0];
               AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
               AV16SDTCargaItem.gxTpr_Id = A730ParametroMudanzaId;
               AV16SDTCargaItem.gxTpr_Nombre = A732ParametroMudanzaNombre;
               AV16SDTCargaItem.gxTpr_Valor = A733ParametroMudanzaValor;
               AV16SDTCargaItem.gxTpr_Unidad = "$";
               AV13SDTCarga.Add(AV16SDTCargaItem, 0);
               gx_BV9 = true;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         edtavSdtcarga__valor_Visible = 0;
         AssignProp(sPrefix, false, edtavSdtcarga__valor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtcarga__valor_Visible), 5, 0), !bGXsfl_9_Refreshing);
      }

      private void E12GQ2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV13SDTCarga.Count )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1));
            edtavSdtcarga__nombre_Fontsize = 13;
            cmbavSdtcarga__cantidad.FontSize = 13;
            lblAdd_Fontsize = 20;
            lblSubtract_Fontsize = 20;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 9;
            }
            sendrow_92( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
            {
               context.DoAjaxLoad(9, Freestylegrid1Row);
            }
            AV27GXV1 = (int)(AV27GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E13GQ2( )
      {
         AV27GXV1 = nGXsfl_9_idx;
         if ( ( AV27GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV27GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1));
         }
         /* 'DoSubtract' Routine */
         returnInSub = false;
         AV18ValorAdicionalCalculado = 0;
         if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad != 0 )
         {
            ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = (short)(((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad-1);
         }
         AV20SDTCarga2 = AV13SDTCarga;
         AV34GXV6 = 1;
         while ( AV34GXV6 <= AV20SDTCarga2.Count )
         {
            AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV34GXV6));
            if ( StringUtil.StrCmp(AV19SDTCargaItem2.gxTpr_Nombre, context.GetMessage( "Peones adicionales", "")) == 0 )
            {
               AV26CantidadPeones = AV19SDTCargaItem2.gxTpr_Cantidad;
               AssignAttri(sPrefix, false, "AV26CantidadPeones", StringUtil.LTrimStr( (decimal)(AV26CantidadPeones), 4, 0));
            }
            else
            {
               AV18ValorAdicionalCalculado = (int)(AV18ValorAdicionalCalculado+((AV19SDTCargaItem2.gxTpr_Cantidad*AV19SDTCargaItem2.gxTpr_Valor)));
            }
            AV34GXV6 = (int)(AV34GXV6+1);
         }
         AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
         AV22WebSession.Set(context.GetMessage( "SDTCargaJson", ""), AV21SDTCargaJson);
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ValorCalculadoAdicionales", new Object[] {(int)AV18ValorAdicionalCalculado,(short)AV26CantidadPeones}, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_9_bak_idx = nGXsfl_9_idx;
         gxgrFreestylegrid1_refresh( sPrefix) ;
         nGXsfl_9_idx = nGXsfl_9_bak_idx;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
      }

      protected void E14GQ2( )
      {
         AV27GXV1 = nGXsfl_9_idx;
         if ( ( AV27GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV27GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1));
         }
         /* 'DoAdd' Routine */
         returnInSub = false;
         AV18ValorAdicionalCalculado = 0;
         ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = (short)(((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad+1);
         AV20SDTCarga2 = AV13SDTCarga;
         AV35GXV7 = 1;
         while ( AV35GXV7 <= AV20SDTCarga2.Count )
         {
            AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV35GXV7));
            if ( StringUtil.StrCmp(AV19SDTCargaItem2.gxTpr_Nombre, context.GetMessage( "Peones adicionales", "")) == 0 )
            {
               AV26CantidadPeones = AV19SDTCargaItem2.gxTpr_Cantidad;
               AssignAttri(sPrefix, false, "AV26CantidadPeones", StringUtil.LTrimStr( (decimal)(AV26CantidadPeones), 4, 0));
            }
            else
            {
               AV18ValorAdicionalCalculado = (int)(AV18ValorAdicionalCalculado+((AV19SDTCargaItem2.gxTpr_Cantidad*AV19SDTCargaItem2.gxTpr_Valor)));
            }
            AV35GXV7 = (int)(AV35GXV7+1);
         }
         AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
         AV22WebSession.Set(context.GetMessage( "SDTCargaJson", ""), AV21SDTCargaJson);
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ValorCalculadoAdicionales", new Object[] {(int)AV18ValorAdicionalCalculado,(short)AV26CantidadPeones}, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_9_bak_idx = nGXsfl_9_idx;
         gxgrFreestylegrid1_refresh( sPrefix) ;
         nGXsfl_9_idx = nGXsfl_9_bak_idx;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
      }

      protected void E15GQ2( )
      {
         AV27GXV1 = nGXsfl_9_idx;
         if ( ( AV27GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV27GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1));
         }
         /* Sdtcarga__cantidad_Click Routine */
         returnInSub = false;
         AV18ValorAdicionalCalculado = 0;
         AV20SDTCarga2 = AV13SDTCarga;
         AV36GXV8 = 1;
         while ( AV36GXV8 <= AV20SDTCarga2.Count )
         {
            AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV36GXV8));
            if ( StringUtil.StrCmp(AV19SDTCargaItem2.gxTpr_Nombre, context.GetMessage( "Peones adicionales", "")) == 0 )
            {
               AV26CantidadPeones = AV19SDTCargaItem2.gxTpr_Cantidad;
               AssignAttri(sPrefix, false, "AV26CantidadPeones", StringUtil.LTrimStr( (decimal)(AV26CantidadPeones), 4, 0));
            }
            else
            {
               AV18ValorAdicionalCalculado = (int)((AV19SDTCargaItem2.gxTpr_Cantidad*AV19SDTCargaItem2.gxTpr_Valor));
            }
            AV36GXV8 = (int)(AV36GXV8+1);
         }
         AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
         AV22WebSession.Set(context.GetMessage( "SDTCargaJson", ""), AV21SDTCargaJson);
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ValorCalculadoAdicionales", new Object[] {(int)AV18ValorAdicionalCalculado,(short)AV26CantidadPeones}, true);
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV23MudanzaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV23MudanzaId", StringUtil.LTrimStr( (decimal)(AV23MudanzaId), 18, 0));
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
         PAGQ2( ) ;
         WSGQ2( ) ;
         WEGQ2( ) ;
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
         sCtrlAV23MudanzaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAGQ2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "adicional1wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAGQ2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV23MudanzaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV23MudanzaId", StringUtil.LTrimStr( (decimal)(AV23MudanzaId), 18, 0));
         }
         wcpOAV23MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV23MudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV23MudanzaId != wcpOAV23MudanzaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV23MudanzaId = AV23MudanzaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV23MudanzaId = cgiGet( sPrefix+"AV23MudanzaId_CTRL");
         if ( StringUtil.Len( sCtrlAV23MudanzaId) > 0 )
         {
            AV23MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV23MudanzaId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV23MudanzaId", StringUtil.LTrimStr( (decimal)(AV23MudanzaId), 18, 0));
         }
         else
         {
            AV23MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV23MudanzaId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PAGQ2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSGQ2( ) ;
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
         WSGQ2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV23MudanzaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV23MudanzaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV23MudanzaId_CTRL", StringUtil.RTrim( sCtrlAV23MudanzaId));
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
         WEGQ2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269212235851", true, true, false);
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
         context.AddJavascriptSource("adicional1wc.js", "?20269212235852", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         edtavSdtcarga__nombre_Internalname = sPrefix+"SDTCARGA__NOMBRE_"+sGXsfl_9_idx;
         lblSubtract_Internalname = sPrefix+"SUBTRACT_"+sGXsfl_9_idx;
         cmbavSdtcarga__cantidad_Internalname = sPrefix+"SDTCARGA__CANTIDAD_"+sGXsfl_9_idx;
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1_"+sGXsfl_9_idx;
         lblAdd_Internalname = sPrefix+"ADD_"+sGXsfl_9_idx;
         edtavSdtcarga__valor_Internalname = sPrefix+"SDTCARGA__VALOR_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtavSdtcarga__nombre_Internalname = sPrefix+"SDTCARGA__NOMBRE_"+sGXsfl_9_fel_idx;
         lblSubtract_Internalname = sPrefix+"SUBTRACT_"+sGXsfl_9_fel_idx;
         cmbavSdtcarga__cantidad_Internalname = sPrefix+"SDTCARGA__CANTIDAD_"+sGXsfl_9_fel_idx;
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1_"+sGXsfl_9_fel_idx;
         lblAdd_Internalname = sPrefix+"ADD_"+sGXsfl_9_fel_idx;
         edtavSdtcarga__valor_Internalname = sPrefix+"SDTCARGA__VALOR_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WBGQ0( ) ;
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
            if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divAdicionales_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-6",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__nombre_Internalname,context.GetMessage( "Parametro Mudanza Nombre", ""),(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__nombre_Internalname,((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Nombre,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtcarga__nombre_Jsonclick,(short)0,(string)"Attribute","font-size:"+StringUtil.Str( (decimal)(edtavSdtcarga__nombre_Fontsize), 3, 0)+"pt;",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtcarga__nombre_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-6",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtable1_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblSubtract_Internalname,context.GetMessage( "<i class=\"AttributeColorInfo fas fa-square-minus\"></i>", ""),(string)"",(string)"",(string)lblSubtract_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSUBTRACT\\'."+sGXsfl_9_idx+"'","font-size:"+StringUtil.Str( (decimal)(lblSubtract_Fontsize), 3, 0)+"pt;",(string)"TextBlock",(short)5,(string)"",(short)1,(short)1,(short)0,(short)1});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavSdtcarga__cantidad_Internalname,context.GetMessage( "Cantidad", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
         if ( ( cmbavSdtcarga__cantidad.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "SDTCARGA__CANTIDAD_" + sGXsfl_9_idx;
            cmbavSdtcarga__cantidad.Name = GXCCtl;
            cmbavSdtcarga__cantidad.WebTags = "";
            cmbavSdtcarga__cantidad.addItem("0", "0", 0);
            cmbavSdtcarga__cantidad.addItem("1", "1", 0);
            cmbavSdtcarga__cantidad.addItem("2", "2", 0);
            cmbavSdtcarga__cantidad.addItem("3", "3", 0);
            cmbavSdtcarga__cantidad.addItem("4", "4", 0);
            cmbavSdtcarga__cantidad.addItem("5", "5", 0);
            cmbavSdtcarga__cantidad.addItem("6", "6", 0);
            cmbavSdtcarga__cantidad.addItem("7", "7", 0);
            cmbavSdtcarga__cantidad.addItem("8", "8", 0);
            cmbavSdtcarga__cantidad.addItem("9", "9", 0);
            cmbavSdtcarga__cantidad.addItem("10", "10", 0);
            cmbavSdtcarga__cantidad.addItem("11", "11", 0);
            cmbavSdtcarga__cantidad.addItem("12", "12", 0);
            cmbavSdtcarga__cantidad.addItem("13", "13", 0);
            cmbavSdtcarga__cantidad.addItem("14", "14", 0);
            cmbavSdtcarga__cantidad.addItem("15", "15", 0);
            cmbavSdtcarga__cantidad.addItem("16", "16", 0);
            cmbavSdtcarga__cantidad.addItem("17", "17", 0);
            cmbavSdtcarga__cantidad.addItem("18", "18", 0);
            cmbavSdtcarga__cantidad.addItem("19", "19", 0);
            cmbavSdtcarga__cantidad.addItem("20", "20", 0);
            cmbavSdtcarga__cantidad.addItem("21", "21", 0);
            cmbavSdtcarga__cantidad.addItem("22", "22", 0);
            cmbavSdtcarga__cantidad.addItem("23", "23", 0);
            cmbavSdtcarga__cantidad.addItem("24", "24", 0);
            cmbavSdtcarga__cantidad.addItem("25", "25", 0);
            cmbavSdtcarga__cantidad.addItem("26", "26", 0);
            cmbavSdtcarga__cantidad.addItem("27", "27", 0);
            cmbavSdtcarga__cantidad.addItem("28", "28", 0);
            cmbavSdtcarga__cantidad.addItem("29", "29", 0);
            cmbavSdtcarga__cantidad.addItem("30", "30", 0);
            cmbavSdtcarga__cantidad.addItem("31", "31", 0);
            cmbavSdtcarga__cantidad.addItem("32", "32", 0);
            cmbavSdtcarga__cantidad.addItem("33", "33", 0);
            cmbavSdtcarga__cantidad.addItem("34", "34", 0);
            cmbavSdtcarga__cantidad.addItem("35", "35", 0);
            cmbavSdtcarga__cantidad.addItem("36", "36", 0);
            cmbavSdtcarga__cantidad.addItem("37", "37", 0);
            cmbavSdtcarga__cantidad.addItem("38", "38", 0);
            cmbavSdtcarga__cantidad.addItem("39", "39", 0);
            cmbavSdtcarga__cantidad.addItem("40", "40", 0);
            cmbavSdtcarga__cantidad.addItem("41", "41", 0);
            cmbavSdtcarga__cantidad.addItem("42", "42", 0);
            cmbavSdtcarga__cantidad.addItem("43", "43", 0);
            cmbavSdtcarga__cantidad.addItem("44", "44", 0);
            cmbavSdtcarga__cantidad.addItem("45", "45", 0);
            cmbavSdtcarga__cantidad.addItem("46", "46", 0);
            cmbavSdtcarga__cantidad.addItem("47", "47", 0);
            cmbavSdtcarga__cantidad.addItem("48", "48", 0);
            cmbavSdtcarga__cantidad.addItem("49", "49", 0);
            cmbavSdtcarga__cantidad.addItem("50", "50", 0);
            cmbavSdtcarga__cantidad.addItem("51", "51", 0);
            cmbavSdtcarga__cantidad.addItem("52", "52", 0);
            cmbavSdtcarga__cantidad.addItem("53", "53", 0);
            cmbavSdtcarga__cantidad.addItem("54", "54", 0);
            cmbavSdtcarga__cantidad.addItem("55", "55", 0);
            cmbavSdtcarga__cantidad.addItem("56", "56", 0);
            cmbavSdtcarga__cantidad.addItem("57", "57", 0);
            cmbavSdtcarga__cantidad.addItem("58", "58", 0);
            cmbavSdtcarga__cantidad.addItem("59", "59", 0);
            cmbavSdtcarga__cantidad.addItem("60", "60", 0);
            cmbavSdtcarga__cantidad.addItem("61", "61", 0);
            cmbavSdtcarga__cantidad.addItem("62", "62", 0);
            cmbavSdtcarga__cantidad.addItem("63", "63", 0);
            cmbavSdtcarga__cantidad.addItem("64", "64", 0);
            cmbavSdtcarga__cantidad.addItem("65", "65", 0);
            cmbavSdtcarga__cantidad.addItem("66", "66", 0);
            cmbavSdtcarga__cantidad.addItem("67", "67", 0);
            cmbavSdtcarga__cantidad.addItem("68", "68", 0);
            cmbavSdtcarga__cantidad.addItem("69", "69", 0);
            cmbavSdtcarga__cantidad.addItem("70", "70", 0);
            if ( cmbavSdtcarga__cantidad.ItemCount > 0 )
            {
               if ( ( AV27GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV27GXV1 ) && (0==((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Cantidad) )
               {
                  ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Cantidad = (short)(Math.Round(NumberUtil.Val( cmbavSdtcarga__cantidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Cantidad), 2, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         /* ComboBox */
         Freestylegrid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdtcarga__cantidad,(string)cmbavSdtcarga__cantidad_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Cantidad), 2, 0)),(short)1,(string)cmbavSdtcarga__cantidad_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ESDTCARGA__CANTIDAD.CLICK."+sGXsfl_9_idx+"'",(string)"int",(string)"",(short)1,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"","font-size:"+StringUtil.Str( (decimal)(cmbavSdtcarga__cantidad.FontSize), 3, 0)+"pt;",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"",(string)"",(bool)true,(short)0});
         cmbavSdtcarga__cantidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Cantidad), 2, 0));
         AssignProp(sPrefix, false, cmbavSdtcarga__cantidad_Internalname, "Values", (string)(cmbavSdtcarga__cantidad.ToJavascriptSource()), !bGXsfl_9_Refreshing);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTextblock1_Internalname,(string)" ",(string)"",(string)"",(string)lblTextblock1_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAdd_Internalname,context.GetMessage( "<i class=\"fas fa-square-plus\"></i>", ""),(string)"",(string)"",(string)lblAdd_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADD\\'."+sGXsfl_9_idx+"'","font-size:"+StringUtil.Str( (decimal)(lblAdd_Fontsize), 3, 0)+"pt;",(string)"TextBlock",(short)5,(string)"",(short)1,(short)1,(short)0,(short)1});
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
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegrid1_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__valor_Internalname,context.GetMessage( "Parametro Mudanza Valor", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__valor_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Valor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Valor, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,33);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtcarga__valor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdtcarga__valor_Visible,(short)1,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
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
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashesGQ2( ) ;
         /* End of Columns property logic. */
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_9_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_9_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDTCARGA__CANTIDAD_" + sGXsfl_9_idx;
         cmbavSdtcarga__cantidad.Name = GXCCtl;
         cmbavSdtcarga__cantidad.WebTags = "";
         cmbavSdtcarga__cantidad.addItem("0", "0", 0);
         cmbavSdtcarga__cantidad.addItem("1", "1", 0);
         cmbavSdtcarga__cantidad.addItem("2", "2", 0);
         cmbavSdtcarga__cantidad.addItem("3", "3", 0);
         cmbavSdtcarga__cantidad.addItem("4", "4", 0);
         cmbavSdtcarga__cantidad.addItem("5", "5", 0);
         cmbavSdtcarga__cantidad.addItem("6", "6", 0);
         cmbavSdtcarga__cantidad.addItem("7", "7", 0);
         cmbavSdtcarga__cantidad.addItem("8", "8", 0);
         cmbavSdtcarga__cantidad.addItem("9", "9", 0);
         cmbavSdtcarga__cantidad.addItem("10", "10", 0);
         cmbavSdtcarga__cantidad.addItem("11", "11", 0);
         cmbavSdtcarga__cantidad.addItem("12", "12", 0);
         cmbavSdtcarga__cantidad.addItem("13", "13", 0);
         cmbavSdtcarga__cantidad.addItem("14", "14", 0);
         cmbavSdtcarga__cantidad.addItem("15", "15", 0);
         cmbavSdtcarga__cantidad.addItem("16", "16", 0);
         cmbavSdtcarga__cantidad.addItem("17", "17", 0);
         cmbavSdtcarga__cantidad.addItem("18", "18", 0);
         cmbavSdtcarga__cantidad.addItem("19", "19", 0);
         cmbavSdtcarga__cantidad.addItem("20", "20", 0);
         cmbavSdtcarga__cantidad.addItem("21", "21", 0);
         cmbavSdtcarga__cantidad.addItem("22", "22", 0);
         cmbavSdtcarga__cantidad.addItem("23", "23", 0);
         cmbavSdtcarga__cantidad.addItem("24", "24", 0);
         cmbavSdtcarga__cantidad.addItem("25", "25", 0);
         cmbavSdtcarga__cantidad.addItem("26", "26", 0);
         cmbavSdtcarga__cantidad.addItem("27", "27", 0);
         cmbavSdtcarga__cantidad.addItem("28", "28", 0);
         cmbavSdtcarga__cantidad.addItem("29", "29", 0);
         cmbavSdtcarga__cantidad.addItem("30", "30", 0);
         cmbavSdtcarga__cantidad.addItem("31", "31", 0);
         cmbavSdtcarga__cantidad.addItem("32", "32", 0);
         cmbavSdtcarga__cantidad.addItem("33", "33", 0);
         cmbavSdtcarga__cantidad.addItem("34", "34", 0);
         cmbavSdtcarga__cantidad.addItem("35", "35", 0);
         cmbavSdtcarga__cantidad.addItem("36", "36", 0);
         cmbavSdtcarga__cantidad.addItem("37", "37", 0);
         cmbavSdtcarga__cantidad.addItem("38", "38", 0);
         cmbavSdtcarga__cantidad.addItem("39", "39", 0);
         cmbavSdtcarga__cantidad.addItem("40", "40", 0);
         cmbavSdtcarga__cantidad.addItem("41", "41", 0);
         cmbavSdtcarga__cantidad.addItem("42", "42", 0);
         cmbavSdtcarga__cantidad.addItem("43", "43", 0);
         cmbavSdtcarga__cantidad.addItem("44", "44", 0);
         cmbavSdtcarga__cantidad.addItem("45", "45", 0);
         cmbavSdtcarga__cantidad.addItem("46", "46", 0);
         cmbavSdtcarga__cantidad.addItem("47", "47", 0);
         cmbavSdtcarga__cantidad.addItem("48", "48", 0);
         cmbavSdtcarga__cantidad.addItem("49", "49", 0);
         cmbavSdtcarga__cantidad.addItem("50", "50", 0);
         cmbavSdtcarga__cantidad.addItem("51", "51", 0);
         cmbavSdtcarga__cantidad.addItem("52", "52", 0);
         cmbavSdtcarga__cantidad.addItem("53", "53", 0);
         cmbavSdtcarga__cantidad.addItem("54", "54", 0);
         cmbavSdtcarga__cantidad.addItem("55", "55", 0);
         cmbavSdtcarga__cantidad.addItem("56", "56", 0);
         cmbavSdtcarga__cantidad.addItem("57", "57", 0);
         cmbavSdtcarga__cantidad.addItem("58", "58", 0);
         cmbavSdtcarga__cantidad.addItem("59", "59", 0);
         cmbavSdtcarga__cantidad.addItem("60", "60", 0);
         cmbavSdtcarga__cantidad.addItem("61", "61", 0);
         cmbavSdtcarga__cantidad.addItem("62", "62", 0);
         cmbavSdtcarga__cantidad.addItem("63", "63", 0);
         cmbavSdtcarga__cantidad.addItem("64", "64", 0);
         cmbavSdtcarga__cantidad.addItem("65", "65", 0);
         cmbavSdtcarga__cantidad.addItem("66", "66", 0);
         cmbavSdtcarga__cantidad.addItem("67", "67", 0);
         cmbavSdtcarga__cantidad.addItem("68", "68", 0);
         cmbavSdtcarga__cantidad.addItem("69", "69", 0);
         cmbavSdtcarga__cantidad.addItem("70", "70", 0);
         if ( cmbavSdtcarga__cantidad.ItemCount > 0 )
         {
            if ( ( AV27GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV27GXV1 ) && (0==((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV27GXV1)).gxTpr_Cantidad) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", sPrefix);
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
            Freestylegrid1Column.AddObjectProperty("Fontsize", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__nombre_Fontsize), 9, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__nombre_Enabled), 5, 0, ".", "")));
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
            Freestylegrid1Column.AddObjectProperty("Value", lblSubtract_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Fontsize", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdtcarga__cantidad.FontSize), 9, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblTextblock1_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblAdd_Caption);
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
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__valor_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
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

      protected void init_default_properties( )
      {
         edtavSdtcarga__nombre_Internalname = sPrefix+"SDTCARGA__NOMBRE";
         lblSubtract_Internalname = sPrefix+"SUBTRACT";
         cmbavSdtcarga__cantidad_Internalname = sPrefix+"SDTCARGA__CANTIDAD";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         lblAdd_Internalname = sPrefix+"ADD";
         tblUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtavSdtcarga__valor_Internalname = sPrefix+"SDTCARGA__VALOR";
         tblUnnamedtablecontentfsfreestylegrid1_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFREESTYLEGRID1";
         divAdicionales_Internalname = sPrefix+"ADICIONALES";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFreestylegrid1_Internalname = sPrefix+"FREESTYLEGRID1";
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
         subFreestylegrid1_Allowcollapsing = 0;
         lblAdd_Caption = context.GetMessage( "<i class=\"fas fa-square-plus\"></i>", "");
         lblTextblock1_Caption = " ";
         lblSubtract_Caption = context.GetMessage( "<i class=\"AttributeColorInfo fas fa-square-minus\"></i>", "");
         edtavSdtcarga__valor_Jsonclick = "";
         edtavSdtcarga__valor_Visible = 1;
         lblAdd_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         cmbavSdtcarga__cantidad_Jsonclick = "";
         cmbavSdtcarga__cantidad.FontSize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         lblSubtract_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         edtavSdtcarga__nombre_Jsonclick = "";
         edtavSdtcarga__nombre_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         edtavSdtcarga__nombre_Enabled = 0;
         subFreestylegrid1_Class = "FreeStyleGrid";
         subFreestylegrid1_Backcolorstyle = 0;
         edtavSdtcarga__nombre_Enabled = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:9,pic:''},{av:'nGXsfl_9_idx',ctrl:'GRID',prop:'GridCurrRow',grid:9},{av:'nRC_GXsfl_9',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:9,type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("FREESTYLEGRID1.LOAD","{handler:'E12GQ2',iparms:[]");
         setEventMetadata("FREESTYLEGRID1.LOAD",",oparms:[{ctrl:'SDTCARGA__NOMBRE',prop:'Fontsize'},{ctrl:'SDTCARGA__CANTIDAD',prop:'Fontsize'},{av:'lblAdd_Fontsize',ctrl:'ADD',prop:'Fontsize'},{av:'lblSubtract_Fontsize',ctrl:'SUBTRACT',prop:'Fontsize'}]}");
         setEventMetadata("'DOSUBTRACT'","{handler:'E13GQ2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:9,pic:''},{av:'nGXsfl_9_idx',ctrl:'GRID',prop:'GridCurrRow',grid:9},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_9',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:9,type:'int'},{av:'AV26CantidadPeones',fld:'vCANTIDADPEONES',pic:'ZZZ9',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("'DOSUBTRACT'",",oparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:9,pic:''},{av:'nGXsfl_9_idx',ctrl:'GRID',prop:'GridCurrRow',grid:9},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_9',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:9,type:'int'},{av:'AV26CantidadPeones',fld:'vCANTIDADPEONES',pic:'ZZZ9',type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("'DOADD'","{handler:'E14GQ2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:9,pic:''},{av:'nGXsfl_9_idx',ctrl:'GRID',prop:'GridCurrRow',grid:9},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_9',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:9,type:'int'},{av:'AV26CantidadPeones',fld:'vCANTIDADPEONES',pic:'ZZZ9',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("'DOADD'",",oparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:9,pic:''},{av:'nGXsfl_9_idx',ctrl:'GRID',prop:'GridCurrRow',grid:9},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_9',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:9,type:'int'},{av:'AV26CantidadPeones',fld:'vCANTIDADPEONES',pic:'ZZZ9',type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("SDTCARGA__CANTIDAD.CLICK","{handler:'E15GQ2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:9,pic:''},{av:'nGXsfl_9_idx',ctrl:'GRID',prop:'GridCurrRow',grid:9},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_9',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:9,type:'int'},{av:'AV26CantidadPeones',fld:'vCANTIDADPEONES',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("SDTCARGA__CANTIDAD.CLICK",",oparms:[{av:'AV26CantidadPeones',fld:'vCANTIDADPEONES',pic:'ZZZ9',type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv4',iparms:[]");
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV13SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         GX_FocusControl = "";
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV24Mudanza = new SdtMudanza(context);
         H00GQ2_A731ParametroMudanzaTipo = new string[] {""} ;
         H00GQ2_A730ParametroMudanzaId = new short[1] ;
         H00GQ2_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GQ2_A733ParametroMudanzaValor = new decimal[1] ;
         A731ParametroMudanzaTipo = "";
         A732ParametroMudanzaNombre = "";
         AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
         AV25MudanzaAdicionalItem = new SdtMudanza_Adicional(context);
         AV22WebSession = context.GetSession();
         AV21SDTCargaJson = "";
         H00GQ3_A731ParametroMudanzaTipo = new string[] {""} ;
         H00GQ3_A730ParametroMudanzaId = new short[1] ;
         H00GQ3_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GQ3_A733ParametroMudanzaValor = new decimal[1] ;
         Freestylegrid1Row = new GXWebRow();
         AV20SDTCarga2 = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         AV19SDTCargaItem2 = new SdtSDTCarga_SDTCargaItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV23MudanzaId = "";
         subFreestylegrid1_Linesclass = "";
         TempTags = "";
         ROClassString = "";
         lblSubtract_Jsonclick = "";
         GXCCtl = "";
         lblTextblock1_Jsonclick = "";
         lblAdd_Jsonclick = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adicional1wc__default(),
            new Object[][] {
                new Object[] {
               H00GQ2_A731ParametroMudanzaTipo, H00GQ2_A730ParametroMudanzaId, H00GQ2_A732ParametroMudanzaNombre, H00GQ2_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00GQ3_A731ParametroMudanzaTipo, H00GQ3_A730ParametroMudanzaId, H00GQ3_A732ParametroMudanzaNombre, H00GQ3_A733ParametroMudanzaValor
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdtcarga__nombre_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV26CantidadPeones ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short A730ParametroMudanzaId ;
      private short FREESTYLEGRID1_nEOF ;
      private short nGXWrapped ;
      private short subFreestylegrid1_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int edtavSdtcarga__nombre_Enabled ;
      private int AV27GXV1 ;
      private int subFreestylegrid1_Islastpage ;
      private int nGXsfl_9_fel_idx=1 ;
      private int AV32GXV5 ;
      private int edtavSdtcarga__valor_Visible ;
      private int edtavSdtcarga__nombre_Fontsize ;
      private int lblAdd_Fontsize ;
      private int lblSubtract_Fontsize ;
      private int AV18ValorAdicionalCalculado ;
      private int AV34GXV6 ;
      private int nGXsfl_9_bak_idx=1 ;
      private int AV35GXV7 ;
      private int AV36GXV8 ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private long AV23MudanzaId ;
      private long wcpOAV23MudanzaId ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private decimal A733ParametroMudanzaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtavSdtcarga__nombre_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string edtavSdtcarga__valor_Internalname ;
      private string sCtrlAV23MudanzaId ;
      private string lblSubtract_Internalname ;
      private string cmbavSdtcarga__cantidad_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblAdd_Internalname ;
      private string subFreestylegrid1_Class ;
      private string subFreestylegrid1_Linesclass ;
      private string divAdicionales_Internalname ;
      private string TempTags ;
      private string ROClassString ;
      private string edtavSdtcarga__nombre_Jsonclick ;
      private string tblUnnamedtable1_Internalname ;
      private string lblSubtract_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdtcarga__cantidad_Jsonclick ;
      private string lblTextblock1_Jsonclick ;
      private string lblAdd_Jsonclick ;
      private string tblUnnamedtablecontentfsfreestylegrid1_Internalname ;
      private string edtavSdtcarga__valor_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private string lblSubtract_Caption ;
      private string lblTextblock1_Caption ;
      private string lblAdd_Caption ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV9 ;
      private string AV21SDTCargaJson ;
      private string A731ParametroMudanzaTipo ;
      private string A732ParametroMudanzaNombre ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebColumn Freestylegrid1Column ;
      private GXWebForm Form ;
      private IGxSession AV22WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSdtcarga__cantidad ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV13SDTCarga ;
      private SdtMudanza AV24Mudanza ;
      private IDataStoreProvider pr_default ;
      private string[] H00GQ2_A731ParametroMudanzaTipo ;
      private short[] H00GQ2_A730ParametroMudanzaId ;
      private string[] H00GQ2_A732ParametroMudanzaNombre ;
      private decimal[] H00GQ2_A733ParametroMudanzaValor ;
      private SdtSDTCarga_SDTCargaItem AV16SDTCargaItem ;
      private SdtMudanza_Adicional AV25MudanzaAdicionalItem ;
      private string[] H00GQ3_A731ParametroMudanzaTipo ;
      private short[] H00GQ3_A730ParametroMudanzaId ;
      private string[] H00GQ3_A732ParametroMudanzaNombre ;
      private decimal[] H00GQ3_A733ParametroMudanzaValor ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV20SDTCarga2 ;
      private SdtSDTCarga_SDTCargaItem AV19SDTCargaItem2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class adicional1wc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00GQ2;
          prmH00GQ2 = new Object[] {
          };
          Object[] prmH00GQ3;
          prmH00GQ3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00GQ2", "SELECT [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'ItemAdicional' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GQ2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00GQ3", "SELECT [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'ItemAdicional' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GQ3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}

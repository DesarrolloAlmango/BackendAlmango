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
   public class gx01q0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01q0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01q0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pMensajesID ,
                           out string aP1_pMensajesDeUser ,
                           out string aP2_pMensajesParaUser ,
                           out string aP3_pMensajesCodRef )
      {
         this.AV11pMensajesID = 0 ;
         this.AV12pMensajesDeUser = "" ;
         this.AV13pMensajesParaUser = "" ;
         this.AV14pMensajesCodRef = "" ;
         ExecutePrivate();
         aP0_pMensajesID=this.AV11pMensajesID;
         aP1_pMensajesDeUser=this.AV12pMensajesDeUser;
         aP2_pMensajesParaUser=this.AV13pMensajesParaUser;
         aP3_pMensajesCodRef=this.AV14pMensajesCodRef;
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
            gxfirstwebparm = GetFirstPar( "pMensajesID");
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
               gxfirstwebparm = GetFirstPar( "pMensajesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pMensajesID");
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
               AV11pMensajesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pMensajesID", StringUtil.LTrimStr( (decimal)(AV11pMensajesID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pMensajesDeUser = GetPar( "pMensajesDeUser");
                  AssignAttri("", false, "AV12pMensajesDeUser", AV12pMensajesDeUser);
                  AV13pMensajesParaUser = GetPar( "pMensajesParaUser");
                  AssignAttri("", false, "AV13pMensajesParaUser", AV13pMensajesParaUser);
                  AV14pMensajesCodRef = GetPar( "pMensajesCodRef");
                  AssignAttri("", false, "AV14pMensajesCodRef", AV14pMensajesCodRef);
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         AV6cMensajesID = (long)(Math.Round(NumberUtil.Val( GetPar( "cMensajesID"), "."), 18, MidpointRounding.ToEven));
         AV7cMensajesDeUser = GetPar( "cMensajesDeUser");
         AV8cMensajesParaUser = GetPar( "cMensajesParaUser");
         AV9cMensajesCodRef = GetPar( "cMensajesCodRef");
         AV10cMensajesFecha = context.localUtil.ParseDTimeParm( GetPar( "cMensajesFecha"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cMensajesID, AV7cMensajesDeUser, AV8cMensajesParaUser, AV9cMensajesCodRef, AV10cMensajesFecha) ;
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
         PAA32( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA32( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01q0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pMensajesID,18,0)),UrlEncode(StringUtil.RTrim(AV12pMensajesDeUser)),UrlEncode(StringUtil.RTrim(AV13pMensajesParaUser)),UrlEncode(StringUtil.RTrim(AV14pMensajesCodRef))}, new string[] {"pMensajesID","pMensajesDeUser","pMensajesParaUser","pMensajesCodRef"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCMENSAJESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMENSAJESDEUSER", StringUtil.RTrim( AV7cMensajesDeUser));
         GxWebStd.gx_hidden_field( context, "GXH_vCMENSAJESPARAUSER", StringUtil.RTrim( AV8cMensajesParaUser));
         GxWebStd.gx_hidden_field( context, "GXH_vCMENSAJESCODREF", StringUtil.RTrim( AV9cMensajesCodRef));
         GxWebStd.gx_hidden_field( context, "GXH_vCMENSAJESFECHA", context.localUtil.TToC( AV10cMensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMENSAJESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pMensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMENSAJESDEUSER", StringUtil.RTrim( AV12pMensajesDeUser));
         GxWebStd.gx_hidden_field( context, "vPMENSAJESPARAUSER", StringUtil.RTrim( AV13pMensajesParaUser));
         GxWebStd.gx_hidden_field( context, "vPMENSAJESCODREF", StringUtil.RTrim( AV14pMensajesCodRef));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MENSAJESIDFILTERCONTAINER_Class", StringUtil.RTrim( divMensajesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MENSAJESDEUSERFILTERCONTAINER_Class", StringUtil.RTrim( divMensajesdeuserfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MENSAJESPARAUSERFILTERCONTAINER_Class", StringUtil.RTrim( divMensajesparauserfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MENSAJESCODREFFILTERCONTAINER_Class", StringUtil.RTrim( divMensajescodreffiltercontainer_Class));
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
            WEA32( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA32( ) ;
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
         return formatLink("gx01q0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pMensajesID,18,0)),UrlEncode(StringUtil.RTrim(AV12pMensajesDeUser)),UrlEncode(StringUtil.RTrim(AV13pMensajesParaUser)),UrlEncode(StringUtil.RTrim(AV14pMensajesCodRef))}, new string[] {"pMensajesID","pMensajesDeUser","pMensajesParaUser","pMensajesCodRef"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01Q0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Mensajes", "") ;
      }

      protected void WBA30( )
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
            GxWebStd.gx_div_start( context, divMensajesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMensajesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmensajesidfilter_Internalname, context.GetMessage( "Mensajes ID", ""), "", "", lblLblmensajesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11a31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmensajesid_Internalname, context.GetMessage( "Mensajes ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmensajesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCmensajesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cMensajesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cMensajesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmensajesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmensajesid_Visible, edtavCmensajesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01Q0.htm");
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
            GxWebStd.gx_div_start( context, divMensajesdeuserfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMensajesdeuserfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmensajesdeuserfilter_Internalname, context.GetMessage( "De", ""), "", "", lblLblmensajesdeuserfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12a31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmensajesdeuser_Internalname, context.GetMessage( "De", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmensajesdeuser_Internalname, StringUtil.RTrim( AV7cMensajesDeUser), StringUtil.RTrim( context.localUtil.Format( AV7cMensajesDeUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmensajesdeuser_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmensajesdeuser_Visible, edtavCmensajesdeuser_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01Q0.htm");
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
            GxWebStd.gx_div_start( context, divMensajesparauserfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMensajesparauserfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmensajesparauserfilter_Internalname, context.GetMessage( "Para", ""), "", "", lblLblmensajesparauserfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13a31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmensajesparauser_Internalname, context.GetMessage( "Para", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmensajesparauser_Internalname, StringUtil.RTrim( AV8cMensajesParaUser), StringUtil.RTrim( context.localUtil.Format( AV8cMensajesParaUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmensajesparauser_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmensajesparauser_Visible, edtavCmensajesparauser_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01Q0.htm");
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
            GxWebStd.gx_div_start( context, divMensajescodreffiltercontainer_Internalname, 1, 0, "px", 0, "px", divMensajescodreffiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmensajescodreffilter_Internalname, context.GetMessage( "Codígo de Referencia", ""), "", "", lblLblmensajescodreffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14a31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmensajescodref_Internalname, context.GetMessage( "Codígo de Referencia", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmensajescodref_Internalname, StringUtil.RTrim( AV9cMensajesCodRef), StringUtil.RTrim( context.localUtil.Format( AV9cMensajesCodRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmensajescodref_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmensajescodref_Visible, edtavCmensajescodref_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01Q0.htm");
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
            GxWebStd.gx_div_start( context, divMensajesfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmensajesfechafilter_Internalname, context.GetMessage( "Fecha", ""), "", "", lblLblmensajesfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmensajesfecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCmensajesfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCmensajesfecha_Internalname, context.localUtil.TToC( AV10cMensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV10cMensajesFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmensajesfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCmensajesfecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01Q0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e15a31_client"+"'", TempTags, "", 2, "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01Q0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void STARTA32( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Mensajes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA30( ) ;
      }

      protected void WSA32( )
      {
         STARTA32( ) ;
         EVTA32( ) ;
      }

      protected void EVTA32( )
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
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A396MensajesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMensajesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A397MensajesDeUser = cgiGet( edtMensajesDeUser_Internalname);
                              A398MensajesParaUser = cgiGet( edtMensajesParaUser_Internalname);
                              A400MensajesCodRef = cgiGet( edtMensajesCodRef_Internalname);
                              A401MensajesFecha = context.localUtil.CToT( cgiGet( edtMensajesFecha_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16A32 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17A32 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmensajesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMENSAJESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMensajesID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmensajesdeuser Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMENSAJESDEUSER"), AV7cMensajesDeUser) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmensajesparauser Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMENSAJESPARAUSER"), AV8cMensajesParaUser) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmensajescodref Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMENSAJESCODREF"), AV9cMensajesCodRef) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmensajesfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCMENSAJESFECHA"), 0) != AV10cMensajesFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18A32 ();
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

      protected void WEA32( )
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

      protected void PAA32( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cMensajesID ,
                                        string AV7cMensajesDeUser ,
                                        string AV8cMensajesParaUser ,
                                        string AV9cMensajesCodRef ,
                                        DateTime AV10cMensajesFecha )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFA32( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A396MensajesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MENSAJESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A396MensajesID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESDEUSER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A397MensajesDeUser, "")), context));
         GxWebStd.gx_hidden_field( context, "MENSAJESDEUSER", StringUtil.RTrim( A397MensajesDeUser));
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESPARAUSER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A398MensajesParaUser, "")), context));
         GxWebStd.gx_hidden_field( context, "MENSAJESPARAUSER", StringUtil.RTrim( A398MensajesParaUser));
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESCODREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A400MensajesCodRef, "")), context));
         GxWebStd.gx_hidden_field( context, "MENSAJESCODREF", StringUtil.RTrim( A400MensajesCodRef));
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
         RFA32( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFA32( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV10cMensajesFecha ,
                                                 A401MensajesFecha ,
                                                 A397MensajesDeUser ,
                                                 AV7cMensajesDeUser ,
                                                 A398MensajesParaUser ,
                                                 AV8cMensajesParaUser ,
                                                 A400MensajesCodRef ,
                                                 AV9cMensajesCodRef ,
                                                 AV6cMensajesID } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG
                                                 }
            });
            lV7cMensajesDeUser = StringUtil.PadR( StringUtil.RTrim( AV7cMensajesDeUser), 30, "%");
            lV8cMensajesParaUser = StringUtil.PadR( StringUtil.RTrim( AV8cMensajesParaUser), 30, "%");
            lV9cMensajesCodRef = StringUtil.PadR( StringUtil.RTrim( AV9cMensajesCodRef), 20, "%");
            /* Using cursor H00A32 */
            pr_default.execute(0, new Object[] {AV6cMensajesID, lV7cMensajesDeUser, lV8cMensajesParaUser, lV9cMensajesCodRef, AV10cMensajesFecha, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A401MensajesFecha = H00A32_A401MensajesFecha[0];
               A400MensajesCodRef = H00A32_A400MensajesCodRef[0];
               A398MensajesParaUser = H00A32_A398MensajesParaUser[0];
               A397MensajesDeUser = H00A32_A397MensajesDeUser[0];
               A396MensajesID = H00A32_A396MensajesID[0];
               /* Execute user event: Load */
               E17A32 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WBA30( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA32( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A396MensajesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESDEUSER"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( A397MensajesDeUser, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESPARAUSER"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( A398MensajesParaUser, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MENSAJESCODREF"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( A400MensajesCodRef, "")), context));
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
                                              AV10cMensajesFecha ,
                                              A401MensajesFecha ,
                                              A397MensajesDeUser ,
                                              AV7cMensajesDeUser ,
                                              A398MensajesParaUser ,
                                              AV8cMensajesParaUser ,
                                              A400MensajesCodRef ,
                                              AV9cMensajesCodRef ,
                                              AV6cMensajesID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV7cMensajesDeUser = StringUtil.PadR( StringUtil.RTrim( AV7cMensajesDeUser), 30, "%");
         lV8cMensajesParaUser = StringUtil.PadR( StringUtil.RTrim( AV8cMensajesParaUser), 30, "%");
         lV9cMensajesCodRef = StringUtil.PadR( StringUtil.RTrim( AV9cMensajesCodRef), 20, "%");
         /* Using cursor H00A33 */
         pr_default.execute(1, new Object[] {AV6cMensajesID, lV7cMensajesDeUser, lV8cMensajesParaUser, lV9cMensajesCodRef, AV10cMensajesFecha});
         GRID1_nRecordCount = H00A33_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMensajesID, AV7cMensajesDeUser, AV8cMensajesParaUser, AV9cMensajesCodRef, AV10cMensajesFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMensajesID, AV7cMensajesDeUser, AV8cMensajesParaUser, AV9cMensajesCodRef, AV10cMensajesFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMensajesID, AV7cMensajesDeUser, AV8cMensajesParaUser, AV9cMensajesCodRef, AV10cMensajesFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMensajesID, AV7cMensajesDeUser, AV8cMensajesParaUser, AV9cMensajesCodRef, AV10cMensajesFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMensajesID, AV7cMensajesDeUser, AV8cMensajesParaUser, AV9cMensajesCodRef, AV10cMensajesFecha) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtMensajesID_Enabled = 0;
         edtMensajesDeUser_Enabled = 0;
         edtMensajesParaUser_Enabled = 0;
         edtMensajesCodRef_Enabled = 0;
         edtMensajesFecha_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA30( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16A32 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmensajesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmensajesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMENSAJESID");
               GX_FocusControl = edtavCmensajesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cMensajesID = 0;
               AssignAttri("", false, "AV6cMensajesID", StringUtil.LTrimStr( (decimal)(AV6cMensajesID), 18, 0));
            }
            else
            {
               AV6cMensajesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmensajesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cMensajesID", StringUtil.LTrimStr( (decimal)(AV6cMensajesID), 18, 0));
            }
            AV7cMensajesDeUser = cgiGet( edtavCmensajesdeuser_Internalname);
            AssignAttri("", false, "AV7cMensajesDeUser", AV7cMensajesDeUser);
            AV8cMensajesParaUser = cgiGet( edtavCmensajesparauser_Internalname);
            AssignAttri("", false, "AV8cMensajesParaUser", AV8cMensajesParaUser);
            AV9cMensajesCodRef = cgiGet( edtavCmensajescodref_Internalname);
            AssignAttri("", false, "AV9cMensajesCodRef", AV9cMensajesCodRef);
            if ( context.localUtil.VCDateTime( cgiGet( edtavCmensajesfecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "vCMENSAJESFECHA");
               GX_FocusControl = edtavCmensajesfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cMensajesFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10cMensajesFecha", context.localUtil.TToC( AV10cMensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV10cMensajesFecha = context.localUtil.CToT( cgiGet( edtavCmensajesfecha_Internalname));
               AssignAttri("", false, "AV10cMensajesFecha", context.localUtil.TToC( AV10cMensajesFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMENSAJESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMensajesID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMENSAJESDEUSER"), AV7cMensajesDeUser) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMENSAJESPARAUSER"), AV8cMensajesParaUser) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMENSAJESCODREF"), AV9cMensajesCodRef) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCMENSAJESFECHA")) != AV10cMensajesFecha )
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
         E16A32 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16A32( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Mensajes", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E17A32( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E18A32 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18A32( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pMensajesID = A396MensajesID;
         AssignAttri("", false, "AV11pMensajesID", StringUtil.LTrimStr( (decimal)(AV11pMensajesID), 18, 0));
         AV12pMensajesDeUser = A397MensajesDeUser;
         AssignAttri("", false, "AV12pMensajesDeUser", AV12pMensajesDeUser);
         AV13pMensajesParaUser = A398MensajesParaUser;
         AssignAttri("", false, "AV13pMensajesParaUser", AV13pMensajesParaUser);
         AV14pMensajesCodRef = A400MensajesCodRef;
         AssignAttri("", false, "AV14pMensajesCodRef", AV14pMensajesCodRef);
         context.setWebReturnParms(new Object[] {(long)AV11pMensajesID,(string)AV12pMensajesDeUser,(string)AV13pMensajesParaUser,(string)AV14pMensajesCodRef});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pMensajesID","AV12pMensajesDeUser","AV13pMensajesParaUser","AV14pMensajesCodRef"});
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
         AV11pMensajesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV11pMensajesID", StringUtil.LTrimStr( (decimal)(AV11pMensajesID), 18, 0));
         AV12pMensajesDeUser = (string)getParm(obj,1);
         AssignAttri("", false, "AV12pMensajesDeUser", AV12pMensajesDeUser);
         AV13pMensajesParaUser = (string)getParm(obj,2);
         AssignAttri("", false, "AV13pMensajesParaUser", AV13pMensajesParaUser);
         AV14pMensajesCodRef = (string)getParm(obj,3);
         AssignAttri("", false, "AV14pMensajesCodRef", AV14pMensajesCodRef);
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
         PAA32( ) ;
         WSA32( ) ;
         WEA32( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730212658", true, true, false);
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
         context.AddJavascriptSource("gx01q0.js", "?2026730212658", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtMensajesID_Internalname = "MENSAJESID_"+sGXsfl_64_idx;
         edtMensajesDeUser_Internalname = "MENSAJESDEUSER_"+sGXsfl_64_idx;
         edtMensajesParaUser_Internalname = "MENSAJESPARAUSER_"+sGXsfl_64_idx;
         edtMensajesCodRef_Internalname = "MENSAJESCODREF_"+sGXsfl_64_idx;
         edtMensajesFecha_Internalname = "MENSAJESFECHA_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtMensajesID_Internalname = "MENSAJESID_"+sGXsfl_64_fel_idx;
         edtMensajesDeUser_Internalname = "MENSAJESDEUSER_"+sGXsfl_64_fel_idx;
         edtMensajesParaUser_Internalname = "MENSAJESPARAUSER_"+sGXsfl_64_fel_idx;
         edtMensajesCodRef_Internalname = "MENSAJESCODREF_"+sGXsfl_64_fel_idx;
         edtMensajesFecha_Internalname = "MENSAJESFECHA_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WBA30( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A396MensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A397MensajesDeUser))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A398MensajesParaUser))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A400MensajesCodRef))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMensajesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A396MensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A396MensajesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMensajesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMensajesDeUser_Internalname,StringUtil.RTrim( A397MensajesDeUser),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMensajesDeUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Usuario",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMensajesParaUser_Internalname,StringUtil.RTrim( A398MensajesParaUser),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMensajesParaUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Usuario",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMensajesCodRef_Internalname,StringUtil.RTrim( A400MensajesCodRef),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMensajesCodRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtMensajesFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A396MensajesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A397MensajesDeUser))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A398MensajesParaUser))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A400MensajesCodRef))+"'"+"]);";
            AssignProp("", false, edtMensajesFecha_Internalname, "Link", edtMensajesFecha_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMensajesFecha_Internalname,context.localUtil.TToC( A401MensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A401MensajesFecha, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMensajesFecha_Link,(string)"",(string)"",(string)"",(string)edtMensajesFecha_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA32( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "De", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Para", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Codígo de Referencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A396MensajesID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A397MensajesDeUser)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A398MensajesParaUser)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A400MensajesCodRef)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A401MensajesFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtMensajesFecha_Link));
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
         lblLblmensajesidfilter_Internalname = "LBLMENSAJESIDFILTER";
         edtavCmensajesid_Internalname = "vCMENSAJESID";
         divMensajesidfiltercontainer_Internalname = "MENSAJESIDFILTERCONTAINER";
         lblLblmensajesdeuserfilter_Internalname = "LBLMENSAJESDEUSERFILTER";
         edtavCmensajesdeuser_Internalname = "vCMENSAJESDEUSER";
         divMensajesdeuserfiltercontainer_Internalname = "MENSAJESDEUSERFILTERCONTAINER";
         lblLblmensajesparauserfilter_Internalname = "LBLMENSAJESPARAUSERFILTER";
         edtavCmensajesparauser_Internalname = "vCMENSAJESPARAUSER";
         divMensajesparauserfiltercontainer_Internalname = "MENSAJESPARAUSERFILTERCONTAINER";
         lblLblmensajescodreffilter_Internalname = "LBLMENSAJESCODREFFILTER";
         edtavCmensajescodref_Internalname = "vCMENSAJESCODREF";
         divMensajescodreffiltercontainer_Internalname = "MENSAJESCODREFFILTERCONTAINER";
         lblLblmensajesfechafilter_Internalname = "LBLMENSAJESFECHAFILTER";
         edtavCmensajesfecha_Internalname = "vCMENSAJESFECHA";
         divMensajesfechafiltercontainer_Internalname = "MENSAJESFECHAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtMensajesID_Internalname = "MENSAJESID";
         edtMensajesDeUser_Internalname = "MENSAJESDEUSER";
         edtMensajesParaUser_Internalname = "MENSAJESPARAUSER";
         edtMensajesCodRef_Internalname = "MENSAJESCODREF";
         edtMensajesFecha_Internalname = "MENSAJESFECHA";
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
         edtMensajesFecha_Jsonclick = "";
         edtMensajesFecha_Link = "";
         edtMensajesCodRef_Jsonclick = "";
         edtMensajesParaUser_Jsonclick = "";
         edtMensajesDeUser_Jsonclick = "";
         edtMensajesID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtMensajesFecha_Enabled = 0;
         edtMensajesCodRef_Enabled = 0;
         edtMensajesParaUser_Enabled = 0;
         edtMensajesDeUser_Enabled = 0;
         edtMensajesID_Enabled = 0;
         edtavCmensajesfecha_Jsonclick = "";
         edtavCmensajesfecha_Enabled = 1;
         edtavCmensajescodref_Jsonclick = "";
         edtavCmensajescodref_Enabled = 1;
         edtavCmensajescodref_Visible = 1;
         edtavCmensajesparauser_Jsonclick = "";
         edtavCmensajesparauser_Enabled = 1;
         edtavCmensajesparauser_Visible = 1;
         edtavCmensajesdeuser_Jsonclick = "";
         edtavCmensajesdeuser_Enabled = 1;
         edtavCmensajesdeuser_Visible = 1;
         edtavCmensajesid_Jsonclick = "";
         edtavCmensajesid_Enabled = 1;
         edtavCmensajesid_Visible = 1;
         divMensajescodreffiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMensajesparauserfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMensajesdeuserfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMensajesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Mensajes", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMensajesID',fld:'vCMENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMensajesDeUser',fld:'vCMENSAJESDEUSER',pic:'',type:'char'},{av:'AV8cMensajesParaUser',fld:'vCMENSAJESPARAUSER',pic:'',type:'char'},{av:'AV9cMensajesCodRef',fld:'vCMENSAJESCODREF',pic:'',type:'char'},{av:'AV10cMensajesFecha',fld:'vCMENSAJESFECHA',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E15A31',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLMENSAJESIDFILTER.CLICK","{handler:'E11A31',iparms:[{av:'divMensajesidfiltercontainer_Class',ctrl:'MENSAJESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMENSAJESIDFILTER.CLICK",",oparms:[{av:'divMensajesidfiltercontainer_Class',ctrl:'MENSAJESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCmensajesid_Visible',ctrl:'vCMENSAJESID',prop:'Visible'}]}");
         setEventMetadata("LBLMENSAJESDEUSERFILTER.CLICK","{handler:'E12A31',iparms:[{av:'divMensajesdeuserfiltercontainer_Class',ctrl:'MENSAJESDEUSERFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMENSAJESDEUSERFILTER.CLICK",",oparms:[{av:'divMensajesdeuserfiltercontainer_Class',ctrl:'MENSAJESDEUSERFILTERCONTAINER',prop:'Class'},{av:'edtavCmensajesdeuser_Visible',ctrl:'vCMENSAJESDEUSER',prop:'Visible'}]}");
         setEventMetadata("LBLMENSAJESPARAUSERFILTER.CLICK","{handler:'E13A31',iparms:[{av:'divMensajesparauserfiltercontainer_Class',ctrl:'MENSAJESPARAUSERFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMENSAJESPARAUSERFILTER.CLICK",",oparms:[{av:'divMensajesparauserfiltercontainer_Class',ctrl:'MENSAJESPARAUSERFILTERCONTAINER',prop:'Class'},{av:'edtavCmensajesparauser_Visible',ctrl:'vCMENSAJESPARAUSER',prop:'Visible'}]}");
         setEventMetadata("LBLMENSAJESCODREFFILTER.CLICK","{handler:'E14A31',iparms:[{av:'divMensajescodreffiltercontainer_Class',ctrl:'MENSAJESCODREFFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMENSAJESCODREFFILTER.CLICK",",oparms:[{av:'divMensajescodreffiltercontainer_Class',ctrl:'MENSAJESCODREFFILTERCONTAINER',prop:'Class'},{av:'edtavCmensajescodref_Visible',ctrl:'vCMENSAJESCODREF',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E18A32',iparms:[{av:'A396MensajesID',fld:'MENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A397MensajesDeUser',fld:'MENSAJESDEUSER',pic:'',hsh:true,type:'char'},{av:'A398MensajesParaUser',fld:'MENSAJESPARAUSER',pic:'',hsh:true,type:'char'},{av:'A400MensajesCodRef',fld:'MENSAJESCODREF',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pMensajesID',fld:'vPMENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12pMensajesDeUser',fld:'vPMENSAJESDEUSER',pic:'',type:'char'},{av:'AV13pMensajesParaUser',fld:'vPMENSAJESPARAUSER',pic:'',type:'char'},{av:'AV14pMensajesCodRef',fld:'vPMENSAJESCODREF',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMensajesID',fld:'vCMENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMensajesDeUser',fld:'vCMENSAJESDEUSER',pic:'',type:'char'},{av:'AV8cMensajesParaUser',fld:'vCMENSAJESPARAUSER',pic:'',type:'char'},{av:'AV9cMensajesCodRef',fld:'vCMENSAJESCODREF',pic:'',type:'char'},{av:'AV10cMensajesFecha',fld:'vCMENSAJESFECHA',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMensajesID',fld:'vCMENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMensajesDeUser',fld:'vCMENSAJESDEUSER',pic:'',type:'char'},{av:'AV8cMensajesParaUser',fld:'vCMENSAJESPARAUSER',pic:'',type:'char'},{av:'AV9cMensajesCodRef',fld:'vCMENSAJESCODREF',pic:'',type:'char'},{av:'AV10cMensajesFecha',fld:'vCMENSAJESFECHA',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMensajesID',fld:'vCMENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMensajesDeUser',fld:'vCMENSAJESDEUSER',pic:'',type:'char'},{av:'AV8cMensajesParaUser',fld:'vCMENSAJESPARAUSER',pic:'',type:'char'},{av:'AV9cMensajesCodRef',fld:'vCMENSAJESCODREF',pic:'',type:'char'},{av:'AV10cMensajesFecha',fld:'vCMENSAJESFECHA',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMensajesID',fld:'vCMENSAJESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMensajesDeUser',fld:'vCMENSAJESDEUSER',pic:'',type:'char'},{av:'AV8cMensajesParaUser',fld:'vCMENSAJESPARAUSER',pic:'',type:'char'},{av:'AV9cMensajesCodRef',fld:'vCMENSAJESCODREF',pic:'',type:'char'},{av:'AV10cMensajesFecha',fld:'vCMENSAJESFECHA',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CMENSAJESFECHA","{handler:'Validv_Cmensajesfecha',iparms:[]");
         setEventMetadata("VALIDV_CMENSAJESFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Mensajesfecha',iparms:[]");
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
         AV12pMensajesDeUser = "";
         AV13pMensajesParaUser = "";
         AV14pMensajesCodRef = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cMensajesDeUser = "";
         AV8cMensajesParaUser = "";
         AV9cMensajesCodRef = "";
         AV10cMensajesFecha = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmensajesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblmensajesdeuserfilter_Jsonclick = "";
         lblLblmensajesparauserfilter_Jsonclick = "";
         lblLblmensajescodreffilter_Jsonclick = "";
         lblLblmensajesfechafilter_Jsonclick = "";
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
         AV16Linkselection_GXI = "";
         A397MensajesDeUser = "";
         A398MensajesParaUser = "";
         A400MensajesCodRef = "";
         A401MensajesFecha = (DateTime)(DateTime.MinValue);
         lV7cMensajesDeUser = "";
         lV8cMensajesParaUser = "";
         lV9cMensajesCodRef = "";
         H00A32_A401MensajesFecha = new DateTime[] {DateTime.MinValue} ;
         H00A32_A400MensajesCodRef = new string[] {""} ;
         H00A32_A398MensajesParaUser = new string[] {""} ;
         H00A32_A397MensajesDeUser = new string[] {""} ;
         H00A32_A396MensajesID = new long[1] ;
         H00A33_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01q0__default(),
            new Object[][] {
                new Object[] {
               H00A32_A401MensajesFecha, H00A32_A400MensajesCodRef, H00A32_A398MensajesParaUser, H00A32_A397MensajesDeUser, H00A32_A396MensajesID
               }
               , new Object[] {
               H00A33_AGRID1_nRecordCount
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
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCmensajesid_Enabled ;
      private int edtavCmensajesid_Visible ;
      private int edtavCmensajesdeuser_Visible ;
      private int edtavCmensajesdeuser_Enabled ;
      private int edtavCmensajesparauser_Visible ;
      private int edtavCmensajesparauser_Enabled ;
      private int edtavCmensajescodref_Visible ;
      private int edtavCmensajescodref_Enabled ;
      private int edtavCmensajesfecha_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtMensajesID_Enabled ;
      private int edtMensajesDeUser_Enabled ;
      private int edtMensajesParaUser_Enabled ;
      private int edtMensajesCodRef_Enabled ;
      private int edtMensajesFecha_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV11pMensajesID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cMensajesID ;
      private long A396MensajesID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV12pMensajesDeUser ;
      private string AV13pMensajesParaUser ;
      private string AV14pMensajesCodRef ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divMensajesidfiltercontainer_Class ;
      private string divMensajesdeuserfiltercontainer_Class ;
      private string divMensajesparauserfiltercontainer_Class ;
      private string divMensajescodreffiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV7cMensajesDeUser ;
      private string AV8cMensajesParaUser ;
      private string AV9cMensajesCodRef ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divMensajesidfiltercontainer_Internalname ;
      private string lblLblmensajesidfilter_Internalname ;
      private string lblLblmensajesidfilter_Jsonclick ;
      private string edtavCmensajesid_Internalname ;
      private string TempTags ;
      private string edtavCmensajesid_Jsonclick ;
      private string divMensajesdeuserfiltercontainer_Internalname ;
      private string lblLblmensajesdeuserfilter_Internalname ;
      private string lblLblmensajesdeuserfilter_Jsonclick ;
      private string edtavCmensajesdeuser_Internalname ;
      private string edtavCmensajesdeuser_Jsonclick ;
      private string divMensajesparauserfiltercontainer_Internalname ;
      private string lblLblmensajesparauserfilter_Internalname ;
      private string lblLblmensajesparauserfilter_Jsonclick ;
      private string edtavCmensajesparauser_Internalname ;
      private string edtavCmensajesparauser_Jsonclick ;
      private string divMensajescodreffiltercontainer_Internalname ;
      private string lblLblmensajescodreffilter_Internalname ;
      private string lblLblmensajescodreffilter_Jsonclick ;
      private string edtavCmensajescodref_Internalname ;
      private string edtavCmensajescodref_Jsonclick ;
      private string divMensajesfechafiltercontainer_Internalname ;
      private string lblLblmensajesfechafilter_Internalname ;
      private string lblLblmensajesfechafilter_Jsonclick ;
      private string edtavCmensajesfecha_Internalname ;
      private string edtavCmensajesfecha_Jsonclick ;
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
      private string edtMensajesID_Internalname ;
      private string A397MensajesDeUser ;
      private string edtMensajesDeUser_Internalname ;
      private string A398MensajesParaUser ;
      private string edtMensajesParaUser_Internalname ;
      private string A400MensajesCodRef ;
      private string edtMensajesCodRef_Internalname ;
      private string edtMensajesFecha_Internalname ;
      private string lV7cMensajesDeUser ;
      private string lV8cMensajesParaUser ;
      private string lV9cMensajesCodRef ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtMensajesID_Jsonclick ;
      private string edtMensajesDeUser_Jsonclick ;
      private string edtMensajesParaUser_Jsonclick ;
      private string edtMensajesCodRef_Jsonclick ;
      private string edtMensajesFecha_Link ;
      private string edtMensajesFecha_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10cMensajesFecha ;
      private DateTime A401MensajesFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV16Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00A32_A401MensajesFecha ;
      private string[] H00A32_A400MensajesCodRef ;
      private string[] H00A32_A398MensajesParaUser ;
      private string[] H00A32_A397MensajesDeUser ;
      private long[] H00A32_A396MensajesID ;
      private long[] H00A33_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pMensajesID ;
      private string aP1_pMensajesDeUser ;
      private string aP2_pMensajesParaUser ;
      private string aP3_pMensajesCodRef ;
   }

   public class gx01q0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A32( IGxContext context ,
                                             DateTime AV10cMensajesFecha ,
                                             DateTime A401MensajesFecha ,
                                             string A397MensajesDeUser ,
                                             string AV7cMensajesDeUser ,
                                             string A398MensajesParaUser ,
                                             string AV8cMensajesParaUser ,
                                             string A400MensajesCodRef ,
                                             string AV9cMensajesCodRef ,
                                             long AV6cMensajesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MensajesFecha], [MensajesCodRef], [MensajesParaUser], [MensajesDeUser], [MensajesID]";
         sFromString = " FROM [Mensajes]";
         sOrderString = "";
         AddWhere(sWhereString, "([MensajesID] >= @AV6cMensajesID)");
         AddWhere(sWhereString, "([MensajesDeUser] like @lV7cMensajesDeUser)");
         AddWhere(sWhereString, "([MensajesParaUser] like @lV8cMensajesParaUser)");
         AddWhere(sWhereString, "([MensajesCodRef] like @lV9cMensajesCodRef)");
         if ( ! (DateTime.MinValue==AV10cMensajesFecha) )
         {
            AddWhere(sWhereString, "([MensajesFecha] >= @AV10cMensajesFecha)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [MensajesID], [MensajesDeUser], [MensajesParaUser], [MensajesCodRef]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00A33( IGxContext context ,
                                             DateTime AV10cMensajesFecha ,
                                             DateTime A401MensajesFecha ,
                                             string A397MensajesDeUser ,
                                             string AV7cMensajesDeUser ,
                                             string A398MensajesParaUser ,
                                             string AV8cMensajesParaUser ,
                                             string A400MensajesCodRef ,
                                             string AV9cMensajesCodRef ,
                                             long AV6cMensajesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Mensajes]";
         AddWhere(sWhereString, "([MensajesID] >= @AV6cMensajesID)");
         AddWhere(sWhereString, "([MensajesDeUser] like @lV7cMensajesDeUser)");
         AddWhere(sWhereString, "([MensajesParaUser] like @lV8cMensajesParaUser)");
         AddWhere(sWhereString, "([MensajesCodRef] like @lV9cMensajesCodRef)");
         if ( ! (DateTime.MinValue==AV10cMensajesFecha) )
         {
            AddWhere(sWhereString, "([MensajesFecha] >= @AV10cMensajesFecha)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00A32(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] );
               case 1 :
                     return conditional_H00A33(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmH00A32;
          prmH00A32 = new Object[] {
          new ParDef("@AV6cMensajesID",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMensajesDeUser",GXType.NChar,30,0) ,
          new ParDef("@lV8cMensajesParaUser",GXType.NChar,30,0) ,
          new ParDef("@lV9cMensajesCodRef",GXType.NChar,20,0) ,
          new ParDef("@AV10cMensajesFecha",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A33;
          prmH00A33 = new Object[] {
          new ParDef("@AV6cMensajesID",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMensajesDeUser",GXType.NChar,30,0) ,
          new ParDef("@lV8cMensajesParaUser",GXType.NChar,30,0) ,
          new ParDef("@lV9cMensajesCodRef",GXType.NChar,20,0) ,
          new ParDef("@AV10cMensajesFecha",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00A32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A32,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A33", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A33,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx01k0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01k0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01k0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pResumenID )
      {
         this.AV13pResumenID = 0 ;
         ExecutePrivate();
         aP0_pResumenID=this.AV13pResumenID;
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
            gxfirstwebparm = GetFirstPar( "pResumenID");
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
               gxfirstwebparm = GetFirstPar( "pResumenID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pResumenID");
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
               AV13pResumenID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pResumenID", StringUtil.LTrimStr( (decimal)(AV13pResumenID), 18, 0));
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
         AV6cResumenID = (long)(Math.Round(NumberUtil.Val( GetPar( "cResumenID"), "."), 18, MidpointRounding.ToEven));
         AV7cConfigGenID = (short)(Math.Round(NumberUtil.Val( GetPar( "cConfigGenID"), "."), 18, MidpointRounding.ToEven));
         AV8cResumenTotClientes = (long)(Math.Round(NumberUtil.Val( GetPar( "cResumenTotClientes"), "."), 18, MidpointRounding.ToEven));
         AV9cProfeTotProfesionales = (long)(Math.Round(NumberUtil.Val( GetPar( "cProfeTotProfesionales"), "."), 18, MidpointRounding.ToEven));
         AV10cResumenTotTrabRealizados = (long)(Math.Round(NumberUtil.Val( GetPar( "cResumenTotTrabRealizados"), "."), 18, MidpointRounding.ToEven));
         AV11cResumenTotServicios = (long)(Math.Round(NumberUtil.Val( GetPar( "cResumenTotServicios"), "."), 18, MidpointRounding.ToEven));
         AV12cResumenFechMod = context.localUtil.ParseDTimeParm( GetPar( "cResumenFechMod"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod) ;
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
         PA9W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9W2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01k0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pResumenID,18,0))}, new string[] {"pResumenID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCRESUMENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESUMENTOTCLIENTES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cResumenTotClientes), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFETOTPROFESIONALES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cProfeTotProfesionales), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESUMENTOTTRABREALIZADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cResumenTotTrabRealizados), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESUMENTOTSERVICIOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cResumenTotServicios), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESUMENFECHMOD", context.localUtil.TToC( AV12cResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRESUMENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RESUMENIDFILTERCONTAINER_Class", StringUtil.RTrim( divResumenidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENIDFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESUMENTOTCLIENTESFILTERCONTAINER_Class", StringUtil.RTrim( divResumentotclientesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFETOTPROFESIONALESFILTERCONTAINER_Class", StringUtil.RTrim( divProfetotprofesionalesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESUMENTOTTRABREALIZADOSFILTERCONTAINER_Class", StringUtil.RTrim( divResumentottrabrealizadosfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESUMENTOTSERVICIOSFILTERCONTAINER_Class", StringUtil.RTrim( divResumentotserviciosfiltercontainer_Class));
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
            WE9W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9W2( ) ;
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
         return formatLink("gx01k0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pResumenID,18,0))}, new string[] {"pResumenID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01K0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Resumen", "") ;
      }

      protected void WB9W0( )
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
            GxWebStd.gx_div_start( context, divResumenidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResumenidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresumenidfilter_Internalname, context.GetMessage( "Resumen ID", ""), "", "", lblLblresumenidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresumenid_Internalname, context.GetMessage( "Resumen ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresumenid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCresumenid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cResumenID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cResumenID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresumenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresumenid_Visible, edtavCresumenid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggenidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenidfilter_Internalname, context.GetMessage( "Config Gen ID", ""), "", "", lblLblconfiggenidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggenid_Internalname, context.GetMessage( "Config Gen ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCconfiggenid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cConfigGenID), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cConfigGenID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggenid_Visible, edtavCconfiggenid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            GxWebStd.gx_div_start( context, divResumentotclientesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResumentotclientesfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresumentotclientesfilter_Internalname, context.GetMessage( "Total de Clientes", ""), "", "", lblLblresumentotclientesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresumentotclientes_Internalname, context.GetMessage( "Total de Clientes", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresumentotclientes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cResumenTotClientes), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCresumentotclientes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cResumenTotClientes), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cResumenTotClientes), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresumentotclientes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresumentotclientes_Visible, edtavCresumentotclientes_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            GxWebStd.gx_div_start( context, divProfetotprofesionalesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfetotprofesionalesfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofetotprofesionalesfilter_Internalname, context.GetMessage( "Total Profesionales", ""), "", "", lblLblprofetotprofesionalesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofetotprofesionales_Internalname, context.GetMessage( "Total Profesionales", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofetotprofesionales_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cProfeTotProfesionales), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCprofetotprofesionales_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cProfeTotProfesionales), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9cProfeTotProfesionales), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofetotprofesionales_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofetotprofesionales_Visible, edtavCprofetotprofesionales_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            GxWebStd.gx_div_start( context, divResumentottrabrealizadosfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResumentottrabrealizadosfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresumentottrabrealizadosfilter_Internalname, context.GetMessage( "Trabajos Realizados", ""), "", "", lblLblresumentottrabrealizadosfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresumentottrabrealizados_Internalname, context.GetMessage( "Trabajos Realizados", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresumentottrabrealizados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cResumenTotTrabRealizados), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCresumentottrabrealizados_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cResumenTotTrabRealizados), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10cResumenTotTrabRealizados), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresumentottrabrealizados_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresumentottrabrealizados_Visible, edtavCresumentottrabrealizados_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            GxWebStd.gx_div_start( context, divResumentotserviciosfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResumentotserviciosfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresumentotserviciosfilter_Internalname, context.GetMessage( "Total Servicios", ""), "", "", lblLblresumentotserviciosfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresumentotservicios_Internalname, context.GetMessage( "Total Servicios", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresumentotservicios_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cResumenTotServicios), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCresumentotservicios_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cResumenTotServicios), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cResumenTotServicios), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresumentotservicios_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresumentotservicios_Visible, edtavCresumentotservicios_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            GxWebStd.gx_div_start( context, divResumenfechmodfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresumenfechmodfilter_Internalname, context.GetMessage( "Fecha", ""), "", "", lblLblresumenfechmodfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx01K0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresumenfechmod_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCresumenfechmod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCresumenfechmod_Internalname, context.localUtil.TToC( AV12cResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV12cResumenFechMod, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresumenfechmod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCresumenfechmod_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01K0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e179w1_client"+"'", TempTags, "", 2, "HLP_Gx01K0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01K0.htm");
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

      protected void START9W2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Resumen", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9W0( ) ;
      }

      protected void WS9W2( )
      {
         START9W2( ) ;
         EVT9W2( ) ;
      }

      protected void EVT9W2( )
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
                              A371ResumenID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A372ResumenTotClientes = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenTotClientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A373ProfeTotProfesionales = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfeTotProfesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A375ResumenTotTrabRealizados = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenTotTrabRealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A376ResumenTotServicios = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtResumenTotServicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A377ResumenFechMod = context.localUtil.CToT( cgiGet( edtResumenFechMod_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E189W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E199W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cresumenid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cResumenID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONFIGGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cConfigGenID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresumentotclientes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENTOTCLIENTES"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cResumenTotClientes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofetotprofesionales Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROFETOTPROFESIONALES"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cProfeTotProfesionales )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresumentottrabrealizados Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENTOTTRABREALIZADOS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cResumenTotTrabRealizados )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresumentotservicios Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENTOTSERVICIOS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cResumenTotServicios )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresumenfechmod Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCRESUMENFECHMOD"), 0) != AV12cResumenFechMod )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E209W2 ();
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

      protected void WE9W2( )
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

      protected void PA9W2( )
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
                                        long AV6cResumenID ,
                                        short AV7cConfigGenID ,
                                        long AV8cResumenTotClientes ,
                                        long AV9cProfeTotProfesionales ,
                                        long AV10cResumenTotTrabRealizados ,
                                        long AV11cResumenTotServicios ,
                                        DateTime AV12cResumenFechMod )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESUMENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A371ResumenID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RESUMENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A371ResumenID), 18, 0, ".", "")));
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
         RF9W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9W2( )
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
                                                 AV7cConfigGenID ,
                                                 AV8cResumenTotClientes ,
                                                 AV9cProfeTotProfesionales ,
                                                 AV10cResumenTotTrabRealizados ,
                                                 AV11cResumenTotServicios ,
                                                 AV12cResumenFechMod ,
                                                 A349ConfigGenID ,
                                                 A372ResumenTotClientes ,
                                                 A373ProfeTotProfesionales ,
                                                 A375ResumenTotTrabRealizados ,
                                                 A376ResumenTotServicios ,
                                                 A377ResumenFechMod ,
                                                 AV6cResumenID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H009W2 */
            pr_default.execute(0, new Object[] {AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A377ResumenFechMod = H009W2_A377ResumenFechMod[0];
               A376ResumenTotServicios = H009W2_A376ResumenTotServicios[0];
               A375ResumenTotTrabRealizados = H009W2_A375ResumenTotTrabRealizados[0];
               A373ProfeTotProfesionales = H009W2_A373ProfeTotProfesionales[0];
               A372ResumenTotClientes = H009W2_A372ResumenTotClientes[0];
               A349ConfigGenID = H009W2_A349ConfigGenID[0];
               A371ResumenID = H009W2_A371ResumenID[0];
               /* Execute user event: Load */
               E199W2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB9W0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9W2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESUMENID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A371ResumenID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cConfigGenID ,
                                              AV8cResumenTotClientes ,
                                              AV9cProfeTotProfesionales ,
                                              AV10cResumenTotTrabRealizados ,
                                              AV11cResumenTotServicios ,
                                              AV12cResumenFechMod ,
                                              A349ConfigGenID ,
                                              A372ResumenTotClientes ,
                                              A373ProfeTotProfesionales ,
                                              A375ResumenTotTrabRealizados ,
                                              A376ResumenTotServicios ,
                                              A377ResumenFechMod ,
                                              AV6cResumenID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         /* Using cursor H009W3 */
         pr_default.execute(1, new Object[] {AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod});
         GRID1_nRecordCount = H009W3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResumenID, AV7cConfigGenID, AV8cResumenTotClientes, AV9cProfeTotProfesionales, AV10cResumenTotTrabRealizados, AV11cResumenTotServicios, AV12cResumenFechMod) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtResumenID_Enabled = 0;
         edtConfigGenID_Enabled = 0;
         edtResumenTotClientes_Enabled = 0;
         edtProfeTotProfesionales_Enabled = 0;
         edtResumenTotTrabRealizados_Enabled = 0;
         edtResumenTotServicios_Enabled = 0;
         edtResumenFechMod_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E189W2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresumenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresumenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESUMENID");
               GX_FocusControl = edtavCresumenid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cResumenID = 0;
               AssignAttri("", false, "AV6cResumenID", StringUtil.LTrimStr( (decimal)(AV6cResumenID), 18, 0));
            }
            else
            {
               AV6cResumenID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCresumenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cResumenID", StringUtil.LTrimStr( (decimal)(AV6cResumenID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCconfiggenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCconfiggenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCONFIGGENID");
               GX_FocusControl = edtavCconfiggenid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cConfigGenID = 0;
               AssignAttri("", false, "AV7cConfigGenID", StringUtil.LTrimStr( (decimal)(AV7cConfigGenID), 4, 0));
            }
            else
            {
               AV7cConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCconfiggenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cConfigGenID", StringUtil.LTrimStr( (decimal)(AV7cConfigGenID), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresumentotclientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresumentotclientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESUMENTOTCLIENTES");
               GX_FocusControl = edtavCresumentotclientes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cResumenTotClientes = 0;
               AssignAttri("", false, "AV8cResumenTotClientes", StringUtil.LTrimStr( (decimal)(AV8cResumenTotClientes), 18, 0));
            }
            else
            {
               AV8cResumenTotClientes = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCresumentotclientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cResumenTotClientes", StringUtil.LTrimStr( (decimal)(AV8cResumenTotClientes), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprofetotprofesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprofetotprofesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROFETOTPROFESIONALES");
               GX_FocusControl = edtavCprofetotprofesionales_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cProfeTotProfesionales = 0;
               AssignAttri("", false, "AV9cProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(AV9cProfeTotProfesionales), 18, 0));
            }
            else
            {
               AV9cProfeTotProfesionales = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCprofetotprofesionales_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cProfeTotProfesionales", StringUtil.LTrimStr( (decimal)(AV9cProfeTotProfesionales), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresumentottrabrealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresumentottrabrealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESUMENTOTTRABREALIZADOS");
               GX_FocusControl = edtavCresumentottrabrealizados_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cResumenTotTrabRealizados = 0;
               AssignAttri("", false, "AV10cResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(AV10cResumenTotTrabRealizados), 18, 0));
            }
            else
            {
               AV10cResumenTotTrabRealizados = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCresumentottrabrealizados_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cResumenTotTrabRealizados", StringUtil.LTrimStr( (decimal)(AV10cResumenTotTrabRealizados), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresumentotservicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresumentotservicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESUMENTOTSERVICIOS");
               GX_FocusControl = edtavCresumentotservicios_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cResumenTotServicios = 0;
               AssignAttri("", false, "AV11cResumenTotServicios", StringUtil.LTrimStr( (decimal)(AV11cResumenTotServicios), 18, 0));
            }
            else
            {
               AV11cResumenTotServicios = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCresumentotservicios_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cResumenTotServicios", StringUtil.LTrimStr( (decimal)(AV11cResumenTotServicios), 18, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCresumenfechmod_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "vCRESUMENFECHMOD");
               GX_FocusControl = edtavCresumenfechmod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cResumenFechMod = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV12cResumenFechMod", context.localUtil.TToC( AV12cResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV12cResumenFechMod = context.localUtil.CToT( cgiGet( edtavCresumenfechmod_Internalname));
               AssignAttri("", false, "AV12cResumenFechMod", context.localUtil.TToC( AV12cResumenFechMod, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cResumenID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONFIGGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cConfigGenID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENTOTCLIENTES"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cResumenTotClientes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROFETOTPROFESIONALES"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cProfeTotProfesionales )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENTOTTRABREALIZADOS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cResumenTotTrabRealizados )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESUMENTOTSERVICIOS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cResumenTotServicios )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCRESUMENFECHMOD")) != AV12cResumenFechMod )
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
         E189W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E189W2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Resumen", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E199W2( )
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
         E209W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E209W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pResumenID = A371ResumenID;
         AssignAttri("", false, "AV13pResumenID", StringUtil.LTrimStr( (decimal)(AV13pResumenID), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pResumenID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pResumenID"});
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
         AV13pResumenID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pResumenID", StringUtil.LTrimStr( (decimal)(AV13pResumenID), 18, 0));
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
         PA9W2( ) ;
         WS9W2( ) ;
         WE9W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126593", true, true, false);
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
         context.AddJavascriptSource("gx01k0.js", "?20267302126593", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtResumenID_Internalname = "RESUMENID_"+sGXsfl_84_idx;
         edtConfigGenID_Internalname = "CONFIGGENID_"+sGXsfl_84_idx;
         edtResumenTotClientes_Internalname = "RESUMENTOTCLIENTES_"+sGXsfl_84_idx;
         edtProfeTotProfesionales_Internalname = "PROFETOTPROFESIONALES_"+sGXsfl_84_idx;
         edtResumenTotTrabRealizados_Internalname = "RESUMENTOTTRABREALIZADOS_"+sGXsfl_84_idx;
         edtResumenTotServicios_Internalname = "RESUMENTOTSERVICIOS_"+sGXsfl_84_idx;
         edtResumenFechMod_Internalname = "RESUMENFECHMOD_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtResumenID_Internalname = "RESUMENID_"+sGXsfl_84_fel_idx;
         edtConfigGenID_Internalname = "CONFIGGENID_"+sGXsfl_84_fel_idx;
         edtResumenTotClientes_Internalname = "RESUMENTOTCLIENTES_"+sGXsfl_84_fel_idx;
         edtProfeTotProfesionales_Internalname = "PROFETOTPROFESIONALES_"+sGXsfl_84_fel_idx;
         edtResumenTotTrabRealizados_Internalname = "RESUMENTOTTRABREALIZADOS_"+sGXsfl_84_fel_idx;
         edtResumenTotServicios_Internalname = "RESUMENTOTSERVICIOS_"+sGXsfl_84_fel_idx;
         edtResumenFechMod_Internalname = "RESUMENFECHMOD_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB9W0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A371ResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResumenID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A371ResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A371ResumenID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResumenID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtResumenTotClientes_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A371ResumenID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtResumenTotClientes_Internalname, "Link", edtResumenTotClientes_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResumenTotClientes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A372ResumenTotClientes), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A372ResumenTotClientes), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResumenTotClientes_Link,(string)"",(string)"",(string)"",(string)edtResumenTotClientes_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfeTotProfesionales_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A373ProfeTotProfesionales), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A373ProfeTotProfesionales), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfeTotProfesionales_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResumenTotTrabRealizados_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A375ResumenTotTrabRealizados), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A375ResumenTotTrabRealizados), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResumenTotTrabRealizados_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResumenTotServicios_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ResumenTotServicios), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ResumenTotServicios), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResumenTotServicios_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResumenFechMod_Internalname,context.localUtil.TToC( A377ResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A377ResumenFechMod, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResumenFechMod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9W2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Config Gen ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total de Clientes", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total Profesionales", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Trabajos Realizados", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Servicios", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A371ResumenID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A372ResumenTotClientes), 18, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtResumenTotClientes_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A373ProfeTotProfesionales), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A375ResumenTotTrabRealizados), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ResumenTotServicios), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A377ResumenFechMod, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
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
         lblLblresumenidfilter_Internalname = "LBLRESUMENIDFILTER";
         edtavCresumenid_Internalname = "vCRESUMENID";
         divResumenidfiltercontainer_Internalname = "RESUMENIDFILTERCONTAINER";
         lblLblconfiggenidfilter_Internalname = "LBLCONFIGGENIDFILTER";
         edtavCconfiggenid_Internalname = "vCCONFIGGENID";
         divConfiggenidfiltercontainer_Internalname = "CONFIGGENIDFILTERCONTAINER";
         lblLblresumentotclientesfilter_Internalname = "LBLRESUMENTOTCLIENTESFILTER";
         edtavCresumentotclientes_Internalname = "vCRESUMENTOTCLIENTES";
         divResumentotclientesfiltercontainer_Internalname = "RESUMENTOTCLIENTESFILTERCONTAINER";
         lblLblprofetotprofesionalesfilter_Internalname = "LBLPROFETOTPROFESIONALESFILTER";
         edtavCprofetotprofesionales_Internalname = "vCPROFETOTPROFESIONALES";
         divProfetotprofesionalesfiltercontainer_Internalname = "PROFETOTPROFESIONALESFILTERCONTAINER";
         lblLblresumentottrabrealizadosfilter_Internalname = "LBLRESUMENTOTTRABREALIZADOSFILTER";
         edtavCresumentottrabrealizados_Internalname = "vCRESUMENTOTTRABREALIZADOS";
         divResumentottrabrealizadosfiltercontainer_Internalname = "RESUMENTOTTRABREALIZADOSFILTERCONTAINER";
         lblLblresumentotserviciosfilter_Internalname = "LBLRESUMENTOTSERVICIOSFILTER";
         edtavCresumentotservicios_Internalname = "vCRESUMENTOTSERVICIOS";
         divResumentotserviciosfiltercontainer_Internalname = "RESUMENTOTSERVICIOSFILTERCONTAINER";
         lblLblresumenfechmodfilter_Internalname = "LBLRESUMENFECHMODFILTER";
         edtavCresumenfechmod_Internalname = "vCRESUMENFECHMOD";
         divResumenfechmodfiltercontainer_Internalname = "RESUMENFECHMODFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtResumenID_Internalname = "RESUMENID";
         edtConfigGenID_Internalname = "CONFIGGENID";
         edtResumenTotClientes_Internalname = "RESUMENTOTCLIENTES";
         edtProfeTotProfesionales_Internalname = "PROFETOTPROFESIONALES";
         edtResumenTotTrabRealizados_Internalname = "RESUMENTOTTRABREALIZADOS";
         edtResumenTotServicios_Internalname = "RESUMENTOTSERVICIOS";
         edtResumenFechMod_Internalname = "RESUMENFECHMOD";
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
         edtResumenFechMod_Jsonclick = "";
         edtResumenTotServicios_Jsonclick = "";
         edtResumenTotTrabRealizados_Jsonclick = "";
         edtProfeTotProfesionales_Jsonclick = "";
         edtResumenTotClientes_Jsonclick = "";
         edtResumenTotClientes_Link = "";
         edtConfigGenID_Jsonclick = "";
         edtResumenID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtResumenFechMod_Enabled = 0;
         edtResumenTotServicios_Enabled = 0;
         edtResumenTotTrabRealizados_Enabled = 0;
         edtProfeTotProfesionales_Enabled = 0;
         edtResumenTotClientes_Enabled = 0;
         edtConfigGenID_Enabled = 0;
         edtResumenID_Enabled = 0;
         edtavCresumenfechmod_Jsonclick = "";
         edtavCresumenfechmod_Enabled = 1;
         edtavCresumentotservicios_Jsonclick = "";
         edtavCresumentotservicios_Enabled = 1;
         edtavCresumentotservicios_Visible = 1;
         edtavCresumentottrabrealizados_Jsonclick = "";
         edtavCresumentottrabrealizados_Enabled = 1;
         edtavCresumentottrabrealizados_Visible = 1;
         edtavCprofetotprofesionales_Jsonclick = "";
         edtavCprofetotprofesionales_Enabled = 1;
         edtavCprofetotprofesionales_Visible = 1;
         edtavCresumentotclientes_Jsonclick = "";
         edtavCresumentotclientes_Enabled = 1;
         edtavCresumentotclientes_Visible = 1;
         edtavCconfiggenid_Jsonclick = "";
         edtavCconfiggenid_Enabled = 1;
         edtavCconfiggenid_Visible = 1;
         edtavCresumenid_Jsonclick = "";
         edtavCresumenid_Enabled = 1;
         edtavCresumenid_Visible = 1;
         divResumentotserviciosfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResumentottrabrealizadosfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfetotprofesionalesfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResumentotclientesfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggenidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResumenidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Resumen", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResumenID',fld:'vCRESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV8cResumenTotClientes',fld:'vCRESUMENTOTCLIENTES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cProfeTotProfesionales',fld:'vCPROFETOTPROFESIONALES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cResumenTotTrabRealizados',fld:'vCRESUMENTOTTRABREALIZADOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cResumenTotServicios',fld:'vCRESUMENTOTSERVICIOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cResumenFechMod',fld:'vCRESUMENFECHMOD',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E179W1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLRESUMENIDFILTER.CLICK","{handler:'E119W1',iparms:[{av:'divResumenidfiltercontainer_Class',ctrl:'RESUMENIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRESUMENIDFILTER.CLICK",",oparms:[{av:'divResumenidfiltercontainer_Class',ctrl:'RESUMENIDFILTERCONTAINER',prop:'Class'},{av:'edtavCresumenid_Visible',ctrl:'vCRESUMENID',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENIDFILTER.CLICK","{handler:'E129W1',iparms:[{av:'divConfiggenidfiltercontainer_Class',ctrl:'CONFIGGENIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENIDFILTER.CLICK",",oparms:[{av:'divConfiggenidfiltercontainer_Class',ctrl:'CONFIGGENIDFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggenid_Visible',ctrl:'vCCONFIGGENID',prop:'Visible'}]}");
         setEventMetadata("LBLRESUMENTOTCLIENTESFILTER.CLICK","{handler:'E139W1',iparms:[{av:'divResumentotclientesfiltercontainer_Class',ctrl:'RESUMENTOTCLIENTESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRESUMENTOTCLIENTESFILTER.CLICK",",oparms:[{av:'divResumentotclientesfiltercontainer_Class',ctrl:'RESUMENTOTCLIENTESFILTERCONTAINER',prop:'Class'},{av:'edtavCresumentotclientes_Visible',ctrl:'vCRESUMENTOTCLIENTES',prop:'Visible'}]}");
         setEventMetadata("LBLPROFETOTPROFESIONALESFILTER.CLICK","{handler:'E149W1',iparms:[{av:'divProfetotprofesionalesfiltercontainer_Class',ctrl:'PROFETOTPROFESIONALESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFETOTPROFESIONALESFILTER.CLICK",",oparms:[{av:'divProfetotprofesionalesfiltercontainer_Class',ctrl:'PROFETOTPROFESIONALESFILTERCONTAINER',prop:'Class'},{av:'edtavCprofetotprofesionales_Visible',ctrl:'vCPROFETOTPROFESIONALES',prop:'Visible'}]}");
         setEventMetadata("LBLRESUMENTOTTRABREALIZADOSFILTER.CLICK","{handler:'E159W1',iparms:[{av:'divResumentottrabrealizadosfiltercontainer_Class',ctrl:'RESUMENTOTTRABREALIZADOSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRESUMENTOTTRABREALIZADOSFILTER.CLICK",",oparms:[{av:'divResumentottrabrealizadosfiltercontainer_Class',ctrl:'RESUMENTOTTRABREALIZADOSFILTERCONTAINER',prop:'Class'},{av:'edtavCresumentottrabrealizados_Visible',ctrl:'vCRESUMENTOTTRABREALIZADOS',prop:'Visible'}]}");
         setEventMetadata("LBLRESUMENTOTSERVICIOSFILTER.CLICK","{handler:'E169W1',iparms:[{av:'divResumentotserviciosfiltercontainer_Class',ctrl:'RESUMENTOTSERVICIOSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRESUMENTOTSERVICIOSFILTER.CLICK",",oparms:[{av:'divResumentotserviciosfiltercontainer_Class',ctrl:'RESUMENTOTSERVICIOSFILTERCONTAINER',prop:'Class'},{av:'edtavCresumentotservicios_Visible',ctrl:'vCRESUMENTOTSERVICIOS',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E209W2',iparms:[{av:'A371ResumenID',fld:'RESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pResumenID',fld:'vPRESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResumenID',fld:'vCRESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV8cResumenTotClientes',fld:'vCRESUMENTOTCLIENTES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cProfeTotProfesionales',fld:'vCPROFETOTPROFESIONALES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cResumenTotTrabRealizados',fld:'vCRESUMENTOTTRABREALIZADOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cResumenTotServicios',fld:'vCRESUMENTOTSERVICIOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cResumenFechMod',fld:'vCRESUMENFECHMOD',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResumenID',fld:'vCRESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV8cResumenTotClientes',fld:'vCRESUMENTOTCLIENTES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cProfeTotProfesionales',fld:'vCPROFETOTPROFESIONALES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cResumenTotTrabRealizados',fld:'vCRESUMENTOTTRABREALIZADOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cResumenTotServicios',fld:'vCRESUMENTOTSERVICIOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cResumenFechMod',fld:'vCRESUMENFECHMOD',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResumenID',fld:'vCRESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV8cResumenTotClientes',fld:'vCRESUMENTOTCLIENTES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cProfeTotProfesionales',fld:'vCPROFETOTPROFESIONALES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cResumenTotTrabRealizados',fld:'vCRESUMENTOTTRABREALIZADOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cResumenTotServicios',fld:'vCRESUMENTOTSERVICIOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cResumenFechMod',fld:'vCRESUMENFECHMOD',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResumenID',fld:'vCRESUMENID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV8cResumenTotClientes',fld:'vCRESUMENTOTCLIENTES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cProfeTotProfesionales',fld:'vCPROFETOTPROFESIONALES',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cResumenTotTrabRealizados',fld:'vCRESUMENTOTTRABREALIZADOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cResumenTotServicios',fld:'vCRESUMENTOTSERVICIOS',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cResumenFechMod',fld:'vCRESUMENFECHMOD',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CRESUMENFECHMOD","{handler:'Validv_Cresumenfechmod',iparms:[]");
         setEventMetadata("VALIDV_CRESUMENFECHMOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Resumenfechmod',iparms:[]");
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
         AV12cResumenFechMod = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblresumenidfilter_Jsonclick = "";
         TempTags = "";
         lblLblconfiggenidfilter_Jsonclick = "";
         lblLblresumentotclientesfilter_Jsonclick = "";
         lblLblprofetotprofesionalesfilter_Jsonclick = "";
         lblLblresumentottrabrealizadosfilter_Jsonclick = "";
         lblLblresumentotserviciosfilter_Jsonclick = "";
         lblLblresumenfechmodfilter_Jsonclick = "";
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
         A377ResumenFechMod = (DateTime)(DateTime.MinValue);
         H009W2_A377ResumenFechMod = new DateTime[] {DateTime.MinValue} ;
         H009W2_A376ResumenTotServicios = new long[1] ;
         H009W2_A375ResumenTotTrabRealizados = new long[1] ;
         H009W2_A373ProfeTotProfesionales = new long[1] ;
         H009W2_A372ResumenTotClientes = new long[1] ;
         H009W2_A349ConfigGenID = new short[1] ;
         H009W2_A371ResumenID = new long[1] ;
         H009W3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01k0__default(),
            new Object[][] {
                new Object[] {
               H009W2_A377ResumenFechMod, H009W2_A376ResumenTotServicios, H009W2_A375ResumenTotTrabRealizados, H009W2_A373ProfeTotProfesionales, H009W2_A372ResumenTotClientes, H009W2_A349ConfigGenID, H009W2_A371ResumenID
               }
               , new Object[] {
               H009W3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cConfigGenID ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A349ConfigGenID ;
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
      private int edtavCresumenid_Enabled ;
      private int edtavCresumenid_Visible ;
      private int edtavCconfiggenid_Enabled ;
      private int edtavCconfiggenid_Visible ;
      private int edtavCresumentotclientes_Enabled ;
      private int edtavCresumentotclientes_Visible ;
      private int edtavCprofetotprofesionales_Enabled ;
      private int edtavCprofetotprofesionales_Visible ;
      private int edtavCresumentottrabrealizados_Enabled ;
      private int edtavCresumentottrabrealizados_Visible ;
      private int edtavCresumentotservicios_Enabled ;
      private int edtavCresumentotservicios_Visible ;
      private int edtavCresumenfechmod_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtResumenID_Enabled ;
      private int edtConfigGenID_Enabled ;
      private int edtResumenTotClientes_Enabled ;
      private int edtProfeTotProfesionales_Enabled ;
      private int edtResumenTotTrabRealizados_Enabled ;
      private int edtResumenTotServicios_Enabled ;
      private int edtResumenFechMod_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pResumenID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cResumenID ;
      private long AV8cResumenTotClientes ;
      private long AV9cProfeTotProfesionales ;
      private long AV10cResumenTotTrabRealizados ;
      private long AV11cResumenTotServicios ;
      private long A371ResumenID ;
      private long A372ResumenTotClientes ;
      private long A373ProfeTotProfesionales ;
      private long A375ResumenTotTrabRealizados ;
      private long A376ResumenTotServicios ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divResumenidfiltercontainer_Class ;
      private string divConfiggenidfiltercontainer_Class ;
      private string divResumentotclientesfiltercontainer_Class ;
      private string divProfetotprofesionalesfiltercontainer_Class ;
      private string divResumentottrabrealizadosfiltercontainer_Class ;
      private string divResumentotserviciosfiltercontainer_Class ;
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
      private string divResumenidfiltercontainer_Internalname ;
      private string lblLblresumenidfilter_Internalname ;
      private string lblLblresumenidfilter_Jsonclick ;
      private string edtavCresumenid_Internalname ;
      private string TempTags ;
      private string edtavCresumenid_Jsonclick ;
      private string divConfiggenidfiltercontainer_Internalname ;
      private string lblLblconfiggenidfilter_Internalname ;
      private string lblLblconfiggenidfilter_Jsonclick ;
      private string edtavCconfiggenid_Internalname ;
      private string edtavCconfiggenid_Jsonclick ;
      private string divResumentotclientesfiltercontainer_Internalname ;
      private string lblLblresumentotclientesfilter_Internalname ;
      private string lblLblresumentotclientesfilter_Jsonclick ;
      private string edtavCresumentotclientes_Internalname ;
      private string edtavCresumentotclientes_Jsonclick ;
      private string divProfetotprofesionalesfiltercontainer_Internalname ;
      private string lblLblprofetotprofesionalesfilter_Internalname ;
      private string lblLblprofetotprofesionalesfilter_Jsonclick ;
      private string edtavCprofetotprofesionales_Internalname ;
      private string edtavCprofetotprofesionales_Jsonclick ;
      private string divResumentottrabrealizadosfiltercontainer_Internalname ;
      private string lblLblresumentottrabrealizadosfilter_Internalname ;
      private string lblLblresumentottrabrealizadosfilter_Jsonclick ;
      private string edtavCresumentottrabrealizados_Internalname ;
      private string edtavCresumentottrabrealizados_Jsonclick ;
      private string divResumentotserviciosfiltercontainer_Internalname ;
      private string lblLblresumentotserviciosfilter_Internalname ;
      private string lblLblresumentotserviciosfilter_Jsonclick ;
      private string edtavCresumentotservicios_Internalname ;
      private string edtavCresumentotservicios_Jsonclick ;
      private string divResumenfechmodfiltercontainer_Internalname ;
      private string lblLblresumenfechmodfilter_Internalname ;
      private string lblLblresumenfechmodfilter_Jsonclick ;
      private string edtavCresumenfechmod_Internalname ;
      private string edtavCresumenfechmod_Jsonclick ;
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
      private string edtResumenID_Internalname ;
      private string edtConfigGenID_Internalname ;
      private string edtResumenTotClientes_Internalname ;
      private string edtProfeTotProfesionales_Internalname ;
      private string edtResumenTotTrabRealizados_Internalname ;
      private string edtResumenTotServicios_Internalname ;
      private string edtResumenFechMod_Internalname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtResumenID_Jsonclick ;
      private string edtConfigGenID_Jsonclick ;
      private string edtResumenTotClientes_Link ;
      private string edtResumenTotClientes_Jsonclick ;
      private string edtProfeTotProfesionales_Jsonclick ;
      private string edtResumenTotTrabRealizados_Jsonclick ;
      private string edtResumenTotServicios_Jsonclick ;
      private string edtResumenFechMod_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV12cResumenFechMod ;
      private DateTime A377ResumenFechMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H009W2_A377ResumenFechMod ;
      private long[] H009W2_A376ResumenTotServicios ;
      private long[] H009W2_A375ResumenTotTrabRealizados ;
      private long[] H009W2_A373ProfeTotProfesionales ;
      private long[] H009W2_A372ResumenTotClientes ;
      private short[] H009W2_A349ConfigGenID ;
      private long[] H009W2_A371ResumenID ;
      private long[] H009W3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pResumenID ;
   }

   public class gx01k0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009W2( IGxContext context ,
                                             short AV7cConfigGenID ,
                                             long AV8cResumenTotClientes ,
                                             long AV9cProfeTotProfesionales ,
                                             long AV10cResumenTotTrabRealizados ,
                                             long AV11cResumenTotServicios ,
                                             DateTime AV12cResumenFechMod ,
                                             short A349ConfigGenID ,
                                             long A372ResumenTotClientes ,
                                             long A373ProfeTotProfesionales ,
                                             long A375ResumenTotTrabRealizados ,
                                             long A376ResumenTotServicios ,
                                             DateTime A377ResumenFechMod ,
                                             long AV6cResumenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ResumenFechMod], [ResumenTotServicios], [ResumenTotTrabRealizados], [ProfeTotProfesionales], [ResumenTotClientes], [ConfigGenID], [ResumenID]";
         sFromString = " FROM [Resumen]";
         sOrderString = "";
         AddWhere(sWhereString, "([ResumenID] >= @AV6cResumenID)");
         if ( ! (0==AV7cConfigGenID) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV7cConfigGenID)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cResumenTotClientes) )
         {
            AddWhere(sWhereString, "([ResumenTotClientes] >= @AV8cResumenTotClientes)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cProfeTotProfesionales) )
         {
            AddWhere(sWhereString, "([ProfeTotProfesionales] >= @AV9cProfeTotProfesionales)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cResumenTotTrabRealizados) )
         {
            AddWhere(sWhereString, "([ResumenTotTrabRealizados] >= @AV10cResumenTotTrabRealizados)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cResumenTotServicios) )
         {
            AddWhere(sWhereString, "([ResumenTotServicios] >= @AV11cResumenTotServicios)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cResumenFechMod) )
         {
            AddWhere(sWhereString, "([ResumenFechMod] >= @AV12cResumenFechMod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ResumenID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009W3( IGxContext context ,
                                             short AV7cConfigGenID ,
                                             long AV8cResumenTotClientes ,
                                             long AV9cProfeTotProfesionales ,
                                             long AV10cResumenTotTrabRealizados ,
                                             long AV11cResumenTotServicios ,
                                             DateTime AV12cResumenFechMod ,
                                             short A349ConfigGenID ,
                                             long A372ResumenTotClientes ,
                                             long A373ProfeTotProfesionales ,
                                             long A375ResumenTotTrabRealizados ,
                                             long A376ResumenTotServicios ,
                                             DateTime A377ResumenFechMod ,
                                             long AV6cResumenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Resumen]";
         AddWhere(sWhereString, "([ResumenID] >= @AV6cResumenID)");
         if ( ! (0==AV7cConfigGenID) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV7cConfigGenID)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cResumenTotClientes) )
         {
            AddWhere(sWhereString, "([ResumenTotClientes] >= @AV8cResumenTotClientes)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cProfeTotProfesionales) )
         {
            AddWhere(sWhereString, "([ProfeTotProfesionales] >= @AV9cProfeTotProfesionales)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cResumenTotTrabRealizados) )
         {
            AddWhere(sWhereString, "([ResumenTotTrabRealizados] >= @AV10cResumenTotTrabRealizados)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cResumenTotServicios) )
         {
            AddWhere(sWhereString, "([ResumenTotServicios] >= @AV11cResumenTotServicios)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cResumenFechMod) )
         {
            AddWhere(sWhereString, "([ResumenFechMod] >= @AV12cResumenFechMod)");
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
                     return conditional_H009W2(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H009W3(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH009W2;
          prmH009W2 = new Object[] {
          new ParDef("@AV6cResumenID",GXType.Decimal,18,0) ,
          new ParDef("@AV7cConfigGenID",GXType.Int16,4,0) ,
          new ParDef("@AV8cResumenTotClientes",GXType.Decimal,18,0) ,
          new ParDef("@AV9cProfeTotProfesionales",GXType.Decimal,18,0) ,
          new ParDef("@AV10cResumenTotTrabRealizados",GXType.Decimal,18,0) ,
          new ParDef("@AV11cResumenTotServicios",GXType.Decimal,18,0) ,
          new ParDef("@AV12cResumenFechMod",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009W3;
          prmH009W3 = new Object[] {
          new ParDef("@AV6cResumenID",GXType.Decimal,18,0) ,
          new ParDef("@AV7cConfigGenID",GXType.Int16,4,0) ,
          new ParDef("@AV8cResumenTotClientes",GXType.Decimal,18,0) ,
          new ParDef("@AV9cProfeTotProfesionales",GXType.Decimal,18,0) ,
          new ParDef("@AV10cResumenTotTrabRealizados",GXType.Decimal,18,0) ,
          new ParDef("@AV11cResumenTotServicios",GXType.Decimal,18,0) ,
          new ParDef("@AV12cResumenFechMod",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H009W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009W2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009W3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

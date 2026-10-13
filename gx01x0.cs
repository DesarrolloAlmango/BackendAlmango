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
   public class gx01x0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01x0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01x0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pCentroCostosId )
      {
         this.AV13pCentroCostosId = 0 ;
         ExecutePrivate();
         aP0_pCentroCostosId=this.AV13pCentroCostosId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCcentrocostostiporef = new GXCombobox();
         cmbCentroCostosTipoRef = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pCentroCostosId");
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
               gxfirstwebparm = GetFirstPar( "pCentroCostosId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCentroCostosId");
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
               AV13pCentroCostosId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pCentroCostosId", StringUtil.LTrimStr( (decimal)(AV13pCentroCostosId), 18, 0));
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
         AV6cCentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "cCentroCostosId"), "."), 18, MidpointRounding.ToEven));
         cmbavCcentrocostostiporef.FromJSonString( GetNextPar( ));
         AV7cCentroCostosTipoRef = GetPar( "cCentroCostosTipoRef");
         AV8cCentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "cCentroCostosRef"), "."), 18, MidpointRounding.ToEven));
         AV9cCentroCostosNombre = GetPar( "cCentroCostosNombre");
         AV10cCentroCostosPrecioFinal = NumberUtil.Val( GetPar( "cCentroCostosPrecioFinal"), ".");
         AV11cCentroCostosSerial = (long)(Math.Round(NumberUtil.Val( GetPar( "cCentroCostosSerial"), "."), 18, MidpointRounding.ToEven));
         AV12cCentroCostosCosto = NumberUtil.Val( GetPar( "cCentroCostosCosto"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosId, AV7cCentroCostosTipoRef, AV8cCentroCostosRef, AV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto) ;
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
         PAIR2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTIR2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01x0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCentroCostosId,18,0))}, new string[] {"pCentroCostosId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSTIPOREF", StringUtil.RTrim( AV7cCentroCostosTipoRef));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSNOMBRE", StringUtil.RTrim( AV9cCentroCostosNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV10cCentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSSERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSCOSTO", StringUtil.LTrim( StringUtil.NToC( AV12cCentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSTIPOREFFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostostiporeffiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSREFFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosreffiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSPRECIOFINALFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostospreciofinalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSSERIALFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosserialfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSCOSTOFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostoscostofiltercontainer_Class));
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
            WEIR2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTIR2( ) ;
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
         return formatLink("gx01x0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCentroCostosId,18,0))}, new string[] {"pCentroCostosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01X0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Centro de Costos", "") ;
      }

      protected void WBIR0( )
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
            GxWebStd.gx_div_start( context, divCentrocostosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosidfilter_Internalname, context.GetMessage( "Código CC", ""), "", "", lblLblcentrocostosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosid_Internalname, context.GetMessage( "Código CC", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCentroCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cCentroCostosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosid_Visible, edtavCcentrocostosid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01X0.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostostiporeffiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostostiporeffiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostostiporeffilter_Internalname, context.GetMessage( "Tipo Referencia", ""), "", "", lblLblcentrocostostiporeffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCcentrocostostiporef_Internalname, context.GetMessage( "Tipo Referencia", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCcentrocostostiporef, cmbavCcentrocostostiporef_Internalname, StringUtil.RTrim( AV7cCentroCostosTipoRef), 1, cmbavCcentrocostostiporef_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCcentrocostostiporef.Visible, cmbavCcentrocostostiporef.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx01X0.htm");
            cmbavCcentrocostostiporef.CurrentValue = StringUtil.RTrim( AV7cCentroCostosTipoRef);
            AssignProp("", false, cmbavCcentrocostostiporef_Internalname, "Values", (string)(cmbavCcentrocostostiporef.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divCentrocostosreffiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosreffiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosreffilter_Internalname, context.GetMessage( "Referencia Nro:", ""), "", "", lblLblcentrocostosreffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosref_Internalname, context.GetMessage( "Referencia Nro:", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosref_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostosref_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCentroCostosRef), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cCentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosref_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosref_Visible, edtavCcentrocostosref_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01X0.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostosnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosnombrefilter_Internalname, context.GetMessage( "Nombre", ""), "", "", lblLblcentrocostosnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosnombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosnombre_Internalname, StringUtil.RTrim( AV9cCentroCostosNombre), StringUtil.RTrim( context.localUtil.Format( AV9cCentroCostosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosnombre_Visible, edtavCcentrocostosnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01X0.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostospreciofinalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostospreciofinalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostospreciofinalfilter_Internalname, context.GetMessage( "Precio Final", ""), "", "", lblLblcentrocostospreciofinalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostospreciofinal_Internalname, context.GetMessage( "Precio Final", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostospreciofinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cCentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostospreciofinal_Enabled!=0) ? context.localUtil.Format( AV10cCentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV10cCentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostospreciofinal_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostospreciofinal_Visible, edtavCcentrocostospreciofinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01X0.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostosserialfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosserialfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosserialfilter_Internalname, context.GetMessage( "Centro Costos Serial", ""), "", "", lblLblcentrocostosserialfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosserial_Internalname, context.GetMessage( "Centro Costos Serial", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosserial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostosserial_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cCentroCostosSerial), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cCentroCostosSerial), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosserial_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosserial_Visible, edtavCcentrocostosserial_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01X0.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostoscostofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostoscostofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostoscostofilter_Internalname, context.GetMessage( "Costo", ""), "", "", lblLblcentrocostoscostofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17ir1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01X0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostoscosto_Internalname, context.GetMessage( "Costo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostoscosto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12cCentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostoscosto_Enabled!=0) ? context.localUtil.Format( AV12cCentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV12cCentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostoscosto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostoscosto_Visible, edtavCcentrocostoscosto_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01X0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18ir1_client"+"'", TempTags, "", 2, "HLP_Gx01X0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01X0.htm");
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

      protected void STARTIR2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Centro de Costos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPIR0( ) ;
      }

      protected void WSIR2( )
      {
         STARTIR2( ) ;
         EVTIR2( ) ;
      }

      protected void EVTIR2( )
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
                              A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbCentroCostosTipoRef.Name = cmbCentroCostosTipoRef_Internalname;
                              cmbCentroCostosTipoRef.CurrentValue = cgiGet( cmbCentroCostosTipoRef_Internalname);
                              A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
                              A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A475CentroCostosCosto = context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A480CentroCostosHoraAlt = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCentroCostosHoraAlt_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19IR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20IR2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccentrocostosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCentroCostosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostostiporef Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTROCOSTOSTIPOREF"), AV7cCentroCostosTipoRef) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostosref Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSREF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cCentroCostosRef )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostosnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTROCOSTOSNOMBRE"), AV9cCentroCostosNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostospreciofinal Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cCentroCostosPrecioFinal )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostosserial Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cCentroCostosSerial )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostoscosto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV12cCentroCostosCosto )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21IR2 ();
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

      protected void WEIR2( )
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

      protected void PAIR2( )
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
                                        long AV6cCentroCostosId ,
                                        string AV7cCentroCostosTipoRef ,
                                        long AV8cCentroCostosRef ,
                                        string AV9cCentroCostosNombre ,
                                        decimal AV10cCentroCostosPrecioFinal ,
                                        long AV11cCentroCostosSerial ,
                                        decimal AV12cCentroCostosCosto )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFIR2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", "")));
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
         if ( cmbavCcentrocostostiporef.ItemCount > 0 )
         {
            AV7cCentroCostosTipoRef = cmbavCcentrocostostiporef.getValidValue(AV7cCentroCostosTipoRef);
            AssignAttri("", false, "AV7cCentroCostosTipoRef", AV7cCentroCostosTipoRef);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCcentrocostostiporef.CurrentValue = StringUtil.RTrim( AV7cCentroCostosTipoRef);
            AssignProp("", false, cmbavCcentrocostostiporef_Internalname, "Values", cmbavCcentrocostostiporef.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFIR2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFIR2( )
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
                                                 AV7cCentroCostosTipoRef ,
                                                 AV8cCentroCostosRef ,
                                                 AV9cCentroCostosNombre ,
                                                 AV10cCentroCostosPrecioFinal ,
                                                 AV11cCentroCostosSerial ,
                                                 AV12cCentroCostosCosto ,
                                                 A487CentroCostosTipoRef ,
                                                 A462CentroCostosRef ,
                                                 A463CentroCostosNombre ,
                                                 A464CentroCostosPrecioFinal ,
                                                 A465CentroCostosSerial ,
                                                 A475CentroCostosCosto ,
                                                 AV6cCentroCostosId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG
                                                 }
            });
            lV7cCentroCostosTipoRef = StringUtil.PadR( StringUtil.RTrim( AV7cCentroCostosTipoRef), 1, "%");
            lV9cCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV9cCentroCostosNombre), 80, "%");
            /* Using cursor H00IR2 */
            pr_default.execute(0, new Object[] {AV6cCentroCostosId, lV7cCentroCostosTipoRef, AV8cCentroCostosRef, lV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A463CentroCostosNombre = H00IR2_A463CentroCostosNombre[0];
               A480CentroCostosHoraAlt = H00IR2_A480CentroCostosHoraAlt[0];
               A475CentroCostosCosto = H00IR2_A475CentroCostosCosto[0];
               A465CentroCostosSerial = H00IR2_A465CentroCostosSerial[0];
               A464CentroCostosPrecioFinal = H00IR2_A464CentroCostosPrecioFinal[0];
               A462CentroCostosRef = H00IR2_A462CentroCostosRef[0];
               A487CentroCostosTipoRef = H00IR2_A487CentroCostosTipoRef[0];
               A461CentroCostosId = H00IR2_A461CentroCostosId[0];
               /* Execute user event: Load */
               E20IR2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBIR0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesIR2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cCentroCostosTipoRef ,
                                              AV8cCentroCostosRef ,
                                              AV9cCentroCostosNombre ,
                                              AV10cCentroCostosPrecioFinal ,
                                              AV11cCentroCostosSerial ,
                                              AV12cCentroCostosCosto ,
                                              A487CentroCostosTipoRef ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A465CentroCostosSerial ,
                                              A475CentroCostosCosto ,
                                              AV6cCentroCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG
                                              }
         });
         lV7cCentroCostosTipoRef = StringUtil.PadR( StringUtil.RTrim( AV7cCentroCostosTipoRef), 1, "%");
         lV9cCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV9cCentroCostosNombre), 80, "%");
         /* Using cursor H00IR3 */
         pr_default.execute(1, new Object[] {AV6cCentroCostosId, lV7cCentroCostosTipoRef, AV8cCentroCostosRef, lV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto});
         GRID1_nRecordCount = H00IR3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosId, AV7cCentroCostosTipoRef, AV8cCentroCostosRef, AV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosId, AV7cCentroCostosTipoRef, AV8cCentroCostosRef, AV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosId, AV7cCentroCostosTipoRef, AV8cCentroCostosRef, AV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosId, AV7cCentroCostosTipoRef, AV8cCentroCostosRef, AV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosId, AV7cCentroCostosTipoRef, AV8cCentroCostosRef, AV9cCentroCostosNombre, AV10cCentroCostosPrecioFinal, AV11cCentroCostosSerial, AV12cCentroCostosCosto) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCentroCostosId_Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosSerial_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosHoraAlt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPIR0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19IR2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSID");
               GX_FocusControl = edtavCcentrocostosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCentroCostosId = 0;
               AssignAttri("", false, "AV6cCentroCostosId", StringUtil.LTrimStr( (decimal)(AV6cCentroCostosId), 18, 0));
            }
            else
            {
               AV6cCentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcentrocostosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCentroCostosId", StringUtil.LTrimStr( (decimal)(AV6cCentroCostosId), 18, 0));
            }
            cmbavCcentrocostostiporef.Name = cmbavCcentrocostostiporef_Internalname;
            cmbavCcentrocostostiporef.CurrentValue = cgiGet( cmbavCcentrocostostiporef_Internalname);
            AV7cCentroCostosTipoRef = cgiGet( cmbavCcentrocostostiporef_Internalname);
            AssignAttri("", false, "AV7cCentroCostosTipoRef", AV7cCentroCostosTipoRef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosref_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosref_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSREF");
               GX_FocusControl = edtavCcentrocostosref_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCentroCostosRef = 0;
               AssignAttri("", false, "AV8cCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8cCentroCostosRef), 18, 0));
            }
            else
            {
               AV8cCentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcentrocostosref_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8cCentroCostosRef), 18, 0));
            }
            AV9cCentroCostosNombre = cgiGet( edtavCcentrocostosnombre_Internalname);
            AssignAttri("", false, "AV9cCentroCostosNombre", AV9cCentroCostosNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostospreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostospreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSPRECIOFINAL");
               GX_FocusControl = edtavCcentrocostospreciofinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cCentroCostosPrecioFinal = 0;
               AssignAttri("", false, "AV10cCentroCostosPrecioFinal", StringUtil.LTrimStr( AV10cCentroCostosPrecioFinal, 18, 2));
            }
            else
            {
               AV10cCentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtavCcentrocostospreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10cCentroCostosPrecioFinal", StringUtil.LTrimStr( AV10cCentroCostosPrecioFinal, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosserial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosserial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSSERIAL");
               GX_FocusControl = edtavCcentrocostosserial_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCentroCostosSerial = 0;
               AssignAttri("", false, "AV11cCentroCostosSerial", StringUtil.LTrimStr( (decimal)(AV11cCentroCostosSerial), 10, 0));
            }
            else
            {
               AV11cCentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcentrocostosserial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cCentroCostosSerial", StringUtil.LTrimStr( (decimal)(AV11cCentroCostosSerial), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostoscosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostoscosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSCOSTO");
               GX_FocusControl = edtavCcentrocostoscosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCentroCostosCosto = 0;
               AssignAttri("", false, "AV12cCentroCostosCosto", StringUtil.LTrimStr( AV12cCentroCostosCosto, 18, 2));
            }
            else
            {
               AV12cCentroCostosCosto = context.localUtil.CToN( cgiGet( edtavCcentrocostoscosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV12cCentroCostosCosto", StringUtil.LTrimStr( AV12cCentroCostosCosto, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCentroCostosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTROCOSTOSTIPOREF"), AV7cCentroCostosTipoRef) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSREF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cCentroCostosRef )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTROCOSTOSNOMBRE"), AV9cCentroCostosNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cCentroCostosPrecioFinal )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cCentroCostosSerial )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV12cCentroCostosCosto )
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
         E19IR2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19IR2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Centro de Costos", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20IR2( )
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
         E21IR2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21IR2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCentroCostosId = A461CentroCostosId;
         AssignAttri("", false, "AV13pCentroCostosId", StringUtil.LTrimStr( (decimal)(AV13pCentroCostosId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pCentroCostosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCentroCostosId"});
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
         AV13pCentroCostosId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pCentroCostosId", StringUtil.LTrimStr( (decimal)(AV13pCentroCostosId), 18, 0));
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
         PAIR2( ) ;
         WSIR2( ) ;
         WEIR2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021263179", true, true, false);
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
         context.AddJavascriptSource("gx01x0.js", "?202673021263180", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCentroCostosId_Internalname = "CENTROCOSTOSID_"+sGXsfl_84_idx;
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF_"+sGXsfl_84_idx;
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF_"+sGXsfl_84_idx;
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL_"+sGXsfl_84_idx;
         edtCentroCostosSerial_Internalname = "CENTROCOSTOSSERIAL_"+sGXsfl_84_idx;
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO_"+sGXsfl_84_idx;
         edtCentroCostosHoraAlt_Internalname = "CENTROCOSTOSHORAALT_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCentroCostosId_Internalname = "CENTROCOSTOSID_"+sGXsfl_84_fel_idx;
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF_"+sGXsfl_84_fel_idx;
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF_"+sGXsfl_84_fel_idx;
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL_"+sGXsfl_84_fel_idx;
         edtCentroCostosSerial_Internalname = "CENTROCOSTOSSERIAL_"+sGXsfl_84_fel_idx;
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO_"+sGXsfl_84_fel_idx;
         edtCentroCostosHoraAlt_Internalname = "CENTROCOSTOSHORAALT_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBIR0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbCentroCostosTipoRef.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_84_idx;
               cmbCentroCostosTipoRef.Name = GXCCtl;
               cmbCentroCostosTipoRef.WebTags = "";
               cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
               cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
               if ( cmbCentroCostosTipoRef.ItemCount > 0 )
               {
                  A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosTipoRef,(string)cmbCentroCostosTipoRef_Internalname,StringUtil.RTrim( A487CentroCostosTipoRef),(short)1,(string)cmbCentroCostosTipoRef_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosRef_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosSerial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A465CentroCostosSerial), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosSerial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosHoraAlt_Internalname,context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"),context.localUtil.Format( A480CentroCostosHoraAlt, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosHoraAlt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesIR2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCcentrocostostiporef.Name = "vCCENTROCOSTOSTIPOREF";
         cmbavCcentrocostostiporef.WebTags = "";
         cmbavCcentrocostostiporef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbavCcentrocostostiporef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbavCcentrocostostiporef.ItemCount > 0 )
         {
            AV7cCentroCostosTipoRef = cmbavCcentrocostostiporef.getValidValue(AV7cCentroCostosTipoRef);
            AssignAttri("", false, "AV7cCentroCostosTipoRef", AV7cCentroCostosTipoRef);
         }
         GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_84_idx;
         cmbCentroCostosTipoRef.Name = GXCCtl;
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
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
            context.SendWebValue( context.GetMessage( "Código CC:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Referencia:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia Nro:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costos Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora de Alta", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A487CentroCostosTipoRef)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99")));
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
         lblLblcentrocostosidfilter_Internalname = "LBLCENTROCOSTOSIDFILTER";
         edtavCcentrocostosid_Internalname = "vCCENTROCOSTOSID";
         divCentrocostosidfiltercontainer_Internalname = "CENTROCOSTOSIDFILTERCONTAINER";
         lblLblcentrocostostiporeffilter_Internalname = "LBLCENTROCOSTOSTIPOREFFILTER";
         cmbavCcentrocostostiporef_Internalname = "vCCENTROCOSTOSTIPOREF";
         divCentrocostostiporeffiltercontainer_Internalname = "CENTROCOSTOSTIPOREFFILTERCONTAINER";
         lblLblcentrocostosreffilter_Internalname = "LBLCENTROCOSTOSREFFILTER";
         edtavCcentrocostosref_Internalname = "vCCENTROCOSTOSREF";
         divCentrocostosreffiltercontainer_Internalname = "CENTROCOSTOSREFFILTERCONTAINER";
         lblLblcentrocostosnombrefilter_Internalname = "LBLCENTROCOSTOSNOMBREFILTER";
         edtavCcentrocostosnombre_Internalname = "vCCENTROCOSTOSNOMBRE";
         divCentrocostosnombrefiltercontainer_Internalname = "CENTROCOSTOSNOMBREFILTERCONTAINER";
         lblLblcentrocostospreciofinalfilter_Internalname = "LBLCENTROCOSTOSPRECIOFINALFILTER";
         edtavCcentrocostospreciofinal_Internalname = "vCCENTROCOSTOSPRECIOFINAL";
         divCentrocostospreciofinalfiltercontainer_Internalname = "CENTROCOSTOSPRECIOFINALFILTERCONTAINER";
         lblLblcentrocostosserialfilter_Internalname = "LBLCENTROCOSTOSSERIALFILTER";
         edtavCcentrocostosserial_Internalname = "vCCENTROCOSTOSSERIAL";
         divCentrocostosserialfiltercontainer_Internalname = "CENTROCOSTOSSERIALFILTERCONTAINER";
         lblLblcentrocostoscostofilter_Internalname = "LBLCENTROCOSTOSCOSTOFILTER";
         edtavCcentrocostoscosto_Internalname = "vCCENTROCOSTOSCOSTO";
         divCentrocostoscostofiltercontainer_Internalname = "CENTROCOSTOSCOSTOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCentroCostosId_Internalname = "CENTROCOSTOSID";
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF";
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF";
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL";
         edtCentroCostosSerial_Internalname = "CENTROCOSTOSSERIAL";
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO";
         edtCentroCostosHoraAlt_Internalname = "CENTROCOSTOSHORAALT";
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
         edtCentroCostosHoraAlt_Jsonclick = "";
         edtCentroCostosCosto_Jsonclick = "";
         edtCentroCostosSerial_Jsonclick = "";
         edtCentroCostosPrecioFinal_Jsonclick = "";
         edtCentroCostosRef_Jsonclick = "";
         cmbCentroCostosTipoRef_Jsonclick = "";
         edtCentroCostosId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCentroCostosHoraAlt_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosSerial_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosId_Enabled = 0;
         edtavCcentrocostoscosto_Jsonclick = "";
         edtavCcentrocostoscosto_Enabled = 1;
         edtavCcentrocostoscosto_Visible = 1;
         edtavCcentrocostosserial_Jsonclick = "";
         edtavCcentrocostosserial_Enabled = 1;
         edtavCcentrocostosserial_Visible = 1;
         edtavCcentrocostospreciofinal_Jsonclick = "";
         edtavCcentrocostospreciofinal_Enabled = 1;
         edtavCcentrocostospreciofinal_Visible = 1;
         edtavCcentrocostosnombre_Jsonclick = "";
         edtavCcentrocostosnombre_Enabled = 1;
         edtavCcentrocostosnombre_Visible = 1;
         edtavCcentrocostosref_Jsonclick = "";
         edtavCcentrocostosref_Enabled = 1;
         edtavCcentrocostosref_Visible = 1;
         cmbavCcentrocostostiporef_Jsonclick = "";
         cmbavCcentrocostostiporef.Visible = 1;
         cmbavCcentrocostostiporef.Enabled = 1;
         edtavCcentrocostosid_Jsonclick = "";
         edtavCcentrocostosid_Enabled = 1;
         edtavCcentrocostosid_Visible = 1;
         divCentrocostoscostofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosserialfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostospreciofinalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosreffiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostostiporeffiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Centro de Costos", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosId',fld:'vCCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCcentrocostostiporef'},{av:'AV7cCentroCostosTipoRef',fld:'vCCENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'AV8cCentroCostosRef',fld:'vCCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCentroCostosNombre',fld:'vCCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV10cCentroCostosPrecioFinal',fld:'vCCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV11cCentroCostosSerial',fld:'vCCENTROCOSTOSSERIAL',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV12cCentroCostosCosto',fld:'vCCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18IR1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCENTROCOSTOSIDFILTER.CLICK","{handler:'E11IR1',iparms:[{av:'divCentrocostosidfiltercontainer_Class',ctrl:'CENTROCOSTOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSIDFILTER.CLICK",",oparms:[{av:'divCentrocostosidfiltercontainer_Class',ctrl:'CENTROCOSTOSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosid_Visible',ctrl:'vCCENTROCOSTOSID',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSTIPOREFFILTER.CLICK","{handler:'E12IR1',iparms:[{av:'divCentrocostostiporeffiltercontainer_Class',ctrl:'CENTROCOSTOSTIPOREFFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSTIPOREFFILTER.CLICK",",oparms:[{av:'divCentrocostostiporeffiltercontainer_Class',ctrl:'CENTROCOSTOSTIPOREFFILTERCONTAINER',prop:'Class'},{av:'cmbavCcentrocostostiporef'}]}");
         setEventMetadata("LBLCENTROCOSTOSREFFILTER.CLICK","{handler:'E13IR1',iparms:[{av:'divCentrocostosreffiltercontainer_Class',ctrl:'CENTROCOSTOSREFFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSREFFILTER.CLICK",",oparms:[{av:'divCentrocostosreffiltercontainer_Class',ctrl:'CENTROCOSTOSREFFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosref_Visible',ctrl:'vCCENTROCOSTOSREF',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSNOMBREFILTER.CLICK","{handler:'E14IR1',iparms:[{av:'divCentrocostosnombrefiltercontainer_Class',ctrl:'CENTROCOSTOSNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSNOMBREFILTER.CLICK",",oparms:[{av:'divCentrocostosnombrefiltercontainer_Class',ctrl:'CENTROCOSTOSNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosnombre_Visible',ctrl:'vCCENTROCOSTOSNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSPRECIOFINALFILTER.CLICK","{handler:'E15IR1',iparms:[{av:'divCentrocostospreciofinalfiltercontainer_Class',ctrl:'CENTROCOSTOSPRECIOFINALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSPRECIOFINALFILTER.CLICK",",oparms:[{av:'divCentrocostospreciofinalfiltercontainer_Class',ctrl:'CENTROCOSTOSPRECIOFINALFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostospreciofinal_Visible',ctrl:'vCCENTROCOSTOSPRECIOFINAL',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSSERIALFILTER.CLICK","{handler:'E16IR1',iparms:[{av:'divCentrocostosserialfiltercontainer_Class',ctrl:'CENTROCOSTOSSERIALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSSERIALFILTER.CLICK",",oparms:[{av:'divCentrocostosserialfiltercontainer_Class',ctrl:'CENTROCOSTOSSERIALFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosserial_Visible',ctrl:'vCCENTROCOSTOSSERIAL',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSCOSTOFILTER.CLICK","{handler:'E17IR1',iparms:[{av:'divCentrocostoscostofiltercontainer_Class',ctrl:'CENTROCOSTOSCOSTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSCOSTOFILTER.CLICK",",oparms:[{av:'divCentrocostoscostofiltercontainer_Class',ctrl:'CENTROCOSTOSCOSTOFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostoscosto_Visible',ctrl:'vCCENTROCOSTOSCOSTO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21IR2',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCentroCostosId',fld:'vPCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosId',fld:'vCCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCcentrocostostiporef'},{av:'AV7cCentroCostosTipoRef',fld:'vCCENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'AV8cCentroCostosRef',fld:'vCCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCentroCostosNombre',fld:'vCCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV10cCentroCostosPrecioFinal',fld:'vCCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV11cCentroCostosSerial',fld:'vCCENTROCOSTOSSERIAL',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV12cCentroCostosCosto',fld:'vCCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosId',fld:'vCCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCcentrocostostiporef'},{av:'AV7cCentroCostosTipoRef',fld:'vCCENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'AV8cCentroCostosRef',fld:'vCCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCentroCostosNombre',fld:'vCCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV10cCentroCostosPrecioFinal',fld:'vCCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV11cCentroCostosSerial',fld:'vCCENTROCOSTOSSERIAL',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV12cCentroCostosCosto',fld:'vCCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosId',fld:'vCCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCcentrocostostiporef'},{av:'AV7cCentroCostosTipoRef',fld:'vCCENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'AV8cCentroCostosRef',fld:'vCCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCentroCostosNombre',fld:'vCCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV10cCentroCostosPrecioFinal',fld:'vCCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV11cCentroCostosSerial',fld:'vCCENTROCOSTOSSERIAL',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV12cCentroCostosCosto',fld:'vCCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosId',fld:'vCCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCcentrocostostiporef'},{av:'AV7cCentroCostosTipoRef',fld:'vCCENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'AV8cCentroCostosRef',fld:'vCCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCentroCostosNombre',fld:'vCCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV10cCentroCostosPrecioFinal',fld:'vCCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV11cCentroCostosSerial',fld:'vCCENTROCOSTOSSERIAL',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV12cCentroCostosCosto',fld:'vCCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Centrocostoshoraalt',iparms:[]");
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
         AV7cCentroCostosTipoRef = "";
         AV9cCentroCostosNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcentrocostosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblcentrocostostiporeffilter_Jsonclick = "";
         lblLblcentrocostosreffilter_Jsonclick = "";
         lblLblcentrocostosnombrefilter_Jsonclick = "";
         lblLblcentrocostospreciofinalfilter_Jsonclick = "";
         lblLblcentrocostosserialfilter_Jsonclick = "";
         lblLblcentrocostoscostofilter_Jsonclick = "";
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
         A487CentroCostosTipoRef = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         lV7cCentroCostosTipoRef = "";
         lV9cCentroCostosNombre = "";
         A463CentroCostosNombre = "";
         H00IR2_A463CentroCostosNombre = new string[] {""} ;
         H00IR2_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         H00IR2_A475CentroCostosCosto = new decimal[1] ;
         H00IR2_A465CentroCostosSerial = new long[1] ;
         H00IR2_A464CentroCostosPrecioFinal = new decimal[1] ;
         H00IR2_A462CentroCostosRef = new long[1] ;
         H00IR2_A487CentroCostosTipoRef = new string[] {""} ;
         H00IR2_A461CentroCostosId = new long[1] ;
         H00IR3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01x0__default(),
            new Object[][] {
                new Object[] {
               H00IR2_A463CentroCostosNombre, H00IR2_A480CentroCostosHoraAlt, H00IR2_A475CentroCostosCosto, H00IR2_A465CentroCostosSerial, H00IR2_A464CentroCostosPrecioFinal, H00IR2_A462CentroCostosRef, H00IR2_A487CentroCostosTipoRef, H00IR2_A461CentroCostosId
               }
               , new Object[] {
               H00IR3_AGRID1_nRecordCount
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
      private int edtavCcentrocostosid_Enabled ;
      private int edtavCcentrocostosid_Visible ;
      private int edtavCcentrocostosref_Enabled ;
      private int edtavCcentrocostosref_Visible ;
      private int edtavCcentrocostosnombre_Visible ;
      private int edtavCcentrocostosnombre_Enabled ;
      private int edtavCcentrocostospreciofinal_Enabled ;
      private int edtavCcentrocostospreciofinal_Visible ;
      private int edtavCcentrocostosserial_Enabled ;
      private int edtavCcentrocostosserial_Visible ;
      private int edtavCcentrocostoscosto_Enabled ;
      private int edtavCcentrocostoscosto_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int edtCentroCostosSerial_Enabled ;
      private int edtCentroCostosCosto_Enabled ;
      private int edtCentroCostosHoraAlt_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pCentroCostosId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cCentroCostosId ;
      private long AV8cCentroCostosRef ;
      private long AV11cCentroCostosSerial ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A465CentroCostosSerial ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV10cCentroCostosPrecioFinal ;
      private decimal AV12cCentroCostosCosto ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCentrocostosidfiltercontainer_Class ;
      private string divCentrocostostiporeffiltercontainer_Class ;
      private string divCentrocostosreffiltercontainer_Class ;
      private string divCentrocostosnombrefiltercontainer_Class ;
      private string divCentrocostospreciofinalfiltercontainer_Class ;
      private string divCentrocostosserialfiltercontainer_Class ;
      private string divCentrocostoscostofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cCentroCostosTipoRef ;
      private string AV9cCentroCostosNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCentrocostosidfiltercontainer_Internalname ;
      private string lblLblcentrocostosidfilter_Internalname ;
      private string lblLblcentrocostosidfilter_Jsonclick ;
      private string edtavCcentrocostosid_Internalname ;
      private string TempTags ;
      private string edtavCcentrocostosid_Jsonclick ;
      private string divCentrocostostiporeffiltercontainer_Internalname ;
      private string lblLblcentrocostostiporeffilter_Internalname ;
      private string lblLblcentrocostostiporeffilter_Jsonclick ;
      private string cmbavCcentrocostostiporef_Internalname ;
      private string cmbavCcentrocostostiporef_Jsonclick ;
      private string divCentrocostosreffiltercontainer_Internalname ;
      private string lblLblcentrocostosreffilter_Internalname ;
      private string lblLblcentrocostosreffilter_Jsonclick ;
      private string edtavCcentrocostosref_Internalname ;
      private string edtavCcentrocostosref_Jsonclick ;
      private string divCentrocostosnombrefiltercontainer_Internalname ;
      private string lblLblcentrocostosnombrefilter_Internalname ;
      private string lblLblcentrocostosnombrefilter_Jsonclick ;
      private string edtavCcentrocostosnombre_Internalname ;
      private string edtavCcentrocostosnombre_Jsonclick ;
      private string divCentrocostospreciofinalfiltercontainer_Internalname ;
      private string lblLblcentrocostospreciofinalfilter_Internalname ;
      private string lblLblcentrocostospreciofinalfilter_Jsonclick ;
      private string edtavCcentrocostospreciofinal_Internalname ;
      private string edtavCcentrocostospreciofinal_Jsonclick ;
      private string divCentrocostosserialfiltercontainer_Internalname ;
      private string lblLblcentrocostosserialfilter_Internalname ;
      private string lblLblcentrocostosserialfilter_Jsonclick ;
      private string edtavCcentrocostosserial_Internalname ;
      private string edtavCcentrocostosserial_Jsonclick ;
      private string divCentrocostoscostofiltercontainer_Internalname ;
      private string lblLblcentrocostoscostofilter_Internalname ;
      private string lblLblcentrocostoscostofilter_Jsonclick ;
      private string edtavCcentrocostoscosto_Internalname ;
      private string edtavCcentrocostoscosto_Jsonclick ;
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
      private string edtCentroCostosId_Internalname ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string A487CentroCostosTipoRef ;
      private string edtCentroCostosRef_Internalname ;
      private string edtCentroCostosPrecioFinal_Internalname ;
      private string edtCentroCostosSerial_Internalname ;
      private string edtCentroCostosCosto_Internalname ;
      private string edtCentroCostosHoraAlt_Internalname ;
      private string lV7cCentroCostosTipoRef ;
      private string lV9cCentroCostosNombre ;
      private string A463CentroCostosNombre ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCentroCostosId_Jsonclick ;
      private string GXCCtl ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string edtCentroCostosSerial_Jsonclick ;
      private string edtCentroCostosCosto_Jsonclick ;
      private string edtCentroCostosHoraAlt_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime A480CentroCostosHoraAlt ;
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
      private GXCombobox cmbavCcentrocostostiporef ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private IDataStoreProvider pr_default ;
      private string[] H00IR2_A463CentroCostosNombre ;
      private DateTime[] H00IR2_A480CentroCostosHoraAlt ;
      private decimal[] H00IR2_A475CentroCostosCosto ;
      private long[] H00IR2_A465CentroCostosSerial ;
      private decimal[] H00IR2_A464CentroCostosPrecioFinal ;
      private long[] H00IR2_A462CentroCostosRef ;
      private string[] H00IR2_A487CentroCostosTipoRef ;
      private long[] H00IR2_A461CentroCostosId ;
      private long[] H00IR3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pCentroCostosId ;
   }

   public class gx01x0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00IR2( IGxContext context ,
                                             string AV7cCentroCostosTipoRef ,
                                             long AV8cCentroCostosRef ,
                                             string AV9cCentroCostosNombre ,
                                             decimal AV10cCentroCostosPrecioFinal ,
                                             long AV11cCentroCostosSerial ,
                                             decimal AV12cCentroCostosCosto ,
                                             string A487CentroCostosTipoRef ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             long A465CentroCostosSerial ,
                                             decimal A475CentroCostosCosto ,
                                             long AV6cCentroCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CentroCostosNombre], [CentroCostosHoraAlt], [CentroCostosCosto], [CentroCostosSerial], [CentroCostosPrecioFinal], [CentroCostosRef], [CentroCostosTipoRef], [CentroCostosId]";
         sFromString = " FROM [CentroCostos]";
         sOrderString = "";
         AddWhere(sWhereString, "([CentroCostosId] >= @AV6cCentroCostosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCentroCostosTipoRef)) )
         {
            AddWhere(sWhereString, "([CentroCostosTipoRef] like @lV7cCentroCostosTipoRef)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cCentroCostosRef) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] >= @AV8cCentroCostosRef)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCentroCostosNombre)) )
         {
            AddWhere(sWhereString, "([CentroCostosNombre] like @lV9cCentroCostosNombre)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] >= @AV10cCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cCentroCostosSerial) )
         {
            AddWhere(sWhereString, "([CentroCostosSerial] >= @AV11cCentroCostosSerial)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12cCentroCostosCosto) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] >= @AV12cCentroCostosCosto)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [CentroCostosId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00IR3( IGxContext context ,
                                             string AV7cCentroCostosTipoRef ,
                                             long AV8cCentroCostosRef ,
                                             string AV9cCentroCostosNombre ,
                                             decimal AV10cCentroCostosPrecioFinal ,
                                             long AV11cCentroCostosSerial ,
                                             decimal AV12cCentroCostosCosto ,
                                             string A487CentroCostosTipoRef ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             long A465CentroCostosSerial ,
                                             decimal A475CentroCostosCosto ,
                                             long AV6cCentroCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CentroCostos]";
         AddWhere(sWhereString, "([CentroCostosId] >= @AV6cCentroCostosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCentroCostosTipoRef)) )
         {
            AddWhere(sWhereString, "([CentroCostosTipoRef] like @lV7cCentroCostosTipoRef)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cCentroCostosRef) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] >= @AV8cCentroCostosRef)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCentroCostosNombre)) )
         {
            AddWhere(sWhereString, "([CentroCostosNombre] like @lV9cCentroCostosNombre)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] >= @AV10cCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cCentroCostosSerial) )
         {
            AddWhere(sWhereString, "([CentroCostosSerial] >= @AV11cCentroCostosSerial)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12cCentroCostosCosto) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] >= @AV12cCentroCostosCosto)");
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
                     return conditional_H00IR2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (long)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00IR3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (long)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00IR2;
          prmH00IR2 = new Object[] {
          new ParDef("@AV6cCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cCentroCostosTipoRef",GXType.NChar,1,0) ,
          new ParDef("@AV8cCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@lV9cCentroCostosNombre",GXType.NChar,80,0) ,
          new ParDef("@AV10cCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV11cCentroCostosSerial",GXType.Decimal,10,0) ,
          new ParDef("@AV12cCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00IR3;
          prmH00IR3 = new Object[] {
          new ParDef("@AV6cCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cCentroCostosTipoRef",GXType.NChar,1,0) ,
          new ParDef("@AV8cCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@lV9cCentroCostosNombre",GXType.NChar,80,0) ,
          new ParDef("@AV10cCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV11cCentroCostosSerial",GXType.Decimal,10,0) ,
          new ParDef("@AV12cCentroCostosCosto",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00IR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00IR2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00IR3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00IR3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

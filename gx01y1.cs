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
   public class gx01y1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01y1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01y1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pCentroCostosId ,
                           out long aP1_pCentroCostosDetallesId )
      {
         this.AV10pCentroCostosId = aP0_pCentroCostosId;
         this.AV11pCentroCostosDetallesId = 0 ;
         ExecutePrivate();
         aP1_pCentroCostosDetallesId=this.AV11pCentroCostosDetallesId;
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
               AV10pCentroCostosId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10pCentroCostosId", StringUtil.LTrimStr( (decimal)(AV10pCentroCostosId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11pCentroCostosDetallesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pCentroCostosDetallesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11pCentroCostosDetallesId", StringUtil.LTrimStr( (decimal)(AV11pCentroCostosDetallesId), 18, 0));
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
         AV6cCentroCostosDetallesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cCentroCostosDetallesId"), "."), 18, MidpointRounding.ToEven));
         AV7cListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "cListaCostosId"), "."), 18, MidpointRounding.ToEven));
         AV8cCentroCostosDetallesNombre = GetPar( "cCentroCostosDetallesNombre");
         AV9cCentroCostosDetallesValor = NumberUtil.Val( GetPar( "cCentroCostosDetallesValor"), ".");
         AV14cCentroCostosDetallesSolId = (long)(Math.Round(NumberUtil.Val( GetPar( "cCentroCostosDetallesSolId"), "."), 18, MidpointRounding.ToEven));
         AV15cCCDetallesProfId = GetPar( "cCCDetallesProfId");
         AV10pCentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "pCentroCostosId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosDetallesId, AV7cListaCostosId, AV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, AV15cCCDetallesProfId, AV10pCentroCostosId) ;
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
         PAA92( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA92( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01y1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pCentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV11pCentroCostosDetallesId,18,0))}, new string[] {"pCentroCostosId","pCentroCostosDetallesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSDETALLESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLISTACOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSDETALLESNOMBRE", StringUtil.RTrim( AV8cCentroCostosDetallesNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSDETALLESVALOR", StringUtil.LTrim( StringUtil.NToC( AV9cCentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTROCOSTOSDETALLESSOLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cCentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCCDETALLESPROFID", StringUtil.RTrim( AV15cCCDetallesProfId));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCENTROCOSTOSDETALLESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pCentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESIDFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosdetallesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divListacostosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosdetallesnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosdetallesvalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESSOLIDFILTERCONTAINER_Class", StringUtil.RTrim( divCentrocostosdetallessolidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CCDETALLESPROFIDFILTERCONTAINER_Class", StringUtil.RTrim( divCcdetallesprofidfiltercontainer_Class));
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
            WEA92( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA92( ) ;
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
         return formatLink("gx01y1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pCentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV11pCentroCostosDetallesId,18,0))}, new string[] {"pCentroCostosId","pCentroCostosDetallesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01Y1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Detalles", "") ;
      }

      protected void WBA90( )
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
            GxWebStd.gx_div_start( context, divCentrocostosdetallesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosdetallesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosdetallesidfilter_Internalname, context.GetMessage( "ListadoID", ""), "", "", lblLblcentrocostosdetallesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11a91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Y1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosdetallesid_Internalname, context.GetMessage( "ListadoID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosdetallesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostosdetallesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cCentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosdetallesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosdetallesid_Visible, edtavCcentrocostosdetallesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01Y1.htm");
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
            GxWebStd.gx_div_start( context, divListacostosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divListacostosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbllistacostosidfilter_Internalname, context.GetMessage( "Idc", ""), "", "", lblLbllistacostosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12a91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Y1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClistacostosid_Internalname, context.GetMessage( "Idc", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClistacostosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavClistacostosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cListaCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cListaCostosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClistacostosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavClistacostosid_Visible, edtavClistacostosid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01Y1.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostosdetallesnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosdetallesnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosdetallesnombrefilter_Internalname, context.GetMessage( "Nombre", ""), "", "", lblLblcentrocostosdetallesnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13a91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Y1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosdetallesnombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosdetallesnombre_Internalname, StringUtil.RTrim( AV8cCentroCostosDetallesNombre), StringUtil.RTrim( context.localUtil.Format( AV8cCentroCostosDetallesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosdetallesnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosdetallesnombre_Visible, edtavCcentrocostosdetallesnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01Y1.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostosdetallesvalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosdetallesvalorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosdetallesvalorfilter_Internalname, context.GetMessage( "Valor", ""), "", "", lblLblcentrocostosdetallesvalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14a91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Y1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosdetallesvalor_Internalname, context.GetMessage( "Valor", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosdetallesvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cCentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostosdetallesvalor_Enabled!=0) ? context.localUtil.Format( AV9cCentroCostosDetallesValor, "ZZZZZZ9.99") : context.localUtil.Format( AV9cCentroCostosDetallesValor, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosdetallesvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosdetallesvalor_Visible, edtavCcentrocostosdetallesvalor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01Y1.htm");
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
            GxWebStd.gx_div_start( context, divCentrocostosdetallessolidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrocostosdetallessolidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrocostosdetallessolidfilter_Internalname, context.GetMessage( "Centro Costos Detalles Sol Id", ""), "", "", lblLblcentrocostosdetallessolidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15a91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Y1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrocostosdetallessolid_Internalname, context.GetMessage( "Centro Costos Detalles Sol Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrocostosdetallessolid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cCentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcentrocostosdetallessolid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14cCentroCostosDetallesSolId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV14cCentroCostosDetallesSolId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrocostosdetallessolid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrocostosdetallessolid_Visible, edtavCcentrocostosdetallessolid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01Y1.htm");
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
            GxWebStd.gx_div_start( context, divCcdetallesprofidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCcdetallesprofidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblccdetallesprofidfilter_Internalname, context.GetMessage( "CCDetalles Prof Id", ""), "", "", lblLblccdetallesprofidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16a91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01Y1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCccdetallesprofid_Internalname, context.GetMessage( "CCDetalles Prof Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCccdetallesprofid_Internalname, StringUtil.RTrim( AV15cCCDetallesProfId), StringUtil.RTrim( context.localUtil.Format( AV15cCCDetallesProfId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavCccdetallesprofid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCccdetallesprofid_Visible, edtavCccdetallesprofid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01Y1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17a91_client"+"'", TempTags, "", 2, "HLP_Gx01Y1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01Y1.htm");
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

      protected void STARTA92( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Detalles", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA90( ) ;
      }

      protected void WSA92( )
      {
         STARTA92( ) ;
         EVTA92( ) ;
      }

      protected void EVTA92( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosDetallesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n459ListaCostosId = false;
                              A473CentroCostosDetallesNombre = cgiGet( edtCentroCostosDetallesNombre_Internalname);
                              A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18A92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19A92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccentrocostosdetallesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSDETALLESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCentroCostosDetallesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clistacostosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCLISTACOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cListaCostosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostosdetallesnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTROCOSTOSDETALLESNOMBRE"), AV8cCentroCostosDetallesNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostosdetallesvalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSDETALLESVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cCentroCostosDetallesValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrocostosdetallessolid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSDETALLESSOLID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14cCentroCostosDetallesSolId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cccdetallesprofid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCCDETALLESPROFID"), AV15cCCDetallesProfId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20A92 ();
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

      protected void WEA92( )
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

      protected void PAA92( )
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
                                        long AV6cCentroCostosDetallesId ,
                                        long AV7cListaCostosId ,
                                        string AV8cCentroCostosDetallesNombre ,
                                        decimal AV9cCentroCostosDetallesValor ,
                                        long AV14cCentroCostosDetallesSolId ,
                                        string AV15cCCDetallesProfId ,
                                        long AV10pCentroCostosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFA92( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSDETALLESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A466CentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, ".", "")));
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
         RFA92( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFA92( )
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
                                                 AV7cListaCostosId ,
                                                 AV8cCentroCostosDetallesNombre ,
                                                 AV9cCentroCostosDetallesValor ,
                                                 AV14cCentroCostosDetallesSolId ,
                                                 AV15cCCDetallesProfId ,
                                                 A459ListaCostosId ,
                                                 A473CentroCostosDetallesNombre ,
                                                 A468CentroCostosDetallesValor ,
                                                 A888CentroCostosDetallesSolId ,
                                                 A890CCDetallesProfId ,
                                                 AV10pCentroCostosId ,
                                                 AV6cCentroCostosDetallesId ,
                                                 A461CentroCostosId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV8cCentroCostosDetallesNombre = StringUtil.PadR( StringUtil.RTrim( AV8cCentroCostosDetallesNombre), 80, "%");
            lV15cCCDetallesProfId = StringUtil.PadR( StringUtil.RTrim( AV15cCCDetallesProfId), 20, "%");
            /* Using cursor H00A92 */
            pr_default.execute(0, new Object[] {AV10pCentroCostosId, AV6cCentroCostosDetallesId, AV7cListaCostosId, lV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, lV15cCCDetallesProfId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A890CCDetallesProfId = H00A92_A890CCDetallesProfId[0];
               A888CentroCostosDetallesSolId = H00A92_A888CentroCostosDetallesSolId[0];
               A468CentroCostosDetallesValor = H00A92_A468CentroCostosDetallesValor[0];
               A461CentroCostosId = H00A92_A461CentroCostosId[0];
               A473CentroCostosDetallesNombre = H00A92_A473CentroCostosDetallesNombre[0];
               A459ListaCostosId = H00A92_A459ListaCostosId[0];
               n459ListaCostosId = H00A92_n459ListaCostosId[0];
               A466CentroCostosDetallesId = H00A92_A466CentroCostosDetallesId[0];
               /* Execute user event: Load */
               E19A92 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBA90( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA92( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSDETALLESID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A466CentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cListaCostosId ,
                                              AV8cCentroCostosDetallesNombre ,
                                              AV9cCentroCostosDetallesValor ,
                                              AV14cCentroCostosDetallesSolId ,
                                              AV15cCCDetallesProfId ,
                                              A459ListaCostosId ,
                                              A473CentroCostosDetallesNombre ,
                                              A468CentroCostosDetallesValor ,
                                              A888CentroCostosDetallesSolId ,
                                              A890CCDetallesProfId ,
                                              AV10pCentroCostosId ,
                                              AV6cCentroCostosDetallesId ,
                                              A461CentroCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV8cCentroCostosDetallesNombre = StringUtil.PadR( StringUtil.RTrim( AV8cCentroCostosDetallesNombre), 80, "%");
         lV15cCCDetallesProfId = StringUtil.PadR( StringUtil.RTrim( AV15cCCDetallesProfId), 20, "%");
         /* Using cursor H00A93 */
         pr_default.execute(1, new Object[] {AV10pCentroCostosId, AV6cCentroCostosDetallesId, AV7cListaCostosId, lV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, lV15cCCDetallesProfId});
         GRID1_nRecordCount = H00A93_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosDetallesId, AV7cListaCostosId, AV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, AV15cCCDetallesProfId, AV10pCentroCostosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosDetallesId, AV7cListaCostosId, AV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, AV15cCCDetallesProfId, AV10pCentroCostosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosDetallesId, AV7cListaCostosId, AV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, AV15cCCDetallesProfId, AV10pCentroCostosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosDetallesId, AV7cListaCostosId, AV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, AV15cCCDetallesProfId, AV10pCentroCostosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCentroCostosDetallesId, AV7cListaCostosId, AV8cCentroCostosDetallesNombre, AV9cCentroCostosDetallesValor, AV14cCentroCostosDetallesSolId, AV15cCCDetallesProfId, AV10pCentroCostosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCentroCostosDetallesId_Enabled = 0;
         edtListaCostosId_Enabled = 0;
         edtCentroCostosDetallesNombre_Enabled = 0;
         edtCentroCostosId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA90( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18A92 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSDETALLESID");
               GX_FocusControl = edtavCcentrocostosdetallesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCentroCostosDetallesId = 0;
               AssignAttri("", false, "AV6cCentroCostosDetallesId", StringUtil.LTrimStr( (decimal)(AV6cCentroCostosDetallesId), 18, 0));
            }
            else
            {
               AV6cCentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCentroCostosDetallesId", StringUtil.LTrimStr( (decimal)(AV6cCentroCostosDetallesId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClistacostosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClistacostosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLISTACOSTOSID");
               GX_FocusControl = edtavClistacostosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cListaCostosId = 0;
               AssignAttri("", false, "AV7cListaCostosId", StringUtil.LTrimStr( (decimal)(AV7cListaCostosId), 18, 0));
            }
            else
            {
               AV7cListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavClistacostosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cListaCostosId", StringUtil.LTrimStr( (decimal)(AV7cListaCostosId), 18, 0));
            }
            AV8cCentroCostosDetallesNombre = cgiGet( edtavCcentrocostosdetallesnombre_Internalname);
            AssignAttri("", false, "AV8cCentroCostosDetallesNombre", AV8cCentroCostosDetallesNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallesvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallesvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSDETALLESVALOR");
               GX_FocusControl = edtavCcentrocostosdetallesvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cCentroCostosDetallesValor = 0;
               AssignAttri("", false, "AV9cCentroCostosDetallesValor", StringUtil.LTrimStr( AV9cCentroCostosDetallesValor, 10, 2));
            }
            else
            {
               AV9cCentroCostosDetallesValor = context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallesvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV9cCentroCostosDetallesValor", StringUtil.LTrimStr( AV9cCentroCostosDetallesValor, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallessolid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallessolid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCENTROCOSTOSDETALLESSOLID");
               GX_FocusControl = edtavCcentrocostosdetallessolid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14cCentroCostosDetallesSolId = 0;
               AssignAttri("", false, "AV14cCentroCostosDetallesSolId", StringUtil.LTrimStr( (decimal)(AV14cCentroCostosDetallesSolId), 18, 0));
            }
            else
            {
               AV14cCentroCostosDetallesSolId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcentrocostosdetallessolid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14cCentroCostosDetallesSolId", StringUtil.LTrimStr( (decimal)(AV14cCentroCostosDetallesSolId), 18, 0));
            }
            AV15cCCDetallesProfId = cgiGet( edtavCccdetallesprofid_Internalname);
            AssignAttri("", false, "AV15cCCDetallesProfId", AV15cCCDetallesProfId);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSDETALLESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCentroCostosDetallesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCLISTACOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cListaCostosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTROCOSTOSDETALLESNOMBRE"), AV8cCentroCostosDetallesNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSDETALLESVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cCentroCostosDetallesValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCENTROCOSTOSDETALLESSOLID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14cCentroCostosDetallesSolId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCCDETALLESPROFID"), AV15cCCDetallesProfId) != 0 )
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
         E18A92 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18A92( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Detalles", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19A92( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E20A92 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20A92( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pCentroCostosDetallesId = A466CentroCostosDetallesId;
         AssignAttri("", false, "AV11pCentroCostosDetallesId", StringUtil.LTrimStr( (decimal)(AV11pCentroCostosDetallesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV11pCentroCostosDetallesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pCentroCostosDetallesId"});
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
         AV10pCentroCostosId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV10pCentroCostosId", StringUtil.LTrimStr( (decimal)(AV10pCentroCostosId), 18, 0));
         AV11pCentroCostosDetallesId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV11pCentroCostosDetallesId", StringUtil.LTrimStr( (decimal)(AV11pCentroCostosDetallesId), 18, 0));
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
         PAA92( ) ;
         WSA92( ) ;
         WEA92( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126784", true, true, false);
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
         context.AddJavascriptSource("gx01y1.js", "?20267302126784", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID_"+sGXsfl_74_idx;
         edtListaCostosId_Internalname = "LISTACOSTOSID_"+sGXsfl_74_idx;
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_74_idx;
         edtCentroCostosId_Internalname = "CENTROCOSTOSID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID_"+sGXsfl_74_fel_idx;
         edtListaCostosId_Internalname = "LISTACOSTOSID_"+sGXsfl_74_fel_idx;
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_74_fel_idx;
         edtCentroCostosId_Internalname = "CENTROCOSTOSID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBA90( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A466CentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesNombre_Internalname,StringUtil.RTrim( A473CentroCostosDetallesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA92( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Idc", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código CC", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A473CentroCostosDetallesNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", ""))));
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
         lblLblcentrocostosdetallesidfilter_Internalname = "LBLCENTROCOSTOSDETALLESIDFILTER";
         edtavCcentrocostosdetallesid_Internalname = "vCCENTROCOSTOSDETALLESID";
         divCentrocostosdetallesidfiltercontainer_Internalname = "CENTROCOSTOSDETALLESIDFILTERCONTAINER";
         lblLbllistacostosidfilter_Internalname = "LBLLISTACOSTOSIDFILTER";
         edtavClistacostosid_Internalname = "vCLISTACOSTOSID";
         divListacostosidfiltercontainer_Internalname = "LISTACOSTOSIDFILTERCONTAINER";
         lblLblcentrocostosdetallesnombrefilter_Internalname = "LBLCENTROCOSTOSDETALLESNOMBREFILTER";
         edtavCcentrocostosdetallesnombre_Internalname = "vCCENTROCOSTOSDETALLESNOMBRE";
         divCentrocostosdetallesnombrefiltercontainer_Internalname = "CENTROCOSTOSDETALLESNOMBREFILTERCONTAINER";
         lblLblcentrocostosdetallesvalorfilter_Internalname = "LBLCENTROCOSTOSDETALLESVALORFILTER";
         edtavCcentrocostosdetallesvalor_Internalname = "vCCENTROCOSTOSDETALLESVALOR";
         divCentrocostosdetallesvalorfiltercontainer_Internalname = "CENTROCOSTOSDETALLESVALORFILTERCONTAINER";
         lblLblcentrocostosdetallessolidfilter_Internalname = "LBLCENTROCOSTOSDETALLESSOLIDFILTER";
         edtavCcentrocostosdetallessolid_Internalname = "vCCENTROCOSTOSDETALLESSOLID";
         divCentrocostosdetallessolidfiltercontainer_Internalname = "CENTROCOSTOSDETALLESSOLIDFILTERCONTAINER";
         lblLblccdetallesprofidfilter_Internalname = "LBLCCDETALLESPROFIDFILTER";
         edtavCccdetallesprofid_Internalname = "vCCCDETALLESPROFID";
         divCcdetallesprofidfiltercontainer_Internalname = "CCDETALLESPROFIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID";
         edtListaCostosId_Internalname = "LISTACOSTOSID";
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE";
         edtCentroCostosId_Internalname = "CENTROCOSTOSID";
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
         edtCentroCostosId_Jsonclick = "";
         edtCentroCostosDetallesNombre_Jsonclick = "";
         edtListaCostosId_Jsonclick = "";
         edtCentroCostosDetallesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCentroCostosId_Enabled = 0;
         edtCentroCostosDetallesNombre_Enabled = 0;
         edtListaCostosId_Enabled = 0;
         edtCentroCostosDetallesId_Enabled = 0;
         edtavCccdetallesprofid_Jsonclick = "";
         edtavCccdetallesprofid_Enabled = 1;
         edtavCccdetallesprofid_Visible = 1;
         edtavCcentrocostosdetallessolid_Jsonclick = "";
         edtavCcentrocostosdetallessolid_Enabled = 1;
         edtavCcentrocostosdetallessolid_Visible = 1;
         edtavCcentrocostosdetallesvalor_Jsonclick = "";
         edtavCcentrocostosdetallesvalor_Enabled = 1;
         edtavCcentrocostosdetallesvalor_Visible = 1;
         edtavCcentrocostosdetallesnombre_Jsonclick = "";
         edtavCcentrocostosdetallesnombre_Enabled = 1;
         edtavCcentrocostosdetallesnombre_Visible = 1;
         edtavClistacostosid_Jsonclick = "";
         edtavClistacostosid_Enabled = 1;
         edtavClistacostosid_Visible = 1;
         edtavCcentrocostosdetallesid_Jsonclick = "";
         edtavCcentrocostosdetallesid_Enabled = 1;
         edtavCcentrocostosdetallesid_Visible = 1;
         divCcdetallesprofidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosdetallessolidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosdetallesvalorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosdetallesnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divListacostosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCentrocostosdetallesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Detalles", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosDetallesId',fld:'vCCENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cListaCostosId',fld:'vCLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cCentroCostosDetallesNombre',fld:'vCCENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'AV9cCentroCostosDetallesValor',fld:'vCCENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV14cCentroCostosDetallesSolId',fld:'vCCENTROCOSTOSDETALLESSOLID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cCCDetallesProfId',fld:'vCCCDETALLESPROFID',pic:'',type:'char'},{av:'AV10pCentroCostosId',fld:'vPCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17A91',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCENTROCOSTOSDETALLESIDFILTER.CLICK","{handler:'E11A91',iparms:[{av:'divCentrocostosdetallesidfiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSDETALLESIDFILTER.CLICK",",oparms:[{av:'divCentrocostosdetallesidfiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosdetallesid_Visible',ctrl:'vCCENTROCOSTOSDETALLESID',prop:'Visible'}]}");
         setEventMetadata("LBLLISTACOSTOSIDFILTER.CLICK","{handler:'E12A91',iparms:[{av:'divListacostosidfiltercontainer_Class',ctrl:'LISTACOSTOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLLISTACOSTOSIDFILTER.CLICK",",oparms:[{av:'divListacostosidfiltercontainer_Class',ctrl:'LISTACOSTOSIDFILTERCONTAINER',prop:'Class'},{av:'edtavClistacostosid_Visible',ctrl:'vCLISTACOSTOSID',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSDETALLESNOMBREFILTER.CLICK","{handler:'E13A91',iparms:[{av:'divCentrocostosdetallesnombrefiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSDETALLESNOMBREFILTER.CLICK",",oparms:[{av:'divCentrocostosdetallesnombrefiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosdetallesnombre_Visible',ctrl:'vCCENTROCOSTOSDETALLESNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSDETALLESVALORFILTER.CLICK","{handler:'E14A91',iparms:[{av:'divCentrocostosdetallesvalorfiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSDETALLESVALORFILTER.CLICK",",oparms:[{av:'divCentrocostosdetallesvalorfiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosdetallesvalor_Visible',ctrl:'vCCENTROCOSTOSDETALLESVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLCENTROCOSTOSDETALLESSOLIDFILTER.CLICK","{handler:'E15A91',iparms:[{av:'divCentrocostosdetallessolidfiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESSOLIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTROCOSTOSDETALLESSOLIDFILTER.CLICK",",oparms:[{av:'divCentrocostosdetallessolidfiltercontainer_Class',ctrl:'CENTROCOSTOSDETALLESSOLIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrocostosdetallessolid_Visible',ctrl:'vCCENTROCOSTOSDETALLESSOLID',prop:'Visible'}]}");
         setEventMetadata("LBLCCDETALLESPROFIDFILTER.CLICK","{handler:'E16A91',iparms:[{av:'divCcdetallesprofidfiltercontainer_Class',ctrl:'CCDETALLESPROFIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCCDETALLESPROFIDFILTER.CLICK",",oparms:[{av:'divCcdetallesprofidfiltercontainer_Class',ctrl:'CCDETALLESPROFIDFILTERCONTAINER',prop:'Class'},{av:'edtavCccdetallesprofid_Visible',ctrl:'vCCCDETALLESPROFID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20A92',iparms:[{av:'A466CentroCostosDetallesId',fld:'CENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pCentroCostosDetallesId',fld:'vPCENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosDetallesId',fld:'vCCENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cListaCostosId',fld:'vCLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cCentroCostosDetallesNombre',fld:'vCCENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'AV9cCentroCostosDetallesValor',fld:'vCCENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV14cCentroCostosDetallesSolId',fld:'vCCENTROCOSTOSDETALLESSOLID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cCCDetallesProfId',fld:'vCCCDETALLESPROFID',pic:'',type:'char'},{av:'AV10pCentroCostosId',fld:'vPCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosDetallesId',fld:'vCCENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cListaCostosId',fld:'vCLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cCentroCostosDetallesNombre',fld:'vCCENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'AV9cCentroCostosDetallesValor',fld:'vCCENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV14cCentroCostosDetallesSolId',fld:'vCCENTROCOSTOSDETALLESSOLID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cCCDetallesProfId',fld:'vCCCDETALLESPROFID',pic:'',type:'char'},{av:'AV10pCentroCostosId',fld:'vPCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosDetallesId',fld:'vCCENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cListaCostosId',fld:'vCLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cCentroCostosDetallesNombre',fld:'vCCENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'AV9cCentroCostosDetallesValor',fld:'vCCENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV14cCentroCostosDetallesSolId',fld:'vCCENTROCOSTOSDETALLESSOLID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cCCDetallesProfId',fld:'vCCCDETALLESPROFID',pic:'',type:'char'},{av:'AV10pCentroCostosId',fld:'vPCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCentroCostosDetallesId',fld:'vCCENTROCOSTOSDETALLESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cListaCostosId',fld:'vCLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cCentroCostosDetallesNombre',fld:'vCCENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'AV9cCentroCostosDetallesValor',fld:'vCCENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV14cCentroCostosDetallesSolId',fld:'vCCENTROCOSTOSDETALLESSOLID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cCCDetallesProfId',fld:'vCCCDETALLESPROFID',pic:'',type:'char'},{av:'AV10pCentroCostosId',fld:'vPCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Centrocostosid',iparms:[]");
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
         AV8cCentroCostosDetallesNombre = "";
         AV15cCCDetallesProfId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcentrocostosdetallesidfilter_Jsonclick = "";
         TempTags = "";
         lblLbllistacostosidfilter_Jsonclick = "";
         lblLblcentrocostosdetallesnombrefilter_Jsonclick = "";
         lblLblcentrocostosdetallesvalorfilter_Jsonclick = "";
         lblLblcentrocostosdetallessolidfilter_Jsonclick = "";
         lblLblccdetallesprofidfilter_Jsonclick = "";
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
         A473CentroCostosDetallesNombre = "";
         lV8cCentroCostosDetallesNombre = "";
         lV15cCCDetallesProfId = "";
         A890CCDetallesProfId = "";
         H00A92_A890CCDetallesProfId = new string[] {""} ;
         H00A92_A888CentroCostosDetallesSolId = new long[1] ;
         H00A92_A468CentroCostosDetallesValor = new decimal[1] ;
         H00A92_A461CentroCostosId = new long[1] ;
         H00A92_A473CentroCostosDetallesNombre = new string[] {""} ;
         H00A92_A459ListaCostosId = new long[1] ;
         H00A92_n459ListaCostosId = new bool[] {false} ;
         H00A92_A466CentroCostosDetallesId = new long[1] ;
         H00A93_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01y1__default(),
            new Object[][] {
                new Object[] {
               H00A92_A890CCDetallesProfId, H00A92_A888CentroCostosDetallesSolId, H00A92_A468CentroCostosDetallesValor, H00A92_A461CentroCostosId, H00A92_A473CentroCostosDetallesNombre, H00A92_A459ListaCostosId, H00A92_n459ListaCostosId, H00A92_A466CentroCostosDetallesId
               }
               , new Object[] {
               H00A93_AGRID1_nRecordCount
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCcentrocostosdetallesid_Enabled ;
      private int edtavCcentrocostosdetallesid_Visible ;
      private int edtavClistacostosid_Enabled ;
      private int edtavClistacostosid_Visible ;
      private int edtavCcentrocostosdetallesnombre_Visible ;
      private int edtavCcentrocostosdetallesnombre_Enabled ;
      private int edtavCcentrocostosdetallesvalor_Enabled ;
      private int edtavCcentrocostosdetallesvalor_Visible ;
      private int edtavCcentrocostosdetallessolid_Enabled ;
      private int edtavCcentrocostosdetallessolid_Visible ;
      private int edtavCccdetallesprofid_Visible ;
      private int edtavCccdetallesprofid_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCentroCostosDetallesId_Enabled ;
      private int edtListaCostosId_Enabled ;
      private int edtCentroCostosDetallesNombre_Enabled ;
      private int edtCentroCostosId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV10pCentroCostosId ;
      private long AV11pCentroCostosDetallesId ;
      private long wcpOAV10pCentroCostosId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cCentroCostosDetallesId ;
      private long AV7cListaCostosId ;
      private long AV14cCentroCostosDetallesSolId ;
      private long A466CentroCostosDetallesId ;
      private long A459ListaCostosId ;
      private long A461CentroCostosId ;
      private long GRID1_nCurrentRecord ;
      private long A888CentroCostosDetallesSolId ;
      private long GRID1_nRecordCount ;
      private decimal AV9cCentroCostosDetallesValor ;
      private decimal A468CentroCostosDetallesValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCentrocostosdetallesidfiltercontainer_Class ;
      private string divListacostosidfiltercontainer_Class ;
      private string divCentrocostosdetallesnombrefiltercontainer_Class ;
      private string divCentrocostosdetallesvalorfiltercontainer_Class ;
      private string divCentrocostosdetallessolidfiltercontainer_Class ;
      private string divCcdetallesprofidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV8cCentroCostosDetallesNombre ;
      private string AV15cCCDetallesProfId ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCentrocostosdetallesidfiltercontainer_Internalname ;
      private string lblLblcentrocostosdetallesidfilter_Internalname ;
      private string lblLblcentrocostosdetallesidfilter_Jsonclick ;
      private string edtavCcentrocostosdetallesid_Internalname ;
      private string TempTags ;
      private string edtavCcentrocostosdetallesid_Jsonclick ;
      private string divListacostosidfiltercontainer_Internalname ;
      private string lblLbllistacostosidfilter_Internalname ;
      private string lblLbllistacostosidfilter_Jsonclick ;
      private string edtavClistacostosid_Internalname ;
      private string edtavClistacostosid_Jsonclick ;
      private string divCentrocostosdetallesnombrefiltercontainer_Internalname ;
      private string lblLblcentrocostosdetallesnombrefilter_Internalname ;
      private string lblLblcentrocostosdetallesnombrefilter_Jsonclick ;
      private string edtavCcentrocostosdetallesnombre_Internalname ;
      private string edtavCcentrocostosdetallesnombre_Jsonclick ;
      private string divCentrocostosdetallesvalorfiltercontainer_Internalname ;
      private string lblLblcentrocostosdetallesvalorfilter_Internalname ;
      private string lblLblcentrocostosdetallesvalorfilter_Jsonclick ;
      private string edtavCcentrocostosdetallesvalor_Internalname ;
      private string edtavCcentrocostosdetallesvalor_Jsonclick ;
      private string divCentrocostosdetallessolidfiltercontainer_Internalname ;
      private string lblLblcentrocostosdetallessolidfilter_Internalname ;
      private string lblLblcentrocostosdetallessolidfilter_Jsonclick ;
      private string edtavCcentrocostosdetallessolid_Internalname ;
      private string edtavCcentrocostosdetallessolid_Jsonclick ;
      private string divCcdetallesprofidfiltercontainer_Internalname ;
      private string lblLblccdetallesprofidfilter_Internalname ;
      private string lblLblccdetallesprofidfilter_Jsonclick ;
      private string edtavCccdetallesprofid_Internalname ;
      private string edtavCccdetallesprofid_Jsonclick ;
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
      private string edtCentroCostosDetallesId_Internalname ;
      private string edtListaCostosId_Internalname ;
      private string A473CentroCostosDetallesNombre ;
      private string edtCentroCostosDetallesNombre_Internalname ;
      private string edtCentroCostosId_Internalname ;
      private string lV8cCentroCostosDetallesNombre ;
      private string lV15cCCDetallesProfId ;
      private string A890CCDetallesProfId ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCentroCostosDetallesId_Jsonclick ;
      private string edtListaCostosId_Jsonclick ;
      private string edtCentroCostosDetallesNombre_Jsonclick ;
      private string edtCentroCostosId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n459ListaCostosId ;
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
      private string[] H00A92_A890CCDetallesProfId ;
      private long[] H00A92_A888CentroCostosDetallesSolId ;
      private decimal[] H00A92_A468CentroCostosDetallesValor ;
      private long[] H00A92_A461CentroCostosId ;
      private string[] H00A92_A473CentroCostosDetallesNombre ;
      private long[] H00A92_A459ListaCostosId ;
      private bool[] H00A92_n459ListaCostosId ;
      private long[] H00A92_A466CentroCostosDetallesId ;
      private long[] H00A93_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pCentroCostosDetallesId ;
   }

   public class gx01y1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A92( IGxContext context ,
                                             long AV7cListaCostosId ,
                                             string AV8cCentroCostosDetallesNombre ,
                                             decimal AV9cCentroCostosDetallesValor ,
                                             long AV14cCentroCostosDetallesSolId ,
                                             string AV15cCCDetallesProfId ,
                                             long A459ListaCostosId ,
                                             string A473CentroCostosDetallesNombre ,
                                             decimal A468CentroCostosDetallesValor ,
                                             long A888CentroCostosDetallesSolId ,
                                             string A890CCDetallesProfId ,
                                             long AV10pCentroCostosId ,
                                             long AV6cCentroCostosDetallesId ,
                                             long A461CentroCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CCDetallesProfId], [CentroCostosDetallesSolId], [CentroCostosDetallesValor], [CentroCostosId], [CentroCostosDetallesNombre], [ListaCostosId], [CentroCostosDetallesId]";
         sFromString = " FROM [CentroCostosDetalles]";
         sOrderString = "";
         AddWhere(sWhereString, "([CentroCostosId] = @AV10pCentroCostosId and [CentroCostosDetallesId] >= @AV6cCentroCostosDetallesId)");
         if ( ! (0==AV7cListaCostosId) )
         {
            AddWhere(sWhereString, "([ListaCostosId] >= @AV7cListaCostosId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCentroCostosDetallesNombre)) )
         {
            AddWhere(sWhereString, "([CentroCostosDetallesNombre] like @lV8cCentroCostosDetallesNombre)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cCentroCostosDetallesValor) )
         {
            AddWhere(sWhereString, "([CentroCostosDetallesValor] >= @AV9cCentroCostosDetallesValor)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV14cCentroCostosDetallesSolId) )
         {
            AddWhere(sWhereString, "([CentroCostosDetallesSolId] >= @AV14cCentroCostosDetallesSolId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15cCCDetallesProfId)) )
         {
            AddWhere(sWhereString, "([CCDetallesProfId] like @lV15cCCDetallesProfId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [CentroCostosId], [CentroCostosDetallesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00A93( IGxContext context ,
                                             long AV7cListaCostosId ,
                                             string AV8cCentroCostosDetallesNombre ,
                                             decimal AV9cCentroCostosDetallesValor ,
                                             long AV14cCentroCostosDetallesSolId ,
                                             string AV15cCCDetallesProfId ,
                                             long A459ListaCostosId ,
                                             string A473CentroCostosDetallesNombre ,
                                             decimal A468CentroCostosDetallesValor ,
                                             long A888CentroCostosDetallesSolId ,
                                             string A890CCDetallesProfId ,
                                             long AV10pCentroCostosId ,
                                             long AV6cCentroCostosDetallesId ,
                                             long A461CentroCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CentroCostosDetalles]";
         AddWhere(sWhereString, "([CentroCostosId] = @AV10pCentroCostosId and [CentroCostosDetallesId] >= @AV6cCentroCostosDetallesId)");
         if ( ! (0==AV7cListaCostosId) )
         {
            AddWhere(sWhereString, "([ListaCostosId] >= @AV7cListaCostosId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCentroCostosDetallesNombre)) )
         {
            AddWhere(sWhereString, "([CentroCostosDetallesNombre] like @lV8cCentroCostosDetallesNombre)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cCentroCostosDetallesValor) )
         {
            AddWhere(sWhereString, "([CentroCostosDetallesValor] >= @AV9cCentroCostosDetallesValor)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV14cCentroCostosDetallesSolId) )
         {
            AddWhere(sWhereString, "([CentroCostosDetallesSolId] >= @AV14cCentroCostosDetallesSolId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15cCCDetallesProfId)) )
         {
            AddWhere(sWhereString, "([CCDetallesProfId] like @lV15cCCDetallesProfId)");
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
                     return conditional_H00A92(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00A93(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00A92;
          prmH00A92 = new Object[] {
          new ParDef("@AV10pCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cCentroCostosDetallesId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@lV8cCentroCostosDetallesNombre",GXType.NChar,80,0) ,
          new ParDef("@AV9cCentroCostosDetallesValor",GXType.Decimal,10,2) ,
          new ParDef("@AV14cCentroCostosDetallesSolId",GXType.Decimal,18,0) ,
          new ParDef("@lV15cCCDetallesProfId",GXType.Char,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A93;
          prmH00A93 = new Object[] {
          new ParDef("@AV10pCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cCentroCostosDetallesId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@lV8cCentroCostosDetallesNombre",GXType.NChar,80,0) ,
          new ParDef("@AV9cCentroCostosDetallesValor",GXType.Decimal,10,2) ,
          new ParDef("@AV14cCentroCostosDetallesSolId",GXType.Decimal,18,0) ,
          new ParDef("@lV15cCCDetallesProfId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A92,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A93", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A93,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx02m1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx02m1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx02m1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pOperacionesId ,
                           out long aP1_pOperacionesSolicitudesId )
      {
         this.AV12pOperacionesId = aP0_pOperacionesId;
         this.AV13pOperacionesSolicitudesId = 0 ;
         ExecutePrivate();
         aP1_pOperacionesSolicitudesId=this.AV13pOperacionesSolicitudesId;
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
            gxfirstwebparm = GetFirstPar( "pOperacionesId");
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
               gxfirstwebparm = GetFirstPar( "pOperacionesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pOperacionesId");
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
               AV12pOperacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pOperacionesId", StringUtil.LTrimStr( (decimal)(AV12pOperacionesId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pOperacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pOperacionesSolicitudesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pOperacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV13pOperacionesSolicitudesId), 18, 0));
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
         AV6cOperacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cOperacionesSolicitudesId"), "."), 18, MidpointRounding.ToEven));
         AV7cOperacionesSolicitudesComPro = NumberUtil.Val( GetPar( "cOperacionesSolicitudesComPro"), ".");
         AV8cOperacionesSolicitudesPFinal = NumberUtil.Val( GetPar( "cOperacionesSolicitudesPFinal"), ".");
         AV9cOperacionesSolicitudesComProv = NumberUtil.Val( GetPar( "cOperacionesSolicitudesComProv"), ".");
         AV10cOperacionesSolicitudesComALM = NumberUtil.Val( GetPar( "cOperacionesSolicitudesComALM"), ".");
         AV11cOperacionesSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( GetPar( "cOperacionesSolicitudesProvID"), "."), 18, MidpointRounding.ToEven));
         AV12pOperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pOperacionesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, AV12pOperacionesId) ;
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
         PAAV2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAV2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx02m1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pOperacionesId,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pOperacionesSolicitudesId,18,0))}, new string[] {"pOperacionesId","pOperacionesSolicitudesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCOPERACIONESSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cOperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCOPERACIONESSOLICITUDESCOMPRO", StringUtil.LTrim( StringUtil.NToC( AV7cOperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCOPERACIONESSOLICITUDESPFINAL", StringUtil.LTrim( StringUtil.NToC( AV8cOperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCOPERACIONESSOLICITUDESCOMPROV", StringUtil.LTrim( StringUtil.NToC( AV9cOperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCOPERACIONESSOLICITUDESCOMALM", StringUtil.LTrim( StringUtil.NToC( AV10cOperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCOPERACIONESSOLICITUDESPROVID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cOperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pOperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPOPERACIONESSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pOperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESIDFILTERCONTAINER_Class", StringUtil.RTrim( divOperacionessolicitudesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESCOMPROFILTERCONTAINER_Class", StringUtil.RTrim( divOperacionessolicitudescomprofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESPFINALFILTERCONTAINER_Class", StringUtil.RTrim( divOperacionessolicitudespfinalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESCOMPROVFILTERCONTAINER_Class", StringUtil.RTrim( divOperacionessolicitudescomprovfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESCOMALMFILTERCONTAINER_Class", StringUtil.RTrim( divOperacionessolicitudescomalmfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESPROVIDFILTERCONTAINER_Class", StringUtil.RTrim( divOperacionessolicitudesprovidfiltercontainer_Class));
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
            WEAV2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAV2( ) ;
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
         return formatLink("gx02m1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pOperacionesId,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pOperacionesSolicitudesId,18,0))}, new string[] {"pOperacionesId","pOperacionesSolicitudesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx02M1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Solicitudes", "") ;
      }

      protected void WBAV0( )
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
            GxWebStd.gx_div_start( context, divOperacionessolicitudesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOperacionessolicitudesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbloperacionessolicitudesidfilter_Internalname, context.GetMessage( "Solicitudes Id", ""), "", "", lblLbloperacionessolicitudesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11av1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02M1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCoperacionessolicitudesid_Internalname, context.GetMessage( "Solicitudes Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoperacionessolicitudesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cOperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCoperacionessolicitudesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cOperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cOperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoperacionessolicitudesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoperacionessolicitudesid_Visible, edtavCoperacionessolicitudesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02M1.htm");
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
            GxWebStd.gx_div_start( context, divOperacionessolicitudescomprofiltercontainer_Internalname, 1, 0, "px", 0, "px", divOperacionessolicitudescomprofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbloperacionessolicitudescomprofilter_Internalname, context.GetMessage( "Comisión del Proveedor", ""), "", "", lblLbloperacionessolicitudescomprofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12av1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02M1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCoperacionessolicitudescompro_Internalname, context.GetMessage( "Comisión del Proveedor", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoperacionessolicitudescompro_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7cOperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCoperacionessolicitudescompro_Enabled!=0) ? context.localUtil.Format( AV7cOperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV7cOperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoperacionessolicitudescompro_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoperacionessolicitudescompro_Visible, edtavCoperacionessolicitudescompro_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02M1.htm");
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
            GxWebStd.gx_div_start( context, divOperacionessolicitudespfinalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOperacionessolicitudespfinalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbloperacionessolicitudespfinalfilter_Internalname, context.GetMessage( "Precio Final", ""), "", "", lblLbloperacionessolicitudespfinalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13av1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02M1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCoperacionessolicitudespfinal_Internalname, context.GetMessage( "Precio Final", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoperacionessolicitudespfinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8cOperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCoperacionessolicitudespfinal_Enabled!=0) ? context.localUtil.Format( AV8cOperacionesSolicitudesPFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV8cOperacionesSolicitudesPFinal, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoperacionessolicitudespfinal_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoperacionessolicitudespfinal_Visible, edtavCoperacionessolicitudespfinal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02M1.htm");
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
            GxWebStd.gx_div_start( context, divOperacionessolicitudescomprovfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOperacionessolicitudescomprovfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbloperacionessolicitudescomprovfilter_Internalname, context.GetMessage( "Comisión del Comercio", ""), "", "", lblLbloperacionessolicitudescomprovfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14av1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02M1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCoperacionessolicitudescomprov_Internalname, context.GetMessage( "Comisión del Comercio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoperacionessolicitudescomprov_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cOperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCoperacionessolicitudescomprov_Enabled!=0) ? context.localUtil.Format( AV9cOperacionesSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV9cOperacionesSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoperacionessolicitudescomprov_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoperacionessolicitudescomprov_Visible, edtavCoperacionessolicitudescomprov_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02M1.htm");
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
            GxWebStd.gx_div_start( context, divOperacionessolicitudescomalmfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOperacionessolicitudescomalmfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbloperacionessolicitudescomalmfilter_Internalname, context.GetMessage( "Comisión del  Almango", ""), "", "", lblLbloperacionessolicitudescomalmfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15av1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02M1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCoperacionessolicitudescomalm_Internalname, context.GetMessage( "Comisión del  Almango", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoperacionessolicitudescomalm_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cOperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCoperacionessolicitudescomalm_Enabled!=0) ? context.localUtil.Format( AV10cOperacionesSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV10cOperacionesSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoperacionessolicitudescomalm_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoperacionessolicitudescomalm_Visible, edtavCoperacionessolicitudescomalm_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02M1.htm");
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
            GxWebStd.gx_div_start( context, divOperacionessolicitudesprovidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOperacionessolicitudesprovidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbloperacionessolicitudesprovidfilter_Internalname, context.GetMessage( "Comercio ID", ""), "", "", lblLbloperacionessolicitudesprovidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16av1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02M1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCoperacionessolicitudesprovid_Internalname, context.GetMessage( "Comercio ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoperacionessolicitudesprovid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cOperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCoperacionessolicitudesprovid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cOperacionesSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cOperacionesSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoperacionessolicitudesprovid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoperacionessolicitudesprovid_Visible, edtavCoperacionessolicitudesprovid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02M1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17av1_client"+"'", TempTags, "", 2, "HLP_Gx02M1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx02M1.htm");
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

      protected void STARTAV2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAV0( ) ;
      }

      protected void WSAV2( )
      {
         STARTAV2( ) ;
         EVTAV2( ) ;
      }

      protected void EVTAV2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A650OperacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A653OperacionesSolicitudesComPro = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n653OperacionesSolicitudesComPro = false;
                              A654OperacionesSolicitudesPFinal = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n654OperacionesSolicitudesPFinal = false;
                              A655OperacionesSolicitudesComProv = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n655OperacionesSolicitudesComProv = false;
                              A656OperacionesSolicitudesComALM = context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n656OperacionesSolicitudesComALM = false;
                              A660OperacionesSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesSolicitudesProvID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n660OperacionesSolicitudesProvID = false;
                              A554OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18AV2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19AV2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Coperacionessolicitudesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cOperacionesSolicitudesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Coperacionessolicitudescompro Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESCOMPRO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV7cOperacionesSolicitudesComPro )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Coperacionessolicitudespfinal Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESPFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV8cOperacionesSolicitudesPFinal )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Coperacionessolicitudescomprov Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESCOMPROV"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cOperacionesSolicitudesComProv )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Coperacionessolicitudescomalm Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESCOMALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cOperacionesSolicitudesComALM )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Coperacionessolicitudesprovid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESPROVID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cOperacionesSolicitudesProvID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20AV2 ();
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

      protected void WEAV2( )
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

      protected void PAAV2( )
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
                                        long AV6cOperacionesSolicitudesId ,
                                        decimal AV7cOperacionesSolicitudesComPro ,
                                        decimal AV8cOperacionesSolicitudesPFinal ,
                                        decimal AV9cOperacionesSolicitudesComProv ,
                                        decimal AV10cOperacionesSolicitudesComALM ,
                                        long AV11cOperacionesSolicitudesProvID ,
                                        long AV12pOperacionesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFAV2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "OPERACIONESSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, ".", "")));
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
         RFAV2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAV2( )
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
                                                 AV7cOperacionesSolicitudesComPro ,
                                                 AV8cOperacionesSolicitudesPFinal ,
                                                 AV9cOperacionesSolicitudesComProv ,
                                                 AV10cOperacionesSolicitudesComALM ,
                                                 AV11cOperacionesSolicitudesProvID ,
                                                 A653OperacionesSolicitudesComPro ,
                                                 A654OperacionesSolicitudesPFinal ,
                                                 A655OperacionesSolicitudesComProv ,
                                                 A656OperacionesSolicitudesComALM ,
                                                 A660OperacionesSolicitudesProvID ,
                                                 AV12pOperacionesId ,
                                                 AV6cOperacionesSolicitudesId ,
                                                 A554OperacionesId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H00AV2 */
            pr_default.execute(0, new Object[] {AV12pOperacionesId, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A554OperacionesId = H00AV2_A554OperacionesId[0];
               A660OperacionesSolicitudesProvID = H00AV2_A660OperacionesSolicitudesProvID[0];
               n660OperacionesSolicitudesProvID = H00AV2_n660OperacionesSolicitudesProvID[0];
               A656OperacionesSolicitudesComALM = H00AV2_A656OperacionesSolicitudesComALM[0];
               n656OperacionesSolicitudesComALM = H00AV2_n656OperacionesSolicitudesComALM[0];
               A655OperacionesSolicitudesComProv = H00AV2_A655OperacionesSolicitudesComProv[0];
               n655OperacionesSolicitudesComProv = H00AV2_n655OperacionesSolicitudesComProv[0];
               A654OperacionesSolicitudesPFinal = H00AV2_A654OperacionesSolicitudesPFinal[0];
               n654OperacionesSolicitudesPFinal = H00AV2_n654OperacionesSolicitudesPFinal[0];
               A653OperacionesSolicitudesComPro = H00AV2_A653OperacionesSolicitudesComPro[0];
               n653OperacionesSolicitudesComPro = H00AV2_n653OperacionesSolicitudesComPro[0];
               A650OperacionesSolicitudesId = H00AV2_A650OperacionesSolicitudesId[0];
               /* Execute user event: Load */
               E19AV2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBAV0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesAV2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESSOLICITUDESID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cOperacionesSolicitudesComPro ,
                                              AV8cOperacionesSolicitudesPFinal ,
                                              AV9cOperacionesSolicitudesComProv ,
                                              AV10cOperacionesSolicitudesComALM ,
                                              AV11cOperacionesSolicitudesProvID ,
                                              A653OperacionesSolicitudesComPro ,
                                              A654OperacionesSolicitudesPFinal ,
                                              A655OperacionesSolicitudesComProv ,
                                              A656OperacionesSolicitudesComALM ,
                                              A660OperacionesSolicitudesProvID ,
                                              AV12pOperacionesId ,
                                              AV6cOperacionesSolicitudesId ,
                                              A554OperacionesId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00AV3 */
         pr_default.execute(1, new Object[] {AV12pOperacionesId, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID});
         GRID1_nRecordCount = H00AV3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, AV12pOperacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, AV12pOperacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, AV12pOperacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, AV12pOperacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOperacionesSolicitudesId, AV7cOperacionesSolicitudesComPro, AV8cOperacionesSolicitudesPFinal, AV9cOperacionesSolicitudesComProv, AV10cOperacionesSolicitudesComALM, AV11cOperacionesSolicitudesProvID, AV12pOperacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtOperacionesSolicitudesId_Enabled = 0;
         edtOperacionesSolicitudesComPro_Enabled = 0;
         edtOperacionesSolicitudesPFinal_Enabled = 0;
         edtOperacionesSolicitudesComProv_Enabled = 0;
         edtOperacionesSolicitudesComALM_Enabled = 0;
         edtOperacionesSolicitudesProvID_Enabled = 0;
         edtOperacionesId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAV0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18AV2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPERACIONESSOLICITUDESID");
               GX_FocusControl = edtavCoperacionessolicitudesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cOperacionesSolicitudesId = 0;
               AssignAttri("", false, "AV6cOperacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV6cOperacionesSolicitudesId), 18, 0));
            }
            else
            {
               AV6cOperacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cOperacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV6cOperacionesSolicitudesId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescompro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescompro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPERACIONESSOLICITUDESCOMPRO");
               GX_FocusControl = edtavCoperacionessolicitudescompro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cOperacionesSolicitudesComPro = 0;
               AssignAttri("", false, "AV7cOperacionesSolicitudesComPro", StringUtil.LTrimStr( AV7cOperacionesSolicitudesComPro, 18, 2));
            }
            else
            {
               AV7cOperacionesSolicitudesComPro = context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescompro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV7cOperacionesSolicitudesComPro", StringUtil.LTrimStr( AV7cOperacionesSolicitudesComPro, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudespfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudespfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPERACIONESSOLICITUDESPFINAL");
               GX_FocusControl = edtavCoperacionessolicitudespfinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cOperacionesSolicitudesPFinal = 0;
               AssignAttri("", false, "AV8cOperacionesSolicitudesPFinal", StringUtil.LTrimStr( AV8cOperacionesSolicitudesPFinal, 18, 2));
            }
            else
            {
               AV8cOperacionesSolicitudesPFinal = context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudespfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV8cOperacionesSolicitudesPFinal", StringUtil.LTrimStr( AV8cOperacionesSolicitudesPFinal, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescomprov_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescomprov_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPERACIONESSOLICITUDESCOMPROV");
               GX_FocusControl = edtavCoperacionessolicitudescomprov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cOperacionesSolicitudesComProv = 0;
               AssignAttri("", false, "AV9cOperacionesSolicitudesComProv", StringUtil.LTrimStr( AV9cOperacionesSolicitudesComProv, 18, 2));
            }
            else
            {
               AV9cOperacionesSolicitudesComProv = context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescomprov_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV9cOperacionesSolicitudesComProv", StringUtil.LTrimStr( AV9cOperacionesSolicitudesComProv, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPERACIONESSOLICITUDESCOMALM");
               GX_FocusControl = edtavCoperacionessolicitudescomalm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cOperacionesSolicitudesComALM = 0;
               AssignAttri("", false, "AV10cOperacionesSolicitudesComALM", StringUtil.LTrimStr( AV10cOperacionesSolicitudesComALM, 18, 2));
            }
            else
            {
               AV10cOperacionesSolicitudesComALM = context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudescomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10cOperacionesSolicitudesComALM", StringUtil.LTrimStr( AV10cOperacionesSolicitudesComALM, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudesprovid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudesprovid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPERACIONESSOLICITUDESPROVID");
               GX_FocusControl = edtavCoperacionessolicitudesprovid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cOperacionesSolicitudesProvID = 0;
               AssignAttri("", false, "AV11cOperacionesSolicitudesProvID", StringUtil.LTrimStr( (decimal)(AV11cOperacionesSolicitudesProvID), 18, 0));
            }
            else
            {
               AV11cOperacionesSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCoperacionessolicitudesprovid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cOperacionesSolicitudesProvID", StringUtil.LTrimStr( (decimal)(AV11cOperacionesSolicitudesProvID), 18, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cOperacionesSolicitudesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESCOMPRO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV7cOperacionesSolicitudesComPro )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESPFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV8cOperacionesSolicitudesPFinal )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESCOMPROV"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cOperacionesSolicitudesComProv )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESCOMALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cOperacionesSolicitudesComALM )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOPERACIONESSOLICITUDESPROVID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cOperacionesSolicitudesProvID )) )
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
         E18AV2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18AV2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Solicitudes", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19AV2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E20AV2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20AV2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pOperacionesSolicitudesId = A650OperacionesSolicitudesId;
         AssignAttri("", false, "AV13pOperacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV13pOperacionesSolicitudesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pOperacionesSolicitudesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pOperacionesSolicitudesId"});
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
         AV12pOperacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pOperacionesId", StringUtil.LTrimStr( (decimal)(AV12pOperacionesId), 18, 0));
         AV13pOperacionesSolicitudesId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pOperacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(AV13pOperacionesSolicitudesId), 18, 0));
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
         PAAV2( ) ;
         WSAV2( ) ;
         WEAV2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821402293", true, true, false);
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
         context.AddJavascriptSource("gx02m1.js", "?202692821402293", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtOperacionesSolicitudesId_Internalname = "OPERACIONESSOLICITUDESID_"+sGXsfl_74_idx;
         edtOperacionesSolicitudesComPro_Internalname = "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_74_idx;
         edtOperacionesSolicitudesPFinal_Internalname = "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_74_idx;
         edtOperacionesSolicitudesComProv_Internalname = "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_74_idx;
         edtOperacionesSolicitudesComALM_Internalname = "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_74_idx;
         edtOperacionesSolicitudesProvID_Internalname = "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_74_idx;
         edtOperacionesId_Internalname = "OPERACIONESID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtOperacionesSolicitudesId_Internalname = "OPERACIONESSOLICITUDESID_"+sGXsfl_74_fel_idx;
         edtOperacionesSolicitudesComPro_Internalname = "OPERACIONESSOLICITUDESCOMPRO_"+sGXsfl_74_fel_idx;
         edtOperacionesSolicitudesPFinal_Internalname = "OPERACIONESSOLICITUDESPFINAL_"+sGXsfl_74_fel_idx;
         edtOperacionesSolicitudesComProv_Internalname = "OPERACIONESSOLICITUDESCOMPROV_"+sGXsfl_74_fel_idx;
         edtOperacionesSolicitudesComALM_Internalname = "OPERACIONESSOLICITUDESCOMALM_"+sGXsfl_74_fel_idx;
         edtOperacionesSolicitudesProvID_Internalname = "OPERACIONESSOLICITUDESPROVID_"+sGXsfl_74_fel_idx;
         edtOperacionesId_Internalname = "OPERACIONESID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBAV0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesComPro_Internalname,StringUtil.LTrim( StringUtil.NToC( A653OperacionesSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A653OperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesComPro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesPFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A654OperacionesSolicitudesPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A654OperacionesSolicitudesPFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesPFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesComProv_Internalname,StringUtil.LTrim( StringUtil.NToC( A655OperacionesSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A655OperacionesSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesComProv_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesComALM_Internalname,StringUtil.LTrim( StringUtil.NToC( A656OperacionesSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A656OperacionesSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesComALM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesSolicitudesProvID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A660OperacionesSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A660OperacionesSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesSolicitudesProvID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesAV2( ) ;
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
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión del Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión del Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión del  Almango", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Operaciones Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A650OperacionesSolicitudesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A653OperacionesSolicitudesComPro, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A654OperacionesSolicitudesPFinal, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A655OperacionesSolicitudesComProv, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A656OperacionesSolicitudesComALM, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A660OperacionesSolicitudesProvID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, ".", ""))));
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
         lblLbloperacionessolicitudesidfilter_Internalname = "LBLOPERACIONESSOLICITUDESIDFILTER";
         edtavCoperacionessolicitudesid_Internalname = "vCOPERACIONESSOLICITUDESID";
         divOperacionessolicitudesidfiltercontainer_Internalname = "OPERACIONESSOLICITUDESIDFILTERCONTAINER";
         lblLbloperacionessolicitudescomprofilter_Internalname = "LBLOPERACIONESSOLICITUDESCOMPROFILTER";
         edtavCoperacionessolicitudescompro_Internalname = "vCOPERACIONESSOLICITUDESCOMPRO";
         divOperacionessolicitudescomprofiltercontainer_Internalname = "OPERACIONESSOLICITUDESCOMPROFILTERCONTAINER";
         lblLbloperacionessolicitudespfinalfilter_Internalname = "LBLOPERACIONESSOLICITUDESPFINALFILTER";
         edtavCoperacionessolicitudespfinal_Internalname = "vCOPERACIONESSOLICITUDESPFINAL";
         divOperacionessolicitudespfinalfiltercontainer_Internalname = "OPERACIONESSOLICITUDESPFINALFILTERCONTAINER";
         lblLbloperacionessolicitudescomprovfilter_Internalname = "LBLOPERACIONESSOLICITUDESCOMPROVFILTER";
         edtavCoperacionessolicitudescomprov_Internalname = "vCOPERACIONESSOLICITUDESCOMPROV";
         divOperacionessolicitudescomprovfiltercontainer_Internalname = "OPERACIONESSOLICITUDESCOMPROVFILTERCONTAINER";
         lblLbloperacionessolicitudescomalmfilter_Internalname = "LBLOPERACIONESSOLICITUDESCOMALMFILTER";
         edtavCoperacionessolicitudescomalm_Internalname = "vCOPERACIONESSOLICITUDESCOMALM";
         divOperacionessolicitudescomalmfiltercontainer_Internalname = "OPERACIONESSOLICITUDESCOMALMFILTERCONTAINER";
         lblLbloperacionessolicitudesprovidfilter_Internalname = "LBLOPERACIONESSOLICITUDESPROVIDFILTER";
         edtavCoperacionessolicitudesprovid_Internalname = "vCOPERACIONESSOLICITUDESPROVID";
         divOperacionessolicitudesprovidfiltercontainer_Internalname = "OPERACIONESSOLICITUDESPROVIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtOperacionesSolicitudesId_Internalname = "OPERACIONESSOLICITUDESID";
         edtOperacionesSolicitudesComPro_Internalname = "OPERACIONESSOLICITUDESCOMPRO";
         edtOperacionesSolicitudesPFinal_Internalname = "OPERACIONESSOLICITUDESPFINAL";
         edtOperacionesSolicitudesComProv_Internalname = "OPERACIONESSOLICITUDESCOMPROV";
         edtOperacionesSolicitudesComALM_Internalname = "OPERACIONESSOLICITUDESCOMALM";
         edtOperacionesSolicitudesProvID_Internalname = "OPERACIONESSOLICITUDESPROVID";
         edtOperacionesId_Internalname = "OPERACIONESID";
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
         edtOperacionesId_Jsonclick = "";
         edtOperacionesSolicitudesProvID_Jsonclick = "";
         edtOperacionesSolicitudesComALM_Jsonclick = "";
         edtOperacionesSolicitudesComProv_Jsonclick = "";
         edtOperacionesSolicitudesPFinal_Jsonclick = "";
         edtOperacionesSolicitudesComPro_Jsonclick = "";
         edtOperacionesSolicitudesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtOperacionesId_Enabled = 0;
         edtOperacionesSolicitudesProvID_Enabled = 0;
         edtOperacionesSolicitudesComALM_Enabled = 0;
         edtOperacionesSolicitudesComProv_Enabled = 0;
         edtOperacionesSolicitudesPFinal_Enabled = 0;
         edtOperacionesSolicitudesComPro_Enabled = 0;
         edtOperacionesSolicitudesId_Enabled = 0;
         edtavCoperacionessolicitudesprovid_Jsonclick = "";
         edtavCoperacionessolicitudesprovid_Enabled = 1;
         edtavCoperacionessolicitudesprovid_Visible = 1;
         edtavCoperacionessolicitudescomalm_Jsonclick = "";
         edtavCoperacionessolicitudescomalm_Enabled = 1;
         edtavCoperacionessolicitudescomalm_Visible = 1;
         edtavCoperacionessolicitudescomprov_Jsonclick = "";
         edtavCoperacionessolicitudescomprov_Enabled = 1;
         edtavCoperacionessolicitudescomprov_Visible = 1;
         edtavCoperacionessolicitudespfinal_Jsonclick = "";
         edtavCoperacionessolicitudespfinal_Enabled = 1;
         edtavCoperacionessolicitudespfinal_Visible = 1;
         edtavCoperacionessolicitudescompro_Jsonclick = "";
         edtavCoperacionessolicitudescompro_Enabled = 1;
         edtavCoperacionessolicitudescompro_Visible = 1;
         edtavCoperacionessolicitudesid_Jsonclick = "";
         edtavCoperacionessolicitudesid_Enabled = 1;
         edtavCoperacionessolicitudesid_Visible = 1;
         divOperacionessolicitudesprovidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOperacionessolicitudescomalmfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOperacionessolicitudescomprovfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOperacionessolicitudespfinalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOperacionessolicitudescomprofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divOperacionessolicitudesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Solicitudes", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOperacionesSolicitudesId',fld:'vCOPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cOperacionesSolicitudesComPro',fld:'vCOPERACIONESSOLICITUDESCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV8cOperacionesSolicitudesPFinal',fld:'vCOPERACIONESSOLICITUDESPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cOperacionesSolicitudesComProv',fld:'vCOPERACIONESSOLICITUDESCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cOperacionesSolicitudesComALM',fld:'vCOPERACIONESSOLICITUDESCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cOperacionesSolicitudesProvID',fld:'vCOPERACIONESSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12pOperacionesId',fld:'vPOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17AV1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLOPERACIONESSOLICITUDESIDFILTER.CLICK","{handler:'E11AV1',iparms:[{av:'divOperacionessolicitudesidfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOPERACIONESSOLICITUDESIDFILTER.CLICK",",oparms:[{av:'divOperacionessolicitudesidfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCoperacionessolicitudesid_Visible',ctrl:'vCOPERACIONESSOLICITUDESID',prop:'Visible'}]}");
         setEventMetadata("LBLOPERACIONESSOLICITUDESCOMPROFILTER.CLICK","{handler:'E12AV1',iparms:[{av:'divOperacionessolicitudescomprofiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESCOMPROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOPERACIONESSOLICITUDESCOMPROFILTER.CLICK",",oparms:[{av:'divOperacionessolicitudescomprofiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESCOMPROFILTERCONTAINER',prop:'Class'},{av:'edtavCoperacionessolicitudescompro_Visible',ctrl:'vCOPERACIONESSOLICITUDESCOMPRO',prop:'Visible'}]}");
         setEventMetadata("LBLOPERACIONESSOLICITUDESPFINALFILTER.CLICK","{handler:'E13AV1',iparms:[{av:'divOperacionessolicitudespfinalfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESPFINALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOPERACIONESSOLICITUDESPFINALFILTER.CLICK",",oparms:[{av:'divOperacionessolicitudespfinalfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESPFINALFILTERCONTAINER',prop:'Class'},{av:'edtavCoperacionessolicitudespfinal_Visible',ctrl:'vCOPERACIONESSOLICITUDESPFINAL',prop:'Visible'}]}");
         setEventMetadata("LBLOPERACIONESSOLICITUDESCOMPROVFILTER.CLICK","{handler:'E14AV1',iparms:[{av:'divOperacionessolicitudescomprovfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESCOMPROVFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOPERACIONESSOLICITUDESCOMPROVFILTER.CLICK",",oparms:[{av:'divOperacionessolicitudescomprovfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESCOMPROVFILTERCONTAINER',prop:'Class'},{av:'edtavCoperacionessolicitudescomprov_Visible',ctrl:'vCOPERACIONESSOLICITUDESCOMPROV',prop:'Visible'}]}");
         setEventMetadata("LBLOPERACIONESSOLICITUDESCOMALMFILTER.CLICK","{handler:'E15AV1',iparms:[{av:'divOperacionessolicitudescomalmfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESCOMALMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOPERACIONESSOLICITUDESCOMALMFILTER.CLICK",",oparms:[{av:'divOperacionessolicitudescomalmfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESCOMALMFILTERCONTAINER',prop:'Class'},{av:'edtavCoperacionessolicitudescomalm_Visible',ctrl:'vCOPERACIONESSOLICITUDESCOMALM',prop:'Visible'}]}");
         setEventMetadata("LBLOPERACIONESSOLICITUDESPROVIDFILTER.CLICK","{handler:'E16AV1',iparms:[{av:'divOperacionessolicitudesprovidfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESPROVIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOPERACIONESSOLICITUDESPROVIDFILTER.CLICK",",oparms:[{av:'divOperacionessolicitudesprovidfiltercontainer_Class',ctrl:'OPERACIONESSOLICITUDESPROVIDFILTERCONTAINER',prop:'Class'},{av:'edtavCoperacionessolicitudesprovid_Visible',ctrl:'vCOPERACIONESSOLICITUDESPROVID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20AV2',iparms:[{av:'A650OperacionesSolicitudesId',fld:'OPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pOperacionesSolicitudesId',fld:'vPOPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOperacionesSolicitudesId',fld:'vCOPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cOperacionesSolicitudesComPro',fld:'vCOPERACIONESSOLICITUDESCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV8cOperacionesSolicitudesPFinal',fld:'vCOPERACIONESSOLICITUDESPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cOperacionesSolicitudesComProv',fld:'vCOPERACIONESSOLICITUDESCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cOperacionesSolicitudesComALM',fld:'vCOPERACIONESSOLICITUDESCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cOperacionesSolicitudesProvID',fld:'vCOPERACIONESSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12pOperacionesId',fld:'vPOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOperacionesSolicitudesId',fld:'vCOPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cOperacionesSolicitudesComPro',fld:'vCOPERACIONESSOLICITUDESCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV8cOperacionesSolicitudesPFinal',fld:'vCOPERACIONESSOLICITUDESPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cOperacionesSolicitudesComProv',fld:'vCOPERACIONESSOLICITUDESCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cOperacionesSolicitudesComALM',fld:'vCOPERACIONESSOLICITUDESCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cOperacionesSolicitudesProvID',fld:'vCOPERACIONESSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12pOperacionesId',fld:'vPOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOperacionesSolicitudesId',fld:'vCOPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cOperacionesSolicitudesComPro',fld:'vCOPERACIONESSOLICITUDESCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV8cOperacionesSolicitudesPFinal',fld:'vCOPERACIONESSOLICITUDESPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cOperacionesSolicitudesComProv',fld:'vCOPERACIONESSOLICITUDESCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cOperacionesSolicitudesComALM',fld:'vCOPERACIONESSOLICITUDESCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cOperacionesSolicitudesProvID',fld:'vCOPERACIONESSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12pOperacionesId',fld:'vPOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOperacionesSolicitudesId',fld:'vCOPERACIONESSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cOperacionesSolicitudesComPro',fld:'vCOPERACIONESSOLICITUDESCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV8cOperacionesSolicitudesPFinal',fld:'vCOPERACIONESSOLICITUDESPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cOperacionesSolicitudesComProv',fld:'vCOPERACIONESSOLICITUDESCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cOperacionesSolicitudesComALM',fld:'vCOPERACIONESSOLICITUDESCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cOperacionesSolicitudesProvID',fld:'vCOPERACIONESSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12pOperacionesId',fld:'vPOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Operacionesid',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbloperacionessolicitudesidfilter_Jsonclick = "";
         TempTags = "";
         lblLbloperacionessolicitudescomprofilter_Jsonclick = "";
         lblLbloperacionessolicitudespfinalfilter_Jsonclick = "";
         lblLbloperacionessolicitudescomprovfilter_Jsonclick = "";
         lblLbloperacionessolicitudescomalmfilter_Jsonclick = "";
         lblLbloperacionessolicitudesprovidfilter_Jsonclick = "";
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
         H00AV2_A554OperacionesId = new long[1] ;
         H00AV2_A660OperacionesSolicitudesProvID = new long[1] ;
         H00AV2_n660OperacionesSolicitudesProvID = new bool[] {false} ;
         H00AV2_A656OperacionesSolicitudesComALM = new decimal[1] ;
         H00AV2_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         H00AV2_A655OperacionesSolicitudesComProv = new decimal[1] ;
         H00AV2_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         H00AV2_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         H00AV2_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         H00AV2_A653OperacionesSolicitudesComPro = new decimal[1] ;
         H00AV2_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         H00AV2_A650OperacionesSolicitudesId = new long[1] ;
         H00AV3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx02m1__default(),
            new Object[][] {
                new Object[] {
               H00AV2_A554OperacionesId, H00AV2_A660OperacionesSolicitudesProvID, H00AV2_n660OperacionesSolicitudesProvID, H00AV2_A656OperacionesSolicitudesComALM, H00AV2_n656OperacionesSolicitudesComALM, H00AV2_A655OperacionesSolicitudesComProv, H00AV2_n655OperacionesSolicitudesComProv, H00AV2_A654OperacionesSolicitudesPFinal, H00AV2_n654OperacionesSolicitudesPFinal, H00AV2_A653OperacionesSolicitudesComPro,
               H00AV2_n653OperacionesSolicitudesComPro, H00AV2_A650OperacionesSolicitudesId
               }
               , new Object[] {
               H00AV3_AGRID1_nRecordCount
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
      private int edtavCoperacionessolicitudesid_Enabled ;
      private int edtavCoperacionessolicitudesid_Visible ;
      private int edtavCoperacionessolicitudescompro_Enabled ;
      private int edtavCoperacionessolicitudescompro_Visible ;
      private int edtavCoperacionessolicitudespfinal_Enabled ;
      private int edtavCoperacionessolicitudespfinal_Visible ;
      private int edtavCoperacionessolicitudescomprov_Enabled ;
      private int edtavCoperacionessolicitudescomprov_Visible ;
      private int edtavCoperacionessolicitudescomalm_Enabled ;
      private int edtavCoperacionessolicitudescomalm_Visible ;
      private int edtavCoperacionessolicitudesprovid_Enabled ;
      private int edtavCoperacionessolicitudesprovid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtOperacionesSolicitudesId_Enabled ;
      private int edtOperacionesSolicitudesComPro_Enabled ;
      private int edtOperacionesSolicitudesPFinal_Enabled ;
      private int edtOperacionesSolicitudesComProv_Enabled ;
      private int edtOperacionesSolicitudesComALM_Enabled ;
      private int edtOperacionesSolicitudesProvID_Enabled ;
      private int edtOperacionesId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pOperacionesId ;
      private long AV13pOperacionesSolicitudesId ;
      private long wcpOAV12pOperacionesId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cOperacionesSolicitudesId ;
      private long AV11cOperacionesSolicitudesProvID ;
      private long A650OperacionesSolicitudesId ;
      private long A660OperacionesSolicitudesProvID ;
      private long A554OperacionesId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV7cOperacionesSolicitudesComPro ;
      private decimal AV8cOperacionesSolicitudesPFinal ;
      private decimal AV9cOperacionesSolicitudesComProv ;
      private decimal AV10cOperacionesSolicitudesComALM ;
      private decimal A653OperacionesSolicitudesComPro ;
      private decimal A654OperacionesSolicitudesPFinal ;
      private decimal A655OperacionesSolicitudesComProv ;
      private decimal A656OperacionesSolicitudesComALM ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divOperacionessolicitudesidfiltercontainer_Class ;
      private string divOperacionessolicitudescomprofiltercontainer_Class ;
      private string divOperacionessolicitudespfinalfiltercontainer_Class ;
      private string divOperacionessolicitudescomprovfiltercontainer_Class ;
      private string divOperacionessolicitudescomalmfiltercontainer_Class ;
      private string divOperacionessolicitudesprovidfiltercontainer_Class ;
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
      private string divOperacionessolicitudesidfiltercontainer_Internalname ;
      private string lblLbloperacionessolicitudesidfilter_Internalname ;
      private string lblLbloperacionessolicitudesidfilter_Jsonclick ;
      private string edtavCoperacionessolicitudesid_Internalname ;
      private string TempTags ;
      private string edtavCoperacionessolicitudesid_Jsonclick ;
      private string divOperacionessolicitudescomprofiltercontainer_Internalname ;
      private string lblLbloperacionessolicitudescomprofilter_Internalname ;
      private string lblLbloperacionessolicitudescomprofilter_Jsonclick ;
      private string edtavCoperacionessolicitudescompro_Internalname ;
      private string edtavCoperacionessolicitudescompro_Jsonclick ;
      private string divOperacionessolicitudespfinalfiltercontainer_Internalname ;
      private string lblLbloperacionessolicitudespfinalfilter_Internalname ;
      private string lblLbloperacionessolicitudespfinalfilter_Jsonclick ;
      private string edtavCoperacionessolicitudespfinal_Internalname ;
      private string edtavCoperacionessolicitudespfinal_Jsonclick ;
      private string divOperacionessolicitudescomprovfiltercontainer_Internalname ;
      private string lblLbloperacionessolicitudescomprovfilter_Internalname ;
      private string lblLbloperacionessolicitudescomprovfilter_Jsonclick ;
      private string edtavCoperacionessolicitudescomprov_Internalname ;
      private string edtavCoperacionessolicitudescomprov_Jsonclick ;
      private string divOperacionessolicitudescomalmfiltercontainer_Internalname ;
      private string lblLbloperacionessolicitudescomalmfilter_Internalname ;
      private string lblLbloperacionessolicitudescomalmfilter_Jsonclick ;
      private string edtavCoperacionessolicitudescomalm_Internalname ;
      private string edtavCoperacionessolicitudescomalm_Jsonclick ;
      private string divOperacionessolicitudesprovidfiltercontainer_Internalname ;
      private string lblLbloperacionessolicitudesprovidfilter_Internalname ;
      private string lblLbloperacionessolicitudesprovidfilter_Jsonclick ;
      private string edtavCoperacionessolicitudesprovid_Internalname ;
      private string edtavCoperacionessolicitudesprovid_Jsonclick ;
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
      private string edtOperacionesSolicitudesId_Internalname ;
      private string edtOperacionesSolicitudesComPro_Internalname ;
      private string edtOperacionesSolicitudesPFinal_Internalname ;
      private string edtOperacionesSolicitudesComProv_Internalname ;
      private string edtOperacionesSolicitudesComALM_Internalname ;
      private string edtOperacionesSolicitudesProvID_Internalname ;
      private string edtOperacionesId_Internalname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtOperacionesSolicitudesId_Jsonclick ;
      private string edtOperacionesSolicitudesComPro_Jsonclick ;
      private string edtOperacionesSolicitudesPFinal_Jsonclick ;
      private string edtOperacionesSolicitudesComProv_Jsonclick ;
      private string edtOperacionesSolicitudesComALM_Jsonclick ;
      private string edtOperacionesSolicitudesProvID_Jsonclick ;
      private string edtOperacionesId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n653OperacionesSolicitudesComPro ;
      private bool n654OperacionesSolicitudesPFinal ;
      private bool n655OperacionesSolicitudesComProv ;
      private bool n656OperacionesSolicitudesComALM ;
      private bool n660OperacionesSolicitudesProvID ;
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
      private long[] H00AV2_A554OperacionesId ;
      private long[] H00AV2_A660OperacionesSolicitudesProvID ;
      private bool[] H00AV2_n660OperacionesSolicitudesProvID ;
      private decimal[] H00AV2_A656OperacionesSolicitudesComALM ;
      private bool[] H00AV2_n656OperacionesSolicitudesComALM ;
      private decimal[] H00AV2_A655OperacionesSolicitudesComProv ;
      private bool[] H00AV2_n655OperacionesSolicitudesComProv ;
      private decimal[] H00AV2_A654OperacionesSolicitudesPFinal ;
      private bool[] H00AV2_n654OperacionesSolicitudesPFinal ;
      private decimal[] H00AV2_A653OperacionesSolicitudesComPro ;
      private bool[] H00AV2_n653OperacionesSolicitudesComPro ;
      private long[] H00AV2_A650OperacionesSolicitudesId ;
      private long[] H00AV3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pOperacionesSolicitudesId ;
   }

   public class gx02m1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00AV2( IGxContext context ,
                                             decimal AV7cOperacionesSolicitudesComPro ,
                                             decimal AV8cOperacionesSolicitudesPFinal ,
                                             decimal AV9cOperacionesSolicitudesComProv ,
                                             decimal AV10cOperacionesSolicitudesComALM ,
                                             long AV11cOperacionesSolicitudesProvID ,
                                             decimal A653OperacionesSolicitudesComPro ,
                                             decimal A654OperacionesSolicitudesPFinal ,
                                             decimal A655OperacionesSolicitudesComProv ,
                                             decimal A656OperacionesSolicitudesComALM ,
                                             long A660OperacionesSolicitudesProvID ,
                                             long AV12pOperacionesId ,
                                             long AV6cOperacionesSolicitudesId ,
                                             long A554OperacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [OperacionesId], [OperacionesSolicitudesProvID], [OperacionesSolicitudesComALM], [OperacionesSolicitudesComProv], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComPro], [OperacionesSolicitudesId]";
         sFromString = " FROM [OperacionesSolicitudes]";
         sOrderString = "";
         AddWhere(sWhereString, "([OperacionesId] = @AV12pOperacionesId and [OperacionesSolicitudesId] >= @AV6cOperacionesSolicitudesId)");
         if ( ! (Convert.ToDecimal(0)==AV7cOperacionesSolicitudesComPro) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesComPro] >= @AV7cOperacionesSolicitudesComPro)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cOperacionesSolicitudesPFinal) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesPFinal] >= @AV8cOperacionesSolicitudesPFinal)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cOperacionesSolicitudesComProv) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesComProv] >= @AV9cOperacionesSolicitudesComProv)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cOperacionesSolicitudesComALM) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesComALM] >= @AV10cOperacionesSolicitudesComALM)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV11cOperacionesSolicitudesProvID) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesProvID] >= @AV11cOperacionesSolicitudesProvID)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [OperacionesId], [OperacionesSolicitudesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00AV3( IGxContext context ,
                                             decimal AV7cOperacionesSolicitudesComPro ,
                                             decimal AV8cOperacionesSolicitudesPFinal ,
                                             decimal AV9cOperacionesSolicitudesComProv ,
                                             decimal AV10cOperacionesSolicitudesComALM ,
                                             long AV11cOperacionesSolicitudesProvID ,
                                             decimal A653OperacionesSolicitudesComPro ,
                                             decimal A654OperacionesSolicitudesPFinal ,
                                             decimal A655OperacionesSolicitudesComProv ,
                                             decimal A656OperacionesSolicitudesComALM ,
                                             long A660OperacionesSolicitudesProvID ,
                                             long AV12pOperacionesId ,
                                             long AV6cOperacionesSolicitudesId ,
                                             long A554OperacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [OperacionesSolicitudes]";
         AddWhere(sWhereString, "([OperacionesId] = @AV12pOperacionesId and [OperacionesSolicitudesId] >= @AV6cOperacionesSolicitudesId)");
         if ( ! (Convert.ToDecimal(0)==AV7cOperacionesSolicitudesComPro) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesComPro] >= @AV7cOperacionesSolicitudesComPro)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cOperacionesSolicitudesPFinal) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesPFinal] >= @AV8cOperacionesSolicitudesPFinal)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cOperacionesSolicitudesComProv) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesComProv] >= @AV9cOperacionesSolicitudesComProv)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cOperacionesSolicitudesComALM) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesComALM] >= @AV10cOperacionesSolicitudesComALM)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV11cOperacionesSolicitudesProvID) )
         {
            AddWhere(sWhereString, "([OperacionesSolicitudesProvID] >= @AV11cOperacionesSolicitudesProvID)");
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
                     return conditional_H00AV2(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (long)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00AV3(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (long)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00AV2;
          prmH00AV2 = new Object[] {
          new ParDef("@AV12pOperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cOperacionesSolicitudesId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cOperacionesSolicitudesComPro",GXType.Decimal,18,2) ,
          new ParDef("@AV8cOperacionesSolicitudesPFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV9cOperacionesSolicitudesComProv",GXType.Decimal,18,2) ,
          new ParDef("@AV10cOperacionesSolicitudesComALM",GXType.Decimal,18,2) ,
          new ParDef("@AV11cOperacionesSolicitudesProvID",GXType.Decimal,18,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00AV3;
          prmH00AV3 = new Object[] {
          new ParDef("@AV12pOperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cOperacionesSolicitudesId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cOperacionesSolicitudesComPro",GXType.Decimal,18,2) ,
          new ParDef("@AV8cOperacionesSolicitudesPFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV9cOperacionesSolicitudesComProv",GXType.Decimal,18,2) ,
          new ParDef("@AV10cOperacionesSolicitudesComALM",GXType.Decimal,18,2) ,
          new ParDef("@AV11cOperacionesSolicitudesProvID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AV2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AV2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00AV3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AV3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx03b0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03b0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03b0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pMudanzaId )
      {
         this.AV13pMudanzaId = 0 ;
         ExecutePrivate();
         aP0_pMudanzaId=this.AV13pMudanzaId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCmudanzahoraservicio = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pMudanzaId");
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
               gxfirstwebparm = GetFirstPar( "pMudanzaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pMudanzaId");
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
               AV13pMudanzaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pMudanzaId", StringUtil.LTrimStr( (decimal)(AV13pMudanzaId), 18, 0));
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
         AV6cMudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "cMudanzaId"), "."), 18, MidpointRounding.ToEven));
         AV7cMudanzaAsesor = GetPar( "cMudanzaAsesor");
         AV8cMudanzaFechaAlta = context.localUtil.ParseDateParm( GetPar( "cMudanzaFechaAlta"));
         AV9cMudanzaFechaServicio = context.localUtil.ParseDateParm( GetPar( "cMudanzaFechaServicio"));
         cmbavCmudanzahoraservicio.FromJSonString( GetNextPar( ));
         AV10cMudanzaHoraServicio = GetPar( "cMudanzaHoraServicio");
         AV12cTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( GetPar( "cTipoInmuebleOrigenId"), "."), 18, MidpointRounding.ToEven));
         AV15cTipoInmuebleDestinoId = (short)(Math.Round(NumberUtil.Val( GetPar( "cTipoInmuebleDestinoId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cMudanzaId, AV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, AV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId) ;
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
         PAE22( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTE22( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pMudanzaId,18,0))}, new string[] {"pMudanzaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMUDANZAASESOR", AV7cMudanzaAsesor);
         GxWebStd.gx_hidden_field( context, "GXH_vCMUDANZAFECHAALTA", context.localUtil.Format(AV8cMudanzaFechaAlta, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCMUDANZAFECHASERVICIO", context.localUtil.Format(AV9cMudanzaFechaServicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCMUDANZAHORASERVICIO", StringUtil.RTrim( AV10cMudanzaHoraServicio));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOINMUEBLEORIGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cTipoInmuebleOrigenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOINMUEBLEDESTINOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cTipoInmuebleDestinoId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pMudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MUDANZAIDFILTERCONTAINER_Class", StringUtil.RTrim( divMudanzaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MUDANZAASESORFILTERCONTAINER_Class", StringUtil.RTrim( divMudanzaasesorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MUDANZAHORASERVICIOFILTERCONTAINER_Class", StringUtil.RTrim( divMudanzahoraserviciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOINMUEBLEORIGENIDFILTERCONTAINER_Class", StringUtil.RTrim( divTipoinmuebleorigenidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOINMUEBLEDESTINOIDFILTERCONTAINER_Class", StringUtil.RTrim( divTipoinmuebledestinoidfiltercontainer_Class));
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
            WEE22( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTE22( ) ;
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
         return formatLink("gx03b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pMudanzaId,18,0))}, new string[] {"pMudanzaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03B0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Mudanza", "") ;
      }

      protected void WBE20( )
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
            GxWebStd.gx_div_start( context, divMudanzaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMudanzaidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmudanzaidfilter_Internalname, context.GetMessage( "Mudanza Id", ""), "", "", lblLblmudanzaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11e21_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmudanzaid_Internalname, context.GetMessage( "Mudanza Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmudanzaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCmudanzaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cMudanzaId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cMudanzaId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmudanzaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmudanzaid_Visible, edtavCmudanzaid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03B0.htm");
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
            GxWebStd.gx_div_start( context, divMudanzaasesorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMudanzaasesorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmudanzaasesorfilter_Internalname, context.GetMessage( "Mudanza Asesor", ""), "", "", lblLblmudanzaasesorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12e21_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmudanzaasesor_Internalname, context.GetMessage( "Mudanza Asesor", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmudanzaasesor_Internalname, AV7cMudanzaAsesor, StringUtil.RTrim( context.localUtil.Format( AV7cMudanzaAsesor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmudanzaasesor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmudanzaasesor_Visible, edtavCmudanzaasesor_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03B0.htm");
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
            GxWebStd.gx_div_start( context, divMudanzafechaaltafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmudanzafechaaltafilter_Internalname, context.GetMessage( "Mudanza Fecha Alta", ""), "", "", lblLblmudanzafechaaltafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmudanzafechaalta_Internalname, context.GetMessage( "Mudanza Fecha Alta", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCmudanzafechaalta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCmudanzafechaalta_Internalname, context.localUtil.Format(AV8cMudanzaFechaAlta, "99/99/99"), context.localUtil.Format( AV8cMudanzaFechaAlta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmudanzafechaalta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCmudanzafechaalta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03B0.htm");
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
            GxWebStd.gx_div_start( context, divMudanzafechaserviciofiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmudanzafechaserviciofilter_Internalname, context.GetMessage( "Mudanza Fecha Servicio", ""), "", "", lblLblmudanzafechaserviciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmudanzafechaservicio_Internalname, context.GetMessage( "Mudanza Fecha Servicio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCmudanzafechaservicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCmudanzafechaservicio_Internalname, context.localUtil.Format(AV9cMudanzaFechaServicio, "99/99/99"), context.localUtil.Format( AV9cMudanzaFechaServicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmudanzafechaservicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCmudanzafechaservicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03B0.htm");
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
            GxWebStd.gx_div_start( context, divMudanzahoraserviciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMudanzahoraserviciofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmudanzahoraserviciofilter_Internalname, context.GetMessage( "Mudanza Hora Servicio", ""), "", "", lblLblmudanzahoraserviciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13e21_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmudanzahoraservicio_Internalname, context.GetMessage( "Mudanza Hora Servicio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmudanzahoraservicio, cmbavCmudanzahoraservicio_Internalname, StringUtil.RTrim( AV10cMudanzaHoraServicio), 1, cmbavCmudanzahoraservicio_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCmudanzahoraservicio.Visible, cmbavCmudanzahoraservicio.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Gx03B0.htm");
            cmbavCmudanzahoraservicio.CurrentValue = StringUtil.RTrim( AV10cMudanzaHoraServicio);
            AssignProp("", false, cmbavCmudanzahoraservicio_Internalname, "Values", (string)(cmbavCmudanzahoraservicio.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTipoinmuebleorigenidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipoinmuebleorigenidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipoinmuebleorigenidfilter_Internalname, context.GetMessage( "Tipo Inmueble Origen Id", ""), "", "", lblLbltipoinmuebleorigenidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14e21_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipoinmuebleorigenid_Internalname, context.GetMessage( "Tipo Inmueble Origen Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipoinmuebleorigenid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cTipoInmuebleOrigenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCtipoinmuebleorigenid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cTipoInmuebleOrigenId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cTipoInmuebleOrigenId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipoinmuebleorigenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipoinmuebleorigenid_Visible, edtavCtipoinmuebleorigenid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03B0.htm");
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
            GxWebStd.gx_div_start( context, divTipoinmuebledestinoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipoinmuebledestinoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipoinmuebledestinoidfilter_Internalname, context.GetMessage( "Tipo Inmueble Destino Id", ""), "", "", lblLbltipoinmuebledestinoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15e21_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipoinmuebledestinoid_Internalname, context.GetMessage( "Tipo Inmueble Destino Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipoinmuebledestinoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cTipoInmuebleDestinoId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCtipoinmuebledestinoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15cTipoInmuebleDestinoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV15cTipoInmuebleDestinoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipoinmuebledestinoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipoinmuebledestinoid_Visible, edtavCtipoinmuebledestinoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03B0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16e21_client"+"'", TempTags, "", 2, "HLP_Gx03B0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03B0.htm");
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

      protected void STARTE22( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPE20( ) ;
      }

      protected void WSE22( )
      {
         STARTE22( ) ;
         EVTE22( ) ;
      }

      protected void EVTE22( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A736MudanzaAsesor = cgiGet( edtMudanzaAsesor_Internalname);
                              A737MudanzaFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtMudanzaFechaAlta_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17E22 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18E22 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmudanzaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMudanzaId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmudanzaasesor Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMUDANZAASESOR"), AV7cMudanzaAsesor) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmudanzafechaalta Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCMUDANZAFECHAALTA"), 0) != AV8cMudanzaFechaAlta )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmudanzafechaservicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCMUDANZAFECHASERVICIO"), 0) != AV9cMudanzaFechaServicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmudanzahoraservicio Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMUDANZAHORASERVICIO"), AV10cMudanzaHoraServicio) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipoinmuebleorigenid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPOINMUEBLEORIGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cTipoInmuebleOrigenId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipoinmuebledestinoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPOINMUEBLEDESTINOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15cTipoInmuebleDestinoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19E22 ();
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

      protected void WEE22( )
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

      protected void PAE22( )
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
                                        long AV6cMudanzaId ,
                                        string AV7cMudanzaAsesor ,
                                        DateTime AV8cMudanzaFechaAlta ,
                                        DateTime AV9cMudanzaFechaServicio ,
                                        string AV10cMudanzaHoraServicio ,
                                        short AV12cTipoInmuebleOrigenId ,
                                        short AV15cTipoInmuebleDestinoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFE22( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", "")));
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
         if ( cmbavCmudanzahoraservicio.ItemCount > 0 )
         {
            AV10cMudanzaHoraServicio = cmbavCmudanzahoraservicio.getValidValue(AV10cMudanzaHoraServicio);
            AssignAttri("", false, "AV10cMudanzaHoraServicio", AV10cMudanzaHoraServicio);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmudanzahoraservicio.CurrentValue = StringUtil.RTrim( AV10cMudanzaHoraServicio);
            AssignProp("", false, cmbavCmudanzahoraservicio_Internalname, "Values", cmbavCmudanzahoraservicio.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFE22( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFE22( )
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
                                                 AV7cMudanzaAsesor ,
                                                 AV8cMudanzaFechaAlta ,
                                                 AV9cMudanzaFechaServicio ,
                                                 AV10cMudanzaHoraServicio ,
                                                 AV12cTipoInmuebleOrigenId ,
                                                 AV15cTipoInmuebleDestinoId ,
                                                 A736MudanzaAsesor ,
                                                 A737MudanzaFechaAlta ,
                                                 A738MudanzaFechaServicio ,
                                                 A739MudanzaHoraServicio ,
                                                 A743TipoInmuebleOrigenId ,
                                                 A745TipoInmuebleDestinoId ,
                                                 AV6cMudanzaId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            lV7cMudanzaAsesor = StringUtil.Concat( StringUtil.RTrim( AV7cMudanzaAsesor), "%", "");
            lV10cMudanzaHoraServicio = StringUtil.PadR( StringUtil.RTrim( AV10cMudanzaHoraServicio), 2, "%");
            /* Using cursor H00E22 */
            pr_default.execute(0, new Object[] {AV6cMudanzaId, lV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, lV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A745TipoInmuebleDestinoId = H00E22_A745TipoInmuebleDestinoId[0];
               A743TipoInmuebleOrigenId = H00E22_A743TipoInmuebleOrigenId[0];
               A739MudanzaHoraServicio = H00E22_A739MudanzaHoraServicio[0];
               n739MudanzaHoraServicio = H00E22_n739MudanzaHoraServicio[0];
               A738MudanzaFechaServicio = H00E22_A738MudanzaFechaServicio[0];
               A737MudanzaFechaAlta = H00E22_A737MudanzaFechaAlta[0];
               A736MudanzaAsesor = H00E22_A736MudanzaAsesor[0];
               A735MudanzaId = H00E22_A735MudanzaId[0];
               /* Execute user event: Load */
               E18E22 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBE20( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesE22( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MUDANZAID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cMudanzaAsesor ,
                                              AV8cMudanzaFechaAlta ,
                                              AV9cMudanzaFechaServicio ,
                                              AV10cMudanzaHoraServicio ,
                                              AV12cTipoInmuebleOrigenId ,
                                              AV15cTipoInmuebleDestinoId ,
                                              A736MudanzaAsesor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio ,
                                              A739MudanzaHoraServicio ,
                                              A743TipoInmuebleOrigenId ,
                                              A745TipoInmuebleDestinoId ,
                                              AV6cMudanzaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         lV7cMudanzaAsesor = StringUtil.Concat( StringUtil.RTrim( AV7cMudanzaAsesor), "%", "");
         lV10cMudanzaHoraServicio = StringUtil.PadR( StringUtil.RTrim( AV10cMudanzaHoraServicio), 2, "%");
         /* Using cursor H00E23 */
         pr_default.execute(1, new Object[] {AV6cMudanzaId, lV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, lV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId});
         GRID1_nRecordCount = H00E23_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMudanzaId, AV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, AV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMudanzaId, AV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, AV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMudanzaId, AV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, AV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMudanzaId, AV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, AV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMudanzaId, AV7cMudanzaAsesor, AV8cMudanzaFechaAlta, AV9cMudanzaFechaServicio, AV10cMudanzaHoraServicio, AV12cTipoInmuebleOrigenId, AV15cTipoInmuebleDestinoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtMudanzaId_Enabled = 0;
         edtMudanzaAsesor_Enabled = 0;
         edtMudanzaFechaAlta_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPE20( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17E22 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMUDANZAID");
               GX_FocusControl = edtavCmudanzaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cMudanzaId = 0;
               AssignAttri("", false, "AV6cMudanzaId", StringUtil.LTrimStr( (decimal)(AV6cMudanzaId), 18, 0));
            }
            else
            {
               AV6cMudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cMudanzaId", StringUtil.LTrimStr( (decimal)(AV6cMudanzaId), 18, 0));
            }
            AV7cMudanzaAsesor = cgiGet( edtavCmudanzaasesor_Internalname);
            AssignAttri("", false, "AV7cMudanzaAsesor", AV7cMudanzaAsesor);
            if ( context.localUtil.VCDate( cgiGet( edtavCmudanzafechaalta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Mudanza Fecha Alta", "")}), 1, "vCMUDANZAFECHAALTA");
               GX_FocusControl = edtavCmudanzafechaalta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cMudanzaFechaAlta = DateTime.MinValue;
               AssignAttri("", false, "AV8cMudanzaFechaAlta", context.localUtil.Format(AV8cMudanzaFechaAlta, "99/99/99"));
            }
            else
            {
               AV8cMudanzaFechaAlta = context.localUtil.CToD( cgiGet( edtavCmudanzafechaalta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV8cMudanzaFechaAlta", context.localUtil.Format(AV8cMudanzaFechaAlta, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCmudanzafechaservicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Mudanza Fecha Servicio", "")}), 1, "vCMUDANZAFECHASERVICIO");
               GX_FocusControl = edtavCmudanzafechaservicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cMudanzaFechaServicio = DateTime.MinValue;
               AssignAttri("", false, "AV9cMudanzaFechaServicio", context.localUtil.Format(AV9cMudanzaFechaServicio, "99/99/99"));
            }
            else
            {
               AV9cMudanzaFechaServicio = context.localUtil.CToD( cgiGet( edtavCmudanzafechaservicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV9cMudanzaFechaServicio", context.localUtil.Format(AV9cMudanzaFechaServicio, "99/99/99"));
            }
            cmbavCmudanzahoraservicio.Name = cmbavCmudanzahoraservicio_Internalname;
            cmbavCmudanzahoraservicio.CurrentValue = cgiGet( cmbavCmudanzahoraservicio_Internalname);
            AV10cMudanzaHoraServicio = cgiGet( cmbavCmudanzahoraservicio_Internalname);
            AssignAttri("", false, "AV10cMudanzaHoraServicio", AV10cMudanzaHoraServicio);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtipoinmuebleorigenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtipoinmuebleorigenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTIPOINMUEBLEORIGENID");
               GX_FocusControl = edtavCtipoinmuebleorigenid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cTipoInmuebleOrigenId = 0;
               AssignAttri("", false, "AV12cTipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(AV12cTipoInmuebleOrigenId), 4, 0));
            }
            else
            {
               AV12cTipoInmuebleOrigenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCtipoinmuebleorigenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cTipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(AV12cTipoInmuebleOrigenId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtipoinmuebledestinoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtipoinmuebledestinoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTIPOINMUEBLEDESTINOID");
               GX_FocusControl = edtavCtipoinmuebledestinoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cTipoInmuebleDestinoId = 0;
               AssignAttri("", false, "AV15cTipoInmuebleDestinoId", StringUtil.LTrimStr( (decimal)(AV15cTipoInmuebleDestinoId), 4, 0));
            }
            else
            {
               AV15cTipoInmuebleDestinoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCtipoinmuebledestinoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15cTipoInmuebleDestinoId", StringUtil.LTrimStr( (decimal)(AV15cTipoInmuebleDestinoId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMudanzaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMUDANZAASESOR"), AV7cMudanzaAsesor) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCMUDANZAFECHAALTA"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV8cMudanzaFechaAlta ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCMUDANZAFECHASERVICIO"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV9cMudanzaFechaServicio ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMUDANZAHORASERVICIO"), AV10cMudanzaHoraServicio) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPOINMUEBLEORIGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cTipoInmuebleOrigenId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTIPOINMUEBLEDESTINOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15cTipoInmuebleDestinoId )) )
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
         E17E22 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17E22( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Mudanza", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18E22( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E19E22 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19E22( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pMudanzaId = A735MudanzaId;
         AssignAttri("", false, "AV13pMudanzaId", StringUtil.LTrimStr( (decimal)(AV13pMudanzaId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pMudanzaId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pMudanzaId"});
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
         AV13pMudanzaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pMudanzaId", StringUtil.LTrimStr( (decimal)(AV13pMudanzaId), 18, 0));
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
         PAE22( ) ;
         WSE22( ) ;
         WEE22( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021261822", true, true, false);
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
         context.AddJavascriptSource("gx03b0.js", "?202673021261822", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_84_idx;
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR_"+sGXsfl_84_idx;
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_84_fel_idx;
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR_"+sGXsfl_84_fel_idx;
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBE20( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtMudanzaAsesor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtMudanzaAsesor_Internalname, "Link", edtMudanzaAsesor_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaAsesor_Internalname,(string)A736MudanzaAsesor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMudanzaAsesor_Link,(string)"",(string)"",(string)"",(string)edtMudanzaAsesor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaFechaAlta_Internalname,context.localUtil.Format(A737MudanzaFechaAlta, "99/99/99"),context.localUtil.Format( A737MudanzaFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesE22( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCmudanzahoraservicio.Name = "vCMUDANZAHORASERVICIO";
         cmbavCmudanzahoraservicio.WebTags = "";
         cmbavCmudanzahoraservicio.addItem("08", "08:00", 0);
         cmbavCmudanzahoraservicio.addItem("09", "09:00", 0);
         cmbavCmudanzahoraservicio.addItem("10", "10:00", 0);
         cmbavCmudanzahoraservicio.addItem("11", "11:00", 0);
         cmbavCmudanzahoraservicio.addItem("12", "12:00", 0);
         cmbavCmudanzahoraservicio.addItem("13", "13:00", 0);
         cmbavCmudanzahoraservicio.addItem("14", "14:00", 0);
         cmbavCmudanzahoraservicio.addItem("15", "15:00", 0);
         cmbavCmudanzahoraservicio.addItem("16", "16:00", 0);
         cmbavCmudanzahoraservicio.addItem("17", "17:00", 0);
         cmbavCmudanzahoraservicio.addItem("18", "18:00", 0);
         cmbavCmudanzahoraservicio.addItem("19", "19:00", 0);
         if ( cmbavCmudanzahoraservicio.ItemCount > 0 )
         {
            AV10cMudanzaHoraServicio = cmbavCmudanzahoraservicio.getValidValue(AV10cMudanzaHoraServicio);
            AssignAttri("", false, "AV10cMudanzaHoraServicio", AV10cMudanzaHoraServicio);
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
            context.SendWebValue( context.GetMessage( "Asesor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A736MudanzaAsesor));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtMudanzaAsesor_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A737MudanzaFechaAlta, "99/99/99")));
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
         lblLblmudanzaidfilter_Internalname = "LBLMUDANZAIDFILTER";
         edtavCmudanzaid_Internalname = "vCMUDANZAID";
         divMudanzaidfiltercontainer_Internalname = "MUDANZAIDFILTERCONTAINER";
         lblLblmudanzaasesorfilter_Internalname = "LBLMUDANZAASESORFILTER";
         edtavCmudanzaasesor_Internalname = "vCMUDANZAASESOR";
         divMudanzaasesorfiltercontainer_Internalname = "MUDANZAASESORFILTERCONTAINER";
         lblLblmudanzafechaaltafilter_Internalname = "LBLMUDANZAFECHAALTAFILTER";
         edtavCmudanzafechaalta_Internalname = "vCMUDANZAFECHAALTA";
         divMudanzafechaaltafiltercontainer_Internalname = "MUDANZAFECHAALTAFILTERCONTAINER";
         lblLblmudanzafechaserviciofilter_Internalname = "LBLMUDANZAFECHASERVICIOFILTER";
         edtavCmudanzafechaservicio_Internalname = "vCMUDANZAFECHASERVICIO";
         divMudanzafechaserviciofiltercontainer_Internalname = "MUDANZAFECHASERVICIOFILTERCONTAINER";
         lblLblmudanzahoraserviciofilter_Internalname = "LBLMUDANZAHORASERVICIOFILTER";
         cmbavCmudanzahoraservicio_Internalname = "vCMUDANZAHORASERVICIO";
         divMudanzahoraserviciofiltercontainer_Internalname = "MUDANZAHORASERVICIOFILTERCONTAINER";
         lblLbltipoinmuebleorigenidfilter_Internalname = "LBLTIPOINMUEBLEORIGENIDFILTER";
         edtavCtipoinmuebleorigenid_Internalname = "vCTIPOINMUEBLEORIGENID";
         divTipoinmuebleorigenidfiltercontainer_Internalname = "TIPOINMUEBLEORIGENIDFILTERCONTAINER";
         lblLbltipoinmuebledestinoidfilter_Internalname = "LBLTIPOINMUEBLEDESTINOIDFILTER";
         edtavCtipoinmuebledestinoid_Internalname = "vCTIPOINMUEBLEDESTINOID";
         divTipoinmuebledestinoidfiltercontainer_Internalname = "TIPOINMUEBLEDESTINOIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtMudanzaId_Internalname = "MUDANZAID";
         edtMudanzaAsesor_Internalname = "MUDANZAASESOR";
         edtMudanzaFechaAlta_Internalname = "MUDANZAFECHAALTA";
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
         edtMudanzaFechaAlta_Jsonclick = "";
         edtMudanzaAsesor_Jsonclick = "";
         edtMudanzaAsesor_Link = "";
         edtMudanzaId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtMudanzaFechaAlta_Enabled = 0;
         edtMudanzaAsesor_Enabled = 0;
         edtMudanzaId_Enabled = 0;
         edtavCtipoinmuebledestinoid_Jsonclick = "";
         edtavCtipoinmuebledestinoid_Enabled = 1;
         edtavCtipoinmuebledestinoid_Visible = 1;
         edtavCtipoinmuebleorigenid_Jsonclick = "";
         edtavCtipoinmuebleorigenid_Enabled = 1;
         edtavCtipoinmuebleorigenid_Visible = 1;
         cmbavCmudanzahoraservicio_Jsonclick = "";
         cmbavCmudanzahoraservicio.Visible = 1;
         cmbavCmudanzahoraservicio.Enabled = 1;
         edtavCmudanzafechaservicio_Jsonclick = "";
         edtavCmudanzafechaservicio_Enabled = 1;
         edtavCmudanzafechaalta_Jsonclick = "";
         edtavCmudanzafechaalta_Enabled = 1;
         edtavCmudanzaasesor_Jsonclick = "";
         edtavCmudanzaasesor_Enabled = 1;
         edtavCmudanzaasesor_Visible = 1;
         edtavCmudanzaid_Jsonclick = "";
         edtavCmudanzaid_Enabled = 1;
         edtavCmudanzaid_Visible = 1;
         divTipoinmuebledestinoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divTipoinmuebleorigenidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMudanzahoraserviciofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMudanzaasesorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMudanzaidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Mudanza", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMudanzaId',fld:'vCMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMudanzaAsesor',fld:'vCMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV8cMudanzaFechaAlta',fld:'vCMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV9cMudanzaFechaServicio',fld:'vCMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'cmbavCmudanzahoraservicio'},{av:'AV10cMudanzaHoraServicio',fld:'vCMUDANZAHORASERVICIO',pic:'',type:'char'},{av:'AV12cTipoInmuebleOrigenId',fld:'vCTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV15cTipoInmuebleDestinoId',fld:'vCTIPOINMUEBLEDESTINOID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16E21',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLMUDANZAIDFILTER.CLICK","{handler:'E11E21',iparms:[{av:'divMudanzaidfiltercontainer_Class',ctrl:'MUDANZAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMUDANZAIDFILTER.CLICK",",oparms:[{av:'divMudanzaidfiltercontainer_Class',ctrl:'MUDANZAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCmudanzaid_Visible',ctrl:'vCMUDANZAID',prop:'Visible'}]}");
         setEventMetadata("LBLMUDANZAASESORFILTER.CLICK","{handler:'E12E21',iparms:[{av:'divMudanzaasesorfiltercontainer_Class',ctrl:'MUDANZAASESORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMUDANZAASESORFILTER.CLICK",",oparms:[{av:'divMudanzaasesorfiltercontainer_Class',ctrl:'MUDANZAASESORFILTERCONTAINER',prop:'Class'},{av:'edtavCmudanzaasesor_Visible',ctrl:'vCMUDANZAASESOR',prop:'Visible'}]}");
         setEventMetadata("LBLMUDANZAHORASERVICIOFILTER.CLICK","{handler:'E13E21',iparms:[{av:'divMudanzahoraserviciofiltercontainer_Class',ctrl:'MUDANZAHORASERVICIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMUDANZAHORASERVICIOFILTER.CLICK",",oparms:[{av:'divMudanzahoraserviciofiltercontainer_Class',ctrl:'MUDANZAHORASERVICIOFILTERCONTAINER',prop:'Class'},{av:'cmbavCmudanzahoraservicio'}]}");
         setEventMetadata("LBLTIPOINMUEBLEORIGENIDFILTER.CLICK","{handler:'E14E21',iparms:[{av:'divTipoinmuebleorigenidfiltercontainer_Class',ctrl:'TIPOINMUEBLEORIGENIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOINMUEBLEORIGENIDFILTER.CLICK",",oparms:[{av:'divTipoinmuebleorigenidfiltercontainer_Class',ctrl:'TIPOINMUEBLEORIGENIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtipoinmuebleorigenid_Visible',ctrl:'vCTIPOINMUEBLEORIGENID',prop:'Visible'}]}");
         setEventMetadata("LBLTIPOINMUEBLEDESTINOIDFILTER.CLICK","{handler:'E15E21',iparms:[{av:'divTipoinmuebledestinoidfiltercontainer_Class',ctrl:'TIPOINMUEBLEDESTINOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOINMUEBLEDESTINOIDFILTER.CLICK",",oparms:[{av:'divTipoinmuebledestinoidfiltercontainer_Class',ctrl:'TIPOINMUEBLEDESTINOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtipoinmuebledestinoid_Visible',ctrl:'vCTIPOINMUEBLEDESTINOID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19E22',iparms:[{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pMudanzaId',fld:'vPMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMudanzaId',fld:'vCMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMudanzaAsesor',fld:'vCMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV8cMudanzaFechaAlta',fld:'vCMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV9cMudanzaFechaServicio',fld:'vCMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'cmbavCmudanzahoraservicio'},{av:'AV10cMudanzaHoraServicio',fld:'vCMUDANZAHORASERVICIO',pic:'',type:'char'},{av:'AV12cTipoInmuebleOrigenId',fld:'vCTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV15cTipoInmuebleDestinoId',fld:'vCTIPOINMUEBLEDESTINOID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMudanzaId',fld:'vCMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMudanzaAsesor',fld:'vCMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV8cMudanzaFechaAlta',fld:'vCMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV9cMudanzaFechaServicio',fld:'vCMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'cmbavCmudanzahoraservicio'},{av:'AV10cMudanzaHoraServicio',fld:'vCMUDANZAHORASERVICIO',pic:'',type:'char'},{av:'AV12cTipoInmuebleOrigenId',fld:'vCTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV15cTipoInmuebleDestinoId',fld:'vCTIPOINMUEBLEDESTINOID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMudanzaId',fld:'vCMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMudanzaAsesor',fld:'vCMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV8cMudanzaFechaAlta',fld:'vCMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV9cMudanzaFechaServicio',fld:'vCMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'cmbavCmudanzahoraservicio'},{av:'AV10cMudanzaHoraServicio',fld:'vCMUDANZAHORASERVICIO',pic:'',type:'char'},{av:'AV12cTipoInmuebleOrigenId',fld:'vCTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV15cTipoInmuebleDestinoId',fld:'vCTIPOINMUEBLEDESTINOID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMudanzaId',fld:'vCMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cMudanzaAsesor',fld:'vCMUDANZAASESOR',pic:'',type:'svchar'},{av:'AV8cMudanzaFechaAlta',fld:'vCMUDANZAFECHAALTA',pic:'',type:'date'},{av:'AV9cMudanzaFechaServicio',fld:'vCMUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'cmbavCmudanzahoraservicio'},{av:'AV10cMudanzaHoraServicio',fld:'vCMUDANZAHORASERVICIO',pic:'',type:'char'},{av:'AV12cTipoInmuebleOrigenId',fld:'vCTIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'AV15cTipoInmuebleDestinoId',fld:'vCTIPOINMUEBLEDESTINOID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CMUDANZAFECHAALTA","{handler:'Validv_Cmudanzafechaalta',iparms:[]");
         setEventMetadata("VALIDV_CMUDANZAFECHAALTA",",oparms:[]}");
         setEventMetadata("VALIDV_CMUDANZAFECHASERVICIO","{handler:'Validv_Cmudanzafechaservicio',iparms:[]");
         setEventMetadata("VALIDV_CMUDANZAFECHASERVICIO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Mudanzafechaalta',iparms:[]");
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
         AV7cMudanzaAsesor = "";
         AV8cMudanzaFechaAlta = DateTime.MinValue;
         AV9cMudanzaFechaServicio = DateTime.MinValue;
         AV10cMudanzaHoraServicio = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmudanzaidfilter_Jsonclick = "";
         TempTags = "";
         lblLblmudanzaasesorfilter_Jsonclick = "";
         lblLblmudanzafechaaltafilter_Jsonclick = "";
         lblLblmudanzafechaserviciofilter_Jsonclick = "";
         lblLblmudanzahoraserviciofilter_Jsonclick = "";
         lblLbltipoinmuebleorigenidfilter_Jsonclick = "";
         lblLbltipoinmuebledestinoidfilter_Jsonclick = "";
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
         A736MudanzaAsesor = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         lV7cMudanzaAsesor = "";
         lV10cMudanzaHoraServicio = "";
         A738MudanzaFechaServicio = DateTime.MinValue;
         A739MudanzaHoraServicio = "";
         H00E22_A745TipoInmuebleDestinoId = new short[1] ;
         H00E22_A743TipoInmuebleOrigenId = new short[1] ;
         H00E22_A739MudanzaHoraServicio = new string[] {""} ;
         H00E22_n739MudanzaHoraServicio = new bool[] {false} ;
         H00E22_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         H00E22_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00E22_A736MudanzaAsesor = new string[] {""} ;
         H00E22_A735MudanzaId = new long[1] ;
         H00E23_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03b0__default(),
            new Object[][] {
                new Object[] {
               H00E22_A745TipoInmuebleDestinoId, H00E22_A743TipoInmuebleOrigenId, H00E22_A739MudanzaHoraServicio, H00E22_n739MudanzaHoraServicio, H00E22_A738MudanzaFechaServicio, H00E22_A737MudanzaFechaAlta, H00E22_A736MudanzaAsesor, H00E22_A735MudanzaId
               }
               , new Object[] {
               H00E23_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12cTipoInmuebleOrigenId ;
      private short AV15cTipoInmuebleDestinoId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A743TipoInmuebleOrigenId ;
      private short A745TipoInmuebleDestinoId ;
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
      private int edtavCmudanzaid_Enabled ;
      private int edtavCmudanzaid_Visible ;
      private int edtavCmudanzaasesor_Visible ;
      private int edtavCmudanzaasesor_Enabled ;
      private int edtavCmudanzafechaalta_Enabled ;
      private int edtavCmudanzafechaservicio_Enabled ;
      private int edtavCtipoinmuebleorigenid_Enabled ;
      private int edtavCtipoinmuebleorigenid_Visible ;
      private int edtavCtipoinmuebledestinoid_Enabled ;
      private int edtavCtipoinmuebledestinoid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtMudanzaId_Enabled ;
      private int edtMudanzaAsesor_Enabled ;
      private int edtMudanzaFechaAlta_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pMudanzaId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cMudanzaId ;
      private long A735MudanzaId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divMudanzaidfiltercontainer_Class ;
      private string divMudanzaasesorfiltercontainer_Class ;
      private string divMudanzahoraserviciofiltercontainer_Class ;
      private string divTipoinmuebleorigenidfiltercontainer_Class ;
      private string divTipoinmuebledestinoidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV10cMudanzaHoraServicio ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divMudanzaidfiltercontainer_Internalname ;
      private string lblLblmudanzaidfilter_Internalname ;
      private string lblLblmudanzaidfilter_Jsonclick ;
      private string edtavCmudanzaid_Internalname ;
      private string TempTags ;
      private string edtavCmudanzaid_Jsonclick ;
      private string divMudanzaasesorfiltercontainer_Internalname ;
      private string lblLblmudanzaasesorfilter_Internalname ;
      private string lblLblmudanzaasesorfilter_Jsonclick ;
      private string edtavCmudanzaasesor_Internalname ;
      private string edtavCmudanzaasesor_Jsonclick ;
      private string divMudanzafechaaltafiltercontainer_Internalname ;
      private string lblLblmudanzafechaaltafilter_Internalname ;
      private string lblLblmudanzafechaaltafilter_Jsonclick ;
      private string edtavCmudanzafechaalta_Internalname ;
      private string edtavCmudanzafechaalta_Jsonclick ;
      private string divMudanzafechaserviciofiltercontainer_Internalname ;
      private string lblLblmudanzafechaserviciofilter_Internalname ;
      private string lblLblmudanzafechaserviciofilter_Jsonclick ;
      private string edtavCmudanzafechaservicio_Internalname ;
      private string edtavCmudanzafechaservicio_Jsonclick ;
      private string divMudanzahoraserviciofiltercontainer_Internalname ;
      private string lblLblmudanzahoraserviciofilter_Internalname ;
      private string lblLblmudanzahoraserviciofilter_Jsonclick ;
      private string cmbavCmudanzahoraservicio_Internalname ;
      private string cmbavCmudanzahoraservicio_Jsonclick ;
      private string divTipoinmuebleorigenidfiltercontainer_Internalname ;
      private string lblLbltipoinmuebleorigenidfilter_Internalname ;
      private string lblLbltipoinmuebleorigenidfilter_Jsonclick ;
      private string edtavCtipoinmuebleorigenid_Internalname ;
      private string edtavCtipoinmuebleorigenid_Jsonclick ;
      private string divTipoinmuebledestinoidfiltercontainer_Internalname ;
      private string lblLbltipoinmuebledestinoidfilter_Internalname ;
      private string lblLbltipoinmuebledestinoidfilter_Jsonclick ;
      private string edtavCtipoinmuebledestinoid_Internalname ;
      private string edtavCtipoinmuebledestinoid_Jsonclick ;
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
      private string edtMudanzaId_Internalname ;
      private string edtMudanzaAsesor_Internalname ;
      private string edtMudanzaFechaAlta_Internalname ;
      private string lV10cMudanzaHoraServicio ;
      private string A739MudanzaHoraServicio ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtMudanzaId_Jsonclick ;
      private string edtMudanzaAsesor_Link ;
      private string edtMudanzaAsesor_Jsonclick ;
      private string edtMudanzaFechaAlta_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8cMudanzaFechaAlta ;
      private DateTime AV9cMudanzaFechaServicio ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime A738MudanzaFechaServicio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n739MudanzaHoraServicio ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cMudanzaAsesor ;
      private string AV16Linkselection_GXI ;
      private string A736MudanzaAsesor ;
      private string lV7cMudanzaAsesor ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCmudanzahoraservicio ;
      private IDataStoreProvider pr_default ;
      private short[] H00E22_A745TipoInmuebleDestinoId ;
      private short[] H00E22_A743TipoInmuebleOrigenId ;
      private string[] H00E22_A739MudanzaHoraServicio ;
      private bool[] H00E22_n739MudanzaHoraServicio ;
      private DateTime[] H00E22_A738MudanzaFechaServicio ;
      private DateTime[] H00E22_A737MudanzaFechaAlta ;
      private string[] H00E22_A736MudanzaAsesor ;
      private long[] H00E22_A735MudanzaId ;
      private long[] H00E23_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pMudanzaId ;
   }

   public class gx03b0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00E22( IGxContext context ,
                                             string AV7cMudanzaAsesor ,
                                             DateTime AV8cMudanzaFechaAlta ,
                                             DateTime AV9cMudanzaFechaServicio ,
                                             string AV10cMudanzaHoraServicio ,
                                             short AV12cTipoInmuebleOrigenId ,
                                             short AV15cTipoInmuebleDestinoId ,
                                             string A736MudanzaAsesor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio ,
                                             string A739MudanzaHoraServicio ,
                                             short A743TipoInmuebleOrigenId ,
                                             short A745TipoInmuebleDestinoId ,
                                             long AV6cMudanzaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TipoInmuebleDestinoId], [TipoInmuebleOrigenId], [MudanzaHoraServicio], [MudanzaFechaServicio], [MudanzaFechaAlta], [MudanzaAsesor], [MudanzaId]";
         sFromString = " FROM [Mudanza]";
         sOrderString = "";
         AddWhere(sWhereString, "([MudanzaId] >= @AV6cMudanzaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMudanzaAsesor)) )
         {
            AddWhere(sWhereString, "([MudanzaAsesor] like @lV7cMudanzaAsesor)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cMudanzaFechaAlta) )
         {
            AddWhere(sWhereString, "([MudanzaFechaAlta] >= @AV8cMudanzaFechaAlta)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cMudanzaFechaServicio) )
         {
            AddWhere(sWhereString, "([MudanzaFechaServicio] >= @AV9cMudanzaFechaServicio)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cMudanzaHoraServicio)) )
         {
            AddWhere(sWhereString, "([MudanzaHoraServicio] like @lV10cMudanzaHoraServicio)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV12cTipoInmuebleOrigenId) )
         {
            AddWhere(sWhereString, "([TipoInmuebleOrigenId] >= @AV12cTipoInmuebleOrigenId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV15cTipoInmuebleDestinoId) )
         {
            AddWhere(sWhereString, "([TipoInmuebleDestinoId] >= @AV15cTipoInmuebleDestinoId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [MudanzaId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00E23( IGxContext context ,
                                             string AV7cMudanzaAsesor ,
                                             DateTime AV8cMudanzaFechaAlta ,
                                             DateTime AV9cMudanzaFechaServicio ,
                                             string AV10cMudanzaHoraServicio ,
                                             short AV12cTipoInmuebleOrigenId ,
                                             short AV15cTipoInmuebleDestinoId ,
                                             string A736MudanzaAsesor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio ,
                                             string A739MudanzaHoraServicio ,
                                             short A743TipoInmuebleOrigenId ,
                                             short A745TipoInmuebleDestinoId ,
                                             long AV6cMudanzaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Mudanza]";
         AddWhere(sWhereString, "([MudanzaId] >= @AV6cMudanzaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMudanzaAsesor)) )
         {
            AddWhere(sWhereString, "([MudanzaAsesor] like @lV7cMudanzaAsesor)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cMudanzaFechaAlta) )
         {
            AddWhere(sWhereString, "([MudanzaFechaAlta] >= @AV8cMudanzaFechaAlta)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cMudanzaFechaServicio) )
         {
            AddWhere(sWhereString, "([MudanzaFechaServicio] >= @AV9cMudanzaFechaServicio)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cMudanzaHoraServicio)) )
         {
            AddWhere(sWhereString, "([MudanzaHoraServicio] like @lV10cMudanzaHoraServicio)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV12cTipoInmuebleOrigenId) )
         {
            AddWhere(sWhereString, "([TipoInmuebleOrigenId] >= @AV12cTipoInmuebleOrigenId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV15cTipoInmuebleDestinoId) )
         {
            AddWhere(sWhereString, "([TipoInmuebleDestinoId] >= @AV15cTipoInmuebleDestinoId)");
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
                     return conditional_H00E22(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00E23(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00E22;
          prmH00E22 = new Object[] {
          new ParDef("@AV6cMudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMudanzaAsesor",GXType.NVarChar,80,0) ,
          new ParDef("@AV8cMudanzaFechaAlta",GXType.Date,8,0) ,
          new ParDef("@AV9cMudanzaFechaServicio",GXType.Date,8,0) ,
          new ParDef("@lV10cMudanzaHoraServicio",GXType.NChar,2,5) ,
          new ParDef("@AV12cTipoInmuebleOrigenId",GXType.Int16,4,0) ,
          new ParDef("@AV15cTipoInmuebleDestinoId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00E23;
          prmH00E23 = new Object[] {
          new ParDef("@AV6cMudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMudanzaAsesor",GXType.NVarChar,80,0) ,
          new ParDef("@AV8cMudanzaFechaAlta",GXType.Date,8,0) ,
          new ParDef("@AV9cMudanzaFechaServicio",GXType.Date,8,0) ,
          new ParDef("@lV10cMudanzaHoraServicio",GXType.NChar,2,5) ,
          new ParDef("@AV12cTipoInmuebleOrigenId",GXType.Int16,4,0) ,
          new ParDef("@AV15cTipoInmuebleDestinoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00E22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E22,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00E23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E23,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

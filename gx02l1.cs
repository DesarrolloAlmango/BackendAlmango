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
   public class gx02l1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx02l1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx02l1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pWalletId ,
                           out long aP1_pWalletBalancesId )
      {
         this.AV12pWalletId = aP0_pWalletId;
         this.AV13pWalletBalancesId = 0 ;
         ExecutePrivate();
         aP1_pWalletBalancesId=this.AV13pWalletBalancesId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCwalletbalancestipomov = new GXCombobox();
         cmbavCwalletbalancesestadoope = new GXCombobox();
         cmbWalletBalancesTipoMov = new GXCombobox();
         cmbWalletBalancesEstadoOPE = new GXCombobox();
         cmbWalletBalancesConcepto = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pWalletId");
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
               gxfirstwebparm = GetFirstPar( "pWalletId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pWalletId");
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
               AV12pWalletId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pWalletId", StringUtil.LTrimStr( (decimal)(AV12pWalletId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pWalletBalancesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pWalletBalancesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pWalletBalancesId", StringUtil.LTrimStr( (decimal)(AV13pWalletBalancesId), 18, 0));
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
         AV6cWalletBalancesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cWalletBalancesId"), "."), 18, MidpointRounding.ToEven));
         AV7cWalletBalancesFechaAlta = context.localUtil.ParseDTimeParm( GetPar( "cWalletBalancesFechaAlta"));
         AV8cWalletBalancesUsrAlta = (long)(Math.Round(NumberUtil.Val( GetPar( "cWalletBalancesUsrAlta"), "."), 18, MidpointRounding.ToEven));
         cmbavCwalletbalancestipomov.FromJSonString( GetNextPar( ));
         AV9cWalletBalancesTipoMov = GetPar( "cWalletBalancesTipoMov");
         AV10cWalletBalancesImporte = NumberUtil.Val( GetPar( "cWalletBalancesImporte"), ".");
         cmbavCwalletbalancesestadoope.FromJSonString( GetNextPar( ));
         AV11cWalletBalancesEstadoOPE = GetPar( "cWalletBalancesEstadoOPE");
         AV12pWalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "pWalletId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, AV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, AV11cWalletBalancesEstadoOPE, AV12pWalletId) ;
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
         PAAU2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAU2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx02l1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pWalletId,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pWalletBalancesId,18,0))}, new string[] {"pWalletId","pWalletBalancesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCWALLETBALANCESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWALLETBALANCESFECHAALTA", context.localUtil.TToC( AV7cWalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCWALLETBALANCESUSRALTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cWalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWALLETBALANCESTIPOMOV", StringUtil.RTrim( AV9cWalletBalancesTipoMov));
         GxWebStd.gx_hidden_field( context, "GXH_vCWALLETBALANCESIMPORTE", StringUtil.LTrim( StringUtil.NToC( AV10cWalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCWALLETBALANCESESTADOOPE", StringUtil.RTrim( AV11cWalletBalancesEstadoOPE));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPWALLETBALANCESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pWalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESIDFILTERCONTAINER_Class", StringUtil.RTrim( divWalletbalancesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESUSRALTAFILTERCONTAINER_Class", StringUtil.RTrim( divWalletbalancesusraltafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESTIPOMOVFILTERCONTAINER_Class", StringUtil.RTrim( divWalletbalancestipomovfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESIMPORTEFILTERCONTAINER_Class", StringUtil.RTrim( divWalletbalancesimportefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESESTADOOPEFILTERCONTAINER_Class", StringUtil.RTrim( divWalletbalancesestadoopefiltercontainer_Class));
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
            WEAU2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAU2( ) ;
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
         return formatLink("gx02l1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pWalletId,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pWalletBalancesId,18,0))}, new string[] {"pWalletId","pWalletBalancesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx02L1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Balances", "") ;
      }

      protected void WBAU0( )
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
            GxWebStd.gx_div_start( context, divWalletbalancesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWalletbalancesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwalletbalancesidfilter_Internalname, context.GetMessage( "Operación Nro.", ""), "", "", lblLblwalletbalancesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11au1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02L1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwalletbalancesid_Internalname, context.GetMessage( "Operación Nro.", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwalletbalancesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cWalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwalletbalancesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cWalletBalancesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cWalletBalancesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwalletbalancesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwalletbalancesid_Visible, edtavCwalletbalancesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02L1.htm");
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
            GxWebStd.gx_div_start( context, divWalletbalancesfechaaltafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwalletbalancesfechaaltafilter_Internalname, context.GetMessage( "Fecha de Alta", ""), "", "", lblLblwalletbalancesfechaaltafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx02L1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwalletbalancesfechaalta_Internalname, context.GetMessage( "Fecha de Alta", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCwalletbalancesfechaalta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCwalletbalancesfechaalta_Internalname, context.localUtil.TToC( AV7cWalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV7cWalletBalancesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwalletbalancesfechaalta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCwalletbalancesfechaalta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02L1.htm");
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
            GxWebStd.gx_div_start( context, divWalletbalancesusraltafiltercontainer_Internalname, 1, 0, "px", 0, "px", divWalletbalancesusraltafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwalletbalancesusraltafilter_Internalname, context.GetMessage( "Usuario de Alta", ""), "", "", lblLblwalletbalancesusraltafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12au1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02L1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwalletbalancesusralta_Internalname, context.GetMessage( "Usuario de Alta", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwalletbalancesusralta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cWalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwalletbalancesusralta_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cWalletBalancesUsrAlta), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cWalletBalancesUsrAlta), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwalletbalancesusralta_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwalletbalancesusralta_Visible, edtavCwalletbalancesusralta_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02L1.htm");
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
            GxWebStd.gx_div_start( context, divWalletbalancestipomovfiltercontainer_Internalname, 1, 0, "px", 0, "px", divWalletbalancestipomovfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwalletbalancestipomovfilter_Internalname, context.GetMessage( "Tipo de Movimiento", ""), "", "", lblLblwalletbalancestipomovfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13au1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02L1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCwalletbalancestipomov_Internalname, context.GetMessage( "Tipo de Movimiento", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCwalletbalancestipomov, cmbavCwalletbalancestipomov_Internalname, StringUtil.RTrim( AV9cWalletBalancesTipoMov), 1, cmbavCwalletbalancestipomov_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCwalletbalancestipomov.Visible, cmbavCwalletbalancestipomov.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Gx02L1.htm");
            cmbavCwalletbalancestipomov.CurrentValue = StringUtil.RTrim( AV9cWalletBalancesTipoMov);
            AssignProp("", false, cmbavCwalletbalancestipomov_Internalname, "Values", (string)(cmbavCwalletbalancestipomov.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divWalletbalancesimportefiltercontainer_Internalname, 1, 0, "px", 0, "px", divWalletbalancesimportefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwalletbalancesimportefilter_Internalname, context.GetMessage( "Importe", ""), "", "", lblLblwalletbalancesimportefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14au1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02L1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCwalletbalancesimporte_Internalname, context.GetMessage( "Importe", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCwalletbalancesimporte_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cWalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCwalletbalancesimporte_Enabled!=0) ? context.localUtil.Format( AV10cWalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV10cWalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCwalletbalancesimporte_Jsonclick, 0, "Attribute", "", "", "", "", edtavCwalletbalancesimporte_Visible, edtavCwalletbalancesimporte_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx02L1.htm");
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
            GxWebStd.gx_div_start( context, divWalletbalancesestadoopefiltercontainer_Internalname, 1, 0, "px", 0, "px", divWalletbalancesestadoopefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblwalletbalancesestadoopefilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblwalletbalancesestadoopefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15au1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx02L1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCwalletbalancesestadoope_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCwalletbalancesestadoope, cmbavCwalletbalancesestadoope_Internalname, StringUtil.RTrim( AV11cWalletBalancesEstadoOPE), 1, cmbavCwalletbalancesestadoope_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCwalletbalancesestadoope.Visible, cmbavCwalletbalancesestadoope.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_Gx02L1.htm");
            cmbavCwalletbalancesestadoope.CurrentValue = StringUtil.RTrim( AV11cWalletBalancesEstadoOPE);
            AssignProp("", false, cmbavCwalletbalancesestadoope_Internalname, "Values", (string)(cmbavCwalletbalancesestadoope.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16au1_client"+"'", TempTags, "", 2, "HLP_Gx02L1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx02L1.htm");
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

      protected void STARTAU2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Balances", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAU0( ) ;
      }

      protected void WSAU2( )
      {
         STARTAU2( ) ;
         EVTAU2( ) ;
      }

      protected void EVTAU2( )
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
                              A640WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A641WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtWalletBalancesFechaAlta_Internalname), 0);
                              A642WalletBalancesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbWalletBalancesTipoMov.Name = cmbWalletBalancesTipoMov_Internalname;
                              cmbWalletBalancesTipoMov.CurrentValue = cgiGet( cmbWalletBalancesTipoMov_Internalname);
                              A643WalletBalancesTipoMov = cgiGet( cmbWalletBalancesTipoMov_Internalname);
                              A644WalletBalancesImporte = context.localUtil.CToN( cgiGet( edtWalletBalancesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbWalletBalancesEstadoOPE.Name = cmbWalletBalancesEstadoOPE_Internalname;
                              cmbWalletBalancesEstadoOPE.CurrentValue = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
                              A645WalletBalancesEstadoOPE = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
                              cmbWalletBalancesConcepto.Name = cmbWalletBalancesConcepto_Internalname;
                              cmbWalletBalancesConcepto.CurrentValue = cgiGet( cmbWalletBalancesConcepto_Internalname);
                              A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWalletBalancesConcepto_Internalname), "."), 18, MidpointRounding.ToEven));
                              n1010WalletBalancesConcepto = false;
                              A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17AU2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18AU2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cwalletbalancesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWALLETBALANCESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWalletBalancesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwalletbalancesfechaalta Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCWALLETBALANCESFECHAALTA"), 0) != AV7cWalletBalancesFechaAlta )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwalletbalancesusralta Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWALLETBALANCESUSRALTA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cWalletBalancesUsrAlta )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwalletbalancestipomov Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWALLETBALANCESTIPOMOV"), AV9cWalletBalancesTipoMov) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwalletbalancesimporte Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCWALLETBALANCESIMPORTE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cWalletBalancesImporte )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cwalletbalancesestadoope Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCWALLETBALANCESESTADOOPE"), AV11cWalletBalancesEstadoOPE) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19AU2 ();
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

      protected void WEAU2( )
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

      protected void PAAU2( )
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
                                        long AV6cWalletBalancesId ,
                                        DateTime AV7cWalletBalancesFechaAlta ,
                                        long AV8cWalletBalancesUsrAlta ,
                                        string AV9cWalletBalancesTipoMov ,
                                        decimal AV10cWalletBalancesImporte ,
                                        string AV11cWalletBalancesEstadoOPE ,
                                        long AV12pWalletId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFAU2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, ".", "")));
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
         if ( cmbavCwalletbalancestipomov.ItemCount > 0 )
         {
            AV9cWalletBalancesTipoMov = cmbavCwalletbalancestipomov.getValidValue(AV9cWalletBalancesTipoMov);
            AssignAttri("", false, "AV9cWalletBalancesTipoMov", AV9cWalletBalancesTipoMov);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCwalletbalancestipomov.CurrentValue = StringUtil.RTrim( AV9cWalletBalancesTipoMov);
            AssignProp("", false, cmbavCwalletbalancestipomov_Internalname, "Values", cmbavCwalletbalancestipomov.ToJavascriptSource(), true);
         }
         if ( cmbavCwalletbalancesestadoope.ItemCount > 0 )
         {
            AV11cWalletBalancesEstadoOPE = cmbavCwalletbalancesestadoope.getValidValue(AV11cWalletBalancesEstadoOPE);
            AssignAttri("", false, "AV11cWalletBalancesEstadoOPE", AV11cWalletBalancesEstadoOPE);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCwalletbalancesestadoope.CurrentValue = StringUtil.RTrim( AV11cWalletBalancesEstadoOPE);
            AssignProp("", false, cmbavCwalletbalancesestadoope_Internalname, "Values", cmbavCwalletbalancesestadoope.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAU2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAU2( )
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
                                                 AV7cWalletBalancesFechaAlta ,
                                                 AV8cWalletBalancesUsrAlta ,
                                                 AV9cWalletBalancesTipoMov ,
                                                 AV10cWalletBalancesImporte ,
                                                 AV11cWalletBalancesEstadoOPE ,
                                                 A641WalletBalancesFechaAlta ,
                                                 A642WalletBalancesUsrAlta ,
                                                 A643WalletBalancesTipoMov ,
                                                 A644WalletBalancesImporte ,
                                                 A645WalletBalancesEstadoOPE ,
                                                 AV12pWalletId ,
                                                 AV6cWalletBalancesId ,
                                                 A637WalletId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV9cWalletBalancesTipoMov = StringUtil.PadR( StringUtil.RTrim( AV9cWalletBalancesTipoMov), 3, "%");
            lV11cWalletBalancesEstadoOPE = StringUtil.PadR( StringUtil.RTrim( AV11cWalletBalancesEstadoOPE), 3, "%");
            /* Using cursor H00AU2 */
            pr_default.execute(0, new Object[] {AV12pWalletId, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, lV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, lV11cWalletBalancesEstadoOPE, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A637WalletId = H00AU2_A637WalletId[0];
               A1010WalletBalancesConcepto = H00AU2_A1010WalletBalancesConcepto[0];
               n1010WalletBalancesConcepto = H00AU2_n1010WalletBalancesConcepto[0];
               A645WalletBalancesEstadoOPE = H00AU2_A645WalletBalancesEstadoOPE[0];
               A644WalletBalancesImporte = H00AU2_A644WalletBalancesImporte[0];
               A643WalletBalancesTipoMov = H00AU2_A643WalletBalancesTipoMov[0];
               A642WalletBalancesUsrAlta = H00AU2_A642WalletBalancesUsrAlta[0];
               A641WalletBalancesFechaAlta = H00AU2_A641WalletBalancesFechaAlta[0];
               A640WalletBalancesId = H00AU2_A640WalletBalancesId[0];
               /* Execute user event: Load */
               E18AU2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBAU0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesAU2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETBALANCESID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cWalletBalancesFechaAlta ,
                                              AV8cWalletBalancesUsrAlta ,
                                              AV9cWalletBalancesTipoMov ,
                                              AV10cWalletBalancesImporte ,
                                              AV11cWalletBalancesEstadoOPE ,
                                              A641WalletBalancesFechaAlta ,
                                              A642WalletBalancesUsrAlta ,
                                              A643WalletBalancesTipoMov ,
                                              A644WalletBalancesImporte ,
                                              A645WalletBalancesEstadoOPE ,
                                              AV12pWalletId ,
                                              AV6cWalletBalancesId ,
                                              A637WalletId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV9cWalletBalancesTipoMov = StringUtil.PadR( StringUtil.RTrim( AV9cWalletBalancesTipoMov), 3, "%");
         lV11cWalletBalancesEstadoOPE = StringUtil.PadR( StringUtil.RTrim( AV11cWalletBalancesEstadoOPE), 3, "%");
         /* Using cursor H00AU3 */
         pr_default.execute(1, new Object[] {AV12pWalletId, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, lV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, lV11cWalletBalancesEstadoOPE});
         GRID1_nRecordCount = H00AU3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, AV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, AV11cWalletBalancesEstadoOPE, AV12pWalletId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, AV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, AV11cWalletBalancesEstadoOPE, AV12pWalletId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, AV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, AV11cWalletBalancesEstadoOPE, AV12pWalletId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, AV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, AV11cWalletBalancesEstadoOPE, AV12pWalletId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cWalletBalancesId, AV7cWalletBalancesFechaAlta, AV8cWalletBalancesUsrAlta, AV9cWalletBalancesTipoMov, AV10cWalletBalancesImporte, AV11cWalletBalancesEstadoOPE, AV12pWalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtWalletBalancesId_Enabled = 0;
         edtWalletBalancesFechaAlta_Enabled = 0;
         edtWalletBalancesUsrAlta_Enabled = 0;
         cmbWalletBalancesTipoMov.Enabled = 0;
         edtWalletBalancesImporte_Enabled = 0;
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         cmbWalletBalancesConcepto.Enabled = 0;
         edtWalletId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAU0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17AU2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwalletbalancesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwalletbalancesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWALLETBALANCESID");
               GX_FocusControl = edtavCwalletbalancesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cWalletBalancesId = 0;
               AssignAttri("", false, "AV6cWalletBalancesId", StringUtil.LTrimStr( (decimal)(AV6cWalletBalancesId), 18, 0));
            }
            else
            {
               AV6cWalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwalletbalancesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cWalletBalancesId", StringUtil.LTrimStr( (decimal)(AV6cWalletBalancesId), 18, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCwalletbalancesfechaalta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha de Alta", "")}), 1, "vCWALLETBALANCESFECHAALTA");
               GX_FocusControl = edtavCwalletbalancesfechaalta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cWalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV7cWalletBalancesFechaAlta", context.localUtil.TToC( AV7cWalletBalancesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV7cWalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtavCwalletbalancesfechaalta_Internalname));
               AssignAttri("", false, "AV7cWalletBalancesFechaAlta", context.localUtil.TToC( AV7cWalletBalancesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwalletbalancesusralta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwalletbalancesusralta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWALLETBALANCESUSRALTA");
               GX_FocusControl = edtavCwalletbalancesusralta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cWalletBalancesUsrAlta = 0;
               AssignAttri("", false, "AV8cWalletBalancesUsrAlta", StringUtil.LTrimStr( (decimal)(AV8cWalletBalancesUsrAlta), 10, 0));
            }
            else
            {
               AV8cWalletBalancesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCwalletbalancesusralta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cWalletBalancesUsrAlta", StringUtil.LTrimStr( (decimal)(AV8cWalletBalancesUsrAlta), 10, 0));
            }
            cmbavCwalletbalancestipomov.Name = cmbavCwalletbalancestipomov_Internalname;
            cmbavCwalletbalancestipomov.CurrentValue = cgiGet( cmbavCwalletbalancestipomov_Internalname);
            AV9cWalletBalancesTipoMov = cgiGet( cmbavCwalletbalancestipomov_Internalname);
            AssignAttri("", false, "AV9cWalletBalancesTipoMov", AV9cWalletBalancesTipoMov);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCwalletbalancesimporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCwalletbalancesimporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCWALLETBALANCESIMPORTE");
               GX_FocusControl = edtavCwalletbalancesimporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cWalletBalancesImporte = 0;
               AssignAttri("", false, "AV10cWalletBalancesImporte", StringUtil.LTrimStr( AV10cWalletBalancesImporte, 18, 2));
            }
            else
            {
               AV10cWalletBalancesImporte = context.localUtil.CToN( cgiGet( edtavCwalletbalancesimporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10cWalletBalancesImporte", StringUtil.LTrimStr( AV10cWalletBalancesImporte, 18, 2));
            }
            cmbavCwalletbalancesestadoope.Name = cmbavCwalletbalancesestadoope_Internalname;
            cmbavCwalletbalancesestadoope.CurrentValue = cgiGet( cmbavCwalletbalancesestadoope_Internalname);
            AV11cWalletBalancesEstadoOPE = cgiGet( cmbavCwalletbalancesestadoope_Internalname);
            AssignAttri("", false, "AV11cWalletBalancesEstadoOPE", AV11cWalletBalancesEstadoOPE);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWALLETBALANCESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cWalletBalancesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCWALLETBALANCESFECHAALTA")) != AV7cWalletBalancesFechaAlta )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCWALLETBALANCESUSRALTA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cWalletBalancesUsrAlta )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWALLETBALANCESTIPOMOV"), AV9cWalletBalancesTipoMov) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCWALLETBALANCESIMPORTE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cWalletBalancesImporte )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCWALLETBALANCESESTADOOPE"), AV11cWalletBalancesEstadoOPE) != 0 )
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
         E17AU2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17AU2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Balances", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18AU2( )
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
         E19AU2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19AU2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pWalletBalancesId = A640WalletBalancesId;
         AssignAttri("", false, "AV13pWalletBalancesId", StringUtil.LTrimStr( (decimal)(AV13pWalletBalancesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pWalletBalancesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pWalletBalancesId"});
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
         AV12pWalletId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pWalletId", StringUtil.LTrimStr( (decimal)(AV12pWalletId), 18, 0));
         AV13pWalletBalancesId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pWalletBalancesId", StringUtil.LTrimStr( (decimal)(AV13pWalletBalancesId), 18, 0));
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
         PAAU2( ) ;
         WSAU2( ) ;
         WEAU2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821405227", true, true, false);
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
         context.AddJavascriptSource("gx02l1.js", "?202692821405228", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtWalletBalancesId_Internalname = "WALLETBALANCESID_"+sGXsfl_74_idx;
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA_"+sGXsfl_74_idx;
         edtWalletBalancesUsrAlta_Internalname = "WALLETBALANCESUSRALTA_"+sGXsfl_74_idx;
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV_"+sGXsfl_74_idx;
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE_"+sGXsfl_74_idx;
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE_"+sGXsfl_74_idx;
         cmbWalletBalancesConcepto_Internalname = "WALLETBALANCESCONCEPTO_"+sGXsfl_74_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtWalletBalancesId_Internalname = "WALLETBALANCESID_"+sGXsfl_74_fel_idx;
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA_"+sGXsfl_74_fel_idx;
         edtWalletBalancesUsrAlta_Internalname = "WALLETBALANCESUSRALTA_"+sGXsfl_74_fel_idx;
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV_"+sGXsfl_74_fel_idx;
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE_"+sGXsfl_74_fel_idx;
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE_"+sGXsfl_74_fel_idx;
         cmbWalletBalancesConcepto_Internalname = "WALLETBALANCESCONCEPTO_"+sGXsfl_74_fel_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBAU0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtWalletBalancesFechaAlta_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtWalletBalancesFechaAlta_Internalname, "Link", edtWalletBalancesFechaAlta_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesFechaAlta_Internalname,context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A641WalletBalancesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWalletBalancesFechaAlta_Link,(string)"",(string)"",(string)"",(string)edtWalletBalancesFechaAlta_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesUsrAlta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A642WalletBalancesUsrAlta), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"UserID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWalletBalancesTipoMov.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETBALANCESTIPOMOV_" + sGXsfl_74_idx;
               cmbWalletBalancesTipoMov.Name = GXCCtl;
               cmbWalletBalancesTipoMov.WebTags = "";
               cmbWalletBalancesTipoMov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
               cmbWalletBalancesTipoMov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
               if ( cmbWalletBalancesTipoMov.ItemCount > 0 )
               {
                  A643WalletBalancesTipoMov = cmbWalletBalancesTipoMov.getValidValue(A643WalletBalancesTipoMov);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesTipoMov,(string)cmbWalletBalancesTipoMov_Internalname,StringUtil.RTrim( A643WalletBalancesTipoMov),(short)1,(string)cmbWalletBalancesTipoMov_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletBalancesTipoMov.CurrentValue = StringUtil.RTrim( A643WalletBalancesTipoMov);
            AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Values", (string)(cmbWalletBalancesTipoMov.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesImporte_Internalname,StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesImporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWalletBalancesEstadoOPE.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETBALANCESESTADOOPE_" + sGXsfl_74_idx;
               cmbWalletBalancesEstadoOPE.Name = GXCCtl;
               cmbWalletBalancesEstadoOPE.WebTags = "";
               cmbWalletBalancesEstadoOPE.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbWalletBalancesEstadoOPE.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbWalletBalancesEstadoOPE.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbWalletBalancesEstadoOPE.ItemCount > 0 )
               {
                  A645WalletBalancesEstadoOPE = cmbWalletBalancesEstadoOPE.getValidValue(A645WalletBalancesEstadoOPE);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesEstadoOPE,(string)cmbWalletBalancesEstadoOPE_Internalname,StringUtil.RTrim( A645WalletBalancesEstadoOPE),(short)1,(string)cmbWalletBalancesEstadoOPE_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletBalancesEstadoOPE.CurrentValue = StringUtil.RTrim( A645WalletBalancesEstadoOPE);
            AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Values", (string)(cmbWalletBalancesEstadoOPE.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWalletBalancesConcepto.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETBALANCESCONCEPTO_" + sGXsfl_74_idx;
               cmbWalletBalancesConcepto.Name = GXCCtl;
               cmbWalletBalancesConcepto.WebTags = "";
               cmbWalletBalancesConcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
               cmbWalletBalancesConcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
               cmbWalletBalancesConcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
               cmbWalletBalancesConcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
               cmbWalletBalancesConcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
               cmbWalletBalancesConcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
               if ( cmbWalletBalancesConcepto.ItemCount > 0 )
               {
                  A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbWalletBalancesConcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  n1010WalletBalancesConcepto = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesConcepto,(string)cmbWalletBalancesConcepto_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0)),(short)1,(string)cmbWalletBalancesConcepto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletBalancesConcepto.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0));
            AssignProp("", false, cmbWalletBalancesConcepto_Internalname, "Values", (string)(cmbWalletBalancesConcepto.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesAU2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCwalletbalancestipomov.Name = "vCWALLETBALANCESTIPOMOV";
         cmbavCwalletbalancestipomov.WebTags = "";
         cmbavCwalletbalancestipomov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
         cmbavCwalletbalancestipomov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
         if ( cmbavCwalletbalancestipomov.ItemCount > 0 )
         {
            AV9cWalletBalancesTipoMov = cmbavCwalletbalancestipomov.getValidValue(AV9cWalletBalancesTipoMov);
            AssignAttri("", false, "AV9cWalletBalancesTipoMov", AV9cWalletBalancesTipoMov);
         }
         cmbavCwalletbalancesestadoope.Name = "vCWALLETBALANCESESTADOOPE";
         cmbavCwalletbalancesestadoope.WebTags = "";
         cmbavCwalletbalancesestadoope.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbavCwalletbalancesestadoope.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbavCwalletbalancesestadoope.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbavCwalletbalancesestadoope.ItemCount > 0 )
         {
            AV11cWalletBalancesEstadoOPE = cmbavCwalletbalancesestadoope.getValidValue(AV11cWalletBalancesEstadoOPE);
            AssignAttri("", false, "AV11cWalletBalancesEstadoOPE", AV11cWalletBalancesEstadoOPE);
         }
         GXCCtl = "WALLETBALANCESTIPOMOV_" + sGXsfl_74_idx;
         cmbWalletBalancesTipoMov.Name = GXCCtl;
         cmbWalletBalancesTipoMov.WebTags = "";
         cmbWalletBalancesTipoMov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
         cmbWalletBalancesTipoMov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
         if ( cmbWalletBalancesTipoMov.ItemCount > 0 )
         {
            A643WalletBalancesTipoMov = cmbWalletBalancesTipoMov.getValidValue(A643WalletBalancesTipoMov);
         }
         GXCCtl = "WALLETBALANCESESTADOOPE_" + sGXsfl_74_idx;
         cmbWalletBalancesEstadoOPE.Name = GXCCtl;
         cmbWalletBalancesEstadoOPE.WebTags = "";
         cmbWalletBalancesEstadoOPE.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbWalletBalancesEstadoOPE.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbWalletBalancesEstadoOPE.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbWalletBalancesEstadoOPE.ItemCount > 0 )
         {
            A645WalletBalancesEstadoOPE = cmbWalletBalancesEstadoOPE.getValidValue(A645WalletBalancesEstadoOPE);
         }
         GXCCtl = "WALLETBALANCESCONCEPTO_" + sGXsfl_74_idx;
         cmbWalletBalancesConcepto.Name = GXCCtl;
         cmbWalletBalancesConcepto.WebTags = "";
         cmbWalletBalancesConcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
         cmbWalletBalancesConcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
         cmbWalletBalancesConcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
         cmbWalletBalancesConcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
         cmbWalletBalancesConcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
         cmbWalletBalancesConcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
         if ( cmbWalletBalancesConcepto.ItemCount > 0 )
         {
            A1010WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbWalletBalancesConcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1010WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n1010WalletBalancesConcepto = false;
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
            context.SendWebValue( context.GetMessage( "Operación Nro.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Movimiento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Importe", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Balances Concepto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Wallet Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtWalletBalancesFechaAlta_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A642WalletBalancesUsrAlta), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A643WalletBalancesTipoMov)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A645WalletBalancesEstadoOPE)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010WalletBalancesConcepto), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", ""))));
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
         lblLblwalletbalancesidfilter_Internalname = "LBLWALLETBALANCESIDFILTER";
         edtavCwalletbalancesid_Internalname = "vCWALLETBALANCESID";
         divWalletbalancesidfiltercontainer_Internalname = "WALLETBALANCESIDFILTERCONTAINER";
         lblLblwalletbalancesfechaaltafilter_Internalname = "LBLWALLETBALANCESFECHAALTAFILTER";
         edtavCwalletbalancesfechaalta_Internalname = "vCWALLETBALANCESFECHAALTA";
         divWalletbalancesfechaaltafiltercontainer_Internalname = "WALLETBALANCESFECHAALTAFILTERCONTAINER";
         lblLblwalletbalancesusraltafilter_Internalname = "LBLWALLETBALANCESUSRALTAFILTER";
         edtavCwalletbalancesusralta_Internalname = "vCWALLETBALANCESUSRALTA";
         divWalletbalancesusraltafiltercontainer_Internalname = "WALLETBALANCESUSRALTAFILTERCONTAINER";
         lblLblwalletbalancestipomovfilter_Internalname = "LBLWALLETBALANCESTIPOMOVFILTER";
         cmbavCwalletbalancestipomov_Internalname = "vCWALLETBALANCESTIPOMOV";
         divWalletbalancestipomovfiltercontainer_Internalname = "WALLETBALANCESTIPOMOVFILTERCONTAINER";
         lblLblwalletbalancesimportefilter_Internalname = "LBLWALLETBALANCESIMPORTEFILTER";
         edtavCwalletbalancesimporte_Internalname = "vCWALLETBALANCESIMPORTE";
         divWalletbalancesimportefiltercontainer_Internalname = "WALLETBALANCESIMPORTEFILTERCONTAINER";
         lblLblwalletbalancesestadoopefilter_Internalname = "LBLWALLETBALANCESESTADOOPEFILTER";
         cmbavCwalletbalancesestadoope_Internalname = "vCWALLETBALANCESESTADOOPE";
         divWalletbalancesestadoopefiltercontainer_Internalname = "WALLETBALANCESESTADOOPEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtWalletBalancesId_Internalname = "WALLETBALANCESID";
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA";
         edtWalletBalancesUsrAlta_Internalname = "WALLETBALANCESUSRALTA";
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV";
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE";
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE";
         cmbWalletBalancesConcepto_Internalname = "WALLETBALANCESCONCEPTO";
         edtWalletId_Internalname = "WALLETID";
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
         edtWalletId_Jsonclick = "";
         cmbWalletBalancesConcepto_Jsonclick = "";
         cmbWalletBalancesEstadoOPE_Jsonclick = "";
         edtWalletBalancesImporte_Jsonclick = "";
         cmbWalletBalancesTipoMov_Jsonclick = "";
         edtWalletBalancesUsrAlta_Jsonclick = "";
         edtWalletBalancesFechaAlta_Jsonclick = "";
         edtWalletBalancesFechaAlta_Link = "";
         edtWalletBalancesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtWalletId_Enabled = 0;
         cmbWalletBalancesConcepto.Enabled = 0;
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         edtWalletBalancesImporte_Enabled = 0;
         cmbWalletBalancesTipoMov.Enabled = 0;
         edtWalletBalancesUsrAlta_Enabled = 0;
         edtWalletBalancesFechaAlta_Enabled = 0;
         edtWalletBalancesId_Enabled = 0;
         cmbavCwalletbalancesestadoope_Jsonclick = "";
         cmbavCwalletbalancesestadoope.Visible = 1;
         cmbavCwalletbalancesestadoope.Enabled = 1;
         edtavCwalletbalancesimporte_Jsonclick = "";
         edtavCwalletbalancesimporte_Enabled = 1;
         edtavCwalletbalancesimporte_Visible = 1;
         cmbavCwalletbalancestipomov_Jsonclick = "";
         cmbavCwalletbalancestipomov.Visible = 1;
         cmbavCwalletbalancestipomov.Enabled = 1;
         edtavCwalletbalancesusralta_Jsonclick = "";
         edtavCwalletbalancesusralta_Enabled = 1;
         edtavCwalletbalancesusralta_Visible = 1;
         edtavCwalletbalancesfechaalta_Jsonclick = "";
         edtavCwalletbalancesfechaalta_Enabled = 1;
         edtavCwalletbalancesid_Jsonclick = "";
         edtavCwalletbalancesid_Enabled = 1;
         edtavCwalletbalancesid_Visible = 1;
         divWalletbalancesestadoopefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWalletbalancesimportefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWalletbalancestipomovfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWalletbalancesusraltafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divWalletbalancesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Balances", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWalletBalancesId',fld:'vCWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cWalletBalancesFechaAlta',fld:'vCWALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV8cWalletBalancesUsrAlta',fld:'vCWALLETBALANCESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwalletbalancestipomov'},{av:'AV9cWalletBalancesTipoMov',fld:'vCWALLETBALANCESTIPOMOV',pic:'',type:'char'},{av:'AV10cWalletBalancesImporte',fld:'vCWALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCwalletbalancesestadoope'},{av:'AV11cWalletBalancesEstadoOPE',fld:'vCWALLETBALANCESESTADOOPE',pic:'',type:'char'},{av:'AV12pWalletId',fld:'vPWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16AU1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLWALLETBALANCESIDFILTER.CLICK","{handler:'E11AU1',iparms:[{av:'divWalletbalancesidfiltercontainer_Class',ctrl:'WALLETBALANCESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWALLETBALANCESIDFILTER.CLICK",",oparms:[{av:'divWalletbalancesidfiltercontainer_Class',ctrl:'WALLETBALANCESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCwalletbalancesid_Visible',ctrl:'vCWALLETBALANCESID',prop:'Visible'}]}");
         setEventMetadata("LBLWALLETBALANCESUSRALTAFILTER.CLICK","{handler:'E12AU1',iparms:[{av:'divWalletbalancesusraltafiltercontainer_Class',ctrl:'WALLETBALANCESUSRALTAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWALLETBALANCESUSRALTAFILTER.CLICK",",oparms:[{av:'divWalletbalancesusraltafiltercontainer_Class',ctrl:'WALLETBALANCESUSRALTAFILTERCONTAINER',prop:'Class'},{av:'edtavCwalletbalancesusralta_Visible',ctrl:'vCWALLETBALANCESUSRALTA',prop:'Visible'}]}");
         setEventMetadata("LBLWALLETBALANCESTIPOMOVFILTER.CLICK","{handler:'E13AU1',iparms:[{av:'divWalletbalancestipomovfiltercontainer_Class',ctrl:'WALLETBALANCESTIPOMOVFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWALLETBALANCESTIPOMOVFILTER.CLICK",",oparms:[{av:'divWalletbalancestipomovfiltercontainer_Class',ctrl:'WALLETBALANCESTIPOMOVFILTERCONTAINER',prop:'Class'},{av:'cmbavCwalletbalancestipomov'}]}");
         setEventMetadata("LBLWALLETBALANCESIMPORTEFILTER.CLICK","{handler:'E14AU1',iparms:[{av:'divWalletbalancesimportefiltercontainer_Class',ctrl:'WALLETBALANCESIMPORTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWALLETBALANCESIMPORTEFILTER.CLICK",",oparms:[{av:'divWalletbalancesimportefiltercontainer_Class',ctrl:'WALLETBALANCESIMPORTEFILTERCONTAINER',prop:'Class'},{av:'edtavCwalletbalancesimporte_Visible',ctrl:'vCWALLETBALANCESIMPORTE',prop:'Visible'}]}");
         setEventMetadata("LBLWALLETBALANCESESTADOOPEFILTER.CLICK","{handler:'E15AU1',iparms:[{av:'divWalletbalancesestadoopefiltercontainer_Class',ctrl:'WALLETBALANCESESTADOOPEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLWALLETBALANCESESTADOOPEFILTER.CLICK",",oparms:[{av:'divWalletbalancesestadoopefiltercontainer_Class',ctrl:'WALLETBALANCESESTADOOPEFILTERCONTAINER',prop:'Class'},{av:'cmbavCwalletbalancesestadoope'}]}");
         setEventMetadata("ENTER","{handler:'E19AU2',iparms:[{av:'A640WalletBalancesId',fld:'WALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pWalletBalancesId',fld:'vPWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWalletBalancesId',fld:'vCWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cWalletBalancesFechaAlta',fld:'vCWALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV8cWalletBalancesUsrAlta',fld:'vCWALLETBALANCESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwalletbalancestipomov'},{av:'AV9cWalletBalancesTipoMov',fld:'vCWALLETBALANCESTIPOMOV',pic:'',type:'char'},{av:'AV10cWalletBalancesImporte',fld:'vCWALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCwalletbalancesestadoope'},{av:'AV11cWalletBalancesEstadoOPE',fld:'vCWALLETBALANCESESTADOOPE',pic:'',type:'char'},{av:'AV12pWalletId',fld:'vPWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWalletBalancesId',fld:'vCWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cWalletBalancesFechaAlta',fld:'vCWALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV8cWalletBalancesUsrAlta',fld:'vCWALLETBALANCESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwalletbalancestipomov'},{av:'AV9cWalletBalancesTipoMov',fld:'vCWALLETBALANCESTIPOMOV',pic:'',type:'char'},{av:'AV10cWalletBalancesImporte',fld:'vCWALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCwalletbalancesestadoope'},{av:'AV11cWalletBalancesEstadoOPE',fld:'vCWALLETBALANCESESTADOOPE',pic:'',type:'char'},{av:'AV12pWalletId',fld:'vPWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWalletBalancesId',fld:'vCWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cWalletBalancesFechaAlta',fld:'vCWALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV8cWalletBalancesUsrAlta',fld:'vCWALLETBALANCESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwalletbalancestipomov'},{av:'AV9cWalletBalancesTipoMov',fld:'vCWALLETBALANCESTIPOMOV',pic:'',type:'char'},{av:'AV10cWalletBalancesImporte',fld:'vCWALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCwalletbalancesestadoope'},{av:'AV11cWalletBalancesEstadoOPE',fld:'vCWALLETBALANCESESTADOOPE',pic:'',type:'char'},{av:'AV12pWalletId',fld:'vPWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cWalletBalancesId',fld:'vCWALLETBALANCESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cWalletBalancesFechaAlta',fld:'vCWALLETBALANCESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV8cWalletBalancesUsrAlta',fld:'vCWALLETBALANCESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'cmbavCwalletbalancestipomov'},{av:'AV9cWalletBalancesTipoMov',fld:'vCWALLETBALANCESTIPOMOV',pic:'',type:'char'},{av:'AV10cWalletBalancesImporte',fld:'vCWALLETBALANCESIMPORTE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCwalletbalancesestadoope'},{av:'AV11cWalletBalancesEstadoOPE',fld:'vCWALLETBALANCESESTADOOPE',pic:'',type:'char'},{av:'AV12pWalletId',fld:'vPWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CWALLETBALANCESFECHAALTA","{handler:'Validv_Cwalletbalancesfechaalta',iparms:[]");
         setEventMetadata("VALIDV_CWALLETBALANCESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALIDV_CWALLETBALANCESTIPOMOV","{handler:'Validv_Cwalletbalancestipomov',iparms:[]");
         setEventMetadata("VALIDV_CWALLETBALANCESTIPOMOV",",oparms:[]}");
         setEventMetadata("VALIDV_CWALLETBALANCESESTADOOPE","{handler:'Validv_Cwalletbalancesestadoope',iparms:[]");
         setEventMetadata("VALIDV_CWALLETBALANCESESTADOOPE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Walletid',iparms:[]");
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
         AV7cWalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         AV9cWalletBalancesTipoMov = "";
         AV11cWalletBalancesEstadoOPE = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblwalletbalancesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblwalletbalancesfechaaltafilter_Jsonclick = "";
         lblLblwalletbalancesusraltafilter_Jsonclick = "";
         lblLblwalletbalancestipomovfilter_Jsonclick = "";
         lblLblwalletbalancesimportefilter_Jsonclick = "";
         lblLblwalletbalancesestadoopefilter_Jsonclick = "";
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
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A643WalletBalancesTipoMov = "";
         A645WalletBalancesEstadoOPE = "";
         lV9cWalletBalancesTipoMov = "";
         lV11cWalletBalancesEstadoOPE = "";
         H00AU2_A637WalletId = new long[1] ;
         H00AU2_A1010WalletBalancesConcepto = new short[1] ;
         H00AU2_n1010WalletBalancesConcepto = new bool[] {false} ;
         H00AU2_A645WalletBalancesEstadoOPE = new string[] {""} ;
         H00AU2_A644WalletBalancesImporte = new decimal[1] ;
         H00AU2_A643WalletBalancesTipoMov = new string[] {""} ;
         H00AU2_A642WalletBalancesUsrAlta = new long[1] ;
         H00AU2_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00AU2_A640WalletBalancesId = new long[1] ;
         H00AU3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx02l1__default(),
            new Object[][] {
                new Object[] {
               H00AU2_A637WalletId, H00AU2_A1010WalletBalancesConcepto, H00AU2_n1010WalletBalancesConcepto, H00AU2_A645WalletBalancesEstadoOPE, H00AU2_A644WalletBalancesImporte, H00AU2_A643WalletBalancesTipoMov, H00AU2_A642WalletBalancesUsrAlta, H00AU2_A641WalletBalancesFechaAlta, H00AU2_A640WalletBalancesId
               }
               , new Object[] {
               H00AU3_AGRID1_nRecordCount
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
      private short A1010WalletBalancesConcepto ;
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
      private int edtavCwalletbalancesid_Enabled ;
      private int edtavCwalletbalancesid_Visible ;
      private int edtavCwalletbalancesfechaalta_Enabled ;
      private int edtavCwalletbalancesusralta_Enabled ;
      private int edtavCwalletbalancesusralta_Visible ;
      private int edtavCwalletbalancesimporte_Enabled ;
      private int edtavCwalletbalancesimporte_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWalletBalancesId_Enabled ;
      private int edtWalletBalancesFechaAlta_Enabled ;
      private int edtWalletBalancesUsrAlta_Enabled ;
      private int edtWalletBalancesImporte_Enabled ;
      private int edtWalletId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pWalletId ;
      private long AV13pWalletBalancesId ;
      private long wcpOAV12pWalletId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cWalletBalancesId ;
      private long AV8cWalletBalancesUsrAlta ;
      private long A640WalletBalancesId ;
      private long A642WalletBalancesUsrAlta ;
      private long A637WalletId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV10cWalletBalancesImporte ;
      private decimal A644WalletBalancesImporte ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divWalletbalancesidfiltercontainer_Class ;
      private string divWalletbalancesusraltafiltercontainer_Class ;
      private string divWalletbalancestipomovfiltercontainer_Class ;
      private string divWalletbalancesimportefiltercontainer_Class ;
      private string divWalletbalancesestadoopefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV9cWalletBalancesTipoMov ;
      private string AV11cWalletBalancesEstadoOPE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divWalletbalancesidfiltercontainer_Internalname ;
      private string lblLblwalletbalancesidfilter_Internalname ;
      private string lblLblwalletbalancesidfilter_Jsonclick ;
      private string edtavCwalletbalancesid_Internalname ;
      private string TempTags ;
      private string edtavCwalletbalancesid_Jsonclick ;
      private string divWalletbalancesfechaaltafiltercontainer_Internalname ;
      private string lblLblwalletbalancesfechaaltafilter_Internalname ;
      private string lblLblwalletbalancesfechaaltafilter_Jsonclick ;
      private string edtavCwalletbalancesfechaalta_Internalname ;
      private string edtavCwalletbalancesfechaalta_Jsonclick ;
      private string divWalletbalancesusraltafiltercontainer_Internalname ;
      private string lblLblwalletbalancesusraltafilter_Internalname ;
      private string lblLblwalletbalancesusraltafilter_Jsonclick ;
      private string edtavCwalletbalancesusralta_Internalname ;
      private string edtavCwalletbalancesusralta_Jsonclick ;
      private string divWalletbalancestipomovfiltercontainer_Internalname ;
      private string lblLblwalletbalancestipomovfilter_Internalname ;
      private string lblLblwalletbalancestipomovfilter_Jsonclick ;
      private string cmbavCwalletbalancestipomov_Internalname ;
      private string cmbavCwalletbalancestipomov_Jsonclick ;
      private string divWalletbalancesimportefiltercontainer_Internalname ;
      private string lblLblwalletbalancesimportefilter_Internalname ;
      private string lblLblwalletbalancesimportefilter_Jsonclick ;
      private string edtavCwalletbalancesimporte_Internalname ;
      private string edtavCwalletbalancesimporte_Jsonclick ;
      private string divWalletbalancesestadoopefiltercontainer_Internalname ;
      private string lblLblwalletbalancesestadoopefilter_Internalname ;
      private string lblLblwalletbalancesestadoopefilter_Jsonclick ;
      private string cmbavCwalletbalancesestadoope_Internalname ;
      private string cmbavCwalletbalancesestadoope_Jsonclick ;
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
      private string edtWalletBalancesId_Internalname ;
      private string edtWalletBalancesFechaAlta_Internalname ;
      private string edtWalletBalancesUsrAlta_Internalname ;
      private string cmbWalletBalancesTipoMov_Internalname ;
      private string A643WalletBalancesTipoMov ;
      private string edtWalletBalancesImporte_Internalname ;
      private string cmbWalletBalancesEstadoOPE_Internalname ;
      private string A645WalletBalancesEstadoOPE ;
      private string cmbWalletBalancesConcepto_Internalname ;
      private string edtWalletId_Internalname ;
      private string lV9cWalletBalancesTipoMov ;
      private string lV11cWalletBalancesEstadoOPE ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtWalletBalancesId_Jsonclick ;
      private string edtWalletBalancesFechaAlta_Link ;
      private string edtWalletBalancesFechaAlta_Jsonclick ;
      private string edtWalletBalancesUsrAlta_Jsonclick ;
      private string GXCCtl ;
      private string cmbWalletBalancesTipoMov_Jsonclick ;
      private string edtWalletBalancesImporte_Jsonclick ;
      private string cmbWalletBalancesEstadoOPE_Jsonclick ;
      private string cmbWalletBalancesConcepto_Jsonclick ;
      private string edtWalletId_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV7cWalletBalancesFechaAlta ;
      private DateTime A641WalletBalancesFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n1010WalletBalancesConcepto ;
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
      private GXCombobox cmbavCwalletbalancestipomov ;
      private GXCombobox cmbavCwalletbalancesestadoope ;
      private GXCombobox cmbWalletBalancesTipoMov ;
      private GXCombobox cmbWalletBalancesEstadoOPE ;
      private GXCombobox cmbWalletBalancesConcepto ;
      private IDataStoreProvider pr_default ;
      private long[] H00AU2_A637WalletId ;
      private short[] H00AU2_A1010WalletBalancesConcepto ;
      private bool[] H00AU2_n1010WalletBalancesConcepto ;
      private string[] H00AU2_A645WalletBalancesEstadoOPE ;
      private decimal[] H00AU2_A644WalletBalancesImporte ;
      private string[] H00AU2_A643WalletBalancesTipoMov ;
      private long[] H00AU2_A642WalletBalancesUsrAlta ;
      private DateTime[] H00AU2_A641WalletBalancesFechaAlta ;
      private long[] H00AU2_A640WalletBalancesId ;
      private long[] H00AU3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pWalletBalancesId ;
   }

   public class gx02l1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00AU2( IGxContext context ,
                                             DateTime AV7cWalletBalancesFechaAlta ,
                                             long AV8cWalletBalancesUsrAlta ,
                                             string AV9cWalletBalancesTipoMov ,
                                             decimal AV10cWalletBalancesImporte ,
                                             string AV11cWalletBalancesEstadoOPE ,
                                             DateTime A641WalletBalancesFechaAlta ,
                                             long A642WalletBalancesUsrAlta ,
                                             string A643WalletBalancesTipoMov ,
                                             decimal A644WalletBalancesImporte ,
                                             string A645WalletBalancesEstadoOPE ,
                                             long AV12pWalletId ,
                                             long AV6cWalletBalancesId ,
                                             long A637WalletId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [WalletId], [WalletBalancesConcepto], [WalletBalancesEstadoOPE], [WalletBalancesImporte], [WalletBalancesTipoMov], [WalletBalancesUsrAlta], [WalletBalancesFechaAlta], [WalletBalancesId]";
         sFromString = " FROM [WalletBalances]";
         sOrderString = "";
         AddWhere(sWhereString, "([WalletId] = @AV12pWalletId and [WalletBalancesId] >= @AV6cWalletBalancesId)");
         if ( ! (DateTime.MinValue==AV7cWalletBalancesFechaAlta) )
         {
            AddWhere(sWhereString, "([WalletBalancesFechaAlta] >= @AV7cWalletBalancesFechaAlta)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8cWalletBalancesUsrAlta) )
         {
            AddWhere(sWhereString, "([WalletBalancesUsrAlta] >= @AV8cWalletBalancesUsrAlta)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWalletBalancesTipoMov)) )
         {
            AddWhere(sWhereString, "([WalletBalancesTipoMov] like @lV9cWalletBalancesTipoMov)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cWalletBalancesImporte) )
         {
            AddWhere(sWhereString, "([WalletBalancesImporte] >= @AV10cWalletBalancesImporte)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cWalletBalancesEstadoOPE)) )
         {
            AddWhere(sWhereString, "([WalletBalancesEstadoOPE] like @lV11cWalletBalancesEstadoOPE)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [WalletId], [WalletBalancesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00AU3( IGxContext context ,
                                             DateTime AV7cWalletBalancesFechaAlta ,
                                             long AV8cWalletBalancesUsrAlta ,
                                             string AV9cWalletBalancesTipoMov ,
                                             decimal AV10cWalletBalancesImporte ,
                                             string AV11cWalletBalancesEstadoOPE ,
                                             DateTime A641WalletBalancesFechaAlta ,
                                             long A642WalletBalancesUsrAlta ,
                                             string A643WalletBalancesTipoMov ,
                                             decimal A644WalletBalancesImporte ,
                                             string A645WalletBalancesEstadoOPE ,
                                             long AV12pWalletId ,
                                             long AV6cWalletBalancesId ,
                                             long A637WalletId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [WalletBalances]";
         AddWhere(sWhereString, "([WalletId] = @AV12pWalletId and [WalletBalancesId] >= @AV6cWalletBalancesId)");
         if ( ! (DateTime.MinValue==AV7cWalletBalancesFechaAlta) )
         {
            AddWhere(sWhereString, "([WalletBalancesFechaAlta] >= @AV7cWalletBalancesFechaAlta)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV8cWalletBalancesUsrAlta) )
         {
            AddWhere(sWhereString, "([WalletBalancesUsrAlta] >= @AV8cWalletBalancesUsrAlta)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cWalletBalancesTipoMov)) )
         {
            AddWhere(sWhereString, "([WalletBalancesTipoMov] like @lV9cWalletBalancesTipoMov)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cWalletBalancesImporte) )
         {
            AddWhere(sWhereString, "([WalletBalancesImporte] >= @AV10cWalletBalancesImporte)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cWalletBalancesEstadoOPE)) )
         {
            AddWhere(sWhereString, "([WalletBalancesEstadoOPE] like @lV11cWalletBalancesEstadoOPE)");
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
                     return conditional_H00AU2(context, (DateTime)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00AU3(context, (DateTime)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00AU2;
          prmH00AU2 = new Object[] {
          new ParDef("@AV12pWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cWalletBalancesId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cWalletBalancesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV8cWalletBalancesUsrAlta",GXType.Decimal,10,0) ,
          new ParDef("@lV9cWalletBalancesTipoMov",GXType.NChar,3,0) ,
          new ParDef("@AV10cWalletBalancesImporte",GXType.Decimal,18,2) ,
          new ParDef("@lV11cWalletBalancesEstadoOPE",GXType.NChar,3,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00AU3;
          prmH00AU3 = new Object[] {
          new ParDef("@AV12pWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cWalletBalancesId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cWalletBalancesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV8cWalletBalancesUsrAlta",GXType.Decimal,10,0) ,
          new ParDef("@lV9cWalletBalancesTipoMov",GXType.NChar,3,0) ,
          new ParDef("@AV10cWalletBalancesImporte",GXType.Decimal,18,2) ,
          new ParDef("@lV11cWalletBalancesEstadoOPE",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AU2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00AU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AU3,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

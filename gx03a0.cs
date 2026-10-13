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
   public class gx03a0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03a0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03a0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pParametroMudanzaId )
      {
         this.AV11pParametroMudanzaId = 0 ;
         ExecutePrivate();
         aP0_pParametroMudanzaId=this.AV11pParametroMudanzaId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCparametromudanzatipo = new GXCombobox();
         cmbavCparametromudanzaunidad = new GXCombobox();
         chkavCparametromudanzaactivo = new GXCheckbox();
         cmbParametroMudanzaTipo = new GXCombobox();
         cmbParametroMudanzaUnidad = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pParametroMudanzaId");
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
               gxfirstwebparm = GetFirstPar( "pParametroMudanzaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pParametroMudanzaId");
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
               AV11pParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV11pParametroMudanzaId), 4, 0));
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
         AV6cParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( GetPar( "cParametroMudanzaId"), "."), 18, MidpointRounding.ToEven));
         cmbavCparametromudanzatipo.FromJSonString( GetNextPar( ));
         AV7cParametroMudanzaTipo = GetPar( "cParametroMudanzaTipo");
         AV9cParametroMudanzaValor = NumberUtil.Val( GetPar( "cParametroMudanzaValor"), ".");
         cmbavCparametromudanzaunidad.FromJSonString( GetNextPar( ));
         AV10cParametroMudanzaUnidad = GetPar( "cParametroMudanzaUnidad");
         AV13cParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( GetPar( "cParametroMudanzaPisoElev"), "."), 18, MidpointRounding.ToEven));
         AV14cParametroMudanzaTitulo = GetPar( "cParametroMudanzaTitulo");
         AV15cParametroMudanzaActivo = StringUtil.StrToBool( GetPar( "cParametroMudanzaActivo"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cParametroMudanzaId, AV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, AV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, AV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo) ;
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
         PAE12( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTE12( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pParametroMudanzaId,4,0))}, new string[] {"pParametroMudanzaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZATIPO", AV7cParametroMudanzaTipo);
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZAVALOR", StringUtil.LTrim( StringUtil.NToC( AV9cParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZAUNIDAD", StringUtil.RTrim( AV10cParametroMudanzaUnidad));
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZAPISOELEV", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZATITULO", AV14cParametroMudanzaTitulo);
         GxWebStd.gx_hidden_field( context, "GXH_vCPARAMETROMUDANZAACTIVO", StringUtil.BoolToStr( AV15cParametroMudanzaActivo));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAIDFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZATIPOFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzatipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAVALORFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzavalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAUNIDADFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzaunidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAPISOELEVFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzapisoelevfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZATITULOFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzatitulofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAACTIVOFILTERCONTAINER_Class", StringUtil.RTrim( divParametromudanzaactivofiltercontainer_Class));
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
            WEE12( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTE12( ) ;
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
         return formatLink("gx03a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pParametroMudanzaId,4,0))}, new string[] {"pParametroMudanzaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03A0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Parametro Mudanza", "") ;
      }

      protected void WBE10( )
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
            GxWebStd.gx_div_start( context, divParametromudanzaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzaidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzaidfilter_Internalname, context.GetMessage( "Parametro Mudanza Id", ""), "", "", lblLblparametromudanzaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCparametromudanzaid_Internalname, context.GetMessage( "Parametro Mudanza Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCparametromudanzaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCparametromudanzaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cParametroMudanzaId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cParametroMudanzaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCparametromudanzaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCparametromudanzaid_Visible, edtavCparametromudanzaid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03A0.htm");
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
            GxWebStd.gx_div_start( context, divParametromudanzatipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzatipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzatipofilter_Internalname, context.GetMessage( "Parametro Mudanza Tipo", ""), "", "", lblLblparametromudanzatipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCparametromudanzatipo_Internalname, context.GetMessage( "Parametro Mudanza Tipo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCparametromudanzatipo, cmbavCparametromudanzatipo_Internalname, StringUtil.RTrim( AV7cParametroMudanzaTipo), 1, cmbavCparametromudanzatipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavCparametromudanzatipo.Visible, cmbavCparametromudanzatipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx03A0.htm");
            cmbavCparametromudanzatipo.CurrentValue = StringUtil.RTrim( AV7cParametroMudanzaTipo);
            AssignProp("", false, cmbavCparametromudanzatipo_Internalname, "Values", (string)(cmbavCparametromudanzatipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divParametromudanzavalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzavalorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzavalorfilter_Internalname, context.GetMessage( "Parametro Mudanza Valor", ""), "", "", lblLblparametromudanzavalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCparametromudanzavalor_Internalname, context.GetMessage( "Parametro Mudanza Valor", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCparametromudanzavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCparametromudanzavalor_Enabled!=0) ? context.localUtil.Format( AV9cParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV9cParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCparametromudanzavalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCparametromudanzavalor_Visible, edtavCparametromudanzavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03A0.htm");
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
            GxWebStd.gx_div_start( context, divParametromudanzaunidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzaunidadfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzaunidadfilter_Internalname, context.GetMessage( "Parametro Mudanza Unidad", ""), "", "", lblLblparametromudanzaunidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCparametromudanzaunidad_Internalname, context.GetMessage( "Parametro Mudanza Unidad", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCparametromudanzaunidad, cmbavCparametromudanzaunidad_Internalname, StringUtil.RTrim( AV10cParametroMudanzaUnidad), 1, cmbavCparametromudanzaunidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCparametromudanzaunidad.Visible, cmbavCparametromudanzaunidad.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Gx03A0.htm");
            cmbavCparametromudanzaunidad.CurrentValue = StringUtil.RTrim( AV10cParametroMudanzaUnidad);
            AssignProp("", false, cmbavCparametromudanzaunidad_Internalname, "Values", (string)(cmbavCparametromudanzaunidad.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divParametromudanzapisoelevfiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzapisoelevfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzapisoelevfilter_Internalname, context.GetMessage( "Parametro Mudanza Piso Elev", ""), "", "", lblLblparametromudanzapisoelevfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCparametromudanzapisoelev_Internalname, context.GetMessage( "Parametro Mudanza Piso Elev", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCparametromudanzapisoelev_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCparametromudanzapisoelev_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13cParametroMudanzaPisoElev), "ZZZ9") : context.localUtil.Format( (decimal)(AV13cParametroMudanzaPisoElev), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCparametromudanzapisoelev_Jsonclick, 0, "Attribute", "", "", "", "", edtavCparametromudanzapisoelev_Visible, edtavCparametromudanzapisoelev_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03A0.htm");
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
            GxWebStd.gx_div_start( context, divParametromudanzatitulofiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzatitulofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzatitulofilter_Internalname, context.GetMessage( "Parametro Mudanza Titulo", ""), "", "", lblLblparametromudanzatitulofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCparametromudanzatitulo_Internalname, context.GetMessage( "Parametro Mudanza Titulo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCparametromudanzatitulo_Internalname, AV14cParametroMudanzaTitulo, StringUtil.RTrim( context.localUtil.Format( AV14cParametroMudanzaTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCparametromudanzatitulo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCparametromudanzatitulo_Visible, edtavCparametromudanzatitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03A0.htm");
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
            GxWebStd.gx_div_start( context, divParametromudanzaactivofiltercontainer_Internalname, 1, 0, "px", 0, "px", divParametromudanzaactivofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblparametromudanzaactivofilter_Internalname, context.GetMessage( "Parametro Mudanza Activo", ""), "", "", lblLblparametromudanzaactivofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17e11_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03A0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCparametromudanzaactivo_Internalname, context.GetMessage( "Parametro Mudanza Activo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCparametromudanzaactivo_Internalname, StringUtil.BoolToStr( AV15cParametroMudanzaActivo), "", context.GetMessage( "Parametro Mudanza Activo", ""), chkavCparametromudanzaactivo.Visible, chkavCparametromudanzaactivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18e11_client"+"'", TempTags, "", 2, "HLP_Gx03A0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03A0.htm");
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

      protected void STARTE12( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Parametro Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPE10( ) ;
      }

      protected void WSE12( )
      {
         STARTE12( ) ;
         EVTE12( ) ;
      }

      protected void EVTE12( )
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
                              A730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbParametroMudanzaTipo.Name = cmbParametroMudanzaTipo_Internalname;
                              cmbParametroMudanzaTipo.CurrentValue = cgiGet( cmbParametroMudanzaTipo_Internalname);
                              A731ParametroMudanzaTipo = cgiGet( cmbParametroMudanzaTipo_Internalname);
                              A733ParametroMudanzaValor = context.localUtil.CToN( cgiGet( edtParametroMudanzaValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbParametroMudanzaUnidad.Name = cmbParametroMudanzaUnidad_Internalname;
                              cmbParametroMudanzaUnidad.CurrentValue = cgiGet( cmbParametroMudanzaUnidad_Internalname);
                              A734ParametroMudanzaUnidad = cgiGet( cmbParametroMudanzaUnidad_Internalname);
                              A818ParametroMudanzaPisoElev = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaPisoElev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19E12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20E12 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cparametromudanzaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPARAMETROMUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cParametroMudanzaId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cparametromudanzatipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPARAMETROMUDANZATIPO"), AV7cParametroMudanzaTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cparametromudanzavalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPARAMETROMUDANZAVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cParametroMudanzaValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cparametromudanzaunidad Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPARAMETROMUDANZAUNIDAD"), AV10cParametroMudanzaUnidad) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cparametromudanzapisoelev Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPARAMETROMUDANZAPISOELEV"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13cParametroMudanzaPisoElev )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cparametromudanzatitulo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPARAMETROMUDANZATITULO"), AV14cParametroMudanzaTitulo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cparametromudanzaactivo Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCPARAMETROMUDANZAACTIVO")) != AV15cParametroMudanzaActivo )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21E12 ();
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

      protected void WEE12( )
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

      protected void PAE12( )
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
                                        short AV6cParametroMudanzaId ,
                                        string AV7cParametroMudanzaTipo ,
                                        decimal AV9cParametroMudanzaValor ,
                                        string AV10cParametroMudanzaUnidad ,
                                        short AV13cParametroMudanzaPisoElev ,
                                        string AV14cParametroMudanzaTitulo ,
                                        bool AV15cParametroMudanzaActivo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFE12( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, ".", "")));
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
         if ( cmbavCparametromudanzatipo.ItemCount > 0 )
         {
            AV7cParametroMudanzaTipo = cmbavCparametromudanzatipo.getValidValue(AV7cParametroMudanzaTipo);
            AssignAttri("", false, "AV7cParametroMudanzaTipo", AV7cParametroMudanzaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCparametromudanzatipo.CurrentValue = StringUtil.RTrim( AV7cParametroMudanzaTipo);
            AssignProp("", false, cmbavCparametromudanzatipo_Internalname, "Values", cmbavCparametromudanzatipo.ToJavascriptSource(), true);
         }
         if ( cmbavCparametromudanzaunidad.ItemCount > 0 )
         {
            AV10cParametroMudanzaUnidad = cmbavCparametromudanzaunidad.getValidValue(AV10cParametroMudanzaUnidad);
            AssignAttri("", false, "AV10cParametroMudanzaUnidad", AV10cParametroMudanzaUnidad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCparametromudanzaunidad.CurrentValue = StringUtil.RTrim( AV10cParametroMudanzaUnidad);
            AssignProp("", false, cmbavCparametromudanzaunidad_Internalname, "Values", cmbavCparametromudanzaunidad.ToJavascriptSource(), true);
         }
         AV15cParametroMudanzaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV15cParametroMudanzaActivo));
         AssignAttri("", false, "AV15cParametroMudanzaActivo", AV15cParametroMudanzaActivo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFE12( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFE12( )
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
                                                 AV7cParametroMudanzaTipo ,
                                                 AV9cParametroMudanzaValor ,
                                                 AV10cParametroMudanzaUnidad ,
                                                 AV13cParametroMudanzaPisoElev ,
                                                 AV14cParametroMudanzaTitulo ,
                                                 AV15cParametroMudanzaActivo ,
                                                 A731ParametroMudanzaTipo ,
                                                 A733ParametroMudanzaValor ,
                                                 A734ParametroMudanzaUnidad ,
                                                 A818ParametroMudanzaPisoElev ,
                                                 A869ParametroMudanzaTitulo ,
                                                 A877ParametroMudanzaActivo ,
                                                 AV6cParametroMudanzaId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV7cParametroMudanzaTipo = StringUtil.Concat( StringUtil.RTrim( AV7cParametroMudanzaTipo), "%", "");
            lV10cParametroMudanzaUnidad = StringUtil.PadR( StringUtil.RTrim( AV10cParametroMudanzaUnidad), 2, "%");
            lV14cParametroMudanzaTitulo = StringUtil.Concat( StringUtil.RTrim( AV14cParametroMudanzaTitulo), "%", "");
            /* Using cursor H00E12 */
            pr_default.execute(0, new Object[] {AV6cParametroMudanzaId, lV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, lV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, lV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A877ParametroMudanzaActivo = H00E12_A877ParametroMudanzaActivo[0];
               A869ParametroMudanzaTitulo = H00E12_A869ParametroMudanzaTitulo[0];
               A818ParametroMudanzaPisoElev = H00E12_A818ParametroMudanzaPisoElev[0];
               A734ParametroMudanzaUnidad = H00E12_A734ParametroMudanzaUnidad[0];
               A733ParametroMudanzaValor = H00E12_A733ParametroMudanzaValor[0];
               A731ParametroMudanzaTipo = H00E12_A731ParametroMudanzaTipo[0];
               A730ParametroMudanzaId = H00E12_A730ParametroMudanzaId[0];
               /* Execute user event: Load */
               E20E12 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBE10( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesE12( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROMUDANZAID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"), context));
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
                                              AV7cParametroMudanzaTipo ,
                                              AV9cParametroMudanzaValor ,
                                              AV10cParametroMudanzaUnidad ,
                                              AV13cParametroMudanzaPisoElev ,
                                              AV14cParametroMudanzaTitulo ,
                                              AV15cParametroMudanzaActivo ,
                                              A731ParametroMudanzaTipo ,
                                              A733ParametroMudanzaValor ,
                                              A734ParametroMudanzaUnidad ,
                                              A818ParametroMudanzaPisoElev ,
                                              A869ParametroMudanzaTitulo ,
                                              A877ParametroMudanzaActivo ,
                                              AV6cParametroMudanzaId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV7cParametroMudanzaTipo = StringUtil.Concat( StringUtil.RTrim( AV7cParametroMudanzaTipo), "%", "");
         lV10cParametroMudanzaUnidad = StringUtil.PadR( StringUtil.RTrim( AV10cParametroMudanzaUnidad), 2, "%");
         lV14cParametroMudanzaTitulo = StringUtil.Concat( StringUtil.RTrim( AV14cParametroMudanzaTitulo), "%", "");
         /* Using cursor H00E13 */
         pr_default.execute(1, new Object[] {AV6cParametroMudanzaId, lV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, lV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, lV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo});
         GRID1_nRecordCount = H00E13_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cParametroMudanzaId, AV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, AV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, AV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cParametroMudanzaId, AV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, AV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, AV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cParametroMudanzaId, AV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, AV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, AV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cParametroMudanzaId, AV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, AV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, AV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cParametroMudanzaId, AV7cParametroMudanzaTipo, AV9cParametroMudanzaValor, AV10cParametroMudanzaUnidad, AV13cParametroMudanzaPisoElev, AV14cParametroMudanzaTitulo, AV15cParametroMudanzaActivo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtParametroMudanzaId_Enabled = 0;
         cmbParametroMudanzaTipo.Enabled = 0;
         edtParametroMudanzaValor_Enabled = 0;
         cmbParametroMudanzaUnidad.Enabled = 0;
         edtParametroMudanzaPisoElev_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPE10( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19E12 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCparametromudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCparametromudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPARAMETROMUDANZAID");
               GX_FocusControl = edtavCparametromudanzaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cParametroMudanzaId = 0;
               AssignAttri("", false, "AV6cParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV6cParametroMudanzaId), 4, 0));
            }
            else
            {
               AV6cParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCparametromudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV6cParametroMudanzaId), 4, 0));
            }
            cmbavCparametromudanzatipo.Name = cmbavCparametromudanzatipo_Internalname;
            cmbavCparametromudanzatipo.CurrentValue = cgiGet( cmbavCparametromudanzatipo_Internalname);
            AV7cParametroMudanzaTipo = cgiGet( cmbavCparametromudanzatipo_Internalname);
            AssignAttri("", false, "AV7cParametroMudanzaTipo", AV7cParametroMudanzaTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCparametromudanzavalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCparametromudanzavalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPARAMETROMUDANZAVALOR");
               GX_FocusControl = edtavCparametromudanzavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cParametroMudanzaValor = 0;
               AssignAttri("", false, "AV9cParametroMudanzaValor", StringUtil.LTrimStr( AV9cParametroMudanzaValor, 18, 2));
            }
            else
            {
               AV9cParametroMudanzaValor = context.localUtil.CToN( cgiGet( edtavCparametromudanzavalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV9cParametroMudanzaValor", StringUtil.LTrimStr( AV9cParametroMudanzaValor, 18, 2));
            }
            cmbavCparametromudanzaunidad.Name = cmbavCparametromudanzaunidad_Internalname;
            cmbavCparametromudanzaunidad.CurrentValue = cgiGet( cmbavCparametromudanzaunidad_Internalname);
            AV10cParametroMudanzaUnidad = cgiGet( cmbavCparametromudanzaunidad_Internalname);
            AssignAttri("", false, "AV10cParametroMudanzaUnidad", AV10cParametroMudanzaUnidad);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCparametromudanzapisoelev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCparametromudanzapisoelev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPARAMETROMUDANZAPISOELEV");
               GX_FocusControl = edtavCparametromudanzapisoelev_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13cParametroMudanzaPisoElev = 0;
               AssignAttri("", false, "AV13cParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(AV13cParametroMudanzaPisoElev), 4, 0));
            }
            else
            {
               AV13cParametroMudanzaPisoElev = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCparametromudanzapisoelev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13cParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(AV13cParametroMudanzaPisoElev), 4, 0));
            }
            AV14cParametroMudanzaTitulo = cgiGet( edtavCparametromudanzatitulo_Internalname);
            AssignAttri("", false, "AV14cParametroMudanzaTitulo", AV14cParametroMudanzaTitulo);
            AV15cParametroMudanzaActivo = StringUtil.StrToBool( cgiGet( chkavCparametromudanzaactivo_Internalname));
            AssignAttri("", false, "AV15cParametroMudanzaActivo", AV15cParametroMudanzaActivo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPARAMETROMUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cParametroMudanzaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPARAMETROMUDANZATIPO"), AV7cParametroMudanzaTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPARAMETROMUDANZAVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cParametroMudanzaValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPARAMETROMUDANZAUNIDAD"), AV10cParametroMudanzaUnidad) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPARAMETROMUDANZAPISOELEV"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13cParametroMudanzaPisoElev )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPARAMETROMUDANZATITULO"), AV14cParametroMudanzaTitulo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCPARAMETROMUDANZAACTIVO")) != AV15cParametroMudanzaActivo )
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
         E19E12 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19E12( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Parametro Mudanza", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20E12( )
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
         E21E12 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21E12( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pParametroMudanzaId = A730ParametroMudanzaId;
         AssignAttri("", false, "AV11pParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV11pParametroMudanzaId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV11pParametroMudanzaId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pParametroMudanzaId"});
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
         AV11pParametroMudanzaId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV11pParametroMudanzaId), 4, 0));
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
         PAE12( ) ;
         WSE12( ) ;
         WEE12( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021261762", true, true, false);
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
         context.AddJavascriptSource("gx03a0.js", "?202673021261762", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID_"+sGXsfl_84_idx;
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO_"+sGXsfl_84_idx;
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR_"+sGXsfl_84_idx;
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD_"+sGXsfl_84_idx;
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID_"+sGXsfl_84_fel_idx;
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO_"+sGXsfl_84_fel_idx;
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR_"+sGXsfl_84_fel_idx;
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD_"+sGXsfl_84_fel_idx;
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBE10( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbParametroMudanzaTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PARAMETROMUDANZATIPO_" + sGXsfl_84_idx;
               cmbParametroMudanzaTipo.Name = GXCCtl;
               cmbParametroMudanzaTipo.WebTags = "";
               cmbParametroMudanzaTipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
               cmbParametroMudanzaTipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
               cmbParametroMudanzaTipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
               cmbParametroMudanzaTipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
               cmbParametroMudanzaTipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
               cmbParametroMudanzaTipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
               cmbParametroMudanzaTipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
               cmbParametroMudanzaTipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
               cmbParametroMudanzaTipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
               cmbParametroMudanzaTipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
               cmbParametroMudanzaTipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
               cmbParametroMudanzaTipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
               cmbParametroMudanzaTipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
               if ( cmbParametroMudanzaTipo.ItemCount > 0 )
               {
                  A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbParametroMudanzaTipo,(string)cmbParametroMudanzaTipo_Internalname,StringUtil.RTrim( A731ParametroMudanzaTipo),(short)1,(string)cmbParametroMudanzaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"DescriptionAttribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbParametroMudanzaTipo.CurrentValue = StringUtil.RTrim( A731ParametroMudanzaTipo);
            AssignProp("", false, cmbParametroMudanzaTipo_Internalname, "Values", (string)(cmbParametroMudanzaTipo.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbParametroMudanzaUnidad.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PARAMETROMUDANZAUNIDAD_" + sGXsfl_84_idx;
               cmbParametroMudanzaUnidad.Name = GXCCtl;
               cmbParametroMudanzaUnidad.WebTags = "";
               cmbParametroMudanzaUnidad.addItem("m3", context.GetMessage( "m3", ""), 0);
               cmbParametroMudanzaUnidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
               cmbParametroMudanzaUnidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
               cmbParametroMudanzaUnidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
               cmbParametroMudanzaUnidad.addItem("%", "%", 0);
               cmbParametroMudanzaUnidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
               if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
               {
                  A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbParametroMudanzaUnidad,(string)cmbParametroMudanzaUnidad_Internalname,StringUtil.RTrim( A734ParametroMudanzaUnidad),(short)1,(string)cmbParametroMudanzaUnidad_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbParametroMudanzaUnidad.CurrentValue = StringUtil.RTrim( A734ParametroMudanzaUnidad);
            AssignProp("", false, cmbParametroMudanzaUnidad_Internalname, "Values", (string)(cmbParametroMudanzaUnidad.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaPisoElev_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A818ParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaPisoElev_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesE12( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCparametromudanzatipo.Name = "vCPARAMETROMUDANZATIPO";
         cmbavCparametromudanzatipo.WebTags = "";
         cmbavCparametromudanzatipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbavCparametromudanzatipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbavCparametromudanzatipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbavCparametromudanzatipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbavCparametromudanzatipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbavCparametromudanzatipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbavCparametromudanzatipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbavCparametromudanzatipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbavCparametromudanzatipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbavCparametromudanzatipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbavCparametromudanzatipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbavCparametromudanzatipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbavCparametromudanzatipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbavCparametromudanzatipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbavCparametromudanzatipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbavCparametromudanzatipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbavCparametromudanzatipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbavCparametromudanzatipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbavCparametromudanzatipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbavCparametromudanzatipo.ItemCount > 0 )
         {
            AV7cParametroMudanzaTipo = cmbavCparametromudanzatipo.getValidValue(AV7cParametroMudanzaTipo);
            AssignAttri("", false, "AV7cParametroMudanzaTipo", AV7cParametroMudanzaTipo);
         }
         cmbavCparametromudanzaunidad.Name = "vCPARAMETROMUDANZAUNIDAD";
         cmbavCparametromudanzaunidad.WebTags = "";
         cmbavCparametromudanzaunidad.addItem("m3", context.GetMessage( "m3", ""), 0);
         cmbavCparametromudanzaunidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
         cmbavCparametromudanzaunidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
         cmbavCparametromudanzaunidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
         cmbavCparametromudanzaunidad.addItem("%", "%", 0);
         cmbavCparametromudanzaunidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
         if ( cmbavCparametromudanzaunidad.ItemCount > 0 )
         {
            AV10cParametroMudanzaUnidad = cmbavCparametromudanzaunidad.getValidValue(AV10cParametroMudanzaUnidad);
            AssignAttri("", false, "AV10cParametroMudanzaUnidad", AV10cParametroMudanzaUnidad);
         }
         chkavCparametromudanzaactivo.Name = "vCPARAMETROMUDANZAACTIVO";
         chkavCparametromudanzaactivo.WebTags = "";
         chkavCparametromudanzaactivo.Caption = context.GetMessage( "Parametro Mudanza Activo", "");
         AssignProp("", false, chkavCparametromudanzaactivo_Internalname, "TitleCaption", chkavCparametromudanzaactivo.Caption, true);
         chkavCparametromudanzaactivo.CheckedValue = "false";
         AV15cParametroMudanzaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV15cParametroMudanzaActivo));
         AssignAttri("", false, "AV15cParametroMudanzaActivo", AV15cParametroMudanzaActivo);
         GXCCtl = "PARAMETROMUDANZATIPO_" + sGXsfl_84_idx;
         cmbParametroMudanzaTipo.Name = GXCCtl;
         cmbParametroMudanzaTipo.WebTags = "";
         cmbParametroMudanzaTipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbParametroMudanzaTipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbParametroMudanzaTipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbParametroMudanzaTipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbParametroMudanzaTipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbParametroMudanzaTipo.ItemCount > 0 )
         {
            A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
         }
         GXCCtl = "PARAMETROMUDANZAUNIDAD_" + sGXsfl_84_idx;
         cmbParametroMudanzaUnidad.Name = GXCCtl;
         cmbParametroMudanzaUnidad.WebTags = "";
         cmbParametroMudanzaUnidad.addItem("m3", context.GetMessage( "m3", ""), 0);
         cmbParametroMudanzaUnidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
         cmbParametroMudanzaUnidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("%", "%", 0);
         cmbParametroMudanzaUnidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
         if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
         {
            A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
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
            context.SendWebValue( context.GetMessage( "Mudanza Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Valor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Unidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Piso Elev", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A731ParametroMudanzaTipo));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbParametroMudanzaTipo.Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A734ParametroMudanzaUnidad)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A818ParametroMudanzaPisoElev), 4, 0, ".", ""))));
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
         lblLblparametromudanzaidfilter_Internalname = "LBLPARAMETROMUDANZAIDFILTER";
         edtavCparametromudanzaid_Internalname = "vCPARAMETROMUDANZAID";
         divParametromudanzaidfiltercontainer_Internalname = "PARAMETROMUDANZAIDFILTERCONTAINER";
         lblLblparametromudanzatipofilter_Internalname = "LBLPARAMETROMUDANZATIPOFILTER";
         cmbavCparametromudanzatipo_Internalname = "vCPARAMETROMUDANZATIPO";
         divParametromudanzatipofiltercontainer_Internalname = "PARAMETROMUDANZATIPOFILTERCONTAINER";
         lblLblparametromudanzavalorfilter_Internalname = "LBLPARAMETROMUDANZAVALORFILTER";
         edtavCparametromudanzavalor_Internalname = "vCPARAMETROMUDANZAVALOR";
         divParametromudanzavalorfiltercontainer_Internalname = "PARAMETROMUDANZAVALORFILTERCONTAINER";
         lblLblparametromudanzaunidadfilter_Internalname = "LBLPARAMETROMUDANZAUNIDADFILTER";
         cmbavCparametromudanzaunidad_Internalname = "vCPARAMETROMUDANZAUNIDAD";
         divParametromudanzaunidadfiltercontainer_Internalname = "PARAMETROMUDANZAUNIDADFILTERCONTAINER";
         lblLblparametromudanzapisoelevfilter_Internalname = "LBLPARAMETROMUDANZAPISOELEVFILTER";
         edtavCparametromudanzapisoelev_Internalname = "vCPARAMETROMUDANZAPISOELEV";
         divParametromudanzapisoelevfiltercontainer_Internalname = "PARAMETROMUDANZAPISOELEVFILTERCONTAINER";
         lblLblparametromudanzatitulofilter_Internalname = "LBLPARAMETROMUDANZATITULOFILTER";
         edtavCparametromudanzatitulo_Internalname = "vCPARAMETROMUDANZATITULO";
         divParametromudanzatitulofiltercontainer_Internalname = "PARAMETROMUDANZATITULOFILTERCONTAINER";
         lblLblparametromudanzaactivofilter_Internalname = "LBLPARAMETROMUDANZAACTIVOFILTER";
         chkavCparametromudanzaactivo_Internalname = "vCPARAMETROMUDANZAACTIVO";
         divParametromudanzaactivofiltercontainer_Internalname = "PARAMETROMUDANZAACTIVOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID";
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO";
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR";
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD";
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV";
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
         cmbParametroMudanzaTipo.Link = "";
         subGrid1_Header = "";
         chkavCparametromudanzaactivo.Caption = context.GetMessage( "Parametro Mudanza Activo", "");
         edtParametroMudanzaPisoElev_Jsonclick = "";
         cmbParametroMudanzaUnidad_Jsonclick = "";
         edtParametroMudanzaValor_Jsonclick = "";
         cmbParametroMudanzaTipo_Jsonclick = "";
         edtParametroMudanzaId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtParametroMudanzaPisoElev_Enabled = 0;
         cmbParametroMudanzaUnidad.Enabled = 0;
         edtParametroMudanzaValor_Enabled = 0;
         cmbParametroMudanzaTipo.Enabled = 0;
         edtParametroMudanzaId_Enabled = 0;
         chkavCparametromudanzaactivo.Enabled = 1;
         chkavCparametromudanzaactivo.Visible = 1;
         edtavCparametromudanzatitulo_Jsonclick = "";
         edtavCparametromudanzatitulo_Enabled = 1;
         edtavCparametromudanzatitulo_Visible = 1;
         edtavCparametromudanzapisoelev_Jsonclick = "";
         edtavCparametromudanzapisoelev_Enabled = 1;
         edtavCparametromudanzapisoelev_Visible = 1;
         cmbavCparametromudanzaunidad_Jsonclick = "";
         cmbavCparametromudanzaunidad.Visible = 1;
         cmbavCparametromudanzaunidad.Enabled = 1;
         edtavCparametromudanzavalor_Jsonclick = "";
         edtavCparametromudanzavalor_Enabled = 1;
         edtavCparametromudanzavalor_Visible = 1;
         cmbavCparametromudanzatipo_Jsonclick = "";
         cmbavCparametromudanzatipo.Visible = 1;
         cmbavCparametromudanzatipo.Enabled = 1;
         edtavCparametromudanzaid_Jsonclick = "";
         edtavCparametromudanzaid_Enabled = 1;
         edtavCparametromudanzaid_Visible = 1;
         divParametromudanzaactivofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divParametromudanzatitulofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divParametromudanzapisoelevfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divParametromudanzaunidadfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divParametromudanzavalorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divParametromudanzatipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divParametromudanzaidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Parametro Mudanza", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametroMudanzaId',fld:'vCPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'cmbavCparametromudanzatipo'},{av:'AV7cParametroMudanzaTipo',fld:'vCPARAMETROMUDANZATIPO',pic:'',type:'svchar'},{av:'AV9cParametroMudanzaValor',fld:'vCPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCparametromudanzaunidad'},{av:'AV10cParametroMudanzaUnidad',fld:'vCPARAMETROMUDANZAUNIDAD',pic:'',type:'char'},{av:'AV13cParametroMudanzaPisoElev',fld:'vCPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV14cParametroMudanzaTitulo',fld:'vCPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV15cParametroMudanzaActivo',fld:'vCPARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18E11',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPARAMETROMUDANZAIDFILTER.CLICK","{handler:'E11E11',iparms:[{av:'divParametromudanzaidfiltercontainer_Class',ctrl:'PARAMETROMUDANZAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZAIDFILTER.CLICK",",oparms:[{av:'divParametromudanzaidfiltercontainer_Class',ctrl:'PARAMETROMUDANZAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCparametromudanzaid_Visible',ctrl:'vCPARAMETROMUDANZAID',prop:'Visible'}]}");
         setEventMetadata("LBLPARAMETROMUDANZATIPOFILTER.CLICK","{handler:'E12E11',iparms:[{av:'divParametromudanzatipofiltercontainer_Class',ctrl:'PARAMETROMUDANZATIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZATIPOFILTER.CLICK",",oparms:[{av:'divParametromudanzatipofiltercontainer_Class',ctrl:'PARAMETROMUDANZATIPOFILTERCONTAINER',prop:'Class'},{av:'cmbavCparametromudanzatipo'}]}");
         setEventMetadata("LBLPARAMETROMUDANZAVALORFILTER.CLICK","{handler:'E13E11',iparms:[{av:'divParametromudanzavalorfiltercontainer_Class',ctrl:'PARAMETROMUDANZAVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZAVALORFILTER.CLICK",",oparms:[{av:'divParametromudanzavalorfiltercontainer_Class',ctrl:'PARAMETROMUDANZAVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCparametromudanzavalor_Visible',ctrl:'vCPARAMETROMUDANZAVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLPARAMETROMUDANZAUNIDADFILTER.CLICK","{handler:'E14E11',iparms:[{av:'divParametromudanzaunidadfiltercontainer_Class',ctrl:'PARAMETROMUDANZAUNIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZAUNIDADFILTER.CLICK",",oparms:[{av:'divParametromudanzaunidadfiltercontainer_Class',ctrl:'PARAMETROMUDANZAUNIDADFILTERCONTAINER',prop:'Class'},{av:'cmbavCparametromudanzaunidad'}]}");
         setEventMetadata("LBLPARAMETROMUDANZAPISOELEVFILTER.CLICK","{handler:'E15E11',iparms:[{av:'divParametromudanzapisoelevfiltercontainer_Class',ctrl:'PARAMETROMUDANZAPISOELEVFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZAPISOELEVFILTER.CLICK",",oparms:[{av:'divParametromudanzapisoelevfiltercontainer_Class',ctrl:'PARAMETROMUDANZAPISOELEVFILTERCONTAINER',prop:'Class'},{av:'edtavCparametromudanzapisoelev_Visible',ctrl:'vCPARAMETROMUDANZAPISOELEV',prop:'Visible'}]}");
         setEventMetadata("LBLPARAMETROMUDANZATITULOFILTER.CLICK","{handler:'E16E11',iparms:[{av:'divParametromudanzatitulofiltercontainer_Class',ctrl:'PARAMETROMUDANZATITULOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZATITULOFILTER.CLICK",",oparms:[{av:'divParametromudanzatitulofiltercontainer_Class',ctrl:'PARAMETROMUDANZATITULOFILTERCONTAINER',prop:'Class'},{av:'edtavCparametromudanzatitulo_Visible',ctrl:'vCPARAMETROMUDANZATITULO',prop:'Visible'}]}");
         setEventMetadata("LBLPARAMETROMUDANZAACTIVOFILTER.CLICK","{handler:'E17E11',iparms:[{av:'divParametromudanzaactivofiltercontainer_Class',ctrl:'PARAMETROMUDANZAACTIVOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPARAMETROMUDANZAACTIVOFILTER.CLICK",",oparms:[{av:'divParametromudanzaactivofiltercontainer_Class',ctrl:'PARAMETROMUDANZAACTIVOFILTERCONTAINER',prop:'Class'},{av:'chkavCparametromudanzaactivo.Visible',ctrl:'vCPARAMETROMUDANZAACTIVO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21E12',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pParametroMudanzaId',fld:'vPPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametroMudanzaId',fld:'vCPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'cmbavCparametromudanzatipo'},{av:'AV7cParametroMudanzaTipo',fld:'vCPARAMETROMUDANZATIPO',pic:'',type:'svchar'},{av:'AV9cParametroMudanzaValor',fld:'vCPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCparametromudanzaunidad'},{av:'AV10cParametroMudanzaUnidad',fld:'vCPARAMETROMUDANZAUNIDAD',pic:'',type:'char'},{av:'AV13cParametroMudanzaPisoElev',fld:'vCPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV14cParametroMudanzaTitulo',fld:'vCPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV15cParametroMudanzaActivo',fld:'vCPARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametroMudanzaId',fld:'vCPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'cmbavCparametromudanzatipo'},{av:'AV7cParametroMudanzaTipo',fld:'vCPARAMETROMUDANZATIPO',pic:'',type:'svchar'},{av:'AV9cParametroMudanzaValor',fld:'vCPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCparametromudanzaunidad'},{av:'AV10cParametroMudanzaUnidad',fld:'vCPARAMETROMUDANZAUNIDAD',pic:'',type:'char'},{av:'AV13cParametroMudanzaPisoElev',fld:'vCPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV14cParametroMudanzaTitulo',fld:'vCPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV15cParametroMudanzaActivo',fld:'vCPARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametroMudanzaId',fld:'vCPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'cmbavCparametromudanzatipo'},{av:'AV7cParametroMudanzaTipo',fld:'vCPARAMETROMUDANZATIPO',pic:'',type:'svchar'},{av:'AV9cParametroMudanzaValor',fld:'vCPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCparametromudanzaunidad'},{av:'AV10cParametroMudanzaUnidad',fld:'vCPARAMETROMUDANZAUNIDAD',pic:'',type:'char'},{av:'AV13cParametroMudanzaPisoElev',fld:'vCPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV14cParametroMudanzaTitulo',fld:'vCPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV15cParametroMudanzaActivo',fld:'vCPARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametroMudanzaId',fld:'vCPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'cmbavCparametromudanzatipo'},{av:'AV7cParametroMudanzaTipo',fld:'vCPARAMETROMUDANZATIPO',pic:'',type:'svchar'},{av:'AV9cParametroMudanzaValor',fld:'vCPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCparametromudanzaunidad'},{av:'AV10cParametroMudanzaUnidad',fld:'vCPARAMETROMUDANZAUNIDAD',pic:'',type:'char'},{av:'AV13cParametroMudanzaPisoElev',fld:'vCPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV14cParametroMudanzaTitulo',fld:'vCPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV15cParametroMudanzaActivo',fld:'vCPARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPARAMETROMUDANZATIPO","{handler:'Validv_Cparametromudanzatipo',iparms:[]");
         setEventMetadata("VALIDV_CPARAMETROMUDANZATIPO",",oparms:[]}");
         setEventMetadata("VALIDV_CPARAMETROMUDANZAUNIDAD","{handler:'Validv_Cparametromudanzaunidad',iparms:[]");
         setEventMetadata("VALIDV_CPARAMETROMUDANZAUNIDAD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Parametromudanzapisoelev',iparms:[]");
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
         AV7cParametroMudanzaTipo = "";
         AV10cParametroMudanzaUnidad = "";
         AV14cParametroMudanzaTitulo = "";
         AV15cParametroMudanzaActivo = true;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblparametromudanzaidfilter_Jsonclick = "";
         TempTags = "";
         lblLblparametromudanzatipofilter_Jsonclick = "";
         lblLblparametromudanzavalorfilter_Jsonclick = "";
         lblLblparametromudanzaunidadfilter_Jsonclick = "";
         lblLblparametromudanzapisoelevfilter_Jsonclick = "";
         lblLblparametromudanzatitulofilter_Jsonclick = "";
         lblLblparametromudanzaactivofilter_Jsonclick = "";
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
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         lV7cParametroMudanzaTipo = "";
         lV10cParametroMudanzaUnidad = "";
         lV14cParametroMudanzaTitulo = "";
         A869ParametroMudanzaTitulo = "";
         H00E12_A877ParametroMudanzaActivo = new bool[] {false} ;
         H00E12_A869ParametroMudanzaTitulo = new string[] {""} ;
         H00E12_A818ParametroMudanzaPisoElev = new short[1] ;
         H00E12_A734ParametroMudanzaUnidad = new string[] {""} ;
         H00E12_A733ParametroMudanzaValor = new decimal[1] ;
         H00E12_A731ParametroMudanzaTipo = new string[] {""} ;
         H00E12_A730ParametroMudanzaId = new short[1] ;
         H00E13_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03a0__default(),
            new Object[][] {
                new Object[] {
               H00E12_A877ParametroMudanzaActivo, H00E12_A869ParametroMudanzaTitulo, H00E12_A818ParametroMudanzaPisoElev, H00E12_A734ParametroMudanzaUnidad, H00E12_A733ParametroMudanzaValor, H00E12_A731ParametroMudanzaTipo, H00E12_A730ParametroMudanzaId
               }
               , new Object[] {
               H00E13_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11pParametroMudanzaId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cParametroMudanzaId ;
      private short AV13cParametroMudanzaPisoElev ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
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
      private int edtavCparametromudanzaid_Enabled ;
      private int edtavCparametromudanzaid_Visible ;
      private int edtavCparametromudanzavalor_Enabled ;
      private int edtavCparametromudanzavalor_Visible ;
      private int edtavCparametromudanzapisoelev_Enabled ;
      private int edtavCparametromudanzapisoelev_Visible ;
      private int edtavCparametromudanzatitulo_Visible ;
      private int edtavCparametromudanzatitulo_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtParametroMudanzaId_Enabled ;
      private int edtParametroMudanzaValor_Enabled ;
      private int edtParametroMudanzaPisoElev_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV9cParametroMudanzaValor ;
      private decimal A733ParametroMudanzaValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divParametromudanzaidfiltercontainer_Class ;
      private string divParametromudanzatipofiltercontainer_Class ;
      private string divParametromudanzavalorfiltercontainer_Class ;
      private string divParametromudanzaunidadfiltercontainer_Class ;
      private string divParametromudanzapisoelevfiltercontainer_Class ;
      private string divParametromudanzatitulofiltercontainer_Class ;
      private string divParametromudanzaactivofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV10cParametroMudanzaUnidad ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divParametromudanzaidfiltercontainer_Internalname ;
      private string lblLblparametromudanzaidfilter_Internalname ;
      private string lblLblparametromudanzaidfilter_Jsonclick ;
      private string edtavCparametromudanzaid_Internalname ;
      private string TempTags ;
      private string edtavCparametromudanzaid_Jsonclick ;
      private string divParametromudanzatipofiltercontainer_Internalname ;
      private string lblLblparametromudanzatipofilter_Internalname ;
      private string lblLblparametromudanzatipofilter_Jsonclick ;
      private string cmbavCparametromudanzatipo_Internalname ;
      private string cmbavCparametromudanzatipo_Jsonclick ;
      private string divParametromudanzavalorfiltercontainer_Internalname ;
      private string lblLblparametromudanzavalorfilter_Internalname ;
      private string lblLblparametromudanzavalorfilter_Jsonclick ;
      private string edtavCparametromudanzavalor_Internalname ;
      private string edtavCparametromudanzavalor_Jsonclick ;
      private string divParametromudanzaunidadfiltercontainer_Internalname ;
      private string lblLblparametromudanzaunidadfilter_Internalname ;
      private string lblLblparametromudanzaunidadfilter_Jsonclick ;
      private string cmbavCparametromudanzaunidad_Internalname ;
      private string cmbavCparametromudanzaunidad_Jsonclick ;
      private string divParametromudanzapisoelevfiltercontainer_Internalname ;
      private string lblLblparametromudanzapisoelevfilter_Internalname ;
      private string lblLblparametromudanzapisoelevfilter_Jsonclick ;
      private string edtavCparametromudanzapisoelev_Internalname ;
      private string edtavCparametromudanzapisoelev_Jsonclick ;
      private string divParametromudanzatitulofiltercontainer_Internalname ;
      private string lblLblparametromudanzatitulofilter_Internalname ;
      private string lblLblparametromudanzatitulofilter_Jsonclick ;
      private string edtavCparametromudanzatitulo_Internalname ;
      private string edtavCparametromudanzatitulo_Jsonclick ;
      private string divParametromudanzaactivofiltercontainer_Internalname ;
      private string lblLblparametromudanzaactivofilter_Internalname ;
      private string lblLblparametromudanzaactivofilter_Jsonclick ;
      private string chkavCparametromudanzaactivo_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtable_Internalname ;
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
      private string edtParametroMudanzaId_Internalname ;
      private string cmbParametroMudanzaTipo_Internalname ;
      private string edtParametroMudanzaValor_Internalname ;
      private string cmbParametroMudanzaUnidad_Internalname ;
      private string A734ParametroMudanzaUnidad ;
      private string edtParametroMudanzaPisoElev_Internalname ;
      private string lV10cParametroMudanzaUnidad ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtParametroMudanzaId_Jsonclick ;
      private string GXCCtl ;
      private string cmbParametroMudanzaTipo_Jsonclick ;
      private string edtParametroMudanzaValor_Jsonclick ;
      private string cmbParametroMudanzaUnidad_Jsonclick ;
      private string edtParametroMudanzaPisoElev_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15cParametroMudanzaActivo ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool A877ParametroMudanzaActivo ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cParametroMudanzaTipo ;
      private string AV14cParametroMudanzaTitulo ;
      private string AV16Linkselection_GXI ;
      private string A731ParametroMudanzaTipo ;
      private string lV7cParametroMudanzaTipo ;
      private string lV14cParametroMudanzaTitulo ;
      private string A869ParametroMudanzaTitulo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCparametromudanzatipo ;
      private GXCombobox cmbavCparametromudanzaunidad ;
      private GXCheckbox chkavCparametromudanzaactivo ;
      private GXCombobox cmbParametroMudanzaTipo ;
      private GXCombobox cmbParametroMudanzaUnidad ;
      private IDataStoreProvider pr_default ;
      private bool[] H00E12_A877ParametroMudanzaActivo ;
      private string[] H00E12_A869ParametroMudanzaTitulo ;
      private short[] H00E12_A818ParametroMudanzaPisoElev ;
      private string[] H00E12_A734ParametroMudanzaUnidad ;
      private decimal[] H00E12_A733ParametroMudanzaValor ;
      private string[] H00E12_A731ParametroMudanzaTipo ;
      private short[] H00E12_A730ParametroMudanzaId ;
      private long[] H00E13_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pParametroMudanzaId ;
   }

   public class gx03a0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00E12( IGxContext context ,
                                             string AV7cParametroMudanzaTipo ,
                                             decimal AV9cParametroMudanzaValor ,
                                             string AV10cParametroMudanzaUnidad ,
                                             short AV13cParametroMudanzaPisoElev ,
                                             string AV14cParametroMudanzaTitulo ,
                                             bool AV15cParametroMudanzaActivo ,
                                             string A731ParametroMudanzaTipo ,
                                             decimal A733ParametroMudanzaValor ,
                                             string A734ParametroMudanzaUnidad ,
                                             short A818ParametroMudanzaPisoElev ,
                                             string A869ParametroMudanzaTitulo ,
                                             bool A877ParametroMudanzaActivo ,
                                             short AV6cParametroMudanzaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ParametroMudanzaActivo], [ParametroMudanzaTitulo], [ParametroMudanzaPisoElev], [ParametroMudanzaUnidad], [ParametroMudanzaValor], [ParametroMudanzaTipo], [ParametroMudanzaId]";
         sFromString = " FROM [ParametroMudanza]";
         sOrderString = "";
         AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV6cParametroMudanzaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cParametroMudanzaTipo)) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] like @lV7cParametroMudanzaTipo)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cParametroMudanzaValor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV9cParametroMudanzaValor)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cParametroMudanzaUnidad)) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaUnidad] like @lV10cParametroMudanzaUnidad)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV13cParametroMudanzaPisoElev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV13cParametroMudanzaPisoElev)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cParametroMudanzaTitulo)) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] like @lV14cParametroMudanzaTitulo)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV15cParametroMudanzaActivo) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] >= @AV15cParametroMudanzaActivo)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ParametroMudanzaId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00E13( IGxContext context ,
                                             string AV7cParametroMudanzaTipo ,
                                             decimal AV9cParametroMudanzaValor ,
                                             string AV10cParametroMudanzaUnidad ,
                                             short AV13cParametroMudanzaPisoElev ,
                                             string AV14cParametroMudanzaTitulo ,
                                             bool AV15cParametroMudanzaActivo ,
                                             string A731ParametroMudanzaTipo ,
                                             decimal A733ParametroMudanzaValor ,
                                             string A734ParametroMudanzaUnidad ,
                                             short A818ParametroMudanzaPisoElev ,
                                             string A869ParametroMudanzaTitulo ,
                                             bool A877ParametroMudanzaActivo ,
                                             short AV6cParametroMudanzaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [ParametroMudanza]";
         AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV6cParametroMudanzaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cParametroMudanzaTipo)) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] like @lV7cParametroMudanzaTipo)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cParametroMudanzaValor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV9cParametroMudanzaValor)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cParametroMudanzaUnidad)) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaUnidad] like @lV10cParametroMudanzaUnidad)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV13cParametroMudanzaPisoElev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV13cParametroMudanzaPisoElev)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cParametroMudanzaTitulo)) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] like @lV14cParametroMudanzaTitulo)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV15cParametroMudanzaActivo) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] >= @AV15cParametroMudanzaActivo)");
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
                     return conditional_H00E12(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00E13(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH00E12;
          prmH00E12 = new Object[] {
          new ParDef("@AV6cParametroMudanzaId",GXType.Int16,4,0) ,
          new ParDef("@lV7cParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV9cParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@lV10cParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@AV13cParametroMudanzaPisoElev",GXType.Int16,4,0) ,
          new ParDef("@lV14cParametroMudanzaTitulo",GXType.NVarChar,80,0) ,
          new ParDef("@AV15cParametroMudanzaActivo",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00E13;
          prmH00E13 = new Object[] {
          new ParDef("@AV6cParametroMudanzaId",GXType.Int16,4,0) ,
          new ParDef("@lV7cParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV9cParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@lV10cParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@AV13cParametroMudanzaPisoElev",GXType.Int16,4,0) ,
          new ParDef("@lV14cParametroMudanzaTitulo",GXType.NVarChar,80,0) ,
          new ParDef("@AV15cParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00E12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E12,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00E13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E13,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx01h0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01h0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01h0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pConfigGenID )
      {
         this.AV13pConfigGenID = 0 ;
         ExecutePrivate();
         aP0_pConfigGenID=this.AV13pConfigGenID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCconfiggenestado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pConfigGenID");
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
               gxfirstwebparm = GetFirstPar( "pConfigGenID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pConfigGenID");
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
               AV13pConfigGenID = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pConfigGenID", StringUtil.LTrimStr( (decimal)(AV13pConfigGenID), 4, 0));
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
         AV6cConfigGenID = (short)(Math.Round(NumberUtil.Val( GetPar( "cConfigGenID"), "."), 18, MidpointRounding.ToEven));
         AV7cConfigGenEmpNom = GetPar( "cConfigGenEmpNom");
         AV8cConfigGenSiglas = GetPar( "cConfigGenSiglas");
         AV9cConfigGenSiteWeb = GetPar( "cConfigGenSiteWeb");
         AV10cConfigGenCorreo = GetPar( "cConfigGenCorreo");
         AV11cConfigGenTelefono = GetPar( "cConfigGenTelefono");
         cmbavCconfiggenestado.FromJSonString( GetNextPar( ));
         AV12cConfigGenEstado = GetPar( "cConfigGenEstado");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenID, AV7cConfigGenEmpNom, AV8cConfigGenSiglas, AV9cConfigGenSiteWeb, AV10cConfigGenCorreo, AV11cConfigGenTelefono, AV12cConfigGenEstado) ;
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
         PA9V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9V2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pConfigGenID,4,0))}, new string[] {"pConfigGenID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENEMPNOM", StringUtil.RTrim( AV7cConfigGenEmpNom));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENSIGLAS", StringUtil.RTrim( AV8cConfigGenSiglas));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENSITEWEB", StringUtil.RTrim( AV9cConfigGenSiteWeb));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENCORREO", AV10cConfigGenCorreo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENTELEFONO", StringUtil.RTrim( AV11cConfigGenTelefono));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENESTADO", StringUtil.RTrim( AV12cConfigGenEstado));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCONFIGGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENIDFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENEMPNOMFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenempnomfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENSIGLASFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggensiglasfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENSITEWEBFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggensitewebfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENCORREOFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggencorreofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENTELEFONOFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggentelefonofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenestadofiltercontainer_Class));
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
            WE9V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9V2( ) ;
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
         return formatLink("gx01h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pConfigGenID,4,0))}, new string[] {"pConfigGenID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01H0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Configuración General", "") ;
      }

      protected void WB9V0( )
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
            GxWebStd.gx_div_start( context, divConfiggenidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenidfilter_Internalname, context.GetMessage( "Config Gen ID", ""), "", "", lblLblconfiggenidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCconfiggenid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cConfigGenID), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cConfigGenID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggenid_Visible, edtavCconfiggenid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01H0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggenempnomfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenempnomfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenempnomfilter_Internalname, context.GetMessage( "Nombre de la Empresa", ""), "", "", lblLblconfiggenempnomfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggenempnom_Internalname, context.GetMessage( "Nombre de la Empresa", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenempnom_Internalname, StringUtil.RTrim( AV7cConfigGenEmpNom), StringUtil.RTrim( context.localUtil.Format( AV7cConfigGenEmpNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenempnom_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggenempnom_Visible, edtavCconfiggenempnom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01H0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggensiglasfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggensiglasfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggensiglasfilter_Internalname, context.GetMessage( "Siglas", ""), "", "", lblLblconfiggensiglasfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggensiglas_Internalname, context.GetMessage( "Siglas", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggensiglas_Internalname, StringUtil.RTrim( AV8cConfigGenSiglas), StringUtil.RTrim( context.localUtil.Format( AV8cConfigGenSiglas, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggensiglas_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggensiglas_Visible, edtavCconfiggensiglas_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01H0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggensitewebfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggensitewebfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggensitewebfilter_Internalname, context.GetMessage( "Sitio Web", ""), "", "", lblLblconfiggensitewebfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggensiteweb_Internalname, context.GetMessage( "Sitio Web", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggensiteweb_Internalname, StringUtil.RTrim( AV9cConfigGenSiteWeb), StringUtil.RTrim( context.localUtil.Format( AV9cConfigGenSiteWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggensiteweb_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggensiteweb_Visible, edtavCconfiggensiteweb_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01H0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggencorreofiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggencorreofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggencorreofilter_Internalname, context.GetMessage( "Email", ""), "", "", lblLblconfiggencorreofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggencorreo_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggencorreo_Internalname, AV10cConfigGenCorreo, StringUtil.RTrim( context.localUtil.Format( AV10cConfigGenCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggencorreo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggencorreo_Visible, edtavCconfiggencorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx01H0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggentelefonofiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggentelefonofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggentelefonofilter_Internalname, context.GetMessage( "Teléfono", ""), "", "", lblLblconfiggentelefonofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggentelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggentelefono_Internalname, StringUtil.RTrim( AV11cConfigGenTelefono), StringUtil.RTrim( context.localUtil.Format( AV11cConfigGenTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggentelefono_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggentelefono_Visible, edtavCconfiggentelefono_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx01H0.htm");
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
            GxWebStd.gx_div_start( context, divConfiggenestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenestadofilter_Internalname, context.GetMessage( "Config Gen Estado", ""), "", "", lblLblconfiggenestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e179v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01H0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCconfiggenestado_Internalname, context.GetMessage( "Config Gen Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCconfiggenestado, cmbavCconfiggenestado_Internalname, StringUtil.RTrim( AV12cConfigGenEstado), 1, cmbavCconfiggenestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCconfiggenestado.Visible, cmbavCconfiggenestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_Gx01H0.htm");
            cmbavCconfiggenestado.CurrentValue = StringUtil.RTrim( AV12cConfigGenEstado);
            AssignProp("", false, cmbavCconfiggenestado_Internalname, "Values", (string)(cmbavCconfiggenestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e189v1_client"+"'", TempTags, "", 2, "HLP_Gx01H0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01H0.htm");
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

      protected void START9V2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Configuración General", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9V0( ) ;
      }

      protected void WS9V2( )
      {
         START9V2( ) ;
         EVT9V2( ) ;
      }

      protected void EVT9V2( )
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
                              A349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A351ConfigGenEmpNom = cgiGet( edtConfigGenEmpNom_Internalname);
                              A353ConfigGenLogo = cgiGet( edtConfigGenLogo_Internalname);
                              AssignProp("", false, edtConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E199V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E209V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cconfiggenid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONFIGGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cConfigGenID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenempnom Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENEMPNOM"), AV7cConfigGenEmpNom) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggensiglas Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENSIGLAS"), AV8cConfigGenSiglas) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggensiteweb Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENSITEWEB"), AV9cConfigGenSiteWeb) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggencorreo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENCORREO"), AV10cConfigGenCorreo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggentelefono Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENTELEFONO"), AV11cConfigGenTelefono) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENESTADO"), AV12cConfigGenEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E219V2 ();
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

      protected void WE9V2( )
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

      protected void PA9V2( )
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
                                        short AV6cConfigGenID ,
                                        string AV7cConfigGenEmpNom ,
                                        string AV8cConfigGenSiglas ,
                                        string AV9cConfigGenSiteWeb ,
                                        string AV10cConfigGenCorreo ,
                                        string AV11cConfigGenTelefono ,
                                        string AV12cConfigGenEstado )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONFIGGENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONFIGGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, ".", "")));
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
         if ( cmbavCconfiggenestado.ItemCount > 0 )
         {
            AV12cConfigGenEstado = cmbavCconfiggenestado.getValidValue(AV12cConfigGenEstado);
            AssignAttri("", false, "AV12cConfigGenEstado", AV12cConfigGenEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCconfiggenestado.CurrentValue = StringUtil.RTrim( AV12cConfigGenEstado);
            AssignProp("", false, cmbavCconfiggenestado_Internalname, "Values", cmbavCconfiggenestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9V2( )
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
                                                 AV7cConfigGenEmpNom ,
                                                 AV8cConfigGenSiglas ,
                                                 AV9cConfigGenSiteWeb ,
                                                 AV10cConfigGenCorreo ,
                                                 AV11cConfigGenTelefono ,
                                                 AV12cConfigGenEstado ,
                                                 A351ConfigGenEmpNom ,
                                                 A352ConfigGenSiglas ,
                                                 A354ConfigGenSiteWeb ,
                                                 A355ConfigGenCorreo ,
                                                 A356ConfigGenTelefono ,
                                                 A358ConfigGenEstado ,
                                                 AV6cConfigGenID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT
                                                 }
            });
            lV7cConfigGenEmpNom = StringUtil.PadR( StringUtil.RTrim( AV7cConfigGenEmpNom), 100, "%");
            lV8cConfigGenSiglas = StringUtil.PadR( StringUtil.RTrim( AV8cConfigGenSiglas), 20, "%");
            lV9cConfigGenSiteWeb = StringUtil.PadR( StringUtil.RTrim( AV9cConfigGenSiteWeb), 80, "%");
            lV10cConfigGenCorreo = StringUtil.Concat( StringUtil.RTrim( AV10cConfigGenCorreo), "%", "");
            lV11cConfigGenTelefono = StringUtil.PadR( StringUtil.RTrim( AV11cConfigGenTelefono), 20, "%");
            lV12cConfigGenEstado = StringUtil.PadR( StringUtil.RTrim( AV12cConfigGenEstado), 3, "%");
            /* Using cursor H009V2 */
            pr_default.execute(0, new Object[] {AV6cConfigGenID, lV7cConfigGenEmpNom, lV8cConfigGenSiglas, lV9cConfigGenSiteWeb, lV10cConfigGenCorreo, lV11cConfigGenTelefono, lV12cConfigGenEstado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A358ConfigGenEstado = H009V2_A358ConfigGenEstado[0];
               A356ConfigGenTelefono = H009V2_A356ConfigGenTelefono[0];
               A355ConfigGenCorreo = H009V2_A355ConfigGenCorreo[0];
               A354ConfigGenSiteWeb = H009V2_A354ConfigGenSiteWeb[0];
               A352ConfigGenSiglas = H009V2_A352ConfigGenSiglas[0];
               A40000ConfigGenLogo_GXI = H009V2_A40000ConfigGenLogo_GXI[0];
               AssignProp("", false, edtConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
               A351ConfigGenEmpNom = H009V2_A351ConfigGenEmpNom[0];
               A349ConfigGenID = H009V2_A349ConfigGenID[0];
               A353ConfigGenLogo = H009V2_A353ConfigGenLogo[0];
               AssignProp("", false, edtConfigGenLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.convertURL( context.PathToRelativeUrl( A353ConfigGenLogo))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtConfigGenLogo_Internalname, "SrcSet", context.GetImageSrcSet( A353ConfigGenLogo), true);
               /* Execute user event: Load */
               E209V2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB9V0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9V2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONFIGGENID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9"), context));
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
                                              AV7cConfigGenEmpNom ,
                                              AV8cConfigGenSiglas ,
                                              AV9cConfigGenSiteWeb ,
                                              AV10cConfigGenCorreo ,
                                              AV11cConfigGenTelefono ,
                                              AV12cConfigGenEstado ,
                                              A351ConfigGenEmpNom ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              A356ConfigGenTelefono ,
                                              A358ConfigGenEstado ,
                                              AV6cConfigGenID } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV7cConfigGenEmpNom = StringUtil.PadR( StringUtil.RTrim( AV7cConfigGenEmpNom), 100, "%");
         lV8cConfigGenSiglas = StringUtil.PadR( StringUtil.RTrim( AV8cConfigGenSiglas), 20, "%");
         lV9cConfigGenSiteWeb = StringUtil.PadR( StringUtil.RTrim( AV9cConfigGenSiteWeb), 80, "%");
         lV10cConfigGenCorreo = StringUtil.Concat( StringUtil.RTrim( AV10cConfigGenCorreo), "%", "");
         lV11cConfigGenTelefono = StringUtil.PadR( StringUtil.RTrim( AV11cConfigGenTelefono), 20, "%");
         lV12cConfigGenEstado = StringUtil.PadR( StringUtil.RTrim( AV12cConfigGenEstado), 3, "%");
         /* Using cursor H009V3 */
         pr_default.execute(1, new Object[] {AV6cConfigGenID, lV7cConfigGenEmpNom, lV8cConfigGenSiglas, lV9cConfigGenSiteWeb, lV10cConfigGenCorreo, lV11cConfigGenTelefono, lV12cConfigGenEstado});
         GRID1_nRecordCount = H009V3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenID, AV7cConfigGenEmpNom, AV8cConfigGenSiglas, AV9cConfigGenSiteWeb, AV10cConfigGenCorreo, AV11cConfigGenTelefono, AV12cConfigGenEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenID, AV7cConfigGenEmpNom, AV8cConfigGenSiglas, AV9cConfigGenSiteWeb, AV10cConfigGenCorreo, AV11cConfigGenTelefono, AV12cConfigGenEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenID, AV7cConfigGenEmpNom, AV8cConfigGenSiglas, AV9cConfigGenSiteWeb, AV10cConfigGenCorreo, AV11cConfigGenTelefono, AV12cConfigGenEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenID, AV7cConfigGenEmpNom, AV8cConfigGenSiglas, AV9cConfigGenSiteWeb, AV10cConfigGenCorreo, AV11cConfigGenTelefono, AV12cConfigGenEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenID, AV7cConfigGenEmpNom, AV8cConfigGenSiglas, AV9cConfigGenSiteWeb, AV10cConfigGenCorreo, AV11cConfigGenTelefono, AV12cConfigGenEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtConfigGenID_Enabled = 0;
         edtConfigGenEmpNom_Enabled = 0;
         edtConfigGenLogo_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E199V2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCconfiggenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCconfiggenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCONFIGGENID");
               GX_FocusControl = edtavCconfiggenid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cConfigGenID = 0;
               AssignAttri("", false, "AV6cConfigGenID", StringUtil.LTrimStr( (decimal)(AV6cConfigGenID), 4, 0));
            }
            else
            {
               AV6cConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCconfiggenid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cConfigGenID", StringUtil.LTrimStr( (decimal)(AV6cConfigGenID), 4, 0));
            }
            AV7cConfigGenEmpNom = cgiGet( edtavCconfiggenempnom_Internalname);
            AssignAttri("", false, "AV7cConfigGenEmpNom", AV7cConfigGenEmpNom);
            AV8cConfigGenSiglas = cgiGet( edtavCconfiggensiglas_Internalname);
            AssignAttri("", false, "AV8cConfigGenSiglas", AV8cConfigGenSiglas);
            AV9cConfigGenSiteWeb = cgiGet( edtavCconfiggensiteweb_Internalname);
            AssignAttri("", false, "AV9cConfigGenSiteWeb", AV9cConfigGenSiteWeb);
            AV10cConfigGenCorreo = cgiGet( edtavCconfiggencorreo_Internalname);
            AssignAttri("", false, "AV10cConfigGenCorreo", AV10cConfigGenCorreo);
            AV11cConfigGenTelefono = cgiGet( edtavCconfiggentelefono_Internalname);
            AssignAttri("", false, "AV11cConfigGenTelefono", AV11cConfigGenTelefono);
            cmbavCconfiggenestado.Name = cmbavCconfiggenestado_Internalname;
            cmbavCconfiggenestado.CurrentValue = cgiGet( cmbavCconfiggenestado_Internalname);
            AV12cConfigGenEstado = cgiGet( cmbavCconfiggenestado_Internalname);
            AssignAttri("", false, "AV12cConfigGenEstado", AV12cConfigGenEstado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONFIGGENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cConfigGenID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENEMPNOM"), AV7cConfigGenEmpNom) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENSIGLAS"), AV8cConfigGenSiglas) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENSITEWEB"), AV9cConfigGenSiteWeb) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENCORREO"), AV10cConfigGenCorreo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENTELEFONO"), AV11cConfigGenTelefono) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENESTADO"), AV12cConfigGenEstado) != 0 )
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
         E199V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E199V2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Configuración General", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E209V2( )
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
         E219V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E219V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pConfigGenID = A349ConfigGenID;
         AssignAttri("", false, "AV13pConfigGenID", StringUtil.LTrimStr( (decimal)(AV13pConfigGenID), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pConfigGenID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pConfigGenID"});
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
         AV13pConfigGenID = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pConfigGenID", StringUtil.LTrimStr( (decimal)(AV13pConfigGenID), 4, 0));
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
         PA9V2( ) ;
         WS9V2( ) ;
         WE9V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021123699", true, true, false);
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
         context.AddJavascriptSource("gx01h0.js", "?202673021123699", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtConfigGenID_Internalname = "CONFIGGENID_"+sGXsfl_84_idx;
         edtConfigGenEmpNom_Internalname = "CONFIGGENEMPNOM_"+sGXsfl_84_idx;
         edtConfigGenLogo_Internalname = "CONFIGGENLOGO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtConfigGenID_Internalname = "CONFIGGENID_"+sGXsfl_84_fel_idx;
         edtConfigGenEmpNom_Internalname = "CONFIGGENEMPNOM_"+sGXsfl_84_fel_idx;
         edtConfigGenLogo_Internalname = "CONFIGGENLOGO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB9V0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtConfigGenEmpNom_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtConfigGenEmpNom_Internalname, "Link", edtConfigGenEmpNom_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenEmpNom_Internalname,StringUtil.RTrim( A351ConfigGenEmpNom),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtConfigGenEmpNom_Link,(string)"",(string)"",(string)"",(string)edtConfigGenEmpNom_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A353ConfigGenLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ConfigGenLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A353ConfigGenLogo)) ? A40000ConfigGenLogo_GXI : context.PathToRelativeUrl( A353ConfigGenLogo));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenLogo_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A353ConfigGenLogo_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashes9V2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCconfiggenestado.Name = "vCCONFIGGENESTADO";
         cmbavCconfiggenestado.WebTags = "";
         cmbavCconfiggenestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCconfiggenestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbavCconfiggenestado.ItemCount > 0 )
         {
            AV12cConfigGenEstado = cmbavCconfiggenestado.getValidValue(AV12cConfigGenEstado);
            AssignAttri("", false, "AV12cConfigGenEstado", AV12cConfigGenEstado);
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
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Empresa", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Logo", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A351ConfigGenEmpNom)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtConfigGenEmpNom_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A353ConfigGenLogo));
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
         lblLblconfiggenidfilter_Internalname = "LBLCONFIGGENIDFILTER";
         edtavCconfiggenid_Internalname = "vCCONFIGGENID";
         divConfiggenidfiltercontainer_Internalname = "CONFIGGENIDFILTERCONTAINER";
         lblLblconfiggenempnomfilter_Internalname = "LBLCONFIGGENEMPNOMFILTER";
         edtavCconfiggenempnom_Internalname = "vCCONFIGGENEMPNOM";
         divConfiggenempnomfiltercontainer_Internalname = "CONFIGGENEMPNOMFILTERCONTAINER";
         lblLblconfiggensiglasfilter_Internalname = "LBLCONFIGGENSIGLASFILTER";
         edtavCconfiggensiglas_Internalname = "vCCONFIGGENSIGLAS";
         divConfiggensiglasfiltercontainer_Internalname = "CONFIGGENSIGLASFILTERCONTAINER";
         lblLblconfiggensitewebfilter_Internalname = "LBLCONFIGGENSITEWEBFILTER";
         edtavCconfiggensiteweb_Internalname = "vCCONFIGGENSITEWEB";
         divConfiggensitewebfiltercontainer_Internalname = "CONFIGGENSITEWEBFILTERCONTAINER";
         lblLblconfiggencorreofilter_Internalname = "LBLCONFIGGENCORREOFILTER";
         edtavCconfiggencorreo_Internalname = "vCCONFIGGENCORREO";
         divConfiggencorreofiltercontainer_Internalname = "CONFIGGENCORREOFILTERCONTAINER";
         lblLblconfiggentelefonofilter_Internalname = "LBLCONFIGGENTELEFONOFILTER";
         edtavCconfiggentelefono_Internalname = "vCCONFIGGENTELEFONO";
         divConfiggentelefonofiltercontainer_Internalname = "CONFIGGENTELEFONOFILTERCONTAINER";
         lblLblconfiggenestadofilter_Internalname = "LBLCONFIGGENESTADOFILTER";
         cmbavCconfiggenestado_Internalname = "vCCONFIGGENESTADO";
         divConfiggenestadofiltercontainer_Internalname = "CONFIGGENESTADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtConfigGenID_Internalname = "CONFIGGENID";
         edtConfigGenEmpNom_Internalname = "CONFIGGENEMPNOM";
         edtConfigGenLogo_Internalname = "CONFIGGENLOGO";
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
         edtConfigGenEmpNom_Jsonclick = "";
         edtConfigGenEmpNom_Link = "";
         edtConfigGenID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtConfigGenLogo_Enabled = 0;
         edtConfigGenEmpNom_Enabled = 0;
         edtConfigGenID_Enabled = 0;
         cmbavCconfiggenestado_Jsonclick = "";
         cmbavCconfiggenestado.Visible = 1;
         cmbavCconfiggenestado.Enabled = 1;
         edtavCconfiggentelefono_Jsonclick = "";
         edtavCconfiggentelefono_Enabled = 1;
         edtavCconfiggentelefono_Visible = 1;
         edtavCconfiggencorreo_Jsonclick = "";
         edtavCconfiggencorreo_Enabled = 1;
         edtavCconfiggencorreo_Visible = 1;
         edtavCconfiggensiteweb_Jsonclick = "";
         edtavCconfiggensiteweb_Enabled = 1;
         edtavCconfiggensiteweb_Visible = 1;
         edtavCconfiggensiglas_Jsonclick = "";
         edtavCconfiggensiglas_Enabled = 1;
         edtavCconfiggensiglas_Visible = 1;
         edtavCconfiggenempnom_Jsonclick = "";
         edtavCconfiggenempnom_Enabled = 1;
         edtavCconfiggenempnom_Visible = 1;
         edtavCconfiggenid_Jsonclick = "";
         edtavCconfiggenid_Enabled = 1;
         edtavCconfiggenid_Visible = 1;
         divConfiggenestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggentelefonofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggencorreofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggensitewebfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggensiglasfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggenempnomfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggenidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Configuración General", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV7cConfigGenEmpNom',fld:'vCCONFIGGENEMPNOM',pic:'',type:'char'},{av:'AV8cConfigGenSiglas',fld:'vCCONFIGGENSIGLAS',pic:'',type:'char'},{av:'AV9cConfigGenSiteWeb',fld:'vCCONFIGGENSITEWEB',pic:'',type:'char'},{av:'AV10cConfigGenCorreo',fld:'vCCONFIGGENCORREO',pic:'',type:'svchar'},{av:'AV11cConfigGenTelefono',fld:'vCCONFIGGENTELEFONO',pic:'',type:'char'},{av:'cmbavCconfiggenestado'},{av:'AV12cConfigGenEstado',fld:'vCCONFIGGENESTADO',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E189V1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCONFIGGENIDFILTER.CLICK","{handler:'E119V1',iparms:[{av:'divConfiggenidfiltercontainer_Class',ctrl:'CONFIGGENIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENIDFILTER.CLICK",",oparms:[{av:'divConfiggenidfiltercontainer_Class',ctrl:'CONFIGGENIDFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggenid_Visible',ctrl:'vCCONFIGGENID',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENEMPNOMFILTER.CLICK","{handler:'E129V1',iparms:[{av:'divConfiggenempnomfiltercontainer_Class',ctrl:'CONFIGGENEMPNOMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENEMPNOMFILTER.CLICK",",oparms:[{av:'divConfiggenempnomfiltercontainer_Class',ctrl:'CONFIGGENEMPNOMFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggenempnom_Visible',ctrl:'vCCONFIGGENEMPNOM',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENSIGLASFILTER.CLICK","{handler:'E139V1',iparms:[{av:'divConfiggensiglasfiltercontainer_Class',ctrl:'CONFIGGENSIGLASFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENSIGLASFILTER.CLICK",",oparms:[{av:'divConfiggensiglasfiltercontainer_Class',ctrl:'CONFIGGENSIGLASFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggensiglas_Visible',ctrl:'vCCONFIGGENSIGLAS',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENSITEWEBFILTER.CLICK","{handler:'E149V1',iparms:[{av:'divConfiggensitewebfiltercontainer_Class',ctrl:'CONFIGGENSITEWEBFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENSITEWEBFILTER.CLICK",",oparms:[{av:'divConfiggensitewebfiltercontainer_Class',ctrl:'CONFIGGENSITEWEBFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggensiteweb_Visible',ctrl:'vCCONFIGGENSITEWEB',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENCORREOFILTER.CLICK","{handler:'E159V1',iparms:[{av:'divConfiggencorreofiltercontainer_Class',ctrl:'CONFIGGENCORREOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENCORREOFILTER.CLICK",",oparms:[{av:'divConfiggencorreofiltercontainer_Class',ctrl:'CONFIGGENCORREOFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggencorreo_Visible',ctrl:'vCCONFIGGENCORREO',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENTELEFONOFILTER.CLICK","{handler:'E169V1',iparms:[{av:'divConfiggentelefonofiltercontainer_Class',ctrl:'CONFIGGENTELEFONOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENTELEFONOFILTER.CLICK",",oparms:[{av:'divConfiggentelefonofiltercontainer_Class',ctrl:'CONFIGGENTELEFONOFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggentelefono_Visible',ctrl:'vCCONFIGGENTELEFONO',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENESTADOFILTER.CLICK","{handler:'E179V1',iparms:[{av:'divConfiggenestadofiltercontainer_Class',ctrl:'CONFIGGENESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENESTADOFILTER.CLICK",",oparms:[{av:'divConfiggenestadofiltercontainer_Class',ctrl:'CONFIGGENESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCconfiggenestado'}]}");
         setEventMetadata("ENTER","{handler:'E219V2',iparms:[{av:'A349ConfigGenID',fld:'CONFIGGENID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pConfigGenID',fld:'vPCONFIGGENID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV7cConfigGenEmpNom',fld:'vCCONFIGGENEMPNOM',pic:'',type:'char'},{av:'AV8cConfigGenSiglas',fld:'vCCONFIGGENSIGLAS',pic:'',type:'char'},{av:'AV9cConfigGenSiteWeb',fld:'vCCONFIGGENSITEWEB',pic:'',type:'char'},{av:'AV10cConfigGenCorreo',fld:'vCCONFIGGENCORREO',pic:'',type:'svchar'},{av:'AV11cConfigGenTelefono',fld:'vCCONFIGGENTELEFONO',pic:'',type:'char'},{av:'cmbavCconfiggenestado'},{av:'AV12cConfigGenEstado',fld:'vCCONFIGGENESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV7cConfigGenEmpNom',fld:'vCCONFIGGENEMPNOM',pic:'',type:'char'},{av:'AV8cConfigGenSiglas',fld:'vCCONFIGGENSIGLAS',pic:'',type:'char'},{av:'AV9cConfigGenSiteWeb',fld:'vCCONFIGGENSITEWEB',pic:'',type:'char'},{av:'AV10cConfigGenCorreo',fld:'vCCONFIGGENCORREO',pic:'',type:'svchar'},{av:'AV11cConfigGenTelefono',fld:'vCCONFIGGENTELEFONO',pic:'',type:'char'},{av:'cmbavCconfiggenestado'},{av:'AV12cConfigGenEstado',fld:'vCCONFIGGENESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV7cConfigGenEmpNom',fld:'vCCONFIGGENEMPNOM',pic:'',type:'char'},{av:'AV8cConfigGenSiglas',fld:'vCCONFIGGENSIGLAS',pic:'',type:'char'},{av:'AV9cConfigGenSiteWeb',fld:'vCCONFIGGENSITEWEB',pic:'',type:'char'},{av:'AV10cConfigGenCorreo',fld:'vCCONFIGGENCORREO',pic:'',type:'svchar'},{av:'AV11cConfigGenTelefono',fld:'vCCONFIGGENTELEFONO',pic:'',type:'char'},{av:'cmbavCconfiggenestado'},{av:'AV12cConfigGenEstado',fld:'vCCONFIGGENESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenID',fld:'vCCONFIGGENID',pic:'ZZZ9',type:'int'},{av:'AV7cConfigGenEmpNom',fld:'vCCONFIGGENEMPNOM',pic:'',type:'char'},{av:'AV8cConfigGenSiglas',fld:'vCCONFIGGENSIGLAS',pic:'',type:'char'},{av:'AV9cConfigGenSiteWeb',fld:'vCCONFIGGENSITEWEB',pic:'',type:'char'},{av:'AV10cConfigGenCorreo',fld:'vCCONFIGGENCORREO',pic:'',type:'svchar'},{av:'AV11cConfigGenTelefono',fld:'vCCONFIGGENTELEFONO',pic:'',type:'char'},{av:'cmbavCconfiggenestado'},{av:'AV12cConfigGenEstado',fld:'vCCONFIGGENESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCONFIGGENCORREO","{handler:'Validv_Cconfiggencorreo',iparms:[]");
         setEventMetadata("VALIDV_CCONFIGGENCORREO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Configgenlogo',iparms:[]");
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
         AV7cConfigGenEmpNom = "";
         AV8cConfigGenSiglas = "";
         AV9cConfigGenSiteWeb = "";
         AV10cConfigGenCorreo = "";
         AV11cConfigGenTelefono = "";
         AV12cConfigGenEstado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblconfiggenidfilter_Jsonclick = "";
         TempTags = "";
         lblLblconfiggenempnomfilter_Jsonclick = "";
         lblLblconfiggensiglasfilter_Jsonclick = "";
         lblLblconfiggensitewebfilter_Jsonclick = "";
         lblLblconfiggencorreofilter_Jsonclick = "";
         lblLblconfiggentelefonofilter_Jsonclick = "";
         lblLblconfiggenestadofilter_Jsonclick = "";
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
         A351ConfigGenEmpNom = "";
         A353ConfigGenLogo = "";
         A40000ConfigGenLogo_GXI = "";
         lV7cConfigGenEmpNom = "";
         lV8cConfigGenSiglas = "";
         lV9cConfigGenSiteWeb = "";
         lV10cConfigGenCorreo = "";
         lV11cConfigGenTelefono = "";
         lV12cConfigGenEstado = "";
         A352ConfigGenSiglas = "";
         A354ConfigGenSiteWeb = "";
         A355ConfigGenCorreo = "";
         A356ConfigGenTelefono = "";
         A358ConfigGenEstado = "";
         H009V2_A358ConfigGenEstado = new string[] {""} ;
         H009V2_A356ConfigGenTelefono = new string[] {""} ;
         H009V2_A355ConfigGenCorreo = new string[] {""} ;
         H009V2_A354ConfigGenSiteWeb = new string[] {""} ;
         H009V2_A352ConfigGenSiglas = new string[] {""} ;
         H009V2_A40000ConfigGenLogo_GXI = new string[] {""} ;
         H009V2_A351ConfigGenEmpNom = new string[] {""} ;
         H009V2_A349ConfigGenID = new short[1] ;
         H009V2_A353ConfigGenLogo = new string[] {""} ;
         H009V3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01h0__default(),
            new Object[][] {
                new Object[] {
               H009V2_A358ConfigGenEstado, H009V2_A356ConfigGenTelefono, H009V2_A355ConfigGenCorreo, H009V2_A354ConfigGenSiteWeb, H009V2_A352ConfigGenSiglas, H009V2_A40000ConfigGenLogo_GXI, H009V2_A351ConfigGenEmpNom, H009V2_A349ConfigGenID, H009V2_A353ConfigGenLogo
               }
               , new Object[] {
               H009V3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13pConfigGenID ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cConfigGenID ;
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
      private int edtavCconfiggenid_Enabled ;
      private int edtavCconfiggenid_Visible ;
      private int edtavCconfiggenempnom_Visible ;
      private int edtavCconfiggenempnom_Enabled ;
      private int edtavCconfiggensiglas_Visible ;
      private int edtavCconfiggensiglas_Enabled ;
      private int edtavCconfiggensiteweb_Visible ;
      private int edtavCconfiggensiteweb_Enabled ;
      private int edtavCconfiggencorreo_Visible ;
      private int edtavCconfiggencorreo_Enabled ;
      private int edtavCconfiggentelefono_Visible ;
      private int edtavCconfiggentelefono_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtConfigGenID_Enabled ;
      private int edtConfigGenEmpNom_Enabled ;
      private int edtConfigGenLogo_Enabled ;
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
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divConfiggenidfiltercontainer_Class ;
      private string divConfiggenempnomfiltercontainer_Class ;
      private string divConfiggensiglasfiltercontainer_Class ;
      private string divConfiggensitewebfiltercontainer_Class ;
      private string divConfiggencorreofiltercontainer_Class ;
      private string divConfiggentelefonofiltercontainer_Class ;
      private string divConfiggenestadofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cConfigGenEmpNom ;
      private string AV8cConfigGenSiglas ;
      private string AV9cConfigGenSiteWeb ;
      private string AV11cConfigGenTelefono ;
      private string AV12cConfigGenEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divConfiggenidfiltercontainer_Internalname ;
      private string lblLblconfiggenidfilter_Internalname ;
      private string lblLblconfiggenidfilter_Jsonclick ;
      private string edtavCconfiggenid_Internalname ;
      private string TempTags ;
      private string edtavCconfiggenid_Jsonclick ;
      private string divConfiggenempnomfiltercontainer_Internalname ;
      private string lblLblconfiggenempnomfilter_Internalname ;
      private string lblLblconfiggenempnomfilter_Jsonclick ;
      private string edtavCconfiggenempnom_Internalname ;
      private string edtavCconfiggenempnom_Jsonclick ;
      private string divConfiggensiglasfiltercontainer_Internalname ;
      private string lblLblconfiggensiglasfilter_Internalname ;
      private string lblLblconfiggensiglasfilter_Jsonclick ;
      private string edtavCconfiggensiglas_Internalname ;
      private string edtavCconfiggensiglas_Jsonclick ;
      private string divConfiggensitewebfiltercontainer_Internalname ;
      private string lblLblconfiggensitewebfilter_Internalname ;
      private string lblLblconfiggensitewebfilter_Jsonclick ;
      private string edtavCconfiggensiteweb_Internalname ;
      private string edtavCconfiggensiteweb_Jsonclick ;
      private string divConfiggencorreofiltercontainer_Internalname ;
      private string lblLblconfiggencorreofilter_Internalname ;
      private string lblLblconfiggencorreofilter_Jsonclick ;
      private string edtavCconfiggencorreo_Internalname ;
      private string edtavCconfiggencorreo_Jsonclick ;
      private string divConfiggentelefonofiltercontainer_Internalname ;
      private string lblLblconfiggentelefonofilter_Internalname ;
      private string lblLblconfiggentelefonofilter_Jsonclick ;
      private string edtavCconfiggentelefono_Internalname ;
      private string edtavCconfiggentelefono_Jsonclick ;
      private string divConfiggenestadofiltercontainer_Internalname ;
      private string lblLblconfiggenestadofilter_Internalname ;
      private string lblLblconfiggenestadofilter_Jsonclick ;
      private string cmbavCconfiggenestado_Internalname ;
      private string cmbavCconfiggenestado_Jsonclick ;
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
      private string edtConfigGenID_Internalname ;
      private string A351ConfigGenEmpNom ;
      private string edtConfigGenEmpNom_Internalname ;
      private string edtConfigGenLogo_Internalname ;
      private string lV7cConfigGenEmpNom ;
      private string lV8cConfigGenSiglas ;
      private string lV9cConfigGenSiteWeb ;
      private string lV11cConfigGenTelefono ;
      private string lV12cConfigGenEstado ;
      private string A352ConfigGenSiglas ;
      private string A354ConfigGenSiteWeb ;
      private string A356ConfigGenTelefono ;
      private string A358ConfigGenEstado ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtConfigGenID_Jsonclick ;
      private string edtConfigGenEmpNom_Link ;
      private string edtConfigGenEmpNom_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A353ConfigGenLogo_IsBlob ;
      private string AV10cConfigGenCorreo ;
      private string AV15Linkselection_GXI ;
      private string A40000ConfigGenLogo_GXI ;
      private string lV10cConfigGenCorreo ;
      private string A355ConfigGenCorreo ;
      private string AV5LinkSelection ;
      private string A353ConfigGenLogo ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCconfiggenestado ;
      private IDataStoreProvider pr_default ;
      private string[] H009V2_A358ConfigGenEstado ;
      private string[] H009V2_A356ConfigGenTelefono ;
      private string[] H009V2_A355ConfigGenCorreo ;
      private string[] H009V2_A354ConfigGenSiteWeb ;
      private string[] H009V2_A352ConfigGenSiglas ;
      private string[] H009V2_A40000ConfigGenLogo_GXI ;
      private string[] H009V2_A351ConfigGenEmpNom ;
      private short[] H009V2_A349ConfigGenID ;
      private string[] H009V2_A353ConfigGenLogo ;
      private long[] H009V3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pConfigGenID ;
   }

   public class gx01h0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009V2( IGxContext context ,
                                             string AV7cConfigGenEmpNom ,
                                             string AV8cConfigGenSiglas ,
                                             string AV9cConfigGenSiteWeb ,
                                             string AV10cConfigGenCorreo ,
                                             string AV11cConfigGenTelefono ,
                                             string AV12cConfigGenEstado ,
                                             string A351ConfigGenEmpNom ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             string A356ConfigGenTelefono ,
                                             string A358ConfigGenEstado ,
                                             short AV6cConfigGenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ConfigGenEstado], [ConfigGenTelefono], [ConfigGenCorreo], [ConfigGenSiteWeb], [ConfigGenSiglas], [ConfigGenLogo_GXI], [ConfigGenEmpNom], [ConfigGenID], [ConfigGenLogo]";
         sFromString = " FROM [ConfigGen]";
         sOrderString = "";
         AddWhere(sWhereString, "([ConfigGenID] >= @AV6cConfigGenID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cConfigGenEmpNom)) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] like @lV7cConfigGenEmpNom)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cConfigGenSiglas)) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] like @lV8cConfigGenSiglas)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cConfigGenSiteWeb)) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] like @lV9cConfigGenSiteWeb)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cConfigGenCorreo)) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] like @lV10cConfigGenCorreo)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cConfigGenTelefono)) )
         {
            AddWhere(sWhereString, "([ConfigGenTelefono] like @lV11cConfigGenTelefono)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cConfigGenEstado)) )
         {
            AddWhere(sWhereString, "([ConfigGenEstado] like @lV12cConfigGenEstado)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ConfigGenID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009V3( IGxContext context ,
                                             string AV7cConfigGenEmpNom ,
                                             string AV8cConfigGenSiglas ,
                                             string AV9cConfigGenSiteWeb ,
                                             string AV10cConfigGenCorreo ,
                                             string AV11cConfigGenTelefono ,
                                             string AV12cConfigGenEstado ,
                                             string A351ConfigGenEmpNom ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             string A356ConfigGenTelefono ,
                                             string A358ConfigGenEstado ,
                                             short AV6cConfigGenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [ConfigGen]";
         AddWhere(sWhereString, "([ConfigGenID] >= @AV6cConfigGenID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cConfigGenEmpNom)) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] like @lV7cConfigGenEmpNom)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cConfigGenSiglas)) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] like @lV8cConfigGenSiglas)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cConfigGenSiteWeb)) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] like @lV9cConfigGenSiteWeb)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cConfigGenCorreo)) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] like @lV10cConfigGenCorreo)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cConfigGenTelefono)) )
         {
            AddWhere(sWhereString, "([ConfigGenTelefono] like @lV11cConfigGenTelefono)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cConfigGenEstado)) )
         {
            AddWhere(sWhereString, "([ConfigGenEstado] like @lV12cConfigGenEstado)");
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
                     return conditional_H009V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H009V3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH009V2;
          prmH009V2 = new Object[] {
          new ParDef("@AV6cConfigGenID",GXType.Int16,4,0) ,
          new ParDef("@lV7cConfigGenEmpNom",GXType.NChar,100,0) ,
          new ParDef("@lV8cConfigGenSiglas",GXType.NChar,20,0) ,
          new ParDef("@lV9cConfigGenSiteWeb",GXType.NChar,80,0) ,
          new ParDef("@lV10cConfigGenCorreo",GXType.NVarChar,100,0) ,
          new ParDef("@lV11cConfigGenTelefono",GXType.NChar,20,0) ,
          new ParDef("@lV12cConfigGenEstado",GXType.NChar,3,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009V3;
          prmH009V3 = new Object[] {
          new ParDef("@AV6cConfigGenID",GXType.Int16,4,0) ,
          new ParDef("@lV7cConfigGenEmpNom",GXType.NChar,100,0) ,
          new ParDef("@lV8cConfigGenSiglas",GXType.NChar,20,0) ,
          new ParDef("@lV9cConfigGenSiteWeb",GXType.NChar,80,0) ,
          new ParDef("@lV10cConfigGenCorreo",GXType.NVarChar,100,0) ,
          new ParDef("@lV11cConfigGenTelefono",GXType.NChar,20,0) ,
          new ParDef("@lV12cConfigGenEstado",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009V2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009V3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

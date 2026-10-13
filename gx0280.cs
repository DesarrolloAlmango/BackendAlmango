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
   public class gx0280 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0280( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0280( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pConexionesID )
      {
         this.AV11pConexionesID = "" ;
         ExecutePrivate();
         aP0_pConexionesID=this.AV11pConexionesID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCconexionesestado = new GXCombobox();
         cmbavCconexionestipointegracion = new GXCombobox();
         cmbConexionesEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pConexionesID");
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
               gxfirstwebparm = GetFirstPar( "pConexionesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pConexionesID");
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
               AV11pConexionesID = gxfirstwebparm;
               AssignAttri("", false, "AV11pConexionesID", AV11pConexionesID);
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
         AV6cConexionesID = GetPar( "cConexionesID");
         AV7cConexionesNombre = GetPar( "cConexionesNombre");
         AV8cConexionesPort = (int)(Math.Round(NumberUtil.Val( GetPar( "cConexionesPort"), "."), 18, MidpointRounding.ToEven));
         AV9cConexionesUsr = GetPar( "cConexionesUsr");
         cmbavCconexionesestado.FromJSonString( GetNextPar( ));
         AV10cConexionesEstado = GetPar( "cConexionesEstado");
         cmbavCconexionestipointegracion.FromJSonString( GetNextPar( ));
         AV13cConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( GetPar( "cConexionesTipoIntegracion"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cConexionesID, AV7cConexionesNombre, AV8cConexionesPort, AV9cConexionesUsr, AV10cConexionesEstado, AV13cConexionesTipoIntegracion) ;
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
         PAJB2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTJB2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0280.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11pConexionesID))}, new string[] {"pConexionesID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCONEXIONESID", StringUtil.RTrim( AV6cConexionesID));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONEXIONESNOMBRE", StringUtil.RTrim( AV7cConexionesNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONEXIONESPORT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cConexionesPort), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONEXIONESUSR", StringUtil.RTrim( AV9cConexionesUsr));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONEXIONESESTADO", StringUtil.RTrim( AV10cConexionesEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONEXIONESTIPOINTEGRACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cConexionesTipoIntegracion), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCONEXIONESID", StringUtil.RTrim( AV11pConexionesID));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CONEXIONESIDFILTERCONTAINER_Class", StringUtil.RTrim( divConexionesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONEXIONESNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divConexionesnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONEXIONESPORTFILTERCONTAINER_Class", StringUtil.RTrim( divConexionesportfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONEXIONESUSRFILTERCONTAINER_Class", StringUtil.RTrim( divConexionesusrfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONEXIONESESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divConexionesestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONEXIONESTIPOINTEGRACIONFILTERCONTAINER_Class", StringUtil.RTrim( divConexionestipointegracionfiltercontainer_Class));
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
            WEJB2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTJB2( ) ;
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
         return formatLink("gx0280.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11pConexionesID))}, new string[] {"pConexionesID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0280" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Conexiones", "") ;
      }

      protected void WBJB0( )
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
            GxWebStd.gx_div_start( context, divConexionesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConexionesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconexionesidfilter_Internalname, context.GetMessage( "Código de Conexión", ""), "", "", lblLblconexionesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11jb1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0280.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconexionesid_Internalname, context.GetMessage( "Código de Conexión", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconexionesid_Internalname, StringUtil.RTrim( AV6cConexionesID), StringUtil.RTrim( context.localUtil.Format( AV6cConexionesID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconexionesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconexionesid_Visible, edtavCconexionesid_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0280.htm");
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
            GxWebStd.gx_div_start( context, divConexionesnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divConexionesnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconexionesnombrefilter_Internalname, context.GetMessage( "Conexiones Nombre", ""), "", "", lblLblconexionesnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12jb1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0280.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconexionesnombre_Internalname, context.GetMessage( "Conexiones Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconexionesnombre_Internalname, StringUtil.RTrim( AV7cConexionesNombre), StringUtil.RTrim( context.localUtil.Format( AV7cConexionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconexionesnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconexionesnombre_Visible, edtavCconexionesnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0280.htm");
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
            GxWebStd.gx_div_start( context, divConexionesportfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConexionesportfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconexionesportfilter_Internalname, context.GetMessage( "Puerto", ""), "", "", lblLblconexionesportfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13jb1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0280.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconexionesport_Internalname, context.GetMessage( "Puerto", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconexionesport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cConexionesPort), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCconexionesport_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cConexionesPort), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cConexionesPort), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconexionesport_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconexionesport_Visible, edtavCconexionesport_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0280.htm");
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
            GxWebStd.gx_div_start( context, divConexionesusrfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConexionesusrfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconexionesusrfilter_Internalname, context.GetMessage( "Usuario", ""), "", "", lblLblconexionesusrfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14jb1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0280.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconexionesusr_Internalname, context.GetMessage( "Usuario", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconexionesusr_Internalname, StringUtil.RTrim( AV9cConexionesUsr), StringUtil.RTrim( context.localUtil.Format( AV9cConexionesUsr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconexionesusr_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconexionesusr_Visible, edtavCconexionesusr_Enabled, 0, "text", "", 64, "chr", 1, "row", 64, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0280.htm");
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
            GxWebStd.gx_div_start( context, divConexionesestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divConexionesestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconexionesestadofilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblconexionesestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15jb1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0280.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCconexionesestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCconexionesestado, cmbavCconexionesestado_Internalname, StringUtil.RTrim( AV10cConexionesEstado), 1, cmbavCconexionesestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCconexionesestado.Visible, cmbavCconexionesestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Gx0280.htm");
            cmbavCconexionesestado.CurrentValue = StringUtil.RTrim( AV10cConexionesEstado);
            AssignProp("", false, cmbavCconexionesestado_Internalname, "Values", (string)(cmbavCconexionesestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divConexionestipointegracionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConexionestipointegracionfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconexionestipointegracionfilter_Internalname, context.GetMessage( "Conexiones Tipo Integracion", ""), "", "", lblLblconexionestipointegracionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16jb1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0280.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCconexionestipointegracion_Internalname, context.GetMessage( "Conexiones Tipo Integracion", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCconexionestipointegracion, cmbavCconexionestipointegracion_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV13cConexionesTipoIntegracion), 4, 0)), 1, cmbavCconexionestipointegracion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCconexionestipointegracion.Visible, cmbavCconexionestipointegracion.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_Gx0280.htm");
            cmbavCconexionestipointegracion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13cConexionesTipoIntegracion), 4, 0));
            AssignProp("", false, cmbavCconexionestipointegracion_Internalname, "Values", (string)(cmbavCconexionestipointegracion.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17jb1_client"+"'", TempTags, "", 2, "HLP_Gx0280.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0280.htm");
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

      protected void STARTJB2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Conexiones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPJB0( ) ;
      }

      protected void WSJB2( )
      {
         STARTJB2( ) ;
         EVTJB2( ) ;
      }

      protected void EVTJB2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A552ConexionesID = cgiGet( edtConexionesID_Internalname);
                              A556ConexionesNombre = cgiGet( edtConexionesNombre_Internalname);
                              n556ConexionesNombre = false;
                              A559ConexionesPort = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConexionesPort_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n559ConexionesPort = false;
                              cmbConexionesEstado.Name = cmbConexionesEstado_Internalname;
                              cmbConexionesEstado.CurrentValue = cgiGet( cmbConexionesEstado_Internalname);
                              A562ConexionesEstado = cgiGet( cmbConexionesEstado_Internalname);
                              n562ConexionesEstado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18JB2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19JB2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cconexionesid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESID"), AV6cConexionesID) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconexionesnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESNOMBRE"), AV7cConexionesNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconexionesport Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONEXIONESPORT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cConexionesPort )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconexionesusr Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESUSR"), AV9cConexionesUsr) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconexionesestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESESTADO"), AV10cConexionesEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconexionestipointegracion Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONEXIONESTIPOINTEGRACION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13cConexionesTipoIntegracion )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20JB2 ();
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

      protected void WEJB2( )
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

      protected void PAJB2( )
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
                                        string AV6cConexionesID ,
                                        string AV7cConexionesNombre ,
                                        int AV8cConexionesPort ,
                                        string AV9cConexionesUsr ,
                                        string AV10cConexionesEstado ,
                                        short AV13cConexionesTipoIntegracion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFJB2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONEXIONESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A552ConexionesID, "")), context));
         GxWebStd.gx_hidden_field( context, "CONEXIONESID", StringUtil.RTrim( A552ConexionesID));
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
         if ( cmbavCconexionesestado.ItemCount > 0 )
         {
            AV10cConexionesEstado = cmbavCconexionesestado.getValidValue(AV10cConexionesEstado);
            AssignAttri("", false, "AV10cConexionesEstado", AV10cConexionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCconexionesestado.CurrentValue = StringUtil.RTrim( AV10cConexionesEstado);
            AssignProp("", false, cmbavCconexionesestado_Internalname, "Values", cmbavCconexionesestado.ToJavascriptSource(), true);
         }
         if ( cmbavCconexionestipointegracion.ItemCount > 0 )
         {
            AV13cConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( cmbavCconexionestipointegracion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13cConexionesTipoIntegracion), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13cConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(AV13cConexionesTipoIntegracion), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCconexionestipointegracion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13cConexionesTipoIntegracion), 4, 0));
            AssignProp("", false, cmbavCconexionestipointegracion_Internalname, "Values", cmbavCconexionestipointegracion.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFJB2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFJB2( )
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
                                                 AV7cConexionesNombre ,
                                                 AV8cConexionesPort ,
                                                 AV9cConexionesUsr ,
                                                 AV10cConexionesEstado ,
                                                 AV13cConexionesTipoIntegracion ,
                                                 A556ConexionesNombre ,
                                                 A559ConexionesPort ,
                                                 A561ConexionesUsr ,
                                                 A562ConexionesEstado ,
                                                 A964ConexionesTipoIntegracion ,
                                                 A552ConexionesID ,
                                                 AV6cConexionesID } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV6cConexionesID = StringUtil.PadR( StringUtil.RTrim( AV6cConexionesID), 9, "%");
            lV7cConexionesNombre = StringUtil.PadR( StringUtil.RTrim( AV7cConexionesNombre), 80, "%");
            lV9cConexionesUsr = StringUtil.PadR( StringUtil.RTrim( AV9cConexionesUsr), 64, "%");
            lV10cConexionesEstado = StringUtil.PadR( StringUtil.RTrim( AV10cConexionesEstado), 3, "%");
            /* Using cursor H00JB2 */
            pr_default.execute(0, new Object[] {lV6cConexionesID, lV7cConexionesNombre, AV8cConexionesPort, lV9cConexionesUsr, lV10cConexionesEstado, AV13cConexionesTipoIntegracion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A964ConexionesTipoIntegracion = H00JB2_A964ConexionesTipoIntegracion[0];
               n964ConexionesTipoIntegracion = H00JB2_n964ConexionesTipoIntegracion[0];
               A561ConexionesUsr = H00JB2_A561ConexionesUsr[0];
               n561ConexionesUsr = H00JB2_n561ConexionesUsr[0];
               A562ConexionesEstado = H00JB2_A562ConexionesEstado[0];
               n562ConexionesEstado = H00JB2_n562ConexionesEstado[0];
               A559ConexionesPort = H00JB2_A559ConexionesPort[0];
               n559ConexionesPort = H00JB2_n559ConexionesPort[0];
               A556ConexionesNombre = H00JB2_A556ConexionesNombre[0];
               n556ConexionesNombre = H00JB2_n556ConexionesNombre[0];
               A552ConexionesID = H00JB2_A552ConexionesID[0];
               /* Execute user event: Load */
               E19JB2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBJB0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesJB2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONEXIONESID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A552ConexionesID, "")), context));
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
                                              AV7cConexionesNombre ,
                                              AV8cConexionesPort ,
                                              AV9cConexionesUsr ,
                                              AV10cConexionesEstado ,
                                              AV13cConexionesTipoIntegracion ,
                                              A556ConexionesNombre ,
                                              A559ConexionesPort ,
                                              A561ConexionesUsr ,
                                              A562ConexionesEstado ,
                                              A964ConexionesTipoIntegracion ,
                                              A552ConexionesID ,
                                              AV6cConexionesID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV6cConexionesID = StringUtil.PadR( StringUtil.RTrim( AV6cConexionesID), 9, "%");
         lV7cConexionesNombre = StringUtil.PadR( StringUtil.RTrim( AV7cConexionesNombre), 80, "%");
         lV9cConexionesUsr = StringUtil.PadR( StringUtil.RTrim( AV9cConexionesUsr), 64, "%");
         lV10cConexionesEstado = StringUtil.PadR( StringUtil.RTrim( AV10cConexionesEstado), 3, "%");
         /* Using cursor H00JB3 */
         pr_default.execute(1, new Object[] {lV6cConexionesID, lV7cConexionesNombre, AV8cConexionesPort, lV9cConexionesUsr, lV10cConexionesEstado, AV13cConexionesTipoIntegracion});
         GRID1_nRecordCount = H00JB3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConexionesID, AV7cConexionesNombre, AV8cConexionesPort, AV9cConexionesUsr, AV10cConexionesEstado, AV13cConexionesTipoIntegracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConexionesID, AV7cConexionesNombre, AV8cConexionesPort, AV9cConexionesUsr, AV10cConexionesEstado, AV13cConexionesTipoIntegracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConexionesID, AV7cConexionesNombre, AV8cConexionesPort, AV9cConexionesUsr, AV10cConexionesEstado, AV13cConexionesTipoIntegracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConexionesID, AV7cConexionesNombre, AV8cConexionesPort, AV9cConexionesUsr, AV10cConexionesEstado, AV13cConexionesTipoIntegracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConexionesID, AV7cConexionesNombre, AV8cConexionesPort, AV9cConexionesUsr, AV10cConexionesEstado, AV13cConexionesTipoIntegracion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtConexionesID_Enabled = 0;
         edtConexionesNombre_Enabled = 0;
         edtConexionesPort_Enabled = 0;
         cmbConexionesEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPJB0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18JB2 ();
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
            AV6cConexionesID = cgiGet( edtavCconexionesid_Internalname);
            AssignAttri("", false, "AV6cConexionesID", AV6cConexionesID);
            AV7cConexionesNombre = cgiGet( edtavCconexionesnombre_Internalname);
            AssignAttri("", false, "AV7cConexionesNombre", AV7cConexionesNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCconexionesport_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCconexionesport_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCONEXIONESPORT");
               GX_FocusControl = edtavCconexionesport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cConexionesPort = 0;
               AssignAttri("", false, "AV8cConexionesPort", StringUtil.LTrimStr( (decimal)(AV8cConexionesPort), 9, 0));
            }
            else
            {
               AV8cConexionesPort = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCconexionesport_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cConexionesPort", StringUtil.LTrimStr( (decimal)(AV8cConexionesPort), 9, 0));
            }
            AV9cConexionesUsr = cgiGet( edtavCconexionesusr_Internalname);
            AssignAttri("", false, "AV9cConexionesUsr", AV9cConexionesUsr);
            cmbavCconexionesestado.Name = cmbavCconexionesestado_Internalname;
            cmbavCconexionesestado.CurrentValue = cgiGet( cmbavCconexionesestado_Internalname);
            AV10cConexionesEstado = cgiGet( cmbavCconexionesestado_Internalname);
            AssignAttri("", false, "AV10cConexionesEstado", AV10cConexionesEstado);
            cmbavCconexionestipointegracion.Name = cmbavCconexionestipointegracion_Internalname;
            cmbavCconexionestipointegracion.CurrentValue = cgiGet( cmbavCconexionestipointegracion_Internalname);
            AV13cConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavCconexionestipointegracion_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13cConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(AV13cConexionesTipoIntegracion), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESID"), AV6cConexionesID) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESNOMBRE"), AV7cConexionesNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONEXIONESPORT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cConexionesPort )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESUSR"), AV9cConexionesUsr) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONEXIONESESTADO"), AV10cConexionesEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONEXIONESTIPOINTEGRACION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13cConexionesTipoIntegracion )) )
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
         E18JB2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18JB2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Conexiones", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19JB2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E20JB2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20JB2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pConexionesID = A552ConexionesID;
         AssignAttri("", false, "AV11pConexionesID", AV11pConexionesID);
         context.setWebReturnParms(new Object[] {(string)AV11pConexionesID});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pConexionesID"});
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
         AV11pConexionesID = (string)getParm(obj,0);
         AssignAttri("", false, "AV11pConexionesID", AV11pConexionesID);
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
         PAJB2( ) ;
         WSJB2( ) ;
         WEJB2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932002390", true, true, false);
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
         context.AddJavascriptSource("gx0280.js", "?2026932002390", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtConexionesID_Internalname = "CONEXIONESID_"+sGXsfl_74_idx;
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE_"+sGXsfl_74_idx;
         edtConexionesPort_Internalname = "CONEXIONESPORT_"+sGXsfl_74_idx;
         cmbConexionesEstado_Internalname = "CONEXIONESESTADO_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtConexionesID_Internalname = "CONEXIONESID_"+sGXsfl_74_fel_idx;
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE_"+sGXsfl_74_fel_idx;
         edtConexionesPort_Internalname = "CONEXIONESPORT_"+sGXsfl_74_fel_idx;
         cmbConexionesEstado_Internalname = "CONEXIONESESTADO_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBJB0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A552ConexionesID))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesID_Internalname,StringUtil.RTrim( A552ConexionesID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtConexionesNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A552ConexionesID))+"'"+"]);";
            AssignProp("", false, edtConexionesNombre_Internalname, "Link", edtConexionesNombre_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesNombre_Internalname,StringUtil.RTrim( A556ConexionesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtConexionesNombre_Link,(string)"",(string)"",(string)"",(string)edtConexionesNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesPort_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A559ConexionesPort), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A559ConexionesPort), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesPort_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbConexionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONEXIONESESTADO_" + sGXsfl_74_idx;
               cmbConexionesEstado.Name = GXCCtl;
               cmbConexionesEstado.WebTags = "";
               cmbConexionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbConexionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbConexionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbConexionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbConexionesEstado.ItemCount > 0 )
               {
                  A562ConexionesEstado = cmbConexionesEstado.getValidValue(A562ConexionesEstado);
                  n562ConexionesEstado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbConexionesEstado,(string)cmbConexionesEstado_Internalname,StringUtil.RTrim( A562ConexionesEstado),(short)1,(string)cmbConexionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbConexionesEstado.CurrentValue = StringUtil.RTrim( A562ConexionesEstado);
            AssignProp("", false, cmbConexionesEstado_Internalname, "Values", (string)(cmbConexionesEstado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            send_integrity_lvl_hashesJB2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCconexionesestado.Name = "vCCONEXIONESESTADO";
         cmbavCconexionesestado.WebTags = "";
         cmbavCconexionesestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCconexionesestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbavCconexionesestado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbavCconexionesestado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbavCconexionesestado.ItemCount > 0 )
         {
            AV10cConexionesEstado = cmbavCconexionesestado.getValidValue(AV10cConexionesEstado);
            AssignAttri("", false, "AV10cConexionesEstado", AV10cConexionesEstado);
         }
         cmbavCconexionestipointegracion.Name = "vCCONEXIONESTIPOINTEGRACION";
         cmbavCconexionestipointegracion.WebTags = "";
         cmbavCconexionestipointegracion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavCconexionestipointegracion.addItem("1", context.GetMessage( "FENICIO", ""), 0);
         cmbavCconexionestipointegracion.addItem("2", context.GetMessage( "KREIVA", ""), 0);
         if ( cmbavCconexionestipointegracion.ItemCount > 0 )
         {
            AV13cConexionesTipoIntegracion = (short)(Math.Round(NumberUtil.Val( cmbavCconexionestipointegracion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13cConexionesTipoIntegracion), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13cConexionesTipoIntegracion", StringUtil.LTrimStr( (decimal)(AV13cConexionesTipoIntegracion), 4, 0));
         }
         GXCCtl = "CONEXIONESESTADO_" + sGXsfl_74_idx;
         cmbConexionesEstado.Name = GXCCtl;
         cmbConexionesEstado.WebTags = "";
         cmbConexionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbConexionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbConexionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbConexionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbConexionesEstado.ItemCount > 0 )
         {
            A562ConexionesEstado = cmbConexionesEstado.getValidValue(A562ConexionesEstado);
            n562ConexionesEstado = false;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código de Conexión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Puerto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A552ConexionesID)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A556ConexionesNombre)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtConexionesNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A559ConexionesPort), 9, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A562ConexionesEstado)));
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
         lblLblconexionesidfilter_Internalname = "LBLCONEXIONESIDFILTER";
         edtavCconexionesid_Internalname = "vCCONEXIONESID";
         divConexionesidfiltercontainer_Internalname = "CONEXIONESIDFILTERCONTAINER";
         lblLblconexionesnombrefilter_Internalname = "LBLCONEXIONESNOMBREFILTER";
         edtavCconexionesnombre_Internalname = "vCCONEXIONESNOMBRE";
         divConexionesnombrefiltercontainer_Internalname = "CONEXIONESNOMBREFILTERCONTAINER";
         lblLblconexionesportfilter_Internalname = "LBLCONEXIONESPORTFILTER";
         edtavCconexionesport_Internalname = "vCCONEXIONESPORT";
         divConexionesportfiltercontainer_Internalname = "CONEXIONESPORTFILTERCONTAINER";
         lblLblconexionesusrfilter_Internalname = "LBLCONEXIONESUSRFILTER";
         edtavCconexionesusr_Internalname = "vCCONEXIONESUSR";
         divConexionesusrfiltercontainer_Internalname = "CONEXIONESUSRFILTERCONTAINER";
         lblLblconexionesestadofilter_Internalname = "LBLCONEXIONESESTADOFILTER";
         cmbavCconexionesestado_Internalname = "vCCONEXIONESESTADO";
         divConexionesestadofiltercontainer_Internalname = "CONEXIONESESTADOFILTERCONTAINER";
         lblLblconexionestipointegracionfilter_Internalname = "LBLCONEXIONESTIPOINTEGRACIONFILTER";
         cmbavCconexionestipointegracion_Internalname = "vCCONEXIONESTIPOINTEGRACION";
         divConexionestipointegracionfiltercontainer_Internalname = "CONEXIONESTIPOINTEGRACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtConexionesID_Internalname = "CONEXIONESID";
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE";
         edtConexionesPort_Internalname = "CONEXIONESPORT";
         cmbConexionesEstado_Internalname = "CONEXIONESESTADO";
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
         cmbConexionesEstado_Jsonclick = "";
         edtConexionesPort_Jsonclick = "";
         edtConexionesNombre_Jsonclick = "";
         edtConexionesNombre_Link = "";
         edtConexionesID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         cmbConexionesEstado.Enabled = 0;
         edtConexionesPort_Enabled = 0;
         edtConexionesNombre_Enabled = 0;
         edtConexionesID_Enabled = 0;
         cmbavCconexionestipointegracion_Jsonclick = "";
         cmbavCconexionestipointegracion.Visible = 1;
         cmbavCconexionestipointegracion.Enabled = 1;
         cmbavCconexionesestado_Jsonclick = "";
         cmbavCconexionesestado.Visible = 1;
         cmbavCconexionesestado.Enabled = 1;
         edtavCconexionesusr_Jsonclick = "";
         edtavCconexionesusr_Enabled = 1;
         edtavCconexionesusr_Visible = 1;
         edtavCconexionesport_Jsonclick = "";
         edtavCconexionesport_Enabled = 1;
         edtavCconexionesport_Visible = 1;
         edtavCconexionesnombre_Jsonclick = "";
         edtavCconexionesnombre_Enabled = 1;
         edtavCconexionesnombre_Visible = 1;
         edtavCconexionesid_Jsonclick = "";
         edtavCconexionesid_Enabled = 1;
         edtavCconexionesid_Visible = 1;
         divConexionestipointegracionfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConexionesestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConexionesusrfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConexionesportfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConexionesnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConexionesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Conexiones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConexionesID',fld:'vCCONEXIONESID',pic:'',type:'char'},{av:'AV7cConexionesNombre',fld:'vCCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV8cConexionesPort',fld:'vCCONEXIONESPORT',pic:'ZZZZZZZZ9',type:'int'},{av:'AV9cConexionesUsr',fld:'vCCONEXIONESUSR',pic:'',type:'char'},{av:'cmbavCconexionesestado'},{av:'AV10cConexionesEstado',fld:'vCCONEXIONESESTADO',pic:'',type:'char'},{av:'cmbavCconexionestipointegracion'},{av:'AV13cConexionesTipoIntegracion',fld:'vCCONEXIONESTIPOINTEGRACION',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17JB1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCONEXIONESIDFILTER.CLICK","{handler:'E11JB1',iparms:[{av:'divConexionesidfiltercontainer_Class',ctrl:'CONEXIONESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONEXIONESIDFILTER.CLICK",",oparms:[{av:'divConexionesidfiltercontainer_Class',ctrl:'CONEXIONESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCconexionesid_Visible',ctrl:'vCCONEXIONESID',prop:'Visible'}]}");
         setEventMetadata("LBLCONEXIONESNOMBREFILTER.CLICK","{handler:'E12JB1',iparms:[{av:'divConexionesnombrefiltercontainer_Class',ctrl:'CONEXIONESNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONEXIONESNOMBREFILTER.CLICK",",oparms:[{av:'divConexionesnombrefiltercontainer_Class',ctrl:'CONEXIONESNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCconexionesnombre_Visible',ctrl:'vCCONEXIONESNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLCONEXIONESPORTFILTER.CLICK","{handler:'E13JB1',iparms:[{av:'divConexionesportfiltercontainer_Class',ctrl:'CONEXIONESPORTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONEXIONESPORTFILTER.CLICK",",oparms:[{av:'divConexionesportfiltercontainer_Class',ctrl:'CONEXIONESPORTFILTERCONTAINER',prop:'Class'},{av:'edtavCconexionesport_Visible',ctrl:'vCCONEXIONESPORT',prop:'Visible'}]}");
         setEventMetadata("LBLCONEXIONESUSRFILTER.CLICK","{handler:'E14JB1',iparms:[{av:'divConexionesusrfiltercontainer_Class',ctrl:'CONEXIONESUSRFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONEXIONESUSRFILTER.CLICK",",oparms:[{av:'divConexionesusrfiltercontainer_Class',ctrl:'CONEXIONESUSRFILTERCONTAINER',prop:'Class'},{av:'edtavCconexionesusr_Visible',ctrl:'vCCONEXIONESUSR',prop:'Visible'}]}");
         setEventMetadata("LBLCONEXIONESESTADOFILTER.CLICK","{handler:'E15JB1',iparms:[{av:'divConexionesestadofiltercontainer_Class',ctrl:'CONEXIONESESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONEXIONESESTADOFILTER.CLICK",",oparms:[{av:'divConexionesestadofiltercontainer_Class',ctrl:'CONEXIONESESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCconexionesestado'}]}");
         setEventMetadata("LBLCONEXIONESTIPOINTEGRACIONFILTER.CLICK","{handler:'E16JB1',iparms:[{av:'divConexionestipointegracionfiltercontainer_Class',ctrl:'CONEXIONESTIPOINTEGRACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONEXIONESTIPOINTEGRACIONFILTER.CLICK",",oparms:[{av:'divConexionestipointegracionfiltercontainer_Class',ctrl:'CONEXIONESTIPOINTEGRACIONFILTERCONTAINER',prop:'Class'},{av:'cmbavCconexionestipointegracion'}]}");
         setEventMetadata("ENTER","{handler:'E20JB2',iparms:[{av:'A552ConexionesID',fld:'CONEXIONESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pConexionesID',fld:'vPCONEXIONESID',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConexionesID',fld:'vCCONEXIONESID',pic:'',type:'char'},{av:'AV7cConexionesNombre',fld:'vCCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV8cConexionesPort',fld:'vCCONEXIONESPORT',pic:'ZZZZZZZZ9',type:'int'},{av:'AV9cConexionesUsr',fld:'vCCONEXIONESUSR',pic:'',type:'char'},{av:'cmbavCconexionesestado'},{av:'AV10cConexionesEstado',fld:'vCCONEXIONESESTADO',pic:'',type:'char'},{av:'cmbavCconexionestipointegracion'},{av:'AV13cConexionesTipoIntegracion',fld:'vCCONEXIONESTIPOINTEGRACION',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConexionesID',fld:'vCCONEXIONESID',pic:'',type:'char'},{av:'AV7cConexionesNombre',fld:'vCCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV8cConexionesPort',fld:'vCCONEXIONESPORT',pic:'ZZZZZZZZ9',type:'int'},{av:'AV9cConexionesUsr',fld:'vCCONEXIONESUSR',pic:'',type:'char'},{av:'cmbavCconexionesestado'},{av:'AV10cConexionesEstado',fld:'vCCONEXIONESESTADO',pic:'',type:'char'},{av:'cmbavCconexionestipointegracion'},{av:'AV13cConexionesTipoIntegracion',fld:'vCCONEXIONESTIPOINTEGRACION',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConexionesID',fld:'vCCONEXIONESID',pic:'',type:'char'},{av:'AV7cConexionesNombre',fld:'vCCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV8cConexionesPort',fld:'vCCONEXIONESPORT',pic:'ZZZZZZZZ9',type:'int'},{av:'AV9cConexionesUsr',fld:'vCCONEXIONESUSR',pic:'',type:'char'},{av:'cmbavCconexionesestado'},{av:'AV10cConexionesEstado',fld:'vCCONEXIONESESTADO',pic:'',type:'char'},{av:'cmbavCconexionestipointegracion'},{av:'AV13cConexionesTipoIntegracion',fld:'vCCONEXIONESTIPOINTEGRACION',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConexionesID',fld:'vCCONEXIONESID',pic:'',type:'char'},{av:'AV7cConexionesNombre',fld:'vCCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV8cConexionesPort',fld:'vCCONEXIONESPORT',pic:'ZZZZZZZZ9',type:'int'},{av:'AV9cConexionesUsr',fld:'vCCONEXIONESUSR',pic:'',type:'char'},{av:'cmbavCconexionesestado'},{av:'AV10cConexionesEstado',fld:'vCCONEXIONESESTADO',pic:'',type:'char'},{av:'cmbavCconexionestipointegracion'},{av:'AV13cConexionesTipoIntegracion',fld:'vCCONEXIONESTIPOINTEGRACION',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCONEXIONESESTADO","{handler:'Validv_Cconexionesestado',iparms:[]");
         setEventMetadata("VALIDV_CCONEXIONESESTADO",",oparms:[]}");
         setEventMetadata("VALIDV_CCONEXIONESTIPOINTEGRACION","{handler:'Validv_Cconexionestipointegracion',iparms:[]");
         setEventMetadata("VALIDV_CCONEXIONESTIPOINTEGRACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Conexionesestado',iparms:[]");
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
         AV11pConexionesID = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cConexionesID = "";
         AV7cConexionesNombre = "";
         AV9cConexionesUsr = "";
         AV10cConexionesEstado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblconexionesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblconexionesnombrefilter_Jsonclick = "";
         lblLblconexionesportfilter_Jsonclick = "";
         lblLblconexionesusrfilter_Jsonclick = "";
         lblLblconexionesestadofilter_Jsonclick = "";
         lblLblconexionestipointegracionfilter_Jsonclick = "";
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
         AV14Linkselection_GXI = "";
         A552ConexionesID = "";
         A556ConexionesNombre = "";
         A562ConexionesEstado = "";
         lV6cConexionesID = "";
         lV7cConexionesNombre = "";
         lV9cConexionesUsr = "";
         lV10cConexionesEstado = "";
         A561ConexionesUsr = "";
         H00JB2_A964ConexionesTipoIntegracion = new short[1] ;
         H00JB2_n964ConexionesTipoIntegracion = new bool[] {false} ;
         H00JB2_A561ConexionesUsr = new string[] {""} ;
         H00JB2_n561ConexionesUsr = new bool[] {false} ;
         H00JB2_A562ConexionesEstado = new string[] {""} ;
         H00JB2_n562ConexionesEstado = new bool[] {false} ;
         H00JB2_A559ConexionesPort = new int[1] ;
         H00JB2_n559ConexionesPort = new bool[] {false} ;
         H00JB2_A556ConexionesNombre = new string[] {""} ;
         H00JB2_n556ConexionesNombre = new bool[] {false} ;
         H00JB2_A552ConexionesID = new string[] {""} ;
         H00JB3_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0280__default(),
            new Object[][] {
                new Object[] {
               H00JB2_A964ConexionesTipoIntegracion, H00JB2_n964ConexionesTipoIntegracion, H00JB2_A561ConexionesUsr, H00JB2_n561ConexionesUsr, H00JB2_A562ConexionesEstado, H00JB2_n562ConexionesEstado, H00JB2_A559ConexionesPort, H00JB2_n559ConexionesPort, H00JB2_A556ConexionesNombre, H00JB2_n556ConexionesNombre,
               H00JB2_A552ConexionesID
               }
               , new Object[] {
               H00JB3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13cConexionesTipoIntegracion ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A964ConexionesTipoIntegracion ;
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
      private int AV8cConexionesPort ;
      private int edtavCconexionesid_Visible ;
      private int edtavCconexionesid_Enabled ;
      private int edtavCconexionesnombre_Visible ;
      private int edtavCconexionesnombre_Enabled ;
      private int edtavCconexionesport_Enabled ;
      private int edtavCconexionesport_Visible ;
      private int edtavCconexionesusr_Visible ;
      private int edtavCconexionesusr_Enabled ;
      private int A559ConexionesPort ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtConexionesID_Enabled ;
      private int edtConexionesNombre_Enabled ;
      private int edtConexionesPort_Enabled ;
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
      private string AV11pConexionesID ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divConexionesidfiltercontainer_Class ;
      private string divConexionesnombrefiltercontainer_Class ;
      private string divConexionesportfiltercontainer_Class ;
      private string divConexionesusrfiltercontainer_Class ;
      private string divConexionesestadofiltercontainer_Class ;
      private string divConexionestipointegracionfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV6cConexionesID ;
      private string AV7cConexionesNombre ;
      private string AV9cConexionesUsr ;
      private string AV10cConexionesEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divConexionesidfiltercontainer_Internalname ;
      private string lblLblconexionesidfilter_Internalname ;
      private string lblLblconexionesidfilter_Jsonclick ;
      private string edtavCconexionesid_Internalname ;
      private string TempTags ;
      private string edtavCconexionesid_Jsonclick ;
      private string divConexionesnombrefiltercontainer_Internalname ;
      private string lblLblconexionesnombrefilter_Internalname ;
      private string lblLblconexionesnombrefilter_Jsonclick ;
      private string edtavCconexionesnombre_Internalname ;
      private string edtavCconexionesnombre_Jsonclick ;
      private string divConexionesportfiltercontainer_Internalname ;
      private string lblLblconexionesportfilter_Internalname ;
      private string lblLblconexionesportfilter_Jsonclick ;
      private string edtavCconexionesport_Internalname ;
      private string edtavCconexionesport_Jsonclick ;
      private string divConexionesusrfiltercontainer_Internalname ;
      private string lblLblconexionesusrfilter_Internalname ;
      private string lblLblconexionesusrfilter_Jsonclick ;
      private string edtavCconexionesusr_Internalname ;
      private string edtavCconexionesusr_Jsonclick ;
      private string divConexionesestadofiltercontainer_Internalname ;
      private string lblLblconexionesestadofilter_Internalname ;
      private string lblLblconexionesestadofilter_Jsonclick ;
      private string cmbavCconexionesestado_Internalname ;
      private string cmbavCconexionesestado_Jsonclick ;
      private string divConexionestipointegracionfiltercontainer_Internalname ;
      private string lblLblconexionestipointegracionfilter_Internalname ;
      private string lblLblconexionestipointegracionfilter_Jsonclick ;
      private string cmbavCconexionestipointegracion_Internalname ;
      private string cmbavCconexionestipointegracion_Jsonclick ;
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
      private string A552ConexionesID ;
      private string edtConexionesID_Internalname ;
      private string A556ConexionesNombre ;
      private string edtConexionesNombre_Internalname ;
      private string edtConexionesPort_Internalname ;
      private string cmbConexionesEstado_Internalname ;
      private string A562ConexionesEstado ;
      private string lV6cConexionesID ;
      private string lV7cConexionesNombre ;
      private string lV9cConexionesUsr ;
      private string lV10cConexionesEstado ;
      private string A561ConexionesUsr ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtConexionesID_Jsonclick ;
      private string edtConexionesNombre_Link ;
      private string edtConexionesNombre_Jsonclick ;
      private string edtConexionesPort_Jsonclick ;
      private string GXCCtl ;
      private string cmbConexionesEstado_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n556ConexionesNombre ;
      private bool n559ConexionesPort ;
      private bool n562ConexionesEstado ;
      private bool gxdyncontrolsrefreshing ;
      private bool n964ConexionesTipoIntegracion ;
      private bool n561ConexionesUsr ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCconexionesestado ;
      private GXCombobox cmbavCconexionestipointegracion ;
      private GXCombobox cmbConexionesEstado ;
      private IDataStoreProvider pr_default ;
      private short[] H00JB2_A964ConexionesTipoIntegracion ;
      private bool[] H00JB2_n964ConexionesTipoIntegracion ;
      private string[] H00JB2_A561ConexionesUsr ;
      private bool[] H00JB2_n561ConexionesUsr ;
      private string[] H00JB2_A562ConexionesEstado ;
      private bool[] H00JB2_n562ConexionesEstado ;
      private int[] H00JB2_A559ConexionesPort ;
      private bool[] H00JB2_n559ConexionesPort ;
      private string[] H00JB2_A556ConexionesNombre ;
      private bool[] H00JB2_n556ConexionesNombre ;
      private string[] H00JB2_A552ConexionesID ;
      private long[] H00JB3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pConexionesID ;
   }

   public class gx0280__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00JB2( IGxContext context ,
                                             string AV7cConexionesNombre ,
                                             int AV8cConexionesPort ,
                                             string AV9cConexionesUsr ,
                                             string AV10cConexionesEstado ,
                                             short AV13cConexionesTipoIntegracion ,
                                             string A556ConexionesNombre ,
                                             int A559ConexionesPort ,
                                             string A561ConexionesUsr ,
                                             string A562ConexionesEstado ,
                                             short A964ConexionesTipoIntegracion ,
                                             string A552ConexionesID ,
                                             string AV6cConexionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ConexionesTipoIntegracion], [ConexionesUsr], [ConexionesEstado], [ConexionesPort], [ConexionesNombre], [ConexionesID]";
         sFromString = " FROM [Conexiones]";
         sOrderString = "";
         AddWhere(sWhereString, "([ConexionesID] like @lV6cConexionesID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cConexionesNombre)) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] like @lV7cConexionesNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cConexionesPort) )
         {
            AddWhere(sWhereString, "([ConexionesPort] >= @AV8cConexionesPort)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cConexionesUsr)) )
         {
            AddWhere(sWhereString, "([ConexionesUsr] like @lV9cConexionesUsr)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cConexionesEstado)) )
         {
            AddWhere(sWhereString, "([ConexionesEstado] like @lV10cConexionesEstado)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV13cConexionesTipoIntegracion) )
         {
            AddWhere(sWhereString, "([ConexionesTipoIntegracion] >= @AV13cConexionesTipoIntegracion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [ConexionesID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00JB3( IGxContext context ,
                                             string AV7cConexionesNombre ,
                                             int AV8cConexionesPort ,
                                             string AV9cConexionesUsr ,
                                             string AV10cConexionesEstado ,
                                             short AV13cConexionesTipoIntegracion ,
                                             string A556ConexionesNombre ,
                                             int A559ConexionesPort ,
                                             string A561ConexionesUsr ,
                                             string A562ConexionesEstado ,
                                             short A964ConexionesTipoIntegracion ,
                                             string A552ConexionesID ,
                                             string AV6cConexionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Conexiones]";
         AddWhere(sWhereString, "([ConexionesID] like @lV6cConexionesID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cConexionesNombre)) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] like @lV7cConexionesNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cConexionesPort) )
         {
            AddWhere(sWhereString, "([ConexionesPort] >= @AV8cConexionesPort)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cConexionesUsr)) )
         {
            AddWhere(sWhereString, "([ConexionesUsr] like @lV9cConexionesUsr)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cConexionesEstado)) )
         {
            AddWhere(sWhereString, "([ConexionesEstado] like @lV10cConexionesEstado)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV13cConexionesTipoIntegracion) )
         {
            AddWhere(sWhereString, "([ConexionesTipoIntegracion] >= @AV13cConexionesTipoIntegracion)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H00JB2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
               case 1 :
                     return conditional_H00JB3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmH00JB2;
          prmH00JB2 = new Object[] {
          new ParDef("@lV6cConexionesID",GXType.NChar,9,0) ,
          new ParDef("@lV7cConexionesNombre",GXType.NChar,80,0) ,
          new ParDef("@AV8cConexionesPort",GXType.Int32,9,0) ,
          new ParDef("@lV9cConexionesUsr",GXType.NChar,64,0) ,
          new ParDef("@lV10cConexionesEstado",GXType.NChar,3,0) ,
          new ParDef("@AV13cConexionesTipoIntegracion",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00JB3;
          prmH00JB3 = new Object[] {
          new ParDef("@lV6cConexionesID",GXType.NChar,9,0) ,
          new ParDef("@lV7cConexionesNombre",GXType.NChar,80,0) ,
          new ParDef("@AV8cConexionesPort",GXType.Int32,9,0) ,
          new ParDef("@lV9cConexionesUsr",GXType.NChar,64,0) ,
          new ParDef("@lV10cConexionesEstado",GXType.NChar,3,0) ,
          new ParDef("@AV13cConexionesTipoIntegracion",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00JB2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JB2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00JB3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JB3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 64);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 80);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

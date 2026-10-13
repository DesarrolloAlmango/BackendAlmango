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
   public class gx0190 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0190( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0190( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pusuariosId )
      {
         this.AV13pusuariosId = "" ;
         ExecutePrivate();
         aP0_pusuariosId=this.AV13pusuariosId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCusuariostipo = new GXCombobox();
         cmbusuariosTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pusuariosId");
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
               gxfirstwebparm = GetFirstPar( "pusuariosId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pusuariosId");
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
               AV13pusuariosId = gxfirstwebparm;
               AssignAttri("", false, "AV13pusuariosId", AV13pusuariosId);
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
         AV6cusuariosId = GetPar( "cusuariosId");
         cmbavCusuariostipo.FromJSonString( GetNextPar( ));
         AV7cusuariosTipo = GetPar( "cusuariosTipo");
         AV8cusuariosNombre = GetPar( "cusuariosNombre");
         AV9cusuariosCorreo = GetPar( "cusuariosCorreo");
         AV10cPaisID = GetPar( "cPaisID");
         AV11cusuariosPasw = GetPar( "cusuariosPasw");
         AV12cusuariosCPostal = (int)(Math.Round(NumberUtil.Val( GetPar( "cusuariosCPostal"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosId, AV7cusuariosTipo, AV8cusuariosNombre, AV9cusuariosCorreo, AV10cPaisID, AV11cusuariosPasw, AV12cusuariosCPostal) ;
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
         PA9Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9Y2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0190.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pusuariosId))}, new string[] {"pusuariosId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSID", StringUtil.RTrim( AV6cusuariosId));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSTIPO", StringUtil.RTrim( AV7cusuariosTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOMBRE", StringUtil.RTrim( AV8cusuariosNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSCORREO", AV9cusuariosCorreo);
         GxWebStd.gx_hidden_field( context, "GXH_vCPAISID", StringUtil.RTrim( AV10cPaisID));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSPASW", StringUtil.RTrim( AV11cusuariosPasw));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSCPOSTAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cusuariosCPostal), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSID", StringUtil.RTrim( AV13pusuariosId));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariostipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSCORREOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarioscorreofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAISIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaisidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSPASWFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariospaswfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSCPOSTALFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarioscpostalfiltercontainer_Class));
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
            WE9Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9Y2( ) ;
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
         return formatLink("gx0190.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pusuariosId))}, new string[] {"pusuariosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0190" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List usuarios", "") ;
      }

      protected void WB9Y0( )
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
            GxWebStd.gx_div_start( context, divUsuariosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosidfilter_Internalname, context.GetMessage( "NickName", ""), "", "", lblLblusuariosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosid_Internalname, context.GetMessage( "NickName", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosid_Internalname, StringUtil.RTrim( AV6cusuariosId), StringUtil.RTrim( context.localUtil.Format( AV6cusuariosId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosid_Visible, edtavCusuariosid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0190.htm");
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
            GxWebStd.gx_div_start( context, divUsuariostipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariostipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariostipofilter_Internalname, context.GetMessage( "usuarios Tipo", ""), "", "", lblLblusuariostipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCusuariostipo_Internalname, context.GetMessage( "usuarios Tipo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCusuariostipo, cmbavCusuariostipo_Internalname, StringUtil.RTrim( AV7cusuariosTipo), 1, cmbavCusuariostipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCusuariostipo.Visible, cmbavCusuariostipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx0190.htm");
            cmbavCusuariostipo.CurrentValue = StringUtil.RTrim( AV7cusuariosTipo);
            AssignProp("", false, cmbavCusuariostipo_Internalname, "Values", (string)(cmbavCusuariostipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divUsuariosnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnombrefilter_Internalname, context.GetMessage( "Nombre", ""), "", "", lblLblusuariosnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosnombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosnombre_Internalname, StringUtil.RTrim( AV8cusuariosNombre), StringUtil.RTrim( context.localUtil.Format( AV8cusuariosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosnombre_Visible, edtavCusuariosnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0190.htm");
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
            GxWebStd.gx_div_start( context, divUsuarioscorreofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarioscorreofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarioscorreofilter_Internalname, context.GetMessage( "Correo", ""), "", "", lblLblusuarioscorreofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuarioscorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarioscorreo_Internalname, AV9cusuariosCorreo, StringUtil.RTrim( context.localUtil.Format( AV9cusuariosCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarioscorreo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarioscorreo_Visible, edtavCusuarioscorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0190.htm");
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
            GxWebStd.gx_div_start( context, divPaisidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaisidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaisidfilter_Internalname, context.GetMessage( "PaisId", ""), "", "", lblLblpaisidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaisid_Internalname, context.GetMessage( "PaisId", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaisid_Internalname, StringUtil.RTrim( AV10cPaisID), StringUtil.RTrim( context.localUtil.Format( AV10cPaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaisid_Visible, edtavCpaisid_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0190.htm");
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
            GxWebStd.gx_div_start( context, divUsuariospaswfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariospaswfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariospaswfilter_Internalname, context.GetMessage( "Paswword", ""), "", "", lblLblusuariospaswfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariospasw_Internalname, context.GetMessage( "Paswword", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariospasw_Internalname, StringUtil.RTrim( AV11cusuariosPasw), StringUtil.RTrim( context.localUtil.Format( AV11cusuariosPasw, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariospasw_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariospasw_Visible, edtavCusuariospasw_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0190.htm");
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
            GxWebStd.gx_div_start( context, divUsuarioscpostalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarioscpostalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarioscpostalfilter_Internalname, context.GetMessage( "Codigo Postal", ""), "", "", lblLblusuarioscpostalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e179y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0190.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuarioscpostal_Internalname, context.GetMessage( "Codigo Postal", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarioscpostal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cusuariosCPostal), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCusuarioscpostal_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cusuariosCPostal), "ZZZZ9") : context.localUtil.Format( (decimal)(AV12cusuariosCPostal), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarioscpostal_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarioscpostal_Visible, edtavCusuarioscpostal_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0190.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e189y1_client"+"'", TempTags, "", 2, "HLP_Gx0190.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0190.htm");
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

      protected void START9Y2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List usuarios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9Y0( ) ;
      }

      protected void WS9Y2( )
      {
         START9Y2( ) ;
         EVT9Y2( ) ;
      }

      protected void EVT9Y2( )
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
                              A145usuariosId = cgiGet( edtusuariosId_Internalname);
                              cmbusuariosTipo.Name = cmbusuariosTipo_Internalname;
                              cmbusuariosTipo.CurrentValue = cgiGet( cmbusuariosTipo_Internalname);
                              A225usuariosTipo = cgiGet( cmbusuariosTipo_Internalname);
                              A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
                              A116PaisID = cgiGet( edtPaisID_Internalname);
                              A266usuariosImagen = cgiGet( edtusuariosImagen_Internalname);
                              AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E199Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E209Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cusuariosid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSID"), AV6cusuariosId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariostipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSTIPO"), AV7cusuariosTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOMBRE"), AV8cusuariosNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuarioscorreo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSCORREO"), AV9cusuariosCorreo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaisid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPAISID"), AV10cPaisID) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariospasw Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSPASW"), AV11cusuariosPasw) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuarioscpostal Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSCPOSTAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cusuariosCPostal )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E219Y2 ();
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

      protected void WE9Y2( )
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

      protected void PA9Y2( )
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
                                        string AV6cusuariosId ,
                                        string AV7cusuariosTipo ,
                                        string AV8cusuariosNombre ,
                                        string AV9cusuariosCorreo ,
                                        string AV10cPaisID ,
                                        string AV11cusuariosPasw ,
                                        int AV12cusuariosCPostal )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.RTrim( A145usuariosId));
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
         if ( cmbavCusuariostipo.ItemCount > 0 )
         {
            AV7cusuariosTipo = cmbavCusuariostipo.getValidValue(AV7cusuariosTipo);
            AssignAttri("", false, "AV7cusuariosTipo", AV7cusuariosTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCusuariostipo.CurrentValue = StringUtil.RTrim( AV7cusuariosTipo);
            AssignProp("", false, cmbavCusuariostipo_Internalname, "Values", cmbavCusuariostipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9Y2( )
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
                                                 AV7cusuariosTipo ,
                                                 AV8cusuariosNombre ,
                                                 AV9cusuariosCorreo ,
                                                 AV10cPaisID ,
                                                 AV11cusuariosPasw ,
                                                 AV12cusuariosCPostal ,
                                                 A225usuariosTipo ,
                                                 A222usuariosNombre ,
                                                 A224usuariosCorreo ,
                                                 A116PaisID ,
                                                 A223usuariosPasw ,
                                                 A231usuariosCPostal ,
                                                 A145usuariosId ,
                                                 AV6cusuariosId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV6cusuariosId = StringUtil.PadR( StringUtil.RTrim( AV6cusuariosId), 20, "%");
            lV7cusuariosTipo = StringUtil.PadR( StringUtil.RTrim( AV7cusuariosTipo), 1, "%");
            lV8cusuariosNombre = StringUtil.PadR( StringUtil.RTrim( AV8cusuariosNombre), 80, "%");
            lV9cusuariosCorreo = StringUtil.Concat( StringUtil.RTrim( AV9cusuariosCorreo), "%", "");
            lV10cPaisID = StringUtil.PadR( StringUtil.RTrim( AV10cPaisID), 2, "%");
            lV11cusuariosPasw = StringUtil.PadR( StringUtil.RTrim( AV11cusuariosPasw), 80, "%");
            /* Using cursor H009Y2 */
            pr_default.execute(0, new Object[] {lV6cusuariosId, lV7cusuariosTipo, lV8cusuariosNombre, lV9cusuariosCorreo, lV10cPaisID, lV11cusuariosPasw, AV12cusuariosCPostal, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A231usuariosCPostal = H009Y2_A231usuariosCPostal[0];
               A223usuariosPasw = H009Y2_A223usuariosPasw[0];
               A224usuariosCorreo = H009Y2_A224usuariosCorreo[0];
               A40000usuariosImagen_GXI = H009Y2_A40000usuariosImagen_GXI[0];
               AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               A116PaisID = H009Y2_A116PaisID[0];
               A222usuariosNombre = H009Y2_A222usuariosNombre[0];
               A225usuariosTipo = H009Y2_A225usuariosTipo[0];
               A145usuariosId = H009Y2_A145usuariosId[0];
               A266usuariosImagen = H009Y2_A266usuariosImagen[0];
               AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               /* Execute user event: Load */
               E209Y2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB9Y0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9Y2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), context));
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
                                              AV7cusuariosTipo ,
                                              AV8cusuariosNombre ,
                                              AV9cusuariosCorreo ,
                                              AV10cPaisID ,
                                              AV11cusuariosPasw ,
                                              AV12cusuariosCPostal ,
                                              A225usuariosTipo ,
                                              A222usuariosNombre ,
                                              A224usuariosCorreo ,
                                              A116PaisID ,
                                              A223usuariosPasw ,
                                              A231usuariosCPostal ,
                                              A145usuariosId ,
                                              AV6cusuariosId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV6cusuariosId = StringUtil.PadR( StringUtil.RTrim( AV6cusuariosId), 20, "%");
         lV7cusuariosTipo = StringUtil.PadR( StringUtil.RTrim( AV7cusuariosTipo), 1, "%");
         lV8cusuariosNombre = StringUtil.PadR( StringUtil.RTrim( AV8cusuariosNombre), 80, "%");
         lV9cusuariosCorreo = StringUtil.Concat( StringUtil.RTrim( AV9cusuariosCorreo), "%", "");
         lV10cPaisID = StringUtil.PadR( StringUtil.RTrim( AV10cPaisID), 2, "%");
         lV11cusuariosPasw = StringUtil.PadR( StringUtil.RTrim( AV11cusuariosPasw), 80, "%");
         /* Using cursor H009Y3 */
         pr_default.execute(1, new Object[] {lV6cusuariosId, lV7cusuariosTipo, lV8cusuariosNombre, lV9cusuariosCorreo, lV10cPaisID, lV11cusuariosPasw, AV12cusuariosCPostal});
         GRID1_nRecordCount = H009Y3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosId, AV7cusuariosTipo, AV8cusuariosNombre, AV9cusuariosCorreo, AV10cPaisID, AV11cusuariosPasw, AV12cusuariosCPostal) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosId, AV7cusuariosTipo, AV8cusuariosNombre, AV9cusuariosCorreo, AV10cPaisID, AV11cusuariosPasw, AV12cusuariosCPostal) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosId, AV7cusuariosTipo, AV8cusuariosNombre, AV9cusuariosCorreo, AV10cPaisID, AV11cusuariosPasw, AV12cusuariosCPostal) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosId, AV7cusuariosTipo, AV8cusuariosNombre, AV9cusuariosCorreo, AV10cPaisID, AV11cusuariosPasw, AV12cusuariosCPostal) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosId, AV7cusuariosTipo, AV8cusuariosNombre, AV9cusuariosCorreo, AV10cPaisID, AV11cusuariosPasw, AV12cusuariosCPostal) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtusuariosId_Enabled = 0;
         cmbusuariosTipo.Enabled = 0;
         edtusuariosNombre_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtusuariosImagen_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E199Y2 ();
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
            AV6cusuariosId = cgiGet( edtavCusuariosid_Internalname);
            AssignAttri("", false, "AV6cusuariosId", AV6cusuariosId);
            cmbavCusuariostipo.Name = cmbavCusuariostipo_Internalname;
            cmbavCusuariostipo.CurrentValue = cgiGet( cmbavCusuariostipo_Internalname);
            AV7cusuariosTipo = cgiGet( cmbavCusuariostipo_Internalname);
            AssignAttri("", false, "AV7cusuariosTipo", AV7cusuariosTipo);
            AV8cusuariosNombre = cgiGet( edtavCusuariosnombre_Internalname);
            AssignAttri("", false, "AV8cusuariosNombre", AV8cusuariosNombre);
            AV9cusuariosCorreo = cgiGet( edtavCusuarioscorreo_Internalname);
            AssignAttri("", false, "AV9cusuariosCorreo", AV9cusuariosCorreo);
            AV10cPaisID = cgiGet( edtavCpaisid_Internalname);
            AssignAttri("", false, "AV10cPaisID", AV10cPaisID);
            AV11cusuariosPasw = cgiGet( edtavCusuariospasw_Internalname);
            AssignAttri("", false, "AV11cusuariosPasw", AV11cusuariosPasw);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuarioscpostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuarioscpostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOSCPOSTAL");
               GX_FocusControl = edtavCusuarioscpostal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cusuariosCPostal = 0;
               AssignAttri("", false, "AV12cusuariosCPostal", StringUtil.LTrimStr( (decimal)(AV12cusuariosCPostal), 5, 0));
            }
            else
            {
               AV12cusuariosCPostal = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCusuarioscpostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cusuariosCPostal", StringUtil.LTrimStr( (decimal)(AV12cusuariosCPostal), 5, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSID"), AV6cusuariosId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSTIPO"), AV7cusuariosTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOMBRE"), AV8cusuariosNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSCORREO"), AV9cusuariosCorreo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPAISID"), AV10cPaisID) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSPASW"), AV11cusuariosPasw) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSCPOSTAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cusuariosCPostal )) )
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
         E199Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E199Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E209Y2( )
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
         E219Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E219Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pusuariosId = A145usuariosId;
         AssignAttri("", false, "AV13pusuariosId", AV13pusuariosId);
         context.setWebReturnParms(new Object[] {(string)AV13pusuariosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pusuariosId"});
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
         AV13pusuariosId = (string)getParm(obj,0);
         AssignAttri("", false, "AV13pusuariosId", AV13pusuariosId);
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
         PA9Y2( ) ;
         WS9Y2( ) ;
         WE9Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320192369", true, true, false);
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
         context.AddJavascriptSource("gx0190.js", "?20269320192369", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_84_idx;
         cmbusuariosTipo_Internalname = "USUARIOSTIPO_"+sGXsfl_84_idx;
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_84_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_84_idx;
         edtusuariosImagen_Internalname = "USUARIOSIMAGEN_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_84_fel_idx;
         cmbusuariosTipo_Internalname = "USUARIOSTIPO_"+sGXsfl_84_fel_idx;
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_84_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_84_fel_idx;
         edtusuariosImagen_Internalname = "USUARIOSIMAGEN_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB9Y0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A145usuariosId))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtusuariosId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A145usuariosId))+"'"+"]);";
            AssignProp("", false, edtusuariosId_Internalname, "Link", edtusuariosId_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosId_Internalname,StringUtil.RTrim( A145usuariosId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtusuariosId_Link,(string)"",(string)"",(string)"",(string)edtusuariosId_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbusuariosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSTIPO_" + sGXsfl_84_idx;
               cmbusuariosTipo.Name = GXCCtl;
               cmbusuariosTipo.WebTags = "";
               cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
               cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
               cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
               cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
               cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
               cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
               cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
               if ( cmbusuariosTipo.ItemCount > 0 )
               {
                  A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosTipo,(string)cmbusuariosTipo_Internalname,StringUtil.RTrim( A225usuariosTipo),(short)1,(string)cmbusuariosTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
            AssignProp("", false, cmbusuariosTipo_Internalname, "Values", (string)(cmbusuariosTipo.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNombre_Internalname,StringUtil.RTrim( A222usuariosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A266usuariosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000usuariosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.PathToRelativeUrl( A266usuariosImagen));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A266usuariosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashes9Y2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCusuariostipo.Name = "vCUSUARIOSTIPO";
         cmbavCusuariostipo.WebTags = "";
         cmbavCusuariostipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
         cmbavCusuariostipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
         cmbavCusuariostipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
         cmbavCusuariostipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
         cmbavCusuariostipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
         cmbavCusuariostipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
         cmbavCusuariostipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
         if ( cmbavCusuariostipo.ItemCount > 0 )
         {
            AV7cusuariosTipo = cmbavCusuariostipo.getValidValue(AV7cusuariosTipo);
            AssignAttri("", false, "AV7cusuariosTipo", AV7cusuariosTipo);
         }
         GXCCtl = "USUARIOSTIPO_" + sGXsfl_84_idx;
         cmbusuariosTipo.Name = GXCCtl;
         cmbusuariosTipo.WebTags = "";
         cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
         cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
         cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
         cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
         cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
         cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
         cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
            A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "PaisId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen 800x800", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A145usuariosId)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtusuariosId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A225usuariosTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A222usuariosNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A266usuariosImagen));
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
         lblLblusuariosidfilter_Internalname = "LBLUSUARIOSIDFILTER";
         edtavCusuariosid_Internalname = "vCUSUARIOSID";
         divUsuariosidfiltercontainer_Internalname = "USUARIOSIDFILTERCONTAINER";
         lblLblusuariostipofilter_Internalname = "LBLUSUARIOSTIPOFILTER";
         cmbavCusuariostipo_Internalname = "vCUSUARIOSTIPO";
         divUsuariostipofiltercontainer_Internalname = "USUARIOSTIPOFILTERCONTAINER";
         lblLblusuariosnombrefilter_Internalname = "LBLUSUARIOSNOMBREFILTER";
         edtavCusuariosnombre_Internalname = "vCUSUARIOSNOMBRE";
         divUsuariosnombrefiltercontainer_Internalname = "USUARIOSNOMBREFILTERCONTAINER";
         lblLblusuarioscorreofilter_Internalname = "LBLUSUARIOSCORREOFILTER";
         edtavCusuarioscorreo_Internalname = "vCUSUARIOSCORREO";
         divUsuarioscorreofiltercontainer_Internalname = "USUARIOSCORREOFILTERCONTAINER";
         lblLblpaisidfilter_Internalname = "LBLPAISIDFILTER";
         edtavCpaisid_Internalname = "vCPAISID";
         divPaisidfiltercontainer_Internalname = "PAISIDFILTERCONTAINER";
         lblLblusuariospaswfilter_Internalname = "LBLUSUARIOSPASWFILTER";
         edtavCusuariospasw_Internalname = "vCUSUARIOSPASW";
         divUsuariospaswfiltercontainer_Internalname = "USUARIOSPASWFILTERCONTAINER";
         lblLblusuarioscpostalfilter_Internalname = "LBLUSUARIOSCPOSTALFILTER";
         edtavCusuarioscpostal_Internalname = "vCUSUARIOSCPOSTAL";
         divUsuarioscpostalfiltercontainer_Internalname = "USUARIOSCPOSTALFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtusuariosId_Internalname = "USUARIOSID";
         cmbusuariosTipo_Internalname = "USUARIOSTIPO";
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtPaisID_Internalname = "PAISID";
         edtusuariosImagen_Internalname = "USUARIOSIMAGEN";
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
         edtPaisID_Jsonclick = "";
         edtusuariosNombre_Jsonclick = "";
         cmbusuariosTipo_Jsonclick = "";
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtusuariosImagen_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtusuariosNombre_Enabled = 0;
         cmbusuariosTipo.Enabled = 0;
         edtusuariosId_Enabled = 0;
         edtavCusuarioscpostal_Jsonclick = "";
         edtavCusuarioscpostal_Enabled = 1;
         edtavCusuarioscpostal_Visible = 1;
         edtavCusuariospasw_Jsonclick = "";
         edtavCusuariospasw_Enabled = 1;
         edtavCusuariospasw_Visible = 1;
         edtavCpaisid_Jsonclick = "";
         edtavCpaisid_Enabled = 1;
         edtavCpaisid_Visible = 1;
         edtavCusuarioscorreo_Jsonclick = "";
         edtavCusuarioscorreo_Enabled = 1;
         edtavCusuarioscorreo_Visible = 1;
         edtavCusuariosnombre_Jsonclick = "";
         edtavCusuariosnombre_Enabled = 1;
         edtavCusuariosnombre_Visible = 1;
         cmbavCusuariostipo_Jsonclick = "";
         cmbavCusuariostipo.Visible = 1;
         cmbavCusuariostipo.Enabled = 1;
         edtavCusuariosid_Jsonclick = "";
         edtavCusuariosid_Enabled = 1;
         edtavCusuariosid_Visible = 1;
         divUsuarioscpostalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariospaswfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPaisidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuarioscorreofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariosnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariostipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List usuarios", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cusuariosId',fld:'vCUSUARIOSID',pic:'',type:'char'},{av:'cmbavCusuariostipo'},{av:'AV7cusuariosTipo',fld:'vCUSUARIOSTIPO',pic:'',type:'char'},{av:'AV8cusuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV9cusuariosCorreo',fld:'vCUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV10cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV11cusuariosPasw',fld:'vCUSUARIOSPASW',pic:'',type:'char'},{av:'AV12cusuariosCPostal',fld:'vCUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E189Y1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOSIDFILTER.CLICK","{handler:'E119Y1',iparms:[{av:'divUsuariosidfiltercontainer_Class',ctrl:'USUARIOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSIDFILTER.CLICK",",oparms:[{av:'divUsuariosidfiltercontainer_Class',ctrl:'USUARIOSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosid_Visible',ctrl:'vCUSUARIOSID',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSTIPOFILTER.CLICK","{handler:'E129Y1',iparms:[{av:'divUsuariostipofiltercontainer_Class',ctrl:'USUARIOSTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSTIPOFILTER.CLICK",",oparms:[{av:'divUsuariostipofiltercontainer_Class',ctrl:'USUARIOSTIPOFILTERCONTAINER',prop:'Class'},{av:'cmbavCusuariostipo'}]}");
         setEventMetadata("LBLUSUARIOSNOMBREFILTER.CLICK","{handler:'E139Y1',iparms:[{av:'divUsuariosnombrefiltercontainer_Class',ctrl:'USUARIOSNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSNOMBREFILTER.CLICK",",oparms:[{av:'divUsuariosnombrefiltercontainer_Class',ctrl:'USUARIOSNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosnombre_Visible',ctrl:'vCUSUARIOSNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSCORREOFILTER.CLICK","{handler:'E149Y1',iparms:[{av:'divUsuarioscorreofiltercontainer_Class',ctrl:'USUARIOSCORREOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSCORREOFILTER.CLICK",",oparms:[{av:'divUsuarioscorreofiltercontainer_Class',ctrl:'USUARIOSCORREOFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarioscorreo_Visible',ctrl:'vCUSUARIOSCORREO',prop:'Visible'}]}");
         setEventMetadata("LBLPAISIDFILTER.CLICK","{handler:'E159Y1',iparms:[{av:'divPaisidfiltercontainer_Class',ctrl:'PAISIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAISIDFILTER.CLICK",",oparms:[{av:'divPaisidfiltercontainer_Class',ctrl:'PAISIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaisid_Visible',ctrl:'vCPAISID',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSPASWFILTER.CLICK","{handler:'E169Y1',iparms:[{av:'divUsuariospaswfiltercontainer_Class',ctrl:'USUARIOSPASWFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSPASWFILTER.CLICK",",oparms:[{av:'divUsuariospaswfiltercontainer_Class',ctrl:'USUARIOSPASWFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariospasw_Visible',ctrl:'vCUSUARIOSPASW',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSCPOSTALFILTER.CLICK","{handler:'E179Y1',iparms:[{av:'divUsuarioscpostalfiltercontainer_Class',ctrl:'USUARIOSCPOSTALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSCPOSTALFILTER.CLICK",",oparms:[{av:'divUsuarioscpostalfiltercontainer_Class',ctrl:'USUARIOSCPOSTALFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarioscpostal_Visible',ctrl:'vCUSUARIOSCPOSTAL',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E219Y2',iparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pusuariosId',fld:'vPUSUARIOSID',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cusuariosId',fld:'vCUSUARIOSID',pic:'',type:'char'},{av:'cmbavCusuariostipo'},{av:'AV7cusuariosTipo',fld:'vCUSUARIOSTIPO',pic:'',type:'char'},{av:'AV8cusuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV9cusuariosCorreo',fld:'vCUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV10cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV11cusuariosPasw',fld:'vCUSUARIOSPASW',pic:'',type:'char'},{av:'AV12cusuariosCPostal',fld:'vCUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cusuariosId',fld:'vCUSUARIOSID',pic:'',type:'char'},{av:'cmbavCusuariostipo'},{av:'AV7cusuariosTipo',fld:'vCUSUARIOSTIPO',pic:'',type:'char'},{av:'AV8cusuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV9cusuariosCorreo',fld:'vCUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV10cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV11cusuariosPasw',fld:'vCUSUARIOSPASW',pic:'',type:'char'},{av:'AV12cusuariosCPostal',fld:'vCUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cusuariosId',fld:'vCUSUARIOSID',pic:'',type:'char'},{av:'cmbavCusuariostipo'},{av:'AV7cusuariosTipo',fld:'vCUSUARIOSTIPO',pic:'',type:'char'},{av:'AV8cusuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV9cusuariosCorreo',fld:'vCUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV10cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV11cusuariosPasw',fld:'vCUSUARIOSPASW',pic:'',type:'char'},{av:'AV12cusuariosCPostal',fld:'vCUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cusuariosId',fld:'vCUSUARIOSID',pic:'',type:'char'},{av:'cmbavCusuariostipo'},{av:'AV7cusuariosTipo',fld:'vCUSUARIOSTIPO',pic:'',type:'char'},{av:'AV8cusuariosNombre',fld:'vCUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV9cusuariosCorreo',fld:'vCUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV10cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV11cusuariosPasw',fld:'vCUSUARIOSPASW',pic:'',type:'char'},{av:'AV12cusuariosCPostal',fld:'vCUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CUSUARIOSCORREO","{handler:'Validv_Cusuarioscorreo',iparms:[]");
         setEventMetadata("VALIDV_CUSUARIOSCORREO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariosimagen',iparms:[]");
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
         AV13pusuariosId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cusuariosId = "";
         AV7cusuariosTipo = "";
         AV8cusuariosNombre = "";
         AV9cusuariosCorreo = "";
         AV10cPaisID = "";
         AV11cusuariosPasw = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblusuariosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblusuariostipofilter_Jsonclick = "";
         lblLblusuariosnombrefilter_Jsonclick = "";
         lblLblusuarioscorreofilter_Jsonclick = "";
         lblLblpaisidfilter_Jsonclick = "";
         lblLblusuariospaswfilter_Jsonclick = "";
         lblLblusuarioscpostalfilter_Jsonclick = "";
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
         A145usuariosId = "";
         A225usuariosTipo = "";
         A222usuariosNombre = "";
         A116PaisID = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         lV6cusuariosId = "";
         lV7cusuariosTipo = "";
         lV8cusuariosNombre = "";
         lV9cusuariosCorreo = "";
         lV10cPaisID = "";
         lV11cusuariosPasw = "";
         A224usuariosCorreo = "";
         A223usuariosPasw = "";
         H009Y2_A231usuariosCPostal = new int[1] ;
         H009Y2_A223usuariosPasw = new string[] {""} ;
         H009Y2_A224usuariosCorreo = new string[] {""} ;
         H009Y2_A40000usuariosImagen_GXI = new string[] {""} ;
         H009Y2_A116PaisID = new string[] {""} ;
         H009Y2_A222usuariosNombre = new string[] {""} ;
         H009Y2_A225usuariosTipo = new string[] {""} ;
         H009Y2_A145usuariosId = new string[] {""} ;
         H009Y2_A266usuariosImagen = new string[] {""} ;
         H009Y3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0190__default(),
            new Object[][] {
                new Object[] {
               H009Y2_A231usuariosCPostal, H009Y2_A223usuariosPasw, H009Y2_A224usuariosCorreo, H009Y2_A40000usuariosImagen_GXI, H009Y2_A116PaisID, H009Y2_A222usuariosNombre, H009Y2_A225usuariosTipo, H009Y2_A145usuariosId, H009Y2_A266usuariosImagen
               }
               , new Object[] {
               H009Y3_AGRID1_nRecordCount
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
      private int AV12cusuariosCPostal ;
      private int edtavCusuariosid_Visible ;
      private int edtavCusuariosid_Enabled ;
      private int edtavCusuariosnombre_Visible ;
      private int edtavCusuariosnombre_Enabled ;
      private int edtavCusuarioscorreo_Visible ;
      private int edtavCusuarioscorreo_Enabled ;
      private int edtavCpaisid_Visible ;
      private int edtavCpaisid_Enabled ;
      private int edtavCusuariospasw_Visible ;
      private int edtavCusuariospasw_Enabled ;
      private int edtavCusuarioscpostal_Enabled ;
      private int edtavCusuarioscpostal_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A231usuariosCPostal ;
      private int edtusuariosId_Enabled ;
      private int edtusuariosNombre_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtusuariosImagen_Enabled ;
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
      private string AV13pusuariosId ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divUsuariosidfiltercontainer_Class ;
      private string divUsuariostipofiltercontainer_Class ;
      private string divUsuariosnombrefiltercontainer_Class ;
      private string divUsuarioscorreofiltercontainer_Class ;
      private string divPaisidfiltercontainer_Class ;
      private string divUsuariospaswfiltercontainer_Class ;
      private string divUsuarioscpostalfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV6cusuariosId ;
      private string AV7cusuariosTipo ;
      private string AV8cusuariosNombre ;
      private string AV10cPaisID ;
      private string AV11cusuariosPasw ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divUsuariosidfiltercontainer_Internalname ;
      private string lblLblusuariosidfilter_Internalname ;
      private string lblLblusuariosidfilter_Jsonclick ;
      private string edtavCusuariosid_Internalname ;
      private string TempTags ;
      private string edtavCusuariosid_Jsonclick ;
      private string divUsuariostipofiltercontainer_Internalname ;
      private string lblLblusuariostipofilter_Internalname ;
      private string lblLblusuariostipofilter_Jsonclick ;
      private string cmbavCusuariostipo_Internalname ;
      private string cmbavCusuariostipo_Jsonclick ;
      private string divUsuariosnombrefiltercontainer_Internalname ;
      private string lblLblusuariosnombrefilter_Internalname ;
      private string lblLblusuariosnombrefilter_Jsonclick ;
      private string edtavCusuariosnombre_Internalname ;
      private string edtavCusuariosnombre_Jsonclick ;
      private string divUsuarioscorreofiltercontainer_Internalname ;
      private string lblLblusuarioscorreofilter_Internalname ;
      private string lblLblusuarioscorreofilter_Jsonclick ;
      private string edtavCusuarioscorreo_Internalname ;
      private string edtavCusuarioscorreo_Jsonclick ;
      private string divPaisidfiltercontainer_Internalname ;
      private string lblLblpaisidfilter_Internalname ;
      private string lblLblpaisidfilter_Jsonclick ;
      private string edtavCpaisid_Internalname ;
      private string edtavCpaisid_Jsonclick ;
      private string divUsuariospaswfiltercontainer_Internalname ;
      private string lblLblusuariospaswfilter_Internalname ;
      private string lblLblusuariospaswfilter_Jsonclick ;
      private string edtavCusuariospasw_Internalname ;
      private string edtavCusuariospasw_Jsonclick ;
      private string divUsuarioscpostalfiltercontainer_Internalname ;
      private string lblLblusuarioscpostalfilter_Internalname ;
      private string lblLblusuarioscpostalfilter_Jsonclick ;
      private string edtavCusuarioscpostal_Internalname ;
      private string edtavCusuarioscpostal_Jsonclick ;
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
      private string A145usuariosId ;
      private string edtusuariosId_Internalname ;
      private string cmbusuariosTipo_Internalname ;
      private string A225usuariosTipo ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Internalname ;
      private string edtusuariosImagen_Internalname ;
      private string lV6cusuariosId ;
      private string lV7cusuariosTipo ;
      private string lV8cusuariosNombre ;
      private string lV10cPaisID ;
      private string lV11cusuariosPasw ;
      private string A223usuariosPasw ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtusuariosId_Link ;
      private string edtusuariosId_Jsonclick ;
      private string GXCCtl ;
      private string cmbusuariosTipo_Jsonclick ;
      private string edtusuariosNombre_Jsonclick ;
      private string edtPaisID_Jsonclick ;
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
      private bool A266usuariosImagen_IsBlob ;
      private string AV9cusuariosCorreo ;
      private string AV15Linkselection_GXI ;
      private string A40000usuariosImagen_GXI ;
      private string lV9cusuariosCorreo ;
      private string A224usuariosCorreo ;
      private string AV5LinkSelection ;
      private string A266usuariosImagen ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCusuariostipo ;
      private GXCombobox cmbusuariosTipo ;
      private IDataStoreProvider pr_default ;
      private int[] H009Y2_A231usuariosCPostal ;
      private string[] H009Y2_A223usuariosPasw ;
      private string[] H009Y2_A224usuariosCorreo ;
      private string[] H009Y2_A40000usuariosImagen_GXI ;
      private string[] H009Y2_A116PaisID ;
      private string[] H009Y2_A222usuariosNombre ;
      private string[] H009Y2_A225usuariosTipo ;
      private string[] H009Y2_A145usuariosId ;
      private string[] H009Y2_A266usuariosImagen ;
      private long[] H009Y3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pusuariosId ;
   }

   public class gx0190__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009Y2( IGxContext context ,
                                             string AV7cusuariosTipo ,
                                             string AV8cusuariosNombre ,
                                             string AV9cusuariosCorreo ,
                                             string AV10cPaisID ,
                                             string AV11cusuariosPasw ,
                                             int AV12cusuariosCPostal ,
                                             string A225usuariosTipo ,
                                             string A222usuariosNombre ,
                                             string A224usuariosCorreo ,
                                             string A116PaisID ,
                                             string A223usuariosPasw ,
                                             int A231usuariosCPostal ,
                                             string A145usuariosId ,
                                             string AV6cusuariosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [usuariosCPostal], [usuariosPasw], [usuariosCorreo], [usuariosImagen_GXI], [PaisID], [usuariosNombre], [usuariosTipo], [usuariosId], [usuariosImagen]";
         sFromString = " FROM [usuarios]";
         sOrderString = "";
         AddWhere(sWhereString, "([usuariosId] like @lV6cusuariosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cusuariosTipo)) )
         {
            AddWhere(sWhereString, "([usuariosTipo] like @lV7cusuariosTipo)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cusuariosNombre)) )
         {
            AddWhere(sWhereString, "([usuariosNombre] like @lV8cusuariosNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cusuariosCorreo)) )
         {
            AddWhere(sWhereString, "([usuariosCorreo] like @lV9cusuariosCorreo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cPaisID)) )
         {
            AddWhere(sWhereString, "([PaisID] like @lV10cPaisID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cusuariosPasw)) )
         {
            AddWhere(sWhereString, "([usuariosPasw] like @lV11cusuariosPasw)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cusuariosCPostal) )
         {
            AddWhere(sWhereString, "([usuariosCPostal] >= @AV12cusuariosCPostal)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [usuariosId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009Y3( IGxContext context ,
                                             string AV7cusuariosTipo ,
                                             string AV8cusuariosNombre ,
                                             string AV9cusuariosCorreo ,
                                             string AV10cPaisID ,
                                             string AV11cusuariosPasw ,
                                             int AV12cusuariosCPostal ,
                                             string A225usuariosTipo ,
                                             string A222usuariosNombre ,
                                             string A224usuariosCorreo ,
                                             string A116PaisID ,
                                             string A223usuariosPasw ,
                                             int A231usuariosCPostal ,
                                             string A145usuariosId ,
                                             string AV6cusuariosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [usuarios]";
         AddWhere(sWhereString, "([usuariosId] like @lV6cusuariosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cusuariosTipo)) )
         {
            AddWhere(sWhereString, "([usuariosTipo] like @lV7cusuariosTipo)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cusuariosNombre)) )
         {
            AddWhere(sWhereString, "([usuariosNombre] like @lV8cusuariosNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cusuariosCorreo)) )
         {
            AddWhere(sWhereString, "([usuariosCorreo] like @lV9cusuariosCorreo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cPaisID)) )
         {
            AddWhere(sWhereString, "([PaisID] like @lV10cPaisID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cusuariosPasw)) )
         {
            AddWhere(sWhereString, "([usuariosPasw] like @lV11cusuariosPasw)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cusuariosCPostal) )
         {
            AddWhere(sWhereString, "([usuariosCPostal] >= @AV12cusuariosCPostal)");
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
                     return conditional_H009Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_H009Y3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmH009Y2;
          prmH009Y2 = new Object[] {
          new ParDef("@lV6cusuariosId",GXType.NChar,20,0) ,
          new ParDef("@lV7cusuariosTipo",GXType.NChar,1,0) ,
          new ParDef("@lV8cusuariosNombre",GXType.NChar,80,0) ,
          new ParDef("@lV9cusuariosCorreo",GXType.NVarChar,100,0) ,
          new ParDef("@lV10cPaisID",GXType.NChar,2,0) ,
          new ParDef("@lV11cusuariosPasw",GXType.NChar,80,0) ,
          new ParDef("@AV12cusuariosCPostal",GXType.Int32,5,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009Y3;
          prmH009Y3 = new Object[] {
          new ParDef("@lV6cusuariosId",GXType.NChar,20,0) ,
          new ParDef("@lV7cusuariosTipo",GXType.NChar,1,0) ,
          new ParDef("@lV8cusuariosNombre",GXType.NChar,80,0) ,
          new ParDef("@lV9cusuariosCorreo",GXType.NVarChar,100,0) ,
          new ParDef("@lV10cPaisID",GXType.NChar,2,0) ,
          new ParDef("@lV11cusuariosPasw",GXType.NChar,80,0) ,
          new ParDef("@AV12cusuariosCPostal",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Y2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Y3,1, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 2);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

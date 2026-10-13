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
   public class gx00y0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00y0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00y0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pProfesionalesId )
      {
         this.AV13pProfesionalesId = "" ;
         ExecutePrivate();
         aP0_pProfesionalesId=this.AV13pProfesionalesId;
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
            gxfirstwebparm = GetFirstPar( "pProfesionalesId");
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
               gxfirstwebparm = GetFirstPar( "pProfesionalesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProfesionalesId");
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
               AV13pProfesionalesId = gxfirstwebparm;
               AssignAttri("", false, "AV13pProfesionalesId", AV13pProfesionalesId);
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
         AV6cProfesionalesId = GetPar( "cProfesionalesId");
         AV7cProfesionalesPrimerNombre = GetPar( "cProfesionalesPrimerNombre");
         AV8cProfesionalesSegundoNombre = GetPar( "cProfesionalesSegundoNombre");
         AV9cProfesionalesApellidoPrimero = GetPar( "cProfesionalesApellidoPrimero");
         AV10cProfesionalesApellidoSegundo = GetPar( "cProfesionalesApellidoSegundo");
         AV11cProfesionalesTelefono = GetPar( "cProfesionalesTelefono");
         AV12cProfesionalesEmail = GetPar( "cProfesionalesEmail");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV7cProfesionalesPrimerNombre, AV8cProfesionalesSegundoNombre, AV9cProfesionalesApellidoPrimero, AV10cProfesionalesApellidoSegundo, AV11cProfesionalesTelefono, AV12cProfesionalesEmail) ;
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
         PA9L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9L2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00y0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pProfesionalesId))}, new string[] {"pProfesionalesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESID", StringUtil.RTrim( AV6cProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV7cProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( AV8cProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV9cProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( AV10cProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESTELEFONO", StringUtil.RTrim( AV11cProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESEMAIL", AV12cProfesionalesEmail);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPROFESIONALESID", StringUtil.RTrim( AV13pProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESIDFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesprimernombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESSEGUNDONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalessegundonombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMEROFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesapellidoprimerofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOSEGUNDOFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesapellidosegundofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESTELEFONOFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalestelefonofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesemailfiltercontainer_Class));
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
            WE9L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9L2( ) ;
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
         return formatLink("gx00y0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pProfesionalesId))}, new string[] {"pProfesionalesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00Y0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Profesionales", "") ;
      }

      protected void WB9L0( )
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
            GxWebStd.gx_div_start( context, divProfesionalesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesidfilter_Internalname, context.GetMessage( "Identidad", ""), "", "", lblLblprofesionalesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesid_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesid_Internalname, StringUtil.RTrim( AV6cProfesionalesId), StringUtil.RTrim( context.localUtil.Format( AV6cProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavCprofesionalesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesid_Visible, edtavCprofesionalesid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalesprimernombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesprimernombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesprimernombrefilter_Internalname, context.GetMessage( "Primer Nombre", ""), "", "", lblLblprofesionalesprimernombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesprimernombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesprimernombre_Internalname, StringUtil.RTrim( AV7cProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( AV7cProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofesionalesprimernombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesprimernombre_Visible, edtavCprofesionalesprimernombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalessegundonombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalessegundonombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalessegundonombrefilter_Internalname, context.GetMessage( "Segundo Nombre", ""), "", "", lblLblprofesionalessegundonombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalessegundonombre_Internalname, context.GetMessage( "Segundo Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalessegundonombre_Internalname, StringUtil.RTrim( AV8cProfesionalesSegundoNombre), StringUtil.RTrim( context.localUtil.Format( AV8cProfesionalesSegundoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofesionalessegundonombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalessegundonombre_Visible, edtavCprofesionalessegundonombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalesapellidoprimerofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesapellidoprimerofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesapellidoprimerofilter_Internalname, context.GetMessage( "Primero Apellido ", ""), "", "", lblLblprofesionalesapellidoprimerofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesapellidoprimero_Internalname, context.GetMessage( "Primero Apellido ", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesapellidoprimero_Internalname, StringUtil.RTrim( AV9cProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( AV9cProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofesionalesapellidoprimero_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesapellidoprimero_Visible, edtavCprofesionalesapellidoprimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalesapellidosegundofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesapellidosegundofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesapellidosegundofilter_Internalname, context.GetMessage( "Segundo Apellido ", ""), "", "", lblLblprofesionalesapellidosegundofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesapellidosegundo_Internalname, context.GetMessage( "Segundo Apellido ", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesapellidosegundo_Internalname, StringUtil.RTrim( AV10cProfesionalesApellidoSegundo), StringUtil.RTrim( context.localUtil.Format( AV10cProfesionalesApellidoSegundo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofesionalesapellidosegundo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesapellidosegundo_Visible, edtavCprofesionalesapellidosegundo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalestelefonofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalestelefonofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalestelefonofilter_Internalname, context.GetMessage( "Teléfono", ""), "", "", lblLblprofesionalestelefonofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalestelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalestelefono_Internalname, StringUtil.RTrim( AV11cProfesionalesTelefono), StringUtil.RTrim( context.localUtil.Format( AV11cProfesionalesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofesionalestelefono_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalestelefono_Visible, edtavCprofesionalestelefono_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalesemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesemailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesemailfilter_Internalname, context.GetMessage( "Email", ""), "", "", lblLblprofesionalesemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e179l1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Y0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesemail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesemail_Internalname, AV12cProfesionalesEmail, StringUtil.RTrim( context.localUtil.Format( AV12cProfesionalesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "email@correo.com", ""), edtavCprofesionalesemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesemail_Visible, edtavCprofesionalesemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e189l1_client"+"'", TempTags, "", 2, "HLP_Gx00Y0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00Y0.htm");
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

      protected void START9L2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9L0( ) ;
      }

      protected void WS9L2( )
      {
         START9L2( ) ;
         EVT9L2( ) ;
      }

      protected void EVT9L2( )
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
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A169ProfesionalesPhoto = cgiGet( edtProfesionalesPhoto_Internalname);
                              AssignProp("", false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E199L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E209L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cprofesionalesid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESID"), AV6cProfesionalesId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalesprimernombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESPRIMERNOMBRE"), AV7cProfesionalesPrimerNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalessegundonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESSEGUNDONOMBRE"), AV8cProfesionalesSegundoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalesapellidoprimero Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESAPELLIDOPRIMERO"), AV9cProfesionalesApellidoPrimero) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalesapellidosegundo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESAPELLIDOSEGUNDO"), AV10cProfesionalesApellidoSegundo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalestelefono Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESTELEFONO"), AV11cProfesionalesTelefono) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalesemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESEMAIL"), AV12cProfesionalesEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E219L2 ();
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

      protected void WE9L2( )
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

      protected void PA9L2( )
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
                                        string AV6cProfesionalesId ,
                                        string AV7cProfesionalesPrimerNombre ,
                                        string AV8cProfesionalesSegundoNombre ,
                                        string AV9cProfesionalesApellidoPrimero ,
                                        string AV10cProfesionalesApellidoSegundo ,
                                        string AV11cProfesionalesTelefono ,
                                        string AV12cProfesionalesEmail )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
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
         RF9L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9L2( )
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
                                                 AV7cProfesionalesPrimerNombre ,
                                                 AV8cProfesionalesSegundoNombre ,
                                                 AV9cProfesionalesApellidoPrimero ,
                                                 AV10cProfesionalesApellidoSegundo ,
                                                 AV11cProfesionalesTelefono ,
                                                 AV12cProfesionalesEmail ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A193ProfesionalesEmail ,
                                                 A120ProfesionalesId ,
                                                 AV6cProfesionalesId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV6cProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV6cProfesionalesId), 20, "%");
            lV7cProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV7cProfesionalesPrimerNombre), 30, "%");
            lV8cProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV8cProfesionalesSegundoNombre), 30, "%");
            lV9cProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV9cProfesionalesApellidoPrimero), 30, "%");
            lV10cProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV10cProfesionalesApellidoSegundo), 30, "%");
            lV11cProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV11cProfesionalesTelefono), 20, "%");
            lV12cProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV12cProfesionalesEmail), "%", "");
            /* Using cursor H009L2 */
            pr_default.execute(0, new Object[] {lV6cProfesionalesId, lV7cProfesionalesPrimerNombre, lV8cProfesionalesSegundoNombre, lV9cProfesionalesApellidoPrimero, lV10cProfesionalesApellidoSegundo, lV11cProfesionalesTelefono, lV12cProfesionalesEmail, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A193ProfesionalesEmail = H009L2_A193ProfesionalesEmail[0];
               n193ProfesionalesEmail = H009L2_n193ProfesionalesEmail[0];
               A170ProfesionalesTelefono = H009L2_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H009L2_A192ProfesionalesApellidoSegundo[0];
               A40000ProfesionalesPhoto_GXI = H009L2_A40000ProfesionalesPhoto_GXI[0];
               AssignProp("", false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A167ProfesionalesApellidoPrimero = H009L2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H009L2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H009L2_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H009L2_A120ProfesionalesId[0];
               A169ProfesionalesPhoto = H009L2_A169ProfesionalesPhoto[0];
               AssignProp("", false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               /* Execute user event: Load */
               E209L2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB9L0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9L2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
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
                                              AV7cProfesionalesPrimerNombre ,
                                              AV8cProfesionalesSegundoNombre ,
                                              AV9cProfesionalesApellidoPrimero ,
                                              AV10cProfesionalesApellidoSegundo ,
                                              AV11cProfesionalesTelefono ,
                                              AV12cProfesionalesEmail ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              AV6cProfesionalesId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV6cProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV6cProfesionalesId), 20, "%");
         lV7cProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV7cProfesionalesPrimerNombre), 30, "%");
         lV8cProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV8cProfesionalesSegundoNombre), 30, "%");
         lV9cProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV9cProfesionalesApellidoPrimero), 30, "%");
         lV10cProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV10cProfesionalesApellidoSegundo), 30, "%");
         lV11cProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV11cProfesionalesTelefono), 20, "%");
         lV12cProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV12cProfesionalesEmail), "%", "");
         /* Using cursor H009L3 */
         pr_default.execute(1, new Object[] {lV6cProfesionalesId, lV7cProfesionalesPrimerNombre, lV8cProfesionalesSegundoNombre, lV9cProfesionalesApellidoPrimero, lV10cProfesionalesApellidoSegundo, lV11cProfesionalesTelefono, lV12cProfesionalesEmail});
         GRID1_nRecordCount = H009L3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV7cProfesionalesPrimerNombre, AV8cProfesionalesSegundoNombre, AV9cProfesionalesApellidoPrimero, AV10cProfesionalesApellidoSegundo, AV11cProfesionalesTelefono, AV12cProfesionalesEmail) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV7cProfesionalesPrimerNombre, AV8cProfesionalesSegundoNombre, AV9cProfesionalesApellidoPrimero, AV10cProfesionalesApellidoSegundo, AV11cProfesionalesTelefono, AV12cProfesionalesEmail) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV7cProfesionalesPrimerNombre, AV8cProfesionalesSegundoNombre, AV9cProfesionalesApellidoPrimero, AV10cProfesionalesApellidoSegundo, AV11cProfesionalesTelefono, AV12cProfesionalesEmail) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV7cProfesionalesPrimerNombre, AV8cProfesionalesSegundoNombre, AV9cProfesionalesApellidoPrimero, AV10cProfesionalesApellidoSegundo, AV11cProfesionalesTelefono, AV12cProfesionalesEmail) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV7cProfesionalesPrimerNombre, AV8cProfesionalesSegundoNombre, AV9cProfesionalesApellidoPrimero, AV10cProfesionalesApellidoSegundo, AV11cProfesionalesTelefono, AV12cProfesionalesEmail) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesPhoto_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E199L2 ();
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
            AV6cProfesionalesId = cgiGet( edtavCprofesionalesid_Internalname);
            AssignAttri("", false, "AV6cProfesionalesId", AV6cProfesionalesId);
            AV7cProfesionalesPrimerNombre = cgiGet( edtavCprofesionalesprimernombre_Internalname);
            AssignAttri("", false, "AV7cProfesionalesPrimerNombre", AV7cProfesionalesPrimerNombre);
            AV8cProfesionalesSegundoNombre = cgiGet( edtavCprofesionalessegundonombre_Internalname);
            AssignAttri("", false, "AV8cProfesionalesSegundoNombre", AV8cProfesionalesSegundoNombre);
            AV9cProfesionalesApellidoPrimero = cgiGet( edtavCprofesionalesapellidoprimero_Internalname);
            AssignAttri("", false, "AV9cProfesionalesApellidoPrimero", AV9cProfesionalesApellidoPrimero);
            AV10cProfesionalesApellidoSegundo = cgiGet( edtavCprofesionalesapellidosegundo_Internalname);
            AssignAttri("", false, "AV10cProfesionalesApellidoSegundo", AV10cProfesionalesApellidoSegundo);
            AV11cProfesionalesTelefono = cgiGet( edtavCprofesionalestelefono_Internalname);
            AssignAttri("", false, "AV11cProfesionalesTelefono", AV11cProfesionalesTelefono);
            AV12cProfesionalesEmail = cgiGet( edtavCprofesionalesemail_Internalname);
            AssignAttri("", false, "AV12cProfesionalesEmail", AV12cProfesionalesEmail);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESID"), AV6cProfesionalesId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESPRIMERNOMBRE"), AV7cProfesionalesPrimerNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESSEGUNDONOMBRE"), AV8cProfesionalesSegundoNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESAPELLIDOPRIMERO"), AV9cProfesionalesApellidoPrimero) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESAPELLIDOSEGUNDO"), AV10cProfesionalesApellidoSegundo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESTELEFONO"), AV11cProfesionalesTelefono) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESEMAIL"), AV12cProfesionalesEmail) != 0 )
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
         E199L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E199L2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E209L2( )
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
         E219L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E219L2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pProfesionalesId = A120ProfesionalesId;
         AssignAttri("", false, "AV13pProfesionalesId", AV13pProfesionalesId);
         context.setWebReturnParms(new Object[] {(string)AV13pProfesionalesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pProfesionalesId"});
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
         AV13pProfesionalesId = (string)getParm(obj,0);
         AssignAttri("", false, "AV13pProfesionalesId", AV13pProfesionalesId);
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
         PA9L2( ) ;
         WS9L2( ) ;
         WE9L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126068", true, true, false);
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
         context.AddJavascriptSource("gx00y0.js", "?20267302126068", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_84_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_84_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_84_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_84_idx;
         edtProfesionalesPhoto_Internalname = "PROFESIONALESPHOTO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_84_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_84_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_84_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_84_fel_idx;
         edtProfesionalesPhoto_Internalname = "PROFESIONALESPHOTO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB9L0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A120ProfesionalesId))+"'"+"]);";
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
            ROClassString = "Attribute";
            edtProfesionalesId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A120ProfesionalesId))+"'"+"]);";
            AssignProp("", false, edtProfesionalesId_Internalname, "Link", edtProfesionalesId_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProfesionalesId_Link,(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A169ProfesionalesPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A169ProfesionalesPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashes9L2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtProfesionalesId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A169ProfesionalesPhoto));
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
         lblLblprofesionalesidfilter_Internalname = "LBLPROFESIONALESIDFILTER";
         edtavCprofesionalesid_Internalname = "vCPROFESIONALESID";
         divProfesionalesidfiltercontainer_Internalname = "PROFESIONALESIDFILTERCONTAINER";
         lblLblprofesionalesprimernombrefilter_Internalname = "LBLPROFESIONALESPRIMERNOMBREFILTER";
         edtavCprofesionalesprimernombre_Internalname = "vCPROFESIONALESPRIMERNOMBRE";
         divProfesionalesprimernombrefiltercontainer_Internalname = "PROFESIONALESPRIMERNOMBREFILTERCONTAINER";
         lblLblprofesionalessegundonombrefilter_Internalname = "LBLPROFESIONALESSEGUNDONOMBREFILTER";
         edtavCprofesionalessegundonombre_Internalname = "vCPROFESIONALESSEGUNDONOMBRE";
         divProfesionalessegundonombrefiltercontainer_Internalname = "PROFESIONALESSEGUNDONOMBREFILTERCONTAINER";
         lblLblprofesionalesapellidoprimerofilter_Internalname = "LBLPROFESIONALESAPELLIDOPRIMEROFILTER";
         edtavCprofesionalesapellidoprimero_Internalname = "vCPROFESIONALESAPELLIDOPRIMERO";
         divProfesionalesapellidoprimerofiltercontainer_Internalname = "PROFESIONALESAPELLIDOPRIMEROFILTERCONTAINER";
         lblLblprofesionalesapellidosegundofilter_Internalname = "LBLPROFESIONALESAPELLIDOSEGUNDOFILTER";
         edtavCprofesionalesapellidosegundo_Internalname = "vCPROFESIONALESAPELLIDOSEGUNDO";
         divProfesionalesapellidosegundofiltercontainer_Internalname = "PROFESIONALESAPELLIDOSEGUNDOFILTERCONTAINER";
         lblLblprofesionalestelefonofilter_Internalname = "LBLPROFESIONALESTELEFONOFILTER";
         edtavCprofesionalestelefono_Internalname = "vCPROFESIONALESTELEFONO";
         divProfesionalestelefonofiltercontainer_Internalname = "PROFESIONALESTELEFONOFILTERCONTAINER";
         lblLblprofesionalesemailfilter_Internalname = "LBLPROFESIONALESEMAILFILTER";
         edtavCprofesionalesemail_Internalname = "vCPROFESIONALESEMAIL";
         divProfesionalesemailfiltercontainer_Internalname = "PROFESIONALESEMAILFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesPhoto_Internalname = "PROFESIONALESPHOTO";
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
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtProfesionalesPhoto_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtavCprofesionalesemail_Jsonclick = "";
         edtavCprofesionalesemail_Enabled = 1;
         edtavCprofesionalesemail_Visible = 1;
         edtavCprofesionalestelefono_Jsonclick = "";
         edtavCprofesionalestelefono_Enabled = 1;
         edtavCprofesionalestelefono_Visible = 1;
         edtavCprofesionalesapellidosegundo_Jsonclick = "";
         edtavCprofesionalesapellidosegundo_Enabled = 1;
         edtavCprofesionalesapellidosegundo_Visible = 1;
         edtavCprofesionalesapellidoprimero_Jsonclick = "";
         edtavCprofesionalesapellidoprimero_Enabled = 1;
         edtavCprofesionalesapellidoprimero_Visible = 1;
         edtavCprofesionalessegundonombre_Jsonclick = "";
         edtavCprofesionalessegundonombre_Enabled = 1;
         edtavCprofesionalessegundonombre_Visible = 1;
         edtavCprofesionalesprimernombre_Jsonclick = "";
         edtavCprofesionalesprimernombre_Enabled = 1;
         edtavCprofesionalesprimernombre_Visible = 1;
         edtavCprofesionalesid_Jsonclick = "";
         edtavCprofesionalesid_Enabled = 1;
         edtavCprofesionalesid_Visible = 1;
         divProfesionalesemailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalestelefonofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalesapellidosegundofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalesapellidoprimerofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalessegundonombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalesprimernombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Profesionales", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV7cProfesionalesPrimerNombre',fld:'vCPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV8cProfesionalesSegundoNombre',fld:'vCPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV9cProfesionalesApellidoPrimero',fld:'vCPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV10cProfesionalesApellidoSegundo',fld:'vCPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV11cProfesionalesTelefono',fld:'vCPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV12cProfesionalesEmail',fld:'vCPROFESIONALESEMAIL',pic:'',type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E189L1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPROFESIONALESIDFILTER.CLICK","{handler:'E119L1',iparms:[{av:'divProfesionalesidfiltercontainer_Class',ctrl:'PROFESIONALESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESIDFILTER.CLICK",",oparms:[{av:'divProfesionalesidfiltercontainer_Class',ctrl:'PROFESIONALESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesid_Visible',ctrl:'vCPROFESIONALESID',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESPRIMERNOMBREFILTER.CLICK","{handler:'E129L1',iparms:[{av:'divProfesionalesprimernombrefiltercontainer_Class',ctrl:'PROFESIONALESPRIMERNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESPRIMERNOMBREFILTER.CLICK",",oparms:[{av:'divProfesionalesprimernombrefiltercontainer_Class',ctrl:'PROFESIONALESPRIMERNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesprimernombre_Visible',ctrl:'vCPROFESIONALESPRIMERNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESSEGUNDONOMBREFILTER.CLICK","{handler:'E139L1',iparms:[{av:'divProfesionalessegundonombrefiltercontainer_Class',ctrl:'PROFESIONALESSEGUNDONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESSEGUNDONOMBREFILTER.CLICK",",oparms:[{av:'divProfesionalessegundonombrefiltercontainer_Class',ctrl:'PROFESIONALESSEGUNDONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalessegundonombre_Visible',ctrl:'vCPROFESIONALESSEGUNDONOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESAPELLIDOPRIMEROFILTER.CLICK","{handler:'E149L1',iparms:[{av:'divProfesionalesapellidoprimerofiltercontainer_Class',ctrl:'PROFESIONALESAPELLIDOPRIMEROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESAPELLIDOPRIMEROFILTER.CLICK",",oparms:[{av:'divProfesionalesapellidoprimerofiltercontainer_Class',ctrl:'PROFESIONALESAPELLIDOPRIMEROFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesapellidoprimero_Visible',ctrl:'vCPROFESIONALESAPELLIDOPRIMERO',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESAPELLIDOSEGUNDOFILTER.CLICK","{handler:'E159L1',iparms:[{av:'divProfesionalesapellidosegundofiltercontainer_Class',ctrl:'PROFESIONALESAPELLIDOSEGUNDOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESAPELLIDOSEGUNDOFILTER.CLICK",",oparms:[{av:'divProfesionalesapellidosegundofiltercontainer_Class',ctrl:'PROFESIONALESAPELLIDOSEGUNDOFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesapellidosegundo_Visible',ctrl:'vCPROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESTELEFONOFILTER.CLICK","{handler:'E169L1',iparms:[{av:'divProfesionalestelefonofiltercontainer_Class',ctrl:'PROFESIONALESTELEFONOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESTELEFONOFILTER.CLICK",",oparms:[{av:'divProfesionalestelefonofiltercontainer_Class',ctrl:'PROFESIONALESTELEFONOFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalestelefono_Visible',ctrl:'vCPROFESIONALESTELEFONO',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESEMAILFILTER.CLICK","{handler:'E179L1',iparms:[{av:'divProfesionalesemailfiltercontainer_Class',ctrl:'PROFESIONALESEMAILFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESEMAILFILTER.CLICK",",oparms:[{av:'divProfesionalesemailfiltercontainer_Class',ctrl:'PROFESIONALESEMAILFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesemail_Visible',ctrl:'vCPROFESIONALESEMAIL',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E219L2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pProfesionalesId',fld:'vPPROFESIONALESID',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV7cProfesionalesPrimerNombre',fld:'vCPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV8cProfesionalesSegundoNombre',fld:'vCPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV9cProfesionalesApellidoPrimero',fld:'vCPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV10cProfesionalesApellidoSegundo',fld:'vCPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV11cProfesionalesTelefono',fld:'vCPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV12cProfesionalesEmail',fld:'vCPROFESIONALESEMAIL',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV7cProfesionalesPrimerNombre',fld:'vCPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV8cProfesionalesSegundoNombre',fld:'vCPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV9cProfesionalesApellidoPrimero',fld:'vCPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV10cProfesionalesApellidoSegundo',fld:'vCPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV11cProfesionalesTelefono',fld:'vCPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV12cProfesionalesEmail',fld:'vCPROFESIONALESEMAIL',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV7cProfesionalesPrimerNombre',fld:'vCPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV8cProfesionalesSegundoNombre',fld:'vCPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV9cProfesionalesApellidoPrimero',fld:'vCPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV10cProfesionalesApellidoSegundo',fld:'vCPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV11cProfesionalesTelefono',fld:'vCPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV12cProfesionalesEmail',fld:'vCPROFESIONALESEMAIL',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV7cProfesionalesPrimerNombre',fld:'vCPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV8cProfesionalesSegundoNombre',fld:'vCPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV9cProfesionalesApellidoPrimero',fld:'vCPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV10cProfesionalesApellidoSegundo',fld:'vCPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV11cProfesionalesTelefono',fld:'vCPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV12cProfesionalesEmail',fld:'vCPROFESIONALESEMAIL',pic:'',type:'svchar'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPROFESIONALESEMAIL","{handler:'Validv_Cprofesionalesemail',iparms:[]");
         setEventMetadata("VALIDV_CPROFESIONALESEMAIL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Profesionalesphoto',iparms:[]");
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
         AV13pProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cProfesionalesId = "";
         AV7cProfesionalesPrimerNombre = "";
         AV8cProfesionalesSegundoNombre = "";
         AV9cProfesionalesApellidoPrimero = "";
         AV10cProfesionalesApellidoSegundo = "";
         AV11cProfesionalesTelefono = "";
         AV12cProfesionalesEmail = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblprofesionalesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblprofesionalesprimernombrefilter_Jsonclick = "";
         lblLblprofesionalessegundonombrefilter_Jsonclick = "";
         lblLblprofesionalesapellidoprimerofilter_Jsonclick = "";
         lblLblprofesionalesapellidosegundofilter_Jsonclick = "";
         lblLblprofesionalestelefonofilter_Jsonclick = "";
         lblLblprofesionalesemailfilter_Jsonclick = "";
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
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         lV6cProfesionalesId = "";
         lV7cProfesionalesPrimerNombre = "";
         lV8cProfesionalesSegundoNombre = "";
         lV9cProfesionalesApellidoPrimero = "";
         lV10cProfesionalesApellidoSegundo = "";
         lV11cProfesionalesTelefono = "";
         lV12cProfesionalesEmail = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         H009L2_A193ProfesionalesEmail = new string[] {""} ;
         H009L2_n193ProfesionalesEmail = new bool[] {false} ;
         H009L2_A170ProfesionalesTelefono = new string[] {""} ;
         H009L2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H009L2_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H009L2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H009L2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H009L2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H009L2_A120ProfesionalesId = new string[] {""} ;
         H009L2_A169ProfesionalesPhoto = new string[] {""} ;
         H009L3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00y0__default(),
            new Object[][] {
                new Object[] {
               H009L2_A193ProfesionalesEmail, H009L2_n193ProfesionalesEmail, H009L2_A170ProfesionalesTelefono, H009L2_A192ProfesionalesApellidoSegundo, H009L2_A40000ProfesionalesPhoto_GXI, H009L2_A167ProfesionalesApellidoPrimero, H009L2_A191ProfesionalesSegundoNombre, H009L2_A166ProfesionalesPrimerNombre, H009L2_A120ProfesionalesId, H009L2_A169ProfesionalesPhoto
               }
               , new Object[] {
               H009L3_AGRID1_nRecordCount
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
      private int edtavCprofesionalesid_Visible ;
      private int edtavCprofesionalesid_Enabled ;
      private int edtavCprofesionalesprimernombre_Visible ;
      private int edtavCprofesionalesprimernombre_Enabled ;
      private int edtavCprofesionalessegundonombre_Visible ;
      private int edtavCprofesionalessegundonombre_Enabled ;
      private int edtavCprofesionalesapellidoprimero_Visible ;
      private int edtavCprofesionalesapellidoprimero_Enabled ;
      private int edtavCprofesionalesapellidosegundo_Visible ;
      private int edtavCprofesionalesapellidosegundo_Enabled ;
      private int edtavCprofesionalestelefono_Visible ;
      private int edtavCprofesionalestelefono_Enabled ;
      private int edtavCprofesionalesemail_Visible ;
      private int edtavCprofesionalesemail_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesPhoto_Enabled ;
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
      private string AV13pProfesionalesId ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProfesionalesidfiltercontainer_Class ;
      private string divProfesionalesprimernombrefiltercontainer_Class ;
      private string divProfesionalessegundonombrefiltercontainer_Class ;
      private string divProfesionalesapellidoprimerofiltercontainer_Class ;
      private string divProfesionalesapellidosegundofiltercontainer_Class ;
      private string divProfesionalestelefonofiltercontainer_Class ;
      private string divProfesionalesemailfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV6cProfesionalesId ;
      private string AV7cProfesionalesPrimerNombre ;
      private string AV8cProfesionalesSegundoNombre ;
      private string AV9cProfesionalesApellidoPrimero ;
      private string AV10cProfesionalesApellidoSegundo ;
      private string AV11cProfesionalesTelefono ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProfesionalesidfiltercontainer_Internalname ;
      private string lblLblprofesionalesidfilter_Internalname ;
      private string lblLblprofesionalesidfilter_Jsonclick ;
      private string edtavCprofesionalesid_Internalname ;
      private string TempTags ;
      private string edtavCprofesionalesid_Jsonclick ;
      private string divProfesionalesprimernombrefiltercontainer_Internalname ;
      private string lblLblprofesionalesprimernombrefilter_Internalname ;
      private string lblLblprofesionalesprimernombrefilter_Jsonclick ;
      private string edtavCprofesionalesprimernombre_Internalname ;
      private string edtavCprofesionalesprimernombre_Jsonclick ;
      private string divProfesionalessegundonombrefiltercontainer_Internalname ;
      private string lblLblprofesionalessegundonombrefilter_Internalname ;
      private string lblLblprofesionalessegundonombrefilter_Jsonclick ;
      private string edtavCprofesionalessegundonombre_Internalname ;
      private string edtavCprofesionalessegundonombre_Jsonclick ;
      private string divProfesionalesapellidoprimerofiltercontainer_Internalname ;
      private string lblLblprofesionalesapellidoprimerofilter_Internalname ;
      private string lblLblprofesionalesapellidoprimerofilter_Jsonclick ;
      private string edtavCprofesionalesapellidoprimero_Internalname ;
      private string edtavCprofesionalesapellidoprimero_Jsonclick ;
      private string divProfesionalesapellidosegundofiltercontainer_Internalname ;
      private string lblLblprofesionalesapellidosegundofilter_Internalname ;
      private string lblLblprofesionalesapellidosegundofilter_Jsonclick ;
      private string edtavCprofesionalesapellidosegundo_Internalname ;
      private string edtavCprofesionalesapellidosegundo_Jsonclick ;
      private string divProfesionalestelefonofiltercontainer_Internalname ;
      private string lblLblprofesionalestelefonofilter_Internalname ;
      private string lblLblprofesionalestelefonofilter_Jsonclick ;
      private string edtavCprofesionalestelefono_Internalname ;
      private string edtavCprofesionalestelefono_Jsonclick ;
      private string divProfesionalesemailfiltercontainer_Internalname ;
      private string lblLblprofesionalesemailfilter_Internalname ;
      private string lblLblprofesionalesemailfilter_Jsonclick ;
      private string edtavCprofesionalesemail_Internalname ;
      private string edtavCprofesionalesemail_Jsonclick ;
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
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A191ProfesionalesSegundoNombre ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string edtProfesionalesPhoto_Internalname ;
      private string lV6cProfesionalesId ;
      private string lV7cProfesionalesPrimerNombre ;
      private string lV8cProfesionalesSegundoNombre ;
      private string lV9cProfesionalesApellidoPrimero ;
      private string lV10cProfesionalesApellidoSegundo ;
      private string lV11cProfesionalesTelefono ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtProfesionalesId_Link ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n193ProfesionalesEmail ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private string AV12cProfesionalesEmail ;
      private string AV15Linkselection_GXI ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string lV12cProfesionalesEmail ;
      private string A193ProfesionalesEmail ;
      private string AV5LinkSelection ;
      private string A169ProfesionalesPhoto ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H009L2_A193ProfesionalesEmail ;
      private bool[] H009L2_n193ProfesionalesEmail ;
      private string[] H009L2_A170ProfesionalesTelefono ;
      private string[] H009L2_A192ProfesionalesApellidoSegundo ;
      private string[] H009L2_A40000ProfesionalesPhoto_GXI ;
      private string[] H009L2_A167ProfesionalesApellidoPrimero ;
      private string[] H009L2_A191ProfesionalesSegundoNombre ;
      private string[] H009L2_A166ProfesionalesPrimerNombre ;
      private string[] H009L2_A120ProfesionalesId ;
      private string[] H009L2_A169ProfesionalesPhoto ;
      private long[] H009L3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pProfesionalesId ;
   }

   public class gx00y0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009L2( IGxContext context ,
                                             string AV7cProfesionalesPrimerNombre ,
                                             string AV8cProfesionalesSegundoNombre ,
                                             string AV9cProfesionalesApellidoPrimero ,
                                             string AV10cProfesionalesApellidoSegundo ,
                                             string AV11cProfesionalesTelefono ,
                                             string AV12cProfesionalesEmail ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string AV6cProfesionalesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId], [ProfesionalesPhoto]";
         sFromString = " FROM [Profesionales]";
         sOrderString = "";
         AddWhere(sWhereString, "([ProfesionalesId] like @lV6cProfesionalesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProfesionalesPrimerNombre)) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] like @lV7cProfesionalesPrimerNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProfesionalesSegundoNombre)) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] like @lV8cProfesionalesSegundoNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cProfesionalesApellidoPrimero)) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] like @lV9cProfesionalesApellidoPrimero)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cProfesionalesApellidoSegundo)) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] like @lV10cProfesionalesApellidoSegundo)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cProfesionalesTelefono)) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] like @lV11cProfesionalesTelefono)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cProfesionalesEmail)) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] like @lV12cProfesionalesEmail)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ProfesionalesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009L3( IGxContext context ,
                                             string AV7cProfesionalesPrimerNombre ,
                                             string AV8cProfesionalesSegundoNombre ,
                                             string AV9cProfesionalesApellidoPrimero ,
                                             string AV10cProfesionalesApellidoSegundo ,
                                             string AV11cProfesionalesTelefono ,
                                             string AV12cProfesionalesEmail ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string AV6cProfesionalesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Profesionales]";
         AddWhere(sWhereString, "([ProfesionalesId] like @lV6cProfesionalesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProfesionalesPrimerNombre)) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] like @lV7cProfesionalesPrimerNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProfesionalesSegundoNombre)) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] like @lV8cProfesionalesSegundoNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cProfesionalesApellidoPrimero)) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] like @lV9cProfesionalesApellidoPrimero)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cProfesionalesApellidoSegundo)) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] like @lV10cProfesionalesApellidoSegundo)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cProfesionalesTelefono)) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] like @lV11cProfesionalesTelefono)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cProfesionalesEmail)) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] like @lV12cProfesionalesEmail)");
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
                     return conditional_H009L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_H009L3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmH009L2;
          prmH009L2 = new Object[] {
          new ParDef("@lV6cProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@lV7cProfesionalesPrimerNombre",GXType.NChar,30,0) ,
          new ParDef("@lV8cProfesionalesSegundoNombre",GXType.NChar,30,0) ,
          new ParDef("@lV9cProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
          new ParDef("@lV10cProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
          new ParDef("@lV11cProfesionalesTelefono",GXType.NChar,20,0) ,
          new ParDef("@lV12cProfesionalesEmail",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009L3;
          prmH009L3 = new Object[] {
          new ParDef("@lV6cProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@lV7cProfesionalesPrimerNombre",GXType.NChar,30,0) ,
          new ParDef("@lV8cProfesionalesSegundoNombre",GXType.NChar,30,0) ,
          new ParDef("@lV9cProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
          new ParDef("@lV10cProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
          new ParDef("@lV11cProfesionalesTelefono",GXType.NChar,20,0) ,
          new ParDef("@lV12cProfesionalesEmail",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009L2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009L3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((string[]) buf[3])[0] = rslt.getString(3, 30);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

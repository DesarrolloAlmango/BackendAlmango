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
   public class gx00l0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00l0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00l0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pDepartamentoId )
      {
         this.AV10pDepartamentoId = 0 ;
         ExecutePrivate();
         aP0_pDepartamentoId=this.AV10pDepartamentoId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCdepartamentoestado = new GXCombobox();
         cmbavCdepartamentointegracionecommerce = new GXCombobox();
         cmbDepartamentoEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pDepartamentoId");
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
               gxfirstwebparm = GetFirstPar( "pDepartamentoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pDepartamentoId");
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
               AV10pDepartamentoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10pDepartamentoId", StringUtil.LTrimStr( (decimal)(AV10pDepartamentoId), 18, 0));
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
         AV6cDepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV7cPaisID = GetPar( "cPaisID");
         AV8cDepartamentoDepartamento = GetPar( "cDepartamentoDepartamento");
         AV9cDepartamentoAutEnuMuni = (short)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoAutEnuMuni"), "."), 18, MidpointRounding.ToEven));
         cmbavCdepartamentoestado.FromJSonString( GetNextPar( ));
         AV12cDepartamentoEstado = GetPar( "cDepartamentoEstado");
         cmbavCdepartamentointegracionecommerce.FromJSonString( GetNextPar( ));
         AV13cDepartamentoIntegracionEcommerce = GetPar( "cDepartamentoIntegracionEcommerce");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cPaisID, AV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, AV12cDepartamentoEstado, AV13cDepartamentoIntegracionEcommerce) ;
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
         PA9F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9F2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00l0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pDepartamentoId,18,0))}, new string[] {"pDepartamentoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAISID", StringUtil.RTrim( AV7cPaisID));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTODEPARTAMENTO", StringUtil.RTrim( AV8cDepartamentoDepartamento));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOAUTENUMUNI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cDepartamentoAutEnuMuni), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOESTADO", StringUtil.RTrim( AV12cDepartamentoEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOINTEGRACIONECOMMERCE", StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAISIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaisidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTODEPARTAMENTOFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentodepartamentofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOAUTENUMUNIFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoautenumunifiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOINTEGRACIONECOMMERCEFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentointegracionecommercefiltercontainer_Class));
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
            WE9F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9F2( ) ;
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
         return formatLink("gx00l0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pDepartamentoId,18,0))}, new string[] {"pDepartamentoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00L0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Departamento", "") ;
      }

      protected void WB9F0( )
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
            GxWebStd.gx_div_start( context, divDepartamentoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoidfilter_Internalname, context.GetMessage( "Departamento", ""), "", "", lblLbldepartamentoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentoid_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoid_Visible, edtavCdepartamentoid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00L0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblpaisidfilter_Internalname, context.GetMessage( "PaisId", ""), "", "", lblLblpaisidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaisid_Internalname, StringUtil.RTrim( AV7cPaisID), StringUtil.RTrim( context.localUtil.Format( AV7cPaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaisid_Visible, edtavCpaisid_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00L0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentodepartamentofiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentodepartamentofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentodepartamentofilter_Internalname, context.GetMessage( "Departamento", ""), "", "", lblLbldepartamentodepartamentofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentodepartamento_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentodepartamento_Internalname, StringUtil.RTrim( AV8cDepartamentoDepartamento), StringUtil.RTrim( context.localUtil.Format( AV8cDepartamentoDepartamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentodepartamento_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentodepartamento_Visible, edtavCdepartamentodepartamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00L0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentoautenumunifiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentoautenumunifiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoautenumunifilter_Internalname, context.GetMessage( "Departamento Aut Enu Muni", ""), "", "", lblLbldepartamentoautenumunifilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentoautenumuni_Internalname, context.GetMessage( "Departamento Aut Enu Muni", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoautenumuni_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cDepartamentoAutEnuMuni), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentoautenumuni_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cDepartamentoAutEnuMuni), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cDepartamentoAutEnuMuni), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoautenumuni_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoautenumuni_Visible, edtavCdepartamentoautenumuni_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00L0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentoestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentoestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoestadofilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLbldepartamentoestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCdepartamentoestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCdepartamentoestado, cmbavCdepartamentoestado_Internalname, StringUtil.RTrim( AV12cDepartamentoEstado), 1, cmbavCdepartamentoestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCdepartamentoestado.Visible, cmbavCdepartamentoestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Gx00L0.htm");
            cmbavCdepartamentoestado.CurrentValue = StringUtil.RTrim( AV12cDepartamentoEstado);
            AssignProp("", false, cmbavCdepartamentoestado_Internalname, "Values", (string)(cmbavCdepartamentoestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divDepartamentointegracionecommercefiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentointegracionecommercefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentointegracionecommercefilter_Internalname, context.GetMessage( "Departamento Integracion Ecommerce", ""), "", "", lblLbldepartamentointegracionecommercefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCdepartamentointegracionecommerce_Internalname, context.GetMessage( "Departamento Integracion Ecommerce", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCdepartamentointegracionecommerce, cmbavCdepartamentointegracionecommerce_Internalname, StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce), 1, cmbavCdepartamentointegracionecommerce_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCdepartamentointegracionecommerce.Visible, cmbavCdepartamentointegracionecommerce.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_Gx00L0.htm");
            cmbavCdepartamentointegracionecommerce.CurrentValue = StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce);
            AssignProp("", false, cmbavCdepartamentointegracionecommerce_Internalname, "Values", (string)(cmbavCdepartamentointegracionecommerce.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e179f1_client"+"'", TempTags, "", 2, "HLP_Gx00L0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00L0.htm");
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

      protected void START9F2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Departamento", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9F0( ) ;
      }

      protected void WS9F2( )
      {
         START9F2( ) ;
         EVT9F2( ) ;
      }

      protected void EVT9F2( )
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
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A116PaisID = cgiGet( edtPaisID_Internalname);
                              A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
                              cmbDepartamentoEstado.Name = cmbDepartamentoEstado_Internalname;
                              cmbDepartamentoEstado.CurrentValue = cgiGet( cmbDepartamentoEstado_Internalname);
                              A907DepartamentoEstado = cgiGet( cmbDepartamentoEstado_Internalname);
                              n907DepartamentoEstado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E189F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E199F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cdepartamentoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cDepartamentoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaisid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPAISID"), AV7cPaisID) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentodepartamento Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTODEPARTAMENTO"), AV8cDepartamentoDepartamento) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentoautenumuni Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOAUTENUMUNI"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cDepartamentoAutEnuMuni )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentoestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOESTADO"), AV12cDepartamentoEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentointegracionecommerce Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOINTEGRACIONECOMMERCE"), AV13cDepartamentoIntegracionEcommerce) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E209F2 ();
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

      protected void WE9F2( )
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

      protected void PA9F2( )
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
                                        long AV6cDepartamentoId ,
                                        string AV7cPaisID ,
                                        string AV8cDepartamentoDepartamento ,
                                        short AV9cDepartamentoAutEnuMuni ,
                                        string AV12cDepartamentoEstado ,
                                        string AV13cDepartamentoIntegracionEcommerce )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DEPARTAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", "")));
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
         if ( cmbavCdepartamentoestado.ItemCount > 0 )
         {
            AV12cDepartamentoEstado = cmbavCdepartamentoestado.getValidValue(AV12cDepartamentoEstado);
            AssignAttri("", false, "AV12cDepartamentoEstado", AV12cDepartamentoEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCdepartamentoestado.CurrentValue = StringUtil.RTrim( AV12cDepartamentoEstado);
            AssignProp("", false, cmbavCdepartamentoestado_Internalname, "Values", cmbavCdepartamentoestado.ToJavascriptSource(), true);
         }
         if ( cmbavCdepartamentointegracionecommerce.ItemCount > 0 )
         {
            AV13cDepartamentoIntegracionEcommerce = cmbavCdepartamentointegracionecommerce.getValidValue(AV13cDepartamentoIntegracionEcommerce);
            AssignAttri("", false, "AV13cDepartamentoIntegracionEcommerce", AV13cDepartamentoIntegracionEcommerce);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCdepartamentointegracionecommerce.CurrentValue = StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce);
            AssignProp("", false, cmbavCdepartamentointegracionecommerce_Internalname, "Values", cmbavCdepartamentointegracionecommerce.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9F2( )
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
                                                 AV7cPaisID ,
                                                 AV8cDepartamentoDepartamento ,
                                                 AV9cDepartamentoAutEnuMuni ,
                                                 AV12cDepartamentoEstado ,
                                                 AV13cDepartamentoIntegracionEcommerce ,
                                                 A116PaisID ,
                                                 A113DepartamentoDepartamento ,
                                                 A185DepartamentoAutEnuMuni ,
                                                 A907DepartamentoEstado ,
                                                 A966DepartamentoIntegracionEcommer ,
                                                 AV6cDepartamentoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            lV7cPaisID = StringUtil.PadR( StringUtil.RTrim( AV7cPaisID), 2, "%");
            lV8cDepartamentoDepartamento = StringUtil.PadR( StringUtil.RTrim( AV8cDepartamentoDepartamento), 80, "%");
            lV12cDepartamentoEstado = StringUtil.PadR( StringUtil.RTrim( AV12cDepartamentoEstado), 3, "%");
            lV13cDepartamentoIntegracionEcommerce = StringUtil.PadR( StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce), 1, "%");
            /* Using cursor H009F2 */
            pr_default.execute(0, new Object[] {AV6cDepartamentoId, lV7cPaisID, lV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, lV12cDepartamentoEstado, lV13cDepartamentoIntegracionEcommerce, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A966DepartamentoIntegracionEcommer = H009F2_A966DepartamentoIntegracionEcommer[0];
               n966DepartamentoIntegracionEcommer = H009F2_n966DepartamentoIntegracionEcommer[0];
               A185DepartamentoAutEnuMuni = H009F2_A185DepartamentoAutEnuMuni[0];
               A907DepartamentoEstado = H009F2_A907DepartamentoEstado[0];
               n907DepartamentoEstado = H009F2_n907DepartamentoEstado[0];
               A113DepartamentoDepartamento = H009F2_A113DepartamentoDepartamento[0];
               A116PaisID = H009F2_A116PaisID[0];
               A112DepartamentoId = H009F2_A112DepartamentoId[0];
               /* Execute user event: Load */
               E199F2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB9F0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9F2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DEPARTAMENTOID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cPaisID ,
                                              AV8cDepartamentoDepartamento ,
                                              AV9cDepartamentoAutEnuMuni ,
                                              AV12cDepartamentoEstado ,
                                              AV13cDepartamentoIntegracionEcommerce ,
                                              A116PaisID ,
                                              A113DepartamentoDepartamento ,
                                              A185DepartamentoAutEnuMuni ,
                                              A907DepartamentoEstado ,
                                              A966DepartamentoIntegracionEcommer ,
                                              AV6cDepartamentoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV7cPaisID = StringUtil.PadR( StringUtil.RTrim( AV7cPaisID), 2, "%");
         lV8cDepartamentoDepartamento = StringUtil.PadR( StringUtil.RTrim( AV8cDepartamentoDepartamento), 80, "%");
         lV12cDepartamentoEstado = StringUtil.PadR( StringUtil.RTrim( AV12cDepartamentoEstado), 3, "%");
         lV13cDepartamentoIntegracionEcommerce = StringUtil.PadR( StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce), 1, "%");
         /* Using cursor H009F3 */
         pr_default.execute(1, new Object[] {AV6cDepartamentoId, lV7cPaisID, lV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, lV12cDepartamentoEstado, lV13cDepartamentoIntegracionEcommerce});
         GRID1_nRecordCount = H009F3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cPaisID, AV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, AV12cDepartamentoEstado, AV13cDepartamentoIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cPaisID, AV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, AV12cDepartamentoEstado, AV13cDepartamentoIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cPaisID, AV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, AV12cDepartamentoEstado, AV13cDepartamentoIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cPaisID, AV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, AV12cDepartamentoEstado, AV13cDepartamentoIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cPaisID, AV8cDepartamentoDepartamento, AV9cDepartamentoAutEnuMuni, AV12cDepartamentoEstado, AV13cDepartamentoIntegracionEcommerce) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtDepartamentoId_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtDepartamentoDepartamento_Enabled = 0;
         cmbDepartamentoEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E189F2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOID");
               GX_FocusControl = edtavCdepartamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cDepartamentoId = 0;
               AssignAttri("", false, "AV6cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV6cDepartamentoId), 18, 0));
            }
            else
            {
               AV6cDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV6cDepartamentoId), 18, 0));
            }
            AV7cPaisID = cgiGet( edtavCpaisid_Internalname);
            AssignAttri("", false, "AV7cPaisID", AV7cPaisID);
            AV8cDepartamentoDepartamento = cgiGet( edtavCdepartamentodepartamento_Internalname);
            AssignAttri("", false, "AV8cDepartamentoDepartamento", AV8cDepartamentoDepartamento);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoautenumuni_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoautenumuni_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOAUTENUMUNI");
               GX_FocusControl = edtavCdepartamentoautenumuni_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cDepartamentoAutEnuMuni = 0;
               AssignAttri("", false, "AV9cDepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(AV9cDepartamentoAutEnuMuni), 4, 0));
            }
            else
            {
               AV9cDepartamentoAutEnuMuni = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentoautenumuni_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cDepartamentoAutEnuMuni", StringUtil.LTrimStr( (decimal)(AV9cDepartamentoAutEnuMuni), 4, 0));
            }
            cmbavCdepartamentoestado.Name = cmbavCdepartamentoestado_Internalname;
            cmbavCdepartamentoestado.CurrentValue = cgiGet( cmbavCdepartamentoestado_Internalname);
            AV12cDepartamentoEstado = cgiGet( cmbavCdepartamentoestado_Internalname);
            AssignAttri("", false, "AV12cDepartamentoEstado", AV12cDepartamentoEstado);
            cmbavCdepartamentointegracionecommerce.Name = cmbavCdepartamentointegracionecommerce_Internalname;
            cmbavCdepartamentointegracionecommerce.CurrentValue = cgiGet( cmbavCdepartamentointegracionecommerce_Internalname);
            AV13cDepartamentoIntegracionEcommerce = cgiGet( cmbavCdepartamentointegracionecommerce_Internalname);
            AssignAttri("", false, "AV13cDepartamentoIntegracionEcommerce", AV13cDepartamentoIntegracionEcommerce);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cDepartamentoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPAISID"), AV7cPaisID) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTODEPARTAMENTO"), AV8cDepartamentoDepartamento) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOAUTENUMUNI"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cDepartamentoAutEnuMuni )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOESTADO"), AV12cDepartamentoEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOINTEGRACIONECOMMERCE"), AV13cDepartamentoIntegracionEcommerce) != 0 )
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
         E189F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E189F2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV11ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E199F2( )
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
         E209F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E209F2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10pDepartamentoId = A112DepartamentoId;
         AssignAttri("", false, "AV10pDepartamentoId", StringUtil.LTrimStr( (decimal)(AV10pDepartamentoId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV10pDepartamentoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV10pDepartamentoId"});
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
         AV10pDepartamentoId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV10pDepartamentoId", StringUtil.LTrimStr( (decimal)(AV10pDepartamentoId), 18, 0));
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
         PA9F2( ) ;
         WS9F2( ) ;
         WE9F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021255833", true, true, false);
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
         context.AddJavascriptSource("gx00l0.js", "?202673021255833", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_74_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_74_idx;
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO_"+sGXsfl_74_idx;
         cmbDepartamentoEstado_Internalname = "DEPARTAMENTOESTADO_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_74_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_74_fel_idx;
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO_"+sGXsfl_74_fel_idx;
         cmbDepartamentoEstado_Internalname = "DEPARTAMENTOESTADO_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB9F0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtDepartamentoDepartamento_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtDepartamentoDepartamento_Internalname, "Link", edtDepartamentoDepartamento_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoDepartamento_Internalname,StringUtil.RTrim( A113DepartamentoDepartamento),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDepartamentoDepartamento_Link,(string)"",(string)"",(string)"",(string)edtDepartamentoDepartamento_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbDepartamentoEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "DEPARTAMENTOESTADO_" + sGXsfl_74_idx;
               cmbDepartamentoEstado.Name = GXCCtl;
               cmbDepartamentoEstado.WebTags = "";
               cmbDepartamentoEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbDepartamentoEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               if ( cmbDepartamentoEstado.ItemCount > 0 )
               {
                  A907DepartamentoEstado = cmbDepartamentoEstado.getValidValue(A907DepartamentoEstado);
                  n907DepartamentoEstado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbDepartamentoEstado,(string)cmbDepartamentoEstado_Internalname,StringUtil.RTrim( A907DepartamentoEstado),(short)1,(string)cmbDepartamentoEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbDepartamentoEstado.CurrentValue = StringUtil.RTrim( A907DepartamentoEstado);
            AssignProp("", false, cmbDepartamentoEstado_Internalname, "Values", (string)(cmbDepartamentoEstado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            send_integrity_lvl_hashes9F2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCdepartamentoestado.Name = "vCDEPARTAMENTOESTADO";
         cmbavCdepartamentoestado.WebTags = "";
         cmbavCdepartamentoestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCdepartamentoestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbavCdepartamentoestado.ItemCount > 0 )
         {
            AV12cDepartamentoEstado = cmbavCdepartamentoestado.getValidValue(AV12cDepartamentoEstado);
            AssignAttri("", false, "AV12cDepartamentoEstado", AV12cDepartamentoEstado);
         }
         cmbavCdepartamentointegracionecommerce.Name = "vCDEPARTAMENTOINTEGRACIONECOMMERCE";
         cmbavCdepartamentointegracionecommerce.WebTags = "";
         cmbavCdepartamentointegracionecommerce.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavCdepartamentointegracionecommerce.addItem("T", context.GetMessage( "TOTAL", ""), 0);
         cmbavCdepartamentointegracionecommerce.addItem("P", context.GetMessage( "PARCIAL", ""), 0);
         cmbavCdepartamentointegracionecommerce.addItem("D", context.GetMessage( "DESHABILITADO", ""), 0);
         if ( cmbavCdepartamentointegracionecommerce.ItemCount > 0 )
         {
            AV13cDepartamentoIntegracionEcommerce = cmbavCdepartamentointegracionecommerce.getValidValue(AV13cDepartamentoIntegracionEcommerce);
            AssignAttri("", false, "AV13cDepartamentoIntegracionEcommerce", AV13cDepartamentoIntegracionEcommerce);
         }
         GXCCtl = "DEPARTAMENTOESTADO_" + sGXsfl_74_idx;
         cmbDepartamentoEstado.Name = GXCCtl;
         cmbDepartamentoEstado.WebTags = "";
         cmbDepartamentoEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbDepartamentoEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbDepartamentoEstado.ItemCount > 0 )
         {
            A907DepartamentoEstado = cmbDepartamentoEstado.getValidValue(A907DepartamentoEstado);
            n907DepartamentoEstado = false;
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
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "PaisId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A113DepartamentoDepartamento)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtDepartamentoDepartamento_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A907DepartamentoEstado)));
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
         lblLbldepartamentoidfilter_Internalname = "LBLDEPARTAMENTOIDFILTER";
         edtavCdepartamentoid_Internalname = "vCDEPARTAMENTOID";
         divDepartamentoidfiltercontainer_Internalname = "DEPARTAMENTOIDFILTERCONTAINER";
         lblLblpaisidfilter_Internalname = "LBLPAISIDFILTER";
         edtavCpaisid_Internalname = "vCPAISID";
         divPaisidfiltercontainer_Internalname = "PAISIDFILTERCONTAINER";
         lblLbldepartamentodepartamentofilter_Internalname = "LBLDEPARTAMENTODEPARTAMENTOFILTER";
         edtavCdepartamentodepartamento_Internalname = "vCDEPARTAMENTODEPARTAMENTO";
         divDepartamentodepartamentofiltercontainer_Internalname = "DEPARTAMENTODEPARTAMENTOFILTERCONTAINER";
         lblLbldepartamentoautenumunifilter_Internalname = "LBLDEPARTAMENTOAUTENUMUNIFILTER";
         edtavCdepartamentoautenumuni_Internalname = "vCDEPARTAMENTOAUTENUMUNI";
         divDepartamentoautenumunifiltercontainer_Internalname = "DEPARTAMENTOAUTENUMUNIFILTERCONTAINER";
         lblLbldepartamentoestadofilter_Internalname = "LBLDEPARTAMENTOESTADOFILTER";
         cmbavCdepartamentoestado_Internalname = "vCDEPARTAMENTOESTADO";
         divDepartamentoestadofiltercontainer_Internalname = "DEPARTAMENTOESTADOFILTERCONTAINER";
         lblLbldepartamentointegracionecommercefilter_Internalname = "LBLDEPARTAMENTOINTEGRACIONECOMMERCEFILTER";
         cmbavCdepartamentointegracionecommerce_Internalname = "vCDEPARTAMENTOINTEGRACIONECOMMERCE";
         divDepartamentointegracionecommercefiltercontainer_Internalname = "DEPARTAMENTOINTEGRACIONECOMMERCEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtPaisID_Internalname = "PAISID";
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO";
         cmbDepartamentoEstado_Internalname = "DEPARTAMENTOESTADO";
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
         cmbDepartamentoEstado_Jsonclick = "";
         edtDepartamentoDepartamento_Jsonclick = "";
         edtDepartamentoDepartamento_Link = "";
         edtPaisID_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         cmbDepartamentoEstado.Enabled = 0;
         edtDepartamentoDepartamento_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         cmbavCdepartamentointegracionecommerce_Jsonclick = "";
         cmbavCdepartamentointegracionecommerce.Visible = 1;
         cmbavCdepartamentointegracionecommerce.Enabled = 1;
         cmbavCdepartamentoestado_Jsonclick = "";
         cmbavCdepartamentoestado.Visible = 1;
         cmbavCdepartamentoestado.Enabled = 1;
         edtavCdepartamentoautenumuni_Jsonclick = "";
         edtavCdepartamentoautenumuni_Enabled = 1;
         edtavCdepartamentoautenumuni_Visible = 1;
         edtavCdepartamentodepartamento_Jsonclick = "";
         edtavCdepartamentodepartamento_Enabled = 1;
         edtavCdepartamentodepartamento_Visible = 1;
         edtavCpaisid_Jsonclick = "";
         edtavCpaisid_Enabled = 1;
         edtavCpaisid_Visible = 1;
         edtavCdepartamentoid_Jsonclick = "";
         edtavCdepartamentoid_Enabled = 1;
         edtavCdepartamentoid_Visible = 1;
         divDepartamentointegracionecommercefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoautenumunifiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentodepartamentofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPaisidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Departamento", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV8cDepartamentoDepartamento',fld:'vCDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV9cDepartamentoAutEnuMuni',fld:'vCDEPARTAMENTOAUTENUMUNI',pic:'ZZZ9',type:'int'},{av:'cmbavCdepartamentoestado'},{av:'AV12cDepartamentoEstado',fld:'vCDEPARTAMENTOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentointegracionecommerce'},{av:'AV13cDepartamentoIntegracionEcommerce',fld:'vCDEPARTAMENTOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E179F1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK","{handler:'E119F1',iparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK",",oparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoid_Visible',ctrl:'vCDEPARTAMENTOID',prop:'Visible'}]}");
         setEventMetadata("LBLPAISIDFILTER.CLICK","{handler:'E129F1',iparms:[{av:'divPaisidfiltercontainer_Class',ctrl:'PAISIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAISIDFILTER.CLICK",",oparms:[{av:'divPaisidfiltercontainer_Class',ctrl:'PAISIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaisid_Visible',ctrl:'vCPAISID',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTODEPARTAMENTOFILTER.CLICK","{handler:'E139F1',iparms:[{av:'divDepartamentodepartamentofiltercontainer_Class',ctrl:'DEPARTAMENTODEPARTAMENTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTODEPARTAMENTOFILTER.CLICK",",oparms:[{av:'divDepartamentodepartamentofiltercontainer_Class',ctrl:'DEPARTAMENTODEPARTAMENTOFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentodepartamento_Visible',ctrl:'vCDEPARTAMENTODEPARTAMENTO',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOAUTENUMUNIFILTER.CLICK","{handler:'E149F1',iparms:[{av:'divDepartamentoautenumunifiltercontainer_Class',ctrl:'DEPARTAMENTOAUTENUMUNIFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOAUTENUMUNIFILTER.CLICK",",oparms:[{av:'divDepartamentoautenumunifiltercontainer_Class',ctrl:'DEPARTAMENTOAUTENUMUNIFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoautenumuni_Visible',ctrl:'vCDEPARTAMENTOAUTENUMUNI',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOESTADOFILTER.CLICK","{handler:'E159F1',iparms:[{av:'divDepartamentoestadofiltercontainer_Class',ctrl:'DEPARTAMENTOESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOESTADOFILTER.CLICK",",oparms:[{av:'divDepartamentoestadofiltercontainer_Class',ctrl:'DEPARTAMENTOESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCdepartamentoestado'}]}");
         setEventMetadata("LBLDEPARTAMENTOINTEGRACIONECOMMERCEFILTER.CLICK","{handler:'E169F1',iparms:[{av:'divDepartamentointegracionecommercefiltercontainer_Class',ctrl:'DEPARTAMENTOINTEGRACIONECOMMERCEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOINTEGRACIONECOMMERCEFILTER.CLICK",",oparms:[{av:'divDepartamentointegracionecommercefiltercontainer_Class',ctrl:'DEPARTAMENTOINTEGRACIONECOMMERCEFILTERCONTAINER',prop:'Class'},{av:'cmbavCdepartamentointegracionecommerce'}]}");
         setEventMetadata("ENTER","{handler:'E209F2',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV10pDepartamentoId',fld:'vPDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV8cDepartamentoDepartamento',fld:'vCDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV9cDepartamentoAutEnuMuni',fld:'vCDEPARTAMENTOAUTENUMUNI',pic:'ZZZ9',type:'int'},{av:'cmbavCdepartamentoestado'},{av:'AV12cDepartamentoEstado',fld:'vCDEPARTAMENTOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentointegracionecommerce'},{av:'AV13cDepartamentoIntegracionEcommerce',fld:'vCDEPARTAMENTOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV8cDepartamentoDepartamento',fld:'vCDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV9cDepartamentoAutEnuMuni',fld:'vCDEPARTAMENTOAUTENUMUNI',pic:'ZZZ9',type:'int'},{av:'cmbavCdepartamentoestado'},{av:'AV12cDepartamentoEstado',fld:'vCDEPARTAMENTOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentointegracionecommerce'},{av:'AV13cDepartamentoIntegracionEcommerce',fld:'vCDEPARTAMENTOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV8cDepartamentoDepartamento',fld:'vCDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV9cDepartamentoAutEnuMuni',fld:'vCDEPARTAMENTOAUTENUMUNI',pic:'ZZZ9',type:'int'},{av:'cmbavCdepartamentoestado'},{av:'AV12cDepartamentoEstado',fld:'vCDEPARTAMENTOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentointegracionecommerce'},{av:'AV13cDepartamentoIntegracionEcommerce',fld:'vCDEPARTAMENTOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPaisID',fld:'vCPAISID',pic:'',type:'char'},{av:'AV8cDepartamentoDepartamento',fld:'vCDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV9cDepartamentoAutEnuMuni',fld:'vCDEPARTAMENTOAUTENUMUNI',pic:'ZZZ9',type:'int'},{av:'cmbavCdepartamentoestado'},{av:'AV12cDepartamentoEstado',fld:'vCDEPARTAMENTOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentointegracionecommerce'},{av:'AV13cDepartamentoIntegracionEcommerce',fld:'vCDEPARTAMENTOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CDEPARTAMENTOINTEGRACIONECOMMERCE","{handler:'Validv_Cdepartamentointegracionecommerce',iparms:[]");
         setEventMetadata("VALIDV_CDEPARTAMENTOINTEGRACIONECOMMERCE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Departamentoestado',iparms:[]");
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
         AV7cPaisID = "";
         AV8cDepartamentoDepartamento = "";
         AV12cDepartamentoEstado = "";
         AV13cDepartamentoIntegracionEcommerce = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbldepartamentoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpaisidfilter_Jsonclick = "";
         lblLbldepartamentodepartamentofilter_Jsonclick = "";
         lblLbldepartamentoautenumunifilter_Jsonclick = "";
         lblLbldepartamentoestadofilter_Jsonclick = "";
         lblLbldepartamentointegracionecommercefilter_Jsonclick = "";
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
         A116PaisID = "";
         A113DepartamentoDepartamento = "";
         A907DepartamentoEstado = "";
         lV7cPaisID = "";
         lV8cDepartamentoDepartamento = "";
         lV12cDepartamentoEstado = "";
         lV13cDepartamentoIntegracionEcommerce = "";
         A966DepartamentoIntegracionEcommer = "";
         H009F2_A966DepartamentoIntegracionEcommer = new string[] {""} ;
         H009F2_n966DepartamentoIntegracionEcommer = new bool[] {false} ;
         H009F2_A185DepartamentoAutEnuMuni = new short[1] ;
         H009F2_A907DepartamentoEstado = new string[] {""} ;
         H009F2_n907DepartamentoEstado = new bool[] {false} ;
         H009F2_A113DepartamentoDepartamento = new string[] {""} ;
         H009F2_A116PaisID = new string[] {""} ;
         H009F2_A112DepartamentoId = new long[1] ;
         H009F3_AGRID1_nRecordCount = new long[1] ;
         AV11ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00l0__default(),
            new Object[][] {
                new Object[] {
               H009F2_A966DepartamentoIntegracionEcommer, H009F2_n966DepartamentoIntegracionEcommer, H009F2_A185DepartamentoAutEnuMuni, H009F2_A907DepartamentoEstado, H009F2_n907DepartamentoEstado, H009F2_A113DepartamentoDepartamento, H009F2_A116PaisID, H009F2_A112DepartamentoId
               }
               , new Object[] {
               H009F3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV9cDepartamentoAutEnuMuni ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A185DepartamentoAutEnuMuni ;
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
      private int edtavCdepartamentoid_Enabled ;
      private int edtavCdepartamentoid_Visible ;
      private int edtavCpaisid_Visible ;
      private int edtavCpaisid_Enabled ;
      private int edtavCdepartamentodepartamento_Visible ;
      private int edtavCdepartamentodepartamento_Enabled ;
      private int edtavCdepartamentoautenumuni_Enabled ;
      private int edtavCdepartamentoautenumuni_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtDepartamentoId_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtDepartamentoDepartamento_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV10pDepartamentoId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cDepartamentoId ;
      private long A112DepartamentoId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divDepartamentoidfiltercontainer_Class ;
      private string divPaisidfiltercontainer_Class ;
      private string divDepartamentodepartamentofiltercontainer_Class ;
      private string divDepartamentoautenumunifiltercontainer_Class ;
      private string divDepartamentoestadofiltercontainer_Class ;
      private string divDepartamentointegracionecommercefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV7cPaisID ;
      private string AV8cDepartamentoDepartamento ;
      private string AV12cDepartamentoEstado ;
      private string AV13cDepartamentoIntegracionEcommerce ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divDepartamentoidfiltercontainer_Internalname ;
      private string lblLbldepartamentoidfilter_Internalname ;
      private string lblLbldepartamentoidfilter_Jsonclick ;
      private string edtavCdepartamentoid_Internalname ;
      private string TempTags ;
      private string edtavCdepartamentoid_Jsonclick ;
      private string divPaisidfiltercontainer_Internalname ;
      private string lblLblpaisidfilter_Internalname ;
      private string lblLblpaisidfilter_Jsonclick ;
      private string edtavCpaisid_Internalname ;
      private string edtavCpaisid_Jsonclick ;
      private string divDepartamentodepartamentofiltercontainer_Internalname ;
      private string lblLbldepartamentodepartamentofilter_Internalname ;
      private string lblLbldepartamentodepartamentofilter_Jsonclick ;
      private string edtavCdepartamentodepartamento_Internalname ;
      private string edtavCdepartamentodepartamento_Jsonclick ;
      private string divDepartamentoautenumunifiltercontainer_Internalname ;
      private string lblLbldepartamentoautenumunifilter_Internalname ;
      private string lblLbldepartamentoautenumunifilter_Jsonclick ;
      private string edtavCdepartamentoautenumuni_Internalname ;
      private string edtavCdepartamentoautenumuni_Jsonclick ;
      private string divDepartamentoestadofiltercontainer_Internalname ;
      private string lblLbldepartamentoestadofilter_Internalname ;
      private string lblLbldepartamentoestadofilter_Jsonclick ;
      private string cmbavCdepartamentoestado_Internalname ;
      private string cmbavCdepartamentoestado_Jsonclick ;
      private string divDepartamentointegracionecommercefiltercontainer_Internalname ;
      private string lblLbldepartamentointegracionecommercefilter_Internalname ;
      private string lblLbldepartamentointegracionecommercefilter_Jsonclick ;
      private string cmbavCdepartamentointegracionecommerce_Internalname ;
      private string cmbavCdepartamentointegracionecommerce_Jsonclick ;
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
      private string edtDepartamentoId_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string edtDepartamentoDepartamento_Internalname ;
      private string cmbDepartamentoEstado_Internalname ;
      private string A907DepartamentoEstado ;
      private string lV7cPaisID ;
      private string lV8cDepartamentoDepartamento ;
      private string lV12cDepartamentoEstado ;
      private string lV13cDepartamentoIntegracionEcommerce ;
      private string A966DepartamentoIntegracionEcommer ;
      private string AV11ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string edtDepartamentoDepartamento_Link ;
      private string edtDepartamentoDepartamento_Jsonclick ;
      private string GXCCtl ;
      private string cmbDepartamentoEstado_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n907DepartamentoEstado ;
      private bool gxdyncontrolsrefreshing ;
      private bool n966DepartamentoIntegracionEcommer ;
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
      private GXCombobox cmbavCdepartamentoestado ;
      private GXCombobox cmbavCdepartamentointegracionecommerce ;
      private GXCombobox cmbDepartamentoEstado ;
      private IDataStoreProvider pr_default ;
      private string[] H009F2_A966DepartamentoIntegracionEcommer ;
      private bool[] H009F2_n966DepartamentoIntegracionEcommer ;
      private short[] H009F2_A185DepartamentoAutEnuMuni ;
      private string[] H009F2_A907DepartamentoEstado ;
      private bool[] H009F2_n907DepartamentoEstado ;
      private string[] H009F2_A113DepartamentoDepartamento ;
      private string[] H009F2_A116PaisID ;
      private long[] H009F2_A112DepartamentoId ;
      private long[] H009F3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pDepartamentoId ;
   }

   public class gx00l0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009F2( IGxContext context ,
                                             string AV7cPaisID ,
                                             string AV8cDepartamentoDepartamento ,
                                             short AV9cDepartamentoAutEnuMuni ,
                                             string AV12cDepartamentoEstado ,
                                             string AV13cDepartamentoIntegracionEcommerce ,
                                             string A116PaisID ,
                                             string A113DepartamentoDepartamento ,
                                             short A185DepartamentoAutEnuMuni ,
                                             string A907DepartamentoEstado ,
                                             string A966DepartamentoIntegracionEcommer ,
                                             long AV6cDepartamentoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DepartamentoIntegracionEcommer], [DepartamentoAutEnuMuni], [DepartamentoEstado], [DepartamentoDepartamento], [PaisID], [DepartamentoId]";
         sFromString = " FROM [Departamento]";
         sOrderString = "";
         AddWhere(sWhereString, "([DepartamentoId] >= @AV6cDepartamentoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cPaisID)) )
         {
            AddWhere(sWhereString, "([PaisID] like @lV7cPaisID)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cDepartamentoDepartamento)) )
         {
            AddWhere(sWhereString, "([DepartamentoDepartamento] like @lV8cDepartamentoDepartamento)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cDepartamentoAutEnuMuni) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] >= @AV9cDepartamentoAutEnuMuni)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cDepartamentoEstado)) )
         {
            AddWhere(sWhereString, "([DepartamentoEstado] like @lV12cDepartamentoEstado)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce)) )
         {
            AddWhere(sWhereString, "([DepartamentoIntegracionEcommer] like @lV13cDepartamentoIntegracionEcommerce)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [DepartamentoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009F3( IGxContext context ,
                                             string AV7cPaisID ,
                                             string AV8cDepartamentoDepartamento ,
                                             short AV9cDepartamentoAutEnuMuni ,
                                             string AV12cDepartamentoEstado ,
                                             string AV13cDepartamentoIntegracionEcommerce ,
                                             string A116PaisID ,
                                             string A113DepartamentoDepartamento ,
                                             short A185DepartamentoAutEnuMuni ,
                                             string A907DepartamentoEstado ,
                                             string A966DepartamentoIntegracionEcommer ,
                                             long AV6cDepartamentoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Departamento]";
         AddWhere(sWhereString, "([DepartamentoId] >= @AV6cDepartamentoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cPaisID)) )
         {
            AddWhere(sWhereString, "([PaisID] like @lV7cPaisID)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cDepartamentoDepartamento)) )
         {
            AddWhere(sWhereString, "([DepartamentoDepartamento] like @lV8cDepartamentoDepartamento)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cDepartamentoAutEnuMuni) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] >= @AV9cDepartamentoAutEnuMuni)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cDepartamentoEstado)) )
         {
            AddWhere(sWhereString, "([DepartamentoEstado] like @lV12cDepartamentoEstado)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cDepartamentoIntegracionEcommerce)) )
         {
            AddWhere(sWhereString, "([DepartamentoIntegracionEcommer] like @lV13cDepartamentoIntegracionEcommerce)");
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
                     return conditional_H009F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] );
               case 1 :
                     return conditional_H009F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] );
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
          Object[] prmH009F2;
          prmH009F2 = new Object[] {
          new ParDef("@AV6cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cPaisID",GXType.NChar,2,0) ,
          new ParDef("@lV8cDepartamentoDepartamento",GXType.NChar,80,0) ,
          new ParDef("@AV9cDepartamentoAutEnuMuni",GXType.Int16,4,0) ,
          new ParDef("@lV12cDepartamentoEstado",GXType.NChar,3,0) ,
          new ParDef("@lV13cDepartamentoIntegracionEcommerce",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009F3;
          prmH009F3 = new Object[] {
          new ParDef("@AV6cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cPaisID",GXType.NChar,2,0) ,
          new ParDef("@lV8cDepartamentoDepartamento",GXType.NChar,80,0) ,
          new ParDef("@AV9cDepartamentoAutEnuMuni",GXType.Int16,4,0) ,
          new ParDef("@lV12cDepartamentoEstado",GXType.NChar,3,0) ,
          new ParDef("@lV13cDepartamentoIntegracionEcommerce",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009F2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009F3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 80);
                ((string[]) buf[6])[0] = rslt.getString(5, 2);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

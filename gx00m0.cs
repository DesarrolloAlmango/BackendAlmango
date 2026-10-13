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
   public class gx00m0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00m0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00m0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pDepartamentoId ,
                           out long aP1_pDepartamentoMunicipioId )
      {
         this.AV8pDepartamentoId = 0 ;
         this.AV9pDepartamentoMunicipioId = 0 ;
         ExecutePrivate();
         aP0_pDepartamentoId=this.AV8pDepartamentoId;
         aP1_pDepartamentoMunicipioId=this.AV9pDepartamentoMunicipioId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCdepartamentomunicipioestado = new GXCombobox();
         cmbavCdepartamentomunicipiointegracionecommerce = new GXCombobox();
         cmbDepartamentoMunicipioEstado = new GXCombobox();
         cmbDepartamentoMunicipioIntegraci = new GXCombobox();
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
               AV8pDepartamentoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8pDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8pDepartamentoId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9pDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "pDepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9pDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV9pDepartamentoMunicipioId), 18, 0));
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         AV7cDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
         AV11cDepartamentoMunicipioCosto = NumberUtil.Val( GetPar( "cDepartamentoMunicipioCosto"), ".");
         cmbavCdepartamentomunicipioestado.FromJSonString( GetNextPar( ));
         AV12cDepartamentoMunicipioEstado = GetPar( "cDepartamentoMunicipioEstado");
         cmbavCdepartamentomunicipiointegracionecommerce.FromJSonString( GetNextPar( ));
         AV13cDepartamentoMunicipioIntegracionEcommerce = GetPar( "cDepartamentoMunicipioIntegracionEcommerce");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, AV12cDepartamentoMunicipioEstado, AV13cDepartamentoMunicipioIntegracionEcommerce) ;
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
         PAH62( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTH62( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00m0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pDepartamentoId,18,0)),UrlEncode(StringUtil.LTrimStr(AV9pDepartamentoMunicipioId,18,0))}, new string[] {"pDepartamentoId","pDepartamentoMunicipioId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOMUNICIPIOCOSTO", StringUtil.LTrim( StringUtil.NToC( AV11cDepartamentoMunicipioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOMUNICIPIOESTADO", StringUtil.RTrim( AV12cDepartamentoMunicipioEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE", StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8pDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPDEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentomunicipioidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOCOSTOFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentomunicipiocostofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentomunicipioestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentomunicipiointegracionecommercefiltercontainer_Class));
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
            WEH62( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTH62( ) ;
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
         return formatLink("gx00m0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pDepartamentoId,18,0)),UrlEncode(StringUtil.LTrimStr(AV9pDepartamentoMunicipioId,18,0))}, new string[] {"pDepartamentoId","pDepartamentoMunicipioId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00M0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Municipio", "") ;
      }

      protected void WBH60( )
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
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoidfilter_Internalname, context.GetMessage( "Departamento", ""), "", "", lblLbldepartamentoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11h61_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoid_Visible, edtavCdepartamentoid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentomunicipioidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentomunicipioidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentomunicipioidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLbldepartamentomunicipioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12h61_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentomunicipioid_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentomunicipioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentomunicipioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cDepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cDepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentomunicipioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentomunicipioid_Visible, edtavCdepartamentomunicipioid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentomunicipiocostofiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentomunicipiocostofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentomunicipiocostofilter_Internalname, context.GetMessage( "Departamento Municipio Costo", ""), "", "", lblLbldepartamentomunicipiocostofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13h61_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentomunicipiocosto_Internalname, context.GetMessage( "Departamento Municipio Costo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentomunicipiocosto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cDepartamentoMunicipioCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentomunicipiocosto_Enabled!=0) ? context.localUtil.Format( AV11cDepartamentoMunicipioCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV11cDepartamentoMunicipioCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentomunicipiocosto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentomunicipiocosto_Visible, edtavCdepartamentomunicipiocosto_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentomunicipioestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentomunicipioestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentomunicipioestadofilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLbldepartamentomunicipioestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14h61_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCdepartamentomunicipioestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCdepartamentomunicipioestado, cmbavCdepartamentomunicipioestado_Internalname, StringUtil.RTrim( AV12cDepartamentoMunicipioEstado), 1, cmbavCdepartamentomunicipioestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCdepartamentomunicipioestado.Visible, cmbavCdepartamentomunicipioestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Gx00M0.htm");
            cmbavCdepartamentomunicipioestado.CurrentValue = StringUtil.RTrim( AV12cDepartamentoMunicipioEstado);
            AssignProp("", false, cmbavCdepartamentomunicipioestado_Internalname, "Values", (string)(cmbavCdepartamentomunicipioestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divDepartamentomunicipiointegracionecommercefiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentomunicipiointegracionecommercefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentomunicipiointegracionecommercefilter_Internalname, context.GetMessage( "Departamento Municipio Integracion Ecommerce", ""), "", "", lblLbldepartamentomunicipiointegracionecommercefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15h61_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCdepartamentomunicipiointegracionecommerce_Internalname, context.GetMessage( "Departamento Municipio Integracion Ecommerce", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCdepartamentomunicipiointegracionecommerce, cmbavCdepartamentomunicipiointegracionecommerce_Internalname, StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce), 1, cmbavCdepartamentomunicipiointegracionecommerce_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCdepartamentomunicipiointegracionecommerce.Visible, cmbavCdepartamentomunicipiointegracionecommerce.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Gx00M0.htm");
            cmbavCdepartamentomunicipiointegracionecommerce.CurrentValue = StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce);
            AssignProp("", false, cmbavCdepartamentomunicipiointegracionecommerce_Internalname, "Values", (string)(cmbavCdepartamentomunicipiointegracionecommerce.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16h61_client"+"'", TempTags, "", 2, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void STARTH62( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Municipio", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPH60( ) ;
      }

      protected void WSH62( )
      {
         STARTH62( ) ;
         EVTH62( ) ;
      }

      protected void EVTH62( )
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
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A863DepartamentoMunicipioCosto = context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbDepartamentoMunicipioEstado.Name = cmbDepartamentoMunicipioEstado_Internalname;
                              cmbDepartamentoMunicipioEstado.CurrentValue = cgiGet( cmbDepartamentoMunicipioEstado_Internalname);
                              A908DepartamentoMunicipioEstado = cgiGet( cmbDepartamentoMunicipioEstado_Internalname);
                              n908DepartamentoMunicipioEstado = false;
                              cmbDepartamentoMunicipioIntegraci.Name = cmbDepartamentoMunicipioIntegraci_Internalname;
                              cmbDepartamentoMunicipioIntegraci.CurrentValue = cgiGet( cmbDepartamentoMunicipioIntegraci_Internalname);
                              A967DepartamentoMunicipioIntegraci = cgiGet( cmbDepartamentoMunicipioIntegraci_Internalname);
                              n967DepartamentoMunicipioIntegraci = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17H62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18H62 ();
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
                                       /* Set Refresh If Cdepartamentomunicipioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cDepartamentoMunicipioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentomunicipiocosto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV11cDepartamentoMunicipioCosto )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentomunicipioestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOESTADO"), AV12cDepartamentoMunicipioEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentomunicipiointegracionecommerce Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE"), AV13cDepartamentoMunicipioIntegracionEcommerce) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19H62 ();
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

      protected void WEH62( )
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

      protected void PAH62( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cDepartamentoId ,
                                        long AV7cDepartamentoMunicipioId ,
                                        decimal AV11cDepartamentoMunicipioCosto ,
                                        string AV12cDepartamentoMunicipioEstado ,
                                        string AV13cDepartamentoMunicipioIntegracionEcommerce )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFH62( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DEPARTAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_DEPARTAMENTOMUNICIPIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
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
         if ( cmbavCdepartamentomunicipioestado.ItemCount > 0 )
         {
            AV12cDepartamentoMunicipioEstado = cmbavCdepartamentomunicipioestado.getValidValue(AV12cDepartamentoMunicipioEstado);
            AssignAttri("", false, "AV12cDepartamentoMunicipioEstado", AV12cDepartamentoMunicipioEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCdepartamentomunicipioestado.CurrentValue = StringUtil.RTrim( AV12cDepartamentoMunicipioEstado);
            AssignProp("", false, cmbavCdepartamentomunicipioestado_Internalname, "Values", cmbavCdepartamentomunicipioestado.ToJavascriptSource(), true);
         }
         if ( cmbavCdepartamentomunicipiointegracionecommerce.ItemCount > 0 )
         {
            AV13cDepartamentoMunicipioIntegracionEcommerce = cmbavCdepartamentomunicipiointegracionecommerce.getValidValue(AV13cDepartamentoMunicipioIntegracionEcommerce);
            AssignAttri("", false, "AV13cDepartamentoMunicipioIntegracionEcommerce", AV13cDepartamentoMunicipioIntegracionEcommerce);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCdepartamentomunicipiointegracionecommerce.CurrentValue = StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce);
            AssignProp("", false, cmbavCdepartamentomunicipiointegracionecommerce_Internalname, "Values", cmbavCdepartamentomunicipiointegracionecommerce.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFH62( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFH62( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11cDepartamentoMunicipioCosto ,
                                                 AV12cDepartamentoMunicipioEstado ,
                                                 AV13cDepartamentoMunicipioIntegracionEcommerce ,
                                                 A863DepartamentoMunicipioCosto ,
                                                 A908DepartamentoMunicipioEstado ,
                                                 A967DepartamentoMunicipioIntegraci ,
                                                 AV6cDepartamentoId ,
                                                 AV7cDepartamentoMunicipioId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV12cDepartamentoMunicipioEstado = StringUtil.PadR( StringUtil.RTrim( AV12cDepartamentoMunicipioEstado), 3, "%");
            lV13cDepartamentoMunicipioIntegracionEcommerce = StringUtil.PadR( StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce), 1, "%");
            /* Using cursor H00H62 */
            pr_default.execute(0, new Object[] {AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, lV12cDepartamentoMunicipioEstado, lV13cDepartamentoMunicipioIntegracionEcommerce, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A967DepartamentoMunicipioIntegraci = H00H62_A967DepartamentoMunicipioIntegraci[0];
               n967DepartamentoMunicipioIntegraci = H00H62_n967DepartamentoMunicipioIntegraci[0];
               A908DepartamentoMunicipioEstado = H00H62_A908DepartamentoMunicipioEstado[0];
               n908DepartamentoMunicipioEstado = H00H62_n908DepartamentoMunicipioEstado[0];
               A863DepartamentoMunicipioCosto = H00H62_A863DepartamentoMunicipioCosto[0];
               A114DepartamentoMunicipioId = H00H62_A114DepartamentoMunicipioId[0];
               A112DepartamentoId = H00H62_A112DepartamentoId[0];
               /* Execute user event: Load */
               E18H62 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WBH60( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesH62( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DEPARTAMENTOID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_DEPARTAMENTOMUNICIPIOID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV11cDepartamentoMunicipioCosto ,
                                              AV12cDepartamentoMunicipioEstado ,
                                              AV13cDepartamentoMunicipioIntegracionEcommerce ,
                                              A863DepartamentoMunicipioCosto ,
                                              A908DepartamentoMunicipioEstado ,
                                              A967DepartamentoMunicipioIntegraci ,
                                              AV6cDepartamentoId ,
                                              AV7cDepartamentoMunicipioId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV12cDepartamentoMunicipioEstado = StringUtil.PadR( StringUtil.RTrim( AV12cDepartamentoMunicipioEstado), 3, "%");
         lV13cDepartamentoMunicipioIntegracionEcommerce = StringUtil.PadR( StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce), 1, "%");
         /* Using cursor H00H63 */
         pr_default.execute(1, new Object[] {AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, lV12cDepartamentoMunicipioEstado, lV13cDepartamentoMunicipioIntegracionEcommerce});
         GRID1_nRecordCount = H00H63_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, AV12cDepartamentoMunicipioEstado, AV13cDepartamentoMunicipioIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, AV12cDepartamentoMunicipioEstado, AV13cDepartamentoMunicipioIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, AV12cDepartamentoMunicipioEstado, AV13cDepartamentoMunicipioIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, AV12cDepartamentoMunicipioEstado, AV13cDepartamentoMunicipioIntegracionEcommerce) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cDepartamentoId, AV7cDepartamentoMunicipioId, AV11cDepartamentoMunicipioCosto, AV12cDepartamentoMunicipioEstado, AV13cDepartamentoMunicipioIntegracionEcommerce) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtDepartamentoId_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtDepartamentoMunicipioCosto_Enabled = 0;
         cmbDepartamentoMunicipioEstado.Enabled = 0;
         cmbDepartamentoMunicipioIntegraci.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPH60( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17H62 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOMUNICIPIOID");
               GX_FocusControl = edtavCdepartamentomunicipioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cDepartamentoMunicipioId = 0;
               AssignAttri("", false, "AV7cDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV7cDepartamentoMunicipioId), 18, 0));
            }
            else
            {
               AV7cDepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV7cDepartamentoMunicipioId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipiocosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipiocosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOMUNICIPIOCOSTO");
               GX_FocusControl = edtavCdepartamentomunicipiocosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cDepartamentoMunicipioCosto = 0;
               AssignAttri("", false, "AV11cDepartamentoMunicipioCosto", StringUtil.LTrimStr( AV11cDepartamentoMunicipioCosto, 18, 2));
            }
            else
            {
               AV11cDepartamentoMunicipioCosto = context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipiocosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV11cDepartamentoMunicipioCosto", StringUtil.LTrimStr( AV11cDepartamentoMunicipioCosto, 18, 2));
            }
            cmbavCdepartamentomunicipioestado.Name = cmbavCdepartamentomunicipioestado_Internalname;
            cmbavCdepartamentomunicipioestado.CurrentValue = cgiGet( cmbavCdepartamentomunicipioestado_Internalname);
            AV12cDepartamentoMunicipioEstado = cgiGet( cmbavCdepartamentomunicipioestado_Internalname);
            AssignAttri("", false, "AV12cDepartamentoMunicipioEstado", AV12cDepartamentoMunicipioEstado);
            cmbavCdepartamentomunicipiointegracionecommerce.Name = cmbavCdepartamentomunicipiointegracionecommerce_Internalname;
            cmbavCdepartamentomunicipiointegracionecommerce.CurrentValue = cgiGet( cmbavCdepartamentomunicipiointegracionecommerce_Internalname);
            AV13cDepartamentoMunicipioIntegracionEcommerce = cgiGet( cmbavCdepartamentomunicipiointegracionecommerce_Internalname);
            AssignAttri("", false, "AV13cDepartamentoMunicipioIntegracionEcommerce", AV13cDepartamentoMunicipioIntegracionEcommerce);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cDepartamentoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cDepartamentoMunicipioId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV11cDepartamentoMunicipioCosto )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOESTADO"), AV12cDepartamentoMunicipioEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE"), AV13cDepartamentoMunicipioIntegracionEcommerce) != 0 )
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
         E17H62 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17H62( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV10ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18H62( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19H62 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19H62( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8pDepartamentoId = A112DepartamentoId;
         AssignAttri("", false, "AV8pDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8pDepartamentoId), 18, 0));
         AV9pDepartamentoMunicipioId = A114DepartamentoMunicipioId;
         AssignAttri("", false, "AV9pDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV9pDepartamentoMunicipioId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV8pDepartamentoId,(long)AV9pDepartamentoMunicipioId});
         context.setWebReturnParmsMetadata(new Object[] {"AV8pDepartamentoId","AV9pDepartamentoMunicipioId"});
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
         AV8pDepartamentoId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8pDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8pDepartamentoId), 18, 0));
         AV9pDepartamentoMunicipioId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV9pDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV9pDepartamentoMunicipioId), 18, 0));
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
         PAH62( ) ;
         WSH62( ) ;
         WEH62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021262250", true, true, false);
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
         context.AddJavascriptSource("gx00m0.js", "?202673021262250", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_64_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_64_idx;
         edtDepartamentoMunicipioCosto_Internalname = "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_64_idx;
         cmbDepartamentoMunicipioEstado_Internalname = "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_64_idx;
         cmbDepartamentoMunicipioIntegraci_Internalname = "DEPARTAMENTOMUNICIPIOINTEGRACI_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_64_fel_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_64_fel_idx;
         edtDepartamentoMunicipioCosto_Internalname = "DEPARTAMENTOMUNICIPIOCOSTO_"+sGXsfl_64_fel_idx;
         cmbDepartamentoMunicipioEstado_Internalname = "DEPARTAMENTOMUNICIPIOESTADO_"+sGXsfl_64_fel_idx;
         cmbDepartamentoMunicipioIntegraci_Internalname = "DEPARTAMENTOMUNICIPIOINTEGRACI_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WBH60( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A863DepartamentoMunicipioCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A863DepartamentoMunicipioCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbDepartamentoMunicipioEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "DEPARTAMENTOMUNICIPIOESTADO_" + sGXsfl_64_idx;
               cmbDepartamentoMunicipioEstado.Name = GXCCtl;
               cmbDepartamentoMunicipioEstado.WebTags = "";
               cmbDepartamentoMunicipioEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbDepartamentoMunicipioEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               if ( cmbDepartamentoMunicipioEstado.ItemCount > 0 )
               {
                  A908DepartamentoMunicipioEstado = cmbDepartamentoMunicipioEstado.getValidValue(A908DepartamentoMunicipioEstado);
                  n908DepartamentoMunicipioEstado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbDepartamentoMunicipioEstado,(string)cmbDepartamentoMunicipioEstado_Internalname,StringUtil.RTrim( A908DepartamentoMunicipioEstado),(short)1,(string)cmbDepartamentoMunicipioEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbDepartamentoMunicipioEstado.CurrentValue = StringUtil.RTrim( A908DepartamentoMunicipioEstado);
            AssignProp("", false, cmbDepartamentoMunicipioEstado_Internalname, "Values", (string)(cmbDepartamentoMunicipioEstado.ToJavascriptSource()), !bGXsfl_64_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbDepartamentoMunicipioIntegraci.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "DEPARTAMENTOMUNICIPIOINTEGRACI_" + sGXsfl_64_idx;
               cmbDepartamentoMunicipioIntegraci.Name = GXCCtl;
               cmbDepartamentoMunicipioIntegraci.WebTags = "";
               cmbDepartamentoMunicipioIntegraci.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbDepartamentoMunicipioIntegraci.addItem("T", context.GetMessage( "TOTAL", ""), 0);
               cmbDepartamentoMunicipioIntegraci.addItem("P", context.GetMessage( "PARCIAL", ""), 0);
               cmbDepartamentoMunicipioIntegraci.addItem("D", context.GetMessage( "DESHABILITADO", ""), 0);
               if ( cmbDepartamentoMunicipioIntegraci.ItemCount > 0 )
               {
                  A967DepartamentoMunicipioIntegraci = cmbDepartamentoMunicipioIntegraci.getValidValue(A967DepartamentoMunicipioIntegraci);
                  n967DepartamentoMunicipioIntegraci = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbDepartamentoMunicipioIntegraci,(string)cmbDepartamentoMunicipioIntegraci_Internalname,StringUtil.RTrim( A967DepartamentoMunicipioIntegraci),(short)1,(string)cmbDepartamentoMunicipioIntegraci_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbDepartamentoMunicipioIntegraci.CurrentValue = StringUtil.RTrim( A967DepartamentoMunicipioIntegraci);
            AssignProp("", false, cmbDepartamentoMunicipioIntegraci_Internalname, "Values", (string)(cmbDepartamentoMunicipioIntegraci.ToJavascriptSource()), !bGXsfl_64_Refreshing);
            send_integrity_lvl_hashesH62( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         cmbavCdepartamentomunicipioestado.Name = "vCDEPARTAMENTOMUNICIPIOESTADO";
         cmbavCdepartamentomunicipioestado.WebTags = "";
         cmbavCdepartamentomunicipioestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCdepartamentomunicipioestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbavCdepartamentomunicipioestado.ItemCount > 0 )
         {
            AV12cDepartamentoMunicipioEstado = cmbavCdepartamentomunicipioestado.getValidValue(AV12cDepartamentoMunicipioEstado);
            AssignAttri("", false, "AV12cDepartamentoMunicipioEstado", AV12cDepartamentoMunicipioEstado);
         }
         cmbavCdepartamentomunicipiointegracionecommerce.Name = "vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE";
         cmbavCdepartamentomunicipiointegracionecommerce.WebTags = "";
         cmbavCdepartamentomunicipiointegracionecommerce.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavCdepartamentomunicipiointegracionecommerce.addItem("T", context.GetMessage( "TOTAL", ""), 0);
         cmbavCdepartamentomunicipiointegracionecommerce.addItem("P", context.GetMessage( "PARCIAL", ""), 0);
         cmbavCdepartamentomunicipiointegracionecommerce.addItem("D", context.GetMessage( "DESHABILITADO", ""), 0);
         if ( cmbavCdepartamentomunicipiointegracionecommerce.ItemCount > 0 )
         {
            AV13cDepartamentoMunicipioIntegracionEcommerce = cmbavCdepartamentomunicipiointegracionecommerce.getValidValue(AV13cDepartamentoMunicipioIntegracionEcommerce);
            AssignAttri("", false, "AV13cDepartamentoMunicipioIntegracionEcommerce", AV13cDepartamentoMunicipioIntegracionEcommerce);
         }
         GXCCtl = "DEPARTAMENTOMUNICIPIOESTADO_" + sGXsfl_64_idx;
         cmbDepartamentoMunicipioEstado.Name = GXCCtl;
         cmbDepartamentoMunicipioEstado.WebTags = "";
         cmbDepartamentoMunicipioEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbDepartamentoMunicipioEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbDepartamentoMunicipioEstado.ItemCount > 0 )
         {
            A908DepartamentoMunicipioEstado = cmbDepartamentoMunicipioEstado.getValidValue(A908DepartamentoMunicipioEstado);
            n908DepartamentoMunicipioEstado = false;
         }
         GXCCtl = "DEPARTAMENTOMUNICIPIOINTEGRACI_" + sGXsfl_64_idx;
         cmbDepartamentoMunicipioIntegraci.Name = GXCCtl;
         cmbDepartamentoMunicipioIntegraci.WebTags = "";
         cmbDepartamentoMunicipioIntegraci.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbDepartamentoMunicipioIntegraci.addItem("T", context.GetMessage( "TOTAL", ""), 0);
         cmbDepartamentoMunicipioIntegraci.addItem("P", context.GetMessage( "PARCIAL", ""), 0);
         cmbDepartamentoMunicipioIntegraci.addItem("D", context.GetMessage( "DESHABILITADO", ""), 0);
         if ( cmbDepartamentoMunicipioIntegraci.ItemCount > 0 )
         {
            A967DepartamentoMunicipioIntegraci = cmbDepartamentoMunicipioIntegraci.getValidValue(A967DepartamentoMunicipioIntegraci);
            n967DepartamentoMunicipioIntegraci = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Municipio Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Integracion Ecommerce", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A863DepartamentoMunicipioCosto, 21, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A908DepartamentoMunicipioEstado)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A967DepartamentoMunicipioIntegraci)));
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
         lblLbldepartamentomunicipioidfilter_Internalname = "LBLDEPARTAMENTOMUNICIPIOIDFILTER";
         edtavCdepartamentomunicipioid_Internalname = "vCDEPARTAMENTOMUNICIPIOID";
         divDepartamentomunicipioidfiltercontainer_Internalname = "DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER";
         lblLbldepartamentomunicipiocostofilter_Internalname = "LBLDEPARTAMENTOMUNICIPIOCOSTOFILTER";
         edtavCdepartamentomunicipiocosto_Internalname = "vCDEPARTAMENTOMUNICIPIOCOSTO";
         divDepartamentomunicipiocostofiltercontainer_Internalname = "DEPARTAMENTOMUNICIPIOCOSTOFILTERCONTAINER";
         lblLbldepartamentomunicipioestadofilter_Internalname = "LBLDEPARTAMENTOMUNICIPIOESTADOFILTER";
         cmbavCdepartamentomunicipioestado_Internalname = "vCDEPARTAMENTOMUNICIPIOESTADO";
         divDepartamentomunicipioestadofiltercontainer_Internalname = "DEPARTAMENTOMUNICIPIOESTADOFILTERCONTAINER";
         lblLbldepartamentomunicipiointegracionecommercefilter_Internalname = "LBLDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTER";
         cmbavCdepartamentomunicipiointegracionecommerce_Internalname = "vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE";
         divDepartamentomunicipiointegracionecommercefiltercontainer_Internalname = "DEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtDepartamentoMunicipioCosto_Internalname = "DEPARTAMENTOMUNICIPIOCOSTO";
         cmbDepartamentoMunicipioEstado_Internalname = "DEPARTAMENTOMUNICIPIOESTADO";
         cmbDepartamentoMunicipioIntegraci_Internalname = "DEPARTAMENTOMUNICIPIOINTEGRACI";
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
         cmbDepartamentoMunicipioIntegraci_Jsonclick = "";
         cmbDepartamentoMunicipioEstado_Jsonclick = "";
         edtDepartamentoMunicipioCosto_Jsonclick = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         cmbDepartamentoMunicipioIntegraci.Enabled = 0;
         cmbDepartamentoMunicipioEstado.Enabled = 0;
         edtDepartamentoMunicipioCosto_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         cmbavCdepartamentomunicipiointegracionecommerce_Jsonclick = "";
         cmbavCdepartamentomunicipiointegracionecommerce.Visible = 1;
         cmbavCdepartamentomunicipiointegracionecommerce.Enabled = 1;
         cmbavCdepartamentomunicipioestado_Jsonclick = "";
         cmbavCdepartamentomunicipioestado.Visible = 1;
         cmbavCdepartamentomunicipioestado.Enabled = 1;
         edtavCdepartamentomunicipiocosto_Jsonclick = "";
         edtavCdepartamentomunicipiocosto_Enabled = 1;
         edtavCdepartamentomunicipiocosto_Visible = 1;
         edtavCdepartamentomunicipioid_Jsonclick = "";
         edtavCdepartamentomunicipioid_Enabled = 1;
         edtavCdepartamentomunicipioid_Visible = 1;
         edtavCdepartamentoid_Jsonclick = "";
         edtavCdepartamentoid_Enabled = 1;
         edtavCdepartamentoid_Visible = 1;
         divDepartamentomunicipiointegracionecommercefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentomunicipioestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentomunicipiocostofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentomunicipioidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Municipio", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioCosto',fld:'vCDEPARTAMENTOMUNICIPIOCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCdepartamentomunicipioestado'},{av:'AV12cDepartamentoMunicipioEstado',fld:'vCDEPARTAMENTOMUNICIPIOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentomunicipiointegracionecommerce'},{av:'AV13cDepartamentoMunicipioIntegracionEcommerce',fld:'vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16H61',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK","{handler:'E11H61',iparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK",",oparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoid_Visible',ctrl:'vCDEPARTAMENTOID',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOIDFILTER.CLICK","{handler:'E12H61',iparms:[{av:'divDepartamentomunicipioidfiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOIDFILTER.CLICK",",oparms:[{av:'divDepartamentomunicipioidfiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentomunicipioid_Visible',ctrl:'vCDEPARTAMENTOMUNICIPIOID',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOCOSTOFILTER.CLICK","{handler:'E13H61',iparms:[{av:'divDepartamentomunicipiocostofiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOCOSTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOCOSTOFILTER.CLICK",",oparms:[{av:'divDepartamentomunicipiocostofiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOCOSTOFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentomunicipiocosto_Visible',ctrl:'vCDEPARTAMENTOMUNICIPIOCOSTO',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOESTADOFILTER.CLICK","{handler:'E14H61',iparms:[{av:'divDepartamentomunicipioestadofiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOESTADOFILTER.CLICK",",oparms:[{av:'divDepartamentomunicipioestadofiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCdepartamentomunicipioestado'}]}");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTER.CLICK","{handler:'E15H61',iparms:[{av:'divDepartamentomunicipiointegracionecommercefiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTER.CLICK",",oparms:[{av:'divDepartamentomunicipiointegracionecommercefiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCEFILTERCONTAINER',prop:'Class'},{av:'cmbavCdepartamentomunicipiointegracionecommerce'}]}");
         setEventMetadata("ENTER","{handler:'E19H62',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8pDepartamentoId',fld:'vPDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9pDepartamentoMunicipioId',fld:'vPDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioCosto',fld:'vCDEPARTAMENTOMUNICIPIOCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCdepartamentomunicipioestado'},{av:'AV12cDepartamentoMunicipioEstado',fld:'vCDEPARTAMENTOMUNICIPIOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentomunicipiointegracionecommerce'},{av:'AV13cDepartamentoMunicipioIntegracionEcommerce',fld:'vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioCosto',fld:'vCDEPARTAMENTOMUNICIPIOCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCdepartamentomunicipioestado'},{av:'AV12cDepartamentoMunicipioEstado',fld:'vCDEPARTAMENTOMUNICIPIOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentomunicipiointegracionecommerce'},{av:'AV13cDepartamentoMunicipioIntegracionEcommerce',fld:'vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioCosto',fld:'vCDEPARTAMENTOMUNICIPIOCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCdepartamentomunicipioestado'},{av:'AV12cDepartamentoMunicipioEstado',fld:'vCDEPARTAMENTOMUNICIPIOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentomunicipiointegracionecommerce'},{av:'AV13cDepartamentoMunicipioIntegracionEcommerce',fld:'vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioCosto',fld:'vCDEPARTAMENTOMUNICIPIOCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCdepartamentomunicipioestado'},{av:'AV12cDepartamentoMunicipioEstado',fld:'vCDEPARTAMENTOMUNICIPIOESTADO',pic:'',type:'char'},{av:'cmbavCdepartamentomunicipiointegracionecommerce'},{av:'AV13cDepartamentoMunicipioIntegracionEcommerce',fld:'vCDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE","{handler:'Validv_Cdepartamentomunicipiointegracionecommerce',iparms:[]");
         setEventMetadata("VALIDV_CDEPARTAMENTOMUNICIPIOINTEGRACIONECOMMERCE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Departamentomunicipiointegraci',iparms:[]");
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
         AV12cDepartamentoMunicipioEstado = "";
         AV13cDepartamentoMunicipioIntegracionEcommerce = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbldepartamentoidfilter_Jsonclick = "";
         TempTags = "";
         lblLbldepartamentomunicipioidfilter_Jsonclick = "";
         lblLbldepartamentomunicipiocostofilter_Jsonclick = "";
         lblLbldepartamentomunicipioestadofilter_Jsonclick = "";
         lblLbldepartamentomunicipiointegracionecommercefilter_Jsonclick = "";
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
         A908DepartamentoMunicipioEstado = "";
         A967DepartamentoMunicipioIntegraci = "";
         lV12cDepartamentoMunicipioEstado = "";
         lV13cDepartamentoMunicipioIntegracionEcommerce = "";
         H00H62_A967DepartamentoMunicipioIntegraci = new string[] {""} ;
         H00H62_n967DepartamentoMunicipioIntegraci = new bool[] {false} ;
         H00H62_A908DepartamentoMunicipioEstado = new string[] {""} ;
         H00H62_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         H00H62_A863DepartamentoMunicipioCosto = new decimal[1] ;
         H00H62_A114DepartamentoMunicipioId = new long[1] ;
         H00H62_A112DepartamentoId = new long[1] ;
         H00H63_AGRID1_nRecordCount = new long[1] ;
         AV10ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00m0__default(),
            new Object[][] {
                new Object[] {
               H00H62_A967DepartamentoMunicipioIntegraci, H00H62_n967DepartamentoMunicipioIntegraci, H00H62_A908DepartamentoMunicipioEstado, H00H62_n908DepartamentoMunicipioEstado, H00H62_A863DepartamentoMunicipioCosto, H00H62_A114DepartamentoMunicipioId, H00H62_A112DepartamentoId
               }
               , new Object[] {
               H00H63_AGRID1_nRecordCount
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
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCdepartamentoid_Enabled ;
      private int edtavCdepartamentoid_Visible ;
      private int edtavCdepartamentomunicipioid_Enabled ;
      private int edtavCdepartamentomunicipioid_Visible ;
      private int edtavCdepartamentomunicipiocosto_Enabled ;
      private int edtavCdepartamentomunicipiocosto_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int edtDepartamentoMunicipioCosto_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV8pDepartamentoId ;
      private long AV9pDepartamentoMunicipioId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cDepartamentoId ;
      private long AV7cDepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV11cDepartamentoMunicipioCosto ;
      private decimal A863DepartamentoMunicipioCosto ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divDepartamentoidfiltercontainer_Class ;
      private string divDepartamentomunicipioidfiltercontainer_Class ;
      private string divDepartamentomunicipiocostofiltercontainer_Class ;
      private string divDepartamentomunicipioestadofiltercontainer_Class ;
      private string divDepartamentomunicipiointegracionecommercefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV12cDepartamentoMunicipioEstado ;
      private string AV13cDepartamentoMunicipioIntegracionEcommerce ;
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
      private string divDepartamentomunicipioidfiltercontainer_Internalname ;
      private string lblLbldepartamentomunicipioidfilter_Internalname ;
      private string lblLbldepartamentomunicipioidfilter_Jsonclick ;
      private string edtavCdepartamentomunicipioid_Internalname ;
      private string edtavCdepartamentomunicipioid_Jsonclick ;
      private string divDepartamentomunicipiocostofiltercontainer_Internalname ;
      private string lblLbldepartamentomunicipiocostofilter_Internalname ;
      private string lblLbldepartamentomunicipiocostofilter_Jsonclick ;
      private string edtavCdepartamentomunicipiocosto_Internalname ;
      private string edtavCdepartamentomunicipiocosto_Jsonclick ;
      private string divDepartamentomunicipioestadofiltercontainer_Internalname ;
      private string lblLbldepartamentomunicipioestadofilter_Internalname ;
      private string lblLbldepartamentomunicipioestadofilter_Jsonclick ;
      private string cmbavCdepartamentomunicipioestado_Internalname ;
      private string cmbavCdepartamentomunicipioestado_Jsonclick ;
      private string divDepartamentomunicipiointegracionecommercefiltercontainer_Internalname ;
      private string lblLbldepartamentomunicipiointegracionecommercefilter_Internalname ;
      private string lblLbldepartamentomunicipiointegracionecommercefilter_Jsonclick ;
      private string cmbavCdepartamentomunicipiointegracionecommerce_Internalname ;
      private string cmbavCdepartamentomunicipiointegracionecommerce_Jsonclick ;
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
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtDepartamentoMunicipioCosto_Internalname ;
      private string cmbDepartamentoMunicipioEstado_Internalname ;
      private string A908DepartamentoMunicipioEstado ;
      private string cmbDepartamentoMunicipioIntegraci_Internalname ;
      private string A967DepartamentoMunicipioIntegraci ;
      private string lV12cDepartamentoMunicipioEstado ;
      private string lV13cDepartamentoMunicipioIntegracionEcommerce ;
      private string AV10ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string edtDepartamentoMunicipioCosto_Jsonclick ;
      private string GXCCtl ;
      private string cmbDepartamentoMunicipioEstado_Jsonclick ;
      private string cmbDepartamentoMunicipioIntegraci_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n908DepartamentoMunicipioEstado ;
      private bool n967DepartamentoMunicipioIntegraci ;
      private bool gxdyncontrolsrefreshing ;
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
      private GXCombobox cmbavCdepartamentomunicipioestado ;
      private GXCombobox cmbavCdepartamentomunicipiointegracionecommerce ;
      private GXCombobox cmbDepartamentoMunicipioEstado ;
      private GXCombobox cmbDepartamentoMunicipioIntegraci ;
      private IDataStoreProvider pr_default ;
      private string[] H00H62_A967DepartamentoMunicipioIntegraci ;
      private bool[] H00H62_n967DepartamentoMunicipioIntegraci ;
      private string[] H00H62_A908DepartamentoMunicipioEstado ;
      private bool[] H00H62_n908DepartamentoMunicipioEstado ;
      private decimal[] H00H62_A863DepartamentoMunicipioCosto ;
      private long[] H00H62_A114DepartamentoMunicipioId ;
      private long[] H00H62_A112DepartamentoId ;
      private long[] H00H63_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pDepartamentoId ;
      private long aP1_pDepartamentoMunicipioId ;
   }

   public class gx00m0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00H62( IGxContext context ,
                                             decimal AV11cDepartamentoMunicipioCosto ,
                                             string AV12cDepartamentoMunicipioEstado ,
                                             string AV13cDepartamentoMunicipioIntegracionEcommerce ,
                                             decimal A863DepartamentoMunicipioCosto ,
                                             string A908DepartamentoMunicipioEstado ,
                                             string A967DepartamentoMunicipioIntegraci ,
                                             long AV6cDepartamentoId ,
                                             long AV7cDepartamentoMunicipioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DepartamentoMunicipioIntegraci], [DepartamentoMunicipioEstado], [DepartamentoMunicipioCosto], [DepartamentoMunicipioId], [DepartamentoId]";
         sFromString = " FROM [DepartamentoMunicipio]";
         sOrderString = "";
         AddWhere(sWhereString, "([DepartamentoId] >= @AV6cDepartamentoId and [DepartamentoMunicipioId] >= @AV7cDepartamentoMunicipioId)");
         if ( ! (Convert.ToDecimal(0)==AV11cDepartamentoMunicipioCosto) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioCosto] >= @AV11cDepartamentoMunicipioCosto)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cDepartamentoMunicipioEstado)) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioEstado] like @lV12cDepartamentoMunicipioEstado)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce)) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioIntegraci] like @lV13cDepartamentoMunicipioIntegracionEcommerce)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [DepartamentoId], [DepartamentoMunicipioId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00H63( IGxContext context ,
                                             decimal AV11cDepartamentoMunicipioCosto ,
                                             string AV12cDepartamentoMunicipioEstado ,
                                             string AV13cDepartamentoMunicipioIntegracionEcommerce ,
                                             decimal A863DepartamentoMunicipioCosto ,
                                             string A908DepartamentoMunicipioEstado ,
                                             string A967DepartamentoMunicipioIntegraci ,
                                             long AV6cDepartamentoId ,
                                             long AV7cDepartamentoMunicipioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [DepartamentoMunicipio]";
         AddWhere(sWhereString, "([DepartamentoId] >= @AV6cDepartamentoId and [DepartamentoMunicipioId] >= @AV7cDepartamentoMunicipioId)");
         if ( ! (Convert.ToDecimal(0)==AV11cDepartamentoMunicipioCosto) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioCosto] >= @AV11cDepartamentoMunicipioCosto)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cDepartamentoMunicipioEstado)) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioEstado] like @lV12cDepartamentoMunicipioEstado)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cDepartamentoMunicipioIntegracionEcommerce)) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioIntegraci] like @lV13cDepartamentoMunicipioIntegracionEcommerce)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00H62(context, (decimal)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
               case 1 :
                     return conditional_H00H63(context, (decimal)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
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
          Object[] prmH00H62;
          prmH00H62 = new Object[] {
          new ParDef("@AV6cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV11cDepartamentoMunicipioCosto",GXType.Decimal,18,2) ,
          new ParDef("@lV12cDepartamentoMunicipioEstado",GXType.NChar,3,0) ,
          new ParDef("@lV13cDepartamentoMunicipioIntegracionEcommerce",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00H63;
          prmH00H63 = new Object[] {
          new ParDef("@AV6cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV11cDepartamentoMunicipioCosto",GXType.Decimal,18,2) ,
          new ParDef("@lV12cDepartamentoMunicipioEstado",GXType.NChar,3,0) ,
          new ParDef("@lV13cDepartamentoMunicipioIntegracionEcommerce",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00H62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00H62,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00H63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00H63,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

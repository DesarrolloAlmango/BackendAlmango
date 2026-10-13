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
   public class gx00q1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00q1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00q1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pRubrosId ,
                           out long aP1_pMedidasID )
      {
         this.AV12pRubrosId = aP0_pRubrosId;
         this.AV13pMedidasID = 0 ;
         ExecutePrivate();
         aP1_pMedidasID=this.AV13pMedidasID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCmedidasestado = new GXCombobox();
         cmbMedidasEstado = new GXCombobox();
         dynMedidasID = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pRubrosId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MEDIDASID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLAMEDIDASID9C2( ) ;
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
               gxfirstwebparm = GetFirstPar( "pRubrosId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pRubrosId");
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
               AV12pRubrosId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pRubrosId", StringUtil.LTrimStr( (decimal)(AV12pRubrosId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "pMedidasID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pMedidasID", StringUtil.LTrimStr( (decimal)(AV13pMedidasID), 18, 0));
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
         AV6cMedidasNombre = GetPar( "cMedidasNombre");
         AV7cRubrosCosto = NumberUtil.Val( GetPar( "cRubrosCosto"), ".");
         AV8cRubrosPrecioBase = NumberUtil.Val( GetPar( "cRubrosPrecioBase"), ".");
         cmbavCmedidasestado.FromJSonString( GetNextPar( ));
         AV9cMedidasEstado = GetPar( "cMedidasEstado");
         AV10cTextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "cTextosId"), "."), 18, MidpointRounding.ToEven));
         AV11cInventarioSerial = (short)(Math.Round(NumberUtil.Val( GetPar( "cInventarioSerial"), "."), 18, MidpointRounding.ToEven));
         AV12pRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "pRubrosId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, AV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, AV12pRubrosId) ;
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
         PA9C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9C2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00q1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pRubrosId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pMedidasID,18,0))}, new string[] {"pRubrosId","pMedidasID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCMEDIDASNOMBRE", StringUtil.RTrim( AV6cMedidasNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCRUBROSCOSTO", StringUtil.LTrim( StringUtil.NToC( AV7cRubrosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRUBROSPRECIOBASE", StringUtil.LTrim( StringUtil.NToC( AV8cRubrosPrecioBase, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMEDIDASESTADO", StringUtil.RTrim( AV9cMedidasEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCTEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVENTARIOSERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cInventarioSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MEDIDASNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divMedidasnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RUBROSCOSTOFILTERCONTAINER_Class", StringUtil.RTrim( divRubroscostofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RUBROSPRECIOBASEFILTERCONTAINER_Class", StringUtil.RTrim( divRubrospreciobasefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MEDIDASESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divMedidasestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TEXTOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divTextosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVENTARIOSERIALFILTERCONTAINER_Class", StringUtil.RTrim( divInventarioserialfiltercontainer_Class));
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
            WE9C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9C2( ) ;
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
         return formatLink("gx00q1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pRubrosId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pMedidasID,18,0))}, new string[] {"pRubrosId","pMedidasID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00Q1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Rubros Medidas y Precios", "") ;
      }

      protected void WB9C0( )
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
            GxWebStd.gx_div_start( context, divMedidasnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divMedidasnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmedidasnombrefilter_Internalname, context.GetMessage( "Nombre de la Característica", ""), "", "", lblLblmedidasnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmedidasnombre_Internalname, context.GetMessage( "Nombre de la Característica", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmedidasnombre_Internalname, StringUtil.RTrim( AV6cMedidasNombre), StringUtil.RTrim( context.localUtil.Format( AV6cMedidasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmedidasnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmedidasnombre_Visible, edtavCmedidasnombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00Q1.htm");
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
            GxWebStd.gx_div_start( context, divRubroscostofiltercontainer_Internalname, 1, 0, "px", 0, "px", divRubroscostofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrubroscostofilter_Internalname, context.GetMessage( "Costo Base", ""), "", "", lblLblrubroscostofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrubroscosto_Internalname, context.GetMessage( "Costo Base", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrubroscosto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7cRubrosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCrubroscosto_Enabled!=0) ? context.localUtil.Format( AV7cRubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV7cRubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrubroscosto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrubroscosto_Visible, edtavCrubroscosto_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00Q1.htm");
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
            GxWebStd.gx_div_start( context, divRubrospreciobasefiltercontainer_Internalname, 1, 0, "px", 0, "px", divRubrospreciobasefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrubrospreciobasefilter_Internalname, context.GetMessage( "Precio Base", ""), "", "", lblLblrubrospreciobasefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrubrospreciobase_Internalname, context.GetMessage( "Precio Base", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrubrospreciobase_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8cRubrosPrecioBase, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCrubrospreciobase_Enabled!=0) ? context.localUtil.Format( AV8cRubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV8cRubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrubrospreciobase_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrubrospreciobase_Visible, edtavCrubrospreciobase_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00Q1.htm");
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
            GxWebStd.gx_div_start( context, divMedidasestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMedidasestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmedidasestadofilter_Internalname, context.GetMessage( "Estado de la Lista", ""), "", "", lblLblmedidasestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmedidasestado_Internalname, context.GetMessage( "Estado de la Lista", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmedidasestado, cmbavCmedidasestado_Internalname, StringUtil.RTrim( AV9cMedidasEstado), 1, cmbavCmedidasestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCmedidasestado.Visible, cmbavCmedidasestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Gx00Q1.htm");
            cmbavCmedidasestado.CurrentValue = StringUtil.RTrim( AV9cMedidasEstado);
            AssignProp("", false, cmbavCmedidasestado_Internalname, "Values", (string)(cmbavCmedidasestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTextosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTextosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltextosidfilter_Internalname, context.GetMessage( "Textos Id", ""), "", "", lblLbltextosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtextosid_Internalname, context.GetMessage( "Textos Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtextosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCtextosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cTextosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10cTextosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtextosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtextosid_Visible, edtavCtextosid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00Q1.htm");
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
            GxWebStd.gx_div_start( context, divInventarioserialfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInventarioserialfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinventarioserialfilter_Internalname, context.GetMessage( "Inventario Serial", ""), "", "", lblLblinventarioserialfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinventarioserial_Internalname, context.GetMessage( "Inventario Serial", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinventarioserial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cInventarioSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCinventarioserial_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cInventarioSerial), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cInventarioSerial), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinventarioserial_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinventarioserial_Visible, edtavCinventarioserial_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00Q1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e179c1_client"+"'", TempTags, "", 2, "HLP_Gx00Q1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00Q1.htm");
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

      protected void START9C2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Rubros Medidas y Precios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9C0( ) ;
      }

      protected void WS9C2( )
      {
         START9C2( ) ;
         EVT9C2( ) ;
      }

      protected void EVT9C2( )
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
                              A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
                              A215RubrosCosto = context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A216RubrosPrecioBase = context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbMedidasEstado.Name = cmbMedidasEstado_Internalname;
                              cmbMedidasEstado.CurrentValue = cgiGet( cmbMedidasEstado_Internalname);
                              A139MedidasEstado = cgiGet( cmbMedidasEstado_Internalname);
                              n139MedidasEstado = false;
                              A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              dynMedidasID.Name = dynMedidasID_Internalname;
                              dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
                              A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E189C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E199C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmedidasnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV6cMedidasNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crubroscosto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV7cRubrosCosto )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crubrospreciobase Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSPRECIOBASE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV8cRubrosPrecioBase )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmedidasestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASESTADO"), AV9cMedidasEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctextosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTEXTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cTextosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinventarioserial Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVENTARIOSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cInventarioSerial )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E209C2 ();
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

      protected void WE9C2( )
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

      protected void PA9C2( )
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

      protected void GXDLAMEDIDASID9C2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data9C2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXAMEDIDASID_html9C2( )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data9C2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMedidasID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynMedidasID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAMEDIDASID_data9C2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H009C2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H009C2_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H009C2_A138MedidasNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
                                        string AV6cMedidasNombre ,
                                        decimal AV7cRubrosCosto ,
                                        decimal AV8cRubrosPrecioBase ,
                                        string AV9cMedidasEstado ,
                                        long AV10cTextosId ,
                                        short AV11cInventarioSerial ,
                                        short AV12pRubrosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MEDIDASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
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
         if ( cmbavCmedidasestado.ItemCount > 0 )
         {
            AV9cMedidasEstado = cmbavCmedidasestado.getValidValue(AV9cMedidasEstado);
            AssignAttri("", false, "AV9cMedidasEstado", AV9cMedidasEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmedidasestado.CurrentValue = StringUtil.RTrim( AV9cMedidasEstado);
            AssignProp("", false, cmbavCmedidasestado_Internalname, "Values", cmbavCmedidasestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9C2( )
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
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV6cMedidasNombre ,
                                                 AV7cRubrosCosto ,
                                                 AV8cRubrosPrecioBase ,
                                                 AV9cMedidasEstado ,
                                                 AV10cTextosId ,
                                                 AV11cInventarioSerial ,
                                                 A138MedidasNombre ,
                                                 A215RubrosCosto ,
                                                 A216RubrosPrecioBase ,
                                                 A139MedidasEstado ,
                                                 A150TextosId ,
                                                 A218InventarioSerial ,
                                                 AV12pRubrosId ,
                                                 A121RubrosId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV6cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV6cMedidasNombre), 50, "%");
            lV9cMedidasEstado = StringUtil.PadR( StringUtil.RTrim( AV9cMedidasEstado), 3, "%");
            /* Using cursor H009C3 */
            pr_default.execute(1, new Object[] {AV12pRubrosId, lV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, lV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A118MonedaId = H009C3_A118MonedaId[0];
               A218InventarioSerial = H009C3_A218InventarioSerial[0];
               A150TextosId = H009C3_A150TextosId[0];
               n150TextosId = H009C3_n150TextosId[0];
               A137MedidasID = H009C3_A137MedidasID[0];
               A121RubrosId = H009C3_A121RubrosId[0];
               A119MonedaISOSimbolo = H009C3_A119MonedaISOSimbolo[0];
               A139MedidasEstado = H009C3_A139MedidasEstado[0];
               n139MedidasEstado = H009C3_n139MedidasEstado[0];
               A216RubrosPrecioBase = H009C3_A216RubrosPrecioBase[0];
               A215RubrosCosto = H009C3_A215RubrosCosto[0];
               A138MedidasNombre = H009C3_A138MedidasNombre[0];
               A119MonedaISOSimbolo = H009C3_A119MonedaISOSimbolo[0];
               /* Execute user event: Load */
               E199C2 ();
               pr_default.readNext(1);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 74;
            WB9C0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9C2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MEDIDASID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV6cMedidasNombre ,
                                              AV7cRubrosCosto ,
                                              AV8cRubrosPrecioBase ,
                                              AV9cMedidasEstado ,
                                              AV10cTextosId ,
                                              AV11cInventarioSerial ,
                                              A138MedidasNombre ,
                                              A215RubrosCosto ,
                                              A216RubrosPrecioBase ,
                                              A139MedidasEstado ,
                                              A150TextosId ,
                                              A218InventarioSerial ,
                                              AV12pRubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV6cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV6cMedidasNombre), 50, "%");
         lV9cMedidasEstado = StringUtil.PadR( StringUtil.RTrim( AV9cMedidasEstado), 3, "%");
         /* Using cursor H009C4 */
         pr_default.execute(2, new Object[] {AV12pRubrosId, lV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, lV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial});
         GRID1_nRecordCount = H009C4_AGRID1_nRecordCount[0];
         pr_default.close(2);
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, AV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, AV12pRubrosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, AV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, AV12pRubrosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, AV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, AV12pRubrosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, AV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, AV12pRubrosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMedidasNombre, AV7cRubrosCosto, AV8cRubrosPrecioBase, AV9cMedidasEstado, AV10cTextosId, AV11cInventarioSerial, AV12pRubrosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         GXAMEDIDASID_html9C2( ) ;
         edtMedidasNombre_Enabled = 0;
         edtRubrosCosto_Enabled = 0;
         edtRubrosPrecioBase_Enabled = 0;
         cmbMedidasEstado.Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtRubrosId_Enabled = 0;
         dynMedidasID.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E189C2 ();
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
            AV6cMedidasNombre = cgiGet( edtavCmedidasnombre_Internalname);
            AssignAttri("", false, "AV6cMedidasNombre", AV6cMedidasNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrubroscosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrubroscosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRUBROSCOSTO");
               GX_FocusControl = edtavCrubroscosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cRubrosCosto = 0;
               AssignAttri("", false, "AV7cRubrosCosto", StringUtil.LTrimStr( AV7cRubrosCosto, 18, 2));
            }
            else
            {
               AV7cRubrosCosto = context.localUtil.CToN( cgiGet( edtavCrubroscosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV7cRubrosCosto", StringUtil.LTrimStr( AV7cRubrosCosto, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrubrospreciobase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrubrospreciobase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRUBROSPRECIOBASE");
               GX_FocusControl = edtavCrubrospreciobase_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cRubrosPrecioBase = 0;
               AssignAttri("", false, "AV8cRubrosPrecioBase", StringUtil.LTrimStr( AV8cRubrosPrecioBase, 18, 2));
            }
            else
            {
               AV8cRubrosPrecioBase = context.localUtil.CToN( cgiGet( edtavCrubrospreciobase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV8cRubrosPrecioBase", StringUtil.LTrimStr( AV8cRubrosPrecioBase, 18, 2));
            }
            cmbavCmedidasestado.Name = cmbavCmedidasestado_Internalname;
            cmbavCmedidasestado.CurrentValue = cgiGet( cmbavCmedidasestado_Internalname);
            AV9cMedidasEstado = cgiGet( cmbavCmedidasestado_Internalname);
            AssignAttri("", false, "AV9cMedidasEstado", AV9cMedidasEstado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtextosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtextosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTEXTOSID");
               GX_FocusControl = edtavCtextosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTextosId = 0;
               AssignAttri("", false, "AV10cTextosId", StringUtil.LTrimStr( (decimal)(AV10cTextosId), 18, 0));
            }
            else
            {
               AV10cTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCtextosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cTextosId", StringUtil.LTrimStr( (decimal)(AV10cTextosId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinventarioserial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinventarioserial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVENTARIOSERIAL");
               GX_FocusControl = edtavCinventarioserial_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cInventarioSerial = 0;
               AssignAttri("", false, "AV11cInventarioSerial", StringUtil.LTrimStr( (decimal)(AV11cInventarioSerial), 4, 0));
            }
            else
            {
               AV11cInventarioSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinventarioserial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cInventarioSerial", StringUtil.LTrimStr( (decimal)(AV11cInventarioSerial), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV6cMedidasNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV7cRubrosCosto )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSPRECIOBASE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV8cRubrosPrecioBase )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASESTADO"), AV9cMedidasEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTEXTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cTextosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVENTARIOSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cInventarioSerial )) )
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
         E189C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E189C2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E199C2( )
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
         E209C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E209C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pMedidasID = A137MedidasID;
         AssignAttri("", false, "AV13pMedidasID", StringUtil.LTrimStr( (decimal)(AV13pMedidasID), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pMedidasID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pMedidasID"});
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
         AV12pRubrosId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12pRubrosId", StringUtil.LTrimStr( (decimal)(AV12pRubrosId), 4, 0));
         AV13pMedidasID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pMedidasID", StringUtil.LTrimStr( (decimal)(AV13pMedidasID), 18, 0));
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
         PA9C2( ) ;
         WS9C2( ) ;
         WE9C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320155893", true, true, false);
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
         context.AddJavascriptSource("gx00q1.js", "?20269320155894", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_74_idx;
         edtRubrosCosto_Internalname = "RUBROSCOSTO_"+sGXsfl_74_idx;
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE_"+sGXsfl_74_idx;
         cmbMedidasEstado_Internalname = "MEDIDASESTADO_"+sGXsfl_74_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_74_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_74_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_74_fel_idx;
         edtRubrosCosto_Internalname = "RUBROSCOSTO_"+sGXsfl_74_fel_idx;
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE_"+sGXsfl_74_fel_idx;
         cmbMedidasEstado_Internalname = "MEDIDASESTADO_"+sGXsfl_74_fel_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_74_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_74_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB9C0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasNombre_Internalname,StringUtil.RTrim( A138MedidasNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtRubrosCosto_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtRubrosCosto_Internalname, "Link", edtRubrosCosto_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A215RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRubrosCosto_Link,(string)"",(string)"",(string)"",(string)edtRubrosCosto_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosPrecioBase_Internalname,StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A216RubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosPrecioBase_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMedidasEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDIDASESTADO_" + sGXsfl_74_idx;
               cmbMedidasEstado.Name = GXCCtl;
               cmbMedidasEstado.WebTags = "";
               cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbMedidasEstado.ItemCount > 0 )
               {
                  A139MedidasEstado = cmbMedidasEstado.getValidValue(A139MedidasEstado);
                  n139MedidasEstado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMedidasEstado,(string)cmbMedidasEstado_Internalname,StringUtil.RTrim( A139MedidasEstado),(short)1,(string)cmbMedidasEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMedidasEstado.CurrentValue = StringUtil.RTrim( A139MedidasEstado);
            AssignProp("", false, cmbMedidasEstado_Internalname, "Values", (string)(cmbMedidasEstado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaISOSimbolo_Internalname,StringUtil.RTrim( A119MonedaISOSimbolo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaISOSimbolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"MonISO",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GXAMEDIDASID_html9C2( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_74_idx;
               dynMedidasID.Name = GXCCtl;
               dynMedidasID.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
            AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            send_integrity_lvl_hashes9C2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCmedidasestado.Name = "vCMEDIDASESTADO";
         cmbavCmedidasestado.WebTags = "";
         cmbavCmedidasestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCmedidasestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbavCmedidasestado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbavCmedidasestado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbavCmedidasestado.ItemCount > 0 )
         {
            AV9cMedidasEstado = cmbavCmedidasestado.getValidValue(AV9cMedidasEstado);
            AssignAttri("", false, "AV9cMedidasEstado", AV9cMedidasEstado);
         }
         GXCCtl = "MEDIDASESTADO_" + sGXsfl_74_idx;
         cmbMedidasEstado.Name = GXCCtl;
         cmbMedidasEstado.WebTags = "";
         cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMedidasEstado.ItemCount > 0 )
         {
            A139MedidasEstado = cmbMedidasEstado.getValidValue(A139MedidasEstado);
            n139MedidasEstado = false;
         }
         GXCCtl = "MEDIDASID_" + sGXsfl_74_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
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
            context.SendWebValue( context.GetMessage( "Nombre de la Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo Base", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Base", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado de la Lista", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items/Característica", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtRubrosCosto_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A139MedidasEstado)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A119MonedaISOSimbolo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
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
         lblLblmedidasnombrefilter_Internalname = "LBLMEDIDASNOMBREFILTER";
         edtavCmedidasnombre_Internalname = "vCMEDIDASNOMBRE";
         divMedidasnombrefiltercontainer_Internalname = "MEDIDASNOMBREFILTERCONTAINER";
         lblLblrubroscostofilter_Internalname = "LBLRUBROSCOSTOFILTER";
         edtavCrubroscosto_Internalname = "vCRUBROSCOSTO";
         divRubroscostofiltercontainer_Internalname = "RUBROSCOSTOFILTERCONTAINER";
         lblLblrubrospreciobasefilter_Internalname = "LBLRUBROSPRECIOBASEFILTER";
         edtavCrubrospreciobase_Internalname = "vCRUBROSPRECIOBASE";
         divRubrospreciobasefiltercontainer_Internalname = "RUBROSPRECIOBASEFILTERCONTAINER";
         lblLblmedidasestadofilter_Internalname = "LBLMEDIDASESTADOFILTER";
         cmbavCmedidasestado_Internalname = "vCMEDIDASESTADO";
         divMedidasestadofiltercontainer_Internalname = "MEDIDASESTADOFILTERCONTAINER";
         lblLbltextosidfilter_Internalname = "LBLTEXTOSIDFILTER";
         edtavCtextosid_Internalname = "vCTEXTOSID";
         divTextosidfiltercontainer_Internalname = "TEXTOSIDFILTERCONTAINER";
         lblLblinventarioserialfilter_Internalname = "LBLINVENTARIOSERIALFILTER";
         edtavCinventarioserial_Internalname = "vCINVENTARIOSERIAL";
         divInventarioserialfiltercontainer_Internalname = "INVENTARIOSERIALFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         edtRubrosCosto_Internalname = "RUBROSCOSTO";
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE";
         cmbMedidasEstado_Internalname = "MEDIDASESTADO";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         edtRubrosId_Internalname = "RUBROSID";
         dynMedidasID_Internalname = "MEDIDASID";
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
         dynMedidasID_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         edtMonedaISOSimbolo_Jsonclick = "";
         cmbMedidasEstado_Jsonclick = "";
         edtRubrosPrecioBase_Jsonclick = "";
         edtRubrosCosto_Jsonclick = "";
         edtRubrosCosto_Link = "";
         edtMedidasNombre_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         dynMedidasID.Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         cmbMedidasEstado.Enabled = 0;
         edtRubrosPrecioBase_Enabled = 0;
         edtRubrosCosto_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtavCinventarioserial_Jsonclick = "";
         edtavCinventarioserial_Enabled = 1;
         edtavCinventarioserial_Visible = 1;
         edtavCtextosid_Jsonclick = "";
         edtavCtextosid_Enabled = 1;
         edtavCtextosid_Visible = 1;
         cmbavCmedidasestado_Jsonclick = "";
         cmbavCmedidasestado.Visible = 1;
         cmbavCmedidasestado.Enabled = 1;
         edtavCrubrospreciobase_Jsonclick = "";
         edtavCrubrospreciobase_Enabled = 1;
         edtavCrubrospreciobase_Visible = 1;
         edtavCrubroscosto_Jsonclick = "";
         edtavCrubroscosto_Enabled = 1;
         edtavCrubroscosto_Visible = 1;
         edtavCmedidasnombre_Jsonclick = "";
         edtavCmedidasnombre_Enabled = 1;
         edtavCmedidasnombre_Visible = 1;
         divInventarioserialfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divTextosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMedidasestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRubrospreciobasefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRubroscostofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMedidasnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Rubros Medidas y Precios", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV7cRubrosCosto',fld:'vCRUBROSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cRubrosPrecioBase',fld:'vCRUBROSPRECIOBASE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCmedidasestado'},{av:'AV9cMedidasEstado',fld:'vCMEDIDASESTADO',pic:'',type:'char'},{av:'AV10cTextosId',fld:'vCTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cInventarioSerial',fld:'vCINVENTARIOSERIAL',pic:'ZZZ9',type:'int'},{av:'AV12pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E179C1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK","{handler:'E119C1',iparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK",",oparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCmedidasnombre_Visible',ctrl:'vCMEDIDASNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLRUBROSCOSTOFILTER.CLICK","{handler:'E129C1',iparms:[{av:'divRubroscostofiltercontainer_Class',ctrl:'RUBROSCOSTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRUBROSCOSTOFILTER.CLICK",",oparms:[{av:'divRubroscostofiltercontainer_Class',ctrl:'RUBROSCOSTOFILTERCONTAINER',prop:'Class'},{av:'edtavCrubroscosto_Visible',ctrl:'vCRUBROSCOSTO',prop:'Visible'}]}");
         setEventMetadata("LBLRUBROSPRECIOBASEFILTER.CLICK","{handler:'E139C1',iparms:[{av:'divRubrospreciobasefiltercontainer_Class',ctrl:'RUBROSPRECIOBASEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRUBROSPRECIOBASEFILTER.CLICK",",oparms:[{av:'divRubrospreciobasefiltercontainer_Class',ctrl:'RUBROSPRECIOBASEFILTERCONTAINER',prop:'Class'},{av:'edtavCrubrospreciobase_Visible',ctrl:'vCRUBROSPRECIOBASE',prop:'Visible'}]}");
         setEventMetadata("LBLMEDIDASESTADOFILTER.CLICK","{handler:'E149C1',iparms:[{av:'divMedidasestadofiltercontainer_Class',ctrl:'MEDIDASESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMEDIDASESTADOFILTER.CLICK",",oparms:[{av:'divMedidasestadofiltercontainer_Class',ctrl:'MEDIDASESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCmedidasestado'}]}");
         setEventMetadata("LBLTEXTOSIDFILTER.CLICK","{handler:'E159C1',iparms:[{av:'divTextosidfiltercontainer_Class',ctrl:'TEXTOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTEXTOSIDFILTER.CLICK",",oparms:[{av:'divTextosidfiltercontainer_Class',ctrl:'TEXTOSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtextosid_Visible',ctrl:'vCTEXTOSID',prop:'Visible'}]}");
         setEventMetadata("LBLINVENTARIOSERIALFILTER.CLICK","{handler:'E169C1',iparms:[{av:'divInventarioserialfiltercontainer_Class',ctrl:'INVENTARIOSERIALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVENTARIOSERIALFILTER.CLICK",",oparms:[{av:'divInventarioserialfiltercontainer_Class',ctrl:'INVENTARIOSERIALFILTERCONTAINER',prop:'Class'},{av:'edtavCinventarioserial_Visible',ctrl:'vCINVENTARIOSERIAL',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E209C2',iparms:[{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV7cRubrosCosto',fld:'vCRUBROSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cRubrosPrecioBase',fld:'vCRUBROSPRECIOBASE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCmedidasestado'},{av:'AV9cMedidasEstado',fld:'vCMEDIDASESTADO',pic:'',type:'char'},{av:'AV10cTextosId',fld:'vCTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cInventarioSerial',fld:'vCINVENTARIOSERIAL',pic:'ZZZ9',type:'int'},{av:'AV12pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV7cRubrosCosto',fld:'vCRUBROSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cRubrosPrecioBase',fld:'vCRUBROSPRECIOBASE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCmedidasestado'},{av:'AV9cMedidasEstado',fld:'vCMEDIDASESTADO',pic:'',type:'char'},{av:'AV10cTextosId',fld:'vCTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cInventarioSerial',fld:'vCINVENTARIOSERIAL',pic:'ZZZ9',type:'int'},{av:'AV12pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV7cRubrosCosto',fld:'vCRUBROSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cRubrosPrecioBase',fld:'vCRUBROSPRECIOBASE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCmedidasestado'},{av:'AV9cMedidasEstado',fld:'vCMEDIDASESTADO',pic:'',type:'char'},{av:'AV10cTextosId',fld:'vCTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cInventarioSerial',fld:'vCINVENTARIOSERIAL',pic:'ZZZ9',type:'int'},{av:'AV12pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV7cRubrosCosto',fld:'vCRUBROSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cRubrosPrecioBase',fld:'vCRUBROSPRECIOBASE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavCmedidasestado'},{av:'AV9cMedidasEstado',fld:'vCMEDIDASESTADO',pic:'',type:'char'},{av:'AV10cTextosId',fld:'vCTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cInventarioSerial',fld:'vCINVENTARIOSERIAL',pic:'ZZZ9',type:'int'},{av:'AV12pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CMEDIDASESTADO","{handler:'Validv_Cmedidasestado',iparms:[]");
         setEventMetadata("VALIDV_CMEDIDASESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Medidasid',iparms:[]");
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
         AV6cMedidasNombre = "";
         AV9cMedidasEstado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmedidasnombrefilter_Jsonclick = "";
         TempTags = "";
         lblLblrubroscostofilter_Jsonclick = "";
         lblLblrubrospreciobasefilter_Jsonclick = "";
         lblLblmedidasestadofilter_Jsonclick = "";
         lblLbltextosidfilter_Jsonclick = "";
         lblLblinventarioserialfilter_Jsonclick = "";
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
         A138MedidasNombre = "";
         A139MedidasEstado = "";
         A119MonedaISOSimbolo = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H009C2_A121RubrosId = new short[1] ;
         H009C2_A137MedidasID = new long[1] ;
         H009C2_A138MedidasNombre = new string[] {""} ;
         H009C2_A139MedidasEstado = new string[] {""} ;
         H009C2_n139MedidasEstado = new bool[] {false} ;
         lV6cMedidasNombre = "";
         lV9cMedidasEstado = "";
         H009C3_A118MonedaId = new short[1] ;
         H009C3_A218InventarioSerial = new short[1] ;
         H009C3_A150TextosId = new long[1] ;
         H009C3_n150TextosId = new bool[] {false} ;
         H009C3_A137MedidasID = new long[1] ;
         H009C3_A121RubrosId = new short[1] ;
         H009C3_A119MonedaISOSimbolo = new string[] {""} ;
         H009C3_A139MedidasEstado = new string[] {""} ;
         H009C3_n139MedidasEstado = new bool[] {false} ;
         H009C3_A216RubrosPrecioBase = new decimal[1] ;
         H009C3_A215RubrosCosto = new decimal[1] ;
         H009C3_A138MedidasNombre = new string[] {""} ;
         H009C4_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00q1__default(),
            new Object[][] {
                new Object[] {
               H009C2_A121RubrosId, H009C2_A137MedidasID, H009C2_A138MedidasNombre, H009C2_A139MedidasEstado, H009C2_n139MedidasEstado
               }
               , new Object[] {
               H009C3_A118MonedaId, H009C3_A218InventarioSerial, H009C3_A150TextosId, H009C3_n150TextosId, H009C3_A137MedidasID, H009C3_A121RubrosId, H009C3_A119MonedaISOSimbolo, H009C3_A139MedidasEstado, H009C3_n139MedidasEstado, H009C3_A216RubrosPrecioBase,
               H009C3_A215RubrosCosto, H009C3_A138MedidasNombre
               }
               , new Object[] {
               H009C4_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12pRubrosId ;
      private short wcpOAV12pRubrosId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11cInventarioSerial ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A121RubrosId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A218InventarioSerial ;
      private short A118MonedaId ;
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
      private int edtavCmedidasnombre_Visible ;
      private int edtavCmedidasnombre_Enabled ;
      private int edtavCrubroscosto_Enabled ;
      private int edtavCrubroscosto_Visible ;
      private int edtavCrubrospreciobase_Enabled ;
      private int edtavCrubrospreciobase_Visible ;
      private int edtavCtextosid_Enabled ;
      private int edtavCtextosid_Visible ;
      private int edtavCinventarioserial_Enabled ;
      private int edtavCinventarioserial_Visible ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtMedidasNombre_Enabled ;
      private int edtRubrosCosto_Enabled ;
      private int edtRubrosPrecioBase_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int edtRubrosId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pMedidasID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV10cTextosId ;
      private long A137MedidasID ;
      private long GRID1_nCurrentRecord ;
      private long A150TextosId ;
      private long GRID1_nRecordCount ;
      private decimal AV7cRubrosCosto ;
      private decimal AV8cRubrosPrecioBase ;
      private decimal A215RubrosCosto ;
      private decimal A216RubrosPrecioBase ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divMedidasnombrefiltercontainer_Class ;
      private string divRubroscostofiltercontainer_Class ;
      private string divRubrospreciobasefiltercontainer_Class ;
      private string divMedidasestadofiltercontainer_Class ;
      private string divTextosidfiltercontainer_Class ;
      private string divInventarioserialfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV6cMedidasNombre ;
      private string AV9cMedidasEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divMedidasnombrefiltercontainer_Internalname ;
      private string lblLblmedidasnombrefilter_Internalname ;
      private string lblLblmedidasnombrefilter_Jsonclick ;
      private string edtavCmedidasnombre_Internalname ;
      private string TempTags ;
      private string edtavCmedidasnombre_Jsonclick ;
      private string divRubroscostofiltercontainer_Internalname ;
      private string lblLblrubroscostofilter_Internalname ;
      private string lblLblrubroscostofilter_Jsonclick ;
      private string edtavCrubroscosto_Internalname ;
      private string edtavCrubroscosto_Jsonclick ;
      private string divRubrospreciobasefiltercontainer_Internalname ;
      private string lblLblrubrospreciobasefilter_Internalname ;
      private string lblLblrubrospreciobasefilter_Jsonclick ;
      private string edtavCrubrospreciobase_Internalname ;
      private string edtavCrubrospreciobase_Jsonclick ;
      private string divMedidasestadofiltercontainer_Internalname ;
      private string lblLblmedidasestadofilter_Internalname ;
      private string lblLblmedidasestadofilter_Jsonclick ;
      private string cmbavCmedidasestado_Internalname ;
      private string cmbavCmedidasestado_Jsonclick ;
      private string divTextosidfiltercontainer_Internalname ;
      private string lblLbltextosidfilter_Internalname ;
      private string lblLbltextosidfilter_Jsonclick ;
      private string edtavCtextosid_Internalname ;
      private string edtavCtextosid_Jsonclick ;
      private string divInventarioserialfiltercontainer_Internalname ;
      private string lblLblinventarioserialfilter_Internalname ;
      private string lblLblinventarioserialfilter_Jsonclick ;
      private string edtavCinventarioserial_Internalname ;
      private string edtavCinventarioserial_Jsonclick ;
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
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Internalname ;
      private string edtRubrosCosto_Internalname ;
      private string edtRubrosPrecioBase_Internalname ;
      private string cmbMedidasEstado_Internalname ;
      private string A139MedidasEstado ;
      private string A119MonedaISOSimbolo ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string edtRubrosId_Internalname ;
      private string dynMedidasID_Internalname ;
      private string gxwrpcisep ;
      private string lV6cMedidasNombre ;
      private string lV9cMedidasEstado ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtMedidasNombre_Jsonclick ;
      private string edtRubrosCosto_Link ;
      private string edtRubrosCosto_Jsonclick ;
      private string edtRubrosPrecioBase_Jsonclick ;
      private string GXCCtl ;
      private string cmbMedidasEstado_Jsonclick ;
      private string edtMonedaISOSimbolo_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n139MedidasEstado ;
      private bool gxdyncontrolsrefreshing ;
      private bool n150TextosId ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCmedidasestado ;
      private GXCombobox cmbMedidasEstado ;
      private GXCombobox dynMedidasID ;
      private IDataStoreProvider pr_default ;
      private short[] H009C2_A121RubrosId ;
      private long[] H009C2_A137MedidasID ;
      private string[] H009C2_A138MedidasNombre ;
      private string[] H009C2_A139MedidasEstado ;
      private bool[] H009C2_n139MedidasEstado ;
      private short[] H009C3_A118MonedaId ;
      private short[] H009C3_A218InventarioSerial ;
      private long[] H009C3_A150TextosId ;
      private bool[] H009C3_n150TextosId ;
      private long[] H009C3_A137MedidasID ;
      private short[] H009C3_A121RubrosId ;
      private string[] H009C3_A119MonedaISOSimbolo ;
      private string[] H009C3_A139MedidasEstado ;
      private bool[] H009C3_n139MedidasEstado ;
      private decimal[] H009C3_A216RubrosPrecioBase ;
      private decimal[] H009C3_A215RubrosCosto ;
      private string[] H009C3_A138MedidasNombre ;
      private long[] H009C4_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pMedidasID ;
   }

   public class gx00q1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009C3( IGxContext context ,
                                             string AV6cMedidasNombre ,
                                             decimal AV7cRubrosCosto ,
                                             decimal AV8cRubrosPrecioBase ,
                                             string AV9cMedidasEstado ,
                                             long AV10cTextosId ,
                                             short AV11cInventarioSerial ,
                                             string A138MedidasNombre ,
                                             decimal A215RubrosCosto ,
                                             decimal A216RubrosPrecioBase ,
                                             string A139MedidasEstado ,
                                             long A150TextosId ,
                                             short A218InventarioSerial ,
                                             short AV12pRubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[MonedaId], T1.[InventarioSerial], T1.[TextosId], T1.[MedidasID], T1.[RubrosId], T2.[MonedaISOSimbolo], T1.[MedidasEstado], T1.[RubrosPrecioBase], T1.[RubrosCosto], T1.[MedidasNombre]";
         sFromString = " FROM ([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV12pRubrosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] like @lV6cMedidasNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV7cRubrosCosto) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] >= @AV7cRubrosCosto)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cRubrosPrecioBase) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] >= @AV8cRubrosPrecioBase)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMedidasEstado)) )
         {
            AddWhere(sWhereString, "(T1.[MedidasEstado] like @lV9cMedidasEstado)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV10cTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV10cTextosId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV11cInventarioSerial) )
         {
            AddWhere(sWhereString, "(T1.[InventarioSerial] >= @AV11cInventarioSerial)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY T1.[RubrosId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009C4( IGxContext context ,
                                             string AV6cMedidasNombre ,
                                             decimal AV7cRubrosCosto ,
                                             decimal AV8cRubrosPrecioBase ,
                                             string AV9cMedidasEstado ,
                                             long AV10cTextosId ,
                                             short AV11cInventarioSerial ,
                                             string A138MedidasNombre ,
                                             decimal A215RubrosCosto ,
                                             decimal A216RubrosPrecioBase ,
                                             string A139MedidasEstado ,
                                             long A150TextosId ,
                                             short A218InventarioSerial ,
                                             short AV12pRubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV12pRubrosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] like @lV6cMedidasNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV7cRubrosCosto) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] >= @AV7cRubrosCosto)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cRubrosPrecioBase) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] >= @AV8cRubrosPrecioBase)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMedidasEstado)) )
         {
            AddWhere(sWhereString, "(T1.[MedidasEstado] like @lV9cMedidasEstado)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV10cTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV10cTextosId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV11cInventarioSerial) )
         {
            AddWhere(sWhereString, "(T1.[InventarioSerial] >= @AV11cInventarioSerial)");
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
               case 1 :
                     return conditional_H009C3(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
               case 2 :
                     return conditional_H009C4(context, (string)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH009C2;
          prmH009C2 = new Object[] {
          };
          Object[] prmH009C3;
          prmH009C3 = new Object[] {
          new ParDef("@AV12pRubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV6cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@AV7cRubrosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV8cRubrosPrecioBase",GXType.Decimal,18,2) ,
          new ParDef("@lV9cMedidasEstado",GXType.NChar,3,0) ,
          new ParDef("@AV10cTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11cInventarioSerial",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009C4;
          prmH009C4 = new Object[] {
          new ParDef("@AV12pRubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV6cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@AV7cRubrosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV8cRubrosPrecioBase",GXType.Decimal,18,2) ,
          new ParDef("@lV9cMedidasEstado",GXType.NChar,3,0) ,
          new ParDef("@AV10cTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11cInventarioSerial",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009C2", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [MedidasEstado] <> 'DES' ORDER BY [MedidasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C4,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 50);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

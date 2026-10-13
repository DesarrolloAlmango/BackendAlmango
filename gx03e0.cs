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
   public class gx03e0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03e0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03e0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pCapacidadProdId )
      {
         this.AV13pCapacidadProdId = 0 ;
         ExecutePrivate();
         aP0_pCapacidadProdId=this.AV13pCapacidadProdId;
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
            gxfirstwebparm = GetFirstPar( "pCapacidadProdId");
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
               gxfirstwebparm = GetFirstPar( "pCapacidadProdId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCapacidadProdId");
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
               AV13pCapacidadProdId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pCapacidadProdId", StringUtil.LTrimStr( (decimal)(AV13pCapacidadProdId), 18, 0));
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
         AV6cCapacidadProdId = (long)(Math.Round(NumberUtil.Val( GetPar( "cCapacidadProdId"), "."), 18, MidpointRounding.ToEven));
         AV7cCapacidadProdTotal = NumberUtil.Val( GetPar( "cCapacidadProdTotal"), ".");
         AV8cDepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV9cCapacidadProdDeptoPercent = NumberUtil.Val( GetPar( "cCapacidadProdDeptoPercent"), ".");
         AV10cCapacidadProdDeptoValor = NumberUtil.Val( GetPar( "cCapacidadProdDeptoValor"), ".");
         AV12cRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "cRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV15cCapacidadProdRubroPercent = NumberUtil.Val( GetPar( "cCapacidadProdRubroPercent"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent) ;
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
         PAGU2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTGU2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03e0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCapacidadProdId,18,0))}, new string[] {"pCapacidadProdId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODTOTAL", StringUtil.LTrim( StringUtil.NToC( AV7cCapacidadProdTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODDEPTOPERCENT", StringUtil.LTrim( StringUtil.NToC( AV9cCapacidadProdDeptoPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODDEPTOVALOR", StringUtil.LTrim( StringUtil.NToC( AV10cCapacidadProdDeptoValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODRUBROPERCENT", StringUtil.LTrim( StringUtil.NToC( AV15cCapacidadProdRubroPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCAPACIDADPRODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODIDFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadprodidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODTOTALFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadprodtotalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODDEPTOPERCENTFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproddeptopercentfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODDEPTOVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproddeptovalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RUBROSIDFILTERCONTAINER_Class", StringUtil.RTrim( divRubrosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODRUBROPERCENTFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadprodrubropercentfiltercontainer_Class));
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
            WEGU2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTGU2( ) ;
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
         return formatLink("gx03e0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCapacidadProdId,18,0))}, new string[] {"pCapacidadProdId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03E0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Capacidad Productiva", "") ;
      }

      protected void WBGU0( )
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
            GxWebStd.gx_div_start( context, divCapacidadprodidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadprodidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadprodidfilter_Internalname, context.GetMessage( "Capacidad Prod Id", ""), "", "", lblLblcapacidadprodidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadprodid_Internalname, context.GetMessage( "Capacidad Prod Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadprodid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadprodid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCapacidadProdId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cCapacidadProdId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadprodid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadprodid_Visible, edtavCcapacidadprodid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadprodtotalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadprodtotalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadprodtotalfilter_Internalname, context.GetMessage( "Capacidad Prod Total", ""), "", "", lblLblcapacidadprodtotalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadprodtotal_Internalname, context.GetMessage( "Capacidad Prod Total", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadprodtotal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7cCapacidadProdTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadprodtotal_Enabled!=0) ? context.localUtil.Format( AV7cCapacidadProdTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV7cCapacidadProdTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadprodtotal_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadprodtotal_Visible, edtavCcapacidadprodtotal_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoidfilter_Internalname, context.GetMessage( "Departamento", ""), "", "", lblLbldepartamentoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoid_Visible, edtavCdepartamentoid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproddeptopercentfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproddeptopercentfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproddeptopercentfilter_Internalname, context.GetMessage( "Capacidad Prod Depto Percent", ""), "", "", lblLblcapacidadproddeptopercentfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproddeptopercent_Internalname, context.GetMessage( "Capacidad Prod Depto Percent", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproddeptopercent_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cCapacidadProdDeptoPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproddeptopercent_Enabled!=0) ? context.localUtil.Format( AV9cCapacidadProdDeptoPercent, "ZZ9.99") : context.localUtil.Format( AV9cCapacidadProdDeptoPercent, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproddeptopercent_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproddeptopercent_Visible, edtavCcapacidadproddeptopercent_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproddeptovalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproddeptovalorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproddeptovalorfilter_Internalname, context.GetMessage( "Capacidad Prod Depto Valor", ""), "", "", lblLblcapacidadproddeptovalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproddeptovalor_Internalname, context.GetMessage( "Capacidad Prod Depto Valor", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproddeptovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cCapacidadProdDeptoValor, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproddeptovalor_Enabled!=0) ? context.localUtil.Format( AV10cCapacidadProdDeptoValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV10cCapacidadProdDeptoValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproddeptovalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproddeptovalor_Visible, edtavCcapacidadproddeptovalor_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_div_start( context, divRubrosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRubrosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrubrosidfilter_Internalname, context.GetMessage( "Rubros Identificador ", ""), "", "", lblLblrubrosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrubrosid_Internalname, context.GetMessage( "Rubros Identificador ", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCrubrosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cRubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cRubrosId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrubrosid_Visible, edtavCrubrosid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadprodrubropercentfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadprodrubropercentfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadprodrubropercentfilter_Internalname, context.GetMessage( "Capacidad Prod Rubro Percent", ""), "", "", lblLblcapacidadprodrubropercentfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17gu1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03E0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadprodrubropercent_Internalname, context.GetMessage( "Capacidad Prod Rubro Percent", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadprodrubropercent_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15cCapacidadProdRubroPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadprodrubropercent_Enabled!=0) ? context.localUtil.Format( AV15cCapacidadProdRubroPercent, "ZZ9.99") : context.localUtil.Format( AV15cCapacidadProdRubroPercent, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadprodrubropercent_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadprodrubropercent_Visible, edtavCcapacidadprodrubropercent_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03E0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18gu1_client"+"'", TempTags, "", 2, "HLP_Gx03E0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03E0.htm");
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

      protected void STARTGU2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Capacidad Productiva", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPGU0( ) ;
      }

      protected void WSGU2( )
      {
         STARTGU2( ) ;
         EVTGU2( ) ;
      }

      protected void EVTGU2( )
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
                              A804CapacidadProdId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProdId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A805CapacidadProdTotal = context.localUtil.CToN( cgiGet( edtCapacidadProdTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A806CapacidadProdDeptoPercent = context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A807CapacidadProdDeptoValor = context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19GU2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20GU2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccapacidadprodid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCapacidadProdId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadprodtotal Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODTOTAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV7cCapacidadProdTotal )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cDepartamentoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproddeptopercent Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODDEPTOPERCENT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cCapacidadProdDeptoPercent )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproddeptovalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODDEPTOVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cCapacidadProdDeptoValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crubrosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cRubrosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadprodrubropercent Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODRUBROPERCENT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV15cCapacidadProdRubroPercent )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21GU2 ();
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

      protected void WEGU2( )
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

      protected void PAGU2( )
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
                                        long AV6cCapacidadProdId ,
                                        decimal AV7cCapacidadProdTotal ,
                                        long AV8cDepartamentoId ,
                                        decimal AV9cCapacidadProdDeptoPercent ,
                                        decimal AV10cCapacidadProdDeptoValor ,
                                        short AV12cRubrosId ,
                                        decimal AV15cCapacidadProdRubroPercent )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFGU2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CAPACIDADPRODID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A804CapacidadProdId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A804CapacidadProdId), 18, 0, ".", "")));
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
         RFGU2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFGU2( )
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
                                                 AV7cCapacidadProdTotal ,
                                                 AV8cDepartamentoId ,
                                                 AV9cCapacidadProdDeptoPercent ,
                                                 AV10cCapacidadProdDeptoValor ,
                                                 AV12cRubrosId ,
                                                 AV15cCapacidadProdRubroPercent ,
                                                 A805CapacidadProdTotal ,
                                                 A112DepartamentoId ,
                                                 A806CapacidadProdDeptoPercent ,
                                                 A807CapacidadProdDeptoValor ,
                                                 A121RubrosId ,
                                                 A809CapacidadProdRubroPercent ,
                                                 AV6cCapacidadProdId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H00GU2 */
            pr_default.execute(0, new Object[] {AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A809CapacidadProdRubroPercent = H00GU2_A809CapacidadProdRubroPercent[0];
               A121RubrosId = H00GU2_A121RubrosId[0];
               A807CapacidadProdDeptoValor = H00GU2_A807CapacidadProdDeptoValor[0];
               A806CapacidadProdDeptoPercent = H00GU2_A806CapacidadProdDeptoPercent[0];
               A112DepartamentoId = H00GU2_A112DepartamentoId[0];
               A805CapacidadProdTotal = H00GU2_A805CapacidadProdTotal[0];
               A804CapacidadProdId = H00GU2_A804CapacidadProdId[0];
               /* Execute user event: Load */
               E20GU2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBGU0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGU2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CAPACIDADPRODID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A804CapacidadProdId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cCapacidadProdTotal ,
                                              AV8cDepartamentoId ,
                                              AV9cCapacidadProdDeptoPercent ,
                                              AV10cCapacidadProdDeptoValor ,
                                              AV12cRubrosId ,
                                              AV15cCapacidadProdRubroPercent ,
                                              A805CapacidadProdTotal ,
                                              A112DepartamentoId ,
                                              A806CapacidadProdDeptoPercent ,
                                              A807CapacidadProdDeptoValor ,
                                              A121RubrosId ,
                                              A809CapacidadProdRubroPercent ,
                                              AV6cCapacidadProdId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00GU3 */
         pr_default.execute(1, new Object[] {AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent});
         GRID1_nRecordCount = H00GU3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProdId, AV7cCapacidadProdTotal, AV8cDepartamentoId, AV9cCapacidadProdDeptoPercent, AV10cCapacidadProdDeptoValor, AV12cRubrosId, AV15cCapacidadProdRubroPercent) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCapacidadProdId_Enabled = 0;
         edtCapacidadProdTotal_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtCapacidadProdDeptoPercent_Enabled = 0;
         edtCapacidadProdDeptoValor_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPGU0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19GU2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadprodid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadprodid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODID");
               GX_FocusControl = edtavCcapacidadprodid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCapacidadProdId = 0;
               AssignAttri("", false, "AV6cCapacidadProdId", StringUtil.LTrimStr( (decimal)(AV6cCapacidadProdId), 18, 0));
            }
            else
            {
               AV6cCapacidadProdId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcapacidadprodid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCapacidadProdId", StringUtil.LTrimStr( (decimal)(AV6cCapacidadProdId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadprodtotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadprodtotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODTOTAL");
               GX_FocusControl = edtavCcapacidadprodtotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCapacidadProdTotal = 0;
               AssignAttri("", false, "AV7cCapacidadProdTotal", StringUtil.LTrimStr( AV7cCapacidadProdTotal, 18, 2));
            }
            else
            {
               AV7cCapacidadProdTotal = context.localUtil.CToN( cgiGet( edtavCcapacidadprodtotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV7cCapacidadProdTotal", StringUtil.LTrimStr( AV7cCapacidadProdTotal, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOID");
               GX_FocusControl = edtavCdepartamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cDepartamentoId = 0;
               AssignAttri("", false, "AV8cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8cDepartamentoId), 18, 0));
            }
            else
            {
               AV8cDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8cDepartamentoId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproddeptopercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproddeptopercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODDEPTOPERCENT");
               GX_FocusControl = edtavCcapacidadproddeptopercent_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cCapacidadProdDeptoPercent = 0;
               AssignAttri("", false, "AV9cCapacidadProdDeptoPercent", StringUtil.LTrimStr( AV9cCapacidadProdDeptoPercent, 6, 2));
            }
            else
            {
               AV9cCapacidadProdDeptoPercent = context.localUtil.CToN( cgiGet( edtavCcapacidadproddeptopercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV9cCapacidadProdDeptoPercent", StringUtil.LTrimStr( AV9cCapacidadProdDeptoPercent, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproddeptovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproddeptovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODDEPTOVALOR");
               GX_FocusControl = edtavCcapacidadproddeptovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cCapacidadProdDeptoValor = 0;
               AssignAttri("", false, "AV10cCapacidadProdDeptoValor", StringUtil.LTrimStr( AV10cCapacidadProdDeptoValor, 18, 2));
            }
            else
            {
               AV10cCapacidadProdDeptoValor = context.localUtil.CToN( cgiGet( edtavCcapacidadproddeptovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10cCapacidadProdDeptoValor", StringUtil.LTrimStr( AV10cCapacidadProdDeptoValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRUBROSID");
               GX_FocusControl = edtavCrubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cRubrosId = 0;
               AssignAttri("", false, "AV12cRubrosId", StringUtil.LTrimStr( (decimal)(AV12cRubrosId), 4, 0));
            }
            else
            {
               AV12cRubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cRubrosId", StringUtil.LTrimStr( (decimal)(AV12cRubrosId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadprodrubropercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadprodrubropercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODRUBROPERCENT");
               GX_FocusControl = edtavCcapacidadprodrubropercent_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cCapacidadProdRubroPercent = 0;
               AssignAttri("", false, "AV15cCapacidadProdRubroPercent", StringUtil.LTrimStr( AV15cCapacidadProdRubroPercent, 6, 2));
            }
            else
            {
               AV15cCapacidadProdRubroPercent = context.localUtil.CToN( cgiGet( edtavCcapacidadprodrubropercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV15cCapacidadProdRubroPercent", StringUtil.LTrimStr( AV15cCapacidadProdRubroPercent, 6, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCapacidadProdId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODTOTAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV7cCapacidadProdTotal )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cDepartamentoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODDEPTOPERCENT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cCapacidadProdDeptoPercent )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODDEPTOVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cCapacidadProdDeptoValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cRubrosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODRUBROPERCENT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV15cCapacidadProdRubroPercent )
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
         E19GU2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19GU2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Capacidad Productiva", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20GU2( )
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
         E21GU2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21GU2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCapacidadProdId = A804CapacidadProdId;
         AssignAttri("", false, "AV13pCapacidadProdId", StringUtil.LTrimStr( (decimal)(AV13pCapacidadProdId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pCapacidadProdId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCapacidadProdId"});
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
         AV13pCapacidadProdId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pCapacidadProdId", StringUtil.LTrimStr( (decimal)(AV13pCapacidadProdId), 18, 0));
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
         PAGU2( ) ;
         WSGU2( ) ;
         WEGU2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021262280", true, true, false);
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
         context.AddJavascriptSource("gx03e0.js", "?202673021262280", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCapacidadProdId_Internalname = "CAPACIDADPRODID_"+sGXsfl_84_idx;
         edtCapacidadProdTotal_Internalname = "CAPACIDADPRODTOTAL_"+sGXsfl_84_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_84_idx;
         edtCapacidadProdDeptoPercent_Internalname = "CAPACIDADPRODDEPTOPERCENT_"+sGXsfl_84_idx;
         edtCapacidadProdDeptoValor_Internalname = "CAPACIDADPRODDEPTOVALOR_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCapacidadProdId_Internalname = "CAPACIDADPRODID_"+sGXsfl_84_fel_idx;
         edtCapacidadProdTotal_Internalname = "CAPACIDADPRODTOTAL_"+sGXsfl_84_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_84_fel_idx;
         edtCapacidadProdDeptoPercent_Internalname = "CAPACIDADPRODDEPTOPERCENT_"+sGXsfl_84_fel_idx;
         edtCapacidadProdDeptoValor_Internalname = "CAPACIDADPRODDEPTOVALOR_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBGU0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A804CapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProdId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A804CapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A804CapacidadProdId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCapacidadProdId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCapacidadProdTotal_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A804CapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtCapacidadProdTotal_Internalname, "Link", edtCapacidadProdTotal_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProdTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A805CapacidadProdTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A805CapacidadProdTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCapacidadProdTotal_Link,(string)"",(string)"",(string)"",(string)edtCapacidadProdTotal_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)22,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Total",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProdDeptoPercent_Internalname,StringUtil.LTrim( StringUtil.NToC( A806CapacidadProdDeptoPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A806CapacidadProdDeptoPercent, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCapacidadProdDeptoPercent_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProdDeptoValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A807CapacidadProdDeptoValor, 22, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A807CapacidadProdDeptoValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCapacidadProdDeptoValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)22,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Total",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesGU2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Prod Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Prod Total", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Depto Percent", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Depto Valor", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A804CapacidadProdId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A805CapacidadProdTotal, 22, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCapacidadProdTotal_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A806CapacidadProdDeptoPercent, 6, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A807CapacidadProdDeptoValor, 22, 2, ".", ""))));
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
         lblLblcapacidadprodidfilter_Internalname = "LBLCAPACIDADPRODIDFILTER";
         edtavCcapacidadprodid_Internalname = "vCCAPACIDADPRODID";
         divCapacidadprodidfiltercontainer_Internalname = "CAPACIDADPRODIDFILTERCONTAINER";
         lblLblcapacidadprodtotalfilter_Internalname = "LBLCAPACIDADPRODTOTALFILTER";
         edtavCcapacidadprodtotal_Internalname = "vCCAPACIDADPRODTOTAL";
         divCapacidadprodtotalfiltercontainer_Internalname = "CAPACIDADPRODTOTALFILTERCONTAINER";
         lblLbldepartamentoidfilter_Internalname = "LBLDEPARTAMENTOIDFILTER";
         edtavCdepartamentoid_Internalname = "vCDEPARTAMENTOID";
         divDepartamentoidfiltercontainer_Internalname = "DEPARTAMENTOIDFILTERCONTAINER";
         lblLblcapacidadproddeptopercentfilter_Internalname = "LBLCAPACIDADPRODDEPTOPERCENTFILTER";
         edtavCcapacidadproddeptopercent_Internalname = "vCCAPACIDADPRODDEPTOPERCENT";
         divCapacidadproddeptopercentfiltercontainer_Internalname = "CAPACIDADPRODDEPTOPERCENTFILTERCONTAINER";
         lblLblcapacidadproddeptovalorfilter_Internalname = "LBLCAPACIDADPRODDEPTOVALORFILTER";
         edtavCcapacidadproddeptovalor_Internalname = "vCCAPACIDADPRODDEPTOVALOR";
         divCapacidadproddeptovalorfiltercontainer_Internalname = "CAPACIDADPRODDEPTOVALORFILTERCONTAINER";
         lblLblrubrosidfilter_Internalname = "LBLRUBROSIDFILTER";
         edtavCrubrosid_Internalname = "vCRUBROSID";
         divRubrosidfiltercontainer_Internalname = "RUBROSIDFILTERCONTAINER";
         lblLblcapacidadprodrubropercentfilter_Internalname = "LBLCAPACIDADPRODRUBROPERCENTFILTER";
         edtavCcapacidadprodrubropercent_Internalname = "vCCAPACIDADPRODRUBROPERCENT";
         divCapacidadprodrubropercentfiltercontainer_Internalname = "CAPACIDADPRODRUBROPERCENTFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCapacidadProdId_Internalname = "CAPACIDADPRODID";
         edtCapacidadProdTotal_Internalname = "CAPACIDADPRODTOTAL";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtCapacidadProdDeptoPercent_Internalname = "CAPACIDADPRODDEPTOPERCENT";
         edtCapacidadProdDeptoValor_Internalname = "CAPACIDADPRODDEPTOVALOR";
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
         edtCapacidadProdDeptoValor_Jsonclick = "";
         edtCapacidadProdDeptoPercent_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtCapacidadProdTotal_Jsonclick = "";
         edtCapacidadProdTotal_Link = "";
         edtCapacidadProdId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCapacidadProdDeptoValor_Enabled = 0;
         edtCapacidadProdDeptoPercent_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtCapacidadProdTotal_Enabled = 0;
         edtCapacidadProdId_Enabled = 0;
         edtavCcapacidadprodrubropercent_Jsonclick = "";
         edtavCcapacidadprodrubropercent_Enabled = 1;
         edtavCcapacidadprodrubropercent_Visible = 1;
         edtavCrubrosid_Jsonclick = "";
         edtavCrubrosid_Enabled = 1;
         edtavCrubrosid_Visible = 1;
         edtavCcapacidadproddeptovalor_Jsonclick = "";
         edtavCcapacidadproddeptovalor_Enabled = 1;
         edtavCcapacidadproddeptovalor_Visible = 1;
         edtavCcapacidadproddeptopercent_Jsonclick = "";
         edtavCcapacidadproddeptopercent_Enabled = 1;
         edtavCcapacidadproddeptopercent_Visible = 1;
         edtavCdepartamentoid_Jsonclick = "";
         edtavCdepartamentoid_Enabled = 1;
         edtavCdepartamentoid_Visible = 1;
         edtavCcapacidadprodtotal_Jsonclick = "";
         edtavCcapacidadprodtotal_Enabled = 1;
         edtavCcapacidadprodtotal_Visible = 1;
         edtavCcapacidadprodid_Jsonclick = "";
         edtavCcapacidadprodid_Enabled = 1;
         edtavCcapacidadprodid_Visible = 1;
         divCapacidadprodrubropercentfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRubrosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproddeptovalorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproddeptopercentfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadprodtotalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadprodidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Capacidad Productiva", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProdId',fld:'vCCAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cCapacidadProdTotal',fld:'vCCAPACIDADPRODTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProdDeptoPercent',fld:'vCCAPACIDADPRODDEPTOPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV10cCapacidadProdDeptoValor',fld:'vCCAPACIDADPRODDEPTOVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV12cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV15cCapacidadProdRubroPercent',fld:'vCCAPACIDADPRODRUBROPERCENT',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18GU1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCAPACIDADPRODIDFILTER.CLICK","{handler:'E11GU1',iparms:[{av:'divCapacidadprodidfiltercontainer_Class',ctrl:'CAPACIDADPRODIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODIDFILTER.CLICK",",oparms:[{av:'divCapacidadprodidfiltercontainer_Class',ctrl:'CAPACIDADPRODIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadprodid_Visible',ctrl:'vCCAPACIDADPRODID',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODTOTALFILTER.CLICK","{handler:'E12GU1',iparms:[{av:'divCapacidadprodtotalfiltercontainer_Class',ctrl:'CAPACIDADPRODTOTALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODTOTALFILTER.CLICK",",oparms:[{av:'divCapacidadprodtotalfiltercontainer_Class',ctrl:'CAPACIDADPRODTOTALFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadprodtotal_Visible',ctrl:'vCCAPACIDADPRODTOTAL',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK","{handler:'E13GU1',iparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK",",oparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoid_Visible',ctrl:'vCDEPARTAMENTOID',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODDEPTOPERCENTFILTER.CLICK","{handler:'E14GU1',iparms:[{av:'divCapacidadproddeptopercentfiltercontainer_Class',ctrl:'CAPACIDADPRODDEPTOPERCENTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODDEPTOPERCENTFILTER.CLICK",",oparms:[{av:'divCapacidadproddeptopercentfiltercontainer_Class',ctrl:'CAPACIDADPRODDEPTOPERCENTFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproddeptopercent_Visible',ctrl:'vCCAPACIDADPRODDEPTOPERCENT',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODDEPTOVALORFILTER.CLICK","{handler:'E15GU1',iparms:[{av:'divCapacidadproddeptovalorfiltercontainer_Class',ctrl:'CAPACIDADPRODDEPTOVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODDEPTOVALORFILTER.CLICK",",oparms:[{av:'divCapacidadproddeptovalorfiltercontainer_Class',ctrl:'CAPACIDADPRODDEPTOVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproddeptovalor_Visible',ctrl:'vCCAPACIDADPRODDEPTOVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLRUBROSIDFILTER.CLICK","{handler:'E16GU1',iparms:[{av:'divRubrosidfiltercontainer_Class',ctrl:'RUBROSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRUBROSIDFILTER.CLICK",",oparms:[{av:'divRubrosidfiltercontainer_Class',ctrl:'RUBROSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCrubrosid_Visible',ctrl:'vCRUBROSID',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODRUBROPERCENTFILTER.CLICK","{handler:'E17GU1',iparms:[{av:'divCapacidadprodrubropercentfiltercontainer_Class',ctrl:'CAPACIDADPRODRUBROPERCENTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODRUBROPERCENTFILTER.CLICK",",oparms:[{av:'divCapacidadprodrubropercentfiltercontainer_Class',ctrl:'CAPACIDADPRODRUBROPERCENTFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadprodrubropercent_Visible',ctrl:'vCCAPACIDADPRODRUBROPERCENT',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21GU2',iparms:[{av:'A804CapacidadProdId',fld:'CAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCapacidadProdId',fld:'vPCAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProdId',fld:'vCCAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cCapacidadProdTotal',fld:'vCCAPACIDADPRODTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProdDeptoPercent',fld:'vCCAPACIDADPRODDEPTOPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV10cCapacidadProdDeptoValor',fld:'vCCAPACIDADPRODDEPTOVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV12cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV15cCapacidadProdRubroPercent',fld:'vCCAPACIDADPRODRUBROPERCENT',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProdId',fld:'vCCAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cCapacidadProdTotal',fld:'vCCAPACIDADPRODTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProdDeptoPercent',fld:'vCCAPACIDADPRODDEPTOPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV10cCapacidadProdDeptoValor',fld:'vCCAPACIDADPRODDEPTOVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV12cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV15cCapacidadProdRubroPercent',fld:'vCCAPACIDADPRODRUBROPERCENT',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProdId',fld:'vCCAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cCapacidadProdTotal',fld:'vCCAPACIDADPRODTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProdDeptoPercent',fld:'vCCAPACIDADPRODDEPTOPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV10cCapacidadProdDeptoValor',fld:'vCCAPACIDADPRODDEPTOVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV12cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV15cCapacidadProdRubroPercent',fld:'vCCAPACIDADPRODRUBROPERCENT',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProdId',fld:'vCCAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cCapacidadProdTotal',fld:'vCCAPACIDADPRODTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProdDeptoPercent',fld:'vCCAPACIDADPRODDEPTOPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV10cCapacidadProdDeptoValor',fld:'vCCAPACIDADPRODDEPTOVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV12cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV15cCapacidadProdRubroPercent',fld:'vCCAPACIDADPRODRUBROPERCENT',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Capacidadproddeptovalor',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcapacidadprodidfilter_Jsonclick = "";
         TempTags = "";
         lblLblcapacidadprodtotalfilter_Jsonclick = "";
         lblLbldepartamentoidfilter_Jsonclick = "";
         lblLblcapacidadproddeptopercentfilter_Jsonclick = "";
         lblLblcapacidadproddeptovalorfilter_Jsonclick = "";
         lblLblrubrosidfilter_Jsonclick = "";
         lblLblcapacidadprodrubropercentfilter_Jsonclick = "";
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
         H00GU2_A809CapacidadProdRubroPercent = new decimal[1] ;
         H00GU2_A121RubrosId = new short[1] ;
         H00GU2_A807CapacidadProdDeptoValor = new decimal[1] ;
         H00GU2_A806CapacidadProdDeptoPercent = new decimal[1] ;
         H00GU2_A112DepartamentoId = new long[1] ;
         H00GU2_A805CapacidadProdTotal = new decimal[1] ;
         H00GU2_A804CapacidadProdId = new long[1] ;
         H00GU3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03e0__default(),
            new Object[][] {
                new Object[] {
               H00GU2_A809CapacidadProdRubroPercent, H00GU2_A121RubrosId, H00GU2_A807CapacidadProdDeptoValor, H00GU2_A806CapacidadProdDeptoPercent, H00GU2_A112DepartamentoId, H00GU2_A805CapacidadProdTotal, H00GU2_A804CapacidadProdId
               }
               , new Object[] {
               H00GU3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12cRubrosId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A121RubrosId ;
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
      private int edtavCcapacidadprodid_Enabled ;
      private int edtavCcapacidadprodid_Visible ;
      private int edtavCcapacidadprodtotal_Enabled ;
      private int edtavCcapacidadprodtotal_Visible ;
      private int edtavCdepartamentoid_Enabled ;
      private int edtavCdepartamentoid_Visible ;
      private int edtavCcapacidadproddeptopercent_Enabled ;
      private int edtavCcapacidadproddeptopercent_Visible ;
      private int edtavCcapacidadproddeptovalor_Enabled ;
      private int edtavCcapacidadproddeptovalor_Visible ;
      private int edtavCrubrosid_Enabled ;
      private int edtavCrubrosid_Visible ;
      private int edtavCcapacidadprodrubropercent_Enabled ;
      private int edtavCcapacidadprodrubropercent_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCapacidadProdId_Enabled ;
      private int edtCapacidadProdTotal_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtCapacidadProdDeptoPercent_Enabled ;
      private int edtCapacidadProdDeptoValor_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pCapacidadProdId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cCapacidadProdId ;
      private long AV8cDepartamentoId ;
      private long A804CapacidadProdId ;
      private long A112DepartamentoId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV7cCapacidadProdTotal ;
      private decimal AV9cCapacidadProdDeptoPercent ;
      private decimal AV10cCapacidadProdDeptoValor ;
      private decimal AV15cCapacidadProdRubroPercent ;
      private decimal A805CapacidadProdTotal ;
      private decimal A806CapacidadProdDeptoPercent ;
      private decimal A807CapacidadProdDeptoValor ;
      private decimal A809CapacidadProdRubroPercent ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCapacidadprodidfiltercontainer_Class ;
      private string divCapacidadprodtotalfiltercontainer_Class ;
      private string divDepartamentoidfiltercontainer_Class ;
      private string divCapacidadproddeptopercentfiltercontainer_Class ;
      private string divCapacidadproddeptovalorfiltercontainer_Class ;
      private string divRubrosidfiltercontainer_Class ;
      private string divCapacidadprodrubropercentfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCapacidadprodidfiltercontainer_Internalname ;
      private string lblLblcapacidadprodidfilter_Internalname ;
      private string lblLblcapacidadprodidfilter_Jsonclick ;
      private string edtavCcapacidadprodid_Internalname ;
      private string TempTags ;
      private string edtavCcapacidadprodid_Jsonclick ;
      private string divCapacidadprodtotalfiltercontainer_Internalname ;
      private string lblLblcapacidadprodtotalfilter_Internalname ;
      private string lblLblcapacidadprodtotalfilter_Jsonclick ;
      private string edtavCcapacidadprodtotal_Internalname ;
      private string edtavCcapacidadprodtotal_Jsonclick ;
      private string divDepartamentoidfiltercontainer_Internalname ;
      private string lblLbldepartamentoidfilter_Internalname ;
      private string lblLbldepartamentoidfilter_Jsonclick ;
      private string edtavCdepartamentoid_Internalname ;
      private string edtavCdepartamentoid_Jsonclick ;
      private string divCapacidadproddeptopercentfiltercontainer_Internalname ;
      private string lblLblcapacidadproddeptopercentfilter_Internalname ;
      private string lblLblcapacidadproddeptopercentfilter_Jsonclick ;
      private string edtavCcapacidadproddeptopercent_Internalname ;
      private string edtavCcapacidadproddeptopercent_Jsonclick ;
      private string divCapacidadproddeptovalorfiltercontainer_Internalname ;
      private string lblLblcapacidadproddeptovalorfilter_Internalname ;
      private string lblLblcapacidadproddeptovalorfilter_Jsonclick ;
      private string edtavCcapacidadproddeptovalor_Internalname ;
      private string edtavCcapacidadproddeptovalor_Jsonclick ;
      private string divRubrosidfiltercontainer_Internalname ;
      private string lblLblrubrosidfilter_Internalname ;
      private string lblLblrubrosidfilter_Jsonclick ;
      private string edtavCrubrosid_Internalname ;
      private string edtavCrubrosid_Jsonclick ;
      private string divCapacidadprodrubropercentfiltercontainer_Internalname ;
      private string lblLblcapacidadprodrubropercentfilter_Internalname ;
      private string lblLblcapacidadprodrubropercentfilter_Jsonclick ;
      private string edtavCcapacidadprodrubropercent_Internalname ;
      private string edtavCcapacidadprodrubropercent_Jsonclick ;
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
      private string edtCapacidadProdId_Internalname ;
      private string edtCapacidadProdTotal_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtCapacidadProdDeptoPercent_Internalname ;
      private string edtCapacidadProdDeptoValor_Internalname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCapacidadProdId_Jsonclick ;
      private string edtCapacidadProdTotal_Link ;
      private string edtCapacidadProdTotal_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtCapacidadProdDeptoPercent_Jsonclick ;
      private string edtCapacidadProdDeptoValor_Jsonclick ;
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
      private string AV16Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00GU2_A809CapacidadProdRubroPercent ;
      private short[] H00GU2_A121RubrosId ;
      private decimal[] H00GU2_A807CapacidadProdDeptoValor ;
      private decimal[] H00GU2_A806CapacidadProdDeptoPercent ;
      private long[] H00GU2_A112DepartamentoId ;
      private decimal[] H00GU2_A805CapacidadProdTotal ;
      private long[] H00GU2_A804CapacidadProdId ;
      private long[] H00GU3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pCapacidadProdId ;
   }

   public class gx03e0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00GU2( IGxContext context ,
                                             decimal AV7cCapacidadProdTotal ,
                                             long AV8cDepartamentoId ,
                                             decimal AV9cCapacidadProdDeptoPercent ,
                                             decimal AV10cCapacidadProdDeptoValor ,
                                             short AV12cRubrosId ,
                                             decimal AV15cCapacidadProdRubroPercent ,
                                             decimal A805CapacidadProdTotal ,
                                             long A112DepartamentoId ,
                                             decimal A806CapacidadProdDeptoPercent ,
                                             decimal A807CapacidadProdDeptoValor ,
                                             short A121RubrosId ,
                                             decimal A809CapacidadProdRubroPercent ,
                                             long AV6cCapacidadProdId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CapacidadProdRubroPercent], [RubrosId], [CapacidadProdDeptoValor], [CapacidadProdDeptoPercent], [DepartamentoId], [CapacidadProdTotal], [CapacidadProdId]";
         sFromString = " FROM [CapacidadProductiva]";
         sOrderString = "";
         AddWhere(sWhereString, "([CapacidadProdId] >= @AV6cCapacidadProdId)");
         if ( ! (Convert.ToDecimal(0)==AV7cCapacidadProdTotal) )
         {
            AddWhere(sWhereString, "([CapacidadProdTotal] >= @AV7cCapacidadProdTotal)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV8cDepartamentoId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cCapacidadProdDeptoPercent) )
         {
            AddWhere(sWhereString, "([CapacidadProdDeptoPercent] >= @AV9cCapacidadProdDeptoPercent)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cCapacidadProdDeptoValor) )
         {
            AddWhere(sWhereString, "([CapacidadProdDeptoValor] >= @AV10cCapacidadProdDeptoValor)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV12cRubrosId) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV12cRubrosId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cCapacidadProdRubroPercent) )
         {
            AddWhere(sWhereString, "([CapacidadProdRubroPercent] >= @AV15cCapacidadProdRubroPercent)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [CapacidadProdId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00GU3( IGxContext context ,
                                             decimal AV7cCapacidadProdTotal ,
                                             long AV8cDepartamentoId ,
                                             decimal AV9cCapacidadProdDeptoPercent ,
                                             decimal AV10cCapacidadProdDeptoValor ,
                                             short AV12cRubrosId ,
                                             decimal AV15cCapacidadProdRubroPercent ,
                                             decimal A805CapacidadProdTotal ,
                                             long A112DepartamentoId ,
                                             decimal A806CapacidadProdDeptoPercent ,
                                             decimal A807CapacidadProdDeptoValor ,
                                             short A121RubrosId ,
                                             decimal A809CapacidadProdRubroPercent ,
                                             long AV6cCapacidadProdId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CapacidadProductiva]";
         AddWhere(sWhereString, "([CapacidadProdId] >= @AV6cCapacidadProdId)");
         if ( ! (Convert.ToDecimal(0)==AV7cCapacidadProdTotal) )
         {
            AddWhere(sWhereString, "([CapacidadProdTotal] >= @AV7cCapacidadProdTotal)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV8cDepartamentoId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cCapacidadProdDeptoPercent) )
         {
            AddWhere(sWhereString, "([CapacidadProdDeptoPercent] >= @AV9cCapacidadProdDeptoPercent)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cCapacidadProdDeptoValor) )
         {
            AddWhere(sWhereString, "([CapacidadProdDeptoValor] >= @AV10cCapacidadProdDeptoValor)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV12cRubrosId) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV12cRubrosId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cCapacidadProdRubroPercent) )
         {
            AddWhere(sWhereString, "([CapacidadProdRubroPercent] >= @AV15cCapacidadProdRubroPercent)");
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
                     return conditional_H00GU2(context, (decimal)dynConstraints[0] , (long)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (long)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00GU3(context, (decimal)dynConstraints[0] , (long)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (long)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00GU2;
          prmH00GU2 = new Object[] {
          new ParDef("@AV6cCapacidadProdId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cCapacidadProdTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV8cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV9cCapacidadProdDeptoPercent",GXType.Decimal,6,2) ,
          new ParDef("@AV10cCapacidadProdDeptoValor",GXType.Decimal,18,2) ,
          new ParDef("@AV12cRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV15cCapacidadProdRubroPercent",GXType.Decimal,6,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00GU3;
          prmH00GU3 = new Object[] {
          new ParDef("@AV6cCapacidadProdId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cCapacidadProdTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV8cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV9cCapacidadProdDeptoPercent",GXType.Decimal,6,2) ,
          new ParDef("@AV10cCapacidadProdDeptoValor",GXType.Decimal,18,2) ,
          new ParDef("@AV12cRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV15cCapacidadProdRubroPercent",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00GU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GU2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00GU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GU3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx03f0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03f0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03f0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pCapacidadProductivaAuxId )
      {
         this.AV10pCapacidadProductivaAuxId = 0 ;
         ExecutePrivate();
         aP0_pCapacidadProductivaAuxId=this.AV10pCapacidadProductivaAuxId;
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
            gxfirstwebparm = GetFirstPar( "pCapacidadProductivaAuxId");
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
               gxfirstwebparm = GetFirstPar( "pCapacidadProductivaAuxId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCapacidadProductivaAuxId");
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
               AV10pCapacidadProductivaAuxId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10pCapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(AV10pCapacidadProductivaAuxId), 18, 0));
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
         AV6cCapacidadProductivaAuxId = (long)(Math.Round(NumberUtil.Val( GetPar( "cCapacidadProductivaAuxId"), "."), 18, MidpointRounding.ToEven));
         AV9cCapacidadProductivaAuxCant = (long)(Math.Round(NumberUtil.Val( GetPar( "cCapacidadProductivaAuxCant"), "."), 18, MidpointRounding.ToEven));
         AV14cCapacidadProductivaAuxProfId = GetPar( "cCapacidadProductivaAuxProfId");
         AV15cCapacidadProductivaAuxDepId = (long)(Math.Round(NumberUtil.Val( GetPar( "cCapacidadProductivaAuxDepId"), "."), 18, MidpointRounding.ToEven));
         AV16cCapacidadProductivaAuxPorcent = NumberUtil.Val( GetPar( "cCapacidadProductivaAuxPorcent"), ".");
         AV17cCapacidadProductivaAuxHoras = NumberUtil.Val( GetPar( "cCapacidadProductivaAuxHoras"), ".");
         AV18cCapacidadProductivaAuxDepNombre = GetPar( "cCapacidadProductivaAuxDepNombre");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, AV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, AV18cCapacidadProductivaAuxDepNombre) ;
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
         PAH02( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTH02( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03f0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pCapacidadProductivaAuxId,18,0))}, new string[] {"pCapacidadProductivaAuxId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXCANT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cCapacidadProductivaAuxCant), 12, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXPROFID", StringUtil.RTrim( AV14cCapacidadProductivaAuxProfId));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXDEPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cCapacidadProductivaAuxDepId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXPORCENT", StringUtil.LTrim( StringUtil.NToC( AV16cCapacidadProductivaAuxPorcent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXHORAS", StringUtil.LTrim( StringUtil.NToC( AV17cCapacidadProductivaAuxHoras, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE", StringUtil.RTrim( AV18cCapacidadProductivaAuxDepNombre));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCAPACIDADPRODUCTIVAAUXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pCapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXIDFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXCANTFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxcantfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXPROFIDFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxprofidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXDEPIDFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxdepidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXPORCENTFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxporcentfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXHORASFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxhorasfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXDEPNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divCapacidadproductivaauxdepnombrefiltercontainer_Class));
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
            WEH02( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTH02( ) ;
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
         return formatLink("gx03f0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pCapacidadProductivaAuxId,18,0))}, new string[] {"pCapacidadProductivaAuxId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03F0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Capacidad Productiva Aux", "") ;
      }

      protected void WBH00( )
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxidfilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Id", ""), "", "", lblLblcapacidadproductivaauxidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxid_Internalname, context.GetMessage( "Capacidad Productiva Aux Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproductivaauxid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cCapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxid_Visible, edtavCcapacidadproductivaauxid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxcantfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxcantfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxcantfilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Cant", ""), "", "", lblLblcapacidadproductivaauxcantfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxcant_Internalname, context.GetMessage( "Capacidad Productiva Aux Cant", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxcant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cCapacidadProductivaAuxCant), 12, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproductivaauxcant_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cCapacidadProductivaAuxCant), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9cCapacidadProductivaAuxCant), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxcant_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxcant_Visible, edtavCcapacidadproductivaauxcant_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxprofidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxprofidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxprofidfilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Prof Id", ""), "", "", lblLblcapacidadproductivaauxprofidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxprofid_Internalname, context.GetMessage( "Capacidad Productiva Aux Prof Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxprofid_Internalname, StringUtil.RTrim( AV14cCapacidadProductivaAuxProfId), StringUtil.RTrim( context.localUtil.Format( AV14cCapacidadProductivaAuxProfId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxprofid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxprofid_Visible, edtavCcapacidadproductivaauxprofid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxdepidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxdepidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxdepidfilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Dep Id", ""), "", "", lblLblcapacidadproductivaauxdepidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxdepid_Internalname, context.GetMessage( "Capacidad Productiva Aux Dep Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxdepid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cCapacidadProductivaAuxDepId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproductivaauxdepid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15cCapacidadProductivaAuxDepId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV15cCapacidadProductivaAuxDepId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxdepid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxdepid_Visible, edtavCcapacidadproductivaauxdepid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxporcentfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxporcentfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxporcentfilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Porcent", ""), "", "", lblLblcapacidadproductivaauxporcentfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxporcent_Internalname, context.GetMessage( "Capacidad Productiva Aux Porcent", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxporcent_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16cCapacidadProductivaAuxPorcent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproductivaauxporcent_Enabled!=0) ? context.localUtil.Format( AV16cCapacidadProductivaAuxPorcent, "ZZ9.99") : context.localUtil.Format( AV16cCapacidadProductivaAuxPorcent, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxporcent_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxporcent_Visible, edtavCcapacidadproductivaauxporcent_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxhorasfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxhorasfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxhorasfilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Horas", ""), "", "", lblLblcapacidadproductivaauxhorasfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxhoras_Internalname, context.GetMessage( "Capacidad Productiva Aux Horas", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxhoras_Internalname, StringUtil.LTrim( StringUtil.NToC( AV17cCapacidadProductivaAuxHoras, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcapacidadproductivaauxhoras_Enabled!=0) ? context.localUtil.Format( AV17cCapacidadProductivaAuxHoras, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV17cCapacidadProductivaAuxHoras, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxhoras_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxhoras_Visible, edtavCcapacidadproductivaauxhoras_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_div_start( context, divCapacidadproductivaauxdepnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCapacidadproductivaauxdepnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcapacidadproductivaauxdepnombrefilter_Internalname, context.GetMessage( "Capacidad Productiva Aux Dep Nombre", ""), "", "", lblLblcapacidadproductivaauxdepnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17h01_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03F0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcapacidadproductivaauxdepnombre_Internalname, context.GetMessage( "Capacidad Productiva Aux Dep Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcapacidadproductivaauxdepnombre_Internalname, StringUtil.RTrim( AV18cCapacidadProductivaAuxDepNombre), StringUtil.RTrim( context.localUtil.Format( AV18cCapacidadProductivaAuxDepNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcapacidadproductivaauxdepnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcapacidadproductivaauxdepnombre_Visible, edtavCcapacidadproductivaauxdepnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03F0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18h01_client"+"'", TempTags, "", 2, "HLP_Gx03F0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03F0.htm");
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

      protected void STARTH02( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Capacidad Productiva Aux", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPH00( ) ;
      }

      protected void WSH02( )
      {
         STARTH02( ) ;
         EVTH02( ) ;
      }

      protected void EVTH02( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A820CapacidadProductivaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A821CapacidadProductivaAuxCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A824CapacidadProductivaAuxProfId = cgiGet( edtCapacidadProductivaAuxProfId_Internalname);
                              A825CapacidadProductivaAuxDepId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProductivaAuxDepId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19H02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20H02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccapacidadproductivaauxid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCapacidadProductivaAuxId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproductivaauxcant Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXCANT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cCapacidadProductivaAuxCant )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproductivaauxprofid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXPROFID"), AV14cCapacidadProductivaAuxProfId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproductivaauxdepid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXDEPID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15cCapacidadProductivaAuxDepId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproductivaauxporcent Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXPORCENT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV16cCapacidadProductivaAuxPorcent )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproductivaauxhoras Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXHORAS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV17cCapacidadProductivaAuxHoras )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccapacidadproductivaauxdepnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE"), AV18cCapacidadProductivaAuxDepNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21H02 ();
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

      protected void WEH02( )
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

      protected void PAH02( )
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
                                        long AV6cCapacidadProductivaAuxId ,
                                        long AV9cCapacidadProductivaAuxCant ,
                                        string AV14cCapacidadProductivaAuxProfId ,
                                        long AV15cCapacidadProductivaAuxDepId ,
                                        decimal AV16cCapacidadProductivaAuxPorcent ,
                                        decimal AV17cCapacidadProductivaAuxHoras ,
                                        string AV18cCapacidadProductivaAuxDepNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFH02( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CAPACIDADPRODUCTIVAAUXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A820CapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CAPACIDADPRODUCTIVAAUXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A820CapacidadProductivaAuxId), 18, 0, ".", "")));
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
         RFH02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFH02( )
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
                                                 AV9cCapacidadProductivaAuxCant ,
                                                 AV14cCapacidadProductivaAuxProfId ,
                                                 AV15cCapacidadProductivaAuxDepId ,
                                                 AV16cCapacidadProductivaAuxPorcent ,
                                                 AV17cCapacidadProductivaAuxHoras ,
                                                 AV18cCapacidadProductivaAuxDepNombre ,
                                                 A821CapacidadProductivaAuxCant ,
                                                 A824CapacidadProductivaAuxProfId ,
                                                 A825CapacidadProductivaAuxDepId ,
                                                 A826CapacidadProductivaAuxPorcent ,
                                                 A808CapacidadProductivaAuxHoras ,
                                                 A834CapacidadProductivaAuxDepNombr ,
                                                 AV6cCapacidadProductivaAuxId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG
                                                 }
            });
            lV14cCapacidadProductivaAuxProfId = StringUtil.PadR( StringUtil.RTrim( AV14cCapacidadProductivaAuxProfId), 20, "%");
            lV18cCapacidadProductivaAuxDepNombre = StringUtil.PadR( StringUtil.RTrim( AV18cCapacidadProductivaAuxDepNombre), 80, "%");
            /* Using cursor H00H02 */
            pr_default.execute(0, new Object[] {AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, lV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, lV18cCapacidadProductivaAuxDepNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A834CapacidadProductivaAuxDepNombr = H00H02_A834CapacidadProductivaAuxDepNombr[0];
               A808CapacidadProductivaAuxHoras = H00H02_A808CapacidadProductivaAuxHoras[0];
               A826CapacidadProductivaAuxPorcent = H00H02_A826CapacidadProductivaAuxPorcent[0];
               A825CapacidadProductivaAuxDepId = H00H02_A825CapacidadProductivaAuxDepId[0];
               A824CapacidadProductivaAuxProfId = H00H02_A824CapacidadProductivaAuxProfId[0];
               A821CapacidadProductivaAuxCant = H00H02_A821CapacidadProductivaAuxCant[0];
               A820CapacidadProductivaAuxId = H00H02_A820CapacidadProductivaAuxId[0];
               /* Execute user event: Load */
               E20H02 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBH00( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesH02( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CAPACIDADPRODUCTIVAAUXID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A820CapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV9cCapacidadProductivaAuxCant ,
                                              AV14cCapacidadProductivaAuxProfId ,
                                              AV15cCapacidadProductivaAuxDepId ,
                                              AV16cCapacidadProductivaAuxPorcent ,
                                              AV17cCapacidadProductivaAuxHoras ,
                                              AV18cCapacidadProductivaAuxDepNombre ,
                                              A821CapacidadProductivaAuxCant ,
                                              A824CapacidadProductivaAuxProfId ,
                                              A825CapacidadProductivaAuxDepId ,
                                              A826CapacidadProductivaAuxPorcent ,
                                              A808CapacidadProductivaAuxHoras ,
                                              A834CapacidadProductivaAuxDepNombr ,
                                              AV6cCapacidadProductivaAuxId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG
                                              }
         });
         lV14cCapacidadProductivaAuxProfId = StringUtil.PadR( StringUtil.RTrim( AV14cCapacidadProductivaAuxProfId), 20, "%");
         lV18cCapacidadProductivaAuxDepNombre = StringUtil.PadR( StringUtil.RTrim( AV18cCapacidadProductivaAuxDepNombre), 80, "%");
         /* Using cursor H00H03 */
         pr_default.execute(1, new Object[] {AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, lV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, lV18cCapacidadProductivaAuxDepNombre});
         GRID1_nRecordCount = H00H03_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, AV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, AV18cCapacidadProductivaAuxDepNombre) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, AV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, AV18cCapacidadProductivaAuxDepNombre) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, AV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, AV18cCapacidadProductivaAuxDepNombre) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, AV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, AV18cCapacidadProductivaAuxDepNombre) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCapacidadProductivaAuxId, AV9cCapacidadProductivaAuxCant, AV14cCapacidadProductivaAuxProfId, AV15cCapacidadProductivaAuxDepId, AV16cCapacidadProductivaAuxPorcent, AV17cCapacidadProductivaAuxHoras, AV18cCapacidadProductivaAuxDepNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCapacidadProductivaAuxId_Enabled = 0;
         edtCapacidadProductivaAuxCant_Enabled = 0;
         edtCapacidadProductivaAuxProfId_Enabled = 0;
         edtCapacidadProductivaAuxDepId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPH00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19H02 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODUCTIVAAUXID");
               GX_FocusControl = edtavCcapacidadproductivaauxid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCapacidadProductivaAuxId = 0;
               AssignAttri("", false, "AV6cCapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(AV6cCapacidadProductivaAuxId), 18, 0));
            }
            else
            {
               AV6cCapacidadProductivaAuxId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(AV6cCapacidadProductivaAuxId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODUCTIVAAUXCANT");
               GX_FocusControl = edtavCcapacidadproductivaauxcant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cCapacidadProductivaAuxCant = 0;
               AssignAttri("", false, "AV9cCapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(AV9cCapacidadProductivaAuxCant), 12, 0));
            }
            else
            {
               AV9cCapacidadProductivaAuxCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cCapacidadProductivaAuxCant", StringUtil.LTrimStr( (decimal)(AV9cCapacidadProductivaAuxCant), 12, 0));
            }
            AV14cCapacidadProductivaAuxProfId = cgiGet( edtavCcapacidadproductivaauxprofid_Internalname);
            AssignAttri("", false, "AV14cCapacidadProductivaAuxProfId", AV14cCapacidadProductivaAuxProfId);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxdepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxdepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODUCTIVAAUXDEPID");
               GX_FocusControl = edtavCcapacidadproductivaauxdepid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cCapacidadProductivaAuxDepId = 0;
               AssignAttri("", false, "AV15cCapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(AV15cCapacidadProductivaAuxDepId), 18, 0));
            }
            else
            {
               AV15cCapacidadProductivaAuxDepId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxdepid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15cCapacidadProductivaAuxDepId", StringUtil.LTrimStr( (decimal)(AV15cCapacidadProductivaAuxDepId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxporcent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxporcent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODUCTIVAAUXPORCENT");
               GX_FocusControl = edtavCcapacidadproductivaauxporcent_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cCapacidadProductivaAuxPorcent = 0;
               AssignAttri("", false, "AV16cCapacidadProductivaAuxPorcent", StringUtil.LTrimStr( AV16cCapacidadProductivaAuxPorcent, 6, 2));
            }
            else
            {
               AV16cCapacidadProductivaAuxPorcent = context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxporcent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV16cCapacidadProductivaAuxPorcent", StringUtil.LTrimStr( AV16cCapacidadProductivaAuxPorcent, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxhoras_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxhoras_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCAPACIDADPRODUCTIVAAUXHORAS");
               GX_FocusControl = edtavCcapacidadproductivaauxhoras_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17cCapacidadProductivaAuxHoras = 0;
               AssignAttri("", false, "AV17cCapacidadProductivaAuxHoras", StringUtil.LTrimStr( AV17cCapacidadProductivaAuxHoras, 18, 2));
            }
            else
            {
               AV17cCapacidadProductivaAuxHoras = context.localUtil.CToN( cgiGet( edtavCcapacidadproductivaauxhoras_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV17cCapacidadProductivaAuxHoras", StringUtil.LTrimStr( AV17cCapacidadProductivaAuxHoras, 18, 2));
            }
            AV18cCapacidadProductivaAuxDepNombre = cgiGet( edtavCcapacidadproductivaauxdepnombre_Internalname);
            AssignAttri("", false, "AV18cCapacidadProductivaAuxDepNombre", AV18cCapacidadProductivaAuxDepNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCapacidadProductivaAuxId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXCANT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cCapacidadProductivaAuxCant )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXPROFID"), AV14cCapacidadProductivaAuxProfId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXDEPID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15cCapacidadProductivaAuxDepId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXPORCENT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV16cCapacidadProductivaAuxPorcent )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXHORAS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV17cCapacidadProductivaAuxHoras )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE"), AV18cCapacidadProductivaAuxDepNombre) != 0 )
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
         E19H02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19H02( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Capacidad Productiva Aux", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV11ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20H02( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV19Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E21H02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21H02( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10pCapacidadProductivaAuxId = A820CapacidadProductivaAuxId;
         AssignAttri("", false, "AV10pCapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(AV10pCapacidadProductivaAuxId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV10pCapacidadProductivaAuxId});
         context.setWebReturnParmsMetadata(new Object[] {"AV10pCapacidadProductivaAuxId"});
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
         AV10pCapacidadProductivaAuxId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV10pCapacidadProductivaAuxId", StringUtil.LTrimStr( (decimal)(AV10pCapacidadProductivaAuxId), 18, 0));
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
         PAH02( ) ;
         WSH02( ) ;
         WEH02( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021262144", true, true, false);
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
         context.AddJavascriptSource("gx03f0.js", "?202673021262145", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCapacidadProductivaAuxId_Internalname = "CAPACIDADPRODUCTIVAAUXID_"+sGXsfl_84_idx;
         edtCapacidadProductivaAuxCant_Internalname = "CAPACIDADPRODUCTIVAAUXCANT_"+sGXsfl_84_idx;
         edtCapacidadProductivaAuxProfId_Internalname = "CAPACIDADPRODUCTIVAAUXPROFID_"+sGXsfl_84_idx;
         edtCapacidadProductivaAuxDepId_Internalname = "CAPACIDADPRODUCTIVAAUXDEPID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCapacidadProductivaAuxId_Internalname = "CAPACIDADPRODUCTIVAAUXID_"+sGXsfl_84_fel_idx;
         edtCapacidadProductivaAuxCant_Internalname = "CAPACIDADPRODUCTIVAAUXCANT_"+sGXsfl_84_fel_idx;
         edtCapacidadProductivaAuxProfId_Internalname = "CAPACIDADPRODUCTIVAAUXPROFID_"+sGXsfl_84_fel_idx;
         edtCapacidadProductivaAuxDepId_Internalname = "CAPACIDADPRODUCTIVAAUXDEPID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBH00( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A820CapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProductivaAuxId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A820CapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A820CapacidadProductivaAuxId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCapacidadProductivaAuxId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProductivaAuxCant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A821CapacidadProductivaAuxCant), 12, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A821CapacidadProductivaAuxCant), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCapacidadProductivaAuxCant_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCapacidadProductivaAuxProfId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A820CapacidadProductivaAuxId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtCapacidadProductivaAuxProfId_Internalname, "Link", edtCapacidadProductivaAuxProfId_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProductivaAuxProfId_Internalname,StringUtil.RTrim( A824CapacidadProductivaAuxProfId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCapacidadProductivaAuxProfId_Link,(string)"",(string)"",(string)"",(string)edtCapacidadProductivaAuxProfId_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCapacidadProductivaAuxDepId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A825CapacidadProductivaAuxDepId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCapacidadProductivaAuxDepId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesH02( ) ;
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
            context.SendWebValue( context.GetMessage( "Aux Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aux Cant", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Prof Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dep Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A820CapacidadProductivaAuxId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A821CapacidadProductivaAuxCant), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A824CapacidadProductivaAuxProfId)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCapacidadProductivaAuxProfId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A825CapacidadProductivaAuxDepId), 18, 0, ".", ""))));
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
         lblLblcapacidadproductivaauxidfilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXIDFILTER";
         edtavCcapacidadproductivaauxid_Internalname = "vCCAPACIDADPRODUCTIVAAUXID";
         divCapacidadproductivaauxidfiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXIDFILTERCONTAINER";
         lblLblcapacidadproductivaauxcantfilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXCANTFILTER";
         edtavCcapacidadproductivaauxcant_Internalname = "vCCAPACIDADPRODUCTIVAAUXCANT";
         divCapacidadproductivaauxcantfiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXCANTFILTERCONTAINER";
         lblLblcapacidadproductivaauxprofidfilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXPROFIDFILTER";
         edtavCcapacidadproductivaauxprofid_Internalname = "vCCAPACIDADPRODUCTIVAAUXPROFID";
         divCapacidadproductivaauxprofidfiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXPROFIDFILTERCONTAINER";
         lblLblcapacidadproductivaauxdepidfilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXDEPIDFILTER";
         edtavCcapacidadproductivaauxdepid_Internalname = "vCCAPACIDADPRODUCTIVAAUXDEPID";
         divCapacidadproductivaauxdepidfiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXDEPIDFILTERCONTAINER";
         lblLblcapacidadproductivaauxporcentfilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXPORCENTFILTER";
         edtavCcapacidadproductivaauxporcent_Internalname = "vCCAPACIDADPRODUCTIVAAUXPORCENT";
         divCapacidadproductivaauxporcentfiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXPORCENTFILTERCONTAINER";
         lblLblcapacidadproductivaauxhorasfilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXHORASFILTER";
         edtavCcapacidadproductivaauxhoras_Internalname = "vCCAPACIDADPRODUCTIVAAUXHORAS";
         divCapacidadproductivaauxhorasfiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXHORASFILTERCONTAINER";
         lblLblcapacidadproductivaauxdepnombrefilter_Internalname = "LBLCAPACIDADPRODUCTIVAAUXDEPNOMBREFILTER";
         edtavCcapacidadproductivaauxdepnombre_Internalname = "vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE";
         divCapacidadproductivaauxdepnombrefiltercontainer_Internalname = "CAPACIDADPRODUCTIVAAUXDEPNOMBREFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCapacidadProductivaAuxId_Internalname = "CAPACIDADPRODUCTIVAAUXID";
         edtCapacidadProductivaAuxCant_Internalname = "CAPACIDADPRODUCTIVAAUXCANT";
         edtCapacidadProductivaAuxProfId_Internalname = "CAPACIDADPRODUCTIVAAUXPROFID";
         edtCapacidadProductivaAuxDepId_Internalname = "CAPACIDADPRODUCTIVAAUXDEPID";
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
         edtCapacidadProductivaAuxDepId_Jsonclick = "";
         edtCapacidadProductivaAuxProfId_Jsonclick = "";
         edtCapacidadProductivaAuxProfId_Link = "";
         edtCapacidadProductivaAuxCant_Jsonclick = "";
         edtCapacidadProductivaAuxId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCapacidadProductivaAuxDepId_Enabled = 0;
         edtCapacidadProductivaAuxProfId_Enabled = 0;
         edtCapacidadProductivaAuxCant_Enabled = 0;
         edtCapacidadProductivaAuxId_Enabled = 0;
         edtavCcapacidadproductivaauxdepnombre_Jsonclick = "";
         edtavCcapacidadproductivaauxdepnombre_Enabled = 1;
         edtavCcapacidadproductivaauxdepnombre_Visible = 1;
         edtavCcapacidadproductivaauxhoras_Jsonclick = "";
         edtavCcapacidadproductivaauxhoras_Enabled = 1;
         edtavCcapacidadproductivaauxhoras_Visible = 1;
         edtavCcapacidadproductivaauxporcent_Jsonclick = "";
         edtavCcapacidadproductivaauxporcent_Enabled = 1;
         edtavCcapacidadproductivaauxporcent_Visible = 1;
         edtavCcapacidadproductivaauxdepid_Jsonclick = "";
         edtavCcapacidadproductivaauxdepid_Enabled = 1;
         edtavCcapacidadproductivaauxdepid_Visible = 1;
         edtavCcapacidadproductivaauxprofid_Jsonclick = "";
         edtavCcapacidadproductivaauxprofid_Enabled = 1;
         edtavCcapacidadproductivaauxprofid_Visible = 1;
         edtavCcapacidadproductivaauxcant_Jsonclick = "";
         edtavCcapacidadproductivaauxcant_Enabled = 1;
         edtavCcapacidadproductivaauxcant_Visible = 1;
         edtavCcapacidadproductivaauxid_Jsonclick = "";
         edtavCcapacidadproductivaauxid_Enabled = 1;
         edtavCcapacidadproductivaauxid_Visible = 1;
         divCapacidadproductivaauxdepnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproductivaauxhorasfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproductivaauxporcentfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproductivaauxdepidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproductivaauxprofidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproductivaauxcantfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCapacidadproductivaauxidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Capacidad Productiva Aux", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProductivaAuxId',fld:'vCCAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProductivaAuxCant',fld:'vCCAPACIDADPRODUCTIVAAUXCANT',pic:'ZZZZZZZZZZZ9',type:'int'},{av:'AV14cCapacidadProductivaAuxProfId',fld:'vCCAPACIDADPRODUCTIVAAUXPROFID',pic:'',type:'char'},{av:'AV15cCapacidadProductivaAuxDepId',fld:'vCCAPACIDADPRODUCTIVAAUXDEPID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16cCapacidadProductivaAuxPorcent',fld:'vCCAPACIDADPRODUCTIVAAUXPORCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV17cCapacidadProductivaAuxHoras',fld:'vCCAPACIDADPRODUCTIVAAUXHORAS',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV18cCapacidadProductivaAuxDepNombre',fld:'vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18H01',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXIDFILTER.CLICK","{handler:'E11H01',iparms:[{av:'divCapacidadproductivaauxidfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXIDFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxidfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxid_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXID',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXCANTFILTER.CLICK","{handler:'E12H01',iparms:[{av:'divCapacidadproductivaauxcantfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXCANTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXCANTFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxcantfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXCANTFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxcant_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXCANT',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXPROFIDFILTER.CLICK","{handler:'E13H01',iparms:[{av:'divCapacidadproductivaauxprofidfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXPROFIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXPROFIDFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxprofidfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXPROFIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxprofid_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXPROFID',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXDEPIDFILTER.CLICK","{handler:'E14H01',iparms:[{av:'divCapacidadproductivaauxdepidfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXDEPIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXDEPIDFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxdepidfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXDEPIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxdepid_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXDEPID',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXPORCENTFILTER.CLICK","{handler:'E15H01',iparms:[{av:'divCapacidadproductivaauxporcentfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXPORCENTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXPORCENTFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxporcentfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXPORCENTFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxporcent_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXPORCENT',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXHORASFILTER.CLICK","{handler:'E16H01',iparms:[{av:'divCapacidadproductivaauxhorasfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXHORASFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXHORASFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxhorasfiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXHORASFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxhoras_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXHORAS',prop:'Visible'}]}");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXDEPNOMBREFILTER.CLICK","{handler:'E17H01',iparms:[{av:'divCapacidadproductivaauxdepnombrefiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXDEPNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCAPACIDADPRODUCTIVAAUXDEPNOMBREFILTER.CLICK",",oparms:[{av:'divCapacidadproductivaauxdepnombrefiltercontainer_Class',ctrl:'CAPACIDADPRODUCTIVAAUXDEPNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCcapacidadproductivaauxdepnombre_Visible',ctrl:'vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21H02',iparms:[{av:'A820CapacidadProductivaAuxId',fld:'CAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV10pCapacidadProductivaAuxId',fld:'vPCAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProductivaAuxId',fld:'vCCAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProductivaAuxCant',fld:'vCCAPACIDADPRODUCTIVAAUXCANT',pic:'ZZZZZZZZZZZ9',type:'int'},{av:'AV14cCapacidadProductivaAuxProfId',fld:'vCCAPACIDADPRODUCTIVAAUXPROFID',pic:'',type:'char'},{av:'AV15cCapacidadProductivaAuxDepId',fld:'vCCAPACIDADPRODUCTIVAAUXDEPID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16cCapacidadProductivaAuxPorcent',fld:'vCCAPACIDADPRODUCTIVAAUXPORCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV17cCapacidadProductivaAuxHoras',fld:'vCCAPACIDADPRODUCTIVAAUXHORAS',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV18cCapacidadProductivaAuxDepNombre',fld:'vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProductivaAuxId',fld:'vCCAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProductivaAuxCant',fld:'vCCAPACIDADPRODUCTIVAAUXCANT',pic:'ZZZZZZZZZZZ9',type:'int'},{av:'AV14cCapacidadProductivaAuxProfId',fld:'vCCAPACIDADPRODUCTIVAAUXPROFID',pic:'',type:'char'},{av:'AV15cCapacidadProductivaAuxDepId',fld:'vCCAPACIDADPRODUCTIVAAUXDEPID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16cCapacidadProductivaAuxPorcent',fld:'vCCAPACIDADPRODUCTIVAAUXPORCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV17cCapacidadProductivaAuxHoras',fld:'vCCAPACIDADPRODUCTIVAAUXHORAS',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV18cCapacidadProductivaAuxDepNombre',fld:'vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProductivaAuxId',fld:'vCCAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProductivaAuxCant',fld:'vCCAPACIDADPRODUCTIVAAUXCANT',pic:'ZZZZZZZZZZZ9',type:'int'},{av:'AV14cCapacidadProductivaAuxProfId',fld:'vCCAPACIDADPRODUCTIVAAUXPROFID',pic:'',type:'char'},{av:'AV15cCapacidadProductivaAuxDepId',fld:'vCCAPACIDADPRODUCTIVAAUXDEPID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16cCapacidadProductivaAuxPorcent',fld:'vCCAPACIDADPRODUCTIVAAUXPORCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV17cCapacidadProductivaAuxHoras',fld:'vCCAPACIDADPRODUCTIVAAUXHORAS',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV18cCapacidadProductivaAuxDepNombre',fld:'vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCapacidadProductivaAuxId',fld:'vCCAPACIDADPRODUCTIVAAUXID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cCapacidadProductivaAuxCant',fld:'vCCAPACIDADPRODUCTIVAAUXCANT',pic:'ZZZZZZZZZZZ9',type:'int'},{av:'AV14cCapacidadProductivaAuxProfId',fld:'vCCAPACIDADPRODUCTIVAAUXPROFID',pic:'',type:'char'},{av:'AV15cCapacidadProductivaAuxDepId',fld:'vCCAPACIDADPRODUCTIVAAUXDEPID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16cCapacidadProductivaAuxPorcent',fld:'vCCAPACIDADPRODUCTIVAAUXPORCENT',pic:'ZZ9.99',type:'decimal'},{av:'AV17cCapacidadProductivaAuxHoras',fld:'vCCAPACIDADPRODUCTIVAAUXHORAS',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV18cCapacidadProductivaAuxDepNombre',fld:'vCCAPACIDADPRODUCTIVAAUXDEPNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Capacidadproductivaauxdepid',iparms:[]");
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
         AV14cCapacidadProductivaAuxProfId = "";
         AV18cCapacidadProductivaAuxDepNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcapacidadproductivaauxidfilter_Jsonclick = "";
         TempTags = "";
         lblLblcapacidadproductivaauxcantfilter_Jsonclick = "";
         lblLblcapacidadproductivaauxprofidfilter_Jsonclick = "";
         lblLblcapacidadproductivaauxdepidfilter_Jsonclick = "";
         lblLblcapacidadproductivaauxporcentfilter_Jsonclick = "";
         lblLblcapacidadproductivaauxhorasfilter_Jsonclick = "";
         lblLblcapacidadproductivaauxdepnombrefilter_Jsonclick = "";
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
         AV19Linkselection_GXI = "";
         A824CapacidadProductivaAuxProfId = "";
         lV14cCapacidadProductivaAuxProfId = "";
         lV18cCapacidadProductivaAuxDepNombre = "";
         A834CapacidadProductivaAuxDepNombr = "";
         H00H02_A834CapacidadProductivaAuxDepNombr = new string[] {""} ;
         H00H02_A808CapacidadProductivaAuxHoras = new decimal[1] ;
         H00H02_A826CapacidadProductivaAuxPorcent = new decimal[1] ;
         H00H02_A825CapacidadProductivaAuxDepId = new long[1] ;
         H00H02_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         H00H02_A821CapacidadProductivaAuxCant = new long[1] ;
         H00H02_A820CapacidadProductivaAuxId = new long[1] ;
         H00H03_AGRID1_nRecordCount = new long[1] ;
         AV11ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03f0__default(),
            new Object[][] {
                new Object[] {
               H00H02_A834CapacidadProductivaAuxDepNombr, H00H02_A808CapacidadProductivaAuxHoras, H00H02_A826CapacidadProductivaAuxPorcent, H00H02_A825CapacidadProductivaAuxDepId, H00H02_A824CapacidadProductivaAuxProfId, H00H02_A821CapacidadProductivaAuxCant, H00H02_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               H00H03_AGRID1_nRecordCount
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
      private int edtavCcapacidadproductivaauxid_Enabled ;
      private int edtavCcapacidadproductivaauxid_Visible ;
      private int edtavCcapacidadproductivaauxcant_Enabled ;
      private int edtavCcapacidadproductivaauxcant_Visible ;
      private int edtavCcapacidadproductivaauxprofid_Visible ;
      private int edtavCcapacidadproductivaauxprofid_Enabled ;
      private int edtavCcapacidadproductivaauxdepid_Enabled ;
      private int edtavCcapacidadproductivaauxdepid_Visible ;
      private int edtavCcapacidadproductivaauxporcent_Enabled ;
      private int edtavCcapacidadproductivaauxporcent_Visible ;
      private int edtavCcapacidadproductivaauxhoras_Enabled ;
      private int edtavCcapacidadproductivaauxhoras_Visible ;
      private int edtavCcapacidadproductivaauxdepnombre_Visible ;
      private int edtavCcapacidadproductivaauxdepnombre_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCapacidadProductivaAuxId_Enabled ;
      private int edtCapacidadProductivaAuxCant_Enabled ;
      private int edtCapacidadProductivaAuxProfId_Enabled ;
      private int edtCapacidadProductivaAuxDepId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV10pCapacidadProductivaAuxId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cCapacidadProductivaAuxId ;
      private long AV9cCapacidadProductivaAuxCant ;
      private long AV15cCapacidadProductivaAuxDepId ;
      private long A820CapacidadProductivaAuxId ;
      private long A821CapacidadProductivaAuxCant ;
      private long A825CapacidadProductivaAuxDepId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV16cCapacidadProductivaAuxPorcent ;
      private decimal AV17cCapacidadProductivaAuxHoras ;
      private decimal A826CapacidadProductivaAuxPorcent ;
      private decimal A808CapacidadProductivaAuxHoras ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCapacidadproductivaauxidfiltercontainer_Class ;
      private string divCapacidadproductivaauxcantfiltercontainer_Class ;
      private string divCapacidadproductivaauxprofidfiltercontainer_Class ;
      private string divCapacidadproductivaauxdepidfiltercontainer_Class ;
      private string divCapacidadproductivaauxporcentfiltercontainer_Class ;
      private string divCapacidadproductivaauxhorasfiltercontainer_Class ;
      private string divCapacidadproductivaauxdepnombrefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV14cCapacidadProductivaAuxProfId ;
      private string AV18cCapacidadProductivaAuxDepNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCapacidadproductivaauxidfiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxidfilter_Internalname ;
      private string lblLblcapacidadproductivaauxidfilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxid_Internalname ;
      private string TempTags ;
      private string edtavCcapacidadproductivaauxid_Jsonclick ;
      private string divCapacidadproductivaauxcantfiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxcantfilter_Internalname ;
      private string lblLblcapacidadproductivaauxcantfilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxcant_Internalname ;
      private string edtavCcapacidadproductivaauxcant_Jsonclick ;
      private string divCapacidadproductivaauxprofidfiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxprofidfilter_Internalname ;
      private string lblLblcapacidadproductivaauxprofidfilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxprofid_Internalname ;
      private string edtavCcapacidadproductivaauxprofid_Jsonclick ;
      private string divCapacidadproductivaauxdepidfiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxdepidfilter_Internalname ;
      private string lblLblcapacidadproductivaauxdepidfilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxdepid_Internalname ;
      private string edtavCcapacidadproductivaauxdepid_Jsonclick ;
      private string divCapacidadproductivaauxporcentfiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxporcentfilter_Internalname ;
      private string lblLblcapacidadproductivaauxporcentfilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxporcent_Internalname ;
      private string edtavCcapacidadproductivaauxporcent_Jsonclick ;
      private string divCapacidadproductivaauxhorasfiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxhorasfilter_Internalname ;
      private string lblLblcapacidadproductivaauxhorasfilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxhoras_Internalname ;
      private string edtavCcapacidadproductivaauxhoras_Jsonclick ;
      private string divCapacidadproductivaauxdepnombrefiltercontainer_Internalname ;
      private string lblLblcapacidadproductivaauxdepnombrefilter_Internalname ;
      private string lblLblcapacidadproductivaauxdepnombrefilter_Jsonclick ;
      private string edtavCcapacidadproductivaauxdepnombre_Internalname ;
      private string edtavCcapacidadproductivaauxdepnombre_Jsonclick ;
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
      private string edtCapacidadProductivaAuxId_Internalname ;
      private string edtCapacidadProductivaAuxCant_Internalname ;
      private string A824CapacidadProductivaAuxProfId ;
      private string edtCapacidadProductivaAuxProfId_Internalname ;
      private string edtCapacidadProductivaAuxDepId_Internalname ;
      private string lV14cCapacidadProductivaAuxProfId ;
      private string lV18cCapacidadProductivaAuxDepNombre ;
      private string A834CapacidadProductivaAuxDepNombr ;
      private string AV11ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCapacidadProductivaAuxId_Jsonclick ;
      private string edtCapacidadProductivaAuxCant_Jsonclick ;
      private string edtCapacidadProductivaAuxProfId_Link ;
      private string edtCapacidadProductivaAuxProfId_Jsonclick ;
      private string edtCapacidadProductivaAuxDepId_Jsonclick ;
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
      private string AV19Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00H02_A834CapacidadProductivaAuxDepNombr ;
      private decimal[] H00H02_A808CapacidadProductivaAuxHoras ;
      private decimal[] H00H02_A826CapacidadProductivaAuxPorcent ;
      private long[] H00H02_A825CapacidadProductivaAuxDepId ;
      private string[] H00H02_A824CapacidadProductivaAuxProfId ;
      private long[] H00H02_A821CapacidadProductivaAuxCant ;
      private long[] H00H02_A820CapacidadProductivaAuxId ;
      private long[] H00H03_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pCapacidadProductivaAuxId ;
   }

   public class gx03f0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00H02( IGxContext context ,
                                             long AV9cCapacidadProductivaAuxCant ,
                                             string AV14cCapacidadProductivaAuxProfId ,
                                             long AV15cCapacidadProductivaAuxDepId ,
                                             decimal AV16cCapacidadProductivaAuxPorcent ,
                                             decimal AV17cCapacidadProductivaAuxHoras ,
                                             string AV18cCapacidadProductivaAuxDepNombre ,
                                             long A821CapacidadProductivaAuxCant ,
                                             string A824CapacidadProductivaAuxProfId ,
                                             long A825CapacidadProductivaAuxDepId ,
                                             decimal A826CapacidadProductivaAuxPorcent ,
                                             decimal A808CapacidadProductivaAuxHoras ,
                                             string A834CapacidadProductivaAuxDepNombr ,
                                             long AV6cCapacidadProductivaAuxId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CapacidadProductivaAuxDepNombr], [CapacidadProductivaAuxHoras], [CapacidadProductivaAuxPorcent], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxCant], [CapacidadProductivaAuxId]";
         sFromString = " FROM [CapacidadProductivaAux]";
         sOrderString = "";
         AddWhere(sWhereString, "([CapacidadProductivaAuxId] >= @AV6cCapacidadProductivaAuxId)");
         if ( ! (0==AV9cCapacidadProductivaAuxCant) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxCant] >= @AV9cCapacidadProductivaAuxCant)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cCapacidadProductivaAuxProfId)) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxProfId] like @lV14cCapacidadProductivaAuxProfId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV15cCapacidadProductivaAuxDepId) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxDepId] >= @AV15cCapacidadProductivaAuxDepId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16cCapacidadProductivaAuxPorcent) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxPorcent] >= @AV16cCapacidadProductivaAuxPorcent)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV17cCapacidadProductivaAuxHoras) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxHoras] >= @AV17cCapacidadProductivaAuxHoras)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18cCapacidadProductivaAuxDepNombre)) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxDepNombr] like @lV18cCapacidadProductivaAuxDepNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [CapacidadProductivaAuxId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00H03( IGxContext context ,
                                             long AV9cCapacidadProductivaAuxCant ,
                                             string AV14cCapacidadProductivaAuxProfId ,
                                             long AV15cCapacidadProductivaAuxDepId ,
                                             decimal AV16cCapacidadProductivaAuxPorcent ,
                                             decimal AV17cCapacidadProductivaAuxHoras ,
                                             string AV18cCapacidadProductivaAuxDepNombre ,
                                             long A821CapacidadProductivaAuxCant ,
                                             string A824CapacidadProductivaAuxProfId ,
                                             long A825CapacidadProductivaAuxDepId ,
                                             decimal A826CapacidadProductivaAuxPorcent ,
                                             decimal A808CapacidadProductivaAuxHoras ,
                                             string A834CapacidadProductivaAuxDepNombr ,
                                             long AV6cCapacidadProductivaAuxId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [CapacidadProductivaAux]";
         AddWhere(sWhereString, "([CapacidadProductivaAuxId] >= @AV6cCapacidadProductivaAuxId)");
         if ( ! (0==AV9cCapacidadProductivaAuxCant) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxCant] >= @AV9cCapacidadProductivaAuxCant)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cCapacidadProductivaAuxProfId)) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxProfId] like @lV14cCapacidadProductivaAuxProfId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV15cCapacidadProductivaAuxDepId) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxDepId] >= @AV15cCapacidadProductivaAuxDepId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16cCapacidadProductivaAuxPorcent) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxPorcent] >= @AV16cCapacidadProductivaAuxPorcent)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV17cCapacidadProductivaAuxHoras) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxHoras] >= @AV17cCapacidadProductivaAuxHoras)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18cCapacidadProductivaAuxDepNombre)) )
         {
            AddWhere(sWhereString, "([CapacidadProductivaAuxDepNombr] like @lV18cCapacidadProductivaAuxDepNombre)");
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
                     return conditional_H00H02(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00H03(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00H02;
          prmH00H02 = new Object[] {
          new ParDef("@AV6cCapacidadProductivaAuxId",GXType.Decimal,18,0) ,
          new ParDef("@AV9cCapacidadProductivaAuxCant",GXType.Decimal,12,0) ,
          new ParDef("@lV14cCapacidadProductivaAuxProfId",GXType.NChar,20,0) ,
          new ParDef("@AV15cCapacidadProductivaAuxDepId",GXType.Decimal,18,0) ,
          new ParDef("@AV16cCapacidadProductivaAuxPorcent",GXType.Decimal,6,2) ,
          new ParDef("@AV17cCapacidadProductivaAuxHoras",GXType.Decimal,18,2) ,
          new ParDef("@lV18cCapacidadProductivaAuxDepNombre",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00H03;
          prmH00H03 = new Object[] {
          new ParDef("@AV6cCapacidadProductivaAuxId",GXType.Decimal,18,0) ,
          new ParDef("@AV9cCapacidadProductivaAuxCant",GXType.Decimal,12,0) ,
          new ParDef("@lV14cCapacidadProductivaAuxProfId",GXType.NChar,20,0) ,
          new ParDef("@AV15cCapacidadProductivaAuxDepId",GXType.Decimal,18,0) ,
          new ParDef("@AV16cCapacidadProductivaAuxPorcent",GXType.Decimal,6,2) ,
          new ParDef("@AV17cCapacidadProductivaAuxHoras",GXType.Decimal,18,2) ,
          new ParDef("@lV18cCapacidadProductivaAuxDepNombre",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00H02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00H02,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00H03", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00H03,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx03c1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03c1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03c1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pMudanzaId ,
                           out short aP1_pItemCargaId )
      {
         this.AV8pMudanzaId = aP0_pMudanzaId;
         this.AV9pItemCargaId = 0 ;
         ExecutePrivate();
         aP1_pItemCargaId=this.AV9pItemCargaId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCitemcargaembalaje = new GXCheckbox();
         chkavCitemcargaelevacion = new GXCheckbox();
         chkItemCargaEmbalaje = new GXCheckbox();
         chkItemCargaElevacion = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pMudanzaId");
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
               gxfirstwebparm = GetFirstPar( "pMudanzaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pMudanzaId");
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
               AV8pMudanzaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8pMudanzaId", StringUtil.LTrimStr( (decimal)(AV8pMudanzaId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9pItemCargaId = (short)(Math.Round(NumberUtil.Val( GetPar( "pItemCargaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9pItemCargaId", StringUtil.LTrimStr( (decimal)(AV9pItemCargaId), 4, 0));
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
         AV6cItemCargaId = (short)(Math.Round(NumberUtil.Val( GetPar( "cItemCargaId"), "."), 18, MidpointRounding.ToEven));
         AV7cItemCargaCantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "cItemCargaCantidad"), "."), 18, MidpointRounding.ToEven));
         AV11cItemCargaEmbCant = (short)(Math.Round(NumberUtil.Val( GetPar( "cItemCargaEmbCant"), "."), 18, MidpointRounding.ToEven));
         AV12cItemCargaElevCant = (short)(Math.Round(NumberUtil.Val( GetPar( "cItemCargaElevCant"), "."), 18, MidpointRounding.ToEven));
         AV13cItemCargaEmbalaje = StringUtil.StrToBool( GetPar( "cItemCargaEmbalaje"));
         AV14cItemCargaElevacion = StringUtil.StrToBool( GetPar( "cItemCargaElevacion"));
         AV8pMudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "pMudanzaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, AV8pMudanzaId) ;
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
         PAE32( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTE32( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03c1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pMudanzaId,18,0)),UrlEncode(StringUtil.LTrimStr(AV9pItemCargaId,4,0))}, new string[] {"pMudanzaId","pItemCargaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCITEMCARGAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cItemCargaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCITEMCARGACANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cItemCargaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCITEMCARGAEMBCANT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cItemCargaEmbCant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCITEMCARGAELEVCANT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cItemCargaElevCant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCITEMCARGAEMBALAJE", StringUtil.BoolToStr( AV13cItemCargaEmbalaje));
         GxWebStd.gx_hidden_field( context, "GXH_vCITEMCARGAELEVACION", StringUtil.BoolToStr( AV14cItemCargaElevacion));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8pMudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPITEMCARGAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pItemCargaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ITEMCARGAIDFILTERCONTAINER_Class", StringUtil.RTrim( divItemcargaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ITEMCARGACANTIDADFILTERCONTAINER_Class", StringUtil.RTrim( divItemcargacantidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ITEMCARGAEMBCANTFILTERCONTAINER_Class", StringUtil.RTrim( divItemcargaembcantfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ITEMCARGAELEVCANTFILTERCONTAINER_Class", StringUtil.RTrim( divItemcargaelevcantfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ITEMCARGAEMBALAJEFILTERCONTAINER_Class", StringUtil.RTrim( divItemcargaembalajefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ITEMCARGAELEVACIONFILTERCONTAINER_Class", StringUtil.RTrim( divItemcargaelevacionfiltercontainer_Class));
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
            WEE32( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTE32( ) ;
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
         return formatLink("gx03c1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pMudanzaId,18,0)),UrlEncode(StringUtil.LTrimStr(AV9pItemCargaId,4,0))}, new string[] {"pMudanzaId","pItemCargaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03C1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Carga", "") ;
      }

      protected void WBE30( )
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
            GxWebStd.gx_div_start( context, divItemcargaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divItemcargaidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblitemcargaidfilter_Internalname, context.GetMessage( "Item Carga Id", ""), "", "", lblLblitemcargaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11e31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03C1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCitemcargaid_Internalname, context.GetMessage( "Item Carga Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCitemcargaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cItemCargaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCitemcargaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cItemCargaId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cItemCargaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCitemcargaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCitemcargaid_Visible, edtavCitemcargaid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03C1.htm");
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
            GxWebStd.gx_div_start( context, divItemcargacantidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divItemcargacantidadfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblitemcargacantidadfilter_Internalname, context.GetMessage( "Item Carga Cantidad", ""), "", "", lblLblitemcargacantidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12e31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03C1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCitemcargacantidad_Internalname, context.GetMessage( "Item Carga Cantidad", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCitemcargacantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cItemCargaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCitemcargacantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cItemCargaCantidad), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cItemCargaCantidad), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCitemcargacantidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCitemcargacantidad_Visible, edtavCitemcargacantidad_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03C1.htm");
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
            GxWebStd.gx_div_start( context, divItemcargaembcantfiltercontainer_Internalname, 1, 0, "px", 0, "px", divItemcargaembcantfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblitemcargaembcantfilter_Internalname, context.GetMessage( "Item Carga Emb Cant", ""), "", "", lblLblitemcargaembcantfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13e31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03C1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCitemcargaembcant_Internalname, context.GetMessage( "Item Carga Emb Cant", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCitemcargaembcant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cItemCargaEmbCant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCitemcargaembcant_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cItemCargaEmbCant), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cItemCargaEmbCant), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCitemcargaembcant_Jsonclick, 0, "Attribute", "", "", "", "", edtavCitemcargaembcant_Visible, edtavCitemcargaembcant_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03C1.htm");
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
            GxWebStd.gx_div_start( context, divItemcargaelevcantfiltercontainer_Internalname, 1, 0, "px", 0, "px", divItemcargaelevcantfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblitemcargaelevcantfilter_Internalname, context.GetMessage( "Item Carga Elev Cant", ""), "", "", lblLblitemcargaelevcantfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14e31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03C1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCitemcargaelevcant_Internalname, context.GetMessage( "Item Carga Elev Cant", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCitemcargaelevcant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cItemCargaElevCant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCitemcargaelevcant_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cItemCargaElevCant), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cItemCargaElevCant), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCitemcargaelevcant_Jsonclick, 0, "Attribute", "", "", "", "", edtavCitemcargaelevcant_Visible, edtavCitemcargaelevcant_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03C1.htm");
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
            GxWebStd.gx_div_start( context, divItemcargaembalajefiltercontainer_Internalname, 1, 0, "px", 0, "px", divItemcargaembalajefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblitemcargaembalajefilter_Internalname, context.GetMessage( "Item Carga Embalaje", ""), "", "", lblLblitemcargaembalajefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15e31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03C1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCitemcargaembalaje_Internalname, context.GetMessage( "Item Carga Embalaje", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCitemcargaembalaje_Internalname, StringUtil.BoolToStr( AV13cItemCargaEmbalaje), "", context.GetMessage( "Item Carga Embalaje", ""), chkavCitemcargaembalaje.Visible, chkavCitemcargaembalaje.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_div_start( context, divItemcargaelevacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divItemcargaelevacionfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblitemcargaelevacionfilter_Internalname, context.GetMessage( "Item Carga Elevacion", ""), "", "", lblLblitemcargaelevacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16e31_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03C1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCitemcargaelevacion_Internalname, context.GetMessage( "Item Carga Elevacion", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCitemcargaelevacion_Internalname, StringUtil.BoolToStr( AV14cItemCargaElevacion), "", context.GetMessage( "Item Carga Elevacion", ""), chkavCitemcargaelevacion.Visible, chkavCitemcargaelevacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17e31_client"+"'", TempTags, "", 2, "HLP_Gx03C1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03C1.htm");
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

      protected void STARTE32( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Carga", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPE30( ) ;
      }

      protected void WSE32( )
      {
         STARTE32( ) ;
         EVTE32( ) ;
      }

      protected void EVTE32( )
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
                              A751ItemCargaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtItemCargaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A753ItemCargaCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtItemCargaCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A813ItemCargaEmbCant = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtItemCargaEmbCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n813ItemCargaEmbCant = false;
                              A814ItemCargaElevCant = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtItemCargaElevCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n814ItemCargaElevCant = false;
                              A815ItemCargaEmbalaje = StringUtil.StrToBool( cgiGet( chkItemCargaEmbalaje_Internalname));
                              A816ItemCargaElevacion = StringUtil.StrToBool( cgiGet( chkItemCargaElevacion_Internalname));
                              A735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18E32 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19E32 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Citemcargaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cItemCargaId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Citemcargacantidad Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGACANTIDAD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cItemCargaCantidad )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Citemcargaembcant Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGAEMBCANT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cItemCargaEmbCant )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Citemcargaelevcant Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGAELEVCANT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cItemCargaElevCant )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Citemcargaembalaje Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCITEMCARGAEMBALAJE")) != AV13cItemCargaEmbalaje )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Citemcargaelevacion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCITEMCARGAELEVACION")) != AV14cItemCargaElevacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20E32 ();
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

      protected void WEE32( )
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

      protected void PAE32( )
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
                                        short AV6cItemCargaId ,
                                        short AV7cItemCargaCantidad ,
                                        short AV11cItemCargaEmbCant ,
                                        short AV12cItemCargaElevCant ,
                                        bool AV13cItemCargaEmbalaje ,
                                        bool AV14cItemCargaElevacion ,
                                        long AV8pMudanzaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFE32( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ITEMCARGAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A751ItemCargaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ITEMCARGAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A751ItemCargaId), 4, 0, ".", "")));
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
         AV13cItemCargaEmbalaje = StringUtil.StrToBool( StringUtil.BoolToStr( AV13cItemCargaEmbalaje));
         AssignAttri("", false, "AV13cItemCargaEmbalaje", AV13cItemCargaEmbalaje);
         AV14cItemCargaElevacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV14cItemCargaElevacion));
         AssignAttri("", false, "AV14cItemCargaElevacion", AV14cItemCargaElevacion);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFE32( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFE32( )
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
                                                 AV7cItemCargaCantidad ,
                                                 AV11cItemCargaEmbCant ,
                                                 AV12cItemCargaElevCant ,
                                                 AV13cItemCargaEmbalaje ,
                                                 AV14cItemCargaElevacion ,
                                                 A753ItemCargaCantidad ,
                                                 A813ItemCargaEmbCant ,
                                                 A814ItemCargaElevCant ,
                                                 A815ItemCargaEmbalaje ,
                                                 A816ItemCargaElevacion ,
                                                 AV8pMudanzaId ,
                                                 AV6cItemCargaId ,
                                                 A735MudanzaId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H00E32 */
            pr_default.execute(0, new Object[] {AV8pMudanzaId, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A735MudanzaId = H00E32_A735MudanzaId[0];
               A816ItemCargaElevacion = H00E32_A816ItemCargaElevacion[0];
               A815ItemCargaEmbalaje = H00E32_A815ItemCargaEmbalaje[0];
               A814ItemCargaElevCant = H00E32_A814ItemCargaElevCant[0];
               n814ItemCargaElevCant = H00E32_n814ItemCargaElevCant[0];
               A813ItemCargaEmbCant = H00E32_A813ItemCargaEmbCant[0];
               n813ItemCargaEmbCant = H00E32_n813ItemCargaEmbCant[0];
               A753ItemCargaCantidad = H00E32_A753ItemCargaCantidad[0];
               A751ItemCargaId = H00E32_A751ItemCargaId[0];
               /* Execute user event: Load */
               E19E32 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBE30( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesE32( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ITEMCARGAID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A751ItemCargaId), "ZZZ9"), context));
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
                                              AV7cItemCargaCantidad ,
                                              AV11cItemCargaEmbCant ,
                                              AV12cItemCargaElevCant ,
                                              AV13cItemCargaEmbalaje ,
                                              AV14cItemCargaElevacion ,
                                              A753ItemCargaCantidad ,
                                              A813ItemCargaEmbCant ,
                                              A814ItemCargaElevCant ,
                                              A815ItemCargaEmbalaje ,
                                              A816ItemCargaElevacion ,
                                              AV8pMudanzaId ,
                                              AV6cItemCargaId ,
                                              A735MudanzaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00E33 */
         pr_default.execute(1, new Object[] {AV8pMudanzaId, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion});
         GRID1_nRecordCount = H00E33_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, AV8pMudanzaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, AV8pMudanzaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, AV8pMudanzaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, AV8pMudanzaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cItemCargaId, AV7cItemCargaCantidad, AV11cItemCargaEmbCant, AV12cItemCargaElevCant, AV13cItemCargaEmbalaje, AV14cItemCargaElevacion, AV8pMudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtItemCargaId_Enabled = 0;
         edtItemCargaCantidad_Enabled = 0;
         edtItemCargaEmbCant_Enabled = 0;
         edtItemCargaElevCant_Enabled = 0;
         chkItemCargaEmbalaje.Enabled = 0;
         chkItemCargaElevacion.Enabled = 0;
         edtMudanzaId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPE30( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18E32 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCitemcargaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCitemcargaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCITEMCARGAID");
               GX_FocusControl = edtavCitemcargaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cItemCargaId = 0;
               AssignAttri("", false, "AV6cItemCargaId", StringUtil.LTrimStr( (decimal)(AV6cItemCargaId), 4, 0));
            }
            else
            {
               AV6cItemCargaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCitemcargaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cItemCargaId", StringUtil.LTrimStr( (decimal)(AV6cItemCargaId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCitemcargacantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCitemcargacantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCITEMCARGACANTIDAD");
               GX_FocusControl = edtavCitemcargacantidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cItemCargaCantidad = 0;
               AssignAttri("", false, "AV7cItemCargaCantidad", StringUtil.LTrimStr( (decimal)(AV7cItemCargaCantidad), 4, 0));
            }
            else
            {
               AV7cItemCargaCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCitemcargacantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cItemCargaCantidad", StringUtil.LTrimStr( (decimal)(AV7cItemCargaCantidad), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCitemcargaembcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCitemcargaembcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCITEMCARGAEMBCANT");
               GX_FocusControl = edtavCitemcargaembcant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cItemCargaEmbCant = 0;
               AssignAttri("", false, "AV11cItemCargaEmbCant", StringUtil.LTrimStr( (decimal)(AV11cItemCargaEmbCant), 4, 0));
            }
            else
            {
               AV11cItemCargaEmbCant = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCitemcargaembcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cItemCargaEmbCant", StringUtil.LTrimStr( (decimal)(AV11cItemCargaEmbCant), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCitemcargaelevcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCitemcargaelevcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCITEMCARGAELEVCANT");
               GX_FocusControl = edtavCitemcargaelevcant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cItemCargaElevCant = 0;
               AssignAttri("", false, "AV12cItemCargaElevCant", StringUtil.LTrimStr( (decimal)(AV12cItemCargaElevCant), 4, 0));
            }
            else
            {
               AV12cItemCargaElevCant = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCitemcargaelevcant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cItemCargaElevCant", StringUtil.LTrimStr( (decimal)(AV12cItemCargaElevCant), 4, 0));
            }
            AV13cItemCargaEmbalaje = StringUtil.StrToBool( cgiGet( chkavCitemcargaembalaje_Internalname));
            AssignAttri("", false, "AV13cItemCargaEmbalaje", AV13cItemCargaEmbalaje);
            AV14cItemCargaElevacion = StringUtil.StrToBool( cgiGet( chkavCitemcargaelevacion_Internalname));
            AssignAttri("", false, "AV14cItemCargaElevacion", AV14cItemCargaElevacion);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cItemCargaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGACANTIDAD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cItemCargaCantidad )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGAEMBCANT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cItemCargaEmbCant )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCITEMCARGAELEVCANT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cItemCargaElevCant )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCITEMCARGAEMBALAJE")) != AV13cItemCargaEmbalaje )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCITEMCARGAELEVACION")) != AV14cItemCargaElevacion )
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
         E18E32 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18E32( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Carga", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV10ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19E32( )
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
         E20E32 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20E32( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9pItemCargaId = A751ItemCargaId;
         AssignAttri("", false, "AV9pItemCargaId", StringUtil.LTrimStr( (decimal)(AV9pItemCargaId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV9pItemCargaId});
         context.setWebReturnParmsMetadata(new Object[] {"AV9pItemCargaId"});
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
         AV8pMudanzaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8pMudanzaId", StringUtil.LTrimStr( (decimal)(AV8pMudanzaId), 18, 0));
         AV9pItemCargaId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV9pItemCargaId", StringUtil.LTrimStr( (decimal)(AV9pItemCargaId), 4, 0));
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
         PAE32( ) ;
         WSE32( ) ;
         WEE32( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021261952", true, true, false);
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
         context.AddJavascriptSource("gx03c1.js", "?202673021261952", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtItemCargaId_Internalname = "ITEMCARGAID_"+sGXsfl_74_idx;
         edtItemCargaCantidad_Internalname = "ITEMCARGACANTIDAD_"+sGXsfl_74_idx;
         edtItemCargaEmbCant_Internalname = "ITEMCARGAEMBCANT_"+sGXsfl_74_idx;
         edtItemCargaElevCant_Internalname = "ITEMCARGAELEVCANT_"+sGXsfl_74_idx;
         chkItemCargaEmbalaje_Internalname = "ITEMCARGAEMBALAJE_"+sGXsfl_74_idx;
         chkItemCargaElevacion_Internalname = "ITEMCARGAELEVACION_"+sGXsfl_74_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtItemCargaId_Internalname = "ITEMCARGAID_"+sGXsfl_74_fel_idx;
         edtItemCargaCantidad_Internalname = "ITEMCARGACANTIDAD_"+sGXsfl_74_fel_idx;
         edtItemCargaEmbCant_Internalname = "ITEMCARGAEMBCANT_"+sGXsfl_74_fel_idx;
         edtItemCargaElevCant_Internalname = "ITEMCARGAELEVCANT_"+sGXsfl_74_fel_idx;
         chkItemCargaEmbalaje_Internalname = "ITEMCARGAEMBALAJE_"+sGXsfl_74_fel_idx;
         chkItemCargaElevacion_Internalname = "ITEMCARGAELEVACION_"+sGXsfl_74_fel_idx;
         edtMudanzaId_Internalname = "MUDANZAID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBE30( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A751ItemCargaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtItemCargaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A751ItemCargaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A751ItemCargaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtItemCargaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtItemCargaCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A753ItemCargaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A753ItemCargaCantidad), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtItemCargaCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtItemCargaEmbCant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A813ItemCargaEmbCant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A813ItemCargaEmbCant), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtItemCargaEmbCant_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtItemCargaElevCant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A814ItemCargaElevCant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A814ItemCargaElevCant), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtItemCargaElevCant_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ITEMCARGAEMBALAJE_" + sGXsfl_74_idx;
            chkItemCargaEmbalaje.Name = GXCCtl;
            chkItemCargaEmbalaje.WebTags = "";
            chkItemCargaEmbalaje.Caption = "";
            AssignProp("", false, chkItemCargaEmbalaje_Internalname, "TitleCaption", chkItemCargaEmbalaje.Caption, !bGXsfl_74_Refreshing);
            chkItemCargaEmbalaje.CheckedValue = "false";
            A815ItemCargaEmbalaje = StringUtil.StrToBool( StringUtil.BoolToStr( A815ItemCargaEmbalaje));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkItemCargaEmbalaje_Internalname,StringUtil.BoolToStr( A815ItemCargaEmbalaje),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ITEMCARGAELEVACION_" + sGXsfl_74_idx;
            chkItemCargaElevacion.Name = GXCCtl;
            chkItemCargaElevacion.WebTags = "";
            chkItemCargaElevacion.Caption = "";
            AssignProp("", false, chkItemCargaElevacion_Internalname, "TitleCaption", chkItemCargaElevacion.Caption, !bGXsfl_74_Refreshing);
            chkItemCargaElevacion.CheckedValue = "false";
            A816ItemCargaElevacion = StringUtil.StrToBool( StringUtil.BoolToStr( A816ItemCargaElevacion));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkItemCargaElevacion_Internalname,StringUtil.BoolToStr( A816ItemCargaElevacion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMudanzaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMudanzaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesE32( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         chkavCitemcargaembalaje.Name = "vCITEMCARGAEMBALAJE";
         chkavCitemcargaembalaje.WebTags = "";
         chkavCitemcargaembalaje.Caption = context.GetMessage( "Item Carga Embalaje", "");
         AssignProp("", false, chkavCitemcargaembalaje_Internalname, "TitleCaption", chkavCitemcargaembalaje.Caption, true);
         chkavCitemcargaembalaje.CheckedValue = "false";
         AV13cItemCargaEmbalaje = StringUtil.StrToBool( StringUtil.BoolToStr( AV13cItemCargaEmbalaje));
         AssignAttri("", false, "AV13cItemCargaEmbalaje", AV13cItemCargaEmbalaje);
         chkavCitemcargaelevacion.Name = "vCITEMCARGAELEVACION";
         chkavCitemcargaelevacion.WebTags = "";
         chkavCitemcargaelevacion.Caption = context.GetMessage( "Item Carga Elevacion", "");
         AssignProp("", false, chkavCitemcargaelevacion_Internalname, "TitleCaption", chkavCitemcargaelevacion.Caption, true);
         chkavCitemcargaelevacion.CheckedValue = "false";
         AV14cItemCargaElevacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV14cItemCargaElevacion));
         AssignAttri("", false, "AV14cItemCargaElevacion", AV14cItemCargaElevacion);
         GXCCtl = "ITEMCARGAEMBALAJE_" + sGXsfl_74_idx;
         chkItemCargaEmbalaje.Name = GXCCtl;
         chkItemCargaEmbalaje.WebTags = "";
         chkItemCargaEmbalaje.Caption = "";
         AssignProp("", false, chkItemCargaEmbalaje_Internalname, "TitleCaption", chkItemCargaEmbalaje.Caption, !bGXsfl_74_Refreshing);
         chkItemCargaEmbalaje.CheckedValue = "false";
         A815ItemCargaEmbalaje = StringUtil.StrToBool( StringUtil.BoolToStr( A815ItemCargaEmbalaje));
         GXCCtl = "ITEMCARGAELEVACION_" + sGXsfl_74_idx;
         chkItemCargaElevacion.Name = GXCCtl;
         chkItemCargaElevacion.WebTags = "";
         chkItemCargaElevacion.Caption = "";
         AssignProp("", false, chkItemCargaElevacion_Internalname, "TitleCaption", chkItemCargaElevacion.Caption, !bGXsfl_74_Refreshing);
         chkItemCargaElevacion.CheckedValue = "false";
         A816ItemCargaElevacion = StringUtil.StrToBool( StringUtil.BoolToStr( A816ItemCargaElevacion));
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
            context.SendWebValue( context.GetMessage( "Carga Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Carga Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Emb Cant", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Elev Cant", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Carga Embalaje", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Carga Elevacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A751ItemCargaId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A753ItemCargaCantidad), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A813ItemCargaEmbCant), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A814ItemCargaElevCant), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A815ItemCargaEmbalaje)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A816ItemCargaElevacion)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, ".", ""))));
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
         lblLblitemcargaidfilter_Internalname = "LBLITEMCARGAIDFILTER";
         edtavCitemcargaid_Internalname = "vCITEMCARGAID";
         divItemcargaidfiltercontainer_Internalname = "ITEMCARGAIDFILTERCONTAINER";
         lblLblitemcargacantidadfilter_Internalname = "LBLITEMCARGACANTIDADFILTER";
         edtavCitemcargacantidad_Internalname = "vCITEMCARGACANTIDAD";
         divItemcargacantidadfiltercontainer_Internalname = "ITEMCARGACANTIDADFILTERCONTAINER";
         lblLblitemcargaembcantfilter_Internalname = "LBLITEMCARGAEMBCANTFILTER";
         edtavCitemcargaembcant_Internalname = "vCITEMCARGAEMBCANT";
         divItemcargaembcantfiltercontainer_Internalname = "ITEMCARGAEMBCANTFILTERCONTAINER";
         lblLblitemcargaelevcantfilter_Internalname = "LBLITEMCARGAELEVCANTFILTER";
         edtavCitemcargaelevcant_Internalname = "vCITEMCARGAELEVCANT";
         divItemcargaelevcantfiltercontainer_Internalname = "ITEMCARGAELEVCANTFILTERCONTAINER";
         lblLblitemcargaembalajefilter_Internalname = "LBLITEMCARGAEMBALAJEFILTER";
         chkavCitemcargaembalaje_Internalname = "vCITEMCARGAEMBALAJE";
         divItemcargaembalajefiltercontainer_Internalname = "ITEMCARGAEMBALAJEFILTERCONTAINER";
         lblLblitemcargaelevacionfilter_Internalname = "LBLITEMCARGAELEVACIONFILTER";
         chkavCitemcargaelevacion_Internalname = "vCITEMCARGAELEVACION";
         divItemcargaelevacionfiltercontainer_Internalname = "ITEMCARGAELEVACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtItemCargaId_Internalname = "ITEMCARGAID";
         edtItemCargaCantidad_Internalname = "ITEMCARGACANTIDAD";
         edtItemCargaEmbCant_Internalname = "ITEMCARGAEMBCANT";
         edtItemCargaElevCant_Internalname = "ITEMCARGAELEVCANT";
         chkItemCargaEmbalaje_Internalname = "ITEMCARGAEMBALAJE";
         chkItemCargaElevacion_Internalname = "ITEMCARGAELEVACION";
         edtMudanzaId_Internalname = "MUDANZAID";
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
         chkavCitemcargaelevacion.Caption = context.GetMessage( "Item Carga Elevacion", "");
         chkavCitemcargaembalaje.Caption = context.GetMessage( "Item Carga Embalaje", "");
         edtMudanzaId_Jsonclick = "";
         chkItemCargaElevacion.Caption = "";
         chkItemCargaEmbalaje.Caption = "";
         edtItemCargaElevCant_Jsonclick = "";
         edtItemCargaEmbCant_Jsonclick = "";
         edtItemCargaCantidad_Jsonclick = "";
         edtItemCargaId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtMudanzaId_Enabled = 0;
         chkItemCargaElevacion.Enabled = 0;
         chkItemCargaEmbalaje.Enabled = 0;
         edtItemCargaElevCant_Enabled = 0;
         edtItemCargaEmbCant_Enabled = 0;
         edtItemCargaCantidad_Enabled = 0;
         edtItemCargaId_Enabled = 0;
         chkavCitemcargaelevacion.Enabled = 1;
         chkavCitemcargaelevacion.Visible = 1;
         chkavCitemcargaembalaje.Enabled = 1;
         chkavCitemcargaembalaje.Visible = 1;
         edtavCitemcargaelevcant_Jsonclick = "";
         edtavCitemcargaelevcant_Enabled = 1;
         edtavCitemcargaelevcant_Visible = 1;
         edtavCitemcargaembcant_Jsonclick = "";
         edtavCitemcargaembcant_Enabled = 1;
         edtavCitemcargaembcant_Visible = 1;
         edtavCitemcargacantidad_Jsonclick = "";
         edtavCitemcargacantidad_Enabled = 1;
         edtavCitemcargacantidad_Visible = 1;
         edtavCitemcargaid_Jsonclick = "";
         edtavCitemcargaid_Enabled = 1;
         edtavCitemcargaid_Visible = 1;
         divItemcargaelevacionfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divItemcargaembalajefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divItemcargaelevcantfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divItemcargaembcantfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divItemcargacantidadfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divItemcargaidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Carga", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cItemCargaId',fld:'vCITEMCARGAID',pic:'ZZZ9',type:'int'},{av:'AV7cItemCargaCantidad',fld:'vCITEMCARGACANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV11cItemCargaEmbCant',fld:'vCITEMCARGAEMBCANT',pic:'ZZZ9',type:'int'},{av:'AV12cItemCargaElevCant',fld:'vCITEMCARGAELEVCANT',pic:'ZZZ9',type:'int'},{av:'AV8pMudanzaId',fld:'vPMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13cItemCargaEmbalaje',fld:'vCITEMCARGAEMBALAJE',pic:'',type:'boolean'},{av:'AV14cItemCargaElevacion',fld:'vCITEMCARGAELEVACION',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17E31',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLITEMCARGAIDFILTER.CLICK","{handler:'E11E31',iparms:[{av:'divItemcargaidfiltercontainer_Class',ctrl:'ITEMCARGAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLITEMCARGAIDFILTER.CLICK",",oparms:[{av:'divItemcargaidfiltercontainer_Class',ctrl:'ITEMCARGAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCitemcargaid_Visible',ctrl:'vCITEMCARGAID',prop:'Visible'}]}");
         setEventMetadata("LBLITEMCARGACANTIDADFILTER.CLICK","{handler:'E12E31',iparms:[{av:'divItemcargacantidadfiltercontainer_Class',ctrl:'ITEMCARGACANTIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLITEMCARGACANTIDADFILTER.CLICK",",oparms:[{av:'divItemcargacantidadfiltercontainer_Class',ctrl:'ITEMCARGACANTIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCitemcargacantidad_Visible',ctrl:'vCITEMCARGACANTIDAD',prop:'Visible'}]}");
         setEventMetadata("LBLITEMCARGAEMBCANTFILTER.CLICK","{handler:'E13E31',iparms:[{av:'divItemcargaembcantfiltercontainer_Class',ctrl:'ITEMCARGAEMBCANTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLITEMCARGAEMBCANTFILTER.CLICK",",oparms:[{av:'divItemcargaembcantfiltercontainer_Class',ctrl:'ITEMCARGAEMBCANTFILTERCONTAINER',prop:'Class'},{av:'edtavCitemcargaembcant_Visible',ctrl:'vCITEMCARGAEMBCANT',prop:'Visible'}]}");
         setEventMetadata("LBLITEMCARGAELEVCANTFILTER.CLICK","{handler:'E14E31',iparms:[{av:'divItemcargaelevcantfiltercontainer_Class',ctrl:'ITEMCARGAELEVCANTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLITEMCARGAELEVCANTFILTER.CLICK",",oparms:[{av:'divItemcargaelevcantfiltercontainer_Class',ctrl:'ITEMCARGAELEVCANTFILTERCONTAINER',prop:'Class'},{av:'edtavCitemcargaelevcant_Visible',ctrl:'vCITEMCARGAELEVCANT',prop:'Visible'}]}");
         setEventMetadata("LBLITEMCARGAEMBALAJEFILTER.CLICK","{handler:'E15E31',iparms:[{av:'divItemcargaembalajefiltercontainer_Class',ctrl:'ITEMCARGAEMBALAJEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLITEMCARGAEMBALAJEFILTER.CLICK",",oparms:[{av:'divItemcargaembalajefiltercontainer_Class',ctrl:'ITEMCARGAEMBALAJEFILTERCONTAINER',prop:'Class'},{av:'chkavCitemcargaembalaje.Visible',ctrl:'vCITEMCARGAEMBALAJE',prop:'Visible'}]}");
         setEventMetadata("LBLITEMCARGAELEVACIONFILTER.CLICK","{handler:'E16E31',iparms:[{av:'divItemcargaelevacionfiltercontainer_Class',ctrl:'ITEMCARGAELEVACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLITEMCARGAELEVACIONFILTER.CLICK",",oparms:[{av:'divItemcargaelevacionfiltercontainer_Class',ctrl:'ITEMCARGAELEVACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCitemcargaelevacion.Visible',ctrl:'vCITEMCARGAELEVACION',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20E32',iparms:[{av:'A751ItemCargaId',fld:'ITEMCARGAID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV9pItemCargaId',fld:'vPITEMCARGAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cItemCargaId',fld:'vCITEMCARGAID',pic:'ZZZ9',type:'int'},{av:'AV7cItemCargaCantidad',fld:'vCITEMCARGACANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV11cItemCargaEmbCant',fld:'vCITEMCARGAEMBCANT',pic:'ZZZ9',type:'int'},{av:'AV12cItemCargaElevCant',fld:'vCITEMCARGAELEVCANT',pic:'ZZZ9',type:'int'},{av:'AV8pMudanzaId',fld:'vPMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13cItemCargaEmbalaje',fld:'vCITEMCARGAEMBALAJE',pic:'',type:'boolean'},{av:'AV14cItemCargaElevacion',fld:'vCITEMCARGAELEVACION',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cItemCargaId',fld:'vCITEMCARGAID',pic:'ZZZ9',type:'int'},{av:'AV7cItemCargaCantidad',fld:'vCITEMCARGACANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV11cItemCargaEmbCant',fld:'vCITEMCARGAEMBCANT',pic:'ZZZ9',type:'int'},{av:'AV12cItemCargaElevCant',fld:'vCITEMCARGAELEVCANT',pic:'ZZZ9',type:'int'},{av:'AV8pMudanzaId',fld:'vPMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13cItemCargaEmbalaje',fld:'vCITEMCARGAEMBALAJE',pic:'',type:'boolean'},{av:'AV14cItemCargaElevacion',fld:'vCITEMCARGAELEVACION',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cItemCargaId',fld:'vCITEMCARGAID',pic:'ZZZ9',type:'int'},{av:'AV7cItemCargaCantidad',fld:'vCITEMCARGACANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV11cItemCargaEmbCant',fld:'vCITEMCARGAEMBCANT',pic:'ZZZ9',type:'int'},{av:'AV12cItemCargaElevCant',fld:'vCITEMCARGAELEVCANT',pic:'ZZZ9',type:'int'},{av:'AV8pMudanzaId',fld:'vPMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13cItemCargaEmbalaje',fld:'vCITEMCARGAEMBALAJE',pic:'',type:'boolean'},{av:'AV14cItemCargaElevacion',fld:'vCITEMCARGAELEVACION',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cItemCargaId',fld:'vCITEMCARGAID',pic:'ZZZ9',type:'int'},{av:'AV7cItemCargaCantidad',fld:'vCITEMCARGACANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV11cItemCargaEmbCant',fld:'vCITEMCARGAEMBCANT',pic:'ZZZ9',type:'int'},{av:'AV12cItemCargaElevCant',fld:'vCITEMCARGAELEVCANT',pic:'ZZZ9',type:'int'},{av:'AV8pMudanzaId',fld:'vPMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13cItemCargaEmbalaje',fld:'vCITEMCARGAEMBALAJE',pic:'',type:'boolean'},{av:'AV14cItemCargaElevacion',fld:'vCITEMCARGAELEVACION',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Mudanzaid',iparms:[]");
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
         lblLblitemcargaidfilter_Jsonclick = "";
         TempTags = "";
         lblLblitemcargacantidadfilter_Jsonclick = "";
         lblLblitemcargaembcantfilter_Jsonclick = "";
         lblLblitemcargaelevcantfilter_Jsonclick = "";
         lblLblitemcargaembalajefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblitemcargaelevacionfilter_Jsonclick = "";
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
         H00E32_A735MudanzaId = new long[1] ;
         H00E32_A816ItemCargaElevacion = new bool[] {false} ;
         H00E32_A815ItemCargaEmbalaje = new bool[] {false} ;
         H00E32_A814ItemCargaElevCant = new short[1] ;
         H00E32_n814ItemCargaElevCant = new bool[] {false} ;
         H00E32_A813ItemCargaEmbCant = new short[1] ;
         H00E32_n813ItemCargaEmbCant = new bool[] {false} ;
         H00E32_A753ItemCargaCantidad = new short[1] ;
         H00E32_A751ItemCargaId = new short[1] ;
         H00E33_AGRID1_nRecordCount = new long[1] ;
         AV10ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03c1__default(),
            new Object[][] {
                new Object[] {
               H00E32_A735MudanzaId, H00E32_A816ItemCargaElevacion, H00E32_A815ItemCargaEmbalaje, H00E32_A814ItemCargaElevCant, H00E32_n814ItemCargaElevCant, H00E32_A813ItemCargaEmbCant, H00E32_n813ItemCargaEmbCant, H00E32_A753ItemCargaCantidad, H00E32_A751ItemCargaId
               }
               , new Object[] {
               H00E33_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9pItemCargaId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cItemCargaId ;
      private short AV7cItemCargaCantidad ;
      private short AV11cItemCargaEmbCant ;
      private short AV12cItemCargaElevCant ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A751ItemCargaId ;
      private short A753ItemCargaCantidad ;
      private short A813ItemCargaEmbCant ;
      private short A814ItemCargaElevCant ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCitemcargaid_Enabled ;
      private int edtavCitemcargaid_Visible ;
      private int edtavCitemcargacantidad_Enabled ;
      private int edtavCitemcargacantidad_Visible ;
      private int edtavCitemcargaembcant_Enabled ;
      private int edtavCitemcargaembcant_Visible ;
      private int edtavCitemcargaelevcant_Enabled ;
      private int edtavCitemcargaelevcant_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtItemCargaId_Enabled ;
      private int edtItemCargaCantidad_Enabled ;
      private int edtItemCargaEmbCant_Enabled ;
      private int edtItemCargaElevCant_Enabled ;
      private int edtMudanzaId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV8pMudanzaId ;
      private long wcpOAV8pMudanzaId ;
      private long GRID1_nFirstRecordOnPage ;
      private long A735MudanzaId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divItemcargaidfiltercontainer_Class ;
      private string divItemcargacantidadfiltercontainer_Class ;
      private string divItemcargaembcantfiltercontainer_Class ;
      private string divItemcargaelevcantfiltercontainer_Class ;
      private string divItemcargaembalajefiltercontainer_Class ;
      private string divItemcargaelevacionfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divItemcargaidfiltercontainer_Internalname ;
      private string lblLblitemcargaidfilter_Internalname ;
      private string lblLblitemcargaidfilter_Jsonclick ;
      private string edtavCitemcargaid_Internalname ;
      private string TempTags ;
      private string edtavCitemcargaid_Jsonclick ;
      private string divItemcargacantidadfiltercontainer_Internalname ;
      private string lblLblitemcargacantidadfilter_Internalname ;
      private string lblLblitemcargacantidadfilter_Jsonclick ;
      private string edtavCitemcargacantidad_Internalname ;
      private string edtavCitemcargacantidad_Jsonclick ;
      private string divItemcargaembcantfiltercontainer_Internalname ;
      private string lblLblitemcargaembcantfilter_Internalname ;
      private string lblLblitemcargaembcantfilter_Jsonclick ;
      private string edtavCitemcargaembcant_Internalname ;
      private string edtavCitemcargaembcant_Jsonclick ;
      private string divItemcargaelevcantfiltercontainer_Internalname ;
      private string lblLblitemcargaelevcantfilter_Internalname ;
      private string lblLblitemcargaelevcantfilter_Jsonclick ;
      private string edtavCitemcargaelevcant_Internalname ;
      private string edtavCitemcargaelevcant_Jsonclick ;
      private string divItemcargaembalajefiltercontainer_Internalname ;
      private string lblLblitemcargaembalajefilter_Internalname ;
      private string lblLblitemcargaembalajefilter_Jsonclick ;
      private string chkavCitemcargaembalaje_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divItemcargaelevacionfiltercontainer_Internalname ;
      private string lblLblitemcargaelevacionfilter_Internalname ;
      private string lblLblitemcargaelevacionfilter_Jsonclick ;
      private string chkavCitemcargaelevacion_Internalname ;
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
      private string edtItemCargaId_Internalname ;
      private string edtItemCargaCantidad_Internalname ;
      private string edtItemCargaEmbCant_Internalname ;
      private string edtItemCargaElevCant_Internalname ;
      private string chkItemCargaEmbalaje_Internalname ;
      private string chkItemCargaElevacion_Internalname ;
      private string edtMudanzaId_Internalname ;
      private string AV10ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtItemCargaId_Jsonclick ;
      private string edtItemCargaCantidad_Jsonclick ;
      private string edtItemCargaEmbCant_Jsonclick ;
      private string edtItemCargaElevCant_Jsonclick ;
      private string GXCCtl ;
      private string edtMudanzaId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13cItemCargaEmbalaje ;
      private bool AV14cItemCargaElevacion ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n813ItemCargaEmbCant ;
      private bool n814ItemCargaElevCant ;
      private bool A815ItemCargaEmbalaje ;
      private bool A816ItemCargaElevacion ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCitemcargaembalaje ;
      private GXCheckbox chkavCitemcargaelevacion ;
      private GXCheckbox chkItemCargaEmbalaje ;
      private GXCheckbox chkItemCargaElevacion ;
      private IDataStoreProvider pr_default ;
      private long[] H00E32_A735MudanzaId ;
      private bool[] H00E32_A816ItemCargaElevacion ;
      private bool[] H00E32_A815ItemCargaEmbalaje ;
      private short[] H00E32_A814ItemCargaElevCant ;
      private bool[] H00E32_n814ItemCargaElevCant ;
      private short[] H00E32_A813ItemCargaEmbCant ;
      private bool[] H00E32_n813ItemCargaEmbCant ;
      private short[] H00E32_A753ItemCargaCantidad ;
      private short[] H00E32_A751ItemCargaId ;
      private long[] H00E33_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pItemCargaId ;
   }

   public class gx03c1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00E32( IGxContext context ,
                                             short AV7cItemCargaCantidad ,
                                             short AV11cItemCargaEmbCant ,
                                             short AV12cItemCargaElevCant ,
                                             bool AV13cItemCargaEmbalaje ,
                                             bool AV14cItemCargaElevacion ,
                                             short A753ItemCargaCantidad ,
                                             short A813ItemCargaEmbCant ,
                                             short A814ItemCargaElevCant ,
                                             bool A815ItemCargaEmbalaje ,
                                             bool A816ItemCargaElevacion ,
                                             long AV8pMudanzaId ,
                                             short AV6cItemCargaId ,
                                             long A735MudanzaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MudanzaId], [ItemCargaElevacion], [ItemCargaEmbalaje], [ItemCargaElevCant], [ItemCargaEmbCant], [ItemCargaCantidad], [ItemCargaId]";
         sFromString = " FROM [MudanzaCarga]";
         sOrderString = "";
         AddWhere(sWhereString, "([MudanzaId] = @AV8pMudanzaId and [ItemCargaId] >= @AV6cItemCargaId)");
         if ( ! (0==AV7cItemCargaCantidad) )
         {
            AddWhere(sWhereString, "([ItemCargaCantidad] >= @AV7cItemCargaCantidad)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV11cItemCargaEmbCant) )
         {
            AddWhere(sWhereString, "([ItemCargaEmbCant] >= @AV11cItemCargaEmbCant)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV12cItemCargaElevCant) )
         {
            AddWhere(sWhereString, "([ItemCargaElevCant] >= @AV12cItemCargaElevCant)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV13cItemCargaEmbalaje) )
         {
            AddWhere(sWhereString, "([ItemCargaEmbalaje] >= @AV13cItemCargaEmbalaje)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV14cItemCargaElevacion) )
         {
            AddWhere(sWhereString, "([ItemCargaElevacion] >= @AV14cItemCargaElevacion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [MudanzaId], [ItemCargaId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00E33( IGxContext context ,
                                             short AV7cItemCargaCantidad ,
                                             short AV11cItemCargaEmbCant ,
                                             short AV12cItemCargaElevCant ,
                                             bool AV13cItemCargaEmbalaje ,
                                             bool AV14cItemCargaElevacion ,
                                             short A753ItemCargaCantidad ,
                                             short A813ItemCargaEmbCant ,
                                             short A814ItemCargaElevCant ,
                                             bool A815ItemCargaEmbalaje ,
                                             bool A816ItemCargaElevacion ,
                                             long AV8pMudanzaId ,
                                             short AV6cItemCargaId ,
                                             long A735MudanzaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [MudanzaCarga]";
         AddWhere(sWhereString, "([MudanzaId] = @AV8pMudanzaId and [ItemCargaId] >= @AV6cItemCargaId)");
         if ( ! (0==AV7cItemCargaCantidad) )
         {
            AddWhere(sWhereString, "([ItemCargaCantidad] >= @AV7cItemCargaCantidad)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV11cItemCargaEmbCant) )
         {
            AddWhere(sWhereString, "([ItemCargaEmbCant] >= @AV11cItemCargaEmbCant)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV12cItemCargaElevCant) )
         {
            AddWhere(sWhereString, "([ItemCargaElevCant] >= @AV12cItemCargaElevCant)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV13cItemCargaEmbalaje) )
         {
            AddWhere(sWhereString, "([ItemCargaEmbalaje] >= @AV13cItemCargaEmbalaje)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV14cItemCargaElevacion) )
         {
            AddWhere(sWhereString, "([ItemCargaElevacion] >= @AV14cItemCargaElevacion)");
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
                     return conditional_H00E32(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (bool)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00E33(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (bool)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00E32;
          prmH00E32 = new Object[] {
          new ParDef("@AV8pMudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cItemCargaId",GXType.Int16,4,0) ,
          new ParDef("@AV7cItemCargaCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV11cItemCargaEmbCant",GXType.Int16,4,0) ,
          new ParDef("@AV12cItemCargaElevCant",GXType.Int16,4,0) ,
          new ParDef("@AV13cItemCargaEmbalaje",GXType.Boolean,4,0) ,
          new ParDef("@AV14cItemCargaElevacion",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00E33;
          prmH00E33 = new Object[] {
          new ParDef("@AV8pMudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@AV6cItemCargaId",GXType.Int16,4,0) ,
          new ParDef("@AV7cItemCargaCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV11cItemCargaEmbCant",GXType.Int16,4,0) ,
          new ParDef("@AV12cItemCargaElevCant",GXType.Int16,4,0) ,
          new ParDef("@AV13cItemCargaEmbalaje",GXType.Boolean,4,0) ,
          new ParDef("@AV14cItemCargaElevacion",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00E32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E32,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00E33", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00E33,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx01b0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01b0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01b0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pMailDesignId )
      {
         this.AV13pMailDesignId = 0 ;
         ExecutePrivate();
         aP0_pMailDesignId=this.AV13pMailDesignId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCmaildesigntipo = new GXCombobox();
         cmbavCmaildesignestado = new GXCombobox();
         cmbMailDesignTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pMailDesignId");
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
               gxfirstwebparm = GetFirstPar( "pMailDesignId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pMailDesignId");
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
               AV13pMailDesignId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pMailDesignId", StringUtil.LTrimStr( (decimal)(AV13pMailDesignId), 18, 0));
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
         AV6cMailDesignId = (long)(Math.Round(NumberUtil.Val( GetPar( "cMailDesignId"), "."), 18, MidpointRounding.ToEven));
         cmbavCmaildesigntipo.FromJSonString( GetNextPar( ));
         AV7cMailDesignTipo = GetPar( "cMailDesignTipo");
         AV8cMailId = (long)(Math.Round(NumberUtil.Val( GetPar( "cMailId"), "."), 18, MidpointRounding.ToEven));
         AV9cMailDesignAsunto = GetPar( "cMailDesignAsunto");
         AV10cMailDesignNombReenvio = GetPar( "cMailDesignNombReenvio");
         AV11cMailDesignMailReenviar = GetPar( "cMailDesignMailReenviar");
         cmbavCmaildesignestado.FromJSonString( GetNextPar( ));
         AV12cMailDesignEstado = GetPar( "cMailDesignEstado");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cMailDesignId, AV7cMailDesignTipo, AV8cMailId, AV9cMailDesignAsunto, AV10cMailDesignNombReenvio, AV11cMailDesignMailReenviar, AV12cMailDesignEstado) ;
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
         PA9N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9N2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pMailDesignId,18,0))}, new string[] {"pMailDesignId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDESIGNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDESIGNTIPO", StringUtil.RTrim( AV7cMailDesignTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cMailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDESIGNASUNTO", StringUtil.RTrim( AV9cMailDesignAsunto));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDESIGNNOMBREENVIO", StringUtil.RTrim( AV10cMailDesignNombReenvio));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDESIGNMAILREENVIAR", AV11cMailDesignMailReenviar);
         GxWebStd.gx_hidden_field( context, "GXH_vCMAILDESIGNESTADO", StringUtil.RTrim( AV12cMailDesignEstado));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMAILDESIGNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pMailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNIDFILTERCONTAINER_Class", StringUtil.RTrim( divMaildesignidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divMaildesigntipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divMailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNASUNTOFILTERCONTAINER_Class", StringUtil.RTrim( divMaildesignasuntofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNNOMBREENVIOFILTERCONTAINER_Class", StringUtil.RTrim( divMaildesignnombreenviofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMAILREENVIARFILTERCONTAINER_Class", StringUtil.RTrim( divMaildesignmailreenviarfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divMaildesignestadofiltercontainer_Class));
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
            WE9N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9N2( ) ;
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
         return formatLink("gx01b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pMailDesignId,18,0))}, new string[] {"pMailDesignId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01B0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Mail Design", "") ;
      }

      protected void WB9N0( )
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
            GxWebStd.gx_div_start( context, divMaildesignidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildesignidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildesignidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLblmaildesignidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmaildesignid_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmaildesignid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cMailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCmaildesignid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cMailDesignId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cMailDesignId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmaildesignid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmaildesignid_Visible, edtavCmaildesignid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01B0.htm");
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
            GxWebStd.gx_div_start( context, divMaildesigntipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildesigntipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildesigntipofilter_Internalname, context.GetMessage( "Tipo", ""), "", "", lblLblmaildesigntipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmaildesigntipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmaildesigntipo, cmbavCmaildesigntipo_Internalname, StringUtil.RTrim( AV7cMailDesignTipo), 1, cmbavCmaildesigntipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCmaildesigntipo.Visible, cmbavCmaildesigntipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx01B0.htm");
            cmbavCmaildesigntipo.CurrentValue = StringUtil.RTrim( AV7cMailDesignTipo);
            AssignProp("", false, cmbavCmaildesigntipo_Internalname, "Values", (string)(cmbavCmaildesigntipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divMailidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMailidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmailidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLblmailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmailid_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cMailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCmailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cMailId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cMailId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmailid_Visible, edtavCmailid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01B0.htm");
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
            GxWebStd.gx_div_start( context, divMaildesignasuntofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildesignasuntofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildesignasuntofilter_Internalname, context.GetMessage( "Asunto", ""), "", "", lblLblmaildesignasuntofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmaildesignasunto_Internalname, context.GetMessage( "Asunto", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmaildesignasunto_Internalname, StringUtil.RTrim( AV9cMailDesignAsunto), StringUtil.RTrim( context.localUtil.Format( AV9cMailDesignAsunto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmaildesignasunto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmaildesignasunto_Visible, edtavCmaildesignasunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01B0.htm");
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
            GxWebStd.gx_div_start( context, divMaildesignnombreenviofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildesignnombreenviofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildesignnombreenviofilter_Internalname, context.GetMessage( "Nombre Reenvio", ""), "", "", lblLblmaildesignnombreenviofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmaildesignnombreenvio_Internalname, context.GetMessage( "Nombre Reenvio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmaildesignnombreenvio_Internalname, StringUtil.RTrim( AV10cMailDesignNombReenvio), StringUtil.RTrim( context.localUtil.Format( AV10cMailDesignNombReenvio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmaildesignnombreenvio_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmaildesignnombreenvio_Visible, edtavCmaildesignnombreenvio_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01B0.htm");
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
            GxWebStd.gx_div_start( context, divMaildesignmailreenviarfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildesignmailreenviarfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildesignmailreenviarfilter_Internalname, context.GetMessage( "Mail Reenviar", ""), "", "", lblLblmaildesignmailreenviarfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmaildesignmailreenviar_Internalname, context.GetMessage( "Mail Reenviar", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmaildesignmailreenviar_Internalname, AV11cMailDesignMailReenviar, StringUtil.RTrim( context.localUtil.Format( AV11cMailDesignMailReenviar, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmaildesignmailreenviar_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmaildesignmailreenviar_Visible, edtavCmaildesignmailreenviar_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx01B0.htm");
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
            GxWebStd.gx_div_start( context, divMaildesignestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMaildesignestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmaildesignestadofilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblmaildesignestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e179n1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01B0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmaildesignestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmaildesignestado, cmbavCmaildesignestado_Internalname, StringUtil.RTrim( AV12cMailDesignEstado), 1, cmbavCmaildesignestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCmaildesignestado.Visible, cmbavCmaildesignestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_Gx01B0.htm");
            cmbavCmaildesignestado.CurrentValue = StringUtil.RTrim( AV12cMailDesignEstado);
            AssignProp("", false, cmbavCmaildesignestado_Internalname, "Values", (string)(cmbavCmaildesignestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e189n1_client"+"'", TempTags, "", 2, "HLP_Gx01B0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01B0.htm");
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

      protected void START9N2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Mail Design", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9N0( ) ;
      }

      protected void WS9N2( )
      {
         START9N2( ) ;
         EVT9N2( ) ;
      }

      protected void EVT9N2( )
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
                              A148MailDesignId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailDesignId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbMailDesignTipo.Name = cmbMailDesignTipo_Internalname;
                              cmbMailDesignTipo.CurrentValue = cgiGet( cmbMailDesignTipo_Internalname);
                              A244MailDesignTipo = cgiGet( cmbMailDesignTipo_Internalname);
                              A149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A246MailDesignAsunto = cgiGet( edtMailDesignAsunto_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E199N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E209N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmaildesignid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILDESIGNID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMailDesignId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmaildesigntipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNTIPO"), AV7cMailDesignTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmailid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cMailId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmaildesignasunto Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNASUNTO"), AV9cMailDesignAsunto) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmaildesignnombreenvio Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNNOMBREENVIO"), AV10cMailDesignNombReenvio) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmaildesignmailreenviar Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNMAILREENVIAR"), AV11cMailDesignMailReenviar) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmaildesignestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNESTADO"), AV12cMailDesignEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E219N2 ();
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

      protected void WE9N2( )
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

      protected void PA9N2( )
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
                                        long AV6cMailDesignId ,
                                        string AV7cMailDesignTipo ,
                                        long AV8cMailId ,
                                        string AV9cMailDesignAsunto ,
                                        string AV10cMailDesignNombReenvio ,
                                        string AV11cMailDesignMailReenviar ,
                                        string AV12cMailDesignEstado )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAILDESIGNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, ".", "")));
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
         if ( cmbavCmaildesigntipo.ItemCount > 0 )
         {
            AV7cMailDesignTipo = cmbavCmaildesigntipo.getValidValue(AV7cMailDesignTipo);
            AssignAttri("", false, "AV7cMailDesignTipo", AV7cMailDesignTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmaildesigntipo.CurrentValue = StringUtil.RTrim( AV7cMailDesignTipo);
            AssignProp("", false, cmbavCmaildesigntipo_Internalname, "Values", cmbavCmaildesigntipo.ToJavascriptSource(), true);
         }
         if ( cmbavCmaildesignestado.ItemCount > 0 )
         {
            AV12cMailDesignEstado = cmbavCmaildesignestado.getValidValue(AV12cMailDesignEstado);
            AssignAttri("", false, "AV12cMailDesignEstado", AV12cMailDesignEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmaildesignestado.CurrentValue = StringUtil.RTrim( AV12cMailDesignEstado);
            AssignProp("", false, cmbavCmaildesignestado_Internalname, "Values", cmbavCmaildesignestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9N2( )
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
                                                 AV7cMailDesignTipo ,
                                                 AV8cMailId ,
                                                 AV9cMailDesignAsunto ,
                                                 AV10cMailDesignNombReenvio ,
                                                 AV11cMailDesignMailReenviar ,
                                                 AV12cMailDesignEstado ,
                                                 A244MailDesignTipo ,
                                                 A149MailId ,
                                                 A246MailDesignAsunto ,
                                                 A254MailDesignNombReenvio ,
                                                 A253MailDesignMailReenviar ,
                                                 A245MailDesignEstado ,
                                                 AV6cMailDesignId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV7cMailDesignTipo = StringUtil.PadR( StringUtil.RTrim( AV7cMailDesignTipo), 1, "%");
            lV9cMailDesignAsunto = StringUtil.PadR( StringUtil.RTrim( AV9cMailDesignAsunto), 80, "%");
            lV10cMailDesignNombReenvio = StringUtil.PadR( StringUtil.RTrim( AV10cMailDesignNombReenvio), 80, "%");
            lV11cMailDesignMailReenviar = StringUtil.Concat( StringUtil.RTrim( AV11cMailDesignMailReenviar), "%", "");
            lV12cMailDesignEstado = StringUtil.PadR( StringUtil.RTrim( AV12cMailDesignEstado), 3, "%");
            /* Using cursor H009N2 */
            pr_default.execute(0, new Object[] {AV6cMailDesignId, lV7cMailDesignTipo, AV8cMailId, lV9cMailDesignAsunto, lV10cMailDesignNombReenvio, lV11cMailDesignMailReenviar, lV12cMailDesignEstado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A245MailDesignEstado = H009N2_A245MailDesignEstado[0];
               A253MailDesignMailReenviar = H009N2_A253MailDesignMailReenviar[0];
               A254MailDesignNombReenvio = H009N2_A254MailDesignNombReenvio[0];
               A246MailDesignAsunto = H009N2_A246MailDesignAsunto[0];
               A149MailId = H009N2_A149MailId[0];
               A244MailDesignTipo = H009N2_A244MailDesignTipo[0];
               A148MailDesignId = H009N2_A148MailDesignId[0];
               /* Execute user event: Load */
               E209N2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB9N0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9N2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAILDESIGNID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cMailDesignTipo ,
                                              AV8cMailId ,
                                              AV9cMailDesignAsunto ,
                                              AV10cMailDesignNombReenvio ,
                                              AV11cMailDesignMailReenviar ,
                                              AV12cMailDesignEstado ,
                                              A244MailDesignTipo ,
                                              A149MailId ,
                                              A246MailDesignAsunto ,
                                              A254MailDesignNombReenvio ,
                                              A253MailDesignMailReenviar ,
                                              A245MailDesignEstado ,
                                              AV6cMailDesignId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV7cMailDesignTipo = StringUtil.PadR( StringUtil.RTrim( AV7cMailDesignTipo), 1, "%");
         lV9cMailDesignAsunto = StringUtil.PadR( StringUtil.RTrim( AV9cMailDesignAsunto), 80, "%");
         lV10cMailDesignNombReenvio = StringUtil.PadR( StringUtil.RTrim( AV10cMailDesignNombReenvio), 80, "%");
         lV11cMailDesignMailReenviar = StringUtil.Concat( StringUtil.RTrim( AV11cMailDesignMailReenviar), "%", "");
         lV12cMailDesignEstado = StringUtil.PadR( StringUtil.RTrim( AV12cMailDesignEstado), 3, "%");
         /* Using cursor H009N3 */
         pr_default.execute(1, new Object[] {AV6cMailDesignId, lV7cMailDesignTipo, AV8cMailId, lV9cMailDesignAsunto, lV10cMailDesignNombReenvio, lV11cMailDesignMailReenviar, lV12cMailDesignEstado});
         GRID1_nRecordCount = H009N3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailDesignId, AV7cMailDesignTipo, AV8cMailId, AV9cMailDesignAsunto, AV10cMailDesignNombReenvio, AV11cMailDesignMailReenviar, AV12cMailDesignEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailDesignId, AV7cMailDesignTipo, AV8cMailId, AV9cMailDesignAsunto, AV10cMailDesignNombReenvio, AV11cMailDesignMailReenviar, AV12cMailDesignEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailDesignId, AV7cMailDesignTipo, AV8cMailId, AV9cMailDesignAsunto, AV10cMailDesignNombReenvio, AV11cMailDesignMailReenviar, AV12cMailDesignEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailDesignId, AV7cMailDesignTipo, AV8cMailId, AV9cMailDesignAsunto, AV10cMailDesignNombReenvio, AV11cMailDesignMailReenviar, AV12cMailDesignEstado) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMailDesignId, AV7cMailDesignTipo, AV8cMailId, AV9cMailDesignAsunto, AV10cMailDesignNombReenvio, AV11cMailDesignMailReenviar, AV12cMailDesignEstado) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtMailDesignId_Enabled = 0;
         cmbMailDesignTipo.Enabled = 0;
         edtMailId_Enabled = 0;
         edtMailDesignAsunto_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E199N2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmaildesignid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmaildesignid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMAILDESIGNID");
               GX_FocusControl = edtavCmaildesignid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cMailDesignId = 0;
               AssignAttri("", false, "AV6cMailDesignId", StringUtil.LTrimStr( (decimal)(AV6cMailDesignId), 18, 0));
            }
            else
            {
               AV6cMailDesignId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmaildesignid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cMailDesignId", StringUtil.LTrimStr( (decimal)(AV6cMailDesignId), 18, 0));
            }
            cmbavCmaildesigntipo.Name = cmbavCmaildesigntipo_Internalname;
            cmbavCmaildesigntipo.CurrentValue = cgiGet( cmbavCmaildesigntipo_Internalname);
            AV7cMailDesignTipo = cgiGet( cmbavCmaildesigntipo_Internalname);
            AssignAttri("", false, "AV7cMailDesignTipo", AV7cMailDesignTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMAILID");
               GX_FocusControl = edtavCmailid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cMailId = 0;
               AssignAttri("", false, "AV8cMailId", StringUtil.LTrimStr( (decimal)(AV8cMailId), 18, 0));
            }
            else
            {
               AV8cMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmailid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cMailId", StringUtil.LTrimStr( (decimal)(AV8cMailId), 18, 0));
            }
            AV9cMailDesignAsunto = cgiGet( edtavCmaildesignasunto_Internalname);
            AssignAttri("", false, "AV9cMailDesignAsunto", AV9cMailDesignAsunto);
            AV10cMailDesignNombReenvio = cgiGet( edtavCmaildesignnombreenvio_Internalname);
            AssignAttri("", false, "AV10cMailDesignNombReenvio", AV10cMailDesignNombReenvio);
            AV11cMailDesignMailReenviar = cgiGet( edtavCmaildesignmailreenviar_Internalname);
            AssignAttri("", false, "AV11cMailDesignMailReenviar", AV11cMailDesignMailReenviar);
            cmbavCmaildesignestado.Name = cmbavCmaildesignestado_Internalname;
            cmbavCmaildesignestado.CurrentValue = cgiGet( cmbavCmaildesignestado_Internalname);
            AV12cMailDesignEstado = cgiGet( cmbavCmaildesignestado_Internalname);
            AssignAttri("", false, "AV12cMailDesignEstado", AV12cMailDesignEstado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILDESIGNID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cMailDesignId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNTIPO"), AV7cMailDesignTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cMailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNASUNTO"), AV9cMailDesignAsunto) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNNOMBREENVIO"), AV10cMailDesignNombReenvio) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNMAILREENVIAR"), AV11cMailDesignMailReenviar) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAILDESIGNESTADO"), AV12cMailDesignEstado) != 0 )
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
         E199N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E199N2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Mail Design", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E209N2( )
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
         E219N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E219N2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pMailDesignId = A148MailDesignId;
         AssignAttri("", false, "AV13pMailDesignId", StringUtil.LTrimStr( (decimal)(AV13pMailDesignId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pMailDesignId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pMailDesignId"});
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
         AV13pMailDesignId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pMailDesignId", StringUtil.LTrimStr( (decimal)(AV13pMailDesignId), 18, 0));
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
         PA9N2( ) ;
         WS9N2( ) ;
         WE9N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021263069", true, true, false);
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
         context.AddJavascriptSource("gx01b0.js", "?202673021263069", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtMailDesignId_Internalname = "MAILDESIGNID_"+sGXsfl_84_idx;
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO_"+sGXsfl_84_idx;
         edtMailId_Internalname = "MAILID_"+sGXsfl_84_idx;
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtMailDesignId_Internalname = "MAILDESIGNID_"+sGXsfl_84_fel_idx;
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO_"+sGXsfl_84_fel_idx;
         edtMailId_Internalname = "MAILID_"+sGXsfl_84_fel_idx;
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB9N0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailDesignId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailDesignId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMailDesignTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MAILDESIGNTIPO_" + sGXsfl_84_idx;
               cmbMailDesignTipo.Name = GXCCtl;
               cmbMailDesignTipo.WebTags = "";
               cmbMailDesignTipo.addItem("A", context.GetMessage( "Publicidad", ""), 0);
               cmbMailDesignTipo.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
               cmbMailDesignTipo.addItem("N", context.GetMessage( "Notificación", ""), 0);
               cmbMailDesignTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
               if ( cmbMailDesignTipo.ItemCount > 0 )
               {
                  A244MailDesignTipo = cmbMailDesignTipo.getValidValue(A244MailDesignTipo);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMailDesignTipo,(string)cmbMailDesignTipo_Internalname,StringUtil.RTrim( A244MailDesignTipo),(short)1,(string)cmbMailDesignTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"DescriptionAttribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMailDesignTipo.CurrentValue = StringUtil.RTrim( A244MailDesignTipo);
            AssignProp("", false, cmbMailDesignTipo_Internalname, "Values", (string)(cmbMailDesignTipo.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailDesignAsunto_Internalname,StringUtil.RTrim( A246MailDesignAsunto),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailDesignAsunto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes9N2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCmaildesigntipo.Name = "vCMAILDESIGNTIPO";
         cmbavCmaildesigntipo.WebTags = "";
         cmbavCmaildesigntipo.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbavCmaildesigntipo.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbavCmaildesigntipo.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbavCmaildesigntipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbavCmaildesigntipo.ItemCount > 0 )
         {
            AV7cMailDesignTipo = cmbavCmaildesigntipo.getValidValue(AV7cMailDesignTipo);
            AssignAttri("", false, "AV7cMailDesignTipo", AV7cMailDesignTipo);
         }
         cmbavCmaildesignestado.Name = "vCMAILDESIGNESTADO";
         cmbavCmaildesignestado.WebTags = "";
         cmbavCmaildesignestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCmaildesignestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbavCmaildesignestado.ItemCount > 0 )
         {
            AV12cMailDesignEstado = cmbavCmaildesignestado.getValidValue(AV12cMailDesignEstado);
            AssignAttri("", false, "AV12cMailDesignEstado", AV12cMailDesignEstado);
         }
         GXCCtl = "MAILDESIGNTIPO_" + sGXsfl_84_idx;
         cmbMailDesignTipo.Name = GXCCtl;
         cmbMailDesignTipo.WebTags = "";
         cmbMailDesignTipo.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbMailDesignTipo.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbMailDesignTipo.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbMailDesignTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbMailDesignTipo.ItemCount > 0 )
         {
            A244MailDesignTipo = cmbMailDesignTipo.getValidValue(A244MailDesignTipo);
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
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Asunto", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A244MailDesignTipo)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbMailDesignTipo.Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A246MailDesignAsunto)));
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
         lblLblmaildesignidfilter_Internalname = "LBLMAILDESIGNIDFILTER";
         edtavCmaildesignid_Internalname = "vCMAILDESIGNID";
         divMaildesignidfiltercontainer_Internalname = "MAILDESIGNIDFILTERCONTAINER";
         lblLblmaildesigntipofilter_Internalname = "LBLMAILDESIGNTIPOFILTER";
         cmbavCmaildesigntipo_Internalname = "vCMAILDESIGNTIPO";
         divMaildesigntipofiltercontainer_Internalname = "MAILDESIGNTIPOFILTERCONTAINER";
         lblLblmailidfilter_Internalname = "LBLMAILIDFILTER";
         edtavCmailid_Internalname = "vCMAILID";
         divMailidfiltercontainer_Internalname = "MAILIDFILTERCONTAINER";
         lblLblmaildesignasuntofilter_Internalname = "LBLMAILDESIGNASUNTOFILTER";
         edtavCmaildesignasunto_Internalname = "vCMAILDESIGNASUNTO";
         divMaildesignasuntofiltercontainer_Internalname = "MAILDESIGNASUNTOFILTERCONTAINER";
         lblLblmaildesignnombreenviofilter_Internalname = "LBLMAILDESIGNNOMBREENVIOFILTER";
         edtavCmaildesignnombreenvio_Internalname = "vCMAILDESIGNNOMBREENVIO";
         divMaildesignnombreenviofiltercontainer_Internalname = "MAILDESIGNNOMBREENVIOFILTERCONTAINER";
         lblLblmaildesignmailreenviarfilter_Internalname = "LBLMAILDESIGNMAILREENVIARFILTER";
         edtavCmaildesignmailreenviar_Internalname = "vCMAILDESIGNMAILREENVIAR";
         divMaildesignmailreenviarfiltercontainer_Internalname = "MAILDESIGNMAILREENVIARFILTERCONTAINER";
         lblLblmaildesignestadofilter_Internalname = "LBLMAILDESIGNESTADOFILTER";
         cmbavCmaildesignestado_Internalname = "vCMAILDESIGNESTADO";
         divMaildesignestadofiltercontainer_Internalname = "MAILDESIGNESTADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtMailDesignId_Internalname = "MAILDESIGNID";
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO";
         edtMailId_Internalname = "MAILID";
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO";
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
         cmbMailDesignTipo.Link = "";
         subGrid1_Header = "";
         edtMailDesignAsunto_Jsonclick = "";
         edtMailId_Jsonclick = "";
         cmbMailDesignTipo_Jsonclick = "";
         edtMailDesignId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtMailDesignAsunto_Enabled = 0;
         edtMailId_Enabled = 0;
         cmbMailDesignTipo.Enabled = 0;
         edtMailDesignId_Enabled = 0;
         cmbavCmaildesignestado_Jsonclick = "";
         cmbavCmaildesignestado.Visible = 1;
         cmbavCmaildesignestado.Enabled = 1;
         edtavCmaildesignmailreenviar_Jsonclick = "";
         edtavCmaildesignmailreenviar_Enabled = 1;
         edtavCmaildesignmailreenviar_Visible = 1;
         edtavCmaildesignnombreenvio_Jsonclick = "";
         edtavCmaildesignnombreenvio_Enabled = 1;
         edtavCmaildesignnombreenvio_Visible = 1;
         edtavCmaildesignasunto_Jsonclick = "";
         edtavCmaildesignasunto_Enabled = 1;
         edtavCmaildesignasunto_Visible = 1;
         edtavCmailid_Jsonclick = "";
         edtavCmailid_Enabled = 1;
         edtavCmailid_Visible = 1;
         cmbavCmaildesigntipo_Jsonclick = "";
         cmbavCmaildesigntipo.Visible = 1;
         cmbavCmaildesigntipo.Enabled = 1;
         edtavCmaildesignid_Jsonclick = "";
         edtavCmaildesignid_Enabled = 1;
         edtavCmaildesignid_Visible = 1;
         divMaildesignestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMaildesignmailreenviarfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMaildesignnombreenviofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMaildesignasuntofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMailidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMaildesigntipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMaildesignidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Mail Design", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailDesignId',fld:'vCMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCmaildesigntipo'},{av:'AV7cMailDesignTipo',fld:'vCMAILDESIGNTIPO',pic:'',type:'char'},{av:'AV8cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cMailDesignAsunto',fld:'vCMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV10cMailDesignNombReenvio',fld:'vCMAILDESIGNNOMBREENVIO',pic:'',type:'char'},{av:'AV11cMailDesignMailReenviar',fld:'vCMAILDESIGNMAILREENVIAR',pic:'',type:'svchar'},{av:'cmbavCmaildesignestado'},{av:'AV12cMailDesignEstado',fld:'vCMAILDESIGNESTADO',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E189N1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLMAILDESIGNIDFILTER.CLICK","{handler:'E119N1',iparms:[{av:'divMaildesignidfiltercontainer_Class',ctrl:'MAILDESIGNIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDESIGNIDFILTER.CLICK",",oparms:[{av:'divMaildesignidfiltercontainer_Class',ctrl:'MAILDESIGNIDFILTERCONTAINER',prop:'Class'},{av:'edtavCmaildesignid_Visible',ctrl:'vCMAILDESIGNID',prop:'Visible'}]}");
         setEventMetadata("LBLMAILDESIGNTIPOFILTER.CLICK","{handler:'E129N1',iparms:[{av:'divMaildesigntipofiltercontainer_Class',ctrl:'MAILDESIGNTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDESIGNTIPOFILTER.CLICK",",oparms:[{av:'divMaildesigntipofiltercontainer_Class',ctrl:'MAILDESIGNTIPOFILTERCONTAINER',prop:'Class'},{av:'cmbavCmaildesigntipo'}]}");
         setEventMetadata("LBLMAILIDFILTER.CLICK","{handler:'E139N1',iparms:[{av:'divMailidfiltercontainer_Class',ctrl:'MAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILIDFILTER.CLICK",",oparms:[{av:'divMailidfiltercontainer_Class',ctrl:'MAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCmailid_Visible',ctrl:'vCMAILID',prop:'Visible'}]}");
         setEventMetadata("LBLMAILDESIGNASUNTOFILTER.CLICK","{handler:'E149N1',iparms:[{av:'divMaildesignasuntofiltercontainer_Class',ctrl:'MAILDESIGNASUNTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDESIGNASUNTOFILTER.CLICK",",oparms:[{av:'divMaildesignasuntofiltercontainer_Class',ctrl:'MAILDESIGNASUNTOFILTERCONTAINER',prop:'Class'},{av:'edtavCmaildesignasunto_Visible',ctrl:'vCMAILDESIGNASUNTO',prop:'Visible'}]}");
         setEventMetadata("LBLMAILDESIGNNOMBREENVIOFILTER.CLICK","{handler:'E159N1',iparms:[{av:'divMaildesignnombreenviofiltercontainer_Class',ctrl:'MAILDESIGNNOMBREENVIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDESIGNNOMBREENVIOFILTER.CLICK",",oparms:[{av:'divMaildesignnombreenviofiltercontainer_Class',ctrl:'MAILDESIGNNOMBREENVIOFILTERCONTAINER',prop:'Class'},{av:'edtavCmaildesignnombreenvio_Visible',ctrl:'vCMAILDESIGNNOMBREENVIO',prop:'Visible'}]}");
         setEventMetadata("LBLMAILDESIGNMAILREENVIARFILTER.CLICK","{handler:'E169N1',iparms:[{av:'divMaildesignmailreenviarfiltercontainer_Class',ctrl:'MAILDESIGNMAILREENVIARFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDESIGNMAILREENVIARFILTER.CLICK",",oparms:[{av:'divMaildesignmailreenviarfiltercontainer_Class',ctrl:'MAILDESIGNMAILREENVIARFILTERCONTAINER',prop:'Class'},{av:'edtavCmaildesignmailreenviar_Visible',ctrl:'vCMAILDESIGNMAILREENVIAR',prop:'Visible'}]}");
         setEventMetadata("LBLMAILDESIGNESTADOFILTER.CLICK","{handler:'E179N1',iparms:[{av:'divMaildesignestadofiltercontainer_Class',ctrl:'MAILDESIGNESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAILDESIGNESTADOFILTER.CLICK",",oparms:[{av:'divMaildesignestadofiltercontainer_Class',ctrl:'MAILDESIGNESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCmaildesignestado'}]}");
         setEventMetadata("ENTER","{handler:'E219N2',iparms:[{av:'A148MailDesignId',fld:'MAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pMailDesignId',fld:'vPMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailDesignId',fld:'vCMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCmaildesigntipo'},{av:'AV7cMailDesignTipo',fld:'vCMAILDESIGNTIPO',pic:'',type:'char'},{av:'AV8cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cMailDesignAsunto',fld:'vCMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV10cMailDesignNombReenvio',fld:'vCMAILDESIGNNOMBREENVIO',pic:'',type:'char'},{av:'AV11cMailDesignMailReenviar',fld:'vCMAILDESIGNMAILREENVIAR',pic:'',type:'svchar'},{av:'cmbavCmaildesignestado'},{av:'AV12cMailDesignEstado',fld:'vCMAILDESIGNESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailDesignId',fld:'vCMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCmaildesigntipo'},{av:'AV7cMailDesignTipo',fld:'vCMAILDESIGNTIPO',pic:'',type:'char'},{av:'AV8cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cMailDesignAsunto',fld:'vCMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV10cMailDesignNombReenvio',fld:'vCMAILDESIGNNOMBREENVIO',pic:'',type:'char'},{av:'AV11cMailDesignMailReenviar',fld:'vCMAILDESIGNMAILREENVIAR',pic:'',type:'svchar'},{av:'cmbavCmaildesignestado'},{av:'AV12cMailDesignEstado',fld:'vCMAILDESIGNESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailDesignId',fld:'vCMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCmaildesigntipo'},{av:'AV7cMailDesignTipo',fld:'vCMAILDESIGNTIPO',pic:'',type:'char'},{av:'AV8cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cMailDesignAsunto',fld:'vCMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV10cMailDesignNombReenvio',fld:'vCMAILDESIGNNOMBREENVIO',pic:'',type:'char'},{av:'AV11cMailDesignMailReenviar',fld:'vCMAILDESIGNMAILREENVIAR',pic:'',type:'svchar'},{av:'cmbavCmaildesignestado'},{av:'AV12cMailDesignEstado',fld:'vCMAILDESIGNESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMailDesignId',fld:'vCMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCmaildesigntipo'},{av:'AV7cMailDesignTipo',fld:'vCMAILDESIGNTIPO',pic:'',type:'char'},{av:'AV8cMailId',fld:'vCMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cMailDesignAsunto',fld:'vCMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV10cMailDesignNombReenvio',fld:'vCMAILDESIGNNOMBREENVIO',pic:'',type:'char'},{av:'AV11cMailDesignMailReenviar',fld:'vCMAILDESIGNMAILREENVIAR',pic:'',type:'svchar'},{av:'cmbavCmaildesignestado'},{av:'AV12cMailDesignEstado',fld:'vCMAILDESIGNESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CMAILDESIGNMAILREENVIAR","{handler:'Validv_Cmaildesignmailreenviar',iparms:[]");
         setEventMetadata("VALIDV_CMAILDESIGNMAILREENVIAR",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Maildesignasunto',iparms:[]");
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
         AV7cMailDesignTipo = "";
         AV9cMailDesignAsunto = "";
         AV10cMailDesignNombReenvio = "";
         AV11cMailDesignMailReenviar = "";
         AV12cMailDesignEstado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmaildesignidfilter_Jsonclick = "";
         TempTags = "";
         lblLblmaildesigntipofilter_Jsonclick = "";
         lblLblmailidfilter_Jsonclick = "";
         lblLblmaildesignasuntofilter_Jsonclick = "";
         lblLblmaildesignnombreenviofilter_Jsonclick = "";
         lblLblmaildesignmailreenviarfilter_Jsonclick = "";
         lblLblmaildesignestadofilter_Jsonclick = "";
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
         A244MailDesignTipo = "";
         A246MailDesignAsunto = "";
         lV7cMailDesignTipo = "";
         lV9cMailDesignAsunto = "";
         lV10cMailDesignNombReenvio = "";
         lV11cMailDesignMailReenviar = "";
         lV12cMailDesignEstado = "";
         A254MailDesignNombReenvio = "";
         A253MailDesignMailReenviar = "";
         A245MailDesignEstado = "";
         H009N2_A245MailDesignEstado = new string[] {""} ;
         H009N2_A253MailDesignMailReenviar = new string[] {""} ;
         H009N2_A254MailDesignNombReenvio = new string[] {""} ;
         H009N2_A246MailDesignAsunto = new string[] {""} ;
         H009N2_A149MailId = new long[1] ;
         H009N2_A244MailDesignTipo = new string[] {""} ;
         H009N2_A148MailDesignId = new long[1] ;
         H009N3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01b0__default(),
            new Object[][] {
                new Object[] {
               H009N2_A245MailDesignEstado, H009N2_A253MailDesignMailReenviar, H009N2_A254MailDesignNombReenvio, H009N2_A246MailDesignAsunto, H009N2_A149MailId, H009N2_A244MailDesignTipo, H009N2_A148MailDesignId
               }
               , new Object[] {
               H009N3_AGRID1_nRecordCount
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
      private int edtavCmaildesignid_Enabled ;
      private int edtavCmaildesignid_Visible ;
      private int edtavCmailid_Enabled ;
      private int edtavCmailid_Visible ;
      private int edtavCmaildesignasunto_Visible ;
      private int edtavCmaildesignasunto_Enabled ;
      private int edtavCmaildesignnombreenvio_Visible ;
      private int edtavCmaildesignnombreenvio_Enabled ;
      private int edtavCmaildesignmailreenviar_Visible ;
      private int edtavCmaildesignmailreenviar_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtMailDesignId_Enabled ;
      private int edtMailId_Enabled ;
      private int edtMailDesignAsunto_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pMailDesignId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cMailDesignId ;
      private long AV8cMailId ;
      private long A148MailDesignId ;
      private long A149MailId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divMaildesignidfiltercontainer_Class ;
      private string divMaildesigntipofiltercontainer_Class ;
      private string divMailidfiltercontainer_Class ;
      private string divMaildesignasuntofiltercontainer_Class ;
      private string divMaildesignnombreenviofiltercontainer_Class ;
      private string divMaildesignmailreenviarfiltercontainer_Class ;
      private string divMaildesignestadofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cMailDesignTipo ;
      private string AV9cMailDesignAsunto ;
      private string AV10cMailDesignNombReenvio ;
      private string AV12cMailDesignEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divMaildesignidfiltercontainer_Internalname ;
      private string lblLblmaildesignidfilter_Internalname ;
      private string lblLblmaildesignidfilter_Jsonclick ;
      private string edtavCmaildesignid_Internalname ;
      private string TempTags ;
      private string edtavCmaildesignid_Jsonclick ;
      private string divMaildesigntipofiltercontainer_Internalname ;
      private string lblLblmaildesigntipofilter_Internalname ;
      private string lblLblmaildesigntipofilter_Jsonclick ;
      private string cmbavCmaildesigntipo_Internalname ;
      private string cmbavCmaildesigntipo_Jsonclick ;
      private string divMailidfiltercontainer_Internalname ;
      private string lblLblmailidfilter_Internalname ;
      private string lblLblmailidfilter_Jsonclick ;
      private string edtavCmailid_Internalname ;
      private string edtavCmailid_Jsonclick ;
      private string divMaildesignasuntofiltercontainer_Internalname ;
      private string lblLblmaildesignasuntofilter_Internalname ;
      private string lblLblmaildesignasuntofilter_Jsonclick ;
      private string edtavCmaildesignasunto_Internalname ;
      private string edtavCmaildesignasunto_Jsonclick ;
      private string divMaildesignnombreenviofiltercontainer_Internalname ;
      private string lblLblmaildesignnombreenviofilter_Internalname ;
      private string lblLblmaildesignnombreenviofilter_Jsonclick ;
      private string edtavCmaildesignnombreenvio_Internalname ;
      private string edtavCmaildesignnombreenvio_Jsonclick ;
      private string divMaildesignmailreenviarfiltercontainer_Internalname ;
      private string lblLblmaildesignmailreenviarfilter_Internalname ;
      private string lblLblmaildesignmailreenviarfilter_Jsonclick ;
      private string edtavCmaildesignmailreenviar_Internalname ;
      private string edtavCmaildesignmailreenviar_Jsonclick ;
      private string divMaildesignestadofiltercontainer_Internalname ;
      private string lblLblmaildesignestadofilter_Internalname ;
      private string lblLblmaildesignestadofilter_Jsonclick ;
      private string cmbavCmaildesignestado_Internalname ;
      private string cmbavCmaildesignestado_Jsonclick ;
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
      private string edtMailDesignId_Internalname ;
      private string cmbMailDesignTipo_Internalname ;
      private string A244MailDesignTipo ;
      private string edtMailId_Internalname ;
      private string A246MailDesignAsunto ;
      private string edtMailDesignAsunto_Internalname ;
      private string lV7cMailDesignTipo ;
      private string lV9cMailDesignAsunto ;
      private string lV10cMailDesignNombReenvio ;
      private string lV12cMailDesignEstado ;
      private string A254MailDesignNombReenvio ;
      private string A245MailDesignEstado ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtMailDesignId_Jsonclick ;
      private string GXCCtl ;
      private string cmbMailDesignTipo_Jsonclick ;
      private string edtMailId_Jsonclick ;
      private string edtMailDesignAsunto_Jsonclick ;
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
      private string AV11cMailDesignMailReenviar ;
      private string AV15Linkselection_GXI ;
      private string lV11cMailDesignMailReenviar ;
      private string A253MailDesignMailReenviar ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCmaildesigntipo ;
      private GXCombobox cmbavCmaildesignestado ;
      private GXCombobox cmbMailDesignTipo ;
      private IDataStoreProvider pr_default ;
      private string[] H009N2_A245MailDesignEstado ;
      private string[] H009N2_A253MailDesignMailReenviar ;
      private string[] H009N2_A254MailDesignNombReenvio ;
      private string[] H009N2_A246MailDesignAsunto ;
      private long[] H009N2_A149MailId ;
      private string[] H009N2_A244MailDesignTipo ;
      private long[] H009N2_A148MailDesignId ;
      private long[] H009N3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pMailDesignId ;
   }

   public class gx01b0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009N2( IGxContext context ,
                                             string AV7cMailDesignTipo ,
                                             long AV8cMailId ,
                                             string AV9cMailDesignAsunto ,
                                             string AV10cMailDesignNombReenvio ,
                                             string AV11cMailDesignMailReenviar ,
                                             string AV12cMailDesignEstado ,
                                             string A244MailDesignTipo ,
                                             long A149MailId ,
                                             string A246MailDesignAsunto ,
                                             string A254MailDesignNombReenvio ,
                                             string A253MailDesignMailReenviar ,
                                             string A245MailDesignEstado ,
                                             long AV6cMailDesignId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MailDesignEstado], [MailDesignMailReenviar], [MailDesignNombReenvio], [MailDesignAsunto], [MailId], [MailDesignTipo], [MailDesignId]";
         sFromString = " FROM [MailDesign]";
         sOrderString = "";
         AddWhere(sWhereString, "([MailDesignId] >= @AV6cMailDesignId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMailDesignTipo)) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] like @lV7cMailDesignTipo)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cMailId) )
         {
            AddWhere(sWhereString, "([MailId] >= @AV8cMailId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMailDesignAsunto)) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] like @lV9cMailDesignAsunto)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cMailDesignNombReenvio)) )
         {
            AddWhere(sWhereString, "([MailDesignNombReenvio] like @lV10cMailDesignNombReenvio)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cMailDesignMailReenviar)) )
         {
            AddWhere(sWhereString, "([MailDesignMailReenviar] like @lV11cMailDesignMailReenviar)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cMailDesignEstado)) )
         {
            AddWhere(sWhereString, "([MailDesignEstado] like @lV12cMailDesignEstado)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [MailDesignId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009N3( IGxContext context ,
                                             string AV7cMailDesignTipo ,
                                             long AV8cMailId ,
                                             string AV9cMailDesignAsunto ,
                                             string AV10cMailDesignNombReenvio ,
                                             string AV11cMailDesignMailReenviar ,
                                             string AV12cMailDesignEstado ,
                                             string A244MailDesignTipo ,
                                             long A149MailId ,
                                             string A246MailDesignAsunto ,
                                             string A254MailDesignNombReenvio ,
                                             string A253MailDesignMailReenviar ,
                                             string A245MailDesignEstado ,
                                             long AV6cMailDesignId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [MailDesign]";
         AddWhere(sWhereString, "([MailDesignId] >= @AV6cMailDesignId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMailDesignTipo)) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] like @lV7cMailDesignTipo)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cMailId) )
         {
            AddWhere(sWhereString, "([MailId] >= @AV8cMailId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMailDesignAsunto)) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] like @lV9cMailDesignAsunto)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cMailDesignNombReenvio)) )
         {
            AddWhere(sWhereString, "([MailDesignNombReenvio] like @lV10cMailDesignNombReenvio)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cMailDesignMailReenviar)) )
         {
            AddWhere(sWhereString, "([MailDesignMailReenviar] like @lV11cMailDesignMailReenviar)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cMailDesignEstado)) )
         {
            AddWhere(sWhereString, "([MailDesignEstado] like @lV12cMailDesignEstado)");
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
                     return conditional_H009N2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H009N3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH009N2;
          prmH009N2 = new Object[] {
          new ParDef("@AV6cMailDesignId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMailDesignTipo",GXType.NChar,1,0) ,
          new ParDef("@AV8cMailId",GXType.Decimal,18,0) ,
          new ParDef("@lV9cMailDesignAsunto",GXType.NChar,80,0) ,
          new ParDef("@lV10cMailDesignNombReenvio",GXType.NChar,80,0) ,
          new ParDef("@lV11cMailDesignMailReenviar",GXType.NVarChar,100,0) ,
          new ParDef("@lV12cMailDesignEstado",GXType.NChar,3,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009N3;
          prmH009N3 = new Object[] {
          new ParDef("@AV6cMailDesignId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cMailDesignTipo",GXType.NChar,1,0) ,
          new ParDef("@AV8cMailId",GXType.Decimal,18,0) ,
          new ParDef("@lV9cMailDesignAsunto",GXType.NChar,80,0) ,
          new ParDef("@lV10cMailDesignNombReenvio",GXType.NChar,80,0) ,
          new ParDef("@lV11cMailDesignMailReenviar",GXType.NVarChar,100,0) ,
          new ParDef("@lV12cMailDesignEstado",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009N2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009N3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

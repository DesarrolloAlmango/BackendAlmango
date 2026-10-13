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
   public class gx0210 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0210( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0210( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pVincularTrnId )
      {
         this.AV12pVincularTrnId = 0 ;
         ExecutePrivate();
         aP0_pVincularTrnId=this.AV12pVincularTrnId;
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
            gxfirstwebparm = GetFirstPar( "pVincularTrnId");
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
               gxfirstwebparm = GetFirstPar( "pVincularTrnId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pVincularTrnId");
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
               AV12pVincularTrnId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pVincularTrnId", StringUtil.LTrimStr( (decimal)(AV12pVincularTrnId), 18, 0));
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
         AV6cVincularTrnId = (long)(Math.Round(NumberUtil.Val( GetPar( "cVincularTrnId"), "."), 18, MidpointRounding.ToEven));
         AV7cProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "cProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV8cVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( GetPar( "cVincularTrnSolidicutd"), "."), 18, MidpointRounding.ToEven));
         AV9cVincularTrnNombreSol = GetPar( "cVincularTrnNombreSol");
         AV10cVincularTrnTelefonoSol = GetPar( "cVincularTrnTelefonoSol");
         AV11cVincularTrnFecha = context.localUtil.ParseDateParm( GetPar( "cVincularTrnFecha"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, AV9cVincularTrnNombreSol, AV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha) ;
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
         PAAC2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAC2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0210.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pVincularTrnId,18,0))}, new string[] {"pVincularTrnId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCVINCULARTRNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cVincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVINCULARTRNSOLIDICUTD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cVincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVINCULARTRNNOMBRESOL", StringUtil.RTrim( AV9cVincularTrnNombreSol));
         GxWebStd.gx_hidden_field( context, "GXH_vCVINCULARTRNTELEFONOSOL", StringUtil.RTrim( AV10cVincularTrnTelefonoSol));
         GxWebStd.gx_hidden_field( context, "GXH_vCVINCULARTRNFECHA", context.localUtil.Format(AV11cVincularTrnFecha, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPVINCULARTRNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pVincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNIDFILTERCONTAINER_Class", StringUtil.RTrim( divVinculartrnidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROVEEDORIDFILTERCONTAINER_Class", StringUtil.RTrim( divProveedoridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNSOLIDICUTDFILTERCONTAINER_Class", StringUtil.RTrim( divVinculartrnsolidicutdfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNNOMBRESOLFILTERCONTAINER_Class", StringUtil.RTrim( divVinculartrnnombresolfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNTELEFONOSOLFILTERCONTAINER_Class", StringUtil.RTrim( divVinculartrntelefonosolfiltercontainer_Class));
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
            WEAC2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAC2( ) ;
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
         return formatLink("gx0210.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pVincularTrnId,18,0))}, new string[] {"pVincularTrnId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0210" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Vincular Trn", "") ;
      }

      protected void WBAC0( )
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
            GxWebStd.gx_div_start( context, divVinculartrnidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVinculartrnidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvinculartrnidfilter_Internalname, context.GetMessage( "Nro", ""), "", "", lblLblvinculartrnidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11ac1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0210.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvinculartrnid_Internalname, context.GetMessage( "Nro", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCvinculartrnid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cVincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCvinculartrnid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cVincularTrnId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cVincularTrnId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvinculartrnid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCvinculartrnid_Visible, edtavCvinculartrnid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0210.htm");
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
            GxWebStd.gx_div_start( context, divProveedoridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProveedoridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproveedoridfilter_Internalname, context.GetMessage( "Comercio", ""), "", "", lblLblproveedoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12ac1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0210.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproveedorid_Internalname, context.GetMessage( "Comercio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproveedorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCproveedorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproveedorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproveedorid_Visible, edtavCproveedorid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0210.htm");
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
            GxWebStd.gx_div_start( context, divVinculartrnsolidicutdfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVinculartrnsolidicutdfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvinculartrnsolidicutdfilter_Internalname, context.GetMessage( "Solicitud", ""), "", "", lblLblvinculartrnsolidicutdfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13ac1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0210.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvinculartrnsolidicutd_Internalname, context.GetMessage( "Solicitud", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCvinculartrnsolidicutd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cVincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCvinculartrnsolidicutd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cVincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cVincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvinculartrnsolidicutd_Jsonclick, 0, "Attribute", "", "", "", "", edtavCvinculartrnsolidicutd_Visible, edtavCvinculartrnsolidicutd_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0210.htm");
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
            GxWebStd.gx_div_start( context, divVinculartrnnombresolfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVinculartrnnombresolfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvinculartrnnombresolfilter_Internalname, context.GetMessage( "Nombre del Cliente", ""), "", "", lblLblvinculartrnnombresolfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14ac1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0210.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvinculartrnnombresol_Internalname, context.GetMessage( "Nombre del Cliente", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCvinculartrnnombresol_Internalname, StringUtil.RTrim( AV9cVincularTrnNombreSol), StringUtil.RTrim( context.localUtil.Format( AV9cVincularTrnNombreSol, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvinculartrnnombresol_Jsonclick, 0, "Attribute", "", "", "", "", edtavCvinculartrnnombresol_Visible, edtavCvinculartrnnombresol_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0210.htm");
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
            GxWebStd.gx_div_start( context, divVinculartrntelefonosolfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVinculartrntelefonosolfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvinculartrntelefonosolfilter_Internalname, context.GetMessage( "Teléfono del Cliente", ""), "", "", lblLblvinculartrntelefonosolfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15ac1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0210.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvinculartrntelefonosol_Internalname, context.GetMessage( "Teléfono del Cliente", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCvinculartrntelefonosol_Internalname, StringUtil.RTrim( AV10cVincularTrnTelefonoSol), StringUtil.RTrim( context.localUtil.Format( AV10cVincularTrnTelefonoSol, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvinculartrntelefonosol_Jsonclick, 0, "Attribute", "", "", "", "", edtavCvinculartrntelefonosol_Visible, edtavCvinculartrntelefonosol_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0210.htm");
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
            GxWebStd.gx_div_start( context, divVinculartrnfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvinculartrnfechafilter_Internalname, context.GetMessage( "Fecha", ""), "", "", lblLblvinculartrnfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx0210.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvinculartrnfecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCvinculartrnfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCvinculartrnfecha_Internalname, context.localUtil.Format(AV11cVincularTrnFecha, "99/99/99"), context.localUtil.Format( AV11cVincularTrnFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvinculartrnfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCvinculartrnfecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0210.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16ac1_client"+"'", TempTags, "", 2, "HLP_Gx0210.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0210.htm");
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

      protected void STARTAC2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Vincular Trn", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAC0( ) ;
      }

      protected void WSAC2( )
      {
         STARTAC2( ) ;
         EVTAC2( ) ;
      }

      protected void EVTAC2( )
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
                              A491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnSolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A494VincularTrnTelefonoSol = cgiGet( edtVincularTrnTelefonoSol_Internalname);
                              A495VincularTrnImagen = cgiGet( edtVincularTrnImagen_Internalname);
                              AssignProp("", false, edtVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
                              A496VincularTrnFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVincularTrnFecha_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17AC2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18AC2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cvinculartrnid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVINCULARTRNID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cVincularTrnId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproveedorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cProveedorID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cvinculartrnsolidicutd Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVINCULARTRNSOLIDICUTD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cVincularTrnSolidicutd )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cvinculartrnnombresol Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCVINCULARTRNNOMBRESOL"), AV9cVincularTrnNombreSol) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cvinculartrntelefonosol Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCVINCULARTRNTELEFONOSOL"), AV10cVincularTrnTelefonoSol) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cvinculartrnfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCVINCULARTRNFECHA"), 0) != AV11cVincularTrnFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19AC2 ();
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

      protected void WEAC2( )
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

      protected void PAAC2( )
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
                                        long AV6cVincularTrnId ,
                                        long AV7cProveedorID ,
                                        long AV8cVincularTrnSolidicutd ,
                                        string AV9cVincularTrnNombreSol ,
                                        string AV10cVincularTrnTelefonoSol ,
                                        DateTime AV11cVincularTrnFecha )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFAC2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VINCULARTRNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, ".", "")));
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
         RFAC2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAC2( )
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
                                                 AV7cProveedorID ,
                                                 AV8cVincularTrnSolidicutd ,
                                                 AV9cVincularTrnNombreSol ,
                                                 AV10cVincularTrnTelefonoSol ,
                                                 AV11cVincularTrnFecha ,
                                                 A133ProveedorID ,
                                                 A492VincularTrnSolidicutd ,
                                                 A493VincularTrnNombreSol ,
                                                 A494VincularTrnTelefonoSol ,
                                                 A496VincularTrnFecha ,
                                                 AV6cVincularTrnId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG
                                                 }
            });
            lV9cVincularTrnNombreSol = StringUtil.PadR( StringUtil.RTrim( AV9cVincularTrnNombreSol), 80, "%");
            lV10cVincularTrnTelefonoSol = StringUtil.PadR( StringUtil.RTrim( AV10cVincularTrnTelefonoSol), 20, "%");
            /* Using cursor H00AC2 */
            pr_default.execute(0, new Object[] {AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, lV9cVincularTrnNombreSol, lV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A493VincularTrnNombreSol = H00AC2_A493VincularTrnNombreSol[0];
               A496VincularTrnFecha = H00AC2_A496VincularTrnFecha[0];
               A40000VincularTrnImagen_GXI = H00AC2_A40000VincularTrnImagen_GXI[0];
               AssignProp("", false, edtVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), !bGXsfl_74_Refreshing);
               AssignProp("", false, edtVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
               A494VincularTrnTelefonoSol = H00AC2_A494VincularTrnTelefonoSol[0];
               A492VincularTrnSolidicutd = H00AC2_A492VincularTrnSolidicutd[0];
               A133ProveedorID = H00AC2_A133ProveedorID[0];
               A491VincularTrnId = H00AC2_A491VincularTrnId[0];
               A495VincularTrnImagen = H00AC2_A495VincularTrnImagen[0];
               AssignProp("", false, edtVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), !bGXsfl_74_Refreshing);
               AssignProp("", false, edtVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
               /* Execute user event: Load */
               E18AC2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBAC0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesAC2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VINCULARTRNID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cProveedorID ,
                                              AV8cVincularTrnSolidicutd ,
                                              AV9cVincularTrnNombreSol ,
                                              AV10cVincularTrnTelefonoSol ,
                                              AV11cVincularTrnFecha ,
                                              A133ProveedorID ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A496VincularTrnFecha ,
                                              AV6cVincularTrnId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV9cVincularTrnNombreSol = StringUtil.PadR( StringUtil.RTrim( AV9cVincularTrnNombreSol), 80, "%");
         lV10cVincularTrnTelefonoSol = StringUtil.PadR( StringUtil.RTrim( AV10cVincularTrnTelefonoSol), 20, "%");
         /* Using cursor H00AC3 */
         pr_default.execute(1, new Object[] {AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, lV9cVincularTrnNombreSol, lV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha});
         GRID1_nRecordCount = H00AC3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, AV9cVincularTrnNombreSol, AV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, AV9cVincularTrnNombreSol, AV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, AV9cVincularTrnNombreSol, AV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, AV9cVincularTrnNombreSol, AV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVincularTrnId, AV7cProveedorID, AV8cVincularTrnSolidicutd, AV9cVincularTrnNombreSol, AV10cVincularTrnTelefonoSol, AV11cVincularTrnFecha) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtVincularTrnId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtVincularTrnSolidicutd_Enabled = 0;
         edtVincularTrnTelefonoSol_Enabled = 0;
         edtVincularTrnImagen_Enabled = 0;
         edtVincularTrnFecha_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAC0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17AC2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCvinculartrnid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCvinculartrnid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVINCULARTRNID");
               GX_FocusControl = edtavCvinculartrnid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cVincularTrnId = 0;
               AssignAttri("", false, "AV6cVincularTrnId", StringUtil.LTrimStr( (decimal)(AV6cVincularTrnId), 18, 0));
            }
            else
            {
               AV6cVincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCvinculartrnid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cVincularTrnId", StringUtil.LTrimStr( (decimal)(AV6cVincularTrnId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproveedorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproveedorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROVEEDORID");
               GX_FocusControl = edtavCproveedorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cProveedorID = 0;
               AssignAttri("", false, "AV7cProveedorID", StringUtil.LTrimStr( (decimal)(AV7cProveedorID), 18, 0));
            }
            else
            {
               AV7cProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproveedorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cProveedorID", StringUtil.LTrimStr( (decimal)(AV7cProveedorID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCvinculartrnsolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCvinculartrnsolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVINCULARTRNSOLIDICUTD");
               GX_FocusControl = edtavCvinculartrnsolidicutd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cVincularTrnSolidicutd = 0;
               AssignAttri("", false, "AV8cVincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(AV8cVincularTrnSolidicutd), 18, 0));
            }
            else
            {
               AV8cVincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCvinculartrnsolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cVincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(AV8cVincularTrnSolidicutd), 18, 0));
            }
            AV9cVincularTrnNombreSol = cgiGet( edtavCvinculartrnnombresol_Internalname);
            AssignAttri("", false, "AV9cVincularTrnNombreSol", AV9cVincularTrnNombreSol);
            AV10cVincularTrnTelefonoSol = cgiGet( edtavCvinculartrntelefonosol_Internalname);
            AssignAttri("", false, "AV10cVincularTrnTelefonoSol", AV10cVincularTrnTelefonoSol);
            if ( context.localUtil.VCDate( cgiGet( edtavCvinculartrnfecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "vCVINCULARTRNFECHA");
               GX_FocusControl = edtavCvinculartrnfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cVincularTrnFecha = DateTime.MinValue;
               AssignAttri("", false, "AV11cVincularTrnFecha", context.localUtil.Format(AV11cVincularTrnFecha, "99/99/99"));
            }
            else
            {
               AV11cVincularTrnFecha = context.localUtil.CToD( cgiGet( edtavCvinculartrnfecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV11cVincularTrnFecha", context.localUtil.Format(AV11cVincularTrnFecha, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVINCULARTRNID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cVincularTrnId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cProveedorID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVINCULARTRNSOLIDICUTD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cVincularTrnSolidicutd )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCVINCULARTRNNOMBRESOL"), AV9cVincularTrnNombreSol) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCVINCULARTRNTELEFONOSOL"), AV10cVincularTrnTelefonoSol) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCVINCULARTRNFECHA"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV11cVincularTrnFecha ) )
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
         E17AC2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17AC2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Vincular Trn", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18AC2( )
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
         E19AC2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19AC2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pVincularTrnId = A491VincularTrnId;
         AssignAttri("", false, "AV12pVincularTrnId", StringUtil.LTrimStr( (decimal)(AV12pVincularTrnId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pVincularTrnId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pVincularTrnId"});
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
         AV12pVincularTrnId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pVincularTrnId", StringUtil.LTrimStr( (decimal)(AV12pVincularTrnId), 18, 0));
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
         PAAC2( ) ;
         WSAC2( ) ;
         WEAC2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021261067", true, true, false);
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
         context.AddJavascriptSource("gx0210.js", "?202673021261068", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtVincularTrnId_Internalname = "VINCULARTRNID_"+sGXsfl_74_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_74_idx;
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD_"+sGXsfl_74_idx;
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL_"+sGXsfl_74_idx;
         edtVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN_"+sGXsfl_74_idx;
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtVincularTrnId_Internalname = "VINCULARTRNID_"+sGXsfl_74_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_74_fel_idx;
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD_"+sGXsfl_74_fel_idx;
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL_"+sGXsfl_74_fel_idx;
         edtVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN_"+sGXsfl_74_fel_idx;
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBAC0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVincularTrnId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtVincularTrnSolidicutd_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Link", edtVincularTrnSolidicutd_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnSolidicutd_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtVincularTrnSolidicutd_Link,(string)"",(string)"",(string)"",(string)edtVincularTrnSolidicutd_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A494VincularTrnTelefonoSol);
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnTelefonoSol_Internalname,StringUtil.RTrim( A494VincularTrnTelefonoSol),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtVincularTrnTelefonoSol_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A495VincularTrnImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000VincularTrnImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.PathToRelativeUrl( A495VincularTrnImagen));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A495VincularTrnImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnFecha_Internalname,context.localUtil.Format(A496VincularTrnFecha, "99/99/99"),context.localUtil.Format( A496VincularTrnFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVincularTrnFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesAC2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( context.GetMessage( "Nro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitud", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono del Cliente", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fotografia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtVincularTrnSolidicutd_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A494VincularTrnTelefonoSol)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A495VincularTrnImagen));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A496VincularTrnFecha, "99/99/99")));
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
         lblLblvinculartrnidfilter_Internalname = "LBLVINCULARTRNIDFILTER";
         edtavCvinculartrnid_Internalname = "vCVINCULARTRNID";
         divVinculartrnidfiltercontainer_Internalname = "VINCULARTRNIDFILTERCONTAINER";
         lblLblproveedoridfilter_Internalname = "LBLPROVEEDORIDFILTER";
         edtavCproveedorid_Internalname = "vCPROVEEDORID";
         divProveedoridfiltercontainer_Internalname = "PROVEEDORIDFILTERCONTAINER";
         lblLblvinculartrnsolidicutdfilter_Internalname = "LBLVINCULARTRNSOLIDICUTDFILTER";
         edtavCvinculartrnsolidicutd_Internalname = "vCVINCULARTRNSOLIDICUTD";
         divVinculartrnsolidicutdfiltercontainer_Internalname = "VINCULARTRNSOLIDICUTDFILTERCONTAINER";
         lblLblvinculartrnnombresolfilter_Internalname = "LBLVINCULARTRNNOMBRESOLFILTER";
         edtavCvinculartrnnombresol_Internalname = "vCVINCULARTRNNOMBRESOL";
         divVinculartrnnombresolfiltercontainer_Internalname = "VINCULARTRNNOMBRESOLFILTERCONTAINER";
         lblLblvinculartrntelefonosolfilter_Internalname = "LBLVINCULARTRNTELEFONOSOLFILTER";
         edtavCvinculartrntelefonosol_Internalname = "vCVINCULARTRNTELEFONOSOL";
         divVinculartrntelefonosolfiltercontainer_Internalname = "VINCULARTRNTELEFONOSOLFILTERCONTAINER";
         lblLblvinculartrnfechafilter_Internalname = "LBLVINCULARTRNFECHAFILTER";
         edtavCvinculartrnfecha_Internalname = "vCVINCULARTRNFECHA";
         divVinculartrnfechafiltercontainer_Internalname = "VINCULARTRNFECHAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtVincularTrnId_Internalname = "VINCULARTRNID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD";
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL";
         edtVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN";
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA";
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
         edtVincularTrnFecha_Jsonclick = "";
         edtVincularTrnTelefonoSol_Jsonclick = "";
         edtVincularTrnSolidicutd_Jsonclick = "";
         edtVincularTrnSolidicutd_Link = "";
         edtProveedorID_Jsonclick = "";
         edtVincularTrnId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtVincularTrnFecha_Enabled = 0;
         edtVincularTrnImagen_Enabled = 0;
         edtVincularTrnTelefonoSol_Enabled = 0;
         edtVincularTrnSolidicutd_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtVincularTrnId_Enabled = 0;
         edtavCvinculartrnfecha_Jsonclick = "";
         edtavCvinculartrnfecha_Enabled = 1;
         edtavCvinculartrntelefonosol_Jsonclick = "";
         edtavCvinculartrntelefonosol_Enabled = 1;
         edtavCvinculartrntelefonosol_Visible = 1;
         edtavCvinculartrnnombresol_Jsonclick = "";
         edtavCvinculartrnnombresol_Enabled = 1;
         edtavCvinculartrnnombresol_Visible = 1;
         edtavCvinculartrnsolidicutd_Jsonclick = "";
         edtavCvinculartrnsolidicutd_Enabled = 1;
         edtavCvinculartrnsolidicutd_Visible = 1;
         edtavCproveedorid_Jsonclick = "";
         edtavCproveedorid_Enabled = 1;
         edtavCproveedorid_Visible = 1;
         edtavCvinculartrnid_Jsonclick = "";
         edtavCvinculartrnid_Enabled = 1;
         edtavCvinculartrnid_Visible = 1;
         divVinculartrntelefonosolfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVinculartrnnombresolfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVinculartrnsolidicutdfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProveedoridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVinculartrnidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Vincular Trn", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVincularTrnId',fld:'vCVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cVincularTrnSolidicutd',fld:'vCVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cVincularTrnNombreSol',fld:'vCVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV10cVincularTrnTelefonoSol',fld:'vCVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV11cVincularTrnFecha',fld:'vCVINCULARTRNFECHA',pic:'',type:'date'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16AC1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLVINCULARTRNIDFILTER.CLICK","{handler:'E11AC1',iparms:[{av:'divVinculartrnidfiltercontainer_Class',ctrl:'VINCULARTRNIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVINCULARTRNIDFILTER.CLICK",",oparms:[{av:'divVinculartrnidfiltercontainer_Class',ctrl:'VINCULARTRNIDFILTERCONTAINER',prop:'Class'},{av:'edtavCvinculartrnid_Visible',ctrl:'vCVINCULARTRNID',prop:'Visible'}]}");
         setEventMetadata("LBLPROVEEDORIDFILTER.CLICK","{handler:'E12AC1',iparms:[{av:'divProveedoridfiltercontainer_Class',ctrl:'PROVEEDORIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROVEEDORIDFILTER.CLICK",",oparms:[{av:'divProveedoridfiltercontainer_Class',ctrl:'PROVEEDORIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproveedorid_Visible',ctrl:'vCPROVEEDORID',prop:'Visible'}]}");
         setEventMetadata("LBLVINCULARTRNSOLIDICUTDFILTER.CLICK","{handler:'E13AC1',iparms:[{av:'divVinculartrnsolidicutdfiltercontainer_Class',ctrl:'VINCULARTRNSOLIDICUTDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVINCULARTRNSOLIDICUTDFILTER.CLICK",",oparms:[{av:'divVinculartrnsolidicutdfiltercontainer_Class',ctrl:'VINCULARTRNSOLIDICUTDFILTERCONTAINER',prop:'Class'},{av:'edtavCvinculartrnsolidicutd_Visible',ctrl:'vCVINCULARTRNSOLIDICUTD',prop:'Visible'}]}");
         setEventMetadata("LBLVINCULARTRNNOMBRESOLFILTER.CLICK","{handler:'E14AC1',iparms:[{av:'divVinculartrnnombresolfiltercontainer_Class',ctrl:'VINCULARTRNNOMBRESOLFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVINCULARTRNNOMBRESOLFILTER.CLICK",",oparms:[{av:'divVinculartrnnombresolfiltercontainer_Class',ctrl:'VINCULARTRNNOMBRESOLFILTERCONTAINER',prop:'Class'},{av:'edtavCvinculartrnnombresol_Visible',ctrl:'vCVINCULARTRNNOMBRESOL',prop:'Visible'}]}");
         setEventMetadata("LBLVINCULARTRNTELEFONOSOLFILTER.CLICK","{handler:'E15AC1',iparms:[{av:'divVinculartrntelefonosolfiltercontainer_Class',ctrl:'VINCULARTRNTELEFONOSOLFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVINCULARTRNTELEFONOSOLFILTER.CLICK",",oparms:[{av:'divVinculartrntelefonosolfiltercontainer_Class',ctrl:'VINCULARTRNTELEFONOSOLFILTERCONTAINER',prop:'Class'},{av:'edtavCvinculartrntelefonosol_Visible',ctrl:'vCVINCULARTRNTELEFONOSOL',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19AC2',iparms:[{av:'A491VincularTrnId',fld:'VINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pVincularTrnId',fld:'vPVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVincularTrnId',fld:'vCVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cVincularTrnSolidicutd',fld:'vCVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cVincularTrnNombreSol',fld:'vCVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV10cVincularTrnTelefonoSol',fld:'vCVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV11cVincularTrnFecha',fld:'vCVINCULARTRNFECHA',pic:'',type:'date'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVincularTrnId',fld:'vCVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cVincularTrnSolidicutd',fld:'vCVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cVincularTrnNombreSol',fld:'vCVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV10cVincularTrnTelefonoSol',fld:'vCVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV11cVincularTrnFecha',fld:'vCVINCULARTRNFECHA',pic:'',type:'date'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVincularTrnId',fld:'vCVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cVincularTrnSolidicutd',fld:'vCVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cVincularTrnNombreSol',fld:'vCVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV10cVincularTrnTelefonoSol',fld:'vCVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV11cVincularTrnFecha',fld:'vCVINCULARTRNFECHA',pic:'',type:'date'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVincularTrnId',fld:'vCVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cVincularTrnSolidicutd',fld:'vCVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cVincularTrnNombreSol',fld:'vCVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV10cVincularTrnTelefonoSol',fld:'vCVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV11cVincularTrnFecha',fld:'vCVINCULARTRNFECHA',pic:'',type:'date'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CVINCULARTRNFECHA","{handler:'Validv_Cvinculartrnfecha',iparms:[]");
         setEventMetadata("VALIDV_CVINCULARTRNFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Vinculartrnfecha',iparms:[]");
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
         AV9cVincularTrnNombreSol = "";
         AV10cVincularTrnTelefonoSol = "";
         AV11cVincularTrnFecha = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblvinculartrnidfilter_Jsonclick = "";
         TempTags = "";
         lblLblproveedoridfilter_Jsonclick = "";
         lblLblvinculartrnsolidicutdfilter_Jsonclick = "";
         lblLblvinculartrnnombresolfilter_Jsonclick = "";
         lblLblvinculartrntelefonosolfilter_Jsonclick = "";
         lblLblvinculartrnfechafilter_Jsonclick = "";
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
         A494VincularTrnTelefonoSol = "";
         A495VincularTrnImagen = "";
         A40000VincularTrnImagen_GXI = "";
         A496VincularTrnFecha = DateTime.MinValue;
         lV9cVincularTrnNombreSol = "";
         lV10cVincularTrnTelefonoSol = "";
         A493VincularTrnNombreSol = "";
         H00AC2_A493VincularTrnNombreSol = new string[] {""} ;
         H00AC2_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         H00AC2_A40000VincularTrnImagen_GXI = new string[] {""} ;
         H00AC2_A494VincularTrnTelefonoSol = new string[] {""} ;
         H00AC2_A492VincularTrnSolidicutd = new long[1] ;
         H00AC2_A133ProveedorID = new long[1] ;
         H00AC2_A491VincularTrnId = new long[1] ;
         H00AC2_A495VincularTrnImagen = new string[] {""} ;
         H00AC3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0210__default(),
            new Object[][] {
                new Object[] {
               H00AC2_A493VincularTrnNombreSol, H00AC2_A496VincularTrnFecha, H00AC2_A40000VincularTrnImagen_GXI, H00AC2_A494VincularTrnTelefonoSol, H00AC2_A492VincularTrnSolidicutd, H00AC2_A133ProveedorID, H00AC2_A491VincularTrnId, H00AC2_A495VincularTrnImagen
               }
               , new Object[] {
               H00AC3_AGRID1_nRecordCount
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCvinculartrnid_Enabled ;
      private int edtavCvinculartrnid_Visible ;
      private int edtavCproveedorid_Enabled ;
      private int edtavCproveedorid_Visible ;
      private int edtavCvinculartrnsolidicutd_Enabled ;
      private int edtavCvinculartrnsolidicutd_Visible ;
      private int edtavCvinculartrnnombresol_Visible ;
      private int edtavCvinculartrnnombresol_Enabled ;
      private int edtavCvinculartrntelefonosol_Visible ;
      private int edtavCvinculartrntelefonosol_Enabled ;
      private int edtavCvinculartrnfecha_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtVincularTrnId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtVincularTrnSolidicutd_Enabled ;
      private int edtVincularTrnTelefonoSol_Enabled ;
      private int edtVincularTrnImagen_Enabled ;
      private int edtVincularTrnFecha_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pVincularTrnId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cVincularTrnId ;
      private long AV7cProveedorID ;
      private long AV8cVincularTrnSolidicutd ;
      private long A491VincularTrnId ;
      private long A133ProveedorID ;
      private long A492VincularTrnSolidicutd ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divVinculartrnidfiltercontainer_Class ;
      private string divProveedoridfiltercontainer_Class ;
      private string divVinculartrnsolidicutdfiltercontainer_Class ;
      private string divVinculartrnnombresolfiltercontainer_Class ;
      private string divVinculartrntelefonosolfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV9cVincularTrnNombreSol ;
      private string AV10cVincularTrnTelefonoSol ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divVinculartrnidfiltercontainer_Internalname ;
      private string lblLblvinculartrnidfilter_Internalname ;
      private string lblLblvinculartrnidfilter_Jsonclick ;
      private string edtavCvinculartrnid_Internalname ;
      private string TempTags ;
      private string edtavCvinculartrnid_Jsonclick ;
      private string divProveedoridfiltercontainer_Internalname ;
      private string lblLblproveedoridfilter_Internalname ;
      private string lblLblproveedoridfilter_Jsonclick ;
      private string edtavCproveedorid_Internalname ;
      private string edtavCproveedorid_Jsonclick ;
      private string divVinculartrnsolidicutdfiltercontainer_Internalname ;
      private string lblLblvinculartrnsolidicutdfilter_Internalname ;
      private string lblLblvinculartrnsolidicutdfilter_Jsonclick ;
      private string edtavCvinculartrnsolidicutd_Internalname ;
      private string edtavCvinculartrnsolidicutd_Jsonclick ;
      private string divVinculartrnnombresolfiltercontainer_Internalname ;
      private string lblLblvinculartrnnombresolfilter_Internalname ;
      private string lblLblvinculartrnnombresolfilter_Jsonclick ;
      private string edtavCvinculartrnnombresol_Internalname ;
      private string edtavCvinculartrnnombresol_Jsonclick ;
      private string divVinculartrntelefonosolfiltercontainer_Internalname ;
      private string lblLblvinculartrntelefonosolfilter_Internalname ;
      private string lblLblvinculartrntelefonosolfilter_Jsonclick ;
      private string edtavCvinculartrntelefonosol_Internalname ;
      private string edtavCvinculartrntelefonosol_Jsonclick ;
      private string divVinculartrnfechafiltercontainer_Internalname ;
      private string lblLblvinculartrnfechafilter_Internalname ;
      private string lblLblvinculartrnfechafilter_Jsonclick ;
      private string edtavCvinculartrnfecha_Internalname ;
      private string edtavCvinculartrnfecha_Jsonclick ;
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
      private string edtVincularTrnId_Internalname ;
      private string edtProveedorID_Internalname ;
      private string edtVincularTrnSolidicutd_Internalname ;
      private string A494VincularTrnTelefonoSol ;
      private string edtVincularTrnTelefonoSol_Internalname ;
      private string edtVincularTrnImagen_Internalname ;
      private string edtVincularTrnFecha_Internalname ;
      private string lV9cVincularTrnNombreSol ;
      private string lV10cVincularTrnTelefonoSol ;
      private string A493VincularTrnNombreSol ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtVincularTrnId_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtVincularTrnSolidicutd_Link ;
      private string edtVincularTrnSolidicutd_Jsonclick ;
      private string gxphoneLink ;
      private string edtVincularTrnTelefonoSol_Jsonclick ;
      private string edtVincularTrnFecha_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cVincularTrnFecha ;
      private DateTime A496VincularTrnFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A495VincularTrnImagen_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string A40000VincularTrnImagen_GXI ;
      private string AV5LinkSelection ;
      private string A495VincularTrnImagen ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00AC2_A493VincularTrnNombreSol ;
      private DateTime[] H00AC2_A496VincularTrnFecha ;
      private string[] H00AC2_A40000VincularTrnImagen_GXI ;
      private string[] H00AC2_A494VincularTrnTelefonoSol ;
      private long[] H00AC2_A492VincularTrnSolidicutd ;
      private long[] H00AC2_A133ProveedorID ;
      private long[] H00AC2_A491VincularTrnId ;
      private string[] H00AC2_A495VincularTrnImagen ;
      private long[] H00AC3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pVincularTrnId ;
   }

   public class gx0210__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00AC2( IGxContext context ,
                                             long AV7cProveedorID ,
                                             long AV8cVincularTrnSolidicutd ,
                                             string AV9cVincularTrnNombreSol ,
                                             string AV10cVincularTrnTelefonoSol ,
                                             DateTime AV11cVincularTrnFecha ,
                                             long A133ProveedorID ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             DateTime A496VincularTrnFecha ,
                                             long AV6cVincularTrnId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [VincularTrnNombreSol], [VincularTrnFecha], [VincularTrnImagen_GXI], [VincularTrnTelefonoSol], [VincularTrnSolidicutd], [ProveedorID], [VincularTrnId], [VincularTrnImagen]";
         sFromString = " FROM [VincularTrn]";
         sOrderString = "";
         AddWhere(sWhereString, "([VincularTrnId] >= @AV6cVincularTrnId)");
         if ( ! (0==AV7cProveedorID) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV7cProveedorID)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cVincularTrnSolidicutd) )
         {
            AddWhere(sWhereString, "([VincularTrnSolidicutd] >= @AV8cVincularTrnSolidicutd)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cVincularTrnNombreSol)) )
         {
            AddWhere(sWhereString, "([VincularTrnNombreSol] like @lV9cVincularTrnNombreSol)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cVincularTrnTelefonoSol)) )
         {
            AddWhere(sWhereString, "([VincularTrnTelefonoSol] like @lV10cVincularTrnTelefonoSol)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cVincularTrnFecha) )
         {
            AddWhere(sWhereString, "([VincularTrnFecha] >= @AV11cVincularTrnFecha)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [VincularTrnId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00AC3( IGxContext context ,
                                             long AV7cProveedorID ,
                                             long AV8cVincularTrnSolidicutd ,
                                             string AV9cVincularTrnNombreSol ,
                                             string AV10cVincularTrnTelefonoSol ,
                                             DateTime AV11cVincularTrnFecha ,
                                             long A133ProveedorID ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             DateTime A496VincularTrnFecha ,
                                             long AV6cVincularTrnId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [VincularTrn]";
         AddWhere(sWhereString, "([VincularTrnId] >= @AV6cVincularTrnId)");
         if ( ! (0==AV7cProveedorID) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV7cProveedorID)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cVincularTrnSolidicutd) )
         {
            AddWhere(sWhereString, "([VincularTrnSolidicutd] >= @AV8cVincularTrnSolidicutd)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cVincularTrnNombreSol)) )
         {
            AddWhere(sWhereString, "([VincularTrnNombreSol] like @lV9cVincularTrnNombreSol)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cVincularTrnTelefonoSol)) )
         {
            AddWhere(sWhereString, "([VincularTrnTelefonoSol] like @lV10cVincularTrnTelefonoSol)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cVincularTrnFecha) )
         {
            AddWhere(sWhereString, "([VincularTrnFecha] >= @AV11cVincularTrnFecha)");
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
                     return conditional_H00AC2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] );
               case 1 :
                     return conditional_H00AC3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] );
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
          Object[] prmH00AC2;
          prmH00AC2 = new Object[] {
          new ParDef("@AV6cVincularTrnId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8cVincularTrnSolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@lV9cVincularTrnNombreSol",GXType.NChar,80,0) ,
          new ParDef("@lV10cVincularTrnTelefonoSol",GXType.NChar,20,0) ,
          new ParDef("@AV11cVincularTrnFecha",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00AC3;
          prmH00AC3 = new Object[] {
          new ParDef("@AV6cVincularTrnId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8cVincularTrnSolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@lV9cVincularTrnNombreSol",GXType.NChar,80,0) ,
          new ParDef("@lV10cVincularTrnTelefonoSol",GXType.NChar,20,0) ,
          new ParDef("@AV11cVincularTrnFecha",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AC2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00AC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AC3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

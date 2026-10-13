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
   public class gx01i1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01i1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01i1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pConfigGenID ,
                           out long aP1_pConfigGenPublicidadId )
      {
         this.AV11pConfigGenID = aP0_pConfigGenID;
         this.AV12pConfigGenPublicidadId = 0 ;
         ExecutePrivate();
         aP1_pConfigGenPublicidadId=this.AV12pConfigGenPublicidadId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCconfiggenpublicidadesta = new GXCombobox();
         cmbConfigGenPublicidadEsta = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pConfigGenID");
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
               gxfirstwebparm = GetFirstPar( "pConfigGenID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pConfigGenID");
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
               AV11pConfigGenID = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pConfigGenID", StringUtil.LTrimStr( (decimal)(AV11pConfigGenID), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pConfigGenPublicidadId = (long)(Math.Round(NumberUtil.Val( GetPar( "pConfigGenPublicidadId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12pConfigGenPublicidadId", StringUtil.LTrimStr( (decimal)(AV12pConfigGenPublicidadId), 18, 0));
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
         AV6cConfigGenPublicidadId = (long)(Math.Round(NumberUtil.Val( GetPar( "cConfigGenPublicidadId"), "."), 18, MidpointRounding.ToEven));
         AV7cConfigGenPublicidadTit = GetPar( "cConfigGenPublicidadTit");
         AV8cConfigGenPublicidadFecIni = context.localUtil.ParseDTimeParm( GetPar( "cConfigGenPublicidadFecIni"));
         AV9cConfigGenPublicidadFecFin = context.localUtil.ParseDTimeParm( GetPar( "cConfigGenPublicidadFecFin"));
         cmbavCconfiggenpublicidadesta.FromJSonString( GetNextPar( ));
         AV10cConfigGenPublicidadEsta = GetPar( "cConfigGenPublicidadEsta");
         AV11pConfigGenID = (short)(Math.Round(NumberUtil.Val( GetPar( "pConfigGenID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenPublicidadId, AV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, AV10cConfigGenPublicidadEsta, AV11pConfigGenID) ;
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
         PA9T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01i1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pConfigGenID,4,0)),UrlEncode(StringUtil.LTrimStr(AV12pConfigGenPublicidadId,18,0))}, new string[] {"pConfigGenID","pConfigGenPublicidadId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENPUBLICIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENPUBLICIDADTIT", StringUtil.RTrim( AV7cConfigGenPublicidadTit));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENPUBLICIDADFECINI", context.localUtil.TToC( AV8cConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENPUBLICIDADFECFIN", context.localUtil.TToC( AV9cConfigGenPublicidadFecFin, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCCONFIGGENPUBLICIDADESTA", StringUtil.RTrim( AV10cConfigGenPublicidadEsta));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCONFIGGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCONFIGGENPUBLICIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADIDFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenpublicidadidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADTITFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenpublicidadtitfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADESTAFILTERCONTAINER_Class", StringUtil.RTrim( divConfiggenpublicidadestafiltercontainer_Class));
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
            WE9T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9T2( ) ;
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
         return formatLink("gx01i1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pConfigGenID,4,0)),UrlEncode(StringUtil.LTrimStr(AV12pConfigGenPublicidadId,18,0))}, new string[] {"pConfigGenID","pConfigGenPublicidadId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01I1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Publicidad", "") ;
      }

      protected void WB9T0( )
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
            GxWebStd.gx_div_start( context, divConfiggenpublicidadidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenpublicidadidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenpublicidadidfilter_Internalname, context.GetMessage( "No.", ""), "", "", lblLblconfiggenpublicidadidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01I1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggenpublicidadid_Internalname, context.GetMessage( "No.", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenpublicidadid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCconfiggenpublicidadid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenpublicidadid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggenpublicidadid_Visible, edtavCconfiggenpublicidadid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01I1.htm");
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
            GxWebStd.gx_div_start( context, divConfiggenpublicidadtitfiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenpublicidadtitfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenpublicidadtitfilter_Internalname, context.GetMessage( "Título", ""), "", "", lblLblconfiggenpublicidadtitfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01I1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggenpublicidadtit_Internalname, context.GetMessage( "Título", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenpublicidadtit_Internalname, StringUtil.RTrim( AV7cConfigGenPublicidadTit), StringUtil.RTrim( context.localUtil.Format( AV7cConfigGenPublicidadTit, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenpublicidadtit_Jsonclick, 0, "Attribute", "", "", "", "", edtavCconfiggenpublicidadtit_Visible, edtavCconfiggenpublicidadtit_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01I1.htm");
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
            GxWebStd.gx_div_start( context, divConfiggenpublicidadfecinifiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenpublicidadfecinifilter_Internalname, context.GetMessage( "Fecha de Inicio", ""), "", "", lblLblconfiggenpublicidadfecinifilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx01I1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggenpublicidadfecini_Internalname, context.GetMessage( "Fecha de Inicio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCconfiggenpublicidadfecini_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenpublicidadfecini_Internalname, context.localUtil.TToC( AV8cConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV8cConfigGenPublicidadFecIni, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenpublicidadfecini_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCconfiggenpublicidadfecini_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01I1.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divConfiggenpublicidadfecfinfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenpublicidadfecfinfilter_Internalname, context.GetMessage( "Fecha Fin", ""), "", "", lblLblconfiggenpublicidadfecfinfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx01I1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCconfiggenpublicidadfecfin_Internalname, context.GetMessage( "Fecha Fin", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCconfiggenpublicidadfecfin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCconfiggenpublicidadfecfin_Internalname, context.localUtil.TToC( AV9cConfigGenPublicidadFecFin, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV9cConfigGenPublicidadFecFin, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCconfiggenpublicidadfecfin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCconfiggenpublicidadfecfin_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01I1.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divConfiggenpublicidadestafiltercontainer_Internalname, 1, 0, "px", 0, "px", divConfiggenpublicidadestafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfiggenpublicidadestafilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblconfiggenpublicidadestafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01I1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCconfiggenpublicidadesta_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCconfiggenpublicidadesta, cmbavCconfiggenpublicidadesta_Internalname, StringUtil.RTrim( AV10cConfigGenPublicidadEsta), 1, cmbavCconfiggenpublicidadesta_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCconfiggenpublicidadesta.Visible, cmbavCconfiggenpublicidadesta.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Gx01I1.htm");
            cmbavCconfiggenpublicidadesta.CurrentValue = StringUtil.RTrim( AV10cConfigGenPublicidadEsta);
            AssignProp("", false, cmbavCconfiggenpublicidadesta_Internalname, "Values", (string)(cmbavCconfiggenpublicidadesta.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e149t1_client"+"'", TempTags, "", 2, "HLP_Gx01I1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01I1.htm");
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

      protected void START9T2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Publicidad", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9T0( ) ;
      }

      protected void WS9T2( )
      {
         START9T2( ) ;
         EVT9T2( ) ;
      }

      protected void EVT9T2( )
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
                              A350ConfigGenPublicidadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenPublicidadId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A359ConfigGenPublicidadTit = cgiGet( edtConfigGenPublicidadTit_Internalname);
                              A361ConfigGenPublicidadIma = cgiGet( edtConfigGenPublicidadIma_Internalname);
                              AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40000ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
                              A362ConfigGenPublicidadFecIni = context.localUtil.CToT( cgiGet( edtConfigGenPublicidadFecIni_Internalname), 0);
                              cmbConfigGenPublicidadEsta.Name = cmbConfigGenPublicidadEsta_Internalname;
                              cmbConfigGenPublicidadEsta.CurrentValue = cgiGet( cmbConfigGenPublicidadEsta_Internalname);
                              A364ConfigGenPublicidadEsta = cgiGet( cmbConfigGenPublicidadEsta_Internalname);
                              A349ConfigGenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtConfigGenID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E159T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E169T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cconfiggenpublicidadid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONFIGGENPUBLICIDADID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cConfigGenPublicidadId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenpublicidadtit Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENPUBLICIDADTIT"), AV7cConfigGenPublicidadTit) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenpublicidadfecini Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCONFIGGENPUBLICIDADFECINI"), 0) != AV8cConfigGenPublicidadFecIni )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenpublicidadfecfin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCONFIGGENPUBLICIDADFECFIN"), 0) != AV9cConfigGenPublicidadFecFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cconfiggenpublicidadesta Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENPUBLICIDADESTA"), AV10cConfigGenPublicidadEsta) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E179T2 ();
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

      protected void WE9T2( )
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

      protected void PA9T2( )
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
                                        long AV6cConfigGenPublicidadId ,
                                        string AV7cConfigGenPublicidadTit ,
                                        DateTime AV8cConfigGenPublicidadFecIni ,
                                        DateTime AV9cConfigGenPublicidadFecFin ,
                                        string AV10cConfigGenPublicidadEsta ,
                                        short AV11pConfigGenID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONFIGGENPUBLICIDADID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A350ConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONFIGGENPUBLICIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, ".", "")));
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
         if ( cmbavCconfiggenpublicidadesta.ItemCount > 0 )
         {
            AV10cConfigGenPublicidadEsta = cmbavCconfiggenpublicidadesta.getValidValue(AV10cConfigGenPublicidadEsta);
            AssignAttri("", false, "AV10cConfigGenPublicidadEsta", AV10cConfigGenPublicidadEsta);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCconfiggenpublicidadesta.CurrentValue = StringUtil.RTrim( AV10cConfigGenPublicidadEsta);
            AssignProp("", false, cmbavCconfiggenpublicidadesta_Internalname, "Values", cmbavCconfiggenpublicidadesta.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9T2( )
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
                                                 AV7cConfigGenPublicidadTit ,
                                                 AV8cConfigGenPublicidadFecIni ,
                                                 AV9cConfigGenPublicidadFecFin ,
                                                 AV10cConfigGenPublicidadEsta ,
                                                 A359ConfigGenPublicidadTit ,
                                                 A362ConfigGenPublicidadFecIni ,
                                                 A363ConfigGenPublicidadFecFin ,
                                                 A364ConfigGenPublicidadEsta ,
                                                 AV11pConfigGenID ,
                                                 AV6cConfigGenPublicidadId ,
                                                 A349ConfigGenID } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                                 }
            });
            lV7cConfigGenPublicidadTit = StringUtil.PadR( StringUtil.RTrim( AV7cConfigGenPublicidadTit), 80, "%");
            lV10cConfigGenPublicidadEsta = StringUtil.PadR( StringUtil.RTrim( AV10cConfigGenPublicidadEsta), 3, "%");
            /* Using cursor H009T2 */
            pr_default.execute(0, new Object[] {AV11pConfigGenID, AV6cConfigGenPublicidadId, lV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, lV10cConfigGenPublicidadEsta, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A363ConfigGenPublicidadFecFin = H009T2_A363ConfigGenPublicidadFecFin[0];
               A349ConfigGenID = H009T2_A349ConfigGenID[0];
               A364ConfigGenPublicidadEsta = H009T2_A364ConfigGenPublicidadEsta[0];
               A362ConfigGenPublicidadFecIni = H009T2_A362ConfigGenPublicidadFecIni[0];
               A40000ConfigGenPublicidadIma_GXI = H009T2_A40000ConfigGenPublicidadIma_GXI[0];
               AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40000ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_64_Refreshing);
               AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
               A359ConfigGenPublicidadTit = H009T2_A359ConfigGenPublicidadTit[0];
               A350ConfigGenPublicidadId = H009T2_A350ConfigGenPublicidadId[0];
               A361ConfigGenPublicidadIma = H009T2_A361ConfigGenPublicidadIma[0];
               AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40000ConfigGenPublicidadIma_GXI : context.convertURL( context.PathToRelativeUrl( A361ConfigGenPublicidadIma))), !bGXsfl_64_Refreshing);
               AssignProp("", false, edtConfigGenPublicidadIma_Internalname, "SrcSet", context.GetImageSrcSet( A361ConfigGenPublicidadIma), true);
               /* Execute user event: Load */
               E169T2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB9T0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9T2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONFIGGENPUBLICIDADID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A350ConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cConfigGenPublicidadTit ,
                                              AV8cConfigGenPublicidadFecIni ,
                                              AV9cConfigGenPublicidadFecFin ,
                                              AV10cConfigGenPublicidadEsta ,
                                              A359ConfigGenPublicidadTit ,
                                              A362ConfigGenPublicidadFecIni ,
                                              A363ConfigGenPublicidadFecFin ,
                                              A364ConfigGenPublicidadEsta ,
                                              AV11pConfigGenID ,
                                              AV6cConfigGenPublicidadId ,
                                              A349ConfigGenID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV7cConfigGenPublicidadTit = StringUtil.PadR( StringUtil.RTrim( AV7cConfigGenPublicidadTit), 80, "%");
         lV10cConfigGenPublicidadEsta = StringUtil.PadR( StringUtil.RTrim( AV10cConfigGenPublicidadEsta), 3, "%");
         /* Using cursor H009T3 */
         pr_default.execute(1, new Object[] {AV11pConfigGenID, AV6cConfigGenPublicidadId, lV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, lV10cConfigGenPublicidadEsta});
         GRID1_nRecordCount = H009T3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenPublicidadId, AV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, AV10cConfigGenPublicidadEsta, AV11pConfigGenID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenPublicidadId, AV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, AV10cConfigGenPublicidadEsta, AV11pConfigGenID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenPublicidadId, AV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, AV10cConfigGenPublicidadEsta, AV11pConfigGenID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenPublicidadId, AV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, AV10cConfigGenPublicidadEsta, AV11pConfigGenID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cConfigGenPublicidadId, AV7cConfigGenPublicidadTit, AV8cConfigGenPublicidadFecIni, AV9cConfigGenPublicidadFecFin, AV10cConfigGenPublicidadEsta, AV11pConfigGenID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtConfigGenPublicidadId_Enabled = 0;
         edtConfigGenPublicidadTit_Enabled = 0;
         edtConfigGenPublicidadIma_Enabled = 0;
         edtConfigGenPublicidadFecIni_Enabled = 0;
         cmbConfigGenPublicidadEsta.Enabled = 0;
         edtConfigGenID_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E159T2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCconfiggenpublicidadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCconfiggenpublicidadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCONFIGGENPUBLICIDADID");
               GX_FocusControl = edtavCconfiggenpublicidadid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cConfigGenPublicidadId = 0;
               AssignAttri("", false, "AV6cConfigGenPublicidadId", StringUtil.LTrimStr( (decimal)(AV6cConfigGenPublicidadId), 18, 0));
            }
            else
            {
               AV6cConfigGenPublicidadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCconfiggenpublicidadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cConfigGenPublicidadId", StringUtil.LTrimStr( (decimal)(AV6cConfigGenPublicidadId), 18, 0));
            }
            AV7cConfigGenPublicidadTit = cgiGet( edtavCconfiggenpublicidadtit_Internalname);
            AssignAttri("", false, "AV7cConfigGenPublicidadTit", AV7cConfigGenPublicidadTit);
            if ( context.localUtil.VCDateTime( cgiGet( edtavCconfiggenpublicidadfecini_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha de Inicio", "")}), 1, "vCCONFIGGENPUBLICIDADFECINI");
               GX_FocusControl = edtavCconfiggenpublicidadfecini_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8cConfigGenPublicidadFecIni", context.localUtil.TToC( AV8cConfigGenPublicidadFecIni, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV8cConfigGenPublicidadFecIni = context.localUtil.CToT( cgiGet( edtavCconfiggenpublicidadfecini_Internalname));
               AssignAttri("", false, "AV8cConfigGenPublicidadFecIni", context.localUtil.TToC( AV8cConfigGenPublicidadFecIni, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCconfiggenpublicidadfecfin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Fin", "")}), 1, "vCCONFIGGENPUBLICIDADFECFIN");
               GX_FocusControl = edtavCconfiggenpublicidadfecfin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9cConfigGenPublicidadFecFin", context.localUtil.TToC( AV9cConfigGenPublicidadFecFin, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV9cConfigGenPublicidadFecFin = context.localUtil.CToT( cgiGet( edtavCconfiggenpublicidadfecfin_Internalname));
               AssignAttri("", false, "AV9cConfigGenPublicidadFecFin", context.localUtil.TToC( AV9cConfigGenPublicidadFecFin, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            cmbavCconfiggenpublicidadesta.Name = cmbavCconfiggenpublicidadesta_Internalname;
            cmbavCconfiggenpublicidadesta.CurrentValue = cgiGet( cmbavCconfiggenpublicidadesta_Internalname);
            AV10cConfigGenPublicidadEsta = cgiGet( cmbavCconfiggenpublicidadesta_Internalname);
            AssignAttri("", false, "AV10cConfigGenPublicidadEsta", AV10cConfigGenPublicidadEsta);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCONFIGGENPUBLICIDADID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cConfigGenPublicidadId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENPUBLICIDADTIT"), AV7cConfigGenPublicidadTit) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCCONFIGGENPUBLICIDADFECINI")) != AV8cConfigGenPublicidadFecIni )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCCONFIGGENPUBLICIDADFECFIN")) != AV9cConfigGenPublicidadFecFin )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCONFIGGENPUBLICIDADESTA"), AV10cConfigGenPublicidadEsta) != 0 )
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
         E159T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E159T2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Publicidad", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E169T2( )
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
         E179T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E179T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pConfigGenPublicidadId = A350ConfigGenPublicidadId;
         AssignAttri("", false, "AV12pConfigGenPublicidadId", StringUtil.LTrimStr( (decimal)(AV12pConfigGenPublicidadId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pConfigGenPublicidadId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pConfigGenPublicidadId"});
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
         AV11pConfigGenID = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pConfigGenID", StringUtil.LTrimStr( (decimal)(AV11pConfigGenID), 4, 0));
         AV12pConfigGenPublicidadId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV12pConfigGenPublicidadId", StringUtil.LTrimStr( (decimal)(AV12pConfigGenPublicidadId), 18, 0));
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
         PA9T2( ) ;
         WS9T2( ) ;
         WE9T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126332", true, true, false);
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
         context.AddJavascriptSource("gx01i1.js", "?20267302126332", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtConfigGenPublicidadId_Internalname = "CONFIGGENPUBLICIDADID_"+sGXsfl_64_idx;
         edtConfigGenPublicidadTit_Internalname = "CONFIGGENPUBLICIDADTIT_"+sGXsfl_64_idx;
         edtConfigGenPublicidadIma_Internalname = "CONFIGGENPUBLICIDADIMA_"+sGXsfl_64_idx;
         edtConfigGenPublicidadFecIni_Internalname = "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_64_idx;
         cmbConfigGenPublicidadEsta_Internalname = "CONFIGGENPUBLICIDADESTA_"+sGXsfl_64_idx;
         edtConfigGenID_Internalname = "CONFIGGENID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtConfigGenPublicidadId_Internalname = "CONFIGGENPUBLICIDADID_"+sGXsfl_64_fel_idx;
         edtConfigGenPublicidadTit_Internalname = "CONFIGGENPUBLICIDADTIT_"+sGXsfl_64_fel_idx;
         edtConfigGenPublicidadIma_Internalname = "CONFIGGENPUBLICIDADIMA_"+sGXsfl_64_fel_idx;
         edtConfigGenPublicidadFecIni_Internalname = "CONFIGGENPUBLICIDADFECINI_"+sGXsfl_64_fel_idx;
         cmbConfigGenPublicidadEsta_Internalname = "CONFIGGENPUBLICIDADESTA_"+sGXsfl_64_fel_idx;
         edtConfigGenID_Internalname = "CONFIGGENID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB9T0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A350ConfigGenPublicidadId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtConfigGenPublicidadTit_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtConfigGenPublicidadTit_Internalname, "Link", edtConfigGenPublicidadTit_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadTit_Internalname,StringUtil.RTrim( A359ConfigGenPublicidadTit),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtConfigGenPublicidadTit_Link,(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadTit_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A361ConfigGenPublicidadIma_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ConfigGenPublicidadIma_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A361ConfigGenPublicidadIma)) ? A40000ConfigGenPublicidadIma_GXI : context.PathToRelativeUrl( A361ConfigGenPublicidadIma));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadIma_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A361ConfigGenPublicidadIma_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenPublicidadFecIni_Internalname,context.localUtil.TToC( A362ConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A362ConfigGenPublicidadFecIni, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenPublicidadFecIni_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbConfigGenPublicidadEsta.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONFIGGENPUBLICIDADESTA_" + sGXsfl_64_idx;
               cmbConfigGenPublicidadEsta.Name = GXCCtl;
               cmbConfigGenPublicidadEsta.WebTags = "";
               cmbConfigGenPublicidadEsta.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbConfigGenPublicidadEsta.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               if ( cmbConfigGenPublicidadEsta.ItemCount > 0 )
               {
                  A364ConfigGenPublicidadEsta = cmbConfigGenPublicidadEsta.getValidValue(A364ConfigGenPublicidadEsta);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbConfigGenPublicidadEsta,(string)cmbConfigGenPublicidadEsta_Internalname,StringUtil.RTrim( A364ConfigGenPublicidadEsta),(short)1,(string)cmbConfigGenPublicidadEsta_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbConfigGenPublicidadEsta.CurrentValue = StringUtil.RTrim( A364ConfigGenPublicidadEsta);
            AssignProp("", false, cmbConfigGenPublicidadEsta_Internalname, "Values", (string)(cmbConfigGenPublicidadEsta.ToJavascriptSource()), !bGXsfl_64_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfigGenID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfigGenID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9T2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         cmbavCconfiggenpublicidadesta.Name = "vCCONFIGGENPUBLICIDADESTA";
         cmbavCconfiggenpublicidadesta.WebTags = "";
         cmbavCconfiggenpublicidadesta.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCconfiggenpublicidadesta.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbavCconfiggenpublicidadesta.ItemCount > 0 )
         {
            AV10cConfigGenPublicidadEsta = cmbavCconfiggenpublicidadesta.getValidValue(AV10cConfigGenPublicidadEsta);
            AssignAttri("", false, "AV10cConfigGenPublicidadEsta", AV10cConfigGenPublicidadEsta);
         }
         GXCCtl = "CONFIGGENPUBLICIDADESTA_" + sGXsfl_64_idx;
         cmbConfigGenPublicidadEsta.Name = GXCCtl;
         cmbConfigGenPublicidadEsta.WebTags = "";
         cmbConfigGenPublicidadEsta.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbConfigGenPublicidadEsta.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbConfigGenPublicidadEsta.ItemCount > 0 )
         {
            A364ConfigGenPublicidadEsta = cmbConfigGenPublicidadEsta.getValidValue(A364ConfigGenPublicidadEsta);
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
            context.SendWebValue( context.GetMessage( "No.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Título", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Inicio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Config Gen ID", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A350ConfigGenPublicidadId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A359ConfigGenPublicidadTit)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtConfigGenPublicidadTit_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A361ConfigGenPublicidadIma));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A362ConfigGenPublicidadFecIni, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A364ConfigGenPublicidadEsta)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A349ConfigGenID), 4, 0, ".", ""))));
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
         lblLblconfiggenpublicidadidfilter_Internalname = "LBLCONFIGGENPUBLICIDADIDFILTER";
         edtavCconfiggenpublicidadid_Internalname = "vCCONFIGGENPUBLICIDADID";
         divConfiggenpublicidadidfiltercontainer_Internalname = "CONFIGGENPUBLICIDADIDFILTERCONTAINER";
         lblLblconfiggenpublicidadtitfilter_Internalname = "LBLCONFIGGENPUBLICIDADTITFILTER";
         edtavCconfiggenpublicidadtit_Internalname = "vCCONFIGGENPUBLICIDADTIT";
         divConfiggenpublicidadtitfiltercontainer_Internalname = "CONFIGGENPUBLICIDADTITFILTERCONTAINER";
         lblLblconfiggenpublicidadfecinifilter_Internalname = "LBLCONFIGGENPUBLICIDADFECINIFILTER";
         edtavCconfiggenpublicidadfecini_Internalname = "vCCONFIGGENPUBLICIDADFECINI";
         divConfiggenpublicidadfecinifiltercontainer_Internalname = "CONFIGGENPUBLICIDADFECINIFILTERCONTAINER";
         lblLblconfiggenpublicidadfecfinfilter_Internalname = "LBLCONFIGGENPUBLICIDADFECFINFILTER";
         edtavCconfiggenpublicidadfecfin_Internalname = "vCCONFIGGENPUBLICIDADFECFIN";
         divConfiggenpublicidadfecfinfiltercontainer_Internalname = "CONFIGGENPUBLICIDADFECFINFILTERCONTAINER";
         lblLblconfiggenpublicidadestafilter_Internalname = "LBLCONFIGGENPUBLICIDADESTAFILTER";
         cmbavCconfiggenpublicidadesta_Internalname = "vCCONFIGGENPUBLICIDADESTA";
         divConfiggenpublicidadestafiltercontainer_Internalname = "CONFIGGENPUBLICIDADESTAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtConfigGenPublicidadId_Internalname = "CONFIGGENPUBLICIDADID";
         edtConfigGenPublicidadTit_Internalname = "CONFIGGENPUBLICIDADTIT";
         edtConfigGenPublicidadIma_Internalname = "CONFIGGENPUBLICIDADIMA";
         edtConfigGenPublicidadFecIni_Internalname = "CONFIGGENPUBLICIDADFECINI";
         cmbConfigGenPublicidadEsta_Internalname = "CONFIGGENPUBLICIDADESTA";
         edtConfigGenID_Internalname = "CONFIGGENID";
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
         edtConfigGenID_Jsonclick = "";
         cmbConfigGenPublicidadEsta_Jsonclick = "";
         edtConfigGenPublicidadFecIni_Jsonclick = "";
         edtConfigGenPublicidadTit_Jsonclick = "";
         edtConfigGenPublicidadTit_Link = "";
         edtConfigGenPublicidadId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtConfigGenID_Enabled = 0;
         cmbConfigGenPublicidadEsta.Enabled = 0;
         edtConfigGenPublicidadFecIni_Enabled = 0;
         edtConfigGenPublicidadIma_Enabled = 0;
         edtConfigGenPublicidadTit_Enabled = 0;
         edtConfigGenPublicidadId_Enabled = 0;
         cmbavCconfiggenpublicidadesta_Jsonclick = "";
         cmbavCconfiggenpublicidadesta.Visible = 1;
         cmbavCconfiggenpublicidadesta.Enabled = 1;
         edtavCconfiggenpublicidadfecfin_Jsonclick = "";
         edtavCconfiggenpublicidadfecfin_Enabled = 1;
         edtavCconfiggenpublicidadfecini_Jsonclick = "";
         edtavCconfiggenpublicidadfecini_Enabled = 1;
         edtavCconfiggenpublicidadtit_Jsonclick = "";
         edtavCconfiggenpublicidadtit_Enabled = 1;
         edtavCconfiggenpublicidadtit_Visible = 1;
         edtavCconfiggenpublicidadid_Jsonclick = "";
         edtavCconfiggenpublicidadid_Enabled = 1;
         edtavCconfiggenpublicidadid_Visible = 1;
         divConfiggenpublicidadestafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggenpublicidadtitfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divConfiggenpublicidadidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Publicidad", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenPublicidadId',fld:'vCCONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenPublicidadTit',fld:'vCCONFIGGENPUBLICIDADTIT',pic:'',type:'char'},{av:'AV8cConfigGenPublicidadFecIni',fld:'vCCONFIGGENPUBLICIDADFECINI',pic:'99/99/99 99:99',type:'dtime'},{av:'AV9cConfigGenPublicidadFecFin',fld:'vCCONFIGGENPUBLICIDADFECFIN',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCconfiggenpublicidadesta'},{av:'AV10cConfigGenPublicidadEsta',fld:'vCCONFIGGENPUBLICIDADESTA',pic:'',type:'char'},{av:'AV11pConfigGenID',fld:'vPCONFIGGENID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E149T1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCONFIGGENPUBLICIDADIDFILTER.CLICK","{handler:'E119T1',iparms:[{av:'divConfiggenpublicidadidfiltercontainer_Class',ctrl:'CONFIGGENPUBLICIDADIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENPUBLICIDADIDFILTER.CLICK",",oparms:[{av:'divConfiggenpublicidadidfiltercontainer_Class',ctrl:'CONFIGGENPUBLICIDADIDFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggenpublicidadid_Visible',ctrl:'vCCONFIGGENPUBLICIDADID',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENPUBLICIDADTITFILTER.CLICK","{handler:'E129T1',iparms:[{av:'divConfiggenpublicidadtitfiltercontainer_Class',ctrl:'CONFIGGENPUBLICIDADTITFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENPUBLICIDADTITFILTER.CLICK",",oparms:[{av:'divConfiggenpublicidadtitfiltercontainer_Class',ctrl:'CONFIGGENPUBLICIDADTITFILTERCONTAINER',prop:'Class'},{av:'edtavCconfiggenpublicidadtit_Visible',ctrl:'vCCONFIGGENPUBLICIDADTIT',prop:'Visible'}]}");
         setEventMetadata("LBLCONFIGGENPUBLICIDADESTAFILTER.CLICK","{handler:'E139T1',iparms:[{av:'divConfiggenpublicidadestafiltercontainer_Class',ctrl:'CONFIGGENPUBLICIDADESTAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCONFIGGENPUBLICIDADESTAFILTER.CLICK",",oparms:[{av:'divConfiggenpublicidadestafiltercontainer_Class',ctrl:'CONFIGGENPUBLICIDADESTAFILTERCONTAINER',prop:'Class'},{av:'cmbavCconfiggenpublicidadesta'}]}");
         setEventMetadata("ENTER","{handler:'E179T2',iparms:[{av:'A350ConfigGenPublicidadId',fld:'CONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pConfigGenPublicidadId',fld:'vPCONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenPublicidadId',fld:'vCCONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenPublicidadTit',fld:'vCCONFIGGENPUBLICIDADTIT',pic:'',type:'char'},{av:'AV8cConfigGenPublicidadFecIni',fld:'vCCONFIGGENPUBLICIDADFECINI',pic:'99/99/99 99:99',type:'dtime'},{av:'AV9cConfigGenPublicidadFecFin',fld:'vCCONFIGGENPUBLICIDADFECFIN',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCconfiggenpublicidadesta'},{av:'AV10cConfigGenPublicidadEsta',fld:'vCCONFIGGENPUBLICIDADESTA',pic:'',type:'char'},{av:'AV11pConfigGenID',fld:'vPCONFIGGENID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenPublicidadId',fld:'vCCONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenPublicidadTit',fld:'vCCONFIGGENPUBLICIDADTIT',pic:'',type:'char'},{av:'AV8cConfigGenPublicidadFecIni',fld:'vCCONFIGGENPUBLICIDADFECINI',pic:'99/99/99 99:99',type:'dtime'},{av:'AV9cConfigGenPublicidadFecFin',fld:'vCCONFIGGENPUBLICIDADFECFIN',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCconfiggenpublicidadesta'},{av:'AV10cConfigGenPublicidadEsta',fld:'vCCONFIGGENPUBLICIDADESTA',pic:'',type:'char'},{av:'AV11pConfigGenID',fld:'vPCONFIGGENID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenPublicidadId',fld:'vCCONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenPublicidadTit',fld:'vCCONFIGGENPUBLICIDADTIT',pic:'',type:'char'},{av:'AV8cConfigGenPublicidadFecIni',fld:'vCCONFIGGENPUBLICIDADFECINI',pic:'99/99/99 99:99',type:'dtime'},{av:'AV9cConfigGenPublicidadFecFin',fld:'vCCONFIGGENPUBLICIDADFECFIN',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCconfiggenpublicidadesta'},{av:'AV10cConfigGenPublicidadEsta',fld:'vCCONFIGGENPUBLICIDADESTA',pic:'',type:'char'},{av:'AV11pConfigGenID',fld:'vPCONFIGGENID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cConfigGenPublicidadId',fld:'vCCONFIGGENPUBLICIDADID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cConfigGenPublicidadTit',fld:'vCCONFIGGENPUBLICIDADTIT',pic:'',type:'char'},{av:'AV8cConfigGenPublicidadFecIni',fld:'vCCONFIGGENPUBLICIDADFECINI',pic:'99/99/99 99:99',type:'dtime'},{av:'AV9cConfigGenPublicidadFecFin',fld:'vCCONFIGGENPUBLICIDADFECFIN',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCconfiggenpublicidadesta'},{av:'AV10cConfigGenPublicidadEsta',fld:'vCCONFIGGENPUBLICIDADESTA',pic:'',type:'char'},{av:'AV11pConfigGenID',fld:'vPCONFIGGENID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCONFIGGENPUBLICIDADFECINI","{handler:'Validv_Cconfiggenpublicidadfecini',iparms:[]");
         setEventMetadata("VALIDV_CCONFIGGENPUBLICIDADFECINI",",oparms:[]}");
         setEventMetadata("VALIDV_CCONFIGGENPUBLICIDADFECFIN","{handler:'Validv_Cconfiggenpublicidadfecfin',iparms:[]");
         setEventMetadata("VALIDV_CCONFIGGENPUBLICIDADFECFIN",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Configgenid',iparms:[]");
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
         AV7cConfigGenPublicidadTit = "";
         AV8cConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         AV9cConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         AV10cConfigGenPublicidadEsta = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblconfiggenpublicidadidfilter_Jsonclick = "";
         TempTags = "";
         lblLblconfiggenpublicidadtitfilter_Jsonclick = "";
         lblLblconfiggenpublicidadfecinifilter_Jsonclick = "";
         lblLblconfiggenpublicidadfecfinfilter_Jsonclick = "";
         lblLblconfiggenpublicidadestafilter_Jsonclick = "";
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
         A359ConfigGenPublicidadTit = "";
         A361ConfigGenPublicidadIma = "";
         A40000ConfigGenPublicidadIma_GXI = "";
         A362ConfigGenPublicidadFecIni = (DateTime)(DateTime.MinValue);
         A364ConfigGenPublicidadEsta = "";
         lV7cConfigGenPublicidadTit = "";
         lV10cConfigGenPublicidadEsta = "";
         A363ConfigGenPublicidadFecFin = (DateTime)(DateTime.MinValue);
         H009T2_A363ConfigGenPublicidadFecFin = new DateTime[] {DateTime.MinValue} ;
         H009T2_A349ConfigGenID = new short[1] ;
         H009T2_A364ConfigGenPublicidadEsta = new string[] {""} ;
         H009T2_A362ConfigGenPublicidadFecIni = new DateTime[] {DateTime.MinValue} ;
         H009T2_A40000ConfigGenPublicidadIma_GXI = new string[] {""} ;
         H009T2_A359ConfigGenPublicidadTit = new string[] {""} ;
         H009T2_A350ConfigGenPublicidadId = new long[1] ;
         H009T2_A361ConfigGenPublicidadIma = new string[] {""} ;
         H009T3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01i1__default(),
            new Object[][] {
                new Object[] {
               H009T2_A363ConfigGenPublicidadFecFin, H009T2_A349ConfigGenID, H009T2_A364ConfigGenPublicidadEsta, H009T2_A362ConfigGenPublicidadFecIni, H009T2_A40000ConfigGenPublicidadIma_GXI, H009T2_A359ConfigGenPublicidadTit, H009T2_A350ConfigGenPublicidadId, H009T2_A361ConfigGenPublicidadIma
               }
               , new Object[] {
               H009T3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11pConfigGenID ;
      private short wcpOAV11pConfigGenID ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A349ConfigGenID ;
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
      private int edtavCconfiggenpublicidadid_Enabled ;
      private int edtavCconfiggenpublicidadid_Visible ;
      private int edtavCconfiggenpublicidadtit_Visible ;
      private int edtavCconfiggenpublicidadtit_Enabled ;
      private int edtavCconfiggenpublicidadfecini_Enabled ;
      private int edtavCconfiggenpublicidadfecfin_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtConfigGenPublicidadId_Enabled ;
      private int edtConfigGenPublicidadTit_Enabled ;
      private int edtConfigGenPublicidadIma_Enabled ;
      private int edtConfigGenPublicidadFecIni_Enabled ;
      private int edtConfigGenID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pConfigGenPublicidadId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cConfigGenPublicidadId ;
      private long A350ConfigGenPublicidadId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divConfiggenpublicidadidfiltercontainer_Class ;
      private string divConfiggenpublicidadtitfiltercontainer_Class ;
      private string divConfiggenpublicidadestafiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV7cConfigGenPublicidadTit ;
      private string AV10cConfigGenPublicidadEsta ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divConfiggenpublicidadidfiltercontainer_Internalname ;
      private string lblLblconfiggenpublicidadidfilter_Internalname ;
      private string lblLblconfiggenpublicidadidfilter_Jsonclick ;
      private string edtavCconfiggenpublicidadid_Internalname ;
      private string TempTags ;
      private string edtavCconfiggenpublicidadid_Jsonclick ;
      private string divConfiggenpublicidadtitfiltercontainer_Internalname ;
      private string lblLblconfiggenpublicidadtitfilter_Internalname ;
      private string lblLblconfiggenpublicidadtitfilter_Jsonclick ;
      private string edtavCconfiggenpublicidadtit_Internalname ;
      private string edtavCconfiggenpublicidadtit_Jsonclick ;
      private string divConfiggenpublicidadfecinifiltercontainer_Internalname ;
      private string lblLblconfiggenpublicidadfecinifilter_Internalname ;
      private string lblLblconfiggenpublicidadfecinifilter_Jsonclick ;
      private string edtavCconfiggenpublicidadfecini_Internalname ;
      private string edtavCconfiggenpublicidadfecini_Jsonclick ;
      private string divConfiggenpublicidadfecfinfiltercontainer_Internalname ;
      private string lblLblconfiggenpublicidadfecfinfilter_Internalname ;
      private string lblLblconfiggenpublicidadfecfinfilter_Jsonclick ;
      private string edtavCconfiggenpublicidadfecfin_Internalname ;
      private string edtavCconfiggenpublicidadfecfin_Jsonclick ;
      private string divConfiggenpublicidadestafiltercontainer_Internalname ;
      private string lblLblconfiggenpublicidadestafilter_Internalname ;
      private string lblLblconfiggenpublicidadestafilter_Jsonclick ;
      private string cmbavCconfiggenpublicidadesta_Internalname ;
      private string cmbavCconfiggenpublicidadesta_Jsonclick ;
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
      private string edtConfigGenPublicidadId_Internalname ;
      private string A359ConfigGenPublicidadTit ;
      private string edtConfigGenPublicidadTit_Internalname ;
      private string edtConfigGenPublicidadIma_Internalname ;
      private string edtConfigGenPublicidadFecIni_Internalname ;
      private string cmbConfigGenPublicidadEsta_Internalname ;
      private string A364ConfigGenPublicidadEsta ;
      private string edtConfigGenID_Internalname ;
      private string lV7cConfigGenPublicidadTit ;
      private string lV10cConfigGenPublicidadEsta ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtConfigGenPublicidadId_Jsonclick ;
      private string edtConfigGenPublicidadTit_Link ;
      private string edtConfigGenPublicidadTit_Jsonclick ;
      private string edtConfigGenPublicidadFecIni_Jsonclick ;
      private string GXCCtl ;
      private string cmbConfigGenPublicidadEsta_Jsonclick ;
      private string edtConfigGenID_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8cConfigGenPublicidadFecIni ;
      private DateTime AV9cConfigGenPublicidadFecFin ;
      private DateTime A362ConfigGenPublicidadFecIni ;
      private DateTime A363ConfigGenPublicidadFecFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A361ConfigGenPublicidadIma_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string A40000ConfigGenPublicidadIma_GXI ;
      private string AV5LinkSelection ;
      private string A361ConfigGenPublicidadIma ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCconfiggenpublicidadesta ;
      private GXCombobox cmbConfigGenPublicidadEsta ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H009T2_A363ConfigGenPublicidadFecFin ;
      private short[] H009T2_A349ConfigGenID ;
      private string[] H009T2_A364ConfigGenPublicidadEsta ;
      private DateTime[] H009T2_A362ConfigGenPublicidadFecIni ;
      private string[] H009T2_A40000ConfigGenPublicidadIma_GXI ;
      private string[] H009T2_A359ConfigGenPublicidadTit ;
      private long[] H009T2_A350ConfigGenPublicidadId ;
      private string[] H009T2_A361ConfigGenPublicidadIma ;
      private long[] H009T3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pConfigGenPublicidadId ;
   }

   public class gx01i1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009T2( IGxContext context ,
                                             string AV7cConfigGenPublicidadTit ,
                                             DateTime AV8cConfigGenPublicidadFecIni ,
                                             DateTime AV9cConfigGenPublicidadFecFin ,
                                             string AV10cConfigGenPublicidadEsta ,
                                             string A359ConfigGenPublicidadTit ,
                                             DateTime A362ConfigGenPublicidadFecIni ,
                                             DateTime A363ConfigGenPublicidadFecFin ,
                                             string A364ConfigGenPublicidadEsta ,
                                             short AV11pConfigGenID ,
                                             long AV6cConfigGenPublicidadId ,
                                             short A349ConfigGenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ConfigGenPublicidadFecFin], [ConfigGenID], [ConfigGenPublicidadEsta], [ConfigGenPublicidadFecIni], [ConfigGenPublicidadIma_GXI], [ConfigGenPublicidadTit], [ConfigGenPublicidadId], [ConfigGenPublicidadIma]";
         sFromString = " FROM [ConfigGenPublicidad]";
         sOrderString = "";
         AddWhere(sWhereString, "([ConfigGenID] = @AV11pConfigGenID and [ConfigGenPublicidadId] >= @AV6cConfigGenPublicidadId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cConfigGenPublicidadTit)) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadTit] like @lV7cConfigGenPublicidadTit)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cConfigGenPublicidadFecIni) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadFecIni] >= @AV8cConfigGenPublicidadFecIni)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cConfigGenPublicidadFecFin) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadFecFin] >= @AV9cConfigGenPublicidadFecFin)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cConfigGenPublicidadEsta)) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadEsta] like @lV10cConfigGenPublicidadEsta)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [ConfigGenID], [ConfigGenPublicidadId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009T3( IGxContext context ,
                                             string AV7cConfigGenPublicidadTit ,
                                             DateTime AV8cConfigGenPublicidadFecIni ,
                                             DateTime AV9cConfigGenPublicidadFecFin ,
                                             string AV10cConfigGenPublicidadEsta ,
                                             string A359ConfigGenPublicidadTit ,
                                             DateTime A362ConfigGenPublicidadFecIni ,
                                             DateTime A363ConfigGenPublicidadFecFin ,
                                             string A364ConfigGenPublicidadEsta ,
                                             short AV11pConfigGenID ,
                                             long AV6cConfigGenPublicidadId ,
                                             short A349ConfigGenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [ConfigGenPublicidad]";
         AddWhere(sWhereString, "([ConfigGenID] = @AV11pConfigGenID and [ConfigGenPublicidadId] >= @AV6cConfigGenPublicidadId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cConfigGenPublicidadTit)) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadTit] like @lV7cConfigGenPublicidadTit)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cConfigGenPublicidadFecIni) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadFecIni] >= @AV8cConfigGenPublicidadFecIni)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cConfigGenPublicidadFecFin) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadFecFin] >= @AV9cConfigGenPublicidadFecFin)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cConfigGenPublicidadEsta)) )
         {
            AddWhere(sWhereString, "([ConfigGenPublicidadEsta] like @lV10cConfigGenPublicidadEsta)");
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
                     return conditional_H009T2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H009T3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH009T2;
          prmH009T2 = new Object[] {
          new ParDef("@AV11pConfigGenID",GXType.Int16,4,0) ,
          new ParDef("@AV6cConfigGenPublicidadId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cConfigGenPublicidadTit",GXType.NChar,80,0) ,
          new ParDef("@AV8cConfigGenPublicidadFecIni",GXType.DateTime,8,5) ,
          new ParDef("@AV9cConfigGenPublicidadFecFin",GXType.DateTime,8,5) ,
          new ParDef("@lV10cConfigGenPublicidadEsta",GXType.NChar,3,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009T3;
          prmH009T3 = new Object[] {
          new ParDef("@AV11pConfigGenID",GXType.Int16,4,0) ,
          new ParDef("@AV6cConfigGenPublicidadId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cConfigGenPublicidadTit",GXType.NChar,80,0) ,
          new ParDef("@AV8cConfigGenPublicidadFecIni",GXType.DateTime,8,5) ,
          new ParDef("@AV9cConfigGenPublicidadFecFin",GXType.DateTime,8,5) ,
          new ParDef("@lV10cConfigGenPublicidadEsta",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009T2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009T3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

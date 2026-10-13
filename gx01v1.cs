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
   public class gx01v1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01v1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01v1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pProfComisionesID ,
                           out long aP1_pProfComisionesRubrosId )
      {
         this.AV12pProfComisionesID = aP0_pProfComisionesID;
         this.AV13pProfComisionesRubrosId = 0 ;
         ExecutePrivate();
         aP1_pProfComisionesRubrosId=this.AV13pProfComisionesRubrosId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCprofcomisionesrubrostipo = new GXCombobox();
         cmbProfComisionesRubrosTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pProfComisionesID");
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
               gxfirstwebparm = GetFirstPar( "pProfComisionesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProfComisionesID");
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
               AV12pProfComisionesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pProfComisionesID", StringUtil.LTrimStr( (decimal)(AV12pProfComisionesID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pProfComisionesRubrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "pProfComisionesRubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV13pProfComisionesRubrosId), 18, 0));
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
         AV6cProfComisionesRubrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "cProfComisionesRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV7cProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "cProveedorID"), "."), 18, MidpointRounding.ToEven));
         cmbavCprofcomisionesrubrostipo.FromJSonString( GetNextPar( ));
         AV11cProfComisionesRubrosTipo = GetPar( "cProfComisionesRubrosTipo");
         AV15cProfComisionesRubrosValor = NumberUtil.Val( GetPar( "cProfComisionesRubrosValor"), ".");
         AV9cMedidasNombre = GetPar( "cMedidasNombre");
         AV16cInventarioNombre = GetPar( "cInventarioNombre");
         AV12pProfComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "pProfComisionesID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cProfComisionesRubrosId, AV7cProveedorID, AV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, AV9cMedidasNombre, AV16cInventarioNombre, AV12pProfComisionesID) ;
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
         PAA82( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA82( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01v1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pProfComisionesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pProfComisionesRubrosId,18,0))}, new string[] {"pProfComisionesID","pProfComisionesRubrosId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFCOMISIONESRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFCOMISIONESRUBROSTIPO", StringUtil.RTrim( AV11cProfComisionesRubrosTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFCOMISIONESRUBROSVALOR", StringUtil.LTrim( StringUtil.NToC( AV15cProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMEDIDASNOMBRE", StringUtil.RTrim( AV9cMedidasNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVENTARIONOMBRE", StringUtil.RTrim( AV16cInventarioNombre));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPROFCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPROFCOMISIONESRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSIDFILTERCONTAINER_Class", StringUtil.RTrim( divProfcomisionesrubrosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROVEEDORIDFILTERCONTAINER_Class", StringUtil.RTrim( divProveedoridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divProfcomisionesrubrostipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSVALORFILTERCONTAINER_Class", StringUtil.RTrim( divProfcomisionesrubrosvalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MEDIDASNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divMedidasnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVENTARIONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divInventarionombrefiltercontainer_Class));
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
            WEA82( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA82( ) ;
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
         return formatLink("gx01v1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pProfComisionesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pProfComisionesRubrosId,18,0))}, new string[] {"pProfComisionesID","pProfComisionesRubrosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01V1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Rubros", "") ;
      }

      protected void WBA80( )
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
            GxWebStd.gx_div_start( context, divProfcomisionesrubrosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfcomisionesrubrosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofcomisionesrubrosidfilter_Internalname, context.GetMessage( "No.", ""), "", "", lblLblprofcomisionesrubrosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11a81_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofcomisionesrubrosid_Internalname, context.GetMessage( "No.", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofcomisionesrubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCprofcomisionesrubrosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofcomisionesrubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofcomisionesrubrosid_Visible, edtavCprofcomisionesrubrosid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01V1.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblproveedoridfilter_Internalname, context.GetMessage( "Comercio", ""), "", "", lblLblproveedoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12a81_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01V1.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCproveedorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCproveedorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproveedorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproveedorid_Visible, edtavCproveedorid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01V1.htm");
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
            GxWebStd.gx_div_start( context, divProfcomisionesrubrostipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfcomisionesrubrostipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofcomisionesrubrostipofilter_Internalname, context.GetMessage( "Tipo de Comisión", ""), "", "", lblLblprofcomisionesrubrostipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13a81_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCprofcomisionesrubrostipo_Internalname, context.GetMessage( "Tipo de Comisión", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCprofcomisionesrubrostipo, cmbavCprofcomisionesrubrostipo_Internalname, StringUtil.RTrim( AV11cProfComisionesRubrosTipo), 1, cmbavCprofcomisionesrubrostipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCprofcomisionesrubrostipo.Visible, cmbavCprofcomisionesrubrostipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_Gx01V1.htm");
            cmbavCprofcomisionesrubrostipo.CurrentValue = StringUtil.RTrim( AV11cProfComisionesRubrosTipo);
            AssignProp("", false, cmbavCprofcomisionesrubrostipo_Internalname, "Values", (string)(cmbavCprofcomisionesrubrostipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divProfcomisionesrubrosvalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfcomisionesrubrosvalorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofcomisionesrubrosvalorfilter_Internalname, context.GetMessage( "Valor/Costo", ""), "", "", lblLblprofcomisionesrubrosvalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14a81_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofcomisionesrubrosvalor_Internalname, context.GetMessage( "Valor/Costo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofcomisionesrubrosvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15cProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCprofcomisionesrubrosvalor_Enabled!=0) ? context.localUtil.Format( AV15cProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV15cProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprofcomisionesrubrosvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofcomisionesrubrosvalor_Visible, edtavCprofcomisionesrubrosvalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01V1.htm");
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
            GxWebStd.gx_div_start( context, divMedidasnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divMedidasnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmedidasnombrefilter_Internalname, context.GetMessage( "Nombre de la Característica", ""), "", "", lblLblmedidasnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15a81_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01V1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmedidasnombre_Internalname, StringUtil.RTrim( AV9cMedidasNombre), StringUtil.RTrim( context.localUtil.Format( AV9cMedidasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmedidasnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmedidasnombre_Visible, edtavCmedidasnombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01V1.htm");
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
            GxWebStd.gx_div_start( context, divInventarionombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInventarionombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinventarionombrefilter_Internalname, context.GetMessage( "Producto/Característica", ""), "", "", lblLblinventarionombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16a81_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinventarionombre_Internalname, context.GetMessage( "Producto/Característica", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinventarionombre_Internalname, StringUtil.RTrim( AV16cInventarioNombre), StringUtil.RTrim( context.localUtil.Format( AV16cInventarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinventarionombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinventarionombre_Visible, edtavCinventarionombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01V1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17a81_client"+"'", TempTags, "", 2, "HLP_Gx01V1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01V1.htm");
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

      protected void STARTA82( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Rubros", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA80( ) ;
      }

      protected void WSA82( )
      {
         STARTA82( ) ;
         EVTA82( ) ;
      }

      protected void EVTA82( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A452ProfComisionesRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n133ProveedorID = false;
                              cmbProfComisionesRubrosTipo.Name = cmbProfComisionesRubrosTipo_Internalname;
                              cmbProfComisionesRubrosTipo.CurrentValue = cgiGet( cmbProfComisionesRubrosTipo_Internalname);
                              A453ProfComisionesRubrosTipo = cgiGet( cmbProfComisionesRubrosTipo_Internalname);
                              A454ProfComisionesRubrosValor = context.localUtil.CToN( cgiGet( edtProfComisionesRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
                              A450ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18A82 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19A82 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cprofcomisionesrubrosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROFCOMISIONESRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cProfComisionesRubrosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproveedorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cProveedorID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofcomisionesrubrostipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFCOMISIONESRUBROSTIPO"), AV11cProfComisionesRubrosTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofcomisionesrubrosvalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPROFCOMISIONESRUBROSVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV15cProfComisionesRubrosValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmedidasnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV9cMedidasNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinventarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVENTARIONOMBRE"), AV16cInventarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20A82 ();
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

      protected void WEA82( )
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

      protected void PAA82( )
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
                                        long AV6cProfComisionesRubrosId ,
                                        long AV7cProveedorID ,
                                        string AV11cProfComisionesRubrosTipo ,
                                        decimal AV15cProfComisionesRubrosValor ,
                                        string AV9cMedidasNombre ,
                                        string AV16cInventarioNombre ,
                                        long AV12pProfComisionesID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFA82( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFCOMISIONESRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A452ProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, ".", "")));
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
         if ( cmbavCprofcomisionesrubrostipo.ItemCount > 0 )
         {
            AV11cProfComisionesRubrosTipo = cmbavCprofcomisionesrubrostipo.getValidValue(AV11cProfComisionesRubrosTipo);
            AssignAttri("", false, "AV11cProfComisionesRubrosTipo", AV11cProfComisionesRubrosTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCprofcomisionesrubrostipo.CurrentValue = StringUtil.RTrim( AV11cProfComisionesRubrosTipo);
            AssignProp("", false, cmbavCprofcomisionesrubrostipo_Internalname, "Values", cmbavCprofcomisionesrubrostipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA82( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFA82( )
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
                                                 AV11cProfComisionesRubrosTipo ,
                                                 AV15cProfComisionesRubrosValor ,
                                                 AV9cMedidasNombre ,
                                                 AV16cInventarioNombre ,
                                                 A133ProveedorID ,
                                                 A453ProfComisionesRubrosTipo ,
                                                 A454ProfComisionesRubrosValor ,
                                                 A138MedidasNombre ,
                                                 A136InventarioNombre ,
                                                 AV12pProfComisionesID ,
                                                 AV6cProfComisionesRubrosId ,
                                                 A450ProfComisionesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV11cProfComisionesRubrosTipo = StringUtil.PadR( StringUtil.RTrim( AV11cProfComisionesRubrosTipo), 1, "%");
            lV9cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV9cMedidasNombre), 50, "%");
            lV16cInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV16cInventarioNombre), 100, "%");
            /* Using cursor H00A82 */
            pr_default.execute(0, new Object[] {AV12pProfComisionesID, AV6cProfComisionesRubrosId, AV7cProveedorID, lV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, lV9cMedidasNombre, lV16cInventarioNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A121RubrosId = H00A82_A121RubrosId[0];
               A137MedidasID = H00A82_A137MedidasID[0];
               A135InventarioId = H00A82_A135InventarioId[0];
               A136InventarioNombre = H00A82_A136InventarioNombre[0];
               A450ProfComisionesID = H00A82_A450ProfComisionesID[0];
               A138MedidasNombre = H00A82_A138MedidasNombre[0];
               A454ProfComisionesRubrosValor = H00A82_A454ProfComisionesRubrosValor[0];
               A453ProfComisionesRubrosTipo = H00A82_A453ProfComisionesRubrosTipo[0];
               A133ProveedorID = H00A82_A133ProveedorID[0];
               n133ProveedorID = H00A82_n133ProveedorID[0];
               A452ProfComisionesRubrosId = H00A82_A452ProfComisionesRubrosId[0];
               A138MedidasNombre = H00A82_A138MedidasNombre[0];
               A136InventarioNombre = H00A82_A136InventarioNombre[0];
               /* Execute user event: Load */
               E19A82 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBA80( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA82( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFCOMISIONESRUBROSID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A452ProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV11cProfComisionesRubrosTipo ,
                                              AV15cProfComisionesRubrosValor ,
                                              AV9cMedidasNombre ,
                                              AV16cInventarioNombre ,
                                              A133ProveedorID ,
                                              A453ProfComisionesRubrosTipo ,
                                              A454ProfComisionesRubrosValor ,
                                              A138MedidasNombre ,
                                              A136InventarioNombre ,
                                              AV12pProfComisionesID ,
                                              AV6cProfComisionesRubrosId ,
                                              A450ProfComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11cProfComisionesRubrosTipo = StringUtil.PadR( StringUtil.RTrim( AV11cProfComisionesRubrosTipo), 1, "%");
         lV9cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV9cMedidasNombre), 50, "%");
         lV16cInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV16cInventarioNombre), 100, "%");
         /* Using cursor H00A83 */
         pr_default.execute(1, new Object[] {AV12pProfComisionesID, AV6cProfComisionesRubrosId, AV7cProveedorID, lV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, lV9cMedidasNombre, lV16cInventarioNombre});
         GRID1_nRecordCount = H00A83_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfComisionesRubrosId, AV7cProveedorID, AV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, AV9cMedidasNombre, AV16cInventarioNombre, AV12pProfComisionesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfComisionesRubrosId, AV7cProveedorID, AV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, AV9cMedidasNombre, AV16cInventarioNombre, AV12pProfComisionesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfComisionesRubrosId, AV7cProveedorID, AV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, AV9cMedidasNombre, AV16cInventarioNombre, AV12pProfComisionesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfComisionesRubrosId, AV7cProveedorID, AV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, AV9cMedidasNombre, AV16cInventarioNombre, AV12pProfComisionesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfComisionesRubrosId, AV7cProveedorID, AV11cProfComisionesRubrosTipo, AV15cProfComisionesRubrosValor, AV9cMedidasNombre, AV16cInventarioNombre, AV12pProfComisionesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtProfComisionesRubrosId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         cmbProfComisionesRubrosTipo.Enabled = 0;
         edtProfComisionesRubrosValor_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtProfComisionesID_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA80( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18A82 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprofcomisionesrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprofcomisionesrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROFCOMISIONESRUBROSID");
               GX_FocusControl = edtavCprofcomisionesrubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cProfComisionesRubrosId = 0;
               AssignAttri("", false, "AV6cProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV6cProfComisionesRubrosId), 18, 0));
            }
            else
            {
               AV6cProfComisionesRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCprofcomisionesrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV6cProfComisionesRubrosId), 18, 0));
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
            cmbavCprofcomisionesrubrostipo.Name = cmbavCprofcomisionesrubrostipo_Internalname;
            cmbavCprofcomisionesrubrostipo.CurrentValue = cgiGet( cmbavCprofcomisionesrubrostipo_Internalname);
            AV11cProfComisionesRubrosTipo = cgiGet( cmbavCprofcomisionesrubrostipo_Internalname);
            AssignAttri("", false, "AV11cProfComisionesRubrosTipo", AV11cProfComisionesRubrosTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprofcomisionesrubrosvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprofcomisionesrubrosvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROFCOMISIONESRUBROSVALOR");
               GX_FocusControl = edtavCprofcomisionesrubrosvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cProfComisionesRubrosValor = 0;
               AssignAttri("", false, "AV15cProfComisionesRubrosValor", StringUtil.LTrimStr( AV15cProfComisionesRubrosValor, 18, 2));
            }
            else
            {
               AV15cProfComisionesRubrosValor = context.localUtil.CToN( cgiGet( edtavCprofcomisionesrubrosvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV15cProfComisionesRubrosValor", StringUtil.LTrimStr( AV15cProfComisionesRubrosValor, 18, 2));
            }
            AV9cMedidasNombre = cgiGet( edtavCmedidasnombre_Internalname);
            AssignAttri("", false, "AV9cMedidasNombre", AV9cMedidasNombre);
            AV16cInventarioNombre = cgiGet( edtavCinventarionombre_Internalname);
            AssignAttri("", false, "AV16cInventarioNombre", AV16cInventarioNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROFCOMISIONESRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cProfComisionesRubrosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cProveedorID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFCOMISIONESRUBROSTIPO"), AV11cProfComisionesRubrosTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPROFCOMISIONESRUBROSVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV15cProfComisionesRubrosValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV9cMedidasNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVENTARIONOMBRE"), AV16cInventarioNombre) != 0 )
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
         E18A82 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18A82( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19A82( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E20A82 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20A82( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pProfComisionesRubrosId = A452ProfComisionesRubrosId;
         AssignAttri("", false, "AV13pProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV13pProfComisionesRubrosId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pProfComisionesRubrosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pProfComisionesRubrosId"});
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
         AV12pProfComisionesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pProfComisionesID", StringUtil.LTrimStr( (decimal)(AV12pProfComisionesID), 18, 0));
         AV13pProfComisionesRubrosId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pProfComisionesRubrosId", StringUtil.LTrimStr( (decimal)(AV13pProfComisionesRubrosId), 18, 0));
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
         PAA82( ) ;
         WSA82( ) ;
         WEA82( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269321392285", true, true, false);
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
         context.AddJavascriptSource("gx01v1.js", "?20269321392285", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtProfComisionesRubrosId_Internalname = "PROFCOMISIONESRUBROSID_"+sGXsfl_74_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_74_idx;
         cmbProfComisionesRubrosTipo_Internalname = "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_74_idx;
         edtProfComisionesRubrosValor_Internalname = "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_74_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_74_idx;
         edtProfComisionesID_Internalname = "PROFCOMISIONESID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtProfComisionesRubrosId_Internalname = "PROFCOMISIONESRUBROSID_"+sGXsfl_74_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_74_fel_idx;
         cmbProfComisionesRubrosTipo_Internalname = "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_74_fel_idx;
         edtProfComisionesRubrosValor_Internalname = "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_74_fel_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_74_fel_idx;
         edtProfComisionesID_Internalname = "PROFCOMISIONESID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBA80( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A452ProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProfComisionesRubrosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROFCOMISIONESRUBROSTIPO_" + sGXsfl_74_idx;
               cmbProfComisionesRubrosTipo.Name = GXCCtl;
               cmbProfComisionesRubrosTipo.WebTags = "";
               cmbProfComisionesRubrosTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
               cmbProfComisionesRubrosTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
               if ( cmbProfComisionesRubrosTipo.ItemCount > 0 )
               {
                  A453ProfComisionesRubrosTipo = cmbProfComisionesRubrosTipo.getValidValue(A453ProfComisionesRubrosTipo);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfComisionesRubrosTipo,(string)cmbProfComisionesRubrosTipo_Internalname,StringUtil.RTrim( A453ProfComisionesRubrosTipo),(short)1,(string)cmbProfComisionesRubrosTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"DescriptionAttribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProfComisionesRubrosTipo.CurrentValue = StringUtil.RTrim( A453ProfComisionesRubrosTipo);
            AssignProp("", false, cmbProfComisionesRubrosTipo_Internalname, "Values", (string)(cmbProfComisionesRubrosTipo.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A454ProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA82( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCprofcomisionesrubrostipo.Name = "vCPROFCOMISIONESRUBROSTIPO";
         cmbavCprofcomisionesrubrostipo.WebTags = "";
         cmbavCprofcomisionesrubrostipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbavCprofcomisionesrubrostipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         if ( cmbavCprofcomisionesrubrostipo.ItemCount > 0 )
         {
            AV11cProfComisionesRubrosTipo = cmbavCprofcomisionesrubrostipo.getValidValue(AV11cProfComisionesRubrosTipo);
            AssignAttri("", false, "AV11cProfComisionesRubrosTipo", AV11cProfComisionesRubrosTipo);
         }
         GXCCtl = "PROFCOMISIONESRUBROSTIPO_" + sGXsfl_74_idx;
         cmbProfComisionesRubrosTipo.Name = GXCCtl;
         cmbProfComisionesRubrosTipo.WebTags = "";
         cmbProfComisionesRubrosTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbProfComisionesRubrosTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         if ( cmbProfComisionesRubrosTipo.ItemCount > 0 )
         {
            A453ProfComisionesRubrosTipo = cmbProfComisionesRubrosTipo.getValidValue(A453ProfComisionesRubrosTipo);
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
            context.SendWebValue( context.GetMessage( "No.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Comisión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Valor/Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Prof Comisiones ID", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A453ProfComisionesRubrosTipo)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbProfComisionesRubrosTipo.Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, ".", ""))));
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
         lblLblprofcomisionesrubrosidfilter_Internalname = "LBLPROFCOMISIONESRUBROSIDFILTER";
         edtavCprofcomisionesrubrosid_Internalname = "vCPROFCOMISIONESRUBROSID";
         divProfcomisionesrubrosidfiltercontainer_Internalname = "PROFCOMISIONESRUBROSIDFILTERCONTAINER";
         lblLblproveedoridfilter_Internalname = "LBLPROVEEDORIDFILTER";
         edtavCproveedorid_Internalname = "vCPROVEEDORID";
         divProveedoridfiltercontainer_Internalname = "PROVEEDORIDFILTERCONTAINER";
         lblLblprofcomisionesrubrostipofilter_Internalname = "LBLPROFCOMISIONESRUBROSTIPOFILTER";
         cmbavCprofcomisionesrubrostipo_Internalname = "vCPROFCOMISIONESRUBROSTIPO";
         divProfcomisionesrubrostipofiltercontainer_Internalname = "PROFCOMISIONESRUBROSTIPOFILTERCONTAINER";
         lblLblprofcomisionesrubrosvalorfilter_Internalname = "LBLPROFCOMISIONESRUBROSVALORFILTER";
         edtavCprofcomisionesrubrosvalor_Internalname = "vCPROFCOMISIONESRUBROSVALOR";
         divProfcomisionesrubrosvalorfiltercontainer_Internalname = "PROFCOMISIONESRUBROSVALORFILTERCONTAINER";
         lblLblmedidasnombrefilter_Internalname = "LBLMEDIDASNOMBREFILTER";
         edtavCmedidasnombre_Internalname = "vCMEDIDASNOMBRE";
         divMedidasnombrefiltercontainer_Internalname = "MEDIDASNOMBREFILTERCONTAINER";
         lblLblinventarionombrefilter_Internalname = "LBLINVENTARIONOMBREFILTER";
         edtavCinventarionombre_Internalname = "vCINVENTARIONOMBRE";
         divInventarionombrefiltercontainer_Internalname = "INVENTARIONOMBREFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtProfComisionesRubrosId_Internalname = "PROFCOMISIONESRUBROSID";
         edtProveedorID_Internalname = "PROVEEDORID";
         cmbProfComisionesRubrosTipo_Internalname = "PROFCOMISIONESRUBROSTIPO";
         edtProfComisionesRubrosValor_Internalname = "PROFCOMISIONESRUBROSVALOR";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         edtProfComisionesID_Internalname = "PROFCOMISIONESID";
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
         cmbProfComisionesRubrosTipo.Link = "";
         subGrid1_Header = "";
         edtProfComisionesID_Jsonclick = "";
         edtMedidasNombre_Jsonclick = "";
         edtProfComisionesRubrosValor_Jsonclick = "";
         cmbProfComisionesRubrosTipo_Jsonclick = "";
         edtProveedorID_Jsonclick = "";
         edtProfComisionesRubrosId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtProfComisionesID_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtProfComisionesRubrosValor_Enabled = 0;
         cmbProfComisionesRubrosTipo.Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProfComisionesRubrosId_Enabled = 0;
         edtavCinventarionombre_Jsonclick = "";
         edtavCinventarionombre_Enabled = 1;
         edtavCinventarionombre_Visible = 1;
         edtavCmedidasnombre_Jsonclick = "";
         edtavCmedidasnombre_Enabled = 1;
         edtavCmedidasnombre_Visible = 1;
         edtavCprofcomisionesrubrosvalor_Jsonclick = "";
         edtavCprofcomisionesrubrosvalor_Enabled = 1;
         edtavCprofcomisionesrubrosvalor_Visible = 1;
         cmbavCprofcomisionesrubrostipo_Jsonclick = "";
         cmbavCprofcomisionesrubrostipo.Visible = 1;
         cmbavCprofcomisionesrubrostipo.Enabled = 1;
         edtavCproveedorid_Jsonclick = "";
         edtavCproveedorid_Enabled = 1;
         edtavCproveedorid_Visible = 1;
         edtavCprofcomisionesrubrosid_Jsonclick = "";
         edtavCprofcomisionesrubrosid_Enabled = 1;
         edtavCprofcomisionesrubrosid_Visible = 1;
         divInventarionombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMedidasnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfcomisionesrubrosvalorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfcomisionesrubrostipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProveedoridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfcomisionesrubrosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Rubros", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfComisionesRubrosId',fld:'vCPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCprofcomisionesrubrostipo'},{av:'AV11cProfComisionesRubrosTipo',fld:'vCPROFCOMISIONESRUBROSTIPO',pic:'',type:'char'},{av:'AV15cProfComisionesRubrosValor',fld:'vCPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV16cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProfComisionesID',fld:'vPPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17A81',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPROFCOMISIONESRUBROSIDFILTER.CLICK","{handler:'E11A81',iparms:[{av:'divProfcomisionesrubrosidfiltercontainer_Class',ctrl:'PROFCOMISIONESRUBROSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFCOMISIONESRUBROSIDFILTER.CLICK",",oparms:[{av:'divProfcomisionesrubrosidfiltercontainer_Class',ctrl:'PROFCOMISIONESRUBROSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCprofcomisionesrubrosid_Visible',ctrl:'vCPROFCOMISIONESRUBROSID',prop:'Visible'}]}");
         setEventMetadata("LBLPROVEEDORIDFILTER.CLICK","{handler:'E12A81',iparms:[{av:'divProveedoridfiltercontainer_Class',ctrl:'PROVEEDORIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROVEEDORIDFILTER.CLICK",",oparms:[{av:'divProveedoridfiltercontainer_Class',ctrl:'PROVEEDORIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproveedorid_Visible',ctrl:'vCPROVEEDORID',prop:'Visible'}]}");
         setEventMetadata("LBLPROFCOMISIONESRUBROSTIPOFILTER.CLICK","{handler:'E13A81',iparms:[{av:'divProfcomisionesrubrostipofiltercontainer_Class',ctrl:'PROFCOMISIONESRUBROSTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFCOMISIONESRUBROSTIPOFILTER.CLICK",",oparms:[{av:'divProfcomisionesrubrostipofiltercontainer_Class',ctrl:'PROFCOMISIONESRUBROSTIPOFILTERCONTAINER',prop:'Class'},{av:'cmbavCprofcomisionesrubrostipo'}]}");
         setEventMetadata("LBLPROFCOMISIONESRUBROSVALORFILTER.CLICK","{handler:'E14A81',iparms:[{av:'divProfcomisionesrubrosvalorfiltercontainer_Class',ctrl:'PROFCOMISIONESRUBROSVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFCOMISIONESRUBROSVALORFILTER.CLICK",",oparms:[{av:'divProfcomisionesrubrosvalorfiltercontainer_Class',ctrl:'PROFCOMISIONESRUBROSVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCprofcomisionesrubrosvalor_Visible',ctrl:'vCPROFCOMISIONESRUBROSVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK","{handler:'E15A81',iparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK",",oparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCmedidasnombre_Visible',ctrl:'vCMEDIDASNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLINVENTARIONOMBREFILTER.CLICK","{handler:'E16A81',iparms:[{av:'divInventarionombrefiltercontainer_Class',ctrl:'INVENTARIONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVENTARIONOMBREFILTER.CLICK",",oparms:[{av:'divInventarionombrefiltercontainer_Class',ctrl:'INVENTARIONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCinventarionombre_Visible',ctrl:'vCINVENTARIONOMBRE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20A82',iparms:[{av:'A452ProfComisionesRubrosId',fld:'PROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pProfComisionesRubrosId',fld:'vPPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfComisionesRubrosId',fld:'vCPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCprofcomisionesrubrostipo'},{av:'AV11cProfComisionesRubrosTipo',fld:'vCPROFCOMISIONESRUBROSTIPO',pic:'',type:'char'},{av:'AV15cProfComisionesRubrosValor',fld:'vCPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV16cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProfComisionesID',fld:'vPPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfComisionesRubrosId',fld:'vCPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCprofcomisionesrubrostipo'},{av:'AV11cProfComisionesRubrosTipo',fld:'vCPROFCOMISIONESRUBROSTIPO',pic:'',type:'char'},{av:'AV15cProfComisionesRubrosValor',fld:'vCPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV16cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProfComisionesID',fld:'vPPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfComisionesRubrosId',fld:'vCPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCprofcomisionesrubrostipo'},{av:'AV11cProfComisionesRubrosTipo',fld:'vCPROFCOMISIONESRUBROSTIPO',pic:'',type:'char'},{av:'AV15cProfComisionesRubrosValor',fld:'vCPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV16cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProfComisionesID',fld:'vPPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfComisionesRubrosId',fld:'vCPROFCOMISIONESRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cProveedorID',fld:'vCPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavCprofcomisionesrubrostipo'},{av:'AV11cProfComisionesRubrosTipo',fld:'vCPROFCOMISIONESRUBROSTIPO',pic:'',type:'char'},{av:'AV15cProfComisionesRubrosValor',fld:'vCPROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV16cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProfComisionesID',fld:'vPPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Profcomisionesid',iparms:[]");
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
         AV11cProfComisionesRubrosTipo = "";
         AV9cMedidasNombre = "";
         AV16cInventarioNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblprofcomisionesrubrosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblproveedoridfilter_Jsonclick = "";
         lblLblprofcomisionesrubrostipofilter_Jsonclick = "";
         lblLblprofcomisionesrubrosvalorfilter_Jsonclick = "";
         lblLblmedidasnombrefilter_Jsonclick = "";
         lblLblinventarionombrefilter_Jsonclick = "";
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
         AV17Linkselection_GXI = "";
         A453ProfComisionesRubrosTipo = "";
         A138MedidasNombre = "";
         lV11cProfComisionesRubrosTipo = "";
         lV9cMedidasNombre = "";
         lV16cInventarioNombre = "";
         A136InventarioNombre = "";
         H00A82_A121RubrosId = new short[1] ;
         H00A82_A137MedidasID = new long[1] ;
         H00A82_A135InventarioId = new long[1] ;
         H00A82_A136InventarioNombre = new string[] {""} ;
         H00A82_A450ProfComisionesID = new long[1] ;
         H00A82_A138MedidasNombre = new string[] {""} ;
         H00A82_A454ProfComisionesRubrosValor = new decimal[1] ;
         H00A82_A453ProfComisionesRubrosTipo = new string[] {""} ;
         H00A82_A133ProveedorID = new long[1] ;
         H00A82_n133ProveedorID = new bool[] {false} ;
         H00A82_A452ProfComisionesRubrosId = new long[1] ;
         H00A83_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01v1__default(),
            new Object[][] {
                new Object[] {
               H00A82_A121RubrosId, H00A82_A137MedidasID, H00A82_A135InventarioId, H00A82_A136InventarioNombre, H00A82_A450ProfComisionesID, H00A82_A138MedidasNombre, H00A82_A454ProfComisionesRubrosValor, H00A82_A453ProfComisionesRubrosTipo, H00A82_A133ProveedorID, H00A82_n133ProveedorID,
               H00A82_A452ProfComisionesRubrosId
               }
               , new Object[] {
               H00A83_AGRID1_nRecordCount
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
      private short A121RubrosId ;
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
      private int edtavCprofcomisionesrubrosid_Enabled ;
      private int edtavCprofcomisionesrubrosid_Visible ;
      private int edtavCproveedorid_Enabled ;
      private int edtavCproveedorid_Visible ;
      private int edtavCprofcomisionesrubrosvalor_Enabled ;
      private int edtavCprofcomisionesrubrosvalor_Visible ;
      private int edtavCmedidasnombre_Visible ;
      private int edtavCmedidasnombre_Enabled ;
      private int edtavCinventarionombre_Visible ;
      private int edtavCinventarionombre_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProfComisionesRubrosId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProfComisionesRubrosValor_Enabled ;
      private int edtMedidasNombre_Enabled ;
      private int edtProfComisionesID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pProfComisionesID ;
      private long AV13pProfComisionesRubrosId ;
      private long wcpOAV12pProfComisionesID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cProfComisionesRubrosId ;
      private long AV7cProveedorID ;
      private long A452ProfComisionesRubrosId ;
      private long A133ProveedorID ;
      private long A450ProfComisionesID ;
      private long GRID1_nCurrentRecord ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID1_nRecordCount ;
      private decimal AV15cProfComisionesRubrosValor ;
      private decimal A454ProfComisionesRubrosValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProfcomisionesrubrosidfiltercontainer_Class ;
      private string divProveedoridfiltercontainer_Class ;
      private string divProfcomisionesrubrostipofiltercontainer_Class ;
      private string divProfcomisionesrubrosvalorfiltercontainer_Class ;
      private string divMedidasnombrefiltercontainer_Class ;
      private string divInventarionombrefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV11cProfComisionesRubrosTipo ;
      private string AV9cMedidasNombre ;
      private string AV16cInventarioNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProfcomisionesrubrosidfiltercontainer_Internalname ;
      private string lblLblprofcomisionesrubrosidfilter_Internalname ;
      private string lblLblprofcomisionesrubrosidfilter_Jsonclick ;
      private string edtavCprofcomisionesrubrosid_Internalname ;
      private string TempTags ;
      private string edtavCprofcomisionesrubrosid_Jsonclick ;
      private string divProveedoridfiltercontainer_Internalname ;
      private string lblLblproveedoridfilter_Internalname ;
      private string lblLblproveedoridfilter_Jsonclick ;
      private string edtavCproveedorid_Internalname ;
      private string edtavCproveedorid_Jsonclick ;
      private string divProfcomisionesrubrostipofiltercontainer_Internalname ;
      private string lblLblprofcomisionesrubrostipofilter_Internalname ;
      private string lblLblprofcomisionesrubrostipofilter_Jsonclick ;
      private string cmbavCprofcomisionesrubrostipo_Internalname ;
      private string cmbavCprofcomisionesrubrostipo_Jsonclick ;
      private string divProfcomisionesrubrosvalorfiltercontainer_Internalname ;
      private string lblLblprofcomisionesrubrosvalorfilter_Internalname ;
      private string lblLblprofcomisionesrubrosvalorfilter_Jsonclick ;
      private string edtavCprofcomisionesrubrosvalor_Internalname ;
      private string edtavCprofcomisionesrubrosvalor_Jsonclick ;
      private string divMedidasnombrefiltercontainer_Internalname ;
      private string lblLblmedidasnombrefilter_Internalname ;
      private string lblLblmedidasnombrefilter_Jsonclick ;
      private string edtavCmedidasnombre_Internalname ;
      private string edtavCmedidasnombre_Jsonclick ;
      private string divInventarionombrefiltercontainer_Internalname ;
      private string lblLblinventarionombrefilter_Internalname ;
      private string lblLblinventarionombrefilter_Jsonclick ;
      private string edtavCinventarionombre_Internalname ;
      private string edtavCinventarionombre_Jsonclick ;
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
      private string edtProfComisionesRubrosId_Internalname ;
      private string edtProveedorID_Internalname ;
      private string cmbProfComisionesRubrosTipo_Internalname ;
      private string A453ProfComisionesRubrosTipo ;
      private string edtProfComisionesRubrosValor_Internalname ;
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Internalname ;
      private string edtProfComisionesID_Internalname ;
      private string lV11cProfComisionesRubrosTipo ;
      private string lV9cMedidasNombre ;
      private string lV16cInventarioNombre ;
      private string A136InventarioNombre ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtProfComisionesRubrosId_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string GXCCtl ;
      private string cmbProfComisionesRubrosTipo_Jsonclick ;
      private string edtProfComisionesRubrosValor_Jsonclick ;
      private string edtMedidasNombre_Jsonclick ;
      private string edtProfComisionesID_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n133ProveedorID ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCprofcomisionesrubrostipo ;
      private GXCombobox cmbProfComisionesRubrosTipo ;
      private IDataStoreProvider pr_default ;
      private short[] H00A82_A121RubrosId ;
      private long[] H00A82_A137MedidasID ;
      private long[] H00A82_A135InventarioId ;
      private string[] H00A82_A136InventarioNombre ;
      private long[] H00A82_A450ProfComisionesID ;
      private string[] H00A82_A138MedidasNombre ;
      private decimal[] H00A82_A454ProfComisionesRubrosValor ;
      private string[] H00A82_A453ProfComisionesRubrosTipo ;
      private long[] H00A82_A133ProveedorID ;
      private bool[] H00A82_n133ProveedorID ;
      private long[] H00A82_A452ProfComisionesRubrosId ;
      private long[] H00A83_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pProfComisionesRubrosId ;
   }

   public class gx01v1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A82( IGxContext context ,
                                             long AV7cProveedorID ,
                                             string AV11cProfComisionesRubrosTipo ,
                                             decimal AV15cProfComisionesRubrosValor ,
                                             string AV9cMedidasNombre ,
                                             string AV16cInventarioNombre ,
                                             long A133ProveedorID ,
                                             string A453ProfComisionesRubrosTipo ,
                                             decimal A454ProfComisionesRubrosValor ,
                                             string A138MedidasNombre ,
                                             string A136InventarioNombre ,
                                             long AV12pProfComisionesID ,
                                             long AV6cProfComisionesRubrosId ,
                                             long A450ProfComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T3.[InventarioNombre], T1.[ProfComisionesID], T2.[MedidasNombre], T1.[ProfComisionesRubrosValor], T1.[ProfComisionesRubrosTipo], T1.[ProveedorID], T1.[ProfComisionesRubrosId]";
         sFromString = " FROM (([ProfComisionesRubros] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ProfComisionesID] = @AV12pProfComisionesID and T1.[ProfComisionesRubrosId] >= @AV6cProfComisionesRubrosId)");
         if ( ! (0==AV7cProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV7cProveedorID)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cProfComisionesRubrosTipo)) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosTipo] like @lV11cProfComisionesRubrosTipo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cProfComisionesRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] >= @AV15cProfComisionesRubrosValor)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T2.[MedidasNombre] like @lV9cMedidasNombre)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16cInventarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[InventarioNombre] like @lV16cInventarioNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00A83( IGxContext context ,
                                             long AV7cProveedorID ,
                                             string AV11cProfComisionesRubrosTipo ,
                                             decimal AV15cProfComisionesRubrosValor ,
                                             string AV9cMedidasNombre ,
                                             string AV16cInventarioNombre ,
                                             long A133ProveedorID ,
                                             string A453ProfComisionesRubrosTipo ,
                                             decimal A454ProfComisionesRubrosValor ,
                                             string A138MedidasNombre ,
                                             string A136InventarioNombre ,
                                             long AV12pProfComisionesID ,
                                             long AV6cProfComisionesRubrosId ,
                                             long A450ProfComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([ProfComisionesRubros] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T1.[ProfComisionesID] = @AV12pProfComisionesID and T1.[ProfComisionesRubrosId] >= @AV6cProfComisionesRubrosId)");
         if ( ! (0==AV7cProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV7cProveedorID)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cProfComisionesRubrosTipo)) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosTipo] like @lV11cProfComisionesRubrosTipo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cProfComisionesRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] >= @AV15cProfComisionesRubrosValor)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T2.[MedidasNombre] like @lV9cMedidasNombre)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16cInventarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[InventarioNombre] like @lV16cInventarioNombre)");
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
                     return conditional_H00A82(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00A83(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00A82;
          prmH00A82 = new Object[] {
          new ParDef("@AV12pProfComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cProfComisionesRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@lV11cProfComisionesRubrosTipo",GXType.NChar,1,0) ,
          new ParDef("@AV15cProfComisionesRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@lV9cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@lV16cInventarioNombre",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A83;
          prmH00A83 = new Object[] {
          new ParDef("@AV12pProfComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cProfComisionesRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV7cProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@lV11cProfComisionesRubrosTipo",GXType.NChar,1,0) ,
          new ParDef("@AV15cProfComisionesRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@lV9cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@lV16cInventarioNombre",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A82,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A83", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A83,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 1);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

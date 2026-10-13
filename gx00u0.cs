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
   public class gx00u0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00u0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00u0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pSolicitudesID )
      {
         this.AV13pSolicitudesID = 0 ;
         ExecutePrivate();
         aP0_pSolicitudesID=this.AV13pSolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbSolicitudesSubTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pSolicitudesID");
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
               gxfirstwebparm = GetFirstPar( "pSolicitudesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSolicitudesID");
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
               AV13pSolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesID), 18, 0));
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
         AV6cSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "cSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         AV8cSolicitudesTelefono = GetPar( "cSolicitudesTelefono");
         AV10cDepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV11cDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
         AV12cZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "cZonasID"), "."), 18, MidpointRounding.ToEven));
         AV15cSolicitudesAutoEnumerar = (short)(Math.Round(NumberUtil.Val( GetPar( "cSolicitudesAutoEnumerar"), "."), 18, MidpointRounding.ToEven));
         AV16cSolicitudesCotizacion = NumberUtil.Val( GetPar( "cSolicitudesCotizacion"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion) ;
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
         PADY2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTDY2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00u0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSolicitudesID,18,0))}, new string[] {"pSolicitudesID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESTELEFONO", StringUtil.RTrim( AV8cSolicitudesTelefono));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCZONASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESAUTOENUMERAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cSolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESCOTIZACION", StringUtil.LTrim( StringUtil.NToC( AV16cSolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESIDFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESTELEFONOFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudestelefonofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentomunicipioidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ZONASIDFILTERCONTAINER_Class", StringUtil.RTrim( divZonasidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESAUTOENUMERARFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudesautoenumerarfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOTIZACIONFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudescotizacionfiltercontainer_Class));
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
            WEDY2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTDY2( ) ;
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
         return formatLink("gx00u0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSolicitudesID,18,0))}, new string[] {"pSolicitudesID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00U0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Registro de Solicitudes", "") ;
      }

      protected void WBDY0( )
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
            GxWebStd.gx_div_start( context, divSolicitudesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesidfilter_Internalname, context.GetMessage( "Solicitudes Id", ""), "", "", lblLblsolicitudesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesid_Internalname, context.GetMessage( "Solicitudes Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudesid_Visible, edtavCsolicitudesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudestelefonofiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudestelefonofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudestelefonofilter_Internalname, context.GetMessage( "ClienteTeléfono", ""), "", "", lblLblsolicitudestelefonofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudestelefono_Internalname, context.GetMessage( "ClienteTeléfono", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudestelefono_Internalname, StringUtil.RTrim( AV8cSolicitudesTelefono), StringUtil.RTrim( context.localUtil.Format( AV8cSolicitudesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "598 099 999999", edtavCsolicitudestelefono_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudestelefono_Visible, edtavCsolicitudestelefono_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoidfilter_Internalname, context.GetMessage( "Departamento", ""), "", "", lblLbldepartamentoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoid_Visible, edtavCdepartamentoid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentomunicipioidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLbldepartamentomunicipioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentomunicipioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentomunicipioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cDepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cDepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentomunicipioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentomunicipioid_Visible, edtavCdepartamentomunicipioid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divZonasidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divZonasidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblzonasidfilter_Internalname, context.GetMessage( "Zona", ""), "", "", lblLblzonasidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCzonasid_Internalname, context.GetMessage( "Código de la Zona", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCzonasid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCzonasid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cZonasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV12cZonasID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Seleccione su Zona", ""), edtavCzonasid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCzonasid_Visible, edtavCzonasid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudesautoenumerarfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudesautoenumerarfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesautoenumerarfilter_Internalname, context.GetMessage( "MudanzaAutoEnumerar", ""), "", "", lblLblsolicitudesautoenumerarfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesautoenumerar_Internalname, context.GetMessage( "MudanzaAutoEnumerar", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesautoenumerar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cSolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudesautoenumerar_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15cSolicitudesAutoEnumerar), "ZZZ9") : context.localUtil.Format( (decimal)(AV15cSolicitudesAutoEnumerar), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesautoenumerar_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudesautoenumerar_Visible, edtavCsolicitudesautoenumerar_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudescotizacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudescotizacionfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudescotizacionfilter_Internalname, context.GetMessage( "Cotización:", ""), "", "", lblLblsolicitudescotizacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17dy1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudescotizacion_Internalname, context.GetMessage( "Cotización:", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudescotizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16cSolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudescotizacion_Enabled!=0) ? context.localUtil.Format( AV16cSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV16cSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudescotizacion_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudescotizacion_Visible, edtavCsolicitudescotizacion_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18dy1_client"+"'", TempTags, "", 2, "HLP_Gx00U0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00U0.htm");
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

      protected void STARTDY2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Registro de Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPDY0( ) ;
      }

      protected void WSDY2( )
      {
         STARTDY2( ) ;
         EVTDY2( ) ;
      }

      protected void EVTDY2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n112DepartamentoId = false;
                              cmbSolicitudesSubTipo.Name = cmbSolicitudesSubTipo_Internalname;
                              cmbSolicitudesSubTipo.CurrentValue = cgiGet( cmbSolicitudesSubTipo_Internalname);
                              A600SolicitudesSubTipo = cgiGet( cmbSolicitudesSubTipo_Internalname);
                              n600SolicitudesSubTipo = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19DY2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20DY2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csolicitudesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSolicitudesID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudestelefono Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSOLICITUDESTELEFONO"), AV8cSolicitudesTelefono) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cDepartamentoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentomunicipioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cDepartamentoMunicipioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Czonasid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCZONASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cZonasID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudesautoenumerar Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESAUTOENUMERAR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15cSolicitudesAutoEnumerar )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudescotizacion Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESCOTIZACION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV16cSolicitudesCotizacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21DY2 ();
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

      protected void WEDY2( )
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

      protected void PADY2( )
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
                                        long AV6cSolicitudesID ,
                                        string AV8cSolicitudesTelefono ,
                                        long AV10cDepartamentoId ,
                                        long AV11cDepartamentoMunicipioId ,
                                        long AV12cZonasID ,
                                        short AV15cSolicitudesAutoEnumerar ,
                                        decimal AV16cSolicitudesCotizacion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFDY2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", "")));
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
         RFDY2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFDY2( )
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
                                                 AV8cSolicitudesTelefono ,
                                                 AV10cDepartamentoId ,
                                                 AV11cDepartamentoMunicipioId ,
                                                 AV12cZonasID ,
                                                 AV15cSolicitudesAutoEnumerar ,
                                                 AV16cSolicitudesCotizacion ,
                                                 A172SolicitudesTelefono ,
                                                 A112DepartamentoId ,
                                                 A114DepartamentoMunicipioId ,
                                                 A110ZonasID ,
                                                 A194SolicitudesAutoEnumerar ,
                                                 A212SolicitudesCotizacion ,
                                                 AV6cSolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG
                                                 }
            });
            lV8cSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV8cSolicitudesTelefono), 20, "%");
            /* Using cursor H00DY2 */
            pr_default.execute(0, new Object[] {AV6cSolicitudesID, lV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A212SolicitudesCotizacion = H00DY2_A212SolicitudesCotizacion[0];
               A194SolicitudesAutoEnumerar = H00DY2_A194SolicitudesAutoEnumerar[0];
               A110ZonasID = H00DY2_A110ZonasID[0];
               n110ZonasID = H00DY2_n110ZonasID[0];
               A114DepartamentoMunicipioId = H00DY2_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = H00DY2_n114DepartamentoMunicipioId[0];
               A600SolicitudesSubTipo = H00DY2_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = H00DY2_n600SolicitudesSubTipo[0];
               A112DepartamentoId = H00DY2_A112DepartamentoId[0];
               n112DepartamentoId = H00DY2_n112DepartamentoId[0];
               A172SolicitudesTelefono = H00DY2_A172SolicitudesTelefono[0];
               A127SolicitudesID = H00DY2_A127SolicitudesID[0];
               /* Execute user event: Load */
               E20DY2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBDY0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesDY2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV8cSolicitudesTelefono ,
                                              AV10cDepartamentoId ,
                                              AV11cDepartamentoMunicipioId ,
                                              AV12cZonasID ,
                                              AV15cSolicitudesAutoEnumerar ,
                                              AV16cSolicitudesCotizacion ,
                                              A172SolicitudesTelefono ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A110ZonasID ,
                                              A194SolicitudesAutoEnumerar ,
                                              A212SolicitudesCotizacion ,
                                              AV6cSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG
                                              }
         });
         lV8cSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV8cSolicitudesTelefono), 20, "%");
         /* Using cursor H00DY3 */
         pr_default.execute(1, new Object[] {AV6cSolicitudesID, lV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion});
         GRID1_nRecordCount = H00DY3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV8cSolicitudesTelefono, AV10cDepartamentoId, AV11cDepartamentoMunicipioId, AV12cZonasID, AV15cSolicitudesAutoEnumerar, AV16cSolicitudesCotizacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSolicitudesID_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         cmbSolicitudesSubTipo.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPDY0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19DY2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESID");
               GX_FocusControl = edtavCsolicitudesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSolicitudesID = 0;
               AssignAttri("", false, "AV6cSolicitudesID", StringUtil.LTrimStr( (decimal)(AV6cSolicitudesID), 18, 0));
            }
            else
            {
               AV6cSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cSolicitudesID", StringUtil.LTrimStr( (decimal)(AV6cSolicitudesID), 18, 0));
            }
            AV8cSolicitudesTelefono = cgiGet( edtavCsolicitudestelefono_Internalname);
            AssignAttri("", false, "AV8cSolicitudesTelefono", AV8cSolicitudesTelefono);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOID");
               GX_FocusControl = edtavCdepartamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cDepartamentoId = 0;
               AssignAttri("", false, "AV10cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV10cDepartamentoId), 18, 0));
            }
            else
            {
               AV10cDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV10cDepartamentoId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOMUNICIPIOID");
               GX_FocusControl = edtavCdepartamentomunicipioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cDepartamentoMunicipioId = 0;
               AssignAttri("", false, "AV11cDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV11cDepartamentoMunicipioId), 18, 0));
            }
            else
            {
               AV11cDepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV11cDepartamentoMunicipioId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCzonasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCzonasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCZONASID");
               GX_FocusControl = edtavCzonasid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cZonasID = 0;
               AssignAttri("", false, "AV12cZonasID", StringUtil.LTrimStr( (decimal)(AV12cZonasID), 18, 0));
            }
            else
            {
               AV12cZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCzonasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cZonasID", StringUtil.LTrimStr( (decimal)(AV12cZonasID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesautoenumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesautoenumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESAUTOENUMERAR");
               GX_FocusControl = edtavCsolicitudesautoenumerar_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cSolicitudesAutoEnumerar = 0;
               AssignAttri("", false, "AV15cSolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(AV15cSolicitudesAutoEnumerar), 4, 0));
            }
            else
            {
               AV15cSolicitudesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsolicitudesautoenumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15cSolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(AV15cSolicitudesAutoEnumerar), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudescotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudescotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESCOTIZACION");
               GX_FocusControl = edtavCsolicitudescotizacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cSolicitudesCotizacion = 0;
               AssignAttri("", false, "AV16cSolicitudesCotizacion", StringUtil.LTrimStr( AV16cSolicitudesCotizacion, 18, 2));
            }
            else
            {
               AV16cSolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtavCsolicitudescotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV16cSolicitudesCotizacion", StringUtil.LTrimStr( AV16cSolicitudesCotizacion, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSolicitudesID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSOLICITUDESTELEFONO"), AV8cSolicitudesTelefono) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cDepartamentoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cDepartamentoMunicipioId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCZONASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cZonasID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESAUTOENUMERAR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15cSolicitudesAutoEnumerar )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESCOTIZACION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV16cSolicitudesCotizacion )
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
         E19DY2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19DY2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Registro de Solicitudes", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20DY2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E21DY2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21DY2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pSolicitudesID = A127SolicitudesID;
         AssignAttri("", false, "AV13pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesID), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pSolicitudesID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pSolicitudesID"});
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
         AV13pSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesID), 18, 0));
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
         PADY2( ) ;
         WSDY2( ) ;
         WEDY2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021263146", true, true, false);
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
         context.AddJavascriptSource("gx00u0.js", "?202673021263146", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_84_idx;
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO_"+sGXsfl_84_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_84_idx;
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_84_fel_idx;
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO_"+sGXsfl_84_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_84_fel_idx;
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBDY0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A172SolicitudesTelefono);
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesTelefono_Internalname,StringUtil.RTrim( A172SolicitudesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"598 099 999999",(string)edtSolicitudesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSolicitudesSubTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDESSUBTIPO_" + sGXsfl_84_idx;
               cmbSolicitudesSubTipo.Name = GXCCtl;
               cmbSolicitudesSubTipo.WebTags = "";
               cmbSolicitudesSubTipo.addItem("T", context.GetMessage( "Trabajo Registrado", ""), 0);
               cmbSolicitudesSubTipo.addItem("E", context.GetMessage( "Ecommerce", ""), 0);
               cmbSolicitudesSubTipo.addItem("G", context.GetMessage( "Garantia", ""), 0);
               cmbSolicitudesSubTipo.addItem("M", context.GetMessage( "Mudanza", ""), 0);
               cmbSolicitudesSubTipo.addItem("A", context.GetMessage( "Obra", ""), 0);
               cmbSolicitudesSubTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
               cmbSolicitudesSubTipo.addItem("Z", context.GetMessage( "Postulacion", ""), 0);
               cmbSolicitudesSubTipo.addItem("S", context.GetMessage( "Subasta Web", ""), 0);
               cmbSolicitudesSubTipo.addItem("P", context.GetMessage( "Postulacion Web", ""), 0);
               if ( cmbSolicitudesSubTipo.ItemCount > 0 )
               {
                  A600SolicitudesSubTipo = cmbSolicitudesSubTipo.getValidValue(A600SolicitudesSubTipo);
                  n600SolicitudesSubTipo = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudesSubTipo,(string)cmbSolicitudesSubTipo_Internalname,StringUtil.RTrim( A600SolicitudesSubTipo),(short)1,(string)cmbSolicitudesSubTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
            AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Values", (string)(cmbSolicitudesSubTipo.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            send_integrity_lvl_hashesDY2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SOLICITUDESSUBTIPO_" + sGXsfl_84_idx;
         cmbSolicitudesSubTipo.Name = GXCCtl;
         cmbSolicitudesSubTipo.WebTags = "";
         cmbSolicitudesSubTipo.addItem("T", context.GetMessage( "Trabajo Registrado", ""), 0);
         cmbSolicitudesSubTipo.addItem("E", context.GetMessage( "Ecommerce", ""), 0);
         cmbSolicitudesSubTipo.addItem("G", context.GetMessage( "Garantia", ""), 0);
         cmbSolicitudesSubTipo.addItem("M", context.GetMessage( "Mudanza", ""), 0);
         cmbSolicitudesSubTipo.addItem("A", context.GetMessage( "Obra", ""), 0);
         cmbSolicitudesSubTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         cmbSolicitudesSubTipo.addItem("Z", context.GetMessage( "Postulacion", ""), 0);
         cmbSolicitudesSubTipo.addItem("S", context.GetMessage( "Subasta Web", ""), 0);
         cmbSolicitudesSubTipo.addItem("P", context.GetMessage( "Postulacion Web", ""), 0);
         if ( cmbSolicitudesSubTipo.ItemCount > 0 )
         {
            A600SolicitudesSubTipo = cmbSolicitudesSubTipo.getValidValue(A600SolicitudesSubTipo);
            n600SolicitudesSubTipo = false;
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
            context.SendWebValue( context.GetMessage( "Solicitud No:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sub Tipo", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A172SolicitudesTelefono)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A600SolicitudesSubTipo)));
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
         lblLblsolicitudesidfilter_Internalname = "LBLSOLICITUDESIDFILTER";
         edtavCsolicitudesid_Internalname = "vCSOLICITUDESID";
         divSolicitudesidfiltercontainer_Internalname = "SOLICITUDESIDFILTERCONTAINER";
         lblLblsolicitudestelefonofilter_Internalname = "LBLSOLICITUDESTELEFONOFILTER";
         edtavCsolicitudestelefono_Internalname = "vCSOLICITUDESTELEFONO";
         divSolicitudestelefonofiltercontainer_Internalname = "SOLICITUDESTELEFONOFILTERCONTAINER";
         lblLbldepartamentoidfilter_Internalname = "LBLDEPARTAMENTOIDFILTER";
         edtavCdepartamentoid_Internalname = "vCDEPARTAMENTOID";
         divDepartamentoidfiltercontainer_Internalname = "DEPARTAMENTOIDFILTERCONTAINER";
         lblLbldepartamentomunicipioidfilter_Internalname = "LBLDEPARTAMENTOMUNICIPIOIDFILTER";
         edtavCdepartamentomunicipioid_Internalname = "vCDEPARTAMENTOMUNICIPIOID";
         divDepartamentomunicipioidfiltercontainer_Internalname = "DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER";
         lblLblzonasidfilter_Internalname = "LBLZONASIDFILTER";
         edtavCzonasid_Internalname = "vCZONASID";
         divZonasidfiltercontainer_Internalname = "ZONASIDFILTERCONTAINER";
         lblLblsolicitudesautoenumerarfilter_Internalname = "LBLSOLICITUDESAUTOENUMERARFILTER";
         edtavCsolicitudesautoenumerar_Internalname = "vCSOLICITUDESAUTOENUMERAR";
         divSolicitudesautoenumerarfiltercontainer_Internalname = "SOLICITUDESAUTOENUMERARFILTERCONTAINER";
         lblLblsolicitudescotizacionfilter_Internalname = "LBLSOLICITUDESCOTIZACIONFILTER";
         edtavCsolicitudescotizacion_Internalname = "vCSOLICITUDESCOTIZACION";
         divSolicitudescotizacionfiltercontainer_Internalname = "SOLICITUDESCOTIZACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO";
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
         cmbSolicitudesSubTipo_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         cmbSolicitudesSubTipo.Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtavCsolicitudescotizacion_Jsonclick = "";
         edtavCsolicitudescotizacion_Enabled = 1;
         edtavCsolicitudescotizacion_Visible = 1;
         edtavCsolicitudesautoenumerar_Jsonclick = "";
         edtavCsolicitudesautoenumerar_Enabled = 1;
         edtavCsolicitudesautoenumerar_Visible = 1;
         edtavCzonasid_Jsonclick = "";
         edtavCzonasid_Enabled = 1;
         edtavCzonasid_Visible = 1;
         edtavCdepartamentomunicipioid_Jsonclick = "";
         edtavCdepartamentomunicipioid_Enabled = 1;
         edtavCdepartamentomunicipioid_Visible = 1;
         edtavCdepartamentoid_Jsonclick = "";
         edtavCdepartamentoid_Enabled = 1;
         edtavCdepartamentoid_Visible = 1;
         edtavCsolicitudestelefono_Jsonclick = "";
         edtavCsolicitudestelefono_Enabled = 1;
         edtavCsolicitudestelefono_Visible = 1;
         edtavCsolicitudesid_Jsonclick = "";
         edtavCsolicitudesid_Enabled = 1;
         edtavCsolicitudesid_Visible = 1;
         divSolicitudescotizacionfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudesautoenumerarfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divZonasidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentomunicipioidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudestelefonofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Registro de Solicitudes", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cSolicitudesTelefono',fld:'vCSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV10cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cZonasID',fld:'vCZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cSolicitudesAutoEnumerar',fld:'vCSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV16cSolicitudesCotizacion',fld:'vCSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18DY1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLSOLICITUDESIDFILTER.CLICK","{handler:'E11DY1',iparms:[{av:'divSolicitudesidfiltercontainer_Class',ctrl:'SOLICITUDESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESIDFILTER.CLICK",",oparms:[{av:'divSolicitudesidfiltercontainer_Class',ctrl:'SOLICITUDESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudesid_Visible',ctrl:'vCSOLICITUDESID',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDESTELEFONOFILTER.CLICK","{handler:'E12DY1',iparms:[{av:'divSolicitudestelefonofiltercontainer_Class',ctrl:'SOLICITUDESTELEFONOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESTELEFONOFILTER.CLICK",",oparms:[{av:'divSolicitudestelefonofiltercontainer_Class',ctrl:'SOLICITUDESTELEFONOFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudestelefono_Visible',ctrl:'vCSOLICITUDESTELEFONO',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK","{handler:'E13DY1',iparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK",",oparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoid_Visible',ctrl:'vCDEPARTAMENTOID',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOIDFILTER.CLICK","{handler:'E14DY1',iparms:[{av:'divDepartamentomunicipioidfiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOIDFILTER.CLICK",",oparms:[{av:'divDepartamentomunicipioidfiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentomunicipioid_Visible',ctrl:'vCDEPARTAMENTOMUNICIPIOID',prop:'Visible'}]}");
         setEventMetadata("LBLZONASIDFILTER.CLICK","{handler:'E15DY1',iparms:[{av:'divZonasidfiltercontainer_Class',ctrl:'ZONASIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLZONASIDFILTER.CLICK",",oparms:[{av:'divZonasidfiltercontainer_Class',ctrl:'ZONASIDFILTERCONTAINER',prop:'Class'},{av:'edtavCzonasid_Visible',ctrl:'vCZONASID',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDESAUTOENUMERARFILTER.CLICK","{handler:'E16DY1',iparms:[{av:'divSolicitudesautoenumerarfiltercontainer_Class',ctrl:'SOLICITUDESAUTOENUMERARFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESAUTOENUMERARFILTER.CLICK",",oparms:[{av:'divSolicitudesautoenumerarfiltercontainer_Class',ctrl:'SOLICITUDESAUTOENUMERARFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudesautoenumerar_Visible',ctrl:'vCSOLICITUDESAUTOENUMERAR',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDESCOTIZACIONFILTER.CLICK","{handler:'E17DY1',iparms:[{av:'divSolicitudescotizacionfiltercontainer_Class',ctrl:'SOLICITUDESCOTIZACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESCOTIZACIONFILTER.CLICK",",oparms:[{av:'divSolicitudescotizacionfiltercontainer_Class',ctrl:'SOLICITUDESCOTIZACIONFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudescotizacion_Visible',ctrl:'vCSOLICITUDESCOTIZACION',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21DY2',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cSolicitudesTelefono',fld:'vCSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV10cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cZonasID',fld:'vCZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cSolicitudesAutoEnumerar',fld:'vCSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV16cSolicitudesCotizacion',fld:'vCSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cSolicitudesTelefono',fld:'vCSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV10cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cZonasID',fld:'vCZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cSolicitudesAutoEnumerar',fld:'vCSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV16cSolicitudesCotizacion',fld:'vCSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cSolicitudesTelefono',fld:'vCSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV10cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cZonasID',fld:'vCZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cSolicitudesAutoEnumerar',fld:'vCSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV16cSolicitudesCotizacion',fld:'vCSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cSolicitudesTelefono',fld:'vCSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV10cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12cZonasID',fld:'vCZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15cSolicitudesAutoEnumerar',fld:'vCSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV16cSolicitudesCotizacion',fld:'vCSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Solicitudessubtipo',iparms:[]");
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
         AV8cSolicitudesTelefono = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsolicitudesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsolicitudestelefonofilter_Jsonclick = "";
         lblLbldepartamentoidfilter_Jsonclick = "";
         lblLbldepartamentomunicipioidfilter_Jsonclick = "";
         lblLblzonasidfilter_Jsonclick = "";
         lblLblsolicitudesautoenumerarfilter_Jsonclick = "";
         lblLblsolicitudescotizacionfilter_Jsonclick = "";
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
         A172SolicitudesTelefono = "";
         A600SolicitudesSubTipo = "";
         lV8cSolicitudesTelefono = "";
         H00DY2_A212SolicitudesCotizacion = new decimal[1] ;
         H00DY2_A194SolicitudesAutoEnumerar = new short[1] ;
         H00DY2_A110ZonasID = new long[1] ;
         H00DY2_n110ZonasID = new bool[] {false} ;
         H00DY2_A114DepartamentoMunicipioId = new long[1] ;
         H00DY2_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00DY2_A600SolicitudesSubTipo = new string[] {""} ;
         H00DY2_n600SolicitudesSubTipo = new bool[] {false} ;
         H00DY2_A112DepartamentoId = new long[1] ;
         H00DY2_n112DepartamentoId = new bool[] {false} ;
         H00DY2_A172SolicitudesTelefono = new string[] {""} ;
         H00DY2_A127SolicitudesID = new long[1] ;
         H00DY3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00u0__default(),
            new Object[][] {
                new Object[] {
               H00DY2_A212SolicitudesCotizacion, H00DY2_A194SolicitudesAutoEnumerar, H00DY2_A110ZonasID, H00DY2_n110ZonasID, H00DY2_A114DepartamentoMunicipioId, H00DY2_n114DepartamentoMunicipioId, H00DY2_A600SolicitudesSubTipo, H00DY2_n600SolicitudesSubTipo, H00DY2_A112DepartamentoId, H00DY2_n112DepartamentoId,
               H00DY2_A172SolicitudesTelefono, H00DY2_A127SolicitudesID
               }
               , new Object[] {
               H00DY3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15cSolicitudesAutoEnumerar ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A194SolicitudesAutoEnumerar ;
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
      private int edtavCsolicitudesid_Enabled ;
      private int edtavCsolicitudesid_Visible ;
      private int edtavCsolicitudestelefono_Visible ;
      private int edtavCsolicitudestelefono_Enabled ;
      private int edtavCdepartamentoid_Enabled ;
      private int edtavCdepartamentoid_Visible ;
      private int edtavCdepartamentomunicipioid_Enabled ;
      private int edtavCdepartamentomunicipioid_Visible ;
      private int edtavCzonasid_Enabled ;
      private int edtavCzonasid_Visible ;
      private int edtavCsolicitudesautoenumerar_Enabled ;
      private int edtavCsolicitudesautoenumerar_Visible ;
      private int edtavCsolicitudescotizacion_Enabled ;
      private int edtavCsolicitudescotizacion_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pSolicitudesID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cSolicitudesID ;
      private long AV10cDepartamentoId ;
      private long AV11cDepartamentoMunicipioId ;
      private long AV12cZonasID ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long GRID1_nCurrentRecord ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long GRID1_nRecordCount ;
      private decimal AV16cSolicitudesCotizacion ;
      private decimal A212SolicitudesCotizacion ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divSolicitudesidfiltercontainer_Class ;
      private string divSolicitudestelefonofiltercontainer_Class ;
      private string divDepartamentoidfiltercontainer_Class ;
      private string divDepartamentomunicipioidfiltercontainer_Class ;
      private string divZonasidfiltercontainer_Class ;
      private string divSolicitudesautoenumerarfiltercontainer_Class ;
      private string divSolicitudescotizacionfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV8cSolicitudesTelefono ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSolicitudesidfiltercontainer_Internalname ;
      private string lblLblsolicitudesidfilter_Internalname ;
      private string lblLblsolicitudesidfilter_Jsonclick ;
      private string edtavCsolicitudesid_Internalname ;
      private string TempTags ;
      private string edtavCsolicitudesid_Jsonclick ;
      private string divSolicitudestelefonofiltercontainer_Internalname ;
      private string lblLblsolicitudestelefonofilter_Internalname ;
      private string lblLblsolicitudestelefonofilter_Jsonclick ;
      private string edtavCsolicitudestelefono_Internalname ;
      private string edtavCsolicitudestelefono_Jsonclick ;
      private string divDepartamentoidfiltercontainer_Internalname ;
      private string lblLbldepartamentoidfilter_Internalname ;
      private string lblLbldepartamentoidfilter_Jsonclick ;
      private string edtavCdepartamentoid_Internalname ;
      private string edtavCdepartamentoid_Jsonclick ;
      private string divDepartamentomunicipioidfiltercontainer_Internalname ;
      private string lblLbldepartamentomunicipioidfilter_Internalname ;
      private string lblLbldepartamentomunicipioidfilter_Jsonclick ;
      private string edtavCdepartamentomunicipioid_Internalname ;
      private string edtavCdepartamentomunicipioid_Jsonclick ;
      private string divZonasidfiltercontainer_Internalname ;
      private string lblLblzonasidfilter_Internalname ;
      private string lblLblzonasidfilter_Jsonclick ;
      private string edtavCzonasid_Internalname ;
      private string edtavCzonasid_Jsonclick ;
      private string divSolicitudesautoenumerarfiltercontainer_Internalname ;
      private string lblLblsolicitudesautoenumerarfilter_Internalname ;
      private string lblLblsolicitudesautoenumerarfilter_Jsonclick ;
      private string edtavCsolicitudesautoenumerar_Internalname ;
      private string edtavCsolicitudesautoenumerar_Jsonclick ;
      private string divSolicitudescotizacionfiltercontainer_Internalname ;
      private string lblLblsolicitudescotizacionfilter_Internalname ;
      private string lblLblsolicitudescotizacionfilter_Jsonclick ;
      private string edtavCsolicitudescotizacion_Internalname ;
      private string edtavCsolicitudescotizacion_Jsonclick ;
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
      private string edtSolicitudesID_Internalname ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string cmbSolicitudesSubTipo_Internalname ;
      private string A600SolicitudesSubTipo ;
      private string lV8cSolicitudesTelefono ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSolicitudesID_Jsonclick ;
      private string gxphoneLink ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string GXCCtl ;
      private string cmbSolicitudesSubTipo_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n112DepartamentoId ;
      private bool n600SolicitudesSubTipo ;
      private bool gxdyncontrolsrefreshing ;
      private bool n110ZonasID ;
      private bool n114DepartamentoMunicipioId ;
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
      private GXCombobox cmbSolicitudesSubTipo ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00DY2_A212SolicitudesCotizacion ;
      private short[] H00DY2_A194SolicitudesAutoEnumerar ;
      private long[] H00DY2_A110ZonasID ;
      private bool[] H00DY2_n110ZonasID ;
      private long[] H00DY2_A114DepartamentoMunicipioId ;
      private bool[] H00DY2_n114DepartamentoMunicipioId ;
      private string[] H00DY2_A600SolicitudesSubTipo ;
      private bool[] H00DY2_n600SolicitudesSubTipo ;
      private long[] H00DY2_A112DepartamentoId ;
      private bool[] H00DY2_n112DepartamentoId ;
      private string[] H00DY2_A172SolicitudesTelefono ;
      private long[] H00DY2_A127SolicitudesID ;
      private long[] H00DY3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pSolicitudesID ;
   }

   public class gx00u0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00DY2( IGxContext context ,
                                             string AV8cSolicitudesTelefono ,
                                             long AV10cDepartamentoId ,
                                             long AV11cDepartamentoMunicipioId ,
                                             long AV12cZonasID ,
                                             short AV15cSolicitudesAutoEnumerar ,
                                             decimal AV16cSolicitudesCotizacion ,
                                             string A172SolicitudesTelefono ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             short A194SolicitudesAutoEnumerar ,
                                             decimal A212SolicitudesCotizacion ,
                                             long AV6cSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SolicitudesCotizacion], [SolicitudesAutoEnumerar], [ZonasID], [DepartamentoMunicipioId], [SolicitudesSubTipo], [DepartamentoId], [SolicitudesTelefono], [SolicitudesID]";
         sFromString = " FROM [Solicitudes]";
         sOrderString = "";
         AddWhere(sWhereString, "([SolicitudesID] >= @AV6cSolicitudesID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSolicitudesTelefono)) )
         {
            AddWhere(sWhereString, "([SolicitudesTelefono] like @lV8cSolicitudesTelefono)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV10cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV10cDepartamentoId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV11cDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV11cDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV12cZonasID) )
         {
            AddWhere(sWhereString, "([ZonasID] >= @AV12cZonasID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV15cSolicitudesAutoEnumerar) )
         {
            AddWhere(sWhereString, "([SolicitudesAutoEnumerar] >= @AV15cSolicitudesAutoEnumerar)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16cSolicitudesCotizacion) )
         {
            AddWhere(sWhereString, "([SolicitudesCotizacion] >= @AV16cSolicitudesCotizacion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [SolicitudesID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00DY3( IGxContext context ,
                                             string AV8cSolicitudesTelefono ,
                                             long AV10cDepartamentoId ,
                                             long AV11cDepartamentoMunicipioId ,
                                             long AV12cZonasID ,
                                             short AV15cSolicitudesAutoEnumerar ,
                                             decimal AV16cSolicitudesCotizacion ,
                                             string A172SolicitudesTelefono ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             short A194SolicitudesAutoEnumerar ,
                                             decimal A212SolicitudesCotizacion ,
                                             long AV6cSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Solicitudes]";
         AddWhere(sWhereString, "([SolicitudesID] >= @AV6cSolicitudesID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSolicitudesTelefono)) )
         {
            AddWhere(sWhereString, "([SolicitudesTelefono] like @lV8cSolicitudesTelefono)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV10cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV10cDepartamentoId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV11cDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV11cDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV12cZonasID) )
         {
            AddWhere(sWhereString, "([ZonasID] >= @AV12cZonasID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV15cSolicitudesAutoEnumerar) )
         {
            AddWhere(sWhereString, "([SolicitudesAutoEnumerar] >= @AV15cSolicitudesAutoEnumerar)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16cSolicitudesCotizacion) )
         {
            AddWhere(sWhereString, "([SolicitudesCotizacion] >= @AV16cSolicitudesCotizacion)");
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
                     return conditional_H00DY2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00DY3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00DY2;
          prmH00DY2 = new Object[] {
          new ParDef("@AV6cSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@lV8cSolicitudesTelefono",GXType.NChar,20,0) ,
          new ParDef("@AV10cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV11cDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV12cZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV15cSolicitudesAutoEnumerar",GXType.Int16,4,0) ,
          new ParDef("@AV16cSolicitudesCotizacion",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00DY3;
          prmH00DY3 = new Object[] {
          new ParDef("@AV6cSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@lV8cSolicitudesTelefono",GXType.NChar,20,0) ,
          new ParDef("@AV10cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV11cDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV12cZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV15cSolicitudesAutoEnumerar",GXType.Int16,4,0) ,
          new ParDef("@AV16cSolicitudesCotizacion",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00DY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DY2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00DY3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DY3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 1);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 20);
                ((long[]) buf[11])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

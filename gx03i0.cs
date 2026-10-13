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
   public class gx03i0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03i0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03i0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pPostulacionesId )
      {
         this.AV12pPostulacionesId = 0 ;
         ExecutePrivate();
         aP0_pPostulacionesId=this.AV12pPostulacionesId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCpostulacionesestado = new GXCombobox();
         chkavCpostulacionesreqsuministros = new GXCheckbox();
         cmbPostulacionesEstado = new GXCombobox();
         chkPostulacionesReqSuministros = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pPostulacionesId");
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
               gxfirstwebparm = GetFirstPar( "pPostulacionesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pPostulacionesId");
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
               AV12pPostulacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pPostulacionesId", StringUtil.LTrimStr( (decimal)(AV12pPostulacionesId), 18, 0));
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
         AV6cPostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cPostulacionesId"), "."), 18, MidpointRounding.ToEven));
         AV10cPostulacionesFechaAlta = context.localUtil.ParseDTimeParm( GetPar( "cPostulacionesFechaAlta"));
         cmbavCpostulacionesestado.FromJSonString( GetNextPar( ));
         AV11cPostulacionesEstado = GetPar( "cPostulacionesEstado");
         AV15cPostulacionesReqSuministros = StringUtil.StrToBool( GetPar( "cPostulacionesReqSuministros"));
         AV16cPostulacionesFechaCierre = context.localUtil.ParseDateParm( GetPar( "cPostulacionesFechaCierre"));
         AV17cPostulacionesHoraCierre = GetPar( "cPostulacionesHoraCierre");
         AV18cPostulacionesTipoFecha = GetPar( "cPostulacionesTipoFecha");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cPostulacionesId, AV10cPostulacionesFechaAlta, AV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, AV17cPostulacionesHoraCierre, AV18cPostulacionesTipoFecha) ;
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
         PAH92( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTH92( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03i0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pPostulacionesId,18,0))}, new string[] {"pPostulacionesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESFECHAALTA", context.localUtil.TToC( AV10cPostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESESTADO", StringUtil.RTrim( AV11cPostulacionesEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESREQSUMINISTROS", StringUtil.BoolToStr( AV15cPostulacionesReqSuministros));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESFECHACIERRE", context.localUtil.Format(AV16cPostulacionesFechaCierre, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESHORACIERRE", AV17cPostulacionesHoraCierre);
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONESTIPOFECHA", AV18cPostulacionesTipoFecha);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pPostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESIDFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionesestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESREQSUMINISTROSFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionesreqsuministrosfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESHORACIERREFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacioneshoracierrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESTIPOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionestipofechafiltercontainer_Class));
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
            WEH92( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTH92( ) ;
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
         return formatLink("gx03i0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pPostulacionesId,18,0))}, new string[] {"pPostulacionesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03I0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Postulaciones", "") ;
      }

      protected void WBH90( )
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
            GxWebStd.gx_div_start( context, divPostulacionesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionesidfilter_Internalname, context.GetMessage( "Postulaciones Id", ""), "", "", lblLblpostulacionesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11h91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionesid_Internalname, context.GetMessage( "Postulaciones Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCpostulacionesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cPostulacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cPostulacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpostulacionesid_Visible, edtavCpostulacionesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03I0.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionesfechaaltafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionesfechaaltafilter_Internalname, context.GetMessage( "Fecha", ""), "", "", lblLblpostulacionesfechaaltafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionesfechaalta_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpostulacionesfechaalta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionesfechaalta_Internalname, context.localUtil.TToC( AV10cPostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV10cPostulacionesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionesfechaalta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpostulacionesfechaalta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03I0.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionesestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionesestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionesestadofilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblpostulacionesestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12h91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCpostulacionesestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCpostulacionesestado, cmbavCpostulacionesestado_Internalname, StringUtil.RTrim( AV11cPostulacionesEstado), 1, cmbavCpostulacionesestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCpostulacionesestado.Visible, cmbavCpostulacionesestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_Gx03I0.htm");
            cmbavCpostulacionesestado.CurrentValue = StringUtil.RTrim( AV11cPostulacionesEstado);
            AssignProp("", false, cmbavCpostulacionesestado_Internalname, "Values", (string)(cmbavCpostulacionesestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divPostulacionesreqsuministrosfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionesreqsuministrosfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionesreqsuministrosfilter_Internalname, context.GetMessage( "Postulaciones Req Suministros", ""), "", "", lblLblpostulacionesreqsuministrosfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13h91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCpostulacionesreqsuministros_Internalname, context.GetMessage( "Postulaciones Req Suministros", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCpostulacionesreqsuministros_Internalname, StringUtil.BoolToStr( AV15cPostulacionesReqSuministros), "", context.GetMessage( "Postulaciones Req Suministros", ""), chkavCpostulacionesreqsuministros.Visible, chkavCpostulacionesreqsuministros.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\"");
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
            GxWebStd.gx_div_start( context, divPostulacionesfechacierrefiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionesfechacierrefilter_Internalname, context.GetMessage( "Postulaciones Fecha Cierre", ""), "", "", lblLblpostulacionesfechacierrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionesfechacierre_Internalname, context.GetMessage( "Postulaciones Fecha Cierre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpostulacionesfechacierre_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionesfechacierre_Internalname, context.localUtil.Format(AV16cPostulacionesFechaCierre, "99/99/99"), context.localUtil.Format( AV16cPostulacionesFechaCierre, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionesfechacierre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpostulacionesfechacierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03I0.htm");
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
            GxWebStd.gx_div_start( context, divPostulacioneshoracierrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacioneshoracierrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacioneshoracierrefilter_Internalname, context.GetMessage( "Postulaciones Hora Cierre", ""), "", "", lblLblpostulacioneshoracierrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14h91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacioneshoracierre_Internalname, context.GetMessage( "Postulaciones Hora Cierre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpostulacioneshoracierre_Internalname, AV17cPostulacionesHoraCierre, StringUtil.RTrim( context.localUtil.Format( AV17cPostulacionesHoraCierre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacioneshoracierre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpostulacioneshoracierre_Visible, edtavCpostulacioneshoracierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03I0.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionestipofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionestipofechafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionestipofechafilter_Internalname, context.GetMessage( "Postulaciones Tipo Fecha", ""), "", "", lblLblpostulacionestipofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15h91_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03I0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionestipofecha_Internalname, context.GetMessage( "Postulaciones Tipo Fecha", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionestipofecha_Internalname, AV18cPostulacionesTipoFecha, StringUtil.RTrim( context.localUtil.Format( AV18cPostulacionesTipoFecha, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionestipofecha_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpostulacionestipofecha_Visible, edtavCpostulacionestipofecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03I0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16h91_client"+"'", TempTags, "", 2, "HLP_Gx03I0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03I0.htm");
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

      protected void STARTH92( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Postulaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPH90( ) ;
      }

      protected void WSH92( )
      {
         STARTH92( ) ;
         EVTH92( ) ;
      }

      protected void EVTH92( )
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
                              A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A425PostulacionesFechaAlta = context.localUtil.CToT( cgiGet( edtPostulacionesFechaAlta_Internalname), 0);
                              cmbPostulacionesEstado.Name = cmbPostulacionesEstado_Internalname;
                              cmbPostulacionesEstado.CurrentValue = cgiGet( cmbPostulacionesEstado_Internalname);
                              A424PostulacionesEstado = cgiGet( cmbPostulacionesEstado_Internalname);
                              A937PostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( chkPostulacionesReqSuministros_Internalname));
                              A939PostulacionesFechaCierre = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionesFechaCierre_Internalname), 0));
                              A940PostulacionesHoraCierre = cgiGet( edtPostulacionesHoraCierre_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17H92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18H92 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cpostulacionesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPOSTULACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cPostulacionesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionesfechaalta Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPOSTULACIONESFECHAALTA"), 0) != AV10cPostulacionesFechaAlta )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionesestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONESESTADO"), AV11cPostulacionesEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionesreqsuministros Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCPOSTULACIONESREQSUMINISTROS")) != AV15cPostulacionesReqSuministros )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionesfechacierre Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPOSTULACIONESFECHACIERRE"), 0) != AV16cPostulacionesFechaCierre )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacioneshoracierre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONESHORACIERRE"), AV17cPostulacionesHoraCierre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionestipofecha Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONESTIPOFECHA"), AV18cPostulacionesTipoFecha) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19H92 ();
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

      protected void WEH92( )
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

      protected void PAH92( )
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
                                        long AV6cPostulacionesId ,
                                        DateTime AV10cPostulacionesFechaAlta ,
                                        string AV11cPostulacionesEstado ,
                                        bool AV15cPostulacionesReqSuministros ,
                                        DateTime AV16cPostulacionesFechaCierre ,
                                        string AV17cPostulacionesHoraCierre ,
                                        string AV18cPostulacionesTipoFecha )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFH92( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "POSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", "")));
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
         if ( cmbavCpostulacionesestado.ItemCount > 0 )
         {
            AV11cPostulacionesEstado = cmbavCpostulacionesestado.getValidValue(AV11cPostulacionesEstado);
            AssignAttri("", false, "AV11cPostulacionesEstado", AV11cPostulacionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCpostulacionesestado.CurrentValue = StringUtil.RTrim( AV11cPostulacionesEstado);
            AssignProp("", false, cmbavCpostulacionesestado_Internalname, "Values", cmbavCpostulacionesestado.ToJavascriptSource(), true);
         }
         AV15cPostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( AV15cPostulacionesReqSuministros));
         AssignAttri("", false, "AV15cPostulacionesReqSuministros", AV15cPostulacionesReqSuministros);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFH92( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFH92( )
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
                                                 AV10cPostulacionesFechaAlta ,
                                                 AV11cPostulacionesEstado ,
                                                 AV15cPostulacionesReqSuministros ,
                                                 AV16cPostulacionesFechaCierre ,
                                                 AV17cPostulacionesHoraCierre ,
                                                 AV18cPostulacionesTipoFecha ,
                                                 A425PostulacionesFechaAlta ,
                                                 A424PostulacionesEstado ,
                                                 A937PostulacionesReqSuministros ,
                                                 A939PostulacionesFechaCierre ,
                                                 A940PostulacionesHoraCierre ,
                                                 A941PostulacionesTipoFecha ,
                                                 AV6cPostulacionesId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.LONG
                                                 }
            });
            lV11cPostulacionesEstado = StringUtil.PadR( StringUtil.RTrim( AV11cPostulacionesEstado), 3, "%");
            lV17cPostulacionesHoraCierre = StringUtil.Concat( StringUtil.RTrim( AV17cPostulacionesHoraCierre), "%", "");
            lV18cPostulacionesTipoFecha = StringUtil.Concat( StringUtil.RTrim( AV18cPostulacionesTipoFecha), "%", "");
            /* Using cursor H00H92 */
            pr_default.execute(0, new Object[] {AV6cPostulacionesId, AV10cPostulacionesFechaAlta, lV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, lV17cPostulacionesHoraCierre, lV18cPostulacionesTipoFecha, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A941PostulacionesTipoFecha = H00H92_A941PostulacionesTipoFecha[0];
               A940PostulacionesHoraCierre = H00H92_A940PostulacionesHoraCierre[0];
               A939PostulacionesFechaCierre = H00H92_A939PostulacionesFechaCierre[0];
               A937PostulacionesReqSuministros = H00H92_A937PostulacionesReqSuministros[0];
               A424PostulacionesEstado = H00H92_A424PostulacionesEstado[0];
               A425PostulacionesFechaAlta = H00H92_A425PostulacionesFechaAlta[0];
               A422PostulacionesId = H00H92_A422PostulacionesId[0];
               /* Execute user event: Load */
               E18H92 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBH90( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesH92( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_POSTULACIONESID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV10cPostulacionesFechaAlta ,
                                              AV11cPostulacionesEstado ,
                                              AV15cPostulacionesReqSuministros ,
                                              AV16cPostulacionesFechaCierre ,
                                              AV17cPostulacionesHoraCierre ,
                                              AV18cPostulacionesTipoFecha ,
                                              A425PostulacionesFechaAlta ,
                                              A424PostulacionesEstado ,
                                              A937PostulacionesReqSuministros ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              AV6cPostulacionesId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV11cPostulacionesEstado = StringUtil.PadR( StringUtil.RTrim( AV11cPostulacionesEstado), 3, "%");
         lV17cPostulacionesHoraCierre = StringUtil.Concat( StringUtil.RTrim( AV17cPostulacionesHoraCierre), "%", "");
         lV18cPostulacionesTipoFecha = StringUtil.Concat( StringUtil.RTrim( AV18cPostulacionesTipoFecha), "%", "");
         /* Using cursor H00H93 */
         pr_default.execute(1, new Object[] {AV6cPostulacionesId, AV10cPostulacionesFechaAlta, lV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, lV17cPostulacionesHoraCierre, lV18cPostulacionesTipoFecha});
         GRID1_nRecordCount = H00H93_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPostulacionesId, AV10cPostulacionesFechaAlta, AV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, AV17cPostulacionesHoraCierre, AV18cPostulacionesTipoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPostulacionesId, AV10cPostulacionesFechaAlta, AV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, AV17cPostulacionesHoraCierre, AV18cPostulacionesTipoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPostulacionesId, AV10cPostulacionesFechaAlta, AV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, AV17cPostulacionesHoraCierre, AV18cPostulacionesTipoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPostulacionesId, AV10cPostulacionesFechaAlta, AV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, AV17cPostulacionesHoraCierre, AV18cPostulacionesTipoFecha) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPostulacionesId, AV10cPostulacionesFechaAlta, AV11cPostulacionesEstado, AV15cPostulacionesReqSuministros, AV16cPostulacionesFechaCierre, AV17cPostulacionesHoraCierre, AV18cPostulacionesTipoFecha) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtPostulacionesId_Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         cmbPostulacionesEstado.Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         edtPostulacionesFechaCierre_Enabled = 0;
         edtPostulacionesHoraCierre_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPH90( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17H92 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpostulacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpostulacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPOSTULACIONESID");
               GX_FocusControl = edtavCpostulacionesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cPostulacionesId = 0;
               AssignAttri("", false, "AV6cPostulacionesId", StringUtil.LTrimStr( (decimal)(AV6cPostulacionesId), 18, 0));
            }
            else
            {
               AV6cPostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpostulacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cPostulacionesId", StringUtil.LTrimStr( (decimal)(AV6cPostulacionesId), 18, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCpostulacionesfechaalta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "vCPOSTULACIONESFECHAALTA");
               GX_FocusControl = edtavCpostulacionesfechaalta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10cPostulacionesFechaAlta", context.localUtil.TToC( AV10cPostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV10cPostulacionesFechaAlta = context.localUtil.CToT( cgiGet( edtavCpostulacionesfechaalta_Internalname));
               AssignAttri("", false, "AV10cPostulacionesFechaAlta", context.localUtil.TToC( AV10cPostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            cmbavCpostulacionesestado.Name = cmbavCpostulacionesestado_Internalname;
            cmbavCpostulacionesestado.CurrentValue = cgiGet( cmbavCpostulacionesestado_Internalname);
            AV11cPostulacionesEstado = cgiGet( cmbavCpostulacionesestado_Internalname);
            AssignAttri("", false, "AV11cPostulacionesEstado", AV11cPostulacionesEstado);
            AV15cPostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( chkavCpostulacionesreqsuministros_Internalname));
            AssignAttri("", false, "AV15cPostulacionesReqSuministros", AV15cPostulacionesReqSuministros);
            if ( context.localUtil.VCDate( cgiGet( edtavCpostulacionesfechacierre_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Postulaciones Fecha Cierre", "")}), 1, "vCPOSTULACIONESFECHACIERRE");
               GX_FocusControl = edtavCpostulacionesfechacierre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cPostulacionesFechaCierre = DateTime.MinValue;
               AssignAttri("", false, "AV16cPostulacionesFechaCierre", context.localUtil.Format(AV16cPostulacionesFechaCierre, "99/99/99"));
            }
            else
            {
               AV16cPostulacionesFechaCierre = context.localUtil.CToD( cgiGet( edtavCpostulacionesfechacierre_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV16cPostulacionesFechaCierre", context.localUtil.Format(AV16cPostulacionesFechaCierre, "99/99/99"));
            }
            AV17cPostulacionesHoraCierre = cgiGet( edtavCpostulacioneshoracierre_Internalname);
            AssignAttri("", false, "AV17cPostulacionesHoraCierre", AV17cPostulacionesHoraCierre);
            AV18cPostulacionesTipoFecha = cgiGet( edtavCpostulacionestipofecha_Internalname);
            AssignAttri("", false, "AV18cPostulacionesTipoFecha", AV18cPostulacionesTipoFecha);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPOSTULACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cPostulacionesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCPOSTULACIONESFECHAALTA")) != AV10cPostulacionesFechaAlta )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONESESTADO"), AV11cPostulacionesEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCPOSTULACIONESREQSUMINISTROS")) != AV15cPostulacionesReqSuministros )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPOSTULACIONESFECHACIERRE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV16cPostulacionesFechaCierre ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONESHORACIERRE"), AV17cPostulacionesHoraCierre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONESTIPOFECHA"), AV18cPostulacionesTipoFecha) != 0 )
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
         E17H92 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17H92( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Postulaciones", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18H92( )
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
         E19H92 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19H92( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pPostulacionesId = A422PostulacionesId;
         AssignAttri("", false, "AV12pPostulacionesId", StringUtil.LTrimStr( (decimal)(AV12pPostulacionesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pPostulacionesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pPostulacionesId"});
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
         AV12pPostulacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pPostulacionesId", StringUtil.LTrimStr( (decimal)(AV12pPostulacionesId), 18, 0));
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
         PAH92( ) ;
         WSH92( ) ;
         WEH92( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021262467", true, true, false);
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
         context.AddJavascriptSource("gx03i0.js", "?202673021262468", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_84_idx;
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA_"+sGXsfl_84_idx;
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO_"+sGXsfl_84_idx;
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS_"+sGXsfl_84_idx;
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE_"+sGXsfl_84_idx;
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_84_fel_idx;
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA_"+sGXsfl_84_fel_idx;
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO_"+sGXsfl_84_fel_idx;
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS_"+sGXsfl_84_fel_idx;
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE_"+sGXsfl_84_fel_idx;
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBH90( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaAlta_Internalname,context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A425PostulacionesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPostulacionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONESESTADO_" + sGXsfl_84_idx;
               cmbPostulacionesEstado.Name = GXCCtl;
               cmbPostulacionesEstado.WebTags = "";
               cmbPostulacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbPostulacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbPostulacionesEstado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
               if ( cmbPostulacionesEstado.ItemCount > 0 )
               {
                  A424PostulacionesEstado = cmbPostulacionesEstado.getValidValue(A424PostulacionesEstado);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionesEstado,(string)cmbPostulacionesEstado_Internalname,StringUtil.RTrim( A424PostulacionesEstado),(short)1,(string)cmbPostulacionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionesEstado.CurrentValue = StringUtil.RTrim( A424PostulacionesEstado);
            AssignProp("", false, cmbPostulacionesEstado_Internalname, "Values", (string)(cmbPostulacionesEstado.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "POSTULACIONESREQSUMINISTROS_" + sGXsfl_84_idx;
            chkPostulacionesReqSuministros.Name = GXCCtl;
            chkPostulacionesReqSuministros.WebTags = "";
            chkPostulacionesReqSuministros.Caption = "";
            AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, !bGXsfl_84_Refreshing);
            chkPostulacionesReqSuministros.CheckedValue = "false";
            A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPostulacionesReqSuministros_Internalname,StringUtil.BoolToStr( A937PostulacionesReqSuministros),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesFechaCierre_Internalname,context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"),context.localUtil.Format( A939PostulacionesFechaCierre, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesFechaCierre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesHoraCierre_Internalname,(string)A940PostulacionesHoraCierre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesHoraCierre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesH92( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCpostulacionesestado.Name = "vCPOSTULACIONESESTADO";
         cmbavCpostulacionesestado.WebTags = "";
         cmbavCpostulacionesestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCpostulacionesestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbavCpostulacionesestado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
         if ( cmbavCpostulacionesestado.ItemCount > 0 )
         {
            AV11cPostulacionesEstado = cmbavCpostulacionesestado.getValidValue(AV11cPostulacionesEstado);
            AssignAttri("", false, "AV11cPostulacionesEstado", AV11cPostulacionesEstado);
         }
         chkavCpostulacionesreqsuministros.Name = "vCPOSTULACIONESREQSUMINISTROS";
         chkavCpostulacionesreqsuministros.WebTags = "";
         chkavCpostulacionesreqsuministros.Caption = context.GetMessage( "Postulaciones Req Suministros", "");
         AssignProp("", false, chkavCpostulacionesreqsuministros_Internalname, "TitleCaption", chkavCpostulacionesreqsuministros.Caption, true);
         chkavCpostulacionesreqsuministros.CheckedValue = "false";
         AV15cPostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( AV15cPostulacionesReqSuministros));
         AssignAttri("", false, "AV15cPostulacionesReqSuministros", AV15cPostulacionesReqSuministros);
         GXCCtl = "POSTULACIONESESTADO_" + sGXsfl_84_idx;
         cmbPostulacionesEstado.Name = GXCCtl;
         cmbPostulacionesEstado.WebTags = "";
         cmbPostulacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPostulacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPostulacionesEstado.addItem("GAN", context.GetMessage( "Ganador", ""), 0);
         if ( cmbPostulacionesEstado.ItemCount > 0 )
         {
            A424PostulacionesEstado = cmbPostulacionesEstado.getValidValue(A424PostulacionesEstado);
         }
         GXCCtl = "POSTULACIONESREQSUMINISTROS_" + sGXsfl_84_idx;
         chkPostulacionesReqSuministros.Name = GXCCtl;
         chkPostulacionesReqSuministros.WebTags = "";
         chkPostulacionesReqSuministros.Caption = "";
         AssignProp("", false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, !bGXsfl_84_Refreshing);
         chkPostulacionesReqSuministros.CheckedValue = "false";
         A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
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
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Req Suministros", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Cierre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora Cierre", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A424PostulacionesEstado)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A937PostulacionesReqSuministros)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A940PostulacionesHoraCierre));
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
         lblLblpostulacionesidfilter_Internalname = "LBLPOSTULACIONESIDFILTER";
         edtavCpostulacionesid_Internalname = "vCPOSTULACIONESID";
         divPostulacionesidfiltercontainer_Internalname = "POSTULACIONESIDFILTERCONTAINER";
         lblLblpostulacionesfechaaltafilter_Internalname = "LBLPOSTULACIONESFECHAALTAFILTER";
         edtavCpostulacionesfechaalta_Internalname = "vCPOSTULACIONESFECHAALTA";
         divPostulacionesfechaaltafiltercontainer_Internalname = "POSTULACIONESFECHAALTAFILTERCONTAINER";
         lblLblpostulacionesestadofilter_Internalname = "LBLPOSTULACIONESESTADOFILTER";
         cmbavCpostulacionesestado_Internalname = "vCPOSTULACIONESESTADO";
         divPostulacionesestadofiltercontainer_Internalname = "POSTULACIONESESTADOFILTERCONTAINER";
         lblLblpostulacionesreqsuministrosfilter_Internalname = "LBLPOSTULACIONESREQSUMINISTROSFILTER";
         chkavCpostulacionesreqsuministros_Internalname = "vCPOSTULACIONESREQSUMINISTROS";
         divPostulacionesreqsuministrosfiltercontainer_Internalname = "POSTULACIONESREQSUMINISTROSFILTERCONTAINER";
         lblLblpostulacionesfechacierrefilter_Internalname = "LBLPOSTULACIONESFECHACIERREFILTER";
         edtavCpostulacionesfechacierre_Internalname = "vCPOSTULACIONESFECHACIERRE";
         divPostulacionesfechacierrefiltercontainer_Internalname = "POSTULACIONESFECHACIERREFILTERCONTAINER";
         lblLblpostulacioneshoracierrefilter_Internalname = "LBLPOSTULACIONESHORACIERREFILTER";
         edtavCpostulacioneshoracierre_Internalname = "vCPOSTULACIONESHORACIERRE";
         divPostulacioneshoracierrefiltercontainer_Internalname = "POSTULACIONESHORACIERREFILTERCONTAINER";
         lblLblpostulacionestipofechafilter_Internalname = "LBLPOSTULACIONESTIPOFECHAFILTER";
         edtavCpostulacionestipofecha_Internalname = "vCPOSTULACIONESTIPOFECHA";
         divPostulacionestipofechafiltercontainer_Internalname = "POSTULACIONESTIPOFECHAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtPostulacionesId_Internalname = "POSTULACIONESID";
         edtPostulacionesFechaAlta_Internalname = "POSTULACIONESFECHAALTA";
         cmbPostulacionesEstado_Internalname = "POSTULACIONESESTADO";
         chkPostulacionesReqSuministros_Internalname = "POSTULACIONESREQSUMINISTROS";
         edtPostulacionesFechaCierre_Internalname = "POSTULACIONESFECHACIERRE";
         edtPostulacionesHoraCierre_Internalname = "POSTULACIONESHORACIERRE";
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
         chkavCpostulacionesreqsuministros.Caption = context.GetMessage( "Postulaciones Req Suministros", "");
         edtPostulacionesHoraCierre_Jsonclick = "";
         edtPostulacionesFechaCierre_Jsonclick = "";
         chkPostulacionesReqSuministros.Caption = "";
         cmbPostulacionesEstado_Jsonclick = "";
         edtPostulacionesFechaAlta_Jsonclick = "";
         edtPostulacionesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtPostulacionesHoraCierre_Enabled = 0;
         edtPostulacionesFechaCierre_Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         cmbPostulacionesEstado.Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         edtavCpostulacionestipofecha_Jsonclick = "";
         edtavCpostulacionestipofecha_Enabled = 1;
         edtavCpostulacionestipofecha_Visible = 1;
         edtavCpostulacioneshoracierre_Jsonclick = "";
         edtavCpostulacioneshoracierre_Enabled = 1;
         edtavCpostulacioneshoracierre_Visible = 1;
         edtavCpostulacionesfechacierre_Jsonclick = "";
         edtavCpostulacionesfechacierre_Enabled = 1;
         chkavCpostulacionesreqsuministros.Enabled = 1;
         chkavCpostulacionesreqsuministros.Visible = 1;
         cmbavCpostulacionesestado_Jsonclick = "";
         cmbavCpostulacionesestado.Visible = 1;
         cmbavCpostulacionesestado.Enabled = 1;
         edtavCpostulacionesfechaalta_Jsonclick = "";
         edtavCpostulacionesfechaalta_Enabled = 1;
         edtavCpostulacionesid_Jsonclick = "";
         edtavCpostulacionesid_Enabled = 1;
         edtavCpostulacionesid_Visible = 1;
         divPostulacionestipofechafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPostulacioneshoracierrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPostulacionesreqsuministrosfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPostulacionesestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPostulacionesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Postulaciones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPostulacionesId',fld:'vCPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPostulacionesFechaAlta',fld:'vCPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCpostulacionesestado'},{av:'AV11cPostulacionesEstado',fld:'vCPOSTULACIONESESTADO',pic:'',type:'char'},{av:'AV16cPostulacionesFechaCierre',fld:'vCPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV17cPostulacionesHoraCierre',fld:'vCPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV18cPostulacionesTipoFecha',fld:'vCPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV15cPostulacionesReqSuministros',fld:'vCPOSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16H91',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPOSTULACIONESIDFILTER.CLICK","{handler:'E11H91',iparms:[{av:'divPostulacionesidfiltercontainer_Class',ctrl:'POSTULACIONESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONESIDFILTER.CLICK",",oparms:[{av:'divPostulacionesidfiltercontainer_Class',ctrl:'POSTULACIONESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpostulacionesid_Visible',ctrl:'vCPOSTULACIONESID',prop:'Visible'}]}");
         setEventMetadata("LBLPOSTULACIONESESTADOFILTER.CLICK","{handler:'E12H91',iparms:[{av:'divPostulacionesestadofiltercontainer_Class',ctrl:'POSTULACIONESESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONESESTADOFILTER.CLICK",",oparms:[{av:'divPostulacionesestadofiltercontainer_Class',ctrl:'POSTULACIONESESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCpostulacionesestado'}]}");
         setEventMetadata("LBLPOSTULACIONESREQSUMINISTROSFILTER.CLICK","{handler:'E13H91',iparms:[{av:'divPostulacionesreqsuministrosfiltercontainer_Class',ctrl:'POSTULACIONESREQSUMINISTROSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONESREQSUMINISTROSFILTER.CLICK",",oparms:[{av:'divPostulacionesreqsuministrosfiltercontainer_Class',ctrl:'POSTULACIONESREQSUMINISTROSFILTERCONTAINER',prop:'Class'},{av:'chkavCpostulacionesreqsuministros.Visible',ctrl:'vCPOSTULACIONESREQSUMINISTROS',prop:'Visible'}]}");
         setEventMetadata("LBLPOSTULACIONESHORACIERREFILTER.CLICK","{handler:'E14H91',iparms:[{av:'divPostulacioneshoracierrefiltercontainer_Class',ctrl:'POSTULACIONESHORACIERREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONESHORACIERREFILTER.CLICK",",oparms:[{av:'divPostulacioneshoracierrefiltercontainer_Class',ctrl:'POSTULACIONESHORACIERREFILTERCONTAINER',prop:'Class'},{av:'edtavCpostulacioneshoracierre_Visible',ctrl:'vCPOSTULACIONESHORACIERRE',prop:'Visible'}]}");
         setEventMetadata("LBLPOSTULACIONESTIPOFECHAFILTER.CLICK","{handler:'E15H91',iparms:[{av:'divPostulacionestipofechafiltercontainer_Class',ctrl:'POSTULACIONESTIPOFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONESTIPOFECHAFILTER.CLICK",",oparms:[{av:'divPostulacionestipofechafiltercontainer_Class',ctrl:'POSTULACIONESTIPOFECHAFILTERCONTAINER',prop:'Class'},{av:'edtavCpostulacionestipofecha_Visible',ctrl:'vCPOSTULACIONESTIPOFECHA',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19H92',iparms:[{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pPostulacionesId',fld:'vPPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPostulacionesId',fld:'vCPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPostulacionesFechaAlta',fld:'vCPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCpostulacionesestado'},{av:'AV11cPostulacionesEstado',fld:'vCPOSTULACIONESESTADO',pic:'',type:'char'},{av:'AV16cPostulacionesFechaCierre',fld:'vCPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV17cPostulacionesHoraCierre',fld:'vCPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV18cPostulacionesTipoFecha',fld:'vCPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV15cPostulacionesReqSuministros',fld:'vCPOSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPostulacionesId',fld:'vCPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPostulacionesFechaAlta',fld:'vCPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCpostulacionesestado'},{av:'AV11cPostulacionesEstado',fld:'vCPOSTULACIONESESTADO',pic:'',type:'char'},{av:'AV16cPostulacionesFechaCierre',fld:'vCPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV17cPostulacionesHoraCierre',fld:'vCPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV18cPostulacionesTipoFecha',fld:'vCPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV15cPostulacionesReqSuministros',fld:'vCPOSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPostulacionesId',fld:'vCPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPostulacionesFechaAlta',fld:'vCPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCpostulacionesestado'},{av:'AV11cPostulacionesEstado',fld:'vCPOSTULACIONESESTADO',pic:'',type:'char'},{av:'AV16cPostulacionesFechaCierre',fld:'vCPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV17cPostulacionesHoraCierre',fld:'vCPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV18cPostulacionesTipoFecha',fld:'vCPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV15cPostulacionesReqSuministros',fld:'vCPOSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPostulacionesId',fld:'vCPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPostulacionesFechaAlta',fld:'vCPOSTULACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavCpostulacionesestado'},{av:'AV11cPostulacionesEstado',fld:'vCPOSTULACIONESESTADO',pic:'',type:'char'},{av:'AV16cPostulacionesFechaCierre',fld:'vCPOSTULACIONESFECHACIERRE',pic:'',type:'date'},{av:'AV17cPostulacionesHoraCierre',fld:'vCPOSTULACIONESHORACIERRE',pic:'',type:'svchar'},{av:'AV18cPostulacionesTipoFecha',fld:'vCPOSTULACIONESTIPOFECHA',pic:'',type:'svchar'},{av:'AV15cPostulacionesReqSuministros',fld:'vCPOSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPOSTULACIONESFECHAALTA","{handler:'Validv_Cpostulacionesfechaalta',iparms:[]");
         setEventMetadata("VALIDV_CPOSTULACIONESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALIDV_CPOSTULACIONESFECHACIERRE","{handler:'Validv_Cpostulacionesfechacierre',iparms:[]");
         setEventMetadata("VALIDV_CPOSTULACIONESFECHACIERRE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Postulacioneshoracierre',iparms:[]");
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
         AV10cPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV11cPostulacionesEstado = "";
         AV16cPostulacionesFechaCierre = DateTime.MinValue;
         AV17cPostulacionesHoraCierre = "";
         AV18cPostulacionesTipoFecha = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblpostulacionesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpostulacionesfechaaltafilter_Jsonclick = "";
         lblLblpostulacionesestadofilter_Jsonclick = "";
         lblLblpostulacionesreqsuministrosfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblpostulacionesfechacierrefilter_Jsonclick = "";
         lblLblpostulacioneshoracierrefilter_Jsonclick = "";
         lblLblpostulacionestipofechafilter_Jsonclick = "";
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
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A424PostulacionesEstado = "";
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         lV11cPostulacionesEstado = "";
         lV17cPostulacionesHoraCierre = "";
         lV18cPostulacionesTipoFecha = "";
         A941PostulacionesTipoFecha = "";
         H00H92_A941PostulacionesTipoFecha = new string[] {""} ;
         H00H92_A940PostulacionesHoraCierre = new string[] {""} ;
         H00H92_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         H00H92_A937PostulacionesReqSuministros = new bool[] {false} ;
         H00H92_A424PostulacionesEstado = new string[] {""} ;
         H00H92_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00H92_A422PostulacionesId = new long[1] ;
         H00H93_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03i0__default(),
            new Object[][] {
                new Object[] {
               H00H92_A941PostulacionesTipoFecha, H00H92_A940PostulacionesHoraCierre, H00H92_A939PostulacionesFechaCierre, H00H92_A937PostulacionesReqSuministros, H00H92_A424PostulacionesEstado, H00H92_A425PostulacionesFechaAlta, H00H92_A422PostulacionesId
               }
               , new Object[] {
               H00H93_AGRID1_nRecordCount
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
      private int edtavCpostulacionesid_Enabled ;
      private int edtavCpostulacionesid_Visible ;
      private int edtavCpostulacionesfechaalta_Enabled ;
      private int edtavCpostulacionesfechacierre_Enabled ;
      private int edtavCpostulacioneshoracierre_Visible ;
      private int edtavCpostulacioneshoracierre_Enabled ;
      private int edtavCpostulacionestipofecha_Visible ;
      private int edtavCpostulacionestipofecha_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtPostulacionesId_Enabled ;
      private int edtPostulacionesFechaAlta_Enabled ;
      private int edtPostulacionesFechaCierre_Enabled ;
      private int edtPostulacionesHoraCierre_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pPostulacionesId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cPostulacionesId ;
      private long A422PostulacionesId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divPostulacionesidfiltercontainer_Class ;
      private string divPostulacionesestadofiltercontainer_Class ;
      private string divPostulacionesreqsuministrosfiltercontainer_Class ;
      private string divPostulacioneshoracierrefiltercontainer_Class ;
      private string divPostulacionestipofechafiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV11cPostulacionesEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divPostulacionesidfiltercontainer_Internalname ;
      private string lblLblpostulacionesidfilter_Internalname ;
      private string lblLblpostulacionesidfilter_Jsonclick ;
      private string edtavCpostulacionesid_Internalname ;
      private string TempTags ;
      private string edtavCpostulacionesid_Jsonclick ;
      private string divPostulacionesfechaaltafiltercontainer_Internalname ;
      private string lblLblpostulacionesfechaaltafilter_Internalname ;
      private string lblLblpostulacionesfechaaltafilter_Jsonclick ;
      private string edtavCpostulacionesfechaalta_Internalname ;
      private string edtavCpostulacionesfechaalta_Jsonclick ;
      private string divPostulacionesestadofiltercontainer_Internalname ;
      private string lblLblpostulacionesestadofilter_Internalname ;
      private string lblLblpostulacionesestadofilter_Jsonclick ;
      private string cmbavCpostulacionesestado_Internalname ;
      private string cmbavCpostulacionesestado_Jsonclick ;
      private string divPostulacionesreqsuministrosfiltercontainer_Internalname ;
      private string lblLblpostulacionesreqsuministrosfilter_Internalname ;
      private string lblLblpostulacionesreqsuministrosfilter_Jsonclick ;
      private string chkavCpostulacionesreqsuministros_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divPostulacionesfechacierrefiltercontainer_Internalname ;
      private string lblLblpostulacionesfechacierrefilter_Internalname ;
      private string lblLblpostulacionesfechacierrefilter_Jsonclick ;
      private string edtavCpostulacionesfechacierre_Internalname ;
      private string edtavCpostulacionesfechacierre_Jsonclick ;
      private string divPostulacioneshoracierrefiltercontainer_Internalname ;
      private string lblLblpostulacioneshoracierrefilter_Internalname ;
      private string lblLblpostulacioneshoracierrefilter_Jsonclick ;
      private string edtavCpostulacioneshoracierre_Internalname ;
      private string edtavCpostulacioneshoracierre_Jsonclick ;
      private string divPostulacionestipofechafiltercontainer_Internalname ;
      private string lblLblpostulacionestipofechafilter_Internalname ;
      private string lblLblpostulacionestipofechafilter_Jsonclick ;
      private string edtavCpostulacionestipofecha_Internalname ;
      private string edtavCpostulacionestipofecha_Jsonclick ;
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
      private string edtPostulacionesId_Internalname ;
      private string edtPostulacionesFechaAlta_Internalname ;
      private string cmbPostulacionesEstado_Internalname ;
      private string A424PostulacionesEstado ;
      private string chkPostulacionesReqSuministros_Internalname ;
      private string edtPostulacionesFechaCierre_Internalname ;
      private string edtPostulacionesHoraCierre_Internalname ;
      private string lV11cPostulacionesEstado ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtPostulacionesId_Jsonclick ;
      private string edtPostulacionesFechaAlta_Jsonclick ;
      private string GXCCtl ;
      private string cmbPostulacionesEstado_Jsonclick ;
      private string edtPostulacionesFechaCierre_Jsonclick ;
      private string edtPostulacionesHoraCierre_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10cPostulacionesFechaAlta ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime AV16cPostulacionesFechaCierre ;
      private DateTime A939PostulacionesFechaCierre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15cPostulacionesReqSuministros ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool A937PostulacionesReqSuministros ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17cPostulacionesHoraCierre ;
      private string AV18cPostulacionesTipoFecha ;
      private string AV19Linkselection_GXI ;
      private string A940PostulacionesHoraCierre ;
      private string lV17cPostulacionesHoraCierre ;
      private string lV18cPostulacionesTipoFecha ;
      private string A941PostulacionesTipoFecha ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCpostulacionesestado ;
      private GXCheckbox chkavCpostulacionesreqsuministros ;
      private GXCombobox cmbPostulacionesEstado ;
      private GXCheckbox chkPostulacionesReqSuministros ;
      private IDataStoreProvider pr_default ;
      private string[] H00H92_A941PostulacionesTipoFecha ;
      private string[] H00H92_A940PostulacionesHoraCierre ;
      private DateTime[] H00H92_A939PostulacionesFechaCierre ;
      private bool[] H00H92_A937PostulacionesReqSuministros ;
      private string[] H00H92_A424PostulacionesEstado ;
      private DateTime[] H00H92_A425PostulacionesFechaAlta ;
      private long[] H00H92_A422PostulacionesId ;
      private long[] H00H93_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pPostulacionesId ;
   }

   public class gx03i0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00H92( IGxContext context ,
                                             DateTime AV10cPostulacionesFechaAlta ,
                                             string AV11cPostulacionesEstado ,
                                             bool AV15cPostulacionesReqSuministros ,
                                             DateTime AV16cPostulacionesFechaCierre ,
                                             string AV17cPostulacionesHoraCierre ,
                                             string AV18cPostulacionesTipoFecha ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             string A424PostulacionesEstado ,
                                             bool A937PostulacionesReqSuministros ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             long AV6cPostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PostulacionesTipoFecha], [PostulacionesHoraCierre], [PostulacionesFechaCierre], [PostulacionesReqSuministros], [PostulacionesEstado], [PostulacionesFechaAlta], [PostulacionesId]";
         sFromString = " FROM [Postulaciones]";
         sOrderString = "";
         AddWhere(sWhereString, "([PostulacionesId] >= @AV6cPostulacionesId)");
         if ( ! (DateTime.MinValue==AV10cPostulacionesFechaAlta) )
         {
            AddWhere(sWhereString, "([PostulacionesFechaAlta] >= @AV10cPostulacionesFechaAlta)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cPostulacionesEstado)) )
         {
            AddWhere(sWhereString, "([PostulacionesEstado] like @lV11cPostulacionesEstado)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (false==AV15cPostulacionesReqSuministros) )
         {
            AddWhere(sWhereString, "([PostulacionesReqSuministros] >= @AV15cPostulacionesReqSuministros)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV16cPostulacionesFechaCierre) )
         {
            AddWhere(sWhereString, "([PostulacionesFechaCierre] >= @AV16cPostulacionesFechaCierre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17cPostulacionesHoraCierre)) )
         {
            AddWhere(sWhereString, "([PostulacionesHoraCierre] like @lV17cPostulacionesHoraCierre)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18cPostulacionesTipoFecha)) )
         {
            AddWhere(sWhereString, "([PostulacionesTipoFecha] like @lV18cPostulacionesTipoFecha)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [PostulacionesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00H93( IGxContext context ,
                                             DateTime AV10cPostulacionesFechaAlta ,
                                             string AV11cPostulacionesEstado ,
                                             bool AV15cPostulacionesReqSuministros ,
                                             DateTime AV16cPostulacionesFechaCierre ,
                                             string AV17cPostulacionesHoraCierre ,
                                             string AV18cPostulacionesTipoFecha ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             string A424PostulacionesEstado ,
                                             bool A937PostulacionesReqSuministros ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             long AV6cPostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Postulaciones]";
         AddWhere(sWhereString, "([PostulacionesId] >= @AV6cPostulacionesId)");
         if ( ! (DateTime.MinValue==AV10cPostulacionesFechaAlta) )
         {
            AddWhere(sWhereString, "([PostulacionesFechaAlta] >= @AV10cPostulacionesFechaAlta)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cPostulacionesEstado)) )
         {
            AddWhere(sWhereString, "([PostulacionesEstado] like @lV11cPostulacionesEstado)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (false==AV15cPostulacionesReqSuministros) )
         {
            AddWhere(sWhereString, "([PostulacionesReqSuministros] >= @AV15cPostulacionesReqSuministros)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV16cPostulacionesFechaCierre) )
         {
            AddWhere(sWhereString, "([PostulacionesFechaCierre] >= @AV16cPostulacionesFechaCierre)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17cPostulacionesHoraCierre)) )
         {
            AddWhere(sWhereString, "([PostulacionesHoraCierre] like @lV17cPostulacionesHoraCierre)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18cPostulacionesTipoFecha)) )
         {
            AddWhere(sWhereString, "([PostulacionesTipoFecha] like @lV18cPostulacionesTipoFecha)");
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
                     return conditional_H00H92(context, (DateTime)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00H93(context, (DateTime)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00H92;
          prmH00H92 = new Object[] {
          new ParDef("@AV6cPostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV10cPostulacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@lV11cPostulacionesEstado",GXType.NChar,3,0) ,
          new ParDef("@AV15cPostulacionesReqSuministros",GXType.Boolean,4,0) ,
          new ParDef("@AV16cPostulacionesFechaCierre",GXType.Date,8,0) ,
          new ParDef("@lV17cPostulacionesHoraCierre",GXType.NVarChar,8,5) ,
          new ParDef("@lV18cPostulacionesTipoFecha",GXType.NVarChar,10,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00H93;
          prmH00H93 = new Object[] {
          new ParDef("@AV6cPostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV10cPostulacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@lV11cPostulacionesEstado",GXType.NChar,3,0) ,
          new ParDef("@AV15cPostulacionesReqSuministros",GXType.Boolean,4,0) ,
          new ParDef("@AV16cPostulacionesFechaCierre",GXType.Date,8,0) ,
          new ParDef("@lV17cPostulacionesHoraCierre",GXType.NVarChar,8,5) ,
          new ParDef("@lV18cPostulacionesTipoFecha",GXType.NVarChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00H92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00H92,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00H93", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00H93,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

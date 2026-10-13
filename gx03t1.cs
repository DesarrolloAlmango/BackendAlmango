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
   public class gx03t1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03t1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03t1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pPostulacionesId ,
                           out string aP1_pProfesionalesId )
      {
         this.AV7pPostulacionesId = aP0_pPostulacionesId;
         this.AV8pProfesionalesId = "" ;
         ExecutePrivate();
         aP1_pProfesionalesId=this.AV8pProfesionalesId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCpostulacionprofesionalestado = new GXCombobox();
         cmbPostulacionProfesionalEstado = new GXCombobox();
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
               AV7pPostulacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7pPostulacionesId", StringUtil.LTrimStr( (decimal)(AV7pPostulacionesId), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8pProfesionalesId = GetPar( "pProfesionalesId");
                  AssignAttri("", false, "AV8pProfesionalesId", AV8pProfesionalesId);
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
         AV6cProfesionalesId = GetPar( "cProfesionalesId");
         cmbavCpostulacionprofesionalestado.FromJSonString( GetNextPar( ));
         AV10cPostulacionProfesionalEstado = GetPar( "cPostulacionProfesionalEstado");
         AV11cPostulacionProfesionalFechaA = context.localUtil.ParseDTimeParm( GetPar( "cPostulacionProfesionalFechaA"));
         AV12cPostulacionProfesionalFechaT = context.localUtil.ParseDateParm( GetPar( "cPostulacionProfesionalFechaT"));
         AV13cPostulacionProfesionalTurnoT = GetPar( "cPostulacionProfesionalTurnoT");
         AV14cPostulacionProfesionalPrecio = NumberUtil.Val( GetPar( "cPostulacionProfesionalPrecio"), ".");
         AV7pPostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pPostulacionesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, AV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, AV7pPostulacionesId) ;
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
         PAK42( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTK42( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03t1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV7pPostulacionesId,18,0)),UrlEncode(StringUtil.RTrim(AV8pProfesionalesId))}, new string[] {"pPostulacionesId","pProfesionalesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESID", StringUtil.RTrim( AV6cProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONPROFESIONALESTADO", StringUtil.RTrim( AV10cPostulacionProfesionalEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONPROFESIONALFECHAA", context.localUtil.TToC( AV11cPostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONPROFESIONALFECHAT", context.localUtil.Format(AV12cPostulacionProfesionalFechaT, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONPROFESIONALTURNOT", StringUtil.RTrim( AV13cPostulacionProfesionalTurnoT));
         GxWebStd.gx_hidden_field( context, "GXH_vCPOSTULACIONPROFESIONALPRECIO", StringUtil.LTrim( StringUtil.NToC( AV14cPostulacionProfesionalPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7pPostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPROFESIONALESID", StringUtil.RTrim( AV8pProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESIDFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionprofesionalestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALTURNOTFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionprofesionalturnotfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "POSTULACIONPROFESIONALPRECIOFILTERCONTAINER_Class", StringUtil.RTrim( divPostulacionprofesionalpreciofiltercontainer_Class));
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
            WEK42( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTK42( ) ;
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
         return formatLink("gx03t1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV7pPostulacionesId,18,0)),UrlEncode(StringUtil.RTrim(AV8pProfesionalesId))}, new string[] {"pPostulacionesId","pProfesionalesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03T1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Profesionales", "") ;
      }

      protected void WBK40( )
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
            GxWebStd.gx_div_start( context, divProfesionalesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesidfilter_Internalname, context.GetMessage( "Identidad", ""), "", "", lblLblprofesionalesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11k41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03T1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesid_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesid_Internalname, StringUtil.RTrim( AV6cProfesionalesId), StringUtil.RTrim( context.localUtil.Format( AV6cProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavCprofesionalesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesid_Visible, edtavCprofesionalesid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03T1.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionprofesionalestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionprofesionalestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionprofesionalestadofilter_Internalname, context.GetMessage( "Postulacion Profesional Estado", ""), "", "", lblLblpostulacionprofesionalestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12k41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03T1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCpostulacionprofesionalestado_Internalname, context.GetMessage( "Postulacion Profesional Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCpostulacionprofesionalestado, cmbavCpostulacionprofesionalestado_Internalname, StringUtil.RTrim( AV10cPostulacionProfesionalEstado), 1, cmbavCpostulacionprofesionalestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCpostulacionprofesionalestado.Visible, cmbavCpostulacionprofesionalestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx03T1.htm");
            cmbavCpostulacionprofesionalestado.CurrentValue = StringUtil.RTrim( AV10cPostulacionProfesionalEstado);
            AssignProp("", false, cmbavCpostulacionprofesionalestado_Internalname, "Values", (string)(cmbavCpostulacionprofesionalestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divPostulacionprofesionalfechaafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionprofesionalfechaafilter_Internalname, context.GetMessage( "Postulacion Profesional Fecha A", ""), "", "", lblLblpostulacionprofesionalfechaafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03T1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionprofesionalfechaa_Internalname, context.GetMessage( "Postulacion Profesional Fecha A", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpostulacionprofesionalfechaa_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionprofesionalfechaa_Internalname, context.localUtil.TToC( AV11cPostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV11cPostulacionProfesionalFechaA, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionprofesionalfechaa_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpostulacionprofesionalfechaa_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03T1.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionprofesionalfechatfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionprofesionalfechatfilter_Internalname, context.GetMessage( "Postulacion Profesional Fecha T", ""), "", "", lblLblpostulacionprofesionalfechatfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03T1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionprofesionalfechat_Internalname, context.GetMessage( "Postulacion Profesional Fecha T", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpostulacionprofesionalfechat_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionprofesionalfechat_Internalname, context.localUtil.Format(AV12cPostulacionProfesionalFechaT, "99/99/99"), context.localUtil.Format( AV12cPostulacionProfesionalFechaT, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionprofesionalfechat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpostulacionprofesionalfechat_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03T1.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionprofesionalturnotfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionprofesionalturnotfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionprofesionalturnotfilter_Internalname, context.GetMessage( "Postulacion Profesional Turno T", ""), "", "", lblLblpostulacionprofesionalturnotfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13k41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03T1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionprofesionalturnot_Internalname, context.GetMessage( "Postulacion Profesional Turno T", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionprofesionalturnot_Internalname, StringUtil.RTrim( AV13cPostulacionProfesionalTurnoT), StringUtil.RTrim( context.localUtil.Format( AV13cPostulacionProfesionalTurnoT, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionprofesionalturnot_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpostulacionprofesionalturnot_Visible, edtavCpostulacionprofesionalturnot_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03T1.htm");
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
            GxWebStd.gx_div_start( context, divPostulacionprofesionalpreciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPostulacionprofesionalpreciofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpostulacionprofesionalpreciofilter_Internalname, context.GetMessage( "Postulacion Profesional Precio", ""), "", "", lblLblpostulacionprofesionalpreciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14k41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03T1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpostulacionprofesionalprecio_Internalname, context.GetMessage( "Postulacion Profesional Precio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpostulacionprofesionalprecio_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14cPostulacionProfesionalPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCpostulacionprofesionalprecio_Enabled!=0) ? context.localUtil.Format( AV14cPostulacionProfesionalPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV14cPostulacionProfesionalPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpostulacionprofesionalprecio_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpostulacionprofesionalprecio_Visible, edtavCpostulacionprofesionalprecio_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03T1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e15k41_client"+"'", TempTags, "", 2, "HLP_Gx03T1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03T1.htm");
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

      protected void STARTK42( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPK40( ) ;
      }

      protected void WSK42( )
      {
         STARTK42( ) ;
         EVTK42( ) ;
      }

      protected void EVTK42( )
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
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              cmbPostulacionProfesionalEstado.Name = cmbPostulacionProfesionalEstado_Internalname;
                              cmbPostulacionProfesionalEstado.CurrentValue = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
                              A956PostulacionProfesionalEstado = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
                              A957PostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( edtPostulacionProfesionalFechaA_Internalname), 0);
                              A958PostulacionProfesionalFechaT = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionProfesionalFechaT_Internalname), 0));
                              A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16K42 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17K42 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cprofesionalesid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESID"), AV6cProfesionalesId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionprofesionalestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONPROFESIONALESTADO"), AV10cPostulacionProfesionalEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionprofesionalfechaa Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPOSTULACIONPROFESIONALFECHAA"), 0) != AV11cPostulacionProfesionalFechaA )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionprofesionalfechat Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPOSTULACIONPROFESIONALFECHAT"), 0) != AV12cPostulacionProfesionalFechaT )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionprofesionalturnot Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONPROFESIONALTURNOT"), AV13cPostulacionProfesionalTurnoT) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpostulacionprofesionalprecio Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPOSTULACIONPROFESIONALPRECIO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV14cPostulacionProfesionalPrecio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18K42 ();
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

      protected void WEK42( )
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

      protected void PAK42( )
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
                                        string AV6cProfesionalesId ,
                                        string AV10cPostulacionProfesionalEstado ,
                                        DateTime AV11cPostulacionProfesionalFechaA ,
                                        DateTime AV12cPostulacionProfesionalFechaT ,
                                        string AV13cPostulacionProfesionalTurnoT ,
                                        decimal AV14cPostulacionProfesionalPrecio ,
                                        long AV7pPostulacionesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFK42( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
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
         if ( cmbavCpostulacionprofesionalestado.ItemCount > 0 )
         {
            AV10cPostulacionProfesionalEstado = cmbavCpostulacionprofesionalestado.getValidValue(AV10cPostulacionProfesionalEstado);
            AssignAttri("", false, "AV10cPostulacionProfesionalEstado", AV10cPostulacionProfesionalEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCpostulacionprofesionalestado.CurrentValue = StringUtil.RTrim( AV10cPostulacionProfesionalEstado);
            AssignProp("", false, cmbavCpostulacionprofesionalestado_Internalname, "Values", cmbavCpostulacionprofesionalestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFK42( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFK42( )
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
                                                 AV10cPostulacionProfesionalEstado ,
                                                 AV11cPostulacionProfesionalFechaA ,
                                                 AV12cPostulacionProfesionalFechaT ,
                                                 AV13cPostulacionProfesionalTurnoT ,
                                                 AV14cPostulacionProfesionalPrecio ,
                                                 A956PostulacionProfesionalEstado ,
                                                 A957PostulacionProfesionalFechaA ,
                                                 A958PostulacionProfesionalFechaT ,
                                                 A959PostulacionProfesionalTurnoT ,
                                                 A982PostulacionProfesionalPrecio ,
                                                 A120ProfesionalesId ,
                                                 AV6cProfesionalesId ,
                                                 AV7pPostulacionesId ,
                                                 A422PostulacionesId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV6cProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV6cProfesionalesId), 20, "%");
            lV10cPostulacionProfesionalEstado = StringUtil.PadR( StringUtil.RTrim( AV10cPostulacionProfesionalEstado), 3, "%");
            lV13cPostulacionProfesionalTurnoT = StringUtil.PadR( StringUtil.RTrim( AV13cPostulacionProfesionalTurnoT), 1, "%");
            /* Using cursor H00K42 */
            pr_default.execute(0, new Object[] {AV7pPostulacionesId, lV6cProfesionalesId, lV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, lV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A982PostulacionProfesionalPrecio = H00K42_A982PostulacionProfesionalPrecio[0];
               n982PostulacionProfesionalPrecio = H00K42_n982PostulacionProfesionalPrecio[0];
               A959PostulacionProfesionalTurnoT = H00K42_A959PostulacionProfesionalTurnoT[0];
               A422PostulacionesId = H00K42_A422PostulacionesId[0];
               A958PostulacionProfesionalFechaT = H00K42_A958PostulacionProfesionalFechaT[0];
               A957PostulacionProfesionalFechaA = H00K42_A957PostulacionProfesionalFechaA[0];
               A956PostulacionProfesionalEstado = H00K42_A956PostulacionProfesionalEstado[0];
               A120ProfesionalesId = H00K42_A120ProfesionalesId[0];
               /* Execute user event: Load */
               E17K42 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBK40( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesK42( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
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
                                              AV10cPostulacionProfesionalEstado ,
                                              AV11cPostulacionProfesionalFechaA ,
                                              AV12cPostulacionProfesionalFechaT ,
                                              AV13cPostulacionProfesionalTurnoT ,
                                              AV14cPostulacionProfesionalPrecio ,
                                              A956PostulacionProfesionalEstado ,
                                              A957PostulacionProfesionalFechaA ,
                                              A958PostulacionProfesionalFechaT ,
                                              A959PostulacionProfesionalTurnoT ,
                                              A982PostulacionProfesionalPrecio ,
                                              A120ProfesionalesId ,
                                              AV6cProfesionalesId ,
                                              AV7pPostulacionesId ,
                                              A422PostulacionesId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV6cProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV6cProfesionalesId), 20, "%");
         lV10cPostulacionProfesionalEstado = StringUtil.PadR( StringUtil.RTrim( AV10cPostulacionProfesionalEstado), 3, "%");
         lV13cPostulacionProfesionalTurnoT = StringUtil.PadR( StringUtil.RTrim( AV13cPostulacionProfesionalTurnoT), 1, "%");
         /* Using cursor H00K43 */
         pr_default.execute(1, new Object[] {AV7pPostulacionesId, lV6cProfesionalesId, lV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, lV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio});
         GRID1_nRecordCount = H00K43_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, AV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, AV7pPostulacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, AV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, AV7pPostulacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, AV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, AV7pPostulacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, AV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, AV7pPostulacionesId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProfesionalesId, AV10cPostulacionProfesionalEstado, AV11cPostulacionProfesionalFechaA, AV12cPostulacionProfesionalFechaT, AV13cPostulacionProfesionalTurnoT, AV14cPostulacionProfesionalPrecio, AV7pPostulacionesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtProfesionalesId_Enabled = 0;
         cmbPostulacionProfesionalEstado.Enabled = 0;
         edtPostulacionProfesionalFechaA_Enabled = 0;
         edtPostulacionProfesionalFechaT_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPK40( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16K42 ();
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
            AV6cProfesionalesId = cgiGet( edtavCprofesionalesid_Internalname);
            AssignAttri("", false, "AV6cProfesionalesId", AV6cProfesionalesId);
            cmbavCpostulacionprofesionalestado.Name = cmbavCpostulacionprofesionalestado_Internalname;
            cmbavCpostulacionprofesionalestado.CurrentValue = cgiGet( cmbavCpostulacionprofesionalestado_Internalname);
            AV10cPostulacionProfesionalEstado = cgiGet( cmbavCpostulacionprofesionalestado_Internalname);
            AssignAttri("", false, "AV10cPostulacionProfesionalEstado", AV10cPostulacionProfesionalEstado);
            if ( context.localUtil.VCDateTime( cgiGet( edtavCpostulacionprofesionalfechaa_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Postulacion Profesional Fecha A", "")}), 1, "vCPOSTULACIONPROFESIONALFECHAA");
               GX_FocusControl = edtavCpostulacionprofesionalfechaa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cPostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV11cPostulacionProfesionalFechaA", context.localUtil.TToC( AV11cPostulacionProfesionalFechaA, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV11cPostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( edtavCpostulacionprofesionalfechaa_Internalname));
               AssignAttri("", false, "AV11cPostulacionProfesionalFechaA", context.localUtil.TToC( AV11cPostulacionProfesionalFechaA, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpostulacionprofesionalfechat_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Postulacion Profesional Fecha T", "")}), 1, "vCPOSTULACIONPROFESIONALFECHAT");
               GX_FocusControl = edtavCpostulacionprofesionalfechat_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cPostulacionProfesionalFechaT = DateTime.MinValue;
               AssignAttri("", false, "AV12cPostulacionProfesionalFechaT", context.localUtil.Format(AV12cPostulacionProfesionalFechaT, "99/99/99"));
            }
            else
            {
               AV12cPostulacionProfesionalFechaT = context.localUtil.CToD( cgiGet( edtavCpostulacionprofesionalfechat_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV12cPostulacionProfesionalFechaT", context.localUtil.Format(AV12cPostulacionProfesionalFechaT, "99/99/99"));
            }
            AV13cPostulacionProfesionalTurnoT = cgiGet( edtavCpostulacionprofesionalturnot_Internalname);
            AssignAttri("", false, "AV13cPostulacionProfesionalTurnoT", AV13cPostulacionProfesionalTurnoT);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpostulacionprofesionalprecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpostulacionprofesionalprecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPOSTULACIONPROFESIONALPRECIO");
               GX_FocusControl = edtavCpostulacionprofesionalprecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14cPostulacionProfesionalPrecio = 0;
               AssignAttri("", false, "AV14cPostulacionProfesionalPrecio", StringUtil.LTrimStr( AV14cPostulacionProfesionalPrecio, 18, 2));
            }
            else
            {
               AV14cPostulacionProfesionalPrecio = context.localUtil.CToN( cgiGet( edtavCpostulacionprofesionalprecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV14cPostulacionProfesionalPrecio", StringUtil.LTrimStr( AV14cPostulacionProfesionalPrecio, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESID"), AV6cProfesionalesId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONPROFESIONALESTADO"), AV10cPostulacionProfesionalEstado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCPOSTULACIONPROFESIONALFECHAA")) != AV11cPostulacionProfesionalFechaA )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPOSTULACIONPROFESIONALFECHAT"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV12cPostulacionProfesionalFechaT ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPOSTULACIONPROFESIONALTURNOT"), AV13cPostulacionProfesionalTurnoT) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPOSTULACIONPROFESIONALPRECIO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV14cPostulacionProfesionalPrecio )
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
         E16K42 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16K42( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV9ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E17K42( )
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
         E18K42 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18K42( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8pProfesionalesId = A120ProfesionalesId;
         AssignAttri("", false, "AV8pProfesionalesId", AV8pProfesionalesId);
         context.setWebReturnParms(new Object[] {(string)AV8pProfesionalesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV8pProfesionalesId"});
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
         AV7pPostulacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV7pPostulacionesId", StringUtil.LTrimStr( (decimal)(AV7pPostulacionesId), 18, 0));
         AV8pProfesionalesId = (string)getParm(obj,1);
         AssignAttri("", false, "AV8pProfesionalesId", AV8pProfesionalesId);
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
         PAK42( ) ;
         WSK42( ) ;
         WEK42( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932012176", true, true, false);
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
         context.AddJavascriptSource("gx03t1.js", "?2026932012176", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_74_idx;
         cmbPostulacionProfesionalEstado_Internalname = "POSTULACIONPROFESIONALESTADO_"+sGXsfl_74_idx;
         edtPostulacionProfesionalFechaA_Internalname = "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_74_idx;
         edtPostulacionProfesionalFechaT_Internalname = "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_74_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_74_fel_idx;
         cmbPostulacionProfesionalEstado_Internalname = "POSTULACIONPROFESIONALESTADO_"+sGXsfl_74_fel_idx;
         edtPostulacionProfesionalFechaA_Internalname = "POSTULACIONPROFESIONALFECHAA_"+sGXsfl_74_fel_idx;
         edtPostulacionProfesionalFechaT_Internalname = "POSTULACIONPROFESIONALFECHAT_"+sGXsfl_74_fel_idx;
         edtPostulacionesId_Internalname = "POSTULACIONESID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBK40( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A120ProfesionalesId))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPostulacionProfesionalEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_74_idx;
               cmbPostulacionProfesionalEstado.Name = GXCCtl;
               cmbPostulacionProfesionalEstado.WebTags = "";
               cmbPostulacionProfesionalEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbPostulacionProfesionalEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbPostulacionProfesionalEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbPostulacionProfesionalEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbPostulacionProfesionalEstado.ItemCount > 0 )
               {
                  A956PostulacionProfesionalEstado = cmbPostulacionProfesionalEstado.getValidValue(A956PostulacionProfesionalEstado);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalEstado,(string)cmbPostulacionProfesionalEstado_Internalname,StringUtil.RTrim( A956PostulacionProfesionalEstado),(short)1,(string)cmbPostulacionProfesionalEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"DescriptionAttribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionProfesionalEstado.CurrentValue = StringUtil.RTrim( A956PostulacionProfesionalEstado);
            AssignProp("", false, cmbPostulacionProfesionalEstado_Internalname, "Values", (string)(cmbPostulacionProfesionalEstado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalFechaA_Internalname,context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A957PostulacionProfesionalFechaA, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalFechaA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalFechaT_Internalname,context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99"),context.localUtil.Format( A958PostulacionProfesionalFechaT, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalFechaT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesK42( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCpostulacionprofesionalestado.Name = "vCPOSTULACIONPROFESIONALESTADO";
         cmbavCpostulacionprofesionalestado.WebTags = "";
         cmbavCpostulacionprofesionalestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCpostulacionprofesionalestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbavCpostulacionprofesionalestado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbavCpostulacionprofesionalestado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbavCpostulacionprofesionalestado.ItemCount > 0 )
         {
            AV10cPostulacionProfesionalEstado = cmbavCpostulacionprofesionalestado.getValidValue(AV10cPostulacionProfesionalEstado);
            AssignAttri("", false, "AV10cPostulacionProfesionalEstado", AV10cPostulacionProfesionalEstado);
         }
         GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_74_idx;
         cmbPostulacionProfesionalEstado.Name = GXCCtl;
         cmbPostulacionProfesionalEstado.WebTags = "";
         cmbPostulacionProfesionalEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbPostulacionProfesionalEstado.ItemCount > 0 )
         {
            A956PostulacionProfesionalEstado = cmbPostulacionProfesionalEstado.getValidValue(A956PostulacionProfesionalEstado);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Profesional Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha T", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Postulaciones Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A956PostulacionProfesionalEstado)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbPostulacionProfesionalEstado.Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, ".", ""))));
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
         lblLblprofesionalesidfilter_Internalname = "LBLPROFESIONALESIDFILTER";
         edtavCprofesionalesid_Internalname = "vCPROFESIONALESID";
         divProfesionalesidfiltercontainer_Internalname = "PROFESIONALESIDFILTERCONTAINER";
         lblLblpostulacionprofesionalestadofilter_Internalname = "LBLPOSTULACIONPROFESIONALESTADOFILTER";
         cmbavCpostulacionprofesionalestado_Internalname = "vCPOSTULACIONPROFESIONALESTADO";
         divPostulacionprofesionalestadofiltercontainer_Internalname = "POSTULACIONPROFESIONALESTADOFILTERCONTAINER";
         lblLblpostulacionprofesionalfechaafilter_Internalname = "LBLPOSTULACIONPROFESIONALFECHAAFILTER";
         edtavCpostulacionprofesionalfechaa_Internalname = "vCPOSTULACIONPROFESIONALFECHAA";
         divPostulacionprofesionalfechaafiltercontainer_Internalname = "POSTULACIONPROFESIONALFECHAAFILTERCONTAINER";
         lblLblpostulacionprofesionalfechatfilter_Internalname = "LBLPOSTULACIONPROFESIONALFECHATFILTER";
         edtavCpostulacionprofesionalfechat_Internalname = "vCPOSTULACIONPROFESIONALFECHAT";
         divPostulacionprofesionalfechatfiltercontainer_Internalname = "POSTULACIONPROFESIONALFECHATFILTERCONTAINER";
         lblLblpostulacionprofesionalturnotfilter_Internalname = "LBLPOSTULACIONPROFESIONALTURNOTFILTER";
         edtavCpostulacionprofesionalturnot_Internalname = "vCPOSTULACIONPROFESIONALTURNOT";
         divPostulacionprofesionalturnotfiltercontainer_Internalname = "POSTULACIONPROFESIONALTURNOTFILTERCONTAINER";
         lblLblpostulacionprofesionalpreciofilter_Internalname = "LBLPOSTULACIONPROFESIONALPRECIOFILTER";
         edtavCpostulacionprofesionalprecio_Internalname = "vCPOSTULACIONPROFESIONALPRECIO";
         divPostulacionprofesionalpreciofiltercontainer_Internalname = "POSTULACIONPROFESIONALPRECIOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         cmbPostulacionProfesionalEstado_Internalname = "POSTULACIONPROFESIONALESTADO";
         edtPostulacionProfesionalFechaA_Internalname = "POSTULACIONPROFESIONALFECHAA";
         edtPostulacionProfesionalFechaT_Internalname = "POSTULACIONPROFESIONALFECHAT";
         edtPostulacionesId_Internalname = "POSTULACIONESID";
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
         cmbPostulacionProfesionalEstado.Link = "";
         subGrid1_Header = "";
         edtPostulacionesId_Jsonclick = "";
         edtPostulacionProfesionalFechaT_Jsonclick = "";
         edtPostulacionProfesionalFechaA_Jsonclick = "";
         cmbPostulacionProfesionalEstado_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtPostulacionesId_Enabled = 0;
         edtPostulacionProfesionalFechaT_Enabled = 0;
         edtPostulacionProfesionalFechaA_Enabled = 0;
         cmbPostulacionProfesionalEstado.Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtavCpostulacionprofesionalprecio_Jsonclick = "";
         edtavCpostulacionprofesionalprecio_Enabled = 1;
         edtavCpostulacionprofesionalprecio_Visible = 1;
         edtavCpostulacionprofesionalturnot_Jsonclick = "";
         edtavCpostulacionprofesionalturnot_Enabled = 1;
         edtavCpostulacionprofesionalturnot_Visible = 1;
         edtavCpostulacionprofesionalfechat_Jsonclick = "";
         edtavCpostulacionprofesionalfechat_Enabled = 1;
         edtavCpostulacionprofesionalfechaa_Jsonclick = "";
         edtavCpostulacionprofesionalfechaa_Enabled = 1;
         cmbavCpostulacionprofesionalestado_Jsonclick = "";
         cmbavCpostulacionprofesionalestado.Visible = 1;
         cmbavCpostulacionprofesionalestado.Enabled = 1;
         edtavCprofesionalesid_Jsonclick = "";
         edtavCprofesionalesid_Enabled = 1;
         edtavCprofesionalesid_Visible = 1;
         divPostulacionprofesionalpreciofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPostulacionprofesionalturnotfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPostulacionprofesionalestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Profesionales", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'cmbavCpostulacionprofesionalestado'},{av:'AV10cPostulacionProfesionalEstado',fld:'vCPOSTULACIONPROFESIONALESTADO',pic:'',type:'char'},{av:'AV11cPostulacionProfesionalFechaA',fld:'vCPOSTULACIONPROFESIONALFECHAA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cPostulacionProfesionalFechaT',fld:'vCPOSTULACIONPROFESIONALFECHAT',pic:'',type:'date'},{av:'AV13cPostulacionProfesionalTurnoT',fld:'vCPOSTULACIONPROFESIONALTURNOT',pic:'',type:'char'},{av:'AV14cPostulacionProfesionalPrecio',fld:'vCPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV7pPostulacionesId',fld:'vPPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E15K41',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPROFESIONALESIDFILTER.CLICK","{handler:'E11K41',iparms:[{av:'divProfesionalesidfiltercontainer_Class',ctrl:'PROFESIONALESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESIDFILTER.CLICK",",oparms:[{av:'divProfesionalesidfiltercontainer_Class',ctrl:'PROFESIONALESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesid_Visible',ctrl:'vCPROFESIONALESID',prop:'Visible'}]}");
         setEventMetadata("LBLPOSTULACIONPROFESIONALESTADOFILTER.CLICK","{handler:'E12K41',iparms:[{av:'divPostulacionprofesionalestadofiltercontainer_Class',ctrl:'POSTULACIONPROFESIONALESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONPROFESIONALESTADOFILTER.CLICK",",oparms:[{av:'divPostulacionprofesionalestadofiltercontainer_Class',ctrl:'POSTULACIONPROFESIONALESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCpostulacionprofesionalestado'}]}");
         setEventMetadata("LBLPOSTULACIONPROFESIONALTURNOTFILTER.CLICK","{handler:'E13K41',iparms:[{av:'divPostulacionprofesionalturnotfiltercontainer_Class',ctrl:'POSTULACIONPROFESIONALTURNOTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONPROFESIONALTURNOTFILTER.CLICK",",oparms:[{av:'divPostulacionprofesionalturnotfiltercontainer_Class',ctrl:'POSTULACIONPROFESIONALTURNOTFILTERCONTAINER',prop:'Class'},{av:'edtavCpostulacionprofesionalturnot_Visible',ctrl:'vCPOSTULACIONPROFESIONALTURNOT',prop:'Visible'}]}");
         setEventMetadata("LBLPOSTULACIONPROFESIONALPRECIOFILTER.CLICK","{handler:'E14K41',iparms:[{av:'divPostulacionprofesionalpreciofiltercontainer_Class',ctrl:'POSTULACIONPROFESIONALPRECIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPOSTULACIONPROFESIONALPRECIOFILTER.CLICK",",oparms:[{av:'divPostulacionprofesionalpreciofiltercontainer_Class',ctrl:'POSTULACIONPROFESIONALPRECIOFILTERCONTAINER',prop:'Class'},{av:'edtavCpostulacionprofesionalprecio_Visible',ctrl:'vCPOSTULACIONPROFESIONALPRECIO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E18K42',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8pProfesionalesId',fld:'vPPROFESIONALESID',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'cmbavCpostulacionprofesionalestado'},{av:'AV10cPostulacionProfesionalEstado',fld:'vCPOSTULACIONPROFESIONALESTADO',pic:'',type:'char'},{av:'AV11cPostulacionProfesionalFechaA',fld:'vCPOSTULACIONPROFESIONALFECHAA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cPostulacionProfesionalFechaT',fld:'vCPOSTULACIONPROFESIONALFECHAT',pic:'',type:'date'},{av:'AV13cPostulacionProfesionalTurnoT',fld:'vCPOSTULACIONPROFESIONALTURNOT',pic:'',type:'char'},{av:'AV14cPostulacionProfesionalPrecio',fld:'vCPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV7pPostulacionesId',fld:'vPPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'cmbavCpostulacionprofesionalestado'},{av:'AV10cPostulacionProfesionalEstado',fld:'vCPOSTULACIONPROFESIONALESTADO',pic:'',type:'char'},{av:'AV11cPostulacionProfesionalFechaA',fld:'vCPOSTULACIONPROFESIONALFECHAA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cPostulacionProfesionalFechaT',fld:'vCPOSTULACIONPROFESIONALFECHAT',pic:'',type:'date'},{av:'AV13cPostulacionProfesionalTurnoT',fld:'vCPOSTULACIONPROFESIONALTURNOT',pic:'',type:'char'},{av:'AV14cPostulacionProfesionalPrecio',fld:'vCPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV7pPostulacionesId',fld:'vPPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'cmbavCpostulacionprofesionalestado'},{av:'AV10cPostulacionProfesionalEstado',fld:'vCPOSTULACIONPROFESIONALESTADO',pic:'',type:'char'},{av:'AV11cPostulacionProfesionalFechaA',fld:'vCPOSTULACIONPROFESIONALFECHAA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cPostulacionProfesionalFechaT',fld:'vCPOSTULACIONPROFESIONALFECHAT',pic:'',type:'date'},{av:'AV13cPostulacionProfesionalTurnoT',fld:'vCPOSTULACIONPROFESIONALTURNOT',pic:'',type:'char'},{av:'AV14cPostulacionProfesionalPrecio',fld:'vCPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV7pPostulacionesId',fld:'vPPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'cmbavCpostulacionprofesionalestado'},{av:'AV10cPostulacionProfesionalEstado',fld:'vCPOSTULACIONPROFESIONALESTADO',pic:'',type:'char'},{av:'AV11cPostulacionProfesionalFechaA',fld:'vCPOSTULACIONPROFESIONALFECHAA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cPostulacionProfesionalFechaT',fld:'vCPOSTULACIONPROFESIONALFECHAT',pic:'',type:'date'},{av:'AV13cPostulacionProfesionalTurnoT',fld:'vCPOSTULACIONPROFESIONALTURNOT',pic:'',type:'char'},{av:'AV14cPostulacionProfesionalPrecio',fld:'vCPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV7pPostulacionesId',fld:'vPPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPOSTULACIONPROFESIONALESTADO","{handler:'Validv_Cpostulacionprofesionalestado',iparms:[]");
         setEventMetadata("VALIDV_CPOSTULACIONPROFESIONALESTADO",",oparms:[]}");
         setEventMetadata("VALIDV_CPOSTULACIONPROFESIONALFECHAA","{handler:'Validv_Cpostulacionprofesionalfechaa',iparms:[]");
         setEventMetadata("VALIDV_CPOSTULACIONPROFESIONALFECHAA",",oparms:[]}");
         setEventMetadata("VALIDV_CPOSTULACIONPROFESIONALFECHAT","{handler:'Validv_Cpostulacionprofesionalfechat',iparms:[]");
         setEventMetadata("VALIDV_CPOSTULACIONPROFESIONALFECHAT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Postulacionesid',iparms:[]");
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
         AV8pProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cProfesionalesId = "";
         AV10cPostulacionProfesionalEstado = "";
         AV11cPostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         AV12cPostulacionProfesionalFechaT = DateTime.MinValue;
         AV13cPostulacionProfesionalTurnoT = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblprofesionalesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpostulacionprofesionalestadofilter_Jsonclick = "";
         lblLblpostulacionprofesionalfechaafilter_Jsonclick = "";
         lblLblpostulacionprofesionalfechatfilter_Jsonclick = "";
         lblLblpostulacionprofesionalturnotfilter_Jsonclick = "";
         lblLblpostulacionprofesionalpreciofilter_Jsonclick = "";
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
         A120ProfesionalesId = "";
         A956PostulacionProfesionalEstado = "";
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         lV6cProfesionalesId = "";
         lV10cPostulacionProfesionalEstado = "";
         lV13cPostulacionProfesionalTurnoT = "";
         A959PostulacionProfesionalTurnoT = "";
         H00K42_A982PostulacionProfesionalPrecio = new decimal[1] ;
         H00K42_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         H00K42_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         H00K42_A422PostulacionesId = new long[1] ;
         H00K42_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         H00K42_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         H00K42_A956PostulacionProfesionalEstado = new string[] {""} ;
         H00K42_A120ProfesionalesId = new string[] {""} ;
         H00K43_AGRID1_nRecordCount = new long[1] ;
         AV9ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03t1__default(),
            new Object[][] {
                new Object[] {
               H00K42_A982PostulacionProfesionalPrecio, H00K42_n982PostulacionProfesionalPrecio, H00K42_A959PostulacionProfesionalTurnoT, H00K42_A422PostulacionesId, H00K42_A958PostulacionProfesionalFechaT, H00K42_A957PostulacionProfesionalFechaA, H00K42_A956PostulacionProfesionalEstado, H00K42_A120ProfesionalesId
               }
               , new Object[] {
               H00K43_AGRID1_nRecordCount
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
      private int edtavCprofesionalesid_Visible ;
      private int edtavCprofesionalesid_Enabled ;
      private int edtavCpostulacionprofesionalfechaa_Enabled ;
      private int edtavCpostulacionprofesionalfechat_Enabled ;
      private int edtavCpostulacionprofesionalturnot_Visible ;
      private int edtavCpostulacionprofesionalturnot_Enabled ;
      private int edtavCpostulacionprofesionalprecio_Enabled ;
      private int edtavCpostulacionprofesionalprecio_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProfesionalesId_Enabled ;
      private int edtPostulacionProfesionalFechaA_Enabled ;
      private int edtPostulacionProfesionalFechaT_Enabled ;
      private int edtPostulacionesId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV7pPostulacionesId ;
      private long wcpOAV7pPostulacionesId ;
      private long GRID1_nFirstRecordOnPage ;
      private long A422PostulacionesId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV14cPostulacionProfesionalPrecio ;
      private decimal A982PostulacionProfesionalPrecio ;
      private string AV8pProfesionalesId ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProfesionalesidfiltercontainer_Class ;
      private string divPostulacionprofesionalestadofiltercontainer_Class ;
      private string divPostulacionprofesionalturnotfiltercontainer_Class ;
      private string divPostulacionprofesionalpreciofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV6cProfesionalesId ;
      private string AV10cPostulacionProfesionalEstado ;
      private string AV13cPostulacionProfesionalTurnoT ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProfesionalesidfiltercontainer_Internalname ;
      private string lblLblprofesionalesidfilter_Internalname ;
      private string lblLblprofesionalesidfilter_Jsonclick ;
      private string edtavCprofesionalesid_Internalname ;
      private string TempTags ;
      private string edtavCprofesionalesid_Jsonclick ;
      private string divPostulacionprofesionalestadofiltercontainer_Internalname ;
      private string lblLblpostulacionprofesionalestadofilter_Internalname ;
      private string lblLblpostulacionprofesionalestadofilter_Jsonclick ;
      private string cmbavCpostulacionprofesionalestado_Internalname ;
      private string cmbavCpostulacionprofesionalestado_Jsonclick ;
      private string divPostulacionprofesionalfechaafiltercontainer_Internalname ;
      private string lblLblpostulacionprofesionalfechaafilter_Internalname ;
      private string lblLblpostulacionprofesionalfechaafilter_Jsonclick ;
      private string edtavCpostulacionprofesionalfechaa_Internalname ;
      private string edtavCpostulacionprofesionalfechaa_Jsonclick ;
      private string divPostulacionprofesionalfechatfiltercontainer_Internalname ;
      private string lblLblpostulacionprofesionalfechatfilter_Internalname ;
      private string lblLblpostulacionprofesionalfechatfilter_Jsonclick ;
      private string edtavCpostulacionprofesionalfechat_Internalname ;
      private string edtavCpostulacionprofesionalfechat_Jsonclick ;
      private string divPostulacionprofesionalturnotfiltercontainer_Internalname ;
      private string lblLblpostulacionprofesionalturnotfilter_Internalname ;
      private string lblLblpostulacionprofesionalturnotfilter_Jsonclick ;
      private string edtavCpostulacionprofesionalturnot_Internalname ;
      private string edtavCpostulacionprofesionalturnot_Jsonclick ;
      private string divPostulacionprofesionalpreciofiltercontainer_Internalname ;
      private string lblLblpostulacionprofesionalpreciofilter_Internalname ;
      private string lblLblpostulacionprofesionalpreciofilter_Jsonclick ;
      private string edtavCpostulacionprofesionalprecio_Internalname ;
      private string edtavCpostulacionprofesionalprecio_Jsonclick ;
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
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string cmbPostulacionProfesionalEstado_Internalname ;
      private string A956PostulacionProfesionalEstado ;
      private string edtPostulacionProfesionalFechaA_Internalname ;
      private string edtPostulacionProfesionalFechaT_Internalname ;
      private string edtPostulacionesId_Internalname ;
      private string lV6cProfesionalesId ;
      private string lV10cPostulacionProfesionalEstado ;
      private string lV13cPostulacionProfesionalTurnoT ;
      private string A959PostulacionProfesionalTurnoT ;
      private string AV9ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtProfesionalesId_Jsonclick ;
      private string GXCCtl ;
      private string cmbPostulacionProfesionalEstado_Jsonclick ;
      private string edtPostulacionProfesionalFechaA_Jsonclick ;
      private string edtPostulacionProfesionalFechaT_Jsonclick ;
      private string edtPostulacionesId_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cPostulacionProfesionalFechaA ;
      private DateTime A957PostulacionProfesionalFechaA ;
      private DateTime AV12cPostulacionProfesionalFechaT ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n982PostulacionProfesionalPrecio ;
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
      private GXCombobox cmbavCpostulacionprofesionalestado ;
      private GXCombobox cmbPostulacionProfesionalEstado ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00K42_A982PostulacionProfesionalPrecio ;
      private bool[] H00K42_n982PostulacionProfesionalPrecio ;
      private string[] H00K42_A959PostulacionProfesionalTurnoT ;
      private long[] H00K42_A422PostulacionesId ;
      private DateTime[] H00K42_A958PostulacionProfesionalFechaT ;
      private DateTime[] H00K42_A957PostulacionProfesionalFechaA ;
      private string[] H00K42_A956PostulacionProfesionalEstado ;
      private string[] H00K42_A120ProfesionalesId ;
      private long[] H00K43_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP1_pProfesionalesId ;
   }

   public class gx03t1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00K42( IGxContext context ,
                                             string AV10cPostulacionProfesionalEstado ,
                                             DateTime AV11cPostulacionProfesionalFechaA ,
                                             DateTime AV12cPostulacionProfesionalFechaT ,
                                             string AV13cPostulacionProfesionalTurnoT ,
                                             decimal AV14cPostulacionProfesionalPrecio ,
                                             string A956PostulacionProfesionalEstado ,
                                             DateTime A957PostulacionProfesionalFechaA ,
                                             DateTime A958PostulacionProfesionalFechaT ,
                                             string A959PostulacionProfesionalTurnoT ,
                                             decimal A982PostulacionProfesionalPrecio ,
                                             string A120ProfesionalesId ,
                                             string AV6cProfesionalesId ,
                                             long AV7pPostulacionesId ,
                                             long A422PostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PostulacionProfesionalPrecio], [PostulacionProfesionalTurnoT], [PostulacionesId], [PostulacionProfesionalFechaT], [PostulacionProfesionalFechaA], [PostulacionProfesionalEstado], [ProfesionalesId]";
         sFromString = " FROM [PostulacionesProfesionales]";
         sOrderString = "";
         AddWhere(sWhereString, "([PostulacionesId] = @AV7pPostulacionesId)");
         AddWhere(sWhereString, "([ProfesionalesId] like @lV6cProfesionalesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cPostulacionProfesionalEstado)) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalEstado] like @lV10cPostulacionProfesionalEstado)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cPostulacionProfesionalFechaA) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalFechaA] >= @AV11cPostulacionProfesionalFechaA)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cPostulacionProfesionalFechaT) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalFechaT] >= @AV12cPostulacionProfesionalFechaT)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cPostulacionProfesionalTurnoT)) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalTurnoT] like @lV13cPostulacionProfesionalTurnoT)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV14cPostulacionProfesionalPrecio) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalPrecio] >= @AV14cPostulacionProfesionalPrecio)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [PostulacionesId], [ProfesionalesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00K43( IGxContext context ,
                                             string AV10cPostulacionProfesionalEstado ,
                                             DateTime AV11cPostulacionProfesionalFechaA ,
                                             DateTime AV12cPostulacionProfesionalFechaT ,
                                             string AV13cPostulacionProfesionalTurnoT ,
                                             decimal AV14cPostulacionProfesionalPrecio ,
                                             string A956PostulacionProfesionalEstado ,
                                             DateTime A957PostulacionProfesionalFechaA ,
                                             DateTime A958PostulacionProfesionalFechaT ,
                                             string A959PostulacionProfesionalTurnoT ,
                                             decimal A982PostulacionProfesionalPrecio ,
                                             string A120ProfesionalesId ,
                                             string AV6cProfesionalesId ,
                                             long AV7pPostulacionesId ,
                                             long A422PostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [PostulacionesProfesionales]";
         AddWhere(sWhereString, "([PostulacionesId] = @AV7pPostulacionesId)");
         AddWhere(sWhereString, "([ProfesionalesId] like @lV6cProfesionalesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cPostulacionProfesionalEstado)) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalEstado] like @lV10cPostulacionProfesionalEstado)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cPostulacionProfesionalFechaA) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalFechaA] >= @AV11cPostulacionProfesionalFechaA)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cPostulacionProfesionalFechaT) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalFechaT] >= @AV12cPostulacionProfesionalFechaT)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cPostulacionProfesionalTurnoT)) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalTurnoT] like @lV13cPostulacionProfesionalTurnoT)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV14cPostulacionProfesionalPrecio) )
         {
            AddWhere(sWhereString, "([PostulacionProfesionalPrecio] >= @AV14cPostulacionProfesionalPrecio)");
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
                     return conditional_H00K42(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] );
               case 1 :
                     return conditional_H00K43(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] );
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
          Object[] prmH00K42;
          prmH00K42 = new Object[] {
          new ParDef("@AV7pPostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV6cProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@lV10cPostulacionProfesionalEstado",GXType.NChar,3,0) ,
          new ParDef("@AV11cPostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
          new ParDef("@AV12cPostulacionProfesionalFechaT",GXType.Date,8,0) ,
          new ParDef("@lV13cPostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
          new ParDef("@AV14cPostulacionProfesionalPrecio",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00K43;
          prmH00K43 = new Object[] {
          new ParDef("@AV7pPostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV6cProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@lV10cPostulacionProfesionalEstado",GXType.NChar,3,0) ,
          new ParDef("@AV11cPostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
          new ParDef("@AV12cPostulacionProfesionalFechaT",GXType.Date,8,0) ,
          new ParDef("@lV13cPostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
          new ParDef("@AV14cPostulacionProfesionalPrecio",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00K42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00K42,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00K43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00K43,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

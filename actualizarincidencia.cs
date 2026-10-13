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
   public class actualizarincidencia : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public actualizarincidencia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarincidencia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_Incidenciaid ,
                           ref long aP1_MotivoId ,
                           ref string aP2_UsuariosId ,
                           string aP3_ProfesionalesId )
      {
         this.AV11Incidenciaid = aP0_Incidenciaid;
         this.AV15MotivoId = aP1_MotivoId;
         this.AV25UsuariosId = aP2_UsuariosId;
         this.AV33ProfesionalesId = aP3_ProfesionalesId;
         ExecutePrivate();
         aP0_Incidenciaid=this.AV11Incidenciaid;
         aP1_MotivoId=this.AV15MotivoId;
         aP2_UsuariosId=this.AV25UsuariosId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavNmotivoid = new GXCombobox();
         dynavCancelaciontipificacion = new GXCombobox();
         cmbavIncidenciaestado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Incidenciaid");
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
               gxfirstwebparm = GetFirstPar( "Incidenciaid");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Incidenciaid");
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

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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
         PABA2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBA2( ) ;
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
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "actualizarincidencia.aspx"+UrlEncode(StringUtil.LTrimStr(AV11Incidenciaid,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15MotivoId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV25UsuariosId)) + "," + UrlEncode(StringUtil.RTrim(AV33ProfesionalesId));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actualizarincidencia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOSSDT", AV34UsuariosSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOSSDT", AV34UsuariosSDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSSDT", GetSecureSignedToken( "", AV34UsuariosSDT, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV26WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV26WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV26WWPContext, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIADETALLEDESC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")), context));
         GxWebStd.gx_hidden_field( context, "vINCIDENCIAUSRACTUALIZACION", StringUtil.RTrim( AV12IncidenciaUsrActualizacion));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIAUSRACTUALIZACION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12IncidenciaUsrActualizacion, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV33ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33ProfesionalesId, "")), context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ActualizarIncidencia");
         forbiddenHiddens.Add("nMotivoId", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"));
         forbiddenHiddens.Add("IncidenciaDetalleDesc", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("actualizarincidencia:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESMAIL", AV35SolicitudesMail);
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESNOMBRE", StringUtil.RTrim( AV36SolicitudesNombre));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOSSDT", AV34UsuariosSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOSSDT", AV34UsuariosSDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSSDT", GetSecureSignedToken( "", AV34UsuariosSDT, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV26WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV26WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV26WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.RTrim( AV25UsuariosId));
         GxWebStd.gx_hidden_field( context, "vCONTARSOLINCL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ContarSolIncl), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINCIDENCIAUSRACTUALIZACION", StringUtil.RTrim( AV12IncidenciaUsrActualizacion));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIAUSRACTUALIZACION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12IncidenciaUsrActualizacion, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROCSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ProcSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vNUEVOESTADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16NuevoEstadoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vNUEVOESTADONOMB", StringUtil.RTrim( AV17NuevoEstadoNomb));
         GxWebStd.gx_hidden_field( context, "vMENSAJENOTIFICAR", AV14MensajeNotificar);
         GxWebStd.gx_hidden_field( context, "vINCIDENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Incidenciaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMOTIVOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESMAIL", A206SolicitudesMail);
         GxWebStd.gx_hidden_field( context, "SOLICITUDESNOMBRE", StringUtil.RTrim( A171SolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV33ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33ProfesionalesId, "")), context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
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
            WEBA2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBA2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "actualizarincidencia.aspx"+UrlEncode(StringUtil.LTrimStr(AV11Incidenciaid,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15MotivoId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV25UsuariosId)) + "," + UrlEncode(StringUtil.RTrim(AV33ProfesionalesId));
         return formatLink("actualizarincidencia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ActualizarIncidencia" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Actualizar Incidencia", "") ;
      }

      protected void WBBA0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavNmotivoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavNmotivoid_Internalname, context.GetMessage( "Motivo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavNmotivoid, dynavNmotivoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0)), 1, dynavNmotivoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavNmotivoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_ActualizarIncidencia.htm");
            dynavNmotivoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0));
            AssignProp("", false, dynavNmotivoid_Internalname, "Values", (string)(dynavNmotivoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavIncidenciadetalledesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIncidenciadetalledesc_Internalname, context.GetMessage( "Detalle", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavIncidenciadetalledesc_Internalname, StringUtil.RTrim( AV9IncidenciaDetalleDesc), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", 0, 1, edtavIncidenciadetalledesc_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ActualizarIncidencia.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavCancelaciontipificacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCancelaciontipificacion_Internalname, context.GetMessage( "Tipo de Cancelación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCancelaciontipificacion, dynavCancelaciontipificacion_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0)), 1, dynavCancelaciontipificacion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCancelaciontipificacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_ActualizarIncidencia.htm");
            dynavCancelaciontipificacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0));
            AssignProp("", false, dynavCancelaciontipificacion_Internalname, "Values", (string)(dynavCancelaciontipificacion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavComentario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavComentario_Internalname, context.GetMessage( "comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavComentario_Internalname, StringUtil.RTrim( AV6comentario), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtavComentario_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ActualizarIncidencia.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavIncidenciaestado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIncidenciaestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIncidenciaestado, cmbavIncidenciaestado_Internalname, StringUtil.RTrim( AV10IncidenciaEstado), 1, cmbavIncidenciaestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavIncidenciaestado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_ActualizarIncidencia.htm");
            cmbavIncidenciaestado.CurrentValue = StringUtil.RTrim( AV10IncidenciaEstado);
            AssignProp("", false, cmbavIncidenciaestado_Internalname, "Values", (string)(cmbavIncidenciaestado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaceptar_Internalname, "", context.GetMessage( "Aceptar", ""), bttBtnaceptar_Jsonclick, 5, context.GetMessage( "Aceptar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOACEPTAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ActualizarIncidencia.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelar_Internalname, "", context.GetMessage( "Cancelar", ""), bttBtncancelar_Jsonclick, 5, context.GetMessage( "Cancelar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ActualizarIncidencia.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsolicitud_Internalname, "", context.GetMessage( "Solicitud", ""), bttBtnbtnsolicitud_Jsonclick, 5, context.GetMessage( "Solicitud", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSOLICITUD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ActualizarIncidencia.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucToastr1.Render(context, "toastr", Toastr1_Internalname, "TOASTR1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTBA2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Actualizar Incidencia", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBA0( ) ;
      }

      protected void WSBA2( )
      {
         STARTBA2( ) ;
         EVTBA2( ) ;
      }

      protected void EVTBA2( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11BA2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOACEPTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAceptar' */
                              E12BA2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCancelar' */
                              E13BA2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSOLICITUD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBTNSolicitud' */
                              E14BA2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15BA2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEBA2( )
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

      protected void PABA2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "actualizarincidencia.aspx")), "actualizarincidencia.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "actualizarincidencia.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "Incidenciaid");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV11Incidenciaid = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV11Incidenciaid", StringUtil.LTrimStr( (decimal)(AV11Incidenciaid), 18, 0));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV15MotivoId = (long)(Math.Round(NumberUtil.Val( GetPar( "MotivoId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV15MotivoId", StringUtil.LTrimStr( (decimal)(AV15MotivoId), 18, 0));
                        AV25UsuariosId = GetPar( "UsuariosId");
                        AssignAttri("", false, "AV25UsuariosId", AV25UsuariosId);
                        AV33ProfesionalesId = GetPar( "ProfesionalesId");
                        AssignAttri("", false, "AV33ProfesionalesId", AV33ProfesionalesId);
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33ProfesionalesId, "")), context));
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
            }
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavNmotivoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCANCELACIONTIPIFICACIONBA1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCANCELACIONTIPIFICACION_dataBA1( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvCANCELACIONTIPIFICACION_htmlBA1( )
      {
         long gxdynajaxvalue;
         GXDLVvCANCELACIONTIPIFICACION_dataBA1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCancelaciontipificacion.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCancelaciontipificacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCancelaciontipificacion.ItemCount > 0 )
         {
            AV37CancelacionTipificacion = (long)(Math.Round(NumberUtil.Val( dynavCancelaciontipificacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV37CancelacionTipificacion", StringUtil.LTrimStr( (decimal)(AV37CancelacionTipificacion), 18, 0));
         }
      }

      protected void GXDLVvCANCELACIONTIPIFICACION_dataBA1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00BA2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00BA2_A996CancelacionTipificacionId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00BA2_A997CancelacionTipificacionDescrip[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvNMOTIVOIDBA1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvNMOTIVOID_dataBA1( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvNMOTIVOID_htmlBA1( )
      {
         long gxdynajaxvalue;
         GXDLVvNMOTIVOID_dataBA1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavNmotivoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavNmotivoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavNmotivoid.ItemCount > 0 )
         {
            AV29nMotivoId = (short)(Math.Round(NumberUtil.Val( dynavNmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
         }
      }

      protected void GXDLVvNMOTIVOID_dataBA1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00BA3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00BA3_A604MotivoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00BA3_A616MotivoNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavCancelaciontipificacion.Name = "vCANCELACIONTIPIFICACION";
            dynavCancelaciontipificacion.WebTags = "";
            dynavCancelaciontipificacion.removeAllItems();
            /* Using cursor H00BA4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavCancelaciontipificacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00BA4_A996CancelacionTipificacionId[0]), 18, 0)), H00BA4_A997CancelacionTipificacionDescrip[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavCancelaciontipificacion.ItemCount > 0 )
            {
               AV37CancelacionTipificacion = (long)(Math.Round(NumberUtil.Val( dynavCancelaciontipificacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37CancelacionTipificacion", StringUtil.LTrimStr( (decimal)(AV37CancelacionTipificacion), 18, 0));
            }
            dynavNmotivoid.Name = "vNMOTIVOID";
            dynavNmotivoid.WebTags = "";
            dynavNmotivoid.removeAllItems();
            /* Using cursor H00BA5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavNmotivoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00BA5_A604MotivoId[0]), 4, 0)), H00BA5_A616MotivoNombre[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavNmotivoid.ItemCount > 0 )
            {
               AV29nMotivoId = (short)(Math.Round(NumberUtil.Val( dynavNmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavNmotivoid.ItemCount > 0 )
         {
            AV29nMotivoId = (short)(Math.Round(NumberUtil.Val( dynavNmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavNmotivoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0));
            AssignProp("", false, dynavNmotivoid_Internalname, "Values", dynavNmotivoid.ToJavascriptSource(), true);
         }
         if ( dynavCancelaciontipificacion.ItemCount > 0 )
         {
            AV37CancelacionTipificacion = (long)(Math.Round(NumberUtil.Val( dynavCancelaciontipificacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV37CancelacionTipificacion", StringUtil.LTrimStr( (decimal)(AV37CancelacionTipificacion), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCancelaciontipificacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0));
            AssignProp("", false, dynavCancelaciontipificacion_Internalname, "Values", dynavCancelaciontipificacion.ToJavascriptSource(), true);
         }
         if ( cmbavIncidenciaestado.ItemCount > 0 )
         {
            AV10IncidenciaEstado = cmbavIncidenciaestado.getValidValue(AV10IncidenciaEstado);
            AssignAttri("", false, "AV10IncidenciaEstado", AV10IncidenciaEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIncidenciaestado.CurrentValue = StringUtil.RTrim( AV10IncidenciaEstado);
            AssignProp("", false, cmbavIncidenciaestado_Internalname, "Values", cmbavIncidenciaestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBA2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         dynavNmotivoid.Enabled = 0;
         AssignProp("", false, dynavNmotivoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavNmotivoid.Enabled), 5, 0), true);
         edtavIncidenciadetalledesc_Enabled = 0;
         AssignProp("", false, edtavIncidenciadetalledesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIncidenciadetalledesc_Enabled), 5, 0), true);
      }

      protected void RFBA2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15BA2 ();
            WBBA0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBA2( )
      {
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOSSDT", AV34UsuariosSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOSSDT", AV34UsuariosSDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSSDT", GetSecureSignedToken( "", AV34UsuariosSDT, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV26WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV26WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV26WWPContext, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIADETALLEDESC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")), context));
         GxWebStd.gx_hidden_field( context, "vINCIDENCIAUSRACTUALIZACION", StringUtil.RTrim( AV12IncidenciaUsrActualizacion));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIAUSRACTUALIZACION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12IncidenciaUsrActualizacion, "")), context));
      }

      protected void before_start_formulas( )
      {
         dynavNmotivoid.Enabled = 0;
         AssignProp("", false, dynavNmotivoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavNmotivoid.Enabled), 5, 0), true);
         edtavIncidenciadetalledesc_Enabled = 0;
         AssignProp("", false, edtavIncidenciadetalledesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIncidenciadetalledesc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBA0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11BA2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavNmotivoid.CurrentValue = cgiGet( dynavNmotivoid_Internalname);
            AV29nMotivoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavNmotivoid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
            AV9IncidenciaDetalleDesc = cgiGet( edtavIncidenciadetalledesc_Internalname);
            AssignAttri("", false, "AV9IncidenciaDetalleDesc", AV9IncidenciaDetalleDesc);
            GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIADETALLEDESC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")), context));
            dynavCancelaciontipificacion.CurrentValue = cgiGet( dynavCancelaciontipificacion_Internalname);
            AV37CancelacionTipificacion = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavCancelaciontipificacion_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV37CancelacionTipificacion", StringUtil.LTrimStr( (decimal)(AV37CancelacionTipificacion), 18, 0));
            AV6comentario = cgiGet( edtavComentario_Internalname);
            AssignAttri("", false, "AV6comentario", AV6comentario);
            cmbavIncidenciaestado.CurrentValue = cgiGet( cmbavIncidenciaestado_Internalname);
            AV10IncidenciaEstado = cgiGet( cmbavIncidenciaestado_Internalname);
            AssignAttri("", false, "AV10IncidenciaEstado", AV10IncidenciaEstado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ActualizarIncidencia");
            AV29nMotivoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavNmotivoid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
            forbiddenHiddens.Add("nMotivoId", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"));
            AV9IncidenciaDetalleDesc = cgiGet( edtavIncidenciadetalledesc_Internalname);
            AssignAttri("", false, "AV9IncidenciaDetalleDesc", AV9IncidenciaDetalleDesc);
            GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIADETALLEDESC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")), context));
            forbiddenHiddens.Add("IncidenciaDetalleDesc", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("actualizarincidencia:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E11BA2 ();
         if (returnInSub) return;
      }

      protected void E11BA2( )
      {
         /* Start Routine */
         returnInSub = false;
         new ousuarioprofid(context ).execute(  AV33ProfesionalesId, out  AV34UsuariosSDT) ;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV26WWPContext) ;
         AV29nMotivoId = (short)(AV15MotivoId);
         AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
         AV12IncidenciaUsrActualizacion = AV26WWPContext.gxTpr_Usuariosid;
         AssignAttri("", false, "AV12IncidenciaUsrActualizacion", AV12IncidenciaUsrActualizacion);
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIAUSRACTUALIZACION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12IncidenciaUsrActualizacion, "")), context));
         /* Execute user subroutine: 'BUSCAR INCIDENCIA' */
         S112 ();
         if (returnInSub) return;
         AV32Modifica = false;
      }

      protected void E12BA2( )
      {
         /* 'DoAceptar' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10IncidenciaEstado, "ANU") == 0 )
         {
            AV14MensajeNotificar = context.GetMessage( "Nuevo Estado Incidencia de Solicitud: ", "") + StringUtil.Str( (decimal)(AV22SolicitudesID), 18, 0) + " " + gxdomainestadoope.getDescription(context,"ANU");
            AssignAttri("", false, "AV14MensajeNotificar", AV14MensajeNotificar);
            /* Execute user subroutine: 'FIN DE LA ACCION' */
            S122 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV10IncidenciaEstado, "PRO") == 0 )
         {
            AV14MensajeNotificar = context.GetMessage( "Nuevo Estado Incidencia de Solicitud: ", "") + StringUtil.Str( (decimal)(AV22SolicitudesID), 18, 0) + " " + gxdomainestadoope.getDescription(context,"PRO");
            AssignAttri("", false, "AV14MensajeNotificar", AV14MensajeNotificar);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6comentario)) || ( AV37CancelacionTipificacion == 0 ) )
            {
               AV24Titulo = context.GetMessage( " Atención ", "");
               this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"error",context.GetMessage( "Debe seleccionar tipo de cancelación y escribir un comentario.", ""),(string)AV24Titulo});
            }
            else
            {
               if ( AV29nMotivoId == 1 )
               {
                  AV16NuevoEstadoId = 3;
                  AssignAttri("", false, "AV16NuevoEstadoId", StringUtil.LTrimStr( (decimal)(AV16NuevoEstadoId), 18, 0));
                  AV17NuevoEstadoNomb = context.GetMessage( "Cancelada", "");
                  AssignAttri("", false, "AV17NuevoEstadoNomb", AV17NuevoEstadoNomb);
                  /* Execute user subroutine: 'OSOLICITUD' */
                  S132 ();
                  if (returnInSub) return;
                  AV21SDTCNotificaciones = new SdtSDTCNotificaciones(context);
                  AV21SDTCNotificaciones.gxTpr_Solicitudesid = AV22SolicitudesID;
                  AV21SDTCNotificaciones.gxTpr_Maildesignid = 2;
                  AV21SDTCNotificaciones.gxTpr_Estadosgenericosid = (int)(AV16NuevoEstadoId);
                  AV21SDTCNotificaciones.gxTpr_Nuevoestado = AV17NuevoEstadoNomb;
                  AV21SDTCNotificaciones.gxTpr_Emailcliente = AV35SolicitudesMail;
                  AV21SDTCNotificaciones.gxTpr_Nombrecliente = AV36SolicitudesNombre;
                  AV21SDTCNotificaciones.gxTpr_Emailprofesional = AV34UsuariosSDT.gxTpr_Usuarioscorreo;
                  AV21SDTCNotificaciones.gxTpr_Nombreprofesional = AV34UsuariosSDT.gxTpr_Usuariosnombre;
                  AV21SDTCNotificaciones.gxTpr_Emailoperador = AV26WWPContext.gxTpr_Usuarioscorreo;
                  AV21SDTCNotificaciones.gxTpr_Nombreoperador = AV26WWPContext.gxTpr_Usuariosnombre;
                  new cambstssolicitudes(context ).execute(  AV22SolicitudesID,  3,  "",  AV21SDTCNotificaciones,  AV25UsuariosId, out  AV5CambioSTSOK) ;
                  if ( StringUtil.StrCmp(AV5CambioSTSOK, context.GetMessage( "S", "")) == 0 )
                  {
                     AV7ContarSolIncl = (short)(AV7ContarSolIncl+1);
                     AssignAttri("", false, "AV7ContarSolIncl", StringUtil.LTrimStr( (decimal)(AV7ContarSolIncl), 4, 0));
                     AV20ProcSolicitudesID = AV22SolicitudesID;
                     AssignAttri("", false, "AV20ProcSolicitudesID", StringUtil.LTrimStr( (decimal)(AV20ProcSolicitudesID), 18, 0));
                     AV6comentario = StringUtil.Format( context.GetMessage( "El profesional %1 comenta: %2 y el usuario %3 comento: %4", ""), StringUtil.Trim( AV25UsuariosId), StringUtil.Trim( AV9IncidenciaDetalleDesc), StringUtil.Trim( AV12IncidenciaUsrActualizacion), StringUtil.Trim( AV6comentario), "", "", "", "", "");
                     AssignAttri("", false, "AV6comentario", AV6comentario);
                     new anotasolicitud(context ).execute(  AV22SolicitudesID, ref  AV6comentario, ref  AV37CancelacionTipificacion) ;
                     AssignAttri("", false, "AV6comentario", AV6comentario);
                     AssignAttri("", false, "AV37CancelacionTipificacion", StringUtil.LTrimStr( (decimal)(AV37CancelacionTipificacion), 18, 0));
                  }
                  if ( AV7ContarSolIncl == 0 )
                  {
                     AV24Titulo = context.GetMessage( " Atención ", "");
                     this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"warning",context.GetMessage( "Debe incluir una o más solicitudes.", ""),(string)AV24Titulo});
                  }
                  else
                  {
                     if ( AV7ContarSolIncl == 1 )
                     {
                        AV24Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV20ProcSolicitudesID), 10, 0));
                        this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Fue Cancelada con Éxito.", ""),(string)AV24Titulo});
                     }
                     else
                     {
                        AV24Titulo = context.GetMessage( "Total de solicitudes: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV7ContarSolIncl), 10, 0));
                        this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Canceladas con Éxito.", ""),(string)AV24Titulo});
                     }
                     /* Execute user subroutine: 'FIN DE LA ACCION' */
                     S122 ();
                     if (returnInSub) return;
                  }
               }
               if ( AV29nMotivoId == 2 )
               {
                  AV21SDTCNotificaciones = new SdtSDTCNotificaciones(context);
                  AV21SDTCNotificaciones.gxTpr_Solicitudesid = AV22SolicitudesID;
                  AV21SDTCNotificaciones.gxTpr_Maildesignid = 2;
                  AV21SDTCNotificaciones.gxTpr_Estadosgenericosid = (int)(AV16NuevoEstadoId);
                  AV21SDTCNotificaciones.gxTpr_Nuevoestado = AV17NuevoEstadoNomb;
                  AV21SDTCNotificaciones.gxTpr_Emailcliente = AV35SolicitudesMail;
                  AV21SDTCNotificaciones.gxTpr_Nombrecliente = AV36SolicitudesNombre;
                  AV21SDTCNotificaciones.gxTpr_Emailprofesional = AV34UsuariosSDT.gxTpr_Usuarioscorreo;
                  AV21SDTCNotificaciones.gxTpr_Nombreprofesional = AV34UsuariosSDT.gxTpr_Usuariosnombre;
                  AV21SDTCNotificaciones.gxTpr_Emailoperador = AV26WWPContext.gxTpr_Usuarioscorreo;
                  AV21SDTCNotificaciones.gxTpr_Nombreoperador = AV26WWPContext.gxTpr_Usuariosnombre;
                  /* Execute user subroutine: 'FIN DE LA ACCION' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
         else
         {
            AV24Titulo = context.GetMessage( " Atención ", "");
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"warning",context.GetMessage( "Accion no valida.", ""),(string)AV24Titulo});
         }
         /*  Sending Event outputs  */
         dynavCancelaciontipificacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0));
         AssignProp("", false, dynavCancelaciontipificacion_Internalname, "Values", dynavCancelaciontipificacion.ToJavascriptSource(), true);
      }

      protected void E13BA2( )
      {
         /* 'DoCancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(long)AV11Incidenciaid,(long)AV15MotivoId,(string)AV25UsuariosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11Incidenciaid","AV15MotivoId","AV25UsuariosId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E14BA2( )
      {
         /* 'DoBTNSolicitud' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim(context.GetMessage( "UPD", ""))) + "," + UrlEncode(StringUtil.LTrimStr(AV22SolicitudesID,18,0));
         CallWebObject(formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'BUSCAR INCIDENCIA' Routine */
         returnInSub = false;
         /* Using cursor H00BA6 */
         pr_default.execute(4, new Object[] {AV11Incidenciaid, AV25UsuariosId, AV29nMotivoId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A603IncidenciaId = H00BA6_A603IncidenciaId[0];
            A604MotivoId = H00BA6_A604MotivoId[0];
            A615IncidenciaUsrAlta = H00BA6_A615IncidenciaUsrAlta[0];
            A608IncidenciaEstado = H00BA6_A608IncidenciaEstado[0];
            A606IncidenciaCodRef = H00BA6_A606IncidenciaCodRef[0];
            AV10IncidenciaEstado = A608IncidenciaEstado;
            AssignAttri("", false, "AV10IncidenciaEstado", AV10IncidenciaEstado);
            AV22SolicitudesID = (long)(Math.Round(NumberUtil.Val( A606IncidenciaCodRef, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22SolicitudesID", StringUtil.LTrimStr( (decimal)(AV22SolicitudesID), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
            /* Using cursor H00BA7 */
            pr_default.execute(5, new Object[] {A603IncidenciaId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A607IncidenciaDetalleDesc = H00BA7_A607IncidenciaDetalleDesc[0];
               AV9IncidenciaDetalleDesc = A607IncidenciaDetalleDesc;
               AssignAttri("", false, "AV9IncidenciaDetalleDesc", AV9IncidenciaDetalleDesc);
               GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIADETALLEDESC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9IncidenciaDetalleDesc, "")), context));
               pr_default.readNext(5);
            }
            pr_default.close(5);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void S122( )
      {
         /* 'FIN DE LA ACCION' Routine */
         returnInSub = false;
         AV23TipoNotificacion = context.GetMessage( "N", "");
         AV18Objeto = context.GetMessage( "dashboardprofesionalesv2", "");
         AV19Parametros = StringUtil.Trim( AV25UsuariosId);
         new anotificacion(context ).execute(  AV25UsuariosId,  AV23TipoNotificacion,  AV18Objeto,  AV19Parametros,  AV14MensajeNotificar) ;
         new aincidenciaestado(context ).execute(  AV11Incidenciaid,  AV29nMotivoId,  AV25UsuariosId,  AV12IncidenciaUsrActualizacion,  AV10IncidenciaEstado) ;
         context.setWebReturnParms(new Object[] {(long)AV11Incidenciaid,(long)AV15MotivoId,(string)AV25UsuariosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11Incidenciaid","AV15MotivoId","AV25UsuariosId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'OSOLICITUD' Routine */
         returnInSub = false;
         /* Using cursor H00BA8 */
         pr_default.execute(6, new Object[] {AV22SolicitudesID});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A127SolicitudesID = H00BA8_A127SolicitudesID[0];
            A206SolicitudesMail = H00BA8_A206SolicitudesMail[0];
            n206SolicitudesMail = H00BA8_n206SolicitudesMail[0];
            A171SolicitudesNombre = H00BA8_A171SolicitudesNombre[0];
            AV35SolicitudesMail = A206SolicitudesMail;
            AssignAttri("", false, "AV35SolicitudesMail", AV35SolicitudesMail);
            AV36SolicitudesNombre = A171SolicitudesNombre;
            AssignAttri("", false, "AV36SolicitudesNombre", AV36SolicitudesNombre);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void nextLoad( )
      {
      }

      protected void E15BA2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11Incidenciaid = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV11Incidenciaid", StringUtil.LTrimStr( (decimal)(AV11Incidenciaid), 18, 0));
         AV15MotivoId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV15MotivoId", StringUtil.LTrimStr( (decimal)(AV15MotivoId), 18, 0));
         AV25UsuariosId = (string)getParm(obj,2);
         AssignAttri("", false, "AV25UsuariosId", AV25UsuariosId);
         AV33ProfesionalesId = (string)getParm(obj,3);
         AssignAttri("", false, "AV33ProfesionalesId", AV33ProfesionalesId);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33ProfesionalesId, "")), context));
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
         PABA2( ) ;
         WSBA2( ) ;
         WEBA2( ) ;
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
         AddStyleSheetFile("Toastr/toastr.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021222092", true, true, false);
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
         context.AddJavascriptSource("actualizarincidencia.js", "?202673021222092", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavNmotivoid.Name = "vNMOTIVOID";
         dynavNmotivoid.WebTags = "";
         dynavNmotivoid.removeAllItems();
         /* Using cursor H00BA9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            dynavNmotivoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00BA9_A604MotivoId[0]), 4, 0)), H00BA9_A616MotivoNombre[0], 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         if ( dynavNmotivoid.ItemCount > 0 )
         {
            AV29nMotivoId = (short)(Math.Round(NumberUtil.Val( dynavNmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29nMotivoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29nMotivoId", StringUtil.LTrimStr( (decimal)(AV29nMotivoId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vNMOTIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29nMotivoId), "ZZZ9"), context));
         }
         dynavCancelaciontipificacion.Name = "vCANCELACIONTIPIFICACION";
         dynavCancelaciontipificacion.WebTags = "";
         dynavCancelaciontipificacion.removeAllItems();
         /* Using cursor H00BA10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynavCancelaciontipificacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00BA10_A996CancelacionTipificacionId[0]), 18, 0)), H00BA10_A997CancelacionTipificacionDescrip[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynavCancelaciontipificacion.ItemCount > 0 )
         {
            AV37CancelacionTipificacion = (long)(Math.Round(NumberUtil.Val( dynavCancelaciontipificacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37CancelacionTipificacion), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV37CancelacionTipificacion", StringUtil.LTrimStr( (decimal)(AV37CancelacionTipificacion), 18, 0));
         }
         cmbavIncidenciaestado.Name = "vINCIDENCIAESTADO";
         cmbavIncidenciaestado.WebTags = "";
         cmbavIncidenciaestado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbavIncidenciaestado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbavIncidenciaestado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbavIncidenciaestado.ItemCount > 0 )
         {
            AV10IncidenciaEstado = cmbavIncidenciaestado.getValidValue(AV10IncidenciaEstado);
            AssignAttri("", false, "AV10IncidenciaEstado", AV10IncidenciaEstado);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavNmotivoid_Internalname = "vNMOTIVOID";
         edtavIncidenciadetalledesc_Internalname = "vINCIDENCIADETALLEDESC";
         dynavCancelaciontipificacion_Internalname = "vCANCELACIONTIPIFICACION";
         edtavComentario_Internalname = "vCOMENTARIO";
         cmbavIncidenciaestado_Internalname = "vINCIDENCIAESTADO";
         bttBtnaceptar_Internalname = "BTNACEPTAR";
         bttBtncancelar_Internalname = "BTNCANCELAR";
         bttBtnbtnsolicitud_Internalname = "BTNBTNSOLICITUD";
         Toastr1_Internalname = "TOASTR1";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         divMaintable_Internalname = "MAINTABLE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         cmbavIncidenciaestado_Jsonclick = "";
         cmbavIncidenciaestado.Enabled = 1;
         edtavComentario_Enabled = 1;
         dynavCancelaciontipificacion_Jsonclick = "";
         dynavCancelaciontipificacion.Enabled = 1;
         edtavIncidenciadetalledesc_Enabled = 1;
         dynavNmotivoid_Jsonclick = "";
         dynavNmotivoid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Actualizar Incidencia", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavCancelaciontipificacion'},{av:'AV37CancelacionTipificacion',fld:'vCANCELACIONTIPIFICACION',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV34UsuariosSDT',fld:'vUSUARIOSSDT',pic:'',hsh:true},{av:'AV26WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV12IncidenciaUsrActualizacion',fld:'vINCIDENCIAUSRACTUALIZACION',pic:'',hsh:true,type:'char'},{av:'AV33ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'dynavNmotivoid'},{av:'AV29nMotivoId',fld:'vNMOTIVOID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV9IncidenciaDetalleDesc',fld:'vINCIDENCIADETALLEDESC',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOACEPTAR'","{handler:'E12BA2',iparms:[{av:'cmbavIncidenciaestado'},{av:'AV10IncidenciaEstado',fld:'vINCIDENCIAESTADO',pic:'',type:'char'},{av:'AV22SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV6comentario',fld:'vCOMENTARIO',pic:'',type:'char'},{av:'dynavCancelaciontipificacion'},{av:'AV37CancelacionTipificacion',fld:'vCANCELACIONTIPIFICACION',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynavNmotivoid'},{av:'AV29nMotivoId',fld:'vNMOTIVOID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV35SolicitudesMail',fld:'vSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV36SolicitudesNombre',fld:'vSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV34UsuariosSDT',fld:'vUSUARIOSSDT',pic:'',hsh:true},{av:'AV26WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV25UsuariosId',fld:'vUSUARIOSID',pic:'',type:'char'},{av:'AV7ContarSolIncl',fld:'vCONTARSOLINCL',pic:'ZZZ9',type:'int'},{av:'AV9IncidenciaDetalleDesc',fld:'vINCIDENCIADETALLEDESC',pic:'',hsh:true,type:'char'},{av:'AV12IncidenciaUsrActualizacion',fld:'vINCIDENCIAUSRACTUALIZACION',pic:'',hsh:true,type:'char'},{av:'AV20ProcSolicitudesID',fld:'vPROCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16NuevoEstadoId',fld:'vNUEVOESTADOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17NuevoEstadoNomb',fld:'vNUEVOESTADONOMB',pic:'',type:'char'},{av:'AV14MensajeNotificar',fld:'vMENSAJENOTIFICAR',pic:'',type:'svchar'},{av:'AV11Incidenciaid',fld:'vINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15MotivoId',fld:'vMOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A206SolicitudesMail',fld:'SOLICITUDESMAIL',pic:'',type:'svchar'},{av:'A171SolicitudesNombre',fld:'SOLICITUDESNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("'DOACEPTAR'",",oparms:[{av:'AV14MensajeNotificar',fld:'vMENSAJENOTIFICAR',pic:'',type:'svchar'},{av:'AV16NuevoEstadoId',fld:'vNUEVOESTADOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17NuevoEstadoNomb',fld:'vNUEVOESTADONOMB',pic:'',type:'char'},{av:'AV7ContarSolIncl',fld:'vCONTARSOLINCL',pic:'ZZZ9',type:'int'},{av:'AV20ProcSolicitudesID',fld:'vPROCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV6comentario',fld:'vCOMENTARIO',pic:'',type:'char'},{av:'dynavCancelaciontipificacion'},{av:'AV37CancelacionTipificacion',fld:'vCANCELACIONTIPIFICACION',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35SolicitudesMail',fld:'vSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV36SolicitudesNombre',fld:'vSOLICITUDESNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("'DOCANCELAR'","{handler:'E13BA2',iparms:[{av:'AV25UsuariosId',fld:'vUSUARIOSID',pic:'',type:'char'},{av:'AV15MotivoId',fld:'vMOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11Incidenciaid',fld:'vINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOCANCELAR'",",oparms:[]}");
         setEventMetadata("'DOBTNSOLICITUD'","{handler:'E14BA2',iparms:[{av:'AV22SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOBTNSOLICITUD'",",oparms:[]}");
         setEventMetadata("VALIDV_INCIDENCIAESTADO","{handler:'Validv_Incidenciaestado',iparms:[]");
         setEventMetadata("VALIDV_INCIDENCIAESTADO",",oparms:[]}");
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
         wcpOAV25UsuariosId = "";
         wcpOAV33ProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34UsuariosSDT = new SdtUsuariosSDT(context);
         AV26WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9IncidenciaDetalleDesc = "";
         AV12IncidenciaUsrActualizacion = "";
         forbiddenHiddens = new GXProperties();
         AV35SolicitudesMail = "";
         AV36SolicitudesNombre = "";
         AV17NuevoEstadoNomb = "";
         AV14MensajeNotificar = "";
         A206SolicitudesMail = "";
         A171SolicitudesNombre = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV37CancelacionTipificacion = 0;
         AV6comentario = "";
         AV10IncidenciaEstado = "";
         bttBtnaceptar_Jsonclick = "";
         bttBtncancelar_Jsonclick = "";
         bttBtnbtnsolicitud_Jsonclick = "";
         ucToastr1 = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00BA2_A996CancelacionTipificacionId = new long[1] ;
         H00BA2_A997CancelacionTipificacionDescrip = new string[] {""} ;
         H00BA3_A604MotivoId = new long[1] ;
         H00BA3_A616MotivoNombre = new string[] {""} ;
         H00BA4_A996CancelacionTipificacionId = new long[1] ;
         H00BA4_A997CancelacionTipificacionDescrip = new string[] {""} ;
         H00BA5_A604MotivoId = new long[1] ;
         H00BA5_A616MotivoNombre = new string[] {""} ;
         hsh = "";
         AV24Titulo = "";
         AV21SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV5CambioSTSOK = "";
         H00BA6_A603IncidenciaId = new long[1] ;
         H00BA6_A604MotivoId = new long[1] ;
         H00BA6_A615IncidenciaUsrAlta = new string[] {""} ;
         H00BA6_A608IncidenciaEstado = new string[] {""} ;
         H00BA6_A606IncidenciaCodRef = new string[] {""} ;
         A615IncidenciaUsrAlta = "";
         A608IncidenciaEstado = "";
         A606IncidenciaCodRef = "";
         H00BA7_A605IncidenciaDetalleId = new long[1] ;
         H00BA7_A603IncidenciaId = new long[1] ;
         H00BA7_A607IncidenciaDetalleDesc = new string[] {""} ;
         A607IncidenciaDetalleDesc = "";
         AV23TipoNotificacion = "";
         AV18Objeto = "";
         AV19Parametros = "";
         H00BA8_A127SolicitudesID = new long[1] ;
         H00BA8_A206SolicitudesMail = new string[] {""} ;
         H00BA8_n206SolicitudesMail = new bool[] {false} ;
         H00BA8_A171SolicitudesNombre = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00BA9_A604MotivoId = new long[1] ;
         H00BA9_A616MotivoNombre = new string[] {""} ;
         H00BA10_A996CancelacionTipificacionId = new long[1] ;
         H00BA10_A997CancelacionTipificacionDescrip = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarincidencia__default(),
            new Object[][] {
                new Object[] {
               H00BA2_A996CancelacionTipificacionId, H00BA2_A997CancelacionTipificacionDescrip
               }
               , new Object[] {
               H00BA3_A604MotivoId, H00BA3_A616MotivoNombre
               }
               , new Object[] {
               H00BA4_A996CancelacionTipificacionId, H00BA4_A997CancelacionTipificacionDescrip
               }
               , new Object[] {
               H00BA5_A604MotivoId, H00BA5_A616MotivoNombre
               }
               , new Object[] {
               H00BA6_A603IncidenciaId, H00BA6_A604MotivoId, H00BA6_A615IncidenciaUsrAlta, H00BA6_A608IncidenciaEstado, H00BA6_A606IncidenciaCodRef
               }
               , new Object[] {
               H00BA7_A605IncidenciaDetalleId, H00BA7_A603IncidenciaId, H00BA7_A607IncidenciaDetalleDesc
               }
               , new Object[] {
               H00BA8_A127SolicitudesID, H00BA8_A206SolicitudesMail, H00BA8_n206SolicitudesMail, H00BA8_A171SolicitudesNombre
               }
               , new Object[] {
               H00BA9_A604MotivoId, H00BA9_A616MotivoNombre
               }
               , new Object[] {
               H00BA10_A996CancelacionTipificacionId, H00BA10_A997CancelacionTipificacionDescrip
               }
            }
         );
         /* GeneXus formulas. */
         dynavNmotivoid.Enabled = 0;
         edtavIncidenciadetalledesc_Enabled = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV29nMotivoId ;
      private short AV7ContarSolIncl ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavIncidenciadetalledesc_Enabled ;
      private int edtavComentario_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV11Incidenciaid ;
      private long AV15MotivoId ;
      private long wcpOAV11Incidenciaid ;
      private long wcpOAV15MotivoId ;
      private long AV22SolicitudesID ;
      private long AV20ProcSolicitudesID ;
      private long AV16NuevoEstadoId ;
      private long A127SolicitudesID ;
      private long AV37CancelacionTipificacion ;
      private long A603IncidenciaId ;
      private long A604MotivoId ;
      private string AV25UsuariosId ;
      private string AV33ProfesionalesId ;
      private string wcpOAV25UsuariosId ;
      private string wcpOAV33ProfesionalesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV9IncidenciaDetalleDesc ;
      private string AV12IncidenciaUsrActualizacion ;
      private string AV36SolicitudesNombre ;
      private string AV17NuevoEstadoNomb ;
      private string A171SolicitudesNombre ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string dynavNmotivoid_Internalname ;
      private string TempTags ;
      private string dynavNmotivoid_Jsonclick ;
      private string edtavIncidenciadetalledesc_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string dynavCancelaciontipificacion_Internalname ;
      private string dynavCancelaciontipificacion_Jsonclick ;
      private string edtavComentario_Internalname ;
      private string AV6comentario ;
      private string cmbavIncidenciaestado_Internalname ;
      private string AV10IncidenciaEstado ;
      private string cmbavIncidenciaestado_Jsonclick ;
      private string bttBtnaceptar_Internalname ;
      private string bttBtnaceptar_Jsonclick ;
      private string bttBtncancelar_Internalname ;
      private string bttBtncancelar_Jsonclick ;
      private string bttBtnbtnsolicitud_Internalname ;
      private string bttBtnbtnsolicitud_Jsonclick ;
      private string Toastr1_Internalname ;
      private string Innewwindow1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string hsh ;
      private string AV24Titulo ;
      private string AV5CambioSTSOK ;
      private string A615IncidenciaUsrAlta ;
      private string A608IncidenciaEstado ;
      private string A607IncidenciaDetalleDesc ;
      private string AV23TipoNotificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV32Modifica ;
      private bool n206SolicitudesMail ;
      private string AV35SolicitudesMail ;
      private string AV14MensajeNotificar ;
      private string A206SolicitudesMail ;
      private string A606IncidenciaCodRef ;
      private string AV18Objeto ;
      private string AV19Parametros ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucToastr1 ;
      private GXUserControl ucInnewwindow1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_Incidenciaid ;
      private long aP1_MotivoId ;
      private string aP2_UsuariosId ;
      private GXCombobox dynavNmotivoid ;
      private GXCombobox dynavCancelaciontipificacion ;
      private GXCombobox cmbavIncidenciaestado ;
      private SdtUsuariosSDT AV34UsuariosSDT ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV26WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] H00BA2_A996CancelacionTipificacionId ;
      private string[] H00BA2_A997CancelacionTipificacionDescrip ;
      private long[] H00BA3_A604MotivoId ;
      private string[] H00BA3_A616MotivoNombre ;
      private long[] H00BA4_A996CancelacionTipificacionId ;
      private string[] H00BA4_A997CancelacionTipificacionDescrip ;
      private long[] H00BA5_A604MotivoId ;
      private string[] H00BA5_A616MotivoNombre ;
      private SdtSDTCNotificaciones AV21SDTCNotificaciones ;
      private long[] H00BA6_A603IncidenciaId ;
      private long[] H00BA6_A604MotivoId ;
      private string[] H00BA6_A615IncidenciaUsrAlta ;
      private string[] H00BA6_A608IncidenciaEstado ;
      private string[] H00BA6_A606IncidenciaCodRef ;
      private long[] H00BA7_A605IncidenciaDetalleId ;
      private long[] H00BA7_A603IncidenciaId ;
      private string[] H00BA7_A607IncidenciaDetalleDesc ;
      private long[] H00BA8_A127SolicitudesID ;
      private string[] H00BA8_A206SolicitudesMail ;
      private bool[] H00BA8_n206SolicitudesMail ;
      private string[] H00BA8_A171SolicitudesNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00BA9_A604MotivoId ;
      private string[] H00BA9_A616MotivoNombre ;
      private long[] H00BA10_A996CancelacionTipificacionId ;
      private string[] H00BA10_A997CancelacionTipificacionDescrip ;
   }

   public class actualizarincidencia__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00BA2;
          prmH00BA2 = new Object[] {
          };
          Object[] prmH00BA3;
          prmH00BA3 = new Object[] {
          };
          Object[] prmH00BA4;
          prmH00BA4 = new Object[] {
          };
          Object[] prmH00BA5;
          prmH00BA5 = new Object[] {
          };
          Object[] prmH00BA6;
          prmH00BA6 = new Object[] {
          new ParDef("@AV11Incidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV25UsuariosId",GXType.NChar,20,0) ,
          new ParDef("@AV29nMotivoId",GXType.Int16,4,0)
          };
          Object[] prmH00BA7;
          prmH00BA7 = new Object[] {
          new ParDef("@IncidenciaId",GXType.Decimal,18,0)
          };
          Object[] prmH00BA8;
          prmH00BA8 = new Object[] {
          new ParDef("@AV22SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH00BA9;
          prmH00BA9 = new Object[] {
          };
          Object[] prmH00BA10;
          prmH00BA10 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00BA2", "SELECT [CancelacionTipificacionId], [CancelacionTipificacionDescrip] FROM [CancelacionTipificacion] ORDER BY [CancelacionTipificacionDescrip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BA3", "SELECT [MotivoId], [MotivoNombre] FROM [Motivo] ORDER BY [MotivoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BA4", "SELECT [CancelacionTipificacionId], [CancelacionTipificacionDescrip] FROM [CancelacionTipificacion] ORDER BY [CancelacionTipificacionDescrip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BA5", "SELECT [MotivoId], [MotivoNombre] FROM [Motivo] ORDER BY [MotivoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BA6", "SELECT [IncidenciaId], [MotivoId], [IncidenciaUsrAlta], [IncidenciaEstado], [IncidenciaCodRef] FROM [Incidencia] WHERE ([IncidenciaId] = @AV11Incidenciaid) AND (RTRIM(LTRIM([IncidenciaUsrAlta])) = RTRIM(LTRIM(@AV25UsuariosId))) AND ([MotivoId] = @AV29nMotivoId) ORDER BY [IncidenciaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00BA7", "SELECT [IncidenciaDetalleId], [IncidenciaId], [IncidenciaDetalleDesc] FROM [IncidenciaDetalle] WHERE [IncidenciaId] = @IncidenciaId ORDER BY [IncidenciaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00BA8", "SELECT TOP 1 [SolicitudesID], [SolicitudesMail], [SolicitudesNombre] FROM [Solicitudes] WHERE [SolicitudesID] = @AV22SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00BA9", "SELECT [MotivoId], [MotivoNombre] FROM [Motivo] ORDER BY [MotivoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA9,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BA10", "SELECT [CancelacionTipificacionId], [CancelacionTipificacionDescrip] FROM [CancelacionTipificacion] ORDER BY [CancelacionTipificacionDescrip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BA10,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 250);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 250);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 250);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 250);
                return;
       }
    }

 }

}

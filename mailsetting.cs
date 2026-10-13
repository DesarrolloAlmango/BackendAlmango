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
   public class mailsetting : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "mailsetting.aspx")), "mailsetting.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "mailsetting.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7MailId = (long)(Math.Round(NumberUtil.Val( GetPar( "MailId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MailId", StringUtil.LTrimStr( (decimal)(AV7MailId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MailId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Mail Setting", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMailHostSMTP_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public mailsetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mailsetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_MailId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MailId = aP1_MailId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMailEstado = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbMailEstado.ItemCount > 0 )
         {
            A243MailEstado = cmbMailEstado.getValidValue(A243MailEstado);
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMailEstado.CurrentValue = StringUtil.RTrim( A243MailEstado);
            AssignProp("", false, cmbMailEstado_Internalname, "Values", cmbMailEstado.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailHostSMTP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailHostSMTP_Internalname, context.GetMessage( "Host SMTP", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMailHostSMTP_Internalname, StringUtil.RTrim( A249MailHostSMTP), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", 0, 1, edtMailHostSMTP_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailCuentaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailCuentaNombre_Internalname, context.GetMessage( "Nombre de la Cuenta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailCuentaNombre_Internalname, StringUtil.RTrim( A241MailCuentaNombre), StringUtil.RTrim( context.localUtil.Format( A241MailCuentaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailCuentaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailCuentaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailDireccion_Internalname, context.GetMessage( "Direccion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailDireccion_Internalname, A242MailDireccion, StringUtil.RTrim( context.localUtil.Format( A242MailDireccion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailDireccion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailDireccion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailSender_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailSender_Internalname, context.GetMessage( "Mail de Envio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailSender_Internalname, A714MailSender, StringUtil.RTrim( context.localUtil.Format( A714MailSender, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A714MailSender, "", "", "", edtMailSender_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailSender_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailPawword_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailPawword_Internalname, context.GetMessage( "Pawword", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailPawword_Internalname, StringUtil.RTrim( A255MailPawword), StringUtil.RTrim( context.localUtil.Format( A255MailPawword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailPawword_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailPawword_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailPuertoSMTP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailPuertoSMTP_Internalname, context.GetMessage( "Puerto SMTP", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailPuertoSMTP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A248MailPuertoSMTP), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMailPuertoSMTP_Enabled!=0) ? context.localUtil.Format( (decimal)(A248MailPuertoSMTP), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A248MailPuertoSMTP), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailPuertoSMTP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailPuertoSMTP_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbMailEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMailEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMailEstado, cmbMailEstado_Internalname, StringUtil.RTrim( A243MailEstado), 1, cmbMailEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMailEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_MailSetting.htm");
         cmbMailEstado.CurrentValue = StringUtil.RTrim( A243MailEstado);
         AssignProp("", false, cmbMailEstado_Internalname, "Values", (string)(cmbMailEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11162 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z149MailId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z243MailEstado = cgiGet( "Z243MailEstado");
               Z249MailHostSMTP = cgiGet( "Z249MailHostSMTP");
               Z241MailCuentaNombre = cgiGet( "Z241MailCuentaNombre");
               Z242MailDireccion = cgiGet( "Z242MailDireccion");
               Z714MailSender = cgiGet( "Z714MailSender");
               n714MailSender = (String.IsNullOrEmpty(StringUtil.RTrim( A714MailSender)) ? true : false);
               Z255MailPawword = cgiGet( "Z255MailPawword");
               Z248MailPuertoSMTP = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z248MailPuertoSMTP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vMAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
               A249MailHostSMTP = cgiGet( edtMailHostSMTP_Internalname);
               AssignAttri("", false, "A249MailHostSMTP", A249MailHostSMTP);
               A241MailCuentaNombre = cgiGet( edtMailCuentaNombre_Internalname);
               AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
               A242MailDireccion = cgiGet( edtMailDireccion_Internalname);
               AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
               A714MailSender = cgiGet( edtMailSender_Internalname);
               n714MailSender = false;
               AssignAttri("", false, "A714MailSender", A714MailSender);
               n714MailSender = (String.IsNullOrEmpty(StringUtil.RTrim( A714MailSender)) ? true : false);
               A255MailPawword = cgiGet( edtMailPawword_Internalname);
               AssignAttri("", false, "A255MailPawword", A255MailPawword);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMailPuertoSMTP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMailPuertoSMTP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MAILPUERTOSMTP");
                  AnyError = 1;
                  GX_FocusControl = edtMailPuertoSMTP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A248MailPuertoSMTP = 0;
                  AssignAttri("", false, "A248MailPuertoSMTP", StringUtil.LTrimStr( (decimal)(A248MailPuertoSMTP), 10, 0));
               }
               else
               {
                  A248MailPuertoSMTP = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailPuertoSMTP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A248MailPuertoSMTP", StringUtil.LTrimStr( (decimal)(A248MailPuertoSMTP), 10, 0));
               }
               cmbMailEstado.CurrentValue = cgiGet( cmbMailEstado_Internalname);
               A243MailEstado = cgiGet( cmbMailEstado_Internalname);
               AssignAttri("", false, "A243MailEstado", A243MailEstado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MailSetting");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A149MailId != Z149MailId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("mailsetting:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A149MailId = (long)(Math.Round(NumberUtil.Val( GetPar( "MailId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode48 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode48;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound48 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_160( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MAILID");
                        AnyError = 1;
                        GX_FocusControl = edtMailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11162 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12162 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12162 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1648( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1648( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_160( )
      {
         BeforeValidate1648( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1648( ) ;
            }
            else
            {
               CheckExtendedTable1648( ) ;
               CloseExtendedTableCursors1648( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption160( )
      {
      }

      protected void E11162( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailSetting_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailSetting_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailSetting_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV13Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12162( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("mailsettingww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1648( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z243MailEstado = T00163_A243MailEstado[0];
               Z249MailHostSMTP = T00163_A249MailHostSMTP[0];
               Z241MailCuentaNombre = T00163_A241MailCuentaNombre[0];
               Z242MailDireccion = T00163_A242MailDireccion[0];
               Z714MailSender = T00163_A714MailSender[0];
               Z255MailPawword = T00163_A255MailPawword[0];
               Z248MailPuertoSMTP = T00163_A248MailPuertoSMTP[0];
            }
            else
            {
               Z243MailEstado = A243MailEstado;
               Z249MailHostSMTP = A249MailHostSMTP;
               Z241MailCuentaNombre = A241MailCuentaNombre;
               Z242MailDireccion = A242MailDireccion;
               Z714MailSender = A714MailSender;
               Z255MailPawword = A255MailPawword;
               Z248MailPuertoSMTP = A248MailPuertoSMTP;
            }
         }
         if ( GX_JID == -6 )
         {
            Z149MailId = A149MailId;
            Z243MailEstado = A243MailEstado;
            Z249MailHostSMTP = A249MailHostSMTP;
            Z241MailCuentaNombre = A241MailCuentaNombre;
            Z242MailDireccion = A242MailDireccion;
            Z714MailSender = A714MailSender;
            Z255MailPawword = A255MailPawword;
            Z248MailPuertoSMTP = A248MailPuertoSMTP;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMailId_Enabled = 0;
         AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MailId) )
         {
            A149MailId = AV7MailId;
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               A149MailId = AV7MailId;
               AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
            }
         }
         if ( ! (0==AV7MailId) )
         {
            edtMailId_Enabled = 0;
            AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         }
         else
         {
            if ( true )
            {
               edtMailId_Enabled = 1;
               AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
            }
            else
            {
               edtMailId_Enabled = 0;
               AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
            }
         }
         if ( ! (0==AV7MailId) )
         {
            edtMailId_Enabled = 0;
            AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "MailSetting";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
      }

      protected void Load1648( )
      {
         /* Using cursor T00164 */
         pr_default.execute(2, new Object[] {A149MailId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound48 = 1;
            A243MailEstado = T00164_A243MailEstado[0];
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
            A249MailHostSMTP = T00164_A249MailHostSMTP[0];
            AssignAttri("", false, "A249MailHostSMTP", A249MailHostSMTP);
            A241MailCuentaNombre = T00164_A241MailCuentaNombre[0];
            AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
            A242MailDireccion = T00164_A242MailDireccion[0];
            AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
            A714MailSender = T00164_A714MailSender[0];
            n714MailSender = T00164_n714MailSender[0];
            AssignAttri("", false, "A714MailSender", A714MailSender);
            A255MailPawword = T00164_A255MailPawword[0];
            AssignAttri("", false, "A255MailPawword", A255MailPawword);
            A248MailPuertoSMTP = T00164_A248MailPuertoSMTP[0];
            AssignAttri("", false, "A248MailPuertoSMTP", StringUtil.LTrimStr( (decimal)(A248MailPuertoSMTP), 10, 0));
            ZM1648( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1648( ) ;
      }

      protected void OnLoadActions1648( )
      {
         AV13Pgmname = "MailSetting";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable1648( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "MailSetting";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( ! ( GxRegex.IsMatch(A714MailSender,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A714MailSender)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Mail de Envio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MAILSENDER");
            AnyError = 1;
            GX_FocusControl = edtMailSender_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1648( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1648( )
      {
         /* Using cursor T00165 */
         pr_default.execute(3, new Object[] {A149MailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00163 */
         pr_default.execute(1, new Object[] {A149MailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1648( 6) ;
            RcdFound48 = 1;
            A149MailId = T00163_A149MailId[0];
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
            A243MailEstado = T00163_A243MailEstado[0];
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
            A249MailHostSMTP = T00163_A249MailHostSMTP[0];
            AssignAttri("", false, "A249MailHostSMTP", A249MailHostSMTP);
            A241MailCuentaNombre = T00163_A241MailCuentaNombre[0];
            AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
            A242MailDireccion = T00163_A242MailDireccion[0];
            AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
            A714MailSender = T00163_A714MailSender[0];
            n714MailSender = T00163_n714MailSender[0];
            AssignAttri("", false, "A714MailSender", A714MailSender);
            A255MailPawword = T00163_A255MailPawword[0];
            AssignAttri("", false, "A255MailPawword", A255MailPawword);
            A248MailPuertoSMTP = T00163_A248MailPuertoSMTP[0];
            AssignAttri("", false, "A248MailPuertoSMTP", StringUtil.LTrimStr( (decimal)(A248MailPuertoSMTP), 10, 0));
            Z149MailId = A149MailId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1648( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey1648( ) ;
            }
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey1648( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1648( ) ;
         if ( RcdFound48 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound48 = 0;
         /* Using cursor T00166 */
         pr_default.execute(4, new Object[] {A149MailId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00166_A149MailId[0] < A149MailId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00166_A149MailId[0] > A149MailId ) ) )
            {
               A149MailId = T00166_A149MailId[0];
               AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
               RcdFound48 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound48 = 0;
         /* Using cursor T00167 */
         pr_default.execute(5, new Object[] {A149MailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00167_A149MailId[0] > A149MailId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00167_A149MailId[0] < A149MailId ) ) )
            {
               A149MailId = T00167_A149MailId[0];
               AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
               RcdFound48 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1648( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMailHostSMTP_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1648( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( A149MailId != Z149MailId )
               {
                  A149MailId = Z149MailId;
                  AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MAILID");
                  AnyError = 1;
                  GX_FocusControl = edtMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMailHostSMTP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1648( ) ;
                  GX_FocusControl = edtMailHostSMTP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A149MailId != Z149MailId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMailHostSMTP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1648( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MAILID");
                     AnyError = 1;
                     GX_FocusControl = edtMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMailHostSMTP_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1648( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A149MailId != Z149MailId )
         {
            A149MailId = Z149MailId;
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MAILID");
            AnyError = 1;
            GX_FocusControl = edtMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMailHostSMTP_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1648( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00162 */
            pr_default.execute(0, new Object[] {A149MailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z243MailEstado, T00162_A243MailEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z249MailHostSMTP, T00162_A249MailHostSMTP[0]) != 0 ) || ( StringUtil.StrCmp(Z241MailCuentaNombre, T00162_A241MailCuentaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z242MailDireccion, T00162_A242MailDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z714MailSender, T00162_A714MailSender[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z255MailPawword, T00162_A255MailPawword[0]) != 0 ) || ( Z248MailPuertoSMTP != T00162_A248MailPuertoSMTP[0] ) )
            {
               if ( StringUtil.StrCmp(Z243MailEstado, T00162_A243MailEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailEstado");
                  GXUtil.WriteLogRaw("Old: ",Z243MailEstado);
                  GXUtil.WriteLogRaw("Current: ",T00162_A243MailEstado[0]);
               }
               if ( StringUtil.StrCmp(Z249MailHostSMTP, T00162_A249MailHostSMTP[0]) != 0 )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailHostSMTP");
                  GXUtil.WriteLogRaw("Old: ",Z249MailHostSMTP);
                  GXUtil.WriteLogRaw("Current: ",T00162_A249MailHostSMTP[0]);
               }
               if ( StringUtil.StrCmp(Z241MailCuentaNombre, T00162_A241MailCuentaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailCuentaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z241MailCuentaNombre);
                  GXUtil.WriteLogRaw("Current: ",T00162_A241MailCuentaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z242MailDireccion, T00162_A242MailDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z242MailDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00162_A242MailDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z714MailSender, T00162_A714MailSender[0]) != 0 )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailSender");
                  GXUtil.WriteLogRaw("Old: ",Z714MailSender);
                  GXUtil.WriteLogRaw("Current: ",T00162_A714MailSender[0]);
               }
               if ( StringUtil.StrCmp(Z255MailPawword, T00162_A255MailPawword[0]) != 0 )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailPawword");
                  GXUtil.WriteLogRaw("Old: ",Z255MailPawword);
                  GXUtil.WriteLogRaw("Current: ",T00162_A255MailPawword[0]);
               }
               if ( Z248MailPuertoSMTP != T00162_A248MailPuertoSMTP[0] )
               {
                  GXUtil.WriteLog("mailsetting:[seudo value changed for attri]"+"MailPuertoSMTP");
                  GXUtil.WriteLogRaw("Old: ",Z248MailPuertoSMTP);
                  GXUtil.WriteLogRaw("Current: ",T00162_A248MailPuertoSMTP[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1648( )
      {
         BeforeValidate1648( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1648( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1648( 0) ;
            CheckOptimisticConcurrency1648( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1648( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1648( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00168 */
                     pr_default.execute(6, new Object[] {A149MailId, A243MailEstado, A249MailHostSMTP, A241MailCuentaNombre, A242MailDireccion, n714MailSender, A714MailSender, A255MailPawword, A248MailPuertoSMTP});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Mail");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption160( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1648( ) ;
            }
            EndLevel1648( ) ;
         }
         CloseExtendedTableCursors1648( ) ;
      }

      protected void Update1648( )
      {
         BeforeValidate1648( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1648( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1648( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1648( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1648( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00169 */
                     pr_default.execute(7, new Object[] {A243MailEstado, A249MailHostSMTP, A241MailCuentaNombre, A242MailDireccion, n714MailSender, A714MailSender, A255MailPawword, A248MailPuertoSMTP, A149MailId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Mail");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1648( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1648( ) ;
         }
         CloseExtendedTableCursors1648( ) ;
      }

      protected void DeferredUpdate1648( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1648( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1648( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1648( ) ;
            AfterConfirm1648( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1648( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001610 */
                  pr_default.execute(8, new Object[] {A149MailId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Mail");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1648( ) ;
         Gx_mode = sMode48;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1648( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "MailSetting";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001611 */
            pr_default.execute(9, new Object[] {A149MailId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mail Design", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1648( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1648( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("mailsetting",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues160( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("mailsetting",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1648( )
      {
         /* Scan By routine */
         /* Using cursor T001612 */
         pr_default.execute(10);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound48 = 1;
            A149MailId = T001612_A149MailId[0];
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1648( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound48 = 1;
            A149MailId = T001612_A149MailId[0];
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
         }
      }

      protected void ScanEnd1648( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1648( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A243MailEstado = context.GetMessage( context.GetMessage( "HAB", ""), "");
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
         }
      }

      protected void BeforeInsert1648( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1648( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1648( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1648( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1648( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1648( )
      {
         edtMailId_Enabled = 0;
         AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         edtMailHostSMTP_Enabled = 0;
         AssignProp("", false, edtMailHostSMTP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailHostSMTP_Enabled), 5, 0), true);
         edtMailCuentaNombre_Enabled = 0;
         AssignProp("", false, edtMailCuentaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailCuentaNombre_Enabled), 5, 0), true);
         edtMailDireccion_Enabled = 0;
         AssignProp("", false, edtMailDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDireccion_Enabled), 5, 0), true);
         edtMailSender_Enabled = 0;
         AssignProp("", false, edtMailSender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailSender_Enabled), 5, 0), true);
         edtMailPawword_Enabled = 0;
         AssignProp("", false, edtMailPawword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailPawword_Enabled), 5, 0), true);
         edtMailPuertoSMTP_Enabled = 0;
         AssignProp("", false, edtMailPuertoSMTP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailPuertoSMTP_Enabled), 5, 0), true);
         cmbMailEstado.Enabled = 0;
         AssignProp("", false, cmbMailEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMailEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1648( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues160( )
      {
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
         MasterPageObj.master_styles();
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mailsetting.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MailId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mailsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"MailSetting");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("mailsetting:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149MailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z243MailEstado", StringUtil.RTrim( Z243MailEstado));
         GxWebStd.gx_hidden_field( context, "Z249MailHostSMTP", StringUtil.RTrim( Z249MailHostSMTP));
         GxWebStd.gx_hidden_field( context, "Z241MailCuentaNombre", StringUtil.RTrim( Z241MailCuentaNombre));
         GxWebStd.gx_hidden_field( context, "Z242MailDireccion", Z242MailDireccion);
         GxWebStd.gx_hidden_field( context, "Z714MailSender", Z714MailSender);
         GxWebStd.gx_hidden_field( context, "Z255MailPawword", StringUtil.RTrim( Z255MailPawword));
         GxWebStd.gx_hidden_field( context, "Z248MailPuertoSMTP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z248MailPuertoSMTP), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vMAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MailId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mailsetting.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MailId,18,0));
         return formatLink("mailsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "MailSetting" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Mail Setting", "") ;
      }

      protected void InitializeNonKey1648( )
      {
         A243MailEstado = "";
         AssignAttri("", false, "A243MailEstado", A243MailEstado);
         A249MailHostSMTP = "";
         AssignAttri("", false, "A249MailHostSMTP", A249MailHostSMTP);
         A241MailCuentaNombre = "";
         AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
         A242MailDireccion = "";
         AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
         A714MailSender = "";
         n714MailSender = false;
         AssignAttri("", false, "A714MailSender", A714MailSender);
         n714MailSender = (String.IsNullOrEmpty(StringUtil.RTrim( A714MailSender)) ? true : false);
         A255MailPawword = "";
         AssignAttri("", false, "A255MailPawword", A255MailPawword);
         A248MailPuertoSMTP = 0;
         AssignAttri("", false, "A248MailPuertoSMTP", StringUtil.LTrimStr( (decimal)(A248MailPuertoSMTP), 10, 0));
         Z243MailEstado = "";
         Z249MailHostSMTP = "";
         Z241MailCuentaNombre = "";
         Z242MailDireccion = "";
         Z714MailSender = "";
         Z255MailPawword = "";
         Z248MailPuertoSMTP = 0;
      }

      protected void InitAll1648( )
      {
         A149MailId = 0;
         AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
         InitializeNonKey1648( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021113295", true, true, false);
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
         context.AddJavascriptSource("mailsetting.js", "?202673021113295", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMailId_Internalname = "MAILID";
         edtMailHostSMTP_Internalname = "MAILHOSTSMTP";
         edtMailCuentaNombre_Internalname = "MAILCUENTANOMBRE";
         edtMailDireccion_Internalname = "MAILDIRECCION";
         edtMailSender_Internalname = "MAILSENDER";
         edtMailPawword_Internalname = "MAILPAWWORD";
         edtMailPuertoSMTP_Internalname = "MAILPUERTOSMTP";
         cmbMailEstado_Internalname = "MAILESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Mail Setting", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbMailEstado_Jsonclick = "";
         cmbMailEstado.Enabled = 1;
         edtMailPuertoSMTP_Jsonclick = "";
         edtMailPuertoSMTP_Enabled = 1;
         edtMailPawword_Jsonclick = "";
         edtMailPawword_Enabled = 1;
         edtMailSender_Jsonclick = "";
         edtMailSender_Enabled = 1;
         edtMailDireccion_Jsonclick = "";
         edtMailDireccion_Enabled = 1;
         edtMailCuentaNombre_Jsonclick = "";
         edtMailCuentaNombre_Enabled = 1;
         edtMailHostSMTP_Enabled = 1;
         edtMailId_Jsonclick = "";
         edtMailId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Dvpanel_tableattributes_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbMailEstado.Name = "MAILESTADO";
         cmbMailEstado.WebTags = "";
         cmbMailEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMailEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbMailEstado.ItemCount > 0 )
         {
            A243MailEstado = cmbMailEstado.getValidValue(A243MailEstado);
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7MailId',fld:'vMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MailId',fld:'vMAILID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12162',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MAILID","{handler:'Valid_Mailid',iparms:[]");
         setEventMetadata("VALID_MAILID",",oparms:[]}");
         setEventMetadata("VALID_MAILSENDER","{handler:'Valid_Mailsender',iparms:[]");
         setEventMetadata("VALID_MAILSENDER",",oparms:[]}");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z243MailEstado = "";
         Z249MailHostSMTP = "";
         Z241MailCuentaNombre = "";
         Z242MailDireccion = "";
         Z714MailSender = "";
         Z255MailPawword = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A243MailEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A249MailHostSMTP = "";
         A241MailCuentaNombre = "";
         A242MailDireccion = "";
         A714MailSender = "";
         A255MailPawword = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV13Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode48 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00164_A149MailId = new long[1] ;
         T00164_A243MailEstado = new string[] {""} ;
         T00164_A249MailHostSMTP = new string[] {""} ;
         T00164_A241MailCuentaNombre = new string[] {""} ;
         T00164_A242MailDireccion = new string[] {""} ;
         T00164_A714MailSender = new string[] {""} ;
         T00164_n714MailSender = new bool[] {false} ;
         T00164_A255MailPawword = new string[] {""} ;
         T00164_A248MailPuertoSMTP = new long[1] ;
         T00165_A149MailId = new long[1] ;
         T00163_A149MailId = new long[1] ;
         T00163_A243MailEstado = new string[] {""} ;
         T00163_A249MailHostSMTP = new string[] {""} ;
         T00163_A241MailCuentaNombre = new string[] {""} ;
         T00163_A242MailDireccion = new string[] {""} ;
         T00163_A714MailSender = new string[] {""} ;
         T00163_n714MailSender = new bool[] {false} ;
         T00163_A255MailPawword = new string[] {""} ;
         T00163_A248MailPuertoSMTP = new long[1] ;
         T00166_A149MailId = new long[1] ;
         T00167_A149MailId = new long[1] ;
         T00162_A149MailId = new long[1] ;
         T00162_A243MailEstado = new string[] {""} ;
         T00162_A249MailHostSMTP = new string[] {""} ;
         T00162_A241MailCuentaNombre = new string[] {""} ;
         T00162_A242MailDireccion = new string[] {""} ;
         T00162_A714MailSender = new string[] {""} ;
         T00162_n714MailSender = new bool[] {false} ;
         T00162_A255MailPawword = new string[] {""} ;
         T00162_A248MailPuertoSMTP = new long[1] ;
         T001611_A148MailDesignId = new long[1] ;
         T001612_A149MailId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.mailsetting__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mailsetting__default(),
            new Object[][] {
                new Object[] {
               T00162_A149MailId, T00162_A243MailEstado, T00162_A249MailHostSMTP, T00162_A241MailCuentaNombre, T00162_A242MailDireccion, T00162_A714MailSender, T00162_n714MailSender, T00162_A255MailPawword, T00162_A248MailPuertoSMTP
               }
               , new Object[] {
               T00163_A149MailId, T00163_A243MailEstado, T00163_A249MailHostSMTP, T00163_A241MailCuentaNombre, T00163_A242MailDireccion, T00163_A714MailSender, T00163_n714MailSender, T00163_A255MailPawword, T00163_A248MailPuertoSMTP
               }
               , new Object[] {
               T00164_A149MailId, T00164_A243MailEstado, T00164_A249MailHostSMTP, T00164_A241MailCuentaNombre, T00164_A242MailDireccion, T00164_A714MailSender, T00164_n714MailSender, T00164_A255MailPawword, T00164_A248MailPuertoSMTP
               }
               , new Object[] {
               T00165_A149MailId
               }
               , new Object[] {
               T00166_A149MailId
               }
               , new Object[] {
               T00167_A149MailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001611_A148MailDesignId
               }
               , new Object[] {
               T001612_A149MailId
               }
            }
         );
         AV13Pgmname = "MailSetting";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound48 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtMailId_Enabled ;
      private int edtMailHostSMTP_Enabled ;
      private int edtMailCuentaNombre_Enabled ;
      private int edtMailDireccion_Enabled ;
      private int edtMailSender_Enabled ;
      private int edtMailPawword_Enabled ;
      private int edtMailPuertoSMTP_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long wcpOAV7MailId ;
      private long Z149MailId ;
      private long Z248MailPuertoSMTP ;
      private long AV7MailId ;
      private long A149MailId ;
      private long A248MailPuertoSMTP ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z243MailEstado ;
      private string Z249MailHostSMTP ;
      private string Z241MailCuentaNombre ;
      private string Z255MailPawword ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMailHostSMTP_Internalname ;
      private string A243MailEstado ;
      private string cmbMailEstado_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtMailId_Internalname ;
      private string TempTags ;
      private string edtMailId_Jsonclick ;
      private string A249MailHostSMTP ;
      private string edtMailCuentaNombre_Internalname ;
      private string A241MailCuentaNombre ;
      private string edtMailCuentaNombre_Jsonclick ;
      private string edtMailDireccion_Internalname ;
      private string edtMailDireccion_Jsonclick ;
      private string edtMailSender_Internalname ;
      private string edtMailSender_Jsonclick ;
      private string edtMailPawword_Internalname ;
      private string A255MailPawword ;
      private string edtMailPawword_Jsonclick ;
      private string edtMailPuertoSMTP_Internalname ;
      private string edtMailPuertoSMTP_Jsonclick ;
      private string cmbMailEstado_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode48 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n714MailSender ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string Z242MailDireccion ;
      private string Z714MailSender ;
      private string A242MailDireccion ;
      private string A714MailSender ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMailEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00164_A149MailId ;
      private string[] T00164_A243MailEstado ;
      private string[] T00164_A249MailHostSMTP ;
      private string[] T00164_A241MailCuentaNombre ;
      private string[] T00164_A242MailDireccion ;
      private string[] T00164_A714MailSender ;
      private bool[] T00164_n714MailSender ;
      private string[] T00164_A255MailPawword ;
      private long[] T00164_A248MailPuertoSMTP ;
      private long[] T00165_A149MailId ;
      private long[] T00163_A149MailId ;
      private string[] T00163_A243MailEstado ;
      private string[] T00163_A249MailHostSMTP ;
      private string[] T00163_A241MailCuentaNombre ;
      private string[] T00163_A242MailDireccion ;
      private string[] T00163_A714MailSender ;
      private bool[] T00163_n714MailSender ;
      private string[] T00163_A255MailPawword ;
      private long[] T00163_A248MailPuertoSMTP ;
      private long[] T00166_A149MailId ;
      private long[] T00167_A149MailId ;
      private long[] T00162_A149MailId ;
      private string[] T00162_A243MailEstado ;
      private string[] T00162_A249MailHostSMTP ;
      private string[] T00162_A241MailCuentaNombre ;
      private string[] T00162_A242MailDireccion ;
      private string[] T00162_A714MailSender ;
      private bool[] T00162_n714MailSender ;
      private string[] T00162_A255MailPawword ;
      private long[] T00162_A248MailPuertoSMTP ;
      private long[] T001611_A148MailDesignId ;
      private long[] T001612_A149MailId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class mailsetting__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class mailsetting__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00162;
        prmT00162 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00163;
        prmT00163 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00164;
        prmT00164 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00165;
        prmT00165 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00166;
        prmT00166 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00167;
        prmT00167 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00168;
        prmT00168 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0) ,
        new ParDef("@MailEstado",GXType.NChar,3,0) ,
        new ParDef("@MailHostSMTP",GXType.NChar,250,0) ,
        new ParDef("@MailCuentaNombre",GXType.NChar,80,0) ,
        new ParDef("@MailDireccion",GXType.NVarChar,100,0) ,
        new ParDef("@MailSender",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@MailPawword",GXType.NChar,20,0) ,
        new ParDef("@MailPuertoSMTP",GXType.Decimal,10,0)
        };
        Object[] prmT00169;
        prmT00169 = new Object[] {
        new ParDef("@MailEstado",GXType.NChar,3,0) ,
        new ParDef("@MailHostSMTP",GXType.NChar,250,0) ,
        new ParDef("@MailCuentaNombre",GXType.NChar,80,0) ,
        new ParDef("@MailDireccion",GXType.NVarChar,100,0) ,
        new ParDef("@MailSender",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@MailPawword",GXType.NChar,20,0) ,
        new ParDef("@MailPuertoSMTP",GXType.Decimal,10,0) ,
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT001610;
        prmT001610 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT001611;
        prmT001611 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT001612;
        prmT001612 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00162", "SELECT [MailId], [MailEstado], [MailHostSMTP], [MailCuentaNombre], [MailDireccion], [MailSender], [MailPawword], [MailPuertoSMTP] FROM [Mail] WITH (UPDLOCK) WHERE [MailId] = @MailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00162,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00163", "SELECT [MailId], [MailEstado], [MailHostSMTP], [MailCuentaNombre], [MailDireccion], [MailSender], [MailPawword], [MailPuertoSMTP] FROM [Mail] WHERE [MailId] = @MailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00163,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00164", "SELECT TM1.[MailId], TM1.[MailEstado], TM1.[MailHostSMTP], TM1.[MailCuentaNombre], TM1.[MailDireccion], TM1.[MailSender], TM1.[MailPawword], TM1.[MailPuertoSMTP] FROM [Mail] TM1 WHERE TM1.[MailId] = @MailId ORDER BY TM1.[MailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00164,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00165", "SELECT [MailId] FROM [Mail] WHERE [MailId] = @MailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00165,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00166", "SELECT TOP 1 [MailId] FROM [Mail] WHERE ( [MailId] > @MailId) ORDER BY [MailId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00166,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00167", "SELECT TOP 1 [MailId] FROM [Mail] WHERE ( [MailId] < @MailId) ORDER BY [MailId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00167,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00168", "INSERT INTO [Mail]([MailId], [MailEstado], [MailHostSMTP], [MailCuentaNombre], [MailDireccion], [MailSender], [MailPawword], [MailPuertoSMTP]) VALUES(@MailId, @MailEstado, @MailHostSMTP, @MailCuentaNombre, @MailDireccion, @MailSender, @MailPawword, @MailPuertoSMTP)", GxErrorMask.GX_NOMASK,prmT00168)
           ,new CursorDef("T00169", "UPDATE [Mail] SET [MailEstado]=@MailEstado, [MailHostSMTP]=@MailHostSMTP, [MailCuentaNombre]=@MailCuentaNombre, [MailDireccion]=@MailDireccion, [MailSender]=@MailSender, [MailPawword]=@MailPawword, [MailPuertoSMTP]=@MailPuertoSMTP  WHERE [MailId] = @MailId", GxErrorMask.GX_NOMASK,prmT00169)
           ,new CursorDef("T001610", "DELETE FROM [Mail]  WHERE [MailId] = @MailId", GxErrorMask.GX_NOMASK,prmT001610)
           ,new CursorDef("T001611", "SELECT TOP 1 [MailDesignId] FROM [MailDesign] WHERE [MailId] = @MailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001612", "SELECT [MailId] FROM [Mail] ORDER BY [MailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001612,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

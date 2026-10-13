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
   public class usuarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A116PaisID = GetPar( "PaisID");
            AssignAttri("", false, "A116PaisID", A116PaisID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A116PaisID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_notificacion") == 0 )
         {
            gxnrGridlevel_notificacion_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "usuarios.aspx")), "usuarios.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "usuarios.aspx")))) ;
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
                  AV7usuariosId = GetPar( "usuariosId");
                  AssignAttri("", false, "AV7usuariosId", AV7usuariosId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7usuariosId, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "usuarios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtusuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_notificacion_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_notificacion_newrow( ) ;
         /* End function gxnrGridlevel_notificacion_newrow_invoke */
      }

      public usuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_usuariosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7usuariosId = aP1_usuariosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbusuariosTipo = new GXCombobox();
         cmbusuariosEstado = new GXCombobox();
         cmbusuariosNotificacionTipo = new GXCombobox();
         chkusuariosNotificacionNotificado = new GXCheckbox();
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
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
            A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
            AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
            AssignProp("", false, cmbusuariosTipo_Internalname, "Values", cmbusuariosTipo.ToJavascriptSource(), true);
         }
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
            AssignProp("", false, cmbusuariosEstado_Internalname, "Values", cmbusuariosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosId_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosId_Internalname, StringUtil.RTrim( A145usuariosId), StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosId_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NickName", "start", true, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbusuariosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbusuariosTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbusuariosTipo, cmbusuariosTipo_Internalname, StringUtil.RTrim( A225usuariosTipo), 1, cmbusuariosTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbusuariosTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_usuarios.htm");
         cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
         AssignProp("", false, cmbusuariosTipo_Internalname, "Values", (string)(cmbusuariosTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosNombre_Internalname, StringUtil.RTrim( A222usuariosNombre), StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosCorreo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosCorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosCorreo_Internalname, A224usuariosCorreo, StringUtil.RTrim( context.localUtil.Format( A224usuariosCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A224usuariosCorreo, "", "", "", edtusuariosCorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "PaisId", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisID_Enabled, 1, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_usuarios.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_116_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_116_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_116_Internalname, sImgUrl, imgprompt_116_Link, "", "", context.GetTheme( ), imgprompt_116_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, context.GetMessage( "Pais", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, StringUtil.RTrim( A165PaisNombre), StringUtil.RTrim( context.localUtil.Format( A165PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosDireccion_Internalname, context.GetMessage( "Direccion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtusuariosDireccion_Internalname, A230usuariosDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A230usuariosDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", 0, 1, edtusuariosDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgusuariosImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen 800x800", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A266usuariosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000usuariosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.PathToRelativeUrl( A266usuariosImagen));
         GxWebStd.gx_bitmap( context, imgusuariosImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgusuariosImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", "", "", 0, A266usuariosImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_usuarios.htm");
         AssignProp("", false, imgusuariosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.PathToRelativeUrl( A266usuariosImagen)), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A266usuariosImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosPasw_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosPasw_Internalname, context.GetMessage( "Paswword", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosPasw_Internalname, StringUtil.RTrim( A223usuariosPasw), StringUtil.RTrim( context.localUtil.Format( A223usuariosPasw, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosPasw_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosPasw_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Pasword", "start", true, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosCPostal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosCPostal_Internalname, context.GetMessage( "Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosCPostal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A231usuariosCPostal), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtusuariosCPostal_Enabled!=0) ? context.localUtil.Format( (decimal)(A231usuariosCPostal), "ZZZZ9") : context.localUtil.Format( (decimal)(A231usuariosCPostal), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosCPostal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosCPostal_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosTelefono_Internalname, context.GetMessage( "Telefono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A232usuariosTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosTelefono_Internalname, StringUtil.RTrim( A232usuariosTelefono), StringUtil.RTrim( context.localUtil.Format( A232usuariosTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtusuariosTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbusuariosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbusuariosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbusuariosEstado, cmbusuariosEstado_Internalname, StringUtil.RTrim( A226usuariosEstado), 1, cmbusuariosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbusuariosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_usuarios.htm");
         cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
         AssignProp("", false, cmbusuariosEstado_Internalname, "Values", (string)(cmbusuariosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosNumeroIdentidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosNumeroIdentidad_Internalname, context.GetMessage( "Numero de Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosNumeroIdentidad_Internalname, StringUtil.RTrim( A240usuariosNumeroIdentidad), StringUtil.RTrim( context.localUtil.Format( A240usuariosNumeroIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosNumeroIdentidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosNumeroIdentidad_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_usuarios.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_notificacion_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_notificacion( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_usuarios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosEstadoOnOffLine_Internalname, StringUtil.RTrim( A227usuariosEstadoOnOffLine), StringUtil.RTrim( context.localUtil.Format( A227usuariosEstadoOnOffLine, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosEstadoOnOffLine_Jsonclick, 0, "Attribute", "", "", "", "", edtusuariosEstadoOnOffLine_Visible, edtusuariosEstadoOnOffLine_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "Estado", "start", true, "", "HLP_usuarios.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtusuariosFechaEstadoOnOff_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtusuariosFechaEstadoOnOff_Internalname, context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"), context.localUtil.Format( A228usuariosFechaEstadoOnOff, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosFechaEstadoOnOff_Jsonclick, 0, "Attribute", "", "", "", "", edtusuariosFechaEstadoOnOff_Visible, edtusuariosFechaEstadoOnOff_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_usuarios.htm");
         GxWebStd.gx_bitmap( context, edtusuariosFechaEstadoOnOff_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtusuariosFechaEstadoOnOff_Visible==0)||(edtusuariosFechaEstadoOnOff_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtusuariosHoraEstadoOnOff_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtusuariosHoraEstadoOnOff_Internalname, context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A229usuariosHoraEstadoOnOff, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosHoraEstadoOnOff_Jsonclick, 0, "Attribute", "", "", "", "", edtusuariosHoraEstadoOnOff_Visible, edtusuariosHoraEstadoOnOff_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_usuarios.htm");
         GxWebStd.gx_bitmap( context, edtusuariosHoraEstadoOnOff_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtusuariosHoraEstadoOnOff_Visible==0)||(edtusuariosHoraEstadoOnOff_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_notificacion( )
      {
         /*  Grid Control  */
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount46 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_46 = 1;
               ScanStart1446( ) ;
               while ( RcdFound46 != 0 )
               {
                  init_level_properties46( ) ;
                  getByPrimaryKey1446( ) ;
                  AddRow1446( ) ;
                  ScanNext1446( ) ;
               }
               ScanEnd1446( ) ;
               nBlankRcdCount46 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1446( ) ;
            standaloneModal1446( ) ;
            sMode46 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow1446( ) ;
               cmbusuariosNotificacionTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtusuariosNotificacionCodigo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtusuariosNotificacionCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               chkusuariosNotificacionNotificado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkusuariosNotificacionNotificado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkusuariosNotificacionNotificado.Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtusuariosNotificacionDescripcio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtusuariosNotificacionDescripcio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionDescripcio_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtusuariosNotificacionParametros_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtusuariosNotificacionParametros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionParametros_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtusuariosNotificacionObjeto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtusuariosNotificacionObjeto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionObjeto_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtusuariosNotificacionFecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtusuariosNotificacionFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionFecha_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               if ( ( nRcdExists_46 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1446( ) ;
               }
               SendRow1446( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount46 = 5;
            nRcdExists_46 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1446( ) ;
               while ( RcdFound46 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8846( ) ;
                  init_level_properties46( ) ;
                  standaloneNotModal1446( ) ;
                  getByPrimaryKey1446( ) ;
                  standaloneModal1446( ) ;
                  AddRow1446( ) ;
                  ScanNext1446( ) ;
               }
               ScanEnd1446( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode46 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8846( ) ;
            InitAll1446( ) ;
            init_level_properties46( ) ;
            nRcdExists_46 = 0;
            nIsMod_46 = 0;
            nRcdDeleted_46 = 0;
            nBlankRcdCount46 = (short)(nBlankRcdUsr46+nBlankRcdCount46);
            fRowAdded = 0;
            while ( nBlankRcdCount46 > 0 )
            {
               standaloneNotModal1446( ) ;
               standaloneModal1446( ) ;
               AddRow1446( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = cmbusuariosNotificacionTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount46 = (short)(nBlankRcdCount46-1);
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_notificacionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_notificacion", Gridlevel_notificacionContainer, subGridlevel_notificacion_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_notificacionContainerData", Gridlevel_notificacionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_notificacionContainerData"+"V", Gridlevel_notificacionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_notificacionContainerData"+"V"+"\" value='"+Gridlevel_notificacionContainer.GridValuesHidden()+"'/>") ;
         }
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
         E11142 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z145usuariosId = cgiGet( "Z145usuariosId");
               Z225usuariosTipo = cgiGet( "Z225usuariosTipo");
               Z222usuariosNombre = cgiGet( "Z222usuariosNombre");
               Z224usuariosCorreo = cgiGet( "Z224usuariosCorreo");
               Z230usuariosDireccion = cgiGet( "Z230usuariosDireccion");
               Z223usuariosPasw = cgiGet( "Z223usuariosPasw");
               Z231usuariosCPostal = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z231usuariosCPostal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z232usuariosTelefono = cgiGet( "Z232usuariosTelefono");
               Z226usuariosEstado = cgiGet( "Z226usuariosEstado");
               Z227usuariosEstadoOnOffLine = cgiGet( "Z227usuariosEstadoOnOffLine");
               Z228usuariosFechaEstadoOnOff = context.localUtil.CToD( cgiGet( "Z228usuariosFechaEstadoOnOff"), 0);
               Z229usuariosHoraEstadoOnOff = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z229usuariosHoraEstadoOnOff"), 0));
               Z240usuariosNumeroIdentidad = cgiGet( "Z240usuariosNumeroIdentidad");
               Z116PaisID = cgiGet( "Z116PaisID");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N116PaisID = cgiGet( "N116PaisID");
               AV7usuariosId = cgiGet( "vUSUARIOSID");
               AV14Insert_PaisID = cgiGet( "vINSERT_PAISID");
               AssignAttri("", false, "AV14Insert_PaisID", AV14Insert_PaisID);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000usuariosImagen_GXI = cgiGet( "USUARIOSIMAGEN_GXI");
               AV17Pgmname = cgiGet( "vPGMNAME");
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
               A145usuariosId = cgiGet( edtusuariosId_Internalname);
               n145usuariosId = false;
               AssignAttri("", false, "A145usuariosId", A145usuariosId);
               cmbusuariosTipo.Name = cmbusuariosTipo_Internalname;
               cmbusuariosTipo.CurrentValue = cgiGet( cmbusuariosTipo_Internalname);
               A225usuariosTipo = cgiGet( cmbusuariosTipo_Internalname);
               AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
               A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
               AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
               A224usuariosCorreo = cgiGet( edtusuariosCorreo_Internalname);
               AssignAttri("", false, "A224usuariosCorreo", A224usuariosCorreo);
               A116PaisID = cgiGet( edtPaisID_Internalname);
               AssignAttri("", false, "A116PaisID", A116PaisID);
               A165PaisNombre = cgiGet( edtPaisNombre_Internalname);
               AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
               A230usuariosDireccion = cgiGet( edtusuariosDireccion_Internalname);
               AssignAttri("", false, "A230usuariosDireccion", A230usuariosDireccion);
               A266usuariosImagen = cgiGet( imgusuariosImagen_Internalname);
               AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
               A223usuariosPasw = cgiGet( edtusuariosPasw_Internalname);
               AssignAttri("", false, "A223usuariosPasw", A223usuariosPasw);
               if ( ( ( context.localUtil.CToN( cgiGet( edtusuariosCPostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtusuariosCPostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSCPOSTAL");
                  AnyError = 1;
                  GX_FocusControl = edtusuariosCPostal_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A231usuariosCPostal = 0;
                  AssignAttri("", false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
               }
               else
               {
                  A231usuariosCPostal = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtusuariosCPostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
               }
               A232usuariosTelefono = cgiGet( edtusuariosTelefono_Internalname);
               AssignAttri("", false, "A232usuariosTelefono", A232usuariosTelefono);
               cmbusuariosEstado.Name = cmbusuariosEstado_Internalname;
               cmbusuariosEstado.CurrentValue = cgiGet( cmbusuariosEstado_Internalname);
               A226usuariosEstado = cgiGet( cmbusuariosEstado_Internalname);
               AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
               A240usuariosNumeroIdentidad = cgiGet( edtusuariosNumeroIdentidad_Internalname);
               AssignAttri("", false, "A240usuariosNumeroIdentidad", A240usuariosNumeroIdentidad);
               A227usuariosEstadoOnOffLine = cgiGet( edtusuariosEstadoOnOffLine_Internalname);
               AssignAttri("", false, "A227usuariosEstadoOnOffLine", A227usuariosEstadoOnOffLine);
               if ( context.localUtil.VCDate( cgiGet( edtusuariosFechaEstadoOnOff_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( " Fecha Estado On Off", "")}), 1, "USUARIOSFECHAESTADOONOFF");
                  AnyError = 1;
                  GX_FocusControl = edtusuariosFechaEstadoOnOff_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A228usuariosFechaEstadoOnOff = DateTime.MinValue;
                  AssignAttri("", false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
               }
               else
               {
                  A228usuariosFechaEstadoOnOff = context.localUtil.CToD( cgiGet( edtusuariosFechaEstadoOnOff_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtusuariosHoraEstadoOnOff_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {context.GetMessage( "Hora Estado On Off", "")}), 1, "USUARIOSHORAESTADOONOFF");
                  AnyError = 1;
                  GX_FocusControl = edtusuariosHoraEstadoOnOff_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A229usuariosHoraEstadoOnOff = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtusuariosHoraEstadoOnOff_Internalname)));
                  AssignAttri("", false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgusuariosImagen_Internalname, ref  A266usuariosImagen, ref  A40000usuariosImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"usuarios");
               forbiddenHiddens.Add("Insert_PaisID", StringUtil.RTrim( context.localUtil.Format( AV14Insert_PaisID, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("usuarios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A145usuariosId = GetPar( "usuariosId");
                  n145usuariosId = false;
                  AssignAttri("", false, "A145usuariosId", A145usuariosId);
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
                     sMode45 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode45;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound45 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_140( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USUARIOSID");
                        AnyError = 1;
                        GX_FocusControl = edtusuariosId_Internalname;
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
                           E11142 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12142 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12142 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1445( ) ;
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
            DisableAttributes1445( ) ;
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1445( ) ;
            }
            else
            {
               CheckExtendedTable1445( ) ;
               CloseExtendedTableCursors1445( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode45 = Gx_mode;
            CONFIRM_1446( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode45;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1446( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow1446( ) ;
            if ( ( nRcdExists_46 != 0 ) || ( nIsMod_46 != 0 ) )
            {
               GetKey1446( ) ;
               if ( ( nRcdExists_46 == 0 ) && ( nRcdDeleted_46 == 0 ) )
               {
                  if ( RcdFound46 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1446( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1446( ) ;
                        CloseExtendedTableCursors1446( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = cmbusuariosNotificacionTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound46 != 0 )
                  {
                     if ( nRcdDeleted_46 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1446( ) ;
                        Load1446( ) ;
                        BeforeValidate1446( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1446( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_46 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1446( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1446( ) ;
                              CloseExtendedTableCursors1446( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_46 == 0 )
                     {
                        GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = cmbusuariosNotificacionTipo_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( cmbusuariosNotificacionTipo_Internalname, StringUtil.RTrim( A146usuariosNotificacionTipo)) ;
            ChangePostValue( edtusuariosNotificacionCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( chkusuariosNotificacionNotificado_Internalname, ((StringUtil.StrCmp(A234usuariosNotificacionNotificado, "N")==0) ? "N" : "S")) ;
            ChangePostValue( edtusuariosNotificacionDescripcio_Internalname, StringUtil.RTrim( A233usuariosNotificacionDescripcio)) ;
            ChangePostValue( edtusuariosNotificacionParametros_Internalname, StringUtil.RTrim( A420usuariosNotificacionParametros)) ;
            ChangePostValue( edtusuariosNotificacionObjeto_Internalname, StringUtil.RTrim( A421usuariosNotificacionObjeto)) ;
            ChangePostValue( edtusuariosNotificacionFecha_Internalname, context.localUtil.TToC( A235usuariosNotificacionFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z146usuariosNotificacionTipo_"+sGXsfl_88_idx, StringUtil.RTrim( Z146usuariosNotificacionTipo)) ;
            ChangePostValue( "ZT_"+"Z147usuariosNotificacionCodigo_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z234usuariosNotificacionNotificado_"+sGXsfl_88_idx, StringUtil.RTrim( Z234usuariosNotificacionNotificado)) ;
            ChangePostValue( "ZT_"+"Z233usuariosNotificacionDescripcio_"+sGXsfl_88_idx, StringUtil.RTrim( Z233usuariosNotificacionDescripcio)) ;
            ChangePostValue( "ZT_"+"Z420usuariosNotificacionParametros_"+sGXsfl_88_idx, StringUtil.RTrim( Z420usuariosNotificacionParametros)) ;
            ChangePostValue( "ZT_"+"Z421usuariosNotificacionObjeto_"+sGXsfl_88_idx, StringUtil.RTrim( Z421usuariosNotificacionObjeto)) ;
            ChangePostValue( "ZT_"+"Z235usuariosNotificacionFecha_"+sGXsfl_88_idx, context.localUtil.TToC( Z235usuariosNotificacionFecha, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "nRcdDeleted_46_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_46_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_46), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_46_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_46), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_46 != 0 )
            {
               ChangePostValue( "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkusuariosNotificacionNotificado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionDescripcio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionParametros_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionObjeto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionFecha_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption140( )
      {
      }

      protected void E11142( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV17Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "PaisID") == 0 )
               {
                  AV14Insert_PaisID = AV15TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV14Insert_PaisID", AV14Insert_PaisID);
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
         edtusuariosEstadoOnOffLine_Visible = 0;
         AssignProp("", false, edtusuariosEstadoOnOffLine_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosEstadoOnOffLine_Visible), 5, 0), true);
         edtusuariosFechaEstadoOnOff_Visible = 0;
         AssignProp("", false, edtusuariosFechaEstadoOnOff_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosFechaEstadoOnOff_Visible), 5, 0), true);
         edtusuariosHoraEstadoOnOff_Visible = 0;
         AssignProp("", false, edtusuariosHoraEstadoOnOff_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosHoraEstadoOnOff_Visible), 5, 0), true);
      }

      protected void E12142( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("usuariosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1445( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z225usuariosTipo = T00145_A225usuariosTipo[0];
               Z222usuariosNombre = T00145_A222usuariosNombre[0];
               Z224usuariosCorreo = T00145_A224usuariosCorreo[0];
               Z230usuariosDireccion = T00145_A230usuariosDireccion[0];
               Z223usuariosPasw = T00145_A223usuariosPasw[0];
               Z231usuariosCPostal = T00145_A231usuariosCPostal[0];
               Z232usuariosTelefono = T00145_A232usuariosTelefono[0];
               Z226usuariosEstado = T00145_A226usuariosEstado[0];
               Z227usuariosEstadoOnOffLine = T00145_A227usuariosEstadoOnOffLine[0];
               Z228usuariosFechaEstadoOnOff = T00145_A228usuariosFechaEstadoOnOff[0];
               Z229usuariosHoraEstadoOnOff = T00145_A229usuariosHoraEstadoOnOff[0];
               Z240usuariosNumeroIdentidad = T00145_A240usuariosNumeroIdentidad[0];
               Z116PaisID = T00145_A116PaisID[0];
            }
            else
            {
               Z225usuariosTipo = A225usuariosTipo;
               Z222usuariosNombre = A222usuariosNombre;
               Z224usuariosCorreo = A224usuariosCorreo;
               Z230usuariosDireccion = A230usuariosDireccion;
               Z223usuariosPasw = A223usuariosPasw;
               Z231usuariosCPostal = A231usuariosCPostal;
               Z232usuariosTelefono = A232usuariosTelefono;
               Z226usuariosEstado = A226usuariosEstado;
               Z227usuariosEstadoOnOffLine = A227usuariosEstadoOnOffLine;
               Z228usuariosFechaEstadoOnOff = A228usuariosFechaEstadoOnOff;
               Z229usuariosHoraEstadoOnOff = A229usuariosHoraEstadoOnOff;
               Z240usuariosNumeroIdentidad = A240usuariosNumeroIdentidad;
               Z116PaisID = A116PaisID;
            }
         }
         if ( GX_JID == -14 )
         {
            Z145usuariosId = A145usuariosId;
            Z225usuariosTipo = A225usuariosTipo;
            Z222usuariosNombre = A222usuariosNombre;
            Z224usuariosCorreo = A224usuariosCorreo;
            Z230usuariosDireccion = A230usuariosDireccion;
            Z266usuariosImagen = A266usuariosImagen;
            Z40000usuariosImagen_GXI = A40000usuariosImagen_GXI;
            Z223usuariosPasw = A223usuariosPasw;
            Z231usuariosCPostal = A231usuariosCPostal;
            Z232usuariosTelefono = A232usuariosTelefono;
            Z226usuariosEstado = A226usuariosEstado;
            Z227usuariosEstadoOnOffLine = A227usuariosEstadoOnOffLine;
            Z228usuariosFechaEstadoOnOff = A228usuariosFechaEstadoOnOff;
            Z229usuariosHoraEstadoOnOff = A229usuariosHoraEstadoOnOff;
            Z240usuariosNumeroIdentidad = A240usuariosNumeroIdentidad;
            Z116PaisID = A116PaisID;
            Z165PaisNombre = A165PaisNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_116_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"paisprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PAISNOMBRE"+"'), id:'"+"PAISNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7usuariosId)) )
         {
            A145usuariosId = AV7usuariosId;
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7usuariosId)) )
         {
            edtusuariosId_Enabled = 0;
            AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         }
         else
         {
            edtusuariosId_Enabled = 1;
            AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7usuariosId)) )
         {
            edtusuariosId_Enabled = 0;
            AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_PaisID)) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisID_Enabled = 1;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_PaisID)) )
         {
            A116PaisID = AV14Insert_PaisID;
            AssignAttri("", false, "A116PaisID", A116PaisID);
         }
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A226usuariosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A226usuariosEstado = "HAB";
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV17Pgmname = "usuarios";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T00146 */
            pr_default.execute(4, new Object[] {A116PaisID});
            A165PaisNombre = T00146_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            pr_default.close(4);
         }
      }

      protected void Load1445( )
      {
         /* Using cursor T00147 */
         pr_default.execute(5, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound45 = 1;
            A225usuariosTipo = T00147_A225usuariosTipo[0];
            AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
            A222usuariosNombre = T00147_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A224usuariosCorreo = T00147_A224usuariosCorreo[0];
            AssignAttri("", false, "A224usuariosCorreo", A224usuariosCorreo);
            A165PaisNombre = T00147_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            A230usuariosDireccion = T00147_A230usuariosDireccion[0];
            AssignAttri("", false, "A230usuariosDireccion", A230usuariosDireccion);
            A40000usuariosImagen_GXI = T00147_A40000usuariosImagen_GXI[0];
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A223usuariosPasw = T00147_A223usuariosPasw[0];
            AssignAttri("", false, "A223usuariosPasw", A223usuariosPasw);
            A231usuariosCPostal = T00147_A231usuariosCPostal[0];
            AssignAttri("", false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
            A232usuariosTelefono = T00147_A232usuariosTelefono[0];
            AssignAttri("", false, "A232usuariosTelefono", A232usuariosTelefono);
            A226usuariosEstado = T00147_A226usuariosEstado[0];
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
            A227usuariosEstadoOnOffLine = T00147_A227usuariosEstadoOnOffLine[0];
            AssignAttri("", false, "A227usuariosEstadoOnOffLine", A227usuariosEstadoOnOffLine);
            A228usuariosFechaEstadoOnOff = T00147_A228usuariosFechaEstadoOnOff[0];
            AssignAttri("", false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
            A229usuariosHoraEstadoOnOff = T00147_A229usuariosHoraEstadoOnOff[0];
            AssignAttri("", false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A240usuariosNumeroIdentidad = T00147_A240usuariosNumeroIdentidad[0];
            AssignAttri("", false, "A240usuariosNumeroIdentidad", A240usuariosNumeroIdentidad);
            A116PaisID = T00147_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            A266usuariosImagen = T00147_A266usuariosImagen[0];
            AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            ZM1445( -14) ;
         }
         pr_default.close(5);
         OnLoadActions1445( ) ;
      }

      protected void OnLoadActions1445( )
      {
         AV17Pgmname = "usuarios";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
      }

      protected void CheckExtendedTable1445( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV17Pgmname = "usuarios";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         if ( ! ( GxRegex.IsMatch(A224usuariosCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Correo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOSCORREO");
            AnyError = 1;
            GX_FocusControl = edtusuariosCorreo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00146 */
         pr_default.execute(4, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A165PaisNombre = T00146_A165PaisNombre[0];
         AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A226usuariosEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "usuarios Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOSESTADO");
            AnyError = 1;
            GX_FocusControl = cmbusuariosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A228usuariosFechaEstadoOnOff) || ( DateTimeUtil.ResetTime ( A228usuariosFechaEstadoOnOff ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( " Fecha Estado On Off", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOSFECHAESTADOONOFF");
            AnyError = 1;
            GX_FocusControl = edtusuariosFechaEstadoOnOff_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1445( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( string A116PaisID )
      {
         /* Using cursor T00148 */
         pr_default.execute(6, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A165PaisNombre = T00148_A165PaisNombre[0];
         AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A165PaisNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1445( )
      {
         /* Using cursor T00149 */
         pr_default.execute(7, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound45 = 1;
         }
         else
         {
            RcdFound45 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00145 */
         pr_default.execute(3, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1445( 14) ;
            RcdFound45 = 1;
            A145usuariosId = T00145_A145usuariosId[0];
            n145usuariosId = T00145_n145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            A225usuariosTipo = T00145_A225usuariosTipo[0];
            AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
            A222usuariosNombre = T00145_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A224usuariosCorreo = T00145_A224usuariosCorreo[0];
            AssignAttri("", false, "A224usuariosCorreo", A224usuariosCorreo);
            A230usuariosDireccion = T00145_A230usuariosDireccion[0];
            AssignAttri("", false, "A230usuariosDireccion", A230usuariosDireccion);
            A40000usuariosImagen_GXI = T00145_A40000usuariosImagen_GXI[0];
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A223usuariosPasw = T00145_A223usuariosPasw[0];
            AssignAttri("", false, "A223usuariosPasw", A223usuariosPasw);
            A231usuariosCPostal = T00145_A231usuariosCPostal[0];
            AssignAttri("", false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
            A232usuariosTelefono = T00145_A232usuariosTelefono[0];
            AssignAttri("", false, "A232usuariosTelefono", A232usuariosTelefono);
            A226usuariosEstado = T00145_A226usuariosEstado[0];
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
            A227usuariosEstadoOnOffLine = T00145_A227usuariosEstadoOnOffLine[0];
            AssignAttri("", false, "A227usuariosEstadoOnOffLine", A227usuariosEstadoOnOffLine);
            A228usuariosFechaEstadoOnOff = T00145_A228usuariosFechaEstadoOnOff[0];
            AssignAttri("", false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
            A229usuariosHoraEstadoOnOff = T00145_A229usuariosHoraEstadoOnOff[0];
            AssignAttri("", false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A240usuariosNumeroIdentidad = T00145_A240usuariosNumeroIdentidad[0];
            AssignAttri("", false, "A240usuariosNumeroIdentidad", A240usuariosNumeroIdentidad);
            A116PaisID = T00145_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            A266usuariosImagen = T00145_A266usuariosImagen[0];
            AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            Z145usuariosId = A145usuariosId;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1445( ) ;
            if ( AnyError == 1 )
            {
               RcdFound45 = 0;
               InitializeNonKey1445( ) ;
            }
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound45 = 0;
            InitializeNonKey1445( ) ;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1445( ) ;
         if ( RcdFound45 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound45 = 0;
         /* Using cursor T001410 */
         pr_default.execute(8, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001410_A145usuariosId[0], A145usuariosId) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001410_A145usuariosId[0], A145usuariosId) > 0 ) ) )
            {
               A145usuariosId = T001410_A145usuariosId[0];
               n145usuariosId = T001410_n145usuariosId[0];
               AssignAttri("", false, "A145usuariosId", A145usuariosId);
               RcdFound45 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound45 = 0;
         /* Using cursor T001411 */
         pr_default.execute(9, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001411_A145usuariosId[0], A145usuariosId) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001411_A145usuariosId[0], A145usuariosId) < 0 ) ) )
            {
               A145usuariosId = T001411_A145usuariosId[0];
               n145usuariosId = T001411_n145usuariosId[0];
               AssignAttri("", false, "A145usuariosId", A145usuariosId);
               RcdFound45 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1445( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtusuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1445( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound45 == 1 )
            {
               if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
               {
                  A145usuariosId = Z145usuariosId;
                  n145usuariosId = false;
                  AssignAttri("", false, "A145usuariosId", A145usuariosId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOSID");
                  AnyError = 1;
                  GX_FocusControl = edtusuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtusuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1445( ) ;
                  GX_FocusControl = edtusuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtusuariosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1445( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOSID");
                     AnyError = 1;
                     GX_FocusControl = edtusuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtusuariosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1445( ) ;
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
         if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
         {
            A145usuariosId = Z145usuariosId;
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOSID");
            AnyError = 1;
            GX_FocusControl = edtusuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtusuariosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1445( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00144 */
            pr_default.execute(2, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z225usuariosTipo, T00144_A225usuariosTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z222usuariosNombre, T00144_A222usuariosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z224usuariosCorreo, T00144_A224usuariosCorreo[0]) != 0 ) || ( StringUtil.StrCmp(Z230usuariosDireccion, T00144_A230usuariosDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z223usuariosPasw, T00144_A223usuariosPasw[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z231usuariosCPostal != T00144_A231usuariosCPostal[0] ) || ( StringUtil.StrCmp(Z232usuariosTelefono, T00144_A232usuariosTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z226usuariosEstado, T00144_A226usuariosEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z227usuariosEstadoOnOffLine, T00144_A227usuariosEstadoOnOffLine[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z228usuariosFechaEstadoOnOff ) != DateTimeUtil.ResetTime ( T00144_A228usuariosFechaEstadoOnOff[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z229usuariosHoraEstadoOnOff != T00144_A229usuariosHoraEstadoOnOff[0] ) || ( StringUtil.StrCmp(Z240usuariosNumeroIdentidad, T00144_A240usuariosNumeroIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z116PaisID, T00144_A116PaisID[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z225usuariosTipo, T00144_A225usuariosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z225usuariosTipo);
                  GXUtil.WriteLogRaw("Current: ",T00144_A225usuariosTipo[0]);
               }
               if ( StringUtil.StrCmp(Z222usuariosNombre, T00144_A222usuariosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z222usuariosNombre);
                  GXUtil.WriteLogRaw("Current: ",T00144_A222usuariosNombre[0]);
               }
               if ( StringUtil.StrCmp(Z224usuariosCorreo, T00144_A224usuariosCorreo[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosCorreo");
                  GXUtil.WriteLogRaw("Old: ",Z224usuariosCorreo);
                  GXUtil.WriteLogRaw("Current: ",T00144_A224usuariosCorreo[0]);
               }
               if ( StringUtil.StrCmp(Z230usuariosDireccion, T00144_A230usuariosDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z230usuariosDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00144_A230usuariosDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z223usuariosPasw, T00144_A223usuariosPasw[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosPasw");
                  GXUtil.WriteLogRaw("Old: ",Z223usuariosPasw);
                  GXUtil.WriteLogRaw("Current: ",T00144_A223usuariosPasw[0]);
               }
               if ( Z231usuariosCPostal != T00144_A231usuariosCPostal[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosCPostal");
                  GXUtil.WriteLogRaw("Old: ",Z231usuariosCPostal);
                  GXUtil.WriteLogRaw("Current: ",T00144_A231usuariosCPostal[0]);
               }
               if ( StringUtil.StrCmp(Z232usuariosTelefono, T00144_A232usuariosTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z232usuariosTelefono);
                  GXUtil.WriteLogRaw("Current: ",T00144_A232usuariosTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z226usuariosEstado, T00144_A226usuariosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z226usuariosEstado);
                  GXUtil.WriteLogRaw("Current: ",T00144_A226usuariosEstado[0]);
               }
               if ( StringUtil.StrCmp(Z227usuariosEstadoOnOffLine, T00144_A227usuariosEstadoOnOffLine[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosEstadoOnOffLine");
                  GXUtil.WriteLogRaw("Old: ",Z227usuariosEstadoOnOffLine);
                  GXUtil.WriteLogRaw("Current: ",T00144_A227usuariosEstadoOnOffLine[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z228usuariosFechaEstadoOnOff ) != DateTimeUtil.ResetTime ( T00144_A228usuariosFechaEstadoOnOff[0] ) )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosFechaEstadoOnOff");
                  GXUtil.WriteLogRaw("Old: ",Z228usuariosFechaEstadoOnOff);
                  GXUtil.WriteLogRaw("Current: ",T00144_A228usuariosFechaEstadoOnOff[0]);
               }
               if ( Z229usuariosHoraEstadoOnOff != T00144_A229usuariosHoraEstadoOnOff[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosHoraEstadoOnOff");
                  GXUtil.WriteLogRaw("Old: ",Z229usuariosHoraEstadoOnOff);
                  GXUtil.WriteLogRaw("Current: ",T00144_A229usuariosHoraEstadoOnOff[0]);
               }
               if ( StringUtil.StrCmp(Z240usuariosNumeroIdentidad, T00144_A240usuariosNumeroIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNumeroIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z240usuariosNumeroIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T00144_A240usuariosNumeroIdentidad[0]);
               }
               if ( StringUtil.StrCmp(Z116PaisID, T00144_A116PaisID[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"PaisID");
                  GXUtil.WriteLogRaw("Old: ",Z116PaisID);
                  GXUtil.WriteLogRaw("Current: ",T00144_A116PaisID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1445( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1445( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1445( 0) ;
            CheckOptimisticConcurrency1445( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1445( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1445( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001412 */
                     pr_default.execute(10, new Object[] {n145usuariosId, A145usuariosId, A225usuariosTipo, A222usuariosNombre, A224usuariosCorreo, A230usuariosDireccion, A266usuariosImagen, A40000usuariosImagen_GXI, A223usuariosPasw, A231usuariosCPostal, A232usuariosTelefono, A226usuariosEstado, A227usuariosEstadoOnOffLine, A228usuariosFechaEstadoOnOff, A229usuariosHoraEstadoOnOff, A240usuariosNumeroIdentidad, A116PaisID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("usuarios");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ProcessLevel1445( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption140( ) ;
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
            else
            {
               Load1445( ) ;
            }
            EndLevel1445( ) ;
         }
         CloseExtendedTableCursors1445( ) ;
      }

      protected void Update1445( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1445( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1445( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1445( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1445( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001413 */
                     pr_default.execute(11, new Object[] {A225usuariosTipo, A222usuariosNombre, A224usuariosCorreo, A230usuariosDireccion, A223usuariosPasw, A231usuariosCPostal, A232usuariosTelefono, A226usuariosEstado, A227usuariosEstadoOnOffLine, A228usuariosFechaEstadoOnOff, A229usuariosHoraEstadoOnOff, A240usuariosNumeroIdentidad, A116PaisID, n145usuariosId, A145usuariosId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("usuarios");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1445( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1445( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1445( ) ;
         }
         CloseExtendedTableCursors1445( ) ;
      }

      protected void DeferredUpdate1445( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001414 */
            pr_default.execute(12, new Object[] {A266usuariosImagen, A40000usuariosImagen_GXI, n145usuariosId, A145usuariosId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("usuarios");
         }
      }

      protected void delete( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1445( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1445( ) ;
            AfterConfirm1445( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1445( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1446( ) ;
                  while ( RcdFound46 != 0 )
                  {
                     getByPrimaryKey1446( ) ;
                     Delete1446( ) ;
                     ScanNext1446( ) ;
                  }
                  ScanEnd1446( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001415 */
                     pr_default.execute(13, new Object[] {n145usuariosId, A145usuariosId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("usuarios");
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
         }
         sMode45 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1445( ) ;
         Gx_mode = sMode45;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1445( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "usuarios";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T001416 */
            pr_default.execute(14, new Object[] {A116PaisID});
            A165PaisNombre = T001416_A165PaisNombre[0];
            AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001417 */
            pr_default.execute(15, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Token", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001418 */
            pr_default.execute(16, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "User", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel1446( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow1446( ) ;
            if ( ( nRcdExists_46 != 0 ) || ( nIsMod_46 != 0 ) )
            {
               standaloneNotModal1446( ) ;
               GetKey1446( ) ;
               if ( ( nRcdExists_46 == 0 ) && ( nRcdDeleted_46 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1446( ) ;
               }
               else
               {
                  if ( RcdFound46 != 0 )
                  {
                     if ( ( nRcdDeleted_46 != 0 ) && ( nRcdExists_46 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1446( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_46 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1446( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_46 == 0 )
                     {
                        GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = cmbusuariosNotificacionTipo_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( cmbusuariosNotificacionTipo_Internalname, StringUtil.RTrim( A146usuariosNotificacionTipo)) ;
            ChangePostValue( edtusuariosNotificacionCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( chkusuariosNotificacionNotificado_Internalname, ((StringUtil.StrCmp(A234usuariosNotificacionNotificado, "N")==0) ? "N" : "S")) ;
            ChangePostValue( edtusuariosNotificacionDescripcio_Internalname, StringUtil.RTrim( A233usuariosNotificacionDescripcio)) ;
            ChangePostValue( edtusuariosNotificacionParametros_Internalname, StringUtil.RTrim( A420usuariosNotificacionParametros)) ;
            ChangePostValue( edtusuariosNotificacionObjeto_Internalname, StringUtil.RTrim( A421usuariosNotificacionObjeto)) ;
            ChangePostValue( edtusuariosNotificacionFecha_Internalname, context.localUtil.TToC( A235usuariosNotificacionFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z146usuariosNotificacionTipo_"+sGXsfl_88_idx, StringUtil.RTrim( Z146usuariosNotificacionTipo)) ;
            ChangePostValue( "ZT_"+"Z147usuariosNotificacionCodigo_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z234usuariosNotificacionNotificado_"+sGXsfl_88_idx, StringUtil.RTrim( Z234usuariosNotificacionNotificado)) ;
            ChangePostValue( "ZT_"+"Z233usuariosNotificacionDescripcio_"+sGXsfl_88_idx, StringUtil.RTrim( Z233usuariosNotificacionDescripcio)) ;
            ChangePostValue( "ZT_"+"Z420usuariosNotificacionParametros_"+sGXsfl_88_idx, StringUtil.RTrim( Z420usuariosNotificacionParametros)) ;
            ChangePostValue( "ZT_"+"Z421usuariosNotificacionObjeto_"+sGXsfl_88_idx, StringUtil.RTrim( Z421usuariosNotificacionObjeto)) ;
            ChangePostValue( "ZT_"+"Z235usuariosNotificacionFecha_"+sGXsfl_88_idx, context.localUtil.TToC( Z235usuariosNotificacionFecha, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "nRcdDeleted_46_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_46_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_46), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_46_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_46), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_46 != 0 )
            {
               ChangePostValue( "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkusuariosNotificacionNotificado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionDescripcio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionParametros_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionObjeto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionFecha_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1446( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_46 = 0;
         nIsMod_46 = 0;
         nRcdDeleted_46 = 0;
      }

      protected void ProcessLevel1445( )
      {
         /* Save parent mode. */
         sMode45 = Gx_mode;
         ProcessNestedLevel1446( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode45;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1445( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1445( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(14);
            context.CommitDataStores("usuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues140( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(14);
            context.RollbackDataStores("usuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1445( )
      {
         /* Scan By routine */
         /* Using cursor T001419 */
         pr_default.execute(17);
         RcdFound45 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound45 = 1;
            A145usuariosId = T001419_A145usuariosId[0];
            n145usuariosId = T001419_n145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1445( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound45 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound45 = 1;
            A145usuariosId = T001419_A145usuariosId[0];
            n145usuariosId = T001419_n145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
         }
      }

      protected void ScanEnd1445( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1445( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1445( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1445( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1445( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1445( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1445( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1445( )
      {
         edtusuariosId_Enabled = 0;
         AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         cmbusuariosTipo.Enabled = 0;
         AssignProp("", false, cmbusuariosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosTipo.Enabled), 5, 0), true);
         edtusuariosNombre_Enabled = 0;
         AssignProp("", false, edtusuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNombre_Enabled), 5, 0), true);
         edtusuariosCorreo_Enabled = 0;
         AssignProp("", false, edtusuariosCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosCorreo_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
         edtusuariosDireccion_Enabled = 0;
         AssignProp("", false, edtusuariosDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosDireccion_Enabled), 5, 0), true);
         imgusuariosImagen_Enabled = 0;
         AssignProp("", false, imgusuariosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgusuariosImagen_Enabled), 5, 0), true);
         edtusuariosPasw_Enabled = 0;
         AssignProp("", false, edtusuariosPasw_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosPasw_Enabled), 5, 0), true);
         edtusuariosCPostal_Enabled = 0;
         AssignProp("", false, edtusuariosCPostal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosCPostal_Enabled), 5, 0), true);
         edtusuariosTelefono_Enabled = 0;
         AssignProp("", false, edtusuariosTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosTelefono_Enabled), 5, 0), true);
         cmbusuariosEstado.Enabled = 0;
         AssignProp("", false, cmbusuariosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosEstado.Enabled), 5, 0), true);
         edtusuariosNumeroIdentidad_Enabled = 0;
         AssignProp("", false, edtusuariosNumeroIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNumeroIdentidad_Enabled), 5, 0), true);
         edtusuariosEstadoOnOffLine_Enabled = 0;
         AssignProp("", false, edtusuariosEstadoOnOffLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosEstadoOnOffLine_Enabled), 5, 0), true);
         edtusuariosFechaEstadoOnOff_Enabled = 0;
         AssignProp("", false, edtusuariosFechaEstadoOnOff_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosFechaEstadoOnOff_Enabled), 5, 0), true);
         edtusuariosHoraEstadoOnOff_Enabled = 0;
         AssignProp("", false, edtusuariosHoraEstadoOnOff_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosHoraEstadoOnOff_Enabled), 5, 0), true);
      }

      protected void ZM1446( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z234usuariosNotificacionNotificado = T00143_A234usuariosNotificacionNotificado[0];
               Z233usuariosNotificacionDescripcio = T00143_A233usuariosNotificacionDescripcio[0];
               Z420usuariosNotificacionParametros = T00143_A420usuariosNotificacionParametros[0];
               Z421usuariosNotificacionObjeto = T00143_A421usuariosNotificacionObjeto[0];
               Z235usuariosNotificacionFecha = T00143_A235usuariosNotificacionFecha[0];
            }
            else
            {
               Z234usuariosNotificacionNotificado = A234usuariosNotificacionNotificado;
               Z233usuariosNotificacionDescripcio = A233usuariosNotificacionDescripcio;
               Z420usuariosNotificacionParametros = A420usuariosNotificacionParametros;
               Z421usuariosNotificacionObjeto = A421usuariosNotificacionObjeto;
               Z235usuariosNotificacionFecha = A235usuariosNotificacionFecha;
            }
         }
         if ( GX_JID == -16 )
         {
            Z145usuariosId = A145usuariosId;
            Z146usuariosNotificacionTipo = A146usuariosNotificacionTipo;
            Z147usuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
            Z234usuariosNotificacionNotificado = A234usuariosNotificacionNotificado;
            Z233usuariosNotificacionDescripcio = A233usuariosNotificacionDescripcio;
            Z420usuariosNotificacionParametros = A420usuariosNotificacionParametros;
            Z421usuariosNotificacionObjeto = A421usuariosNotificacionObjeto;
            Z235usuariosNotificacionFecha = A235usuariosNotificacionFecha;
         }
      }

      protected void standaloneNotModal1446( )
      {
      }

      protected void standaloneModal1446( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            cmbusuariosNotificacionTipo.Enabled = 0;
            AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            cmbusuariosNotificacionTipo.Enabled = 1;
            AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtusuariosNotificacionCodigo_Enabled = 0;
            AssignProp("", false, edtusuariosNotificacionCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtusuariosNotificacionCodigo_Enabled = 1;
            AssignProp("", false, edtusuariosNotificacionCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
      }

      protected void Load1446( )
      {
         /* Using cursor T001420 */
         pr_default.execute(18, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound46 = 1;
            A234usuariosNotificacionNotificado = T001420_A234usuariosNotificacionNotificado[0];
            A233usuariosNotificacionDescripcio = T001420_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = T001420_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = T001420_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = T001420_A235usuariosNotificacionFecha[0];
            ZM1446( -16) ;
         }
         pr_default.close(18);
         OnLoadActions1446( ) ;
      }

      protected void OnLoadActions1446( )
      {
      }

      protected void CheckExtendedTable1446( )
      {
         nIsDirty_46 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1446( ) ;
         if ( ! ( (DateTime.MinValue==A235usuariosNotificacionFecha) || ( A235usuariosNotificacionFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GXCCtl = "USUARIOSNOTIFICACIONFECHA_" + sGXsfl_88_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtusuariosNotificacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1446( )
      {
      }

      protected void enableDisable1446( )
      {
      }

      protected void GetKey1446( )
      {
         /* Using cursor T001421 */
         pr_default.execute(19, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey1446( )
      {
         /* Using cursor T00143 */
         pr_default.execute(1, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1446( 16) ;
            RcdFound46 = 1;
            InitializeNonKey1446( ) ;
            A146usuariosNotificacionTipo = T00143_A146usuariosNotificacionTipo[0];
            A147usuariosNotificacionCodigo = T00143_A147usuariosNotificacionCodigo[0];
            A234usuariosNotificacionNotificado = T00143_A234usuariosNotificacionNotificado[0];
            A233usuariosNotificacionDescripcio = T00143_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = T00143_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = T00143_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = T00143_A235usuariosNotificacionFecha[0];
            Z145usuariosId = A145usuariosId;
            Z146usuariosNotificacionTipo = A146usuariosNotificacionTipo;
            Z147usuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1446( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1446( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1446( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1446( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1446( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00142 */
            pr_default.execute(0, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuariosNotificacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z234usuariosNotificacionNotificado, T00142_A234usuariosNotificacionNotificado[0]) != 0 ) || ( StringUtil.StrCmp(Z233usuariosNotificacionDescripcio, T00142_A233usuariosNotificacionDescripcio[0]) != 0 ) || ( StringUtil.StrCmp(Z420usuariosNotificacionParametros, T00142_A420usuariosNotificacionParametros[0]) != 0 ) || ( StringUtil.StrCmp(Z421usuariosNotificacionObjeto, T00142_A421usuariosNotificacionObjeto[0]) != 0 ) || ( Z235usuariosNotificacionFecha != T00142_A235usuariosNotificacionFecha[0] ) )
            {
               if ( StringUtil.StrCmp(Z234usuariosNotificacionNotificado, T00142_A234usuariosNotificacionNotificado[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNotificacionNotificado");
                  GXUtil.WriteLogRaw("Old: ",Z234usuariosNotificacionNotificado);
                  GXUtil.WriteLogRaw("Current: ",T00142_A234usuariosNotificacionNotificado[0]);
               }
               if ( StringUtil.StrCmp(Z233usuariosNotificacionDescripcio, T00142_A233usuariosNotificacionDescripcio[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNotificacionDescripcio");
                  GXUtil.WriteLogRaw("Old: ",Z233usuariosNotificacionDescripcio);
                  GXUtil.WriteLogRaw("Current: ",T00142_A233usuariosNotificacionDescripcio[0]);
               }
               if ( StringUtil.StrCmp(Z420usuariosNotificacionParametros, T00142_A420usuariosNotificacionParametros[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNotificacionParametros");
                  GXUtil.WriteLogRaw("Old: ",Z420usuariosNotificacionParametros);
                  GXUtil.WriteLogRaw("Current: ",T00142_A420usuariosNotificacionParametros[0]);
               }
               if ( StringUtil.StrCmp(Z421usuariosNotificacionObjeto, T00142_A421usuariosNotificacionObjeto[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNotificacionObjeto");
                  GXUtil.WriteLogRaw("Old: ",Z421usuariosNotificacionObjeto);
                  GXUtil.WriteLogRaw("Current: ",T00142_A421usuariosNotificacionObjeto[0]);
               }
               if ( Z235usuariosNotificacionFecha != T00142_A235usuariosNotificacionFecha[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"usuariosNotificacionFecha");
                  GXUtil.WriteLogRaw("Old: ",Z235usuariosNotificacionFecha);
                  GXUtil.WriteLogRaw("Current: ",T00142_A235usuariosNotificacionFecha[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"usuariosNotificacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1446( )
      {
         BeforeValidate1446( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1446( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1446( 0) ;
            CheckOptimisticConcurrency1446( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1446( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1446( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001422 */
                     pr_default.execute(20, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo, A234usuariosNotificacionNotificado, A233usuariosNotificacionDescripcio, A420usuariosNotificacionParametros, A421usuariosNotificacionObjeto, A235usuariosNotificacionFecha});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load1446( ) ;
            }
            EndLevel1446( ) ;
         }
         CloseExtendedTableCursors1446( ) ;
      }

      protected void Update1446( )
      {
         BeforeValidate1446( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1446( ) ;
         }
         if ( ( nIsMod_46 != 0 ) || ( nIsDirty_46 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1446( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1446( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1446( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001423 */
                        pr_default.execute(21, new Object[] {A234usuariosNotificacionNotificado, A233usuariosNotificacionDescripcio, A420usuariosNotificacionParametros, A421usuariosNotificacionObjeto, A235usuariosNotificacionFecha, n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
                        pr_default.close(21);
                        pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
                        if ( (pr_default.getStatus(21) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuariosNotificacion"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1446( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1446( ) ;
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
               EndLevel1446( ) ;
            }
         }
         CloseExtendedTableCursors1446( ) ;
      }

      protected void DeferredUpdate1446( )
      {
      }

      protected void Delete1446( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1446( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1446( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1446( ) ;
            AfterConfirm1446( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1446( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001424 */
                  pr_default.execute(22, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1446( ) ;
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1446( )
      {
         standaloneModal1446( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1446( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1446( )
      {
         /* Scan By routine */
         /* Using cursor T001425 */
         pr_default.execute(23, new Object[] {n145usuariosId, A145usuariosId});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound46 = 1;
            A146usuariosNotificacionTipo = T001425_A146usuariosNotificacionTipo[0];
            A147usuariosNotificacionCodigo = T001425_A147usuariosNotificacionCodigo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1446( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound46 = 1;
            A146usuariosNotificacionTipo = T001425_A146usuariosNotificacionTipo[0];
            A147usuariosNotificacionCodigo = T001425_A147usuariosNotificacionCodigo[0];
         }
      }

      protected void ScanEnd1446( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm1446( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1446( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1446( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1446( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1446( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1446( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1446( )
      {
         cmbusuariosNotificacionTipo.Enabled = 0;
         AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtusuariosNotificacionCodigo_Enabled = 0;
         AssignProp("", false, edtusuariosNotificacionCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         chkusuariosNotificacionNotificado.Enabled = 0;
         AssignProp("", false, chkusuariosNotificacionNotificado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkusuariosNotificacionNotificado.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtusuariosNotificacionDescripcio_Enabled = 0;
         AssignProp("", false, edtusuariosNotificacionDescripcio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionDescripcio_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtusuariosNotificacionParametros_Enabled = 0;
         AssignProp("", false, edtusuariosNotificacionParametros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionParametros_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtusuariosNotificacionObjeto_Enabled = 0;
         AssignProp("", false, edtusuariosNotificacionObjeto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionObjeto_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtusuariosNotificacionFecha_Enabled = 0;
         AssignProp("", false, edtusuariosNotificacionFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionFecha_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes1446( )
      {
      }

      protected void send_integrity_lvl_hashes1445( )
      {
      }

      protected void SubsflControlProps_8846( )
      {
         cmbusuariosNotificacionTipo_Internalname = "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_idx;
         edtusuariosNotificacionCodigo_Internalname = "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_idx;
         chkusuariosNotificacionNotificado_Internalname = "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_idx;
         edtusuariosNotificacionDescripcio_Internalname = "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_idx;
         edtusuariosNotificacionParametros_Internalname = "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_idx;
         edtusuariosNotificacionObjeto_Internalname = "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_idx;
         edtusuariosNotificacionFecha_Internalname = "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8846( )
      {
         cmbusuariosNotificacionTipo_Internalname = "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_fel_idx;
         edtusuariosNotificacionCodigo_Internalname = "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_fel_idx;
         chkusuariosNotificacionNotificado_Internalname = "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_fel_idx;
         edtusuariosNotificacionDescripcio_Internalname = "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_fel_idx;
         edtusuariosNotificacionParametros_Internalname = "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_fel_idx;
         edtusuariosNotificacionObjeto_Internalname = "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_fel_idx;
         edtusuariosNotificacionFecha_Internalname = "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow1446( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8846( ) ;
         SendRow1446( ) ;
      }

      protected void SendRow1446( )
      {
         Gridlevel_notificacionRow = GXWebRow.GetNew(context);
         if ( subGridlevel_notificacion_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_notificacion_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_notificacion_Class, "") != 0 )
            {
               subGridlevel_notificacion_Linesclass = subGridlevel_notificacion_Class+"Odd";
            }
         }
         else if ( subGridlevel_notificacion_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_notificacion_Backstyle = 0;
            subGridlevel_notificacion_Backcolor = subGridlevel_notificacion_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_notificacion_Class, "") != 0 )
            {
               subGridlevel_notificacion_Linesclass = subGridlevel_notificacion_Class+"Uniform";
            }
         }
         else if ( subGridlevel_notificacion_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_notificacion_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_notificacion_Class, "") != 0 )
            {
               subGridlevel_notificacion_Linesclass = subGridlevel_notificacion_Class+"Odd";
            }
            subGridlevel_notificacion_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_notificacion_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_notificacion_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridlevel_notificacion_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_notificacion_Class, "") != 0 )
               {
                  subGridlevel_notificacion_Linesclass = subGridlevel_notificacion_Class+"Even";
               }
            }
            else
            {
               subGridlevel_notificacion_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_notificacion_Class, "") != 0 )
               {
                  subGridlevel_notificacion_Linesclass = subGridlevel_notificacion_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_88_idx;
         cmbusuariosNotificacionTipo.Name = GXCCtl;
         cmbusuariosNotificacionTipo.WebTags = "";
         cmbusuariosNotificacionTipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
         cmbusuariosNotificacionTipo.addItem("T", context.GetMessage( "Tags", ""), 0);
         cmbusuariosNotificacionTipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
         cmbusuariosNotificacionTipo.addItem("C", context.GetMessage( "Correo", ""), 0);
         cmbusuariosNotificacionTipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
         cmbusuariosNotificacionTipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
         if ( cmbusuariosNotificacionTipo.ItemCount > 0 )
         {
            A146usuariosNotificacionTipo = cmbusuariosNotificacionTipo.getValidValue(A146usuariosNotificacionTipo);
         }
         /* ComboBox */
         Gridlevel_notificacionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosNotificacionTipo,(string)cmbusuariosNotificacionTipo_Internalname,StringUtil.RTrim( A146usuariosNotificacionTipo),(short)1,(string)cmbusuariosNotificacionTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbusuariosNotificacionTipo.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"",(bool)true,(short)0});
         cmbusuariosNotificacionTipo.CurrentValue = StringUtil.RTrim( A146usuariosNotificacionTipo);
         AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Values", (string)(cmbusuariosNotificacionTipo.ToJavascriptSource()), !bGXsfl_88_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_notificacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionCodigo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A147usuariosNotificacionCodigo), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtusuariosNotificacionCodigo_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "USUARIOSNOTIFICACIONNOTIFICADO_" + sGXsfl_88_idx;
         chkusuariosNotificacionNotificado.Name = GXCCtl;
         chkusuariosNotificacionNotificado.WebTags = "";
         chkusuariosNotificacionNotificado.Caption = "";
         AssignProp("", false, chkusuariosNotificacionNotificado_Internalname, "TitleCaption", chkusuariosNotificacionNotificado.Caption, !bGXsfl_88_Refreshing);
         chkusuariosNotificacionNotificado.CheckedValue = "N";
         A234usuariosNotificacionNotificado = ((StringUtil.StrCmp(StringUtil.RTrim( A234usuariosNotificacionNotificado), "S")==0) ? "S" : "N");
         Gridlevel_notificacionRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkusuariosNotificacionNotificado_Internalname,(string)A234usuariosNotificacionNotificado,(string)"",(string)"",(short)-1,chkusuariosNotificacionNotificado.Enabled,(string)"S",context.GetMessage( "Notificado", ""),(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_notificacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionDescripcio_Internalname,StringUtil.RTrim( A233usuariosNotificacionDescripcio),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionDescripcio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtusuariosNotificacionDescripcio_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_notificacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionParametros_Internalname,StringUtil.RTrim( A420usuariosNotificacionParametros),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionParametros_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtusuariosNotificacionParametros_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_notificacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionObjeto_Internalname,StringUtil.RTrim( A421usuariosNotificacionObjeto),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionObjeto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtusuariosNotificacionObjeto_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_notificacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionFecha_Internalname,context.localUtil.TToC( A235usuariosNotificacionFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A235usuariosNotificacionFecha, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,95);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtusuariosNotificacionFecha_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_notificacionRow);
         send_integrity_lvl_hashes1446( ) ;
         GXCCtl = "Z146usuariosNotificacionTipo_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z146usuariosNotificacionTipo));
         GXCCtl = "Z147usuariosNotificacionCodigo_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z234usuariosNotificacionNotificado_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z234usuariosNotificacionNotificado));
         GXCCtl = "Z233usuariosNotificacionDescripcio_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z233usuariosNotificacionDescripcio));
         GXCCtl = "Z420usuariosNotificacionParametros_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z420usuariosNotificacionParametros));
         GXCCtl = "Z421usuariosNotificacionObjeto_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z421usuariosNotificacionObjeto));
         GXCCtl = "Z235usuariosNotificacionFecha_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z235usuariosNotificacionFecha, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "nRcdDeleted_46_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_46_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_46), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_46_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_46), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vUSUARIOSID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7usuariosId));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkusuariosNotificacionNotificado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionDescripcio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionParametros_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionObjeto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionFecha_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_notificacionContainer.AddRow(Gridlevel_notificacionRow);
      }

      protected void ReadRow1446( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8846( ) ;
         cmbusuariosNotificacionTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtusuariosNotificacionCodigo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkusuariosNotificacionNotificado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtusuariosNotificacionDescripcio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONDESCRIPCIO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtusuariosNotificacionParametros_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONPARAMETROS_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtusuariosNotificacionObjeto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtusuariosNotificacionFecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOSNOTIFICACIONFECHA_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbusuariosNotificacionTipo.Name = cmbusuariosNotificacionTipo_Internalname;
         cmbusuariosNotificacionTipo.CurrentValue = cgiGet( cmbusuariosNotificacionTipo_Internalname);
         A146usuariosNotificacionTipo = cgiGet( cmbusuariosNotificacionTipo_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtusuariosNotificacionCodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtusuariosNotificacionCodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "USUARIOSNOTIFICACIONCODIGO_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtusuariosNotificacionCodigo_Internalname;
            wbErr = true;
            A147usuariosNotificacionCodigo = 0;
         }
         else
         {
            A147usuariosNotificacionCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtusuariosNotificacionCodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A234usuariosNotificacionNotificado = ((StringUtil.StrCmp(cgiGet( chkusuariosNotificacionNotificado_Internalname), "S")==0) ? "S" : "N");
         A233usuariosNotificacionDescripcio = cgiGet( edtusuariosNotificacionDescripcio_Internalname);
         A420usuariosNotificacionParametros = cgiGet( edtusuariosNotificacionParametros_Internalname);
         A421usuariosNotificacionObjeto = cgiGet( edtusuariosNotificacionObjeto_Internalname);
         if ( context.localUtil.VCDateTime( cgiGet( edtusuariosNotificacionFecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
         {
            GXCCtl = "USUARIOSNOTIFICACIONFECHA_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtusuariosNotificacionFecha_Internalname;
            wbErr = true;
            A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         }
         else
         {
            A235usuariosNotificacionFecha = context.localUtil.CToT( cgiGet( edtusuariosNotificacionFecha_Internalname));
         }
         GXCCtl = "Z146usuariosNotificacionTipo_" + sGXsfl_88_idx;
         Z146usuariosNotificacionTipo = cgiGet( GXCCtl);
         GXCCtl = "Z147usuariosNotificacionCodigo_" + sGXsfl_88_idx;
         Z147usuariosNotificacionCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z234usuariosNotificacionNotificado_" + sGXsfl_88_idx;
         Z234usuariosNotificacionNotificado = cgiGet( GXCCtl);
         GXCCtl = "Z233usuariosNotificacionDescripcio_" + sGXsfl_88_idx;
         Z233usuariosNotificacionDescripcio = cgiGet( GXCCtl);
         GXCCtl = "Z420usuariosNotificacionParametros_" + sGXsfl_88_idx;
         Z420usuariosNotificacionParametros = cgiGet( GXCCtl);
         GXCCtl = "Z421usuariosNotificacionObjeto_" + sGXsfl_88_idx;
         Z421usuariosNotificacionObjeto = cgiGet( GXCCtl);
         GXCCtl = "Z235usuariosNotificacionFecha_" + sGXsfl_88_idx;
         Z235usuariosNotificacionFecha = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "nRcdDeleted_46_" + sGXsfl_88_idx;
         nRcdDeleted_46 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_46_" + sGXsfl_88_idx;
         nRcdExists_46 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_46_" + sGXsfl_88_idx;
         nIsMod_46 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtusuariosNotificacionCodigo_Enabled = edtusuariosNotificacionCodigo_Enabled;
         defcmbusuariosNotificacionTipo_Enabled = cmbusuariosNotificacionTipo.Enabled;
      }

      protected void ConfirmValues140( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8846( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8846( ) ;
            ChangePostValue( "Z146usuariosNotificacionTipo_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z146usuariosNotificacionTipo_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z146usuariosNotificacionTipo_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z147usuariosNotificacionCodigo_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z147usuariosNotificacionCodigo_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z147usuariosNotificacionCodigo_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z234usuariosNotificacionNotificado_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z234usuariosNotificacionNotificado_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z234usuariosNotificacionNotificado_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z233usuariosNotificacionDescripcio_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z233usuariosNotificacionDescripcio_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z233usuariosNotificacionDescripcio_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z420usuariosNotificacionParametros_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z420usuariosNotificacionParametros_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z420usuariosNotificacionParametros_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z421usuariosNotificacionObjeto_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z421usuariosNotificacionObjeto_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z421usuariosNotificacionObjeto_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z235usuariosNotificacionFecha_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z235usuariosNotificacionFecha_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z235usuariosNotificacionFecha_"+sGXsfl_88_idx) ;
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
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
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7usuariosId));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"usuarios");
         forbiddenHiddens.Add("Insert_PaisID", StringUtil.RTrim( context.localUtil.Format( AV14Insert_PaisID, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("usuarios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z145usuariosId", StringUtil.RTrim( Z145usuariosId));
         GxWebStd.gx_hidden_field( context, "Z225usuariosTipo", StringUtil.RTrim( Z225usuariosTipo));
         GxWebStd.gx_hidden_field( context, "Z222usuariosNombre", StringUtil.RTrim( Z222usuariosNombre));
         GxWebStd.gx_hidden_field( context, "Z224usuariosCorreo", Z224usuariosCorreo);
         GxWebStd.gx_hidden_field( context, "Z230usuariosDireccion", Z230usuariosDireccion);
         GxWebStd.gx_hidden_field( context, "Z223usuariosPasw", StringUtil.RTrim( Z223usuariosPasw));
         GxWebStd.gx_hidden_field( context, "Z231usuariosCPostal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z231usuariosCPostal), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z232usuariosTelefono", StringUtil.RTrim( Z232usuariosTelefono));
         GxWebStd.gx_hidden_field( context, "Z226usuariosEstado", StringUtil.RTrim( Z226usuariosEstado));
         GxWebStd.gx_hidden_field( context, "Z227usuariosEstadoOnOffLine", StringUtil.RTrim( Z227usuariosEstadoOnOffLine));
         GxWebStd.gx_hidden_field( context, "Z228usuariosFechaEstadoOnOff", context.localUtil.DToC( Z228usuariosFechaEstadoOnOff, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z229usuariosHoraEstadoOnOff", context.localUtil.TToC( Z229usuariosHoraEstadoOnOff, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z240usuariosNumeroIdentidad", StringUtil.RTrim( Z240usuariosNumeroIdentidad));
         GxWebStd.gx_hidden_field( context, "Z116PaisID", StringUtil.RTrim( Z116PaisID));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N116PaisID", StringUtil.RTrim( A116PaisID));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.RTrim( AV7usuariosId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7usuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.RTrim( AV14Insert_PaisID));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIOSIMAGEN_GXI", A40000usuariosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GXCCtlgxBlob = "USUARIOSIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A266usuariosImagen);
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
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7usuariosId));
         return formatLink("usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "usuarios" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "usuarios", "") ;
      }

      protected void InitializeNonKey1445( )
      {
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         A225usuariosTipo = "";
         AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
         A222usuariosNombre = "";
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         A224usuariosCorreo = "";
         AssignAttri("", false, "A224usuariosCorreo", A224usuariosCorreo);
         A165PaisNombre = "";
         AssignAttri("", false, "A165PaisNombre", A165PaisNombre);
         A230usuariosDireccion = "";
         AssignAttri("", false, "A230usuariosDireccion", A230usuariosDireccion);
         A266usuariosImagen = "";
         AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         A40000usuariosImagen_GXI = "";
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         A223usuariosPasw = "";
         AssignAttri("", false, "A223usuariosPasw", A223usuariosPasw);
         A231usuariosCPostal = 0;
         AssignAttri("", false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
         A232usuariosTelefono = "";
         AssignAttri("", false, "A232usuariosTelefono", A232usuariosTelefono);
         A227usuariosEstadoOnOffLine = "";
         AssignAttri("", false, "A227usuariosEstadoOnOffLine", A227usuariosEstadoOnOffLine);
         A228usuariosFechaEstadoOnOff = DateTime.MinValue;
         AssignAttri("", false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
         A229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A240usuariosNumeroIdentidad = "";
         AssignAttri("", false, "A240usuariosNumeroIdentidad", A240usuariosNumeroIdentidad);
         A226usuariosEstado = "HAB";
         AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         Z225usuariosTipo = "";
         Z222usuariosNombre = "";
         Z224usuariosCorreo = "";
         Z230usuariosDireccion = "";
         Z223usuariosPasw = "";
         Z231usuariosCPostal = 0;
         Z232usuariosTelefono = "";
         Z226usuariosEstado = "";
         Z227usuariosEstadoOnOffLine = "";
         Z228usuariosFechaEstadoOnOff = DateTime.MinValue;
         Z229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         Z240usuariosNumeroIdentidad = "";
         Z116PaisID = "";
      }

      protected void InitAll1445( )
      {
         A145usuariosId = "";
         n145usuariosId = false;
         AssignAttri("", false, "A145usuariosId", A145usuariosId);
         InitializeNonKey1445( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A226usuariosEstado = i226usuariosEstado;
         AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
      }

      protected void InitializeNonKey1446( )
      {
         A234usuariosNotificacionNotificado = "";
         A233usuariosNotificacionDescripcio = "";
         A420usuariosNotificacionParametros = "";
         A421usuariosNotificacionObjeto = "";
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z234usuariosNotificacionNotificado = "";
         Z233usuariosNotificacionDescripcio = "";
         Z420usuariosNotificacionParametros = "";
         Z421usuariosNotificacionObjeto = "";
         Z235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1446( )
      {
         A146usuariosNotificacionTipo = "";
         A147usuariosNotificacionCodigo = 0;
         InitializeNonKey1446( ) ;
      }

      protected void StandaloneModalInsert1446( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932025411", true, true, false);
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
         context.AddJavascriptSource("usuarios.js", "?2026932025411", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties46( )
      {
         edtusuariosNotificacionCodigo_Enabled = defedtusuariosNotificacionCodigo_Enabled;
         AssignProp("", false, edtusuariosNotificacionCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         cmbusuariosNotificacionTipo.Enabled = defcmbusuariosNotificacionTipo_Enabled;
         AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void StartGridControl88( )
      {
         Gridlevel_notificacionContainer.AddObjectProperty("GridName", "Gridlevel_notificacion");
         Gridlevel_notificacionContainer.AddObjectProperty("Header", subGridlevel_notificacion_Header);
         Gridlevel_notificacionContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_notificacionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_notificacionContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A146usuariosNotificacionTipo)));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbusuariosNotificacionTipo.Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, ".", ""))));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionCodigo_Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A234usuariosNotificacionNotificado)));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkusuariosNotificacionNotificado.Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A233usuariosNotificacionDescripcio)));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionDescripcio_Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A420usuariosNotificacionParametros)));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionParametros_Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A421usuariosNotificacionObjeto)));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionObjeto_Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_notificacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A235usuariosNotificacionFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_notificacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNotificacionFecha_Enabled), 5, 0, ".", "")));
         Gridlevel_notificacionContainer.AddColumnProperties(Gridlevel_notificacionColumn);
         Gridlevel_notificacionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Selectedindex), 4, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Allowselection), 1, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Allowhovering), 1, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_notificacionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_notificacion_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtusuariosId_Internalname = "USUARIOSID";
         cmbusuariosTipo_Internalname = "USUARIOSTIPO";
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtusuariosCorreo_Internalname = "USUARIOSCORREO";
         edtPaisID_Internalname = "PAISID";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         edtusuariosDireccion_Internalname = "USUARIOSDIRECCION";
         imgusuariosImagen_Internalname = "USUARIOSIMAGEN";
         edtusuariosPasw_Internalname = "USUARIOSPASW";
         edtusuariosCPostal_Internalname = "USUARIOSCPOSTAL";
         edtusuariosTelefono_Internalname = "USUARIOSTELEFONO";
         cmbusuariosEstado_Internalname = "USUARIOSESTADO";
         edtusuariosNumeroIdentidad_Internalname = "USUARIOSNUMEROIDENTIDAD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         cmbusuariosNotificacionTipo_Internalname = "USUARIOSNOTIFICACIONTIPO";
         edtusuariosNotificacionCodigo_Internalname = "USUARIOSNOTIFICACIONCODIGO";
         chkusuariosNotificacionNotificado_Internalname = "USUARIOSNOTIFICACIONNOTIFICADO";
         edtusuariosNotificacionDescripcio_Internalname = "USUARIOSNOTIFICACIONDESCRIPCIO";
         edtusuariosNotificacionParametros_Internalname = "USUARIOSNOTIFICACIONPARAMETROS";
         edtusuariosNotificacionObjeto_Internalname = "USUARIOSNOTIFICACIONOBJETO";
         edtusuariosNotificacionFecha_Internalname = "USUARIOSNOTIFICACIONFECHA";
         divTableleaflevel_notificacion_Internalname = "TABLELEAFLEVEL_NOTIFICACION";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtusuariosEstadoOnOffLine_Internalname = "USUARIOSESTADOONOFFLINE";
         edtusuariosFechaEstadoOnOff_Internalname = "USUARIOSFECHAESTADOONOFF";
         edtusuariosHoraEstadoOnOff_Internalname = "USUARIOSHORAESTADOONOFF";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_116_Internalname = "PROMPT_116";
         subGridlevel_notificacion_Internalname = "GRIDLEVEL_NOTIFICACION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_notificacion_Allowcollapsing = 0;
         subGridlevel_notificacion_Allowselection = 0;
         subGridlevel_notificacion_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "usuarios", "");
         edtusuariosNotificacionFecha_Jsonclick = "";
         edtusuariosNotificacionObjeto_Jsonclick = "";
         edtusuariosNotificacionParametros_Jsonclick = "";
         edtusuariosNotificacionDescripcio_Jsonclick = "";
         chkusuariosNotificacionNotificado.Caption = "";
         edtusuariosNotificacionCodigo_Jsonclick = "";
         cmbusuariosNotificacionTipo_Jsonclick = "";
         subGridlevel_notificacion_Class = "WorkWith";
         subGridlevel_notificacion_Backcolorstyle = 0;
         edtusuariosNotificacionFecha_Enabled = 1;
         edtusuariosNotificacionObjeto_Enabled = 1;
         edtusuariosNotificacionParametros_Enabled = 1;
         edtusuariosNotificacionDescripcio_Enabled = 1;
         chkusuariosNotificacionNotificado.Enabled = 1;
         edtusuariosNotificacionCodigo_Enabled = 1;
         cmbusuariosNotificacionTipo.Enabled = 1;
         edtusuariosHoraEstadoOnOff_Jsonclick = "";
         edtusuariosHoraEstadoOnOff_Enabled = 1;
         edtusuariosHoraEstadoOnOff_Visible = 1;
         edtusuariosFechaEstadoOnOff_Jsonclick = "";
         edtusuariosFechaEstadoOnOff_Enabled = 1;
         edtusuariosFechaEstadoOnOff_Visible = 1;
         edtusuariosEstadoOnOffLine_Jsonclick = "";
         edtusuariosEstadoOnOffLine_Enabled = 1;
         edtusuariosEstadoOnOffLine_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtusuariosNumeroIdentidad_Jsonclick = "";
         edtusuariosNumeroIdentidad_Enabled = 1;
         cmbusuariosEstado_Jsonclick = "";
         cmbusuariosEstado.Enabled = 1;
         edtusuariosTelefono_Jsonclick = "";
         edtusuariosTelefono_Enabled = 1;
         edtusuariosCPostal_Jsonclick = "";
         edtusuariosCPostal_Enabled = 1;
         edtusuariosPasw_Jsonclick = "";
         edtusuariosPasw_Enabled = 1;
         imgusuariosImagen_Enabled = 1;
         edtusuariosDireccion_Enabled = 1;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 0;
         imgprompt_116_Visible = 1;
         imgprompt_116_Link = "";
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 1;
         edtusuariosCorreo_Jsonclick = "";
         edtusuariosCorreo_Enabled = 1;
         edtusuariosNombre_Jsonclick = "";
         edtusuariosNombre_Enabled = 1;
         cmbusuariosTipo_Jsonclick = "";
         cmbusuariosTipo.Enabled = 1;
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Enabled = 1;
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

      protected void gxnrGridlevel_notificacion_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8846( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1446( ) ;
            standaloneModal1446( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1446( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8846( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_notificacionContainer)) ;
         /* End function gxnrGridlevel_notificacion_newrow */
      }

      protected void init_web_controls( )
      {
         cmbusuariosTipo.Name = "USUARIOSTIPO";
         cmbusuariosTipo.WebTags = "";
         cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
         cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
         cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
         cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
         cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
         cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
         cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
            A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
            AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
         }
         cmbusuariosEstado.Name = "USUARIOSESTADO";
         cmbusuariosEstado.WebTags = "";
         cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A226usuariosEstado)) )
            {
               A226usuariosEstado = "HAB";
               AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
            }
         }
         GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_88_idx;
         cmbusuariosNotificacionTipo.Name = GXCCtl;
         cmbusuariosNotificacionTipo.WebTags = "";
         cmbusuariosNotificacionTipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
         cmbusuariosNotificacionTipo.addItem("T", context.GetMessage( "Tags", ""), 0);
         cmbusuariosNotificacionTipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
         cmbusuariosNotificacionTipo.addItem("C", context.GetMessage( "Correo", ""), 0);
         cmbusuariosNotificacionTipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
         cmbusuariosNotificacionTipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
         if ( cmbusuariosNotificacionTipo.ItemCount > 0 )
         {
            A146usuariosNotificacionTipo = cmbusuariosNotificacionTipo.getValidValue(A146usuariosNotificacionTipo);
         }
         GXCCtl = "USUARIOSNOTIFICACIONNOTIFICADO_" + sGXsfl_88_idx;
         chkusuariosNotificacionNotificado.Name = GXCCtl;
         chkusuariosNotificacionNotificado.WebTags = "";
         chkusuariosNotificacionNotificado.Caption = "";
         AssignProp("", false, chkusuariosNotificacionNotificado_Internalname, "TitleCaption", chkusuariosNotificacionNotificado.Caption, !bGXsfl_88_Refreshing);
         chkusuariosNotificacionNotificado.CheckedValue = "N";
         A234usuariosNotificacionNotificado = ((StringUtil.StrCmp(StringUtil.RTrim( A234usuariosNotificacionNotificado), "S")==0) ? "S" : "N");
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

      public void Valid_Paisid( )
      {
         /* Using cursor T001416 */
         pr_default.execute(14, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
         }
         A165PaisNombre = T001416_A165PaisNombre[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A165PaisNombre", StringUtil.RTrim( A165PaisNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7usuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'AV14Insert_PaisID',fld:'vINSERT_PAISID',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12142',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSCORREO","{handler:'Valid_Usuarioscorreo',iparms:[]");
         setEventMetadata("VALID_USUARIOSCORREO",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'A165PaisNombre',fld:'PAISNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A165PaisNombre',fld:'PAISNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_USUARIOSESTADO","{handler:'Valid_Usuariosestado',iparms:[]");
         setEventMetadata("VALID_USUARIOSESTADO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSFECHAESTADOONOFF","{handler:'Valid_Usuariosfechaestadoonoff',iparms:[]");
         setEventMetadata("VALID_USUARIOSFECHAESTADOONOFF",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOTIFICACIONTIPO","{handler:'Valid_Usuariosnotificaciontipo',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOTIFICACIONTIPO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOTIFICACIONCODIGO","{handler:'Valid_Usuariosnotificacioncodigo',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOTIFICACIONCODIGO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOTIFICACIONFECHA","{handler:'Valid_Usuariosnotificacionfecha',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOTIFICACIONFECHA",",oparms:[]}");
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
         pr_default.close(3);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7usuariosId = "";
         Z145usuariosId = "";
         Z225usuariosTipo = "";
         Z222usuariosNombre = "";
         Z224usuariosCorreo = "";
         Z230usuariosDireccion = "";
         Z223usuariosPasw = "";
         Z232usuariosTelefono = "";
         Z226usuariosEstado = "";
         Z227usuariosEstadoOnOffLine = "";
         Z228usuariosFechaEstadoOnOff = DateTime.MinValue;
         Z229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         Z240usuariosNumeroIdentidad = "";
         Z116PaisID = "";
         N116PaisID = "";
         Z146usuariosNotificacionTipo = "";
         Z234usuariosNotificacionNotificado = "";
         Z233usuariosNotificacionDescripcio = "";
         Z420usuariosNotificacionParametros = "";
         Z421usuariosNotificacionObjeto = "";
         Z235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A116PaisID = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A225usuariosTipo = "";
         A226usuariosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A145usuariosId = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         imgprompt_116_gximage = "";
         sImgUrl = "";
         A165PaisNombre = "";
         A230usuariosDireccion = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         A223usuariosPasw = "";
         gxphoneLink = "";
         A232usuariosTelefono = "";
         A240usuariosNumeroIdentidad = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A227usuariosEstadoOnOffLine = "";
         A228usuariosFechaEstadoOnOff = DateTime.MinValue;
         A229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         Gridlevel_notificacionContainer = new GXWebGrid( context);
         sMode46 = "";
         sStyleString = "";
         AV14Insert_PaisID = "";
         AV17Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode45 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A146usuariosNotificacionTipo = "";
         A234usuariosNotificacionNotificado = "";
         A233usuariosNotificacionDescripcio = "";
         A420usuariosNotificacionParametros = "";
         A421usuariosNotificacionObjeto = "";
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z266usuariosImagen = "";
         Z40000usuariosImagen_GXI = "";
         Z165PaisNombre = "";
         T00146_A165PaisNombre = new string[] {""} ;
         T00147_A145usuariosId = new string[] {""} ;
         T00147_n145usuariosId = new bool[] {false} ;
         T00147_A225usuariosTipo = new string[] {""} ;
         T00147_A222usuariosNombre = new string[] {""} ;
         T00147_A224usuariosCorreo = new string[] {""} ;
         T00147_A165PaisNombre = new string[] {""} ;
         T00147_A230usuariosDireccion = new string[] {""} ;
         T00147_A40000usuariosImagen_GXI = new string[] {""} ;
         T00147_A223usuariosPasw = new string[] {""} ;
         T00147_A231usuariosCPostal = new int[1] ;
         T00147_A232usuariosTelefono = new string[] {""} ;
         T00147_A226usuariosEstado = new string[] {""} ;
         T00147_A227usuariosEstadoOnOffLine = new string[] {""} ;
         T00147_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         T00147_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         T00147_A240usuariosNumeroIdentidad = new string[] {""} ;
         T00147_A116PaisID = new string[] {""} ;
         T00147_A266usuariosImagen = new string[] {""} ;
         T00148_A165PaisNombre = new string[] {""} ;
         T00149_A145usuariosId = new string[] {""} ;
         T00149_n145usuariosId = new bool[] {false} ;
         T00145_A145usuariosId = new string[] {""} ;
         T00145_n145usuariosId = new bool[] {false} ;
         T00145_A225usuariosTipo = new string[] {""} ;
         T00145_A222usuariosNombre = new string[] {""} ;
         T00145_A224usuariosCorreo = new string[] {""} ;
         T00145_A230usuariosDireccion = new string[] {""} ;
         T00145_A40000usuariosImagen_GXI = new string[] {""} ;
         T00145_A223usuariosPasw = new string[] {""} ;
         T00145_A231usuariosCPostal = new int[1] ;
         T00145_A232usuariosTelefono = new string[] {""} ;
         T00145_A226usuariosEstado = new string[] {""} ;
         T00145_A227usuariosEstadoOnOffLine = new string[] {""} ;
         T00145_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         T00145_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         T00145_A240usuariosNumeroIdentidad = new string[] {""} ;
         T00145_A116PaisID = new string[] {""} ;
         T00145_A266usuariosImagen = new string[] {""} ;
         T001410_A145usuariosId = new string[] {""} ;
         T001410_n145usuariosId = new bool[] {false} ;
         T001411_A145usuariosId = new string[] {""} ;
         T001411_n145usuariosId = new bool[] {false} ;
         T00144_A145usuariosId = new string[] {""} ;
         T00144_n145usuariosId = new bool[] {false} ;
         T00144_A225usuariosTipo = new string[] {""} ;
         T00144_A222usuariosNombre = new string[] {""} ;
         T00144_A224usuariosCorreo = new string[] {""} ;
         T00144_A230usuariosDireccion = new string[] {""} ;
         T00144_A40000usuariosImagen_GXI = new string[] {""} ;
         T00144_A223usuariosPasw = new string[] {""} ;
         T00144_A231usuariosCPostal = new int[1] ;
         T00144_A232usuariosTelefono = new string[] {""} ;
         T00144_A226usuariosEstado = new string[] {""} ;
         T00144_A227usuariosEstadoOnOffLine = new string[] {""} ;
         T00144_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         T00144_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         T00144_A240usuariosNumeroIdentidad = new string[] {""} ;
         T00144_A116PaisID = new string[] {""} ;
         T00144_A266usuariosImagen = new string[] {""} ;
         T001416_A165PaisNombre = new string[] {""} ;
         T001417_A899TokenId = new string[] {""} ;
         T001418_A18SecUserId = new long[1] ;
         T001419_A145usuariosId = new string[] {""} ;
         T001419_n145usuariosId = new bool[] {false} ;
         T001420_A145usuariosId = new string[] {""} ;
         T001420_n145usuariosId = new bool[] {false} ;
         T001420_A146usuariosNotificacionTipo = new string[] {""} ;
         T001420_A147usuariosNotificacionCodigo = new long[1] ;
         T001420_A234usuariosNotificacionNotificado = new string[] {""} ;
         T001420_A233usuariosNotificacionDescripcio = new string[] {""} ;
         T001420_A420usuariosNotificacionParametros = new string[] {""} ;
         T001420_A421usuariosNotificacionObjeto = new string[] {""} ;
         T001420_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T001421_A145usuariosId = new string[] {""} ;
         T001421_n145usuariosId = new bool[] {false} ;
         T001421_A146usuariosNotificacionTipo = new string[] {""} ;
         T001421_A147usuariosNotificacionCodigo = new long[1] ;
         T00143_A145usuariosId = new string[] {""} ;
         T00143_n145usuariosId = new bool[] {false} ;
         T00143_A146usuariosNotificacionTipo = new string[] {""} ;
         T00143_A147usuariosNotificacionCodigo = new long[1] ;
         T00143_A234usuariosNotificacionNotificado = new string[] {""} ;
         T00143_A233usuariosNotificacionDescripcio = new string[] {""} ;
         T00143_A420usuariosNotificacionParametros = new string[] {""} ;
         T00143_A421usuariosNotificacionObjeto = new string[] {""} ;
         T00143_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T00142_A145usuariosId = new string[] {""} ;
         T00142_n145usuariosId = new bool[] {false} ;
         T00142_A146usuariosNotificacionTipo = new string[] {""} ;
         T00142_A147usuariosNotificacionCodigo = new long[1] ;
         T00142_A234usuariosNotificacionNotificado = new string[] {""} ;
         T00142_A233usuariosNotificacionDescripcio = new string[] {""} ;
         T00142_A420usuariosNotificacionParametros = new string[] {""} ;
         T00142_A421usuariosNotificacionObjeto = new string[] {""} ;
         T00142_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T001425_A145usuariosId = new string[] {""} ;
         T001425_n145usuariosId = new bool[] {false} ;
         T001425_A146usuariosNotificacionTipo = new string[] {""} ;
         T001425_A147usuariosNotificacionCodigo = new long[1] ;
         Gridlevel_notificacionRow = new GXWebRow();
         subGridlevel_notificacion_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i226usuariosEstado = "";
         Gridlevel_notificacionColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.usuarios__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios__default(),
            new Object[][] {
                new Object[] {
               T00142_A145usuariosId, T00142_A146usuariosNotificacionTipo, T00142_A147usuariosNotificacionCodigo, T00142_A234usuariosNotificacionNotificado, T00142_A233usuariosNotificacionDescripcio, T00142_A420usuariosNotificacionParametros, T00142_A421usuariosNotificacionObjeto, T00142_A235usuariosNotificacionFecha
               }
               , new Object[] {
               T00143_A145usuariosId, T00143_A146usuariosNotificacionTipo, T00143_A147usuariosNotificacionCodigo, T00143_A234usuariosNotificacionNotificado, T00143_A233usuariosNotificacionDescripcio, T00143_A420usuariosNotificacionParametros, T00143_A421usuariosNotificacionObjeto, T00143_A235usuariosNotificacionFecha
               }
               , new Object[] {
               T00144_A145usuariosId, T00144_A225usuariosTipo, T00144_A222usuariosNombre, T00144_A224usuariosCorreo, T00144_A230usuariosDireccion, T00144_A40000usuariosImagen_GXI, T00144_A223usuariosPasw, T00144_A231usuariosCPostal, T00144_A232usuariosTelefono, T00144_A226usuariosEstado,
               T00144_A227usuariosEstadoOnOffLine, T00144_A228usuariosFechaEstadoOnOff, T00144_A229usuariosHoraEstadoOnOff, T00144_A240usuariosNumeroIdentidad, T00144_A116PaisID, T00144_A266usuariosImagen
               }
               , new Object[] {
               T00145_A145usuariosId, T00145_A225usuariosTipo, T00145_A222usuariosNombre, T00145_A224usuariosCorreo, T00145_A230usuariosDireccion, T00145_A40000usuariosImagen_GXI, T00145_A223usuariosPasw, T00145_A231usuariosCPostal, T00145_A232usuariosTelefono, T00145_A226usuariosEstado,
               T00145_A227usuariosEstadoOnOffLine, T00145_A228usuariosFechaEstadoOnOff, T00145_A229usuariosHoraEstadoOnOff, T00145_A240usuariosNumeroIdentidad, T00145_A116PaisID, T00145_A266usuariosImagen
               }
               , new Object[] {
               T00146_A165PaisNombre
               }
               , new Object[] {
               T00147_A145usuariosId, T00147_A225usuariosTipo, T00147_A222usuariosNombre, T00147_A224usuariosCorreo, T00147_A165PaisNombre, T00147_A230usuariosDireccion, T00147_A40000usuariosImagen_GXI, T00147_A223usuariosPasw, T00147_A231usuariosCPostal, T00147_A232usuariosTelefono,
               T00147_A226usuariosEstado, T00147_A227usuariosEstadoOnOffLine, T00147_A228usuariosFechaEstadoOnOff, T00147_A229usuariosHoraEstadoOnOff, T00147_A240usuariosNumeroIdentidad, T00147_A116PaisID, T00147_A266usuariosImagen
               }
               , new Object[] {
               T00148_A165PaisNombre
               }
               , new Object[] {
               T00149_A145usuariosId
               }
               , new Object[] {
               T001410_A145usuariosId
               }
               , new Object[] {
               T001411_A145usuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001416_A165PaisNombre
               }
               , new Object[] {
               T001417_A899TokenId
               }
               , new Object[] {
               T001418_A18SecUserId
               }
               , new Object[] {
               T001419_A145usuariosId
               }
               , new Object[] {
               T001420_A145usuariosId, T001420_A146usuariosNotificacionTipo, T001420_A147usuariosNotificacionCodigo, T001420_A234usuariosNotificacionNotificado, T001420_A233usuariosNotificacionDescripcio, T001420_A420usuariosNotificacionParametros, T001420_A421usuariosNotificacionObjeto, T001420_A235usuariosNotificacionFecha
               }
               , new Object[] {
               T001421_A145usuariosId, T001421_A146usuariosNotificacionTipo, T001421_A147usuariosNotificacionCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001425_A145usuariosId, T001425_A146usuariosNotificacionTipo, T001425_A147usuariosNotificacionCodigo
               }
            }
         );
         AV17Pgmname = "usuarios";
         Z226usuariosEstado = "HAB";
         A226usuariosEstado = "HAB";
         i226usuariosEstado = "HAB";
      }

      private short nRcdDeleted_46 ;
      private short nRcdExists_46 ;
      private short nIsMod_46 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount46 ;
      private short RcdFound46 ;
      private short nBlankRcdUsr46 ;
      private short Gx_BScreen ;
      private short RcdFound45 ;
      private short nIsDirty_46 ;
      private short subGridlevel_notificacion_Backcolorstyle ;
      private short subGridlevel_notificacion_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_notificacion_Allowselection ;
      private short subGridlevel_notificacion_Allowhovering ;
      private short subGridlevel_notificacion_Allowcollapsing ;
      private short subGridlevel_notificacion_Collapsed ;
      private int Z231usuariosCPostal ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int trnEnded ;
      private int edtusuariosId_Enabled ;
      private int edtusuariosNombre_Enabled ;
      private int edtusuariosCorreo_Enabled ;
      private int edtPaisID_Enabled ;
      private int imgprompt_116_Visible ;
      private int edtPaisNombre_Enabled ;
      private int edtusuariosDireccion_Enabled ;
      private int imgusuariosImagen_Enabled ;
      private int edtusuariosPasw_Enabled ;
      private int A231usuariosCPostal ;
      private int edtusuariosCPostal_Enabled ;
      private int edtusuariosTelefono_Enabled ;
      private int edtusuariosNumeroIdentidad_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtusuariosEstadoOnOffLine_Visible ;
      private int edtusuariosEstadoOnOffLine_Enabled ;
      private int edtusuariosFechaEstadoOnOff_Visible ;
      private int edtusuariosFechaEstadoOnOff_Enabled ;
      private int edtusuariosHoraEstadoOnOff_Visible ;
      private int edtusuariosHoraEstadoOnOff_Enabled ;
      private int edtusuariosNotificacionCodigo_Enabled ;
      private int edtusuariosNotificacionDescripcio_Enabled ;
      private int edtusuariosNotificacionParametros_Enabled ;
      private int edtusuariosNotificacionObjeto_Enabled ;
      private int edtusuariosNotificacionFecha_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV18GXV1 ;
      private int subGridlevel_notificacion_Backcolor ;
      private int subGridlevel_notificacion_Allbackcolor ;
      private int defedtusuariosNotificacionCodigo_Enabled ;
      private int defcmbusuariosNotificacionTipo_Enabled ;
      private int idxLst ;
      private int subGridlevel_notificacion_Selectedindex ;
      private int subGridlevel_notificacion_Selectioncolor ;
      private int subGridlevel_notificacion_Hoveringcolor ;
      private long Z147usuariosNotificacionCodigo ;
      private long GRIDLEVEL_NOTIFICACION_nFirstRecordOnPage ;
      private long A147usuariosNotificacionCodigo ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7usuariosId ;
      private string Z145usuariosId ;
      private string Z225usuariosTipo ;
      private string Z222usuariosNombre ;
      private string Z223usuariosPasw ;
      private string Z232usuariosTelefono ;
      private string Z226usuariosEstado ;
      private string Z227usuariosEstadoOnOffLine ;
      private string Z240usuariosNumeroIdentidad ;
      private string Z116PaisID ;
      private string N116PaisID ;
      private string Z146usuariosNotificacionTipo ;
      private string Z234usuariosNotificacionNotificado ;
      private string Z233usuariosNotificacionDescripcio ;
      private string Z420usuariosNotificacionParametros ;
      private string Z421usuariosNotificacionObjeto ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A116PaisID ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7usuariosId ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtusuariosId_Internalname ;
      private string sGXsfl_88_idx="0001" ;
      private string A225usuariosTipo ;
      private string cmbusuariosTipo_Internalname ;
      private string A226usuariosEstado ;
      private string cmbusuariosEstado_Internalname ;
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
      private string TempTags ;
      private string A145usuariosId ;
      private string edtusuariosId_Jsonclick ;
      private string cmbusuariosTipo_Jsonclick ;
      private string edtusuariosNombre_Internalname ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Jsonclick ;
      private string edtusuariosCorreo_Internalname ;
      private string edtusuariosCorreo_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string imgprompt_116_gximage ;
      private string sImgUrl ;
      private string imgprompt_116_Internalname ;
      private string imgprompt_116_Link ;
      private string edtPaisNombre_Internalname ;
      private string A165PaisNombre ;
      private string edtPaisNombre_Jsonclick ;
      private string edtusuariosDireccion_Internalname ;
      private string imgusuariosImagen_Internalname ;
      private string edtusuariosPasw_Internalname ;
      private string A223usuariosPasw ;
      private string edtusuariosPasw_Jsonclick ;
      private string edtusuariosCPostal_Internalname ;
      private string edtusuariosCPostal_Jsonclick ;
      private string edtusuariosTelefono_Internalname ;
      private string gxphoneLink ;
      private string A232usuariosTelefono ;
      private string edtusuariosTelefono_Jsonclick ;
      private string cmbusuariosEstado_Jsonclick ;
      private string edtusuariosNumeroIdentidad_Internalname ;
      private string A240usuariosNumeroIdentidad ;
      private string edtusuariosNumeroIdentidad_Jsonclick ;
      private string divTableleaflevel_notificacion_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtusuariosEstadoOnOffLine_Internalname ;
      private string A227usuariosEstadoOnOffLine ;
      private string edtusuariosEstadoOnOffLine_Jsonclick ;
      private string edtusuariosFechaEstadoOnOff_Internalname ;
      private string edtusuariosFechaEstadoOnOff_Jsonclick ;
      private string edtusuariosHoraEstadoOnOff_Internalname ;
      private string edtusuariosHoraEstadoOnOff_Jsonclick ;
      private string sMode46 ;
      private string cmbusuariosNotificacionTipo_Internalname ;
      private string edtusuariosNotificacionCodigo_Internalname ;
      private string chkusuariosNotificacionNotificado_Internalname ;
      private string edtusuariosNotificacionDescripcio_Internalname ;
      private string edtusuariosNotificacionParametros_Internalname ;
      private string edtusuariosNotificacionObjeto_Internalname ;
      private string edtusuariosNotificacionFecha_Internalname ;
      private string sStyleString ;
      private string subGridlevel_notificacion_Internalname ;
      private string AV14Insert_PaisID ;
      private string AV17Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode45 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A146usuariosNotificacionTipo ;
      private string A234usuariosNotificacionNotificado ;
      private string A233usuariosNotificacionDescripcio ;
      private string A420usuariosNotificacionParametros ;
      private string A421usuariosNotificacionObjeto ;
      private string GXEncryptionTmp ;
      private string Z165PaisNombre ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridlevel_notificacion_Class ;
      private string subGridlevel_notificacion_Linesclass ;
      private string cmbusuariosNotificacionTipo_Jsonclick ;
      private string ROClassString ;
      private string edtusuariosNotificacionCodigo_Jsonclick ;
      private string edtusuariosNotificacionDescripcio_Jsonclick ;
      private string edtusuariosNotificacionParametros_Jsonclick ;
      private string edtusuariosNotificacionObjeto_Jsonclick ;
      private string edtusuariosNotificacionFecha_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i226usuariosEstado ;
      private string subGridlevel_notificacion_Header ;
      private DateTime Z229usuariosHoraEstadoOnOff ;
      private DateTime Z235usuariosNotificacionFecha ;
      private DateTime A229usuariosHoraEstadoOnOff ;
      private DateTime A235usuariosNotificacionFecha ;
      private DateTime Z228usuariosFechaEstadoOnOff ;
      private DateTime A228usuariosFechaEstadoOnOff ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A266usuariosImagen_IsBlob ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n145usuariosId ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string Z224usuariosCorreo ;
      private string Z230usuariosDireccion ;
      private string A224usuariosCorreo ;
      private string A230usuariosDireccion ;
      private string A40000usuariosImagen_GXI ;
      private string Z40000usuariosImagen_GXI ;
      private string A266usuariosImagen ;
      private string Z266usuariosImagen ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_notificacionContainer ;
      private GXWebRow Gridlevel_notificacionRow ;
      private GXWebColumn Gridlevel_notificacionColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbusuariosTipo ;
      private GXCombobox cmbusuariosEstado ;
      private GXCombobox cmbusuariosNotificacionTipo ;
      private GXCheckbox chkusuariosNotificacionNotificado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00146_A165PaisNombre ;
      private string[] T00147_A145usuariosId ;
      private bool[] T00147_n145usuariosId ;
      private string[] T00147_A225usuariosTipo ;
      private string[] T00147_A222usuariosNombre ;
      private string[] T00147_A224usuariosCorreo ;
      private string[] T00147_A165PaisNombre ;
      private string[] T00147_A230usuariosDireccion ;
      private string[] T00147_A40000usuariosImagen_GXI ;
      private string[] T00147_A223usuariosPasw ;
      private int[] T00147_A231usuariosCPostal ;
      private string[] T00147_A232usuariosTelefono ;
      private string[] T00147_A226usuariosEstado ;
      private string[] T00147_A227usuariosEstadoOnOffLine ;
      private DateTime[] T00147_A228usuariosFechaEstadoOnOff ;
      private DateTime[] T00147_A229usuariosHoraEstadoOnOff ;
      private string[] T00147_A240usuariosNumeroIdentidad ;
      private string[] T00147_A116PaisID ;
      private string[] T00147_A266usuariosImagen ;
      private string[] T00148_A165PaisNombre ;
      private string[] T00149_A145usuariosId ;
      private bool[] T00149_n145usuariosId ;
      private string[] T00145_A145usuariosId ;
      private bool[] T00145_n145usuariosId ;
      private string[] T00145_A225usuariosTipo ;
      private string[] T00145_A222usuariosNombre ;
      private string[] T00145_A224usuariosCorreo ;
      private string[] T00145_A230usuariosDireccion ;
      private string[] T00145_A40000usuariosImagen_GXI ;
      private string[] T00145_A223usuariosPasw ;
      private int[] T00145_A231usuariosCPostal ;
      private string[] T00145_A232usuariosTelefono ;
      private string[] T00145_A226usuariosEstado ;
      private string[] T00145_A227usuariosEstadoOnOffLine ;
      private DateTime[] T00145_A228usuariosFechaEstadoOnOff ;
      private DateTime[] T00145_A229usuariosHoraEstadoOnOff ;
      private string[] T00145_A240usuariosNumeroIdentidad ;
      private string[] T00145_A116PaisID ;
      private string[] T00145_A266usuariosImagen ;
      private string[] T001410_A145usuariosId ;
      private bool[] T001410_n145usuariosId ;
      private string[] T001411_A145usuariosId ;
      private bool[] T001411_n145usuariosId ;
      private string[] T00144_A145usuariosId ;
      private bool[] T00144_n145usuariosId ;
      private string[] T00144_A225usuariosTipo ;
      private string[] T00144_A222usuariosNombre ;
      private string[] T00144_A224usuariosCorreo ;
      private string[] T00144_A230usuariosDireccion ;
      private string[] T00144_A40000usuariosImagen_GXI ;
      private string[] T00144_A223usuariosPasw ;
      private int[] T00144_A231usuariosCPostal ;
      private string[] T00144_A232usuariosTelefono ;
      private string[] T00144_A226usuariosEstado ;
      private string[] T00144_A227usuariosEstadoOnOffLine ;
      private DateTime[] T00144_A228usuariosFechaEstadoOnOff ;
      private DateTime[] T00144_A229usuariosHoraEstadoOnOff ;
      private string[] T00144_A240usuariosNumeroIdentidad ;
      private string[] T00144_A116PaisID ;
      private string[] T00144_A266usuariosImagen ;
      private string[] T001416_A165PaisNombre ;
      private string[] T001417_A899TokenId ;
      private long[] T001418_A18SecUserId ;
      private string[] T001419_A145usuariosId ;
      private bool[] T001419_n145usuariosId ;
      private string[] T001420_A145usuariosId ;
      private bool[] T001420_n145usuariosId ;
      private string[] T001420_A146usuariosNotificacionTipo ;
      private long[] T001420_A147usuariosNotificacionCodigo ;
      private string[] T001420_A234usuariosNotificacionNotificado ;
      private string[] T001420_A233usuariosNotificacionDescripcio ;
      private string[] T001420_A420usuariosNotificacionParametros ;
      private string[] T001420_A421usuariosNotificacionObjeto ;
      private DateTime[] T001420_A235usuariosNotificacionFecha ;
      private string[] T001421_A145usuariosId ;
      private bool[] T001421_n145usuariosId ;
      private string[] T001421_A146usuariosNotificacionTipo ;
      private long[] T001421_A147usuariosNotificacionCodigo ;
      private string[] T00143_A145usuariosId ;
      private bool[] T00143_n145usuariosId ;
      private string[] T00143_A146usuariosNotificacionTipo ;
      private long[] T00143_A147usuariosNotificacionCodigo ;
      private string[] T00143_A234usuariosNotificacionNotificado ;
      private string[] T00143_A233usuariosNotificacionDescripcio ;
      private string[] T00143_A420usuariosNotificacionParametros ;
      private string[] T00143_A421usuariosNotificacionObjeto ;
      private DateTime[] T00143_A235usuariosNotificacionFecha ;
      private string[] T00142_A145usuariosId ;
      private bool[] T00142_n145usuariosId ;
      private string[] T00142_A146usuariosNotificacionTipo ;
      private long[] T00142_A147usuariosNotificacionCodigo ;
      private string[] T00142_A234usuariosNotificacionNotificado ;
      private string[] T00142_A233usuariosNotificacionDescripcio ;
      private string[] T00142_A420usuariosNotificacionParametros ;
      private string[] T00142_A421usuariosNotificacionObjeto ;
      private DateTime[] T00142_A235usuariosNotificacionFecha ;
      private string[] T001425_A145usuariosId ;
      private bool[] T001425_n145usuariosId ;
      private string[] T001425_A146usuariosNotificacionTipo ;
      private long[] T001425_A147usuariosNotificacionCodigo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class usuarios__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class usuarios__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00142;
        prmT00142 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmT00143;
        prmT00143 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmT00144;
        prmT00144 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00145;
        prmT00145 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00146;
        prmT00146 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT00147;
        prmT00147 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00148;
        prmT00148 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT00149;
        prmT00149 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001410;
        prmT001410 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001411;
        prmT001411 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001412;
        prmT001412 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNombre",GXType.NChar,80,0) ,
        new ParDef("@usuariosCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@usuariosDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@usuariosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@usuariosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="usuarios", Fld="usuariosImagen"} ,
        new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
        new ParDef("@usuariosCPostal",GXType.Int32,5,0) ,
        new ParDef("@usuariosTelefono",GXType.NChar,20,0) ,
        new ParDef("@usuariosEstado",GXType.NChar,3,0) ,
        new ParDef("@usuariosEstadoOnOffLine",GXType.NChar,3,0) ,
        new ParDef("@usuariosFechaEstadoOnOff",GXType.Date,8,0) ,
        new ParDef("@usuariosHoraEstadoOnOff",GXType.DateTime,0,5) ,
        new ParDef("@usuariosNumeroIdentidad",GXType.NChar,20,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT001413;
        prmT001413 = new Object[] {
        new ParDef("@usuariosTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNombre",GXType.NChar,80,0) ,
        new ParDef("@usuariosCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@usuariosDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
        new ParDef("@usuariosCPostal",GXType.Int32,5,0) ,
        new ParDef("@usuariosTelefono",GXType.NChar,20,0) ,
        new ParDef("@usuariosEstado",GXType.NChar,3,0) ,
        new ParDef("@usuariosEstadoOnOffLine",GXType.NChar,3,0) ,
        new ParDef("@usuariosFechaEstadoOnOff",GXType.Date,8,0) ,
        new ParDef("@usuariosHoraEstadoOnOff",GXType.DateTime,0,5) ,
        new ParDef("@usuariosNumeroIdentidad",GXType.NChar,20,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001414;
        prmT001414 = new Object[] {
        new ParDef("@usuariosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@usuariosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="usuarios", Fld="usuariosImagen"} ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001415;
        prmT001415 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001416;
        prmT001416 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmT001417;
        prmT001417 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001418;
        prmT001418 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001419;
        prmT001419 = new Object[] {
        };
        Object[] prmT001420;
        prmT001420 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmT001421;
        prmT001421 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmT001422;
        prmT001422 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0) ,
        new ParDef("@usuariosNotificacionNotificado",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionDescripcio",GXType.NChar,250,0) ,
        new ParDef("@usuariosNotificacionParametros",GXType.NChar,500,0) ,
        new ParDef("@usuariosNotificacionObjeto",GXType.NChar,100,0) ,
        new ParDef("@usuariosNotificacionFecha",GXType.DateTime,8,5)
        };
        Object[] prmT001423;
        prmT001423 = new Object[] {
        new ParDef("@usuariosNotificacionNotificado",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionDescripcio",GXType.NChar,250,0) ,
        new ParDef("@usuariosNotificacionParametros",GXType.NChar,500,0) ,
        new ParDef("@usuariosNotificacionObjeto",GXType.NChar,100,0) ,
        new ParDef("@usuariosNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmT001424;
        prmT001424 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmT001425;
        prmT001425 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00142", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WITH (UPDLOCK) WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00143", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00144", "SELECT [usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [usuariosDireccion], [usuariosImagen_GXI], [usuariosPasw], [usuariosCPostal], [usuariosTelefono], [usuariosEstado], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad], [PaisID], [usuariosImagen] FROM [usuarios] WITH (UPDLOCK) WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00145", "SELECT [usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [usuariosDireccion], [usuariosImagen_GXI], [usuariosPasw], [usuariosCPostal], [usuariosTelefono], [usuariosEstado], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad], [PaisID], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00146", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00146,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00147", "SELECT TM1.[usuariosId], TM1.[usuariosTipo], TM1.[usuariosNombre], TM1.[usuariosCorreo], T2.[PaisNombre], TM1.[usuariosDireccion], TM1.[usuariosImagen_GXI], TM1.[usuariosPasw], TM1.[usuariosCPostal], TM1.[usuariosTelefono], TM1.[usuariosEstado], TM1.[usuariosEstadoOnOffLine], TM1.[usuariosFechaEstadoOnOff], TM1.[usuariosHoraEstadoOnOff], TM1.[usuariosNumeroIdentidad], TM1.[PaisID], TM1.[usuariosImagen] FROM ([usuarios] TM1 INNER JOIN [Pais] T2 ON T2.[PaisID] = TM1.[PaisID]) WHERE TM1.[usuariosId] = @usuariosId ORDER BY TM1.[usuariosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00147,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00148", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00148,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00149", "SELECT [usuariosId] FROM [usuarios] WHERE [usuariosId] = @usuariosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00149,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001410", "SELECT TOP 1 [usuariosId] FROM [usuarios] WHERE ( [usuariosId] > @usuariosId) ORDER BY [usuariosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001410,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001411", "SELECT TOP 1 [usuariosId] FROM [usuarios] WHERE ( [usuariosId] < @usuariosId) ORDER BY [usuariosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001411,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001412", "INSERT INTO [usuarios]([usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [usuariosDireccion], [usuariosImagen], [usuariosImagen_GXI], [usuariosPasw], [usuariosCPostal], [usuariosTelefono], [usuariosEstado], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad], [PaisID]) VALUES(@usuariosId, @usuariosTipo, @usuariosNombre, @usuariosCorreo, @usuariosDireccion, @usuariosImagen, @usuariosImagen_GXI, @usuariosPasw, @usuariosCPostal, @usuariosTelefono, @usuariosEstado, @usuariosEstadoOnOffLine, @usuariosFechaEstadoOnOff, @usuariosHoraEstadoOnOff, @usuariosNumeroIdentidad, @PaisID)", GxErrorMask.GX_NOMASK,prmT001412)
           ,new CursorDef("T001413", "UPDATE [usuarios] SET [usuariosTipo]=@usuariosTipo, [usuariosNombre]=@usuariosNombre, [usuariosCorreo]=@usuariosCorreo, [usuariosDireccion]=@usuariosDireccion, [usuariosPasw]=@usuariosPasw, [usuariosCPostal]=@usuariosCPostal, [usuariosTelefono]=@usuariosTelefono, [usuariosEstado]=@usuariosEstado, [usuariosEstadoOnOffLine]=@usuariosEstadoOnOffLine, [usuariosFechaEstadoOnOff]=@usuariosFechaEstadoOnOff, [usuariosHoraEstadoOnOff]=@usuariosHoraEstadoOnOff, [usuariosNumeroIdentidad]=@usuariosNumeroIdentidad, [PaisID]=@PaisID  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK,prmT001413)
           ,new CursorDef("T001414", "UPDATE [usuarios] SET [usuariosImagen]=@usuariosImagen, [usuariosImagen_GXI]=@usuariosImagen_GXI  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK,prmT001414)
           ,new CursorDef("T001415", "DELETE FROM [usuarios]  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK,prmT001415)
           ,new CursorDef("T001416", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001416,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001417", "SELECT TOP 1 [TokenId] FROM [Token] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001417,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001418", "SELECT TOP 1 [SecUserId] FROM [SecUser] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001418,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001419", "SELECT [usuariosId] FROM [usuarios] ORDER BY [usuariosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001419,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001420", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId and [usuariosNotificacionTipo] = @usuariosNotificacionTipo and [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001420,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001421", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001421,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001422", "INSERT INTO [usuariosNotificacion]([usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha]) VALUES(@usuariosId, @usuariosNotificacionTipo, @usuariosNotificacionCodigo, @usuariosNotificacionNotificado, @usuariosNotificacionDescripcio, @usuariosNotificacionParametros, @usuariosNotificacionObjeto, @usuariosNotificacionFecha)", GxErrorMask.GX_NOMASK,prmT001422)
           ,new CursorDef("T001423", "UPDATE [usuariosNotificacion] SET [usuariosNotificacionNotificado]=@usuariosNotificacionNotificado, [usuariosNotificacionDescripcio]=@usuariosNotificacionDescripcio, [usuariosNotificacionParametros]=@usuariosNotificacionParametros, [usuariosNotificacionObjeto]=@usuariosNotificacionObjeto, [usuariosNotificacionFecha]=@usuariosNotificacionFecha  WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo", GxErrorMask.GX_NOMASK,prmT001423)
           ,new CursorDef("T001424", "DELETE FROM [usuariosNotificacion]  WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo", GxErrorMask.GX_NOMASK,prmT001424)
           ,new CursorDef("T001425", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001425,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((string[]) buf[14])[0] = rslt.getString(15, 2);
              ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(6));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((string[]) buf[14])[0] = rslt.getString(15, 2);
              ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(6));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 80);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((string[]) buf[11])[0] = rslt.getString(12, 3);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 2);
              ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(7));
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
  }

}

}

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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secuser : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action17") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_17_067( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action18") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_18_067( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"vEXITE") == 0 )
         {
            A145usuariosId = GetPar( "usuariosId");
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            A26SecUserName = GetPar( "SecUserName");
            AssignAttri("", false, "A26SecUserName", A26SecUserName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX12ASAEXITE067( A145usuariosId, A26SecUserName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"SECUSERPASSWORD") == 0 )
         {
            AV28UserPassword = GetPar( "UserPassword");
            AssignAttri("", false, "AV28UserPassword", AV28UserPassword);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASASECUSERPASSWORD067( AV28UserPassword) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel15"+"_"+"vEXITEVINCULO") == 0 )
         {
            AV26OldSecUserName = GetPar( "OldSecUserName");
            AssignAttri("", false, "AV26OldSecUserName", AV26OldSecUserName);
            AV27OldusuariosId = GetPar( "OldusuariosId");
            AssignAttri("", false, "AV27OldusuariosId", AV27OldusuariosId);
            A145usuariosId = GetPar( "usuariosId");
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            A26SecUserName = GetPar( "SecUserName");
            AssignAttri("", false, "A26SecUserName", A26SecUserName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX15ASAEXITEVINCULO067( AV26OldSecUserName, AV27OldusuariosId, A145usuariosId, A26SecUserName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A145usuariosId = GetPar( "usuariosId");
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A145usuariosId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secuser.aspx")), "wwpbaseobjects.secuser.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secuser.aspx")))) ;
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
                  AV7SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SecUserId", StringUtil.LTrimStr( (decimal)(AV7SecUserId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "User", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SecUserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SecUserId = aP1_SecUserId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbusuariosEstado = new GXCombobox();
         cmbSecUserEstado = new GXCombobox();
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
         if ( cmbSecUserEstado.ItemCount > 0 )
         {
            A550SecUserEstado = cmbSecUserEstado.getValidValue(A550SecUserEstado);
            n550SecUserEstado = false;
            AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSecUserEstado.CurrentValue = StringUtil.RTrim( A550SecUserEstado);
            AssignProp("", false, cmbSecUserEstado_Internalname, "Values", cmbSecUserEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, context.GetMessage( "Usuario Nro.", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserName_Internalname, context.GetMessage( "NickName", ""), "col-sm-3 ActionBaseColorAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserName_Internalname, A26SecUserName, StringUtil.RTrim( context.localUtil.Format( A26SecUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Usuario para iniciar sesión", ""), edtSecUserName_Jsonclick, 0, "ActionBaseColorAttribute", "", "", "", "", 1, edtSecUserName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserFullName_Internalname, context.GetMessage( "Nombre Completo", ""), "col-sm-3 ActionBaseColorAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserFullName_Internalname, A587SecUserFullName, StringUtil.RTrim( context.localUtil.Format( A587SecUserFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserFullName_Jsonclick, 0, "ActionBaseColorAttribute", "", "", "", "", 1, edtSecUserFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, context.GetMessage( "Password", ""), "col-sm-3 ActionBaseColorAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, AV28UserPassword, StringUtil.RTrim( context.localUtil.Format( AV28UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "*********", edtavUserpassword_Jsonclick, 0, "ActionBaseColorAttribute", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtusuariosId_Internalname, context.GetMessage( "Usuarios Relacionado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosId_Internalname, StringUtil.RTrim( A145usuariosId), StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosId_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NickName", "start", true, "", "HLP_WWPBaseObjects/SecUser.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_145_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_145_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_145_Internalname, sImgUrl, imgprompt_145_Link, "", "", context.GetTheme( ), imgprompt_145_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_WWPBaseObjects/SecUser.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtusuariosNombre_Internalname, StringUtil.RTrim( A222usuariosNombre), StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_WWPBaseObjects/SecUser.htm");
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
         GxWebStd.gx_label_element( context, cmbusuariosEstado_Internalname, context.GetMessage( "usuarios Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbusuariosEstado, cmbusuariosEstado_Internalname, StringUtil.RTrim( A226usuariosEstado), 1, cmbusuariosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbusuariosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_WWPBaseObjects/SecUser.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgusuariosImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A266usuariosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000usuariosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.PathToRelativeUrl( A266usuariosImagen));
         GxWebStd.gx_bitmap( context, imgusuariosImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgusuariosImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", "", "", 0, A266usuariosImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/SecUser.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSecUserEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSecUserEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSecUserEstado, cmbSecUserEstado_Internalname, StringUtil.RTrim( A550SecUserEstado), 1, cmbSecUserEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSecUserEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_WWPBaseObjects/SecUser.htm");
         cmbSecUserEstado.CurrentValue = StringUtil.RTrim( A550SecUserEstado);
         AssignProp("", false, cmbSecUserEstado_Internalname, "Values", (string)(cmbSecUserEstado.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUser.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserPassword_Internalname, A27SecUserPassword, StringUtil.RTrim( context.localUtil.Format( A27SecUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserPassword_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserPassword_Visible, edtSecUserPassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUser.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z18SecUserId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z27SecUserPassword = cgiGet( "Z27SecUserPassword");
               Z26SecUserName = cgiGet( "Z26SecUserName");
               Z587SecUserFullName = cgiGet( "Z587SecUserFullName");
               Z550SecUserEstado = cgiGet( "Z550SecUserEstado");
               n550SecUserEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) ? true : false);
               Z145usuariosId = cgiGet( "Z145usuariosId");
               n145usuariosId = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? true : false);
               O27SecUserPassword = cgiGet( "O27SecUserPassword");
               O145usuariosId = cgiGet( "O145usuariosId");
               n145usuariosId = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? true : false);
               O26SecUserName = cgiGet( "O26SecUserName");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N145usuariosId = cgiGet( "N145usuariosId");
               n145usuariosId = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? true : false);
               AV7SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSECUSERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV16Insert_usuariosId = cgiGet( "vINSERT_USUARIOSID");
               AssignAttri("", false, "AV16Insert_usuariosId", AV16Insert_usuariosId);
               AV26OldSecUserName = cgiGet( "vOLDSECUSERNAME");
               AV27OldusuariosId = cgiGet( "vOLDUSUARIOSID");
               AV30OdlusuariosPasw = cgiGet( "vODLUSUARIOSPASW");
               AV24Exite = cgiGet( "vEXITE");
               AssignAttri("", false, "AV24Exite", AV24Exite);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV25ExiteVinculo = cgiGet( "vEXITEVINCULO");
               AssignAttri("", false, "AV25ExiteVinculo", AV25ExiteVinculo);
               A223usuariosPasw = cgiGet( "USUARIOSPASW");
               A40000usuariosImagen_GXI = cgiGet( "USUARIOSIMAGEN_GXI");
               A225usuariosTipo = cgiGet( "USUARIOSTIPO");
               AV32Pgmname = cgiGet( "vPGMNAME");
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
               A18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               A26SecUserName = cgiGet( edtSecUserName_Internalname);
               AssignAttri("", false, "A26SecUserName", A26SecUserName);
               A587SecUserFullName = cgiGet( edtSecUserFullName_Internalname);
               AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
               AV28UserPassword = cgiGet( edtavUserpassword_Internalname);
               AssignAttri("", false, "AV28UserPassword", AV28UserPassword);
               A145usuariosId = cgiGet( edtusuariosId_Internalname);
               n145usuariosId = false;
               AssignAttri("", false, "A145usuariosId", A145usuariosId);
               n145usuariosId = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? true : false);
               A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
               AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
               cmbusuariosEstado.CurrentValue = cgiGet( cmbusuariosEstado_Internalname);
               A226usuariosEstado = cgiGet( cmbusuariosEstado_Internalname);
               AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
               A266usuariosImagen = cgiGet( imgusuariosImagen_Internalname);
               AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
               cmbSecUserEstado.CurrentValue = cgiGet( cmbSecUserEstado_Internalname);
               A550SecUserEstado = cgiGet( cmbSecUserEstado_Internalname);
               n550SecUserEstado = false;
               AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
               n550SecUserEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) ? true : false);
               A27SecUserPassword = cgiGet( edtSecUserPassword_Internalname);
               AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgusuariosImagen_Internalname, ref  A266usuariosImagen, ref  A40000usuariosImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SecUser");
               A18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               forbiddenHiddens.Add("SecUserId", context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_usuariosId", StringUtil.RTrim( context.localUtil.Format( AV16Insert_usuariosId, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A18SecUserId != Z18SecUserId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("wwpbaseobjects\\secuser:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A18SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SECUSERID");
                        AnyError = 1;
                        GX_FocusControl = edtSecUserId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "VUSERPASSWORD.ISVALID") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E13062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll067( ) ;
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
            DisableAttributes067( ) ;
         }
         AssignProp("", false, edtavUserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Enabled), 5, 0), true);
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

      protected void CONFIRM_060( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls067( ) ;
            }
            else
            {
               CheckExtendedTable067( ) ;
               CloseExtendedTableCursors067( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV32Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "usuariosId") == 0 )
               {
                  AV16Insert_usuariosId = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV16Insert_usuariosId", AV16Insert_usuariosId);
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         edtSecUserPassword_Visible = 0;
         AssignProp("", false, edtSecUserPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserPassword_Visible), 5, 0), true);
         AV24Exite = context.GetMessage( "N", "");
         AssignAttri("", false, "AV24Exite", AV24Exite);
         AV25ExiteVinculo = context.GetMessage( "N", "");
         AssignAttri("", false, "AV25ExiteVinculo", AV25ExiteVinculo);
         AV28UserPassword = "";
         AssignAttri("", false, "AV28UserPassword", AV28UserPassword);
      }

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) && ! String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) )
         {
            new setusuariospasw(context ).execute(  A145usuariosId,  AV28UserPassword) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpbaseobjects.secuserww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E13062( )
      {
         /* Userpassword_Isvalid Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) )
         {
            new pencripta(context ).execute(  StringUtil.Trim( AV28UserPassword), out  A27SecUserPassword) ;
            AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
         }
         /*  Sending Event outputs  */
      }

      protected void ZM067( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z27SecUserPassword = T00063_A27SecUserPassword[0];
               Z26SecUserName = T00063_A26SecUserName[0];
               Z587SecUserFullName = T00063_A587SecUserFullName[0];
               Z550SecUserEstado = T00063_A550SecUserEstado[0];
               Z145usuariosId = T00063_A145usuariosId[0];
            }
            else
            {
               Z27SecUserPassword = A27SecUserPassword;
               Z26SecUserName = A26SecUserName;
               Z587SecUserFullName = A587SecUserFullName;
               Z550SecUserEstado = A550SecUserEstado;
               Z145usuariosId = A145usuariosId;
            }
         }
         if ( GX_JID == -23 )
         {
            Z18SecUserId = A18SecUserId;
            Z27SecUserPassword = A27SecUserPassword;
            Z26SecUserName = A26SecUserName;
            Z587SecUserFullName = A587SecUserFullName;
            Z550SecUserEstado = A550SecUserEstado;
            Z145usuariosId = A145usuariosId;
            Z222usuariosNombre = A222usuariosNombre;
            Z223usuariosPasw = A223usuariosPasw;
            Z226usuariosEstado = A226usuariosEstado;
            Z266usuariosImagen = A266usuariosImagen;
            Z40000usuariosImagen_GXI = A40000usuariosImagen_GXI;
            Z225usuariosTipo = A225usuariosTipo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSecUserName_Enabled = 0;
            AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
         }
         else
         {
            edtSecUserName_Enabled = 1;
            AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
         }
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_145_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"usuariosprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"USUARIOSID"+"'), id:'"+"USUARIOSID"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SecUserId) )
         {
            A18SecUserId = AV7SecUserId;
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_usuariosId)) )
         {
            edtusuariosId_Enabled = 0;
            AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         }
         else
         {
            edtusuariosId_Enabled = 1;
            AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(AV24Exite, context.GetMessage( "S", "")) == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "Error: El usuario ya existe, selecciones otro nickname (Nombre)", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.StrCmp(AV25ExiteVinculo, context.GetMessage( "S", "")) == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "Error: Ya se encuentra vinculado con el usuario seleccionado.", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void standaloneModal( )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) )
         {
            GXt_char2 = A27SecUserPassword;
            new pencripta(context ).execute(  AV28UserPassword, out  GXt_char2) ;
            A27SecUserPassword = GXt_char2;
            AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_usuariosId)) )
         {
            A145usuariosId = AV16Insert_usuariosId;
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSecUserName_Enabled = 0;
            AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) && ( Gx_BScreen == 0 ) )
         {
            A550SecUserEstado = "HAB";
            n550SecUserEstado = false;
            AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV32Pgmname = "WWPBaseObjects.SecUser";
            AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
            AV30OdlusuariosPasw = O27SecUserPassword;
            AssignAttri("", false, "AV30OdlusuariosPasw", AV30OdlusuariosPasw);
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {n145usuariosId, A145usuariosId});
            A222usuariosNombre = T00064_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A223usuariosPasw = T00064_A223usuariosPasw[0];
            A226usuariosEstado = T00064_A226usuariosEstado[0];
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
            A40000usuariosImagen_GXI = T00064_A40000usuariosImagen_GXI[0];
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A225usuariosTipo = T00064_A225usuariosTipo[0];
            A266usuariosImagen = T00064_A266usuariosImagen[0];
            AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            pr_default.close(2);
            AV27OldusuariosId = O145usuariosId;
            AssignAttri("", false, "AV27OldusuariosId", AV27OldusuariosId);
         }
      }

      protected void Load067( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A27SecUserPassword = T00065_A27SecUserPassword[0];
            AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
            A26SecUserName = T00065_A26SecUserName[0];
            AssignAttri("", false, "A26SecUserName", A26SecUserName);
            A587SecUserFullName = T00065_A587SecUserFullName[0];
            AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
            A222usuariosNombre = T00065_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A223usuariosPasw = T00065_A223usuariosPasw[0];
            A226usuariosEstado = T00065_A226usuariosEstado[0];
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
            A40000usuariosImagen_GXI = T00065_A40000usuariosImagen_GXI[0];
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A225usuariosTipo = T00065_A225usuariosTipo[0];
            A550SecUserEstado = T00065_A550SecUserEstado[0];
            n550SecUserEstado = T00065_n550SecUserEstado[0];
            AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
            A145usuariosId = T00065_A145usuariosId[0];
            n145usuariosId = T00065_n145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            A266usuariosImagen = T00065_A266usuariosImagen[0];
            AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            ZM067( -23) ;
         }
         pr_default.close(3);
         OnLoadActions067( ) ;
      }

      protected void OnLoadActions067( )
      {
         AV32Pgmname = "WWPBaseObjects.SecUser";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         AV26OldSecUserName = O26SecUserName;
         AssignAttri("", false, "AV26OldSecUserName", AV26OldSecUserName);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_char2 = AV24Exite;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
            AV24Exite = GXt_char2;
            AssignAttri("", false, "AV24Exite", AV24Exite);
         }
         AV30OdlusuariosPasw = O27SecUserPassword;
         AssignAttri("", false, "AV30OdlusuariosPasw", AV30OdlusuariosPasw);
         AV27OldusuariosId = O145usuariosId;
         AssignAttri("", false, "AV27OldusuariosId", AV27OldusuariosId);
         if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_char2 = AV25ExiteVinculo;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
            AV25ExiteVinculo = GXt_char2;
            AssignAttri("", false, "AV25ExiteVinculo", AV25ExiteVinculo);
         }
      }

      protected void CheckExtendedTable067( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV32Pgmname = "WWPBaseObjects.SecUser";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         AV26OldSecUserName = O26SecUserName;
         AssignAttri("", false, "AV26OldSecUserName", AV26OldSecUserName);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_char2 = AV24Exite;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
            AV24Exite = GXt_char2;
            AssignAttri("", false, "AV24Exite", AV24Exite);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A26SecUserName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Error: El nickname no puede ser vacíos.", ""), 1, "SECUSERNAME");
            AnyError = 1;
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         AV30OdlusuariosPasw = O27SecUserPassword;
         AssignAttri("", false, "AV30OdlusuariosPasw", AV30OdlusuariosPasw);
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtusuariosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A222usuariosNombre = T00064_A222usuariosNombre[0];
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         A223usuariosPasw = T00064_A223usuariosPasw[0];
         A226usuariosEstado = T00064_A226usuariosEstado[0];
         AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         A40000usuariosImagen_GXI = T00064_A40000usuariosImagen_GXI[0];
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         A225usuariosTipo = T00064_A225usuariosTipo[0];
         A266usuariosImagen = T00064_A266usuariosImagen[0];
         AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         pr_default.close(2);
         AV27OldusuariosId = O145usuariosId;
         AssignAttri("", false, "AV27OldusuariosId", AV27OldusuariosId);
         if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_char2 = AV25ExiteVinculo;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
            AV25ExiteVinculo = GXt_char2;
            AssignAttri("", false, "AV25ExiteVinculo", AV25ExiteVinculo);
         }
         if ( ! ( ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A550SecUserEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SECUSERESTADO");
            AnyError = 1;
            GX_FocusControl = cmbSecUserEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors067( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( string A145usuariosId )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtusuariosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A222usuariosNombre = T00066_A222usuariosNombre[0];
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         A223usuariosPasw = T00066_A223usuariosPasw[0];
         A226usuariosEstado = T00066_A226usuariosEstado[0];
         AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         A40000usuariosImagen_GXI = T00066_A40000usuariosImagen_GXI[0];
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         A225usuariosTipo = T00066_A225usuariosTipo[0];
         A266usuariosImagen = T00066_A266usuariosImagen[0];
         AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A222usuariosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A223usuariosPasw))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A226usuariosEstado))+"\""+","+"\""+GXUtil.EncodeJSConstant( A266usuariosImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000usuariosImagen_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A225usuariosTipo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey067( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM067( 23) ;
            RcdFound7 = 1;
            A18SecUserId = T00063_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            A27SecUserPassword = T00063_A27SecUserPassword[0];
            AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
            A26SecUserName = T00063_A26SecUserName[0];
            AssignAttri("", false, "A26SecUserName", A26SecUserName);
            A587SecUserFullName = T00063_A587SecUserFullName[0];
            AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
            A550SecUserEstado = T00063_A550SecUserEstado[0];
            n550SecUserEstado = T00063_n550SecUserEstado[0];
            AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
            A145usuariosId = T00063_A145usuariosId[0];
            n145usuariosId = T00063_n145usuariosId[0];
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            O27SecUserPassword = A27SecUserPassword;
            AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
            O145usuariosId = A145usuariosId;
            n145usuariosId = false;
            AssignAttri("", false, "A145usuariosId", A145usuariosId);
            O26SecUserName = A26SecUserName;
            AssignAttri("", false, "A26SecUserName", A26SecUserName);
            Z18SecUserId = A18SecUserId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load067( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey067( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey067( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey067( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00068_A18SecUserId[0] < A18SecUserId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00068_A18SecUserId[0] > A18SecUserId ) ) )
            {
               A18SecUserId = T00068_A18SecUserId[0];
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00069_A18SecUserId[0] > A18SecUserId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00069_A18SecUserId[0] < A18SecUserId ) ) )
            {
               A18SecUserId = T00069_A18SecUserId[0];
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey067( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert067( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A18SecUserId != Z18SecUserId )
               {
                  A18SecUserId = Z18SecUserId;
                  AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update067( ) ;
                  GX_FocusControl = edtSecUserName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A18SecUserId != Z18SecUserId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSecUserName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert067( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECUSERID");
                     AnyError = 1;
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSecUserName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert067( ) ;
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
         if ( A18SecUserId != Z18SecUserId )
         {
            A18SecUserId = Z18SecUserId;
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency067( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z27SecUserPassword, T00062_A27SecUserPassword[0]) != 0 ) || ( StringUtil.StrCmp(Z26SecUserName, T00062_A26SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z587SecUserFullName, T00062_A587SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z550SecUserEstado, T00062_A550SecUserEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z145usuariosId, T00062_A145usuariosId[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z27SecUserPassword, T00062_A27SecUserPassword[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuser:[seudo value changed for attri]"+"SecUserPassword");
                  GXUtil.WriteLogRaw("Old: ",Z27SecUserPassword);
                  GXUtil.WriteLogRaw("Current: ",T00062_A27SecUserPassword[0]);
               }
               if ( StringUtil.StrCmp(Z26SecUserName, T00062_A26SecUserName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuser:[seudo value changed for attri]"+"SecUserName");
                  GXUtil.WriteLogRaw("Old: ",Z26SecUserName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A26SecUserName[0]);
               }
               if ( StringUtil.StrCmp(Z587SecUserFullName, T00062_A587SecUserFullName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuser:[seudo value changed for attri]"+"SecUserFullName");
                  GXUtil.WriteLogRaw("Old: ",Z587SecUserFullName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A587SecUserFullName[0]);
               }
               if ( StringUtil.StrCmp(Z550SecUserEstado, T00062_A550SecUserEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuser:[seudo value changed for attri]"+"SecUserEstado");
                  GXUtil.WriteLogRaw("Old: ",Z550SecUserEstado);
                  GXUtil.WriteLogRaw("Current: ",T00062_A550SecUserEstado[0]);
               }
               if ( StringUtil.StrCmp(Z145usuariosId, T00062_A145usuariosId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuser:[seudo value changed for attri]"+"usuariosId");
                  GXUtil.WriteLogRaw("Old: ",Z145usuariosId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A145usuariosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM067( 0) ;
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000610 */
                     pr_default.execute(8, new Object[] {A27SecUserPassword, A26SecUserName, A587SecUserFullName, n550SecUserEstado, A550SecUserEstado, n145usuariosId, A145usuariosId});
                     A18SecUserId = T000610_A18SecUserId[0];
                     AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  StringUtil.Trim( StringUtil.Str( (decimal)(A18SecUserId), 10, 0)),  "") ;
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load067( ) ;
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void Update067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000611 */
                     pr_default.execute(9, new Object[] {A27SecUserPassword, A26SecUserName, A587SecUserFullName, n550SecUserEstado, A550SecUserEstado, n145usuariosId, A145usuariosId, A18SecUserId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate067( ) ;
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
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void DeferredUpdate067( )
      {
      }

      protected void delete( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls067( ) ;
            AfterConfirm067( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete067( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000612 */
                  pr_default.execute(10, new Object[] {A18SecUserId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("SecUser");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel067( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls067( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV32Pgmname = "WWPBaseObjects.SecUser";
            AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
            AV26OldSecUserName = O26SecUserName;
            AssignAttri("", false, "AV26OldSecUserName", AV26OldSecUserName);
            AV30OdlusuariosPasw = O27SecUserPassword;
            AssignAttri("", false, "AV30OdlusuariosPasw", AV30OdlusuariosPasw);
            /* Using cursor T000613 */
            pr_default.execute(11, new Object[] {n145usuariosId, A145usuariosId});
            A222usuariosNombre = T000613_A222usuariosNombre[0];
            AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
            A223usuariosPasw = T000613_A223usuariosPasw[0];
            A226usuariosEstado = T000613_A226usuariosEstado[0];
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
            A40000usuariosImagen_GXI = T000613_A40000usuariosImagen_GXI[0];
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A225usuariosTipo = T000613_A225usuariosTipo[0];
            A266usuariosImagen = T000613_A266usuariosImagen[0];
            AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
            AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
            AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            pr_default.close(11);
            AV27OldusuariosId = O145usuariosId;
            AssignAttri("", false, "AV27OldusuariosId", AV27OldusuariosId);
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GXt_char2 = AV24Exite;
               new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
               AV24Exite = GXt_char2;
               AssignAttri("", false, "AV24Exite", AV24Exite);
            }
            if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               GXt_char2 = AV25ExiteVinculo;
               new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
               AV25ExiteVinculo = GXt_char2;
               AssignAttri("", false, "AV25ExiteVinculo", AV25ExiteVinculo);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000614 */
            pr_default.execute(12, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupar Usuarios y Proveedores", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000615 */
            pr_default.execute(13, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Sec User Role", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel067( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete067( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("wwpbaseobjects.secuser",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("wwpbaseobjects.secuser",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart067( )
      {
         /* Scan By routine */
         /* Using cursor T000616 */
         pr_default.execute(14);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound7 = 1;
            A18SecUserId = T000616_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext067( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound7 = 1;
            A18SecUserId = T000616_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         }
      }

      protected void ScanEnd067( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm067( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert067( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate067( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete067( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete067( )
      {
         /* Before Complete Rules */
         if ( IsUpd( )  || IsDlt( )  )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_updateuserextended(context ).execute( ) ;
         }
      }

      protected void BeforeValidate067( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes067( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtSecUserName_Enabled = 0;
         AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
         edtSecUserFullName_Enabled = 0;
         AssignProp("", false, edtSecUserFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserFullName_Enabled), 5, 0), true);
         edtavUserpassword_Enabled = 0;
         AssignProp("", false, edtavUserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Enabled), 5, 0), true);
         edtusuariosId_Enabled = 0;
         AssignProp("", false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         edtusuariosNombre_Enabled = 0;
         AssignProp("", false, edtusuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNombre_Enabled), 5, 0), true);
         cmbusuariosEstado.Enabled = 0;
         AssignProp("", false, cmbusuariosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosEstado.Enabled), 5, 0), true);
         imgusuariosImagen_Enabled = 0;
         AssignProp("", false, imgusuariosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgusuariosImagen_Enabled), 5, 0), true);
         cmbSecUserEstado.Enabled = 0;
         AssignProp("", false, cmbSecUserEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSecUserEstado.Enabled), 5, 0), true);
         edtSecUserPassword_Enabled = 0;
         AssignProp("", false, edtSecUserPassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserPassword_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes067( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         GXEncryptionTmp = "wwpbaseobjects.secuser.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secuser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SecUser");
         forbiddenHiddens.Add("SecUserId", context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_usuariosId", StringUtil.RTrim( context.localUtil.Format( AV16Insert_usuariosId, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wwpbaseobjects\\secuser:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z18SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z27SecUserPassword", Z27SecUserPassword);
         GxWebStd.gx_hidden_field( context, "Z26SecUserName", Z26SecUserName);
         GxWebStd.gx_hidden_field( context, "Z587SecUserFullName", Z587SecUserFullName);
         GxWebStd.gx_hidden_field( context, "Z550SecUserEstado", StringUtil.RTrim( Z550SecUserEstado));
         GxWebStd.gx_hidden_field( context, "Z145usuariosId", StringUtil.RTrim( Z145usuariosId));
         GxWebStd.gx_hidden_field( context, "O27SecUserPassword", O27SecUserPassword);
         GxWebStd.gx_hidden_field( context, "O145usuariosId", StringUtil.RTrim( O145usuariosId));
         GxWebStd.gx_hidden_field( context, "O26SecUserName", O26SecUserName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N145usuariosId", StringUtil.RTrim( A145usuariosId));
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
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_USUARIOSID", StringUtil.RTrim( AV16Insert_usuariosId));
         GxWebStd.gx_hidden_field( context, "vOLDSECUSERNAME", AV26OldSecUserName);
         GxWebStd.gx_hidden_field( context, "vOLDUSUARIOSID", StringUtil.RTrim( AV27OldusuariosId));
         GxWebStd.gx_hidden_field( context, "vODLUSUARIOSPASW", StringUtil.RTrim( AV30OdlusuariosPasw));
         GxWebStd.gx_hidden_field( context, "vEXITE", StringUtil.RTrim( AV24Exite));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vEXITEVINCULO", StringUtil.RTrim( AV25ExiteVinculo));
         GxWebStd.gx_hidden_field( context, "USUARIOSPASW", StringUtil.RTrim( A223usuariosPasw));
         GxWebStd.gx_hidden_field( context, "USUARIOSIMAGEN_GXI", A40000usuariosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "USUARIOSTIPO", StringUtil.RTrim( A225usuariosTipo));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
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
         GXEncryptionTmp = "wwpbaseobjects.secuser.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserId,10,0));
         return formatLink("wwpbaseobjects.secuser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "User", "") ;
      }

      protected void InitializeNonKey067( )
      {
         A145usuariosId = "";
         n145usuariosId = false;
         AssignAttri("", false, "A145usuariosId", A145usuariosId);
         n145usuariosId = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? true : false);
         AV26OldSecUserName = "";
         AssignAttri("", false, "AV26OldSecUserName", AV26OldSecUserName);
         AV27OldusuariosId = "";
         AssignAttri("", false, "AV27OldusuariosId", AV27OldusuariosId);
         AV30OdlusuariosPasw = "";
         AssignAttri("", false, "AV30OdlusuariosPasw", AV30OdlusuariosPasw);
         A27SecUserPassword = "";
         AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
         A26SecUserName = "";
         AssignAttri("", false, "A26SecUserName", A26SecUserName);
         A587SecUserFullName = "";
         AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
         A222usuariosNombre = "";
         AssignAttri("", false, "A222usuariosNombre", A222usuariosNombre);
         A223usuariosPasw = "";
         AssignAttri("", false, "A223usuariosPasw", A223usuariosPasw);
         A226usuariosEstado = "";
         AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         A266usuariosImagen = "";
         AssignAttri("", false, "A266usuariosImagen", A266usuariosImagen);
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         A40000usuariosImagen_GXI = "";
         AssignProp("", false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
         AssignProp("", false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
         A225usuariosTipo = "";
         AssignAttri("", false, "A225usuariosTipo", A225usuariosTipo);
         A550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
         O27SecUserPassword = A27SecUserPassword;
         AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
         O145usuariosId = A145usuariosId;
         n145usuariosId = false;
         AssignAttri("", false, "A145usuariosId", A145usuariosId);
         O26SecUserName = A26SecUserName;
         AssignAttri("", false, "A26SecUserName", A26SecUserName);
         Z27SecUserPassword = "";
         Z26SecUserName = "";
         Z587SecUserFullName = "";
         Z550SecUserEstado = "";
         Z145usuariosId = "";
      }

      protected void InitAll067( )
      {
         A18SecUserId = 0;
         AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         InitializeNonKey067( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A550SecUserEstado = i550SecUserEstado;
         n550SecUserEstado = false;
         AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269321451488", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/secuser.js", "?20269321451489", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSecUserId_Internalname = "SECUSERID";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         edtusuariosId_Internalname = "USUARIOSID";
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE";
         cmbusuariosEstado_Internalname = "USUARIOSESTADO";
         imgusuariosImagen_Internalname = "USUARIOSIMAGEN";
         cmbSecUserEstado_Internalname = "SECUSERESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSecUserPassword_Internalname = "SECUSERPASSWORD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_145_Internalname = "PROMPT_145";
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
         Form.Caption = context.GetMessage( "User", "");
         edtSecUserPassword_Jsonclick = "";
         edtSecUserPassword_Enabled = 1;
         edtSecUserPassword_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbSecUserEstado_Jsonclick = "";
         cmbSecUserEstado.Enabled = 1;
         imgusuariosImagen_Enabled = 0;
         cmbusuariosEstado_Jsonclick = "";
         cmbusuariosEstado.Enabled = 0;
         edtusuariosNombre_Jsonclick = "";
         edtusuariosNombre_Enabled = 0;
         imgprompt_145_Visible = 1;
         imgprompt_145_Link = "";
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Enabled = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Enabled = 1;
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Enabled = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 0;
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

      protected void GX12ASAEXITE067( string A145usuariosId ,
                                      string A26SecUserName )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_char2 = AV24Exite;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
            AV24Exite = GXt_char2;
            AssignAttri("", false, "AV24Exite", AV24Exite);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV24Exite))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX13ASASECUSERPASSWORD067( string AV28UserPassword )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) )
         {
            GXt_char2 = A27SecUserPassword;
            new pencripta(context ).execute(  AV28UserPassword, out  GXt_char2) ;
            A27SecUserPassword = GXt_char2;
            AssignAttri("", false, "A27SecUserPassword", A27SecUserPassword);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A27SecUserPassword)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX15ASAEXITEVINCULO067( string AV26OldSecUserName ,
                                             string AV27OldusuariosId ,
                                             string A145usuariosId ,
                                             string A26SecUserName )
      {
         if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_char2 = AV25ExiteVinculo;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
            AV25ExiteVinculo = GXt_char2;
            AssignAttri("", false, "AV25ExiteVinculo", AV25ExiteVinculo);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV25ExiteVinculo))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_17_067( )
      {
         new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  StringUtil.Trim( StringUtil.Str( (decimal)(A18SecUserId), 10, 0)),  "") ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_18_067( string Gx_mode )
      {
         if ( IsUpd( )  || IsDlt( )  )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_updateuserextended(context ).execute( ) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbusuariosEstado.Name = "USUARIOSESTADO";
         cmbusuariosEstado.WebTags = "";
         cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
            AssignAttri("", false, "A226usuariosEstado", A226usuariosEstado);
         }
         cmbSecUserEstado.Name = "SECUSERESTADO";
         cmbSecUserEstado.WebTags = "";
         cmbSecUserEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbSecUserEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbSecUserEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbSecUserEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbSecUserEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) )
            {
               A550SecUserEstado = "HAB";
               n550SecUserEstado = false;
               AssignAttri("", false, "A550SecUserEstado", A550SecUserEstado);
            }
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

      public void Valid_Secusername( )
      {
         AV26OldSecUserName = O26SecUserName;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A26SecUserName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Error: El nickname no puede ser vacíos.", ""), 1, "SECUSERNAME");
            AnyError = 1;
            GX_FocusControl = edtSecUserName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "AV26OldSecUserName", AV26OldSecUserName);
      }

      public void Valid_Usuariosid( )
      {
         n145usuariosId = false;
         A226usuariosEstado = cmbusuariosEstado.CurrentValue;
         cmbusuariosEstado.CurrentValue = A226usuariosEstado;
         /* Using cursor T000613 */
         pr_default.execute(11, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
               GX_FocusControl = edtusuariosId_Internalname;
            }
         }
         A222usuariosNombre = T000613_A222usuariosNombre[0];
         A223usuariosPasw = T000613_A223usuariosPasw[0];
         A226usuariosEstado = T000613_A226usuariosEstado[0];
         cmbusuariosEstado.CurrentValue = A226usuariosEstado;
         A40000usuariosImagen_GXI = T000613_A40000usuariosImagen_GXI[0];
         A225usuariosTipo = T000613_A225usuariosTipo[0];
         A266usuariosImagen = T000613_A266usuariosImagen[0];
         pr_default.close(11);
         AV27OldusuariosId = O145usuariosId;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_char2 = AV24Exite;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
            AV24Exite = GXt_char2;
         }
         if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_char2 = AV25ExiteVinculo;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
            AV25ExiteVinculo = GXt_char2;
         }
         dynload_actions( ) ;
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
            cmbusuariosEstado.CurrentValue = A226usuariosEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A222usuariosNombre", StringUtil.RTrim( A222usuariosNombre));
         AssignAttri("", false, "A223usuariosPasw", StringUtil.RTrim( A223usuariosPasw));
         AssignAttri("", false, "A226usuariosEstado", StringUtil.RTrim( A226usuariosEstado));
         cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
         AssignProp("", false, cmbusuariosEstado_Internalname, "Values", cmbusuariosEstado.ToJavascriptSource(), true);
         AssignAttri("", false, "A266usuariosImagen", context.PathToRelativeUrl( A266usuariosImagen));
         GXCCtlgxBlob = "USUARIOSIMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A266usuariosImagen));
         AssignAttri("", false, "A40000usuariosImagen_GXI", A40000usuariosImagen_GXI);
         AssignAttri("", false, "A225usuariosTipo", StringUtil.RTrim( A225usuariosTipo));
         AssignAttri("", false, "AV27OldusuariosId", StringUtil.RTrim( AV27OldusuariosId));
         AssignAttri("", false, "AV24Exite", StringUtil.RTrim( AV24Exite));
         AssignAttri("", false, "AV25ExiteVinculo", StringUtil.RTrim( AV25ExiteVinculo));
      }

      public void Valid_Secuserpassword( )
      {
         n145usuariosId = false;
         AV30OdlusuariosPasw = O27SecUserPassword;
         O27SecUserPassword = A27SecUserPassword;
         O145usuariosId = A145usuariosId;
         n145usuariosId = false;
         O26SecUserName = A26SecUserName;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "AV30OdlusuariosPasw", StringUtil.RTrim( AV30OdlusuariosPasw));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV16Insert_usuariosId',fld:'vINSERT_USUARIOSID',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'AV28UserPassword',fld:'vUSERPASSWORD',pic:'',type:'svchar'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VUSERPASSWORD.ISVALID","{handler:'E13062',iparms:[{av:'AV28UserPassword',fld:'vUSERPASSWORD',pic:'',type:'svchar'}]");
         setEventMetadata("VUSERPASSWORD.ISVALID",",oparms:[{av:'A27SecUserPassword',fld:'SECUSERPASSWORD',pic:'',type:'svchar'}]}");
         setEventMetadata("VALID_SECUSERID","{handler:'Valid_Secuserid',iparms:[]");
         setEventMetadata("VALID_SECUSERID",",oparms:[]}");
         setEventMetadata("VALID_SECUSERNAME","{handler:'Valid_Secusername',iparms:[{av:'O26SecUserName',type:'svchar'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'AV26OldSecUserName',fld:'vOLDSECUSERNAME',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_SECUSERNAME",",oparms:[{av:'AV26OldSecUserName',fld:'vOLDSECUSERNAME',pic:'',type:'svchar'}]}");
         setEventMetadata("VALIDV_USERPASSWORD","{handler:'Validv_Userpassword',iparms:[]");
         setEventMetadata("VALIDV_USERPASSWORD",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'O145usuariosId',type:'char'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'AV26OldSecUserName',fld:'vOLDSECUSERNAME',pic:'',type:'svchar'},{av:'AV27OldusuariosId',fld:'vOLDUSUARIOSID',pic:'',type:'char'},{av:'A222usuariosNombre',fld:'USUARIOSNOMBRE',pic:'',type:'char'},{av:'A223usuariosPasw',fld:'USUARIOSPASW',pic:'',type:'char'},{av:'cmbusuariosEstado'},{av:'A226usuariosEstado',fld:'USUARIOSESTADO',pic:'',type:'char'},{av:'A266usuariosImagen',fld:'USUARIOSIMAGEN',pic:'',type:'bits'},{av:'A40000usuariosImagen_GXI',fld:'USUARIOSIMAGEN_GXI',pic:'',type:'svchar'},{av:'A225usuariosTipo',fld:'USUARIOSTIPO',pic:'',type:'char'},{av:'AV24Exite',fld:'vEXITE',pic:'',type:'char'},{av:'AV25ExiteVinculo',fld:'vEXITEVINCULO',pic:'',type:'char'}]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[{av:'A222usuariosNombre',fld:'USUARIOSNOMBRE',pic:'',type:'char'},{av:'A223usuariosPasw',fld:'USUARIOSPASW',pic:'',type:'char'},{av:'cmbusuariosEstado'},{av:'A226usuariosEstado',fld:'USUARIOSESTADO',pic:'',type:'char'},{av:'A266usuariosImagen',fld:'USUARIOSIMAGEN',pic:'',type:'bits'},{av:'A40000usuariosImagen_GXI',fld:'USUARIOSIMAGEN_GXI',pic:'',type:'svchar'},{av:'A225usuariosTipo',fld:'USUARIOSTIPO',pic:'',type:'char'},{av:'AV27OldusuariosId',fld:'vOLDUSUARIOSID',pic:'',type:'char'},{av:'AV24Exite',fld:'vEXITE',pic:'',type:'char'},{av:'AV25ExiteVinculo',fld:'vEXITEVINCULO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_SECUSERESTADO","{handler:'Valid_Secuserestado',iparms:[]");
         setEventMetadata("VALID_SECUSERESTADO",",oparms:[]}");
         setEventMetadata("VALID_SECUSERPASSWORD","{handler:'Valid_Secuserpassword',iparms:[{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'O27SecUserPassword',type:'svchar'},{av:'A27SecUserPassword',fld:'SECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV30OdlusuariosPasw',fld:'vODLUSUARIOSPASW',pic:'',type:'char'}]");
         setEventMetadata("VALID_SECUSERPASSWORD",",oparms:[{av:'AV30OdlusuariosPasw',fld:'vODLUSUARIOSPASW',pic:'',type:'char'}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z27SecUserPassword = "";
         Z26SecUserName = "";
         Z587SecUserFullName = "";
         Z550SecUserEstado = "";
         Z145usuariosId = "";
         O27SecUserPassword = "";
         O145usuariosId = "";
         O26SecUserName = "";
         N145usuariosId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A145usuariosId = "";
         A26SecUserName = "";
         AV28UserPassword = "";
         AV26OldSecUserName = "";
         AV27OldusuariosId = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A226usuariosEstado = "";
         A550SecUserEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A587SecUserFullName = "";
         imgprompt_145_gximage = "";
         sImgUrl = "";
         A222usuariosNombre = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A27SecUserPassword = "";
         AV16Insert_usuariosId = "";
         AV30OdlusuariosPasw = "";
         AV24Exite = "";
         AV25ExiteVinculo = "";
         A223usuariosPasw = "";
         A225usuariosTipo = "";
         AV32Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z222usuariosNombre = "";
         Z223usuariosPasw = "";
         Z226usuariosEstado = "";
         Z266usuariosImagen = "";
         Z40000usuariosImagen_GXI = "";
         Z225usuariosTipo = "";
         T00064_A222usuariosNombre = new string[] {""} ;
         T00064_A223usuariosPasw = new string[] {""} ;
         T00064_A226usuariosEstado = new string[] {""} ;
         T00064_A40000usuariosImagen_GXI = new string[] {""} ;
         T00064_A225usuariosTipo = new string[] {""} ;
         T00064_A266usuariosImagen = new string[] {""} ;
         T00065_A18SecUserId = new long[1] ;
         T00065_A27SecUserPassword = new string[] {""} ;
         T00065_A26SecUserName = new string[] {""} ;
         T00065_A587SecUserFullName = new string[] {""} ;
         T00065_A222usuariosNombre = new string[] {""} ;
         T00065_A223usuariosPasw = new string[] {""} ;
         T00065_A226usuariosEstado = new string[] {""} ;
         T00065_A40000usuariosImagen_GXI = new string[] {""} ;
         T00065_A225usuariosTipo = new string[] {""} ;
         T00065_A550SecUserEstado = new string[] {""} ;
         T00065_n550SecUserEstado = new bool[] {false} ;
         T00065_A145usuariosId = new string[] {""} ;
         T00065_n145usuariosId = new bool[] {false} ;
         T00065_A266usuariosImagen = new string[] {""} ;
         T00066_A222usuariosNombre = new string[] {""} ;
         T00066_A223usuariosPasw = new string[] {""} ;
         T00066_A226usuariosEstado = new string[] {""} ;
         T00066_A40000usuariosImagen_GXI = new string[] {""} ;
         T00066_A225usuariosTipo = new string[] {""} ;
         T00066_A266usuariosImagen = new string[] {""} ;
         T00067_A18SecUserId = new long[1] ;
         T00063_A18SecUserId = new long[1] ;
         T00063_A27SecUserPassword = new string[] {""} ;
         T00063_A26SecUserName = new string[] {""} ;
         T00063_A587SecUserFullName = new string[] {""} ;
         T00063_A550SecUserEstado = new string[] {""} ;
         T00063_n550SecUserEstado = new bool[] {false} ;
         T00063_A145usuariosId = new string[] {""} ;
         T00063_n145usuariosId = new bool[] {false} ;
         T00068_A18SecUserId = new long[1] ;
         T00069_A18SecUserId = new long[1] ;
         T00062_A18SecUserId = new long[1] ;
         T00062_A27SecUserPassword = new string[] {""} ;
         T00062_A26SecUserName = new string[] {""} ;
         T00062_A587SecUserFullName = new string[] {""} ;
         T00062_A550SecUserEstado = new string[] {""} ;
         T00062_n550SecUserEstado = new bool[] {false} ;
         T00062_A145usuariosId = new string[] {""} ;
         T00062_n145usuariosId = new bool[] {false} ;
         T000610_A18SecUserId = new long[1] ;
         T000613_A222usuariosNombre = new string[] {""} ;
         T000613_A223usuariosPasw = new string[] {""} ;
         T000613_A226usuariosEstado = new string[] {""} ;
         T000613_A40000usuariosImagen_GXI = new string[] {""} ;
         T000613_A225usuariosTipo = new string[] {""} ;
         T000613_A266usuariosImagen = new string[] {""} ;
         T000614_A590Listaid = new long[1] ;
         T000614_A18SecUserId = new long[1] ;
         T000615_A18SecUserId = new long[1] ;
         T000615_A16SecRoleId = new short[1] ;
         T000616_A18SecUserId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i550SecUserEstado = "";
         ZV26OldSecUserName = "";
         GXt_char2 = "";
         ZV27OldusuariosId = "";
         ZV24Exite = "";
         ZV25ExiteVinculo = "";
         ZV30OdlusuariosPasw = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuser__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuser__default(),
            new Object[][] {
                new Object[] {
               T00062_A18SecUserId, T00062_A27SecUserPassword, T00062_A26SecUserName, T00062_A587SecUserFullName, T00062_A550SecUserEstado, T00062_n550SecUserEstado, T00062_A145usuariosId, T00062_n145usuariosId
               }
               , new Object[] {
               T00063_A18SecUserId, T00063_A27SecUserPassword, T00063_A26SecUserName, T00063_A587SecUserFullName, T00063_A550SecUserEstado, T00063_n550SecUserEstado, T00063_A145usuariosId, T00063_n145usuariosId
               }
               , new Object[] {
               T00064_A222usuariosNombre, T00064_A223usuariosPasw, T00064_A226usuariosEstado, T00064_A40000usuariosImagen_GXI, T00064_A225usuariosTipo, T00064_A266usuariosImagen
               }
               , new Object[] {
               T00065_A18SecUserId, T00065_A27SecUserPassword, T00065_A26SecUserName, T00065_A587SecUserFullName, T00065_A222usuariosNombre, T00065_A223usuariosPasw, T00065_A226usuariosEstado, T00065_A40000usuariosImagen_GXI, T00065_A225usuariosTipo, T00065_A550SecUserEstado,
               T00065_n550SecUserEstado, T00065_A145usuariosId, T00065_n145usuariosId, T00065_A266usuariosImagen
               }
               , new Object[] {
               T00066_A222usuariosNombre, T00066_A223usuariosPasw, T00066_A226usuariosEstado, T00066_A40000usuariosImagen_GXI, T00066_A225usuariosTipo, T00066_A266usuariosImagen
               }
               , new Object[] {
               T00067_A18SecUserId
               }
               , new Object[] {
               T00068_A18SecUserId
               }
               , new Object[] {
               T00069_A18SecUserId
               }
               , new Object[] {
               T000610_A18SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000613_A222usuariosNombre, T000613_A223usuariosPasw, T000613_A226usuariosEstado, T000613_A40000usuariosImagen_GXI, T000613_A225usuariosTipo, T000613_A266usuariosImagen
               }
               , new Object[] {
               T000614_A590Listaid, T000614_A18SecUserId
               }
               , new Object[] {
               T000615_A18SecUserId, T000615_A16SecRoleId
               }
               , new Object[] {
               T000616_A18SecUserId
               }
            }
         );
         AV32Pgmname = "WWPBaseObjects.SecUser";
         Z550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         A550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         i550SecUserEstado = "HAB";
         n550SecUserEstado = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtavUserpassword_Enabled ;
      private int edtusuariosId_Enabled ;
      private int imgprompt_145_Visible ;
      private int edtusuariosNombre_Enabled ;
      private int imgusuariosImagen_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSecUserPassword_Visible ;
      private int edtSecUserPassword_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV33GXV1 ;
      private int idxLst ;
      private long wcpOAV7SecUserId ;
      private long Z18SecUserId ;
      private long AV7SecUserId ;
      private long A18SecUserId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z550SecUserEstado ;
      private string Z145usuariosId ;
      private string O145usuariosId ;
      private string N145usuariosId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string A145usuariosId ;
      private string AV27OldusuariosId ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecUserName_Internalname ;
      private string A226usuariosEstado ;
      private string cmbusuariosEstado_Internalname ;
      private string A550SecUserEstado ;
      private string cmbSecUserEstado_Internalname ;
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
      private string edtSecUserId_Internalname ;
      private string TempTags ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string edtavUserpassword_Jsonclick ;
      private string edtusuariosId_Internalname ;
      private string edtusuariosId_Jsonclick ;
      private string imgprompt_145_gximage ;
      private string sImgUrl ;
      private string imgprompt_145_Internalname ;
      private string imgprompt_145_Link ;
      private string edtusuariosNombre_Internalname ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Jsonclick ;
      private string cmbusuariosEstado_Jsonclick ;
      private string imgusuariosImagen_Internalname ;
      private string cmbSecUserEstado_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSecUserPassword_Internalname ;
      private string edtSecUserPassword_Jsonclick ;
      private string AV16Insert_usuariosId ;
      private string AV30OdlusuariosPasw ;
      private string AV24Exite ;
      private string AV25ExiteVinculo ;
      private string A223usuariosPasw ;
      private string A225usuariosTipo ;
      private string AV32Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z222usuariosNombre ;
      private string Z223usuariosPasw ;
      private string Z226usuariosEstado ;
      private string Z225usuariosTipo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i550SecUserEstado ;
      private string GXt_char2 ;
      private string ZV27OldusuariosId ;
      private string ZV24Exite ;
      private string ZV25ExiteVinculo ;
      private string ZV30OdlusuariosPasw ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n145usuariosId ;
      private bool wbErr ;
      private bool n550SecUserEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A266usuariosImagen_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private string Z27SecUserPassword ;
      private string Z26SecUserName ;
      private string Z587SecUserFullName ;
      private string O27SecUserPassword ;
      private string O26SecUserName ;
      private string A26SecUserName ;
      private string AV28UserPassword ;
      private string AV26OldSecUserName ;
      private string A587SecUserFullName ;
      private string A40000usuariosImagen_GXI ;
      private string A27SecUserPassword ;
      private string Z40000usuariosImagen_GXI ;
      private string ZV26OldSecUserName ;
      private string A266usuariosImagen ;
      private string Z266usuariosImagen ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbusuariosEstado ;
      private GXCombobox cmbSecUserEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00064_A222usuariosNombre ;
      private string[] T00064_A223usuariosPasw ;
      private string[] T00064_A226usuariosEstado ;
      private string[] T00064_A40000usuariosImagen_GXI ;
      private string[] T00064_A225usuariosTipo ;
      private string[] T00064_A266usuariosImagen ;
      private long[] T00065_A18SecUserId ;
      private string[] T00065_A27SecUserPassword ;
      private string[] T00065_A26SecUserName ;
      private string[] T00065_A587SecUserFullName ;
      private string[] T00065_A222usuariosNombre ;
      private string[] T00065_A223usuariosPasw ;
      private string[] T00065_A226usuariosEstado ;
      private string[] T00065_A40000usuariosImagen_GXI ;
      private string[] T00065_A225usuariosTipo ;
      private string[] T00065_A550SecUserEstado ;
      private bool[] T00065_n550SecUserEstado ;
      private string[] T00065_A145usuariosId ;
      private bool[] T00065_n145usuariosId ;
      private string[] T00065_A266usuariosImagen ;
      private string[] T00066_A222usuariosNombre ;
      private string[] T00066_A223usuariosPasw ;
      private string[] T00066_A226usuariosEstado ;
      private string[] T00066_A40000usuariosImagen_GXI ;
      private string[] T00066_A225usuariosTipo ;
      private string[] T00066_A266usuariosImagen ;
      private long[] T00067_A18SecUserId ;
      private long[] T00063_A18SecUserId ;
      private string[] T00063_A27SecUserPassword ;
      private string[] T00063_A26SecUserName ;
      private string[] T00063_A587SecUserFullName ;
      private string[] T00063_A550SecUserEstado ;
      private bool[] T00063_n550SecUserEstado ;
      private string[] T00063_A145usuariosId ;
      private bool[] T00063_n145usuariosId ;
      private long[] T00068_A18SecUserId ;
      private long[] T00069_A18SecUserId ;
      private long[] T00062_A18SecUserId ;
      private string[] T00062_A27SecUserPassword ;
      private string[] T00062_A26SecUserName ;
      private string[] T00062_A587SecUserFullName ;
      private string[] T00062_A550SecUserEstado ;
      private bool[] T00062_n550SecUserEstado ;
      private string[] T00062_A145usuariosId ;
      private bool[] T00062_n145usuariosId ;
      private long[] T000610_A18SecUserId ;
      private string[] T000613_A222usuariosNombre ;
      private string[] T000613_A223usuariosPasw ;
      private string[] T000613_A226usuariosEstado ;
      private string[] T000613_A40000usuariosImagen_GXI ;
      private string[] T000613_A225usuariosTipo ;
      private string[] T000613_A266usuariosImagen ;
      private long[] T000614_A590Listaid ;
      private long[] T000614_A18SecUserId ;
      private long[] T000615_A18SecUserId ;
      private short[] T000615_A16SecRoleId ;
      private long[] T000616_A18SecUserId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secuser__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secuser__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00062;
        prmT00062 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00063;
        prmT00063 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00064;
        prmT00064 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00065;
        prmT00065 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00066;
        prmT00066 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00067;
        prmT00067 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00068;
        prmT00068 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00069;
        prmT00069 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT000610;
        prmT000610 = new Object[] {
        new ParDef("@SecUserPassword",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserName",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserFullName",GXType.NVarChar,120,0) ,
        new ParDef("@SecUserEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000611;
        prmT000611 = new Object[] {
        new ParDef("@SecUserPassword",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserName",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserFullName",GXType.NVarChar,120,0) ,
        new ParDef("@SecUserEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT000612;
        prmT000612 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT000613;
        prmT000613 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000614;
        prmT000614 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT000615;
        prmT000615 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT000616;
        prmT000616 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00062", "SELECT [SecUserId], [SecUserPassword], [SecUserName], [SecUserFullName], [SecUserEstado], [usuariosId] FROM [SecUser] WITH (UPDLOCK) WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00063", "SELECT [SecUserId], [SecUserPassword], [SecUserName], [SecUserFullName], [SecUserEstado], [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00064", "SELECT [usuariosNombre], [usuariosPasw], [usuariosEstado], [usuariosImagen_GXI], [usuariosTipo], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00065", "SELECT TM1.[SecUserId], TM1.[SecUserPassword], TM1.[SecUserName], TM1.[SecUserFullName], T2.[usuariosNombre], T2.[usuariosPasw], T2.[usuariosEstado], T2.[usuariosImagen_GXI], T2.[usuariosTipo], TM1.[SecUserEstado], TM1.[usuariosId], T2.[usuariosImagen] FROM ([SecUser] TM1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = TM1.[usuariosId]) WHERE TM1.[SecUserId] = @SecUserId ORDER BY TM1.[SecUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00066", "SELECT [usuariosNombre], [usuariosPasw], [usuariosEstado], [usuariosImagen_GXI], [usuariosTipo], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00067", "SELECT [SecUserId] FROM [SecUser] WHERE [SecUserId] = @SecUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00068", "SELECT TOP 1 [SecUserId] FROM [SecUser] WHERE ( [SecUserId] > @SecUserId) ORDER BY [SecUserId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00069", "SELECT TOP 1 [SecUserId] FROM [SecUser] WHERE ( [SecUserId] < @SecUserId) ORDER BY [SecUserId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000610", "INSERT INTO [SecUser]([SecUserPassword], [SecUserName], [SecUserFullName], [SecUserEstado], [usuariosId]) VALUES(@SecUserPassword, @SecUserName, @SecUserFullName, @SecUserEstado, @usuariosId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000611", "UPDATE [SecUser] SET [SecUserPassword]=@SecUserPassword, [SecUserName]=@SecUserName, [SecUserFullName]=@SecUserFullName, [SecUserEstado]=@SecUserEstado, [usuariosId]=@usuariosId  WHERE [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK,prmT000611)
           ,new CursorDef("T000612", "DELETE FROM [SecUser]  WHERE [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK,prmT000612)
           ,new CursorDef("T000613", "SELECT [usuariosNombre], [usuariosPasw], [usuariosEstado], [usuariosImagen_GXI], [usuariosTipo], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000614", "SELECT TOP 1 [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000615", "SELECT TOP 1 [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000616", "SELECT [SecUserId] FROM [SecUser] ORDER BY [SecUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

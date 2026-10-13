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
   public class listaagruser : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LISTAID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLALISTAID2485( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A590Listaid = (long)(Math.Round(NumberUtil.Val( GetPar( "Listaid"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A590Listaid) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A18SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A18SecUserId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedoresTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A151ProveedoresTipoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_proveedor") == 0 )
         {
            gxnrGridlevel_proveedor_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listaagruser.aspx")), "listaagruser.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listaagruser.aspx")))) ;
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
                  AV23Listaid = (long)(Math.Round(NumberUtil.Val( GetPar( "Listaid"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV23Listaid", StringUtil.LTrimStr( (decimal)(AV23Listaid), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23Listaid), "ZZZZZZZZZZZZZZZZZ9"), context));
                  AV24SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24SecUserId", StringUtil.LTrimStr( (decimal)(AV24SecUserId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24SecUserId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Agrupar Comercios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_proveedor_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_proveedor_newrow( ) ;
         /* End function gxnrGridlevel_proveedor_newrow_invoke */
      }

      public listaagruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listaagruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_Listaid ,
                           long aP2_SecUserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV23Listaid = aP1_Listaid;
         this.AV24SecUserId = aP2_SecUserId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynListaid = new GXCombobox();
         cmbListaAgrUserEstado = new GXCombobox();
         cmbAgrProveedorEstado = new GXCombobox();
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
         if ( dynListaid.ItemCount > 0 )
         {
            A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0));
            AssignProp("", false, dynListaid_Internalname, "Values", dynListaid.ToJavascriptSource(), true);
         }
         if ( cmbListaAgrUserEstado.ItemCount > 0 )
         {
            A599ListaAgrUserEstado = cmbListaAgrUserEstado.getValidValue(A599ListaAgrUserEstado);
            AssignAttri("", false, "A599ListaAgrUserEstado", A599ListaAgrUserEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaAgrUserEstado.CurrentValue = StringUtil.RTrim( A599ListaAgrUserEstado);
            AssignProp("", false, cmbListaAgrUserEstado_Internalname, "Values", cmbListaAgrUserEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynListaid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynListaid_Internalname, context.GetMessage( "Listaid", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynListaid, dynListaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0)), 1, dynListaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynListaid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_ListaAgrUser.htm");
         dynListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0));
         AssignProp("", false, dynListaid_Internalname, "Values", (string)(dynListaid.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ListaAgrUser.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_18_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_18_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_18_Internalname, sImgUrl, imgprompt_18_Link, "", "", context.GetTheme( ), imgprompt_18_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ListaAgrUser.htm");
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
         GxWebStd.gx_label_element( context, edtSecUserFullName_Internalname, context.GetMessage( "Nombre Completo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserFullName_Internalname, A587SecUserFullName, StringUtil.RTrim( context.localUtil.Format( A587SecUserFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserFullName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ListaAgrUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaAgrUserEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbListaAgrUserEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbListaAgrUserEstado, cmbListaAgrUserEstado_Internalname, StringUtil.RTrim( A599ListaAgrUserEstado), 1, cmbListaAgrUserEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaAgrUserEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_ListaAgrUser.htm");
         cmbListaAgrUserEstado.CurrentValue = StringUtil.RTrim( A599ListaAgrUserEstado);
         AssignProp("", false, cmbListaAgrUserEstado_Internalname, "Values", (string)(cmbListaAgrUserEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_proveedor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_proveedor( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrUser.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrUser.htm");
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

      protected void gxdraw_Gridlevel_proveedor( )
      {
         /*  Grid Control  */
         StartGridControl43( ) ;
         nGXsfl_43_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount86 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_86 = 1;
               ScanStart2486( ) ;
               while ( RcdFound86 != 0 )
               {
                  init_level_properties86( ) ;
                  getByPrimaryKey2486( ) ;
                  AddRow2486( ) ;
                  ScanNext2486( ) ;
               }
               ScanEnd2486( ) ;
               nBlankRcdCount86 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2486( ) ;
            standaloneModal2486( ) ;
            sMode86 = Gx_mode;
            while ( nGXsfl_43_idx < nRC_GXsfl_43 )
            {
               bGXsfl_43_Refreshing = true;
               ReadRow2486( ) ;
               edtProveedorID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtProveedoresTipoDescripcion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedoresTipoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtProveedorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORNOMBRE_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtProveedorTelefono_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORTELEFONO_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtProveedorEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDOREMAIL_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtAgrProveedorComent_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRPROVEEDORCOMENT_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAgrProveedorComent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgrProveedorComent_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               cmbAgrProveedorEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRPROVEEDORESTADO_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbAgrProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgrProveedorEstado.Enabled), 5, 0), !bGXsfl_43_Refreshing);
               imgprompt_18_Link = cgiGet( "PROMPT_133_"+sGXsfl_43_idx+"Link");
               if ( ( nRcdExists_86 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2486( ) ;
               }
               SendRow2486( ) ;
               bGXsfl_43_Refreshing = false;
            }
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount86 = 5;
            nRcdExists_86 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2486( ) ;
               while ( RcdFound86 != 0 )
               {
                  sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4386( ) ;
                  init_level_properties86( ) ;
                  standaloneNotModal2486( ) ;
                  getByPrimaryKey2486( ) ;
                  standaloneModal2486( ) ;
                  AddRow2486( ) ;
                  ScanNext2486( ) ;
               }
               ScanEnd2486( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode86 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4386( ) ;
            InitAll2486( ) ;
            init_level_properties86( ) ;
            nRcdExists_86 = 0;
            nIsMod_86 = 0;
            nRcdDeleted_86 = 0;
            nBlankRcdCount86 = (short)(nBlankRcdUsr86+nBlankRcdCount86);
            fRowAdded = 0;
            while ( nBlankRcdCount86 > 0 )
            {
               standaloneNotModal2486( ) ;
               standaloneModal2486( ) ;
               AddRow2486( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount86 = (short)(nBlankRcdCount86-1);
            }
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_proveedorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_proveedor", Gridlevel_proveedorContainer, subGridlevel_proveedor_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_proveedorContainerData", Gridlevel_proveedorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_proveedorContainerData"+"V", Gridlevel_proveedorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_proveedorContainerData"+"V"+"\" value='"+Gridlevel_proveedorContainer.GridValuesHidden()+"'/>") ;
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
         E11242 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z590Listaid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z18SecUserId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z599ListaAgrUserEstado = cgiGet( "Z599ListaAgrUserEstado");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV23Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vLISTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV24SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSECUSERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV25Pgmname = cgiGet( "vPGMNAME");
               A151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTIPOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               dynListaid.Name = dynListaid_Internalname;
               dynListaid.CurrentValue = cgiGet( dynListaid_Internalname);
               A590Listaid = (long)(Math.Round(NumberUtil.Val( cgiGet( dynListaid_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A18SecUserId = 0;
                  AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               }
               else
               {
                  A18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               }
               A587SecUserFullName = cgiGet( edtSecUserFullName_Internalname);
               AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
               cmbListaAgrUserEstado.Name = cmbListaAgrUserEstado_Internalname;
               cmbListaAgrUserEstado.CurrentValue = cgiGet( cmbListaAgrUserEstado_Internalname);
               A599ListaAgrUserEstado = cgiGet( cmbListaAgrUserEstado_Internalname);
               AssignAttri("", false, "A599ListaAgrUserEstado", A599ListaAgrUserEstado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ListaAgrUser");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A590Listaid != Z590Listaid ) || ( A18SecUserId != Z18SecUserId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("listaagruser:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A590Listaid = (long)(Math.Round(NumberUtil.Val( GetPar( "Listaid"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
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
                     sMode85 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode85;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound85 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_240( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LISTAID");
                        AnyError = 1;
                        GX_FocusControl = dynListaid_Internalname;
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
                           E11242 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12242 ();
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
            E12242 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2485( ) ;
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
            DisableAttributes2485( ) ;
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

      protected void CONFIRM_240( )
      {
         BeforeValidate2485( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2485( ) ;
            }
            else
            {
               CheckExtendedTable2485( ) ;
               CloseExtendedTableCursors2485( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode85 = Gx_mode;
            CONFIRM_2486( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode85;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2486( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow2486( ) ;
            if ( ( nRcdExists_86 != 0 ) || ( nIsMod_86 != 0 ) )
            {
               GetKey2486( ) ;
               if ( ( nRcdExists_86 == 0 ) && ( nRcdDeleted_86 == 0 ) )
               {
                  if ( RcdFound86 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2486( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2486( ) ;
                        CloseExtendedTableCursors2486( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROVEEDORID_" + sGXsfl_43_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound86 != 0 )
                  {
                     if ( nRcdDeleted_86 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2486( ) ;
                        Load2486( ) ;
                        BeforeValidate2486( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2486( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_86 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2486( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2486( ) ;
                              CloseExtendedTableCursors2486( ) ;
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
                     if ( nRcdDeleted_86 == 0 )
                     {
                        GXCCtl = "PROVEEDORID_" + sGXsfl_43_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProveedorID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedoresTipoDescripcion_Internalname, A279ProveedoresTipoDescripcion) ;
            ChangePostValue( edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre)) ;
            ChangePostValue( edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono)) ;
            ChangePostValue( edtProveedorEmail_Internalname, A433ProveedorEmail) ;
            ChangePostValue( edtAgrProveedorComent_Internalname, A596AgrProveedorComent) ;
            ChangePostValue( cmbAgrProveedorEstado_Internalname, StringUtil.RTrim( A594AgrProveedorEstado)) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z594AgrProveedorEstado_"+sGXsfl_43_idx, StringUtil.RTrim( Z594AgrProveedorEstado)) ;
            ChangePostValue( "nRcdDeleted_86_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_86), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_86_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_86), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_86_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_86), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_86 != 0 )
            {
               ChangePostValue( "PROVEEDORID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORNOMBRE_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORTELEFONO_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDOREMAIL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRPROVEEDORCOMENT_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrProveedorComent_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRPROVEEDORESTADO_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrProveedorEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption240( )
      {
      }

      protected void E11242( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV7IsAuthorized = true;
         AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrUser_Insert", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrUser_Update", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrUser_Delete", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( ! AV7IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV25Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12242( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("listaagruserww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2485( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z599ListaAgrUserEstado = T00247_A599ListaAgrUserEstado[0];
            }
            else
            {
               Z599ListaAgrUserEstado = A599ListaAgrUserEstado;
            }
         }
         if ( GX_JID == -10 )
         {
            Z599ListaAgrUserEstado = A599ListaAgrUserEstado;
            Z590Listaid = A590Listaid;
            Z18SecUserId = A18SecUserId;
            Z587SecUserFullName = A587SecUserFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         GXALISTAID_html2485( ) ;
         imgprompt_18_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"wwpbaseobjects.secuserprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECUSERID"+"'), id:'"+"SECUSERID"+"'"+",IOType:'inout',isKey:true,isLastKey:true}"+","+"{Ctrl:gx.dom.el('"+"SECUSERFULLNAME"+"'), id:'"+"SECUSERFULLNAME"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV23Listaid) )
         {
            A590Listaid = AV23Listaid;
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         }
         if ( ! (0==AV23Listaid) )
         {
            dynListaid.Enabled = 0;
            AssignProp("", false, dynListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynListaid.Enabled), 5, 0), true);
         }
         else
         {
            dynListaid.Enabled = 1;
            AssignProp("", false, dynListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynListaid.Enabled), 5, 0), true);
         }
         if ( ! (0==AV23Listaid) )
         {
            dynListaid.Enabled = 0;
            AssignProp("", false, dynListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynListaid.Enabled), 5, 0), true);
         }
         if ( ! (0==AV24SecUserId) )
         {
            A18SecUserId = AV24SecUserId;
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         }
         if ( ! (0==AV24SecUserId) )
         {
            edtSecUserId_Enabled = 0;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         }
         else
         {
            edtSecUserId_Enabled = 1;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV24SecUserId) )
         {
            edtSecUserId_Enabled = 0;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
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
            AV25Pgmname = "ListaAgrUser";
            AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
            /* Using cursor T00249 */
            pr_default.execute(7, new Object[] {A18SecUserId});
            A587SecUserFullName = T00249_A587SecUserFullName[0];
            AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
            pr_default.close(7);
         }
      }

      protected void Load2485( )
      {
         /* Using cursor T002410 */
         pr_default.execute(8, new Object[] {A590Listaid, A18SecUserId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound85 = 1;
            A587SecUserFullName = T002410_A587SecUserFullName[0];
            AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
            A599ListaAgrUserEstado = T002410_A599ListaAgrUserEstado[0];
            AssignAttri("", false, "A599ListaAgrUserEstado", A599ListaAgrUserEstado);
            ZM2485( -10) ;
         }
         pr_default.close(8);
         OnLoadActions2485( ) ;
      }

      protected void OnLoadActions2485( )
      {
         AV25Pgmname = "ListaAgrUser";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable2485( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "ListaAgrUser";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         /* Using cursor T00248 */
         pr_default.execute(6, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = dynListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         /* Using cursor T00249 */
         pr_default.execute(7, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A587SecUserFullName = T00249_A587SecUserFullName[0];
         AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
         pr_default.close(7);
         if ( ! ( ( StringUtil.StrCmp(A599ListaAgrUserEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A599ListaAgrUserEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A599ListaAgrUserEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A599ListaAgrUserEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "LISTAAGRUSERESTADO");
            AnyError = 1;
            GX_FocusControl = cmbListaAgrUserEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2485( )
      {
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( long A590Listaid )
      {
         /* Using cursor T002411 */
         pr_default.execute(9, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = dynListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_12( long A18SecUserId )
      {
         /* Using cursor T002412 */
         pr_default.execute(10, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A587SecUserFullName = T002412_A587SecUserFullName[0];
         AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A587SecUserFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey2485( )
      {
         /* Using cursor T002413 */
         pr_default.execute(11, new Object[] {A590Listaid, A18SecUserId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00247 */
         pr_default.execute(5, new Object[] {A590Listaid, A18SecUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM2485( 10) ;
            RcdFound85 = 1;
            A599ListaAgrUserEstado = T00247_A599ListaAgrUserEstado[0];
            AssignAttri("", false, "A599ListaAgrUserEstado", A599ListaAgrUserEstado);
            A590Listaid = T00247_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            A18SecUserId = T00247_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            Z590Listaid = A590Listaid;
            Z18SecUserId = A18SecUserId;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2485( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey2485( ) ;
            }
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey2485( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey2485( ) ;
         if ( RcdFound85 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound85 = 0;
         /* Using cursor T002414 */
         pr_default.execute(12, new Object[] {A590Listaid, A18SecUserId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T002414_A590Listaid[0] < A590Listaid ) || ( T002414_A590Listaid[0] == A590Listaid ) && ( T002414_A18SecUserId[0] < A18SecUserId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T002414_A590Listaid[0] > A590Listaid ) || ( T002414_A590Listaid[0] == A590Listaid ) && ( T002414_A18SecUserId[0] > A18SecUserId ) ) )
            {
               A590Listaid = T002414_A590Listaid[0];
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               A18SecUserId = T002414_A18SecUserId[0];
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               RcdFound85 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound85 = 0;
         /* Using cursor T002415 */
         pr_default.execute(13, new Object[] {A590Listaid, A18SecUserId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T002415_A590Listaid[0] > A590Listaid ) || ( T002415_A590Listaid[0] == A590Listaid ) && ( T002415_A18SecUserId[0] > A18SecUserId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T002415_A590Listaid[0] < A590Listaid ) || ( T002415_A590Listaid[0] == A590Listaid ) && ( T002415_A18SecUserId[0] < A18SecUserId ) ) )
            {
               A590Listaid = T002415_A590Listaid[0];
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               A18SecUserId = T002415_A18SecUserId[0];
               AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
               RcdFound85 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2485( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2485( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( ( A590Listaid != Z590Listaid ) || ( A18SecUserId != Z18SecUserId ) )
               {
                  A590Listaid = Z590Listaid;
                  AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
                  A18SecUserId = Z18SecUserId;
                  AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LISTAID");
                  AnyError = 1;
                  GX_FocusControl = dynListaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynListaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2485( ) ;
                  GX_FocusControl = dynListaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A590Listaid != Z590Listaid ) || ( A18SecUserId != Z18SecUserId ) )
               {
                  /* Insert record */
                  GX_FocusControl = dynListaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2485( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LISTAID");
                     AnyError = 1;
                     GX_FocusControl = dynListaid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynListaid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2485( ) ;
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
         if ( ( A590Listaid != Z590Listaid ) || ( A18SecUserId != Z18SecUserId ) )
         {
            A590Listaid = Z590Listaid;
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            A18SecUserId = Z18SecUserId;
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = dynListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2485( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00246 */
            pr_default.execute(4, new Object[] {A590Listaid, A18SecUserId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaAgrUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z599ListaAgrUserEstado, T00246_A599ListaAgrUserEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z599ListaAgrUserEstado, T00246_A599ListaAgrUserEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagruser:[seudo value changed for attri]"+"ListaAgrUserEstado");
                  GXUtil.WriteLogRaw("Old: ",Z599ListaAgrUserEstado);
                  GXUtil.WriteLogRaw("Current: ",T00246_A599ListaAgrUserEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ListaAgrUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2485( )
      {
         BeforeValidate2485( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2485( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2485( 0) ;
            CheckOptimisticConcurrency2485( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2485( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2485( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002416 */
                     pr_default.execute(14, new Object[] {A599ListaAgrUserEstado, A590Listaid, A18SecUserId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("ListaAgrUser");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ProcessLevel2485( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption240( ) ;
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
               Load2485( ) ;
            }
            EndLevel2485( ) ;
         }
         CloseExtendedTableCursors2485( ) ;
      }

      protected void Update2485( )
      {
         BeforeValidate2485( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2485( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2485( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2485( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2485( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002417 */
                     pr_default.execute(15, new Object[] {A599ListaAgrUserEstado, A590Listaid, A18SecUserId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("ListaAgrUser");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaAgrUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2485( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2485( ) ;
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
            EndLevel2485( ) ;
         }
         CloseExtendedTableCursors2485( ) ;
      }

      protected void DeferredUpdate2485( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2485( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2485( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2485( ) ;
            AfterConfirm2485( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2485( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2486( ) ;
                  while ( RcdFound86 != 0 )
                  {
                     getByPrimaryKey2486( ) ;
                     Delete2486( ) ;
                     ScanNext2486( ) ;
                  }
                  ScanEnd2486( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002418 */
                     pr_default.execute(16, new Object[] {A590Listaid, A18SecUserId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("ListaAgrUser");
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2485( ) ;
         Gx_mode = sMode85;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2485( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "ListaAgrUser";
            AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
            /* Using cursor T002419 */
            pr_default.execute(17, new Object[] {A18SecUserId});
            A587SecUserFullName = T002419_A587SecUserFullName[0];
            AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel2486( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow2486( ) ;
            if ( ( nRcdExists_86 != 0 ) || ( nIsMod_86 != 0 ) )
            {
               standaloneNotModal2486( ) ;
               GetKey2486( ) ;
               if ( ( nRcdExists_86 == 0 ) && ( nRcdDeleted_86 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2486( ) ;
               }
               else
               {
                  if ( RcdFound86 != 0 )
                  {
                     if ( ( nRcdDeleted_86 != 0 ) && ( nRcdExists_86 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2486( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_86 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2486( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_86 == 0 )
                     {
                        GXCCtl = "PROVEEDORID_" + sGXsfl_43_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProveedorID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedoresTipoDescripcion_Internalname, A279ProveedoresTipoDescripcion) ;
            ChangePostValue( edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre)) ;
            ChangePostValue( edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono)) ;
            ChangePostValue( edtProveedorEmail_Internalname, A433ProveedorEmail) ;
            ChangePostValue( edtAgrProveedorComent_Internalname, A596AgrProveedorComent) ;
            ChangePostValue( cmbAgrProveedorEstado_Internalname, StringUtil.RTrim( A594AgrProveedorEstado)) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z594AgrProveedorEstado_"+sGXsfl_43_idx, StringUtil.RTrim( Z594AgrProveedorEstado)) ;
            ChangePostValue( "nRcdDeleted_86_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_86), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_86_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_86), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_86_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_86), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_86 != 0 )
            {
               ChangePostValue( "PROVEEDORID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORNOMBRE_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORTELEFONO_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDOREMAIL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRPROVEEDORCOMENT_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrProveedorComent_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRPROVEEDORESTADO_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrProveedorEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2486( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_86 = 0;
         nIsMod_86 = 0;
         nRcdDeleted_86 = 0;
      }

      protected void ProcessLevel2485( )
      {
         /* Save parent mode. */
         sMode85 = Gx_mode;
         ProcessNestedLevel2486( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode85;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2485( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2485( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("listaagruser",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues240( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("listaagruser",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2485( )
      {
         /* Scan By routine */
         /* Using cursor T002420 */
         pr_default.execute(18);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound85 = 1;
            A590Listaid = T002420_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            A18SecUserId = T002420_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2485( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound85 = 1;
            A590Listaid = T002420_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            A18SecUserId = T002420_A18SecUserId[0];
            AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         }
      }

      protected void ScanEnd2485( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2485( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2485( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2485( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2485( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2485( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2485( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2485( )
      {
         dynListaid.Enabled = 0;
         AssignProp("", false, dynListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynListaid.Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtSecUserFullName_Enabled = 0;
         AssignProp("", false, edtSecUserFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserFullName_Enabled), 5, 0), true);
         cmbListaAgrUserEstado.Enabled = 0;
         AssignProp("", false, cmbListaAgrUserEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaAgrUserEstado.Enabled), 5, 0), true);
      }

      protected void ZM2486( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z594AgrProveedorEstado = T00243_A594AgrProveedorEstado[0];
            }
            else
            {
               Z594AgrProveedorEstado = A594AgrProveedorEstado;
            }
         }
         if ( GX_JID == -13 )
         {
            Z590Listaid = A590Listaid;
            Z18SecUserId = A18SecUserId;
            Z596AgrProveedorComent = A596AgrProveedorComent;
            Z594AgrProveedorEstado = A594AgrProveedorEstado;
            Z133ProveedorID = A133ProveedorID;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z279ProveedoresTipoDescripcion = A279ProveedoresTipoDescripcion;
         }
      }

      protected void standaloneNotModal2486( )
      {
      }

      protected void standaloneModal2486( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProveedorID_Enabled = 0;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         }
         else
         {
            edtProveedorID_Enabled = 1;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         }
      }

      protected void Load2486( )
      {
         /* Using cursor T002421 */
         pr_default.execute(19, new Object[] {A590Listaid, A18SecUserId, A133ProveedorID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound86 = 1;
            A151ProveedoresTipoId = T002421_A151ProveedoresTipoId[0];
            A282ProveedorNombre = T002421_A282ProveedorNombre[0];
            A279ProveedoresTipoDescripcion = T002421_A279ProveedoresTipoDescripcion[0];
            A430ProveedorTelefono = T002421_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T002421_n430ProveedorTelefono[0];
            A433ProveedorEmail = T002421_A433ProveedorEmail[0];
            n433ProveedorEmail = T002421_n433ProveedorEmail[0];
            A596AgrProveedorComent = T002421_A596AgrProveedorComent[0];
            n596AgrProveedorComent = T002421_n596AgrProveedorComent[0];
            A594AgrProveedorEstado = T002421_A594AgrProveedorEstado[0];
            n594AgrProveedorEstado = T002421_n594AgrProveedorEstado[0];
            ZM2486( -13) ;
         }
         pr_default.close(19);
         OnLoadActions2486( ) ;
      }

      protected void OnLoadActions2486( )
      {
      }

      protected void CheckExtendedTable2486( )
      {
         nIsDirty_86 = 0;
         Gx_BScreen = 1;
         standaloneModal2486( ) ;
         /* Using cursor T00244 */
         pr_default.execute(2, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A151ProveedoresTipoId = T00244_A151ProveedoresTipoId[0];
         A282ProveedorNombre = T00244_A282ProveedorNombre[0];
         A430ProveedorTelefono = T00244_A430ProveedorTelefono[0];
         n430ProveedorTelefono = T00244_n430ProveedorTelefono[0];
         A433ProveedorEmail = T00244_A433ProveedorEmail[0];
         n433ProveedorEmail = T00244_n433ProveedorEmail[0];
         pr_default.close(2);
         /* Using cursor T00245 */
         pr_default.execute(3, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A279ProveedoresTipoDescripcion = T00245_A279ProveedoresTipoDescripcion[0];
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A594AgrProveedorEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A594AgrProveedorEstado, "VIN") == 0 ) || ( StringUtil.StrCmp(A594AgrProveedorEstado, "DES") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A594AgrProveedorEstado)) ) )
         {
            GXCCtl = "AGRPROVEEDORESTADO_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbAgrProveedorEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2486( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable2486( )
      {
      }

      protected void gxLoad_14( long A133ProveedorID )
      {
         /* Using cursor T002422 */
         pr_default.execute(20, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A151ProveedoresTipoId = T002422_A151ProveedoresTipoId[0];
         A282ProveedorNombre = T002422_A282ProveedorNombre[0];
         A430ProveedorTelefono = T002422_A430ProveedorTelefono[0];
         n430ProveedorTelefono = T002422_n430ProveedorTelefono[0];
         A433ProveedorEmail = T002422_A433ProveedorEmail[0];
         n433ProveedorEmail = T002422_n433ProveedorEmail[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A430ProveedorTelefono))+"\""+","+"\""+GXUtil.EncodeJSConstant( A433ProveedorEmail)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_15( long A151ProveedoresTipoId )
      {
         /* Using cursor T002423 */
         pr_default.execute(21, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A279ProveedoresTipoDescripcion = T002423_A279ProveedoresTipoDescripcion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A279ProveedoresTipoDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void GetKey2486( )
      {
         /* Using cursor T002424 */
         pr_default.execute(22, new Object[] {A590Listaid, A18SecUserId, A133ProveedorID});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey2486( )
      {
         /* Using cursor T00243 */
         pr_default.execute(1, new Object[] {A590Listaid, A18SecUserId, A133ProveedorID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2486( 13) ;
            RcdFound86 = 1;
            InitializeNonKey2486( ) ;
            A596AgrProveedorComent = T00243_A596AgrProveedorComent[0];
            n596AgrProveedorComent = T00243_n596AgrProveedorComent[0];
            A594AgrProveedorEstado = T00243_A594AgrProveedorEstado[0];
            n594AgrProveedorEstado = T00243_n594AgrProveedorEstado[0];
            A133ProveedorID = T00243_A133ProveedorID[0];
            Z590Listaid = A590Listaid;
            Z18SecUserId = A18SecUserId;
            Z133ProveedorID = A133ProveedorID;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2486( ) ;
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey2486( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2486( ) ;
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2486( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2486( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00242 */
            pr_default.execute(0, new Object[] {A590Listaid, A18SecUserId, A133ProveedorID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaAgrUserProveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z594AgrProveedorEstado, T00242_A594AgrProveedorEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z594AgrProveedorEstado, T00242_A594AgrProveedorEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagruser:[seudo value changed for attri]"+"AgrProveedorEstado");
                  GXUtil.WriteLogRaw("Old: ",Z594AgrProveedorEstado);
                  GXUtil.WriteLogRaw("Current: ",T00242_A594AgrProveedorEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ListaAgrUserProveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2486( )
      {
         BeforeValidate2486( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2486( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2486( 0) ;
            CheckOptimisticConcurrency2486( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2486( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2486( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002425 */
                     pr_default.execute(23, new Object[] {A590Listaid, A18SecUserId, n596AgrProveedorComent, A596AgrProveedorComent, n594AgrProveedorEstado, A594AgrProveedorEstado, A133ProveedorID});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("ListaAgrUserProveedor");
                     if ( (pr_default.getStatus(23) == 1) )
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
               Load2486( ) ;
            }
            EndLevel2486( ) ;
         }
         CloseExtendedTableCursors2486( ) ;
      }

      protected void Update2486( )
      {
         BeforeValidate2486( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2486( ) ;
         }
         if ( ( nIsMod_86 != 0 ) || ( nIsDirty_86 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2486( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2486( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2486( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002426 */
                        pr_default.execute(24, new Object[] {n596AgrProveedorComent, A596AgrProveedorComent, n594AgrProveedorEstado, A594AgrProveedorEstado, A590Listaid, A18SecUserId, A133ProveedorID});
                        pr_default.close(24);
                        pr_default.SmartCacheProvider.SetUpdated("ListaAgrUserProveedor");
                        if ( (pr_default.getStatus(24) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaAgrUserProveedor"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2486( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2486( ) ;
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
               EndLevel2486( ) ;
            }
         }
         CloseExtendedTableCursors2486( ) ;
      }

      protected void DeferredUpdate2486( )
      {
      }

      protected void Delete2486( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2486( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2486( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2486( ) ;
            AfterConfirm2486( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2486( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002427 */
                  pr_default.execute(25, new Object[] {A590Listaid, A18SecUserId, A133ProveedorID});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("ListaAgrUserProveedor");
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2486( ) ;
         Gx_mode = sMode86;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2486( )
      {
         standaloneModal2486( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002428 */
            pr_default.execute(26, new Object[] {A133ProveedorID});
            A151ProveedoresTipoId = T002428_A151ProveedoresTipoId[0];
            A282ProveedorNombre = T002428_A282ProveedorNombre[0];
            A430ProveedorTelefono = T002428_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T002428_n430ProveedorTelefono[0];
            A433ProveedorEmail = T002428_A433ProveedorEmail[0];
            n433ProveedorEmail = T002428_n433ProveedorEmail[0];
            pr_default.close(26);
            /* Using cursor T002429 */
            pr_default.execute(27, new Object[] {A151ProveedoresTipoId});
            A279ProveedoresTipoDescripcion = T002429_A279ProveedoresTipoDescripcion[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel2486( )
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

      public void ScanStart2486( )
      {
         /* Scan By routine */
         /* Using cursor T002430 */
         pr_default.execute(28, new Object[] {A590Listaid, A18SecUserId});
         RcdFound86 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound86 = 1;
            A133ProveedorID = T002430_A133ProveedorID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2486( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound86 = 1;
            A133ProveedorID = T002430_A133ProveedorID[0];
         }
      }

      protected void ScanEnd2486( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm2486( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2486( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2486( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2486( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2486( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2486( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2486( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtProveedoresTipoDescripcion_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtProveedorTelefono_Enabled = 0;
         AssignProp("", false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtProveedorEmail_Enabled = 0;
         AssignProp("", false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtAgrProveedorComent_Enabled = 0;
         AssignProp("", false, edtAgrProveedorComent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgrProveedorComent_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         cmbAgrProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbAgrProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgrProveedorEstado.Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void send_integrity_lvl_hashes2486( )
      {
      }

      protected void send_integrity_lvl_hashes2485( )
      {
      }

      protected void SubsflControlProps_4386( )
      {
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_43_idx;
         imgprompt_133_Internalname = "PROMPT_133_"+sGXsfl_43_idx;
         edtProveedoresTipoDescripcion_Internalname = "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_43_idx;
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO_"+sGXsfl_43_idx;
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL_"+sGXsfl_43_idx;
         edtAgrProveedorComent_Internalname = "AGRPROVEEDORCOMENT_"+sGXsfl_43_idx;
         cmbAgrProveedorEstado_Internalname = "AGRPROVEEDORESTADO_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_4386( )
      {
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_43_fel_idx;
         imgprompt_133_Internalname = "PROMPT_133_"+sGXsfl_43_fel_idx;
         edtProveedoresTipoDescripcion_Internalname = "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_43_fel_idx;
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO_"+sGXsfl_43_fel_idx;
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL_"+sGXsfl_43_fel_idx;
         edtAgrProveedorComent_Internalname = "AGRPROVEEDORCOMENT_"+sGXsfl_43_fel_idx;
         cmbAgrProveedorEstado_Internalname = "AGRPROVEEDORESTADO_"+sGXsfl_43_fel_idx;
      }

      protected void AddRow2486( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4386( ) ;
         SendRow2486( ) ;
      }

      protected void SendRow2486( )
      {
         Gridlevel_proveedorRow = GXWebRow.GetNew(context);
         if ( subGridlevel_proveedor_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_proveedor_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_proveedor_Class, "") != 0 )
            {
               subGridlevel_proveedor_Linesclass = subGridlevel_proveedor_Class+"Odd";
            }
         }
         else if ( subGridlevel_proveedor_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_proveedor_Backstyle = 0;
            subGridlevel_proveedor_Backcolor = subGridlevel_proveedor_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_proveedor_Class, "") != 0 )
            {
               subGridlevel_proveedor_Linesclass = subGridlevel_proveedor_Class+"Uniform";
            }
         }
         else if ( subGridlevel_proveedor_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_proveedor_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_proveedor_Class, "") != 0 )
            {
               subGridlevel_proveedor_Linesclass = subGridlevel_proveedor_Class+"Odd";
            }
            subGridlevel_proveedor_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_proveedor_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_proveedor_Backstyle = 1;
            if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
            {
               subGridlevel_proveedor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_proveedor_Class, "") != 0 )
               {
                  subGridlevel_proveedor_Linesclass = subGridlevel_proveedor_Class+"Even";
               }
            }
            else
            {
               subGridlevel_proveedor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_proveedor_Class, "") != 0 )
               {
                  subGridlevel_proveedor_Linesclass = subGridlevel_proveedor_Class+"Odd";
               }
            }
         }
         imgprompt_133_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORID_"+sGXsfl_43_idx+"'), id:'"+"PROVEEDORID_"+sGXsfl_43_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROVEEDORNOMBRE_"+sGXsfl_43_idx+"'), id:'"+"PROVEEDORNOMBRE_"+sGXsfl_43_idx+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_86_"+sGXsfl_43_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorID_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_133_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_133_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_proveedorRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_133_Internalname,(string)sImgUrl,(string)imgprompt_133_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_133_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedoresTipoDescripcion_Internalname,(string)A279ProveedoresTipoDescripcion,(string)A279ProveedoresTipoDescripcion,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedoresTipoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedoresTipoDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)43,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorTelefono_Internalname,StringUtil.RTrim( A430ProveedorTelefono),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProveedorTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorTelefono_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorEmail_Internalname,(string)A433ProveedorEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A433ProveedorEmail,(string)"",(string)"",(string)"",(string)edtProveedorEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgrProveedorComent_Internalname,(string)A596AgrProveedorComent,(string)A596AgrProveedorComent,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgrProveedorComent_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAgrProveedorComent_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)43,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_86_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_43_idx + "',43)\"";
         if ( ( cmbAgrProveedorEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "AGRPROVEEDORESTADO_" + sGXsfl_43_idx;
            cmbAgrProveedorEstado.Name = GXCCtl;
            cmbAgrProveedorEstado.WebTags = "";
            cmbAgrProveedorEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
            cmbAgrProveedorEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
            cmbAgrProveedorEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
            if ( cmbAgrProveedorEstado.ItemCount > 0 )
            {
               A594AgrProveedorEstado = cmbAgrProveedorEstado.getValidValue(A594AgrProveedorEstado);
               n594AgrProveedorEstado = false;
            }
         }
         /* ComboBox */
         Gridlevel_proveedorRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAgrProveedorEstado,(string)cmbAgrProveedorEstado_Internalname,StringUtil.RTrim( A594AgrProveedorEstado),(short)1,(string)cmbAgrProveedorEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbAgrProveedorEstado.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"",(bool)true,(short)0});
         cmbAgrProveedorEstado.CurrentValue = StringUtil.RTrim( A594AgrProveedorEstado);
         AssignProp("", false, cmbAgrProveedorEstado_Internalname, "Values", (string)(cmbAgrProveedorEstado.ToJavascriptSource()), !bGXsfl_43_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_proveedorRow);
         send_integrity_lvl_hashes2486( ) ;
         GXCCtl = "Z133ProveedorID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z594AgrProveedorEstado_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z594AgrProveedorEstado));
         GXCCtl = "nRcdDeleted_86_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_86), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_86_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_86), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_86_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_86), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_43_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV8TrnContext);
         }
         GXCCtl = "vLISTAID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vSECUSERID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORNOMBRE_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORTELEFONO_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDOREMAIL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AGRPROVEEDORCOMENT_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrProveedorComent_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AGRPROVEEDORESTADO_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrProveedorEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_133_"+sGXsfl_43_idx+"Link", StringUtil.RTrim( imgprompt_133_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_proveedorContainer.AddRow(Gridlevel_proveedorRow);
      }

      protected void ReadRow2486( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4386( ) ;
         edtProveedorID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedoresTipoDescripcion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORNOMBRE_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorTelefono_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORTELEFONO_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDOREMAIL_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAgrProveedorComent_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRPROVEEDORCOMENT_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbAgrProveedorEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRPROVEEDORESTADO_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_18_Link = cgiGet( "PROMPT_133_"+sGXsfl_43_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_43_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            wbErr = true;
            A133ProveedorID = 0;
         }
         else
         {
            A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A279ProveedoresTipoDescripcion = cgiGet( edtProveedoresTipoDescripcion_Internalname);
         A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
         A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
         n430ProveedorTelefono = false;
         A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
         n433ProveedorEmail = false;
         A596AgrProveedorComent = cgiGet( edtAgrProveedorComent_Internalname);
         n596AgrProveedorComent = false;
         n596AgrProveedorComent = (String.IsNullOrEmpty(StringUtil.RTrim( A596AgrProveedorComent)) ? true : false);
         cmbAgrProveedorEstado.Name = cmbAgrProveedorEstado_Internalname;
         cmbAgrProveedorEstado.CurrentValue = cgiGet( cmbAgrProveedorEstado_Internalname);
         A594AgrProveedorEstado = cgiGet( cmbAgrProveedorEstado_Internalname);
         n594AgrProveedorEstado = false;
         n594AgrProveedorEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A594AgrProveedorEstado)) ? true : false);
         GXCCtl = "Z133ProveedorID_" + sGXsfl_43_idx;
         Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z594AgrProveedorEstado_" + sGXsfl_43_idx;
         Z594AgrProveedorEstado = cgiGet( GXCCtl);
         n594AgrProveedorEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A594AgrProveedorEstado)) ? true : false);
         GXCCtl = "nRcdDeleted_86_" + sGXsfl_43_idx;
         nRcdDeleted_86 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_86_" + sGXsfl_43_idx;
         nRcdExists_86 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_86_" + sGXsfl_43_idx;
         nIsMod_86 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProveedorID_Enabled = edtProveedorID_Enabled;
      }

      protected void ConfirmValues240( )
      {
         nGXsfl_43_idx = 0;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4386( ) ;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_4386( ) ;
            ChangePostValue( "Z133ProveedorID_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z133ProveedorID_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z594AgrProveedorEstado_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z594AgrProveedorEstado_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z594AgrProveedorEstado_"+sGXsfl_43_idx) ;
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
         GXEncryptionTmp = "listaagruser.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV23Listaid,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV24SecUserId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listaagruser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ListaAgrUser");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("listaagruser:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z590Listaid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z18SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z599ListaAgrUserEstado", StringUtil.RTrim( Z599ListaAgrUserEstado));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_43_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23Listaid), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "listaagruser.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV23Listaid,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV24SecUserId,10,0));
         return formatLink("listaagruser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ListaAgrUser" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Agrupar Comercios", "") ;
      }

      protected void InitializeNonKey2485( )
      {
         A587SecUserFullName = "";
         AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
         A599ListaAgrUserEstado = "";
         AssignAttri("", false, "A599ListaAgrUserEstado", A599ListaAgrUserEstado);
         Z599ListaAgrUserEstado = "";
      }

      protected void InitAll2485( )
      {
         A590Listaid = 0;
         AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         A18SecUserId = 0;
         AssignAttri("", false, "A18SecUserId", StringUtil.LTrimStr( (decimal)(A18SecUserId), 10, 0));
         InitializeNonKey2485( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2486( )
      {
         A151ProveedoresTipoId = 0;
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         A282ProveedorNombre = "";
         A279ProveedoresTipoDescripcion = "";
         A430ProveedorTelefono = "";
         n430ProveedorTelefono = false;
         A433ProveedorEmail = "";
         n433ProveedorEmail = false;
         A596AgrProveedorComent = "";
         n596AgrProveedorComent = false;
         A594AgrProveedorEstado = "";
         n594AgrProveedorEstado = false;
         Z594AgrProveedorEstado = "";
      }

      protected void InitAll2486( )
      {
         A133ProveedorID = 0;
         InitializeNonKey2486( ) ;
      }

      protected void StandaloneModalInsert2486( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932084782", true, true, false);
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
         context.AddJavascriptSource("listaagruser.js", "?2026932084782", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties86( )
      {
         edtProveedorID_Enabled = defedtProveedorID_Enabled;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void StartGridControl43( )
      {
         Gridlevel_proveedorContainer.AddObjectProperty("GridName", "Gridlevel_proveedor");
         Gridlevel_proveedorContainer.AddObjectProperty("Header", subGridlevel_proveedor_Header);
         Gridlevel_proveedorContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_proveedorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_proveedorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A279ProveedoresTipoDescripcion));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A430ProveedorTelefono)));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A433ProveedorEmail));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A596AgrProveedorComent));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrProveedorComent_Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_proveedorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A594AgrProveedorEstado)));
         Gridlevel_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrProveedorEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_proveedorContainer.AddColumnProperties(Gridlevel_proveedorColumn);
         Gridlevel_proveedorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Selectedindex), 4, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Allowselection), 1, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Allowhovering), 1, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_proveedorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_proveedor_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         dynListaid_Internalname = "LISTAID";
         edtSecUserId_Internalname = "SECUSERID";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         cmbListaAgrUserEstado_Internalname = "LISTAAGRUSERESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedoresTipoDescripcion_Internalname = "PROVEEDORESTIPODESCRIPCION";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO";
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL";
         edtAgrProveedorComent_Internalname = "AGRPROVEEDORCOMENT";
         cmbAgrProveedorEstado_Internalname = "AGRPROVEEDORESTADO";
         divTableleaflevel_proveedor_Internalname = "TABLELEAFLEVEL_PROVEEDOR";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_18_Internalname = "PROMPT_18";
         imgprompt_133_Internalname = "PROMPT_133";
         subGridlevel_proveedor_Internalname = "GRIDLEVEL_PROVEEDOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_proveedor_Allowcollapsing = 0;
         subGridlevel_proveedor_Allowselection = 0;
         subGridlevel_proveedor_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Agrupar Comercios", "");
         cmbAgrProveedorEstado_Jsonclick = "";
         edtAgrProveedorComent_Jsonclick = "";
         edtProveedorEmail_Jsonclick = "";
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedoresTipoDescripcion_Jsonclick = "";
         imgprompt_133_Visible = 1;
         imgprompt_133_Link = "";
         imgprompt_18_Visible = 1;
         edtProveedorID_Jsonclick = "";
         subGridlevel_proveedor_Class = "WorkWith";
         subGridlevel_proveedor_Backcolorstyle = 0;
         cmbAgrProveedorEstado.Enabled = 1;
         edtAgrProveedorComent_Enabled = 1;
         edtProveedorEmail_Enabled = 0;
         edtProveedorTelefono_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedoresTipoDescripcion_Enabled = 0;
         edtProveedorID_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbListaAgrUserEstado_Jsonclick = "";
         cmbListaAgrUserEstado.Enabled = 1;
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Enabled = 0;
         imgprompt_18_Visible = 1;
         imgprompt_18_Link = "";
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
         dynListaid_Jsonclick = "";
         dynListaid.Enabled = 1;
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

      protected void GXDLALISTAID2485( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALISTAID_data2485( ) ;
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

      protected void GXALISTAID_html2485( )
      {
         long gxdynajaxvalue;
         GXDLALISTAID_data2485( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynListaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynListaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLALISTAID_data2485( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T002431 */
         pr_default.execute(29);
         while ( (pr_default.getStatus(29) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T002431_A590Listaid[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T002431_A592ListaNombre[0]));
            pr_default.readNext(29);
         }
         pr_default.close(29);
      }

      protected void gxnrGridlevel_proveedor_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4386( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2486( ) ;
            standaloneModal2486( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2486( ) ;
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_4386( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_proveedorContainer)) ;
         /* End function gxnrGridlevel_proveedor_newrow */
      }

      protected void init_web_controls( )
      {
         dynListaid.Name = "LISTAID";
         dynListaid.WebTags = "";
         cmbListaAgrUserEstado.Name = "LISTAAGRUSERESTADO";
         cmbListaAgrUserEstado.WebTags = "";
         cmbListaAgrUserEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbListaAgrUserEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbListaAgrUserEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbListaAgrUserEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbListaAgrUserEstado.ItemCount > 0 )
         {
            A599ListaAgrUserEstado = cmbListaAgrUserEstado.getValidValue(A599ListaAgrUserEstado);
            AssignAttri("", false, "A599ListaAgrUserEstado", A599ListaAgrUserEstado);
         }
         GXCCtl = "AGRPROVEEDORESTADO_" + sGXsfl_43_idx;
         cmbAgrProveedorEstado.Name = GXCCtl;
         cmbAgrProveedorEstado.WebTags = "";
         cmbAgrProveedorEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
         cmbAgrProveedorEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
         cmbAgrProveedorEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
         if ( cmbAgrProveedorEstado.ItemCount > 0 )
         {
            A594AgrProveedorEstado = cmbAgrProveedorEstado.getValidValue(A594AgrProveedorEstado);
            n594AgrProveedorEstado = false;
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

      public void Valid_Listaid( )
      {
         A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T002432 */
         pr_default.execute(30, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = dynListaid_Internalname;
         }
         pr_default.close(30);
         dynload_actions( ) ;
         if ( dynListaid.ItemCount > 0 )
         {
            A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0));
         }
         /*  Sending validation outputs */
      }

      public void Valid_Secuserid( )
      {
         A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T002433 */
         pr_default.execute(31, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
         }
         A587SecUserFullName = T002433_A587SecUserFullName[0];
         pr_default.close(31);
         dynload_actions( ) ;
         if ( dynListaid.ItemCount > 0 )
         {
            A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A587SecUserFullName", A587SecUserFullName);
      }

      public void Valid_Proveedorid( )
      {
         A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n430ProveedorTelefono = false;
         n433ProveedorEmail = false;
         /* Using cursor T002428 */
         pr_default.execute(26, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
         }
         A151ProveedoresTipoId = T002428_A151ProveedoresTipoId[0];
         A282ProveedorNombre = T002428_A282ProveedorNombre[0];
         A430ProveedorTelefono = T002428_A430ProveedorTelefono[0];
         n430ProveedorTelefono = T002428_n430ProveedorTelefono[0];
         A433ProveedorEmail = T002428_A433ProveedorEmail[0];
         n433ProveedorEmail = T002428_n433ProveedorEmail[0];
         pr_default.close(26);
         /* Using cursor T002429 */
         pr_default.execute(27, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A279ProveedoresTipoDescripcion = T002429_A279ProveedoresTipoDescripcion[0];
         pr_default.close(27);
         dynload_actions( ) ;
         if ( dynListaid.ItemCount > 0 )
         {
            A590Listaid = (long)(Math.Round(NumberUtil.Val( dynListaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynListaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A590Listaid), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, ".", "")));
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A430ProveedorTelefono", StringUtil.RTrim( A430ProveedorTelefono));
         AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
         AssignAttri("", false, "A279ProveedoresTipoDescripcion", A279ProveedoresTipoDescripcion);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV23Listaid',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV24SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV23Listaid',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV24SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12242',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_LISTAID",",oparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_SECUSERID","{handler:'Valid_Secuserid',iparms:[{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A587SecUserFullName',fld:'SECUSERFULLNAME',pic:'',type:'svchar'},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_SECUSERID",",oparms:[{av:'A587SecUserFullName',fld:'SECUSERFULLNAME',pic:'',type:'svchar'},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_LISTAAGRUSERESTADO","{handler:'Valid_Listaagruserestado',iparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_LISTAAGRUSERESTADO",",oparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A430ProveedorTelefono',fld:'PROVEEDORTELEFONO',pic:'',type:'char'},{av:'A433ProveedorEmail',fld:'PROVEEDOREMAIL',pic:'',type:'svchar'},{av:'A279ProveedoresTipoDescripcion',fld:'PROVEEDORESTIPODESCRIPCION',pic:'',type:'vchar'},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A430ProveedorTelefono',fld:'PROVEEDORTELEFONO',pic:'',type:'char'},{av:'A433ProveedorEmail',fld:'PROVEEDOREMAIL',pic:'',type:'svchar'},{av:'A279ProveedoresTipoDescripcion',fld:'PROVEEDORESTIPODESCRIPCION',pic:'',type:'vchar'},{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_AGRPROVEEDORESTADO","{handler:'Valid_Agrproveedorestado',iparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_AGRPROVEEDORESTADO",",oparms:[{av:'dynListaid'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
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
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(5);
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z599ListaAgrUserEstado = "";
         Z594AgrProveedorEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A599ListaAgrUserEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_18_gximage = "";
         sImgUrl = "";
         A587SecUserFullName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_proveedorContainer = new GXWebGrid( context);
         sMode86 = "";
         sStyleString = "";
         AV25Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode85 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A279ProveedoresTipoDescripcion = "";
         A282ProveedorNombre = "";
         A430ProveedorTelefono = "";
         A433ProveedorEmail = "";
         A596AgrProveedorComent = "";
         A594AgrProveedorEstado = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         Z587SecUserFullName = "";
         T00249_A587SecUserFullName = new string[] {""} ;
         T002410_A587SecUserFullName = new string[] {""} ;
         T002410_A599ListaAgrUserEstado = new string[] {""} ;
         T002410_A590Listaid = new long[1] ;
         T002410_A18SecUserId = new long[1] ;
         T00248_A590Listaid = new long[1] ;
         T002411_A590Listaid = new long[1] ;
         T002412_A587SecUserFullName = new string[] {""} ;
         T002413_A590Listaid = new long[1] ;
         T002413_A18SecUserId = new long[1] ;
         T00247_A599ListaAgrUserEstado = new string[] {""} ;
         T00247_A590Listaid = new long[1] ;
         T00247_A18SecUserId = new long[1] ;
         T002414_A590Listaid = new long[1] ;
         T002414_A18SecUserId = new long[1] ;
         T002415_A590Listaid = new long[1] ;
         T002415_A18SecUserId = new long[1] ;
         T00246_A599ListaAgrUserEstado = new string[] {""} ;
         T00246_A590Listaid = new long[1] ;
         T00246_A18SecUserId = new long[1] ;
         T002419_A587SecUserFullName = new string[] {""} ;
         T002420_A590Listaid = new long[1] ;
         T002420_A18SecUserId = new long[1] ;
         Z596AgrProveedorComent = "";
         Z282ProveedorNombre = "";
         Z430ProveedorTelefono = "";
         Z433ProveedorEmail = "";
         Z279ProveedoresTipoDescripcion = "";
         T002421_A151ProveedoresTipoId = new long[1] ;
         T002421_A590Listaid = new long[1] ;
         T002421_A18SecUserId = new long[1] ;
         T002421_A282ProveedorNombre = new string[] {""} ;
         T002421_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002421_A430ProveedorTelefono = new string[] {""} ;
         T002421_n430ProveedorTelefono = new bool[] {false} ;
         T002421_A433ProveedorEmail = new string[] {""} ;
         T002421_n433ProveedorEmail = new bool[] {false} ;
         T002421_A596AgrProveedorComent = new string[] {""} ;
         T002421_n596AgrProveedorComent = new bool[] {false} ;
         T002421_A594AgrProveedorEstado = new string[] {""} ;
         T002421_n594AgrProveedorEstado = new bool[] {false} ;
         T002421_A133ProveedorID = new long[1] ;
         T00244_A151ProveedoresTipoId = new long[1] ;
         T00244_A282ProveedorNombre = new string[] {""} ;
         T00244_A430ProveedorTelefono = new string[] {""} ;
         T00244_n430ProveedorTelefono = new bool[] {false} ;
         T00244_A433ProveedorEmail = new string[] {""} ;
         T00244_n433ProveedorEmail = new bool[] {false} ;
         T00245_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002422_A151ProveedoresTipoId = new long[1] ;
         T002422_A282ProveedorNombre = new string[] {""} ;
         T002422_A430ProveedorTelefono = new string[] {""} ;
         T002422_n430ProveedorTelefono = new bool[] {false} ;
         T002422_A433ProveedorEmail = new string[] {""} ;
         T002422_n433ProveedorEmail = new bool[] {false} ;
         T002423_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002424_A590Listaid = new long[1] ;
         T002424_A18SecUserId = new long[1] ;
         T002424_A133ProveedorID = new long[1] ;
         T00243_A590Listaid = new long[1] ;
         T00243_A18SecUserId = new long[1] ;
         T00243_A596AgrProveedorComent = new string[] {""} ;
         T00243_n596AgrProveedorComent = new bool[] {false} ;
         T00243_A594AgrProveedorEstado = new string[] {""} ;
         T00243_n594AgrProveedorEstado = new bool[] {false} ;
         T00243_A133ProveedorID = new long[1] ;
         T00242_A590Listaid = new long[1] ;
         T00242_A18SecUserId = new long[1] ;
         T00242_A596AgrProveedorComent = new string[] {""} ;
         T00242_n596AgrProveedorComent = new bool[] {false} ;
         T00242_A594AgrProveedorEstado = new string[] {""} ;
         T00242_n594AgrProveedorEstado = new bool[] {false} ;
         T00242_A133ProveedorID = new long[1] ;
         T002428_A151ProveedoresTipoId = new long[1] ;
         T002428_A282ProveedorNombre = new string[] {""} ;
         T002428_A430ProveedorTelefono = new string[] {""} ;
         T002428_n430ProveedorTelefono = new bool[] {false} ;
         T002428_A433ProveedorEmail = new string[] {""} ;
         T002428_n433ProveedorEmail = new bool[] {false} ;
         T002429_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002430_A590Listaid = new long[1] ;
         T002430_A18SecUserId = new long[1] ;
         T002430_A133ProveedorID = new long[1] ;
         Gridlevel_proveedorRow = new GXWebRow();
         subGridlevel_proveedor_Linesclass = "";
         ROClassString = "";
         imgprompt_133_gximage = "";
         gxphoneLink = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_proveedorColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T002431_A590Listaid = new long[1] ;
         T002431_A592ListaNombre = new string[] {""} ;
         T002431_A591ListaTipo = new string[] {""} ;
         T002432_A590Listaid = new long[1] ;
         T002433_A587SecUserFullName = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.listaagruser__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listaagruser__default(),
            new Object[][] {
                new Object[] {
               T00242_A590Listaid, T00242_A18SecUserId, T00242_A596AgrProveedorComent, T00242_n596AgrProveedorComent, T00242_A594AgrProveedorEstado, T00242_n594AgrProveedorEstado, T00242_A133ProveedorID
               }
               , new Object[] {
               T00243_A590Listaid, T00243_A18SecUserId, T00243_A596AgrProveedorComent, T00243_n596AgrProveedorComent, T00243_A594AgrProveedorEstado, T00243_n594AgrProveedorEstado, T00243_A133ProveedorID
               }
               , new Object[] {
               T00244_A151ProveedoresTipoId, T00244_A282ProveedorNombre, T00244_A430ProveedorTelefono, T00244_n430ProveedorTelefono, T00244_A433ProveedorEmail, T00244_n433ProveedorEmail
               }
               , new Object[] {
               T00245_A279ProveedoresTipoDescripcion
               }
               , new Object[] {
               T00246_A599ListaAgrUserEstado, T00246_A590Listaid, T00246_A18SecUserId
               }
               , new Object[] {
               T00247_A599ListaAgrUserEstado, T00247_A590Listaid, T00247_A18SecUserId
               }
               , new Object[] {
               T00248_A590Listaid
               }
               , new Object[] {
               T00249_A587SecUserFullName
               }
               , new Object[] {
               T002410_A587SecUserFullName, T002410_A599ListaAgrUserEstado, T002410_A590Listaid, T002410_A18SecUserId
               }
               , new Object[] {
               T002411_A590Listaid
               }
               , new Object[] {
               T002412_A587SecUserFullName
               }
               , new Object[] {
               T002413_A590Listaid, T002413_A18SecUserId
               }
               , new Object[] {
               T002414_A590Listaid, T002414_A18SecUserId
               }
               , new Object[] {
               T002415_A590Listaid, T002415_A18SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002419_A587SecUserFullName
               }
               , new Object[] {
               T002420_A590Listaid, T002420_A18SecUserId
               }
               , new Object[] {
               T002421_A151ProveedoresTipoId, T002421_A590Listaid, T002421_A18SecUserId, T002421_A282ProveedorNombre, T002421_A279ProveedoresTipoDescripcion, T002421_A430ProveedorTelefono, T002421_n430ProveedorTelefono, T002421_A433ProveedorEmail, T002421_n433ProveedorEmail, T002421_A596AgrProveedorComent,
               T002421_n596AgrProveedorComent, T002421_A594AgrProveedorEstado, T002421_n594AgrProveedorEstado, T002421_A133ProveedorID
               }
               , new Object[] {
               T002422_A151ProveedoresTipoId, T002422_A282ProveedorNombre, T002422_A430ProveedorTelefono, T002422_n430ProveedorTelefono, T002422_A433ProveedorEmail, T002422_n433ProveedorEmail
               }
               , new Object[] {
               T002423_A279ProveedoresTipoDescripcion
               }
               , new Object[] {
               T002424_A590Listaid, T002424_A18SecUserId, T002424_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002428_A151ProveedoresTipoId, T002428_A282ProveedorNombre, T002428_A430ProveedorTelefono, T002428_n430ProveedorTelefono, T002428_A433ProveedorEmail, T002428_n433ProveedorEmail
               }
               , new Object[] {
               T002429_A279ProveedoresTipoDescripcion
               }
               , new Object[] {
               T002430_A590Listaid, T002430_A18SecUserId, T002430_A133ProveedorID
               }
               , new Object[] {
               T002431_A590Listaid, T002431_A592ListaNombre, T002431_A591ListaTipo
               }
               , new Object[] {
               T002432_A590Listaid
               }
               , new Object[] {
               T002433_A587SecUserFullName
               }
            }
         );
         AV25Pgmname = "ListaAgrUser";
      }

      private short nIsMod_86 ;
      private short nRcdDeleted_86 ;
      private short nRcdExists_86 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount86 ;
      private short RcdFound86 ;
      private short nBlankRcdUsr86 ;
      private short RcdFound85 ;
      private short Gx_BScreen ;
      private short nIsDirty_86 ;
      private short subGridlevel_proveedor_Backcolorstyle ;
      private short subGridlevel_proveedor_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_proveedor_Allowselection ;
      private short subGridlevel_proveedor_Allowhovering ;
      private short subGridlevel_proveedor_Allowcollapsing ;
      private short subGridlevel_proveedor_Collapsed ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int trnEnded ;
      private int edtSecUserId_Enabled ;
      private int imgprompt_18_Visible ;
      private int edtSecUserFullName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedoresTipoDescripcion_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int edtAgrProveedorComent_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_proveedor_Backcolor ;
      private int subGridlevel_proveedor_Allbackcolor ;
      private int imgprompt_133_Visible ;
      private int defedtProveedorID_Enabled ;
      private int idxLst ;
      private int subGridlevel_proveedor_Selectedindex ;
      private int subGridlevel_proveedor_Selectioncolor ;
      private int subGridlevel_proveedor_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV23Listaid ;
      private long wcpOAV24SecUserId ;
      private long Z590Listaid ;
      private long Z18SecUserId ;
      private long Z133ProveedorID ;
      private long A590Listaid ;
      private long A18SecUserId ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long AV23Listaid ;
      private long AV24SecUserId ;
      private long GRIDLEVEL_PROVEEDOR_nFirstRecordOnPage ;
      private long Z151ProveedoresTipoId ;
      private string sPrefix ;
      private string sGXsfl_43_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z599ListaAgrUserEstado ;
      private string Z594AgrProveedorEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynListaid_Internalname ;
      private string A599ListaAgrUserEstado ;
      private string cmbListaAgrUserEstado_Internalname ;
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
      private string dynListaid_Jsonclick ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserId_Jsonclick ;
      private string imgprompt_18_gximage ;
      private string sImgUrl ;
      private string imgprompt_18_Internalname ;
      private string imgprompt_18_Link ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserFullName_Jsonclick ;
      private string cmbListaAgrUserEstado_Jsonclick ;
      private string divTableleaflevel_proveedor_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode86 ;
      private string edtProveedorID_Internalname ;
      private string edtProveedoresTipoDescripcion_Internalname ;
      private string edtProveedorNombre_Internalname ;
      private string edtProveedorTelefono_Internalname ;
      private string edtProveedorEmail_Internalname ;
      private string edtAgrProveedorComent_Internalname ;
      private string cmbAgrProveedorEstado_Internalname ;
      private string sStyleString ;
      private string subGridlevel_proveedor_Internalname ;
      private string AV25Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode85 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A282ProveedorNombre ;
      private string A430ProveedorTelefono ;
      private string A594AgrProveedorEstado ;
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string Z430ProveedorTelefono ;
      private string imgprompt_133_Internalname ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGridlevel_proveedor_Class ;
      private string subGridlevel_proveedor_Linesclass ;
      private string imgprompt_133_Link ;
      private string ROClassString ;
      private string edtProveedorID_Jsonclick ;
      private string imgprompt_133_gximage ;
      private string edtProveedoresTipoDescripcion_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string gxphoneLink ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorEmail_Jsonclick ;
      private string edtAgrProveedorComent_Jsonclick ;
      private string cmbAgrProveedorEstado_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_proveedor_Header ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV7IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n430ProveedorTelefono ;
      private bool n433ProveedorEmail ;
      private bool n596AgrProveedorComent ;
      private bool n594AgrProveedorEstado ;
      private bool gxdyncontrolsrefreshing ;
      private string A279ProveedoresTipoDescripcion ;
      private string A596AgrProveedorComent ;
      private string Z596AgrProveedorComent ;
      private string Z279ProveedoresTipoDescripcion ;
      private string A587SecUserFullName ;
      private string A433ProveedorEmail ;
      private string Z587SecUserFullName ;
      private string Z433ProveedorEmail ;
      private IGxSession AV9WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_proveedorContainer ;
      private GXWebRow Gridlevel_proveedorRow ;
      private GXWebColumn Gridlevel_proveedorColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynListaid ;
      private GXCombobox cmbListaAgrUserEstado ;
      private GXCombobox cmbAgrProveedorEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T00249_A587SecUserFullName ;
      private string[] T002410_A587SecUserFullName ;
      private string[] T002410_A599ListaAgrUserEstado ;
      private long[] T002410_A590Listaid ;
      private long[] T002410_A18SecUserId ;
      private long[] T00248_A590Listaid ;
      private long[] T002411_A590Listaid ;
      private string[] T002412_A587SecUserFullName ;
      private long[] T002413_A590Listaid ;
      private long[] T002413_A18SecUserId ;
      private string[] T00247_A599ListaAgrUserEstado ;
      private long[] T00247_A590Listaid ;
      private long[] T00247_A18SecUserId ;
      private long[] T002414_A590Listaid ;
      private long[] T002414_A18SecUserId ;
      private long[] T002415_A590Listaid ;
      private long[] T002415_A18SecUserId ;
      private string[] T00246_A599ListaAgrUserEstado ;
      private long[] T00246_A590Listaid ;
      private long[] T00246_A18SecUserId ;
      private string[] T002419_A587SecUserFullName ;
      private long[] T002420_A590Listaid ;
      private long[] T002420_A18SecUserId ;
      private long[] T002421_A151ProveedoresTipoId ;
      private long[] T002421_A590Listaid ;
      private long[] T002421_A18SecUserId ;
      private string[] T002421_A282ProveedorNombre ;
      private string[] T002421_A279ProveedoresTipoDescripcion ;
      private string[] T002421_A430ProveedorTelefono ;
      private bool[] T002421_n430ProveedorTelefono ;
      private string[] T002421_A433ProveedorEmail ;
      private bool[] T002421_n433ProveedorEmail ;
      private string[] T002421_A596AgrProveedorComent ;
      private bool[] T002421_n596AgrProveedorComent ;
      private string[] T002421_A594AgrProveedorEstado ;
      private bool[] T002421_n594AgrProveedorEstado ;
      private long[] T002421_A133ProveedorID ;
      private long[] T00244_A151ProveedoresTipoId ;
      private string[] T00244_A282ProveedorNombre ;
      private string[] T00244_A430ProveedorTelefono ;
      private bool[] T00244_n430ProveedorTelefono ;
      private string[] T00244_A433ProveedorEmail ;
      private bool[] T00244_n433ProveedorEmail ;
      private string[] T00245_A279ProveedoresTipoDescripcion ;
      private long[] T002422_A151ProveedoresTipoId ;
      private string[] T002422_A282ProveedorNombre ;
      private string[] T002422_A430ProveedorTelefono ;
      private bool[] T002422_n430ProveedorTelefono ;
      private string[] T002422_A433ProveedorEmail ;
      private bool[] T002422_n433ProveedorEmail ;
      private string[] T002423_A279ProveedoresTipoDescripcion ;
      private long[] T002424_A590Listaid ;
      private long[] T002424_A18SecUserId ;
      private long[] T002424_A133ProveedorID ;
      private long[] T00243_A590Listaid ;
      private long[] T00243_A18SecUserId ;
      private string[] T00243_A596AgrProveedorComent ;
      private bool[] T00243_n596AgrProveedorComent ;
      private string[] T00243_A594AgrProveedorEstado ;
      private bool[] T00243_n594AgrProveedorEstado ;
      private long[] T00243_A133ProveedorID ;
      private long[] T00242_A590Listaid ;
      private long[] T00242_A18SecUserId ;
      private string[] T00242_A596AgrProveedorComent ;
      private bool[] T00242_n596AgrProveedorComent ;
      private string[] T00242_A594AgrProveedorEstado ;
      private bool[] T00242_n594AgrProveedorEstado ;
      private long[] T00242_A133ProveedorID ;
      private long[] T002428_A151ProveedoresTipoId ;
      private string[] T002428_A282ProveedorNombre ;
      private string[] T002428_A430ProveedorTelefono ;
      private bool[] T002428_n430ProveedorTelefono ;
      private string[] T002428_A433ProveedorEmail ;
      private bool[] T002428_n433ProveedorEmail ;
      private string[] T002429_A279ProveedoresTipoDescripcion ;
      private long[] T002430_A590Listaid ;
      private long[] T002430_A18SecUserId ;
      private long[] T002430_A133ProveedorID ;
      private long[] T002431_A590Listaid ;
      private string[] T002431_A592ListaNombre ;
      private string[] T002431_A591ListaTipo ;
      private long[] T002432_A590Listaid ;
      private string[] T002433_A587SecUserFullName ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class listaagruser__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class listaagruser__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00242;
        prmT00242 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT00243;
        prmT00243 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT00244;
        prmT00244 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT00245;
        prmT00245 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT00246;
        prmT00246 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00247;
        prmT00247 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT00248;
        prmT00248 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT00249;
        prmT00249 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002410;
        prmT002410 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002411;
        prmT002411 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002412;
        prmT002412 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002413;
        prmT002413 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002414;
        prmT002414 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002415;
        prmT002415 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002416;
        prmT002416 = new Object[] {
        new ParDef("@ListaAgrUserEstado",GXType.NChar,3,0) ,
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002417;
        prmT002417 = new Object[] {
        new ParDef("@ListaAgrUserEstado",GXType.NChar,3,0) ,
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002418;
        prmT002418 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002419;
        prmT002419 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002420;
        prmT002420 = new Object[] {
        };
        Object[] prmT002421;
        prmT002421 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002422;
        prmT002422 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002423;
        prmT002423 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT002424;
        prmT002424 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002425;
        prmT002425 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@AgrProveedorComent",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@AgrProveedorEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002426;
        prmT002426 = new Object[] {
        new ParDef("@AgrProveedorComent",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@AgrProveedorEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002427;
        prmT002427 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002428;
        prmT002428 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002429;
        prmT002429 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT002430;
        prmT002430 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmT002431;
        prmT002431 = new Object[] {
        };
        Object[] prmT002432;
        prmT002432 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002433;
        prmT002433 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00242", "SELECT [Listaid], [SecUserId], [AgrProveedorComent], [AgrProveedorEstado], [ProveedorID] FROM [ListaAgrUserProveedor] WITH (UPDLOCK) WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId AND [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00242,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00243", "SELECT [Listaid], [SecUserId], [AgrProveedorComent], [AgrProveedorEstado], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId AND [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00243,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00244", "SELECT [ProveedoresTipoId], [ProveedorNombre], [ProveedorTelefono], [ProveedorEmail] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00244,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00245", "SELECT [ProveedoresTipoDescripcion] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00245,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00246", "SELECT [ListaAgrUserEstado], [Listaid], [SecUserId] FROM [ListaAgrUser] WITH (UPDLOCK) WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00246,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00247", "SELECT [ListaAgrUserEstado], [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00247,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00248", "SELECT [Listaid] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT00248,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00249", "SELECT [SecUserFullName] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00249,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002410", "SELECT T2.[SecUserFullName], TM1.[ListaAgrUserEstado], TM1.[Listaid], TM1.[SecUserId] FROM ([ListaAgrUser] TM1 INNER JOIN [SecUser] T2 ON T2.[SecUserId] = TM1.[SecUserId]) WHERE TM1.[Listaid] = @Listaid and TM1.[SecUserId] = @SecUserId ORDER BY TM1.[Listaid], TM1.[SecUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002410,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002411", "SELECT [Listaid] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002412", "SELECT [SecUserFullName] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002413", "SELECT [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002414", "SELECT TOP 1 [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE ( [Listaid] > @Listaid or [Listaid] = @Listaid and [SecUserId] > @SecUserId) ORDER BY [Listaid], [SecUserId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002414,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002415", "SELECT TOP 1 [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE ( [Listaid] < @Listaid or [Listaid] = @Listaid and [SecUserId] < @SecUserId) ORDER BY [Listaid] DESC, [SecUserId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002415,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002416", "INSERT INTO [ListaAgrUser]([ListaAgrUserEstado], [Listaid], [SecUserId]) VALUES(@ListaAgrUserEstado, @Listaid, @SecUserId)", GxErrorMask.GX_NOMASK,prmT002416)
           ,new CursorDef("T002417", "UPDATE [ListaAgrUser] SET [ListaAgrUserEstado]=@ListaAgrUserEstado  WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK,prmT002417)
           ,new CursorDef("T002418", "DELETE FROM [ListaAgrUser]  WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK,prmT002418)
           ,new CursorDef("T002419", "SELECT [SecUserFullName] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002420", "SELECT [Listaid], [SecUserId] FROM [ListaAgrUser] ORDER BY [Listaid], [SecUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002420,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002421", "SELECT T2.[ProveedoresTipoId], T1.[Listaid], T1.[SecUserId], T2.[ProveedorNombre], T3.[ProveedoresTipoDescripcion], T2.[ProveedorTelefono], T2.[ProveedorEmail], T1.[AgrProveedorComent], T1.[AgrProveedorEstado], T1.[ProveedorID] FROM (([ListaAgrUserProveedor] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [ProveedoresTipo] T3 ON T3.[ProveedoresTipoId] = T2.[ProveedoresTipoId]) WHERE T1.[Listaid] = @Listaid and T1.[SecUserId] = @SecUserId and T1.[ProveedorID] = @ProveedorID ORDER BY T1.[Listaid], T1.[SecUserId], T1.[ProveedorID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002421,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002422", "SELECT [ProveedoresTipoId], [ProveedorNombre], [ProveedorTelefono], [ProveedorEmail] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002422,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002423", "SELECT [ProveedoresTipoDescripcion] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002423,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002424", "SELECT [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId AND [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002424,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002425", "INSERT INTO [ListaAgrUserProveedor]([Listaid], [SecUserId], [AgrProveedorComent], [AgrProveedorEstado], [ProveedorID]) VALUES(@Listaid, @SecUserId, @AgrProveedorComent, @AgrProveedorEstado, @ProveedorID)", GxErrorMask.GX_NOMASK,prmT002425)
           ,new CursorDef("T002426", "UPDATE [ListaAgrUserProveedor] SET [AgrProveedorComent]=@AgrProveedorComent, [AgrProveedorEstado]=@AgrProveedorEstado  WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId AND [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT002426)
           ,new CursorDef("T002427", "DELETE FROM [ListaAgrUserProveedor]  WHERE [Listaid] = @Listaid AND [SecUserId] = @SecUserId AND [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT002427)
           ,new CursorDef("T002428", "SELECT [ProveedoresTipoId], [ProveedorNombre], [ProveedorTelefono], [ProveedorEmail] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002428,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002429", "SELECT [ProveedoresTipoDescripcion] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002429,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002430", "SELECT [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [Listaid] = @Listaid and [SecUserId] = @SecUserId ORDER BY [Listaid], [SecUserId], [ProveedorID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002430,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002431", "SELECT [Listaid], [ListaNombre], [ListaTipo] FROM [Lista] WHERE [ListaTipo] = 'ADM' ORDER BY [ListaNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002431,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002432", "SELECT [Listaid] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002432,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002433", "SELECT [SecUserFullName] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002433,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((long[]) buf[6])[0] = rslt.getLong(5);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((long[]) buf[6])[0] = rslt.getLong(5);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 3);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((long[]) buf[13])[0] = rslt.getLong(10);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}

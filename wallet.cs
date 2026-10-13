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
   public class wallet : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"WALLETTOTALCREDITO") == 0 )
         {
            A637WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASAWALLETTOTALCREDITO2992( A637WalletId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"WALLETTOTALDEBITO") == 0 )
         {
            A637WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX6ASAWALLETTOTALDEBITO2992( A637WalletId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"WALLETNOMBRE") == 0 )
         {
            A638WalletTipoEntidad = GetPar( "WalletTipoEntidad");
            AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
            A639WalletCodRefencia = GetPar( "WalletCodRefencia");
            AssignAttri("", false, "A639WalletCodRefencia", A639WalletCodRefencia);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAWALLETNOMBRE2992( A638WalletTipoEntidad, A639WalletCodRefencia) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"WALLETSOLICITUDESPENDIENTES") == 0 )
         {
            A639WalletCodRefencia = GetPar( "WalletCodRefencia");
            AssignAttri("", false, "A639WalletCodRefencia", A639WalletCodRefencia);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASAWALLETSOLICITUDESPENDIENTES2992( A639WalletCodRefencia) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A483TipoCuentaId = (long)(Math.Round(NumberUtil.Val( GetPar( "TipoCuentaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A483TipoCuentaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( GetPar( "MonedaId"), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A118MonedaId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_balances") == 0 )
         {
            gxnrGridlevel_balances_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wallet.aspx")), "wallet.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wallet.aspx")))) ;
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
                  AV7WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7WalletId", StringUtil.LTrimStr( (decimal)(AV7WalletId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Saldos y Cuentas", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipoCuentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_balances_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_balances_newrow( ) ;
         /* End function gxnrGridlevel_balances_newrow_invoke */
      }

      public wallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wallet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_WalletId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WalletId = aP1_WalletId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTipoCuentaConcepto = new GXCombobox();
         cmbWalletEstado = new GXCombobox();
         cmbWalletTipoEntidad = new GXCombobox();
         dynMonedaId = new GXCombobox();
         cmbWalletBalancesTipoMov = new GXCombobox();
         cmbWalletBalancesEstadoOPE = new GXCombobox();
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
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
            A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
            AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
            AssignProp("", false, cmbTipoCuentaConcepto_Internalname, "Values", cmbTipoCuentaConcepto.ToJavascriptSource(), true);
         }
         if ( cmbWalletEstado.ItemCount > 0 )
         {
            A665WalletEstado = cmbWalletEstado.getValidValue(A665WalletEstado);
            AssignAttri("", false, "A665WalletEstado", A665WalletEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWalletEstado.CurrentValue = StringUtil.RTrim( A665WalletEstado);
            AssignProp("", false, cmbWalletEstado_Internalname, "Values", cmbWalletEstado.ToJavascriptSource(), true);
         }
         if ( cmbWalletTipoEntidad.ItemCount > 0 )
         {
            A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
            AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWalletTipoEntidad.CurrentValue = StringUtil.RTrim( A638WalletTipoEntidad);
            AssignProp("", false, cmbWalletTipoEntidad_Internalname, "Values", cmbWalletTipoEntidad.ToJavascriptSource(), true);
         }
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
            AssignProp("", false, dynMonedaId_Internalname, "Values", dynMonedaId.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
         /* User Defined Control */
         ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
         ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
         ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
         ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "tabGeneral") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletId_Enabled!=0) ? context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoCuentaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoCuentaId_Internalname, context.GetMessage( "Clasificación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoCuentaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoCuentaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoCuentaId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Wallet.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_483_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_483_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_483_Internalname, sImgUrl, imgprompt_483_Link, "", "", context.GetTheme( ), imgprompt_483_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTipoCuentaConcepto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTipoCuentaConcepto_Internalname, context.GetMessage( "Tipo de Concepto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipoCuentaConcepto, cmbTipoCuentaConcepto_Internalname, StringUtil.RTrim( A636TipoCuentaConcepto), 1, cmbTipoCuentaConcepto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTipoCuentaConcepto.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_Wallet.htm");
         cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
         AssignProp("", false, cmbTipoCuentaConcepto_Internalname, "Values", (string)(cmbTipoCuentaConcepto.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWalletEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWalletEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWalletEstado, cmbWalletEstado_Internalname, StringUtil.RTrim( A665WalletEstado), 1, cmbWalletEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbWalletEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_Wallet.htm");
         cmbWalletEstado.CurrentValue = StringUtil.RTrim( A665WalletEstado);
         AssignProp("", false, cmbWalletEstado_Internalname, "Values", (string)(cmbWalletEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWalletTipoEntidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWalletTipoEntidad_Internalname, context.GetMessage( "Tipo Entidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWalletTipoEntidad, cmbWalletTipoEntidad_Internalname, StringUtil.RTrim( A638WalletTipoEntidad), 1, cmbWalletTipoEntidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbWalletTipoEntidad.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Wallet.htm");
         cmbWalletTipoEntidad.CurrentValue = StringUtil.RTrim( A638WalletTipoEntidad);
         AssignProp("", false, cmbWalletTipoEntidad_Internalname, "Values", (string)(cmbWalletTipoEntidad.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletCodRefencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletCodRefencia_Internalname, context.GetMessage( "Código de Refencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletCodRefencia_Internalname, StringUtil.RTrim( A639WalletCodRefencia), StringUtil.RTrim( context.localUtil.Format( A639WalletCodRefencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletCodRefencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletCodRefencia_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Wallet.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_639_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_639_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_639_Internalname, sImgUrl, imgprompt_639_Link, "", "", context.GetTheme( ), imgprompt_639_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletNombre_Internalname, StringUtil.RTrim( A715WalletNombre), StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoCuentaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoCuentaNombre_Internalname, context.GetMessage( "Nombre del Tipo de Cuenta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoCuentaNombre_Internalname, StringUtil.RTrim( A484TipoCuentaNombre), StringUtil.RTrim( context.localUtil.Format( A484TipoCuentaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoCuentaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoCuentaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "NombreLargo", "start", true, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynMonedaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynMonedaId_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynMonedaId, dynMonedaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0)), 1, dynMonedaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMonedaId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Wallet.htm");
         dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         AssignProp("", false, dynMonedaId_Internalname, "Values", (string)(dynMonedaId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletTotalDebito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletTotalDebito_Internalname, context.GetMessage( "Total Debito", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletTotalDebito_Internalname, StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletTotalDebito_Enabled!=0) ? context.localUtil.Format( A646WalletTotalDebito, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A646WalletTotalDebito, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletTotalDebito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletTotalDebito_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletTotalCredito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletTotalCredito_Internalname, context.GetMessage( "Total Credito", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletTotalCredito_Internalname, StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletTotalCredito_Enabled!=0) ? context.localUtil.Format( A647WalletTotalCredito, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A647WalletTotalCredito, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletTotalCredito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletTotalCredito_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletSaldo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletSaldo_Internalname, context.GetMessage( "SALDO CONSOLIDADO", ""), " AttributeFLLabel AttributeSizeLargeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletSaldo_Enabled!=0) ? context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletSaldo_Jsonclick, 0, "AttributeFL AttributeSizeLarge", "", "", "", "", 1, edtWalletSaldo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletSaldoAlDia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletSaldoAlDia_Internalname, context.GetMessage( "Saldo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletSaldoAlDia_Internalname, StringUtil.LTrim( StringUtil.NToC( A1008WalletSaldoAlDia, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletSaldoAlDia_Enabled!=0) ? context.localUtil.Format( A1008WalletSaldoAlDia, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A1008WalletSaldoAlDia, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletSaldoAlDia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletSaldoAlDia_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletSolicitudesPendientes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWalletSolicitudesPendientes_Internalname, context.GetMessage( "Saldo Pendiente", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWalletSolicitudesPendientes_Internalname, StringUtil.LTrim( StringUtil.NToC( A1007WalletSolicitudesPendientes, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletSolicitudesPendientes_Enabled!=0) ? context.localUtil.Format( A1007WalletSolicitudesPendientes, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A1007WalletSolicitudesPendientes, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletSolicitudesPendientes_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletSolicitudesPendientes_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_balances_title_Internalname, context.GetMessage( "Balances", ""), "", "", lblTablevel_balances_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Balances") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_balances_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_balances_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_balances( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet.htm");
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

      protected void gxdraw_Gridlevel_balances( )
      {
         /*  Grid Control  */
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount93 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_93 = 1;
               ScanStart2993( ) ;
               while ( RcdFound93 != 0 )
               {
                  init_level_properties93( ) ;
                  getByPrimaryKey2993( ) ;
                  AddRow2993( ) ;
                  ScanNext2993( ) ;
               }
               ScanEnd2993( ) ;
               nBlankRcdCount93 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2993( ) ;
            standaloneModal2993( ) ;
            sMode93 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow2993( ) ;
               edtWalletBalancesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWalletBalancesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtWalletBalancesFechaAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESFECHAALTA_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWalletBalancesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtWalletBalancesUsrAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESUSRALTA_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWalletBalancesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               cmbWalletBalancesTipoMov.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESTIPOMOV_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtWalletBalancesImporte_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESIMPORTE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWalletBalancesImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               cmbWalletBalancesEstadoOPE.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESESTADOOPE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0), !bGXsfl_88_Refreshing);
               if ( ( nRcdExists_93 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2993( ) ;
               }
               SendRow2993( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount93 = 5;
            nRcdExists_93 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2993( ) ;
               while ( RcdFound93 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8893( ) ;
                  init_level_properties93( ) ;
                  standaloneNotModal2993( ) ;
                  getByPrimaryKey2993( ) ;
                  standaloneModal2993( ) ;
                  AddRow2993( ) ;
                  ScanNext2993( ) ;
               }
               ScanEnd2993( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode93 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8893( ) ;
            InitAll2993( ) ;
            init_level_properties93( ) ;
            nRcdExists_93 = 0;
            nIsMod_93 = 0;
            nRcdDeleted_93 = 0;
            nBlankRcdCount93 = (short)(nBlankRcdUsr93+nBlankRcdCount93);
            fRowAdded = 0;
            while ( nBlankRcdCount93 > 0 )
            {
               standaloneNotModal2993( ) ;
               standaloneModal2993( ) ;
               AddRow2993( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
               }
               nBlankRcdCount93 = (short)(nBlankRcdCount93-1);
            }
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_balancesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_balances", Gridlevel_balancesContainer, subGridlevel_balances_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_balancesContainerData", Gridlevel_balancesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_balancesContainerData"+"V", Gridlevel_balancesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_balancesContainerData"+"V"+"\" value='"+Gridlevel_balancesContainer.GridValuesHidden()+"'/>") ;
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
         E11292 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z637WalletId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z638WalletTipoEntidad = cgiGet( "Z638WalletTipoEntidad");
               Z639WalletCodRefencia = cgiGet( "Z639WalletCodRefencia");
               Z665WalletEstado = cgiGet( "Z665WalletEstado");
               Z483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z483TipoCuentaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z118MonedaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n118MonedaId = ((0==A118MonedaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N483TipoCuentaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N118MonedaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n118MonedaId = ((0==A118MonedaId) ? true : false);
               AV7WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vWALLETID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPOCUENTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_TipoCuentaId", StringUtil.LTrimStr( (decimal)(AV13Insert_TipoCuentaId), 18, 0));
               AV14Insert_MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MONEDAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_MonedaId", StringUtil.LTrimStr( (decimal)(AV14Insert_MonedaId), 4, 0));
               A119MonedaISOSimbolo = cgiGet( "MONEDAISOSIMBOLO");
               AV18Pgmname = cgiGet( "vPGMNAME");
               A1009WalletBalancesObs = cgiGet( "WALLETBALANCESOBS");
               n1009WalletBalancesObs = false;
               n1009WalletBalancesObs = (String.IsNullOrEmpty(StringUtil.RTrim( A1009WalletBalancesObs)) ? true : false);
               A1010WalletBalancesConcepto = (short)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESCONCEPTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1010WalletBalancesConcepto = false;
               n1010WalletBalancesConcepto = ((0==A1010WalletBalancesConcepto) ? true : false);
               A1011WalletBalancesUrl = cgiGet( "WALLETBALANCESURL");
               n1011WalletBalancesUrl = false;
               n1011WalletBalancesUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1011WalletBalancesUrl)) ? true : false);
               A1012WalletBalanceLiquidacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCELIQUIDACION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1012WalletBalanceLiquidacion = false;
               n1012WalletBalanceLiquidacion = ((0==A1012WalletBalanceLiquidacion) ? true : false);
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               /* Read variables values. */
               A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPOCUENTAID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A483TipoCuentaId = 0;
                  AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
               }
               else
               {
                  A483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
               }
               cmbTipoCuentaConcepto.Name = cmbTipoCuentaConcepto_Internalname;
               cmbTipoCuentaConcepto.CurrentValue = cgiGet( cmbTipoCuentaConcepto_Internalname);
               A636TipoCuentaConcepto = cgiGet( cmbTipoCuentaConcepto_Internalname);
               AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
               cmbWalletEstado.Name = cmbWalletEstado_Internalname;
               cmbWalletEstado.CurrentValue = cgiGet( cmbWalletEstado_Internalname);
               A665WalletEstado = cgiGet( cmbWalletEstado_Internalname);
               AssignAttri("", false, "A665WalletEstado", A665WalletEstado);
               cmbWalletTipoEntidad.Name = cmbWalletTipoEntidad_Internalname;
               cmbWalletTipoEntidad.CurrentValue = cgiGet( cmbWalletTipoEntidad_Internalname);
               A638WalletTipoEntidad = cgiGet( cmbWalletTipoEntidad_Internalname);
               AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
               A639WalletCodRefencia = cgiGet( edtWalletCodRefencia_Internalname);
               AssignAttri("", false, "A639WalletCodRefencia", A639WalletCodRefencia);
               A715WalletNombre = cgiGet( edtWalletNombre_Internalname);
               AssignAttri("", false, "A715WalletNombre", A715WalletNombre);
               A484TipoCuentaNombre = cgiGet( edtTipoCuentaNombre_Internalname);
               AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
               dynMonedaId.Name = dynMonedaId_Internalname;
               dynMonedaId.CurrentValue = cgiGet( dynMonedaId_Internalname);
               A118MonedaId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynMonedaId_Internalname), "."), 18, MidpointRounding.ToEven));
               n118MonedaId = false;
               AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
               n118MonedaId = ((0==A118MonedaId) ? true : false);
               A646WalletTotalDebito = context.localUtil.CToN( cgiGet( edtWalletTotalDebito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
               A647WalletTotalCredito = context.localUtil.CToN( cgiGet( edtWalletTotalCredito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
               A648WalletSaldo = context.localUtil.CToN( cgiGet( edtWalletSaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
               A1008WalletSaldoAlDia = context.localUtil.CToN( cgiGet( edtWalletSaldoAlDia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
               A1007WalletSolicitudesPendientes = context.localUtil.CToN( cgiGet( edtWalletSolicitudesPendientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Wallet");
               A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
               forbiddenHiddens.Add("WalletId", context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TipoCuentaId", context.localUtil.Format( (decimal)(AV13Insert_TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_MonedaId", context.localUtil.Format( (decimal)(AV14Insert_MonedaId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A637WalletId != Z637WalletId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("wallet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A637WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
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
                     sMode92 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode92;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound92 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_290( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WALLETID");
                        AnyError = 1;
                        GX_FocusControl = edtWalletId_Internalname;
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
                           E11292 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12292 ();
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
            E12292 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2992( ) ;
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
            DisableAttributes2992( ) ;
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

      protected void CONFIRM_290( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2992( ) ;
            }
            else
            {
               CheckExtendedTable2992( ) ;
               CloseExtendedTableCursors2992( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode92 = Gx_mode;
            CONFIRM_2993( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode92;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2993( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow2993( ) ;
            if ( ( nRcdExists_93 != 0 ) || ( nIsMod_93 != 0 ) )
            {
               GetKey2993( ) ;
               if ( ( nRcdExists_93 == 0 ) && ( nRcdDeleted_93 == 0 ) )
               {
                  if ( RcdFound93 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2993( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2993( ) ;
                        CloseExtendedTableCursors2993( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound93 != 0 )
                  {
                     if ( nRcdDeleted_93 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2993( ) ;
                        Load2993( ) ;
                        BeforeValidate2993( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2993( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_93 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2993( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2993( ) ;
                              CloseExtendedTableCursors2993( ) ;
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
                     if ( nRcdDeleted_93 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtWalletBalancesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtWalletBalancesFechaAlta_Internalname, context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtWalletBalancesUsrAlta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbWalletBalancesTipoMov_Internalname, StringUtil.RTrim( A643WalletBalancesTipoMov)) ;
            ChangePostValue( edtWalletBalancesImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbWalletBalancesEstadoOPE_Internalname, StringUtil.RTrim( A645WalletBalancesEstadoOPE)) ;
            ChangePostValue( "ZT_"+"Z640WalletBalancesId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z641WalletBalancesFechaAlta_"+sGXsfl_88_idx, context.localUtil.TToC( Z641WalletBalancesFechaAlta, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z642WalletBalancesUsrAlta_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z643WalletBalancesTipoMov_"+sGXsfl_88_idx, StringUtil.RTrim( Z643WalletBalancesTipoMov)) ;
            ChangePostValue( "ZT_"+"Z644WalletBalancesImporte_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( Z644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1009WalletBalancesObs_"+sGXsfl_88_idx, Z1009WalletBalancesObs) ;
            ChangePostValue( "ZT_"+"Z1010WalletBalancesConcepto_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1010WalletBalancesConcepto), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1011WalletBalancesUrl_"+sGXsfl_88_idx, Z1011WalletBalancesUrl) ;
            ChangePostValue( "ZT_"+"Z645WalletBalancesEstadoOPE_"+sGXsfl_88_idx, StringUtil.RTrim( Z645WalletBalancesEstadoOPE)) ;
            ChangePostValue( "ZT_"+"Z1012WalletBalanceLiquidacion_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1012WalletBalanceLiquidacion), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_93_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_93), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_93_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_93), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_93_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_93), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_93 != 0 )
            {
               ChangePostValue( "WALLETBALANCESID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESFECHAALTA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESUSRALTA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESTIPOMOV_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESIMPORTE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESESTADOOPE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption290( )
      {
      }

      protected void E11292( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV18Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV18Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV19GXV1 = 1;
            AssignAttri("", false, "AV19GXV1", StringUtil.LTrimStr( (decimal)(AV19GXV1), 8, 0));
            while ( AV19GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV19GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "TipoCuentaId") == 0 )
               {
                  AV13Insert_TipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_TipoCuentaId", StringUtil.LTrimStr( (decimal)(AV13Insert_TipoCuentaId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "MonedaId") == 0 )
               {
                  AV14Insert_MonedaId = (short)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_MonedaId", StringUtil.LTrimStr( (decimal)(AV14Insert_MonedaId), 4, 0));
               }
               AV19GXV1 = (int)(AV19GXV1+1);
               AssignAttri("", false, "AV19GXV1", StringUtil.LTrimStr( (decimal)(AV19GXV1), 8, 0));
            }
         }
      }

      protected void E12292( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("walletww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2992( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z638WalletTipoEntidad = T00295_A638WalletTipoEntidad[0];
               Z639WalletCodRefencia = T00295_A639WalletCodRefencia[0];
               Z665WalletEstado = T00295_A665WalletEstado[0];
               Z483TipoCuentaId = T00295_A483TipoCuentaId[0];
               Z118MonedaId = T00295_A118MonedaId[0];
            }
            else
            {
               Z638WalletTipoEntidad = A638WalletTipoEntidad;
               Z639WalletCodRefencia = A639WalletCodRefencia;
               Z665WalletEstado = A665WalletEstado;
               Z483TipoCuentaId = A483TipoCuentaId;
               Z118MonedaId = A118MonedaId;
            }
         }
         if ( GX_JID == -29 )
         {
            Z637WalletId = A637WalletId;
            Z638WalletTipoEntidad = A638WalletTipoEntidad;
            Z639WalletCodRefencia = A639WalletCodRefencia;
            Z665WalletEstado = A665WalletEstado;
            Z483TipoCuentaId = A483TipoCuentaId;
            Z118MonedaId = A118MonedaId;
            Z636TipoCuentaConcepto = A636TipoCuentaConcepto;
            Z484TipoCuentaNombre = A484TipoCuentaNombre;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtWalletNombre_Enabled = 0;
         AssignProp("", false, edtWalletNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletNombre_Enabled), 5, 0), true);
         edtWalletTotalDebito_Enabled = 0;
         AssignProp("", false, edtWalletTotalDebito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalDebito_Enabled), 5, 0), true);
         edtWalletTotalCredito_Enabled = 0;
         AssignProp("", false, edtWalletTotalCredito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalCredito_Enabled), 5, 0), true);
         edtWalletSaldo_Enabled = 0;
         AssignProp("", false, edtWalletSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSaldo_Enabled), 5, 0), true);
         edtWalletId_Enabled = 0;
         AssignProp("", false, edtWalletId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletId_Enabled), 5, 0), true);
         imgprompt_483_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"tipocuentaprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOCUENTAID"+"'), id:'"+"TIPOCUENTAID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"TIPOCUENTANOMBRE"+"'), id:'"+"TIPOCUENTANOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_639_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"WALLETCODREFENCIA"+"'), id:'"+"WALLETCODREFENCIA"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vFULLNAME"+"'), id:'"+"vFULLNAME"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtWalletNombre_Enabled = 0;
         AssignProp("", false, edtWalletNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletNombre_Enabled), 5, 0), true);
         edtWalletTotalDebito_Enabled = 0;
         AssignProp("", false, edtWalletTotalDebito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalDebito_Enabled), 5, 0), true);
         edtWalletTotalCredito_Enabled = 0;
         AssignProp("", false, edtWalletTotalCredito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalCredito_Enabled), 5, 0), true);
         edtWalletSaldo_Enabled = 0;
         AssignProp("", false, edtWalletSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSaldo_Enabled), 5, 0), true);
         edtWalletId_Enabled = 0;
         AssignProp("", false, edtWalletId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WalletId) )
         {
            A637WalletId = AV7WalletId;
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TipoCuentaId) )
         {
            edtTipoCuentaId_Enabled = 0;
            AssignProp("", false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         }
         else
         {
            edtTipoCuentaId_Enabled = 1;
            AssignProp("", false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_MonedaId) )
         {
            dynMonedaId.Enabled = 0;
            AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), true);
         }
         else
         {
            dynMonedaId.Enabled = 1;
            AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_MonedaId) )
         {
            A118MonedaId = AV14Insert_MonedaId;
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TipoCuentaId) )
         {
            A483TipoCuentaId = AV13Insert_TipoCuentaId;
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
            AV18Pgmname = "Wallet";
            AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
            /* Using cursor T00297 */
            pr_default.execute(5, new Object[] {n118MonedaId, A118MonedaId});
            A119MonedaISOSimbolo = T00297_A119MonedaISOSimbolo[0];
            pr_default.close(5);
            /* Using cursor T00296 */
            pr_default.execute(4, new Object[] {A483TipoCuentaId});
            A636TipoCuentaConcepto = T00296_A636TipoCuentaConcepto[0];
            AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
            A484TipoCuentaNombre = T00296_A484TipoCuentaNombre[0];
            AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
            pr_default.close(4);
         }
      }

      protected void Load2992( )
      {
         /* Using cursor T00298 */
         pr_default.execute(6, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound92 = 1;
            A636TipoCuentaConcepto = T00298_A636TipoCuentaConcepto[0];
            AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
            A484TipoCuentaNombre = T00298_A484TipoCuentaNombre[0];
            AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
            A638WalletTipoEntidad = T00298_A638WalletTipoEntidad[0];
            AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
            A639WalletCodRefencia = T00298_A639WalletCodRefencia[0];
            AssignAttri("", false, "A639WalletCodRefencia", A639WalletCodRefencia);
            A119MonedaISOSimbolo = T00298_A119MonedaISOSimbolo[0];
            A665WalletEstado = T00298_A665WalletEstado[0];
            AssignAttri("", false, "A665WalletEstado", A665WalletEstado);
            A483TipoCuentaId = T00298_A483TipoCuentaId[0];
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            A118MonedaId = T00298_A118MonedaId[0];
            n118MonedaId = T00298_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            ZM2992( -29) ;
         }
         pr_default.close(6);
         OnLoadActions2992( ) ;
      }

      protected void OnLoadActions2992( )
      {
         AV18Pgmname = "Wallet";
         AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
         GXt_decimal2 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
         A647WalletTotalCredito = GXt_decimal2;
         AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
         GXt_decimal2 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
         A646WalletTotalDebito = GXt_decimal2;
         AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
         A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
         AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
         GXt_char3 = A715WalletNombre;
         new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
         A715WalletNombre = GXt_char3;
         AssignAttri("", false, "A715WalletNombre", A715WalletNombre);
         GXt_decimal2 = A1007WalletSolicitudesPendientes;
         new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
         A1007WalletSolicitudesPendientes = GXt_decimal2;
         AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
         A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
         AssignAttri("", false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
      }

      protected void CheckExtendedTable2992( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV18Pgmname = "Wallet";
         AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
         /* Using cursor T00299 */
         pr_default.execute(7, new Object[] {A639WalletCodRefencia, A637WalletId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Código de Refencia", "")}), "DuplicateCandidateKey", 1, "WALLETCODREFENCIA");
            AnyError = 1;
            GX_FocusControl = edtWalletCodRefencia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         GXt_decimal2 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
         A647WalletTotalCredito = GXt_decimal2;
         AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
         GXt_decimal2 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
         A646WalletTotalDebito = GXt_decimal2;
         AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
         A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
         AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
         /* Using cursor T00296 */
         pr_default.execute(4, new Object[] {A483TipoCuentaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
            AnyError = 1;
            GX_FocusControl = edtTipoCuentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A636TipoCuentaConcepto = T00296_A636TipoCuentaConcepto[0];
         AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
         A484TipoCuentaNombre = T00296_A484TipoCuentaNombre[0];
         AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A638WalletTipoEntidad, "CLI") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "COM") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "PRO") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "EMP") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "OTR") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Wallet Tipo Entidad", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WALLETTIPOENTIDAD");
            AnyError = 1;
            GX_FocusControl = cmbWalletTipoEntidad_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXt_char3 = A715WalletNombre;
         new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
         A715WalletNombre = GXt_char3;
         AssignAttri("", false, "A715WalletNombre", A715WalletNombre);
         GXt_decimal2 = A1007WalletSolicitudesPendientes;
         new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
         A1007WalletSolicitudesPendientes = GXt_decimal2;
         AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
         A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
         AssignAttri("", false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
         /* Using cursor T00297 */
         pr_default.execute(5, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
               GX_FocusControl = dynMonedaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A119MonedaISOSimbolo = T00297_A119MonedaISOSimbolo[0];
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A665WalletEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A665WalletEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A665WalletEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A665WalletEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "WALLETESTADO");
            AnyError = 1;
            GX_FocusControl = cmbWalletEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2992( )
      {
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_31( long A483TipoCuentaId )
      {
         /* Using cursor T002910 */
         pr_default.execute(8, new Object[] {A483TipoCuentaId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
            AnyError = 1;
            GX_FocusControl = edtTipoCuentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A636TipoCuentaConcepto = T002910_A636TipoCuentaConcepto[0];
         AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
         A484TipoCuentaNombre = T002910_A484TipoCuentaNombre[0];
         AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A636TipoCuentaConcepto))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A484TipoCuentaNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_32( short A118MonedaId )
      {
         /* Using cursor T002911 */
         pr_default.execute(9, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
               GX_FocusControl = dynMonedaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A119MonedaISOSimbolo = T002911_A119MonedaISOSimbolo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A119MonedaISOSimbolo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey2992( )
      {
         /* Using cursor T002912 */
         pr_default.execute(10, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound92 = 1;
         }
         else
         {
            RcdFound92 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00295 */
         pr_default.execute(3, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2992( 29) ;
            RcdFound92 = 1;
            A637WalletId = T00295_A637WalletId[0];
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
            A638WalletTipoEntidad = T00295_A638WalletTipoEntidad[0];
            AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
            A639WalletCodRefencia = T00295_A639WalletCodRefencia[0];
            AssignAttri("", false, "A639WalletCodRefencia", A639WalletCodRefencia);
            A665WalletEstado = T00295_A665WalletEstado[0];
            AssignAttri("", false, "A665WalletEstado", A665WalletEstado);
            A483TipoCuentaId = T00295_A483TipoCuentaId[0];
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            A118MonedaId = T00295_A118MonedaId[0];
            n118MonedaId = T00295_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            Z637WalletId = A637WalletId;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2992( ) ;
            if ( AnyError == 1 )
            {
               RcdFound92 = 0;
               InitializeNonKey2992( ) ;
            }
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound92 = 0;
            InitializeNonKey2992( ) ;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2992( ) ;
         if ( RcdFound92 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound92 = 0;
         /* Using cursor T002913 */
         pr_default.execute(11, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002913_A637WalletId[0] < A637WalletId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002913_A637WalletId[0] > A637WalletId ) ) )
            {
               A637WalletId = T002913_A637WalletId[0];
               AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound92 = 0;
         /* Using cursor T002914 */
         pr_default.execute(12, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T002914_A637WalletId[0] > A637WalletId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T002914_A637WalletId[0] < A637WalletId ) ) )
            {
               A637WalletId = T002914_A637WalletId[0];
               AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2992( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipoCuentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2992( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound92 == 1 )
            {
               if ( A637WalletId != Z637WalletId )
               {
                  A637WalletId = Z637WalletId;
                  AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WALLETID");
                  AnyError = 1;
                  GX_FocusControl = edtWalletId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2992( ) ;
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A637WalletId != Z637WalletId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2992( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WALLETID");
                     AnyError = 1;
                     GX_FocusControl = edtWalletId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipoCuentaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2992( ) ;
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
         if ( A637WalletId != Z637WalletId )
         {
            A637WalletId = Z637WalletId;
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WALLETID");
            AnyError = 1;
            GX_FocusControl = edtWalletId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipoCuentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2992( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00294 */
            pr_default.execute(2, new Object[] {A637WalletId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Wallet"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z638WalletTipoEntidad, T00294_A638WalletTipoEntidad[0]) != 0 ) || ( StringUtil.StrCmp(Z639WalletCodRefencia, T00294_A639WalletCodRefencia[0]) != 0 ) || ( StringUtil.StrCmp(Z665WalletEstado, T00294_A665WalletEstado[0]) != 0 ) || ( Z483TipoCuentaId != T00294_A483TipoCuentaId[0] ) || ( Z118MonedaId != T00294_A118MonedaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z638WalletTipoEntidad, T00294_A638WalletTipoEntidad[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletTipoEntidad");
                  GXUtil.WriteLogRaw("Old: ",Z638WalletTipoEntidad);
                  GXUtil.WriteLogRaw("Current: ",T00294_A638WalletTipoEntidad[0]);
               }
               if ( StringUtil.StrCmp(Z639WalletCodRefencia, T00294_A639WalletCodRefencia[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletCodRefencia");
                  GXUtil.WriteLogRaw("Old: ",Z639WalletCodRefencia);
                  GXUtil.WriteLogRaw("Current: ",T00294_A639WalletCodRefencia[0]);
               }
               if ( StringUtil.StrCmp(Z665WalletEstado, T00294_A665WalletEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletEstado");
                  GXUtil.WriteLogRaw("Old: ",Z665WalletEstado);
                  GXUtil.WriteLogRaw("Current: ",T00294_A665WalletEstado[0]);
               }
               if ( Z483TipoCuentaId != T00294_A483TipoCuentaId[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"TipoCuentaId");
                  GXUtil.WriteLogRaw("Old: ",Z483TipoCuentaId);
                  GXUtil.WriteLogRaw("Current: ",T00294_A483TipoCuentaId[0]);
               }
               if ( Z118MonedaId != T00294_A118MonedaId[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"MonedaId");
                  GXUtil.WriteLogRaw("Old: ",Z118MonedaId);
                  GXUtil.WriteLogRaw("Current: ",T00294_A118MonedaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Wallet"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2992( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2992( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2992( 0) ;
            CheckOptimisticConcurrency2992( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2992( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2992( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002915 */
                     pr_default.execute(13, new Object[] {A638WalletTipoEntidad, A639WalletCodRefencia, A665WalletEstado, A483TipoCuentaId, n118MonedaId, A118MonedaId});
                     A637WalletId = T002915_A637WalletId[0];
                     AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Wallet");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2992( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption290( ) ;
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
               Load2992( ) ;
            }
            EndLevel2992( ) ;
         }
         CloseExtendedTableCursors2992( ) ;
      }

      protected void Update2992( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2992( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2992( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2992( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2992( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002916 */
                     pr_default.execute(14, new Object[] {A638WalletTipoEntidad, A639WalletCodRefencia, A665WalletEstado, A483TipoCuentaId, n118MonedaId, A118MonedaId, A637WalletId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Wallet");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Wallet"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2992( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2992( ) ;
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
            EndLevel2992( ) ;
         }
         CloseExtendedTableCursors2992( ) ;
      }

      protected void DeferredUpdate2992( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2992( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2992( ) ;
            AfterConfirm2992( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2992( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2993( ) ;
                  while ( RcdFound93 != 0 )
                  {
                     getByPrimaryKey2993( ) ;
                     Delete2993( ) ;
                     ScanNext2993( ) ;
                  }
                  ScanEnd2993( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002917 */
                     pr_default.execute(15, new Object[] {A637WalletId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Wallet");
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
         sMode92 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2992( ) ;
         Gx_mode = sMode92;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2992( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV18Pgmname = "Wallet";
            AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
            /* Using cursor T002918 */
            pr_default.execute(16, new Object[] {A483TipoCuentaId});
            A636TipoCuentaConcepto = T002918_A636TipoCuentaConcepto[0];
            AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
            A484TipoCuentaNombre = T002918_A484TipoCuentaNombre[0];
            AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
            pr_default.close(16);
            GXt_char3 = A715WalletNombre;
            new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
            A715WalletNombre = GXt_char3;
            AssignAttri("", false, "A715WalletNombre", A715WalletNombre);
            GXt_decimal2 = A1007WalletSolicitudesPendientes;
            new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
            A1007WalletSolicitudesPendientes = GXt_decimal2;
            AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
            A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
            AssignAttri("", false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
            /* Using cursor T002919 */
            pr_default.execute(17, new Object[] {n118MonedaId, A118MonedaId});
            A119MonedaISOSimbolo = T002919_A119MonedaISOSimbolo[0];
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel2993( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow2993( ) ;
            if ( ( nRcdExists_93 != 0 ) || ( nIsMod_93 != 0 ) )
            {
               standaloneNotModal2993( ) ;
               GetKey2993( ) ;
               if ( ( nRcdExists_93 == 0 ) && ( nRcdDeleted_93 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2993( ) ;
               }
               else
               {
                  if ( RcdFound93 != 0 )
                  {
                     if ( ( nRcdDeleted_93 != 0 ) && ( nRcdExists_93 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2993( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_93 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2993( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_93 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtWalletBalancesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtWalletBalancesFechaAlta_Internalname, context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")) ;
            ChangePostValue( edtWalletBalancesUsrAlta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbWalletBalancesTipoMov_Internalname, StringUtil.RTrim( A643WalletBalancesTipoMov)) ;
            ChangePostValue( edtWalletBalancesImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbWalletBalancesEstadoOPE_Internalname, StringUtil.RTrim( A645WalletBalancesEstadoOPE)) ;
            ChangePostValue( "ZT_"+"Z640WalletBalancesId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z641WalletBalancesFechaAlta_"+sGXsfl_88_idx, context.localUtil.TToC( Z641WalletBalancesFechaAlta, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z642WalletBalancesUsrAlta_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z643WalletBalancesTipoMov_"+sGXsfl_88_idx, StringUtil.RTrim( Z643WalletBalancesTipoMov)) ;
            ChangePostValue( "ZT_"+"Z644WalletBalancesImporte_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( Z644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1009WalletBalancesObs_"+sGXsfl_88_idx, Z1009WalletBalancesObs) ;
            ChangePostValue( "ZT_"+"Z1010WalletBalancesConcepto_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1010WalletBalancesConcepto), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1011WalletBalancesUrl_"+sGXsfl_88_idx, Z1011WalletBalancesUrl) ;
            ChangePostValue( "ZT_"+"Z645WalletBalancesEstadoOPE_"+sGXsfl_88_idx, StringUtil.RTrim( Z645WalletBalancesEstadoOPE)) ;
            ChangePostValue( "ZT_"+"Z1012WalletBalanceLiquidacion_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1012WalletBalanceLiquidacion), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_93_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_93), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_93_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_93), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_93_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_93), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_93 != 0 )
            {
               ChangePostValue( "WALLETBALANCESID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESFECHAALTA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESUSRALTA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESTIPOMOV_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESIMPORTE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WALLETBALANCESESTADOOPE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2993( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_93 = 0;
         nIsMod_93 = 0;
         nRcdDeleted_93 = 0;
      }

      protected void ProcessLevel2992( )
      {
         /* Save parent mode. */
         sMode92 = Gx_mode;
         ProcessNestedLevel2993( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode92;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2992( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2992( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("wallet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues290( ) ;
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
            pr_default.close(16);
            pr_default.close(17);
            context.RollbackDataStores("wallet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2992( )
      {
         /* Scan By routine */
         /* Using cursor T002920 */
         pr_default.execute(18);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound92 = 1;
            A637WalletId = T002920_A637WalletId[0];
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2992( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound92 = 1;
            A637WalletId = T002920_A637WalletId[0];
            AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
         }
      }

      protected void ScanEnd2992( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2992( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2992( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2992( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2992( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2992( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2992( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2992( )
      {
         edtWalletId_Enabled = 0;
         AssignProp("", false, edtWalletId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletId_Enabled), 5, 0), true);
         edtTipoCuentaId_Enabled = 0;
         AssignProp("", false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         cmbTipoCuentaConcepto.Enabled = 0;
         AssignProp("", false, cmbTipoCuentaConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipoCuentaConcepto.Enabled), 5, 0), true);
         cmbWalletEstado.Enabled = 0;
         AssignProp("", false, cmbWalletEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletEstado.Enabled), 5, 0), true);
         cmbWalletTipoEntidad.Enabled = 0;
         AssignProp("", false, cmbWalletTipoEntidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletTipoEntidad.Enabled), 5, 0), true);
         edtWalletCodRefencia_Enabled = 0;
         AssignProp("", false, edtWalletCodRefencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletCodRefencia_Enabled), 5, 0), true);
         edtWalletNombre_Enabled = 0;
         AssignProp("", false, edtWalletNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletNombre_Enabled), 5, 0), true);
         edtTipoCuentaNombre_Enabled = 0;
         AssignProp("", false, edtTipoCuentaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaNombre_Enabled), 5, 0), true);
         dynMonedaId.Enabled = 0;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), true);
         edtWalletTotalDebito_Enabled = 0;
         AssignProp("", false, edtWalletTotalDebito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalDebito_Enabled), 5, 0), true);
         edtWalletTotalCredito_Enabled = 0;
         AssignProp("", false, edtWalletTotalCredito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalCredito_Enabled), 5, 0), true);
         edtWalletSaldo_Enabled = 0;
         AssignProp("", false, edtWalletSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSaldo_Enabled), 5, 0), true);
         edtWalletSaldoAlDia_Enabled = 0;
         AssignProp("", false, edtWalletSaldoAlDia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSaldoAlDia_Enabled), 5, 0), true);
         edtWalletSolicitudesPendientes_Enabled = 0;
         AssignProp("", false, edtWalletSolicitudesPendientes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSolicitudesPendientes_Enabled), 5, 0), true);
      }

      protected void ZM2993( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z641WalletBalancesFechaAlta = T00293_A641WalletBalancesFechaAlta[0];
               Z642WalletBalancesUsrAlta = T00293_A642WalletBalancesUsrAlta[0];
               Z643WalletBalancesTipoMov = T00293_A643WalletBalancesTipoMov[0];
               Z644WalletBalancesImporte = T00293_A644WalletBalancesImporte[0];
               Z1009WalletBalancesObs = T00293_A1009WalletBalancesObs[0];
               Z1010WalletBalancesConcepto = T00293_A1010WalletBalancesConcepto[0];
               Z1011WalletBalancesUrl = T00293_A1011WalletBalancesUrl[0];
               Z645WalletBalancesEstadoOPE = T00293_A645WalletBalancesEstadoOPE[0];
               Z1012WalletBalanceLiquidacion = T00293_A1012WalletBalanceLiquidacion[0];
            }
            else
            {
               Z641WalletBalancesFechaAlta = A641WalletBalancesFechaAlta;
               Z642WalletBalancesUsrAlta = A642WalletBalancesUsrAlta;
               Z643WalletBalancesTipoMov = A643WalletBalancesTipoMov;
               Z644WalletBalancesImporte = A644WalletBalancesImporte;
               Z1009WalletBalancesObs = A1009WalletBalancesObs;
               Z1010WalletBalancesConcepto = A1010WalletBalancesConcepto;
               Z1011WalletBalancesUrl = A1011WalletBalancesUrl;
               Z645WalletBalancesEstadoOPE = A645WalletBalancesEstadoOPE;
               Z1012WalletBalanceLiquidacion = A1012WalletBalanceLiquidacion;
            }
         }
         if ( GX_JID == -33 )
         {
            Z637WalletId = A637WalletId;
            Z640WalletBalancesId = A640WalletBalancesId;
            Z641WalletBalancesFechaAlta = A641WalletBalancesFechaAlta;
            Z642WalletBalancesUsrAlta = A642WalletBalancesUsrAlta;
            Z643WalletBalancesTipoMov = A643WalletBalancesTipoMov;
            Z644WalletBalancesImporte = A644WalletBalancesImporte;
            Z1009WalletBalancesObs = A1009WalletBalancesObs;
            Z1010WalletBalancesConcepto = A1010WalletBalancesConcepto;
            Z1011WalletBalancesUrl = A1011WalletBalancesUrl;
            Z645WalletBalancesEstadoOPE = A645WalletBalancesEstadoOPE;
            Z1012WalletBalanceLiquidacion = A1012WalletBalanceLiquidacion;
         }
      }

      protected void standaloneNotModal2993( )
      {
         edtWalletBalancesId_Enabled = 0;
         AssignProp("", false, edtWalletBalancesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesFechaAlta_Enabled = 0;
         AssignProp("", false, edtWalletBalancesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesUsrAlta_Enabled = 0;
         AssignProp("", false, edtWalletBalancesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         cmbWalletBalancesTipoMov.Enabled = 0;
         AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesImporte_Enabled = 0;
         AssignProp("", false, edtWalletBalancesImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void standaloneModal2993( )
      {
      }

      protected void Load2993( )
      {
         /* Using cursor T002921 */
         pr_default.execute(19, new Object[] {A637WalletId, A640WalletBalancesId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound93 = 1;
            A641WalletBalancesFechaAlta = T002921_A641WalletBalancesFechaAlta[0];
            A642WalletBalancesUsrAlta = T002921_A642WalletBalancesUsrAlta[0];
            A643WalletBalancesTipoMov = T002921_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = T002921_A644WalletBalancesImporte[0];
            A1009WalletBalancesObs = T002921_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = T002921_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = T002921_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = T002921_n1010WalletBalancesConcepto[0];
            A1011WalletBalancesUrl = T002921_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = T002921_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = T002921_A645WalletBalancesEstadoOPE[0];
            A1012WalletBalanceLiquidacion = T002921_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = T002921_n1012WalletBalanceLiquidacion[0];
            ZM2993( -33) ;
         }
         pr_default.close(19);
         OnLoadActions2993( ) ;
      }

      protected void OnLoadActions2993( )
      {
      }

      protected void CheckExtendedTable2993( )
      {
         nIsDirty_93 = 0;
         Gx_BScreen = 1;
         standaloneModal2993( ) ;
      }

      protected void CloseExtendedTableCursors2993( )
      {
      }

      protected void enableDisable2993( )
      {
      }

      protected void GetKey2993( )
      {
         /* Using cursor T002922 */
         pr_default.execute(20, new Object[] {A637WalletId, A640WalletBalancesId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound93 = 1;
         }
         else
         {
            RcdFound93 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey2993( )
      {
         /* Using cursor T00293 */
         pr_default.execute(1, new Object[] {A637WalletId, A640WalletBalancesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2993( 33) ;
            RcdFound93 = 1;
            InitializeNonKey2993( ) ;
            A640WalletBalancesId = T00293_A640WalletBalancesId[0];
            A641WalletBalancesFechaAlta = T00293_A641WalletBalancesFechaAlta[0];
            A642WalletBalancesUsrAlta = T00293_A642WalletBalancesUsrAlta[0];
            A643WalletBalancesTipoMov = T00293_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = T00293_A644WalletBalancesImporte[0];
            A1009WalletBalancesObs = T00293_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = T00293_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = T00293_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = T00293_n1010WalletBalancesConcepto[0];
            A1011WalletBalancesUrl = T00293_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = T00293_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = T00293_A645WalletBalancesEstadoOPE[0];
            A1012WalletBalanceLiquidacion = T00293_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = T00293_n1012WalletBalanceLiquidacion[0];
            Z637WalletId = A637WalletId;
            Z640WalletBalancesId = A640WalletBalancesId;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2993( ) ;
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound93 = 0;
            InitializeNonKey2993( ) ;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2993( ) ;
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2993( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2993( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00292 */
            pr_default.execute(0, new Object[] {A637WalletId, A640WalletBalancesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WalletBalances"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z641WalletBalancesFechaAlta != T00292_A641WalletBalancesFechaAlta[0] ) || ( Z642WalletBalancesUsrAlta != T00292_A642WalletBalancesUsrAlta[0] ) || ( StringUtil.StrCmp(Z643WalletBalancesTipoMov, T00292_A643WalletBalancesTipoMov[0]) != 0 ) || ( Z644WalletBalancesImporte != T00292_A644WalletBalancesImporte[0] ) || ( StringUtil.StrCmp(Z1009WalletBalancesObs, T00292_A1009WalletBalancesObs[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1010WalletBalancesConcepto != T00292_A1010WalletBalancesConcepto[0] ) || ( StringUtil.StrCmp(Z1011WalletBalancesUrl, T00292_A1011WalletBalancesUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z645WalletBalancesEstadoOPE, T00292_A645WalletBalancesEstadoOPE[0]) != 0 ) || ( Z1012WalletBalanceLiquidacion != T00292_A1012WalletBalanceLiquidacion[0] ) )
            {
               if ( Z641WalletBalancesFechaAlta != T00292_A641WalletBalancesFechaAlta[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z641WalletBalancesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T00292_A641WalletBalancesFechaAlta[0]);
               }
               if ( Z642WalletBalancesUsrAlta != T00292_A642WalletBalancesUsrAlta[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z642WalletBalancesUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T00292_A642WalletBalancesUsrAlta[0]);
               }
               if ( StringUtil.StrCmp(Z643WalletBalancesTipoMov, T00292_A643WalletBalancesTipoMov[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesTipoMov");
                  GXUtil.WriteLogRaw("Old: ",Z643WalletBalancesTipoMov);
                  GXUtil.WriteLogRaw("Current: ",T00292_A643WalletBalancesTipoMov[0]);
               }
               if ( Z644WalletBalancesImporte != T00292_A644WalletBalancesImporte[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesImporte");
                  GXUtil.WriteLogRaw("Old: ",Z644WalletBalancesImporte);
                  GXUtil.WriteLogRaw("Current: ",T00292_A644WalletBalancesImporte[0]);
               }
               if ( StringUtil.StrCmp(Z1009WalletBalancesObs, T00292_A1009WalletBalancesObs[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesObs");
                  GXUtil.WriteLogRaw("Old: ",Z1009WalletBalancesObs);
                  GXUtil.WriteLogRaw("Current: ",T00292_A1009WalletBalancesObs[0]);
               }
               if ( Z1010WalletBalancesConcepto != T00292_A1010WalletBalancesConcepto[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1010WalletBalancesConcepto);
                  GXUtil.WriteLogRaw("Current: ",T00292_A1010WalletBalancesConcepto[0]);
               }
               if ( StringUtil.StrCmp(Z1011WalletBalancesUrl, T00292_A1011WalletBalancesUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesUrl");
                  GXUtil.WriteLogRaw("Old: ",Z1011WalletBalancesUrl);
                  GXUtil.WriteLogRaw("Current: ",T00292_A1011WalletBalancesUrl[0]);
               }
               if ( StringUtil.StrCmp(Z645WalletBalancesEstadoOPE, T00292_A645WalletBalancesEstadoOPE[0]) != 0 )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalancesEstadoOPE");
                  GXUtil.WriteLogRaw("Old: ",Z645WalletBalancesEstadoOPE);
                  GXUtil.WriteLogRaw("Current: ",T00292_A645WalletBalancesEstadoOPE[0]);
               }
               if ( Z1012WalletBalanceLiquidacion != T00292_A1012WalletBalanceLiquidacion[0] )
               {
                  GXUtil.WriteLog("wallet:[seudo value changed for attri]"+"WalletBalanceLiquidacion");
                  GXUtil.WriteLogRaw("Old: ",Z1012WalletBalanceLiquidacion);
                  GXUtil.WriteLogRaw("Current: ",T00292_A1012WalletBalanceLiquidacion[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WalletBalances"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2993( )
      {
         BeforeValidate2993( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2993( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2993( 0) ;
            CheckOptimisticConcurrency2993( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2993( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2993( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002923 */
                     pr_default.execute(21, new Object[] {A637WalletId, A640WalletBalancesId, A641WalletBalancesFechaAlta, A642WalletBalancesUsrAlta, A643WalletBalancesTipoMov, A644WalletBalancesImporte, n1009WalletBalancesObs, A1009WalletBalancesObs, n1010WalletBalancesConcepto, A1010WalletBalancesConcepto, n1011WalletBalancesUrl, A1011WalletBalancesUrl, A645WalletBalancesEstadoOPE, n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
                     if ( (pr_default.getStatus(21) == 1) )
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
               Load2993( ) ;
            }
            EndLevel2993( ) ;
         }
         CloseExtendedTableCursors2993( ) ;
      }

      protected void Update2993( )
      {
         BeforeValidate2993( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2993( ) ;
         }
         if ( ( nIsMod_93 != 0 ) || ( nIsDirty_93 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2993( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2993( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2993( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002924 */
                        pr_default.execute(22, new Object[] {A641WalletBalancesFechaAlta, A642WalletBalancesUsrAlta, A643WalletBalancesTipoMov, A644WalletBalancesImporte, n1009WalletBalancesObs, A1009WalletBalancesObs, n1010WalletBalancesConcepto, A1010WalletBalancesConcepto, n1011WalletBalancesUrl, A1011WalletBalancesUrl, A645WalletBalancesEstadoOPE, n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion, A637WalletId, A640WalletBalancesId});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WalletBalances"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2993( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2993( ) ;
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
               EndLevel2993( ) ;
            }
         }
         CloseExtendedTableCursors2993( ) ;
      }

      protected void DeferredUpdate2993( )
      {
      }

      protected void Delete2993( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2993( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2993( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2993( ) ;
            AfterConfirm2993( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2993( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002925 */
                  pr_default.execute(23, new Object[] {A637WalletId, A640WalletBalancesId});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
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
         sMode93 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2993( ) ;
         Gx_mode = sMode93;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2993( )
      {
         standaloneModal2993( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2993( )
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

      public void ScanStart2993( )
      {
         /* Scan By routine */
         /* Using cursor T002926 */
         pr_default.execute(24, new Object[] {A637WalletId});
         RcdFound93 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound93 = 1;
            A640WalletBalancesId = T002926_A640WalletBalancesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2993( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound93 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound93 = 1;
            A640WalletBalancesId = T002926_A640WalletBalancesId[0];
         }
      }

      protected void ScanEnd2993( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm2993( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2993( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2993( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2993( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2993( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2993( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2993( )
      {
         edtWalletBalancesId_Enabled = 0;
         AssignProp("", false, edtWalletBalancesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesFechaAlta_Enabled = 0;
         AssignProp("", false, edtWalletBalancesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesUsrAlta_Enabled = 0;
         AssignProp("", false, edtWalletBalancesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         cmbWalletBalancesTipoMov.Enabled = 0;
         AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesImporte_Enabled = 0;
         AssignProp("", false, edtWalletBalancesImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes2993( )
      {
      }

      protected void send_integrity_lvl_hashes2992( )
      {
      }

      protected void SubsflControlProps_8893( )
      {
         edtWalletBalancesId_Internalname = "WALLETBALANCESID_"+sGXsfl_88_idx;
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA_"+sGXsfl_88_idx;
         edtWalletBalancesUsrAlta_Internalname = "WALLETBALANCESUSRALTA_"+sGXsfl_88_idx;
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV_"+sGXsfl_88_idx;
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE_"+sGXsfl_88_idx;
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8893( )
      {
         edtWalletBalancesId_Internalname = "WALLETBALANCESID_"+sGXsfl_88_fel_idx;
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA_"+sGXsfl_88_fel_idx;
         edtWalletBalancesUsrAlta_Internalname = "WALLETBALANCESUSRALTA_"+sGXsfl_88_fel_idx;
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV_"+sGXsfl_88_fel_idx;
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE_"+sGXsfl_88_fel_idx;
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow2993( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8893( ) ;
         SendRow2993( ) ;
      }

      protected void SendRow2993( )
      {
         Gridlevel_balancesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_balances_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_balances_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_balances_Class, "") != 0 )
            {
               subGridlevel_balances_Linesclass = subGridlevel_balances_Class+"Odd";
            }
         }
         else if ( subGridlevel_balances_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_balances_Backstyle = 0;
            subGridlevel_balances_Backcolor = subGridlevel_balances_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_balances_Class, "") != 0 )
            {
               subGridlevel_balances_Linesclass = subGridlevel_balances_Class+"Uniform";
            }
         }
         else if ( subGridlevel_balances_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_balances_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_balances_Class, "") != 0 )
            {
               subGridlevel_balances_Linesclass = subGridlevel_balances_Class+"Odd";
            }
            subGridlevel_balances_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_balances_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_balances_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridlevel_balances_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_balances_Class, "") != 0 )
               {
                  subGridlevel_balances_Linesclass = subGridlevel_balances_Class+"Even";
               }
            }
            else
            {
               subGridlevel_balances_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_balances_Class, "") != 0 )
               {
                  subGridlevel_balances_Linesclass = subGridlevel_balances_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_93_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_balancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWalletBalancesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A640WalletBalancesId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWalletBalancesId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_93_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_balancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesFechaAlta_Internalname,context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A641WalletBalancesFechaAlta, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWalletBalancesFechaAlta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_93_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_balancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesUsrAlta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWalletBalancesUsrAlta_Enabled!=0) ? context.localUtil.Format( (decimal)(A642WalletBalancesUsrAlta), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A642WalletBalancesUsrAlta), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,91);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWalletBalancesUsrAlta_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"UserID",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_93_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_88_idx + "',88)\"";
         if ( ( cmbWalletBalancesTipoMov.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "WALLETBALANCESTIPOMOV_" + sGXsfl_88_idx;
            cmbWalletBalancesTipoMov.Name = GXCCtl;
            cmbWalletBalancesTipoMov.WebTags = "";
            cmbWalletBalancesTipoMov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
            cmbWalletBalancesTipoMov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
            if ( cmbWalletBalancesTipoMov.ItemCount > 0 )
            {
               A643WalletBalancesTipoMov = cmbWalletBalancesTipoMov.getValidValue(A643WalletBalancesTipoMov);
            }
         }
         /* ComboBox */
         Gridlevel_balancesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesTipoMov,(string)cmbWalletBalancesTipoMov_Internalname,StringUtil.RTrim( A643WalletBalancesTipoMov),(short)1,(string)cmbWalletBalancesTipoMov_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbWalletBalancesTipoMov.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"",(string)"",(bool)true,(short)0});
         cmbWalletBalancesTipoMov.CurrentValue = StringUtil.RTrim( A643WalletBalancesTipoMov);
         AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Values", (string)(cmbWalletBalancesTipoMov.ToJavascriptSource()), !bGXsfl_88_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_93_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_balancesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletBalancesImporte_Internalname,StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtWalletBalancesImporte_Enabled!=0) ? context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletBalancesImporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWalletBalancesImporte_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_93_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_88_idx + "',88)\"";
         if ( ( cmbWalletBalancesEstadoOPE.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "WALLETBALANCESESTADOOPE_" + sGXsfl_88_idx;
            cmbWalletBalancesEstadoOPE.Name = GXCCtl;
            cmbWalletBalancesEstadoOPE.WebTags = "";
            cmbWalletBalancesEstadoOPE.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
            cmbWalletBalancesEstadoOPE.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
            cmbWalletBalancesEstadoOPE.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
            if ( cmbWalletBalancesEstadoOPE.ItemCount > 0 )
            {
               A645WalletBalancesEstadoOPE = cmbWalletBalancesEstadoOPE.getValidValue(A645WalletBalancesEstadoOPE);
            }
         }
         /* ComboBox */
         Gridlevel_balancesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletBalancesEstadoOPE,(string)cmbWalletBalancesEstadoOPE_Internalname,StringUtil.RTrim( A645WalletBalancesEstadoOPE),(short)1,(string)cmbWalletBalancesEstadoOPE_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbWalletBalancesEstadoOPE.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"",(string)"",(bool)true,(short)0});
         cmbWalletBalancesEstadoOPE.CurrentValue = StringUtil.RTrim( A645WalletBalancesEstadoOPE);
         AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Values", (string)(cmbWalletBalancesEstadoOPE.ToJavascriptSource()), !bGXsfl_88_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_balancesRow);
         send_integrity_lvl_hashes2993( ) ;
         GXCCtl = "Z640WalletBalancesId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z640WalletBalancesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z641WalletBalancesFechaAlta_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z641WalletBalancesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z642WalletBalancesUsrAlta_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z642WalletBalancesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z643WalletBalancesTipoMov_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z643WalletBalancesTipoMov));
         GXCCtl = "Z644WalletBalancesImporte_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z644WalletBalancesImporte, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z1009WalletBalancesObs_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z1009WalletBalancesObs);
         GXCCtl = "Z1010WalletBalancesConcepto_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1010WalletBalancesConcepto), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z1011WalletBalancesUrl_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z1011WalletBalancesUrl);
         GXCCtl = "Z645WalletBalancesEstadoOPE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z645WalletBalancesEstadoOPE));
         GXCCtl = "Z1012WalletBalanceLiquidacion_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1012WalletBalanceLiquidacion), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_93_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_93), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_93_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_93), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_93_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_93), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vWALLETID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESFECHAALTA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESUSRALTA_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESTIPOMOV_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESIMPORTE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESESTADOOPE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_balancesContainer.AddRow(Gridlevel_balancesRow);
      }

      protected void ReadRow2993( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8893( ) ;
         edtWalletBalancesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWalletBalancesFechaAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESFECHAALTA_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWalletBalancesUsrAlta_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESUSRALTA_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWalletBalancesTipoMov.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESTIPOMOV_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtWalletBalancesImporte_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESIMPORTE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWalletBalancesEstadoOPE.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WALLETBALANCESESTADOOPE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A640WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A641WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( edtWalletBalancesFechaAlta_Internalname));
         A642WalletBalancesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletBalancesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbWalletBalancesTipoMov.Name = cmbWalletBalancesTipoMov_Internalname;
         cmbWalletBalancesTipoMov.CurrentValue = cgiGet( cmbWalletBalancesTipoMov_Internalname);
         A643WalletBalancesTipoMov = cgiGet( cmbWalletBalancesTipoMov_Internalname);
         A644WalletBalancesImporte = context.localUtil.CToN( cgiGet( edtWalletBalancesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         cmbWalletBalancesEstadoOPE.Name = cmbWalletBalancesEstadoOPE_Internalname;
         cmbWalletBalancesEstadoOPE.CurrentValue = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
         A645WalletBalancesEstadoOPE = cgiGet( cmbWalletBalancesEstadoOPE_Internalname);
         GXCCtl = "Z640WalletBalancesId_" + sGXsfl_88_idx;
         Z640WalletBalancesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z641WalletBalancesFechaAlta_" + sGXsfl_88_idx;
         Z641WalletBalancesFechaAlta = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z642WalletBalancesUsrAlta_" + sGXsfl_88_idx;
         Z642WalletBalancesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z643WalletBalancesTipoMov_" + sGXsfl_88_idx;
         Z643WalletBalancesTipoMov = cgiGet( GXCCtl);
         GXCCtl = "Z644WalletBalancesImporte_" + sGXsfl_88_idx;
         Z644WalletBalancesImporte = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z1009WalletBalancesObs_" + sGXsfl_88_idx;
         Z1009WalletBalancesObs = cgiGet( GXCCtl);
         n1009WalletBalancesObs = (String.IsNullOrEmpty(StringUtil.RTrim( A1009WalletBalancesObs)) ? true : false);
         GXCCtl = "Z1010WalletBalancesConcepto_" + sGXsfl_88_idx;
         Z1010WalletBalancesConcepto = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n1010WalletBalancesConcepto = ((0==A1010WalletBalancesConcepto) ? true : false);
         GXCCtl = "Z1011WalletBalancesUrl_" + sGXsfl_88_idx;
         Z1011WalletBalancesUrl = cgiGet( GXCCtl);
         n1011WalletBalancesUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1011WalletBalancesUrl)) ? true : false);
         GXCCtl = "Z645WalletBalancesEstadoOPE_" + sGXsfl_88_idx;
         Z645WalletBalancesEstadoOPE = cgiGet( GXCCtl);
         GXCCtl = "Z1012WalletBalanceLiquidacion_" + sGXsfl_88_idx;
         Z1012WalletBalanceLiquidacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n1012WalletBalanceLiquidacion = ((0==A1012WalletBalanceLiquidacion) ? true : false);
         GXCCtl = "Z1009WalletBalancesObs_" + sGXsfl_88_idx;
         A1009WalletBalancesObs = cgiGet( GXCCtl);
         n1009WalletBalancesObs = false;
         n1009WalletBalancesObs = (String.IsNullOrEmpty(StringUtil.RTrim( A1009WalletBalancesObs)) ? true : false);
         GXCCtl = "Z1010WalletBalancesConcepto_" + sGXsfl_88_idx;
         A1010WalletBalancesConcepto = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n1010WalletBalancesConcepto = false;
         n1010WalletBalancesConcepto = ((0==A1010WalletBalancesConcepto) ? true : false);
         GXCCtl = "Z1011WalletBalancesUrl_" + sGXsfl_88_idx;
         A1011WalletBalancesUrl = cgiGet( GXCCtl);
         n1011WalletBalancesUrl = false;
         n1011WalletBalancesUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1011WalletBalancesUrl)) ? true : false);
         GXCCtl = "Z1012WalletBalanceLiquidacion_" + sGXsfl_88_idx;
         A1012WalletBalanceLiquidacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n1012WalletBalanceLiquidacion = false;
         n1012WalletBalanceLiquidacion = ((0==A1012WalletBalanceLiquidacion) ? true : false);
         GXCCtl = "nRcdDeleted_93_" + sGXsfl_88_idx;
         nRcdDeleted_93 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_93_" + sGXsfl_88_idx;
         nRcdExists_93 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_93_" + sGXsfl_88_idx;
         nIsMod_93 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defcmbWalletBalancesEstadoOPE_Enabled = cmbWalletBalancesEstadoOPE.Enabled;
         defedtWalletBalancesImporte_Enabled = edtWalletBalancesImporte_Enabled;
         defcmbWalletBalancesTipoMov_Enabled = cmbWalletBalancesTipoMov.Enabled;
         defedtWalletBalancesUsrAlta_Enabled = edtWalletBalancesUsrAlta_Enabled;
         defedtWalletBalancesFechaAlta_Enabled = edtWalletBalancesFechaAlta_Enabled;
         defedtWalletBalancesId_Enabled = edtWalletBalancesId_Enabled;
      }

      protected void ConfirmValues290( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8893( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8893( ) ;
            ChangePostValue( "Z640WalletBalancesId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z640WalletBalancesId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z640WalletBalancesId_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z641WalletBalancesFechaAlta_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z641WalletBalancesFechaAlta_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z641WalletBalancesFechaAlta_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z642WalletBalancesUsrAlta_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z642WalletBalancesUsrAlta_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z642WalletBalancesUsrAlta_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z643WalletBalancesTipoMov_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z643WalletBalancesTipoMov_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z643WalletBalancesTipoMov_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z644WalletBalancesImporte_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z644WalletBalancesImporte_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z644WalletBalancesImporte_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z1009WalletBalancesObs_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z1009WalletBalancesObs_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z1009WalletBalancesObs_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z1010WalletBalancesConcepto_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z1010WalletBalancesConcepto_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z1010WalletBalancesConcepto_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z1011WalletBalancesUrl_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z1011WalletBalancesUrl_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z1011WalletBalancesUrl_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z645WalletBalancesEstadoOPE_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z645WalletBalancesEstadoOPE_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z645WalletBalancesEstadoOPE_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z1012WalletBalanceLiquidacion_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z1012WalletBalanceLiquidacion_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z1012WalletBalanceLiquidacion_"+sGXsfl_88_idx) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
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
         GXEncryptionTmp = "wallet.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WalletId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Wallet");
         forbiddenHiddens.Add("WalletId", context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TipoCuentaId", context.localUtil.Format( (decimal)(AV13Insert_TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_MonedaId", context.localUtil.Format( (decimal)(AV14Insert_MonedaId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wallet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z637WalletId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z638WalletTipoEntidad", StringUtil.RTrim( Z638WalletTipoEntidad));
         GxWebStd.gx_hidden_field( context, "Z639WalletCodRefencia", StringUtil.RTrim( Z639WalletCodRefencia));
         GxWebStd.gx_hidden_field( context, "Z665WalletEstado", StringUtil.RTrim( Z665WalletEstado));
         GxWebStd.gx_hidden_field( context, "Z483TipoCuentaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N483TipoCuentaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOCUENTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_MONEDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MONEDAISOSIMBOLO", StringUtil.RTrim( A119MonedaISOSimbolo));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV18Pgmname));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESOBS", A1009WalletBalancesObs);
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESCONCEPTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010WalletBalancesConcepto), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETBALANCESURL", A1011WalletBalancesUrl);
         GxWebStd.gx_hidden_field( context, "WALLETBALANCELIQUIDACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1012WalletBalanceLiquidacion), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
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
         GXEncryptionTmp = "wallet.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WalletId,18,0));
         return formatLink("wallet.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Wallet" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Saldos y Cuentas", "") ;
      }

      protected void InitializeNonKey2992( )
      {
         A483TipoCuentaId = 0;
         AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
         A118MonedaId = 0;
         n118MonedaId = false;
         AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         n118MonedaId = ((0==A118MonedaId) ? true : false);
         A1008WalletSaldoAlDia = 0;
         AssignAttri("", false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
         A648WalletSaldo = 0;
         AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
         A1007WalletSolicitudesPendientes = 0;
         AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
         A715WalletNombre = "";
         AssignAttri("", false, "A715WalletNombre", A715WalletNombre);
         A646WalletTotalDebito = 0;
         AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
         A647WalletTotalCredito = 0;
         AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
         A636TipoCuentaConcepto = "";
         AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
         A484TipoCuentaNombre = "";
         AssignAttri("", false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
         A638WalletTipoEntidad = "";
         AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
         A639WalletCodRefencia = "";
         AssignAttri("", false, "A639WalletCodRefencia", A639WalletCodRefencia);
         A119MonedaISOSimbolo = "";
         AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
         A665WalletEstado = "";
         AssignAttri("", false, "A665WalletEstado", A665WalletEstado);
         Z638WalletTipoEntidad = "";
         Z639WalletCodRefencia = "";
         Z665WalletEstado = "";
         Z483TipoCuentaId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll2992( )
      {
         A637WalletId = 0;
         AssignAttri("", false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
         InitializeNonKey2992( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2993( )
      {
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A642WalletBalancesUsrAlta = 0;
         A643WalletBalancesTipoMov = "";
         A644WalletBalancesImporte = 0;
         A1009WalletBalancesObs = "";
         n1009WalletBalancesObs = false;
         AssignAttri("", false, "A1009WalletBalancesObs", A1009WalletBalancesObs);
         A1010WalletBalancesConcepto = 0;
         n1010WalletBalancesConcepto = false;
         AssignAttri("", false, "A1010WalletBalancesConcepto", StringUtil.LTrimStr( (decimal)(A1010WalletBalancesConcepto), 4, 0));
         A1011WalletBalancesUrl = "";
         n1011WalletBalancesUrl = false;
         AssignAttri("", false, "A1011WalletBalancesUrl", A1011WalletBalancesUrl);
         A645WalletBalancesEstadoOPE = "";
         A1012WalletBalanceLiquidacion = 0;
         n1012WalletBalanceLiquidacion = false;
         AssignAttri("", false, "A1012WalletBalanceLiquidacion", StringUtil.LTrimStr( (decimal)(A1012WalletBalanceLiquidacion), 18, 0));
         Z641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         Z642WalletBalancesUsrAlta = 0;
         Z643WalletBalancesTipoMov = "";
         Z644WalletBalancesImporte = 0;
         Z1009WalletBalancesObs = "";
         Z1010WalletBalancesConcepto = 0;
         Z1011WalletBalancesUrl = "";
         Z645WalletBalancesEstadoOPE = "";
         Z1012WalletBalanceLiquidacion = 0;
      }

      protected void InitAll2993( )
      {
         A640WalletBalancesId = 0;
         InitializeNonKey2993( ) ;
      }

      protected void StandaloneModalInsert2993( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821401314", true, true, false);
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
         context.AddJavascriptSource("wallet.js", "?202692821401314", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties93( )
      {
         cmbWalletBalancesEstadoOPE.Enabled = defcmbWalletBalancesEstadoOPE_Enabled;
         AssignProp("", false, cmbWalletBalancesEstadoOPE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesImporte_Enabled = defedtWalletBalancesImporte_Enabled;
         AssignProp("", false, edtWalletBalancesImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         cmbWalletBalancesTipoMov.Enabled = defcmbWalletBalancesTipoMov_Enabled;
         AssignProp("", false, cmbWalletBalancesTipoMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesUsrAlta_Enabled = defedtWalletBalancesUsrAlta_Enabled;
         AssignProp("", false, edtWalletBalancesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesFechaAlta_Enabled = defedtWalletBalancesFechaAlta_Enabled;
         AssignProp("", false, edtWalletBalancesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtWalletBalancesId_Enabled = defedtWalletBalancesId_Enabled;
         AssignProp("", false, edtWalletBalancesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletBalancesId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void StartGridControl88( )
      {
         Gridlevel_balancesContainer.AddObjectProperty("GridName", "Gridlevel_balances");
         Gridlevel_balancesContainer.AddObjectProperty("Header", subGridlevel_balances_Header);
         Gridlevel_balancesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_balancesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_balancesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_balancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_balancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A640WalletBalancesId), 18, 0, ".", ""))));
         Gridlevel_balancesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesId_Enabled), 5, 0, ".", "")));
         Gridlevel_balancesContainer.AddColumnProperties(Gridlevel_balancesColumn);
         Gridlevel_balancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_balancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A641WalletBalancesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
         Gridlevel_balancesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesFechaAlta_Enabled), 5, 0, ".", "")));
         Gridlevel_balancesContainer.AddColumnProperties(Gridlevel_balancesColumn);
         Gridlevel_balancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_balancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A642WalletBalancesUsrAlta), 10, 0, ".", ""))));
         Gridlevel_balancesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesUsrAlta_Enabled), 5, 0, ".", "")));
         Gridlevel_balancesContainer.AddColumnProperties(Gridlevel_balancesColumn);
         Gridlevel_balancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_balancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A643WalletBalancesTipoMov)));
         Gridlevel_balancesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesTipoMov.Enabled), 5, 0, ".", "")));
         Gridlevel_balancesContainer.AddColumnProperties(Gridlevel_balancesColumn);
         Gridlevel_balancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_balancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A644WalletBalancesImporte, 18, 2, ".", ""))));
         Gridlevel_balancesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletBalancesImporte_Enabled), 5, 0, ".", "")));
         Gridlevel_balancesContainer.AddColumnProperties(Gridlevel_balancesColumn);
         Gridlevel_balancesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_balancesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A645WalletBalancesEstadoOPE)));
         Gridlevel_balancesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWalletBalancesEstadoOPE.Enabled), 5, 0, ".", "")));
         Gridlevel_balancesContainer.AddColumnProperties(Gridlevel_balancesColumn);
         Gridlevel_balancesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Selectedindex), 4, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Allowselection), 1, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Allowhovering), 1, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_balancesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_balances_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtWalletId_Internalname = "WALLETID";
         edtTipoCuentaId_Internalname = "TIPOCUENTAID";
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO";
         cmbWalletEstado_Internalname = "WALLETESTADO";
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD";
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA";
         edtWalletNombre_Internalname = "WALLETNOMBRE";
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE";
         dynMonedaId_Internalname = "MONEDAID";
         edtWalletTotalDebito_Internalname = "WALLETTOTALDEBITO";
         edtWalletTotalCredito_Internalname = "WALLETTOTALCREDITO";
         edtWalletSaldo_Internalname = "WALLETSALDO";
         edtWalletSaldoAlDia_Internalname = "WALLETSALDOALDIA";
         edtWalletSolicitudesPendientes_Internalname = "WALLETSOLICITUDESPENDIENTES";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_balances_title_Internalname = "TABLEVEL_BALANCES_TITLE";
         edtWalletBalancesId_Internalname = "WALLETBALANCESID";
         edtWalletBalancesFechaAlta_Internalname = "WALLETBALANCESFECHAALTA";
         edtWalletBalancesUsrAlta_Internalname = "WALLETBALANCESUSRALTA";
         cmbWalletBalancesTipoMov_Internalname = "WALLETBALANCESTIPOMOV";
         edtWalletBalancesImporte_Internalname = "WALLETBALANCESIMPORTE";
         cmbWalletBalancesEstadoOPE_Internalname = "WALLETBALANCESESTADOOPE";
         divTableleaflevel_balances_Internalname = "TABLELEAFLEVEL_BALANCES";
         divTabtablelevel_balances_Internalname = "TABTABLELEVEL_BALANCES";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_483_Internalname = "PROMPT_483";
         imgprompt_639_Internalname = "PROMPT_639";
         subGridlevel_balances_Internalname = "GRIDLEVEL_BALANCES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_balances_Allowcollapsing = 0;
         subGridlevel_balances_Allowselection = 0;
         subGridlevel_balances_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Saldos y Cuentas", "");
         cmbWalletBalancesEstadoOPE_Jsonclick = "";
         edtWalletBalancesImporte_Jsonclick = "";
         cmbWalletBalancesTipoMov_Jsonclick = "";
         edtWalletBalancesUsrAlta_Jsonclick = "";
         edtWalletBalancesFechaAlta_Jsonclick = "";
         edtWalletBalancesId_Jsonclick = "";
         subGridlevel_balances_Class = "WorkWith";
         subGridlevel_balances_Backcolorstyle = 0;
         cmbWalletBalancesEstadoOPE.Enabled = 0;
         edtWalletBalancesImporte_Enabled = 0;
         cmbWalletBalancesTipoMov.Enabled = 0;
         edtWalletBalancesUsrAlta_Enabled = 0;
         edtWalletBalancesFechaAlta_Enabled = 0;
         edtWalletBalancesId_Enabled = 0;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtWalletSolicitudesPendientes_Jsonclick = "";
         edtWalletSolicitudesPendientes_Enabled = 0;
         edtWalletSaldoAlDia_Jsonclick = "";
         edtWalletSaldoAlDia_Enabled = 0;
         edtWalletSaldo_Jsonclick = "";
         edtWalletSaldo_Enabled = 0;
         edtWalletTotalCredito_Jsonclick = "";
         edtWalletTotalCredito_Enabled = 0;
         edtWalletTotalDebito_Jsonclick = "";
         edtWalletTotalDebito_Enabled = 0;
         dynMonedaId_Jsonclick = "";
         dynMonedaId.Enabled = 1;
         edtTipoCuentaNombre_Jsonclick = "";
         edtTipoCuentaNombre_Enabled = 0;
         edtWalletNombre_Jsonclick = "";
         edtWalletNombre_Enabled = 0;
         imgprompt_639_Visible = 1;
         imgprompt_639_Link = "";
         edtWalletCodRefencia_Jsonclick = "";
         edtWalletCodRefencia_Enabled = 1;
         cmbWalletTipoEntidad_Jsonclick = "";
         cmbWalletTipoEntidad.Enabled = 1;
         cmbWalletEstado_Jsonclick = "";
         cmbWalletEstado.Enabled = 1;
         cmbTipoCuentaConcepto_Jsonclick = "";
         cmbTipoCuentaConcepto.Enabled = 0;
         imgprompt_483_Visible = 1;
         imgprompt_483_Link = "";
         edtTipoCuentaId_Jsonclick = "";
         edtTipoCuentaId_Enabled = 1;
         edtWalletId_Jsonclick = "";
         edtWalletId_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 2;
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

      protected void GXDLAMONEDAID291( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMONEDAID_data291( ) ;
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

      protected void GXAMONEDAID_html291( )
      {
         short gxdynajaxvalue;
         GXDLAMONEDAID_data291( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMonedaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAMONEDAID_data291( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T002927 */
         pr_default.execute(25);
         while ( (pr_default.getStatus(25) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T002927_A118MonedaId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T002927_A119MonedaISOSimbolo[0]));
            pr_default.readNext(25);
         }
         pr_default.close(25);
      }

      protected void GX5ASAWALLETTOTALCREDITO2992( long A637WalletId )
      {
         GXt_decimal2 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
         A647WalletTotalCredito = GXt_decimal2;
         AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX6ASAWALLETTOTALDEBITO2992( long A637WalletId )
      {
         GXt_decimal2 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
         A646WalletTotalDebito = GXt_decimal2;
         AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX7ASAWALLETNOMBRE2992( string A638WalletTipoEntidad ,
                                             string A639WalletCodRefencia )
      {
         GXt_char3 = A715WalletNombre;
         new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
         A715WalletNombre = GXt_char3;
         AssignAttri("", false, "A715WalletNombre", A715WalletNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A715WalletNombre))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX8ASAWALLETSOLICITUDESPENDIENTES2992( string A639WalletCodRefencia )
      {
         GXt_decimal2 = A1007WalletSolicitudesPendientes;
         new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
         A1007WalletSolicitudesPendientes = GXt_decimal2;
         AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1007WalletSolicitudesPendientes, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_balances_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8893( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2993( ) ;
            standaloneModal2993( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2993( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8893( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_balancesContainer)) ;
         /* End function gxnrGridlevel_balances_newrow */
      }

      protected void init_web_controls( )
      {
         cmbTipoCuentaConcepto.Name = "TIPOCUENTACONCEPTO";
         cmbTipoCuentaConcepto.WebTags = "";
         cmbTipoCuentaConcepto.addItem("SAL", context.GetMessage( "Saldo por Cuentas", ""), 0);
         cmbTipoCuentaConcepto.addItem("COS", context.GetMessage( "Usada En Centro Costo", ""), 0);
         cmbTipoCuentaConcepto.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
            A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
            AssignAttri("", false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
         }
         cmbWalletEstado.Name = "WALLETESTADO";
         cmbWalletEstado.WebTags = "";
         cmbWalletEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbWalletEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbWalletEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbWalletEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbWalletEstado.ItemCount > 0 )
         {
            A665WalletEstado = cmbWalletEstado.getValidValue(A665WalletEstado);
            AssignAttri("", false, "A665WalletEstado", A665WalletEstado);
         }
         cmbWalletTipoEntidad.Name = "WALLETTIPOENTIDAD";
         cmbWalletTipoEntidad.WebTags = "";
         cmbWalletTipoEntidad.addItem("CLI", context.GetMessage( "Clientes", ""), 0);
         cmbWalletTipoEntidad.addItem("COM", context.GetMessage( "Comercios", ""), 0);
         cmbWalletTipoEntidad.addItem("PRO", context.GetMessage( "Profesionales", ""), 0);
         cmbWalletTipoEntidad.addItem("EMP", context.GetMessage( "Empleados", ""), 0);
         cmbWalletTipoEntidad.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbWalletTipoEntidad.ItemCount > 0 )
         {
            A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
            AssignAttri("", false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
         }
         dynMonedaId.Name = "MONEDAID";
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor T002928 */
         pr_default.execute(26);
         while ( (pr_default.getStatus(26) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T002928_A118MonedaId[0]), 4, 0)), T002928_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(26);
         }
         pr_default.close(26);
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
         GXCCtl = "WALLETBALANCESTIPOMOV_" + sGXsfl_88_idx;
         cmbWalletBalancesTipoMov.Name = GXCCtl;
         cmbWalletBalancesTipoMov.WebTags = "";
         cmbWalletBalancesTipoMov.addItem("DEB", context.GetMessage( "Debitado", ""), 0);
         cmbWalletBalancesTipoMov.addItem("CRE", context.GetMessage( "Acreditado", ""), 0);
         if ( cmbWalletBalancesTipoMov.ItemCount > 0 )
         {
            A643WalletBalancesTipoMov = cmbWalletBalancesTipoMov.getValidValue(A643WalletBalancesTipoMov);
         }
         GXCCtl = "WALLETBALANCESESTADOOPE_" + sGXsfl_88_idx;
         cmbWalletBalancesEstadoOPE.Name = GXCCtl;
         cmbWalletBalancesEstadoOPE.WebTags = "";
         cmbWalletBalancesEstadoOPE.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbWalletBalancesEstadoOPE.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbWalletBalancesEstadoOPE.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbWalletBalancesEstadoOPE.ItemCount > 0 )
         {
            A645WalletBalancesEstadoOPE = cmbWalletBalancesEstadoOPE.getValidValue(A645WalletBalancesEstadoOPE);
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

      public void Valid_Walletid( )
      {
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         GXt_decimal2 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
         A647WalletTotalCredito = GXt_decimal2;
         GXt_decimal2 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
         A646WalletTotalDebito = GXt_decimal2;
         A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, ".", "")));
         AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, ".", "")));
         AssignAttri("", false, "A648WalletSaldo", StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, ".", "")));
      }

      public void Valid_Tipocuentaid( )
      {
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         A636TipoCuentaConcepto = cmbTipoCuentaConcepto.CurrentValue;
         cmbTipoCuentaConcepto.CurrentValue = A636TipoCuentaConcepto;
         /* Using cursor T002918 */
         pr_default.execute(16, new Object[] {A483TipoCuentaId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
            AnyError = 1;
            GX_FocusControl = edtTipoCuentaId_Internalname;
         }
         A636TipoCuentaConcepto = T002918_A636TipoCuentaConcepto[0];
         cmbTipoCuentaConcepto.CurrentValue = A636TipoCuentaConcepto;
         A484TipoCuentaNombre = T002918_A484TipoCuentaNombre[0];
         pr_default.close(16);
         dynload_actions( ) ;
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
            A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
            cmbTipoCuentaConcepto.CurrentValue = A636TipoCuentaConcepto;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A636TipoCuentaConcepto", StringUtil.RTrim( A636TipoCuentaConcepto));
         cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
         AssignProp("", false, cmbTipoCuentaConcepto_Internalname, "Values", cmbTipoCuentaConcepto.ToJavascriptSource(), true);
         AssignAttri("", false, "A484TipoCuentaNombre", StringUtil.RTrim( A484TipoCuentaNombre));
      }

      public void Valid_Walletcodrefencia( )
      {
         A638WalletTipoEntidad = cmbWalletTipoEntidad.CurrentValue;
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         /* Using cursor T002929 */
         pr_default.execute(27, new Object[] {A639WalletCodRefencia, A637WalletId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Código de Refencia", "")}), "DuplicateCandidateKey", 1, "WALLETCODREFENCIA");
            AnyError = 1;
            GX_FocusControl = edtWalletCodRefencia_Internalname;
         }
         pr_default.close(27);
         GXt_char3 = A715WalletNombre;
         new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
         A715WalletNombre = GXt_char3;
         GXt_decimal2 = A1007WalletSolicitudesPendientes;
         new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
         A1007WalletSolicitudesPendientes = GXt_decimal2;
         A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A715WalletNombre", StringUtil.RTrim( A715WalletNombre));
         AssignAttri("", false, "A1007WalletSolicitudesPendientes", StringUtil.LTrim( StringUtil.NToC( A1007WalletSolicitudesPendientes, 18, 2, ".", "")));
         AssignAttri("", false, "A1008WalletSaldoAlDia", StringUtil.LTrim( StringUtil.NToC( A1008WalletSaldoAlDia, 18, 2, ".", "")));
      }

      public void Valid_Monedaid( )
      {
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         /* Using cursor T002919 */
         pr_default.execute(17, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
               GX_FocusControl = dynMonedaId_Internalname;
            }
         }
         A119MonedaISOSimbolo = T002919_A119MonedaISOSimbolo[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A119MonedaISOSimbolo", StringUtil.RTrim( A119MonedaISOSimbolo));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13Insert_TipoCuentaId',fld:'vINSERT_TIPOCUENTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14Insert_MonedaId',fld:'vINSERT_MONEDAID',pic:'ZZZ9',type:'int'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12292',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETID","{handler:'Valid_Walletid',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A647WalletTotalCredito',fld:'WALLETTOTALCREDITO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A646WalletTotalDebito',fld:'WALLETTOTALDEBITO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETID",",oparms:[{av:'A647WalletTotalCredito',fld:'WALLETTOTALCREDITO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A646WalletTotalDebito',fld:'WALLETTOTALDEBITO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_TIPOCUENTAID","{handler:'Valid_Tipocuentaid',iparms:[{av:'A483TipoCuentaId',fld:'TIPOCUENTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbTipoCuentaConcepto'},{av:'A636TipoCuentaConcepto',fld:'TIPOCUENTACONCEPTO',pic:'',type:'char'},{av:'A484TipoCuentaNombre',fld:'TIPOCUENTANOMBRE',pic:'',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_TIPOCUENTAID",",oparms:[{av:'cmbTipoCuentaConcepto'},{av:'A636TipoCuentaConcepto',fld:'TIPOCUENTACONCEPTO',pic:'',type:'char'},{av:'A484TipoCuentaNombre',fld:'TIPOCUENTANOMBRE',pic:'',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETESTADO","{handler:'Valid_Walletestado',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETESTADO",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETTIPOENTIDAD","{handler:'Valid_Wallettipoentidad',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETTIPOENTIDAD",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETCODREFENCIA","{handler:'Valid_Walletcodrefencia',iparms:[{av:'A639WalletCodRefencia',fld:'WALLETCODREFENCIA',pic:'',type:'char'},{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbWalletTipoEntidad'},{av:'A638WalletTipoEntidad',fld:'WALLETTIPOENTIDAD',pic:'',type:'char'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A1007WalletSolicitudesPendientes',fld:'WALLETSOLICITUDESPENDIENTES',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',type:'char'},{av:'A1008WalletSaldoAlDia',fld:'WALLETSALDOALDIA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETCODREFENCIA",",oparms:[{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',type:'char'},{av:'A1007WalletSolicitudesPendientes',fld:'WALLETSOLICITUDESPENDIENTES',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A1008WalletSaldoAlDia',fld:'WALLETSALDOALDIA',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_MONEDAID",",oparms:[{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETTOTALDEBITO","{handler:'Valid_Wallettotaldebito',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETTOTALDEBITO",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETTOTALCREDITO","{handler:'Valid_Wallettotalcredito',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETTOTALCREDITO",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETSALDO","{handler:'Valid_Walletsaldo',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETSALDO",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETSOLICITUDESPENDIENTES","{handler:'Valid_Walletsolicitudespendientes',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETSOLICITUDESPENDIENTES",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_WALLETBALANCESID","{handler:'Valid_Walletbalancesid',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_WALLETBALANCESID",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("NULL","{handler:'Valid_Walletbalancesestadoope',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
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
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z638WalletTipoEntidad = "";
         Z639WalletCodRefencia = "";
         Z665WalletEstado = "";
         Z641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         Z643WalletBalancesTipoMov = "";
         Z1009WalletBalancesObs = "";
         Z1011WalletBalancesUrl = "";
         Z645WalletBalancesEstadoOPE = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A638WalletTipoEntidad = "";
         A639WalletCodRefencia = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A636TipoCuentaConcepto = "";
         A665WalletEstado = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         imgprompt_483_gximage = "";
         sImgUrl = "";
         imgprompt_639_gximage = "";
         A715WalletNombre = "";
         A484TipoCuentaNombre = "";
         lblTablevel_balances_title_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_balancesContainer = new GXWebGrid( context);
         sMode93 = "";
         sStyleString = "";
         A119MonedaISOSimbolo = "";
         AV18Pgmname = "";
         A1009WalletBalancesObs = "";
         A1011WalletBalancesUrl = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode92 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A643WalletBalancesTipoMov = "";
         A645WalletBalancesEstadoOPE = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z636TipoCuentaConcepto = "";
         Z484TipoCuentaNombre = "";
         Z119MonedaISOSimbolo = "";
         T00297_A119MonedaISOSimbolo = new string[] {""} ;
         T00296_A636TipoCuentaConcepto = new string[] {""} ;
         T00296_A484TipoCuentaNombre = new string[] {""} ;
         T00298_A637WalletId = new long[1] ;
         T00298_A636TipoCuentaConcepto = new string[] {""} ;
         T00298_A484TipoCuentaNombre = new string[] {""} ;
         T00298_A638WalletTipoEntidad = new string[] {""} ;
         T00298_A639WalletCodRefencia = new string[] {""} ;
         T00298_A119MonedaISOSimbolo = new string[] {""} ;
         T00298_A665WalletEstado = new string[] {""} ;
         T00298_A483TipoCuentaId = new long[1] ;
         T00298_A118MonedaId = new short[1] ;
         T00298_n118MonedaId = new bool[] {false} ;
         T00299_A639WalletCodRefencia = new string[] {""} ;
         T002910_A636TipoCuentaConcepto = new string[] {""} ;
         T002910_A484TipoCuentaNombre = new string[] {""} ;
         T002911_A119MonedaISOSimbolo = new string[] {""} ;
         T002912_A637WalletId = new long[1] ;
         T00295_A637WalletId = new long[1] ;
         T00295_A638WalletTipoEntidad = new string[] {""} ;
         T00295_A639WalletCodRefencia = new string[] {""} ;
         T00295_A665WalletEstado = new string[] {""} ;
         T00295_A483TipoCuentaId = new long[1] ;
         T00295_A118MonedaId = new short[1] ;
         T00295_n118MonedaId = new bool[] {false} ;
         T002913_A637WalletId = new long[1] ;
         T002914_A637WalletId = new long[1] ;
         T00294_A637WalletId = new long[1] ;
         T00294_A638WalletTipoEntidad = new string[] {""} ;
         T00294_A639WalletCodRefencia = new string[] {""} ;
         T00294_A665WalletEstado = new string[] {""} ;
         T00294_A483TipoCuentaId = new long[1] ;
         T00294_A118MonedaId = new short[1] ;
         T00294_n118MonedaId = new bool[] {false} ;
         T002915_A637WalletId = new long[1] ;
         T002918_A636TipoCuentaConcepto = new string[] {""} ;
         T002918_A484TipoCuentaNombre = new string[] {""} ;
         T002919_A119MonedaISOSimbolo = new string[] {""} ;
         T002920_A637WalletId = new long[1] ;
         T002921_A637WalletId = new long[1] ;
         T002921_A640WalletBalancesId = new long[1] ;
         T002921_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002921_A642WalletBalancesUsrAlta = new long[1] ;
         T002921_A643WalletBalancesTipoMov = new string[] {""} ;
         T002921_A644WalletBalancesImporte = new decimal[1] ;
         T002921_A1009WalletBalancesObs = new string[] {""} ;
         T002921_n1009WalletBalancesObs = new bool[] {false} ;
         T002921_A1010WalletBalancesConcepto = new short[1] ;
         T002921_n1010WalletBalancesConcepto = new bool[] {false} ;
         T002921_A1011WalletBalancesUrl = new string[] {""} ;
         T002921_n1011WalletBalancesUrl = new bool[] {false} ;
         T002921_A645WalletBalancesEstadoOPE = new string[] {""} ;
         T002921_A1012WalletBalanceLiquidacion = new long[1] ;
         T002921_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         T002922_A637WalletId = new long[1] ;
         T002922_A640WalletBalancesId = new long[1] ;
         T00293_A637WalletId = new long[1] ;
         T00293_A640WalletBalancesId = new long[1] ;
         T00293_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00293_A642WalletBalancesUsrAlta = new long[1] ;
         T00293_A643WalletBalancesTipoMov = new string[] {""} ;
         T00293_A644WalletBalancesImporte = new decimal[1] ;
         T00293_A1009WalletBalancesObs = new string[] {""} ;
         T00293_n1009WalletBalancesObs = new bool[] {false} ;
         T00293_A1010WalletBalancesConcepto = new short[1] ;
         T00293_n1010WalletBalancesConcepto = new bool[] {false} ;
         T00293_A1011WalletBalancesUrl = new string[] {""} ;
         T00293_n1011WalletBalancesUrl = new bool[] {false} ;
         T00293_A645WalletBalancesEstadoOPE = new string[] {""} ;
         T00293_A1012WalletBalanceLiquidacion = new long[1] ;
         T00293_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         T00292_A637WalletId = new long[1] ;
         T00292_A640WalletBalancesId = new long[1] ;
         T00292_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00292_A642WalletBalancesUsrAlta = new long[1] ;
         T00292_A643WalletBalancesTipoMov = new string[] {""} ;
         T00292_A644WalletBalancesImporte = new decimal[1] ;
         T00292_A1009WalletBalancesObs = new string[] {""} ;
         T00292_n1009WalletBalancesObs = new bool[] {false} ;
         T00292_A1010WalletBalancesConcepto = new short[1] ;
         T00292_n1010WalletBalancesConcepto = new bool[] {false} ;
         T00292_A1011WalletBalancesUrl = new string[] {""} ;
         T00292_n1011WalletBalancesUrl = new bool[] {false} ;
         T00292_A645WalletBalancesEstadoOPE = new string[] {""} ;
         T00292_A1012WalletBalanceLiquidacion = new long[1] ;
         T00292_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         T002926_A637WalletId = new long[1] ;
         T002926_A640WalletBalancesId = new long[1] ;
         Gridlevel_balancesRow = new GXWebRow();
         subGridlevel_balances_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_balancesColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T002927_A118MonedaId = new short[1] ;
         T002927_n118MonedaId = new bool[] {false} ;
         T002927_A119MonedaISOSimbolo = new string[] {""} ;
         T002928_A118MonedaId = new short[1] ;
         T002928_n118MonedaId = new bool[] {false} ;
         T002928_A119MonedaISOSimbolo = new string[] {""} ;
         T002929_A639WalletCodRefencia = new string[] {""} ;
         GXt_char3 = "";
         Z715WalletNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wallet__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wallet__default(),
            new Object[][] {
                new Object[] {
               T00292_A637WalletId, T00292_A640WalletBalancesId, T00292_A641WalletBalancesFechaAlta, T00292_A642WalletBalancesUsrAlta, T00292_A643WalletBalancesTipoMov, T00292_A644WalletBalancesImporte, T00292_A1009WalletBalancesObs, T00292_n1009WalletBalancesObs, T00292_A1010WalletBalancesConcepto, T00292_n1010WalletBalancesConcepto,
               T00292_A1011WalletBalancesUrl, T00292_n1011WalletBalancesUrl, T00292_A645WalletBalancesEstadoOPE, T00292_A1012WalletBalanceLiquidacion, T00292_n1012WalletBalanceLiquidacion
               }
               , new Object[] {
               T00293_A637WalletId, T00293_A640WalletBalancesId, T00293_A641WalletBalancesFechaAlta, T00293_A642WalletBalancesUsrAlta, T00293_A643WalletBalancesTipoMov, T00293_A644WalletBalancesImporte, T00293_A1009WalletBalancesObs, T00293_n1009WalletBalancesObs, T00293_A1010WalletBalancesConcepto, T00293_n1010WalletBalancesConcepto,
               T00293_A1011WalletBalancesUrl, T00293_n1011WalletBalancesUrl, T00293_A645WalletBalancesEstadoOPE, T00293_A1012WalletBalanceLiquidacion, T00293_n1012WalletBalanceLiquidacion
               }
               , new Object[] {
               T00294_A637WalletId, T00294_A638WalletTipoEntidad, T00294_A639WalletCodRefencia, T00294_A665WalletEstado, T00294_A483TipoCuentaId, T00294_A118MonedaId, T00294_n118MonedaId
               }
               , new Object[] {
               T00295_A637WalletId, T00295_A638WalletTipoEntidad, T00295_A639WalletCodRefencia, T00295_A665WalletEstado, T00295_A483TipoCuentaId, T00295_A118MonedaId, T00295_n118MonedaId
               }
               , new Object[] {
               T00296_A636TipoCuentaConcepto, T00296_A484TipoCuentaNombre
               }
               , new Object[] {
               T00297_A119MonedaISOSimbolo
               }
               , new Object[] {
               T00298_A637WalletId, T00298_A636TipoCuentaConcepto, T00298_A484TipoCuentaNombre, T00298_A638WalletTipoEntidad, T00298_A639WalletCodRefencia, T00298_A119MonedaISOSimbolo, T00298_A665WalletEstado, T00298_A483TipoCuentaId, T00298_A118MonedaId, T00298_n118MonedaId
               }
               , new Object[] {
               T00299_A639WalletCodRefencia
               }
               , new Object[] {
               T002910_A636TipoCuentaConcepto, T002910_A484TipoCuentaNombre
               }
               , new Object[] {
               T002911_A119MonedaISOSimbolo
               }
               , new Object[] {
               T002912_A637WalletId
               }
               , new Object[] {
               T002913_A637WalletId
               }
               , new Object[] {
               T002914_A637WalletId
               }
               , new Object[] {
               T002915_A637WalletId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002918_A636TipoCuentaConcepto, T002918_A484TipoCuentaNombre
               }
               , new Object[] {
               T002919_A119MonedaISOSimbolo
               }
               , new Object[] {
               T002920_A637WalletId
               }
               , new Object[] {
               T002921_A637WalletId, T002921_A640WalletBalancesId, T002921_A641WalletBalancesFechaAlta, T002921_A642WalletBalancesUsrAlta, T002921_A643WalletBalancesTipoMov, T002921_A644WalletBalancesImporte, T002921_A1009WalletBalancesObs, T002921_n1009WalletBalancesObs, T002921_A1010WalletBalancesConcepto, T002921_n1010WalletBalancesConcepto,
               T002921_A1011WalletBalancesUrl, T002921_n1011WalletBalancesUrl, T002921_A645WalletBalancesEstadoOPE, T002921_A1012WalletBalanceLiquidacion, T002921_n1012WalletBalanceLiquidacion
               }
               , new Object[] {
               T002922_A637WalletId, T002922_A640WalletBalancesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002926_A637WalletId, T002926_A640WalletBalancesId
               }
               , new Object[] {
               T002927_A118MonedaId, T002927_A119MonedaISOSimbolo
               }
               , new Object[] {
               T002928_A118MonedaId, T002928_A119MonedaISOSimbolo
               }
               , new Object[] {
               T002929_A639WalletCodRefencia
               }
            }
         );
         AV18Pgmname = "Wallet";
      }

      private short Z118MonedaId ;
      private short N118MonedaId ;
      private short Z1010WalletBalancesConcepto ;
      private short nRcdDeleted_93 ;
      private short nRcdExists_93 ;
      private short nIsMod_93 ;
      private short GxWebError ;
      private short A118MonedaId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount93 ;
      private short RcdFound93 ;
      private short nBlankRcdUsr93 ;
      private short AV14Insert_MonedaId ;
      private short A1010WalletBalancesConcepto ;
      private short RcdFound92 ;
      private short Gx_BScreen ;
      private short nIsDirty_93 ;
      private short subGridlevel_balances_Backcolorstyle ;
      private short subGridlevel_balances_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_balances_Allowselection ;
      private short subGridlevel_balances_Allowhovering ;
      private short subGridlevel_balances_Allowcollapsing ;
      private short subGridlevel_balances_Collapsed ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtWalletId_Enabled ;
      private int edtTipoCuentaId_Enabled ;
      private int imgprompt_483_Visible ;
      private int edtWalletCodRefencia_Enabled ;
      private int imgprompt_639_Visible ;
      private int edtWalletNombre_Enabled ;
      private int edtTipoCuentaNombre_Enabled ;
      private int edtWalletTotalDebito_Enabled ;
      private int edtWalletTotalCredito_Enabled ;
      private int edtWalletSaldo_Enabled ;
      private int edtWalletSaldoAlDia_Enabled ;
      private int edtWalletSolicitudesPendientes_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtWalletBalancesId_Enabled ;
      private int edtWalletBalancesFechaAlta_Enabled ;
      private int edtWalletBalancesUsrAlta_Enabled ;
      private int edtWalletBalancesImporte_Enabled ;
      private int fRowAdded ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int AV19GXV1 ;
      private int subGridlevel_balances_Backcolor ;
      private int subGridlevel_balances_Allbackcolor ;
      private int defcmbWalletBalancesEstadoOPE_Enabled ;
      private int defedtWalletBalancesImporte_Enabled ;
      private int defcmbWalletBalancesTipoMov_Enabled ;
      private int defedtWalletBalancesUsrAlta_Enabled ;
      private int defedtWalletBalancesFechaAlta_Enabled ;
      private int defedtWalletBalancesId_Enabled ;
      private int idxLst ;
      private int subGridlevel_balances_Selectedindex ;
      private int subGridlevel_balances_Selectioncolor ;
      private int subGridlevel_balances_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7WalletId ;
      private long Z637WalletId ;
      private long Z483TipoCuentaId ;
      private long N483TipoCuentaId ;
      private long Z640WalletBalancesId ;
      private long Z642WalletBalancesUsrAlta ;
      private long Z1012WalletBalanceLiquidacion ;
      private long A637WalletId ;
      private long A483TipoCuentaId ;
      private long AV7WalletId ;
      private long AV13Insert_TipoCuentaId ;
      private long A1012WalletBalanceLiquidacion ;
      private long GRIDLEVEL_BALANCES_nFirstRecordOnPage ;
      private long A640WalletBalancesId ;
      private long A642WalletBalancesUsrAlta ;
      private decimal Z644WalletBalancesImporte ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal A648WalletSaldo ;
      private decimal A1008WalletSaldoAlDia ;
      private decimal A1007WalletSolicitudesPendientes ;
      private decimal A644WalletBalancesImporte ;
      private decimal Z647WalletTotalCredito ;
      private decimal Z646WalletTotalDebito ;
      private decimal Z648WalletSaldo ;
      private decimal GXt_decimal2 ;
      private decimal Z1007WalletSolicitudesPendientes ;
      private decimal Z1008WalletSaldoAlDia ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z638WalletTipoEntidad ;
      private string Z639WalletCodRefencia ;
      private string Z665WalletEstado ;
      private string Z643WalletBalancesTipoMov ;
      private string Z645WalletBalancesEstadoOPE ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A638WalletTipoEntidad ;
      private string A639WalletCodRefencia ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipoCuentaId_Internalname ;
      private string sGXsfl_88_idx="0001" ;
      private string A636TipoCuentaConcepto ;
      private string cmbTipoCuentaConcepto_Internalname ;
      private string A665WalletEstado ;
      private string cmbWalletEstado_Internalname ;
      private string cmbWalletTipoEntidad_Internalname ;
      private string dynMonedaId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string edtWalletId_Internalname ;
      private string TempTags ;
      private string edtWalletId_Jsonclick ;
      private string edtTipoCuentaId_Jsonclick ;
      private string imgprompt_483_gximage ;
      private string sImgUrl ;
      private string imgprompt_483_Internalname ;
      private string imgprompt_483_Link ;
      private string cmbTipoCuentaConcepto_Jsonclick ;
      private string cmbWalletEstado_Jsonclick ;
      private string cmbWalletTipoEntidad_Jsonclick ;
      private string edtWalletCodRefencia_Internalname ;
      private string edtWalletCodRefencia_Jsonclick ;
      private string imgprompt_639_gximage ;
      private string imgprompt_639_Internalname ;
      private string imgprompt_639_Link ;
      private string edtWalletNombre_Internalname ;
      private string A715WalletNombre ;
      private string edtWalletNombre_Jsonclick ;
      private string edtTipoCuentaNombre_Internalname ;
      private string A484TipoCuentaNombre ;
      private string edtTipoCuentaNombre_Jsonclick ;
      private string dynMonedaId_Jsonclick ;
      private string edtWalletTotalDebito_Internalname ;
      private string edtWalletTotalDebito_Jsonclick ;
      private string edtWalletTotalCredito_Internalname ;
      private string edtWalletTotalCredito_Jsonclick ;
      private string edtWalletSaldo_Internalname ;
      private string edtWalletSaldo_Jsonclick ;
      private string edtWalletSaldoAlDia_Internalname ;
      private string edtWalletSaldoAlDia_Jsonclick ;
      private string edtWalletSolicitudesPendientes_Internalname ;
      private string edtWalletSolicitudesPendientes_Jsonclick ;
      private string lblTablevel_balances_title_Internalname ;
      private string lblTablevel_balances_title_Jsonclick ;
      private string divTabtablelevel_balances_Internalname ;
      private string divTableleaflevel_balances_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode93 ;
      private string edtWalletBalancesId_Internalname ;
      private string edtWalletBalancesFechaAlta_Internalname ;
      private string edtWalletBalancesUsrAlta_Internalname ;
      private string cmbWalletBalancesTipoMov_Internalname ;
      private string edtWalletBalancesImporte_Internalname ;
      private string cmbWalletBalancesEstadoOPE_Internalname ;
      private string sStyleString ;
      private string subGridlevel_balances_Internalname ;
      private string A119MonedaISOSimbolo ;
      private string AV18Pgmname ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string hsh ;
      private string sMode92 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A643WalletBalancesTipoMov ;
      private string A645WalletBalancesEstadoOPE ;
      private string GXEncryptionTmp ;
      private string Z636TipoCuentaConcepto ;
      private string Z484TipoCuentaNombre ;
      private string Z119MonedaISOSimbolo ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridlevel_balances_Class ;
      private string subGridlevel_balances_Linesclass ;
      private string ROClassString ;
      private string edtWalletBalancesId_Jsonclick ;
      private string edtWalletBalancesFechaAlta_Jsonclick ;
      private string edtWalletBalancesUsrAlta_Jsonclick ;
      private string GXCCtl ;
      private string cmbWalletBalancesTipoMov_Jsonclick ;
      private string edtWalletBalancesImporte_Jsonclick ;
      private string cmbWalletBalancesEstadoOPE_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_balances_Header ;
      private string gxwrpcisep ;
      private string GXt_char3 ;
      private string Z715WalletNombre ;
      private DateTime Z641WalletBalancesFechaAlta ;
      private DateTime A641WalletBalancesFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n118MonedaId ;
      private bool wbErr ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool n1009WalletBalancesObs ;
      private bool n1010WalletBalancesConcepto ;
      private bool n1011WalletBalancesUrl ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string Z1009WalletBalancesObs ;
      private string Z1011WalletBalancesUrl ;
      private string A1009WalletBalancesObs ;
      private string A1011WalletBalancesUrl ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_balancesContainer ;
      private GXWebRow Gridlevel_balancesRow ;
      private GXWebColumn Gridlevel_balancesColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTipoCuentaConcepto ;
      private GXCombobox cmbWalletEstado ;
      private GXCombobox cmbWalletTipoEntidad ;
      private GXCombobox dynMonedaId ;
      private GXCombobox cmbWalletBalancesTipoMov ;
      private GXCombobox cmbWalletBalancesEstadoOPE ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00297_A119MonedaISOSimbolo ;
      private string[] T00296_A636TipoCuentaConcepto ;
      private string[] T00296_A484TipoCuentaNombre ;
      private long[] T00298_A637WalletId ;
      private string[] T00298_A636TipoCuentaConcepto ;
      private string[] T00298_A484TipoCuentaNombre ;
      private string[] T00298_A638WalletTipoEntidad ;
      private string[] T00298_A639WalletCodRefencia ;
      private string[] T00298_A119MonedaISOSimbolo ;
      private string[] T00298_A665WalletEstado ;
      private long[] T00298_A483TipoCuentaId ;
      private short[] T00298_A118MonedaId ;
      private bool[] T00298_n118MonedaId ;
      private string[] T00299_A639WalletCodRefencia ;
      private string[] T002910_A636TipoCuentaConcepto ;
      private string[] T002910_A484TipoCuentaNombre ;
      private string[] T002911_A119MonedaISOSimbolo ;
      private long[] T002912_A637WalletId ;
      private long[] T00295_A637WalletId ;
      private string[] T00295_A638WalletTipoEntidad ;
      private string[] T00295_A639WalletCodRefencia ;
      private string[] T00295_A665WalletEstado ;
      private long[] T00295_A483TipoCuentaId ;
      private short[] T00295_A118MonedaId ;
      private bool[] T00295_n118MonedaId ;
      private long[] T002913_A637WalletId ;
      private long[] T002914_A637WalletId ;
      private long[] T00294_A637WalletId ;
      private string[] T00294_A638WalletTipoEntidad ;
      private string[] T00294_A639WalletCodRefencia ;
      private string[] T00294_A665WalletEstado ;
      private long[] T00294_A483TipoCuentaId ;
      private short[] T00294_A118MonedaId ;
      private bool[] T00294_n118MonedaId ;
      private long[] T002915_A637WalletId ;
      private string[] T002918_A636TipoCuentaConcepto ;
      private string[] T002918_A484TipoCuentaNombre ;
      private string[] T002919_A119MonedaISOSimbolo ;
      private long[] T002920_A637WalletId ;
      private long[] T002921_A637WalletId ;
      private long[] T002921_A640WalletBalancesId ;
      private DateTime[] T002921_A641WalletBalancesFechaAlta ;
      private long[] T002921_A642WalletBalancesUsrAlta ;
      private string[] T002921_A643WalletBalancesTipoMov ;
      private decimal[] T002921_A644WalletBalancesImporte ;
      private string[] T002921_A1009WalletBalancesObs ;
      private bool[] T002921_n1009WalletBalancesObs ;
      private short[] T002921_A1010WalletBalancesConcepto ;
      private bool[] T002921_n1010WalletBalancesConcepto ;
      private string[] T002921_A1011WalletBalancesUrl ;
      private bool[] T002921_n1011WalletBalancesUrl ;
      private string[] T002921_A645WalletBalancesEstadoOPE ;
      private long[] T002921_A1012WalletBalanceLiquidacion ;
      private bool[] T002921_n1012WalletBalanceLiquidacion ;
      private long[] T002922_A637WalletId ;
      private long[] T002922_A640WalletBalancesId ;
      private long[] T00293_A637WalletId ;
      private long[] T00293_A640WalletBalancesId ;
      private DateTime[] T00293_A641WalletBalancesFechaAlta ;
      private long[] T00293_A642WalletBalancesUsrAlta ;
      private string[] T00293_A643WalletBalancesTipoMov ;
      private decimal[] T00293_A644WalletBalancesImporte ;
      private string[] T00293_A1009WalletBalancesObs ;
      private bool[] T00293_n1009WalletBalancesObs ;
      private short[] T00293_A1010WalletBalancesConcepto ;
      private bool[] T00293_n1010WalletBalancesConcepto ;
      private string[] T00293_A1011WalletBalancesUrl ;
      private bool[] T00293_n1011WalletBalancesUrl ;
      private string[] T00293_A645WalletBalancesEstadoOPE ;
      private long[] T00293_A1012WalletBalanceLiquidacion ;
      private bool[] T00293_n1012WalletBalanceLiquidacion ;
      private long[] T00292_A637WalletId ;
      private long[] T00292_A640WalletBalancesId ;
      private DateTime[] T00292_A641WalletBalancesFechaAlta ;
      private long[] T00292_A642WalletBalancesUsrAlta ;
      private string[] T00292_A643WalletBalancesTipoMov ;
      private decimal[] T00292_A644WalletBalancesImporte ;
      private string[] T00292_A1009WalletBalancesObs ;
      private bool[] T00292_n1009WalletBalancesObs ;
      private short[] T00292_A1010WalletBalancesConcepto ;
      private bool[] T00292_n1010WalletBalancesConcepto ;
      private string[] T00292_A1011WalletBalancesUrl ;
      private bool[] T00292_n1011WalletBalancesUrl ;
      private string[] T00292_A645WalletBalancesEstadoOPE ;
      private long[] T00292_A1012WalletBalanceLiquidacion ;
      private bool[] T00292_n1012WalletBalanceLiquidacion ;
      private long[] T002926_A637WalletId ;
      private long[] T002926_A640WalletBalancesId ;
      private short[] T002927_A118MonedaId ;
      private bool[] T002927_n118MonedaId ;
      private string[] T002927_A119MonedaISOSimbolo ;
      private short[] T002928_A118MonedaId ;
      private bool[] T002928_n118MonedaId ;
      private string[] T002928_A119MonedaISOSimbolo ;
      private string[] T002929_A639WalletCodRefencia ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wallet__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wallet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00292;
        prmT00292 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmT00293;
        prmT00293 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmT00294;
        prmT00294 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT00295;
        prmT00295 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT00296;
        prmT00296 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0)
        };
        Object[] prmT00297;
        prmT00297 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00298;
        prmT00298 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT00299;
        prmT00299 = new Object[] {
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002910;
        prmT002910 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0)
        };
        Object[] prmT002911;
        prmT002911 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT002912;
        prmT002912 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002913;
        prmT002913 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002914;
        prmT002914 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002915;
        prmT002915 = new Object[] {
        new ParDef("@WalletTipoEntidad",GXType.NChar,3,0) ,
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletEstado",GXType.NChar,3,0) ,
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT002916;
        prmT002916 = new Object[] {
        new ParDef("@WalletTipoEntidad",GXType.NChar,3,0) ,
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletEstado",GXType.NChar,3,0) ,
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002917;
        prmT002917 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002918;
        prmT002918 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0)
        };
        Object[] prmT002919;
        prmT002919 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT002920;
        prmT002920 = new Object[] {
        };
        Object[] prmT002921;
        prmT002921 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmT002922;
        prmT002922 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmT002923;
        prmT002923 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@WalletBalancesUsrAlta",GXType.Decimal,10,0) ,
        new ParDef("@WalletBalancesTipoMov",GXType.NChar,3,0) ,
        new ParDef("@WalletBalancesImporte",GXType.Decimal,18,2) ,
        new ParDef("@WalletBalancesObs",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@WalletBalancesConcepto",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletBalancesUrl",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002924;
        prmT002924 = new Object[] {
        new ParDef("@WalletBalancesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@WalletBalancesUsrAlta",GXType.Decimal,10,0) ,
        new ParDef("@WalletBalancesTipoMov",GXType.NChar,3,0) ,
        new ParDef("@WalletBalancesImporte",GXType.Decimal,18,2) ,
        new ParDef("@WalletBalancesObs",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@WalletBalancesConcepto",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletBalancesUrl",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmT002925;
        prmT002925 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmT002926;
        prmT002926 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmT002927;
        prmT002927 = new Object[] {
        };
        Object[] prmT002928;
        prmT002928 = new Object[] {
        };
        Object[] prmT002929;
        prmT002929 = new Object[] {
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00292", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WITH (UPDLOCK) WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00292,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00293", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00293,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00294", "SELECT [WalletId], [WalletTipoEntidad], [WalletCodRefencia], [WalletEstado], [TipoCuentaId], [MonedaId] FROM [Wallet] WITH (UPDLOCK) WHERE [WalletId] = @WalletId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00294,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00295", "SELECT [WalletId], [WalletTipoEntidad], [WalletCodRefencia], [WalletEstado], [TipoCuentaId], [MonedaId] FROM [Wallet] WHERE [WalletId] = @WalletId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00295,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00296", "SELECT [TipoCuentaConcepto], [TipoCuentaNombre] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00296,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00297", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00297,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00298", "SELECT TM1.[WalletId], T2.[TipoCuentaConcepto], T2.[TipoCuentaNombre], TM1.[WalletTipoEntidad], TM1.[WalletCodRefencia], T3.[MonedaISOSimbolo], TM1.[WalletEstado], TM1.[TipoCuentaId], TM1.[MonedaId] FROM (([Wallet] TM1 INNER JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = TM1.[TipoCuentaId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = TM1.[MonedaId]) WHERE TM1.[WalletId] = @WalletId ORDER BY TM1.[WalletId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00298,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00299", "SELECT [WalletCodRefencia] FROM [Wallet] WHERE ([WalletCodRefencia] = @WalletCodRefencia) AND (Not ( [WalletId] = @WalletId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00299,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002910", "SELECT [TipoCuentaConcepto], [TipoCuentaNombre] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002911", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002912", "SELECT [WalletId] FROM [Wallet] WHERE [WalletId] = @WalletId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002912,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002913", "SELECT TOP 1 [WalletId] FROM [Wallet] WHERE ( [WalletId] > @WalletId) ORDER BY [WalletId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002913,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002914", "SELECT TOP 1 [WalletId] FROM [Wallet] WHERE ( [WalletId] < @WalletId) ORDER BY [WalletId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002914,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002915", "INSERT INTO [Wallet]([WalletTipoEntidad], [WalletCodRefencia], [WalletEstado], [TipoCuentaId], [MonedaId]) VALUES(@WalletTipoEntidad, @WalletCodRefencia, @WalletEstado, @TipoCuentaId, @MonedaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002915,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002916", "UPDATE [Wallet] SET [WalletTipoEntidad]=@WalletTipoEntidad, [WalletCodRefencia]=@WalletCodRefencia, [WalletEstado]=@WalletEstado, [TipoCuentaId]=@TipoCuentaId, [MonedaId]=@MonedaId  WHERE [WalletId] = @WalletId", GxErrorMask.GX_NOMASK,prmT002916)
           ,new CursorDef("T002917", "DELETE FROM [Wallet]  WHERE [WalletId] = @WalletId", GxErrorMask.GX_NOMASK,prmT002917)
           ,new CursorDef("T002918", "SELECT [TipoCuentaConcepto], [TipoCuentaNombre] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002918,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002919", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002919,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002920", "SELECT [WalletId] FROM [Wallet] ORDER BY [WalletId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002920,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002921", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WHERE [WalletId] = @WalletId and [WalletBalancesId] = @WalletBalancesId ORDER BY [WalletId], [WalletBalancesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002921,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002922", "SELECT [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002922,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002923", "INSERT INTO [WalletBalances]([WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion]) VALUES(@WalletId, @WalletBalancesId, @WalletBalancesFechaAlta, @WalletBalancesUsrAlta, @WalletBalancesTipoMov, @WalletBalancesImporte, @WalletBalancesObs, @WalletBalancesConcepto, @WalletBalancesUrl, @WalletBalancesEstadoOPE, @WalletBalanceLiquidacion)", GxErrorMask.GX_NOMASK,prmT002923)
           ,new CursorDef("T002924", "UPDATE [WalletBalances] SET [WalletBalancesFechaAlta]=@WalletBalancesFechaAlta, [WalletBalancesUsrAlta]=@WalletBalancesUsrAlta, [WalletBalancesTipoMov]=@WalletBalancesTipoMov, [WalletBalancesImporte]=@WalletBalancesImporte, [WalletBalancesObs]=@WalletBalancesObs, [WalletBalancesConcepto]=@WalletBalancesConcepto, [WalletBalancesUrl]=@WalletBalancesUrl, [WalletBalancesEstadoOPE]=@WalletBalancesEstadoOPE, [WalletBalanceLiquidacion]=@WalletBalanceLiquidacion  WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId", GxErrorMask.GX_NOMASK,prmT002924)
           ,new CursorDef("T002925", "DELETE FROM [WalletBalances]  WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId", GxErrorMask.GX_NOMASK,prmT002925)
           ,new CursorDef("T002926", "SELECT [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE [WalletId] = @WalletId ORDER BY [WalletId], [WalletBalancesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002926,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002927", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002927,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002928", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002928,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002929", "SELECT [WalletCodRefencia] FROM [Wallet] WHERE ([WalletCodRefencia] = @WalletCodRefencia) AND (Not ( [WalletId] = @WalletId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT002929,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 25);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 25);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 26 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 25);
              return;
     }
  }

}

}

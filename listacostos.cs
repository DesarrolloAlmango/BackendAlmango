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
   public class listacostos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A483TipoCuentaId = (long)(Math.Round(NumberUtil.Val( GetPar( "TipoCuentaId"), "."), 18, MidpointRounding.ToEven));
            n483TipoCuentaId = false;
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A483TipoCuentaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listacostos.aspx")), "listacostos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listacostos.aspx")))) ;
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
                  AV7ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ListaCostosId", StringUtil.LTrimStr( (decimal)(AV7ListaCostosId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLISTACOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Lista de Costos", ""), 0) ;
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

      public listacostos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listacostos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ListaCostosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ListaCostosId = aP1_ListaCostosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbListaCostosEstado = new GXCombobox();
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
         if ( cmbListaCostosEstado.ItemCount > 0 )
         {
            A486ListaCostosEstado = cmbListaCostosEstado.getValidValue(A486ListaCostosEstado);
            AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaCostosEstado.CurrentValue = StringUtil.RTrim( A486ListaCostosEstado);
            AssignProp("", false, cmbListaCostosEstado_Internalname, "Values", cmbListaCostosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaCostosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaCostosId_Internalname, context.GetMessage( "Idc", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtListaCostosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaCostosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaCostosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoCuentaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoCuentaId_Internalname, context.GetMessage( "Tipo de Cuenta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoCuentaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoCuentaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoCuentaId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ListaCostos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_483_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_483_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_483_Internalname, sImgUrl, imgprompt_483_Link, "", "", context.GetTheme( ), imgprompt_483_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaCostosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaCostosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaCostosNombre_Internalname, StringUtil.RTrim( A460ListaCostosNombre), StringUtil.RTrim( context.localUtil.Format( A460ListaCostosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaCostosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaCostosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaCostosValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaCostosValor_Internalname, context.GetMessage( "Costo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaCostosValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtListaCostosValor_Enabled!=0) ? context.localUtil.Format( A471ListaCostosValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A471ListaCostosValor, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaCostosValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaCostosValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaCostosCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaCostosCC_Internalname, context.GetMessage( "Código Contable ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaCostosCC_Internalname, StringUtil.RTrim( A485ListaCostosCC), StringUtil.RTrim( context.localUtil.Format( A485ListaCostosCC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaCostosCC_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaCostosCC_Enabled, 0, "text", "", 35, "chr", 1, "row", 35, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaCostosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbListaCostosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbListaCostosEstado, cmbListaCostosEstado_Internalname, StringUtil.RTrim( A486ListaCostosEstado), 1, cmbListaCostosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaCostosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_ListaCostos.htm");
         cmbListaCostosEstado.CurrentValue = StringUtil.RTrim( A486ListaCostosEstado);
         AssignProp("", false, cmbListaCostosEstado_Internalname, "Values", (string)(cmbListaCostosEstado.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaCostos.htm");
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
         E111P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z459ListaCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z460ListaCostosNombre = cgiGet( "Z460ListaCostosNombre");
               Z471ListaCostosValor = context.localUtil.CToN( cgiGet( "Z471ListaCostosValor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z485ListaCostosCC = cgiGet( "Z485ListaCostosCC");
               n485ListaCostosCC = (String.IsNullOrEmpty(StringUtil.RTrim( A485ListaCostosCC)) ? true : false);
               Z486ListaCostosEstado = cgiGet( "Z486ListaCostosEstado");
               Z483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z483TipoCuentaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n483TipoCuentaId = ((0==A483TipoCuentaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N483TipoCuentaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n483TipoCuentaId = ((0==A483TipoCuentaId) ? true : false);
               AV7ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vLISTACOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPOCUENTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_TipoCuentaId", StringUtil.LTrimStr( (decimal)(AV11Insert_TipoCuentaId), 18, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV22Pgmname = cgiGet( "vPGMNAME");
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
               A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n459ListaCostosId = false;
               AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPOCUENTAID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A483TipoCuentaId = 0;
                  n483TipoCuentaId = false;
                  AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
               }
               else
               {
                  A483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n483TipoCuentaId = false;
                  AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
               }
               n483TipoCuentaId = ((0==A483TipoCuentaId) ? true : false);
               A460ListaCostosNombre = cgiGet( edtListaCostosNombre_Internalname);
               AssignAttri("", false, "A460ListaCostosNombre", A460ListaCostosNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtListaCostosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListaCostosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTACOSTOSVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtListaCostosValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A471ListaCostosValor = 0;
                  AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
               }
               else
               {
                  A471ListaCostosValor = context.localUtil.CToN( cgiGet( edtListaCostosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
               }
               A485ListaCostosCC = cgiGet( edtListaCostosCC_Internalname);
               n485ListaCostosCC = false;
               AssignAttri("", false, "A485ListaCostosCC", A485ListaCostosCC);
               n485ListaCostosCC = (String.IsNullOrEmpty(StringUtil.RTrim( A485ListaCostosCC)) ? true : false);
               cmbListaCostosEstado.CurrentValue = cgiGet( cmbListaCostosEstado_Internalname);
               A486ListaCostosEstado = cgiGet( cmbListaCostosEstado_Internalname);
               AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ListaCostos");
               A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n459ListaCostosId = false;
               AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
               forbiddenHiddens.Add("ListaCostosId", context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TipoCuentaId", context.localUtil.Format( (decimal)(AV11Insert_TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A459ListaCostosId != Z459ListaCostosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("listacostos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A459ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
                  n459ListaCostosId = false;
                  AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
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
                     sMode68 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode68;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound68 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LISTACOSTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtListaCostosId_Internalname;
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
                           E111P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121P2 ();
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
            E121P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1P68( ) ;
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
            DisableAttributes1P68( ) ;
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

      protected void CONFIRM_1P0( )
      {
         BeforeValidate1P68( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1P68( ) ;
            }
            else
            {
               CheckExtendedTable1P68( ) ;
               CloseExtendedTableCursors1P68( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1P0( )
      {
      }

      protected void E111P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaCostos_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaCostos_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaCostos_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV22Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TipoCuentaId") == 0 )
               {
                  AV11Insert_TipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_TipoCuentaId", StringUtil.LTrimStr( (decimal)(AV11Insert_TipoCuentaId), 18, 0));
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E121P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("listacostosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1P68( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z460ListaCostosNombre = T001P3_A460ListaCostosNombre[0];
               Z471ListaCostosValor = T001P3_A471ListaCostosValor[0];
               Z485ListaCostosCC = T001P3_A485ListaCostosCC[0];
               Z486ListaCostosEstado = T001P3_A486ListaCostosEstado[0];
               Z483TipoCuentaId = T001P3_A483TipoCuentaId[0];
            }
            else
            {
               Z460ListaCostosNombre = A460ListaCostosNombre;
               Z471ListaCostosValor = A471ListaCostosValor;
               Z485ListaCostosCC = A485ListaCostosCC;
               Z486ListaCostosEstado = A486ListaCostosEstado;
               Z483TipoCuentaId = A483TipoCuentaId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z459ListaCostosId = A459ListaCostosId;
            Z460ListaCostosNombre = A460ListaCostosNombre;
            Z471ListaCostosValor = A471ListaCostosValor;
            Z485ListaCostosCC = A485ListaCostosCC;
            Z486ListaCostosEstado = A486ListaCostosEstado;
            Z483TipoCuentaId = A483TipoCuentaId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtListaCostosId_Enabled = 0;
         AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_483_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx01z0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOCUENTAID"+"'), id:'"+"TIPOCUENTAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtListaCostosId_Enabled = 0;
         AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ListaCostosId) )
         {
            A459ListaCostosId = AV7ListaCostosId;
            n459ListaCostosId = false;
            AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoCuentaId) )
         {
            edtTipoCuentaId_Enabled = 0;
            AssignProp("", false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         }
         else
         {
            edtTipoCuentaId_Enabled = 1;
            AssignProp("", false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoCuentaId) )
         {
            A483TipoCuentaId = AV11Insert_TipoCuentaId;
            n483TipoCuentaId = false;
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A486ListaCostosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A486ListaCostosEstado = context.GetMessage( context.GetMessage( "HAB", ""), "");
            AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV22Pgmname = "ListaCostos";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         }
      }

      protected void Load1P68( )
      {
         /* Using cursor T001P5 */
         pr_default.execute(3, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound68 = 1;
            A460ListaCostosNombre = T001P5_A460ListaCostosNombre[0];
            AssignAttri("", false, "A460ListaCostosNombre", A460ListaCostosNombre);
            A471ListaCostosValor = T001P5_A471ListaCostosValor[0];
            AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
            A485ListaCostosCC = T001P5_A485ListaCostosCC[0];
            n485ListaCostosCC = T001P5_n485ListaCostosCC[0];
            AssignAttri("", false, "A485ListaCostosCC", A485ListaCostosCC);
            A486ListaCostosEstado = T001P5_A486ListaCostosEstado[0];
            AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
            A483TipoCuentaId = T001P5_A483TipoCuentaId[0];
            n483TipoCuentaId = T001P5_n483TipoCuentaId[0];
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            ZM1P68( -9) ;
         }
         pr_default.close(3);
         OnLoadActions1P68( ) ;
      }

      protected void OnLoadActions1P68( )
      {
         AV22Pgmname = "ListaCostos";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
      }

      protected void CheckExtendedTable1P68( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV22Pgmname = "ListaCostos";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         /* Using cursor T001P4 */
         pr_default.execute(2, new Object[] {n483TipoCuentaId, A483TipoCuentaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A483TipoCuentaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
               AnyError = 1;
               GX_FocusControl = edtTipoCuentaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1P68( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( long A483TipoCuentaId )
      {
         /* Using cursor T001P6 */
         pr_default.execute(4, new Object[] {n483TipoCuentaId, A483TipoCuentaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A483TipoCuentaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
               AnyError = 1;
               GX_FocusControl = edtTipoCuentaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1P68( )
      {
         /* Using cursor T001P7 */
         pr_default.execute(5, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001P3 */
         pr_default.execute(1, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1P68( 9) ;
            RcdFound68 = 1;
            A459ListaCostosId = T001P3_A459ListaCostosId[0];
            n459ListaCostosId = T001P3_n459ListaCostosId[0];
            AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
            A460ListaCostosNombre = T001P3_A460ListaCostosNombre[0];
            AssignAttri("", false, "A460ListaCostosNombre", A460ListaCostosNombre);
            A471ListaCostosValor = T001P3_A471ListaCostosValor[0];
            AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
            A485ListaCostosCC = T001P3_A485ListaCostosCC[0];
            n485ListaCostosCC = T001P3_n485ListaCostosCC[0];
            AssignAttri("", false, "A485ListaCostosCC", A485ListaCostosCC);
            A486ListaCostosEstado = T001P3_A486ListaCostosEstado[0];
            AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
            A483TipoCuentaId = T001P3_A483TipoCuentaId[0];
            n483TipoCuentaId = T001P3_n483TipoCuentaId[0];
            AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            Z459ListaCostosId = A459ListaCostosId;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1P68( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey1P68( ) ;
            }
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey1P68( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1P68( ) ;
         if ( RcdFound68 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound68 = 0;
         /* Using cursor T001P8 */
         pr_default.execute(6, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001P8_A459ListaCostosId[0] < A459ListaCostosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001P8_A459ListaCostosId[0] > A459ListaCostosId ) ) )
            {
               A459ListaCostosId = T001P8_A459ListaCostosId[0];
               n459ListaCostosId = T001P8_n459ListaCostosId[0];
               AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
               RcdFound68 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound68 = 0;
         /* Using cursor T001P9 */
         pr_default.execute(7, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001P9_A459ListaCostosId[0] > A459ListaCostosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001P9_A459ListaCostosId[0] < A459ListaCostosId ) ) )
            {
               A459ListaCostosId = T001P9_A459ListaCostosId[0];
               n459ListaCostosId = T001P9_n459ListaCostosId[0];
               AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
               RcdFound68 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1P68( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipoCuentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1P68( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( A459ListaCostosId != Z459ListaCostosId )
               {
                  A459ListaCostosId = Z459ListaCostosId;
                  n459ListaCostosId = false;
                  AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LISTACOSTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtListaCostosId_Internalname;
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
                  Update1P68( ) ;
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A459ListaCostosId != Z459ListaCostosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipoCuentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1P68( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LISTACOSTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtListaCostosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipoCuentaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1P68( ) ;
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
         if ( A459ListaCostosId != Z459ListaCostosId )
         {
            A459ListaCostosId = Z459ListaCostosId;
            n459ListaCostosId = false;
            AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LISTACOSTOSID");
            AnyError = 1;
            GX_FocusControl = edtListaCostosId_Internalname;
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

      protected void CheckOptimisticConcurrency1P68( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001P2 */
            pr_default.execute(0, new Object[] {n459ListaCostosId, A459ListaCostosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaCostos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z460ListaCostosNombre, T001P2_A460ListaCostosNombre[0]) != 0 ) || ( Z471ListaCostosValor != T001P2_A471ListaCostosValor[0] ) || ( StringUtil.StrCmp(Z485ListaCostosCC, T001P2_A485ListaCostosCC[0]) != 0 ) || ( StringUtil.StrCmp(Z486ListaCostosEstado, T001P2_A486ListaCostosEstado[0]) != 0 ) || ( Z483TipoCuentaId != T001P2_A483TipoCuentaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z460ListaCostosNombre, T001P2_A460ListaCostosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("listacostos:[seudo value changed for attri]"+"ListaCostosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z460ListaCostosNombre);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A460ListaCostosNombre[0]);
               }
               if ( Z471ListaCostosValor != T001P2_A471ListaCostosValor[0] )
               {
                  GXUtil.WriteLog("listacostos:[seudo value changed for attri]"+"ListaCostosValor");
                  GXUtil.WriteLogRaw("Old: ",Z471ListaCostosValor);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A471ListaCostosValor[0]);
               }
               if ( StringUtil.StrCmp(Z485ListaCostosCC, T001P2_A485ListaCostosCC[0]) != 0 )
               {
                  GXUtil.WriteLog("listacostos:[seudo value changed for attri]"+"ListaCostosCC");
                  GXUtil.WriteLogRaw("Old: ",Z485ListaCostosCC);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A485ListaCostosCC[0]);
               }
               if ( StringUtil.StrCmp(Z486ListaCostosEstado, T001P2_A486ListaCostosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("listacostos:[seudo value changed for attri]"+"ListaCostosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z486ListaCostosEstado);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A486ListaCostosEstado[0]);
               }
               if ( Z483TipoCuentaId != T001P2_A483TipoCuentaId[0] )
               {
                  GXUtil.WriteLog("listacostos:[seudo value changed for attri]"+"TipoCuentaId");
                  GXUtil.WriteLogRaw("Old: ",Z483TipoCuentaId);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A483TipoCuentaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ListaCostos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1P68( )
      {
         BeforeValidate1P68( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P68( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1P68( 0) ;
            CheckOptimisticConcurrency1P68( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P68( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1P68( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P10 */
                     pr_default.execute(8, new Object[] {A460ListaCostosNombre, A471ListaCostosValor, n485ListaCostosCC, A485ListaCostosCC, A486ListaCostosEstado, n483TipoCuentaId, A483TipoCuentaId});
                     A459ListaCostosId = T001P10_A459ListaCostosId[0];
                     n459ListaCostosId = T001P10_n459ListaCostosId[0];
                     AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ListaCostos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1P0( ) ;
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
               Load1P68( ) ;
            }
            EndLevel1P68( ) ;
         }
         CloseExtendedTableCursors1P68( ) ;
      }

      protected void Update1P68( )
      {
         BeforeValidate1P68( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P68( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P68( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P68( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1P68( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P11 */
                     pr_default.execute(9, new Object[] {A460ListaCostosNombre, A471ListaCostosValor, n485ListaCostosCC, A485ListaCostosCC, A486ListaCostosEstado, n483TipoCuentaId, A483TipoCuentaId, n459ListaCostosId, A459ListaCostosId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ListaCostos");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaCostos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1P68( ) ;
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
            EndLevel1P68( ) ;
         }
         CloseExtendedTableCursors1P68( ) ;
      }

      protected void DeferredUpdate1P68( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1P68( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P68( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1P68( ) ;
            AfterConfirm1P68( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1P68( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001P12 */
                  pr_default.execute(10, new Object[] {n459ListaCostosId, A459ListaCostosId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("ListaCostos");
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
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1P68( ) ;
         Gx_mode = sMode68;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1P68( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV22Pgmname = "ListaCostos";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001P13 */
            pr_default.execute(11, new Object[] {n459ListaCostosId, A459ListaCostosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Detalles", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1P68( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1P68( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("listacostos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("listacostos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1P68( )
      {
         /* Scan By routine */
         /* Using cursor T001P14 */
         pr_default.execute(12);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound68 = 1;
            A459ListaCostosId = T001P14_A459ListaCostosId[0];
            n459ListaCostosId = T001P14_n459ListaCostosId[0];
            AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1P68( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound68 = 1;
            A459ListaCostosId = T001P14_A459ListaCostosId[0];
            n459ListaCostosId = T001P14_n459ListaCostosId[0];
            AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
         }
      }

      protected void ScanEnd1P68( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1P68( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1P68( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1P68( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1P68( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1P68( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1P68( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1P68( )
      {
         edtListaCostosId_Enabled = 0;
         AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), true);
         edtTipoCuentaId_Enabled = 0;
         AssignProp("", false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         edtListaCostosNombre_Enabled = 0;
         AssignProp("", false, edtListaCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosNombre_Enabled), 5, 0), true);
         edtListaCostosValor_Enabled = 0;
         AssignProp("", false, edtListaCostosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosValor_Enabled), 5, 0), true);
         edtListaCostosCC_Enabled = 0;
         AssignProp("", false, edtListaCostosCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosCC_Enabled), 5, 0), true);
         cmbListaCostosEstado.Enabled = 0;
         AssignProp("", false, cmbListaCostosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaCostosEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1P68( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1P0( )
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
         GXEncryptionTmp = "listacostos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ListaCostosId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listacostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ListaCostos");
         forbiddenHiddens.Add("ListaCostosId", context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TipoCuentaId", context.localUtil.Format( (decimal)(AV11Insert_TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("listacostos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z459ListaCostosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z460ListaCostosNombre", StringUtil.RTrim( Z460ListaCostosNombre));
         GxWebStd.gx_hidden_field( context, "Z471ListaCostosValor", StringUtil.LTrim( StringUtil.NToC( Z471ListaCostosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z485ListaCostosCC", StringUtil.RTrim( Z485ListaCostosCC));
         GxWebStd.gx_hidden_field( context, "Z486ListaCostosEstado", StringUtil.RTrim( Z486ListaCostosEstado));
         GxWebStd.gx_hidden_field( context, "Z483TipoCuentaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N483TipoCuentaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vLISTACOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTACOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOCUENTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
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
         GXEncryptionTmp = "listacostos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ListaCostosId,18,0));
         return formatLink("listacostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ListaCostos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista de Costos", "") ;
      }

      protected void InitializeNonKey1P68( )
      {
         A483TipoCuentaId = 0;
         n483TipoCuentaId = false;
         AssignAttri("", false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
         n483TipoCuentaId = ((0==A483TipoCuentaId) ? true : false);
         A460ListaCostosNombre = "";
         AssignAttri("", false, "A460ListaCostosNombre", A460ListaCostosNombre);
         A471ListaCostosValor = 0;
         AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
         A485ListaCostosCC = "";
         n485ListaCostosCC = false;
         AssignAttri("", false, "A485ListaCostosCC", A485ListaCostosCC);
         n485ListaCostosCC = (String.IsNullOrEmpty(StringUtil.RTrim( A485ListaCostosCC)) ? true : false);
         A486ListaCostosEstado = context.GetMessage( "HAB", "");
         AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
         Z460ListaCostosNombre = "";
         Z471ListaCostosValor = 0;
         Z485ListaCostosCC = "";
         Z486ListaCostosEstado = "";
         Z483TipoCuentaId = 0;
      }

      protected void InitAll1P68( )
      {
         A459ListaCostosId = 0;
         n459ListaCostosId = false;
         AssignAttri("", false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
         InitializeNonKey1P68( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A486ListaCostosEstado = i486ListaCostosEstado;
         AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021122333", true, true, false);
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
         context.AddJavascriptSource("listacostos.js", "?202673021122334", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtListaCostosId_Internalname = "LISTACOSTOSID";
         edtTipoCuentaId_Internalname = "TIPOCUENTAID";
         edtListaCostosNombre_Internalname = "LISTACOSTOSNOMBRE";
         edtListaCostosValor_Internalname = "LISTACOSTOSVALOR";
         edtListaCostosCC_Internalname = "LISTACOSTOSCC";
         cmbListaCostosEstado_Internalname = "LISTACOSTOSESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_483_Internalname = "PROMPT_483";
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
         Form.Caption = context.GetMessage( "Lista de Costos", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbListaCostosEstado_Jsonclick = "";
         cmbListaCostosEstado.Enabled = 1;
         edtListaCostosCC_Jsonclick = "";
         edtListaCostosCC_Enabled = 1;
         edtListaCostosValor_Jsonclick = "";
         edtListaCostosValor_Enabled = 1;
         edtListaCostosNombre_Jsonclick = "";
         edtListaCostosNombre_Enabled = 1;
         imgprompt_483_Visible = 1;
         imgprompt_483_Link = "";
         edtTipoCuentaId_Jsonclick = "";
         edtTipoCuentaId_Enabled = 1;
         edtListaCostosId_Jsonclick = "";
         edtListaCostosId_Enabled = 0;
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
         cmbListaCostosEstado.Name = "LISTACOSTOSESTADO";
         cmbListaCostosEstado.WebTags = "";
         cmbListaCostosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbListaCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbListaCostosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A486ListaCostosEstado)) )
            {
               A486ListaCostosEstado = context.GetMessage( "HAB", "");
               AssignAttri("", false, "A486ListaCostosEstado", A486ListaCostosEstado);
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

      public void Valid_Tipocuentaid( )
      {
         n483TipoCuentaId = false;
         /* Using cursor T001P15 */
         pr_default.execute(13, new Object[] {n483TipoCuentaId, A483TipoCuentaId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A483TipoCuentaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
               AnyError = 1;
               GX_FocusControl = edtTipoCuentaId_Internalname;
            }
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A459ListaCostosId',fld:'LISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11Insert_TipoCuentaId',fld:'vINSERT_TIPOCUENTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121P2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_LISTACOSTOSID","{handler:'Valid_Listacostosid',iparms:[]");
         setEventMetadata("VALID_LISTACOSTOSID",",oparms:[]}");
         setEventMetadata("VALID_TIPOCUENTAID","{handler:'Valid_Tipocuentaid',iparms:[{av:'A483TipoCuentaId',fld:'TIPOCUENTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_TIPOCUENTAID",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z460ListaCostosNombre = "";
         Z485ListaCostosCC = "";
         Z486ListaCostosEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A486ListaCostosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_483_gximage = "";
         sImgUrl = "";
         A460ListaCostosNombre = "";
         A485ListaCostosCC = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV22Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode68 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         T001P5_A459ListaCostosId = new long[1] ;
         T001P5_n459ListaCostosId = new bool[] {false} ;
         T001P5_A460ListaCostosNombre = new string[] {""} ;
         T001P5_A471ListaCostosValor = new decimal[1] ;
         T001P5_A485ListaCostosCC = new string[] {""} ;
         T001P5_n485ListaCostosCC = new bool[] {false} ;
         T001P5_A486ListaCostosEstado = new string[] {""} ;
         T001P5_A483TipoCuentaId = new long[1] ;
         T001P5_n483TipoCuentaId = new bool[] {false} ;
         T001P4_A483TipoCuentaId = new long[1] ;
         T001P4_n483TipoCuentaId = new bool[] {false} ;
         T001P6_A483TipoCuentaId = new long[1] ;
         T001P6_n483TipoCuentaId = new bool[] {false} ;
         T001P7_A459ListaCostosId = new long[1] ;
         T001P7_n459ListaCostosId = new bool[] {false} ;
         T001P3_A459ListaCostosId = new long[1] ;
         T001P3_n459ListaCostosId = new bool[] {false} ;
         T001P3_A460ListaCostosNombre = new string[] {""} ;
         T001P3_A471ListaCostosValor = new decimal[1] ;
         T001P3_A485ListaCostosCC = new string[] {""} ;
         T001P3_n485ListaCostosCC = new bool[] {false} ;
         T001P3_A486ListaCostosEstado = new string[] {""} ;
         T001P3_A483TipoCuentaId = new long[1] ;
         T001P3_n483TipoCuentaId = new bool[] {false} ;
         T001P8_A459ListaCostosId = new long[1] ;
         T001P8_n459ListaCostosId = new bool[] {false} ;
         T001P9_A459ListaCostosId = new long[1] ;
         T001P9_n459ListaCostosId = new bool[] {false} ;
         T001P2_A459ListaCostosId = new long[1] ;
         T001P2_n459ListaCostosId = new bool[] {false} ;
         T001P2_A460ListaCostosNombre = new string[] {""} ;
         T001P2_A471ListaCostosValor = new decimal[1] ;
         T001P2_A485ListaCostosCC = new string[] {""} ;
         T001P2_n485ListaCostosCC = new bool[] {false} ;
         T001P2_A486ListaCostosEstado = new string[] {""} ;
         T001P2_A483TipoCuentaId = new long[1] ;
         T001P2_n483TipoCuentaId = new bool[] {false} ;
         T001P10_A459ListaCostosId = new long[1] ;
         T001P10_n459ListaCostosId = new bool[] {false} ;
         T001P13_A461CentroCostosId = new long[1] ;
         T001P13_A466CentroCostosDetallesId = new long[1] ;
         T001P14_A459ListaCostosId = new long[1] ;
         T001P14_n459ListaCostosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i486ListaCostosEstado = "";
         T001P15_A483TipoCuentaId = new long[1] ;
         T001P15_n483TipoCuentaId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.listacostos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostos__default(),
            new Object[][] {
                new Object[] {
               T001P2_A459ListaCostosId, T001P2_A460ListaCostosNombre, T001P2_A471ListaCostosValor, T001P2_A485ListaCostosCC, T001P2_n485ListaCostosCC, T001P2_A486ListaCostosEstado, T001P2_A483TipoCuentaId, T001P2_n483TipoCuentaId
               }
               , new Object[] {
               T001P3_A459ListaCostosId, T001P3_A460ListaCostosNombre, T001P3_A471ListaCostosValor, T001P3_A485ListaCostosCC, T001P3_n485ListaCostosCC, T001P3_A486ListaCostosEstado, T001P3_A483TipoCuentaId, T001P3_n483TipoCuentaId
               }
               , new Object[] {
               T001P4_A483TipoCuentaId
               }
               , new Object[] {
               T001P5_A459ListaCostosId, T001P5_A460ListaCostosNombre, T001P5_A471ListaCostosValor, T001P5_A485ListaCostosCC, T001P5_n485ListaCostosCC, T001P5_A486ListaCostosEstado, T001P5_A483TipoCuentaId, T001P5_n483TipoCuentaId
               }
               , new Object[] {
               T001P6_A483TipoCuentaId
               }
               , new Object[] {
               T001P7_A459ListaCostosId
               }
               , new Object[] {
               T001P8_A459ListaCostosId
               }
               , new Object[] {
               T001P9_A459ListaCostosId
               }
               , new Object[] {
               T001P10_A459ListaCostosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001P13_A461CentroCostosId, T001P13_A466CentroCostosDetallesId
               }
               , new Object[] {
               T001P14_A459ListaCostosId
               }
               , new Object[] {
               T001P15_A483TipoCuentaId
               }
            }
         );
         AV22Pgmname = "ListaCostos";
         Z486ListaCostosEstado = context.GetMessage( "HAB", "");
         A486ListaCostosEstado = context.GetMessage( "HAB", "");
         i486ListaCostosEstado = context.GetMessage( "HAB", "");
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound68 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtListaCostosId_Enabled ;
      private int edtTipoCuentaId_Enabled ;
      private int imgprompt_483_Visible ;
      private int edtListaCostosNombre_Enabled ;
      private int edtListaCostosValor_Enabled ;
      private int edtListaCostosCC_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private long wcpOAV7ListaCostosId ;
      private long Z459ListaCostosId ;
      private long Z483TipoCuentaId ;
      private long N483TipoCuentaId ;
      private long A483TipoCuentaId ;
      private long AV7ListaCostosId ;
      private long A459ListaCostosId ;
      private long AV11Insert_TipoCuentaId ;
      private decimal Z471ListaCostosValor ;
      private decimal A471ListaCostosValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z460ListaCostosNombre ;
      private string Z485ListaCostosCC ;
      private string Z486ListaCostosEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipoCuentaId_Internalname ;
      private string A486ListaCostosEstado ;
      private string cmbListaCostosEstado_Internalname ;
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
      private string edtListaCostosId_Internalname ;
      private string TempTags ;
      private string edtListaCostosId_Jsonclick ;
      private string edtTipoCuentaId_Jsonclick ;
      private string imgprompt_483_gximage ;
      private string sImgUrl ;
      private string imgprompt_483_Internalname ;
      private string imgprompt_483_Link ;
      private string edtListaCostosNombre_Internalname ;
      private string A460ListaCostosNombre ;
      private string edtListaCostosNombre_Jsonclick ;
      private string edtListaCostosValor_Internalname ;
      private string edtListaCostosValor_Jsonclick ;
      private string edtListaCostosCC_Internalname ;
      private string A485ListaCostosCC ;
      private string edtListaCostosCC_Jsonclick ;
      private string cmbListaCostosEstado_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV22Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode68 ;
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
      private string i486ListaCostosEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n483TipoCuentaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n485ListaCostosCC ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n459ListaCostosId ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbListaCostosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T001P5_A459ListaCostosId ;
      private bool[] T001P5_n459ListaCostosId ;
      private string[] T001P5_A460ListaCostosNombre ;
      private decimal[] T001P5_A471ListaCostosValor ;
      private string[] T001P5_A485ListaCostosCC ;
      private bool[] T001P5_n485ListaCostosCC ;
      private string[] T001P5_A486ListaCostosEstado ;
      private long[] T001P5_A483TipoCuentaId ;
      private bool[] T001P5_n483TipoCuentaId ;
      private long[] T001P4_A483TipoCuentaId ;
      private bool[] T001P4_n483TipoCuentaId ;
      private long[] T001P6_A483TipoCuentaId ;
      private bool[] T001P6_n483TipoCuentaId ;
      private long[] T001P7_A459ListaCostosId ;
      private bool[] T001P7_n459ListaCostosId ;
      private long[] T001P3_A459ListaCostosId ;
      private bool[] T001P3_n459ListaCostosId ;
      private string[] T001P3_A460ListaCostosNombre ;
      private decimal[] T001P3_A471ListaCostosValor ;
      private string[] T001P3_A485ListaCostosCC ;
      private bool[] T001P3_n485ListaCostosCC ;
      private string[] T001P3_A486ListaCostosEstado ;
      private long[] T001P3_A483TipoCuentaId ;
      private bool[] T001P3_n483TipoCuentaId ;
      private long[] T001P8_A459ListaCostosId ;
      private bool[] T001P8_n459ListaCostosId ;
      private long[] T001P9_A459ListaCostosId ;
      private bool[] T001P9_n459ListaCostosId ;
      private long[] T001P2_A459ListaCostosId ;
      private bool[] T001P2_n459ListaCostosId ;
      private string[] T001P2_A460ListaCostosNombre ;
      private decimal[] T001P2_A471ListaCostosValor ;
      private string[] T001P2_A485ListaCostosCC ;
      private bool[] T001P2_n485ListaCostosCC ;
      private string[] T001P2_A486ListaCostosEstado ;
      private long[] T001P2_A483TipoCuentaId ;
      private bool[] T001P2_n483TipoCuentaId ;
      private long[] T001P10_A459ListaCostosId ;
      private bool[] T001P10_n459ListaCostosId ;
      private long[] T001P13_A461CentroCostosId ;
      private long[] T001P13_A466CentroCostosDetallesId ;
      private long[] T001P14_A459ListaCostosId ;
      private bool[] T001P14_n459ListaCostosId ;
      private long[] T001P15_A483TipoCuentaId ;
      private bool[] T001P15_n483TipoCuentaId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class listacostos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class listacostos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001P2;
        prmT001P2 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P3;
        prmT001P3 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P4;
        prmT001P4 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P5;
        prmT001P5 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P6;
        prmT001P6 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P7;
        prmT001P7 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P8;
        prmT001P8 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P9;
        prmT001P9 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P10;
        prmT001P10 = new Object[] {
        new ParDef("@ListaCostosNombre",GXType.NChar,80,0) ,
        new ParDef("@ListaCostosValor",GXType.Decimal,18,2) ,
        new ParDef("@ListaCostosCC",GXType.NChar,35,0){Nullable=true} ,
        new ParDef("@ListaCostosEstado",GXType.NChar,3,0) ,
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P11;
        prmT001P11 = new Object[] {
        new ParDef("@ListaCostosNombre",GXType.NChar,80,0) ,
        new ParDef("@ListaCostosValor",GXType.Decimal,18,2) ,
        new ParDef("@ListaCostosCC",GXType.NChar,35,0){Nullable=true} ,
        new ParDef("@ListaCostosEstado",GXType.NChar,3,0) ,
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P12;
        prmT001P12 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P13;
        prmT001P13 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001P14;
        prmT001P14 = new Object[] {
        };
        Object[] prmT001P15;
        prmT001P15 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001P2", "SELECT [ListaCostosId], [ListaCostosNombre], [ListaCostosValor], [ListaCostosCC], [ListaCostosEstado], [TipoCuentaId] FROM [ListaCostos] WITH (UPDLOCK) WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P3", "SELECT [ListaCostosId], [ListaCostosNombre], [ListaCostosValor], [ListaCostosCC], [ListaCostosEstado], [TipoCuentaId] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P4", "SELECT [TipoCuentaId] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P5", "SELECT TM1.[ListaCostosId], TM1.[ListaCostosNombre], TM1.[ListaCostosValor], TM1.[ListaCostosCC], TM1.[ListaCostosEstado], TM1.[TipoCuentaId] FROM [ListaCostos] TM1 WHERE TM1.[ListaCostosId] = @ListaCostosId ORDER BY TM1.[ListaCostosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P6", "SELECT [TipoCuentaId] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P7", "SELECT [ListaCostosId] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P8", "SELECT TOP 1 [ListaCostosId] FROM [ListaCostos] WHERE ( [ListaCostosId] > @ListaCostosId) ORDER BY [ListaCostosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P9", "SELECT TOP 1 [ListaCostosId] FROM [ListaCostos] WHERE ( [ListaCostosId] < @ListaCostosId) ORDER BY [ListaCostosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P10", "INSERT INTO [ListaCostos]([ListaCostosNombre], [ListaCostosValor], [ListaCostosCC], [ListaCostosEstado], [TipoCuentaId]) VALUES(@ListaCostosNombre, @ListaCostosValor, @ListaCostosCC, @ListaCostosEstado, @TipoCuentaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001P10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P11", "UPDATE [ListaCostos] SET [ListaCostosNombre]=@ListaCostosNombre, [ListaCostosValor]=@ListaCostosValor, [ListaCostosCC]=@ListaCostosCC, [ListaCostosEstado]=@ListaCostosEstado, [TipoCuentaId]=@TipoCuentaId  WHERE [ListaCostosId] = @ListaCostosId", GxErrorMask.GX_NOMASK,prmT001P11)
           ,new CursorDef("T001P12", "DELETE FROM [ListaCostos]  WHERE [ListaCostosId] = @ListaCostosId", GxErrorMask.GX_NOMASK,prmT001P12)
           ,new CursorDef("T001P13", "SELECT TOP 1 [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P14", "SELECT [ListaCostosId] FROM [ListaCostos] ORDER BY [ListaCostosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P15", "SELECT [TipoCuentaId] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P15,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 35);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 35);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 35);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

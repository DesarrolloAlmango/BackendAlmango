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
   public class centrocostos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action19") == 0 )
         {
            A462CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A487CentroCostosTipoRef = GetPar( "CentroCostosTipoRef");
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_19_1Q69( A462CentroCostosRef, Gx_mode, A487CentroCostosTipoRef) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A461CentroCostosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A459ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
            n459ListaCostosId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A459ListaCostosId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_detalles") == 0 )
         {
            gxnrGridlevel_detalles_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "centrocostos.aspx")), "centrocostos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "centrocostos.aspx")))) ;
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
                  AV7CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CentroCostosId", StringUtil.LTrimStr( (decimal)(AV7CentroCostosId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Centro de Costos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCentroCostosRef_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_detalles_newrow_invoke( )
      {
         nRC_GXsfl_93 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_93"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_93_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_93_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_93_idx = GetPar( "sGXsfl_93_idx");
         A465CentroCostosSerial = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosSerial"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_detalles_newrow( ) ;
         /* End function gxnrGridlevel_detalles_newrow_invoke */
      }

      public centrocostos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrocostos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_CentroCostosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CentroCostosId = aP1_CentroCostosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCentroCostosTipoRef = new GXCombobox();
         cmbCentroCostosEstado = new GXCombobox();
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
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Values", cmbCentroCostosTipoRef.ToJavascriptSource(), true);
         }
         if ( cmbCentroCostosEstado.ItemCount > 0 )
         {
            A482CentroCostosEstado = cmbCentroCostosEstado.getValidValue(A482CentroCostosEstado);
            AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
            AssignProp("", false, cmbCentroCostosEstado_Internalname, "Values", cmbCentroCostosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosId_Internalname, context.GetMessage( "Código CC:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCentroCostosTipoRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCentroCostosTipoRef_Internalname, context.GetMessage( "Tipo Referencia:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCentroCostosTipoRef, cmbCentroCostosTipoRef_Internalname, StringUtil.RTrim( A487CentroCostosTipoRef), 1, cmbCentroCostosTipoRef_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCentroCostosTipoRef.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_CentroCostos.htm");
         cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosRef_Internalname, context.GetMessage( "Referencia Nro:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosRef_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosRef_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosRef_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosNombre_Internalname, StringUtil.RTrim( A463CentroCostosNombre), StringUtil.RTrim( context.localUtil.Format( A463CentroCostosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosNombre_Enabled, 1, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtCentroCostosPrecioFinal_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosPrecioFinal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosPrecioFinal_Internalname, context.GetMessage( "Precio Final:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosPrecioFinal_Enabled!=0) ? context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosPrecioFinal_Jsonclick, 0, "AttributeFL", "", "", "", "", edtCentroCostosPrecioFinal_Visible, edtCentroCostosPrecioFinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", imgavNuevoitem_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgavNuevoitem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Nuevo Item", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "AttributeFL" + " " + ((StringUtil.StrCmp(imgavNuevoitem_gximage, "")==0) ? "" : "GX_Image_"+imgavNuevoitem_gximage+"_Class");
         StyleString = "";
         sImgUrl = context.PathToRelativeUrl( AV15NuevoItem);
         GxWebStd.gx_bitmap( context, imgavNuevoitem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavNuevoitem_Visible, imgavNuevoitem_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosSubTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosSubTotal_Internalname, context.GetMessage( "Sub Total", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosSubTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosSubTotal_Enabled!=0) ? context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosSubTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosSubTotal_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosCosto_Internalname, context.GetMessage( "Costo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosCosto_Enabled!=0) ? context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosCosto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosCosto_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtCentroCostosGam_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosGam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosGam_Internalname, context.GetMessage( "Ganancia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosGam_Internalname, StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosGam_Enabled!=0) ? context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosGam_Jsonclick, 0, "AttributeFL", "", "", "", "", edtCentroCostosGam_Visible, edtCentroCostosGam_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosUsrAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosUsrAlta_Internalname, context.GetMessage( "Usuario de Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosUsrAlta_Internalname, StringUtil.RTrim( A478CentroCostosUsrAlta), StringUtil.RTrim( context.localUtil.Format( A478CentroCostosUsrAlta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosUsrAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosUsrAlta_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosUsrMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosUsrMod_Internalname, context.GetMessage( "Usuario de Modificiación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosUsrMod_Internalname, StringUtil.RTrim( A479CentroCostosUsrMod), StringUtil.RTrim( context.localUtil.Format( A479CentroCostosUsrMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosUsrMod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosUsrMod_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosHoraAlt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosHoraAlt_Internalname, context.GetMessage( "Hora de Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCentroCostosHoraAlt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCentroCostosHoraAlt_Internalname, context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"), context.localUtil.Format( A480CentroCostosHoraAlt, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosHoraAlt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosHoraAlt_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_bitmap( context, edtCentroCostosHoraAlt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCentroCostosHoraAlt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CentroCostos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosHoraMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosHoraMod_Internalname, context.GetMessage( "Hora de Modificiación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCentroCostosHoraMod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCentroCostosHoraMod_Internalname, context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"), context.localUtil.Format( A481CentroCostosHoraMod, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosHoraMod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosHoraMod_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CentroCostos.htm");
         GxWebStd.gx_bitmap( context, edtCentroCostosHoraMod_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCentroCostosHoraMod_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CentroCostos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCentroCostosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCentroCostosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCentroCostosEstado, cmbCentroCostosEstado_Internalname, StringUtil.RTrim( A482CentroCostosEstado), 1, cmbCentroCostosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCentroCostosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_CentroCostos.htm");
         cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
         AssignProp("", false, cmbCentroCostosEstado_Internalname, "Values", (string)(cmbCentroCostosEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_detalles_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_detalles( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostos.htm");
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

      protected void gxdraw_Gridlevel_detalles( )
      {
         /*  Grid Control  */
         StartGridControl93( ) ;
         nGXsfl_93_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount70 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_70 = 1;
               ScanStart1Q70( ) ;
               while ( RcdFound70 != 0 )
               {
                  init_level_properties70( ) ;
                  getByPrimaryKey1Q70( ) ;
                  AddRow1Q70( ) ;
                  ScanNext1Q70( ) ;
               }
               ScanEnd1Q70( ) ;
               nBlankRcdCount70 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B465CentroCostosSerial = A465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            B469CentroCostosSubTotal = A469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            standaloneNotModal1Q70( ) ;
            standaloneModal1Q70( ) ;
            sMode70 = Gx_mode;
            while ( nGXsfl_93_idx < nRC_GXsfl_93 )
            {
               bGXsfl_93_Refreshing = true;
               ReadRow1Q70( ) ;
               edtCentroCostosDetallesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESID_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
               edtListaCostosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LISTACOSTOSID_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
               edtCentroCostosDetallesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_93_Refreshing);
               edtCentroCostosDetallesValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_93_Refreshing);
               imgprompt_459_Link = cgiGet( "PROMPT_459_"+sGXsfl_93_idx+"Link");
               if ( ( nRcdExists_70 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1Q70( ) ;
               }
               SendRow1Q70( ) ;
               bGXsfl_93_Refreshing = false;
            }
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A465CentroCostosSerial = B465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = B469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount70 = 5;
            nRcdExists_70 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1Q70( ) ;
               while ( RcdFound70 != 0 )
               {
                  sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_9370( ) ;
                  init_level_properties70( ) ;
                  standaloneNotModal1Q70( ) ;
                  getByPrimaryKey1Q70( ) ;
                  standaloneModal1Q70( ) ;
                  AddRow1Q70( ) ;
                  ScanNext1Q70( ) ;
               }
               ScanEnd1Q70( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode70 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx+1), 4, 0), 4, "0");
            SubsflControlProps_9370( ) ;
            InitAll1Q70( ) ;
            init_level_properties70( ) ;
            B465CentroCostosSerial = A465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            B469CentroCostosSubTotal = A469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            nRcdExists_70 = 0;
            nIsMod_70 = 0;
            nRcdDeleted_70 = 0;
            nBlankRcdCount70 = (short)(nBlankRcdUsr70+nBlankRcdCount70);
            fRowAdded = 0;
            while ( nBlankRcdCount70 > 0 )
            {
               standaloneNotModal1Q70( ) ;
               standaloneModal1Q70( ) ;
               AddRow1Q70( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtListaCostosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount70 = (short)(nBlankRcdCount70-1);
            }
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A465CentroCostosSerial = B465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = B469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_detallesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_detalles", Gridlevel_detallesContainer, subGridlevel_detalles_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_detallesContainerData", Gridlevel_detallesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_detallesContainerData"+"V", Gridlevel_detallesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_detallesContainerData"+"V"+"\" value='"+Gridlevel_detallesContainer.GridValuesHidden()+"'/>") ;
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
         E111Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z461CentroCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z475CentroCostosCosto = context.localUtil.CToN( cgiGet( "Z475CentroCostosCosto"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z487CentroCostosTipoRef = cgiGet( "Z487CentroCostosTipoRef");
               Z462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z462CentroCostosRef"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z463CentroCostosNombre = cgiGet( "Z463CentroCostosNombre");
               Z464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( "Z464CentroCostosPrecioFinal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z465CentroCostosSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z478CentroCostosUsrAlta = cgiGet( "Z478CentroCostosUsrAlta");
               Z479CentroCostosUsrMod = cgiGet( "Z479CentroCostosUsrMod");
               Z480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( "Z480CentroCostosHoraAlt"), 0);
               Z481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( "Z481CentroCostosHoraMod"), 0);
               Z482CentroCostosEstado = cgiGet( "Z482CentroCostosEstado");
               A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z465CentroCostosSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "O465CentroCostosSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( "O469CentroCostosSubTotal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_93 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_93"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N462CentroCostosRef"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N463CentroCostosNombre = cgiGet( "N463CentroCostosNombre");
               AV7CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCENTROCOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13CentroCostosNombre = cgiGet( "vCENTROCOSTOSNOMBRE");
               AV14CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( "vCENTROCOSTOSPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV24Pgmname = cgiGet( "vPGMNAME");
               A460ListaCostosNombre = cgiGet( "LISTACOSTOSNOMBRE");
               A471ListaCostosValor = context.localUtil.CToN( cgiGet( "LISTACOSTOSVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
               A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               cmbCentroCostosTipoRef.Name = cmbCentroCostosTipoRef_Internalname;
               cmbCentroCostosTipoRef.CurrentValue = cgiGet( cmbCentroCostosTipoRef_Internalname);
               A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
               AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CENTROCOSTOSREF");
                  AnyError = 1;
                  GX_FocusControl = edtCentroCostosRef_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A462CentroCostosRef = 0;
                  AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
               }
               else
               {
                  A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
               }
               A463CentroCostosNombre = cgiGet( edtCentroCostosNombre_Internalname);
               AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
               A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
               AV15NuevoItem = cgiGet( imgavNuevoitem_Internalname);
               A469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( edtCentroCostosSubTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CENTROCOSTOSCOSTO");
                  AnyError = 1;
                  GX_FocusControl = edtCentroCostosCosto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A475CentroCostosCosto = 0;
                  AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
               }
               else
               {
                  A475CentroCostosCosto = context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
               }
               A474CentroCostosGam = context.localUtil.CToN( cgiGet( edtCentroCostosGam_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
               A478CentroCostosUsrAlta = cgiGet( edtCentroCostosUsrAlta_Internalname);
               AssignAttri("", false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
               A479CentroCostosUsrMod = cgiGet( edtCentroCostosUsrMod_Internalname);
               AssignAttri("", false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
               A480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( edtCentroCostosHoraAlt_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
               A481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( edtCentroCostosHoraMod_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
               cmbCentroCostosEstado.Name = cmbCentroCostosEstado_Internalname;
               cmbCentroCostosEstado.CurrentValue = cgiGet( cmbCentroCostosEstado_Internalname);
               A482CentroCostosEstado = cgiGet( cmbCentroCostosEstado_Internalname);
               AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CentroCostos");
               A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               forbiddenHiddens.Add("CentroCostosId", context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"));
               A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
               AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
               forbiddenHiddens.Add("CentroCostosTipoRef", StringUtil.RTrim( context.localUtil.Format( A487CentroCostosTipoRef, "")));
               A478CentroCostosUsrAlta = cgiGet( edtCentroCostosUsrAlta_Internalname);
               AssignAttri("", false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
               forbiddenHiddens.Add("CentroCostosUsrAlta", StringUtil.RTrim( context.localUtil.Format( A478CentroCostosUsrAlta, "")));
               A479CentroCostosUsrMod = cgiGet( edtCentroCostosUsrMod_Internalname);
               AssignAttri("", false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
               forbiddenHiddens.Add("CentroCostosUsrMod", StringUtil.RTrim( context.localUtil.Format( A479CentroCostosUsrMod, "")));
               A480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( edtCentroCostosHoraAlt_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
               forbiddenHiddens.Add("CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
               A481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( edtCentroCostosHoraMod_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
               forbiddenHiddens.Add("CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A461CentroCostosId != Z461CentroCostosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("centrocostos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
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
                     sMode69 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode69;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound69 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CENTROCOSTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtCentroCostosId_Internalname;
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
                           E111Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121Q2 ();
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
            E121Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1Q69( ) ;
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
            DisableAttributes1Q69( ) ;
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

      protected void CONFIRM_1Q0( )
      {
         BeforeValidate1Q69( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Q69( ) ;
            }
            else
            {
               CheckExtendedTable1Q69( ) ;
               CloseExtendedTableCursors1Q69( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode69 = Gx_mode;
            CONFIRM_1Q70( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode69;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1Q70( )
      {
         s465CentroCostosSerial = O465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         s469CentroCostosSubTotal = O469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         nGXsfl_93_idx = 0;
         while ( nGXsfl_93_idx < nRC_GXsfl_93 )
         {
            ReadRow1Q70( ) ;
            if ( ( nRcdExists_70 != 0 ) || ( nIsMod_70 != 0 ) )
            {
               GetKey1Q70( ) ;
               if ( ( nRcdExists_70 == 0 ) && ( nRcdDeleted_70 == 0 ) )
               {
                  if ( RcdFound70 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1Q70( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1Q70( ) ;
                        CloseExtendedTableCursors1Q70( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O465CentroCostosSerial = A465CentroCostosSerial;
                        AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                        O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                        n469CentroCostosSubTotal = false;
                        AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
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
                  if ( RcdFound70 != 0 )
                  {
                     if ( nRcdDeleted_70 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1Q70( ) ;
                        Load1Q70( ) ;
                        BeforeValidate1Q70( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1Q70( ) ;
                           O465CentroCostosSerial = A465CentroCostosSerial;
                           AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                           O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                           n469CentroCostosSubTotal = false;
                           AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_70 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1Q70( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1Q70( ) ;
                              CloseExtendedTableCursors1Q70( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O465CentroCostosSerial = A465CentroCostosSerial;
                              AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                              O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                              n469CentroCostosSubTotal = false;
                              AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_70 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtCentroCostosDetallesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCentroCostosDetallesNombre_Internalname, StringUtil.RTrim( A473CentroCostosDetallesNombre)) ;
            ChangePostValue( edtCentroCostosDetallesValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_93_idx, StringUtil.RTrim( Z473CentroCostosDetallesNombre)) ;
            ChangePostValue( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( Z468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z459ListaCostosId_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "T468CentroCostosDetallesValor_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( O468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_70_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_70_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_70_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_70 != 0 )
            {
               ChangePostValue( "CENTROCOSTOSDETALLESID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LISTACOSTOSID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O465CentroCostosSerial = s465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         O469CentroCostosSubTotal = s469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1Q0( )
      {
      }

      protected void E111Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV24Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E121Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("centrocostosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1Q69( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z475CentroCostosCosto = T001Q6_A475CentroCostosCosto[0];
               Z487CentroCostosTipoRef = T001Q6_A487CentroCostosTipoRef[0];
               Z462CentroCostosRef = T001Q6_A462CentroCostosRef[0];
               Z463CentroCostosNombre = T001Q6_A463CentroCostosNombre[0];
               Z464CentroCostosPrecioFinal = T001Q6_A464CentroCostosPrecioFinal[0];
               Z465CentroCostosSerial = T001Q6_A465CentroCostosSerial[0];
               Z478CentroCostosUsrAlta = T001Q6_A478CentroCostosUsrAlta[0];
               Z479CentroCostosUsrMod = T001Q6_A479CentroCostosUsrMod[0];
               Z480CentroCostosHoraAlt = T001Q6_A480CentroCostosHoraAlt[0];
               Z481CentroCostosHoraMod = T001Q6_A481CentroCostosHoraMod[0];
               Z482CentroCostosEstado = T001Q6_A482CentroCostosEstado[0];
            }
            else
            {
               Z475CentroCostosCosto = A475CentroCostosCosto;
               Z487CentroCostosTipoRef = A487CentroCostosTipoRef;
               Z462CentroCostosRef = A462CentroCostosRef;
               Z463CentroCostosNombre = A463CentroCostosNombre;
               Z464CentroCostosPrecioFinal = A464CentroCostosPrecioFinal;
               Z465CentroCostosSerial = A465CentroCostosSerial;
               Z478CentroCostosUsrAlta = A478CentroCostosUsrAlta;
               Z479CentroCostosUsrMod = A479CentroCostosUsrMod;
               Z480CentroCostosHoraAlt = A480CentroCostosHoraAlt;
               Z481CentroCostosHoraMod = A481CentroCostosHoraMod;
               Z482CentroCostosEstado = A482CentroCostosEstado;
            }
         }
         if ( GX_JID == -29 )
         {
            Z461CentroCostosId = A461CentroCostosId;
            Z475CentroCostosCosto = A475CentroCostosCosto;
            Z487CentroCostosTipoRef = A487CentroCostosTipoRef;
            Z462CentroCostosRef = A462CentroCostosRef;
            Z463CentroCostosNombre = A463CentroCostosNombre;
            Z464CentroCostosPrecioFinal = A464CentroCostosPrecioFinal;
            Z465CentroCostosSerial = A465CentroCostosSerial;
            Z478CentroCostosUsrAlta = A478CentroCostosUsrAlta;
            Z479CentroCostosUsrMod = A479CentroCostosUsrMod;
            Z480CentroCostosHoraAlt = A480CentroCostosHoraAlt;
            Z481CentroCostosHoraMod = A481CentroCostosHoraMod;
            Z482CentroCostosEstado = A482CentroCostosEstado;
            Z469CentroCostosSubTotal = A469CentroCostosSubTotal;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCentroCostosId_Enabled = 0;
         AssignProp("", false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosUsrAlta_Enabled = 0;
         AssignProp("", false, edtCentroCostosUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrAlta_Enabled), 5, 0), true);
         edtCentroCostosUsrMod_Enabled = 0;
         AssignProp("", false, edtCentroCostosUsrMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrMod_Enabled), 5, 0), true);
         edtCentroCostosHoraAlt_Enabled = 0;
         AssignProp("", false, edtCentroCostosHoraAlt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraAlt_Enabled), 5, 0), true);
         edtCentroCostosHoraMod_Enabled = 0;
         AssignProp("", false, edtCentroCostosHoraMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraMod_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCentroCostosId_Enabled = 0;
         AssignProp("", false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosUsrAlta_Enabled = 0;
         AssignProp("", false, edtCentroCostosUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrAlta_Enabled), 5, 0), true);
         edtCentroCostosUsrMod_Enabled = 0;
         AssignProp("", false, edtCentroCostosUsrMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrMod_Enabled), 5, 0), true);
         edtCentroCostosHoraAlt_Enabled = 0;
         AssignProp("", false, edtCentroCostosHoraAlt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraAlt_Enabled), 5, 0), true);
         edtCentroCostosHoraMod_Enabled = 0;
         AssignProp("", false, edtCentroCostosHoraMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraMod_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CentroCostosId) )
         {
            A461CentroCostosId = AV7CentroCostosId;
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A487CentroCostosTipoRef)) && ( Gx_BScreen == 0 ) )
         {
            A487CentroCostosTipoRef = context.GetMessage( context.GetMessage( "O", ""), "");
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A482CentroCostosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A482CentroCostosEstado = context.GetMessage( context.GetMessage( "PND", ""), "");
            AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001Q8 */
            pr_default.execute(5, new Object[] {A461CentroCostosId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A469CentroCostosSubTotal = T001Q8_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = T001Q8_n469CentroCostosSubTotal[0];
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               A469CentroCostosSubTotal = 0;
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            O469CentroCostosSubTotal = A469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            pr_default.close(5);
            if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
            {
               A464CentroCostosPrecioFinal = AV14CentroCostosPrecioFinal;
               AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
            }
            if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
            {
               A463CentroCostosNombre = AV13CentroCostosNombre;
               AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
            {
               edtCentroCostosRef_Enabled = 0;
               AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
            }
            else
            {
               edtCentroCostosRef_Enabled = 1;
               AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
            {
               edtCentroCostosNombre_Enabled = 0;
               AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
            }
            else
            {
               edtCentroCostosNombre_Enabled = 1;
               AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
            {
               edtCentroCostosPrecioFinal_Visible = 0;
               AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Visible), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
            {
               edtCentroCostosGam_Visible = 0;
               AssignProp("", false, edtCentroCostosGam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Visible), 5, 0), true);
            }
         }
      }

      protected void Load1Q69( )
      {
         /* Using cursor T001Q10 */
         pr_default.execute(6, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound69 = 1;
            A475CentroCostosCosto = T001Q10_A475CentroCostosCosto[0];
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            A487CentroCostosTipoRef = T001Q10_A487CentroCostosTipoRef[0];
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            A462CentroCostosRef = T001Q10_A462CentroCostosRef[0];
            AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
            A463CentroCostosNombre = T001Q10_A463CentroCostosNombre[0];
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            A464CentroCostosPrecioFinal = T001Q10_A464CentroCostosPrecioFinal[0];
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
            A465CentroCostosSerial = T001Q10_A465CentroCostosSerial[0];
            A478CentroCostosUsrAlta = T001Q10_A478CentroCostosUsrAlta[0];
            AssignAttri("", false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
            A479CentroCostosUsrMod = T001Q10_A479CentroCostosUsrMod[0];
            AssignAttri("", false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
            A480CentroCostosHoraAlt = T001Q10_A480CentroCostosHoraAlt[0];
            AssignAttri("", false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
            A481CentroCostosHoraMod = T001Q10_A481CentroCostosHoraMod[0];
            AssignAttri("", false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
            A482CentroCostosEstado = T001Q10_A482CentroCostosEstado[0];
            AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
            A469CentroCostosSubTotal = T001Q10_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T001Q10_n469CentroCostosSubTotal[0];
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            ZM1Q69( -29) ;
         }
         pr_default.close(6);
         OnLoadActions1Q69( ) ;
      }

      protected void OnLoadActions1Q69( )
      {
         O469CentroCostosSubTotal = A469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         AV24Pgmname = "CentroCostos";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
         {
            A464CentroCostosPrecioFinal = AV14CentroCostosPrecioFinal;
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
         }
         if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
         {
            A463CentroCostosNombre = AV13CentroCostosNombre;
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
         }
         A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
         AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         if ( ( StringUtil.StrCmp(sMode69, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
         {
            edtCentroCostosRef_Enabled = 0;
            AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         }
         else
         {
            edtCentroCostosRef_Enabled = 1;
            AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(sMode69, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
         {
            edtCentroCostosNombre_Enabled = 0;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         }
         else
         {
            edtCentroCostosNombre_Enabled = 1;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
         {
            edtCentroCostosPrecioFinal_Visible = 0;
            AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
         {
            edtCentroCostosGam_Visible = 0;
            AssignProp("", false, edtCentroCostosGam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Visible), 5, 0), true);
         }
      }

      protected void CheckExtendedTable1Q69( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV24Pgmname = "CentroCostos";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         /* Using cursor T001Q8 */
         pr_default.execute(5, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A469CentroCostosSubTotal = T001Q8_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T001Q8_n469CentroCostosSubTotal[0];
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         pr_default.close(5);
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
         {
            A464CentroCostosPrecioFinal = AV14CentroCostosPrecioFinal;
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
         }
         if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
         {
            A463CentroCostosNombre = AV13CentroCostosNombre;
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( "S", "")) == 0 ) )
         {
            new osoldat(context ).execute(  A462CentroCostosRef, out  AV13CentroCostosNombre, out  AV14CentroCostosPrecioFinal) ;
            AssignAttri("", false, "AV13CentroCostosNombre", AV13CentroCostosNombre);
            AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
         }
         A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
         AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
         {
            edtCentroCostosRef_Enabled = 0;
            AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         }
         else
         {
            edtCentroCostosRef_Enabled = 1;
            AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
         {
            edtCentroCostosNombre_Enabled = 0;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         }
         else
         {
            edtCentroCostosNombre_Enabled = 1;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
         {
            edtCentroCostosPrecioFinal_Visible = 0;
            AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
         {
            edtCentroCostosGam_Visible = 0;
            AssignProp("", false, edtCentroCostosGam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Visible), 5, 0), true);
         }
      }

      protected void CloseExtendedTableCursors1Q69( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_30( long A461CentroCostosId )
      {
         /* Using cursor T001Q12 */
         pr_default.execute(7, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A469CentroCostosSubTotal = T001Q12_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T001Q12_n469CentroCostosSubTotal[0];
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey1Q69( )
      {
         /* Using cursor T001Q13 */
         pr_default.execute(8, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound69 = 1;
         }
         else
         {
            RcdFound69 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Q6 */
         pr_default.execute(4, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1Q69( 29) ;
            RcdFound69 = 1;
            A461CentroCostosId = T001Q6_A461CentroCostosId[0];
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            A475CentroCostosCosto = T001Q6_A475CentroCostosCosto[0];
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            A487CentroCostosTipoRef = T001Q6_A487CentroCostosTipoRef[0];
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            A462CentroCostosRef = T001Q6_A462CentroCostosRef[0];
            AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
            A463CentroCostosNombre = T001Q6_A463CentroCostosNombre[0];
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            A464CentroCostosPrecioFinal = T001Q6_A464CentroCostosPrecioFinal[0];
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
            A465CentroCostosSerial = T001Q6_A465CentroCostosSerial[0];
            A478CentroCostosUsrAlta = T001Q6_A478CentroCostosUsrAlta[0];
            AssignAttri("", false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
            A479CentroCostosUsrMod = T001Q6_A479CentroCostosUsrMod[0];
            AssignAttri("", false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
            A480CentroCostosHoraAlt = T001Q6_A480CentroCostosHoraAlt[0];
            AssignAttri("", false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
            A481CentroCostosHoraMod = T001Q6_A481CentroCostosHoraMod[0];
            AssignAttri("", false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
            A482CentroCostosEstado = T001Q6_A482CentroCostosEstado[0];
            AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
            O465CentroCostosSerial = A465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            Z461CentroCostosId = A461CentroCostosId;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1Q69( ) ;
            if ( AnyError == 1 )
            {
               RcdFound69 = 0;
               InitializeNonKey1Q69( ) ;
            }
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound69 = 0;
            InitializeNonKey1Q69( ) ;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Q69( ) ;
         if ( RcdFound69 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound69 = 0;
         /* Using cursor T001Q14 */
         pr_default.execute(9, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001Q14_A461CentroCostosId[0] < A461CentroCostosId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001Q14_A461CentroCostosId[0] > A461CentroCostosId ) ) )
            {
               A461CentroCostosId = T001Q14_A461CentroCostosId[0];
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               RcdFound69 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound69 = 0;
         /* Using cursor T001Q15 */
         pr_default.execute(10, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001Q15_A461CentroCostosId[0] > A461CentroCostosId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001Q15_A461CentroCostosId[0] < A461CentroCostosId ) ) )
            {
               A461CentroCostosId = T001Q15_A461CentroCostosId[0];
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               RcdFound69 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Q69( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A465CentroCostosSerial = O465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = O469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            GX_FocusControl = edtCentroCostosRef_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Q69( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound69 == 1 )
            {
               if ( A461CentroCostosId != Z461CentroCostosId )
               {
                  A461CentroCostosId = Z461CentroCostosId;
                  AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CENTROCOSTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtCentroCostosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCentroCostosRef_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  Update1Q69( ) ;
                  GX_FocusControl = edtCentroCostosRef_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A461CentroCostosId != Z461CentroCostosId )
               {
                  /* Insert record */
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  GX_FocusControl = edtCentroCostosRef_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Q69( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CENTROCOSTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtCentroCostosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A465CentroCostosSerial = O465CentroCostosSerial;
                     AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                     A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                     n469CentroCostosSubTotal = false;
                     AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                     GX_FocusControl = edtCentroCostosRef_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Q69( ) ;
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
         if ( A461CentroCostosId != Z461CentroCostosId )
         {
            A461CentroCostosId = Z461CentroCostosId;
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CENTROCOSTOSID");
            AnyError = 1;
            GX_FocusControl = edtCentroCostosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A465CentroCostosSerial = O465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = O469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCentroCostosRef_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1Q69( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Q5 */
            pr_default.execute(3, new Object[] {A461CentroCostosId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( Z475CentroCostosCosto != T001Q5_A475CentroCostosCosto[0] ) || ( StringUtil.StrCmp(Z487CentroCostosTipoRef, T001Q5_A487CentroCostosTipoRef[0]) != 0 ) || ( Z462CentroCostosRef != T001Q5_A462CentroCostosRef[0] ) || ( StringUtil.StrCmp(Z463CentroCostosNombre, T001Q5_A463CentroCostosNombre[0]) != 0 ) || ( Z464CentroCostosPrecioFinal != T001Q5_A464CentroCostosPrecioFinal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z465CentroCostosSerial != T001Q5_A465CentroCostosSerial[0] ) || ( StringUtil.StrCmp(Z478CentroCostosUsrAlta, T001Q5_A478CentroCostosUsrAlta[0]) != 0 ) || ( StringUtil.StrCmp(Z479CentroCostosUsrMod, T001Q5_A479CentroCostosUsrMod[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z480CentroCostosHoraAlt ) != DateTimeUtil.ResetTime ( T001Q5_A480CentroCostosHoraAlt[0] ) ) || ( DateTimeUtil.ResetTime ( Z481CentroCostosHoraMod ) != DateTimeUtil.ResetTime ( T001Q5_A481CentroCostosHoraMod[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z482CentroCostosEstado, T001Q5_A482CentroCostosEstado[0]) != 0 ) )
            {
               if ( Z475CentroCostosCosto != T001Q5_A475CentroCostosCosto[0] )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosCosto");
                  GXUtil.WriteLogRaw("Old: ",Z475CentroCostosCosto);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A475CentroCostosCosto[0]);
               }
               if ( StringUtil.StrCmp(Z487CentroCostosTipoRef, T001Q5_A487CentroCostosTipoRef[0]) != 0 )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosTipoRef");
                  GXUtil.WriteLogRaw("Old: ",Z487CentroCostosTipoRef);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A487CentroCostosTipoRef[0]);
               }
               if ( Z462CentroCostosRef != T001Q5_A462CentroCostosRef[0] )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosRef");
                  GXUtil.WriteLogRaw("Old: ",Z462CentroCostosRef);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A462CentroCostosRef[0]);
               }
               if ( StringUtil.StrCmp(Z463CentroCostosNombre, T001Q5_A463CentroCostosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z463CentroCostosNombre);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A463CentroCostosNombre[0]);
               }
               if ( Z464CentroCostosPrecioFinal != T001Q5_A464CentroCostosPrecioFinal[0] )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosPrecioFinal");
                  GXUtil.WriteLogRaw("Old: ",Z464CentroCostosPrecioFinal);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A464CentroCostosPrecioFinal[0]);
               }
               if ( Z465CentroCostosSerial != T001Q5_A465CentroCostosSerial[0] )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosSerial");
                  GXUtil.WriteLogRaw("Old: ",Z465CentroCostosSerial);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A465CentroCostosSerial[0]);
               }
               if ( StringUtil.StrCmp(Z478CentroCostosUsrAlta, T001Q5_A478CentroCostosUsrAlta[0]) != 0 )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z478CentroCostosUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A478CentroCostosUsrAlta[0]);
               }
               if ( StringUtil.StrCmp(Z479CentroCostosUsrMod, T001Q5_A479CentroCostosUsrMod[0]) != 0 )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosUsrMod");
                  GXUtil.WriteLogRaw("Old: ",Z479CentroCostosUsrMod);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A479CentroCostosUsrMod[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z480CentroCostosHoraAlt ) != DateTimeUtil.ResetTime ( T001Q5_A480CentroCostosHoraAlt[0] ) )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosHoraAlt");
                  GXUtil.WriteLogRaw("Old: ",Z480CentroCostosHoraAlt);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A480CentroCostosHoraAlt[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z481CentroCostosHoraMod ) != DateTimeUtil.ResetTime ( T001Q5_A481CentroCostosHoraMod[0] ) )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosHoraMod");
                  GXUtil.WriteLogRaw("Old: ",Z481CentroCostosHoraMod);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A481CentroCostosHoraMod[0]);
               }
               if ( StringUtil.StrCmp(Z482CentroCostosEstado, T001Q5_A482CentroCostosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z482CentroCostosEstado);
                  GXUtil.WriteLogRaw("Current: ",T001Q5_A482CentroCostosEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CentroCostos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q69( )
      {
         BeforeValidate1Q69( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q69( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q69( 0) ;
            CheckOptimisticConcurrency1Q69( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q69( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q69( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q16 */
                     pr_default.execute(11, new Object[] {A475CentroCostosCosto, A487CentroCostosTipoRef, A462CentroCostosRef, A463CentroCostosNombre, A464CentroCostosPrecioFinal, A465CentroCostosSerial, A478CentroCostosUsrAlta, A479CentroCostosUsrMod, A480CentroCostosHoraAlt, A481CentroCostosHoraMod, A482CentroCostosEstado});
                     A461CentroCostosId = T001Q16_A461CentroCostosId[0];
                     AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1Q69( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1Q0( ) ;
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
               Load1Q69( ) ;
            }
            EndLevel1Q69( ) ;
         }
         CloseExtendedTableCursors1Q69( ) ;
      }

      protected void Update1Q69( )
      {
         BeforeValidate1Q69( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q69( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q69( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q69( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q69( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q17 */
                     pr_default.execute(12, new Object[] {A475CentroCostosCosto, A487CentroCostosTipoRef, A462CentroCostosRef, A463CentroCostosNombre, A464CentroCostosPrecioFinal, A465CentroCostosSerial, A478CentroCostosUsrAlta, A479CentroCostosUsrMod, A480CentroCostosHoraAlt, A481CentroCostosHoraMod, A482CentroCostosEstado, A461CentroCostosId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q69( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1Q69( ) ;
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
            EndLevel1Q69( ) ;
         }
         CloseExtendedTableCursors1Q69( ) ;
      }

      protected void DeferredUpdate1Q69( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1Q69( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q69( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q69( ) ;
            AfterConfirm1Q69( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q69( ) ;
               if ( AnyError == 0 )
               {
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  ScanStart1Q70( ) ;
                  while ( RcdFound70 != 0 )
                  {
                     getByPrimaryKey1Q70( ) ;
                     Delete1Q70( ) ;
                     ScanNext1Q70( ) ;
                     O465CentroCostosSerial = A465CentroCostosSerial;
                     AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                     O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                     n469CentroCostosSubTotal = false;
                     AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  }
                  ScanEnd1Q70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q18 */
                     pr_default.execute(13, new Object[] {A461CentroCostosId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
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
         sMode69 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Q69( ) ;
         Gx_mode = sMode69;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Q69( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV24Pgmname = "CentroCostos";
            AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
            /* Using cursor T001Q20 */
            pr_default.execute(14, new Object[] {A461CentroCostosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A469CentroCostosSubTotal = T001Q20_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = T001Q20_n469CentroCostosSubTotal[0];
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               A469CentroCostosSubTotal = 0;
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            pr_default.close(14);
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
            {
               edtCentroCostosRef_Enabled = 0;
               AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
            }
            else
            {
               edtCentroCostosRef_Enabled = 1;
               AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) == 0 ) )
            {
               edtCentroCostosNombre_Enabled = 0;
               AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
            }
            else
            {
               edtCentroCostosNombre_Enabled = 1;
               AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
            {
               edtCentroCostosPrecioFinal_Visible = 0;
               AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Visible), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( context.GetMessage( "S", ""), "")) != 0 )
            {
               edtCentroCostosGam_Visible = 0;
               AssignProp("", false, edtCentroCostosGam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Visible), 5, 0), true);
            }
            A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
            AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         }
      }

      protected void ProcessNestedLevel1Q70( )
      {
         s465CentroCostosSerial = O465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         s469CentroCostosSubTotal = O469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         nGXsfl_93_idx = 0;
         while ( nGXsfl_93_idx < nRC_GXsfl_93 )
         {
            ReadRow1Q70( ) ;
            if ( ( nRcdExists_70 != 0 ) || ( nIsMod_70 != 0 ) )
            {
               standaloneNotModal1Q70( ) ;
               GetKey1Q70( ) ;
               if ( ( nRcdExists_70 == 0 ) && ( nRcdDeleted_70 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1Q70( ) ;
               }
               else
               {
                  if ( RcdFound70 != 0 )
                  {
                     if ( ( nRcdDeleted_70 != 0 ) && ( nRcdExists_70 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1Q70( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_70 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1Q70( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_70 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O465CentroCostosSerial = A465CentroCostosSerial;
               AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
               O469CentroCostosSubTotal = A469CentroCostosSubTotal;
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            ChangePostValue( edtCentroCostosDetallesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCentroCostosDetallesNombre_Internalname, StringUtil.RTrim( A473CentroCostosDetallesNombre)) ;
            ChangePostValue( edtCentroCostosDetallesValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_93_idx, StringUtil.RTrim( Z473CentroCostosDetallesNombre)) ;
            ChangePostValue( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( Z468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z459ListaCostosId_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "T468CentroCostosDetallesValor_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( O468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_70_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_70_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_70_"+sGXsfl_93_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_70 != 0 )
            {
               ChangePostValue( "CENTROCOSTOSDETALLESID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LISTACOSTOSID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1Q70( ) ;
         if ( AnyError != 0 )
         {
            O465CentroCostosSerial = s465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            O469CentroCostosSubTotal = s469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         nRcdExists_70 = 0;
         nIsMod_70 = 0;
         nRcdDeleted_70 = 0;
      }

      protected void ProcessLevel1Q69( )
      {
         /* Save parent mode. */
         sMode69 = Gx_mode;
         ProcessNestedLevel1Q70( ) ;
         if ( AnyError != 0 )
         {
            O465CentroCostosSerial = s465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            O469CentroCostosSubTotal = s469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode69;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T001Q21 */
         pr_default.execute(15, new Object[] {A465CentroCostosSerial, A475CentroCostosCosto, A461CentroCostosId});
         pr_default.close(15);
         pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
      }

      protected void EndLevel1Q69( )
      {
         pr_default.close(3);
         if ( AnyError == 0 )
         {
            BeforeComplete1Q69( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(14);
            pr_default.close(2);
            context.CommitDataStores("centrocostos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(14);
            pr_default.close(2);
            context.RollbackDataStores("centrocostos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Q69( )
      {
         /* Scan By routine */
         /* Using cursor T001Q22 */
         pr_default.execute(16);
         RcdFound69 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound69 = 1;
            A461CentroCostosId = T001Q22_A461CentroCostosId[0];
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Q69( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound69 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound69 = 1;
            A461CentroCostosId = T001Q22_A461CentroCostosId[0];
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         }
      }

      protected void ScanEnd1Q69( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1Q69( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q69( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q69( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q69( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q69( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q69( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q69( )
      {
         edtCentroCostosId_Enabled = 0;
         AssignProp("", false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosRef_Enabled = 0;
         AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         edtCentroCostosNombre_Enabled = 0;
         AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         edtCentroCostosSubTotal_Enabled = 0;
         AssignProp("", false, edtCentroCostosSubTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosSubTotal_Enabled), 5, 0), true);
         edtCentroCostosCosto_Enabled = 0;
         AssignProp("", false, edtCentroCostosCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosCosto_Enabled), 5, 0), true);
         edtCentroCostosGam_Enabled = 0;
         AssignProp("", false, edtCentroCostosGam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Enabled), 5, 0), true);
         edtCentroCostosUsrAlta_Enabled = 0;
         AssignProp("", false, edtCentroCostosUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrAlta_Enabled), 5, 0), true);
         edtCentroCostosUsrMod_Enabled = 0;
         AssignProp("", false, edtCentroCostosUsrMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrMod_Enabled), 5, 0), true);
         edtCentroCostosHoraAlt_Enabled = 0;
         AssignProp("", false, edtCentroCostosHoraAlt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraAlt_Enabled), 5, 0), true);
         edtCentroCostosHoraMod_Enabled = 0;
         AssignProp("", false, edtCentroCostosHoraMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraMod_Enabled), 5, 0), true);
         cmbCentroCostosEstado.Enabled = 0;
         AssignProp("", false, cmbCentroCostosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosEstado.Enabled), 5, 0), true);
      }

      protected void ZM1Q70( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z473CentroCostosDetallesNombre = T001Q3_A473CentroCostosDetallesNombre[0];
               Z468CentroCostosDetallesValor = T001Q3_A468CentroCostosDetallesValor[0];
               Z459ListaCostosId = T001Q3_A459ListaCostosId[0];
            }
            else
            {
               Z473CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
               Z468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
               Z459ListaCostosId = A459ListaCostosId;
            }
         }
         if ( GX_JID == -31 )
         {
            Z461CentroCostosId = A461CentroCostosId;
            Z466CentroCostosDetallesId = A466CentroCostosDetallesId;
            Z473CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
            Z468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
            Z459ListaCostosId = A459ListaCostosId;
            Z460ListaCostosNombre = A460ListaCostosNombre;
            Z471ListaCostosValor = A471ListaCostosValor;
         }
      }

      protected void standaloneNotModal1Q70( )
      {
         edtCentroCostosDetallesId_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
      }

      protected void standaloneModal1Q70( )
      {
         if ( IsIns( )  )
         {
            A465CentroCostosSerial = (long)(O465CentroCostosSerial+1);
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A466CentroCostosDetallesId = A465CentroCostosSerial;
         }
      }

      protected void Load1Q70( )
      {
         /* Using cursor T001Q23 */
         pr_default.execute(17, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound70 = 1;
            A473CentroCostosDetallesNombre = T001Q23_A473CentroCostosDetallesNombre[0];
            A468CentroCostosDetallesValor = T001Q23_A468CentroCostosDetallesValor[0];
            A460ListaCostosNombre = T001Q23_A460ListaCostosNombre[0];
            A471ListaCostosValor = T001Q23_A471ListaCostosValor[0];
            A459ListaCostosId = T001Q23_A459ListaCostosId[0];
            n459ListaCostosId = T001Q23_n459ListaCostosId[0];
            ZM1Q70( -31) ;
         }
         pr_default.close(17);
         OnLoadActions1Q70( ) ;
      }

      protected void OnLoadActions1Q70( )
      {
         if ( true /* After */ && IsIns( )  )
         {
            A473CentroCostosDetallesNombre = A460ListaCostosNombre;
         }
         if ( true /* After */ && IsIns( )  )
         {
            A468CentroCostosDetallesValor = A471ListaCostosValor;
         }
         if ( IsIns( )  )
         {
            A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor);
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor-O468CentroCostosDetallesValor);
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal-O468CentroCostosDetallesValor);
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
            }
         }
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
      }

      protected void CheckExtendedTable1Q70( )
      {
         nIsDirty_70 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1Q70( ) ;
         /* Using cursor T001Q4 */
         pr_default.execute(2, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A459ListaCostosId) ) )
            {
               GXCCtl = "LISTACOSTOSID_" + sGXsfl_93_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista de Costos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtListaCostosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A460ListaCostosNombre = T001Q4_A460ListaCostosNombre[0];
         A471ListaCostosValor = T001Q4_A471ListaCostosValor[0];
         pr_default.close(2);
         if ( true /* After */ && IsIns( )  )
         {
            nIsDirty_70 = 1;
            A473CentroCostosDetallesNombre = A460ListaCostosNombre;
         }
         if ( true /* After */ && IsIns( )  )
         {
            nIsDirty_70 = 1;
            A468CentroCostosDetallesValor = A471ListaCostosValor;
         }
         if ( IsIns( )  )
         {
            nIsDirty_70 = 1;
            A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor);
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_70 = 1;
               A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor-O468CentroCostosDetallesValor);
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_70 = 1;
                  A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal-O468CentroCostosDetallesValor);
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
            }
         }
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            nIsDirty_70 = 1;
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
      }

      protected void CloseExtendedTableCursors1Q70( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1Q70( )
      {
      }

      protected void gxLoad_32( long A459ListaCostosId )
      {
         /* Using cursor T001Q24 */
         pr_default.execute(18, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A459ListaCostosId) ) )
            {
               GXCCtl = "LISTACOSTOSID_" + sGXsfl_93_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista de Costos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtListaCostosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A460ListaCostosNombre = T001Q24_A460ListaCostosNombre[0];
         A471ListaCostosValor = T001Q24_A471ListaCostosValor[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A460ListaCostosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey1Q70( )
      {
         /* Using cursor T001Q25 */
         pr_default.execute(19, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey1Q70( )
      {
         /* Using cursor T001Q3 */
         pr_default.execute(1, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Q70( 31) ;
            RcdFound70 = 1;
            InitializeNonKey1Q70( ) ;
            A466CentroCostosDetallesId = T001Q3_A466CentroCostosDetallesId[0];
            A473CentroCostosDetallesNombre = T001Q3_A473CentroCostosDetallesNombre[0];
            A468CentroCostosDetallesValor = T001Q3_A468CentroCostosDetallesValor[0];
            A459ListaCostosId = T001Q3_A459ListaCostosId[0];
            n459ListaCostosId = T001Q3_n459ListaCostosId[0];
            O468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
            Z461CentroCostosId = A461CentroCostosId;
            Z466CentroCostosDetallesId = A466CentroCostosDetallesId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1Q70( ) ;
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey1Q70( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1Q70( ) ;
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1Q70( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1Q70( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Q2 */
            pr_default.execute(0, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostosDetalles"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z473CentroCostosDetallesNombre, T001Q2_A473CentroCostosDetallesNombre[0]) != 0 ) || ( Z468CentroCostosDetallesValor != T001Q2_A468CentroCostosDetallesValor[0] ) || ( Z459ListaCostosId != T001Q2_A459ListaCostosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z473CentroCostosDetallesNombre, T001Q2_A473CentroCostosDetallesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosDetallesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z473CentroCostosDetallesNombre);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A473CentroCostosDetallesNombre[0]);
               }
               if ( Z468CentroCostosDetallesValor != T001Q2_A468CentroCostosDetallesValor[0] )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"CentroCostosDetallesValor");
                  GXUtil.WriteLogRaw("Old: ",Z468CentroCostosDetallesValor);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A468CentroCostosDetallesValor[0]);
               }
               if ( Z459ListaCostosId != T001Q2_A459ListaCostosId[0] )
               {
                  GXUtil.WriteLog("centrocostos:[seudo value changed for attri]"+"ListaCostosId");
                  GXUtil.WriteLogRaw("Old: ",Z459ListaCostosId);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A459ListaCostosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CentroCostosDetalles"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q70( )
      {
         BeforeValidate1Q70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q70( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q70( 0) ;
            CheckOptimisticConcurrency1Q70( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q70( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q26 */
                     pr_default.execute(20, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId, A473CentroCostosDetallesNombre, A468CentroCostosDetallesValor, n459ListaCostosId, A459ListaCostosId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
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
               Load1Q70( ) ;
            }
            EndLevel1Q70( ) ;
         }
         CloseExtendedTableCursors1Q70( ) ;
      }

      protected void Update1Q70( )
      {
         BeforeValidate1Q70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q70( ) ;
         }
         if ( ( nIsMod_70 != 0 ) || ( nIsDirty_70 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1Q70( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1Q70( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1Q70( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001Q27 */
                        pr_default.execute(21, new Object[] {A473CentroCostosDetallesNombre, A468CentroCostosDetallesValor, n459ListaCostosId, A459ListaCostosId, A461CentroCostosId, A466CentroCostosDetallesId});
                        pr_default.close(21);
                        pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
                        if ( (pr_default.getStatus(21) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostosDetalles"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1Q70( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1Q70( ) ;
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
               EndLevel1Q70( ) ;
            }
         }
         CloseExtendedTableCursors1Q70( ) ;
      }

      protected void DeferredUpdate1Q70( )
      {
      }

      protected void Delete1Q70( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Q70( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q70( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q70( ) ;
            AfterConfirm1Q70( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q70( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Q28 */
                  pr_default.execute(22, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Q70( ) ;
         Gx_mode = sMode70;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Q70( )
      {
         standaloneModal1Q70( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001Q29 */
            pr_default.execute(23, new Object[] {n459ListaCostosId, A459ListaCostosId});
            A460ListaCostosNombre = T001Q29_A460ListaCostosNombre[0];
            A471ListaCostosValor = T001Q29_A471ListaCostosValor[0];
            pr_default.close(23);
            if ( IsIns( )  )
            {
               A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor);
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor-O468CentroCostosDetallesValor);
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal-O468CentroCostosDetallesValor);
                     n469CentroCostosSubTotal = false;
                     AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  }
               }
            }
            if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
            {
               A475CentroCostosCosto = A469CentroCostosSubTotal;
               AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            }
         }
      }

      protected void EndLevel1Q70( )
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

      public void ScanStart1Q70( )
      {
         /* Scan By routine */
         /* Using cursor T001Q30 */
         pr_default.execute(24, new Object[] {A461CentroCostosId});
         RcdFound70 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound70 = 1;
            A466CentroCostosDetallesId = T001Q30_A466CentroCostosDetallesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Q70( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound70 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound70 = 1;
            A466CentroCostosDetallesId = T001Q30_A466CentroCostosDetallesId[0];
         }
      }

      protected void ScanEnd1Q70( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm1Q70( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q70( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q70( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q70( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q70( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q70( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q70( )
      {
         edtCentroCostosDetallesId_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
         edtListaCostosId_Enabled = 0;
         AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
         edtCentroCostosDetallesNombre_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_93_Refreshing);
         edtCentroCostosDetallesValor_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_93_Refreshing);
      }

      protected void send_integrity_lvl_hashes1Q70( )
      {
      }

      protected void send_integrity_lvl_hashes1Q69( )
      {
      }

      protected void SubsflControlProps_9370( )
      {
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID_"+sGXsfl_93_idx;
         edtListaCostosId_Internalname = "LISTACOSTOSID_"+sGXsfl_93_idx;
         imgprompt_459_Internalname = "PROMPT_459_"+sGXsfl_93_idx;
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_idx;
         edtCentroCostosDetallesValor_Internalname = "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_idx;
      }

      protected void SubsflControlProps_fel_9370( )
      {
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID_"+sGXsfl_93_fel_idx;
         edtListaCostosId_Internalname = "LISTACOSTOSID_"+sGXsfl_93_fel_idx;
         imgprompt_459_Internalname = "PROMPT_459_"+sGXsfl_93_fel_idx;
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_fel_idx;
         edtCentroCostosDetallesValor_Internalname = "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_fel_idx;
      }

      protected void AddRow1Q70( )
      {
         nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_9370( ) ;
         SendRow1Q70( ) ;
      }

      protected void SendRow1Q70( )
      {
         Gridlevel_detallesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_detalles_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_detalles_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
            {
               subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Odd";
            }
         }
         else if ( subGridlevel_detalles_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_detalles_Backstyle = 0;
            subGridlevel_detalles_Backcolor = subGridlevel_detalles_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
            {
               subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Uniform";
            }
         }
         else if ( subGridlevel_detalles_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_detalles_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
            {
               subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Odd";
            }
            subGridlevel_detalles_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_detalles_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_detalles_Backstyle = 1;
            if ( ((int)((nGXsfl_93_idx) % (2))) == 0 )
            {
               subGridlevel_detalles_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
               {
                  subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Even";
               }
            }
            else
            {
               subGridlevel_detalles_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
               {
                  subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Odd";
               }
            }
         }
         imgprompt_459_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx01w0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LISTACOSTOSID_"+sGXsfl_93_idx+"'), id:'"+"LISTACOSTOSID_"+sGXsfl_93_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_70_"+sGXsfl_93_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_93_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_93_idx + "',93)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtCentroCostosDetallesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A466CentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A466CentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCentroCostosDetallesId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)93,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_93_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_93_idx + "',93)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtListaCostosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,95);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtListaCostosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)93,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_459_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_459_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_detallesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_459_Internalname,(string)sImgUrl,(string)imgprompt_459_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_459_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_93_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_93_idx + "',93)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesNombre_Internalname,StringUtil.RTrim( A473CentroCostosDetallesNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCentroCostosDetallesNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)93,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_93_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_93_idx + "',93)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtCentroCostosDetallesValor_Enabled!=0) ? context.localUtil.Format( A468CentroCostosDetallesValor, "ZZZZZZ9.99") : context.localUtil.Format( A468CentroCostosDetallesValor, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,97);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCentroCostosDetallesValor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)93,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_detallesRow);
         send_integrity_lvl_hashes1Q70( ) ;
         GXCCtl = "Z466CentroCostosDetallesId_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z473CentroCostosDetallesNombre_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z473CentroCostosDetallesNombre));
         GXCCtl = "Z468CentroCostosDetallesValor_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z459ListaCostosId_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "O468CentroCostosDetallesValor_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_70_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_70), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_70_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_70), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_70_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_70), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_93_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV10TrnContext);
         }
         GXCCtl = "vCENTROCOSTOSID_" + sGXsfl_93_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSID_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_459_"+sGXsfl_93_idx+"Link", StringUtil.RTrim( imgprompt_459_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_detallesContainer.AddRow(Gridlevel_detallesRow);
      }

      protected void ReadRow1Q70( )
      {
         nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_9370( ) ;
         edtCentroCostosDetallesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESID_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtListaCostosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LISTACOSTOSID_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCentroCostosDetallesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCentroCostosDetallesValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_93_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_459_Link = cgiGet( "PROMPT_459_"+sGXsfl_93_idx+"Link");
         A466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosDetallesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "LISTACOSTOSID_" + sGXsfl_93_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtListaCostosId_Internalname;
            wbErr = true;
            A459ListaCostosId = 0;
            n459ListaCostosId = false;
         }
         else
         {
            A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n459ListaCostosId = false;
         }
         n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
         A473CentroCostosDetallesNombre = cgiGet( edtCentroCostosDetallesNombre_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
         {
            GXCCtl = "CENTROCOSTOSDETALLESVALOR_" + sGXsfl_93_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCentroCostosDetallesValor_Internalname;
            wbErr = true;
            A468CentroCostosDetallesValor = 0;
         }
         else
         {
            A468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         GXCCtl = "Z466CentroCostosDetallesId_" + sGXsfl_93_idx;
         Z466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z473CentroCostosDetallesNombre_" + sGXsfl_93_idx;
         Z473CentroCostosDetallesNombre = cgiGet( GXCCtl);
         GXCCtl = "Z468CentroCostosDetallesValor_" + sGXsfl_93_idx;
         Z468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z459ListaCostosId_" + sGXsfl_93_idx;
         Z459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
         GXCCtl = "O468CentroCostosDetallesValor_" + sGXsfl_93_idx;
         O468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "nRcdDeleted_70_" + sGXsfl_93_idx;
         nRcdDeleted_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_70_" + sGXsfl_93_idx;
         nRcdExists_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_70_" + sGXsfl_93_idx;
         nIsMod_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtCentroCostosDetallesId_Enabled = edtCentroCostosDetallesId_Enabled;
      }

      protected void ConfirmValues1Q0( )
      {
         nGXsfl_93_idx = 0;
         sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
         SubsflControlProps_9370( ) ;
         while ( nGXsfl_93_idx < nRC_GXsfl_93 )
         {
            nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_9370( ) ;
            ChangePostValue( "Z466CentroCostosDetallesId_"+sGXsfl_93_idx, cgiGet( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_93_idx)) ;
            DeletePostValue( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_93_idx) ;
            ChangePostValue( "Z473CentroCostosDetallesNombre_"+sGXsfl_93_idx, cgiGet( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_93_idx)) ;
            DeletePostValue( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_93_idx) ;
            ChangePostValue( "Z468CentroCostosDetallesValor_"+sGXsfl_93_idx, cgiGet( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_93_idx)) ;
            DeletePostValue( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_93_idx) ;
            ChangePostValue( "Z459ListaCostosId_"+sGXsfl_93_idx, cgiGet( "ZT_"+"Z459ListaCostosId_"+sGXsfl_93_idx)) ;
            DeletePostValue( "ZT_"+"Z459ListaCostosId_"+sGXsfl_93_idx) ;
         }
         ChangePostValue( "O468CentroCostosDetallesValor", cgiGet( "T468CentroCostosDetallesValor")) ;
         DeletePostValue( "T468CentroCostosDetallesValor") ;
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
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CentroCostosId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CentroCostos");
         forbiddenHiddens.Add("CentroCostosId", context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("CentroCostosTipoRef", StringUtil.RTrim( context.localUtil.Format( A487CentroCostosTipoRef, "")));
         forbiddenHiddens.Add("CentroCostosUsrAlta", StringUtil.RTrim( context.localUtil.Format( A478CentroCostosUsrAlta, "")));
         forbiddenHiddens.Add("CentroCostosUsrMod", StringUtil.RTrim( context.localUtil.Format( A479CentroCostosUsrMod, "")));
         forbiddenHiddens.Add("CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
         forbiddenHiddens.Add("CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("centrocostos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z461CentroCostosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z475CentroCostosCosto", StringUtil.LTrim( StringUtil.NToC( Z475CentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z487CentroCostosTipoRef", StringUtil.RTrim( Z487CentroCostosTipoRef));
         GxWebStd.gx_hidden_field( context, "Z462CentroCostosRef", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z463CentroCostosNombre", StringUtil.RTrim( Z463CentroCostosNombre));
         GxWebStd.gx_hidden_field( context, "Z464CentroCostosPrecioFinal", StringUtil.LTrim( StringUtil.NToC( Z464CentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z465CentroCostosSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z478CentroCostosUsrAlta", StringUtil.RTrim( Z478CentroCostosUsrAlta));
         GxWebStd.gx_hidden_field( context, "Z479CentroCostosUsrMod", StringUtil.RTrim( Z479CentroCostosUsrMod));
         GxWebStd.gx_hidden_field( context, "Z480CentroCostosHoraAlt", context.localUtil.DToC( Z480CentroCostosHoraAlt, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z481CentroCostosHoraMod", context.localUtil.DToC( Z481CentroCostosHoraMod, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z482CentroCostosEstado", StringUtil.RTrim( Z482CentroCostosEstado));
         GxWebStd.gx_hidden_field( context, "O465CentroCostosSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O469CentroCostosSubTotal", StringUtil.LTrim( StringUtil.NToC( O469CentroCostosSubTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_93", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_93_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N462CentroCostosRef", StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N463CentroCostosNombre", StringUtil.RTrim( A463CentroCostosNombre));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vCENTROCOSTOSNOMBRE", StringUtil.RTrim( AV13CentroCostosNombre));
         GxWebStd.gx_hidden_field( context, "vCENTROCOSTOSPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV14CentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSSERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSNOMBRE", StringUtil.RTrim( A460ListaCostosNombre));
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSVALOR", StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CentroCostosId,18,0));
         return formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "CentroCostos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Centro de Costos", "") ;
      }

      protected void InitializeNonKey1Q69( )
      {
         AV13CentroCostosNombre = "";
         AssignAttri("", false, "AV13CentroCostosNombre", AV13CentroCostosNombre);
         AV14CentroCostosPrecioFinal = 0;
         AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
         A475CentroCostosCosto = 0;
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         A474CentroCostosGam = 0;
         AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         A462CentroCostosRef = 0;
         AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
         A463CentroCostosNombre = "";
         AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
         A464CentroCostosPrecioFinal = 0;
         AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
         A465CentroCostosSerial = 0;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         A469CentroCostosSubTotal = 0;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         A478CentroCostosUsrAlta = "";
         AssignAttri("", false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
         A479CentroCostosUsrMod = "";
         AssignAttri("", false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
         A480CentroCostosHoraAlt = DateTime.MinValue;
         AssignAttri("", false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
         A481CentroCostosHoraMod = DateTime.MinValue;
         AssignAttri("", false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
         A487CentroCostosTipoRef = context.GetMessage( "O", "");
         AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         A482CentroCostosEstado = context.GetMessage( "PND", "");
         AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
         O465CentroCostosSerial = A465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         O469CentroCostosSubTotal = A469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         Z475CentroCostosCosto = 0;
         Z487CentroCostosTipoRef = "";
         Z462CentroCostosRef = 0;
         Z463CentroCostosNombre = "";
         Z464CentroCostosPrecioFinal = 0;
         Z465CentroCostosSerial = 0;
         Z478CentroCostosUsrAlta = "";
         Z479CentroCostosUsrMod = "";
         Z480CentroCostosHoraAlt = DateTime.MinValue;
         Z481CentroCostosHoraMod = DateTime.MinValue;
         Z482CentroCostosEstado = "";
      }

      protected void InitAll1Q69( )
      {
         A461CentroCostosId = 0;
         AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         InitializeNonKey1Q69( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A487CentroCostosTipoRef = i487CentroCostosTipoRef;
         AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         A482CentroCostosEstado = i482CentroCostosEstado;
         AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
      }

      protected void InitializeNonKey1Q70( )
      {
         A473CentroCostosDetallesNombre = "";
         A468CentroCostosDetallesValor = 0;
         A459ListaCostosId = 0;
         n459ListaCostosId = false;
         A460ListaCostosNombre = "";
         AssignAttri("", false, "A460ListaCostosNombre", A460ListaCostosNombre);
         A471ListaCostosValor = 0;
         AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
         O468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
         Z473CentroCostosDetallesNombre = "";
         Z468CentroCostosDetallesValor = 0;
         Z459ListaCostosId = 0;
      }

      protected void InitAll1Q70( )
      {
         A466CentroCostosDetallesId = 0;
         InitializeNonKey1Q70( ) ;
      }

      protected void StandaloneModalInsert1Q70( )
      {
         A465CentroCostosSerial = i465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021141055", true, true, false);
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
         context.AddJavascriptSource("centrocostos.js", "?202673021141056", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties70( )
      {
         edtCentroCostosDetallesId_Enabled = defedtCentroCostosDetallesId_Enabled;
         AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_93_Refreshing);
      }

      protected void StartGridControl93( )
      {
         Gridlevel_detallesContainer.AddObjectProperty("GridName", "Gridlevel_detalles");
         Gridlevel_detallesContainer.AddObjectProperty("Header", subGridlevel_detalles_Header);
         Gridlevel_detallesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_detallesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_detallesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A473CentroCostosDetallesNombre)));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Selectedindex), 4, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Allowselection), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Allowhovering), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtCentroCostosId_Internalname = "CENTROCOSTOSID";
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF";
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF";
         edtCentroCostosNombre_Internalname = "CENTROCOSTOSNOMBRE";
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL";
         imgavNuevoitem_Internalname = "vNUEVOITEM";
         edtCentroCostosSubTotal_Internalname = "CENTROCOSTOSSUBTOTAL";
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO";
         edtCentroCostosGam_Internalname = "CENTROCOSTOSGAM";
         edtCentroCostosUsrAlta_Internalname = "CENTROCOSTOSUSRALTA";
         edtCentroCostosUsrMod_Internalname = "CENTROCOSTOSUSRMOD";
         edtCentroCostosHoraAlt_Internalname = "CENTROCOSTOSHORAALT";
         edtCentroCostosHoraMod_Internalname = "CENTROCOSTOSHORAMOD";
         cmbCentroCostosEstado_Internalname = "CENTROCOSTOSESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID";
         edtListaCostosId_Internalname = "LISTACOSTOSID";
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE";
         edtCentroCostosDetallesValor_Internalname = "CENTROCOSTOSDETALLESVALOR";
         divTableleaflevel_detalles_Internalname = "TABLELEAFLEVEL_DETALLES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_459_Internalname = "PROMPT_459";
         subGridlevel_detalles_Internalname = "GRIDLEVEL_DETALLES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_detalles_Allowcollapsing = 0;
         subGridlevel_detalles_Allowselection = 0;
         subGridlevel_detalles_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Centro de Costos", "");
         edtCentroCostosDetallesValor_Jsonclick = "";
         edtCentroCostosDetallesNombre_Jsonclick = "";
         imgprompt_459_Visible = 1;
         imgprompt_459_Link = "";
         imgprompt_459_Visible = 1;
         edtListaCostosId_Jsonclick = "";
         edtCentroCostosDetallesId_Jsonclick = "";
         subGridlevel_detalles_Class = "WorkWith";
         subGridlevel_detalles_Backcolorstyle = 0;
         edtCentroCostosDetallesValor_Enabled = 1;
         edtCentroCostosDetallesNombre_Enabled = 1;
         edtListaCostosId_Enabled = 1;
         edtCentroCostosDetallesId_Enabled = 0;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCentroCostosEstado_Jsonclick = "";
         cmbCentroCostosEstado.Enabled = 1;
         edtCentroCostosHoraMod_Jsonclick = "";
         edtCentroCostosHoraMod_Enabled = 0;
         edtCentroCostosHoraAlt_Jsonclick = "";
         edtCentroCostosHoraAlt_Enabled = 0;
         edtCentroCostosUsrMod_Jsonclick = "";
         edtCentroCostosUsrMod_Enabled = 0;
         edtCentroCostosUsrAlta_Jsonclick = "";
         edtCentroCostosUsrAlta_Enabled = 0;
         edtCentroCostosGam_Jsonclick = "";
         edtCentroCostosGam_Enabled = 0;
         edtCentroCostosGam_Visible = 1;
         edtCentroCostosCosto_Jsonclick = "";
         edtCentroCostosCosto_Enabled = 1;
         edtCentroCostosSubTotal_Jsonclick = "";
         edtCentroCostosSubTotal_Enabled = 0;
         imgavNuevoitem_gximage = "";
         imgavNuevoitem_Enabled = 0;
         imgavNuevoitem_Visible = 1;
         edtCentroCostosPrecioFinal_Jsonclick = "";
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosPrecioFinal_Visible = 1;
         edtCentroCostosNombre_Jsonclick = "";
         edtCentroCostosNombre_Enabled = 1;
         edtCentroCostosRef_Jsonclick = "";
         edtCentroCostosRef_Enabled = 1;
         cmbCentroCostosTipoRef_Jsonclick = "";
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosId_Jsonclick = "";
         edtCentroCostosId_Enabled = 0;
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

      protected void XC_19_1Q69( long A462CentroCostosRef ,
                                 string Gx_mode ,
                                 string A487CentroCostosTipoRef )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( "S", "")) == 0 ) )
         {
            new osoldat(context ).execute(  A462CentroCostosRef, out  AV13CentroCostosNombre, out  AV14CentroCostosPrecioFinal) ;
            AssignAttri("", false, "AV13CentroCostosNombre", AV13CentroCostosNombre);
            AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV13CentroCostosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( AV14CentroCostosPrecioFinal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_detalles_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_9370( ) ;
         while ( nGXsfl_93_idx <= nRC_GXsfl_93 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1Q70( ) ;
            standaloneModal1Q70( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1Q70( ) ;
            nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
            sGXsfl_93_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_93_idx), 4, 0), 4, "0");
            SubsflControlProps_9370( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_detallesContainer)) ;
         /* End function gxnrGridlevel_detalles_newrow */
      }

      protected void init_web_controls( )
      {
         cmbCentroCostosTipoRef.Name = "CENTROCOSTOSTIPOREF";
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A487CentroCostosTipoRef)) )
            {
               A487CentroCostosTipoRef = context.GetMessage( "O", "");
               AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            }
         }
         cmbCentroCostosEstado.Name = "CENTROCOSTOSESTADO";
         cmbCentroCostosEstado.WebTags = "";
         cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
         if ( cmbCentroCostosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A482CentroCostosEstado)) )
            {
               A482CentroCostosEstado = context.GetMessage( "PND", "");
               AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
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

      public void Valid_Centrocostosid( )
      {
         n469CentroCostosSubTotal = false;
         /* Using cursor T001Q20 */
         pr_default.execute(14, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A469CentroCostosSubTotal = T001Q20_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T001Q20_n469CentroCostosSubTotal[0];
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
         }
         pr_default.close(14);
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
         }
         if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
         {
            A464CentroCostosPrecioFinal = AV14CentroCostosPrecioFinal;
         }
         if ( (Convert.ToDecimal( A462CentroCostosRef ) != AV14CentroCostosPrecioFinal ) && ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && true /* After */ )
         {
            A463CentroCostosNombre = AV13CentroCostosNombre;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 18, 2, ".", "")));
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 18, 2, ".", "")));
         AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 18, 2, ".", "")));
         AssignAttri("", false, "A463CentroCostosNombre", StringUtil.RTrim( A463CentroCostosNombre));
      }

      public void Valid_Centrocostosref( )
      {
         A487CentroCostosTipoRef = cmbCentroCostosTipoRef.CurrentValue;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, context.GetMessage( "S", "")) == 0 ) )
         {
            new osoldat(context ).execute(  A462CentroCostosRef, out  AV13CentroCostosNombre, out  AV14CentroCostosPrecioFinal) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "AV13CentroCostosNombre", StringUtil.RTrim( AV13CentroCostosNombre));
         AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrim( StringUtil.NToC( AV14CentroCostosPrecioFinal, 18, 2, ".", "")));
      }

      public void Valid_Listacostosid( )
      {
         n459ListaCostosId = false;
         /* Using cursor T001Q29 */
         pr_default.execute(23, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A459ListaCostosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista de Costos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTACOSTOSID");
               AnyError = 1;
               GX_FocusControl = edtListaCostosId_Internalname;
            }
         }
         A460ListaCostosNombre = T001Q29_A460ListaCostosNombre[0];
         A471ListaCostosValor = T001Q29_A471ListaCostosValor[0];
         pr_default.close(23);
         if ( true /* After */ && IsIns( )  )
         {
            A473CentroCostosDetallesNombre = A460ListaCostosNombre;
         }
         if ( true /* After */ && IsIns( )  )
         {
            A468CentroCostosDetallesValor = A471ListaCostosValor;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A460ListaCostosNombre", StringUtil.RTrim( A460ListaCostosNombre));
         AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, ".", "")));
         AssignAttri("", false, "A473CentroCostosDetallesNombre", StringUtil.RTrim( A473CentroCostosDetallesNombre));
         AssignAttri("", false, "A468CentroCostosDetallesValor", StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7CentroCostosId',fld:'vCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CentroCostosId',fld:'vCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbCentroCostosTipoRef'},{av:'A487CentroCostosTipoRef',fld:'CENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'A478CentroCostosUsrAlta',fld:'CENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'A479CentroCostosUsrMod',fld:'CENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'A480CentroCostosHoraAlt',fld:'CENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'A481CentroCostosHoraMod',fld:'CENTROCOSTOSHORAMOD',pic:'',type:'date'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121Q2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSID","{handler:'Valid_Centrocostosid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A469CentroCostosSubTotal',fld:'CENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A475CentroCostosCosto',fld:'CENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A464CentroCostosPrecioFinal',fld:'CENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A463CentroCostosNombre',fld:'CENTROCOSTOSNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_CENTROCOSTOSID",",oparms:[{av:'A469CentroCostosSubTotal',fld:'CENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A475CentroCostosCosto',fld:'CENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A464CentroCostosPrecioFinal',fld:'CENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A463CentroCostosNombre',fld:'CENTROCOSTOSNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_CENTROCOSTOSTIPOREF","{handler:'Valid_Centrocostostiporef',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSTIPOREF",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSREF","{handler:'Valid_Centrocostosref',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbCentroCostosTipoRef'},{av:'A487CentroCostosTipoRef',fld:'CENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'AV13CentroCostosNombre',fld:'vCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV14CentroCostosPrecioFinal',fld:'vCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("VALID_CENTROCOSTOSREF",",oparms:[{av:'AV13CentroCostosNombre',fld:'vCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV14CentroCostosPrecioFinal',fld:'vCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]}");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL","{handler:'Valid_Centrocostospreciofinal',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSSUBTOTAL","{handler:'Valid_Centrocostossubtotal',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSSUBTOTAL",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO","{handler:'Valid_Centrocostoscosto',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESID","{handler:'Valid_Centrocostosdetallesid',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESID",",oparms:[]}");
         setEventMetadata("VALID_LISTACOSTOSID","{handler:'Valid_Listacostosid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A459ListaCostosId',fld:'LISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A460ListaCostosNombre',fld:'LISTACOSTOSNOMBRE',pic:'',type:'char'},{av:'A471ListaCostosValor',fld:'LISTACOSTOSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A473CentroCostosDetallesNombre',fld:'CENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'A468CentroCostosDetallesValor',fld:'CENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("VALID_LISTACOSTOSID",",oparms:[{av:'A460ListaCostosNombre',fld:'LISTACOSTOSNOMBRE',pic:'',type:'char'},{av:'A471ListaCostosValor',fld:'LISTACOSTOSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A473CentroCostosDetallesNombre',fld:'CENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'A468CentroCostosDetallesValor',fld:'CENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESVALOR","{handler:'Valid_Centrocostosdetallesvalor',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESVALOR",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(4);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z487CentroCostosTipoRef = "";
         Z463CentroCostosNombre = "";
         Z478CentroCostosUsrAlta = "";
         Z479CentroCostosUsrMod = "";
         Z480CentroCostosHoraAlt = DateTime.MinValue;
         Z481CentroCostosHoraMod = DateTime.MinValue;
         Z482CentroCostosEstado = "";
         N463CentroCostosNombre = "";
         Z473CentroCostosDetallesNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A487CentroCostosTipoRef = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A482CentroCostosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A463CentroCostosNombre = "";
         sImgUrl = "";
         AV15NuevoItem = "";
         A478CentroCostosUsrAlta = "";
         A479CentroCostosUsrMod = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         A481CentroCostosHoraMod = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_detallesContainer = new GXWebGrid( context);
         sMode70 = "";
         sStyleString = "";
         AV13CentroCostosNombre = "";
         AV24Pgmname = "";
         A460ListaCostosNombre = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode69 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A473CentroCostosDetallesNombre = "";
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         T001Q8_A469CentroCostosSubTotal = new decimal[1] ;
         T001Q8_n469CentroCostosSubTotal = new bool[] {false} ;
         T001Q10_A461CentroCostosId = new long[1] ;
         T001Q10_A475CentroCostosCosto = new decimal[1] ;
         T001Q10_A487CentroCostosTipoRef = new string[] {""} ;
         T001Q10_A462CentroCostosRef = new long[1] ;
         T001Q10_A463CentroCostosNombre = new string[] {""} ;
         T001Q10_A464CentroCostosPrecioFinal = new decimal[1] ;
         T001Q10_A465CentroCostosSerial = new long[1] ;
         T001Q10_A478CentroCostosUsrAlta = new string[] {""} ;
         T001Q10_A479CentroCostosUsrMod = new string[] {""} ;
         T001Q10_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         T001Q10_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         T001Q10_A482CentroCostosEstado = new string[] {""} ;
         T001Q10_A469CentroCostosSubTotal = new decimal[1] ;
         T001Q10_n469CentroCostosSubTotal = new bool[] {false} ;
         T001Q12_A469CentroCostosSubTotal = new decimal[1] ;
         T001Q12_n469CentroCostosSubTotal = new bool[] {false} ;
         T001Q13_A461CentroCostosId = new long[1] ;
         T001Q6_A461CentroCostosId = new long[1] ;
         T001Q6_A475CentroCostosCosto = new decimal[1] ;
         T001Q6_A487CentroCostosTipoRef = new string[] {""} ;
         T001Q6_A462CentroCostosRef = new long[1] ;
         T001Q6_A463CentroCostosNombre = new string[] {""} ;
         T001Q6_A464CentroCostosPrecioFinal = new decimal[1] ;
         T001Q6_A465CentroCostosSerial = new long[1] ;
         T001Q6_A478CentroCostosUsrAlta = new string[] {""} ;
         T001Q6_A479CentroCostosUsrMod = new string[] {""} ;
         T001Q6_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         T001Q6_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         T001Q6_A482CentroCostosEstado = new string[] {""} ;
         T001Q14_A461CentroCostosId = new long[1] ;
         T001Q15_A461CentroCostosId = new long[1] ;
         T001Q5_A461CentroCostosId = new long[1] ;
         T001Q5_A475CentroCostosCosto = new decimal[1] ;
         T001Q5_A487CentroCostosTipoRef = new string[] {""} ;
         T001Q5_A462CentroCostosRef = new long[1] ;
         T001Q5_A463CentroCostosNombre = new string[] {""} ;
         T001Q5_A464CentroCostosPrecioFinal = new decimal[1] ;
         T001Q5_A465CentroCostosSerial = new long[1] ;
         T001Q5_A478CentroCostosUsrAlta = new string[] {""} ;
         T001Q5_A479CentroCostosUsrMod = new string[] {""} ;
         T001Q5_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         T001Q5_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         T001Q5_A482CentroCostosEstado = new string[] {""} ;
         T001Q16_A461CentroCostosId = new long[1] ;
         T001Q20_A469CentroCostosSubTotal = new decimal[1] ;
         T001Q20_n469CentroCostosSubTotal = new bool[] {false} ;
         T001Q22_A461CentroCostosId = new long[1] ;
         Z460ListaCostosNombre = "";
         T001Q23_A461CentroCostosId = new long[1] ;
         T001Q23_A466CentroCostosDetallesId = new long[1] ;
         T001Q23_A473CentroCostosDetallesNombre = new string[] {""} ;
         T001Q23_A468CentroCostosDetallesValor = new decimal[1] ;
         T001Q23_A460ListaCostosNombre = new string[] {""} ;
         T001Q23_A471ListaCostosValor = new decimal[1] ;
         T001Q23_A459ListaCostosId = new long[1] ;
         T001Q23_n459ListaCostosId = new bool[] {false} ;
         T001Q4_A460ListaCostosNombre = new string[] {""} ;
         T001Q4_A471ListaCostosValor = new decimal[1] ;
         GXCCtl = "";
         T001Q24_A460ListaCostosNombre = new string[] {""} ;
         T001Q24_A471ListaCostosValor = new decimal[1] ;
         T001Q25_A461CentroCostosId = new long[1] ;
         T001Q25_A466CentroCostosDetallesId = new long[1] ;
         T001Q3_A461CentroCostosId = new long[1] ;
         T001Q3_A466CentroCostosDetallesId = new long[1] ;
         T001Q3_A473CentroCostosDetallesNombre = new string[] {""} ;
         T001Q3_A468CentroCostosDetallesValor = new decimal[1] ;
         T001Q3_A459ListaCostosId = new long[1] ;
         T001Q3_n459ListaCostosId = new bool[] {false} ;
         T001Q2_A461CentroCostosId = new long[1] ;
         T001Q2_A466CentroCostosDetallesId = new long[1] ;
         T001Q2_A473CentroCostosDetallesNombre = new string[] {""} ;
         T001Q2_A468CentroCostosDetallesValor = new decimal[1] ;
         T001Q2_A459ListaCostosId = new long[1] ;
         T001Q2_n459ListaCostosId = new bool[] {false} ;
         T001Q29_A460ListaCostosNombre = new string[] {""} ;
         T001Q29_A471ListaCostosValor = new decimal[1] ;
         T001Q30_A461CentroCostosId = new long[1] ;
         T001Q30_A466CentroCostosDetallesId = new long[1] ;
         Gridlevel_detallesRow = new GXWebRow();
         subGridlevel_detalles_Linesclass = "";
         ROClassString = "";
         imgprompt_459_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i487CentroCostosTipoRef = "";
         i482CentroCostosEstado = "";
         Gridlevel_detallesColumn = new GXWebColumn();
         ZV13CentroCostosNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.centrocostos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostos__default(),
            new Object[][] {
                new Object[] {
               T001Q2_A461CentroCostosId, T001Q2_A466CentroCostosDetallesId, T001Q2_A473CentroCostosDetallesNombre, T001Q2_A468CentroCostosDetallesValor, T001Q2_A459ListaCostosId, T001Q2_n459ListaCostosId
               }
               , new Object[] {
               T001Q3_A461CentroCostosId, T001Q3_A466CentroCostosDetallesId, T001Q3_A473CentroCostosDetallesNombre, T001Q3_A468CentroCostosDetallesValor, T001Q3_A459ListaCostosId, T001Q3_n459ListaCostosId
               }
               , new Object[] {
               T001Q4_A460ListaCostosNombre, T001Q4_A471ListaCostosValor
               }
               , new Object[] {
               T001Q5_A461CentroCostosId, T001Q5_A475CentroCostosCosto, T001Q5_A487CentroCostosTipoRef, T001Q5_A462CentroCostosRef, T001Q5_A463CentroCostosNombre, T001Q5_A464CentroCostosPrecioFinal, T001Q5_A465CentroCostosSerial, T001Q5_A478CentroCostosUsrAlta, T001Q5_A479CentroCostosUsrMod, T001Q5_A480CentroCostosHoraAlt,
               T001Q5_A481CentroCostosHoraMod, T001Q5_A482CentroCostosEstado
               }
               , new Object[] {
               T001Q6_A461CentroCostosId, T001Q6_A475CentroCostosCosto, T001Q6_A487CentroCostosTipoRef, T001Q6_A462CentroCostosRef, T001Q6_A463CentroCostosNombre, T001Q6_A464CentroCostosPrecioFinal, T001Q6_A465CentroCostosSerial, T001Q6_A478CentroCostosUsrAlta, T001Q6_A479CentroCostosUsrMod, T001Q6_A480CentroCostosHoraAlt,
               T001Q6_A481CentroCostosHoraMod, T001Q6_A482CentroCostosEstado
               }
               , new Object[] {
               T001Q8_A469CentroCostosSubTotal, T001Q8_n469CentroCostosSubTotal
               }
               , new Object[] {
               T001Q10_A461CentroCostosId, T001Q10_A475CentroCostosCosto, T001Q10_A487CentroCostosTipoRef, T001Q10_A462CentroCostosRef, T001Q10_A463CentroCostosNombre, T001Q10_A464CentroCostosPrecioFinal, T001Q10_A465CentroCostosSerial, T001Q10_A478CentroCostosUsrAlta, T001Q10_A479CentroCostosUsrMod, T001Q10_A480CentroCostosHoraAlt,
               T001Q10_A481CentroCostosHoraMod, T001Q10_A482CentroCostosEstado, T001Q10_A469CentroCostosSubTotal, T001Q10_n469CentroCostosSubTotal
               }
               , new Object[] {
               T001Q12_A469CentroCostosSubTotal, T001Q12_n469CentroCostosSubTotal
               }
               , new Object[] {
               T001Q13_A461CentroCostosId
               }
               , new Object[] {
               T001Q14_A461CentroCostosId
               }
               , new Object[] {
               T001Q15_A461CentroCostosId
               }
               , new Object[] {
               T001Q16_A461CentroCostosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q20_A469CentroCostosSubTotal, T001Q20_n469CentroCostosSubTotal
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q22_A461CentroCostosId
               }
               , new Object[] {
               T001Q23_A461CentroCostosId, T001Q23_A466CentroCostosDetallesId, T001Q23_A473CentroCostosDetallesNombre, T001Q23_A468CentroCostosDetallesValor, T001Q23_A460ListaCostosNombre, T001Q23_A471ListaCostosValor, T001Q23_A459ListaCostosId, T001Q23_n459ListaCostosId
               }
               , new Object[] {
               T001Q24_A460ListaCostosNombre, T001Q24_A471ListaCostosValor
               }
               , new Object[] {
               T001Q25_A461CentroCostosId, T001Q25_A466CentroCostosDetallesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q29_A460ListaCostosNombre, T001Q29_A471ListaCostosValor
               }
               , new Object[] {
               T001Q30_A461CentroCostosId, T001Q30_A466CentroCostosDetallesId
               }
            }
         );
         AV24Pgmname = "CentroCostos";
         Z482CentroCostosEstado = context.GetMessage( "PND", "");
         A482CentroCostosEstado = context.GetMessage( "PND", "");
         i482CentroCostosEstado = context.GetMessage( "PND", "");
         Z487CentroCostosTipoRef = context.GetMessage( "O", "");
         i487CentroCostosTipoRef = context.GetMessage( "O", "");
         A487CentroCostosTipoRef = context.GetMessage( "O", "");
      }

      private short nIsMod_70 ;
      private short nRcdDeleted_70 ;
      private short nRcdExists_70 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount70 ;
      private short RcdFound70 ;
      private short nBlankRcdUsr70 ;
      private short RcdFound69 ;
      private short nIsDirty_70 ;
      private short subGridlevel_detalles_Backcolorstyle ;
      private short subGridlevel_detalles_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_detalles_Allowselection ;
      private short subGridlevel_detalles_Allowhovering ;
      private short subGridlevel_detalles_Allowcollapsing ;
      private short subGridlevel_detalles_Collapsed ;
      private int nRC_GXsfl_93 ;
      private int nGXsfl_93_idx=1 ;
      private int trnEnded ;
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtCentroCostosNombre_Enabled ;
      private int edtCentroCostosPrecioFinal_Visible ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int imgavNuevoitem_Visible ;
      private int imgavNuevoitem_Enabled ;
      private int edtCentroCostosSubTotal_Enabled ;
      private int edtCentroCostosCosto_Enabled ;
      private int edtCentroCostosGam_Visible ;
      private int edtCentroCostosGam_Enabled ;
      private int edtCentroCostosUsrAlta_Enabled ;
      private int edtCentroCostosUsrMod_Enabled ;
      private int edtCentroCostosHoraAlt_Enabled ;
      private int edtCentroCostosHoraMod_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCentroCostosDetallesId_Enabled ;
      private int edtListaCostosId_Enabled ;
      private int edtCentroCostosDetallesNombre_Enabled ;
      private int edtCentroCostosDetallesValor_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_detalles_Backcolor ;
      private int subGridlevel_detalles_Allbackcolor ;
      private int imgprompt_459_Visible ;
      private int defedtCentroCostosDetallesId_Enabled ;
      private int idxLst ;
      private int subGridlevel_detalles_Selectedindex ;
      private int subGridlevel_detalles_Selectioncolor ;
      private int subGridlevel_detalles_Hoveringcolor ;
      private long wcpOAV7CentroCostosId ;
      private long Z461CentroCostosId ;
      private long Z462CentroCostosRef ;
      private long Z465CentroCostosSerial ;
      private long O465CentroCostosSerial ;
      private long N462CentroCostosRef ;
      private long Z466CentroCostosDetallesId ;
      private long Z459ListaCostosId ;
      private long A462CentroCostosRef ;
      private long A461CentroCostosId ;
      private long A459ListaCostosId ;
      private long AV7CentroCostosId ;
      private long A465CentroCostosSerial ;
      private long B465CentroCostosSerial ;
      private long GRIDLEVEL_DETALLES_nFirstRecordOnPage ;
      private long s465CentroCostosSerial ;
      private long A466CentroCostosDetallesId ;
      private long i465CentroCostosSerial ;
      private decimal Z475CentroCostosCosto ;
      private decimal Z464CentroCostosPrecioFinal ;
      private decimal O469CentroCostosSubTotal ;
      private decimal Z468CentroCostosDetallesValor ;
      private decimal O468CentroCostosDetallesValor ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A469CentroCostosSubTotal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private decimal B469CentroCostosSubTotal ;
      private decimal AV14CentroCostosPrecioFinal ;
      private decimal A471ListaCostosValor ;
      private decimal s469CentroCostosSubTotal ;
      private decimal A468CentroCostosDetallesValor ;
      private decimal T468CentroCostosDetallesValor ;
      private decimal Z469CentroCostosSubTotal ;
      private decimal Z471ListaCostosValor ;
      private decimal ZV14CentroCostosPrecioFinal ;
      private string sPrefix ;
      private string sGXsfl_93_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z487CentroCostosTipoRef ;
      private string Z463CentroCostosNombre ;
      private string Z478CentroCostosUsrAlta ;
      private string Z479CentroCostosUsrMod ;
      private string Z482CentroCostosEstado ;
      private string N463CentroCostosNombre ;
      private string Z473CentroCostosDetallesNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string A487CentroCostosTipoRef ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCentroCostosRef_Internalname ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string A482CentroCostosEstado ;
      private string cmbCentroCostosEstado_Internalname ;
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
      private string edtCentroCostosId_Internalname ;
      private string TempTags ;
      private string edtCentroCostosId_Jsonclick ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtCentroCostosNombre_Internalname ;
      private string A463CentroCostosNombre ;
      private string edtCentroCostosNombre_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Internalname ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string imgavNuevoitem_Internalname ;
      private string imgavNuevoitem_gximage ;
      private string sImgUrl ;
      private string edtCentroCostosSubTotal_Internalname ;
      private string edtCentroCostosSubTotal_Jsonclick ;
      private string edtCentroCostosCosto_Internalname ;
      private string edtCentroCostosCosto_Jsonclick ;
      private string edtCentroCostosGam_Internalname ;
      private string edtCentroCostosGam_Jsonclick ;
      private string edtCentroCostosUsrAlta_Internalname ;
      private string A478CentroCostosUsrAlta ;
      private string edtCentroCostosUsrAlta_Jsonclick ;
      private string edtCentroCostosUsrMod_Internalname ;
      private string A479CentroCostosUsrMod ;
      private string edtCentroCostosUsrMod_Jsonclick ;
      private string edtCentroCostosHoraAlt_Internalname ;
      private string edtCentroCostosHoraAlt_Jsonclick ;
      private string edtCentroCostosHoraMod_Internalname ;
      private string edtCentroCostosHoraMod_Jsonclick ;
      private string cmbCentroCostosEstado_Jsonclick ;
      private string divTableleaflevel_detalles_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode70 ;
      private string edtCentroCostosDetallesId_Internalname ;
      private string edtListaCostosId_Internalname ;
      private string edtCentroCostosDetallesNombre_Internalname ;
      private string edtCentroCostosDetallesValor_Internalname ;
      private string imgprompt_459_Link ;
      private string sStyleString ;
      private string subGridlevel_detalles_Internalname ;
      private string AV13CentroCostosNombre ;
      private string AV24Pgmname ;
      private string A460ListaCostosNombre ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode69 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A473CentroCostosDetallesNombre ;
      private string GXEncryptionTmp ;
      private string Z460ListaCostosNombre ;
      private string GXCCtl ;
      private string imgprompt_459_Internalname ;
      private string sGXsfl_93_fel_idx="0001" ;
      private string subGridlevel_detalles_Class ;
      private string subGridlevel_detalles_Linesclass ;
      private string ROClassString ;
      private string edtCentroCostosDetallesId_Jsonclick ;
      private string edtListaCostosId_Jsonclick ;
      private string imgprompt_459_gximage ;
      private string edtCentroCostosDetallesNombre_Jsonclick ;
      private string edtCentroCostosDetallesValor_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i487CentroCostosTipoRef ;
      private string i482CentroCostosEstado ;
      private string subGridlevel_detalles_Header ;
      private string ZV13CentroCostosNombre ;
      private DateTime Z480CentroCostosHoraAlt ;
      private DateTime Z481CentroCostosHoraMod ;
      private DateTime A480CentroCostosHoraAlt ;
      private DateTime A481CentroCostosHoraMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n459ListaCostosId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n469CentroCostosSubTotal ;
      private bool bGXsfl_93_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string AV15NuevoItem ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_detallesContainer ;
      private GXWebRow Gridlevel_detallesRow ;
      private GXWebColumn Gridlevel_detallesColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private GXCombobox cmbCentroCostosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private decimal[] T001Q8_A469CentroCostosSubTotal ;
      private bool[] T001Q8_n469CentroCostosSubTotal ;
      private long[] T001Q10_A461CentroCostosId ;
      private decimal[] T001Q10_A475CentroCostosCosto ;
      private string[] T001Q10_A487CentroCostosTipoRef ;
      private long[] T001Q10_A462CentroCostosRef ;
      private string[] T001Q10_A463CentroCostosNombre ;
      private decimal[] T001Q10_A464CentroCostosPrecioFinal ;
      private long[] T001Q10_A465CentroCostosSerial ;
      private string[] T001Q10_A478CentroCostosUsrAlta ;
      private string[] T001Q10_A479CentroCostosUsrMod ;
      private DateTime[] T001Q10_A480CentroCostosHoraAlt ;
      private DateTime[] T001Q10_A481CentroCostosHoraMod ;
      private string[] T001Q10_A482CentroCostosEstado ;
      private decimal[] T001Q10_A469CentroCostosSubTotal ;
      private bool[] T001Q10_n469CentroCostosSubTotal ;
      private decimal[] T001Q12_A469CentroCostosSubTotal ;
      private bool[] T001Q12_n469CentroCostosSubTotal ;
      private long[] T001Q13_A461CentroCostosId ;
      private long[] T001Q6_A461CentroCostosId ;
      private decimal[] T001Q6_A475CentroCostosCosto ;
      private string[] T001Q6_A487CentroCostosTipoRef ;
      private long[] T001Q6_A462CentroCostosRef ;
      private string[] T001Q6_A463CentroCostosNombre ;
      private decimal[] T001Q6_A464CentroCostosPrecioFinal ;
      private long[] T001Q6_A465CentroCostosSerial ;
      private string[] T001Q6_A478CentroCostosUsrAlta ;
      private string[] T001Q6_A479CentroCostosUsrMod ;
      private DateTime[] T001Q6_A480CentroCostosHoraAlt ;
      private DateTime[] T001Q6_A481CentroCostosHoraMod ;
      private string[] T001Q6_A482CentroCostosEstado ;
      private long[] T001Q14_A461CentroCostosId ;
      private long[] T001Q15_A461CentroCostosId ;
      private long[] T001Q5_A461CentroCostosId ;
      private decimal[] T001Q5_A475CentroCostosCosto ;
      private string[] T001Q5_A487CentroCostosTipoRef ;
      private long[] T001Q5_A462CentroCostosRef ;
      private string[] T001Q5_A463CentroCostosNombre ;
      private decimal[] T001Q5_A464CentroCostosPrecioFinal ;
      private long[] T001Q5_A465CentroCostosSerial ;
      private string[] T001Q5_A478CentroCostosUsrAlta ;
      private string[] T001Q5_A479CentroCostosUsrMod ;
      private DateTime[] T001Q5_A480CentroCostosHoraAlt ;
      private DateTime[] T001Q5_A481CentroCostosHoraMod ;
      private string[] T001Q5_A482CentroCostosEstado ;
      private long[] T001Q16_A461CentroCostosId ;
      private decimal[] T001Q20_A469CentroCostosSubTotal ;
      private bool[] T001Q20_n469CentroCostosSubTotal ;
      private long[] T001Q22_A461CentroCostosId ;
      private long[] T001Q23_A461CentroCostosId ;
      private long[] T001Q23_A466CentroCostosDetallesId ;
      private string[] T001Q23_A473CentroCostosDetallesNombre ;
      private decimal[] T001Q23_A468CentroCostosDetallesValor ;
      private string[] T001Q23_A460ListaCostosNombre ;
      private decimal[] T001Q23_A471ListaCostosValor ;
      private long[] T001Q23_A459ListaCostosId ;
      private bool[] T001Q23_n459ListaCostosId ;
      private string[] T001Q4_A460ListaCostosNombre ;
      private decimal[] T001Q4_A471ListaCostosValor ;
      private string[] T001Q24_A460ListaCostosNombre ;
      private decimal[] T001Q24_A471ListaCostosValor ;
      private long[] T001Q25_A461CentroCostosId ;
      private long[] T001Q25_A466CentroCostosDetallesId ;
      private long[] T001Q3_A461CentroCostosId ;
      private long[] T001Q3_A466CentroCostosDetallesId ;
      private string[] T001Q3_A473CentroCostosDetallesNombre ;
      private decimal[] T001Q3_A468CentroCostosDetallesValor ;
      private long[] T001Q3_A459ListaCostosId ;
      private bool[] T001Q3_n459ListaCostosId ;
      private long[] T001Q2_A461CentroCostosId ;
      private long[] T001Q2_A466CentroCostosDetallesId ;
      private string[] T001Q2_A473CentroCostosDetallesNombre ;
      private decimal[] T001Q2_A468CentroCostosDetallesValor ;
      private long[] T001Q2_A459ListaCostosId ;
      private bool[] T001Q2_n459ListaCostosId ;
      private string[] T001Q29_A460ListaCostosNombre ;
      private decimal[] T001Q29_A471ListaCostosValor ;
      private long[] T001Q30_A461CentroCostosId ;
      private long[] T001Q30_A466CentroCostosDetallesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class centrocostos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class centrocostos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001Q2;
        prmT001Q2 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q3;
        prmT001Q3 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q4;
        prmT001Q4 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001Q5;
        prmT001Q5 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q6;
        prmT001Q6 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q8;
        prmT001Q8 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q10;
        prmT001Q10 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q12;
        prmT001Q12 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q13;
        prmT001Q13 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q14;
        prmT001Q14 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q15;
        prmT001Q15 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q16;
        prmT001Q16 = new Object[] {
        new ParDef("@CentroCostosCosto",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosTipoRef",GXType.NChar,1,0) ,
        new ParDef("@CentroCostosRef",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosSerial",GXType.Decimal,10,0) ,
        new ParDef("@CentroCostosUsrAlta",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosUsrMod",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosHoraAlt",GXType.Date,8,0) ,
        new ParDef("@CentroCostosHoraMod",GXType.Date,8,0) ,
        new ParDef("@CentroCostosEstado",GXType.NChar,3,0)
        };
        Object[] prmT001Q17;
        prmT001Q17 = new Object[] {
        new ParDef("@CentroCostosCosto",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosTipoRef",GXType.NChar,1,0) ,
        new ParDef("@CentroCostosRef",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosSerial",GXType.Decimal,10,0) ,
        new ParDef("@CentroCostosUsrAlta",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosUsrMod",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosHoraAlt",GXType.Date,8,0) ,
        new ParDef("@CentroCostosHoraMod",GXType.Date,8,0) ,
        new ParDef("@CentroCostosEstado",GXType.NChar,3,0) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q18;
        prmT001Q18 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q20;
        prmT001Q20 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q21;
        prmT001Q21 = new Object[] {
        new ParDef("@CentroCostosSerial",GXType.Decimal,10,0) ,
        new ParDef("@CentroCostosCosto",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q22;
        prmT001Q22 = new Object[] {
        };
        Object[] prmT001Q23;
        prmT001Q23 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q24;
        prmT001Q24 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001Q25;
        prmT001Q25 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q26;
        prmT001Q26 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosDetallesValor",GXType.Decimal,10,2) ,
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001Q27;
        prmT001Q27 = new Object[] {
        new ParDef("@CentroCostosDetallesNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosDetallesValor",GXType.Decimal,10,2) ,
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q28;
        prmT001Q28 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT001Q29;
        prmT001Q29 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001Q30;
        prmT001Q30 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001Q2", "SELECT [CentroCostosId], [CentroCostosDetallesId], [CentroCostosDetallesNombre], [CentroCostosDetallesValor], [ListaCostosId] FROM [CentroCostosDetalles] WITH (UPDLOCK) WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q3", "SELECT [CentroCostosId], [CentroCostosDetallesId], [CentroCostosDetallesNombre], [CentroCostosDetallesValor], [ListaCostosId] FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q4", "SELECT [ListaCostosNombre], [ListaCostosValor] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q5", "SELECT [CentroCostosId], [CentroCostosCosto], [CentroCostosTipoRef], [CentroCostosRef], [CentroCostosNombre], [CentroCostosPrecioFinal], [CentroCostosSerial], [CentroCostosUsrAlta], [CentroCostosUsrMod], [CentroCostosHoraAlt], [CentroCostosHoraMod], [CentroCostosEstado] FROM [CentroCostos] WITH (UPDLOCK) WHERE [CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q6", "SELECT [CentroCostosId], [CentroCostosCosto], [CentroCostosTipoRef], [CentroCostosRef], [CentroCostosNombre], [CentroCostosPrecioFinal], [CentroCostosSerial], [CentroCostosUsrAlta], [CentroCostosUsrMod], [CentroCostosHoraAlt], [CentroCostosHoraMod], [CentroCostosEstado] FROM [CentroCostos] WHERE [CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q8", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q10", "SELECT TM1.[CentroCostosId], TM1.[CentroCostosCosto], TM1.[CentroCostosTipoRef], TM1.[CentroCostosRef], TM1.[CentroCostosNombre], TM1.[CentroCostosPrecioFinal], TM1.[CentroCostosSerial], TM1.[CentroCostosUsrAlta], TM1.[CentroCostosUsrMod], TM1.[CentroCostosHoraAlt], TM1.[CentroCostosHoraMod], TM1.[CentroCostosEstado], COALESCE( T2.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM ([CentroCostos] TM1 LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T2 ON T2.[CentroCostosId] = TM1.[CentroCostosId]) WHERE TM1.[CentroCostosId] = @CentroCostosId ORDER BY TM1.[CentroCostosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q12", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q13", "SELECT [CentroCostosId] FROM [CentroCostos] WHERE [CentroCostosId] = @CentroCostosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q14", "SELECT TOP 1 [CentroCostosId] FROM [CentroCostos] WHERE ( [CentroCostosId] > @CentroCostosId) ORDER BY [CentroCostosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Q15", "SELECT TOP 1 [CentroCostosId] FROM [CentroCostos] WHERE ( [CentroCostosId] < @CentroCostosId) ORDER BY [CentroCostosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Q16", "INSERT INTO [CentroCostos]([CentroCostosCosto], [CentroCostosTipoRef], [CentroCostosRef], [CentroCostosNombre], [CentroCostosPrecioFinal], [CentroCostosSerial], [CentroCostosUsrAlta], [CentroCostosUsrMod], [CentroCostosHoraAlt], [CentroCostosHoraMod], [CentroCostosEstado], [CentroCostosJson]) VALUES(@CentroCostosCosto, @CentroCostosTipoRef, @CentroCostosRef, @CentroCostosNombre, @CentroCostosPrecioFinal, @CentroCostosSerial, @CentroCostosUsrAlta, @CentroCostosUsrMod, @CentroCostosHoraAlt, @CentroCostosHoraMod, @CentroCostosEstado, ''); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Q17", "UPDATE [CentroCostos] SET [CentroCostosCosto]=@CentroCostosCosto, [CentroCostosTipoRef]=@CentroCostosTipoRef, [CentroCostosRef]=@CentroCostosRef, [CentroCostosNombre]=@CentroCostosNombre, [CentroCostosPrecioFinal]=@CentroCostosPrecioFinal, [CentroCostosSerial]=@CentroCostosSerial, [CentroCostosUsrAlta]=@CentroCostosUsrAlta, [CentroCostosUsrMod]=@CentroCostosUsrMod, [CentroCostosHoraAlt]=@CentroCostosHoraAlt, [CentroCostosHoraMod]=@CentroCostosHoraMod, [CentroCostosEstado]=@CentroCostosEstado  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK,prmT001Q17)
           ,new CursorDef("T001Q18", "DELETE FROM [CentroCostos]  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK,prmT001Q18)
           ,new CursorDef("T001Q20", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q21", "UPDATE [CentroCostos] SET [CentroCostosSerial]=@CentroCostosSerial, [CentroCostosCosto]=@CentroCostosCosto  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK,prmT001Q21)
           ,new CursorDef("T001Q22", "SELECT [CentroCostosId] FROM [CentroCostos] ORDER BY [CentroCostosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q23", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesId], T1.[CentroCostosDetallesNombre], T1.[CentroCostosDetallesValor], T2.[ListaCostosNombre], T2.[ListaCostosValor], T1.[ListaCostosId] FROM ([CentroCostosDetalles] T1 LEFT JOIN [ListaCostos] T2 ON T2.[ListaCostosId] = T1.[ListaCostosId]) WHERE T1.[CentroCostosId] = @CentroCostosId and T1.[CentroCostosDetallesId] = @CentroCostosDetallesId ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q23,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q24", "SELECT [ListaCostosNombre], [ListaCostosValor] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q25", "SELECT [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q26", "INSERT INTO [CentroCostosDetalles]([CentroCostosId], [CentroCostosDetallesId], [CentroCostosDetallesNombre], [CentroCostosDetallesValor], [ListaCostosId], [CentroCostosDetallesSolId], [CCDetallesProfId], [CentroCostosDetallesFecha], [CentroCostosDetallesEstado]) VALUES(@CentroCostosId, @CentroCostosDetallesId, @CentroCostosDetallesNombre, @CentroCostosDetallesValor, @ListaCostosId, convert(int, 0), '', convert( DATETIME, '17530101', 112 ), convert(int, 0))", GxErrorMask.GX_NOMASK,prmT001Q26)
           ,new CursorDef("T001Q27", "UPDATE [CentroCostosDetalles] SET [CentroCostosDetallesNombre]=@CentroCostosDetallesNombre, [CentroCostosDetallesValor]=@CentroCostosDetallesValor, [ListaCostosId]=@ListaCostosId  WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId", GxErrorMask.GX_NOMASK,prmT001Q27)
           ,new CursorDef("T001Q28", "DELETE FROM [CentroCostosDetalles]  WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId", GxErrorMask.GX_NOMASK,prmT001Q28)
           ,new CursorDef("T001Q29", "SELECT [ListaCostosNombre], [ListaCostosValor] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Q30", "SELECT [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @CentroCostosId ORDER BY [CentroCostosId], [CentroCostosDetallesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q30,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 30);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 3);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 30);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 3);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 30);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 3);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              return;
           case 7 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}

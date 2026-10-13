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
   public class parametromudanza : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "parametromudanza.aspx")), "parametromudanza.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "parametromudanza.aspx")))) ;
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
                  AV13ParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( GetPar( "ParametroMudanzaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV13ParametroMudanzaId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ParametroMudanzaId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Parametro Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parametromudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ParametroMudanzaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13ParametroMudanzaId = aP1_ParametroMudanzaId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbParametroMudanzaTipo = new GXCombobox();
         cmbParametroMudanzaUnidad = new GXCombobox();
         chkParametroMudanzaActivo = new GXCheckbox();
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
         if ( cmbParametroMudanzaTipo.ItemCount > 0 )
         {
            A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
            AssignAttri("", false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametroMudanzaTipo.CurrentValue = StringUtil.RTrim( A731ParametroMudanzaTipo);
            AssignProp("", false, cmbParametroMudanzaTipo_Internalname, "Values", cmbParametroMudanzaTipo.ToJavascriptSource(), true);
         }
         if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
         {
            A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
            AssignAttri("", false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametroMudanzaUnidad.CurrentValue = StringUtil.RTrim( A734ParametroMudanzaUnidad);
            AssignProp("", false, cmbParametroMudanzaUnidad_Internalname, "Values", cmbParametroMudanzaUnidad.ToJavascriptSource(), true);
         }
         A877ParametroMudanzaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A877ParametroMudanzaActivo));
         AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroMudanzaId_Internalname, context.GetMessage( "Mudanza Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroMudanzaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametroMudanzaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9") : context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbParametroMudanzaTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbParametroMudanzaTipo_Internalname, context.GetMessage( "Mudanza Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbParametroMudanzaTipo, cmbParametroMudanzaTipo_Internalname, StringUtil.RTrim( A731ParametroMudanzaTipo), 1, cmbParametroMudanzaTipo_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EPARAMETROMUDANZATIPO.CLICK."+"'", "svchar", "", 1, cmbParametroMudanzaTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_ParametroMudanza.htm");
         cmbParametroMudanzaTipo.CurrentValue = StringUtil.RTrim( A731ParametroMudanzaTipo);
         AssignProp("", false, cmbParametroMudanzaTipo_Internalname, "Values", (string)(cmbParametroMudanzaTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroMudanzaTitulo_Internalname, context.GetMessage( "Título tarjetas", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroMudanzaTitulo_Internalname, A869ParametroMudanzaTitulo, StringUtil.RTrim( context.localUtil.Format( A869ParametroMudanzaTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroMudanzaNombre_Internalname, context.GetMessage( "Mudanza Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroMudanzaNombre_Internalname, A732ParametroMudanzaNombre, StringUtil.RTrim( context.localUtil.Format( A732ParametroMudanzaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "ParametroNombre", "start", true, "", "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtParametroMudanzaDescripcion_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroMudanzaDescripcion_Internalname, context.GetMessage( "INFORMACIÓN", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroMudanzaDescripcion_Internalname, A812ParametroMudanzaDescripcion, StringUtil.RTrim( context.localUtil.Format( A812ParametroMudanzaDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", edtParametroMudanzaDescripcion_Visible, edtParametroMudanzaDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "ParametroNombre", "start", true, "", "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroMudanzaValor_Internalname, context.GetMessage( "Mudanza Valor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroMudanzaValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametroMudanzaValor_Enabled!=0) ? context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "ParametroValor", "end", false, "", "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbParametroMudanzaUnidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbParametroMudanzaUnidad_Internalname, context.GetMessage( "Mudanza Unidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbParametroMudanzaUnidad, cmbParametroMudanzaUnidad_Internalname, StringUtil.RTrim( A734ParametroMudanzaUnidad), 1, cmbParametroMudanzaUnidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbParametroMudanzaUnidad.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_ParametroMudanza.htm");
         cmbParametroMudanzaUnidad.CurrentValue = StringUtil.RTrim( A734ParametroMudanzaUnidad);
         AssignProp("", false, cmbParametroMudanzaUnidad_Internalname, "Values", (string)(cmbParametroMudanzaUnidad.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtParametroMudanzaPisoElev_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaPisoElev_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroMudanzaPisoElev_Internalname, context.GetMessage( "PISO (Elevación)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroMudanzaPisoElev_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A818ParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametroMudanzaPisoElev_Enabled!=0) ? context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9") : context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaPisoElev_Jsonclick, 0, "AttributeFL", "", "", "", "", edtParametroMudanzaPisoElev_Visible, edtParametroMudanzaPisoElev_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgParametroMudanzaImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Mudanza Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A870ParametroMudanzaImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ParametroMudanzaImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.PathToRelativeUrl( A870ParametroMudanzaImagen));
         GxWebStd.gx_bitmap( context, imgParametroMudanzaImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgParametroMudanzaImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", "", "", 0, A870ParametroMudanzaImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanza.htm");
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.PathToRelativeUrl( A870ParametroMudanzaImagen)), true);
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A870ParametroMudanzaImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkParametroMudanzaActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkParametroMudanzaActivo_Internalname, context.GetMessage( "¿Activo?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkParametroMudanzaActivo_Internalname, StringUtil.BoolToStr( A877ParametroMudanzaActivo), "", context.GetMessage( "¿Activo?", ""), 1, chkParametroMudanzaActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(67, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,67);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanza.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanza.htm");
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
         E112J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z730ParametroMudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z731ParametroMudanzaTipo = cgiGet( "Z731ParametroMudanzaTipo");
               Z869ParametroMudanzaTitulo = cgiGet( "Z869ParametroMudanzaTitulo");
               Z732ParametroMudanzaNombre = cgiGet( "Z732ParametroMudanzaNombre");
               Z812ParametroMudanzaDescripcion = cgiGet( "Z812ParametroMudanzaDescripcion");
               Z733ParametroMudanzaValor = context.localUtil.CToN( cgiGet( "Z733ParametroMudanzaValor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z734ParametroMudanzaUnidad = cgiGet( "Z734ParametroMudanzaUnidad");
               Z818ParametroMudanzaPisoElev = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z818ParametroMudanzaPisoElev"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z877ParametroMudanzaActivo = StringUtil.StrToBool( cgiGet( "Z877ParametroMudanzaActivo"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV13ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPARAMETROMUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000ParametroMudanzaImagen_GXI = cgiGet( "PARAMETROMUDANZAIMAGEN_GXI");
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               A730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
               cmbParametroMudanzaTipo.CurrentValue = cgiGet( cmbParametroMudanzaTipo_Internalname);
               A731ParametroMudanzaTipo = cgiGet( cmbParametroMudanzaTipo_Internalname);
               AssignAttri("", false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
               A869ParametroMudanzaTitulo = cgiGet( edtParametroMudanzaTitulo_Internalname);
               AssignAttri("", false, "A869ParametroMudanzaTitulo", A869ParametroMudanzaTitulo);
               A732ParametroMudanzaNombre = cgiGet( edtParametroMudanzaNombre_Internalname);
               AssignAttri("", false, "A732ParametroMudanzaNombre", A732ParametroMudanzaNombre);
               A812ParametroMudanzaDescripcion = cgiGet( edtParametroMudanzaDescripcion_Internalname);
               AssignAttri("", false, "A812ParametroMudanzaDescripcion", A812ParametroMudanzaDescripcion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtParametroMudanzaValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametroMudanzaValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROMUDANZAVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtParametroMudanzaValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A733ParametroMudanzaValor = 0;
                  AssignAttri("", false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
               }
               else
               {
                  A733ParametroMudanzaValor = context.localUtil.CToN( cgiGet( edtParametroMudanzaValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
               }
               cmbParametroMudanzaUnidad.CurrentValue = cgiGet( cmbParametroMudanzaUnidad_Internalname);
               A734ParametroMudanzaUnidad = cgiGet( cmbParametroMudanzaUnidad_Internalname);
               AssignAttri("", false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
               if ( ( ( context.localUtil.CToN( cgiGet( edtParametroMudanzaPisoElev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametroMudanzaPisoElev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROMUDANZAPISOELEV");
                  AnyError = 1;
                  GX_FocusControl = edtParametroMudanzaPisoElev_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A818ParametroMudanzaPisoElev = 0;
                  AssignAttri("", false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
               }
               else
               {
                  A818ParametroMudanzaPisoElev = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaPisoElev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
               }
               A870ParametroMudanzaImagen = cgiGet( imgParametroMudanzaImagen_Internalname);
               AssignAttri("", false, "A870ParametroMudanzaImagen", A870ParametroMudanzaImagen);
               A877ParametroMudanzaActivo = StringUtil.StrToBool( cgiGet( chkParametroMudanzaActivo_Internalname));
               AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgParametroMudanzaImagen_Internalname, ref  A870ParametroMudanzaImagen, ref  A40000ParametroMudanzaImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ParametroMudanza");
               A730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
               forbiddenHiddens.Add("ParametroMudanzaId", context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A730ParametroMudanzaId != Z730ParametroMudanzaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("parametromudanza:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A730ParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( GetPar( "ParametroMudanzaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
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
                     sMode118 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode118;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound118 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARAMETROMUDANZAID");
                        AnyError = 1;
                        GX_FocusControl = edtParametroMudanzaId_Internalname;
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
                           E112J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PARAMETROMUDANZATIPO.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E132J2 ();
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
            E122J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2J118( ) ;
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
            DisableAttributes2J118( ) ;
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

      protected void CONFIRM_2J0( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2J118( ) ;
            }
            else
            {
               CheckExtendedTable2J118( ) ;
               CloseExtendedTableCursors2J118( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2J0( )
      {
      }

      protected void E112J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV15Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         AV14ParametroMudanza.Load(AV13ParametroMudanzaId);
         if ( ((StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "TipoInmuebleCasa")==0)||(StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "TipoInmuebleApto")==0)) )
         {
            edtParametroMudanzaPisoElev_Visible = 1;
            AssignProp("", false, edtParametroMudanzaPisoElev_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Visible), 5, 0), true);
         }
         else
         {
            edtParametroMudanzaPisoElev_Visible = 0;
            AssignProp("", false, edtParametroMudanzaPisoElev_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Visible), 5, 0), true);
         }
         if ( ((StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "ItemCargaDecoracion")==0)||(StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "ItemCargaExterior")==0)||(StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "ItemCargaHogar")==0)||(StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "ItemCargaMobiliario")==0)||(StringUtil.StrCmp(AV14ParametroMudanza.gxTpr_Parametromudanzatipo, "ItemCargaOtros")==0)) )
         {
            edtParametroMudanzaDescripcion_Visible = 1;
            AssignProp("", false, edtParametroMudanzaDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Visible), 5, 0), true);
         }
         else
         {
            edtParametroMudanzaDescripcion_Visible = 0;
            AssignProp("", false, edtParametroMudanzaDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Visible), 5, 0), true);
         }
      }

      protected void E122J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("parametromudanzaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E132J2( )
      {
         /* ParametroMudanzaTipo_Click Routine */
         returnInSub = false;
         if ( ((StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa")==0)||(StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto")==0)) )
         {
            edtParametroMudanzaPisoElev_Visible = 1;
            AssignProp("", false, edtParametroMudanzaPisoElev_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Visible), 5, 0), true);
         }
         else
         {
            edtParametroMudanzaPisoElev_Visible = 0;
            AssignProp("", false, edtParametroMudanzaPisoElev_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Visible), 5, 0), true);
         }
         if ( ((StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion")==0)||(StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior")==0)||(StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar")==0)||(StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario")==0)||(StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros")==0)) )
         {
            edtParametroMudanzaDescripcion_Visible = 1;
            AssignProp("", false, edtParametroMudanzaDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Visible), 5, 0), true);
         }
         else
         {
            edtParametroMudanzaDescripcion_Visible = 0;
            AssignProp("", false, edtParametroMudanzaDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void ZM2J118( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z731ParametroMudanzaTipo = T002J3_A731ParametroMudanzaTipo[0];
               Z869ParametroMudanzaTitulo = T002J3_A869ParametroMudanzaTitulo[0];
               Z732ParametroMudanzaNombre = T002J3_A732ParametroMudanzaNombre[0];
               Z812ParametroMudanzaDescripcion = T002J3_A812ParametroMudanzaDescripcion[0];
               Z733ParametroMudanzaValor = T002J3_A733ParametroMudanzaValor[0];
               Z734ParametroMudanzaUnidad = T002J3_A734ParametroMudanzaUnidad[0];
               Z818ParametroMudanzaPisoElev = T002J3_A818ParametroMudanzaPisoElev[0];
               Z877ParametroMudanzaActivo = T002J3_A877ParametroMudanzaActivo[0];
            }
            else
            {
               Z731ParametroMudanzaTipo = A731ParametroMudanzaTipo;
               Z869ParametroMudanzaTitulo = A869ParametroMudanzaTitulo;
               Z732ParametroMudanzaNombre = A732ParametroMudanzaNombre;
               Z812ParametroMudanzaDescripcion = A812ParametroMudanzaDescripcion;
               Z733ParametroMudanzaValor = A733ParametroMudanzaValor;
               Z734ParametroMudanzaUnidad = A734ParametroMudanzaUnidad;
               Z818ParametroMudanzaPisoElev = A818ParametroMudanzaPisoElev;
               Z877ParametroMudanzaActivo = A877ParametroMudanzaActivo;
            }
         }
         if ( GX_JID == -6 )
         {
            Z730ParametroMudanzaId = A730ParametroMudanzaId;
            Z731ParametroMudanzaTipo = A731ParametroMudanzaTipo;
            Z869ParametroMudanzaTitulo = A869ParametroMudanzaTitulo;
            Z732ParametroMudanzaNombre = A732ParametroMudanzaNombre;
            Z812ParametroMudanzaDescripcion = A812ParametroMudanzaDescripcion;
            Z733ParametroMudanzaValor = A733ParametroMudanzaValor;
            Z734ParametroMudanzaUnidad = A734ParametroMudanzaUnidad;
            Z818ParametroMudanzaPisoElev = A818ParametroMudanzaPisoElev;
            Z870ParametroMudanzaImagen = A870ParametroMudanzaImagen;
            Z40000ParametroMudanzaImagen_GXI = A40000ParametroMudanzaImagen_GXI;
            Z877ParametroMudanzaActivo = A877ParametroMudanzaActivo;
         }
      }

      protected void standaloneNotModal( )
      {
         edtParametroMudanzaId_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtParametroMudanzaId_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV13ParametroMudanzaId) )
         {
            A730ParametroMudanzaId = AV13ParametroMudanzaId;
            AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
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
         if ( IsIns( )  && (false==A877ParametroMudanzaActivo) && ( Gx_BScreen == 0 ) )
         {
            A877ParametroMudanzaActivo = true;
            AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
         }
      }

      protected void Load2J118( )
      {
         /* Using cursor T002J4 */
         pr_default.execute(2, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound118 = 1;
            A731ParametroMudanzaTipo = T002J4_A731ParametroMudanzaTipo[0];
            AssignAttri("", false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
            A869ParametroMudanzaTitulo = T002J4_A869ParametroMudanzaTitulo[0];
            AssignAttri("", false, "A869ParametroMudanzaTitulo", A869ParametroMudanzaTitulo);
            A732ParametroMudanzaNombre = T002J4_A732ParametroMudanzaNombre[0];
            AssignAttri("", false, "A732ParametroMudanzaNombre", A732ParametroMudanzaNombre);
            A812ParametroMudanzaDescripcion = T002J4_A812ParametroMudanzaDescripcion[0];
            AssignAttri("", false, "A812ParametroMudanzaDescripcion", A812ParametroMudanzaDescripcion);
            A733ParametroMudanzaValor = T002J4_A733ParametroMudanzaValor[0];
            AssignAttri("", false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
            A734ParametroMudanzaUnidad = T002J4_A734ParametroMudanzaUnidad[0];
            AssignAttri("", false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
            A818ParametroMudanzaPisoElev = T002J4_A818ParametroMudanzaPisoElev[0];
            AssignAttri("", false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
            A40000ParametroMudanzaImagen_GXI = T002J4_A40000ParametroMudanzaImagen_GXI[0];
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
            A877ParametroMudanzaActivo = T002J4_A877ParametroMudanzaActivo[0];
            AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
            A870ParametroMudanzaImagen = T002J4_A870ParametroMudanzaImagen[0];
            AssignAttri("", false, "A870ParametroMudanzaImagen", A870ParametroMudanzaImagen);
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
            ZM2J118( -6) ;
         }
         pr_default.close(2);
         OnLoadActions2J118( ) ;
      }

      protected void OnLoadActions2J118( )
      {
         AV15Pgmname = "ParametroMudanza";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable2J118( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "ParametroMudanza";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Parametro Mudanza Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PARAMETROMUDANZATIPO");
            AnyError = 1;
            GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Parametro Mudanza Unidad", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PARAMETROMUDANZAUNIDAD");
            AnyError = 1;
            GX_FocusControl = cmbParametroMudanzaUnidad_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2J118( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2J118( )
      {
         /* Using cursor T002J5 */
         pr_default.execute(3, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound118 = 1;
         }
         else
         {
            RcdFound118 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002J3 */
         pr_default.execute(1, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2J118( 6) ;
            RcdFound118 = 1;
            A730ParametroMudanzaId = T002J3_A730ParametroMudanzaId[0];
            AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
            A731ParametroMudanzaTipo = T002J3_A731ParametroMudanzaTipo[0];
            AssignAttri("", false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
            A869ParametroMudanzaTitulo = T002J3_A869ParametroMudanzaTitulo[0];
            AssignAttri("", false, "A869ParametroMudanzaTitulo", A869ParametroMudanzaTitulo);
            A732ParametroMudanzaNombre = T002J3_A732ParametroMudanzaNombre[0];
            AssignAttri("", false, "A732ParametroMudanzaNombre", A732ParametroMudanzaNombre);
            A812ParametroMudanzaDescripcion = T002J3_A812ParametroMudanzaDescripcion[0];
            AssignAttri("", false, "A812ParametroMudanzaDescripcion", A812ParametroMudanzaDescripcion);
            A733ParametroMudanzaValor = T002J3_A733ParametroMudanzaValor[0];
            AssignAttri("", false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
            A734ParametroMudanzaUnidad = T002J3_A734ParametroMudanzaUnidad[0];
            AssignAttri("", false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
            A818ParametroMudanzaPisoElev = T002J3_A818ParametroMudanzaPisoElev[0];
            AssignAttri("", false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
            A40000ParametroMudanzaImagen_GXI = T002J3_A40000ParametroMudanzaImagen_GXI[0];
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
            A877ParametroMudanzaActivo = T002J3_A877ParametroMudanzaActivo[0];
            AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
            A870ParametroMudanzaImagen = T002J3_A870ParametroMudanzaImagen[0];
            AssignAttri("", false, "A870ParametroMudanzaImagen", A870ParametroMudanzaImagen);
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
            AssignProp("", false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
            Z730ParametroMudanzaId = A730ParametroMudanzaId;
            sMode118 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2J118( ) ;
            if ( AnyError == 1 )
            {
               RcdFound118 = 0;
               InitializeNonKey2J118( ) ;
            }
            Gx_mode = sMode118;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound118 = 0;
            InitializeNonKey2J118( ) ;
            sMode118 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode118;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2J118( ) ;
         if ( RcdFound118 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound118 = 0;
         /* Using cursor T002J6 */
         pr_default.execute(4, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002J6_A730ParametroMudanzaId[0] < A730ParametroMudanzaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002J6_A730ParametroMudanzaId[0] > A730ParametroMudanzaId ) ) )
            {
               A730ParametroMudanzaId = T002J6_A730ParametroMudanzaId[0];
               AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
               RcdFound118 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound118 = 0;
         /* Using cursor T002J7 */
         pr_default.execute(5, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002J7_A730ParametroMudanzaId[0] > A730ParametroMudanzaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002J7_A730ParametroMudanzaId[0] < A730ParametroMudanzaId ) ) )
            {
               A730ParametroMudanzaId = T002J7_A730ParametroMudanzaId[0];
               AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
               RcdFound118 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2J118( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2J118( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound118 == 1 )
            {
               if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
               {
                  A730ParametroMudanzaId = Z730ParametroMudanzaId;
                  AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARAMETROMUDANZAID");
                  AnyError = 1;
                  GX_FocusControl = edtParametroMudanzaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2J118( ) ;
                  GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2J118( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARAMETROMUDANZAID");
                     AnyError = 1;
                     GX_FocusControl = edtParametroMudanzaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2J118( ) ;
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
         if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
         {
            A730ParametroMudanzaId = Z730ParametroMudanzaId;
            AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARAMETROMUDANZAID");
            AnyError = 1;
            GX_FocusControl = edtParametroMudanzaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbParametroMudanzaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2J118( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002J2 */
            pr_default.execute(0, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ParametroMudanza"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z731ParametroMudanzaTipo, T002J2_A731ParametroMudanzaTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z869ParametroMudanzaTitulo, T002J2_A869ParametroMudanzaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z732ParametroMudanzaNombre, T002J2_A732ParametroMudanzaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z812ParametroMudanzaDescripcion, T002J2_A812ParametroMudanzaDescripcion[0]) != 0 ) || ( Z733ParametroMudanzaValor != T002J2_A733ParametroMudanzaValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z734ParametroMudanzaUnidad, T002J2_A734ParametroMudanzaUnidad[0]) != 0 ) || ( Z818ParametroMudanzaPisoElev != T002J2_A818ParametroMudanzaPisoElev[0] ) || ( Z877ParametroMudanzaActivo != T002J2_A877ParametroMudanzaActivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z731ParametroMudanzaTipo, T002J2_A731ParametroMudanzaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z731ParametroMudanzaTipo);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A731ParametroMudanzaTipo[0]);
               }
               if ( StringUtil.StrCmp(Z869ParametroMudanzaTitulo, T002J2_A869ParametroMudanzaTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z869ParametroMudanzaTitulo);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A869ParametroMudanzaTitulo[0]);
               }
               if ( StringUtil.StrCmp(Z732ParametroMudanzaNombre, T002J2_A732ParametroMudanzaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z732ParametroMudanzaNombre);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A732ParametroMudanzaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z812ParametroMudanzaDescripcion, T002J2_A812ParametroMudanzaDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z812ParametroMudanzaDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A812ParametroMudanzaDescripcion[0]);
               }
               if ( Z733ParametroMudanzaValor != T002J2_A733ParametroMudanzaValor[0] )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaValor");
                  GXUtil.WriteLogRaw("Old: ",Z733ParametroMudanzaValor);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A733ParametroMudanzaValor[0]);
               }
               if ( StringUtil.StrCmp(Z734ParametroMudanzaUnidad, T002J2_A734ParametroMudanzaUnidad[0]) != 0 )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaUnidad");
                  GXUtil.WriteLogRaw("Old: ",Z734ParametroMudanzaUnidad);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A734ParametroMudanzaUnidad[0]);
               }
               if ( Z818ParametroMudanzaPisoElev != T002J2_A818ParametroMudanzaPisoElev[0] )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaPisoElev");
                  GXUtil.WriteLogRaw("Old: ",Z818ParametroMudanzaPisoElev);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A818ParametroMudanzaPisoElev[0]);
               }
               if ( Z877ParametroMudanzaActivo != T002J2_A877ParametroMudanzaActivo[0] )
               {
                  GXUtil.WriteLog("parametromudanza:[seudo value changed for attri]"+"ParametroMudanzaActivo");
                  GXUtil.WriteLogRaw("Old: ",Z877ParametroMudanzaActivo);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A877ParametroMudanzaActivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ParametroMudanza"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2J118( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2J118( 0) ;
            CheckOptimisticConcurrency2J118( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J118( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2J118( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002J8 */
                     pr_default.execute(6, new Object[] {A731ParametroMudanzaTipo, A869ParametroMudanzaTitulo, A732ParametroMudanzaNombre, A812ParametroMudanzaDescripcion, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A818ParametroMudanzaPisoElev, A870ParametroMudanzaImagen, A40000ParametroMudanzaImagen_GXI, A877ParametroMudanzaActivo});
                     A730ParametroMudanzaId = T002J8_A730ParametroMudanzaId[0];
                     AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2J0( ) ;
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
               Load2J118( ) ;
            }
            EndLevel2J118( ) ;
         }
         CloseExtendedTableCursors2J118( ) ;
      }

      protected void Update2J118( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J118( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J118( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2J118( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002J9 */
                     pr_default.execute(7, new Object[] {A731ParametroMudanzaTipo, A869ParametroMudanzaTitulo, A732ParametroMudanzaNombre, A812ParametroMudanzaDescripcion, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A818ParametroMudanzaPisoElev, A877ParametroMudanzaActivo, A730ParametroMudanzaId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ParametroMudanza"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2J118( ) ;
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
            EndLevel2J118( ) ;
         }
         CloseExtendedTableCursors2J118( ) ;
      }

      protected void DeferredUpdate2J118( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002J10 */
            pr_default.execute(8, new Object[] {A870ParametroMudanzaImagen, A40000ParametroMudanzaImagen_GXI, A730ParametroMudanzaId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
         }
      }

      protected void delete( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2J118( ) ;
            AfterConfirm2J118( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2J118( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002J11 */
                  pr_default.execute(9, new Object[] {A730ParametroMudanzaId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
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
         sMode118 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2J118( ) ;
         Gx_mode = sMode118;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2J118( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "ParametroMudanza";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002J12 */
            pr_default.execute(10, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Adicional", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T002J13 */
            pr_default.execute(11, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Carga", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T002J14 */
            pr_default.execute(12, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Estacionam Destino", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T002J15 */
            pr_default.execute(13, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Estacionam Origen", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T002J16 */
            pr_default.execute(14, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Inmueble Destino", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002J17 */
            pr_default.execute(15, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Inmueble Origen", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel2J118( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("parametromudanza",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("parametromudanza",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2J118( )
      {
         /* Scan By routine */
         /* Using cursor T002J18 */
         pr_default.execute(16);
         RcdFound118 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound118 = 1;
            A730ParametroMudanzaId = T002J18_A730ParametroMudanzaId[0];
            AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2J118( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound118 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound118 = 1;
            A730ParametroMudanzaId = T002J18_A730ParametroMudanzaId[0];
            AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
         }
      }

      protected void ScanEnd2J118( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm2J118( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2J118( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2J118( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2J118( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2J118( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2J118( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2J118( )
      {
         edtParametroMudanzaId_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaId_Enabled), 5, 0), true);
         cmbParametroMudanzaTipo.Enabled = 0;
         AssignProp("", false, cmbParametroMudanzaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametroMudanzaTipo.Enabled), 5, 0), true);
         edtParametroMudanzaTitulo_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaTitulo_Enabled), 5, 0), true);
         edtParametroMudanzaNombre_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaNombre_Enabled), 5, 0), true);
         edtParametroMudanzaDescripcion_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Enabled), 5, 0), true);
         edtParametroMudanzaValor_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaValor_Enabled), 5, 0), true);
         cmbParametroMudanzaUnidad.Enabled = 0;
         AssignProp("", false, cmbParametroMudanzaUnidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametroMudanzaUnidad.Enabled), 5, 0), true);
         edtParametroMudanzaPisoElev_Enabled = 0;
         AssignProp("", false, edtParametroMudanzaPisoElev_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Enabled), 5, 0), true);
         imgParametroMudanzaImagen_Enabled = 0;
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgParametroMudanzaImagen_Enabled), 5, 0), true);
         chkParametroMudanzaActivo.Enabled = 0;
         AssignProp("", false, chkParametroMudanzaActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkParametroMudanzaActivo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2J118( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2J0( )
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
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13ParametroMudanzaId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ParametroMudanza");
         forbiddenHiddens.Add("ParametroMudanzaId", context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("parametromudanza:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z730ParametroMudanzaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z731ParametroMudanzaTipo", Z731ParametroMudanzaTipo);
         GxWebStd.gx_hidden_field( context, "Z869ParametroMudanzaTitulo", Z869ParametroMudanzaTitulo);
         GxWebStd.gx_hidden_field( context, "Z732ParametroMudanzaNombre", Z732ParametroMudanzaNombre);
         GxWebStd.gx_hidden_field( context, "Z812ParametroMudanzaDescripcion", Z812ParametroMudanzaDescripcion);
         GxWebStd.gx_hidden_field( context, "Z733ParametroMudanzaValor", StringUtil.LTrim( StringUtil.NToC( Z733ParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z734ParametroMudanzaUnidad", StringUtil.RTrim( Z734ParametroMudanzaUnidad));
         GxWebStd.gx_hidden_field( context, "Z818ParametroMudanzaPisoElev", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z818ParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z877ParametroMudanzaActivo", Z877ParametroMudanzaActivo);
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
         GxWebStd.gx_hidden_field( context, "vPARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ParametroMudanzaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAIMAGEN_GXI", A40000ParametroMudanzaImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GXCCtlgxBlob = "PARAMETROMUDANZAIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A870ParametroMudanzaImagen);
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
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13ParametroMudanzaId,4,0));
         return formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ParametroMudanza" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Parametro Mudanza", "") ;
      }

      protected void InitializeNonKey2J118( )
      {
         A731ParametroMudanzaTipo = "";
         AssignAttri("", false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
         A869ParametroMudanzaTitulo = "";
         AssignAttri("", false, "A869ParametroMudanzaTitulo", A869ParametroMudanzaTitulo);
         A732ParametroMudanzaNombre = "";
         AssignAttri("", false, "A732ParametroMudanzaNombre", A732ParametroMudanzaNombre);
         A812ParametroMudanzaDescripcion = "";
         AssignAttri("", false, "A812ParametroMudanzaDescripcion", A812ParametroMudanzaDescripcion);
         A733ParametroMudanzaValor = 0;
         AssignAttri("", false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
         A734ParametroMudanzaUnidad = "";
         AssignAttri("", false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
         A818ParametroMudanzaPisoElev = 0;
         AssignAttri("", false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
         A870ParametroMudanzaImagen = "";
         AssignAttri("", false, "A870ParametroMudanzaImagen", A870ParametroMudanzaImagen);
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
         A40000ParametroMudanzaImagen_GXI = "";
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
         AssignProp("", false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
         A877ParametroMudanzaActivo = true;
         AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
         Z731ParametroMudanzaTipo = "";
         Z869ParametroMudanzaTitulo = "";
         Z732ParametroMudanzaNombre = "";
         Z812ParametroMudanzaDescripcion = "";
         Z733ParametroMudanzaValor = 0;
         Z734ParametroMudanzaUnidad = "";
         Z818ParametroMudanzaPisoElev = 0;
         Z877ParametroMudanzaActivo = false;
      }

      protected void InitAll2J118( )
      {
         A730ParametroMudanzaId = 0;
         AssignAttri("", false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
         InitializeNonKey2J118( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A877ParametroMudanzaActivo = i877ParametroMudanzaActivo;
         AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021154045", true, true, false);
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
         context.AddJavascriptSource("parametromudanza.js", "?202673021154046", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID";
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO";
         edtParametroMudanzaTitulo_Internalname = "PARAMETROMUDANZATITULO";
         edtParametroMudanzaNombre_Internalname = "PARAMETROMUDANZANOMBRE";
         edtParametroMudanzaDescripcion_Internalname = "PARAMETROMUDANZADESCRIPCION";
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR";
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD";
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV";
         imgParametroMudanzaImagen_Internalname = "PARAMETROMUDANZAIMAGEN";
         chkParametroMudanzaActivo_Internalname = "PARAMETROMUDANZAACTIVO";
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
         Form.Caption = context.GetMessage( "Parametro Mudanza", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkParametroMudanzaActivo.Enabled = 1;
         imgParametroMudanzaImagen_Enabled = 1;
         edtParametroMudanzaPisoElev_Jsonclick = "";
         edtParametroMudanzaPisoElev_Enabled = 1;
         edtParametroMudanzaPisoElev_Visible = 1;
         cmbParametroMudanzaUnidad_Jsonclick = "";
         cmbParametroMudanzaUnidad.Enabled = 1;
         edtParametroMudanzaValor_Jsonclick = "";
         edtParametroMudanzaValor_Enabled = 1;
         edtParametroMudanzaDescripcion_Jsonclick = "";
         edtParametroMudanzaDescripcion_Enabled = 1;
         edtParametroMudanzaDescripcion_Visible = 1;
         edtParametroMudanzaNombre_Jsonclick = "";
         edtParametroMudanzaNombre_Enabled = 1;
         edtParametroMudanzaTitulo_Jsonclick = "";
         edtParametroMudanzaTitulo_Enabled = 1;
         cmbParametroMudanzaTipo_Jsonclick = "";
         cmbParametroMudanzaTipo.Enabled = 1;
         edtParametroMudanzaId_Jsonclick = "";
         edtParametroMudanzaId_Enabled = 0;
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
         cmbParametroMudanzaTipo.Name = "PARAMETROMUDANZATIPO";
         cmbParametroMudanzaTipo.WebTags = "";
         cmbParametroMudanzaTipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbParametroMudanzaTipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbParametroMudanzaTipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbParametroMudanzaTipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbParametroMudanzaTipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbParametroMudanzaTipo.ItemCount > 0 )
         {
            A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
            AssignAttri("", false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
         }
         cmbParametroMudanzaUnidad.Name = "PARAMETROMUDANZAUNIDAD";
         cmbParametroMudanzaUnidad.WebTags = "";
         cmbParametroMudanzaUnidad.addItem("m3", context.GetMessage( "m3", ""), 0);
         cmbParametroMudanzaUnidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
         cmbParametroMudanzaUnidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("%", "%", 0);
         cmbParametroMudanzaUnidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
         if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
         {
            A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
            AssignAttri("", false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
         }
         chkParametroMudanzaActivo.Name = "PARAMETROMUDANZAACTIVO";
         chkParametroMudanzaActivo.WebTags = "";
         chkParametroMudanzaActivo.Caption = context.GetMessage( "¿Activo?", "");
         AssignProp("", false, chkParametroMudanzaActivo_Internalname, "TitleCaption", chkParametroMudanzaActivo.Caption, true);
         chkParametroMudanzaActivo.CheckedValue = "false";
         if ( IsIns( ) && (false==A877ParametroMudanzaActivo) )
         {
            A877ParametroMudanzaActivo = true;
            AssignAttri("", false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV13ParametroMudanzaId',fld:'vPARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV13ParametroMudanzaId',fld:'vPARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E122J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
         setEventMetadata("PARAMETROMUDANZATIPO.CLICK","{handler:'E132J2',iparms:[{av:'cmbParametroMudanzaTipo'},{av:'A731ParametroMudanzaTipo',fld:'PARAMETROMUDANZATIPO',pic:'',type:'svchar'},{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("PARAMETROMUDANZATIPO.CLICK",",oparms:[{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PARAMETROMUDANZAID","{handler:'Valid_Parametromudanzaid',iparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PARAMETROMUDANZAID",",oparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PARAMETROMUDANZATIPO","{handler:'Valid_Parametromudanzatipo',iparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PARAMETROMUDANZATIPO",",oparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PARAMETROMUDANZAUNIDAD","{handler:'Valid_Parametromudanzaunidad',iparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PARAMETROMUDANZAUNIDAD",",oparms:[{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]}");
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
         Z731ParametroMudanzaTipo = "";
         Z869ParametroMudanzaTitulo = "";
         Z732ParametroMudanzaNombre = "";
         Z812ParametroMudanzaDescripcion = "";
         Z734ParametroMudanzaUnidad = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         A870ParametroMudanzaImagen = "";
         A40000ParametroMudanzaImagen_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode118 = "";
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
         AV14ParametroMudanza = new SdtParametroMudanza(context);
         Z870ParametroMudanzaImagen = "";
         Z40000ParametroMudanzaImagen_GXI = "";
         T002J4_A730ParametroMudanzaId = new short[1] ;
         T002J4_A731ParametroMudanzaTipo = new string[] {""} ;
         T002J4_A869ParametroMudanzaTitulo = new string[] {""} ;
         T002J4_A732ParametroMudanzaNombre = new string[] {""} ;
         T002J4_A812ParametroMudanzaDescripcion = new string[] {""} ;
         T002J4_A733ParametroMudanzaValor = new decimal[1] ;
         T002J4_A734ParametroMudanzaUnidad = new string[] {""} ;
         T002J4_A818ParametroMudanzaPisoElev = new short[1] ;
         T002J4_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         T002J4_A877ParametroMudanzaActivo = new bool[] {false} ;
         T002J4_A870ParametroMudanzaImagen = new string[] {""} ;
         T002J5_A730ParametroMudanzaId = new short[1] ;
         T002J3_A730ParametroMudanzaId = new short[1] ;
         T002J3_A731ParametroMudanzaTipo = new string[] {""} ;
         T002J3_A869ParametroMudanzaTitulo = new string[] {""} ;
         T002J3_A732ParametroMudanzaNombre = new string[] {""} ;
         T002J3_A812ParametroMudanzaDescripcion = new string[] {""} ;
         T002J3_A733ParametroMudanzaValor = new decimal[1] ;
         T002J3_A734ParametroMudanzaUnidad = new string[] {""} ;
         T002J3_A818ParametroMudanzaPisoElev = new short[1] ;
         T002J3_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         T002J3_A877ParametroMudanzaActivo = new bool[] {false} ;
         T002J3_A870ParametroMudanzaImagen = new string[] {""} ;
         T002J6_A730ParametroMudanzaId = new short[1] ;
         T002J7_A730ParametroMudanzaId = new short[1] ;
         T002J2_A730ParametroMudanzaId = new short[1] ;
         T002J2_A731ParametroMudanzaTipo = new string[] {""} ;
         T002J2_A869ParametroMudanzaTitulo = new string[] {""} ;
         T002J2_A732ParametroMudanzaNombre = new string[] {""} ;
         T002J2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         T002J2_A733ParametroMudanzaValor = new decimal[1] ;
         T002J2_A734ParametroMudanzaUnidad = new string[] {""} ;
         T002J2_A818ParametroMudanzaPisoElev = new short[1] ;
         T002J2_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         T002J2_A877ParametroMudanzaActivo = new bool[] {false} ;
         T002J2_A870ParametroMudanzaImagen = new string[] {""} ;
         T002J8_A730ParametroMudanzaId = new short[1] ;
         T002J12_A735MudanzaId = new long[1] ;
         T002J12_A766ItemAdicionalId = new short[1] ;
         T002J13_A735MudanzaId = new long[1] ;
         T002J13_A751ItemCargaId = new short[1] ;
         T002J14_A735MudanzaId = new long[1] ;
         T002J15_A735MudanzaId = new long[1] ;
         T002J16_A735MudanzaId = new long[1] ;
         T002J17_A735MudanzaId = new long[1] ;
         T002J18_A730ParametroMudanzaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.parametromudanza__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanza__default(),
            new Object[][] {
                new Object[] {
               T002J2_A730ParametroMudanzaId, T002J2_A731ParametroMudanzaTipo, T002J2_A869ParametroMudanzaTitulo, T002J2_A732ParametroMudanzaNombre, T002J2_A812ParametroMudanzaDescripcion, T002J2_A733ParametroMudanzaValor, T002J2_A734ParametroMudanzaUnidad, T002J2_A818ParametroMudanzaPisoElev, T002J2_A40000ParametroMudanzaImagen_GXI, T002J2_A877ParametroMudanzaActivo,
               T002J2_A870ParametroMudanzaImagen
               }
               , new Object[] {
               T002J3_A730ParametroMudanzaId, T002J3_A731ParametroMudanzaTipo, T002J3_A869ParametroMudanzaTitulo, T002J3_A732ParametroMudanzaNombre, T002J3_A812ParametroMudanzaDescripcion, T002J3_A733ParametroMudanzaValor, T002J3_A734ParametroMudanzaUnidad, T002J3_A818ParametroMudanzaPisoElev, T002J3_A40000ParametroMudanzaImagen_GXI, T002J3_A877ParametroMudanzaActivo,
               T002J3_A870ParametroMudanzaImagen
               }
               , new Object[] {
               T002J4_A730ParametroMudanzaId, T002J4_A731ParametroMudanzaTipo, T002J4_A869ParametroMudanzaTitulo, T002J4_A732ParametroMudanzaNombre, T002J4_A812ParametroMudanzaDescripcion, T002J4_A733ParametroMudanzaValor, T002J4_A734ParametroMudanzaUnidad, T002J4_A818ParametroMudanzaPisoElev, T002J4_A40000ParametroMudanzaImagen_GXI, T002J4_A877ParametroMudanzaActivo,
               T002J4_A870ParametroMudanzaImagen
               }
               , new Object[] {
               T002J5_A730ParametroMudanzaId
               }
               , new Object[] {
               T002J6_A730ParametroMudanzaId
               }
               , new Object[] {
               T002J7_A730ParametroMudanzaId
               }
               , new Object[] {
               T002J8_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002J12_A735MudanzaId, T002J12_A766ItemAdicionalId
               }
               , new Object[] {
               T002J13_A735MudanzaId, T002J13_A751ItemCargaId
               }
               , new Object[] {
               T002J14_A735MudanzaId
               }
               , new Object[] {
               T002J15_A735MudanzaId
               }
               , new Object[] {
               T002J16_A735MudanzaId
               }
               , new Object[] {
               T002J17_A735MudanzaId
               }
               , new Object[] {
               T002J18_A730ParametroMudanzaId
               }
            }
         );
         Z877ParametroMudanzaActivo = true;
         A877ParametroMudanzaActivo = true;
         i877ParametroMudanzaActivo = true;
         AV15Pgmname = "ParametroMudanza";
      }

      private short wcpOAV13ParametroMudanzaId ;
      private short Z730ParametroMudanzaId ;
      private short Z818ParametroMudanzaPisoElev ;
      private short GxWebError ;
      private short AV13ParametroMudanzaId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
      private short Gx_BScreen ;
      private short RcdFound118 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtParametroMudanzaId_Enabled ;
      private int edtParametroMudanzaTitulo_Enabled ;
      private int edtParametroMudanzaNombre_Enabled ;
      private int edtParametroMudanzaDescripcion_Visible ;
      private int edtParametroMudanzaDescripcion_Enabled ;
      private int edtParametroMudanzaValor_Enabled ;
      private int edtParametroMudanzaPisoElev_Visible ;
      private int edtParametroMudanzaPisoElev_Enabled ;
      private int imgParametroMudanzaImagen_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private decimal Z733ParametroMudanzaValor ;
      private decimal A733ParametroMudanzaValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z734ParametroMudanzaUnidad ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbParametroMudanzaTipo_Internalname ;
      private string A734ParametroMudanzaUnidad ;
      private string cmbParametroMudanzaUnidad_Internalname ;
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
      private string edtParametroMudanzaId_Internalname ;
      private string TempTags ;
      private string edtParametroMudanzaId_Jsonclick ;
      private string cmbParametroMudanzaTipo_Jsonclick ;
      private string edtParametroMudanzaTitulo_Internalname ;
      private string edtParametroMudanzaTitulo_Jsonclick ;
      private string edtParametroMudanzaNombre_Internalname ;
      private string edtParametroMudanzaNombre_Jsonclick ;
      private string edtParametroMudanzaDescripcion_Internalname ;
      private string edtParametroMudanzaDescripcion_Jsonclick ;
      private string edtParametroMudanzaValor_Internalname ;
      private string edtParametroMudanzaValor_Jsonclick ;
      private string cmbParametroMudanzaUnidad_Jsonclick ;
      private string edtParametroMudanzaPisoElev_Internalname ;
      private string edtParametroMudanzaPisoElev_Jsonclick ;
      private string imgParametroMudanzaImagen_Internalname ;
      private string sImgUrl ;
      private string chkParametroMudanzaActivo_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode118 ;
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
      private string GXCCtlgxBlob ;
      private bool Z877ParametroMudanzaActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A877ParametroMudanzaActivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A870ParametroMudanzaImagen_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool i877ParametroMudanzaActivo ;
      private string Z731ParametroMudanzaTipo ;
      private string Z869ParametroMudanzaTitulo ;
      private string Z732ParametroMudanzaNombre ;
      private string Z812ParametroMudanzaDescripcion ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private string A40000ParametroMudanzaImagen_GXI ;
      private string Z40000ParametroMudanzaImagen_GXI ;
      private string A870ParametroMudanzaImagen ;
      private string Z870ParametroMudanzaImagen ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbParametroMudanzaTipo ;
      private GXCombobox cmbParametroMudanzaUnidad ;
      private GXCheckbox chkParametroMudanzaActivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private SdtParametroMudanza AV14ParametroMudanza ;
      private IDataStoreProvider pr_default ;
      private short[] T002J4_A730ParametroMudanzaId ;
      private string[] T002J4_A731ParametroMudanzaTipo ;
      private string[] T002J4_A869ParametroMudanzaTitulo ;
      private string[] T002J4_A732ParametroMudanzaNombre ;
      private string[] T002J4_A812ParametroMudanzaDescripcion ;
      private decimal[] T002J4_A733ParametroMudanzaValor ;
      private string[] T002J4_A734ParametroMudanzaUnidad ;
      private short[] T002J4_A818ParametroMudanzaPisoElev ;
      private string[] T002J4_A40000ParametroMudanzaImagen_GXI ;
      private bool[] T002J4_A877ParametroMudanzaActivo ;
      private string[] T002J4_A870ParametroMudanzaImagen ;
      private short[] T002J5_A730ParametroMudanzaId ;
      private short[] T002J3_A730ParametroMudanzaId ;
      private string[] T002J3_A731ParametroMudanzaTipo ;
      private string[] T002J3_A869ParametroMudanzaTitulo ;
      private string[] T002J3_A732ParametroMudanzaNombre ;
      private string[] T002J3_A812ParametroMudanzaDescripcion ;
      private decimal[] T002J3_A733ParametroMudanzaValor ;
      private string[] T002J3_A734ParametroMudanzaUnidad ;
      private short[] T002J3_A818ParametroMudanzaPisoElev ;
      private string[] T002J3_A40000ParametroMudanzaImagen_GXI ;
      private bool[] T002J3_A877ParametroMudanzaActivo ;
      private string[] T002J3_A870ParametroMudanzaImagen ;
      private short[] T002J6_A730ParametroMudanzaId ;
      private short[] T002J7_A730ParametroMudanzaId ;
      private short[] T002J2_A730ParametroMudanzaId ;
      private string[] T002J2_A731ParametroMudanzaTipo ;
      private string[] T002J2_A869ParametroMudanzaTitulo ;
      private string[] T002J2_A732ParametroMudanzaNombre ;
      private string[] T002J2_A812ParametroMudanzaDescripcion ;
      private decimal[] T002J2_A733ParametroMudanzaValor ;
      private string[] T002J2_A734ParametroMudanzaUnidad ;
      private short[] T002J2_A818ParametroMudanzaPisoElev ;
      private string[] T002J2_A40000ParametroMudanzaImagen_GXI ;
      private bool[] T002J2_A877ParametroMudanzaActivo ;
      private string[] T002J2_A870ParametroMudanzaImagen ;
      private short[] T002J8_A730ParametroMudanzaId ;
      private long[] T002J12_A735MudanzaId ;
      private short[] T002J12_A766ItemAdicionalId ;
      private long[] T002J13_A735MudanzaId ;
      private short[] T002J13_A751ItemCargaId ;
      private long[] T002J14_A735MudanzaId ;
      private long[] T002J15_A735MudanzaId ;
      private long[] T002J16_A735MudanzaId ;
      private long[] T002J17_A735MudanzaId ;
      private short[] T002J18_A730ParametroMudanzaId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class parametromudanza__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class parametromudanza__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002J2;
        prmT002J2 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J3;
        prmT002J3 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J4;
        prmT002J4 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J5;
        prmT002J5 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J6;
        prmT002J6 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J7;
        prmT002J7 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J8;
        prmT002J8 = new Object[] {
        new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
        new ParDef("@ParametroMudanzaTitulo",GXType.NVarChar,80,0) ,
        new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
        new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
        new ParDef("@ParametroMudanzaPisoElev",GXType.Int16,4,0) ,
        new ParDef("@ParametroMudanzaImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ParametroMudanzaImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=7, Tbl="ParametroMudanza", Fld="ParametroMudanzaImagen"} ,
        new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
        };
        Object[] prmT002J9;
        prmT002J9 = new Object[] {
        new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
        new ParDef("@ParametroMudanzaTitulo",GXType.NVarChar,80,0) ,
        new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
        new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
        new ParDef("@ParametroMudanzaPisoElev",GXType.Int16,4,0) ,
        new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0) ,
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J10;
        prmT002J10 = new Object[] {
        new ParDef("@ParametroMudanzaImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ParametroMudanzaImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="ParametroMudanza", Fld="ParametroMudanzaImagen"} ,
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J11;
        prmT002J11 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J12;
        prmT002J12 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J13;
        prmT002J13 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J14;
        prmT002J14 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J15;
        prmT002J15 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J16;
        prmT002J16 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J17;
        prmT002J17 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmT002J18;
        prmT002J18 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002J2", "SELECT [ParametroMudanzaId], [ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen_GXI], [ParametroMudanzaActivo], [ParametroMudanzaImagen] FROM [ParametroMudanza] WITH (UPDLOCK) WHERE [ParametroMudanzaId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J3", "SELECT [ParametroMudanzaId], [ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen_GXI], [ParametroMudanzaActivo], [ParametroMudanzaImagen] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J4", "SELECT TM1.[ParametroMudanzaId], TM1.[ParametroMudanzaTipo], TM1.[ParametroMudanzaTitulo], TM1.[ParametroMudanzaNombre], TM1.[ParametroMudanzaDescripcion], TM1.[ParametroMudanzaValor], TM1.[ParametroMudanzaUnidad], TM1.[ParametroMudanzaPisoElev], TM1.[ParametroMudanzaImagen_GXI], TM1.[ParametroMudanzaActivo], TM1.[ParametroMudanzaImagen] FROM [ParametroMudanza] TM1 WHERE TM1.[ParametroMudanzaId] = @ParametroMudanzaId ORDER BY TM1.[ParametroMudanzaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J5", "SELECT [ParametroMudanzaId] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ParametroMudanzaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J6", "SELECT TOP 1 [ParametroMudanzaId] FROM [ParametroMudanza] WHERE ( [ParametroMudanzaId] > @ParametroMudanzaId) ORDER BY [ParametroMudanzaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J7", "SELECT TOP 1 [ParametroMudanzaId] FROM [ParametroMudanza] WHERE ( [ParametroMudanzaId] < @ParametroMudanzaId) ORDER BY [ParametroMudanzaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J8", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI], [ParametroMudanzaActivo]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaTitulo, @ParametroMudanzaNombre, @ParametroMudanzaDescripcion, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaPisoElev, @ParametroMudanzaImagen, @ParametroMudanzaImagen_GXI, @ParametroMudanzaActivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002J8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J9", "UPDATE [ParametroMudanza] SET [ParametroMudanzaTipo]=@ParametroMudanzaTipo, [ParametroMudanzaTitulo]=@ParametroMudanzaTitulo, [ParametroMudanzaNombre]=@ParametroMudanzaNombre, [ParametroMudanzaDescripcion]=@ParametroMudanzaDescripcion, [ParametroMudanzaValor]=@ParametroMudanzaValor, [ParametroMudanzaUnidad]=@ParametroMudanzaUnidad, [ParametroMudanzaPisoElev]=@ParametroMudanzaPisoElev, [ParametroMudanzaActivo]=@ParametroMudanzaActivo  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK,prmT002J9)
           ,new CursorDef("T002J10", "UPDATE [ParametroMudanza] SET [ParametroMudanzaImagen]=@ParametroMudanzaImagen, [ParametroMudanzaImagen_GXI]=@ParametroMudanzaImagen_GXI  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK,prmT002J10)
           ,new CursorDef("T002J11", "DELETE FROM [ParametroMudanza]  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK,prmT002J11)
           ,new CursorDef("T002J12", "SELECT TOP 1 [MudanzaId], [ItemAdicionalId] FROM [MudanzaAdicional] WHERE [ItemAdicionalId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J13", "SELECT TOP 1 [MudanzaId], [ItemCargaId] FROM [MudanzaCarga] WHERE [ItemCargaId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J14", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoEstacionamDestinoId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J15", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoEstacionamOrigenId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J16", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoInmuebleDestinoId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J17", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoInmuebleOrigenId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J18", "SELECT [ParametroMudanzaId] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J18,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}

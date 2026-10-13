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
   public class listaagrupacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedoresTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A151ProveedoresTipoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A120ProfesionalesId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_agrupacion") == 0 )
         {
            gxnrGridlevel_agrupacion_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listaagrupacion.aspx")), "listaagrupacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listaagrupacion.aspx")))) ;
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
                  AV19Listaid = (long)(Math.Round(NumberUtil.Val( GetPar( "Listaid"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV19Listaid", StringUtil.LTrimStr( (decimal)(AV19Listaid), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19Listaid), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Lista Agrupacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtListaNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_agrupacion_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_agrupacion_newrow( ) ;
         /* End function gxnrGridlevel_agrupacion_newrow_invoke */
      }

      public listaagrupacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listaagrupacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_Listaid )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV19Listaid = aP1_Listaid;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbListaTipo = new GXCombobox();
         cmbAgrupacionEstado = new GXCombobox();
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
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp("", false, cmbListaTipo_Internalname, "Values", cmbListaTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaid_Internalname, context.GetMessage( "Listaid", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtListaid_Enabled!=0) ? context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ListaAgrupacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaNombre_Internalname, StringUtil.RTrim( A592ListaNombre), StringUtil.RTrim( context.localUtil.Format( A592ListaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ListaAgrupacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbListaTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbListaTipo, cmbListaTipo_Internalname, StringUtil.RTrim( A591ListaTipo), 1, cmbListaTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_ListaAgrupacion.htm");
         cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
         AssignProp("", false, cmbListaTipo_Internalname, "Values", (string)(cmbListaTipo.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_agrupacion_Internalname, divTableleaflevel_agrupacion_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_agrupacion( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrupacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrupacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrupacion.htm");
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

      protected void gxdraw_Gridlevel_agrupacion( )
      {
         /*  Grid Control  */
         StartGridControl38( ) ;
         nGXsfl_38_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount87 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_87 = 1;
               ScanStart2387( ) ;
               while ( RcdFound87 != 0 )
               {
                  init_level_properties87( ) ;
                  getByPrimaryKey2387( ) ;
                  AddRow2387( ) ;
                  ScanNext2387( ) ;
               }
               ScanEnd2387( ) ;
               nBlankRcdCount87 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2387( ) ;
            standaloneModal2387( ) ;
            sMode87 = Gx_mode;
            while ( nGXsfl_38_idx < nRC_GXsfl_38 )
            {
               bGXsfl_38_Refreshing = true;
               ReadRow2387( ) ;
               edtProveedorID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProveedorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProveedoresTipoDescripcion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedoresTipoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProveedorDocIdentidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesPrimerNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesSegundoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesApellidoPrimero_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtProfesionalesApellidoSegundo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               cmbAgrupacionEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRUPACIONESTADO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbAgrupacionEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgrupacionEstado.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtAgrupacionMotivo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRUPACIONMOTIVO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAgrupacionMotivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgrupacionMotivo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               imgprompt_133_Link = cgiGet( "PROMPT_133_"+sGXsfl_38_idx+"Link");
               imgprompt_133_Link = cgiGet( "PROMPT_120_"+sGXsfl_38_idx+"Link");
               if ( ( nRcdExists_87 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2387( ) ;
               }
               SendRow2387( ) ;
               bGXsfl_38_Refreshing = false;
            }
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount87 = 5;
            nRcdExists_87 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2387( ) ;
               while ( RcdFound87 != 0 )
               {
                  sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3887( ) ;
                  init_level_properties87( ) ;
                  standaloneNotModal2387( ) ;
                  getByPrimaryKey2387( ) ;
                  standaloneModal2387( ) ;
                  AddRow2387( ) ;
                  ScanNext2387( ) ;
               }
               ScanEnd2387( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode87 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
            SubsflControlProps_3887( ) ;
            InitAll2387( ) ;
            init_level_properties87( ) ;
            nRcdExists_87 = 0;
            nIsMod_87 = 0;
            nRcdDeleted_87 = 0;
            nBlankRcdCount87 = (short)(nBlankRcdUsr87+nBlankRcdCount87);
            fRowAdded = 0;
            while ( nBlankRcdCount87 > 0 )
            {
               standaloneNotModal2387( ) ;
               standaloneModal2387( ) ;
               AddRow2387( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount87 = (short)(nBlankRcdCount87-1);
            }
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_agrupacionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_agrupacion", Gridlevel_agrupacionContainer, subGridlevel_agrupacion_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_agrupacionContainerData", Gridlevel_agrupacionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_agrupacionContainerData"+"V", Gridlevel_agrupacionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_agrupacionContainerData"+"V"+"\" value='"+Gridlevel_agrupacionContainer.GridValuesHidden()+"'/>") ;
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
         E11232 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z590Listaid"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z592ListaNombre = cgiGet( "Z592ListaNombre");
               Z591ListaTipo = cgiGet( "Z591ListaTipo");
               Z593ListaEstado = cgiGet( "Z593ListaEstado");
               n593ListaEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A593ListaEstado)) ? true : false);
               A593ListaEstado = cgiGet( "Z593ListaEstado");
               n593ListaEstado = false;
               n593ListaEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A593ListaEstado)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV19Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vLISTAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A593ListaEstado = cgiGet( "LISTAESTADO");
               n593ListaEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A593ListaEstado)) ? true : false);
               AV22Pgmname = cgiGet( "vPGMNAME");
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
               A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               A592ListaNombre = cgiGet( edtListaNombre_Internalname);
               AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
               cmbListaTipo.Name = cmbListaTipo_Internalname;
               cmbListaTipo.CurrentValue = cgiGet( cmbListaTipo_Internalname);
               A591ListaTipo = cgiGet( cmbListaTipo_Internalname);
               AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ListaAgrupacion");
               A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               forbiddenHiddens.Add("Listaid", context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ListaEstado", StringUtil.RTrim( context.localUtil.Format( A593ListaEstado, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A590Listaid != Z590Listaid ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("listaagrupacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                     sMode83 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode83;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound83 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_230( ) ;
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
                        GX_FocusControl = edtListaid_Internalname;
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
                           E11232 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12232 ();
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
            E12232 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2383( ) ;
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
            DisableAttributes2383( ) ;
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

      protected void CONFIRM_230( )
      {
         BeforeValidate2383( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2383( ) ;
            }
            else
            {
               CheckExtendedTable2383( ) ;
               CloseExtendedTableCursors2383( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode83 = Gx_mode;
            CONFIRM_2387( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode83;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2387( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow2387( ) ;
            if ( ( nRcdExists_87 != 0 ) || ( nIsMod_87 != 0 ) )
            {
               GetKey2387( ) ;
               if ( ( nRcdExists_87 == 0 ) && ( nRcdDeleted_87 == 0 ) )
               {
                  if ( RcdFound87 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2387( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2387( ) ;
                        CloseExtendedTableCursors2387( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROVEEDORID_" + sGXsfl_38_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound87 != 0 )
                  {
                     if ( nRcdDeleted_87 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2387( ) ;
                        Load2387( ) ;
                        BeforeValidate2387( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2387( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_87 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2387( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2387( ) ;
                              CloseExtendedTableCursors2387( ) ;
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
                     if ( nRcdDeleted_87 == 0 )
                     {
                        GXCCtl = "PROVEEDORID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProveedorID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre)) ;
            ChangePostValue( edtProveedoresTipoDescripcion_Internalname, A279ProveedoresTipoDescripcion) ;
            ChangePostValue( edtProveedorDocIdentidad_Internalname, StringUtil.RTrim( A338ProveedorDocIdentidad)) ;
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ;
            ChangePostValue( edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ;
            ChangePostValue( edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ;
            ChangePostValue( edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ;
            ChangePostValue( cmbAgrupacionEstado_Internalname, StringUtil.RTrim( A588AgrupacionEstado)) ;
            ChangePostValue( edtAgrupacionMotivo_Internalname, A589AgrupacionMotivo) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "ZT_"+"Z588AgrupacionEstado_"+sGXsfl_38_idx, StringUtil.RTrim( Z588AgrupacionEstado)) ;
            ChangePostValue( "ZT_"+"Z589AgrupacionMotivo_"+sGXsfl_38_idx, Z589AgrupacionMotivo) ;
            ChangePostValue( "nRcdDeleted_87_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_87_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_87_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_87 != 0 )
            {
               ChangePostValue( "PROVEEDORID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRUPACIONESTADO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrupacionEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRUPACIONMOTIVO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrupacionMotivo_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption230( )
      {
      }

      protected void E11232( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV7IsAuthorized = true;
         AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrupacion_Insert", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrupacion_Update", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrupacion_Delete", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( ! AV7IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV22Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12232( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("listaagrupacionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM2383( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z592ListaNombre = T00238_A592ListaNombre[0];
               Z591ListaTipo = T00238_A591ListaTipo[0];
               Z593ListaEstado = T00238_A593ListaEstado[0];
            }
            else
            {
               Z592ListaNombre = A592ListaNombre;
               Z591ListaTipo = A591ListaTipo;
               Z593ListaEstado = A593ListaEstado;
            }
         }
         if ( GX_JID == -8 )
         {
            Z590Listaid = A590Listaid;
            Z592ListaNombre = A592ListaNombre;
            Z591ListaTipo = A591ListaTipo;
            Z593ListaEstado = A593ListaEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtListaid_Enabled = 0;
         AssignProp("", false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtListaid_Enabled = 0;
         AssignProp("", false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV19Listaid) )
         {
            A590Listaid = AV19Listaid;
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A591ListaTipo)) && ( Gx_BScreen == 0 ) )
         {
            A591ListaTipo = "PROV";
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            divTableleaflevel_agrupacion_Visible = (((StringUtil.StrCmp(A591ListaTipo, "ADM")!=0)) ? 1 : 0);
            AssignProp("", false, divTableleaflevel_agrupacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableleaflevel_agrupacion_Visible), 5, 0), true);
         }
      }

      protected void Load2383( )
      {
         /* Using cursor T00239 */
         pr_default.execute(7, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound83 = 1;
            A592ListaNombre = T00239_A592ListaNombre[0];
            AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
            A591ListaTipo = T00239_A591ListaTipo[0];
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
            A593ListaEstado = T00239_A593ListaEstado[0];
            n593ListaEstado = T00239_n593ListaEstado[0];
            ZM2383( -8) ;
         }
         pr_default.close(7);
         OnLoadActions2383( ) ;
      }

      protected void OnLoadActions2383( )
      {
         AV22Pgmname = "ListaAgrupacion";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         divTableleaflevel_agrupacion_Visible = (((StringUtil.StrCmp(A591ListaTipo, "ADM")!=0)) ? 1 : 0);
         AssignProp("", false, divTableleaflevel_agrupacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableleaflevel_agrupacion_Visible), 5, 0), true);
      }

      protected void CheckExtendedTable2383( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV22Pgmname = "ListaAgrupacion";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) || ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) || ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) || ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Lista Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "LISTATIPO");
            AnyError = 1;
            GX_FocusControl = cmbListaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         divTableleaflevel_agrupacion_Visible = (((StringUtil.StrCmp(A591ListaTipo, "ADM")!=0)) ? 1 : 0);
         AssignProp("", false, divTableleaflevel_agrupacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableleaflevel_agrupacion_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "Debe seleccionar un tipo diferente de lista", ""), 1, "LISTATIPO");
            AnyError = 1;
            GX_FocusControl = cmbListaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2383( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2383( )
      {
         /* Using cursor T002310 */
         pr_default.execute(8, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00238 */
         pr_default.execute(6, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM2383( 8) ;
            RcdFound83 = 1;
            A590Listaid = T00238_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            A592ListaNombre = T00238_A592ListaNombre[0];
            AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
            A591ListaTipo = T00238_A591ListaTipo[0];
            AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
            A593ListaEstado = T00238_A593ListaEstado[0];
            n593ListaEstado = T00238_n593ListaEstado[0];
            Z590Listaid = A590Listaid;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2383( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey2383( ) ;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey2383( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey2383( ) ;
         if ( RcdFound83 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound83 = 0;
         /* Using cursor T002311 */
         pr_default.execute(9, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002311_A590Listaid[0] < A590Listaid ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002311_A590Listaid[0] > A590Listaid ) ) )
            {
               A590Listaid = T002311_A590Listaid[0];
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound83 = 0;
         /* Using cursor T002312 */
         pr_default.execute(10, new Object[] {A590Listaid});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002312_A590Listaid[0] > A590Listaid ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002312_A590Listaid[0] < A590Listaid ) ) )
            {
               A590Listaid = T002312_A590Listaid[0];
               AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2383( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtListaNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2383( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( A590Listaid != Z590Listaid )
               {
                  A590Listaid = Z590Listaid;
                  AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LISTAID");
                  AnyError = 1;
                  GX_FocusControl = edtListaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtListaNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2383( ) ;
                  GX_FocusControl = edtListaNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A590Listaid != Z590Listaid )
               {
                  /* Insert record */
                  GX_FocusControl = edtListaNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2383( ) ;
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
                     GX_FocusControl = edtListaid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtListaNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2383( ) ;
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
         if ( A590Listaid != Z590Listaid )
         {
            A590Listaid = Z590Listaid;
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LISTAID");
            AnyError = 1;
            GX_FocusControl = edtListaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtListaNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2383( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00237 */
            pr_default.execute(5, new Object[] {A590Listaid});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lista"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z592ListaNombre, T00237_A592ListaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z591ListaTipo, T00237_A591ListaTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z593ListaEstado, T00237_A593ListaEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z592ListaNombre, T00237_A592ListaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagrupacion:[seudo value changed for attri]"+"ListaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z592ListaNombre);
                  GXUtil.WriteLogRaw("Current: ",T00237_A592ListaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z591ListaTipo, T00237_A591ListaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagrupacion:[seudo value changed for attri]"+"ListaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z591ListaTipo);
                  GXUtil.WriteLogRaw("Current: ",T00237_A591ListaTipo[0]);
               }
               if ( StringUtil.StrCmp(Z593ListaEstado, T00237_A593ListaEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagrupacion:[seudo value changed for attri]"+"ListaEstado");
                  GXUtil.WriteLogRaw("Old: ",Z593ListaEstado);
                  GXUtil.WriteLogRaw("Current: ",T00237_A593ListaEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Lista"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2383( )
      {
         BeforeValidate2383( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2383( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2383( 0) ;
            CheckOptimisticConcurrency2383( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2383( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2383( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002313 */
                     pr_default.execute(11, new Object[] {A592ListaNombre, A591ListaTipo, n593ListaEstado, A593ListaEstado});
                     A590Listaid = T002313_A590Listaid[0];
                     AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Lista");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2383( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption230( ) ;
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
               Load2383( ) ;
            }
            EndLevel2383( ) ;
         }
         CloseExtendedTableCursors2383( ) ;
      }

      protected void Update2383( )
      {
         BeforeValidate2383( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2383( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2383( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2383( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2383( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002314 */
                     pr_default.execute(12, new Object[] {A592ListaNombre, A591ListaTipo, n593ListaEstado, A593ListaEstado, A590Listaid});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Lista");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lista"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2383( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2383( ) ;
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
            EndLevel2383( ) ;
         }
         CloseExtendedTableCursors2383( ) ;
      }

      protected void DeferredUpdate2383( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2383( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2383( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2383( ) ;
            AfterConfirm2383( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2383( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2387( ) ;
                  while ( RcdFound87 != 0 )
                  {
                     getByPrimaryKey2387( ) ;
                     Delete2387( ) ;
                     ScanNext2387( ) ;
                  }
                  ScanEnd2387( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002315 */
                     pr_default.execute(13, new Object[] {A590Listaid});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Lista");
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2383( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2383( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV22Pgmname = "ListaAgrupacion";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
            divTableleaflevel_agrupacion_Visible = (((StringUtil.StrCmp(A591ListaTipo, "ADM")!=0)) ? 1 : 0);
            AssignProp("", false, divTableleaflevel_agrupacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableleaflevel_agrupacion_Visible), 5, 0), true);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002316 */
            pr_default.execute(14, new Object[] {A590Listaid});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesRestriccion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002317 */
            pr_default.execute(15, new Object[] {A590Listaid});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupar Usuarios y Proveedores", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel2387( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow2387( ) ;
            if ( ( nRcdExists_87 != 0 ) || ( nIsMod_87 != 0 ) )
            {
               standaloneNotModal2387( ) ;
               GetKey2387( ) ;
               if ( ( nRcdExists_87 == 0 ) && ( nRcdDeleted_87 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2387( ) ;
               }
               else
               {
                  if ( RcdFound87 != 0 )
                  {
                     if ( ( nRcdDeleted_87 != 0 ) && ( nRcdExists_87 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2387( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_87 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2387( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_87 == 0 )
                     {
                        GXCCtl = "PROVEEDORID_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProveedorID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre)) ;
            ChangePostValue( edtProveedoresTipoDescripcion_Internalname, A279ProveedoresTipoDescripcion) ;
            ChangePostValue( edtProveedorDocIdentidad_Internalname, StringUtil.RTrim( A338ProveedorDocIdentidad)) ;
            ChangePostValue( edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId)) ;
            ChangePostValue( edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ;
            ChangePostValue( edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ;
            ChangePostValue( edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ;
            ChangePostValue( edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ;
            ChangePostValue( cmbAgrupacionEstado_Internalname, StringUtil.RTrim( A588AgrupacionEstado)) ;
            ChangePostValue( edtAgrupacionMotivo_Internalname, A589AgrupacionMotivo) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx, StringUtil.RTrim( Z120ProfesionalesId)) ;
            ChangePostValue( "ZT_"+"Z588AgrupacionEstado_"+sGXsfl_38_idx, StringUtil.RTrim( Z588AgrupacionEstado)) ;
            ChangePostValue( "ZT_"+"Z589AgrupacionMotivo_"+sGXsfl_38_idx, Z589AgrupacionMotivo) ;
            ChangePostValue( "nRcdDeleted_87_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_87_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_87_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_87), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_87 != 0 )
            {
               ChangePostValue( "PROVEEDORID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRUPACIONESTADO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrupacionEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AGRUPACIONMOTIVO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrupacionMotivo_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2387( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_87 = 0;
         nIsMod_87 = 0;
         nRcdDeleted_87 = 0;
      }

      protected void ProcessLevel2383( )
      {
         /* Save parent mode. */
         sMode83 = Gx_mode;
         ProcessNestedLevel2387( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2383( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2383( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.CommitDataStores("listaagrupacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues230( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.RollbackDataStores("listaagrupacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2383( )
      {
         /* Scan By routine */
         /* Using cursor T002318 */
         pr_default.execute(16);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound83 = 1;
            A590Listaid = T002318_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2383( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound83 = 1;
            A590Listaid = T002318_A590Listaid[0];
            AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         }
      }

      protected void ScanEnd2383( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm2383( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2383( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2383( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2383( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2383( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2383( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2383( )
      {
         edtListaid_Enabled = 0;
         AssignProp("", false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         edtListaNombre_Enabled = 0;
         AssignProp("", false, edtListaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaNombre_Enabled), 5, 0), true);
         cmbListaTipo.Enabled = 0;
         AssignProp("", false, cmbListaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaTipo.Enabled), 5, 0), true);
      }

      protected void ZM2387( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z588AgrupacionEstado = T00233_A588AgrupacionEstado[0];
               Z589AgrupacionMotivo = T00233_A589AgrupacionMotivo[0];
            }
            else
            {
               Z588AgrupacionEstado = A588AgrupacionEstado;
               Z589AgrupacionMotivo = A589AgrupacionMotivo;
            }
         }
         if ( GX_JID == -9 )
         {
            Z590Listaid = A590Listaid;
            Z588AgrupacionEstado = A588AgrupacionEstado;
            Z589AgrupacionMotivo = A589AgrupacionMotivo;
            Z133ProveedorID = A133ProveedorID;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z279ProveedoresTipoDescripcion = A279ProveedoresTipoDescripcion;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
         }
      }

      protected void standaloneNotModal2387( )
      {
      }

      protected void standaloneModal2387( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProveedorID_Enabled = 0;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            edtProveedorID_Enabled = 1;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
      }

      protected void Load2387( )
      {
         /* Using cursor T002319 */
         pr_default.execute(17, new Object[] {A590Listaid, A133ProveedorID, A120ProfesionalesId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound87 = 1;
            A151ProveedoresTipoId = T002319_A151ProveedoresTipoId[0];
            A282ProveedorNombre = T002319_A282ProveedorNombre[0];
            A279ProveedoresTipoDescripcion = T002319_A279ProveedoresTipoDescripcion[0];
            A338ProveedorDocIdentidad = T002319_A338ProveedorDocIdentidad[0];
            A166ProfesionalesPrimerNombre = T002319_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T002319_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = T002319_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = T002319_A192ProfesionalesApellidoSegundo[0];
            A588AgrupacionEstado = T002319_A588AgrupacionEstado[0];
            A589AgrupacionMotivo = T002319_A589AgrupacionMotivo[0];
            ZM2387( -9) ;
         }
         pr_default.close(17);
         OnLoadActions2387( ) ;
      }

      protected void OnLoadActions2387( )
      {
      }

      protected void CheckExtendedTable2387( )
      {
         nIsDirty_87 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal2387( ) ;
         /* Using cursor T00234 */
         pr_default.execute(2, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A151ProveedoresTipoId = T00234_A151ProveedoresTipoId[0];
         A282ProveedorNombre = T00234_A282ProveedorNombre[0];
         A338ProveedorDocIdentidad = T00234_A338ProveedorDocIdentidad[0];
         pr_default.close(2);
         /* Using cursor T00236 */
         pr_default.execute(4, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A279ProveedoresTipoDescripcion = T00236_A279ProveedoresTipoDescripcion[0];
         pr_default.close(4);
         /* Using cursor T00235 */
         pr_default.execute(3, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T00235_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T00235_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T00235_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T00235_A192ProfesionalesApellidoSegundo[0];
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A588AgrupacionEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A588AgrupacionEstado, "VIN") == 0 ) || ( StringUtil.StrCmp(A588AgrupacionEstado, "DES") == 0 ) ) )
         {
            GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Agrupacion Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbAgrupacionEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2387( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable2387( )
      {
      }

      protected void gxLoad_10( long A133ProveedorID )
      {
         /* Using cursor T002320 */
         pr_default.execute(18, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A151ProveedoresTipoId = T002320_A151ProveedoresTipoId[0];
         A282ProveedorNombre = T002320_A282ProveedorNombre[0];
         A338ProveedorDocIdentidad = T002320_A338ProveedorDocIdentidad[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A338ProveedorDocIdentidad))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_12( long A151ProveedoresTipoId )
      {
         /* Using cursor T002321 */
         pr_default.execute(19, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A279ProveedoresTipoDescripcion = T002321_A279ProveedoresTipoDescripcion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A279ProveedoresTipoDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_11( string A120ProfesionalesId )
      {
         /* Using cursor T002322 */
         pr_default.execute(20, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PROFESIONALESID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T002322_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T002322_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T002322_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T002322_A192ProfesionalesApellidoSegundo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A191ProfesionalesSegundoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A192ProfesionalesApellidoSegundo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey2387( )
      {
         /* Using cursor T002323 */
         pr_default.execute(21, new Object[] {A590Listaid, A133ProveedorID, A120ProfesionalesId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound87 = 1;
         }
         else
         {
            RcdFound87 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey2387( )
      {
         /* Using cursor T00233 */
         pr_default.execute(1, new Object[] {A590Listaid, A133ProveedorID, A120ProfesionalesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2387( 9) ;
            RcdFound87 = 1;
            InitializeNonKey2387( ) ;
            A588AgrupacionEstado = T00233_A588AgrupacionEstado[0];
            A589AgrupacionMotivo = T00233_A589AgrupacionMotivo[0];
            A133ProveedorID = T00233_A133ProveedorID[0];
            A120ProfesionalesId = T00233_A120ProfesionalesId[0];
            Z590Listaid = A590Listaid;
            Z133ProveedorID = A133ProveedorID;
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2387( ) ;
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound87 = 0;
            InitializeNonKey2387( ) ;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2387( ) ;
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2387( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2387( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00232 */
            pr_default.execute(0, new Object[] {A590Listaid, A133ProveedorID, A120ProfesionalesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaAgrupacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z588AgrupacionEstado, T00232_A588AgrupacionEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z589AgrupacionMotivo, T00232_A589AgrupacionMotivo[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z588AgrupacionEstado, T00232_A588AgrupacionEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagrupacion:[seudo value changed for attri]"+"AgrupacionEstado");
                  GXUtil.WriteLogRaw("Old: ",Z588AgrupacionEstado);
                  GXUtil.WriteLogRaw("Current: ",T00232_A588AgrupacionEstado[0]);
               }
               if ( StringUtil.StrCmp(Z589AgrupacionMotivo, T00232_A589AgrupacionMotivo[0]) != 0 )
               {
                  GXUtil.WriteLog("listaagrupacion:[seudo value changed for attri]"+"AgrupacionMotivo");
                  GXUtil.WriteLogRaw("Old: ",Z589AgrupacionMotivo);
                  GXUtil.WriteLogRaw("Current: ",T00232_A589AgrupacionMotivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ListaAgrupacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2387( )
      {
         BeforeValidate2387( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2387( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2387( 0) ;
            CheckOptimisticConcurrency2387( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2387( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2387( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002324 */
                     pr_default.execute(22, new Object[] {A590Listaid, A588AgrupacionEstado, A589AgrupacionMotivo, A133ProveedorID, A120ProfesionalesId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("ListaAgrupacion");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load2387( ) ;
            }
            EndLevel2387( ) ;
         }
         CloseExtendedTableCursors2387( ) ;
      }

      protected void Update2387( )
      {
         BeforeValidate2387( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2387( ) ;
         }
         if ( ( nIsMod_87 != 0 ) || ( nIsDirty_87 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2387( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2387( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2387( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002325 */
                        pr_default.execute(23, new Object[] {A588AgrupacionEstado, A589AgrupacionMotivo, A590Listaid, A133ProveedorID, A120ProfesionalesId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("ListaAgrupacion");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaAgrupacion"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2387( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2387( ) ;
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
               EndLevel2387( ) ;
            }
         }
         CloseExtendedTableCursors2387( ) ;
      }

      protected void DeferredUpdate2387( )
      {
      }

      protected void Delete2387( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2387( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2387( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2387( ) ;
            AfterConfirm2387( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2387( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002326 */
                  pr_default.execute(24, new Object[] {A590Listaid, A133ProveedorID, A120ProfesionalesId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("ListaAgrupacion");
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
         sMode87 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2387( ) ;
         Gx_mode = sMode87;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2387( )
      {
         standaloneModal2387( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002327 */
            pr_default.execute(25, new Object[] {A133ProveedorID});
            A151ProveedoresTipoId = T002327_A151ProveedoresTipoId[0];
            A282ProveedorNombre = T002327_A282ProveedorNombre[0];
            A338ProveedorDocIdentidad = T002327_A338ProveedorDocIdentidad[0];
            pr_default.close(25);
            /* Using cursor T002328 */
            pr_default.execute(26, new Object[] {A151ProveedoresTipoId});
            A279ProveedoresTipoDescripcion = T002328_A279ProveedoresTipoDescripcion[0];
            pr_default.close(26);
            /* Using cursor T002329 */
            pr_default.execute(27, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T002329_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T002329_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = T002329_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = T002329_A192ProfesionalesApellidoSegundo[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel2387( )
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

      public void ScanStart2387( )
      {
         /* Scan By routine */
         /* Using cursor T002330 */
         pr_default.execute(28, new Object[] {A590Listaid});
         RcdFound87 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound87 = 1;
            A133ProveedorID = T002330_A133ProveedorID[0];
            A120ProfesionalesId = T002330_A120ProfesionalesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2387( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound87 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound87 = 1;
            A133ProveedorID = T002330_A133ProveedorID[0];
            A120ProfesionalesId = T002330_A120ProfesionalesId[0];
         }
      }

      protected void ScanEnd2387( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm2387( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2387( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2387( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2387( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2387( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2387( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2387( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProveedoresTipoDescripcion_Enabled = 0;
         AssignProp("", false, edtProveedoresTipoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesSegundoNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProfesionalesApellidoSegundo_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         cmbAgrupacionEstado.Enabled = 0;
         AssignProp("", false, cmbAgrupacionEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAgrupacionEstado.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtAgrupacionMotivo_Enabled = 0;
         AssignProp("", false, edtAgrupacionMotivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgrupacionMotivo_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void send_integrity_lvl_hashes2387( )
      {
      }

      protected void send_integrity_lvl_hashes2383( )
      {
      }

      protected void SubsflControlProps_3887( )
      {
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_38_idx;
         imgprompt_133_Internalname = "PROMPT_133_"+sGXsfl_38_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_38_idx;
         edtProveedoresTipoDescripcion_Internalname = "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_idx;
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_38_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_38_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_idx;
         cmbAgrupacionEstado_Internalname = "AGRUPACIONESTADO_"+sGXsfl_38_idx;
         edtAgrupacionMotivo_Internalname = "AGRUPACIONMOTIVO_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_3887( )
      {
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_38_fel_idx;
         imgprompt_133_Internalname = "PROMPT_133_"+sGXsfl_38_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_38_fel_idx;
         edtProveedoresTipoDescripcion_Internalname = "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_fel_idx;
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_38_fel_idx;
         imgprompt_120_Internalname = "PROMPT_120_"+sGXsfl_38_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_fel_idx;
         cmbAgrupacionEstado_Internalname = "AGRUPACIONESTADO_"+sGXsfl_38_fel_idx;
         edtAgrupacionMotivo_Internalname = "AGRUPACIONMOTIVO_"+sGXsfl_38_fel_idx;
      }

      protected void AddRow2387( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3887( ) ;
         SendRow2387( ) ;
      }

      protected void SendRow2387( )
      {
         Gridlevel_agrupacionRow = GXWebRow.GetNew(context);
         if ( subGridlevel_agrupacion_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_agrupacion_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_agrupacion_Class, "") != 0 )
            {
               subGridlevel_agrupacion_Linesclass = subGridlevel_agrupacion_Class+"Odd";
            }
         }
         else if ( subGridlevel_agrupacion_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_agrupacion_Backstyle = 0;
            subGridlevel_agrupacion_Backcolor = subGridlevel_agrupacion_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_agrupacion_Class, "") != 0 )
            {
               subGridlevel_agrupacion_Linesclass = subGridlevel_agrupacion_Class+"Uniform";
            }
         }
         else if ( subGridlevel_agrupacion_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_agrupacion_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_agrupacion_Class, "") != 0 )
            {
               subGridlevel_agrupacion_Linesclass = subGridlevel_agrupacion_Class+"Odd";
            }
            subGridlevel_agrupacion_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_agrupacion_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_agrupacion_Backstyle = 1;
            if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
            {
               subGridlevel_agrupacion_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_agrupacion_Class, "") != 0 )
               {
                  subGridlevel_agrupacion_Linesclass = subGridlevel_agrupacion_Class+"Even";
               }
            }
            else
            {
               subGridlevel_agrupacion_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_agrupacion_Class, "") != 0 )
               {
                  subGridlevel_agrupacion_Linesclass = subGridlevel_agrupacion_Class+"Odd";
               }
            }
         }
         imgprompt_120_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALESID_"+sGXsfl_38_idx+"'), id:'"+"PROFESIONALESID_"+sGXsfl_38_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vFULLNAME"+"'), id:'"+"vFULLNAME"+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_87_"+sGXsfl_38_idx+","+"'', false"+","+"false"+");");
         imgprompt_133_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORID_"+sGXsfl_38_idx+"'), id:'"+"PROVEEDORID_"+sGXsfl_38_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROVEEDORNOMBRE_"+sGXsfl_38_idx+"'), id:'"+"PROVEEDORNOMBRE_"+sGXsfl_38_idx+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_87_"+sGXsfl_38_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorID_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_133_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_133_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_agrupacionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_133_Internalname,(string)sImgUrl,(string)imgprompt_133_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_133_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedoresTipoDescripcion_Internalname,(string)A279ProveedoresTipoDescripcion,(string)A279ProveedoresTipoDescripcion,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedoresTipoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedoresTipoDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)38,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorDocIdentidad_Internalname,StringUtil.RTrim( A338ProveedorDocIdentidad),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorDocIdentidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorDocIdentidad_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_120_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_120_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_agrupacionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_120_Internalname,(string)sImgUrl,(string)imgprompt_120_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_120_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesPrimerNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesSegundoNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesApellidoPrimero_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesApellidoSegundo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_38_idx + "',38)\"";
         if ( ( cmbAgrupacionEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_38_idx;
            cmbAgrupacionEstado.Name = GXCCtl;
            cmbAgrupacionEstado.WebTags = "";
            cmbAgrupacionEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
            cmbAgrupacionEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
            cmbAgrupacionEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
            if ( cmbAgrupacionEstado.ItemCount > 0 )
            {
               A588AgrupacionEstado = cmbAgrupacionEstado.getValidValue(A588AgrupacionEstado);
            }
         }
         /* ComboBox */
         Gridlevel_agrupacionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAgrupacionEstado,(string)cmbAgrupacionEstado_Internalname,StringUtil.RTrim( A588AgrupacionEstado),(short)1,(string)cmbAgrupacionEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbAgrupacionEstado.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"",(bool)true,(short)0});
         cmbAgrupacionEstado.CurrentValue = StringUtil.RTrim( A588AgrupacionEstado);
         AssignProp("", false, cmbAgrupacionEstado_Internalname, "Values", (string)(cmbAgrupacionEstado.ToJavascriptSource()), !bGXsfl_38_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_87_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_agrupacionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgrupacionMotivo_Internalname,(string)A589AgrupacionMotivo,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgrupacionMotivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAgrupacionMotivo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_agrupacionRow);
         send_integrity_lvl_hashes2387( ) ;
         GXCCtl = "Z133ProveedorID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z120ProfesionalesId));
         GXCCtl = "Z588AgrupacionEstado_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z588AgrupacionEstado));
         GXCCtl = "Z589AgrupacionMotivo_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z589AgrupacionMotivo);
         GXCCtl = "nRcdDeleted_87_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_87), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_87_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_87), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_87_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_87), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_38_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV8TrnContext);
         }
         GXCCtl = "vLISTAID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AGRUPACIONESTADO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrupacionEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AGRUPACIONMOTIVO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrupacionMotivo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_133_"+sGXsfl_38_idx+"Link", StringUtil.RTrim( imgprompt_133_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_120_"+sGXsfl_38_idx+"Link", StringUtil.RTrim( imgprompt_120_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_agrupacionContainer.AddRow(Gridlevel_agrupacionRow);
      }

      protected void ReadRow2387( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3887( ) ;
         edtProveedorID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedoresTipoDescripcion_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORESTIPODESCRIPCION_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorDocIdentidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORDOCIDENTIDAD_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesPrimerNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesSegundoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesApellidoPrimero_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalesApellidoSegundo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbAgrupacionEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRUPACIONESTADO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAgrupacionMotivo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGRUPACIONMOTIVO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_133_Link = cgiGet( "PROMPT_133_"+sGXsfl_38_idx+"Link");
         imgprompt_133_Link = cgiGet( "PROMPT_120_"+sGXsfl_38_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_38_idx;
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
         A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
         A279ProveedoresTipoDescripcion = cgiGet( edtProveedoresTipoDescripcion_Internalname);
         A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
         A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
         A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
         A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
         A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
         A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
         cmbAgrupacionEstado.Name = cmbAgrupacionEstado_Internalname;
         cmbAgrupacionEstado.CurrentValue = cgiGet( cmbAgrupacionEstado_Internalname);
         A588AgrupacionEstado = cgiGet( cmbAgrupacionEstado_Internalname);
         A589AgrupacionMotivo = cgiGet( edtAgrupacionMotivo_Internalname);
         GXCCtl = "Z133ProveedorID_" + sGXsfl_38_idx;
         Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z120ProfesionalesId_" + sGXsfl_38_idx;
         Z120ProfesionalesId = cgiGet( GXCCtl);
         GXCCtl = "Z588AgrupacionEstado_" + sGXsfl_38_idx;
         Z588AgrupacionEstado = cgiGet( GXCCtl);
         GXCCtl = "Z589AgrupacionMotivo_" + sGXsfl_38_idx;
         Z589AgrupacionMotivo = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_87_" + sGXsfl_38_idx;
         nRcdDeleted_87 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_87_" + sGXsfl_38_idx;
         nRcdExists_87 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_87_" + sGXsfl_38_idx;
         nIsMod_87 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProfesionalesId_Enabled = edtProfesionalesId_Enabled;
         defedtProveedorID_Enabled = edtProveedorID_Enabled;
      }

      protected void ConfirmValues230( )
      {
         nGXsfl_38_idx = 0;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3887( ) ;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_3887( ) ;
            ChangePostValue( "Z133ProveedorID_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z133ProveedorID_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z120ProfesionalesId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z120ProfesionalesId_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z588AgrupacionEstado_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z588AgrupacionEstado_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z588AgrupacionEstado_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z589AgrupacionMotivo_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z589AgrupacionMotivo_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z589AgrupacionMotivo_"+sGXsfl_38_idx) ;
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
         GXEncryptionTmp = "listaagrupacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV19Listaid,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listaagrupacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ListaAgrupacion");
         forbiddenHiddens.Add("Listaid", context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ListaEstado", StringUtil.RTrim( context.localUtil.Format( A593ListaEstado, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("listaagrupacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z590Listaid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z592ListaNombre", StringUtil.RTrim( Z592ListaNombre));
         GxWebStd.gx_hidden_field( context, "Z591ListaTipo", StringUtil.RTrim( Z591ListaTipo));
         GxWebStd.gx_hidden_field( context, "Z593ListaEstado", StringUtil.RTrim( Z593ListaEstado));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_38_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19Listaid), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "LISTAESTADO", StringUtil.RTrim( A593ListaEstado));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
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
         GXEncryptionTmp = "listaagrupacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV19Listaid,18,0));
         return formatLink("listaagrupacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ListaAgrupacion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista Agrupacion", "") ;
      }

      protected void InitializeNonKey2383( )
      {
         A592ListaNombre = "";
         AssignAttri("", false, "A592ListaNombre", A592ListaNombre);
         A593ListaEstado = "";
         n593ListaEstado = false;
         AssignAttri("", false, "A593ListaEstado", A593ListaEstado);
         A591ListaTipo = "PROV";
         AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
         Z592ListaNombre = "";
         Z591ListaTipo = "";
         Z593ListaEstado = "";
      }

      protected void InitAll2383( )
      {
         A590Listaid = 0;
         AssignAttri("", false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
         InitializeNonKey2383( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A591ListaTipo = i591ListaTipo;
         AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
      }

      protected void InitializeNonKey2387( )
      {
         A151ProveedoresTipoId = 0;
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         A282ProveedorNombre = "";
         A279ProveedoresTipoDescripcion = "";
         A338ProveedorDocIdentidad = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A588AgrupacionEstado = "";
         A589AgrupacionMotivo = "";
         Z588AgrupacionEstado = "";
         Z589AgrupacionMotivo = "";
      }

      protected void InitAll2387( )
      {
         A133ProveedorID = 0;
         A120ProfesionalesId = "";
         InitializeNonKey2387( ) ;
      }

      protected void StandaloneModalInsert2387( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693208959", true, true, false);
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
         context.AddJavascriptSource("listaagrupacion.js", "?202693208959", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties87( )
      {
         edtProfesionalesId_Enabled = defedtProfesionalesId_Enabled;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtProveedorID_Enabled = defedtProveedorID_Enabled;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void StartGridControl38( )
      {
         Gridlevel_agrupacionContainer.AddObjectProperty("GridName", "Gridlevel_agrupacion");
         Gridlevel_agrupacionContainer.AddObjectProperty("Header", subGridlevel_agrupacion_Header);
         Gridlevel_agrupacionContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_agrupacionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_agrupacionContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A279ProveedoresTipoDescripcion));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedoresTipoDescripcion_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A338ProveedorDocIdentidad)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A588AgrupacionEstado)));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbAgrupacionEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_agrupacionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A589AgrupacionMotivo));
         Gridlevel_agrupacionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAgrupacionMotivo_Enabled), 5, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddColumnProperties(Gridlevel_agrupacionColumn);
         Gridlevel_agrupacionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Selectedindex), 4, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Allowselection), 1, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Allowhovering), 1, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_agrupacionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_agrupacion_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtListaid_Internalname = "LISTAID";
         edtListaNombre_Internalname = "LISTANOMBRE";
         cmbListaTipo_Internalname = "LISTATIPO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedoresTipoDescripcion_Internalname = "PROVEEDORESTIPODESCRIPCION";
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         cmbAgrupacionEstado_Internalname = "AGRUPACIONESTADO";
         edtAgrupacionMotivo_Internalname = "AGRUPACIONMOTIVO";
         divTableleaflevel_agrupacion_Internalname = "TABLELEAFLEVEL_AGRUPACION";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_133_Internalname = "PROMPT_133";
         imgprompt_120_Internalname = "PROMPT_120";
         subGridlevel_agrupacion_Internalname = "GRIDLEVEL_AGRUPACION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_agrupacion_Allowcollapsing = 0;
         subGridlevel_agrupacion_Allowselection = 0;
         subGridlevel_agrupacion_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Lista Agrupacion", "");
         edtAgrupacionMotivo_Jsonclick = "";
         cmbAgrupacionEstado_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         imgprompt_120_Visible = 1;
         imgprompt_120_Link = "";
         edtProfesionalesId_Jsonclick = "";
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedoresTipoDescripcion_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         imgprompt_133_Visible = 1;
         imgprompt_133_Link = "";
         imgprompt_133_Visible = 1;
         edtProveedorID_Jsonclick = "";
         subGridlevel_agrupacion_Class = "WorkWith";
         subGridlevel_agrupacion_Backcolorstyle = 0;
         edtAgrupacionMotivo_Enabled = 1;
         cmbAgrupacionEstado.Enabled = 1;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 1;
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedoresTipoDescripcion_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         divTableleaflevel_agrupacion_Visible = 1;
         cmbListaTipo_Jsonclick = "";
         cmbListaTipo.Enabled = 1;
         edtListaNombre_Jsonclick = "";
         edtListaNombre_Enabled = 1;
         edtListaid_Jsonclick = "";
         edtListaid_Enabled = 0;
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

      protected void gxnrGridlevel_agrupacion_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3887( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2387( ) ;
            standaloneModal2387( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2387( ) ;
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_3887( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_agrupacionContainer)) ;
         /* End function gxnrGridlevel_agrupacion_newrow */
      }

      protected void init_web_controls( )
      {
         cmbListaTipo.Name = "LISTATIPO";
         cmbListaTipo.WebTags = "";
         cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
         cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
         cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
         cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
         if ( cmbListaTipo.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A591ListaTipo)) )
            {
               A591ListaTipo = "PROV";
               AssignAttri("", false, "A591ListaTipo", A591ListaTipo);
            }
         }
         GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_38_idx;
         cmbAgrupacionEstado.Name = GXCCtl;
         cmbAgrupacionEstado.WebTags = "";
         cmbAgrupacionEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
         cmbAgrupacionEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
         cmbAgrupacionEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
         if ( cmbAgrupacionEstado.ItemCount > 0 )
         {
            A588AgrupacionEstado = cmbAgrupacionEstado.getValidValue(A588AgrupacionEstado);
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

      public void Valid_Proveedorid( )
      {
         /* Using cursor T002327 */
         pr_default.execute(25, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
         }
         A151ProveedoresTipoId = T002327_A151ProveedoresTipoId[0];
         A282ProveedorNombre = T002327_A282ProveedorNombre[0];
         A338ProveedorDocIdentidad = T002327_A338ProveedorDocIdentidad[0];
         pr_default.close(25);
         /* Using cursor T002328 */
         pr_default.execute(26, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A279ProveedoresTipoDescripcion = T002328_A279ProveedoresTipoDescripcion[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, ".", "")));
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A338ProveedorDocIdentidad", StringUtil.RTrim( A338ProveedorDocIdentidad));
         AssignAttri("", false, "A279ProveedoresTipoDescripcion", A279ProveedoresTipoDescripcion);
      }

      public void Valid_Profesionalesid( )
      {
         /* Using cursor T002329 */
         pr_default.execute(27, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         A166ProfesionalesPrimerNombre = T002329_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T002329_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T002329_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T002329_A192ProfesionalesApellidoSegundo[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         AssignAttri("", false, "A192ProfesionalesApellidoSegundo", StringUtil.RTrim( A192ProfesionalesApellidoSegundo));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV19Listaid',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV19Listaid',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A593ListaEstado',fld:'LISTAESTADO',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12232',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[]");
         setEventMetadata("VALID_LISTAID",",oparms:[]}");
         setEventMetadata("VALID_LISTATIPO","{handler:'Valid_Listatipo',iparms:[]");
         setEventMetadata("VALID_LISTATIPO",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A338ProveedorDocIdentidad',fld:'PROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'A279ProveedoresTipoDescripcion',fld:'PROVEEDORESTIPODESCRIPCION',pic:'',type:'vchar'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A338ProveedorDocIdentidad',fld:'PROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'A279ProveedoresTipoDescripcion',fld:'PROVEEDORESTIPODESCRIPCION',pic:'',type:'vchar'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_AGRUPACIONESTADO","{handler:'Valid_Agrupacionestado',iparms:[]");
         setEventMetadata("VALID_AGRUPACIONESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Agrupacionmotivo',iparms:[]");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(25);
         pr_default.close(27);
         pr_default.close(26);
         pr_default.close(6);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z592ListaNombre = "";
         Z591ListaTipo = "";
         Z593ListaEstado = "";
         Z120ProfesionalesId = "";
         Z588AgrupacionEstado = "";
         Z589AgrupacionMotivo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A120ProfesionalesId = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A591ListaTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A592ListaNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_agrupacionContainer = new GXWebGrid( context);
         sMode87 = "";
         sStyleString = "";
         A593ListaEstado = "";
         AV22Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode83 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A282ProveedorNombre = "";
         A279ProveedoresTipoDescripcion = "";
         A338ProveedorDocIdentidad = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A588AgrupacionEstado = "";
         A589AgrupacionMotivo = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         T00239_A590Listaid = new long[1] ;
         T00239_A592ListaNombre = new string[] {""} ;
         T00239_A591ListaTipo = new string[] {""} ;
         T00239_A593ListaEstado = new string[] {""} ;
         T00239_n593ListaEstado = new bool[] {false} ;
         T002310_A590Listaid = new long[1] ;
         T00238_A590Listaid = new long[1] ;
         T00238_A592ListaNombre = new string[] {""} ;
         T00238_A591ListaTipo = new string[] {""} ;
         T00238_A593ListaEstado = new string[] {""} ;
         T00238_n593ListaEstado = new bool[] {false} ;
         T002311_A590Listaid = new long[1] ;
         T002312_A590Listaid = new long[1] ;
         T00237_A590Listaid = new long[1] ;
         T00237_A592ListaNombre = new string[] {""} ;
         T00237_A591ListaTipo = new string[] {""} ;
         T00237_A593ListaEstado = new string[] {""} ;
         T00237_n593ListaEstado = new bool[] {false} ;
         T002313_A590Listaid = new long[1] ;
         T002316_A976ProfesionalesRestriccionId = new long[1] ;
         T002317_A590Listaid = new long[1] ;
         T002317_A18SecUserId = new long[1] ;
         T002318_A590Listaid = new long[1] ;
         Z282ProveedorNombre = "";
         Z338ProveedorDocIdentidad = "";
         Z279ProveedoresTipoDescripcion = "";
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         T002319_A151ProveedoresTipoId = new long[1] ;
         T002319_A590Listaid = new long[1] ;
         T002319_A282ProveedorNombre = new string[] {""} ;
         T002319_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002319_A338ProveedorDocIdentidad = new string[] {""} ;
         T002319_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002319_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T002319_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002319_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T002319_A588AgrupacionEstado = new string[] {""} ;
         T002319_A589AgrupacionMotivo = new string[] {""} ;
         T002319_A133ProveedorID = new long[1] ;
         T002319_A120ProfesionalesId = new string[] {""} ;
         T00234_A151ProveedoresTipoId = new long[1] ;
         T00234_A282ProveedorNombre = new string[] {""} ;
         T00234_A338ProveedorDocIdentidad = new string[] {""} ;
         T00236_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T00235_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T00235_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T00235_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T00235_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T002320_A151ProveedoresTipoId = new long[1] ;
         T002320_A282ProveedorNombre = new string[] {""} ;
         T002320_A338ProveedorDocIdentidad = new string[] {""} ;
         T002321_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002322_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002322_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T002322_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002322_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T002323_A590Listaid = new long[1] ;
         T002323_A133ProveedorID = new long[1] ;
         T002323_A120ProfesionalesId = new string[] {""} ;
         T00233_A590Listaid = new long[1] ;
         T00233_A588AgrupacionEstado = new string[] {""} ;
         T00233_A589AgrupacionMotivo = new string[] {""} ;
         T00233_A133ProveedorID = new long[1] ;
         T00233_A120ProfesionalesId = new string[] {""} ;
         T00232_A590Listaid = new long[1] ;
         T00232_A588AgrupacionEstado = new string[] {""} ;
         T00232_A589AgrupacionMotivo = new string[] {""} ;
         T00232_A133ProveedorID = new long[1] ;
         T00232_A120ProfesionalesId = new string[] {""} ;
         T002327_A151ProveedoresTipoId = new long[1] ;
         T002327_A282ProveedorNombre = new string[] {""} ;
         T002327_A338ProveedorDocIdentidad = new string[] {""} ;
         T002328_A279ProveedoresTipoDescripcion = new string[] {""} ;
         T002329_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T002329_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T002329_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T002329_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T002330_A590Listaid = new long[1] ;
         T002330_A133ProveedorID = new long[1] ;
         T002330_A120ProfesionalesId = new string[] {""} ;
         Gridlevel_agrupacionRow = new GXWebRow();
         subGridlevel_agrupacion_Linesclass = "";
         ROClassString = "";
         imgprompt_133_gximage = "";
         sImgUrl = "";
         imgprompt_120_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i591ListaTipo = "";
         Gridlevel_agrupacionColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.listaagrupacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listaagrupacion__default(),
            new Object[][] {
                new Object[] {
               T00232_A590Listaid, T00232_A588AgrupacionEstado, T00232_A589AgrupacionMotivo, T00232_A133ProveedorID, T00232_A120ProfesionalesId
               }
               , new Object[] {
               T00233_A590Listaid, T00233_A588AgrupacionEstado, T00233_A589AgrupacionMotivo, T00233_A133ProveedorID, T00233_A120ProfesionalesId
               }
               , new Object[] {
               T00234_A151ProveedoresTipoId, T00234_A282ProveedorNombre, T00234_A338ProveedorDocIdentidad
               }
               , new Object[] {
               T00235_A166ProfesionalesPrimerNombre, T00235_A191ProfesionalesSegundoNombre, T00235_A167ProfesionalesApellidoPrimero, T00235_A192ProfesionalesApellidoSegundo
               }
               , new Object[] {
               T00236_A279ProveedoresTipoDescripcion
               }
               , new Object[] {
               T00237_A590Listaid, T00237_A592ListaNombre, T00237_A591ListaTipo, T00237_A593ListaEstado, T00237_n593ListaEstado
               }
               , new Object[] {
               T00238_A590Listaid, T00238_A592ListaNombre, T00238_A591ListaTipo, T00238_A593ListaEstado, T00238_n593ListaEstado
               }
               , new Object[] {
               T00239_A590Listaid, T00239_A592ListaNombre, T00239_A591ListaTipo, T00239_A593ListaEstado, T00239_n593ListaEstado
               }
               , new Object[] {
               T002310_A590Listaid
               }
               , new Object[] {
               T002311_A590Listaid
               }
               , new Object[] {
               T002312_A590Listaid
               }
               , new Object[] {
               T002313_A590Listaid
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002316_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T002317_A590Listaid, T002317_A18SecUserId
               }
               , new Object[] {
               T002318_A590Listaid
               }
               , new Object[] {
               T002319_A151ProveedoresTipoId, T002319_A590Listaid, T002319_A282ProveedorNombre, T002319_A279ProveedoresTipoDescripcion, T002319_A338ProveedorDocIdentidad, T002319_A166ProfesionalesPrimerNombre, T002319_A191ProfesionalesSegundoNombre, T002319_A167ProfesionalesApellidoPrimero, T002319_A192ProfesionalesApellidoSegundo, T002319_A588AgrupacionEstado,
               T002319_A589AgrupacionMotivo, T002319_A133ProveedorID, T002319_A120ProfesionalesId
               }
               , new Object[] {
               T002320_A151ProveedoresTipoId, T002320_A282ProveedorNombre, T002320_A338ProveedorDocIdentidad
               }
               , new Object[] {
               T002321_A279ProveedoresTipoDescripcion
               }
               , new Object[] {
               T002322_A166ProfesionalesPrimerNombre, T002322_A191ProfesionalesSegundoNombre, T002322_A167ProfesionalesApellidoPrimero, T002322_A192ProfesionalesApellidoSegundo
               }
               , new Object[] {
               T002323_A590Listaid, T002323_A133ProveedorID, T002323_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002327_A151ProveedoresTipoId, T002327_A282ProveedorNombre, T002327_A338ProveedorDocIdentidad
               }
               , new Object[] {
               T002328_A279ProveedoresTipoDescripcion
               }
               , new Object[] {
               T002329_A166ProfesionalesPrimerNombre, T002329_A191ProfesionalesSegundoNombre, T002329_A167ProfesionalesApellidoPrimero, T002329_A192ProfesionalesApellidoSegundo
               }
               , new Object[] {
               T002330_A590Listaid, T002330_A133ProveedorID, T002330_A120ProfesionalesId
               }
            }
         );
         AV22Pgmname = "ListaAgrupacion";
         Z591ListaTipo = "PROV";
         A591ListaTipo = "PROV";
         i591ListaTipo = "PROV";
      }

      private short nIsMod_87 ;
      private short nRcdDeleted_87 ;
      private short nRcdExists_87 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount87 ;
      private short RcdFound87 ;
      private short nBlankRcdUsr87 ;
      private short Gx_BScreen ;
      private short RcdFound83 ;
      private short nIsDirty_87 ;
      private short subGridlevel_agrupacion_Backcolorstyle ;
      private short subGridlevel_agrupacion_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_agrupacion_Allowselection ;
      private short subGridlevel_agrupacion_Allowhovering ;
      private short subGridlevel_agrupacion_Allowcollapsing ;
      private short subGridlevel_agrupacion_Collapsed ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int trnEnded ;
      private int edtListaid_Enabled ;
      private int edtListaNombre_Enabled ;
      private int divTableleaflevel_agrupacion_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedoresTipoDescripcion_Enabled ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtAgrupacionMotivo_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_agrupacion_Backcolor ;
      private int subGridlevel_agrupacion_Allbackcolor ;
      private int imgprompt_133_Visible ;
      private int imgprompt_120_Visible ;
      private int defedtProfesionalesId_Enabled ;
      private int defedtProveedorID_Enabled ;
      private int idxLst ;
      private int subGridlevel_agrupacion_Selectedindex ;
      private int subGridlevel_agrupacion_Selectioncolor ;
      private int subGridlevel_agrupacion_Hoveringcolor ;
      private long wcpOAV19Listaid ;
      private long Z590Listaid ;
      private long Z133ProveedorID ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long AV19Listaid ;
      private long A590Listaid ;
      private long GRIDLEVEL_AGRUPACION_nFirstRecordOnPage ;
      private long Z151ProveedoresTipoId ;
      private string sPrefix ;
      private string sGXsfl_38_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z592ListaNombre ;
      private string Z591ListaTipo ;
      private string Z593ListaEstado ;
      private string Z120ProfesionalesId ;
      private string Z588AgrupacionEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A120ProfesionalesId ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtListaNombre_Internalname ;
      private string A591ListaTipo ;
      private string cmbListaTipo_Internalname ;
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
      private string edtListaid_Internalname ;
      private string TempTags ;
      private string edtListaid_Jsonclick ;
      private string A592ListaNombre ;
      private string edtListaNombre_Jsonclick ;
      private string cmbListaTipo_Jsonclick ;
      private string divTableleaflevel_agrupacion_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode87 ;
      private string edtProveedorID_Internalname ;
      private string edtProveedorNombre_Internalname ;
      private string edtProveedoresTipoDescripcion_Internalname ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string edtProfesionalesId_Internalname ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string cmbAgrupacionEstado_Internalname ;
      private string edtAgrupacionMotivo_Internalname ;
      private string imgprompt_133_Link ;
      private string sStyleString ;
      private string subGridlevel_agrupacion_Internalname ;
      private string A593ListaEstado ;
      private string AV22Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode83 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A282ProveedorNombre ;
      private string A338ProveedorDocIdentidad ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A588AgrupacionEstado ;
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string Z338ProveedorDocIdentidad ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z192ProfesionalesApellidoSegundo ;
      private string imgprompt_133_Internalname ;
      private string imgprompt_120_Internalname ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGridlevel_agrupacion_Class ;
      private string subGridlevel_agrupacion_Linesclass ;
      private string imgprompt_120_Link ;
      private string ROClassString ;
      private string edtProveedorID_Jsonclick ;
      private string imgprompt_133_gximage ;
      private string sImgUrl ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedoresTipoDescripcion_Jsonclick ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string imgprompt_120_gximage ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string cmbAgrupacionEstado_Jsonclick ;
      private string edtAgrupacionMotivo_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i591ListaTipo ;
      private string subGridlevel_agrupacion_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool n593ListaEstado ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV7IsAuthorized ;
      private bool GXt_boolean1 ;
      private string A279ProveedoresTipoDescripcion ;
      private string Z279ProveedoresTipoDescripcion ;
      private string Z589AgrupacionMotivo ;
      private string A589AgrupacionMotivo ;
      private IGxSession AV9WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_agrupacionContainer ;
      private GXWebRow Gridlevel_agrupacionRow ;
      private GXWebColumn Gridlevel_agrupacionColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbListaTipo ;
      private GXCombobox cmbAgrupacionEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T00239_A590Listaid ;
      private string[] T00239_A592ListaNombre ;
      private string[] T00239_A591ListaTipo ;
      private string[] T00239_A593ListaEstado ;
      private bool[] T00239_n593ListaEstado ;
      private long[] T002310_A590Listaid ;
      private long[] T00238_A590Listaid ;
      private string[] T00238_A592ListaNombre ;
      private string[] T00238_A591ListaTipo ;
      private string[] T00238_A593ListaEstado ;
      private bool[] T00238_n593ListaEstado ;
      private long[] T002311_A590Listaid ;
      private long[] T002312_A590Listaid ;
      private long[] T00237_A590Listaid ;
      private string[] T00237_A592ListaNombre ;
      private string[] T00237_A591ListaTipo ;
      private string[] T00237_A593ListaEstado ;
      private bool[] T00237_n593ListaEstado ;
      private long[] T002313_A590Listaid ;
      private long[] T002316_A976ProfesionalesRestriccionId ;
      private long[] T002317_A590Listaid ;
      private long[] T002317_A18SecUserId ;
      private long[] T002318_A590Listaid ;
      private long[] T002319_A151ProveedoresTipoId ;
      private long[] T002319_A590Listaid ;
      private string[] T002319_A282ProveedorNombre ;
      private string[] T002319_A279ProveedoresTipoDescripcion ;
      private string[] T002319_A338ProveedorDocIdentidad ;
      private string[] T002319_A166ProfesionalesPrimerNombre ;
      private string[] T002319_A191ProfesionalesSegundoNombre ;
      private string[] T002319_A167ProfesionalesApellidoPrimero ;
      private string[] T002319_A192ProfesionalesApellidoSegundo ;
      private string[] T002319_A588AgrupacionEstado ;
      private string[] T002319_A589AgrupacionMotivo ;
      private long[] T002319_A133ProveedorID ;
      private string[] T002319_A120ProfesionalesId ;
      private long[] T00234_A151ProveedoresTipoId ;
      private string[] T00234_A282ProveedorNombre ;
      private string[] T00234_A338ProveedorDocIdentidad ;
      private string[] T00236_A279ProveedoresTipoDescripcion ;
      private string[] T00235_A166ProfesionalesPrimerNombre ;
      private string[] T00235_A191ProfesionalesSegundoNombre ;
      private string[] T00235_A167ProfesionalesApellidoPrimero ;
      private string[] T00235_A192ProfesionalesApellidoSegundo ;
      private long[] T002320_A151ProveedoresTipoId ;
      private string[] T002320_A282ProveedorNombre ;
      private string[] T002320_A338ProveedorDocIdentidad ;
      private string[] T002321_A279ProveedoresTipoDescripcion ;
      private string[] T002322_A166ProfesionalesPrimerNombre ;
      private string[] T002322_A191ProfesionalesSegundoNombre ;
      private string[] T002322_A167ProfesionalesApellidoPrimero ;
      private string[] T002322_A192ProfesionalesApellidoSegundo ;
      private long[] T002323_A590Listaid ;
      private long[] T002323_A133ProveedorID ;
      private string[] T002323_A120ProfesionalesId ;
      private long[] T00233_A590Listaid ;
      private string[] T00233_A588AgrupacionEstado ;
      private string[] T00233_A589AgrupacionMotivo ;
      private long[] T00233_A133ProveedorID ;
      private string[] T00233_A120ProfesionalesId ;
      private long[] T00232_A590Listaid ;
      private string[] T00232_A588AgrupacionEstado ;
      private string[] T00232_A589AgrupacionMotivo ;
      private long[] T00232_A133ProveedorID ;
      private string[] T00232_A120ProfesionalesId ;
      private long[] T002327_A151ProveedoresTipoId ;
      private string[] T002327_A282ProveedorNombre ;
      private string[] T002327_A338ProveedorDocIdentidad ;
      private string[] T002328_A279ProveedoresTipoDescripcion ;
      private string[] T002329_A166ProfesionalesPrimerNombre ;
      private string[] T002329_A191ProfesionalesSegundoNombre ;
      private string[] T002329_A167ProfesionalesApellidoPrimero ;
      private string[] T002329_A192ProfesionalesApellidoSegundo ;
      private long[] T002330_A590Listaid ;
      private long[] T002330_A133ProveedorID ;
      private string[] T002330_A120ProfesionalesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class listaagrupacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class listaagrupacion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00232;
        prmT00232 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00233;
        prmT00233 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00234;
        prmT00234 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT00235;
        prmT00235 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00236;
        prmT00236 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT00237;
        prmT00237 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT00238;
        prmT00238 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT00239;
        prmT00239 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002310;
        prmT002310 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002311;
        prmT002311 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002312;
        prmT002312 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002313;
        prmT002313 = new Object[] {
        new ParDef("@ListaNombre",GXType.NChar,80,0) ,
        new ParDef("@ListaTipo",GXType.NChar,4,0) ,
        new ParDef("@ListaEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmT002314;
        prmT002314 = new Object[] {
        new ParDef("@ListaNombre",GXType.NChar,80,0) ,
        new ParDef("@ListaTipo",GXType.NChar,4,0) ,
        new ParDef("@ListaEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002315;
        prmT002315 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002316;
        prmT002316 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002317;
        prmT002317 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        Object[] prmT002318;
        prmT002318 = new Object[] {
        };
        Object[] prmT002319;
        prmT002319 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002320;
        prmT002320 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002321;
        prmT002321 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT002322;
        prmT002322 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002323;
        prmT002323 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002324;
        prmT002324 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@AgrupacionEstado",GXType.NChar,3,0) ,
        new ParDef("@AgrupacionMotivo",GXType.NVarChar,80,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002325;
        prmT002325 = new Object[] {
        new ParDef("@AgrupacionEstado",GXType.NChar,3,0) ,
        new ParDef("@AgrupacionMotivo",GXType.NVarChar,80,0) ,
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002326;
        prmT002326 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002327;
        prmT002327 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002328;
        prmT002328 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT002329;
        prmT002329 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT002330;
        prmT002330 = new Object[] {
        new ParDef("@Listaid",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00232", "SELECT [Listaid], [AgrupacionEstado], [AgrupacionMotivo], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WITH (UPDLOCK) WHERE [Listaid] = @Listaid AND [ProveedorID] = @ProveedorID AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00232,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00233", "SELECT [Listaid], [AgrupacionEstado], [AgrupacionMotivo], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [Listaid] = @Listaid AND [ProveedorID] = @ProveedorID AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00233,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00234", "SELECT [ProveedoresTipoId], [ProveedorNombre], [ProveedorDocIdentidad] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00234,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00235", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00235,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00236", "SELECT [ProveedoresTipoDescripcion] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00236,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00237", "SELECT [Listaid], [ListaNombre], [ListaTipo], [ListaEstado] FROM [Lista] WITH (UPDLOCK) WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT00237,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00238", "SELECT [Listaid], [ListaNombre], [ListaTipo], [ListaEstado] FROM [Lista] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT00238,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00239", "SELECT TM1.[Listaid], TM1.[ListaNombre], TM1.[ListaTipo], TM1.[ListaEstado] FROM [Lista] TM1 WHERE TM1.[Listaid] = @Listaid ORDER BY TM1.[Listaid]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00239,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002310", "SELECT [Listaid] FROM [Lista] WHERE [Listaid] = @Listaid  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002311", "SELECT TOP 1 [Listaid] FROM [Lista] WHERE ( [Listaid] > @Listaid) ORDER BY [Listaid]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002311,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002312", "SELECT TOP 1 [Listaid] FROM [Lista] WHERE ( [Listaid] < @Listaid) ORDER BY [Listaid] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002312,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002313", "INSERT INTO [Lista]([ListaNombre], [ListaTipo], [ListaEstado]) VALUES(@ListaNombre, @ListaTipo, @ListaEstado); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002313,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002314", "UPDATE [Lista] SET [ListaNombre]=@ListaNombre, [ListaTipo]=@ListaTipo, [ListaEstado]=@ListaEstado  WHERE [Listaid] = @Listaid", GxErrorMask.GX_NOMASK,prmT002314)
           ,new CursorDef("T002315", "DELETE FROM [Lista]  WHERE [Listaid] = @Listaid", GxErrorMask.GX_NOMASK,prmT002315)
           ,new CursorDef("T002316", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002316,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002317", "SELECT TOP 1 [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE [Listaid] = @Listaid ",true, GxErrorMask.GX_NOMASK, false, this,prmT002317,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002318", "SELECT [Listaid] FROM [Lista] ORDER BY [Listaid]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002318,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002319", "SELECT T2.[ProveedoresTipoId], T1.[Listaid], T2.[ProveedorNombre], T3.[ProveedoresTipoDescripcion], T2.[ProveedorDocIdentidad], T4.[ProfesionalesPrimerNombre], T4.[ProfesionalesSegundoNombre], T4.[ProfesionalesApellidoPrimero], T4.[ProfesionalesApellidoSegundo], T1.[AgrupacionEstado], T1.[AgrupacionMotivo], T1.[ProveedorID], T1.[ProfesionalesId] FROM ((([ListaAgrupacion] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [ProveedoresTipo] T3 ON T3.[ProveedoresTipoId] = T2.[ProveedoresTipoId]) INNER JOIN [Profesionales] T4 ON T4.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[Listaid] = @Listaid and T1.[ProveedorID] = @ProveedorID and T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[Listaid], T1.[ProveedorID], T1.[ProfesionalesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002319,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002320", "SELECT [ProveedoresTipoId], [ProveedorNombre], [ProveedorDocIdentidad] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002320,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002321", "SELECT [ProveedoresTipoDescripcion] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002321,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002322", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002322,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002323", "SELECT [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [Listaid] = @Listaid AND [ProveedorID] = @ProveedorID AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002323,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002324", "INSERT INTO [ListaAgrupacion]([Listaid], [AgrupacionEstado], [AgrupacionMotivo], [ProveedorID], [ProfesionalesId]) VALUES(@Listaid, @AgrupacionEstado, @AgrupacionMotivo, @ProveedorID, @ProfesionalesId)", GxErrorMask.GX_NOMASK,prmT002324)
           ,new CursorDef("T002325", "UPDATE [ListaAgrupacion] SET [AgrupacionEstado]=@AgrupacionEstado, [AgrupacionMotivo]=@AgrupacionMotivo  WHERE [Listaid] = @Listaid AND [ProveedorID] = @ProveedorID AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT002325)
           ,new CursorDef("T002326", "DELETE FROM [ListaAgrupacion]  WHERE [Listaid] = @Listaid AND [ProveedorID] = @ProveedorID AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT002326)
           ,new CursorDef("T002327", "SELECT [ProveedoresTipoId], [ProveedorNombre], [ProveedorDocIdentidad] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002327,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002328", "SELECT [ProveedoresTipoDescripcion] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002328,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002329", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002329,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002330", "SELECT [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [Listaid] = @Listaid ORDER BY [Listaid], [ProveedorID], [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002330,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 25);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 30);
              ((string[]) buf[7])[0] = rslt.getString(8, 30);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
     }
  }

}

}

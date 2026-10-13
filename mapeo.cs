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
   public class mapeo : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MEDIDASID") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAMEDIDASID2U135( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"INVENTARIOID") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAINVENTARIOID2U135( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A919STComerciosID = (long)(Math.Round(NumberUtil.Val( GetPar( "STComerciosID"), "."), 18, MidpointRounding.ToEven));
            n919STComerciosID = false;
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A919STComerciosID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A552ConexionesID = GetPar( "ConexionesID");
            n552ConexionesID = false;
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A552ConexionesID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A121RubrosId, A137MedidasID, A135InventarioId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_referencia") == 0 )
         {
            gxnrGridlevel_referencia_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylelevel_listado") == 0 )
         {
            gxnrFreestylelevel_listado_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "mapeo.aspx")), "mapeo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "mapeo.aspx")))) ;
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
                  AV7MapeoID = (long)(Math.Round(NumberUtil.Val( GetPar( "MapeoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MapeoID", StringUtil.LTrimStr( (decimal)(AV7MapeoID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMAPEOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MapeoID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Mapeo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_referencia_newrow_invoke( )
      {
         nRC_GXsfl_105 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_105"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_105_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_105_idx = GetPar( "sGXsfl_105_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_referencia_newrow( ) ;
         /* End function gxnrGridlevel_referencia_newrow_invoke */
      }

      protected void gxnrFreestylelevel_listado_newrow_invoke( )
      {
         nRC_GXsfl_69 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_69"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_69_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_69_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_69_idx = GetPar( "sGXsfl_69_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylelevel_listado_newrow( ) ;
         /* End function gxnrFreestylelevel_listado_newrow_invoke */
      }

      public mapeo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mapeo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_MapeoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MapeoID = aP1_MapeoID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProveedorEstado = new GXCombobox();
         cmbSTComerciosEstado = new GXCombobox();
         cmbMapeoEstado = new GXCombobox();
         cmbMapeoListadoEstado = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
         cmbMapeoListadoReferenciaEstado = new GXCombobox();
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
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp("", false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
         }
         if ( cmbSTComerciosEstado.ItemCount > 0 )
         {
            A924STComerciosEstado = cmbSTComerciosEstado.getValidValue(A924STComerciosEstado);
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
            AssignProp("", false, cmbSTComerciosEstado_Internalname, "Values", cmbSTComerciosEstado.ToJavascriptSource(), true);
         }
         if ( cmbMapeoEstado.ItemCount > 0 )
         {
            A922MapeoEstado = cmbMapeoEstado.getValidValue(A922MapeoEstado);
            n922MapeoEstado = false;
            AssignAttri("", false, "A922MapeoEstado", A922MapeoEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMapeoEstado.CurrentValue = StringUtil.RTrim( A922MapeoEstado);
            AssignProp("", false, cmbMapeoEstado_Internalname, "Values", cmbMapeoEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMapeoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMapeoID_Internalname, context.GetMessage( "Mapeo ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMapeoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A918MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMapeoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMapeoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMapeoID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Comercio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Mapeo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_133_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_133_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_133_Internalname, sImgUrl, imgprompt_133_Link, "", "", context.GetTheme( ), imgprompt_133_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Proveedor Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProveedorEstado_Internalname, context.GetMessage( "Proveedor Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProveedorEstado, cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado), 1, cmbProveedorEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_Mapeo.htm");
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSTComerciosID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSTComerciosID_Internalname, context.GetMessage( "Comercio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSTComerciosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A919STComerciosID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSTComerciosID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSTComerciosID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Mapeo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_919_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_919_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_919_Internalname, sImgUrl, imgprompt_919_Link, "", "", context.GetTheme( ), imgprompt_919_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSTComerciosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSTComerciosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSTComerciosNombre_Internalname, StringUtil.RTrim( A923STComerciosNombre), StringUtil.RTrim( context.localUtil.Format( A923STComerciosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSTComerciosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSTComerciosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSTComerciosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSTComerciosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSTComerciosEstado, cmbSTComerciosEstado_Internalname, StringUtil.RTrim( A924STComerciosEstado), 1, cmbSTComerciosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSTComerciosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_Mapeo.htm");
         cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
         AssignProp("", false, cmbSTComerciosEstado_Internalname, "Values", (string)(cmbSTComerciosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesID_Internalname, context.GetMessage( "Código de Conexión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesID_Internalname, StringUtil.RTrim( A552ConexionesID), StringUtil.RTrim( context.localUtil.Format( A552ConexionesID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesID_Enabled, 1, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Mapeo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_552_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_552_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_552_Internalname, sImgUrl, imgprompt_552_Link, "", "", context.GetTheme( ), imgprompt_552_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConexionesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConexionesNombre_Internalname, context.GetMessage( "Conexiones Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConexionesNombre_Internalname, StringUtil.RTrim( A556ConexionesNombre), StringUtil.RTrim( context.localUtil.Format( A556ConexionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConexionesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConexionesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbMapeoEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMapeoEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMapeoEstado, cmbMapeoEstado_Internalname, StringUtil.RTrim( A922MapeoEstado), 1, cmbMapeoEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMapeoEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_Mapeo.htm");
         cmbMapeoEstado.CurrentValue = StringUtil.RTrim( A922MapeoEstado);
         AssignProp("", false, cmbMapeoEstado_Internalname, "Values", (string)(cmbMapeoEstado.ToJavascriptSource()), true);
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
         /* User Defined Control */
         ucDvpanel_tableintermediatelevel_listado.SetProperty("Width", Dvpanel_tableintermediatelevel_listado_Width);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("AutoWidth", Dvpanel_tableintermediatelevel_listado_Autowidth);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("AutoHeight", Dvpanel_tableintermediatelevel_listado_Autoheight);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("Cls", Dvpanel_tableintermediatelevel_listado_Cls);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("Title", Dvpanel_tableintermediatelevel_listado_Title);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("Collapsible", Dvpanel_tableintermediatelevel_listado_Collapsible);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("Collapsed", Dvpanel_tableintermediatelevel_listado_Collapsed);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("ShowCollapseIcon", Dvpanel_tableintermediatelevel_listado_Showcollapseicon);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("IconPosition", Dvpanel_tableintermediatelevel_listado_Iconposition);
         ucDvpanel_tableintermediatelevel_listado.SetProperty("AutoScroll", Dvpanel_tableintermediatelevel_listado_Autoscroll);
         ucDvpanel_tableintermediatelevel_listado.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableintermediatelevel_listado_Internalname, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADOContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEINTERMEDIATELEVEL_LISTADOContainer"+"TableIntermediateLevel_Listado"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableintermediatelevel_listado_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Freestylelevel_listado( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mapeo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mapeo.htm");
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

      protected void gxdraw_Freestylelevel_listado( )
      {
         /*  Grid Control  */
         StartGridControl69( ) ;
         /* Save parent mode. */
         sMode135 = Gx_mode;
         nGXsfl_69_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount135 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_135 = 1;
               ScanStart2U135( ) ;
               while ( RcdFound135 != 0 )
               {
                  init_level_properties135( ) ;
                  getByPrimaryKey2U135( ) ;
                  AddRow2U135( ) ;
                  ScanNext2U135( ) ;
               }
               ScanEnd2U135( ) ;
               nBlankRcdCount135 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2U135( ) ;
            standaloneModal2U135( ) ;
            sMode135 = Gx_mode;
            while ( nGXsfl_69_idx < nRC_GXsfl_69 )
            {
               bGXsfl_69_Refreshing = true;
               ReadRow2U135( ) ;
               edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_69_Refreshing);
               cmbMapeoListadoEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOESTADO_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbMapeoListadoEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMapeoListadoEstado.Enabled), 5, 0), !bGXsfl_69_Refreshing);
               dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_69_Refreshing);
               dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_69_Refreshing);
               edtMapeoListadoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADONOMBRE_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMapeoListadoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoNombre_Enabled), 5, 0), !bGXsfl_69_Refreshing);
               edtInventarioRefCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOREFCODE_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioRefCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioRefCode_Enabled), 5, 0), !bGXsfl_69_Refreshing);
               imgprompt_133_Link = cgiGet( "PROMPT_121_137_135_"+sGXsfl_69_idx+"Link");
               if ( ( nRcdExists_135 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2U135( ) ;
               }
               SendRow2U135( ) ;
               bGXsfl_69_Refreshing = false;
            }
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount135 = 5;
            nRcdExists_135 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2U135( ) ;
               while ( RcdFound135 != 0 )
               {
                  sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_69135( ) ;
                  init_level_properties135( ) ;
                  standaloneNotModal2U135( ) ;
                  getByPrimaryKey2U135( ) ;
                  standaloneModal2U135( ) ;
                  AddRow2U135( ) ;
                  ScanNext2U135( ) ;
               }
               ScanEnd2U135( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode135 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx+1), 4, 0), 4, "0");
            SubsflControlProps_69135( ) ;
            InitAll2U135( ) ;
            init_level_properties135( ) ;
            nRcdExists_135 = 0;
            nIsMod_135 = 0;
            nRcdDeleted_135 = 0;
            nBlankRcdCount135 = (short)(nBlankRcdUsr135+nBlankRcdCount135);
            fRowAdded = 0;
            while ( nBlankRcdCount135 > 0 )
            {
               standaloneNotModal2U135( ) ;
               standaloneModal2U135( ) ;
               AddRow2U135( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount135 = (short)(nBlankRcdCount135-1);
            }
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         /* Restore parent mode. */
         Gx_mode = sMode135;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Freestylelevel_listadoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylelevel_listado", Freestylelevel_listadoContainer, subFreestylelevel_listado_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Freestylelevel_listadoContainerData", Freestylelevel_listadoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Freestylelevel_listadoContainerData"+"V", Freestylelevel_listadoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylelevel_listadoContainerData"+"V"+"\" value='"+Freestylelevel_listadoContainer.GridValuesHidden()+"'/>") ;
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
         E112U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z918MapeoID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z918MapeoID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z922MapeoEstado = cgiGet( "Z922MapeoEstado");
               n922MapeoEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A922MapeoEstado)) ? true : false);
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z919STComerciosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n919STComerciosID = ((0==A919STComerciosID) ? true : false);
               Z552ConexionesID = cgiGet( "Z552ConexionesID");
               n552ConexionesID = (String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_69 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_69"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N919STComerciosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n919STComerciosID = ((0==A919STComerciosID) ? true : false);
               N552ConexionesID = cgiGet( "N552ConexionesID");
               n552ConexionesID = (String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ? true : false);
               AV7MapeoID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vMAPEOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV13Insert_ProveedorID), 18, 0));
               AV14Insert_STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_STCOMERCIOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_STComerciosID", StringUtil.LTrimStr( (decimal)(AV14Insert_STComerciosID), 18, 0));
               AV15Insert_ConexionesID = cgiGet( "vINSERT_CONEXIONESID");
               AssignAttri("", false, "AV15Insert_ConexionesID", AV15Insert_ConexionesID);
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
               Dvpanel_tableintermediatelevel_listado_Objectcall = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Objectcall");
               Dvpanel_tableintermediatelevel_listado_Class = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Class");
               Dvpanel_tableintermediatelevel_listado_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Enabled"));
               Dvpanel_tableintermediatelevel_listado_Width = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Width");
               Dvpanel_tableintermediatelevel_listado_Height = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Height");
               Dvpanel_tableintermediatelevel_listado_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Autowidth"));
               Dvpanel_tableintermediatelevel_listado_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Autoheight"));
               Dvpanel_tableintermediatelevel_listado_Cls = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Cls");
               Dvpanel_tableintermediatelevel_listado_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Showheader"));
               Dvpanel_tableintermediatelevel_listado_Title = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Title");
               Dvpanel_tableintermediatelevel_listado_Titletype = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Titletype");
               Dvpanel_tableintermediatelevel_listado_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Collapsible"));
               Dvpanel_tableintermediatelevel_listado_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Collapsed"));
               Dvpanel_tableintermediatelevel_listado_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Showcollapseicon"));
               Dvpanel_tableintermediatelevel_listado_Iconposition = cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Iconposition");
               Dvpanel_tableintermediatelevel_listado_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Autoscroll"));
               Dvpanel_tableintermediatelevel_listado_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Visible"));
               Dvpanel_tableintermediatelevel_listado_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A918MapeoID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMapeoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROVEEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A133ProveedorID = 0;
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               }
               else
               {
                  A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               }
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
               cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
               A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STCOMERCIOSID");
                  AnyError = 1;
                  GX_FocusControl = edtSTComerciosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A919STComerciosID = 0;
                  n919STComerciosID = false;
                  AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
               }
               else
               {
                  A919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n919STComerciosID = false;
                  AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
               }
               n919STComerciosID = ((0==A919STComerciosID) ? true : false);
               A923STComerciosNombre = cgiGet( edtSTComerciosNombre_Internalname);
               AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
               cmbSTComerciosEstado.Name = cmbSTComerciosEstado_Internalname;
               cmbSTComerciosEstado.CurrentValue = cgiGet( cmbSTComerciosEstado_Internalname);
               A924STComerciosEstado = cgiGet( cmbSTComerciosEstado_Internalname);
               AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
               A552ConexionesID = cgiGet( edtConexionesID_Internalname);
               n552ConexionesID = false;
               AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
               n552ConexionesID = (String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ? true : false);
               A556ConexionesNombre = cgiGet( edtConexionesNombre_Internalname);
               n556ConexionesNombre = false;
               AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
               cmbMapeoEstado.Name = cmbMapeoEstado_Internalname;
               cmbMapeoEstado.CurrentValue = cgiGet( cmbMapeoEstado_Internalname);
               A922MapeoEstado = cgiGet( cmbMapeoEstado_Internalname);
               n922MapeoEstado = false;
               AssignAttri("", false, "A922MapeoEstado", A922MapeoEstado);
               n922MapeoEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A922MapeoEstado)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Mapeo");
               A918MapeoID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMapeoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
               forbiddenHiddens.Add("MapeoID", context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV13Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_STComerciosID", context.localUtil.Format( (decimal)(AV14Insert_STComerciosID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ConexionesID", StringUtil.RTrim( context.localUtil.Format( AV15Insert_ConexionesID, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A918MapeoID != Z918MapeoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("mapeo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A918MapeoID = (long)(Math.Round(NumberUtil.Val( GetPar( "MapeoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
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
                     sMode134 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode134;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound134 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MAPEOID");
                        AnyError = 1;
                        GX_FocusControl = edtMapeoID_Internalname;
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
                           E112U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122U2 ();
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
            E122U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2U134( ) ;
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
            DisableAttributes2U134( ) ;
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

      protected void CONFIRM_2U0( )
      {
         BeforeValidate2U134( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2U134( ) ;
            }
            else
            {
               CheckExtendedTable2U134( ) ;
               CloseExtendedTableCursors2U134( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode134 = Gx_mode;
            CONFIRM_2U135( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode134;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2U136( )
      {
         nGXsfl_105_idx = 0;
         while ( nGXsfl_105_idx < nRC_GXsfl_105 )
         {
            ReadRow2U136( ) ;
            if ( ( nRcdExists_136 != 0 ) || ( nIsMod_136 != 0 ) )
            {
               GetKey2U136( ) ;
               if ( ( nRcdExists_136 == 0 ) && ( nRcdDeleted_136 == 0 ) )
               {
                  if ( RcdFound136 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2U136( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2U136( ) ;
                        CloseExtendedTableCursors2U136( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound136 != 0 )
                  {
                     if ( nRcdDeleted_136 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2U136( ) ;
                        Load2U136( ) ;
                        BeforeValidate2U136( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2U136( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_136 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2U136( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2U136( ) ;
                              CloseExtendedTableCursors2U136( ) ;
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
                     if ( nRcdDeleted_136 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtMapeoListadoReferenciaId_Internalname, StringUtil.RTrim( A920MapeoListadoReferenciaId)) ;
            ChangePostValue( edtMapeoListadoReferenciaURL_Internalname, A927MapeoListadoReferenciaURL) ;
            ChangePostValue( edtMapeoListadoReferenciaNombre_Internalname, StringUtil.RTrim( A928MapeoListadoReferenciaNombre)) ;
            ChangePostValue( cmbMapeoListadoReferenciaEstado_Internalname, StringUtil.RTrim( A929MapeoListadoReferenciaEstado)) ;
            ChangePostValue( "ZT_"+"Z920MapeoListadoReferenciaId_"+sGXsfl_105_idx, StringUtil.RTrim( Z920MapeoListadoReferenciaId)) ;
            ChangePostValue( "ZT_"+"Z927MapeoListadoReferenciaURL_"+sGXsfl_105_idx, Z927MapeoListadoReferenciaURL) ;
            ChangePostValue( "ZT_"+"Z928MapeoListadoReferenciaNombre_"+sGXsfl_105_idx, StringUtil.RTrim( Z928MapeoListadoReferenciaNombre)) ;
            ChangePostValue( "ZT_"+"Z929MapeoListadoReferenciaEstado_"+sGXsfl_105_idx, StringUtil.RTrim( Z929MapeoListadoReferenciaEstado)) ;
            ChangePostValue( "nRcdDeleted_136_"+sGXsfl_105_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_136), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_136_"+sGXsfl_105_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_136), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_136_"+sGXsfl_105_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_136), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_136 != 0 )
            {
               ChangePostValue( "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaURL_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoReferenciaEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_2U135( )
      {
         nGXsfl_69_idx = 0;
         while ( nGXsfl_69_idx < nRC_GXsfl_69 )
         {
            ReadRow2U135( ) ;
            if ( ( nRcdExists_135 != 0 ) || ( nIsMod_135 != 0 ) )
            {
               GetKey2U135( ) ;
               if ( ( nRcdExists_135 == 0 ) && ( nRcdDeleted_135 == 0 ) )
               {
                  if ( RcdFound135 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2U135( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2U135( ) ;
                        CloseExtendedTableCursors2U135( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Save parent mode. */
                           sMode135 = Gx_mode;
                           CONFIRM_2U136( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Restore parent mode. */
                              Gx_mode = sMode135;
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                              IsConfirmed = 1;
                              AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                           }
                           /* Restore parent mode. */
                           Gx_mode = sMode135;
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound135 != 0 )
                  {
                     if ( nRcdDeleted_135 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2U135( ) ;
                        Load2U135( ) ;
                        BeforeValidate2U135( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2U135( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_135 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2U135( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2U135( ) ;
                              CloseExtendedTableCursors2U135( ) ;
                              if ( AnyError == 0 )
                              {
                                 /* Save parent mode. */
                                 sMode135 = Gx_mode;
                                 CONFIRM_2U136( ) ;
                                 if ( AnyError == 0 )
                                 {
                                    /* Restore parent mode. */
                                    Gx_mode = sMode135;
                                    AssignAttri("", false, "Gx_mode", Gx_mode);
                                    IsConfirmed = 1;
                                    AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                                 }
                                 /* Restore parent mode. */
                                 Gx_mode = sMode135;
                                 AssignAttri("", false, "Gx_mode", Gx_mode);
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_135 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbMapeoListadoEstado_Internalname, StringUtil.RTrim( A926MapeoListadoEstado)) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtMapeoListadoNombre_Internalname, StringUtil.RTrim( A925MapeoListadoNombre)) ;
            ChangePostValue( edtInventarioRefCode_Internalname, StringUtil.RTrim( A921InventarioRefCode)) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z925MapeoListadoNombre_"+sGXsfl_69_idx, StringUtil.RTrim( Z925MapeoListadoNombre)) ;
            ChangePostValue( "ZT_"+"Z926MapeoListadoEstado_"+sGXsfl_69_idx, StringUtil.RTrim( Z926MapeoListadoEstado)) ;
            ChangePostValue( "nRC_GXsfl_105_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_105), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_135_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_135), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_135_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_135), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_135_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_135), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_135 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOESTADO_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADONOMBRE_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOREFCODE_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption2U0( )
      {
      }

      protected void E112U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV17Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ProveedorID") == 0 )
               {
                  AV13Insert_ProveedorID = (long)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV13Insert_ProveedorID), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "STComerciosID") == 0 )
               {
                  AV14Insert_STComerciosID = (long)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_STComerciosID", StringUtil.LTrimStr( (decimal)(AV14Insert_STComerciosID), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ConexionesID") == 0 )
               {
                  AV15Insert_ConexionesID = AV16TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV15Insert_ConexionesID", AV15Insert_ConexionesID);
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
      }

      protected void E122U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("mapeoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2U134( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z922MapeoEstado = T002U8_A922MapeoEstado[0];
               Z133ProveedorID = T002U8_A133ProveedorID[0];
               Z919STComerciosID = T002U8_A919STComerciosID[0];
               Z552ConexionesID = T002U8_A552ConexionesID[0];
            }
            else
            {
               Z922MapeoEstado = A922MapeoEstado;
               Z133ProveedorID = A133ProveedorID;
               Z919STComerciosID = A919STComerciosID;
               Z552ConexionesID = A552ConexionesID;
            }
         }
         if ( GX_JID == -23 )
         {
            Z918MapeoID = A918MapeoID;
            Z922MapeoEstado = A922MapeoEstado;
            Z133ProveedorID = A133ProveedorID;
            Z919STComerciosID = A919STComerciosID;
            Z552ConexionesID = A552ConexionesID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z923STComerciosNombre = A923STComerciosNombre;
            Z924STComerciosEstado = A924STComerciosEstado;
            Z556ConexionesNombre = A556ConexionesNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMapeoID_Enabled = 0;
         AssignProp("", false, edtMapeoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoID_Enabled), 5, 0), true);
         imgprompt_133_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORID"+"'), id:'"+"PROVEEDORID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROVEEDORNOMBRE"+"'), id:'"+"PROVEEDORNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_919_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"STCOMERCIOSID"+"'), id:'"+"STCOMERCIOSID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"STCOMERCIOSNOMBRE"+"'), id:'"+"STCOMERCIOSNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_552_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0280.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CONEXIONESID"+"'), id:'"+"CONEXIONESID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtMapeoID_Enabled = 0;
         AssignProp("", false, edtMapeoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MapeoID) )
         {
            A918MapeoID = AV7MapeoID;
            AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProveedorID) )
         {
            edtProveedorID_Enabled = 0;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         }
         else
         {
            edtProveedorID_Enabled = 1;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_STComerciosID) )
         {
            edtSTComerciosID_Enabled = 0;
            AssignProp("", false, edtSTComerciosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Enabled), 5, 0), true);
         }
         else
         {
            edtSTComerciosID_Enabled = 1;
            AssignProp("", false, edtSTComerciosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ConexionesID)) )
         {
            edtConexionesID_Enabled = 0;
            AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
         }
         else
         {
            edtConexionesID_Enabled = 1;
            AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ConexionesID)) )
         {
            A552ConexionesID = AV15Insert_ConexionesID;
            n552ConexionesID = false;
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_STComerciosID) )
         {
            A919STComerciosID = AV14Insert_STComerciosID;
            n919STComerciosID = false;
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProveedorID) )
         {
            A133ProveedorID = AV13Insert_ProveedorID;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
            AV17Pgmname = "Mapeo";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T002U11 */
            pr_default.execute(9, new Object[] {n552ConexionesID, A552ConexionesID});
            A556ConexionesNombre = T002U11_A556ConexionesNombre[0];
            n556ConexionesNombre = T002U11_n556ConexionesNombre[0];
            AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
            pr_default.close(9);
            /* Using cursor T002U10 */
            pr_default.execute(8, new Object[] {n919STComerciosID, A919STComerciosID});
            A923STComerciosNombre = T002U10_A923STComerciosNombre[0];
            AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
            A924STComerciosEstado = T002U10_A924STComerciosEstado[0];
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
            pr_default.close(8);
            /* Using cursor T002U9 */
            pr_default.execute(7, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T002U9_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A344ProveedorEstado = T002U9_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            pr_default.close(7);
         }
      }

      protected void Load2U134( )
      {
         /* Using cursor T002U12 */
         pr_default.execute(10, new Object[] {A918MapeoID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound134 = 1;
            A282ProveedorNombre = T002U12_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A344ProveedorEstado = T002U12_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A923STComerciosNombre = T002U12_A923STComerciosNombre[0];
            AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
            A924STComerciosEstado = T002U12_A924STComerciosEstado[0];
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
            A556ConexionesNombre = T002U12_A556ConexionesNombre[0];
            n556ConexionesNombre = T002U12_n556ConexionesNombre[0];
            AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
            A922MapeoEstado = T002U12_A922MapeoEstado[0];
            n922MapeoEstado = T002U12_n922MapeoEstado[0];
            AssignAttri("", false, "A922MapeoEstado", A922MapeoEstado);
            A133ProveedorID = T002U12_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A919STComerciosID = T002U12_A919STComerciosID[0];
            n919STComerciosID = T002U12_n919STComerciosID[0];
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
            A552ConexionesID = T002U12_A552ConexionesID[0];
            n552ConexionesID = T002U12_n552ConexionesID[0];
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
            ZM2U134( -23) ;
         }
         pr_default.close(10);
         OnLoadActions2U134( ) ;
      }

      protected void OnLoadActions2U134( )
      {
         AV17Pgmname = "Mapeo";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
      }

      protected void CheckExtendedTable2U134( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV17Pgmname = "Mapeo";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         /* Using cursor T002U9 */
         pr_default.execute(7, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A282ProveedorNombre = T002U9_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A344ProveedorEstado = T002U9_A344ProveedorEstado[0];
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         pr_default.close(7);
         /* Using cursor T002U10 */
         pr_default.execute(8, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
               GX_FocusControl = edtSTComerciosID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A923STComerciosNombre = T002U10_A923STComerciosNombre[0];
         AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
         A924STComerciosEstado = T002U10_A924STComerciosEstado[0];
         AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         pr_default.close(8);
         /* Using cursor T002U11 */
         pr_default.execute(9, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Conexiones", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CONEXIONESID");
               AnyError = 1;
               GX_FocusControl = edtConexionesID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A556ConexionesNombre = T002U11_A556ConexionesNombre[0];
         n556ConexionesNombre = T002U11_n556ConexionesNombre[0];
         AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
         pr_default.close(9);
         if ( ! ( ( StringUtil.StrCmp(A922MapeoEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A922MapeoEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A922MapeoEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A922MapeoEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A922MapeoEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mapeo Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MAPEOESTADO");
            AnyError = 1;
            GX_FocusControl = cmbMapeoEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2U134( )
      {
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( long A133ProveedorID )
      {
         /* Using cursor T002U13 */
         pr_default.execute(11, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A282ProveedorNombre = T002U13_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A344ProveedorEstado = T002U13_A344ProveedorEstado[0];
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A344ProveedorEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_25( long A919STComerciosID )
      {
         /* Using cursor T002U14 */
         pr_default.execute(12, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
               GX_FocusControl = edtSTComerciosID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A923STComerciosNombre = T002U14_A923STComerciosNombre[0];
         AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
         A924STComerciosEstado = T002U14_A924STComerciosEstado[0];
         AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A923STComerciosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A924STComerciosEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_26( string A552ConexionesID )
      {
         /* Using cursor T002U15 */
         pr_default.execute(13, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Conexiones", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CONEXIONESID");
               AnyError = 1;
               GX_FocusControl = edtConexionesID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A556ConexionesNombre = T002U15_A556ConexionesNombre[0];
         n556ConexionesNombre = T002U15_n556ConexionesNombre[0];
         AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A556ConexionesNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void GetKey2U134( )
      {
         /* Using cursor T002U16 */
         pr_default.execute(14, new Object[] {A918MapeoID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound134 = 1;
         }
         else
         {
            RcdFound134 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002U8 */
         pr_default.execute(6, new Object[] {A918MapeoID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM2U134( 23) ;
            RcdFound134 = 1;
            A918MapeoID = T002U8_A918MapeoID[0];
            AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
            A922MapeoEstado = T002U8_A922MapeoEstado[0];
            n922MapeoEstado = T002U8_n922MapeoEstado[0];
            AssignAttri("", false, "A922MapeoEstado", A922MapeoEstado);
            A133ProveedorID = T002U8_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A919STComerciosID = T002U8_A919STComerciosID[0];
            n919STComerciosID = T002U8_n919STComerciosID[0];
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
            A552ConexionesID = T002U8_A552ConexionesID[0];
            n552ConexionesID = T002U8_n552ConexionesID[0];
            AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
            Z918MapeoID = A918MapeoID;
            sMode134 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2U134( ) ;
            if ( AnyError == 1 )
            {
               RcdFound134 = 0;
               InitializeNonKey2U134( ) ;
            }
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound134 = 0;
            InitializeNonKey2U134( ) ;
            sMode134 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey2U134( ) ;
         if ( RcdFound134 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound134 = 0;
         /* Using cursor T002U17 */
         pr_default.execute(15, new Object[] {A918MapeoID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T002U17_A918MapeoID[0] < A918MapeoID ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T002U17_A918MapeoID[0] > A918MapeoID ) ) )
            {
               A918MapeoID = T002U17_A918MapeoID[0];
               AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
               RcdFound134 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void move_previous( )
      {
         RcdFound134 = 0;
         /* Using cursor T002U18 */
         pr_default.execute(16, new Object[] {A918MapeoID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T002U18_A918MapeoID[0] > A918MapeoID ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T002U18_A918MapeoID[0] < A918MapeoID ) ) )
            {
               A918MapeoID = T002U18_A918MapeoID[0];
               AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
               RcdFound134 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2U134( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2U134( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound134 == 1 )
            {
               if ( A918MapeoID != Z918MapeoID )
               {
                  A918MapeoID = Z918MapeoID;
                  AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MAPEOID");
                  AnyError = 1;
                  GX_FocusControl = edtMapeoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2U134( ) ;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A918MapeoID != Z918MapeoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2U134( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MAPEOID");
                     AnyError = 1;
                     GX_FocusControl = edtMapeoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2U134( ) ;
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
         if ( A918MapeoID != Z918MapeoID )
         {
            A918MapeoID = Z918MapeoID;
            AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MAPEOID");
            AnyError = 1;
            GX_FocusControl = edtMapeoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2U134( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002U7 */
            pr_default.execute(5, new Object[] {A918MapeoID});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaMapeo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z922MapeoEstado, T002U7_A922MapeoEstado[0]) != 0 ) || ( Z133ProveedorID != T002U7_A133ProveedorID[0] ) || ( Z919STComerciosID != T002U7_A919STComerciosID[0] ) || ( StringUtil.StrCmp(Z552ConexionesID, T002U7_A552ConexionesID[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z922MapeoEstado, T002U7_A922MapeoEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"MapeoEstado");
                  GXUtil.WriteLogRaw("Old: ",Z922MapeoEstado);
                  GXUtil.WriteLogRaw("Current: ",T002U7_A922MapeoEstado[0]);
               }
               if ( Z133ProveedorID != T002U7_A133ProveedorID[0] )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"ProveedorID");
                  GXUtil.WriteLogRaw("Old: ",Z133ProveedorID);
                  GXUtil.WriteLogRaw("Current: ",T002U7_A133ProveedorID[0]);
               }
               if ( Z919STComerciosID != T002U7_A919STComerciosID[0] )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"STComerciosID");
                  GXUtil.WriteLogRaw("Old: ",Z919STComerciosID);
                  GXUtil.WriteLogRaw("Current: ",T002U7_A919STComerciosID[0]);
               }
               if ( StringUtil.StrCmp(Z552ConexionesID, T002U7_A552ConexionesID[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"ConexionesID");
                  GXUtil.WriteLogRaw("Old: ",Z552ConexionesID);
                  GXUtil.WriteLogRaw("Current: ",T002U7_A552ConexionesID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ListaMapeo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2U134( )
      {
         BeforeValidate2U134( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U134( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2U134( 0) ;
            CheckOptimisticConcurrency2U134( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U134( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2U134( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U19 */
                     pr_default.execute(17, new Object[] {n922MapeoEstado, A922MapeoEstado, A133ProveedorID, n919STComerciosID, A919STComerciosID, n552ConexionesID, A552ConexionesID});
                     A918MapeoID = T002U19_A918MapeoID[0];
                     AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("ListaMapeo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2U134( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption2U0( ) ;
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
               Load2U134( ) ;
            }
            EndLevel2U134( ) ;
         }
         CloseExtendedTableCursors2U134( ) ;
      }

      protected void Update2U134( )
      {
         BeforeValidate2U134( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U134( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U134( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U134( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2U134( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U20 */
                     pr_default.execute(18, new Object[] {n922MapeoEstado, A922MapeoEstado, A133ProveedorID, n919STComerciosID, A919STComerciosID, n552ConexionesID, A552ConexionesID, A918MapeoID});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("ListaMapeo");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaMapeo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2U134( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2U134( ) ;
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
            EndLevel2U134( ) ;
         }
         CloseExtendedTableCursors2U134( ) ;
      }

      protected void DeferredUpdate2U134( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2U134( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U134( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2U134( ) ;
            AfterConfirm2U134( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2U134( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002U21 */
                  pr_default.execute(19, new Object[] {A918MapeoID});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("ListaMapeo");
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
         sMode134 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2U134( ) ;
         Gx_mode = sMode134;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2U134( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "Mapeo";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T002U22 */
            pr_default.execute(20, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T002U22_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A344ProveedorEstado = T002U22_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            pr_default.close(20);
            /* Using cursor T002U23 */
            pr_default.execute(21, new Object[] {n919STComerciosID, A919STComerciosID});
            A923STComerciosNombre = T002U23_A923STComerciosNombre[0];
            AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
            A924STComerciosEstado = T002U23_A924STComerciosEstado[0];
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
            pr_default.close(21);
            /* Using cursor T002U24 */
            pr_default.execute(22, new Object[] {n552ConexionesID, A552ConexionesID});
            A556ConexionesNombre = T002U24_A556ConexionesNombre[0];
            n556ConexionesNombre = T002U24_n556ConexionesNombre[0];
            AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002U25 */
            pr_default.execute(23, new Object[] {A918MapeoID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "MapeosListado", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void ProcessNestedLevel2U135( )
      {
         nGXsfl_69_idx = 0;
         while ( nGXsfl_69_idx < nRC_GXsfl_69 )
         {
            ReadRow2U135( ) ;
            if ( ( nRcdExists_135 != 0 ) || ( nIsMod_135 != 0 ) )
            {
               standaloneNotModal2U135( ) ;
               GetKey2U135( ) ;
               if ( ( nRcdExists_135 == 0 ) && ( nRcdDeleted_135 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2U135( ) ;
               }
               else
               {
                  if ( RcdFound135 != 0 )
                  {
                     if ( ( nRcdDeleted_135 != 0 ) && ( nRcdExists_135 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2U135( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_135 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2U135( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_135 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbMapeoListadoEstado_Internalname, StringUtil.RTrim( A926MapeoListadoEstado)) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtMapeoListadoNombre_Internalname, StringUtil.RTrim( A925MapeoListadoNombre)) ;
            ChangePostValue( edtInventarioRefCode_Internalname, StringUtil.RTrim( A921InventarioRefCode)) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z925MapeoListadoNombre_"+sGXsfl_69_idx, StringUtil.RTrim( Z925MapeoListadoNombre)) ;
            ChangePostValue( "ZT_"+"Z926MapeoListadoEstado_"+sGXsfl_69_idx, StringUtil.RTrim( Z926MapeoListadoEstado)) ;
            ChangePostValue( "nRC_GXsfl_105_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_105), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_135_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_135), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_135_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_135), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_135_"+sGXsfl_69_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_135), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_135 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOESTADO_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADONOMBRE_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOREFCODE_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2U135( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_135 = 0;
         nIsMod_135 = 0;
         nRcdDeleted_135 = 0;
      }

      protected void ProcessLevel2U134( )
      {
         /* Save parent mode. */
         sMode134 = Gx_mode;
         ProcessNestedLevel2U135( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode134;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2U134( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2U134( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(4);
            context.CommitDataStores("mapeo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(6);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(4);
            context.RollbackDataStores("mapeo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2U134( )
      {
         /* Scan By routine */
         /* Using cursor T002U26 */
         pr_default.execute(24);
         RcdFound134 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound134 = 1;
            A918MapeoID = T002U26_A918MapeoID[0];
            AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2U134( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound134 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound134 = 1;
            A918MapeoID = T002U26_A918MapeoID[0];
            AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
         }
      }

      protected void ScanEnd2U134( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm2U134( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2U134( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2U134( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2U134( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2U134( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2U134( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2U134( )
      {
         edtMapeoID_Enabled = 0;
         AssignProp("", false, edtMapeoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoID_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         edtSTComerciosID_Enabled = 0;
         AssignProp("", false, edtSTComerciosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Enabled), 5, 0), true);
         edtSTComerciosNombre_Enabled = 0;
         AssignProp("", false, edtSTComerciosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosNombre_Enabled), 5, 0), true);
         cmbSTComerciosEstado.Enabled = 0;
         AssignProp("", false, cmbSTComerciosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSTComerciosEstado.Enabled), 5, 0), true);
         edtConexionesID_Enabled = 0;
         AssignProp("", false, edtConexionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesID_Enabled), 5, 0), true);
         edtConexionesNombre_Enabled = 0;
         AssignProp("", false, edtConexionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConexionesNombre_Enabled), 5, 0), true);
         cmbMapeoEstado.Enabled = 0;
         AssignProp("", false, cmbMapeoEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMapeoEstado.Enabled), 5, 0), true);
      }

      protected void ZM2U135( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z925MapeoListadoNombre = T002U5_A925MapeoListadoNombre[0];
               Z926MapeoListadoEstado = T002U5_A926MapeoListadoEstado[0];
            }
            else
            {
               Z925MapeoListadoNombre = A925MapeoListadoNombre;
               Z926MapeoListadoEstado = A926MapeoListadoEstado;
            }
         }
         if ( GX_JID == -27 )
         {
            Z918MapeoID = A918MapeoID;
            Z925MapeoListadoNombre = A925MapeoListadoNombre;
            Z926MapeoListadoEstado = A926MapeoListadoEstado;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
         }
      }

      protected void standaloneNotModal2U135( )
      {
      }

      protected void standaloneModal2U135( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtRubrosId_Enabled = 0;
            AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_69_Refreshing);
         }
         else
         {
            edtRubrosId_Enabled = 1;
            AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_69_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            dynMedidasID.Enabled = 0;
            AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         }
         else
         {
            dynMedidasID.Enabled = 1;
            AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            dynInventarioId.Enabled = 0;
            AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         }
         else
         {
            dynInventarioId.Enabled = 1;
            AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         }
      }

      protected void Load2U135( )
      {
         /* Using cursor T002U27 */
         pr_default.execute(25, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound135 = 1;
            A925MapeoListadoNombre = T002U27_A925MapeoListadoNombre[0];
            A926MapeoListadoEstado = T002U27_A926MapeoListadoEstado[0];
            ZM2U135( -27) ;
         }
         pr_default.close(25);
         OnLoadActions2U135( ) ;
      }

      protected void OnLoadActions2U135( )
      {
         GXAMEDIDASID_html2U135( A121RubrosId) ;
         GXAINVENTARIOID_html2U135( A121RubrosId, A137MedidasID) ;
         A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
      }

      protected void CheckExtendedTable2U135( )
      {
         nIsDirty_135 = 0;
         Gx_BScreen = 1;
         standaloneModal2U135( ) ;
         GXAMEDIDASID_html2U135( A121RubrosId) ;
         if ( (0==A121RubrosId) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Rubros Identificador ", ""), "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GXAINVENTARIOID_html2U135( A121RubrosId, A137MedidasID) ;
         /* Using cursor T002U6 */
         pr_default.execute(4, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_69_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         nIsDirty_135 = 1;
         A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
         if ( ! ( ( StringUtil.StrCmp(A926MapeoListadoEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A926MapeoListadoEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A926MapeoListadoEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A926MapeoListadoEstado, "BLO") == 0 ) ) )
         {
            GXCCtl = "MAPEOLISTADOESTADO_" + sGXsfl_69_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbMapeoListadoEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2U135( )
      {
         pr_default.close(4);
      }

      protected void enableDisable2U135( )
      {
      }

      protected void gxLoad_28( short A121RubrosId ,
                                long A137MedidasID ,
                                long A135InventarioId )
      {
         /* Using cursor T002U28 */
         pr_default.execute(26, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_69_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void GetKey2U135( )
      {
         /* Using cursor T002U29 */
         pr_default.execute(27, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound135 = 1;
         }
         else
         {
            RcdFound135 = 0;
         }
         pr_default.close(27);
      }

      protected void getByPrimaryKey2U135( )
      {
         /* Using cursor T002U5 */
         pr_default.execute(3, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2U135( 27) ;
            RcdFound135 = 1;
            InitializeNonKey2U135( ) ;
            A925MapeoListadoNombre = T002U5_A925MapeoListadoNombre[0];
            A926MapeoListadoEstado = T002U5_A926MapeoListadoEstado[0];
            A121RubrosId = T002U5_A121RubrosId[0];
            A137MedidasID = T002U5_A137MedidasID[0];
            A135InventarioId = T002U5_A135InventarioId[0];
            Z918MapeoID = A918MapeoID;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            sMode135 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2U135( ) ;
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound135 = 0;
            InitializeNonKey2U135( ) ;
            sMode135 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2U135( ) ;
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2U135( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency2U135( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002U4 */
            pr_default.execute(2, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MapeosListado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z925MapeoListadoNombre, T002U4_A925MapeoListadoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z926MapeoListadoEstado, T002U4_A926MapeoListadoEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z925MapeoListadoNombre, T002U4_A925MapeoListadoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"MapeoListadoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z925MapeoListadoNombre);
                  GXUtil.WriteLogRaw("Current: ",T002U4_A925MapeoListadoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z926MapeoListadoEstado, T002U4_A926MapeoListadoEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"MapeoListadoEstado");
                  GXUtil.WriteLogRaw("Old: ",Z926MapeoListadoEstado);
                  GXUtil.WriteLogRaw("Current: ",T002U4_A926MapeoListadoEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MapeosListado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2U135( )
      {
         BeforeValidate2U135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U135( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2U135( 0) ;
            CheckOptimisticConcurrency2U135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2U135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U30 */
                     pr_default.execute(28, new Object[] {A918MapeoID, A925MapeoListadoNombre, A926MapeoListadoEstado, A121RubrosId, A137MedidasID, A135InventarioId});
                     pr_default.close(28);
                     pr_default.SmartCacheProvider.SetUpdated("MapeosListado");
                     if ( (pr_default.getStatus(28) == 1) )
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
                           ProcessLevel2U135( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
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
               Load2U135( ) ;
            }
            EndLevel2U135( ) ;
         }
         CloseExtendedTableCursors2U135( ) ;
      }

      protected void Update2U135( )
      {
         BeforeValidate2U135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U135( ) ;
         }
         if ( ( nIsMod_135 != 0 ) || ( nIsDirty_135 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2U135( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2U135( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2U135( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002U31 */
                        pr_default.execute(29, new Object[] {A925MapeoListadoNombre, A926MapeoListadoEstado, A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
                        pr_default.close(29);
                        pr_default.SmartCacheProvider.SetUpdated("MapeosListado");
                        if ( (pr_default.getStatus(29) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MapeosListado"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2U135( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              ProcessLevel2U135( ) ;
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
               EndLevel2U135( ) ;
            }
         }
         CloseExtendedTableCursors2U135( ) ;
      }

      protected void DeferredUpdate2U135( )
      {
      }

      protected void Delete2U135( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2U135( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U135( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2U135( ) ;
            AfterConfirm2U135( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2U135( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2U136( ) ;
                  while ( RcdFound136 != 0 )
                  {
                     getByPrimaryKey2U136( ) ;
                     Delete2U136( ) ;
                     ScanNext2U136( ) ;
                  }
                  ScanEnd2U136( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U32 */
                     pr_default.execute(30, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("MapeosListado");
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
         }
         sMode135 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2U135( ) ;
         Gx_mode = sMode135;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2U135( )
      {
         standaloneModal2U135( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXAMEDIDASID_html2U135( A121RubrosId) ;
            GXAINVENTARIOID_html2U135( A121RubrosId, A137MedidasID) ;
            A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
         }
      }

      protected void ProcessNestedLevel2U136( )
      {
         nGXsfl_105_idx = 0;
         while ( nGXsfl_105_idx < nRC_GXsfl_105 )
         {
            ReadRow2U136( ) ;
            if ( ( nRcdExists_136 != 0 ) || ( nIsMod_136 != 0 ) )
            {
               standaloneNotModal2U136( ) ;
               GetKey2U136( ) ;
               if ( ( nRcdExists_136 == 0 ) && ( nRcdDeleted_136 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2U136( ) ;
               }
               else
               {
                  if ( RcdFound136 != 0 )
                  {
                     if ( ( nRcdDeleted_136 != 0 ) && ( nRcdExists_136 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2U136( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_136 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2U136( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_136 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtMapeoListadoReferenciaId_Internalname, StringUtil.RTrim( A920MapeoListadoReferenciaId)) ;
            ChangePostValue( edtMapeoListadoReferenciaURL_Internalname, A927MapeoListadoReferenciaURL) ;
            ChangePostValue( edtMapeoListadoReferenciaNombre_Internalname, StringUtil.RTrim( A928MapeoListadoReferenciaNombre)) ;
            ChangePostValue( cmbMapeoListadoReferenciaEstado_Internalname, StringUtil.RTrim( A929MapeoListadoReferenciaEstado)) ;
            ChangePostValue( "ZT_"+"Z920MapeoListadoReferenciaId_"+sGXsfl_105_idx, StringUtil.RTrim( Z920MapeoListadoReferenciaId)) ;
            ChangePostValue( "ZT_"+"Z927MapeoListadoReferenciaURL_"+sGXsfl_105_idx, Z927MapeoListadoReferenciaURL) ;
            ChangePostValue( "ZT_"+"Z928MapeoListadoReferenciaNombre_"+sGXsfl_105_idx, StringUtil.RTrim( Z928MapeoListadoReferenciaNombre)) ;
            ChangePostValue( "ZT_"+"Z929MapeoListadoReferenciaEstado_"+sGXsfl_105_idx, StringUtil.RTrim( Z929MapeoListadoReferenciaEstado)) ;
            ChangePostValue( "nRcdDeleted_136_"+sGXsfl_105_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_136), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_136_"+sGXsfl_105_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_136), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_136_"+sGXsfl_105_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_136), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_136 != 0 )
            {
               ChangePostValue( "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaURL_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoReferenciaEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2U136( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_136 = 0;
         nIsMod_136 = 0;
         nRcdDeleted_136 = 0;
      }

      protected void ProcessLevel2U135( )
      {
         /* Save parent mode. */
         sMode135 = Gx_mode;
         ProcessNestedLevel2U136( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode135;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2U135( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2U135( )
      {
         /* Scan By routine */
         /* Using cursor T002U33 */
         pr_default.execute(31, new Object[] {A918MapeoID});
         RcdFound135 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound135 = 1;
            A121RubrosId = T002U33_A121RubrosId[0];
            A137MedidasID = T002U33_A137MedidasID[0];
            A135InventarioId = T002U33_A135InventarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2U135( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound135 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound135 = 1;
            A121RubrosId = T002U33_A121RubrosId[0];
            A137MedidasID = T002U33_A137MedidasID[0];
            A135InventarioId = T002U33_A135InventarioId[0];
         }
      }

      protected void ScanEnd2U135( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm2U135( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2U135( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2U135( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2U135( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2U135( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2U135( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2U135( )
      {
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_69_Refreshing);
         cmbMapeoListadoEstado.Enabled = 0;
         AssignProp("", false, cmbMapeoListadoEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMapeoListadoEstado.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         dynMedidasID.Enabled = 0;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         dynInventarioId.Enabled = 0;
         AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         edtMapeoListadoNombre_Enabled = 0;
         AssignProp("", false, edtMapeoListadoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoNombre_Enabled), 5, 0), !bGXsfl_69_Refreshing);
         edtInventarioRefCode_Enabled = 0;
         AssignProp("", false, edtInventarioRefCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioRefCode_Enabled), 5, 0), !bGXsfl_69_Refreshing);
      }

      protected void ZM2U136( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z927MapeoListadoReferenciaURL = T002U3_A927MapeoListadoReferenciaURL[0];
               Z928MapeoListadoReferenciaNombre = T002U3_A928MapeoListadoReferenciaNombre[0];
               Z929MapeoListadoReferenciaEstado = T002U3_A929MapeoListadoReferenciaEstado[0];
            }
            else
            {
               Z927MapeoListadoReferenciaURL = A927MapeoListadoReferenciaURL;
               Z928MapeoListadoReferenciaNombre = A928MapeoListadoReferenciaNombre;
               Z929MapeoListadoReferenciaEstado = A929MapeoListadoReferenciaEstado;
            }
         }
         if ( GX_JID == -29 )
         {
            Z918MapeoID = A918MapeoID;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z920MapeoListadoReferenciaId = A920MapeoListadoReferenciaId;
            Z927MapeoListadoReferenciaURL = A927MapeoListadoReferenciaURL;
            Z928MapeoListadoReferenciaNombre = A928MapeoListadoReferenciaNombre;
            Z929MapeoListadoReferenciaEstado = A929MapeoListadoReferenciaEstado;
         }
      }

      protected void standaloneNotModal2U136( )
      {
      }

      protected void standaloneModal2U136( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtMapeoListadoReferenciaId_Enabled = 0;
            AssignProp("", false, edtMapeoListadoReferenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0), !bGXsfl_105_Refreshing);
         }
         else
         {
            edtMapeoListadoReferenciaId_Enabled = 1;
            AssignProp("", false, edtMapeoListadoReferenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0), !bGXsfl_105_Refreshing);
         }
      }

      protected void Load2U136( )
      {
         /* Using cursor T002U34 */
         pr_default.execute(32, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound136 = 1;
            A927MapeoListadoReferenciaURL = T002U34_A927MapeoListadoReferenciaURL[0];
            n927MapeoListadoReferenciaURL = T002U34_n927MapeoListadoReferenciaURL[0];
            A928MapeoListadoReferenciaNombre = T002U34_A928MapeoListadoReferenciaNombre[0];
            n928MapeoListadoReferenciaNombre = T002U34_n928MapeoListadoReferenciaNombre[0];
            A929MapeoListadoReferenciaEstado = T002U34_A929MapeoListadoReferenciaEstado[0];
            n929MapeoListadoReferenciaEstado = T002U34_n929MapeoListadoReferenciaEstado[0];
            ZM2U136( -29) ;
         }
         pr_default.close(32);
         OnLoadActions2U136( ) ;
      }

      protected void OnLoadActions2U136( )
      {
      }

      protected void CheckExtendedTable2U136( )
      {
         nIsDirty_136 = 0;
         Gx_BScreen = 1;
         standaloneModal2U136( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A920MapeoListadoReferenciaId)) )
         {
            GXCCtl = "MAPEOLISTADOREFERENCIAID_" + sGXsfl_105_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Id Ref.: Externo (SKU)", ""), "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtMapeoListadoReferenciaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A927MapeoListadoReferenciaURL,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A927MapeoListadoReferenciaURL)) ) )
         {
            GXCCtl = "MAPEOLISTADOREFERENCIAURL_" + sGXsfl_105_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "URL del Producto en el Comercio ", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtMapeoListadoReferenciaURL_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A929MapeoListadoReferenciaEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A929MapeoListadoReferenciaEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A929MapeoListadoReferenciaEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A929MapeoListadoReferenciaEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A929MapeoListadoReferenciaEstado)) ) )
         {
            GXCCtl = "MAPEOLISTADOREFERENCIAESTADO_" + sGXsfl_105_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbMapeoListadoReferenciaEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2U136( )
      {
      }

      protected void enableDisable2U136( )
      {
      }

      protected void GetKey2U136( )
      {
         /* Using cursor T002U35 */
         pr_default.execute(33, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound136 = 1;
         }
         else
         {
            RcdFound136 = 0;
         }
         pr_default.close(33);
      }

      protected void getByPrimaryKey2U136( )
      {
         /* Using cursor T002U3 */
         pr_default.execute(1, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2U136( 29) ;
            RcdFound136 = 1;
            InitializeNonKey2U136( ) ;
            A920MapeoListadoReferenciaId = T002U3_A920MapeoListadoReferenciaId[0];
            A927MapeoListadoReferenciaURL = T002U3_A927MapeoListadoReferenciaURL[0];
            n927MapeoListadoReferenciaURL = T002U3_n927MapeoListadoReferenciaURL[0];
            A928MapeoListadoReferenciaNombre = T002U3_A928MapeoListadoReferenciaNombre[0];
            n928MapeoListadoReferenciaNombre = T002U3_n928MapeoListadoReferenciaNombre[0];
            A929MapeoListadoReferenciaEstado = T002U3_A929MapeoListadoReferenciaEstado[0];
            n929MapeoListadoReferenciaEstado = T002U3_n929MapeoListadoReferenciaEstado[0];
            Z918MapeoID = A918MapeoID;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z920MapeoListadoReferenciaId = A920MapeoListadoReferenciaId;
            sMode136 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2U136( ) ;
            Gx_mode = sMode136;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound136 = 0;
            InitializeNonKey2U136( ) ;
            sMode136 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2U136( ) ;
            Gx_mode = sMode136;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2U136( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2U136( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002U2 */
            pr_default.execute(0, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MapeoListadoReferencia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z927MapeoListadoReferenciaURL, T002U2_A927MapeoListadoReferenciaURL[0]) != 0 ) || ( StringUtil.StrCmp(Z928MapeoListadoReferenciaNombre, T002U2_A928MapeoListadoReferenciaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z929MapeoListadoReferenciaEstado, T002U2_A929MapeoListadoReferenciaEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z927MapeoListadoReferenciaURL, T002U2_A927MapeoListadoReferenciaURL[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"MapeoListadoReferenciaURL");
                  GXUtil.WriteLogRaw("Old: ",Z927MapeoListadoReferenciaURL);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A927MapeoListadoReferenciaURL[0]);
               }
               if ( StringUtil.StrCmp(Z928MapeoListadoReferenciaNombre, T002U2_A928MapeoListadoReferenciaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"MapeoListadoReferenciaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z928MapeoListadoReferenciaNombre);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A928MapeoListadoReferenciaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z929MapeoListadoReferenciaEstado, T002U2_A929MapeoListadoReferenciaEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("mapeo:[seudo value changed for attri]"+"MapeoListadoReferenciaEstado");
                  GXUtil.WriteLogRaw("Old: ",Z929MapeoListadoReferenciaEstado);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A929MapeoListadoReferenciaEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MapeoListadoReferencia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2U136( )
      {
         BeforeValidate2U136( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U136( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2U136( 0) ;
            CheckOptimisticConcurrency2U136( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U136( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2U136( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U36 */
                     pr_default.execute(34, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId, n927MapeoListadoReferenciaURL, A927MapeoListadoReferenciaURL, n928MapeoListadoReferenciaNombre, A928MapeoListadoReferenciaNombre, n929MapeoListadoReferenciaEstado, A929MapeoListadoReferenciaEstado});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("MapeoListadoReferencia");
                     if ( (pr_default.getStatus(34) == 1) )
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
               Load2U136( ) ;
            }
            EndLevel2U136( ) ;
         }
         CloseExtendedTableCursors2U136( ) ;
      }

      protected void Update2U136( )
      {
         BeforeValidate2U136( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U136( ) ;
         }
         if ( ( nIsMod_136 != 0 ) || ( nIsDirty_136 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2U136( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2U136( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2U136( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002U37 */
                        pr_default.execute(35, new Object[] {n927MapeoListadoReferenciaURL, A927MapeoListadoReferenciaURL, n928MapeoListadoReferenciaNombre, A928MapeoListadoReferenciaNombre, n929MapeoListadoReferenciaEstado, A929MapeoListadoReferenciaEstado, A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId});
                        pr_default.close(35);
                        pr_default.SmartCacheProvider.SetUpdated("MapeoListadoReferencia");
                        if ( (pr_default.getStatus(35) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MapeoListadoReferencia"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2U136( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2U136( ) ;
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
               EndLevel2U136( ) ;
            }
         }
         CloseExtendedTableCursors2U136( ) ;
      }

      protected void DeferredUpdate2U136( )
      {
      }

      protected void Delete2U136( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2U136( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U136( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2U136( ) ;
            AfterConfirm2U136( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2U136( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002U38 */
                  pr_default.execute(36, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId, A920MapeoListadoReferenciaId});
                  pr_default.close(36);
                  pr_default.SmartCacheProvider.SetUpdated("MapeoListadoReferencia");
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
         sMode136 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2U136( ) ;
         Gx_mode = sMode136;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2U136( )
      {
         standaloneModal2U136( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2U136( )
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

      public void ScanStart2U136( )
      {
         /* Scan By routine */
         /* Using cursor T002U39 */
         pr_default.execute(37, new Object[] {A918MapeoID, A121RubrosId, A137MedidasID, A135InventarioId});
         RcdFound136 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound136 = 1;
            A920MapeoListadoReferenciaId = T002U39_A920MapeoListadoReferenciaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2U136( )
      {
         /* Scan next routine */
         pr_default.readNext(37);
         RcdFound136 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound136 = 1;
            A920MapeoListadoReferenciaId = T002U39_A920MapeoListadoReferenciaId[0];
         }
      }

      protected void ScanEnd2U136( )
      {
         pr_default.close(37);
      }

      protected void AfterConfirm2U136( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2U136( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2U136( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2U136( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2U136( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2U136( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2U136( )
      {
         edtMapeoListadoReferenciaId_Enabled = 0;
         AssignProp("", false, edtMapeoListadoReferenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0), !bGXsfl_105_Refreshing);
         edtMapeoListadoReferenciaURL_Enabled = 0;
         AssignProp("", false, edtMapeoListadoReferenciaURL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaURL_Enabled), 5, 0), !bGXsfl_105_Refreshing);
         edtMapeoListadoReferenciaNombre_Enabled = 0;
         AssignProp("", false, edtMapeoListadoReferenciaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaNombre_Enabled), 5, 0), !bGXsfl_105_Refreshing);
         cmbMapeoListadoReferenciaEstado.Enabled = 0;
         AssignProp("", false, cmbMapeoListadoReferenciaEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMapeoListadoReferenciaEstado.Enabled), 5, 0), !bGXsfl_105_Refreshing);
      }

      protected void send_integrity_lvl_hashes2U136( )
      {
      }

      protected void send_integrity_lvl_hashes2U135( )
      {
      }

      protected void send_integrity_lvl_hashes2U134( )
      {
      }

      protected void SubsflControlProps_69135( )
      {
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_69_idx;
         cmbMapeoListadoEstado_Internalname = "MAPEOLISTADOESTADO_"+sGXsfl_69_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_69_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_69_idx;
         edtMapeoListadoNombre_Internalname = "MAPEOLISTADONOMBRE_"+sGXsfl_69_idx;
         edtInventarioRefCode_Internalname = "INVENTARIOREFCODE_"+sGXsfl_69_idx;
         imgprompt_121_137_135_Internalname = "PROMPT_121_137_135_"+sGXsfl_69_idx;
         subGridlevel_referencia_Internalname = "GRIDLEVEL_REFERENCIA_"+sGXsfl_69_idx;
      }

      protected void SubsflControlProps_fel_69135( )
      {
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_69_fel_idx;
         cmbMapeoListadoEstado_Internalname = "MAPEOLISTADOESTADO_"+sGXsfl_69_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_69_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_69_fel_idx;
         edtMapeoListadoNombre_Internalname = "MAPEOLISTADONOMBRE_"+sGXsfl_69_fel_idx;
         edtInventarioRefCode_Internalname = "INVENTARIOREFCODE_"+sGXsfl_69_fel_idx;
         imgprompt_121_137_135_Internalname = "PROMPT_121_137_135_"+sGXsfl_69_fel_idx;
         subGridlevel_referencia_Internalname = "GRIDLEVEL_REFERENCIA_"+sGXsfl_69_fel_idx;
      }

      protected void AddRow2U135( )
      {
         nRC_GXsfl_105 = 0;
         nGXsfl_69_idx = (int)(nGXsfl_69_idx+1);
         sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx), 4, 0), 4, "0");
         SubsflControlProps_69135( ) ;
         SendRow2U135( ) ;
      }

      protected void SendRow2U135( )
      {
         Freestylelevel_listadoRow = GXWebRow.GetNew(context);
         if ( subFreestylelevel_listado_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylelevel_listado_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylelevel_listado_Class, "") != 0 )
            {
               subFreestylelevel_listado_Linesclass = subFreestylelevel_listado_Class+"Odd";
            }
         }
         else if ( subFreestylelevel_listado_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylelevel_listado_Backstyle = 0;
            subFreestylelevel_listado_Backcolor = subFreestylelevel_listado_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylelevel_listado_Class, "") != 0 )
            {
               subFreestylelevel_listado_Linesclass = subFreestylelevel_listado_Class+"Uniform";
            }
         }
         else if ( subFreestylelevel_listado_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylelevel_listado_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylelevel_listado_Class, "") != 0 )
            {
               subFreestylelevel_listado_Linesclass = subFreestylelevel_listado_Class+"Odd";
            }
            subFreestylelevel_listado_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylelevel_listado_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylelevel_listado_Backstyle = 1;
            if ( ((int)((nGXsfl_69_idx) % (2))) == 0 )
            {
               subFreestylelevel_listado_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylelevel_listado_Class, "") != 0 )
               {
                  subFreestylelevel_listado_Linesclass = subFreestylelevel_listado_Class+"Even";
               }
            }
            else
            {
               subFreestylelevel_listado_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylelevel_listado_Class, "") != 0 )
               {
                  subFreestylelevel_listado_Linesclass = subFreestylelevel_listado_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylelevel_listadoContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylelevel_listado_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_69_idx+"\">") ;
         }
         if ( FREESTYLELEVEL_LISTADO_IsPaging == 0 )
         {
            GXCCtl = "GRIDLEVEL_REFERENCIA_nFirstRecordOnPage_" + sGXsfl_69_idx;
            GRIDLEVEL_REFERENCIA_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         else
         {
            GRIDLEVEL_REFERENCIA_nFirstRecordOnPage = 0;
         }
         imgprompt_121_137_135_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00r0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_69_idx+"'), id:'"+"RUBROSID_"+sGXsfl_69_idx+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MEDIDASID_"+sGXsfl_69_idx+"'), id:'"+"MEDIDASID_"+sGXsfl_69_idx+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INVENTARIOID_"+sGXsfl_69_idx+"'), id:'"+"INVENTARIOID_"+sGXsfl_69_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_135_"+sGXsfl_69_idx+","+"'', false"+","+"false"+");");
         GXAMEDIDASID_html2U135( A121RubrosId) ;
         GXAINVENTARIOID_html2U135( A121RubrosId, A137MedidasID) ;
         /* Table start */
         Freestylelevel_listadoRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablefsfreestylelevel_listado_Internalname+"_"+sGXsfl_69_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylelevel_listadoRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylelevel_listadoRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableintermediateinslevel_listado_Internalname+"_"+sGXsfl_69_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtRubrosId_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_listadoRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,context.GetMessage( "Rubros Identificador ", ""),(string)"col-sm-3 AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_69_idx + "',69)\"";
         ROClassString = "AttributeFL";
         Freestylelevel_listadoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtRubrosId_Enabled,(short)1,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)69,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2 DataContentCellFL",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+cmbMapeoListadoEstado_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_listadoRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbMapeoListadoEstado_Internalname,context.GetMessage( "Estado", ""),(string)"col-sm-3 AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_69_idx + "',69)\"";
         if ( ( cmbMapeoListadoEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MAPEOLISTADOESTADO_" + sGXsfl_69_idx;
            cmbMapeoListadoEstado.Name = GXCCtl;
            cmbMapeoListadoEstado.WebTags = "";
            cmbMapeoListadoEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbMapeoListadoEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbMapeoListadoEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbMapeoListadoEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbMapeoListadoEstado.ItemCount > 0 )
            {
               A926MapeoListadoEstado = cmbMapeoListadoEstado.getValidValue(A926MapeoListadoEstado);
            }
         }
         /* ComboBox */
         Freestylelevel_listadoRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMapeoListadoEstado,(string)cmbMapeoListadoEstado_Internalname,StringUtil.RTrim( A926MapeoListadoEstado),(short)1,(string)cmbMapeoListadoEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)1,cmbMapeoListadoEstado.Enabled,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"AttributeFL",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"",(string)"",(bool)true,(short)0});
         cmbMapeoListadoEstado.CurrentValue = StringUtil.RTrim( A926MapeoListadoEstado);
         AssignProp("", false, cmbMapeoListadoEstado_Internalname, "Values", (string)(cmbMapeoListadoEstado.ToJavascriptSource()), !bGXsfl_69_Refreshing);
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DataContentCellFL",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+dynMedidasID_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_listadoRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)dynMedidasID_Internalname,context.GetMessage( "Items/Característica", ""),(string)"col-sm-3 AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_69_idx + "',69)\"";
         GXCCtl = "MEDIDASID_" + sGXsfl_69_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         /* ComboBox */
         Freestylelevel_listadoRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,dynMedidasID.Enabled,(short)1,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"AttributeFL",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"",(bool)true,(short)0});
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_69_Refreshing);
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DataContentCellFL",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+dynInventarioId_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_listadoRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)dynInventarioId_Internalname,context.GetMessage( "Detalle", ""),(string)"col-sm-3 AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_69_idx + "',69)\"";
         GXCCtl = "INVENTARIOID_" + sGXsfl_69_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         /* ComboBox */
         Freestylelevel_listadoRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,dynInventarioId.Enabled,(short)1,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"AttributeFL",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"",(string)"",(bool)true,(short)0});
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_69_Refreshing);
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_121_137_135_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_121_137_135_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Freestylelevel_listadoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_121_137_135_Internalname,(string)sImgUrl,(string)imgprompt_121_137_135_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_121_137_135_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DataContentCellFL",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtMapeoListadoNombre_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_listadoRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtMapeoListadoNombre_Internalname,context.GetMessage( "Nombre de Referencia", ""),(string)"col-sm-3 AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_69_idx + "',69)\"";
         ROClassString = "AttributeFL";
         Freestylelevel_listadoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoListadoNombre_Internalname,StringUtil.RTrim( A925MapeoListadoNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMapeoListadoNombre_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtMapeoListadoNombre_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)69,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DataContentCellFL",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtInventarioRefCode_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_listadoRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtInventarioRefCode_Internalname,context.GetMessage( "Ref.: Código (SKU)", ""),(string)"col-sm-3 AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_69_idx + "',69)\"";
         ROClassString = "AttributeFL";
         Freestylelevel_listadoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioRefCode_Internalname,StringUtil.RTrim( A921InventarioRefCode),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioRefCode_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtInventarioRefCode_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)120,(short)0,(short)0,(short)69,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-9 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableleaflevel_referencia_Internalname+"_"+sGXsfl_69_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_listadoRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Freestylelevel_listadoRow.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Gridlevel_referenciaContainer"});
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_referenciaContainer = new GXWebGrid( context);
         }
         else
         {
            Gridlevel_referenciaContainer.Clear();
         }
         StartGridControl105( ) ;
         nGXsfl_105_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount136 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_136 = 1;
               ScanStart2U136( ) ;
               while ( RcdFound136 != 0 )
               {
                  init_level_properties136( ) ;
                  getByPrimaryKey2U136( ) ;
                  AddRow2U136( ) ;
                  ScanNext2U136( ) ;
               }
               ScanEnd2U136( ) ;
               nBlankRcdCount136 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2U136( ) ;
            standaloneModal2U136( ) ;
            sMode136 = Gx_mode;
            while ( nGXsfl_105_idx < nRC_GXsfl_105 )
            {
               bGXsfl_105_Refreshing = true;
               ReadRow2U136( ) ;
               edtMapeoListadoReferenciaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMapeoListadoReferenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0), !bGXsfl_105_Refreshing);
               edtMapeoListadoReferenciaURL_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMapeoListadoReferenciaURL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaURL_Enabled), 5, 0), !bGXsfl_105_Refreshing);
               edtMapeoListadoReferenciaNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMapeoListadoReferenciaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaNombre_Enabled), 5, 0), !bGXsfl_105_Refreshing);
               cmbMapeoListadoReferenciaEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbMapeoListadoReferenciaEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMapeoListadoReferenciaEstado.Enabled), 5, 0), !bGXsfl_105_Refreshing);
               if ( ( nRcdExists_136 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2U136( ) ;
               }
               SendRow2U136( ) ;
               bGXsfl_105_Refreshing = false;
            }
            Gx_mode = sMode136;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount136 = 5;
            nRcdExists_136 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2U136( ) ;
               while ( RcdFound136 != 0 )
               {
                  sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx+1), 4, 0), 4, "0") + sGXsfl_69_idx;
                  SubsflControlProps_105136( ) ;
                  init_level_properties136( ) ;
                  standaloneNotModal2U136( ) ;
                  getByPrimaryKey2U136( ) ;
                  standaloneModal2U136( ) ;
                  AddRow2U136( ) ;
                  ScanNext2U136( ) ;
               }
               ScanEnd2U136( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode136 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx+1), 4, 0), 4, "0") + sGXsfl_69_idx;
            SubsflControlProps_105136( ) ;
            InitAll2U136( ) ;
            init_level_properties136( ) ;
            nRcdExists_136 = 0;
            nIsMod_136 = 0;
            nRcdDeleted_136 = 0;
            if ( ( NumberUtil.Val( EvtGridId, ".") + NumberUtil.Val( EvtRowId, ".") == Convert.ToDecimal( 0 )) || (Convert.ToDecimal( 69 ) == NumberUtil.Val( EvtGridId, ".") ) && ( NumberUtil.Val( EvtRowId, ".") == NumberUtil.Val( sGXsfl_69_idx, ".") ) )
            {
               nBlankRcdCount136 = (short)(nBlankRcdUsr136+nBlankRcdCount136);
            }
            fRowAdded = 0;
            while ( nBlankRcdCount136 > 0 )
            {
               standaloneNotModal2U136( ) ;
               standaloneModal2U136( ) ;
               AddRow2U136( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtMapeoListadoReferenciaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount136 = (short)(nBlankRcdCount136-1);
            }
            Gx_mode = sMode136;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( ! isAjaxCallMode( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_referenciaContainerData"+"_"+sGXsfl_69_idx, Gridlevel_referenciaContainer.ToJavascriptSource());
         }
         if ( isAjaxCallMode( ) )
         {
            Freestylelevel_listadoRow.AddGrid("Gridlevel_referencia", Gridlevel_referenciaContainer);
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_referenciaContainerData"+"V_"+sGXsfl_69_idx, Gridlevel_referenciaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_referenciaContainerData"+"V_"+sGXsfl_69_idx+"\" value='"+Gridlevel_referenciaContainer.GridValuesHidden()+"'/>") ;
         }
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_listadoRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* End of table */
         context.httpAjaxContext.ajax_sending_grid_row(Freestylelevel_listadoRow);
         send_integrity_lvl_hashes2U135( ) ;
         GXCCtl = "Z121RubrosId_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z137MedidasID_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z135InventarioId_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z925MapeoListadoNombre_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z925MapeoListadoNombre));
         GXCCtl = "Z926MapeoListadoEstado_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z926MapeoListadoEstado));
         GXCCtl = "nRC_GXsfl_105_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_105_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_135_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_135), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_135_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_135), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_135_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_135), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_69_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vMAPEOID_" + sGXsfl_69_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOESTADO_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOID_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADONOMBRE_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOREFCODE_"+sGXsfl_69_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_121_137_135_"+sGXsfl_69_idx+"Link", StringUtil.RTrim( imgprompt_121_137_135_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         GRIDLEVEL_REFERENCIA_nFirstRecordOnPage = 0;
         GRIDLEVEL_REFERENCIA_nCurrentRecord = 0;
         /* End of Columns property logic. */
         Freestylelevel_listadoContainer.AddRow(Freestylelevel_listadoRow);
      }

      protected void ReadRow2U135( )
      {
         nGXsfl_69_idx = (int)(nGXsfl_69_idx+1);
         sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx), 4, 0), 4, "0");
         SubsflControlProps_69135( ) ;
         edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbMapeoListadoEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOESTADO_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMapeoListadoNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADONOMBRE_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioRefCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOREFCODE_"+sGXsfl_69_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_133_Link = cgiGet( "PROMPT_121_137_135_"+sGXsfl_69_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_69_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            wbErr = true;
            A121RubrosId = 0;
         }
         else
         {
            A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         cmbMapeoListadoEstado.Name = cmbMapeoListadoEstado_Internalname;
         cmbMapeoListadoEstado.CurrentValue = cgiGet( cmbMapeoListadoEstado_Internalname);
         A926MapeoListadoEstado = cgiGet( cmbMapeoListadoEstado_Internalname);
         dynMedidasID.Name = dynMedidasID_Internalname;
         dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
         dynInventarioId.Name = dynInventarioId_Internalname;
         dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
         A925MapeoListadoNombre = cgiGet( edtMapeoListadoNombre_Internalname);
         A921InventarioRefCode = cgiGet( edtInventarioRefCode_Internalname);
         GXCCtl = "Z121RubrosId_" + sGXsfl_69_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z137MedidasID_" + sGXsfl_69_idx;
         Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z135InventarioId_" + sGXsfl_69_idx;
         Z135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z925MapeoListadoNombre_" + sGXsfl_69_idx;
         Z925MapeoListadoNombre = cgiGet( GXCCtl);
         GXCCtl = "Z926MapeoListadoEstado_" + sGXsfl_69_idx;
         Z926MapeoListadoEstado = cgiGet( GXCCtl);
         GXCCtl = "nRC_GXsfl_105_" + sGXsfl_69_idx;
         nRC_GXsfl_105 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_135_" + sGXsfl_69_idx;
         nRcdDeleted_135 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_135_" + sGXsfl_69_idx;
         nRcdExists_135 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_135_" + sGXsfl_69_idx;
         nIsMod_135 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_105_" + sGXsfl_69_idx;
         nRC_GXsfl_105 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_105136( )
      {
         edtMapeoListadoReferenciaId_Internalname = "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_idx;
         edtMapeoListadoReferenciaURL_Internalname = "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_idx;
         edtMapeoListadoReferenciaNombre_Internalname = "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_idx;
         cmbMapeoListadoReferenciaEstado_Internalname = "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_idx;
      }

      protected void SubsflControlProps_fel_105136( )
      {
         edtMapeoListadoReferenciaId_Internalname = "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_fel_idx;
         edtMapeoListadoReferenciaURL_Internalname = "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_fel_idx;
         edtMapeoListadoReferenciaNombre_Internalname = "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_fel_idx;
         cmbMapeoListadoReferenciaEstado_Internalname = "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_fel_idx;
      }

      protected void AddRow2U136( )
      {
         nGXsfl_105_idx = (int)(nGXsfl_105_idx+1);
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0") + sGXsfl_69_idx;
         SubsflControlProps_105136( ) ;
         SendRow2U136( ) ;
      }

      protected void SendRow2U136( )
      {
         Gridlevel_referenciaRow = GXWebRow.GetNew(context);
         if ( subGridlevel_referencia_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_referencia_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_referencia_Class, "") != 0 )
            {
               subGridlevel_referencia_Linesclass = subGridlevel_referencia_Class+"Odd";
            }
         }
         else if ( subGridlevel_referencia_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_referencia_Backstyle = 0;
            subGridlevel_referencia_Backcolor = subGridlevel_referencia_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_referencia_Class, "") != 0 )
            {
               subGridlevel_referencia_Linesclass = subGridlevel_referencia_Class+"Uniform";
            }
         }
         else if ( subGridlevel_referencia_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_referencia_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_referencia_Class, "") != 0 )
            {
               subGridlevel_referencia_Linesclass = subGridlevel_referencia_Class+"Odd";
            }
            subGridlevel_referencia_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_referencia_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_referencia_Backstyle = 1;
            if ( ((int)((nGXsfl_105_idx) % (2))) == 0 )
            {
               subGridlevel_referencia_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_referencia_Class, "") != 0 )
               {
                  subGridlevel_referencia_Linesclass = subGridlevel_referencia_Class+"Even";
               }
            }
            else
            {
               subGridlevel_referencia_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_referencia_Class, "") != 0 )
               {
                  subGridlevel_referencia_Linesclass = subGridlevel_referencia_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_136_" + sGXsfl_105_idx + "',1);gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_105_idx + "',105)\"";
         ROClassString = "Attribute";
         Gridlevel_referenciaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoListadoReferenciaId_Internalname,StringUtil.RTrim( A920MapeoListadoReferenciaId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMapeoListadoReferenciaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMapeoListadoReferenciaId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_136_" + sGXsfl_105_idx + "',1);gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_105_idx + "',105)\"";
         ROClassString = "Attribute";
         Gridlevel_referenciaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoListadoReferenciaURL_Internalname,(string)A927MapeoListadoReferenciaURL,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)A927MapeoListadoReferenciaURL,(string)"_blank",(string)"",(string)"",(string)edtMapeoListadoReferenciaURL_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMapeoListadoReferenciaURL_Enabled,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_136_" + sGXsfl_105_idx + "',1);gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_105_idx + "',105)\"";
         ROClassString = "Attribute";
         Gridlevel_referenciaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoListadoReferenciaNombre_Internalname,StringUtil.RTrim( A928MapeoListadoReferenciaNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMapeoListadoReferenciaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMapeoListadoReferenciaNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_136_" + sGXsfl_105_idx + "',1);gx.fn.setControlValue('nIsMod_135_" + sGXsfl_69_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_105_idx + "',105)\"";
         if ( ( cmbMapeoListadoReferenciaEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MAPEOLISTADOREFERENCIAESTADO_" + sGXsfl_105_idx;
            cmbMapeoListadoReferenciaEstado.Name = GXCCtl;
            cmbMapeoListadoReferenciaEstado.WebTags = "";
            cmbMapeoListadoReferenciaEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbMapeoListadoReferenciaEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbMapeoListadoReferenciaEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbMapeoListadoReferenciaEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbMapeoListadoReferenciaEstado.ItemCount > 0 )
            {
               A929MapeoListadoReferenciaEstado = cmbMapeoListadoReferenciaEstado.getValidValue(A929MapeoListadoReferenciaEstado);
               n929MapeoListadoReferenciaEstado = false;
            }
         }
         /* ComboBox */
         Gridlevel_referenciaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMapeoListadoReferenciaEstado,(string)cmbMapeoListadoReferenciaEstado_Internalname,StringUtil.RTrim( A929MapeoListadoReferenciaEstado),(short)1,(string)cmbMapeoListadoReferenciaEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbMapeoListadoReferenciaEstado.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"",(string)"",(bool)true,(short)0});
         cmbMapeoListadoReferenciaEstado.CurrentValue = StringUtil.RTrim( A929MapeoListadoReferenciaEstado);
         AssignProp("", false, cmbMapeoListadoReferenciaEstado_Internalname, "Values", (string)(cmbMapeoListadoReferenciaEstado.ToJavascriptSource()), !bGXsfl_105_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_referenciaRow);
         send_integrity_lvl_hashes2U136( ) ;
         GXCCtl = "Z920MapeoListadoReferenciaId_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z920MapeoListadoReferenciaId));
         GXCCtl = "Z927MapeoListadoReferenciaURL_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z927MapeoListadoReferenciaURL);
         GXCCtl = "Z928MapeoListadoReferenciaNombre_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z928MapeoListadoReferenciaNombre));
         GXCCtl = "Z929MapeoListadoReferenciaEstado_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z929MapeoListadoReferenciaEstado));
         GXCCtl = "nRcdDeleted_136_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_136), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_136_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_136), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_136_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_136), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_105_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vMAPEOID_" + sGXsfl_105_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaURL_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoReferenciaEstado.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_referenciaContainer.AddRow(Gridlevel_referenciaRow);
      }

      protected void ReadRow2U136( )
      {
         nGXsfl_105_idx = (int)(nGXsfl_105_idx+1);
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0") + sGXsfl_69_idx;
         SubsflControlProps_105136( ) ;
         edtMapeoListadoReferenciaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIAID_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMapeoListadoReferenciaURL_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIAURL_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMapeoListadoReferenciaNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIANOMBRE_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbMapeoListadoReferenciaEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAPEOLISTADOREFERENCIAESTADO_"+sGXsfl_105_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A920MapeoListadoReferenciaId = cgiGet( edtMapeoListadoReferenciaId_Internalname);
         A927MapeoListadoReferenciaURL = cgiGet( edtMapeoListadoReferenciaURL_Internalname);
         n927MapeoListadoReferenciaURL = false;
         n927MapeoListadoReferenciaURL = (String.IsNullOrEmpty(StringUtil.RTrim( A927MapeoListadoReferenciaURL)) ? true : false);
         A928MapeoListadoReferenciaNombre = cgiGet( edtMapeoListadoReferenciaNombre_Internalname);
         n928MapeoListadoReferenciaNombre = false;
         n928MapeoListadoReferenciaNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A928MapeoListadoReferenciaNombre)) ? true : false);
         cmbMapeoListadoReferenciaEstado.Name = cmbMapeoListadoReferenciaEstado_Internalname;
         cmbMapeoListadoReferenciaEstado.CurrentValue = cgiGet( cmbMapeoListadoReferenciaEstado_Internalname);
         A929MapeoListadoReferenciaEstado = cgiGet( cmbMapeoListadoReferenciaEstado_Internalname);
         n929MapeoListadoReferenciaEstado = false;
         n929MapeoListadoReferenciaEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A929MapeoListadoReferenciaEstado)) ? true : false);
         GXCCtl = "Z920MapeoListadoReferenciaId_" + sGXsfl_105_idx;
         Z920MapeoListadoReferenciaId = cgiGet( GXCCtl);
         GXCCtl = "Z927MapeoListadoReferenciaURL_" + sGXsfl_105_idx;
         Z927MapeoListadoReferenciaURL = cgiGet( GXCCtl);
         n927MapeoListadoReferenciaURL = (String.IsNullOrEmpty(StringUtil.RTrim( A927MapeoListadoReferenciaURL)) ? true : false);
         GXCCtl = "Z928MapeoListadoReferenciaNombre_" + sGXsfl_105_idx;
         Z928MapeoListadoReferenciaNombre = cgiGet( GXCCtl);
         n928MapeoListadoReferenciaNombre = (String.IsNullOrEmpty(StringUtil.RTrim( A928MapeoListadoReferenciaNombre)) ? true : false);
         GXCCtl = "Z929MapeoListadoReferenciaEstado_" + sGXsfl_105_idx;
         Z929MapeoListadoReferenciaEstado = cgiGet( GXCCtl);
         n929MapeoListadoReferenciaEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A929MapeoListadoReferenciaEstado)) ? true : false);
         GXCCtl = "nRcdDeleted_136_" + sGXsfl_105_idx;
         nRcdDeleted_136 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_136_" + sGXsfl_105_idx;
         nRcdExists_136 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_136_" + sGXsfl_105_idx;
         nIsMod_136 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtMapeoListadoReferenciaId_Enabled = edtMapeoListadoReferenciaId_Enabled;
         defdynInventarioId_Enabled = dynInventarioId.Enabled;
         defdynMedidasID_Enabled = dynMedidasID.Enabled;
         defedtRubrosId_Enabled = edtRubrosId_Enabled;
      }

      protected void ConfirmValues2U0( )
      {
         nGXsfl_105_idx = 0;
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0") + sGXsfl_69_idx;
         SubsflControlProps_105136( ) ;
         while ( nGXsfl_105_idx < nRC_GXsfl_105 )
         {
            nGXsfl_105_idx = (int)(nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0") + sGXsfl_69_idx;
            SubsflControlProps_105136( ) ;
            ChangePostValue( "Z920MapeoListadoReferenciaId_"+sGXsfl_105_idx, cgiGet( "ZT_"+"Z920MapeoListadoReferenciaId_"+sGXsfl_105_idx)) ;
            DeletePostValue( "ZT_"+"Z920MapeoListadoReferenciaId_"+sGXsfl_105_idx) ;
            ChangePostValue( "Z927MapeoListadoReferenciaURL_"+sGXsfl_105_idx, cgiGet( "ZT_"+"Z927MapeoListadoReferenciaURL_"+sGXsfl_105_idx)) ;
            DeletePostValue( "ZT_"+"Z927MapeoListadoReferenciaURL_"+sGXsfl_105_idx) ;
            ChangePostValue( "Z928MapeoListadoReferenciaNombre_"+sGXsfl_105_idx, cgiGet( "ZT_"+"Z928MapeoListadoReferenciaNombre_"+sGXsfl_105_idx)) ;
            DeletePostValue( "ZT_"+"Z928MapeoListadoReferenciaNombre_"+sGXsfl_105_idx) ;
            ChangePostValue( "Z929MapeoListadoReferenciaEstado_"+sGXsfl_105_idx, cgiGet( "ZT_"+"Z929MapeoListadoReferenciaEstado_"+sGXsfl_105_idx)) ;
            DeletePostValue( "ZT_"+"Z929MapeoListadoReferenciaEstado_"+sGXsfl_105_idx) ;
         }
         nGXsfl_69_idx = 0;
         sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx), 4, 0), 4, "0");
         SubsflControlProps_69135( ) ;
         while ( nGXsfl_69_idx < nRC_GXsfl_69 )
         {
            nGXsfl_69_idx = (int)(nGXsfl_69_idx+1);
            sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx), 4, 0), 4, "0");
            SubsflControlProps_69135( ) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_69_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_69_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_69_idx) ;
            ChangePostValue( "Z137MedidasID_"+sGXsfl_69_idx, cgiGet( "ZT_"+"Z137MedidasID_"+sGXsfl_69_idx)) ;
            DeletePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_69_idx) ;
            ChangePostValue( "Z135InventarioId_"+sGXsfl_69_idx, cgiGet( "ZT_"+"Z135InventarioId_"+sGXsfl_69_idx)) ;
            DeletePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_69_idx) ;
            ChangePostValue( "Z925MapeoListadoNombre_"+sGXsfl_69_idx, cgiGet( "ZT_"+"Z925MapeoListadoNombre_"+sGXsfl_69_idx)) ;
            DeletePostValue( "ZT_"+"Z925MapeoListadoNombre_"+sGXsfl_69_idx) ;
            ChangePostValue( "Z926MapeoListadoEstado_"+sGXsfl_69_idx, cgiGet( "ZT_"+"Z926MapeoListadoEstado_"+sGXsfl_69_idx)) ;
            DeletePostValue( "ZT_"+"Z926MapeoListadoEstado_"+sGXsfl_69_idx) ;
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
         GXEncryptionTmp = "mapeo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MapeoID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mapeo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Mapeo");
         forbiddenHiddens.Add("MapeoID", context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV13Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_STComerciosID", context.localUtil.Format( (decimal)(AV14Insert_STComerciosID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ConexionesID", StringUtil.RTrim( context.localUtil.Format( AV15Insert_ConexionesID, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("mapeo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z918MapeoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z918MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z922MapeoEstado", StringUtil.RTrim( Z922MapeoEstado));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z919STComerciosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z552ConexionesID", StringUtil.RTrim( Z552ConexionesID));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_69", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_69_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N919STComerciosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N552ConexionesID", StringUtil.RTrim( A552ConexionesID));
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
         GxWebStd.gx_hidden_field( context, "vMAPEOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMAPEOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MapeoID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_STCOMERCIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONEXIONESID", StringUtil.RTrim( AV15Insert_ConexionesID));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Objectcall", StringUtil.RTrim( Dvpanel_tableintermediatelevel_listado_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Enabled", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Width", StringUtil.RTrim( Dvpanel_tableintermediatelevel_listado_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Autowidth", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Autoheight", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Cls", StringUtil.RTrim( Dvpanel_tableintermediatelevel_listado_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Title", StringUtil.RTrim( Dvpanel_tableintermediatelevel_listado_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Collapsible", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Collapsed", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Iconposition", StringUtil.RTrim( Dvpanel_tableintermediatelevel_listado_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableintermediatelevel_listado_Autoscroll));
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
         GXEncryptionTmp = "mapeo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MapeoID,18,0));
         return formatLink("mapeo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Mapeo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Mapeo", "") ;
      }

      protected void InitializeNonKey2U134( )
      {
         A133ProveedorID = 0;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         A919STComerciosID = 0;
         n919STComerciosID = false;
         AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
         n919STComerciosID = ((0==A919STComerciosID) ? true : false);
         A552ConexionesID = "";
         n552ConexionesID = false;
         AssignAttri("", false, "A552ConexionesID", A552ConexionesID);
         n552ConexionesID = (String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ? true : false);
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A344ProveedorEstado = "";
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         A923STComerciosNombre = "";
         AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
         A924STComerciosEstado = "";
         AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         A556ConexionesNombre = "";
         n556ConexionesNombre = false;
         AssignAttri("", false, "A556ConexionesNombre", A556ConexionesNombre);
         A922MapeoEstado = "";
         n922MapeoEstado = false;
         AssignAttri("", false, "A922MapeoEstado", A922MapeoEstado);
         n922MapeoEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A922MapeoEstado)) ? true : false);
         Z922MapeoEstado = "";
         Z133ProveedorID = 0;
         Z919STComerciosID = 0;
         Z552ConexionesID = "";
      }

      protected void InitAll2U134( )
      {
         A918MapeoID = 0;
         AssignAttri("", false, "A918MapeoID", StringUtil.LTrimStr( (decimal)(A918MapeoID), 18, 0));
         InitializeNonKey2U134( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2U135( )
      {
         A921InventarioRefCode = "";
         A925MapeoListadoNombre = "";
         A926MapeoListadoEstado = "";
         Z925MapeoListadoNombre = "";
         Z926MapeoListadoEstado = "";
      }

      protected void InitAll2U135( )
      {
         A121RubrosId = 0;
         A137MedidasID = 0;
         A135InventarioId = 0;
         InitializeNonKey2U135( ) ;
      }

      protected void StandaloneModalInsert2U135( )
      {
      }

      protected void InitializeNonKey2U136( )
      {
         A927MapeoListadoReferenciaURL = "";
         n927MapeoListadoReferenciaURL = false;
         A928MapeoListadoReferenciaNombre = "";
         n928MapeoListadoReferenciaNombre = false;
         A929MapeoListadoReferenciaEstado = "";
         n929MapeoListadoReferenciaEstado = false;
         Z927MapeoListadoReferenciaURL = "";
         Z928MapeoListadoReferenciaNombre = "";
         Z929MapeoListadoReferenciaEstado = "";
      }

      protected void InitAll2U136( )
      {
         A920MapeoListadoReferenciaId = "";
         InitializeNonKey2U136( ) ;
      }

      protected void StandaloneModalInsert2U136( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320115066", true, true, false);
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
         context.AddJavascriptSource("mapeo.js", "?20269320115066", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties135( )
      {
         dynInventarioId.Enabled = defdynInventarioId_Enabled;
         AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         dynMedidasID.Enabled = defdynMedidasID_Enabled;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_69_Refreshing);
         edtRubrosId_Enabled = defedtRubrosId_Enabled;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_69_Refreshing);
      }

      protected void init_level_properties136( )
      {
         edtMapeoListadoReferenciaId_Enabled = defedtMapeoListadoReferenciaId_Enabled;
         AssignProp("", false, edtMapeoListadoReferenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0), !bGXsfl_105_Refreshing);
      }

      protected void StartGridControl69( )
      {
         Freestylelevel_listadoContainer.AddObjectProperty("GridName", "Freestylelevel_listado");
         Freestylelevel_listadoContainer.AddObjectProperty("Header", subFreestylelevel_listado_Header);
         Freestylelevel_listadoContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylelevel_listadoContainer.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylelevel_listadoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Backcolorstyle), 1, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("CmpContext", "");
         Freestylelevel_listadoContainer.AddObjectProperty("InMasterPage", "false");
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Freestylelevel_listadoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A926MapeoListadoEstado)));
         Freestylelevel_listadoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoEstado.Enabled), 5, 0, ".", "")));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
         Freestylelevel_listadoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
         Freestylelevel_listadoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A925MapeoListadoNombre)));
         Freestylelevel_listadoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoNombre_Enabled), 5, 0, ".", "")));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A921InventarioRefCode)));
         Freestylelevel_listadoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", "")));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_listadoContainer.AddColumnProperties(Freestylelevel_listadoColumn);
         Freestylelevel_listadoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Selectedindex), 4, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Allowselection), 1, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Selectioncolor), 9, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Allowhovering), 1, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Hoveringcolor), 9, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Allowcollapsing), 1, 0, ".", "")));
         Freestylelevel_listadoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_listado_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl105( )
      {
         Gridlevel_referenciaContainer.AddObjectProperty("GridName", "Gridlevel_referencia");
         Gridlevel_referenciaContainer.AddObjectProperty("Header", subGridlevel_referencia_Header);
         Gridlevel_referenciaContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_referenciaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_referenciaContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_referenciaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_referenciaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A920MapeoListadoReferenciaId)));
         Gridlevel_referenciaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaId_Enabled), 5, 0, ".", "")));
         Gridlevel_referenciaContainer.AddColumnProperties(Gridlevel_referenciaColumn);
         Gridlevel_referenciaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_referenciaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A927MapeoListadoReferenciaURL));
         Gridlevel_referenciaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaURL_Enabled), 5, 0, ".", "")));
         Gridlevel_referenciaContainer.AddColumnProperties(Gridlevel_referenciaColumn);
         Gridlevel_referenciaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_referenciaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A928MapeoListadoReferenciaNombre)));
         Gridlevel_referenciaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoListadoReferenciaNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_referenciaContainer.AddColumnProperties(Gridlevel_referenciaColumn);
         Gridlevel_referenciaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_referenciaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A929MapeoListadoReferenciaEstado)));
         Gridlevel_referenciaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMapeoListadoReferenciaEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_referenciaContainer.AddColumnProperties(Gridlevel_referenciaColumn);
         Gridlevel_referenciaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Selectedindex), 4, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Allowselection), 1, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Allowhovering), 1, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_referenciaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_referencia_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtMapeoID_Internalname = "MAPEOID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         edtSTComerciosID_Internalname = "STCOMERCIOSID";
         edtSTComerciosNombre_Internalname = "STCOMERCIOSNOMBRE";
         cmbSTComerciosEstado_Internalname = "STCOMERCIOSESTADO";
         edtConexionesID_Internalname = "CONEXIONESID";
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE";
         cmbMapeoEstado_Internalname = "MAPEOESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtRubrosId_Internalname = "RUBROSID";
         cmbMapeoListadoEstado_Internalname = "MAPEOLISTADOESTADO";
         dynMedidasID_Internalname = "MEDIDASID";
         dynInventarioId_Internalname = "INVENTARIOID";
         edtMapeoListadoNombre_Internalname = "MAPEOLISTADONOMBRE";
         edtInventarioRefCode_Internalname = "INVENTARIOREFCODE";
         edtMapeoListadoReferenciaId_Internalname = "MAPEOLISTADOREFERENCIAID";
         edtMapeoListadoReferenciaURL_Internalname = "MAPEOLISTADOREFERENCIAURL";
         edtMapeoListadoReferenciaNombre_Internalname = "MAPEOLISTADOREFERENCIANOMBRE";
         cmbMapeoListadoReferenciaEstado_Internalname = "MAPEOLISTADOREFERENCIAESTADO";
         divTableleaflevel_referencia_Internalname = "TABLELEAFLEVEL_REFERENCIA";
         divTableintermediateinslevel_listado_Internalname = "TABLEINTERMEDIATEINSLEVEL_LISTADO";
         tblUnnamedtablefsfreestylelevel_listado_Internalname = "UNNAMEDTABLEFSFREESTYLELEVEL_LISTADO";
         divTableintermediatelevel_listado_Internalname = "TABLEINTERMEDIATELEVEL_LISTADO";
         Dvpanel_tableintermediatelevel_listado_Internalname = "DVPANEL_TABLEINTERMEDIATELEVEL_LISTADO";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_133_Internalname = "PROMPT_133";
         imgprompt_919_Internalname = "PROMPT_919";
         imgprompt_552_Internalname = "PROMPT_552";
         imgprompt_121_137_135_Internalname = "PROMPT_121_137_135";
         subGridlevel_referencia_Internalname = "GRIDLEVEL_REFERENCIA";
         subFreestylelevel_listado_Internalname = "FREESTYLELEVEL_LISTADO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_referencia_Allowcollapsing = 0;
         subGridlevel_referencia_Allowselection = 0;
         subGridlevel_referencia_Header = "";
         subFreestylelevel_listado_Allowcollapsing = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Mapeo", "");
         cmbMapeoListadoReferenciaEstado_Jsonclick = "";
         edtMapeoListadoReferenciaNombre_Jsonclick = "";
         edtMapeoListadoReferenciaURL_Jsonclick = "";
         edtMapeoListadoReferenciaId_Jsonclick = "";
         subGridlevel_referencia_Class = "WorkWith";
         subGridlevel_referencia_Backcolorstyle = 0;
         edtInventarioRefCode_Jsonclick = "";
         edtMapeoListadoNombre_Jsonclick = "";
         imgprompt_121_137_135_Visible = 1;
         imgprompt_121_137_135_Link = "";
         dynInventarioId_Jsonclick = "";
         dynMedidasID_Jsonclick = "";
         cmbMapeoListadoEstado_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         subFreestylelevel_listado_Class = "FreeStyleGrid";
         subFreestylelevel_listado_Backcolorstyle = 0;
         cmbMapeoListadoReferenciaEstado.Enabled = 1;
         edtMapeoListadoReferenciaNombre_Enabled = 1;
         edtMapeoListadoReferenciaURL_Enabled = 1;
         edtMapeoListadoReferenciaId_Enabled = 1;
         edtInventarioRefCode_Enabled = 0;
         edtMapeoListadoNombre_Enabled = 1;
         dynInventarioId.Enabled = 1;
         dynMedidasID.Enabled = 1;
         cmbMapeoListadoEstado.Enabled = 1;
         edtRubrosId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Dvpanel_tableintermediatelevel_listado_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableintermediatelevel_listado_Iconposition = "Right";
         Dvpanel_tableintermediatelevel_listado_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableintermediatelevel_listado_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableintermediatelevel_listado_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableintermediatelevel_listado_Title = context.GetMessage( "Lista de Productos", "");
         Dvpanel_tableintermediatelevel_listado_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tableintermediatelevel_listado_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableintermediatelevel_listado_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableintermediatelevel_listado_Width = "100%";
         cmbMapeoEstado_Jsonclick = "";
         cmbMapeoEstado.Enabled = 1;
         edtConexionesNombre_Jsonclick = "";
         edtConexionesNombre_Enabled = 0;
         imgprompt_552_Visible = 1;
         imgprompt_552_Link = "";
         edtConexionesID_Jsonclick = "";
         edtConexionesID_Enabled = 1;
         cmbSTComerciosEstado_Jsonclick = "";
         cmbSTComerciosEstado.Enabled = 0;
         edtSTComerciosNombre_Jsonclick = "";
         edtSTComerciosNombre_Enabled = 0;
         imgprompt_919_Visible = 1;
         imgprompt_919_Link = "";
         edtSTComerciosID_Jsonclick = "";
         edtSTComerciosID_Enabled = 1;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado.Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         imgprompt_133_Visible = 1;
         imgprompt_133_Link = "";
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 1;
         edtMapeoID_Jsonclick = "";
         edtMapeoID_Enabled = 0;
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
         GXAMEDIDASID_html2U135( A121RubrosId) ;
         GXAINVENTARIOID_html2U135( A121RubrosId, A137MedidasID) ;
         /* End function dynload_actions */
      }

      protected void GXDLAMEDIDASID2U135( short A121RubrosId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data2U135( A121RubrosId) ;
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

      protected void GXAMEDIDASID_html2U135( short A121RubrosId )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data2U135( A121RubrosId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMedidasID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynMedidasID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAMEDIDASID_data2U135( short A121RubrosId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T002U40 */
         pr_default.execute(38, new Object[] {A121RubrosId});
         while ( (pr_default.getStatus(38) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T002U40_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T002U40_A138MedidasNombre[0]));
            pr_default.readNext(38);
         }
         pr_default.close(38);
      }

      protected void GXDLAINVENTARIOID2U135( short A121RubrosId ,
                                             long A137MedidasID )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_data2U135( A121RubrosId, A137MedidasID) ;
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

      protected void GXAINVENTARIOID_html2U135( short A121RubrosId ,
                                                long A137MedidasID )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_data2U135( A121RubrosId, A137MedidasID) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynInventarioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynInventarioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAINVENTARIOID_data2U135( short A121RubrosId ,
                                                  long A137MedidasID )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T002U41 */
         pr_default.execute(39, new Object[] {A121RubrosId, A137MedidasID});
         while ( (pr_default.getStatus(39) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T002U41_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T002U41_A136InventarioNombre[0]));
            pr_default.readNext(39);
         }
         pr_default.close(39);
      }

      protected void gxnrFreestylelevel_listado_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_69135( ) ;
         while ( nGXsfl_69_idx <= nRC_GXsfl_69 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2U135( ) ;
            standaloneModal2U135( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2U135( ) ;
            Freestylelevel_listadoRow.AddGrid("Gridlevel_referencia", Gridlevel_referenciaContainer);
            nGXsfl_69_idx = (int)(nGXsfl_69_idx+1);
            sGXsfl_69_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_69_idx), 4, 0), 4, "0");
            SubsflControlProps_69135( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylelevel_listadoContainer)) ;
         /* End function gxnrFreestylelevel_listado_newrow */
      }

      protected void gxnrGridlevel_referencia_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_105136( ) ;
         while ( nGXsfl_105_idx <= nRC_GXsfl_105 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2U135( ) ;
            standaloneModal2U135( ) ;
            standaloneNotModal2U136( ) ;
            standaloneModal2U136( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2U136( ) ;
            nGXsfl_105_idx = (int)(nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0") + sGXsfl_69_idx;
            SubsflControlProps_105136( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_referenciaContainer)) ;
         /* End function gxnrGridlevel_referencia_newrow */
      }

      protected void init_web_controls( )
      {
         cmbProveedorEstado.Name = "PROVEEDORESTADO";
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         cmbSTComerciosEstado.Name = "STCOMERCIOSESTADO";
         cmbSTComerciosEstado.WebTags = "";
         cmbSTComerciosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbSTComerciosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbSTComerciosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbSTComerciosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbSTComerciosEstado.ItemCount > 0 )
         {
            A924STComerciosEstado = cmbSTComerciosEstado.getValidValue(A924STComerciosEstado);
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         }
         cmbMapeoEstado.Name = "MAPEOESTADO";
         cmbMapeoEstado.WebTags = "";
         cmbMapeoEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMapeoEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMapeoEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMapeoEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMapeoEstado.ItemCount > 0 )
         {
            A922MapeoEstado = cmbMapeoEstado.getValidValue(A922MapeoEstado);
            n922MapeoEstado = false;
            AssignAttri("", false, "A922MapeoEstado", A922MapeoEstado);
         }
         GXCCtl = "MAPEOLISTADOESTADO_" + sGXsfl_69_idx;
         cmbMapeoListadoEstado.Name = GXCCtl;
         cmbMapeoListadoEstado.WebTags = "";
         cmbMapeoListadoEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMapeoListadoEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMapeoListadoEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMapeoListadoEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMapeoListadoEstado.ItemCount > 0 )
         {
            A926MapeoListadoEstado = cmbMapeoListadoEstado.getValidValue(A926MapeoListadoEstado);
         }
         GXCCtl = "MEDIDASID_" + sGXsfl_69_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_69_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         GXCCtl = "MAPEOLISTADOREFERENCIAESTADO_" + sGXsfl_105_idx;
         cmbMapeoListadoReferenciaEstado.Name = GXCCtl;
         cmbMapeoListadoReferenciaEstado.WebTags = "";
         cmbMapeoListadoReferenciaEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMapeoListadoReferenciaEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMapeoListadoReferenciaEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMapeoListadoReferenciaEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMapeoListadoReferenciaEstado.ItemCount > 0 )
         {
            A929MapeoListadoReferenciaEstado = cmbMapeoListadoReferenciaEstado.getValidValue(A929MapeoListadoReferenciaEstado);
            n929MapeoListadoReferenciaEstado = false;
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
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A344ProveedorEstado = cmbProveedorEstado.CurrentValue;
         cmbProveedorEstado.CurrentValue = A344ProveedorEstado;
         /* Using cursor T002U22 */
         pr_default.execute(20, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
         }
         A282ProveedorNombre = T002U22_A282ProveedorNombre[0];
         A344ProveedorEstado = T002U22_A344ProveedorEstado[0];
         cmbProveedorEstado.CurrentValue = A344ProveedorEstado;
         pr_default.close(20);
         dynload_actions( ) ;
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            cmbProveedorEstado.CurrentValue = A344ProveedorEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A344ProveedorEstado", StringUtil.RTrim( A344ProveedorEstado));
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
      }

      public void Valid_Stcomerciosid( )
      {
         n919STComerciosID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A924STComerciosEstado = cmbSTComerciosEstado.CurrentValue;
         cmbSTComerciosEstado.CurrentValue = A924STComerciosEstado;
         /* Using cursor T002U23 */
         pr_default.execute(21, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
               GX_FocusControl = edtSTComerciosID_Internalname;
            }
         }
         A923STComerciosNombre = T002U23_A923STComerciosNombre[0];
         A924STComerciosEstado = T002U23_A924STComerciosEstado[0];
         cmbSTComerciosEstado.CurrentValue = A924STComerciosEstado;
         pr_default.close(21);
         dynload_actions( ) ;
         if ( cmbSTComerciosEstado.ItemCount > 0 )
         {
            A924STComerciosEstado = cmbSTComerciosEstado.getValidValue(A924STComerciosEstado);
            cmbSTComerciosEstado.CurrentValue = A924STComerciosEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A923STComerciosNombre", StringUtil.RTrim( A923STComerciosNombre));
         AssignAttri("", false, "A924STComerciosEstado", StringUtil.RTrim( A924STComerciosEstado));
         cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
         AssignProp("", false, cmbSTComerciosEstado_Internalname, "Values", cmbSTComerciosEstado.ToJavascriptSource(), true);
      }

      public void Valid_Conexionesid( )
      {
         n552ConexionesID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n556ConexionesNombre = false;
         /* Using cursor T002U24 */
         pr_default.execute(22, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Conexiones", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CONEXIONESID");
               AnyError = 1;
               GX_FocusControl = edtConexionesID_Internalname;
            }
         }
         A556ConexionesNombre = T002U24_A556ConexionesNombre[0];
         n556ConexionesNombre = T002U24_n556ConexionesNombre[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A556ConexionesNombre", StringUtil.RTrim( A556ConexionesNombre));
      }

      public void Valid_Rubrosid( )
      {
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         if ( (0==A121RubrosId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Rubros Identificador ", ""), "", "", "", "", "", "", "", ""), 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
         }
         dynload_actions( ) ;
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A137MedidasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", dynMedidasID.ToJavascriptSource(), true);
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Medidasid( )
      {
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         dynload_actions( ) ;
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Inventarioid( )
      {
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T002U42 */
         pr_default.execute(40, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(40) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
         }
         pr_default.close(40);
         A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
         dynload_actions( ) ;
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A921InventarioRefCode", StringUtil.RTrim( A921InventarioRefCode));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7MapeoID',fld:'vMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MapeoID',fld:'vMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A918MapeoID',fld:'MAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13Insert_ProveedorID',fld:'vINSERT_PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14Insert_STComerciosID',fld:'vINSERT_STCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15Insert_ConexionesID',fld:'vINSERT_CONEXIONESID',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E122U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MAPEOID","{handler:'Valid_Mapeoid',iparms:[]");
         setEventMetadata("VALID_MAPEOID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_STCOMERCIOSID","{handler:'Valid_Stcomerciosid',iparms:[{av:'A919STComerciosID',fld:'STCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A923STComerciosNombre',fld:'STCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'cmbSTComerciosEstado'},{av:'A924STComerciosEstado',fld:'STCOMERCIOSESTADO',pic:'',type:'char'}]");
         setEventMetadata("VALID_STCOMERCIOSID",",oparms:[{av:'A923STComerciosNombre',fld:'STCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'cmbSTComerciosEstado'},{av:'A924STComerciosEstado',fld:'STCOMERCIOSESTADO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_CONEXIONESID","{handler:'Valid_Conexionesid',iparms:[{av:'A552ConexionesID',fld:'CONEXIONESID',pic:'',type:'char'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A556ConexionesNombre',fld:'CONEXIONESNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_CONEXIONESID",",oparms:[{av:'A556ConexionesNombre',fld:'CONEXIONESNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_MAPEOESTADO","{handler:'Valid_Mapeoestado',iparms:[]");
         setEventMetadata("VALID_MAPEOESTADO",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MAPEOLISTADOESTADO","{handler:'Valid_Mapeolistadoestado',iparms:[]");
         setEventMetadata("VALID_MAPEOLISTADOESTADO",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A921InventarioRefCode',fld:'INVENTARIOREFCODE',pic:'',type:'char'}]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[{av:'A921InventarioRefCode',fld:'INVENTARIOREFCODE',pic:'',type:'char'}]}");
         setEventMetadata("NULL","{handler:'Valid_Inventariorefcode',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_MAPEOLISTADOREFERENCIAID","{handler:'Valid_Mapeolistadoreferenciaid',iparms:[]");
         setEventMetadata("VALID_MAPEOLISTADOREFERENCIAID",",oparms:[]}");
         setEventMetadata("VALID_MAPEOLISTADOREFERENCIAURL","{handler:'Valid_Mapeolistadoreferenciaurl',iparms:[]");
         setEventMetadata("VALID_MAPEOLISTADOREFERENCIAURL",",oparms:[]}");
         setEventMetadata("VALID_MAPEOLISTADOREFERENCIAESTADO","{handler:'Valid_Mapeolistadoreferenciaestado',iparms:[]");
         setEventMetadata("VALID_MAPEOLISTADOREFERENCIAESTADO",",oparms:[]}");
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
         pr_default.close(40);
         pr_default.close(6);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z922MapeoEstado = "";
         Z552ConexionesID = "";
         N552ConexionesID = "";
         Z925MapeoListadoNombre = "";
         Z926MapeoListadoEstado = "";
         Z920MapeoListadoReferenciaId = "";
         Z927MapeoListadoReferenciaURL = "";
         Z928MapeoListadoReferenciaNombre = "";
         Z929MapeoListadoReferenciaEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A552ConexionesID = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A344ProveedorEstado = "";
         A924STComerciosEstado = "";
         A922MapeoEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_133_gximage = "";
         sImgUrl = "";
         A282ProveedorNombre = "";
         imgprompt_919_gximage = "";
         A923STComerciosNombre = "";
         imgprompt_552_gximage = "";
         A556ConexionesNombre = "";
         ucDvpanel_tableintermediatelevel_listado = new GXUserControl();
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Freestylelevel_listadoContainer = new GXWebGrid( context);
         sMode135 = "";
         sStyleString = "";
         AV15Insert_ConexionesID = "";
         AV17Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         Dvpanel_tableintermediatelevel_listado_Objectcall = "";
         Dvpanel_tableintermediatelevel_listado_Class = "";
         Dvpanel_tableintermediatelevel_listado_Height = "";
         Dvpanel_tableintermediatelevel_listado_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode134 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A920MapeoListadoReferenciaId = "";
         A927MapeoListadoReferenciaURL = "";
         A928MapeoListadoReferenciaNombre = "";
         A929MapeoListadoReferenciaEstado = "";
         A926MapeoListadoEstado = "";
         A925MapeoListadoNombre = "";
         A921InventarioRefCode = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV16TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z282ProveedorNombre = "";
         Z344ProveedorEstado = "";
         Z923STComerciosNombre = "";
         Z924STComerciosEstado = "";
         Z556ConexionesNombre = "";
         T002U11_A556ConexionesNombre = new string[] {""} ;
         T002U11_n556ConexionesNombre = new bool[] {false} ;
         T002U10_A923STComerciosNombre = new string[] {""} ;
         T002U10_A924STComerciosEstado = new string[] {""} ;
         T002U9_A282ProveedorNombre = new string[] {""} ;
         T002U9_A344ProveedorEstado = new string[] {""} ;
         T002U12_A918MapeoID = new long[1] ;
         T002U12_A282ProveedorNombre = new string[] {""} ;
         T002U12_A344ProveedorEstado = new string[] {""} ;
         T002U12_A923STComerciosNombre = new string[] {""} ;
         T002U12_A924STComerciosEstado = new string[] {""} ;
         T002U12_A556ConexionesNombre = new string[] {""} ;
         T002U12_n556ConexionesNombre = new bool[] {false} ;
         T002U12_A922MapeoEstado = new string[] {""} ;
         T002U12_n922MapeoEstado = new bool[] {false} ;
         T002U12_A133ProveedorID = new long[1] ;
         T002U12_A919STComerciosID = new long[1] ;
         T002U12_n919STComerciosID = new bool[] {false} ;
         T002U12_A552ConexionesID = new string[] {""} ;
         T002U12_n552ConexionesID = new bool[] {false} ;
         T002U13_A282ProveedorNombre = new string[] {""} ;
         T002U13_A344ProveedorEstado = new string[] {""} ;
         T002U14_A923STComerciosNombre = new string[] {""} ;
         T002U14_A924STComerciosEstado = new string[] {""} ;
         T002U15_A556ConexionesNombre = new string[] {""} ;
         T002U15_n556ConexionesNombre = new bool[] {false} ;
         T002U16_A918MapeoID = new long[1] ;
         T002U8_A918MapeoID = new long[1] ;
         T002U8_A922MapeoEstado = new string[] {""} ;
         T002U8_n922MapeoEstado = new bool[] {false} ;
         T002U8_A133ProveedorID = new long[1] ;
         T002U8_A919STComerciosID = new long[1] ;
         T002U8_n919STComerciosID = new bool[] {false} ;
         T002U8_A552ConexionesID = new string[] {""} ;
         T002U8_n552ConexionesID = new bool[] {false} ;
         T002U17_A918MapeoID = new long[1] ;
         T002U18_A918MapeoID = new long[1] ;
         T002U7_A918MapeoID = new long[1] ;
         T002U7_A922MapeoEstado = new string[] {""} ;
         T002U7_n922MapeoEstado = new bool[] {false} ;
         T002U7_A133ProveedorID = new long[1] ;
         T002U7_A919STComerciosID = new long[1] ;
         T002U7_n919STComerciosID = new bool[] {false} ;
         T002U7_A552ConexionesID = new string[] {""} ;
         T002U7_n552ConexionesID = new bool[] {false} ;
         T002U19_A918MapeoID = new long[1] ;
         T002U22_A282ProveedorNombre = new string[] {""} ;
         T002U22_A344ProveedorEstado = new string[] {""} ;
         T002U23_A923STComerciosNombre = new string[] {""} ;
         T002U23_A924STComerciosEstado = new string[] {""} ;
         T002U24_A556ConexionesNombre = new string[] {""} ;
         T002U24_n556ConexionesNombre = new bool[] {false} ;
         T002U25_A918MapeoID = new long[1] ;
         T002U25_A121RubrosId = new short[1] ;
         T002U25_A137MedidasID = new long[1] ;
         T002U25_A135InventarioId = new long[1] ;
         T002U26_A918MapeoID = new long[1] ;
         T002U27_A918MapeoID = new long[1] ;
         T002U27_A925MapeoListadoNombre = new string[] {""} ;
         T002U27_A926MapeoListadoEstado = new string[] {""} ;
         T002U27_A121RubrosId = new short[1] ;
         T002U27_A137MedidasID = new long[1] ;
         T002U27_A135InventarioId = new long[1] ;
         T002U6_A121RubrosId = new short[1] ;
         T002U28_A121RubrosId = new short[1] ;
         T002U29_A918MapeoID = new long[1] ;
         T002U29_A121RubrosId = new short[1] ;
         T002U29_A137MedidasID = new long[1] ;
         T002U29_A135InventarioId = new long[1] ;
         T002U5_A918MapeoID = new long[1] ;
         T002U5_A925MapeoListadoNombre = new string[] {""} ;
         T002U5_A926MapeoListadoEstado = new string[] {""} ;
         T002U5_A121RubrosId = new short[1] ;
         T002U5_A137MedidasID = new long[1] ;
         T002U5_A135InventarioId = new long[1] ;
         T002U4_A918MapeoID = new long[1] ;
         T002U4_A925MapeoListadoNombre = new string[] {""} ;
         T002U4_A926MapeoListadoEstado = new string[] {""} ;
         T002U4_A121RubrosId = new short[1] ;
         T002U4_A137MedidasID = new long[1] ;
         T002U4_A135InventarioId = new long[1] ;
         T002U33_A918MapeoID = new long[1] ;
         T002U33_A121RubrosId = new short[1] ;
         T002U33_A137MedidasID = new long[1] ;
         T002U33_A135InventarioId = new long[1] ;
         T002U34_A918MapeoID = new long[1] ;
         T002U34_A121RubrosId = new short[1] ;
         T002U34_A137MedidasID = new long[1] ;
         T002U34_A135InventarioId = new long[1] ;
         T002U34_A920MapeoListadoReferenciaId = new string[] {""} ;
         T002U34_A927MapeoListadoReferenciaURL = new string[] {""} ;
         T002U34_n927MapeoListadoReferenciaURL = new bool[] {false} ;
         T002U34_A928MapeoListadoReferenciaNombre = new string[] {""} ;
         T002U34_n928MapeoListadoReferenciaNombre = new bool[] {false} ;
         T002U34_A929MapeoListadoReferenciaEstado = new string[] {""} ;
         T002U34_n929MapeoListadoReferenciaEstado = new bool[] {false} ;
         T002U35_A918MapeoID = new long[1] ;
         T002U35_A121RubrosId = new short[1] ;
         T002U35_A137MedidasID = new long[1] ;
         T002U35_A135InventarioId = new long[1] ;
         T002U35_A920MapeoListadoReferenciaId = new string[] {""} ;
         T002U3_A918MapeoID = new long[1] ;
         T002U3_A121RubrosId = new short[1] ;
         T002U3_A137MedidasID = new long[1] ;
         T002U3_A135InventarioId = new long[1] ;
         T002U3_A920MapeoListadoReferenciaId = new string[] {""} ;
         T002U3_A927MapeoListadoReferenciaURL = new string[] {""} ;
         T002U3_n927MapeoListadoReferenciaURL = new bool[] {false} ;
         T002U3_A928MapeoListadoReferenciaNombre = new string[] {""} ;
         T002U3_n928MapeoListadoReferenciaNombre = new bool[] {false} ;
         T002U3_A929MapeoListadoReferenciaEstado = new string[] {""} ;
         T002U3_n929MapeoListadoReferenciaEstado = new bool[] {false} ;
         sMode136 = "";
         T002U2_A918MapeoID = new long[1] ;
         T002U2_A121RubrosId = new short[1] ;
         T002U2_A137MedidasID = new long[1] ;
         T002U2_A135InventarioId = new long[1] ;
         T002U2_A920MapeoListadoReferenciaId = new string[] {""} ;
         T002U2_A927MapeoListadoReferenciaURL = new string[] {""} ;
         T002U2_n927MapeoListadoReferenciaURL = new bool[] {false} ;
         T002U2_A928MapeoListadoReferenciaNombre = new string[] {""} ;
         T002U2_n928MapeoListadoReferenciaNombre = new bool[] {false} ;
         T002U2_A929MapeoListadoReferenciaEstado = new string[] {""} ;
         T002U2_n929MapeoListadoReferenciaEstado = new bool[] {false} ;
         T002U39_A918MapeoID = new long[1] ;
         T002U39_A121RubrosId = new short[1] ;
         T002U39_A137MedidasID = new long[1] ;
         T002U39_A135InventarioId = new long[1] ;
         T002U39_A920MapeoListadoReferenciaId = new string[] {""} ;
         Freestylelevel_listadoRow = new GXWebRow();
         subFreestylelevel_listado_Linesclass = "";
         ROClassString = "";
         imgprompt_121_137_135_gximage = "";
         Gridlevel_referenciaContainer = new GXWebGrid( context);
         Gridlevel_referenciaRow = new GXWebRow();
         subGridlevel_referencia_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         subFreestylelevel_listado_Header = "";
         Freestylelevel_listadoColumn = new GXWebColumn();
         Gridlevel_referenciaColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T002U40_A121RubrosId = new short[1] ;
         T002U40_A137MedidasID = new long[1] ;
         T002U40_A138MedidasNombre = new string[] {""} ;
         T002U40_A139MedidasEstado = new string[] {""} ;
         T002U40_n139MedidasEstado = new bool[] {false} ;
         T002U41_A121RubrosId = new short[1] ;
         T002U41_A137MedidasID = new long[1] ;
         T002U41_A135InventarioId = new long[1] ;
         T002U41_A136InventarioNombre = new string[] {""} ;
         T002U41_A107EstadosTipo = new string[] {""} ;
         T002U41_A108EstadosGenericosId = new int[1] ;
         T002U42_A121RubrosId = new short[1] ;
         Z921InventarioRefCode = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.mapeo__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mapeo__default(),
            new Object[][] {
                new Object[] {
               T002U2_A918MapeoID, T002U2_A121RubrosId, T002U2_A137MedidasID, T002U2_A135InventarioId, T002U2_A920MapeoListadoReferenciaId, T002U2_A927MapeoListadoReferenciaURL, T002U2_n927MapeoListadoReferenciaURL, T002U2_A928MapeoListadoReferenciaNombre, T002U2_n928MapeoListadoReferenciaNombre, T002U2_A929MapeoListadoReferenciaEstado,
               T002U2_n929MapeoListadoReferenciaEstado
               }
               , new Object[] {
               T002U3_A918MapeoID, T002U3_A121RubrosId, T002U3_A137MedidasID, T002U3_A135InventarioId, T002U3_A920MapeoListadoReferenciaId, T002U3_A927MapeoListadoReferenciaURL, T002U3_n927MapeoListadoReferenciaURL, T002U3_A928MapeoListadoReferenciaNombre, T002U3_n928MapeoListadoReferenciaNombre, T002U3_A929MapeoListadoReferenciaEstado,
               T002U3_n929MapeoListadoReferenciaEstado
               }
               , new Object[] {
               T002U4_A918MapeoID, T002U4_A925MapeoListadoNombre, T002U4_A926MapeoListadoEstado, T002U4_A121RubrosId, T002U4_A137MedidasID, T002U4_A135InventarioId
               }
               , new Object[] {
               T002U5_A918MapeoID, T002U5_A925MapeoListadoNombre, T002U5_A926MapeoListadoEstado, T002U5_A121RubrosId, T002U5_A137MedidasID, T002U5_A135InventarioId
               }
               , new Object[] {
               T002U6_A121RubrosId
               }
               , new Object[] {
               T002U7_A918MapeoID, T002U7_A922MapeoEstado, T002U7_n922MapeoEstado, T002U7_A133ProveedorID, T002U7_A919STComerciosID, T002U7_n919STComerciosID, T002U7_A552ConexionesID, T002U7_n552ConexionesID
               }
               , new Object[] {
               T002U8_A918MapeoID, T002U8_A922MapeoEstado, T002U8_n922MapeoEstado, T002U8_A133ProveedorID, T002U8_A919STComerciosID, T002U8_n919STComerciosID, T002U8_A552ConexionesID, T002U8_n552ConexionesID
               }
               , new Object[] {
               T002U9_A282ProveedorNombre, T002U9_A344ProveedorEstado
               }
               , new Object[] {
               T002U10_A923STComerciosNombre, T002U10_A924STComerciosEstado
               }
               , new Object[] {
               T002U11_A556ConexionesNombre, T002U11_n556ConexionesNombre
               }
               , new Object[] {
               T002U12_A918MapeoID, T002U12_A282ProveedorNombre, T002U12_A344ProveedorEstado, T002U12_A923STComerciosNombre, T002U12_A924STComerciosEstado, T002U12_A556ConexionesNombre, T002U12_n556ConexionesNombre, T002U12_A922MapeoEstado, T002U12_n922MapeoEstado, T002U12_A133ProveedorID,
               T002U12_A919STComerciosID, T002U12_n919STComerciosID, T002U12_A552ConexionesID, T002U12_n552ConexionesID
               }
               , new Object[] {
               T002U13_A282ProveedorNombre, T002U13_A344ProveedorEstado
               }
               , new Object[] {
               T002U14_A923STComerciosNombre, T002U14_A924STComerciosEstado
               }
               , new Object[] {
               T002U15_A556ConexionesNombre, T002U15_n556ConexionesNombre
               }
               , new Object[] {
               T002U16_A918MapeoID
               }
               , new Object[] {
               T002U17_A918MapeoID
               }
               , new Object[] {
               T002U18_A918MapeoID
               }
               , new Object[] {
               T002U19_A918MapeoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002U22_A282ProveedorNombre, T002U22_A344ProveedorEstado
               }
               , new Object[] {
               T002U23_A923STComerciosNombre, T002U23_A924STComerciosEstado
               }
               , new Object[] {
               T002U24_A556ConexionesNombre, T002U24_n556ConexionesNombre
               }
               , new Object[] {
               T002U25_A918MapeoID, T002U25_A121RubrosId, T002U25_A137MedidasID, T002U25_A135InventarioId
               }
               , new Object[] {
               T002U26_A918MapeoID
               }
               , new Object[] {
               T002U27_A918MapeoID, T002U27_A925MapeoListadoNombre, T002U27_A926MapeoListadoEstado, T002U27_A121RubrosId, T002U27_A137MedidasID, T002U27_A135InventarioId
               }
               , new Object[] {
               T002U28_A121RubrosId
               }
               , new Object[] {
               T002U29_A918MapeoID, T002U29_A121RubrosId, T002U29_A137MedidasID, T002U29_A135InventarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002U33_A918MapeoID, T002U33_A121RubrosId, T002U33_A137MedidasID, T002U33_A135InventarioId
               }
               , new Object[] {
               T002U34_A918MapeoID, T002U34_A121RubrosId, T002U34_A137MedidasID, T002U34_A135InventarioId, T002U34_A920MapeoListadoReferenciaId, T002U34_A927MapeoListadoReferenciaURL, T002U34_n927MapeoListadoReferenciaURL, T002U34_A928MapeoListadoReferenciaNombre, T002U34_n928MapeoListadoReferenciaNombre, T002U34_A929MapeoListadoReferenciaEstado,
               T002U34_n929MapeoListadoReferenciaEstado
               }
               , new Object[] {
               T002U35_A918MapeoID, T002U35_A121RubrosId, T002U35_A137MedidasID, T002U35_A135InventarioId, T002U35_A920MapeoListadoReferenciaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002U39_A918MapeoID, T002U39_A121RubrosId, T002U39_A137MedidasID, T002U39_A135InventarioId, T002U39_A920MapeoListadoReferenciaId
               }
               , new Object[] {
               T002U40_A121RubrosId, T002U40_A137MedidasID, T002U40_A138MedidasNombre, T002U40_A139MedidasEstado, T002U40_n139MedidasEstado
               }
               , new Object[] {
               T002U41_A121RubrosId, T002U41_A137MedidasID, T002U41_A135InventarioId, T002U41_A136InventarioNombre, T002U41_A107EstadosTipo, T002U41_A108EstadosGenericosId
               }
               , new Object[] {
               T002U42_A121RubrosId
               }
            }
         );
         AV17Pgmname = "Mapeo";
      }

      private short nIsMod_135 ;
      private short Z121RubrosId ;
      private short nRcdDeleted_135 ;
      private short nRcdExists_135 ;
      private short nRcdDeleted_136 ;
      private short nRcdExists_136 ;
      private short nIsMod_136 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount135 ;
      private short RcdFound135 ;
      private short nBlankRcdUsr135 ;
      private short RcdFound134 ;
      private short RcdFound136 ;
      private short Gx_BScreen ;
      private short nIsDirty_135 ;
      private short nIsDirty_136 ;
      private short subFreestylelevel_listado_Backcolorstyle ;
      private short subFreestylelevel_listado_Backstyle ;
      private short nBlankRcdCount136 ;
      private short nBlankRcdUsr136 ;
      private short subGridlevel_referencia_Backcolorstyle ;
      private short subGridlevel_referencia_Backstyle ;
      private short gxajaxcallmode ;
      private short subFreestylelevel_listado_Allowselection ;
      private short subFreestylelevel_listado_Allowhovering ;
      private short subFreestylelevel_listado_Allowcollapsing ;
      private short subFreestylelevel_listado_Collapsed ;
      private short subGridlevel_referencia_Allowselection ;
      private short subGridlevel_referencia_Allowhovering ;
      private short subGridlevel_referencia_Allowcollapsing ;
      private short subGridlevel_referencia_Collapsed ;
      private int nRC_GXsfl_69 ;
      private int nGXsfl_69_idx=1 ;
      private int nRC_GXsfl_105 ;
      private int nGXsfl_105_idx=1 ;
      private int trnEnded ;
      private int edtMapeoID_Enabled ;
      private int edtProveedorID_Enabled ;
      private int imgprompt_133_Visible ;
      private int edtProveedorNombre_Enabled ;
      private int edtSTComerciosID_Enabled ;
      private int imgprompt_919_Visible ;
      private int edtSTComerciosNombre_Enabled ;
      private int edtConexionesID_Enabled ;
      private int imgprompt_552_Visible ;
      private int edtConexionesNombre_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtRubrosId_Enabled ;
      private int edtMapeoListadoNombre_Enabled ;
      private int edtInventarioRefCode_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Dvpanel_tableintermediatelevel_listado_Gxcontroltype ;
      private int edtMapeoListadoReferenciaId_Enabled ;
      private int edtMapeoListadoReferenciaURL_Enabled ;
      private int edtMapeoListadoReferenciaNombre_Enabled ;
      private int AV18GXV1 ;
      private int subFreestylelevel_listado_Backcolor ;
      private int subFreestylelevel_listado_Allbackcolor ;
      private int FREESTYLELEVEL_LISTADO_IsPaging ;
      private int imgprompt_121_137_135_Visible ;
      private int subGridlevel_referencia_Backcolor ;
      private int subGridlevel_referencia_Allbackcolor ;
      private int defedtMapeoListadoReferenciaId_Enabled ;
      private int defdynInventarioId_Enabled ;
      private int defdynMedidasID_Enabled ;
      private int defedtRubrosId_Enabled ;
      private int idxLst ;
      private int subFreestylelevel_listado_Selectedindex ;
      private int subFreestylelevel_listado_Selectioncolor ;
      private int subFreestylelevel_listado_Hoveringcolor ;
      private int subGridlevel_referencia_Selectedindex ;
      private int subGridlevel_referencia_Selectioncolor ;
      private int subGridlevel_referencia_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7MapeoID ;
      private long Z918MapeoID ;
      private long Z133ProveedorID ;
      private long Z919STComerciosID ;
      private long N133ProveedorID ;
      private long N919STComerciosID ;
      private long Z137MedidasID ;
      private long Z135InventarioId ;
      private long A137MedidasID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long A135InventarioId ;
      private long AV7MapeoID ;
      private long A918MapeoID ;
      private long GRIDLEVEL_REFERENCIA_nFirstRecordOnPage ;
      private long AV13Insert_ProveedorID ;
      private long AV14Insert_STComerciosID ;
      private long FREESTYLELEVEL_LISTADO_nFirstRecordOnPage ;
      private long GRIDLEVEL_REFERENCIA_nCurrentRecord ;
      private string sPrefix ;
      private string sGXsfl_69_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z922MapeoEstado ;
      private string Z552ConexionesID ;
      private string N552ConexionesID ;
      private string Z925MapeoListadoNombre ;
      private string Z926MapeoListadoEstado ;
      private string Z920MapeoListadoReferenciaId ;
      private string Z928MapeoListadoReferenciaNombre ;
      private string Z929MapeoListadoReferenciaEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A552ConexionesID ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProveedorID_Internalname ;
      private string sGXsfl_105_idx="0001" ;
      private string A344ProveedorEstado ;
      private string cmbProveedorEstado_Internalname ;
      private string A924STComerciosEstado ;
      private string cmbSTComerciosEstado_Internalname ;
      private string A922MapeoEstado ;
      private string cmbMapeoEstado_Internalname ;
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
      private string edtMapeoID_Internalname ;
      private string TempTags ;
      private string edtMapeoID_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string imgprompt_133_gximage ;
      private string sImgUrl ;
      private string imgprompt_133_Internalname ;
      private string imgprompt_133_Link ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string edtSTComerciosID_Internalname ;
      private string edtSTComerciosID_Jsonclick ;
      private string imgprompt_919_gximage ;
      private string imgprompt_919_Internalname ;
      private string imgprompt_919_Link ;
      private string edtSTComerciosNombre_Internalname ;
      private string A923STComerciosNombre ;
      private string edtSTComerciosNombre_Jsonclick ;
      private string cmbSTComerciosEstado_Jsonclick ;
      private string edtConexionesID_Internalname ;
      private string edtConexionesID_Jsonclick ;
      private string imgprompt_552_gximage ;
      private string imgprompt_552_Internalname ;
      private string imgprompt_552_Link ;
      private string edtConexionesNombre_Internalname ;
      private string A556ConexionesNombre ;
      private string edtConexionesNombre_Jsonclick ;
      private string cmbMapeoEstado_Jsonclick ;
      private string Dvpanel_tableintermediatelevel_listado_Width ;
      private string Dvpanel_tableintermediatelevel_listado_Cls ;
      private string Dvpanel_tableintermediatelevel_listado_Title ;
      private string Dvpanel_tableintermediatelevel_listado_Iconposition ;
      private string Dvpanel_tableintermediatelevel_listado_Internalname ;
      private string divTableintermediatelevel_listado_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode135 ;
      private string edtRubrosId_Internalname ;
      private string cmbMapeoListadoEstado_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string edtMapeoListadoNombre_Internalname ;
      private string edtInventarioRefCode_Internalname ;
      private string sStyleString ;
      private string subFreestylelevel_listado_Internalname ;
      private string AV15Insert_ConexionesID ;
      private string AV17Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string Dvpanel_tableintermediatelevel_listado_Objectcall ;
      private string Dvpanel_tableintermediatelevel_listado_Class ;
      private string Dvpanel_tableintermediatelevel_listado_Height ;
      private string Dvpanel_tableintermediatelevel_listado_Titletype ;
      private string hsh ;
      private string sMode134 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string edtMapeoListadoReferenciaId_Internalname ;
      private string A920MapeoListadoReferenciaId ;
      private string edtMapeoListadoReferenciaURL_Internalname ;
      private string edtMapeoListadoReferenciaNombre_Internalname ;
      private string A928MapeoListadoReferenciaNombre ;
      private string cmbMapeoListadoReferenciaEstado_Internalname ;
      private string A929MapeoListadoReferenciaEstado ;
      private string A926MapeoListadoEstado ;
      private string A925MapeoListadoNombre ;
      private string A921InventarioRefCode ;
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string Z344ProveedorEstado ;
      private string Z923STComerciosNombre ;
      private string Z924STComerciosEstado ;
      private string Z556ConexionesNombre ;
      private string sMode136 ;
      private string imgprompt_121_137_135_Internalname ;
      private string subGridlevel_referencia_Internalname ;
      private string sGXsfl_69_fel_idx="0001" ;
      private string subFreestylelevel_listado_Class ;
      private string subFreestylelevel_listado_Linesclass ;
      private string imgprompt_121_137_135_Link ;
      private string tblUnnamedtablefsfreestylelevel_listado_Internalname ;
      private string divTableintermediateinslevel_listado_Internalname ;
      private string ROClassString ;
      private string edtRubrosId_Jsonclick ;
      private string cmbMapeoListadoEstado_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string dynInventarioId_Jsonclick ;
      private string imgprompt_121_137_135_gximage ;
      private string edtMapeoListadoNombre_Jsonclick ;
      private string edtInventarioRefCode_Jsonclick ;
      private string divTableleaflevel_referencia_Internalname ;
      private string sGXsfl_105_fel_idx="0001" ;
      private string subGridlevel_referencia_Class ;
      private string subGridlevel_referencia_Linesclass ;
      private string edtMapeoListadoReferenciaId_Jsonclick ;
      private string edtMapeoListadoReferenciaURL_Jsonclick ;
      private string edtMapeoListadoReferenciaNombre_Jsonclick ;
      private string cmbMapeoListadoReferenciaEstado_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subFreestylelevel_listado_Header ;
      private string subGridlevel_referencia_Header ;
      private string gxwrpcisep ;
      private string Z921InventarioRefCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n919STComerciosID ;
      private bool n552ConexionesID ;
      private bool wbErr ;
      private bool n922MapeoEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableintermediatelevel_listado_Autowidth ;
      private bool Dvpanel_tableintermediatelevel_listado_Autoheight ;
      private bool Dvpanel_tableintermediatelevel_listado_Collapsible ;
      private bool Dvpanel_tableintermediatelevel_listado_Collapsed ;
      private bool Dvpanel_tableintermediatelevel_listado_Showcollapseicon ;
      private bool Dvpanel_tableintermediatelevel_listado_Autoscroll ;
      private bool bGXsfl_69_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Dvpanel_tableintermediatelevel_listado_Enabled ;
      private bool Dvpanel_tableintermediatelevel_listado_Showheader ;
      private bool Dvpanel_tableintermediatelevel_listado_Visible ;
      private bool n556ConexionesNombre ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool bGXsfl_105_Refreshing=false ;
      private bool n927MapeoListadoReferenciaURL ;
      private bool n928MapeoListadoReferenciaNombre ;
      private bool n929MapeoListadoReferenciaEstado ;
      private bool gxdyncontrolsrefreshing ;
      private string Z927MapeoListadoReferenciaURL ;
      private string A927MapeoListadoReferenciaURL ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Freestylelevel_listadoContainer ;
      private GXWebGrid Gridlevel_referenciaContainer ;
      private GXWebRow Freestylelevel_listadoRow ;
      private GXWebRow Gridlevel_referenciaRow ;
      private GXWebColumn Freestylelevel_listadoColumn ;
      private GXWebColumn Gridlevel_referenciaColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_tableintermediatelevel_listado ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorEstado ;
      private GXCombobox cmbSTComerciosEstado ;
      private GXCombobox cmbMapeoEstado ;
      private GXCombobox cmbMapeoListadoEstado ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private GXCombobox cmbMapeoListadoReferenciaEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002U11_A556ConexionesNombre ;
      private bool[] T002U11_n556ConexionesNombre ;
      private string[] T002U10_A923STComerciosNombre ;
      private string[] T002U10_A924STComerciosEstado ;
      private string[] T002U9_A282ProveedorNombre ;
      private string[] T002U9_A344ProveedorEstado ;
      private long[] T002U12_A918MapeoID ;
      private string[] T002U12_A282ProveedorNombre ;
      private string[] T002U12_A344ProveedorEstado ;
      private string[] T002U12_A923STComerciosNombre ;
      private string[] T002U12_A924STComerciosEstado ;
      private string[] T002U12_A556ConexionesNombre ;
      private bool[] T002U12_n556ConexionesNombre ;
      private string[] T002U12_A922MapeoEstado ;
      private bool[] T002U12_n922MapeoEstado ;
      private long[] T002U12_A133ProveedorID ;
      private long[] T002U12_A919STComerciosID ;
      private bool[] T002U12_n919STComerciosID ;
      private string[] T002U12_A552ConexionesID ;
      private bool[] T002U12_n552ConexionesID ;
      private string[] T002U13_A282ProveedorNombre ;
      private string[] T002U13_A344ProveedorEstado ;
      private string[] T002U14_A923STComerciosNombre ;
      private string[] T002U14_A924STComerciosEstado ;
      private string[] T002U15_A556ConexionesNombre ;
      private bool[] T002U15_n556ConexionesNombre ;
      private long[] T002U16_A918MapeoID ;
      private long[] T002U8_A918MapeoID ;
      private string[] T002U8_A922MapeoEstado ;
      private bool[] T002U8_n922MapeoEstado ;
      private long[] T002U8_A133ProveedorID ;
      private long[] T002U8_A919STComerciosID ;
      private bool[] T002U8_n919STComerciosID ;
      private string[] T002U8_A552ConexionesID ;
      private bool[] T002U8_n552ConexionesID ;
      private long[] T002U17_A918MapeoID ;
      private long[] T002U18_A918MapeoID ;
      private long[] T002U7_A918MapeoID ;
      private string[] T002U7_A922MapeoEstado ;
      private bool[] T002U7_n922MapeoEstado ;
      private long[] T002U7_A133ProveedorID ;
      private long[] T002U7_A919STComerciosID ;
      private bool[] T002U7_n919STComerciosID ;
      private string[] T002U7_A552ConexionesID ;
      private bool[] T002U7_n552ConexionesID ;
      private long[] T002U19_A918MapeoID ;
      private string[] T002U22_A282ProveedorNombre ;
      private string[] T002U22_A344ProveedorEstado ;
      private string[] T002U23_A923STComerciosNombre ;
      private string[] T002U23_A924STComerciosEstado ;
      private string[] T002U24_A556ConexionesNombre ;
      private bool[] T002U24_n556ConexionesNombre ;
      private long[] T002U25_A918MapeoID ;
      private short[] T002U25_A121RubrosId ;
      private long[] T002U25_A137MedidasID ;
      private long[] T002U25_A135InventarioId ;
      private long[] T002U26_A918MapeoID ;
      private long[] T002U27_A918MapeoID ;
      private string[] T002U27_A925MapeoListadoNombre ;
      private string[] T002U27_A926MapeoListadoEstado ;
      private short[] T002U27_A121RubrosId ;
      private long[] T002U27_A137MedidasID ;
      private long[] T002U27_A135InventarioId ;
      private short[] T002U6_A121RubrosId ;
      private short[] T002U28_A121RubrosId ;
      private long[] T002U29_A918MapeoID ;
      private short[] T002U29_A121RubrosId ;
      private long[] T002U29_A137MedidasID ;
      private long[] T002U29_A135InventarioId ;
      private long[] T002U5_A918MapeoID ;
      private string[] T002U5_A925MapeoListadoNombre ;
      private string[] T002U5_A926MapeoListadoEstado ;
      private short[] T002U5_A121RubrosId ;
      private long[] T002U5_A137MedidasID ;
      private long[] T002U5_A135InventarioId ;
      private long[] T002U4_A918MapeoID ;
      private string[] T002U4_A925MapeoListadoNombre ;
      private string[] T002U4_A926MapeoListadoEstado ;
      private short[] T002U4_A121RubrosId ;
      private long[] T002U4_A137MedidasID ;
      private long[] T002U4_A135InventarioId ;
      private long[] T002U33_A918MapeoID ;
      private short[] T002U33_A121RubrosId ;
      private long[] T002U33_A137MedidasID ;
      private long[] T002U33_A135InventarioId ;
      private long[] T002U34_A918MapeoID ;
      private short[] T002U34_A121RubrosId ;
      private long[] T002U34_A137MedidasID ;
      private long[] T002U34_A135InventarioId ;
      private string[] T002U34_A920MapeoListadoReferenciaId ;
      private string[] T002U34_A927MapeoListadoReferenciaURL ;
      private bool[] T002U34_n927MapeoListadoReferenciaURL ;
      private string[] T002U34_A928MapeoListadoReferenciaNombre ;
      private bool[] T002U34_n928MapeoListadoReferenciaNombre ;
      private string[] T002U34_A929MapeoListadoReferenciaEstado ;
      private bool[] T002U34_n929MapeoListadoReferenciaEstado ;
      private long[] T002U35_A918MapeoID ;
      private short[] T002U35_A121RubrosId ;
      private long[] T002U35_A137MedidasID ;
      private long[] T002U35_A135InventarioId ;
      private string[] T002U35_A920MapeoListadoReferenciaId ;
      private long[] T002U3_A918MapeoID ;
      private short[] T002U3_A121RubrosId ;
      private long[] T002U3_A137MedidasID ;
      private long[] T002U3_A135InventarioId ;
      private string[] T002U3_A920MapeoListadoReferenciaId ;
      private string[] T002U3_A927MapeoListadoReferenciaURL ;
      private bool[] T002U3_n927MapeoListadoReferenciaURL ;
      private string[] T002U3_A928MapeoListadoReferenciaNombre ;
      private bool[] T002U3_n928MapeoListadoReferenciaNombre ;
      private string[] T002U3_A929MapeoListadoReferenciaEstado ;
      private bool[] T002U3_n929MapeoListadoReferenciaEstado ;
      private long[] T002U2_A918MapeoID ;
      private short[] T002U2_A121RubrosId ;
      private long[] T002U2_A137MedidasID ;
      private long[] T002U2_A135InventarioId ;
      private string[] T002U2_A920MapeoListadoReferenciaId ;
      private string[] T002U2_A927MapeoListadoReferenciaURL ;
      private bool[] T002U2_n927MapeoListadoReferenciaURL ;
      private string[] T002U2_A928MapeoListadoReferenciaNombre ;
      private bool[] T002U2_n928MapeoListadoReferenciaNombre ;
      private string[] T002U2_A929MapeoListadoReferenciaEstado ;
      private bool[] T002U2_n929MapeoListadoReferenciaEstado ;
      private long[] T002U39_A918MapeoID ;
      private short[] T002U39_A121RubrosId ;
      private long[] T002U39_A137MedidasID ;
      private long[] T002U39_A135InventarioId ;
      private string[] T002U39_A920MapeoListadoReferenciaId ;
      private short[] T002U40_A121RubrosId ;
      private long[] T002U40_A137MedidasID ;
      private string[] T002U40_A138MedidasNombre ;
      private string[] T002U40_A139MedidasEstado ;
      private bool[] T002U40_n139MedidasEstado ;
      private short[] T002U41_A121RubrosId ;
      private long[] T002U41_A137MedidasID ;
      private long[] T002U41_A135InventarioId ;
      private string[] T002U41_A136InventarioNombre ;
      private string[] T002U41_A107EstadosTipo ;
      private int[] T002U41_A108EstadosGenericosId ;
      private short[] T002U42_A121RubrosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class mapeo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class mapeo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new UpdateCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002U2;
        prmT002U2 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0)
        };
        Object[] prmT002U3;
        prmT002U3 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0)
        };
        Object[] prmT002U4;
        prmT002U4 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U5;
        prmT002U5 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U6;
        prmT002U6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U7;
        prmT002U7 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U8;
        prmT002U8 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U9;
        prmT002U9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002U10;
        prmT002U10 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002U11;
        prmT002U11 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002U12;
        prmT002U12 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U13;
        prmT002U13 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002U14;
        prmT002U14 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002U15;
        prmT002U15 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002U16;
        prmT002U16 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U17;
        prmT002U17 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U18;
        prmT002U18 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U19;
        prmT002U19 = new Object[] {
        new ParDef("@MapeoEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002U20;
        prmT002U20 = new Object[] {
        new ParDef("@MapeoEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U21;
        prmT002U21 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U22;
        prmT002U22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002U23;
        prmT002U23 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002U24;
        prmT002U24 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmT002U25;
        prmT002U25 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U26;
        prmT002U26 = new Object[] {
        };
        Object[] prmT002U27;
        prmT002U27 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U28;
        prmT002U28 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U29;
        prmT002U29 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U30;
        prmT002U30 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoNombre",GXType.NChar,80,0) ,
        new ParDef("@MapeoListadoEstado",GXType.NChar,3,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U31;
        prmT002U31 = new Object[] {
        new ParDef("@MapeoListadoNombre",GXType.NChar,80,0) ,
        new ParDef("@MapeoListadoEstado",GXType.NChar,3,0) ,
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U32;
        prmT002U32 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U33;
        prmT002U33 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0)
        };
        Object[] prmT002U34;
        prmT002U34 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0)
        };
        Object[] prmT002U35;
        prmT002U35 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0)
        };
        Object[] prmT002U36;
        prmT002U36 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0) ,
        new ParDef("@MapeoListadoReferenciaURL",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@MapeoListadoReferenciaNombre",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@MapeoListadoReferenciaEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmT002U37;
        prmT002U37 = new Object[] {
        new ParDef("@MapeoListadoReferenciaURL",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@MapeoListadoReferenciaNombre",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@MapeoListadoReferenciaEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0)
        };
        Object[] prmT002U38;
        prmT002U38 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@MapeoListadoReferenciaId",GXType.NChar,120,0)
        };
        Object[] prmT002U39;
        prmT002U39 = new Object[] {
        new ParDef("@MapeoID",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002U40;
        prmT002U40 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002U41;
        prmT002U41 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT002U42;
        prmT002U42 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002U2", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId], [MapeoListadoReferenciaURL], [MapeoListadoReferenciaNombre], [MapeoListadoReferenciaEstado] FROM [MapeoListadoReferencia] WITH (UPDLOCK) WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId AND [MapeoListadoReferenciaId] = @MapeoListadoReferenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U3", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId], [MapeoListadoReferenciaURL], [MapeoListadoReferenciaNombre], [MapeoListadoReferenciaEstado] FROM [MapeoListadoReferencia] WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId AND [MapeoListadoReferenciaId] = @MapeoListadoReferenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U4", "SELECT [MapeoID], [MapeoListadoNombre], [MapeoListadoEstado], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WITH (UPDLOCK) WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U5", "SELECT [MapeoID], [MapeoListadoNombre], [MapeoListadoEstado], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U6", "SELECT [RubrosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U7", "SELECT [MapeoID], [MapeoEstado], [ProveedorID], [STComerciosID] AS STComerciosID, [ConexionesID] FROM [ListaMapeo] WITH (UPDLOCK) WHERE [MapeoID] = @MapeoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U8", "SELECT [MapeoID], [MapeoEstado], [ProveedorID], [STComerciosID] AS STComerciosID, [ConexionesID] FROM [ListaMapeo] WHERE [MapeoID] = @MapeoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U9", "SELECT [ProveedorNombre], [ProveedorEstado] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U10", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U11", "SELECT [ConexionesNombre] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U12", "SELECT TM1.[MapeoID], T2.[ProveedorNombre], T2.[ProveedorEstado], T3.[ProveedorNombre] AS STComerciosNombre, T3.[ProveedorEstado] AS STComerciosEstado, T4.[ConexionesNombre], TM1.[MapeoEstado], TM1.[ProveedorID], TM1.[STComerciosID] AS STComerciosID, TM1.[ConexionesID] FROM ((([ListaMapeo] TM1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = TM1.[ProveedorID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = TM1.[STComerciosID]) LEFT JOIN [Conexiones] T4 ON T4.[ConexionesID] = TM1.[ConexionesID]) WHERE TM1.[MapeoID] = @MapeoID ORDER BY TM1.[MapeoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U12,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U13", "SELECT [ProveedorNombre], [ProveedorEstado] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U14", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U15", "SELECT [ConexionesNombre] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U16", "SELECT [MapeoID] FROM [ListaMapeo] WHERE [MapeoID] = @MapeoID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U17", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE ( [MapeoID] > @MapeoID) ORDER BY [MapeoID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002U18", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE ( [MapeoID] < @MapeoID) ORDER BY [MapeoID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002U19", "INSERT INTO [ListaMapeo]([MapeoEstado], [ProveedorID], [STComerciosID], [ConexionesID]) VALUES(@MapeoEstado, @ProveedorID, @STComerciosID, @ConexionesID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002U19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002U20", "UPDATE [ListaMapeo] SET [MapeoEstado]=@MapeoEstado, [ProveedorID]=@ProveedorID, [STComerciosID]=@STComerciosID, [ConexionesID]=@ConexionesID  WHERE [MapeoID] = @MapeoID", GxErrorMask.GX_NOMASK,prmT002U20)
           ,new CursorDef("T002U21", "DELETE FROM [ListaMapeo]  WHERE [MapeoID] = @MapeoID", GxErrorMask.GX_NOMASK,prmT002U21)
           ,new CursorDef("T002U22", "SELECT [ProveedorNombre], [ProveedorEstado] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U23", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U24", "SELECT [ConexionesNombre] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U25", "SELECT TOP 1 [MapeoID], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [MapeoID] = @MapeoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002U26", "SELECT [MapeoID] FROM [ListaMapeo] ORDER BY [MapeoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U26,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U27", "SELECT [MapeoID], [MapeoListadoNombre], [MapeoListadoEstado], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [MapeoID] = @MapeoID and [RubrosId] = @RubrosId and [MedidasID] = @MedidasID and [InventarioId] = @InventarioId ORDER BY [MapeoID], [RubrosId], [MedidasID], [InventarioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U27,6, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U28", "SELECT [RubrosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U29", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U30", "INSERT INTO [MapeosListado]([MapeoID], [MapeoListadoNombre], [MapeoListadoEstado], [RubrosId], [MedidasID], [InventarioId]) VALUES(@MapeoID, @MapeoListadoNombre, @MapeoListadoEstado, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmT002U30)
           ,new CursorDef("T002U31", "UPDATE [MapeosListado] SET [MapeoListadoNombre]=@MapeoListadoNombre, [MapeoListadoEstado]=@MapeoListadoEstado  WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId", GxErrorMask.GX_NOMASK,prmT002U31)
           ,new CursorDef("T002U32", "DELETE FROM [MapeosListado]  WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId", GxErrorMask.GX_NOMASK,prmT002U32)
           ,new CursorDef("T002U33", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [MapeoID] = @MapeoID ORDER BY [MapeoID], [RubrosId], [MedidasID], [InventarioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U33,6, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U34", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId], [MapeoListadoReferenciaURL], [MapeoListadoReferenciaNombre], [MapeoListadoReferenciaEstado] FROM [MapeoListadoReferencia] WHERE [MapeoID] = @MapeoID and [RubrosId] = @RubrosId and [MedidasID] = @MedidasID and [InventarioId] = @InventarioId and [MapeoListadoReferenciaId] = @MapeoListadoReferenciaId ORDER BY [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U34,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U35", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId] FROM [MapeoListadoReferencia] WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId AND [MapeoListadoReferenciaId] = @MapeoListadoReferenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U36", "INSERT INTO [MapeoListadoReferencia]([MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId], [MapeoListadoReferenciaURL], [MapeoListadoReferenciaNombre], [MapeoListadoReferenciaEstado]) VALUES(@MapeoID, @RubrosId, @MedidasID, @InventarioId, @MapeoListadoReferenciaId, @MapeoListadoReferenciaURL, @MapeoListadoReferenciaNombre, @MapeoListadoReferenciaEstado)", GxErrorMask.GX_NOMASK,prmT002U36)
           ,new CursorDef("T002U37", "UPDATE [MapeoListadoReferencia] SET [MapeoListadoReferenciaURL]=@MapeoListadoReferenciaURL, [MapeoListadoReferenciaNombre]=@MapeoListadoReferenciaNombre, [MapeoListadoReferenciaEstado]=@MapeoListadoReferenciaEstado  WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId AND [MapeoListadoReferenciaId] = @MapeoListadoReferenciaId", GxErrorMask.GX_NOMASK,prmT002U37)
           ,new CursorDef("T002U38", "DELETE FROM [MapeoListadoReferencia]  WHERE [MapeoID] = @MapeoID AND [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId AND [MapeoListadoReferenciaId] = @MapeoListadoReferenciaId", GxErrorMask.GX_NOMASK,prmT002U38)
           ,new CursorDef("T002U39", "SELECT [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId] FROM [MapeoListadoReferencia] WHERE [MapeoID] = @MapeoID and [RubrosId] = @RubrosId and [MedidasID] = @MedidasID and [InventarioId] = @InventarioId ORDER BY [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U39,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U40", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE ([RubrosId] = @RubrosId) AND ([MedidasEstado] <> 'DES') ORDER BY [MedidasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U40,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U41", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [InventarioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U41,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U42", "SELECT [RubrosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U42,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 120);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 80);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 120);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 80);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 9);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 9);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 3);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 9);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 26 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 120);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 80);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 120);
              return;
           case 37 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 120);
              return;
           case 38 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 39 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 40 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}

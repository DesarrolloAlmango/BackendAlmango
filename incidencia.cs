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
   public class incidencia : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A604MotivoId = (long)(Math.Round(NumberUtil.Val( GetPar( "MotivoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A604MotivoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_detalle") == 0 )
         {
            gxnrGridlevel_detalle_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "incidencia.aspx")), "incidencia.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "incidencia.aspx")))) ;
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
                  AV8IncidenciaId = (long)(Math.Round(NumberUtil.Val( GetPar( "IncidenciaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV8IncidenciaId", StringUtil.LTrimStr( (decimal)(AV8IncidenciaId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Incidencia", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbIncidenciaOrigen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_detalle_newrow_invoke( )
      {
         nRC_GXsfl_73 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_73"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_73_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_73_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_73_idx = GetPar( "sGXsfl_73_idx");
         A613IncidenciaUltLin = (short)(Math.Round(NumberUtil.Val( GetPar( "IncidenciaUltLin"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_detalle_newrow( ) ;
         /* End function gxnrGridlevel_detalle_newrow_invoke */
      }

      public incidencia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public incidencia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IncidenciaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8IncidenciaId = aP1_IncidenciaId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbIncidenciaOrigen = new GXCombobox();
         cmbIncidenciaEstado = new GXCombobox();
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
         if ( cmbIncidenciaOrigen.ItemCount > 0 )
         {
            A611IncidenciaOrigen = cmbIncidenciaOrigen.getValidValue(A611IncidenciaOrigen);
            AssignAttri("", false, "A611IncidenciaOrigen", A611IncidenciaOrigen);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbIncidenciaOrigen.CurrentValue = StringUtil.RTrim( A611IncidenciaOrigen);
            AssignProp("", false, cmbIncidenciaOrigen_Internalname, "Values", cmbIncidenciaOrigen.ToJavascriptSource(), true);
         }
         if ( cmbIncidenciaEstado.ItemCount > 0 )
         {
            A608IncidenciaEstado = cmbIncidenciaEstado.getValidValue(A608IncidenciaEstado);
            AssignAttri("", false, "A608IncidenciaEstado", A608IncidenciaEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbIncidenciaEstado.CurrentValue = StringUtil.RTrim( A608IncidenciaEstado);
            AssignProp("", false, cmbIncidenciaEstado_Internalname, "Values", cmbIncidenciaEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIncidenciaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIncidenciaId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIncidenciaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A603IncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtIncidenciaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIncidenciaId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbIncidenciaOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbIncidenciaOrigen_Internalname, context.GetMessage( "Origen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbIncidenciaOrigen, cmbIncidenciaOrigen_Internalname, StringUtil.RTrim( A611IncidenciaOrigen), 1, cmbIncidenciaOrigen_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbIncidenciaOrigen.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Incidencia.htm");
         cmbIncidenciaOrigen.CurrentValue = StringUtil.RTrim( A611IncidenciaOrigen);
         AssignProp("", false, cmbIncidenciaOrigen_Internalname, "Values", (string)(cmbIncidenciaOrigen.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIncidenciaCodRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIncidenciaCodRef_Internalname, context.GetMessage( "Cod Ref", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIncidenciaCodRef_Internalname, A606IncidenciaCodRef, StringUtil.RTrim( context.localUtil.Format( A606IncidenciaCodRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaCodRef_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIncidenciaCodRef_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbIncidenciaEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbIncidenciaEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbIncidenciaEstado, cmbIncidenciaEstado_Internalname, StringUtil.RTrim( A608IncidenciaEstado), 1, cmbIncidenciaEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbIncidenciaEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_Incidencia.htm");
         cmbIncidenciaEstado.CurrentValue = StringUtil.RTrim( A608IncidenciaEstado);
         AssignProp("", false, cmbIncidenciaEstado_Internalname, "Values", (string)(cmbIncidenciaEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMotivoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMotivoId_Internalname, context.GetMessage( "Motivo Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMotivoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A604MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A604MotivoId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMotivoId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Incidencia.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_604_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_604_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_604_Internalname, sImgUrl, imgprompt_604_Link, "", "", context.GetTheme( ), imgprompt_604_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMotivoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMotivoNombre_Internalname, context.GetMessage( "Motivo Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMotivoNombre_Internalname, StringUtil.RTrim( A616MotivoNombre), StringUtil.RTrim( context.localUtil.Format( A616MotivoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMotivoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIncidenciaFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIncidenciaFechaAlta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIncidenciaFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIncidenciaFechaAlta_Internalname, context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"), context.localUtil.Format( A610IncidenciaFechaAlta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIncidenciaFechaAlta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Incidencia.htm");
         GxWebStd.gx_bitmap( context, edtIncidenciaFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIncidenciaFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Incidencia.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIncidenciaFechaActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIncidenciaFechaActualizacion_Internalname, context.GetMessage( "Fecha Actualizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIncidenciaFechaActualizacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIncidenciaFechaActualizacion_Internalname, context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"), context.localUtil.Format( A609IncidenciaFechaActualizacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaFechaActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIncidenciaFechaActualizacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Incidencia.htm");
         GxWebStd.gx_bitmap( context, edtIncidenciaFechaActualizacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIncidenciaFechaActualizacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Incidencia.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIncidenciaUsrAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIncidenciaUsrAlta_Internalname, context.GetMessage( "Usr Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIncidenciaUsrAlta_Internalname, StringUtil.RTrim( A615IncidenciaUsrAlta), StringUtil.RTrim( context.localUtil.Format( A615IncidenciaUsrAlta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaUsrAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIncidenciaUsrAlta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NickName", "start", true, "", "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIncidenciaUsrActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIncidenciaUsrActualizacion_Internalname, context.GetMessage( "Usr Actualizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIncidenciaUsrActualizacion_Internalname, StringUtil.RTrim( A614IncidenciaUsrActualizacion), StringUtil.RTrim( context.localUtil.Format( A614IncidenciaUsrActualizacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaUsrActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIncidenciaUsrActualizacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NickName", "start", true, "", "HLP_Incidencia.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_detalle_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_detalle( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Incidencia.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIncidenciaUltLin_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A613IncidenciaUltLin), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtIncidenciaUltLin_Enabled!=0) ? context.localUtil.Format( (decimal)(A613IncidenciaUltLin), "ZZZ9") : context.localUtil.Format( (decimal)(A613IncidenciaUltLin), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIncidenciaUltLin_Jsonclick, 0, "Attribute", "", "", "", "", edtIncidenciaUltLin_Visible, edtIncidenciaUltLin_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Incidencia.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_detalle( )
      {
         /*  Grid Control  */
         StartGridControl73( ) ;
         nGXsfl_73_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount90 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_90 = 1;
               ScanStart2690( ) ;
               while ( RcdFound90 != 0 )
               {
                  init_level_properties90( ) ;
                  getByPrimaryKey2690( ) ;
                  AddRow2690( ) ;
                  ScanNext2690( ) ;
               }
               ScanEnd2690( ) ;
               nBlankRcdCount90 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B613IncidenciaUltLin = A613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            standaloneNotModal2690( ) ;
            standaloneModal2690( ) ;
            sMode90 = Gx_mode;
            while ( nGXsfl_73_idx < nRC_GXsfl_73 )
            {
               bGXsfl_73_Refreshing = true;
               ReadRow2690( ) ;
               edtIncidenciaDetalleId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INCIDENCIADETALLEID_"+sGXsfl_73_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIncidenciaDetalleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtIncidenciaDetalleDesc_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INCIDENCIADETALLEDESC_"+sGXsfl_73_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIncidenciaDetalleDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleDesc_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               if ( ( nRcdExists_90 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2690( ) ;
               }
               SendRow2690( ) ;
               bGXsfl_73_Refreshing = false;
            }
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A613IncidenciaUltLin = B613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount90 = 5;
            nRcdExists_90 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2690( ) ;
               while ( RcdFound90 != 0 )
               {
                  sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7390( ) ;
                  init_level_properties90( ) ;
                  standaloneNotModal2690( ) ;
                  getByPrimaryKey2690( ) ;
                  standaloneModal2690( ) ;
                  AddRow2690( ) ;
                  ScanNext2690( ) ;
               }
               ScanEnd2690( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode90 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7390( ) ;
            InitAll2690( ) ;
            init_level_properties90( ) ;
            B613IncidenciaUltLin = A613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            nRcdExists_90 = 0;
            nIsMod_90 = 0;
            nRcdDeleted_90 = 0;
            nBlankRcdCount90 = (short)(nBlankRcdUsr90+nBlankRcdCount90);
            fRowAdded = 0;
            while ( nBlankRcdCount90 > 0 )
            {
               standaloneNotModal2690( ) ;
               standaloneModal2690( ) ;
               AddRow2690( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIncidenciaDetalleId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount90 = (short)(nBlankRcdCount90-1);
            }
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A613IncidenciaUltLin = B613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_detalleContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_detalle", Gridlevel_detalleContainer, subGridlevel_detalle_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_detalleContainerData", Gridlevel_detalleContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_detalleContainerData"+"V", Gridlevel_detalleContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_detalleContainerData"+"V"+"\" value='"+Gridlevel_detalleContainer.GridValuesHidden()+"'/>") ;
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
         E11262 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z603IncidenciaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z603IncidenciaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z610IncidenciaFechaAlta = context.localUtil.CToD( cgiGet( "Z610IncidenciaFechaAlta"), 0);
               Z609IncidenciaFechaActualizacion = context.localUtil.CToD( cgiGet( "Z609IncidenciaFechaActualizacion"), 0);
               Z611IncidenciaOrigen = cgiGet( "Z611IncidenciaOrigen");
               Z606IncidenciaCodRef = cgiGet( "Z606IncidenciaCodRef");
               Z608IncidenciaEstado = cgiGet( "Z608IncidenciaEstado");
               Z615IncidenciaUsrAlta = cgiGet( "Z615IncidenciaUsrAlta");
               Z614IncidenciaUsrActualizacion = cgiGet( "Z614IncidenciaUsrActualizacion");
               Z613IncidenciaUltLin = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z613IncidenciaUltLin"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z604MotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z604MotivoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O613IncidenciaUltLin = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O613IncidenciaUltLin"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_73 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N604MotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N604MotivoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8IncidenciaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINCIDENCIAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Insert_MotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MOTIVOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_MotivoId", StringUtil.LTrimStr( (decimal)(AV14Insert_MotivoId), 18, 0));
               A618MotivoTipo = cgiGet( "MOTIVOTIPO");
               n618MotivoTipo = false;
               AV17Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               A603IncidenciaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtIncidenciaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
               cmbIncidenciaOrigen.Name = cmbIncidenciaOrigen_Internalname;
               cmbIncidenciaOrigen.CurrentValue = cgiGet( cmbIncidenciaOrigen_Internalname);
               A611IncidenciaOrigen = cgiGet( cmbIncidenciaOrigen_Internalname);
               AssignAttri("", false, "A611IncidenciaOrigen", A611IncidenciaOrigen);
               A606IncidenciaCodRef = cgiGet( edtIncidenciaCodRef_Internalname);
               AssignAttri("", false, "A606IncidenciaCodRef", A606IncidenciaCodRef);
               cmbIncidenciaEstado.Name = cmbIncidenciaEstado_Internalname;
               cmbIncidenciaEstado.CurrentValue = cgiGet( cmbIncidenciaEstado_Internalname);
               A608IncidenciaEstado = cgiGet( cmbIncidenciaEstado_Internalname);
               AssignAttri("", false, "A608IncidenciaEstado", A608IncidenciaEstado);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOTIVOID");
                  AnyError = 1;
                  GX_FocusControl = edtMotivoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A604MotivoId = 0;
                  AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
               }
               else
               {
                  A604MotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
               }
               A616MotivoNombre = cgiGet( edtMotivoNombre_Internalname);
               AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
               A610IncidenciaFechaAlta = context.localUtil.CToD( cgiGet( edtIncidenciaFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
               A609IncidenciaFechaActualizacion = context.localUtil.CToD( cgiGet( edtIncidenciaFechaActualizacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
               A615IncidenciaUsrAlta = cgiGet( edtIncidenciaUsrAlta_Internalname);
               AssignAttri("", false, "A615IncidenciaUsrAlta", A615IncidenciaUsrAlta);
               A614IncidenciaUsrActualizacion = cgiGet( edtIncidenciaUsrActualizacion_Internalname);
               AssignAttri("", false, "A614IncidenciaUsrActualizacion", A614IncidenciaUsrActualizacion);
               A613IncidenciaUltLin = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIncidenciaUltLin_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Incidencia");
               A603IncidenciaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtIncidenciaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
               forbiddenHiddens.Add("IncidenciaId", context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"));
               A610IncidenciaFechaAlta = context.localUtil.CToD( cgiGet( edtIncidenciaFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
               forbiddenHiddens.Add("IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
               A609IncidenciaFechaActualizacion = context.localUtil.CToD( cgiGet( edtIncidenciaFechaActualizacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
               forbiddenHiddens.Add("IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
               A615IncidenciaUsrAlta = cgiGet( edtIncidenciaUsrAlta_Internalname);
               AssignAttri("", false, "A615IncidenciaUsrAlta", A615IncidenciaUsrAlta);
               forbiddenHiddens.Add("IncidenciaUsrAlta", StringUtil.RTrim( context.localUtil.Format( A615IncidenciaUsrAlta, "")));
               A614IncidenciaUsrActualizacion = cgiGet( edtIncidenciaUsrActualizacion_Internalname);
               AssignAttri("", false, "A614IncidenciaUsrActualizacion", A614IncidenciaUsrActualizacion);
               forbiddenHiddens.Add("IncidenciaUsrActualizacion", StringUtil.RTrim( context.localUtil.Format( A614IncidenciaUsrActualizacion, "")));
               forbiddenHiddens.Add("Insert_MotivoId", context.localUtil.Format( (decimal)(AV14Insert_MotivoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A603IncidenciaId != Z603IncidenciaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("incidencia:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A603IncidenciaId = (long)(Math.Round(NumberUtil.Val( GetPar( "IncidenciaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
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
                     sMode89 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode89;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound89 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_260( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INCIDENCIAID");
                        AnyError = 1;
                        GX_FocusControl = edtIncidenciaId_Internalname;
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
                           E11262 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12262 ();
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
            E12262 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2689( ) ;
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
            DisableAttributes2689( ) ;
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

      protected void CONFIRM_260( )
      {
         BeforeValidate2689( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2689( ) ;
            }
            else
            {
               CheckExtendedTable2689( ) ;
               CloseExtendedTableCursors2689( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode89 = Gx_mode;
            CONFIRM_2690( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode89;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2690( )
      {
         s613IncidenciaUltLin = O613IncidenciaUltLin;
         AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow2690( ) ;
            if ( ( nRcdExists_90 != 0 ) || ( nIsMod_90 != 0 ) )
            {
               GetKey2690( ) ;
               if ( ( nRcdExists_90 == 0 ) && ( nRcdDeleted_90 == 0 ) )
               {
                  if ( RcdFound90 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2690( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2690( ) ;
                        CloseExtendedTableCursors2690( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O613IncidenciaUltLin = A613IncidenciaUltLin;
                        AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "INCIDENCIADETALLEID_" + sGXsfl_73_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtIncidenciaDetalleId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound90 != 0 )
                  {
                     if ( nRcdDeleted_90 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2690( ) ;
                        Load2690( ) ;
                        BeforeValidate2690( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2690( ) ;
                           O613IncidenciaUltLin = A613IncidenciaUltLin;
                           AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_90 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2690( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2690( ) ;
                              CloseExtendedTableCursors2690( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O613IncidenciaUltLin = A613IncidenciaUltLin;
                              AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_90 == 0 )
                     {
                        GXCCtl = "INCIDENCIADETALLEID_" + sGXsfl_73_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIncidenciaDetalleId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIncidenciaDetalleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A605IncidenciaDetalleId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtIncidenciaDetalleDesc_Internalname, StringUtil.RTrim( A607IncidenciaDetalleDesc)) ;
            ChangePostValue( "ZT_"+"Z605IncidenciaDetalleId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z605IncidenciaDetalleId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z607IncidenciaDetalleDesc_"+sGXsfl_73_idx, StringUtil.RTrim( Z607IncidenciaDetalleDesc)) ;
            ChangePostValue( "nRcdDeleted_90_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_90), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_90_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_90), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_90_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_90), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_90 != 0 )
            {
               ChangePostValue( "INCIDENCIADETALLEID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INCIDENCIADETALLEDESC_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleDesc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O613IncidenciaUltLin = s613IncidenciaUltLin;
         AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption260( )
      {
      }

      protected void E11262( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10IsAuthorized = true;
         AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia_Insert", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia_Update", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia_Delete", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( ! AV10IsAuthorized )
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
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "MotivoId") == 0 )
               {
                  AV14Insert_MotivoId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_MotivoId", StringUtil.LTrimStr( (decimal)(AV14Insert_MotivoId), 18, 0));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
         edtIncidenciaUltLin_Visible = 0;
         AssignProp("", false, edtIncidenciaUltLin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaUltLin_Visible), 5, 0), true);
      }

      protected void E12262( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("incidenciaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2689( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z610IncidenciaFechaAlta = T00265_A610IncidenciaFechaAlta[0];
               Z609IncidenciaFechaActualizacion = T00265_A609IncidenciaFechaActualizacion[0];
               Z611IncidenciaOrigen = T00265_A611IncidenciaOrigen[0];
               Z606IncidenciaCodRef = T00265_A606IncidenciaCodRef[0];
               Z608IncidenciaEstado = T00265_A608IncidenciaEstado[0];
               Z615IncidenciaUsrAlta = T00265_A615IncidenciaUsrAlta[0];
               Z614IncidenciaUsrActualizacion = T00265_A614IncidenciaUsrActualizacion[0];
               Z613IncidenciaUltLin = T00265_A613IncidenciaUltLin[0];
               Z604MotivoId = T00265_A604MotivoId[0];
            }
            else
            {
               Z610IncidenciaFechaAlta = A610IncidenciaFechaAlta;
               Z609IncidenciaFechaActualizacion = A609IncidenciaFechaActualizacion;
               Z611IncidenciaOrigen = A611IncidenciaOrigen;
               Z606IncidenciaCodRef = A606IncidenciaCodRef;
               Z608IncidenciaEstado = A608IncidenciaEstado;
               Z615IncidenciaUsrAlta = A615IncidenciaUsrAlta;
               Z614IncidenciaUsrActualizacion = A614IncidenciaUsrActualizacion;
               Z613IncidenciaUltLin = A613IncidenciaUltLin;
               Z604MotivoId = A604MotivoId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z603IncidenciaId = A603IncidenciaId;
            Z610IncidenciaFechaAlta = A610IncidenciaFechaAlta;
            Z609IncidenciaFechaActualizacion = A609IncidenciaFechaActualizacion;
            Z611IncidenciaOrigen = A611IncidenciaOrigen;
            Z606IncidenciaCodRef = A606IncidenciaCodRef;
            Z608IncidenciaEstado = A608IncidenciaEstado;
            Z615IncidenciaUsrAlta = A615IncidenciaUsrAlta;
            Z614IncidenciaUsrActualizacion = A614IncidenciaUsrActualizacion;
            Z613IncidenciaUltLin = A613IncidenciaUltLin;
            Z604MotivoId = A604MotivoId;
            Z618MotivoTipo = A618MotivoTipo;
            Z616MotivoNombre = A616MotivoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIncidenciaId_Enabled = 0;
         AssignProp("", false, edtIncidenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaId_Enabled), 5, 0), true);
         edtIncidenciaFechaAlta_Enabled = 0;
         AssignProp("", false, edtIncidenciaFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaAlta_Enabled), 5, 0), true);
         edtIncidenciaFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtIncidenciaFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaActualizacion_Enabled), 5, 0), true);
         edtIncidenciaUsrAlta_Enabled = 0;
         AssignProp("", false, edtIncidenciaUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrAlta_Enabled), 5, 0), true);
         edtIncidenciaUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtIncidenciaUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrActualizacion_Enabled), 5, 0), true);
         edtIncidenciaUltLin_Enabled = 0;
         AssignProp("", false, edtIncidenciaUltLin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUltLin_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_604_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx02j0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOID"+"'), id:'"+"MOTIVOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtIncidenciaId_Enabled = 0;
         AssignProp("", false, edtIncidenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaId_Enabled), 5, 0), true);
         edtIncidenciaFechaAlta_Enabled = 0;
         AssignProp("", false, edtIncidenciaFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaAlta_Enabled), 5, 0), true);
         edtIncidenciaFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtIncidenciaFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaActualizacion_Enabled), 5, 0), true);
         edtIncidenciaUsrAlta_Enabled = 0;
         AssignProp("", false, edtIncidenciaUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrAlta_Enabled), 5, 0), true);
         edtIncidenciaUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtIncidenciaUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrActualizacion_Enabled), 5, 0), true);
         edtIncidenciaUltLin_Enabled = 0;
         AssignProp("", false, edtIncidenciaUltLin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUltLin_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV8IncidenciaId) )
         {
            A603IncidenciaId = AV8IncidenciaId;
            AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_MotivoId) )
         {
            edtMotivoId_Enabled = 0;
            AssignProp("", false, edtMotivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoId_Enabled), 5, 0), true);
         }
         else
         {
            edtMotivoId_Enabled = 1;
            AssignProp("", false, edtMotivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A610IncidenciaFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
         }
         if ( IsIns( )  || IsUpd( )  )
         {
            A609IncidenciaFechaActualizacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_MotivoId) )
         {
            A604MotivoId = AV14Insert_MotivoId;
            AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
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
            AV17Pgmname = "Incidencia";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T00266 */
            pr_default.execute(4, new Object[] {A604MotivoId});
            A618MotivoTipo = T00266_A618MotivoTipo[0];
            n618MotivoTipo = T00266_n618MotivoTipo[0];
            A616MotivoNombre = T00266_A616MotivoNombre[0];
            AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
            pr_default.close(4);
         }
      }

      protected void Load2689( )
      {
         /* Using cursor T00267 */
         pr_default.execute(5, new Object[] {A603IncidenciaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound89 = 1;
            A610IncidenciaFechaAlta = T00267_A610IncidenciaFechaAlta[0];
            AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
            A609IncidenciaFechaActualizacion = T00267_A609IncidenciaFechaActualizacion[0];
            AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
            A611IncidenciaOrigen = T00267_A611IncidenciaOrigen[0];
            AssignAttri("", false, "A611IncidenciaOrigen", A611IncidenciaOrigen);
            A606IncidenciaCodRef = T00267_A606IncidenciaCodRef[0];
            AssignAttri("", false, "A606IncidenciaCodRef", A606IncidenciaCodRef);
            A608IncidenciaEstado = T00267_A608IncidenciaEstado[0];
            AssignAttri("", false, "A608IncidenciaEstado", A608IncidenciaEstado);
            A618MotivoTipo = T00267_A618MotivoTipo[0];
            n618MotivoTipo = T00267_n618MotivoTipo[0];
            A616MotivoNombre = T00267_A616MotivoNombre[0];
            AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
            A615IncidenciaUsrAlta = T00267_A615IncidenciaUsrAlta[0];
            AssignAttri("", false, "A615IncidenciaUsrAlta", A615IncidenciaUsrAlta);
            A614IncidenciaUsrActualizacion = T00267_A614IncidenciaUsrActualizacion[0];
            AssignAttri("", false, "A614IncidenciaUsrActualizacion", A614IncidenciaUsrActualizacion);
            A613IncidenciaUltLin = T00267_A613IncidenciaUltLin[0];
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            A604MotivoId = T00267_A604MotivoId[0];
            AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
            ZM2689( -20) ;
         }
         pr_default.close(5);
         OnLoadActions2689( ) ;
      }

      protected void OnLoadActions2689( )
      {
         AV17Pgmname = "Incidencia";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
      }

      protected void CheckExtendedTable2689( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV17Pgmname = "Incidencia";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) || ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) || ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Incidencia Origen", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "INCIDENCIAORIGEN");
            AnyError = 1;
            GX_FocusControl = cmbIncidenciaOrigen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) || ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) || ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Incidencia Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "INCIDENCIAESTADO");
            AnyError = 1;
            GX_FocusControl = cmbIncidenciaEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00266 */
         pr_default.execute(4, new Object[] {A604MotivoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVOID");
            AnyError = 1;
            GX_FocusControl = edtMotivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A618MotivoTipo = T00266_A618MotivoTipo[0];
         n618MotivoTipo = T00266_n618MotivoTipo[0];
         A616MotivoNombre = T00266_A616MotivoNombre[0];
         AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2689( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( long A604MotivoId )
      {
         /* Using cursor T00268 */
         pr_default.execute(6, new Object[] {A604MotivoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVOID");
            AnyError = 1;
            GX_FocusControl = edtMotivoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A618MotivoTipo = T00268_A618MotivoTipo[0];
         n618MotivoTipo = T00268_n618MotivoTipo[0];
         A616MotivoNombre = T00268_A616MotivoNombre[0];
         AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A618MotivoTipo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A616MotivoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2689( )
      {
         /* Using cursor T00269 */
         pr_default.execute(7, new Object[] {A603IncidenciaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound89 = 1;
         }
         else
         {
            RcdFound89 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00265 */
         pr_default.execute(3, new Object[] {A603IncidenciaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2689( 20) ;
            RcdFound89 = 1;
            A603IncidenciaId = T00265_A603IncidenciaId[0];
            AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
            A610IncidenciaFechaAlta = T00265_A610IncidenciaFechaAlta[0];
            AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
            A609IncidenciaFechaActualizacion = T00265_A609IncidenciaFechaActualizacion[0];
            AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
            A611IncidenciaOrigen = T00265_A611IncidenciaOrigen[0];
            AssignAttri("", false, "A611IncidenciaOrigen", A611IncidenciaOrigen);
            A606IncidenciaCodRef = T00265_A606IncidenciaCodRef[0];
            AssignAttri("", false, "A606IncidenciaCodRef", A606IncidenciaCodRef);
            A608IncidenciaEstado = T00265_A608IncidenciaEstado[0];
            AssignAttri("", false, "A608IncidenciaEstado", A608IncidenciaEstado);
            A615IncidenciaUsrAlta = T00265_A615IncidenciaUsrAlta[0];
            AssignAttri("", false, "A615IncidenciaUsrAlta", A615IncidenciaUsrAlta);
            A614IncidenciaUsrActualizacion = T00265_A614IncidenciaUsrActualizacion[0];
            AssignAttri("", false, "A614IncidenciaUsrActualizacion", A614IncidenciaUsrActualizacion);
            A613IncidenciaUltLin = T00265_A613IncidenciaUltLin[0];
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            A604MotivoId = T00265_A604MotivoId[0];
            AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
            O613IncidenciaUltLin = A613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            Z603IncidenciaId = A603IncidenciaId;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2689( ) ;
            if ( AnyError == 1 )
            {
               RcdFound89 = 0;
               InitializeNonKey2689( ) ;
            }
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound89 = 0;
            InitializeNonKey2689( ) ;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2689( ) ;
         if ( RcdFound89 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound89 = 0;
         /* Using cursor T002610 */
         pr_default.execute(8, new Object[] {A603IncidenciaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002610_A603IncidenciaId[0] < A603IncidenciaId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002610_A603IncidenciaId[0] > A603IncidenciaId ) ) )
            {
               A603IncidenciaId = T002610_A603IncidenciaId[0];
               AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
               RcdFound89 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound89 = 0;
         /* Using cursor T002611 */
         pr_default.execute(9, new Object[] {A603IncidenciaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002611_A603IncidenciaId[0] > A603IncidenciaId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002611_A603IncidenciaId[0] < A603IncidenciaId ) ) )
            {
               A603IncidenciaId = T002611_A603IncidenciaId[0];
               AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
               RcdFound89 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2689( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A613IncidenciaUltLin = O613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            GX_FocusControl = cmbIncidenciaOrigen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2689( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound89 == 1 )
            {
               if ( A603IncidenciaId != Z603IncidenciaId )
               {
                  A603IncidenciaId = Z603IncidenciaId;
                  AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INCIDENCIAID");
                  AnyError = 1;
                  GX_FocusControl = edtIncidenciaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A613IncidenciaUltLin = O613IncidenciaUltLin;
                  AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbIncidenciaOrigen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A613IncidenciaUltLin = O613IncidenciaUltLin;
                  AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                  Update2689( ) ;
                  GX_FocusControl = cmbIncidenciaOrigen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A603IncidenciaId != Z603IncidenciaId )
               {
                  /* Insert record */
                  A613IncidenciaUltLin = O613IncidenciaUltLin;
                  AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                  GX_FocusControl = cmbIncidenciaOrigen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2689( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INCIDENCIAID");
                     AnyError = 1;
                     GX_FocusControl = edtIncidenciaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A613IncidenciaUltLin = O613IncidenciaUltLin;
                     AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                     GX_FocusControl = cmbIncidenciaOrigen_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2689( ) ;
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
         if ( A603IncidenciaId != Z603IncidenciaId )
         {
            A603IncidenciaId = Z603IncidenciaId;
            AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INCIDENCIAID");
            AnyError = 1;
            GX_FocusControl = edtIncidenciaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A613IncidenciaUltLin = O613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbIncidenciaOrigen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2689( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00264 */
            pr_default.execute(2, new Object[] {A603IncidenciaId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Incidencia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( DateTimeUtil.ResetTime ( Z610IncidenciaFechaAlta ) != DateTimeUtil.ResetTime ( T00264_A610IncidenciaFechaAlta[0] ) ) || ( DateTimeUtil.ResetTime ( Z609IncidenciaFechaActualizacion ) != DateTimeUtil.ResetTime ( T00264_A609IncidenciaFechaActualizacion[0] ) ) || ( StringUtil.StrCmp(Z611IncidenciaOrigen, T00264_A611IncidenciaOrigen[0]) != 0 ) || ( StringUtil.StrCmp(Z606IncidenciaCodRef, T00264_A606IncidenciaCodRef[0]) != 0 ) || ( StringUtil.StrCmp(Z608IncidenciaEstado, T00264_A608IncidenciaEstado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z615IncidenciaUsrAlta, T00264_A615IncidenciaUsrAlta[0]) != 0 ) || ( StringUtil.StrCmp(Z614IncidenciaUsrActualizacion, T00264_A614IncidenciaUsrActualizacion[0]) != 0 ) || ( Z613IncidenciaUltLin != T00264_A613IncidenciaUltLin[0] ) || ( Z604MotivoId != T00264_A604MotivoId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z610IncidenciaFechaAlta ) != DateTimeUtil.ResetTime ( T00264_A610IncidenciaFechaAlta[0] ) )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z610IncidenciaFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T00264_A610IncidenciaFechaAlta[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z609IncidenciaFechaActualizacion ) != DateTimeUtil.ResetTime ( T00264_A609IncidenciaFechaActualizacion[0] ) )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaFechaActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z609IncidenciaFechaActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T00264_A609IncidenciaFechaActualizacion[0]);
               }
               if ( StringUtil.StrCmp(Z611IncidenciaOrigen, T00264_A611IncidenciaOrigen[0]) != 0 )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z611IncidenciaOrigen);
                  GXUtil.WriteLogRaw("Current: ",T00264_A611IncidenciaOrigen[0]);
               }
               if ( StringUtil.StrCmp(Z606IncidenciaCodRef, T00264_A606IncidenciaCodRef[0]) != 0 )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaCodRef");
                  GXUtil.WriteLogRaw("Old: ",Z606IncidenciaCodRef);
                  GXUtil.WriteLogRaw("Current: ",T00264_A606IncidenciaCodRef[0]);
               }
               if ( StringUtil.StrCmp(Z608IncidenciaEstado, T00264_A608IncidenciaEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaEstado");
                  GXUtil.WriteLogRaw("Old: ",Z608IncidenciaEstado);
                  GXUtil.WriteLogRaw("Current: ",T00264_A608IncidenciaEstado[0]);
               }
               if ( StringUtil.StrCmp(Z615IncidenciaUsrAlta, T00264_A615IncidenciaUsrAlta[0]) != 0 )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z615IncidenciaUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T00264_A615IncidenciaUsrAlta[0]);
               }
               if ( StringUtil.StrCmp(Z614IncidenciaUsrActualizacion, T00264_A614IncidenciaUsrActualizacion[0]) != 0 )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaUsrActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z614IncidenciaUsrActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T00264_A614IncidenciaUsrActualizacion[0]);
               }
               if ( Z613IncidenciaUltLin != T00264_A613IncidenciaUltLin[0] )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaUltLin");
                  GXUtil.WriteLogRaw("Old: ",Z613IncidenciaUltLin);
                  GXUtil.WriteLogRaw("Current: ",T00264_A613IncidenciaUltLin[0]);
               }
               if ( Z604MotivoId != T00264_A604MotivoId[0] )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"MotivoId");
                  GXUtil.WriteLogRaw("Old: ",Z604MotivoId);
                  GXUtil.WriteLogRaw("Current: ",T00264_A604MotivoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Incidencia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2689( )
      {
         BeforeValidate2689( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2689( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2689( 0) ;
            CheckOptimisticConcurrency2689( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2689( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2689( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002612 */
                     pr_default.execute(10, new Object[] {A610IncidenciaFechaAlta, A609IncidenciaFechaActualizacion, A611IncidenciaOrigen, A606IncidenciaCodRef, A608IncidenciaEstado, A615IncidenciaUsrAlta, A614IncidenciaUsrActualizacion, A613IncidenciaUltLin, A604MotivoId});
                     A603IncidenciaId = T002612_A603IncidenciaId[0];
                     AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Incidencia");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2689( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption260( ) ;
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
               Load2689( ) ;
            }
            EndLevel2689( ) ;
         }
         CloseExtendedTableCursors2689( ) ;
      }

      protected void Update2689( )
      {
         BeforeValidate2689( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2689( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2689( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2689( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2689( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002613 */
                     pr_default.execute(11, new Object[] {A610IncidenciaFechaAlta, A609IncidenciaFechaActualizacion, A611IncidenciaOrigen, A606IncidenciaCodRef, A608IncidenciaEstado, A615IncidenciaUsrAlta, A614IncidenciaUsrActualizacion, A613IncidenciaUltLin, A604MotivoId, A603IncidenciaId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Incidencia");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Incidencia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2689( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2689( ) ;
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
            EndLevel2689( ) ;
         }
         CloseExtendedTableCursors2689( ) ;
      }

      protected void DeferredUpdate2689( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2689( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2689( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2689( ) ;
            AfterConfirm2689( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2689( ) ;
               if ( AnyError == 0 )
               {
                  A613IncidenciaUltLin = O613IncidenciaUltLin;
                  AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                  ScanStart2690( ) ;
                  while ( RcdFound90 != 0 )
                  {
                     getByPrimaryKey2690( ) ;
                     Delete2690( ) ;
                     ScanNext2690( ) ;
                     O613IncidenciaUltLin = A613IncidenciaUltLin;
                     AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
                  }
                  ScanEnd2690( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002614 */
                     pr_default.execute(12, new Object[] {A603IncidenciaId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Incidencia");
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
         sMode89 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2689( ) ;
         Gx_mode = sMode89;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2689( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "Incidencia";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T002615 */
            pr_default.execute(13, new Object[] {A604MotivoId});
            A618MotivoTipo = T002615_A618MotivoTipo[0];
            n618MotivoTipo = T002615_n618MotivoTipo[0];
            A616MotivoNombre = T002615_A616MotivoNombre[0];
            AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel2690( )
      {
         s613IncidenciaUltLin = O613IncidenciaUltLin;
         AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow2690( ) ;
            if ( ( nRcdExists_90 != 0 ) || ( nIsMod_90 != 0 ) )
            {
               standaloneNotModal2690( ) ;
               GetKey2690( ) ;
               if ( ( nRcdExists_90 == 0 ) && ( nRcdDeleted_90 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2690( ) ;
               }
               else
               {
                  if ( RcdFound90 != 0 )
                  {
                     if ( ( nRcdDeleted_90 != 0 ) && ( nRcdExists_90 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2690( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_90 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2690( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_90 == 0 )
                     {
                        GXCCtl = "INCIDENCIADETALLEID_" + sGXsfl_73_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIncidenciaDetalleId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O613IncidenciaUltLin = A613IncidenciaUltLin;
               AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
            }
            ChangePostValue( edtIncidenciaDetalleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A605IncidenciaDetalleId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtIncidenciaDetalleDesc_Internalname, StringUtil.RTrim( A607IncidenciaDetalleDesc)) ;
            ChangePostValue( "ZT_"+"Z605IncidenciaDetalleId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z605IncidenciaDetalleId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z607IncidenciaDetalleDesc_"+sGXsfl_73_idx, StringUtil.RTrim( Z607IncidenciaDetalleDesc)) ;
            ChangePostValue( "nRcdDeleted_90_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_90), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_90_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_90), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_90_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_90), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_90 != 0 )
            {
               ChangePostValue( "INCIDENCIADETALLEID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INCIDENCIADETALLEDESC_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleDesc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2690( ) ;
         if ( AnyError != 0 )
         {
            O613IncidenciaUltLin = s613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         }
         nRcdExists_90 = 0;
         nIsMod_90 = 0;
         nRcdDeleted_90 = 0;
      }

      protected void ProcessLevel2689( )
      {
         /* Save parent mode. */
         sMode89 = Gx_mode;
         ProcessNestedLevel2690( ) ;
         if ( AnyError != 0 )
         {
            O613IncidenciaUltLin = s613IncidenciaUltLin;
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode89;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T002616 */
         pr_default.execute(14, new Object[] {A613IncidenciaUltLin, A603IncidenciaId});
         pr_default.close(14);
         pr_default.SmartCacheProvider.SetUpdated("Incidencia");
      }

      protected void EndLevel2689( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete2689( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.CommitDataStores("incidencia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues260( ) ;
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
            pr_default.close(13);
            context.RollbackDataStores("incidencia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2689( )
      {
         /* Scan By routine */
         /* Using cursor T002617 */
         pr_default.execute(15);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound89 = 1;
            A603IncidenciaId = T002617_A603IncidenciaId[0];
            AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2689( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound89 = 1;
            A603IncidenciaId = T002617_A603IncidenciaId[0];
            AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
         }
      }

      protected void ScanEnd2689( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2689( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2689( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2689( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2689( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2689( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2689( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2689( )
      {
         edtIncidenciaId_Enabled = 0;
         AssignProp("", false, edtIncidenciaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaId_Enabled), 5, 0), true);
         cmbIncidenciaOrigen.Enabled = 0;
         AssignProp("", false, cmbIncidenciaOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbIncidenciaOrigen.Enabled), 5, 0), true);
         edtIncidenciaCodRef_Enabled = 0;
         AssignProp("", false, edtIncidenciaCodRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaCodRef_Enabled), 5, 0), true);
         cmbIncidenciaEstado.Enabled = 0;
         AssignProp("", false, cmbIncidenciaEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbIncidenciaEstado.Enabled), 5, 0), true);
         edtMotivoId_Enabled = 0;
         AssignProp("", false, edtMotivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoId_Enabled), 5, 0), true);
         edtMotivoNombre_Enabled = 0;
         AssignProp("", false, edtMotivoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoNombre_Enabled), 5, 0), true);
         edtIncidenciaFechaAlta_Enabled = 0;
         AssignProp("", false, edtIncidenciaFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaAlta_Enabled), 5, 0), true);
         edtIncidenciaFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtIncidenciaFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaActualizacion_Enabled), 5, 0), true);
         edtIncidenciaUsrAlta_Enabled = 0;
         AssignProp("", false, edtIncidenciaUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrAlta_Enabled), 5, 0), true);
         edtIncidenciaUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtIncidenciaUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrActualizacion_Enabled), 5, 0), true);
         edtIncidenciaUltLin_Enabled = 0;
         AssignProp("", false, edtIncidenciaUltLin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUltLin_Enabled), 5, 0), true);
      }

      protected void ZM2690( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z607IncidenciaDetalleDesc = T00263_A607IncidenciaDetalleDesc[0];
            }
            else
            {
               Z607IncidenciaDetalleDesc = A607IncidenciaDetalleDesc;
            }
         }
         if ( GX_JID == -22 )
         {
            Z603IncidenciaId = A603IncidenciaId;
            Z605IncidenciaDetalleId = A605IncidenciaDetalleId;
            Z607IncidenciaDetalleDesc = A607IncidenciaDetalleDesc;
         }
      }

      protected void standaloneNotModal2690( )
      {
         edtIncidenciaUltLin_Enabled = 0;
         AssignProp("", false, edtIncidenciaUltLin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUltLin_Enabled), 5, 0), true);
         edtIncidenciaUltLin_Enabled = 0;
         AssignProp("", false, edtIncidenciaUltLin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaUltLin_Enabled), 5, 0), true);
      }

      protected void standaloneModal2690( )
      {
         if ( IsIns( )  )
         {
            A613IncidenciaUltLin = (short)(O613IncidenciaUltLin+1);
            AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A605IncidenciaDetalleId = A613IncidenciaUltLin;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtIncidenciaDetalleId_Enabled = 0;
            AssignProp("", false, edtIncidenciaDetalleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
         else
         {
            edtIncidenciaDetalleId_Enabled = 1;
            AssignProp("", false, edtIncidenciaDetalleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
      }

      protected void Load2690( )
      {
         /* Using cursor T002618 */
         pr_default.execute(16, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound90 = 1;
            A607IncidenciaDetalleDesc = T002618_A607IncidenciaDetalleDesc[0];
            ZM2690( -22) ;
         }
         pr_default.close(16);
         OnLoadActions2690( ) ;
      }

      protected void OnLoadActions2690( )
      {
      }

      protected void CheckExtendedTable2690( )
      {
         nIsDirty_90 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal2690( ) ;
      }

      protected void CloseExtendedTableCursors2690( )
      {
      }

      protected void enableDisable2690( )
      {
      }

      protected void GetKey2690( )
      {
         /* Using cursor T002619 */
         pr_default.execute(17, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound90 = 1;
         }
         else
         {
            RcdFound90 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey2690( )
      {
         /* Using cursor T00263 */
         pr_default.execute(1, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2690( 22) ;
            RcdFound90 = 1;
            InitializeNonKey2690( ) ;
            A605IncidenciaDetalleId = T00263_A605IncidenciaDetalleId[0];
            A607IncidenciaDetalleDesc = T00263_A607IncidenciaDetalleDesc[0];
            Z603IncidenciaId = A603IncidenciaId;
            Z605IncidenciaDetalleId = A605IncidenciaDetalleId;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2690( ) ;
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound90 = 0;
            InitializeNonKey2690( ) ;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2690( ) ;
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2690( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2690( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00262 */
            pr_default.execute(0, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"IncidenciaDetalle"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z607IncidenciaDetalleDesc, T00262_A607IncidenciaDetalleDesc[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z607IncidenciaDetalleDesc, T00262_A607IncidenciaDetalleDesc[0]) != 0 )
               {
                  GXUtil.WriteLog("incidencia:[seudo value changed for attri]"+"IncidenciaDetalleDesc");
                  GXUtil.WriteLogRaw("Old: ",Z607IncidenciaDetalleDesc);
                  GXUtil.WriteLogRaw("Current: ",T00262_A607IncidenciaDetalleDesc[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"IncidenciaDetalle"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2690( )
      {
         BeforeValidate2690( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2690( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2690( 0) ;
            CheckOptimisticConcurrency2690( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2690( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2690( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002620 */
                     pr_default.execute(18, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId, A607IncidenciaDetalleDesc});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("IncidenciaDetalle");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load2690( ) ;
            }
            EndLevel2690( ) ;
         }
         CloseExtendedTableCursors2690( ) ;
      }

      protected void Update2690( )
      {
         BeforeValidate2690( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2690( ) ;
         }
         if ( ( nIsMod_90 != 0 ) || ( nIsDirty_90 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2690( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2690( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2690( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002621 */
                        pr_default.execute(19, new Object[] {A607IncidenciaDetalleDesc, A603IncidenciaId, A605IncidenciaDetalleId});
                        pr_default.close(19);
                        pr_default.SmartCacheProvider.SetUpdated("IncidenciaDetalle");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"IncidenciaDetalle"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2690( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2690( ) ;
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
               EndLevel2690( ) ;
            }
         }
         CloseExtendedTableCursors2690( ) ;
      }

      protected void DeferredUpdate2690( )
      {
      }

      protected void Delete2690( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2690( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2690( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2690( ) ;
            AfterConfirm2690( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2690( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002622 */
                  pr_default.execute(20, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("IncidenciaDetalle");
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
         sMode90 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2690( ) ;
         Gx_mode = sMode90;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2690( )
      {
         standaloneModal2690( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2690( )
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

      public void ScanStart2690( )
      {
         /* Scan By routine */
         /* Using cursor T002623 */
         pr_default.execute(21, new Object[] {A603IncidenciaId});
         RcdFound90 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound90 = 1;
            A605IncidenciaDetalleId = T002623_A605IncidenciaDetalleId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2690( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound90 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound90 = 1;
            A605IncidenciaDetalleId = T002623_A605IncidenciaDetalleId[0];
         }
      }

      protected void ScanEnd2690( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm2690( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2690( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2690( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2690( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2690( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2690( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2690( )
      {
         edtIncidenciaDetalleId_Enabled = 0;
         AssignProp("", false, edtIncidenciaDetalleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtIncidenciaDetalleDesc_Enabled = 0;
         AssignProp("", false, edtIncidenciaDetalleDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleDesc_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void send_integrity_lvl_hashes2690( )
      {
      }

      protected void send_integrity_lvl_hashes2689( )
      {
      }

      protected void SubsflControlProps_7390( )
      {
         edtIncidenciaDetalleId_Internalname = "INCIDENCIADETALLEID_"+sGXsfl_73_idx;
         edtIncidenciaDetalleDesc_Internalname = "INCIDENCIADETALLEDESC_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_7390( )
      {
         edtIncidenciaDetalleId_Internalname = "INCIDENCIADETALLEID_"+sGXsfl_73_fel_idx;
         edtIncidenciaDetalleDesc_Internalname = "INCIDENCIADETALLEDESC_"+sGXsfl_73_fel_idx;
      }

      protected void AddRow2690( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7390( ) ;
         SendRow2690( ) ;
      }

      protected void SendRow2690( )
      {
         Gridlevel_detalleRow = GXWebRow.GetNew(context);
         if ( subGridlevel_detalle_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_detalle_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_detalle_Class, "") != 0 )
            {
               subGridlevel_detalle_Linesclass = subGridlevel_detalle_Class+"Odd";
            }
         }
         else if ( subGridlevel_detalle_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_detalle_Backstyle = 0;
            subGridlevel_detalle_Backcolor = subGridlevel_detalle_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_detalle_Class, "") != 0 )
            {
               subGridlevel_detalle_Linesclass = subGridlevel_detalle_Class+"Uniform";
            }
         }
         else if ( subGridlevel_detalle_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_detalle_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_detalle_Class, "") != 0 )
            {
               subGridlevel_detalle_Linesclass = subGridlevel_detalle_Class+"Odd";
            }
            subGridlevel_detalle_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_detalle_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_detalle_Backstyle = 1;
            if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
            {
               subGridlevel_detalle_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_detalle_Class, "") != 0 )
               {
                  subGridlevel_detalle_Linesclass = subGridlevel_detalle_Class+"Even";
               }
            }
            else
            {
               subGridlevel_detalle_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_detalle_Class, "") != 0 )
               {
                  subGridlevel_detalle_Linesclass = subGridlevel_detalle_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_90_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridlevel_detalleRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaDetalleId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A605IncidenciaDetalleId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A605IncidenciaDetalleId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaDetalleId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIncidenciaDetalleId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_90_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridlevel_detalleRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaDetalleDesc_Internalname,StringUtil.RTrim( A607IncidenciaDetalleDesc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaDetalleDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtIncidenciaDetalleDesc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_detalleRow);
         send_integrity_lvl_hashes2690( ) ;
         GXCCtl = "Z605IncidenciaDetalleId_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z605IncidenciaDetalleId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z607IncidenciaDetalleDesc_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z607IncidenciaDetalleDesc));
         GXCCtl = "nRcdDeleted_90_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_90), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_90_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_90), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_90_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_90), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_73_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vINCIDENCIAID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8IncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "INCIDENCIADETALLEID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INCIDENCIADETALLEDESC_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleDesc_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_detalleContainer.AddRow(Gridlevel_detalleRow);
      }

      protected void ReadRow2690( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7390( ) ;
         edtIncidenciaDetalleId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INCIDENCIADETALLEID_"+sGXsfl_73_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtIncidenciaDetalleDesc_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INCIDENCIADETALLEDESC_"+sGXsfl_73_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtIncidenciaDetalleId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIncidenciaDetalleId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "INCIDENCIADETALLEID_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIncidenciaDetalleId_Internalname;
            wbErr = true;
            A605IncidenciaDetalleId = 0;
         }
         else
         {
            A605IncidenciaDetalleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtIncidenciaDetalleId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A607IncidenciaDetalleDesc = cgiGet( edtIncidenciaDetalleDesc_Internalname);
         GXCCtl = "Z605IncidenciaDetalleId_" + sGXsfl_73_idx;
         Z605IncidenciaDetalleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z607IncidenciaDetalleDesc_" + sGXsfl_73_idx;
         Z607IncidenciaDetalleDesc = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_90_" + sGXsfl_73_idx;
         nRcdDeleted_90 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_90_" + sGXsfl_73_idx;
         nRcdExists_90 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_90_" + sGXsfl_73_idx;
         nIsMod_90 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtIncidenciaDetalleId_Enabled = edtIncidenciaDetalleId_Enabled;
      }

      protected void ConfirmValues260( )
      {
         nGXsfl_73_idx = 0;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7390( ) ;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_7390( ) ;
            ChangePostValue( "Z605IncidenciaDetalleId_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z605IncidenciaDetalleId_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z605IncidenciaDetalleId_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z607IncidenciaDetalleDesc_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z607IncidenciaDetalleDesc_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z607IncidenciaDetalleDesc_"+sGXsfl_73_idx) ;
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
         GXEncryptionTmp = "incidencia.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV8IncidenciaId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("incidencia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Incidencia");
         forbiddenHiddens.Add("IncidenciaId", context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
         forbiddenHiddens.Add("IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
         forbiddenHiddens.Add("IncidenciaUsrAlta", StringUtil.RTrim( context.localUtil.Format( A615IncidenciaUsrAlta, "")));
         forbiddenHiddens.Add("IncidenciaUsrActualizacion", StringUtil.RTrim( context.localUtil.Format( A614IncidenciaUsrActualizacion, "")));
         forbiddenHiddens.Add("Insert_MotivoId", context.localUtil.Format( (decimal)(AV14Insert_MotivoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("incidencia:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z603IncidenciaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z603IncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z610IncidenciaFechaAlta", context.localUtil.DToC( Z610IncidenciaFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z609IncidenciaFechaActualizacion", context.localUtil.DToC( Z609IncidenciaFechaActualizacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z611IncidenciaOrigen", StringUtil.RTrim( Z611IncidenciaOrigen));
         GxWebStd.gx_hidden_field( context, "Z606IncidenciaCodRef", Z606IncidenciaCodRef);
         GxWebStd.gx_hidden_field( context, "Z608IncidenciaEstado", StringUtil.RTrim( Z608IncidenciaEstado));
         GxWebStd.gx_hidden_field( context, "Z615IncidenciaUsrAlta", StringUtil.RTrim( Z615IncidenciaUsrAlta));
         GxWebStd.gx_hidden_field( context, "Z614IncidenciaUsrActualizacion", StringUtil.RTrim( Z614IncidenciaUsrActualizacion));
         GxWebStd.gx_hidden_field( context, "Z613IncidenciaUltLin", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z613IncidenciaUltLin), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z604MotivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z604MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O613IncidenciaUltLin", StringUtil.LTrim( StringUtil.NToC( (decimal)(O613IncidenciaUltLin), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_73_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N604MotivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A604MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vINCIDENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8IncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCIDENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MOTIVOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MOTIVOTIPO", StringUtil.RTrim( A618MotivoTipo));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "incidencia.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV8IncidenciaId,18,0));
         return formatLink("incidencia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Incidencia" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Incidencia", "") ;
      }

      protected void InitializeNonKey2689( )
      {
         A604MotivoId = 0;
         AssignAttri("", false, "A604MotivoId", StringUtil.LTrimStr( (decimal)(A604MotivoId), 18, 0));
         A610IncidenciaFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
         A611IncidenciaOrigen = "";
         AssignAttri("", false, "A611IncidenciaOrigen", A611IncidenciaOrigen);
         A606IncidenciaCodRef = "";
         AssignAttri("", false, "A606IncidenciaCodRef", A606IncidenciaCodRef);
         A608IncidenciaEstado = "";
         AssignAttri("", false, "A608IncidenciaEstado", A608IncidenciaEstado);
         A618MotivoTipo = "";
         n618MotivoTipo = false;
         AssignAttri("", false, "A618MotivoTipo", A618MotivoTipo);
         A616MotivoNombre = "";
         AssignAttri("", false, "A616MotivoNombre", A616MotivoNombre);
         A615IncidenciaUsrAlta = "";
         AssignAttri("", false, "A615IncidenciaUsrAlta", A615IncidenciaUsrAlta);
         A614IncidenciaUsrActualizacion = "";
         AssignAttri("", false, "A614IncidenciaUsrActualizacion", A614IncidenciaUsrActualizacion);
         A613IncidenciaUltLin = 0;
         AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         O613IncidenciaUltLin = A613IncidenciaUltLin;
         AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
         Z610IncidenciaFechaAlta = DateTime.MinValue;
         Z609IncidenciaFechaActualizacion = DateTime.MinValue;
         Z611IncidenciaOrigen = "";
         Z606IncidenciaCodRef = "";
         Z608IncidenciaEstado = "";
         Z615IncidenciaUsrAlta = "";
         Z614IncidenciaUsrActualizacion = "";
         Z613IncidenciaUltLin = 0;
         Z604MotivoId = 0;
      }

      protected void InitAll2689( )
      {
         A603IncidenciaId = 0;
         AssignAttri("", false, "A603IncidenciaId", StringUtil.LTrimStr( (decimal)(A603IncidenciaId), 18, 0));
         InitializeNonKey2689( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A610IncidenciaFechaAlta = i610IncidenciaFechaAlta;
         AssignAttri("", false, "A610IncidenciaFechaAlta", context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"));
         A609IncidenciaFechaActualizacion = i609IncidenciaFechaActualizacion;
         AssignAttri("", false, "A609IncidenciaFechaActualizacion", context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"));
      }

      protected void InitializeNonKey2690( )
      {
         A607IncidenciaDetalleDesc = "";
         Z607IncidenciaDetalleDesc = "";
      }

      protected void InitAll2690( )
      {
         A605IncidenciaDetalleId = 0;
         InitializeNonKey2690( ) ;
      }

      protected void StandaloneModalInsert2690( )
      {
         A613IncidenciaUltLin = i613IncidenciaUltLin;
         AssignAttri("", false, "A613IncidenciaUltLin", StringUtil.LTrimStr( (decimal)(A613IncidenciaUltLin), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021151499", true, true, false);
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
         context.AddJavascriptSource("incidencia.js", "?202673021151499", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties90( )
      {
         edtIncidenciaDetalleId_Enabled = defedtIncidenciaDetalleId_Enabled;
         AssignProp("", false, edtIncidenciaDetalleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void StartGridControl73( )
      {
         Gridlevel_detalleContainer.AddObjectProperty("GridName", "Gridlevel_detalle");
         Gridlevel_detalleContainer.AddObjectProperty("Header", subGridlevel_detalle_Header);
         Gridlevel_detalleContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_detalleContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_detalleContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_detalleColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detalleColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A605IncidenciaDetalleId), 18, 0, ".", ""))));
         Gridlevel_detalleColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleId_Enabled), 5, 0, ".", "")));
         Gridlevel_detalleContainer.AddColumnProperties(Gridlevel_detalleColumn);
         Gridlevel_detalleColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detalleColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A607IncidenciaDetalleDesc)));
         Gridlevel_detalleColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaDetalleDesc_Enabled), 5, 0, ".", "")));
         Gridlevel_detalleContainer.AddColumnProperties(Gridlevel_detalleColumn);
         Gridlevel_detalleContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Selectedindex), 4, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Allowselection), 1, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Allowhovering), 1, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_detalleContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalle_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtIncidenciaId_Internalname = "INCIDENCIAID";
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN";
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF";
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO";
         edtMotivoId_Internalname = "MOTIVOID";
         edtMotivoNombre_Internalname = "MOTIVONOMBRE";
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA";
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION";
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA";
         edtIncidenciaUsrActualizacion_Internalname = "INCIDENCIAUSRACTUALIZACION";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtIncidenciaDetalleId_Internalname = "INCIDENCIADETALLEID";
         edtIncidenciaDetalleDesc_Internalname = "INCIDENCIADETALLEDESC";
         divTableleaflevel_detalle_Internalname = "TABLELEAFLEVEL_DETALLE";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtIncidenciaUltLin_Internalname = "INCIDENCIAULTLIN";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_604_Internalname = "PROMPT_604";
         subGridlevel_detalle_Internalname = "GRIDLEVEL_DETALLE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_detalle_Allowcollapsing = 0;
         subGridlevel_detalle_Allowselection = 0;
         subGridlevel_detalle_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Incidencia", "");
         edtIncidenciaDetalleDesc_Jsonclick = "";
         edtIncidenciaDetalleId_Jsonclick = "";
         subGridlevel_detalle_Class = "WorkWith";
         subGridlevel_detalle_Backcolorstyle = 0;
         edtIncidenciaDetalleDesc_Enabled = 1;
         edtIncidenciaDetalleId_Enabled = 1;
         edtIncidenciaUltLin_Jsonclick = "";
         edtIncidenciaUltLin_Enabled = 0;
         edtIncidenciaUltLin_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtIncidenciaUsrActualizacion_Jsonclick = "";
         edtIncidenciaUsrActualizacion_Enabled = 0;
         edtIncidenciaUsrAlta_Jsonclick = "";
         edtIncidenciaUsrAlta_Enabled = 0;
         edtIncidenciaFechaActualizacion_Jsonclick = "";
         edtIncidenciaFechaActualizacion_Enabled = 0;
         edtIncidenciaFechaAlta_Jsonclick = "";
         edtIncidenciaFechaAlta_Enabled = 0;
         edtMotivoNombre_Jsonclick = "";
         edtMotivoNombre_Enabled = 0;
         imgprompt_604_Visible = 1;
         imgprompt_604_Link = "";
         edtMotivoId_Jsonclick = "";
         edtMotivoId_Enabled = 1;
         cmbIncidenciaEstado_Jsonclick = "";
         cmbIncidenciaEstado.Enabled = 1;
         edtIncidenciaCodRef_Jsonclick = "";
         edtIncidenciaCodRef_Enabled = 1;
         cmbIncidenciaOrigen_Jsonclick = "";
         cmbIncidenciaOrigen.Enabled = 1;
         edtIncidenciaId_Jsonclick = "";
         edtIncidenciaId_Enabled = 0;
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

      protected void gxnrGridlevel_detalle_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7390( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2690( ) ;
            standaloneModal2690( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2690( ) ;
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_7390( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_detalleContainer)) ;
         /* End function gxnrGridlevel_detalle_newrow */
      }

      protected void init_web_controls( )
      {
         cmbIncidenciaOrigen.Name = "INCIDENCIAORIGEN";
         cmbIncidenciaOrigen.WebTags = "";
         cmbIncidenciaOrigen.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
         cmbIncidenciaOrigen.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
         cmbIncidenciaOrigen.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
         if ( cmbIncidenciaOrigen.ItemCount > 0 )
         {
            A611IncidenciaOrigen = cmbIncidenciaOrigen.getValidValue(A611IncidenciaOrigen);
            AssignAttri("", false, "A611IncidenciaOrigen", A611IncidenciaOrigen);
         }
         cmbIncidenciaEstado.Name = "INCIDENCIAESTADO";
         cmbIncidenciaEstado.WebTags = "";
         cmbIncidenciaEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbIncidenciaEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbIncidenciaEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbIncidenciaEstado.ItemCount > 0 )
         {
            A608IncidenciaEstado = cmbIncidenciaEstado.getValidValue(A608IncidenciaEstado);
            AssignAttri("", false, "A608IncidenciaEstado", A608IncidenciaEstado);
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

      public void Valid_Motivoid( )
      {
         n618MotivoTipo = false;
         /* Using cursor T002615 */
         pr_default.execute(13, new Object[] {A604MotivoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVOID");
            AnyError = 1;
            GX_FocusControl = edtMotivoId_Internalname;
         }
         A618MotivoTipo = T002615_A618MotivoTipo[0];
         n618MotivoTipo = T002615_n618MotivoTipo[0];
         A616MotivoNombre = T002615_A616MotivoNombre[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A618MotivoTipo", StringUtil.RTrim( A618MotivoTipo));
         AssignAttri("", false, "A616MotivoNombre", StringUtil.RTrim( A616MotivoNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8IncidenciaId',fld:'vINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV8IncidenciaId',fld:'vINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A603IncidenciaId',fld:'INCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A610IncidenciaFechaAlta',fld:'INCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'A609IncidenciaFechaActualizacion',fld:'INCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'A615IncidenciaUsrAlta',fld:'INCIDENCIAUSRALTA',pic:'',type:'char'},{av:'A614IncidenciaUsrActualizacion',fld:'INCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV14Insert_MotivoId',fld:'vINSERT_MOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12262',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAID","{handler:'Valid_Incidenciaid',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAID",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAORIGEN","{handler:'Valid_Incidenciaorigen',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAORIGEN",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAESTADO","{handler:'Valid_Incidenciaestado',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAESTADO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOID","{handler:'Valid_Motivoid',iparms:[{av:'A604MotivoId',fld:'MOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A618MotivoTipo',fld:'MOTIVOTIPO',pic:'',type:'char'},{av:'A616MotivoNombre',fld:'MOTIVONOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_MOTIVOID",",oparms:[{av:'A618MotivoTipo',fld:'MOTIVOTIPO',pic:'',type:'char'},{av:'A616MotivoNombre',fld:'MOTIVONOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_INCIDENCIAULTLIN","{handler:'Valid_Incidenciaultlin',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAULTLIN",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIADETALLEID","{handler:'Valid_Incidenciadetalleid',iparms:[]");
         setEventMetadata("VALID_INCIDENCIADETALLEID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Incidenciadetalledesc',iparms:[]");
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
         pr_default.close(3);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z610IncidenciaFechaAlta = DateTime.MinValue;
         Z609IncidenciaFechaActualizacion = DateTime.MinValue;
         Z611IncidenciaOrigen = "";
         Z606IncidenciaCodRef = "";
         Z608IncidenciaEstado = "";
         Z615IncidenciaUsrAlta = "";
         Z614IncidenciaUsrActualizacion = "";
         Z607IncidenciaDetalleDesc = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A611IncidenciaOrigen = "";
         A608IncidenciaEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A606IncidenciaCodRef = "";
         imgprompt_604_gximage = "";
         sImgUrl = "";
         A616MotivoNombre = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         A615IncidenciaUsrAlta = "";
         A614IncidenciaUsrActualizacion = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_detalleContainer = new GXWebGrid( context);
         sMode90 = "";
         sStyleString = "";
         A618MotivoTipo = "";
         AV17Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode89 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A607IncidenciaDetalleDesc = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z618MotivoTipo = "";
         Z616MotivoNombre = "";
         T00266_A618MotivoTipo = new string[] {""} ;
         T00266_n618MotivoTipo = new bool[] {false} ;
         T00266_A616MotivoNombre = new string[] {""} ;
         T00267_A603IncidenciaId = new long[1] ;
         T00267_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00267_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T00267_A611IncidenciaOrigen = new string[] {""} ;
         T00267_A606IncidenciaCodRef = new string[] {""} ;
         T00267_A608IncidenciaEstado = new string[] {""} ;
         T00267_A618MotivoTipo = new string[] {""} ;
         T00267_n618MotivoTipo = new bool[] {false} ;
         T00267_A616MotivoNombre = new string[] {""} ;
         T00267_A615IncidenciaUsrAlta = new string[] {""} ;
         T00267_A614IncidenciaUsrActualizacion = new string[] {""} ;
         T00267_A613IncidenciaUltLin = new short[1] ;
         T00267_A604MotivoId = new long[1] ;
         T00268_A618MotivoTipo = new string[] {""} ;
         T00268_n618MotivoTipo = new bool[] {false} ;
         T00268_A616MotivoNombre = new string[] {""} ;
         T00269_A603IncidenciaId = new long[1] ;
         T00265_A603IncidenciaId = new long[1] ;
         T00265_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00265_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T00265_A611IncidenciaOrigen = new string[] {""} ;
         T00265_A606IncidenciaCodRef = new string[] {""} ;
         T00265_A608IncidenciaEstado = new string[] {""} ;
         T00265_A615IncidenciaUsrAlta = new string[] {""} ;
         T00265_A614IncidenciaUsrActualizacion = new string[] {""} ;
         T00265_A613IncidenciaUltLin = new short[1] ;
         T00265_A604MotivoId = new long[1] ;
         T002610_A603IncidenciaId = new long[1] ;
         T002611_A603IncidenciaId = new long[1] ;
         T00264_A603IncidenciaId = new long[1] ;
         T00264_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00264_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T00264_A611IncidenciaOrigen = new string[] {""} ;
         T00264_A606IncidenciaCodRef = new string[] {""} ;
         T00264_A608IncidenciaEstado = new string[] {""} ;
         T00264_A615IncidenciaUsrAlta = new string[] {""} ;
         T00264_A614IncidenciaUsrActualizacion = new string[] {""} ;
         T00264_A613IncidenciaUltLin = new short[1] ;
         T00264_A604MotivoId = new long[1] ;
         T002612_A603IncidenciaId = new long[1] ;
         T002615_A618MotivoTipo = new string[] {""} ;
         T002615_n618MotivoTipo = new bool[] {false} ;
         T002615_A616MotivoNombre = new string[] {""} ;
         T002617_A603IncidenciaId = new long[1] ;
         T002618_A603IncidenciaId = new long[1] ;
         T002618_A605IncidenciaDetalleId = new long[1] ;
         T002618_A607IncidenciaDetalleDesc = new string[] {""} ;
         T002619_A603IncidenciaId = new long[1] ;
         T002619_A605IncidenciaDetalleId = new long[1] ;
         T00263_A603IncidenciaId = new long[1] ;
         T00263_A605IncidenciaDetalleId = new long[1] ;
         T00263_A607IncidenciaDetalleDesc = new string[] {""} ;
         T00262_A603IncidenciaId = new long[1] ;
         T00262_A605IncidenciaDetalleId = new long[1] ;
         T00262_A607IncidenciaDetalleDesc = new string[] {""} ;
         T002623_A603IncidenciaId = new long[1] ;
         T002623_A605IncidenciaDetalleId = new long[1] ;
         Gridlevel_detalleRow = new GXWebRow();
         subGridlevel_detalle_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i610IncidenciaFechaAlta = DateTime.MinValue;
         i609IncidenciaFechaActualizacion = DateTime.MinValue;
         Gridlevel_detalleColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.incidencia__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidencia__default(),
            new Object[][] {
                new Object[] {
               T00262_A603IncidenciaId, T00262_A605IncidenciaDetalleId, T00262_A607IncidenciaDetalleDesc
               }
               , new Object[] {
               T00263_A603IncidenciaId, T00263_A605IncidenciaDetalleId, T00263_A607IncidenciaDetalleDesc
               }
               , new Object[] {
               T00264_A603IncidenciaId, T00264_A610IncidenciaFechaAlta, T00264_A609IncidenciaFechaActualizacion, T00264_A611IncidenciaOrigen, T00264_A606IncidenciaCodRef, T00264_A608IncidenciaEstado, T00264_A615IncidenciaUsrAlta, T00264_A614IncidenciaUsrActualizacion, T00264_A613IncidenciaUltLin, T00264_A604MotivoId
               }
               , new Object[] {
               T00265_A603IncidenciaId, T00265_A610IncidenciaFechaAlta, T00265_A609IncidenciaFechaActualizacion, T00265_A611IncidenciaOrigen, T00265_A606IncidenciaCodRef, T00265_A608IncidenciaEstado, T00265_A615IncidenciaUsrAlta, T00265_A614IncidenciaUsrActualizacion, T00265_A613IncidenciaUltLin, T00265_A604MotivoId
               }
               , new Object[] {
               T00266_A618MotivoTipo, T00266_n618MotivoTipo, T00266_A616MotivoNombre
               }
               , new Object[] {
               T00267_A603IncidenciaId, T00267_A610IncidenciaFechaAlta, T00267_A609IncidenciaFechaActualizacion, T00267_A611IncidenciaOrigen, T00267_A606IncidenciaCodRef, T00267_A608IncidenciaEstado, T00267_A618MotivoTipo, T00267_n618MotivoTipo, T00267_A616MotivoNombre, T00267_A615IncidenciaUsrAlta,
               T00267_A614IncidenciaUsrActualizacion, T00267_A613IncidenciaUltLin, T00267_A604MotivoId
               }
               , new Object[] {
               T00268_A618MotivoTipo, T00268_n618MotivoTipo, T00268_A616MotivoNombre
               }
               , new Object[] {
               T00269_A603IncidenciaId
               }
               , new Object[] {
               T002610_A603IncidenciaId
               }
               , new Object[] {
               T002611_A603IncidenciaId
               }
               , new Object[] {
               T002612_A603IncidenciaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002615_A618MotivoTipo, T002615_n618MotivoTipo, T002615_A616MotivoNombre
               }
               , new Object[] {
               }
               , new Object[] {
               T002617_A603IncidenciaId
               }
               , new Object[] {
               T002618_A603IncidenciaId, T002618_A605IncidenciaDetalleId, T002618_A607IncidenciaDetalleDesc
               }
               , new Object[] {
               T002619_A603IncidenciaId, T002619_A605IncidenciaDetalleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002623_A603IncidenciaId, T002623_A605IncidenciaDetalleId
               }
            }
         );
         AV17Pgmname = "Incidencia";
      }

      private short Z613IncidenciaUltLin ;
      private short O613IncidenciaUltLin ;
      private short nRcdDeleted_90 ;
      private short nRcdExists_90 ;
      private short nIsMod_90 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A613IncidenciaUltLin ;
      private short Gx_BScreen ;
      private short nBlankRcdCount90 ;
      private short RcdFound90 ;
      private short B613IncidenciaUltLin ;
      private short nBlankRcdUsr90 ;
      private short RcdFound89 ;
      private short s613IncidenciaUltLin ;
      private short nIsDirty_90 ;
      private short subGridlevel_detalle_Backcolorstyle ;
      private short subGridlevel_detalle_Backstyle ;
      private short gxajaxcallmode ;
      private short i613IncidenciaUltLin ;
      private short subGridlevel_detalle_Allowselection ;
      private short subGridlevel_detalle_Allowhovering ;
      private short subGridlevel_detalle_Allowcollapsing ;
      private short subGridlevel_detalle_Collapsed ;
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int trnEnded ;
      private int edtIncidenciaId_Enabled ;
      private int edtIncidenciaCodRef_Enabled ;
      private int edtMotivoId_Enabled ;
      private int imgprompt_604_Visible ;
      private int edtMotivoNombre_Enabled ;
      private int edtIncidenciaFechaAlta_Enabled ;
      private int edtIncidenciaFechaActualizacion_Enabled ;
      private int edtIncidenciaUsrAlta_Enabled ;
      private int edtIncidenciaUsrActualizacion_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtIncidenciaUltLin_Enabled ;
      private int edtIncidenciaUltLin_Visible ;
      private int edtIncidenciaDetalleId_Enabled ;
      private int edtIncidenciaDetalleDesc_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV18GXV1 ;
      private int subGridlevel_detalle_Backcolor ;
      private int subGridlevel_detalle_Allbackcolor ;
      private int defedtIncidenciaDetalleId_Enabled ;
      private int idxLst ;
      private int subGridlevel_detalle_Selectedindex ;
      private int subGridlevel_detalle_Selectioncolor ;
      private int subGridlevel_detalle_Hoveringcolor ;
      private long wcpOAV8IncidenciaId ;
      private long Z603IncidenciaId ;
      private long Z604MotivoId ;
      private long N604MotivoId ;
      private long Z605IncidenciaDetalleId ;
      private long A604MotivoId ;
      private long AV8IncidenciaId ;
      private long A603IncidenciaId ;
      private long AV14Insert_MotivoId ;
      private long GRIDLEVEL_DETALLE_nFirstRecordOnPage ;
      private long A605IncidenciaDetalleId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z611IncidenciaOrigen ;
      private string Z608IncidenciaEstado ;
      private string Z615IncidenciaUsrAlta ;
      private string Z614IncidenciaUsrActualizacion ;
      private string Z607IncidenciaDetalleDesc ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbIncidenciaOrigen_Internalname ;
      private string sGXsfl_73_idx="0001" ;
      private string A611IncidenciaOrigen ;
      private string A608IncidenciaEstado ;
      private string cmbIncidenciaEstado_Internalname ;
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
      private string edtIncidenciaId_Internalname ;
      private string TempTags ;
      private string edtIncidenciaId_Jsonclick ;
      private string cmbIncidenciaOrigen_Jsonclick ;
      private string edtIncidenciaCodRef_Internalname ;
      private string edtIncidenciaCodRef_Jsonclick ;
      private string cmbIncidenciaEstado_Jsonclick ;
      private string edtMotivoId_Internalname ;
      private string edtMotivoId_Jsonclick ;
      private string imgprompt_604_gximage ;
      private string sImgUrl ;
      private string imgprompt_604_Internalname ;
      private string imgprompt_604_Link ;
      private string edtMotivoNombre_Internalname ;
      private string A616MotivoNombre ;
      private string edtMotivoNombre_Jsonclick ;
      private string edtIncidenciaFechaAlta_Internalname ;
      private string edtIncidenciaFechaAlta_Jsonclick ;
      private string edtIncidenciaFechaActualizacion_Internalname ;
      private string edtIncidenciaFechaActualizacion_Jsonclick ;
      private string edtIncidenciaUsrAlta_Internalname ;
      private string A615IncidenciaUsrAlta ;
      private string edtIncidenciaUsrAlta_Jsonclick ;
      private string edtIncidenciaUsrActualizacion_Internalname ;
      private string A614IncidenciaUsrActualizacion ;
      private string edtIncidenciaUsrActualizacion_Jsonclick ;
      private string divTableleaflevel_detalle_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtIncidenciaUltLin_Internalname ;
      private string edtIncidenciaUltLin_Jsonclick ;
      private string sMode90 ;
      private string edtIncidenciaDetalleId_Internalname ;
      private string edtIncidenciaDetalleDesc_Internalname ;
      private string sStyleString ;
      private string subGridlevel_detalle_Internalname ;
      private string A618MotivoTipo ;
      private string AV17Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode89 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A607IncidenciaDetalleDesc ;
      private string GXEncryptionTmp ;
      private string Z618MotivoTipo ;
      private string Z616MotivoNombre ;
      private string sGXsfl_73_fel_idx="0001" ;
      private string subGridlevel_detalle_Class ;
      private string subGridlevel_detalle_Linesclass ;
      private string ROClassString ;
      private string edtIncidenciaDetalleId_Jsonclick ;
      private string edtIncidenciaDetalleDesc_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_detalle_Header ;
      private DateTime Z610IncidenciaFechaAlta ;
      private DateTime Z609IncidenciaFechaActualizacion ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private DateTime i610IncidenciaFechaAlta ;
      private DateTime i609IncidenciaFechaActualizacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool n618MotivoTipo ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string Z606IncidenciaCodRef ;
      private string A606IncidenciaCodRef ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_detalleContainer ;
      private GXWebRow Gridlevel_detalleRow ;
      private GXWebColumn Gridlevel_detalleColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbIncidenciaOrigen ;
      private GXCombobox cmbIncidenciaEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00266_A618MotivoTipo ;
      private bool[] T00266_n618MotivoTipo ;
      private string[] T00266_A616MotivoNombre ;
      private long[] T00267_A603IncidenciaId ;
      private DateTime[] T00267_A610IncidenciaFechaAlta ;
      private DateTime[] T00267_A609IncidenciaFechaActualizacion ;
      private string[] T00267_A611IncidenciaOrigen ;
      private string[] T00267_A606IncidenciaCodRef ;
      private string[] T00267_A608IncidenciaEstado ;
      private string[] T00267_A618MotivoTipo ;
      private bool[] T00267_n618MotivoTipo ;
      private string[] T00267_A616MotivoNombre ;
      private string[] T00267_A615IncidenciaUsrAlta ;
      private string[] T00267_A614IncidenciaUsrActualizacion ;
      private short[] T00267_A613IncidenciaUltLin ;
      private long[] T00267_A604MotivoId ;
      private string[] T00268_A618MotivoTipo ;
      private bool[] T00268_n618MotivoTipo ;
      private string[] T00268_A616MotivoNombre ;
      private long[] T00269_A603IncidenciaId ;
      private long[] T00265_A603IncidenciaId ;
      private DateTime[] T00265_A610IncidenciaFechaAlta ;
      private DateTime[] T00265_A609IncidenciaFechaActualizacion ;
      private string[] T00265_A611IncidenciaOrigen ;
      private string[] T00265_A606IncidenciaCodRef ;
      private string[] T00265_A608IncidenciaEstado ;
      private string[] T00265_A615IncidenciaUsrAlta ;
      private string[] T00265_A614IncidenciaUsrActualizacion ;
      private short[] T00265_A613IncidenciaUltLin ;
      private long[] T00265_A604MotivoId ;
      private long[] T002610_A603IncidenciaId ;
      private long[] T002611_A603IncidenciaId ;
      private long[] T00264_A603IncidenciaId ;
      private DateTime[] T00264_A610IncidenciaFechaAlta ;
      private DateTime[] T00264_A609IncidenciaFechaActualizacion ;
      private string[] T00264_A611IncidenciaOrigen ;
      private string[] T00264_A606IncidenciaCodRef ;
      private string[] T00264_A608IncidenciaEstado ;
      private string[] T00264_A615IncidenciaUsrAlta ;
      private string[] T00264_A614IncidenciaUsrActualizacion ;
      private short[] T00264_A613IncidenciaUltLin ;
      private long[] T00264_A604MotivoId ;
      private long[] T002612_A603IncidenciaId ;
      private string[] T002615_A618MotivoTipo ;
      private bool[] T002615_n618MotivoTipo ;
      private string[] T002615_A616MotivoNombre ;
      private long[] T002617_A603IncidenciaId ;
      private long[] T002618_A603IncidenciaId ;
      private long[] T002618_A605IncidenciaDetalleId ;
      private string[] T002618_A607IncidenciaDetalleDesc ;
      private long[] T002619_A603IncidenciaId ;
      private long[] T002619_A605IncidenciaDetalleId ;
      private long[] T00263_A603IncidenciaId ;
      private long[] T00263_A605IncidenciaDetalleId ;
      private string[] T00263_A607IncidenciaDetalleDesc ;
      private long[] T00262_A603IncidenciaId ;
      private long[] T00262_A605IncidenciaDetalleId ;
      private string[] T00262_A607IncidenciaDetalleDesc ;
      private long[] T002623_A603IncidenciaId ;
      private long[] T002623_A605IncidenciaDetalleId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class incidencia__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class incidencia__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00262;
        prmT00262 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0)
        };
        Object[] prmT00263;
        prmT00263 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0)
        };
        Object[] prmT00264;
        prmT00264 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT00265;
        prmT00265 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT00266;
        prmT00266 = new Object[] {
        new ParDef("@MotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT00267;
        prmT00267 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT00268;
        prmT00268 = new Object[] {
        new ParDef("@MotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT00269;
        prmT00269 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT002610;
        prmT002610 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT002611;
        prmT002611 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT002612;
        prmT002612 = new Object[] {
        new ParDef("@IncidenciaFechaAlta",GXType.Date,8,0) ,
        new ParDef("@IncidenciaFechaActualizacion",GXType.Date,8,0) ,
        new ParDef("@IncidenciaOrigen",GXType.NChar,3,0) ,
        new ParDef("@IncidenciaCodRef",GXType.NVarChar,40,0) ,
        new ParDef("@IncidenciaEstado",GXType.NChar,3,0) ,
        new ParDef("@IncidenciaUsrAlta",GXType.NChar,20,0) ,
        new ParDef("@IncidenciaUsrActualizacion",GXType.NChar,20,0) ,
        new ParDef("@IncidenciaUltLin",GXType.Int16,4,0) ,
        new ParDef("@MotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT002613;
        prmT002613 = new Object[] {
        new ParDef("@IncidenciaFechaAlta",GXType.Date,8,0) ,
        new ParDef("@IncidenciaFechaActualizacion",GXType.Date,8,0) ,
        new ParDef("@IncidenciaOrigen",GXType.NChar,3,0) ,
        new ParDef("@IncidenciaCodRef",GXType.NVarChar,40,0) ,
        new ParDef("@IncidenciaEstado",GXType.NChar,3,0) ,
        new ParDef("@IncidenciaUsrAlta",GXType.NChar,20,0) ,
        new ParDef("@IncidenciaUsrActualizacion",GXType.NChar,20,0) ,
        new ParDef("@IncidenciaUltLin",GXType.Int16,4,0) ,
        new ParDef("@MotivoId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT002614;
        prmT002614 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT002615;
        prmT002615 = new Object[] {
        new ParDef("@MotivoId",GXType.Decimal,18,0)
        };
        Object[] prmT002616;
        prmT002616 = new Object[] {
        new ParDef("@IncidenciaUltLin",GXType.Int16,4,0) ,
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        Object[] prmT002617;
        prmT002617 = new Object[] {
        };
        Object[] prmT002618;
        prmT002618 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0)
        };
        Object[] prmT002619;
        prmT002619 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0)
        };
        Object[] prmT002620;
        prmT002620 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleDesc",GXType.NChar,250,0)
        };
        Object[] prmT002621;
        prmT002621 = new Object[] {
        new ParDef("@IncidenciaDetalleDesc",GXType.NChar,250,0) ,
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0)
        };
        Object[] prmT002622;
        prmT002622 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
        new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0)
        };
        Object[] prmT002623;
        prmT002623 = new Object[] {
        new ParDef("@IncidenciaId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00262", "SELECT [IncidenciaId], [IncidenciaDetalleId], [IncidenciaDetalleDesc] FROM [IncidenciaDetalle] WITH (UPDLOCK) WHERE [IncidenciaId] = @IncidenciaId AND [IncidenciaDetalleId] = @IncidenciaDetalleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00262,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00263", "SELECT [IncidenciaId], [IncidenciaDetalleId], [IncidenciaDetalleDesc] FROM [IncidenciaDetalle] WHERE [IncidenciaId] = @IncidenciaId AND [IncidenciaDetalleId] = @IncidenciaDetalleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00263,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00264", "SELECT [IncidenciaId], [IncidenciaFechaAlta], [IncidenciaFechaActualizacion], [IncidenciaOrigen], [IncidenciaCodRef], [IncidenciaEstado], [IncidenciaUsrAlta], [IncidenciaUsrActualizacion], [IncidenciaUltLin], [MotivoId] FROM [Incidencia] WITH (UPDLOCK) WHERE [IncidenciaId] = @IncidenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00264,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00265", "SELECT [IncidenciaId], [IncidenciaFechaAlta], [IncidenciaFechaActualizacion], [IncidenciaOrigen], [IncidenciaCodRef], [IncidenciaEstado], [IncidenciaUsrAlta], [IncidenciaUsrActualizacion], [IncidenciaUltLin], [MotivoId] FROM [Incidencia] WHERE [IncidenciaId] = @IncidenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00265,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00266", "SELECT [MotivoTipo], [MotivoNombre] FROM [Motivo] WHERE [MotivoId] = @MotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00266,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00267", "SELECT TM1.[IncidenciaId], TM1.[IncidenciaFechaAlta], TM1.[IncidenciaFechaActualizacion], TM1.[IncidenciaOrigen], TM1.[IncidenciaCodRef], TM1.[IncidenciaEstado], T2.[MotivoTipo], T2.[MotivoNombre], TM1.[IncidenciaUsrAlta], TM1.[IncidenciaUsrActualizacion], TM1.[IncidenciaUltLin], TM1.[MotivoId] FROM ([Incidencia] TM1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = TM1.[MotivoId]) WHERE TM1.[IncidenciaId] = @IncidenciaId ORDER BY TM1.[IncidenciaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00267,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00268", "SELECT [MotivoTipo], [MotivoNombre] FROM [Motivo] WHERE [MotivoId] = @MotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00268,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00269", "SELECT [IncidenciaId] FROM [Incidencia] WHERE [IncidenciaId] = @IncidenciaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00269,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002610", "SELECT TOP 1 [IncidenciaId] FROM [Incidencia] WHERE ( [IncidenciaId] > @IncidenciaId) ORDER BY [IncidenciaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002610,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002611", "SELECT TOP 1 [IncidenciaId] FROM [Incidencia] WHERE ( [IncidenciaId] < @IncidenciaId) ORDER BY [IncidenciaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002612", "INSERT INTO [Incidencia]([IncidenciaFechaAlta], [IncidenciaFechaActualizacion], [IncidenciaOrigen], [IncidenciaCodRef], [IncidenciaEstado], [IncidenciaUsrAlta], [IncidenciaUsrActualizacion], [IncidenciaUltLin], [MotivoId]) VALUES(@IncidenciaFechaAlta, @IncidenciaFechaActualizacion, @IncidenciaOrigen, @IncidenciaCodRef, @IncidenciaEstado, @IncidenciaUsrAlta, @IncidenciaUsrActualizacion, @IncidenciaUltLin, @MotivoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002613", "UPDATE [Incidencia] SET [IncidenciaFechaAlta]=@IncidenciaFechaAlta, [IncidenciaFechaActualizacion]=@IncidenciaFechaActualizacion, [IncidenciaOrigen]=@IncidenciaOrigen, [IncidenciaCodRef]=@IncidenciaCodRef, [IncidenciaEstado]=@IncidenciaEstado, [IncidenciaUsrAlta]=@IncidenciaUsrAlta, [IncidenciaUsrActualizacion]=@IncidenciaUsrActualizacion, [IncidenciaUltLin]=@IncidenciaUltLin, [MotivoId]=@MotivoId  WHERE [IncidenciaId] = @IncidenciaId", GxErrorMask.GX_NOMASK,prmT002613)
           ,new CursorDef("T002614", "DELETE FROM [Incidencia]  WHERE [IncidenciaId] = @IncidenciaId", GxErrorMask.GX_NOMASK,prmT002614)
           ,new CursorDef("T002615", "SELECT [MotivoTipo], [MotivoNombre] FROM [Motivo] WHERE [MotivoId] = @MotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002615,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002616", "UPDATE [Incidencia] SET [IncidenciaUltLin]=@IncidenciaUltLin  WHERE [IncidenciaId] = @IncidenciaId", GxErrorMask.GX_NOMASK,prmT002616)
           ,new CursorDef("T002617", "SELECT [IncidenciaId] FROM [Incidencia] ORDER BY [IncidenciaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002617,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002618", "SELECT [IncidenciaId], [IncidenciaDetalleId], [IncidenciaDetalleDesc] FROM [IncidenciaDetalle] WHERE [IncidenciaId] = @IncidenciaId and [IncidenciaDetalleId] = @IncidenciaDetalleId ORDER BY [IncidenciaId], [IncidenciaDetalleId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002618,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002619", "SELECT [IncidenciaId], [IncidenciaDetalleId] FROM [IncidenciaDetalle] WHERE [IncidenciaId] = @IncidenciaId AND [IncidenciaDetalleId] = @IncidenciaDetalleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002619,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002620", "INSERT INTO [IncidenciaDetalle]([IncidenciaId], [IncidenciaDetalleId], [IncidenciaDetalleDesc]) VALUES(@IncidenciaId, @IncidenciaDetalleId, @IncidenciaDetalleDesc)", GxErrorMask.GX_NOMASK,prmT002620)
           ,new CursorDef("T002621", "UPDATE [IncidenciaDetalle] SET [IncidenciaDetalleDesc]=@IncidenciaDetalleDesc  WHERE [IncidenciaId] = @IncidenciaId AND [IncidenciaDetalleId] = @IncidenciaDetalleId", GxErrorMask.GX_NOMASK,prmT002621)
           ,new CursorDef("T002622", "DELETE FROM [IncidenciaDetalle]  WHERE [IncidenciaId] = @IncidenciaId AND [IncidenciaDetalleId] = @IncidenciaDetalleId", GxErrorMask.GX_NOMASK,prmT002622)
           ,new CursorDef("T002623", "SELECT [IncidenciaId], [IncidenciaDetalleId] FROM [IncidenciaDetalle] WHERE [IncidenciaId] = @IncidenciaId ORDER BY [IncidenciaId], [IncidenciaDetalleId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002623,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 80);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 80);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((string[]) buf[10])[0] = rslt.getString(10, 20);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((long[]) buf[12])[0] = rslt.getLong(12);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 80);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 80);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}

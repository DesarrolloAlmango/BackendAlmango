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
   public class publicaciones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
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
            gxLoad_8( A118MonedaId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_documento") == 0 )
         {
            gxnrGridlevel_documento_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_multimedia") == 0 )
         {
            gxnrGridlevel_multimedia_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Publicaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPublicacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_documento_newrow_invoke( )
      {
         nRC_GXsfl_153 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_153"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_153_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_153_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_153_idx = GetPar( "sGXsfl_153_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_documento_newrow( ) ;
         /* End function gxnrGridlevel_documento_newrow_invoke */
      }

      protected void gxnrGridlevel_multimedia_newrow_invoke( )
      {
         nRC_GXsfl_162 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_162"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_162_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_162_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_162_idx = GetPar( "sGXsfl_162_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_multimedia_newrow( ) ;
         /* End function gxnrGridlevel_multimedia_newrow_invoke */
      }

      public publicaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public publicaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynMonedaId = new GXCombobox();
         cmbPublicacionesEstado = new GXCombobox();
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
         if ( cmbPublicacionesEstado.ItemCount > 0 )
         {
            A384PublicacionesEstado = cmbPublicacionesEstado.getValidValue(A384PublicacionesEstado);
            AssignAttri("", false, "A384PublicacionesEstado", A384PublicacionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPublicacionesEstado.CurrentValue = StringUtil.RTrim( A384PublicacionesEstado);
            AssignProp("", false, cmbPublicacionesEstado_Internalname, "Values", cmbPublicacionesEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesId_Internalname, context.GetMessage( "Referencia:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A381PublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPublicacionesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A381PublicacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A381PublicacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesTitulo_Internalname, context.GetMessage( "Título", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesTitulo_Internalname, StringUtil.RTrim( A382PublicacionesTitulo), StringUtil.RTrim( context.localUtil.Format( A382PublicacionesTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesDescripcion_Internalname, context.GetMessage( "Descripción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPublicacionesDescripcion_Internalname, A383PublicacionesDescripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, 1, edtPublicacionesDescripcion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoMunicipioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoMunicipioId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoMunicipioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoMunicipioId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoMunicipioId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Publicaciones.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_112_114_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_112_114_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_112_114_Internalname, sImgUrl, imgprompt_112_114_Link, "", "", context.GetTheme( ), imgprompt_112_114_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesFecTentInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesFecTentInicio_Internalname, context.GetMessage( "Tent Inicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPublicacionesFecTentInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPublicacionesFecTentInicio_Internalname, context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"), context.localUtil.Format( A843PublicacionesFecTentInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesFecTentInicio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesFecTentInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_bitmap( context, edtPublicacionesFecTentInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPublicacionesFecTentInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Publicaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesFecRealInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesFecRealInicio_Internalname, context.GetMessage( "Real Inicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPublicacionesFecRealInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPublicacionesFecRealInicio_Internalname, context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"), context.localUtil.Format( A844PublicacionesFecRealInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesFecRealInicio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesFecRealInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_bitmap( context, edtPublicacionesFecRealInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPublicacionesFecRealInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Publicaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesFecFinPostulacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesFecFinPostulacion_Internalname, context.GetMessage( "Fin Postulacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPublicacionesFecFinPostulacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPublicacionesFecFinPostulacion_Internalname, context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"), context.localUtil.Format( A845PublicacionesFecFinPostulacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesFecFinPostulacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesFecFinPostulacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_bitmap( context, edtPublicacionesFecFinPostulacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPublicacionesFecFinPostulacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Publicaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesDetalleMateriales_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesDetalleMateriales_Internalname, context.GetMessage( "Detalle Materiales", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesDetalleMateriales_Internalname, StringUtil.RTrim( A846PublicacionesDetalleMateriales), StringUtil.RTrim( context.localUtil.Format( A846PublicacionesDetalleMateriales, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesDetalleMateriales_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesDetalleMateriales_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesFecVisita_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesFecVisita_Internalname, context.GetMessage( "Fec Visita", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPublicacionesFecVisita_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPublicacionesFecVisita_Internalname, context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"), context.localUtil.Format( A847PublicacionesFecVisita, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesFecVisita_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesFecVisita_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_bitmap( context, edtPublicacionesFecVisita_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPublicacionesFecVisita_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Publicaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesHoraVisita_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesHoraVisita_Internalname, context.GetMessage( "Hora Visita", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesHoraVisita_Internalname, StringUtil.RTrim( A848PublicacionesHoraVisita), StringUtil.RTrim( context.localUtil.Format( A848PublicacionesHoraVisita, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesHoraVisita_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesHoraVisita_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesDirVisita_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesDirVisita_Internalname, context.GetMessage( "Dir Visita", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesDirVisita_Internalname, A849PublicacionesDirVisita, StringUtil.RTrim( context.localUtil.Format( A849PublicacionesDirVisita, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesDirVisita_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesDirVisita_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesCondiciones_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesCondiciones_Internalname, context.GetMessage( "Condiciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesCondiciones_Internalname, A850PublicacionesCondiciones, StringUtil.RTrim( context.localUtil.Format( A850PublicacionesCondiciones, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesCondiciones_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesCondiciones_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesTipoDesembolso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesTipoDesembolso_Internalname, context.GetMessage( "Tipo Desembolso", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesTipoDesembolso_Internalname, A851PublicacionesTipoDesembolso, StringUtil.RTrim( context.localUtil.Format( A851PublicacionesTipoDesembolso, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesTipoDesembolso_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesTipoDesembolso_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesOtroTipoDes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesOtroTipoDes_Internalname, context.GetMessage( "Tipo Des", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesOtroTipoDes_Internalname, A859PublicacionesOtroTipoDes, StringUtil.RTrim( context.localUtil.Format( A859PublicacionesOtroTipoDes, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesOtroTipoDes_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesOtroTipoDes_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesModalidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesModalidad_Internalname, context.GetMessage( "Modalidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesModalidad_Internalname, StringUtil.RTrim( A852PublicacionesModalidad), StringUtil.RTrim( context.localUtil.Format( A852PublicacionesModalidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesModalidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesModalidad_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesPrecio_Internalname, context.GetMessage( "Precio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A389PublicacionesPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPublicacionesPrecio_Enabled!=0) ? context.localUtil.Format( A389PublicacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A389PublicacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesPrecio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesPrecio_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynMonedaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynMonedaId_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynMonedaId, dynMonedaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0)), 1, dynMonedaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMonedaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 0, "HLP_Publicaciones.htm");
         dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         AssignProp("", false, dynMonedaId_Internalname, "Values", (string)(dynMonedaId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMonedaISOSimbolo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonedaISOSimbolo_Internalname, context.GetMessage( "Simbolo ISO", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonedaISOSimbolo_Internalname, StringUtil.RTrim( A119MonedaISOSimbolo), StringUtil.RTrim( context.localUtil.Format( A119MonedaISOSimbolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonedaISOSimbolo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMonedaISOSimbolo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "MonISO", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesFecCierre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesFecCierre_Internalname, context.GetMessage( "Fec Cierre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPublicacionesFecCierre_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPublicacionesFecCierre_Internalname, context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"), context.localUtil.Format( A854PublicacionesFecCierre, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesFecCierre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesFecCierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_bitmap( context, edtPublicacionesFecCierre_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPublicacionesFecCierre_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Publicaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesDocReq_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesDocReq_Internalname, context.GetMessage( "Doc Req", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesDocReq_Internalname, A855PublicacionesDocReq, StringUtil.RTrim( context.localUtil.Format( A855PublicacionesDocReq, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesDocReq_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesDocReq_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesDocDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesDocDescripcion_Internalname, context.GetMessage( "Doc Descripcion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesDocDescripcion_Internalname, A856PublicacionesDocDescripcion, StringUtil.RTrim( context.localUtil.Format( A856PublicacionesDocDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesDocDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesDocDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesTipoEmpresa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesTipoEmpresa_Internalname, context.GetMessage( "Tipo Empresa", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesTipoEmpresa_Internalname, A857PublicacionesTipoEmpresa, StringUtil.RTrim( context.localUtil.Format( A857PublicacionesTipoEmpresa, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesTipoEmpresa_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesTipoEmpresa_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesContratoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesContratoId_Internalname, context.GetMessage( "Contrato Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesContratoId_Internalname, A858PublicacionesContratoId, StringUtil.RTrim( context.localUtil.Format( A858PublicacionesContratoId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesContratoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesContratoId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPublicacionesTerminoObra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPublicacionesTerminoObra_Internalname, context.GetMessage( "Termino Obra", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesTerminoObra_Internalname, A860PublicacionesTerminoObra, StringUtil.RTrim( context.localUtil.Format( A860PublicacionesTerminoObra, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesTerminoObra_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPublicacionesTerminoObra_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPublicacionesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPublicacionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPublicacionesEstado, cmbPublicacionesEstado_Internalname, StringUtil.RTrim( A384PublicacionesEstado), 1, cmbPublicacionesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPublicacionesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "", true, 0, "HLP_Publicaciones.htm");
         cmbPublicacionesEstado.CurrentValue = StringUtil.RTrim( A384PublicacionesEstado);
         AssignProp("", false, cmbPublicacionesEstado_Internalname, "Values", (string)(cmbPublicacionesEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_documento_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_documento( ) ;
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
         GxWebStd.gx_div_start( context, divTableleaflevel_multimedia_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_multimedia( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Publicaciones.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesSerialIma_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A385PublicacionesSerialIma), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPublicacionesSerialIma_Enabled!=0) ? context.localUtil.Format( (decimal)(A385PublicacionesSerialIma), "ZZZ9") : context.localUtil.Format( (decimal)(A385PublicacionesSerialIma), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesSerialIma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPublicacionesSerialIma_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPublicacionesSerialRem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A395PublicacionesSerialRem), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPublicacionesSerialRem_Enabled!=0) ? context.localUtil.Format( (decimal)(A395PublicacionesSerialRem), "ZZZ9") : context.localUtil.Format( (decimal)(A395PublicacionesSerialRem), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPublicacionesSerialRem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPublicacionesSerialRem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Publicaciones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_documento( )
      {
         /*  Grid Control  */
         StartGridControl153( ) ;
         nGXsfl_153_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount128 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_128 = 1;
               ScanStart1G128( ) ;
               while ( RcdFound128 != 0 )
               {
                  init_level_properties128( ) ;
                  getByPrimaryKey1G128( ) ;
                  AddRow1G128( ) ;
                  ScanNext1G128( ) ;
               }
               ScanEnd1G128( ) ;
               nBlankRcdCount128 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1G128( ) ;
            standaloneModal1G128( ) ;
            sMode128 = Gx_mode;
            while ( nGXsfl_153_idx < nRC_GXsfl_153 )
            {
               bGXsfl_153_Refreshing = true;
               ReadRow1G128( ) ;
               edtPublicacionesDocId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESDOCID_"+sGXsfl_153_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPublicacionesDocId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocId_Enabled), 5, 0), !bGXsfl_153_Refreshing);
               edtPublicacionesDoc_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESDOC_"+sGXsfl_153_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPublicacionesDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDoc_Enabled), 5, 0), !bGXsfl_153_Refreshing);
               edtPublicacionesDocDescrip_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPublicacionesDocDescrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocDescrip_Enabled), 5, 0), !bGXsfl_153_Refreshing);
               if ( ( nRcdExists_128 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1G128( ) ;
               }
               SendRow1G128( ) ;
               bGXsfl_153_Refreshing = false;
            }
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount128 = 5;
            nRcdExists_128 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1G128( ) ;
               while ( RcdFound128 != 0 )
               {
                  sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_153128( ) ;
                  init_level_properties128( ) ;
                  standaloneNotModal1G128( ) ;
                  getByPrimaryKey1G128( ) ;
                  standaloneModal1G128( ) ;
                  AddRow1G128( ) ;
                  ScanNext1G128( ) ;
               }
               ScanEnd1G128( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode128 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx+1), 4, 0), 4, "0");
         SubsflControlProps_153128( ) ;
         InitAll1G128( ) ;
         init_level_properties128( ) ;
         nRcdExists_128 = 0;
         nIsMod_128 = 0;
         nRcdDeleted_128 = 0;
         nBlankRcdCount128 = (short)(nBlankRcdUsr128+nBlankRcdCount128);
         fRowAdded = 0;
         while ( nBlankRcdCount128 > 0 )
         {
            standaloneNotModal1G128( ) ;
            standaloneModal1G128( ) ;
            AddRow1G128( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPublicacionesDocId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount128 = (short)(nBlankRcdCount128-1);
         }
         Gx_mode = sMode128;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_documentoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_documento", Gridlevel_documentoContainer, subGridlevel_documento_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_documentoContainerData", Gridlevel_documentoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_documentoContainerData"+"V", Gridlevel_documentoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_documentoContainerData"+"V"+"\" value='"+Gridlevel_documentoContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_multimedia( )
      {
         /*  Grid Control  */
         StartGridControl162( ) ;
         nGXsfl_162_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount129 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_129 = 1;
               ScanStart1G129( ) ;
               while ( RcdFound129 != 0 )
               {
                  init_level_properties129( ) ;
                  getByPrimaryKey1G129( ) ;
                  AddRow1G129( ) ;
                  ScanNext1G129( ) ;
               }
               ScanEnd1G129( ) ;
               nBlankRcdCount129 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1G129( ) ;
            standaloneModal1G129( ) ;
            sMode129 = Gx_mode;
            while ( nGXsfl_162_idx < nRC_GXsfl_162 )
            {
               bGXsfl_162_Refreshing = true;
               ReadRow1G129( ) ;
               edtPublicacionesMultId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESMULTID_"+sGXsfl_162_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPublicacionesMultId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultId_Enabled), 5, 0), !bGXsfl_162_Refreshing);
               edtPublicacionesMult_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESMULT_"+sGXsfl_162_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPublicacionesMult_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMult_Enabled), 5, 0), !bGXsfl_162_Refreshing);
               edtPublicacionesMultDescrip_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPublicacionesMultDescrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultDescrip_Enabled), 5, 0), !bGXsfl_162_Refreshing);
               if ( ( nRcdExists_129 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1G129( ) ;
               }
               SendRow1G129( ) ;
               bGXsfl_162_Refreshing = false;
            }
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount129 = 5;
            nRcdExists_129 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1G129( ) ;
               while ( RcdFound129 != 0 )
               {
                  sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_162129( ) ;
                  init_level_properties129( ) ;
                  standaloneNotModal1G129( ) ;
                  getByPrimaryKey1G129( ) ;
                  standaloneModal1G129( ) ;
                  AddRow1G129( ) ;
                  ScanNext1G129( ) ;
               }
               ScanEnd1G129( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode129 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx+1), 4, 0), 4, "0");
         SubsflControlProps_162129( ) ;
         InitAll1G129( ) ;
         init_level_properties129( ) ;
         nRcdExists_129 = 0;
         nIsMod_129 = 0;
         nRcdDeleted_129 = 0;
         nBlankRcdCount129 = (short)(nBlankRcdUsr129+nBlankRcdCount129);
         fRowAdded = 0;
         while ( nBlankRcdCount129 > 0 )
         {
            standaloneNotModal1G129( ) ;
            standaloneModal1G129( ) ;
            AddRow1G129( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPublicacionesMultId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount129 = (short)(nBlankRcdCount129-1);
         }
         Gx_mode = sMode129;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_multimediaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_multimedia", Gridlevel_multimediaContainer, subGridlevel_multimedia_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_multimediaContainerData", Gridlevel_multimediaContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_multimediaContainerData"+"V", Gridlevel_multimediaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_multimediaContainerData"+"V"+"\" value='"+Gridlevel_multimediaContainer.GridValuesHidden()+"'/>") ;
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
         E111G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z381PublicacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z381PublicacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z382PublicacionesTitulo = cgiGet( "Z382PublicacionesTitulo");
               Z843PublicacionesFecTentInicio = context.localUtil.CToD( cgiGet( "Z843PublicacionesFecTentInicio"), 0);
               Z844PublicacionesFecRealInicio = context.localUtil.CToD( cgiGet( "Z844PublicacionesFecRealInicio"), 0);
               Z845PublicacionesFecFinPostulacion = context.localUtil.CToD( cgiGet( "Z845PublicacionesFecFinPostulacion"), 0);
               Z846PublicacionesDetalleMateriales = cgiGet( "Z846PublicacionesDetalleMateriales");
               Z847PublicacionesFecVisita = context.localUtil.CToD( cgiGet( "Z847PublicacionesFecVisita"), 0);
               Z848PublicacionesHoraVisita = cgiGet( "Z848PublicacionesHoraVisita");
               Z849PublicacionesDirVisita = cgiGet( "Z849PublicacionesDirVisita");
               Z850PublicacionesCondiciones = cgiGet( "Z850PublicacionesCondiciones");
               Z851PublicacionesTipoDesembolso = cgiGet( "Z851PublicacionesTipoDesembolso");
               Z859PublicacionesOtroTipoDes = cgiGet( "Z859PublicacionesOtroTipoDes");
               Z852PublicacionesModalidad = cgiGet( "Z852PublicacionesModalidad");
               Z389PublicacionesPrecio = context.localUtil.CToN( cgiGet( "Z389PublicacionesPrecio"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z854PublicacionesFecCierre = context.localUtil.CToD( cgiGet( "Z854PublicacionesFecCierre"), 0);
               Z855PublicacionesDocReq = cgiGet( "Z855PublicacionesDocReq");
               Z856PublicacionesDocDescripcion = cgiGet( "Z856PublicacionesDocDescripcion");
               Z857PublicacionesTipoEmpresa = cgiGet( "Z857PublicacionesTipoEmpresa");
               Z858PublicacionesContratoId = cgiGet( "Z858PublicacionesContratoId");
               Z860PublicacionesTerminoObra = cgiGet( "Z860PublicacionesTerminoObra");
               Z384PublicacionesEstado = cgiGet( "Z384PublicacionesEstado");
               Z385PublicacionesSerialIma = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z385PublicacionesSerialIma"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z395PublicacionesSerialRem = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z395PublicacionesSerialRem"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z118MonedaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n118MonedaId = ((0==A118MonedaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_153 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_153"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_162 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_162"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtPublicacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPublicacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PUBLICACIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A381PublicacionesId = 0;
                  AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
               }
               else
               {
                  A381PublicacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPublicacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
               }
               A382PublicacionesTitulo = cgiGet( edtPublicacionesTitulo_Internalname);
               AssignAttri("", false, "A382PublicacionesTitulo", A382PublicacionesTitulo);
               A383PublicacionesDescripcion = cgiGet( edtPublicacionesDescripcion_Internalname);
               AssignAttri("", false, "A383PublicacionesDescripcion", A383PublicacionesDescripcion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A112DepartamentoId = 0;
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               }
               else
               {
                  A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOMUNICIPIOID");
                  AnyError = 1;
                  GX_FocusControl = edtDepartamentoMunicipioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A114DepartamentoMunicipioId = 0;
                  AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               }
               else
               {
                  A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPublicacionesFecTentInicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Tent Inicio", "")}), 1, "PUBLICACIONESFECTENTINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesFecTentInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A843PublicacionesFecTentInicio = DateTime.MinValue;
                  AssignAttri("", false, "A843PublicacionesFecTentInicio", context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"));
               }
               else
               {
                  A843PublicacionesFecTentInicio = context.localUtil.CToD( cgiGet( edtPublicacionesFecTentInicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A843PublicacionesFecTentInicio", context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPublicacionesFecRealInicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Real Inicio", "")}), 1, "PUBLICACIONESFECREALINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesFecRealInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A844PublicacionesFecRealInicio = DateTime.MinValue;
                  AssignAttri("", false, "A844PublicacionesFecRealInicio", context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"));
               }
               else
               {
                  A844PublicacionesFecRealInicio = context.localUtil.CToD( cgiGet( edtPublicacionesFecRealInicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A844PublicacionesFecRealInicio", context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPublicacionesFecFinPostulacion_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Fin Postulacion", "")}), 1, "PUBLICACIONESFECFINPOSTULACION");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesFecFinPostulacion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A845PublicacionesFecFinPostulacion = DateTime.MinValue;
                  AssignAttri("", false, "A845PublicacionesFecFinPostulacion", context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"));
               }
               else
               {
                  A845PublicacionesFecFinPostulacion = context.localUtil.CToD( cgiGet( edtPublicacionesFecFinPostulacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A845PublicacionesFecFinPostulacion", context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"));
               }
               A846PublicacionesDetalleMateriales = cgiGet( edtPublicacionesDetalleMateriales_Internalname);
               AssignAttri("", false, "A846PublicacionesDetalleMateriales", A846PublicacionesDetalleMateriales);
               if ( context.localUtil.VCDate( cgiGet( edtPublicacionesFecVisita_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Visita", "")}), 1, "PUBLICACIONESFECVISITA");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesFecVisita_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A847PublicacionesFecVisita = DateTime.MinValue;
                  AssignAttri("", false, "A847PublicacionesFecVisita", context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"));
               }
               else
               {
                  A847PublicacionesFecVisita = context.localUtil.CToD( cgiGet( edtPublicacionesFecVisita_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A847PublicacionesFecVisita", context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"));
               }
               A848PublicacionesHoraVisita = cgiGet( edtPublicacionesHoraVisita_Internalname);
               AssignAttri("", false, "A848PublicacionesHoraVisita", A848PublicacionesHoraVisita);
               A849PublicacionesDirVisita = cgiGet( edtPublicacionesDirVisita_Internalname);
               AssignAttri("", false, "A849PublicacionesDirVisita", A849PublicacionesDirVisita);
               A850PublicacionesCondiciones = cgiGet( edtPublicacionesCondiciones_Internalname);
               AssignAttri("", false, "A850PublicacionesCondiciones", A850PublicacionesCondiciones);
               A851PublicacionesTipoDesembolso = cgiGet( edtPublicacionesTipoDesembolso_Internalname);
               AssignAttri("", false, "A851PublicacionesTipoDesembolso", A851PublicacionesTipoDesembolso);
               A859PublicacionesOtroTipoDes = cgiGet( edtPublicacionesOtroTipoDes_Internalname);
               AssignAttri("", false, "A859PublicacionesOtroTipoDes", A859PublicacionesOtroTipoDes);
               A852PublicacionesModalidad = cgiGet( edtPublicacionesModalidad_Internalname);
               AssignAttri("", false, "A852PublicacionesModalidad", A852PublicacionesModalidad);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPublicacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPublicacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PUBLICACIONESPRECIO");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesPrecio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A389PublicacionesPrecio = 0;
                  AssignAttri("", false, "A389PublicacionesPrecio", StringUtil.LTrimStr( A389PublicacionesPrecio, 18, 2));
               }
               else
               {
                  A389PublicacionesPrecio = context.localUtil.CToN( cgiGet( edtPublicacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A389PublicacionesPrecio", StringUtil.LTrimStr( A389PublicacionesPrecio, 18, 2));
               }
               dynMonedaId.Name = dynMonedaId_Internalname;
               dynMonedaId.CurrentValue = cgiGet( dynMonedaId_Internalname);
               A118MonedaId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynMonedaId_Internalname), "."), 18, MidpointRounding.ToEven));
               n118MonedaId = false;
               AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
               n118MonedaId = ((0==A118MonedaId) ? true : false);
               A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
               AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
               if ( context.localUtil.VCDate( cgiGet( edtPublicacionesFecCierre_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Cierre", "")}), 1, "PUBLICACIONESFECCIERRE");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesFecCierre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A854PublicacionesFecCierre = DateTime.MinValue;
                  AssignAttri("", false, "A854PublicacionesFecCierre", context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"));
               }
               else
               {
                  A854PublicacionesFecCierre = context.localUtil.CToD( cgiGet( edtPublicacionesFecCierre_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A854PublicacionesFecCierre", context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"));
               }
               A855PublicacionesDocReq = cgiGet( edtPublicacionesDocReq_Internalname);
               AssignAttri("", false, "A855PublicacionesDocReq", A855PublicacionesDocReq);
               A856PublicacionesDocDescripcion = cgiGet( edtPublicacionesDocDescripcion_Internalname);
               AssignAttri("", false, "A856PublicacionesDocDescripcion", A856PublicacionesDocDescripcion);
               A857PublicacionesTipoEmpresa = cgiGet( edtPublicacionesTipoEmpresa_Internalname);
               AssignAttri("", false, "A857PublicacionesTipoEmpresa", A857PublicacionesTipoEmpresa);
               A858PublicacionesContratoId = cgiGet( edtPublicacionesContratoId_Internalname);
               AssignAttri("", false, "A858PublicacionesContratoId", A858PublicacionesContratoId);
               A860PublicacionesTerminoObra = cgiGet( edtPublicacionesTerminoObra_Internalname);
               AssignAttri("", false, "A860PublicacionesTerminoObra", A860PublicacionesTerminoObra);
               cmbPublicacionesEstado.Name = cmbPublicacionesEstado_Internalname;
               cmbPublicacionesEstado.CurrentValue = cgiGet( cmbPublicacionesEstado_Internalname);
               A384PublicacionesEstado = cgiGet( cmbPublicacionesEstado_Internalname);
               AssignAttri("", false, "A384PublicacionesEstado", A384PublicacionesEstado);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPublicacionesSerialIma_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPublicacionesSerialIma_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PUBLICACIONESSERIALIMA");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesSerialIma_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A385PublicacionesSerialIma = 0;
                  AssignAttri("", false, "A385PublicacionesSerialIma", StringUtil.LTrimStr( (decimal)(A385PublicacionesSerialIma), 4, 0));
               }
               else
               {
                  A385PublicacionesSerialIma = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPublicacionesSerialIma_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A385PublicacionesSerialIma", StringUtil.LTrimStr( (decimal)(A385PublicacionesSerialIma), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPublicacionesSerialRem_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPublicacionesSerialRem_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PUBLICACIONESSERIALREM");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesSerialRem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A395PublicacionesSerialRem = 0;
                  AssignAttri("", false, "A395PublicacionesSerialRem", StringUtil.LTrimStr( (decimal)(A395PublicacionesSerialRem), 4, 0));
               }
               else
               {
                  A395PublicacionesSerialRem = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPublicacionesSerialRem_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A395PublicacionesSerialRem", StringUtil.LTrimStr( (decimal)(A395PublicacionesSerialRem), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
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
                  A381PublicacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PublicacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal( ) ;
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
                           E111G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            E121G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1G127( ) ;
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
         if ( IsIns( ) )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtntrn_enter_Visible = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1G127( ) ;
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

      protected void CONFIRM_1G129( )
      {
         nGXsfl_162_idx = 0;
         while ( nGXsfl_162_idx < nRC_GXsfl_162 )
         {
            ReadRow1G129( ) ;
            if ( ( nRcdExists_129 != 0 ) || ( nIsMod_129 != 0 ) )
            {
               GetKey1G129( ) ;
               if ( ( nRcdExists_129 == 0 ) && ( nRcdDeleted_129 == 0 ) )
               {
                  if ( RcdFound129 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1G129( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1G129( ) ;
                        CloseExtendedTableCursors1G129( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PUBLICACIONESMULTID_" + sGXsfl_162_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPublicacionesMultId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound129 != 0 )
                  {
                     if ( nRcdDeleted_129 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1G129( ) ;
                        Load1G129( ) ;
                        BeforeValidate1G129( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1G129( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_129 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1G129( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1G129( ) ;
                              CloseExtendedTableCursors1G129( ) ;
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
                     if ( nRcdDeleted_129 == 0 )
                     {
                        GXCCtl = "PUBLICACIONESMULTID_" + sGXsfl_162_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPublicacionesMultId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPublicacionesMultId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A394PublicacionesMultId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPublicacionesMult_Internalname, A392PublicacionesMult) ;
            ChangePostValue( edtPublicacionesMultDescrip_Internalname, A861PublicacionesMultDescrip) ;
            ChangePostValue( "ZT_"+"Z394PublicacionesMultId_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z394PublicacionesMultId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z392PublicacionesMult_"+sGXsfl_162_idx, Z392PublicacionesMult) ;
            ChangePostValue( "ZT_"+"Z861PublicacionesMultDescrip_"+sGXsfl_162_idx, Z861PublicacionesMultDescrip) ;
            ChangePostValue( "nRcdDeleted_129_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_129), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_129_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_129), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_129_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_129), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_129 != 0 )
            {
               ChangePostValue( "PUBLICACIONESMULTID_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESMULT_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMult_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultDescrip_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1G128( )
      {
         nGXsfl_153_idx = 0;
         while ( nGXsfl_153_idx < nRC_GXsfl_153 )
         {
            ReadRow1G128( ) ;
            if ( ( nRcdExists_128 != 0 ) || ( nIsMod_128 != 0 ) )
            {
               GetKey1G128( ) ;
               if ( ( nRcdExists_128 == 0 ) && ( nRcdDeleted_128 == 0 ) )
               {
                  if ( RcdFound128 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1G128( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1G128( ) ;
                        CloseExtendedTableCursors1G128( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PUBLICACIONESDOCID_" + sGXsfl_153_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPublicacionesDocId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound128 != 0 )
                  {
                     if ( nRcdDeleted_128 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1G128( ) ;
                        Load1G128( ) ;
                        BeforeValidate1G128( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1G128( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_128 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1G128( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1G128( ) ;
                              CloseExtendedTableCursors1G128( ) ;
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
                     if ( nRcdDeleted_128 == 0 )
                     {
                        GXCCtl = "PUBLICACIONESDOCID_" + sGXsfl_153_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPublicacionesDocId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPublicacionesDocId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A386PublicacionesDocId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPublicacionesDoc_Internalname, A387PublicacionesDoc) ;
            ChangePostValue( edtPublicacionesDocDescrip_Internalname, A388PublicacionesDocDescrip) ;
            ChangePostValue( "ZT_"+"Z386PublicacionesDocId_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z386PublicacionesDocId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z387PublicacionesDoc_"+sGXsfl_153_idx, Z387PublicacionesDoc) ;
            ChangePostValue( "ZT_"+"Z388PublicacionesDocDescrip_"+sGXsfl_153_idx, Z388PublicacionesDocDescrip) ;
            ChangePostValue( "nRcdDeleted_128_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_128), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_128_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_128), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_128_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_128), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_128 != 0 )
            {
               ChangePostValue( "PUBLICACIONESDOCID_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESDOC_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDoc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocDescrip_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1G0( )
      {
      }

      protected void E111G2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E121G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1G127( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z382PublicacionesTitulo = T001G7_A382PublicacionesTitulo[0];
               Z843PublicacionesFecTentInicio = T001G7_A843PublicacionesFecTentInicio[0];
               Z844PublicacionesFecRealInicio = T001G7_A844PublicacionesFecRealInicio[0];
               Z845PublicacionesFecFinPostulacion = T001G7_A845PublicacionesFecFinPostulacion[0];
               Z846PublicacionesDetalleMateriales = T001G7_A846PublicacionesDetalleMateriales[0];
               Z847PublicacionesFecVisita = T001G7_A847PublicacionesFecVisita[0];
               Z848PublicacionesHoraVisita = T001G7_A848PublicacionesHoraVisita[0];
               Z849PublicacionesDirVisita = T001G7_A849PublicacionesDirVisita[0];
               Z850PublicacionesCondiciones = T001G7_A850PublicacionesCondiciones[0];
               Z851PublicacionesTipoDesembolso = T001G7_A851PublicacionesTipoDesembolso[0];
               Z859PublicacionesOtroTipoDes = T001G7_A859PublicacionesOtroTipoDes[0];
               Z852PublicacionesModalidad = T001G7_A852PublicacionesModalidad[0];
               Z389PublicacionesPrecio = T001G7_A389PublicacionesPrecio[0];
               Z854PublicacionesFecCierre = T001G7_A854PublicacionesFecCierre[0];
               Z855PublicacionesDocReq = T001G7_A855PublicacionesDocReq[0];
               Z856PublicacionesDocDescripcion = T001G7_A856PublicacionesDocDescripcion[0];
               Z857PublicacionesTipoEmpresa = T001G7_A857PublicacionesTipoEmpresa[0];
               Z858PublicacionesContratoId = T001G7_A858PublicacionesContratoId[0];
               Z860PublicacionesTerminoObra = T001G7_A860PublicacionesTerminoObra[0];
               Z384PublicacionesEstado = T001G7_A384PublicacionesEstado[0];
               Z385PublicacionesSerialIma = T001G7_A385PublicacionesSerialIma[0];
               Z395PublicacionesSerialRem = T001G7_A395PublicacionesSerialRem[0];
               Z112DepartamentoId = T001G7_A112DepartamentoId[0];
               Z114DepartamentoMunicipioId = T001G7_A114DepartamentoMunicipioId[0];
               Z118MonedaId = T001G7_A118MonedaId[0];
            }
            else
            {
               Z382PublicacionesTitulo = A382PublicacionesTitulo;
               Z843PublicacionesFecTentInicio = A843PublicacionesFecTentInicio;
               Z844PublicacionesFecRealInicio = A844PublicacionesFecRealInicio;
               Z845PublicacionesFecFinPostulacion = A845PublicacionesFecFinPostulacion;
               Z846PublicacionesDetalleMateriales = A846PublicacionesDetalleMateriales;
               Z847PublicacionesFecVisita = A847PublicacionesFecVisita;
               Z848PublicacionesHoraVisita = A848PublicacionesHoraVisita;
               Z849PublicacionesDirVisita = A849PublicacionesDirVisita;
               Z850PublicacionesCondiciones = A850PublicacionesCondiciones;
               Z851PublicacionesTipoDesembolso = A851PublicacionesTipoDesembolso;
               Z859PublicacionesOtroTipoDes = A859PublicacionesOtroTipoDes;
               Z852PublicacionesModalidad = A852PublicacionesModalidad;
               Z389PublicacionesPrecio = A389PublicacionesPrecio;
               Z854PublicacionesFecCierre = A854PublicacionesFecCierre;
               Z855PublicacionesDocReq = A855PublicacionesDocReq;
               Z856PublicacionesDocDescripcion = A856PublicacionesDocDescripcion;
               Z857PublicacionesTipoEmpresa = A857PublicacionesTipoEmpresa;
               Z858PublicacionesContratoId = A858PublicacionesContratoId;
               Z860PublicacionesTerminoObra = A860PublicacionesTerminoObra;
               Z384PublicacionesEstado = A384PublicacionesEstado;
               Z385PublicacionesSerialIma = A385PublicacionesSerialIma;
               Z395PublicacionesSerialRem = A395PublicacionesSerialRem;
               Z112DepartamentoId = A112DepartamentoId;
               Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
               Z118MonedaId = A118MonedaId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z381PublicacionesId = A381PublicacionesId;
            Z382PublicacionesTitulo = A382PublicacionesTitulo;
            Z383PublicacionesDescripcion = A383PublicacionesDescripcion;
            Z843PublicacionesFecTentInicio = A843PublicacionesFecTentInicio;
            Z844PublicacionesFecRealInicio = A844PublicacionesFecRealInicio;
            Z845PublicacionesFecFinPostulacion = A845PublicacionesFecFinPostulacion;
            Z846PublicacionesDetalleMateriales = A846PublicacionesDetalleMateriales;
            Z847PublicacionesFecVisita = A847PublicacionesFecVisita;
            Z848PublicacionesHoraVisita = A848PublicacionesHoraVisita;
            Z849PublicacionesDirVisita = A849PublicacionesDirVisita;
            Z850PublicacionesCondiciones = A850PublicacionesCondiciones;
            Z851PublicacionesTipoDesembolso = A851PublicacionesTipoDesembolso;
            Z859PublicacionesOtroTipoDes = A859PublicacionesOtroTipoDes;
            Z852PublicacionesModalidad = A852PublicacionesModalidad;
            Z389PublicacionesPrecio = A389PublicacionesPrecio;
            Z854PublicacionesFecCierre = A854PublicacionesFecCierre;
            Z855PublicacionesDocReq = A855PublicacionesDocReq;
            Z856PublicacionesDocDescripcion = A856PublicacionesDocDescripcion;
            Z857PublicacionesTipoEmpresa = A857PublicacionesTipoEmpresa;
            Z858PublicacionesContratoId = A858PublicacionesContratoId;
            Z860PublicacionesTerminoObra = A860PublicacionesTerminoObra;
            Z384PublicacionesEstado = A384PublicacionesEstado;
            Z385PublicacionesSerialIma = A385PublicacionesSerialIma;
            Z395PublicacionesSerialRem = A395PublicacionesSerialRem;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z118MonedaId = A118MonedaId;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_112_114_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00m0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOMUNICIPIOID"+"'), id:'"+"DEPARTAMENTOMUNICIPIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_delete_Enabled = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
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
      }

      protected void Load1G127( )
      {
         /* Using cursor T001G10 */
         pr_default.execute(8, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound127 = 1;
            A382PublicacionesTitulo = T001G10_A382PublicacionesTitulo[0];
            AssignAttri("", false, "A382PublicacionesTitulo", A382PublicacionesTitulo);
            A383PublicacionesDescripcion = T001G10_A383PublicacionesDescripcion[0];
            AssignAttri("", false, "A383PublicacionesDescripcion", A383PublicacionesDescripcion);
            A843PublicacionesFecTentInicio = T001G10_A843PublicacionesFecTentInicio[0];
            AssignAttri("", false, "A843PublicacionesFecTentInicio", context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"));
            A844PublicacionesFecRealInicio = T001G10_A844PublicacionesFecRealInicio[0];
            AssignAttri("", false, "A844PublicacionesFecRealInicio", context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"));
            A845PublicacionesFecFinPostulacion = T001G10_A845PublicacionesFecFinPostulacion[0];
            AssignAttri("", false, "A845PublicacionesFecFinPostulacion", context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"));
            A846PublicacionesDetalleMateriales = T001G10_A846PublicacionesDetalleMateriales[0];
            AssignAttri("", false, "A846PublicacionesDetalleMateriales", A846PublicacionesDetalleMateriales);
            A847PublicacionesFecVisita = T001G10_A847PublicacionesFecVisita[0];
            AssignAttri("", false, "A847PublicacionesFecVisita", context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"));
            A848PublicacionesHoraVisita = T001G10_A848PublicacionesHoraVisita[0];
            AssignAttri("", false, "A848PublicacionesHoraVisita", A848PublicacionesHoraVisita);
            A849PublicacionesDirVisita = T001G10_A849PublicacionesDirVisita[0];
            AssignAttri("", false, "A849PublicacionesDirVisita", A849PublicacionesDirVisita);
            A850PublicacionesCondiciones = T001G10_A850PublicacionesCondiciones[0];
            AssignAttri("", false, "A850PublicacionesCondiciones", A850PublicacionesCondiciones);
            A851PublicacionesTipoDesembolso = T001G10_A851PublicacionesTipoDesembolso[0];
            AssignAttri("", false, "A851PublicacionesTipoDesembolso", A851PublicacionesTipoDesembolso);
            A859PublicacionesOtroTipoDes = T001G10_A859PublicacionesOtroTipoDes[0];
            AssignAttri("", false, "A859PublicacionesOtroTipoDes", A859PublicacionesOtroTipoDes);
            A852PublicacionesModalidad = T001G10_A852PublicacionesModalidad[0];
            AssignAttri("", false, "A852PublicacionesModalidad", A852PublicacionesModalidad);
            A389PublicacionesPrecio = T001G10_A389PublicacionesPrecio[0];
            AssignAttri("", false, "A389PublicacionesPrecio", StringUtil.LTrimStr( A389PublicacionesPrecio, 18, 2));
            A119MonedaISOSimbolo = T001G10_A119MonedaISOSimbolo[0];
            AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
            A854PublicacionesFecCierre = T001G10_A854PublicacionesFecCierre[0];
            AssignAttri("", false, "A854PublicacionesFecCierre", context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"));
            A855PublicacionesDocReq = T001G10_A855PublicacionesDocReq[0];
            AssignAttri("", false, "A855PublicacionesDocReq", A855PublicacionesDocReq);
            A856PublicacionesDocDescripcion = T001G10_A856PublicacionesDocDescripcion[0];
            AssignAttri("", false, "A856PublicacionesDocDescripcion", A856PublicacionesDocDescripcion);
            A857PublicacionesTipoEmpresa = T001G10_A857PublicacionesTipoEmpresa[0];
            AssignAttri("", false, "A857PublicacionesTipoEmpresa", A857PublicacionesTipoEmpresa);
            A858PublicacionesContratoId = T001G10_A858PublicacionesContratoId[0];
            AssignAttri("", false, "A858PublicacionesContratoId", A858PublicacionesContratoId);
            A860PublicacionesTerminoObra = T001G10_A860PublicacionesTerminoObra[0];
            AssignAttri("", false, "A860PublicacionesTerminoObra", A860PublicacionesTerminoObra);
            A384PublicacionesEstado = T001G10_A384PublicacionesEstado[0];
            AssignAttri("", false, "A384PublicacionesEstado", A384PublicacionesEstado);
            A385PublicacionesSerialIma = T001G10_A385PublicacionesSerialIma[0];
            AssignAttri("", false, "A385PublicacionesSerialIma", StringUtil.LTrimStr( (decimal)(A385PublicacionesSerialIma), 4, 0));
            A395PublicacionesSerialRem = T001G10_A395PublicacionesSerialRem[0];
            AssignAttri("", false, "A395PublicacionesSerialRem", StringUtil.LTrimStr( (decimal)(A395PublicacionesSerialRem), 4, 0));
            A112DepartamentoId = T001G10_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T001G10_A114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A118MonedaId = T001G10_A118MonedaId[0];
            n118MonedaId = T001G10_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            ZM1G127( -6) ;
         }
         pr_default.close(8);
         OnLoadActions1G127( ) ;
      }

      protected void OnLoadActions1G127( )
      {
      }

      protected void CheckExtendedTable1G127( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001G8 */
         pr_default.execute(6, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A843PublicacionesFecTentInicio) || ( DateTimeUtil.ResetTime ( A843PublicacionesFecTentInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Tent Inicio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PUBLICACIONESFECTENTINICIO");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesFecTentInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A844PublicacionesFecRealInicio) || ( DateTimeUtil.ResetTime ( A844PublicacionesFecRealInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Real Inicio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PUBLICACIONESFECREALINICIO");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesFecRealInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A845PublicacionesFecFinPostulacion) || ( DateTimeUtil.ResetTime ( A845PublicacionesFecFinPostulacion ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Fin Postulacion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PUBLICACIONESFECFINPOSTULACION");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesFecFinPostulacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A847PublicacionesFecVisita) || ( DateTimeUtil.ResetTime ( A847PublicacionesFecVisita ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Visita", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PUBLICACIONESFECVISITA");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesFecVisita_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001G9 */
         pr_default.execute(7, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
               GX_FocusControl = dynMonedaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A119MonedaISOSimbolo = T001G9_A119MonedaISOSimbolo[0];
         AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A854PublicacionesFecCierre) || ( DateTimeUtil.ResetTime ( A854PublicacionesFecCierre ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Cierre", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PUBLICACIONESFECCIERRE");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesFecCierre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1G127( )
      {
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( long A112DepartamentoId ,
                               long A114DepartamentoMunicipioId )
      {
         /* Using cursor T001G11 */
         pr_default.execute(9, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
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

      protected void gxLoad_8( short A118MonedaId )
      {
         /* Using cursor T001G12 */
         pr_default.execute(10, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
               GX_FocusControl = dynMonedaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A119MonedaISOSimbolo = T001G12_A119MonedaISOSimbolo[0];
         AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A119MonedaISOSimbolo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey1G127( )
      {
         /* Using cursor T001G13 */
         pr_default.execute(11, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound127 = 1;
         }
         else
         {
            RcdFound127 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001G7 */
         pr_default.execute(5, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM1G127( 6) ;
            RcdFound127 = 1;
            A381PublicacionesId = T001G7_A381PublicacionesId[0];
            AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
            A382PublicacionesTitulo = T001G7_A382PublicacionesTitulo[0];
            AssignAttri("", false, "A382PublicacionesTitulo", A382PublicacionesTitulo);
            A383PublicacionesDescripcion = T001G7_A383PublicacionesDescripcion[0];
            AssignAttri("", false, "A383PublicacionesDescripcion", A383PublicacionesDescripcion);
            A843PublicacionesFecTentInicio = T001G7_A843PublicacionesFecTentInicio[0];
            AssignAttri("", false, "A843PublicacionesFecTentInicio", context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"));
            A844PublicacionesFecRealInicio = T001G7_A844PublicacionesFecRealInicio[0];
            AssignAttri("", false, "A844PublicacionesFecRealInicio", context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"));
            A845PublicacionesFecFinPostulacion = T001G7_A845PublicacionesFecFinPostulacion[0];
            AssignAttri("", false, "A845PublicacionesFecFinPostulacion", context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"));
            A846PublicacionesDetalleMateriales = T001G7_A846PublicacionesDetalleMateriales[0];
            AssignAttri("", false, "A846PublicacionesDetalleMateriales", A846PublicacionesDetalleMateriales);
            A847PublicacionesFecVisita = T001G7_A847PublicacionesFecVisita[0];
            AssignAttri("", false, "A847PublicacionesFecVisita", context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"));
            A848PublicacionesHoraVisita = T001G7_A848PublicacionesHoraVisita[0];
            AssignAttri("", false, "A848PublicacionesHoraVisita", A848PublicacionesHoraVisita);
            A849PublicacionesDirVisita = T001G7_A849PublicacionesDirVisita[0];
            AssignAttri("", false, "A849PublicacionesDirVisita", A849PublicacionesDirVisita);
            A850PublicacionesCondiciones = T001G7_A850PublicacionesCondiciones[0];
            AssignAttri("", false, "A850PublicacionesCondiciones", A850PublicacionesCondiciones);
            A851PublicacionesTipoDesembolso = T001G7_A851PublicacionesTipoDesembolso[0];
            AssignAttri("", false, "A851PublicacionesTipoDesembolso", A851PublicacionesTipoDesembolso);
            A859PublicacionesOtroTipoDes = T001G7_A859PublicacionesOtroTipoDes[0];
            AssignAttri("", false, "A859PublicacionesOtroTipoDes", A859PublicacionesOtroTipoDes);
            A852PublicacionesModalidad = T001G7_A852PublicacionesModalidad[0];
            AssignAttri("", false, "A852PublicacionesModalidad", A852PublicacionesModalidad);
            A389PublicacionesPrecio = T001G7_A389PublicacionesPrecio[0];
            AssignAttri("", false, "A389PublicacionesPrecio", StringUtil.LTrimStr( A389PublicacionesPrecio, 18, 2));
            A854PublicacionesFecCierre = T001G7_A854PublicacionesFecCierre[0];
            AssignAttri("", false, "A854PublicacionesFecCierre", context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"));
            A855PublicacionesDocReq = T001G7_A855PublicacionesDocReq[0];
            AssignAttri("", false, "A855PublicacionesDocReq", A855PublicacionesDocReq);
            A856PublicacionesDocDescripcion = T001G7_A856PublicacionesDocDescripcion[0];
            AssignAttri("", false, "A856PublicacionesDocDescripcion", A856PublicacionesDocDescripcion);
            A857PublicacionesTipoEmpresa = T001G7_A857PublicacionesTipoEmpresa[0];
            AssignAttri("", false, "A857PublicacionesTipoEmpresa", A857PublicacionesTipoEmpresa);
            A858PublicacionesContratoId = T001G7_A858PublicacionesContratoId[0];
            AssignAttri("", false, "A858PublicacionesContratoId", A858PublicacionesContratoId);
            A860PublicacionesTerminoObra = T001G7_A860PublicacionesTerminoObra[0];
            AssignAttri("", false, "A860PublicacionesTerminoObra", A860PublicacionesTerminoObra);
            A384PublicacionesEstado = T001G7_A384PublicacionesEstado[0];
            AssignAttri("", false, "A384PublicacionesEstado", A384PublicacionesEstado);
            A385PublicacionesSerialIma = T001G7_A385PublicacionesSerialIma[0];
            AssignAttri("", false, "A385PublicacionesSerialIma", StringUtil.LTrimStr( (decimal)(A385PublicacionesSerialIma), 4, 0));
            A395PublicacionesSerialRem = T001G7_A395PublicacionesSerialRem[0];
            AssignAttri("", false, "A395PublicacionesSerialRem", StringUtil.LTrimStr( (decimal)(A395PublicacionesSerialRem), 4, 0));
            A112DepartamentoId = T001G7_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T001G7_A114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A118MonedaId = T001G7_A118MonedaId[0];
            n118MonedaId = T001G7_n118MonedaId[0];
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            Z381PublicacionesId = A381PublicacionesId;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1G127( ) ;
            if ( AnyError == 1 )
            {
               RcdFound127 = 0;
               InitializeNonKey1G127( ) ;
            }
            Gx_mode = sMode127;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound127 = 0;
            InitializeNonKey1G127( ) ;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode127;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G127( ) ;
         if ( RcdFound127 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound127 = 0;
         /* Using cursor T001G14 */
         pr_default.execute(12, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T001G14_A381PublicacionesId[0] < A381PublicacionesId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T001G14_A381PublicacionesId[0] > A381PublicacionesId ) ) )
            {
               A381PublicacionesId = T001G14_A381PublicacionesId[0];
               AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
               RcdFound127 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound127 = 0;
         /* Using cursor T001G15 */
         pr_default.execute(13, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T001G15_A381PublicacionesId[0] > A381PublicacionesId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T001G15_A381PublicacionesId[0] < A381PublicacionesId ) ) )
            {
               A381PublicacionesId = T001G15_A381PublicacionesId[0];
               AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
               RcdFound127 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1G127( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPublicacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1G127( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound127 == 1 )
            {
               if ( A381PublicacionesId != Z381PublicacionesId )
               {
                  A381PublicacionesId = Z381PublicacionesId;
                  AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PUBLICACIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtPublicacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPublicacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1G127( ) ;
                  GX_FocusControl = edtPublicacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A381PublicacionesId != Z381PublicacionesId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPublicacionesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1G127( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PUBLICACIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtPublicacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPublicacionesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1G127( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A381PublicacionesId != Z381PublicacionesId )
         {
            A381PublicacionesId = Z381PublicacionesId;
            AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PUBLICACIONESID");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPublicacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PUBLICACIONESID");
            AnyError = 1;
            GX_FocusControl = edtPublicacionesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPublicacionesTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1G127( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPublicacionesTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1G127( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPublicacionesTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPublicacionesTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1G127( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound127 != 0 )
            {
               ScanNext1G127( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPublicacionesTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1G127( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1G127( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G6 */
            pr_default.execute(4, new Object[] {A381PublicacionesId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Publicaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z382PublicacionesTitulo, T001G6_A382PublicacionesTitulo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z843PublicacionesFecTentInicio ) != DateTimeUtil.ResetTime ( T001G6_A843PublicacionesFecTentInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z844PublicacionesFecRealInicio ) != DateTimeUtil.ResetTime ( T001G6_A844PublicacionesFecRealInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z845PublicacionesFecFinPostulacion ) != DateTimeUtil.ResetTime ( T001G6_A845PublicacionesFecFinPostulacion[0] ) ) || ( StringUtil.StrCmp(Z846PublicacionesDetalleMateriales, T001G6_A846PublicacionesDetalleMateriales[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z847PublicacionesFecVisita ) != DateTimeUtil.ResetTime ( T001G6_A847PublicacionesFecVisita[0] ) ) || ( StringUtil.StrCmp(Z848PublicacionesHoraVisita, T001G6_A848PublicacionesHoraVisita[0]) != 0 ) || ( StringUtil.StrCmp(Z849PublicacionesDirVisita, T001G6_A849PublicacionesDirVisita[0]) != 0 ) || ( StringUtil.StrCmp(Z850PublicacionesCondiciones, T001G6_A850PublicacionesCondiciones[0]) != 0 ) || ( StringUtil.StrCmp(Z851PublicacionesTipoDesembolso, T001G6_A851PublicacionesTipoDesembolso[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z859PublicacionesOtroTipoDes, T001G6_A859PublicacionesOtroTipoDes[0]) != 0 ) || ( StringUtil.StrCmp(Z852PublicacionesModalidad, T001G6_A852PublicacionesModalidad[0]) != 0 ) || ( Z389PublicacionesPrecio != T001G6_A389PublicacionesPrecio[0] ) || ( DateTimeUtil.ResetTime ( Z854PublicacionesFecCierre ) != DateTimeUtil.ResetTime ( T001G6_A854PublicacionesFecCierre[0] ) ) || ( StringUtil.StrCmp(Z855PublicacionesDocReq, T001G6_A855PublicacionesDocReq[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z856PublicacionesDocDescripcion, T001G6_A856PublicacionesDocDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z857PublicacionesTipoEmpresa, T001G6_A857PublicacionesTipoEmpresa[0]) != 0 ) || ( StringUtil.StrCmp(Z858PublicacionesContratoId, T001G6_A858PublicacionesContratoId[0]) != 0 ) || ( StringUtil.StrCmp(Z860PublicacionesTerminoObra, T001G6_A860PublicacionesTerminoObra[0]) != 0 ) || ( StringUtil.StrCmp(Z384PublicacionesEstado, T001G6_A384PublicacionesEstado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z385PublicacionesSerialIma != T001G6_A385PublicacionesSerialIma[0] ) || ( Z395PublicacionesSerialRem != T001G6_A395PublicacionesSerialRem[0] ) || ( Z112DepartamentoId != T001G6_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != T001G6_A114DepartamentoMunicipioId[0] ) || ( Z118MonedaId != T001G6_A118MonedaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z382PublicacionesTitulo, T001G6_A382PublicacionesTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z382PublicacionesTitulo);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A382PublicacionesTitulo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z843PublicacionesFecTentInicio ) != DateTimeUtil.ResetTime ( T001G6_A843PublicacionesFecTentInicio[0] ) )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesFecTentInicio");
                  GXUtil.WriteLogRaw("Old: ",Z843PublicacionesFecTentInicio);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A843PublicacionesFecTentInicio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z844PublicacionesFecRealInicio ) != DateTimeUtil.ResetTime ( T001G6_A844PublicacionesFecRealInicio[0] ) )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesFecRealInicio");
                  GXUtil.WriteLogRaw("Old: ",Z844PublicacionesFecRealInicio);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A844PublicacionesFecRealInicio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z845PublicacionesFecFinPostulacion ) != DateTimeUtil.ResetTime ( T001G6_A845PublicacionesFecFinPostulacion[0] ) )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesFecFinPostulacion");
                  GXUtil.WriteLogRaw("Old: ",Z845PublicacionesFecFinPostulacion);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A845PublicacionesFecFinPostulacion[0]);
               }
               if ( StringUtil.StrCmp(Z846PublicacionesDetalleMateriales, T001G6_A846PublicacionesDetalleMateriales[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesDetalleMateriales");
                  GXUtil.WriteLogRaw("Old: ",Z846PublicacionesDetalleMateriales);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A846PublicacionesDetalleMateriales[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z847PublicacionesFecVisita ) != DateTimeUtil.ResetTime ( T001G6_A847PublicacionesFecVisita[0] ) )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesFecVisita");
                  GXUtil.WriteLogRaw("Old: ",Z847PublicacionesFecVisita);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A847PublicacionesFecVisita[0]);
               }
               if ( StringUtil.StrCmp(Z848PublicacionesHoraVisita, T001G6_A848PublicacionesHoraVisita[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesHoraVisita");
                  GXUtil.WriteLogRaw("Old: ",Z848PublicacionesHoraVisita);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A848PublicacionesHoraVisita[0]);
               }
               if ( StringUtil.StrCmp(Z849PublicacionesDirVisita, T001G6_A849PublicacionesDirVisita[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesDirVisita");
                  GXUtil.WriteLogRaw("Old: ",Z849PublicacionesDirVisita);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A849PublicacionesDirVisita[0]);
               }
               if ( StringUtil.StrCmp(Z850PublicacionesCondiciones, T001G6_A850PublicacionesCondiciones[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesCondiciones");
                  GXUtil.WriteLogRaw("Old: ",Z850PublicacionesCondiciones);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A850PublicacionesCondiciones[0]);
               }
               if ( StringUtil.StrCmp(Z851PublicacionesTipoDesembolso, T001G6_A851PublicacionesTipoDesembolso[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesTipoDesembolso");
                  GXUtil.WriteLogRaw("Old: ",Z851PublicacionesTipoDesembolso);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A851PublicacionesTipoDesembolso[0]);
               }
               if ( StringUtil.StrCmp(Z859PublicacionesOtroTipoDes, T001G6_A859PublicacionesOtroTipoDes[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesOtroTipoDes");
                  GXUtil.WriteLogRaw("Old: ",Z859PublicacionesOtroTipoDes);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A859PublicacionesOtroTipoDes[0]);
               }
               if ( StringUtil.StrCmp(Z852PublicacionesModalidad, T001G6_A852PublicacionesModalidad[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesModalidad");
                  GXUtil.WriteLogRaw("Old: ",Z852PublicacionesModalidad);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A852PublicacionesModalidad[0]);
               }
               if ( Z389PublicacionesPrecio != T001G6_A389PublicacionesPrecio[0] )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z389PublicacionesPrecio);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A389PublicacionesPrecio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z854PublicacionesFecCierre ) != DateTimeUtil.ResetTime ( T001G6_A854PublicacionesFecCierre[0] ) )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesFecCierre");
                  GXUtil.WriteLogRaw("Old: ",Z854PublicacionesFecCierre);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A854PublicacionesFecCierre[0]);
               }
               if ( StringUtil.StrCmp(Z855PublicacionesDocReq, T001G6_A855PublicacionesDocReq[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesDocReq");
                  GXUtil.WriteLogRaw("Old: ",Z855PublicacionesDocReq);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A855PublicacionesDocReq[0]);
               }
               if ( StringUtil.StrCmp(Z856PublicacionesDocDescripcion, T001G6_A856PublicacionesDocDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesDocDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z856PublicacionesDocDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A856PublicacionesDocDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z857PublicacionesTipoEmpresa, T001G6_A857PublicacionesTipoEmpresa[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesTipoEmpresa");
                  GXUtil.WriteLogRaw("Old: ",Z857PublicacionesTipoEmpresa);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A857PublicacionesTipoEmpresa[0]);
               }
               if ( StringUtil.StrCmp(Z858PublicacionesContratoId, T001G6_A858PublicacionesContratoId[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesContratoId");
                  GXUtil.WriteLogRaw("Old: ",Z858PublicacionesContratoId);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A858PublicacionesContratoId[0]);
               }
               if ( StringUtil.StrCmp(Z860PublicacionesTerminoObra, T001G6_A860PublicacionesTerminoObra[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesTerminoObra");
                  GXUtil.WriteLogRaw("Old: ",Z860PublicacionesTerminoObra);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A860PublicacionesTerminoObra[0]);
               }
               if ( StringUtil.StrCmp(Z384PublicacionesEstado, T001G6_A384PublicacionesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z384PublicacionesEstado);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A384PublicacionesEstado[0]);
               }
               if ( Z385PublicacionesSerialIma != T001G6_A385PublicacionesSerialIma[0] )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesSerialIma");
                  GXUtil.WriteLogRaw("Old: ",Z385PublicacionesSerialIma);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A385PublicacionesSerialIma[0]);
               }
               if ( Z395PublicacionesSerialRem != T001G6_A395PublicacionesSerialRem[0] )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesSerialRem");
                  GXUtil.WriteLogRaw("Old: ",Z395PublicacionesSerialRem);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A395PublicacionesSerialRem[0]);
               }
               if ( Z112DepartamentoId != T001G6_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A112DepartamentoId[0]);
               }
               if ( Z114DepartamentoMunicipioId != T001G6_A114DepartamentoMunicipioId[0] )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"DepartamentoMunicipioId");
                  GXUtil.WriteLogRaw("Old: ",Z114DepartamentoMunicipioId);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A114DepartamentoMunicipioId[0]);
               }
               if ( Z118MonedaId != T001G6_A118MonedaId[0] )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"MonedaId");
                  GXUtil.WriteLogRaw("Old: ",Z118MonedaId);
                  GXUtil.WriteLogRaw("Current: ",T001G6_A118MonedaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Publicaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G127( )
      {
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G127( 0) ;
            CheckOptimisticConcurrency1G127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G16 */
                     pr_default.execute(14, new Object[] {A382PublicacionesTitulo, A383PublicacionesDescripcion, A843PublicacionesFecTentInicio, A844PublicacionesFecRealInicio, A845PublicacionesFecFinPostulacion, A846PublicacionesDetalleMateriales, A847PublicacionesFecVisita, A848PublicacionesHoraVisita, A849PublicacionesDirVisita, A850PublicacionesCondiciones, A851PublicacionesTipoDesembolso, A859PublicacionesOtroTipoDes, A852PublicacionesModalidad, A389PublicacionesPrecio, A854PublicacionesFecCierre, A855PublicacionesDocReq, A856PublicacionesDocDescripcion, A857PublicacionesTipoEmpresa, A858PublicacionesContratoId, A860PublicacionesTerminoObra, A384PublicacionesEstado, A385PublicacionesSerialIma, A395PublicacionesSerialRem, A112DepartamentoId, A114DepartamentoMunicipioId, n118MonedaId, A118MonedaId});
                     A381PublicacionesId = T001G16_A381PublicacionesId[0];
                     AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Publicaciones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1G127( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1G0( ) ;
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
               Load1G127( ) ;
            }
            EndLevel1G127( ) ;
         }
         CloseExtendedTableCursors1G127( ) ;
      }

      protected void Update1G127( )
      {
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G17 */
                     pr_default.execute(15, new Object[] {A382PublicacionesTitulo, A383PublicacionesDescripcion, A843PublicacionesFecTentInicio, A844PublicacionesFecRealInicio, A845PublicacionesFecFinPostulacion, A846PublicacionesDetalleMateriales, A847PublicacionesFecVisita, A848PublicacionesHoraVisita, A849PublicacionesDirVisita, A850PublicacionesCondiciones, A851PublicacionesTipoDesembolso, A859PublicacionesOtroTipoDes, A852PublicacionesModalidad, A389PublicacionesPrecio, A854PublicacionesFecCierre, A855PublicacionesDocReq, A856PublicacionesDocDescripcion, A857PublicacionesTipoEmpresa, A858PublicacionesContratoId, A860PublicacionesTerminoObra, A384PublicacionesEstado, A385PublicacionesSerialIma, A395PublicacionesSerialRem, A112DepartamentoId, A114DepartamentoMunicipioId, n118MonedaId, A118MonedaId, A381PublicacionesId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Publicaciones");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Publicaciones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G127( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1G127( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1G0( ) ;
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
            EndLevel1G127( ) ;
         }
         CloseExtendedTableCursors1G127( ) ;
      }

      protected void DeferredUpdate1G127( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G127( ) ;
            AfterConfirm1G127( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G127( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1G129( ) ;
                  while ( RcdFound129 != 0 )
                  {
                     getByPrimaryKey1G129( ) ;
                     Delete1G129( ) ;
                     ScanNext1G129( ) ;
                  }
                  ScanEnd1G129( ) ;
                  ScanStart1G128( ) ;
                  while ( RcdFound128 != 0 )
                  {
                     getByPrimaryKey1G128( ) ;
                     Delete1G128( ) ;
                     ScanNext1G128( ) ;
                  }
                  ScanEnd1G128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G18 */
                     pr_default.execute(16, new Object[] {A381PublicacionesId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Publicaciones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound127 == 0 )
                           {
                              InitAll1G127( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption1G0( ) ;
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
         sMode127 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G127( ) ;
         Gx_mode = sMode127;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G127( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001G19 */
            pr_default.execute(17, new Object[] {n118MonedaId, A118MonedaId});
            A119MonedaISOSimbolo = T001G19_A119MonedaISOSimbolo[0];
            AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel1G128( )
      {
         nGXsfl_153_idx = 0;
         while ( nGXsfl_153_idx < nRC_GXsfl_153 )
         {
            ReadRow1G128( ) ;
            if ( ( nRcdExists_128 != 0 ) || ( nIsMod_128 != 0 ) )
            {
               standaloneNotModal1G128( ) ;
               GetKey1G128( ) ;
               if ( ( nRcdExists_128 == 0 ) && ( nRcdDeleted_128 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1G128( ) ;
               }
               else
               {
                  if ( RcdFound128 != 0 )
                  {
                     if ( ( nRcdDeleted_128 != 0 ) && ( nRcdExists_128 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1G128( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_128 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1G128( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_128 == 0 )
                     {
                        GXCCtl = "PUBLICACIONESDOCID_" + sGXsfl_153_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPublicacionesDocId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPublicacionesDocId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A386PublicacionesDocId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPublicacionesDoc_Internalname, A387PublicacionesDoc) ;
            ChangePostValue( edtPublicacionesDocDescrip_Internalname, A388PublicacionesDocDescrip) ;
            ChangePostValue( "ZT_"+"Z386PublicacionesDocId_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z386PublicacionesDocId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z387PublicacionesDoc_"+sGXsfl_153_idx, Z387PublicacionesDoc) ;
            ChangePostValue( "ZT_"+"Z388PublicacionesDocDescrip_"+sGXsfl_153_idx, Z388PublicacionesDocDescrip) ;
            ChangePostValue( "nRcdDeleted_128_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_128), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_128_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_128), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_128_"+sGXsfl_153_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_128), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_128 != 0 )
            {
               ChangePostValue( "PUBLICACIONESDOCID_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESDOC_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDoc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocDescrip_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1G128( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_128 = 0;
         nIsMod_128 = 0;
         nRcdDeleted_128 = 0;
      }

      protected void ProcessNestedLevel1G129( )
      {
         nGXsfl_162_idx = 0;
         while ( nGXsfl_162_idx < nRC_GXsfl_162 )
         {
            ReadRow1G129( ) ;
            if ( ( nRcdExists_129 != 0 ) || ( nIsMod_129 != 0 ) )
            {
               standaloneNotModal1G129( ) ;
               GetKey1G129( ) ;
               if ( ( nRcdExists_129 == 0 ) && ( nRcdDeleted_129 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1G129( ) ;
               }
               else
               {
                  if ( RcdFound129 != 0 )
                  {
                     if ( ( nRcdDeleted_129 != 0 ) && ( nRcdExists_129 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1G129( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_129 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1G129( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_129 == 0 )
                     {
                        GXCCtl = "PUBLICACIONESMULTID_" + sGXsfl_162_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPublicacionesMultId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPublicacionesMultId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A394PublicacionesMultId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPublicacionesMult_Internalname, A392PublicacionesMult) ;
            ChangePostValue( edtPublicacionesMultDescrip_Internalname, A861PublicacionesMultDescrip) ;
            ChangePostValue( "ZT_"+"Z394PublicacionesMultId_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z394PublicacionesMultId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z392PublicacionesMult_"+sGXsfl_162_idx, Z392PublicacionesMult) ;
            ChangePostValue( "ZT_"+"Z861PublicacionesMultDescrip_"+sGXsfl_162_idx, Z861PublicacionesMultDescrip) ;
            ChangePostValue( "nRcdDeleted_129_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_129), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_129_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_129), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_129_"+sGXsfl_162_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_129), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_129 != 0 )
            {
               ChangePostValue( "PUBLICACIONESMULTID_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESMULT_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMult_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultDescrip_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1G129( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_129 = 0;
         nIsMod_129 = 0;
         nRcdDeleted_129 = 0;
      }

      protected void ProcessLevel1G127( )
      {
         /* Save parent mode. */
         sMode127 = Gx_mode;
         ProcessNestedLevel1G128( ) ;
         ProcessNestedLevel1G129( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode127;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1G127( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            context.CommitDataStores("publicaciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            context.RollbackDataStores("publicaciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1G127( )
      {
         /* Scan By routine */
         /* Using cursor T001G20 */
         pr_default.execute(18);
         RcdFound127 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound127 = 1;
            A381PublicacionesId = T001G20_A381PublicacionesId[0];
            AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G127( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound127 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound127 = 1;
            A381PublicacionesId = T001G20_A381PublicacionesId[0];
            AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
         }
      }

      protected void ScanEnd1G127( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm1G127( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G127( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G127( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G127( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G127( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G127( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G127( )
      {
         edtPublicacionesId_Enabled = 0;
         AssignProp("", false, edtPublicacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesId_Enabled), 5, 0), true);
         edtPublicacionesTitulo_Enabled = 0;
         AssignProp("", false, edtPublicacionesTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesTitulo_Enabled), 5, 0), true);
         edtPublicacionesDescripcion_Enabled = 0;
         AssignProp("", false, edtPublicacionesDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDescripcion_Enabled), 5, 0), true);
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoMunicipioId_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), true);
         edtPublicacionesFecTentInicio_Enabled = 0;
         AssignProp("", false, edtPublicacionesFecTentInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesFecTentInicio_Enabled), 5, 0), true);
         edtPublicacionesFecRealInicio_Enabled = 0;
         AssignProp("", false, edtPublicacionesFecRealInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesFecRealInicio_Enabled), 5, 0), true);
         edtPublicacionesFecFinPostulacion_Enabled = 0;
         AssignProp("", false, edtPublicacionesFecFinPostulacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesFecFinPostulacion_Enabled), 5, 0), true);
         edtPublicacionesDetalleMateriales_Enabled = 0;
         AssignProp("", false, edtPublicacionesDetalleMateriales_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDetalleMateriales_Enabled), 5, 0), true);
         edtPublicacionesFecVisita_Enabled = 0;
         AssignProp("", false, edtPublicacionesFecVisita_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesFecVisita_Enabled), 5, 0), true);
         edtPublicacionesHoraVisita_Enabled = 0;
         AssignProp("", false, edtPublicacionesHoraVisita_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesHoraVisita_Enabled), 5, 0), true);
         edtPublicacionesDirVisita_Enabled = 0;
         AssignProp("", false, edtPublicacionesDirVisita_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDirVisita_Enabled), 5, 0), true);
         edtPublicacionesCondiciones_Enabled = 0;
         AssignProp("", false, edtPublicacionesCondiciones_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesCondiciones_Enabled), 5, 0), true);
         edtPublicacionesTipoDesembolso_Enabled = 0;
         AssignProp("", false, edtPublicacionesTipoDesembolso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesTipoDesembolso_Enabled), 5, 0), true);
         edtPublicacionesOtroTipoDes_Enabled = 0;
         AssignProp("", false, edtPublicacionesOtroTipoDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesOtroTipoDes_Enabled), 5, 0), true);
         edtPublicacionesModalidad_Enabled = 0;
         AssignProp("", false, edtPublicacionesModalidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesModalidad_Enabled), 5, 0), true);
         edtPublicacionesPrecio_Enabled = 0;
         AssignProp("", false, edtPublicacionesPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesPrecio_Enabled), 5, 0), true);
         dynMonedaId.Enabled = 0;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), true);
         edtMonedaISOSimbolo_Enabled = 0;
         AssignProp("", false, edtMonedaISOSimbolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaISOSimbolo_Enabled), 5, 0), true);
         edtPublicacionesFecCierre_Enabled = 0;
         AssignProp("", false, edtPublicacionesFecCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesFecCierre_Enabled), 5, 0), true);
         edtPublicacionesDocReq_Enabled = 0;
         AssignProp("", false, edtPublicacionesDocReq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocReq_Enabled), 5, 0), true);
         edtPublicacionesDocDescripcion_Enabled = 0;
         AssignProp("", false, edtPublicacionesDocDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocDescripcion_Enabled), 5, 0), true);
         edtPublicacionesTipoEmpresa_Enabled = 0;
         AssignProp("", false, edtPublicacionesTipoEmpresa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesTipoEmpresa_Enabled), 5, 0), true);
         edtPublicacionesContratoId_Enabled = 0;
         AssignProp("", false, edtPublicacionesContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesContratoId_Enabled), 5, 0), true);
         edtPublicacionesTerminoObra_Enabled = 0;
         AssignProp("", false, edtPublicacionesTerminoObra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesTerminoObra_Enabled), 5, 0), true);
         cmbPublicacionesEstado.Enabled = 0;
         AssignProp("", false, cmbPublicacionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPublicacionesEstado.Enabled), 5, 0), true);
         edtPublicacionesSerialIma_Enabled = 0;
         AssignProp("", false, edtPublicacionesSerialIma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesSerialIma_Enabled), 5, 0), true);
         edtPublicacionesSerialRem_Enabled = 0;
         AssignProp("", false, edtPublicacionesSerialRem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesSerialRem_Enabled), 5, 0), true);
      }

      protected void ZM1G128( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z387PublicacionesDoc = T001G5_A387PublicacionesDoc[0];
               Z388PublicacionesDocDescrip = T001G5_A388PublicacionesDocDescrip[0];
            }
            else
            {
               Z387PublicacionesDoc = A387PublicacionesDoc;
               Z388PublicacionesDocDescrip = A388PublicacionesDocDescrip;
            }
         }
         if ( GX_JID == -9 )
         {
            Z381PublicacionesId = A381PublicacionesId;
            Z386PublicacionesDocId = A386PublicacionesDocId;
            Z387PublicacionesDoc = A387PublicacionesDoc;
            Z388PublicacionesDocDescrip = A388PublicacionesDocDescrip;
         }
      }

      protected void standaloneNotModal1G128( )
      {
      }

      protected void standaloneModal1G128( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPublicacionesDocId_Enabled = 0;
            AssignProp("", false, edtPublicacionesDocId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocId_Enabled), 5, 0), !bGXsfl_153_Refreshing);
         }
         else
         {
            edtPublicacionesDocId_Enabled = 1;
            AssignProp("", false, edtPublicacionesDocId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocId_Enabled), 5, 0), !bGXsfl_153_Refreshing);
         }
      }

      protected void Load1G128( )
      {
         /* Using cursor T001G21 */
         pr_default.execute(19, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound128 = 1;
            A387PublicacionesDoc = T001G21_A387PublicacionesDoc[0];
            A388PublicacionesDocDescrip = T001G21_A388PublicacionesDocDescrip[0];
            ZM1G128( -9) ;
         }
         pr_default.close(19);
         OnLoadActions1G128( ) ;
      }

      protected void OnLoadActions1G128( )
      {
      }

      protected void CheckExtendedTable1G128( )
      {
         nIsDirty_128 = 0;
         Gx_BScreen = 1;
         standaloneModal1G128( ) ;
      }

      protected void CloseExtendedTableCursors1G128( )
      {
      }

      protected void enableDisable1G128( )
      {
      }

      protected void GetKey1G128( )
      {
         /* Using cursor T001G22 */
         pr_default.execute(20, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound128 = 1;
         }
         else
         {
            RcdFound128 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey1G128( )
      {
         /* Using cursor T001G5 */
         pr_default.execute(3, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1G128( 9) ;
            RcdFound128 = 1;
            InitializeNonKey1G128( ) ;
            A386PublicacionesDocId = T001G5_A386PublicacionesDocId[0];
            A387PublicacionesDoc = T001G5_A387PublicacionesDoc[0];
            A388PublicacionesDocDescrip = T001G5_A388PublicacionesDocDescrip[0];
            Z381PublicacionesId = A381PublicacionesId;
            Z386PublicacionesDocId = A386PublicacionesDocId;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1G128( ) ;
            Load1G128( ) ;
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound128 = 0;
            InitializeNonKey1G128( ) ;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1G128( ) ;
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1G128( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency1G128( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G4 */
            pr_default.execute(2, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesDocumento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z387PublicacionesDoc, T001G4_A387PublicacionesDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z388PublicacionesDocDescrip, T001G4_A388PublicacionesDocDescrip[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z387PublicacionesDoc, T001G4_A387PublicacionesDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesDoc");
                  GXUtil.WriteLogRaw("Old: ",Z387PublicacionesDoc);
                  GXUtil.WriteLogRaw("Current: ",T001G4_A387PublicacionesDoc[0]);
               }
               if ( StringUtil.StrCmp(Z388PublicacionesDocDescrip, T001G4_A388PublicacionesDocDescrip[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesDocDescrip");
                  GXUtil.WriteLogRaw("Old: ",Z388PublicacionesDocDescrip);
                  GXUtil.WriteLogRaw("Current: ",T001G4_A388PublicacionesDocDescrip[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PublicacionesDocumento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G128( )
      {
         BeforeValidate1G128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G128( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G128( 0) ;
            CheckOptimisticConcurrency1G128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G23 */
                     pr_default.execute(21, new Object[] {A381PublicacionesId, A386PublicacionesDocId, A387PublicacionesDoc, A388PublicacionesDocDescrip});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("PublicacionesDocumento");
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
               Load1G128( ) ;
            }
            EndLevel1G128( ) ;
         }
         CloseExtendedTableCursors1G128( ) ;
      }

      protected void Update1G128( )
      {
         BeforeValidate1G128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G128( ) ;
         }
         if ( ( nIsMod_128 != 0 ) || ( nIsDirty_128 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1G128( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1G128( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1G128( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001G24 */
                        pr_default.execute(22, new Object[] {A387PublicacionesDoc, A388PublicacionesDocDescrip, A381PublicacionesId, A386PublicacionesDocId});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("PublicacionesDocumento");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesDocumento"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1G128( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1G128( ) ;
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
               EndLevel1G128( ) ;
            }
         }
         CloseExtendedTableCursors1G128( ) ;
      }

      protected void DeferredUpdate1G128( )
      {
      }

      protected void Delete1G128( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1G128( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G128( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G128( ) ;
            AfterConfirm1G128( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G128( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001G25 */
                  pr_default.execute(23, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("PublicacionesDocumento");
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
         sMode128 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G128( ) ;
         Gx_mode = sMode128;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G128( )
      {
         standaloneModal1G128( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1G128( )
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

      public void ScanStart1G128( )
      {
         /* Scan By routine */
         /* Using cursor T001G26 */
         pr_default.execute(24, new Object[] {A381PublicacionesId});
         RcdFound128 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound128 = 1;
            A386PublicacionesDocId = T001G26_A386PublicacionesDocId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G128( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound128 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound128 = 1;
            A386PublicacionesDocId = T001G26_A386PublicacionesDocId[0];
         }
      }

      protected void ScanEnd1G128( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm1G128( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G128( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G128( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G128( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G128( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G128( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G128( )
      {
         edtPublicacionesDocId_Enabled = 0;
         AssignProp("", false, edtPublicacionesDocId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocId_Enabled), 5, 0), !bGXsfl_153_Refreshing);
         edtPublicacionesDoc_Enabled = 0;
         AssignProp("", false, edtPublicacionesDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDoc_Enabled), 5, 0), !bGXsfl_153_Refreshing);
         edtPublicacionesDocDescrip_Enabled = 0;
         AssignProp("", false, edtPublicacionesDocDescrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocDescrip_Enabled), 5, 0), !bGXsfl_153_Refreshing);
      }

      protected void send_integrity_lvl_hashes1G128( )
      {
      }

      protected void ZM1G129( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z392PublicacionesMult = T001G3_A392PublicacionesMult[0];
               Z861PublicacionesMultDescrip = T001G3_A861PublicacionesMultDescrip[0];
            }
            else
            {
               Z392PublicacionesMult = A392PublicacionesMult;
               Z861PublicacionesMultDescrip = A861PublicacionesMultDescrip;
            }
         }
         if ( GX_JID == -10 )
         {
            Z381PublicacionesId = A381PublicacionesId;
            Z394PublicacionesMultId = A394PublicacionesMultId;
            Z392PublicacionesMult = A392PublicacionesMult;
            Z861PublicacionesMultDescrip = A861PublicacionesMultDescrip;
         }
      }

      protected void standaloneNotModal1G129( )
      {
      }

      protected void standaloneModal1G129( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPublicacionesMultId_Enabled = 0;
            AssignProp("", false, edtPublicacionesMultId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultId_Enabled), 5, 0), !bGXsfl_162_Refreshing);
         }
         else
         {
            edtPublicacionesMultId_Enabled = 1;
            AssignProp("", false, edtPublicacionesMultId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultId_Enabled), 5, 0), !bGXsfl_162_Refreshing);
         }
      }

      protected void Load1G129( )
      {
         /* Using cursor T001G27 */
         pr_default.execute(25, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound129 = 1;
            A392PublicacionesMult = T001G27_A392PublicacionesMult[0];
            A861PublicacionesMultDescrip = T001G27_A861PublicacionesMultDescrip[0];
            ZM1G129( -10) ;
         }
         pr_default.close(25);
         OnLoadActions1G129( ) ;
      }

      protected void OnLoadActions1G129( )
      {
      }

      protected void CheckExtendedTable1G129( )
      {
         nIsDirty_129 = 0;
         Gx_BScreen = 1;
         standaloneModal1G129( ) ;
      }

      protected void CloseExtendedTableCursors1G129( )
      {
      }

      protected void enableDisable1G129( )
      {
      }

      protected void GetKey1G129( )
      {
         /* Using cursor T001G28 */
         pr_default.execute(26, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound129 = 1;
         }
         else
         {
            RcdFound129 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey1G129( )
      {
         /* Using cursor T001G3 */
         pr_default.execute(1, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G129( 10) ;
            RcdFound129 = 1;
            InitializeNonKey1G129( ) ;
            A394PublicacionesMultId = T001G3_A394PublicacionesMultId[0];
            A392PublicacionesMult = T001G3_A392PublicacionesMult[0];
            A861PublicacionesMultDescrip = T001G3_A861PublicacionesMultDescrip[0];
            Z381PublicacionesId = A381PublicacionesId;
            Z394PublicacionesMultId = A394PublicacionesMultId;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1G129( ) ;
            Load1G129( ) ;
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound129 = 0;
            InitializeNonKey1G129( ) ;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1G129( ) ;
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1G129( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1G129( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G2 */
            pr_default.execute(0, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesMultimedia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z392PublicacionesMult, T001G2_A392PublicacionesMult[0]) != 0 ) || ( StringUtil.StrCmp(Z861PublicacionesMultDescrip, T001G2_A861PublicacionesMultDescrip[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z392PublicacionesMult, T001G2_A392PublicacionesMult[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesMult");
                  GXUtil.WriteLogRaw("Old: ",Z392PublicacionesMult);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A392PublicacionesMult[0]);
               }
               if ( StringUtil.StrCmp(Z861PublicacionesMultDescrip, T001G2_A861PublicacionesMultDescrip[0]) != 0 )
               {
                  GXUtil.WriteLog("publicaciones:[seudo value changed for attri]"+"PublicacionesMultDescrip");
                  GXUtil.WriteLogRaw("Old: ",Z861PublicacionesMultDescrip);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A861PublicacionesMultDescrip[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PublicacionesMultimedia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G129( )
      {
         BeforeValidate1G129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G129( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G129( 0) ;
            CheckOptimisticConcurrency1G129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G29 */
                     pr_default.execute(27, new Object[] {A381PublicacionesId, A394PublicacionesMultId, A392PublicacionesMult, A861PublicacionesMultDescrip});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("PublicacionesMultimedia");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load1G129( ) ;
            }
            EndLevel1G129( ) ;
         }
         CloseExtendedTableCursors1G129( ) ;
      }

      protected void Update1G129( )
      {
         BeforeValidate1G129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G129( ) ;
         }
         if ( ( nIsMod_129 != 0 ) || ( nIsDirty_129 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1G129( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1G129( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1G129( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001G30 */
                        pr_default.execute(28, new Object[] {A392PublicacionesMult, A861PublicacionesMultDescrip, A381PublicacionesId, A394PublicacionesMultId});
                        pr_default.close(28);
                        pr_default.SmartCacheProvider.SetUpdated("PublicacionesMultimedia");
                        if ( (pr_default.getStatus(28) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesMultimedia"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1G129( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1G129( ) ;
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
               EndLevel1G129( ) ;
            }
         }
         CloseExtendedTableCursors1G129( ) ;
      }

      protected void DeferredUpdate1G129( )
      {
      }

      protected void Delete1G129( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1G129( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G129( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G129( ) ;
            AfterConfirm1G129( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G129( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001G31 */
                  pr_default.execute(29, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
                  pr_default.close(29);
                  pr_default.SmartCacheProvider.SetUpdated("PublicacionesMultimedia");
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
         sMode129 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G129( ) ;
         Gx_mode = sMode129;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G129( )
      {
         standaloneModal1G129( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1G129( )
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

      public void ScanStart1G129( )
      {
         /* Scan By routine */
         /* Using cursor T001G32 */
         pr_default.execute(30, new Object[] {A381PublicacionesId});
         RcdFound129 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound129 = 1;
            A394PublicacionesMultId = T001G32_A394PublicacionesMultId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G129( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound129 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound129 = 1;
            A394PublicacionesMultId = T001G32_A394PublicacionesMultId[0];
         }
      }

      protected void ScanEnd1G129( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm1G129( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G129( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G129( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G129( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G129( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G129( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G129( )
      {
         edtPublicacionesMultId_Enabled = 0;
         AssignProp("", false, edtPublicacionesMultId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultId_Enabled), 5, 0), !bGXsfl_162_Refreshing);
         edtPublicacionesMult_Enabled = 0;
         AssignProp("", false, edtPublicacionesMult_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMult_Enabled), 5, 0), !bGXsfl_162_Refreshing);
         edtPublicacionesMultDescrip_Enabled = 0;
         AssignProp("", false, edtPublicacionesMultDescrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultDescrip_Enabled), 5, 0), !bGXsfl_162_Refreshing);
      }

      protected void send_integrity_lvl_hashes1G129( )
      {
      }

      protected void send_integrity_lvl_hashes1G127( )
      {
      }

      protected void SubsflControlProps_153128( )
      {
         edtPublicacionesDocId_Internalname = "PUBLICACIONESDOCID_"+sGXsfl_153_idx;
         edtPublicacionesDoc_Internalname = "PUBLICACIONESDOC_"+sGXsfl_153_idx;
         edtPublicacionesDocDescrip_Internalname = "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_idx;
      }

      protected void SubsflControlProps_fel_153128( )
      {
         edtPublicacionesDocId_Internalname = "PUBLICACIONESDOCID_"+sGXsfl_153_fel_idx;
         edtPublicacionesDoc_Internalname = "PUBLICACIONESDOC_"+sGXsfl_153_fel_idx;
         edtPublicacionesDocDescrip_Internalname = "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_fel_idx;
      }

      protected void AddRow1G128( )
      {
         nGXsfl_153_idx = (int)(nGXsfl_153_idx+1);
         sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
         SubsflControlProps_153128( ) ;
         SendRow1G128( ) ;
      }

      protected void SendRow1G128( )
      {
         Gridlevel_documentoRow = GXWebRow.GetNew(context);
         if ( subGridlevel_documento_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_documento_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_documento_Class, "") != 0 )
            {
               subGridlevel_documento_Linesclass = subGridlevel_documento_Class+"Odd";
            }
         }
         else if ( subGridlevel_documento_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_documento_Backstyle = 0;
            subGridlevel_documento_Backcolor = subGridlevel_documento_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_documento_Class, "") != 0 )
            {
               subGridlevel_documento_Linesclass = subGridlevel_documento_Class+"Uniform";
            }
         }
         else if ( subGridlevel_documento_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_documento_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_documento_Class, "") != 0 )
            {
               subGridlevel_documento_Linesclass = subGridlevel_documento_Class+"Odd";
            }
            subGridlevel_documento_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_documento_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_documento_Backstyle = 1;
            if ( ((int)((nGXsfl_153_idx) % (2))) == 0 )
            {
               subGridlevel_documento_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_documento_Class, "") != 0 )
               {
                  subGridlevel_documento_Linesclass = subGridlevel_documento_Class+"Even";
               }
            }
            else
            {
               subGridlevel_documento_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_documento_Class, "") != 0 )
               {
                  subGridlevel_documento_Linesclass = subGridlevel_documento_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_128_" + sGXsfl_153_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 154,'',false,'" + sGXsfl_153_idx + "',153)\"";
         ROClassString = "Attribute";
         Gridlevel_documentoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesDocId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A386PublicacionesDocId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A386PublicacionesDocId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,154);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPublicacionesDocId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPublicacionesDocId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)153,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_128_" + sGXsfl_153_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 155,'',false,'" + sGXsfl_153_idx + "',153)\"";
         ROClassString = "Attribute";
         Gridlevel_documentoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesDoc_Internalname,(string)A387PublicacionesDoc,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPublicacionesDoc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPublicacionesDoc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)153,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_128_" + sGXsfl_153_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 156,'',false,'" + sGXsfl_153_idx + "',153)\"";
         ROClassString = "Attribute";
         Gridlevel_documentoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesDocDescrip_Internalname,(string)A388PublicacionesDocDescrip,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",context.GetMessage( "Descripción", ""),context.GetMessage( "Descripción", ""),(string)edtPublicacionesDocDescrip_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPublicacionesDocDescrip_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)153,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_documentoRow);
         send_integrity_lvl_hashes1G128( ) ;
         GXCCtl = "Z386PublicacionesDocId_" + sGXsfl_153_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z386PublicacionesDocId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z387PublicacionesDoc_" + sGXsfl_153_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z387PublicacionesDoc);
         GXCCtl = "Z388PublicacionesDocDescrip_" + sGXsfl_153_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z388PublicacionesDocDescrip);
         GXCCtl = "nRcdDeleted_128_" + sGXsfl_153_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_128), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_128_" + sGXsfl_153_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_128), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_128_" + sGXsfl_153_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_128), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESDOCID_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESDOC_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDoc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocDescrip_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_documentoContainer.AddRow(Gridlevel_documentoRow);
      }

      protected void ReadRow1G128( )
      {
         nGXsfl_153_idx = (int)(nGXsfl_153_idx+1);
         sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
         SubsflControlProps_153128( ) ;
         edtPublicacionesDocId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESDOCID_"+sGXsfl_153_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPublicacionesDoc_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESDOC_"+sGXsfl_153_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPublicacionesDocDescrip_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESDOCDESCRIP_"+sGXsfl_153_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtPublicacionesDocId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPublicacionesDocId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PUBLICACIONESDOCID_" + sGXsfl_153_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPublicacionesDocId_Internalname;
            wbErr = true;
            A386PublicacionesDocId = 0;
         }
         else
         {
            A386PublicacionesDocId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPublicacionesDocId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A387PublicacionesDoc = cgiGet( edtPublicacionesDoc_Internalname);
         A388PublicacionesDocDescrip = cgiGet( edtPublicacionesDocDescrip_Internalname);
         GXCCtl = "Z386PublicacionesDocId_" + sGXsfl_153_idx;
         Z386PublicacionesDocId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z387PublicacionesDoc_" + sGXsfl_153_idx;
         Z387PublicacionesDoc = cgiGet( GXCCtl);
         GXCCtl = "Z388PublicacionesDocDescrip_" + sGXsfl_153_idx;
         Z388PublicacionesDocDescrip = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_128_" + sGXsfl_153_idx;
         nRcdDeleted_128 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_128_" + sGXsfl_153_idx;
         nRcdExists_128 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_128_" + sGXsfl_153_idx;
         nIsMod_128 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_162129( )
      {
         edtPublicacionesMultId_Internalname = "PUBLICACIONESMULTID_"+sGXsfl_162_idx;
         edtPublicacionesMult_Internalname = "PUBLICACIONESMULT_"+sGXsfl_162_idx;
         edtPublicacionesMultDescrip_Internalname = "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_idx;
      }

      protected void SubsflControlProps_fel_162129( )
      {
         edtPublicacionesMultId_Internalname = "PUBLICACIONESMULTID_"+sGXsfl_162_fel_idx;
         edtPublicacionesMult_Internalname = "PUBLICACIONESMULT_"+sGXsfl_162_fel_idx;
         edtPublicacionesMultDescrip_Internalname = "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_fel_idx;
      }

      protected void AddRow1G129( )
      {
         nGXsfl_162_idx = (int)(nGXsfl_162_idx+1);
         sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx), 4, 0), 4, "0");
         SubsflControlProps_162129( ) ;
         SendRow1G129( ) ;
      }

      protected void SendRow1G129( )
      {
         Gridlevel_multimediaRow = GXWebRow.GetNew(context);
         if ( subGridlevel_multimedia_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
            {
               subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Odd";
            }
         }
         else if ( subGridlevel_multimedia_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 0;
            subGridlevel_multimedia_Backcolor = subGridlevel_multimedia_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
            {
               subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Uniform";
            }
         }
         else if ( subGridlevel_multimedia_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
            {
               subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Odd";
            }
            subGridlevel_multimedia_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_multimedia_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_multimedia_Backstyle = 1;
            if ( ((int)((nGXsfl_162_idx) % (2))) == 0 )
            {
               subGridlevel_multimedia_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
               {
                  subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Even";
               }
            }
            else
            {
               subGridlevel_multimedia_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_multimedia_Class, "") != 0 )
               {
                  subGridlevel_multimedia_Linesclass = subGridlevel_multimedia_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_129_" + sGXsfl_162_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 163,'',false,'" + sGXsfl_162_idx + "',162)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesMultId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A394PublicacionesMultId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A394PublicacionesMultId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,163);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPublicacionesMultId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPublicacionesMultId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)162,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_129_" + sGXsfl_162_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_162_idx + "',162)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesMult_Internalname,(string)A392PublicacionesMult,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPublicacionesMult_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPublicacionesMult_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)162,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_129_" + sGXsfl_162_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_162_idx + "',162)\"";
         ROClassString = "Attribute";
         Gridlevel_multimediaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesMultDescrip_Internalname,(string)A861PublicacionesMultDescrip,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,165);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPublicacionesMultDescrip_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPublicacionesMultDescrip_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)162,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_multimediaRow);
         send_integrity_lvl_hashes1G129( ) ;
         GXCCtl = "Z394PublicacionesMultId_" + sGXsfl_162_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z394PublicacionesMultId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z392PublicacionesMult_" + sGXsfl_162_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z392PublicacionesMult);
         GXCCtl = "Z861PublicacionesMultDescrip_" + sGXsfl_162_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z861PublicacionesMultDescrip);
         GXCCtl = "nRcdDeleted_129_" + sGXsfl_162_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_129), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_129_" + sGXsfl_162_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_129), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_129_" + sGXsfl_162_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_129), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESMULTID_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESMULT_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMult_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultDescrip_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_multimediaContainer.AddRow(Gridlevel_multimediaRow);
      }

      protected void ReadRow1G129( )
      {
         nGXsfl_162_idx = (int)(nGXsfl_162_idx+1);
         sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx), 4, 0), 4, "0");
         SubsflControlProps_162129( ) ;
         edtPublicacionesMultId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESMULTID_"+sGXsfl_162_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPublicacionesMult_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESMULT_"+sGXsfl_162_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPublicacionesMultDescrip_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PUBLICACIONESMULTDESCRIP_"+sGXsfl_162_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtPublicacionesMultId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPublicacionesMultId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PUBLICACIONESMULTID_" + sGXsfl_162_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPublicacionesMultId_Internalname;
            wbErr = true;
            A394PublicacionesMultId = 0;
         }
         else
         {
            A394PublicacionesMultId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPublicacionesMultId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A392PublicacionesMult = cgiGet( edtPublicacionesMult_Internalname);
         A861PublicacionesMultDescrip = cgiGet( edtPublicacionesMultDescrip_Internalname);
         GXCCtl = "Z394PublicacionesMultId_" + sGXsfl_162_idx;
         Z394PublicacionesMultId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z392PublicacionesMult_" + sGXsfl_162_idx;
         Z392PublicacionesMult = cgiGet( GXCCtl);
         GXCCtl = "Z861PublicacionesMultDescrip_" + sGXsfl_162_idx;
         Z861PublicacionesMultDescrip = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_129_" + sGXsfl_162_idx;
         nRcdDeleted_129 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_129_" + sGXsfl_162_idx;
         nRcdExists_129 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_129_" + sGXsfl_162_idx;
         nIsMod_129 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPublicacionesMultId_Enabled = edtPublicacionesMultId_Enabled;
         defedtPublicacionesDocId_Enabled = edtPublicacionesDocId_Enabled;
      }

      protected void ConfirmValues1G0( )
      {
         nGXsfl_153_idx = 0;
         sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
         SubsflControlProps_153128( ) ;
         while ( nGXsfl_153_idx < nRC_GXsfl_153 )
         {
            nGXsfl_153_idx = (int)(nGXsfl_153_idx+1);
            sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
            SubsflControlProps_153128( ) ;
            ChangePostValue( "Z386PublicacionesDocId_"+sGXsfl_153_idx, cgiGet( "ZT_"+"Z386PublicacionesDocId_"+sGXsfl_153_idx)) ;
            DeletePostValue( "ZT_"+"Z386PublicacionesDocId_"+sGXsfl_153_idx) ;
            ChangePostValue( "Z387PublicacionesDoc_"+sGXsfl_153_idx, cgiGet( "ZT_"+"Z387PublicacionesDoc_"+sGXsfl_153_idx)) ;
            DeletePostValue( "ZT_"+"Z387PublicacionesDoc_"+sGXsfl_153_idx) ;
            ChangePostValue( "Z388PublicacionesDocDescrip_"+sGXsfl_153_idx, cgiGet( "ZT_"+"Z388PublicacionesDocDescrip_"+sGXsfl_153_idx)) ;
            DeletePostValue( "ZT_"+"Z388PublicacionesDocDescrip_"+sGXsfl_153_idx) ;
         }
         nGXsfl_162_idx = 0;
         sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx), 4, 0), 4, "0");
         SubsflControlProps_162129( ) ;
         while ( nGXsfl_162_idx < nRC_GXsfl_162 )
         {
            nGXsfl_162_idx = (int)(nGXsfl_162_idx+1);
            sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx), 4, 0), 4, "0");
            SubsflControlProps_162129( ) ;
            ChangePostValue( "Z394PublicacionesMultId_"+sGXsfl_162_idx, cgiGet( "ZT_"+"Z394PublicacionesMultId_"+sGXsfl_162_idx)) ;
            DeletePostValue( "ZT_"+"Z394PublicacionesMultId_"+sGXsfl_162_idx) ;
            ChangePostValue( "Z392PublicacionesMult_"+sGXsfl_162_idx, cgiGet( "ZT_"+"Z392PublicacionesMult_"+sGXsfl_162_idx)) ;
            DeletePostValue( "ZT_"+"Z392PublicacionesMult_"+sGXsfl_162_idx) ;
            ChangePostValue( "Z861PublicacionesMultDescrip_"+sGXsfl_162_idx, cgiGet( "ZT_"+"Z861PublicacionesMultDescrip_"+sGXsfl_162_idx)) ;
            DeletePostValue( "ZT_"+"Z861PublicacionesMultDescrip_"+sGXsfl_162_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("publicaciones.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z381PublicacionesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381PublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z382PublicacionesTitulo", StringUtil.RTrim( Z382PublicacionesTitulo));
         GxWebStd.gx_hidden_field( context, "Z843PublicacionesFecTentInicio", context.localUtil.DToC( Z843PublicacionesFecTentInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z844PublicacionesFecRealInicio", context.localUtil.DToC( Z844PublicacionesFecRealInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z845PublicacionesFecFinPostulacion", context.localUtil.DToC( Z845PublicacionesFecFinPostulacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z846PublicacionesDetalleMateriales", StringUtil.RTrim( Z846PublicacionesDetalleMateriales));
         GxWebStd.gx_hidden_field( context, "Z847PublicacionesFecVisita", context.localUtil.DToC( Z847PublicacionesFecVisita, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z848PublicacionesHoraVisita", StringUtil.RTrim( Z848PublicacionesHoraVisita));
         GxWebStd.gx_hidden_field( context, "Z849PublicacionesDirVisita", Z849PublicacionesDirVisita);
         GxWebStd.gx_hidden_field( context, "Z850PublicacionesCondiciones", Z850PublicacionesCondiciones);
         GxWebStd.gx_hidden_field( context, "Z851PublicacionesTipoDesembolso", Z851PublicacionesTipoDesembolso);
         GxWebStd.gx_hidden_field( context, "Z859PublicacionesOtroTipoDes", Z859PublicacionesOtroTipoDes);
         GxWebStd.gx_hidden_field( context, "Z852PublicacionesModalidad", StringUtil.RTrim( Z852PublicacionesModalidad));
         GxWebStd.gx_hidden_field( context, "Z389PublicacionesPrecio", StringUtil.LTrim( StringUtil.NToC( Z389PublicacionesPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z854PublicacionesFecCierre", context.localUtil.DToC( Z854PublicacionesFecCierre, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z855PublicacionesDocReq", Z855PublicacionesDocReq);
         GxWebStd.gx_hidden_field( context, "Z856PublicacionesDocDescripcion", Z856PublicacionesDocDescripcion);
         GxWebStd.gx_hidden_field( context, "Z857PublicacionesTipoEmpresa", Z857PublicacionesTipoEmpresa);
         GxWebStd.gx_hidden_field( context, "Z858PublicacionesContratoId", Z858PublicacionesContratoId);
         GxWebStd.gx_hidden_field( context, "Z860PublicacionesTerminoObra", Z860PublicacionesTerminoObra);
         GxWebStd.gx_hidden_field( context, "Z384PublicacionesEstado", StringUtil.RTrim( Z384PublicacionesEstado));
         GxWebStd.gx_hidden_field( context, "Z385PublicacionesSerialIma", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z385PublicacionesSerialIma), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z395PublicacionesSerialRem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z395PublicacionesSerialRem), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_153", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_153_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_162", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_162_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("publicaciones.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Publicaciones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Publicaciones", "") ;
      }

      protected void InitializeNonKey1G127( )
      {
         A382PublicacionesTitulo = "";
         AssignAttri("", false, "A382PublicacionesTitulo", A382PublicacionesTitulo);
         A383PublicacionesDescripcion = "";
         AssignAttri("", false, "A383PublicacionesDescripcion", A383PublicacionesDescripcion);
         A112DepartamentoId = 0;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         A114DepartamentoMunicipioId = 0;
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         A843PublicacionesFecTentInicio = DateTime.MinValue;
         AssignAttri("", false, "A843PublicacionesFecTentInicio", context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"));
         A844PublicacionesFecRealInicio = DateTime.MinValue;
         AssignAttri("", false, "A844PublicacionesFecRealInicio", context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"));
         A845PublicacionesFecFinPostulacion = DateTime.MinValue;
         AssignAttri("", false, "A845PublicacionesFecFinPostulacion", context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"));
         A846PublicacionesDetalleMateriales = "";
         AssignAttri("", false, "A846PublicacionesDetalleMateriales", A846PublicacionesDetalleMateriales);
         A847PublicacionesFecVisita = DateTime.MinValue;
         AssignAttri("", false, "A847PublicacionesFecVisita", context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"));
         A848PublicacionesHoraVisita = "";
         AssignAttri("", false, "A848PublicacionesHoraVisita", A848PublicacionesHoraVisita);
         A849PublicacionesDirVisita = "";
         AssignAttri("", false, "A849PublicacionesDirVisita", A849PublicacionesDirVisita);
         A850PublicacionesCondiciones = "";
         AssignAttri("", false, "A850PublicacionesCondiciones", A850PublicacionesCondiciones);
         A851PublicacionesTipoDesembolso = "";
         AssignAttri("", false, "A851PublicacionesTipoDesembolso", A851PublicacionesTipoDesembolso);
         A859PublicacionesOtroTipoDes = "";
         AssignAttri("", false, "A859PublicacionesOtroTipoDes", A859PublicacionesOtroTipoDes);
         A852PublicacionesModalidad = "";
         AssignAttri("", false, "A852PublicacionesModalidad", A852PublicacionesModalidad);
         A389PublicacionesPrecio = 0;
         AssignAttri("", false, "A389PublicacionesPrecio", StringUtil.LTrimStr( A389PublicacionesPrecio, 18, 2));
         A118MonedaId = 0;
         n118MonedaId = false;
         AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         n118MonedaId = ((0==A118MonedaId) ? true : false);
         A119MonedaISOSimbolo = "";
         AssignAttri("", false, "A119MonedaISOSimbolo", A119MonedaISOSimbolo);
         A854PublicacionesFecCierre = DateTime.MinValue;
         AssignAttri("", false, "A854PublicacionesFecCierre", context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"));
         A855PublicacionesDocReq = "";
         AssignAttri("", false, "A855PublicacionesDocReq", A855PublicacionesDocReq);
         A856PublicacionesDocDescripcion = "";
         AssignAttri("", false, "A856PublicacionesDocDescripcion", A856PublicacionesDocDescripcion);
         A857PublicacionesTipoEmpresa = "";
         AssignAttri("", false, "A857PublicacionesTipoEmpresa", A857PublicacionesTipoEmpresa);
         A858PublicacionesContratoId = "";
         AssignAttri("", false, "A858PublicacionesContratoId", A858PublicacionesContratoId);
         A860PublicacionesTerminoObra = "";
         AssignAttri("", false, "A860PublicacionesTerminoObra", A860PublicacionesTerminoObra);
         A384PublicacionesEstado = "";
         AssignAttri("", false, "A384PublicacionesEstado", A384PublicacionesEstado);
         A385PublicacionesSerialIma = 0;
         AssignAttri("", false, "A385PublicacionesSerialIma", StringUtil.LTrimStr( (decimal)(A385PublicacionesSerialIma), 4, 0));
         A395PublicacionesSerialRem = 0;
         AssignAttri("", false, "A395PublicacionesSerialRem", StringUtil.LTrimStr( (decimal)(A395PublicacionesSerialRem), 4, 0));
         Z382PublicacionesTitulo = "";
         Z843PublicacionesFecTentInicio = DateTime.MinValue;
         Z844PublicacionesFecRealInicio = DateTime.MinValue;
         Z845PublicacionesFecFinPostulacion = DateTime.MinValue;
         Z846PublicacionesDetalleMateriales = "";
         Z847PublicacionesFecVisita = DateTime.MinValue;
         Z848PublicacionesHoraVisita = "";
         Z849PublicacionesDirVisita = "";
         Z850PublicacionesCondiciones = "";
         Z851PublicacionesTipoDesembolso = "";
         Z859PublicacionesOtroTipoDes = "";
         Z852PublicacionesModalidad = "";
         Z389PublicacionesPrecio = 0;
         Z854PublicacionesFecCierre = DateTime.MinValue;
         Z855PublicacionesDocReq = "";
         Z856PublicacionesDocDescripcion = "";
         Z857PublicacionesTipoEmpresa = "";
         Z858PublicacionesContratoId = "";
         Z860PublicacionesTerminoObra = "";
         Z384PublicacionesEstado = "";
         Z385PublicacionesSerialIma = 0;
         Z395PublicacionesSerialRem = 0;
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll1G127( )
      {
         A381PublicacionesId = 0;
         AssignAttri("", false, "A381PublicacionesId", StringUtil.LTrimStr( (decimal)(A381PublicacionesId), 18, 0));
         InitializeNonKey1G127( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1G128( )
      {
         A387PublicacionesDoc = "";
         A388PublicacionesDocDescrip = "";
         Z387PublicacionesDoc = "";
         Z388PublicacionesDocDescrip = "";
      }

      protected void InitAll1G128( )
      {
         A386PublicacionesDocId = 0;
         InitializeNonKey1G128( ) ;
      }

      protected void StandaloneModalInsert1G128( )
      {
      }

      protected void InitializeNonKey1G129( )
      {
         A392PublicacionesMult = "";
         A861PublicacionesMultDescrip = "";
         Z392PublicacionesMult = "";
         Z861PublicacionesMultDescrip = "";
      }

      protected void InitAll1G129( )
      {
         A394PublicacionesMultId = 0;
         InitializeNonKey1G129( ) ;
      }

      protected void StandaloneModalInsert1G129( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302112445", true, true, false);
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
         context.AddJavascriptSource("publicaciones.js", "?20267302112446", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties128( )
      {
         edtPublicacionesDocId_Enabled = defedtPublicacionesDocId_Enabled;
         AssignProp("", false, edtPublicacionesDocId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesDocId_Enabled), 5, 0), !bGXsfl_153_Refreshing);
      }

      protected void init_level_properties129( )
      {
         edtPublicacionesMultId_Enabled = defedtPublicacionesMultId_Enabled;
         AssignProp("", false, edtPublicacionesMultId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPublicacionesMultId_Enabled), 5, 0), !bGXsfl_162_Refreshing);
      }

      protected void StartGridControl153( )
      {
         Gridlevel_documentoContainer.AddObjectProperty("GridName", "Gridlevel_documento");
         Gridlevel_documentoContainer.AddObjectProperty("Header", subGridlevel_documento_Header);
         Gridlevel_documentoContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_documentoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_documentoContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_documentoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_documentoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A386PublicacionesDocId), 18, 0, ".", ""))));
         Gridlevel_documentoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocId_Enabled), 5, 0, ".", "")));
         Gridlevel_documentoContainer.AddColumnProperties(Gridlevel_documentoColumn);
         Gridlevel_documentoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_documentoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A387PublicacionesDoc));
         Gridlevel_documentoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDoc_Enabled), 5, 0, ".", "")));
         Gridlevel_documentoContainer.AddColumnProperties(Gridlevel_documentoColumn);
         Gridlevel_documentoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_documentoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A388PublicacionesDocDescrip));
         Gridlevel_documentoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesDocDescrip_Enabled), 5, 0, ".", "")));
         Gridlevel_documentoContainer.AddColumnProperties(Gridlevel_documentoColumn);
         Gridlevel_documentoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Selectedindex), 4, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Allowselection), 1, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Allowhovering), 1, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_documentoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_documento_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl162( )
      {
         Gridlevel_multimediaContainer.AddObjectProperty("GridName", "Gridlevel_multimedia");
         Gridlevel_multimediaContainer.AddObjectProperty("Header", subGridlevel_multimedia_Header);
         Gridlevel_multimediaContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_multimediaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_multimediaContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A394PublicacionesMultId), 18, 0, ".", ""))));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultId_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A392PublicacionesMult));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMult_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_multimediaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A861PublicacionesMultDescrip));
         Gridlevel_multimediaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPublicacionesMultDescrip_Enabled), 5, 0, ".", "")));
         Gridlevel_multimediaContainer.AddColumnProperties(Gridlevel_multimediaColumn);
         Gridlevel_multimediaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Selectedindex), 4, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Allowselection), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Allowhovering), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_multimediaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_multimedia_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtPublicacionesId_Internalname = "PUBLICACIONESID";
         edtPublicacionesTitulo_Internalname = "PUBLICACIONESTITULO";
         edtPublicacionesDescripcion_Internalname = "PUBLICACIONESDESCRIPCION";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtPublicacionesFecTentInicio_Internalname = "PUBLICACIONESFECTENTINICIO";
         edtPublicacionesFecRealInicio_Internalname = "PUBLICACIONESFECREALINICIO";
         edtPublicacionesFecFinPostulacion_Internalname = "PUBLICACIONESFECFINPOSTULACION";
         edtPublicacionesDetalleMateriales_Internalname = "PUBLICACIONESDETALLEMATERIALES";
         edtPublicacionesFecVisita_Internalname = "PUBLICACIONESFECVISITA";
         edtPublicacionesHoraVisita_Internalname = "PUBLICACIONESHORAVISITA";
         edtPublicacionesDirVisita_Internalname = "PUBLICACIONESDIRVISITA";
         edtPublicacionesCondiciones_Internalname = "PUBLICACIONESCONDICIONES";
         edtPublicacionesTipoDesembolso_Internalname = "PUBLICACIONESTIPODESEMBOLSO";
         edtPublicacionesOtroTipoDes_Internalname = "PUBLICACIONESOTROTIPODES";
         edtPublicacionesModalidad_Internalname = "PUBLICACIONESMODALIDAD";
         edtPublicacionesPrecio_Internalname = "PUBLICACIONESPRECIO";
         dynMonedaId_Internalname = "MONEDAID";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         edtPublicacionesFecCierre_Internalname = "PUBLICACIONESFECCIERRE";
         edtPublicacionesDocReq_Internalname = "PUBLICACIONESDOCREQ";
         edtPublicacionesDocDescripcion_Internalname = "PUBLICACIONESDOCDESCRIPCION";
         edtPublicacionesTipoEmpresa_Internalname = "PUBLICACIONESTIPOEMPRESA";
         edtPublicacionesContratoId_Internalname = "PUBLICACIONESCONTRATOID";
         edtPublicacionesTerminoObra_Internalname = "PUBLICACIONESTERMINOOBRA";
         cmbPublicacionesEstado_Internalname = "PUBLICACIONESESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtPublicacionesDocId_Internalname = "PUBLICACIONESDOCID";
         edtPublicacionesDoc_Internalname = "PUBLICACIONESDOC";
         edtPublicacionesDocDescrip_Internalname = "PUBLICACIONESDOCDESCRIP";
         divTableleaflevel_documento_Internalname = "TABLELEAFLEVEL_DOCUMENTO";
         edtPublicacionesMultId_Internalname = "PUBLICACIONESMULTID";
         edtPublicacionesMult_Internalname = "PUBLICACIONESMULT";
         edtPublicacionesMultDescrip_Internalname = "PUBLICACIONESMULTDESCRIP";
         divTableleaflevel_multimedia_Internalname = "TABLELEAFLEVEL_MULTIMEDIA";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtPublicacionesSerialIma_Internalname = "PUBLICACIONESSERIALIMA";
         edtPublicacionesSerialRem_Internalname = "PUBLICACIONESSERIALREM";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_112_114_Internalname = "PROMPT_112_114";
         subGridlevel_documento_Internalname = "GRIDLEVEL_DOCUMENTO";
         subGridlevel_multimedia_Internalname = "GRIDLEVEL_MULTIMEDIA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_multimedia_Allowcollapsing = 0;
         subGridlevel_multimedia_Allowselection = 0;
         subGridlevel_multimedia_Header = "";
         subGridlevel_documento_Allowcollapsing = 0;
         subGridlevel_documento_Allowselection = 0;
         subGridlevel_documento_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Publicaciones", "");
         edtPublicacionesMultDescrip_Jsonclick = "";
         edtPublicacionesMult_Jsonclick = "";
         edtPublicacionesMultId_Jsonclick = "";
         subGridlevel_multimedia_Class = "WorkWith";
         subGridlevel_multimedia_Backcolorstyle = 0;
         edtPublicacionesDocDescrip_Jsonclick = "";
         edtPublicacionesDoc_Jsonclick = "";
         edtPublicacionesDocId_Jsonclick = "";
         subGridlevel_documento_Class = "WorkWith";
         subGridlevel_documento_Backcolorstyle = 0;
         edtPublicacionesMultDescrip_Enabled = 1;
         edtPublicacionesMult_Enabled = 1;
         edtPublicacionesMultId_Enabled = 1;
         edtPublicacionesDocDescrip_Enabled = 1;
         edtPublicacionesDoc_Enabled = 1;
         edtPublicacionesDocId_Enabled = 1;
         edtPublicacionesSerialRem_Jsonclick = "";
         edtPublicacionesSerialRem_Enabled = 1;
         edtPublicacionesSerialIma_Jsonclick = "";
         edtPublicacionesSerialIma_Enabled = 1;
         bttBtntrn_delete_Enabled = 1;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbPublicacionesEstado_Jsonclick = "";
         cmbPublicacionesEstado.Enabled = 1;
         edtPublicacionesTerminoObra_Jsonclick = "";
         edtPublicacionesTerminoObra_Enabled = 1;
         edtPublicacionesContratoId_Jsonclick = "";
         edtPublicacionesContratoId_Enabled = 1;
         edtPublicacionesTipoEmpresa_Jsonclick = "";
         edtPublicacionesTipoEmpresa_Enabled = 1;
         edtPublicacionesDocDescripcion_Jsonclick = "";
         edtPublicacionesDocDescripcion_Enabled = 1;
         edtPublicacionesDocReq_Jsonclick = "";
         edtPublicacionesDocReq_Enabled = 1;
         edtPublicacionesFecCierre_Jsonclick = "";
         edtPublicacionesFecCierre_Enabled = 1;
         edtMonedaISOSimbolo_Jsonclick = "";
         edtMonedaISOSimbolo_Enabled = 0;
         dynMonedaId_Jsonclick = "";
         dynMonedaId.Enabled = 1;
         edtPublicacionesPrecio_Jsonclick = "";
         edtPublicacionesPrecio_Enabled = 1;
         edtPublicacionesModalidad_Jsonclick = "";
         edtPublicacionesModalidad_Enabled = 1;
         edtPublicacionesOtroTipoDes_Jsonclick = "";
         edtPublicacionesOtroTipoDes_Enabled = 1;
         edtPublicacionesTipoDesembolso_Jsonclick = "";
         edtPublicacionesTipoDesembolso_Enabled = 1;
         edtPublicacionesCondiciones_Jsonclick = "";
         edtPublicacionesCondiciones_Enabled = 1;
         edtPublicacionesDirVisita_Jsonclick = "";
         edtPublicacionesDirVisita_Enabled = 1;
         edtPublicacionesHoraVisita_Jsonclick = "";
         edtPublicacionesHoraVisita_Enabled = 1;
         edtPublicacionesFecVisita_Jsonclick = "";
         edtPublicacionesFecVisita_Enabled = 1;
         edtPublicacionesDetalleMateriales_Jsonclick = "";
         edtPublicacionesDetalleMateriales_Enabled = 1;
         edtPublicacionesFecFinPostulacion_Jsonclick = "";
         edtPublicacionesFecFinPostulacion_Enabled = 1;
         edtPublicacionesFecRealInicio_Jsonclick = "";
         edtPublicacionesFecRealInicio_Enabled = 1;
         edtPublicacionesFecTentInicio_Jsonclick = "";
         edtPublicacionesFecTentInicio_Enabled = 1;
         imgprompt_112_114_Visible = 1;
         imgprompt_112_114_Link = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoMunicipioId_Enabled = 1;
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 1;
         edtPublicacionesDescripcion_Enabled = 1;
         edtPublicacionesTitulo_Jsonclick = "";
         edtPublicacionesTitulo_Enabled = 1;
         edtPublicacionesId_Jsonclick = "";
         edtPublicacionesId_Enabled = 1;
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

      protected void GXDLAMONEDAID1G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMONEDAID_data1G1( ) ;
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

      protected void GXAMONEDAID_html1G1( )
      {
         short gxdynajaxvalue;
         GXDLAMONEDAID_data1G1( ) ;
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

      protected void GXDLAMONEDAID_data1G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001G33 */
         pr_default.execute(31);
         while ( (pr_default.getStatus(31) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001G33_A118MonedaId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001G33_A119MonedaISOSimbolo[0]));
            pr_default.readNext(31);
         }
         pr_default.close(31);
      }

      protected void gxnrGridlevel_documento_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_153128( ) ;
         while ( nGXsfl_153_idx <= nRC_GXsfl_153 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1G128( ) ;
            standaloneModal1G128( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1G128( ) ;
            nGXsfl_153_idx = (int)(nGXsfl_153_idx+1);
            sGXsfl_153_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_153_idx), 4, 0), 4, "0");
            SubsflControlProps_153128( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_documentoContainer)) ;
         /* End function gxnrGridlevel_documento_newrow */
      }

      protected void gxnrGridlevel_multimedia_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_162129( ) ;
         while ( nGXsfl_162_idx <= nRC_GXsfl_162 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1G129( ) ;
            standaloneModal1G129( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1G129( ) ;
            nGXsfl_162_idx = (int)(nGXsfl_162_idx+1);
            sGXsfl_162_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_162_idx), 4, 0), 4, "0");
            SubsflControlProps_162129( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_multimediaContainer)) ;
         /* End function gxnrGridlevel_multimedia_newrow */
      }

      protected void init_web_controls( )
      {
         dynMonedaId.Name = "MONEDAID";
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor T001G34 */
         pr_default.execute(32);
         while ( (pr_default.getStatus(32) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T001G34_A118MonedaId[0]), 4, 0)), T001G34_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(32);
         }
         pr_default.close(32);
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri("", false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
         cmbPublicacionesEstado.Name = "PUBLICACIONESESTADO";
         cmbPublicacionesEstado.WebTags = "";
         cmbPublicacionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPublicacionesEstado.addItem("FIN", context.GetMessage( "Finalizado", ""), 0);
         cmbPublicacionesEstado.addItem("REV", context.GetMessage( "Revisión", ""), 0);
         cmbPublicacionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPublicacionesEstado.addItem("ACE", context.GetMessage( "Aceptada", ""), 0);
         if ( cmbPublicacionesEstado.ItemCount > 0 )
         {
            A384PublicacionesEstado = cmbPublicacionesEstado.getValidValue(A384PublicacionesEstado);
            AssignAttri("", false, "A384PublicacionesEstado", A384PublicacionesEstado);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPublicacionesTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Publicacionesid( )
      {
         A384PublicacionesEstado = cmbPublicacionesEstado.CurrentValue;
         cmbPublicacionesEstado.CurrentValue = A384PublicacionesEstado;
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         }
         if ( cmbPublicacionesEstado.ItemCount > 0 )
         {
            A384PublicacionesEstado = cmbPublicacionesEstado.getValidValue(A384PublicacionesEstado);
            cmbPublicacionesEstado.CurrentValue = A384PublicacionesEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPublicacionesEstado.CurrentValue = StringUtil.RTrim( A384PublicacionesEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A382PublicacionesTitulo", StringUtil.RTrim( A382PublicacionesTitulo));
         AssignAttri("", false, "A383PublicacionesDescripcion", A383PublicacionesDescripcion);
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", "")));
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
         AssignAttri("", false, "A843PublicacionesFecTentInicio", context.localUtil.Format(A843PublicacionesFecTentInicio, "99/99/99"));
         AssignAttri("", false, "A844PublicacionesFecRealInicio", context.localUtil.Format(A844PublicacionesFecRealInicio, "99/99/99"));
         AssignAttri("", false, "A845PublicacionesFecFinPostulacion", context.localUtil.Format(A845PublicacionesFecFinPostulacion, "99/99/99"));
         AssignAttri("", false, "A846PublicacionesDetalleMateriales", StringUtil.RTrim( A846PublicacionesDetalleMateriales));
         AssignAttri("", false, "A847PublicacionesFecVisita", context.localUtil.Format(A847PublicacionesFecVisita, "99/99/99"));
         AssignAttri("", false, "A848PublicacionesHoraVisita", StringUtil.RTrim( A848PublicacionesHoraVisita));
         AssignAttri("", false, "A849PublicacionesDirVisita", A849PublicacionesDirVisita);
         AssignAttri("", false, "A850PublicacionesCondiciones", A850PublicacionesCondiciones);
         AssignAttri("", false, "A851PublicacionesTipoDesembolso", A851PublicacionesTipoDesembolso);
         AssignAttri("", false, "A859PublicacionesOtroTipoDes", A859PublicacionesOtroTipoDes);
         AssignAttri("", false, "A852PublicacionesModalidad", StringUtil.RTrim( A852PublicacionesModalidad));
         AssignAttri("", false, "A389PublicacionesPrecio", StringUtil.LTrim( StringUtil.NToC( A389PublicacionesPrecio, 18, 2, ".", "")));
         AssignAttri("", false, "A118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", "")));
         dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         AssignProp("", false, dynMonedaId_Internalname, "Values", dynMonedaId.ToJavascriptSource(), true);
         AssignAttri("", false, "A854PublicacionesFecCierre", context.localUtil.Format(A854PublicacionesFecCierre, "99/99/99"));
         AssignAttri("", false, "A855PublicacionesDocReq", A855PublicacionesDocReq);
         AssignAttri("", false, "A856PublicacionesDocDescripcion", A856PublicacionesDocDescripcion);
         AssignAttri("", false, "A857PublicacionesTipoEmpresa", A857PublicacionesTipoEmpresa);
         AssignAttri("", false, "A858PublicacionesContratoId", A858PublicacionesContratoId);
         AssignAttri("", false, "A860PublicacionesTerminoObra", A860PublicacionesTerminoObra);
         AssignAttri("", false, "A384PublicacionesEstado", StringUtil.RTrim( A384PublicacionesEstado));
         cmbPublicacionesEstado.CurrentValue = StringUtil.RTrim( A384PublicacionesEstado);
         AssignProp("", false, cmbPublicacionesEstado_Internalname, "Values", cmbPublicacionesEstado.ToJavascriptSource(), true);
         AssignAttri("", false, "A385PublicacionesSerialIma", StringUtil.LTrim( StringUtil.NToC( (decimal)(A385PublicacionesSerialIma), 4, 0, ".", "")));
         AssignAttri("", false, "A395PublicacionesSerialRem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A395PublicacionesSerialRem), 4, 0, ".", "")));
         AssignAttri("", false, "A119MonedaISOSimbolo", StringUtil.RTrim( A119MonedaISOSimbolo));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z381PublicacionesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381PublicacionesId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z382PublicacionesTitulo", StringUtil.RTrim( Z382PublicacionesTitulo));
         GxWebStd.gx_hidden_field( context, "Z383PublicacionesDescripcion", Z383PublicacionesDescripcion);
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z843PublicacionesFecTentInicio", context.localUtil.Format(Z843PublicacionesFecTentInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z844PublicacionesFecRealInicio", context.localUtil.Format(Z844PublicacionesFecRealInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z845PublicacionesFecFinPostulacion", context.localUtil.Format(Z845PublicacionesFecFinPostulacion, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z846PublicacionesDetalleMateriales", StringUtil.RTrim( Z846PublicacionesDetalleMateriales));
         GxWebStd.gx_hidden_field( context, "Z847PublicacionesFecVisita", context.localUtil.Format(Z847PublicacionesFecVisita, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z848PublicacionesHoraVisita", StringUtil.RTrim( Z848PublicacionesHoraVisita));
         GxWebStd.gx_hidden_field( context, "Z849PublicacionesDirVisita", Z849PublicacionesDirVisita);
         GxWebStd.gx_hidden_field( context, "Z850PublicacionesCondiciones", Z850PublicacionesCondiciones);
         GxWebStd.gx_hidden_field( context, "Z851PublicacionesTipoDesembolso", Z851PublicacionesTipoDesembolso);
         GxWebStd.gx_hidden_field( context, "Z859PublicacionesOtroTipoDes", Z859PublicacionesOtroTipoDes);
         GxWebStd.gx_hidden_field( context, "Z852PublicacionesModalidad", StringUtil.RTrim( Z852PublicacionesModalidad));
         GxWebStd.gx_hidden_field( context, "Z389PublicacionesPrecio", StringUtil.LTrim( StringUtil.NToC( Z389PublicacionesPrecio, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z854PublicacionesFecCierre", context.localUtil.Format(Z854PublicacionesFecCierre, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z855PublicacionesDocReq", Z855PublicacionesDocReq);
         GxWebStd.gx_hidden_field( context, "Z856PublicacionesDocDescripcion", Z856PublicacionesDocDescripcion);
         GxWebStd.gx_hidden_field( context, "Z857PublicacionesTipoEmpresa", Z857PublicacionesTipoEmpresa);
         GxWebStd.gx_hidden_field( context, "Z858PublicacionesContratoId", Z858PublicacionesContratoId);
         GxWebStd.gx_hidden_field( context, "Z860PublicacionesTerminoObra", Z860PublicacionesTerminoObra);
         GxWebStd.gx_hidden_field( context, "Z384PublicacionesEstado", StringUtil.RTrim( Z384PublicacionesEstado));
         GxWebStd.gx_hidden_field( context, "Z385PublicacionesSerialIma", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z385PublicacionesSerialIma), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z395PublicacionesSerialRem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z395PublicacionesSerialRem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z119MonedaISOSimbolo", StringUtil.RTrim( Z119MonedaISOSimbolo));
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Departamentomunicipioid( )
      {
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         /* Using cursor T001G35 */
         pr_default.execute(33, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
         }
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Monedaid( )
      {
         n118MonedaId = false;
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n118MonedaId = false;
         /* Using cursor T001G19 */
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
         A119MonedaISOSimbolo = T001G19_A119MonedaISOSimbolo[0];
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E121G2',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESID","{handler:'Valid_Publicacionesid',iparms:[{av:'cmbPublicacionesEstado'},{av:'A384PublicacionesEstado',fld:'PUBLICACIONESESTADO',pic:'',type:'char'},{av:'A381PublicacionesId',fld:'PUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESID",",oparms:[{av:'A382PublicacionesTitulo',fld:'PUBLICACIONESTITULO',pic:'',type:'char'},{av:'A383PublicacionesDescripcion',fld:'PUBLICACIONESDESCRIPCION',pic:'',type:'vchar'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A843PublicacionesFecTentInicio',fld:'PUBLICACIONESFECTENTINICIO',pic:'',type:'date'},{av:'A844PublicacionesFecRealInicio',fld:'PUBLICACIONESFECREALINICIO',pic:'',type:'date'},{av:'A845PublicacionesFecFinPostulacion',fld:'PUBLICACIONESFECFINPOSTULACION',pic:'',type:'date'},{av:'A846PublicacionesDetalleMateriales',fld:'PUBLICACIONESDETALLEMATERIALES',pic:'',type:'char'},{av:'A847PublicacionesFecVisita',fld:'PUBLICACIONESFECVISITA',pic:'',type:'date'},{av:'A848PublicacionesHoraVisita',fld:'PUBLICACIONESHORAVISITA',pic:'',type:'char'},{av:'A849PublicacionesDirVisita',fld:'PUBLICACIONESDIRVISITA',pic:'',type:'svchar'},{av:'A850PublicacionesCondiciones',fld:'PUBLICACIONESCONDICIONES',pic:'',type:'svchar'},{av:'A851PublicacionesTipoDesembolso',fld:'PUBLICACIONESTIPODESEMBOLSO',pic:'',type:'svchar'},{av:'A859PublicacionesOtroTipoDes',fld:'PUBLICACIONESOTROTIPODES',pic:'',type:'svchar'},{av:'A852PublicacionesModalidad',fld:'PUBLICACIONESMODALIDAD',pic:'',type:'char'},{av:'A389PublicacionesPrecio',fld:'PUBLICACIONESPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A854PublicacionesFecCierre',fld:'PUBLICACIONESFECCIERRE',pic:'',type:'date'},{av:'A855PublicacionesDocReq',fld:'PUBLICACIONESDOCREQ',pic:'',type:'svchar'},{av:'A856PublicacionesDocDescripcion',fld:'PUBLICACIONESDOCDESCRIPCION',pic:'',type:'svchar'},{av:'A857PublicacionesTipoEmpresa',fld:'PUBLICACIONESTIPOEMPRESA',pic:'',type:'svchar'},{av:'A858PublicacionesContratoId',fld:'PUBLICACIONESCONTRATOID',pic:'',type:'svchar'},{av:'A860PublicacionesTerminoObra',fld:'PUBLICACIONESTERMINOOBRA',pic:'',type:'svchar'},{av:'cmbPublicacionesEstado'},{av:'A384PublicacionesEstado',fld:'PUBLICACIONESESTADO',pic:'',type:'char'},{av:'A385PublicacionesSerialIma',fld:'PUBLICACIONESSERIALIMA',pic:'ZZZ9',type:'int'},{av:'A395PublicacionesSerialRem',fld:'PUBLICACIONESSERIALREM',pic:'ZZZ9',type:'int'},{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z381PublicacionesId',type:'int'},{av:'Z382PublicacionesTitulo',type:'char'},{av:'Z383PublicacionesDescripcion',type:'vchar'},{av:'Z112DepartamentoId',type:'int'},{av:'Z114DepartamentoMunicipioId',type:'int'},{av:'Z843PublicacionesFecTentInicio',type:'date'},{av:'Z844PublicacionesFecRealInicio',type:'date'},{av:'Z845PublicacionesFecFinPostulacion',type:'date'},{av:'Z846PublicacionesDetalleMateriales',type:'char'},{av:'Z847PublicacionesFecVisita',type:'date'},{av:'Z848PublicacionesHoraVisita',type:'char'},{av:'Z849PublicacionesDirVisita',type:'svchar'},{av:'Z850PublicacionesCondiciones',type:'svchar'},{av:'Z851PublicacionesTipoDesembolso',type:'svchar'},{av:'Z859PublicacionesOtroTipoDes',type:'svchar'},{av:'Z852PublicacionesModalidad',type:'char'},{av:'Z389PublicacionesPrecio',type:'decimal'},{av:'Z118MonedaId',type:'int'},{av:'Z854PublicacionesFecCierre',type:'date'},{av:'Z855PublicacionesDocReq',type:'svchar'},{av:'Z856PublicacionesDocDescripcion',type:'svchar'},{av:'Z857PublicacionesTipoEmpresa',type:'svchar'},{av:'Z858PublicacionesContratoId',type:'svchar'},{av:'Z860PublicacionesTerminoObra',type:'svchar'},{av:'Z384PublicacionesEstado',type:'char'},{av:'Z385PublicacionesSerialIma',type:'int'},{av:'Z395PublicacionesSerialRem',type:'int'},{av:'Z119MonedaISOSimbolo',type:'char'},{ctrl:'BTNTRN_DELETE',prop:'Enabled'},{ctrl:'BTNTRN_ENTER',prop:'Enabled'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESFECTENTINICIO","{handler:'Valid_Publicacionesfectentinicio',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESFECTENTINICIO",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESFECREALINICIO","{handler:'Valid_Publicacionesfecrealinicio',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESFECREALINICIO",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESFECFINPOSTULACION","{handler:'Valid_Publicacionesfecfinpostulacion',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESFECFINPOSTULACION",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESFECVISITA","{handler:'Valid_Publicacionesfecvisita',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESFECVISITA",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_MONEDAID",",oparms:[{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESFECCIERRE","{handler:'Valid_Publicacionesfeccierre',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESFECCIERRE",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESDOCID","{handler:'Valid_Publicacionesdocid',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESDOCID",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("NULL","{handler:'Valid_Publicacionesdocdescrip',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PUBLICACIONESMULTID","{handler:'Valid_Publicacionesmultid',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_PUBLICACIONESMULTID",",oparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("NULL","{handler:'Valid_Publicacionesmultdescrip',iparms:[{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'}]");
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
         pr_default.close(5);
         pr_default.close(33);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z382PublicacionesTitulo = "";
         Z843PublicacionesFecTentInicio = DateTime.MinValue;
         Z844PublicacionesFecRealInicio = DateTime.MinValue;
         Z845PublicacionesFecFinPostulacion = DateTime.MinValue;
         Z846PublicacionesDetalleMateriales = "";
         Z847PublicacionesFecVisita = DateTime.MinValue;
         Z848PublicacionesHoraVisita = "";
         Z849PublicacionesDirVisita = "";
         Z850PublicacionesCondiciones = "";
         Z851PublicacionesTipoDesembolso = "";
         Z859PublicacionesOtroTipoDes = "";
         Z852PublicacionesModalidad = "";
         Z854PublicacionesFecCierre = DateTime.MinValue;
         Z855PublicacionesDocReq = "";
         Z856PublicacionesDocDescripcion = "";
         Z857PublicacionesTipoEmpresa = "";
         Z858PublicacionesContratoId = "";
         Z860PublicacionesTerminoObra = "";
         Z384PublicacionesEstado = "";
         Z387PublicacionesDoc = "";
         Z388PublicacionesDocDescrip = "";
         Z392PublicacionesMult = "";
         Z861PublicacionesMultDescrip = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         A384PublicacionesEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A382PublicacionesTitulo = "";
         A383PublicacionesDescripcion = "";
         imgprompt_112_114_gximage = "";
         sImgUrl = "";
         A843PublicacionesFecTentInicio = DateTime.MinValue;
         A844PublicacionesFecRealInicio = DateTime.MinValue;
         A845PublicacionesFecFinPostulacion = DateTime.MinValue;
         A846PublicacionesDetalleMateriales = "";
         A847PublicacionesFecVisita = DateTime.MinValue;
         A848PublicacionesHoraVisita = "";
         A849PublicacionesDirVisita = "";
         A850PublicacionesCondiciones = "";
         A851PublicacionesTipoDesembolso = "";
         A859PublicacionesOtroTipoDes = "";
         A852PublicacionesModalidad = "";
         A119MonedaISOSimbolo = "";
         A854PublicacionesFecCierre = DateTime.MinValue;
         A855PublicacionesDocReq = "";
         A856PublicacionesDocDescripcion = "";
         A857PublicacionesTipoEmpresa = "";
         A858PublicacionesContratoId = "";
         A860PublicacionesTerminoObra = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_documentoContainer = new GXWebGrid( context);
         sMode128 = "";
         sStyleString = "";
         Gridlevel_multimediaContainer = new GXWebGrid( context);
         sMode129 = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A392PublicacionesMult = "";
         A861PublicacionesMultDescrip = "";
         A387PublicacionesDoc = "";
         A388PublicacionesDocDescrip = "";
         Z383PublicacionesDescripcion = "";
         Z119MonedaISOSimbolo = "";
         T001G10_A381PublicacionesId = new long[1] ;
         T001G10_A382PublicacionesTitulo = new string[] {""} ;
         T001G10_A383PublicacionesDescripcion = new string[] {""} ;
         T001G10_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         T001G10_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         T001G10_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         T001G10_A846PublicacionesDetalleMateriales = new string[] {""} ;
         T001G10_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         T001G10_A848PublicacionesHoraVisita = new string[] {""} ;
         T001G10_A849PublicacionesDirVisita = new string[] {""} ;
         T001G10_A850PublicacionesCondiciones = new string[] {""} ;
         T001G10_A851PublicacionesTipoDesembolso = new string[] {""} ;
         T001G10_A859PublicacionesOtroTipoDes = new string[] {""} ;
         T001G10_A852PublicacionesModalidad = new string[] {""} ;
         T001G10_A389PublicacionesPrecio = new decimal[1] ;
         T001G10_A119MonedaISOSimbolo = new string[] {""} ;
         T001G10_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         T001G10_A855PublicacionesDocReq = new string[] {""} ;
         T001G10_A856PublicacionesDocDescripcion = new string[] {""} ;
         T001G10_A857PublicacionesTipoEmpresa = new string[] {""} ;
         T001G10_A858PublicacionesContratoId = new string[] {""} ;
         T001G10_A860PublicacionesTerminoObra = new string[] {""} ;
         T001G10_A384PublicacionesEstado = new string[] {""} ;
         T001G10_A385PublicacionesSerialIma = new short[1] ;
         T001G10_A395PublicacionesSerialRem = new short[1] ;
         T001G10_A112DepartamentoId = new long[1] ;
         T001G10_A114DepartamentoMunicipioId = new long[1] ;
         T001G10_A118MonedaId = new short[1] ;
         T001G10_n118MonedaId = new bool[] {false} ;
         T001G8_A112DepartamentoId = new long[1] ;
         T001G9_A119MonedaISOSimbolo = new string[] {""} ;
         T001G11_A112DepartamentoId = new long[1] ;
         T001G12_A119MonedaISOSimbolo = new string[] {""} ;
         T001G13_A381PublicacionesId = new long[1] ;
         T001G7_A381PublicacionesId = new long[1] ;
         T001G7_A382PublicacionesTitulo = new string[] {""} ;
         T001G7_A383PublicacionesDescripcion = new string[] {""} ;
         T001G7_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         T001G7_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         T001G7_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         T001G7_A846PublicacionesDetalleMateriales = new string[] {""} ;
         T001G7_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         T001G7_A848PublicacionesHoraVisita = new string[] {""} ;
         T001G7_A849PublicacionesDirVisita = new string[] {""} ;
         T001G7_A850PublicacionesCondiciones = new string[] {""} ;
         T001G7_A851PublicacionesTipoDesembolso = new string[] {""} ;
         T001G7_A859PublicacionesOtroTipoDes = new string[] {""} ;
         T001G7_A852PublicacionesModalidad = new string[] {""} ;
         T001G7_A389PublicacionesPrecio = new decimal[1] ;
         T001G7_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         T001G7_A855PublicacionesDocReq = new string[] {""} ;
         T001G7_A856PublicacionesDocDescripcion = new string[] {""} ;
         T001G7_A857PublicacionesTipoEmpresa = new string[] {""} ;
         T001G7_A858PublicacionesContratoId = new string[] {""} ;
         T001G7_A860PublicacionesTerminoObra = new string[] {""} ;
         T001G7_A384PublicacionesEstado = new string[] {""} ;
         T001G7_A385PublicacionesSerialIma = new short[1] ;
         T001G7_A395PublicacionesSerialRem = new short[1] ;
         T001G7_A112DepartamentoId = new long[1] ;
         T001G7_A114DepartamentoMunicipioId = new long[1] ;
         T001G7_A118MonedaId = new short[1] ;
         T001G7_n118MonedaId = new bool[] {false} ;
         sMode127 = "";
         T001G14_A381PublicacionesId = new long[1] ;
         T001G15_A381PublicacionesId = new long[1] ;
         T001G6_A381PublicacionesId = new long[1] ;
         T001G6_A382PublicacionesTitulo = new string[] {""} ;
         T001G6_A383PublicacionesDescripcion = new string[] {""} ;
         T001G6_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         T001G6_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         T001G6_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         T001G6_A846PublicacionesDetalleMateriales = new string[] {""} ;
         T001G6_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         T001G6_A848PublicacionesHoraVisita = new string[] {""} ;
         T001G6_A849PublicacionesDirVisita = new string[] {""} ;
         T001G6_A850PublicacionesCondiciones = new string[] {""} ;
         T001G6_A851PublicacionesTipoDesembolso = new string[] {""} ;
         T001G6_A859PublicacionesOtroTipoDes = new string[] {""} ;
         T001G6_A852PublicacionesModalidad = new string[] {""} ;
         T001G6_A389PublicacionesPrecio = new decimal[1] ;
         T001G6_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         T001G6_A855PublicacionesDocReq = new string[] {""} ;
         T001G6_A856PublicacionesDocDescripcion = new string[] {""} ;
         T001G6_A857PublicacionesTipoEmpresa = new string[] {""} ;
         T001G6_A858PublicacionesContratoId = new string[] {""} ;
         T001G6_A860PublicacionesTerminoObra = new string[] {""} ;
         T001G6_A384PublicacionesEstado = new string[] {""} ;
         T001G6_A385PublicacionesSerialIma = new short[1] ;
         T001G6_A395PublicacionesSerialRem = new short[1] ;
         T001G6_A112DepartamentoId = new long[1] ;
         T001G6_A114DepartamentoMunicipioId = new long[1] ;
         T001G6_A118MonedaId = new short[1] ;
         T001G6_n118MonedaId = new bool[] {false} ;
         T001G16_A381PublicacionesId = new long[1] ;
         T001G19_A119MonedaISOSimbolo = new string[] {""} ;
         T001G20_A381PublicacionesId = new long[1] ;
         T001G21_A381PublicacionesId = new long[1] ;
         T001G21_A386PublicacionesDocId = new long[1] ;
         T001G21_A387PublicacionesDoc = new string[] {""} ;
         T001G21_A388PublicacionesDocDescrip = new string[] {""} ;
         T001G22_A381PublicacionesId = new long[1] ;
         T001G22_A386PublicacionesDocId = new long[1] ;
         T001G5_A381PublicacionesId = new long[1] ;
         T001G5_A386PublicacionesDocId = new long[1] ;
         T001G5_A387PublicacionesDoc = new string[] {""} ;
         T001G5_A388PublicacionesDocDescrip = new string[] {""} ;
         T001G4_A381PublicacionesId = new long[1] ;
         T001G4_A386PublicacionesDocId = new long[1] ;
         T001G4_A387PublicacionesDoc = new string[] {""} ;
         T001G4_A388PublicacionesDocDescrip = new string[] {""} ;
         T001G26_A381PublicacionesId = new long[1] ;
         T001G26_A386PublicacionesDocId = new long[1] ;
         T001G27_A381PublicacionesId = new long[1] ;
         T001G27_A394PublicacionesMultId = new long[1] ;
         T001G27_A392PublicacionesMult = new string[] {""} ;
         T001G27_A861PublicacionesMultDescrip = new string[] {""} ;
         T001G28_A381PublicacionesId = new long[1] ;
         T001G28_A394PublicacionesMultId = new long[1] ;
         T001G3_A381PublicacionesId = new long[1] ;
         T001G3_A394PublicacionesMultId = new long[1] ;
         T001G3_A392PublicacionesMult = new string[] {""} ;
         T001G3_A861PublicacionesMultDescrip = new string[] {""} ;
         T001G2_A381PublicacionesId = new long[1] ;
         T001G2_A394PublicacionesMultId = new long[1] ;
         T001G2_A392PublicacionesMult = new string[] {""} ;
         T001G2_A861PublicacionesMultDescrip = new string[] {""} ;
         T001G32_A381PublicacionesId = new long[1] ;
         T001G32_A394PublicacionesMultId = new long[1] ;
         Gridlevel_documentoRow = new GXWebRow();
         subGridlevel_documento_Linesclass = "";
         ROClassString = "";
         Gridlevel_multimediaRow = new GXWebRow();
         subGridlevel_multimedia_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_documentoColumn = new GXWebColumn();
         Gridlevel_multimediaColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001G33_A118MonedaId = new short[1] ;
         T001G33_n118MonedaId = new bool[] {false} ;
         T001G33_A119MonedaISOSimbolo = new string[] {""} ;
         T001G34_A118MonedaId = new short[1] ;
         T001G34_n118MonedaId = new bool[] {false} ;
         T001G34_A119MonedaISOSimbolo = new string[] {""} ;
         ZZ382PublicacionesTitulo = "";
         ZZ383PublicacionesDescripcion = "";
         ZZ843PublicacionesFecTentInicio = DateTime.MinValue;
         ZZ844PublicacionesFecRealInicio = DateTime.MinValue;
         ZZ845PublicacionesFecFinPostulacion = DateTime.MinValue;
         ZZ846PublicacionesDetalleMateriales = "";
         ZZ847PublicacionesFecVisita = DateTime.MinValue;
         ZZ848PublicacionesHoraVisita = "";
         ZZ849PublicacionesDirVisita = "";
         ZZ850PublicacionesCondiciones = "";
         ZZ851PublicacionesTipoDesembolso = "";
         ZZ859PublicacionesOtroTipoDes = "";
         ZZ852PublicacionesModalidad = "";
         ZZ854PublicacionesFecCierre = DateTime.MinValue;
         ZZ855PublicacionesDocReq = "";
         ZZ856PublicacionesDocDescripcion = "";
         ZZ857PublicacionesTipoEmpresa = "";
         ZZ858PublicacionesContratoId = "";
         ZZ860PublicacionesTerminoObra = "";
         ZZ384PublicacionesEstado = "";
         ZZ119MonedaISOSimbolo = "";
         T001G35_A112DepartamentoId = new long[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.publicaciones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.publicaciones__default(),
            new Object[][] {
                new Object[] {
               T001G2_A381PublicacionesId, T001G2_A394PublicacionesMultId, T001G2_A392PublicacionesMult, T001G2_A861PublicacionesMultDescrip
               }
               , new Object[] {
               T001G3_A381PublicacionesId, T001G3_A394PublicacionesMultId, T001G3_A392PublicacionesMult, T001G3_A861PublicacionesMultDescrip
               }
               , new Object[] {
               T001G4_A381PublicacionesId, T001G4_A386PublicacionesDocId, T001G4_A387PublicacionesDoc, T001G4_A388PublicacionesDocDescrip
               }
               , new Object[] {
               T001G5_A381PublicacionesId, T001G5_A386PublicacionesDocId, T001G5_A387PublicacionesDoc, T001G5_A388PublicacionesDocDescrip
               }
               , new Object[] {
               T001G6_A381PublicacionesId, T001G6_A382PublicacionesTitulo, T001G6_A383PublicacionesDescripcion, T001G6_A843PublicacionesFecTentInicio, T001G6_A844PublicacionesFecRealInicio, T001G6_A845PublicacionesFecFinPostulacion, T001G6_A846PublicacionesDetalleMateriales, T001G6_A847PublicacionesFecVisita, T001G6_A848PublicacionesHoraVisita, T001G6_A849PublicacionesDirVisita,
               T001G6_A850PublicacionesCondiciones, T001G6_A851PublicacionesTipoDesembolso, T001G6_A859PublicacionesOtroTipoDes, T001G6_A852PublicacionesModalidad, T001G6_A389PublicacionesPrecio, T001G6_A854PublicacionesFecCierre, T001G6_A855PublicacionesDocReq, T001G6_A856PublicacionesDocDescripcion, T001G6_A857PublicacionesTipoEmpresa, T001G6_A858PublicacionesContratoId,
               T001G6_A860PublicacionesTerminoObra, T001G6_A384PublicacionesEstado, T001G6_A385PublicacionesSerialIma, T001G6_A395PublicacionesSerialRem, T001G6_A112DepartamentoId, T001G6_A114DepartamentoMunicipioId, T001G6_A118MonedaId, T001G6_n118MonedaId
               }
               , new Object[] {
               T001G7_A381PublicacionesId, T001G7_A382PublicacionesTitulo, T001G7_A383PublicacionesDescripcion, T001G7_A843PublicacionesFecTentInicio, T001G7_A844PublicacionesFecRealInicio, T001G7_A845PublicacionesFecFinPostulacion, T001G7_A846PublicacionesDetalleMateriales, T001G7_A847PublicacionesFecVisita, T001G7_A848PublicacionesHoraVisita, T001G7_A849PublicacionesDirVisita,
               T001G7_A850PublicacionesCondiciones, T001G7_A851PublicacionesTipoDesembolso, T001G7_A859PublicacionesOtroTipoDes, T001G7_A852PublicacionesModalidad, T001G7_A389PublicacionesPrecio, T001G7_A854PublicacionesFecCierre, T001G7_A855PublicacionesDocReq, T001G7_A856PublicacionesDocDescripcion, T001G7_A857PublicacionesTipoEmpresa, T001G7_A858PublicacionesContratoId,
               T001G7_A860PublicacionesTerminoObra, T001G7_A384PublicacionesEstado, T001G7_A385PublicacionesSerialIma, T001G7_A395PublicacionesSerialRem, T001G7_A112DepartamentoId, T001G7_A114DepartamentoMunicipioId, T001G7_A118MonedaId, T001G7_n118MonedaId
               }
               , new Object[] {
               T001G8_A112DepartamentoId
               }
               , new Object[] {
               T001G9_A119MonedaISOSimbolo
               }
               , new Object[] {
               T001G10_A381PublicacionesId, T001G10_A382PublicacionesTitulo, T001G10_A383PublicacionesDescripcion, T001G10_A843PublicacionesFecTentInicio, T001G10_A844PublicacionesFecRealInicio, T001G10_A845PublicacionesFecFinPostulacion, T001G10_A846PublicacionesDetalleMateriales, T001G10_A847PublicacionesFecVisita, T001G10_A848PublicacionesHoraVisita, T001G10_A849PublicacionesDirVisita,
               T001G10_A850PublicacionesCondiciones, T001G10_A851PublicacionesTipoDesembolso, T001G10_A859PublicacionesOtroTipoDes, T001G10_A852PublicacionesModalidad, T001G10_A389PublicacionesPrecio, T001G10_A119MonedaISOSimbolo, T001G10_A854PublicacionesFecCierre, T001G10_A855PublicacionesDocReq, T001G10_A856PublicacionesDocDescripcion, T001G10_A857PublicacionesTipoEmpresa,
               T001G10_A858PublicacionesContratoId, T001G10_A860PublicacionesTerminoObra, T001G10_A384PublicacionesEstado, T001G10_A385PublicacionesSerialIma, T001G10_A395PublicacionesSerialRem, T001G10_A112DepartamentoId, T001G10_A114DepartamentoMunicipioId, T001G10_A118MonedaId, T001G10_n118MonedaId
               }
               , new Object[] {
               T001G11_A112DepartamentoId
               }
               , new Object[] {
               T001G12_A119MonedaISOSimbolo
               }
               , new Object[] {
               T001G13_A381PublicacionesId
               }
               , new Object[] {
               T001G14_A381PublicacionesId
               }
               , new Object[] {
               T001G15_A381PublicacionesId
               }
               , new Object[] {
               T001G16_A381PublicacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G19_A119MonedaISOSimbolo
               }
               , new Object[] {
               T001G20_A381PublicacionesId
               }
               , new Object[] {
               T001G21_A381PublicacionesId, T001G21_A386PublicacionesDocId, T001G21_A387PublicacionesDoc, T001G21_A388PublicacionesDocDescrip
               }
               , new Object[] {
               T001G22_A381PublicacionesId, T001G22_A386PublicacionesDocId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G26_A381PublicacionesId, T001G26_A386PublicacionesDocId
               }
               , new Object[] {
               T001G27_A381PublicacionesId, T001G27_A394PublicacionesMultId, T001G27_A392PublicacionesMult, T001G27_A861PublicacionesMultDescrip
               }
               , new Object[] {
               T001G28_A381PublicacionesId, T001G28_A394PublicacionesMultId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G32_A381PublicacionesId, T001G32_A394PublicacionesMultId
               }
               , new Object[] {
               T001G33_A118MonedaId, T001G33_A119MonedaISOSimbolo
               }
               , new Object[] {
               T001G34_A118MonedaId, T001G34_A119MonedaISOSimbolo
               }
               , new Object[] {
               T001G35_A112DepartamentoId
               }
            }
         );
      }

      private short Z385PublicacionesSerialIma ;
      private short Z395PublicacionesSerialRem ;
      private short Z118MonedaId ;
      private short nRcdDeleted_128 ;
      private short nRcdExists_128 ;
      private short nIsMod_128 ;
      private short nRcdDeleted_129 ;
      private short nRcdExists_129 ;
      private short nIsMod_129 ;
      private short GxWebError ;
      private short A118MonedaId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A385PublicacionesSerialIma ;
      private short A395PublicacionesSerialRem ;
      private short nBlankRcdCount128 ;
      private short RcdFound128 ;
      private short nBlankRcdUsr128 ;
      private short nBlankRcdCount129 ;
      private short RcdFound129 ;
      private short nBlankRcdUsr129 ;
      private short RcdFound127 ;
      private short Gx_BScreen ;
      private short nIsDirty_128 ;
      private short nIsDirty_129 ;
      private short subGridlevel_documento_Backcolorstyle ;
      private short subGridlevel_documento_Backstyle ;
      private short subGridlevel_multimedia_Backcolorstyle ;
      private short subGridlevel_multimedia_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_documento_Allowselection ;
      private short subGridlevel_documento_Allowhovering ;
      private short subGridlevel_documento_Allowcollapsing ;
      private short subGridlevel_documento_Collapsed ;
      private short subGridlevel_multimedia_Allowselection ;
      private short subGridlevel_multimedia_Allowhovering ;
      private short subGridlevel_multimedia_Allowcollapsing ;
      private short subGridlevel_multimedia_Collapsed ;
      private short ZZ118MonedaId ;
      private short ZZ385PublicacionesSerialIma ;
      private short ZZ395PublicacionesSerialRem ;
      private int nRC_GXsfl_153 ;
      private int nGXsfl_153_idx=1 ;
      private int nRC_GXsfl_162 ;
      private int nGXsfl_162_idx=1 ;
      private int trnEnded ;
      private int edtPublicacionesId_Enabled ;
      private int edtPublicacionesTitulo_Enabled ;
      private int edtPublicacionesDescripcion_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int imgprompt_112_114_Visible ;
      private int edtPublicacionesFecTentInicio_Enabled ;
      private int edtPublicacionesFecRealInicio_Enabled ;
      private int edtPublicacionesFecFinPostulacion_Enabled ;
      private int edtPublicacionesDetalleMateriales_Enabled ;
      private int edtPublicacionesFecVisita_Enabled ;
      private int edtPublicacionesHoraVisita_Enabled ;
      private int edtPublicacionesDirVisita_Enabled ;
      private int edtPublicacionesCondiciones_Enabled ;
      private int edtPublicacionesTipoDesembolso_Enabled ;
      private int edtPublicacionesOtroTipoDes_Enabled ;
      private int edtPublicacionesModalidad_Enabled ;
      private int edtPublicacionesPrecio_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int edtPublicacionesFecCierre_Enabled ;
      private int edtPublicacionesDocReq_Enabled ;
      private int edtPublicacionesDocDescripcion_Enabled ;
      private int edtPublicacionesTipoEmpresa_Enabled ;
      private int edtPublicacionesContratoId_Enabled ;
      private int edtPublicacionesTerminoObra_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtPublicacionesSerialIma_Enabled ;
      private int edtPublicacionesSerialRem_Enabled ;
      private int edtPublicacionesDocId_Enabled ;
      private int edtPublicacionesDoc_Enabled ;
      private int edtPublicacionesDocDescrip_Enabled ;
      private int fRowAdded ;
      private int edtPublicacionesMultId_Enabled ;
      private int edtPublicacionesMult_Enabled ;
      private int edtPublicacionesMultDescrip_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_documento_Backcolor ;
      private int subGridlevel_documento_Allbackcolor ;
      private int subGridlevel_multimedia_Backcolor ;
      private int subGridlevel_multimedia_Allbackcolor ;
      private int defedtPublicacionesMultId_Enabled ;
      private int defedtPublicacionesDocId_Enabled ;
      private int idxLst ;
      private int subGridlevel_documento_Selectedindex ;
      private int subGridlevel_documento_Selectioncolor ;
      private int subGridlevel_documento_Hoveringcolor ;
      private int subGridlevel_multimedia_Selectedindex ;
      private int subGridlevel_multimedia_Selectioncolor ;
      private int subGridlevel_multimedia_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long Z381PublicacionesId ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long Z386PublicacionesDocId ;
      private long Z394PublicacionesMultId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A381PublicacionesId ;
      private long GRIDLEVEL_DOCUMENTO_nFirstRecordOnPage ;
      private long GRIDLEVEL_MULTIMEDIA_nFirstRecordOnPage ;
      private long A394PublicacionesMultId ;
      private long A386PublicacionesDocId ;
      private long ZZ381PublicacionesId ;
      private long ZZ112DepartamentoId ;
      private long ZZ114DepartamentoMunicipioId ;
      private decimal Z389PublicacionesPrecio ;
      private decimal A389PublicacionesPrecio ;
      private decimal ZZ389PublicacionesPrecio ;
      private string sPrefix ;
      private string Z382PublicacionesTitulo ;
      private string Z846PublicacionesDetalleMateriales ;
      private string Z848PublicacionesHoraVisita ;
      private string Z852PublicacionesModalidad ;
      private string Z384PublicacionesEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPublicacionesId_Internalname ;
      private string sGXsfl_153_idx="0001" ;
      private string Gx_mode ;
      private string sGXsfl_162_idx="0001" ;
      private string dynMonedaId_Internalname ;
      private string A384PublicacionesEstado ;
      private string cmbPublicacionesEstado_Internalname ;
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
      private string edtPublicacionesId_Jsonclick ;
      private string edtPublicacionesTitulo_Internalname ;
      private string A382PublicacionesTitulo ;
      private string edtPublicacionesTitulo_Jsonclick ;
      private string edtPublicacionesDescripcion_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string imgprompt_112_114_gximage ;
      private string sImgUrl ;
      private string imgprompt_112_114_Internalname ;
      private string imgprompt_112_114_Link ;
      private string edtPublicacionesFecTentInicio_Internalname ;
      private string edtPublicacionesFecTentInicio_Jsonclick ;
      private string edtPublicacionesFecRealInicio_Internalname ;
      private string edtPublicacionesFecRealInicio_Jsonclick ;
      private string edtPublicacionesFecFinPostulacion_Internalname ;
      private string edtPublicacionesFecFinPostulacion_Jsonclick ;
      private string edtPublicacionesDetalleMateriales_Internalname ;
      private string A846PublicacionesDetalleMateriales ;
      private string edtPublicacionesDetalleMateriales_Jsonclick ;
      private string edtPublicacionesFecVisita_Internalname ;
      private string edtPublicacionesFecVisita_Jsonclick ;
      private string edtPublicacionesHoraVisita_Internalname ;
      private string A848PublicacionesHoraVisita ;
      private string edtPublicacionesHoraVisita_Jsonclick ;
      private string edtPublicacionesDirVisita_Internalname ;
      private string edtPublicacionesDirVisita_Jsonclick ;
      private string edtPublicacionesCondiciones_Internalname ;
      private string edtPublicacionesCondiciones_Jsonclick ;
      private string edtPublicacionesTipoDesembolso_Internalname ;
      private string edtPublicacionesTipoDesembolso_Jsonclick ;
      private string edtPublicacionesOtroTipoDes_Internalname ;
      private string edtPublicacionesOtroTipoDes_Jsonclick ;
      private string edtPublicacionesModalidad_Internalname ;
      private string A852PublicacionesModalidad ;
      private string edtPublicacionesModalidad_Jsonclick ;
      private string edtPublicacionesPrecio_Internalname ;
      private string edtPublicacionesPrecio_Jsonclick ;
      private string dynMonedaId_Jsonclick ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string A119MonedaISOSimbolo ;
      private string edtMonedaISOSimbolo_Jsonclick ;
      private string edtPublicacionesFecCierre_Internalname ;
      private string edtPublicacionesFecCierre_Jsonclick ;
      private string edtPublicacionesDocReq_Internalname ;
      private string edtPublicacionesDocReq_Jsonclick ;
      private string edtPublicacionesDocDescripcion_Internalname ;
      private string edtPublicacionesDocDescripcion_Jsonclick ;
      private string edtPublicacionesTipoEmpresa_Internalname ;
      private string edtPublicacionesTipoEmpresa_Jsonclick ;
      private string edtPublicacionesContratoId_Internalname ;
      private string edtPublicacionesContratoId_Jsonclick ;
      private string edtPublicacionesTerminoObra_Internalname ;
      private string edtPublicacionesTerminoObra_Jsonclick ;
      private string cmbPublicacionesEstado_Jsonclick ;
      private string divTableleaflevel_documento_Internalname ;
      private string divTableleaflevel_multimedia_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPublicacionesSerialIma_Internalname ;
      private string edtPublicacionesSerialIma_Jsonclick ;
      private string edtPublicacionesSerialRem_Internalname ;
      private string edtPublicacionesSerialRem_Jsonclick ;
      private string sMode128 ;
      private string edtPublicacionesDocId_Internalname ;
      private string edtPublicacionesDoc_Internalname ;
      private string edtPublicacionesDocDescrip_Internalname ;
      private string sStyleString ;
      private string subGridlevel_documento_Internalname ;
      private string sMode129 ;
      private string edtPublicacionesMultId_Internalname ;
      private string edtPublicacionesMult_Internalname ;
      private string edtPublicacionesMultDescrip_Internalname ;
      private string subGridlevel_multimedia_Internalname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z119MonedaISOSimbolo ;
      private string sMode127 ;
      private string sGXsfl_153_fel_idx="0001" ;
      private string subGridlevel_documento_Class ;
      private string subGridlevel_documento_Linesclass ;
      private string ROClassString ;
      private string edtPublicacionesDocId_Jsonclick ;
      private string edtPublicacionesDoc_Jsonclick ;
      private string edtPublicacionesDocDescrip_Jsonclick ;
      private string sGXsfl_162_fel_idx="0001" ;
      private string subGridlevel_multimedia_Class ;
      private string subGridlevel_multimedia_Linesclass ;
      private string edtPublicacionesMultId_Jsonclick ;
      private string edtPublicacionesMult_Jsonclick ;
      private string edtPublicacionesMultDescrip_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_documento_Header ;
      private string subGridlevel_multimedia_Header ;
      private string gxwrpcisep ;
      private string ZZ382PublicacionesTitulo ;
      private string ZZ846PublicacionesDetalleMateriales ;
      private string ZZ848PublicacionesHoraVisita ;
      private string ZZ852PublicacionesModalidad ;
      private string ZZ384PublicacionesEstado ;
      private string ZZ119MonedaISOSimbolo ;
      private DateTime Z843PublicacionesFecTentInicio ;
      private DateTime Z844PublicacionesFecRealInicio ;
      private DateTime Z845PublicacionesFecFinPostulacion ;
      private DateTime Z847PublicacionesFecVisita ;
      private DateTime Z854PublicacionesFecCierre ;
      private DateTime A843PublicacionesFecTentInicio ;
      private DateTime A844PublicacionesFecRealInicio ;
      private DateTime A845PublicacionesFecFinPostulacion ;
      private DateTime A847PublicacionesFecVisita ;
      private DateTime A854PublicacionesFecCierre ;
      private DateTime ZZ843PublicacionesFecTentInicio ;
      private DateTime ZZ844PublicacionesFecRealInicio ;
      private DateTime ZZ845PublicacionesFecFinPostulacion ;
      private DateTime ZZ847PublicacionesFecVisita ;
      private DateTime ZZ854PublicacionesFecCierre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n118MonedaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_153_Refreshing=false ;
      private bool bGXsfl_162_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string A383PublicacionesDescripcion ;
      private string Z383PublicacionesDescripcion ;
      private string ZZ383PublicacionesDescripcion ;
      private string Z849PublicacionesDirVisita ;
      private string Z850PublicacionesCondiciones ;
      private string Z851PublicacionesTipoDesembolso ;
      private string Z859PublicacionesOtroTipoDes ;
      private string Z855PublicacionesDocReq ;
      private string Z856PublicacionesDocDescripcion ;
      private string Z857PublicacionesTipoEmpresa ;
      private string Z858PublicacionesContratoId ;
      private string Z860PublicacionesTerminoObra ;
      private string Z387PublicacionesDoc ;
      private string Z388PublicacionesDocDescrip ;
      private string Z392PublicacionesMult ;
      private string Z861PublicacionesMultDescrip ;
      private string A849PublicacionesDirVisita ;
      private string A850PublicacionesCondiciones ;
      private string A851PublicacionesTipoDesembolso ;
      private string A859PublicacionesOtroTipoDes ;
      private string A855PublicacionesDocReq ;
      private string A856PublicacionesDocDescripcion ;
      private string A857PublicacionesTipoEmpresa ;
      private string A858PublicacionesContratoId ;
      private string A860PublicacionesTerminoObra ;
      private string A392PublicacionesMult ;
      private string A861PublicacionesMultDescrip ;
      private string A387PublicacionesDoc ;
      private string A388PublicacionesDocDescrip ;
      private string ZZ849PublicacionesDirVisita ;
      private string ZZ850PublicacionesCondiciones ;
      private string ZZ851PublicacionesTipoDesembolso ;
      private string ZZ859PublicacionesOtroTipoDes ;
      private string ZZ855PublicacionesDocReq ;
      private string ZZ856PublicacionesDocDescripcion ;
      private string ZZ857PublicacionesTipoEmpresa ;
      private string ZZ858PublicacionesContratoId ;
      private string ZZ860PublicacionesTerminoObra ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Gridlevel_documentoContainer ;
      private GXWebGrid Gridlevel_multimediaContainer ;
      private GXWebRow Gridlevel_documentoRow ;
      private GXWebRow Gridlevel_multimediaRow ;
      private GXWebColumn Gridlevel_documentoColumn ;
      private GXWebColumn Gridlevel_multimediaColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynMonedaId ;
      private GXCombobox cmbPublicacionesEstado ;
      private IDataStoreProvider pr_default ;
      private long[] T001G10_A381PublicacionesId ;
      private string[] T001G10_A382PublicacionesTitulo ;
      private string[] T001G10_A383PublicacionesDescripcion ;
      private DateTime[] T001G10_A843PublicacionesFecTentInicio ;
      private DateTime[] T001G10_A844PublicacionesFecRealInicio ;
      private DateTime[] T001G10_A845PublicacionesFecFinPostulacion ;
      private string[] T001G10_A846PublicacionesDetalleMateriales ;
      private DateTime[] T001G10_A847PublicacionesFecVisita ;
      private string[] T001G10_A848PublicacionesHoraVisita ;
      private string[] T001G10_A849PublicacionesDirVisita ;
      private string[] T001G10_A850PublicacionesCondiciones ;
      private string[] T001G10_A851PublicacionesTipoDesembolso ;
      private string[] T001G10_A859PublicacionesOtroTipoDes ;
      private string[] T001G10_A852PublicacionesModalidad ;
      private decimal[] T001G10_A389PublicacionesPrecio ;
      private string[] T001G10_A119MonedaISOSimbolo ;
      private DateTime[] T001G10_A854PublicacionesFecCierre ;
      private string[] T001G10_A855PublicacionesDocReq ;
      private string[] T001G10_A856PublicacionesDocDescripcion ;
      private string[] T001G10_A857PublicacionesTipoEmpresa ;
      private string[] T001G10_A858PublicacionesContratoId ;
      private string[] T001G10_A860PublicacionesTerminoObra ;
      private string[] T001G10_A384PublicacionesEstado ;
      private short[] T001G10_A385PublicacionesSerialIma ;
      private short[] T001G10_A395PublicacionesSerialRem ;
      private long[] T001G10_A112DepartamentoId ;
      private long[] T001G10_A114DepartamentoMunicipioId ;
      private short[] T001G10_A118MonedaId ;
      private bool[] T001G10_n118MonedaId ;
      private long[] T001G8_A112DepartamentoId ;
      private string[] T001G9_A119MonedaISOSimbolo ;
      private long[] T001G11_A112DepartamentoId ;
      private string[] T001G12_A119MonedaISOSimbolo ;
      private long[] T001G13_A381PublicacionesId ;
      private long[] T001G7_A381PublicacionesId ;
      private string[] T001G7_A382PublicacionesTitulo ;
      private string[] T001G7_A383PublicacionesDescripcion ;
      private DateTime[] T001G7_A843PublicacionesFecTentInicio ;
      private DateTime[] T001G7_A844PublicacionesFecRealInicio ;
      private DateTime[] T001G7_A845PublicacionesFecFinPostulacion ;
      private string[] T001G7_A846PublicacionesDetalleMateriales ;
      private DateTime[] T001G7_A847PublicacionesFecVisita ;
      private string[] T001G7_A848PublicacionesHoraVisita ;
      private string[] T001G7_A849PublicacionesDirVisita ;
      private string[] T001G7_A850PublicacionesCondiciones ;
      private string[] T001G7_A851PublicacionesTipoDesembolso ;
      private string[] T001G7_A859PublicacionesOtroTipoDes ;
      private string[] T001G7_A852PublicacionesModalidad ;
      private decimal[] T001G7_A389PublicacionesPrecio ;
      private DateTime[] T001G7_A854PublicacionesFecCierre ;
      private string[] T001G7_A855PublicacionesDocReq ;
      private string[] T001G7_A856PublicacionesDocDescripcion ;
      private string[] T001G7_A857PublicacionesTipoEmpresa ;
      private string[] T001G7_A858PublicacionesContratoId ;
      private string[] T001G7_A860PublicacionesTerminoObra ;
      private string[] T001G7_A384PublicacionesEstado ;
      private short[] T001G7_A385PublicacionesSerialIma ;
      private short[] T001G7_A395PublicacionesSerialRem ;
      private long[] T001G7_A112DepartamentoId ;
      private long[] T001G7_A114DepartamentoMunicipioId ;
      private short[] T001G7_A118MonedaId ;
      private bool[] T001G7_n118MonedaId ;
      private long[] T001G14_A381PublicacionesId ;
      private long[] T001G15_A381PublicacionesId ;
      private long[] T001G6_A381PublicacionesId ;
      private string[] T001G6_A382PublicacionesTitulo ;
      private string[] T001G6_A383PublicacionesDescripcion ;
      private DateTime[] T001G6_A843PublicacionesFecTentInicio ;
      private DateTime[] T001G6_A844PublicacionesFecRealInicio ;
      private DateTime[] T001G6_A845PublicacionesFecFinPostulacion ;
      private string[] T001G6_A846PublicacionesDetalleMateriales ;
      private DateTime[] T001G6_A847PublicacionesFecVisita ;
      private string[] T001G6_A848PublicacionesHoraVisita ;
      private string[] T001G6_A849PublicacionesDirVisita ;
      private string[] T001G6_A850PublicacionesCondiciones ;
      private string[] T001G6_A851PublicacionesTipoDesembolso ;
      private string[] T001G6_A859PublicacionesOtroTipoDes ;
      private string[] T001G6_A852PublicacionesModalidad ;
      private decimal[] T001G6_A389PublicacionesPrecio ;
      private DateTime[] T001G6_A854PublicacionesFecCierre ;
      private string[] T001G6_A855PublicacionesDocReq ;
      private string[] T001G6_A856PublicacionesDocDescripcion ;
      private string[] T001G6_A857PublicacionesTipoEmpresa ;
      private string[] T001G6_A858PublicacionesContratoId ;
      private string[] T001G6_A860PublicacionesTerminoObra ;
      private string[] T001G6_A384PublicacionesEstado ;
      private short[] T001G6_A385PublicacionesSerialIma ;
      private short[] T001G6_A395PublicacionesSerialRem ;
      private long[] T001G6_A112DepartamentoId ;
      private long[] T001G6_A114DepartamentoMunicipioId ;
      private short[] T001G6_A118MonedaId ;
      private bool[] T001G6_n118MonedaId ;
      private long[] T001G16_A381PublicacionesId ;
      private string[] T001G19_A119MonedaISOSimbolo ;
      private long[] T001G20_A381PublicacionesId ;
      private long[] T001G21_A381PublicacionesId ;
      private long[] T001G21_A386PublicacionesDocId ;
      private string[] T001G21_A387PublicacionesDoc ;
      private string[] T001G21_A388PublicacionesDocDescrip ;
      private long[] T001G22_A381PublicacionesId ;
      private long[] T001G22_A386PublicacionesDocId ;
      private long[] T001G5_A381PublicacionesId ;
      private long[] T001G5_A386PublicacionesDocId ;
      private string[] T001G5_A387PublicacionesDoc ;
      private string[] T001G5_A388PublicacionesDocDescrip ;
      private long[] T001G4_A381PublicacionesId ;
      private long[] T001G4_A386PublicacionesDocId ;
      private string[] T001G4_A387PublicacionesDoc ;
      private string[] T001G4_A388PublicacionesDocDescrip ;
      private long[] T001G26_A381PublicacionesId ;
      private long[] T001G26_A386PublicacionesDocId ;
      private long[] T001G27_A381PublicacionesId ;
      private long[] T001G27_A394PublicacionesMultId ;
      private string[] T001G27_A392PublicacionesMult ;
      private string[] T001G27_A861PublicacionesMultDescrip ;
      private long[] T001G28_A381PublicacionesId ;
      private long[] T001G28_A394PublicacionesMultId ;
      private long[] T001G3_A381PublicacionesId ;
      private long[] T001G3_A394PublicacionesMultId ;
      private string[] T001G3_A392PublicacionesMult ;
      private string[] T001G3_A861PublicacionesMultDescrip ;
      private long[] T001G2_A381PublicacionesId ;
      private long[] T001G2_A394PublicacionesMultId ;
      private string[] T001G2_A392PublicacionesMult ;
      private string[] T001G2_A861PublicacionesMultDescrip ;
      private long[] T001G32_A381PublicacionesId ;
      private long[] T001G32_A394PublicacionesMultId ;
      private short[] T001G33_A118MonedaId ;
      private bool[] T001G33_n118MonedaId ;
      private string[] T001G33_A119MonedaISOSimbolo ;
      private short[] T001G34_A118MonedaId ;
      private bool[] T001G34_n118MonedaId ;
      private string[] T001G34_A119MonedaISOSimbolo ;
      private long[] T001G35_A112DepartamentoId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class publicaciones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class publicaciones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
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
       ,new UpdateCursor(def[27])
       ,new UpdateCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001G2;
        prmT001G2 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmT001G3;
        prmT001G3 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmT001G4;
        prmT001G4 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmT001G5;
        prmT001G5 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmT001G6;
        prmT001G6 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G7;
        prmT001G7 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G8;
        prmT001G8 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT001G9;
        prmT001G9 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT001G10;
        prmT001G10 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G11;
        prmT001G11 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT001G12;
        prmT001G12 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT001G13;
        prmT001G13 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G14;
        prmT001G14 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G15;
        prmT001G15 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G16;
        prmT001G16 = new Object[] {
        new ParDef("@PublicacionesTitulo",GXType.NChar,80,0) ,
        new ParDef("@PublicacionesDescripcion",GXType.NVarChar,2097152,0) ,
        new ParDef("@PublicacionesFecTentInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecRealInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecFinPostulacion",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDetalleMateriales",GXType.NChar,100,0) ,
        new ParDef("@PublicacionesFecVisita",GXType.Date,8,0) ,
        new ParDef("@PublicacionesHoraVisita",GXType.NChar,8,0) ,
        new ParDef("@PublicacionesDirVisita",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesCondiciones",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoDesembolso",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesOtroTipoDes",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesModalidad",GXType.NChar,1,0) ,
        new ParDef("@PublicacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PublicacionesFecCierre",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDocReq",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesDocDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoEmpresa",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesContratoId",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesTerminoObra",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PublicacionesSerialIma",GXType.Int16,4,0) ,
        new ParDef("@PublicacionesSerialRem",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT001G17;
        prmT001G17 = new Object[] {
        new ParDef("@PublicacionesTitulo",GXType.NChar,80,0) ,
        new ParDef("@PublicacionesDescripcion",GXType.NVarChar,2097152,0) ,
        new ParDef("@PublicacionesFecTentInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecRealInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecFinPostulacion",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDetalleMateriales",GXType.NChar,100,0) ,
        new ParDef("@PublicacionesFecVisita",GXType.Date,8,0) ,
        new ParDef("@PublicacionesHoraVisita",GXType.NChar,8,0) ,
        new ParDef("@PublicacionesDirVisita",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesCondiciones",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoDesembolso",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesOtroTipoDes",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesModalidad",GXType.NChar,1,0) ,
        new ParDef("@PublicacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PublicacionesFecCierre",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDocReq",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesDocDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoEmpresa",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesContratoId",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesTerminoObra",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PublicacionesSerialIma",GXType.Int16,4,0) ,
        new ParDef("@PublicacionesSerialRem",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G18;
        prmT001G18 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G19;
        prmT001G19 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT001G20;
        prmT001G20 = new Object[] {
        };
        Object[] prmT001G21;
        prmT001G21 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmT001G22;
        prmT001G22 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmT001G23;
        prmT001G23 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDoc",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesDocDescrip",GXType.NVarChar,80,0)
        };
        Object[] prmT001G24;
        prmT001G24 = new Object[] {
        new ParDef("@PublicacionesDoc",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesDocDescrip",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmT001G25;
        prmT001G25 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmT001G26;
        prmT001G26 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G27;
        prmT001G27 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmT001G28;
        prmT001G28 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmT001G29;
        prmT001G29 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMult",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesMultDescrip",GXType.NVarChar,80,0)
        };
        Object[] prmT001G30;
        prmT001G30 = new Object[] {
        new ParDef("@PublicacionesMult",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesMultDescrip",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmT001G31;
        prmT001G31 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmT001G32;
        prmT001G32 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmT001G33;
        prmT001G33 = new Object[] {
        };
        Object[] prmT001G34;
        prmT001G34 = new Object[] {
        };
        Object[] prmT001G35;
        prmT001G35 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001G2", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WITH (UPDLOCK) WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G3", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G4", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WITH (UPDLOCK) WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G5", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G6", "SELECT [PublicacionesId], [PublicacionesTitulo], [PublicacionesDescripcion], [PublicacionesFecTentInicio], [PublicacionesFecRealInicio], [PublicacionesFecFinPostulacion], [PublicacionesDetalleMateriales], [PublicacionesFecVisita], [PublicacionesHoraVisita], [PublicacionesDirVisita], [PublicacionesCondiciones], [PublicacionesTipoDesembolso], [PublicacionesOtroTipoDes], [PublicacionesModalidad], [PublicacionesPrecio], [PublicacionesFecCierre], [PublicacionesDocReq], [PublicacionesDocDescripcion], [PublicacionesTipoEmpresa], [PublicacionesContratoId], [PublicacionesTerminoObra], [PublicacionesEstado], [PublicacionesSerialIma], [PublicacionesSerialRem], [DepartamentoId], [DepartamentoMunicipioId], [MonedaId] FROM [Publicaciones] WITH (UPDLOCK) WHERE [PublicacionesId] = @PublicacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G7", "SELECT [PublicacionesId], [PublicacionesTitulo], [PublicacionesDescripcion], [PublicacionesFecTentInicio], [PublicacionesFecRealInicio], [PublicacionesFecFinPostulacion], [PublicacionesDetalleMateriales], [PublicacionesFecVisita], [PublicacionesHoraVisita], [PublicacionesDirVisita], [PublicacionesCondiciones], [PublicacionesTipoDesembolso], [PublicacionesOtroTipoDes], [PublicacionesModalidad], [PublicacionesPrecio], [PublicacionesFecCierre], [PublicacionesDocReq], [PublicacionesDocDescripcion], [PublicacionesTipoEmpresa], [PublicacionesContratoId], [PublicacionesTerminoObra], [PublicacionesEstado], [PublicacionesSerialIma], [PublicacionesSerialRem], [DepartamentoId], [DepartamentoMunicipioId], [MonedaId] FROM [Publicaciones] WHERE [PublicacionesId] = @PublicacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G8", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G9", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G10", "SELECT TM1.[PublicacionesId], TM1.[PublicacionesTitulo], TM1.[PublicacionesDescripcion], TM1.[PublicacionesFecTentInicio], TM1.[PublicacionesFecRealInicio], TM1.[PublicacionesFecFinPostulacion], TM1.[PublicacionesDetalleMateriales], TM1.[PublicacionesFecVisita], TM1.[PublicacionesHoraVisita], TM1.[PublicacionesDirVisita], TM1.[PublicacionesCondiciones], TM1.[PublicacionesTipoDesembolso], TM1.[PublicacionesOtroTipoDes], TM1.[PublicacionesModalidad], TM1.[PublicacionesPrecio], T2.[MonedaISOSimbolo], TM1.[PublicacionesFecCierre], TM1.[PublicacionesDocReq], TM1.[PublicacionesDocDescripcion], TM1.[PublicacionesTipoEmpresa], TM1.[PublicacionesContratoId], TM1.[PublicacionesTerminoObra], TM1.[PublicacionesEstado], TM1.[PublicacionesSerialIma], TM1.[PublicacionesSerialRem], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], TM1.[MonedaId] FROM ([Publicaciones] TM1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = TM1.[MonedaId]) WHERE TM1.[PublicacionesId] = @PublicacionesId ORDER BY TM1.[PublicacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G11", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G12", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G13", "SELECT [PublicacionesId] FROM [Publicaciones] WHERE [PublicacionesId] = @PublicacionesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G14", "SELECT TOP 1 [PublicacionesId] FROM [Publicaciones] WHERE ( [PublicacionesId] > @PublicacionesId) ORDER BY [PublicacionesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001G15", "SELECT TOP 1 [PublicacionesId] FROM [Publicaciones] WHERE ( [PublicacionesId] < @PublicacionesId) ORDER BY [PublicacionesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001G16", "INSERT INTO [Publicaciones]([PublicacionesTitulo], [PublicacionesDescripcion], [PublicacionesFecTentInicio], [PublicacionesFecRealInicio], [PublicacionesFecFinPostulacion], [PublicacionesDetalleMateriales], [PublicacionesFecVisita], [PublicacionesHoraVisita], [PublicacionesDirVisita], [PublicacionesCondiciones], [PublicacionesTipoDesembolso], [PublicacionesOtroTipoDes], [PublicacionesModalidad], [PublicacionesPrecio], [PublicacionesFecCierre], [PublicacionesDocReq], [PublicacionesDocDescripcion], [PublicacionesTipoEmpresa], [PublicacionesContratoId], [PublicacionesTerminoObra], [PublicacionesEstado], [PublicacionesSerialIma], [PublicacionesSerialRem], [DepartamentoId], [DepartamentoMunicipioId], [MonedaId]) VALUES(@PublicacionesTitulo, @PublicacionesDescripcion, @PublicacionesFecTentInicio, @PublicacionesFecRealInicio, @PublicacionesFecFinPostulacion, @PublicacionesDetalleMateriales, @PublicacionesFecVisita, @PublicacionesHoraVisita, @PublicacionesDirVisita, @PublicacionesCondiciones, @PublicacionesTipoDesembolso, @PublicacionesOtroTipoDes, @PublicacionesModalidad, @PublicacionesPrecio, @PublicacionesFecCierre, @PublicacionesDocReq, @PublicacionesDocDescripcion, @PublicacionesTipoEmpresa, @PublicacionesContratoId, @PublicacionesTerminoObra, @PublicacionesEstado, @PublicacionesSerialIma, @PublicacionesSerialRem, @DepartamentoId, @DepartamentoMunicipioId, @MonedaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001G16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001G17", "UPDATE [Publicaciones] SET [PublicacionesTitulo]=@PublicacionesTitulo, [PublicacionesDescripcion]=@PublicacionesDescripcion, [PublicacionesFecTentInicio]=@PublicacionesFecTentInicio, [PublicacionesFecRealInicio]=@PublicacionesFecRealInicio, [PublicacionesFecFinPostulacion]=@PublicacionesFecFinPostulacion, [PublicacionesDetalleMateriales]=@PublicacionesDetalleMateriales, [PublicacionesFecVisita]=@PublicacionesFecVisita, [PublicacionesHoraVisita]=@PublicacionesHoraVisita, [PublicacionesDirVisita]=@PublicacionesDirVisita, [PublicacionesCondiciones]=@PublicacionesCondiciones, [PublicacionesTipoDesembolso]=@PublicacionesTipoDesembolso, [PublicacionesOtroTipoDes]=@PublicacionesOtroTipoDes, [PublicacionesModalidad]=@PublicacionesModalidad, [PublicacionesPrecio]=@PublicacionesPrecio, [PublicacionesFecCierre]=@PublicacionesFecCierre, [PublicacionesDocReq]=@PublicacionesDocReq, [PublicacionesDocDescripcion]=@PublicacionesDocDescripcion, [PublicacionesTipoEmpresa]=@PublicacionesTipoEmpresa, [PublicacionesContratoId]=@PublicacionesContratoId, [PublicacionesTerminoObra]=@PublicacionesTerminoObra, [PublicacionesEstado]=@PublicacionesEstado, [PublicacionesSerialIma]=@PublicacionesSerialIma, [PublicacionesSerialRem]=@PublicacionesSerialRem, [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [MonedaId]=@MonedaId  WHERE [PublicacionesId] = @PublicacionesId", GxErrorMask.GX_NOMASK,prmT001G17)
           ,new CursorDef("T001G18", "DELETE FROM [Publicaciones]  WHERE [PublicacionesId] = @PublicacionesId", GxErrorMask.GX_NOMASK,prmT001G18)
           ,new CursorDef("T001G19", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G20", "SELECT [PublicacionesId] FROM [Publicaciones] ORDER BY [PublicacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G21", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId and [PublicacionesDocId] = @PublicacionesDocId ORDER BY [PublicacionesId], [PublicacionesDocId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G22", "SELECT [PublicacionesId], [PublicacionesDocId] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G23", "INSERT INTO [PublicacionesDocumento]([PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip]) VALUES(@PublicacionesId, @PublicacionesDocId, @PublicacionesDoc, @PublicacionesDocDescrip)", GxErrorMask.GX_NOMASK,prmT001G23)
           ,new CursorDef("T001G24", "UPDATE [PublicacionesDocumento] SET [PublicacionesDoc]=@PublicacionesDoc, [PublicacionesDocDescrip]=@PublicacionesDocDescrip  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId", GxErrorMask.GX_NOMASK,prmT001G24)
           ,new CursorDef("T001G25", "DELETE FROM [PublicacionesDocumento]  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId", GxErrorMask.GX_NOMASK,prmT001G25)
           ,new CursorDef("T001G26", "SELECT [PublicacionesId], [PublicacionesDocId] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId ORDER BY [PublicacionesId], [PublicacionesDocId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G26,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G27", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId and [PublicacionesMultId] = @PublicacionesMultId ORDER BY [PublicacionesId], [PublicacionesMultId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G27,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G28", "SELECT [PublicacionesId], [PublicacionesMultId] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G29", "INSERT INTO [PublicacionesMultimedia]([PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip]) VALUES(@PublicacionesId, @PublicacionesMultId, @PublicacionesMult, @PublicacionesMultDescrip)", GxErrorMask.GX_NOMASK,prmT001G29)
           ,new CursorDef("T001G30", "UPDATE [PublicacionesMultimedia] SET [PublicacionesMult]=@PublicacionesMult, [PublicacionesMultDescrip]=@PublicacionesMultDescrip  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId", GxErrorMask.GX_NOMASK,prmT001G30)
           ,new CursorDef("T001G31", "DELETE FROM [PublicacionesMultimedia]  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId", GxErrorMask.GX_NOMASK,prmT001G31)
           ,new CursorDef("T001G32", "SELECT [PublicacionesId], [PublicacionesMultId] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId ORDER BY [PublicacionesId], [PublicacionesMultId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G32,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G33", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G33,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G34", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G34,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G35", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G35,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 3);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((bool[]) buf[27])[0] = rslt.wasNull(27);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 3);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((bool[]) buf[27])[0] = rslt.wasNull(27);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 3);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 3);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((long[]) buf[26])[0] = rslt.getLong(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((bool[]) buf[28])[0] = rslt.wasNull(28);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
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
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 31 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 32 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

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
   public class clientes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOMUNICIPIOID") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLADEPARTAMENTOMUNICIPIOID0I20( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
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
            gxLoad_17( A112DepartamentoId, A114DepartamentoMunicipioId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "clientes.aspx")), "clientes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "clientes.aspx")))) ;
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
                  AV7ClientesId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClientesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ClientesId", StringUtil.LTrimStr( (decimal)(AV7ClientesId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClientesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Clientes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbClientesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ClientesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ClientesId = aP1_ClientesId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbClientesEstado = new GXCombobox();
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
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
         if ( cmbClientesEstado.ItemCount > 0 )
         {
            A435ClientesEstado = cmbClientesEstado.getValidValue(A435ClientesEstado);
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
            AssignProp("", false, cmbClientesEstado_Internalname, "Values", cmbClientesEstado.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp("", false, dynDepartamentoId_Internalname, "Values", dynDepartamentoId.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtClientesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClientesEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbClientesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbClientesEstado, cmbClientesEstado_Internalname, StringUtil.RTrim( A435ClientesEstado), 1, cmbClientesEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbClientesEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Clientes.htm");
         cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
         AssignProp("", false, cmbClientesEstado_Internalname, "Values", (string)(cmbClientesEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesNombre_Internalname, StringUtil.RTrim( A160ClientesNombre), StringUtil.RTrim( context.localUtil.Format( A160ClientesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesIdentidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesIdentidad_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesIdentidad_Internalname, StringUtil.RTrim( A434ClientesIdentidad), StringUtil.RTrim( context.localUtil.Format( A434ClientesIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesIdentidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesIdentidad_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesTelefono_Internalname, context.GetMessage( "Telefóno", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A161ClientesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesTelefono_Internalname, StringUtil.RTrim( A161ClientesTelefono), StringUtil.RTrim( context.localUtil.Format( A161ClientesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtClientesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesEmail_Internalname, A162ClientesEmail, StringUtil.RTrim( context.localUtil.Format( A162ClientesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A162ClientesEmail, "", "", "", edtClientesEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoId, dynDepartamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)), 1, dynDepartamentoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_Clientes.htm");
         dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
         AssignProp("", false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoMunicipioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynDepartamentoMunicipioId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoMunicipioId, dynDepartamentoMunicipioId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)), 1, dynDepartamentoMunicipioId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoMunicipioId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_Clientes.htm");
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtClientesDireccion_Internalname, A163ClientesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A163ClientesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", 0, 1, edtClientesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgClientesImagen_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A164ClientesImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ClientesImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.PathToRelativeUrl( A164ClientesImagen));
         GxWebStd.gx_bitmap( context, imgClientesImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgClientesImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", "", "", 0, A164ClientesImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Clientes.htm");
         AssignProp("", false, imgClientesImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.PathToRelativeUrl( A164ClientesImagen)), true);
         AssignProp("", false, imgClientesImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A164ClientesImagen_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", edtPaisID_Visible, edtPaisID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Clientes.htm");
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
         E110I2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106ClientesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z435ClientesEstado = cgiGet( "Z435ClientesEstado");
               Z160ClientesNombre = cgiGet( "Z160ClientesNombre");
               Z434ClientesIdentidad = cgiGet( "Z434ClientesIdentidad");
               Z161ClientesTelefono = cgiGet( "Z161ClientesTelefono");
               Z162ClientesEmail = cgiGet( "Z162ClientesEmail");
               Z163ClientesDireccion = cgiGet( "Z163ClientesDireccion");
               Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_DepartamentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DepartamentoId), 18, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV14Insert_DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV14Insert_DepartamentoMunicipioId), 18, 0));
               A40000ClientesImagen_GXI = cgiGet( "CLIENTESIMAGEN_GXI");
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
               A106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClientesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
               cmbClientesEstado.CurrentValue = cgiGet( cmbClientesEstado_Internalname);
               A435ClientesEstado = cgiGet( cmbClientesEstado_Internalname);
               AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
               A160ClientesNombre = cgiGet( edtClientesNombre_Internalname);
               AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
               A434ClientesIdentidad = cgiGet( edtClientesIdentidad_Internalname);
               AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
               A161ClientesTelefono = cgiGet( edtClientesTelefono_Internalname);
               AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
               A162ClientesEmail = cgiGet( edtClientesEmail_Internalname);
               AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
               dynDepartamentoId.CurrentValue = cgiGet( dynDepartamentoId_Internalname);
               A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               dynDepartamentoMunicipioId.CurrentValue = cgiGet( dynDepartamentoMunicipioId_Internalname);
               A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoMunicipioId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               A163ClientesDireccion = cgiGet( edtClientesDireccion_Internalname);
               AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
               A164ClientesImagen = cgiGet( imgClientesImagen_Internalname);
               AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
               A116PaisID = cgiGet( edtPaisID_Internalname);
               AssignAttri("", false, "A116PaisID", A116PaisID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgClientesImagen_Internalname, ref  A164ClientesImagen, ref  A40000ClientesImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Clientes");
               A106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClientesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
               forbiddenHiddens.Add("ClientesId", context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_DepartamentoId", context.localUtil.Format( (decimal)(AV13Insert_DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_DepartamentoMunicipioId", context.localUtil.Format( (decimal)(AV14Insert_DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A106ClientesId != Z106ClientesId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("clientes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A106ClientesId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClientesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
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
                     sMode20 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode20;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound20 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIENTESID");
                        AnyError = 1;
                        GX_FocusControl = edtClientesId_Internalname;
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
                           E110I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120I2 ();
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
            E120I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I20( ) ;
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
            DisableAttributes0I20( ) ;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I20( ) ;
            }
            else
            {
               CheckExtendedTable0I20( ) ;
               CloseExtendedTableCursors0I20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0I0( )
      {
      }

      protected void E110I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV22Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DepartamentoId") == 0 )
               {
                  AV13Insert_DepartamentoId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_DepartamentoId", StringUtil.LTrimStr( (decimal)(AV13Insert_DepartamentoId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DepartamentoMunicipioId") == 0 )
               {
                  AV14Insert_DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV14Insert_DepartamentoMunicipioId), 18, 0));
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
         edtPaisID_Visible = 0;
         AssignProp("", false, edtPaisID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisID_Visible), 5, 0), true);
      }

      protected void E120I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("clientesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0I20( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z435ClientesEstado = T000I3_A435ClientesEstado[0];
               Z160ClientesNombre = T000I3_A160ClientesNombre[0];
               Z434ClientesIdentidad = T000I3_A434ClientesIdentidad[0];
               Z161ClientesTelefono = T000I3_A161ClientesTelefono[0];
               Z162ClientesEmail = T000I3_A162ClientesEmail[0];
               Z163ClientesDireccion = T000I3_A163ClientesDireccion[0];
               Z112DepartamentoId = T000I3_A112DepartamentoId[0];
               Z114DepartamentoMunicipioId = T000I3_A114DepartamentoMunicipioId[0];
            }
            else
            {
               Z435ClientesEstado = A435ClientesEstado;
               Z160ClientesNombre = A160ClientesNombre;
               Z434ClientesIdentidad = A434ClientesIdentidad;
               Z161ClientesTelefono = A161ClientesTelefono;
               Z162ClientesEmail = A162ClientesEmail;
               Z163ClientesDireccion = A163ClientesDireccion;
               Z112DepartamentoId = A112DepartamentoId;
               Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z106ClientesId = A106ClientesId;
            Z435ClientesEstado = A435ClientesEstado;
            Z160ClientesNombre = A160ClientesNombre;
            Z434ClientesIdentidad = A434ClientesIdentidad;
            Z164ClientesImagen = A164ClientesImagen;
            Z40000ClientesImagen_GXI = A40000ClientesImagen_GXI;
            Z161ClientesTelefono = A161ClientesTelefono;
            Z162ClientesEmail = A162ClientesEmail;
            Z163ClientesDireccion = A163ClientesDireccion;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z116PaisID = A116PaisID;
         }
      }

      protected void standaloneNotModal( )
      {
         edtClientesId_Enabled = 0;
         AssignProp("", false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtClientesId_Enabled = 0;
         AssignProp("", false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ClientesId) )
         {
            A106ClientesId = AV7ClientesId;
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DepartamentoId) )
         {
            dynDepartamentoId.Enabled = 0;
            AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         }
         else
         {
            dynDepartamentoId.Enabled = 1;
            AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_DepartamentoMunicipioId) )
         {
            dynDepartamentoMunicipioId.Enabled = 0;
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         }
         else
         {
            dynDepartamentoMunicipioId.Enabled = 1;
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A435ClientesEstado = "HAB";
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_DepartamentoMunicipioId) )
         {
            A114DepartamentoMunicipioId = AV14Insert_DepartamentoMunicipioId;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_DepartamentoId) )
         {
            A112DepartamentoId = AV13Insert_DepartamentoId;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A112DepartamentoId) && ( Gx_BScreen == 0 ) )
            {
               A112DepartamentoId = 1;
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV22Pgmname = "Clientes";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
            /* Using cursor T000I4 */
            pr_default.execute(2, new Object[] {A112DepartamentoId});
            A116PaisID = T000I4_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            pr_default.close(2);
            GXADEPARTAMENTOMUNICIPIOID_html0I20( A112DepartamentoId) ;
         }
      }

      protected void Load0I20( )
      {
         /* Using cursor T000I6 */
         pr_default.execute(4, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
            A435ClientesEstado = T000I6_A435ClientesEstado[0];
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
            A160ClientesNombre = T000I6_A160ClientesNombre[0];
            AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
            A434ClientesIdentidad = T000I6_A434ClientesIdentidad[0];
            AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
            A40000ClientesImagen_GXI = T000I6_A40000ClientesImagen_GXI[0];
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            A161ClientesTelefono = T000I6_A161ClientesTelefono[0];
            AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
            A162ClientesEmail = T000I6_A162ClientesEmail[0];
            AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
            A163ClientesDireccion = T000I6_A163ClientesDireccion[0];
            AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
            A112DepartamentoId = T000I6_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T000I6_A114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A116PaisID = T000I6_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            A164ClientesImagen = T000I6_A164ClientesImagen[0];
            AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            ZM0I20( -15) ;
         }
         pr_default.close(4);
         OnLoadActions0I20( ) ;
      }

      protected void OnLoadActions0I20( )
      {
         AV22Pgmname = "Clientes";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         GXADEPARTAMENTOMUNICIPIOID_html0I20( A112DepartamentoId) ;
      }

      protected void CheckExtendedTable0I20( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV22Pgmname = "Clientes";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         if ( ! ( GxRegex.IsMatch(A162ClientesEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CLIENTESEMAIL");
            AnyError = 1;
            GX_FocusControl = edtClientesEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000I4 */
         pr_default.execute(2, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A116PaisID = T000I4_A116PaisID[0];
         AssignAttri("", false, "A116PaisID", A116PaisID);
         pr_default.close(2);
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         GXADEPARTAMENTOMUNICIPIOID_html0I20( A112DepartamentoId) ;
         if ( ! ( ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A435ClientesEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Clientes Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CLIENTESESTADO");
            AnyError = 1;
            GX_FocusControl = cmbClientesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0I20( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( long A112DepartamentoId )
      {
         /* Using cursor T000I7 */
         pr_default.execute(5, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A116PaisID = T000I7_A116PaisID[0];
         AssignAttri("", false, "A116PaisID", A116PaisID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A116PaisID))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_17( long A112DepartamentoId ,
                                long A114DepartamentoMunicipioId )
      {
         /* Using cursor T000I8 */
         pr_default.execute(6, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0I20( )
      {
         /* Using cursor T000I9 */
         pr_default.execute(7, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I20( 15) ;
            RcdFound20 = 1;
            A106ClientesId = T000I3_A106ClientesId[0];
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
            A435ClientesEstado = T000I3_A435ClientesEstado[0];
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
            A160ClientesNombre = T000I3_A160ClientesNombre[0];
            AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
            A434ClientesIdentidad = T000I3_A434ClientesIdentidad[0];
            AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
            A40000ClientesImagen_GXI = T000I3_A40000ClientesImagen_GXI[0];
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            A161ClientesTelefono = T000I3_A161ClientesTelefono[0];
            AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
            A162ClientesEmail = T000I3_A162ClientesEmail[0];
            AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
            A163ClientesDireccion = T000I3_A163ClientesDireccion[0];
            AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
            A112DepartamentoId = T000I3_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T000I3_A114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A164ClientesImagen = T000I3_A164ClientesImagen[0];
            AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
            AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
            AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
            Z106ClientesId = A106ClientesId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0I20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0I20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0I20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I20( ) ;
         if ( RcdFound20 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound20 = 0;
         /* Using cursor T000I10 */
         pr_default.execute(8, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000I10_A106ClientesId[0] < A106ClientesId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000I10_A106ClientesId[0] > A106ClientesId ) ) )
            {
               A106ClientesId = T000I10_A106ClientesId[0];
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000I11 */
         pr_default.execute(9, new Object[] {A106ClientesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000I11_A106ClientesId[0] > A106ClientesId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000I11_A106ClientesId[0] < A106ClientesId ) ) )
            {
               A106ClientesId = T000I11_A106ClientesId[0];
               AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbClientesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A106ClientesId != Z106ClientesId )
               {
                  A106ClientesId = Z106ClientesId;
                  AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTESID");
                  AnyError = 1;
                  GX_FocusControl = edtClientesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbClientesEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0I20( ) ;
                  GX_FocusControl = cmbClientesEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A106ClientesId != Z106ClientesId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbClientesEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTESID");
                     AnyError = 1;
                     GX_FocusControl = edtClientesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbClientesEstado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I20( ) ;
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
         if ( A106ClientesId != Z106ClientesId )
         {
            A106ClientesId = Z106ClientesId;
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTESID");
            AnyError = 1;
            GX_FocusControl = edtClientesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbClientesEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0I20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {A106ClientesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Clientes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z435ClientesEstado, T000I2_A435ClientesEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z160ClientesNombre, T000I2_A160ClientesNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z434ClientesIdentidad, T000I2_A434ClientesIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z161ClientesTelefono, T000I2_A161ClientesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z162ClientesEmail, T000I2_A162ClientesEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z163ClientesDireccion, T000I2_A163ClientesDireccion[0]) != 0 ) || ( Z112DepartamentoId != T000I2_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != T000I2_A114DepartamentoMunicipioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z435ClientesEstado, T000I2_A435ClientesEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"ClientesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z435ClientesEstado);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A435ClientesEstado[0]);
               }
               if ( StringUtil.StrCmp(Z160ClientesNombre, T000I2_A160ClientesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"ClientesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z160ClientesNombre);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A160ClientesNombre[0]);
               }
               if ( StringUtil.StrCmp(Z434ClientesIdentidad, T000I2_A434ClientesIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"ClientesIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z434ClientesIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A434ClientesIdentidad[0]);
               }
               if ( StringUtil.StrCmp(Z161ClientesTelefono, T000I2_A161ClientesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"ClientesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z161ClientesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A161ClientesTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z162ClientesEmail, T000I2_A162ClientesEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"ClientesEmail");
                  GXUtil.WriteLogRaw("Old: ",Z162ClientesEmail);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A162ClientesEmail[0]);
               }
               if ( StringUtil.StrCmp(Z163ClientesDireccion, T000I2_A163ClientesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"ClientesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z163ClientesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A163ClientesDireccion[0]);
               }
               if ( Z112DepartamentoId != T000I2_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A112DepartamentoId[0]);
               }
               if ( Z114DepartamentoMunicipioId != T000I2_A114DepartamentoMunicipioId[0] )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"DepartamentoMunicipioId");
                  GXUtil.WriteLogRaw("Old: ",Z114DepartamentoMunicipioId);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A114DepartamentoMunicipioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Clientes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I20( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I20( 0) ;
            CheckOptimisticConcurrency0I20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I12 */
                     pr_default.execute(10, new Object[] {A435ClientesEstado, A160ClientesNombre, A434ClientesIdentidad, A164ClientesImagen, A40000ClientesImagen_GXI, A161ClientesTelefono, A162ClientesEmail, A163ClientesDireccion, A112DepartamentoId, A114DepartamentoMunicipioId});
                     A106ClientesId = T000I12_A106ClientesId[0];
                     AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Clientes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0I0( ) ;
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
               Load0I20( ) ;
            }
            EndLevel0I20( ) ;
         }
         CloseExtendedTableCursors0I20( ) ;
      }

      protected void Update0I20( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I13 */
                     pr_default.execute(11, new Object[] {A435ClientesEstado, A160ClientesNombre, A434ClientesIdentidad, A161ClientesTelefono, A162ClientesEmail, A163ClientesDireccion, A112DepartamentoId, A114DepartamentoMunicipioId, A106ClientesId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Clientes");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Clientes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I20( ) ;
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
            EndLevel0I20( ) ;
         }
         CloseExtendedTableCursors0I20( ) ;
      }

      protected void DeferredUpdate0I20( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000I14 */
            pr_default.execute(12, new Object[] {A164ClientesImagen, A40000ClientesImagen_GXI, A106ClientesId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("Clientes");
         }
      }

      protected void delete( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I20( ) ;
            AfterConfirm0I20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I15 */
                  pr_default.execute(13, new Object[] {A106ClientesId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Clientes");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV22Pgmname = "Clientes";
            AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
            /* Using cursor T000I16 */
            pr_default.execute(14, new Object[] {A112DepartamentoId});
            A116PaisID = T000I16_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            pr_default.close(14);
            GXADEPARTAMENTOMUNICIPIOID_html0I20( A112DepartamentoId) ;
         }
      }

      protected void EndLevel0I20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(14);
            context.CommitDataStores("clientes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            context.RollbackDataStores("clientes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I20( )
      {
         /* Scan By routine */
         /* Using cursor T000I17 */
         pr_default.execute(15);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound20 = 1;
            A106ClientesId = T000I17_A106ClientesId[0];
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I20( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound20 = 1;
            A106ClientesId = T000I17_A106ClientesId[0];
            AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
      }

      protected void ScanEnd0I20( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0I20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I20( )
      {
         edtClientesId_Enabled = 0;
         AssignProp("", false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
         cmbClientesEstado.Enabled = 0;
         AssignProp("", false, cmbClientesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClientesEstado.Enabled), 5, 0), true);
         edtClientesNombre_Enabled = 0;
         AssignProp("", false, edtClientesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesNombre_Enabled), 5, 0), true);
         edtClientesIdentidad_Enabled = 0;
         AssignProp("", false, edtClientesIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesIdentidad_Enabled), 5, 0), true);
         edtClientesTelefono_Enabled = 0;
         AssignProp("", false, edtClientesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesTelefono_Enabled), 5, 0), true);
         edtClientesEmail_Enabled = 0;
         AssignProp("", false, edtClientesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesEmail_Enabled), 5, 0), true);
         dynDepartamentoId.Enabled = 0;
         AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         edtClientesDireccion_Enabled = 0;
         AssignProp("", false, edtClientesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesDireccion_Enabled), 5, 0), true);
         imgClientesImagen_Enabled = 0;
         AssignProp("", false, imgClientesImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgClientesImagen_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         GXEncryptionTmp = "clientes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClientesId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Clientes");
         forbiddenHiddens.Add("ClientesId", context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_DepartamentoId", context.localUtil.Format( (decimal)(AV13Insert_DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_DepartamentoMunicipioId", context.localUtil.Format( (decimal)(AV14Insert_DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clientes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z106ClientesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z435ClientesEstado", StringUtil.RTrim( Z435ClientesEstado));
         GxWebStd.gx_hidden_field( context, "Z160ClientesNombre", StringUtil.RTrim( Z160ClientesNombre));
         GxWebStd.gx_hidden_field( context, "Z434ClientesIdentidad", StringUtil.RTrim( Z434ClientesIdentidad));
         GxWebStd.gx_hidden_field( context, "Z161ClientesTelefono", StringUtil.RTrim( Z161ClientesTelefono));
         GxWebStd.gx_hidden_field( context, "Z162ClientesEmail", Z162ClientesEmail);
         GxWebStd.gx_hidden_field( context, "Z163ClientesDireccion", Z163ClientesDireccion);
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vCLIENTESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClientesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_DEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CLIENTESIMAGEN_GXI", A40000ClientesImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GXCCtlgxBlob = "CLIENTESIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A164ClientesImagen);
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
         GXEncryptionTmp = "clientes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClientesId,18,0));
         return formatLink("clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Clientes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Clientes", "") ;
      }

      protected void InitializeNonKey0I20( )
      {
         A114DepartamentoMunicipioId = 0;
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         A435ClientesEstado = "";
         AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         A160ClientesNombre = "";
         AssignAttri("", false, "A160ClientesNombre", A160ClientesNombre);
         A434ClientesIdentidad = "";
         AssignAttri("", false, "A434ClientesIdentidad", A434ClientesIdentidad);
         A164ClientesImagen = "";
         AssignAttri("", false, "A164ClientesImagen", A164ClientesImagen);
         AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
         AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
         A40000ClientesImagen_GXI = "";
         AssignProp("", false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
         AssignProp("", false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
         A161ClientesTelefono = "";
         AssignAttri("", false, "A161ClientesTelefono", A161ClientesTelefono);
         A162ClientesEmail = "";
         AssignAttri("", false, "A162ClientesEmail", A162ClientesEmail);
         A163ClientesDireccion = "";
         AssignAttri("", false, "A163ClientesDireccion", A163ClientesDireccion);
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         A112DepartamentoId = 1;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         Z435ClientesEstado = "";
         Z160ClientesNombre = "";
         Z434ClientesIdentidad = "";
         Z161ClientesTelefono = "";
         Z162ClientesEmail = "";
         Z163ClientesDireccion = "";
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
      }

      protected void InitAll0I20( )
      {
         A106ClientesId = 0;
         AssignAttri("", false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         InitializeNonKey0I20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A435ClientesEstado = i435ClientesEstado;
         AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         A112DepartamentoId = i112DepartamentoId;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319584060", true, true, false);
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
         context.AddJavascriptSource("clientes.js", "?20269319584061", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtClientesId_Internalname = "CLIENTESID";
         cmbClientesEstado_Internalname = "CLIENTESESTADO";
         edtClientesNombre_Internalname = "CLIENTESNOMBRE";
         edtClientesIdentidad_Internalname = "CLIENTESIDENTIDAD";
         edtClientesTelefono_Internalname = "CLIENTESTELEFONO";
         edtClientesEmail_Internalname = "CLIENTESEMAIL";
         dynDepartamentoId_Internalname = "DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtClientesDireccion_Internalname = "CLIENTESDIRECCION";
         imgClientesImagen_Internalname = "CLIENTESIMAGEN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtPaisID_Internalname = "PAISID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Caption = context.GetMessage( "Clientes", "");
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtPaisID_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgClientesImagen_Enabled = 1;
         edtClientesDireccion_Enabled = 1;
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoMunicipioId.Enabled = 1;
         dynDepartamentoId_Jsonclick = "";
         dynDepartamentoId.Enabled = 1;
         edtClientesEmail_Jsonclick = "";
         edtClientesEmail_Enabled = 1;
         edtClientesTelefono_Jsonclick = "";
         edtClientesTelefono_Enabled = 1;
         edtClientesIdentidad_Jsonclick = "";
         edtClientesIdentidad_Enabled = 1;
         edtClientesNombre_Jsonclick = "";
         edtClientesNombre_Enabled = 1;
         cmbClientesEstado_Jsonclick = "";
         cmbClientesEstado.Enabled = 1;
         edtClientesId_Jsonclick = "";
         edtClientesId_Enabled = 0;
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
         GXADEPARTAMENTOMUNICIPIOID_html0I20( A112DepartamentoId) ;
         /* End function dynload_actions */
      }

      protected void GXDLADEPARTAMENTOID0I1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOID_data0I1( ) ;
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

      protected void GXADEPARTAMENTOID_html0I1( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOID_data0I1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLADEPARTAMENTOID_data0I1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000I18 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000I18_A112DepartamentoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000I18_A113DepartamentoDepartamento[0]));
            pr_default.readNext(16);
         }
         pr_default.close(16);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID0I20( long A112DepartamentoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_data0I20( A112DepartamentoId) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_html0I20( long A112DepartamentoId )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_data0I20( A112DepartamentoId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoMunicipioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoMunicipioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID_data0I20( long A112DepartamentoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000I19 */
         pr_default.execute(17, new Object[] {A112DepartamentoId});
         while ( (pr_default.getStatus(17) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000I19_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000I19_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(17);
         }
         pr_default.close(17);
      }

      protected void init_web_controls( )
      {
         cmbClientesEstado.Name = "CLIENTESESTADO";
         cmbClientesEstado.WebTags = "";
         cmbClientesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbClientesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbClientesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbClientesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbClientesEstado.ItemCount > 0 )
         {
            A435ClientesEstado = cmbClientesEstado.getValidValue(A435ClientesEstado);
            AssignAttri("", false, "A435ClientesEstado", A435ClientesEstado);
         }
         dynDepartamentoId.Name = "DEPARTAMENTOID";
         dynDepartamentoId.WebTags = "";
         dynDepartamentoId.removeAllItems();
         /* Using cursor T000I20 */
         pr_default.execute(18);
         while ( (pr_default.getStatus(18) != 101) )
         {
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000I20_A112DepartamentoId[0]), 18, 0)), T000I20_A113DepartamentoDepartamento[0], 0);
            pr_default.readNext(18);
         }
         pr_default.close(18);
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A112DepartamentoId) )
            {
               A112DepartamentoId = 1;
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
         }
         dynDepartamentoMunicipioId.Name = "DEPARTAMENTOMUNICIPIOID";
         dynDepartamentoMunicipioId.WebTags = "";
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

      public void Valid_Departamentoid( )
      {
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000I16 */
         pr_default.execute(14, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
         }
         A116PaisID = T000I16_A116PaisID[0];
         pr_default.close(14);
         GXADEPARTAMENTOMUNICIPIOID_html0I20( A112DepartamentoId) ;
         dynload_actions( ) ;
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A116PaisID", StringUtil.RTrim( A116PaisID));
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
      }

      public void Valid_Departamentomunicipioid( )
      {
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000I21 */
         pr_default.execute(19, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ClientesId',fld:'vCLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ClientesId',fld:'vCLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A106ClientesId',fld:'CLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13Insert_DepartamentoId',fld:'vINSERT_DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14Insert_DepartamentoMunicipioId',fld:'vINSERT_DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120I2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_CLIENTESID","{handler:'Valid_Clientesid',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_CLIENTESID",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_CLIENTESESTADO","{handler:'Valid_Clientesestado',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_CLIENTESESTADO",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_CLIENTESEMAIL","{handler:'Valid_Clientesemail',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_CLIENTESEMAIL",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
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
         pr_default.close(14);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z435ClientesEstado = "";
         Z160ClientesNombre = "";
         Z434ClientesIdentidad = "";
         Z161ClientesTelefono = "";
         Z162ClientesEmail = "";
         Z163ClientesDireccion = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A435ClientesEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A160ClientesNombre = "";
         A434ClientesIdentidad = "";
         gxphoneLink = "";
         A161ClientesTelefono = "";
         A162ClientesEmail = "";
         A163ClientesDireccion = "";
         A164ClientesImagen = "";
         A40000ClientesImagen_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A116PaisID = "";
         AV22Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode20 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z164ClientesImagen = "";
         Z40000ClientesImagen_GXI = "";
         Z116PaisID = "";
         T000I4_A116PaisID = new string[] {""} ;
         T000I6_A106ClientesId = new long[1] ;
         T000I6_A435ClientesEstado = new string[] {""} ;
         T000I6_A160ClientesNombre = new string[] {""} ;
         T000I6_A434ClientesIdentidad = new string[] {""} ;
         T000I6_A40000ClientesImagen_GXI = new string[] {""} ;
         T000I6_A161ClientesTelefono = new string[] {""} ;
         T000I6_A162ClientesEmail = new string[] {""} ;
         T000I6_A163ClientesDireccion = new string[] {""} ;
         T000I6_A112DepartamentoId = new long[1] ;
         T000I6_A114DepartamentoMunicipioId = new long[1] ;
         T000I6_A116PaisID = new string[] {""} ;
         T000I6_A164ClientesImagen = new string[] {""} ;
         T000I5_A112DepartamentoId = new long[1] ;
         T000I7_A116PaisID = new string[] {""} ;
         T000I8_A112DepartamentoId = new long[1] ;
         T000I9_A106ClientesId = new long[1] ;
         T000I3_A106ClientesId = new long[1] ;
         T000I3_A435ClientesEstado = new string[] {""} ;
         T000I3_A160ClientesNombre = new string[] {""} ;
         T000I3_A434ClientesIdentidad = new string[] {""} ;
         T000I3_A40000ClientesImagen_GXI = new string[] {""} ;
         T000I3_A161ClientesTelefono = new string[] {""} ;
         T000I3_A162ClientesEmail = new string[] {""} ;
         T000I3_A163ClientesDireccion = new string[] {""} ;
         T000I3_A112DepartamentoId = new long[1] ;
         T000I3_A114DepartamentoMunicipioId = new long[1] ;
         T000I3_A164ClientesImagen = new string[] {""} ;
         T000I10_A106ClientesId = new long[1] ;
         T000I11_A106ClientesId = new long[1] ;
         T000I2_A106ClientesId = new long[1] ;
         T000I2_A435ClientesEstado = new string[] {""} ;
         T000I2_A160ClientesNombre = new string[] {""} ;
         T000I2_A434ClientesIdentidad = new string[] {""} ;
         T000I2_A40000ClientesImagen_GXI = new string[] {""} ;
         T000I2_A161ClientesTelefono = new string[] {""} ;
         T000I2_A162ClientesEmail = new string[] {""} ;
         T000I2_A163ClientesDireccion = new string[] {""} ;
         T000I2_A112DepartamentoId = new long[1] ;
         T000I2_A114DepartamentoMunicipioId = new long[1] ;
         T000I2_A164ClientesImagen = new string[] {""} ;
         T000I12_A106ClientesId = new long[1] ;
         T000I16_A116PaisID = new string[] {""} ;
         T000I17_A106ClientesId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i435ClientesEstado = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000I18_A112DepartamentoId = new long[1] ;
         T000I18_A113DepartamentoDepartamento = new string[] {""} ;
         T000I19_A112DepartamentoId = new long[1] ;
         T000I19_A114DepartamentoMunicipioId = new long[1] ;
         T000I19_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T000I20_A112DepartamentoId = new long[1] ;
         T000I20_A113DepartamentoDepartamento = new string[] {""} ;
         T000I21_A112DepartamentoId = new long[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.clientes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientes__default(),
            new Object[][] {
                new Object[] {
               T000I2_A106ClientesId, T000I2_A435ClientesEstado, T000I2_A160ClientesNombre, T000I2_A434ClientesIdentidad, T000I2_A40000ClientesImagen_GXI, T000I2_A161ClientesTelefono, T000I2_A162ClientesEmail, T000I2_A163ClientesDireccion, T000I2_A112DepartamentoId, T000I2_A114DepartamentoMunicipioId,
               T000I2_A164ClientesImagen
               }
               , new Object[] {
               T000I3_A106ClientesId, T000I3_A435ClientesEstado, T000I3_A160ClientesNombre, T000I3_A434ClientesIdentidad, T000I3_A40000ClientesImagen_GXI, T000I3_A161ClientesTelefono, T000I3_A162ClientesEmail, T000I3_A163ClientesDireccion, T000I3_A112DepartamentoId, T000I3_A114DepartamentoMunicipioId,
               T000I3_A164ClientesImagen
               }
               , new Object[] {
               T000I4_A116PaisID
               }
               , new Object[] {
               T000I5_A112DepartamentoId
               }
               , new Object[] {
               T000I6_A106ClientesId, T000I6_A435ClientesEstado, T000I6_A160ClientesNombre, T000I6_A434ClientesIdentidad, T000I6_A40000ClientesImagen_GXI, T000I6_A161ClientesTelefono, T000I6_A162ClientesEmail, T000I6_A163ClientesDireccion, T000I6_A112DepartamentoId, T000I6_A114DepartamentoMunicipioId,
               T000I6_A116PaisID, T000I6_A164ClientesImagen
               }
               , new Object[] {
               T000I7_A116PaisID
               }
               , new Object[] {
               T000I8_A112DepartamentoId
               }
               , new Object[] {
               T000I9_A106ClientesId
               }
               , new Object[] {
               T000I10_A106ClientesId
               }
               , new Object[] {
               T000I11_A106ClientesId
               }
               , new Object[] {
               T000I12_A106ClientesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I16_A116PaisID
               }
               , new Object[] {
               T000I17_A106ClientesId
               }
               , new Object[] {
               T000I18_A112DepartamentoId, T000I18_A113DepartamentoDepartamento
               }
               , new Object[] {
               T000I19_A112DepartamentoId, T000I19_A114DepartamentoMunicipioId, T000I19_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               T000I20_A112DepartamentoId, T000I20_A113DepartamentoDepartamento
               }
               , new Object[] {
               T000I21_A112DepartamentoId
               }
            }
         );
         AV22Pgmname = "Clientes";
         Z112DepartamentoId = 1;
         N112DepartamentoId = 1;
         i112DepartamentoId = 1;
         A112DepartamentoId = 1;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound20 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtClientesId_Enabled ;
      private int edtClientesNombre_Enabled ;
      private int edtClientesIdentidad_Enabled ;
      private int edtClientesTelefono_Enabled ;
      private int edtClientesEmail_Enabled ;
      private int edtClientesDireccion_Enabled ;
      private int imgClientesImagen_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtPaisID_Visible ;
      private int edtPaisID_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV7ClientesId ;
      private long Z106ClientesId ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long N112DepartamentoId ;
      private long N114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long AV7ClientesId ;
      private long A106ClientesId ;
      private long AV13Insert_DepartamentoId ;
      private long AV14Insert_DepartamentoMunicipioId ;
      private long i112DepartamentoId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z435ClientesEstado ;
      private string Z160ClientesNombre ;
      private string Z434ClientesIdentidad ;
      private string Z161ClientesTelefono ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbClientesEstado_Internalname ;
      private string A435ClientesEstado ;
      private string dynDepartamentoId_Internalname ;
      private string dynDepartamentoMunicipioId_Internalname ;
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
      private string edtClientesId_Internalname ;
      private string TempTags ;
      private string edtClientesId_Jsonclick ;
      private string cmbClientesEstado_Jsonclick ;
      private string edtClientesNombre_Internalname ;
      private string A160ClientesNombre ;
      private string edtClientesNombre_Jsonclick ;
      private string edtClientesIdentidad_Internalname ;
      private string A434ClientesIdentidad ;
      private string edtClientesIdentidad_Jsonclick ;
      private string edtClientesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A161ClientesTelefono ;
      private string edtClientesTelefono_Jsonclick ;
      private string edtClientesEmail_Internalname ;
      private string edtClientesEmail_Jsonclick ;
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string edtClientesDireccion_Internalname ;
      private string imgClientesImagen_Internalname ;
      private string sImgUrl ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPaisID_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Jsonclick ;
      private string AV22Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode20 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z116PaisID ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i435ClientesEstado ;
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
      private bool A164ClientesImagen_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string Z162ClientesEmail ;
      private string Z163ClientesDireccion ;
      private string A162ClientesEmail ;
      private string A163ClientesDireccion ;
      private string A40000ClientesImagen_GXI ;
      private string Z40000ClientesImagen_GXI ;
      private string A164ClientesImagen ;
      private string Z164ClientesImagen ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbClientesEstado ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000I4_A116PaisID ;
      private long[] T000I6_A106ClientesId ;
      private string[] T000I6_A435ClientesEstado ;
      private string[] T000I6_A160ClientesNombre ;
      private string[] T000I6_A434ClientesIdentidad ;
      private string[] T000I6_A40000ClientesImagen_GXI ;
      private string[] T000I6_A161ClientesTelefono ;
      private string[] T000I6_A162ClientesEmail ;
      private string[] T000I6_A163ClientesDireccion ;
      private long[] T000I6_A112DepartamentoId ;
      private long[] T000I6_A114DepartamentoMunicipioId ;
      private string[] T000I6_A116PaisID ;
      private string[] T000I6_A164ClientesImagen ;
      private long[] T000I5_A112DepartamentoId ;
      private string[] T000I7_A116PaisID ;
      private long[] T000I8_A112DepartamentoId ;
      private long[] T000I9_A106ClientesId ;
      private long[] T000I3_A106ClientesId ;
      private string[] T000I3_A435ClientesEstado ;
      private string[] T000I3_A160ClientesNombre ;
      private string[] T000I3_A434ClientesIdentidad ;
      private string[] T000I3_A40000ClientesImagen_GXI ;
      private string[] T000I3_A161ClientesTelefono ;
      private string[] T000I3_A162ClientesEmail ;
      private string[] T000I3_A163ClientesDireccion ;
      private long[] T000I3_A112DepartamentoId ;
      private long[] T000I3_A114DepartamentoMunicipioId ;
      private string[] T000I3_A164ClientesImagen ;
      private long[] T000I10_A106ClientesId ;
      private long[] T000I11_A106ClientesId ;
      private long[] T000I2_A106ClientesId ;
      private string[] T000I2_A435ClientesEstado ;
      private string[] T000I2_A160ClientesNombre ;
      private string[] T000I2_A434ClientesIdentidad ;
      private string[] T000I2_A40000ClientesImagen_GXI ;
      private string[] T000I2_A161ClientesTelefono ;
      private string[] T000I2_A162ClientesEmail ;
      private string[] T000I2_A163ClientesDireccion ;
      private long[] T000I2_A112DepartamentoId ;
      private long[] T000I2_A114DepartamentoMunicipioId ;
      private string[] T000I2_A164ClientesImagen ;
      private long[] T000I12_A106ClientesId ;
      private string[] T000I16_A116PaisID ;
      private long[] T000I17_A106ClientesId ;
      private long[] T000I18_A112DepartamentoId ;
      private string[] T000I18_A113DepartamentoDepartamento ;
      private long[] T000I19_A112DepartamentoId ;
      private long[] T000I19_A114DepartamentoMunicipioId ;
      private string[] T000I19_A115DepartamentoMunicipioNombre ;
      private long[] T000I20_A112DepartamentoId ;
      private string[] T000I20_A113DepartamentoDepartamento ;
      private long[] T000I21_A112DepartamentoId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class clientes__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class clientes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000I2;
        prmT000I2 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I3;
        prmT000I3 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I4;
        prmT000I4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000I5;
        prmT000I5 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000I6;
        prmT000I6 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I7;
        prmT000I7 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000I8;
        prmT000I8 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000I9;
        prmT000I9 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I10;
        prmT000I10 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I11;
        prmT000I11 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I12;
        prmT000I12 = new Object[] {
        new ParDef("@ClientesEstado",GXType.NChar,3,0) ,
        new ParDef("@ClientesNombre",GXType.NChar,100,0) ,
        new ParDef("@ClientesIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ClientesImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ClientesImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Clientes", Fld="ClientesImagen"} ,
        new ParDef("@ClientesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ClientesEmail",GXType.NVarChar,100,0) ,
        new ParDef("@ClientesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000I13;
        prmT000I13 = new Object[] {
        new ParDef("@ClientesEstado",GXType.NChar,3,0) ,
        new ParDef("@ClientesNombre",GXType.NChar,100,0) ,
        new ParDef("@ClientesIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ClientesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ClientesEmail",GXType.NVarChar,100,0) ,
        new ParDef("@ClientesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I14;
        prmT000I14 = new Object[] {
        new ParDef("@ClientesImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ClientesImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Clientes", Fld="ClientesImagen"} ,
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I15;
        prmT000I15 = new Object[] {
        new ParDef("@ClientesId",GXType.Decimal,18,0)
        };
        Object[] prmT000I16;
        prmT000I16 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000I17;
        prmT000I17 = new Object[] {
        };
        Object[] prmT000I18;
        prmT000I18 = new Object[] {
        };
        Object[] prmT000I19;
        prmT000I19 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000I20;
        prmT000I20 = new Object[] {
        };
        Object[] prmT000I21;
        prmT000I21 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000I2", "SELECT [ClientesId], [ClientesEstado], [ClientesNombre], [ClientesIdentidad], [ClientesImagen_GXI], [ClientesTelefono], [ClientesEmail], [ClientesDireccion], [DepartamentoId], [DepartamentoMunicipioId], [ClientesImagen] FROM [Clientes] WITH (UPDLOCK) WHERE [ClientesId] = @ClientesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I3", "SELECT [ClientesId], [ClientesEstado], [ClientesNombre], [ClientesIdentidad], [ClientesImagen_GXI], [ClientesTelefono], [ClientesEmail], [ClientesDireccion], [DepartamentoId], [DepartamentoMunicipioId], [ClientesImagen] FROM [Clientes] WHERE [ClientesId] = @ClientesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I4", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I5", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I6", "SELECT TM1.[ClientesId], TM1.[ClientesEstado], TM1.[ClientesNombre], TM1.[ClientesIdentidad], TM1.[ClientesImagen_GXI], TM1.[ClientesTelefono], TM1.[ClientesEmail], TM1.[ClientesDireccion], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], T2.[PaisID], TM1.[ClientesImagen] FROM ([Clientes] TM1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = TM1.[DepartamentoId]) WHERE TM1.[ClientesId] = @ClientesId ORDER BY TM1.[ClientesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I7", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I8", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I9", "SELECT [ClientesId] FROM [Clientes] WHERE [ClientesId] = @ClientesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I10", "SELECT TOP 1 [ClientesId] FROM [Clientes] WHERE ( [ClientesId] > @ClientesId) ORDER BY [ClientesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I11", "SELECT TOP 1 [ClientesId] FROM [Clientes] WHERE ( [ClientesId] < @ClientesId) ORDER BY [ClientesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I12", "INSERT INTO [Clientes]([ClientesEstado], [ClientesNombre], [ClientesIdentidad], [ClientesImagen], [ClientesImagen_GXI], [ClientesTelefono], [ClientesEmail], [ClientesDireccion], [DepartamentoId], [DepartamentoMunicipioId]) VALUES(@ClientesEstado, @ClientesNombre, @ClientesIdentidad, @ClientesImagen, @ClientesImagen_GXI, @ClientesTelefono, @ClientesEmail, @ClientesDireccion, @DepartamentoId, @DepartamentoMunicipioId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000I12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I13", "UPDATE [Clientes] SET [ClientesEstado]=@ClientesEstado, [ClientesNombre]=@ClientesNombre, [ClientesIdentidad]=@ClientesIdentidad, [ClientesTelefono]=@ClientesTelefono, [ClientesEmail]=@ClientesEmail, [ClientesDireccion]=@ClientesDireccion, [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId  WHERE [ClientesId] = @ClientesId", GxErrorMask.GX_NOMASK,prmT000I13)
           ,new CursorDef("T000I14", "UPDATE [Clientes] SET [ClientesImagen]=@ClientesImagen, [ClientesImagen_GXI]=@ClientesImagen_GXI  WHERE [ClientesId] = @ClientesId", GxErrorMask.GX_NOMASK,prmT000I14)
           ,new CursorDef("T000I15", "DELETE FROM [Clientes]  WHERE [ClientesId] = @ClientesId", GxErrorMask.GX_NOMASK,prmT000I15)
           ,new CursorDef("T000I16", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I17", "SELECT [ClientesId] FROM [Clientes] ORDER BY [ClientesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I18", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I18,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I19", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE ([DepartamentoId] = @DepartamentoId) AND ([DepartamentoMunicipioId] < 9999) ORDER BY [DepartamentoMunicipioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I19,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I20", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I20,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I21", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I21,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 2);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(5));
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
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
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

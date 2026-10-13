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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class proveedorgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public proveedorgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public proveedorgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID )
      {
         this.A133ProveedorID = aP0_ProveedorID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbProveedorEstado = new GXCombobox();
         chkProveedorFreezePrice = new GXCheckbox();
         dynProveedoresTipoId = new GXCombobox();
         chkProveedorUsoInterno = new GXCheckbox();
         chkProveedorCIU = new GXCheckbox();
         cmbProveedorPagoDefault = new GXCombobox();
         dynBancoId = new GXCombobox();
         dynProveedorUsrAlta = new GXCombobox();
         dynProveedorUsrActualizacion = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProveedorID");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A133ProveedorID});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"BANCOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLABANCOID4U2( ) ;
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
                  gxfirstwebparm = GetFirstPar( "ProveedorID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProveedorID");
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA4U2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProveedorGeneral";
               GXABANCOID_html4U2( ) ;
               WS4U2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Proveedor General", "")) ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "proveedorgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedorgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Width", StringUtil.RTrim( Dvpanel_unnamedtable3_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Cls", StringUtil.RTrim( Dvpanel_unnamedtable3_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Title", StringUtil.RTrim( Dvpanel_unnamedtable3_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable3_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoscroll));
      }

      protected void RenderHtmlCloseForm4U2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ProveedorGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Proveedor General", "") ;
      }

      protected void WB4U0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "proveedorgeneral.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbProveedorEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbProveedorEstado, cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado), 1, cmbProveedorEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 0, "HLP_ProveedorGeneral.htm");
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedproveedorfreezeprice_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockproveedorfreezeprice_Internalname, "", "", "", lblTextblockproveedorfreezeprice_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_26_4U2( true) ;
         }
         else
         {
            wb_table1_26_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_26_4U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynProveedoresTipoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynProveedoresTipoId_Internalname, context.GetMessage( "TipoId", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynProveedoresTipoId, dynProveedoresTipoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0)), 1, dynProveedoresTipoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProveedoresTipoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, 0, "HLP_ProveedorGeneral.htm");
            dynProveedoresTipoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0));
            AssignProp(sPrefix, false, dynProveedoresTipoId_Internalname, "Values", (string)(dynProveedoresTipoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorRazonSocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorRazonSocial_Internalname, context.GetMessage( "Razón Social", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorRazonSocial_Internalname, StringUtil.RTrim( A682ProveedorRazonSocial), StringUtil.RTrim( context.localUtil.Format( A682ProveedorRazonSocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorRazonSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorRazonSocial_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono), StringUtil.RTrim( context.localUtil.Format( A430ProveedorTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorEmail_Internalname, A433ProveedorEmail, StringUtil.RTrim( context.localUtil.Format( A433ProveedorEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A433ProveedorEmail, "", "", "", edtProveedorEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProveedorDireccion_Internalname, A431ProveedorDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A431ProveedorDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", 0, 1, edtProveedorDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedproveedorusointerno_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockproveedorusointerno_Internalname, "", "", "", lblTextblockproveedorusointerno_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table2_73_4U2( true) ;
         }
         else
         {
            wb_table2_73_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_73_4U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkProveedorCIU_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkProveedorCIU_Internalname, context.GetMessage( "¿Convenio CIU?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkProveedorCIU_Internalname, StringUtil.BoolToStr( A978ProveedorCIU), "", context.GetMessage( "¿Convenio CIU?", ""), 1, chkProveedorCIU.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProveedorImagen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
            GxWebStd.gx_bitmap( context, imgProveedorImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A432ProveedorImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorPagoDefault_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbProveedorPagoDefault_Internalname, context.GetMessage( "por Default", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbProveedorPagoDefault, cmbProveedorPagoDefault_Internalname, StringUtil.RTrim( A440ProveedorPagoDefault), 1, cmbProveedorPagoDefault_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorPagoDefault.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_ProveedorGeneral.htm");
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
            AssignProp(sPrefix, false, cmbProveedorPagoDefault_Internalname, "Values", (string)(cmbProveedorPagoDefault.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorDocIdentidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorDocIdentidad_Internalname, context.GetMessage( "Documento de Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorDocIdentidad_Internalname, StringUtil.RTrim( A338ProveedorDocIdentidad), StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorDocIdentidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorDocIdentidad_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorSitioWeb_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorSitioWeb_Internalname, context.GetMessage( "Web", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorSitioWeb_Internalname, StringUtil.RTrim( A685ProveedorSitioWeb), StringUtil.RTrim( context.localUtil.Format( A685ProveedorSitioWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorSitioWeb_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorSitioWeb_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorAceptoTerminos_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorAceptoTerminos_Internalname, context.GetMessage( "Aceptó Terminos y Condiciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtProveedorAceptoTerminos_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProveedorAceptoTerminos_Internalname, context.localUtil.TToC( A686ProveedorAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A686ProveedorAceptoTerminos, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,111);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorAceptoTerminos_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorAceptoTerminos_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProveedorAceptoTerminos_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProveedorAceptoTerminos_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProveedorGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable3.SetProperty("Width", Dvpanel_unnamedtable3_Width);
            ucDvpanel_unnamedtable3.SetProperty("AutoWidth", Dvpanel_unnamedtable3_Autowidth);
            ucDvpanel_unnamedtable3.SetProperty("AutoHeight", Dvpanel_unnamedtable3_Autoheight);
            ucDvpanel_unnamedtable3.SetProperty("Cls", Dvpanel_unnamedtable3_Cls);
            ucDvpanel_unnamedtable3.SetProperty("Title", Dvpanel_unnamedtable3_Title);
            ucDvpanel_unnamedtable3.SetProperty("Collapsible", Dvpanel_unnamedtable3_Collapsible);
            ucDvpanel_unnamedtable3.SetProperty("Collapsed", Dvpanel_unnamedtable3_Collapsed);
            ucDvpanel_unnamedtable3.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable3_Showcollapseicon);
            ucDvpanel_unnamedtable3.SetProperty("IconPosition", Dvpanel_unnamedtable3_Iconposition);
            ucDvpanel_unnamedtable3.SetProperty("AutoScroll", Dvpanel_unnamedtable3_Autoscroll);
            ucDvpanel_unnamedtable3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable3_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE3Container"+"UnnamedTable3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContacto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorContacto_Internalname, context.GetMessage( "Nombre del Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorContacto_Internalname, StringUtil.RTrim( A683ProveedorContacto), StringUtil.RTrim( context.localUtil.Format( A683ProveedorContacto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorContacto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContacto_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContactoCell_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorContactoCell_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A684ProveedorContactoCell);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorContactoCell_Internalname, StringUtil.RTrim( A684ProveedorContactoCell), StringUtil.RTrim( context.localUtil.Format( A684ProveedorContactoCell, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorContactoCell_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContactoCell_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProveedorGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynBancoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynBancoId_Internalname, context.GetMessage( "Banco", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynBancoId, dynBancoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0)), 1, dynBancoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynBancoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "", true, 0, "HLP_ProveedorGeneral.htm");
            dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
            AssignProp(sPrefix, false, dynBancoId_Internalname, "Values", (string)(dynBancoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorCuentaBancaria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorCuentaBancaria_Internalname, context.GetMessage( "Cuenta Bancaria", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorCuentaBancaria_Internalname, StringUtil.RTrim( A687ProveedorCuentaBancaria), StringUtil.RTrim( context.localUtil.Format( A687ProveedorCuentaBancaria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorCuentaBancaria_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorCuentaBancaria_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "CuentaBancari", "start", true, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Auditoría", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ProveedorGeneral.htm");
            wb_table3_139_4U2( true) ;
         }
         else
         {
            wb_table3_139_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_139_4U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtProveedorSerialComi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A345ProveedorSerialComi), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A345ProveedorSerialComi), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorSerialComi_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorSerialComi_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProveedorGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProveedorPerAltShop_Internalname, StringUtil.RTrim( A437ProveedorPerAltShop), StringUtil.RTrim( context.localUtil.Format( A437ProveedorPerAltShop, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorPerAltShop_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorPerAltShop_Visible, 0, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProveedorPideDoc_Internalname, StringUtil.RTrim( A490ProveedorPideDoc), StringUtil.RTrim( context.localUtil.Format( A490ProveedorPideDoc, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorPideDoc_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorPideDoc_Visible, 0, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDocumentacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentacionId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentacionId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProveedorGeneral.htm");
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
            GxWebStd.gx_bitmap( context, imgDocumentacionIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDocumentacionIcono_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A498DocumentacionIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4U2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Proveedor General", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP4U0( ) ;
            }
         }
      }

      protected void WS4U2( )
      {
         START4U2( ) ;
         EVT4U2( ) ;
      }

      protected void EVT4U2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E134U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E144U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE4U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4U2( ) ;
            }
         }
      }

      protected void PA4U2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "proveedorgeneral.aspx")), "proveedorgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "proveedorgeneral.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "ProveedorID");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLAPROVEEDORUSRACTUALIZACION4U1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORUSRACTUALIZACION_data4U1( ) ;
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

      protected void GXAPROVEEDORUSRACTUALIZACION_html4U1( )
      {
         long gxdynajaxvalue;
         GXDLAPROVEEDORUSRACTUALIZACION_data4U1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProveedorUsrActualizacion.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynProveedorUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynProveedorUsrActualizacion.ItemCount > 0 )
         {
            A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n547ProveedorUsrActualizacion = false;
            AssignAttri(sPrefix, false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
         }
      }

      protected void GXDLAPROVEEDORUSRACTUALIZACION_data4U1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004U2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004U2_A18SecUserId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(H004U2_A587SecUserFullName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLAPROVEEDORUSRALTA4U1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORUSRALTA_data4U1( ) ;
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

      protected void GXAPROVEEDORUSRALTA_html4U1( )
      {
         long gxdynajaxvalue;
         GXDLAPROVEEDORUSRALTA_data4U1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProveedorUsrAlta.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynProveedorUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynProveedorUsrAlta.ItemCount > 0 )
         {
            A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n546ProveedorUsrAlta = false;
            AssignAttri(sPrefix, false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
         }
      }

      protected void GXDLAPROVEEDORUSRALTA_data4U1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004U3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004U3_A18SecUserId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(H004U3_A587SecUserFullName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLAPROVEEDORESTIPOID4U1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORESTIPOID_data4U1( ) ;
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

      protected void GXAPROVEEDORESTIPOID_html4U1( )
      {
         long gxdynajaxvalue;
         GXDLAPROVEEDORESTIPOID_data4U1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProveedoresTipoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynProveedoresTipoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynProveedoresTipoId.ItemCount > 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         }
      }

      protected void GXDLAPROVEEDORESTIPOID_data4U1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004U4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004U4_A151ProveedoresTipoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H004U4_A278ProveedoresTipoNombre[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLABANCOID4U2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLABANCOID_data4U2( ) ;
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

      protected void GXABANCOID_html4U2( )
      {
         long gxdynajaxvalue;
         GXDLABANCOID_data4U2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynBancoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynBancoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLABANCOID_data4U2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H004U5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004U5_A673BancoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H004U5_A674BancoNombre[0]));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXABANCOID_html4U2( ) ;
            dynProveedorUsrActualizacion.Name = "PROVEEDORUSRACTUALIZACION";
            dynProveedorUsrActualizacion.WebTags = "";
            dynProveedorUsrActualizacion.removeAllItems();
            /* Using cursor H004U6 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               dynProveedorUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004U6_A18SecUserId[0]), 10, 0)), H004U6_A587SecUserFullName[0], 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( dynProveedorUsrActualizacion.ItemCount > 0 )
            {
               A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
               n547ProveedorUsrActualizacion = false;
               AssignAttri(sPrefix, false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            }
            dynProveedorUsrAlta.Name = "PROVEEDORUSRALTA";
            dynProveedorUsrAlta.WebTags = "";
            dynProveedorUsrAlta.removeAllItems();
            /* Using cursor H004U7 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               dynProveedorUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004U7_A18SecUserId[0]), 10, 0)), H004U7_A587SecUserFullName[0], 0);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( dynProveedorUsrAlta.ItemCount > 0 )
            {
               A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
               n546ProveedorUsrAlta = false;
               AssignAttri(sPrefix, false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
            }
            dynProveedoresTipoId.Name = "PROVEEDORESTIPOID";
            dynProveedoresTipoId.WebTags = "";
            dynProveedoresTipoId.removeAllItems();
            /* Using cursor H004U8 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               dynProveedoresTipoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004U8_A151ProveedoresTipoId[0]), 18, 0)), H004U8_A278ProveedoresTipoNombre[0], 0);
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( dynProveedoresTipoId.ItemCount > 0 )
            {
               A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri(sPrefix, false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
         }
         A999ProveedorFreezePrice = StringUtil.StrToBool( StringUtil.BoolToStr( A999ProveedorFreezePrice));
         n999ProveedorFreezePrice = false;
         AssignAttri(sPrefix, false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
         if ( dynProveedoresTipoId.ItemCount > 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedoresTipoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0));
            AssignProp(sPrefix, false, dynProveedoresTipoId_Internalname, "Values", dynProveedoresTipoId.ToJavascriptSource(), true);
         }
         A601ProveedorUsoInterno = ((StringUtil.StrCmp(StringUtil.RTrim( A601ProveedorUsoInterno), "S")==0) ? "S" : "N");
         n601ProveedorUsoInterno = false;
         AssignAttri(sPrefix, false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
         A978ProveedorCIU = StringUtil.StrToBool( StringUtil.BoolToStr( A978ProveedorCIU));
         AssignAttri(sPrefix, false, "A978ProveedorCIU", A978ProveedorCIU);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
            AssignAttri(sPrefix, false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
            AssignProp(sPrefix, false, cmbProveedorPagoDefault_Internalname, "Values", cmbProveedorPagoDefault.ToJavascriptSource(), true);
         }
         if ( dynBancoId.ItemCount > 0 )
         {
            A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
            AssignProp(sPrefix, false, dynBancoId_Internalname, "Values", dynBancoId.ToJavascriptSource(), true);
         }
         if ( dynProveedorUsrAlta.ItemCount > 0 )
         {
            A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n546ProveedorUsrAlta = false;
            AssignAttri(sPrefix, false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedorUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0));
            AssignProp(sPrefix, false, dynProveedorUsrAlta_Internalname, "Values", dynProveedorUsrAlta.ToJavascriptSource(), true);
         }
         if ( dynProveedorUsrActualizacion.ItemCount > 0 )
         {
            A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n547ProveedorUsrActualizacion = false;
            AssignAttri(sPrefix, false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedorUsrActualizacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            AssignProp(sPrefix, false, dynProveedorUsrActualizacion_Internalname, "Values", dynProveedorUsrActualizacion.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProveedorGeneral";
      }

      protected void RF4U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004U9 */
            pr_default.execute(7, new Object[] {A133ProveedorID});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A40001DocumentacionIcono_GXI = H004U9_A40001DocumentacionIcono_GXI[0];
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A488DocumentacionId = H004U9_A488DocumentacionId[0];
               n488DocumentacionId = H004U9_n488DocumentacionId[0];
               AssignAttri(sPrefix, false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               A490ProveedorPideDoc = H004U9_A490ProveedorPideDoc[0];
               n490ProveedorPideDoc = H004U9_n490ProveedorPideDoc[0];
               AssignAttri(sPrefix, false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
               A437ProveedorPerAltShop = H004U9_A437ProveedorPerAltShop[0];
               n437ProveedorPerAltShop = H004U9_n437ProveedorPerAltShop[0];
               AssignAttri(sPrefix, false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
               A345ProveedorSerialComi = H004U9_A345ProveedorSerialComi[0];
               AssignAttri(sPrefix, false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
               A549ProveedorFechaActualizacion = H004U9_A549ProveedorFechaActualizacion[0];
               n549ProveedorFechaActualizacion = H004U9_n549ProveedorFechaActualizacion[0];
               AssignAttri(sPrefix, false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A548ProveedorFechaAlta = H004U9_A548ProveedorFechaAlta[0];
               n548ProveedorFechaAlta = H004U9_n548ProveedorFechaAlta[0];
               AssignAttri(sPrefix, false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A547ProveedorUsrActualizacion = H004U9_A547ProveedorUsrActualizacion[0];
               n547ProveedorUsrActualizacion = H004U9_n547ProveedorUsrActualizacion[0];
               AssignAttri(sPrefix, false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
               A546ProveedorUsrAlta = H004U9_A546ProveedorUsrAlta[0];
               n546ProveedorUsrAlta = H004U9_n546ProveedorUsrAlta[0];
               AssignAttri(sPrefix, false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
               A687ProveedorCuentaBancaria = H004U9_A687ProveedorCuentaBancaria[0];
               n687ProveedorCuentaBancaria = H004U9_n687ProveedorCuentaBancaria[0];
               AssignAttri(sPrefix, false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
               A673BancoId = H004U9_A673BancoId[0];
               n673BancoId = H004U9_n673BancoId[0];
               AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               A684ProveedorContactoCell = H004U9_A684ProveedorContactoCell[0];
               n684ProveedorContactoCell = H004U9_n684ProveedorContactoCell[0];
               AssignAttri(sPrefix, false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
               A683ProveedorContacto = H004U9_A683ProveedorContacto[0];
               n683ProveedorContacto = H004U9_n683ProveedorContacto[0];
               AssignAttri(sPrefix, false, "A683ProveedorContacto", A683ProveedorContacto);
               A686ProveedorAceptoTerminos = H004U9_A686ProveedorAceptoTerminos[0];
               n686ProveedorAceptoTerminos = H004U9_n686ProveedorAceptoTerminos[0];
               AssignAttri(sPrefix, false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A685ProveedorSitioWeb = H004U9_A685ProveedorSitioWeb[0];
               n685ProveedorSitioWeb = H004U9_n685ProveedorSitioWeb[0];
               AssignAttri(sPrefix, false, "A685ProveedorSitioWeb", A685ProveedorSitioWeb);
               A338ProveedorDocIdentidad = H004U9_A338ProveedorDocIdentidad[0];
               AssignAttri(sPrefix, false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
               A440ProveedorPagoDefault = H004U9_A440ProveedorPagoDefault[0];
               AssignAttri(sPrefix, false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
               A40000ProveedorImagen_GXI = H004U9_A40000ProveedorImagen_GXI[0];
               n40000ProveedorImagen_GXI = H004U9_n40000ProveedorImagen_GXI[0];
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A978ProveedorCIU = H004U9_A978ProveedorCIU[0];
               AssignAttri(sPrefix, false, "A978ProveedorCIU", A978ProveedorCIU);
               A601ProveedorUsoInterno = H004U9_A601ProveedorUsoInterno[0];
               n601ProveedorUsoInterno = H004U9_n601ProveedorUsoInterno[0];
               AssignAttri(sPrefix, false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
               A431ProveedorDireccion = H004U9_A431ProveedorDireccion[0];
               n431ProveedorDireccion = H004U9_n431ProveedorDireccion[0];
               AssignAttri(sPrefix, false, "A431ProveedorDireccion", A431ProveedorDireccion);
               A433ProveedorEmail = H004U9_A433ProveedorEmail[0];
               n433ProveedorEmail = H004U9_n433ProveedorEmail[0];
               AssignAttri(sPrefix, false, "A433ProveedorEmail", A433ProveedorEmail);
               A430ProveedorTelefono = H004U9_A430ProveedorTelefono[0];
               n430ProveedorTelefono = H004U9_n430ProveedorTelefono[0];
               AssignAttri(sPrefix, false, "A430ProveedorTelefono", A430ProveedorTelefono);
               A682ProveedorRazonSocial = H004U9_A682ProveedorRazonSocial[0];
               n682ProveedorRazonSocial = H004U9_n682ProveedorRazonSocial[0];
               AssignAttri(sPrefix, false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
               A282ProveedorNombre = H004U9_A282ProveedorNombre[0];
               AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
               A151ProveedoresTipoId = H004U9_A151ProveedoresTipoId[0];
               AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
               A999ProveedorFreezePrice = H004U9_A999ProveedorFreezePrice[0];
               n999ProveedorFreezePrice = H004U9_n999ProveedorFreezePrice[0];
               AssignAttri(sPrefix, false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
               A344ProveedorEstado = H004U9_A344ProveedorEstado[0];
               AssignAttri(sPrefix, false, "A344ProveedorEstado", A344ProveedorEstado);
               A498DocumentacionIcono = H004U9_A498DocumentacionIcono[0];
               AssignAttri(sPrefix, false, "A498DocumentacionIcono", A498DocumentacionIcono);
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A432ProveedorImagen = H004U9_A432ProveedorImagen[0];
               n432ProveedorImagen = H004U9_n432ProveedorImagen[0];
               AssignAttri(sPrefix, false, "A432ProveedorImagen", A432ProveedorImagen);
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A40001DocumentacionIcono_GXI = H004U9_A40001DocumentacionIcono_GXI[0];
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A498DocumentacionIcono = H004U9_A498DocumentacionIcono[0];
               AssignAttri(sPrefix, false, "A498DocumentacionIcono", A498DocumentacionIcono);
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
               AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               GXABANCOID_html4U2( ) ;
               /* Execute user event: Load */
               E124U2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(7);
            WB4U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4U2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProveedorGeneral";
         GXABANCOID_html4U2( ) ;
         edtProveedorID_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         chkProveedorFreezePrice.Enabled = 0;
         AssignProp(sPrefix, false, chkProveedorFreezePrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorFreezePrice.Enabled), 5, 0), true);
         dynProveedoresTipoId.Enabled = 0;
         AssignProp(sPrefix, false, dynProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedoresTipoId.Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorRazonSocial_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorRazonSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorRazonSocial_Enabled), 5, 0), true);
         edtProveedorTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), true);
         edtProveedorEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), true);
         edtProveedorDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDireccion_Enabled), 5, 0), true);
         chkProveedorUsoInterno.Enabled = 0;
         AssignProp(sPrefix, false, chkProveedorUsoInterno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorUsoInterno.Enabled), 5, 0), true);
         chkProveedorCIU.Enabled = 0;
         AssignProp(sPrefix, false, chkProveedorCIU_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorCIU.Enabled), 5, 0), true);
         imgProveedorImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
         cmbProveedorPagoDefault.Enabled = 0;
         AssignProp(sPrefix, false, cmbProveedorPagoDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorPagoDefault.Enabled), 5, 0), true);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), true);
         edtProveedorSitioWeb_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorSitioWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSitioWeb_Enabled), 5, 0), true);
         edtProveedorAceptoTerminos_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorAceptoTerminos_Enabled), 5, 0), true);
         edtProveedorContacto_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorContacto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContacto_Enabled), 5, 0), true);
         edtProveedorContactoCell_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorContactoCell_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContactoCell_Enabled), 5, 0), true);
         dynBancoId.Enabled = 0;
         AssignProp(sPrefix, false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         edtProveedorCuentaBancaria_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorCuentaBancaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorCuentaBancaria_Enabled), 5, 0), true);
         dynProveedorUsrAlta.Enabled = 0;
         AssignProp(sPrefix, false, dynProveedorUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrAlta.Enabled), 5, 0), true);
         dynProveedorUsrActualizacion.Enabled = 0;
         AssignProp(sPrefix, false, dynProveedorUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrActualizacion.Enabled), 5, 0), true);
         edtProveedorFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaAlta_Enabled), 5, 0), true);
         edtProveedorFechaActualizacion_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaActualizacion_Enabled), 5, 0), true);
         edtProveedorSerialComi_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorSerialComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Enabled), 5, 0), true);
         edtProveedorPerAltShop_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorPerAltShop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorPerAltShop_Enabled), 5, 0), true);
         edtProveedorPideDoc_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorPideDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorPideDoc_Enabled), 5, 0), true);
         edtDocumentacionId_Enabled = 0;
         AssignProp(sPrefix, false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         imgDocumentacionIcono_Enabled = 0;
         AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114U2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvpanel_unnamedtable3_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Width");
            Dvpanel_unnamedtable3_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autowidth"));
            Dvpanel_unnamedtable3_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoheight"));
            Dvpanel_unnamedtable3_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Cls");
            Dvpanel_unnamedtable3_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Title");
            Dvpanel_unnamedtable3_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsible"));
            Dvpanel_unnamedtable3_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsed"));
            Dvpanel_unnamedtable3_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Showcollapseicon"));
            Dvpanel_unnamedtable3_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Iconposition");
            Dvpanel_unnamedtable3_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoscroll"));
            /* Read variables values. */
            cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
            A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
            AssignAttri(sPrefix, false, "A344ProveedorEstado", A344ProveedorEstado);
            A999ProveedorFreezePrice = StringUtil.StrToBool( cgiGet( chkProveedorFreezePrice_Internalname));
            n999ProveedorFreezePrice = false;
            AssignAttri(sPrefix, false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
            dynProveedoresTipoId.CurrentValue = cgiGet( dynProveedoresTipoId_Internalname);
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedoresTipoId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
            AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
            A682ProveedorRazonSocial = cgiGet( edtProveedorRazonSocial_Internalname);
            n682ProveedorRazonSocial = false;
            AssignAttri(sPrefix, false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
            A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
            n430ProveedorTelefono = false;
            AssignAttri(sPrefix, false, "A430ProveedorTelefono", A430ProveedorTelefono);
            A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
            n433ProveedorEmail = false;
            AssignAttri(sPrefix, false, "A433ProveedorEmail", A433ProveedorEmail);
            A431ProveedorDireccion = cgiGet( edtProveedorDireccion_Internalname);
            n431ProveedorDireccion = false;
            AssignAttri(sPrefix, false, "A431ProveedorDireccion", A431ProveedorDireccion);
            A601ProveedorUsoInterno = ((StringUtil.StrCmp(cgiGet( chkProveedorUsoInterno_Internalname), "S")==0) ? "S" : "N");
            n601ProveedorUsoInterno = false;
            AssignAttri(sPrefix, false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
            A978ProveedorCIU = StringUtil.StrToBool( cgiGet( chkProveedorCIU_Internalname));
            AssignAttri(sPrefix, false, "A978ProveedorCIU", A978ProveedorCIU);
            A432ProveedorImagen = cgiGet( imgProveedorImagen_Internalname);
            n432ProveedorImagen = false;
            AssignAttri(sPrefix, false, "A432ProveedorImagen", A432ProveedorImagen);
            cmbProveedorPagoDefault.CurrentValue = cgiGet( cmbProveedorPagoDefault_Internalname);
            A440ProveedorPagoDefault = cgiGet( cmbProveedorPagoDefault_Internalname);
            AssignAttri(sPrefix, false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
            AssignAttri(sPrefix, false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
            A685ProveedorSitioWeb = cgiGet( edtProveedorSitioWeb_Internalname);
            n685ProveedorSitioWeb = false;
            AssignAttri(sPrefix, false, "A685ProveedorSitioWeb", A685ProveedorSitioWeb);
            A686ProveedorAceptoTerminos = context.localUtil.CToT( cgiGet( edtProveedorAceptoTerminos_Internalname));
            n686ProveedorAceptoTerminos = false;
            AssignAttri(sPrefix, false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A683ProveedorContacto = cgiGet( edtProveedorContacto_Internalname);
            n683ProveedorContacto = false;
            AssignAttri(sPrefix, false, "A683ProveedorContacto", A683ProveedorContacto);
            A684ProveedorContactoCell = cgiGet( edtProveedorContactoCell_Internalname);
            n684ProveedorContactoCell = false;
            AssignAttri(sPrefix, false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
            dynBancoId.CurrentValue = cgiGet( dynBancoId_Internalname);
            A673BancoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynBancoId_Internalname), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A687ProveedorCuentaBancaria = cgiGet( edtProveedorCuentaBancaria_Internalname);
            n687ProveedorCuentaBancaria = false;
            AssignAttri(sPrefix, false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
            dynProveedorUsrAlta.CurrentValue = cgiGet( dynProveedorUsrAlta_Internalname);
            A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorUsrAlta_Internalname), "."), 18, MidpointRounding.ToEven));
            n546ProveedorUsrAlta = false;
            AssignAttri(sPrefix, false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
            dynProveedorUsrActualizacion.CurrentValue = cgiGet( dynProveedorUsrActualizacion_Internalname);
            A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorUsrActualizacion_Internalname), "."), 18, MidpointRounding.ToEven));
            n547ProveedorUsrActualizacion = false;
            AssignAttri(sPrefix, false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            A548ProveedorFechaAlta = context.localUtil.CToT( cgiGet( edtProveedorFechaAlta_Internalname));
            n548ProveedorFechaAlta = false;
            AssignAttri(sPrefix, false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A549ProveedorFechaActualizacion = context.localUtil.CToT( cgiGet( edtProveedorFechaActualizacion_Internalname));
            n549ProveedorFechaActualizacion = false;
            AssignAttri(sPrefix, false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A345ProveedorSerialComi = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorSerialComi_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            A437ProveedorPerAltShop = cgiGet( edtProveedorPerAltShop_Internalname);
            n437ProveedorPerAltShop = false;
            AssignAttri(sPrefix, false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
            A490ProveedorPideDoc = cgiGet( edtProveedorPideDoc_Internalname);
            n490ProveedorPideDoc = false;
            AssignAttri(sPrefix, false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
            A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n488DocumentacionId = false;
            AssignAttri(sPrefix, false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            A498DocumentacionIcono = cgiGet( imgDocumentacionIcono_Internalname);
            AssignAttri(sPrefix, false, "A498DocumentacionIcono", A498DocumentacionIcono);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXABANCOID_html4U2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E114U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E124U2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtProveedorSerialComi_Visible = 0;
         AssignProp(sPrefix, false, edtProveedorSerialComi_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Visible), 5, 0), true);
         edtProveedorPerAltShop_Visible = 0;
         AssignProp(sPrefix, false, edtProveedorPerAltShop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorPerAltShop_Visible), 5, 0), true);
         edtProveedorPideDoc_Visible = 0;
         AssignProp(sPrefix, false, edtProveedorPideDoc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorPideDoc_Visible), 5, 0), true);
         edtDocumentacionId_Visible = 0;
         AssignProp(sPrefix, false, edtDocumentacionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Visible), 5, 0), true);
         imgDocumentacionIcono_Visible = 0;
         AssignProp(sPrefix, false, imgDocumentacionIcono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E134U2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E144U2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Proveedor";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_139_4U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynProveedorUsrAlta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynProveedorUsrAlta_Internalname, context.GetMessage( "Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynProveedorUsrAlta, dynProveedorUsrAlta_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0)), 1, dynProveedorUsrAlta_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProveedorUsrAlta.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "", true, 0, "HLP_ProveedorGeneral.htm");
            dynProveedorUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0));
            AssignProp(sPrefix, false, dynProveedorUsrAlta_Internalname, "Values", (string)(dynProveedorUsrAlta.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynProveedorUsrActualizacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynProveedorUsrActualizacion_Internalname, context.GetMessage( "Actualizacion", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynProveedorUsrActualizacion, dynProveedorUsrActualizacion_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0)), 1, dynProveedorUsrActualizacion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProveedorUsrActualizacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "", true, 0, "HLP_ProveedorGeneral.htm");
            dynProveedorUsrActualizacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            AssignProp(sPrefix, false, dynProveedorUsrActualizacion_Internalname, "Values", (string)(dynProveedorUsrActualizacion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorFechaAlta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorFechaAlta_Internalname, context.GetMessage( "Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtProveedorFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProveedorFechaAlta_Internalname, context.localUtil.TToC( A548ProveedorFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A548ProveedorFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,153);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProveedorFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProveedorFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProveedorGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorFechaActualizacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorFechaActualizacion_Internalname, context.GetMessage( "Actualizacion", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtProveedorFechaActualizacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProveedorFechaActualizacion_Internalname, context.localUtil.TToC( A549ProveedorFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A549ProveedorFechaActualizacion, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,157);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorFechaActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorFechaActualizacion_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProveedorGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProveedorFechaActualizacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProveedorFechaActualizacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProveedorGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_139_4U2e( true) ;
         }
         else
         {
            wb_table3_139_4U2e( false) ;
         }
      }

      protected void wb_table2_73_4U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedproveedorusointerno_Internalname, tblTablemergedproveedorusointerno_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkProveedorUsoInterno_Internalname, context.GetMessage( "¿Es de Uso Interno?", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkProveedorUsoInterno_Internalname, A601ProveedorUsoInterno, "", context.GetMessage( "¿Es de Uso Interno?", ""), 1, chkProveedorUsoInterno.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(77, this, 'S', 'N',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,77);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProveedorusointerno_righttext_Internalname, context.GetMessage( "¿Es de uso Inter?", ""), "", "", lblProveedorusointerno_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_ProveedorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_73_4U2e( true) ;
         }
         else
         {
            wb_table2_73_4U2e( false) ;
         }
      }

      protected void wb_table1_26_4U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedproveedorfreezeprice_Internalname, tblTablemergedproveedorfreezeprice_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkProveedorFreezePrice_Internalname, context.GetMessage( "Freezar Precio", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkProveedorFreezePrice_Internalname, StringUtil.BoolToStr( A999ProveedorFreezePrice), "", context.GetMessage( "Freezar Precio", ""), 1, chkProveedorFreezePrice.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(30, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,30);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProveedorfreezeprice_righttext_Internalname, context.GetMessage( "Freezar Precios", ""), "", "", lblProveedorfreezeprice_righttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_ProveedorGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_26_4U2e( true) ;
         }
         else
         {
            wb_table1_26_4U2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A133ProveedorID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA4U2( ) ;
         WS4U2( ) ;
         WE4U2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA133ProveedorID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4U2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "proveedorgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4U2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A133ProveedorID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         wcpOA133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A133ProveedorID != wcpOA133ProveedorID ) ) )
         {
            setjustcreated();
         }
         wcpOA133ProveedorID = A133ProveedorID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA133ProveedorID = cgiGet( sPrefix+"A133ProveedorID_CTRL");
         if ( StringUtil.Len( sCtrlA133ProveedorID) > 0 )
         {
            A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA133ProveedorID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         else
         {
            A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A133ProveedorID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA4U2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS4U2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A133ProveedorID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA133ProveedorID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A133ProveedorID_CTRL", StringUtil.RTrim( sCtrlA133ProveedorID));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE4U2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319595185", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("proveedorgeneral.js", "?20269319595185", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
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
         }
         chkProveedorFreezePrice.Name = "PROVEEDORFREEZEPRICE";
         chkProveedorFreezePrice.WebTags = "";
         chkProveedorFreezePrice.Caption = context.GetMessage( "Freezar Precio", "");
         AssignProp(sPrefix, false, chkProveedorFreezePrice_Internalname, "TitleCaption", chkProveedorFreezePrice.Caption, true);
         chkProveedorFreezePrice.CheckedValue = "false";
         dynProveedoresTipoId.Name = "PROVEEDORESTIPOID";
         dynProveedoresTipoId.WebTags = "";
         dynProveedoresTipoId.removeAllItems();
         /* Using cursor H004U10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynProveedoresTipoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004U10_A151ProveedoresTipoId[0]), 18, 0)), H004U10_A278ProveedoresTipoNombre[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynProveedoresTipoId.ItemCount > 0 )
         {
         }
         chkProveedorUsoInterno.Name = "PROVEEDORUSOINTERNO";
         chkProveedorUsoInterno.WebTags = "";
         chkProveedorUsoInterno.Caption = context.GetMessage( "¿Es de Uso Interno?", "");
         AssignProp(sPrefix, false, chkProveedorUsoInterno_Internalname, "TitleCaption", chkProveedorUsoInterno.Caption, true);
         chkProveedorUsoInterno.CheckedValue = "N";
         chkProveedorCIU.Name = "PROVEEDORCIU";
         chkProveedorCIU.WebTags = "";
         chkProveedorCIU.Caption = context.GetMessage( "¿Convenio CIU?", "");
         AssignProp(sPrefix, false, chkProveedorCIU_Internalname, "TitleCaption", chkProveedorCIU.Caption, true);
         chkProveedorCIU.CheckedValue = "false";
         cmbProveedorPagoDefault.Name = "PROVEEDORPAGODEFAULT";
         cmbProveedorPagoDefault.WebTags = "";
         cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
         }
         dynBancoId.Name = "BANCOID";
         dynBancoId.WebTags = "";
         dynProveedorUsrAlta.Name = "PROVEEDORUSRALTA";
         dynProveedorUsrAlta.WebTags = "";
         dynProveedorUsrAlta.removeAllItems();
         /* Using cursor H004U11 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            dynProveedorUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004U11_A18SecUserId[0]), 10, 0)), H004U11_A587SecUserFullName[0], 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         if ( dynProveedorUsrAlta.ItemCount > 0 )
         {
         }
         dynProveedorUsrActualizacion.Name = "PROVEEDORUSRACTUALIZACION";
         dynProveedorUsrActualizacion.WebTags = "";
         dynProveedorUsrActualizacion.removeAllItems();
         /* Using cursor H004U12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            dynProveedorUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004U12_A18SecUserId[0]), 10, 0)), H004U12_A587SecUserFullName[0], 0);
            pr_default.readNext(10);
         }
         pr_default.close(10);
         if ( dynProveedorUsrActualizacion.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID";
         cmbProveedorEstado_Internalname = sPrefix+"PROVEEDORESTADO";
         lblTextblockproveedorfreezeprice_Internalname = sPrefix+"TEXTBLOCKPROVEEDORFREEZEPRICE";
         chkProveedorFreezePrice_Internalname = sPrefix+"PROVEEDORFREEZEPRICE";
         lblProveedorfreezeprice_righttext_Internalname = sPrefix+"PROVEEDORFREEZEPRICE_RIGHTTEXT";
         tblTablemergedproveedorfreezeprice_Internalname = sPrefix+"TABLEMERGEDPROVEEDORFREEZEPRICE";
         divTablesplittedproveedorfreezeprice_Internalname = sPrefix+"TABLESPLITTEDPROVEEDORFREEZEPRICE";
         dynProveedoresTipoId_Internalname = sPrefix+"PROVEEDORESTIPOID";
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE";
         edtProveedorRazonSocial_Internalname = sPrefix+"PROVEEDORRAZONSOCIAL";
         edtProveedorTelefono_Internalname = sPrefix+"PROVEEDORTELEFONO";
         edtProveedorEmail_Internalname = sPrefix+"PROVEEDOREMAIL";
         edtProveedorDireccion_Internalname = sPrefix+"PROVEEDORDIRECCION";
         lblTextblockproveedorusointerno_Internalname = sPrefix+"TEXTBLOCKPROVEEDORUSOINTERNO";
         chkProveedorUsoInterno_Internalname = sPrefix+"PROVEEDORUSOINTERNO";
         lblProveedorusointerno_righttext_Internalname = sPrefix+"PROVEEDORUSOINTERNO_RIGHTTEXT";
         tblTablemergedproveedorusointerno_Internalname = sPrefix+"TABLEMERGEDPROVEEDORUSOINTERNO";
         divTablesplittedproveedorusointerno_Internalname = sPrefix+"TABLESPLITTEDPROVEEDORUSOINTERNO";
         chkProveedorCIU_Internalname = sPrefix+"PROVEEDORCIU";
         divTransactiondetail_tb1_Internalname = sPrefix+"TRANSACTIONDETAIL_TB1";
         imgProveedorImagen_Internalname = sPrefix+"PROVEEDORIMAGEN";
         cmbProveedorPagoDefault_Internalname = sPrefix+"PROVEEDORPAGODEFAULT";
         edtProveedorDocIdentidad_Internalname = sPrefix+"PROVEEDORDOCIDENTIDAD";
         edtProveedorSitioWeb_Internalname = sPrefix+"PROVEEDORSITIOWEB";
         edtProveedorAceptoTerminos_Internalname = sPrefix+"PROVEEDORACEPTOTERMINOS";
         edtProveedorContacto_Internalname = sPrefix+"PROVEEDORCONTACTO";
         edtProveedorContactoCell_Internalname = sPrefix+"PROVEEDORCONTACTOCELL";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         Dvpanel_unnamedtable3_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE3";
         divTransactiondetail_tb2_Internalname = sPrefix+"TRANSACTIONDETAIL_TB2";
         dynBancoId_Internalname = sPrefix+"BANCOID";
         edtProveedorCuentaBancaria_Internalname = sPrefix+"PROVEEDORCUENTABANCARIA";
         dynProveedorUsrAlta_Internalname = sPrefix+"PROVEEDORUSRALTA";
         dynProveedorUsrActualizacion_Internalname = sPrefix+"PROVEEDORUSRACTUALIZACION";
         edtProveedorFechaAlta_Internalname = sPrefix+"PROVEEDORFECHAALTA";
         edtProveedorFechaActualizacion_Internalname = sPrefix+"PROVEEDORFECHAACTUALIZACION";
         tblUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtProveedorSerialComi_Internalname = sPrefix+"PROVEEDORSERIALCOMI";
         edtProveedorPerAltShop_Internalname = sPrefix+"PROVEEDORPERALTSHOP";
         edtProveedorPideDoc_Internalname = sPrefix+"PROVEEDORPIDEDOC";
         edtDocumentacionId_Internalname = sPrefix+"DOCUMENTACIONID";
         imgDocumentacionIcono_Internalname = sPrefix+"DOCUMENTACIONICONO";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkProveedorCIU.Caption = context.GetMessage( "¿Convenio CIU?", "");
         chkProveedorUsoInterno.Caption = context.GetMessage( "¿Es de Uso Interno?", "");
         chkProveedorFreezePrice.Caption = context.GetMessage( "Freezar Precio", "");
         edtProveedorFechaActualizacion_Jsonclick = "";
         edtProveedorFechaAlta_Jsonclick = "";
         dynProveedorUsrActualizacion_Jsonclick = "";
         dynProveedorUsrAlta_Jsonclick = "";
         imgDocumentacionIcono_Enabled = 0;
         edtDocumentacionId_Enabled = 0;
         edtProveedorPideDoc_Enabled = 0;
         edtProveedorPerAltShop_Enabled = 0;
         edtProveedorSerialComi_Enabled = 0;
         edtProveedorFechaActualizacion_Enabled = 0;
         edtProveedorFechaAlta_Enabled = 0;
         dynProveedorUsrActualizacion.Enabled = 0;
         dynProveedorUsrAlta.Enabled = 0;
         imgProveedorImagen_Enabled = 0;
         chkProveedorUsoInterno.Enabled = 0;
         chkProveedorFreezePrice.Enabled = 0;
         imgDocumentacionIcono_Visible = 1;
         edtDocumentacionId_Jsonclick = "";
         edtDocumentacionId_Visible = 1;
         edtProveedorPideDoc_Jsonclick = "";
         edtProveedorPideDoc_Visible = 1;
         edtProveedorPerAltShop_Jsonclick = "";
         edtProveedorPerAltShop_Visible = 1;
         edtProveedorSerialComi_Jsonclick = "";
         edtProveedorSerialComi_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtProveedorCuentaBancaria_Jsonclick = "";
         edtProveedorCuentaBancaria_Enabled = 0;
         dynBancoId_Jsonclick = "";
         dynBancoId.Enabled = 0;
         edtProveedorContactoCell_Jsonclick = "";
         edtProveedorContactoCell_Enabled = 0;
         edtProveedorContacto_Jsonclick = "";
         edtProveedorContacto_Enabled = 0;
         edtProveedorAceptoTerminos_Jsonclick = "";
         edtProveedorAceptoTerminos_Enabled = 0;
         edtProveedorSitioWeb_Jsonclick = "";
         edtProveedorSitioWeb_Enabled = 0;
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedorDocIdentidad_Enabled = 0;
         cmbProveedorPagoDefault_Jsonclick = "";
         cmbProveedorPagoDefault.Enabled = 0;
         chkProveedorCIU.Enabled = 0;
         edtProveedorDireccion_Enabled = 0;
         edtProveedorEmail_Jsonclick = "";
         edtProveedorEmail_Enabled = 0;
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorTelefono_Enabled = 0;
         edtProveedorRazonSocial_Jsonclick = "";
         edtProveedorRazonSocial_Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         dynProveedoresTipoId_Jsonclick = "";
         dynProveedoresTipoId.Enabled = 0;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado.Enabled = 0;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
         Dvpanel_unnamedtable3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Iconposition = "Right";
         Dvpanel_unnamedtable3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Title = context.GetMessage( "CONTACTO", "");
         Dvpanel_unnamedtable3_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_unnamedtable3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Width = "100%";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E134U2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E144U2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTACIONID","{handler:'Valid_Documentacionid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTACIONID",",oparms:[]}");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A344ProveedorEstado = "";
         lblTextblockproveedorfreezeprice_Jsonclick = "";
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         gxphoneLink = "";
         A430ProveedorTelefono = "";
         A433ProveedorEmail = "";
         ClassString = "";
         StyleString = "";
         A431ProveedorDireccion = "";
         lblTextblockproveedorusointerno_Jsonclick = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         sImgUrl = "";
         A440ProveedorPagoDefault = "";
         A338ProveedorDocIdentidad = "";
         A685ProveedorSitioWeb = "";
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         ucDvpanel_unnamedtable3 = new GXUserControl();
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A687ProveedorCuentaBancaria = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A437ProveedorPerAltShop = "";
         A490ProveedorPideDoc = "";
         A498DocumentacionIcono = "";
         A40001DocumentacionIcono_GXI = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H004U2_A18SecUserId = new long[1] ;
         H004U2_A587SecUserFullName = new string[] {""} ;
         H004U3_A18SecUserId = new long[1] ;
         H004U3_A587SecUserFullName = new string[] {""} ;
         H004U4_A151ProveedoresTipoId = new long[1] ;
         H004U4_A278ProveedoresTipoNombre = new string[] {""} ;
         H004U5_A673BancoId = new long[1] ;
         H004U5_n673BancoId = new bool[] {false} ;
         H004U5_A674BancoNombre = new string[] {""} ;
         H004U5_A675BancoEstado = new string[] {""} ;
         H004U6_A18SecUserId = new long[1] ;
         H004U6_A587SecUserFullName = new string[] {""} ;
         H004U7_A18SecUserId = new long[1] ;
         H004U7_A587SecUserFullName = new string[] {""} ;
         H004U8_A151ProveedoresTipoId = new long[1] ;
         H004U8_A278ProveedoresTipoNombre = new string[] {""} ;
         A601ProveedorUsoInterno = "";
         H004U9_A133ProveedorID = new long[1] ;
         H004U9_A40001DocumentacionIcono_GXI = new string[] {""} ;
         H004U9_A488DocumentacionId = new long[1] ;
         H004U9_n488DocumentacionId = new bool[] {false} ;
         H004U9_A490ProveedorPideDoc = new string[] {""} ;
         H004U9_n490ProveedorPideDoc = new bool[] {false} ;
         H004U9_A437ProveedorPerAltShop = new string[] {""} ;
         H004U9_n437ProveedorPerAltShop = new bool[] {false} ;
         H004U9_A345ProveedorSerialComi = new short[1] ;
         H004U9_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H004U9_n549ProveedorFechaActualizacion = new bool[] {false} ;
         H004U9_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H004U9_n548ProveedorFechaAlta = new bool[] {false} ;
         H004U9_A547ProveedorUsrActualizacion = new long[1] ;
         H004U9_n547ProveedorUsrActualizacion = new bool[] {false} ;
         H004U9_A546ProveedorUsrAlta = new long[1] ;
         H004U9_n546ProveedorUsrAlta = new bool[] {false} ;
         H004U9_A687ProveedorCuentaBancaria = new string[] {""} ;
         H004U9_n687ProveedorCuentaBancaria = new bool[] {false} ;
         H004U9_A673BancoId = new long[1] ;
         H004U9_n673BancoId = new bool[] {false} ;
         H004U9_A684ProveedorContactoCell = new string[] {""} ;
         H004U9_n684ProveedorContactoCell = new bool[] {false} ;
         H004U9_A683ProveedorContacto = new string[] {""} ;
         H004U9_n683ProveedorContacto = new bool[] {false} ;
         H004U9_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         H004U9_n686ProveedorAceptoTerminos = new bool[] {false} ;
         H004U9_A685ProveedorSitioWeb = new string[] {""} ;
         H004U9_n685ProveedorSitioWeb = new bool[] {false} ;
         H004U9_A338ProveedorDocIdentidad = new string[] {""} ;
         H004U9_A440ProveedorPagoDefault = new string[] {""} ;
         H004U9_A40000ProveedorImagen_GXI = new string[] {""} ;
         H004U9_n40000ProveedorImagen_GXI = new bool[] {false} ;
         H004U9_A978ProveedorCIU = new bool[] {false} ;
         H004U9_A601ProveedorUsoInterno = new string[] {""} ;
         H004U9_n601ProveedorUsoInterno = new bool[] {false} ;
         H004U9_A431ProveedorDireccion = new string[] {""} ;
         H004U9_n431ProveedorDireccion = new bool[] {false} ;
         H004U9_A433ProveedorEmail = new string[] {""} ;
         H004U9_n433ProveedorEmail = new bool[] {false} ;
         H004U9_A430ProveedorTelefono = new string[] {""} ;
         H004U9_n430ProveedorTelefono = new bool[] {false} ;
         H004U9_A682ProveedorRazonSocial = new string[] {""} ;
         H004U9_n682ProveedorRazonSocial = new bool[] {false} ;
         H004U9_A282ProveedorNombre = new string[] {""} ;
         H004U9_A151ProveedoresTipoId = new long[1] ;
         H004U9_A999ProveedorFreezePrice = new bool[] {false} ;
         H004U9_n999ProveedorFreezePrice = new bool[] {false} ;
         H004U9_A344ProveedorEstado = new string[] {""} ;
         H004U9_A498DocumentacionIcono = new string[] {""} ;
         H004U9_A432ProveedorImagen = new string[] {""} ;
         H004U9_n432ProveedorImagen = new bool[] {false} ;
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         sStyleString = "";
         lblProveedorusointerno_righttext_Jsonclick = "";
         lblProveedorfreezeprice_righttext_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA133ProveedorID = "";
         H004U10_A151ProveedoresTipoId = new long[1] ;
         H004U10_A278ProveedoresTipoNombre = new string[] {""} ;
         H004U11_A18SecUserId = new long[1] ;
         H004U11_A587SecUserFullName = new string[] {""} ;
         H004U12_A18SecUserId = new long[1] ;
         H004U12_A587SecUserFullName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorgeneral__default(),
            new Object[][] {
                new Object[] {
               H004U2_A18SecUserId, H004U2_A587SecUserFullName
               }
               , new Object[] {
               H004U3_A18SecUserId, H004U3_A587SecUserFullName
               }
               , new Object[] {
               H004U4_A151ProveedoresTipoId, H004U4_A278ProveedoresTipoNombre
               }
               , new Object[] {
               H004U5_A673BancoId, H004U5_A674BancoNombre, H004U5_A675BancoEstado
               }
               , new Object[] {
               H004U6_A18SecUserId, H004U6_A587SecUserFullName
               }
               , new Object[] {
               H004U7_A18SecUserId, H004U7_A587SecUserFullName
               }
               , new Object[] {
               H004U8_A151ProveedoresTipoId, H004U8_A278ProveedoresTipoNombre
               }
               , new Object[] {
               H004U9_A133ProveedorID, H004U9_A40001DocumentacionIcono_GXI, H004U9_A488DocumentacionId, H004U9_n488DocumentacionId, H004U9_A490ProveedorPideDoc, H004U9_n490ProveedorPideDoc, H004U9_A437ProveedorPerAltShop, H004U9_n437ProveedorPerAltShop, H004U9_A345ProveedorSerialComi, H004U9_A549ProveedorFechaActualizacion,
               H004U9_n549ProveedorFechaActualizacion, H004U9_A548ProveedorFechaAlta, H004U9_n548ProveedorFechaAlta, H004U9_A547ProveedorUsrActualizacion, H004U9_n547ProveedorUsrActualizacion, H004U9_A546ProveedorUsrAlta, H004U9_n546ProveedorUsrAlta, H004U9_A687ProveedorCuentaBancaria, H004U9_n687ProveedorCuentaBancaria, H004U9_A673BancoId,
               H004U9_n673BancoId, H004U9_A684ProveedorContactoCell, H004U9_n684ProveedorContactoCell, H004U9_A683ProveedorContacto, H004U9_n683ProveedorContacto, H004U9_A686ProveedorAceptoTerminos, H004U9_n686ProveedorAceptoTerminos, H004U9_A685ProveedorSitioWeb, H004U9_n685ProveedorSitioWeb, H004U9_A338ProveedorDocIdentidad,
               H004U9_A440ProveedorPagoDefault, H004U9_A40000ProveedorImagen_GXI, H004U9_n40000ProveedorImagen_GXI, H004U9_A978ProveedorCIU, H004U9_A601ProveedorUsoInterno, H004U9_n601ProveedorUsoInterno, H004U9_A431ProveedorDireccion, H004U9_n431ProveedorDireccion, H004U9_A433ProveedorEmail, H004U9_n433ProveedorEmail,
               H004U9_A430ProveedorTelefono, H004U9_n430ProveedorTelefono, H004U9_A682ProveedorRazonSocial, H004U9_n682ProveedorRazonSocial, H004U9_A282ProveedorNombre, H004U9_A151ProveedoresTipoId, H004U9_A999ProveedorFreezePrice, H004U9_n999ProveedorFreezePrice, H004U9_A344ProveedorEstado, H004U9_A498DocumentacionIcono,
               H004U9_A432ProveedorImagen, H004U9_n432ProveedorImagen
               }
               , new Object[] {
               H004U10_A151ProveedoresTipoId, H004U10_A278ProveedoresTipoNombre
               }
               , new Object[] {
               H004U11_A18SecUserId, H004U11_A587SecUserFullName
               }
               , new Object[] {
               H004U12_A18SecUserId, H004U12_A587SecUserFullName
               }
            }
         );
         AV13Pgmname = "ProveedorGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ProveedorGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A345ProveedorSerialComi ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorRazonSocial_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int edtProveedorDireccion_Enabled ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int edtProveedorSitioWeb_Enabled ;
      private int edtProveedorAceptoTerminos_Enabled ;
      private int edtProveedorContacto_Enabled ;
      private int edtProveedorContactoCell_Enabled ;
      private int edtProveedorCuentaBancaria_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtProveedorSerialComi_Visible ;
      private int edtProveedorPerAltShop_Visible ;
      private int edtProveedorPideDoc_Visible ;
      private int edtDocumentacionId_Visible ;
      private int imgDocumentacionIcono_Visible ;
      private int gxdynajaxindex ;
      private int imgProveedorImagen_Enabled ;
      private int edtProveedorFechaAlta_Enabled ;
      private int edtProveedorFechaActualizacion_Enabled ;
      private int edtProveedorSerialComi_Enabled ;
      private int edtProveedorPerAltShop_Enabled ;
      private int edtProveedorPideDoc_Enabled ;
      private int edtDocumentacionId_Enabled ;
      private int imgDocumentacionIcono_Enabled ;
      private int idxLst ;
      private long A133ProveedorID ;
      private long wcpOA133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long A673BancoId ;
      private long A488DocumentacionId ;
      private long A547ProveedorUsrActualizacion ;
      private long A546ProveedorUsrAlta ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_unnamedtable3_Width ;
      private string Dvpanel_unnamedtable3_Cls ;
      private string Dvpanel_unnamedtable3_Title ;
      private string Dvpanel_unnamedtable3_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtProveedorID_Internalname ;
      private string TempTags ;
      private string edtProveedorID_Jsonclick ;
      private string cmbProveedorEstado_Internalname ;
      private string A344ProveedorEstado ;
      private string cmbProveedorEstado_Jsonclick ;
      private string divTablesplittedproveedorfreezeprice_Internalname ;
      private string lblTextblockproveedorfreezeprice_Internalname ;
      private string lblTextblockproveedorfreezeprice_Jsonclick ;
      private string divTransactiondetail_tb1_Internalname ;
      private string dynProveedoresTipoId_Internalname ;
      private string dynProveedoresTipoId_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorRazonSocial_Internalname ;
      private string A682ProveedorRazonSocial ;
      private string edtProveedorRazonSocial_Jsonclick ;
      private string edtProveedorTelefono_Internalname ;
      private string gxphoneLink ;
      private string A430ProveedorTelefono ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorEmail_Internalname ;
      private string edtProveedorEmail_Jsonclick ;
      private string edtProveedorDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablesplittedproveedorusointerno_Internalname ;
      private string lblTextblockproveedorusointerno_Internalname ;
      private string lblTextblockproveedorusointerno_Jsonclick ;
      private string chkProveedorCIU_Internalname ;
      private string divTransactiondetail_tb2_Internalname ;
      private string imgProveedorImagen_Internalname ;
      private string sImgUrl ;
      private string cmbProveedorPagoDefault_Internalname ;
      private string A440ProveedorPagoDefault ;
      private string cmbProveedorPagoDefault_Jsonclick ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string A338ProveedorDocIdentidad ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string edtProveedorSitioWeb_Internalname ;
      private string A685ProveedorSitioWeb ;
      private string edtProveedorSitioWeb_Jsonclick ;
      private string edtProveedorAceptoTerminos_Internalname ;
      private string edtProveedorAceptoTerminos_Jsonclick ;
      private string Dvpanel_unnamedtable3_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtProveedorContacto_Internalname ;
      private string A683ProveedorContacto ;
      private string edtProveedorContacto_Jsonclick ;
      private string edtProveedorContactoCell_Internalname ;
      private string A684ProveedorContactoCell ;
      private string edtProveedorContactoCell_Jsonclick ;
      private string dynBancoId_Internalname ;
      private string dynBancoId_Jsonclick ;
      private string edtProveedorCuentaBancaria_Internalname ;
      private string A687ProveedorCuentaBancaria ;
      private string edtProveedorCuentaBancaria_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtProveedorSerialComi_Internalname ;
      private string edtProveedorSerialComi_Jsonclick ;
      private string edtProveedorPerAltShop_Internalname ;
      private string A437ProveedorPerAltShop ;
      private string edtProveedorPerAltShop_Jsonclick ;
      private string edtProveedorPideDoc_Internalname ;
      private string A490ProveedorPideDoc ;
      private string edtProveedorPideDoc_Jsonclick ;
      private string edtDocumentacionId_Internalname ;
      private string edtDocumentacionId_Jsonclick ;
      private string imgDocumentacionIcono_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string A601ProveedorUsoInterno ;
      private string dynProveedorUsrAlta_Internalname ;
      private string dynProveedorUsrActualizacion_Internalname ;
      private string chkProveedorFreezePrice_Internalname ;
      private string chkProveedorUsoInterno_Internalname ;
      private string edtProveedorFechaAlta_Internalname ;
      private string edtProveedorFechaActualizacion_Internalname ;
      private string sStyleString ;
      private string tblUnnamedtable1_Internalname ;
      private string dynProveedorUsrAlta_Jsonclick ;
      private string dynProveedorUsrActualizacion_Jsonclick ;
      private string edtProveedorFechaAlta_Jsonclick ;
      private string edtProveedorFechaActualizacion_Jsonclick ;
      private string tblTablemergedproveedorusointerno_Internalname ;
      private string lblProveedorusointerno_righttext_Internalname ;
      private string lblProveedorusointerno_righttext_Jsonclick ;
      private string tblTablemergedproveedorfreezeprice_Internalname ;
      private string lblProveedorfreezeprice_righttext_Internalname ;
      private string lblProveedorfreezeprice_righttext_Jsonclick ;
      private string sCtrlA133ProveedorID ;
      private DateTime A686ProveedorAceptoTerminos ;
      private DateTime A549ProveedorFechaActualizacion ;
      private DateTime A548ProveedorFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_unnamedtable3_Autowidth ;
      private bool Dvpanel_unnamedtable3_Autoheight ;
      private bool Dvpanel_unnamedtable3_Collapsible ;
      private bool Dvpanel_unnamedtable3_Collapsed ;
      private bool Dvpanel_unnamedtable3_Showcollapseicon ;
      private bool Dvpanel_unnamedtable3_Autoscroll ;
      private bool wbLoad ;
      private bool A978ProveedorCIU ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool A498DocumentacionIcono_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n547ProveedorUsrActualizacion ;
      private bool n546ProveedorUsrAlta ;
      private bool A999ProveedorFreezePrice ;
      private bool n999ProveedorFreezePrice ;
      private bool n601ProveedorUsoInterno ;
      private bool n673BancoId ;
      private bool n488DocumentacionId ;
      private bool n490ProveedorPideDoc ;
      private bool n437ProveedorPerAltShop ;
      private bool n549ProveedorFechaActualizacion ;
      private bool n548ProveedorFechaAlta ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n684ProveedorContactoCell ;
      private bool n683ProveedorContacto ;
      private bool n686ProveedorAceptoTerminos ;
      private bool n685ProveedorSitioWeb ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n430ProveedorTelefono ;
      private bool n682ProveedorRazonSocial ;
      private bool n432ProveedorImagen ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A433ProveedorEmail ;
      private string A431ProveedorDireccion ;
      private string A40000ProveedorImagen_GXI ;
      private string A40001DocumentacionIcono_GXI ;
      private string A432ProveedorImagen ;
      private string A498DocumentacionIcono ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucDvpanel_unnamedtable3 ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorEstado ;
      private GXCheckbox chkProveedorFreezePrice ;
      private GXCombobox dynProveedoresTipoId ;
      private GXCheckbox chkProveedorUsoInterno ;
      private GXCheckbox chkProveedorCIU ;
      private GXCombobox cmbProveedorPagoDefault ;
      private GXCombobox dynBancoId ;
      private GXCombobox dynProveedorUsrAlta ;
      private GXCombobox dynProveedorUsrActualizacion ;
      private IDataStoreProvider pr_default ;
      private long[] H004U2_A18SecUserId ;
      private string[] H004U2_A587SecUserFullName ;
      private long[] H004U3_A18SecUserId ;
      private string[] H004U3_A587SecUserFullName ;
      private long[] H004U4_A151ProveedoresTipoId ;
      private string[] H004U4_A278ProveedoresTipoNombre ;
      private long[] H004U5_A673BancoId ;
      private bool[] H004U5_n673BancoId ;
      private string[] H004U5_A674BancoNombre ;
      private string[] H004U5_A675BancoEstado ;
      private long[] H004U6_A18SecUserId ;
      private string[] H004U6_A587SecUserFullName ;
      private long[] H004U7_A18SecUserId ;
      private string[] H004U7_A587SecUserFullName ;
      private long[] H004U8_A151ProveedoresTipoId ;
      private string[] H004U8_A278ProveedoresTipoNombre ;
      private long[] H004U9_A133ProveedorID ;
      private string[] H004U9_A40001DocumentacionIcono_GXI ;
      private long[] H004U9_A488DocumentacionId ;
      private bool[] H004U9_n488DocumentacionId ;
      private string[] H004U9_A490ProveedorPideDoc ;
      private bool[] H004U9_n490ProveedorPideDoc ;
      private string[] H004U9_A437ProveedorPerAltShop ;
      private bool[] H004U9_n437ProveedorPerAltShop ;
      private short[] H004U9_A345ProveedorSerialComi ;
      private DateTime[] H004U9_A549ProveedorFechaActualizacion ;
      private bool[] H004U9_n549ProveedorFechaActualizacion ;
      private DateTime[] H004U9_A548ProveedorFechaAlta ;
      private bool[] H004U9_n548ProveedorFechaAlta ;
      private long[] H004U9_A547ProveedorUsrActualizacion ;
      private bool[] H004U9_n547ProveedorUsrActualizacion ;
      private long[] H004U9_A546ProveedorUsrAlta ;
      private bool[] H004U9_n546ProveedorUsrAlta ;
      private string[] H004U9_A687ProveedorCuentaBancaria ;
      private bool[] H004U9_n687ProveedorCuentaBancaria ;
      private long[] H004U9_A673BancoId ;
      private bool[] H004U9_n673BancoId ;
      private string[] H004U9_A684ProveedorContactoCell ;
      private bool[] H004U9_n684ProveedorContactoCell ;
      private string[] H004U9_A683ProveedorContacto ;
      private bool[] H004U9_n683ProveedorContacto ;
      private DateTime[] H004U9_A686ProveedorAceptoTerminos ;
      private bool[] H004U9_n686ProveedorAceptoTerminos ;
      private string[] H004U9_A685ProveedorSitioWeb ;
      private bool[] H004U9_n685ProveedorSitioWeb ;
      private string[] H004U9_A338ProveedorDocIdentidad ;
      private string[] H004U9_A440ProveedorPagoDefault ;
      private string[] H004U9_A40000ProveedorImagen_GXI ;
      private bool[] H004U9_n40000ProveedorImagen_GXI ;
      private bool[] H004U9_A978ProveedorCIU ;
      private string[] H004U9_A601ProveedorUsoInterno ;
      private bool[] H004U9_n601ProveedorUsoInterno ;
      private string[] H004U9_A431ProveedorDireccion ;
      private bool[] H004U9_n431ProveedorDireccion ;
      private string[] H004U9_A433ProveedorEmail ;
      private bool[] H004U9_n433ProveedorEmail ;
      private string[] H004U9_A430ProveedorTelefono ;
      private bool[] H004U9_n430ProveedorTelefono ;
      private string[] H004U9_A682ProveedorRazonSocial ;
      private bool[] H004U9_n682ProveedorRazonSocial ;
      private string[] H004U9_A282ProveedorNombre ;
      private long[] H004U9_A151ProveedoresTipoId ;
      private bool[] H004U9_A999ProveedorFreezePrice ;
      private bool[] H004U9_n999ProveedorFreezePrice ;
      private string[] H004U9_A344ProveedorEstado ;
      private string[] H004U9_A498DocumentacionIcono ;
      private string[] H004U9_A432ProveedorImagen ;
      private bool[] H004U9_n432ProveedorImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H004U10_A151ProveedoresTipoId ;
      private string[] H004U10_A278ProveedoresTipoNombre ;
      private long[] H004U11_A18SecUserId ;
      private string[] H004U11_A587SecUserFullName ;
      private long[] H004U12_A18SecUserId ;
      private string[] H004U12_A587SecUserFullName ;
   }

   public class proveedorgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004U2;
          prmH004U2 = new Object[] {
          };
          Object[] prmH004U3;
          prmH004U3 = new Object[] {
          };
          Object[] prmH004U4;
          prmH004U4 = new Object[] {
          };
          Object[] prmH004U5;
          prmH004U5 = new Object[] {
          };
          Object[] prmH004U6;
          prmH004U6 = new Object[] {
          };
          Object[] prmH004U7;
          prmH004U7 = new Object[] {
          };
          Object[] prmH004U8;
          prmH004U8 = new Object[] {
          };
          Object[] prmH004U9;
          prmH004U9 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmH004U10;
          prmH004U10 = new Object[] {
          };
          Object[] prmH004U11;
          prmH004U11 = new Object[] {
          };
          Object[] prmH004U12;
          prmH004U12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004U2", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U3", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U4", "SELECT [ProveedoresTipoId], [ProveedoresTipoNombre] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U5", "SELECT [BancoId], [BancoNombre], [BancoEstado] FROM [Banco] WHERE [BancoEstado] = 'HAB' ORDER BY [BancoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U6", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U7", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U8", "SELECT [ProveedoresTipoId], [ProveedoresTipoNombre] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U8,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U9", "SELECT T1.[ProveedorID], T2.[DocumentacionIcono_GXI], T1.[DocumentacionId], T1.[ProveedorPideDoc], T1.[ProveedorPerAltShop], T1.[ProveedorSerialComi], T1.[ProveedorFechaActualizacion], T1.[ProveedorFechaAlta], T1.[ProveedorUsrActualizacion], T1.[ProveedorUsrAlta], T1.[ProveedorCuentaBancaria], T1.[BancoId], T1.[ProveedorContactoCell], T1.[ProveedorContacto], T1.[ProveedorAceptoTerminos], T1.[ProveedorSitioWeb], T1.[ProveedorDocIdentidad], T1.[ProveedorPagoDefault], T1.[ProveedorImagen_GXI], T1.[ProveedorCIU], T1.[ProveedorUsoInterno], T1.[ProveedorDireccion], T1.[ProveedorEmail], T1.[ProveedorTelefono], T1.[ProveedorRazonSocial], T1.[ProveedorNombre], T1.[ProveedoresTipoId], T1.[ProveedorFreezePrice], T1.[ProveedorEstado], T2.[DocumentacionIcono], T1.[ProveedorImagen] FROM ([Proveedor] T1 LEFT JOIN [Documentacion] T2 ON T2.[DocumentacionId] = T1.[DocumentacionId]) WHERE T1.[ProveedorID] = @ProveedorID ORDER BY T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004U10", "SELECT [ProveedoresTipoId], [ProveedoresTipoNombre] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U10,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U11", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U11,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004U12", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004U12,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 1);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((long[]) buf[13])[0] = rslt.getLong(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((long[]) buf[15])[0] = rslt.getLong(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((string[]) buf[17])[0] = rslt.getString(11, 50);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((long[]) buf[19])[0] = rslt.getLong(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((string[]) buf[21])[0] = rslt.getString(13, 20);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((string[]) buf[23])[0] = rslt.getString(14, 128);
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(15);
                ((bool[]) buf[26])[0] = rslt.wasNull(15);
                ((string[]) buf[27])[0] = rslt.getString(16, 128);
                ((bool[]) buf[28])[0] = rslt.wasNull(16);
                ((string[]) buf[29])[0] = rslt.getString(17, 25);
                ((string[]) buf[30])[0] = rslt.getString(18, 1);
                ((string[]) buf[31])[0] = rslt.getMultimediaUri(19);
                ((bool[]) buf[32])[0] = rslt.wasNull(19);
                ((bool[]) buf[33])[0] = rslt.getBool(20);
                ((string[]) buf[34])[0] = rslt.getString(21, 1);
                ((bool[]) buf[35])[0] = rslt.wasNull(21);
                ((string[]) buf[36])[0] = rslt.getVarchar(22);
                ((bool[]) buf[37])[0] = rslt.wasNull(22);
                ((string[]) buf[38])[0] = rslt.getVarchar(23);
                ((bool[]) buf[39])[0] = rslt.wasNull(23);
                ((string[]) buf[40])[0] = rslt.getString(24, 20);
                ((bool[]) buf[41])[0] = rslt.wasNull(24);
                ((string[]) buf[42])[0] = rslt.getString(25, 25);
                ((bool[]) buf[43])[0] = rslt.wasNull(25);
                ((string[]) buf[44])[0] = rslt.getString(26, 80);
                ((long[]) buf[45])[0] = rslt.getLong(27);
                ((bool[]) buf[46])[0] = rslt.getBool(28);
                ((bool[]) buf[47])[0] = rslt.wasNull(28);
                ((string[]) buf[48])[0] = rslt.getString(29, 3);
                ((string[]) buf[49])[0] = rslt.getMultimediaFile(30, rslt.getVarchar(2));
                ((string[]) buf[50])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(19));
                ((bool[]) buf[51])[0] = rslt.wasNull(31);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}

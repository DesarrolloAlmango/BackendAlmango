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
   public class maildesign : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A149MailId = (long)(Math.Round(NumberUtil.Val( GetPar( "MailId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A149MailId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "maildesign.aspx")), "maildesign.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "maildesign.aspx")))) ;
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
                  AV7MailDesignId = (long)(Math.Round(NumberUtil.Val( GetPar( "MailDesignId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MailDesignId", StringUtil.LTrimStr( (decimal)(AV7MailDesignId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMAILDESIGNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MailDesignId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Mail Design", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbMailDesignTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public maildesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public maildesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_MailDesignId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MailDesignId = aP1_MailDesignId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMailDesignTipo = new GXCombobox();
         cmbMailEstado = new GXCombobox();
         cmbMailDesignEstado = new GXCombobox();
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
         if ( cmbMailDesignTipo.ItemCount > 0 )
         {
            A244MailDesignTipo = cmbMailDesignTipo.getValidValue(A244MailDesignTipo);
            AssignAttri("", false, "A244MailDesignTipo", A244MailDesignTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMailDesignTipo.CurrentValue = StringUtil.RTrim( A244MailDesignTipo);
            AssignProp("", false, cmbMailDesignTipo_Internalname, "Values", cmbMailDesignTipo.ToJavascriptSource(), true);
         }
         if ( cmbMailEstado.ItemCount > 0 )
         {
            A243MailEstado = cmbMailEstado.getValidValue(A243MailEstado);
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMailEstado.CurrentValue = StringUtil.RTrim( A243MailEstado);
            AssignProp("", false, cmbMailEstado_Internalname, "Values", cmbMailEstado.ToJavascriptSource(), true);
         }
         if ( cmbMailDesignEstado.ItemCount > 0 )
         {
            A245MailDesignEstado = cmbMailDesignEstado.getValidValue(A245MailDesignEstado);
            AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMailDesignEstado.CurrentValue = StringUtil.RTrim( A245MailDesignEstado);
            AssignProp("", false, cmbMailDesignEstado_Internalname, "Values", cmbMailDesignEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailDesignId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailDesignId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailDesignId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailDesignId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailDesignId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbMailDesignTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMailDesignTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMailDesignTipo, cmbMailDesignTipo_Internalname, StringUtil.RTrim( A244MailDesignTipo), 1, cmbMailDesignTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMailDesignTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_MailDesign.htm");
         cmbMailDesignTipo.CurrentValue = StringUtil.RTrim( A244MailDesignTipo);
         AssignProp("", false, cmbMailDesignTipo_Internalname, "Values", (string)(cmbMailDesignTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_MailDesign.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_149_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_149_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_149_Internalname, sImgUrl, imgprompt_149_Link, "", "", context.GetTheme( ), imgprompt_149_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailCuentaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailCuentaNombre_Internalname, context.GetMessage( "Nombre de la Cuenta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailCuentaNombre_Internalname, StringUtil.RTrim( A241MailCuentaNombre), StringUtil.RTrim( context.localUtil.Format( A241MailCuentaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailCuentaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailCuentaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailDireccion_Internalname, context.GetMessage( "Mail Direccion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailDireccion_Internalname, A242MailDireccion, StringUtil.RTrim( context.localUtil.Format( A242MailDireccion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailDireccion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailDireccion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbMailEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMailEstado_Internalname, context.GetMessage( "Mail Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMailEstado, cmbMailEstado_Internalname, StringUtil.RTrim( A243MailEstado), 1, cmbMailEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMailEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_MailDesign.htm");
         cmbMailEstado.CurrentValue = StringUtil.RTrim( A243MailEstado);
         AssignProp("", false, cmbMailEstado_Internalname, "Values", (string)(cmbMailEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailDesignAsunto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailDesignAsunto_Internalname, context.GetMessage( "Asunto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailDesignAsunto_Internalname, StringUtil.RTrim( A246MailDesignAsunto), StringUtil.RTrim( context.localUtil.Format( A246MailDesignAsunto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailDesignAsunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailDesignAsunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailDesignNombReenvio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailDesignNombReenvio_Internalname, context.GetMessage( "Reenvio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailDesignNombReenvio_Internalname, StringUtil.RTrim( A254MailDesignNombReenvio), StringUtil.RTrim( context.localUtil.Format( A254MailDesignNombReenvio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMailDesignNombReenvio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailDesignNombReenvio_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMailDesignMailReenviar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMailDesignMailReenviar_Internalname, context.GetMessage( "Mail Reenviar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMailDesignMailReenviar_Internalname, A253MailDesignMailReenviar, StringUtil.RTrim( context.localUtil.Format( A253MailDesignMailReenviar, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A253MailDesignMailReenviar, "", "", "", edtMailDesignMailReenviar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMailDesignMailReenviar_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Maildesigncabezal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Maildesigncabezal_Internalname, context.GetMessage( "Cabezal", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucMaildesigncabezal.SetProperty("Attribute", MailDesignCabezal);
         ucMaildesigncabezal.SetProperty("CaptionClass", Maildesigncabezal_Captionclass);
         ucMaildesigncabezal.SetProperty("CaptionStyle", Maildesigncabezal_Captionstyle);
         ucMaildesigncabezal.SetProperty("CaptionPosition", Maildesigncabezal_Captionposition);
         ucMaildesigncabezal.Render(context, "fckeditor", Maildesigncabezal_Internalname, "MAILDESIGNCABEZALContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Maildesignmensaje_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Maildesignmensaje_Internalname, context.GetMessage( "Mensaje", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucMaildesignmensaje.SetProperty("Attribute", MailDesignMensaje);
         ucMaildesignmensaje.SetProperty("CaptionClass", Maildesignmensaje_Captionclass);
         ucMaildesignmensaje.SetProperty("CaptionStyle", Maildesignmensaje_Captionstyle);
         ucMaildesignmensaje.SetProperty("CaptionPosition", Maildesignmensaje_Captionposition);
         ucMaildesignmensaje.Render(context, "fckeditor", Maildesignmensaje_Internalname, "MAILDESIGNMENSAJEContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Maildesignfirma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Maildesignfirma_Internalname, context.GetMessage( "Firma", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucMaildesignfirma.SetProperty("Attribute", MailDesignFirma);
         ucMaildesignfirma.SetProperty("CaptionClass", Maildesignfirma_Captionclass);
         ucMaildesignfirma.SetProperty("CaptionStyle", Maildesignfirma_Captionstyle);
         ucMaildesignfirma.SetProperty("CaptionPosition", Maildesignfirma_Captionposition);
         ucMaildesignfirma.Render(context, "fckeditor", Maildesignfirma_Internalname, "MAILDESIGNFIRMAContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbMailDesignEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMailDesignEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMailDesignEstado, cmbMailDesignEstado_Internalname, StringUtil.RTrim( A245MailDesignEstado), 1, cmbMailDesignEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMailDesignEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_MailDesign.htm");
         cmbMailDesignEstado.CurrentValue = StringUtil.RTrim( A245MailDesignEstado);
         AssignProp("", false, cmbMailDesignEstado_Internalname, "Values", (string)(cmbMailDesignEstado.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesign.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesign.htm");
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
         E11152 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z148MailDesignId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z148MailDesignId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z245MailDesignEstado = cgiGet( "Z245MailDesignEstado");
               Z244MailDesignTipo = cgiGet( "Z244MailDesignTipo");
               Z246MailDesignAsunto = cgiGet( "Z246MailDesignAsunto");
               Z254MailDesignNombReenvio = cgiGet( "Z254MailDesignNombReenvio");
               Z253MailDesignMailReenviar = cgiGet( "Z253MailDesignMailReenviar");
               Z149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z149MailId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N149MailId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7MailDesignId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vMAILDESIGNID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MAILID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_MailId", StringUtil.LTrimStr( (decimal)(AV13Insert_MailId), 18, 0));
               A251MailDesignCabezal = cgiGet( "MAILDESIGNCABEZAL");
               A250MailDesignMensaje = cgiGet( "MAILDESIGNMENSAJE");
               A252MailDesignFirma = cgiGet( "MAILDESIGNFIRMA");
               AV15Pgmname = cgiGet( "vPGMNAME");
               Maildesigncabezal_Objectcall = cgiGet( "MAILDESIGNCABEZAL_Objectcall");
               Maildesigncabezal_Class = cgiGet( "MAILDESIGNCABEZAL_Class");
               Maildesigncabezal_Enabled = StringUtil.StrToBool( cgiGet( "MAILDESIGNCABEZAL_Enabled"));
               Maildesigncabezal_Width = cgiGet( "MAILDESIGNCABEZAL_Width");
               Maildesigncabezal_Height = cgiGet( "MAILDESIGNCABEZAL_Height");
               Maildesigncabezal_Skin = cgiGet( "MAILDESIGNCABEZAL_Skin");
               Maildesigncabezal_Toolbar = cgiGet( "MAILDESIGNCABEZAL_Toolbar");
               Maildesigncabezal_Customtoolbar = cgiGet( "MAILDESIGNCABEZAL_Customtoolbar");
               Maildesigncabezal_Customconfiguration = cgiGet( "MAILDESIGNCABEZAL_Customconfiguration");
               Maildesigncabezal_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "MAILDESIGNCABEZAL_Toolbarcancollapse"));
               Maildesigncabezal_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "MAILDESIGNCABEZAL_Toolbarexpanded"));
               Maildesigncabezal_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAILDESIGNCABEZAL_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Maildesigncabezal_Buttonpressedid = cgiGet( "MAILDESIGNCABEZAL_Buttonpressedid");
               Maildesigncabezal_Captionvalue = cgiGet( "MAILDESIGNCABEZAL_Captionvalue");
               Maildesigncabezal_Captionclass = cgiGet( "MAILDESIGNCABEZAL_Captionclass");
               Maildesigncabezal_Captionstyle = cgiGet( "MAILDESIGNCABEZAL_Captionstyle");
               Maildesigncabezal_Captionposition = cgiGet( "MAILDESIGNCABEZAL_Captionposition");
               Maildesigncabezal_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "MAILDESIGNCABEZAL_Isabstractlayoutcontrol"));
               Maildesigncabezal_Coltitle = cgiGet( "MAILDESIGNCABEZAL_Coltitle");
               Maildesigncabezal_Coltitlefont = cgiGet( "MAILDESIGNCABEZAL_Coltitlefont");
               Maildesigncabezal_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAILDESIGNCABEZAL_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Maildesigncabezal_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "MAILDESIGNCABEZAL_Usercontroliscolumn"));
               Maildesigncabezal_Visible = StringUtil.StrToBool( cgiGet( "MAILDESIGNCABEZAL_Visible"));
               Maildesignmensaje_Objectcall = cgiGet( "MAILDESIGNMENSAJE_Objectcall");
               Maildesignmensaje_Class = cgiGet( "MAILDESIGNMENSAJE_Class");
               Maildesignmensaje_Enabled = StringUtil.StrToBool( cgiGet( "MAILDESIGNMENSAJE_Enabled"));
               Maildesignmensaje_Width = cgiGet( "MAILDESIGNMENSAJE_Width");
               Maildesignmensaje_Height = cgiGet( "MAILDESIGNMENSAJE_Height");
               Maildesignmensaje_Skin = cgiGet( "MAILDESIGNMENSAJE_Skin");
               Maildesignmensaje_Toolbar = cgiGet( "MAILDESIGNMENSAJE_Toolbar");
               Maildesignmensaje_Customtoolbar = cgiGet( "MAILDESIGNMENSAJE_Customtoolbar");
               Maildesignmensaje_Customconfiguration = cgiGet( "MAILDESIGNMENSAJE_Customconfiguration");
               Maildesignmensaje_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "MAILDESIGNMENSAJE_Toolbarcancollapse"));
               Maildesignmensaje_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "MAILDESIGNMENSAJE_Toolbarexpanded"));
               Maildesignmensaje_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAILDESIGNMENSAJE_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Maildesignmensaje_Buttonpressedid = cgiGet( "MAILDESIGNMENSAJE_Buttonpressedid");
               Maildesignmensaje_Captionvalue = cgiGet( "MAILDESIGNMENSAJE_Captionvalue");
               Maildesignmensaje_Captionclass = cgiGet( "MAILDESIGNMENSAJE_Captionclass");
               Maildesignmensaje_Captionstyle = cgiGet( "MAILDESIGNMENSAJE_Captionstyle");
               Maildesignmensaje_Captionposition = cgiGet( "MAILDESIGNMENSAJE_Captionposition");
               Maildesignmensaje_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "MAILDESIGNMENSAJE_Isabstractlayoutcontrol"));
               Maildesignmensaje_Coltitle = cgiGet( "MAILDESIGNMENSAJE_Coltitle");
               Maildesignmensaje_Coltitlefont = cgiGet( "MAILDESIGNMENSAJE_Coltitlefont");
               Maildesignmensaje_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAILDESIGNMENSAJE_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Maildesignmensaje_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "MAILDESIGNMENSAJE_Usercontroliscolumn"));
               Maildesignmensaje_Visible = StringUtil.StrToBool( cgiGet( "MAILDESIGNMENSAJE_Visible"));
               Maildesignfirma_Objectcall = cgiGet( "MAILDESIGNFIRMA_Objectcall");
               Maildesignfirma_Class = cgiGet( "MAILDESIGNFIRMA_Class");
               Maildesignfirma_Enabled = StringUtil.StrToBool( cgiGet( "MAILDESIGNFIRMA_Enabled"));
               Maildesignfirma_Width = cgiGet( "MAILDESIGNFIRMA_Width");
               Maildesignfirma_Height = cgiGet( "MAILDESIGNFIRMA_Height");
               Maildesignfirma_Skin = cgiGet( "MAILDESIGNFIRMA_Skin");
               Maildesignfirma_Toolbar = cgiGet( "MAILDESIGNFIRMA_Toolbar");
               Maildesignfirma_Customtoolbar = cgiGet( "MAILDESIGNFIRMA_Customtoolbar");
               Maildesignfirma_Customconfiguration = cgiGet( "MAILDESIGNFIRMA_Customconfiguration");
               Maildesignfirma_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "MAILDESIGNFIRMA_Toolbarcancollapse"));
               Maildesignfirma_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "MAILDESIGNFIRMA_Toolbarexpanded"));
               Maildesignfirma_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAILDESIGNFIRMA_Color"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Maildesignfirma_Buttonpressedid = cgiGet( "MAILDESIGNFIRMA_Buttonpressedid");
               Maildesignfirma_Captionvalue = cgiGet( "MAILDESIGNFIRMA_Captionvalue");
               Maildesignfirma_Captionclass = cgiGet( "MAILDESIGNFIRMA_Captionclass");
               Maildesignfirma_Captionstyle = cgiGet( "MAILDESIGNFIRMA_Captionstyle");
               Maildesignfirma_Captionposition = cgiGet( "MAILDESIGNFIRMA_Captionposition");
               Maildesignfirma_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "MAILDESIGNFIRMA_Isabstractlayoutcontrol"));
               Maildesignfirma_Coltitle = cgiGet( "MAILDESIGNFIRMA_Coltitle");
               Maildesignfirma_Coltitlefont = cgiGet( "MAILDESIGNFIRMA_Coltitlefont");
               Maildesignfirma_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MAILDESIGNFIRMA_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Maildesignfirma_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "MAILDESIGNFIRMA_Usercontroliscolumn"));
               Maildesignfirma_Visible = StringUtil.StrToBool( cgiGet( "MAILDESIGNFIRMA_Visible"));
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
               A148MailDesignId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailDesignId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
               cmbMailDesignTipo.CurrentValue = cgiGet( cmbMailDesignTipo_Internalname);
               A244MailDesignTipo = cgiGet( cmbMailDesignTipo_Internalname);
               AssignAttri("", false, "A244MailDesignTipo", A244MailDesignTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MAILID");
                  AnyError = 1;
                  GX_FocusControl = edtMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A149MailId = 0;
                  AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
               }
               else
               {
                  A149MailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
               }
               A241MailCuentaNombre = cgiGet( edtMailCuentaNombre_Internalname);
               AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
               A242MailDireccion = cgiGet( edtMailDireccion_Internalname);
               AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
               cmbMailEstado.CurrentValue = cgiGet( cmbMailEstado_Internalname);
               A243MailEstado = cgiGet( cmbMailEstado_Internalname);
               AssignAttri("", false, "A243MailEstado", A243MailEstado);
               A246MailDesignAsunto = cgiGet( edtMailDesignAsunto_Internalname);
               AssignAttri("", false, "A246MailDesignAsunto", A246MailDesignAsunto);
               A254MailDesignNombReenvio = cgiGet( edtMailDesignNombReenvio_Internalname);
               AssignAttri("", false, "A254MailDesignNombReenvio", A254MailDesignNombReenvio);
               A253MailDesignMailReenviar = cgiGet( edtMailDesignMailReenviar_Internalname);
               AssignAttri("", false, "A253MailDesignMailReenviar", A253MailDesignMailReenviar);
               cmbMailDesignEstado.CurrentValue = cgiGet( cmbMailDesignEstado_Internalname);
               A245MailDesignEstado = cgiGet( cmbMailDesignEstado_Internalname);
               AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MailDesign");
               forbiddenHiddens.Add("Insert_MailId", context.localUtil.Format( (decimal)(AV13Insert_MailId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A148MailDesignId != Z148MailDesignId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("maildesign:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A148MailDesignId = (long)(Math.Round(NumberUtil.Val( GetPar( "MailDesignId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
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
                     sMode47 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode47;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound47 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_150( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MAILDESIGNID");
                        AnyError = 1;
                        GX_FocusControl = edtMailDesignId_Internalname;
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
                           E11152 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12152 ();
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
            E12152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1547( ) ;
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
            DisableAttributes1547( ) ;
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1547( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1547( ) ;
            }
            else
            {
               CheckExtendedTable1547( ) ;
               CloseExtendedTableCursors1547( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption150( )
      {
      }

      protected void E11152( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign_Delete", out  GXt_boolean1) ;
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
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MailId") == 0 )
               {
                  AV13Insert_MailId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_MailId", StringUtil.LTrimStr( (decimal)(AV13Insert_MailId), 18, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
      }

      protected void E12152( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("maildesignww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1547( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z245MailDesignEstado = T00153_A245MailDesignEstado[0];
               Z244MailDesignTipo = T00153_A244MailDesignTipo[0];
               Z246MailDesignAsunto = T00153_A246MailDesignAsunto[0];
               Z254MailDesignNombReenvio = T00153_A254MailDesignNombReenvio[0];
               Z253MailDesignMailReenviar = T00153_A253MailDesignMailReenviar[0];
               Z149MailId = T00153_A149MailId[0];
            }
            else
            {
               Z245MailDesignEstado = A245MailDesignEstado;
               Z244MailDesignTipo = A244MailDesignTipo;
               Z246MailDesignAsunto = A246MailDesignAsunto;
               Z254MailDesignNombReenvio = A254MailDesignNombReenvio;
               Z253MailDesignMailReenviar = A253MailDesignMailReenviar;
               Z149MailId = A149MailId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z148MailDesignId = A148MailDesignId;
            Z245MailDesignEstado = A245MailDesignEstado;
            Z244MailDesignTipo = A244MailDesignTipo;
            Z246MailDesignAsunto = A246MailDesignAsunto;
            Z254MailDesignNombReenvio = A254MailDesignNombReenvio;
            Z253MailDesignMailReenviar = A253MailDesignMailReenviar;
            Z251MailDesignCabezal = A251MailDesignCabezal;
            Z250MailDesignMensaje = A250MailDesignMensaje;
            Z252MailDesignFirma = A252MailDesignFirma;
            Z149MailId = A149MailId;
            Z241MailCuentaNombre = A241MailCuentaNombre;
            Z242MailDireccion = A242MailDireccion;
            Z243MailEstado = A243MailEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_149_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx01c0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MAILID"+"'), id:'"+"MAILID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtMailDesignId_Enabled = 0;
         AssignProp("", false, edtMailDesignId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MailDesignId) )
         {
            A148MailDesignId = AV7MailDesignId;
            AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               A148MailDesignId = AV7MailDesignId;
               AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
            }
         }
         if ( ! (0==AV7MailDesignId) )
         {
            edtMailDesignId_Enabled = 0;
            AssignProp("", false, edtMailDesignId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Enabled), 5, 0), true);
         }
         else
         {
            if ( true )
            {
               edtMailDesignId_Enabled = 1;
               AssignProp("", false, edtMailDesignId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Enabled), 5, 0), true);
            }
            else
            {
               edtMailDesignId_Enabled = 0;
               AssignProp("", false, edtMailDesignId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Enabled), 5, 0), true);
            }
         }
         if ( ! (0==AV7MailDesignId) )
         {
            edtMailDesignId_Enabled = 0;
            AssignProp("", false, edtMailDesignId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MailId) )
         {
            edtMailId_Enabled = 0;
            AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         }
         else
         {
            edtMailId_Enabled = 1;
            AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MailId) )
         {
            A149MailId = AV13Insert_MailId;
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
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
            AV15Pgmname = "MailDesign";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00154 */
            pr_default.execute(2, new Object[] {A149MailId});
            A241MailCuentaNombre = T00154_A241MailCuentaNombre[0];
            AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
            A242MailDireccion = T00154_A242MailDireccion[0];
            AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
            A243MailEstado = T00154_A243MailEstado[0];
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
            pr_default.close(2);
         }
      }

      protected void Load1547( )
      {
         /* Using cursor T00155 */
         pr_default.execute(3, new Object[] {A148MailDesignId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound47 = 1;
            A245MailDesignEstado = T00155_A245MailDesignEstado[0];
            AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
            A244MailDesignTipo = T00155_A244MailDesignTipo[0];
            AssignAttri("", false, "A244MailDesignTipo", A244MailDesignTipo);
            A241MailCuentaNombre = T00155_A241MailCuentaNombre[0];
            AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
            A242MailDireccion = T00155_A242MailDireccion[0];
            AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
            A243MailEstado = T00155_A243MailEstado[0];
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
            A246MailDesignAsunto = T00155_A246MailDesignAsunto[0];
            AssignAttri("", false, "A246MailDesignAsunto", A246MailDesignAsunto);
            A254MailDesignNombReenvio = T00155_A254MailDesignNombReenvio[0];
            AssignAttri("", false, "A254MailDesignNombReenvio", A254MailDesignNombReenvio);
            A253MailDesignMailReenviar = T00155_A253MailDesignMailReenviar[0];
            AssignAttri("", false, "A253MailDesignMailReenviar", A253MailDesignMailReenviar);
            A251MailDesignCabezal = T00155_A251MailDesignCabezal[0];
            A250MailDesignMensaje = T00155_A250MailDesignMensaje[0];
            A252MailDesignFirma = T00155_A252MailDesignFirma[0];
            A149MailId = T00155_A149MailId[0];
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
            ZM1547( -11) ;
         }
         pr_default.close(3);
         OnLoadActions1547( ) ;
      }

      protected void OnLoadActions1547( )
      {
         AV15Pgmname = "MailDesign";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable1547( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "MailDesign";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {A149MailId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mail", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MAILID");
            AnyError = 1;
            GX_FocusControl = edtMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A241MailCuentaNombre = T00154_A241MailCuentaNombre[0];
         AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
         A242MailDireccion = T00154_A242MailDireccion[0];
         AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
         A243MailEstado = T00154_A243MailEstado[0];
         AssignAttri("", false, "A243MailEstado", A243MailEstado);
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A253MailDesignMailReenviar,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Mail Reenviar", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MAILDESIGNMAILREENVIAR");
            AnyError = 1;
            GX_FocusControl = edtMailDesignMailReenviar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1547( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( long A149MailId )
      {
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {A149MailId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mail", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MAILID");
            AnyError = 1;
            GX_FocusControl = edtMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A241MailCuentaNombre = T00156_A241MailCuentaNombre[0];
         AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
         A242MailDireccion = T00156_A242MailDireccion[0];
         AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
         A243MailEstado = T00156_A243MailEstado[0];
         AssignAttri("", false, "A243MailEstado", A243MailEstado);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A241MailCuentaNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A242MailDireccion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A243MailEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1547( )
      {
         /* Using cursor T00157 */
         pr_default.execute(5, new Object[] {A148MailDesignId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {A148MailDesignId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1547( 11) ;
            RcdFound47 = 1;
            A148MailDesignId = T00153_A148MailDesignId[0];
            AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
            A245MailDesignEstado = T00153_A245MailDesignEstado[0];
            AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
            A244MailDesignTipo = T00153_A244MailDesignTipo[0];
            AssignAttri("", false, "A244MailDesignTipo", A244MailDesignTipo);
            A246MailDesignAsunto = T00153_A246MailDesignAsunto[0];
            AssignAttri("", false, "A246MailDesignAsunto", A246MailDesignAsunto);
            A254MailDesignNombReenvio = T00153_A254MailDesignNombReenvio[0];
            AssignAttri("", false, "A254MailDesignNombReenvio", A254MailDesignNombReenvio);
            A253MailDesignMailReenviar = T00153_A253MailDesignMailReenviar[0];
            AssignAttri("", false, "A253MailDesignMailReenviar", A253MailDesignMailReenviar);
            A251MailDesignCabezal = T00153_A251MailDesignCabezal[0];
            A250MailDesignMensaje = T00153_A250MailDesignMensaje[0];
            A252MailDesignFirma = T00153_A252MailDesignFirma[0];
            A149MailId = T00153_A149MailId[0];
            AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
            Z148MailDesignId = A148MailDesignId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1547( ) ;
            if ( AnyError == 1 )
            {
               RcdFound47 = 0;
               InitializeNonKey1547( ) ;
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey1547( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1547( ) ;
         if ( RcdFound47 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound47 = 0;
         /* Using cursor T00158 */
         pr_default.execute(6, new Object[] {A148MailDesignId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00158_A148MailDesignId[0] < A148MailDesignId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00158_A148MailDesignId[0] > A148MailDesignId ) ) )
            {
               A148MailDesignId = T00158_A148MailDesignId[0];
               AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
               RcdFound47 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound47 = 0;
         /* Using cursor T00159 */
         pr_default.execute(7, new Object[] {A148MailDesignId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00159_A148MailDesignId[0] > A148MailDesignId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00159_A148MailDesignId[0] < A148MailDesignId ) ) )
            {
               A148MailDesignId = T00159_A148MailDesignId[0];
               AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
               RcdFound47 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1547( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbMailDesignTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1547( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound47 == 1 )
            {
               if ( A148MailDesignId != Z148MailDesignId )
               {
                  A148MailDesignId = Z148MailDesignId;
                  AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MAILDESIGNID");
                  AnyError = 1;
                  GX_FocusControl = edtMailDesignId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbMailDesignTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1547( ) ;
                  GX_FocusControl = cmbMailDesignTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A148MailDesignId != Z148MailDesignId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbMailDesignTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1547( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MAILDESIGNID");
                     AnyError = 1;
                     GX_FocusControl = edtMailDesignId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbMailDesignTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1547( ) ;
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
         if ( A148MailDesignId != Z148MailDesignId )
         {
            A148MailDesignId = Z148MailDesignId;
            AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MAILDESIGNID");
            AnyError = 1;
            GX_FocusControl = edtMailDesignId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbMailDesignTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1547( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {A148MailDesignId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MailDesign"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z245MailDesignEstado, T00152_A245MailDesignEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z244MailDesignTipo, T00152_A244MailDesignTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z246MailDesignAsunto, T00152_A246MailDesignAsunto[0]) != 0 ) || ( StringUtil.StrCmp(Z254MailDesignNombReenvio, T00152_A254MailDesignNombReenvio[0]) != 0 ) || ( StringUtil.StrCmp(Z253MailDesignMailReenviar, T00152_A253MailDesignMailReenviar[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z149MailId != T00152_A149MailId[0] ) )
            {
               if ( StringUtil.StrCmp(Z245MailDesignEstado, T00152_A245MailDesignEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("maildesign:[seudo value changed for attri]"+"MailDesignEstado");
                  GXUtil.WriteLogRaw("Old: ",Z245MailDesignEstado);
                  GXUtil.WriteLogRaw("Current: ",T00152_A245MailDesignEstado[0]);
               }
               if ( StringUtil.StrCmp(Z244MailDesignTipo, T00152_A244MailDesignTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("maildesign:[seudo value changed for attri]"+"MailDesignTipo");
                  GXUtil.WriteLogRaw("Old: ",Z244MailDesignTipo);
                  GXUtil.WriteLogRaw("Current: ",T00152_A244MailDesignTipo[0]);
               }
               if ( StringUtil.StrCmp(Z246MailDesignAsunto, T00152_A246MailDesignAsunto[0]) != 0 )
               {
                  GXUtil.WriteLog("maildesign:[seudo value changed for attri]"+"MailDesignAsunto");
                  GXUtil.WriteLogRaw("Old: ",Z246MailDesignAsunto);
                  GXUtil.WriteLogRaw("Current: ",T00152_A246MailDesignAsunto[0]);
               }
               if ( StringUtil.StrCmp(Z254MailDesignNombReenvio, T00152_A254MailDesignNombReenvio[0]) != 0 )
               {
                  GXUtil.WriteLog("maildesign:[seudo value changed for attri]"+"MailDesignNombReenvio");
                  GXUtil.WriteLogRaw("Old: ",Z254MailDesignNombReenvio);
                  GXUtil.WriteLogRaw("Current: ",T00152_A254MailDesignNombReenvio[0]);
               }
               if ( StringUtil.StrCmp(Z253MailDesignMailReenviar, T00152_A253MailDesignMailReenviar[0]) != 0 )
               {
                  GXUtil.WriteLog("maildesign:[seudo value changed for attri]"+"MailDesignMailReenviar");
                  GXUtil.WriteLogRaw("Old: ",Z253MailDesignMailReenviar);
                  GXUtil.WriteLogRaw("Current: ",T00152_A253MailDesignMailReenviar[0]);
               }
               if ( Z149MailId != T00152_A149MailId[0] )
               {
                  GXUtil.WriteLog("maildesign:[seudo value changed for attri]"+"MailId");
                  GXUtil.WriteLogRaw("Old: ",Z149MailId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A149MailId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MailDesign"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1547( )
      {
         BeforeValidate1547( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1547( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1547( 0) ;
            CheckOptimisticConcurrency1547( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1547( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1547( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001510 */
                     pr_default.execute(8, new Object[] {A148MailDesignId, A245MailDesignEstado, A244MailDesignTipo, A246MailDesignAsunto, A254MailDesignNombReenvio, A253MailDesignMailReenviar, A251MailDesignCabezal, A250MailDesignMensaje, A252MailDesignFirma, A149MailId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("MailDesign");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption150( ) ;
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
               Load1547( ) ;
            }
            EndLevel1547( ) ;
         }
         CloseExtendedTableCursors1547( ) ;
      }

      protected void Update1547( )
      {
         BeforeValidate1547( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1547( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1547( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1547( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1547( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001511 */
                     pr_default.execute(9, new Object[] {A245MailDesignEstado, A244MailDesignTipo, A246MailDesignAsunto, A254MailDesignNombReenvio, A253MailDesignMailReenviar, A251MailDesignCabezal, A250MailDesignMensaje, A252MailDesignFirma, A149MailId, A148MailDesignId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("MailDesign");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MailDesign"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1547( ) ;
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
            EndLevel1547( ) ;
         }
         CloseExtendedTableCursors1547( ) ;
      }

      protected void DeferredUpdate1547( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1547( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1547( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1547( ) ;
            AfterConfirm1547( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1547( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001512 */
                  pr_default.execute(10, new Object[] {A148MailDesignId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("MailDesign");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1547( ) ;
         Gx_mode = sMode47;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1547( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "MailDesign";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T001513 */
            pr_default.execute(11, new Object[] {A149MailId});
            A241MailCuentaNombre = T001513_A241MailCuentaNombre[0];
            AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
            A242MailDireccion = T001513_A242MailDireccion[0];
            AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
            A243MailEstado = T001513_A243MailEstado[0];
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
            pr_default.close(11);
         }
      }

      protected void EndLevel1547( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1547( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("maildesign",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("maildesign",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1547( )
      {
         /* Scan By routine */
         /* Using cursor T001514 */
         pr_default.execute(12);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound47 = 1;
            A148MailDesignId = T001514_A148MailDesignId[0];
            AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1547( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound47 = 1;
            A148MailDesignId = T001514_A148MailDesignId[0];
            AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
         }
      }

      protected void ScanEnd1547( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1547( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A245MailDesignEstado = context.GetMessage( context.GetMessage( "HAB", ""), "");
            AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
         }
      }

      protected void BeforeInsert1547( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1547( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1547( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1547( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1547( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1547( )
      {
         edtMailDesignId_Enabled = 0;
         AssignProp("", false, edtMailDesignId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Enabled), 5, 0), true);
         cmbMailDesignTipo.Enabled = 0;
         AssignProp("", false, cmbMailDesignTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMailDesignTipo.Enabled), 5, 0), true);
         edtMailId_Enabled = 0;
         AssignProp("", false, edtMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailId_Enabled), 5, 0), true);
         edtMailCuentaNombre_Enabled = 0;
         AssignProp("", false, edtMailCuentaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailCuentaNombre_Enabled), 5, 0), true);
         edtMailDireccion_Enabled = 0;
         AssignProp("", false, edtMailDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDireccion_Enabled), 5, 0), true);
         cmbMailEstado.Enabled = 0;
         AssignProp("", false, cmbMailEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMailEstado.Enabled), 5, 0), true);
         edtMailDesignAsunto_Enabled = 0;
         AssignProp("", false, edtMailDesignAsunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignAsunto_Enabled), 5, 0), true);
         edtMailDesignNombReenvio_Enabled = 0;
         AssignProp("", false, edtMailDesignNombReenvio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignNombReenvio_Enabled), 5, 0), true);
         edtMailDesignMailReenviar_Enabled = 0;
         AssignProp("", false, edtMailDesignMailReenviar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMailDesignMailReenviar_Enabled), 5, 0), true);
         cmbMailDesignEstado.Enabled = 0;
         AssignProp("", false, cmbMailDesignEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMailDesignEstado.Enabled), 5, 0), true);
         Maildesigncabezal_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Maildesigncabezal_Internalname, "Enabled", StringUtil.BoolToStr( Maildesigncabezal_Enabled), true);
         Maildesignmensaje_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Maildesignmensaje_Internalname, "Enabled", StringUtil.BoolToStr( Maildesignmensaje_Enabled), true);
         Maildesignfirma_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Maildesignfirma_Internalname, "Enabled", StringUtil.BoolToStr( Maildesignfirma_Enabled), true);
      }

      protected void send_integrity_lvl_hashes1547( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
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
         GXEncryptionTmp = "maildesign.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MailDesignId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("maildesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MailDesign");
         forbiddenHiddens.Add("Insert_MailId", context.localUtil.Format( (decimal)(AV13Insert_MailId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("maildesign:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z148MailDesignId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z148MailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z245MailDesignEstado", StringUtil.RTrim( Z245MailDesignEstado));
         GxWebStd.gx_hidden_field( context, "Z244MailDesignTipo", StringUtil.RTrim( Z244MailDesignTipo));
         GxWebStd.gx_hidden_field( context, "Z246MailDesignAsunto", StringUtil.RTrim( Z246MailDesignAsunto));
         GxWebStd.gx_hidden_field( context, "Z254MailDesignNombReenvio", StringUtil.RTrim( Z254MailDesignNombReenvio));
         GxWebStd.gx_hidden_field( context, "Z253MailDesignMailReenviar", Z253MailDesignMailReenviar);
         GxWebStd.gx_hidden_field( context, "Z149MailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N149MailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A149MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vMAILDESIGNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMAILDESIGNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MailDesignId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_MailId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNCABEZAL", A251MailDesignCabezal);
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMENSAJE", A250MailDesignMensaje);
         GxWebStd.gx_hidden_field( context, "MAILDESIGNFIRMA", A252MailDesignFirma);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNCABEZAL_Objectcall", StringUtil.RTrim( Maildesigncabezal_Objectcall));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNCABEZAL_Enabled", StringUtil.BoolToStr( Maildesigncabezal_Enabled));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNCABEZAL_Captionclass", StringUtil.RTrim( Maildesigncabezal_Captionclass));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNCABEZAL_Captionstyle", StringUtil.RTrim( Maildesigncabezal_Captionstyle));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNCABEZAL_Captionposition", StringUtil.RTrim( Maildesigncabezal_Captionposition));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMENSAJE_Objectcall", StringUtil.RTrim( Maildesignmensaje_Objectcall));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMENSAJE_Enabled", StringUtil.BoolToStr( Maildesignmensaje_Enabled));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMENSAJE_Captionclass", StringUtil.RTrim( Maildesignmensaje_Captionclass));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMENSAJE_Captionstyle", StringUtil.RTrim( Maildesignmensaje_Captionstyle));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNMENSAJE_Captionposition", StringUtil.RTrim( Maildesignmensaje_Captionposition));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNFIRMA_Objectcall", StringUtil.RTrim( Maildesignfirma_Objectcall));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNFIRMA_Enabled", StringUtil.BoolToStr( Maildesignfirma_Enabled));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNFIRMA_Captionclass", StringUtil.RTrim( Maildesignfirma_Captionclass));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNFIRMA_Captionstyle", StringUtil.RTrim( Maildesignfirma_Captionstyle));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNFIRMA_Captionposition", StringUtil.RTrim( Maildesignfirma_Captionposition));
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
         GXEncryptionTmp = "maildesign.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MailDesignId,18,0));
         return formatLink("maildesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "MailDesign" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Mail Design", "") ;
      }

      protected void InitializeNonKey1547( )
      {
         A149MailId = 0;
         AssignAttri("", false, "A149MailId", StringUtil.LTrimStr( (decimal)(A149MailId), 18, 0));
         A245MailDesignEstado = "";
         AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
         A244MailDesignTipo = "";
         AssignAttri("", false, "A244MailDesignTipo", A244MailDesignTipo);
         A241MailCuentaNombre = "";
         AssignAttri("", false, "A241MailCuentaNombre", A241MailCuentaNombre);
         A242MailDireccion = "";
         AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
         A243MailEstado = "";
         AssignAttri("", false, "A243MailEstado", A243MailEstado);
         A246MailDesignAsunto = "";
         AssignAttri("", false, "A246MailDesignAsunto", A246MailDesignAsunto);
         A254MailDesignNombReenvio = "";
         AssignAttri("", false, "A254MailDesignNombReenvio", A254MailDesignNombReenvio);
         A253MailDesignMailReenviar = "";
         AssignAttri("", false, "A253MailDesignMailReenviar", A253MailDesignMailReenviar);
         A251MailDesignCabezal = "";
         AssignAttri("", false, "A251MailDesignCabezal", A251MailDesignCabezal);
         A250MailDesignMensaje = "";
         AssignAttri("", false, "A250MailDesignMensaje", A250MailDesignMensaje);
         A252MailDesignFirma = "";
         AssignAttri("", false, "A252MailDesignFirma", A252MailDesignFirma);
         Z245MailDesignEstado = "";
         Z244MailDesignTipo = "";
         Z246MailDesignAsunto = "";
         Z254MailDesignNombReenvio = "";
         Z253MailDesignMailReenviar = "";
         Z149MailId = 0;
      }

      protected void InitAll1547( )
      {
         A148MailDesignId = 0;
         AssignAttri("", false, "A148MailDesignId", StringUtil.LTrimStr( (decimal)(A148MailDesignId), 18, 0));
         InitializeNonKey1547( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021113032", true, true, false);
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
         context.AddJavascriptSource("maildesign.js", "?202673021113032", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true, false);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMailDesignId_Internalname = "MAILDESIGNID";
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO";
         edtMailId_Internalname = "MAILID";
         edtMailCuentaNombre_Internalname = "MAILCUENTANOMBRE";
         edtMailDireccion_Internalname = "MAILDIRECCION";
         cmbMailEstado_Internalname = "MAILESTADO";
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO";
         edtMailDesignNombReenvio_Internalname = "MAILDESIGNNOMBREENVIO";
         edtMailDesignMailReenviar_Internalname = "MAILDESIGNMAILREENVIAR";
         Maildesigncabezal_Internalname = "MAILDESIGNCABEZAL";
         Maildesignmensaje_Internalname = "MAILDESIGNMENSAJE";
         Maildesignfirma_Internalname = "MAILDESIGNFIRMA";
         cmbMailDesignEstado_Internalname = "MAILDESIGNESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_149_Internalname = "PROMPT_149";
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
         Form.Caption = context.GetMessage( "Mail Design", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbMailDesignEstado_Jsonclick = "";
         cmbMailDesignEstado.Enabled = 1;
         Maildesignfirma_Captionposition = "Left";
         Maildesignfirma_Captionstyle = "";
         Maildesignfirma_Captionclass = " AttributeLabel";
         Maildesignfirma_Enabled = Convert.ToBoolean( 1);
         Maildesignmensaje_Captionposition = "Left";
         Maildesignmensaje_Captionstyle = "";
         Maildesignmensaje_Captionclass = " AttributeLabel";
         Maildesignmensaje_Enabled = Convert.ToBoolean( 1);
         Maildesigncabezal_Captionposition = "Left";
         Maildesigncabezal_Captionstyle = "";
         Maildesigncabezal_Captionclass = " AttributeLabel";
         Maildesigncabezal_Enabled = Convert.ToBoolean( 1);
         edtMailDesignMailReenviar_Jsonclick = "";
         edtMailDesignMailReenviar_Enabled = 1;
         edtMailDesignNombReenvio_Jsonclick = "";
         edtMailDesignNombReenvio_Enabled = 1;
         edtMailDesignAsunto_Jsonclick = "";
         edtMailDesignAsunto_Enabled = 1;
         cmbMailEstado_Jsonclick = "";
         cmbMailEstado.Enabled = 0;
         edtMailDireccion_Jsonclick = "";
         edtMailDireccion_Enabled = 0;
         edtMailCuentaNombre_Jsonclick = "";
         edtMailCuentaNombre_Enabled = 0;
         imgprompt_149_Visible = 1;
         imgprompt_149_Link = "";
         edtMailId_Jsonclick = "";
         edtMailId_Enabled = 1;
         cmbMailDesignTipo_Jsonclick = "";
         cmbMailDesignTipo.Enabled = 1;
         edtMailDesignId_Jsonclick = "";
         edtMailDesignId_Enabled = 0;
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
         cmbMailDesignTipo.Name = "MAILDESIGNTIPO";
         cmbMailDesignTipo.WebTags = "";
         cmbMailDesignTipo.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbMailDesignTipo.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbMailDesignTipo.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbMailDesignTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbMailDesignTipo.ItemCount > 0 )
         {
            A244MailDesignTipo = cmbMailDesignTipo.getValidValue(A244MailDesignTipo);
            AssignAttri("", false, "A244MailDesignTipo", A244MailDesignTipo);
         }
         cmbMailEstado.Name = "MAILESTADO";
         cmbMailEstado.WebTags = "";
         cmbMailEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMailEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbMailEstado.ItemCount > 0 )
         {
            A243MailEstado = cmbMailEstado.getValidValue(A243MailEstado);
            AssignAttri("", false, "A243MailEstado", A243MailEstado);
         }
         cmbMailDesignEstado.Name = "MAILDESIGNESTADO";
         cmbMailDesignEstado.WebTags = "";
         cmbMailDesignEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMailDesignEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbMailDesignEstado.ItemCount > 0 )
         {
            A245MailDesignEstado = cmbMailDesignEstado.getValidValue(A245MailDesignEstado);
            AssignAttri("", false, "A245MailDesignEstado", A245MailDesignEstado);
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

      public void Valid_Mailid( )
      {
         A243MailEstado = cmbMailEstado.CurrentValue;
         cmbMailEstado.CurrentValue = A243MailEstado;
         /* Using cursor T001513 */
         pr_default.execute(11, new Object[] {A149MailId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mail", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MAILID");
            AnyError = 1;
            GX_FocusControl = edtMailId_Internalname;
         }
         A241MailCuentaNombre = T001513_A241MailCuentaNombre[0];
         A242MailDireccion = T001513_A242MailDireccion[0];
         A243MailEstado = T001513_A243MailEstado[0];
         cmbMailEstado.CurrentValue = A243MailEstado;
         pr_default.close(11);
         dynload_actions( ) ;
         if ( cmbMailEstado.ItemCount > 0 )
         {
            A243MailEstado = cmbMailEstado.getValidValue(A243MailEstado);
            cmbMailEstado.CurrentValue = A243MailEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMailEstado.CurrentValue = StringUtil.RTrim( A243MailEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A241MailCuentaNombre", StringUtil.RTrim( A241MailCuentaNombre));
         AssignAttri("", false, "A242MailDireccion", A242MailDireccion);
         AssignAttri("", false, "A243MailEstado", StringUtil.RTrim( A243MailEstado));
         cmbMailEstado.CurrentValue = StringUtil.RTrim( A243MailEstado);
         AssignProp("", false, cmbMailEstado_Internalname, "Values", cmbMailEstado.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7MailDesignId',fld:'vMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MailDesignId',fld:'vMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV13Insert_MailId',fld:'vINSERT_MAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12152',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MAILDESIGNID","{handler:'Valid_Maildesignid',iparms:[]");
         setEventMetadata("VALID_MAILDESIGNID",",oparms:[]}");
         setEventMetadata("VALID_MAILID","{handler:'Valid_Mailid',iparms:[{av:'A149MailId',fld:'MAILID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A241MailCuentaNombre',fld:'MAILCUENTANOMBRE',pic:'',type:'char'},{av:'A242MailDireccion',fld:'MAILDIRECCION',pic:'',type:'svchar'},{av:'cmbMailEstado'},{av:'A243MailEstado',fld:'MAILESTADO',pic:'',type:'char'}]");
         setEventMetadata("VALID_MAILID",",oparms:[{av:'A241MailCuentaNombre',fld:'MAILCUENTANOMBRE',pic:'',type:'char'},{av:'A242MailDireccion',fld:'MAILDIRECCION',pic:'',type:'svchar'},{av:'cmbMailEstado'},{av:'A243MailEstado',fld:'MAILESTADO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_MAILDESIGNMAILREENVIAR","{handler:'Valid_Maildesignmailreenviar',iparms:[]");
         setEventMetadata("VALID_MAILDESIGNMAILREENVIAR",",oparms:[]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z245MailDesignEstado = "";
         Z244MailDesignTipo = "";
         Z246MailDesignAsunto = "";
         Z254MailDesignNombReenvio = "";
         Z253MailDesignMailReenviar = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A244MailDesignTipo = "";
         A243MailEstado = "";
         A245MailDesignEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_149_gximage = "";
         sImgUrl = "";
         A241MailCuentaNombre = "";
         A242MailDireccion = "";
         A246MailDesignAsunto = "";
         A254MailDesignNombReenvio = "";
         A253MailDesignMailReenviar = "";
         ucMaildesigncabezal = new GXUserControl();
         MailDesignCabezal = "";
         ucMaildesignmensaje = new GXUserControl();
         MailDesignMensaje = "";
         ucMaildesignfirma = new GXUserControl();
         MailDesignFirma = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A251MailDesignCabezal = "";
         A250MailDesignMensaje = "";
         A252MailDesignFirma = "";
         AV15Pgmname = "";
         Maildesigncabezal_Objectcall = "";
         Maildesigncabezal_Class = "";
         Maildesigncabezal_Width = "";
         Maildesigncabezal_Height = "";
         Maildesigncabezal_Skin = "";
         Maildesigncabezal_Toolbar = "";
         Maildesigncabezal_Customtoolbar = "";
         Maildesigncabezal_Customconfiguration = "";
         Maildesigncabezal_Buttonpressedid = "";
         Maildesigncabezal_Captionvalue = "";
         Maildesigncabezal_Coltitle = "";
         Maildesigncabezal_Coltitlefont = "";
         Maildesignmensaje_Objectcall = "";
         Maildesignmensaje_Class = "";
         Maildesignmensaje_Width = "";
         Maildesignmensaje_Height = "";
         Maildesignmensaje_Skin = "";
         Maildesignmensaje_Toolbar = "";
         Maildesignmensaje_Customtoolbar = "";
         Maildesignmensaje_Customconfiguration = "";
         Maildesignmensaje_Buttonpressedid = "";
         Maildesignmensaje_Captionvalue = "";
         Maildesignmensaje_Coltitle = "";
         Maildesignmensaje_Coltitlefont = "";
         Maildesignfirma_Objectcall = "";
         Maildesignfirma_Class = "";
         Maildesignfirma_Width = "";
         Maildesignfirma_Height = "";
         Maildesignfirma_Skin = "";
         Maildesignfirma_Toolbar = "";
         Maildesignfirma_Customtoolbar = "";
         Maildesignfirma_Customconfiguration = "";
         Maildesignfirma_Buttonpressedid = "";
         Maildesignfirma_Captionvalue = "";
         Maildesignfirma_Coltitle = "";
         Maildesignfirma_Coltitlefont = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode47 = "";
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
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z251MailDesignCabezal = "";
         Z250MailDesignMensaje = "";
         Z252MailDesignFirma = "";
         Z241MailCuentaNombre = "";
         Z242MailDireccion = "";
         Z243MailEstado = "";
         T00154_A241MailCuentaNombre = new string[] {""} ;
         T00154_A242MailDireccion = new string[] {""} ;
         T00154_A243MailEstado = new string[] {""} ;
         T00155_A148MailDesignId = new long[1] ;
         T00155_A245MailDesignEstado = new string[] {""} ;
         T00155_A244MailDesignTipo = new string[] {""} ;
         T00155_A241MailCuentaNombre = new string[] {""} ;
         T00155_A242MailDireccion = new string[] {""} ;
         T00155_A243MailEstado = new string[] {""} ;
         T00155_A246MailDesignAsunto = new string[] {""} ;
         T00155_A254MailDesignNombReenvio = new string[] {""} ;
         T00155_A253MailDesignMailReenviar = new string[] {""} ;
         T00155_A251MailDesignCabezal = new string[] {""} ;
         T00155_A250MailDesignMensaje = new string[] {""} ;
         T00155_A252MailDesignFirma = new string[] {""} ;
         T00155_A149MailId = new long[1] ;
         T00156_A241MailCuentaNombre = new string[] {""} ;
         T00156_A242MailDireccion = new string[] {""} ;
         T00156_A243MailEstado = new string[] {""} ;
         T00157_A148MailDesignId = new long[1] ;
         T00153_A148MailDesignId = new long[1] ;
         T00153_A245MailDesignEstado = new string[] {""} ;
         T00153_A244MailDesignTipo = new string[] {""} ;
         T00153_A246MailDesignAsunto = new string[] {""} ;
         T00153_A254MailDesignNombReenvio = new string[] {""} ;
         T00153_A253MailDesignMailReenviar = new string[] {""} ;
         T00153_A251MailDesignCabezal = new string[] {""} ;
         T00153_A250MailDesignMensaje = new string[] {""} ;
         T00153_A252MailDesignFirma = new string[] {""} ;
         T00153_A149MailId = new long[1] ;
         T00158_A148MailDesignId = new long[1] ;
         T00159_A148MailDesignId = new long[1] ;
         T00152_A148MailDesignId = new long[1] ;
         T00152_A245MailDesignEstado = new string[] {""} ;
         T00152_A244MailDesignTipo = new string[] {""} ;
         T00152_A246MailDesignAsunto = new string[] {""} ;
         T00152_A254MailDesignNombReenvio = new string[] {""} ;
         T00152_A253MailDesignMailReenviar = new string[] {""} ;
         T00152_A251MailDesignCabezal = new string[] {""} ;
         T00152_A250MailDesignMensaje = new string[] {""} ;
         T00152_A252MailDesignFirma = new string[] {""} ;
         T00152_A149MailId = new long[1] ;
         T001513_A241MailCuentaNombre = new string[] {""} ;
         T001513_A242MailDireccion = new string[] {""} ;
         T001513_A243MailEstado = new string[] {""} ;
         T001514_A148MailDesignId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.maildesign__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.maildesign__default(),
            new Object[][] {
                new Object[] {
               T00152_A148MailDesignId, T00152_A245MailDesignEstado, T00152_A244MailDesignTipo, T00152_A246MailDesignAsunto, T00152_A254MailDesignNombReenvio, T00152_A253MailDesignMailReenviar, T00152_A251MailDesignCabezal, T00152_A250MailDesignMensaje, T00152_A252MailDesignFirma, T00152_A149MailId
               }
               , new Object[] {
               T00153_A148MailDesignId, T00153_A245MailDesignEstado, T00153_A244MailDesignTipo, T00153_A246MailDesignAsunto, T00153_A254MailDesignNombReenvio, T00153_A253MailDesignMailReenviar, T00153_A251MailDesignCabezal, T00153_A250MailDesignMensaje, T00153_A252MailDesignFirma, T00153_A149MailId
               }
               , new Object[] {
               T00154_A241MailCuentaNombre, T00154_A242MailDireccion, T00154_A243MailEstado
               }
               , new Object[] {
               T00155_A148MailDesignId, T00155_A245MailDesignEstado, T00155_A244MailDesignTipo, T00155_A241MailCuentaNombre, T00155_A242MailDireccion, T00155_A243MailEstado, T00155_A246MailDesignAsunto, T00155_A254MailDesignNombReenvio, T00155_A253MailDesignMailReenviar, T00155_A251MailDesignCabezal,
               T00155_A250MailDesignMensaje, T00155_A252MailDesignFirma, T00155_A149MailId
               }
               , new Object[] {
               T00156_A241MailCuentaNombre, T00156_A242MailDireccion, T00156_A243MailEstado
               }
               , new Object[] {
               T00157_A148MailDesignId
               }
               , new Object[] {
               T00158_A148MailDesignId
               }
               , new Object[] {
               T00159_A148MailDesignId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001513_A241MailCuentaNombre, T001513_A242MailDireccion, T001513_A243MailEstado
               }
               , new Object[] {
               T001514_A148MailDesignId
               }
            }
         );
         AV15Pgmname = "MailDesign";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound47 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtMailDesignId_Enabled ;
      private int edtMailId_Enabled ;
      private int imgprompt_149_Visible ;
      private int edtMailCuentaNombre_Enabled ;
      private int edtMailDireccion_Enabled ;
      private int edtMailDesignAsunto_Enabled ;
      private int edtMailDesignNombReenvio_Enabled ;
      private int edtMailDesignMailReenviar_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Maildesigncabezal_Color ;
      private int Maildesigncabezal_Coltitlecolor ;
      private int Maildesignmensaje_Color ;
      private int Maildesignmensaje_Coltitlecolor ;
      private int Maildesignfirma_Color ;
      private int Maildesignfirma_Coltitlecolor ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV16GXV1 ;
      private int idxLst ;
      private long wcpOAV7MailDesignId ;
      private long Z148MailDesignId ;
      private long Z149MailId ;
      private long N149MailId ;
      private long A149MailId ;
      private long AV7MailDesignId ;
      private long A148MailDesignId ;
      private long AV13Insert_MailId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z245MailDesignEstado ;
      private string Z244MailDesignTipo ;
      private string Z246MailDesignAsunto ;
      private string Z254MailDesignNombReenvio ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbMailDesignTipo_Internalname ;
      private string A244MailDesignTipo ;
      private string A243MailEstado ;
      private string cmbMailEstado_Internalname ;
      private string A245MailDesignEstado ;
      private string cmbMailDesignEstado_Internalname ;
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
      private string edtMailDesignId_Internalname ;
      private string TempTags ;
      private string edtMailDesignId_Jsonclick ;
      private string cmbMailDesignTipo_Jsonclick ;
      private string edtMailId_Internalname ;
      private string edtMailId_Jsonclick ;
      private string imgprompt_149_gximage ;
      private string sImgUrl ;
      private string imgprompt_149_Internalname ;
      private string imgprompt_149_Link ;
      private string edtMailCuentaNombre_Internalname ;
      private string A241MailCuentaNombre ;
      private string edtMailCuentaNombre_Jsonclick ;
      private string edtMailDireccion_Internalname ;
      private string edtMailDireccion_Jsonclick ;
      private string cmbMailEstado_Jsonclick ;
      private string edtMailDesignAsunto_Internalname ;
      private string A246MailDesignAsunto ;
      private string edtMailDesignAsunto_Jsonclick ;
      private string edtMailDesignNombReenvio_Internalname ;
      private string A254MailDesignNombReenvio ;
      private string edtMailDesignNombReenvio_Jsonclick ;
      private string edtMailDesignMailReenviar_Internalname ;
      private string edtMailDesignMailReenviar_Jsonclick ;
      private string Maildesigncabezal_Internalname ;
      private string Maildesigncabezal_Captionclass ;
      private string Maildesigncabezal_Captionstyle ;
      private string Maildesigncabezal_Captionposition ;
      private string Maildesignmensaje_Internalname ;
      private string Maildesignmensaje_Captionclass ;
      private string Maildesignmensaje_Captionstyle ;
      private string Maildesignmensaje_Captionposition ;
      private string Maildesignfirma_Internalname ;
      private string Maildesignfirma_Captionclass ;
      private string Maildesignfirma_Captionstyle ;
      private string Maildesignfirma_Captionposition ;
      private string cmbMailDesignEstado_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string Maildesigncabezal_Objectcall ;
      private string Maildesigncabezal_Class ;
      private string Maildesigncabezal_Width ;
      private string Maildesigncabezal_Height ;
      private string Maildesigncabezal_Skin ;
      private string Maildesigncabezal_Toolbar ;
      private string Maildesigncabezal_Customtoolbar ;
      private string Maildesigncabezal_Customconfiguration ;
      private string Maildesigncabezal_Buttonpressedid ;
      private string Maildesigncabezal_Captionvalue ;
      private string Maildesigncabezal_Coltitle ;
      private string Maildesigncabezal_Coltitlefont ;
      private string Maildesignmensaje_Objectcall ;
      private string Maildesignmensaje_Class ;
      private string Maildesignmensaje_Width ;
      private string Maildesignmensaje_Height ;
      private string Maildesignmensaje_Skin ;
      private string Maildesignmensaje_Toolbar ;
      private string Maildesignmensaje_Customtoolbar ;
      private string Maildesignmensaje_Customconfiguration ;
      private string Maildesignmensaje_Buttonpressedid ;
      private string Maildesignmensaje_Captionvalue ;
      private string Maildesignmensaje_Coltitle ;
      private string Maildesignmensaje_Coltitlefont ;
      private string Maildesignfirma_Objectcall ;
      private string Maildesignfirma_Class ;
      private string Maildesignfirma_Width ;
      private string Maildesignfirma_Height ;
      private string Maildesignfirma_Skin ;
      private string Maildesignfirma_Toolbar ;
      private string Maildesignfirma_Customtoolbar ;
      private string Maildesignfirma_Customconfiguration ;
      private string Maildesignfirma_Buttonpressedid ;
      private string Maildesignfirma_Captionvalue ;
      private string Maildesignfirma_Coltitle ;
      private string Maildesignfirma_Coltitlefont ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode47 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string Z241MailCuentaNombre ;
      private string Z243MailEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Maildesigncabezal_Enabled ;
      private bool Maildesigncabezal_Toolbarcancollapse ;
      private bool Maildesigncabezal_Toolbarexpanded ;
      private bool Maildesigncabezal_Isabstractlayoutcontrol ;
      private bool Maildesigncabezal_Usercontroliscolumn ;
      private bool Maildesigncabezal_Visible ;
      private bool Maildesignmensaje_Enabled ;
      private bool Maildesignmensaje_Toolbarcancollapse ;
      private bool Maildesignmensaje_Toolbarexpanded ;
      private bool Maildesignmensaje_Isabstractlayoutcontrol ;
      private bool Maildesignmensaje_Usercontroliscolumn ;
      private bool Maildesignmensaje_Visible ;
      private bool Maildesignfirma_Enabled ;
      private bool Maildesignfirma_Toolbarcancollapse ;
      private bool Maildesignfirma_Toolbarexpanded ;
      private bool Maildesignfirma_Isabstractlayoutcontrol ;
      private bool Maildesignfirma_Usercontroliscolumn ;
      private bool Maildesignfirma_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string MailDesignCabezal ;
      private string MailDesignMensaje ;
      private string MailDesignFirma ;
      private string A251MailDesignCabezal ;
      private string A250MailDesignMensaje ;
      private string A252MailDesignFirma ;
      private string Z251MailDesignCabezal ;
      private string Z250MailDesignMensaje ;
      private string Z252MailDesignFirma ;
      private string Z253MailDesignMailReenviar ;
      private string A242MailDireccion ;
      private string A253MailDesignMailReenviar ;
      private string Z242MailDireccion ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucMaildesigncabezal ;
      private GXUserControl ucMaildesignmensaje ;
      private GXUserControl ucMaildesignfirma ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMailDesignTipo ;
      private GXCombobox cmbMailEstado ;
      private GXCombobox cmbMailDesignEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00154_A241MailCuentaNombre ;
      private string[] T00154_A242MailDireccion ;
      private string[] T00154_A243MailEstado ;
      private long[] T00155_A148MailDesignId ;
      private string[] T00155_A245MailDesignEstado ;
      private string[] T00155_A244MailDesignTipo ;
      private string[] T00155_A241MailCuentaNombre ;
      private string[] T00155_A242MailDireccion ;
      private string[] T00155_A243MailEstado ;
      private string[] T00155_A246MailDesignAsunto ;
      private string[] T00155_A254MailDesignNombReenvio ;
      private string[] T00155_A253MailDesignMailReenviar ;
      private string[] T00155_A251MailDesignCabezal ;
      private string[] T00155_A250MailDesignMensaje ;
      private string[] T00155_A252MailDesignFirma ;
      private long[] T00155_A149MailId ;
      private string[] T00156_A241MailCuentaNombre ;
      private string[] T00156_A242MailDireccion ;
      private string[] T00156_A243MailEstado ;
      private long[] T00157_A148MailDesignId ;
      private long[] T00153_A148MailDesignId ;
      private string[] T00153_A245MailDesignEstado ;
      private string[] T00153_A244MailDesignTipo ;
      private string[] T00153_A246MailDesignAsunto ;
      private string[] T00153_A254MailDesignNombReenvio ;
      private string[] T00153_A253MailDesignMailReenviar ;
      private string[] T00153_A251MailDesignCabezal ;
      private string[] T00153_A250MailDesignMensaje ;
      private string[] T00153_A252MailDesignFirma ;
      private long[] T00153_A149MailId ;
      private long[] T00158_A148MailDesignId ;
      private long[] T00159_A148MailDesignId ;
      private long[] T00152_A148MailDesignId ;
      private string[] T00152_A245MailDesignEstado ;
      private string[] T00152_A244MailDesignTipo ;
      private string[] T00152_A246MailDesignAsunto ;
      private string[] T00152_A254MailDesignNombReenvio ;
      private string[] T00152_A253MailDesignMailReenviar ;
      private string[] T00152_A251MailDesignCabezal ;
      private string[] T00152_A250MailDesignMensaje ;
      private string[] T00152_A252MailDesignFirma ;
      private long[] T00152_A149MailId ;
      private string[] T001513_A241MailCuentaNombre ;
      private string[] T001513_A242MailDireccion ;
      private string[] T001513_A243MailEstado ;
      private long[] T001514_A148MailDesignId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class maildesign__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class maildesign__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00152;
        prmT00152 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT00153;
        prmT00153 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT00154;
        prmT00154 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00155;
        prmT00155 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT00156;
        prmT00156 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT00157;
        prmT00157 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT00158;
        prmT00158 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT00159;
        prmT00159 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT001510;
        prmT001510 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0) ,
        new ParDef("@MailDesignEstado",GXType.NChar,3,0) ,
        new ParDef("@MailDesignTipo",GXType.NChar,1,0) ,
        new ParDef("@MailDesignAsunto",GXType.NChar,80,0) ,
        new ParDef("@MailDesignNombReenvio",GXType.NChar,80,0) ,
        new ParDef("@MailDesignMailReenviar",GXType.NVarChar,100,0) ,
        new ParDef("@MailDesignCabezal",GXType.NVarChar,2097152,0) ,
        new ParDef("@MailDesignMensaje",GXType.NVarChar,2097152,0) ,
        new ParDef("@MailDesignFirma",GXType.NVarChar,2097152,0) ,
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT001511;
        prmT001511 = new Object[] {
        new ParDef("@MailDesignEstado",GXType.NChar,3,0) ,
        new ParDef("@MailDesignTipo",GXType.NChar,1,0) ,
        new ParDef("@MailDesignAsunto",GXType.NChar,80,0) ,
        new ParDef("@MailDesignNombReenvio",GXType.NChar,80,0) ,
        new ParDef("@MailDesignMailReenviar",GXType.NVarChar,100,0) ,
        new ParDef("@MailDesignCabezal",GXType.NVarChar,2097152,0) ,
        new ParDef("@MailDesignMensaje",GXType.NVarChar,2097152,0) ,
        new ParDef("@MailDesignFirma",GXType.NVarChar,2097152,0) ,
        new ParDef("@MailId",GXType.Decimal,18,0) ,
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT001512;
        prmT001512 = new Object[] {
        new ParDef("@MailDesignId",GXType.Decimal,18,0)
        };
        Object[] prmT001513;
        prmT001513 = new Object[] {
        new ParDef("@MailId",GXType.Decimal,18,0)
        };
        Object[] prmT001514;
        prmT001514 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00152", "SELECT [MailDesignId], [MailDesignEstado], [MailDesignTipo], [MailDesignAsunto], [MailDesignNombReenvio], [MailDesignMailReenviar], [MailDesignCabezal], [MailDesignMensaje], [MailDesignFirma], [MailId] FROM [MailDesign] WITH (UPDLOCK) WHERE [MailDesignId] = @MailDesignId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00153", "SELECT [MailDesignId], [MailDesignEstado], [MailDesignTipo], [MailDesignAsunto], [MailDesignNombReenvio], [MailDesignMailReenviar], [MailDesignCabezal], [MailDesignMensaje], [MailDesignFirma], [MailId] FROM [MailDesign] WHERE [MailDesignId] = @MailDesignId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00154", "SELECT [MailCuentaNombre], [MailDireccion], [MailEstado] FROM [Mail] WHERE [MailId] = @MailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00155", "SELECT TM1.[MailDesignId], TM1.[MailDesignEstado], TM1.[MailDesignTipo], T2.[MailCuentaNombre], T2.[MailDireccion], T2.[MailEstado], TM1.[MailDesignAsunto], TM1.[MailDesignNombReenvio], TM1.[MailDesignMailReenviar], TM1.[MailDesignCabezal], TM1.[MailDesignMensaje], TM1.[MailDesignFirma], TM1.[MailId] FROM ([MailDesign] TM1 INNER JOIN [Mail] T2 ON T2.[MailId] = TM1.[MailId]) WHERE TM1.[MailDesignId] = @MailDesignId ORDER BY TM1.[MailDesignId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00156", "SELECT [MailCuentaNombre], [MailDireccion], [MailEstado] FROM [Mail] WHERE [MailId] = @MailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00157", "SELECT [MailDesignId] FROM [MailDesign] WHERE [MailDesignId] = @MailDesignId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00158", "SELECT TOP 1 [MailDesignId] FROM [MailDesign] WHERE ( [MailDesignId] > @MailDesignId) ORDER BY [MailDesignId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00159", "SELECT TOP 1 [MailDesignId] FROM [MailDesign] WHERE ( [MailDesignId] < @MailDesignId) ORDER BY [MailDesignId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00159,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001510", "INSERT INTO [MailDesign]([MailDesignId], [MailDesignEstado], [MailDesignTipo], [MailDesignAsunto], [MailDesignNombReenvio], [MailDesignMailReenviar], [MailDesignCabezal], [MailDesignMensaje], [MailDesignFirma], [MailId]) VALUES(@MailDesignId, @MailDesignEstado, @MailDesignTipo, @MailDesignAsunto, @MailDesignNombReenvio, @MailDesignMailReenviar, @MailDesignCabezal, @MailDesignMensaje, @MailDesignFirma, @MailId)", GxErrorMask.GX_NOMASK,prmT001510)
           ,new CursorDef("T001511", "UPDATE [MailDesign] SET [MailDesignEstado]=@MailDesignEstado, [MailDesignTipo]=@MailDesignTipo, [MailDesignAsunto]=@MailDesignAsunto, [MailDesignNombReenvio]=@MailDesignNombReenvio, [MailDesignMailReenviar]=@MailDesignMailReenviar, [MailDesignCabezal]=@MailDesignCabezal, [MailDesignMensaje]=@MailDesignMensaje, [MailDesignFirma]=@MailDesignFirma, [MailId]=@MailId  WHERE [MailDesignId] = @MailDesignId", GxErrorMask.GX_NOMASK,prmT001511)
           ,new CursorDef("T001512", "DELETE FROM [MailDesign]  WHERE [MailDesignId] = @MailDesignId", GxErrorMask.GX_NOMASK,prmT001512)
           ,new CursorDef("T001513", "SELECT [MailCuentaNombre], [MailDireccion], [MailEstado] FROM [Mail] WHERE [MailId] = @MailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001513,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001514", "SELECT [MailDesignId] FROM [MailDesign] ORDER BY [MailDesignId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001514,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((string[]) buf[7])[0] = rslt.getString(8, 80);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
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
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
